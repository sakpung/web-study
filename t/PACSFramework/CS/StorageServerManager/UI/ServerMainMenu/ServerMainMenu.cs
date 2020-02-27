// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;

namespace Leadtools.Demos.StorageServer.UI
{
   public partial class ServerMainMenu : MenuStrip
   {
      #region Public
         
         #region Methods
         
            public ServerMainMenu ( )
            {
               InitializeComponent ( ) ;

               Init ( ) ;

               RegisterEvents ( ) ;
            }
         
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
         
            public event EventHandler ExitApplication ;
            public event EventHandler ShowSettings ;
            public event EventHandler ShowAbout ;
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods

            private void Init ( )
            {
               _file          = new ToolStripMenuItem ( "&File" ) ;
               _tools         = new ToolStripMenuItem ( "&Tools" ) ;
               _help          = new ToolStripMenuItem ( "&Help" ) ;
               _fileExit      = new ToolStripMenuItem ( "E&xit" ) ;
               _toolsSettings = new ToolStripMenuItem (  "&Settings..." ) ;
               _helpAbout     = new ToolStripMenuItem ( "&About" ) ;


               _file.DropDownItems.Add  ( _fileExit ) ;
               _tools.DropDownItems.Add ( _toolsSettings ) ;
               _help.DropDownItems.Add  ( _helpAbout ) ;

               this.Items.Add (_file ) ;
               this.Items.Add ( _tools ) ;
               this.Items.Add ( _help ) ;

               _toolsSettings.Enabled = UserManager.User.IsAdmin() || UserManager.User.IsAuthorized ( UserPermissions.CanChangeServerSettings ) ;
            }

            private void RegisterEvents ( )
            {
               _fileExit.Click      += new EventHandler ( _fileExit_Click ) ;
               _toolsSettings.Click += new EventHandler ( _toolsSettings_Click ) ;
               _helpAbout.Click     += new EventHandler ( _helpAbout_Click ) ;
            }
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
               
            void _toolsSettings_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( null != ShowSettings )
                  {
                     ShowSettings ( this, e ) ;
                  }
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }

            void _fileExit_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( null != ExitApplication ) 
                  {
                     ExitApplication ( this, e ) ;
                  }
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }

            void _helpAbout_Click(object sender, EventArgs e)
            {
               try
               {
                  if ( null != ShowAbout ) 
                  {
                     ShowAbout ( this, e ) ;
                  }
               }
               catch ( Exception ex ) 
               {
                  Messager.ShowError ( this, ex ) ;
               }
            }
         
         #endregion
         
         #region Data Members
         
            private ToolStripMenuItem _file ; 
            private ToolStripMenuItem _tools ; 
            private ToolStripMenuItem _help ; 
            private ToolStripMenuItem _fileExit ;
            private ToolStripMenuItem _toolsSettings ; 
            private ToolStripMenuItem _helpAbout ; 
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
   
}
