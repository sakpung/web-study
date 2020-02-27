using Leadtools.Codecs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Forms.Processing.Omr;
using System.IO;
using Leadtools.Controls;

namespace OmrProcessingDemo.UI
{
   public partial class TemplatePanel : WizardStep
   {
      private ImageViewer iv;

      private RasterImage templateImage;
      private RasterImage fileImage;

      private ITemplateForm templateEditorEngine;
      private ITemplateForm loadedEditorEngine;

      public ITemplateForm LoadedEditor { get { return rdbtnTemplate.Checked ? templateEditorEngine : loadedEditorEngine; } }

      public RasterImage LoadedImage { get { return iv.Image; } }

      public TemplatePanel()
      {
         InitializeComponent();

         iv = new ImageViewer();
         iv.Dock = DockStyle.Fill;
         iv.AutoDisposeImages = false;
         iv.ItemChanged += Riv_ItemChanged;
         pnlThumbnail.Controls.Add(iv);
      }

      public TemplatePanel(RasterImage defaultImage, ITemplateForm currentEngine) : this()
      {
         templateImage = defaultImage;
         templateEditorEngine = currentEngine;

         if (defaultImage != null)
         {
            rdbtnTemplate.Checked = true;
         }
         else
         {
            rdBtnFile.Checked = true;
            rdbtnTemplate.Enabled = false;
         }
      }

      private void rdBtnToggled(object sender, EventArgs e)
      {
         try
         {
            if (rdBtnFile.Checked)
            {
               iv.Image = fileImage;
            }
            if (rdbtnTemplate.Checked)
            {
               iv.Image = templateImage;
            }
         }
         catch (Exception)
         {
            iv.Image = null;
         }

         txtFilePath.Enabled = rdBtnFile.Checked;
         btnBrowse.Enabled = rdBtnFile.Checked;

         OnCanProceed();
      }

      private void btnTemplateBrowse_Click(object sender, EventArgs e)
      {
         string input = "";
         if (MainForm.ChooseTemplate(out input))
         {
            LoadTemplate(input);
            fileImage = loadedEditorEngine.Pages[0].Image;
            iv.Image = fileImage;
            txtFilePath.Text = input;

            OnCanProceed();
         }
      }

      protected override void OnCanProceed()
      {
         OnCanProceed(LoadedEditor != null && iv.Image != null);
      }

      private void LoadTemplate(string selectedPath)
      {
         loadedEditorEngine = MainForm.GetOmrEngine().CreateTemplateForm();

         loadedEditorEngine.Load(new FileStream(selectedPath, FileMode.Open, FileAccess.Read));
      }
      private void Riv_ItemChanged(object sender, ImageViewerItemChangedEventArgs e)
      {
         if (e.Reason == ImageViewerItemChangedReason.Image)
         {
            iv.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty);
         }
      }

   }
}