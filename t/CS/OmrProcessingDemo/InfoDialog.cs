using OmrProcessingDemo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OmrProcessingDemo
{
   public partial class InfoDialog : Form
   {
      public InfoDialog()
      {
         InitializeComponent();
      }

      private void InfoDialog_Load(object sender, EventArgs e)
      {
         chkShowOnStartup.Checked = Settings.Default.ShowInfoDialog;
      }

      private void InfoDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         Settings.Default.ShowInfoDialog = chkShowOnStartup.Checked;
      }

      private void btnClose_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
