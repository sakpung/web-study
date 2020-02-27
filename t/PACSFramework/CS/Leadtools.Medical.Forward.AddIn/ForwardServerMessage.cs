// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.Winforms.Forwarder;
using System.Diagnostics;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Forward.DataAccessLayer;
using Leadtools.Medical.Forward.DataAccessLayer.Configuration;
using Leadtools.Medical.Forwarder.AddIn.Processes;
using Leadtools.Dicom.AddIn;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using System.Net;
using Leadtools.Dicom.Scu;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Logging;
using Leadtools.DicomDemos;
using Leadtools.Dicom.Common.Extensions;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.DataAccessLayer.Configuration;
#endif 

namespace Leadtools.Medical.Forwarder.AddIn
{
   /// <summary>
   /// Process forwarding messages sent to the server.
   /// </summary>
   public class ForwardServerMessage : IProcessServiceMessage
   {
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
         try
         {
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(Module.ServiceDirectory);

            IForwardDataAccessAgent forwardAgent = GetAgent<IForwardDataAccessAgent>(configuration, new ForwardDataAccessConfigurationView(configuration, null, Module.ServiceName));
            IStorageDataAccessAgent storageAgent = GetAgent<IStorageDataAccessAgent>(configuration, new StorageDataAccessConfigurationView(configuration, null, Module.ServiceName));
            IAeManagementDataAccessAgent aeManagementAgent = GetAgent<IAeManagementDataAccessAgent>(configuration, new AeManagementDataAccessConfigurationView(configuration, null, Module.ServiceName));

            bool bContinue = true;
            if (forwardAgent == null)
            {
               error = string.Format("{0} {1}", AssemblyName, "Cannot create IForwardDataAccessAgent");
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
               if (aeManagementAgent == null)
               {
                  error = string.Format("{0} {1}", AssemblyName, "Cannot create IAeManagementDataAccessAgent");
                  bContinue = false;
               }
            }

            if (bContinue)
            {
               forwardAgent.IsForwarded("notUsed");

               storageAgent.MaxQueryResults = 10;
               storageAgent.IsPatientsExists("patientIdNotUsed");

               aeManagementAgent.GetAeTitle("notUsed");
            }
         }
         catch (Exception e)
         {
            error = string.Format("{0} {1}", AssemblyName, e.Message);
         }

         bool ret = string.IsNullOrEmpty(error);
         return ret;
      }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)

      #region IProcessServiceMessage Members

      /// <summary>
      /// Determines whether this instance can process the specified message id.
      /// </summary>
      /// <param name="MessageId">The message id.</param>
      /// <returns>
      ///   <c>true</c> if this instance can process the specified message id; otherwise, <c>false</c>.
      /// </returns>
      public bool CanProcess(string MessageId)
      {
         return (MessageId == ForwarderMessage.Forward ||
#if LEADTOOLS_V18_OR_LATER
                 MessageId == ForwarderMessage.CancelForward ||
                 MessageId == ForwarderMessage.CancelClean ||
#endif // #if LEADTOOLS_V18_OR_LATER
                 MessageId == ForwarderMessage.Clean ||
                 MessageId == ForwarderMessage.Reset 
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
                 ||
                 MessageId == MessageNames.IsAddinHealthy
#endif
                 || MessageId ==  MessageNames.ServiceShuttingDown
                 );
      }

      /// <summary>
      /// Processes the specified message.
      /// </summary>
      /// <param name="Message">The message to be processed.</param>
      /// <returns></returns>
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
            case ForwarderMessage.Forward:
               Forward(Message.Data[0] as string);
               break;
#if LEADTOOLS_V18_OR_LATER
            case ForwarderMessage.CancelForward:
               CancelForward();
               break;

            case ForwarderMessage.CancelClean:
               CancelClean();
               break;
#endif // #if LEADTOOLS_V18_OR_LATER

            case MessageNames.ServiceShuttingDown:
               Logger.Global.SystemMessage(LogType.Information, string.Format("[Forwarder] Received ServiceShuttingDown message"), Module.ServerAE);
               Cancel_ServiceShuttingDown();
               break;

            case ForwarderMessage.Clean:
               Clean();
               break;
            case ForwarderMessage.Reset:
               DateRange range = Message.Data[0] as DateRange;

               Reset(range);
               break;
         }
         return serviceMessage;
      }

      #endregion

      /// <summary>
      /// Initiates the forward process.
      /// </summary>
      private void Forward(string destinationAE)
      {
         try
         {
            IForwardDataAccessAgent forwardAgent;
            IAeManagementDataAccessAgent aeAgent;

            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(Module.ServiceDirectory);

            if (!DataAccessServices.IsDataAccessServiceRegistered<IForwardDataAccessAgent>())
            {
               forwardAgent = DataAccessFactory.GetInstance(new ForwardDataAccessConfigurationView(configuration, null, Module.ServiceName)).CreateDataAccessAgent<IForwardDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IForwardDataAccessAgent>(forwardAgent);
            }
            else
               forwardAgent = DataAccessServices.GetDataAccessService<IForwardDataAccessAgent>();

            if (!DataAccessServices.IsDataAccessServiceRegistered<IAeManagementDataAccessAgent>())
            {
               aeAgent = DataAccessFactory.GetInstance(new AeManagementDataAccessConfigurationView(configuration, null, Module.ServiceName)).CreateDataAccessAgent<IAeManagementDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IAeManagementDataAccessAgent>(aeAgent);
            }
            else
               aeAgent = DataAccessServices.GetDataAccessService<IAeManagementDataAccessAgent>();

            if (forwardAgent != null && aeAgent != null)
            {
               AeInfoExtended ae = aeAgent.GetAeTitle(destinationAE);

               if (ae != null)
               {
#if LEADTOOLS_V20_OR_LATER
                  // Update dbo.AeInfo.LastAccessDate to Date.Now
                  ae.LastAccessDate = DateTime.Now;
                  aeAgent.Update(ae.AETitle, ae);
#endif

                  DicomScp scp = null;
                  IPAddress address = IPAddress.None;

                  if (!IPAddress.TryParse(ae.Address, out address))
                  {
                     IPHostEntry host = Dns.GetHostEntry(ae.Address);

                     if (host.AddressList.Length > 0)
                     {
                        address = host.AddressList[0];
                     }
                  }

                  if (address != IPAddress.None)
                  {
                     scp = new DicomScp(address, ae.AETitle, ae.Port) { Timeout = Module.Timeout };

                     new ForwardProcess(Module.Options, Module.ServerAE).Run(scp, forwardAgent);
                  }
                  else
                  {
                     string message = string.Format("[Forwarder] Could resolve host name ({0}) not found on server", ae.Address);

                     Logger.Global.SystemMessage(LogType.Error, message, Module.ServerAE);
                  }
               }
               else
               {
                  string message = string.Format("[Forwarder] AE title ({0}) not found on server", destinationAE);

                  Logger.Global.SystemMessage(LogType.Warning, message, Module.ServerAE);
               }
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemMessage(LogType.Error, e.Message, Module.ServerAE);
         }
      }

      /// <summary>
      /// Initiates the clean process.
      /// </summary>
      private void Clean()
      {
         try
         {
            IForwardDataAccessAgent forwardAgent;
            IStorageDataAccessAgent storageAgent;

            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(Module.ServiceDirectory);

            if (!DataAccessServices.IsDataAccessServiceRegistered<IForwardDataAccessAgent>())
            {
               forwardAgent = DataAccessFactory.GetInstance(new ForwardDataAccessConfigurationView(configuration, null, Module.ServiceName)).CreateDataAccessAgent<IForwardDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IForwardDataAccessAgent>(forwardAgent);
            }
            else
               forwardAgent = DataAccessServices.GetDataAccessService<IForwardDataAccessAgent>();

            if (!DataAccessServices.IsDataAccessServiceRegistered<IAeManagementDataAccessAgent>())
            {
               storageAgent = DataAccessFactory.GetInstance(new StorageDataAccessConfigurationView(configuration, null, Module.ServiceName)).CreateDataAccessAgent<IStorageDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IStorageDataAccessAgent>(storageAgent);
            }
            else
               storageAgent = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();

            if (forwardAgent != null && storageAgent != null)
            {
               new CleanProcess(Module.Options, Module.ServerAE).Run(forwardAgent, storageAgent);
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemMessage(LogType.Error, e.Message, Module.ServerAE);
         }
      }

      /// <summary>
      /// Initiates the reset process.
      /// </summary>
      /// <param name="range">The date range to reset.</param>
      private void Reset(DateRange range)
      {
         try
         {
            IForwardDataAccessAgent forwardAgent;

            if (!DataAccessServices.IsDataAccessServiceRegistered<IForwardDataAccessAgent>())
            {
               System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(Module.ServiceDirectory);
               forwardAgent = DataAccessFactory.GetInstance(new ForwardDataAccessConfigurationView(configuration, null, Module.ServiceName)).CreateDataAccessAgent<IForwardDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IForwardDataAccessAgent>(forwardAgent);
            }
            else
               forwardAgent = DataAccessServices.GetDataAccessService<IForwardDataAccessAgent>();

            if (forwardAgent != null)
            {
               new ResetProcess(Module.ServerAE).Run(forwardAgent, range);
            }
         }
         catch (Exception e)
         {
            Logger.Global.SystemMessage(LogType.Error, e.Message, Module.ServerAE);
         }
      }
#if LEADTOOLS_V18_OR_LATER
      private void CancelForward()
      {
         new ForwardProcess(Module.Options, Module.ServerAE).Cancel();
      }

      private void CancelClean()
      {
         new CleanProcess(Module.Options, Module.ServerAE).Cancel();
      }
#endif // #if LEADTOOLS_V18_OR_LATER

      private void Cancel_ServiceShuttingDown()
      {
         new ForwardProcess(Module.Options, Module.ServerAE).ServiceShuttingDown();
      }
   }
}
