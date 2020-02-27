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
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.ExternalStore.Azure.Addin
{
   public class Module : ModuleInit, IProcessBreak
   {
      public const string Source = "ExternalStoreAzure";
      public const string AzureGuid = "845B878D-2786-4445-99ED-9A1514093B96";
      public const string AzureFriendlyName = "Azure Cloud Storage";

      static ExternalStoreAddinConfigAbstract _externalStoreAddinConfig = null;
      public static ExternalStoreAddinConfigAbstract AzureExternalStoreAddinConfig
      {
         get
         {
            if (_externalStoreAddinConfig == null)
            {
               _externalStoreAddinConfig = new AzureExternalStoreAddinConfig();
            } 
            return _externalStoreAddinConfig; 
         }
         set 
         { 
            _externalStoreAddinConfig = value;
         }
      }

      private static string _serviceDirectory;
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
                  if ((item != null) && (item.ExternalStoreAddinConfig != null) && (item.ExternalStoreAddinConfig.Guid == Module.AzureGuid))
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
            Type[] extraTypes = new Type[]{typeof(AzureConfiguration)};
            Options = settings.GetAddInCustomData<ExternalStoreOptions>(ExternalStorePresenter._Name, "ExternalStoreOptions", extraTypes);
            ExternalStorePresenter.MyDumpExternalStoreOptions("Module.Load()  -- settings.GetAddInCustomData()", Options);
            if (Options == null)
            {
               Options = new ExternalStoreOptions();               
            }
            ICrud thisCrud = Options.GetCrud(AzureGuid);
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

         ExternalStore.Addin.Module.StartExternalStoreJobs(AzureExternalStoreAddinConfig, "Azure");
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
         DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Azure Module.ExternalStoreSettingsChanged()");
         Settings.RefreshSettings();
         Type[] extraTypes = new Type[] { typeof(AzureConfiguration) };
         Options = Settings.GetAddInCustomData<ExternalStoreOptions>(ExternalStorePresenter._Name, "ExternalStoreOptions", extraTypes);

         ExternalStorePresenter.MyDumpExternalStoreOptions("Azure ExternalStoreSettingsChanged() -- options about to be saved", Options);
         ExternalStore.Addin.Module.StartExternalStoreJobs(AzureExternalStoreAddinConfig, "Azure");
      }

      #region IProcessBreak Members

      public void Break(BreakType type)
      {
         // Do Nothing
      }

      #endregion
   }
}
