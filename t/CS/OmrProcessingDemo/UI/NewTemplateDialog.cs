using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Forms.Processing.Omr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmrProcessingDemo
{
   public partial class NewTemplateDialog : Form
   {
      #region Members
      private ImageViewer iv;
      private RasterImage loadedImage;
      private RasterImage twainImage;
      #endregion
      #region Properties
      public RasterImage LoadedImage { get { return iv.Image; } }
      public string TemplateName { get { return txtTemplateName.Text; } }
      public string FileName { get { return txtFilePath.Text; } }
      #endregion
      #region Initialization
      public NewTemplateDialog()
      {
         InitializeComponent();

         iv = new ImageViewer();
         iv.Dock = DockStyle.Fill;
         iv.AutoDisposeImages = false;
         iv.ItemChanged += Riv_ItemChanged;
         pnlThumbnail.Controls.Add(iv);

         rdBtnFile.Checked = true;

         txtTemplateName.Text = "New Template";
         txtTemplateName.Focus();
         txtTemplateName.SelectAll();
      }

      public NewTemplateDialog(int currentPageCount) : this()
      {
         this.Text = "Add new page";

         this.lblDescription.Text = "Page Name:";

         txtTemplateName.Text = string.Format("Page {0}", currentPageCount + 1);
         txtTemplateName.Focus();
         txtTemplateName.SelectAll();

         txtTemplateName.Visible = false;
         lblDescription.Text = "Choose a single page or multipage file to append new pages to this template.";
      }

      public NewTemplateDialog(string v) : this()
      {
         txtFilePath.Text = v;
      }
      #endregion

      #region Events
      private void rdBtnToggled(object sender, EventArgs e)
      {
         grpLoad.Enabled = rdBtnFile.Checked;
         grpTwain.Enabled = rdbtnTwain.Checked;

         rdBtnFile.Checked = !rdbtnTwain.Checked;

         if (rdbtnTwain.Checked)
         {
            iv.Image = twainImage;
         }
         else if (rdBtnFile.Checked)
         {
            iv.Image = loadedImage;
         }
      }

      private void btnBrowse_Click(object sender, EventArgs e)
      {
         string filename;

         bool loaded = MainForm.LoadRasterImage(out loadedImage, out filename, true);

         if (loaded)
         {
            txtFilePath.Text = filename;
            iv.Image = loadedImage;

            lblPageIndex.Visible = true;

            AdvanceToPage(0);
         }
      }

      private void AdvanceToPage(int dir)
      {
         iv.Image.Page += dir;

         lblPageIndex.Text = string.Format("Page {0} of {1}", iv.Image.Page, iv.Image.PageCount);
         btnNextPage.Enabled = iv.Image.Page < iv.Image.PageCount;
         btnPreviousPage.Enabled = iv.Image.Page > 1;
      }

      private void Riv_ItemChanged(object sender, ImageViewerItemChangedEventArgs e)
      {
         if (e.Reason == ImageViewerItemChangedReason.Image)
         {
            iv.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty);
         }

         CheckToProceed();
      }

      private void CheckToProceed()
      {
         BtnOK.Enabled = string.IsNullOrWhiteSpace(txtTemplateName.Text) == false && iv.Image != null;
      }
      #endregion

      private void GetNewImageDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (rdbtnTwain.Checked)
         {
            txtFilePath.Text = "";
         }
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

      private void txtTemplateName_TextChanged(object sender, EventArgs e)
      {
         CheckToProceed();
      }

      private void btnNextPage_Click(object sender, EventArgs e)
      {
         AdvanceToPage(1);
      }

      private void btnPreviousPage_Click(object sender, EventArgs e)
      {
         AdvanceToPage(-1);
      }
   }
}
