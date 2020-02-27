using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Controls;
using Leadtools.Codecs;

namespace OmrProcessingDemo.UI
{
   public partial class KeyPanel : WizardStep
   {
      private ImageViewer iv;
      private RasterImage fileImage;
      private RasterImage twainImage;

      public bool IsKeySelected { get { return chkUseKey.Checked; } }

      public RasterImage AnswerImage { get { return iv.Image; } }
      public string AnswerImagePath { get { return rdBtnFile.Checked ? txtFilePath.Text : txtScanPath.Text; } }
      public int PassingGrade { get { return (int)nudPassingGrade.Value; } }


      private int requiredPageCount;

      public KeyPanel(bool isAnswerPresent, int requiredPages)
      {
         InitializeComponent();

         iv = new ImageViewer();
         iv.Dock = DockStyle.Fill;
         iv.AutoDisposeImages = false;
         iv.ItemChanged += Riv_ItemChanged;
         pnlThumbnail.Controls.Add(iv);

         rdBtnFile.Checked = true;

         this.requiredPageCount = requiredPages;

         this.Title = "Choose an Answer Key";
      }

      private void Riv_ItemChanged(object sender, ImageViewerItemChangedEventArgs e)
      {
         if (e.Reason == ImageViewerItemChangedReason.Image)
         {
            iv.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty);
         }

         OnCanProceed();
      }

      protected override void OnCanProceed()
      {
         OnCanProceed(chkUseKey.Checked == false || (chkUseKey.Checked && iv.Image != null));
      }

      private void rdBtnToggled(object sender, EventArgs e)
      {
         try
         {
            if (rdBtnFile.Checked)
            {
               iv.Image = fileImage;
            }
            if (rdbtnTwain.Checked)
            {
               iv.Image = twainImage;
            }
         }
         catch (Exception)
         {
            iv.Image = null;
         }

         txtFilePath.Enabled = rdBtnFile.Checked;
         btnBrowse.Enabled = rdBtnFile.Checked;

         btnScan.Enabled = rdbtnTwain.Checked;
         txtScanPath.Enabled = rdbtnTwain.Checked;
      }

      private void btnImageFileBrowse_Click(object sender, EventArgs e)
      {
         RasterImage image;
         string path;

         bool loaded = MainForm.LoadRasterImage(out image, out path, true);

         if (loaded)
         {
            if (image.PageCount != requiredPageCount)
            {
               MessageBox.Show(string.Format("This file contains {0} pages, but the template requires {1}.", image.PageCount, requiredPageCount));
               return;
            }

            txtFilePath.Text = path;
            fileImage = image;
            iv.Image = image;
         }
      }

      private void chkUseKey_CheckedChanged(object sender, EventArgs e)
      {
         OnCanProceed();

         rdBtnFile.Enabled = chkUseKey.Checked;
         txtFilePath.Enabled = rdBtnFile.Checked && chkUseKey.Checked;
         btnBrowse.Enabled = rdBtnFile.Checked && chkUseKey.Checked;

         rdbtnTwain.Enabled = chkUseKey.Checked;
         btnScan.Enabled = rdbtnTwain.Checked && chkUseKey.Checked;

         nudPassingGrade.Enabled = chkUseKey.Checked;
         lblPassingGrade.Enabled = chkUseKey.Checked;
      }


      private void btnScan_Click(object sender, EventArgs e)
      {
         string path = null;

         if (MainForm.GetFromTwain(out path))
         {
            twainImage = MainForm.LoadImage(path, false);

            if (twainImage != null)
            {
               iv.Image = twainImage;
               txtScanPath.Text = path;
            }
         }
      }
   }
}
