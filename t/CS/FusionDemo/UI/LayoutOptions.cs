// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

using Leadtools.MedicalViewer;

namespace FusionDemo
{
   public partial class LayoutOptions : Form
   {
      MedicalViewer _viewer;
      MainForm _form;

      public LayoutOptions()
      {
         InitializeComponent();
      }

      public LayoutOptions(MedicalViewer viewer, MainForm form)
      {
         _viewer = viewer;
         _form = form;

         InitializeComponent();

         _txtRows.Value = _viewer.Rows;
         _txtColumns.Value = _viewer.Columns;
         _interpolateAlwaysImage.Checked = _form.AlwaysInterpolate;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
          if (_viewer.Rows != _txtRows.Value)
              _viewer.Rows = _txtRows.Value;

          if (_viewer.Columns != _txtColumns.Value)
              _viewer.Columns = _txtColumns.Value;

          _form.AlwaysInterpolate = _interpolateAlwaysImage.Checked;

          int counter;
          MedicalViewerCell cell;
          for (counter = 0; counter < _viewer.Cells.Count; counter++)
          {
              if (_viewer.Cells[counter] is MedicalViewerCell)
              {
                  cell = ((MedicalViewerCell)_viewer.Cells[counter]);
                  cell.AlwaysInterpolate = _interpolateAlwaysImage.Checked;
              }
          }
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         _btnOK_Click(sender, e);
      }
   }
}
