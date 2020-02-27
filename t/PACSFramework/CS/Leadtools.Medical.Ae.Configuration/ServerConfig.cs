// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn;
using Leadtools.Medical.DataAccessLayer;
using System.Diagnostics;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Logging;
using Leadtools.Medical.Winforms;
using Leadtools.DicomDemos;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.DataAccessLayer.Configuration;
#endif

namespace Leadtools.Medical.Ae.Configuration
{
   public class ServerConfig : IServerConfig
   {
      #region IServerConfig Members

      public void Configure(DicomServer server)
      {
         ServiceDirectory = server.ServerDirectory;
         DisplayName = server.Name;

         try
         {
            AeManagementDataAccessConfigurationView configView = new AeManagementDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(server.ServerDirectory), null, server.Name);
            IAeManagementDataAccessAgent aeAgent = DataAccessFactory.GetInstance(configView).CreateDataAccessAgent<IAeManagementDataAccessAgent>();

            ServiceLocator.Register<IAETitle>(new AeTitle(aeAgent));
         }
         catch (Exception e)
         {
            Logger.Global.Exception("AE Configuration", e);
         }
      }

      public static string ServiceDirectory
      {
         get;
         set;
      }

      public static string DisplayName
      {
         get;
         set;
      }

      #endregion
   }


   #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
   public class AeConfigurationServerMessage : IProcessServiceMessage
   {
      #region IProcessServiceMessage Members

      public bool CanProcess(string MessageId)
      {
         return (
                 MessageId == MessageNames.IsAddinHealthy
                 );
      }

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

      public static T GetAgent<T>(System.Configuration.Configuration configuration, DataAccessConfigurationView view)
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
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(ServerConfig.ServiceDirectory);
            IAeManagementDataAccessAgent aeManagementAgent = GetAgent<IAeManagementDataAccessAgent>(configuration, new AeManagementDataAccessConfigurationView(configuration, null, ServerConfig.DisplayName));

            bool bContinue = true;
            if (aeManagementAgent == null)
            {
               error = string.Format("{0} {1}", AssemblyName, "Cannot create IAeManagementDataAccessAgent");
               bContinue = false;
            }

            if (bContinue)
            {
               aeManagementAgent.GetAeTitle("notUsed");
            }
         }
         catch (Exception e)
         {
            error = string.Format("{0} {1}", AssemblyName, e.Message);
         }

         ret = string.IsNullOrEmpty(error);
         return ret;
      }

      public ServiceMessage Process(ServiceMessage Message)
      {
         ServiceMessage serviceMessage = null;
         switch (Message.Message)
         {
            case MessageNames.IsAddinHealthy:
               serviceMessage = new ServiceMessage();
               string error;
               serviceMessage.Message = Message.Message;
               serviceMessage.Success = CanAccessDatabase(out error);
               serviceMessage.Error = error;
               break;
         }
         return serviceMessage;
      }
      #endregion
   }

#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
}
