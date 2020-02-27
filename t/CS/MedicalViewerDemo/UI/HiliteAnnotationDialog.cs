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
   public partial class HiliteAnnotationDialog : Form
   {
      MedicalViewerAnnotationHilite _hiliteAnnotation;
      MedicalViewerCell cell = null;
      MedicalViewer viewer;

      public HiliteAnnotationDialog(MainForm owner)
      {
         InitializeComponent();

         cell = MainForm.DefaultCell;
         viewer = owner.Viewer;

         _cmbApplyTo.SelectedIndex = 0;
         _hiliteAnnotation = (MedicalViewerAnnotationHilite)(cell.GetActionProperties(MedicalViewerActionType.AnnotationHilite));
         _lblColor.BackColor = Color.FromArgb(0xff, _hiliteAnnotation.AnnotationColor);
         _radCenter.Checked = _hiliteAnnotation.CreateFromCenter;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         _btnApply_Click(sender, e);
         this.Close();
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         _hiliteAnnotation.Flags = ((MedicalViewerAnnotationFlags)_cmbApplyTo.SelectedIndex);
         _hiliteAnnotation.CreateFromCenter = _radCenter.Checked;
         _hiliteAnnotation.AnnotationColor = _lblColor.BackColor;

         cell.SetActionProperties(MedicalViewerActionType.AnnotationHilite, _hiliteAnnotation);

         foreach (MedicalViewerMultiCell viewerCell in viewer.Cells)
         {
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationHilite, _hiliteAnnotation);
         }
      }

      private void _btnColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblColor);
      }
   }
}
