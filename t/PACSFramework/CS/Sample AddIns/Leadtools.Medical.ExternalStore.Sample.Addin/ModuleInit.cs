// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom.AddIn;
using Leadtools.Logging;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Medical.Winforms.ExternalStore;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.DataAccessLayer;

namespace Leadtools.Medical.ExternalStore.Sample.Addin
{
   public class Module : ModuleInit, IProcessBreak
   {
      // Logged messages use this name to refer to this sample addin 
      public const string Source = "ExternalStoreSample";

      // GUID that uniquely identifies this addin
      public const string SampleGuid = "0868AEE8-F7FA-435A-8F40-00386C339AE3";

      // Friendly name that is displayed in the CSStorageServerManager.exe UI
      public const string FriendlyName = "LEAD Sample External Store Addin";

      // Stores the configuration settings for this addin
      private static ExternalStoreAddinConfigAbstract _sampleExternalStoreAddinConfig = null;
      public static ExternalStoreAddinConfigAbstract SampleExternalStoreAddinConfig
      {
         get
         {
            if (_sampleExternalStoreAddinConfig == null)
            {
               _sampleExternalStoreAddinConfig = new SampleExternalStoreAddinConfig();
            }
            return _sampleExternalStoreAddinConfig;
         }
         set
         {
            _sampleExternalStoreAddinConfig = value;
         }
      }

      // Location of the configuration settings for this addin
      private static string _serviceDirectory;

      // For mutual exclusion when reading the 'ExternalStoreOptions'
      private static readonly object optionsLock = new object();

      // Get/Set the 'ExternalStoreOptions'
      // ExternalStoreOptions holds options that are common to all ExternalStore addins 
      private static ExternalStoreOptions _options;
      public static ExternalStoreOptions Options
      {
         get
         {
            lock (optionsLock)
            {
               return _options;
            }
         }
         set
         {
            lock (optionsLock)
            {
               _options = value;
               if (_options != null)
               {
                  ExternalStoreItem item = _options.GetCurrentOption();
                  if ((item != null) && (item.ExternalStoreAddinConfig != null) && (item.ExternalStoreAddinConfig.Guid == Module.SampleGuid)  )
                  {
                     _sampleExternalStoreAddinConfig = item.ExternalStoreAddinConfig;
                     CreateExternalStoreFolder();
                  }
               }
            }
         }
      }

      private static void CreateExternalStoreFolder()
      {
         try
         {
            // Call VerifyConfiguration -- for this addin, it creates the external store folder
            string errorString = string.Empty;
            bool verify = SampleExternalStoreAddinConfig.VerifyConfiguration(out errorString);
            if (verify == false)
            {
               Logger.Global.Error(Source, errorString);
            }
         }
         catch (Exception ex)
         {
            Logger.Global.Error(Source, ex.Message);
         }
      }

      // Called when the external store addin is loaded by the PACSFramework
      // Registers the ICrud interface used by this external store add-in
      // If this external store add-in is currently active, this method starts the JobManager for this addin 
      public override void Load(string serviceDirectory, string displayName)
      {
         // Open 'advanced.config' which contains all settings for CSStorageServerManger.exe addins (including this ExternalStore SampleAddin)
         AdvancedSettings settings = AdvancedSettings.Open(serviceDirectory);

         _serviceDirectory = serviceDirectory;

         try
         {  
            Type[] extraTypes = new[]{typeof(SampleConfiguration)};
            Options = settings.GetAddInCustomData<ExternalStoreOptions>(ExternalStorePresenter._Name, "ExternalStoreOptions", extraTypes);
            if (Options == null)
            {
               Options = new ExternalStoreOptions();               
            }
            ICrud thisCrud = Options.GetCrud(SampleGuid);
            if (thisCrud != null)
            {
               DataAccessServiceLocator.Register(thisCrud, thisCrud.ExternalStoreGuid); 
            }
         }
         catch (Exception e)
         {
            if (Options == null)
            {
               Options = new ExternalStoreOptions();
            }

            Logger.Global.Error(Source, e.Message);
         }

         ExternalStore.Addin.Module.StartExternalStoreJobs(SampleExternalStoreAddinConfig, "Sample");
      }

      // If the external store options changed through the CSStorageServerManager.exe UI this event is fired 
      // and the DICOM Listening service needs to be notified to reinitialize the external store settings.
      public static void ExternalStoreSettingsChanged()
      {
         AdvancedSettings settings = AdvancedSettings.Open(_serviceDirectory);

         if (settings != null)
         {
            settings.RefreshSettings();
            Type[] extraTypes = new Type[] { typeof(SampleConfiguration) };
            Options = settings.GetAddInCustomData<ExternalStoreOptions>(ExternalStorePresenter._Name, "ExternalStoreOptions", extraTypes);

            ExternalStore.Addin.Module.StartExternalStoreJobs(SampleExternalStoreAddinConfig, "Sample");
         }
      }

      #region IProcessBreak Members

      public void Break(BreakType type)
      {
      }

      #endregion
   }
}
