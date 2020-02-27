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

namespace Leadtools.Annotations.WinForms
{
   public enum MediaControl
   {
      Audio,
      Video
   }

   public partial class MediaForm : Form
   {
      MediaControl _mediaControl;

      public MediaForm(string url, MediaControl mediaControl)
      {
         InitializeComponent();

         _mediaControl = mediaControl;

         switch (mediaControl)
         {
            case MediaControl.Audio:
               mediaWebBrowser.DocumentText = @"
               <!DOCTYPE html>
               <html lang='en'>
               <head>
                   <meta http-equiv='X-UA-Compatible' content='IE=Edge,chrome=IE8'/>
               </head>
               <body>
                  <audio id='mediaObject' controls='controls'>
                     <source src='" + url + @"'>
                  </audio>
               </body>
               </html>";
               this.Size = new Size(650, 100);
               break;

            case MediaControl.Video:
               mediaWebBrowser.DocumentText = @"
               <!DOCTYPE html>
               <html lang='en'>
               <head>
                   <meta http-equiv='X-UA-Compatible' content='IE=Edge,chrome=IE8' />
               </head>
               <body>
                  <video id='mediaObject' controls='controls'>
                     <source src='" + url + @"'>
                  </video>
               </body>
               </html>";
               this.Size = new Size(650, 400);
               break;
         }
      }

      private void mediaWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
      {
         HtmlElement mediaObject = mediaWebBrowser.Document.GetElementById("mediaObject");
         if (mediaObject != null)
         {
            mediaObject.InvokeMember("play");
         }

         mediaWebBrowser.Document.Body.Style = "margin:0px; padding:0px; overflow:hidden; width:100%; height:100%;";

         mediaObject.Style = "width:100%; height:100%;";

         if (_mediaControl == MediaControl.Video)
         {
            mediaObject.DoubleClick += mediaObject_DoubleClick;
         }
      }

      private bool _isFullScreenMode = false;
      private void mediaObject_DoubleClick(object sender, HtmlElementEventArgs e)
      {
         this.TopMost = _isFullScreenMode ? false : true;

         this.FormBorderStyle = _isFullScreenMode ? FormBorderStyle.FixedDialog : FormBorderStyle.None;

         this.WindowState = _isFullScreenMode ? FormWindowState.Normal : FormWindowState.Maximized;

         _isFullScreenMode = !_isFullScreenMode;
      }
   }
}
