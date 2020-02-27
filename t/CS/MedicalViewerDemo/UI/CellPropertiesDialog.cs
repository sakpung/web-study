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
   public partial class CellPropertiesDialog : Form
   {
      public CellPropertiesDialog(MainForm mainForm, int i)
      {
         InitializeComponent();

         if (i != mainForm.Viewer.Cells.Count)
            _rdoApplyToSelected.Checked = true;
         else
         {
            i = 0;
            _rdoApplyToAll.Checked = true;
         }

         MedicalViewerMultiCell cell = (MedicalViewerMultiCell)mainForm.Viewer.Cells[i];
         _chkShowTags.Checked =  cell.ShowTags;
         _cmbDisplayRuler.SelectedIndex = (int)cell.DisplayRulers;
         _chkApplyOnMove.Checked = cell.ApplyActionOnMove;
         _chkApplyWLToAll.Checked = !cell.ApplyOnIndividualSubCell;
         _chkFitImage.Checked = cell.FitImageToCell;
         _txtRows.Text = cell.Rows.ToString();
         _txtColumns.Text = cell.Columns.ToString();

         _chkSnapRulers.Checked = cell.SnapRulers;
         _chkDisableControlPoints.Checked = !cell.ShowControlPoints;

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

               if (_chkSnapRulers.Checked != cell.SnapRulers)
                   cell.SnapRulers = _chkSnapRulers.Checked;

               if (_chkDisableControlPoints.Checked == cell.ShowControlPoints)
                   cell.ShowControlPoints = !_chkDisableControlPoints.Checked;

            }
         }
      }

   }
}
