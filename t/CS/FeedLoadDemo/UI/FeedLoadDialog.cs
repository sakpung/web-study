// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Net;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Codecs;

namespace FeedLoadDemo
{
   /// <summary>
   /// Summary description for FeedLoadDialog.
   /// </summary>
   public class FeedLoadDialog : System.Windows.Forms.Form
   {
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Label _lblProgress;
      private System.Windows.Forms.ProgressBar _pbProgress;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public FeedLoadDialog(RasterCodecs codecs, string url, string fileName)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         _codecs = codecs;
         _url = url;
         _fileName = fileName;
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
         this._btnCancel = new System.Windows.Forms.Button();
         this._lblProgress = new System.Windows.Forms.Label();
         this._pbProgress = new System.Windows.Forms.ProgressBar();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(109, 80);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _lblProgress
         // 
         this._lblProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblProgress.Location = new System.Drawing.Point(10, 8);
         this._lblProgress.Name = "_lblProgress";
         this._lblProgress.Size = new System.Drawing.Size(272, 23);
         this._lblProgress.TabIndex = 0;
         this._lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _pbProgress
         // 
         this._pbProgress.Location = new System.Drawing.Point(10, 40);
         this._pbProgress.Name = "_pbProgress";
         this._pbProgress.Size = new System.Drawing.Size(272, 23);
         this._pbProgress.TabIndex = 1;
         // 
         // FeedLoadDialog
         // 
         this.AcceptButton = this._btnCancel;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(292, 109);
         this.Controls.Add(this._pbProgress);
         this.Controls.Add(this._lblProgress);
         this.Controls.Add(this._btnCancel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FeedLoadDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Loading...";
         this.Load += new System.EventHandler(this.FeedLoadDialog_Load);
         this.ResumeLayout(false);

      }
      #endregion

      private RasterCodecs _codecs;
      private string _url;
      private string _fileName;
      private IAsyncResult _ar;
      private bool _canceled;
      private delegate void StartupCallback( );

      public RasterImage Image;

      private void FeedLoadDialog_Load(object sender, System.EventArgs e)
      {
         _ar = BeginInvoke(new StartupCallback(Startup));
      }

      private void Startup( )
      {
         EndInvoke(_ar);

         _pbProgress.Visible = _fileName != null;

         Application.DoEvents();
         _canceled = false;

         WebResponse response = null;
         FileStream fs = null;
         Stream strm = null;

         try
         {
            WebRequest request;

            int length;

            if(_url != null)
            {
               request = WebRequest.Create(_url);
               if(request.Proxy!=null)
                  request.Proxy.Credentials = CredentialCache.DefaultCredentials;

               // reduce the timeout to 20sec
               request.Timeout = 20000;
               // you cannot cancel during GetResponse()
               _btnCancel.Enabled = false;
               response = request.GetResponse();
               _btnCancel.Enabled = true;
               strm = response.GetResponseStream();
               length = -1;
            }
            else
            {
               fs = File.OpenRead(_fileName);
               length = (int)fs.Length;
               strm = fs;
               _pbProgress.Maximum = length;
            }

            const int bufferSize = 1024;
            byte[] buffer = new byte[bufferSize];

            int read;
            int count = 0;

            _codecs.StartFeedLoad(0, CodecsLoadByteOrder.BgrOrGray);

            do
            {
               Application.DoEvents();

               if(!_canceled)
               {
                  read = strm.Read(buffer, 0, bufferSize);
                  if(read > 0)
                  {
                     Application.DoEvents();

                     if(!_canceled)
                        _codecs.FeedLoad(buffer, 0, read);

                     count += read;
                  }
               }
               else
                  read = 0;

               if(!_canceled)
               {
                  if(_url != null)
                     _lblProgress.Text = string.Format("Downloading {0} bytes", count);
                  else
                  {
                     _lblProgress.Text = string.Format("Loading {0} of {1} bytes", count, length);
                     _pbProgress.Value = count;
                  }
               }
            }
            while(read > 0 && !_canceled);


            if(!_canceled)
            {
               Image = _codecs.StopFeedLoad();
               Close(DialogResult.OK);
            }
            else
            {
               _codecs.CancelFeedLoad();
               Image = null;
               Close(DialogResult.Cancel);
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            Close(DialogResult.Cancel);
         }
         finally
         {
            if(strm != null)
               strm.Close();
            if(response != null)
               response.Close();
            if(fs != null)
               fs.Close();
         }
      }

      private void Close(DialogResult res)
      {
         DialogResult = res;
         Close();
      }

      private void _btnCancel_Click(object sender, System.EventArgs e)
      {
         _canceled = true;
         DialogResult = DialogResult.None;
         Close();
      }
   }
}
