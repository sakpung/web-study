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
using System.Diagnostics;
using Leadtools.Medical.Winforms;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.Rules.AddIn;
using System.IO;
using Leadtools.Medical.Rules.AddIn.Scripting;
using Leadtools.Medical.Winforms.Forwarder.Scheduling;
using Leadtools.Dicom.Server.Admin;

namespace Leadtools.Medical.Rules.AddIn
{
   public partial class Module : ModuleInit, IProcessBreak
   {      
      private static ScriptProcessor _ScriptProcessor = null;

      public static ScriptProcessor ScriptProcessor
      {
         get { return _ScriptProcessor; }
         set { _ScriptProcessor = value; }
      }

      private static DicomService _Service;

      public static DicomService Service
      {
         get
         {
            return _Service;
         }         
      }

      public const string Source = "Rules";

      [CLSCompliant(false)]
      public static RuleProcessorOptions _Options;

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

      public static string ServiceName
      {
         get;
         set;
      }

      private static Scheduler _Scheduler = new Scheduler();

      [CLSCompliant(false)]
      public static Scheduler Scheduler
      {
         get
         {
            return _Scheduler;
         }
      }

      private static string _FailureDirectory;

      public static string FailureDirectory
      {
         get
         {
            return _FailureDirectory;
         }
      }      

      public override void Load(string serviceDirectory, string displayName)
      {
         bool isLicensed = false;
         ILicense license = null;

         if(ServiceLocator.IsRegistered<ILicense>())
            license = ServiceLocator.Retrieve<ILicense>();
        
         InitializeLicense();
         isLicensed = IsLicenseValid();
         try
         {
            AdvancedSettings settings = AdvancedSettings.Open(serviceDirectory);

            ServiceDirectory = serviceDirectory;
            DisplayName = displayName;
            DicomServer server = ServiceLocator.Retrieve<DicomServer>();
            ServiceName = server.Name;

            GetService(serviceDirectory, displayName);
            if (!ServiceLocator.IsRegistered<SettingsChangedNotifier>())
            {
               SettingsChangedNotifier configChangedNotifier = new SettingsChangedNotifier(settings);

               configChangedNotifier.SettingsChanged += new EventHandler(configChangedNotifier_SettingsChanged);
               configChangedNotifier.Enabled = true;
               ServiceLocator.Register<SettingsChangedNotifier>(configChangedNotifier);
            }
            else
               ServiceLocator.Retrieve<SettingsChangedNotifier>().SettingsChanged += new EventHandler(configChangedNotifier_SettingsChanged);
           
            if(isLicensed) 
               ConfigureRuleProcessor(settings);
         }
         catch (Exception e)
         {            
            if (_Options == null)
               _Options = new RuleProcessorOptions();

            Logger.Global.Error(Source, e.Message);
         }

         ConfigureScriptProcessor(serviceDirectory, isLicensed);
         if(license!=null)
            license.LicenseChanged += new EventHandler(license_LicenseChanged);
      }

      void license_LicenseChanged(object sender, EventArgs e)
      {
         try
         {
            if (ScriptProcessor != null)
            {
               if (IsLicenseValid())
                  ScriptProcessor.LoadScripts();
               else
               {
                  Scheduler.CancelAll();
               }
            }
         }
         catch (Exception ex)
         {
            Logger.Global.Error(Source, ex.Message);
         }
      }

      public static void ConfigureScriptProcessor(string serviceDirectory, bool isLicensed)
      {
         try
         {
            if (isLicensed)
            {
               if (ScriptProcessor == null)
               {
                  AdvancedSettings settings = AdvancedSettings.Open(serviceDirectory);

                  ConfigureRuleProcessor(settings);
               }
               _Options.RuleDirectory = Path.Combine(serviceDirectory, @"AddIns\Rules\");
               InitializeFailureDirectory(serviceDirectory);
               ScriptProcessor = new ScriptProcessor(_Options.RuleDirectory, serviceDirectory);
               ScriptProcessor.LoadScripts();
            }
         }
         catch (Exception e)
         {
            Logger.Global.Error(Source, e.Message);
         }
      }

      public static void InitializeFailureDirectory(string serviceDirectory)
      {
         _FailureDirectory = Path.Combine(serviceDirectory, @"AddIns\rules\Failures\");

         if (!Directory.Exists(_FailureDirectory))
         {
            Directory.CreateDirectory(_FailureDirectory);
         }
      }

      private void GetService(string serviceDirectory, string displayName)
      {
         string dir = serviceDirectory.Replace(displayName, string.Empty);
         ServiceAdministrator _Administrator = new ServiceAdministrator(dir);

         _Administrator.Initialize(new List<string>() { displayName });
         if (_Administrator.Services.ContainsKey(displayName))
         {
            _Service = _Administrator.Services[displayName];
         }
      }

      public static void ConfigureRuleProcessor(AdvancedSettings settings)
      {
         string name = Assembly.GetExecutingAssembly().GetName().Name;

         settings.RefreshSettings();
         _Options = settings.GetAddInCustomData<RuleProcessorOptions>(name, Source);
         if (_Options == null)
         {
            _Options = new RuleProcessorOptions();
            _Options.RuleDirectory = Path.Combine(ServiceDirectory, @"AddIns\Rules");
         }

         if (!Directory.Exists(_Options.RuleDirectory))
         {
            Directory.CreateDirectory(_Options.RuleDirectory);
         }
      }

      void configChangedNotifier_SettingsChanged(object sender, EventArgs e)
      {
         try
         {
            AdvancedSettings settings = AdvancedSettings.Open(ServiceDirectory);

            ConfigureRuleProcessor(settings);
         }
         catch (Exception ex)
         {
            Logger.Global.Exception(Source, ex);
         }
      }     

      #region IProcessBreak Members

      public void Break(BreakType type)
      {
         if (type == BreakType.Shutdown)
         {
            //
            // Cancel all pending jobs
            //
            Scheduler.CancelAll();
         }
      }

      #endregion
   }
}
