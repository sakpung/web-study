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
using Leadtools.Twain;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Ocr;
using System.IO;
using Leadtools.Forms.Commands;
using System.Diagnostics;
using System.Threading;

using Leadtools.Drawing;
using Leadtools.Controls;
using System.Drawing.Drawing2D;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;
using Leadtools.Barcode;
using System.Linq;

namespace BusinessCardReaderDemo
{
   public partial class MainForm : Form
   {
      public MainForm()
      {
         InitializeComponent();
      }

      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         Boolean bLocked = RasterSupport.IsLocked(RasterSupportType.Forms);
         if (bLocked)
            MessageBox.Show("Forms support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

         Boolean bOCRLocked = RasterSupport.IsLocked(RasterSupportType.OcrLEAD) & RasterSupport.IsLocked(RasterSupportType.OcrOmniPage);
         if (bOCRLocked)
             MessageBox.Show("OCR support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

         if (bLocked | bOCRLocked)
            return;

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }

      private TwainSession _twainSession = null;
      private bool _inTwainAcquire;
      private RasterCodecs _rasterCodecs;
      private BarcodeEngine _barcodeEngine;
      private IOcrEngine _ocrEngine;
      private ImageViewerNoneInteractiveMode _noneInteractiveMode = null;
      private ImageViewerPanZoomInteractiveMode _panInteractiveMode = null;
      private ImageViewerZoomToInteractiveMode _zoomToInteractiveMode = null;
      private BusinessCardReader _bcrReader;
      private RasterImage _scannedImage = null;
      private string _caption;

      public ImageViewerNoneInteractiveMode NoneInteractiveMode
      {
         get
         {
            return _noneInteractiveMode;
         }
         set
         {
            _noneInteractiveMode = value;
         }
      }

      public ImageViewerPanZoomInteractiveMode PanInteractiveMode
      {
         get
         {
            return _panInteractiveMode;
         }
         set
         {
            _panInteractiveMode = value;
         }
      }

      private void Startup()
      {
         try
         {
            //Check if ocr engine was passed in. The recognition demos have the ability to launch this demo and it will pass
            //the ocr engine it is using. We will default to that engine
            if (!StartUpEngines())
            {
               Messager.ShowError(this, "One or more required engines did not start. The application will now close.");
               this.Close();
               return;
            }

            Messager.Caption = "LEADTOOLS Business Card Reader";
            _bcrReader = new BusinessCardReader(_ocrEngine, _barcodeEngine);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }

         closeToolStripMenuItem.Enabled = false;
         _noneInteractiveMode = new ImageViewerNoneInteractiveMode();
         _panInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left;
         _zoomToInteractiveMode = new ImageViewerZoomToInteractiveMode();

         rasterImageViewer1.InteractiveModes.BeginUpdate();
         rasterImageViewer1.InteractiveModes.Add(_noneInteractiveMode);
         rasterImageViewer1.InteractiveModes.Add(_panInteractiveMode);
         rasterImageViewer1.InteractiveModes.Add(_zoomToInteractiveMode);
         rasterImageViewer1.InteractiveModes.EndUpdate();

         this.rasterImageViewer1.PostRender += RasterImageViewer1_PostRender;

         // Load the default document
         string defaultDocumentFile = Path.Combine(DemosGlobal.ImagesFolder, "business_card_sample.jpg");

         if (File.Exists(defaultDocumentFile))
            OpenImage(defaultDocumentFile);
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            BeginInvoke(new MethodInvoker(Startup));
         }

         base.OnLoad(e);
      }

      private void StartupBarcode()
      {
         _barcodeEngine = new BarcodeEngine();         
      }

      private void StartupTwain()
      {
         try
         {
            if (TwainSession.IsAvailable(this.Handle))
            {
               _twainSession = new TwainSession();
               _twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
               _twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(twainSession_AcquirePage);
            }

            scanImageToolStripMenuItem.Enabled = _twainSession != null;
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
      }

      public bool StartUpEngines()
      {
         try
         {
            StartUpRasterCodecs();
            StartUpOcrEngine();
            StartupTwain();
            StartupBarcode();
            return true;
         }
         catch
         {
            return false;
         }
      }

      private void ShutDownEngines()
      {
         if (_ocrEngine != null && _ocrEngine.IsStarted)
         {
            _ocrEngine.Shutdown();
            _ocrEngine.Dispose();
         }

         if (_twainSession != null)
         {
            try
            {
               _twainSession.Shutdown();
            }
            catch
            { }
         }
      }

      private void StartUpRasterCodecs()
      {
         try
         {
            _rasterCodecs = new RasterCodecs();

            //To turn off the dithering method when converting colored images to 1-bit black and white image during the load
            //so the text in the image is not damaged.
            RasterDefaults.DitheringMethod = RasterDitheringMethod.None;
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
            throw;
         }
      }

      private void StartUpOcrEngine()
      {
         try
         {
            _ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, false);
            _ocrEngine.Startup(null, null, null, null);

            if (_ocrEngine.SettingManager.IsSettingNameSupported("Recognition.RecognitionModuleTradeoff"))
               _ocrEngine.SettingManager.SetEnumValue("Recognition.RecognitionModuleTradeoff", "Accurate");

            if (_ocrEngine.SettingManager.IsSettingNameSupported("Recognition.Threading.MaximumThreads"))
               _ocrEngine.SettingManager.SetIntegerValue("Recognition.Threading.MaximumThreads", 0);

            if (_ocrEngine.SettingManager.IsSettingNameSupported("Recognition.DetectColors"))
               _ocrEngine.SettingManager.SetBooleanValue("Recognition.DetectColors", false);

            if (_ocrEngine.SettingManager.IsSettingNameSupported("Recognition.Preprocess.MobileImagePreprocess"))
               _ocrEngine.SettingManager.SetBooleanValue("Recognition.Preprocess.MobileImagePreprocess", true);

            if (_ocrEngine.SettingManager.IsSettingNameSupported("Recognition.Fonts.RecognizeFontAttributes"))
               _ocrEngine.SettingManager.SetBooleanValue("Recognition.Fonts.RecognizeFontAttributes", false);

            this.Text = String.Format("{0}", this.Text);
            _caption = this.Text;
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
            throw;
         }
      }

      void twainSession_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         if (_scannedImage != null)
         {
            _scannedImage.Dispose();
            _scannedImage = null;
         }

         if(e.Image != null)
            _scannedImage = e.Image.Clone();
      }

      public void LoadImageScanner()
      {
         if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, _twainSession.SelectedSourceName()))
            return;

         bool showUI = false;
         _inTwainAcquire = true;

         //Set the scanner to scan a specified number of pages, scan at 1bpp B/W, and at 300DPI
         try
         {
            _twainSession.MaximumTransferCount = 1;
            _twainSession.Resolution = new SizeF(300, 300);
         }
         catch
         {
            MessageBox.Show("Unable to set scanner to 300DPI.");
            showUI = true;
         }

         try
         {
            if (showUI)
               _twainSession.Acquire(TwainUserInterfaceFlags.Modal);
            else
               _twainSession.Acquire(TwainUserInterfaceFlags.None);
         }
         catch (TwainException twEx)
         {
            MessageBox.Show(twEx.Message, "Scanner Error");
         }

         _inTwainAcquire = false;
      }

      void EnableControls(bool bEnable)
      {
         this.fileToolStripMenuItem.Enabled = bEnable;
         this.fileToolStripMenuItem.Enabled = bEnable;
         this.ControlBox = bEnable;
      }

      private void OpenImage(string path)
      {
         RasterImage image = _rasterCodecs.Load(path);
         this.Text = String.Format("{0} [{1}]", _caption, path);
         OpenImage(image);
      }

      private void OpenImage(RasterImage image)
      {
         Cursor = Cursors.WaitCursor;
         EnableControls(false);
         ProcessImage(image);
         _btnFit_Click(null, null);
         Cursor = Cursors.Arrow;
      }

      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            ImageFileLoader loader = new ImageFileLoader();
            loader.ShowLoadPagesDialog = true;
            loader.MultiSelect = false;
            loader.ShowPdfOptions = true;
            loader.ShowLoadPagesDialog = false;
            if (loader.Load(this, _rasterCodecs, true) > 0)
            {
               this.Text = String.Format("{0} [{1}]", _caption, loader.FileName);
               OpenImage(loader.Image);
            }
         }
         catch (Exception exp)
         {
            EnableControls(true);
            Messager.ShowError(this, exp);
         }
      }

      private void ProcessImage(RasterImage rasterImage)
      {
         if (rasterImage.BitsPerPixel == 1)
         {
            ColorResolutionCommand cmd = new ColorResolutionCommand();
            cmd.BitsPerPixel = 8;
            cmd.Run(rasterImage);
         }

         BCProcessStatus status = _bcrReader.Process(rasterImage);

         this.rasterImageViewer1.Image = rasterImage;

         if (status == BCProcessStatus.BlurDetected)
            Messager.ShowError(this, "Blur detected in image.");
         else if (status == BCProcessStatus.GlareDetected)
            Messager.ShowError(this, "Glare detected in image.");
         else if (status == BCProcessStatus.Failed)
            Messager.ShowError(this, "Failed to recognize image.");

          UpdateControls();
      }

      private void FillResults()
      {
         if (dGV_Results.Rows.Count > 0)
            dGV_Results.Rows.Clear();

         if (_bcrReader.Results != null)
         {
            foreach (var res in _bcrReader.Results)
            {
               DataGridViewRow row = new DataGridViewRow();
               row.CreateCells(dGV_Results, res.Key, res.Value.Value, res.Value.Confidence);
               row.Tag = res.Value;
               dGV_Results.Rows.Add(row);
            }
         }
      }

      private void ClearOldData(bool clearImage)
      {
         dGV_Results.Rows.Clear();
         if (clearImage)
         {
            this.rasterImageViewer1.Image = null;
         }
         this.rasterImageViewer1.Invalidate();
         closeToolStripMenuItem.Enabled = false;
         Application.DoEvents();
      }

      private void UpdateControls()
      {
         scanImageToolStripMenuItem.Enabled = _twainSession != null;
         EnableControls(true);
         dGV_Results.Rows.Clear();

         closeToolStripMenuItem.Enabled = true;

         if (_bcrReader.Results != null)
            FillResults();
      }

      private void _btnZoomNormal_Click(object sender, EventArgs e)
      {
         try
         {
            rasterImageViewer1.Zoom(ControlSizeMode.ActualSize, 1, rasterImageViewer1.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnFit_Click(object sender, EventArgs e)
      {
         try
         {
            rasterImageViewer1.Zoom(ControlSizeMode.FitAlways, 1, rasterImageViewer1.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnFitWidth_Click(object sender, EventArgs e)
      {
         try
         {
            rasterImageViewer1.Zoom(ControlSizeMode.FitWidth, 1, rasterImageViewer1.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnZoomIn_Click(object sender, EventArgs e)
      {
         try
         {
            double oldScaleFactor = rasterImageViewer1.ScaleFactor;
            rasterImageViewer1.Zoom(ControlSizeMode.None, oldScaleFactor + 0.1f, rasterImageViewer1.DefaultZoomOrigin);
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnZoomOut_Click(object sender, EventArgs e)
      {
         try
         {
            if (rasterImageViewer1.ScaleFactor > 0.1f)
            {
               double oldScaleFactor = rasterImageViewer1.ScaleFactor;
               rasterImageViewer1.Zoom(ControlSizeMode.None, oldScaleFactor - 0.1f, rasterImageViewer1.DefaultZoomOrigin);
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnZoomDrawTool_Click(object sender, EventArgs e)
      {
         ClearCheck(sender as ToolStripButton);
         DisableInteractiveModes();
         rasterImageViewer1.InteractiveModes.EnableById(_zoomToInteractiveMode.Id);
      }

      private void _btnUseDpi_Click(object sender, EventArgs e)
      {
         rasterImageViewer1.UseDpi = _btnUseDpi.Checked;

         if (_btnUseDpi.Checked)
            _btnUseDpi.ToolTipText = "Ignore Image DPI When Viewing";
         else
            _btnUseDpi.ToolTipText = "Use Image DPI When Viewing";
      }

      private void DisableInteractiveModes()
      {
         foreach (ImageViewerInteractiveMode mode in rasterImageViewer1.InteractiveModes)
         {
            mode.IsEnabled = false;
         }
      }

      private void _btnPanTool_Click(object sender, EventArgs e)
      {
         ClearCheck(sender as ToolStripButton);
         DisableInteractiveModes();
         rasterImageViewer1.InteractiveModes.EnableById(_panInteractiveMode.Id);
      }

      private void ClearCheck(ToolStripButton toolStripButton)
      {
         _btnPanTool.Checked = toolStripButton.Equals(_btnPanTool);
         _btnZoomDrawTool.Checked = toolStripButton.Equals(_btnZoomDrawTool);
      }

      private void closeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         this.Text = _caption;
         ClearOldData(true);
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      protected override void OnClosed(EventArgs e)
      {
         ClearOldData(true);
         ShutDownEngines();
         if (_ocrEngine != null && _ocrEngine.IsStarted)
         {
            _ocrEngine.Shutdown();
            _ocrEngine.Dispose();
         }
         base.OnClosed(e);
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Business Card Reader", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      string ToReadbleString(string str)
      {
         string str2 = str.Clone() as string;
         for (int i = 0; i < str2.Length; i++)
         {
            if (char.IsUpper(str2[i]) && i != 0)
            {
               str2 = str2.Insert(i, " ");
               i++;
            }
         }

         return str2;
      }

      private void scanImageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //select the desired scanner
         _inTwainAcquire = true;

         try
         {
            if (_twainSession != null)
            {
               if (_twainSession.SelectSource(null) != DialogResult.OK)
               {
                  _inTwainAcquire = false;
                  return;
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         
         _inTwainAcquire = false;

         Application.DoEvents();

         //Scan the first page
         LoadImageScanner();
         if (_scannedImage != null)
         {
            this.Text = String.Format("{0} [Scanned image]", _caption);
            OpenImage(_scannedImage);
         }
      }

      private void _btnRotateRight_Click(object sender, EventArgs e)
      {
         RasterImage image = this.rasterImageViewer1.Image;
         if (image != null)
         {
            Leadtools.ImageProcessing.RotateCommand cmd = new Leadtools.ImageProcessing.RotateCommand(9000, Leadtools.ImageProcessing.RotateCommandFlags.Resize, RasterColor.Black);
            cmd.Run(image);
            ClearOldData(false);
         }
      }

      private void _btnRotateLeft_Click(object sender, EventArgs e)
      {
         RasterImage image = this.rasterImageViewer1.Image;
         if (image != null)
         {
            Leadtools.ImageProcessing.RotateCommand cmd = new Leadtools.ImageProcessing.RotateCommand(-9000, Leadtools.ImageProcessing.RotateCommandFlags.Resize, RasterColor.Black);
            cmd.Run(image);
            ClearOldData(false);
         }
      }

      private void _btnRetry_Click(object sender, EventArgs e)
      {
         RasterImage image = this.rasterImageViewer1.Image;
         if (image != null)
         {
            ProcessImage(image.Clone());
         }
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (_inTwainAcquire)
            e.Cancel = true;
      }

      private LeadRect _selectedFieldBounds = LeadRect.Empty;
      private Brush _brush = new SolidBrush(Color.FromArgb(127, Color.Yellow));
      private void dGV_Results_SelectionChanged(object sender, EventArgs e)
      {
         _selectedFieldBounds = LeadRect.Empty;
         DataGridView dataGrid = sender as DataGridView;
         if(dataGrid.SelectedRows != null && dataGrid.SelectedRows.Count > 0)
         {
            _selectedFieldBounds = (dataGrid.SelectedRows[0].Tag as BCResult).Bounds;
         }

         this.rasterImageViewer1.Invalidate();
      }

      private void RasterImageViewer1_PostRender(object sender, ImageViewerRenderEventArgs e)
      {
         if (!_selectedFieldBounds.IsEmpty)
         {
            LeadRectD rect = rasterImageViewer1.ImageTransform.TransformRect(_selectedFieldBounds.ToLeadRectD());
            e.PaintEventArgs.Graphics.FillRectangle(_brush, new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height));
         }
      }
   }
}
