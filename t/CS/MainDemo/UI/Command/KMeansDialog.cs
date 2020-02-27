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

namespace MainDemo
{
    public partial class KMeansDialog : Form
    {
        public KMeansCommandFlags Type;
        public int Clusters;

        public KMeansDialog()
        {
            InitializeComponent();
            _cbType.SelectedIndex = 0;
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
        }

    }
}
