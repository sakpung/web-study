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
using System.Threading;

using Leadtools.Demos;
using Leadtools.Pdf;

namespace PDFDocumentDemo.LoadDocument
{
   public partial class LoadDocumentDialog : Form
   {
      private bool _isWorking = true;

      private PDFDocument _document;
      public PDFDocument PDFDocument
      {
         get { return _document; }
      }

      public LoadDocumentDialog(string fileName)
      {
         InitializeComponent();

         _fileNameTextBox.Text = fileName;
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            BeginInvoke(new MethodInvoker(CheckAndLoadDocument));
         }

         base.OnLoad(e);
      }

      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         e.Cancel = _isWorking;

         base.OnFormClosing(e);
      }

      private void CheckAndLoadDocument()
      {
         _isWorking = true;
         _cancelButton.Enabled = false;
         _okButton.Enabled = false;
         Application.DoEvents();

         PDFDocument document = _getDocumentPropertiesControl.Run(_fileNameTextBox.Text);
         if (document == null)
         {
            _isWorking = false;
            DialogResult = DialogResult.Cancel;
            return;
         }

         _document = document;

         _mainWizardControl.SelectedTab = _optionsTabPage;
         _loadDocumentOptionsControl.SetDocument(document);

         _isWorking = false;
         _cancelButton.Enabled = true;
         _okButton.Enabled = true;

         Application.DoEvents();
      }

      private void ReadDocument()
      {
         _isWorking = true;
         _cancelButton.Enabled = false;
         _okButton.Enabled = false;
         Application.DoEvents();

         bool noErrors = _readPDFDocumentControl.Run(
            _document,
            _loadDocumentOptionsControl.ReadDocumentStructOptions,
            _loadDocumentOptionsControl.ParsePagesOptions,
            _loadDocumentOptionsControl.ParseChunks);

         _isWorking = false;
         _okButton.Enabled = true;

         if (noErrors)
         {
            DialogResult = DialogResult.OK;
            Close();
         }
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         if (_mainWizardControl.SelectedTab == _optionsTabPage)
         {
            _loadDocumentOptionsControl.Apply();
            _document.Resolution = _loadDocumentOptionsControl.Resolution;

            _mainWizardControl.SelectedTab = _readTabPage;
            BeginInvoke(new MethodInvoker(ReadDocument));
            DialogResult = DialogResult.None;
            return;
         }
      }
   }
}
