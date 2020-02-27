// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Demos.StorageServer.DataTypes;
using System.Windows.Forms;
using Leadtools.Medical.Winforms;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Medical.Winforms.Forwarder;
using Leadtools.Dicom.AddIn.Configuration;
using System.ServiceProcess;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;
using Leadtools.Logging;
using Leadtools.Medical.Logging.Addins;
using Leadtools.Medical.Winforms.DatabaseManager;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.Winforms.ExternalStore;
using Leadtools.Dicom.Common.Extensions;
#endif 

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.Winforms.Anonymize;
using Leadtools.Medical.Storage.AddIns.Controls.StorageCommit;
using Leadtools.Medical.Winforms.ClientManager;
using Leadtools.Medical.Winforms.SecurityOptions;
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

namespace Leadtools.Demos.StorageServer.UI
{
   public class ServerSettingsPresenter
   {
      public void RunView ( ServerSettingsDialog view ) 
      {
         View = view ;

         EventBroker.Instance.Subscribe <DisplayFeatureEventArgs> ( OnDisplayFeature ) ;

         ServerState.Instance.ServerServiceChanged += new EventHandler ( Instance_ServerServiceChanged ) ;
         ServerState.Instance.LoggingStateChanged  += new EventHandler ( Instance_LoggingStateChanged ) ;

         CreateViews ( ) ;
         
         View.CanApply = false;
         View.CanCancel = true;

         View.ConfirmChanges += new EventHandler ( View_ConfirmChanges ) ;
         View.CancelChanges  += new EventHandler ( View_CancelChanges ) ;
         View.ApplyChanges   += new EventHandler( View_ConfirmChanges );
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
         View.FeatureSelected += new EventHandler<DataTypes.DataEventArgs<FeatureNames>>(View_FeatureSelected);
#endif
      }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
      void View_FeatureSelected(object sender, DataTypes.DataEventArgs<FeatureNames> e)
      {
         ServerSettingsDialog dlg = sender as ServerSettingsDialog;
         if (dlg != null)
         {
            if (!Shell.ServerAddins.IsFeatureValid(e.Data))
            {
               dlg.DisableFeature(e.Data);
            }
         }
      }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)

      void Instance_ServerServiceChanged ( object sender, EventArgs e )
      {
         string serviceDirectory ;
         
         
         serviceDirectory = string.Empty ;
         
         if ( null != __StorageSettingsPresenter )
         {
            if ( null != ServerState.Instance.ServerService ) 
            {
               serviceDirectory = ServerState.Instance.ServerService.ServiceDirectory ;

               __StorageSettingsPresenter.ServiceName = ServerState.Instance.ServerService.ServiceName;
            }
            

            __StorageSettingsPresenter.ReConfigureViews();

            
            ConfigureForwarder ( ) ;
            ConfigureAutoCopy();

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
            ConfigureExternalStore();
#endif

            __PatientUpdaterPresenter.ServiceDirectory = serviceDirectory;
            
         }
         
         if ( null != __LoggingConfigPresenter ) 
         {
            __LoggingConfigPresenter.EnableView = ServerState.Instance.ServerService != null ;
         }
      }
      
      void Instance_LoggingStateChanged ( object sender, EventArgs e )
      {
         if ( null != __LoggingConfigPresenter ) 
         {
            __LoggingConfigPresenter.ResetState ( ServerState.Instance.LoggingState ) ;
         }
      }

      private void CreateViews ( )
      {
         StorageModuleConfigurationManager  configManager = ServiceLocator.Retrieve <StorageModuleConfigurationManager> ( ) ;
         
         GeneralSettingsPresenter  generalPresenter = new GeneralSettingsPresenter ( ) ;
         ServerOptionsPresenter    optionsPresenter = new ServerOptionsPresenter ( ) ;
         GeneralSettingsView       generalView      = new GeneralSettingsView ( ) ;
         ServerOptionsView         optionsView      = new ServerOptionsView ( ) ;
         ServerNetworkingPresenter networkPresenter = new ServerNetworkingPresenter ( ) ;
         ServerNetworkingView      networkView      = new ServerNetworkingView ( ) ;
            
         StorageOptionsView storeOptionsView = new StorageOptionsView ( ) ;
         QueryOptionsView   queryOptionsView = new QueryOptionsView ( ) ;
         StorageSettingsPresenter storagePresenter = new StorageSettingsPresenter ( configManager ) ;

#if LEADTOOLS_V19_OR_LATER 
         StorageCommitView storageCommitView = new StorageCommitView();
         StorageCommitPresenter storageCommitPresenter = new StorageCommitPresenter();
#endif 
         SecurityOptionsPresenter securityOptionsPresenter = new SecurityOptionsPresenter();

         EventLogConfigurationView loggingConfigView = new EventLogConfigurationView  ( ) ;
         
         ClientViewerPresenter     clientConfigPresenter = new ClientViewerPresenter();
         ClientViewerControl       clientConfigView = new ClientViewerControl();
         
         EventLogConfigurationPresenter loggingConfigPresenter = new EventLogConfigurationPresenter ( ) ;
         
         PatientUpdaterConfigurationView patientUpdaterView = new PatientUpdaterConfigurationView ( ) ;
         PatientUpdaterPresenter         patientUpdaterPresenter = new PatientUpdaterPresenter ( ) ;
         
         AutoCopyView                    autoCopyView = new AutoCopyView ( ) ;
         AutoCopyPresenter               autoCopyPresenter = new AutoCopyPresenter ( ) ;

         StorageClassesTabControl storageClassesView        = new StorageClassesTabControl();        
         StorageClassesPresenter storageClassesPresenter = new StorageClassesPresenter();
         ForwardManagerConfigurationView forwardView = new ForwardManagerConfigurationView() { Visible = false };
         ForwardManagerPresenter forwardPresenter = new ForwardManagerPresenter();
         
         GatewaySettingsPresenter gatewayPresenter = new GatewaySettingsPresenter ( ) ;
         GatewaySettingsView      gatewayView = new GatewaySettingsView ( ) ;

         SecurityOptionsView      securityOptionsView = new SecurityOptionsView();

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         AnonymizeOptionsPresenter anonymizeOptionsPresenter = new AnonymizeOptionsPresenter();
         AnonymizeOptionsView anonymizeOptionsView = new AnonymizeOptionsView {SaveButtonVisible = false};
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         ExternalStoreConfigurationView externalStoreView = new ExternalStoreConfigurationView();
         ExternalStorePresenter externalStorePresenter = new ExternalStorePresenter();

         InitializeExternalStore(externalStoreView, externalStorePresenter);
#endif
         InitializeForwarding(forwardView, forwardPresenter);
         InitializeAutoCopy(autoCopyView, autoCopyPresenter);

#if LEADTOOLS_V19_OR_LATER 
         InitializeStorageCommit(storageCommitView, storageCommitPresenter);
#endif

         InitializeSecurityOptionsView(securityOptionsView, securityOptionsPresenter);

         generalPresenter.RunView ( generalView ) ;
         optionsPresenter.RunView ( optionsView ) ;
         networkPresenter.RunView ( networkView ) ;
         patientUpdaterPresenter.RunView(patientUpdaterView, ServerState.Instance.ServerService!=null?ServerState.Instance.ServerService.ServiceDirectory:string.Empty);
         clientConfigPresenter.RunView(clientConfigView);
         storageClassesPresenter.RunView(storageClassesView);

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         anonymizeOptionsPresenter.RunView(anonymizeOptionsView);    
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)   
         gatewayPresenter.RunView ( gatewayView ) ; 

         loggingConfigPresenter.RunView  ( loggingConfigView, ServerState.Instance.LoggingState ) ;
         
         loggingConfigPresenter.EnableView = ServerState.Instance.ServerService != null ;
         
         storeOptionsView.ShowDeleteAnnotationOption = false ;
         
         storagePresenter.RunViews ( storeOptionsView, queryOptionsView ) ;

         View.AddFeatureControl ( FeatureNames.ServerParentFeature, generalView, null ) ;
         View.AddFeatureControl ( FeatureNames.ServerSettings, generalView, FeatureNames.ServerParentFeature ) ;
         View.AddFeatureControl ( FeatureNames.ClientConfig, clientConfigView, FeatureNames.ServerParentFeature ) ;
         View.AddFeatureControl ( FeatureNames.ServerOptions, optionsView, FeatureNames.ServerParentFeature ) ;
         View.AddFeatureControl ( FeatureNames.ServerNetworking, networkView, FeatureNames.ServerParentFeature ) ;
         
         //
         // Storage Settings
         //
         View.AddFeatureControl ( FeatureNames.StoreSettingsParentFeature, storeOptionsView, null ) ;
         View.AddFeatureControl ( FeatureNames.StoreSettings, storeOptionsView, FeatureNames.StoreSettingsParentFeature ) ;
         View.AddFeatureControl ( FeatureNames.QuerySettings, queryOptionsView, FeatureNames.StoreSettingsParentFeature ) ;
#if LEADTOOLS_V19_OR_LATER 
         View.AddFeatureControl ( FeatureNames.StorageCommit, storageCommitView, FeatureNames.StoreSettingsParentFeature ) ;
#endif
         View.AddFeatureControl( FeatureNames.IodClasses, storageClassesView, FeatureNames.StoreSettingsParentFeature);
         
         if ( UserManager.User.IsAdmin ( ) )
         {
            PasswordOptionsPresenter passwordOptionsPresenter = new PasswordOptionsPresenter ( ) ;
            PasswordOptionsView passwordOptions = new PasswordOptionsView ( ) ;
            
            UserViewPresenter userViewPresenter = new UserViewPresenter ( ) ;
            RolesViewPresenter rolesViewPresenter = new RolesViewPresenter();
            UserView userView = new UserView();
            RolesView rolesView = new RolesView();
            DatabaseManagerOptionsView databaseManagerOptionsView = new DatabaseManagerOptionsView();
            DatabaseManagerOptionsPresenter databaseManagerOptionsPresenter = new DatabaseManagerOptionsPresenter();

#if LEADTOOLS_V20_OR_LATER
            ClientConfigurationOptionsView clientConfigurationOptionsView = new ClientConfigurationOptionsView();
            ClientConfigurationOptionsPresenter clientConfigurationOptionsPresenter = new ClientConfigurationOptionsPresenter();
           __ClientConfigurationOptionsPresenter = clientConfigurationOptionsPresenter;
#endif // #if LEADTOOLS_V20_OR_LATER

            __UserViewPresenter = userViewPresenter;
            __RolesViewPresenter = rolesViewPresenter;
            __DatabaseManagerOptionsPresenter = databaseManagerOptionsPresenter;
           
            passwordOptionsPresenter.RunView ( passwordOptions ) ;
            userViewPresenter.RunView        ( userView ) ;
            rolesViewPresenter.RunView(rolesView);
            databaseManagerOptionsPresenter.RunView(databaseManagerOptionsView);

#if LEADTOOLS_V20_OR_LATER
            clientConfigurationOptionsPresenter.RunView(clientConfigurationOptionsView);
#endif

#if LEADTOOLS_V19_OR_LATER
            CardUserViewPresenter cardUserViewPresenter = new CardUserViewPresenter();
            CardUserView cardUserView = new CardUserView();
            __CardUserViewPresenter = cardUserViewPresenter;
            cardUserViewPresenter.RunView(cardUserView);
#endif

            //
            // Administrative Settings
            //
            View.AddFeatureControl ( FeatureNames.AdministrationParentFeature, passwordOptions, null ) ;
            View.AddFeatureControl ( FeatureNames.PasswordOptions, passwordOptions, FeatureNames.AdministrationParentFeature ) ;
            View.AddFeatureControl ( FeatureNames.Users, userView, FeatureNames.AdministrationParentFeature ) ;
#if LEADTOOLS_V19_OR_LATER
            View.AddFeatureControl ( FeatureNames.CardUsers, cardUserView, FeatureNames.AdministrationParentFeature ) ;
#endif

            View.AddFeatureControl ( FeatureNames.Roles, rolesView, FeatureNames.AdministrationParentFeature);
            View.AddFeatureControl ( FeatureNames.DatabaseManagerOptions, databaseManagerOptionsView, FeatureNames.AdministrationParentFeature);
 
#if LEADTOOLS_V20_OR_LATER           
            View.AddFeatureControl ( FeatureNames.ClientConfigurationOptions,  clientConfigurationOptionsView, FeatureNames.AdministrationParentFeature);
 #endif
           
#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
            View.AddFeatureControl( FeatureNames.AnonymizeOptions, anonymizeOptionsView, FeatureNames.AdministrationParentFeature);
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)         
            __PasswordOptionsPresenter = passwordOptionsPresenter ;
            
            __PasswordOptionsPresenter.IdleTimeout += new EventHandler(passwordOptionsPresenter_IdleTimeout);
         }
         
         View.AddFeatureControl(FeatureNames.PatientUpdater, patientUpdaterView, null ) ;
         View.AddFeatureControl(FeatureNames.AutoCopy, autoCopyView, null ) ;
         View.AddFeatureControl(FeatureNames.LoggingConfig, loggingConfigView, null);
         View.AddFeatureControl(FeatureNames.Forwarder, forwardView, null);
         
         View.AddFeatureControl ( FeatureNames.Gateway, gatewayView, null ) ;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         View.AddFeatureControl ( FeatureNames.ExternalStore, externalStoreView, null ) ;
#endif
         View.AddFeatureControl(FeatureNames.SecurityOptions, securityOptionsView, null);

         __SecurityOptionsPresenter = securityOptionsPresenter;
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         __ExternalStorePresenter = externalStorePresenter;
#endif     
         __LoggingConfigPresenter      = loggingConfigPresenter ;
         __PatientUpdaterPresenter     = patientUpdaterPresenter ;
         __AutoCopyPresenter           = autoCopyPresenter ;
         __StorageClassesPresenter     = storageClassesPresenter;
         __StorageSettingsPresenter    = storagePresenter ;         
         __ClientConfigPresenter       = clientConfigPresenter;
         __GatewaySettingsPresenter    = gatewayPresenter;
         __GeneralSettingsPresenter    = generalPresenter;
         __ServerOptionsPresenter      = optionsPresenter;
         __ServerNetworkingPresenter   = networkPresenter;

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         __AnonymizeOptionsPresenter = anonymizeOptionsPresenter;
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

         SetClientConfigLicense();
         SetGatewayLicense();

         // Subscribe to SettingsChanged events
         __LoggingConfigPresenter.SettingsChanged           += new EventHandler(OnSettingsChanged);
         __PatientUpdaterPresenter.SettingsChanged          += new EventHandler(OnSettingsChanged);
         __AutoCopyPresenter.SettingsChanged                += new EventHandler(OnSettingsChanged);
         __StorageClassesPresenter.SettingsChanged          += new EventHandler(OnSettingsChanged);
         __StorageSettingsPresenter.SettingsChanged         += new EventHandler(OnSettingsChanged);
         __ClientConfigPresenter.SettingsChanged            += new EventHandler(OnSettingsChanged);
         
         __GeneralSettingsPresenter.SettingsChanged         += new EventHandler(OnSettingsChanged);
         __ServerOptionsPresenter.SettingsChanged           += new EventHandler(OnSettingsChanged);
         __ServerNetworkingPresenter.SettingsChanged        += new EventHandler(OnSettingsChanged);
         __ForwardPresenter.SettingsChanged                 += new EventHandler(OnSettingsChanged);

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         __ExternalStorePresenter.SettingsChanged           += new EventHandler(OnSettingsChanged);
#endif 

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         __AnonymizeOptionsPresenter.SettingsChanged          += new EventHandler(OnSettingsChanged);
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

#if LEADTOOLS_V19_OR_LATER 
         if (__StorageCommitPresenter != null)
         {
            __StorageCommitPresenter.SettingsChanged        += new EventHandler(OnSettingsChanged);
         }
#endif

         if (__SecurityOptionsPresenter != null)
         {
            __SecurityOptionsPresenter.SettingsChanged += new EventHandler(OnSettingsChanged);
         }

         if (__PasswordOptionsPresenter != null)
         {
            __PasswordOptionsPresenter.SettingsChanged      += new EventHandler(OnSettingsChanged);
         }
         
         if (__UserViewPresenter != null)
         {
            __UserViewPresenter.SettingsChanged             += new EventHandler(OnSettingsChanged);
         }
#if LEADTOOLS_V19_OR_LATER
         if (__CardUserViewPresenter != null)
         {
            __CardUserViewPresenter.SettingsChanged             += new EventHandler(OnSettingsChanged);
         }
#endif

         if (__RolesViewPresenter != null)
         {
            __RolesViewPresenter.SettingsChanged += new EventHandler(OnSettingsChanged);
         }
         
         if (__DatabaseManagerOptionsPresenter != null)
         {
            __DatabaseManagerOptionsPresenter.SettingsChanged += new EventHandler(OnSettingsChanged);
         }

#if LEADTOOLS_V20_OR_LATER
         if (__ClientConfigurationOptionsPresenter != null)
         {
            __ClientConfigurationOptionsPresenter.SettingsChanged += new EventHandler(OnSettingsChanged);
         }
#endif // #if LEADTOOLS_V20_OR_LATER      
         EventBroker.Instance.Subscribe<ActivateIdleMonitorEventArgs>(new EventHandler<ActivateIdleMonitorEventArgs>(OnActivateIdle));

         EventBroker.Instance.Subscribe<ExitMinimizedStateEventArgs>(new EventHandler<ExitMinimizedStateEventArgs>(OnExitMinimizedState));

      }
      
      void OnExitMinimizedState(object sender, ExitMinimizedStateEventArgs e)
      {
         if (e.MinimizedSeconds != 0)
         {
            if (
                  (e.MinimizedSeconds > __PasswordOptionsPresenter.View.Options.IdleTimeOut) &&
                  __PasswordOptionsPresenter.View.Options.EnableIdleTimeout
               )
            {
               EventBroker.Instance.PublishEvent<LoginEventArgs>(this, new LoginEventArgs());
            }
         }
      }

      private void InitializeAutoCopy(AutoCopyView autoCopyView, AutoCopyPresenter autoCopyPresenter)
      {
         if (ServerState.Instance.ServerService != null)
         {
            AdvancedSettings settings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory);

            autoCopyPresenter.RunView(autoCopyView, settings);
         }
         else
         {
            autoCopyPresenter.RunView(autoCopyView, null);
         }
         __AutoCopyPresenter = autoCopyPresenter;
      }

#if LEADTOOLS_V19_OR_LATER 
      private void InitializeStorageCommit(StorageCommitView storageCommitView, StorageCommitPresenter storageCommitPresenter)
      {
         if (ServerState.Instance.ServerService != null)
         {
            AdvancedSettings settings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory);

            storageCommitPresenter.RunView(storageCommitView, settings);
         }
         else
         {
            storageCommitPresenter.RunView(storageCommitView, null);
         }
         __StorageCommitPresenter = storageCommitPresenter;
      }
#endif // #if LEADTOOLS_V19_OR_LATER 


      private void InitializeSecurityOptionsView(SecurityOptionsView securityOptionsView, SecurityOptionsPresenter securityOptionsPresenter)
      {
         if (ServerState.Instance.ServerService != null)
         {
            AdvancedSettings settings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory);

            securityOptionsPresenter.RunView(securityOptionsView, settings);
         }
         else
         {
            securityOptionsPresenter.RunView(securityOptionsView, null);
         }
         __SecurityOptionsPresenter = securityOptionsPresenter;
      }

      private void InitializeForwarding(ForwardManagerConfigurationView forwardView, ForwardManagerPresenter forwardPresenter)
      {         
         if (ServerState.Instance.ServerService != null)
         {
            AdvancedSettings settings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory);

            forwardPresenter.RunView(forwardView, settings);                        
         }
         else
         {
            forwardPresenter.RunView(forwardView, null);                        
         }

         __ForwardPresenter = forwardPresenter;
         __ForwardPresenter.Forward += new EventHandler<ForwardMessageEventArgs>(Forwarder_Forward);
         __ForwardPresenter.Clean += new EventHandler<Leadtools.Medical.Winforms.Forwarder.SendMessageEventArgs>(Forwarder_Clean);
         __ForwardPresenter.Reset += new EventHandler<Leadtools.Medical.Winforms.Forwarder.ResetEventArgs>(Forwarder_Reset);
#if LEADTOOLS_V18_OR_LATER      
         __ForwardPresenter.CancelForward += new EventHandler<EventArgs>(Forwarder_CancelForward);
         __ForwardPresenter.CancelClean += new EventHandler<EventArgs>(Forwarder_CancelClean);
#endif // #if LEADTOOLS_V18_OR_LATER
         ConfigureForwarder();         

         ServerState.Instance.IsRemoteServerChanged += new EventHandler(OnConfigurerFowarder);
         ServerState.Instance.RemoteServerInformationChanged += new EventHandler(OnConfigurerFowarder);   
      }

      private void ConfigureForwarder()
      {
         if (ServerState.Instance.ServerService != null)
         {
            AdvancedSettings settings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory);

            __ForwardPresenter.UpdateSettings(settings);
            __ForwardPresenter.EnableTools(ServerState.Instance.ServerService.Status == ServiceControllerStatus.Running);
            ServerState.Instance.ServerService.StatusChange += new EventHandler(ServerService_StatusChange);
            ServerState.Instance.LicenseChanged += new EventHandler(Instance_LicenseChanged);
         }
         else
         {
            __ForwardPresenter.EnableTools(false);
            __ForwardPresenter.View.Enabled = false;
         }
         Instance_LicenseChanged(this, EventArgs.Empty);
      }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
      private void InitializeExternalStore(ExternalStoreConfigurationView externalStoreView, ExternalStorePresenter externalStorePresenter)
      {         
         if (ServerState.Instance.ServerService != null)
         {
            AdvancedSettings settings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory);

            externalStorePresenter.ServiceDirectory = ServerState.Instance.ServerService.ServiceDirectory;

            externalStorePresenter.RunView(externalStoreView, settings);                        
         }
         else
         {
            externalStorePresenter.RunView(externalStoreView, null);                        
         }

         __ExternalStorePresenter = externalStorePresenter;
         __ExternalStorePresenter.ExternalStore += new EventHandler<ExternalStoreMessageEventArgs>(ExternalStorePresenter_ExternalStore);
         __ExternalStorePresenter.CancelExternalStore += new EventHandler<EventArgs>(ExternalStorePresenter_CancelExternalStore);
         __ExternalStorePresenter.Clean += new EventHandler<Leadtools.Medical.Winforms.ExternalStore.CleanMessageEventArgs>(ExternalStorePresenter_Clean);
         __ExternalStorePresenter.Restore +=new EventHandler<RestoreMessageEventArgs>(ExternalStorePresenter_Restore);
         __ExternalStorePresenter.CancelRestore +=new EventHandler<EventArgs>(ExternalStorePresenter_CancelRestore);
         __ExternalStorePresenter.Reset += new EventHandler<Leadtools.Medical.Winforms.ExternalStore.ResetEventArgs>(ExternalStorePresenter_Reset);
         ConfigureExternalStore();         

         //ServerState.Instance.IsRemoteServerChanged += new EventHandler(OnConfigurerFowarder);
         //ServerState.Instance.RemoteServerInformationChanged += new EventHandler(OnConfigurerFowarder);   
      }

      private void ConfigureExternalStore()
      {
         if (ServerState.Instance.ServerService != null)
         {
            AdvancedSettings settings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory);

            __ExternalStorePresenter.ServiceDirectory = ServerState.Instance.ServerService.ServiceDirectory;
            __ExternalStorePresenter.UpdateSettings(settings);
            __ExternalStorePresenter.EnableTools(ServerState.Instance.ServerService.Status == ServiceControllerStatus.Running);
            ServerState.Instance.ServerService.StatusChange += new EventHandler(ExternalStore_ServerService_StatusChange);
            ServerState.Instance.LicenseChanged += new EventHandler(Instance_LicenseChanged);            
         }
         else
         {
            __ExternalStorePresenter.EnableTools(false);
            __ExternalStorePresenter.View.Enabled = false;
         }
         Instance_LicenseChanged(this, EventArgs.Empty);
      }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)

      private void ConfigureAutoCopy()
      {
         if (ServerState.Instance.ServerService != null)
         {
            AdvancedSettings settings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory);

            __AutoCopyPresenter.UpdateSettings(settings);
         }
      }

      void Instance_LicenseChanged(object sender, EventArgs e)
      {
         SetDefaultPresentersLicense();
         SetForwardLicense();
         SetGatewayLicense();
         SetClientConfigLicense();
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         SetExternalStoreLicense();
#endif
      }
      
      private void SetDefaultPresentersLicense()
      {
         // Always enabled

         // DICOM Server
         if (__GeneralSettingsPresenter != null)
            __GeneralSettingsPresenter.View.Enabled = true;
         if (__ClientConfigPresenter != null)
            __ClientConfigPresenter.View.Enabled = true;
         if (__ServerOptionsPresenter != null)
            __ServerOptionsPresenter.View.Enabled = true;
         if (__ServerNetworkingPresenter != null)
            __ServerNetworkingPresenter.View.Enabled = true;

         // Storage Settings
         if (__StorageSettingsPresenter != null)
            __StorageSettingsPresenter.StorageView.Enabled = true;
         if (__StorageSettingsPresenter != null)
            __StorageSettingsPresenter.QueryView.Enabled = true;
         if (__StorageClassesPresenter != null)
            __StorageClassesPresenter.View.Enabled = true;

         // Adminstration
         if (__PasswordOptionsPresenter != null)
            __PasswordOptionsPresenter.View.Enabled = true;
         if (__UserViewPresenter != null)
            __UserViewPresenter.View.Enabled = true;
#if LEADTOOLS_V19_OR_LATER
         if (__CardUserViewPresenter != null)
            __CardUserViewPresenter.View.Enabled = true;
#endif
         if (__RolesViewPresenter != null)
            __RolesViewPresenter.View.Enabled = true;
         if (__DatabaseManagerOptionsPresenter != null)
            __DatabaseManagerOptionsPresenter.View.Enabled = true;

#if LEADTOOLS_V20_OR_LATER
          if (__ClientConfigurationOptionsPresenter != null)
            __ClientConfigurationOptionsPresenter.View.Enabled = true;
#endif // #if LEADTOOLS_V20_OR_LATER

         // Patient Updater
         if (__PatientUpdaterPresenter != null)
            __PatientUpdaterPresenter.View.Enabled = true;

         // Auto Copy
         if (__AutoCopyPresenter != null)
            __AutoCopyPresenter.View.Enabled = true;

         // Logging Configuration
         if (__LoggingConfigPresenter != null)
            __LoggingConfigPresenter.View.Enabled = true;

         // Forwarding
         // Controled by licensing

         // Gateway
         // Controlled by licensing

         // Anonymize
#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         if (__AnonymizeOptionsPresenter != null)
            __AnonymizeOptionsPresenter.View.Enabled = true;
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
      }
      
      private bool IsFeatureValid(string featureId)
      {
         bool ret = true;
         
         ILicense license = ServerState.Instance.License;
         if (license == null)
            return false;
            
         IFeature feature = license.GetFeature(featureId);
         if (feature == null)
            ret = false;
         else if (feature.Type == LicenseFeatureType.Off)
            ret = false;
         else if (feature.Type == LicenseFeatureType.Eval && feature.IsExpired)
            ret = false;
         else
            ret = true;
         return ret;
      }
   
      private void SetForwardLicense()
      {
         if (__ForwardPresenter != null)
         {
            __ForwardPresenter.View.Enabled = IsFeatureValid(ServerFeatures.Forwarding);
         }
      }
      
      private void SetGatewayLicense()
      {
         if (__GatewaySettingsPresenter != null)
         {
            __GatewaySettingsPresenter.View.Enabled = IsFeatureValid(ServerFeatures.Gateway);
         }
      }

      private void SetClientConfigLicense()
      {
         if (__ClientConfigPresenter != null)
         {
            if (ServerState.Instance.License != null)
            {
               ILicense license = ServerState.Instance.License;
               IFeature feature = license.GetFeature(ServerFeatures.MaxConfigurableClients);

               if (feature != null && feature.Type == LicenseFeatureType.LimitedNumber)
                  __ClientConfigPresenter.MaxClients = (feature.Counter <= 0) ? int.MaxValue : feature.Counter;
               else if (feature != null && feature.Type == LicenseFeatureType.Eval && !feature.IsExpired)
                  __ClientConfigPresenter.MaxClients = 10;
               else if (feature == null)
                  __ClientConfigPresenter.MaxClients = null;
               else
                  __ClientConfigPresenter.MaxClients = 0;

            }
            else
            {
               //
               // If there is not setting for max clients then there is no limitation
               //
               __ClientConfigPresenter.MaxClients = null;
            }
         }
      }

      private void OnConfigurerFowarder(object sender, EventArgs e)
      {
         ConfigureForwarder();
      }

      void passwordOptionsPresenter_IdleTimeout(object sender, EventArgs e)
      {
         EventBroker.Instance.PublishEvent<LoginEventArgs>(this, new LoginEventArgs());
      }

      void OnActivateIdle(object sender, ActivateIdleMonitorEventArgs e)
      {
         if ( null != __PasswordOptionsPresenter ) 
         {
            __PasswordOptionsPresenter.UpdateIdleMonitor(e);
         }
      }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
      private void SetExternalStoreLicense()
      {
         if (__ExternalStorePresenter != null)
         {
            __ExternalStorePresenter.View.Enabled = IsFeatureValid(ServerFeatures.ExternalStore);
         }
      }

      void ExternalStorePresenter_ExternalStore(object sender, ExternalStoreMessageEventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.ExternalStore, e.ExternalStoreTo);
         }
      }

      void ExternalStorePresenter_CancelExternalStore(object sender, EventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.CancelExternalStore);
         }
      }

      void ExternalStorePresenter_Clean(object sender, Leadtools.Medical.Winforms.ExternalStore.CleanMessageEventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.Clean, e.ExternalStoreTo, e.ExpirationDays);
         }
      }

      void ExternalStorePresenter_Restore(object sender, RestoreMessageEventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            DateRange range = new DateRange();

            range.StartDate = e.Start;
            range.EndDate = e.End;
            ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.Restore, e.RestoreFrom, range);
         }
      }

      void ExternalStorePresenter_CancelRestore(object sender, EventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.CancelRestore);
         }
      }

      void ExternalStorePresenter_Reset(object sender, Leadtools.Medical.Winforms.ExternalStore.ResetEventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            DateRange range = new DateRange();

            range.StartDate = e.Start;
            range.EndDate = e.End;
            ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.Reset, range);
         }
      } 

      void ExternalStore_ServerService_StatusChange(object sender, EventArgs e)
      {
         AsyncHelper.SynchronizedInvoke(Application.OpenForms[0],() => __ExternalStorePresenter.EnableTools(ServerState.Instance.ServerService.Status == ServiceControllerStatus.Running));
      }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)

      void Forwarder_Forward(object sender, ForwardMessageEventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            ServerState.Instance.ServerService.SendMessage(ForwarderMessage.Forward, e.ForwardTo);
         }
      }

#if LEADTOOLS_V18_OR_LATER
      void Forwarder_CancelForward(object sender, EventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            ServerState.Instance.ServerService.SendMessage(ForwarderMessage.CancelForward);
         }
      }

      void Forwarder_CancelClean(object sender, EventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            ServerState.Instance.ServerService.SendMessage(ForwarderMessage.CancelClean);
         }
      }
#endif // #if LEADTOOLS_V18_OR_LATER

      void Forwarder_Clean(object sender, Leadtools.Medical.Winforms.Forwarder.SendMessageEventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            ServerState.Instance.ServerService.SendMessage(ForwarderMessage.Clean);
         }
      }

      void Forwarder_Reset(object sender, Leadtools.Medical.Winforms.Forwarder.ResetEventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            DateRange range = new DateRange();

            range.StartDate = e.Start;
            range.EndDate = e.End;
            ServerState.Instance.ServerService.SendMessage(ForwarderMessage.Reset, range);
         }
      }

      void ServerService_StatusChange(object sender, EventArgs e)
      {
         AsyncHelper.SynchronizedInvoke(Application.OpenForms[0],() => __ForwardPresenter.EnableTools(ServerState.Instance.ServerService.Status == ServiceControllerStatus.Running));
      }

      public ServerSettingsDialog View
      {
         get ;
         private set ;
      }

      private void OnDisplayFeature ( object sender, DisplayFeatureEventArgs featureArgs ) 
      {
         if ( FeatureNames.DisplaySettingsFeature == featureArgs.Feature )
         {
            View.EnsureActive ( ) ;
         }
         else if ( View.IsFeatureAdded ( featureArgs.Feature ) )
         {
            View.SelectFeature ( featureArgs.Feature ) ;

            View.EnsureActive ( ) ;
         }
      }
      
      private EventLogConfigurationPresenter __LoggingConfigPresenter { get ; set ; }
      private PatientUpdaterPresenter        __PatientUpdaterPresenter { get ; set ; }
      private AutoCopyPresenter              __AutoCopyPresenter  { get ; set ; }
      private ForwardManagerPresenter        __ForwardPresenter { get; set; }
      private PasswordOptionsPresenter       __PasswordOptionsPresenter { get; set; }

      private StorageClassesPresenter        __StorageClassesPresenter { get; set; }
      private StorageSettingsPresenter       __StorageSettingsPresenter { get; set; }

      private ClientViewerPresenter          __ClientConfigPresenter { get; set; }
      private GatewaySettingsPresenter       __GatewaySettingsPresenter { get; set; }

      private GeneralSettingsPresenter       __GeneralSettingsPresenter { get; set; }
      private ServerOptionsPresenter         __ServerOptionsPresenter   { get; set; }
      private ServerNetworkingPresenter      __ServerNetworkingPresenter { get; set; }
      
      private UserViewPresenter              __UserViewPresenter{ get; set; }
#if LEADTOOLS_V19_OR_LATER
      private CardUserViewPresenter              __CardUserViewPresenter{ get; set; }
#endif
      private RolesViewPresenter             __RolesViewPresenter { get; set; }
      private DatabaseManagerOptionsPresenter __DatabaseManagerOptionsPresenter { get; set; }

#if LEADTOOLS_V20_OR_LATER
      private ClientConfigurationOptionsPresenter __ClientConfigurationOptionsPresenter { get; set;}
#endif

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
      private ExternalStorePresenter         __ExternalStorePresenter{ get; set; }
#endif

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
      private AnonymizeOptionsPresenter        __AnonymizeOptionsPresenter { get; set; }
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

#if LEADTOOLS_V19_OR_LATER 
      private StorageCommitPresenter __StorageCommitPresenter { get; set; }
#endif

      private SecurityOptionsPresenter __SecurityOptionsPresenter { get; set; }
      void View_CancelChanges ( object sender, EventArgs e )
      {
         // These live in Leadtools.Medical.Winforms.dll
         __LoggingConfigPresenter.ResetView ( ) ;
         __PatientUpdaterPresenter.CancelOptions ( ) ;
         __AutoCopyPresenter.CancelOptions ( ) ;
         __ForwardPresenter.CancelOptions();
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         __ExternalStorePresenter.CancelOptions();
#endif
         __StorageClassesPresenter.ResetSettings();
         __StorageSettingsPresenter.ResetView();

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         __AnonymizeOptionsPresenter.ResetSettings();
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

         if (null != __PasswordOptionsPresenter)
         {
            __PasswordOptionsPresenter.ResetView();
         }

         // These live in the EXE
         EventBroker.Instance.PublishEvent <CancelServerSettingsEventArgs> ( this, new CancelServerSettingsEventArgs ( ) ) ;
         
         LocalAuditLogQueue.Clear ( ) ;
         View.CanApply = false;
      }

      void View_ConfirmChanges ( object sender, EventArgs e )
      {
         // Code below prevents the "configuration file has been changed by another program' exception
         // This happens when an addin that the server manager does not know about (i.e. Leadtools.Medical.Rules.Addin) saves its settings into 'advanced.config', which occurs in a different process
         // When the main process (server manager UI) saves the advanced.config without doing a RefreshSettings first, the exception occurs
         //
         // To prevent this:
         //    Get a reference to the global copy of 'advanced.config' and refresh from disk (RefreshSettings)
         //    All the presenters (i.e. _PatientUpdaterPresenter) have a reference to this, but it is the same reference
         //    Now copy all settings into the reference to 'advanced.config' and save
         
         if (ServerState.Instance.ServerService != null)
         {
            AdvancedSettings settings = AdvancedSettings.Open(ServerState.Instance.ServerService.ServiceDirectory);
            settings.RefreshSettings();
         }
         
         // These live in Leadtools.Medical.Winforms.dll
         __LoggingConfigPresenter.UpdateState  ( ) ;
         __PatientUpdaterPresenter.SaveOptions ( ) ;
         __AutoCopyPresenter.SaveOptions ( ) ;
         __ForwardPresenter.SaveOptions();

         if (__SecurityOptionsPresenter.IsDirty)
         {
            __SecurityOptionsPresenter.SaveOptions();
         }

#if LEADTOOLS_V19_OR_LATER 
         bool isStorageCommitDirty = __StorageCommitPresenter.IsDirty;
         if (isStorageCommitDirty)
         {
            __StorageCommitPresenter.SaveOptions();

            // This fails if the service is not running
            // This is not a problem, because once the service starts it will read the options
            try
            {
               DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "SendMessage(ExternalStoreMessage.SettingsChanged)");
               // ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.SettingsChanged);
            }
            catch (Exception ex)
            {
               DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Exception: SendMessage(ExternalStoreMessage.SettingsChanged)" + ex.Message);
            }
         }
#endif

         bool isSecurityOptionsDirty = __SecurityOptionsPresenter.IsDirty;
         if (isSecurityOptionsDirty)
         {
            __SecurityOptionsPresenter.SaveOptions();

            // This fails if the service is not running
            // This is not a problem, because once the service starts it will read the options
            try
            {
               // DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "SendMessage(SecurityOptionsMessage.SettingsChanged)");
               // ServerState.Instance.ServerService.SendMessage(SecurityOptionsMessage.SettingsChanged);
            }
            catch (Exception)
            {
              //  DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Exception: SendMessage(SecurityOptionsMessage.SettingsChanged)" + ex.Message);
            }
         }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         bool isExternalStoreDirty = __ExternalStorePresenter.IsDirty;
         DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "__ExternalStorePresenter.IsDirty : " + isExternalStoreDirty.ToString());
         if (isExternalStoreDirty)
         {
            __ExternalStorePresenter.SaveOptions();

            // This fails if the service is not running
            // This is not a problem, because once the service starts it will read the options
            try
            {
               DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "SendMessage(ExternalStoreMessage.SettingsChanged)");
               ServerState.Instance.ServerService.SendMessage(ExternalStoreMessage.SettingsChanged);
            }
            catch (Exception ex)
            {
               DicomUtilities.DebugString(DebugStringOptions.ShowCounter, "Exception: SendMessage(ExternalStoreMessage.SettingsChanged)" + ex.Message);
            }
         }
 #endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
                 
         if ( __StorageClassesPresenter.IsDirty ) 
         {
            StorageModuleConfigurationManager configManager ;
            
            
            configManager = ServiceLocator.Retrieve <StorageModuleConfigurationManager> ( ) ;
            
            __StorageClassesPresenter.UpdateSettings();
            
            if ( configManager.IsLoaded ) 
            {
               configManager.SetPresentationContextsTimestamp ( ) ;
            }
         }

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         if (__AnonymizeOptionsPresenter.IsDirty) 
         {
            StorageModuleConfigurationManager configManager  = ServiceLocator.Retrieve <StorageModuleConfigurationManager> ( ) ;
            
            __AnonymizeOptionsPresenter.UpdateSettings();
         }
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

         if (null != __StorageSettingsPresenter)
         {
            if (__StorageSettingsPresenter.IsDirty)
            {
               __StorageSettingsPresenter.UpdateState();
               __StorageSettingsPresenter.SaveSettings();
            }
         }
         
         if ( __DatabaseManagerOptionsPresenter.IsDirty)
         {
            __DatabaseManagerOptionsPresenter.SaveOptions();
            
            DatabaseManagerOptionsAppliedEventArgs args = new DatabaseManagerOptionsAppliedEventArgs();
            EventBroker.Instance.PublishEvent <DatabaseManagerOptionsAppliedEventArgs> ( this, args) ;
         }

#if LEADTOOLS_V20_OR_LATER
         if ( __ClientConfigurationOptionsPresenter.IsDirty)
         {
            __ClientConfigurationOptionsPresenter.SaveOptions();
            
            ClientConfigurationOptionsAppliedEventArgs args = new ClientConfigurationOptionsAppliedEventArgs();
            EventBroker.Instance.PublishEvent <ClientConfigurationOptionsAppliedEventArgs> ( this, args) ;
         }
#endif // #if LEADTOOLS_V20_OR_LATER

         // These live in the EXE
         EventBroker.Instance.PublishEvent <ApplyServerSettingsEventArgs> ( this, new ApplyServerSettingsEventArgs ( ) ) ;
         EventBroker.Instance.PublishEvent <ServerSettingsAppliedEventArgs> ( this, new ServerSettingsAppliedEventArgs ( ) ) ;

         if ( null != __PasswordOptionsPresenter ) 
         {
            __PasswordOptionsPresenter.SaveOptions();
         }
         
         LocalAuditLogQueue.FlushLogs ( Logger.Global, UserManager.User.Name ) ;
         
         View.CanApply = false;
      }

      void OnSettingsChanged(object sender, EventArgs e)
      {
         View.CanApply = true;
      }
   }
}
