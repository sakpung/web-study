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
using Leadtools.Ocr;

namespace OcrDemo
{
   public partial class CreateOcrDocumentDialog : Form
   {
      private OcrCreateDocumentOptions _createOcrDocumentOptions;

      public CreateOcrDocumentDialog(string ocrDocumentFilePath)
      {
         InitializeComponent();

         _createOcrDocumentOptions = OcrCreateDocumentOptions.AutoDeleteFile;
         if (!string.IsNullOrEmpty(ocrDocumentFilePath))
            _tbOcrDocumentFile.Text = ocrDocumentFilePath;
      }

      private void CreateOcrDocumentDialog_Load(object sender, EventArgs e)
      {
         _cmbDocumentMode.Focus();
         _cmbDocumentMode.SelectedIndex = 0;
      }

      public OcrCreateDocumentOptions OcrDocumentOptions
      {
         get { return _createOcrDocumentOptions; }
      }

      public string OcrDocumentFilePath
      {
         get { return _tbOcrDocumentFile.Text; }
      }

      private void _cmbDocumentMode_SelectedIndexChanged(object sender, EventArgs e)
      {
         switch(_cmbDocumentMode.SelectedIndex)
         {
            case 0:  // File
               _createOcrDocumentOptions = (_tbOcrDocumentFile.Text.Length > 0) ? OcrCreateDocumentOptions.None : OcrCreateDocumentOptions.AutoDeleteFile;
               _lblHints.Text = "In OCR document file mode you can only handle one page at a time, " +
                                "so you can load one page, OCR it and then add it to the document, then " +
                                "you can repeat the steps for other pages of your source document(s).\n\n" +
                                "This is the RECOMMENDED mode to use when dealing with wide number of pages " +
                                "since it saves your system memory and keeps the work on disk.";
               break;

            case 1:  // Memory
               _createOcrDocumentOptions = OcrCreateDocumentOptions.InMemory;
               _lblHints.Text = "OCR document memory mode is ONLY recommended when dealing with a few number " + 
                                "of pages since each loaded page will remain in memory which will consume your " + 
                                "system memory.\n\n" + 
                                "Multi-page support is enabled when using this mode, you don't have to OCR the pages " + 
                                "before adding them to the OCR document while using the memory mode, you can do that even " +
                                "after adding the pages to the document.";
               break;
         }

         UpdateUIState();
      }

      void UpdateUIState()
      {
         _lblOcrDocumentFile.Visible = _cmbDocumentMode.SelectedIndex == 0;
         _tbOcrDocumentFile.Visible = _cmbDocumentMode.SelectedIndex == 0;
         _btnBrowse.Visible = _cmbDocumentMode.SelectedIndex == 0;
      }

      private void _btnBrowse_Click(object sender, EventArgs e)
      {
         using (SaveFileDialog dlg = new SaveFileDialog())
         {
            string extension = "ltd";
            string friendlyName = "LEAD Temporary Document";
            dlg.Filter = string.Format("{0} (*.{1})|*.{1}|All Files (*.*)|*.*", friendlyName, extension);
            dlg.DefaultExt = extension;
            dlg.Title = "Select path to save LEAD Temporary Document (LTD)";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _tbOcrDocumentFile.Text = dlg.FileName;
            }
         }
      }
   }
}
