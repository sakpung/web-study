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
   public partial class ScalePropertiesDialog : Form
   {
      MedicalViewerScale _scale;
      private MedicalViewerCell _SelectedCell = null;
      private MedicalViewer _Viewer = null;
      private MedicalViewerKeys _keys = null;

      public ScalePropertiesDialog(MainForm owner, MedicalViewerCell selectedCell)
      {
         InitializeComponent();
         _Viewer = owner.Viewer;
         if (selectedCell == null)
         {
            if (_Viewer.Cells.Count != 0)
               selectedCell = (MedicalViewerCell)_Viewer.Cells[0];
         }
         _SelectedCell = selectedCell;

         if (selectedCell != null)
         {
             _txtCellIndex.Value = _Viewer.Cells.IndexOf(selectedCell);
         }

         if (_SelectedCell != null)
         {
             _scale = (MedicalViewerScale)(_SelectedCell.GetActionProperties(MedicalViewerActionType.Scale));
             _keys = _SelectedCell.GetActionKeys(MedicalViewerActionType.Scale);
         }
         else
         {
             _scale = (MedicalViewerScale)(MainForm.GlobalCell.GetActionProperties(MedicalViewerActionType.Scale));
             _keys = MainForm.GlobalCell.GetActionKeys(MedicalViewerActionType.Scale);
         }

         _btnCursor.ButtonCursor = _scale.ActionCursor;         
         _cmbApplyToCells.SelectedIndex = 0;
         _txtSensitivity.Value = _scale.Sensitivity;
         _chkCircular.Checked = _scale.CircularMouseMove;
         _txtScale.Value = _scale.Scale;
         owner.AddKeysToCombo(_cmbTopKey, _keys.MouseUp);
         owner.AddKeysToCombo(_cmbBottomKey, _keys.MouseDown);
         owner.AddModifiersToCombo(_cmbModifiers, _keys.Modifiers);

         _cmbApplyToCells.Enabled = (owner.Viewer.Cells.Count != 0);
      }

      private void _cmbApplyToCells_SelectedIndexChanged(object sender, EventArgs e)
      {
         _txtScale.Enabled = (_cmbApplyToCells.Text != "None");
         _txtCellIndex.Enabled = (_cmbApplyToCells.Text == "Custom");
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
          _keys.MouseUp = (Keys)_cmbTopKey.Items[_cmbTopKey.SelectedIndex];
          _keys.MouseDown = (Keys)_cmbBottomKey.Items[_cmbBottomKey.SelectedIndex];
          _keys.Modifiers = (MedicalViewerModifiers)_cmbModifiers.Items[_cmbModifiers.SelectedIndex];

          _scale.Sensitivity = _txtSensitivity.Value;
          _scale.CircularMouseMove = _chkCircular.Checked;
          _scale.ActionCursor = _btnCursor.ButtonCursor;

          MainForm.GlobalCell.SetActionKeys(MedicalViewerActionType.Scale, _keys);
          MainForm.GlobalCell.SetActionProperties(MedicalViewerActionType.Scale, _scale);

          foreach (MedicalViewerMultiCell cell in _Viewer.Cells)
          {
             MainForm.CopyKeysFromGlobalCell(MainForm.GlobalCell, cell, MedicalViewerActionType.Scale);
             MainForm.CopyActionPropertiesFromGlobalCell(MainForm.GlobalCell, cell, MedicalViewerActionType.Scale);
          }

          if (_cmbApplyToCells.Text != "None")
          {
              _scale.Scale = _txtScale.Value;
              MainForm.ApplyToCells(_Viewer, _cmbApplyToCells, _txtCellIndex, null, null, MedicalViewerActionType.Scale, _scale);
          }
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
         _btnApply_Click(sender, e);
      }
   }
}
