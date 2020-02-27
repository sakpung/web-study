using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmrProcessingDemo.Operations
{
   class BusyOperation
   {
      protected bool useWaitWindow = true;

      private Thread thread;
      private WaitWindow ww;
      private AutoResetEvent autoReset = new AutoResetEvent(false);
      public BusyOperation()
      {
         thread = new Thread(new ThreadStart(StartThread));
         ww = new WaitWindow();
      }

      public void Start()
      {
         thread.Start();

         if (thread.IsAlive && useWaitWindow)
         {
            ww.ShowDialog();
         }
         
         WaitHandle.WaitAny(new WaitHandle[] { this.autoReset });
      }

      // override and implement custom logic BusyOperation is to perform
      protected virtual void Run()
      {
      }

      // override for operation-specific error-handling
      protected virtual void StartThread()
      {
         try
         {
            Run();
         }
         catch (Exception ex)
         {
            Error(ex);
         }
         finally
         {
            Complete();
         }
      }

      // call to update progress in wait window with 0-100 percentage and title (use 101 for marquee scroll)
      protected void Progress(int percentage, string message)
      {
         Action p = new Action(delegate ()
         {
            ww.lblDisplay.Text = string.IsNullOrWhiteSpace(message) ? ww.lblDisplay.Text : message;
            if (percentage > ww.pbar.Maximum)
            {
               ww.pbar.Style = ProgressBarStyle.Marquee;
            }
            else
            {
               ww.pbar.Style = ProgressBarStyle.Continuous;
               ww.pbar.Value = percentage;
            }
         });

         Migrate(p);
      }

      protected void Complete()
      {
         Action p = new Action(delegate ()
         {
            if (ww.Visible)
            {
               ww.Close();
            }
         });

         Migrate(p);

         autoReset.Set();
      }

      private void Error(Exception ex)
      {
         Action p = new Action(delegate ()
         {
            ww.lblDisplay.Text = ex.Message;
            MessageBox.Show(ex.Message);
         });

         Migrate(p);
      }

      private void Migrate(Action p)
      {
         if (ww.InvokeRequired)
         {
            ww.Invoke(p);
         }
         else if (ww.IsHandleCreated)
         {
            p();
         }
      }
   }
}
