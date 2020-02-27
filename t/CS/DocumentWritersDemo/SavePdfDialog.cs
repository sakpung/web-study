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

using Leadtools.Demos;
using Leadtools.Document.Writer;

namespace DocumentWritersDemo
{
   public partial class SavePdfDialog : Form
   {
      private string _documentFileName;
      private PdfDocumentOptions _pdfOptions;
      private int _defaultResolution;
      private int _totalPages;

      public SavePdfDialog(string documentFileName, PdfDocumentOptions pdfOptions, int defaultResolution, int totalPages)
      {
         InitializeComponent();

         _documentFileName = documentFileName;
         _pdfOptions = pdfOptions;
         _defaultResolution = defaultResolution;
         _totalPages = totalPages;
      }

      public SavePdfDialog(string documentFileName, PdfDocumentOptions pdfOptions)
      {
         InitializeComponent();

         _documentFileName = documentFileName;
         _pdfOptions = pdfOptions;
      }

      public string DocumentFileName
      {
         get { return _documentFileName; }
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            _documentFileNameTextBox.Text = _documentFileName;

            Array a = Enum.GetValues(typeof(PdfDocumentType));
            foreach (PdfDocumentType i in a)
            {
               if (i != PdfDocumentType.PdfA && i != PdfDocumentType.Pdf16)
                  _documentTypeComboBox.Items.Add(i);
            }
            _documentTypeComboBox.SelectedItem = _pdfOptions.DocumentType;
            _resolutionComboBox.SelectedIndex = 0;
            _resolutionNumericUpDown.Value = _defaultResolution;
            _resolutionNumericUpDown.Enabled = false;

            UpdateUIState();
         }

         base.OnLoad(e);
      }

      private void _documentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _protectedCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _encryptionModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _browseDocumentFileNameButton_Click(object sender, EventArgs e)
      {
         using (SaveFileDialog dlg = new SaveFileDialog())
         {
            dlg.Filter = "PDF Files (*.pdf)|*.pdf";
            dlg.DefaultExt = "pdf";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _documentFileNameTextBox.Text = dlg.FileName;
            }
         }
      }

      private void UpdateUIState()
      {
         this.SuspendLayout();

         this.ResumeLayout();
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         string documentFileName = _documentFileNameTextBox.Text.Trim();
         if (string.IsNullOrEmpty(documentFileName))
         {
            Messager.ShowWarning(this, "Enter the PDF document output file name or click the browse button.");
            _documentFileNameTextBox.Focus();
            DialogResult = DialogResult.None;
            return;
         }

         _documentFileName = documentFileName;

         _pdfOptions.DocumentType = (PdfDocumentType)_documentTypeComboBox.SelectedItem;
         _pdfOptions.ImageOverText = false;  // We will not support image/text in this demo
         _pdfOptions.DocumentResolution = _resolutionComboBox.SelectedIndex == 0 ? _defaultResolution : Convert.ToInt32(_resolutionNumericUpDown.Value);
      }

      private void _printEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _editEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }


      private void _resolutionComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         _resolutionNumericUpDown.Enabled = _resolutionComboBox.SelectedIndex == 1;
      }


      private void _pdfAdvancedOptionsButton_Click(object sender, EventArgs e)
      {
         Properties.Settings settings = new Properties.Settings();
         int tabIndex = settings.AdvancedPdfOptionsSelectedTabIndex;

         using (AdvancedPdfDocumentOptionsDialog dlg = new AdvancedPdfDocumentOptionsDialog(_pdfOptions, _totalPages, tabIndex))
         {
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               settings.AdvancedPdfOptionsSelectedTabIndex = dlg.TabControl.SelectedIndex;
               settings.Save();
            }
         }
      }
   }
}
