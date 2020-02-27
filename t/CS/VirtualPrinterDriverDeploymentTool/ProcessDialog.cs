// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualPrinterDriverDeploymentTool
{
   public partial class ProcessDialog : Form
   {
      /// <summary>
      ///      The optional action to perform when closing the dialog
      /// </summary>
      private Action cleanup;

      /// <summary>
      ///      Create a new dialog with the specified callback(s)
      /// </summary>
      /// <param name="title">The new title for the dialog</param>
      /// <param name="task">The main process to run</param>
      /// <param name="cleanup">Optional, action to perform when the dialog is closed</param>
      public ProcessDialog(string title, Action<ProcessDialog> task, Action cleanup = null)
      {
         InitializeComponent();

         // Set the title
         Text = title;

         // Start the process in a background thread
         Cursor = Cursors.WaitCursor;
         this.cleanup = cleanup;
         Task.Factory.StartNew(() =>
         {
            try
            {
               task(this);
            }
            catch (Exception ex)
            {
               Finished(string.Format("There was a problem executing the task:{0}{1}", Environment.NewLine, ex.Message));
            }
         });
      }

      /// <summary>
      ///      Ensure the temporary directory gets deleted
      /// </summary>
      /// <param name="sender">Unused</param>
      /// <param name="e">Unused</param>
      private void DeployDialog_FormClosed(object sender, FormClosedEventArgs e)
      {
         cleanup?.Invoke();
      }

      /// <summary>
      ///      Setup the exitting message
      /// </summary>
      /// <param name="message">The final status message</param>
      public void Finished(string message)
      {
         BeginInvoke(new Action(() =>
         {
            Cursor = Cursors.Default;
            Text = "Finished";
            textBoxLog.AppendText("==========" + Environment.NewLine + message);
            MessageBox.Show(message);
         }));
      }

      /// <summary>
      ///      Append a line of input to the text box
      /// </summary>
      /// <param name="line">Text to append</param>
      public void Log(string line)
      {
         BeginInvoke(new Action(() => textBoxLog.AppendText(line + Environment.NewLine)));
      }
   }
}
