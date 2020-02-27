// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LEADUniversalViewer
{
   // This dialog is designed to give the user the ability to change the // loading resolution for document files (DOC, DOCx, PDF, etc.)
   public partial class LoadingResolutionDialog : Form
   {
      private int _LoadingResolution;

      private int _selecteResdIndex;

      public int LoadingResolution
      {
         get
         {
            return _LoadingResolution;
         }
         set
         {
            _LoadingResolution = value;
         }
      }

      public int SelecteResdIndex
      {
         get
         {
            return _selecteResdIndex;
         }
         set
         {
            _selecteResdIndex = value;
         }
      }

      public LoadingResolutionDialog()
      {
         InitializeComponent();
         _LoadingResolution = 150;
         _cmbResolutions.SelectedIndex = 3;
      }

      private void LoadingResolutionDialog_Load(object sender, EventArgs e)
      {
         _txtInfo.Text = "When you load big document files (PDF, Doc, Docx, etc.), or big number of pages, you might require sufficient free memory on your machine to load them smoothly. If you are facing any delay or memory consuming issues, try to reduce the loading resolution to smaller values (72, 96, 100, etc).";
         _cmbResolutions.SelectedIndex = SelecteResdIndex;
      }

      private void chkChangeResolution_CheckedChanged(object sender, EventArgs e)
      {
         _cmbResolutions.Enabled = _chkChangeResolution.Checked;
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         _LoadingResolution = int.Parse(_cmbResolutions.Text);

         this.Hide();
      }

      private void cmbResolutions_SelectedIndexChanged(object sender, EventArgs e)
      {
         SelecteResdIndex = _cmbResolutions.SelectedIndex;
      }

      private void LoadingResolutionDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         SelecteResdIndex = _cmbResolutions.SelectedIndex;
      }
   }
}
