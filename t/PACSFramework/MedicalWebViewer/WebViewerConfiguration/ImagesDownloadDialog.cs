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
      public ImagesDownloadDialog(string appName)
      {
         InitializeComponent();

         this.Text = appName;
      }

      private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         Process.Start ( @"ftp://ftp.leadtools.com/pub/3d/" ) ;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
      }

      public bool DoNotShowAgainCheckBox
      {
         get
         {
            return _chkBoxDontShowThisAgain.Checked;
         }

         set
         {
            _chkBoxDontShowThisAgain.Checked = value;
         }
      }

      public bool VisibleCheckBox
      {
         get
         {
            return _chkBoxDontShowThisAgain.Visible;
         }
         set
         {
            _chkBoxDontShowThisAgain.Visible = value;
         }
      }

   }
}
