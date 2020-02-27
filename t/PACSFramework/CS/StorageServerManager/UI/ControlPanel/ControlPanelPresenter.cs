// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Demos.StorageServer.Properties;
using Leadtools.Medical.Winforms;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;
using Leadtools.Dicom.AddIn.Interfaces;

namespace Leadtools.Demos.StorageServer.UI
{
   class ControlPanelPresenter
   {
      PanelItem forwarding = new PanelItem();
      PanelItem gateway = new PanelItem();

      PanelItem serverSettingsItem = new PanelItem();
      PanelItem storeSettings = new PanelItem();
      PanelItem administration = new PanelItem();
      PanelItem patientUpdater = new PanelItem();
      PanelItem autoCopy = new PanelItem();
      PanelItem LoggingConfig = new PanelItem(); 

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
      PanelItem externalStore = new PanelItem(); 
#endif    
      PanelItem securityOptions = new PanelItem();


      public void RunView ( ControlPanelView view ) 
      {
         __View = view ;
         
         ConfigureView ( ) ;

         ServerState.Instance.ServerServiceChanged += new EventHandler(Instance_ServerServiceChanged);
         ServerState.Instance.LicenseChanged += new EventHandler(Instance_LicenseChanged);
         __View.ItemClicked += new EventHandler<DisplayFeatureEventArgs>(__View_ItemClicked);
         
      }

      void Instance_LicenseChanged(object sender, EventArgs e)
      {
         //__View.EnableItem(HasFeature(ServerFeatures.Forwarding),forwarding);
         //__View.EnableItem(HasFeature(ServerFeatures.Gateway),gateway);
         
         //bool isExpired = IsLicenseExpired();
         //__View.EnableItem(isExpired, serverSettingsItem);
         //__View.EnableItem(isExpired, storeSettings);
         //__View.EnableItem(isExpired, administration);
         //__View.EnableItem(isExpired, patientUpdater);
         //__View.EnableItem(isExpired, autoCopy);
         //__View.EnableItem(isExpired, LoggingConfig);
         
         UpdateUI();
         
      }

      private bool IsLicenseValid()
      {
         ILicense license = ServerState.Instance.License;
         if (license == null || license.Features.Count == 0)
            return false;

         if (license.IsFeatureExpired(ServerFeatures.GeneralFunctionality))
            return false;

         return true;
      }

      private bool HasFeature(string featureId)
      {
         ILicense license = ServerState.Instance.License;

         if (!IsLicenseValid())
            return false;

         if (!license.IsFeatureValid(featureId))
            return false;
            
         IFeature feature = license.GetFeature(featureId);
         if (feature != null)
         {
            if (feature.Type == LicenseFeatureType.Off)
            return false;
         }

         if (license.IsFeatureEvaluation(featureId) && license.IsFeatureExpired(featureId))
            return false;

         return true;
      }

      private void UpdateUI()
      {
         bool exists = ServerState.Instance.ServerService != null;
         bool isAdmin = UserManager.User.IsAdmin();
         ILicense license = ServerState.Instance.License;
         bool isLicenseValid = IsLicenseValid();

         bool canChangeServerSettings = UserManager.User.IsAuthorized(UserPermissions.CanChangeServerSettings);

         serverSettingsItem.Enabled    =                   (isAdmin || canChangeServerSettings);    // always show this one
         storeSettings.Enabled         = isLicenseValid && (exists && (isAdmin || canChangeServerSettings));
         administration.Enabled        = isLicenseValid && (isAdmin);
         patientUpdater.Enabled        = isLicenseValid && (exists && (isAdmin || canChangeServerSettings));
         autoCopy.Enabled              = isLicenseValid && (exists && (isAdmin || canChangeServerSettings));
         LoggingConfig.Enabled         = isLicenseValid && (exists && (isAdmin || canChangeServerSettings));
         forwarding.Enabled            = isLicenseValid && (exists && (isAdmin || canChangeServerSettings) && HasFeature(ServerFeatures.Forwarding));
         gateway.Enabled               = isLicenseValid && (exists && (isAdmin || canChangeServerSettings) && HasFeature(ServerFeatures.Gateway));
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         externalStore.Enabled         = isLicenseValid && (exists && (isAdmin || canChangeServerSettings) && HasFeature(ServerFeatures.ExternalStore));
#endif 
         securityOptions.Enabled       = isLicenseValid && (exists && (isAdmin || canChangeServerSettings));

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
         // If the addins are not healthy (i.e. cannot access database), then disable the corresponding feature
         patientUpdater.Enabled = patientUpdater.Enabled && Shell.ServerAddins.PatientUpdaterValid;
         autoCopy.Enabled = autoCopy.Enabled && Shell.ServerAddins.AutoCopyValid;
         forwarding.Enabled = forwarding.Enabled && Shell.ServerAddins.ForwarderValid;
         gateway.Enabled = gateway.Enabled && Shell.ServerAddins.GatewayValid;
         externalStore.Enabled = externalStore.Enabled && Shell.ServerAddins.ExternalStoreValid;

         // View.AddFeatureControl(FeatureNames.AutoCopy, autoCopyView, null ) ;
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)

         securityOptions.Enabled = securityOptions.Enabled && Shell.ServerAddins.SecurityValid;


         __View.EnableItem(serverSettingsItem.Enabled,   serverSettingsItem);
         __View.EnableItem(storeSettings.Enabled,        storeSettings);
         __View.EnableItem(administration.Enabled,       administration);
         __View.EnableItem(serverSettingsItem.Enabled,   serverSettingsItem);
         __View.EnableItem(patientUpdater.Enabled,       patientUpdater);
         __View.EnableItem(autoCopy.Enabled,             autoCopy);
         __View.EnableItem(LoggingConfig.Enabled,        LoggingConfig);
         __View.EnableItem(forwarding.Enabled,           forwarding);
         __View.EnableItem(gateway.Enabled,              gateway);

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         __View.EnableItem(externalStore.Enabled,        externalStore);
#endif

         __View.EnableItem(securityOptions.Enabled, securityOptions);
      }

      private void ConfigureView ( )
      {
         bool exists  = ServerState.Instance.ServerService != null ;
         bool isAdmin = UserManager.User.IsAdmin ( ) ;
         ILicense license = ServerState.Instance.License;
         
         bool canChangeServerSettings = UserManager.User.IsAuthorized ( UserPermissions.CanChangeServerSettings ) ;
                  
         serverSettingsItem.Feature = FeatureNames.ServerParentFeature ;
         serverSettingsItem.Text    = FeatureNames.ServerParentFeature.DisplayName ;
         serverSettingsItem.Image   = Resources.server ;
         serverSettingsItem.ToolTip = ItemsToolTips.DICOMServer ;
         
         storeSettings.Feature = FeatureNames.StoreSettingsParentFeature ;
         storeSettings.Text    = FeatureNames.StoreSettingsParentFeature.DisplayName ;
         storeSettings.Image   = ( exists ) ? Resources.storage_setting : Resources.Warning_32 ;
         storeSettings.ToolTip = ItemsToolTips.StorageSettings ;
         
         administration.Feature = FeatureNames.AdministrationParentFeature ;
         administration.Text    = FeatureNames.AdministrationParentFeature.DisplayName ;
         administration.Image   = Resources.administration ;
         administration.ToolTip = ItemsToolTips.Administration ;
         
         patientUpdater.Feature = FeatureNames.PatientUpdater ;
         patientUpdater.Text    = FeatureNames.PatientUpdater.DisplayName ;
         patientUpdater.Image   = ( exists ) ? Resources.patient_updater : Resources.Warning_32 ;
         patientUpdater.ToolTip = ItemsToolTips.PatientUpdater ;
         
         autoCopy.Feature = FeatureNames.AutoCopy ;
         autoCopy.Text    = FeatureNames.AutoCopy.DisplayName ;
         autoCopy.Image   = Resources.autocopy ;
         autoCopy.ToolTip = ItemsToolTips.AutoCopy ;
         
         LoggingConfig.Feature = FeatureNames.LoggingConfig ;
         LoggingConfig.Text    = FeatureNames.LoggingConfig.DisplayName ;
         LoggingConfig.Image   = Resources.login_config ;
         LoggingConfig.ToolTip = ItemsToolTips.LoggingConfig ; ;

         forwarding.Feature = FeatureNames.Forwarder ;
         forwarding.Text    = FeatureNames.Forwarder.DisplayName;
         forwarding.Image   = Resources.patient_forwarding ;
         forwarding.ToolTip = ItemsToolTips.Forwarding ;
         
         gateway.Feature = FeatureNames.Gateway ;
         gateway.Text    = FeatureNames.Gateway.DisplayName ;
         gateway.Image   = Resources.gateway ;
         gateway.ToolTip = ItemsToolTips.Gateway ; 

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         externalStore.Feature = FeatureNames.ExternalStore ;
         externalStore.Text    = FeatureNames.ExternalStore.DisplayName ;
         externalStore.Image   = Resources.externalStore ;
         externalStore.ToolTip = ItemsToolTips.ExternalStore ; 

         Shell.ServerAddins.Changed += new EventHandler(ServerAddins_Changed);
#endif
         securityOptions.Feature = FeatureNames.SecurityOptions;
         securityOptions.Text    = FeatureNames.SecurityOptions.Name;
         securityOptions.Image   = Resources.Lock_Icon_32;
         securityOptions.ToolTip = ItemsToolTips.SecurityOptions;

         UpdateUI();
         
         __View.SetItem ( serverSettingsItem ) ;
         __View.SetItem ( storeSettings ) ;
         __View.SetItem ( administration ) ;
         __View.SetItem ( patientUpdater ) ;
         __View.SetItem ( autoCopy ) ;
         __View.SetItem ( LoggingConfig ) ;
         __View.SetItem ( forwarding ) ;
         __View.SetItem ( gateway ) ;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         __View.SetItem ( externalStore ) ;
#endif

         __View.SetItem(securityOptions);
         
         __View.Notes = Shell.storageServerNotes;
      }

      void ServerAddins_Changed(object sender, EventArgs e)
      {
         UpdateUI();
      }
      
      void Instance_ServerServiceChanged ( object sender, EventArgs e )
      {
         __View.ClearItems ( ) ;
         
         ConfigureView ( ) ;
      }
      
      void __View_ItemClicked(object sender, DisplayFeatureEventArgs e)
      {
         EventBroker.Instance.PublishEvent <DisplayFeatureEventArgs> ( this, e ) ;
      }
      
      private ControlPanelView __View { get ; set ; }
      
      
   }
}
