// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Linq;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.DicomDemos;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using System.Configuration;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;

using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer.Configuration;
using Leadtools.Medical.WebViewer.PatientAccessRights.DataAccessAgent;
using Leadtools.Medical.WebViewer.Annotations.DataAccessAgent;
using System.IO;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.DataAccessLayers;
#endif 

namespace WebViewerConfiguration
{
   class StorageServerHelper
   {
      /// <summary>
      /// Checks if the Storage server DB is configured/created
      /// </summary>
      /// <returns></returns>
      public static bool IsDatabaseConfigured ( ) 
      {
         string missingDb ;
         
         return GlobalPacsUpdater.IsDbComponentsConfigured ( new string []{DicomDemoSettingsManager.ProductNameStorageServer}, out missingDb ) ;
      }
      
      public static bool IsDatabaseUpToDate ( ) 
      {
         return GlobalPacsUpdater.IsProductDatabaseUpTodate ( DicomDemoSettingsManager.ProductNameStorageServer) ;
      }

      public static bool IsSqlCe()
      {
         ConnectionStringSettings settings = GetConnectionSettings ( ) ;
         
         if ( null == settings || settings.ProviderName.ToLower ( ).Contains ( "sqlserverce" ) )
         {
            return true ;
         }
         
         return false ;
      }
      
      public static StorageServerInformation GetServerInformation ( ) 
      {
         IOptionsDataAccessAgent  optionsAgent ;
         

         optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent> ( ) ;

         return optionsAgent.Get <StorageServerInformation> ( typeof (StorageServerInformation).Name, null, new Type[0] ) ;
      }

      public static ConnectionStringSettings GetConnectionSettings()
      {
         Configuration configPacs = DicomDemoSettingsManager.GetGlobalPacsConfiguration();
         
         return GetConnectionString(configPacs, new StorageDataAccessConfigurationView(configPacs, DicomDemoSettingsManager.ProductNameStorageServer, null).DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameStorageServer );
      }
      
      public static bool IsDatabaseUpgraded()
      {
         ConnectionStringSettings storage;


         storage = GetConnectionSettings ( ) ;

         return WebViewerDataAccess.IsUpgraded ( storage ) ;
      }

      private static ConnectionStringSettings GetConnectionString
      (
         Configuration pacsConfig,
         string dataAccessSectionName,
         string productName
      )
      {
         DataAccessSettings settings = null;
         ConnectionStringSettings connectionStringSettings = null;
         try
         {
            settings = pacsConfig.GetSection(dataAccessSectionName) as DataAccessSettings;
            if (settings != null)
            {
               bool found = false;
               string name = string.Empty;
               foreach (ConnectionElement connectionElement in settings.Connections)
               {
                  if (connectionElement.ProductName == productName )
                  {
                     name = connectionElement.ConnectionName;
                     found = true;
                     break;
                  }
               }

               if (found && !string.IsNullOrEmpty(name))
               {
                  ConnectionStringsSection connectionStringsSection = pacsConfig.ConnectionStrings;
                  connectionStringSettings = connectionStringsSection.ConnectionStrings[name];
               }
            }

         }
         catch (Exception)
         {
            // return null;
         }

         return connectionStringSettings;
      }

      public static void UpgradeDatabase()
      {
         ConnectionStringSettings connectionSettings = GetConnectionSettings();

         WebViewerDataAccess.UpgradeDatabase(connectionSettings);

#if LEADTOOLS_V19_OR_LATER
         WebViewerDataAccess.SetDefaultOptions();
#endif
      }

      public static void ConfigureWebViewerDatabase ( )
      {
         ConnectionStringSettings connectionSettings = GetConnectionSettings ( ) ;
         Configuration config = DicomDemoSettingsManager.GetGlobalPacsConfiguration() ;

         UpdateGlobalPacsConfig ( config, connectionSettings, false ) ;

         config.Save ( ConfigurationSaveMode.Minimal ) ;
      }

      public static void UpdateGlobalPacsConfig ( Configuration configGlobalPacs, ConnectionStringSettings connectionSettings, bool jobAccessOnly )
      {
          string serviceName = string.Empty;
          StorageServerInformation serverInfo = GetServerInformation ( ) ;

          if(  null != serverInfo )
          {
            serviceName = serverInfo.ServiceName;
            // throw new ApplicationException ( "Server is not configured" ) ;
          }

         ConfigureJobsDataAccess          ( configGlobalPacs, connectionSettings, serviceName) ;
         ConfigurePatientRightsDataAccess ( configGlobalPacs, connectionSettings, serviceName) ;
         ConfigureAnnotationsDataAccess   ( configGlobalPacs, connectionSettings, serviceName) ;

#if LEADTOOLS_V19_OR_LATER
         if (jobAccessOnly == false)
         {
            ConfigureOptionsDataAccess(configGlobalPacs, connectionSettings, serviceName);
            ConfigureMoniforCalibrationDataAccess(configGlobalPacs, connectionSettings, serviceName);
           ConfigureTemplateDataAccess(configGlobalPacs, connectionSettings, serviceName);
         }
#endif
      }

      private static void ConfigureJobsDataAccess ( Configuration configGlobalPacs, ConnectionStringSettings connectionSettings, string serviceName )
      {
         DownloadJobsDataAccessConfigurationView jobsConfigurationView = new DownloadJobsDataAccessConfigurationView ( configGlobalPacs, DicomDemoSettingsManager.ProductNameMedicalViewer, null ) ;
         
         //jobsConfigurationView.ConfigurationSource = ConfigSource; ConfigurationSourceFactory.Create ( )
         jobsConfigurationView.Configuration = configGlobalPacs;
         ConfigureSection(configGlobalPacs, jobsConfigurationView, connectionSettings, DicomDemoSettingsManager.ProductNameMedicalViewer, serviceName );
      }

      private static void ConfigurePatientRightsDataAccess ( Configuration configGlobalPacs, ConnectionStringSettings connectionSettings, string serviceName )
      {
         PatientRightsDataAccessConfigurationView accessRightsConfigurationView = new PatientRightsDataAccessConfigurationView ( configGlobalPacs, DicomDemoSettingsManager.ProductNameMedicalViewer, null ) ;
         
         accessRightsConfigurationView.Configuration = configGlobalPacs;
         ConfigureSection(configGlobalPacs, accessRightsConfigurationView, connectionSettings, DicomDemoSettingsManager.ProductNameMedicalViewer, serviceName );
      }
      
      private static void ConfigureAnnotationsDataAccess ( Configuration configGlobalPacs, ConnectionStringSettings connectionSettings, string serviceName )
      {
         AnnotationsDataAccessConfigurationView annotationsConfigurationView = new AnnotationsDataAccessConfigurationView ( configGlobalPacs, DicomDemoSettingsManager.ProductNameMedicalViewer, null ) ;
         
         annotationsConfigurationView.Configuration = configGlobalPacs;
         ConfigureSection(configGlobalPacs, annotationsConfigurationView, connectionSettings, DicomDemoSettingsManager.ProductNameMedicalViewer, serviceName );
      }


#if LEADTOOLS_V19_OR_LATER
      private static void ConfigureOptionsDataAccess(Configuration configGlobalPacs, ConnectionStringSettings connectionSettings, string serviceName)
      {
         OptionsDataAccessConfigurationView optionsConfigurationView = new OptionsDataAccessConfigurationView ( configGlobalPacs, DicomDemoSettingsManager.ProductNameMedicalViewer, null ) ;
         
         optionsConfigurationView.Configuration = configGlobalPacs;
         ConfigureSection(configGlobalPacs, optionsConfigurationView, connectionSettings, DicomDemoSettingsManager.ProductNameMedicalViewer, serviceName );
      }

      private static void ConfigureMoniforCalibrationDataAccess(Configuration configGlobalPacs, ConnectionStringSettings connectionSettings, string serviceName)
      {
         MonitorCalibrationDataAccessConfigurationView monitorCalibrationConfigurationView = new MonitorCalibrationDataAccessConfigurationView ( configGlobalPacs, DicomDemoSettingsManager.ProductNameMedicalViewer, null ) ;
         
         monitorCalibrationConfigurationView.Configuration = configGlobalPacs;
         ConfigureSection(configGlobalPacs, monitorCalibrationConfigurationView, connectionSettings, DicomDemoSettingsManager.ProductNameMedicalViewer, serviceName );
      }

        private static void ConfigureTemplateDataAccess(Configuration configGlobalPacs, ConnectionStringSettings connectionSettings, string serviceName)
        {
            TemplateDataAccessConfigurationView templateConfigurationView = new TemplateDataAccessConfigurationView(configGlobalPacs, DicomDemoSettingsManager.ProductNameMedicalViewer, null);

            templateConfigurationView.Configuration = configGlobalPacs;
            ConfigureSection(configGlobalPacs, templateConfigurationView, connectionSettings, DicomDemoSettingsManager.ProductNameMedicalViewer, serviceName);
        }
#endif

        /// <summary>
        /// configure a data access section to hold the correct connection string info/product name and service name
        /// if found then update otherwise create
        /// </summary>
        /// <param name="config"></param>
        /// <param name="sectionView"></param>
        /// <param name="connectionSettings"></param>
        /// <param name="productName"></param>
        /// <param name="serviceName"></param>
        private static void ConfigureSection 
      ( 
         Configuration config, 
         DataAccessConfigurationView sectionView, 
         ConnectionStringSettings connectionSettings, 
         string productName,
         string serviceName
      )
      {
         DataAccessSettings dataAccessSettings;


         ConfigurationManager.RefreshSection(sectionView.DataAccessSettingsSectionName);

         try
         {
            dataAccessSettings = config.Sections.OfType<DataAccessSettings>().FirstOrDefault(n => n.SectionInformation.Name == sectionView.DataAccessSettingsSectionName);
         }
         catch (Exception)
         {
            config.Sections.Remove(sectionView.DataAccessSettingsSectionName);
            dataAccessSettings = null;
         }

         bool newSection = false;
         if (null == dataAccessSettings)
         {
            dataAccessSettings = new DataAccessSettings();
            newSection = true;
         }

         dataAccessSettings.ConnectionName = connectionSettings.Name ;

         string defaultConnectionName = string.Empty;

         if (!string.IsNullOrEmpty(productName))
         {
            AddProduct ( dataAccessSettings, productName, connectionSettings.Name ) ;
         }

         if ( !string.IsNullOrEmpty ( serviceName ) ) 
         {
            AddServiceToProduct ( dataAccessSettings, productName, serviceName, connectionSettings.Name ) ;
         }

         if (newSection)
         {
            config.Sections.Add ( sectionView.DataAccessSettingsSectionName, dataAccessSettings ) ;
         }
      }


      /// <summary>
      /// Checks all connection string sections required by the Web Viewer components
      /// </summary>
      /// <returns></returns>
      public static bool IsWebViewerConnectionConfigured ( ) 
      {
         Configuration configPacs = DicomDemoSettingsManager.GetGlobalPacsConfiguration();
         
         ConnectionStringSettings webViewerDownloadSettings = GetConnectionString(configPacs, new DownloadJobsDataAccessConfigurationView(configPacs, DicomDemoSettingsManager.ProductNameMedicalViewer, null).DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameMedicalViewer);
         ConnectionStringSettings webViewerRolesPatientsSettings = GetConnectionString(configPacs, new PatientRightsDataAccessConfigurationView(configPacs, DicomDemoSettingsManager.ProductNameMedicalViewer, null).DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameMedicalViewer);
         ConnectionStringSettings webViewerAnnotationsSettings = GetConnectionString(configPacs, new AnnotationsDataAccessConfigurationView(configPacs, DicomDemoSettingsManager.ProductNameMedicalViewer, null).DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameMedicalViewer);
         ConnectionStringSettings storageSettings   = GetConnectionString(configPacs, new StorageDataAccessConfigurationView(configPacs, DicomDemoSettingsManager.ProductNameStorageServer, null).DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameStorageServer);
#if LEADTOOLS_V19_OR_LATER
         ConnectionStringSettings webViewerOptionsSettings = GetConnectionString(configPacs, new OptionsDataAccessConfigurationView(configPacs, DicomDemoSettingsManager.ProductNameMedicalViewer, null).DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameMedicalViewer);
         ConnectionStringSettings webViewerMonitorCalibrationSettings = GetConnectionString(configPacs, new MonitorCalibrationDataAccessConfigurationView(configPacs, DicomDemoSettingsManager.ProductNameMedicalViewer, null).DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameMedicalViewer);

         ConnectionStringSettings webViewerTemplateSettings = GetConnectionString(configPacs, new TemplateDataAccessConfigurationView(configPacs, DicomDemoSettingsManager.ProductNameMedicalViewer, null).DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameMedicalViewer);

#endif


         if ( 
               null != webViewerDownloadSettings && 
               null !=storageSettings && 
               null != webViewerRolesPatientsSettings && 
               null != webViewerAnnotationsSettings 
#if LEADTOOLS_V19_OR_LATER
               &&
               null != webViewerOptionsSettings &&
               null != webViewerMonitorCalibrationSettings &&
               null != webViewerTemplateSettings
#endif
            )
         {
            return ( 
                     ( storageSettings.ConnectionString == webViewerDownloadSettings.ConnectionString ) && 
                     ( storageSettings.ConnectionString == webViewerRolesPatientsSettings.ConnectionString ) &&
                     ( storageSettings.ConnectionString == webViewerAnnotationsSettings.ConnectionString )
#if LEADTOOLS_V19_OR_LATER
                     &&
                     (storageSettings.ConnectionString == webViewerOptionsSettings.ConnectionString)  &&
                     (storageSettings.ConnectionString == webViewerMonitorCalibrationSettings.ConnectionString) &&
                     (storageSettings.ConnectionString == webViewerTemplateSettings.ConnectionString)

#endif
) ;
         }

         return false ;
      }

      /// <summary>
      /// find/create the connection element that points to our product and update the connection information
      /// </summary>
      /// <param name="dataAccessSettings"></param>
      /// <param name="productName"></param>
      /// <param name="connectionName"></param>
      private static void AddProduct (DataAccessSettings dataAccessSettings, string productName, string connectionName)
      {
         ConnectionElement connectionElement = null;
         if (dataAccessSettings != null)
         {
            int count = dataAccessSettings.Connections.Count;
            for (int i = 0; i < count; i++)
            {
               if (dataAccessSettings.Connections[i].ProductName == productName)
               {
                  connectionElement = dataAccessSettings.Connections[i];
                  connectionElement.ConnectionName = connectionName;
                  break;
               }
            }
            if (connectionElement == null)
            {
               connectionElement = new ConnectionElement();
               connectionElement.ProductName = productName;
               connectionElement.ConnectionName = connectionName;
               dataAccessSettings.Connections.Add(connectionElement);
            }
         }
      }
      
      /// <summary>
      /// adds/creates a connection element with the proper service name/product name and connection string
      /// </summary>
      /// <param name="dataAccessSettings"></param>
      /// <param name="productName"></param>
      /// <param name="serviceName"></param>
      /// <param name="connectionName"></param>
      private static void AddServiceToProduct(DataAccessSettings dataAccessSettings, string productName, string serviceName, string connectionName)
      {
         ConnectionElement connectionElement = null;
         if (dataAccessSettings != null)
         {
            int count = dataAccessSettings.Connections.Count;
            for (int i = 0; i < count; i++)
            {
               if (dataAccessSettings.Connections[i].ProductName == productName)
               {
                  connectionElement = dataAccessSettings.Connections[i];
                  connectionElement.ConnectionName = connectionName;
                  break;
               }
            }
            if (connectionElement == null)
            {
               connectionElement = new ConnectionElement();
               connectionElement.ProductName = productName;
               connectionElement.ServiceName = serviceName;
               connectionElement.ConnectionName = connectionName;
               dataAccessSettings.Connections.Add(connectionElement);
            }
            else
            {
               connectionElement.ServiceName = serviceName ;
            }
         }
      }
   }
}
