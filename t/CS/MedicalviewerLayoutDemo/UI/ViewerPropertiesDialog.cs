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
   public partial class ViewerPropertiesDialog : Form
   {
      MedicalViewerMultiCell _cell;

      public ViewerPropertiesDialog(MainForm owner, MedicalViewerMultiCell cell)
      {
          InitializeComponent();
          MainForm _mainForm = (MainForm)owner;
          _cell = cell;

          _cmbRuler.SelectedIndex = (int)(_cell.RulerStyle);
          _cmbPaintMethod.SelectedIndex = (int)(_cell.PaintingMethod);
          _cmbTextQuality.SelectedIndex = (int)(_cell.TextQuality);
          _cmbBorderStyle.SelectedIndex = (int)(_cell.BorderStyle);
          _cmbMeasurmentUnit.SelectedIndex = (int)(_cell.MeasurementUnit);
          _chkShowCellScroll.Checked = _cell.ShowCellScroll;
          _chkMaintainSize.Checked = _mainForm.Viewer.CellMaintenance;
          _chkShowFreeze.Checked = _cell.ShowFreezeText;

          _lblBackgroundColor.BoxColor = _cell.CellBackColor;
          _lblText.BoxColor = _cell.TextColor;
          _lblShadowColor.BoxColor = _cell.TextShadowColor;
          _lblActiveBorderColor.BoxColor = _cell.ActiveBorderColor;
          _lblNonActiveBorderColor.BoxColor = _cell.NonActiveBorderColor;
          _lblRulerInColor.BoxColor = _cell.RulerInColor;
          _lblRulerOutColor.BoxColor = _cell.RulerOutColor;          
          _lblActiveSubcellColor.BoxColor = _cell.ActiveSubCellBorderColor;
         _labelDesignForeColor.BoxColor = _mainForm.Viewer.LayoutOptions.RectForeColor;
         _labelDesignBackColor.BoxColor = _mainForm.Viewer.LayoutOptions.RectBackColor;

      }

      private void _chkModifyRowsColumns_CheckedChanged(object sender, EventArgs e)
      {

      }

      private void applyButton_Click(object sender, EventArgs e)
      {
         MedicalViewer viewer = ((MainForm)this.Owner).Viewer;

         //if (viewer.BackColor != _lblBackgroundColor.BackColor)
         //    viewer.BackColor = _lblBackgroundColor.BackColor;

         if (viewer.CellMaintenance != _chkMaintainSize.Checked)
            viewer.CellMaintenance = _chkMaintainSize.Checked;

         if (viewer.LayoutOptions.RectForeColor != _labelDesignForeColor.BoxColor)
            viewer.LayoutOptions.RectForeColor = _labelDesignForeColor.BoxColor;

         if (viewer.LayoutOptions.RectBackColor != _labelDesignBackColor.BoxColor)
            viewer.LayoutOptions.RectBackColor = _labelDesignBackColor.BoxColor;

         ApplyCellProperties(_cell);

         foreach (MedicalViewerMultiCell cell in ((MainForm)this.Owner).Viewer.Cells)
         {
            ApplyCellProperties(cell);
         }
      }

      private void ApplyCellProperties(MedicalViewerMultiCell cell)
      {
         MedicalViewer viewer = ((MainForm)this.Owner).Viewer;

         if (cell.CellBackColor != _lblBackgroundColor.BoxColor)
             cell.CellBackColor = _lblBackgroundColor.BoxColor;

         if (cell.TextColor != _lblText.BoxColor)
            cell.TextColor = _lblText.BackColor;

         if (cell.TextShadowColor != _lblShadowColor.BoxColor)
            cell.TextShadowColor = _lblShadowColor.BackColor;

         if (cell.ActiveBorderColor != _lblActiveBorderColor.BoxColor)
            cell.ActiveBorderColor = _lblActiveBorderColor.BackColor;

         if (cell.NonActiveBorderColor != _lblNonActiveBorderColor.BoxColor)
            cell.NonActiveBorderColor = _lblNonActiveBorderColor.BackColor;

         if (cell.ActiveSubCellBorderColor != _lblActiveSubcellColor.BoxColor)
            cell.ActiveSubCellBorderColor = _lblActiveSubcellColor.BackColor;

         if (cell.RulerInColor != _lblRulerInColor.BoxColor)
            cell.RulerInColor = _lblRulerInColor.BackColor;

         if (cell.RulerOutColor != _lblRulerOutColor.BoxColor)
            cell.RulerOutColor = _lblRulerOutColor.BackColor;

         if (cell.TextQuality != (MedicalViewerTextQuality)_cmbTextQuality.SelectedIndex)
            cell.TextQuality = (MedicalViewerTextQuality)_cmbTextQuality.SelectedIndex;

         if (cell.RulerStyle != (MedicalViewerRulerStyle)_cmbRuler.SelectedIndex)
            cell.RulerStyle = (MedicalViewerRulerStyle)_cmbRuler.SelectedIndex;

         if (cell.ShowCellScroll != _chkShowCellScroll.Checked)
            cell.ShowCellScroll = _chkShowCellScroll.Checked;

         if (cell.ShowFreezeText != _chkShowFreeze.Checked)
            cell.ShowFreezeText = _chkShowFreeze.Checked;

         if (cell.PaintingMethod != (MedicalViewerPaintingMethod)_cmbPaintMethod.SelectedIndex)
            cell.PaintingMethod = (MedicalViewerPaintingMethod)_cmbPaintMethod.SelectedIndex;

         if (cell.MeasurementUnit != (MedicalViewerMeasurementUnit)_cmbMeasurmentUnit.SelectedIndex)
            cell.MeasurementUnit = (MedicalViewerMeasurementUnit)_cmbMeasurmentUnit.SelectedIndex;

         if (cell.BorderStyle != (MedicalViewerBorderStyle)_cmbBorderStyle.SelectedIndex)
            cell.BorderStyle = (MedicalViewerBorderStyle)_cmbBorderStyle.SelectedIndex;          
      }

      private void okButton_Click(object sender, EventArgs e)
      {
         applyButton_Click(sender, e);
         this.Close();
      }

      private void resetButton_Click(object sender, EventArgs e)
      {
         MedicalViewer viewer = ((MainForm)this.Owner).Viewer;

         _cmbRuler.SelectedIndex = (int)(_cell.RulerStyle);
         _cmbPaintMethod.SelectedIndex = (int)(_cell.PaintingMethod);
         _cmbTextQuality.SelectedIndex = (int)(_cell.TextQuality);
         _cmbBorderStyle.SelectedIndex = (int)(_cell.BorderStyle);
         _cmbMeasurmentUnit.SelectedIndex = (int)(_cell.MeasurementUnit);
         _chkShowCellScroll.Checked = _cell.ShowCellScroll;
         _chkMaintainSize.Checked = viewer.CellMaintenance;
         _chkShowFreeze.Checked = _cell.ShowFreezeText;

         //_lblEmptyCellBackColor.BoxColor = viewer.BackColor;
         _lblBackgroundColor.BoxColor = _cell.CellBackColor;
         _lblText.BoxColor = _cell.TextColor;
         _lblShadowColor.BoxColor = _cell.TextShadowColor;
         _lblActiveBorderColor.BoxColor = _cell.ActiveBorderColor;
         _lblNonActiveBorderColor.BoxColor = _cell.NonActiveBorderColor;
         _lblRulerInColor.BoxColor = _cell.RulerInColor;
         _lblRulerOutColor.BoxColor = _cell.RulerOutColor;
         _lblBackgroundColor.BoxColor = viewer.BackColor;
         _lblActiveSubcellColor.BoxColor = _cell.ActiveSubCellBorderColor;

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

       private void _btnDesignForeColor_Click(object sender, EventArgs e)
       {
           MainForm.ShowColorDialog(_labelDesignForeColor);
       }

       private void _btnDesignBackColor_Click(object sender, EventArgs e)
       {
           MainForm.ShowColorDialog(_labelDesignBackColor);
       }      
   }
}
