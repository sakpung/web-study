using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebViewerConfiguration
{
   public partial class WebServiceInstallerDialog : Form
   {
      string _defaultZipPath = Path.Combine(WebServiceInstaller.RootPath, WebServiceInstaller.DefaultZipName);

      public WebServiceInstallerDialog()
      {
         InitializeComponent();
      }

      private void WebServiceInstallerDialog_Load(object sender, EventArgs e)
      {
         string result = WebServiceInstaller.GetInstallerMessage(InstallerMessageType.BeforeCreated, WebServiceInstaller.DefaultZipName);
         labelResult.Text = result;

         if (string.IsNullOrEmpty(ZipPath))
         {
            textboxZipInstallerPath.Text = _defaultZipPath;
         }
         else
         {
            textboxZipInstallerPath.Text = ZipPath;
         }

         string storageServerPath = WebServiceInstaller.GetStorageServerPath();
         string storageServerName = Path.GetFileName(storageServerPath);
         this.linkLabelRunCSStorageServerManagerDemo.Text = string.Format("Run '{0}'", storageServerName);

         this.linkLabelRunCSStorageServerManagerDemo.LinkClicked += LinkLabelRunCSStorageServerManagerDemo_LinkClicked;
         this.linkLabelInstructionsNetworkPath.LinkClicked += LinkLabelInstructionsNetworkPath_LinkClicked;
         this.linkLabelCreateInstaller.LinkClicked += LinkLabelCreateInstaller_LinkClicked;
      }

      private void LinkLabelRunCSStorageServerManagerDemo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         string storageServerPath = WebServiceInstaller.GetStorageServerPath();
         Process.Start(storageServerPath);
      }

      private void LinkLabelInstructionsNetworkPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         Process.Start("https://www.leadtools.com/support/guides/instructions-filesettingstonetworkpath.pdf");
      }

      private void LinkLabelCreateInstaller_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         Close();
         DialogResult = DialogResult.OK;
      }

      public string ZipPath
      {
         get
         {
            return textboxZipInstallerPath.Text;
         }
         set
         {
            textboxZipInstallerPath.Text = value;
         }
      }


      private void buttonBrowse_Click(object sender, EventArgs e)
      {
         SaveFileDialog saveDialog = new SaveFileDialog();
         saveDialog.Title = "Save Location for Installer";
         saveDialog.FileName = textboxZipInstallerPath.Text;
         saveDialog.Filter = "ZIP files (*.zip)|*.zip|All files (*.*)|*.*";
         saveDialog.OverwritePrompt = true;
         saveDialog.CreatePrompt = false;

         DialogResult result = saveDialog.ShowDialog(this);
         if (result == DialogResult.OK)
         {
            textboxZipInstallerPath.Text = saveDialog.FileName;
         }
      }
   }
}
