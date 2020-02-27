// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer.Catalog;
using Leadtools.Medical.Winforms.Worklist;
using Leadtools.Medical.Worklist.DataAccessLayer;
using Leadtools.Medical.Worklist.DataAccessLayer.BusinessEntity;
using Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.Worklist.Utilities;
using Leadtools.Medical.Worklist.DataAccessLayer.Configuration;
using Leadtools.DicomDemos;

namespace Leadtools.Medical.Winforms
{
   public partial class WorklistDatabaseEditor : System.Windows.Forms.UserControl
   {
      #region Public
         
         #region Methods
            
            public WorklistDatabaseEditor ( )
            {
               try
               {
                  InitializeComponent ( ) ;  
                  
                  Init ( ) ;
                        
                  RegisterEvents ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
            
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
            
            private void Init ( )
            {
               try
               {
                  if ( !_DesignMode )
                  {
                     __DSValidator = new DataSetValidatorManager ( ) ;
                  }
                  
                  InitQueryViews ( ) ;
                  
                  InitDbTableNameToFriendlyNameDataset ( ) ;
                  
                  InitFilterTypeDataSet ( ) ;
                  
                  InitMatchingParametersDataSet ( ) ;
                  
                  FillDataGridTableStyles ( ) ;
                  
                  BindControls ( ) ;
                  
                  EnableDisableQueryView ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void RegisterEvents ( )
            {
               try
               {
                  cmbQueryType.SelectionChangeCommitted += new EventHandler ( cmbQueryType_SelectionChangeCommitted ) ;
                  grdDataView.Navigate                  += new NavigateEventHandler ( grdQueryResultsView_Navigate ) ;
                  tmrControlDeleteButton.Tick           += new EventHandler ( tmrControlDeleteButton_Tick ) ;
                  
                  btnQuery.Click         += new EventHandler ( btnQuery_Click ) ;
                  btnDelete.Click        += new EventHandler ( btnDelete_Click ) ;
                  btnUndoChanges.Click   += new EventHandler ( btnUndoChanges_Click ) ;
                  btnCommitChanges.Click += new EventHandler ( btnCommitChanges_Click ) ;
                  btnReset.Click         += new EventHandler ( btnReset_Click ) ;
                  
                  if ( !_DesignMode )
                  {
                     __DSValidator.ValidationErrorDetected     += new DataSetValidator.ValidationErrorDetectionEventHandler ( DSValidator_ValidationErrorDetected ) ;
                     __DSValidator.RowValidationErrorDetection += new DataSetValidator.RowValidationErrorDetectionEventHandler ( DSValidator_RowValidationErrorDetectionEvent ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
                  
            
            private void InitQueryViews ( ) 
            {
               try
               {
                  ctlScheduledProcedureStepQueryView = new ScheduledProcedureStepQuery ( ) ;
                  ctlVisitQueryView                  = new VisitQuery ( ) ;
                  ctlRequestedProcedureQueryView     = new RequestedProcedureQuery ( ) ;
                  ctlPatientQueryView                = new PatientQuery ( ) ;
                  ctlImagingServiceRequestQueryView  = new ImagingServiceRequestQuery ( ) ;
                  ctlPeformedProcedureStepQueryView  = new PeformedProcedureStepQuery ( ) ;
                   
                  {//ctlScheduledProcedureStepQueryView
                  
                     ctlScheduledProcedureStepQueryView.Dock     = System.Windows.Forms.DockStyle.Fill ;
                     ctlScheduledProcedureStepQueryView.Location = new System.Drawing.Point ( 0, 0 ) ;
                     ctlScheduledProcedureStepQueryView.Name     = "ctlScheduledProcedureStepQueryView" ;
                     ctlScheduledProcedureStepQueryView.Size     = new System.Drawing.Size ( 384, 344 ) ;
                     ctlScheduledProcedureStepQueryView.TabIndex = 6 ;
                     
                  }//ctlScheduledProcedureStepQueryView
                  
                  {// ctlVisitQueryView
                  
                     ctlVisitQueryView.Dock     = System.Windows.Forms.DockStyle.Fill ;
                     ctlVisitQueryView.Location = new System.Drawing.Point ( 0, 0) ;
                     ctlVisitQueryView.Name     = "ctlVisitQueryView" ;
                     ctlVisitQueryView.Size     = new System.Drawing.Size ( 384, 344) ;
                     ctlVisitQueryView.TabIndex = 7 ;
                     
                  }// ctlVisitQueryView
                  
                  {// ctlRequestedProcedureQueryView
                     this.ctlRequestedProcedureQueryView.Dock     = System.Windows.Forms.DockStyle.Fill ;
                     this.ctlRequestedProcedureQueryView.Location = new System.Drawing.Point ( 0, 0 ) ;
                     this.ctlRequestedProcedureQueryView.Name     = "ctlRequestedProcedureQueryView" ;
                     this.ctlRequestedProcedureQueryView.Size     = new System.Drawing.Size ( 384, 344 ) ;
                     this.ctlRequestedProcedureQueryView.TabIndex = 5 ;
                     
                  }// ctlRequestedProcedureQueryView
                   
                  
                  {// ctlPatientQueryView
                  
                     this.ctlPatientQueryView.Dock     = System.Windows.Forms.DockStyle.Fill ;
                     this.ctlPatientQueryView.Location = new System.Drawing.Point ( 0, 0 ) ;
                     this.ctlPatientQueryView.Name     = "ctlPatientQueryView" ;
                     this.ctlPatientQueryView.Size     = new System.Drawing.Size ( 384, 344 ) ;
                     this.ctlPatientQueryView.TabIndex = 4 ;
               
                  }// ctlPatientQueryView
                  
                  {// ctlImagingServiceRequestQueryView
                     
                     this.ctlImagingServiceRequestQueryView.Dock     = System.Windows.Forms.DockStyle.Fill ;
                     this.ctlImagingServiceRequestQueryView.Location = new System.Drawing.Point ( 0, 0 ) ;
                     this.ctlImagingServiceRequestQueryView.Name     = "ctlImagingServiceRequestQueryView" ;
                     this.ctlImagingServiceRequestQueryView.Size     = new System.Drawing.Size ( 384, 344 ) ;
                     this.ctlImagingServiceRequestQueryView.TabIndex = 3 ;
                     
                  }// ctlImagingServiceRequestQueryView
                  
                  {// ctlImagingServiceRequestQueryView
                        
                     this.ctlPeformedProcedureStepQueryView.Dock     = System.Windows.Forms.DockStyle.Fill ;
                     this.ctlPeformedProcedureStepQueryView.Location = new System.Drawing.Point ( 0, 0 ) ;
                     this.ctlPeformedProcedureStepQueryView.Name     = "ctlctlPeformedProcedureStepQueryView" ;
                     this.ctlPeformedProcedureStepQueryView.Size     = new System.Drawing.Size ( 384, 344 ) ;
                     this.ctlPeformedProcedureStepQueryView.TabIndex = 4 ;
                        
                  }// ctlImagingServiceRequestQueryView
               
                  this.tabpgScheduledProcedureStep.Controls.Add ( ctlScheduledProcedureStepQueryView ) ;
                  this.tabpgVisit.Controls.Add ( ctlVisitQueryView ) ;
                  this.tabpgRequestedProcedure.Controls.Add ( ctlRequestedProcedureQueryView ) ;
                  this.tabpgPatient.Controls.Add ( ctlPatientQueryView ) ;
                  this.tabpgImageServiceRequest.Controls.Add ( ctlImagingServiceRequestQueryView ) ;
                  this.tabpgPerformedProcedureStep.Controls.Add ( ctlPeformedProcedureStepQueryView ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void InitDbTableNameToFriendlyNameDataset ( )
            {
               try
               {
                  DataSet   SupportedTablesDataSet = null ;
                  DataTable TableNameToFrindlyNameDataTable ;
                  WorklistCatalog catalog = new WorklistCatalog ( ) ;
                  
                  
                  __DbTableNameToFriendlyNameDataSet = new DataSet ( ) ;
                  SupportedTablesDataSet             = new DataSet ( ) ;
                  TableNameToFrindlyNameDataTable    = new DataTable ( ) ;
                  
                  SupportedTablesDataSet.ReadXml ( Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resources.SupportedTables ) ) ;  
                  
                  TableNameToFrindlyNameDataTable.Columns.Add ( Constants.BindingInfo.ColumnNames.DBTABLENAMETOFRIENDLYNAMES_ENTRY_DBNAME, typeof ( string ) ) ;
                  TableNameToFrindlyNameDataTable.Columns.Add ( Constants.BindingInfo.ColumnNames.DBTABLENAMETOFRIENDLYNAMES_ENTRY_FRIENDLYNAME, typeof ( string ) ) ;

                  foreach ( DataRow SupportedTablesDataRow in SupportedTablesDataSet.Tables [ 0 ].Rows )
                  {
                     DataRow TableNameToFriendlyNameDataRow ;
                     string  strTableKey ;
                     
                     
                     TableNameToFriendlyNameDataRow = TableNameToFrindlyNameDataTable.NewRow ( ) ;
                     
                     strTableKey = SupportedTablesDataRow [ Constants.BindingInfo.ColumnNames.TableKey ].ToString ( ) ;
                     
                     TableNameToFriendlyNameDataRow [ Constants.BindingInfo.ColumnNames.DBTABLENAMETOFRIENDLYNAMES_ENTRY_DBNAME ]       = catalog.GetEntityName ( strTableKey ) ;
                     TableNameToFriendlyNameDataRow [ Constants.BindingInfo.ColumnNames.DBTABLENAMETOFRIENDLYNAMES_ENTRY_FRIENDLYNAME ] = catalog.GetEntityDisplayName (  strTableKey ) ;
                     
                     TableNameToFrindlyNameDataTable.Rows.Add ( TableNameToFriendlyNameDataRow ) ;
                  }
                  
                  __DbTableNameToFriendlyNameDataSet.Tables.Add ( TableNameToFrindlyNameDataTable ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void InitFilterTypeDataSet ( )
            {
               try
               {
                  __QueryTypeDataSet = new DataSet ( ) ;
                  
                  
                  __QueryTypeDataSet.ReadXml ( Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resources.FILTERTYPE ) ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void InitMatchingParametersDataSet ( )
            {
               try
               {
                  __Catalog                          = new WorklistCatalog ( ) ;
                  __ColumnsMatchingParametersDataSet = new MatchingParametersDataSet ( ) ;
                  
                  __ColumnsMatchingParametersDataSet.ReadXml ( Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resources.MatchingParametersXML ) ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void FillDataGridTableStyles ( )
            {
               
               try
               {
                  DataGridTableStyles DataGridTableStyleDataSet ;
                  WorklistCatalog     catalog ;
                     
                  
                  DataGridTableStyleDataSet = new DataGridTableStyles ( ) ;
                  catalog                   = new WorklistCatalog ( ) ;
                  
                  //DataGridTableStyleDataSet.ReadXmlSchema ( Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resources.DataGridTableStylesSchema ) ) ;
                  DataGridTableStyleDataSet.ReadXml       ( Assembly.GetExecutingAssembly ( ).GetManifestResourceStream ( Constants.Resources.DataGridTableStylesXML ) ) ;
                  
                  foreach ( DataGridTableStyles.TableStylesRow tableStylesDataRow in DataGridTableStyleDataSet.TableStyles )
                  {
                     DataGridTableStyle GridTableStyle ;
                     string             tableKey ;
                     
                     GridTableStyle = new DataGridTableStyle ( ) ;
                     tableKey       = tableStylesDataRow [ Constants.BindingInfo.GridTableStyles.ColumnName.TableStyles_TableID ].ToString ( ) ;
                     
                     GridTableStyle.MappingName = catalog.GetEntityName ( tableKey ) ;
                     
                     foreach ( DataGridTableStyles.ColumnStylesRow columnStylesDataRow in tableStylesDataRow.GetColumnStylesRows ( ) )
                     {
                        DataGridColumnStyle GridColumnStyle    = null ;
                        DataGridColumnType  enumGridcolumntype ;
                        string              strColumnFormat    = String.Empty ; 
                        string              strColumnKey       = String.Empty ;
                        
                        
                        enumGridcolumntype = ( DataGridColumnType ) Enum.Parse( typeof ( DataGridColumnType ),
                                                                                columnStylesDataRow.ColumnType ) ;
                        
                        if ( columnStylesDataRow.IsColumnFormatNull ( ) ) 
                        {
                           strColumnFormat = string.Empty ;
                        }
                        else
                        {
                           strColumnFormat = columnStylesDataRow.ColumnFormat ;
                        }
                        
                        GridColumnStyle = CreateDataGridColumnStyle ( enumGridcolumntype, 
                                                                      strColumnFormat ) ;
                                                                      
                        strColumnKey = columnStylesDataRow.ColumnID ;
                        
                        GridColumnStyle.MappingName = catalog.GetEntityElementName ( tableKey, strColumnKey );
                        
                        GridColumnStyle.HeaderText  = catalog.GetEntityElementDisplayName ( tableKey, strColumnKey ) ;
                        
                        GridTableStyle.GridColumnStyles.Add ( GridColumnStyle ) ;
                     }
                     
                     grdDataView.TableStyles.Add ( GridTableStyle ) ;
                  }                  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private DataGridColumnStyle CreateDataGridColumnStyle 
            ( 
               DataGridColumnType enumGridColumnType, 
               string strColumnFormat 
            ) 
            {
               try
               {
                  DataGridColumnStyle GridColumnStyle ;
                  
                  
                  switch ( enumGridColumnType )
                  {
                     case DataGridColumnType.Text:
                     {
                        GridColumnStyle = new DataGridTextBoxColumn ( ) ;
                           
                        ( ( DataGridTextBoxColumn ) GridColumnStyle ).Format = strColumnFormat ;
                     }
                           
                        break ;
                           
                           
                     case DataGridColumnType.Bool:
                     {
                        GridColumnStyle = new DataGridBoolColumn ( ) ;
                     }
                           
                        break ;
                           
                     default:
                     {
                        throw new Exception ( Constants.Messages.Exception.DataGridColumntypeNotSupported ) ;
                     }
                  }
                  
                  return GridColumnStyle ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void BindControls ( )
            {
               try
               {
                  cmbQueryDisplayTable.DataSource    = __DbTableNameToFriendlyNameDataSet.Tables [ 0 ] ;
                  cmbQueryDisplayTable.DisplayMember = Constants.BindingInfo.ColumnNames.DBTABLENAMETOFRIENDLYNAMES_ENTRY_FRIENDLYNAME ;
                  
                  cmbQueryType.DataSource    = __QueryTypeDataSet.Tables [ 0 ] ;
                  cmbQueryType.DisplayMember = Constants.BindingInfo.ColumnNames.DBQUERYTYPES_DISPLAYVALUE ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void EnableDisableQueryView ( ) 
            {
               try
               {
                  QueryType SelectedQueryType ;
                  

                  SelectedQueryType = GetSelectedQueryType ( ) ;
                  
                  if ( SelectedQueryType == QueryType.Filtered )
                  {
                     ctlPatientQueryView.Enabled                = true ;
                     ctlImagingServiceRequestQueryView.Enabled  = true ;
                     ctlRequestedProcedureQueryView.Enabled     = true ;
                     ctlScheduledProcedureStepQueryView.Enabled = true ;
                     ctlVisitQueryView.Enabled                  = true ;
                     ctlPeformedProcedureStepQueryView.Enabled  = true ;
                     btnReset.Enabled                           = true ;
                  }
                  else
                  {
                     ctlPatientQueryView.Enabled                = false ;
                     ctlImagingServiceRequestQueryView.Enabled  = false ;
                     ctlRequestedProcedureQueryView.Enabled     = false ;
                     ctlScheduledProcedureStepQueryView.Enabled = false ;
                     ctlVisitQueryView.Enabled                  = false ;
                     ctlPeformedProcedureStepQueryView.Enabled  = false ;
                     btnReset.Enabled                           = false ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
                  
              
            private void ChangeQueryViewVisibilityState ( )
            {
               try
               {
                  pnlQueryButton.Visible   = ! pnlQueryButton.Visible ;
                  pnlQueryControls.Visible = ! pnlQueryControls.Visible ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            //private void PerformApplicationClosing ( CancelEventArgs e )
            //{
            //   try
            //   {
            //      DataSet QueryResultsDataset = null ;
                  
                  
            //      QueryResultsDataset = ( DataSet ) grdDataView.DataSource ;
                  
            //      if ( null != QueryResultsDataset ) 
            //      {
            //         if ( QueryResultsDataset.HasChanges ( ) )
            //         {
            //            DialogResult SaveChangesDialogResult ;
                     
                     
            //            SaveChangesDialogResult = GetCommitChangesUserAgreement ( ) ;
                                                                 
            //            switch ( SaveChangesDialogResult )
            //            {
            //               case DialogResult.Yes:
            //               {
            //                  if ( ! CommitChangesToDatabase ( ) )
            //                  {
            //                     e.Cancel = true ;
                                 
            //                     return ;
            //                  }
            //               }
                        
            //               break ;
                           
            //               case DialogResult.No:
            //               {
                              
            //               }
                        
            //               break ;
                           
            //               case DialogResult.Cancel:
            //               {
            //                  e.Cancel = true ;
                              
            //                  return ;
            //               }
                           
            //               default:
            //               {
            //                  throw new Exception ( "Commit changes dialog result not supported." ) ;                              
            //               }
            //            }
            //         }
            //      }
                   
            //      e.Cancel = false ;
            //   }
            //   catch ( Exception exception )
            //   {
            //      System.Diagnostics.Debug.Assert ( false ) ;
                  
            //      throw exception ;
            //   }
            //}
            
            
            private DialogResult GetCommitChangesUserAgreement ( )
            {
               try
               {
                  return MessageBox.Show ( Constants.Messages.MessageBox.DatabaseEditor_SaveChanges,
                                           Constants.Messages.MessageBox.DATABASEEDITOR_INFORMATION_CAPTION,
                                           MessageBoxButtons.YesNoCancel,
                                           MessageBoxIcon.Warning,
                                           MessageBoxDefaultButton.Button3 ) ;   
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void PerformApplicationQuery ( )
            {
               try
               {
                  DataSet QueryResultsDataset = null ;
                  
                  
                  QueryResultsDataset = ( DataSet )grdDataView.DataSource ;
                  
                  if ( null != QueryResultsDataset ) 
                  {
                     if ( QueryResultsDataset.HasChanges ( ) )
                     {
                  
                        DialogResult CommitChangesDiaolgResult ;
                        
                        
                        CommitChangesDiaolgResult = GetCommitChangesUserAgreement ( ) ;
                        
                        switch ( CommitChangesDiaolgResult )
                        {
                           case DialogResult.Yes:
                           {
                              if ( ! CommitChangesToDatabase ( ) )
                              {
                                 return ;
                              }
                           }
                           
                           break ;
                           
                           case DialogResult.No:
                           {
                                                         
                           }
                           
                           break ;
                           
                           case DialogResult.Cancel:
                           {
                              return ;
                           }
                           
                           default:
                           {
                              throw new Exception ( "Commit changes dialog result not supported." ) ;
                           }
                        }
                     }
                  }
                  
                  PerformQuery ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void PerformQuery ( )
            {
               try
               {
                  DataSet   QueryDataSet ;
                  QueryType SelectedQueryType ;
                  
                  
                  Cursor.Current = Cursors.WaitCursor ;
                  
                  SelectedQueryType = GetSelectedQueryType ( ) ;
                  
                  switch ( SelectedQueryType )
                  {
                     case QueryType.All:
                     {
                        QueryDataSet = PerformQueryAll ( ) ;
                     }
                     
                     break ;
                     
                     case QueryType.Filtered:
                     {
                        QueryDataSet = PerformQueryFiltered ( ) ;
                     }
                     
                     break ;
                     
                     case QueryType.Selected_Related:
                     {
                        if ( grdDataView.DataSource != null ) 
                        {
                           if ( GetDataGridSelectedRows ( ).Count != 0 )
                           {
                              QueryDataSet = PerformQuerySelectedRelated ( ) ;
                           }
                           else
                           {
                              MessageBox.Show ( Constants.Messages.MessageBox.DATABASEEDITOR_QUERY_RELATEDSELECTED_NOTSELECTED_MESSAGE,
                                                Constants.Messages.MessageBox.DATABASEEDITOR_INFORMATION_CAPTION,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information ) ;
                                                
                              return ;
                           }
                        }
                        else
                        {
                           MessageBox.Show ( Constants.Messages.MessageBox.DATABASEEDITOR_QUERY_RELATEDSELECTED_NOTSELECTED_MESSAGE,
                                             Constants.Messages.MessageBox.DATABASEEDITOR_INFORMATION_CAPTION,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information ) ;
                                                
                           return ;
                        }
                     }
                     
                     break ;
                     
                     default:
                     {
                        throw new Exception ( "Query type not supported" ) ;
                     }
                  }
                  
                  if ( null != QueryDataSet ) 
                  {
                     __DSValidator.BeginValidation ( QueryDataSet ) ;
                  
                     BindDatagrid ( QueryDataSet,
                                    GetSelectedDbTableName ( ).ToString ( ) ) ;
                                                          
                     HandleDataViewGridCaptionText ( ) ;
                                                       
                     RegisterDataSetEvents ( QueryDataSet ) ;
                  
                     HandleCommetUndoButtonsEnableDisableState ( false ) ;
                  }
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  MessageBox.Show ( Constants.Messages.MessageBox.DATABASEEDITOR_QUERY_FAILED,
                                    Constants.Messages.MessageBox.DATABASEEDITOR_ERROR_CAPTION,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
               }
               finally
               {
                  HandleDataViewGridCaptionText ( ) ;
                  
                  Cursor.Current = Cursors.Default ;
               }
            }
            
            private void BindDatagrid 
            ( 
               DataSet QueryDataSet, 
               string strTableName 
            ) 
            {
               try
               {
                  grdDataView.DataSource = null ;
                  grdDataView.DataMember = string.Empty ;

                  grdDataView.DataSource = QueryDataSet ;
                  grdDataView.DataMember = strTableName ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }   
            
            private DataSet PerformQueryAll ( )
            {
               try
               {
                  return GenerateDataset ( GetSelectedDbTableName ( ), new MatchingParameterCollection ( ) ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private DataSet PerformQueryFiltered ( )
            {
               try
               {
                  MatchingParameterCollection FilterMatchingArrayListCollection ;
                  DatasetType SelectedDbTableName ;
                  MatchingParameterList FilteredMatchingParametersList ;
                  
                  
                  FilterMatchingArrayListCollection = new MatchingParameterCollection ( ) ;
                  SelectedDbTableName               = GetSelectedDbTableName ( ) ;
                  FilteredMatchingParametersList    = new MatchingParameterList ( ) ;
                  
                  FillPatientQueryMatchingParameters                ( FilteredMatchingParametersList ) ;
                  FillImagingServiceRequestQueryMatchingParameters  ( FilteredMatchingParametersList ) ;
                  FillRequestedProcedureQueryMatchingParameters     ( FilteredMatchingParametersList ) ;
                  FillScheduledProcedureStepQueryMatchingParameters ( FilteredMatchingParametersList ) ;
                  FillVisitQueryMatchingParameters                  ( FilteredMatchingParametersList ) ;
                  FillPeformedProcedureStepQueryMatchingParameters  ( FilteredMatchingParametersList ) ;
                  
                  FilterMatchingArrayListCollection.Add ( FilteredMatchingParametersList ) ;
                  
                  return GenerateDataset ( SelectedDbTableName, FilterMatchingArrayListCollection ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private DataSet PerformQuerySelectedRelated ( )
            {
               try
               {
                  ArrayList SelectedRowsArrayList ;
                  MatchingParameterCollection DbMatchingParameterArrayListCollection ; 
                  
                  
                  DbMatchingParameterArrayListCollection = new MatchingParameterCollection ( ) ;
                  SelectedRowsArrayList      = GetDataGridSelectedRows ( ) ;
                  
                  if ( SelectedRowsArrayList.Count != 0 )
                  {
                     foreach ( DataRow SelectedDataRow in SelectedRowsArrayList )
                     {
                        MatchingParameterList SelectedMatchingParamsList ;
                        Dictionary <string, ICatalogEntity> matchingEntities ;
                     
                     
                        SelectedMatchingParamsList = new MatchingParameterList ( ) ;
                        matchingEntities           = new Dictionary<string,ICatalogEntity> ( ) ;
                     
                        foreach ( DataColumn PrimaryKeyDataColumn in SelectedDataRow.Table.PrimaryKey )
                        {
                           FillMatchingParameter ( SelectedDataRow,
                                                   PrimaryKeyDataColumn,
                                                   matchingEntities ) ;
                        }
                        
                        foreach ( ICatalogEntity entity in matchingEntities.Values )
                        {
                           SelectedMatchingParamsList.Add ( entity ) ;
                        }
                     
                        DbMatchingParameterArrayListCollection.Add ( SelectedMatchingParamsList ) ;
                     }
                  
                     return GenerateDataset ( GetSelectedDbTableName ( ),
                                              DbMatchingParameterArrayListCollection ) ; 
                  }
                  else
                  {
                     return null ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private DataSet GenerateDataset
            ( 
               DatasetType RequestedDatasetType,
               MatchingParameterCollection DbMatchingParameterArrayListCollection
            )
            {
               try
               {
                  IWorklistDataAccessAgent datasetDataAccessAgent ;


                  datasetDataAccessAgent = GetDataAccessAgent ( ) ;
                  
                  if ( RequestedDatasetType == DatasetType.PPSInformation )
                  {
                     return datasetDataAccessAgent.QueryMPPS ( DbMatchingParameterArrayListCollection ) ;
                  }
                  else
                  {
                     return datasetDataAccessAgent.FindPatientInformation ( DbMatchingParameterArrayListCollection ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }

            private static IWorklistDataAccessAgent GetDataAccessAgent ( )
            {
               IWorklistDataAccessAgent datasetDataAccessAgent;


               if ( !DataAccessServices.IsDataAccessServiceRegistered <IWorklistDataAccessAgent> ( ) )
               {
                  datasetDataAccessAgent = DataAccessFactory.GetInstance(new WorklistDataAccessConfigurationView(DicomDemoSettingsManager.GetGlobalPacsConfiguration(), PacsProduct.ProductName, PacsProduct.ServiceName) ).CreateDataAccessAgent<IWorklistDataAccessAgent>();
                  
                  DataAccessServices.RegisterDataAccessService  <IWorklistDataAccessAgent> ( datasetDataAccessAgent ) ;
               }
               else
               {
                  datasetDataAccessAgent = DataAccessServices.GetDataAccessService<IWorklistDataAccessAgent>();
               }
               
               return datasetDataAccessAgent;
            }
            
            
            private QueryType GetSelectedQueryType ( )
            {
               try
               {
                  string    strQueryType ;
                  QueryType SelectedQueryType ;
                  
                  
                  strQueryType =  __QueryTypeDataSet.Tables [ 0 ].Rows [ cmbQueryType.SelectedIndex ] [ Constants.BindingInfo.ColumnNames.DBQUERYTYPES_KEY ].ToString ( ) ;
                  
                  SelectedQueryType = ( QueryType ) Enum.Parse ( typeof ( QueryType ),
                                                                 strQueryType ) ;
                  
                  return SelectedQueryType ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private DatasetType GetSelectedDbTableName ( ) 
            {
               try
               {
                  string      strSelectedTableName ;
                  DatasetType SelectedDbTableName ;
                  
                  
                  strSelectedTableName = __DbTableNameToFriendlyNameDataSet.Tables [ 0 ].Rows [ cmbQueryDisplayTable.SelectedIndex ] [ Constants.BindingInfo.ColumnNames.DBTABLENAMETOFRIENDLYNAMES_ENTRY_DBNAME ].ToString ( ) ;
                  
                  SelectedDbTableName = ( DatasetType ) Enum.Parse ( typeof ( DatasetType ), 
                                                                     strSelectedTableName ) ;
                  
                  return SelectedDbTableName ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private ArrayList GetDataGridSelectedRows ( )
            {
               try
               {
                  ArrayList DisplayedRowsArrayList ;
                  ArrayList SelectedRowsArrayList ;
                  
                  
                  DisplayedRowsArrayList = GetCurrentDisplayedRows ( ) ;
                  SelectedRowsArrayList  = new ArrayList ( ) ;
                  
                  
                  for ( int i = 0; i < DisplayedRowsArrayList.Count; i++ ) 
                  {
                     if ( grdDataView.IsSelected ( i ) ) 
                     {
                        SelectedRowsArrayList.Add ( DisplayedRowsArrayList [ i ] ) ;
                     }
                  }
            
                  return SelectedRowsArrayList ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private ArrayList GetCurrentDisplayedRows ( )
            {
               try
               {
                  ArrayList          ReturnArrayList                = null ;
                  BindingManagerBase SelectedRowsBindingManagerBase = null ;
                  DataRow []         arrAllRelatedDataRows          = null ;
                     

                  if ( null == grdDataView.DataSource )
                  {
                     return new ArrayList ( ) ;
                  }
                  
                  ReturnArrayList                = new ArrayList ( ) ;
                  SelectedRowsBindingManagerBase = grdDataView.BindingContext [ grdDataView.DataSource,
                                                                                grdDataView.DataMember ] ;  
                                                                                        
                  if ( -1 != SelectedRowsBindingManagerBase.Position )
                  {
                     if ( grdDataView.DataMember.IndexOf ( Constants.SpecialCharacters.DOT ) != -1 )
                     {
                        DataRow ParentRow       = null ;
                        string  strDataMember   = string.Empty ;
                        string  strRelationName = string.Empty ;
                        int     nLastIndexofDot = -1 ; 
                           
                           
                        strDataMember = grdDataView.DataMember ;
                        
                        nLastIndexofDot = strDataMember.LastIndexOf ( Constants.SpecialCharacters.DOT ) ;
                        
                        strRelationName = strDataMember.Remove ( 0, nLastIndexofDot + 1 ) ;
                        
                        try
                        {
                           ParentRow = ( ( DataRowView ) SelectedRowsBindingManagerBase.Current ).Row.GetParentRow ( strRelationName ) ;  
                        }
                        catch ( System.Exception )
                        {
                           return new ArrayList ( ) ;
                        }
                     
                        if ( null != ParentRow ) 
                        {
                           arrAllRelatedDataRows = ParentRow.GetChildRows ( strRelationName ) ;  
                        }
                     }
                     else
                     {
                        ArrayList DisplayedDataRowsArrayList = null ;
                        
                        
                        try
                        {
                           DisplayedDataRowsArrayList = new ArrayList ( ( ( DataRowView ) SelectedRowsBindingManagerBase.Current ).Row.Table.Rows ) ;  
                        }
                        catch ( System.Exception )
                        {
                           return new ArrayList ( ) ;
                        }
                        
                        arrAllRelatedDataRows =  ( DataRow [] ) DisplayedDataRowsArrayList.ToArray ( typeof ( DataRow ) ) ;
                     }
                  }
                  
                  if ( null != arrAllRelatedDataRows ) 
                  {
                     foreach ( DataRow DisplayedRow in arrAllRelatedDataRows )
                     {
                        if ( ( DisplayedRow.RowState != DataRowState.Deleted ) &&
                             ( DisplayedRow.RowState != DataRowState.Detached ) )
                        {
                           ReturnArrayList.Add ( DisplayedRow ) ;
                        }
                     }
                  }
                  
                  return ReturnArrayList ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private bool IsDeleteRequestValid ( )
            {
               try
               {
                  DialogResult DeleteDialogResult ;
                  
                  
                  DeleteDialogResult = MessageBox.Show ( Constants.Messages.MessageBox.DATABASEEDITOR_DELETE_WARNING_MESSAGE,
                                                         Constants.Messages.MessageBox.DATABASEEDITOR_WARNING_CAPTION,
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Warning,
                                                         MessageBoxDefaultButton.Button2 ) ;
                                                         
                  if ( DialogResult.Yes == DeleteDialogResult )
                  {
                     return true ;
                  }
                  else
                  {
                     return false ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void DeleteSelectedDataGridRows ( )
            {
               try
               {
                  Cursor.Current = Cursors.WaitCursor ;
                  
                  if ( null != grdDataView.DataSource ) 
                  {
                     if ( IsDeleteRequestValid ( ) )
                     {
                        ArrayList SelectedRowsArrayList ;
                        
                        
                        SelectedRowsArrayList = GetDataGridSelectedRows ( ) ;
                        
                        foreach ( DataRow SelectedRow in SelectedRowsArrayList ) 
                        {
                           SelectedRow.Delete ( ) ;
                        }
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                  
                  MessageBox.Show ( Constants.Messages.MessageBox.DATABASEEDITOR_DATABASEEDITOR_DELETE_ERROR_MESSAGE,
                                    Constants.Messages.MessageBox.DATABASEEDITOR_ERROR_CAPTION,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
               }
               finally
               {
                  Cursor.Current = Cursors.Default ;
               }
            }
            
            
            private void FillMatchingParameter
            ( 
               DataRow SelectedDataRow,
               DataColumn PrimaryKeyDataColumn,
               Dictionary <string, ICatalogEntity> matchingEntities
            ) 
            {
               try
               {
                  PropertyInfo matchingPropertyInfo ;
                  ICatalogEntity matchingEntity ;
                  
                  
                  matchingPropertyInfo = GetMatchingProperty ( PrimaryKeyDataColumn, 
                                                               matchingEntities, 
                                                               out matchingEntity ) ;
                  
                  if ( PrimaryKeyDataColumn.DataType == typeof ( DateTime ) )
                  {
                     Type      valueType ;
                     DateTime  matchingDate ;
                     object    propertyValue ;
                     
                     
                     valueType     = matchingPropertyInfo.PropertyType ;
                     matchingDate  = ( DateTime ) SelectedDataRow [ PrimaryKeyDataColumn ] ;
                     propertyValue = null ;
                     
                     if ( valueType == typeof ( DicomDateRangeValue? ) ) 
                     {
                        DicomDateRangeValue? dateRangeValue ;
                        
                        
                        dateRangeValue = new DicomDateRangeValue ( DicomRangeType.Both, 
                                                                   new DicomDateValue ( matchingDate ), 
                                                                   new DicomDateValue ( matchingDate ) ) ;
                                                                   
                        propertyValue = dateRangeValue ;
                     }
                     else if ( valueType == typeof ( DicomTimeRangeValue?) )
                     {
                        DicomTimeRangeValue? timeRangeValue ;
                        
                        
                        timeRangeValue = new DicomTimeRangeValue ( DicomRangeType.Both, 
                                                                   new DicomTimeValue ( matchingDate ), 
                                                                   new DicomTimeValue ( matchingDate ) ) ;
                                                                   
                        propertyValue = timeRangeValue ;
                     } 
                     else if ( valueType == typeof ( DateRange ) )
                     {
                        DateRange dateValue ;
                        
                        
                        dateValue = new DateRange ( ) ;
                        
                        dateValue.StartDate = matchingDate  ;
                        dateValue.EndDate   = matchingDate ;
                        
                        propertyValue = dateValue ;
                     }
                     else if ( valueType == typeof ( DateTime ) )
                     {
                        propertyValue = matchingDate ;
                     }
                     
                     matchingPropertyInfo.SetValue ( propertyValue, matchingEntity, null ) ;
                  }
                  else
                  {  
                     matchingPropertyInfo.SetValue ( matchingEntity, SelectedDataRow [ PrimaryKeyDataColumn ], null ) ;
                     
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private PropertyInfo GetMatchingProperty
            ( 
               DataColumn primaryKeyDataColumn,
               Dictionary <string, ICatalogEntity> matchingEntities,
               out ICatalogEntity matchingEntity
            )
            {
               try
               {
                  MatchingParametersDataSet.MatchingColumnsRow columnNameDataRow ;
                  
                  
                  columnNameDataRow = __ColumnsMatchingParametersDataSet.MatchingColumns.FindByTableNameColumnName ( primaryKeyDataColumn.Table.TableName, 
                                                                                                                     primaryKeyDataColumn.ColumnName ) ;
                  
                  if ( null != columnNameDataRow ) 
                  {
                     string matchingEntityType ;
                     Type   dicomEntityType ;
                     
                     
                     matchingEntityType = columnNameDataRow.MatchingEntityType ;
                     dicomEntityType    = Type.GetType             ( matchingEntityType ) ;
                     
                     if ( matchingEntities.ContainsKey ( matchingEntityType ) )
                     {
                        matchingEntity = matchingEntities [ matchingEntityType ] ;
                     }
                     else
                     {
                        matchingEntity  = Activator.CreateInstance ( dicomEntityType ) as ICatalogEntity ;
                        
                        if ( matchingEntity == null ) 
                        {
                           throw new Exception ( string.Format ( "Can't create ICatalogEntity from {0}", dicomEntityType ) ) ; 
                        }
                        
                        matchingEntities.Add ( matchingEntityType, matchingEntity ) ;
                     }
                     
                     if ( matchingEntity is ICatalogEntity ) 
                     {
                        string       key ;
                        string       name ;
                        string       fieldName ;
                        PropertyInfo info ;
                        
                        
                        key       = ( matchingEntity as ICatalogEntity ).CatalogKey ;
                        name      = __Catalog.GetEntityName ( key ) ;
                        fieldName = columnNameDataRow.MatchingPropertyName ;
                        
                        info = dicomEntityType.GetProperty ( fieldName, 
                                                             BindingFlags.Instance | BindingFlags.Public ) ;
                        
                        return info ;
                     }
                     else
                     {
                        throw new Exception ( "Column Name is not supported in Matching Element Type" ) ; 
                     }
                  }

                  throw new Exception ( "Column Name is not supported in Matching Element Type" ) ; 
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private string GetGridDataMember ( )
            {
               try
               {
                  string strGridDataMember = string.Empty ;
                  
                  
                  strGridDataMember = grdDataView.DataMember ;
                  
                  if ( strGridDataMember.IndexOf ( "." ) != -1 ) 
                  {
                     strGridDataMember = strGridDataMember.Substring ( strGridDataMember.LastIndexOf ( "." ) + 1 ) ;
                  }
                  
                  return strGridDataMember ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void FillPatientQueryMatchingParameters
            ( 
               MatchingParameterList PatientMatchingParametersList 
            )
            {
               try
               {
                  Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters.Patient patient ;
                  bool    addEntity = false ;
                  
                  
                  patient = new Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters.Patient ( ) ;
                  
                  {//PatientID
                     
                     if ( string.Empty != ctlPatientQueryView.PatientID ) 
                     {
                        patient.PatientID = ctlPatientQueryView.PatientID.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR, 
                                                                                    Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                     
                        addEntity = true ;
                     }
                  
                  }//PatientID
                  
                  {//IssuerOfPatientID
                     
                     if ( string.Empty != ctlPatientQueryView.IssuerOfPatientID ) 
                     {
                        patient.IssuerOfPatientID = ctlPatientQueryView.IssuerOfPatientID.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR, 
                                                                                                    Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                        
                        addEntity = true ;
                     }
                     
                  }//IssuerOfPatientID
                  
                  {//PatientFirstName
                     
                     if ( string.Empty != ctlPatientQueryView.FirstName ) 
                     {   
                        patient.PatientNameGivenName = ctlPatientQueryView.FirstName.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR, 
                                                                                               Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                     
                        addEntity = true ;
                     }
                        
                  }//PatientFirstName
                  
                  {//PatientMiddleName
                     
                     if ( string.Empty != ctlPatientQueryView.MiddleName ) 
                     {      
                        patient.PatientNameMiddleName = ctlPatientQueryView.MiddleName.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR, 
                                                                                                 Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                     
                        addEntity = true ;
                     }
                           
                  }//PatientMiddleName
                  
                  {//PatientLastName
                              
                      if ( string.Empty != ctlPatientQueryView.LastName ) 
                      {
                        patient.PatientNameFamilyName = ctlPatientQueryView.LastName.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR, 
                                                                                               Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                     
                        addEntity = true ;
                     }
                              
                  }//PatientLastName
                  
                  
                  {//PatientBirthDate
                                 
                     if ( ( string.Empty != ctlPatientQueryView.DateOfBirthFrom ) ||
                          ( string.Empty != ctlPatientQueryView.DateOfBirthTo ) ) 
                     {
                        DateTime? date1 = null ;
                        DateTime? date2 = null ;
                        DicomDateRangeValue dicomRange ;
                        
                        
                        if ( !string.IsNullOrEmpty ( ctlPatientQueryView.DateOfBirthFrom ) )
                        {
                           date1 = DateTime.Parse ( ctlPatientQueryView.DateOfBirthFrom ) ;
                        }
                        
                        if ( !string.IsNullOrEmpty ( ctlPatientQueryView.DateOfBirthTo ) )
                        {
                           date2 = DateTime.Parse ( ctlPatientQueryView.DateOfBirthTo ) ;
                        }
                        
                        dicomRange = new DicomDateRangeValue ( ) ;
                        
                        dicomRange.Type = DicomRangeType.None ;
                        
                        if ( null != date1 )
                        {
                           dicomRange.Date1 = new DicomDateValue ( date1.Value ) ;
                           dicomRange.Type  = DicomRangeType.Lower ;
                        }
                        
                        if ( null != date2 ) 
                        {
                           if ( dicomRange.Type == DicomRangeType.Lower )
                           {
                              dicomRange.Date2 = new DicomDateValue ( date2.Value ) ;
                              dicomRange.Type  = DicomRangeType.Both ;
                           }
                           else
                           {
                              dicomRange.Date1 = new DicomDateValue ( date2.Value ) ;
                              dicomRange.Type  = DicomRangeType.Upper ;
                           }
                        }
                        
                        if ( dicomRange.Type != DicomRangeType.None )
                        {
                           patient.PatientBirthDate = dicomRange ;
                           
                           addEntity = true ;
                        }
                     }
                                 
                  }//PatientBirthDate
                  
                  if ( addEntity ) 
                  {
                     PatientMatchingParametersList.Add ( patient ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void FillImagingServiceRequestQueryMatchingParameters 
            ( 
               MatchingParameterList ImagingServiceRequestMatchingParametersList
            )
            {
               try
               {
                  {//AccessionNumber
                  
                     if ( string.Empty != ctlImagingServiceRequestQueryView.AccessionNumber )
                     {
                        ImagingServiceRequest imagingService ;
                        
                        
                        imagingService = new ImagingServiceRequest ( ) ;
                        
                        imagingService.AccessionNumber = ctlImagingServiceRequestQueryView.AccessionNumber.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                                                     Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                        
                        ImagingServiceRequestMatchingParametersList.Add ( imagingService ) ;
                     }
                     
                  }//AccessionNumber
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void FillRequestedProcedureQueryMatchingParameters 
            ( 
               MatchingParameterList requestedProcedureMatchingParametersList
            )
            {
               try
               {
                  RequestedProcedure requestedProcedure ;
                  bool               addEntity = false ;
                  
                  
                  requestedProcedure = new RequestedProcedure ( ) ;
                  
                  {//RequestedProcedureID
                  
                     if ( string.Empty != ctlRequestedProcedureQueryView.RequestedProcedureID )
                     {
                        requestedProcedure.RequestedProcedureID =  ctlRequestedProcedureQueryView.RequestedProcedureID.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                                                                 Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                        addEntity = true ;
                     }
                     
                  }//RequestedProcedureID
                  
                  {//StudyInstanceUID
                     
                     if ( string.Empty != ctlRequestedProcedureQueryView.StudyInstanceUID )
                     {
                        requestedProcedure.StudyInstanceUID = ctlRequestedProcedureQueryView.StudyInstanceUID.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                                                        Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                           
                        addEntity = true ;
                     }
                        
                  }//StudyInstanceUID
                  
                  {//RequestedProcedurePriority
                        
                     if ( string.Empty != ctlRequestedProcedureQueryView.RequestedProcedurePriority )
                     {
                        requestedProcedure.RequestedProcedurePriority = ctlRequestedProcedureQueryView.RequestedProcedurePriority.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                                                                             Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                              
                        addEntity = true ;
                     }
                           
                  }//RequestedProcedurePriority
                  
                  if ( addEntity )
                  {
                     requestedProcedureMatchingParametersList.Add ( requestedProcedure ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void FillScheduledProcedureStepQueryMatchingParameters 
            ( 
               MatchingParameterList scheduledProcedureStepMatchingParametersList 
            )
            {
               try
               {
                  Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters.ScheduledProcedureStep scheduledProcedureStep ;
                  bool                   addEntity = false ;
                  
                  
                  scheduledProcedureStep = new Leadtools.Medical.Worklist.DataAccessLayer.MatchingParameters.ScheduledProcedureStep ( ) ;
                  
                  {//ScheduledProcedureStepID
                  
                     if ( string.Empty != ctlScheduledProcedureStepQueryView.ScheduledProcedureStepID ) 
                     {
                        scheduledProcedureStep.ScheduledProcedureStepID = ctlScheduledProcedureStepQueryView.ScheduledProcedureStepID.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                                                                                Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                        
                        addEntity = true ;
                     }
                     
                  }//ScheduledProcedureStepID
                  
                  {//Modality
                  
                     if ( string.Empty != ctlScheduledProcedureStepQueryView.Modality ) 
                     {
                        scheduledProcedureStep.Modality = ctlScheduledProcedureStepQueryView.Modality.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                                                Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                        
                        addEntity = true ;
                     }
                     
                  }//Modality
                  
                  {//StationAETitle
                     
                     if ( string.Empty != ctlScheduledProcedureStepQueryView.StationAETitle ) 
                     {
                        ScheduledStationAETitles stationAeTitles ;
                        
                        
                        stationAeTitles = new ScheduledStationAETitles ( ) ;
                        
                        stationAeTitles.ScheduledStationAETitle = ctlScheduledProcedureStepQueryView.StationAETitle.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                                                              Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                           
                        scheduledProcedureStepMatchingParametersList.Add ( stationAeTitles ) ;
                     }
                        
                  }//StationAETitle
                  
                  {//ScheduledPerformingPhysicianFirstName
                        
                     if ( string.Empty != ctlScheduledProcedureStepQueryView.ScheduledPerformingPhysicianFirstName ) 
                     {
                        scheduledProcedureStep.ScheduledPerformingPhysicianNameGivenName = ctlScheduledProcedureStepQueryView.ScheduledPerformingPhysicianFirstName.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                                                                                                              Constants.SpecialCharacters.DataAccessFieldSeparator ) ;

                        addEntity = true ;
                     }
                           
                  }//ScheduledPerformingPhysicianFirstName
                  
                  {//ScheduledPerformingPhysicianMiddleName
                           
                     if ( string.Empty != ctlScheduledProcedureStepQueryView.ScheduledPerformingPhysicianMiddleName ) 
                     {
                        scheduledProcedureStep.ScheduledPerformingPhysicianNameMiddleName = ctlScheduledProcedureStepQueryView.ScheduledPerformingPhysicianMiddleName.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                                                                                                                Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                                 
                        addEntity = true ;
                     }
                              
                  }//ScheduledPerformingPhysicianMiddleName
                  
                  {//ScheduledPerformingPhysicianLastName
                              
                     if ( string.Empty != ctlScheduledProcedureStepQueryView.ScheduledPerformingPhysicianLastName ) 
                     {
                        scheduledProcedureStep.ScheduledPerformingPhysicianNameFamilyName = ctlScheduledProcedureStepQueryView.ScheduledPerformingPhysicianLastName.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                                                                                                              Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                                    
                        addEntity = true ;
                     }

                  }//ScheduledPerformingPhysicianLastName
                  
                  {//StartDateTime
                                 
                     if ( ( string.Empty != ctlScheduledProcedureStepQueryView.ScheduledProcedureStepStartDateTimeFrom ) ||
                          ( string.Empty != ctlScheduledProcedureStepQueryView.ScheduledProcedureStepStartDateTimeTo ) )
                     {
                        DateRange dateTimeRange ;
                        
                        
                        dateTimeRange = new DateRange ( ) ;
                        
                        if ( !string.IsNullOrEmpty ( ctlScheduledProcedureStepQueryView.ScheduledProcedureStepStartDateTimeFrom ) )
                        {
                           dateTimeRange.StartDate = DateTime.Parse ( ctlScheduledProcedureStepQueryView.ScheduledProcedureStepStartDateTimeFrom ) ;
                        }
                        
                        if ( !string.IsNullOrEmpty ( ctlScheduledProcedureStepQueryView.ScheduledProcedureStepStartDateTimeTo ) )
                        {
                           dateTimeRange.EndDate = DateTime.Parse ( ctlScheduledProcedureStepQueryView.ScheduledProcedureStepStartDateTimeTo ) ;
                        }
                        
                        scheduledProcedureStep.ScheduledProcedureStepStartDate_Time = dateTimeRange ;
                        
                        addEntity = true ;
                     }

                  }//StartDateTime
                  
                  if ( addEntity ) 
                  {
                     scheduledProcedureStepMatchingParametersList.Add ( scheduledProcedureStep ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void FillVisitQueryMatchingParameters 
            ( 
               MatchingParameterList VisitMatchingParametersList
            )
            {
               try
               {
                  {//AdmissionID
                  
                     if ( string.Empty != ctlVisitQueryView.AdmissionID ) 
                     {
                        Visit visit ;
                        
                        
                        visit = new Visit ( ) ;
                        
                        visit.AdmissionID = ctlVisitQueryView.AdmissionID.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                    Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                        
                        VisitMatchingParametersList.Add ( visit ) ;
                     }
                     
                  }//AdmissionID
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void FillPeformedProcedureStepQueryMatchingParameters
            (
               MatchingParameterList PPSMatchingParametersList
            )
            {
               try
               {
                  PPSInformation ppsInformation ;
                  string strMPPSSOPInstanceUIDs = null ;
                  string strStudyInstanceUIDs   = null ;
                  string strMPPSStatus          = null ;
                  string strMPPSStartDateFrom   = null ;
                  string strMPPSStartDateTo     = null ;
                  bool   addEntity              = false ;
                  
                  ppsInformation         = new PPSInformation ( ) ;
                  strMPPSSOPInstanceUIDs = ctlPeformedProcedureStepQueryView.MPPSSOPInstanceUIDs ;
                  strStudyInstanceUIDs   = ctlPeformedProcedureStepQueryView.StudyInstanceUIDs ;
                  strMPPSStatus          = ctlPeformedProcedureStepQueryView.MPPSStatus ;
                  strMPPSStartDateFrom   = ctlPeformedProcedureStepQueryView.MPPSStartDateFrom ;
                  strMPPSStartDateTo     = ctlPeformedProcedureStepQueryView.MPPSStartDateTo ;
                  
                  if ( string.Empty != strMPPSSOPInstanceUIDs )
                  {
                     ppsInformation.MPPSSOPInstanceUID = strMPPSSOPInstanceUIDs.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                          Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                     
                     addEntity = true ;
                  }
                  
                  if ( string.Empty != strStudyInstanceUIDs )
                  {
                     ppsInformation.StudyInstanceUID = strStudyInstanceUIDs.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                      Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                     
                     addEntity = true ;
                  }
                  
                  
                  if ( 0 != strMPPSStatus.Length )
                  {
                     ppsInformation.PerformedProcedureStepStatus = strMPPSStatus.Replace ( Constants.SpecialCharacters.QUERY_FIELD_SEPARATOR,
                                                                                           Constants.SpecialCharacters.DataAccessFieldSeparator ) ;
                     
                     addEntity = true ;
                  }
                  
                  
                  if ( string.Empty != strMPPSStartDateTo || string.Empty != strMPPSStartDateFrom )
                  {
                     DateTime? date1 = null ;
                     DateTime? date2 = null ;
                     DicomDateRangeValue dicomDateRange ;
                     DicomTimeRangeValue dicomTimeRange ;
                        
                        
                     if ( !string.IsNullOrEmpty ( strMPPSStartDateFrom ) )
                     {
                        date1 = DateTime.Parse ( strMPPSStartDateFrom ) ;
                     }
                     
                     if ( !string.IsNullOrEmpty ( strMPPSStartDateTo ) )
                     {
                        date2 = DateTime.Parse ( strMPPSStartDateTo ) ;
                     }
                     
                     dicomDateRange = new DicomDateRangeValue ( ) ;
                     dicomTimeRange = new DicomTimeRangeValue ( ) ;
                     
                     dicomDateRange.Type = DicomRangeType.None ;
                     dicomTimeRange.Type = DicomRangeType.None ;
                     
                     if ( null != date1 )
                     {
                        dicomDateRange.Date1 = new DicomDateValue ( date1.Value ) ;
                        dicomDateRange.Type  = DicomRangeType.Lower ;
                        dicomTimeRange.Time1 = new DicomTimeValue ( date1.Value ) ;
                        dicomTimeRange.Type  = DicomRangeType.Lower ;
                     }
                     
                     if ( null != date2 ) 
                     {
                        if ( dicomDateRange.Type == DicomRangeType.Lower )
                        {
                           dicomDateRange.Date2 = new DicomDateValue ( date2.Value ) ;
                           dicomDateRange.Type  = DicomRangeType.Both ;
                           dicomTimeRange.Time2 = new DicomTimeValue ( date2.Value ) ;
                           dicomTimeRange.Type  = DicomRangeType.Both ;
                        }
                        else
                        {
                           dicomDateRange.Date1 = new DicomDateValue ( date2.Value ) ;
                           dicomDateRange.Type  = DicomRangeType.Upper ;
                           dicomTimeRange.Time1 = new DicomTimeValue ( date2.Value ) ;
                           dicomTimeRange.Type  = DicomRangeType.Upper ;
                        }
                     }
                     
                     if ( dicomDateRange.Type != DicomRangeType.None )
                     {
                        ppsInformation.PerformedProcedureStepStartDate = dicomDateRange ;
                        ppsInformation.PerformedProcedureStepStartTime = dicomTimeRange ;
                        
                        addEntity = true ;
                     }
                  }
                  
                  if ( addEntity )
                  {
                     PPSMatchingParametersList.Add ( ppsInformation ) ;
                  }
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
            
            private void HandleValidationError 
            ( 
               string strReason, 
               DataColumnChangeEventArgs e
            )
            {
               try
               {
                  MessageBox.Show ( string.Format ( Constants.Messages.MessageBox.DATABASEEDITOR_UPDATE_VALIDATION_ERROR_MESSAGE, e.Column.ColumnName, strReason ),
                                    Constants.Messages.MessageBox.DATABASEEDITOR_ERROR_CAPTION,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
                  
                  
                  e.ProposedValue = e.Row [ e.Column, GetValidRowVersion ( e.Row ) ] ;
                  
                  e.Row.SetColumnError ( e.Column, 
                                         string.Empty ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private bool IsUndoRequestValid ( )
            {
               try
               {
                  DialogResult UndoRequestDialogResult ;
                  
                  
                  UndoRequestDialogResult = MessageBox.Show ( Constants.Messages.MessageBox.DATABASEEDITOR_UNDO_WARNING_MESSAGE,
                                                              Constants.Messages.MessageBox.DATABASEEDITOR_WARNING_CAPTION,
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Warning,
                                                              MessageBoxDefaultButton.Button2 ) ;
                                                              
                  if ( DialogResult.Yes == UndoRequestDialogResult )
                  {
                     return true ;
                  }
                  else
                  {
                     return false ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void RejectDataSetChanges ( )
            {
               try
               {
                  Cursor.Current = Cursors.WaitCursor ;
                  
                  if ( null != grdDataView.DataSource )
                  {
                     if ( IsUndoRequestValid ( ) )
                     {
                        ( ( DataSet ) grdDataView.DataSource ).RejectChanges ( ) ;
                        
                        ClearErrors ( ( DataSet ) grdDataView.DataSource ) ;
                        
                        grdDataView.Refresh ( ) ;
                        
                        HandleCommetUndoButtonsEnableDisableState ( false ) ;
                     }
                     else
                     {
                        HandleCommetUndoButtonsEnableDisableState ( true ) ;
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                  
                  MessageBox.Show ( Constants.Messages.MessageBox.DATABASEEDITOR_UNDO_ERROR_MESSAGE,
                                    Constants.Messages.MessageBox.DATABASEEDITOR_ERROR_CAPTION,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
               }
               finally
               {
                  Cursor.Current = Cursors.Default ;
               }
            }
            
            
            private void ClearErrors ( DataSet DirtyDataSet ) 
            {
               try
               {
                  foreach ( DataTable DirtyTable in DirtyDataSet.Tables )
                  {
                     if ( DirtyTable.HasErrors )
                     {
                        DataRow [] arrDirtyDataRow ;
                        
                        
                        arrDirtyDataRow = DirtyTable.GetErrors ( ) ;
                        
                        foreach ( DataRow DirtyDataRow in arrDirtyDataRow )
                        {
                           DirtyDataRow.ClearErrors ( ) ;
                        }
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private bool CommitChangesToDatabase ( )
            {
               try
               {
                  Cursor.Current = Cursors.WaitCursor ;
                  
                  bool fResult ;
                  
                  
                  fResult = false ;
                  
                  if ( null != grdDataView.DataSource ) 
                  {
                     if ( IsCommitChangesAcceptedByUser ( ) ) 
                     {
                        bool    bIsValid = false ;
                        string  strValidationReason = string.Empty ;
                        
                        
                        bIsValid = __DSValidator.IsDataSetValid ( ( DataSet ) grdDataView.DataSource, ref strValidationReason ) ;
                         
                        if ( bIsValid )
                        {
                           try
                           {
                              UpdateDatabase ( ( DataSet ) grdDataView.DataSource ) ; 
                                                               
                              HandleDataViewGridCaptionText ( ) ;
                              
                              ClearErrors ( ( DataSet ) grdDataView.DataSource ) ;
                              
                              grdDataView.Refresh ( ) ;
                                                                                             
                              MessageBox.Show ( Constants.Messages.MessageBox.DATABASEEDITOR_COMMIT_SUCCESS_MESSAGE,
                                                Constants.Messages.MessageBox.DATABASEEDITOR_INFORMATION_CAPTION,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information ) ; 
                                                
                              fResult = true ;
                           }
                           catch ( Exception exception )
                           {
                              if ( IsNavigationRequestedByUserOnCommittingError ( exception.Message ) )
                              {
                                 NavigateToDataSetError ( ) ;
                              }
                           }
                        }
                        else
                        {
                           if ( IsNavigationRequestedByUserOnCommittingError ( strValidationReason ) )
                           {
                              NavigateToDataSetError ( ) ;
                           }
                        }
                     }
                  }
                  
                  HandleCommetUndoButtonsEnableDisableState ( ! fResult ) ;
                  
                  return fResult ;
               }
               catch ( Exception exp ) 
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exp ;
               }
               finally
               {
                  HandleDataViewGridCaptionText ( ) ;
                  
                  Cursor.Current = Cursors.Default ;
               }
            }
            
            
            private void UpdateDatabase ( DataSet UpdatedDataset )
            {
               try
               {
                  if ( UpdatedDataset.HasChanges ( ) )
                  {
                     IWorklistDataAccessAgent AccessAgent ;
                     
                     
                     AccessAgent = GetDataAccessAgent ( ) ;
                     
                     if ( UpdatedDataset is MWLDataset ) 
                     {
                        AccessAgent.UpdateMWL ( ( MWLDataset ) UpdatedDataset ) ;
                     
                        return ;
                     }
                     else if ( UpdatedDataset is MPPSDataset )
                     {
                        AccessAgent.UpdateMPPS ( ( MPPSDataset ) UpdatedDataset ) ;
                        
                        return ;
                     }
                     
                     throw new Exception ( "Invalid dataset type" ) ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private bool IsCommitChangesAcceptedByUser ( )
            {
               try
               {
                  DialogResult CommitChangesDialogResult ;
                  
                  
                  CommitChangesDialogResult = MessageBox.Show ( Constants.Messages.MessageBox.DATABASEEDITOR_COMMITCHANGES_WARNING_MESSAGE,
                                                                Constants.Messages.MessageBox.DATABASEEDITOR_WARNING_CAPTION,
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Warning,
                                                                MessageBoxDefaultButton.Button2 ) ;
                                                                
                  if ( DialogResult.Yes == CommitChangesDialogResult )
                  {
                     return true ;
                  }
                  else
                  {
                     return false ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private bool IsNavigationRequestedByUserOnCommittingError 
            ( 
               string strMessageParam
            )
            {
               try
               {
                  DialogResult CommitingErrorDialogResult ;
                  
                  
                  CommitingErrorDialogResult = MessageBox.Show ( string.Format ( Constants.Messages.MessageBox.DATABASEEDITOR_COMMIT_ERROR_MESSAGE, strMessageParam ),
                                                                 Constants.Messages.MessageBox.DATABASEEDITOR_ERROR_CAPTION,
                                                                 MessageBoxButtons.YesNo,
                                                                 MessageBoxIcon.Error,
                                                                 MessageBoxDefaultButton.Button2 ) ;                   

                  switch ( CommitingErrorDialogResult )
                  {
                     case DialogResult.Yes:
                     {
                        return true ;
                     }
                     
                     default:
                     {
                        return false ;
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
                        
            private DataRowVersion GetValidRowVersion ( DataRow CurrentRow )
            {
               try
               {
                  DataRowVersion LastRowVersion ;
                  
                  
                  if ( CurrentRow.HasVersion ( DataRowVersion.Current ) )
                  {
                     LastRowVersion = DataRowVersion.Current ;
                  }
                  else
                  {
                     if ( CurrentRow.HasVersion ( DataRowVersion.Original ) )
                     {
                        LastRowVersion  = DataRowVersion.Original ;
                     }
                     else
                     {
                        LastRowVersion  = DataRowVersion.Default ;
                     }
                  }
                  
                  return LastRowVersion ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void RegisterDataSetEvents ( DataSet QueryDataSet )
            {
               try
               {
                  foreach ( DataTable QueryDataTable in QueryDataSet.Tables ) 
                  {
                     QueryDataTable.ColumnChanged += new DataColumnChangeEventHandler ( QueryDataTable_ColumnChanged ) ;
                     QueryDataTable.RowChanged    += new DataRowChangeEventHandler ( QueryDataTable_RowChanged ) ;
                     QueryDataTable.RowDeleted    +=new DataRowChangeEventHandler ( QueryDataTable_RowDeleted );
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void HandleTableChange 
            (
               DataRow ChangedRow
            )
            {
               try
               {
                  if ( DataRowState.Detached != ChangedRow.RowState )
                  {
                     HandleCommetUndoButtonsEnableDisableState ( true ) ;
                  }
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void HandleCommetUndoButtonsEnableDisableState ( bool bState )
            {
               try
               {
                  btnCommitChanges.Enabled = bState ;
                  btnUndoChanges.Enabled   = bState ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void ResetQueryControls ( )
            {
               try
               {
                  ctlPatientQueryView.Reset ( ) ;
                  ctlImagingServiceRequestQueryView.Reset ( ) ;
                  ctlRequestedProcedureQueryView.Reset ( ) ;
                  ctlScheduledProcedureStepQueryView.Reset ( ) ;
                  ctlVisitQueryView.Reset ( ) ;
                  ctlPeformedProcedureStepQueryView.Reset ( ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void HandleDataViewGridCaptionText ( ) 
            {
               try
               {
                  string strCurrentTableName ;
                                            
                                            
                  strCurrentTableName = grdDataView.DataMember.Substring ( grdDataView.DataMember.LastIndexOf ( Constants.SpecialCharacters.DOT ) + 1 ) ;
                  
                  if ( strCurrentTableName != string.Empty ) 
                  {
                     grdDataView.CaptionText = Constants.General.DATAGRID_CAPTION_TEXT_MAIN + Constants.SpecialCharacters.DASH + "(" + strCurrentTableName + ")" ;
                  }
                  else
                  {
                     grdDataView.CaptionText = Constants.General.DATAGRID_CAPTION_TEXT_MAIN ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void HandleDeleteButtonEnableState ( )
            {
               try
               {
                  if ( null != grdDataView.DataSource ) 
                  {
                     if ( GetDataGridSelectedRows ( ).Count > 0 )
                     {
                        btnDelete.Enabled = true ;
                     }
                     else
                     {
                        btnDelete.Enabled = false ;
                     }
                  }
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  btnDelete.Enabled = false ;
               }
            }
            
            
            private void NavigateToDataSetError ( )
            {
               try
               {
                  NavigateToDataRow ( GetFirstDirtyRow ( ( DataSet ) grdDataView.DataSource ) ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void NavigateToDataRow ( DataRow RequredDataRow ) 
            {
               try
               {
                  grdDataView.SuspendLayout ( ) ;
                  
                  if ( null != RequredDataRow ) 
                  {
                     ArrayList RelationNamesArrayList = null ;
                     Stack     TopParentDataRowStack  = null ;
                     
                     
                     RelationNamesArrayList = new ArrayList ( ) ;
                     
                     RelationNamesArrayList.AddRange ( GetDataRowFullPath ( RequredDataRow ).Split ( Constants.SpecialCharacters.DOT.ToCharArray ( ) ) ) ;
                     
                     TopParentDataRowStack = GetDataRowParents ( RequredDataRow ) ;
                     
                     if ( 0 != RelationNamesArrayList.Count ) 
                     {
                        DataRow ParentDataRow   = null ;
                        int     nParentRowIndex = -1 ;
                        
                        
                        grdDataView.DataMember = RelationNamesArrayList [ 0 ].ToString ( ) ;
                        
                        if ( TopParentDataRowStack.Count > 0 )
                        {
                           ParentDataRow = ( DataRow ) TopParentDataRowStack.Pop ( ) ;
                           
                           nParentRowIndex = GetRowIndexFromArray (  ParentDataRow, 
                                                                     ( DataRow [] ) new ArrayList ( ParentDataRow.Table.Rows ).ToArray ( typeof ( DataRow ) ) ) ;
                           
                           for ( int i = 1 ; i < RelationNamesArrayList.Count; i++ ) 
                           {
                              grdDataView.NavigateTo ( ( nParentRowIndex ), 
                                                      RelationNamesArrayList [ i ].ToString ( ) ) ;
                              
                              if ( TopParentDataRowStack.Count > 0 )
                              {
                                 ParentDataRow = ( DataRow ) TopParentDataRowStack.Pop ( ) ;
                              
                                 nParentRowIndex = GetRowIndexFromArray ( ParentDataRow ,
                                                                        ParentDataRow.GetParentRow ( RelationNamesArrayList [ i ].ToString ( ) ).GetChildRows ( RelationNamesArrayList [ i ].ToString ( ) ) ) ;
                              }
                           }  
                        }
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
               finally
               {
                  grdDataView.ResumeLayout ( ) ;
               }
            }
            
            
            private DataRow GetFirstDirtyRow ( DataSet DirtyDataSet )
            {
               try
               {
                  foreach ( DataTable DirtyDataTable in DirtyDataSet.Tables )
                  {
                     foreach ( DataRow DirtyDataRow in DirtyDataTable.GetErrors ( ) )
                     {
                        return DirtyDataRow ;
                     }
                  }
                  
                  return null ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private int GetRowIndexFromArray
            ( 
               DataRow RequestedDataRow,
               DataRow [] arrGroupDataRow 
            )
            {
               try
               {
                  for ( int i = 0; i < arrGroupDataRow.Length; i++ )
                  {
                     if ( RequestedDataRow == arrGroupDataRow [ i ] ) 
                     {
                        return i ;
                     }
                  }
                  
                  return -1 ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private Stack GetDataRowParents ( DataRow ChildDataRow )
            {
               try
               {
                  Stack   ReturnParentStack ;
                  DataRow ParentDataRow ;
                  
                  
                  ReturnParentStack = new Stack ( ) ;
                  
                  if ( 0 != ChildDataRow.Table.ParentRelations.Count )
                  {
                     ParentDataRow = ChildDataRow.GetParentRow ( ChildDataRow.Table.ParentRelations [ 0 ] ) ;
                     
                     ReturnParentStack.Push ( ParentDataRow ) ;
                     
                     while ( ParentDataRow.Table.ParentRelations.Count > 0 )
                     {
                        ParentDataRow = ParentDataRow.GetParentRow ( ParentDataRow.Table.ParentRelations [ 0 ] ) ;
                        
                        ReturnParentStack.Push ( ParentDataRow ) ;
                     }
                  }
                  
                  return ReturnParentStack ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private string GetDataRowFullPath ( DataRow DirtyDataRow )
            {
               try
               {
                  string strDataRowPath = string.Empty ;
                  
                  
                  while ( DirtyDataRow.Table.ParentRelations.Count > 0 )
                  {
                     strDataRowPath = Constants.SpecialCharacters.DOT +
                                      DirtyDataRow.Table.ParentRelations [ 0 ].RelationName + 
                                      strDataRowPath ;
                                      
                     DirtyDataRow = DirtyDataRow.GetParentRow ( DirtyDataRow.Table.ParentRelations [ 0 ] ) ;
                  }
                  
                  strDataRowPath = DirtyDataRow.Table.TableName + strDataRowPath ;
                  
                  return strDataRowPath ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            //private void PrepareGridForDbInsert
            //( 
            //   DatasetType RequestedDataSetType 
            //)
            //{
            //   try
            //   {
            //      Cursor.Current = Cursors.WaitCursor ;
                  
            //      DataSet InsertDataSet ;
                  
                  
            //      InsertDataSet = GetDataSet ( RequestedDataSetType ) ;
                  
            //      __DSValidator.BeginValidation ( InsertDataSet ) ;
                  
            //      BindDatagrid ( InsertDataSet, 
            //                     RequestedDataSetType.ToString ( ) ) ;
                                               
            //      HandleDataViewGridCaptionText ( ) ;
                                                       
            //      RegisterDataSetEvents ( InsertDataSet ) ;
                  
            //      HandleCommetUndoButtonsEnableDisableState ( false ) ;
            //   }
            //   catch ( Exception exception )
            //   {
            //      System.Diagnostics.Debug.Assert ( false ) ;
                  
            //      throw exception ;
            //   }
            //   finally
            //   {
            //      Cursor.Current = Cursors.Default ;
            //   }
            //}
            
            
            //private DataSet GetDataSet
            //( 
            //   DatasetType RequestedDataSetType 
            //)
            //{
            //   try
            //   {
            //      switch ( RequestedDataSetType )
            //      {
            //         case DatasetType.Patient:
            //         {
            //            return new PatientTreeDataset ( ) ;
            //         }
                     
            //         case DatasetType.ImagingServiceRequest:
            //         {
            //            return new ImagingServiceRequestTreeDataset ( ) ;
            //         }
                     
            //         case DatasetType.RequestedProcedure:
            //         {
            //            return new RequestedProcedureTreeDataset ( ) ;
            //         }
                     
                     
            //         case DatasetType.ScheduledProcedureStep:
            //         {
            //            return new ScheduledProcedureStepNodeDataset ( ) ;
            //         }

                  
            //         case DatasetType.Visit:
            //         {
            //            return new VisitTreeDataset ( ) ;
            //         }

            //         case DatasetType.PPSInformation:
            //         {
            //            return new MPPSDataset ( ) ;
            //         }


            //         default:
            //         {
            //            throw new Exception ( "Not Supported dataSet type" ) ;
            //         }
            //      }      
            //   }
            //   catch ( Exception exception )
            //   {
            //      System.Diagnostics.Debug.Assert ( false ) ;
                  
            //      throw exception ;
            //   }
            //}
            
            
            
            private void HandleRowValidationError
            (
               string strReason, 
               DataRowChangeEventArgs e
            )
            {
               try
               {
                  //throw new ApplicationException ( strReason ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private bool ContinueWithInsertionAfterCommittingChanges ( )
            {
               try
               {
                  DialogResult UserCommitChangesDialogResult ;
                        
                        
                  UserCommitChangesDialogResult = GetCommitChangesUserAgreement ( ) ;
                        
                  switch (  UserCommitChangesDialogResult )
                  {
                     case DialogResult.Yes:
                     {
                        if ( ! CommitChangesToDatabase ( ) )
                        {
                           return false ;
                        }
                     }
                        
                        break ;
                           
                     case DialogResult.No:
                     {
                        return true ;         
                     }
                           
                     case DialogResult.Cancel:
                     {
                        return false ;
                     }
                           
                     default:
                     {
                        throw new Exception ( "Commit changes dialog result not supported." ) ;
                     }
                  }
                  
                  return true ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
         #endregion
         
         #region Properties
         
            private bool _DesignMode
            {
               get
               {
                  return (this.GetService(typeof(System.ComponentModel.Design.IDesignerHost)) != null) || 
                         (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime);
               }
            }
            
            private DataSet __DbTableNameToFriendlyNameDataSet
            {
               get
               {
                  return m_DbTableNameToFriendlyNameDataSet ;
               }
            
               set 
               {
                  m_DbTableNameToFriendlyNameDataSet = value ;
               }
            }
            
            private DataSet __QueryTypeDataSet
            {
               get
               {
                  return m_FilterTypeDataSet ;
               }
            
               set 
               {
                  m_FilterTypeDataSet = value ;
               }
            }
            
            private MatchingParametersDataSet __ColumnsMatchingParametersDataSet
            {
               get
               {
                  return m_ColumnsMatchingParametersDataSet ;
               }
            
               set 
               {
                  m_ColumnsMatchingParametersDataSet = value ;
               }
            }
            
            private WorklistCatalog __Catalog 
            {
               get
               {
                  return _catalog ;
               }
               
               set
               {
                  _catalog = value ;
               }
            }
            
            
            private DataSetValidatorManager __DSValidator
            {
               get
               {
                  return m_DSValidator ;
               }
            
               set 
               {
                  m_DSValidator = value ;
               }
            }
            
            
         #endregion
         
         #region Events
         
            private void cmbQueryType_SelectionChangeCommitted
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  EnableDisableQueryView ( ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void btnQuery_Click
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  PerformApplicationQuery ( ) ;   
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void btnUndoChanges_Click
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  RejectDataSetChanges ( ) ;      
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }


            private void btnDelete_Click ( object sender, EventArgs e )
            {
               try
               {
                  tmrControlDeleteButton.Enabled = false ;
                  
                  DeleteSelectedDataGridRows ( ) ;
                  
                  tmrControlDeleteButton.Enabled = true ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void btnCommitChanges_Click ( object sender, EventArgs e )
            {
               try
               {
                  CommitChangesToDatabase ( ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  MessageBox.Show ( Constants.Messages.MessageBox.DATABASEEDITOR_COMMITCHANGES_ERROR_MESSAGE,
                                    Constants.Messages.MessageBox.DATABASEEDITOR_ERROR_CAPTION,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
               }
            }
            
            
            private void DSValidator_ValidationErrorDetected
            (
               string  strReason,
               DataColumnChangeEventArgs e
            )
            {
               try
               {
                  HandleValidationError ( strReason, e ) ;   
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            
            private void QueryDataTable_ColumnChanged
            (
               object sender, 
               DataColumnChangeEventArgs e
            )
            {
               try
               {
                  HandleTableChange ( e.Row ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void QueryDataTable_RowChanged
            (
               object sender, 
               DataRowChangeEventArgs e
            )
            {
               try
               {
                  HandleTableChange ( e.Row ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void QueryDataTable_RowDeleted
            (
               object sender, 
               DataRowChangeEventArgs e
            )
            {
               try
               {
                  HandleTableChange ( e.Row ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void btnReset_Click ( object sender, EventArgs e )
            {
               try
               {
                  ResetQueryControls ( ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void grdQueryResultsView_Navigate
            (
               object sender, 
               NavigateEventArgs ne
            )
            {
               try
               {
                  HandleDataViewGridCaptionText ( ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void tmrControlDeleteButton_Tick 
            ( 
               object sender, 
               EventArgs e 
            )
            {
               try
               {
                  HandleDeleteButtonEnableState ( ) ;
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private static void SingleInstanceDatabaseEditorMainForm_Closed
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void DSValidator_RowValidationErrorDetectionEvent
            (
               string strReason, 
               DataRowChangeEventArgs e
            )
            {
               try
               {
                  HandleRowValidationError ( strReason , e ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
         #endregion

         #region Data Members


            
            private ScheduledProcedureStepQuery ctlScheduledProcedureStepQueryView ;
            private VisitQuery                  ctlVisitQueryView ;
            private RequestedProcedureQuery     ctlRequestedProcedureQueryView ;
            private PatientQuery                ctlPatientQueryView ;
            private ImagingServiceRequestQuery  ctlImagingServiceRequestQueryView ;
            private PeformedProcedureStepQuery  ctlPeformedProcedureStepQueryView ;
            private DataSet                     m_DbTableNameToFriendlyNameDataSet ;
            private DataSet                     m_FilterTypeDataSet ;
            private MatchingParametersDataSet   m_ColumnsMatchingParametersDataSet ;
            private WorklistCatalog             _catalog ;
            private DataSetValidatorManager     m_DSValidator ;
            private System.Windows.Forms.Splitter spltDataViewQueryView ;
            private System.Windows.Forms.TabPage tabpgPerformedProcedureStep ;
            //private Dictionary <string, ICatalogEntity> _dicomEntit
         #endregion

         #region Data Types Definition
         
            
            private class Constants
            {
               public class SpecialCharacter
               {
                  public const char FieldDelimiter = '.' ;
               }

               public class General
               {
                  public const int MutexWaitTimeSpan = 1 ;
                  
                  public const string DATAGRID_CAPTION_TEXT_MAIN = "Data View" ;
                  public const string InsertDataSetListButtonText = "I&nsert" ;
               }
               
               
               public class SpecialCharacters
               {
                  public const string DataAccessFieldSeparator = "\\" ;
                  public const string QUERY_FIELD_SEPARATOR    = "," ;
                  public const string DASH                     = "-" ;
                  public const string DOT                      = "." ;
                  public const string Space                    = " " ; 
               }
               
               
               public class BindingInfo
               {
                  public class ColumnNames
                  {
                     public const string TableKey                                           = "TableKey" ; 
                     public const string DBTABLENAMETOFRIENDLYNAMES_ENTRY_FRIENDLYNAME      = "FriendlyName" ;
                     public const string DBTABLENAMETOFRIENDLYNAMES_ENTRY_DBNAME            = "DbName" ;
                     public const string DBQUERYTYPES_DISPLAYVALUE                          = "DisplayValue" ;
                     public const string DBQUERYTYPES_KEY                                   = "Key" ;
                     public const string TABLE_COLUMN_NAME                                  = "TableColumnName" ;
                  }
                                    
                                    
                  public class PropertyName
                  {
                     public class EntityView
                     {
                        public const string ENTITY_NAME = "EntityName" ;      
                     }
                  
                     public class SystemGUI
                     {
                        public const string CHECKED = "Checked" ;
                        public const string ENABLED = "Enabled" ;
                     }
                  }
                  
                  public class GridTableStyles
                  {
                     public class TableName
                     {
                        public const string TableStyles  = "TableStyles" ;
                        public const string ColumnStyles = "ColumnStyles" ;
                     }
                     
                     public class ColumnName
                     {
                        public const string TableStyles_TableID       = "TableID" ;
                        public const string ColumnStyles_TableID      = "TableID" ;
                        public const string ColumnStyles_ColumnID     = "ColumnID" ;
                        public const string ColumnStyles_ColumnType   = "ColumnType" ;
                        public const string ColumnStyles_ColumnFormat = "ColumnFormat" ;
                     }
                     
                     public class RelationName
                     {
                        public const string TableRelatedColumns = "TableRelatedColumns" ;
                     }
                  }
                  
                  public class ColumnsMatchingParameters
                  {
                     public class TableName
                     {
                        public const string TablesNameTable  = "Table1" ;
                        public const string ColumnsNameTable = "Table2" ;
                     }
                     
                     public class ColumnName
                     {
                        public static string Table1_TableName         = "TableName" ;
                        public static string Table2_TableName         = "TableName" ;
                        public static string Table2_ColumnName        = "ColumnName" ;
                        public static string Table2_MatchingParameter = "MatchingParameter" ;
                     }
                     
                     public class RelationName
                     {
                        public static string Relation = "Relation1" ;
                     }
                  }
               }
               
               
               public class Messages
               {
                  public class MessageBox
                  {
                     public const string DATABASEEDITOR_ERROR_CAPTION                             = "Database Editor Error" ;
                     public const string DATABASEEDITOR_INFORMATION_CAPTION                       = "Database Editor" ;
                     public const string DATABASEEDITOR_ABOUT_ERROR_MESSAGE                       = "Problem occurred while trying to open About dialog." ;
                     public const string DATABASEEDITOR_QUERY_RELATEDSELECTED_NOTSELECTED_MESSAGE = "At least one row should be selected from the 'Data View' to perform the desired query." ;
                     public const string DATABASEEDITOR_QUERY_FAILED                              = "Failed while trying to perform query." ;
                     public const string DATABASEEDITOR_UPDATE_VALIDATION_ERROR_MESSAGE           = "Invalid value for column '{0}'.\n{1}\nOriginal value will be restored." ;
                     public const string DATABASEEDITOR_UNDO_WARNING_MESSAGE                      = "All changes will be rejected!\nAre you sure you want to undo all changes performed on all tables?" ;
                     public const string DATABASEEDITOR_WARNING_CAPTION                           = "Database Editor" ;
                     public const string DATABASEEDITOR_DELETE_WARNING_MESSAGE                    = "Selected rows and all related data in other tables will be deleted!\nAre you sure you want to delete selected rows?" ;
                     public const string DATABASEEDITOR_COMMITCHANGES_WARNING_MESSAGE             = "This operation will update broker database!\nAre you sure you want to continue?" ;
                     public const string DATABASEEDITOR_COMMITCHANGES_VALIDATION_ERROR_MESSAGE    = "Can’t commit changes to database!\nInvalid data.\n{0}" ;
                     public const string DATABASEEDITOR_COMMIT_ERROR_MESSAGE                      = "Failed while trying to update the database!\n{0}\nDo you want to try navigating to the error?" ;
                     public const string DATABASEEDITOR_COMMIT_SUCCESS_MESSAGE                    = "Database updated successfully." ;
                     public const string DATABASEEDITOR_UNDO_ERROR_MESSAGE                        = "Problem occurred while trying to undo changes." ;
                     public const string DATABASEEDITOR_DATABASEEDITOR_DELETE_ERROR_MESSAGE       = "Failed while trying to delete selected rows." ;
                     public const string DATABASEEDITOR_COMMITCHANGES_ERROR_MESSAGE               = "Problem has occurred while trying to commit changed in the database." ;
                     public const string DatabaseEditor_SaveChanges                               = "Do you want to commit changes to the database?" ; 
                     public const string DatabaseEditor_ClosingError_Message                      = "Problem occurred while trying to close the Database Editor." ; 
                     public const string DatabaseEditor_Insertion_Error                           = "Problem occurred while trying to prepare Data View for insertion." ; 
                     
                  }
                  
                  public class Exception
                  {
                     public const string VALIDATION_REASON_NOT_SUPPORTED = "Validation reason not supported." ;
                     public const string DataGridColumntypeNotSupported  = "Not supported datagrid column type." ;
                  }
               }
               
               
               public class Resources
               {
                  public const string SupportedTables                 = "Leadtools.Medical.Winforms.WorklistDatabaseEditor.XML.SupportedTables.SupportedTables.xml" ;
                  public const string FILTERTYPE                      = "Leadtools.Medical.Winforms.WorklistDatabaseEditor.XML.QueryTypes.QueryTypes.xml" ;
                  public const string AppIcon                         = "Leadtools.Medical.Winforms.WorklistDatabaseEditor.Res.Icon.MiPACSBrokerApp.ico" ;
                  public const string MatchingParametersXML           = "Leadtools.Medical.Winforms.WorklistDatabaseEditor.XML.ColumnsMatchingParameters.MatchingParameters.xml" ;
                  public const string ColumnsMatchingParametersSchema = "Leadtools.Medical.Winforms.WorklistDatabaseEditor.XML.ColumnsMatchingParameters.ColumnsMatchingParameters.xsd" ;
                  public const string DataGridTableStylesSchema       = "Leadtools.Medical.Winforms.WorklistDatabaseEditor.XML.DataGridTableStyles.DataGridTableStyles.xsd" ;
                  public const string DataGridTableStylesXML          = "Leadtools.Medical.Winforms.WorklistDatabaseEditor.XML.DataGridTableStyles.DataGridTableStyles.xml" ;                  
               }
            }
            
            
            private enum QueryType
            {
               All,
               Filtered,
               Selected_Related
            }
            
            private enum DataGridColumnType
            {
               Text,
               Bool
            }
            
            
            private enum DatasetType
            {
               Patient,
               ImagingServiceRequest,
               Visit,
               RequestedProcedure,
               ScheduledProcedureStep,
               PPSInformation
            }
            
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
   }
}
