// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Http;

using Microsoft.Practices.Unity;

using Leadtools.DataAccessLayers;
using Leadtools.Dicom;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using Leadtools.Medical.ExternalStore.DataAccessLayer.Configuration;
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
using Leadtools.Medical.WebViewer.Common;
using Leadtools.Medical.WebViewer.Controllers;
using Leadtools.Medical.WebViewer.Dependency;
using Leadtools.Medical.WebViewer.Errors;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer.Configuration;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.WebViewer.PatientAccessRights.DataAccessAgent;
using Leadtools.Medical.WebViewer.Services;
using Leadtools.Medical.WebViewer.Services.Implementation;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.DataAccessLayer.Configuration;
using System.Web.SessionState;
using System.Threading;
using System.Net;
using System.Diagnostics;
using System.Linq;

namespace Leadtools.Medical.WebViewer
{
   public class WebApiApplication : System.Web.HttpApplication
   {
      private static Exception AppDomainException = null;

      protected void Application_End(object sender, EventArgs e)
      {
         foreach (var process in Process.GetProcessesByName("Leadtools.ProxyServer3D"))
         {
            try
            {
               process.Kill();
            }
            catch
            {
            }
         }
      }

      protected void Application_BeginRequest(object sender, EventArgs e)
      {
         if (AppDomainException != null)
         {
            HandleError(AppDomainException);
            HttpRuntime.UnloadAppDomain();
            Response.End();
         }
      }

      void HandleError(Exception exception)
      {
         Response.Redirect("~/ConfigFirst.html");
      }

      //called for each instance
      //public override void Init()
      //{
      //   base.Init();         
      //}

      protected void Application_PostAuthorizeRequest()
      {
         HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Disabled);
      }

      //called once for the lifetime of the app domain
      protected void Application_Start()
      {
         AppDomainException = null;

         GlobalConfiguration.Configure(WebApiConfig.Register);

         //allow xml serialization
         //GlobalConfiguration.Configuration.Formatters.XmlFormatter.UseXmlSerializer = true;

         // ServicePointManager setup
         ServicePointManager.UseNagleAlgorithm = false;
         ServicePointManager.Expect100Continue = false;
         ServicePointManager.DefaultConnectionLimit = int.MaxValue;
         ServicePointManager.EnableDnsRoundRobin = true;
         //ServicePointManager.ReusePort = true;

         try
         {
            //initialize
            SupportLock.SetLicense();
            DicomEngine.Startup();
            DicomNet.Startup();

            //Unity dependency injection container
            var unity = new UnityContainer();

            //register types

            //controllers that should be injectable
            unity.RegisterType<AuthController>();
            unity.RegisterType<AuditController>();
            unity.RegisterType<TemplateController>();
            unity.RegisterType<StoreController>();
            unity.RegisterType<PatientController>();
            unity.RegisterType<PatientAccessRightsController>();
            unity.RegisterType<PACSRetrieveController>();
            unity.RegisterType<PacsQueryController>();
            unity.RegisterType<OptionsController>();
            unity.RegisterType<MonitorCalibrationController>();
            unity.RegisterType<ExportController>();
            unity.RegisterType<RetrieveController>();
            unity.RegisterType<QueryController>();
            unity.RegisterType<ThreeDController>();
            unity.RegisterType<AutoController>();
            
            //injectable types
            unity.RegisterType<AddinsFactory>();
            
            //injectable types/base
            unity.RegisterType<IAuthHandler, AuthHandler>();
            unity.RegisterType<IAuditHandler, AuditHandler>();
            unity.RegisterType<ITemplateHandler, TemplateHandler>();
            unity.RegisterType<IStoreHandler, StoreHandler>();
            unity.RegisterType<IPatientHandler, PatientHandler>();
            unity.RegisterType<IPatientAccessRightsHandler, PatientAccessRightsHandler>();
                        
            unity.RegisterType<IOptionsHandler, OptionsHandler>();
            unity.RegisterType<IMonitorCalibrationHandler, MonitorCalibrationHandler>();
            //unity.RegisterType<IStreamExportHandler, StreamExportHandler>();
            unity.RegisterType<IHashingProvider, HashingProvider>();
            unity.RegisterType<IExportHandler, ExportHandler>();

            unity.RegisterType<IRetrieveHandler, RetrieveHandler>("local");
            unity.RegisterType<IRetrieveHandler, WadoRetrieveHandler>("wado");

            unity.RegisterType<IQueryHandler, QueryHandler>("local");
            unity.RegisterType<IQueryHandler, WadoQueryHandler>("wado");
            unity.RegisterType<IThreeDHandler, ThreeDHandler>();

            unity.RegisterType<IPacsQueryHandler, PacsQueryHandler>("pacsquery");
            unity.RegisterType<IPacsQueryHandler, WadoAsPacsQueryHandler>("wadoaspacsquery");

            unity.RegisterType<IPacsRetrieveHandler, PacsRetrieveHandler>("pacsretrieve");
            unity.RegisterType<IPacsRetrieveHandler, WadoAsPacsRetrieveHandler>("wadoaspacsretrieve");

            unity.RegisterType<IAutoHandler, AutoHandler>();

            {
               //register singletons
               CreateSingletons();

               unity.RegisterInstance<Lazy<IMessagesBus>>(_messageBus, new ExternallyControlledLifetimeManager());
               unity.RegisterInstance<Lazy<IStorageDataAccessAgent3>>(_storageAgent, new ExternallyControlledLifetimeManager());
               unity.RegisterInstance<Lazy<ILoggingDataAccessAgent>>(_loggingAgent, new ExternallyControlledLifetimeManager());
               unity.RegisterInstance<Lazy<IUserManagementDataAccessAgent4>>(_userManagementDataAccessAgent, new ExternallyControlledLifetimeManager());
               unity.RegisterInstance<Lazy<IPermissionManagementDataAccessAgent2>>(_permissionManagementDataAccessAgent, new ExternallyControlledLifetimeManager());
               unity.RegisterInstance<Lazy<IOptionsDataAccessAgent>>(_optionsDataAccessAgent, new ExternallyControlledLifetimeManager());
               unity.RegisterInstance<Lazy<IPatientRightsDataAccessAgent>>(_patientRightsDataAccess, new ExternallyControlledLifetimeManager());
               unity.RegisterInstance<Lazy<IDownloadJobsDataAccessAgent>>(_downloadJobsDataAccessAgent, new ExternallyControlledLifetimeManager());
               unity.RegisterInstance<Lazy<IAuthorizedStorageDataAccessAgent2>>(_authorizedStorageDataAccessAgent, new ExternallyControlledLifetimeManager());
               unity.RegisterInstance<Lazy<IMonitorCalibrationDataAccessAgent>>(_monitorCalibrationDataAccessAgent, new ExternallyControlledLifetimeManager());
               unity.RegisterInstance<Lazy<ITemplateDataAccessAgent>>(_templateDataAccessAgent, new ExternallyControlledLifetimeManager());
               unity.RegisterInstance<Lazy<IExternalStoreDataAccessAgent>>(_externalStoreAgent, new ExternallyControlledLifetimeManager());
               unity.RegisterInstance<Lazy<Leadtools.Dicom.Imaging.IDataCacheProvider>>(_dataCache, new ExternallyControlledLifetimeManager());
               unity.RegisterInstance<Lazy<ConnectionSettings>>(_connectionSettings, new ExternallyControlledLifetimeManager());
            }

            //set default dependency resolver to Unity (with the wrapper)
            GlobalConfiguration.Configuration.DependencyResolver = new IoCContainer(unity);

            //caching workers
            LTCachingCtrl.QeueuWorkers();
         }
         catch (ServiceSetupException ex)
         {
            AppDomainException = ex;
            //handle on first request
         }
         catch (Exception)
         {
            HttpRuntime.UnloadAppDomain();
            throw;
         }
      }

      //singletons 
      private Lazy<IMessagesBus> _messageBus = null;
      private Lazy<IStorageDataAccessAgent3> _storageAgent = null;
      private Lazy<ILoggingDataAccessAgent> _loggingAgent = null;
      private Lazy<IUserManagementDataAccessAgent4> _userManagementDataAccessAgent = null;
      private Lazy<IPermissionManagementDataAccessAgent2> _permissionManagementDataAccessAgent = null;
      private Lazy<IOptionsDataAccessAgent> _optionsDataAccessAgent = null;
      private Lazy<IPatientRightsDataAccessAgent> _patientRightsDataAccess;
      private Lazy<IDownloadJobsDataAccessAgent> _downloadJobsDataAccessAgent;
      private Lazy<IAuthorizedStorageDataAccessAgent2> _authorizedStorageDataAccessAgent;
      private Lazy<IMonitorCalibrationDataAccessAgent> _monitorCalibrationDataAccessAgent;
      private Lazy<ITemplateDataAccessAgent> _templateDataAccessAgent;
      private Lazy<IExternalStoreDataAccessAgent> _externalStoreAgent;
      private Lazy<Leadtools.Dicom.Imaging.IDataCacheProvider> _dataCache;
      private Lazy<ConnectionSettings> _connectionSettings;

      private const string ProductNameStorageServer = "StorageServer";
      private const string ProductNameMedicalViewer = "MedicalViewer";


      static T0 createDataAccess<T1, T0>(ConnectionStringSettings cs) where T1 : new()
      {
         var view = new T1() as DataAccessConfigurationView;
         return (T0)Activator.CreateInstance(view.GetDefaultMappingProxy(null, cs.ProviderName).DataAccessType, cs.ConnectionString);
      }

      //no overhead here since all services need these objects created anyway
      private void CreateSingletons()
      {
         System.Configuration.Configuration configuration = null;
         ConnectionStringSettings cs = null;
         ConnectionStringSettings csMessageBus = null;

         try
         {
            configuration = GetGlobalPacsConfig();
            if (null == configuration)
            {
               cs = GetConnectionDefaults();
            }
            if (null == configuration && null == cs)
            {
               throw new ServiceSetupException("Missing GlobalPacs.Config path information (and/or) missing the Connection strings configurations.");
            }

            csMessageBus = GetMessageBusConnection();

            if(null==csMessageBus)
            {
               _messageBus = new Lazy<IMessagesBus>(() => new InMemoryMessagesBus());
            }
            else
            {
               _messageBus = new Lazy<IMessagesBus>(() => new RebusSqlMessagesBus(csMessageBus.ConnectionString));
            }

            _storageAgent = new Lazy<IStorageDataAccessAgent3>(() =>
            {
               if (DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent3>())
               {
                  return DataAccessServices.GetDataAccessService<IStorageDataAccessAgent3>();
               }
               else
               {
                  if (null != configuration)
                     return DataAccessFactory.GetInstance(new StorageDataAccessConfigurationView(configuration, ProductNameStorageServer, null)).CreateDataAccessAgent<IStorageDataAccessAgent3>();
                  else
                     return createDataAccess<StorageDataAccessConfigurationView, IStorageDataAccessAgent3>(cs);
               }
            });

            _loggingAgent = new Lazy<ILoggingDataAccessAgent>(() =>
            {
               if (DataAccessServices.IsDataAccessServiceRegistered<ILoggingDataAccessAgent>())
               {

                  return DataAccessServices.GetDataAccessService<ILoggingDataAccessAgent>();
               }
               else
               {
                  if (null != configuration)
                     return DataAccessFactory.GetInstance(new LoggingDataAccessConfigurationView(configuration, ProductNameStorageServer, null)).CreateDataAccessAgent<ILoggingDataAccessAgent>();
                  else
                     return createDataAccess<LoggingDataAccessConfigurationView, ILoggingDataAccessAgent>(cs);
               }
            });

            //initialize external storage (slow)
            // (07.26.2019) Update for 85943: Call ExternalStorage.Startup() here for ExternalStorage (i.e. Cloud storage)
            ExternalStorage.Startup();

            _externalStoreAgent = new Lazy<IExternalStoreDataAccessAgent>(() =>
            {

               if (DataAccessServices.IsDataAccessServiceRegistered<IExternalStoreDataAccessAgent>())
               {
                  return DataAccessServices.GetDataAccessService<IExternalStoreDataAccessAgent>();
               }
               else
               {
                  IExternalStoreDataAccessAgent externalStoreAgent;
                  if (null != configuration)
                     externalStoreAgent = DataAccessFactory.GetInstance(new ExternalStoreDataAccessConfigurationView(configuration, ProductNameStorageServer, null)).CreateDataAccessAgent<IExternalStoreDataAccessAgent>();
                  else
                     externalStoreAgent = createDataAccess<ExternalStoreDataAccessConfigurationView, IExternalStoreDataAccessAgent>(cs);
                  DataAccessServices.RegisterDataAccessService<IExternalStoreDataAccessAgent>(externalStoreAgent);
                  return externalStoreAgent;
               }
            });

            _userManagementDataAccessAgent = new Lazy<IUserManagementDataAccessAgent4>(() =>
            {
               if (null != configuration)
                  return DataAccessFactory.GetInstance(new UserManagementDataAccessConfigurationView2(configuration, ProductNameStorageServer, null)).CreateDataAccessAgent<IUserManagementDataAccessAgent4>();
               else
                  return createDataAccess<UserManagementDataAccessConfigurationView2, IUserManagementDataAccessAgent4>(cs);
            });
            _permissionManagementDataAccessAgent = new Lazy<IPermissionManagementDataAccessAgent2>(() =>
            {
               if (null != configuration)
                  return DataAccessFactory.GetInstance(new PermissionManagementDataAccessConfigurationView(configuration, ProductNameStorageServer, null)).CreateDataAccessAgent<IPermissionManagementDataAccessAgent2>();
               else
                  return createDataAccess<PermissionManagementDataAccessConfigurationView, IPermissionManagementDataAccessAgent2>(cs);
            });
            _optionsDataAccessAgent = new Lazy<IOptionsDataAccessAgent>(() =>
            {
               if (null != configuration)
                  return DataAccessFactory.GetInstance(new OptionsDataAccessConfigurationView(configuration, ProductNameMedicalViewer, null)).CreateDataAccessAgent<IOptionsDataAccessAgent>();
               else
                  return createDataAccess<OptionsDataAccessConfigurationView, IOptionsDataAccessAgent>(cs);
            });
            _patientRightsDataAccess = new Lazy<IPatientRightsDataAccessAgent>(() =>
            {
               if (null != configuration)
                  return DataAccessFactory.GetInstance(new PatientRightsDataAccessConfigurationView(configuration, ProductNameMedicalViewer, null)).CreateDataAccessAgent<IPatientRightsDataAccessAgent>();
               else
                  return createDataAccess<PatientRightsDataAccessConfigurationView, IPatientRightsDataAccessAgent>(cs);
            });
            _downloadJobsDataAccessAgent = new Lazy<IDownloadJobsDataAccessAgent>(() =>
            {
               if (null != configuration)
                  return DataAccessFactory.GetInstance(new DownloadJobsDataAccessConfigurationView(configuration, ProductNameMedicalViewer, null)).CreateDataAccessAgent<IDownloadJobsDataAccessAgent>();
               else
                  return createDataAccess<DownloadJobsDataAccessConfigurationView, IDownloadJobsDataAccessAgent>(cs);
            });
            _monitorCalibrationDataAccessAgent = new Lazy<IMonitorCalibrationDataAccessAgent>(() =>
            {
               if (null != configuration)
                  return DataAccessFactory.GetInstance(new MonitorCalibrationDataAccessConfigurationView(configuration, ProductNameMedicalViewer, null)).CreateDataAccessAgent<IMonitorCalibrationDataAccessAgent>();
               else
                  return createDataAccess<MonitorCalibrationDataAccessConfigurationView, IMonitorCalibrationDataAccessAgent>(cs);
            });
            _templateDataAccessAgent = new Lazy<ITemplateDataAccessAgent>(() =>
            {
               if (null != configuration)
                  return DataAccessFactory.GetInstance(new TemplateDataAccessConfigurationView(configuration, ProductNameMedicalViewer, null)).CreateDataAccessAgent<ITemplateDataAccessAgent>();
               else
                  return createDataAccess<TemplateDataAccessConfigurationView, ITemplateDataAccessAgent>(cs);
            });
                        
            _authorizedStorageDataAccessAgent = new Lazy<IAuthorizedStorageDataAccessAgent2>(() => new AuthorizedStorageDataAccessAgent(_storageAgent.Value, _patientRightsDataAccess.Value, _permissionManagementDataAccessAgent.Value));
            _dataCache = new Lazy<Leadtools.Dicom.Imaging.IDataCacheProvider>(() => LTCachingCtrl.CreateCache(LTCachingCtrl.CacheSettings));
            _connectionSettings = new Lazy<ConnectionSettings>();

         }
         catch
         {
            throw new ServiceSetupException("Service component not registered");
         }
      }

      static string GetPlatformPath()
      {
#if DEBUG
#if FOR_ANYCPU
         return @"Win32\Debug\";
#elif WIN64
         return @"x64\Debug\";
#else
               return @"Win32\Debug\";
#endif
#else
#if FOR_ANYCPU
               return @"Win32\";
#elif WIN64
               return @"x64\";
#else
               return @"Win32\";
#endif
#endif
      }

      static string GetPlatformPathSetup()
      {
#if FOR_ANYCPU
         return @"Win32\";
#elif WIN64
         return @"x64\";
#else
               return @"Win32\";
#endif
      }

      public static string FindGlobalPacsConfig()
      {
         var path = System.Uri.UnescapeDataString((new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath);
         var folder = Path.GetDirectoryName(path);

         var rootpath = Path.Combine(folder, @"..\..\..\..\..\..\");
         var binpath = Path.Combine(rootpath, @"Bin20\DotNet4\", GetPlatformPath());
         var binpathSetup = Path.Combine(rootpath, @"Bin\DotNet4\", GetPlatformPathSetup());
         var gpacspath = Path.Combine(binpath, @"GlobalPacs.config");
         var gpacspathsetup = Path.Combine(binpathSetup, @"GlobalPacs.config");

         if (File.Exists(gpacspathsetup))
         {
            return gpacspathsetup;
         }
         if (File.Exists(gpacspath))
         {
            return gpacspath;
         }
         return null;
      }

      public static ConnectionStringSettings GetConnectionDefaults()
      {
         var name = "default";
         var connectionStrings = ApplicationSettings.GetConnectionStrings();
         if (null != connectionStrings)
         {
            if (connectionStrings[name] != null)
            {
               return connectionStrings[name];
            }
         }
         return null; ;
      }

      public static ConnectionStringSettings GetMessageBusConnection()
      {
         var name = "messageBus";
         var connectionStrings = ApplicationSettings.GetConnectionStrings();
         if (null != connectionStrings)
         {
            return connectionStrings[name];
         }
         return null; ;
      }

      public static System.Configuration.Configuration GetGlobalPacsConfig()
      {
         var globalPacsFile = ApplicationSettings.GetSettingValue("globalConfigPath");

         if (string.IsNullOrEmpty(globalPacsFile))
         {
            globalPacsFile = FindGlobalPacsConfig();
         }

         if (string.IsNullOrEmpty(globalPacsFile))
         {
            return null;
         }

         ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
         configFile.ExeConfigFilename = globalPacsFile;
         configFile.MachineConfigFilename = globalPacsFile;

         return ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
      }

   }
}
