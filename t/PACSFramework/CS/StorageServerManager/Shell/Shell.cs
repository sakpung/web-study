// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Leadtools.Demos.StorageServer.UI;
using System.Drawing.Drawing2D;
using Leadtools.Dicom.Server.Admin;
using Leadtools.Medical.Winforms;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Medical.Logging.DataAccessLayer;
using Leadtools.Medical.Logging.DataAccessLayer.Configuration;
using Leadtools.Demos.StorageServer.DataTypes;
using System.IO;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.DicomDemos;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;
using Leadtools.Medical.Winforms.DataAccessLayer.Configuration;
using Leadtools.Medical.Forward.DataAccessLayer;
using Leadtools.Medical.Forward.DataAccessLayer.Configuration;
using Leadtools.Dicom.AddIn;
using Leadtools.Medical.Logging.Addins;
using Leadtools.Logging;
using Leadtools.Logging.Medical ;
using Leadtools.Medical.Storage.AddIns;
using System.Configuration;
using Leadtools.Medical.Winforms.EventBrokerArgs;
using Leadtools.Dicom;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.WebViewer.PatientAccessRights.DataAccessAgent;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.Medical.ExternalStore.DataAccessLayer.Configuration;
#endif

#if TUTORIAL_CUSTOM_DATABASE
using My.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Interface;
using Leadtools.Dicom.Scp;
using My.Medical.Storage.DataAccessLayer.Entities;
#endif

namespace Leadtools.Demos.StorageServer
{

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
   public class StorageServerAddins
   {
      private bool _externalStoreValid;
      private bool _patientUpdaterValid;
      private bool _autoCopyValid;
      private bool _forwarderValid;
      private bool _gatewayValid;
      private bool _securityValid;

      public StorageServerAddins()
      {
         _externalStoreValid = true;
         _patientUpdaterValid = true;
         _autoCopyValid = true;
         _forwarderValid = true;
         _gatewayValid = true;
         _securityValid = true;
      }

      public event EventHandler Changed;

      public bool ExternalStoreValid
      {
         get { return _externalStoreValid; }
         set
         {
            if (_externalStoreValid != value)
            {
               _externalStoreValid = value;
               OnChanged();
            }
         }
      }

      public bool IsFeatureValid(FeatureNames featureName)
      {
         bool ret = true;
         switch (featureName.Name)
         {
            case "ExternalStore":
               ret = _externalStoreValid;
               break;

            case "PatientUpdater":
               ret = _patientUpdaterValid;
               break;

            case "AutoCopy":
               ret = _autoCopyValid;
               break;

            case "Forwarder":
               ret = _forwarderValid;
               break;

            case "Gateway":
               ret = _gatewayValid;
               break;

            case "Server":
               ret = _securityValid;
               break;
         }
         return ret;
      }

      public bool PatientUpdaterValid
      {
         get { return _patientUpdaterValid; }
         set
         {
            if (_patientUpdaterValid != value)
            {
               _patientUpdaterValid = value;
               OnChanged();
            }
         }
      }

      public bool AutoCopyValid
      {
         get { return _autoCopyValid; }
         set
         {
            if (_autoCopyValid != value)
            {
               _autoCopyValid = value;
               OnChanged();
            }
         }
      }

      public bool ForwarderValid
      {
         get { return _forwarderValid; }
         set
         {
            if (_forwarderValid != value)
            {
               _forwarderValid = value;
               OnChanged();
            }
         }
      }

      public bool GatewayValid
      {
         get { return _gatewayValid; }
         set
         {
            if (_gatewayValid != value)
            {
               _gatewayValid = value;
               OnChanged();
            }
         }
      }

      public bool SecurityValid
      {
         get { return _securityValid; }
         set
         {
            if (_securityValid != value)
            {
               _securityValid = value;
               OnChanged();
            }
         }
      }

      private void OnChanged()
      {
         if (null != Changed)
         {
            Changed(this, EventArgs.Empty);
         }
      }
   }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
   public partial class Shell
   {
      private MainForm _Form;

      public Shell ( ) 
      {
         
      }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
      public static StorageServerAddins ServerAddins = new StorageServerAddins();
#endif 

      public void Run ( ) 
      {
         try
         {
            
            StorageServerContainerView      containerPanel     = new StorageServerContainerView ( ) ;
            StorageServerContainerPresenter containerPresenter = new StorageServerContainerPresenter () ;                                                
               
            RegisterDataAccessLayers ( ) ;

            _Form                       = new MainForm ( ) ;
            _Form.Text                  = Shell.storageServerName;
            containerPanel.Dock         = DockStyle.Fill ;
            containerPanel.GradientMode = LinearGradientMode.Vertical ;

            _Form.Controls.Add ( containerPanel ) ;
            
            using ( ServiceAdministrator serverAdmin = new ServiceAdministrator ( Application.StartupPath ) )
            {
               DicomService service = null ;
               
               
               string serviceName = InitializeServiceAdmin ( serverAdmin ) ;
            
               if ( serverAdmin.Services.Count > 0 )
               {
                  service = serverAdmin.Services [ serviceName ] ;
               }

               CreateConfigurationServices ( service ) ;

                         
#if TUTORIAL_CUSTOM_DATABASE
               // To use a custom database schema, you must create and register your CatalogEntity classes (MyPatient, MyStudy, MySeries, MyInstance).
               // Also, you must register your classes to extract DICOM data from a System.Data.DataRow (MyPatientInfo, MyStudyInfo, MySeriesInfo, MyInstanceInfo
               // For more details, see the "Changing the LEAD Medical Storage Server to use a different database schema" tutorial.

               DataAccessServiceLocator.Register<IPatientInfo>(new MyPatientInfo());
               DataAccessServiceLocator.Register<IStudyInfo>(new MyStudyInfo());
               DataAccessServiceLocator.Register<ISeriesInfo>(new MySeriesInfo());
               DataAccessServiceLocator.Register<IInstanceInfo>(new MyInstanceInfo());

               RegisteredEntities.Items.Add(RegisteredEntities.PatientEntityName, typeof(MyPatient));
               RegisteredEntities.Items.Add(RegisteredEntities.StudyEntityName, typeof(MyStudy));
               RegisteredEntities.Items.Add(RegisteredEntities.SeriesEntityName, typeof(MySeries));
               RegisteredEntities.Items.Add(RegisteredEntities.InstanceEntityName, typeof(MyInstance));
#endif


               ServerState.Instance.ServerService = service;
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
               if (ServerState.Instance.ServerService != null)
               {
                  ServerState.Instance.ServerService.Message += new EventHandler<MessageEventArgs>(ServerService_Message);
               }
#endif
               ServerState.Instance.ServiceAdmin = serverAdmin;
               ServerState.Instance.BaseDirectory = Application.StartupPath ;
               ServerState.Instance.ServiceName   = serviceName ;

               ConfigureDataAccessLayers ( ) ;
               
               LoadLoggingState ( service ) ;
               InitializeLogger ( ) ;
#if LEADTOOLS_V18_OR_LATER
               CheckLicenseFile();
#endif // #if LEADTOOLS_V18_OR_LATER

               string csPathLogDump = ServerState.Instance.LoggingState.AutoSaveDirectory;
               
               containerPresenter.PathLogDump = csPathLogDump;
               
               containerPresenter.RunView ( containerPanel ) ;               

               SubscribeToEvents ( ) ;

               new AuditLogSubscriber ( ).Start ( ) ;
               
               new CStoreAddIn().Start();
               
               LogAudit ( string.Format ( AuditMessages.UserLogIn.Message, UserManager.User.FriendlyName ) ) ;
               
               Start(_Form);

               if (UserManager.User != null)
               {
                  LogAudit(string.Format(AuditMessages.UserLogOff.Message, UserManager.User.FriendlyName));
               }
               else
               {
                  LogAudit("Canceled idle timer re-login");
               }
            }  
         }
         catch ( Exception) 
         {
            // Console.WriteLine ( ex.Message ) ;
            throw;
         }
      }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
      public static void ServerService_Message(object sender, MessageEventArgs e)
      {
         if (e == null || e.Message == null)
         {
            return;
         }

         if (!e.Message.Success)
         {
            Logger.Global.Log(string.Empty,
                              e.Message.Service, // string.Empty,
                              string.Empty,
                              0,
                              string.Empty,
                              string.Empty,
                              0,
                              DicomCommandType.Undefined,
                              DateTime.Now,
                              LogType.Error,
                              MessageDirection.None,
                              e.Message.Error,
                              null,
                              null);

            if (e.Message.Error.Contains("Leadtools.Medical.AutoCopy.AddIn", StringComparison.OrdinalIgnoreCase))
            {
               ServerAddins.AutoCopyValid = false;
            }

            else if (e.Message.Error.Contains("Leadtools.Medical.ExternalStore.Addin", StringComparison.OrdinalIgnoreCase))
            {
               ServerAddins.ExternalStoreValid = false;
               ServerAddins.GatewayValid = false;
            }

            else if (e.Message.Error.Contains("Leadtools.Medical.Forwarder.Addin", StringComparison.OrdinalIgnoreCase))
            {
               ServerAddins.ForwarderValid = false;
            }

            else if (e.Message.Error.Contains("Leadtools.Medical.PatientUpdater.Addin", StringComparison.OrdinalIgnoreCase))
            {
               ServerAddins.PatientUpdaterValid = false;
            }
         }
      }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)

      private void ConfigureDataAccessLayers ( )
      {
         IStorageDataAccessAgent storageDataAccess = DataAccessServices.GetDataAccessService <IStorageDataAccessAgent> ( ) ;
         
         
         if ( storageDataAccess != null && storageDataAccess is StorageDbDataAccessAgent ) 
         {
            StorageModuleConfigurationManager storageConfig = ServiceLocator.Retrieve <StorageModuleConfigurationManager> ( ) ;
            
            if ( storageConfig.IsLoaded )
            {
               ((StorageDbDataAccessAgent)storageDataAccess).AutoTruncateData = storageConfig.GetStorageAddInsSettings(ServerState.Instance.ServiceName).StoreAddIn.AutoTruncateData;
            }
         }
      }

      private void CreateConfigurationServices ( DicomService service )
      {
         StorageModuleConfigurationManager storageConfigMnager = new StorageModuleConfigurationManager ( false ) ;
         LoggingModuleConfigurationManager loggingConfigManager = new LoggingModuleConfigurationManager ( false ) ;
         
         if ( null != service ) 
         {
            storageConfigMnager.Load  ( service.ServiceDirectory ) ;
            loggingConfigManager.Load ( service.ServiceDirectory ) ;
         }
         
         ServiceLocator.Register <StorageModuleConfigurationManager> ( storageConfigMnager ) ;
         ServiceLocator.Register <LoggingModuleConfigurationManager> ( loggingConfigManager ) ;
      }

      private void InitializeLogger ( )
      {
         LoggingConfigurationSession.ConfigureLogger ( Logger.Global, 
                                                       ServerState.Instance.LoggingState, 
                                                       DataAccessServices.GetDataAccessService <ILoggingDataAccessAgent2> ( ) ) ;
      }

      private static void LoadLoggingState ( DicomService service )
      {
         LoggingModuleConfigurationManager loggingConfigManager = ServiceLocator.Retrieve <LoggingModuleConfigurationManager> ( ) ;
         
         if ( service != null  && loggingConfigManager.IsLoaded )
         {
            ServerState.Instance.LoggingState = loggingConfigManager.GetLoggingState ( ) ;
         }
         else
         {
            ServerState.Instance.LoggingState = GetDefaultLoggingState ( ) ;
         }
      }

      private void SubscribeToEvents()
      {
         EventBroker.Instance.Subscribe <ServerSettingsAppliedEventArgs> ( Instance_ServerSettingsApplied ) ;
         EventBroker.Instance.Subscribe <LoginEventArgs>                 ( Relogin ) ;
         
         ServerState.Instance.LoggingStateChanged += new EventHandler ( Instance_LoggingStateChanged ) ;
         
      }
      
      void Instance_ServerSettingsApplied ( object sender, EventArgs e )
      {
         ConfigureDataAccessLayers ( ) ;
         
         InitializeLogger ( ) ;
         
         SaveSettings ( ) ;
      }

      private void SaveSettings ( )
      {
         SetStorageServerInformationOptions ( DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent> ( ) ) ;
         
         SaveLoggingState ( ) ;
      }

      void Relogin(object sender, EventArgs e)
      {
         if (_Form.InvokeRequired)
         {
            _Form.Invoke(new EventHandler(Relogin));
         }
         else
         {
            LogAudit ( string.Format ( AuditMessages.UserLogOff.Message, UserManager.User.FriendlyName ) ) ;
            
            UserManager.User = null;

            try
            {
               EventBroker.Instance.PublishEvent<ActivateIdleMonitorEventArgs>(this, new ActivateIdleMonitorEventArgs(false));
               if (!Program.Login("Idle timeout.  Please re-login to continue.", true))
               {
                  Environment.Exit(0);
               }
               else
               {
                  LogAudit(string.Format(AuditMessages.UserLogIn.Message, UserManager.User.FriendlyName));
               }
            }
            finally
            {
               EventBroker.Instance.PublishEvent<ActivateIdleMonitorEventArgs>(this, new ActivateIdleMonitorEventArgs(true));
            }
         }
      }
      
      void Instance_LoggingStateChanged ( object sender, EventArgs e )
      {
         InitializeLogger ( ) ;
      }

      private string InitializeServiceAdmin ( ServiceAdministrator serverAdmin )
      {
         IOptionsDataAccessAgent  optionsAgent ;
         StorageServerInformation serverInfo ;
         List <string>            services ;
         string                   serviceName ;
         
         optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent> ( ) ;
         serverInfo   = optionsAgent.Get <StorageServerInformation> ( typeof (StorageServerInformation).Name, null, new Type[0] ) ;
         services     = new List<string> ( ) ;
         
         ServerState.Instance.IsRemoteServer = false ;
         
         if ( null == serverInfo ) 
         {
            serviceName = DefaultServiceName;
            
            services.Add ( serviceName ) ;
         }
         else
         {
            if ( serverInfo.MachineName.ToLower() == Environment.MachineName.ToLower() )
            {
               if ( !string.IsNullOrEmpty ( serverInfo.ServiceName) )
               {
                  serviceName = serverInfo.ServiceName ;
               }
               else
               {
                  serviceName = DefaultServiceName;
               }
               
               services.Add ( serverInfo.ServiceName ) ;
            }
            else
            {
               ServerState.Instance.IsRemoteServer          = true ;
               ServerState.Instance.RemoteServerInformation = serverInfo ;
               
               serviceName = serverInfo.ServiceName ;
            }
         }
         
         ServerState.Instance.ServiceAdminChanged  += new EventHandler ( Instance_ServiceAdminChanged ) ;
         ServerState.Instance.ServerServiceChanged += new EventHandler ( Instance_ServerServiceChanged ) ;
         
         if ( services.Count > 0 ) 
         {
            serverAdmin.Initialize ( services ) ;
         }
         
         return serviceName;
      }

      private void RegisterDataAccessLayers ( )
      {
#if (LEADTOOLS_V19_OR_LATER && !TUTORIAL_CUSTOM_DATABASE)
         IStorageDataAccessAgent3             storageAgent ;
#else
         IStorageDataAccessAgent              storageAgent ;
#endif 
         ILoggingDataAccessAgent2             loggingAgent ;
         //IOptionsDataAccessAgent              optionsAgent ;
         IAeManagementDataAccessAgent         aeManagementAgent;
         IPermissionManagementDataAccessAgent permissionManagementAgent;
         IForwardDataAccessAgent              forwardManagementAgent;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         IExternalStoreDataAccessAgent        externalStoreAgent;
#endif

#if (LEADTOOLS_V20_OR_LATER)
         IPatientRightsDataAccessAgent2 patientRightsAgent;
#endif


         System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();

#if TUTORIAL_CUSTOM_DATABASE
         // To use a custom database schema, you must create a data access configuration view that implements IDataAccessConfigurationView. 
         // This helper class is used to create your custom data access agent.
         // For more details, see the "Changing the LEAD Medical Storage Server to use a different database schema" tutorial.

         storageAgent = DataAccessFactory.GetInstance ( new MyStorageDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent <IStorageDataAccessAgent> ( ) ;
#elif (LEADTOOLS_V19_OR_LATER)
         storageAgent = DataAccessFactory.GetInstance ( new StorageDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent <IStorageDataAccessAgent3> ( ) ;
#else
         storageAgent = DataAccessFactory.GetInstance ( new StorageDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent <IStorageDataAccessAgent> ( ) ;
#endif
         
         loggingAgent = DataAccessFactory.GetInstance(new LoggingDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent<ILoggingDataAccessAgent2>();
         //optionsAgent = DataAccessFactory.GetInstance(new OptionsDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent<IOptionsDataAccessAgent>();
         aeManagementAgent = DataAccessFactory.GetInstance(new AeManagementDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent<IAeManagementDataAccessAgent>();
         permissionManagementAgent = DataAccessFactory.GetInstance(new AePermissionManagementDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent<IPermissionManagementDataAccessAgent>();
         forwardManagementAgent = DataAccessFactory.GetInstance(new ForwardDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null) ).CreateDataAccessAgent<IForwardDataAccessAgent>();
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         externalStoreAgent = DataAccessFactory.GetInstance(new ExternalStoreDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null) ).CreateDataAccessAgent<IExternalStoreDataAccessAgent>();
#endif

#if (LEADTOOLS_V20_OR_LATER)
         patientRightsAgent = DataAccessFactory.GetInstance(new PatientRightsDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent<IPatientRightsDataAccessAgent2>();
#endif

         DataAccessServices.RegisterDataAccessService <IStorageDataAccessAgent> ( storageAgent ) ;
         DataAccessServices.RegisterDataAccessService <ILoggingDataAccessAgent2> ( loggingAgent ) ;
         //DataAccessServices.RegisterDataAccessService<IOptionsDataAccessAgent>(optionsAgent);
         DataAccessServices.RegisterDataAccessService<IAeManagementDataAccessAgent>(aeManagementAgent);
         DataAccessServices.RegisterDataAccessService<IPermissionManagementDataAccessAgent>(permissionManagementAgent);
         DataAccessServices.RegisterDataAccessService<IForwardDataAccessAgent>(forwardManagementAgent);

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
         DataAccessServices.RegisterDataAccessService<IExternalStoreDataAccessAgent>(externalStoreAgent);
#endif

#if (LEADTOOLS_V20_OR_LATER)
         DataAccessServices.RegisterDataAccessService<IPatientRightsDataAccessAgent2>(patientRightsAgent);
#endif
      }

      void Instance_ServerServiceChanged ( object sender, EventArgs e )
      {
         IOptionsDataAccessAgent optionsAgent ;
         
         
         optionsAgent = DataAccessServices.GetDataAccessService <IOptionsDataAccessAgent> ( ) ;
         
         if ( null != ServerState.Instance.ServerService )
         {
            SetStorageServerInformationOptions ( optionsAgent ) ;

            LoadLicense(ServerState.Instance.ServerService.Settings.LicenseFile);
         }
         else
         {
            optionsAgent.DeleteOption ( typeof ( StorageServerInformation) .Name ) ;
            
            ServerState.Instance.License = null;
         }
         
         LoadLoggingState ( ServerState.Instance.ServerService ) ;
      }

      private static void SetStorageServerInformationOptions ( IOptionsDataAccessAgent optionsAgent )
      {
         if ( null != ServerState.Instance.ServerService )
         {
            StorageServerInformation information = null ;
            
            DicomAE ae = new DicomAE ( ServerState.Instance.ServerService.Settings.AETitle, 
                                       ServerState.Instance.ServerService.Settings.IpAddress, 
                                       ServerState.Instance.ServerService.Settings.Port, 
                                       0, 
                                       ServerState.Instance.ServerService.Settings.Secure ) ;
                                       
            information = new StorageServerInformation ( ae, ServerState.Instance.ServerService.ServiceName, Environment.MachineName ) ;
            
            optionsAgent.Set <StorageServerInformation> ( typeof (StorageServerInformation).Name, information, new Type[0] ) ;
         }
      }
      
      void Instance_ServiceAdminChanged ( object sender, EventArgs e )
      {
         if ( null != ServerState.Instance.ServiceAdmin )
         {
            ServerState.Instance.ServiceAdmin.Error += new EventHandler<Leadtools.Dicom.Server.Admin.ErrorEventArgs> ( ServiceAdmin_Error ) ;
         }
      }

      void ServiceAdmin_Error ( object sender, Leadtools.Dicom.Server.Admin.ErrorEventArgs e )
      {
         //TODO
         MessageBox.Show ( e.Error.Message ) ;
      }
      
      internal static LoggingState GetDefaultLoggingState ( )
      {
         LoggingState state ;
         
         
         state =  new LoggingState ( ) ;
         
         state.EnableAutoSaveLog = false ;
         
         return state ;
      }

      internal static void SaveLoggingState ( )
      {
         LoggingModuleConfigurationManager loggingConfigManager = ServiceLocator.Retrieve <LoggingModuleConfigurationManager> ( ) ;
         
         if ( loggingConfigManager.IsLoaded ) 
         {
            loggingConfigManager.SetLoggingState ( ServerState.Instance.LoggingState ) ;
            
            loggingConfigManager.Save ( ) ;
         }
      }
      
      public static void InstallAddIns ( string[] addIns, string directory )
      {
         if ( !Directory.Exists ( directory ) )
         {
            Directory.CreateDirectory ( directory ) ;
         }

         foreach ( string addInDll in addIns )
         {
            string sourceFileLocation = Path.Combine ( ServerState.Instance.ServiceAdmin.BaseDirectory, addInDll ) ;
            
            if ( !File.Exists ( sourceFileLocation ) )
            {
               string baseDir = Path.Combine ( ServerState.Instance.ServiceAdmin.BaseDirectory, @"PACSAddIns" ) ;
               
               sourceFileLocation = Path.Combine ( baseDir, addInDll ) ;
            }
            
            if ( File.Exists ( sourceFileLocation ) )
            {
               File.Copy ( sourceFileLocation,
                           Path.Combine ( directory, addInDll ),
                           true ) ;
            }
         }
      }
      
      public static void LogAudit( string description )
      {
         DicomLogEntry logEntry = new DicomLogEntry ( ) ;
         
         logEntry.LogType       = LogType.Audit ;
         if (UserManager.User != null)
         {
            logEntry.ClientAETitle = UserManager.User.Name;
         }
         else
         {
            IOptionsDataAccessAgent optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();
            string lastUser = optionsAgent.Get<string>("LastUser", string.Empty);

            logEntry.ClientAETitle = lastUser;
         }
         logEntry.Description   = description ;
         
         Logger.Global.Log ( logEntry ) ;
      }
      
      public static void LogMessage( string description, LogType logType )
      {
         DicomLogEntry logEntry = new DicomLogEntry ( ) ;
         
         logEntry.LogType       = logType ;
         if (UserManager.User != null)
         {
            logEntry.ClientAETitle = UserManager.User.FriendlyName;
         }
         else
         {
            IOptionsDataAccessAgent optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();
            string lastUser = optionsAgent.Get<string>("LastUser", string.Empty);

            logEntry.ClientAETitle = lastUser;
         }
         logEntry.Description   = description ;
         
         Logger.Global.Log ( logEntry ) ;
      }
      
   }
   
}
