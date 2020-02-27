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

using Leadtools.ImageProcessing.Core;

namespace GrayScaleDemo
{
   public partial class OtsuThresholdDialog : Form
   {
      private int _clusters;

      public int Clusters;
      private MainForm _mainForm;

      public OtsuThresholdDialog(MainForm form)
      {
         _mainForm = form;
         InitializeComponent();
      }

      private void OtsuThresholdDialog_Load(object sender, EventArgs e)
      {
         OtsuThresholdCommand cmd = new OtsuThresholdCommand();
         _clusters = cmd.Clusters;

         Clusters = _clusters;

         _numClusters.Value = Clusters;
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         Clusters = (int)_numClusters.Value;
         _clusters = Clusters;
         (_mainForm.ActiveMdiChild as ViewerForm).addToImageList();
         _mainForm.IsSegmentation = false;
         _mainForm.UpdateMyControls();
         (_mainForm.ActiveMdiChild as ViewerForm).UpdateAfterCommandExecution();
      }
   }
}
