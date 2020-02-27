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
using System.IO;

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Pdf;
using Leadtools.Annotations.Engine;

using Leadtools.Annotations.Automation;
using Leadtools.Annotations.WinForms;

using PDFDocumentDemo.Annotations;

namespace PDFDocumentDemo
{
   public partial class MainForm : Form
   {
      // The RasterCodecs objects to use when loading the images
      private RasterCodecs _rasterCodecs;
      // Current demo options
      private DemoOptions _demoOptions = DemoOptions.Default;
      // The current document
      private PDFDocument _document;
      // Current annotations
      private DocumentAnnotations _documentAnnotations;
      // Current page number
      private int _currentPageNumber;
      // This is the words for each page
      private Dictionary<int, MyWord[]> _documentText;
      // These are the highlighted words in each page
      private Dictionary<int, MyWord[]> _selectedText;
      // Helper class for "find" text
      private FindTextHelper _findTextHelper;

      public MainForm()
      {
         InitializeComponent();

         Messager.Caption = "PDF Document C# Demo";
         Text = Messager.Caption;
      }

      #region UI
      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            BeginInvoke(new MethodInvoker(Startup));
         }

         base.OnLoad(e);
      }

      private void Startup()
      {
         try
         {
            if (!Init())
            {
               Close();
               return;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            Close();
         }
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         CleanUp();

         base.OnFormClosed(e);
      }

      private void _openToolStripButton_Click(object sender, EventArgs e)
      {
         OpenDocument();
      }

      private void _findToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (_document == null || _documentText == null || string.IsNullOrEmpty(_findToolStripTextBox.Text)) return;

         if (e.KeyChar == (char)Keys.Return)
         {
            FindText(true);
         }
      }

      private void _findToolStripTextBox_KeyDown(object sender, KeyEventArgs e)
      {
         if (_document == null || _documentText == null || string.IsNullOrEmpty(_findToolStripTextBox.Text)) return;

         if (e.KeyCode == Keys.F3)
         {
            FindText(e.Modifiers != Keys.Shift);
         }
      }

      private void _findPreviousToolStripButton_Click(object sender, EventArgs e)
      {
         if (_document == null || _documentText == null || string.IsNullOrEmpty(_findToolStripTextBox.Text)) return;

         FindText(false);
      }

      private void _findNextToolStripButton_Click(object sender, EventArgs e)
      {
         if (_document == null || _documentText == null || string.IsNullOrEmpty(_findToolStripTextBox.Text)) return;

         FindText(true);
      }

      private void _fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         _saveToolStripMenuItem.Visible = _document != null;
         _saveAsToolStripMenuItem.Visible = _document != null;
         _closeToolStripMenuItem.Visible = _document != null;
         _fileSep1ToolStripMenuItem.Visible = _document != null;
         _exportTextToolStripMenuItem.Visible = _document != null;
         _exportTextToolStripMenuItem.Enabled = _documentText != null;
         _propertiesToolStripMenuItem.Visible = _document != null;
         _fontsToolStripMenuItem.Visible = _document != null;
         _fileSep2ToolStripMenuItem.Visible = _document != null;
      }

      private void _openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OpenDocument();
      }


      private void _saveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         // Check if the file exist and is accessible

         string fileName = _document.FileName;
         bool isFileAccessible = false;

         // Try to open it
         try
         {
            using (FileStream file = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
               isFileAccessible = true;
            }
         }
         catch
         {
            isFileAccessible = false;
         }

         // If the file is not accessible, then offer to do SaveAs
         if (!isFileAccessible)
         {
            string message = "The file:\n" + fileName + "\nIs not accessible at this time. Do you want to save the file using another name?";
            if (Messager.ShowQuestion(this, message, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               _saveAsToolStripMenuItem.PerformClick();
            }
         }
         else
         {
            // Otherwise into the original file
            SaveDocument(fileName);
         }
      }

      private void _saveAsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         using (SaveFileDialog dlg = new SaveFileDialog())
         {
            dlg.Filter = "PDF files|*.pdf|All files|*.*";
            dlg.DefaultExt = "pdf";
            dlg.FileName = Path.GetFileName(_document.FileName);

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               SaveDocument(dlg.FileName);
            }
         }
      }

      private void _closeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         CloseDocument();
      }

      private void _exportTextToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null || _documentText == null) return;

         ExportDocumentText();
      }

      private void _propertiesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         ShowDocumentProperties();
      }

      private void _fontsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         using (var dlg = new PDFFontsDialog(_document))
            dlg.ShowDialog(this);
      }

      private void _exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         if (_document == null) return;

         // These with text
         bool textSelected = IsTextSelected;
         _copyToolStripMenuItem.Enabled = textSelected;
         _selectAllToolStripMenuItem.Enabled = _documentText != null;
         _clearSelectionToolStripMenuItem.Enabled = textSelected;
         _findToolStripMenuItem.Enabled = _documentText != null;
         _findNextToolStripMenuItem.Enabled = _documentText != null && !string.IsNullOrEmpty(_findToolStripTextBox.Text);
         _findPreviousToolStripMenuItem.Enabled = _documentText != null && !string.IsNullOrEmpty(_findToolStripTextBox.Text);
      }

      private void _copyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null ||
            _documentText == null ||
            _selectedText[_currentPageNumber] == null ||
            _selectedText[_currentPageNumber].Length == 0)
         {
            return;
         }

         CopySelectedText();
      }

      private void _selectAllToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null || _documentText == null) return;

         SelectAllText();
      }

      private void _clearSelectionToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null || _documentText == null) return;

         ClearTextSelection();
      }

      private void _findToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null || _documentText == null) return;

         _findToolStripTextBox.Focus();
         _findToolStripTextBox.SelectAll();
      }

      private void _findNextToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null || _documentText == null || string.IsNullOrEmpty(_findToolStripTextBox.Text)) return;

         FindText(true);
      }

      private void _findPreviousToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null || _documentText == null || string.IsNullOrEmpty(_findToolStripTextBox.Text)) return;

         FindText(false);
      }

      private void _viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         if (_document == null) return;

         _fitWidthToolStripMenuItem.Checked = _viewerControl.RasterImageViewer.SizeMode == Leadtools.Controls.ControlSizeMode.FitWidth;
         _fitPageToolStripMenuItem.Checked = _viewerControl.RasterImageViewer.SizeMode == Leadtools.Controls.ControlSizeMode.FitAlways;
         _thumbnailsToolStripMenuItem.Checked = _pagesControl.ShowThumbnails;
         _bookmarksToolStripMenuItem.Checked = _pagesControl.ShowBookmarks;
         _signaturesToolStripMenuItem.Checked = _pagesControl.ShowSignatures;
         _highlightObjectsToolStripMenuItem.Checked = _viewerControl.HighlightObjects;

         _thumbnailsToolStripMenuItem.Visible = _pagesControl.Visible;
         _bookmarksToolStripMenuItem.Visible = _pagesControl.Visible;
         _signaturesToolStripMenuItem.Visible = _pagesControl.Visible;
         _viewSep3ToolStripMenuItem.Visible = _pagesControl.Visible;
      }

      private void _zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         _viewerControl.ZoomViewer(true);
      }

      private void _zoomInToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         _viewerControl.ZoomViewer(false);
      }

      private void _fitWidthToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         _viewerControl.FitPage(true);
      }

      private void _fitPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         _viewerControl.FitPage(false);
      }

      private void _thumbnailsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _pagesControl.SetActiveTab(true, false, false);
      }

      private void _bookmarksToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _pagesControl.SetActiveTab(false, true, false);
      }

      private void _signaturesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _pagesControl.SetActiveTab(false, false, true);
      }

      private void _highlightObjectsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.HighlightObjects = !_viewerControl.HighlightObjects;
      }

      private void _pageToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         if (_document == null) return;

         int pageCount = _document.Pages.Count;
         _previousPageToolStripMenuItem.Enabled = _currentPageNumber > 1;
         _nextPageToolStripMenuItem.Enabled = _currentPageNumber < pageCount;
         _gotoPageToolStripMenuItem.Enabled = pageCount > 1;
      }

      private void _previousPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         GotoPage(_currentPageNumber - 1, true);
      }

      private void _nextPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         GotoPage(_currentPageNumber + 1, true);
      }

      private void _gotoPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         using (GotoPageDialog dlg = new GotoPageDialog())
         {
            dlg.DocumentPage = _currentPageNumber;
            dlg.DocumentPageCount = _document.Pages.Count;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               GotoPage(dlg.DocumentPage, true);
            }
         }
      }

      private void _interactiveToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         if (_document == null) return;

         ViewerControl.ViewerControlInteractiveMode interactiveMode = _viewerControl.InteractiveMode;

         _selectModeToolStripMenuItem.Checked = (interactiveMode == ViewerControl.ViewerControlInteractiveMode.SelectMode);
         _highlightTextModeToolStripMenuItem.Checked = (interactiveMode == ViewerControl.ViewerControlInteractiveMode.HighlightTextMode);
         _panModeToolStripMenuItem.Checked = (interactiveMode == ViewerControl.ViewerControlInteractiveMode.PanMode);
         _zoomToModeToolStripMenuItem.Checked = (interactiveMode == ViewerControl.ViewerControlInteractiveMode.ZoomToSelectionMode);
      }

      private void _selectModeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode;
      }

      private void _highlightTextModeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.HighlightTextMode;
      }

      private void _panModeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.PanMode;
      }

      private void _zoomToModeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.ZoomToSelectionMode;
      }


      private void _annotationsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         UpdateAnnotationsToolStrip();
      }

      private void UpdateAnnotationsToolStrip()
      {
         if (_document == null) return;

         bool canDoAnnotations = _documentAnnotations.IsAnnotationsVisible && _documentAnnotations.IsEnabled;
         AnnAutomation automation = _documentAnnotations.Automation;

         bool isSignatureObject = (automation.CurrentEditObject != null && automation.CurrentEditObject.Id == AnnObject.None);

         _showAnnotationsToolStripMenuItem.Checked = _documentAnnotations.IsAnnotationsVisible;
         _annotationsObjectToolStripMenuItem.Enabled = _documentAnnotations.IsEnabled;
         _selectNextObjectToolStripMenuItem.Enabled = canDoAnnotations;
         _selectPreviousObjectToolStripMenuItem.Enabled = canDoAnnotations;
         _objectPropertiesToolStripMenuItem.Enabled = canDoAnnotations && (automation.CurrentEditObject != null && !isSignatureObject);
         _objectContentToolStripMenuItem.Enabled = canDoAnnotations && (automation.CurrentEditObject != null && !isSignatureObject);
         _deleteObjectToolStripMenuItem.Enabled = canDoAnnotations && (automation.CanDeleteObjects && !isSignatureObject);
      }

      private void _showAnnotationsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         _documentAnnotations.IsAnnotationsVisible = !_documentAnnotations.IsAnnotationsVisible;
         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode;
         _viewerControl.RasterImageViewer.Invalidate();
         _annotationsControl.Enabled = _documentAnnotations.IsAnnotationsVisible;
      }

      private void _annotationsObjectToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         int currentObjectId = _documentAnnotations.AutomationManagerHelper.AutomationManager.CurrentObjectId;
         foreach (ToolStripMenuItem item in _annotationsObjectToolStripMenuItem.DropDownItems)
         {
            item.Checked = (currentObjectId == (int)item.Tag);
         }
      }

      private void _selectNextObjectToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         if (_documentAnnotations.IsAnnotationsVisible && _documentAnnotations.IsEnabled)
         {
            _documentAnnotations.SelectNextPreviousObject(true);
         }

         UpdateAnnotationsToolStrip();
      }

      private void _selectPreviousObjectToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         if (_documentAnnotations.IsAnnotationsVisible && _documentAnnotations.IsEnabled)
         {
            _documentAnnotations.SelectNextPreviousObject(false);
         }

         UpdateAnnotationsToolStrip();
      }

      private void _objectPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         if (_documentAnnotations.IsAnnotationsVisible && _documentAnnotations.IsEnabled && _documentAnnotations.Automation.CurrentEditObject != null)
         {
            _documentAnnotations.Automation.ShowObjectProperties();
         }
      }

      private void _objectContentToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         if (_documentAnnotations.IsAnnotationsVisible && _documentAnnotations.IsEnabled && _documentAnnotations.Automation.CurrentEditObject != null)
         {
            _documentAnnotations.ShowObjectContent(_documentAnnotations.Automation.CurrentEditObject);
         }
      }

      private void _deleteObjectToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_document == null) return;

         if (_documentAnnotations.IsAnnotationsVisible && _documentAnnotations.IsEnabled && _documentAnnotations.Automation.CanDeleteObjects)
         {
            _documentAnnotations.DeleteSelectedObject();
         }

         UpdateAnnotationsToolStrip();
      }

      private void _aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("PDF Document", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _pagesControl_Action(object sender, ActionEventArgs e)
      {
         switch (e.Action)
         {
            case "PageNumberChanged":
               GotoPage((int)e.Data, true);
               break;

            case "GotoBookmark":
               PDFBookmark bookmark = (PDFBookmark)e.Data;
               GotoLink(bookmark.TargetPageNumber, bookmark.TargetPageFitType, bookmark.TargetZoomPercent);
               break;

            default:
               break;
         }
      }

      private void _viewerControl_Action(object sender, ActionEventArgs e)
      {
         switch (e.Action)
         {
            case "PageNumberChanged":
               GotoPage((int)e.Data, true);
               break;

            case "HighlightText":
               HighlightText((LeadRect)e.Data);
               break;

            case "GotoInternalLink":
               PDFInternalLink internalLink = (PDFInternalLink)e.Data;
               GotoLink(internalLink.TargetPageNumber, internalLink.TargetPageFitType, internalLink.TargetZoomPercent);
               break;

            case "GotoHyperlink":
               PDFHyperlink hyperlink = (PDFHyperlink)e.Data;
               GotoHyperlink(hyperlink.Hyperlink);
               break;

            default:
               break;
         }
      }

      private void _viewerControl_InteractiveModeChanged(object sender, EventArgs e)
      {
         // Let our annotations knows, to enable/disable the toolbar
         if (_documentAnnotations != null)
            _documentAnnotations.InteractiveModeChanged(_viewerControl.InteractiveMode);
      }

      private void UpdateUIState()
      {
         // Update the status of the various UI controls

         bool documentOk = false;
         int pageCount = 1;

         if (_document != null)
         {
            documentOk = true;
            pageCount = _document.Pages.Count;
         }

         _viewerControl.Visible = documentOk;
         _pagesControl.Visible = documentOk && pageCount >= 1;

         _annotationsControl.Visible = documentOk;
         _bottomPanel.Visible = documentOk;

         _editToolStripMenuItem2.Visible = documentOk;
         _viewToolStripMenuItem.Visible = documentOk;
         _pageToolStripMenuItem.Visible = documentOk;
         _interactiveToolStripMenuItem.Visible = documentOk;
         _annotationsToolStripMenuItem.Visible = documentOk;

         _toolStripSeparator1.Visible = documentOk;

         _findToolStripTextBox.Visible = documentOk;
         _findToolStripTextBox.Enabled = _documentText != null;

         _findToolStripTextBox.Visible = documentOk;
         _findToolStripTextBox.Enabled = _documentText != null;

         _findPreviousToolStripButton.Visible = documentOk;
         _findPreviousToolStripButton.Enabled = _documentText != null;

         _findNextToolStripButton.Visible = documentOk;
         _findNextToolStripButton.Enabled = _documentText != null;
      }
      #endregion UI

      private bool Init()
      {
         // Check support required to use this demo
         if (RasterSupport.IsLocked(RasterSupportType.Document))
         {
            Messager.ShowError(this, string.Format(DemosGlobalization.GetResxString(GetType(), "resx_DemoWillExit"), "RasterSupportType.Document"));
            return false;
         }

         _rasterCodecs = new RasterCodecs();

         _demoOptions = DemoOptions.Load();

         _viewerControl.Visible = false;
         _pagesControl.Visible = false;

         _documentAnnotations = new DocumentAnnotations(this);

         _viewerControl.BringToFront();

         UpdateUIState();

         LoadDefaultDocument();

         return true;
      }

      private void LoadDefaultDocument()
      {
         string defaultDocumentFileName = Path.GetFullPath(Path.Combine(DemosGlobal.ImagesFolder, @"Leadtools.pdf"));
         if (File.Exists(defaultDocumentFileName))
         {
            if (Messager.ShowQuestion(this, string.Format(DemosGlobalization.GetResxString(GetType(), "resx_OpenDefault"), defaultDocumentFileName), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               OpenDocument(defaultDocumentFileName);
            }
         }
      }

      private void CleanUp()
      {
         _demoOptions.Save();

         _pagesControl.StopLoadingThumbnails();

         // Delete all resources
         if (_document != null)
         {
            _document.Dispose();
            _document = null;
         }

         _selectedText = null;
         _findTextHelper = null;
         _documentText = null;
      }

      private void OpenDocument()
      {
         using (OpenFileDialog dlg = new OpenFileDialog())
         {
            if (string.IsNullOrEmpty(_demoOptions.OpenCommonDialogFolder) || !Directory.Exists(_demoOptions.OpenCommonDialogFolder))
            {
               _demoOptions.OpenCommonDialogFolder = DemosGlobal.ImagesFolder;
            }

            dlg.InitialDirectory = _demoOptions.OpenCommonDialogFolder;

            dlg.Filter = "PDF Documents (*.pdf)|*.pdf|All Files|*.*";
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
               string dir = Path.GetDirectoryName(dlg.FileName);
               if (Directory.Exists(dir))
               {
                  _demoOptions.OpenCommonDialogFolder = dir;
               }

               OpenDocument(dlg.FileName);
            }
         }
      }

      private void OpenDocument(string fileName)
      {
         using (LoadDocument.LoadDocumentDialog dlg = new LoadDocument.LoadDocumentDialog(fileName))
         {
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               try
               {
                  using (WaitCursor wait = new WaitCursor())
                  {
                     PDFDocument document = dlg.PDFDocument;

                     // Parse the document text
                     Dictionary<int, MyWord[]> documentText = MyWord.BuildWord(document);

                     // Initialize the document with annotations
                     SetDocument(document, documentText, fileName);
                  }
               }
               catch (Exception ex)
               {
                  Messager.ShowError(this, ex.Message);
               }
               finally
               {
                  UpdateUIState();
               }
            }
         }
      }

      private void SetDocument(PDFDocument document, Dictionary<int, MyWord[]> documentText, string documentName)
      {
         this.SuspendLayout();

         try
         {
            // Stop the thumbnails generator if it is running
            _pagesControl.StopLoadingThumbnails();

            if (_document != null)
            {
               _document.Dispose();
               _document = null;
            }

            _documentText = null;

            _document = document;
            _documentAnnotations.SetDocument(document);

            if (_document != null)
            {
               _selectedText = new Dictionary<int, MyWord[]>();
               _findTextHelper = new FindTextHelper();
               _documentText = new Dictionary<int, MyWord[]>();

               for (int pageNumber = 1; pageNumber <= _document.Pages.Count; pageNumber++)
               {
                  _selectedText.Add(pageNumber, null);
                  _documentText.Add(pageNumber, null);
               }
            }
            else
            {
               _selectedText = null;
               _findTextHelper = null;
            }

            _viewerControl.SetDocument(_document, _selectedText);
            _pagesControl.SetDocument(_document);

            if (_document != null)
            {
               // Build words
               _documentText = documentText;

               _viewerControl.Visible = true;

               if (_document.Pages.Count > 1)
               {
                  _pagesControl.SetCurrentPageNumber(1);
                  _pagesControl.Visible = true;
               }

               Text = string.Format("{0} - {1}", documentName, Messager.Caption);

               GotoPage(1, true);
            }
            else
            {
               Text = Messager.Caption;
            }
         }
         finally
         {
            this.ResumeLayout();
         }
      }

      private void CloseDocument()
      {
         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               SetDocument(null, null, null);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex.Message);
         }
         finally
         {
            UpdateUIState();
         }
      }

      private void SaveDocument(string fileName)
      {
         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               _documentAnnotations.SaveDocument(fileName);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void ShowDocumentProperties()
      {
         using (DocumentPropertiesDialog dlg = new DocumentPropertiesDialog(_document, null))
         {
            dlg.ShowDialog(this);
         }
      }

      public void GotoPage(int pageNumber, bool resetFindText)
      {
         if (_document == null || pageNumber <= 0) return;

         try
         {
            _viewerControl.HighlightSelectedImageObject = false;
            using (WaitCursor wait = new WaitCursor())
            {
               DocumentAnnotations.SetRasterCodecsOptions(_document, _rasterCodecs, pageNumber);
               RasterImage pageImage = _document.GetPageImage(_rasterCodecs, pageNumber);

               _currentPageNumber = pageNumber;

               _pagesControl.SetCurrentPageNumber(pageNumber);
               _viewerControl.SetCurrentPageNumber(pageNumber, pageImage);
               _documentAnnotations.SetCurrentPageNumber(pageNumber);
               //set function will hide/show objects
               _documentAnnotations.IsAnnotationsVisible = _documentAnnotations.IsAnnotationsVisible;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            if (resetFindText)
            {
               _findTextHelper.Reset();
            }

            UpdateUIState();
         }
      }

      private string BuildPageText(MyWord[] words)
      {
         if (words == null || words.Length == 0) return string.Empty;

         StringBuilder sb = new StringBuilder();
         for (int i = 0; i < words.Length; i++)
         {
            MyWord word = words[i];
            sb.Append(word.Value);

            if (word.IsEndOfLine)
            {
               sb.AppendLine();
            }
            else if (i != (words.Length - 1))
            {
               sb.Append(" ");
            }
         }

         return sb.ToString();
      }

      private void ExportDocumentText()
      {
         using (SaveFileDialog dlg = new SaveFileDialog())
         {
            dlg.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
               StringBuilder sb = new StringBuilder();

               foreach (PDFDocumentPage page in _document.Pages)
               {
                  string text = string.Empty;
                  if (_documentText[page.PageNumber] != null)
                  {
                     text = BuildPageText(_documentText[page.PageNumber]);
                  }

                  sb.Append(text);

                  if (!text.EndsWith(Environment.NewLine))
                  {
                     sb.AppendLine();
                  }

                  File.WriteAllText(dlg.FileName, sb.ToString());
               }
            }
         }
      }

      private void CopySelectedText()
      {
         // Convert the selected words to a single string

         MyWord[] words = _selectedText[_currentPageNumber];
         if (words != null)
         {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
               MyWord word = words[i];
               sb.Append(word.Value);

               if (word.IsEndOfLine)
               {
                  sb.AppendLine();
               }
               else if (i != (words.Length - 1))
               {
                  sb.Append(" ");
               }
            }

            Clipboard.SetText(sb.ToString());
         }
      }

      private void SelectAllText()
      {
         if (_document == null || _documentText[_currentPageNumber] == null) return;

         // Get the text for the current page

         _selectedText[_currentPageNumber] = new MyWord[_documentText[_currentPageNumber].Length];
         _documentText[_currentPageNumber].CopyTo(_selectedText[_currentPageNumber], 0);
         // Select it all (by replacing the selected text for the page for all text in the page)
         // Re-paint the viewer
         _viewerControl.RasterImageViewer.Invalidate();
      }

      public void ClearTextSelection()
      {
         if (_document == null) return;

         // Clear the selected text of the current page
         _selectedText[_currentPageNumber] = null;
         // Re-paint the viewer
         _viewerControl.RasterImageViewer.Invalidate();
      }

      public void HighlightText(LeadRect bounds)
      {
         if (_document == null || _documentText == null || _documentText[_currentPageNumber] == null) return;

         // Select new text
         IList<MyWord> allWords = _documentText[_currentPageNumber];
         List<MyWord> selectedWords = new List<MyWord>();

         if (allWords != null)
         {
            foreach (MyWord word in allWords)
            {
               if (word.Bounds.IntersectsWith(bounds))
               {
                  selectedWords.Add(word);
               }
            }
         }

         // Set the new words
         _selectedText[_currentPageNumber] = selectedWords.ToArray();
         // Re-paint the viewer
         _viewerControl.RasterImageViewer.Invalidate();
      }

      private void FindText(bool next)
      {
         string textToFind = _findToolStripTextBox.Text;
         bool textFound = _findTextHelper.FindText(_documentText, _currentPageNumber, _document.Pages.Count, _findToolStripTextBox.Text, next);
         if (textFound)
         {
            int textPageNumber = _findTextHelper.GotoPageNumber;
            _selectedText[textPageNumber] = _findTextHelper.GetSelectedWords();

            if (textPageNumber != _currentPageNumber)
            {
               GotoPage(textPageNumber, false);
            }
         }
         else
         {
            for (int pageNumber = 1; pageNumber <= _document.Pages.Count; pageNumber++)
            {
               _selectedText[pageNumber] = null;
            }

            Messager.ShowInformation(this, string.Format(DemosGlobalization.GetResxString(GetType(), "resx_NotFound"), textToFind));
         }

         _viewerControl.RasterImageViewer.Invalidate();
      }

      private void GotoLink(int pageNumber, PDFPageFitType pageFitType, int zoomPercent)
      {
         if (pageNumber >= 1 && pageNumber <= _document.Pages.Count)
         {
            if (_currentPageNumber != pageNumber)
            {
               GotoPage(pageNumber, true);
            }

            _viewerControl.RunLink(_document, pageFitType, zoomPercent);
         }
      }

      private void GotoHyperlink(string hyperlink)
      {
         if (!string.IsNullOrEmpty(hyperlink))
         {
            if (Uri.IsWellFormedUriString(hyperlink, UriKind.RelativeOrAbsolute))
            {
               try
               {
                  System.Diagnostics.Process.Start(hyperlink);
               }
               catch (Exception ex)
               {
                  Messager.ShowError(this, ex);
               }
            }
            else
            {
               Messager.ShowWarning(this, string.Format(DemosGlobalization.GetResxString(GetType(), "resx_HyperlinkValNotWellFormatted"), hyperlink));
            }
         }
      }

      public bool IsTextSelected
      {
         get
         {
            return _documentText != null && _selectedText[_currentPageNumber] != null && _selectedText[_currentPageNumber].Length > 0;
         }
      }

      public AutomationImageViewer AnnotationsViewer
      {
         get { return _viewerControl.RasterImageViewer; }
      }

      public AnnotationsControl AnnotationsControl
      {
         get { return _annotationsControl; }
      }

      public ToolStripMenuItem AnnotationsMenuItem
      {
         get { return _annotationsObjectToolStripMenuItem; }
      }

      public Dictionary<int, MyWord[]> SelectedText
      {
         get { return _selectedText; }
      }
   }
}
