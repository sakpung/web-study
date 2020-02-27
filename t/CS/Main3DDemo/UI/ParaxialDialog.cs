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

using Leadtools.Medical3D;
using Leadtools.MedicalViewer;

namespace Main3DDemo
{
   public partial class ParaxialDialog : Form
   {
      private int oldLengthValue = 0;
      private int oldDistanceValue = 0;
      MedicalViewerParaxialCutCell _cell;


      public ParaxialDialog(MedicalViewerParaxialCutCell cell)
      {
         InitializeComponent();

         _cell = cell;

         oldLengthValue = (int)_cell.ParaxialLength;
         oldDistanceValue = (int)_cell.ParaxialDistance;
         _textBoxLength.Value = oldLengthValue;
         _textBoxDistance.Value = oldDistanceValue;
      }

      private void _btnReset_Click(object sender, EventArgs e)
      {
         _textBoxLength.Value = oldLengthValue;
         _textBoxDistance.Value = oldDistanceValue;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         _cell.BeginUpdate();
         _cell.ParaxialLength = (float)_textBoxLength.Value;
         _cell.ParaxialDistance = (float)_textBoxDistance.Value;
         _cell.EndUpdate();
      }
   }
}
