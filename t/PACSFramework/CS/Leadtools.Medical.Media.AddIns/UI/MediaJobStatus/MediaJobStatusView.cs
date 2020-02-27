// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Collections.Generic;
using System.Linq ;
using System.Windows.Forms;
using Leadtools.Dicom.Common.DataTypes.MediaCreation;
using Leadtools.Dicom.Scp.Media;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Medical.Media.AddIns ;
using System.Data;
using System;
using Leadtools.Demos;
using System.Drawing;
using Leadtools.Dicom;

namespace Leadtools.Medical.Media.AddIns.UI
{
   public partial class MediaJobStatusView : UserControl, IMediaJobStatusView
   {
      #region Public
         
         #region Methods
         
            public MediaJobStatusView ( )
            {
               InitializeComponent ( ) ;
               
               Init ( ) ;
            }

            public void LoadMedia ( MediaObjectsStateService mediaObjectsState ) 
            {
               __MediaObjectsState    = mediaObjectsState ;
               __RefreshTimer.Enabled = AutoRefreshCheckBox.Checked ;
               
               CreateMediaJobs ( mediaObjectsState.MediaQueue ) ;
               
               RegisterEvents ( ) ;
            }

            public void TearDown ( )
            {
               if ( null != __RefreshTimer ) 
               {
                  __RefreshTimer.Tick -= new EventHandler(__RefreshTimer_Tick);
                  
                  __RefreshTimer.Dispose ( ) ;
                  
                  __RefreshTimer = null ;
               }
            }
            
            public void NotifyMediaCreationSuccess ( MediaCreationManagement mediaObject ) 
            {
               MediaJob     mediaJob ;
               ListViewItem mediaItem ;
               
               
               mediaJob = FindMediaJob ( mediaObject ) ;
               
               if ( null == mediaJob ) 
               {
                  return ;
               }
               
               mediaJob.Comments = string.Empty ;
               
               mediaItem = FindMediaItem ( mediaJob ) ;
               
               if ( null != mediaItem ) 
               {
                  RefreshItem ( mediaItem, mediaJob ) ;
               }
            }
            
            public void NotifyMediaCreationError ( MediaCreationManagement mediaObject, Exception  error ) 
            {
               MediaJob     mediaJob ;
               ListViewItem mediaItem ;
               
               
               mediaJob = FindMediaJob ( mediaObject ) ;
               
               if ( null == mediaJob ) 
               {
                  return ;
               }
               
               mediaJob.Comments = error.Message ;
               
               mediaItem = FindMediaItem ( mediaJob ) ;
               
               if ( null != mediaItem ) 
               {
                  RefreshItem ( mediaItem, mediaJob ) ;
               }
            }
            
            public void OnMediaObjectRemoved ( MediaCreationManagement mediaObject )
            {
               try
               {
                  MediaJob mediaJob ;
                  ListViewItem item ;
                  
                  
                  mediaJob = FindMediaJob ( mediaObject ) ;
                  
                  if ( null != mediaJob ) 
                  {
                     __MediaJobs.Remove ( mediaJob ) ;
                  }
                  
                  item = FindMediaItem ( mediaJob ) ;
                  
                  if ( null != item ) 
                  {
                     DeleteListViewItem ( item ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            public void OnMediaObjectAdded ( MediaCreationManagement mediaObject )
            {
               try
               {
                  MediaJob job ;
                  
                  
                  job = new MediaJob ( mediaObject ) ;
                  
                  SetCreatingMediaComment ( mediaObject, job ) ;
                  
                  __MediaJobs.Add ( job ) ;
                  
                  if ( mediaObject.ExecutionStatus.ExecutionStatus == ( ExecutionStatus ) StatusComboBox.SelectedValue )
                  {
                     AddListViewItem ( job ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            public void OnMediaObjectStatusUpdated ( MediaCreationManagement mediaObject ) 
            {
               try
               {
                  MediaJob mediaJob ;
                  
                  
                  mediaJob = FindMediaJob ( mediaObject ) ;
                  
                  if ( null == mediaJob ) 
                  {
                     return ;
                  }

                  SetCreatingMediaComment ( mediaObject, mediaJob ) ;
                  
                  if ( (ExecutionStatus) StatusComboBox.SelectedValue != mediaJob.MediaObject.ExecutionStatus.ExecutionStatus )
                  {
                     StatusComboBox.SelectedValue = mediaJob.MediaObject.ExecutionStatus.ExecutionStatus ;
                     
                     StatusComboBox_SelectionChangeCommitted ( StatusComboBox, EventArgs.Empty ) ;
                  }
                  else
                  {
                     ListViewItem mediaItem ;
                     
                     
                     mediaItem = FindMediaItem ( mediaJob ) ;
                     
                     if ( null != mediaItem ) 
                     {
                        RefreshItem ( mediaItem, mediaJob ) ;
                     }
                     else
                     {
                        AddListViewItem ( mediaJob ) ;
                     }
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            public void OnMediaObjectsCleared ( )
            {
               try
               {
                  __MediaJobs.Clear             ( ) ;
                  MediaJobsListView.Items.Clear ( ) ;
                  
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            public void HideUserAlert ( ) 
            {
               UserAlertToolStripStatusLabel.Text = string.Empty ;
               UserAlertToolStripStatusLabel.ToolTipText = string.Empty ;
               UserAlertStatusStrip.Visible       = false ;
            }
            
            public void ShowUserAlert ( string alertMessage ) 
            {
               UserAlertToolStripStatusLabel.Text = alertMessage ;
               UserAlertToolStripStatusLabel.ToolTipText = alertMessage ;
               UserAlertStatusStrip.Visible       = true ;
            }
            
         #endregion
         
         #region Properties
         
            public bool CanCreateSelected
            {
               set 
               {
                  CreateMediaToolStripButton.Enabled = value ;
               }
            }
         
            public bool CanRecreateSelected
            {
               set
               {
                  RecreateMediaToolStripButton.Enabled = value ;
               }
            }
            
            public bool CanDeleteSelected
            {
               set
               {
                  DeleteToolStripButton.Enabled = value ;
               }
            }
            
            public bool CanBurn
            {
               set 
               {
                  BurnMediaToolStripButton.Enabled = value ;
               }
            }
            
            public DicomDataSet DetailesDataSet
            {
               get 
               {
                  return MediaCreationDetails.DataSet ;
               }
               
               set 
               {
                  MediaCreationDetails.DataSet = value ;
               }
            }
            
            public MediaCreationManagement SelectedMediaObject
            {
               get
               {
                  return propertyGrid1.SelectedObject as MediaCreationManagement ;
               }
               
               set
               {
                  propertyGrid1.SelectedObject = value ;
               }
            }
      
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public event EventHandler DeleteMedia ;
            public event EventHandler RefreshMediaQueue ;
            public event EventHandler CreateMedia ;
            public event EventHandler RecreateMedia ;
            public event EventHandler BurnActiveMedia ;
            
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
               __MediaJobs    = new List<MediaJob> ( ) ;
               __RefreshTimer = new Timer ( ) ;
               
               __RefreshTimer.Interval = 10000 ;
               
               DataTable executionStatusLookupTable ;
               
               
               executionStatusLookupTable = new DataTable ( ) ;
               
               executionStatusLookupTable.Columns.Add ( Constants.StatusLookupTableColumns.DisplayColumn, typeof (string) ) ;
               executionStatusLookupTable.Columns.Add ( Constants.StatusLookupTableColumns.ValueColumn, typeof (ExecutionStatus) ) ;
               
               executionStatusLookupTable.Rows.Add ( ExecutionStatus.Pending.ToString  ( ), ExecutionStatus.Pending ) ;
               executionStatusLookupTable.Rows.Add ( ExecutionStatus.Creating.ToString ( ), ExecutionStatus.Creating ) ;
               executionStatusLookupTable.Rows.Add ( ExecutionStatus.Done.ToString     ( ), ExecutionStatus.Done ) ;
               executionStatusLookupTable.Rows.Add ( ExecutionStatus.Failure.ToString  ( ), ExecutionStatus.Failure ) ;
               executionStatusLookupTable.Rows.Add ( ExecutionStatus.Idle.ToString     ( ), ExecutionStatus.Idle ) ;
               
               MediaJobsListView.Columns.Add ( Constants.ListViewColumns.DescriptionKey, Constants.ListViewColumns.DescriptionText, 100 ) ;
               MediaJobsListView.Columns.Add ( Constants.ListViewColumns.PriorityKey, Constants.ListViewColumns.PriorityText, 50 ) ;
               MediaJobsListView.Columns.Add ( Constants.ListViewColumns.NumberOfCopiesKey, Constants.ListViewColumns.NumberOfCopiesText, 50 ) ;
               MediaJobsListView.Columns.Add ( Constants.ListViewColumns.CreationDateKey, Constants.ListViewColumns.CreationDateText, 150 ) ;
               MediaJobsListView.Columns.Add ( Constants.ListViewColumns.CreationErrorKey, Constants.ListViewColumns.CreationErrorText, 200 ) ;
               
               StatusComboBox.DataSource = executionStatusLookupTable ;
               StatusComboBox.DisplayMember = Constants.StatusLookupTableColumns.DisplayColumn ;
               StatusComboBox.ValueMember   = Constants.StatusLookupTableColumns.ValueColumn ;
               
               StatusComboBox.SelectedValue = ExecutionStatus.Pending ;
               
               MediaCreationDetails.ReadOnly = true ;
               
               HideUserAlert ( ) ;
               
               RefreshToolStripButton.Image       = Leadtools.Medical.Media.AddIns.Properties.Resources.RefreshList.ToBitmap ( ) ;
               DeleteToolStripButton.Image        = Leadtools.Medical.Media.AddIns.Properties.Resources.DeleteJobs.ToBitmap();
               CreateMediaToolStripButton.Image   = Leadtools.Medical.Media.AddIns.Properties.Resources.CreateJobs.ToBitmap();
               RecreateMediaToolStripButton.Image = Leadtools.Medical.Media.AddIns.Properties.Resources.RecreateJobs.ToBitmap();
               BurnMediaToolStripButton.Image     = Leadtools.Medical.Media.AddIns.Properties.Resources.BurnMedia.ToBitmap();
            }
            
            private void RegisterEvents ( )
            {
               StatusComboBox.SelectionChangeCommitted += new EventHandler            ( StatusComboBox_SelectionChangeCommitted ) ;
               MediaJobsListView.ItemChecked           += new ItemCheckedEventHandler ( MediaJobsListView_ItemChecked ) ;
               MediaJobsListView.SelectedIndexChanged  += new EventHandler            ( MediaJobsListView_SelectedIndexChanged ) ;
               SelectJobsCheckBox.CheckedChanged       += new EventHandler            ( SelectJobsCheckBox_CheckedChanged ) ;
               
               RefreshToolStripButton.Click       += new EventHandler            ( RefreshButton_Click ) ;
               DeleteToolStripButton.Click        += new EventHandler            ( DeleteButton_Click ) ;
               CreateMediaToolStripButton.Click   += new EventHandler            ( CreateMediaButton_Click ) ;
               RecreateMediaToolStripButton.Click += new EventHandler            ( RecreateMediaButton_Click ) ;
               BurnMediaToolStripButton.Click     += new EventHandler            ( BurnMediaButton_Click ) ;
               
               
               AutoRefreshCheckBox.CheckedChanged      += new EventHandler            ( AutoRefreshCheckBox_CheckedChanged ) ;
               
               __RefreshTimer.Tick += new EventHandler ( __RefreshTimer_Tick ) ;
            }

            private void CreateMediaJobs ( MediaCreationQueue mediaQueue )
            {
               foreach ( MediaCreationManagement mediaCreation in mediaQueue )
               {
                  MediaJob job ;
                  
                  
                  job = new MediaJob ( mediaCreation ) ;
                  
                  job.Checked = __MediaObjectsState.SelectedMediaItems.Contains ( mediaCreation ) ;
                  
                  if ( mediaCreation.ExecutionStatus.ExecutionStatus == ExecutionStatus.Creating &&
                       string.IsNullOrEmpty ( mediaCreation.GetCreationPath ( ) ) )
                  {
                     job.Comments = "Media creation was interrupted." ;
                  }
                  
                  __MediaJobs.Add ( job ) ;
                  
                  if ( mediaCreation.ExecutionStatus.ExecutionStatus == ( ExecutionStatus ) StatusComboBox.SelectedValue )
                  {
                     AddListViewItem ( job ) ;
                  }
               }
               
               SetActiveMediaItem ( ) ;
            }

            private void AddListViewItem ( MediaJob job )
            {
               ListViewItem item ;
               
               
               item = new ListViewItem ( job.MediaFileId ) ;
               
               item.SubItems.Add ( job.Priority.ToString ( ) ) ;
               item.SubItems.Add ( job.NumberOfCopies.ToString ( ) ) ;
               item.SubItems.Add ( job.CreationTime.ToLongDateString ( ) + " " + job.CreationTime.ToLongTimeString ( ) ) ;
               item.SubItems.Add ( job.Comments ).ForeColor = Color.Red ;
               item.SubItems.Add ( job.MediaLocation ) ;
               
               item.Tag                     = job ;
               item.Checked                 = job.Checked ;
               item.UseItemStyleForSubItems = false ;
               
               MediaJobsListView.Items.Add ( item ) ;

               UpdateSelectedMediaItems ( job ) ;
            }
            
            private void RefreshItem ( ListViewItem item, MediaJob job ) 
            {
               MediaJobsListView.SuspendLayout ( ) ;
               
               try
               {
                  item.Text = job.MediaFileId ;
                  
                  item.SubItems [ Constants.ListViewColumns.PriorityIndex ].Text       = job.Priority.ToString ( ) ;
                  item.SubItems [ Constants.ListViewColumns.NumberOfCopiesIndex ].Text = job.NumberOfCopies.ToString ( ) ;
                  item.SubItems [ Constants.ListViewColumns.CreationDateIndex ].Text   = job.CreationTime.ToLongDateString ( ) + " " + job.CreationTime.ToLongTimeString ( ) ;
                  item.SubItems [ Constants.ListViewColumns.CreationErrorIndex ].Text  = job.Comments ;
                  item.SubItems [ Constants.ListViewColumns.MediaLocationIndex ].Text  = job.MediaLocation ;
               }
               finally
               {
                  MediaJobsListView.ResumeLayout ( true ) ;
               }
            }
            
            private void DeleteListViewItem ( ListViewItem item )
            {
               MediaJobsListView.Items.Remove ( item );

               UpdateUIButtons ( ) ;

               UpdateSelectJobsCheckBoxState ( ) ;
            }

            private void UpdateSelectedMediaItems ( MediaJob job )
            {
               if ( job.Checked && !__MediaObjectsState.SelectedMediaItems.Contains ( job.MediaObject ) ) 
               {
                  __MediaObjectsState.SelectedMediaItems.Add ( job.MediaObject ) ;
               }
               else if ( !job.Checked && __MediaObjectsState.SelectedMediaItems.Contains ( job.MediaObject ) )
               {
                  __MediaObjectsState.SelectedMediaItems.Remove( job.MediaObject ) ;
               }

               UpdateUIButtons ( ) ;
            }
            
            private void UpdateUIButtons ( )
            {
               //DeleteButton.Enabled = __MediaObjectsState.SelectedMediaItems.Count > 0 && !IsCreating ( __MediaObjectsState.SelectedMediaItems ) ;
               
               //CreateMediaButton.Enabled = ( __MediaObjectsState.SelectedMediaItems.Count > 0 &&
               //                                      ( ExecutionStatus ) StatusComboBox.SelectedValue == ExecutionStatus.Pending ) ;
            }

            //private bool IsCreating ( MediaCreationQueue mediaCreationQueue )
            //{
            //   foreach ( MediaCreationManagement mediaObject in mediaCreationQueue )
            //   {
            //      MediaJob mediaJob ;
                  
            //      mediaJob = FindMediaJob ( mediaObject ) ;
                  
            //      if ( null != mediaJob && mediaJob.Creating )
            //      {
            //         return true ;
            //      }
            //   }
               
            //   return false ;
            //}

            private void FillList ( List<MediaJob> jobs )
            {
               MediaJobsListView.SuspendLayout ( ) ;
               
               try
               {
                  ExecutionStatus selectedStatus ;
                  
                  
                  MediaJobsListView.Items.Clear ( ) ;
                  
                  __MediaObjectsState.SelectedMediaItems.Clear ( ) ;
                  __MediaObjectsState.ActiveMediaItem = null ;
                  
                  selectedStatus = ( ExecutionStatus) StatusComboBox.SelectedValue ;
                  
                  if ( selectedStatus ==  ExecutionStatus.Creating ||
                       selectedStatus ==  ExecutionStatus.Done || 
                       selectedStatus == ExecutionStatus.Failure )
                  {
                     if ( !MediaJobsListView.Columns.ContainsKey ( Constants.ListViewColumns.MediaLocationKey ) )
                     {
                        MediaJobsListView.Columns.Add ( Constants.ListViewColumns.MediaLocationKey, Constants.ListViewColumns.MediaLocationText, _locationColumnWidth ) ;
                     }
                  }
                  else if ( MediaJobsListView.Columns.ContainsKey ( Constants.ListViewColumns.MediaLocationKey ) )
                  {
                     _locationColumnWidth = MediaJobsListView.Columns [ Constants.ListViewColumns.MediaLocationIndex ].Width ;
                     
                     MediaJobsListView.Columns.RemoveByKey ( Constants.ListViewColumns.MediaLocationKey ) ;
                  }
                  
                  foreach ( MediaJob job in jobs ) 
                  {
                     AddListViewItem ( job ) ;
                  }

                  SetActiveMediaItem ( ) ;
               }
               finally
               {
                  MediaJobsListView.ResumeLayout ( ) ;
               }
               
            }

            private void SetActiveMediaItem ( )
            {
               if ( MediaJobsListView.SelectedItems.Count > 0 ) 
               {
                  __MediaObjectsState.ActiveMediaItem = ( ( MediaJob ) MediaJobsListView.SelectedItems [ 0 ].Tag ).MediaObject ;
               }
               else
               {
                  __MediaObjectsState.ActiveMediaItem = null ;
               }
               
               UpdateUIButtons ( ) ;
            }
            
            private CheckState GetListCheckState ( ) 
            {
               CheckState? state ;
               
               
               state = null ;
               
               foreach ( ListViewItem item in MediaJobsListView.Items ) 
               {
                  if ( state == null )
                  {
                     state = ( item.Checked ) ? CheckState.Checked : CheckState.Unchecked ;
                  }
                  else if ( item.Checked && state.Value == CheckState.Unchecked || 
                            !item.Checked && state.Value == CheckState.Checked )
                  {
                     return CheckState.Indeterminate ;
                  }
               }
               
               if ( state == null ) 
               {
                  return CheckState.Unchecked ;
               }
               else
               {
                  return state.Value ;
               }
            }
            
            private void SetItemsCheckState ( bool checkState )
            {
               MediaJobsListView.ItemChecked -= new ItemCheckedEventHandler ( MediaJobsListView_ItemChecked ) ;
               
               try
               {
                  foreach ( ListViewItem item in MediaJobsListView.Items ) 
                  {
                     MediaJob job ;
                     
                     
                     item.Checked = checkState ;
                     
                     job = ( item.Tag as MediaJob ) ;
                     
                     job.Checked = checkState ;
                     
                     UpdateSelectedMediaItems ( job ) ;
                  }
               }
               finally
               {
                  MediaJobsListView.ItemChecked += new ItemCheckedEventHandler ( MediaJobsListView_ItemChecked ) ;
               }
            }
            
            private void UpdateSelectJobsCheckBoxState ( )
            {
               SelectJobsCheckBox.CheckedChanged -= new EventHandler ( SelectJobsCheckBox_CheckedChanged ) ;
               
               try
               {
                  SelectJobsCheckBox.CheckState = GetListCheckState ( ) ;
               }
               finally
               {
                  SelectJobsCheckBox.CheckedChanged += new EventHandler ( SelectJobsCheckBox_CheckedChanged ) ;
               }
            }
          
            private void OnDeleteMedia ( )
            {
               if ( null != DeleteMedia ) 
               {
                  DeleteMedia ( this, EventArgs.Empty ) ;
               }
            }
            
            private void OnCreateMedia ( )
            {
               if ( null != CreateMedia )
               {
                  CreateMedia ( this, EventArgs.Empty ) ;
               }
            }
            
            private void OnReCreateMedia()
            {
               if ( RecreateMedia != null ) 
               {
                  RecreateMedia ( this, EventArgs.Empty ) ;
               }
            }
            
            private void OnBurnActiveMedia ( ) 
            {
               if ( null != BurnActiveMedia ) 
               {
                  BurnActiveMedia ( this, EventArgs.Empty ) ;
               }
            }
            
            private void OnRefreshMedia ( )
            {
               if ( null != RefreshMediaQueue ) 
               {
                  RefreshMediaQueue ( this, EventArgs.Empty ) ;
               }
            }
            
            private MediaJob FindMediaJob ( MediaCreationManagement mediaObject ) 
            {
               return __MediaJobs.Where ( n=>n.MediaObject == mediaObject ).FirstOrDefault ( ) ;
            }
            
            private ListViewItem FindMediaItem ( MediaJob mediaJob ) 
            {
               return MediaJobsListView.Items.OfType <ListViewItem> ( ).Where ( n=> ( n.Tag == mediaJob ) ).FirstOrDefault ( ) ;
            }
            
            private static void SetCreatingMediaComment
            (
               MediaCreationManagement mediaObject, 
               MediaJob mediaJob
            )
            {
               if ( mediaObject.ExecutionStatus.ExecutionStatus == ExecutionStatus.Creating && 
                    string.IsNullOrEmpty ( mediaObject.GetCreationPath ( ) ) )
               {
                  mediaJob.Comments = "Creating media..." ;
               }
               else
               {
                  mediaJob.Comments = string.Empty ;
               }
            }
            
         #endregion
         
         #region Properties
         
            private Timer __RefreshTimer
            {
               get
               {
                  return _refreshTimer ;
               }
               
               set
               {
                  _refreshTimer = value ;
               }
            }
            
            private MediaObjectsStateService __MediaObjectsState
            {
               get ;
               set ;
            }
         
            private List <MediaJob> __MediaJobs
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
            void StatusComboBox_SelectionChangeCommitted ( object sender, EventArgs e )
            {
               try
               {
                  List <MediaJob> jobs ;
                  
                  
                  jobs = __MediaJobs.FindAll ( n=> n.Status == ( ExecutionStatus ) StatusComboBox.SelectedValue ) ;
                  
                  FillList ( jobs ) ;
                  
                  UpdateSelectJobsCheckBoxState ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void MediaJobsListView_ItemChecked ( object sender, ItemCheckedEventArgs e )
            {
               try
               {
                  MediaJob job ;
                  
                  
                  job = ( e.Item.Tag as MediaJob ) ;
                  
                  job.Checked = e.Item.Checked ;
                  
                  UpdateSelectedMediaItems ( job ) ;
                  
                  UpdateSelectJobsCheckBoxState ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void MediaJobsListView_SelectedIndexChanged ( object sender, EventArgs e )
            {
               try
               {
                  SetActiveMediaItem ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void SelectJobsCheckBox_CheckedChanged ( object sender, EventArgs e )
            {
               try
               {
                  SetItemsCheckState ( SelectJobsCheckBox.Checked ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void RefreshButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  OnRefreshMedia ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

            void DeleteButton_Click(object sender, EventArgs e)
            {
               try
               {
                  OnDeleteMedia ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void CreateMediaButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  OnCreateMedia ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void RecreateMediaButton_Click(object sender, EventArgs e)
            {
               try
               {
                  OnReCreateMedia ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            
            void BurnMediaButton_Click(object sender, EventArgs e)
            {
               try
               {
                  OnBurnActiveMedia ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void AutoRefreshCheckBox_CheckedChanged(object sender, EventArgs e)
            {
               try
               {
                  __RefreshTimer.Enabled = AutoRefreshCheckBox.Checked ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void __RefreshTimer_Tick(object sender, EventArgs e)
            {
               try
               {
                  __RefreshTimer.Enabled = false ;
                  
                  OnRefreshMedia ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
               finally
               {
                  __RefreshTimer.Enabled = AutoRefreshCheckBox.Checked ;
               }
            }

         #endregion
         
         #region Data Members
         
            private int _locationColumnWidth = 200 ;
            Timer _refreshTimer ;
            
         #endregion
         
         #region Data Types Definition
         
            private abstract class Constants
            {
               public abstract class StatusLookupTableColumns
               {
                  public const string DisplayColumn = "Display" ;
                  public const string ValueColumn   = "Value" ;
               }
               
               public abstract class ListViewColumns
               {
                  public const string  DescriptionText    = "Description" ;
                  public const string  PriorityText       = "Priority" ;
                  public const string  NumberOfCopiesText = "Number Of Copies" ;
                  public const string  CreationDateText   = "Creation Date" ;
                  public const string  MediaLocationText  = "Location" ;
                  public const string  CreationErrorText = "Comments" ;
                  
                  public const string  DescriptionKey    = "Description" ;
                  public const string  PriorityKey       = "Priority" ;
                  public const string  NumberOfCopiesKey = "NumberOfCopies" ;
                  public const string  CreationDateKey   = "CreationDate" ;
                  public const string  MediaLocationKey  = "Location" ;
                  public const string  CreationErrorKey  = "Comments" ;
                  
                  public const int DescriptionIndex    = 0 ;
                  public const int PriorityIndex       = 1 ;
                  public const int NumberOfCopiesIndex = 2 ;
                  public const int CreationDateIndex   = 3 ;
                  public const int CreationErrorIndex  = 4 ;
                  public const int MediaLocationIndex  = 5 ;
               } 
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
