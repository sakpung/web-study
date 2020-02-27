// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
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
using Leadtools.Controls;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Effects;
using Leadtools.Ocr;
using Leadtools.Document.Writer;
using System.ComponentModel;

namespace OcrDemo
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
      private bool _saveAfterRecognize;
      private string _ocrDocumentFilePath;
      private string _openInitialPath = string.Empty;
      private string _fileName = string.Empty;
      private static bool _customFileName = false; // Has user given own file name for save.
      private static bool _documentMode = false;
      private static string _outputDir = string.Empty;

      public static bool PerspectiveDeskewActive = false;
      public static bool UnWarpActive = false;

      public MainForm()
      {
         InitializeComponent();

         _mainSplitContainer.Panel1Collapsed = true;
         _viewerVertSplitContainer.Panel2Collapsed = true;

         // Setup the caption for this demo
         Messager.Caption = "C# OCR Demo";

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
               Messager.ShowError(this, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org");
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
         _saveAfterRecognize = false;
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

         try
         {
            _ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, false);

#if LT_CLICKONCE
            _ocrEngine.Startup( _rasterCodecs, null, null, Application.StartupPath + @"\OCR Engine" );
#else
            _ocrEngine.Startup(_rasterCodecs, null, null, null);
#endif // #if LT_CLICKONCE


            UpdateActiveSpellCheckerLabel((_ocrEngine.SpellCheckManager != null) ? _ocrEngine.SpellCheckManager.SpellCheckEngine : OcrSpellCheckEngine.None);
            // Set document writer options
            SetDocumentWriterOptions();
            UpdateUIState();

            Application.DoEvents();
         }
         catch (System.Exception ex)
         {
            string message = string.Format("{0}. This demo cannot start without OCR capabilities.", ex.Message);
            MessageBox.Show(this, message, "Engine Startup", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
         }

         // Load the default document
#if LT_CLICKONCE
         string defaultDocumentFile = Path.Combine(Application.StartupPath, "ocr1.tif");
#else
         string defaultDocumentFile = Path.Combine(DemosGlobal.ImagesFolder, "ocr1.tif");
#endif

         if (File.Exists(defaultDocumentFile))
            OpenDocument(defaultDocumentFile, null, 1, 1);
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
         settings.Save();

         if (_ocrPage != null)
         {
            if (!IsOcrDocumentInMemory())
               _ocrPage.Dispose();
            _ocrPage = null;
         }

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

      private void SetDocumentWriterOptions()
      {
         DocDocumentOptions docOptions = _ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.Doc) as DocDocumentOptions;
         docOptions.TextMode = DocumentTextMode.Framed;

         DocxDocumentOptions docxOptions = _ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.Docx) as DocxDocumentOptions;
         docxOptions.TextMode = DocumentTextMode.Framed;

         RtfDocumentOptions rtfOptions = _ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.Rtf) as RtfDocumentOptions;
         rtfOptions.TextMode = DocumentTextMode.Framed;

         AltoXmlDocumentOptions altoXmlOptions = _ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.AltoXml) as AltoXmlDocumentOptions;
         altoXmlOptions.Formatted = true;
      }

      private void _fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update the UI state of the File menu items

         if (_twainSession == null)
            _fileScanToolStripMenuItem.Enabled = false;
      }

      private void _fileOpenToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OpenDocument();
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
            InsertPages(null, 1, 1, e.Image, -1);
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

         _editCopyToolStripMenuItem.Enabled = _ocrPage != null;
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
                  RasterImage image = RasterClipboard.Paste(this.Handle);
                  InsertPages(null, 1, 1, image, -1);
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

         bool isOcrPageAvailable = _ocrPage != null;

         _viewZoomOutToolStripMenuItem.Enabled = isOcrPageAvailable;
         _viewZoomInToolStripMenuItem.Enabled = isOcrPageAvailable;

         _viewFitWidthToolStripMenuItem.Enabled = isOcrPageAvailable;
         _viewFitPageToolStripMenuItem.Enabled = isOcrPageAvailable;

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

      private void _pageToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update the UI state of the Pages menu items

         bool isOcrPageAvailable = _ocrPage != null;

         _pageSaveProcessingImageToDiskToolStripMenuItem.Enabled = isOcrPageAvailable;
         _pageDetectPageLanguagesToolStripMenuItem.Enabled = isOcrPageAvailable;
         _pageCloseCurrentPageToolStripMenuItem.Enabled = isOcrPageAvailable && !IsOcrDocumentInMemory();
         _pageSaveRecognizedDataAsXmlToolStripMenuItem.Enabled = isOcrPageAvailable && _ocrPage.IsRecognized;
      }

      private void _processToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update 'Process' menu items
         bool isInMemory = IsOcrDocumentInMemory();
         bool isOcrPageAvailable = _ocrPage != null;

         _processAllPagesToolStripMenuItem.Enabled = isInMemory;
         _processFlipToolStripMenuItem.Enabled = isOcrPageAvailable;
         _processReverseToolStripMenuItem.Enabled = isOcrPageAvailable;
         _processRotate90ClockwiseToolStripMenuItem.Enabled = isOcrPageAvailable;
         _processRotate90CounterClockwiseToolStripMenuItem.Enabled = isOcrPageAvailable;
         _processPreprocessToolStripMenuItem.Enabled = isOcrPageAvailable;
         _documentCleanupToolStripMenuItem.Enabled = isOcrPageAvailable;
         _binarizationToolStripMenuItem.Enabled = isOcrPageAvailable;
         _brightnessToolStripMenuItem.Enabled = isOcrPageAvailable;
         _processPageSplitterToolStripMenuItem.Enabled = isOcrPageAvailable;
         _processExpandContentToolStripMenuItem.Enabled = isOcrPageAvailable;
         _processLineRemoveToolStripMenuItem.Enabled = (isOcrPageAvailable && _ocrPage.BitsPerPixel == 1);
         _manualPerspectiveToolStripMenuItem.Enabled = isOcrPageAvailable;
         _inversePerspectiveToolStripMenuItem.Enabled = isOcrPageAvailable;
         _perspectiveDeskewToolStripMenuItem.Enabled = isOcrPageAvailable;
         _unwarpToolStripMenuItem.Enabled = isOcrPageAvailable && (_ocrPage.BitsPerPixel == 1 || _ocrPage.BitsPerPixel == 8 || _ocrPage.BitsPerPixel == 24 || _ocrPage.BitsPerPixel == 32);
      }

      private void _pagesSaveProcessingImageToDiskToolStripMenuItem_Click(object sender, EventArgs e)
      {
         string tifFileName = null;

         using (SaveFileDialog dlg = new SaveFileDialog())
         {
            dlg.Title = "Save processing image for this page as TIF";
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

      private void _pagesDetectPageLanguagesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (DetectPageLanguagesDialog dlg = new DetectPageLanguagesDialog(_ocrEngine, _ocrPage))
         {
            dlg.ShowDialog(this);
            _viewerControl.ZonesUpdated();
         }
      }

      private void _pageCloseCurrentPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         CloseCurrentOcrPage();
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
               switch (command)
               {
                  case OcrAutoPreprocessPageCommand.Deskew:
                     {
                        int angle = _ocrPage.GetDeskewAngle();
                        sb.AppendLine("Deskew angle is " + (angle / 10.0).ToString());
                     }
                     break;

                  case OcrAutoPreprocessPageCommand.Rotate:
                     {
                        int angle = _ocrPage.GetRotateAngle();
                        sb.AppendLine("Rotate angle is " + angle.ToString());
                     }
                     break;

                  case OcrAutoPreprocessPageCommand.Invert:
                     {
                        bool isInverted = _ocrPage.IsInverted();

                        if (isInverted)
                           sb.AppendLine("Page is inverted");
                        else
                           sb.AppendLine("Page is not inverted");
                     }
                     break;
               }
            }

            MessageBox.Show(this, sb.ToString(), "Pre-processing", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
         if (!IsOcrDocumentInMemory())
         {
            MessageBox.Show("This function only works in memory mode, please create in-memory OCR document first.", "Page splitter", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
         }

         bool allPages = _processAllPagesToolStripMenuItem.Checked;
         int pagesCount = 1;
         int firstPageIndex = 0;
         int lastPageIndex = 0;
         if (allPages)
         {
            pagesCount = GetOcrDocumentPagesCount();
            lastPageIndex = pagesCount - 1;
            if (pagesCount > 1)
            {
               if (MessageBox.Show("This function only works on 1-BPP images, so if any of your document pages is not then it will be converted to 1-BPP, press 'Yes' if you wish to proceed.", "Page splitter", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                  return;
            }
         }
         else
         {
            firstPageIndex = _currentPageIndex;
            lastPageIndex = _currentPageIndex;
            if (_viewerControl.ImageViewer.Image != null && _viewerControl.ImageViewer.Image.BitsPerPixel != 1)
            {
               if (MessageBox.Show("This function only works on 1-BPP images, press 'Yes' to convert the current image to 1-BPP and proceed.", "Page splitter", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
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
            pagesCount = IsOcrDocumentInMemory() ? GetOcrDocumentPagesCount() : 1;
            lastPageIndex = pagesCount - 1;
            if (pagesCount > 1)
            {
               if (MessageBox.Show("This function only works on 1-BPP images, so if any of your document pages is not then it will be converted to 1-BPP, press 'Yes' if you wish to proceed.", "Page expand content", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                  return;
            }
         }
         else
         {
            firstPageIndex = _currentPageIndex;
            lastPageIndex = _currentPageIndex;
            if (_viewerControl.ImageViewer.Image != null && _viewerControl.ImageViewer.Image.BitsPerPixel != 1)
            {
               if (MessageBox.Show("This function only works on 1-BPP images, press 'Yes' to convert the current image to 1-BPP and proceed.", "Page expand content", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                  return;
            }
         }

         for (int i = firstPageIndex; i <= lastPageIndex; i++)
         {
            // Get the processed 1-BPP image from each OCR page and set it as the original page image
            IOcrPage ocrPage = null;
            if (IsOcrDocumentInMemory())
               ocrPage = _ocrDocument.Pages[i];
            else
               ocrPage = _ocrPage;
            RasterImage processingImage = ocrPage.GetRasterImage(OcrPageType.Processing);
            if (processingImage != null)
               ocrPage.SetRasterImage(processingImage);
         }

         RunImageProcessingCommand(new ExpandContentCommand());
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
         int pagesCount = 1;

         if (IsOcrDocumentInMemory())
            pagesCount = GetOcrDocumentPagesCount();

         for (int i = 0; i < pagesCount; i++)
         {
            IOcrPage ocrPage = null;
            if (IsOcrDocumentInMemory())
               ocrPage = _ocrDocument.Pages[i];
            else
               ocrPage = _ocrPage;

            if (ocrPage != null)
            {
               ocrPage.Zones.Clear();
               ocrPage.Unrecognize();
            }
         }

         // Re-paint current page to show new zones
         _viewerControl.ZonesUpdated();
         UpdateUIState();
         // Update the thumbnail(s)
         RefreshPagesControl(true);
      }

      private void _zonesShowZonesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.ShowZones = !_viewerControl.ShowZones;
      }

      private void _zonesShowZoneNamesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.ShowZoneNames = !_viewerControl.ShowZoneNames;
      }

      private void _zonesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update 'Zones' menu items
         bool isInMemory = IsOcrDocumentInMemory();
         bool isOcrPageAvailable = _ocrPage != null;

         _zonesAutoZoneDocumentToolStripMenuItem.Enabled = isInMemory && GetOcrDocumentPagesCount() > 0;
         _zonesAutoZoneCurrentPageToolStripMenuItem.Enabled = isOcrPageAvailable;
         _zonesUpdateZonesToolStripMenuItem.Enabled = isOcrPageAvailable;
         _zonesLoadZonesToolStripMenuItem.Enabled = isOcrPageAvailable;
         _zonesSaveZonesToolStripMenuItem.Enabled = isOcrPageAvailable && _ocrPage.Zones.Count > 0;
         _loadAllPagesZonesToolStripMenuItem.Enabled = isInMemory && GetOcrDocumentPagesCount() > 0;
         _saveAllPagesZonesToolStripMenuItem.Enabled = isInMemory && GetOcrDocumentPagesCount() > 0;
         _clearAllPagesZonesToolStripMenuItem.Enabled = (isOcrPageAvailable) || (isInMemory && GetOcrDocumentPagesCount() > 0);
         _zonesShowZonesToolStripMenuItem.Checked = _viewerControl.ShowZones;
         _zonesShowZoneNamesToolStripMenuItem.Checked = _viewerControl.ShowZoneNames;
      }

      private void _recognizeToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update 'Recognize' menu items
         bool isInMemory = IsOcrDocumentInMemory();
         bool isOcrPageAvailable = _ocrPage != null;

         _recognizeRecognizeDocumentToolStripMenuItem.Enabled = isInMemory && GetOcrDocumentPagesCount() > 0;
         _recognizeRecognizePageToolStripMenuItem.Enabled = isOcrPageAvailable;
         _recognizeSaveAfterRecognizeToolStripMenuItem.Checked = _saveAfterRecognize;

         bool enable = false;
         if (isInMemory)
         {
            foreach (IOcrPage page in _ocrDocument.Pages)
            {
               enable = page.IsRecognized;
               if (enable)
                  break;
            }
         }
         else
            enable = (_ocrPage != null) ? _ocrPage.IsRecognized : false;
      }

      private void _documentToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         // Update 'Document' menu items
         bool isInMemory = IsOcrDocumentInMemory();
         bool isOcrPageAvailable = _ocrPage != null;

         _documentAddCurrentPageToolStripMenuItem.Enabled = (_ocrDocument != null) && isOcrPageAvailable && ((isInMemory) ? !IsCurrentOcrPagePartOfOcrDocument() : true);
         _documentInsertPagesToolStripMenuItem.Enabled = (_ocrDocument != null) && isInMemory;
         _documentRemoveCurrentPageToolStripMenuItem.Enabled = (_ocrDocument != null) && isOcrPageAvailable && isInMemory;
         _documentClearDocumentPagesToolStripMenuItem.Enabled = (_ocrDocument != null) && isInMemory && GetOcrDocumentPagesCount() > 0;
         _documentSaveDocumentToolStripMenuItem.Enabled = (isOcrPageAvailable || ((_ocrDocument != null) && GetOcrDocumentPagesCount() > 0));
         _documentCloseDocumentToolStripMenuItem.Enabled = (_ocrDocument != null);
         _documentSaveRecognizedDataAsXmlToolStripMenuItem.Enabled = (_ocrDocument != null && _ocrDocument.IsInMemory && _ocrDocument.Pages.Count > 0);
      }

      private void _recognizeRecognizeDocumentToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RecognizeDocument(true);
      }

      private void _recognizeRecognizePageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RecognizeDocument(false);
      }

      private void SaveRecognizedDataAsXml(bool saveActivePageOnly)
      {
         using (SaveRecognizedXmlDialog dlg = new SaveRecognizedXmlDialog())
         {
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               try
               {
                  using (WaitCursor wait = new WaitCursor())
                  {
                     OcrWriteXmlOptions xmlOptions = new OcrWriteXmlOptions(OcrXmlEncoding.UTF8, true, "  ");
                     OcrXmlOutputOptions outputOptions = dlg.OutputOptions;
                     String fileName = dlg.FileName;

                     if (saveActivePageOnly)
                        _ocrPage.SaveXml(fileName, 1, xmlOptions, outputOptions);
                     else
                        _ocrDocument.SaveXml(fileName, xmlOptions, outputOptions);

                     System.Threading.Thread.Sleep(1000);
                     System.Diagnostics.Process.Start(fileName);
                  }
               }
               catch (Exception ex)
               {
                  MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  DialogResult = DialogResult.None;
               }
            }
         }
      }

      private void _recognizeSpellCheckEngineStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_ocrEngine.SpellCheckManager == null)
         {
            MessageBox.Show("Feature not supported for this engine.", "Spell Language", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
         }

         using (SpellCheckEngineDialog dlg = new SpellCheckEngineDialog(_ocrEngine))
         {
            if (dlg.ShowDialog() == DialogResult.OK)
               UpdateActiveSpellCheckerLabel((_ocrEngine.SpellCheckManager != null) ? _ocrEngine.SpellCheckManager.SpellCheckEngine : OcrSpellCheckEngine.None);
         }
      }

      private void _recognizeOmrOptionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (OcrOmrOptionsDialog dlg = new OcrOmrOptionsDialog(_ocrEngine))
            dlg.ShowDialog(this);
      }

      private void _recognizeSaveAfterRecognizeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _saveAfterRecognize = !_recognizeSaveAfterRecognizeToolStripMenuItem.Checked;
         _recognizeSaveAfterRecognizeToolStripMenuItem.Checked = _saveAfterRecognize;
      }

      private void _documentCreateDocumentToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Properties.Settings settings = new Properties.Settings();
         _ocrDocumentFilePath = settings.OcrDocumentFilePath;
         using (CreateOcrDocumentDialog dlg = new CreateOcrDocumentDialog(_ocrDocumentFilePath))
         {
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               _ocrDocumentFilePath = dlg.OcrDocumentFilePath;
               settings.OcrDocumentFilePath = _ocrDocumentFilePath;
               settings.Save();

               CreateOcrDocument(dlg.OcrDocumentOptions, _ocrDocumentFilePath, true);
            }
         }
      }

      private void _documentLoadDocumentToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (OpenFileDialog dlg = new OpenFileDialog())
         {
            string extension = "ltd";
            string friendlyName = "LEAD Temporary Document";
            dlg.Filter = string.Format("{0} (*.{1})|*.{1}|All Files (*.*)|*.*", friendlyName, extension);
            dlg.DefaultExt = extension;
            dlg.Title = "Select LEAD Temporary Document File (LTD)";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               CreateOcrDocument(OcrCreateDocumentOptions.LoadExisting, dlg.FileName, true);
            }
         }
      }

      private void _documentAddCurrentPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Insert the existing OCR page into the document
         // Check if we have file based document then use IOcrPageCollection.Add else then use IOcrPageCollection.Insert
         // because the insert function is only supported for memory based document.
         using (WaitCursor wait = new WaitCursor())
         {
            if (!IsOcrDocumentInMemory())
            {
               if (!_ocrPage.IsRecognized)
               {
                  if (MessageBox.Show("This page is not recognized. Are you sure you want to add it to this file-based Document? Saving this document will save the page as an image without any OCR data", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                     return;
               }
               _ocrDocument.Pages.Add(_ocrPage);
            }
            else
               _ocrDocument.Pages.Insert(-1, _ocrPage);

            RefreshPagesControl(false);
            RepopulateDocumentInformationControl();
         }
      }

      private void _documentInsertPagesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         InsertPages();
      }

      private void _documentRemoveCurrentPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DeletePage(CurrentPageIndex);
      }

      private void _documentClearDocumentPagesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_ocrDocument != null)
            _ocrDocument.Pages.Clear();

         // Check if in memory mode and the current loaded page is part of the cleared document, then just set
         // the _ocrPage to null since the OCR document already freed that OCR page.
         if (IsOcrDocumentInMemory())
         {
            _ocrPage = null;
            _pagesControl.RasterImageList.Items.Clear();
         }

         _currentPageIndex = -1;
         _viewerControl.ClearZones();
         _viewerControl.SetImageAndPage(null, null);
         _viewerControl.SetPages(0, 0);

         RepopulatePagesControl(-1, -1, string.Empty);
         RepopulateDocumentInformationControl();
         RepopulateOcrPageTextWindow();
      }

      private void _documentSaveDocumentToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SaveDocument();
      }

      private void _documentCloseDocumentToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DoCloseOcrDocument(true);
      }

      private void DoCloseOcrDocument(bool showWarning)
      {
         // Show warning message to the user that he is going to close the OCR document as reminder to save before close
         if (showWarning)
         {
            if (MessageBox.Show(this, "Are you sure you want to close current OCR document?", "Close Document", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
               return;
         }

         bool isInMemory = IsOcrDocumentInMemory();
         _ocrDocument.Dispose();
         _ocrDocument = null;
         _customFileName = false;
         // Remove check mark from 'All pages' menu item inside 'Preprocess' menu
         _processAllPagesToolStripMenuItem.Checked = false;

         if (isInMemory)
         {
            _ocrPage = null;
            _pagesControl.RasterImageList.Items.Clear();
            _viewerControl.ClearZones();
            _viewerControl.SetImageAndPage(null, null);
            _viewerControl.SetPages(0, 0);
         }

         _documentMode = false;

         _viewerControl.Title = string.Empty;
         RepopulatePagesControl(-1, -1, string.Empty);
         RepopulateDocumentInformationControl();
         RepopulateOcrPageTextWindow();
         UpdateUIState();
      }

      private void _preferencesUseProgressBarsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _preferencesUseProgressBarsToolStripMenuItem.Checked = !_preferencesUseProgressBarsToolStripMenuItem.Checked;
      }

      private void _helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("OCR", ProgrammingInterface.CS))
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
         _recognizeRecognizeDocumentToolStripMenuItem.PerformClick();
      }

      private void _recognizePageToolStripButton_Click(object sender, EventArgs e)
      {
         _recognizeRecognizePageToolStripMenuItem.PerformClick();
      }

      private void _saveDocumentToolStripButton_Click(object sender, EventArgs e)
      {
         _documentSaveDocumentToolStripMenuItem.PerformClick();
      }

      private void UpdateUIState()
      {
         // Update the UI state

         bool isInMemory = IsOcrDocumentInMemory();
         bool isOcrPageAvailable = _ocrPage != null;
         bool isOcrDocumentAvailable = _ocrDocument != null;

         // Update toolbar buttons
         _autoZoneDocumentToolStripButton.Enabled = isInMemory && GetOcrDocumentPagesCount() > 0;
         _autoZonePageToolStripButton.Enabled = isOcrPageAvailable;
         _recognizeDocumentToolStripButton.Enabled = isInMemory && GetOcrDocumentPagesCount() > 0;
         _recognizePageToolStripButton.Enabled = isOcrPageAvailable;
         _saveDocumentToolStripButton.Enabled = isOcrPageAvailable || isOcrDocumentAvailable;

         _recognizeToolStripMenuItem_DropDownOpening(null, null);
         _documentToolStripMenuItem_DropDownOpening(null, null);
      }

      private void OpenDocument()
      {
         // Open a document from disk

         Properties.Settings settings = new Properties.Settings();

         // Show the LEADTOOLS common dialog
         ImageFileLoader loader = new ImageFileLoader();
         loader.LoadOnlyOnePage = true;
         loader.ShowLoadPagesDialog = true;
         loader.OpenDialogInitialPath = _openInitialPath;
         if (!String.IsNullOrEmpty(settings.OpenDialogInitialPath))
            loader.OpenDialogInitialPath = settings.OpenDialogInitialPath;
         if (String.IsNullOrEmpty(loader.OpenDialogInitialPath))
            loader.OpenDialogInitialPath = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
         try
         {
            // Insert the pages loader into the document
            if (loader.Load(this, _rasterCodecs, false) > 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               settings.OpenDialogInitialPath = Path.GetDirectoryName(loader.FileName);
               settings.Save();

               if(!_documentMode)
                  _customFileName = false;

               OpenDocument(loader.FileName, null, loader.FirstPage, loader.LastPage);
            }
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
      }

      private void SetFileName(string fileName)
      {
         if (_documentMode && (_ocrDocument != null) && !(_ocrDocument.Pages.Count >= 1))
         {
            _fileName = fileName;
         }
         else if (!_documentMode && _outputDir.Equals(String.Empty))
         {
            if (_customFileName)
               _fileName = Path.Combine(Path.GetDirectoryName(_fileName), Path.GetFileName(fileName));
            else
               _fileName = fileName;
         }
         else if (!_documentMode)
         {
            if (fileName != null)
            {
               if (!_outputDir.Equals(String.Empty))
                  _fileName = Path.Combine(_outputDir, Path.GetFileName(fileName));
               else if (_customFileName)
                  _outputDir = Path.GetDirectoryName(_fileName);
            }
         }
      }

      private void OpenDocument(string fileName, RasterImage rasterImage, int firstPage, int lastPage)
      {
         // Open the document in file name

         try
         {
            SetFileName(fileName);

            bool multipage = lastPage != firstPage;
            if (multipage && _ocrDocument != null && !IsOcrDocumentInMemory())
            {
               // We already have a File OCR document loaded, so inform the user that the current OCR document will be closed 
               // cause a new InMemory document is going to be created.
               if (MessageBox.Show(this, "In order to load a multi-page file the current file based OCR document should be closed and create new memory based one, do you wish to continue?", "Load Multi-Page", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                  return;
            }

            if (_ocrPage != null && !IsOcrDocumentInMemory())
            {
               // Dispose the current OcrPage (if exists)
               _ocrPage.Dispose();
               _ocrPage = null;
               _viewerControl.SetImageAndPage(null, null);
            }

            // Check if have OCR document in memory then we need to append the loaded pages into that document, 
            // if we don't have InMemory document and we are only loading one page then don't create a document
            if (multipage && !IsOcrDocumentInMemory())
               CreateOcrDocument(OcrCreateDocumentOptions.InMemory, null, false);

            // Clear previous document pages when called from "File" -> "Open" menu
            _documentClearDocumentPagesToolStripMenuItem.PerformClick();

            DateTime beginTime = DateTime.Now;
            int pageIndex = CurrentPageIndex;

            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = true;
            Form popup = new Form();
            popup.MainMenuStrip = null;
            popup.ShowInTaskbar = false;
            Size popupSize = new Size(300, 100);
            popup.MinimumSize = popupSize;
            popup.MaximumSize = popupSize;
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.FormBorderStyle = FormBorderStyle.None;
            ProgressBar progress = new ProgressBar();
            progress.Maximum = 100;
            progress.Step = 1;
            progress.Value = 0;
            progress.Location = new Point((popup.Width / 2) - 125, (popup.Height / 2) - 12);
            progress.Height = 25;
            progress.Width = 250;
            Label progressText = new Label();
            progressText.Width = popupSize.Width;
            progressText.TextAlign = ContentAlignment.MiddleCenter;
            Button cancel = new Button();
            cancel.Text = "Cancel";
            cancel.Size = new Size(80, 25);
            cancel.Location = new Point((popup.Width / 2) - 40, (popup.Height - 30));
            cancel.Click += (s, e) =>
            {
               worker.CancelAsync();
            };

            popup.Controls.Add(progress);
            popup.Controls.Add(progressText);
            popup.Controls.Add(cancel);

            Exception exception = null;
            worker.DoWork += (s, e) =>
            {
               this.BeginInvoke(new Action(() => popup.ShowDialog(this)));
               try
               {
                  Int64 uTotalMemoryUsed = 0;
                  for (int i = firstPage; i <= lastPage; i++)
                  {
                     this.BeginInvoke(new Action(() => progressText.Text = string.Format("Loading Page {0} of {1}...", i, lastPage)));
                     if (worker.CancellationPending)
                     {
                        this.BeginInvoke(new Action(() => progressText.Text = "Cancelling..."));
                        if (_ocrPage != null)
                           _ocrPage = null;

                        if (IsOcrDocumentInMemory())
                           _ocrDocument.Pages.Clear();
                        e.Cancel = true;
                        return;
                     }

                     // Load the bitmap page
                     RasterImage image = null;

                     if (rasterImage != null)
                        image = rasterImage;
                     else
                     {
#if !FOR_WIN64
                        if (uTotalMemoryUsed > (1000 << 20))
                           _rasterCodecs.Options.Load.DiskMemory = true;
#endif // #if !FOR_WIN64

                        image = _rasterCodecs.Load(fileName, i);
                        uTotalMemoryUsed += image.DataSize;
                     }

                     _ocrPage = _ocrEngine.CreatePage(image, OcrImageSharingMode.AutoDispose);

                     // Add the created IOcrPage into IOcrDocument in case of memory mode
                     if (IsOcrDocumentInMemory())
                     {
                        _ocrDocument.Pages.Insert(pageIndex + 1, _ocrPage);
                     }

                     pageIndex++;
                     worker.ReportProgress((i * 100) / lastPage);
                  }
               }
               catch (System.Exception ex2)
               {
                  exception = ex2;
                  worker.CancelAsync();
               }
            };

            worker.ProgressChanged += (s, e) =>
            {
               progress.Value = e.ProgressPercentage;
            };

            worker.RunWorkerCompleted += (s, e) =>
            {
               popup.Close();

               if (!e.Cancelled && exception == null)
               {
                  TimeSpan ts = DateTime.Now - beginTime;
                  UpdateTimingLabel(new string[] { "Load Pages" }, new TimeSpan[] { ts });

                  int pagesCount = lastPage - firstPage + 1;
                  RepopulatePagesControl(0, pagesCount, fileName);
                  RepopulateDocumentInformationControl();
                  RepopulateOcrPageTextWindow();
                  GotoPage(CurrentPageIndex + 1);
                  UpdateUIState();

                  if (!string.IsNullOrEmpty(fileName))
                     _viewerControl.Title = fileName;

                  // Go to the current page in the viewer control
                  _viewerControl.SetPages(0, pagesCount);

                  using (WaitCursor wait = new WaitCursor())
                  {
                     RasterImage image = _ocrPage.GetRasterImage(OcrPageType.Current);
                     _viewerControl.SetImageAndPage(image, _ocrPage);
                  }
               }

               if (exception != null && exception.Message.Equals("Not enough memory available"))
               {
                  DoCloseOcrDocument(false);
                  ShowError(exception);
               }
            };

            worker.RunWorkerAsync();
         }
         catch (Exception ex)
         {
            ShowError(ex);
            UpdateTimingLabel(null, null);
         }
      }

      private void CreateOcrDocument(OcrCreateDocumentOptions options, string ocrDocumentFilePath, bool showWarning)
      {
         // Create a new document
         if (_ocrDocument != null)
         {
            if (showWarning)
            {
               // We already have a OCR document loaded, so inform the user that the current OCR document will be closed.
               if (MessageBox.Show(this, "In order to create/load new OCR document, the current OCR document will be closed, do you want to proceed?", "Create OCR Document", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                  return;
            }

            if (IsOcrDocumentInMemory())
            {
               DoCloseOcrDocument(false);
            }

            if (_ocrDocument != null)
            {
               _ocrDocument.Dispose();
               _ocrDocument = null;
            }
         }

         string ocrDocumentFile = (options != OcrCreateDocumentOptions.InMemory) ? ocrDocumentFilePath : null;
         _ocrDocument = _ocrEngine.DocumentManager.CreateDocument(ocrDocumentFile, options);
         if (options == OcrCreateDocumentOptions.InMemory && _ocrPage != null)
         {
            // Insert the existing OCR page into the document
            _ocrDocument.Pages.Insert(-1, _ocrPage);
         }

         int pagesCount = GetOcrDocumentPagesCount();
         RepopulatePagesControl(0, pagesCount, _fileName);
         RepopulateDocumentInformationControl();
         RepopulateOcrPageTextWindow();
         GotoPage(-1);

         _documentMode = true;

         UpdateUIState();
      }

      private bool IsOcrDocumentInMemory()
      {
         bool isInMemory = false;

         if (_ocrDocument != null)
            isInMemory = _ocrDocument.IsInMemory;

         return isInMemory;
      }

      int GetOcrDocumentPagesCount()
      {
         int pagesCount = 0;

         if (_ocrDocument != null)
            pagesCount = _ocrDocument.Pages.Count;

         return pagesCount;
      }

      bool IsCurrentOcrPagePartOfOcrDocument()
      {
         if (IsOcrDocumentInMemory())
         {
            int pageIndex = -1;
            pageIndex = _ocrDocument.Pages.IndexOf(_ocrPage);
            if (pageIndex != -1)
               return true;
         }

         return false;
      }

      void CloseCurrentOcrPage()
      {
         if (_ocrPage != null)
         {
            _ocrPage.Dispose();
            _ocrPage = null;
            _viewerControl.ClearZones();
            _viewerControl.SetImageAndPage(null, null);
            _viewerControl.SetPages(0, 0);
            _viewerControl.Title = string.Empty;
            RepopulateOcrPageTextWindow();
            UpdateUIState();
         }
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

      private int _currentPageIndex = -1;
      private int CurrentPageIndex
      {
         get
         {
            return _currentPageIndex;
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
         SetFileName(fileName);

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

         int oldPagesCount = GetOcrDocumentPagesCount();

         // Check if we are inserting a page from file or directly
         using (WaitCursor wait = new WaitCursor())
         {
            DateTime beginTime = DateTime.Now;

            if (_ocrPage != null && !IsOcrDocumentInMemory())
            {
               _ocrPage.Dispose();
               _ocrPage = null;
            }

            for (int i = firstPage; i <= lastPage; i++)
            {
               if (image != null)
               {
                  _ocrPage = _ocrEngine.CreatePage(image, OcrImageSharingMode.AutoDispose);
               }
               else
               {
                  // Load the bitmap page
                  RasterImage rasterImage = _rasterCodecs.Load(fileName, i);
                  _ocrPage = _ocrEngine.CreatePage(rasterImage, OcrImageSharingMode.AutoDispose);
               }

               if (IsOcrDocumentInMemory())
                  _ocrDocument.Pages.Insert(pageIndex, _ocrPage);

               pageIndex++;
            }
            pageIndex--;

            TimeSpan ts = DateTime.Now - beginTime;
            UpdateTimingLabel(new string[] { "Insert pages" }, new TimeSpan[] { ts });
         }

         pageIndex -= lastPage - firstPage;
         if (CurrentPageIndex == -1)
            pageIndex = 0;

         // Update the pages control with the new document
         int newPagesCount = GetOcrDocumentPagesCount();
         RepopulatePagesControl(pageIndex, newPagesCount - oldPagesCount, fileName);
         RepopulateDocumentInformationControl();

         // Go to the first page inserted in the document
         GotoPage(pageIndex);
      }

      private void DeletePage(int pageIndex)
      {
         // Delete the current page from the document
         using (WaitCursor wait = new WaitCursor())
         {
            _ocrDocument.Pages.RemoveAt(pageIndex);

            _pagesControl.RasterImageList.Items.RemoveAt(pageIndex);
            if (_pagesControl.RasterImageList.Items.Count <= 0)
               _currentPageIndex = -1;

            if (pageIndex >= GetOcrDocumentPagesCount())
               pageIndex = GetOcrDocumentPagesCount() - 1;

            // Update the pages control with the new document
            if (pageIndex >= 0)
               UpdatePagesControlItemsText(pageIndex);

            RepopulateDocumentInformationControl();

            // Go to the current page
            GotoPage(pageIndex);
         }
      }

      private void RepopulatePagesControl(int pageIndex, int count, string fileName)
      {
         if (!IsOcrDocumentInMemory())
         {
            _pagesControl.RasterImageList.Items.Clear();
            _mainSplitContainer.Panel1Collapsed = true;
            _currentPageIndex = -1;
            return;
         }

         _mainSplitContainer.Panel1Collapsed = false;
         using (WaitCursor wait = new WaitCursor())
         {
            // Re-insert the thumbnails from the pages control
            ImageViewer imageList = _pagesControl.RasterImageList;
            imageList.BeginUpdate();

            // Loop through all the pages in the document and create thumbnails for them,
            // add the thumbnails to the pages control

            if (_ocrDocument != null)
            {
               LeadSize thumbSize = imageList.ItemSize;

               int index = pageIndex;
               if (index != -1)
               {
                  for (int i = 0; i < count; i++)
                  {
                     IOcrPage ocrPage = _ocrDocument.Pages[index];
                     RasterImage image = ocrPage.CreateThumbnail(thumbSize.Width, thumbSize.Height);
                     ImageViewerItem item = new ImageViewerItem();
                     item.Image = image;
                     item.PageNumber = 1;
                     item.Text = "Page " + (index + 1).ToString();
                     ImageListItemData itemData = null;
                     if (item.Tag != null)
                        itemData = item.Tag as ImageListItemData;
                     else
                        itemData = new ImageListItemData(fileName, ocrPage.IsRecognized);

                     item.Tag = itemData;
                     imageList.Items.Insert(index, item);
                     index++;
                  }

                  // Loop through all image list items that followed the inserted item and correct their names orders
                  for (int i = index; i < imageList.Items.Count; i++)
                  {
                     if (imageList.Items[i] != null)
                     {
                        imageList.Items[i].Text = "Page " + (i + 1).ToString();
                     }
                  }
               }
            }

            imageList.EndUpdate();
         }
      }

      void RepopulateDocumentInformationControl()
      {
         if (_ocrDocument == null)
         {
            _viewerVertSplitContainer.Panel2Collapsed = true;
            return;
         }

         _viewerVertSplitContainer.Panel2Collapsed = false;
         _documentInfoControl.RepopulateDocumentInformationControl(_ocrDocument);
      }

      void RepopulateOcrPageTextWindow()
      {
         if (_ocrPage != null)
         {
            if (!_ocrPage.IsRecognized)
            {
               _pageTextControl.SetPageText(string.Empty);
               return;
            }

            // Get the page text and update the OCR page text pane
            try
            {
               string pageText = _ocrPage.GetText(-1); // -1 will get all page recognized text
               if (pageText != null && pageText.Length > 0)
                  _pageTextControl.SetPageText(pageText);
            }
            catch (Exception ex)
            {
               ShowError(ex);
            }
         }
         else
            _pageTextControl.SetPageText(string.Empty);
      }

      private void UpdatePagesControlItemsText(int pageIndex)
      {
         ImageViewer imageList = _pagesControl.RasterImageList;

         for (int i = pageIndex; i < imageList.Items.Count; i++)
         {
            String itemText = "Page " + (i + 1).ToString();
            imageList.Items[i].Text = itemText;
         }
      }

      private void RefreshPagesControl(bool allPages)
      {
         using (WaitCursor wait = new WaitCursor())
         {
            // Re-get the thumbnails from the pages control
            ImageViewer imageList = _pagesControl.RasterImageList;
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
               ImageListItemData itemData = null;
               if (imageList.Items[i].Tag != null)
                  itemData = imageList.Items[i].Tag as ImageListItemData;
               else
                  itemData = new ImageListItemData(_fileName, false);

               if (_ocrDocument != null && _ocrDocument.Pages[i].IsRecognized)
                  itemData.IsRecognized = true;
               else
                  itemData.IsRecognized = false;

               imageList.Items[i].Tag = itemData;
            }

            imageList.EndUpdate();
         }
      }

      private void GotoPage(int pageIndex)
      {
         try
         {
            if (!IsOcrDocumentInMemory())
            {
               if (_ocrPage != null)
               {
                  RasterImage image = _ocrPage.GetRasterImage(OcrPageType.Current);
                  if (image != null)
                  {
                     _viewerControl.SetImageAndPage(image, _ocrPage);
                  }
               }
               return;
            }

            // Goto this page in the OCR document
            if (pageIndex == -1)
               pageIndex = 0;

            if (_ocrDocument != null && GetOcrDocumentPagesCount() > 0)
            {
               _ocrPage = _ocrDocument.Pages[pageIndex];

               // Set the current page in the pages control
               _pagesControl.SetCurrentPageIndex(pageIndex);
               _currentPageIndex = pageIndex;

               // Go to the current page in the viewer control
               _viewerControl.SetPages(pageIndex, GetOcrDocumentPagesCount());

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

               _currentPageIndex = -1;
               _pagesControl.SetCurrentPageIndex(-1);
               _viewerControl.ClearZones();
               _viewerControl.SetImageAndPage(null, null);
               _viewerControl.SetPages(0, 0);
            }

            if (_pagesControl.RasterImageList.Items.Count > 0 && pageIndex < _pagesControl.RasterImageList.Items.Count)
            {
               ImageViewerItem[] selectedItems = _pagesControl.RasterImageList.Items.GetSelected();
               if (selectedItems.Length > 0 && selectedItems[0].Tag != null)
               {
                  ImageListItemData itemData = selectedItems[0].Tag as ImageListItemData;
                  _viewerControl.Title = itemData.FileName;
               }
               else
                  _viewerControl.Title = _pagesControl.RasterImageList.Items[pageIndex].Text;
            }
            else
               _viewerControl.Title = String.Empty;
         }
         finally
         {
            UpdateUIState();
            RepopulateOcrPageTextWindow();
         }
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
                                 string fileName = _pagesControl.RasterImageList.Items[i].Text;

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
                           string fileName = _pagesControl.RasterImageList.Items[currentPageIndex].Text;

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

                     RasterImage image = ocrPage.GetRasterImage(OcrPageType.Current);
                     image.FlipViewPerspective(horizontal);
                     ocrPage.SetRasterImage(image);
                     _viewerControl.SetImageAndPage(image, ocrPage);
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
                  _viewerControl.SetImageAndPage(image, _ocrPage);
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

                     RasterImage image = ocrPage.GetRasterImage();
                     rotateCmd.Run(image);
                     ocrPage.SetRasterImage(image);
                     _viewerControl.SetImageAndPage(image, ocrPage);
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
                  _viewerControl.SetImageAndPage(_viewerControl.RasterImage, _ocrPage);
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
            using (OcrProgressDialog dlg = new OcrProgressDialog(allowProgress, "Preprocess", new OcrProgressDialog.ProcessDelegate(DoPreprocess), args))
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
               dlg.UpdateDescription("Preprocessing the page(s) of the document...");

            // Remove the zones from the page(s)

            if (allPages)
            {
               foreach (IOcrPage ocrPage in _ocrDocument.Pages)
               {
                  // Remove the zones from the page and un-recognize
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
            UpdateTimingLabel(new string[] { "Preprocess" }, new TimeSpan[] { ts });
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
            using (OcrProgressDialog dlg = new OcrProgressDialog(allowProgress, "Auto Zone", new OcrProgressDialog.ProcessDelegate(DoAutoZone), args))
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

      private void DoAutoZone(OcrProgressDialog dlg, Dictionary<string, object> args)
      {
         // Perform auto-zoning here

         OcrProgressCallback callback = dlg.OcrProgressCallback;

         bool allPages = (bool)args["allPages"];

         try
         {
            // If we are not using a progress bar, update the description text
            if (callback == null)
               dlg.UpdateDescription("Auto zoning the page(s) of the document...");

            DateTime beginTime = DateTime.Now;

            if (allPages)
               _ocrDocument.Pages.AutoZone(callback);
            else
               _ocrPage.AutoZone(callback);

            TimeSpan ts = DateTime.Now - beginTime;
            UpdateTimingLabel(new string[] { "Auto Zone" }, new TimeSpan[] { ts });
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
            using (OcrProgressDialog dlg = new OcrProgressDialog(allowProgress, "Recognize", new OcrProgressDialog.ProcessDelegate(DoRecognize), args))
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

            // offer to save the recognized page/document after recognize
            if (_saveAfterRecognize)
               SaveDocument();
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
               dlg.UpdateDescription("Recognizing the page(s) of the document...");

            DateTime beginTime = DateTime.Now;

            if (allPages)
               _ocrDocument.Pages.Recognize(callback);
            else
               _ocrPage.Recognize(callback);

            TimeSpan ts = DateTime.Now - beginTime;
            UpdateTimingLabel(new string[] { "Recognize" }, new TimeSpan[] { ts });
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
         // If we have an empty document, nothing gets saved unless the document has some pages. Check...
         if (_ocrDocument != null)
         {
            int pageCount = GetOcrDocumentPagesCount();
            if (pageCount == 0)
            {
               MessageBox.Show("This document has no pages. Add at least one page and try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return;
            }

            // check if we have memory mode document then check if non of its pages were recognized then recognize all pages first
            if (IsOcrDocumentInMemory())
            {
               bool documentHasNoRecognizedPages = true;
               for (int i = 0; i < pageCount; i++)
               {
                  IOcrPage ocrPage = null;
                  ocrPage = _ocrDocument.Pages[i];
                  if (ocrPage != null)
                  {
                     if (ocrPage.IsRecognized)
                     {
                        documentHasNoRecognizedPages = false;
                        break;
                     }
                  }
               }

               if (documentHasNoRecognizedPages)
               {
                  _recognizeRecognizeDocumentToolStripMenuItem.PerformClick();
               }
            }
         }

         // Get the last format, options and document file name selected by the user
         DocumentWriter docWriter = _ocrEngine.DocumentWriterInstance;

         Properties.Settings settings = new Properties.Settings();
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

         IOcrDocument tempOcrDocument = null;
         if (_ocrDocument == null)
         {
            // User wish to save page while he/she doesn't have OCR Document yet, so we are going to create a temp document, 
            // add the page, save then destroy the document.
            tempOcrDocument = _ocrEngine.DocumentManager.CreateDocument(null, OcrCreateDocumentOptions.AutoDeleteFile);
            if (tempOcrDocument != null)
            {
               // Check if the page is recognized, otherwise, recognize
               if (!_ocrPage.IsRecognized)
               {
                  // Recognize it first
                  Dictionary<string, object> args = new Dictionary<string, object>();
                  args.Add("allPages", false);
                  bool allowProgress = _preferencesUseProgressBarsToolStripMenuItem.Checked;
                  using (OcrProgressDialog dlg = new OcrProgressDialog(allowProgress, "Recognize", new OcrProgressDialog.ProcessDelegate(DoRecognize), args))
                  {
                     if (dlg.ShowDialog(this) == DialogResult.Cancel)
                        return;
                  }
               }
            }
         }
         else
            tempOcrDocument = _ocrDocument;

         // Show the save dialog
         using (SaveDocumentDialog dlg = new SaveDocumentDialog(tempOcrDocument, initialFormat, settings.DocumentFileName, _viewDocument, _customFileName))
         {
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               if (_ocrDocument == null)
                  tempOcrDocument.Pages.Add(_ocrPage);

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


               if (!string.IsNullOrEmpty(_fileName))
               {
                  if (!_fileName.Equals(dlg.SelectedFileName))
                  {
                     _customFileName = true;
                     dlg.CustomFileName = true;
                     _outputDir = Path.GetDirectoryName(dlg.SelectedFileName);
                  }
               }

               _fileName = dlg.SelectedFileName;

               // Save the document
               SaveDocument(tempOcrDocument, dlg.SelectedFileName, dlg.SelectedFormat);
            }
         }

         if (tempOcrDocument != null && _ocrDocument == null)
            tempOcrDocument.Dispose();
      }

      private void SaveDocument(IOcrDocument ocrDocument, string documentFileName, DocumentFormat format)
      {
         // Save the document

         // Setup the arguments for the callback
         Dictionary<string, object> args = new Dictionary<string, object>();
         args.Add("OcrDocument", ocrDocument);
         args.Add("documentFileName", documentFileName);
         args.Add("format", format);

         // Call the process dialog
         try
         {
            bool allowProgress = _preferencesUseProgressBarsToolStripMenuItem.Checked;
            using (OcrProgressDialog dlg = new OcrProgressDialog(allowProgress, "Save", new OcrProgressDialog.ProcessDelegate(DoSave), args))
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
            IOcrDocument ocrDocument = args["OcrDocument"] as IOcrDocument;
            string documentFileName = args["documentFileName"] as string;
            DocumentFormat format = (DocumentFormat)args["format"];

            if (format == DocumentFormat.Ltd && File.Exists(documentFileName))
               File.Delete(documentFileName);

            // If we are not using a progress bar, update the description text
            if (callback == null)
               dlg.UpdateDescription("Saving the result document...");

            TimeSpan saveTimeSpan = new TimeSpan();

            // If it has not been canceled, save the document
            if (!dlg.IsCanceled)
            {
               DateTime beginTime = DateTime.Now;
               ocrDocument.Save(documentFileName, format, callback);
               saveTimeSpan = DateTime.Now - beginTime;
            }

            if (!dlg.IsCanceled)
            {
               UpdateTimingLabel(new string[] { "Save Document" }, new TimeSpan[] { saveTimeSpan });
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
                  _viewerControl.ZonesUpdated();
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

      private void ShowZoneProperties()
      {
         // Show the zone properties dialog
         // to let the user update the zones

         // Get the selected zone from the viewer control
         int selectedZoneIndex = _viewerControl.SelectedZoneIndex;

         // Make a copy of the page zones in case the user canceled the dialog
         List<OcrZone> zones = new List<OcrZone>();

         try
         {
            foreach (OcrZone zone in _ocrPage.Zones)
            {
               zones.Add(zone);
            }
            using (ZonePropertiesDialog dlg = new ZonePropertiesDialog(_ocrEngine, _ocrPage, _viewerControl, selectedZoneIndex))
            {
               if (dlg.ShowDialog(this) == DialogResult.OK)
               {
                  // We should mark the page as unrecognized since we updated its zones
                  _ocrPage.Unrecognize();

                  UpdateUIState();

                  RefreshPagesControl(false);
                  RepopulateOcrPageTextWindow();
               }
               else
               {
                  // Restore the old zones
                  _ocrPage.Zones.Clear();
                  foreach (OcrZone zone in zones)
                  {
                     _ocrPage.Zones.Add(zone);
                  }
               }

               // Let the viewer control know that the zones has been updated
               _viewerControl.ZonesUpdated();
            }

            CheckOmrOptions();
         }
         catch (Exception ex)
         {
            ShowError(ex);
         }
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
            Messager.ShowError(this, string.Format("OCR Error\n\nCode: {0}\n\n{1}", ocr.Code, ocr.Message));
            return;
         }

         OcrComponentMissingException ocrComponent = ex as OcrComponentMissingException;
         if (ocrComponent != null)
         {
            Messager.ShowError(this, string.Format("OCR Component Missing\n\n{0}\n\nUse 'Engine/Componets' from the menu to show the available components and instructions of how to install the additional components of this OCR engine.", ocrComponent.Message));
            return;
         }

         RasterException raster = ex as RasterException;
         if (raster != null)
         {
            Messager.ShowError(this, string.Format("LEADTOOLS Error\n\nCode: {0}\n\n{1}", raster.Code, raster.Message));
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
         if (_omrOptionsDismissed || _ocrDocument == null || GetOcrDocumentPagesCount() == 0)
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

      private void _fileSetPDFLoadResolutionToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (LoadResolutionDialog dlg = new LoadResolutionDialog(_rasterCodecs))
         {
            dlg.ShowDialog(this);
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
         bool isInMemory = IsOcrDocumentInMemory();
         IOcrPage ocrPage = null;
         if (isInMemory)
            ocrPage = _ocrDocument.Pages[_currentPageIndex];
         else
            ocrPage = _ocrPage;

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
                  GotoPage(_currentPageIndex);
               }
               break;
         }

         perspectiveDlg.Action -= new EventHandler<ActionEventArgs>(perspectiveDlg_Action);
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

      private void _pageSaveRecognizedDataAsXmlToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SaveRecognizedDataAsXml(true);
      }

      private void _documentSaveRecognizedDataAsXmlToolStripMenuItem_Click(object sender, EventArgs e)
      {
         SaveRecognizedDataAsXml(false);
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
         bool isInMemory = IsOcrDocumentInMemory();
         IOcrPage ocrPage = null;
         if (isInMemory)
            ocrPage = _ocrDocument.Pages[_currentPageIndex];
         else
            ocrPage = _ocrPage;

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
                  GotoPage(_currentPageIndex);
               }
               break;
         }

         unwarpDlg.Action -= new EventHandler<ActionEventArgs>(unwarpDlg_Action);
         _viewerControl.UpdateUIState();
         _pagesControl.UpdateUIState();
      }
   }

   public class ImageListItemData
   {
      public string FileName;
      public bool IsRecognized;

      public ImageListItemData(string fileName, bool isRecognized)
      {
         FileName = fileName;
         IsRecognized = isRecognized;
      }
   }
}
