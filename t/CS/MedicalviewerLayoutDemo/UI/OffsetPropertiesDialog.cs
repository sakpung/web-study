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
   public partial class OffsetPropertiesDialog : Form
   {
      MedicalViewerOffset _offset;      
      private MedicalViewerKeys _keys = null;
      private MedicalViewer _Viewer = null;
      private MedicalViewerCell _SelectedCell = null; 

      public OffsetPropertiesDialog(MainForm owner, MedicalViewerCell selectedCell)
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
             _offset = (MedicalViewerOffset)(_SelectedCell.GetActionProperties(MedicalViewerActionType.Offset, _txtCellIndex.Value));
             _keys = _SelectedCell.GetActionKeys(MedicalViewerActionType.Offset);
         }
         else
         {
             _offset = (MedicalViewerOffset)(MainForm.GlobalCell.GetActionProperties(MedicalViewerActionType.Offset, _txtCellIndex.Value));
             _keys = MainForm.GlobalCell.GetActionKeys(MedicalViewerActionType.Offset);
         }         

         _btnActionCursor.ButtonCursor = _offset.ActionCursor;        

         _cmbApplyToCell.SelectedIndex = 0;
         _txtX.Value = _offset.X;
         _txtY.Value = _offset.Y;

         _txtSensitivity.Value = _offset.Sensitivity;
         _chkCircular.Checked = _offset.CircularMouseMove;

         owner.AddKeysToCombo(_cmbLeftKey, _keys.MouseLeft);
         owner.AddKeysToCombo(_cmbRightKey, _keys.MouseRight);
         owner.AddKeysToCombo(_cmbBottomKey, _keys.MouseDown);
         owner.AddKeysToCombo(_cmbTopKey, _keys.MouseUp);
         owner.AddModifiersToCombo(_cmbModifiers, _keys.Modifiers);

         _cmbApplyToCell.Enabled = (owner.Viewer.Cells.Count != 0);
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
         _btnApply_Click(sender, e);
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
          _keys.MouseDown = (Keys)_cmbBottomKey.Items[_cmbBottomKey.SelectedIndex];
          _keys.MouseLeft = (Keys)_cmbLeftKey.Items[_cmbLeftKey.SelectedIndex];
          _keys.MouseRight = (Keys)_cmbRightKey.Items[_cmbRightKey.SelectedIndex];
          _keys.MouseUp = (Keys)_cmbTopKey.Items[_cmbTopKey.SelectedIndex];
          _keys.Modifiers = (MedicalViewerModifiers)_cmbModifiers.Items[_cmbModifiers.SelectedIndex];

          _offset.Sensitivity = _txtSensitivity.Value;
          _offset.CircularMouseMove = _chkCircular.Checked;
          _offset.ActionCursor = _btnActionCursor.ButtonCursor;

          MainForm.GlobalCell.SetActionKeys(MedicalViewerActionType.Offset, _keys);
          MainForm.GlobalCell.SetActionProperties(MedicalViewerActionType.Offset, _offset);

          foreach (MedicalViewerMultiCell cell in _Viewer.Cells)
          {
             MainForm.CopyKeysFromGlobalCell(MainForm.GlobalCell, cell, MedicalViewerActionType.Offset);
             MainForm.CopyActionPropertiesFromGlobalCell(MainForm.GlobalCell, cell, MedicalViewerActionType.Offset);
          }

         if (_cmbApplyToCell.Text != "None")
          {
              _offset.X = _txtY.Value;
              _offset.Y = _txtX.Value;
              MainForm.ApplyToCells(_Viewer, _cmbApplyToCell, _txtCellIndex, null, null, MedicalViewerActionType.Offset, _offset);
          }

      }

      private void _cmbApplyToCell_SelectedIndexChanged(object sender, EventArgs e)
      {
         _txtY.Enabled = (_cmbApplyToCell.Text != "None");
         _txtX.Enabled = (_cmbApplyToCell.Text != "None");
         _txtCellIndex.Enabled = (_cmbApplyToCell.Text == "Custom");
      }
   }
}
