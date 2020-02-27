// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.DicomDemos;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.ExternalStore.DataAccessLayer.Configuration;
using Leadtools.Logging;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Medical.ExternalStore.Addin.Process;
using Leadtools.Medical.Winforms.ExternalStore;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Medical.ExternalStore.Addin.Processes;
using Leadtools.Medical.ExternalStore.Addin;
using Leadtools.Medical.Storage.AddIns.Configuration;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
using System.Diagnostics;
using Leadtools.Medical.DataAccessLayer.Configuration;
#endif

namespace Leadtools.Medical.ExternalStore.Atmos.Addin.Processes
{
   public class ExternalStoreServerMessage : IProcessServiceMessage
   {
      #region IProcessServiceMessage Members

      public bool CanProcess(string MessageId)
      {
         return (
                 MessageId == ExternalStoreMessage.ExternalStore ||
                 MessageId == ExternalStoreMessage.CancelExternalStore ||
                 MessageId == ExternalStoreMessage.Clean ||
                 MessageId == ExternalStoreMessage.Restore ||
                 MessageId == ExternalStoreMessage.CancelRestore ||
                 MessageId == ExternalStoreMessage.Reset ||
                 MessageId == ExternalStoreMessage.SettingsChanged 
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
                 ||
                 MessageId == MessageNames.IsAddinHealthy
#endif
                 );
      }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
      private string _assemblyName = string.Empty;
      public string AssemblyName
      {
         get
         {
            if (string.IsNullOrEmpty(_assemblyName))
            {
               System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
               if (assembly != null)
               {
                  _assemblyName = assembly.ManifestModule.Name;
               }
            }
            return _assemblyName;
         }
      }

      public static T GetAgent<T>(System.Configuration.Configuration configuration, DataAccessConfigurationView view )
      {
         T agent;

         if (!DataAccessServices.IsDataAccessServiceRegistered<T>())
         {
            agent = DataAccessFactory.GetInstance(view).CreateDataAccessAgent<T>();
            DataAccessServices.RegisterDataAccessService<T>(agent);
         }
         else
         {
            agent = DataAccessServices.GetDataAccessService<T>();
         }
         return agent;
      }

      public bool CanAccessDatabase(out string error)
      {
         error = string.Empty;
         bool ret = false;
         try
         {
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(Module.ServiceDirectory);

            IExternalStoreDataAccessAgent externalStoreAgent = GetAgent<IExternalStoreDataAccessAgent>(configuration, new ExternalStoreDataAccessConfigurationView(configuration, null, Module.ServiceName));
            IStorageDataAccessAgent storageAgent = GetAgent<IStorageDataAccessAgent>(configuration, new StorageDataAccessConfigurationView(configuration, null, Module.ServiceName));

            bool bContinue = true;
            if (externalStoreAgent == null)
            {
               error = string.Format("{0} {1}", AssemblyName, "Cannot create IExternalStoreDataAccessAgent");
               bContinue = false;
            }

            if (bContinue)
            {
               if (storageAgent == null)
               {
                  error = string.Format("{0} {1}", AssemblyName, "Cannot create IStorageDataAccessAgent");
                  bContinue = false;
               }
            }

            if (bContinue)
            {
               externalStoreAgent.IsExternalStored("notUsed");
               storageAgent.MaxQueryResults = 10;
               storageAgent.IsPatientsExists("patientIdNotUsed");
            }
         }
         catch (Exception e)
         {
            error = string.Format("{0} {1}", AssemblyName, e.Message);
         }

         ret = string.IsNullOrEmpty(error);
         return ret;
      }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)

      public ServiceMessage Process(ServiceMessage Message)
      {
            ServiceMessage serviceMessage = null;
         switch (Message.Message)
         {
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
            case MessageNames.IsAddinHealthy:
               serviceMessage = new ServiceMessage();
               string error;
               serviceMessage.Message = Message.Message;
               serviceMessage.Success = CanAccessDatabase(out error);
               serviceMessage.Error = error;
               break;
#endif
            case ExternalStoreMessage.ExternalStore:
               ExternalStore(Message.Data[0] as string);
               break;
            case ExternalStoreMessage.CancelExternalStore:
               CancelExternalStore();
               break;
            case ExternalStoreMessage.Clean:
               int expirationDays = 0;
               int ? intValue = Message.Data[1] as int ?;
               if (intValue.HasValue)
               {
                  expirationDays = intValue.Value;
               }
               Clean(Message.Data[0] as string, expirationDays);
               break;
            case ExternalStoreMessage.Restore:
               Restore(Message.Data[0] as string, Message.Data[1] as DateRange);
               break;
            case ExternalStoreMessage.CancelRestore:
               CancelRestore();
               break;
            case ExternalStoreMessage.Reset:
               DateRange range = Message.Data[0] as DateRange;
               Reset(range);
               break;

            case ExternalStoreMessage.SettingsChanged:
               DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Received 'ExternalStoreMessage.SettingsChanged' Message");

               Module.StopExternalStoreJobs();

               IEnumerable<ICrud> allCruds = DataAccessServiceLocator.RetrieveAll<ICrud>();
               foreach (ICrud crud in allCruds)
               {
                  crud.SettingsChanged();
               }
               break;
         }
         return serviceMessage;
      }

      #endregion

      /// <summary>
      /// Initiates the 'External Store' operation.
      /// </summary>
      private static void ExternalStore(string externalStoreGuid)
      {
         try
         {
            IExternalStoreDataAccessAgent externalStoreAgent;
            IStorageDataAccessAgent storageAgent;
            
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(Module.ServiceDirectory);

            // External Store Agent
            if (!DataAccessServices.IsDataAccessServiceRegistered<IExternalStoreDataAccessAgent>())
            {
               externalStoreAgent = DataAccessFactory.GetInstance(new ExternalStoreDataAccessConfigurationView(configuration, null, Module.ServiceName) ).CreateDataAccessAgent<IExternalStoreDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IExternalStoreDataAccessAgent>(externalStoreAgent);
            }
            else
            {
               externalStoreAgent = DataAccessServices.GetDataAccessService<IExternalStoreDataAccessAgent>();
            }

            // Storage Agent
            if (!DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent>())
            {
               storageAgent = DataAccessFactory.GetInstance(new StorageDataAccessConfigurationView(configuration, null, Module.ServiceName) ).CreateDataAccessAgent<IStorageDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IStorageDataAccessAgent>(storageAgent);
            }
            else
            {
               storageAgent = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();
            }

            if (externalStoreAgent != null && storageAgent != null)
            {
               ExternalStoreOptions options = Module.Options;
               if (options != null)
               {
                  new ExternalStoreProcess(Module.Options, externalStoreGuid, Module.ServiceName).Run(externalStoreAgent, storageAgent);
               }
               else
               {
                  string message = string.Format("Before using the 'External Store' tools, you must configure an 'External Store' addin and then click the 'Apply' button.");
                  Logger.Global.SystemMessage(LogType.Error, message, Module.ServiceName);
               }

            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemLogException(e, Module.ServiceName);
         } 
      }

      private static void Clean(string externalStoreGuid, int expirationDays)
      {
         try
         {
            IExternalStoreDataAccessAgent externalStoreAgent;
            IStorageDataAccessAgent storageAgent;
            
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(Module.ServiceDirectory);

            if (!DataAccessServices.IsDataAccessServiceRegistered<IExternalStoreDataAccessAgent>())
            {
               externalStoreAgent = DataAccessFactory.GetInstance(new ExternalStoreDataAccessConfigurationView(configuration, null, Module.ServiceName) ).CreateDataAccessAgent<IExternalStoreDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IExternalStoreDataAccessAgent>(externalStoreAgent);
            }
            else
            {
               externalStoreAgent = DataAccessServices.GetDataAccessService<IExternalStoreDataAccessAgent>();
            }

            if (!DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent>())
            {
               storageAgent = DataAccessFactory.GetInstance(new StorageDataAccessConfigurationView(configuration, null, Module.ServiceName) ).CreateDataAccessAgent<IStorageDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IStorageDataAccessAgent>(storageAgent);
            }
            else
            {
               storageAgent = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();
            }

            if (externalStoreAgent != null && storageAgent != null)
            {
               StorageAddInsConfiguration storageAddinsConfiguration = Module.StorageConfigManager.GetStorageAddInsSettings();
               new CleanProcess(Module.Options, externalStoreGuid, Module.ServiceName, storageAddinsConfiguration).Run(externalStoreAgent, storageAgent, expirationDays);
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemLogException(e, Module.ServiceName);
         }      
      }

      private static void Restore(string externalStoreGuid, DateRange range)
      {
         try
         {
            IExternalStoreDataAccessAgent externalStoreAgent;
            IStorageDataAccessAgent storageAgent;
            
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(Module.ServiceDirectory);

            if (!DataAccessServices.IsDataAccessServiceRegistered<IExternalStoreDataAccessAgent>())
            {
               externalStoreAgent = DataAccessFactory.GetInstance(new ExternalStoreDataAccessConfigurationView(configuration, null, Module.ServiceName) ).CreateDataAccessAgent<IExternalStoreDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IExternalStoreDataAccessAgent>(externalStoreAgent);
            }
            else
            {
               externalStoreAgent = DataAccessServices.GetDataAccessService<IExternalStoreDataAccessAgent>();
            }

            if (!DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent>())
            {
               storageAgent = DataAccessFactory.GetInstance(new StorageDataAccessConfigurationView(configuration, null, Module.ServiceName) ).CreateDataAccessAgent<IStorageDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IStorageDataAccessAgent>(storageAgent);
            }
            else
            {
               storageAgent = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();
            }

            if (externalStoreAgent != null && storageAgent != null)
            {
               StorageAddInsConfiguration storageAddinsConfiguration = Module.StorageConfigManager.GetStorageAddInsSettings();

               new RestoreProcess(Module.Options, externalStoreGuid, Module.ServiceName, storageAddinsConfiguration).Run(externalStoreAgent, storageAgent, range);
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemLogException(e, Module.ServiceName);
         }      
      }

      private static void CancelExternalStore()
      {
         string externalStoreGuid = string.Empty;
         new ExternalStoreProcess(Module.Options, externalStoreGuid, Module.ServiceName).Cancel();
      }

      private static void CancelRestore()
      {
         string externalStoreGuid = string.Empty;
         StorageAddInsConfiguration storageAddinsConfiguration = Module.StorageConfigManager.GetStorageAddInsSettings();
         new RestoreProcess(Module.Options, externalStoreGuid, Module.ServiceName, storageAddinsConfiguration).Cancel();
      }

      /// <summary>
      /// Initiates the reset process.
      /// </summary>
      /// <param name="range">The date range to reset.</param>
      private static void Reset(DateRange range)
      {
         try
         {
            IExternalStoreDataAccessAgent externalStoreAgent;

            if (!DataAccessServices.IsDataAccessServiceRegistered<IExternalStoreDataAccessAgent>())
            {
               System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(Module.ServiceDirectory);
               externalStoreAgent = DataAccessFactory.GetInstance(new ExternalStoreDataAccessConfigurationView(configuration, null, Module.ServiceName)).CreateDataAccessAgent<IExternalStoreDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IExternalStoreDataAccessAgent>(externalStoreAgent);
            }
            else
               externalStoreAgent = DataAccessServices.GetDataAccessService<IExternalStoreDataAccessAgent>();

            if (externalStoreAgent != null)
            {
               new ResetProcess(Module.ServerAE).Run(externalStoreAgent, range);
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemLogException(e, Module.ServiceName);
         }
      }
   }
}
