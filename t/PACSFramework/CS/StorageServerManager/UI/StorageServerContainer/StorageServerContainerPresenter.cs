// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using Leadtools.Demos.StorageServer.UI;
using System.Windows.Forms;
using Leadtools.Medical.Winforms;
using System.Drawing;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Medical.Logging.DataAccessLayer.Configuration;
using System.Configuration;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.UserManagementDataAccessLayer.Configuration;
using Leadtools.Medical.AeManagement.DataAccessLayer.Configuration;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;
using Leadtools.DicomDemos;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom;
using Leadtools.Demos.StorageServer.DataTypes;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Medical.Storage.AddIns;
using Leadtools.Dicom.AddIn;
using Leadtools.Medical.Winforms.DataAccessLayer.Configuration;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer.Configuration;
using Leadtools.Medical.Forward.DataAccessLayer.Configuration;

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Dicom.Scp.Command;
using Leadtools.Demos.StorageServer.UI.RealtimeView;
using Leadtools.Medical.Winforms.ClientManager;
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)


#if TUTORIAL_CUSTOM_DATABASE
using My.Medical.Storage.DataAccessLayer;
using My.Medical.Storage.DataAccessLayer.Entities;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Medical.Winforms.Control;
using Leadtools.Dicom.Common.Extensions;
#endif

namespace Leadtools.Demos.StorageServer
{
   public partial class StorageServerContainerPresenter
   {
      private ILicense _License;
      private IFeature _FeatureStudyCount;
      private IFeature _FeatureSeriesCount;
      private IStorageDataAccessAgent _AccessAgent;
      private StorageDatabaseManager __DbManager ;
      private ServerInformationView __ServerInfoView;

      public StorageServerContainerPresenter ( ) 
      {
         ProductName = DicomDemoSettingsManager.ProductNameStorageServer;
      }

      public string ProductName
      {
         get;
         set;
      }
      
      public string PathLogDump
      {
         get;set;
      }

      public void RunView ( StorageServerContainerView view ) 
      {
         View = view ;

         CreateContainerPages ( ) ;
         
         EventBroker.Instance.Subscribe <CurrentUserPemissionsChangedEventArgs> ( OnCurrentUserPermissionChanged ) ;
         EventBroker.Instance.Subscribe <ServerSettingsAppliedEventArgs>        ( OnServerSettingsApplied ) ;
      }

#if TUTORIAL_CUSTOM_DATABASE
      // To use a custom database schema with the Database Manager, you must define a custom MyPrepareSearch method 
      // and assign it to the StorageDatabaseManager.PrepareSearch delegate. After doing this, the search fields in the Database Manager 
      //will properly refine any database manager search.  The MyPrepareSearch() method gets the search fields specified in the database manager 
      // by calling StorageDatabaseManager.GetDicomQueryParams().  This returns any query parameters specified.
      // The MyPrepareSearch() method then needs to create a MatchingParameterCollection that corresponds to the specified search. 
      // Note that the database manager search fields correspond to items contained in the patient, study, and series tables only.  
      // There are no search fields that correspond to the image table.  
      // Therefore MyPrepareSearch() only needs to add MyPatient, MyStudy, and MySeries objects to the MatchingParameterList. 
      // For more details, see the "Changing the LEAD Medical Storage Server to use a different database schema" tutorial.


      private void MyPrepareSearch(MatchingParameterCollection matchingCollection)
      {
         DicomQueryParams q = __DbManager.GetDicomQueryParams();

         try
         {
            MatchingParameterList matchingList = new MatchingParameterList();
            MyPatient patient = new MyPatient();
            MyStudy study = new MyStudy();
            MySeries series = new MySeries();

            matchingList.Add(patient);
            matchingList.Add(study);
            matchingList.Add(series);

            matchingCollection.Add(matchingList);
            study.StudyAccessionNumber = q.AccessionNumber;
            patient.PatientIdentification = q.PatientId;

            if (!string.IsNullOrEmpty(q.PatientName.FamilyName))
               patient.PatientName = q.PatientName.FamilyName.TrimEnd('*') + "*";

            if (!string.IsNullOrEmpty(q.PatientName.GivenName))
               patient.PatientName = q.PatientName.GivenName.TrimEnd('*') + "*";

            if (!string.IsNullOrEmpty(q.Modalities))
               series.SeriesModality = q.Modalities.Replace(",", "\\"); ;

            if (!string.IsNullOrEmpty(q.SeriesDescription))
               series.SeriesSeriesDescription = q.SeriesDescription.TrimEnd('*') + "*";

            if (!string.IsNullOrEmpty(q.ReferringPhysiciansName.FamilyName))
               study.StudyReferringPhysiciansName = q.ReferringPhysiciansName.FamilyName.TrimEnd('*') + "*"; ;

            if (!string.IsNullOrEmpty(q.ReferringPhysiciansName.GivenName))
               study.StudyReferringPhysiciansName = q.ReferringPhysiciansName.GivenName.TrimEnd('*') + "*"; ;

            if (q.StudyFromChecked || q.StudyToChecked)
            {
               DateRange studyDateRange = new DateRange();

               if (q.StudyFromChecked)
               {
                  studyDateRange.StartDate = q.StudyFromDate;
               }

               if (q.StudyToChecked)
               {
                  studyDateRange.EndDate = q.StudyToDate;
               }

               study.StudyStudyDate = studyDateRange;
            }

            if (q.StorageDateChecked)
            {
               MyInstance instance = new MyInstance();
               DateRange dateRange = new DateRange();
               DateRangeFilter StorageDateRangeFilter = q.StorageDateRange;
               string startDate = StorageDateRangeFilter.DateRangeFrom;
               string endDate = StorageDateRangeFilter.DateRangeTo;

               if (StorageDateRangeFilter.SelectedDateFilter == DateRangeFilter.RangeFilterType.DateRange)
               {
                  if (!string.IsNullOrEmpty(startDate))
                  {
                     dateRange.StartDate = DateTime.Parse(startDate);
                  }

                  if (!string.IsNullOrEmpty(endDate))
                  {
                     dateRange.EndDate = DateTime.Parse(endDate);
                  }
               }
               else if (StorageDateRangeFilter.SelectedDateFilter == DateRangeFilter.RangeFilterType.Months)
               {
                  DateTime lastMonthsDate = DateTime.Now.SubtractMonths(Convert.ToInt32(StorageDateRangeFilter.LastMonths));

                  dateRange.StartDate = lastMonthsDate;
                  dateRange.EndDate = DateTime.Now;
               }
               else
               {
                  TimeSpan subtractionDays = new TimeSpan(Convert.ToInt32(StorageDateRangeFilter.LastDays),
                                                   DateTime.Now.Hour,
                                                   DateTime.Now.Minute,
                                                   DateTime.Now.Second,
                                                   DateTime.Now.Millisecond);

                  dateRange.StartDate = DateTime.Now.Subtract(subtractionDays);
                  dateRange.EndDate = DateTime.Now;
               }

               instance.ImageLastStoreDate = dateRange;
               matchingList.Add(instance);
            }

            study.StudyStudyId = q.StudyId;
         }
         catch (Exception exception)
         {
            throw exception;
         }
         finally
         {
            // do nothing ;
         }
      }
#endif

      private void CreateContainerPages ( )
      {
         ControlPanelView         controlPanelView  = new ControlPanelView ( ) ;
         ServerInformationView    serverInfoView    = new ServerInformationView ( )  ;
         ServerAddinsView         serverAddInView   = new ServerAddinsView ( ) ;
         ServerSettingsDialog     serverSettingsDlg = new ServerSettingsDialog ( ) ;
         ServerInformationControl serverInfoControl = new ServerInformationControl();
         
         ControlPanelPresenter      controlPanelPresenter   = new ControlPanelPresenter ( ) ;
         ServerInformationPresenter serverInfoPresenter     = new ServerInformationPresenter ( ) ;
         ServerAddinPresenter       serverAddInPresenter    = new ServerAddinPresenter ( ) ;
         ServerSettingsPresenter    serverSettingsPresenter = new ServerSettingsPresenter ( ) ;         

#if LEADTOOLS_V19_OR_LATER
         RealTimeViewPresenter realTimePresenter = new RealTimeViewPresenter();
#endif
         
         StorageDatabaseManager dbManager = new StorageDatabaseManager ( ) ;
#if TUTORIAL_CUSTOM_DATABASE
         // To use a custom database schema with the Database Manager, you must define a custom MyPrepareSearch method 
         // and assign it to the StorageDatabaseManager.PrepareSearch delegate.
         // For more details, see the "Changing the LEAD Medical Storage Server to use a different database schema" tutorial.
      
         dbManager.PrepareSearch = new PrepareSearchDelegate(MyPrepareSearch);
#endif
         EventLogViewer         logViewer = new EventLogViewer ( ) ;         

#if LEADTOOLS_V19_OR_LATER
         RealTimeViewerControl realTimeView = new RealTimeViewerControl() { Visible = false };
#endif

         dbManager.BackColor         = Color.FromArgb ( 75, 75, 75 ) ;
         logViewer.BackColor         = Color.White ;
         logViewer.PathLogDump       = this.PathLogDump;
         serverInfoControl.BackColor = Color.White;

         ThemesManager.ApplyTheme ( controlPanelView ) ;
         ThemesManager.ApplyTheme ( logViewer ) ;
         ThemesManager.ApplyTheme ( dbManager ) ;
         ThemesManager.ApplyTheme ( serverInfoControl ) ;         

#if LEADTOOLS_V19_OR_LATER
         ThemesManager.ApplyTheme(realTimeView);
#endif
         
         ConfigureServerInfoConrol ( serverInfoControl ) ;
         
         View.SetHeader ( serverInfoView ) ;

         AddPage ( new PageData ( controlPanelView, "Control Panel", null )) ;
         
         //AddPage ( new PageData ( new Control ( ), "Security", null ) ) ;
         AddPage ( new PageData ( logViewer, "Event Log", null )) ;
         AddPage ( new PageData ( serverInfoControl, "System Information", null ) ) ;
         
         dbManager.MergeImportDicom = true ;

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         dbManager.EnableExport = true;
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

         dbManager.Enabled          = ServerState.Instance.ServerService != null ;
         
         if (ServerState.Instance.ServerService != null)
         {
            dbManager.AETitle = ServerState.Instance.ServerService.Settings.AETitle;
         }
         
         AddPage ( new PageData ( dbManager, "Database Manager", null ) ) ;

         dbManager.Enabled = true;

#if LEADTOOLS_V19_OR_LATER
         AddPage(new PageData(realTimeView, "Live View", null));
#endif
         InitializeLicenseView();         
         
         serverAddInView.Enabled = UserManager.User.IsAdmin();
         AddPage ( new PageData ( serverAddInView, "Add-ons",  null ) ) ;
         
         controlPanelPresenter.RunView   ( controlPanelView ) ;
         serverInfoPresenter.RunView     ( serverInfoView ) ;
         serverAddInPresenter.RunView    ( serverAddInView ) ;
         serverSettingsPresenter.RunView ( serverSettingsDlg ) ;  
         
#if LEADTOOLS_V19_OR_LATER
         realTimePresenter.RunView(realTimeView);
#endif

         if (DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent>())
         {
            _AccessAgent = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();
         }

         dbManager.CancelStore           += new EventHandler<CancelStoreEventArgs>  ( dbManager_CancelStore ) ;
         dbManager.ConfigureStoreCommand += new EventHandler<StoreCommandEventArgs> ( dbManager_ConfigureStoreCommand ) ;

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         dbManager.ConfigureStoreExportCommand += new EventHandler<StoreCommandEventArgs> ( dbManager_ConfigureStoreCommandExport ) ;
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         
         
#if TUTORIAL_CUSTOM_DATABASE
        // To use a custom database schema with the Database Manager, you must define a custom MyPrepareSearch method 
        // and assign it to the StorageDatabaseManager.PrepareSearch delegate. After doing this, the search fields in the Database Manager 
        //will properly refine any database manager search.  The MyPrepareSearch() method gets the search fields specified in the database manager 
        // by calling StorageDatabaseManager.GetDicomQueryParams().  This returns any query parameters specified.
        // For more details, see the "Changing the LEAD Medical Storage Server to use a different database schema" tutorial.

         dbManager.GetDicomQueryParams();
#endif
         __DbManager = dbManager ;
         __ServerInfoView = serverInfoView;
         
         ApplyPermissions ( ) ;

         ApplyStorageSettingsPermissions ( ) ;

         Instance_LicenseChanged(this, EventArgs.Empty);
         ServerState.Instance.LicenseChanged += new EventHandler(Instance_LicenseChanged);
      }

      private void ApplyStorageSettingsPermissions()
      {
         if (null != __DbManager)
         {
            StorageModuleConfigurationManager configManager = ServiceLocator.Retrieve<StorageModuleConfigurationManager>();
            if (configManager.IsLoaded)
            {
               StorageAddInsConfiguration storageSettings = configManager.GetStorageAddInsSettings();
               
            if (storageSettings != null)
            {
               __DbManager.DeleteFilesOnDatabaseDelete = storageSettings.StoreAddIn.DeleteFiles;
               __DbManager.BackupFilesOnDatabaseDelete = storageSettings.StoreAddIn.BackupFilesOnDelete;
               __DbManager.BackupFilesOnDeleteFolder = storageSettings.StoreAddIn.DeleteBackupLocation;
#if LEADTOOLS_V20_OR_LATER
               __DbManager.MetadataOptions = storageSettings.StoreAddIn.GetMetadataOptions();
#endif
            }
            }
         }
      }

      private void ApplyPermissions ( )
      {
         if ( null != __DbManager ) 
         {
            __DbManager.CanDelete        = UserManager.User.IsAuthorized ( UserPermissions.CanDeleteFromDatabase ) ;
            __DbManager.CanEmptyDatabase = UserManager.User.IsAuthorized ( UserPermissions.CanEmptyDatabase ) ;
            __ServerInfoView.CanChangeSettings = UserManager.User.IsAuthorized(UserPermissions.Admin) || UserManager.User.IsAuthorized(UserPermissions.CanChangeServerSettings);

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
            __DbManager.CanChangeSettings = UserManager.User.IsAuthorized(UserPermissions.Admin) || UserManager.User.IsAuthorized(UserPermissions.CanChangeServerSettings);
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         }
      }

      void OnCurrentUserPermissionChanged ( object sender, CurrentUserPemissionsChangedEventArgs e ) 
      {
         ApplyPermissions ( ) ;
      }
      
      void OnServerSettingsApplied  ( object sender, ServerSettingsAppliedEventArgs e ) 
      {
         ApplyStorageSettingsPermissions ( ) ;
      }

      void Instance_LicenseChanged(object sender, EventArgs e)
      {
         try
         {
            _License = ServerState.Instance.License;
            if (_License != null)
            {
               _FeatureStudyCount = _License.GetFeature(ServerFeatures.MaxStudiesStored);
               _FeatureSeriesCount = _License.GetFeature(ServerFeatures.MaxSeriesStored);
            }
         }
         catch{}
         finally
         {
            UpdateContainerPagesEnabled();
         }
      }

      void dbManager_CancelStore ( object sender, CancelStoreEventArgs e )
      {
         try
         {
            ValidateLicense ( e ) ;
         }
         catch{}
      }
      
      void dbManager_ConfigureStoreCommand ( object sender, StoreCommandEventArgs e )
      {
         try
         {
            if ( ServerState.Instance.ServerService != null ) 
            {
               StorageModuleConfigurationManager configManager = ServiceLocator.Retrieve <StorageModuleConfigurationManager> ( ) ;
               
               if ( configManager.IsLoaded ) 
               {
                  StorageAddInsConfiguration storageSettings = configManager.GetStorageAddInsSettings ( ) ;
                  
                  StoreCommandInitializationService.ConfigureCStoreCommand         ( e.Command, storageSettings.StoreAddIn ) ;
                  StoreCommandInitializationService.ConfigureInstanceCStoreCommand ( e.Command, storageSettings.StoreAddIn ) ;
               }
            }
         }
         catch{}
      }


#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
      static void dbManager_ConfigureStoreCommandExport ( object sender, StoreCommandEventArgs e )
      {
         try
         {
            if (ServerState.Instance.ServerService != null)
            {
               StorageModuleConfigurationManager configManager = ServiceLocator.Retrieve<StorageModuleConfigurationManager>();

               if (configManager.IsLoaded)
               {
                  StorageAddInsConfiguration storageSettings = configManager.GetStorageAddInsSettings();

                  StoreCommandInitializationService.ConfigureCStoreCommand(e.Command, storageSettings.StoreAddIn);


                  // StoreCommandInitializationService.ConfigureInstanceCStoreCommand ( e.Command, storageSettings.StoreAddIn ) ;

                  InstanceCStoreCommand instanceStoreCommand = e.Command as InstanceCStoreCommand;
                  if (instanceStoreCommand != null)
                  {
                     instanceStoreCommand.InstanceConfiguration.CreateBackupForDuplicateSop = false;
                     instanceStoreCommand.InstanceConfiguration.UpdateInstanceData = false;
                     instanceStoreCommand.InstanceConfiguration.UpdatePatientData = false;
                     instanceStoreCommand.InstanceConfiguration.UpdateSeriesData = false;
                     instanceStoreCommand.InstanceConfiguration.UpdateStudyData = false;
                     instanceStoreCommand.InstanceConfiguration.ValidateDuplicateSopInstanceUID = false;
                  }

                  CStoreCommand storeCommand = e.Command as CStoreCommand;
                  if (storeCommand != null  && storeCommand.Configuration != null)
                  {
                     storeCommand.Configuration.OtherImageFormat.Clear();
                     storeCommand.Configuration.SaveThumbnail = false;
                  }
               }

            }
         }
         catch { }
      }
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

      private void ValidateLicense(CancelStoreEventArgs e)
      {
         if (_License == null)
         {
            e.Cancel = true;
            e.CancelMessage = "No valid license provided.";
         }
         else
         {
            if (_AccessAgent != null)
            {
               string instance = string.Empty;
               int count;
               MatchingParameterCollection mpc = new MatchingParameterCollection() { { new MatchingParameterList() } };

               if (_FeatureStudyCount != null)
               {
                  instance = e.DataSet.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty);
                  if (!_AccessAgent.IsStudyExists(instance))
                  {
                     count = _AccessAgent.FindStudiesCount(mpc);
                     if (_FeatureStudyCount.Counter > 0 && (count + 1) > _FeatureStudyCount.Counter)
                     {
                        e.Cancel = true;
                        e.CancelMessage = string.Format("Max study limit reached, Study ({0}) not stored.  The license is restricted to storing {1} {2}.", instance, count, count == 1 ? "study" : "studies");
                        return;
                     }
                  }
               }

               if (_FeatureSeriesCount != null)
               {
                  instance = e.DataSet.GetValue<string>(DicomTag.SeriesInstanceUID, string.Empty);
                  if (!_AccessAgent.IsSeriesExists(instance))
                  {
                     count = _AccessAgent.FindSeriesCount(mpc);
                     if (_FeatureSeriesCount.Counter > 0 && (count + 1) > _FeatureSeriesCount.Counter)
                     {
                        e.Cancel = true;
                        e.CancelMessage = string.Format("Max series limit reached, Series ({0}) not stored.  The license is restricted to storing {1} series.", instance, count);
                        return;
                     }
                  }
               }
            }
         }
      }

      public void AddPage ( PageData pageData ) 
      {
         ValidateView ( ) ;

         View.Pages.Add ( pageData ) ;
      }

      private void ValidateView()
      {
         if ( null == View )
         {
            throw new InvalidOperationException ( "View is not initialized." ) ;
         }
      }

      public StorageServerContainerView View
      {
         get ;
         private set ;
      }

      private ServerInformationControl _serverInfoControl;
      
      private void ConfigureServerInfoConrol ( ServerInformationControl serverInfoControl )
      {
         ConnectionStringSettings logging;
         ConnectionStringSettings storage;
         ConnectionStringSettings options;
         ConnectionStringSettings userManagement;
         ConnectionStringSettings userPermissions;
         ConnectionStringSettings aeManagement;
         ConnectionStringSettings aePermissions;
         ConnectionStringSettings forwarding;

         System.Configuration.Configuration configPacs = DicomDemoSettingsManager.GetGlobalPacsConfiguration();

         // Machine.config file
         System.Configuration.Configuration configMachine = ConfigurationManager.OpenMachineConfiguration();

#if TUTORIAL_CUSTOM_DATABASE
        // To use a custom database schema with the Database Manager, you must define a connection string in the 'globalPacs.config' for your database.
        // You must use your 'MyStorageDataAccessConfigurationView' class to retrieve the connection string.
        // For more details, see the "Changing the LEAD Medical Storage Server to use a different database schema" tutorial.
        
         storage = GetConnectionString(configPacs, configMachine, new MyStorageDataAccessConfigurationView(configPacs, PacsProduct.ProductName, null).DataAccessSettingsSectionName);
#else
         storage = GetConnectionString(configPacs, configMachine, new StorageDataAccessConfigurationView(configPacs, PacsProduct.ProductName, null).DataAccessSettingsSectionName);
#endif
         logging = GetConnectionString(configPacs, configMachine, new LoggingDataAccessConfigurationView(configPacs, PacsProduct.ProductName, null).DataAccessSettingsSectionName);
         options = GetConnectionString(configPacs, configMachine, new OptionsDataAccessConfigurationView(configPacs, PacsProduct.ProductName, null).DataAccessSettingsSectionName);
         userManagement =GetConnectionString(configPacs, configMachine, new UserManagementDataAccessConfigurationView(configPacs, ProductName, null).DataAccessSettingsSectionName);
         userPermissions = GetConnectionString(configPacs, configMachine, new PermissionManagementDataAccessConfigurationView(configPacs, ProductName, null).DataAccessSettingsSectionName);
         aeManagement = GetConnectionString(configPacs, configMachine, new AeManagementDataAccessConfigurationView(configPacs, PacsProduct.ProductName, null).DataAccessSettingsSectionName);
         aePermissions = GetConnectionString(configPacs, configMachine, new AePermissionManagementDataAccessConfigurationView(configPacs, PacsProduct.ProductName, null).DataAccessSettingsSectionName);
         forwarding = GetConnectionString(configPacs, configMachine, new ForwardDataAccessConfigurationView(configPacs, PacsProduct.ProductName, null).DataAccessSettingsSectionName);


         Dictionary<string, string> connections = new Dictionary<string, string>();
         string storageDatabaseName = "Storage Database" ;
         connections.Add(storageDatabaseName, storage.ConnectionString);
         connections.Add("Logging Database", logging.ConnectionString);
         connections.Add("Server Configuration Database", options.ConnectionString);
         connections.Add("User Management Database", userManagement.ConnectionString);
         connections.Add("User Permissions Database", userPermissions.ConnectionString);
         connections.Add("Client Management Database", aeManagement.ConnectionString);
         connections.Add("Client Permissions Database", aePermissions.ConnectionString);
         connections.Add("Forwarding Database", forwarding.ConnectionString);

         serverInfoControl.SqlDatabaseList = connections;
         serverInfoControl.StorageDatabaseName = storageDatabaseName ;
         serverInfoControl.MaximumClientConnectionCount = ServerState.Instance.ServerService == null?5:ServerState.Instance.ServerService.Settings.MaxClients;
         serverInfoControl.RequestCurrentClientConnectionCount += new EventHandler<CurrentClientConnectionCountEventArgs>(serverInfoControl_RequestCurrentClientConnectionCount);
         serverInfoControl.ServiceName = ServerState.Instance.ServerService == null ? string.Empty : ServerState.Instance.ServiceName;
         _serverInfoControl = serverInfoControl;
         _serverInfoControl.HideUserDetails = Program.ShouldHideUserDetails();

         if (ServerState.Instance.ServerService != null)
         {
            ServerState.Instance.ServerService.Message += new EventHandler<Leadtools.Dicom.Server.Admin.MessageEventArgs>(ServerService_Message);
            ServerState.Instance.ServerService.StatusChange += new EventHandler(ServerService_StatusChange);
            if (ServerState.Instance.ServerService.Status == System.ServiceProcess.ServiceControllerStatus.Running)
            {
               _serverInfoControl.SetStartTime();
            }
         }

         ServerState.Instance.ServerServiceChanged += new EventHandler ( Instance_ServerServiceChanged ) ;
         EventBroker.Instance.Subscribe<ServerSettingsAppliedEventArgs>(new EventHandler<ServerSettingsAppliedEventArgs>(OnSettingsChanged));
      }

      void ServerService_StatusChange(object sender, EventArgs e)
      {
         if (ServerState.Instance.ServerService.Status == System.ServiceProcess.ServiceControllerStatus.Running)
         {
            _serverInfoControl.SetStartTime();
         }
         else if (ServerState.Instance.ServerService.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
         {
            _serverInfoControl.ResetStartTime();
         }
      }

      void OnSettingsChanged(object sender, EventArgs e)
      {
         if (ServerState.Instance.ServerService != null)
         {
            _serverInfoControl.MaximumClientConnectionCount = ServerState.Instance.ServerService.Settings.MaxClients;
         }
      }

      void Instance_ServerServiceChanged(object sender, EventArgs e)
      {
         try
         {
            if (ServerState.Instance.ServerService != null)
            {
               ServerState.Instance.ServerService.Message += new EventHandler<Leadtools.Dicom.Server.Admin.MessageEventArgs> ( ServerService_Message ) ;

               _serverInfoControl.ServiceName = ServerState.Instance.ServiceName;
               ServerState.Instance.ServerServiceChanged += new EventHandler(Instance_ServerServiceChanged);
            }
            
            if ( null != __DbManager )
            {
               // __DbManager.Enabled = ServerState.Instance.ServerService != null ;
               UpdateContainerPagesEnabled();
            }
         }
         catch{}
      }


      delegate void Invoker(int parameter);

      void UpdateServerInfoControlConnectionCount(int count)
      {
         if (_serverInfoControl.InvokeRequired)
         {
            _serverInfoControl.BeginInvoke(new Invoker(UpdateServerInfoControlConnectionCount), count);
         }
         else
         {
            _serverInfoControl.CurrentClientConnectionCount = count;
         }
      }

      void ServerService_Message(object sender, Leadtools.Dicom.Server.Admin.MessageEventArgs e)
      {
         try
         {
            if (e.Message.Message == MessageNames.GetTotalClients)
            {
               int count = 0;
               if
               (
               (e.Message.Success) &&
               (e.Message.Data != null) &&
               (e.Message.Data.Count == 1)
               )
               {
                  count = (int)e.Message.Data[0];
               }
               UpdateServerInfoControlConnectionCount(count);
            }
         }
         catch{}
      }

      private void GetConnectionCount(object data)
      {
         if ((ServerState.Instance.ServerService != null) && (ServerState.Instance.ServerService.Status == System.ServiceProcess.ServiceControllerStatus.Running))
         {
            ServerState.Instance.ServerService.SendMessage(MessageNames.GetTotalClients);
         }
         else
         {
            UpdateServerInfoControlConnectionCount(0);
         }
      }

      void serverInfoControl_RequestCurrentClientConnectionCount(object sender, CurrentClientConnectionCountEventArgs e)
      {
         try
         {
            GetConnectionCount(null);
         }
         catch {}
      }

      private ConnectionStringSettings GetConnectionString
      (
         System.Configuration.Configuration pacsConfig,
         System.Configuration.Configuration machineConfig,
         string dataAccessSectionName
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
                  if (connectionElement.ProductName == ProductName /*|| connectionElement.ServiceName == ServiceName*/ )
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

         if (connectionStringSettings == null)
            connectionStringSettings = GetConnectionString(machineConfig, dataAccessSectionName);
         return connectionStringSettings;
      }

      private ConnectionStringSettings GetConnectionString
      (
         System.Configuration.Configuration machineConfig,
         string dataAccessSectionName
      )
      {
         DataAccessSettings settings;


         try
         {
            settings = machineConfig.GetSection(dataAccessSectionName) as DataAccessSettings;

            if (null == settings)
            {
               return new ConnectionStringSettings();
            }
            else
            {
               ConnectionStringSettings connection;


               connection = machineConfig.ConnectionStrings.ConnectionStrings[settings.ConnectionName];

               if (null == connection)
               {
                  return new ConnectionStringSettings();
               }
               else
               {                  
                  return connection;
               }
            }
         }
         catch (Exception)
         {
            return new ConnectionStringSettings();
         }
      }
   }
}
