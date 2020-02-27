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
   public partial class KMeansDialog : Form
   {
      private KMeansCommandFlags _type;
      private int _clusters;
      public KMeansCommandFlags Type;
      public int Clusters;

      public KMeansDialog()
      {
         InitializeComponent();
      }

      private void KMeansDialog_Load(object sender, EventArgs e)
      {
         KMeansCommand cmd = new KMeansCommand();
         _type = cmd.Type;
         _clusters = cmd.Clusters;
         _cbType.SelectedIndex = 0;

         Type = _type;
         Clusters = _clusters;

         _numClusters.Value = Clusters;
         switch (Type)
         {
            case KMeansCommandFlags.KMeans_Random:
               _cbType.SelectedIndex = 0;
               break;
            case KMeansCommandFlags.KMeans_Uniform:
               _cbType.SelectedIndex = 1;
               break;
         }
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         switch (_cbType.SelectedIndex)
         {
            case 0:
               Type = KMeansCommandFlags.KMeans_Random;
               break;
            case 1:
               Type = KMeansCommandFlags.KMeans_Uniform;
               break;
         }
         Clusters = (int)_numClusters.Value;

         _clusters = Clusters;
         _type = Type;
      }
   }
}
