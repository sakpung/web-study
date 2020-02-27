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
using Leadtools.MedicalViewer;

namespace MedicalViewerDemo
{
   public partial class CalibrateRulerDialog : Form
   {
      MedicalViewerMultiCell _cell = null;
      public CalibrateRulerDialog(MainForm owner)
      {
         InitializeComponent();

         int cellIndex = owner.SearchForFirstSelected();
         _cell = (MedicalViewerMultiCell)owner.Viewer.Cells[cellIndex];

         _cmbUnit.SelectedIndex = (int)(_cell.MeasurementUnit);
         _txtDistance.MinimumAllowed = 1;
         _txtDistance.MaximumAllowed = 100;
         _txtDistance.Text = (1).ToString();
         _chkApplyToAll.Checked = owner.ApplyToAll;
      }

      private void applyButton_Click(object sender, EventArgs e)
      {
         int subCellIndex = (_chkApplyToAll.Checked) ? -1 : -2;
         ((MainForm)this.Owner).ApplyToAll = _chkApplyToAll.Checked;
         foreach (MedicalViewerMultiCell cell in ((MainForm)this.Owner).Viewer.Cells)
         {
            if (cell.Selected)
               cell.CalibrateRuler(_txtDistance.Value, (MedicalViewerMeasurementUnit)(_cmbUnit.SelectedIndex), subCellIndex);
         }
      }

      private void okButton_Click(object sender, EventArgs e)
      {
         applyButton_Click(sender, e);
         this.Close();
      }
   }
}
