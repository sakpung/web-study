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
   public partial class ArrowAnnotationDialog : Form
   {
      MedicalViewerAnnotationArrow _arrowAnnotation;
      MedicalViewerCell cell = null;
      MedicalViewer viewer;

      public ArrowAnnotationDialog(MainForm owner)
      {
         InitializeComponent();

         cell = MainForm.DefaultCell;
         viewer = owner.Viewer;

         _arrowAnnotation = (MedicalViewerAnnotationArrow)(cell.GetActionProperties(MedicalViewerActionType.AnnotationArrow));
         _lblColor.BackColor = Color.FromArgb(0xff, _arrowAnnotation.AnnotationColor);
         _cmbApplyTo.SelectedIndex = (int)_arrowAnnotation.Flags;

      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         _btnApply_Click(sender, e);
         this.Close();
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         _arrowAnnotation.Flags = ((MedicalViewerAnnotationFlags)_cmbApplyTo.SelectedIndex);
         _arrowAnnotation.AnnotationColor = _lblColor.BackColor;

         //int cellIndex = owner.SearchForFirstSelected();
         cell = MainForm.DefaultCell; //(MedicalViewerMultiCell)owner.Viewer.Cells[cellIndex];

         cell.SetActionProperties(MedicalViewerActionType.AnnotationArrow, _arrowAnnotation);

         foreach (MedicalViewerMultiCell viewerCell in viewer.Cells)
         {
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationArrow, _arrowAnnotation);
         }
      }

      private void _btnColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblColor);
      }
   }
}
