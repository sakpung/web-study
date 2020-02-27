// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Logging;

namespace Leadtools.Medical.SearchOtherPatientId.Addin.Common
{
   public class Module : ModuleInit, IProcessBreak
   {
      private static readonly object optionsLock = new object();
      private static FindOtherPatientIdsOptions _Options;
      private static DicomServer _Server;
      public const string Source = "SearchOtherPatientId";
      public const string OptionsName = "EnableFindOtherPatientId";


      // Called when the external store addin is loaded by the PACSFramework
      public override void Load(string serviceDirectory, string displayName)
      {
         try
         {
            // Open 'advanced.config' which contains all settings for CSStorageServerManger.exe addins (including this addin)
            AdvancedSettings settings = AdvancedSettings.Open(serviceDirectory);

            ServiceDirectory = serviceDirectory;
            DisplayName = displayName;

            if (ServiceLocator.IsRegistered<DicomServer>())
            {
               _Server = ServiceLocator.Retrieve<DicomServer>();
               ServiceName = _Server.Name;
            }
            else
            {
               _Server = new DicomServer(string.Empty);
            }

            if (!ServiceLocator.IsRegistered<SettingsChangedNotifier>())
            {
               SettingsChangedNotifier configChangedNotifier = new SettingsChangedNotifier(settings);

               configChangedNotifier.SettingsChanged += new EventHandler(configChangedNotifier_SettingsChanged);
               configChangedNotifier.Enabled = true;
               ServiceLocator.Register<SettingsChangedNotifier>(configChangedNotifier);
            }
            else
               ServiceLocator.Retrieve<SettingsChangedNotifier>().SettingsChanged += new EventHandler(configChangedNotifier_SettingsChanged);

            ConfigureUSAF(settings);
         }
         catch (Exception e)
         {
            if (_Options == null)
               _Options = new FindOtherPatientIdsOptions();

            Logger.Global.SystemMessage(LogType.Error, e.Message);
         }
      }

      private static void ConfigureUSAF(AdvancedSettings settings)
      {
         //string name = Assembly.GetExecutingAssembly().GetName().Name;

         _Options = GetFindOtherPatientIdOptions(settings);
      }

      private static void configChangedNotifier_SettingsChanged(object sender, EventArgs e)
      {
         AdvancedSettings settings = AdvancedSettings.Open(ServiceDirectory);

         ConfigureUSAF(settings);
      }

      public static FindOtherPatientIdsOptions GetFindOtherPatientIdOptions(AdvancedSettings settings)
      {
         FindOtherPatientIdsOptions options = null;

         try
         {
            settings.RefreshSettings();
            options = settings.GetAddInCustomData<FindOtherPatientIdsOptions>(Source, OptionsName);
            if (options == null)
            {
               options = new FindOtherPatientIdsOptions();
            }
         }
         catch (Exception e)
         {
            if (options == null)
               options = new FindOtherPatientIdsOptions();

            Logger.Global.SystemMessage(LogType.Error, e.Message);
         }

         return options;
      }


      public static FindOtherPatientIdsOptions Options
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
               _Options = value;
            }
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

      public static string ServiceName
      {
         get;
         set;
      }

      public static DicomServer Server
      {
         get
         {
            return _Server;
         }
      }

      #region IProcessBreak Members

      public void Break(BreakType type)
      {
         // do nothing
      }

      #endregion
   }
}
