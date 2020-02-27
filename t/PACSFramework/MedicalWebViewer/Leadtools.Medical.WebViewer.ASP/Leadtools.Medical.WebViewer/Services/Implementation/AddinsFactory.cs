// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Linq;

using Leadtools.DataAccessLayers;
using Leadtools.Medical.Logging.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.UserManagementDataAccessLayer;
using Leadtools.Medical.WebViewer.Addins;
using Leadtools.Medical.WebViewer.Annotations;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Jobs.DataAccessLayer;
using Leadtools.Medical.WebViewer.PatientAccessRights;
using Leadtools.Medical.ExternalStore.DataAccessLayer;
using System.Configuration;
using Leadtools.Medical.WebViewer.Common;
using System.Xml.Linq;
using Leadtools.Medical.WebViewer.Wado;
using Leadtools.Medical.WebViewer.Services.Interfaces;

namespace Leadtools.Medical.WebViewer.Services
{
   public class AddinsFactory : IDisposable
   {
      private Lazy<IUserManagementDataAccessAgent4> UserManagementDataAccessAgent;
      private Lazy<IPermissionManagementDataAccessAgent2> PermissionManagementDataAccessAgent;
      private Lazy<IOptionsDataAccessAgent> OptionsDataAccessAgent;
      private Lazy<ILoggingDataAccessAgent> LoggingAgent;
      private Lazy<IStorageDataAccessAgent3> StorageAgent;
      private Lazy<IPatientRightsDataAccessAgent> PatientRightsDataAccess;
      private Lazy<IDownloadJobsDataAccessAgent> DownloadJobsDataAccessAgent;
      private Lazy<IAuthorizedStorageDataAccessAgent2> AuthorizedStorageDataAccessAgent;
      private Lazy<IMonitorCalibrationDataAccessAgent> MonitorCalibrationDataAccessAgent;
      private Lazy<ITemplateDataAccessAgent> TemplateDataAccessAgent;
      private Lazy<IExternalStoreDataAccessAgent> ExternalStoreAgent;
      private Lazy<Leadtools.Dicom.Imaging.IDataCacheProvider> DataCache;
      private Lazy<ConnectionSettings> ConnectionSettings;


      public AddinsFactory(Lazy<IUserManagementDataAccessAgent4> userManagementDataAccessAgent,
       Lazy<IPermissionManagementDataAccessAgent2> permissionManagementDataAccessAgent,
       Lazy<IOptionsDataAccessAgent> optionsDataAccessAgent,
       Lazy<ILoggingDataAccessAgent> loggingAgent,
       Lazy<IStorageDataAccessAgent3> storageAgent,
       Lazy<IPatientRightsDataAccessAgent> patientRightsDataAccess,
       Lazy<IDownloadJobsDataAccessAgent> downloadJobsDataAccessAgent,
       Lazy<IAuthorizedStorageDataAccessAgent2> authorizedStorageDataAccessAgent,
       Lazy<IMonitorCalibrationDataAccessAgent> monitorCalibrationDataAccessAgent,
       Lazy<ITemplateDataAccessAgent> templateDataAccessAgent,
       Lazy<IExternalStoreDataAccessAgent> externalStoreAgent,
       Lazy<Leadtools.Dicom.Imaging.IDataCacheProvider> dataCache,
       Lazy<ConnectionSettings> connectionSettings)
      {
         UserManagementDataAccessAgent = userManagementDataAccessAgent;
         PermissionManagementDataAccessAgent = permissionManagementDataAccessAgent;
         OptionsDataAccessAgent = optionsDataAccessAgent;
         LoggingAgent = loggingAgent;
         StorageAgent = storageAgent;
         PatientRightsDataAccess = patientRightsDataAccess;
         DownloadJobsDataAccessAgent = downloadJobsDataAccessAgent;
         AuthorizedStorageDataAccessAgent = authorizedStorageDataAccessAgent;
         MonitorCalibrationDataAccessAgent = monitorCalibrationDataAccessAgent;
         TemplateDataAccessAgent = templateDataAccessAgent;
         ExternalStoreAgent = externalStoreAgent;
         DataCache = dataCache;
         ConnectionSettings = connectionSettings;
      }

      private bool _disposed = false;
      ~AddinsFactory()
      {
         if (!this._disposed)
         {
            this._disposed = true;
            Dispose();
         }
      }

      public void Dispose()
      {
         if (!this._disposed)
         {
            this._disposed = true;
            GC.SuppressFinalize(this);
         }
      }

      public IAuthenticationAddin CreateAuthenticationAddin()
      {
         return new AuthenticationAddin(UserManagementDataAccessAgent.Value, PermissionManagementDataAccessAgent.Value, OptionsDataAccessAgent.Value, LoggingAgent.Value);
      }

      public IAuditLogAddin CreateAuditLogAddin()
      {
         return new AuditLogAddin(LoggingAgent.Value);
      }
      public IObjectRetrieveAddin CreateRetrieveAddin()
      {
         return new ObjectRetrieveAddin(StorageAgent.Value, ExternalStoreAgent, LoggingAgent.Value, ConnectionSettings.Value.StorageServerServicePath, OptionsDataAccessAgent.Value, PermissionManagementDataAccessAgent.Value, AuthorizedStorageDataAccessAgent.Value, DataCache.Value);
      }

      public IQueryAddin CreateQueryAddin()
      {
         return new DatabaseQueryAddin(AuthorizedStorageDataAccessAgent.Value, OptionsDataAccessAgent.Value, PermissionManagementDataAccessAgent.Value, ExternalStoreAgent, LoggingAgent.Value, ConnectionSettings.Value.StorageServerServicePath, StorageAgent.Value, DataCache.Value);
      }

      public IRemoteQueryAddin CreateWadoQueryAddin()
      {
         return new WadoQueryAddin();
      }
      public IRemoteRetrieveAddin CreateWadoRetrieveAddin()
      {
         return new WadoRetrieveAddin();
      }
      
      public IStoreAddin CreateStoreAddin()
      {
         return new StoreAddin(StorageAgent.Value, LoggingAgent.Value, CreateQueryAddin(), CreateRetrieveAddin(), ConnectionSettings.Value.StorageServerConnection.AETitle, ConnectionSettings.Value.StorageServerServicePath, PermissionManagementDataAccessAgent.Value, AuthorizedStorageDataAccessAgent.Value);
      }

      public Leadtools.Dicom.Imaging.DiskDataCacheStorage CreateCacheDiskStorage()
      {
         return LTCachingCtrl.CreateCacheStorage(LTCachingCtrl.CacheSettings);
      }
      public IExportAddin CreateExportAddin()
      {
         IStoreAddin storeAddin = new StoreAddin(StorageAgent.Value, LoggingAgent.Value, CreateQueryAddin(), CreateRetrieveAddin(), ConnectionSettings.Value.StorageServerConnection.AETitle, ConnectionSettings.Value.StorageServerServicePath, PermissionManagementDataAccessAgent.Value, AuthorizedStorageDataAccessAgent.Value);

         return new ExportAddin(StorageAgent.Value, AuthorizedStorageDataAccessAgent.Value, ExternalStoreAgent, LoggingAgent.Value, ConnectionSettings.Value.StorageServerServicePath, storeAddin, OptionsDataAccessAgent.Value, PermissionManagementDataAccessAgent.Value, DataCache.Value);
      }

      public static ISessionAuthenticationAddin CreateSessionAuthenticationAddin()
      {
         return new SessionAuthenticationAddin();
      }
      public IMonitorCalibrationAddin CreateMonitorCalibrationAddin()
      {
         return new MonitorCalibrationAddin(MonitorCalibrationDataAccessAgent.Value);
      }
      public IOptionsAddin CreateOptionsAddin()
      {
         return new OptionsAddin(OptionsDataAccessAgent.Value, LoggingAgent.Value);
      }
      public IPACSQueryAddin CreatePacsQueryAddin()
      {
         return new PACSQueryAddin(ConnectionSettings.Value.ClientConnection);
      }
      public IPacsDownloadAddin CreatePacsDownloadAddin()
      {
         return new DownloadAddin(ConnectionSettings.Value.ClientConnection, ConnectionSettings.Value.StorageServerConnection, DownloadJobsDataAccessAgent.Value, AuthorizedStorageDataAccessAgent.Value);
      }
      public IPatientAccessRightsAddin CreatePatientAccessRightsAddin()
      {
         return new PatientAccessRightsAddin(PatientRightsDataAccess.Value);
      }

      public ITemplateAddin CreateTemplateAddin()
      {
         return new TemplateAddin(TemplateDataAccessAgent.Value);
      }
   }
}
