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
using System.Diagnostics;
using System.Configuration;

namespace Leadtools.Demos
{
   public partial class ImagesDownloadDialog : Form
   {
      private bool _showCheckBox;
      public ImagesDownloadDialog(string appName)
      {
         InitializeComponent();

         this.Text = appName;
         _chkBoxDontShowThisAgain.Checked = ShowCheckBox;
      }

      private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         Process.Start ( @"ftp://ftp.leadtools.com/pub/3d/" ) ;
      }

      private void SetConfigValue(string setting, bool value)
      {
         System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

         if (null != config.AppSettings.Settings[setting])
            config.AppSettings.Settings[setting].Value = value.ToString();
         config.Save(ConfigurationSaveMode.Modified);
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         SetConfigValue("ShowDownloadSamplesDialog", !_chkBoxDontShowThisAgain.Checked);
      }

      public bool ShowCheckBox
      {
         get
         {
            return _showCheckBox;
         }

         set
         {
            _showCheckBox = value;
         }
      }

   }
}
