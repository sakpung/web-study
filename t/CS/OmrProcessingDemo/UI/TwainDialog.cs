using Leadtools;
using Leadtools.Codecs;
using Leadtools.Twain;
using Leadtools.WinForms.CommonDialogs.File;
using OmrProcessingDemo.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmrProcessingDemo.UI
{
   public partial class TwainDialog : Form
   {
      private TwainSession twnSession;
      private RasterImageFormat format = RasterImageFormat.Unknown;
      public string SavedLocation { get { return txtSaveLocation.Text; } }

      public TwainDialog()
      {
         InitializeComponent();
         btnScan.Enabled = false;
         twnSession = new TwainSession();
      }

      private void TwainDialog_Load(object sender, EventArgs e)
      {
         try
         {
            twnSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
         }
         catch (Exception)
         {
            MessageBox.Show("An error occurred initializing TWAIN.");
            this.Close();
         }
      }

      private void TwainDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         twnSession.Shutdown();
      }

      private void btnScan_Click(object sender, EventArgs e)
      {
         //TwainOperation to = new TwainOperation(twnSession, txtSaveLocation.Text, format);
         //to.Start();

         Cursor current = this.Cursor;
         this.Cursor = Cursors.WaitCursor;

         RasterImage image = twnSession.AcquireToImage(TwainUserInterfaceFlags.Show | TwainUserInterfaceFlags.Modal);

         using (RasterCodecs codecs = MainForm.GetRasterCodecs())
         {
            codecs.Save(image, txtSaveLocation.Text, format, 0);
         }

         image.Dispose();

         this.Cursor = current;

         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      private void btnSelectSource_Click(object sender, EventArgs e)
      {
         if (twnSession.SelectSource(string.Empty) == DialogResult.OK)
         {
            txtSelectedSource.Text = twnSession.SelectedSourceName();
         }

         UpdateScanEnabled();
      }

      private void UpdateScanEnabled()
      {
         btnScan.Enabled = string.IsNullOrWhiteSpace(txtSaveLocation.Text) == false && string.IsNullOrWhiteSpace(txtSelectedSource.Text) == false && format != RasterImageFormat.Unknown;
      }

      private void btnChooseSaveLocation_Click(object sender, EventArgs e)
      {
         using (RasterCodecs codecs = MainForm.GetRasterCodecs())
         {
            RasterSaveDialog rsd = new RasterSaveDialog(codecs);
            rsd.FileFormatsList = new RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.Default);
            rsd.ShowFormatSubType = false;
            rsd.ShowBitsPerPixel = false;
            rsd.Title = "Save scan...";

            if (rsd.ShowDialog(this) == DialogResult.OK)
            {
               txtSaveLocation.Text = rsd.FileName;
               format = rsd.Format;
            }

            UpdateScanEnabled();
         }
      }
   }
}
