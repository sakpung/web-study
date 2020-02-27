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

using Leadtools.MedicalViewer;
using Leadtools;

namespace MedicalViewerDemo
{
   public partial class StatisticsDialog : Form
   {
      public StatisticsDialog(MainForm owner)
      {
         InitializeComponent();

         int cellIndex = owner.SearchForFirstSelected();

         MedicalViewerMultiCell cell = null;

         if (cellIndex != -1)
            cell = (MedicalViewerMultiCell)owner.Viewer.Cells[cellIndex];

         if (cell == null)
            return;

         if (cell.Image.GetRegionBounds(null).IsEmpty)
            cell.Image.MakeRegionEmpty();



         int page = cell.Image.Page;
         RasterImage image = cell.Image;
         image.Page = cell.ActiveSubCell + 1;
         
         if (cell.Image.HasRegion)
         {
            _hasRegionLbl.Text = "True";
            _hasRegionLbl.BackColor = Color.FromArgb(128, 255, 128);

            LeadRect bounds = image.GetRegionBounds(null);

            _xLbl.Text = bounds.X.ToString();
            _yLbl.Text = bounds.Y.ToString();
            _widthLbl.Text = bounds.Width.ToString();
            _heightLbl.Text = bounds.Height.ToString();

            _areaLbl.Text = image.CalculateRegionArea().ToString();
         }
         else
         {
            _hasRegionLbl.Text = "False";
            _hasRegionLbl.BackColor = Color.FromArgb(255, 128, 128);
         }

         image.Page = page;
      }

      private void okButton_Click(object sender, EventArgs e)
      {
         this.Close();
      }

   }
}
