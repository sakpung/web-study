// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Drawing ;
using System.Collections ;
using System.ComponentModel ;
using System.Windows.Forms ;
using System.Data ;
using Leadtools.Dicom ;
using Leadtools.Medical.DataAccessLayer ;
using Leadtools.Medical.Logging.DataAccessLayer ;
using Leadtools.Medical.Logging.DataAccessLayer.Configuration ;
using Leadtools.Medical.Logging.DataAccessLayer.MatchingParameters ;
using Leadtools.Demos;
using Leadtools.DicomDemos;


namespace Leadtools.Medical.Winforms
{
   class DICOMServerEventLogDetails : System.Windows.Forms.Form
   {
      #region Public
         
         #region Methods
         
            public DICOMServerEventLogDetails ( ) 
            {
               try
               {
                  InitializeComponent ( ) ;
                  
                  RegisterEvents ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            public void BindData 
            ( 
               DicomEventLogDataSet.DICOMServerEventLogRow sourceRow
            )
            {
               try
               {  
                  DICOMServerEventLogFormsFormatter EventLogFormsFormatter ;
                  
                  
                  EventLogFormsFormatter = new DICOMServerEventLogFormsFormatter ( ) ;
                  
                  if ( null == sourceRow ) 
                  {
                     return ;
                  }
                  
                  SourceRow = sourceRow ;
                  
                  txtServerAETitle.Text     = ( sourceRow.IsServerAETitleNull ( ) )     ? string.Empty : EventLogFormsFormatter.FormatServerAETitle ( sourceRow.ServerAETitle ) ;
                  txtServerIPAddress.Text   = ( sourceRow.IsServerIPAddressNull ( ) )   ? string.Empty : EventLogFormsFormatter.FormatServerIPAddress ( sourceRow.ServerIPAddress ) ;
                  txtServerPort.Text        = ( sourceRow.IsServerPortNull ( ) )        ? string.Empty : EventLogFormsFormatter.FormatServerPort ( sourceRow.ServerPort ) ;
                  rchtxtDescription.Text    = ( sourceRow.IsDescriptionNull ( ) )        ? string.Empty : EventLogFormsFormatter.FormatDescription ( sourceRow.Description ) ;
                  txtDateTime.Text          = ( sourceRow.IsEventDateTimeNull ( ) )      ? string.Empty : EventLogFormsFormatter.FormatEventDateTime ( sourceRow.EventDateTime ) ;
                  txtClientAETitle.Text     = ( sourceRow.IsClientAETitleNull ( ) )     ? string.Empty : EventLogFormsFormatter.FormatClientAETitle ( sourceRow.ClientAETitle ) ;
                  txtClientHostAddress.Text = ( sourceRow.IsClientHostAddressNull ( ) ) ? string.Empty : EventLogFormsFormatter.FormatClientHostAddress ( sourceRow.ClientHostAddress ) ;
                  txtClientPort.Text        = ( sourceRow.IsClientPortNull ( ) )        ? string.Empty : EventLogFormsFormatter.FormatClientPort ( sourceRow.ClientPort ) ;
                  txtType.Text              = EventLogFormsFormatter.FormatEventType ( sourceRow.Type ) ;
                  

                  btnViewDataSet.Enabled = !sourceRow.IsDatasetPathNull ( ) || ( null != GetEventDataset ( ( int ) SourceRow.EventID ) ) ; 
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }


         #endregion
         
         #region Properties
         
            public DicomEventLogDataSet.DICOMServerEventLogRow SourceRow
            {
               get ;
               private set ;
            }
            
            public bool CanDisplayNext
            {
               get
               {
                  return NextButton.Enabled ;
               }
               
               set
               {
                  NextButton.Enabled = value ;
               }
            }
            
            public bool CanDisplayPrevious
            {
               get
               {
                  return PreviousButton.Enabled ;
               }
               
               set
               {
                  PreviousButton.Enabled = value ;
               }
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public event EventHandler DisplayPrevious ;
            public event EventHandler DisplayNext ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
         
            protected override void Dispose ( bool disposing )
            {
               if ( disposing )
               {
                  if ( components != null ) 
                  {
                     components.Dispose ( ) ;
                  }
               }
               base.Dispose ( disposing ) ;
            }

            
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
               this.lblServerAETitle = new System.Windows.Forms.Label();
               this.txtServerAETitle = new System.Windows.Forms.TextBox();
               this.txtServerIPAddress = new System.Windows.Forms.TextBox();
               this.lblServerIPAddress = new System.Windows.Forms.Label();
               this.lblServerPort = new System.Windows.Forms.Label();
               this.txtServerPort = new System.Windows.Forms.TextBox();
               this.lblDateTime = new System.Windows.Forms.Label();
               this.txtDateTime = new System.Windows.Forms.TextBox();
               this.lblType = new System.Windows.Forms.Label();
               this.txtType = new System.Windows.Forms.TextBox();
               this.lblDescription = new System.Windows.Forms.Label();
               this.btnClose = new System.Windows.Forms.Button();
               this.btnViewDataSet = new System.Windows.Forms.Button();
               this.grpSeparator = new System.Windows.Forms.GroupBox();
               this.rchtxtDescription = new System.Windows.Forms.RichTextBox();
               this.txtClientPort = new System.Windows.Forms.TextBox();
               this.lblClientPort = new System.Windows.Forms.Label();
               this.lblClientHostAddress = new System.Windows.Forms.Label();
               this.txtClientHostAddress = new System.Windows.Forms.TextBox();
               this.txtClientAETitle = new System.Windows.Forms.TextBox();
               this.lblClientAE = new System.Windows.Forms.Label();
               this.NextButton = new System.Windows.Forms.Button();
               this.PreviousButton = new System.Windows.Forms.Button();
               this.SuspendLayout();
               // 
               // lblServerAETitle
               // 
               this.lblServerAETitle.Location = new System.Drawing.Point(7, 7);
               this.lblServerAETitle.Name = "lblServerAETitle";
               this.lblServerAETitle.Size = new System.Drawing.Size(83, 20);
               this.lblServerAETitle.TabIndex = 0;
               this.lblServerAETitle.Text = "Server &AE Title:";
               this.lblServerAETitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // txtServerAETitle
               // 
               this.txtServerAETitle.Location = new System.Drawing.Point(104, 7);
               this.txtServerAETitle.Name = "txtServerAETitle";
               this.txtServerAETitle.ReadOnly = true;
               this.txtServerAETitle.Size = new System.Drawing.Size(129, 20);
               this.txtServerAETitle.TabIndex = 1;
               // 
               // txtServerIPAddress
               // 
               this.txtServerIPAddress.Location = new System.Drawing.Point(104, 35);
               this.txtServerIPAddress.Name = "txtServerIPAddress";
               this.txtServerIPAddress.ReadOnly = true;
               this.txtServerIPAddress.Size = new System.Drawing.Size(129, 20);
               this.txtServerIPAddress.TabIndex = 3;
               // 
               // lblServerIPAddress
               // 
               this.lblServerIPAddress.Location = new System.Drawing.Point(7, 35);
               this.lblServerIPAddress.Name = "lblServerIPAddress";
               this.lblServerIPAddress.Size = new System.Drawing.Size(99, 20);
               this.lblServerIPAddress.TabIndex = 2;
               this.lblServerIPAddress.Text = "Server &IP Address:";
               this.lblServerIPAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // lblServerPort
               // 
               this.lblServerPort.Location = new System.Drawing.Point(7, 63);
               this.lblServerPort.Name = "lblServerPort";
               this.lblServerPort.Size = new System.Drawing.Size(64, 20);
               this.lblServerPort.TabIndex = 4;
               this.lblServerPort.Text = "Server &Port:";
               this.lblServerPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // txtServerPort
               // 
               this.txtServerPort.Location = new System.Drawing.Point(104, 63);
               this.txtServerPort.Name = "txtServerPort";
               this.txtServerPort.ReadOnly = true;
               this.txtServerPort.Size = new System.Drawing.Size(129, 20);
               this.txtServerPort.TabIndex = 5;
               // 
               // lblDateTime
               // 
               this.lblDateTime.Location = new System.Drawing.Point(256, 96);
               this.lblDateTime.Name = "lblDateTime";
               this.lblDateTime.Size = new System.Drawing.Size(96, 20);
               this.lblDateTime.TabIndex = 14;
               this.lblDateTime.Text = "Event &Date/Time:";
               this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // txtDateTime
               // 
               this.txtDateTime.Location = new System.Drawing.Point(368, 96);
               this.txtDateTime.Name = "txtDateTime";
               this.txtDateTime.ReadOnly = true;
               this.txtDateTime.Size = new System.Drawing.Size(130, 20);
               this.txtDateTime.TabIndex = 15;
               // 
               // lblType
               // 
               this.lblType.Location = new System.Drawing.Point(7, 96);
               this.lblType.Name = "lblType";
               this.lblType.Size = new System.Drawing.Size(46, 20);
               this.lblType.TabIndex = 6;
               this.lblType.Text = "&Type:";
               this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // txtType
               // 
               this.txtType.Location = new System.Drawing.Point(104, 96);
               this.txtType.Name = "txtType";
               this.txtType.ReadOnly = true;
               this.txtType.Size = new System.Drawing.Size(130, 20);
               this.txtType.TabIndex = 7;
               // 
               // lblDescription
               // 
               this.lblDescription.Location = new System.Drawing.Point(8, 127);
               this.lblDescription.Name = "lblDescription";
               this.lblDescription.Size = new System.Drawing.Size(64, 20);
               this.lblDescription.TabIndex = 16;
               this.lblDescription.Text = "&Description:";
               this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // btnClose
               // 
               this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
               this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
               this.btnClose.Location = new System.Drawing.Point(421, 575);
               this.btnClose.Name = "btnClose";
               this.btnClose.Size = new System.Drawing.Size(92, 24);
               this.btnClose.TabIndex = 22;
               this.btnClose.Text = "&Close";
               // 
               // btnViewDataSet
               // 
               this.btnViewDataSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
               this.btnViewDataSet.Location = new System.Drawing.Point(7, 532);
               this.btnViewDataSet.Name = "btnViewDataSet";
               this.btnViewDataSet.Size = new System.Drawing.Size(96, 24);
               this.btnViewDataSet.TabIndex = 18;
               this.btnViewDataSet.Text = "&View Dataset...";
               // 
               // grpSeparator
               // 
               this.grpSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                           | System.Windows.Forms.AnchorStyles.Right)));
               this.grpSeparator.Location = new System.Drawing.Point(-8, 562);
               this.grpSeparator.Name = "grpSeparator";
               this.grpSeparator.Size = new System.Drawing.Size(562, 3);
               this.grpSeparator.TabIndex = 21;
               this.grpSeparator.TabStop = false;
               // 
               // rchtxtDescription
               // 
               this.rchtxtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                           | System.Windows.Forms.AnchorStyles.Left)
                           | System.Windows.Forms.AnchorStyles.Right)));
               this.rchtxtDescription.AutoSize = true;
               this.rchtxtDescription.Location = new System.Drawing.Point(7, 159);
               this.rchtxtDescription.Name = "rchtxtDescription";
               this.rchtxtDescription.ReadOnly = true;
               this.rchtxtDescription.Size = new System.Drawing.Size(506, 364);
               this.rchtxtDescription.TabIndex = 17;
               this.rchtxtDescription.Text = "";
               this.rchtxtDescription.WordWrap = false;
               // 
               // txtClientPort
               // 
               this.txtClientPort.Location = new System.Drawing.Point(368, 63);
               this.txtClientPort.Name = "txtClientPort";
               this.txtClientPort.ReadOnly = true;
               this.txtClientPort.Size = new System.Drawing.Size(129, 20);
               this.txtClientPort.TabIndex = 13;
               // 
               // lblClientPort
               // 
               this.lblClientPort.Location = new System.Drawing.Point(256, 63);
               this.lblClientPort.Name = "lblClientPort";
               this.lblClientPort.Size = new System.Drawing.Size(70, 20);
               this.lblClientPort.TabIndex = 12;
               this.lblClientPort.Text = "Client P&ort:";
               this.lblClientPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // lblClientHostAddress
               // 
               this.lblClientHostAddress.Location = new System.Drawing.Point(256, 35);
               this.lblClientHostAddress.Name = "lblClientHostAddress";
               this.lblClientHostAddress.Size = new System.Drawing.Size(107, 20);
               this.lblClientHostAddress.TabIndex = 10;
               this.lblClientHostAddress.Text = "Client &Host Address:";
               this.lblClientHostAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // txtClientHostAddress
               // 
               this.txtClientHostAddress.Location = new System.Drawing.Point(368, 35);
               this.txtClientHostAddress.Name = "txtClientHostAddress";
               this.txtClientHostAddress.ReadOnly = true;
               this.txtClientHostAddress.Size = new System.Drawing.Size(129, 20);
               this.txtClientHostAddress.TabIndex = 11;
               // 
               // txtClientAETitle
               // 
               this.txtClientAETitle.Location = new System.Drawing.Point(368, 7);
               this.txtClientAETitle.Name = "txtClientAETitle";
               this.txtClientAETitle.ReadOnly = true;
               this.txtClientAETitle.Size = new System.Drawing.Size(129, 20);
               this.txtClientAETitle.TabIndex = 9;
               // 
               // lblClientAE
               // 
               this.lblClientAE.Location = new System.Drawing.Point(256, 7);
               this.lblClientAE.Name = "lblClientAE";
               this.lblClientAE.Size = new System.Drawing.Size(79, 20);
               this.lblClientAE.TabIndex = 8;
               this.lblClientAE.Text = "C&lient AE Title:";
               this.lblClientAE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // NextButton
               // 
               this.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
               this.NextButton.Location = new System.Drawing.Point(421, 532);
               this.NextButton.Name = "NextButton";
               this.NextButton.Size = new System.Drawing.Size(92, 24);
               this.NextButton.TabIndex = 20;
               this.NextButton.Text = "&Next";
               // 
               // PreviousButton
               // 
               this.PreviousButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
               this.PreviousButton.Location = new System.Drawing.Point(323, 532);
               this.PreviousButton.Name = "PreviousButton";
               this.PreviousButton.Size = new System.Drawing.Size(92, 24);
               this.PreviousButton.TabIndex = 19;
               this.PreviousButton.Text = "&Previous";
               // 
               // DICOMServerEventLogDetails
               // 
               this.AcceptButton = this.btnViewDataSet;
               this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
               this.CancelButton = this.btnClose;
               this.ClientSize = new System.Drawing.Size(520, 608);
               this.Controls.Add(this.PreviousButton);
               this.Controls.Add(this.NextButton);
               this.Controls.Add(this.txtServerIPAddress);
               this.Controls.Add(this.txtClientPort);
               this.Controls.Add(this.txtClientHostAddress);
               this.Controls.Add(this.txtClientAETitle);
               this.Controls.Add(this.txtType);
               this.Controls.Add(this.txtDateTime);
               this.Controls.Add(this.txtServerPort);
               this.Controls.Add(this.txtServerAETitle);
               this.Controls.Add(this.lblClientPort);
               this.Controls.Add(this.lblClientHostAddress);
               this.Controls.Add(this.lblClientAE);
               this.Controls.Add(this.rchtxtDescription);
               this.Controls.Add(this.grpSeparator);
               this.Controls.Add(this.btnViewDataSet);
               this.Controls.Add(this.btnClose);
               this.Controls.Add(this.lblDescription);
               this.Controls.Add(this.lblType);
               this.Controls.Add(this.lblDateTime);
               this.Controls.Add(this.lblServerPort);
               this.Controls.Add(this.lblServerIPAddress);
               this.Controls.Add(this.lblServerAETitle);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
               this.MaximizeBox = false;
               this.MinimizeBox = false;
               this.MinimumSize = new System.Drawing.Size(420, 440);
               this.Name = "DICOMServerEventLogDetails";
               this.ShowInTaskbar = false;
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "Event Log Details";
               this.ResumeLayout(false);
               this.PerformLayout();

            }
            
            private void RegisterEvents ( )
            {
               try
               {
                  btnClose.Click       += new EventHandler ( btnClose_Click ) ;
                  btnViewDataSet.Click += new EventHandler ( btnViewDataSet_Click ) ;
                  PreviousButton.Click += new EventHandler ( PreviousButton_Click ) ;
                  NextButton.Click     += new EventHandler ( NextButton_Click ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }

            private DicomDataSet GetEventDataset
            ( 
               long decEventID 
            )
            {
               try
               {
                  return __DataAccessAgent.GetDicomDataSet ( decEventID ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void DisplayDICOMDataSet ( ) 
            {
               try
               {
                  using ( DicomDataSet ds = GetDicomDataSet ( ) )
                  {
                     DatasetView DICOMDataSetViewDlg ;
                     
                     
                     DICOMDataSetViewDlg = new DatasetView ( ) ;
                     
                     Cursor.Current = Cursors.WaitCursor ;
                     
                     DICOMDataSetViewDlg.BindData ( ds ) ;
                     
                     DICOMDataSetViewDlg.ShowDialog ( ) ;
                  }
               }
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  MessageBox.Show ( Constants.Messages.MessageBox.DatasetViewError,
                                    Constants.Messages.MessageBox.EventLogDetailsErrorCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error ) ;
               }
               finally
               {
                  Cursor.Current = Cursors.Default ;
               }
            }

            private DicomDataSet GetDicomDataSet ( ) 
            {
               DicomDataSet ds;
               
               if ( SourceRow.IsDatasetPathNull ( ) )
               {
                  ds = GetEventDataset ( ( int ) SourceRow.EventID ) ;
               }
               else
               {
                  ds = new DicomDataSet (  ) ;
                  
                  ds.Load ( SourceRow.DatasetPath, DicomDataSetLoadFlags.None ) ;
               }
               
               return ds ;
            }
            
            
         #endregion
         
         #region Properties
            
            private ILoggingDataAccessAgent __DataAccessAgent
            {
               get
               {
                  if ( null == _dataAccessAgent )
                  {
                     if (!DataAccessServices.IsDataAccessServiceRegistered<ILoggingDataAccessAgent>())
                     {
                        System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();
                        _dataAccessAgent = DataAccessFactory.GetInstance(new LoggingDataAccessConfigurationView(configuration, PacsProduct.ProductName, PacsProduct.ServiceName)).CreateDataAccessAgent<ILoggingDataAccessAgent>();

                        DataAccessServices.RegisterDataAccessService<ILoggingDataAccessAgent> ( _dataAccessAgent ) ;
                     }
                     else
                     {
                        _dataAccessAgent = DataAccessServices.GetDataAccessService<ILoggingDataAccessAgent>();
                     }
                  }
                  
                  return _dataAccessAgent ;
               }
            }
            
            private void OnDisplayPrevious ( ) 
            {
               if ( null != DisplayPrevious ) 
               {
                  DisplayPrevious ( this, EventArgs.Empty ) ;
               }
            }
            
            private void OnDisplayNext ( ) 
            {
               if ( null != DisplayNext ) 
               {
                  DisplayNext ( this, EventArgs.Empty ) ;
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
               catch
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
               }
            }
            
            
            private void btnViewDataSet_Click ( object sender, EventArgs e )
            {
               try
               {
                  DisplayDICOMDataSet ( ) ;
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex.Message ) ;
               }
            }
            
            void PreviousButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  OnDisplayPrevious ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception.Message ) ;
               }
            }
            
            void NextButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  OnDisplayNext ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception.Message ) ;
               }
            }
            
            
         #endregion
         
         #region Data Members
         
            private System.ComponentModel.Container components = null ;
            private System.Windows.Forms.Label lblDateTime ;
            private System.Windows.Forms.TextBox txtDateTime ;
            private System.Windows.Forms.Label lblType ;
            private System.Windows.Forms.TextBox txtType ;
            private System.Windows.Forms.Label lblDescription ;
            private System.Windows.Forms.Button btnViewDataSet ;
            private System.Windows.Forms.Button btnClose ;
            private System.Windows.Forms.RichTextBox rchtxtDescription ;
            private System.Windows.Forms.GroupBox grpSeparator ;
            private System.Windows.Forms.TextBox txtServerAETitle ;
            private System.Windows.Forms.Label lblServerAETitle ;
            private System.Windows.Forms.TextBox txtServerIPAddress ;
            private System.Windows.Forms.Label lblServerIPAddress ;
            private System.Windows.Forms.Label lblServerPort ;
            private System.Windows.Forms.TextBox txtServerPort ;
            private System.Windows.Forms.TextBox txtClientPort ;
            private System.Windows.Forms.Label lblClientPort ;
            private System.Windows.Forms.Label lblClientHostAddress ;
            private System.Windows.Forms.TextBox txtClientHostAddress ;
            private System.Windows.Forms.TextBox txtClientAETitle ;
            private System.Windows.Forms.Label lblClientAE ;
            private Button NextButton;
            private Button PreviousButton;
                  
            private ILoggingDataAccessAgent _dataAccessAgent ;
            
         #endregion
         
         #region Data Types Definition
         
            private class Constants
            {
               public class SpecialCharacter
               {
                  public const string Delimiter     = "^" ;
                  public const string AntiDelimiter = "\n" ;
               }
               
               public class Messages
               {
                  public class MessageBox
                  {
                     public const string EventLogDetailsErrorCaption = "Event Log Details Error" ;
                     public const string DatasetViewError = "Problem occurred while trying to open Dataset detail." ;
                  }
                  
                  
                  public class ExceptionMessages
                  {
                     public const string EVENT_TYPE_NOT_SUPPORTED    = "Event-Type not supported." ;
                     public const string SOURCEID_NOT_SUPPORTED      = "SourceID not supported." ;
                     public const string LOG_DIRECTION_NOT_SUPPORTED = "Log-Direction not supported." ;
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

