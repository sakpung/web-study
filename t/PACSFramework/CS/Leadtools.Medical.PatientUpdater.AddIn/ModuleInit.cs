// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using Leadtools.Logging;
using Leadtools.Dicom.AddIn.Configuration;
using System.Reflection;
using Leadtools.Dicom.Scp.Command.NAction.PatientUpdater;
using Leadtools.Medical.PatientUpdater.AddIn.Queue;
using Leadtools.Medical.PatientUpdater.AddIn.Retry;
using System.IO;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.DicomDemos;
using Leadtools.Dicom.AddIn.Interfaces;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)

namespace Leadtools.Medical.PatientUpdater.AddIn
{
   public class Module : ModuleInit, IProcessBreak
   {
      public const string Source = "Patient Updater";
      private static PatientUpdaterOptions _Options;
      private string _AddIn = "PatientUpdater";
      private string _Name = "PatientUpdaterOptions";

      private static object optionsLock = new object();

      public static PatientUpdaterOptions Options
      {
         get 
         {
            lock (optionsLock)
            {
               return Module._Options;
            }
         }
         set 
         {
            lock (optionsLock)
            {
               Module._Options = value;
            }
         }
      }
      public static AutoUpdateQueue UpdateQueue = null;
      public static AutoRetryProcessor RetryProcessor = null;
      public static StorageModuleConfigurationManager StorageConfigManager;
      public static IStorageDataAccessAgent StorageAgent;

      public static string ServiceDirectory
      {
         get;
         set;
      }

      public static string ServiceName
      {
         get;
         set;
      }

      public static string ServerAE
      {
         get;
         set;
      }

      public override void Load(string serviceDirectory, string displayName)
      {
         System.Configuration.Configuration configuration;
         DicomServer server = ServiceLocator.Retrieve<DicomServer>();

         ServiceDirectory = serviceDirectory;         
         ServiceName = server.Name;
         ServerAE = server.AETitle;

         server.ServerSettingsChanged += new EventHandler(server_ServerSettingsChanged);
         StorageConfigManager = new StorageModuleConfigurationManager(true);
         StorageConfigManager.Load(serviceDirectory);

         configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(serviceDirectory);
         if (!DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent>())
         {
            StorageAgent = DataAccessFactory.GetInstance(new StorageDataAccessConfigurationView(configuration, null, displayName)).CreateDataAccessAgent<IStorageDataAccessAgent>();
            DataAccessServices.RegisterDataAccessService<IStorageDataAccessAgent>(StorageAgent);
         }
         else
            StorageAgent = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();

         try
         {
            AdvancedSettings settings = AdvancedSettings.Open(ServiceDirectory);
            string name = Assembly.GetExecutingAssembly().GetName().Name;

            RegisterServerEvents(settings);
            Options = settings.GetAddInCustomData<PatientUpdaterOptions>(_AddIn, _Name);
            if (Options == null)
            {
               Options = new PatientUpdaterOptions();               
            }

            if (Options.EnableAutoUpdate)
            {
               UpdateQueue = new AutoUpdateQueue(Options.AutoUpdateThreads);
               UpdateQueue.InitializeDatabase();
            }
         }
         catch (Exception e)
         {
            if (Options == null)
               Options = new PatientUpdaterOptions();

            Logger.Global.Error(Source, e.Message);
         }

         if (Options.EnableRetry)
         {
            if (string.IsNullOrEmpty(Module.Options.RetryDirectory))
               Module.Options.RetryDirectory = Path.Combine(ServiceDirectory, @"AutoUpdate\");

            RetryProcessor = new AutoRetryProcessor(Options.RetryDirectory);
            RetryProcessor.Start(Options.RetrySeconds, Options.RetryDays);
         }
      }

      void server_ServerSettingsChanged(object sender, EventArgs e)
      {
         DicomServer server = ServiceLocator.Retrieve<DicomServer>();

         ServerAE = server.AETitle;
      }

      private void RegisterServerEvents(AdvancedSettings settings)
      {         
         if (settings != null)
         {
            if (!ServiceLocator.IsRegistered<SettingsChangedNotifier>())
            {
               SettingsChangedNotifier configChangedNotifier = new SettingsChangedNotifier(settings);

               configChangedNotifier.SettingsChanged += new EventHandler(server_AdvancedSettingsChanged);
               configChangedNotifier.Enabled = true;
               ServiceLocator.Register<SettingsChangedNotifier>(configChangedNotifier);
            }
            else
               ServiceLocator.Retrieve<SettingsChangedNotifier>().SettingsChanged += new EventHandler(server_AdvancedSettingsChanged);
         }
      }

      void server_AdvancedSettingsChanged(object sender, EventArgs e)
      {
         AdvancedSettings settings = AdvancedSettings.Open(ServiceDirectory);

         if (settings != null)
         {
            settings.RefreshSettings();
            Options = settings.GetAddInCustomData<PatientUpdaterOptions>(_AddIn, _Name);
            if (Options != null)
            {
               //
               // Change auto update settings
               //
               if (Options.EnableAutoUpdate)
               {
                  if (UpdateQueue != null)
                     return;

                  UpdateQueue = new AutoUpdateQueue(Options.AutoUpdateThreads);
                  UpdateQueue.InitializeDatabase();
               }
               else
               {
                  if (UpdateQueue != null)
                  {
                     UpdateQueue.Dispose();
                     UpdateQueue = null;
                  }
               }

               //
               // Change retry settings
               //
               if (Options.EnableRetry)
               {
                  if (RetryProcessor != null)
                     return;

                  RetryProcessor = new AutoRetryProcessor(Options.RetryDirectory);
                  RetryProcessor.Start(Options.RetrySeconds, Options.RetryDays);
               }
               else
               {
                  if (RetryProcessor != null)
                  {
                     RetryProcessor.Stop();
                     RetryProcessor = null;
                  }
               }
            }
         }
      }

      #region IProcessBreak Members

      public void Break(BreakType type)
      {
         if (UpdateQueue != null)
         {
            UpdateQueue.Dispose();
            UpdateQueue = null;
         }

         if (RetryProcessor != null)
         {
            RetryProcessor.Stop();
            RetryProcessor = null;
         }
      }

      #endregion
   }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
   public class PatientUpdaterServerMessage : IProcessServiceMessage
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

            IStorageDataAccessAgent storageAgent = GetAgent<IStorageDataAccessAgent>(configuration, new StorageDataAccessConfigurationView(configuration, null, Module.ServiceName));
            IAeManagementDataAccessAgent aeManagementAgent = GetAgent<IAeManagementDataAccessAgent>(configuration, new AeManagementDataAccessConfigurationView(configuration, null, Module.ServiceName));
            IOptionsDataAccessAgent optionsAgent = GetAgent<IOptionsDataAccessAgent>(configuration, new OptionsDataAccessConfigurationView(configuration, null, Module.ServiceName));


            bool bContinue = true;
            if (aeManagementAgent == null)
            {
               error = string.Format("{0} {1}", AssemblyName, "Cannot create IAeManagementDataAccessAgent");
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
               if (optionsAgent == null)
               {
                  error = string.Format("{0} {1}", AssemblyName, "Cannot create IOptionsDataAccessAgent");
                  bContinue = false;
               }
            }

            if (bContinue)
            {
               storageAgent.MaxQueryResults = 10;
               storageAgent.IsPatientsExists("patientIdNotUsed");

               aeManagementAgent.GetAeTitle("notUsed");

               optionsAgent.GetDefaultOptions();
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
