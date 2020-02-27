// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

namespace ImageViewerDemo
{
   public partial class LoadFileDialog : Form
   {
      public LoadFileDialog()
      {
         InitializeComponent();
      }

      // File name
      public string ImageFileName { get; set; }

      // Options
      public DemoOptions DemoOptions { get; set; }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            _fileNameTextBox.Text = this.ImageFileName;
            _virtualizerUseCheckBox.Checked = this.DemoOptions.UseVirtiualizer;
            _svgUseCheckBox.Checked = this.DemoOptions.UseSVG;

            UpdateUIState();
         }

         base.OnLoad(e);
      }

      private void UpdateUIState()
      {
         // We must have a file name
         _okButton.Enabled = !string.IsNullOrEmpty(_fileNameTextBox.Text);
      }

      private void _fileNameTextBox_TextChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _fileNameBrowseButton_Click(object sender, EventArgs e)
      {
         // Browse for a file
         using (var dlg = new OpenFileDialog())
         {
            dlg.Title = "Select Image File";
            dlg.Filter = "All files|*.*";
            if (dlg.ShowDialog(this) == DialogResult.OK)
               _fileNameTextBox.Text = dlg.FileName;
         }
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         // Collect the info
         this.ImageFileName = _fileNameTextBox.Text.Trim();
         this.DemoOptions.UseVirtiualizer = _virtualizerUseCheckBox.Checked;
         this.DemoOptions.UseSVG = _svgUseCheckBox.Checked;
      }
   }
}
