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
using System.Data.SqlClient ;
using System.Linq;
using System.Text ;
using System.Windows.Forms ;
using Leadtools.Demos;

namespace Leadtools.Demos.Sql
{
   partial class SqlServerConfigurationControl : UserControl
   {      
       public bool Overwrite
       {
           get
           {
               return checkBoxOverwrite.Checked;
           }
       }

      #region Public
         
         #region Methods
            
            public SqlServerConfigurationControl()
            {
               InitializeComponent ( ) ;
               
               Init ( ) ;
               
               RegisterEvents ( ) ;
            }
            
         #endregion
         
         #region Properties
            
            
            public string DefaultDatabaseName
            {
               get
               {
                  return _defaultDatabaseName ;
               }
               
               set
               {
                  _defaultDatabaseName = value ;
               }
            }
         
            public DbConfigurationMode Mode
            {
               get
               {
                  return _configMode ;
               }
               
               set
               {
                  _configMode = value ;
                  
                  if ( _configMode == DbConfigurationMode.Configure )
                  {
                     serverDatabaseComboBox.DropDownStyle = ComboBoxStyle.DropDown ;
                  }
                  else
                  {
                     serverDatabaseComboBox.DropDownStyle = ComboBoxStyle.Simple ;
                  }
               }
            }
            
            public string ConnectionString
            {
               get
               {
                  SqlConnectionStringBuilder connectionBuilder ;
                  
                  
                  connectionBuilder = new SqlConnectionStringBuilder ( ) ;
                  
                  connectionBuilder.DataSource = serverNameCoboBox.Text ;
                  connectionBuilder.IntegratedSecurity = windowsAuthenticationRadioButton.Checked ;
                  connectionBuilder.UserID             = userNameTextBox.Text ;
                  connectionBuilder.Password           = passwordTextBox.Text ;
                  connectionBuilder.InitialCatalog     = serverDatabaseComboBox.Text ;
                  connectionBuilder.Pooling            = true ;

                  return connectionBuilder.ConnectionString ;
               }
               
               set
               {
                  SqlConnectionStringBuilder connectionBuilder ;
                  
                  
                  if ( string.IsNullOrEmpty ( value ) )
                  {
                     userNameTextBox.Text                     = string.Empty ;
                     passwordTextBox.Text                     = string.Empty ;
                     serverDatabaseComboBox.Text              = string.Empty ;
                     windowsAuthenticationRadioButton.Checked = true ;
                  }
                  else
                  {
                     connectionBuilder = new SqlConnectionStringBuilder ( value ) ;
                     
                     serverNameCoboBox.Text                   = connectionBuilder.DataSource ;
                     windowsAuthenticationRadioButton.Checked = connectionBuilder.IntegratedSecurity ;
                     userNameTextBox.Text                     = connectionBuilder.UserID ;
                     passwordTextBox.Text                     = connectionBuilder.Password ;
                     serverDatabaseComboBox.Text              = connectionBuilder.InitialCatalog ;
                     
                     sqlAuthenticationRadioButton.Checked = !windowsAuthenticationRadioButton.Checked ;
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
         
            private void Init ( ) 
            {
               userInfoPanel.DataBindings.Add ( new Binding ( "Enabled", sqlAuthenticationRadioButton, "Checked" ) ) ;
               
               Mode = DbConfigurationMode.Configure ;
               
               DefaultDatabaseName = string.Empty ;
            }
               
            private void RegisterEvents ( ) 
            {
               this.Load                       += new EventHandler(SqlServerConfiguration_Load);
               refreshServersButton.Click      += new EventHandler(SqlServerConfiguration_Load);
               serverDatabaseComboBox.DropDown += new EventHandler(serverNameCoboBox_DropDown);
            }

         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
         
            void SqlServerConfiguration_Load ( object sender, EventArgs e )
            {
               if ( _DesignMode )
               {
                  return ;
               }
               
               this.Cursor = Cursors.WaitCursor ;
               
               try
               {
                  string [] locals ;
                  
                  try
                  {
                     locals = SqlUtilities.GetLocalSQLServerInstances ( ) ;
                  }
                  catch ( Exception ) 
                  {
                     locals = new string [ 0 ] ;
                  }


                  if (locals != null && locals.Length > 0)
                  {
                     serverNameCoboBox.Text = locals [ 0 ] ;
                  }
                  
                  if ( string.IsNullOrEmpty ( serverDatabaseComboBox.Text ) )
                  {
                     serverDatabaseComboBox.Text = DefaultDatabaseName ;
                  }
                  
                  if ( !_DesignMode )
                  {
                     string currentServer = serverNameCoboBox.Text;
                         
                        
                     serverNameCoboBox.DataSource = SqlUtilities.GetServerList ( ) ;
                      
                     if ( !string.IsNullOrEmpty ( currentServer ) )
                     {
                        serverNameCoboBox.Text = currentServer ;
                     }
                  }
               }
               catch ( Exception exception )
               {
                  try
                  {
                     //last time try to get the local servers.
                     serverNameCoboBox.DataSource = SqlUtilities.GetLocalSQLServerInstances ( ) ;
                  }
                  catch ( Exception )
                  {}
                                    
                  Messager.ShowError ( this, exception ) ;
               }
               finally
               {
                  this.Cursor = Cursors.Default ;
               }
            }
            
            private void serverNameCoboBox_DropDown ( object sender, EventArgs e )
            {
               try
               {
                  this.Cursor = Cursors.WaitCursor ;
                  
                  SqlConnectionStringBuilder connectionBuilder ;                                     
                  
                  connectionBuilder = new SqlConnectionStringBuilder ( ) ;
                  
                  connectionBuilder.DataSource = serverNameCoboBox.Text ;
                  connectionBuilder.IntegratedSecurity = windowsAuthenticationRadioButton.Checked ;
                  connectionBuilder.UserID             = userNameTextBox.Text ;
                  connectionBuilder.Password           = passwordTextBox.Text ;
                  
                  serverDatabaseComboBox.DataSource = SqlUtilities.GetDatabaseList ( connectionBuilder ) ;
               }
               catch ( Exception exp )
               {
                  serverDatabaseComboBox.DataSource = null ;                     
                  serverDatabaseComboBox.Items.Clear ( ) ;
                  Messager.ShowError ( this, exp ) ;                                                      
               }
               finally
               {
                  this.Cursor = Cursors.Default ;
               }
            }
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
            
         #endregion
         
         #region Properties
         
            private bool _DesignMode
            {
               get
               {
                  return (this.GetService(typeof(IDesignerHost)) != null) || 
                         (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime);
               }
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
         
            private DbConfigurationMode _configMode ;
            private string              _defaultDatabaseName ;
            
         #endregion            

            private void windowsAuthenticationRadioButton_CheckedChanged(object sender, EventArgs e)
            {
               if ( windowsAuthenticationRadioButton.Checked )
               {
                  labelSqlNote.Visible = true ;
               }
               else
               {
                  labelSqlNote.Visible = false ; 
               }
            }

            private void label6_Click(object sender, EventArgs e)
            {

            }

            private void label5_Click(object sender, EventArgs e)
            {

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
   }
}
