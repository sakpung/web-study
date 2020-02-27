using Leadtools;
using Leadtools.Barcode;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AAMVAWriteDemo
{
   public partial class WriteBarcodeForm : Form
   {
      private ImageViewer _viewer;
      private RasterCodecs _codecs;
      private byte[] _aamvaData;
      private BarcodeEngine _barcodeEngine;
      private PDF417BarcodeWriteOptions _writeOptions;

      public WriteBarcodeForm(byte[] data)
      {
         InitializeComponent();
         _aamvaData = data;
      }

      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         if (_codecs != null)
            _codecs.Dispose();

         if (_viewer.Items.Count > 0 && _viewer.Items[0].HasFloater &&
            _viewer.Items[0].Floater != null && !_viewer.Items[0].Floater.IsDisposed)
         {
            _viewer.Items[0].Floater.Dispose();
            _viewer.Items[0].Floater = null;
         }

         if (_viewer.Image != null && !_viewer.Image.IsDisposed)
            _viewer.Image.Dispose();

         base.OnFormClosing(e);
      }

      private void WriteBarcodeForm_Load(object sender, System.EventArgs e)
      {
         // initialize the _viewer object
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();

         // initialize the codecs object.
         _codecs = new RasterCodecs();

         try
         {
            string imagePath = Path.Combine(DemosGlobal.ImagesFolder, "license_sample_rear_blank.png");
            _viewer.Image = _codecs.Load(imagePath);
         }
         catch
         {
            _viewer.Image = RasterImage.Create(1100, 700, 24, 150, RasterColor.White);
         }

         _barcodeEngine = new BarcodeEngine();
         _writeOptions = (PDF417BarcodeWriteOptions)_barcodeEngine.Writer.GetDefaultOptions(BarcodeSymbology.PDF417);

         //Refer to AAMVA CDS 2016 Section D.3 thru D.11.2

         //Must range from 0.0066 to 0.015 inches
         _writeOptions.XModule = 15; //0.015
         //Must >= 3
         _writeOptions.XModuleAspectRatio = 3;
         //Error level must be at least 3, 5 is recommended
         _writeOptions.ECCLevel = PDF417BarcodeECCLevel.Level5;
         //Default WidthAspectRatio is 2:1. 4:1 looks similar to ID barcodes in the wild
         _writeOptions.SymbolWidthAspectRatio = 4;
         //Default quiet zone for PDF417 is 2 * XModule


         _viewer.BeginUpdate();
         WriteBarcodeInteractiveMode writeBarcodeInteractiveMode = new WriteBarcodeInteractiveMode(_barcodeEngine, _aamvaData, _writeOptions);
         writeBarcodeInteractiveMode.IsEnabled = true;
         ImageViewerPanZoomInteractiveMode panZoomInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         _viewer.InteractiveModes.Add(writeBarcodeInteractiveMode);
         _viewer.InteractiveModes.Add(panZoomInteractiveMode);
         _viewer.EndUpdate();

         
         UpdateMyControls();
      }

      /// <summary>
      /// Update the UI depending on the program state
      /// </summary>
      private void UpdateMyControls()
      {
         if (_viewer.Image != null)
         {
            _miFileSave.Enabled = true;
         }
         else
         {
            _miFileSave.Enabled = false;
         }
      }

      /// <summary>
      /// Load a new image
      /// </summary>
      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         try
         {
            // load the image
            ImageFileLoader loader = new ImageFileLoader();

            loader.ShowLoadPagesDialog = true;
            if (loader.Load(this, _codecs, true) > 0)
            {
               // update the caption
               Text = string.Format("{0} - {1}", loader.FileName, Messager.Caption);

               // set the new image in the viewer.
               _viewer.Image = loader.Image;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateMyControls();
         }
      }

      /// <summary>
      /// save the original image
      /// </summary>
      private void _miFileSave_Click(object sender, System.EventArgs e)
      {
         try
         {
            ImageFileSaver saver = new ImageFileSaver();
            if (saver.Save(this, _codecs, _viewer.Image))
            {
               // we need to load this new image
               RasterImage temp = _codecs.Load(saver.FileName);

               // update the caption
               Text = string.Format("{0} - {1}", saver.FileName, Messager.Caption);
               _viewer.Image = temp;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateMyControls();
         }
      }

      public void UpdateOptions(PDF417BarcodeWriteOptions options)
      {
         foreach(ImageViewerInteractiveMode mode in _viewer.InteractiveModes)
         {
            if(mode is WriteBarcodeInteractiveMode)
            {
               WriteBarcodeInteractiveMode writeMode = (WriteBarcodeInteractiveMode)mode;
               writeMode.WriteOptions = options;
               _writeOptions = options;
            }
         }
      }

      /// <summary>
      /// Shutdown
      /// </summary>
      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void EnableAndVisibleMenu(MenuItem menu, bool value)
      {
         menu.Enabled = value;
         menu.Visible = value;
      }

      private void _miWriteOptions_Click(object sender, EventArgs e)
      {
         WriteBarcodeOptionsDialog dlg = new WriteBarcodeOptionsDialog(this, _writeOptions);
         dlg.StartPosition = this.StartPosition;
         dlg.ShowDialog();
      }
   }
}
