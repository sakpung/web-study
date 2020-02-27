// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using Microsoft.Win32;
using Leadtools.WebScanning.Host.Properties;
using Leadtools.Demos;

namespace Leadtools.WebScanning.Host
{
   public partial class WebScanningForm : Form
   {
      private TwainServiceHost _serviceHost;
      private const string _appName = "Leadtools.WebScanning.Host";

      public WebScanningForm()
      {
         this.WindowState = FormWindowState.Minimized;
         this.ShowInTaskbar = false;
         InitializeComponent();

         SetRunatStartup(Settings.Default.RunatStartup);
         _startupChkBox.Checked = Settings.Default.RunatStartup;
      }

      // Disable Close (x) button
      private const int CP_NOCLOSE_BUTTON = 0x200;
      protected override CreateParams CreateParams
      {
         get
         {
            CreateParams myCp = base.CreateParams;
            myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
            return myCp;
         }
      }

      private void StartupChkBox_CheckedChanged(object sender, EventArgs e)
      {
         SetRunatStartup(_startupChkBox.Checked);
      }

      private void SetRunatStartup(bool activate)
      {
         RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

         string appPath = (string)rk.GetValue(_appName);

         if (activate)
         {
            if (appPath != Application.ExecutablePath.ToString())
            {
               rk.SetValue(_appName, Application.ExecutablePath.ToString());
               Settings.Default.RunatStartup = true;
               Settings.Default.Save();
            }
         }
         else
         {
            rk.DeleteValue(_appName, false);
            Settings.Default.RunatStartup = false;
            Settings.Default.Save();
         }
      }

      private void TrayIcon_DoubleClick(object sender, EventArgs e)
      {
         ShowForm();
      }

      private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ShowForm();
      }

      private void ShowForm()
      {
         this.Show();
         this.WindowState = FormWindowState.Normal;
         this.BringToFront();
      }

      private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _serviceHost.Stop();
         this.Close();
      }

      private void WebScanningForm_Resize(object sender, EventArgs e)
      {
         if (this.WindowState == FormWindowState.Minimized)
            this.Hide();
      }

      private void WebScanningForm_Load(object sender, EventArgs e)
      {
         try
         {
            _serviceHost = new TwainServiceHost();
            _serviceHost.Start(this.Handle);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }
   }
}
