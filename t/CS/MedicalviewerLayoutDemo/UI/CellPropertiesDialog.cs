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

namespace MedicalViewerLayoutDemo
{
   public partial class CellPropertiesDialog : Form
   {
      MedicalViewerMultiCell _cell;
      public CellPropertiesDialog(MainForm mainForm, MedicalViewerMultiCell multiCell)
      {
         InitializeComponent();

         _cell = multiCell;

         if (multiCell != null)
            _rdoApplyToSelected.Checked = true;
         else
         {
            _cell = (MedicalViewerMultiCell)(mainForm.Viewer.Cells[0]);
            _rdoApplyToAll.Checked = true;
            _rdoApplyToSelected.Enabled = false;
         }

         _chkShowTags.Checked = _cell.ShowTags;
         _cmbDisplayRuler.SelectedIndex = (int)_cell.DisplayRulers;
         _chkApplyOnMove.Checked = _cell.ApplyActionOnMove;
         _chkApplyWLToAll.Checked = !_cell.ApplyOnIndividualSubCell;
         _chkFitImage.Checked = _cell.FitImageToCell;
         _txtRows.Text = _cell.Rows.ToString();
         _txtColumns.Text = _cell.Columns.ToString();
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
         _btnApply_Click(sender, e);
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         foreach (MedicalViewerMultiCell cell in ((MainForm)this.Owner).Viewer.Cells)
         {
            if (cell.Selected || _rdoApplyToAll.Checked)
            {
               if (cell.ShowTags != _chkShowTags.Checked)
                  cell.ShowTags = _chkShowTags.Checked;

               if (cell.DisplayRulers != (MedicalViewerRulers)_cmbDisplayRuler.SelectedIndex)
                  cell.DisplayRulers = (MedicalViewerRulers)_cmbDisplayRuler.SelectedIndex;

               if (cell.ApplyActionOnMove != _chkApplyOnMove.Checked)
                  cell.ApplyActionOnMove = _chkApplyOnMove.Checked;

               if (cell.ApplyOnIndividualSubCell != (!_chkApplyWLToAll.Checked))
                  cell.ApplyOnIndividualSubCell = !_chkApplyWLToAll.Checked;

               if (cell.FitImageToCell != _chkFitImage.Checked)
                  cell.FitImageToCell = _chkFitImage.Checked;

               if (cell.Rows != _txtRows.Value)
                  cell.Rows = _txtRows.Value;

               if (cell.Columns != _txtColumns.Value)
                  cell.Columns = _txtColumns.Value;
            }
         }
      }

   }
}
