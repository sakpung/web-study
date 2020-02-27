// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Leadtools.Ocr;

namespace OcrDemo
{
   /// <summary>
   /// This is a dialog that handles the OCR progress callback
   /// </summary>
   public partial class OcrProgressDialog : Form
   {
      // The user operation
      public delegate void ProcessDelegate(OcrProgressDialog dlg, Dictionary<string, object> args);
      private ProcessDelegate _delegate;
      private Dictionary<string, object> _args;
      // The OCR progress callback
      private OcrProgressCallback _ocrProgressCallback;
      // Has the operation been canceled?
      private bool _isCanceled;
      // Is the dialog working?
      private bool _isWorking;
      // Are we using a progress bar?
      private bool _allowProgress;

      public OcrProgressDialog(bool allowProgress, string title, ProcessDelegate del, Dictionary<string, object> args)
      {
         InitializeComponent();

         Text = title;
         _delegate = del;
         _args = args;

         _allowProgress = allowProgress;

         if(_allowProgress)
            _panel.BorderStyle = BorderStyle.None;
         else
         {
            // Hide the border and cancel button
            _panel.BorderStyle = BorderStyle.FixedSingle;
            FormBorderStyle = FormBorderStyle.None;
            _cancelButton.Visible = false;
            _cancelButton.Enabled = false;

            // Use Marquee progress style
            _progressBar.Style = ProgressBarStyle.Marquee;
         }

         _isWorking = true;
      }

      public bool IsCanceled
      {
         get
         {
            return _isCanceled;
         }
      }

      public OcrProgressCallback OcrProgressCallback
      {
         get
         {
            return _ocrProgressCallback;
         }
      }

      protected override void OnLoad(EventArgs e)
      {
         // Call the user to perform the operation, run it in a separate thread
         Thread t = new Thread(new ParameterizedThreadStart(StartUp));
         t.Start();

         base.OnLoad(e);
      }

      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         // Dont allow the form to close while the callback is still working
         if(_isWorking)
            e.Cancel = true;

         base.OnFormClosing(e);
      }

      private void StartUp(object obj)
      {
         if(_allowProgress)
            _ocrProgressCallback = new OcrProgressCallback(MyOcrProgressCallback);
         else
            _ocrProgressCallback = null;

         Invoke(_delegate, new object[] { this, _args });

         if(_isCanceled)
            DialogResult = DialogResult.Cancel;
         else
            DialogResult = DialogResult.OK;

         _isWorking = false;

         if(InvokeRequired && IsHandleCreated)
            BeginInvoke(new MethodInvoker(Close));
         else
            Close();
      }

      private void DoUpdateStatus(string str, int percentage)
      {
         _descriptionLabel.Text = str;
         _progressBar.Value = percentage;
      }

      private delegate void DoUpdateStatusDelegate(string str, int percentage);

      private void MyOcrProgressCallback(IOcrProgressData data)
      {
         // Update the description label
         int pageNumber = data.CurrentPageIndex + 1;
         int pagesCount = data.LastPageIndex + 1;

         string str = string.Format("{0} - Page {1} of {2}", data.Operation.ToString(), pageNumber, pagesCount);
         int percentage = data.Percentage;

         if(InvokeRequired && IsHandleCreated)
            BeginInvoke(new DoUpdateStatusDelegate(DoUpdateStatus), new object[] { str, percentage });
         else
            DoUpdateStatus(str, percentage);

         if(_isCanceled)
            data.Status = OcrProgressStatus.Abort;

         Application.DoEvents();
      }

      private void _cancelButton_Click(object sender, EventArgs e)
      {
         // Set the isCanceled variable to true
         // This will break from the progress callback and 
         // closes the dialog
         if(_allowProgress)
            _isCanceled = true;
      }

      private void DoUpdateDescription(string message)
      {
         _descriptionLabel.Text = message;
      }

      private delegate void UpdateDescriptionDelegate(string message);

      /// <summary>
      /// Called by the user to update the description label
      /// </summary>
      public void UpdateDescription(string message)
      {
         if(InvokeRequired && IsHandleCreated)
            BeginInvoke(new UpdateDescriptionDelegate(DoUpdateDescription), new object[] { message });
         else
            DoUpdateDescription(message);
         Application.DoEvents();
      }

      /// <summary>
      /// Called by the user when the operation is done to close the dialog
      /// </summary>
      public void EndOperation()
      {
         _isWorking = false;

         if(InvokeRequired && IsHandleCreated)
            BeginInvoke(new MethodInvoker(Close));
         else
            Close();
      }
   }
}
