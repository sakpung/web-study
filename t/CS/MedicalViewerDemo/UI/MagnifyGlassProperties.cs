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
   public partial class MagnifyGlassProperties : Form
   {
       private MedicalViewerCell _SelectedCell = null;
       private MedicalViewerMagnifyGlass _magnifyGlass  = null;
       //private MedicalViewerKeys _keys = null;
       private MedicalViewer _Viewer = null;

      public MagnifyGlassProperties(MainForm owner, MedicalViewerCell selectedCell)
      {
         InitializeComponent();

         _Viewer = owner.Viewer;
         _SelectedCell = selectedCell;

         if (_SelectedCell != null)
         {
             _magnifyGlass = (MedicalViewerMagnifyGlass)(_SelectedCell.GetActionProperties(MedicalViewerActionType.MagnifyGlass));
         }
         else
         {
             _magnifyGlass = (MedicalViewerMagnifyGlass)(MainForm.DefaultCell.GetActionProperties(MedicalViewerActionType.MagnifyGlass));
         }

         _chk3D.Checked = _magnifyGlass.Border3D;
         _chk3D.Enabled = !_chkElliptical.Checked;
         _chkElliptical.Checked = _magnifyGlass.Elliptical;
         _txtWidth.Value = _magnifyGlass.Width;
         _txtHeight.Value = _magnifyGlass.Height;
         _txtZoom.Value = _magnifyGlass.Zoom;
         _txtBorder.Value = _magnifyGlass.BorderSize;
         _cmbCrosshair.SelectedIndex = (int)_magnifyGlass.Crosshair;
         _lblPenColor.BackColor = Color.FromArgb(0xff, _magnifyGlass.PenColor.R, _magnifyGlass.PenColor.G, _magnifyGlass.PenColor.B);
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
         _btnApply_Click(sender, e);
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
          _magnifyGlass.Border3D = _chk3D.Checked;
          _magnifyGlass.BorderSize = _txtBorder.Value;
          _magnifyGlass.Crosshair = (MedicalViewerCrosshairStyle)_cmbCrosshair.SelectedIndex;
          _magnifyGlass.Elliptical = _chkElliptical.Checked;
          _magnifyGlass.Height = _txtHeight.Value;
          _magnifyGlass.Width = _txtWidth.Value;
          _magnifyGlass.Zoom = _txtZoom.Value;
          _magnifyGlass.PenColor = _lblPenColor.BackColor;

          MainForm.DefaultCell.SetActionProperties(MedicalViewerActionType.MagnifyGlass, _magnifyGlass);
          foreach (MedicalViewerCell cell in _Viewer.Cells)
          {
              cell.SetActionProperties(MedicalViewerActionType.MagnifyGlass, _magnifyGlass);
          }
      }

      private void _btnPenColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblPenColor);
      }

      private void _chkElliptical_CheckedChanged(object sender, EventArgs e)
      {
         _chk3D.Enabled = !_chkElliptical.Checked;
      }
   }
}
