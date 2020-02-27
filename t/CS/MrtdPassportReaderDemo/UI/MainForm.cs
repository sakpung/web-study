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

namespace MrtdPassportReaderDemo
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

      private TwainSession twainSession = null;
      private bool inTwainAcquire;
      private RasterCodecs rasterCodecs;
      private IOcrEngine ocrEngine;
      private ImageViewerNoneInteractiveMode _noneInteractiveMode = null;
      private ImageViewerPanZoomInteractiveMode _panInteractiveMode = null;
      private ImageViewerZoomToInteractiveMode _zoomToInteractiveMode = null;
      private MRTDReader _reader;
      RasterImage scannedImage = null;
      bool _textEditMode = false;
      LeadRect selectedRect = LeadRect.Empty;
      Brush brush = null;
      Pen pen = null;
      InformationDlg infoDlg = new InformationDlg();

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
            string[] commandArgs = Environment.GetCommandLineArgs();
            if (commandArgs.Length == 2)
            {
               Properties.Settings settings = new Properties.Settings();
               settings.OcrEngineType = commandArgs[1];
               settings.Save();
            }

            if (!StartUpEngines())
            {
               Messager.ShowError(this, "One or more required engines did not start. The application will now close.");
               this.Close();
               return;
            }

            Messager.Caption = "LEADTOOLS Passport Reader";

            _reader = new MRTDReader();
            _reader.OcrEngine = ocrEngine;
            brush = new SolidBrush(Color.FromArgb(127, Color.Yellow));
            pen = new Pen(brush);

         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }

         _noneInteractiveMode = new ImageViewerNoneInteractiveMode();
         _panInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left;
         _zoomToInteractiveMode = new ImageViewerZoomToInteractiveMode();

         rasterImageViewer1.InteractiveModes.BeginUpdate();
         rasterImageViewer1.InteractiveModes.Add(_noneInteractiveMode);
         rasterImageViewer1.InteractiveModes.Add(_panInteractiveMode);
         rasterImageViewer1.InteractiveModes.Add(_zoomToInteractiveMode);
         rasterImageViewer1.PostRender += new EventHandler<ImageViewerRenderEventArgs>(rasterImageViewer1_PostRender);
         rasterImageViewer1.InteractiveModes.EndUpdate();
         // Load the default document
         string defaultDocumentFile = Path.Combine(DemosGlobal.ImagesFolder, "MRZ_SAMPLE.jpg");

         if (File.Exists(defaultDocumentFile))
            OpenImage(defaultDocumentFile);
      }

      void rasterImageViewer1_PostRender(object sender, ImageViewerRenderEventArgs e)
      {
         if (!selectedRect.IsEmpty)
         {
            LeadRectD rect = rasterImageViewer1.ImageTransform.TransformRect(selectedRect.ToLeadRectD());
            e.PaintEventArgs.Graphics.FillRectangle(brush, new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height));
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

      private void StartupTwain()
      {
         try
         {
            twainSession = new TwainSession();
            if (TwainSession.IsAvailable(this.Handle))
            {
               twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
               twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(twainSession_AcquirePage);
            }
         }
         catch (TwainException ex)
         {
            if (ex.Code == TwainExceptionCode.InvalidDll)
            {
               twainSession = null;
               Messager.ShowError(this, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org");
            }
            else
            {
               twainSession = null;
               Messager.ShowError(this, ex);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            twainSession = null;
         }
      }

      public bool StartUpEngines()
      {
         try
         {
            StartUpRasterCodecs();
            StartUpOcrEngine();
            StartupTwain();
            return true;
         }
         catch
         {
            return false;
         }
      }

      private void ShutDownEngines()
      {
         if (ocrEngine != null && ocrEngine.IsStarted)
         {
            Properties.Settings settings = new Properties.Settings();
            settings.OcrEngineType = ocrEngine.EngineType.ToString();
            settings.Save();

            ocrEngine.Shutdown();
            ocrEngine.Dispose();
         }

         if (twainSession != null)
         {
            try
            {
               twainSession.Shutdown();
            }
            catch
            { }
         }
      }

      private void StartUpRasterCodecs()
      {
         try
         {
            rasterCodecs = new RasterCodecs();

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
            Properties.Settings settings = new Properties.Settings();
            string engineType = settings.OcrEngineType;

            ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, false);
            ocrEngine.Startup(null, null, null, null);

            if (ocrEngine.SettingManager.IsSettingNameSupported("Recognition.RecognitionModuleTradeoff"))
                ocrEngine.SettingManager.SetEnumValue("Recognition.RecognitionModuleTradeoff", "Accurate");
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
            throw;
         }
      }

      void twainSession_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         if (scannedImage != null)
         {
            scannedImage.Dispose();
            scannedImage = null;
         }

         if(e.Image != null)
            scannedImage = e.Image.Clone();
      }

      public void LoadImageScanner()
      {
         if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, twainSession.SelectedSourceName()))
            return;

         bool showUI = false;
         inTwainAcquire = true;

         //Set the scanner to scan a specified number of pages, scan at 1bpp B/W, and at 300DPI
         try
         {
            twainSession.MaximumTransferCount = 1;
            twainSession.Resolution = new SizeF(300, 300);
         }
         catch
         {
            MessageBox.Show("Unable to set scanner to 300DPI.");
            showUI = true;
         }

         if (showUI)
            twainSession.Acquire(TwainUserInterfaceFlags.Modal);
         else
            twainSession.Acquire(TwainUserInterfaceFlags.None);

         inTwainAcquire = false;
      }

      void EnableControls(bool bEnable)
      {
         this.fileToolStripMenuItem.Enabled = bEnable;
         this.fileToolStripMenuItem.Enabled = bEnable;
         this.ControlBox = bEnable;
         this._btn_Edit.Enabled = bEnable;
      }


      private void OpenImage(string path)
      {
         RasterImage image = rasterCodecs.Load(path);
         OpenImage(image);
      }

      private void OpenImage(RasterImage image)
      {
         EnableControls(false);
         ProcessImage(image);
         _btnFit_Click(null, null);
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
            if (loader.Load(this, rasterCodecs, true) > 0)
            {
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
         ClearOldData(true);
         this.rasterImageViewer1.Image = rasterImage;
         _reader.ProcessImage(rasterImage);

         _tB_MRZCode.Visible = false;
         _tB_readonlyMRZCode.Visible = true;
         _btn_Edit.Text = "Edit";
         _textEditMode = false;

         UpdateControls();
      }

      private object ThrowExp(Exception ex)
      {
         MessageBox.Show(ex.Message);
         return null;
      }

      private void ClearOldData(bool clearImage)
      {
         selectedRect = LeadRect.Empty;
         dGV_Results.Rows.Clear();
         dGV_Errors.Rows.Clear();
         if (clearImage)
         {
            this.rasterImageViewer1.Image = null;
         }
         this.rasterImageViewer1.Invalidate();
         _tB_readonlyMRZCode.Text = "";
         _tB_MRZCode.Text = "";
         closeToolStripMenuItem.Enabled = false;
         Application.DoEvents();
      }

      private void UpdateControls()
      {
         scanImageToolStripMenuItem.Enabled = twainSession != null && TwainSession.IsAvailable(this.Handle);
         EnableControls(true);
         dGV_Results.Rows.Clear();
         dGV_Errors.Rows.Clear();

         _tB_readonlyMRZCode.Lines = _reader.Lines;
         if (rasterImageViewer1.Image != null)
            selectedRect = _reader.Bounds;
         else
            selectedRect = LeadRect.Empty;
         closeToolStripMenuItem.Enabled = true;
         foreach (var item in _reader.Results)
         {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dGV_Results, ToReadbleString(item.Key.ToString()), item.Value.ReadableValue, item.Value.MrzCharacters);
            row.Tag = item.Value;
            if (!item.Value.IsValid)
            {
               row.DefaultCellStyle.BackColor = Color.Red;
               DataGridViewRow errorRow = new DataGridViewRow();
               errorRow.CreateCells(dGV_Errors, ToReadbleString(item.Key.ToString()) + " Is Invalid");
               dGV_Errors.Rows.Add(errorRow);
            }
            dGV_Results.Rows.Add(row);
         }

         if (_reader.Errors != MRTDErrors.NoError)
         {
            foreach (var value in Enum.GetValues(typeof(MRTDErrors)))
            {
               if ((_reader.Errors & (MRTDErrors)value) == (MRTDErrors)value && (MRTDErrors)value!=MRTDErrors.NoError)
               {
                  DataGridViewRow row = new DataGridViewRow();
                  row.CreateCells(dGV_Errors, ToReadbleString(((MRTDErrors)value).ToString()));
                  row.Tag = ((MRTDErrors)value);
                  dGV_Errors.Rows.Add(row);
               }
            }
         }
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
         ClearOldData(true);
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         this.Close();
      }

      protected override void OnClosed(EventArgs e)
      {
         ClearOldData(true);
         if (_reader != null)
            _reader.OcrEngine = null;

         ShutDownEngines();
         if (ocrEngine != null && ocrEngine.IsStarted)
         {
            ocrEngine.Shutdown();
            ocrEngine.Dispose();
         }
         base.OnClosed(e);
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Machine Readable Travel Documents Reader", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _btn_Edit_Click(object sender, EventArgs e)
      {
         _textEditMode = !_textEditMode;

         if (_textEditMode)
         {
            _btn_Edit.Text = "Done Editing";
            _tB_MRZCode.Text = _tB_readonlyMRZCode.Text;
            _tB_MRZCode.Visible = true;
            _tB_readonlyMRZCode.Visible = false;
            _tB_MRZCode.Focus();
         }
         else
         {
            _btn_Edit.Text = "Edit";
            _tB_readonlyMRZCode.Text = _tB_MRZCode.Text;
            _tB_MRZCode.Visible = false;
            _tB_readonlyMRZCode.Visible = true;

            if (_tB_readonlyMRZCode.Text.Length > 0)
            {
               _reader.ProcessText(_tB_readonlyMRZCode.Lines);
               UpdateControls();
            }
         }
      }

      private void _tB_readonlyMRZCode_TextChanged(object sender, EventArgs e)
      {
         Size size = TextRenderer.MeasureText(_tB_readonlyMRZCode.Text + " ", _tB_readonlyMRZCode.Font);
         _tB_readonlyMRZCode.Width = size.Width;
         _tB_readonlyMRZCode.Height = size.Height * 3 / 2;

         _tB_readonlyMRZCode.Location = new Point(_tB_MRZCode.Width / 2 - _tB_readonlyMRZCode.Width / 2, _tB_MRZCode.Bounds.Height / 2 - _tB_readonlyMRZCode.Height / 2);
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         if (infoDlg.ShouldShow())
         {
            infoDlg.ShowDialog();
         }
      }

      private void informationToolStripMenuItem_Click(object sender, EventArgs e)
      {
         infoDlg.ShowDialog();
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

      private void _tB_readonlyMRZCode_Resize(object sender, EventArgs e)
      {
         _tB_readonlyMRZCode_TextChanged(sender, null);
      }

      private void enableImprovingResultsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         enableImprovingResultsToolStripMenuItem.Checked = !enableImprovingResultsToolStripMenuItem.Checked;
         _reader.ImproveResults = enableImprovingResultsToolStripMenuItem.Checked;
         if (rasterImageViewer1.Image != null)
         {
            this.OpenImage(rasterImageViewer1.Image.Clone());
         }
      }

      private void scanImageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         //select the desired scanner
         inTwainAcquire = true;

         try
         {
            if (twainSession != null)
            {
               if (twainSession.SelectSource(null) != DialogResult.OK)
               {
                  inTwainAcquire = false;
                  return;
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         
         inTwainAcquire = false;

         Application.DoEvents();
         
         //Scan the first page
         LoadImageScanner();
                 
         if(scannedImage != null)
            OpenImage(scannedImage);
      }

      private void dGV_Results_CellClick(object sender, DataGridViewCellEventArgs e)
      {
         int selectedRowIndex = e.RowIndex;

         if (selectedRowIndex >= 0 && selectedRowIndex < dGV_Results.Rows.Count)
         {
            MRTDDataElement element = dGV_Results.Rows[selectedRowIndex].Tag as MRTDDataElement;
            if (element.LineIndex >= 0)
            {
               int linePadding = 0;
               for (int i = 0; i < element.LineIndex; i++)
                  linePadding += _tB_readonlyMRZCode.Lines[i].Length + 2; //(+2) for /r/n
               _tB_readonlyMRZCode.SelectionStart = element.BeginIndex + linePadding;
               _tB_readonlyMRZCode.SelectionLength = element.Length;
               _tB_readonlyMRZCode.Focus();
            }
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
         if (inTwainAcquire)
            e.Cancel = true;
      }
   }
}
