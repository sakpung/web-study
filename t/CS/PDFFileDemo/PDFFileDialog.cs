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
using Leadtools.Demos;
using Leadtools.Pdf;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace PDFFileDemo
{
   public partial class PDFFileDialog : Form
   {
      private PDFFile _sourceDocument;
      private bool _isSourcePostscript;
      private PDFFile _destinationDocument;
      private string _destinationFileName;
      private PDFDistillerOptions _distillerOptions;
      private int _insertPageNumber;
      private int _firstPageNumber;
      private int _lastPageNumber;

      private enum Operation
      {
         UpdateProperties,
         ConvertToPDFA,
         Linearize,
         Convert,
         Merge,
         DeletePages,
         ExtractPages,
         InsertPages,
         Distill,
#if LEADTOOLS_V19_OR_LATER
         Optimizer,
         InitialView,
         DigitalSignature
#endif // #if LEADTOOLS_V19_OR_LATER
      }

      private struct OperationItem
      {
         public Operation Operation;
         public string Text;
         public bool ShowPages;
         public bool CanUseAllPages;
         public bool MutlipleSourceFiles;
         public bool DestinationMustExist;
         public bool ShowCompatibilityLevel;
         public bool ShowSecurityOptions;
         public bool ShowOptimizationOptions;
         public bool ShowInitialViewOptions;
         public bool ShowDigitalSignatureOptions;

         public OperationItem(Operation operation_, string text_, bool showPages_, bool canUseAllPages_, bool mutlipleSourceFiles_, bool destinationMustExist_, bool showCompatibilityLevel_, bool showSecurityOptions_, bool showOptimizationOptions_, bool showInitialViewOptions_, bool showDigitalSignatureOptions_)
         {
            Operation = operation_;
            Text = text_;
            ShowPages = showPages_;
            CanUseAllPages = canUseAllPages_;
            MutlipleSourceFiles = mutlipleSourceFiles_;
            DestinationMustExist = destinationMustExist_;
            ShowCompatibilityLevel = showCompatibilityLevel_;
            ShowSecurityOptions = showSecurityOptions_;
            ShowOptimizationOptions = showOptimizationOptions_;
            ShowInitialViewOptions = showInitialViewOptions_;
            ShowDigitalSignatureOptions = showDigitalSignatureOptions_;
         }

         public override string ToString()
         {
            return Text;
         }
      }

      private readonly OperationItem _distillOperationItem = new OperationItem(Operation.Distill, null, false, false, false, false, true, true, true, true, false);

      public PDFFileDialog()
      {
         InitializeComponent();
      }

      private static readonly string _updatePropertiesText = "Update the properties of a PDF file such as title, author, keywords, etc";
      private static readonly string _convertToPDFAText = "Convert a PDF file to PDF/A";
      private static readonly string _linearizeText = "Linearize a PDF file (optimize it for Web viewing)";
      private static readonly string _convertText = "Convert or encrypt a PDF file to another versions";
      private static readonly string _mergeText = "Merge a PDF file with one or more existing files";
      private static readonly string _deletePagesText = "Delete one or more pages from an existing PDF file";
      private static readonly string _extractPagesText = "Extract one or more pages from an existing PDF file";
      private static readonly string _insertPagesText = "Insert pages from an existing PDF file into another";
#if LEADTOOLS_V19_OR_LATER
      private static readonly string _optimizerText = "Update PDF file optimizer options";
      private static readonly string _initialViewText = "Update PDF file initial view options";
      private static readonly string _digitalSignature = "Sign PDF File (Digital Signature)";
#endif // #if LEADTOOLS_V19_OR_LATER

      protected override void OnLoad(EventArgs e)
      {
         if(!DesignMode)
         {
            Messager.Caption = "PDF File C# Demo";
            Text = Messager.Caption;

            this.Text = Messager.Caption;

            OperationItem[] items =
            {
               new OperationItem(Operation.UpdateProperties, _updatePropertiesText, false, false, false, false, false, false, false, false, false),
               new OperationItem(Operation.ConvertToPDFA, _convertToPDFAText, false, false, false, false, false, false, false, false, false),
               new OperationItem(Operation.Linearize, _linearizeText, false, false, false, false, false, false, false, false, false),
               new OperationItem(Operation.Convert, _convertText, true, true, false, false, true, true, true, true, false),
               new OperationItem(Operation.Merge, _mergeText, false, false, true, false, true, true, true, true, false),
               new OperationItem(Operation.DeletePages, _deletePagesText, true, false, false, false, true, true, true, true, false),
               new OperationItem(Operation.ExtractPages, _extractPagesText, true, true, false, false, true, true, true, true, false),
               new OperationItem(Operation.InsertPages, _insertPagesText, true, true, false, true, true, true, true, true, false),
#if LEADTOOLS_V19_OR_LATER
               new OperationItem(Operation.Optimizer, _optimizerText, false, false, false, false, false, false, true, false, false),
               new OperationItem(Operation.InitialView, _initialViewText, false, false, false, false, false, false, false, true, false),
               new OperationItem(Operation.DigitalSignature, _digitalSignature, false, false, false, false, false, false, false, false, true),
#endif // #if LEADTOOLS_V19_OR_LATER
            };

            foreach(OperationItem item in items)
            {
               _operationComboBox.Items.Add(item);
            }

            _operationComboBox.SelectedIndex = 0;

            _sourceDocumentPropertiesControl.SetDocumentProperties(null, true);
            _sourceFileIsPostscriptLabel.Visible = false;

            _distillOptionsOutputModeComboBox.Items.Add("Default - Useful across a wide variety of uses, at the expense of a larger output file");
            _distillOptionsOutputModeComboBox.Items.Add("Low-resolution similar to Acrobat Distiller 'Screen Optimized'");
            _distillOptionsOutputModeComboBox.Items.Add("Medium-resolution similar to the Acrobat Distiller 'eBook Optimized'");
            _distillOptionsOutputModeComboBox.Items.Add("High-resolution similar to the Acrobat Distiller 'Print Optimized'");
            _distillOptionsOutputModeComboBox.Items.Add("Highest-resolution similar to the Acrobat Distiller 'Prepress Optimized'");
            _distillOptionsOutputModeComboBox.SelectedIndex = 2;

            _distillOptionsAutoRotatePageModeComboBox.Items.Add("No rotation");
            _distillOptionsAutoRotatePageModeComboBox.Items.Add("Rotation will be performed on a page by page bases");
            _distillOptionsAutoRotatePageModeComboBox.Items.Add("Rotation will be applied to all the pages in the final document");
            _distillOptionsAutoRotatePageModeComboBox.SelectedIndex = 1;

            UpdateUIState();
         }

         base.OnLoad(e);
      }

      private void _exitButton_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _aboutButton_Click(object sender, EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("PDF File", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("PDF File"))
            aboutDialog.ShowDialog(this);
#endif
      }

      private void UpdateUIState()
      {
        if(_mainWizardControl.SelectedTab == _sourceFileTabPage)
         {
            SourceFileUpdateUIState();
         }
         else if(_mainWizardControl.SelectedTab == _operationTabPage)
         {
            OperationUpdateUIState();
         }
         else if(_mainWizardControl.SelectedTab == _distillTabPage)
         {
            DistillUpdateUIState();
         }
         else if(_mainWizardControl.SelectedTab == _sourceFilesTabPage)
         {
            SourceFilesUpdateUIState();
         }
         else if(_mainWizardControl.SelectedTab == _destinationFileTabPage)
         {
            DestinationFileUpdateUIState();
         }
         else if(_mainWizardControl.SelectedTab == _optionsTabPage)
         {
            OptionsUpdateUIState();
         }
      }

      private void _previousButton_Click(object sender, EventArgs e)
      {
         if(_mainWizardControl.SelectedTab == _operationTabPage)
         {
            OperationPreviousPage();
         }
         if(_mainWizardControl.SelectedTab == _distillTabPage)
         {
            DistillPreviousPage();
         }
         else if(_mainWizardControl.SelectedTab == _sourceFilesTabPage)
         {
            SourceFilesPreviousPage();
         }
         else if(_mainWizardControl.SelectedTab == _destinationFileTabPage)
         {
            DestinationFilePreviousPage();
         }
         else if(_mainWizardControl.SelectedTab == _optionsTabPage)
         {
            OptionsPreviousPage();
         }

         UpdateUIState();
      }

      private void _nextButton_Click(object sender, EventArgs e)
      {
         if(_mainWizardControl.SelectedTab == _sourceFileTabPage)
         {
            SourceFileNextPage();
         }
         else if(_mainWizardControl.SelectedTab == _operationTabPage)
         {
            OperationNextPage();
         }
         else if(_mainWizardControl.SelectedTab == _distillTabPage)
         {
            DistillNextPage();
         }
         else if(_mainWizardControl.SelectedTab == _sourceFilesTabPage)
         {
            SourceFilesNextPage();
         }
         else if(_mainWizardControl.SelectedTab == _destinationFileTabPage)
         {
            OperationItem operationItem = GetCurrentOperation();
            if (operationItem.ShowDigitalSignatureOptions)
            {
               _destinationFileName = _destinationFileNameTextBox.Text;
               OptionsNextPage();
               _filePasswordTextBox.Text = "";
            }
            else
               DestinationFileNextPage();
         }
         else if(_mainWizardControl.SelectedTab == _optionsTabPage)
         {
            OptionsNextPage();
         }

         UpdateUIState();
      }

      #region Source File Page
      private void SourceFileUpdateUIState()
      {
         _previousButton.Enabled = false;
         _nextButton.Enabled = true;
         _nextButton.Text = "&Next";
      }

      private void SourceFileNextPage()
      {
         if(string.IsNullOrEmpty(_sourceFileNameTextBox.Text))
         {
            Messager.ShowWarning(this, "You must select a source PDF file first");
            _sourceFileNameBrowseButton.Focus();
            return;
         }

         if(!_isSourcePostscript)
         {
            _mainWizardControl.SelectedTab = _operationTabPage;
         }
         else
         {
            _mainWizardControl.SelectedTab = _distillTabPage;
         }
      }

      private void _sourceFileNameBrowseButton_Click(object sender, EventArgs e)
      {
         bool isPostscript;
         PDFFile document = BrowsePDFDocument(false, out isPostscript);
         if(document != null)
         {
            _sourceDocument = document;
            _isSourcePostscript = isPostscript;

            _sourceFileNameTextBox.Text = _sourceDocument.FileName;

            if(!_isSourcePostscript)
            {
               _sourceFilePropertiesControl.Visible = true;
               _sourceFilePropertiesControl.SetFileProperties(_sourceDocument);
               _sourceDocumentPropertiesControl.Visible = true;
               _sourceDocumentPropertiesControl.SetDocumentProperties(_sourceDocument.DocumentProperties, true);

               _operationPageCountLabel.Text = string.Format("Document has {0} pages.", _sourceDocument.Pages.Count);
               _operationAllPagesCheckBox.Checked = true;
               _operationFirstPageNumberTextBox.Text = "1";
               _operationLastPageNumberTextBox.Text = _sourceDocument.Pages.Count.ToString();
               _sourceFileIsPostscriptLabel.Visible = false;
            }
            else
            {
               _sourceFilePropertiesControl.Visible = false;
               _sourceDocumentPropertiesControl.Visible = false;
               _sourceFileIsPostscriptLabel.Visible = true;
            }

            UpdateUIState();
         }
      }
      #endregion Source File Page

      #region Operation Page
      private OperationItem GetCurrentOperation()
      {
         if(!_isSourcePostscript)
         {
            return (OperationItem)_operationComboBox.SelectedItem;
         }
         else
         {
            return _distillOperationItem;
         }
      }

      private void OperationUpdateUIState()
      {
         _previousButton.Enabled = true;
         _nextButton.Enabled = true;
         _nextButton.Text = "&Next";

         OperationItem operationItem = GetCurrentOperation();
         _operationSourcePages.Visible = operationItem.ShowPages;
         _operationAllPagesCheckBox.Visible = operationItem.CanUseAllPages;
         if(!_operationAllPagesCheckBox.Visible)
         {
            _operationAllPagesCheckBox.Checked = false;
         }

         _operationFirstPageNumberTextBox.Enabled = !_operationAllPagesCheckBox.Checked;
         _operationLastPageNumberTextBox.Enabled = !_operationAllPagesCheckBox.Checked;
      }

      private void OperationPreviousPage()
      {
         _mainWizardControl.SelectedTab = _sourceFileTabPage;
      }

      private void OperationNextPage()
      {
         bool allOk = true;

         if(_operationSourcePages.Visible && (!_operationAllPagesCheckBox.Visible || !_operationAllPagesCheckBox.Checked))
         {
            // Check if the pages are OK
            int firstPageNumber = 1;
            int lastPageNumber = _sourceDocument.Pages.Count;

            if(allOk && !int.TryParse(_operationFirstPageNumberTextBox.Text, out firstPageNumber))
            {
               Messager.ShowWarning(this, "Enter a valid page number");
               _operationFirstPageNumberTextBox.Focus();
               _operationFirstPageNumberTextBox.SelectAll();
               allOk = false;
            }

            if(allOk && !int.TryParse(_operationLastPageNumberTextBox.Text, out lastPageNumber))
            {
               Messager.ShowWarning(this, "Enter a valid page number");
               _operationLastPageNumberTextBox.Focus();
               _operationLastPageNumberTextBox.SelectAll();
               allOk = false;
            }

            if(allOk && (firstPageNumber < 1 || firstPageNumber > lastPageNumber || firstPageNumber > _sourceDocument.Pages.Count))
            {
               Messager.ShowWarning(this, "First page number must be a value between 1 and " + _sourceDocument.Pages.Count.ToString());
               _operationFirstPageNumberTextBox.Focus();
               _operationFirstPageNumberTextBox.SelectAll();
               allOk = false;
            }

            if(allOk && (lastPageNumber < 1 || firstPageNumber > lastPageNumber || lastPageNumber > _sourceDocument.Pages.Count))
            {
               Messager.ShowWarning(this, "Last page number must be a value greater than first page number and less than " + _sourceDocument.Pages.Count.ToString());
               _operationLastPageNumberTextBox.Focus();
               _operationLastPageNumberTextBox.SelectAll();
               allOk = false;
            }

            if(!_operationAllPagesCheckBox.Visible)
            {
               if(_sourceDocument.Pages.Count > 1 && firstPageNumber == 1 && (lastPageNumber == -1 || lastPageNumber == _sourceDocument.Pages.Count))
               {
                  Messager.ShowWarning(this, "Cannot delete all the pages from a document");
                  _operationLastPageNumberTextBox.Focus();
                  _operationLastPageNumberTextBox.SelectAll();
                  allOk = false;
               }
            }

            _firstPageNumber = firstPageNumber;
            _lastPageNumber = lastPageNumber;
         }
         else
         {
            _firstPageNumber = 1;
            _lastPageNumber = -1;
         }

         OperationItem operationItem = GetCurrentOperation();
         if(operationItem.Operation == Operation.DeletePages && _sourceDocument.Pages.Count == 1)
         {
            Messager.ShowWarning(this, "This document contain a single page. 'Delete Pages' operation is not supported");
            allOk = false;
         }

         if(allOk)
         {
            if(operationItem.MutlipleSourceFiles)
            {
               _mainWizardControl.SelectedTab = _sourceFilesTabPage;
            }
            else
            {
               _signatureFileNameTextBox.Text = "";
               _filePasswordTextBox.Text = "";
               _mainWizardControl.SelectedTab = _destinationFileTabPage;
            }
         }
      }

      private void _operationComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _operationAllPagesCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }
      #endregion Operation Page

      #region Distill Page
      private void DistillUpdateUIState()
      {
         _previousButton.Enabled = true;
         _nextButton.Enabled = true;
         _nextButton.Text = "&Next";
      }

      private void DistillPreviousPage()
      {
         _mainWizardControl.SelectedTab = _sourceFileTabPage;
      }

      private void DistillNextPage()
      {
         if(string.IsNullOrEmpty(_distillPDFFileTextBox.Text))
         {
            Messager.ShowWarning(this, "You must select the PDF file name to create.");
            return;
         }

         _destinationFileName = _distillPDFFileTextBox.Text;

         _distillerOptions = new PDFDistillerOptions();
         _distillerOptions.OutputMode = (PDFDistillerOutputMode)_distillOptionsOutputModeComboBox.SelectedIndex;
         _distillerOptions.AutoRotatePageMode = (PDFDistillerAutoRotatePageMode)_distillOptionsAutoRotatePageModeComboBox.SelectedIndex;

         _mainWizardControl.SelectedTab = _optionsTabPage;
      }

      private void _distillPDFFileBrowseButton_Click(object sender, EventArgs e)
      {
         string pdfFileName = RunPDFSaveFileDialog();
         if(pdfFileName != null)
         {
            _distillPDFFileTextBox.Text = pdfFileName;
         }
      }
      #endregion Distill Page

      #region Source Files Page
      private void SourceFilesUpdateUIState()
      {
         _previousButton.Enabled = true;
         _nextButton.Enabled = true;
         _nextButton.Text = "&Next";
      }

      private void SourceFilesPreviousPage()
      {
         _mainWizardControl.SelectedTab = _operationTabPage;
      }

      private void SourceFilesNextPage()
      {
         if(_sourceFilesListBox.Items.Count == 0)
         {
            Messager.ShowWarning(this, "You must select at least one file to merge with.");
            _sourceFilesAddButton.Focus();
            return;
         }

         _mainWizardControl.SelectedTab = _destinationFileTabPage;
      }

      private void _sourceFilesAddButton_Click(object sender, EventArgs e)
      {
         string fileName = RunPDFOpenFileDialog(true);
         if(fileName != null)
         {
            _sourceFilesListBox.Items.Add(fileName);
         }
      }

      private void _sourceFilesClearButton_Click(object sender, EventArgs e)
      {
         _sourceFilesListBox.Items.Clear();
      }
      #endregion Source Files Page

      #region Destination File Page
      private void DestinationFileUpdateUIState()
      {
         _previousButton.Enabled = true;
         _nextButton.Enabled = true;

         OperationItem operationItem = GetCurrentOperation();
         if(operationItem.DestinationMustExist)
         {
            // Use must select a destination file
            _destinationFileUseSourceFileCheckBox.Checked = false;
            _destinationFileUseSourceFileCheckBox.Visible = false;
            _destinationFileNameGroupBox.Enabled = true;
            _destinationFilePropertiesControl.Visible = true;
            _destinationFileInsertPageNumberGroupBox.Visible = true;
            if(string.IsNullOrEmpty(_destinationFileInsertPageNumberTextBox.Text))
            {
               _destinationFileInsertPageNumberTextBox.Text = "-1";
            }
         }
         else
         {
            _destinationFileUseSourceFileCheckBox.Visible = true;
            _destinationFileNameGroupBox.Enabled = !_destinationFileUseSourceFileCheckBox.Checked;
            _destinationFilePropertiesControl.Visible = false;
            _destinationFileInsertPageNumberGroupBox.Visible = false;
         }

         if (operationItem.ShowDigitalSignatureOptions)
         {
            if (_destinationFileUseSourceFileCheckBox.Checked)
               _destinationFileNameTextBox.Text = _sourceDocument.FileName;

            _signatureFileNameGroupBox.Visible = true;
            _filePasswordGroupBox.Visible = true;
            _nextButton.Text = "&Finish";
         }
         else
         {
            _signatureFileNameGroupBox.Visible = false;
            _filePasswordGroupBox.Visible = false;
            _nextButton.Text = "&Next";
         }
      }

      private void DestinationFilePreviousPage()
      {
         OperationItem operationItem = GetCurrentOperation();
         if(operationItem.MutlipleSourceFiles)
         {
            _mainWizardControl.SelectedTab = _sourceFilesTabPage;
         }
         else
         {
            if(!_isSourcePostscript)
            {
               _mainWizardControl.SelectedTab = _operationTabPage;
               _destinationFileNameTextBox.Text = null;
               _destinationFileUseSourceFileCheckBox.Checked = false;
            }
            else
            {
               _mainWizardControl.SelectedTab = _distillTabPage;
            }
         }
      }

      private void DestinationFileNextPage()
      {
         if(string.IsNullOrEmpty(_destinationFileNameTextBox.Text) && !_destinationFileUseSourceFileCheckBox.Checked)
         {
            Messager.ShowWarning(this, "You must select a destination PDF file");
            return;
         }

         if(_destinationFileInsertPageNumberGroupBox.Visible)
         {
            int insertPageNumber;
            if(!int.TryParse(_destinationFileInsertPageNumberTextBox.Text, out insertPageNumber))
            {
               Messager.ShowWarning(this, "Enter a valid page number");
               _destinationFileInsertPageNumberTextBox.Focus();
               _destinationFileInsertPageNumberTextBox.SelectAll();
               return;
            }

            if(insertPageNumber != -1 && insertPageNumber != 0 && (insertPageNumber < 1 || insertPageNumber > _destinationDocument.Pages.Count))
            {
               Messager.ShowWarning(this, "Enter a valid page number");
               _destinationFileInsertPageNumberTextBox.Focus();
               _destinationFileInsertPageNumberTextBox.SelectAll();
               return;
            }

            _insertPageNumber = insertPageNumber;
            _destinationFileName = null;
         }
         else
         {
            if(_destinationFileUseSourceFileCheckBox.Checked)
            {
               _destinationFileName = null;
            }
            else
            {
               _destinationFileName = _destinationFileNameTextBox.Text;
            }
         }

         _mainWizardControl.SelectedTab = _optionsTabPage;
      }

      private void _destinationFileNameBrowseButton_Click(object sender, EventArgs e)
      {
         OperationItem operationItem = GetCurrentOperation();
         if(operationItem.DestinationMustExist)
         {
            // Destination file must be a valid PDF file
            bool isPostscript;
            PDFFile destinationDocument = BrowsePDFDocument(true, out isPostscript);
            if(destinationDocument != null)
            {
               _destinationDocument = destinationDocument;

               _destinationFileNameTextBox.Text = _destinationDocument.FileName;
               _destinationFilePropertiesControl.SetFileProperties(_destinationDocument);
            }
         }
         else
         {
            // We will not check here
            string fileName = RunPDFSaveFileDialog();
            if(fileName != null)
            {
               _destinationFileNameTextBox.Text = fileName;
            }
         }

         UpdateUIState();
      }

      private void _signatureFileNameBrowseButton_Click(object sender, EventArgs e)
      {
         string fileName = BrowseDigitalSignature();
         if (!string.IsNullOrEmpty(fileName))
         {
            _signatureFileNameTextBox.Text = fileName;
         }
      }

      private void _destinationFileUseSourceFileCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }
      #endregion Destination File Page

      #region Option Page
      private void OptionsUpdateUIState()
      {
         _previousButton.Enabled = true;
         _nextButton.Enabled = true;
         _nextButton.Text = "&Finish";

         OperationItem operationItem = GetCurrentOperation();
         if(operationItem.DestinationMustExist)
         {
            _optionsConvertOptionsControl.SetDocument(_destinationDocument, true, operationItem.ShowSecurityOptions, operationItem.ShowOptimizationOptions, operationItem.ShowInitialViewOptions, _firstPageNumber, _lastPageNumber);
         }
         else
         {
            _optionsConvertOptionsControl.SetDocument(_sourceDocument, operationItem.ShowCompatibilityLevel, operationItem.ShowSecurityOptions, operationItem.ShowOptimizationOptions, operationItem.ShowInitialViewOptions, _firstPageNumber, _lastPageNumber);
         }
      }

      private void OptionsPreviousPage()
      {
         if(!_isSourcePostscript)
         {
            _mainWizardControl.SelectedTab = _destinationFileTabPage;
         }
         else
         {
            _mainWizardControl.SelectedTab = _distillTabPage;
         }
      }

      private void OptionsNextPage()
      {
         OperationItem operationItem = GetCurrentOperation();
         string viewFileName;

         if(operationItem.DestinationMustExist)
         {
            viewFileName = _destinationDocument.FileName;
         }
         else
         {
            viewFileName = _destinationFileName != null ? _destinationFileName : _sourceDocument.FileName;
         }

         if(operationItem.DestinationMustExist)
         {
            _optionsConvertOptionsControl.UpdateDocument(_destinationDocument);
         }
         else
         {
            _optionsConvertOptionsControl.UpdateDocument(_sourceDocument);
         }

         try
         {
            using(WaitCursor wait = new WaitCursor())
            {
               switch(operationItem.Operation)
               {
                  case Operation.UpdateProperties:
                     _sourceDocument.SetDocumentProperties(_destinationFileName);
                     break;

                  case Operation.ConvertToPDFA:
                     _sourceDocument.ConvertToPDFA(_destinationFileName);
                     break;

                  case Operation.Linearize:
                     _sourceDocument.Linearize(_destinationFileName);
                     break;

                  case Operation.Convert:
                     _sourceDocument.Convert(_firstPageNumber, _lastPageNumber, _destinationFileName);
                     break;

                  case Operation.Merge:
                     string[] sourceFiles = new string[_sourceFilesListBox.Items.Count];
                     for(int i = 0; i < _sourceFilesListBox.Items.Count; i++)
                     {
                        sourceFiles[i] = _sourceFilesListBox.Items[i].ToString();
                     }

                     _sourceDocument.MergeWith(sourceFiles, _destinationFileName);
                     break;

                  case Operation.DeletePages:
                     _sourceDocument.DeletePages(_firstPageNumber, _lastPageNumber, _destinationFileName);
                     break;

                  case Operation.ExtractPages:
                     _sourceDocument.ExtractPages(_firstPageNumber, _lastPageNumber, _destinationFileName);
                     break;

                  case Operation.InsertPages:
                     _destinationDocument.InsertPagesFrom(_insertPageNumber, _sourceDocument, _firstPageNumber, _lastPageNumber);
                     break;

                  case Operation.Distill:
                     _sourceDocument.Distill(_distillerOptions, _destinationFileName);
                     break;

                  case Operation.InitialView:
                     _sourceDocument.SetInitialView(_destinationFileName);
                     break;

                  case Operation.Optimizer:
                     _sourceDocument.Optimize(_destinationFileName);
                     break;

                  case Operation.DigitalSignature:
                     if (!HasDigitalSignatureSupport(this))
                        return;

                     _sourceDocument.SignDocument(_destinationFileNameTextBox.Text, _signatureFileNameTextBox.Text, _filePasswordTextBox.Text);
                     break;

                  default:
                     break;
               }
            }

            System.Diagnostics.Process.Start(viewFileName);
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }
      #endregion Option Page

      #region Tools
      private PDFFile BrowsePDFDocument(bool pdfOnly, out bool isPostscript)
      {
         isPostscript = false;
         string fileName = RunPDFOpenFileDialog(pdfOnly);
         if(fileName == null)
         {
            return null;
         }

         try
         {
            PDFFileType fileType = PDFFile.GetPDFFileType(fileName, pdfOnly);
            if(fileType == PDFFileType.Unknown)
            {
               if(pdfOnly)
               {
                  Messager.ShowError(this, string.Format("Not a valid PDF file.\n\n{0}", fileName));
               }
               else
               {
                  Messager.ShowError(this, string.Format("Not a valid PDF or Postscript file.\n\n{0}", fileName));
               }
               return null;
            }

            if(fileType == PDFFileType.Postscript || fileType == PDFFileType.EncapsulatedPostscript)
            {
               isPostscript = true;
            }

            if(!isPostscript)
            {
               string password = null;

               // Check if it is encrypted
               if(PDFFile.IsEncrypted(fileName))
               {
                  using(GetPasswordDialog dlg = new GetPasswordDialog())
                  {
                     if(dlg.ShowDialog(this) == DialogResult.OK)
                     {
                        password = dlg.Password;
                     }
                     else
                     {
                        return null;
                     }
                  }
               }

               using(WaitCursor wait = new WaitCursor())
               {
                  PDFFile document = new PDFFile(fileName, password);
                  document.Load();
                  return document;
               }
            }
            else
            {
               PDFFile document = new PDFFile(fileName);
               return document;
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex.Message);
         }

         return null;
      }

      private string RunPDFOpenFileDialog(bool pdfOnly)
      {
         using(OpenFileDialog dlg = new OpenFileDialog())
         {
            if(pdfOnly)
            {
               dlg.Filter = "PDF Documents|*.pdf|All Files|*.*";
            }
            else
            {
               dlg.Filter = "PDF or Postscript Documents|*.pdf;*.ps;*.eps|All Files|*.*";
            }

            if(dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
               return dlg.FileName;
            }
         }

         return null;
      }

      private string RunPDFSaveFileDialog()
      {
         using(SaveFileDialog dlg = new SaveFileDialog())
         {
            dlg.Filter = "PDF Documents|*.pdf|All Files|*.*";
            dlg.DefaultExt = "pdf";
            if(dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
               return dlg.FileName;
            }
         }

         return null;
      }

      private string BrowseDigitalSignature()
      {
         using (OpenFileDialog dlg = new OpenFileDialog())
         {
            dlg.Filter = "Digital Signature|*.pfx";

            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
               return dlg.FileName;
            }
         }

         return "";
      }

      private static bool HasDigitalSignatureSupport(IWin32Window owner)
      {
         // If the user selected to parse digital signature then verify the status
         RasterExceptionCode digitalSignatureSupportStatus = PDFDocument.GetDigitalSignatureSupportStatus();
         if (digitalSignatureSupportStatus == RasterExceptionCode.OpenSSLDllMissing)
         {
            // We have PDF digital signature support but Open SSL library is missing.
            string message = "To use this feature, download the latest version of the 1.1.0 OpenSSL libraries and copy libcrypto-1_1[-x64].dll and libssl-1_1[-x64].dll to the location of the LEADTOOLS binaries folder." + Environment.NewLine + Environment.NewLine +
               "LEAD Precompiled and Signed OpenSSL binaries:" + Environment.NewLine +
               "https://www.leadtools.com/openssl/binaries" + Environment.NewLine + Environment.NewLine +
               "OpenSSL source code:" + Environment.NewLine +
               "https://www.openssl.org";
            string caption = "Download OpenSSL";

            MessageBox.Show(owner, message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
         }
         else
         {
            // Nothing for us to do, will either work or not supported in this platform
            return true;
         }
      }

      #endregion Tools
   }
}
