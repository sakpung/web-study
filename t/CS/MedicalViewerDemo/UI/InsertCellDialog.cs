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
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.WinForms.CommonDialogs.File;
using Leadtools.MedicalViewer;

namespace MedicalViewerDemo
{
   public partial class InsertCellDialog : Form
   {
      RasterCodecs _codecs;
      public InsertCellDialog(MainForm owner)
      {
         _codecs = new RasterCodecs();
         InitializeComponent();

         this.CancelButton = _btnCancel;
         this.AcceptButton = _btnOK;

         // set the allowed range for the cell index text box.
         _txtCellIndex.MinimumAllowed = -1;
         _txtCellIndex.MaximumAllowed = owner.Viewer.Cells.Count;
         _txtCellIndex.Text = (0).ToString();
      }

      private void insertNewCellRadio_CheckedChanged(object sender, EventArgs e)
      {
            // Enable or disable the controls based on this radio button state.
         _lblCellIndex.Enabled = _chkInsert.Checked;
         _txtCellIndex.Enabled = _chkInsert.Checked;
            if (_txtCellIndex.Enabled)
               _txtCellIndex.Focus();
      }

      private void okButton_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.OK;
         ((MainForm)(this.Owner)).CellIndex = _chkInsert.Checked ? _txtCellIndex.Value : -1;
      }

   }
}
