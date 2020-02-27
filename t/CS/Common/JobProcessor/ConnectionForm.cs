// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Microsoft.Win32;
using System.Net;
using System.Data.SqlClient;

namespace Leadtools.Common.JobProcessor
{
   public enum ServicesType
   {
      JobProcessorJobService = 0x000000001,
   }

   public partial class ConnectionForm : Form
   {
      string _connectionString = string.Empty;

      string _address;
      ServicesType _type;
      string _caption;
      bool _noDatabase;

      public string ConnectionString
      {
         get { return _connectionString; }
         set { _connectionString = value; }
      }

      public ConnectionForm(bool userHost, string address, string connectionString, string caption, bool noDatabase, bool enableUserHost)
      {
         InitializeComponent();
         _address = address;
         _caption = caption;
         _noDatabase = noDatabase;

         if (enableUserHost)
            _radUserHost.Enabled = true;
         else
            _radUserHost.Enabled = false;

         if(userHost)
         {
            _radUserHost.Checked = true;

            Set_UserHost_Settings();
         }
         else
         {
            Set_IIS_Settings();
         }

         if (!noDatabase)
         {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
            _txtDatabaseName.Text = builder.InitialCatalog;

            _connectionString = connectionString;
         }

         _txtDatabaseName.Enabled = !_noDatabase;
      }

      public ConnectionForm(string caption)
      {
         InitializeComponent();

         _caption = caption;
         Set_IIS_Settings();
      }

      void Set_IIS_Settings()
      {
         _radIIS.Checked = true;

         GetWebSite();
         _txtAlias.Enabled = false;
         _txtPort.Enabled = false;
         _txtAddress.Enabled = false;
      }

      void GetWebSite()
      {
         _txtAlias.Text = "LEADTOOLSJobProcessorServices";
         _txtPort.Text = "80";
         _txtAddress.Text = "localhost";
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         Cursor = Cursors.WaitCursor;
         string alias = "";

         if(_txtAlias.Text.Length > 0)
         {
            alias = "/" + _txtAlias.Text;
         }
         string tmpAddress = "http://" + _txtAddress.Text + ":" + _txtPort.Text + alias;

         bool jobServiceEnabled = false;

         try
         {
            if ((_type & ServicesType.JobProcessorJobService) == ServicesType.JobProcessorJobService)
            {

               string address = tmpAddress + @"/JobService.svc";
               WebRequest webRequest = (HttpWebRequest)WebRequest.Create(address);
               webRequest.Timeout = 180000;
               try
               {
                  WebResponse resp = (HttpWebResponse)webRequest.GetResponse();
                  jobServiceEnabled = true;

                  resp.Close();
               }
               catch
               {
                  jobServiceEnabled = false;
               }
            }
         }
         catch(Exception ex)
         {
            MessageBox.Show(ex.Message);
            DialogResult = DialogResult.None;
            Cursor = Cursors.Arrow;
            return;
         }


         if ((!jobServiceEnabled && (_type & ServicesType.JobProcessorJobService) == ServicesType.JobProcessorJobService))
         {
            if(!_radIIS.Checked)
            {
               string message = "The LEADTOOLS JobProcessor WCF Services could not be reached.\n\nLEADTOOLS installation ships with a Job Processor Host Demo located at:\n\n[LEADTOOLS_SETUP_PATH]\\Bin\\Dotnet4\\[Win32/x64]\\CSJobProcessorHostDemo_Original.exe\n\nDo you want to run the Job Processor Host Demo now?\n\nIf the demo is found, you need to click the 'Startup' button to start the service and try reconnecting from this demo.";

               if (MessageBox.Show(this, message, "JobProcessor Administrator Demo", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                  RunDemo("CSJobProcessorHostDemo_Original.exe");
               }
            }
            else
            {
               string message = "The LEADTOOLS JobProcessor WCF Services could not be reached.\n\nLEADTOOLS installation ships with a Job Processor Server Config Demo located at:\n\n[LEADTOOLS_SETUP_PATH]\\Bin\\Dotnet4\\[Win32/x64]\\CSJobProcessorServerConfigDemo_Original.exe\n\nThis demo will configure Internet Information System (IIS) on this machine to host the LEADTOOLS JobProcessor Components and create the virtual directory and application pool necessary for this demo to run.\n\nDo you want this demo to run the Job Processor Server Config Demo now?";
               if (MessageBox.Show(this, message, "JobProcessor Administrator Demo", MessageBoxButtons.YesNo) == DialogResult.Yes)
               {
                  RunDemo("CSJobProcessorServerConfigDemo_Original.exe");
               }
            }

            Cursor = Cursors.Arrow;
            DialogResult = DialogResult.None;
         }
         else
         {
            _address = tmpAddress;
            if (!_noDatabase)
            {
               SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(_connectionString);
               builder.InitialCatalog = _txtDatabaseName.Text;
               builder.DataSource = string.Format(@"{0}\{1}",_txtAddress.Text, "SQLEXPRESS");
               _connectionString = builder.ConnectionString;
            }

            Cursor = Cursors.Arrow;
            DialogResult = DialogResult.OK;
         }
      }

      private void _radUserHost_CheckedChanged(object sender, EventArgs e)
      {
         if(_radIIS.Checked == true)
         {
            Set_IIS_Settings();
         }
         else
         {
            Set_UserHost_Settings();
         }

         Cursor = Cursors.Default;
      }

      void Set_UserHost_Settings()
      {
         _txtAlias.Enabled = true;
         _txtPort.Enabled = true;
         _txtAddress.Enabled = true;

         if(Address != null)
         {
            if(Address.Length > 0)
            {
               Uri uri = new Uri(Address);
               _txtAddress.Text = uri.Host;
               _txtPort.Text = uri.Port.ToString();
               _txtAlias.Text = uri.AbsolutePath.Substring(1);
            }
         }
         else
         {
            _txtAddress.Text = String.Empty;
            _txtPort.Text = String.Empty;
            _txtAlias.Text = String.Empty;
         }
      }

      public bool UserHost
      {
         get
         {
            return _radUserHost.Checked;
         }
         set
         {
            _radUserHost.Checked = value;
         }
      }

      public string Address
      {
         get
         {
            return _address;
         }
         set
         {
            _address = value;
         }
      }

      private void _txtPort_KeyPress(object sender, KeyPressEventArgs e)
      {
         if(!e.Handled)
         {
            if(!Char.IsControl(e.KeyChar) && !Char.IsDigit(e.KeyChar))
               e.Handled = true;
         }
      }

      public ServicesType Type
      {
         get
         {
            return _type;
         }
         set
         {
            _type = value;
         }
      }

      public string Caption
      {
         get { return _caption; }
         set { _caption = value; }
      }

      private void RunDemo(string demoName)
      {
         string demoFullName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), demoName);
         if(!File.Exists(demoFullName))
            MessageBox.Show(this, string.Format("Could not find the file:\n\n{0}", demoFullName), String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
         else
         {
            try
            {
               Process.Start(demoFullName);
            }
            catch(Exception ex)
            {
               MessageBox.Show(this, ex.Message, String.Empty, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }
   }
}
