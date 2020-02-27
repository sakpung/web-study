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

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Controls;
using Leadtools.Ocr;
using Leadtools.Drawing;

namespace OcrZonesRubberBandDemo
{
   public partial class MainForm : Form
   {
      private IOcrEngine _ocrEngine;
      private IOcrPage _ocrPage;
      private RasterCodecs _codecs;
      private ImageViewerRubberBandInteractiveMode _rubberBand;
      private OcrEngineType _ocrEngineType;
      private LeadRect _currentHighlightRect;
      private string _openInitialPath = string.Empty;

      public MainForm()
      {
         InitializeComponent();

         InitInteractiveModes();
         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         Messager.Caption = "OCR Zones Rubberband Demo";

         _codecs = new RasterCodecs();

         // Use the new RasterizeDocumentOptions to default loading document files at 300 DPI
         _codecs.Options.RasterizeDocument.Load.XResolution = 300;
         _codecs.Options.RasterizeDocument.Load.YResolution = 300;
         _codecs.Options.Pdf.Load.EnableInterpolate = true;
         _codecs.Options.Load.AutoFixImageResolution = true;

         InitializeViewer(_viewer);
         InitializeZoomComboBox();

         UpdateMyControls();
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

         string engineType = settings.OcrEngineType;

         // Show the engine selection dialog
         using (OcrEngineSelectDialog dlg = new OcrEngineSelectDialog(Messager.Caption, engineType, true))
         {
            dlg.RasterCodecsInstance = _codecs;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _ocrEngine = dlg.OcrEngine;
               _ocrEngineType = dlg.SelectedOcrEngineType;

               // Add the selected engine name to the demo caption
               Text = Text + " [" + _ocrEngineType.ToString() + " Engine]";

               StartupEngine();

               //load default image
               LoadImage(true);
               string message = String.Format(@"To use this demo: {0} 1) Load an image with text on it. {0} 2) Draw a rectangle using the mouse around the portion of text you want to recognize.", Environment.NewLine);
               MessageBox.Show(message, "Instructions");

               UpdateMyControls();
            }
            else
            {
               // Close the demo
               Close();
            }
         }
      }

      private void InitInteractiveModes()
      {
         _viewer.InteractiveModes.BeginUpdate();
         _viewer.InteractiveModes.Clear();
         _rubberBand = new ImageViewerRubberBandInteractiveMode();
         _rubberBand.RubberBandCompleted += new EventHandler<ImageViewerRubberBandEventArgs>(_rubberBand_RubberBandCompleted);
         _rubberBand.MouseButtons = System.Windows.Forms.MouseButtons.Left;
         _rubberBand.WorkOnBounds = true;
         _rubberBand.IdleCursor = Cursors.Cross;
         _rubberBand.WorkingCursor = Cursors.Cross;
         _viewer.InteractiveModes.Add(_rubberBand);
         _viewer.InteractiveModes.EndUpdate();
      }

      void _rubberBand_RubberBandCompleted(object sender, ImageViewerRubberBandEventArgs e)
      {
         if (_ocrPage == null)
            return;

         try
         {
            _tsMainZoomComboBox.Enabled = false;

            using (WaitCursor cursor = new WaitCursor())
            {
               if (_viewer.Image != null)
               {
                  _currentHighlightRect = _viewer.ConvertRect(
                     null,
                     ImageViewerCoordinateType.Control,
                     ImageViewerCoordinateType.Image,
                     LeadRect.FromLTRB(e.Points[0].X, e.Points[0].Y, e.Points[1].X, e.Points[1].Y));

                  if (_currentHighlightRect.Width > 2 && _currentHighlightRect.Height > 2)
                  {
                     OcrZone zone = new OcrZone();
                     zone.Bounds = _currentHighlightRect;
                     zone.ZoneType = OcrZoneType.Text;
                     zone.CharacterFilters = OcrZoneCharacterFilters.None;

                     _ocrPage.Zones.Clear();
                     _ocrPage.Zones.Add(zone);

                     _ocrPage.Recognize(null);
                     _recognitionResults.Text = _ocrPage.GetText(0);

                     if (_recognitionResults.Text == "\n" || _recognitionResults.Text == "")
                        Messager.ShowInformation(this, "No text was recognized.");
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            _viewer.Invalidate();
            _tsMainZoomComboBox.Enabled = true;
         }
      }

      private void _miFileOpen_Click(object sender, EventArgs e)
      {
         LoadImage(false);
      }

      private void LoadImage(bool loadDefaultImage)
      {
         ImageFileLoader loader = new ImageFileLoader();
         bool bLoaded;

         loader.OpenDialogInitialPath = _openInitialPath;

         try
         {
            loader.LoadOnlyOnePage = true;

            if (loadDefaultImage)
            {
               if (_ocrEngineType == OcrEngineType.OmniPageArabic)
                  bLoaded = loader.Load(this, DemosGlobal.ImagesFolder + @"\ArabicSample.tif", _codecs, 1, -1);
               else
                  bLoaded = loader.Load(this, DemosGlobal.ImagesFolder + @"\ocr1.tif", _codecs, 1, -1);
            }
            else
               bLoaded = loader.Load(this, _codecs, true) > 0;

            if (bLoaded)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);

               RasterImage image = loader.Image;
               if (image.XResolution < 150)
                  image.XResolution = 150;

               if (image.YResolution < 150)
                  image.YResolution = 150;

               if (_ocrPage != null)
               {
                  _ocrPage.Dispose();
                  _ocrPage = null;
               }

               _viewer.Image = image;

               if (_ocrEngine.IsStarted)
                  _ocrPage = _ocrEngine.CreatePage(image, OcrImageSharingMode.None);

               _currentHighlightRect = LeadRect.Empty;
               _recognitionResults.Text = "";

               _tsMainZoomComboBox_SelectedIndexChanged(_tsMainZoomComboBox, new EventArgs());
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }
         finally
         {
            _viewer.Invalidate();
         }
      }

      private void _viewer_Paint(object sender, ImageViewerRenderEventArgs e)
      {
         Graphics g = e.PaintEventArgs.Graphics;
         try
         {
            if (_viewer.Image != null && _currentHighlightRect != LeadRect.Empty)
            {
               LeadRect imageRect = _viewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, _currentHighlightRect);
               Rectangle drawRect = Rectangle.FromLTRB(imageRect.Left, imageRect.Top, imageRect.Right, imageRect.Bottom);
               g.DrawRectangle(new Pen(Color.Orange), drawRect);
               g.FillRectangle(new SolidBrush(Color.FromArgb(70, Color.Yellow)), drawRect);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            Properties.Settings settings = new Properties.Settings();
            settings.OcrEngineType = _ocrEngineType.ToString();
            settings.Save();

            if (_ocrPage != null)
               _ocrPage.Dispose();

            if (_ocrEngine != null)
               _ocrEngine.Dispose();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void StartupEngine()
      {
         // Change the text box direction and font for more suitable Arabic font.
         if (_ocrEngineType == OcrEngineType.OmniPageArabic)
         {
            _recognitionResults.RightToLeft = RightToLeft.Yes;
            _recognitionResults.Font = new System.Drawing.Font("Times New Roman", 11);
         }
      }

      void UpdateMyControls()
      {
         bool bEnable = _ocrEngine != null && _ocrEngine.IsStarted;

         _miFileOpen.Enabled = bEnable;
         _miFileSetLoadRes.Enabled = bEnable;
         _tsMainZoomComboBox.Enabled = bEnable;
         _recognitionResults.Enabled = bEnable;
      }

      public void ShowError(Exception ex, IWin32Window owner, OcrEngineType engineType)
      {
         if (ex is OcrException)
         {
            OcrException oe = ex as OcrException;
            Messager.ShowError(owner, string.Format("LEADTOOLS Error\nCode: {0}\nMessage:{1}", oe.Code, ex.Message));
         }
         else if (ex is RasterException)
         {
            RasterException re = ex as RasterException;
            Messager.ShowError(owner, string.Format("OCR Error\nCode: {0}\nMessage:{1}", re.Code, ex.Message));
         }
         else
         {
            Messager.ShowError(owner, ex);
         }
      }

      private void InitializeViewer(ImageViewer viewer)
      {
         // Appearance
         viewer.BackColor = SystemColors.AppWorkspace;
         viewer.Dock = DockStyle.Fill;

         // Set Scale-to-Gray
         RasterPaintProperties properties = RasterPaintProperties.Default;
         properties.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic | RasterPaintDisplayModeFlags.ScaleToGray;
         properties.PaintEngine = RasterPaintEngine.GdiPlus;
         properties.UsePaintPalette = true;
         viewer.PaintProperties = properties;
      }

      private void InitializeZoomComboBox()
      {
         _tsMainZoomComboBox.Items.Add("Fit");
         _tsMainZoomComboBox.Items.Add("Page Width");

         int[] initialValues =
         {
            100, 25, 40, 50, 60, 75
         };

         foreach (int i in initialValues)
            _tsMainZoomComboBox.Items.Add(i + "%");

         for (int i = 125; i <= 1000; i += 25)
            _tsMainZoomComboBox.Items.Add(i + "%");

         _tsMainZoomComboBox.SelectedIndex = 0;
      }

      private void _tsMainZoomComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Zoom
         // Get the size mode and scale factor
         ControlSizeMode sizeMode = ControlSizeMode.None;
         double scaleFactor = _viewer.ScaleFactor;

         string selected = _tsMainZoomComboBox.SelectedItem.ToString();

         if (selected == "Fit")
         {
            sizeMode = ControlSizeMode.Fit;
            scaleFactor = 1.0;
         }
         else if (selected == "Page Width")
         {
            sizeMode = ControlSizeMode.FitWidth;
            scaleFactor = 1.0;
         }
         else if (selected == "100%")
         {
            scaleFactor = 1;
            sizeMode = ControlSizeMode.ActualSize;
         }
         else
         {
            int percentage = int.Parse(selected.Replace("%", ""));
            scaleFactor = (double)percentage / 100.0;
         }
         // Check if the size mode or scale factor has changed
         if (sizeMode != _viewer.SizeMode || scaleFactor != _viewer.ScaleFactor)
         {
            // yes, change it
            _viewer.BeginUpdate();
            _viewer.Zoom(sizeMode, scaleFactor, _viewer.DefaultZoomOrigin);
            _viewer.EndUpdate();
         }
      }

      private void _miFileSetLoadRes_Click(object sender, EventArgs e)
      {
         using (SetResolution setResDlg = new SetResolution())
         {
            setResDlg._xRes = _codecs.Options.RasterizeDocument.Load.XResolution;
            setResDlg._yRes = _codecs.Options.RasterizeDocument.Load.YResolution;
            if (setResDlg.ShowDialog(this) == DialogResult.OK)
            {
               _codecs.Options.RasterizeDocument.Load.XResolution = setResDlg._xRes;
               _codecs.Options.RasterizeDocument.Load.YResolution = setResDlg._yRes;
            }
         }
      }

      private void _miHelpAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Ocr Zones Rubberband", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _miFileExit_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _viewer_MouseUp(object sender, MouseEventArgs e)
      {
         _viewer.Invalidate();
      }
   }
}
