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
   public partial class EllipseAnnotationDialog : Form
   {
      MedicalViewerAnnotationEllipse _ellipseAnnotation;

      MedicalViewerMultiCell cell = null;
      MedicalViewer viewer;

      public EllipseAnnotationDialog(MainForm owner)
      {
         InitializeComponent();
         int cellIndex = owner.SearchForFirstSelected();
         cell = MainForm.DefaultCell; //(MedicalViewerMultiCell)owner.Viewer.Cells[cellIndex];
         viewer = owner.Viewer;

         _cmbApplyTo.SelectedIndex = 0;
         _ellipseAnnotation = (MedicalViewerAnnotationEllipse)(cell.GetActionProperties(MedicalViewerActionType.AnnotationEllipse));
         _lblColor.BackColor = Color.FromArgb(0xff, _ellipseAnnotation.AnnotationColor);
         _radCenter.Checked = _ellipseAnnotation.CreateFromCenter;
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         _ellipseAnnotation.Flags = ((MedicalViewerAnnotationFlags)_cmbApplyTo.SelectedIndex);
         _ellipseAnnotation.CreateFromCenter = _radCenter.Checked;
         _ellipseAnnotation.AnnotationColor = _lblColor.BackColor;

         cell.SetActionProperties(MedicalViewerActionType.AnnotationEllipse, _ellipseAnnotation);

         foreach (MedicalViewerMultiCell viewerCell in viewer.Cells)
         {
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationEllipse, _ellipseAnnotation);
         }

      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
         _btnApply_Click(sender, e);
      }

      private void _btnColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblColor);
      }
   }
}
