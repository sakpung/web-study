// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Windows.Forms;
using Leadtools.Dicom;


namespace Leadtools.Medical.Winforms
{
   class DatasetView: System.Windows.Forms.Form
   {
      #region Public
         
         #region Methods
               
            public DatasetView ( )
            {
               try
               {
                  InitializeComponent ( ) ;
                        
                  RegisterEvents  ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
                  
                  
            public void BindData ( DicomDataSet DICOMDataset )
            {
               try
               {
                  DICOMServerEventLogFormsFormatter EventLogFormsFormatter ;
                        
                              
                  EventLogFormsFormatter = new DICOMServerEventLogFormsFormatter ( ) ;
                        
                  __DICOMDataset = DICOMDataset ;
                              
                  rchtxtDatasetView.Text = EventLogFormsFormatter.FormatDataSet ( DICOMDataset ) ;
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
            
            private void InitializeComponent ( )
            {
               this.rchtxtDatasetView = new System.Windows.Forms.RichTextBox();
               this.grpSeparator = new System.Windows.Forms.GroupBox();
               this.btnSave = new System.Windows.Forms.Button();
               this.btnClose = new System.Windows.Forms.Button();
               this.LogsSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
               this.SuspendLayout();
               // 
               // rchtxtDatasetView
               // 
               this.rchtxtDatasetView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                  | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
               this.rchtxtDatasetView.Cursor = System.Windows.Forms.Cursors.IBeam;
               this.rchtxtDatasetView.Location = new System.Drawing.Point(7, 8);
               this.rchtxtDatasetView.Name = "rchtxtDatasetView";
               this.rchtxtDatasetView.ReadOnly = true;
               this.rchtxtDatasetView.Size = new System.Drawing.Size(626, 393);
               this.rchtxtDatasetView.TabIndex = 1;
               this.rchtxtDatasetView.Text = "";
               // 
               // grpSeparator
               // 
               this.grpSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                  | System.Windows.Forms.AnchorStyles.Right)));
               this.grpSeparator.Location = new System.Drawing.Point(0, 408);
               this.grpSeparator.Name = "grpSeparator";
               this.grpSeparator.Size = new System.Drawing.Size(648, 3);
               this.grpSeparator.TabIndex = 2;
               this.grpSeparator.TabStop = false;
               // 
               // btnSave
               // 
               this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
               this.btnSave.Location = new System.Drawing.Point(7, 419);
               this.btnSave.Name = "btnSave";
               this.btnSave.Size = new System.Drawing.Size(81, 23);
               this.btnSave.TabIndex = 3;
               this.btnSave.Text = "&Save to file...";
               // 
               // btnClose
               // 
               this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
               this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
               this.btnClose.Location = new System.Drawing.Point(558, 419);
               this.btnClose.Name = "btnClose";
               this.btnClose.TabIndex = 4;
               this.btnClose.Text = "&Close";
               // 
               // LogsSaveFileDialog
               // 
               this.LogsSaveFileDialog.Filter = "Text files(*.txt)|*.txt| XML files(*.xml)|*.xml| DICOM files(*.dcm)|*.dcm";
               this.LogsSaveFileDialog.Title = "Save Dataset";
               // 
               // DatasetView
               // 
               this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
               this.CancelButton = this.btnClose;
               this.ClientSize = new System.Drawing.Size(640, 448);
               this.Controls.Add(this.btnClose);
               this.Controls.Add(this.btnSave);
               this.Controls.Add(this.grpSeparator);
               this.Controls.Add(this.rchtxtDatasetView);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
               this.MinimizeBox = false;
               this.Name = "DatasetView";
               this.ShowInTaskbar = false;
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "Dataset Details";
               this.ResumeLayout(false);

            }
                  
                  
            private void RegisterEvents ( ) 
            {
               try
               {
                  btnClose.Click += new EventHandler ( btnClose_Click ) ;
                  btnSave.Click  += new EventHandler ( btnSave_Click ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
                  
                  
            private void SaveDataset ( ) 
            {
               try
               {
                  if ( DialogResult.OK == LogsSaveFileDialog.ShowDialog ( ) )
                  {
                     switch ( LogsSaveFileDialog.FilterIndex )
                     {
                        case Constants.FilterIndexes.DCM:
                        {
                           __DICOMDataset.Save ( LogsSaveFileDialog.FileName, DicomDataSetSaveFlags.None ) ;
                        }
                        
                        break;
                        
                        default:
                        {
                           rchtxtDatasetView.SaveFile ( LogsSaveFileDialog.FileName, 
                                                        RichTextBoxStreamType.PlainText ) ;  
                        }
                        
                        break ;
                     }
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
                  
                  
         #endregion
            
         #region Properties
            
            private DicomDataSet __DICOMDataset
            {
               get
               {
                  return m_dicomDataSet ;
               }
                  
               set 
               {
                  m_dicomDataSet = value ;
               }
            }
                  
         #endregion
            
         #region Events
            
            private void btnClose_Click
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  this.Close ( ) ;
               }
               catch ( Exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
                  
                  
            private void btnSave_Click
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  SaveDataset ( ) ;
               }
               catch ( Exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  MessageBox.Show ( Constants.Messages.MessageBox.SavingFileError,
                                    Constants.Messages.MessageBox.DatasetDetailsError,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
               }
            }
                  
               
         #endregion
            
         #region Data Members

            private System.Windows.Forms.Button btnSave ;
            private System.Windows.Forms.Button btnClose ;
            private System.Windows.Forms.RichTextBox rchtxtDatasetView ;
            private System.Windows.Forms.GroupBox grpSeparator ;
            private System.Windows.Forms.SaveFileDialog LogsSaveFileDialog ;
                  
            private DicomDataSet m_dicomDataSet ;
                  
         #endregion
            
         #region Data Types Definition
            
            private class Constants
            {
               public class SpecialCharacter
               {
                  public const string CloseingArrow = ">" ;
               }
               
               public class FilterIndexes
               {
                  public const int All = 1 ;
                  public const int XML = 2 ;
                  public const int DCM = 3 ;
               }
               
               public class Messages
               {
                  public class MessageBox
                  {
                     public const string SavingFileError     = "Problem occurred while trying to save dataset file." ;
                     public const string DatasetDetailsError = "Dataset View Error" ;
                  }
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
