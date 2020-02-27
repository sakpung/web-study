// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections ;
using System.ComponentModel ;
using System.Drawing ;
using System.Data ;
using System.Windows.Forms ;


namespace Leadtools.Medical.Winforms
{
   partial class PeformedProcedureStepQuery : System.Windows.Forms.UserControl
   {
      #region Public
         
         #region Methods
         
            public PeformedProcedureStepQuery ( )
            {
               try
               {
                  InitializeComponent ( ) ;   
                  
                  Init ( ) ;
                  
                  RegisterEvents ( ) ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }



            public void Reset ( ) 
            {
               try
               {
                  ctlMPPSSOPInstanceUIDView.Reset ( ) ;
                  ctlStudySOPInstanceUIDView.Reset ( ) ;
                  
                  chkStatusInProgress.Checked = false ;
                  chkStatusCompleted.Checked  = false ;
                  chkStatusDiscontinued.Checked = false ;
                  
                  dtpicMPPSStartDateTimeFrom.Checked = false ;
                  dtpicMPPSStartDateTimeTo.Checked   = false ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
         #endregion
         
         #region Properties
         
            public string MPPSSOPInstanceUIDs
            {
               get
               {
                  return ctlMPPSSOPInstanceUIDView.SOPInstanceUIDs ;
               }
            }
            
            
            public string StudyInstanceUIDs
            {
               get
               {
                  return ctlStudySOPInstanceUIDView.SOPInstanceUIDs ;
               }
            }
            
            
            public string MPPSStatus
            {
               get
               {
                  string strMPPSStatus = string.Empty ;
                  
                  
                  if ( chkStatusInProgress.Checked )
                  {
                     strMPPSStatus =  chkStatusInProgress.Tag.ToString ( ) ;
                     strMPPSStatus += Constants.GroupDelimeter ;
                  }
                  
                  if ( chkStatusCompleted.Checked )
                  {
                     strMPPSStatus +=  chkStatusCompleted.Tag.ToString ( ) ;
                     strMPPSStatus += Constants.GroupDelimeter ;
                  }
                  
                  if ( chkStatusDiscontinued.Checked )
                  {
                     strMPPSStatus +=  chkStatusDiscontinued.Tag.ToString ( ) ;
                     strMPPSStatus += Constants.GroupDelimeter ;
                  }
                  
                  if ( strMPPSStatus.Length != 0 ) 
                  {
                     strMPPSStatus = strMPPSStatus.TrimEnd ( Constants.GroupDelimeter.ToCharArray ( ) ) ;
                  }
                  
                  return strMPPSStatus ;
               }
            }
            
            public string MPPSStartDateFrom
            {
               get
               {
                  if ( dtpicMPPSStartDateTimeFrom.Checked )
                  {
                     return dtpicMPPSStartDateTimeFrom.Value.ToString ( ) ;
                  }
                  else
                  {
                     return string.Empty ;
                  }
               }
            }
            
            public string MPPSStartDateTo
            {
               get
               {
                  if ( dtpicMPPSStartDateTimeTo.Checked )
                  {
                     return dtpicMPPSStartDateTimeTo.Value.ToString ( ) ;
                  }
                  else
                  {
                     return string.Empty ;
                  }
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
                  InitSOPInstanceUIDControls ( ) ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
                        
                        
            private void RegisterEvents ( )
            {
               try
               {
                  dtpicMPPSStartDateTimeFrom.ValueChanged += new EventHandler ( dtpicMPPSStartDateTimeFrom_ValueChanged ) ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
            
            private void InitSOPInstanceUIDControls ( )
            {
               try
               {
                  ctlMPPSSOPInstanceUIDView  = new InstanceUIDController ( ) ;
                  ctlStudySOPInstanceUIDView = new InstanceUIDController ( )  ;
                  
                  
                  // 
                  // grpMPPSSOPInstanceUID
                  // 
                  this.ctlMPPSSOPInstanceUIDView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                     | System.Windows.Forms.AnchorStyles.Left)));
                  this.ctlMPPSSOPInstanceUIDView.Location = new System.Drawing.Point(8, 21);
                  this.ctlMPPSSOPInstanceUIDView.Name = "ctlMPPSSOPInstanceUIDView";
                  this.ctlMPPSSOPInstanceUIDView.Size = new System.Drawing.Size(284, 137);
                  this.ctlMPPSSOPInstanceUIDView.TabIndex = 0;
                  this.ctlMPPSSOPInstanceUIDView.TabStop = true;
                  this.ctlMPPSSOPInstanceUIDView.Caption = "&MPPS SOP Instance UID:";
                  
                  
                  // 
                  // StudySOPInstanceUIDView
                  // 
                  this.ctlStudySOPInstanceUIDView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                     | System.Windows.Forms.AnchorStyles.Left)));
                  this.ctlStudySOPInstanceUIDView.Location = new System.Drawing.Point(299, 21);
                  this.ctlStudySOPInstanceUIDView.Name = "ctlStudyInstanceUIDView";
                  this.ctlStudySOPInstanceUIDView.Size = new System.Drawing.Size(284, 137);
                  this.ctlStudySOPInstanceUIDView.TabIndex = 1;
                  this.ctlStudySOPInstanceUIDView.TabStop = true;
                  this.ctlStudySOPInstanceUIDView.Caption = "&Study Instance UID:";
                  
                  this.grpPPSQuery.Controls.Add ( ctlMPPSSOPInstanceUIDView ) ;
                  this.grpPPSQuery.Controls.Add ( ctlStudySOPInstanceUIDView ) ;
               }
               catch ( System.Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                   
                  throw exception ;
               }
            }
            
            
            
            private void FixDateTimeControlsMinValue ( ) 
            {
               try
               {
                  FixStartDateTo ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                  
                  throw exception ;
               }
            }
            
            
            private void FixStartDateTo ( ) 
            {
               try
               {
                  dtpicMPPSStartDateTimeTo.MinDate = dtpicMPPSStartDateTimeFrom.Value ;
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
         
            private void dtpicMPPSStartDateTimeFrom_ValueChanged
            (
               object sender, 
               EventArgs e
            )
            {
               try
               {
                  FixStartDateTo ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false ) ;
                        
                  throw exception ;
               }
            }
         
         #endregion
         
         #region Data Members
         
         #endregion
         
         #region Data Types Definition
         
            private class Constants
            {
               public const string GroupDelimeter = "," ;
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
