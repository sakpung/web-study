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
   public partial class WebServiceInstallerResultDialog : Form
   {
      public WebServiceInstallerResultDialog()
      {
         InitializeComponent();
      }

      private void WebServiceInstallerResultDialog_Load(object sender, EventArgs e)
      {
         this.Text = "Web Service Installer Created";
         string zipFileName = Path.GetFileName(InstallerLocation);
         string result = WebServiceInstaller.GetInstallerMessage(InstallerMessageType.AfterCreated, zipFileName);
         labelResult.Text = result;

         linkLabel.Text = InstallerLocation;
         linkLabel.Links[0].LinkData = InstallerLocation;
      }

      private string _configure3DServiceToolStripMenuItemText = string.Empty;
      public string Configure3DServiceToolStripMenuItemText
      {
         get
         {
            return _configure3DServiceToolStripMenuItemText;
         }
         set
         {
            _configure3DServiceToolStripMenuItemText = value;
         }
      }

      public string InstallerLocation
      {
         get;
         set;
      }

      private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         string installerLocation = e.Link.LinkData.ToString();
         if (!File.Exists(installerLocation))
            return;

         string argument = "/select, \"" + installerLocation + "\"";

         System.Diagnostics.Process.Start("explorer.exe", argument);
      }
   }
}
