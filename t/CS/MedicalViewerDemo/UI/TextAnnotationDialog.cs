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
   public partial class TextAnnotationDialog : Form
   {
      MedicalViewerAnnotationText _textAnnotation;
      MedicalViewerCell _cell;
      MedicalViewer _viewer;

      public TextAnnotationDialog(MainForm owner)
      {
         InitializeComponent();

         _cell = MainForm.DefaultCell;
         _viewer = owner.Viewer;

         if (_viewer.Cells.Count ==  0)
            _textAnnotation = (MedicalViewerAnnotationText)(_cell.GetActionProperties(MedicalViewerActionType.AnnotationText));
         else
            _textAnnotation = (MedicalViewerAnnotationText)(_viewer.Cells[0].GetActionProperties(MedicalViewerActionType.AnnotationText));

         _lblColor.BackColor = Color.FromArgb(0xff, _textAnnotation.AnnotationColor);
         _textAnnotation.TextColor = Color.FromArgb(0xff, _textAnnotation.TextColor);
         _cmbApplyTo.SelectedIndex = (int)_textAnnotation.Flags;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         this.Close();
         _btnApply_Click(sender, e);
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         _textAnnotation.Flags = ((MedicalViewerAnnotationFlags)_cmbApplyTo.SelectedIndex);
         _textAnnotation.AnnotationColor = _lblColor.BackColor;
         _textAnnotation.TextColor = _lblColor.BackColor;

         _cell.SetActionProperties(MedicalViewerActionType.AnnotationText, _textAnnotation);

         foreach (MedicalViewerMultiCell viewerCell in _viewer.Cells)
         {
            viewerCell.SetActionProperties(MedicalViewerActionType.AnnotationText, _textAnnotation);
         }
      }

      private void _btnColor_Click(object sender, EventArgs e)
      {
         MainForm.ShowColorDialog(_lblColor);
      }
   }
}
