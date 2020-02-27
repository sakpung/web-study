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
   public partial class StackPropertiesDialog : Form
   {
      MedicalViewerStack _stack;
      private MedicalViewerCell _SelectedCell = null;      
      private MedicalViewerKeys _keys = null;
      private MedicalViewer _Viewer = null;

      public StackPropertiesDialog(MainForm owner, MedicalViewerCell selectedCell)
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

         if (selectedCell != null)
         {
             _stack = (MedicalViewerStack)(_SelectedCell.GetActionProperties(MedicalViewerActionType.Stack));
             _keys = _SelectedCell.GetActionKeys(MedicalViewerActionType.Stack);
         }
         else
         {
             _stack = (MedicalViewerStack)(MainForm.DefaultCell.GetActionProperties(MedicalViewerActionType.Stack, _txtCellIndex.Value));
             _keys = MainForm.DefaultCell.GetActionKeys(MedicalViewerActionType.Stack);
         }

         _btnActionCursor.ButtonCursor = _stack.ActionCursor;

         _txtSensitivity.Value = _stack.Sensitivity;
         _chkCircular.Checked = _stack.CircularMouseMove;
         _txtStack.Value = _stack.ScrollValue;         
         _txtActiveSubCell.Value = _stack.ActiveSubCell;

         _cmbApplyToCells.SelectedIndex = 0;

         owner.AddKeysToCombo(_cmbTopKey, _keys.MouseUp);
         owner.AddKeysToCombo(_cmbBottomKey, _keys.MouseDown);
         owner.AddModifiersToCombo(_cmbModifiers, _keys.Modifiers);

         _cmbApplyToCells.Enabled = (owner.Viewer.Cells.Count != 0);
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
         _btnApply_Click(sender, e);
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
          _keys.MouseUp = (Keys)_cmbTopKey.Items[_cmbTopKey.SelectedIndex];
          _keys.MouseDown = (Keys)_cmbBottomKey.Items[_cmbBottomKey.SelectedIndex];
          _keys.Modifiers = (MedicalViewerModifiers)_cmbModifiers.Items[_cmbModifiers.SelectedIndex];         

          _stack.Sensitivity = _txtSensitivity.Value;
          _stack.CircularMouseMove = _chkCircular.Checked;
          _stack.ActionCursor = _btnActionCursor.ButtonCursor;

          MainForm.DefaultCell.SetActionKeys(MedicalViewerActionType.Stack, _keys);
          MainForm.DefaultCell.SetActionProperties(MedicalViewerActionType.Stack, _stack);

          foreach (MedicalViewerMultiCell cell in _Viewer.Cells)
          {
             MainForm.CopyKeysFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.Stack);
             MainForm.CopyActionPropertiesFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.Stack);
          }

          if (_cmbApplyToCells.Text != "None")
          {
             _stack.ScrollValue = _txtStack.Value;
             _stack.ActiveSubCell = _txtActiveSubCell.Value;
             MainForm.ApplyToCells(_Viewer, _cmbApplyToCells, _txtCellIndex, null, null, MedicalViewerActionType.Stack, _stack);
          }
      }

      private void _cmbApplyToCells_SelectedIndexChanged(object sender, EventArgs e)
      {
         _txtActiveSubCell.Enabled = (_cmbApplyToCells.Text != "None");
         _txtStack.Enabled = (_cmbApplyToCells.Text != "None");
         _txtCellIndex.Enabled = (_cmbApplyToCells.Text == "Custom");
      }

   }
}
