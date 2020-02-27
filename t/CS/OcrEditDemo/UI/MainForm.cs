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
using System.Drawing.Drawing2D;
using System.Diagnostics;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Controls;
using Leadtools.Ocr;
using Leadtools.Document.Writer;
using Leadtools.Drawing;

namespace OcrEditDemo
{
   public partial class MainForm : Form
   {
      // The RasterCodecs instance used to load/save images
      private RasterCodecs _rasterCodecs;
      // The OCR engine instance used in this demo
      private IOcrEngine _ocrEngine;
      // The current OCR document
      private IOcrDocument _ocrDocument;
      // The current OCR page in the viewer
      private IOcrPage _ocrPage;
      // The current recognized characters
      private IOcrPageCharacters _ocrPageCharacters;
      // The current recognized words
      private List<List<OcrWord>> _ocrZoneWords;
      // Selected word index into _ocrZoneWords
      private int _selectedZoneIndex;
      // Selected word index into the _ocrZoneWords[_selectedZoneIndex];
      private int _selectedWordIndex;

      // Last document we opened correctly
      private string _lastDocumentFile;
      // Minimum and maximum scale percentages allowed
      private const double _minimumViewerScalePercentage = 1;
      private const double _maximumViewerScalePercentage = 6400;
      // Extra pixels to edge around the word when clicking/highlighting
      private const int _wordEdge = 2;

      private string _openInitialPath = string.Empty;

      #region Main Form code
      public MainForm()
      {
         InitializeComponent();

         // Setup the caption for this demo
         Messager.Caption = "C# OCR Edit Demo";

         // Initialize the RasterCodecs object
         _rasterCodecs = new RasterCodecs();

         //  Use the new RasterizeDocumentOptions to default loading document files at 300 DPI
         _rasterCodecs.Options.RasterizeDocument.Load.XResolution = 300;
         _rasterCodecs.Options.RasterizeDocument.Load.YResolution = 300;
         _rasterCodecs.Options.Pdf.Load.EnableInterpolate = true;
         _rasterCodecs.Options.Load.AutoFixImageResolution = true;

         if (!DesignMode)
         {
            // Use ScaleToGray and Bicubic for optimum viewing of black/white and color images
            RasterPaintProperties props = _imageViewer.PaintProperties;
            props.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray | RasterPaintDisplayModeFlags.Bicubic;
            _imageViewer.PaintProperties = props;

            // Pad the viewer
            _imageViewer.ViewPadding = new Padding(10);

            _imageViewer.Zoom(ControlSizeMode.Fit, 1, _imageViewer.DefaultZoomOrigin);

            // These events are needed and not visible from the designer, so
            // hook into them here
            _zoomToolStripComboBox.LostFocus += new EventHandler(_zoomToolStripComboBox_LostFocus);

            // Call the transform changed event
            _imageViewer_TransformChanged(_imageViewer, EventArgs.Empty);

            _mousePositionLabel.Text = string.Empty;
         }
      }

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
         Properties.Settings settings = new Properties.Settings();

         // Show the OCR engine selection dialog to startup the OCR engine
         string engineType = settings.OcrEngineType;

         using (OcrEngineSelectDialog dlg = new OcrEngineSelectDialog(Messager.Caption, engineType, true))
         {
            // Use the same RasterCodecs instance in the OCR engine
            dlg.RasterCodecsInstance = _rasterCodecs;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _ocrEngine = dlg.OcrEngine;

               if (_ocrEngine.SettingManager.IsSettingNameSupported("Recognition.SpaceIsValidCharacter"))
                  _ocrEngine.SettingManager.SetBooleanValue("Recognition.SpaceIsValidCharacter", false);

               Text = string.Format("{0} [{1} Engine]", Messager.Caption, _ocrEngine.EngineType.ToString());

               // Load the default document
               string defaultDocumentFile;
               if (_ocrEngine.EngineType == OcrEngineType.OmniPageArabic)
                  defaultDocumentFile = Path.Combine(DemosGlobal.ImagesFolder, "ArabicSample.tif");
               else
                  defaultDocumentFile = Path.Combine(DemosGlobal.ImagesFolder, "ocr1.tif");

               if (File.Exists(defaultDocumentFile))
                  OpenDocument(defaultDocumentFile);

               UpdateUIState();
            }
            else
            {
               // Close the demo
               Close();
            }
         }
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         // Clean up

         // Save the last setting
         Properties.Settings settings = new Properties.Settings();
         if (_ocrEngine != null)
            settings.OcrEngineType = _ocrEngine.EngineType.ToString();

         settings.Save();

         if (_ocrDocument != null)
         {
            _ocrDocument.Dispose();
            _ocrDocument = null;
         }

         // Dispose the OCR engine (this will call Shutdown as well)
         if (_ocrEngine != null)
         {
            _ocrEngine.Dispose();
            _ocrEngine = null;
         }

         if (_rasterCodecs != null)
         {
            _rasterCodecs.Dispose();
            _rasterCodecs = null;
         }

         base.OnFormClosed(e);
      }
      #endregion Main Form code

      #region Tools

      private void DoShowError(Exception ex)
      {
         BeginInvoke(new MethodInvoker(delegate()
         {
            // Shows an error, check if the exception is an OCR, raster or general one
            OcrException oe = ex as OcrException;
            if (oe != null)
               Messager.ShowError(this, string.Format("LEADTOOLS Error\n\nCode: {0}\n\n{1}", oe.Code, ex.Message));
            else
            {
               RasterException re = ex as RasterException;
               if (re != null)
                  Messager.ShowError(this, string.Format("OCR Error\n\nCode: {0}\n\n{1}", re.Code, ex.Message));
               else
                  Messager.ShowError(this, ex);
            }
         }));
      }

      private delegate void ShowErrorDelegate(Exception ex);

      private void ShowError(Exception ex)
      {
         if (InvokeRequired)
            BeginInvoke(new ShowErrorDelegate(DoShowError), new object[] { ex });
         else
            DoShowError(ex);
      }

      private void UpdateUIState()
      {
         // Update the UI controls states

         _fitPageWidthToolStripButton.Checked = _imageViewer.SizeMode == ControlSizeMode.FitWidth;
         _fitPageToolStripButton.Checked = _imageViewer.SizeMode == ControlSizeMode.Fit;

         bool imageOk = _imageViewer.Image != null;

         _openToolStripButton.Enabled = true;
         _saveToolStripButton.Enabled = imageOk;
         _fitPageWidthToolStripButton.Enabled = imageOk;
         _fitPageToolStripButton.Enabled = imageOk;
         _zoomToolStripComboBox.Enabled = imageOk;
         _zoomOutToolStripButton.Enabled = imageOk;
         _zoomInToolStripButton.Enabled = imageOk;

         _controlsPanel.Enabled = imageOk;

         if (!imageOk)
            _zoomToolStripComboBox.Text = string.Empty;

         _highlightWordsToolStripButton.Enabled = imageOk;

         bool wordIsSelected = _selectedZoneIndex != -1 && _selectedWordIndex != -1;

         _deleteButton.Enabled = imageOk && wordIsSelected;
         _updateButton.Enabled = imageOk && wordIsSelected && _wordTextBox.Text.Trim().Length > 0;

         _deleteWordToolStripButton.Enabled = _deleteButton.Enabled;
         _updateWordToolStripButton.Enabled = _updateButton.Enabled;
      }
      #endregion Tools

      #region File Menu handlers
      private void _fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         bool documentOk = _ocrPage != null;

         _fileSaveToolStripMenuItem.Enabled = documentOk;
      }

      private void _fileOpenToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Open a document from disk

         // Show the LEADTOOLS common dialog
         ImageFileLoader loader = new ImageFileLoader();
         loader.LoadOnlyOnePage = true;
         loader.ShowLoadPagesDialog = false;
         loader.OpenDialogInitialPath = _openInitialPath;

         try
         {
            // Insert the pages loader into the document
            if (loader.Load(this, _rasterCodecs, false) > 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               OpenDocument(loader.FileName);
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
      }

      private void _fileSaveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Show the save file dialog
         using (SaveFileDialog dlg = new SaveFileDialog())
         {
            string friendlyName = DocumentWriter.GetFormatFriendlyName(DocumentFormat.Pdf);
            string extension = DocumentWriter.GetFormatFileExtension(DocumentFormat.Pdf);

            dlg.Filter = string.Format("{0} Documents (*.{1})|*.{1}|All Files|*.*", friendlyName, extension);

            if (!string.IsNullOrEmpty(_lastDocumentFile))
               dlg.FileName = Path.ChangeExtension(_lastDocumentFile, extension);

            if (dlg.ShowDialog(this) == DialogResult.OK)
               SaveDocument(dlg.FileName);
         }
      }

      private void _fileExitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }
      #endregion File Menu handlers

      #region View Menu handlers
      private void _viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update the UI state of the View menu items

         bool documentOk = _ocrPage != null;

         _viewZoomOutToolStripMenuItem.Enabled = documentOk;
         _viewZoomInToolStripMenuItem.Enabled = documentOk;

         _viewFitWidthToolStripMenuItem.Enabled = documentOk;
         _viewFitPageToolStripMenuItem.Enabled = documentOk;
         _viewHighlightRecognizedWordsToolStripMenuItem.Enabled = documentOk;

         _viewFitWidthToolStripMenuItem.Checked = documentOk && (_imageViewer.SizeMode == ControlSizeMode.FitWidth);
         _viewFitPageToolStripMenuItem.Checked = documentOk && (_imageViewer.SizeMode == ControlSizeMode.Fit);
      }

      private void _viewZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ZoomViewer(true);
      }

      private void _viewZoomInToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ZoomViewer(false);
      }

      private void _viewFitWidthToolStripMenuItem_Click(object sender, EventArgs e)
      {
         FitPage(true);
      }

      private void _viewFitPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         FitPage(false);
      }

      private void _viewHighlightRecognizedWordsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _highlightWordsToolStripButton.Checked = _viewHighlightRecognizedWordsToolStripMenuItem.Checked;
         _imageViewer.Invalidate();
      }
      #endregion View Menu handlers

      #region Words menu handlers
      private void _wordToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update the UI state of the Words menu items
         _wordUpdateToolStripMenuItem.Enabled = _updateButton.Enabled;
         _wordDeleteToolStripMenuItem.Enabled = _deleteButton.Enabled;
      }

      private void _wordUpdateToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _updateButton.PerformClick();
      }

      private void _wordDeleteToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _deleteButton.PerformClick();
      }

      #endregion Words menu handlers

      #region Preferences Menu handlers
      private void _preferencesPdfResolutionToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (LoadResolutionDialog dlg = new LoadResolutionDialog(_rasterCodecs))
            dlg.ShowDialog(this);
      }
      #endregion Preferences Menu handlers

      #region Help Menu handlers
      private void _helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("OCR Edit", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }
      #endregion Help Menu handlers

      #region Viewer code
      private void SetImage(RasterImage image)
      {
         _imageViewer.Image = image;

         UpdateUIState();
      }

      public void FitPage(bool fitWidth)
      {
         // Since we are doing more than one operation on the viewer, it is
         // recommended to disable then re-enable updates on the viewer to
         // minimize flickering

         _imageViewer.BeginUpdate();

         ControlSizeMode sizeMode = ControlSizeMode.Fit;

         if (fitWidth)
            sizeMode = ControlSizeMode.FitWidth;

         _imageViewer.Zoom(sizeMode, 1, _imageViewer.DefaultZoomOrigin);

         _imageViewer.EndUpdate();

         UpdateUIState();
      }

      private void ZoomViewer(bool zoomOut)
      {
         // Get the current scale factor
         double percentage = _imageViewer.XScaleFactor * 100.0;

         // The valid scale factors are here
         double[] validPercentages =
         {
            _minimumViewerScalePercentage, 6.25, 12.5, 25, 33.3, 50, 66.7, 73.6, 92.5, 100,
            125, 150, 200, 300, 400, 600, 800, 1200, 1600, 2400,
            3200, _maximumViewerScalePercentage
         };

         // Find out where we are, move to the next one up or down depending on 'zoomOut'
         if (zoomOut)
         {
            for (int i = validPercentages.Length - 1; i >= 0; i--)
            {
               if (percentage > validPercentages[i])
               {
                  percentage = validPercentages[i];
                  break;
               }
            }
         }
         else
         {
            for (int i = 0; i < validPercentages.Length; i++)
            {
               if (percentage < validPercentages[i])
               {
                  percentage = validPercentages[i];
                  break;
               }
            }
         }

         SetViewerZoomPercentage(percentage);
      }

      private void UpdateZoomValueFromControl()
      {
         // We are invoking this instead of changing the properties
         // directly because the Text value of a combo box is not
         // updated till after the lost focus or enter event is exited
         BeginInvoke(new MethodInvoker(delegate()
         {
            if (_imageViewer.Image != null)
            {
               double factor = _imageViewer.XScaleFactor * 100.0;
               _zoomToolStripComboBox.Text = factor.ToString("F1") + "%";
            }
            else
            {
               _zoomToolStripComboBox.Text = string.Empty;
            }
         }));
      }

      private void _imageViewer_TransformChanged(object sender, EventArgs e)
      {
         if (IsHandleCreated)
         {
            UpdateZoomValueFromControl();
            UpdateUIState();
         }
      }

      private void _openToolStripButton_Click(object sender, EventArgs e)
      {
         _fileOpenToolStripMenuItem.PerformClick();
      }

      private void _saveToolStripButton_Click(object sender, EventArgs e)
      {
         _fileSaveToolStripMenuItem.PerformClick();
      }

      private void _zoomOutToolStripButton_Click(object sender, EventArgs e)
      {
         ZoomViewer(true);
      }

      private void _zoomInToolStripButton_Click(object sender, EventArgs e)
      {
         ZoomViewer(false);
      }

      private void _zoomToolStripComboBox_LostFocus(object sender, EventArgs e)
      {
         UpdateZoomValueFromControl();
      }

      private void _zoomToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Parse the new zoom value
         string str = _zoomToolStripComboBox.Text.Trim();

         switch (str)
         {
            case "Actual Size":
               SetViewerZoomPercentage(100);
               break;

            case "Fit Page":
               _fitPageToolStripButton.PerformClick();
               break;

            case "Fit Width":
               _fitPageWidthToolStripButton.PerformClick();
               break;

            default:
               if (!string.IsNullOrEmpty(str))
               {
                  double val = double.Parse(str.Substring(0, str.Length - 1));
                  SetViewerZoomPercentage(val);
               }
               break;
         }
      }

      private void _zoomToolStripComboBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == (char)Keys.Return)
         {
            // User has pressed enter, parse the new zoom value

            string str = _zoomToolStripComboBox.Text.Trim();

            if (!string.IsNullOrEmpty(str))
            {
               // Remove the % sign if present
               if (str.EndsWith("%"))
                  str = str.Remove(str.Length - 1, 1).Trim();

               // Try to parse the new zoom value
               double percentage;
               if (double.TryParse(str, out percentage))
                  SetViewerZoomPercentage(percentage);

               UpdateZoomValueFromControl();
            }
         }
      }

      private void _fitPageWidthToolStripButton_Click(object sender, EventArgs e)
      {
         FitPage(true);
      }

      private void _fitPageToolStripButton_Click(object sender, EventArgs e)
      {
         FitPage(false);
      }

      private void _highlightWordsToolStripButton_Click(object sender, EventArgs e)
      {
         _viewHighlightRecognizedWordsToolStripMenuItem.Checked = _highlightWordsToolStripButton.Checked;
         _imageViewer.Invalidate();
      }

      private void _updateWordToolStripButton_Click(object sender, EventArgs e)
      {
         _updateButton.PerformClick();
      }

      private void _deleteWordToolStripButton_Click(object sender, EventArgs e)
      {
         _deleteButton.PerformClick();
      }

      private void SetViewerZoomPercentage(double percentage)
      {
         // Normalize the percentage based on min/max value allowed
         percentage = Math.Max(_minimumViewerScalePercentage, Math.Min(_maximumViewerScalePercentage, percentage));

         if (Math.Abs(_imageViewer.XScaleFactor * 100.0 - percentage) > 0.01)
         {
            _imageViewer.BeginUpdate();

            // Zoom
            double scaleFactor = percentage / 100.0;

            _imageViewer.Zoom(ControlSizeMode.None, scaleFactor, _imageViewer.DefaultZoomOrigin);

            _imageViewer.EndUpdate();

            _imageViewer_TransformChanged(_imageViewer, EventArgs.Empty);

            UpdateUIState();
         }
      }

      private void _imageViewer_MouseMove(object sender, MouseEventArgs e)
      {
         string str;

         if (_imageViewer.Image != null)
         {
            // Show the mouse position in physical and logical (inches) coordinates

            LeadPoint physical = LeadPoint.Create(e.X, e.Y);
            LeadPoint pixels = _imageViewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, physical);
            str = string.Format("{0},{1} px", (int)pixels.X, (int)pixels.Y);
         }
         else
            str = string.Empty;

         _mousePositionLabel.Text = str;
      }
      #endregion Viewer code

      #region OCR open/recognize and save code
      private void OpenDocument(string documentFileName)
      {
         // Create a new document, add the page to it and recognize it
         // If all the above is OK, then use it

         // Setup the arguments for the callback
         Dictionary<string, object> args = new Dictionary<string, object>();
         args.Add("documentFileName", documentFileName);

         // Call the process dialog
         try
         {
            bool allowProgress = _preferencesUseCallbacksToolStripMenuItem.Checked;
            using (OcrProgressDialog dlg = new OcrProgressDialog(allowProgress, "Loading and Recognizing Document", new OcrProgressDialog.ProcessDelegate(DoLoadAndRecognizeDocument), args))
            {
               dlg.ShowDialog(this);
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
         finally
         {
            UpdateUIState();
         }
      }

      private void DoLoadAndRecognizeDocument(OcrProgressDialog dlg, Dictionary<string, object> args)
      {
         // Perform load and recognize here

         OcrProgressCallback callback = dlg.OcrProgressCallback;
         IOcrDocument ocrDocument = null;

         try
         {
            string documentFileName = args["documentFileName"] as string;

            ocrDocument = _ocrEngine.DocumentManager.CreateDocument("", OcrCreateDocumentOptions.InMemory);

            IOcrPage ocrPage = null;

            if (!dlg.IsCanceled)
            {
               // If we are not using a progress bar, update the description text
               if (callback == null)
                  dlg.UpdateDescription("Loading the document (first page only)...");

               ocrPage = ocrDocument.Pages.AddPage(documentFileName, callback);
            }

            if (!dlg.IsCanceled)
            {
               // If we are not using a progress bar, update the description text
               if (callback == null)
                  dlg.UpdateDescription("Recognizing the page(s) of the document...");

               ocrPage.Recognize(callback);
            }

            if (!dlg.IsCanceled)
            {
               // We did not cancel, use this document
               SetDocument(ocrDocument, documentFileName);
               ocrDocument = null;
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
         finally
         {
            if (callback == null)
               dlg.EndOperation();

            // Clean up
            if (ocrDocument != null)
               ocrDocument.Dispose();
         }
      }

      private void SaveDocument(string documentFileName)
      {
         // Update the characters from what we have so far
         // The word is remove now from the OCR results
         _ocrPage.SetRecognizedCharacters(_ocrPageCharacters);

         // Save this document as PDF

         // Setup the arguments for the callback
         Dictionary<string, object> args = new Dictionary<string, object>();
         args.Add("documentFileName", documentFileName);
         args.Add("viewDocument", _preferencesViewSavedDocumentToolStripMenuItem.Checked);

         // Call the process dialog
         try
         {
            bool allowProgress = _preferencesUseCallbacksToolStripMenuItem.Checked;
            using (OcrProgressDialog dlg = new OcrProgressDialog(allowProgress, "Saving Document", new OcrProgressDialog.ProcessDelegate(DoSaveDocument), args))
            {
               dlg.ShowDialog(this);
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
         finally
         {
            UpdateUIState();
         }
      }

      private void DoSaveDocument(OcrProgressDialog dlg, Dictionary<string, object> args)
      {
         // Perform load and recognize here

         OcrProgressCallback callback = dlg.OcrProgressCallback;

         try
         {
            string documentFileName = args["documentFileName"] as string;
            bool viewDocument = (bool)args["viewDocument"];

            if (!dlg.IsCanceled)
            {
               // If we are not using a progress bar, update the description text
               if (callback == null)
                  dlg.UpdateDescription("Saving the document ...");

               PdfDocumentOptions pdfOptions = _ocrDocument.DocumentWriterInstance.GetOptions(DocumentFormat.Pdf) as PdfDocumentOptions;
               pdfOptions.Producer = "LEAD Technologies, Inc.";
               pdfOptions.Creator = "LEADTOOLS PDFWriter";
               _ocrDocument.DocumentWriterInstance.SetOptions(DocumentFormat.Pdf, pdfOptions);
               _ocrDocument.Save(documentFileName, DocumentFormat.Pdf, callback);
            }

            // If it has not been canceled, show the final document (if applicable)
            if (!dlg.IsCanceled && viewDocument)
               Process.Start(documentFileName);
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
         finally
         {
            if (callback == null)
               dlg.EndOperation();
         }
      }

      private void SetDocument(IOcrDocument ocrDocument, string documentFileName)
      {
         // Delete the old document if it exists
         if (_ocrDocument != null)
            _ocrDocument.Dispose();

         _lastDocumentFile = documentFileName;
         _ocrDocument = ocrDocument;
         _ocrPage = _ocrDocument.Pages[0];

         BuildWordLists();

         _wordTextBox.Text = string.Empty;

         SetImage(_ocrPage.GetRasterImage());

         UpdateUIState();
      }
      #endregion OCR open/recognize and save code

      private void BuildWordLists()
      {
         _ocrPageCharacters = _ocrPage.GetRecognizedCharacters();
         _ocrZoneWords = new List<List<OcrWord>>();

         // Build the words
         foreach (IOcrZoneCharacters zoneCharacters in _ocrPageCharacters)
         {
            List<OcrWord> words = new List<OcrWord>();
            words.AddRange(zoneCharacters.GetWords());

            _ocrZoneWords.Add(words);
         }

         _selectedZoneIndex = -1;
         _selectedWordIndex = -1;
      }

      private void _imageViewer_MouseClick(object sender, MouseEventArgs e)
      {
         if (_imageViewer.Image == null)
            return;

         // Get the mouse click in logical coordinates (page) and select the word under this point (if any)

         LeadPoint physical = LeadPoint.Create(e.X, e.Y);
         LeadPoint pixels = _imageViewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, physical);

         FindWordUnderPoint(pixels);
      }

      private void FindWordUnderPoint(LeadPoint pt)
      {
         foreach (List<OcrWord> zoneWords in _ocrZoneWords)
         {
            for (int wordIndex = 0; wordIndex < zoneWords.Count; wordIndex++)
            {
               OcrWord word = zoneWords[wordIndex];

               RectangleF rc = Leadtools.Demos.Converters.ConvertRect(word.Bounds);
               rc.Inflate(_wordEdge, _wordEdge);

               if (rc.Contains(new PointF(pt.X, pt.Y)))
               {
                  // Found a word, select it and exit
                  SelectWord(_ocrZoneWords.IndexOf(zoneWords), wordIndex, word);
                  return;
               }
            }
         }

         // No word was selected, de-select the last word
         SelectWord(-1, -1, new OcrWord());
      }

      private void SelectWord(int wordZoneIndex, int wordIndex, OcrWord word)
      {
         _selectedZoneIndex = wordZoneIndex;
         _selectedWordIndex = wordIndex;
         _wordTextBox.Text = word.Value;

         _imageViewer.Invalidate();
         UpdateUIState();
      }

      private void _imageViewer_PostRender(object sender, ImageViewerRenderEventArgs e)
      {
         if (_imageViewer.Image == null)
            return;

         Graphics g = e.PaintEventArgs.Graphics;

         if (_viewHighlightRecognizedWordsToolStripMenuItem.Checked)
         {
            // Highlight all words
            using (Brush b = new SolidBrush(Color.FromArgb(64, Color.Black)))
            {
               using (Pen p = new Pen(Color.FromArgb(64, Color.Black)))
               {
                  for (int zoneIndex = 0; zoneIndex < _ocrZoneWords.Count; zoneIndex++)
                  {
                     List<OcrWord> zoneWords = _ocrZoneWords[zoneIndex];
                     for (int wordIndex = 0; wordIndex < zoneWords.Count; wordIndex++)
                     {
                        // Only draw this if it is not the selected word
                        // This will be painted later
                        if (zoneIndex != _selectedZoneIndex || wordIndex != _selectedWordIndex)
                           HighlightWord(g, zoneIndex, wordIndex, b, p);
                     }
                  }
               }
            }
         }

         // If we have a word selected, highlight it
         if (_selectedZoneIndex != -1 && _selectedWordIndex != -1)
         {
            using (Brush b = new SolidBrush(Color.FromArgb(128, Color.Yellow)))
            {
               using (Pen p = new Pen(Color.FromArgb(128, Color.Red)))
               {
                  HighlightWord(g, _selectedZoneIndex, _selectedWordIndex, b, p);
               }
            }
         }
      }

      private void HighlightWord(Graphics g, int zoneIndex, int wordIndex, Brush b, Pen p)
      {
         OcrWord word = _ocrZoneWords[zoneIndex][wordIndex];

         // Get the word bounding rectangle and convert to physical so we can draw it on the viewer surface
         LeadRect rc = LeadRectD.FromLTRB(word.Bounds.Left, word.Bounds.Top, word.Bounds.Right, word.Bounds.Bottom).ToLeadRect();

         rc = _imageViewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rc);

         // Make the rectangle a little bit bigger for visibility purposes
         rc.Inflate(_wordEdge, _wordEdge);

         g.FillRectangle(b, Leadtools.Demos.Converters.ConvertRect(rc));
         g.DrawRectangle(p, rc.X, rc.Y, rc.Width - 1, rc.Height - 1);
      }

      private void _updateButton_Click(object sender, EventArgs e)
      {
         UpdateWord(_wordTextBox.Text);
      }

      private void _deleteButton_Click(object sender, EventArgs e)
      {
         // null will delete a word
         UpdateWord(null);
      }

      private void _wordTextBox_TextChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void UpdateWord(string value)
      {
         _ocrPageCharacters.UpdateWord(
            _ocrZoneWords[_selectedZoneIndex],
            _selectedZoneIndex,
            _selectedWordIndex,
            value);

         if (value != null)
         {
            // Word has been updated, invalidate
            _imageViewer.Invalidate();
            UpdateUIState();
         }
         else
         {
            // Word is deleted, remove selection
            SelectWord(-1, -1, new OcrWord());
         }
      }
   }
}
