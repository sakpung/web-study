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
   public partial class RepositionCellDialog : Form
   {
      public RepositionCellDialog(MainForm owner)
      {
         InitializeComponent();

         _txtCellIndex.MaximumAllowed = owner.Viewer.Cells.Count - 1;
         _txtTargetIndex.MaximumAllowed = owner.Viewer.Cells.Count - 1;
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         ((MainForm)this.Owner).Viewer.Cells.Reposition(_txtCellIndex.Value, _txtTargetIndex.Value, _chkSwap.Checked);
      }
   }
}
