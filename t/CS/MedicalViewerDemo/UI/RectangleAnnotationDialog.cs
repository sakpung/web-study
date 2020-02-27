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
   public partial class RectangleAnnotationDialog : Form
   {
      MedicalViewerAnnotationRectangle _rectangleAnnotation;
      MedicalViewerCell cell = null;
      MedicalViewer viewer;

      public RectangleAnnotationDialog(MainForm owner)
      {
         InitializeComponent();

         cell = MainForm.DefaultCell;
         viewer = owner.Viewer;

         _cmbApplyTo.SelectedIndex = 0;
         _rectangleAnnotation = (MedicalViewerAnnotationRectangle)(cell.GetActionProperties(MedicalViewerActionType.AnnotationRectangle));
         _lblColor.BackColor = Color.FromArgb(0xff, _rectangleAnnotation.AnnotationColor);
         _radCenter.Checked = _rectangleAnnotation.CreateFromCenter;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         _btnApply_Click(sender, e);
         this.Close();
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         _rectangleAnnotation.Flags = ((MedicalViewerAnnotationFlags)_cmbApplyTo.SelectedIndex);
         _rectangleAnnotation.CreateFromCenter = _radCenter.Checked;         
         _rectangleAnnotation.AnnotationColor = _lblColor.BackColor;         

         cell.SetActionProperties(MedicalViewerActionType.AnnotationRectangle, _rectangleAnnotation);

         foreach (MedicalViewerMultiCell viewerCell in viewer.Cells)
         {
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationRectangle, _rectangleAnnotation);
         }
      }

      private void _btnColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblColor);
      }
   }
}
