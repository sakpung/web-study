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


namespace MedicalViewerDemo
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
             _windowLevel = MainForm.DefaultCell.GetActionProperties(MedicalViewerActionType.WindowLevel, 0) as MedicalViewerWindowLevel;
             _keys = MainForm.DefaultCell.GetActionKeys(MedicalViewerActionType.WindowLevel);


             _chkUseWindowLevelBoundaries.Checked = MainForm.DefaultCell.UseWindowLevelBoundaries;
             _cmbBoxPaletteType.SelectedIndex = (int)(MainForm.DefaultCell.SubCells[0].PaletteType);

         }
         else
         {
             _windowLevel = selectedCell.GetActionProperties(MedicalViewerActionType.WindowLevel, 0) as MedicalViewerWindowLevel;
             _keys = selectedCell.GetActionKeys(MedicalViewerActionType.WindowLevel);


             _chkUseWindowLevelBoundaries.Checked = selectedCell.UseWindowLevelBoundaries;

             _cmbBoxPaletteType.SelectedIndex = (int)(selectedCell.SubCells[0].PaletteType);

         }

         _cmbFillType.Items.Add(MedicalViewerLookupTableType.Linear);
         _cmbFillType.Items.Add(MedicalViewerLookupTableType.Logarithmic);
         _cmbFillType.Items.Add(MedicalViewerLookupTableType.Exponential);
         _cmbFillType.Items.Add(MedicalViewerLookupTableType.Sigmoid);
         _btnCursor.ButtonCursor = _windowLevel.ActionCursor;

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

         if (_Viewer.Cells.Count == 0)
             return;

         MedicalViewerMultiCell myCell = (MedicalViewerMultiCell)_Viewer.Cells[_txtCellIndex.Value];

         _chkUseWindowLevelBoundaries.Checked = myCell.UseWindowLevelBoundaries;


         _txtCellIndex.Enabled = enableControls && (_cmbApplyToCell.Text == "Custom");
         _cmbApplyToSubCell.Enabled = enableControls;
         _txtSubcellIndex.Enabled = (enableControls && enableSubCellControls);
         _txtWidth.Enabled = enableControls;
         _txtCenter.Enabled = enableControls;
         _cmbFillType.Enabled = enableControls;

         _cmbBoxPaletteType.Enabled = enableControls;
         _chkUseWindowLevelBoundaries.Enabled = enableControls;

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

          MainForm.DefaultCell.SetActionKeys(MedicalViewerActionType.WindowLevel, _keys);
          MainForm.DefaultCell.SetActionProperties(MedicalViewerActionType.WindowLevel, _windowLevel);


          MainForm.DefaultCell.UseWindowLevelBoundaries = _chkUseWindowLevelBoundaries.Checked;


          foreach (MedicalViewerMultiCell cell in _Viewer.Cells)
          {
             MainForm.CopyKeysFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.WindowLevel);
             MainForm.CopyActionPropertiesFromGlobalCell(MainForm.DefaultCell, cell, MedicalViewerActionType.WindowLevel);
          }

         if (_cmbApplyToCell.Text != "None")
         {
            _windowLevel.Width = _txtWidth.Value;
            _windowLevel.Center = _txtCenter.Value;
            _windowLevel.LookupTableType = (MedicalViewerLookupTableType)_cmbFillType.Items[_cmbFillType.SelectedIndex];

            MainForm.ApplyToCells(_Viewer, _cmbApplyToCell, _txtCellIndex, _cmbApplyToSubCell, _txtSubcellIndex, MedicalViewerActionType.WindowLevel, _windowLevel, ApplyMoreFeatures);

         }


      }

      public void ApplyMoreFeatures(MedicalViewerMultiCell cell, int subCellIndex)
      {

          cell.UseWindowLevelBoundaries = _chkUseWindowLevelBoundaries.Checked;


          int from = 0;
          int to = 1;

          switch (subCellIndex)
          {
              case -2:
                  from = cell.ActiveSubCell;
                  to = from + 1;
                  break;
              case -1:
                  from = 0;
                  to = cell.SubCells.Count;
                  break;
              default:
                  from = subCellIndex;
                  to = subCellIndex + 1;
                  break;
          }


          int counter;
          for (counter = from; counter < to; counter++)
          {
              cell.SubCells[counter].PaletteType = (MedicalViewerPaletteType)(_cmbBoxPaletteType.SelectedIndex);
          }

      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
         _btnApply_Click(sender, e);
      }
   }
}
