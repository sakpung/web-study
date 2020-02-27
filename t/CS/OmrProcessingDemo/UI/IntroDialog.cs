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
   public partial class IntroDialog : Form
   {
      public enum StartupType
      {
         None,
         NewTemplate,
         LoadTemplate,
         LoadWorkspace,
         LoadBackupTemplate
      }

      public StartupType Start { get; private set; }

      public IntroDialog(bool recoverVisible)
      {
         InitializeComponent();

         Start = StartupType.None;

         rdbtnLoadAutosave.Visible = recoverVisible;
         lblDescAutoRecover.Visible = recoverVisible;
      }

      private void rdbtnCreateNewTemplate_CheckedChanged(object sender, EventArgs e)
      {
         Start = StartupType.NewTemplate;
      }

      private void rdbtnLoadTemplate_CheckedChanged(object sender, EventArgs e)
      {
         Start = StartupType.LoadTemplate;
      }

      private void rdbtnLoadWorkspace_CheckedChanged(object sender, EventArgs e)
      {
         Start = StartupType.LoadWorkspace;
      }
      private void rdbtnLoadAutosave_CheckedChanged(object sender, EventArgs e)
      {
         Start = StartupType.LoadBackupTemplate;
      }

      private void IntroDialog_FormClosed(object sender, FormClosedEventArgs e)
      {
         if (this.DialogResult == DialogResult.Cancel)
         {
            Start = StartupType.None;
         }
      }

   }
}
