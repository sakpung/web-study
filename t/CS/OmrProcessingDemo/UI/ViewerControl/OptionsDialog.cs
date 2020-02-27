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

namespace OmrProcessingDemo.ViewerControl
{
   public partial class OptionsDialog : Form
   {
      bool _autoEstimateMissingOmr;
      public OptionsDialog(bool autoEstimateMissingOmr)
      {
         InitializeComponent();


         chkAutoEstimate.Checked = autoEstimateMissingOmr;
         chkAutosave.Checked = Properties.Settings.Default.AutoSaveEnabled;
         nudAutosave.Value = Properties.Settings.Default.AutoSaveDelay;
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         _autoEstimateMissingOmr = chkAutoEstimate.Checked;


         Properties.Settings.Default.AutoSaveDelay = (int)nudAutosave.Value;
         Properties.Settings.Default.AutoSaveEnabled = chkAutosave.Checked;
         this.Close();
      }

      private void chkAutosave_CheckedChanged(object sender, EventArgs e)
      {
         nudAutosave.Enabled = chkAutosave.Checked;
      }

      public bool AutoEstimateMissingOmr
      {
         get
         {
            return _autoEstimateMissingOmr;
         }
      }
   }
}
