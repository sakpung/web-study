// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom.AddIn;
using Leadtools.Logging;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Medical.Winforms.ExternalStore;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.ExternalStore.Atmos.Addin
{
   public class Module : ModuleInit, IProcessBreak
   {
      public const string Source = "ExternalStoreAtmos";
      public const string AtmosGuid = "09F258DF-1BDF-46FC-9106-F9ECFEE15A59";
      public const string AtmosFriendlyName = "Atmos Cloud Storage";

      private static string _serviceDirectory;

      public static StorageModuleConfigurationManager StorageConfigManager;

      static ExternalStoreAddinConfigAbstract _externalStoreAddinConfig = null;
      public static ExternalStoreAddinConfigAbstract AtmosExternalStoreAddinConfig
      {
         get
         {
            if (_externalStoreAddinConfig == null)
            {
               _externalStoreAddinConfig = new AtmosExternalStoreAddinConfig();
            } 
            return _externalStoreAddinConfig; 
         }
         set 
         { 
            _externalStoreAddinConfig = value;
         }
      }

      public static string ServiceDirectory
      {
         get { return _serviceDirectory; }
         set { _serviceDirectory = value; }
      }

      public static string ServiceName
      {
         get;
         set;
      }

      private static string _ServerAE;

      public static string ServerAE
      {
         get { return _ServerAE; }
         set { _ServerAE = value; }
      }

      private static readonly object optionsLock = new object();

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
                  if ((item != null) && (item.ExternalStoreAddinConfig != null) && (item.ExternalStoreAddinConfig.Guid == Module.AtmosGuid))
                  {
                     _externalStoreAddinConfig = item.ExternalStoreAddinConfig;
                  }
               }
            }
         }
      }

      public override void Load(string serviceDirectory, string displayName)
      {
         string msg = string.Format("serviceDirectory:{0}  displayName:{1}", serviceDirectory, displayName);
         DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Module.Load()  -- JobManager.Start" +  msg);
         AdvancedSettings settings = AdvancedSettings.Open(serviceDirectory);

         _serviceDirectory = serviceDirectory;

         DicomServer server = ServiceLocator.Retrieve<DicomServer>();
         ServiceName = server.Name;

         try
         {  
            Type[] extraTypes = new Type[]{typeof(AtmosConfiguration)};
            Options = settings.GetAddInCustomData<ExternalStoreOptions>(ExternalStorePresenter._Name, "ExternalStoreOptions", extraTypes);
            ExternalStorePresenter.MyDumpExternalStoreOptions("Module.Load()  -- settings.GetAddInCustomData()", Options);
            if (Options == null)
            {
               Options = new ExternalStoreOptions();               
            }
            ICrud thisCrud = Options.GetCrud(AtmosGuid);
            if (thisCrud != null)
            {
               DataAccessServiceLocator.Register<ICrud>(thisCrud, thisCrud.ExternalStoreGuid); 
            }
         }
         catch (Exception e)
         {
            DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "*** Exception: Module.Load()   settings.GetAddInCustomData" + e.Message);
            if (Options == null)
               Options = new ExternalStoreOptions();

            Logger.Global.Error(Source, e.Message);
         }

         ExternalStore.Addin.Module.StartExternalStoreJobs(AtmosExternalStoreAddinConfig, "Atmos");
      }

      static AdvancedSettings _settings;

      public static AdvancedSettings Settings
      {
         get
         {
            if (_settings == null)
            {
               _settings = AdvancedSettings.Open(_serviceDirectory);
            }
            return _settings;
         }

         set
         {
            _settings = value;
         }
      }

       public static void ExternalStoreSettingsChanged()
      {
         DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Atmos: Module.ExternalStoreSettingsChanged()");
         Settings.RefreshSettings();
         Type[] extraTypes = new Type[] { typeof(AtmosConfiguration) };
         Options = Settings.GetAddInCustomData<ExternalStoreOptions>(ExternalStorePresenter._Name, "ExternalStoreOptions", extraTypes);

         ExternalStorePresenter.MyDumpExternalStoreOptions("Atmos ExternalStoreSettingsChanged() -- options about to be saved", Options);
         ExternalStore.Addin.Module.StartExternalStoreJobs(AtmosExternalStoreAddinConfig, "Atmos");
      }

      #region IProcessBreak Members

      public void Break(BreakType type)
      {
         // Do Nothing
      }

      #endregion
   }
}
