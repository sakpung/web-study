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
using System.Net;
using System.Threading;

using Leadtools.Demos;
using Leadtools;
using Leadtools.Codecs;

namespace SharePointDemo
{
   public partial class SharePointDownloadUploadDialog : Form
   {
      // Set the server properties to use
      private SharePointServerProperties _serverProperties;
      // The RasterCodecs objects used to download/upload
      private RasterCodecs _rasterCodecs;
      // The Image file name
      private string _imageFileName;
      // The RasterImage object
      private RasterImage _rasterImage;
      // The image name on the server
      private string _imageServerName;
      // Are we downloading (or uploading?)
      private bool _isDownloading;
      // We are busy
      private bool _isBusy;

      public SharePointDownloadUploadDialog(SharePointServerProperties serverProperties, RasterCodecs codecs, string imageFileName, RasterImage image)
      {
         InitializeComponent();

         _rasterCodecs = codecs;
         _serverProperties = serverProperties;

         _imageFileName = imageFileName;
         _rasterImage = image;

         if(_rasterImage == null)
         {
            // We are downloading
            _isDownloading = true;
         }
         else
         {
            // We are uploading
            _isDownloading = false;
         }
      }

      public RasterImage RasterImage
      {
         get { return _rasterImage; }
      }

      public string ImageServerName
      {
         get { return _imageServerName; }
      }

      private delegate void StartupDelegate();

      protected override void OnLoad(EventArgs e)
      {
         _isBusy = true;

         BeginInvoke(new StartupDelegate(Startup));

         base.OnLoad(e);
      }

      private void Startup()
      {
         if(_isDownloading)
            _messageLabel.Text = string.Format("Downloading '{0}' from '{1}'", _imageFileName, _serverProperties.Url);
         else
            _messageLabel.Text = string.Format("Uploading '{0}' to '{1}'", _imageFileName, _serverProperties.Url);
         _busyProgressBar.MarqueeAnimationSpeed = 100;
         Application.DoEvents();

         Thread t = new Thread(new ThreadStart(UploadDownload));
         t.Start();
      }

      private void UploadDownload()
      {
         try
         {
            // Set the credentials
            if(_serverProperties.UseCredentials)
               _rasterCodecs.UriOperationCredentials = new NetworkCredential(_serverProperties.UserName, _serverProperties.Password, _serverProperties.Domain);
            else
               _rasterCodecs.UriOperationCredentials = CredentialCache.DefaultCredentials;

            // Set the proxy
            if(_serverProperties.UseProxy)
               _rasterCodecs.UriOperationProxy = new WebProxy(_serverProperties.Host, _serverProperties.Port);
            else
               _rasterCodecs.UriOperationProxy = null;

            // Create the URL for the image
            string url = _serverProperties.Url;
            if(!url.EndsWith("/"))
               url += "/";

            // Use the SharePoint Lists web service
            url += "Shared Documents/" + _imageFileName;

            Uri uri = new Uri(url);
            _imageServerName = uri.ToString();

            // Upload or download this image
            if(_isDownloading)
               _rasterImage = _rasterCodecs.Load(uri);
            else
               _rasterCodecs.Save(_rasterImage, uri, _rasterImage.OriginalFormat, 0);

            CloseMe(true, null);
         }
         catch(Exception ex)
         {
            CloseMe(false, ex);
         }
      }

      private void CloseMe(bool success, Exception ex)
      {
         BeginInvoke(new MethodInvoker(delegate()
         {
            if(success)
            {
               _isBusy = false;
               DialogResult = DialogResult.OK;
            }
            else
            {
               // Stop the animation and show the error
               _busyProgressBar.MarqueeAnimationSpeed = 0;
               Application.DoEvents();

               Messager.ShowError(this, ex);

               // Cancel
               _isBusy = false;
               DialogResult = DialogResult.Cancel;
            }
         }));
      }

      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         // If we are busy, cancel but do not close the dialog
         // The ConnectToServer method will eventually exists
         if(_isBusy)
         {
            e.Cancel = true;
         }

         base.OnFormClosing(e);
      }
   }
}
