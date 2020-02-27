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
   public partial class AngleAnnotationDialog : Form
   {
      MedicalViewerAnnotationAngle _angleAnnotation;
      MedicalViewerMultiCell cell = null;
      MedicalViewer viewer;

      public AngleAnnotationDialog(MainForm owner)
      {
         InitializeComponent();

         cell = MainForm.DefaultCell;
         viewer = owner.Viewer;

         _angleAnnotation = (MedicalViewerAnnotationAngle)(cell.GetActionProperties(MedicalViewerActionType.AnnotationAngle));
         _lblColor.BackColor = Color.FromArgb(0xff, _angleAnnotation.AnnotationColor);
         _cmbApplyTo.SelectedIndex = (int)_angleAnnotation.Flags;
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         _angleAnnotation.Flags = ((MedicalViewerAnnotationFlags)_cmbApplyTo.SelectedIndex);
         _angleAnnotation.AnnotationColor = _lblColor.BackColor;

         cell.SetActionProperties(MedicalViewerActionType.AnnotationAngle, _angleAnnotation);

         foreach (MedicalViewerMultiCell viewerCell in viewer.Cells)
         {
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationAngle, _angleAnnotation);
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
