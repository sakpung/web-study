// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Drawing ;
using System.Collections ;
using System.ComponentModel ;
using System.Windows.Forms ;


namespace Leadtools.Medical.Winforms.Control
{
   class DeleteRowFailedDialog : System.Windows.Forms.Form
   {
      #region Public
         
         #region Methods
         
            public DeleteRowFailedDialog ( )
            {
               try
               {
                  InitializeComponent ( ) ;   
                  
                  HandleDetailsDisplay ( ) ;
                  
                  picbxIcon.Paint += new PaintEventHandler ( picbxIcon_Paint ) ;
                  
                  btnRetry.Click   += new EventHandler ( Close_Click ) ;
                  btnSkipAll.Click += new EventHandler ( Close_Click ) ;
                  btnSkip.Click    += new EventHandler ( Close_Click ) ;
                  
                  btnDetails.Click += new EventHandler ( btnDetails_Click ) ;
                  
                  this.Closing += new CancelEventHandler ( DeleteRowFailedDialog_Closing ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
         #endregion
         
         #region Properties
         
            public string DetailsMessage
            {
               get
               {
                  return rtxtDetails.Text ;
               }
               
               set
               {
                  rtxtDetails.Text = value ;
               }
            }
            
            
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
         
            protected override void Dispose( bool disposing )
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
               this.pnlControls = new System.Windows.Forms.Panel();
               this.btnDetails = new System.Windows.Forms.Button();
               this.grpSeparator = new System.Windows.Forms.GroupBox();
               this.btnSkipAll = new System.Windows.Forms.Button();
               this.btnSkip = new System.Windows.Forms.Button();
               this.btnRetry = new System.Windows.Forms.Button();
               this.lblDialogError = new System.Windows.Forms.Label();
               this.picbxIcon = new System.Windows.Forms.PictureBox();
               this.pnlDetails = new System.Windows.Forms.Panel();
               this.rtxtDetails = new System.Windows.Forms.RichTextBox();
               this.pnlControls.SuspendLayout();
               this.pnlDetails.SuspendLayout();
               this.SuspendLayout();
               // 
               // pnlControls
               // 
               this.pnlControls.Controls.Add(this.btnDetails);
               this.pnlControls.Controls.Add(this.grpSeparator);
               this.pnlControls.Controls.Add(this.btnSkipAll);
               this.pnlControls.Controls.Add(this.btnSkip);
               this.pnlControls.Controls.Add(this.btnRetry);
               this.pnlControls.Controls.Add(this.lblDialogError);
               this.pnlControls.Controls.Add(this.picbxIcon);
               this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
               this.pnlControls.Location = new System.Drawing.Point(0, 0);
               this.pnlControls.Name = "pnlControls";
               this.pnlControls.Size = new System.Drawing.Size(354, 151);
               this.pnlControls.TabIndex = 6;
               // 
               // btnDetails
               // 
               this.btnDetails.Location = new System.Drawing.Point(8, 106);
               this.btnDetails.Name = "btnDetails";
               this.btnDetails.Size = new System.Drawing.Size(112, 30);
               this.btnDetails.TabIndex = 16;
               this.btnDetails.Text = "Show &details >>";
               // 
               // grpSeparator
               // 
               this.grpSeparator.Location = new System.Drawing.Point(0, 90);
               this.grpSeparator.Name = "grpSeparator";
               this.grpSeparator.Size = new System.Drawing.Size(376, 8);
               this.grpSeparator.TabIndex = 17;
               this.grpSeparator.TabStop = false;
               // 
               // btnSkipAll
               // 
               this.btnSkipAll.DialogResult = System.Windows.Forms.DialogResult.Abort;
               this.btnSkipAll.Location = new System.Drawing.Point(232, 59);
               this.btnSkipAll.Name = "btnSkipAll";
               this.btnSkipAll.TabIndex = 15;
               this.btnSkipAll.Text = "Skip &All";
               // 
               // btnSkip
               // 
               this.btnSkip.DialogResult = System.Windows.Forms.DialogResult.Ignore;
               this.btnSkip.Location = new System.Drawing.Point(152, 59);
               this.btnSkip.Name = "btnSkip";
               this.btnSkip.TabIndex = 14;
               this.btnSkip.Text = "&Skip";
               // 
               // btnRetry
               // 
               this.btnRetry.DialogResult = System.Windows.Forms.DialogResult.Retry;
               this.btnRetry.Location = new System.Drawing.Point(72, 59);
               this.btnRetry.Name = "btnRetry";
               this.btnRetry.TabIndex = 13;
               this.btnRetry.Text = "&Retry";
               // 
               // lblDialogError
               // 
               this.lblDialogError.Location = new System.Drawing.Point(64, 19);
               this.lblDialogError.Name = "lblDialogError";
               this.lblDialogError.Size = new System.Drawing.Size(248, 20);
               this.lblDialogError.TabIndex = 12;
               this.lblDialogError.Text = "Problem occurred while deleting event log.";
               this.lblDialogError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
               // 
               // picbxIcon
               // 
               this.picbxIcon.Location = new System.Drawing.Point(16, 12);
               this.picbxIcon.Name = "picbxIcon";
               this.picbxIcon.Size = new System.Drawing.Size(32, 32);
               this.picbxIcon.TabIndex = 11;
               this.picbxIcon.TabStop = false;
               // 
               // pnlDetails
               // 
               this.pnlDetails.Controls.Add(this.rtxtDetails);
               this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
               this.pnlDetails.Location = new System.Drawing.Point(0, 151);
               this.pnlDetails.Name = "pnlDetails";
               this.pnlDetails.Size = new System.Drawing.Size(354, 139);
               this.pnlDetails.TabIndex = 19;
               // 
               // rtxtDetails
               // 
               this.rtxtDetails.Dock = System.Windows.Forms.DockStyle.Fill;
               this.rtxtDetails.Location = new System.Drawing.Point(0, 0);
               this.rtxtDetails.Name = "rtxtDetails";
               this.rtxtDetails.ReadOnly = true;
               this.rtxtDetails.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
               this.rtxtDetails.Size = new System.Drawing.Size(354, 139);
               this.rtxtDetails.TabIndex = 10;
               this.rtxtDetails.Text = "";
               // 
               // DeleteRowFailedDialog
               // 
               this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
               this.ClientSize = new System.Drawing.Size(354, 290);
               this.ControlBox = false;
               this.Controls.Add(this.pnlDetails);
               this.Controls.Add(this.pnlControls);
               this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
               this.MaximizeBox = false;
               this.MinimizeBox = false;
               this.Name = "DeleteRowFailedDialog";
               this.ShowInTaskbar = false;
               this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
               this.Text = "Error";
               this.pnlControls.ResumeLayout(false);
               this.pnlDetails.ResumeLayout(false);
               this.ResumeLayout(false);

            }



            private void HandleDetailsDisplay ( ) 
            {
               try
               {   
                  if ( __ShowDetails ) 
                  {
                     btnDetails.Text = Constants.DetailsCaption.HideDetails ;
                     
                     this.Height = Constants.PanelHeights.ControlsPanel + 
                                   Constants.PanelHeights.DetailsPanel + 
                                   SystemInformation.CaptionHeight + 
                                   SystemInformation.BorderSize.Height ;
                  }
                  else
                  {
                     btnDetails.Text = Constants.DetailsCaption.ShowDetails ;
                     
                     this.Height = Constants.PanelHeights.ControlsPanel + 
                                   SystemInformation.CaptionHeight + 
                                   SystemInformation.BorderSize.Height ;
                  }
                  
                  pnlDetails.Visible = __ShowDetails ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            

            
         #endregion

         #region Properties
         
            private bool __ShowDetails
            {
               get
               {
                  return m_bShowDetails ;
               }
            
               set
               {
                  m_bShowDetails = value ;
               }
            }
            
            
         #endregion
         
         #region Events
         
            private void picbxIcon_Paint
            (
               object sender, 
               PaintEventArgs e
            )
            {
               try
               {
                                    
                  e.Graphics.DrawIcon ( SystemIcons.Error, 
                                        new Rectangle ( 0, 
                                                        0, 
                                                        SystemIcons.Error.Width, 
                                                        SystemIcons.Error.Height ) ) ;   
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }

            private void Close_Click
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  this.Close ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            private void btnDetails_Click
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  __ShowDetails = ! __ShowDetails ;
                  
                  HandleDetailsDisplay ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            
            private void DeleteRowFailedDialog_Closing
            (
               object sender, 
               CancelEventArgs e
            )
            {
               try
               {
                  e.Cancel = ( DialogResult.Cancel == this.DialogResult ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
         #endregion
         
         #region Data Members
         
            private System.ComponentModel.Container components = null ;
            private System.Windows.Forms.Panel pnlControls ;
            private System.Windows.Forms.Button btnDetails ;
            private System.Windows.Forms.Button btnSkipAll  ;
            private System.Windows.Forms.Button btnSkip ;
            private System.Windows.Forms.Button btnRetry ;
            private System.Windows.Forms.Label lblDialogError ;
            private System.Windows.Forms.Panel pnlDetails ;
            private System.Windows.Forms.PictureBox picbxIcon ;
            private System.Windows.Forms.RichTextBox rtxtDetails ;
            private System.Windows.Forms.GroupBox grpSeparator ;
            
            private bool m_bShowDetails = false ;
            
         #endregion
         
         #region Data Types Definition
         
            private class Constants
            {
               public class PanelHeights
               {
                  public const int ControlsPanel = 151 ;
                  public const int DetailsPanel  = 139 ;
               }
               
               public class DetailsCaption
               {
                  public const string ShowDetails = "Show &details >>" ;
                  public const string HideDetails = "Hide &details >>" ;
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
