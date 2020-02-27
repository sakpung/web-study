// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using Leadtools.DataAccessLayers;
using Leadtools.Dicom;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Logging.DataAccessLayer;
using Leadtools.Medical.Logging.DataAccessLayer.Configuration;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Medical.UserManagementDataAccessLayer;
using Leadtools.Medical.UserManagementDataAccessLayer.Configuration;
using Leadtools.Medical.WebViewer.Addins;
using Leadtools.Medical.WebViewer.Annotations;
using Leadtools.Medical.WebViewer.Annotations.DataAccessAgent;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer.Configuration;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.WebViewer.PatientAccessRights.DataAccessAgent;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Wcf.Helper;

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.Winforms.ExternalStore;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.Medical.ExternalStore.DataAccessLayer.Configuration;
using Leadtools.Dicom.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Security;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Tasks.Common;
using System.Net;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)

namespace Leadtools.Medical.WebViewer.Wcf
{
    /// <summary>
    /// The factory class is used by the different services to create the add-ins objects that executes the functionality of the service.
    /// </summary>
    public static class AddinsFactory
    {
       static IServiceObjectsFactory _factory = null;
       static DateTime? _timeStamp = null;
       static Object _synch = new Object();

       static AddinsFactory()
       {
          _factory = new ServiceObjectsFactory();

          Startup();          
       }

       static void Startup()
       {
          try
          {
             SupportLock.Unlock();
             DicomEngine.Startup();
             DicomNet.Startup();

             //chance for any override
             ServiceUtils.RegisterInterfaces();

             LoadTimeStamp();
             //Debug.WriteLine("lt: " + (_timeStamp.HasValue? _timeStamp.ToString():"none"));
             //PACS client settings
             {                
                //the client AE/IP/port used for connecting to remote PACS for query
                _clientConnection.AETitle = ConfigurationManager.AppSettings.Get("ClientAe");
                if (string.IsNullOrEmpty(_clientConnection.AETitle))
                {
                   _clientConnection.AETitle = "LTCLIENT19";
                }
                _clientConnection.IPAddress = ConfigurationManager.AppSettings.Get("ClientIP");
                if(string.IsNullOrEmpty(_clientConnection.IPAddress))
                {
                   _clientConnection.IPAddress = ServiceUtils.GetLocalIPAddressesV4();
                }

                _clientConnection.Port = ServiceUtils.ToInt(ConfigurationManager.AppSettings.Get("ClientPort"), ServiceUtils.GetFreeIPPort());
             }

             //Storage server settings
             {
                //the path for the local storage server service, used by the store add-in to read the server configuration
                _storageServerServicePath = ConfigurationManager.AppSettings.Get("storageServerServicePath");
                _storageServerServicePath = ServiceUtils.MapConfigPath(_storageServerServicePath);

                _storageServerConnection.AETitle = ConfigurationManager.AppSettings.Get("ServerAe");
                _storageServerConnection.IPAddress = ConfigurationManager.AppSettings.Get("ServerIP");
                _storageServerConnection.Port = ServiceUtils.ToInt(ConfigurationManager.AppSettings.Get("ServerPort"), -1);

                //read default storage server dicom connection settings
                if (!string.IsNullOrEmpty(_storageServerServicePath) && 
                   (string.IsNullOrEmpty(_storageServerConnection.AETitle) ||
                   string.IsNullOrEmpty(_storageServerConnection.IPAddress) ||
                   _storageServerConnection.Port <= 0))
                {
                   try
                   {
                      var settingsFile = Path.Combine(_storageServerServicePath, "settings.xml");
                      var doc = XDocument.Load(settingsFile);
                      {
                         _storageServerConnection.Port = ServiceUtils.ToInt(doc.Descendants("Port").First().Value, -1);
                         _storageServerConnection.IPAddress = doc.Descendants("IpAddress").First().Value;
                         _storageServerConnection.AETitle = doc.Descendants("AETitle").First().Value;
                      }
                   }
                   catch
                   {
                   }
                }

                if (string.IsNullOrEmpty(_storageServerConnection.AETitle))
                {
                   _storageServerConnection.AETitle = "LTSTORAGESERVER";
                }
             }

             //read static settings
             {  
                //the path for storing the annotations files (not used anymore)
                _annotationsPath = ConfigurationManager.AppSettings.Get("AnnotationsPath");
                
                if (string.IsNullOrEmpty(_annotationsPath))
                {
                   _annotationsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Annotations");
                }
             }

             //initialize external storage
             ExternalStorage.Startup();
          }
          catch (Exception ex)
          {
             ServiceUtils.Log(ex.ToString());
             throw new ServiceException("Failed to startup: " + ex.Message, HttpStatusCode.InternalServerError);
          }

          //caching workers
          LTCachingCtrl.QeueuWorkers();
       }

       static string GetLocalConfigPathName()
       {
          var ServiceFolder = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
          return System.IO.Path.Combine(ServiceFolder, "Session.config");
       }
       public static void RefreshTimeStamp()
       {
          lock (_synch)
          {
             try
             {
                _timeStamp = DateTime.Now;

                string localConfigFile = GetLocalConfigPathName();

                File.WriteAllText(localConfigFile, _timeStamp.ToString());
             }
             catch
             {
                _timeStamp = null;
             }
          }
       }

       public static DateTime? GetTimeStamp()
       {
          lock (_synch)
          {
             DateTime? ret = null;
             
             if (_timeStamp.HasValue)
             {
                ret = _timeStamp.Value;
             }
             
             return ret;
          }
       }

       static void LoadTimeStamp()
       {
          lock (_synch)
          {
             try
             {
                _timeStamp = null;

                string localConfigFile = GetLocalConfigPathName();

                if (File.Exists(localConfigFile))
                {
                   var timestamp = File.ReadAllText(localConfigFile);
                   if (!string.IsNullOrEmpty(timestamp))
                   {
                      _timeStamp = DateTime.Parse(timestamp);
                   }
                }
             }
             catch
             {
                _timeStamp = null;
             }
          }
       }


        /// <summary>
        /// Creates the Query Add-in
        /// </summary>
        /// <returns></returns>
        public static IQueryAddin CreateQueryAddin()
        {
#if LEADTOOLS_V19_OR_LATER
            return new DatabaseQueryAddin(AuthorizedStorageDataAccessAgent, OptionsDataAccessAgent, PermissionManagementDataAccessAgent, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, StorageAgent, DataCache);
#else
            return new DatabaseQueryAddin(AuthorizedStorageDataAccessAgent, OptionsDataAccessAgent);
#endif
        }

        /// <summary>
        /// Creates the authentication add-in
        /// </summary>
        /// <returns></returns>
        public static IAuthenticationAddin CreateAuthenticationAddin()
        {
            return new AuthenticationAddin(UserManagementDataAccessAgent, PermissionManagementDataAccessAgent, OptionsDataAccessAgent, LoggingAgent);
        }

        /// <summary>
        /// Creates the session-authentication add-in
        /// </summary>
        /// <returns></returns>
        public static ISessionAuthenticationAddin CreateSessionAuthenticationAddin()
        {
           return new SessionAuthenticationAddin();
        }

        /// <summary>
        /// Creates the PACS Query Add-in (to query remote PACS)
        /// </summary>
        /// <returns></returns>
        public static IPACSQueryAddin CreatePacsQueryAddin()
        {
            return new PACSQueryAddin(ClientConnection);
        }

        /// <summary>
        /// Creates the PACS download/Move add-in (Move DICOM datasets from remote PACS into local PACS)
        /// </summary>
        /// <returns></returns>
        public static IPacsDownloadAddin CreatePacsDownloadAddin()
        {
           return new DownloadAddin(ClientConnection, StorageServerConnection, DownloadJobsDataAccessAgent, AuthorizedStorageDataAccessAgent);
        }

        /// <summary>
        /// Creates the Object Retrieve Add-in that returns the DICOM instance information/images
        /// </summary>
        /// <returns></returns>
        public static IObjectRetrieveAddin CreateObjectRetrieveAddin()
        {
#if (!LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) && (!LEADTOOLS_V19_OR_LATER)
            return new ObjectRetrieveAddin(StorageAgent);
#else
            return new ObjectRetrieveAddin(StorageAgent, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, OptionsDataAccessAgent, PermissionManagementDataAccessAgent, AuthorizedStorageDataAccessAgent, DataCache);
#endif // #if (!LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) && (!LEADTOOLS_V19_OR_LATER)
        }

        /// <summary>
        /// Creates the Patient access rights Add-in
        /// </summary>
        /// <returns></returns>
        public static IPatientAccessRightsAddin CreatePatientAccessRightsAddin()
        {
            return new PatientAccessRightsAddin(PatientRightsDataAccess);
        }

        /// <summary>
        /// Creates the store Add-in (store into local server)
        /// </summary>
        /// <returns></returns>
        public static IStoreAddin CreateStoreAddin()
        {
#if !LEADTOOLS_V19_OR_LATER
            return new StoreAddin(StorageAgent, LoggingAgent, CreateQueryAddin(), CreateObjectRetrieveAddin(), StorageServerConnection.AETitle, StorageServerServicePath);
#else
           return new StoreAddin(StorageAgent, LoggingAgent, CreateQueryAddin(), CreateObjectRetrieveAddin(), StorageServerConnection.AETitle, StorageServerServicePath, PermissionManagementDataAccessAgent, AuthorizedStorageDataAccessAgent);
#endif
        }
      

        public static IOptionsAddin CreateOptionsAddin()
        {
            return new OptionsAddin(OptionsDataAccessAgent, LoggingAgent);
        }

        public static IAuditLogAddin CreateAuditLogAddin()
        {
            return new AuditLogAddin(LoggingAgent);
        }

        public static IExportAddin CreateExportAddin()
        {
#if !LEADTOOLS_V19_OR_LATER
            IStoreAddin storeAddin = new StoreAddin(StorageAgent, LoggingAgent, CreateQueryAddin(), CreateObjectRetrieveAddin(), StorageServerConnection.AETitle, StorageServerServicePath);
#else
           IStoreAddin storeAddin = new StoreAddin(StorageAgent, LoggingAgent, CreateQueryAddin(), CreateObjectRetrieveAddin(), StorageServerConnection.AETitle, StorageServerServicePath, PermissionManagementDataAccessAgent, AuthorizedStorageDataAccessAgent);
#endif

            return new ExportAddin(StorageAgent, AuthorizedStorageDataAccessAgent, ExternalStoreAgent, LoggingAgent, StorageServerServicePath, storeAddin, OptionsDataAccessAgent, PermissionManagementDataAccessAgent, DataCache);
        }

        public static IMonitorCalibrationAddin CreateMonitorCalibrationAddin()
        {           
            return new MonitorCalibrationAddin(MonitorCalibrationDataAccessAgent);
        }
#if LEADTOOLS_V19_OR_LATER
        public static ITemplateAddin CreateTemplateAddin()
        {
            return new TemplateAddin(TemplateDataAccessAgent);
        }

        public static Leadtools.Dicom.Imaging.DiskDataCacheStorage CacheDiskStorage
        {
           get
           {
              return _factory.Get<Leadtools.Dicom.Imaging.DiskDataCacheStorage>(() =>
              {
                 return LTCachingCtrl.CreateCacheStorage(LTCachingCtrl.CacheSettings);
              });
           }
        }
#endif      
        private static System.Configuration.Configuration GlobalPacsConfig
        {
           get
           {
              return _factory.Get<System.Configuration.Configuration>(() =>
              {
                 var config = ServiceUtils.GetGlobalPacsConfig();
                 //log path name
                 ServiceUtils.Log(config.FilePath);
                 return config;
              });
           }
        }

        private static IStorageDataAccessAgent3 StorageAgent
        {
           get
           {
              return _factory.Get<IStorageDataAccessAgent3>(() =>
              {
                 if (DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent3>())
                 {
                    return DataAccessServices.GetDataAccessService<IStorageDataAccessAgent3>();
                 }
                 else
                 {
                    return DataAccessFactory.GetInstance(new StorageDataAccessConfigurationView(GlobalPacsConfig, ServiceUtils.ProductNameStorageServer, null)).CreateDataAccessAgent<IStorageDataAccessAgent3>();
                 }
              });
           }
        }

        private static IPatientRightsDataAccessAgent PatientRightsDataAccess
        {
           get
           {
              return _factory.Get<IPatientRightsDataAccessAgent>(() =>
              {
                 return DataAccessFactory.GetInstance(new PatientRightsDataAccessConfigurationView(GlobalPacsConfig, ServiceUtils.ProductNameMedicalViewer, null)).CreateDataAccessAgent<IPatientRightsDataAccessAgent>();
              });
           }
        }

       //expensive object
        private static IUserManagementDataAccessAgent4 UserManagementDataAccessAgent
        {
           get
           {
              return _factory.Get<IUserManagementDataAccessAgent4>(() =>
              {
                 return DataAccessFactory.GetInstance(new UserManagementDataAccessConfigurationView2(GlobalPacsConfig, ServiceUtils.ProductNameStorageServer, null)).CreateDataAccessAgent<IUserManagementDataAccessAgent4>();
              });
           }
        }

        private static IPermissionManagementDataAccessAgent2 PermissionManagementDataAccessAgent
        {
           get
           {
              return _factory.Get<IPermissionManagementDataAccessAgent2>(() =>
              {
                 return DataAccessFactory.GetInstance(new PermissionManagementDataAccessConfigurationView(GlobalPacsConfig, ServiceUtils.ProductNameStorageServer, null)).CreateDataAccessAgent<IPermissionManagementDataAccessAgent2>();
              });
           }
        }

        private static IDownloadJobsDataAccessAgent DownloadJobsDataAccessAgent
        {
           get
           {
              return _factory.Get<IDownloadJobsDataAccessAgent>(() =>
              {
                 return DataAccessFactory.GetInstance(new DownloadJobsDataAccessConfigurationView(GlobalPacsConfig, ServiceUtils.ProductNameMedicalViewer, null)).CreateDataAccessAgent<IDownloadJobsDataAccessAgent>();
              });
           }
        }
      
        private static IAuthorizedStorageDataAccessAgent2 AuthorizedStorageDataAccessAgent
        {
           get
           {
              return _factory.Get<IAuthorizedStorageDataAccessAgent2>(() =>
              {
                 return new AuthorizedStorageDataAccessAgent(StorageAgent, PatientRightsDataAccess, PermissionManagementDataAccessAgent);
              });
           }
        }

        private static IOptionsDataAccessAgent OptionsDataAccessAgent
        {
           get
           {
              return _factory.Get<IOptionsDataAccessAgent>(() =>
              {
                 return DataAccessFactory.GetInstance(new OptionsDataAccessConfigurationView(GlobalPacsConfig, ServiceUtils.ProductNameMedicalViewer, null)).CreateDataAccessAgent<IOptionsDataAccessAgent>();
              });
           }
        }


        private static IMonitorCalibrationDataAccessAgent MonitorCalibrationDataAccessAgent
        {
           get
           {
              return _factory.Get<IMonitorCalibrationDataAccessAgent>(() =>
              {
                 return DataAccessFactory.GetInstance(new MonitorCalibrationDataAccessConfigurationView(GlobalPacsConfig, ServiceUtils.ProductNameMedicalViewer, null)).CreateDataAccessAgent<IMonitorCalibrationDataAccessAgent>();
              });
           }
        }

        private static ITemplateDataAccessAgent TemplateDataAccessAgent
        {
           get
           {
              return _factory.Get<ITemplateDataAccessAgent>(() =>
              {
                 return DataAccessFactory.GetInstance(new TemplateDataAccessConfigurationView(GlobalPacsConfig, ServiceUtils.ProductNameMedicalViewer, null)).CreateDataAccessAgent<ITemplateDataAccessAgent>();
              });
           }
        }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
        private static Lazy<IExternalStoreDataAccessAgent> ExternalStoreAgent
        {
           get
           {
            return new Lazy<IExternalStoreDataAccessAgent>(() =>
             _factory.Get<IExternalStoreDataAccessAgent>(() =>
            {
               if (DataAccessServices.IsDataAccessServiceRegistered<IExternalStoreDataAccessAgent>())
               {
                  return DataAccessServices.GetDataAccessService<IExternalStoreDataAccessAgent>();
               }
               else
               {
                  var externalStoreAgent = DataAccessFactory.GetInstance(new ExternalStoreDataAccessConfigurationView(GlobalPacsConfig, ServiceUtils.ProductNameStorageServer, null)).CreateDataAccessAgent<IExternalStoreDataAccessAgent>();
                  DataAccessServices.RegisterDataAccessService<IExternalStoreDataAccessAgent>(externalStoreAgent);
                  return externalStoreAgent;
               }
            }));
           }
        }

       //expensive object
        private static ILoggingDataAccessAgent LoggingAgent
        {
           get
           {
              return _factory.Get<ILoggingDataAccessAgent>(() =>
              {
                 if (DataAccessServices.IsDataAccessServiceRegistered<ILoggingDataAccessAgent>())
                 {
                    return DataAccessServices.GetDataAccessService<ILoggingDataAccessAgent>();
                 }
                 else
                 {
                    var loggingAgent = DataAccessFactory.GetInstance(new LoggingDataAccessConfigurationView(GlobalPacsConfig, ServiceUtils.ProductNameStorageServer, null)).CreateDataAccessAgent<ILoggingDataAccessAgent>();
                    DataAccessServices.RegisterDataAccessService<ILoggingDataAccessAgent>(loggingAgent);
                    return loggingAgent;
                 }
              });
           }
        }
#endif // #if (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V19_OR_LATER)
        private static Leadtools.Dicom.Imaging.IDataCacheProvider DataCache
        {
           get
           {
              return _factory.Get<Leadtools.Dicom.Imaging.IDataCacheProvider>(() =>
              {
                 return LTCachingCtrl.CreateCache(LTCachingCtrl.CacheSettings);
              });
           }
        }

        static PACSConnection _storageServerConnection = new PACSConnection();
        static PACSConnection _clientConnection = new PACSConnection();
        static string _annotationsPath = null;
        static string _storageServerServicePath = null;

        public static PACSConnection StorageServerConnection { get { return _storageServerConnection; } }
        public static PACSConnection ClientConnection { get { return _clientConnection; } }
        private static string AnnotationsPath { get { return _annotationsPath; } }
        private static string StorageServerServicePath { get { return _storageServerServicePath; } }      
    }
}
