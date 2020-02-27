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
   public partial class ViewerPropertiesDialog : Form
   {
      public ViewerPropertiesDialog(MainForm owner)
      {
         InitializeComponent();
         MainForm _mainForm = (MainForm)owner;
         _txtRows.Text = _mainForm.Viewer.Rows.ToString();
         _txtColumns.Text = _mainForm.Viewer.Columns.ToString();
         _cmbRuler.SelectedIndex = (int)(MainForm.DefaultCell.RulerStyle);
         _cmbSplitterType.SelectedIndex = (int)(_mainForm.Viewer.SplitterStyle);
         _cmbPaintMethod.SelectedIndex = (int)(MainForm.DefaultCell.PaintingMethod);
         _cmbTextQuality.SelectedIndex = (int)(MainForm.DefaultCell.TextQuality);
         _cmbBorderStyle.SelectedIndex = (int)(MainForm.DefaultCell.BorderStyle);
         _cmbMeasurmentUnit.SelectedIndex = (int)(MainForm.DefaultCell.MeasurementUnit);
         _chkShowViewerScroll.Checked = _mainForm.Viewer.AutoScroll;
         _chkShowCellScroll.Checked = MainForm.DefaultCell.ShowCellScroll;
         _chkMaintainSize.Checked = _mainForm.Viewer.CellMaintenance;
         _chkUseExtraSplitters.Checked = _mainForm.Viewer.UseExtraSplitters;
         _chkShowFreeze.Checked = MainForm.DefaultCell.ShowFreezeText;

         _chkCustomSplitterColor.Checked = _mainForm.Viewer.CustomSplitterColor;
         _lblEmptyCellBackColor.BoxColor = _mainForm.Viewer.BackColor;
         _lblText.BoxColor = MainForm.DefaultCell.TextColor;
         _lblShadowColor.BoxColor = MainForm.DefaultCell.TextShadowColor;
         _lblActiveBorderColor.BoxColor = MainForm.DefaultCell.ActiveBorderColor;
         _lblNonActiveBorderColor.BoxColor = MainForm.DefaultCell.NonActiveBorderColor;
         _lblRulerInColor.BoxColor = MainForm.DefaultCell.RulerInColor;
         _lblRulerOutColor.BoxColor = MainForm.DefaultCell.RulerOutColor;
         _lblBackgroundColor.BoxColor = MainForm.DefaultCell.CellBackColor;
         _lblActiveSubcellColor.BoxColor = MainForm.DefaultCell.ActiveSubCellBorderColor;
         _lblSplitterColor.BoxColor =  _mainForm.Viewer.SplitterColor;
         _lblSplitterColor.Enabled =
         _btnSplitterColor.Enabled = _chkCustomSplitterColor.Checked;

         _btnVerticalCursor.ButtonCursor = _mainForm.Viewer.ResizeVerticalCursor;
         _btnBothCursor.ButtonCursor = _mainForm.Viewer.ResizeBoth;
         _btnHorizontalCursor.ButtonCursor = _mainForm.Viewer.ResizeHorizontalCursor;
         _btnDefaultCursor.ButtonCursor = _mainForm.Viewer.Cursor;

         int index = 0;
         foreach (MedicalViewerIcon icon in MainForm.DefaultCell.Titlebar.Icons)
         {
            ((ColorBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_lblColor1) + index]).BoxColor = icon.Color;
            ((ColorBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_lblColorPressed1) + index]).BoxColor = icon.ColorPressed;
            ((ColorBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_lblColorHover1) + index]).BoxColor = icon.ColorHover;
            ((CheckBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_chkReadOnly1) + index]).Checked = icon.ReadOnly;
            ((CheckBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_chkShowIcon1) + index]).Checked = icon.Visible;

            ++index;
         }

         _chkShowTitlebar.Checked = MainForm.DefaultCell.Titlebar.Visible;
         _lblTitlebarColor.BackColor = MainForm.DefaultCell.Titlebar.Color;

         if (!_chkShowTitlebar.Checked)
         {
            foreach (Control control in _tabTitlebar.Controls)
               if (!control.Equals(_chkShowTitlebar))
                  control.Enabled = false;
         }
         else
         {
            _chkCustomTitlebarColor.Checked = MainForm.DefaultCell.Titlebar.UseCustomColor;
            _lblTitlebarColor.Enabled = MainForm.DefaultCell.Titlebar.UseCustomColor;
            _btnTitlebarColor.Enabled = MainForm.DefaultCell.Titlebar.UseCustomColor;
         }
      }

      private void _chkModifyRowsColumns_CheckedChanged(object sender, EventArgs e)
      {
         _txtRows.Enabled = _chkModifyRowsColumns.Checked;
         _lblRows.Enabled = _chkModifyRowsColumns.Checked;
         _txtColumns.Enabled = _chkModifyRowsColumns.Checked;
         _lblColumns.Enabled = _chkModifyRowsColumns.Checked;
         if (_chkModifyRowsColumns.Checked)
            _txtRows.Focus();
      }

      private void applyButton_Click(object sender, EventArgs e)
      {
         int index = 0;
         int checkShowindex = _tabTitlebar.Controls.IndexOf(_chkShowIcon1);
         int colorIndex = _tabTitlebar.Controls.IndexOf(_lblColor1);
         int colorHoverIndex = _tabTitlebar.Controls.IndexOf(_lblColorHover1);
         int colorPressedIndex = _tabTitlebar.Controls.IndexOf(_lblColorPressed1);
         int checkReadOnlyIndex = _tabTitlebar.Controls.IndexOf(_chkReadOnly1);
         MedicalViewer viewer = ((MainForm)this.Owner).Viewer;
         MedicalViewerIcon icon;
         MedicalViewerCell defaultCell = MainForm.DefaultCell;

         if (viewer.BackColor != _lblEmptyCellBackColor.BackColor)
            viewer.BackColor = _lblEmptyCellBackColor.BackColor;

         if (_chkCustomSplitterColor.Checked)
         {
            if (viewer.SplitterColor != _lblSplitterColor.BoxColor)
               viewer.SplitterColor = _lblSplitterColor.BackColor;
         }

         if (viewer.CustomSplitterColor != _chkCustomSplitterColor.Checked)
            viewer.CustomSplitterColor = _chkCustomSplitterColor.Checked;


         if (_chkModifyRowsColumns.Checked)
         {
            if (viewer.Rows != _txtRows.Value)
               viewer.Rows = _txtRows.Value;

            if (viewer.Columns != _txtColumns.Value)
               viewer.Columns = _txtColumns.Value;
         }

         if (viewer.SplitterStyle != (MedicalViewerSplitterStyle)_cmbSplitterType.SelectedIndex)
            viewer.SplitterStyle = (MedicalViewerSplitterStyle)_cmbSplitterType.SelectedIndex;

         if (viewer.UseExtraSplitters != _chkUseExtraSplitters.Checked)
            viewer.UseExtraSplitters = _chkUseExtraSplitters.Checked;

         if (viewer.CellMaintenance != _chkMaintainSize.Checked)
            viewer.CellMaintenance = _chkMaintainSize.Checked;


         for (index = 0; index < (MainForm.DefaultCell.Titlebar.Icons.Length); index++)
         {
            icon = defaultCell.Titlebar.Icons[index];

            if (icon.Visible != ((CheckBox)_tabTitlebar.Controls[checkShowindex + index]).Checked)
               icon.Visible = ((CheckBox)_tabTitlebar.Controls[checkShowindex + index]).Checked;

            if (icon.Color != ((ColorBox)_tabTitlebar.Controls[colorIndex + index]).BoxColor)
               icon.Color = ((ColorBox)_tabTitlebar.Controls[colorIndex + index]).BoxColor;

            if (icon.ColorPressed != ((ColorBox)_tabTitlebar.Controls[colorPressedIndex + index]).BoxColor)
               icon.ColorPressed = ((ColorBox)_tabTitlebar.Controls[colorPressedIndex + index]).BoxColor;

            if (icon.ColorHover != ((ColorBox)_tabTitlebar.Controls[colorHoverIndex + index]).BoxColor)
               icon.ColorHover = ((ColorBox)_tabTitlebar.Controls[colorHoverIndex + index]).BoxColor;

            if (icon.ReadOnly != ((CheckBox)_tabTitlebar.Controls[checkReadOnlyIndex + index]).Checked)
               icon.ReadOnly = ((CheckBox)_tabTitlebar.Controls[checkReadOnlyIndex + index]).Checked;
         }

         if (viewer.AutoScroll != _chkShowViewerScroll.Checked)
            viewer.AutoScroll = _chkShowViewerScroll.Checked;

         if (defaultCell.CellBackColor != _lblBackgroundColor.BoxColor)
            defaultCell.CellBackColor = _lblBackgroundColor.BackColor;

         if (defaultCell.TextColor != _lblText.BoxColor)
            defaultCell.TextColor = _lblText.BackColor;

         if (defaultCell.TextShadowColor != _lblShadowColor.BoxColor)
            defaultCell.TextShadowColor = _lblShadowColor.BackColor;

         if (defaultCell.ActiveBorderColor != _lblActiveBorderColor.BoxColor)
            defaultCell.ActiveBorderColor = _lblActiveBorderColor.BackColor;

         if (defaultCell.NonActiveBorderColor != _lblNonActiveBorderColor.BoxColor)
            defaultCell.NonActiveBorderColor = _lblNonActiveBorderColor.BackColor;

         if (defaultCell.ActiveSubCellBorderColor != _lblActiveSubcellColor.BoxColor)
            defaultCell.ActiveSubCellBorderColor = _lblActiveSubcellColor.BackColor;

         if (defaultCell.RulerInColor != _lblRulerInColor.BoxColor)
            defaultCell.RulerInColor = _lblRulerInColor.BackColor;

         if (defaultCell.RulerOutColor != _lblRulerOutColor.BoxColor)
            defaultCell.RulerOutColor = _lblRulerOutColor.BackColor;

         if (defaultCell.Titlebar.UseCustomColor != _chkCustomTitlebarColor.Checked)
            defaultCell.Titlebar.UseCustomColor = _chkCustomTitlebarColor.Checked;

         if (defaultCell.Titlebar.Color != _lblTitlebarColor.BoxColor)
            defaultCell.Titlebar.Color = _lblTitlebarColor.BackColor;

         if (defaultCell.Titlebar.Visible != _chkShowTitlebar.Checked)
            defaultCell.Titlebar.Visible = _chkShowTitlebar.Checked;

         if (defaultCell.TextQuality != (MedicalViewerTextQuality)_cmbTextQuality.SelectedIndex)
            defaultCell.TextQuality = (MedicalViewerTextQuality)_cmbTextQuality.SelectedIndex;

         if (defaultCell.RulerStyle != (MedicalViewerRulerStyle)_cmbRuler.SelectedIndex)
            defaultCell.RulerStyle = (MedicalViewerRulerStyle)_cmbRuler.SelectedIndex;

         if (defaultCell.ShowCellScroll != _chkShowCellScroll.Checked)
            defaultCell.ShowCellScroll = _chkShowCellScroll.Checked;

         if (defaultCell.ShowFreezeText != _chkShowFreeze.Checked)
            defaultCell.ShowFreezeText = _chkShowFreeze.Checked;

         if (defaultCell.PaintingMethod != (MedicalViewerPaintingMethod)_cmbPaintMethod.SelectedIndex)
            defaultCell.PaintingMethod = (MedicalViewerPaintingMethod)_cmbPaintMethod.SelectedIndex;

         if (defaultCell.MeasurementUnit != (MedicalViewerMeasurementUnit)_cmbMeasurmentUnit.SelectedIndex)
            defaultCell.MeasurementUnit = (MedicalViewerMeasurementUnit)_cmbMeasurmentUnit.SelectedIndex;

         if (defaultCell.BorderStyle != (MedicalViewerBorderStyle)_cmbBorderStyle.SelectedIndex)
            defaultCell.BorderStyle = (MedicalViewerBorderStyle)_cmbBorderStyle.SelectedIndex;


         if (!_btnVerticalCursor.ButtonCursor.Equals(viewer.ResizeVerticalCursor))
         {
            viewer.ResizeVerticalCursor = _btnVerticalCursor.ButtonCursor;
         }

         if (!_btnBothCursor.ButtonCursor.Equals(viewer.ResizeBoth))
         {
            viewer.ResizeBoth = _btnBothCursor.ButtonCursor;
         }

         if (!_btnHorizontalCursor.ButtonCursor.Equals(viewer.ResizeHorizontalCursor))
         {
            viewer.ResizeHorizontalCursor = _btnHorizontalCursor.ButtonCursor;
         }

         if (!_btnDefaultCursor.ButtonCursor.Equals(defaultCell.Cursor))
         {
            defaultCell.Cursor = _btnDefaultCursor.ButtonCursor;
         }

         if (!_btnDefaultCursor.ButtonCursor.Equals(viewer.Cursor))
         {
            viewer.Cursor = _btnDefaultCursor.ButtonCursor;
         }

         foreach (MedicalViewerCell cell in viewer.Cells)
         {
            ((MainForm)Owner).ApplyToCell(cell);
         }
      }

      private void okButton_Click(object sender, EventArgs e)
      {
         applyButton_Click(sender, e);
         this.Close();
      }



      private void resetButton_Click(object sender, EventArgs e)
      {
         MedicalViewer viewer = ((MainForm)this.Owner).Viewer;
         MedicalViewerCell defaultCell = MainForm.DefaultCell;

         _txtRows.Text = viewer.Rows.ToString();
         _txtColumns.Text = viewer.Columns.ToString();
         _cmbSplitterType.SelectedIndex = (int)(viewer.SplitterStyle);
         _chkShowViewerScroll.Checked = viewer.AutoScroll;

         _cmbRuler.SelectedIndex = (int)(defaultCell.RulerStyle);
         _cmbPaintMethod.SelectedIndex = (int)(defaultCell.PaintingMethod);
         _cmbTextQuality.SelectedIndex = (int)(defaultCell.TextQuality);
         _cmbBorderStyle.SelectedIndex = (int)(defaultCell.BorderStyle);
         _cmbMeasurmentUnit.SelectedIndex = (int)(defaultCell.MeasurementUnit);
         _chkShowCellScroll.Checked = defaultCell.ShowCellScroll;
         _chkShowFreeze.Checked = defaultCell.ShowFreezeText;
         _lblText.BoxColor = defaultCell.TextColor;
         _lblShadowColor.BoxColor = defaultCell.TextShadowColor;
         _lblActiveBorderColor.BoxColor = defaultCell.ActiveBorderColor;
         _lblNonActiveBorderColor.BoxColor = defaultCell.NonActiveBorderColor;
         _lblRulerInColor.BoxColor = defaultCell.RulerInColor;
         _lblRulerOutColor.BoxColor = defaultCell.RulerOutColor;
         _lblBackgroundColor.BoxColor = defaultCell.CellBackColor;
         _lblActiveSubcellColor.BoxColor = defaultCell.ActiveSubCellBorderColor;
         _btnHorizontalCursor.ButtonCursor = viewer.ResizeHorizontalCursor;

         int index = 0;
         foreach (MedicalViewerIcon icon in defaultCell.Titlebar.Icons)
         {
            ((ColorBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_lblColor1) + index]).BoxColor = icon.Color;
            ((ColorBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_lblColorPressed1) + index]).BoxColor = icon.ColorPressed;
            ((ColorBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_lblColorHover1) + index]).BoxColor = icon.ColorHover;
            ((CheckBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_chkReadOnly1) + index]).Checked = icon.ReadOnly;
            ((CheckBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_chkShowIcon1) + index]).Checked = icon.Visible;

            ++index;
         }

         _chkShowTitlebar.Checked = defaultCell.Titlebar.Visible;
         _lblTitlebarColor.BackColor = defaultCell.Titlebar.Color;


         _chkMaintainSize.Checked = viewer.CellMaintenance;
         _chkUseExtraSplitters.Checked = viewer.UseExtraSplitters;
         _chkCustomSplitterColor.Checked = viewer.CustomSplitterColor;
         _lblEmptyCellBackColor.BoxColor = viewer.BackColor;
         _lblSplitterColor.BoxColor = viewer.SplitterColor;
         _lblSplitterColor.Enabled = _chkCustomSplitterColor.Checked;

         _btnVerticalCursor.ButtonCursor = viewer.ResizeVerticalCursor;
         _btnBothCursor.ButtonCursor = viewer.ResizeBoth;
         _btnDefaultCursor.ButtonCursor = viewer.Cursor;


         if (!_chkShowTitlebar.Checked)
         {
            foreach (Control control in _tabTitlebar.Controls)
               if (!control.Equals(_chkShowTitlebar))
                  control.Enabled = false;
         }
         else
         {
            _chkCustomTitlebarColor.Checked = defaultCell.Titlebar.UseCustomColor;
            _lblTitlebarColor.Enabled = defaultCell.Titlebar.UseCustomColor;
            _btnTitlebarColor.Enabled = defaultCell.Titlebar.UseCustomColor;
         }

         foreach (MedicalViewerCell cell in viewer.Cells)
         {
            ((MainForm)Owner).ApplyToCell(cell);
         }
      }

      private void _chkShowIcon_CheckedChanged(object sender, EventArgs e)
      {
         int index = _tabTitlebar.Controls.IndexOf((Control)sender) - _tabTitlebar.Controls.IndexOf(_chkShowIcon1);
         bool CheckBoxChecked = ((CheckBox)sender).Checked;

         ((ColorBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_lblColor1) + index]).Enabled = CheckBoxChecked;
         ((ColorBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_lblColorPressed1) + index]).Enabled = CheckBoxChecked;
         ((ColorBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_lblColorHover1) + index]).Enabled = CheckBoxChecked;
         ((CheckBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_chkReadOnly1) + index]).Enabled = CheckBoxChecked;
      }

      private void _chkShowTitlebar_CheckedChanged(object sender, EventArgs e)
      {
         if (!_chkShowTitlebar.Checked)
         {
            foreach (Control control in _tabTitlebar.Controls)
            {
               if (!control.Equals(_chkShowTitlebar))
                  control.Enabled = false;
            }
         }
         else
         {
            int index;

            for (index = 0; index < 8; index++)
            {
               bool iconEnabled = ((CheckBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_chkShowIcon1) + index]).Checked;

               ((CheckBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_chkShowIcon1) + index]).Enabled = true;
               ((ColorBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_lblColor1) + index]).Enabled = iconEnabled;
               ((ColorBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_lblColorPressed1) + index]).Enabled = iconEnabled;
               ((ColorBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_lblColorHover1) + index]).Enabled = iconEnabled;
               ((CheckBox)_tabTitlebar.Controls[_tabTitlebar.Controls.IndexOf(_chkReadOnly1) + index]).Enabled = iconEnabled;
            }

            _chkCustomTitlebarColor.Enabled = true;

            if (_chkCustomTitlebarColor.Checked)
            {
               _btnTitlebarColor.Enabled = _chkCustomTitlebarColor.Checked;
               _lblTitlebarColor.Enabled = _chkCustomTitlebarColor.Checked;
            }
         }
      }

      private void _chkCustomTitlebarColor_CheckedChanged(object sender, EventArgs e)
      {
         _btnTitlebarColor.Enabled = _chkCustomTitlebarColor.Checked;
         _lblTitlebarColor.Enabled = _chkCustomTitlebarColor.Checked;
      }

      private void _btnSplitterColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblSplitterColor);
      }

      private void _btnEmptyCellBackColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblEmptyCellBackColor);
      }

      private void _btnText_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblText);
      }

      private void _btnShadowColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblShadowColor);
      }

      private void _btnActiveBorderColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblActiveBorderColor);
      }

      private void _btnActiveSubcellColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblActiveSubcellColor);
      }

      private void _btnBackgroundColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblBackgroundColor);
      }

      private void _btnRulerInColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblRulerInColor);
      }

      private void _btnRulerOutColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblRulerOutColor);
      }

      private void _btnNonActiveBorderColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblNonActiveBorderColor);
      }

      private void _btnTitlebarColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblTitlebarColor);
      }

      private void _chkCustomSplitterColor_CheckedChanged(object sender, EventArgs e)
      {
         _btnSplitterColor.Enabled = _chkCustomSplitterColor.Checked;
         _lblSplitterColor.Enabled = _chkCustomSplitterColor.Checked;
      }
   }
}
