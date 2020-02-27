using Leadtools.Codecs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OmrProcessingDemo.UI
{
   public partial class InputPanel : WizardStep
   {
      private int requiredPageCount;

      public List<string> SelectedInputs { get { return new List<string>(chkFiles.CheckedItems.Cast<string>()); } }

      public string SelectedFilePath { get { return txtSavePath.Text; } }
      public bool DoSaveWorkspace { get { return chkSaveWorkspace.Checked; } }

      public InputPanel(int requiredPages)
      {
         InitializeComponent();

         this.Title = "Choose forms to process";
         this.requiredPageCount = requiredPages;
      }

      protected override void OnCanProceed()
      {
         Action p = new Action(delegate ()
         {
            OnCanProceed(chkFiles.CheckedItems.Count > 0 && (chkSaveWorkspace.Checked == false || (chkSaveWorkspace.Checked && string.IsNullOrWhiteSpace(txtSavePath.Text) == false)));
         });

         if (this.InvokeRequired)
         {
            this.Invoke(p);
         }
         else
         {
            p();
         }
      }

      private void btnChooseFile_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();
         ofd.Filter = "Image Files (*.bmp; *.jpg; *.tif; *.png; *.pdf) | *.BMP; *.JPG; *.TIF; *.PNG; *.PDF";

         ofd.Multiselect = true;

         List<string> unloadableFiles = new List<string>();

         if (ofd.ShowDialog() == DialogResult.OK)
         {
            Cursor cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            for (int i = 0; i < ofd.FileNames.Length; i++)
            {
               if (!AddFile(ofd.FileNames[i]))
               {
                  unloadableFiles.Add(ofd.FileNames[i]);
               }
            }
            this.Cursor = cursor;
         }

         if (unloadableFiles.Count == 1)
         {
            MessageBox.Show(string.Format("This file does not have a page count of {0} expected by the template.", requiredPageCount));
         }
         else if (unloadableFiles.Count > 1)
         {
            string message = "These files were not added as they do not have the expected number of pages:";
            for (int i = 0; i < unloadableFiles.Count; i++)
            {
               message += Environment.NewLine + unloadableFiles[i];
            }

            MessageBox.Show(message);
         }

         OnCanProceed();
      }

      private bool AddFile(string ofd)
      {
         if (File.Exists(ofd))
         {
            if (chkFiles.FindStringExact(ofd) == -1)
            {
               using (RasterCodecs codecs = new RasterCodecs())
               {
                  int pageCount = codecs.GetTotalPages(ofd);

                  if (requiredPageCount != pageCount)
                  {
                     return false;
                  }
               }

               chkFiles.Items.Add(ofd, true);
               chkFiles.TopIndex = chkFiles.Items.Count - 1;
            }

            // it's already in the list
            return true;
         }

         return false;
      }

      private void btnScan_Click(object sender, EventArgs e)
      {
         string savedPath = null;

         if (MainForm.GetFromTwain(out savedPath))
         {
            chkFiles.Items.Add(savedPath, true);
         }

         OnCanProceed();
      }

      private void btnChooseFolderofFiles_Click(object sender, EventArgs e)
      {
         FolderBrowserDialog fbd = new FolderBrowserDialog();
         fbd.Description = "Choose folder containing files to use";

         if (fbd.ShowDialog() == DialogResult.OK)
         {
            DirectoryInfo di = new DirectoryInfo(fbd.SelectedPath);
            List<FileInfo> files = new List<FileInfo>(di.GetFiles());

            files = files.FindAll(f => f.Extension.EndsWith("bmp")
            || f.Extension.EndsWith("jpg")
            || f.Extension.EndsWith("tif")
            || f.Extension.EndsWith("png")
            || f.Extension.EndsWith("pdf"));

            Cursor cursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;

            List<string> unloadableFiles = new List<string>();

            foreach (FileInfo fi in files)
            {
               if (!AddFile(fi.FullName))
               {
                  unloadableFiles.Add(fi.Name);
               }
            }

            this.Cursor = cursor;
            if (unloadableFiles.Count == 1)
            {
               MessageBox.Show(string.Format("The file '{0}' does not have a page count of {0} expected by the template.", unloadableFiles[0], requiredPageCount));
            }
            else if (unloadableFiles.Count > 1)
            {
               string message = "These files were not added as they do not have the expected number of pages:";
               for (int i = 0; i < unloadableFiles.Count; i++)
               {
                  message += Environment.NewLine + unloadableFiles[i];
               }
               MessageBox.Show(message);
            }
         }

         OnCanProceed();
      }

      private void chkSaveWorkspace_CheckedChanged(object sender, EventArgs e)
      {
         OnCanProceed();

         txtSavePath.Enabled = chkSaveWorkspace.Checked;
         btnChooseWorkspaceFilename.Enabled = chkSaveWorkspace.Checked;
      }

      private void btnChooseWorkspaceFilename_Click(object sender, EventArgs e)
      {
         string path;
         if (MainForm.ChooseWorkspaceFilePath(out path))
         {
            txtSavePath.Text = path;
         }
      }

      private void txtSavePath_TextChanged(object sender, EventArgs e)
      {
         OnCanProceed();
      }

      private void btnRemoveUnchecked_Click(object sender, EventArgs e)
      {
         for (int i = chkFiles.Items.Count - 1; i >= 0; i--)
         {
            if (!chkFiles.GetItemChecked(i))
            {
               chkFiles.Items.RemoveAt(i);
            }
         }
      }
   }
}