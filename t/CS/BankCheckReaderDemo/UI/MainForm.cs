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
using CSBankCheckReader.UI;
using System.Globalization;

namespace CSBankCheckReader
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

      private RasterCodecs rasterCodecs;
      private IOcrEngine ocrEngine;
      private ImageViewerNoneInteractiveMode _noneInteractiveMode = null;
      private ImageViewerPanZoomInteractiveMode _panInteractiveMode = null;
      private ImageViewerZoomToInteractiveMode _zoomToInteractiveMode = null;
      private BankCheckReader checkReader = null;
      private ProcessDialog processdlg;
      int selectedRowIndex = 0;
      LeadRect selectedRect = LeadRect.Empty;
      Brush brush = null;
      Pen pen = null;

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

            Messager.Caption = "LEADTOOLS Check Reader";

            checkReader = new BankCheckReader();
            checkReader.OcrEngine = ocrEngine;
#if LEADTOOLS_V20_OR_LATER
            checkReader.MicrFontType = BankCheckMicrFontType.Unknown;
#endif // #if LEADTOOLS_V20_OR_LATER
            brush = new SolidBrush(Color.FromArgb(127, Color.Yellow));
            pen = new Pen(brush);

         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
            return;
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

         dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

         // Load the default document
         string defaultDocumentFile = Path.Combine(DemosGlobal.ImagesFolder, "BankCheck.jpg");

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

      private void _menuItemComponents_Click(object sender, EventArgs e)
      {
         // Show the dialog to let the user see the OCR components installed on this system
         using (OcrEngineComponentsDialog dlg = new OcrEngineComponentsDialog(ocrEngine))
            dlg.ShowDialog(this);
      }

      private void _menuItemLanguages_Click(object sender, EventArgs e)
      {
         // Show the dialog to let the user change the current enabled languages
         using (EnableLanguagesDialog dlg = new EnableLanguagesDialog(ocrEngine))
            dlg.ShowDialog(this);
      }

      public bool StartUpEngines()
      {
         try
         {
            StartUpRasterCodecs();
            StartUpOcrEngine();
            return true;
         }
         catch
         {
            return false;
         }
      }

      private void ShutDownOcrEngine()
      {
         if (ocrEngine != null && ocrEngine.IsStarted)
         {
            Properties.Settings settings = new Properties.Settings();
            settings.OcrEngineType = ocrEngine.EngineType.ToString();
            settings.Save();

            ocrEngine.Shutdown();
            ocrEngine.Dispose();
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

            // Show the engine selection dialog
            using (OcrEngineSelectDialog dlg = new OcrEngineSelectDialog(Messager.Caption, engineType, false))
            {
               if (dlg.ShowDialog(this) == DialogResult.OK)
               {
                  ocrEngine = OcrEngineManager.CreateEngine(dlg.SelectedOcrEngineType, false);
                  ocrEngine.Startup(null, null, null, null);

                  if (ocrEngine.EngineType == OcrEngineType.LEAD)
                   {
                      if (ocrEngine.SettingManager.IsSettingNameSupported("Recognition.RecognitionModuleTradeoff"))
                      ocrEngine.SettingManager.SetEnumValue("Recognition.RecognitionModuleTradeoff", "Accurate");
                   }

                  this.Text = String.Format("{0} [{1} Engine]", this.Text, dlg.SelectedOcrEngineType.ToString());
               }
               else
                  throw new Exception("No engine selected.");
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
            throw;
         }
      }

      void EnableControls(bool bEnable)
      {
         this.fileToolStripMenuItem.Enabled = bEnable;
         this._menuItemEngine.Enabled = bEnable;
         this.fileToolStripMenuItem.Enabled = bEnable;
         this.ControlBox = bEnable;
      }

      void OpenImage(string fileName)
      {
         try
         {
            RasterImage image = rasterCodecs.Load(fileName);
            this.Text = "LEADTOOLS Check Reader " + fileName;
            EnableControls(false);
            ProcessImage(image);
         }
         catch (Exception exp)
         {
            EnableControls(true);
            Messager.ShowError(this, exp);
            if (processdlg != null)
               processdlg.Close();
         }
      }

      private void openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ImageFileLoader loader = new ImageFileLoader();
         loader.ShowLoadPagesDialog = true;
         loader.MultiSelect = false;
         loader.ShowPdfOptions = true;
         loader.ShowLoadPagesDialog = false;
         if (loader.Load(this, rasterCodecs, true) > 0)
         {
            OpenImage(loader.FileName);
         }
      }

      private void ProcessImage(RasterImage rasterImage)
      {
         ClearOldData(false);
         selectedRowIndex = -1;
         if (rasterImage.ViewPerspective != RasterViewPerspective.TopLeft)
         {
            Leadtools.ImageProcessing.ChangeViewPerspectiveCommand cmd = new Leadtools.ImageProcessing.ChangeViewPerspectiveCommand();
            cmd.InPlace = true;
            cmd.ViewPerspective = RasterViewPerspective.TopLeft;
            cmd.Run(rasterImage);
         }
         this.rasterImageViewer1.Image = rasterImage;
         processdlg = new ProcessDialog(checkReader);
         processdlg.Show();
         processdlg.ProcessFinished += new EventHandler(processdlg_ProcessFinished);
         new Thread(delegate()
         {
            try
            {
               checkReader.ProcessImage(rasterImage);
            }
            catch (Exception e)
            {
               checkReader.Cancel();
               this.Invoke(new Action(() => ThrowExp(e)));
               
            }
         }).Start();
         
      }

      private object ThrowExp(Exception ex)
      {
         MessageBox.Show(ex.Message);
         return null;
      }

      private void ClearOldData(bool clearTitle)
      {
         if(clearTitle)
         {
            this.Text = "LEADTOOLS Check Reader ";
            if (ocrEngine != null)
               this.Text = String.Format("{0} [{1} Engine]", this.Text, ocrEngine.ToString());
         }
         selectedRect = LeadRect.Empty;
         dataGridView1.Rows.Clear();
         this.imageViewerField.Image = null;
         this.rasterImageViewer1.Image = null;
         this.rasterImageViewer1.Invalidate();
         Application.DoEvents();
      }

      void processdlg_ProcessFinished(object sender, EventArgs e)
      {
         UpdateControls();
         processdlg = null;
      }

      private void UpdateControls()
      {
         EnableControls(true);
         dataGridView1.Rows.Clear();

         foreach (var item in checkReader.Results)
         {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView1, item.Key, item.Value.Text);
            row.Tag = item.Value;
            dataGridView1.Rows.Add(row);
         }
      }

      private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
      {
         selectedRowIndex = e.RowIndex;

         if (selectedRowIndex >= 0 && selectedRowIndex < dataGridView1.Rows.Count)
         {
            BankCheckField field = dataGridView1.Rows[selectedRowIndex].Tag as BankCheckField;
            selectedRect = field.Bounds;

            this.imageViewerField.Image = this.rasterImageViewer1.Image.Clone(selectedRect);
            rasterImageViewer1.Invalidate();

            LeadPoint centerPoint = new LeadPoint(selectedRect.X + selectedRect.Width / 2, selectedRect.Y + selectedRect.Height / 2);
            centerPoint = this.rasterImageViewer1.ConvertPoint(this.rasterImageViewer1.Items[0], ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, centerPoint);
            this.rasterImageViewer1.CenterAtPoint(centerPoint);
         }
      }

      private void CheckToolButtons(object sender)
      {
         _btnZoomDrawTool.Checked = false;
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
         DisableInteractiveModes();
         rasterImageViewer1.InteractiveModes.EnableById(_zoomToInteractiveMode.Id);
         CheckToolButtons(sender);
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
         DisableInteractiveModes();
         rasterImageViewer1.InteractiveModes.EnableById(_panInteractiveMode.Id);
         CheckToolButtons(sender);
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
         if (checkReader != null)
            checkReader.OcrEngine = null;

         ShutDownOcrEngine();
         base.OnClosed(e);
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Bank Check Reader", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _miFontType_Click(object sender, EventArgs e)
      {
         _miFontUnknown.Checked = _miFontE13B.Checked = _miFontCMC7.Checked = false;

         ToolStripMenuItem menuItem = (sender as ToolStripMenuItem);
         menuItem.Checked = true;

#if LEADTOOLS_V20_OR_LATER
         if (checkReader != null)
         {
            checkReader.MicrFontType = (BankCheckMicrFontType)Enum.Parse(typeof(BankCheckMicrFontType), 
               CultureInfo.CurrentCulture.TextInfo.ToTitleCase(menuItem.Text.ToLower()));
         }
#endif // #if LEADTOOLS_V20_OR_LATER

      }
   }
}
