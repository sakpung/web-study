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
   public partial class RulerAnnotationDialog : Form
   {
      MedicalViewerAnnotationRuler _rulerAnnotation;
      MedicalViewerMultiCell cell = null;
      MedicalViewer viewer;

      public RulerAnnotationDialog(MainForm owner)
      {
         InitializeComponent();

         cell = MainForm.DefaultCell;
         viewer = owner.Viewer;

         _rulerAnnotation = (MedicalViewerAnnotationRuler)(cell.GetActionProperties(MedicalViewerActionType.AnnotationRuler));
         _lblColor.BackColor = Color.FromArgb(0xff, _rulerAnnotation.AnnotationColor);
         _cmbApplyTo.SelectedIndex = (int)_rulerAnnotation.Flags;
         _chkSimpleRuler.Checked = _rulerAnnotation.SimpleRuler;
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         _rulerAnnotation.Flags = ((MedicalViewerAnnotationFlags)_cmbApplyTo.SelectedIndex);
         _rulerAnnotation.SimpleRuler = _chkSimpleRuler.Checked;
         _rulerAnnotation.AnnotationColor = _lblColor.BackColor;

         cell.SetActionProperties(MedicalViewerActionType.AnnotationRuler, _rulerAnnotation);

         foreach (MedicalViewerMultiCell viewerCell in viewer.Cells)
         {
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationRuler, _rulerAnnotation);
         }
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         _btnApply_Click(sender, e);
         this.Close();
      }

      private void _btnColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblColor);
      }
   }
}
