// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.Configuration;
using Leadtools.Medical.Winforms;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Demos;
using Leadtools.Medical.Workstation.DataAccessLayer;
using Leadtools.Medical.Workstation.DataAccessLayer.Configuration;
using Leadtools.DicomDemos;
using Leadtools.Medical.Winforms.EventBrokerArgs;
using Leadtools.Medical.Winforms.Properties;
using Leadtools.Medical.Winforms.Monitor;
using Leadtools.Medical.Winforms.Common;
using System.Data.Common;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.Winforms.DatabaseManager;
using System.Diagnostics;
using static Leadtools.Medical.Winforms.GenerateMetadataBackgroundWorker;

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.Winforms.DatabaseManager.Export;
using Leadtools.Medical.Winforms.Anonymize;
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)


namespace Leadtools.Medical.Winforms
{
   public enum DisableCancelButton
   {
      None,
      DicomAdd,
      DicomSearch
   }
   public partial class StorageDatabaseManager : UserControl
   {
      #region Public

      #region Methods

      public StorageDatabaseManager()
      {
         InitializeComponent();

         if (!_DesignMode)
         {
            Init();

            RegisterEvents();
            
            _pageNumber = 1;
            paginationControl1.Enabled = true;
            paginationControl1.MinPageNumber = 1;
            paginationControl1.PageSizeLabel = "Image Level Page Size:";
            
            _optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();
            
            // _optionsAgent will be null for the Medical Workstation
            if (_optionsAgent != null)
            {
               _options = _optionsAgent.Get<DatabaseManagerOptions>(DatabaseManagerOptionsPresenter.DatabaseManagerOptions, new DatabaseManagerOptions());
            }
             
            UpdatePaginationUI();
         }
      }

      public DicomQueryParams GetDicomQueryParams()
      {
         return this.dicomQuery1.GetDicomQueryParams();
      }

      public PrepareSearchDelegate _prepareSearch;

      public PrepareSearchDelegate PrepareSearch
      {
         get { return dicomQuery1.PrepareSearch; }
         set { dicomQuery1.PrepareSearch = value; }
      }

      public void PerformAddDicomFiles()
      {
         tsbAddDicom_Click(this, EventArgs.Empty);
      }

      public void PerformAddDicomDirectory()
      {
         tsbAddDicomDir_Click(this, EventArgs.Empty);
      }

      #endregion

      #region Properties
      
      public bool IsWorking
      {
         get
         {
            return _isWorking;
         }

         private set
         {
            _isWorking = value;
         }
      }

      public string AETitle
      {
         get
         {
            return _AETitle;
         }

         set
         {
            _AETitle = value;
            if (__AddDicomWorker != null)
            {
               __AddDicomWorker.AETitle = _AETitle;
            }
         }
      }

      public string ImplementationClassUID { get; set; }

      public bool DeleteAnnotationsOnImageDelete
      {
         get;
         set;
      }

      public MetadataOptions MetadataOptions
      {
         get;
         set;
      }

      public bool DeleteFilesOnDatabaseDelete
      {
         get
         {
            return _deleteFilesOnDatabaseDelete;
         }
         set
         {
            _deleteFilesOnDatabaseDelete = value;
         }
      }

      public bool BackupFilesOnDatabaseDelete
      {
         get
         {
            return _backupFilesOnDatabaseDelete;
         }
         set
         {
            _backupFilesOnDatabaseDelete = value;
         }
      }

      public string BackupFilesOnDeleteFolder { get; set; }

      public bool CanDelete
      {
         get
         {
            return _canDelete;
         }
         set
         {
            if (value != _canDelete)
            {
               _canDelete = value;

               tsbDelete.Enabled = _canDelete;
            }
         }
      }

      public bool CanEmptyDatabase
      {
         get
         {
            return _canEmptyDatabase;
         }

         set
         {
            if (value != _canEmptyDatabase)
            {
               _canEmptyDatabase = value;

               tsbEmpyDatabase.Enabled = _canEmptyDatabase;
            }
         }
      }

      public bool MergeImportDicom
      {
         get
         {
            return _mergeImportDicom;
         }

         set
         {
            _mergeImportDicom = value;
            tsbAddDicomDir.Visible = !value;
         }
      }

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
      public bool CanChangeSettings
      {
         get
         {
            return _canChangeSettings;
         }

         set
         {
            _canChangeSettings = value;
         }
      }

      public bool EnableExport
      {
         get
         {
            return _enableExport;
         }
         set
         {
            _enableExport = value;
            tsbExportSelected.Visible = value;
            exportSelectedToolStripMenuItem.Visible = value;
         }
      }
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

      #endregion

      #region Events

      public event EventHandler<CancelStoreEventArgs> CancelStore;

      protected bool OnCancelStore(DicomDataSet ds, out string message)
      {
         message = string.Empty;
         if (CancelStore != null)
         {
            CancelStoreEventArgs e = new CancelStoreEventArgs(ds);

            CancelStore(this, e);
            message = e.CancelMessage;
            return e.Cancel;
         }
         return false;
      }

      #endregion

      #region Data Types Definition

      #endregion

      #region Callbacks

      public event EventHandler StatusChange;
      public event EventHandler<StoreCommandEventArgs> ConfigureStoreCommand;

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
      public event EventHandler<StoreCommandEventArgs> ConfigureStoreExportCommand;
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

      #endregion

      #endregion

      #region Protected

      #region Methods

      #endregion

      #region Properties

      #endregion

      #region Events

      #endregion

      #region Data Members

      #endregion

      #region Data Types Definition

      #endregion

      #endregion

      #region Private

      #region Methods

      private void Init()
      {
         DicomEngine.Startup();


         SetPropertyValue(dgvStudies, "DoubleBuffered", true);
#if (LEADTOOLS_V19_OR_LATER)
         SetPropertyValue(dgvStudies, "AutoSizeRowsMode", DataGridViewAutoSizeRowsMode.AllCells);
#endif
         if (DataAccessServices.IsDataAccessServiceRegistered<IStorageDataAccessAgent>())
         {
            __DataAccess = DataAccessServices.GetDataAccessService<IStorageDataAccessAgent>();
         }
         else
         {
            throw new InvalidOperationException(typeof(IStorageDataAccessAgent).Name + " is not registered.");
         }

         if (DataAccessServices.IsDataAccessServiceRegistered<IWorkstationDataAccessAgent>())
         {
            __WsDataAccess = DataAccessServices.GetDataAccessService<IWorkstationDataAccessAgent>();
         }

         // __SearchWorker = new BackgroundWorker();
         _openDicomFileDialog = new OpenFileDialog();

         _openDicomFileDialog.RestoreDirectory = true;

         // __SearchWorker.WorkerSupportsCancellation = true;

         __AddDicomWorker = new AddDicomBackgroundWorker(AETitle, __DataAccess, ImplementationClassUID);
         __RemoveDicomWorker = new RemoveDicomBackgroundWorker(__DataAccess);
         __EmptyDatabaseWorker = new EmptyDatabaseBackgroundWorker(__DataAccess);

         __GenerateMetadataWorker = new GenerateMetadataBackgroundWorker(__DataAccess as IStorageDataAccessAgent4);
#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         __ExportDicomWorker = new ExportDicomBackgroundWorker(__DataAccess);
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

         InitViewTypeCombo();

         EnableButtons(true, DisableCancelButton.None);

         __QueryDataSet                = new DataSet();
         __QueryDataSetHangingProtocol = new DataSet();
      }
      
      private void RegisterEvents()
      {
         dicomQuery1.PerformSearch += new EventHandler<ApplySearchEventArgs>(dicomQuery1_ApplySearch);
         dicomQuery1.CancelSearch += new EventHandler(dicomQuery1_CancelSearch);
         dicomQuery1.ClearSearch += new EventHandler(dicomQuery1_ClearSearch);

         // __SearchWorker.DoWork += new DoWorkEventHandler(__SearchWorker_DoWork);
         // __SearchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(__SearchWorker_RunWorkerCompleted);

         __AddDicomWorker.ProgressChanged += new ProgressChangedEventHandler(__AddDicomWorker_ProgressChanged);
         __AddDicomWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(__AddDicomWorker_RunWorkerCompleted);
         __AddDicomWorker.StoreCommandCreated += new EventHandler<StoreCommandEventArgs>(__AddDicomWorker_StoreCommandCreated);
         __AddDicomWorker.CancelStore += new EventHandler<CancelStoreEventArgs>(__AddDicomWorker_CanStore);

         __GenerateMetadataWorker.ProgressChanged += __GenerateMetadataWorker_ProgressChanged;
         __GenerateMetadataWorker.RunWorkerCompleted += __GenerateMetadataWorker_RunWorkerCompleted;
         // __GenerateMetadataWorker.CancelGenerateMetadata += __GenerateMetadataWorker_CancelGenerateMetadata;

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         __ExportDicomWorker.ProgressChanged += new ProgressChangedEventHandler(__ExportDicomWorker_ProgressChanged);
         __ExportDicomWorker.StoreCommandCreated += new EventHandler<StoreCommandEventArgs>(__ExportDicomWorker_StoreCommandCreated);
         __ExportDicomWorker.RunWorkerCompleted +=new RunWorkerCompletedEventHandler(__ExportDicomWorker_RunWorkerCompleted);
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

         __RemoveDicomWorker.ProgressChanged += new ProgressChangedEventHandler(__RemoveDicomWorker_ProgressChanged);
         __RemoveDicomWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(__RemoveDicomWorker_RunWorkerCompleted);

         __EmptyDatabaseWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(__EmptyDatabaseWorker_RunWorkerCompleted);

         tsbAddDicom.Click += new EventHandler(tsbAddDicom_Click);
         tsbAddDicomDir.Click += new EventHandler(tsbAddDicomDir_Click);
         tsbDelete.Click += new EventHandler(tsbDelete_Click);
         tsbEmpyDatabase.Click += new EventHandler(tsbEmpyDatabase_Click);
         tsbShowReport.Click += new EventHandler(tsbShowReport_Click);
         tsbCancel.Click += new EventHandler(tsbCancel_Click);

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         tsbExportSelected.Click += new EventHandler(tsbExportSelected_Click);
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)


         tsbGenerateMetadata.Click += tsbGenerateMetadata_Click;

         addDicomToolStripMenuItem.Click += tsbAddDicom_Click;
         exportSelectedToolStripMenuItem.Click += tsbExportSelected_Click;
         deleteSelectedToolStripMenuItem.Click += tsbDelete_Click;
         emptyDatabaseToolStripMenuItem.Click += tsbEmpyDatabase_Click;
         generateMetadataToolStripMenuItem.Click += tsbGenerateMetadata_Click;
         statusReportToolStripMenuItem.Click += tsbShowReport_Click;
         cancelToolStripMenuItem.Click += tsbCancel_Click;

         tscDisplayLevel.ComboBox.SelectionChangeCommitted += new EventHandler(tscDisplayLevel_SelectionChangeCommitted);

         paginationControl1.FirstClicked += new EventHandler(paginationControl1_FirstClicked);
         paginationControl1.LastClicked += new EventHandler(paginationControl1_LastClicked);
         paginationControl1.NextClicked += new EventHandler(paginationControl1_NextClicked);
         paginationControl1.PreviousClicked += new EventHandler(paginationControl1_PreviousClicked);
         paginationControl1.GotoPageClicked += new EventHandler(paginationControl1_GotoPageClicked);

         __DataAccess.QueryCompositeInstancesStarting += new EventHandler<QueryCompositeInstancesArgs>(__DataAccess_QueryCompositeInstancesStarting);
         __DataAccess.QueryCompositeInstancesCompleted += new EventHandler<QueryCompositeInstancesArgs>(__DataAccess_QueryCompositeInstancesCompleted);
#if (LEADTOOLS_V19_OR_LATER)
         if (__DataAccess3 != null)
         {
            __DataAccess3.QueryHangingProtocolStarting += new EventHandler<QueryCompositeInstancesArgs>(__DataAccess_QueryHangingProtocolStarting);
            __DataAccess3.QueryHangingProtocolCompleted += new EventHandler<QueryCompositeInstancesArgs>(__DataAccess_QueryHangingProtocolCompleted);
         }
#endif         
         EventBroker.Instance.Subscribe <DatabaseManagerOptionsAppliedEventArgs> ( DatabaseManagerOptionsAppliedHandler ) ;
      }


      private void UnRegisterEvents()
      {
         dicomQuery1.PerformSearch -= new EventHandler<ApplySearchEventArgs>(dicomQuery1_ApplySearch);
         dicomQuery1.CancelSearch -= new EventHandler(dicomQuery1_CancelSearch);
         dicomQuery1.ClearSearch -= new EventHandler(dicomQuery1_ClearSearch);

         // __SearchWorker.DoWork += new DoWorkEventHandler(__SearchWorker_DoWork);
         // __SearchWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(__SearchWorker_RunWorkerCompleted);

         __AddDicomWorker.ProgressChanged -= new ProgressChangedEventHandler(__AddDicomWorker_ProgressChanged);
         __AddDicomWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(__AddDicomWorker_RunWorkerCompleted);
         __AddDicomWorker.StoreCommandCreated -= new EventHandler<StoreCommandEventArgs>(__AddDicomWorker_StoreCommandCreated);
         __AddDicomWorker.CancelStore -= new EventHandler<CancelStoreEventArgs>(__AddDicomWorker_CanStore);

         __GenerateMetadataWorker.ProgressChanged -= __GenerateMetadataWorker_ProgressChanged;
         __GenerateMetadataWorker.RunWorkerCompleted -= __GenerateMetadataWorker_RunWorkerCompleted;
         // __GenerateMetadataWorker.CancelGenerateMetadata -= __GenerateMetadataWorker_CancelGenerateMetadata;

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         __ExportDicomWorker.ProgressChanged -= new ProgressChangedEventHandler(__ExportDicomWorker_ProgressChanged);
         __ExportDicomWorker.StoreCommandCreated -= new EventHandler<StoreCommandEventArgs>(__ExportDicomWorker_StoreCommandCreated);
         __ExportDicomWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(__ExportDicomWorker_RunWorkerCompleted);
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

         __RemoveDicomWorker.ProgressChanged -= new ProgressChangedEventHandler(__RemoveDicomWorker_ProgressChanged);
         __RemoveDicomWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(__RemoveDicomWorker_RunWorkerCompleted);

         __EmptyDatabaseWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(__EmptyDatabaseWorker_RunWorkerCompleted);

         tsbAddDicom.Click -= new EventHandler(tsbAddDicom_Click);
         tsbAddDicomDir.Click -= new EventHandler(tsbAddDicomDir_Click);
         tsbDelete.Click -= new EventHandler(tsbDelete_Click);
         tsbEmpyDatabase.Click -= new EventHandler(tsbEmpyDatabase_Click);
         tsbShowReport.Click -= new EventHandler(tsbShowReport_Click);
         tsbCancel.Click -= new EventHandler(tsbCancel_Click);

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         tsbExportSelected.Click -= new EventHandler(tsbExportSelected_Click);
#endif //#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

         tsbGenerateMetadata.Click -= tsbGenerateMetadata_Click;

         addDicomToolStripMenuItem.Click -= tsbAddDicom_Click;
         exportSelectedToolStripMenuItem.Click     -= tsbExportSelected_Click;
         deleteSelectedToolStripMenuItem.Click     -= tsbDelete_Click;
         emptyDatabaseToolStripMenuItem.Click      -= tsbEmpyDatabase_Click;
         generateMetadataToolStripMenuItem.Click   -= tsbGenerateMetadata_Click;
         statusReportToolStripMenuItem.Click       -= tsbShowReport_Click;
         cancelToolStripMenuItem.Click             -= tsbCancel_Click;


         tscDisplayLevel.ComboBox.SelectionChangeCommitted -= new EventHandler(tscDisplayLevel_SelectionChangeCommitted);

         paginationControl1.FirstClicked -= new EventHandler(paginationControl1_FirstClicked);
         paginationControl1.LastClicked -= new EventHandler(paginationControl1_LastClicked);
         paginationControl1.NextClicked -= new EventHandler(paginationControl1_NextClicked);
         paginationControl1.PreviousClicked -= new EventHandler(paginationControl1_PreviousClicked);
         paginationControl1.GotoPageClicked -= new EventHandler(paginationControl1_GotoPageClicked);

         __DataAccess.QueryCompositeInstancesStarting -= new EventHandler<QueryCompositeInstancesArgs>(__DataAccess_QueryCompositeInstancesStarting);
         __DataAccess.QueryCompositeInstancesCompleted -= new EventHandler<QueryCompositeInstancesArgs>(__DataAccess_QueryCompositeInstancesCompleted);
#if (LEADTOOLS_V19_OR_LATER)
         if (__DataAccess3 != null)
         {
            __DataAccess3.QueryHangingProtocolStarting -= new EventHandler<QueryCompositeInstancesArgs>(__DataAccess_QueryHangingProtocolStarting);
            __DataAccess3.QueryHangingProtocolCompleted -= new EventHandler<QueryCompositeInstancesArgs>(__DataAccess_QueryHangingProtocolCompleted);
         }
#endif         
         EventBroker.Instance.Unsubscribe <DatabaseManagerOptionsAppliedEventArgs> ( DatabaseManagerOptionsAppliedHandler ) ;
      }
      
       private void DatabaseManagerOptionsAppliedHandler ( object sender, DatabaseManagerOptionsAppliedEventArgs e )
      {
         // _options.PageSize = e.PageSize;
         // _options.PaginationDisplay = e.PaginationDisplay;

         if (_optionsAgent != null)
         {
            _options = _optionsAgent.Get<DatabaseManagerOptions>(DatabaseManagerOptionsPresenter.DatabaseManagerOptions, new DatabaseManagerOptions());
            ClearSearch();
            UpdatePaginationUI();
            EnableButtons(true, DisableCancelButton.None);
         }
      }

      void __AddDicomWorker_CanStore(object sender, CancelStoreEventArgs e)
      {
         string message;

         e.Cancel = OnCancelStore(e.DataSet, out message);
         if (e.Cancel)
         {
            e.CancelMessage = message;
         }
      }

      private void InitViewTypeCombo()
      {
         Dictionary<string, DicomInformationView> viewNameType;


         viewNameType = new Dictionary<string, DicomInformationView>();

         viewNameType.Add("Patient Level", DicomInformationView.PatientLevel);
         viewNameType.Add("Study Level", DicomInformationView.StudiesLevel);
         viewNameType.Add("Series Level", DicomInformationView.SeriesLevel);
         viewNameType.Add("Image Level", DicomInformationView.ImagesLevel);
#if (LEADTOOLS_V19_OR_LATER)
         if (__DataAccess3 != null && __DataAccess3.HangingProtocolSupported)
         {
            viewNameType.Add("Hanging Protocol", DicomInformationView.HangingProtocol);
            //viewNameType.Add("Hanging Protocol Definition", DicomInformationView.HangingProtocolDefinition);
         }
#endif
         tscDisplayLevel.ComboBox.DataSource = new BindingSource(viewNameType, null);
         tscDisplayLevel.ComboBox.DisplayMember = "key";
         tscDisplayLevel.ComboBox.ValueMember = "value";

         tscDisplayLevel.ComboBox.BindingContext = this.BindingContext;

         try
         {
            tscDisplayLevel.ComboBox.SelectedIndex = 3;
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false, "ComboBox was not bound!");
            //do nothing! 
            //for some reason the combobox was not filled 
            //which means it didn't get bound yet
         }

      }

      private void EnsureReportVisible()
      {
         if (StatusReport.Instance.Visible)
         {
            StatusReport.Instance.Focus();
         }
         else
         {
            if (null == StatusReport.Instance.Owner)
            {
               StatusReport.Instance.Owner = this.FindForm();
            }

            StatusReport.Instance.Show(this);
         }
      }

      private void AddDicomFiles(string[] files)
      {
         EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(true));
         
         __AddDicomWorker.RunWorkerAsync(files);

         EnableButtons(false, DisableCancelButton.DicomSearch);

         EnsureReportVisible();

         StatusReport.Instance.BeginOperation(@"Add DICOM Files:");
      }

      private void RefreshLastQuery()
      {
         MatchingParameterCollection queryParams = IsSelectedView(DicomInformationView.HangingProtocol) ? __LastqueryParamsHangingProtocol : __LastqueryParams;
         try
         {
            dicomQuery1_ApplySearch(this, new ApplySearchEventArgs(queryParams));

            __Refreshing = true;
         }
         catch (Exception exception)
         {
            MessageBox.Show(this, exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void EnablePopupmenuButtons()
      {
         addDicomToolStripMenuItem.Enabled = tsbAddDicom.Enabled;
         exportSelectedToolStripMenuItem.Enabled = tsbExportSelected.Enabled;
         deleteSelectedToolStripMenuItem.Enabled = tsbDelete.Enabled;
         emptyDatabaseToolStripMenuItem.Enabled = tsbEmpyDatabase.Enabled;
         generateMetadataToolStripMenuItem.Enabled = tsbGenerateMetadata.Enabled;
         statusReportToolStripMenuItem.Enabled = tsbShowReport.Enabled;
         cancelToolStripMenuItem.Enabled = tsbCancel.Enabled;
      }

      private void EnableButtons(bool state, DisableCancelButton disableCancelButton)
      {
         bool enableMetadataButton = true;
         DicomInformationView selectedView = GetSelectedView();
         if (selectedView == DicomInformationView.HangingProtocol  || selectedView == DicomInformationView.HangingProtocolDefinition)
         {
            enableMetadataButton = false;
         }


#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         tsbExportSelected.Enabled = state;
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         tsbDelete.Enabled = state && CanDelete;
         tsbEmpyDatabase.Enabled = state && CanEmptyDatabase;
         tsbAddDicom.Enabled = state;
         tsbAddDicomDir.Enabled = state;
         tsbGenerateMetadata.Enabled = state && enableMetadataButton;

         tsbCancel.Enabled = !state;
         pnlStatus.Visible = !state;
         
         // progressBar1.Visible = !state;
         
         bool isEmpty = (dgvStudies.RowCount == 0);
         paginationControl1.Visible = state;
         if (_options != null)
         {
            switch (_options.PaginationDisplay)
            {
               case PaginationDisplayOptions.ShowNever:
                  paginationControl1.Visible = false;
                  pnlStatus.Visible = !state;
                  break;

               case PaginationDisplayOptions.ShowWhenNecessary:
                  pnlStatus.Visible = (paginationControl1.MaxPageNumber > 1) && !isEmpty;
                  paginationControl1.Visible = pnlStatus.Visible;
                  break;

               case PaginationDisplayOptions.ShowAlways:
                  pnlStatus.Visible = !isEmpty;
                  paginationControl1.Visible = pnlStatus.Visible;
                  break;
            }
         }


         paginationControl1.EnableItems(state);

         progressBar1.Value = 0;

         IsWorking = !state;

         if (state == false)
         {
            switch (disableCancelButton)
            {
               case DisableCancelButton.None:
                  break;
               case DisableCancelButton.DicomAdd:
                  tsbCancel.Enabled = false;
                  break;
               case DisableCancelButton.DicomSearch:
                  break;
            }
         }

         EnablePopupmenuButtons();
       
         
         dicomQuery1.EnableItems(state, disableCancelButton == DisableCancelButton.DicomAdd);
         OnStatusChange(this, EventArgs.Empty);
      }

      private void OnStatusChange(object sender, EventArgs eventArgs)
      {
         if (null != StatusChange)
         {
            StatusChange(sender, eventArgs);
         }
      }

      private void DeletePhysicalImages
      (
         ViewGenerator.ViewDataRow deletedRow
      )
      {
         try
         {
            List<DataRow> imageRows = GetImageRows(deletedRow);

            DeletePhysicalImages(imageRows.ToArray());
         }
         catch (Exception)
         {
            throw;
         }
      }

      private void DeletePhysicalImages
      (
         DataTable images
      )
      {
         try
         {
            // CompositeInstanceDataSet.InstanceRow[] imageRows;


            DataRow[] imageRows = new DataRow[images.Rows.Count];

            images.Rows.CopyTo(imageRows, 0);

            DeletePhysicalImages(imageRows);
         }
         catch (Exception)
         {
            throw;
         }
      }

      private void DeletePhysicalImages
      (
         /*CompositeInstanceDataSet.InstanceRow*/ DataRow[] imageRows
      )
      {
         try
         {
            DicomInstanceDeleteCommand deleteCmd = new DicomInstanceDeleteCommand ( __DataAccess ) ;

            deleteCmd.BackupFilesOnDatabaseDelete = BackupFilesOnDatabaseDelete ;
            deleteCmd.BackupFilesOnDeleteFolder = BackupFilesOnDeleteFolder ;
            deleteCmd.ContinueOnError = true ;
            deleteCmd.DeleteFiles = DeleteFilesOnDatabaseDelete ;
            
            deleteCmd.InstanceDeleted += new EventHandler<InstanceEventArgs>(deleteCmd_InstanceDeleted);
            deleteCmd.InstanceDeleteError += new EventHandler<InstanceEventArgs>(deleteCmd_InstanceDeleteError);
            deleteCmd.InstanceDeleting += new EventHandler<InstanceEventArgs>(deleteCmd_InstanceDeleting);
            deleteCmd.ReferencedImageDeleted += new EventHandler<ReferencedImageEventArgs>(deleteCmd_ReferencedImageDeleted);
            deleteCmd.ReferencedImageDeleteError += new EventHandler<ReferencedImageEventArgs>(deleteCmd_ReferencedImageDeleteError);

            deleteCmd.DeleteInstances ( imageRows ) ;
         }
         catch (Exception)
         {
            throw;
         }
      }

      void deleteCmd_ReferencedImageDeleteError(object sender, ReferencedImageEventArgs e)
      {
         string sReferencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(e.ReferencedImage);

         StatusReport.Instance.OperationErrorStatus(string.Format("Failed to delete file: {0}", sReferencedFile));

         EnsureReportVisible();
      }

      void deleteCmd_ReferencedImageDeleted(object sender, ReferencedImageEventArgs e)
      {
         string sReferencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(e.ReferencedImage);
         EventBroker.Instance.PublishEvent<ImageFileDeletedEventArgs>(this, new ImageFileDeletedEventArgs(sReferencedFile));
      }

      void deleteCmd_InstanceDeleting(object sender, InstanceEventArgs e)
      {
         if (e.Instance.IsHangingProtocol() == false)
         {
            DeleteAnnotations(RegisteredDataRows.InstanceInfo.GetElementValue(e.Instance, DicomTag.SOPInstanceUID));
            DeleteVolumes(RegisteredDataRows.InstanceInfo.GetElementValue(e.Instance, DicomTag.SeriesInstanceUID));
         }
      }

      void deleteCmd_InstanceDeleteError(object sender, InstanceEventArgs e)
      {
         string sReferencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(e.Instance);

         StatusReport.Instance.OperationErrorStatus(string.Format("Failed to delete file: {0}", sReferencedFile));
         
         EnsureReportVisible();
      }

      void deleteCmd_InstanceDeleted(object sender, InstanceEventArgs e)
      {
         string sReferencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(e.Instance);
      
         EventBroker.Instance.PublishEvent<DicomFileDeletedEventArgs>(this, new DicomFileDeletedEventArgs(sReferencedFile));
      }

      private void DeleteVolumes(string seriesInstanceUID)
      {
         if (string.IsNullOrEmpty(seriesInstanceUID))
            return;

         if (null != _wsDataAccess)
         {
            VolumeIdentifier[] volumes;


            volumes = __WsDataAccess.GetVolumes(seriesInstanceUID);

            foreach (VolumeIdentifier volume in volumes)
            {
               __WsDataAccess.DeleteVolume(volume);
            }
         }
      }

      private void DeleteAnnotations(string sopInstanceUID)
      {
         if (string.IsNullOrEmpty(sopInstanceUID))
         {
            return;
         }

         try
         {
            if (null == __WsDataAccess || !DeleteAnnotationsOnImageDelete)
            {
               return;
            }

            AnnotationIdentifier[] annotations;


            annotations = __WsDataAccess.GetAnnotationIdentifier(sopInstanceUID);

            if (null != annotations && annotations.Length > 0)
            {
               foreach (AnnotationIdentifier annotation in annotations)
               {
                  string annotationFile;


                  annotationFile = __WsDataAccess.GetAnnotationFile(annotation);

                  __WsDataAccess.DeleteAnnotationObject(annotation);

                  if (File.Exists(annotationFile))
                  {
                     File.Delete(annotationFile);
                  }
               }
            }
         }
         catch (Exception)
         {
            throw;
         }
      }

      //private void DeleteDirectories(string directory)
      //{
      //   string[] remainingFiles = Directory.GetFiles(directory);
      //   string[] remainingDirs = Directory.GetDirectories(directory);

      //   if ((remainingFiles.Length == 1) &&
      //        (Path.GetFileName(remainingFiles[0]) == "key") &&
      //        remainingDirs.Length == 0)
      //   {
      //      File.Delete(remainingFiles[0]);

      //      Directory.Delete(directory);

      //      DeleteDirectories(Directory.GetParent(directory).FullName);
      //   }
      //}

      private List<DataRow> GetImageRows
      (
         ViewGenerator.ViewDataRow deletedRow
      )
      {
         List<DataRow> imageRows = new List<DataRow>();

         if (deletedRow.OriginalRow is CompositeInstanceDataSet.InstanceRow)
         {
            imageRows.Add((CompositeInstanceDataSet.InstanceRow)deletedRow.OriginalRow);
         }
#if (LEADTOOLS_V19_OR_LATER)
         else if (deletedRow.OriginalRow is HangingProtocolDataset.HangingProtocolRow)
         {
            imageRows.Add(deletedRow.OriginalRow);
         }
#endif
         else
         {
            FillImagesRows(deletedRow.OriginalRow, imageRows);
         }

         return imageRows;
      }

      private void FillImagesRows
      (
         DataRow parentRow,
         List<DataRow> imageRows
      )
      {
         if (parentRow is CompositeInstanceDataSet.PatientRow)
         {
            CompositeInstanceDataSet.PatientRow patient = parentRow as CompositeInstanceDataSet.PatientRow;


            DataRow[] studies = patient.GetStudyRows();

            foreach (DataRow study in studies)
            {
               FillImagesRows(study, imageRows);
            }
         }
         else if (parentRow is CompositeInstanceDataSet.StudyRow)
         {
            CompositeInstanceDataSet.StudyRow study = parentRow as CompositeInstanceDataSet.StudyRow;
            DataRow[] series = study.GetSeriesRows();

            foreach (DataRow seriesRow in series)
            {
               FillImagesRows(seriesRow, imageRows);
            }
         }
         else if (parentRow is CompositeInstanceDataSet.SeriesRow)
         {
            CompositeInstanceDataSet.SeriesRow series = parentRow as CompositeInstanceDataSet.SeriesRow;

            imageRows.AddRange(series.GetInstanceRows());
         }
      }

      private List<string> _wrapModeTrueColumnNames = new List<string>(new string[]{"Modalities", "Lateralities", "Study Descriptions", "Body Parts Examined", "Protocol Names"});

      private void ApplyView(DicomInformationView selectedValue)
      {

         List<DataGridViewColumn> gridColumns;


         if (__CachedViews.ContainsKey(selectedValue))
         {
            gridColumns = __CachedViews[selectedValue];
         }
         else
         {
            string viewFileName;
            DataSet viewDataSet;


            viewFileName = selectedValue.ToString() + ".xml";
            viewFileName = Path.Combine(Application.StartupPath, viewFileName);
            viewDataSet = new DataSet();
            gridColumns = new List<DataGridViewColumn>();

            if (!File.Exists(viewFileName))
            {
               //Assembly thisAssem ;
               //Stream viewStream ;
               FileStream fs;
               //StreamReader reader ;
               string xmlFileContents;
               StreamWriter writer;


               //thisAssem       = GetType().Assembly;


               xmlFileContents = GetViewContents(selectedValue);
               //viewStream      = 

               //thisAssem.GetManifestResourceStream("Leadtools.Medical.Winforms.Control.StoreAddIn.DatabaseManager.ViewColumnMappings." + selectedValue.ToString ( ) + ".xml" );
               fs = File.Create(viewFileName);
               //reader          = new StreamReader(viewStream);
               //xmlFileContents = reader.ReadToEnd();
               writer = new StreamWriter(fs);

               writer.Write(xmlFileContents);

               //reader.Close ( ) ;
               writer.Close();
               fs.Close();
            }


            try
            {
               viewDataSet.ReadXml(viewFileName);
            }
            catch (Exception)
            {
               MessageBox.Show(this, "Couldn't apply selected view information. View file is corrupted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

               return;
            }

            int displayIndex = 0;

            foreach (DataRow viewRow in viewDataSet.Tables[0].Rows)
            {
               DataGridViewColumn column;
               string columnName = viewRow[1].ToString();

               if(columnName == "Referenced File")
               {
                  DataGridViewLinkColumn links = new DataGridViewLinkColumn();

                  links.LinkColor = Color.Blue;
                  links.TrackVisitedState = false;                  
                  column = links;
                  column.Name = viewRow[0].ToString();
                  column.DataPropertyName = viewRow[0].ToString();
                  column.HeaderText = viewRow[1].ToString();
                  column.Visible = (bool)viewRow[3];
                  column.DisplayIndex = displayIndex;
                  column.SortMode = DataGridViewColumnSortMode.Automatic;
               }
               else
               {
                  column = new DataGridViewTextBoxColumn();

                  column.Name = viewRow[0].ToString();
                  column.DataPropertyName = viewRow[0].ToString();
                  column.HeaderText = viewRow[1].ToString();
                  column.Visible = (bool)viewRow[3];
                  column.DisplayIndex = displayIndex;
               }
#if (LEADTOOLS_V19_OR_LATER)
               if (_wrapModeTrueColumnNames.Contains(columnName))
               {
                  column.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
               }
#endif // #if (LEADTOOLS_V19_OR_LATER)
               gridColumns.Add(column);

               displayIndex++;
            }

            __CachedViews.Add(selectedValue, gridColumns);
         }

         dgvStudies.SuspendLayout();

         try
         {
            dgvStudies.Columns.Clear();

            dgvStudies.AutoGenerateColumns = false;

            dgvStudies.Columns.AddRange(gridColumns.ToArray());
         }
         finally
         {
            dgvStudies.ResumeLayout();
         }
      }

      private static string GetViewContents(DicomInformationView view)
      {
         if (view == DicomInformationView.PatientLevel)
         {
            return Leadtools.Medical.Winforms.Properties.Resources.PatientLevel;
         }
         else if (view == DicomInformationView.StudiesLevel)
         {
            return Leadtools.Medical.Winforms.Properties.Resources.StudiesLevel;
         }
         else if (view == DicomInformationView.SeriesLevel)
         {
            return Leadtools.Medical.Winforms.Properties.Resources.SeriesLevel;
         }
         else if (view == DicomInformationView.ImagesLevel)
         {
            return Leadtools.Medical.Winforms.Properties.Resources.ImagesLevel;
         }
#if (LEADTOOLS_V19_OR_LATER)
         else if (view == DicomInformationView.HangingProtocol)
         {
            return Leadtools.Medical.Winforms.Properties.Resources.HangingProtocol;
         }
         else if (view == DicomInformationView.HangingProtocolDefinition)
         {
            return Leadtools.Medical.Winforms.Properties.Resources.HangingProtocolDefinition;
         }
#endif
         else
         {
            return string.Empty;
         }
      }

      private void SetDisplayedRecordsCount(int count)
      {
         if (count > 0)
         {
            string text = " record";

            if (count > 1)
            {
               text = text + "s";
            }

            RecordsCountToolStripLabel.Text = "(" + count.ToString() + ")" + text;
         }
         else
         {
            RecordsCountToolStripLabel.Text = string.Empty;
         }
      }

      #endregion

      #region Properties

      private IStorageDataAccessAgent __DataAccess
      {
         get
         {
            return _dataAccess;
         }

         set
         {
            _dataAccess = value;
         }
      }
#if (LEADTOOLS_V19_OR_LATER)   
      private IStorageDataAccessAgent3 __DataAccess3
      {
         get
         {
            return _dataAccess as IStorageDataAccessAgent3;
         }
      }
#else
      private IStorageDataAccessAgent __DataAccess3
      {
         get
         {
            return null;
         }
      }
#endif

      private IWorkstationDataAccessAgent __WsDataAccess
      {
         get
         {
            return _wsDataAccess;
         }

         set
         {
            _wsDataAccess = value;
         }
      }

      //private BackgroundWorker __SearchWorker
      //{
      //   get
      //   {
      //      return _searchWorker;
      //   }

      //   set
      //   {
      //      _searchWorker = value;
      //   }
      //}

      private AddDicomBackgroundWorker __AddDicomWorker
      {
         get
         {
            return _addDicomWorker;
         }

         set
         {
            _addDicomWorker = value;
         }
      }

      private GenerateMetadataBackgroundWorker __GenerateMetadataWorker
      {
         get
         {
            return _generateMetadataDicomWorker;
         }

         set
         {
            _generateMetadataDicomWorker = value;
         }
      }

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
      private ExportDicomBackgroundWorker __ExportDicomWorker
      {
         get
         {
            return _exportDicomWorker;
         }

         set
         {
            _exportDicomWorker = value;
         }
      }
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

      private RemoveDicomBackgroundWorker __RemoveDicomWorker
      {
         get
         {
            return _removeDicomWorker;
         }

         set
         {
            _removeDicomWorker = value;
         }
      }

      private EmptyDatabaseBackgroundWorker __EmptyDatabaseWorker
      {
         get
         {
            return _emptyDatabaseWorker;
         }

         set
         {
            _emptyDatabaseWorker = value;
         }
      }

      private bool _DesignMode
      {
         get
         {
            return (this.GetService(typeof(IDesignerHost)) != null) ||
                   (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime);
         }
      }

      private DataSet /*CompositeInstanceDataSet*/ __QueryDataSet
      {
         get
         {
            return _queryDataSet;
         }

         set
         {
            _queryDataSet = value;
         }
      }

      private DataSet __QueryDataSetHangingProtocol
      {
         get
         {
            return _queryDataSetHangingProtocol;
         }

         set
         {
            _queryDataSetHangingProtocol = value;
         }
      }

      private DataSet __ActiveQueryDataSet
      {
         set
         {
            if (IsSelectedViewHangingProtocol())
            {
               __QueryDataSetHangingProtocol = value;
            }
            else
            {
               __QueryDataSet = value;
            }
         }

         get
         {
            if (IsSelectedViewHangingProtocol())
            {
               return __QueryDataSetHangingProtocol;
            }
            else
            {
               return __QueryDataSet;
            }
         }
      }
      private MatchingParameterCollection __LastqueryParams
      {
         get
         {
            return _lastqueryParams;
         }

         set
         {
            _lastqueryParams = value;
         }
      }

      private MatchingParameterCollection __LastqueryParamsHangingProtocol
      {
         get
         {
            return _lastqueryParamsHangingProtocol;
         }

         set
         {
            _lastqueryParamsHangingProtocol = value;
         }
      }

      private bool __Refreshing
      {
         get
         {
            return _refreshing;
         }

         set
         {
            _refreshing = value;
         }
      }

      private Dictionary<DicomInformationView, List<DataGridViewColumn>> __CachedViews
      {
         get
         {
            return _cachedViews;
         }

         set
         {
            _cachedViews = value;
         }
      }

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
      private ExportOptions ExportSettings
      {
         get
         {
            // These can only be modified here
            if (_exportSettings == null)
            {
               if (_optionsAgent != null)
               {
                  _exportSettings = _optionsAgent.Get<ExportOptions>(ExportOptions.OptionsKey, new ExportOptions());
               }
            }
            if (_exportSettings == null)
            {
               _exportSettings = new ExportOptions();
            }
            return _exportSettings;
         }
         set
         {
            if (_optionsAgent != null)
            {
               _optionsAgent.Set(ExportOptions.OptionsKey, value);
            }
            _exportSettings = value;
         }
      }

      public AnonymizeScripts Scripts
      {
         get
         {
            // Must always read the scripts, because they can also be changed from the settings dialog
            if (_optionsAgent != null)
            {
               _scripts = _optionsAgent.Get<AnonymizeScripts>(AnonymizeOptionsPresenter.AnonymizeOptionsKey, new AnonymizeScripts(true));
            }
            if (_scripts == null)
            {
               _scripts = new AnonymizeScripts(true);
            }
            return _scripts;
         }
         set
         {
            if (_optionsAgent != null)
            {
               _optionsAgent.Set(AnonymizeOptionsPresenter.AnonymizeOptionsKey, value);
            }
            _scripts = value;
         }
      }
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

      #endregion

      #region Events
      
      private int IncrementPage()
      {
         if (_pageNumber < _options.MaxPageNumber)
         {
            _pageNumber++;
         }
         return _pageNumber;
      }
      
      private int DecrementPage()
      {
         if (_pageNumber > 1)
         {
            _pageNumber--;
         }
         return _pageNumber;
      }

      void UpdatePaginationUI()
      {
         paginationControl1.PageSize = _options.PageSize;
         paginationControl1.MaxPageNumber = _options.MaxPageNumber;
         paginationControl1.PageNumber = _pageNumber;
         paginationControl1.UpdateStatus();
      }
      
      void paginationControl1_PreviousClicked(object sender, EventArgs e)
      {
         try
         {
            EnableButtons(false, DisableCancelButton.DicomAdd);
            DecrementPage();
            ApplySearch(__LastqueryParams, false);

         }
         catch (Exception exception)
         {
            MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            // UpdatePaginationUI();
         }
      }

      void paginationControl1_LastClicked(object sender, EventArgs e)
      {
         try
         {
            _pageNumber = _options.MaxPageNumber;
            EnableButtons(false, DisableCancelButton.DicomAdd);
            ApplySearch(__LastqueryParams, false);
         }
         catch (Exception exception)
         {
            MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      void paginationControl1_FirstClicked(object sender, EventArgs e)
      {
         try
         {
            _pageNumber = 1;
            EnableButtons(false, DisableCancelButton.DicomAdd);
            ApplySearch(__LastqueryParams, false);
         }
         catch (Exception exception)
         {
            MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
      
      void paginationControl1_NextClicked(object sender, EventArgs e)
      {
         try
         {
            EnableButtons(false, DisableCancelButton.DicomAdd);
            
            IncrementPage();
            ApplySearch(__LastqueryParams, false);
            
         }
         catch (Exception exception)
         {
            MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            // UpdatePaginationUI();
         }
      }
      
      void paginationControl1_GotoPageClicked(object sender, EventArgs e)
      {
         try
         {
            EnableButtons(false, DisableCancelButton.DicomAdd);
            _pageNumber = paginationControl1.PageNumber;
            ApplySearch(__LastqueryParams, false);
            
         }
         catch (Exception exception)
         {
            MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            // UpdatePaginationUI();
         }
      }


      DicomInformationView GetSelectedView()
      {
         DicomInformationView view = DicomInformationView.ImagesLevel;
         if (tscDisplayLevel.ComboBox != null)
         {
            view = (DicomInformationView)tscDisplayLevel.ComboBox.SelectedValue;
         }
         return view;
      }

      bool IsSelectedView(DicomInformationView view)
      {
         DicomInformationView selectedView = GetSelectedView();
         return (selectedView == view);
      }

      bool IsSelectedViewHangingProtocol()
      {
         DicomInformationView selectedView = GetSelectedView();
         return (selectedView == DicomInformationView.HangingProtocol) ||(selectedView == DicomInformationView.HangingProtocolDefinition);
      }

      void dicomQuery1_ApplySearch(object sender, ApplySearchEventArgs e)
      {
         try
         {
            //if (__SearchWorker.IsBusy)
            //{
            //   throw new InvalidOperationException("Another search is already running.");
            //}
   
            // EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(true));
            
             // __SearchWorker.RunWorkerAsync(e.QueryParams);

            EnableButtons(false, DisableCancelButton.DicomAdd);
            
            ApplySearch(e.QueryParams, true);
           
            __LastqueryParams = e.QueryParams;

            if (IsSelectedViewHangingProtocol())
            {
               __LastqueryParamsHangingProtocol = e.QueryParams;
            }
            else
            {
               __LastqueryParams = e.QueryParams;
            }
         }
         catch (Exception exception)
         {
            MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
      
      void ApplySearch(MatchingParameterCollection query, bool getTotalInstanceCount)
      {
         try
         {
            if (query == null)
            {
               query = new MatchingParameterCollection();
            }

            _options.PageSize = paginationControl1.PageSize;
            if (getTotalInstanceCount)
            {
               // This occurs when doing an initial search (as opposed to looking at additional pages)
               int totalInstanceCount = 0;
#if (LEADTOOLS_V19_OR_LATER)
               if (IsSelectedViewHangingProtocol() && (__DataAccess3 != null))
               {
                  totalInstanceCount = __DataAccess3.FindHangingProtocolCount(query); ;
               }
               else
               {
                  totalInstanceCount = __DataAccess.FindCompositeInstancesCount(query); ;
               }
#else
               totalInstanceCount = __DataAccess.FindCompositeInstancesCount(query); ;
#endif


               double totalPages = ((double)totalInstanceCount / (double)_options.PageSize);
               _options.MaxPageNumber = (int)Math.Ceiling(totalPages); // - 1;
               if (_options.MaxPageNumber == 0)
               {
                  _options.MaxPageNumber = 1;
               }
               _pageNumber = 1;
            }

            QueryPageInfo queryPageInfo = new QueryPageInfo(_options.PageSize, _pageNumber);
            bool bSearching = false;

#if (LEADTOOLS_V19_OR_LATER)
            if (IsSelectedViewHangingProtocol() && (__DataAccess3 != null))
            {
               bSearching = __DataAccess3.QueryHangingProtocolAsync(query, queryPageInfo);
            }
            else
            {
               bSearching = __DataAccess.QueryCompositeInstancesAsync(query, queryPageInfo);
            }
#else
            bSearching = __DataAccess.QueryCompositeInstancesAsync(query, queryPageInfo);
#endif

            if (!bSearching)
            {
               MessageBox.Show(this, @"Another search is already running.  Click the 'Cancel' button to cancel the existing search.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
               UpdatePaginationUI();
            }
         }
         catch (Exception exception)
         {
            MessageBox.Show(this, exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }
      
      private QueryCompositeInstancesArgs _queryCompositeInstancesArgs = null;


//      void __SearchWorker_DoWork(object sender, DoWorkEventArgs e)
//      {
//         try
//         {
//            MatchingParameterCollection query;
//            CompositeInstanceDataSet queryResult;

//            query = (e.Argument as MatchingParameterCollection);

//            if (query == null)
//            {
//               query = new MatchingParameterCollection();
//            }

//            if (e.Cancel)
//            {
//               return;
//            }

//            if (__SearchWorker.CancellationPending)
//            {
//               e.Cancel = true;

//               return;
//}

//            queryResult = __DataAccess.QueryCompositeInstances(query);

//            if (e.Cancel)
//            {
//               return;
//            }

//            e.Result = queryResult;
//         }
//         catch (Exception exception)
//         {
//            MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//         }
//      }
//
      
      void __DataAccess_QueryCompositeInstancesStarting(object sender, QueryCompositeInstancesArgs e)
      {
         _queryCompositeInstancesArgs = e;
      }


      void __DataAccess_QueryCompositeInstancesCompleted(object sender, QueryCompositeInstancesArgs e)
      {
         try
         {
            if (!e.Cancelled /*&& (e.Error == null)*/)
            {
               DataSet queryResult = (e.Result );

               if (null != queryResult)
               {
                  if (queryResult.Tables[DataTableHelper.InstanceTableName].Rows.Count > 0)
                  {
                     DataTable viewTable = ViewGenerator.GenerateView((DicomInformationView)tscDisplayLevel.ComboBox.SelectedValue, queryResult);

                     ApplyView((DicomInformationView)tscDisplayLevel.ComboBox.SelectedValue);


                     dgvStudies.DataSource = null;
                     dgvStudies.DataSource = viewTable;

                     if (null != viewTable)
                     {
                        SetDisplayedRecordsCount(viewTable.Rows.Count);
                     }

                     __QueryDataSet = queryResult;
                  }
                  else
                  {
                     if (null != __QueryDataSet)
                     {
                        __QueryDataSet.Clear();
                     }

                     dgvStudies.DataSource = null;

                     SetDisplayedRecordsCount(0);

                     if (!__Refreshing)
                     {
                        MessageBox.Show(this, @"No information found matching your search criteria.", @"Database Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                  }
               }
            }
         }
         catch (Exception exception)
         {
            MessageBox.Show(this, exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            __Refreshing = false;

            EnableButtons(true, DisableCancelButton.None);
            
            EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(false));
         }

         //if (e.Error != null)
         //{
         //   MessageBox.Show(this, e.Error.Message, e.Error.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
         //}

         if (e.Cancelled)
         {
            MessageBox.Show(this, "Search canceled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }

#if (LEADTOOLS_V19_OR_LATER)
      void __DataAccess_QueryHangingProtocolStarting(object sender, QueryCompositeInstancesArgs e)
      {
         _queryCompositeInstancesArgs = e;
      }

      void __DataAccess_QueryHangingProtocolCompleted(object sender, QueryCompositeInstancesArgs e)
      {
         try
         {
            if (!e.Cancelled /*&& (e.Error == null)*/)
            {
               DataSet queryResult = e.Result;

               if (null != queryResult)
               {
                  if (queryResult.Tables[DataTableHelper.HangingProtocolTableName].Rows.Count > 0)
                  {
                     DataTable viewTable = ViewGenerator.GenerateView((DicomInformationView)tscDisplayLevel.ComboBox.SelectedValue, queryResult);

                     ApplyView((DicomInformationView)tscDisplayLevel.ComboBox.SelectedValue);


                     dgvStudies.DataSource = null;
                     dgvStudies.DataSource = viewTable;

                     if (null != viewTable)
                     {
                        SetDisplayedRecordsCount(viewTable.Rows.Count);
                     }

                     __QueryDataSetHangingProtocol = queryResult;
                  }
                  else
                  {
                     if (null != __QueryDataSetHangingProtocol)
                     {
                        __QueryDataSetHangingProtocol.Clear();
                     }

                     __QueryDataSetHangingProtocol = new DataSet();

                     dgvStudies.DataSource = null;

                     SetDisplayedRecordsCount(0);

                     if (!__Refreshing)
                     {
                        MessageBox.Show(this, @"No information found matching your search criteria.", @"Database Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     }
                  }
               }
            }
         }
         catch (Exception exception)
         {
            MessageBox.Show(this, exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
            __Refreshing = false;

            EnableButtons(true, DisableCancelButton.None);
            
            EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(false));
         }

         //if (e.Error != null)
         //{
         //   MessageBox.Show(this, e.Error.Message, e.Error.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
         //}

         if (e.Cancelled)
         {
            MessageBox.Show(this, "Search canceled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
      }
#endif // #if (LEADTOOLS_V19_OR_LATER)
      
      private void __AddDicomWorker_ProgressChanged
      (
         object sender,
         ProgressChangedEventArgs e
      )
      {
         try
         {
            AddDicomBackgroundWorker.AddDicomWorkerProgressState state;

            state = (e.UserState as AddDicomBackgroundWorker.AddDicomWorkerProgressState);

            progressBar1.Value = e.ProgressPercentage;

            if (state.Status == DicomCommandStatusType.Success)
            {
               string message;


               message = string.Format("Loaded {0} of {1} files...", state.CurrentCount, state.TotalCount);

               StatusReport.Instance.OperationMainStatus(message);
            }
            else
            {
               string error;


               error = string.Format("\r\nFailed to load '{0}', Status: {1}, Description: {2}", state.File, state.Status, state.Description);

               StatusReport.Instance.OperationErrorStatus(error);
            }
            EventBroker.Instance.PublishEvent<DicomFileImportedEventArgs>(this, new DicomFileImportedEventArgs(state.File, state.Status, state.Description));

         }
         catch (Exception exception)
         {
            MessageBox.Show(this, exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

      }

      void __AddDicomWorker_RunWorkerCompleted
      (
         object sender,
         RunWorkerCompletedEventArgs e
      )
      {
         try
         {
            bool cancelled       = false;
            int  totalCount      = 0;
            int  successCount    = 0;
            int  failedCount     = 0;


            AddDicomBackgroundWorker.AddDicomWorkerResultState state = (e.Result as AddDicomBackgroundWorker.AddDicomWorkerResultState);
            if (null != state)
            {
               totalCount = state.TotalCount;
               successCount = state.SuccessCount;
               failedCount = state.FailedCount;
               cancelled = state.Cancelled;
            }


            if (e.Error == null)
            {
               if (null != state)
               {
                  StatusReport.Instance.OperationAppendStatus(string.Format("\r\nTotal number of stored instances: {0}\r\nTotal number of failed instances: {1}", successCount, failedCount));
               }
            }

            if (cancelled)
            {
               StatusReport.Instance.EndOperation("Operation Canceled");
            }
            else if (e.Error != null)
            {
               StatusReport.Instance.EndOperation("An error occured.\r\n" + e.Error.Message);
            }
            else
            {
               StatusReport.Instance.EndOperation("Operation Completed");
            }

         MultiDicomImportEventArgs argsFinished = new MultiDicomImportEventArgs(cancelled, totalCount, successCount, failedCount);
         EventBroker.Instance.PublishEvent<MultiDicomImportEventArgs>(this, argsFinished);

            RefreshLastQuery();
         }
         catch (Exception)
         { }
         finally
         {
            EnableButtons(true, DisableCancelButton.None);
            EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(false));
         }

      }

      void __AddDicomWorker_StoreCommandCreated(object sender, StoreCommandEventArgs e)
      {
         if (null != ConfigureStoreCommand)
         {
            ConfigureStoreCommand(sender, e);
         }
      }

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
      void __ExportDicomWorker_StoreCommandCreated(object sender, StoreCommandEventArgs e)
      {
         if (null != ConfigureStoreExportCommand)
         {
            ConfigureStoreExportCommand(sender, e);
         }
      }

      //private void __GenerateMetadataWorker_CancelGenerateMetadata(object sender, CancelGenerateMetadataEventArgs e)
      //{
      //   string message;

      //   e.Cancel = OnCancelStore(e.DataSet, out message);
      //   if (e.Cancel)
      //   {
      //      e.CancelMessage = message;
      //   }
      //}

      private void __GenerateMetadataWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         string reason = string.Empty;
         GenerateMetadataBackgroundWorker.GenerateMetadataWorkerResultState state = null;
         try
         {
            if (!e.Cancelled && e.Error == null)
            {
               state = (e.Result as GenerateMetadataBackgroundWorker.GenerateMetadataWorkerResultState);
               if (null != state)
               {
                  StatusReport.Instance.AddOperationMainStatus(string.Format("Total Generated Metadata Instances: {0} of {1}", state.SuccessCount, state.TotalCount));
               }
            }

            if (state.Cancelled || e.Cancelled)
            {
               reason = "Operation Canceled";
               StatusReport.Instance.EndOperation(reason);
            }
            else if (e.Error != null)
            {
               reason = "An error occured.\r\n" + e.Error.Message;
               StatusReport.Instance.EndOperation(reason);
            }
            else
            {
               reason = "Operation Completed";
               StatusReport.Instance.EndOperation(reason);
            }
         }
         catch (Exception)
         { }
         finally
         {
            EnableButtons(true, DisableCancelButton.None);

            if (state != null)
               EventBroker.Instance.PublishEvent<MetadataEventArgs>(this, new MetadataEventArgs(MetadataCommand.Generate, MetadataCategory.All, MetadataScope.All, true, reason, state.SuccessCount, state.TotalCount, state.Cancelled));
         }

      }

      private void __GenerateMetadataWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         try
         {
            GenerateMetadataBackgroundWorker.GenerateMetadataWorkerProgressState state = (e.UserState as GenerateMetadataBackgroundWorker.GenerateMetadataWorkerProgressState);

            progressBar1.Value = e.ProgressPercentage;

            if (state.Status == DicomCommandStatusType.Success)
            {
               string message = string.Format("Generated Metadata Instances {0} of {1} ...", state.CurrentCount, state.TotalCount);

               StatusReport.Instance.OperationMainStatus(message);
            }
            else
            {
               string error = string.Format("\r\nFailed to Generate Metadata {0}, Status: {1}, Description: {2}", state.File, state.Status, state.Description);

               StatusReport.Instance.OperationErrorStatus(error);
            }
            // EventBroker.Instance.PublishEvent<DicomFileExportedEventArgs>(this, new DicomFileExportedEventArgs(state.File, state.Status, state.Description));
         }
         catch (Exception exception)
         {
            MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

      }


      private void __ExportDicomWorker_ProgressChanged
      (
         object sender,
         ProgressChangedEventArgs e
      )
      {
         try
         {
            ExportDicomBackgroundWorker.ExportDicomWorkerProgressState state = (e.UserState as ExportDicomBackgroundWorker.ExportDicomWorkerProgressState);

            progressBar1.Value = e.ProgressPercentage;

            if (state.Status == DicomCommandStatusType.Success)
            {
               string message = string.Format("Exported {0} of {1} files...", state.CurrentCount, state.TotalCount);

               StatusReport.Instance.OperationMainStatus(message);
            }
            else
            {
               string error = string.Format("\r\nFailed to export {0}, Status: {1}, Description: {2}", state.File, state.Status, state.Description);

               StatusReport.Instance.OperationErrorStatus(error);
            }
            EventBroker.Instance.PublishEvent<DicomFileExportedEventArgs>(this, new DicomFileExportedEventArgs(state.File, state.Status, state.Description));

         }
         catch (Exception exception)
         {
            MessageBox.Show(this, exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }

      }

      void __ExportDicomWorker_RunWorkerCompleted
      (
         object sender,
         RunWorkerCompletedEventArgs e
      )
      {
         try
         {
            AddDicomBackgroundWorker.AddDicomWorkerResultState state;


            if (!e.Cancelled && e.Error == null)
            {
               state = (e.Result as AddDicomBackgroundWorker.AddDicomWorkerResultState);

               if (null != state)
               {
                  StatusReport.Instance.AddOperationMainStatus(string.Format("Total number of exported instances: {0}", state.SuccessCount));
                  StatusReport.Instance.AddOperationMainStatus(string.Format("Total number of failed instances: {0}", state.FailedCount));
               }
            }

            if (e.Cancelled)
            {
               StatusReport.Instance.EndOperation("Operation Canceled");
            }
            else if (e.Error != null)
            {
               StatusReport.Instance.EndOperation("An error occured.\r\n" + e.Error.Message);
            }
            else
            {
               StatusReport.Instance.EndOperation("Operation Completed");
            }

            RefreshLastQuery();
         }
         catch (Exception)
         { }
         finally
         {
            EnableButtons(true, DisableCancelButton.None);
            EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(false));
         }

      }
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

      void __RemoveDicomWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
      {
         try
         {
            progressBar1.Value = e.ProgressPercentage;

            RemoveDicomBackgroundWorker.RemoveDiconWorkerProgressState state;


            state = (e.UserState as RemoveDicomBackgroundWorker.RemoveDiconWorkerProgressState);

            progressBar1.Value = e.ProgressPercentage;

            if (null == state.Error)
            {
               string message;

               message = string.Format("{0} with [{1} = {2}] information deleted. Total DICOM Instance(s) deleted in step: {3}",
                                         state.ViewName,
                                         state.RowKeyName,
                                         state.RowKeyValue,
                                         state.RemovedImagesCount);

               StatusReport.Instance.AddOperationMainStatus(message);

               StatusReport.Instance.AddOperationMainStatus("Deleting images from disk...");

               DeletePhysicalImages(state.DeletedRow);
            }
            else
            {
               string error;

               error = string.Format("Failed to delete {0} with [{1} = {2}].\r\nError:{3}",
                                        state.ViewName,
                                        state.RowKeyName,
                                        state.RowKeyValue,
                                        state.Error.Message);

               StatusReport.Instance.OperationErrorStatus(error);
            }

            if ((e.UserState as RemoveDicomBackgroundWorker.RemoveDiconWorkerProgressState).Error != null)
            {
               Messager.ShowError(this, (e.UserState as RemoveDicomBackgroundWorker.RemoveDiconWorkerProgressState).Error);
            }
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception);
         }
      }

      void __RemoveDicomWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
      {
         try
         {
            if (!e.Cancelled && e.Error == null)
            {
               StatusReport.Instance.AddOperationMainStatus(string.Format("Total number of deleted instances: {0}", e.Result));
            }

            if (e.Cancelled)
            {
               StatusReport.Instance.EndOperation("Operation Canceled");
            }
            else if (e.Error != null)
            {
               StatusReport.Instance.EndOperation("An error occured.\r\n" + e.Error.Message);
            }
            else
            {
               StatusReport.Instance.EndOperation("Operation Completed");
            }

            RefreshLastQuery();
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception);
         }
         finally
         {
            EnableButtons(true, DisableCancelButton.None);
            
            EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(true));
         }
      }

      void dicomQuery1_CancelSearch(object sender, EventArgs e)
      {
         __DataAccess.CancelQueryCompositeInstancesAsync(_queryCompositeInstancesArgs);
         EnableButtons(true, DisableCancelButton.None);
      }
      
      void ClearSearch()
      {
         dgvStudies.DataSource = null;
         __ActiveQueryDataSet = new DataSet();

         SetDisplayedRecordsCount(0);
         EnableButtons(true, DisableCancelButton.None);
      }

      void dicomQuery1_ClearSearch(object sender, EventArgs e)
      {
         ClearSearch();
      }

      private void tsbAddDicom_Click(object sender, EventArgs e)
      {
         try
         {
            if (__AddDicomWorker.IsBusy)
            {
               throw new InvalidOperationException("DICOM files are being loaded.");
            }

            _openDicomFileDialog.Multiselect = true;
            _openDicomFileDialog.Title = "Add DICOM File";
            _openDicomFileDialog.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*";
            _openDicomFileDialog.FilterIndex = 2;

            if (_openDicomFileDialog.ShowDialog() == DialogResult.OK)
            {
               AddDicomFiles(_openDicomFileDialog.FileNames);
            }
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception);
         }

      }

      private void tsbAddDicomDir_Click(object sender, EventArgs e)
      {
         try
         {
            if (__AddDicomWorker.IsBusy)
            {
               throw new InvalidOperationException("DICOM files are being loaded.");
            }
            _openDicomFileDialog.Multiselect = false;
            _openDicomFileDialog.Title = "Add DICOM Dir";
            _openDicomFileDialog.Filter = "DICOMDIR|DICOMDIR|All Files|*.*";
            _openDicomFileDialog.FileName = "DICOMDIR";
            _openDicomFileDialog.FilterIndex = 1;

            if (_openDicomFileDialog.ShowDialog() == DialogResult.OK)
            {
               AddDicomFiles(_openDicomFileDialog.FileNames);
            }
         }
         catch (Exception excpetion)
         {
            Messager.ShowError(this, excpetion);
         }
      }

      private void tsbDelete_Click(object sender, EventArgs e)
      {
         try
         {
            DataGridViewSelectedRowCollection selectedRows;
            List<ViewGenerator.ViewDataRow> deletedRows;


            selectedRows = dgvStudies.SelectedRows;
            deletedRows = new List<ViewGenerator.ViewDataRow>();

            if (selectedRows.Count == 0)
            {
               return;
            }

            using (ConfirmWithReasonDialog confirmDlg = new ConfirmWithReasonDialog())
            {
               confirmDlg.Text = "Confirm Delete";

               confirmDlg.Message = string.Format("You are about to delete {0} record(s) from {1}.\n\nAre you sure you want to delete selected rows?\n\nType the reason for deleting selected rows.",
                                                    selectedRows.Count,
                                                    tscDisplayLevel.Text);

               confirmDlg.ConfirmIcon = Resources.Warning_128;
               
               confirmDlg.ConfirmCheckBoxVisible = false;

               if (confirmDlg.ShowDialog(this) != DialogResult.OK)
               {
                  return;
               }


               EventBroker.Instance.PublishEvent<DeletingDicomFilesEventArgs>(this, new DeletingDicomFilesEventArgs(confirmDlg.Reason));
            }

            ViewGenerator.ViewDataTable viewTable;


            viewTable = (ViewGenerator.ViewDataTable)dgvStudies.DataSource;

            foreach (DataGridViewRow gridRow in selectedRows)
            {
               deletedRows.Add((ViewGenerator.ViewDataRow) ( ( DataRowView ) gridRow.DataBoundItem ).Row);
            }

            EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(true));
            
            __RemoveDicomWorker.RunWorkerAsync(deletedRows.ToArray());

            EnableButtons(false, DisableCancelButton.DicomSearch);
            EnsureReportVisible();

            StatusReport.Instance.BeginOperation("Deleting DICOM Files:");
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception);
         }
      }

      void tsbEmpyDatabase_Click(object sender, EventArgs e)
      {
         try
         {
            using (ConfirmWithReasonDialog confirmDlg = new ConfirmWithReasonDialog())
            {
               confirmDlg.Text = "Confirm Delete";

               confirmDlg.Message = "CAUTION:\n\rYou are about to DELETE ALL DICOM instances.\n\r\n\r" +
                                    "Are you sure you want to DELETE ALL DICOM instances ?\r\nOnce this operation is started it can't be canceled.\n\r\n\r" +
                                    "Type the reason for clearing the database.";

               confirmDlg.ConfirmIcon = Resources.extreme_warning;
              
               confirmDlg.ConfirmCheckBoxVisible = true;

               if (confirmDlg.ShowDialog(this) != DialogResult.OK)
               {
                  return;
               }


               EventBroker.Instance.PublishEvent<EmptyDatabaseEventArgs>(this, new EmptyDatabaseEventArgs(confirmDlg.Reason));
            }

            EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(true));
            
            __EmptyDatabaseWorker.RunWorkerAsync();

            EnableButtons(false, DisableCancelButton.DicomSearch);

            {
               tsbCancel.Enabled = false;
               pnlStatus.Enabled = false;
            }

            EnsureReportVisible();

            StatusReport.Instance.BeginOperation("Deleting DICOM Files:");
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception);
         }
      }

      private void __EmptyDatabaseWorker_RunWorkerCompleted
      (
         object sender, RunWorkerCompletedEventArgs e
      )
      {
         try
         {
            try
            {
               if (null != e.Error)
               {
                  StatusReport.Instance.OperationErrorStatus("Operation Failed. Reason: " + e.Error.Message);

               }
               else
               {
                  // CompositeInstanceDataSet.InstanceDataTable deletedImages;


                  DataTable deletedImages = (DataTable)e.Result;

                  StatusReport.Instance.OperationMainStatus(string.Format("{0} DICOM instance removed.", deletedImages.Rows.Count));

                  StatusReport.Instance.AddOperationMainStatus("Deleting images from disk...");

                  Application.DoEvents();

                  DeletePhysicalImages(deletedImages);

                  dgvStudies.DataSource = null;

                  SetDisplayedRecordsCount(0);

                  if (null != __QueryDataSet)
                  {
                     __QueryDataSet.Clear();
                  }
#if (LEADTOOLS_V19_OR_LATER)
                  if (null != __QueryDataSetHangingProtocol)
                  {
                     __QueryDataSetHangingProtocol.Clear();
                  }
#endif
               }
            }
            catch (Exception exception)
            {
               StatusReport.Instance.OperationErrorStatus("Error occured.\r\n" + exception.Message);
            }
            finally
            {
               EnableButtons(true, DisableCancelButton.None);

               StatusReport.Instance.EndOperation("Operation Completed.");
               
               EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(true));
            }
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception);
         }
      }

      void tscDisplayLevel_SelectionChangeCommitted(object sender, EventArgs e)
      {
         DicomInformationView selectedView = GetSelectedView();

         EnableButtons(true, DisableCancelButton.DicomSearch);
         this.dicomQuery1.SetSearch(selectedView);

         if (__ActiveQueryDataSet != null)
         {
            ViewGenerator.ViewDataTable viewTable;


            viewTable = ViewGenerator.GenerateView((DicomInformationView)tscDisplayLevel.ComboBox.SelectedValue,
                                                      __ActiveQueryDataSet);

            dgvStudies.DataSource = null;

            SetDisplayedRecordsCount(0);

            ApplyView((DicomInformationView)tscDisplayLevel.ComboBox.SelectedValue);

            dgvStudies.DataSource = viewTable;

            if (null != viewTable)
            {
               SetDisplayedRecordsCount(viewTable.Rows.Count);
            }
         }
      }

      private void tsbShowReport_Click(object sender, EventArgs e)
      {
         bool checkingFiles = false;
         try
         {
            List<string> fileList  = new List<string>();;
            DicomQueryParams dicomQueryParams = dicomQuery1.GetDicomQueryParams();
            if ((dicomQueryParams.PatientName.FamilyName == "1234##4321" && dicomQueryParams.PatientName.GivenName == "1234##4321"))
            {
               int missingFileCount = 0;
               foreach (DataGridViewRow row in dgvStudies.Rows)
               {
                  string fileName = row.Cells[22].Value.ToString();
                  if (!string.IsNullOrEmpty(fileName))
                  {
                     if (!File.Exists(fileName))
                     {
                        fileList.Add(fileName);
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        row.DefaultCellStyle.SelectionBackColor = Color.Orange;
                        missingFileCount++;
                     }
                  }
               }

               string oldMessagerCaption = Messager.Caption;
               Messager.Caption = "Missing File Diagnostics";

               if (missingFileCount == 0)
               {
                  Messager.ShowInformation(this, "Missing File Count: 0");
               }
               else
               {
                  string message = string.Format("Missing File Count (yellow): {0}\n\rClick 'Yes' to see the missing files", missingFileCount);
                  if (missingFileCount > 0)
                  {
                     DialogResult dr = Messager.ShowQuestion(this, message, MessageBoxIcon.Exclamation, MessageBoxButtons.YesNo);
                     if (dr == DialogResult.Yes)
                     {
                        string result = String.Join("\n", fileList.ToArray());
                        Messager.ShowInformation(this, result);
                     }
                  }
               }
               Messager.Caption = oldMessagerCaption;

               checkingFiles = true;
            }
         }
         catch (Exception)
         {
         }

         if (checkingFiles)
         {
            return;
         }

         try
         {
            EnsureReportVisible();
         }
         catch (Exception)
         { }
      }

      private void tsbCancel_Click(object sender, EventArgs e)
      {
         try
         {
            if (__AddDicomWorker.IsBusy)
            {
               __AddDicomWorker.CancelAsync();
            }

            if (__RemoveDicomWorker.IsBusy)
            {
               __RemoveDicomWorker.CancelAsync();
            }

            if (__GenerateMetadataWorker.IsBusy)
            {
               __GenerateMetadataWorker.CancelAsync();
            }

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
            if (__ExportDicomWorker.IsBusy)
            {
               __ExportDicomWorker.CancelAsync();
            }
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception.Message);
         }
      }

      private void tsbGenerateMetadata_Click(object sender, EventArgs e)
      {
         DataGridViewSelectedRowCollection selectedRows = dgvStudies.SelectedRows;

         if (selectedRows.Count == 0)
         {
            return;
         }

         // EventBroker.Instance.PublishEvent<DeletingDicomFilesEventArgs>(this, new DeletingDicomFilesEventArgs(confirmDlg.Reason));
         List<ViewGenerator.ViewDataRow> metadataRows = new List<ViewGenerator.ViewDataRow>();
         foreach (DataGridViewRow gridRow in selectedRows)
         {
            metadataRows.Add((ViewGenerator.ViewDataRow)((DataRowView)gridRow.DataBoundItem).Row);
         }

         int metadataCount = __GenerateMetadataWorker.GetSelectedInstanceCount(metadataRows.ToArray());

         string timeConsumingWarning = (metadataCount > 500) ? "\n\nNote that generating this many metadata records is a time consuming task, and can be canceled at any time." : string.Empty;

         string message = string.Format("You are about to generate metadata for {0} row(s) from {1}.  This will be {2} total metadata records. {3} \n\nAre you sure you want to generate metadata for the selected rows? (Type the reason for generating metadata).",
                                       selectedRows.Count,
                                       tscDisplayLevel.Text,
                                       metadataCount,
                                       timeConsumingWarning);

         using (ConfirmWithReasonDialog confirmDlg = new ConfirmWithReasonDialog())
         {
            confirmDlg.Text = "Confirm Generate Metadata";
            confirmDlg.Message = message;
            confirmDlg.ConfirmIcon = Resources.Warning_128;
            confirmDlg.ConfirmCheckBoxVisible = false;

            if (confirmDlg.ShowDialog(this) != DialogResult.OK)
            {
               return;
            }

            // EventBroker.Instance.PublishEvent<DeletingDicomFilesEventArgs>(this, new DeletingDicomFilesEventArgs(confirmDlg.Reason));
            //List<ViewGenerator.ViewDataRow>  metadataRows = new List<ViewGenerator.ViewDataRow>();
            //foreach (DataGridViewRow gridRow in selectedRows)
            //{
            //   metadataRows.Add((ViewGenerator.ViewDataRow)((DataRowView)gridRow.DataBoundItem).Row);
            //}

            GenerateMetadataBackgroundWorker.GenerateMetadataWorkerArgs args = new GenerateMetadataBackgroundWorker.GenerateMetadataWorkerArgs(metadataRows.ToArray())
            {
               Options = MetadataOptions
            };

            __GenerateMetadataWorker.RunWorkerAsync(args);
            EnableButtons(false, DisableCancelButton.DicomSearch);
            EnsureReportVisible();

            string reason = "Generating Metadata:";
            StatusReport.Instance.BeginOperation(reason);

            EventBroker.Instance.PublishEvent<MetadataEventArgs>(this, new MetadataEventArgs(MetadataCommand.Generate, MetadataCategory.All, MetadataScope.All, false, reason, 0, metadataCount, false));
         }
      }

#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
      void exportDicomDialog_SaveAnonymizeSettings(object sender, SaveAnonymizeSettingsEventArgs e)
      {
         Scripts = e.Scripts;
         e.Handled = true;
         EventBroker.Instance.PublishEvent<SaveAnonymizeSettingsEventArgs>(sender, e);
      }

      private void tsbExportSelected_Click(object sender, EventArgs e)
      {
         if (__ExportDicomWorker.IsBusy)
         {
            throw new InvalidOperationException("DICOM files are being exported.");
         }

         DataGridViewSelectedRowCollection selectedRows = dgvStudies.SelectedRows;

         if (selectedRows.Count == 0)
         {
            return;
         }

         string message = string.Format("You are about to export {0} record(s) from {1}.\n\nAre you sure you want to export the selected rows?",
                                        selectedRows.Count,
                                        tscDisplayLevel.Text);

         bool continueWithExport = false;
         ExportOptions exportSettings = ExportSettings;
         using (ExportDicomDialog dlg = new ExportDicomDialog())
         {
            dlg.ExportDialogIcon = MessageBoxIcon.Information;
            dlg.Message = message;
            dlg.Overwrite = exportSettings.OverwriteExisting;
            dlg.Anonymize = exportSettings.Anonmyize;
            dlg.CreateDicomDir = exportSettings.CreateDicomDirectory;
            dlg.ExportFolder = exportSettings.ExportFolder;
            dlg.Scripts = Scripts;
            dlg.CanChangeSettings = CanChangeSettings;
            dlg.SaveAnonymizeSettings += exportDicomDialog_SaveAnonymizeSettings;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               exportSettings.OverwriteExisting = dlg.Overwrite;
               exportSettings.Anonmyize = dlg.Anonymize;
               exportSettings.CreateDicomDirectory = dlg.CreateDicomDir;
               exportSettings.ExportFolder = dlg.ExportFolder;

               if (dlg.ScriptsChanged)
               {
                  Scripts = dlg.Scripts;
               }

               ExportSettings = exportSettings;
               continueWithExport = true;
            }

            dlg.SaveAnonymizeSettings -= exportDicomDialog_SaveAnonymizeSettings;
         }

         if (continueWithExport)
         {
            try
            {
               List<ViewGenerator.ViewDataRow> exportedRows = new List<ViewGenerator.ViewDataRow>();

               ViewGenerator.ViewDataTable viewTable = (ViewGenerator.ViewDataTable) dgvStudies.DataSource;

               foreach (DataGridViewRow gridRow in selectedRows)
               {
                  exportedRows.Add((ViewGenerator.ViewDataRow) ((DataRowView) gridRow.DataBoundItem).Row);
               }

               EventBroker.Instance.PublishEvent<BackgroundProcessEventAgs>(this, new BackgroundProcessEventAgs(true));

               ExportDicomWorkerArgs args = new ExportDicomWorkerArgs(exportSettings.ExportFolder,
                                                                      exportedRows.ToArray())
                                               {
                                                  Overwrite = exportSettings.OverwriteExisting,
                                                  Anonymize = exportSettings.Anonmyize,
                                                  CreateDicomDir = exportSettings.CreateDicomDirectory
                                               };
               __ExportDicomWorker.Anonymizer = Scripts.ActiveAnonymizer();
               __ExportDicomWorker.RunWorkerAsync(args);
               EnableButtons(false, DisableCancelButton.DicomSearch);
               EnsureReportVisible();

               StatusReport.Instance.BeginOperation("Exporting DICOM Files:");

            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      void dlg_SaveAnonymizeSettings(object sender, SaveAnonymizeSettingsEventArgs e)
      {
         throw new NotImplementedException();
      }

#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

      private void GeneratePatientView()
      {
         List<string> patientColumns = ViewGenerator.GetSeriesLevelColumns();


         DataSet patientViewDS;
         DataTable mappingTable;

         patientViewDS = new DataSet();

         mappingTable = patientViewDS.Tables.Add("mappingTable");

         mappingTable.Columns.Add("ColumnName", typeof(string));
         mappingTable.Columns.Add("FriendlyName", typeof(string));
         mappingTable.Columns.Add("Type", typeof(Type));
         mappingTable.Columns.Add("Visible", typeof(bool));

         foreach (string columnName in patientColumns)
         {
            DataRow mappingRow;


            mappingRow = mappingTable.NewRow();

            mappingRow[0] = columnName;
            mappingRow[1] = columnName;
            mappingRow[2] = (columnName.ToUpper().Contains("DATE")) ? typeof(DateTime) : typeof(string);
            mappingRow[3] = true;

            mappingTable.Rows.Add(mappingRow);
         }

         patientViewDS.WriteXml(@"c:\SeriesViewDS.xml", XmlWriteMode.WriteSchema);

      }

      private void GenerateImagePatientView()
      {
         List<string> patientColumns = ViewGenerator.GetImageLevelColumns();


         DataSet patientViewDS;
         DataTable mappingTable;

         patientViewDS = new DataSet();

         mappingTable = patientViewDS.Tables.Add("mappingTable");

         mappingTable.Columns.Add("ColumnName", typeof(string));
         mappingTable.Columns.Add("FriendlyName", typeof(string));
         mappingTable.Columns.Add("Type", typeof(Type));
         mappingTable.Columns.Add("Visible", typeof(bool));

         foreach (string columnName in patientColumns)
         {
            DataRow mappingRow;


            mappingRow = mappingTable.NewRow();

            mappingRow[0] = columnName;
            mappingRow[1] = columnName;
            mappingRow[2] = (columnName.ToUpper().Contains("DATE")) ? typeof(DateTime) : typeof(string);
            mappingRow[3] = true;

            mappingTable.Rows.Add(mappingRow);
         }

         patientViewDS.WriteXml(@"c:\ImageViewDS.xml", XmlWriteMode.WriteSchema);

      }


      #endregion

      #region Data Members

      private IStorageDataAccessAgent _dataAccess;
      private IWorkstationDataAccessAgent _wsDataAccess;
      // private BackgroundWorker _searchWorker;
      private AddDicomBackgroundWorker _addDicomWorker;
      private RemoveDicomBackgroundWorker _removeDicomWorker;
      private EmptyDatabaseBackgroundWorker _emptyDatabaseWorker;
      private OpenFileDialog _openDicomFileDialog;
      private DataSet _queryDataSet;
      private DataSet _queryDataSetHangingProtocol;
      private MatchingParameterCollection _lastqueryParamsHangingProtocol = new MatchingParameterCollection();
      private MatchingParameterCollection _lastqueryParams = new MatchingParameterCollection();
      private bool _refreshing = false;
      private Dictionary<DicomInformationView, List<DataGridViewColumn>> _cachedViews = new Dictionary<DicomInformationView, List<DataGridViewColumn>>();
      private string _AETitle;
      private bool _isWorking;
      private bool _mergeImportDicom;
      private bool _canDelete = true;
      private bool _canEmptyDatabase = true;
      private bool _backupFilesOnDatabaseDelete = false;
      private bool _deleteFilesOnDatabaseDelete = true;

      private IOptionsDataAccessAgent _optionsAgent;
      private DatabaseManagerOptions _options = new DatabaseManagerOptions();
      private int _pageNumber = 1;

      private GenerateMetadataBackgroundWorker _generateMetadataDicomWorker;
#if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)
      private ExportDicomBackgroundWorker _exportDicomWorker;
      private bool _enableExport;
      private bool _canChangeSettings = true;
      private ExportOptions _exportSettings;
      private AnonymizeScripts _scripts;
#endif // #if (LEADTOOLS_V19_OR_LATER_EXPORT) || (LEADTOOLS_V19_OR_LATER)

      #endregion
      
      private void dgvStudies_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
      {
         try
         {

            if (e.RowIndex != -1)
            {
               Leadtools.Medical.Winforms.ViewGenerator.ViewDataRow dataRow = (dgvStudies.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Leadtools.Medical.Winforms.ViewGenerator.ViewDataRow;

               if (dataRow != null)
               {
                  // if (dataRow.OriginalRow is CompositeInstanceDataSet.InstanceRow)
                  if (
                        (string.Compare(dataRow.OriginalRow.Table.TableName, DataTableHelper.InstanceTableName) == 0) ||
                        (string.Compare(dataRow.OriginalRow.Table.TableName, DataTableHelper.HangingProtocolTableName) == 0)
                      )
                  {
                     // CompositeInstanceDataSet.InstanceRow instance = dataRow.OriginalRow as CompositeInstanceDataSet.InstanceRow;
                     DataRow instance = dataRow.OriginalRow;
                     DicomInstanceRetrieveCommand dsLoadCmd = new DicomInstanceRetrieveCommand ( __DataAccess ) ;
                     
                     using (DicomDataSet ds = dsLoadCmd.GetDicomDataSet (instance ))
                     {
                        ViewDatasetDialog dlgView = new ViewDatasetDialog();
                        
                        dlgView.Dataset = ds;
                        dlgView.StorageDataAccessAgent = __DataAccess as IStorageDataAccessAgent5;
                        dlgView.ShowDialog(this);                        
                     }
                  }
               }
            }
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception);
         }
      }

      private void dgvStudies_CellContentClick(object sender, DataGridViewCellEventArgs e)
      {
         if (dgvStudies.Columns[e.ColumnIndex].Name == "ReferencedFile")
         {
            //e.RowIndex == -1 is the column header
            if (e.RowIndex >= 0)
            {
               string value = dgvStudies.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

               if (!string.IsNullOrEmpty(value) && File.Exists(value))
               {
                  string argument = string.Format("/select,\"{0}\"", value);

                  Process.Start("explorer.exe", argument);
               }
            }
         }
      }

      #region Data Types Definition

      #endregion

      #endregion

      #region internal

      #region Methods

      #endregion

      #region Properties

      #endregion

      #region Events

      #endregion

      #region Data Types Definition

      #endregion

      #region Callbacks

      #endregion

      #endregion

      private PropertyInfo GetPropertyInfo(Type type, string propertyName)
      {
         PropertyInfo propInfo = null;
         do
         {
            propInfo = type.GetProperty(propertyName,
                   BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            type = type.BaseType;
         }
         while (propInfo == null && type != null);
         return propInfo;
      }

      public object GetPropertyValue(object obj, string propertyName)
      {
         if (obj == null)
            throw new ArgumentNullException("obj");
         Type objType = obj.GetType();
         PropertyInfo propInfo = GetPropertyInfo(objType, propertyName);
         if (propInfo == null)
            throw new ArgumentOutOfRangeException("propertyName",
              string.Format("Couldn't find property {0} in type {1}", propertyName, objType.FullName));
         return propInfo.GetValue(obj, null);
      }

      public void SetPropertyValue(object obj, string propertyName, object val)
      {
         if (obj == null)
            throw new ArgumentNullException("obj");
         Type objType = obj.GetType();
         PropertyInfo propInfo = GetPropertyInfo(objType, propertyName);
         if (propInfo == null)
            throw new ArgumentOutOfRangeException("propertyName",
              string.Format("Couldn't find property {0} in type {1}", propertyName, objType.FullName));
         propInfo.SetValue(obj, val, null);
      }
   }
}
