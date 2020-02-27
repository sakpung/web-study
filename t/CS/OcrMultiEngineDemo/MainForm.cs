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
using System.Diagnostics;

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Twain;
using Leadtools.Codecs;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Effects;
using Leadtools.Ocr;
using Leadtools.Document.Writer;
using Leadtools.Controls;
using Leadtools.Annotations.Engine;
using OcrMultiEngineDemo.ViewerControl;

namespace OcrMultiEngineDemo
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
      // View document on successful recognition
      private bool _viewDocument = true;
      // The twain session used for scanning
      private TwainSession _twainSession;

      private bool _omrOptionsDismissed;
      private string _openInitialPath = string.Empty;
      private string _fileName;
      private bool _isCustomFileName = false;
      private string _outputDir = String.Empty;

      public static bool PerspectiveDeskewActive = false;
      public static bool UnWarpActive = false;

      public MainForm()
      {
         InitializeComponent();

         // Setup the caption for this demo
         Messager.Caption = "C# OCR Multi-Engine Demo";

         // Initialize the RasterCodecs object
         _rasterCodecs = new RasterCodecs();

         // Use the new RasterizeDocumentOptions to default loading document files at 300 DPI
         _rasterCodecs.Options.RasterizeDocument.Load.XResolution = 300;
         _rasterCodecs.Options.RasterizeDocument.Load.YResolution = 300;
         _rasterCodecs.Options.Pdf.Load.EnableInterpolate = true;
         _rasterCodecs.Options.Load.AutoFixImageResolution = true;

         // See if we have a scanning session
         try
         {
            if (TwainSession.IsAvailable(this.Handle))
            {
               _twainSession = new TwainSession();

               _twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);

               _twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(_twainSession_AcquirePage);
            }
         }
         catch (TwainException ex)
         {
            if (ex.Code == TwainExceptionCode.InvalidDll)
            {
               _twainSession = null;
               Messager.ShowError(this, DemosGlobalization.GetResxString(GetType(), "Resx_TwainException"));
            }
            else
            {
               _twainSession = null;
               Messager.ShowError(this, ex);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            _twainSession = null;
         }

         _preferencesUseProgressBarsToolStripMenuItem.Checked = true;

         _omrOptionsDismissed = false;
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

               Text = string.Format("{0} [{1} Engine]", Messager.Caption, _ocrEngine.EngineType.ToString());

               // Load the default document
               string defaultDocumentFile;
               if (_ocrEngine.EngineType == OcrEngineType.OmniPageArabic)
                  defaultDocumentFile = Path.Combine(DemosGlobal.ImagesFolder, "ArabicSample.tif");
               else
                  defaultDocumentFile = Path.Combine(DemosGlobal.ImagesFolder, "ocr1.tif");

               UpdateActiveSpellCheckerLabel((_ocrEngine.SpellCheckManager != null) ? _ocrEngine.SpellCheckManager.SpellCheckEngine : OcrSpellCheckEngine.None);

               if (File.Exists(defaultDocumentFile))
                  OpenDocument(defaultDocumentFile, 1, -1);
               else
                  NewDocument(DemosGlobalization.GetResxString(GetType(), "Resx_NewDocument"));
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

         // Shutdown down if started
         if (_twainSession != null)
         {
            _twainSession.AcquirePage -= new EventHandler<TwainAcquirePageEventArgs>(_twainSession_AcquirePage);
            _twainSession.Shutdown();
            _twainSession = null;
         }

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

      private void _fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update the UI state of the File menu items

         bool documentHasPages = _ocrDocument != null && _ocrDocument.Pages.Count > 0;

         _fileCloseToolStripMenuItem.Enabled = documentHasPages;

         if (_twainSession == null)
            _fileScanToolStripMenuItem.Enabled = false;
      }

      private void _fileOpenToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OpenDocument();
      }

      private void _fileCloseToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Do the same as New document
         NewDocument(DemosGlobalization.GetResxString(GetType(), "Resx_NewDocument"));
      }

      private void _fileConvertLDToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ConvertLD();
      }

      private void _scanSelectSourceToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Select the TWAIN source
         try
         {
            _twainSession.SelectSource(string.Empty);
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
      }

      private void _scanAcquireToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Acquire the pages using TWAIN
         try
         {
            if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, _twainSession.SelectedSourceName()))
               return;
            _twainSession.Acquire(TwainUserInterfaceFlags.Show);
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
      }

      private void _twainSession_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         // Add the page to the OCR engine
         try
         {
            InsertPages(null, -1, -1, e.Image, -1);
         }
         catch (Exception ex)
         {
            ShowError(ex);
            UpdateTimingLabel(null, null);
         }
      }

      private void _editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update the UI state of the Edit menu items

         bool documentHasPages = _ocrDocument != null && _ocrDocument.Pages.Count > 0;

         _editCopyToolStripMenuItem.Enabled = documentHasPages;
         _editPasteToolStripMenuItem.Enabled = RasterClipboard.IsReady;
      }

      private void _editCopyToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Copy the current RasterImage to the clipboard
         RasterImage image = _viewerControl.RasterImage;
         if (image != null)
         {
            try
            {
               using (WaitCursor wait = new WaitCursor())
               {
                  RasterClipboard.Copy(
                     this.Handle,
                     image,
                     RasterClipboardCopyFlags.Empty |
                     RasterClipboardCopyFlags.Dib |
                     RasterClipboardCopyFlags.Palette);
               }
            }
            catch (Exception ex)
            {
               ShowError(ex);
            }
         }
      }

      private void _editPasteToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Paste the image in the clipboard (if any) as a new page in the current document

         if (RasterClipboard.IsReady)
         {
            try
            {
               using (WaitCursor wait = new WaitCursor())
               {
                  using (RasterImage image = RasterClipboard.Paste(this.Handle))
                     InsertPages(null, -1, -1, image, -1);
               }
            }
            catch (Exception ex)
            {
               ShowError(ex);
               UpdateTimingLabel(null, null);
            }
         }
      }

      private void _viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update the UI state of the View menu items

         bool documentHasPages = _ocrDocument != null && _ocrDocument.Pages.Count > 0;

         _viewZoomOutToolStripMenuItem.Enabled = documentHasPages;
         _viewZoomInToolStripMenuItem.Enabled = documentHasPages;

         _viewFitWidthToolStripMenuItem.Enabled = documentHasPages;
         _viewFitPageToolStripMenuItem.Enabled = documentHasPages;

         _viewFitWidthToolStripMenuItem.Checked = _viewerControl.CurrentSizeMode == ControlSizeMode.FitWidth;
         _viewFitPageToolStripMenuItem.Checked = _viewerControl.CurrentSizeMode == ControlSizeMode.Fit;
      }

      private void _viewZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.ZoomViewer(true);
      }

      private void _viewZoomInToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.ZoomViewer(false);
      }

      private void _viewFitWidthToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.FitPage(true);
         _viewerControl.ZonesUpdated();
      }

      private void _viewFitPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.FitPage(false);
      }

      private void _engineSettingsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Show the dialog to let the user change any of the engine settings
         using (EngineSettingsDialog dlg = new EngineSettingsDialog(_ocrEngine))
            dlg.ShowDialog(this);
      }

      private void _engineComponentsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Show the dialog to let the user see the OCR components installed on this system
         using (OcrEngineComponentsDialog dlg = new OcrEngineComponentsDialog(_ocrEngine))
            dlg.ShowDialog(this);
      }

      private void _engineLanguagesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Show the dialog to let the user change the current enabled languages
         Image moveRightImage = LoadImageFromResource("MoveRight.png");
         Image moveLeftImage = LoadImageFromResource("MoveLeft.png");
         Image moveTopImage = LoadImageFromResource("MoveTop.png");
         using (EnableLanguagesDialog dlg = new EnableLanguagesDialog(_ocrEngine, moveRightImage, moveLeftImage, moveTopImage))
            dlg.ShowDialog(this);
      }

      private Image LoadImageFromResource(string resourceName)
      {
         Stream stream = GetType().Assembly.GetManifestResourceStream(string.Format("{0}.Resources.{1}", GetType().Namespace, resourceName));
         if (stream == null)
            return null;

         Image image = Image.FromStream(stream);
         return image;
      }

      private void _pagesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update the UI state of the Pages menu items

         bool documentHasPages = _ocrDocument != null && _ocrDocument.Pages.Count > 0;

         _pagesDeleteCurrentPageToolStripMenuItem.Enabled = documentHasPages;
         _pagesSaveProcessingImageToDiskToolStripMenuItem.Enabled = documentHasPages;
         _pagesProcessToolStripMenuItem.Enabled = documentHasPages;

         // We only need this option for OmniPage and LEAD engines

         _pagesDetectPageLanguagesToolStripMenuItem.Visible = (_ocrEngine.EngineType == OcrEngineType.OmniPage || _ocrEngine.EngineType == OcrEngineType.LEAD);
         _dualPageToolStripMenuItem.Visible = true;

         _unwarpToolStripMenuItem.Enabled = documentHasPages && (_ocrPage.BitsPerPixel == 1 || _ocrPage.BitsPerPixel == 8 || _ocrPage.BitsPerPixel == 24 || _ocrPage.BitsPerPixel == 32);
      }

      private void _pagesInsertToolStripMenuItem_Click(object sender, EventArgs e)
      {
         InsertPages();
      }

      private void _pagesDeleteCurrentPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DeletePage(CurrentPageIndex);
      }

      private void _pagesSaveProcessingImageToDiskToolStripMenuItem_Click(object sender, EventArgs e)
      {
         string tifFileName = null;

         using (SaveFileDialog dlg = new SaveFileDialog())
         {
            dlg.Title = DemosGlobalization.GetResxString(GetType(), "Resx_dlg_Title");
            dlg.Filter = "TIFF Files (*.tif;*.tiff)|*.tif;*.tiff|All Files|*.*";
            dlg.DefaultExt = "tif";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               tifFileName = dlg.FileName;
            }
         }

         if (tifFileName == null) return;

         try
         {
            using (RasterImage image = _ocrPage.GetRasterImage(OcrPageType.Processing))
            {
               _rasterCodecs.Save(image, tifFileName, RasterImageFormat.CcittGroup4, 1);
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
      }

      private void _processAllPagesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Switch the process all pages or single page option
         _processAllPagesToolStripMenuItem.Checked = !_processAllPagesToolStripMenuItem.Checked;
      }

      private void _processFlipToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Flip the current page or all pages
         FlipDocument(false);
      }

      private void _processReverseToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Reverse (flip horizontal) the current page or pages
         FlipDocument(true);
      }

      private void _processRotate90ClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Rotate the current page or pages 90 degrees clockwise
         RotateDocument(90);
      }

      private void _processRotate90CounterClockwiseToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Rotate the current page or pages 90 degrees counter-clockwise
         RotateDocument(-90);
      }

      private void _processPreprocessGetDeskewAngleToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ShowPreprocessingParameters(OcrAutoPreprocessPageCommand.Deskew);
      }

      private void _processPreprocessGetRotateAngleToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ShowPreprocessingParameters(OcrAutoPreprocessPageCommand.Rotate);
      }

      private void _processPreprocessIsInvertedToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ShowPreprocessingParameters(OcrAutoPreprocessPageCommand.Invert);
      }

      private void ShowPreprocessingParameters(OcrAutoPreprocessPageCommand command)
      {
         bool allPages = _processAllPagesToolStripMenuItem.Checked;

         try
         {
            StringBuilder sb = new StringBuilder();

            using (WaitCursor wait = new WaitCursor())
            {
               for (int i = 0; i < _ocrDocument.Pages.Count; i++)
               {
                  if (allPages || i == CurrentPageIndex)
                  {
                     IOcrPage ocrPage = _ocrDocument.Pages[i];

                     sb.Append(DemosGlobalization.GetResxString(GetType(), "Resx_Page") + (i + 1).ToString());

                     switch (command)
                     {
                        case OcrAutoPreprocessPageCommand.Deskew:
                           {
                              int angle = ocrPage.GetDeskewAngle();
                              sb.AppendLine(DemosGlobalization.GetResxString(GetType(), "Resx_DeskewAngle") + (angle / 10.0).ToString());
                           }
                           break;

                        case OcrAutoPreprocessPageCommand.Rotate:
                           {
                              int angle = ocrPage.GetRotateAngle();
                              sb.AppendLine(DemosGlobalization.GetResxString(GetType(), "Resx_RotateAngle") + angle.ToString());
                           }
                           break;

                        case OcrAutoPreprocessPageCommand.Invert:
                           {
                              bool isInverted = ocrPage.IsInverted();

                              if (isInverted)
                                 sb.AppendLine(DemosGlobalization.GetResxString(GetType(), "Resx_Inverted"));
                              else
                                 sb.AppendLine(DemosGlobalization.GetResxString(GetType(), "Resx_NotInverted"));
                           }
                           break;
                     }
                  }
               }
            }

            MessageBox.Show(this, sb.ToString(), DemosGlobalization.GetResxString(GetType(), "Resx_Caption"), MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
      }

      private void _processPreprocessDeskewToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Preprocess(OcrAutoPreprocessPageCommand.Deskew);
      }

      private void _processPreprocessRotateToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Preprocess(OcrAutoPreprocessPageCommand.Rotate);
      }

      private void _processPreprocessInvertToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Preprocess(OcrAutoPreprocessPageCommand.Invert);
      }

      private void _processPreprocessAllToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Preprocess(OcrAutoPreprocessPageCommand.All);
      }

      private void _documentCleanupToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         _processLineRemoveToolStripMenuItem.Enabled = (_ocrPage.BitsPerPixel == 1);
      }

      private void _processAutoCropToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Auto-crop the current page or pages
         RunImageProcessingCommand(new AutoCropCommand());
      }

      private void _processDespeckleToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Despeckle the current page or pages
         RunImageProcessingCommand(new DespeckleCommand());
      }

      private void _processErodeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Erode the current page or pages
         RunImageProcessingCommand(new BinaryFilterCommand(BinaryFilterCommandPredefined.ErosionOmniDirectional));
      }

      private void _processDilateToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Dilate the current page or pages
         RunImageProcessingCommand(new BinaryFilterCommand(BinaryFilterCommandPredefined.DilationOmniDirectional));
      }

      private void _processUnditherTextToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Undither text on current page or pages
         RunImageProcessingCommands(new RasterCommand[] { new MedianCommand(3), new MinimumCommand(2) });
      }

      private void _processFixBrokenLettersToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Fix broken text on current page or pages
         RunImageProcessingCommand(new MinimumCommand(2));
      }

      private void _processLineRemoveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LineRemoveCommand horizontalRemoveCommand = new LineRemoveCommand();
         horizontalRemoveCommand.Type = LineRemoveCommandType.Horizontal;

         LineRemoveCommand verticalRemoveCommand = new LineRemoveCommand();
         verticalRemoveCommand.Type = LineRemoveCommandType.Vertical;

         RunImageProcessingCommands(new RasterCommand[] { horizontalRemoveCommand, verticalRemoveCommand });
      }

      private void _processAutoBinarizeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Auto-binarize the current page or pages
         RunImageProcessingCommand(new AutoBinaryCommand());
      }

      private void _processDynamicBinarizeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RunImageProcessingCommand(new DynamicBinaryCommand(7, 50));
      }

      private void _processHisogramEqualToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RunImageProcessingCommand(new HistogramEqualizeCommand(HistogramEqualizeType.Yuv));
      }

      private void _processAutoLevelToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RunImageProcessingCommand(new AutoColorLevelCommand());
      }

      private void _processContrastBrightnessIntensityToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (ContrastBrightnessIntensityDialog dlg = new ContrastBrightnessIntensityDialog(_viewerControl.ImageViewer))
         {
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               RunImageProcessingCommand(dlg.Command);
            }
         }
      }

      private void _processPageSplitterToolStripMenuItem_Click(object sender, EventArgs e)
      {
         bool allPages = _processAllPagesToolStripMenuItem.Checked;
         int pagesCount = 1;
         int firstPageIndex = 0;
         int lastPageIndex = 0;
         if (allPages)
         {
            pagesCount = _ocrDocument.Pages.Count;
            lastPageIndex = pagesCount - 1;
            if (pagesCount > 1)
            {
               if (MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_PageSplitterAllPages"), DemosGlobalization.GetResxString(GetType(), "Resx_PageSplitter"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                  return;
            }
         }
         else
         {
            firstPageIndex = CurrentPageIndex;
            lastPageIndex = CurrentPageIndex;
            if (_viewerControl.ImageViewer.Image != null && _viewerControl.ImageViewer.Image.BitsPerPixel != 1)
            {
               if (MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_PageSplitterOnePage"), DemosGlobalization.GetResxString(GetType(), "Resx_PageSplitter"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                  return;
            }
         }

         for (int i = firstPageIndex; i <= lastPageIndex; i++)
         {
            // Get the processed 1-BPP image from each OCR page and set it as the original page image
            IOcrPage ocrPage = _ocrDocument.Pages[i];
            RasterImage processingImage = ocrPage.GetRasterImage(OcrPageType.Processing);
            if (processingImage != null)
               ocrPage.SetRasterImage(processingImage);
         }

         BorderRemoveCommand borderRemoveCommand = new BorderRemoveCommand();
         borderRemoveCommand.Flags = BorderRemoveCommandFlags.AutoRemove;
         RunImageProcessingCommands(new RasterCommand[] { borderRemoveCommand, new AutoPageSplitterCommand() });
      }

      private void _processExpandContentToolStripMenuItem_Click(object sender, EventArgs e)
      {
         bool allPages = _processAllPagesToolStripMenuItem.Checked;
         int pagesCount = 1;
         int firstPageIndex = 0;
         int lastPageIndex = 0;
         if (allPages)
         {
            pagesCount = _ocrDocument.Pages.Count;
            lastPageIndex = pagesCount - 1;
            if (pagesCount > 1)
            {
               if (MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_PageExpandContentAllPages"), DemosGlobalization.GetResxString(GetType(), "Resx_PageExpandContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                  return;
            }
         }
         else
         {
            firstPageIndex = CurrentPageIndex;
            lastPageIndex = CurrentPageIndex;
            if (_viewerControl.ImageViewer.Image != null && _viewerControl.ImageViewer.Image.BitsPerPixel != 1)
            {
               if (MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_PageExpandContentOnePage"), DemosGlobalization.GetResxString(GetType(), "Resx_PageExpandContent"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                  return;
            }
         }

         for (int i = firstPageIndex; i <= lastPageIndex; i++)
         {
            // Get the processed 1-BPP image from each OCR page and set it as the original page image
            IOcrPage ocrPage = null;
            ocrPage = _ocrDocument.Pages[i];
            RasterImage processingImage = ocrPage.GetRasterImage(OcrPageType.Processing);
            if (processingImage != null)
               ocrPage.SetRasterImage(processingImage);
         }

         RunImageProcessingCommand(new ExpandContentCommand());
      }

      private void _ocrToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update the UI state of the OCR menu items
         UpdateUIState();
      }

      private void _ocrZonesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         _zonesUpdateZonesToolStripMenuItem.Enabled = _ocrPage != null;
         _zonesShowZonesToolStripMenuItem.Checked = _viewerControl.ShowZones;
         _zonesShowZoneNamesToolStripMenuItem.Checked = _viewerControl.ShowZoneNames;
      }

      private void _ocrRecognizeDocumentToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_ocrDocument == null || _ocrDocument.Pages.Count == 0)
            return;

         RecognizeDocument(true);
      }

      private void _ocrRecognizePageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_ocrDocument == null || _ocrDocument.Pages.Count == 0)
            return;

         RecognizeDocument(false);
      }

      private void _ocrSaveDocumentToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_ocrDocument == null || _ocrDocument.Pages.Count == 0)
            return;

         SaveDocument();
      }

      private void _ocrShowRecognizedWordsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_ocrPage != null && _ocrPage.IsRecognized)
         {
            using (RecognizedWordsDialog dlg = new RecognizedWordsDialog(_ocrDocument))
               dlg.ShowDialog(this);
         }
      }

      private void _ocrSaveRecognizedDataAsXmlToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_ocrPage != null && _ocrPage.IsRecognized)
         {
            using (SaveRecognizedXmlDialog dlg = new SaveRecognizedXmlDialog(_ocrDocument))
            {
               dlg.ShowDialog(this);
            }
         }
      }

      private void _ocrSpellCheckEngineStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_ocrEngine.SpellCheckManager == null)
         {
            MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_FeatureNotSupported"), DemosGlobalization.GetResxString(GetType(), "Resx_SpellLanguage"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
         }

         using (SpellCheckEngineDialog dlg = new SpellCheckEngineDialog(_ocrEngine))
         {
            if (dlg.ShowDialog() == DialogResult.OK)
               UpdateActiveSpellCheckerLabel((_ocrEngine.SpellCheckManager != null) ? _ocrEngine.SpellCheckManager.SpellCheckEngine : OcrSpellCheckEngine.None);
         }
      }

      private void _ocrOmrOptionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (OcrOmrOptionsDialog dlg = new OcrOmrOptionsDialog(_ocrEngine))
            dlg.ShowDialog(this);
      }

      private void _zonesAutoZoneDocumentToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AutoZone(true);
      }

      private void _zonesAutoZoneCurrentPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         AutoZone(false);
      }

      private void _zonesUpdateZonesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ShowZoneProperties();
      }

      private void _zonesLoadZonesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LoadZones(false);
      }

      private void _zonesSaveZonesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SaveZones(false);
      }

      private void _zonesShowZonesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.ShowZones = !_viewerControl.ShowZones;
      }

      private void _zonesShowZoneNamesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.ShowZoneNames = !_viewerControl.ShowZoneNames;
      }

      private void _preferencesUseProgressBarsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _preferencesUseProgressBarsToolStripMenuItem.Checked = !_preferencesUseProgressBarsToolStripMenuItem.Checked;
      }

      private void _helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Multi-Engine OCR", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _openDocumentToolStripButton_Click(object sender, EventArgs e)
      {
         _fileOpenToolStripMenuItem.PerformClick();
      }

      private void _autoZoneDocumentToolStripButton_Click(object sender, EventArgs e)
      {
         _zonesAutoZoneDocumentToolStripMenuItem.PerformClick();
      }

      private void _autoZonePageToolStripButton_Click(object sender, EventArgs e)
      {
         _zonesAutoZoneCurrentPageToolStripMenuItem.PerformClick();
      }

      private void _recognizeDocumentToolStripButton_Click(object sender, EventArgs e)
      {
         _ocrRecognizeDocumentToolStripMenuItem.PerformClick();
      }

      private void _recognizePageToolStripButton_Click(object sender, EventArgs e)
      {
         _ocrRecognizePageToolStripMenuItem.PerformClick();
      }

      private void _saveDocumentToolStripButton_Click(object sender, EventArgs e)
      {
         _ocrSaveDocumentToolStripMenuItem.PerformClick();
      }

      private void UpdateUIState()
      {
         // Update the UI state

         bool documentHasPages = _ocrDocument != null && _ocrDocument.Pages.Count > 0;

         // Update toolbar buttons
         _autoZoneDocumentToolStripButton.Enabled = documentHasPages;
         _autoZonePageToolStripButton.Enabled = documentHasPages;
         _recognizeDocumentToolStripButton.Enabled = documentHasPages;
         _recognizePageToolStripButton.Enabled = documentHasPages;
         _saveDocumentToolStripButton.Enabled = documentHasPages;

         // Update menu items
         _ocrZonesToolStripMenuItem.Enabled = documentHasPages;
         _ocrRecognizeDocumentToolStripMenuItem.Enabled = documentHasPages;
         _ocrRecognizePageToolStripMenuItem.Enabled = documentHasPages;
         _ocrSaveDocumentToolStripMenuItem.Enabled = documentHasPages;
         _ocrShowRecognizedWordsToolStripMenuItem.Enabled = _ocrPage != null && _ocrPage.IsRecognized;
         _ocrSaveRecognizedDataAsXmlToolStripMenuItem.Enabled = _ocrPage != null && _ocrPage.IsRecognized;

         // We only need this option for LEAD engine
         _processContrastBrightnessIntensityToolStripMenuItem.Visible = _ocrEngine.EngineType == OcrEngineType.LEAD;

         // OMR is not supported for Arabic OCR engine.
         _ocrOmrOptionsToolStripMenuItem.Enabled = _ocrEngine.EngineType != OcrEngineType.OmniPageArabic;
      }

      private void OpenDocument()
      {
         // Open a document from disk

         Properties.Settings settings = new Properties.Settings();

         // Show the LEADTOOLS common dialog
         ImageFileLoader loader = new ImageFileLoader();
         loader.LoadOnlyOnePage = false;
         loader.ShowLoadPagesDialog = true;
         loader.OpenDialogInitialPath = _openInitialPath;
         if (!String.IsNullOrEmpty(settings.OpenDialogInitialPath))
            loader.OpenDialogInitialPath = settings.OpenDialogInitialPath;

         try
         {
            // Insert the pages loader into the document
            if (loader.Load(this, _rasterCodecs, false) > 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               settings.OpenDialogInitialPath = Path.GetDirectoryName(loader.FileName);
               settings.Save();
               OpenDocument(loader.FileName, loader.FirstPage, loader.LastPage);
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
      }

      private void OpenDocument(string fileName, int firstPage, int lastPage)
      {
         _fileName = fileName;
         // Open the document in file name

         // Create a new document and insert the pages
         try
         {
            NewDocument(fileName);
            InsertPages(fileName, firstPage, lastPage, null, -1);
            _isCustomFileName = false;
         }
         catch (Exception ex)
         {
            ShowError(ex);
            UpdateTimingLabel(null, null);
         }
      }

      private void NewDocument(string title)
      {
         // Create a new document

         if (_ocrDocument != null)
            _ocrDocument.Dispose();

         _ocrDocument = _ocrEngine.DocumentManager.CreateDocument();
         _ocrPage = null;

         _viewerControl.ClearZones();
         _viewerControl.Title = title;

         _pagesControl.ImageList.Items.Clear();
         RepopulatePagesControl(0, -1, title);
         GotoPage(-1);

         UpdateUIState();
      }

      private void _pagesControl_Action(object sender, ActionEventArgs e)
      {
         // Called from the PagesControl when a button is clicked

         switch (e.Action)
         {
            case "InsertPage":
               InsertPages();
               break;

            case "DeletePage":
               DeletePage(CurrentPageIndex);
               break;

            case "MovePageUp":
               MoveCurrentPage(true);
               break;

            case "MovePageDown":
               MoveCurrentPage(false);
               break;

            case "PageIndexChanged":
               {
                  // Get the new page index and go to it
                  int pageIndex = (int)e.Data;
                  GotoPage(pageIndex);
               }
               break;
         }
      }

      private void _viewerControl_Action(object sender, ActionEventArgs e)
      {
         // Called from the ViewerControl when a button is clicked

         switch (e.Action)
         {
            case "PageIndexChanged":
               {
                  // Get the new page index and go to it
                  int pageIndex = (int)e.Data;
                  GotoPage(pageIndex);
               }
               break;

            case "ShowZoneProperties":
               ShowZoneProperties();
               break;

            case "RefreshPagesControl":
               bool allPages = (bool)e.Data;
               RefreshPagesControl(allPages);
               break;
         }
      }

      private int CurrentPageIndex
      {
         // Get the current OCR page index
         get
         {
            if (_ocrPage == null)
               return -1;
            else
               return _ocrDocument.Pages.IndexOf(_ocrPage);
         }
      }

      private void InsertPages()
      {
         // Insert new pages into the current document

         // Show the common file dialog to let the user select a file
         ImageFileLoader loader = new ImageFileLoader();
         loader.LoadOnlyOnePage = false;
         loader.ShowLoadPagesDialog = true;

         try
         {
            Properties.Settings settings = new Properties.Settings();
            if (!String.IsNullOrEmpty(settings.InsertPageDialogInitialPath))
               loader.OpenDialogInitialPath = settings.InsertPageDialogInitialPath;

            // Insert the pages loader into the document
            if (loader.Load(this, _rasterCodecs, false) > 0)
            {
               settings.InsertPageDialogInitialPath = Path.GetDirectoryName(loader.FileName);
               settings.Save();
               InsertPages(loader.FileName, loader.FirstPage, loader.LastPage, null, -1);
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
            UpdateTimingLabel(null, null);
         }
      }

      private void InsertPages(string fileName, int firstPage, int lastPage, RasterImage image, int insertionIndex)
      {
         // Insert the pages from file or directly into the current document
         // Go to the first inserted page

         int pageIndex = insertionIndex;
         if (insertionIndex == -1)
         {
            pageIndex = CurrentPageIndex;

            // Insert the new pages after the current page
            if (pageIndex == -1)
               pageIndex = 0;
            else
               pageIndex++;
         }

         int oldPagesCount = _ocrDocument.Pages.Count;
         try
         {
            // Check if we are inserting a page from file or directly
            using (WaitCursor wait = new WaitCursor())
            {
               DateTime beginTime = DateTime.Now;

               if (image != null)
                  _ocrDocument.Pages.InsertPage(
                     pageIndex,
                     image,
                     null);
               else
                  _ocrDocument.Pages.InsertPages(
                     pageIndex,
                     fileName,
                     firstPage,
                     lastPage,
                     null);

               TimeSpan ts = DateTime.Now - beginTime;
               UpdateTimingLabel(new string[] { DemosGlobalization.GetResxString(GetType(), "Resx_InsertPages ") }, new TimeSpan[] { ts });
            }

            // Update the pages control with the new document
            int newPagesCount = _ocrDocument.Pages.Count;
            RepopulatePagesControl(pageIndex, newPagesCount - oldPagesCount, fileName);

            // Go to the first page inserted in the document
            GotoPage(pageIndex);
         }
         catch (System.Exception ex)
         {
            if (ex.Message.Equals("Not enough memory available"))
            {
               _ocrDocument.Pages.Clear();
            }
            else
            {
               int newPagesCount = _ocrDocument.Pages.Count;
               if (newPagesCount == oldPagesCount + 1)
               {
                  // page was added successfully into the engine but the error occurred somewhere else after that, 
                  // so delete the last inserted page otherwise the demo PagesControl will have some problems.
                  _ocrDocument.Pages.RemoveAt(newPagesCount - 1);
               }
            }

            throw ex;
         }
      }

      private void DeletePage(int pageIndex)
      {
         // Delete the page with the passed index from the document
         using (WaitCursor wait = new WaitCursor())
         {
            _ocrDocument.Pages.RemoveAt(pageIndex);

            _pagesControl.ImageList.Items.RemoveAt(pageIndex);

            if (pageIndex >= _ocrDocument.Pages.Count)
               pageIndex = _ocrDocument.Pages.Count - 1;

            // Update the pages control with the new document
            if (pageIndex >= 0)
               UpdatePagesControlItemsText(pageIndex);

            // Go to the current page
            GotoPage(pageIndex);
         }
      }

      private void RepopulatePagesControl(int pageIndex, int count, String fileName)
      {
         using (WaitCursor wait = new WaitCursor())
         {
            // Re-insert the thumbnails from the pages control
            ImageViewer imageList = _pagesControl.ImageList;
            imageList.BeginUpdate();

            // Loop through all the pages in the document and create thumbnails for them,
            // add the thumbnails to the pages control

            try
            {
               if (_ocrDocument != null)
               {
                  LeadSize thumbSize = imageList.ItemSize;

                  int index = pageIndex;
                  for (int i = 0; i < count; i++)
                  {
                     IOcrPage ocrPage = _ocrDocument.Pages[index];
                     RasterImage image = ocrPage.CreateThumbnail(thumbSize.Width, thumbSize.Height);
                     ImageViewerItem item = new ImageViewerItem();
                     item.Image = image;
                     item.PageNumber = 1;
                     item.Text = DemosGlobalization.GetResxString(GetType(), "Resx_Page") + (index + 1).ToString();
                     imageList.Items.Insert(index, item);
                     index++;
                  }

                  // Loop through all image list items that followed the inserted item and correct their names orders
                  for (int i = index; i < imageList.Items.Count; i++)
                  {
                     if (imageList.Items[i] != null)
                     {
                        imageList.Items[i].Text = DemosGlobalization.GetResxString(GetType(), "Resx_Page") + (i + 1).ToString();
                     }
                  }
               }
            }
            catch (System.Exception ex)
            {
               // need to resume image list update before throwing the error.
               imageList.EndUpdate();
               throw ex;
            }

            imageList.EndUpdate();
         }
      }

      private void UpdatePagesControlItemsText(int pageIndex)
      {
         ImageViewer imageList = _pagesControl.ImageList;

         for (int i = pageIndex; i < imageList.Items.Count; i++)
         {
            String itemText = DemosGlobalization.GetResxString(GetType(), "Resx_Page") + (i + 1).ToString();
            imageList.Items[i].Text = itemText;
         }
      }

      private void RefreshPagesControl(bool allPages)
      {
         using (WaitCursor wait = new WaitCursor())
         {
            // Re-get the thumbnails from the pages control
            ImageViewer imageList = _pagesControl.ImageList;
            imageList.BeginUpdate();

            LeadSize thumbSize = imageList.ItemSize;

            int pageIndex = CurrentPageIndex;

            for (int i = 0; i < imageList.Items.Count; i++)
            {
               if (allPages || i == pageIndex)
               {
                  RasterImage image = _ocrDocument.Pages[i].CreateThumbnail(thumbSize.Width, thumbSize.Height);
                  imageList.Items[i].Image = image;
               }

               // Set the item tag if the page is recognized, otherwise set it to null
               if (_ocrDocument != null && _ocrDocument.Pages[i].IsRecognized)
                  imageList.Items[i].Tag = true;
               else
                  imageList.Items[i].Tag = false;
            }

            imageList.EndUpdate();
         }
      }

      private void GotoPage(int pageIndex)
      {
         // Goto this page in the OCR document
         if (pageIndex == -1)
            pageIndex = 0;

         if (_ocrDocument != null && _ocrDocument.Pages.Count > 0)
         {
            _ocrPage = _ocrDocument.Pages[pageIndex];

            // Set the current page in the pages control
            _pagesControl.SetCurrentPageIndex(pageIndex);

            // Go to the current page in the viewer control
            _viewerControl.SetPages(pageIndex, _ocrDocument.Pages.Count);

            using (WaitCursor wait = new WaitCursor())
            {
               RasterImage image = _ocrPage.GetRasterImage(OcrPageType.Current);
               _viewerControl.SetImageAndPage(image, _ocrPage);
            }
         }
         else
         {
            // No more pages
            _ocrPage = null;

            _pagesControl.SetCurrentPageIndex(-1);
            _viewerControl.ClearZones();
            _viewerControl.SetImageAndPage(null, null);
            _viewerControl.SetPages(0, 0);
         }

         if (_pagesControl.ImageList.Items.Count > 0 && pageIndex < _pagesControl.ImageList.Items.Count)
            _viewerControl.Title = _pagesControl.ImageList.Items[pageIndex].Text;
         else
            _viewerControl.Title = String.Empty;

         UpdateUIState();
      }

      private void RunImageProcessingCommand(RasterCommand command)
      {
         RunImageProcessingCommands(new RasterCommand[] { command });
      }

      private void RunImageProcessingCommands(RasterCommand[] commands)
      {
         // Run the command on all or just current page
         bool allPages = _processAllPagesToolStripMenuItem.Checked;
         bool isPageSplitterCommand = false;
         int currentPageIndex = CurrentPageIndex;

         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               if (allPages)
               {
                  // Loop through the pages of the document
                  // Get the page as a RasterImage object
                  // Run the command on it
                  // Set it back in the engine
                  for (int i = 0; i < _ocrDocument.Pages.Count; i++)
                  {
                     IOcrPage ocrPage = _ocrDocument.Pages[i];
                     // Remove the zones from the page and unrecognize
                     ocrPage.Zones.Clear();
                     ocrPage.Unrecognize();

                     using (RasterImage image = ocrPage.GetRasterImage())
                     {
                        foreach (RasterCommand command in commands)
                        {
                           command.Run(image);
                           if (command.GetType() == typeof(AutoPageSplitterCommand))
                           {
                              isPageSplitterCommand = true;
                              AutoPageSplitterCommand pageSplitterCommand = (AutoPageSplitterCommand)command;
                              if (pageSplitterCommand.FirstImage != null && pageSplitterCommand.SecondImage != null)
                              {
                                 // Use the original image list item file name after applying this command to display 
                                 // the correct file name in viewer control title bar
                                 string fileName = _pagesControl.ImageList.Items[i].Text;

                                 // This command splits the page into two, so we need to remove the original page and 
                                 // add two pages instead with the images returned from this command.
                                 DeletePage(i);
                                 InsertPages(fileName, 1, 1, pageSplitterCommand.FirstImage, i);
                                 InsertPages(fileName, 1, 1, pageSplitterCommand.SecondImage, i + 1);
                                 i++;
                              }
                           }
                        }
                        if (!isPageSplitterCommand)
                           ocrPage.SetRasterImage(image);
                     }
                  }

                  if (isPageSplitterCommand)
                     GotoPage(currentPageIndex);
               }
               else
               {
                  // Remove the zones from the page and unrecognize
                  _ocrPage.Zones.Clear();
                  _ocrPage.Unrecognize();

                  // The image is in the viewer, use it
                  RasterImage image = _ocrPage.GetRasterImage(OcrPageType.Current);
                  foreach (RasterCommand command in commands)
                  {
                     command.Run(image);
                     if (command.GetType() == typeof(AutoPageSplitterCommand))
                     {
                        isPageSplitterCommand = true;
                        AutoPageSplitterCommand pageSplitterCommand = (AutoPageSplitterCommand)command;
                        if (pageSplitterCommand.FirstImage != null && pageSplitterCommand.SecondImage != null)
                        {
                           // Use the original image list item file name after applying this command to display 
                           // the correct file name in viewer control title bar
                           string fileName = _pagesControl.ImageList.Items[currentPageIndex].Text;

                           // This command splits the page into two, so we need to remove the original page and 
                           // add two pages instead with the images returned from this command.
                           InsertPages(fileName, 1, 1, pageSplitterCommand.FirstImage, -1);
                           InsertPages(fileName, 1, 1, pageSplitterCommand.SecondImage, -1);
                           DeletePage(currentPageIndex);
                        }
                     }
                  }

                  if (!isPageSplitterCommand)
                     _ocrPage.SetRasterImage(image);
               }
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
         finally
         {
            // Update the page in the viewer from the engine
            GotoPage(CurrentPageIndex);
            // Update the thumbnail(s)
            RefreshPagesControl(allPages);
         }
      }

      private void FlipDocument(bool horizontal)
      {
         // Run the command on all or just current page
         bool allPages = _processAllPagesToolStripMenuItem.Checked;

         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               if (allPages)
               {
                  // Loop through the pages of the document
                  // Get the page as a RasterImage object
                  // Run the command on it
                  // Set it back in the engine
                  foreach (IOcrPage ocrPage in _ocrDocument.Pages)
                  {
                     // Remove the zones from the page and unrecognize
                     ocrPage.Zones.Clear();
                     ocrPage.Unrecognize();

                     using (RasterImage image = ocrPage.GetRasterImage())
                     {
                        image.FlipViewPerspective(horizontal);
                        ocrPage.SetRasterImage(image);
                     }
                  }
               }
               else
               {
                  // Remove the zones from the page and unrecognize
                  _ocrPage.Zones.Clear();
                  _ocrPage.Unrecognize();

                  // The image is in the viewer, use it
                  RasterImage image = _viewerControl.RasterImage;
                  image.FlipViewPerspective(horizontal);
                  _ocrPage.SetRasterImage(image);
               }
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
         finally
         {
            // Update the page in the viewer from the engine
            GotoPage(CurrentPageIndex);
            // Update the thumbnail(s)
            RefreshPagesControl(allPages);
         }
      }

      private void RotateDocument(int angle)
      {
         // Run the command on all or just current page
         bool allPages = _processAllPagesToolStripMenuItem.Checked;
         RotateCommand rotateCmd = new RotateCommand(angle * 100, RotateCommandFlags.Resize, new RasterColor(255, 255, 255));

         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               if (allPages)
               {
                  // Loop through the pages of the document
                  // Get the page as a RasterImage object
                  // Run the command on it
                  // Set it back in the engine
                  foreach (IOcrPage ocrPage in _ocrDocument.Pages)
                  {
                     // Remove the zones from the page and unrecognize
                     ocrPage.Zones.Clear();
                     ocrPage.Unrecognize();

                     using (RasterImage image = ocrPage.GetRasterImage())
                     {
                        rotateCmd.Run(image);
                        ocrPage.SetRasterImage(image);
                     }
                  }
               }
               else
               {
                  // Remove the zones from the page and unrecognize
                  _ocrPage.Zones.Clear();
                  _ocrPage.Unrecognize();

                  // The image is in the viewer, use it
                  rotateCmd.Run(_viewerControl.RasterImage);
                  _ocrPage.SetRasterImage(_viewerControl.RasterImage);
               }
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
         finally
         {
            // Update the page in the viewer from the engine
            GotoPage(CurrentPageIndex);
            // Update the thumbnail(s)
            RefreshPagesControl(allPages);
         }
      }

      private void MoveCurrentPage(bool up)
      {
         // Move the current page up or down

         // Get the page index to move
         int pageIndex1 = CurrentPageIndex;
         int pageIndex2;

         if (up)
            pageIndex2 = pageIndex1 - 1;
         else
            pageIndex2 = pageIndex1 + 1;

         using (WaitCursor wait = new WaitCursor())
         {
            IOcrPage ocrPage = _ocrDocument.Pages[pageIndex1];

            _ocrDocument.Pages.MovePage(ocrPage, pageIndex2);

            RefreshPagesControl(true);

            // Finally, go to the new page
            GotoPage(pageIndex2);
         }
      }

      private void Preprocess(OcrAutoPreprocessPageCommand command)
      {
         // Preprocess current or all pages in the document
         bool allPages = _processAllPagesToolStripMenuItem.Checked;

         // Setup the arguments for the callback
         Dictionary<string, object> args = new Dictionary<string, object>();
         args.Add("allPages", allPages);
         args.Add("command", command);

         // Call the process dialog
         try
         {
            bool allowProgress = _preferencesUseProgressBarsToolStripMenuItem.Checked;
            using (OcrProgressDialog dlg = new OcrProgressDialog(allowProgress, DemosGlobalization.GetResxString(GetType(), "Resx_Preprocess"), new OcrProgressDialog.ProcessDelegate(DoPreprocess), args))
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
            // Update the page in the viewer from the engine
            GotoPage(CurrentPageIndex);
            // Update the thumbnail(s)
            RefreshPagesControl(allPages);

            UpdateUIState();
         }
      }

      private void DoPreprocess(OcrProgressDialog dlg, Dictionary<string, object> args)
      {
         // Perform auto-zoning here

         OcrProgressCallback callback = dlg.OcrProgressCallback;

         try
         {
            bool allPages = (bool)args["allPages"];
            OcrAutoPreprocessPageCommand command = (OcrAutoPreprocessPageCommand)args["command"];

            // If we are not using a progress bar, update the description text
            if (callback == null)
               dlg.UpdateDescription(DemosGlobalization.GetResxString(GetType(), "Resx_PreprocessingDocument"));

            // Remove the zones from the page(s)

            if (allPages)
            {
               foreach (IOcrPage ocrPage in _ocrDocument.Pages)
               {
                  // Remove the zones from the page and unrecognize
                  ocrPage.Zones.Clear();
                  ocrPage.Unrecognize();
               }
            }
            else
            {
               _ocrPage.Zones.Clear();
               _ocrPage.Unrecognize();
            }

            DateTime beginTime = DateTime.Now;

            if (allPages)
               _ocrDocument.Pages.AutoPreprocess(command, callback);
            else
               _ocrPage.AutoPreprocess(command, callback);

            TimeSpan ts = DateTime.Now - beginTime;
            UpdateTimingLabel(new string[] { DemosGlobalization.GetResxString(GetType(), "Resx_Preprocess") }, new TimeSpan[] { ts });
         }
         catch (Exception ex)
         {
            ShowError(ex);
            UpdateTimingLabel(null, null);
         }
         finally
         {
            if (callback == null)
               dlg.EndOperation();
         }
      }

      private void AutoZone(bool allPages)
      {
         // Auto zone current or all pages in the document

         // Setup the arguments for the callback
         Dictionary<string, object> args = new Dictionary<string, object>();
         args.Add("allPages", allPages);

         // Call the process dialog
         try
         {
            bool allowProgress = _preferencesUseProgressBarsToolStripMenuItem.Checked;
            using (OcrProgressDialog dlg = new OcrProgressDialog(allowProgress, DemosGlobalization.GetResxString(GetType(), "Resx_AutoZone"), new OcrProgressDialog.ProcessDelegate(DoAutoZone), args))
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
            // Re-paint current page to show new zones
            _viewerControl.ZonesUpdated();
            UpdateUIState();
         }

         _viewerControl.InteractiveMode = ViewerControlInteractiveMode.DrawZoneMode;
         _viewerControl.AutomationManager.CurrentObjectId = AnnObject.SelectObjectId;
      }

      private void DoAutoZone(OcrProgressDialog dlg, Dictionary<string, object> args)
      {
         // Perform auto-zoning here

         OcrProgressCallback callback = dlg.OcrProgressCallback;

         bool allPages = (bool)args["allPages"];

         try
         {
            // If we are not using a progress bar, update the description text
            if (callback == null)
               dlg.UpdateDescription(DemosGlobalization.GetResxString(GetType(), "Resx_AutoZoning"));

            DateTime beginTime = DateTime.Now;

            if (allPages)
               _ocrDocument.Pages.AutoZone(callback);
            else
               _ocrPage.AutoZone(callback);

            TimeSpan ts = DateTime.Now - beginTime;
            UpdateTimingLabel(new string[] { DemosGlobalization.GetResxString(GetType(), "Resx_AutoZone") }, new TimeSpan[] { ts });
         }
         catch (Exception ex)
         {
            ShowError(ex);
            UpdateTimingLabel(null, null);
         }
         finally
         {
            if (callback == null)
               dlg.EndOperation();

            foreach (IOcrPage page in _ocrDocument.Pages)
            {
               page.Unrecognize();
            }
            _viewerControl.ZonesUpdated();

            // Engine will correct the page deskew before AutoZone or Recognize, so we need to load the page again form the engine.
            GotoPage(CurrentPageIndex);
            // Update the thumbnail(s)
            RefreshPagesControl(allPages);
         }
      }

      private void RecognizeDocument(bool allPages)
      {
         // Recognize current or all pages in the document

         // Setup the arguments for the callback
         Dictionary<string, object> args = new Dictionary<string, object>();
         args.Add("allPages", allPages);

         // Call the process dialog
         try
         {
            bool allowProgress = _preferencesUseProgressBarsToolStripMenuItem.Checked;
            using (OcrProgressDialog dlg = new OcrProgressDialog(allowProgress, DemosGlobalization.GetResxString(GetType(), "Resx_Recognize"), new OcrProgressDialog.ProcessDelegate(DoRecognize), args))
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
            // Re-paint current page to show new zones
            _viewerControl.ZonesUpdated();
            UpdateUIState();
         }
      }

      private void DoRecognize(OcrProgressDialog dlg, Dictionary<string, object> args)
      {
         // Perform auto-zoning here

         OcrProgressCallback callback = dlg.OcrProgressCallback;

         bool allPages = (bool)args["allPages"];

         try
         {
            // If we are not using a progress bar, update the description text
            if (callback == null)
               dlg.UpdateDescription(DemosGlobalization.GetResxString(GetType(), "Resx_RecognizingDocument"));

            DateTime beginTime = DateTime.Now;

            if (allPages)
               _ocrDocument.Pages.Recognize(callback);
            else
               _ocrPage.Recognize(callback);

            TimeSpan ts = DateTime.Now - beginTime;
            UpdateTimingLabel(new string[] { DemosGlobalization.GetResxString(GetType(), "Resx_Recognize") }, new TimeSpan[] { ts });
         }
         catch (Exception ex)
         {
            ShowError(ex);
            UpdateTimingLabel(null, null);
         }
         finally
         {
            if (callback == null)
               dlg.EndOperation();

            // Engine will correct the page deskew before AutoZone or Recognize, so we need to load the page again form the engine.
            GotoPage(CurrentPageIndex);
            // Update the thumbnail(s)
            RefreshPagesControl(allPages);
         }
      }

      private void SaveDocument()
      {
         // Get the last format, options and document file name selected by the user
         DocumentWriter docWriter = _ocrEngine.DocumentWriterInstance;

         Properties.Settings settings = new Properties.Settings();

         if(!_isCustomFileName)
            settings.DocumentFileName = _fileName;

         DocumentFormat initialFormat = DocumentFormat.Pdf;

         if (!string.IsNullOrEmpty(settings.Format))
         {
            try
            {
               initialFormat = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), settings.Format);
            }
            catch { }
         }

         if (!string.IsNullOrEmpty(settings.FormatOptionsXml))
         {
            // Set the document writer options from the last one we saved
            try
            {
               byte[] buffer = Encoding.Unicode.GetBytes(settings.FormatOptionsXml);
               using (MemoryStream ms = new MemoryStream(buffer))
                  docWriter.LoadOptions(ms);
            }
            catch { }
         }

         if (!string.IsNullOrEmpty(settings.EngineFormatName))
         {
            if (_ocrEngine.DocumentManager.IsEngineFormatSupported(settings.EngineFormatName))
               _ocrEngine.DocumentManager.EngineFormat = settings.EngineFormatName;
         }

         // Show the save dialog
         using (SaveDocumentDialog dlg = new SaveDocumentDialog(_ocrDocument, initialFormat, settings.DocumentFileName, _isCustomFileName, _outputDir, _viewDocument))
         {
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               // Saved OK, save the last format, options and document file name used
               _viewDocument = dlg.SelectedViewDocument;
               settings.Format = dlg.SelectedFormat.ToString();

               using (MemoryStream ms = new MemoryStream())
               {
                  docWriter.SaveOptions(ms);
                  settings.FormatOptionsXml = Encoding.Unicode.GetString(ms.ToArray());
               }

               if (_ocrEngine.DocumentManager.EngineFormat != null)
                  settings.EngineFormatName = _ocrEngine.DocumentManager.EngineFormat;

               settings.DocumentFileName = dlg.SelectedFileName;
               settings.Save();

               _isCustomFileName = dlg.IsCustomFileName;

               if (_isCustomFileName)
                  _outputDir = dlg.OutputDir;

               // Save the document
               SaveDocument(dlg.SelectedFileName, dlg.SelectedFormat);
            }
         }
      }

      private void SaveDocument(string documentFileName, DocumentFormat format)
      {
         // Save the document

         // Setup the arguments for the callback
         Dictionary<string, object> args = new Dictionary<string, object>();
         args.Add("documentFileName", documentFileName);
         args.Add("format", format);

         // Call the process dialog
         try
         {
            bool allowProgress = _preferencesUseProgressBarsToolStripMenuItem.Checked;
            using (OcrProgressDialog dlg = new OcrProgressDialog(allowProgress, DemosGlobalization.GetResxString(GetType(), "Resx_Save"), new OcrProgressDialog.ProcessDelegate(DoSave), args))
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
            // Re-paint current page to show new zones
            _viewerControl.ZonesUpdated();
            UpdateUIState();
         }
      }

      private void DoSave(OcrProgressDialog dlg, Dictionary<string, object> args)
      {
         // Perform save here

         OcrProgressCallback callback = dlg.OcrProgressCallback;

         try
         {
            string documentFileName = args["documentFileName"] as string;
            DocumentFormat format = (DocumentFormat)args["format"];

            if (format == DocumentFormat.Ltd && File.Exists(documentFileName))
               File.Delete(documentFileName);

            // This could be called without any pages being recognized. In this case, recognize
            // the document before saving it
            bool isRecognizeRequired = true;
            foreach (IOcrPage ocrPage in _ocrDocument.Pages)
            {
               if (ocrPage.IsRecognized)
               {
                  isRecognizeRequired = false;
                  break;
               }
            }

            TimeSpan recognizeTimeSpan = new TimeSpan();

            if (isRecognizeRequired)
            {
               // Recognize before saving

               // If we are not using a progress bar, update the description text
               if (callback == null)
                  dlg.UpdateDescription(DemosGlobalization.GetResxString(GetType(), "Resx_RecognizingDocument"));

               if (!dlg.IsCanceled)
               {
                  DateTime beginTime = DateTime.Now;
                  _ocrDocument.Pages.Recognize(callback);
                  recognizeTimeSpan = DateTime.Now - beginTime;

                  // Engine will correct the page deskew before AutoZone or Recognize, so we need to load the page again form the engine.
                  GotoPage(CurrentPageIndex);

                  // Update the thumbnail(s)
                  RefreshPagesControl(true);
               }
            }

            // If we are not using a progress bar, update the description text
            if (callback == null)
               dlg.UpdateDescription(DemosGlobalization.GetResxString(GetType(), "Resx_SavingDocument"));

            TimeSpan saveTimeSpan = new TimeSpan();

            // If it has not been canceled, save the document
            if (!dlg.IsCanceled)
            {
               DateTime beginTime = DateTime.Now;
               _ocrDocument.Save(documentFileName, format, callback);
               saveTimeSpan = DateTime.Now - beginTime;
            }

            if (!dlg.IsCanceled)
            {
               if (isRecognizeRequired)
                  UpdateTimingLabel(new string[] { DemosGlobalization.GetResxString(GetType(), "Resx_Recognize"), DemosGlobalization.GetResxString(GetType(), "Resx_SaveDocument") }, new TimeSpan[] { recognizeTimeSpan, saveTimeSpan });
               else
                  UpdateTimingLabel(new string[] { DemosGlobalization.GetResxString(GetType(), "Resx_SaveDocument") }, new TimeSpan[] { saveTimeSpan });
            }

            // In the Plus engine, if the image DPI is not compatible with the engine,
            // the engine will automatically change it, so check for that and get the
            // the image from the engine if this is the case
            if (_viewerControl.RasterImage != null && _ocrPage != null)
            {
               if (_viewerControl.RasterImage.XResolution != _ocrPage.DpiX || _viewerControl.RasterImage.YResolution != _ocrPage.DpiY)
                  GotoPage(CurrentPageIndex);
            }

            // If it has not been canceled, show the final document (if applicable)
            if (!dlg.IsCanceled && _viewDocument)
            {
               // Put some delay before loading the saved file since Windows 7 is a little slower in creating the 
               // documents specially the EMF format.
               System.Threading.Thread.Sleep(1000);
               Process.Start(documentFileName);
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
            UpdateTimingLabel(null, null);
         }
         finally
         {
            if (callback == null)
               dlg.EndOperation();
         }
      }

      private void LoadZones(bool loadAllPagesZones)
      {
         // Load the zones from a disk file
         using (OpenFileDialog dlg = new OpenFileDialog())
         {
            dlg.Filter = "Zone files (*.ozf)|*.ozf|All Files|*.*";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               try
               {
                  using (WaitCursor wait = new WaitCursor())
                  {
                     if (!loadAllPagesZones)
                        _ocrPage.LoadZones(dlg.FileName);
                     else
                        _ocrDocument.LoadZones(dlg.FileName);
                  }

                  CheckOmrOptions();
               }
               catch (Exception ex)
               {
                  ShowError(ex);
               }
               finally
               {
                  foreach (IOcrPage page in _ocrDocument.Pages)
                  {
                     page.Unrecognize();
                  }
                  _viewerControl.ZonesUpdated();
                  RefreshPagesControl(true);
                  UpdateUIState();
               }
            }
         }
      }

      private void SaveZones(bool saveAllPagesZones)
      {
         // Save the zones to a disk file
         using (SaveFileDialog dlg = new SaveFileDialog())
         {
            dlg.Filter = "Zone files (*.ozf)|*.ozf|All Files|*.*";
            dlg.DefaultExt = "ozf";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               try
               {
                  using (WaitCursor wait = new WaitCursor())
                  {
                     if (!saveAllPagesZones)
                        _ocrPage.SaveZones(dlg.FileName);
                     else
                        _ocrDocument.SaveZones(dlg.FileName);
                  }
               }
               catch (Exception ex)
               {
                  ShowError(ex);
               }
            }
         }
      }

      private struct MyZoneData
      {
         public OcrZone Zone;
         public OcrZoneCell[] ZoneCells;

         public MyZoneData(OcrZone zone, OcrZoneCell[] cells)
         {
            Zone = zone;
            ZoneCells = cells;
         }
      }

      private void ShowZoneProperties()
      {
         // Show the zone properties dialog
         // to let the user update the zones

         // Get the selected zone from the viewer control
         int selectedZoneIndex = _viewerControl.SelectedZoneIndex;

         // Make a copy of the page zones in case the user canceled the dialog
         List<MyZoneData> zones = new List<MyZoneData>();
         foreach (OcrZone zone in _ocrPage.Zones)
         {
            OcrZoneCell[] cells = null;

            if(zone.ZoneType == OcrZoneType.Table)
               cells = _ocrPage.Zones.GetZoneCells(zone);

            zones.Add(new MyZoneData(zone, cells));
         }
         using (ZonePropertiesDialog dlg = new ZonePropertiesDialog(_ocrEngine, _ocrPage, _viewerControl, selectedZoneIndex))
         {
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               // We should mark the page as unrecognized since we updated its zones
               _ocrPage.Unrecognize();

               UpdateUIState();

               RefreshPagesControl(false);
            }
            else
            {
               // Restore the old zones
               _ocrPage.Zones.Clear();
               foreach (MyZoneData zoneData in zones)
               {
                  _ocrPage.Zones.Add(zoneData.Zone);
                  if (zoneData.ZoneCells != null)
                     _ocrPage.Zones.SetZoneCells(zoneData.Zone, zoneData.ZoneCells);
               }
            }

            // Let the viewer control know that the zones has been updated
            _viewerControl.ZonesUpdated();
         }

         CheckOmrOptions();
      }

      private void ConvertLD()
      {
         // Get the last format, options and document file name selected by the user
         DocumentWriter docWriter = _ocrEngine.DocumentWriterInstance;

         Properties.Settings settings = new Properties.Settings();

         DocumentFormat initialFormat = DocumentFormat.Pdf;

         if (!string.IsNullOrEmpty(settings.Format))
         {
            try
            {
               initialFormat = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), settings.Format);
            }
            catch
            {
            }
         }

         if (!string.IsNullOrEmpty(settings.FormatOptionsXml))
         {
            // Set the document writer options from the last one we saved
            try
            {
               byte[] buffer = Encoding.Unicode.GetBytes(settings.FormatOptionsXml);
               using (MemoryStream ms = new MemoryStream(buffer))
                  docWriter.LoadOptions(ms);
            }
            catch
            {
            }
         }

         // Show the convert LTD dialog
         using (ConvertLdDialog dlg = new ConvertLdDialog(_ocrDocument, docWriter, initialFormat, settings.LdFileName, _viewDocument))
         {
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               // Saved OK, save the last format, options and document file name used
               _viewDocument = dlg.SelectedViewDocument;
               settings.Format = dlg.SelectedFormat.ToString();
               settings.LdFileName = dlg.SelectedInputFileName;

               using (MemoryStream ms = new MemoryStream())
               {
                  docWriter.SaveOptions(ms);
                  settings.FormatOptionsXml = Encoding.Unicode.GetString(ms.ToArray());
               }

               settings.Save();

               // Convert the LTD file
               try
               {
                  using (WaitCursor wait = new WaitCursor())
                  {
                     docWriter.Convert(dlg.SelectedInputFileName, dlg.SelectedOutputFileName, dlg.SelectedFormat);
                     if (_viewDocument)
                     {
                        // Put some delay before loading the saved file since Windows 7 is a little slower in creating the 
                        // documents specially the EMF format.
                        System.Threading.Thread.Sleep(1000);
                        Process.Start(dlg.SelectedOutputFileName);
                     }
                  }
               }
               catch (Exception ex)
               {
                  ShowError(ex);
               }
            }
         }
      }

      private void DoUpdateTimingLabel(string str)
      {
         _timingToolStripStatusLabel.Text = str;
      }

      private delegate void UpdateTimingLabelDelegate(string str);

      private void UpdateTimingLabel(string[] labels, TimeSpan[] times)
      {
         string str;

         if (labels != null)
         {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < labels.Length; i++)
            {
               sb.AppendFormat("{0}: {1} (s)", labels[i], times[i].TotalSeconds.ToString("F03"));
               if (i < (labels.Length - 1))
                  sb.Append(" - ");
            }

            str = sb.ToString();
         }
         else
            str = string.Empty;

         if (InvokeRequired)
            BeginInvoke(new UpdateTimingLabelDelegate(DoUpdateTimingLabel), new object[] { str });
         else
            DoUpdateTimingLabel(str);
      }

      private void DoShowError(Exception ex)
      {
         // Shows an error, check if the exception is an OCR, raster or general one
         OcrException ocr = ex as OcrException;
         if (ocr != null)
         {
            Messager.ShowError(this, string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_OCRError"), ocr.Code, ocr.Message));
            return;
         }

         OcrComponentMissingException ocrComponent = ex as OcrComponentMissingException;
         if (ocrComponent != null)
         {
            Messager.ShowError(this, string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_OCRComponentMissing"), ocrComponent.Message));
            return;
         }

         RasterException raster = ex as RasterException;
         if (raster != null)
         {
            Messager.ShowError(this, string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_LEADError"), raster.Code, raster.Message));
            return;
         }

         Messager.ShowError(this, ex);
      }

      private delegate void ShowErrorDelegate(Exception ex);

      private void ShowError(Exception ex)
      {
         if (InvokeRequired)
            BeginInvoke(new ShowErrorDelegate(DoShowError), new object[] { ex });
         else
            DoShowError(ex);
      }

      private void _fileExitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private bool HasOmrZones()
      {
         foreach (IOcrPage ocrPage in _ocrDocument.Pages)
         {
            foreach (OcrZone ocrZone in ocrPage.Zones)
            {
               if (ocrZone.ZoneType == OcrZoneType.Omr)
                  return true;
            }
         }
         return false;
      }

      public static Color ConvertColor(RasterColor color)
      {
         return Leadtools.Drawing.RasterColorConverter.ToColor(color);
      }

      public static RasterColor ConvertColor(Color color)
      {
         return Leadtools.Drawing.RasterColorConverter.FromColor(color);
      }

      private void CheckOmrOptions()
      {
         if (_omrOptionsDismissed || _ocrDocument == null || _ocrDocument.Pages.Count == 0)
            return;

         if (HasOmrZones())
         {
            _omrOptionsDismissed = true;

            using (OcrOmrOptionsDialog dlg = new OcrOmrOptionsDialog(_ocrEngine))
            {
               dlg.ShowDialog(this);
            }
         }
      }

      private void _saveAllPagesZonesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SaveZones(true);
      }

      private void _loadAllPagesZonesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LoadZones(true);
      }

      private void _clearAllPagesZonesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         foreach (IOcrPage page in _ocrDocument.Pages)
         {
            page.Zones.Clear();
            page.Unrecognize();
         }

         // Re-paint current page to show new zones
         _viewerControl.ZonesUpdated();
         UpdateUIState();
         // Update the thumbnail(s)
         RefreshPagesControl(true);
      }

      private void _pagesDetectPageLanguagesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (DetectPageLanguagesDialog dlg = new DetectPageLanguagesDialog(_ocrEngine, _ocrPage))
         {
            dlg.ShowDialog(this);
            _viewerControl.ZonesUpdated();
         }
      }

      private void _manualPerspectiveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         PerspectiveDeskewActive = true;
         _mainMenuStrip.Enabled = false;
         _mainToolStrip.Enabled = false;
         _viewerControl.UpdateUIState();
         _pagesControl.UpdateUIState();
         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode;
         _viewerControl.ZonesUpdated();

         PerspectiveDialog perspectiveDlg = new PerspectiveDialog(this, _viewerControl, true);
         perspectiveDlg.Action += new EventHandler<ActionEventArgs>(perspectiveDlg_Action);
         perspectiveDlg.Show();
      }

      private void _inversePerspectiveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         PerspectiveDeskewActive = true;
         _mainMenuStrip.Enabled = false;
         _mainToolStrip.Enabled = false;
         _viewerControl.UpdateUIState();
         _pagesControl.UpdateUIState();
         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode;
         _viewerControl.ZonesUpdated();

         PerspectiveDialog perspectiveDlg = new PerspectiveDialog(this, _viewerControl, false);
         perspectiveDlg.Action += new EventHandler<ActionEventArgs>(perspectiveDlg_Action);
         perspectiveDlg.Show();
      }

      private void _perspectiveDeskewToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_viewerControl.ImageViewer.Image != null && _viewerControl.ImageViewer.Image.BitsPerPixel != 24 && _viewerControl.ImageViewer.Image.BitsPerPixel != 32)
         {
            MessageBox.Show("This function only works on 24-BPP and 32-BPP images", "Perspective Deskew", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
         }

         RunImageProcessingCommand(new PerspectiveDeskewCommand());
      }

      void perspectiveDlg_Action(object sender, ActionEventArgs e)
      {
         IOcrPage ocrPage = _ocrDocument.Pages[CurrentPageIndex];
         if (ocrPage != null)
         {
            if (!PerspectiveDeskewActive)
            {
               _viewerControl.UpdateUIState();
               _pagesControl.UpdateUIState();
               _mainMenuStrip.Enabled = true;
               _mainToolStrip.Enabled = true;
            }
         }

         _viewerControl.ZonesUpdated();
         PerspectiveDialog perspectiveDlg = e.Data as PerspectiveDialog;
         if (!perspectiveDlg.IsDisposed && !perspectiveDlg.OkButtonPressed)
            return;

         // Called from the PerspectiveDialog when a OK or Apply buttons clicked
         switch (e.Action)
         {
            case "ManualPerspectiveCommand":
            case "InversePerspectiveCommand":
               using (WaitCursor wait = new WaitCursor())
               {
                  ocrPage.Zones.Clear();
                  ocrPage.Unrecognize();
                  ocrPage.SetRasterImage(_viewerControl.ImageViewer.Image);

                  // Re-paint current page
                  _viewerControl.ZonesUpdated();
                  UpdateUIState();
                  // Update the thumbnail(s)
                  RefreshPagesControl(true);
                  GotoPage(CurrentPageIndex);
               }
               break;
         }

         perspectiveDlg.Action -= new EventHandler<ActionEventArgs>(perspectiveDlg_Action);
         PerspectiveDeskewActive = false;
         _mainMenuStrip.Enabled = true;
         _mainToolStrip.Enabled = true;
         _viewerControl.UpdateUIState();
         _pagesControl.UpdateUIState();
      }

      void UpdateActiveSpellCheckerLabel(OcrSpellCheckEngine spellCheckEngine)
      {
         _activeSpellCheckerToolStripStatusLabel.Text = Enum.GetName(typeof(OcrSpellCheckEngine), spellCheckEngine);
      }

      private void MainForm_Resize(object sender, EventArgs e)
      {
         _viewerControl.ZonesUpdated();
      }

      private void _unwarpToolStripMenuItem_Click(object sender, EventArgs e)
      {
         UnWarpActive = true;
         _mainMenuStrip.Enabled = false;
         _mainToolStrip.Enabled = false;
         _viewerControl.UpdateUIState();
         _pagesControl.UpdateUIState();
         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode;
         _viewerControl.ZonesUpdated();

         UnWarpDialog unwarpDlg = new UnWarpDialog(this, _viewerControl);
         unwarpDlg.Action += new EventHandler<ActionEventArgs>(unwarpDlg_Action);
         unwarpDlg.Show();
      }

      void unwarpDlg_Action(object sender, ActionEventArgs e)
      {
         IOcrPage ocrPage = _ocrDocument.Pages[CurrentPageIndex];
         if (ocrPage != null)
         {
            if (!UnWarpActive)
            {
               _viewerControl.UpdateUIState();
               _pagesControl.UpdateUIState();
               _mainMenuStrip.Enabled = true;
               _mainToolStrip.Enabled = true;
            }
         }

         _viewerControl.ZonesUpdated();
         UnWarpDialog unwarpDlg = e.Data as UnWarpDialog;
         if (!unwarpDlg.IsDisposed && !unwarpDlg.OkButtonPressed)
            return;

         // Called from the UnWarpDialog when a OK or Apply buttons clicked
         switch (e.Action)
         {
            case "UnWarpCommand":
               using (WaitCursor wait = new WaitCursor())
               {
                  ocrPage.Zones.Clear();
                  ocrPage.Unrecognize();
                  ocrPage.SetRasterImage(_viewerControl.ImageViewer.Image);

                  // Re-paint current page
                  _viewerControl.ZonesUpdated();
                  UpdateUIState();
                  // Update the thumbnail(s)
                  RefreshPagesControl(true);
                  GotoPage(CurrentPageIndex);
               }
               break;
         }

         unwarpDlg.Action -= new EventHandler<ActionEventArgs>(unwarpDlg_Action);
         UnWarpActive = false;
         _mainMenuStrip.Enabled = true;
         _mainToolStrip.Enabled = true;
         _viewerControl.UpdateUIState();
         _pagesControl.UpdateUIState();
      }
   }
}
