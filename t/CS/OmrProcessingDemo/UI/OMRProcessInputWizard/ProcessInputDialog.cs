using Leadtools;
using Leadtools.Forms.Processing.Omr.Fields;
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

namespace OmrProcessingDemo.UI.ViewerControl
{
   public partial class ProcessInputDialog : Form
   {
      private WizardStep[] steps;
      private int index = 0;

      // for multi-step instructions, handles navigating between panes
      public ProcessInputDialog(WizardStep[] wizardSteps)
      {
         InitializeComponent();

         steps = wizardSteps;

         for (int i = 0; i < steps.Length; i++)
         {
            steps[i].CanProceed += ProcessInputDialog_CanProceed;
            steps[i].Location = new Point(12, 3);
         }

         Controls.AddRange(steps);
         index = 0;

         ChangeWizardStep(0);

         btnPrevious.Enabled = index > 0;
      }

      // to display a single input/info pane
      public ProcessInputDialog(WizardStep singleStep, string okButtonText, bool cancelNeeded = true)
      {
         InitializeComponent();

         singleStep.Location = new Point(12, 3);
         singleStep.Visible = true;

         btnPrevious.Visible = false;
         btnNext.Visible = false;

         btnOK.Visible = true;
         btnOK.Text = okButtonText;

         btnCancel.Visible = cancelNeeded;

         singleStep.CanProceed += ProcessInputDialog_CanProceed;

         Controls.Add(singleStep);

         this.Text = singleStep.Title;
      }

      private void ProcessInputDialog_CanProceed(object sender, UpdatedEventArgs e)
      {
         btnNext.Enabled = e.CanProceed;
         btnOK.Enabled = e.CanProceed;
      }

      private void ChangeWizardStep(int v)
      {
         index += v;

         this.Text = steps[index].Title;

         btnPrevious.Enabled = index > 0;

         if (index == steps.Length - 1)
         {
            btnNext.Enabled = false;
            btnOK.Enabled = true;

            btnOK.BringToFront();
            btnNext.SendToBack();
         }
         else
         {
            btnNext.Enabled = true;
            btnOK.Enabled = false;

            btnOK.SendToBack();
            btnNext.BringToFront();
         }

         for (int i = 0; i < steps.Length; i++)
         {
            steps[i].Visible = i == index;
         }
      }

      private void btnNext_Click(object sender, EventArgs e)
      {
         ChangeWizardStep(1);
      }
      private void btnPrevious_Click(object sender, EventArgs e)
      {
         ChangeWizardStep(-1);
         btnNext.Enabled = true;
      }
   }
}