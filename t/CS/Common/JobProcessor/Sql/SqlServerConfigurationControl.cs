// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Windows.Forms;
using Leadtools.Demos;

namespace Leadtools.Common.JobProcessor
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

      public SqlServerConfigurationControl()
      {
         InitializeComponent();

         Init();

         RegisterEvents();
      }

      public bool IsWindowsAuthentication()
      {
         return windowsAuthenticationRadioButton.Checked;
      }

      public DbConfigurationMode Mode
      {
         get
         {
            return _configMode;
         }

         set
         {
            _configMode = value;

            if (_configMode == DbConfigurationMode.Configure)
            {
               serverDatabaseComboBox.DropDownStyle = ComboBoxStyle.DropDown;
            }
            else
            {
               serverDatabaseComboBox.DropDownStyle = ComboBoxStyle.Simple;
            }
         }
      }

      public string ConnectionString
      {
         get
         {
            SqlConnectionStringBuilder connectionBuilder;


            connectionBuilder = new SqlConnectionStringBuilder();

            connectionBuilder.DataSource = serverNameCoboBox.Text;
            connectionBuilder.IntegratedSecurity = windowsAuthenticationRadioButton.Checked;
            connectionBuilder.UserID = userNameTextBox.Text;
            connectionBuilder.Password = passwordTextBox.Text;
            connectionBuilder.InitialCatalog = serverDatabaseComboBox.Text;
            connectionBuilder.Pooling = true;

            return connectionBuilder.ConnectionString;
         }

         set
         {
            SqlConnectionStringBuilder connectionBuilder;


            if (string.IsNullOrEmpty(value))
            {
               userNameTextBox.Text = string.Empty;
               passwordTextBox.Text = string.Empty;
               serverDatabaseComboBox.Text = string.Empty;
               windowsAuthenticationRadioButton.Checked = true;
            }
            else
            {
               connectionBuilder = new SqlConnectionStringBuilder(value);

               serverNameCoboBox.Text = connectionBuilder.DataSource;
               windowsAuthenticationRadioButton.Checked = connectionBuilder.IntegratedSecurity;
               userNameTextBox.Text = connectionBuilder.UserID;
               passwordTextBox.Text = connectionBuilder.Password;
               serverDatabaseComboBox.Text = connectionBuilder.InitialCatalog;

               sqlAuthenticationRadioButton.Checked = !windowsAuthenticationRadioButton.Checked;
            }
         }
      }


      private void Init()
      {
         userInfoPanel.DataBindings.Add(new Binding("Enabled", sqlAuthenticationRadioButton, "Checked"));
         Mode = DbConfigurationMode.Configure;
      }

      private void RegisterEvents()
      {
         this.Load += new EventHandler(SqlServerConfiguration_Load);
         refreshServersButton.Click += new EventHandler(SqlServerConfiguration_Load);
         serverDatabaseComboBox.DropDown += new EventHandler(serverNameCoboBox_DropDown);
      }

      void SqlServerConfiguration_Load(object sender, EventArgs e)
      {
         if (_DesignMode)
         {
            return;
         }

         this.Cursor = Cursors.WaitCursor;
         string local = string.Empty;
         try
         {
            if (string.IsNullOrEmpty(serverDatabaseComboBox.Text))
            {
               serverDatabaseComboBox.Text = "LEADTOOLSJobProcessorDB";
            }

            if (!_DesignMode)
            {
               try
               {
                  string currentServer = serverNameCoboBox.Text;

                  try
                  {
                     serverNameCoboBox.DataSource = SqlUtilities.GetServerList(out local);

                     if(!String.IsNullOrEmpty(local))
                     {
                        serverNameCoboBox.Text = local;
                     }
                  }
                  catch (Exception)
                  {
                     Messager.ShowInformation(this,
                     "The application can't enumerate the SQL Servers located in your network because \"Microsoft SQL Server 2008 Management Objects (SMO)\" is not installed.\n\n" +
                     "You can manually type the SQL Server name in the server name field or install Microsoft SMO from the Microsoft site:\n" +
                     @"http://www.microsoft.com/downloadS/details.aspx?familyid=C6C3E9EF-BA29-4A43-8D69-A2BED18FE73C&displaylang=en");
                  }

                  if (!string.IsNullOrEmpty(currentServer))
                  {
                     serverNameCoboBox.Text = currentServer;
                  }
               }
               catch (Exception exp)
               {
                  Messager.ShowError(this, exp);
               }
            }
         }
         catch (Exception)
         {
            serverNameCoboBox.DataSource = local;

            Messager.ShowInformation(this,
                        "The application can't enumerate the SQL Servers located in your network because \"Microsoft SQL Server 2008 Management Objects (SMO)\" is not installed.\n\n" +
                        "You can manually type the SQL Server name in the server name field or install Microsoft SMO from the Microsoft site:\n" +
                        @"http://www.microsoft.com/downloadS/details.aspx?familyid=C6C3E9EF-BA29-4A43-8D69-A2BED18FE73C&displaylang=en");

            return;
         }
         finally
         {
            this.Cursor = Cursors.Default;
         }
      }

      private void serverNameCoboBox_DropDown(object sender, EventArgs e)
      {
         try
         {
            this.Cursor = Cursors.WaitCursor;

            SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();

            connectionBuilder.DataSource = serverNameCoboBox.Text;
            connectionBuilder.IntegratedSecurity = windowsAuthenticationRadioButton.Checked;
            connectionBuilder.UserID = userNameTextBox.Text;
            connectionBuilder.Password = passwordTextBox.Text;

            serverDatabaseComboBox.DataSource = SqlUtilities.GetDatabaseList(connectionBuilder.ConnectionString);
         }
         catch (Exception exp)
         {
            serverDatabaseComboBox.DataSource = null;
            serverDatabaseComboBox.Items.Clear();
            Messager.ShowError(this, exp);
         }
         finally
         {
            this.Cursor = Cursors.Default;
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

      private DbConfigurationMode _configMode;

      private void windowsAuthenticationRadioButton_CheckedChanged(object sender, EventArgs e)
      {
         if (windowsAuthenticationRadioButton.Checked)
         {
            labelSqlNote.Visible = true;
         }
         else
         {
            labelSqlNote.Visible = false;
         }
      }
   }
}
