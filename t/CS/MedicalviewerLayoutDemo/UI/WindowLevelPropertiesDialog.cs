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
using Leadtools.MedicalViewer;


namespace MedicalViewerLayoutDemo
{
   public partial class WindowLevelPropertiesDialog : Form
   {      
       private MedicalViewerCell _SelectedCell= null;       
       private MedicalViewerWindowLevel _windowLevel = null;
       private MedicalViewerKeys _keys = null;
       private MedicalViewer _Viewer = null;
     
      public WindowLevelPropertiesDialog(MainForm owner, MedicalViewerCell selectedCell)
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

         if (selectedCell == null)
         {
             _windowLevel = MainForm.GlobalCell.GetActionProperties(MedicalViewerActionType.WindowLevel, 0) as MedicalViewerWindowLevel;
             _keys = MainForm.GlobalCell.GetActionKeys(MedicalViewerActionType.WindowLevel); 
         }
         else
         {
             _windowLevel = selectedCell.GetActionProperties(MedicalViewerActionType.WindowLevel, 0) as MedicalViewerWindowLevel;
             _keys = selectedCell.GetActionKeys(MedicalViewerActionType.WindowLevel);
         }

         _cmbFillType.Items.Add(MedicalViewerLookupTableType.Linear);
         _cmbFillType.Items.Add(MedicalViewerLookupTableType.Logarithmic);
         _cmbFillType.Items.Add(MedicalViewerLookupTableType.Exponential);
         _cmbFillType.Items.Add(MedicalViewerLookupTableType.Sigmoid);
         _btnCursor.ButtonCursor = _windowLevel.ActionCursor;

         _lblStart.BoxColor = _windowLevel.StartColor;
         _lblEnd.BoxColor = _windowLevel.EndColor;
         _txtWidth.Value = (_windowLevel.Width == 0) ? 1 : _windowLevel.Width;
         _txtCenter.Value = _windowLevel.Center;
         int index = _cmbFillType.Items.IndexOf(_windowLevel.LookupTableType);
         _cmbFillType.SelectedIndex = index == -1 ? 0 : index;
         _txtSensitivity.Text = _windowLevel.Sensitivity.ToString();
         _chkCircular.Checked = _windowLevel.CircularMouseMove;
         _cmbApplyToCell.SelectedIndex = 0;
         _cmbApplyToSubCell.SelectedIndex = 0;

         owner.AddKeysToCombo(_cmbLeftKey, _keys.MouseLeft);
         owner.AddKeysToCombo(_cmbRightKey, _keys.MouseRight);
         owner.AddKeysToCombo(_cmbBottomKey, _keys.MouseDown);
         owner.AddKeysToCombo(_cmbTopKey, _keys.MouseUp);
         owner.AddModifiersToCombo(_cmbModifiers, _keys.Modifiers);

         _cmbApplyToCell.Enabled = (owner.Viewer.Cells.Count != 0);
      }

      private void _cmbApplyToCell_SelectedIndexChanged(object sender, EventArgs e)
      {
         bool enableControls = (_cmbApplyToCell.SelectedIndex != 0);
         bool enableSubCellControls = (_cmbApplyToSubCell.Text == "Custom");

         _txtCellIndex.Enabled = enableControls && (_cmbApplyToCell.Text == "Custom");
         _cmbApplyToSubCell.Enabled = enableControls;
         _txtSubcellIndex.Enabled = (enableControls && enableSubCellControls);
         _txtWidth.Enabled = enableControls;
         _txtCenter.Enabled = enableControls;
         _cmbFillType.Enabled = enableControls;
         _lblStart.Enabled = enableControls;
         _lblEnd.Enabled = enableControls;
         _btnStart.Enabled = enableControls;
         _btnEnd.Enabled = enableControls;
      }

      private void _cmbApplyToSubCell_SelectedIndexChanged(object sender, EventArgs e)
      {
         _txtSubcellIndex.Enabled = ((_cmbApplyToSubCell.Text == "Custom") && (_cmbApplyToCell.SelectedIndex != 0));
      }



      private void _btnApply_Click(object sender, EventArgs e)
      {        
          _keys.MouseDown = (Keys)_cmbBottomKey.Items[_cmbBottomKey.SelectedIndex];
          _keys.MouseLeft = (Keys)_cmbLeftKey.Items[_cmbLeftKey.SelectedIndex];
          _keys.MouseRight = (Keys)_cmbRightKey.Items[_cmbRightKey.SelectedIndex];
          _keys.MouseUp = (Keys)_cmbTopKey.Items[_cmbTopKey.SelectedIndex];
          _keys.Modifiers = (MedicalViewerModifiers)_cmbModifiers.Items[_cmbModifiers.SelectedIndex];

          _windowLevel.Sensitivity = _txtSensitivity.Value;
          _windowLevel.CircularMouseMove = _chkCircular.Checked;
          _windowLevel.ActionCursor = _btnCursor.ButtonCursor;

          MainForm.GlobalCell.SetActionKeys(MedicalViewerActionType.WindowLevel, _keys);
          MainForm.GlobalCell.SetActionProperties(MedicalViewerActionType.WindowLevel, _windowLevel);

          foreach (MedicalViewerMultiCell cell in _Viewer.Cells)
          {
             MainForm.CopyKeysFromGlobalCell(MainForm.GlobalCell, cell, MedicalViewerActionType.WindowLevel);
             MainForm.CopyActionPropertiesFromGlobalCell(MainForm.GlobalCell, cell, MedicalViewerActionType.WindowLevel);
          }

         if (_cmbApplyToCell.Text != "None")
         {
            _windowLevel.Width = _txtWidth.Value;
            _windowLevel.Center = _txtCenter.Value;
            _windowLevel.LookupTableType = (MedicalViewerLookupTableType)_cmbFillType.Items[_cmbFillType.SelectedIndex];
            _windowLevel.StartColor = _lblStart.BoxColor;
            _windowLevel.EndColor = _lblEnd.BoxColor;

            MainForm.ApplyToCells(_Viewer, _cmbApplyToCell, _txtCellIndex, _cmbApplyToSubCell, _txtSubcellIndex, MedicalViewerActionType.WindowLevel, _windowLevel);
         }
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
         _btnApply_Click(sender, e);
      }

      private void _btnStart_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblStart);
      }

      private void _btnEnd_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblEnd);
      }
   }
}
