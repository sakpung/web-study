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

namespace DocumentWritersDemo
{
   public partial class NewDocumentDialogBox : Form
   {
      // The document width in inches
      private float _documentWidth;
      // The document height in inches
      private float _documentHeight;
      // The document resolution in DPI
      private int _documentResolution;

      public NewDocumentDialogBox(float width, float height, int resolution)
      {
         InitializeComponent();

         // Set the initial variables
         _documentWidth = width;

         if(_documentWidth <= 0)
            _documentWidth = 1;

         _documentHeight = height;
         if(_documentHeight <= 0)
            _documentHeight = 1;

         _documentResolution = resolution;

         _widthNumericUpDown.Value = (decimal)_documentWidth;
         _heightNumericUpDown.Value = (decimal)_documentHeight;

         // Find the resolution
         _resolutionComboBox.SelectedItem = _documentResolution.ToString();
         if(_resolutionComboBox.SelectedIndex == -1)
            _resolutionComboBox.SelectedItem = "300";

         _documentResolution = int.Parse(_resolutionComboBox.SelectedItem.ToString());

         UpdatePhysicalSize();
      }

      public float DocumentWidth
      {
         get { return _documentWidth; }
      }

      public float DocumentHeight
      {
         get { return _documentHeight; }
      }

      public int DocumentResolution
      {
         get { return _documentResolution; }
      }

      private void UpdatePhysicalSize()
      {
         if(_resolutionComboBox.SelectedIndex != -1)
         {
            float width = (float)_widthNumericUpDown.Value;
            float height = (float)_heightNumericUpDown.Value;
            int resolution = int.Parse(_resolutionComboBox.SelectedItem.ToString());

            int widthInPixels = (int)(width * resolution);
            int heightInPixels = (int)(height * resolution);

            _physicalSizeValueLabel.Text = string.Format("{0} by {1}", widthInPixels, heightInPixels);
         }
      }

      private void _resolutionComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdatePhysicalSize();
      }

      private void _numericUpDown_ValueChanged(object sender, EventArgs e)
      {
         UpdatePhysicalSize();
      }

      private void _defaultButton_Click(object sender, EventArgs e)
      {
         _widthNumericUpDown.Value = (decimal)8.5F;
         _heightNumericUpDown.Value = 11;
         _resolutionComboBox.SelectedItem = "300";
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         _documentWidth = (float)_widthNumericUpDown.Value;
         _documentHeight = (float)_heightNumericUpDown.Value;
         _documentResolution = int.Parse(_resolutionComboBox.SelectedItem.ToString());
      }
   }
}
