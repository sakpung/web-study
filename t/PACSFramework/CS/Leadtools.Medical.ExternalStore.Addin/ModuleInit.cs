// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom.AddIn;
using Leadtools.Medical.Winforms.ExternalStore;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Medical.ExternalStore.DataAccessLayer.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Logging;
using Leadtools.DicomDemos;

namespace Leadtools.Medical.ExternalStore.Addin
{
   public class Module : ModuleInit, IProcessBreak
   {

      private static AdvancedSettings _settings;
      public static AdvancedSettings Settings
      {
         get { return _settings; }
      }

      private static string _serviceDirectory;
      public static string ServiceDirectory
      {
         get { return _serviceDirectory; }
      }

      private static string _displayName;
      public static string DisplayName
      {
         get { return _displayName; }
      }

      private static string _serviceName;
      public static string ServiceName
      {
         get { return _serviceName; }
      }

      private static string _serverAE;
      public static string ServerAE
      {
         get { return _serverAE; }
      }

      private static StorageModuleConfigurationManager _storageConfigManager;
      public static StorageModuleConfigurationManager StorageConfigManager
      {
         get { return _storageConfigManager; }
         set { _storageConfigManager = value; }
      }

      private static JobManager _jobManager = null;
      public static JobManager JobManager
      {
         get
         {
            return _jobManager;
         }

         set
         {
            if (_jobManager != null)
            { 
               _jobManager.Stop();
            }
            _jobManager = value;
         }
      }

     private static readonly object optionsLock = new object();

      private static ExternalStoreOptions _Options;
      public static ExternalStoreOptions Options
      {
         get
         {
            lock (optionsLock)
            {
               return _Options;
            }
         }
         set
         {
            lock (optionsLock)
            {
               _Options = value;
            }
         }
      }

      public override void Load(string serviceDirectory, string displayName)
      {
         _serviceDirectory = serviceDirectory;
         _displayName = displayName;
         DicomServer server = ServiceLocator.Retrieve<DicomServer>();
         if (server != null)
         {
            _serverAE = server.AETitle;
            _serviceName = server.Name;
         }

         _settings = AdvancedSettings.Open(serviceDirectory);

         Type[] extraTypes = null;//

         Options = Settings.GetAddInCustomData<ExternalStoreOptions>(ExternalStorePresenter._Name, "ExternalStoreOptions", extraTypes);

         StorageConfigManager = new StorageModuleConfigurationManager(true);
         StorageConfigManager.Load(ServiceDirectory);
      }

      public static void StopExternalStoreJobs()
      {
         if (JobManager != null)
         {
            string sDebug = string.Format("Module.StopExternalStoreJobs  -- JobManager.Stop");
            DicomUtilities.DebugString(DebugStringOptions.ShowCounter, sDebug);
            JobManager.Stop();
         }

         // No cloud storage
         Settings.RefreshSettings();
         Options = Settings.GetAddInCustomData<ExternalStoreOptions>(ExternalStorePresenter._Name, "ExternalStoreOptions", null);

         string s = string.Format("{0}: Module.StopExternalStoreJobs()", ExternalStorePresenter._Name);
         ExternalStorePresenter.MyDumpExternalStoreOptions(s, Options);
         if (Options.ExternalStoreIndex == -1)
         {
            DataAccessServiceLocator.Register<ICrud>(new DefaultCrud());
         }
      }

      public static void StartExternalStoreJobs(ExternalStoreAddinConfigAbstract addinExternalStoreAddinConfig, string addinFriendlyName)
      {
         ExternalStoreItem item = null;
         if (Options != null)
         {
            item = Options.GetCurrentOption();
         }
         if ((item != null) && (addinExternalStoreAddinConfig != null) && (item.ExternalStoreAddinConfig.Equals(addinExternalStoreAddinConfig)))
         {
            ICrud crud = item.ExternalStoreAddinConfig.GetCrudInterface();
            crud.Initialize();
            DataAccessServiceLocator.Register<ICrud>(crud);
            DataAccessServiceLocator.Register<ICrud>(crud, crud.ExternalStoreGuid); 

            StorageConfigManager = new StorageModuleConfigurationManager(true);
            StorageConfigManager.Load(ServiceDirectory);
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(_serviceDirectory);
            IExternalStoreDataAccessAgent externalStoreAgent;
            if (!DataAccessServices.IsDataAccessServiceRegistered<IExternalStoreDataAccessAgent>())
            {
               externalStoreAgent = DataAccessFactory.GetInstance(new ExternalStoreDataAccessConfigurationView(configuration, null, _displayName)).CreateDataAccessAgent<IExternalStoreDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IExternalStoreDataAccessAgent>(externalStoreAgent);
            }
            else
            {
               externalStoreAgent = DataAccessServices.GetDataAccessService<IExternalStoreDataAccessAgent>();
            }

            IStorageDataAccessAgent storageAgent;
            if (!DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent>())
            {
               storageAgent = DataAccessFactory.GetInstance(new StorageDataAccessConfigurationView(configuration, null, _displayName)).CreateDataAccessAgent<IStorageDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IStorageDataAccessAgent>(storageAgent);
            }
            else
            {
               storageAgent = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();
            }

            string sDebug = string.Format("{0}: Module.StartOrStopAddin()  -- new JobManager()", addinFriendlyName);
            ExternalStorePresenter.MyDumpExternalStoreOptions(sDebug, Options);
            JobManager = new JobManager(Options, externalStoreAgent, storageAgent, ServiceName, StorageConfigManager.GetStorageAddInsSettings());

            JobManager.ExternalStoreGuid = item.ExternalStoreAddinConfig.Guid;

            if (IsLicenseValid())
            {
               sDebug = string.Format("{0}: Module.StartOrStopAddin()  -- JobManager.Start", addinFriendlyName);
               DicomUtilities.DebugString(DebugStringOptions.ShowCounter, sDebug);
               JobManager.Start();
            }
         }
      }

      /// <summary>
      /// Determines whether the server has a valid license for external store.
      /// </summary>
      /// <returns>
      ///   <c>true</c> if the license is valid; otherwise, <c>false</c>.
      /// </returns>
      private static bool IsLicenseValid()
      {
         if (ServiceLocator.IsRegistered<ILicense>())
         {
            DicomServer server = ServiceLocator.Retrieve<DicomServer>();

            _License = ServiceLocator.Retrieve<ILicense>();
            _License.LicenseChanged += new EventHandler(OnLicenseChanged);

            string message;
            if (!License.IsFeatureValid(ServerFeatures.ExternalStore))
            {
               message = string.Format("No valid license for External Store found.  External Store will not be available.");
               Logger.Global.SystemMessage(LogType.Error, message, ServiceName);
               return false;
            }

            if (_License.IsFeatureEvaluation(ServerFeatures.ExternalStore) && _License.IsFeatureExpired(ServerFeatures.ExternalStore))
            {
               message = string.Format("Evaluation period for External Store has expired.  External Store will not be available.");
               Logger.Global.SystemMessage(LogType.Error, message, ServiceName);
               return false;
            }
         }
         return true;
      }

      static void OnLicenseChanged(object sender, EventArgs e)
      {
         if (JobManager != null)
         {
            JobManager.Stop();
            if (IsLicenseValid())
            {
               JobManager.Start();
            }
         }
      }

      private static ILicense _License;
      public static ILicense License
      {
         get { return _License; }
         set { _License = value; }
      }

      #region IProcessBreak Members

      void IProcessBreak.Break(BreakType type)
      {
         if (JobManager != null)
         {
            JobManager.Stop();
         }
      }

      #endregion
   }
}
