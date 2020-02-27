// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections.Generic ;
using System.ComponentModel ;
using System.Drawing ;
using System.Data  ;
using System.Text ;
using System.Windows.Forms ;
using System.Net ;
using Leadtools.Dicom.Scu ;
using Leadtools.Demos.Workstation.Configuration ;
using Leadtools.Medical.Workstation.DataAccessLayer ;
using Leadtools.Medical.UserManagementDataAccessLayer;


namespace Leadtools.Demos.Workstation
{
   public partial class WorkstationConfiguration : UserControl
   {
      #region Public
   
         #region Methods
         
            public WorkstationConfiguration ( )
            {
               try
               {
                  InitializeComponent ( ) ;
                  
                  Init ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw exception ;
               }
            }
            
         #endregion
   
         #region Properties
         
            public bool CanViewPACSConfig
            {
               get
               {
                  return _canViewPACSConfig ;
               }
               
               set
               {
                  if ( value != _canViewPACSConfig ) 
                  {
                     _canViewPACSConfig = value ;
                     
                     PACSToolStripButton.Enabled = value ;
                     
                     if ( value == false && 
                          this.Handle != IntPtr.Zero &&
                          ControlsAreaPanel.Controls.Contains ( _servers ) )
                     {
                        WorkstationClientToolStripButton.PerformClick ( ) ;
                     }
                  }
               }
            }
            
            public bool CanEditWorkstationClientInfo
            {
               get
               {
                  return _client.CanChangeClientInfo ; 
               }
               
               set
               {
                  _client.CanChangeClientInfo = value ;
               }
            }
            
            public bool CanChangeForceClientInfo
            {
               get
               {
                  return _client.CanChangeForceClientInfo ;
               }
               
               set
               {
                  _client.CanChangeForceClientInfo = value ;
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
                  _client            = new ClientConfiguration ( ) ;
                  _servers           = new DICOMServers ( ) ;
                  CanViewPACSConfig  = true ;
                  
                  ConfigurationTabControl.TabPages [ 0 ].Controls.Add ( _client ) ;
                  ConfigurationTabControl.TabPages [ 1 ].Controls.Add ( _servers ) ;
                  
                  _client.Dock  = DockStyle.Fill ;
                  _servers.Dock = DockStyle.Fill ;
                  
                  WorkstationToolStrip.CausesValidation = true ;
                  
                  this.Load += new EventHandler ( WorkstationConfiguration_Load ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw exception ;
               }
            }
                  
            private void RegisterEvents ( ) 
            {
               try
               {
                  WorkstationClientToolStripButton.Click += new EventHandler ( btnWorkstationClient_Click ) ;
                  PACSToolStripButton.Click              += new EventHandler ( btnPACS_Click ) ;
                  SaveChangesButton.Click                += new EventHandler ( btnSaveChanges_Click ) ;
                  
                  ConfigurationData.ValueChanged += new EventHandler ( Control_ValueChanged ) ;
                  
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw exception ;
               }
            }

            void Control_ValueChanged ( object sender, EventArgs e )
            {
               SaveChangesButton.Enabled = true ;
            }
            
            void WorkstationConfiguration_Load ( object sender, EventArgs e )
            {
               try
               {
                  SaveChangesButton.Enabled = false ;
                  
                  RegisterEvents ( ) ;
                  
                  WorkstationClientToolStripButton.PerformClick ( ) ;
               }
               catch ( Exception exception ) 
               {
                  ThreadSafeMessager.ShowError (  exception.Message ) ;
               }
            }
            
            private void btnSaveChanges_Click ( object sender, EventArgs e )
            {
               try
               {
                  SaveChanges ( ) ;
               }
               catch ( Exception exception ) 
               {
                  ThreadSafeMessager.ShowError (  exception.Message ) ;
               }
            }
            
            void btnWorkstationClient_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( this.Validate ( ) )
                  {
                     ControlsAreaPanel.Controls.Clear ( ) ;
                     
                     ControlsAreaPanel.Controls.Add ( _client ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  ThreadSafeMessager.ShowError (  exception.Message ) ;
               }
            }
            
            void btnPACS_Click(object sender, EventArgs e)
            {
               try
               {
                  if ( this.Validate ( ) )
                  {
                     ControlsAreaPanel.Controls.Clear ( ) ;
                     
                     ControlsAreaPanel.Controls.Add ( _servers ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  ThreadSafeMessager.ShowError (  exception.Message ) ;
               }
            }
            
            private void SaveChanges ( ) 
            {
               ConfigurationData.SaveChanges ( ) ;
               
               SaveChangesButton.Enabled = ConfigurationData.HasChanges ( ) ;
            }

         #endregion
   
         #region Properties
   
            
         #endregion
   
         #region Events
         
         #endregion
   
         #region Data Members
         
            ClientConfiguration _client ;
            DICOMServers _servers ;
            private bool _canViewPACSConfig ;

         #endregion

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
   }
}
