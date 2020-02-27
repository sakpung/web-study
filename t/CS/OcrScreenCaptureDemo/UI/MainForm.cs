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
using System.Runtime.InteropServices;

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.ImageProcessing;
using Leadtools.Ocr;
using Leadtools.Document.Writer;
using Leadtools.ScreenCapture;
using Leadtools.Drawing;

using OcrDemo;
using Leadtools.Document.Viewer;
using Leadtools.Document;
using Leadtools.Caching;
using Leadtools.Document.Converter;

namespace OcrScreenCaptureDemo
{
   public partial class MainForm : Form
   {
      #region UI Code
      private ImageViewer _imageViewer = null; // The LEADTOOLS ImageViewer control to see the Image
      private DocumentViewer _svgViewer = null; //The LEADTOOLS ImageViewer Control to view as SVG
      public MainForm()
      {
         InitializeComponent();

         // Setup the caption for this demo
         Messager.Caption = "C# OCR Screen Capture Demo";
         this.Text = Messager.Caption;

         #region LEADTOOLS ImageViewer
         // Create the LEADTOOLS ImageViewer
         _imageViewer = new ImageViewer();

         // Add it to the Form
         _splitContainer.Panel1.Controls.Add(_imageViewer);
         // Set the display properties
         _imageViewer.BeginUpdate();
         _imageViewer.Dock = DockStyle.Fill;
         _imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         _imageViewer.Cursor = System.Windows.Forms.Cursors.Default;
         _imageViewer.ViewHorizontalAlignment = ControlAlignment.Center;
         _imageViewer.ViewVerticalAlignment = ControlAlignment.Center;
         _imageViewer.ItemHorizontalAlignment = ControlAlignment.Center;
         _imageViewer.ItemVerticalAlignment = ControlAlignment.Center;
         // Set the layout
         _imageViewer.ViewLayout = new ImageViewerSingleViewLayout();
         _imageViewer.EndUpdate();
         // Hook up the Mouse Events
         _imageViewer.MouseDown += new MouseEventHandler(imageViewer_MouseDown);
         _imageViewer.MouseMove += new MouseEventHandler(imageViewer_MouseMove);
         _imageViewer.MouseUp += new MouseEventHandler(imageViewer_MouseUp);
         _imageViewer.MouseLeave += new EventHandler(imageViewer_MouseLeave);
         _imageViewer.KeyDown += new KeyEventHandler(imageViewer_KeyDown);
         _imageViewer.LostFocus += new EventHandler(imageViewer_LostFocus);
         #endregion LEADTOOLS ImageViewer

         #region LEADTOOLS DocumentViewer
         var createOptions = new DocumentViewerCreateOptions()
         {
            ViewContainer = _splitContainer.Panel2,
            ThumbnailsContainer = null,
            BookmarksContainer = null,
            UseAnnotations = false
         };

         _svgViewer = DocumentViewerFactory.CreateDocumentViewer(createOptions);
         _svgViewer.View.PreferredItemType = DocumentViewerItemType.Svg;
         _svgViewer.Text.AutoGetText = true;
         _svgViewer.View.ImageViewer.KeyDown += ImageViewer_KeyDown;
         _svgViewer.Commands.Run(DocumentViewerCommands.InteractiveSelectText);

         _svgViewer.View.ImageViewer.InteractiveModes.BeginUpdate();
         ImageViewerPanZoomInteractiveMode panZoom = new ImageViewerPanZoomInteractiveMode()
         {
            MouseButtons = MouseButtons.Middle
         };
         _svgViewer.View.ImageViewer.InteractiveModes.Add(panZoom);
         _svgViewer.View.ImageViewer.InteractiveModes.EndUpdate();


         ContextMenu viewerContextMenu = new ContextMenu();
         MenuItem selectAllMenuItem = new MenuItem("Select All");
         selectAllMenuItem.Click += (s, e) => { _svgViewer.Commands.Run(DocumentViewerCommands.TextSelectAll); };
         viewerContextMenu.MenuItems.Add(selectAllMenuItem);

         MenuItem copyText = new MenuItem("Copy");
         copyText.Click += (s, e) => { _svgViewer.Commands.Run(DocumentViewerCommands.TextCopy); };
         viewerContextMenu.MenuItems.Add(copyText);
         _svgViewer.View.ImageViewer.ContextMenu = viewerContextMenu;
         _svgViewer.View.ImageViewer.MouseDoubleClick += ImageViewer_MouseDoubleClick;
         #endregion LEADTOOLS DocumentViewer
      }


      #region Main Form Events

      private void ImageViewer_MouseDoubleClick(object sender, MouseEventArgs e)
      {
         bool fitWidth = _svgViewer.View.ImageViewer.SizeMode == ControlSizeMode.FitWidth;
         if (fitWidth)
            _svgViewer.Commands.Run(DocumentViewerCommands.ViewFitPage);
         else
            _svgViewer.Commands.Run(DocumentViewerCommands.ViewFitWidth);
      }

      private void ImageViewer_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.Control && e.KeyCode == Keys.A)
            _svgViewer.Commands.Run(DocumentViewerCommands.TextSelectAll);
         else if (e.Control && e.KeyCode == Keys.C)
            _svgViewer.Commands.Run(DocumentViewerCommands.TextCopy);
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         this.MinimumSize = new Size(545, 455);

         IntPtr sysMenuHandle = GetSystemMenu(this.Handle, false);
         InsertMenu(sysMenuHandle, -1, MF_BYPOSITION | MF_SEPARATOR, 0, string.Empty);
         InsertMenu(sysMenuHandle, -1, MF_BYPOSITION, IDM_ABOUT, "About...");

         try
         {
            // Set up the Screen Capture
            ScreenCaptureEngine.Startup();
            _screenCaptureEngine = new ScreenCaptureEngine();
            _screenCaptureEngine.CaptureInformation += new EventHandler<ScreenCaptureInformationEventArgs>(captureCallback);

            // Set up the OCR
            _ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, false);

            // Start up the OCR engine
#if LT_CLICKONCE
            _ocrEngine.Startup(null, null, null, Application.StartupPath + @"\OCR Engine");
#else
            _ocrEngine.Startup(null, null, null, null);
#endif // #if LT_CLICKONCE

            // Load the OCR settings
            LoadOcrSettings(_ocrEngine);

            _ocrEngine.SettingManager.SetBooleanValue("Recognition.ModifyProcessingImage", false);
            _ocrEngine.SettingManager.SetEnumValue("Recognition.RecognitionModuleTradeoff", 0);
            _ocrEngine.SettingManager.SetBooleanValue("Recognition.DetectColors", false);
            _ocrEngine.SettingManager.SetEnumValue("Recognition.Fonts.DetectFontStyles", "Bold,Italic,Underline,SansSerif,Serif,Proportional,Superscript,Subscript");
            _ocrEngine.SettingManager.SetBooleanValue("Recognition.ShareOriginalImage", false);//this demo does not support the sharing mode

            // Load application settings
            Properties.Settings mySettings = new Properties.Settings();
            foreach (ToolStripMenuItem ts in _tsCaptureBtn.DropDownItems)
            {
               selectedScreenCapture = mySettings.CaptureArea;
               if (ts.Name == selectedScreenCapture)
                  ts.Checked = true;
            }
            _tsUseHotkey.Checked = mySettings.UseHotKey;
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         StopDrawing();

         //// Clean up
         DeleteObject(_highlightWin32Pen);
         DeleteObject(_redWin32Pen);

         ScreenCaptureEngine.Shutdown();

         if (_ocrEngine != null)
            _ocrEngine.Shutdown();

         if (_svgViewer != null && _svgViewer.HasDocument)
         {
            string temp = _svgViewer.Document.GetDocumentFileName();
            if (File.Exists(temp))
               File.Delete(temp);
         }

         Properties.Settings mySettings = new Properties.Settings();
         mySettings.UseHotKey = _tsUseHotkey.Checked;
         mySettings.CaptureArea = selectedScreenCapture;
         mySettings.Save();
      }
      #endregion Main Form Events

      #region Button Events
      bool showMessagebox = false;
      private void buttonScreenCapture_Click(object sender, EventArgs e)
      {
         if (_tsUseHotkey.Checked && !showMessagebox)
         {
            MyMessageBox myMessageBox = new MyMessageBox("Hotkey Capture", "Press F11 to start capture");
            myMessageBox.Show(this);
            showMessagebox = myMessageBox.Checked;
         }

         EnableUI(false);
         System.Threading.Thread.Sleep(500);
         try
         {
            // Capture an area from the screen
            RasterImage image = DoCapture(_tsUseHotkey.Checked);

            this.BringToFront();

            ColorResolutionCommand colorRes = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, 24,
               RasterByteOrder.Bgr, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.Fixed, null);
            colorRes.Run(image);

            EnableUI(true);
            if (image != null)
            {
               ClearDocument();
               ClearImage();

               // Store the new image
               _imageViewer.Image = image;

               // Set the image to the PictureBox
               UpdateViewer();

               // OCR the image and get back an RTF file
               string document = DoOcr(_imageViewer.Image);

               if (!string.IsNullOrEmpty(document))
               {
                  var options = new LoadDocumentOptions()
                  {
                     UseCache = false
                  };
                  // Load the RTF file
                  var doc = DocumentFactory.LoadFromFile(document, options);
                  doc.AutoDisposeDocuments = true;
                  _svgViewer.SetDocument(doc);
                  _svgViewer.Commands.Run(DocumentViewerCommands.ViewFitPage);
               }
            }
         }
         catch (Exception ex)
         {
            RasterException rasex = ex as RasterException;
            if (rasex != null)
            {
               if (rasex.Code != RasterExceptionCode.UserAbort)
                  Messager.ShowError(this, ex);
            }
            else
               Messager.ShowError(this, ex);
         }
         finally
         {
            EnableUI(true);
         }
      }

      private void buttonCopyImage_Click(object sender, EventArgs e)
      {
         CopyImage();
      }

      private void buttonCopyText_Click(object sender, EventArgs e)
      {
         CopyText();
      }

      private void buttonSaveText_Click(object sender, EventArgs e)
      {
         SaveText();
      }

      private void buttonSaveImage_Click(object sender, EventArgs e)
      {
         SaveImage();
      }

      private void buttonOcrOptions_Click(object sender, EventArgs e)
      {
         EngineSettingsDialog dlg = new EngineSettingsDialog(_ocrEngine);
         dlg.ShowDialog();
         _ocrEngine.SettingManager.SetBooleanValue("Recognition.ShareOriginalImage", false);//this demo does not support the sharing mode
         SaveOcrSettings(_ocrEngine);

         if (_imageViewer.Image != null)
         {
            var result = MessageBox.Show("Do you want to retry the OCR with the updated settings?", "Retry?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
               try
               {
                  // OCR the image and get back an RTF file
                  string document = DoOcr(_imageViewer.Image);
                  if (!string.IsNullOrEmpty(document))
                  {
                     var options = new LoadDocumentOptions()
                     {
                        UseCache = false
                     };
                     // Load the RTF file
                     var doc = DocumentFactory.LoadFromFile(document, options);
                     doc.AutoDisposeDocuments = true;
                     _svgViewer.SetDocument(doc);
                     _svgViewer.Commands.Run(DocumentViewerCommands.ViewFitPage);
                  }
               }
               catch (Exception ex)
               {
                  RasterException rasex = ex as RasterException;
                  Messager.ShowError(this, ex);
               }
               finally
               {
                  EnableUI(true);
               }
            }
         }
      }

      private void _tsCaptureBtnItem_Clicked(object sender, EventArgs e)
      {
         ToolStripMenuItem ts = sender as ToolStripMenuItem;

         //uncheck all items in collection
         foreach (ToolStripMenuItem items in _tsCaptureBtn.DropDownItems)
            items.Checked = false;

         //check the selected option
         ts.Checked = true;

         selectedScreenCapture = ts.Name;
      }

      private void _tsDrawingChoice_Click(object sender, EventArgs e)
      {
         ToolStripMenuItem ts = sender as ToolStripMenuItem;

         foreach (ToolStripMenuItem items in _tsDrawingChoice.DropDownItems)
            items.Checked = false;

         ts.Checked = true;
      }
      #endregion Button Events

      #region LEADTOOLS ImageViewer Mouse Events
      private void imageViewer_MouseDown(object sender, MouseEventArgs e)
      {
         StartDrawing(e.Location);
      }

      private void imageViewer_MouseMove(object sender, MouseEventArgs e)
      {
         if (_imageViewer.Image != null)
            _imageViewer.Cursor = highlighterToolStripMenuItem.Checked ? _highlighterCursor : _penCursor;

         Point newPoint = e.Location;
         Draw(newPoint, highlighterToolStripMenuItem.Checked);
         _oldPoint = newPoint;
      }

      private void imageViewer_MouseUp(object sender, MouseEventArgs e)
      {
         StopDrawing();
      }

      private void imageViewer_MouseLeave(object sender, EventArgs e)
      {
         StopDrawing();
      }

      private void imageViewer_LostFocus(object sender, EventArgs e)
      {
         StopDrawing();
      }

      void imageViewer_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.C && e.Control)
         {
            CopyImage();
         }

         if (e.KeyCode == Keys.Z && e.Control)
         {
            RasterImage image = Undo();
            if (image != null)
            {
               _imageViewer.Image = image;
            }
         }
      }

      #endregion LEADTOOLS ImageViewer Mouse Events

      #region Splitter Events
      private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
      {
      }
      #endregion Splitter Events

      #region UI Tools
      private void EnableUI(bool enable)
      {
         _tsCaptureBtn.Enabled = enable;
         _tsCopyTextBtn.Enabled = enable;
         _tsCopyImageBtn.Enabled = enable;
         _tsSaveTextBtn.Enabled = enable;
         _tsSaveImageBtn.Enabled = enable;
         _tsOCROptionsBtn.Enabled = enable;

         _tsUseHotkey.Enabled = enable;

         if (!enable)
            this.SendToBack();
         else
            this.BringToFront();
      }

      private void UpdateViewer()
      {
         _imageViewer.Refresh();
      }

      private void ClearDocument()
      {
         if (_svgViewer.HasDocument)
         {
            string filename = _svgViewer.Document.GetDocumentFileName();
            if (File.Exists(filename))
               File.Delete(filename);

            _svgViewer.SetDocument(null);
            _svgViewer.View.Invalidate();
         }
      }

      private void ClearImage()
      {
         // Dispose the old viewer image
         if (_imageViewer.Image != null)
            _imageViewer.Image.Dispose();
         _imageViewer.Image = null;

         // Cleanup the undo list
         while (_undo.Count > 0)
         {
            _undo[_undo.Count - 1].Dispose();
            _undo.RemoveAt(_undo.Count - 1);
         }
      }
      #endregion UI Tools

      #endregion UI Code

      #region Settings Code
      private string GetSettingsFile()
      {
         string name = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
         return string.Format("{0}.Ocr.settings", name);
      }

      private void SaveOcrSettings(IOcrEngine ocrEngine)
      {
         if (ocrEngine != null)
         {
            try
            {
               ocrEngine.SettingManager.Save(System.IO.Path.Combine(Application.StartupPath, GetSettingsFile()));
            }
            catch
            {
            }
         }
      }

      private void LoadOcrSettings(IOcrEngine ocrEngine)
      {
         if (ocrEngine != null)
         {
            try
            {
               ocrEngine.SettingManager.Load(System.IO.Path.Combine(Application.StartupPath, GetSettingsFile()));
            }
            catch
            {
            }
         }
      }
      #endregion Settings Code

      #region Screen Capture Code
      private ScreenCaptureEngine _screenCaptureEngine = null; // The LEADTOOLS Screen Capture Engine
      // Callback for Screen Capture
      private void captureCallback(object sender, ScreenCaptureInformationEventArgs e)
      {
         e.Cancel = false;
      }

      string selectedScreenCapture;
      // Use LEADTOOLS to capture an area of the screen
      private RasterImage DoCapture(bool useHotkey)
      {
         // Use default options for the capture process
         ScreenCaptureOptions screenCaptureOptions = _screenCaptureEngine.CaptureOptions;
         // Use default options for the area to capture
         ScreenCaptureAreaOptions screenCaptureAreaOptions = ScreenCaptureEngine.DefaultCaptureAreaOptions;

         if (useHotkey)
         {
            screenCaptureOptions.Hotkey = Keys.F11;
         }
         else
            screenCaptureOptions.Hotkey = Keys.None;

         _screenCaptureEngine.CaptureOptions = screenCaptureOptions;

         switch (selectedScreenCapture)
         {
            case "rectangularArea":
               screenCaptureAreaOptions.AreaType = ScreenCaptureAreaType.Rectangle;
               return _screenCaptureEngine.CaptureArea(screenCaptureAreaOptions, null);
            case "freehandArea":
               screenCaptureAreaOptions.AreaType = ScreenCaptureAreaType.Freehand;
               return _screenCaptureEngine.CaptureArea(screenCaptureAreaOptions, null);
            case "windowCapture":
               ScreenCaptureObjectOptions objectOptions = ScreenCaptureEngine.DefaultCaptureObjectOptions;
               return _screenCaptureEngine.CaptureSelectedObject(objectOptions, null);
            case "fullscreenCapture":
               return _screenCaptureEngine.CaptureFullScreen(null);
            default:
               return _screenCaptureEngine.CaptureArea(screenCaptureAreaOptions, null);
         }

      }
      #endregion Screen Capture Code

      #region OCR Code
      private IOcrEngine _ocrEngine = null; // The LEADTOOLS OCR Engine

      // Use LEADTOOLS to OCR the image and get back text (RTF)
      private string DoOcr(RasterImage image)
      {
         this.Cursor = Cursors.WaitCursor;
         string temp = System.IO.Path.GetTempFileName(); // temp file for the RTF

         if (image == null)
            return string.Empty;

         // Use Double pass method to get highest confidence page from OCR
         IOcrPage highestConfidencePage = DoublePass(image);

         // Create a document and add the page
         using (var document = _ocrEngine.DocumentManager.CreateDocument(null, OcrCreateDocumentOptions.AutoDeleteFile))
         {
            // Add the page
            document.Pages.Add(highestConfidencePage);
            try
            {
               // Save as svg
               document.Save(temp, DocumentFormat.Pdf, null);
            }
            catch (Exception ex)
            {
               if (File.Exists(temp))
                  File.Delete(temp);
               throw ex;
            }
         }

         this.Cursor = Cursors.Default;
         return temp;
      }

      private IOcrPage DoublePass(RasterImage image)
      {
         //first pass with default settings
         IOcrPage page = _ocrEngine.CreatePage(image.Clone(), OcrImageSharingMode.AutoDispose);
         page.Recognize(null);

         //second pass with mobile image processing set to true
         _ocrEngine.SettingManager.SetBooleanValue("Recognition.Preprocess.MobileImagePreprocess", true);
         IOcrPage mobilePage = _ocrEngine.CreatePage(image.Clone(), OcrImageSharingMode.AutoDispose);
         mobilePage.Recognize(null);

         //get the confidence of both pages
         PageResults firstPassResults = GetPageConfidence(page);
         PageResults secondPassResults = GetPageConfidence(mobilePage);

         double confidenceDif = firstPassResults.Confidence - secondPassResults.Confidence;

         IOcrPage highestConfidence;
         PageResults pageResultsHighest;

         if (confidenceDif > 2)
         {
            highestConfidence = page;
            pageResultsHighest = firstPassResults;
         }
         else
         {
            highestConfidence = mobilePage;
            pageResultsHighest = secondPassResults;
         }

         if (pageResultsHighest.TotalWords < 20)
         {
            IOcrPage thirdPass = highestConfidence.Copy();
            thirdPass.Unrecognize();
            OcrZone singleZone = new OcrZone()
            {
               Bounds = new LeadRect(0, 0, image.Width, image.Height)
            };
            thirdPass.Zones.Add(singleZone);
            thirdPass.Recognize(null);
            PageResults thirdResults = GetPageConfidence(thirdPass);
            double confidencetDifThird = thirdResults.Confidence - pageResultsHighest.Confidence;
            if (confidenceDif > 5)
            {
               highestConfidence = thirdPass;
               pageResultsHighest = thirdResults;
            }
         }

         return highestConfidence;
      }

      private class PageResults
      {
         public double PageConfidence { get; set; }
         public double Confidence { get; set; }
         public int CertainWords { get; set; }
         public int TotalWords { get; set; }

         public PageResults(double pageConfidence, int certainwords, int totalWords)
         {
            PageConfidence = pageConfidence;
            CertainWords = certainwords;
            TotalWords = totalWords;
            Confidence = 0.25 * PageConfidence + 0.75 * certainwords * 100 / totalWords;
         }
      }

      private PageResults GetPageConfidence(IOcrPage ocrPage)
      {
         IOcrPageCharacters pageCharacters = ocrPage.GetRecognizedCharacters();
         double pageConfidence = 0;
         int certainWords = 0;
         int totalWords = 0;
         int totalZoneWords = 0;
         int textZoneCount = 0;

         for (int i = 0; i < ocrPage.Zones.Count; i++)
         {
            IOcrZoneCharacters zoneCharacters = pageCharacters.FindZoneCharacters(i);
            if (zoneCharacters.Count == 0)
               continue;

            textZoneCount++;
            double zoneConfidence = 0;
            int characterCount = 0;
            double wordConfidence = 0;
            totalZoneWords = 0;
            bool newWord = true;
            foreach (var ocrCharacter in zoneCharacters)
            {
               if (newWord)
               {
                  wordConfidence = 0;
                  characterCount = 0;
                  wordConfidence = 1000;
               }
               if (ocrCharacter.Confidence < wordConfidence)
                  wordConfidence = ocrCharacter.Confidence;
               characterCount++;

               if ((ocrCharacter.Position & OcrCharacterPosition.EndOfWord) == OcrCharacterPosition.EndOfWord || (ocrCharacter.Position & OcrCharacterPosition.EndOfLine) == OcrCharacterPosition.EndOfLine)
               {
                  if (characterCount > 3)
                  {
                     if (ocrCharacter.WordIsCertain)
                        certainWords++;
                     totalWords++;
                     totalZoneWords++;
                     zoneConfidence += wordConfidence;
                  }

                  newWord = true;
               }
               else
                  newWord = false;
            }

            if (totalZoneWords > 0)
            {
               zoneConfidence /= totalZoneWords;
               pageConfidence += zoneConfidence;
            }
            else
            {
               zoneConfidence = 0;
               pageConfidence += zoneConfidence;
            }
         }
         if (textZoneCount > 0)
            pageConfidence /= textZoneCount;
         else
            pageConfidence = 0;

         PageResults results = new PageResults(pageConfidence, certainWords, totalWords);
         return results;
      }

      #endregion OCR Code

      #region Clipboard Code
      // Copy the image to the clipboard
      private void CopyImage()
      {
         if (_imageViewer.Image != null)
         {
            try
            {
               Leadtools.Controls.RasterClipboard.Copy(this.Handle, _imageViewer.Image, Leadtools.Controls.RasterClipboardCopyFlags.Dib | Leadtools.Controls.RasterClipboardCopyFlags.Bitmap | Leadtools.Controls.RasterClipboardCopyFlags.Empty);
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      // Copy the text (RTF) to the clipboard
      private void CopyText()
      {
         if (_svgViewer.HasDocument)
         {
            _svgViewer.Commands.Run(DocumentViewerCommands.TextSelectAll);
            _svgViewer.Commands.Run(DocumentViewerCommands.TextCopy);
            _svgViewer.Commands.Run(DocumentViewerCommands.TextClearSelection);
         }
      }
      #endregion Clipboard Code

      #region Save Code
      private void SaveImage()
      {
         if (_imageViewer.Image != null)
         {
            try
            {
               SaveFileDialog dlg = new SaveFileDialog();
               dlg.Filter = "PNG | *.png";
               if (dlg.ShowDialog() == DialogResult.OK)
               {
                  using (RasterCodecs codecs = new RasterCodecs())
                  {
                     codecs.Save(_imageViewer.Image, dlg.FileName, RasterImageFormat.Png, 0);
                  }
               }
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void SaveText()
      {
         if (_imageViewer.HasImage)
         {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text File (.rtf)|*.rtf|Text (.txt)|*.txt";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               string ext = Path.GetExtension(dlg.FileName);
               DocumentFormat outputFormat = DocumentFormat.Text;
               switch (ext)
               {
                  case ".txt":
                     outputFormat = DocumentFormat.Text;
                     break;
                  case ".rtf":
                     outputFormat = DocumentFormat.Rtf;
                     break;
               }
               using (IOcrDocument document = _ocrEngine.DocumentManager.CreateDocument())
               {
                  document.Pages.AddPage(_imageViewer.Image, null);
                  document.Pages.Recognize(null);
                  RtfDocumentOptions rtfOptions = _ocrEngine.DocumentWriterInstance.GetOptions(DocumentFormat.Rtf) as RtfDocumentOptions;
                  if (rtfOptions != null)
                  {
                     rtfOptions.DropObjects = DocumentDropObjects.None;
                     rtfOptions.TextMode = DocumentTextMode.Framed;
                     _ocrEngine.DocumentWriterInstance.SetOptions(DocumentFormat.Rtf, rtfOptions);
                  }
                  document.Save(dlg.FileName, outputFormat, null);
               }
            }
         }
      }

      #endregion

      #region Drawing Code
      #region dllImport
      [DllImport("gdi32.dll")]
      static extern bool LineTo(IntPtr hdc, int nXEnd, int nYEnd);
      [DllImport("gdi32.dll")]
      static extern IntPtr CreatePen(int fnPenStyle, int nWidth, uint crColor);
      [DllImport("gdi32.dll")]
      static extern bool MoveToEx(IntPtr hdc, int X, int Y, IntPtr lpPoint);
      [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
      public static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);
      [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
      [return: MarshalAs(UnmanagedType.Bool)]
      public static extern bool DeleteObject([In] IntPtr hObject);
      [DllImport("gdi32.dll")]
      static extern int SetROP2(IntPtr hdc, int fnDrawMode);
      #endregion dllImport
      private bool _drawing = false;
      private Point _oldPoint = Point.Empty;
      private Cursor _highlighterCursor = new Cursor(new MemoryStream(global::OcrScreenCaptureDemo.Properties.Resources.highlight));
      private Cursor _penCursor = new Cursor(new MemoryStream(global::OcrScreenCaptureDemo.Properties.Resources.pen));
      private IntPtr imageHDC = IntPtr.Zero;
      private IntPtr _highlightWin32Pen = CreatePen(0, 10, (uint)0x8000FFFF); //yellow win32 pen
      private IntPtr _redWin32Pen = CreatePen(0, 2, (uint)0x80000FF); //red win32 pen

      // Translate Point From Control to RasterImage
      private Point TranslatePoint(ImageViewer viewer, RasterImage image, Point point)
      {
         if (image != null && viewer != null)
         {
            LeadPoint leadPoint = new LeadPoint(point.X, point.Y);
            leadPoint = viewer.ConvertPoint(viewer.Items[0], ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, leadPoint);
            point.X = leadPoint.X;
            point.Y = leadPoint.Y;
         }
         return point;
      }

      // Start the drawing process
      private void StartDrawing(Point point)
      {
         if (_drawing)
            return;

         if (_imageViewer.Image == null)
            return;

         AddUndoItem(_imageViewer.Image);

         _oldPoint = point;
         _drawing = true;
      }

      // Draw on the viewer control and the image
      private void Draw(Point point, bool useHighlighter)
      {
         if (!_drawing)
            return;

         IntPtr pen = useHighlighter ? _highlightWin32Pen : _redWin32Pen;
         int mixMode = useHighlighter ? 9 : 13;

         Point point1 = TranslatePoint(_imageViewer, _imageViewer.Image, _oldPoint);
         Point point2 = TranslatePoint(_imageViewer, _imageViewer.Image, point);

         imageHDC = RasterImagePainter.CreateLeadDC(_imageViewer.Image);
         SetROP2(imageHDC, mixMode);
         DeleteObject(SelectObject(imageHDC, pen));
         MoveToEx(imageHDC, point1.X, point1.Y, IntPtr.Zero);
         LineTo(imageHDC, point2.X, point2.Y);
         RasterImagePainter.DeleteLeadDC(imageHDC);
      }

      // Stop the drawing process
      private void StopDrawing()
      {
         if (!_drawing)
            return;

         _drawing = false;

         UpdateViewer();
      }
      #endregion Drawing Code

      #region Undo Code
      private List<RasterImage> _undo = new List<RasterImage>();

      // Add an item to the undo list
      private void AddUndoItem(RasterImage image)
      {
         if (image != null)
         {
            _undo.Add(image.Clone()); // add a copy of the image
         }
      }

      // Remove the last undo item from the list and return it
      private RasterImage Undo()
      {
         RasterImage image = null;
         if (_undo.Count > 0)
         {
            int index = _undo.Count - 1;
            image = _undo[index];
            _undo.RemoveAt(index);
         }
         return image;
      }

      #endregion Undo Code

      #region System Menu Code
      [DllImport("user32.dll")]
      private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
      [DllImport("user32.dll")]
      private static extern bool InsertMenu(IntPtr hMenu,
          Int32 wPosition, Int32 wFlags, Int32 wIDNewItem,
          string lpNewItem);

      public const Int32 WM_SYSCOMMAND = 0x112;
      public const Int32 MF_SEPARATOR = 0x800;
      public const Int32 MF_BYPOSITION = 0x400;
      public const Int32 MF_STRING = 0x0;
      public const Int32 IDM_ABOUT = 1000;

      protected override void WndProc(ref Message m)
      {
         if (m.Msg == WM_SYSCOMMAND)
         {
            switch (m.WParam.ToInt32())
            {
               case IDM_ABOUT:
                  using (AboutDialog aboutDialog = new AboutDialog("OCR Screen Capture", ProgrammingInterface.CS))
                     aboutDialog.ShowDialog(this);
                  return;
               default:
                  break;
            }
         }
         base.WndProc(ref m);
      }
      #endregion System Menu Code

      #region My Custom Message Box
      public class MyMessageBox : Form
      {
         #region Private Data
         private System.Windows.Forms.Label _label;
         private System.Windows.Forms.Button _button;
         private System.Windows.Forms.CheckBox _checkBox;
         private Size _size = new Size(250, 100);
         private Size _margin = new Size(10, 20);
         private string _title;
         private string _message;
         #endregion Private Data

         #region Public Properties
         public string Title
         {
            get { return _title; }
            set { _title = value; }
         }

         public string Message
         {
            get { return _message; }
            set { _message = value; }
         }

         public bool Checked
         {
            get { return _checkBox.Checked; }
         }
         #endregion Public Properties

         #region Initialization
         public MyMessageBox()
         {
            InitializeComponent();
         }

         public MyMessageBox(string title, string message)
         {
            this.Title = title;
            this.Message = message;
            InitializeComponent();
         }

         private void InitializeComponent()
         {
            this._label = new System.Windows.Forms.Label();
            this._button = new System.Windows.Forms.Button();
            this._checkBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _label
            // 
            this._label.Location = new Point(this._margin);
            this._label.Size = new System.Drawing.Size(_size.Width - this._label.Location.X * 2, 30);
            this._label.Name = "_textBox";
            this._label.Text = this._message;
            this._label.TextAlign = ContentAlignment.TopCenter;
            // 
            // _button
            // 
            this._button.Size = new System.Drawing.Size(75, 23);
            this._button.Location = new System.Drawing.Point(this._size.Width - this._margin.Width - this._button.Size.Width, this._size.Height - this._margin.Height - this._button.Size.Height);
            this._button.Name = "_button";
            this._button.TabIndex = 0;
            this._button.Text = "OK";
            this._button.UseVisualStyleBackColor = true;
            this._button.Click += new EventHandler(button_Click);
            // 
            // _checkBox
            // 
            this._checkBox.AutoSize = true;
            this._checkBox.Location = new System.Drawing.Point(this._margin.Width, this._button.Location.Y);
            this._checkBox.Name = "_checkBox";
            this._checkBox.Size = new System.Drawing.Size(80, 17);
            this._checkBox.TabIndex = 1;
            this._checkBox.Text = "Don't show this again";
            this._checkBox.UseVisualStyleBackColor = true;
            this._checkBox.Checked = false;
            // 
            // MyMessageBox
            // 
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ClientSize = this._size;
            this.Controls.Add(this._button);
            this.Controls.Add(this._label);
            this.Controls.Add(this._checkBox);
            this._checkBox.BringToFront();
            this.Name = "MyMessageBox";
            this.Text = this._title;
            this.ResumeLayout(false);
            this.PerformLayout();
            this.Load += (s, e) =>
            {
               if (this.Owner != null)
               {
                  this.Location = new Point(this.Owner.Location.X + (this.Owner.Width / 2) - (this.Width / 2), this.Owner.Location.Y + (this.Owner.Height / 2) - (this.Height / 2));
               }
            };
         }
         #endregion Initialization

         #region Event Handlers
         void button_Click(object sender, EventArgs e)
         {
            this.Close();
         }
         #endregion Event Handlers

         #region Overrides
         new public void Show()
         {
            ShowDialog();
         }
         new public void Show(IWin32Window owner)
         {
            ShowDialog(owner);
         }
         #endregion Overrides
      }
      #endregion My Custom Message Box
   }
}
