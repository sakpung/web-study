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
   public partial class AlphaPropertiesDialog : Form
   {
      private MedicalViewerAlpha _alpha;
      private MedicalViewerCell _SelectedCell= null;
      private MedicalViewer _Viewer = null;
      private MedicalViewerKeys _keys = null;
       
      public AlphaPropertiesDialog(MainForm owner, MedicalViewerCell selectedCell)
      {
         InitializeComponent();
         _Viewer = owner.Viewer;
         if (selectedCell == null)
         {
            if (_Viewer.Cells.Count != 0)
               selectedCell = (MedicalViewerCell)_Viewer.Cells[0];
         }

         _SelectedCell = selectedCell;
         _txtCellIndex.Value = _Viewer.Cells.IndexOf(_SelectedCell);
         _txtSubCellIndex.Value = 0;

         if (_SelectedCell != null)
         {
             _alpha = (MedicalViewerAlpha)(_SelectedCell.GetActionProperties(MedicalViewerActionType.Alpha));             
             _keys = _SelectedCell.GetActionKeys(MedicalViewerActionType.Alpha);
         }
         else
         {
             _alpha = (MedicalViewerAlpha)(MainForm.DefaultCell.GetActionProperties(MedicalViewerActionType.Alpha));             
            _keys = MainForm.DefaultCell.GetActionKeys(MedicalViewerActionType.Alpha);
         }

         _btnCursor.ButtonCursor = _alpha.ActionCursor;

         _txtFactor.Value = _alpha.Alpha;

         _txtSensitivity.Value = _alpha.Sensitivity;
         _chkCircular.Checked = _alpha.CircularMouseMove;

         _cmbApplyToCell.SelectedIndex = 0;
         _cmbApplyToSubCell.SelectedIndex = 0;

         owner.AddKeysToCombo(_cmbLeftKey, _keys.MouseLeft);
         owner.AddKeysToCombo(_cmbRightKey, _keys.MouseRight);
         owner.AddModifiersToCombo(_cmbModifiers, _keys.Modifiers);

         _cmbApplyToCell.Enabled = (owner.Viewer.Cells.Count != 0);
      }

      private void _cmbApplyToSubCell_SelectedIndexChanged(object sender, EventArgs e)
      {
         _txtSubCellIndex.Enabled = ((_cmbApplyToSubCell.Text == "Custom") && (_cmbApplyToCell.SelectedIndex != 0));
      }

      private void _cmbApplyToCell_SelectedIndexChanged(object sender, EventArgs e)
      {
         bool enableControls = (_cmbApplyToCell.SelectedIndex != 0);
         bool enableSubCellControls = (_cmbApplyToSubCell.Text == "Custom");

         _txtCellIndex.Enabled = enableControls && (_cmbApplyToCell.Text == "Custom");
         _cmbApplyToSubCell.Enabled = enableControls;
         _txtSubCellIndex.Enabled = (enableControls && enableSubCellControls);
         _txtFactor.Enabled = enableControls;
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
          _keys.MouseLeft = (Keys)_cmbLeftKey.Items[_cmbLeftKey.SelectedIndex];
          _keys.MouseRight = (Keys)_cmbRightKey.Items[_cmbRightKey.SelectedIndex];
          _keys.Modifiers = (MedicalViewerModifiers)_cmbModifiers.Items[_cmbModifiers.SelectedIndex];          

          _alpha.Sensitivity = _txtSensitivity.Value;
          _alpha.CircularMouseMove = _chkCircular.Checked;
          _alpha.ActionCursor = _btnCursor.ButtonCursor;

          MainForm.DefaultCell.SetActionKeys(MedicalViewerActionType.Alpha, _keys);
          MainForm.DefaultCell.SetActionProperties(MedicalViewerActionType.Alpha, _alpha);

          foreach (MedicalViewerMultiCell cell in _Viewer.Cells)
          {
             MainForm.CopyKeysFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.Alpha);
             MainForm.CopyActionPropertiesFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.Alpha);
          }

          if (_cmbApplyToCell.Text != "None")
          {
             _alpha.Alpha = _txtFactor.Value;
             MainForm.ApplyToCells(_Viewer, _cmbApplyToCell, _txtCellIndex, _cmbApplyToSubCell, _txtSubCellIndex, MedicalViewerActionType.Alpha, _alpha);
          }
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         this.Close();
         _btnApply_Click(sender, e);
      }
   }
}
