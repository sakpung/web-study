// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Logging;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Medical.Winforms.SecurityOptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadtools.Medical.Security.AddIn
{
   public class ServerConfig : ModuleInit, IProcessBreak
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

      internal static DicomSecurityOptions _dicomSecurityOptions = null;

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

         InitializeDicomSecurity();

         if (!ServiceLocator.IsRegistered<SettingsChangedNotifier>())
         {
            SettingsChangedNotifier configChangedNotifier = new SettingsChangedNotifier(Settings);

            configChangedNotifier.SettingsChanged += new EventHandler(configChangedNotifier_SettingsChanged);
            configChangedNotifier.Enabled = true;
            ServiceLocator.Register<SettingsChangedNotifier>(configChangedNotifier);
         }
         else
         {
            ServiceLocator.Retrieve<SettingsChangedNotifier>().SettingsChanged += new EventHandler(configChangedNotifier_SettingsChanged);
         }
      }

      void InitializeDicomSecurity()
      {
         Type[] extraTypes = null;
         _dicomSecurityOptions = Settings.GetAddInCustomData<DicomSecurityOptions>(SecurityOptionsPresenter.AddinName, SecurityOptionsPresenter.CustomDataName, extraTypes);
         if (_dicomSecurityOptions == null)
         {
            _dicomSecurityOptions = new DicomSecurityOptions();
            Settings.SetAddInCustomData<DicomSecurityOptions>(SecurityOptionsPresenter.AddinName, SecurityOptionsPresenter.CustomDataName, _dicomSecurityOptions);
            Settings.Save();
         }
      }

      void configChangedNotifier_SettingsChanged(object sender, EventArgs e)
      {
         // Reinitialize the dicom security settings
         InitializeDicomSecurity();
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
               message = string.Format("No valid license for DICOM Security found.  DICOM Security option will not be available.");
               Logger.Global.SystemMessage(LogType.Error, message, ServiceName);
               return false;
            }

            if (_License.IsFeatureEvaluation(ServerFeatures.ExternalStore) && _License.IsFeatureExpired(ServerFeatures.ExternalStore))
            {
               message = string.Format("Evaluation period for DICOM Security has expired.  DICOM Security Option will not be available.");
               Logger.Global.SystemMessage(LogType.Error, message, ServiceName);
               return false;
            }
         }
         return true;
      }

      static void OnLicenseChanged(object sender, EventArgs e)
      {
      }

      public void Break(BreakType type)
      {
      }

      private static ILicense _License;
      public static ILicense License
      {
         get { return _License; }
         set { _License = value; }
      }
   }
}
