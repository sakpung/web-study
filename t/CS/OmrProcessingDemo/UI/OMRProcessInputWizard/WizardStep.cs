using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmrProcessingDemo.UI
{
   public class WizardStep : UserControl
   {
      public event EventHandler<UpdatedEventArgs> CanProceed;

      public string Title { get; protected set; }

      protected WizardStep()
      {
         this.VisibleChanged += WizardStep_VisibleChanged;
      }

      private void WizardStep_VisibleChanged(object sender, EventArgs e)
      {
         if (Visible)
         {
            OnCanProceed();
         }
      }

      protected virtual void OnCanProceed() { }

      protected void OnCanProceed(bool canProceed)
      {
         if (CanProceed != null)
         {
            CanProceed(this, new UI.UpdatedEventArgs(canProceed));
         }
      }

      private void InitializeComponent()
      {
         this.SuspendLayout();
         // 
         // WizardStep
         // 
         this.Name = "WizardStep";
         this.Size = new System.Drawing.Size(617, 198);
         this.ResumeLayout(false);

      }
   }

   public class UpdatedEventArgs : EventArgs
   {
      public bool CanProceed { get; private set; }
      public UpdatedEventArgs(bool canProceed)
      {
         this.CanProceed = canProceed;
      }
   }
}
