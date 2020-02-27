// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Medical.Gateway.CFindAddin.DataTypes;
using Leadtools.Medical.Winforms.Forwarder;
using Leadtools.Medical.Forward.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Forward.DataAccessLayer.Configuration;
using Leadtools.Logging.Medical;
using Leadtools.Logging;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn.Common;
using System.Configuration;
using Leadtools.DicomDemos;
using Leadtools.Dicom.AddIn.Interfaces;
using System.Diagnostics;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.AeManagement.DataAccessLayer;
using Leadtools.Dicom.Scu.Common;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
#endif

namespace Leadtools.Medical.Gateway
{
   public class GatewaySession : ModuleInit
   {
      private static int _Timeout;

      public static int Timeout
      {
         get
         {
            return _Timeout;
         }
      }

      public static string ServiceDirectory
      {
         get;
         set;
      }

      public static string ServiceName
      {
         get;
         set;
      }

      private static DicomServer __Server;
      public static DicomServer Server
      {
         get
         {
            return __Server;
         }
         set
         {
            __Server = value;
         }
      }

      private static IDicomSecurity _dicomSecurityAgent = null;
      public static IDicomSecurityCiphers _dicomSecurityCiphersAgent;
      public static DicomOpenSslContextCreationSettings _openSslOptions = null;
      public static List<DicomTlsCipherSuiteType> _cipherSuiteList = null;

      public static IDicomSecurity DicomSecurityAgent
      {
         get
         {
            return _dicomSecurityAgent;
         }
      }

      private static IAeManagementDataAccessAgent _aeManagementAgent = null;
      
      public static IAeManagementDataAccessAgent AeManagementAgent
      {
         get
         {
            if (_aeManagementAgent == null)
            {
               if (DataAccessServices.IsDataAccessServiceRegistered<IAeManagementDataAccessAgent>())
               {
                  _aeManagementAgent = DataAccessServices.GetDataAccessService<IAeManagementDataAccessAgent>();
               }
            }
            return _aeManagementAgent;
         }
      }

      public static bool IsDicomSecurityAvailable()
      {
         return ServiceLocator.IsRegistered<IDicomSecurity>();
      }

      public static void SetCiphers(DicomNet dicomNet)
      {
         if (_dicomSecurityCiphersAgent == null)
            return;

         int index = 0;
         foreach (DicomTlsCipherSuiteType cipher in _dicomSecurityCiphersAgent.CipherSuiteList)
         {
            dicomNet.SetTlsCipherSuiteByIndex(index, cipher);
            index++;
         }
      }

      public static void SetSecurityCertificates(DicomNet dicomNet)
      {
         if (_dicomSecurityAgent == null)
            return;

         dicomNet.SetTlsClientCertificate(
                                _dicomSecurityAgent.CertificateFileName,
                                _dicomSecurityAgent.CertificateType,
                                _dicomSecurityAgent.KeyFileName.Length > 0 ? _dicomSecurityAgent.KeyFileName : null);
      }

      public static void InitializeDicomSecurity(bool forceInitialize)
      {
         if ((_dicomSecurityAgent == null) || (forceInitialize))
         {
            if (ServiceLocator.IsRegistered<IDicomSecurity>())
            {
               _dicomSecurityAgent = ServiceLocator.Retrieve<IDicomSecurity>();
            }
         }

         if ((_dicomSecurityCiphersAgent == null) || (forceInitialize))
         {
            if (ServiceLocator.IsRegistered<IDicomSecurityCiphers>())
            {
               _dicomSecurityCiphersAgent = ServiceLocator.Retrieve<IDicomSecurityCiphers>();
            }
         }

         if (_cipherSuiteList == null || (forceInitialize))
         {
            if (_dicomSecurityCiphersAgent != null)
            {
               _cipherSuiteList = _dicomSecurityCiphersAgent.CipherSuiteList;
            }
         }

         if ((_openSslOptions == null) || (forceInitialize))
         {
            if (_dicomSecurityAgent != null)
            {
               _openSslOptions =
                  new DicomOpenSslContextCreationSettings(
                     _dicomSecurityAgent.SslMethodType,
                     _dicomSecurityAgent.CertificationAuthoritiesFileName,
                     _dicomSecurityAgent.VerificationFlags,
                     _dicomSecurityAgent.MaximumVerificationDepth,
                     _dicomSecurityAgent.Options);
            }
         }
      }

      public override void Load ( string serviceDirectory, string displayName )
      {
         __Server = ServiceLocator.Retrieve <DicomServer> ( ) ;

         ServiceDirectory = serviceDirectory;         
         ServiceName = __Server.Name;

         __Server.ServerSettingsChanged += new EventHandler(__Server_ServerSettingsChanged);
         _Timeout = __Server.ClientTimeout <= 0 ? 30 : __Server.ClientTimeout;
         
         __Settings = AdvancedSettings.Open ( ServiceDirectory ) ;
         CheckLicense();
      }

      void __Server_ServerSettingsChanged(object sender, EventArgs e)
      {
         _Timeout = __Server.ClientTimeout <= 0 ? 30 : __Server.ClientTimeout;
      }

      private void RegisterForwardService ( )
      {
         ForwardOptions forwardOptions = __Settings.GetAddInCustomData<ForwardOptions>(ForwardManagerPresenter._addinName, "ForwardOptions");

         if (forwardOptions == null)
         {
            forwardOptions = new ForwardOptions();
         }
         
         if ( null != forwardOptions ) 
         {
            ServiceLocator.Register <ForwardOptions> ( forwardOptions ) ;
         }
      }
      
      private GatewayServer GetGatewayServer ( )
      {
         GatewayServer gateway;
         
         
         gateway = __Settings.GetAddInCustomData <GatewayServer> ( this.GetType ( ).Name, typeof(GatewayServer).Name ) ;
         
         if ( gateway == null ) 
         {
            DicomServer server = __Server ;
            
            if ( null != server ) 
            {
               gateway = new GatewayServer ( ) ;
               
               
               gateway.Server           = new AeInfo ( ) ;
               gateway.ServiceName      = server.Name ;
               gateway.Server.AETitle   = server.AETitle ;
               gateway.Server.Address = server.HostAddress ;
               gateway.Server.Port      = server.HostPort ;
            }
         }
         
         return gateway ;
      }
      
      public override void AddServices ( )
      {
         Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(ServiceDirectory);
         DicomServer server = ServiceLocator.Retrieve<DicomServer>();
         string serviceName = server.Name;

         if ( !DataAccessServices.IsDataAccessServiceRegistered <IForwardDataAccessAgent> ( ) )
         {
            IForwardDataAccessAgent dataAccess = DataAccessFactory.GetInstance(new ForwardDataAccessConfigurationView(configuration, null, serviceName)).CreateDataAccessAgent<IForwardDataAccessAgent>();
            
            DataAccessServices.RegisterDataAccessService <IForwardDataAccessAgent> ( dataAccess ) ;
         }

         RegisterGatewayServer ( ) ;
         
         RegisterForwardService ( ) ;
         
         SettingsChangedNotifier settingsChanged ;
         
         if ( !ServiceLocator.IsRegistered <SettingsChangedNotifier> ( ) )
         {
            settingsChanged = new SettingsChangedNotifier ( __Settings ) ;
            
            ServiceLocator.Register<SettingsChangedNotifier> ( settingsChanged ) ;
         }
         else
         {
            settingsChanged = ServiceLocator.Retrieve<SettingsChangedNotifier> (  ) ;
         }

         settingsChanged.SettingsChanged += new EventHandler(settingsChanged_SettingsChanged);
         
         settingsChanged.Enabled = true ;
      }

      private void RegisterGatewayServer()
      {
         GatewayServer gateway = GetGatewayServer ( ) ;
         
         if ( gateway == null ) 
         {
            return ;
         }
         
         GatewayServersManager serverManager = new GatewayServersManager ( gateway ) ;
         
         if ( serverManager != null ) 
         {
            AeInfo remote = serverManager.GetRemoteServer();

            if (remote != null)
            {
               StorageServerInformation info = GetStorageServerInfo();

               if (info != null)
               {
                  if (remote.Address == info.DicomServer.IPAddress &&
                     remote.Port == info.DicomServer.Port)
                  {
                     DicomServer server = ServiceLocator.Retrieve<DicomServer>();

                     GatewaySession.Log(string.Empty, string.Empty, -1, DicomCommandType.Undefined, LogType.Error, MessageDirection.None, null,
                                        "Gateway - Remote server cannot be the same as primary server.  Gateway [" + server.AETitle +"] not available.");
                     return;
                  }
               }
            }
            ServiceLocator.Register <GatewayServersManager> ( serverManager ) ;
         }
      }

      private StorageServerInformation GetStorageServerInfo()
      {
         IOptionsDataAccessAgent optionsAgent;
         StorageServerInformation serverInfo = null;

         optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();
         if (optionsAgent != null)
         {
            string name = typeof(StorageServerInformation).Name;

            if (optionsAgent.OptionExits(name))
            {
               serverInfo = optionsAgent.Get<StorageServerInformation>(name, null, new Type[0]);
            }
         }

         return serverInfo;
      }

      void settingsChanged_SettingsChanged(object sender, EventArgs e)
      {
         SettingsChangedNotifier settingsChanged = (SettingsChangedNotifier) sender ;
         
         bool currentStatus = settingsChanged.Enabled ;
         
         settingsChanged.Enabled = false ;
         
         try
         {
            // Reinitialize the dicom security settings
            InitializeDicomSecurity(true);

            __Settings.RefreshSettings ( ) ;
            
            RegisterGatewayServer ( ) ;
            RegisterForwardService ( ) ; 
         }
         finally
         {
            settingsChanged.Enabled = currentStatus ;
         }
      }
      
      
      public static void Log 
      ( 
         DicomNet client,
         DicomCommandType command, 
         LogType logType, 
         MessageDirection direction, 
         DicomDataSet dataSet,
         string description
      ) 
      {
         Log ( client.IsAssociated ( ) ? client.Association.Calling : string.Empty,
               client.HostAddress,
               client.HostPort,
               command,
               logType,
               direction,
               dataSet,
               description ) ;
      }     
      
      public static void Log 
      ( 
         string clientAe, 
         string clientIp, 
         int clientPort, 
         DicomCommandType command, 
         LogType logType, 
         MessageDirection direction, 
         DicomDataSet dataSet,
         string description
      )
      {
         if ( __Server != null ) 
         {
            Logger.Global.Log ( __Server.AETitle, __Server.HostAddress, __Server.HostPort, clientAe, clientIp, clientPort, command, DateTime.Now, logType, direction, description, dataSet, null ) ;
         }
      }

      public static void Log(LogType logType,string description)
      {
         if (__Server != null)
         {
            Logger.Global.Log(__Server.AETitle, __Server.HostAddress, __Server.HostPort, string.Empty, string.Empty, -1, DicomCommandType.Undefined, DateTime.Now, logType, MessageDirection.None, description, null, null);
         }
      }

      private void CheckLicense()
      {
         if (ServiceLocator.IsRegistered<ILicense>())
         {
            if (_License != null)
            {
               _License.LicenseChanged -= OnLicenseChanged;
            }

            _License = ServiceLocator.Retrieve<ILicense>();
            _License.LicenseChanged += new EventHandler(OnLicenseChanged);

            if (_License.IsValid() && _License.IsFeatureValid(ServerFeatures.Gateway))
            {
               if (!_License.IsFeatureEvaluation(ServerFeatures.Gateway) || (_License.IsFeatureEvaluation(ServerFeatures.Gateway) &&
                  !_License.IsFeatureExpired(ServerFeatures.Gateway)))
               {
                  _HasGetwayLicense = true;                  
               }
               else
               {
                  Log(LogType.Error, "License for Gateway has expired");
               }
            }
            else
            {
               Log(LogType.Error, "Valid license for gateway feature not found");
            }
         }
      }

      void OnLicenseChanged(object sender, EventArgs e)
      {
         CheckLicense();
      }
      
      private AdvancedSettings      __Settings { get ; set ; } 

      private static ILicense _License;

      private static bool _HasGetwayLicense = false;

      public static bool HasGetwayLicense
      {
         get { return GatewaySession._HasGetwayLicense; }
         set { GatewaySession._HasGetwayLicense = value; }
      }
   }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
   public class GatewayServerMessage : IProcessServiceMessage
   {

      #region IProcessServiceMessage Members

      public bool CanProcess(string MessageId)
      {
         return (
                 MessageId == MessageNames.IsAddinHealthy
                 );
      }

      private string _assemblyName = string.Empty;
      public string AssemblyName
      {
         get
         {
            if (string.IsNullOrEmpty(_assemblyName))
            {
               System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
               if (assembly != null)
               {
                  _assemblyName = assembly.ManifestModule.Name;
               }
            }
            return _assemblyName;
         }
      }

      public static T GetAgent<T>(System.Configuration.Configuration configuration, DataAccessConfigurationView view )
      {
         T agent;

         if (!DataAccessServices.IsDataAccessServiceRegistered<T>())
         {
            agent = DataAccessFactory.GetInstance(view).CreateDataAccessAgent<T>();
            DataAccessServices.RegisterDataAccessService<T>(agent);
         }
         else
         {
            agent = DataAccessServices.GetDataAccessService<T>();
         }
         return agent;
      }

      public bool CanAccessDatabase(out string error)
      {
         error = string.Empty;
         bool ret = false;
         try
         {
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsAddinsConfiguration(GatewaySession.ServiceDirectory);

            IForwardDataAccessAgent forwardAgent = GetAgent<IForwardDataAccessAgent>(configuration, new ForwardDataAccessConfigurationView(configuration, null, GatewaySession.ServiceName));
            IOptionsDataAccessAgent optionsAgent = GetAgent<IOptionsDataAccessAgent>(configuration, new OptionsDataAccessConfigurationView(configuration, null, GatewaySession.ServiceName));

            bool bContinue = true;
            if (forwardAgent == null)
            {
               error = string.Format("{0} {1}", AssemblyName, "Cannot create IForwardDataAccessAgent");
               bContinue = false;
            }

            if (bContinue)
            {
               if (optionsAgent == null)
               {
                  error = string.Format("{0} {1}", AssemblyName, "Cannot create IOptionsDataAccessAgent");
                  bContinue = false;
               }
            }

            if (bContinue)
            {
               forwardAgent.IsForwarded("notUsed");
               optionsAgent.GetDefaultOptions();
            }
         }
         catch (Exception e)
         {
            error = string.Format("{0} {1}", AssemblyName, e.Message);
         }

         ret = string.IsNullOrEmpty(error);
         return ret;
      }

      public ServiceMessage Process(ServiceMessage Message)
      {
         ServiceMessage serviceMessage = null;
         switch (Message.Message)
         {
            case MessageNames.IsAddinHealthy:
               serviceMessage = new ServiceMessage();
               string error;
               serviceMessage.Message = Message.Message;
               serviceMessage.Success = CanAccessDatabase(out error);
               serviceMessage.Error = error;
               break;
         }
         return serviceMessage;
      }

      #endregion
   }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_VERIFY_ADDINS) || (LEADTOOLS_V19_OR_LATER)
}
