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
using System.IO;

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;

namespace SharePointDemo
{
   public partial class MainForm : Form
   {
      // Ths RasterCodecs instance used to load/save raster images
      private RasterCodecs _codecs;
      // SharePoint server properties
      private SharePointServerProperties _serverProperties;
      // The name (without path) of the last image we put in the viewer
      private string _lastImageName;
      private string _openInitialPath = string.Empty;
      private ImageViewerPanZoomInteractiveMode panMode;
      private ImageViewerZoomToInteractiveMode zoomToMode;
      private ImageViewerNoneInteractiveMode noneMode;

      public MainForm()
      {
         InitializeComponent();

         InitInteractiveModes();

         // Initialize the messager class (used to show error messages)
         Messager.Caption = "C# SharePoint Demo";
         this.Text = Messager.Caption;

         // Init the RasterCodecs object
         _codecs = new RasterCodecs();
      }

      private void InitInteractiveModes()
      {
         noneMode = _viewerControl.NoneInteractiveMode;
         panMode = _viewerControl.PanZoomInteractiveMode;
         zoomToMode = _viewerControl.ZoomToInteractiveMode;
      }

      protected override void OnLoad(EventArgs e)
      {
         // We must connect to a valid SharePoint server
         // Otherwise, this demo will exit

         _serverProperties = new SharePointServerProperties();

         // Load the last settings we used
         Properties.Settings settings = new Properties.Settings();

         _serverProperties.Url = settings.Url;
         bool.TryParse(settings.UseCredentials, out _serverProperties.UseCredentials);
         _serverProperties.UserName = settings.UserName;
         _serverProperties.Password = string.Empty;
         _serverProperties.Domain = settings.Domain;
         bool.TryParse(settings.UseProxy, out _serverProperties.UseProxy);
         _serverProperties.Host = settings.Host;
         int.TryParse(settings.Port, out _serverProperties.Port);

         if (!ConnectToSharePointServer())
         {
            Close();
         }

         base.OnLoad(e);
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         // Save last settings used
         Properties.Settings settings = new Properties.Settings();

         settings.Url = _serverProperties.Url;
         settings.UseCredentials = _serverProperties.UseCredentials.ToString();
         settings.UserName = _serverProperties.UserName;
         settings.Domain = _serverProperties.Domain;
         settings.UseProxy = _serverProperties.UseProxy.ToString();
         settings.Host = _serverProperties.Host;
         settings.Port = _serverProperties.Port.ToString();

         settings.Save();

         // Dispose the RasterCodecs object we used
         if (_codecs != null)
            _codecs.Dispose();

         base.OnFormClosed(e);
      }

      private void _fileOpenToolStripMenuItem_Click(object sender, EventArgs e)
      {
         OpenImageFile();
      }

      private void _fileExitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _helpAboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("SharePoint", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         bool isImageAvailable = _viewerControl.RasterImage != null;
         _viewZoomInToolStripMenuItem.Enabled = isImageAvailable;
         _viewZoomOutToolStripMenuItem.Enabled = isImageAvailable;
         _viewFitPageWidthToolStripMenuItem.Enabled = isImageAvailable;
         _viewFitPageToolStripMenuItem.Enabled = isImageAvailable;
      }

      private void _viewZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.ZoomViewer(true);
      }

      private void _viewZoomInToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.ZoomViewer(false);
      }

      private void _viewFitPageWidthToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.FitPage(true);
      }

      private void _viewFitPageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.FitPage(false);
      }

      private void _pagesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         bool isImageAvailable = _viewerControl.RasterImage != null;

         if (isImageAvailable)
         {
            _pagesPreviousToolStripMenuItem.Enabled = _viewerControl.RasterImage.Page > 1;
            _pagesNextToolStripMenuItem.Enabled = _viewerControl.RasterImage.Page < _viewerControl.RasterImage.PageCount;
         }
         else
         {
            _pagesPreviousToolStripMenuItem.Enabled = false;
            _pagesNextToolStripMenuItem.Enabled = false;
         }
      }

      private void _pagesPreviousToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.MoveToPage(true);
      }

      private void _pagesNextToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.MoveToPage(false);
      }

      private void _interactiveToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         _interactiveSelectModeToolStripMenuItem.Checked = noneMode.IsEnabled;
         _interactivePanModeToolStripMenuItem.Checked = panMode.IsEnabled;
         _interactiveZoomToSelectionModeToolStripMenuItem.Checked = zoomToMode.IsEnabled;

         bool isImageAvailable = _viewerControl.RasterImage != null;

         _interactiveSelectModeToolStripMenuItem.Enabled = isImageAvailable;
         _interactivePanModeToolStripMenuItem.Enabled = isImageAvailable;
         _interactiveZoomToSelectionModeToolStripMenuItem.Enabled = isImageAvailable;
      }

      private void _interactiveSelectModeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.SetMode(noneMode);
      }

      private void _interactivePanModeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.SetMode(panMode);
      }

      private void _interactiveZoomToSelectionModeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         _viewerControl.SetMode(zoomToMode);
      }

      private void _sharePointServerToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {
         _sharePointServerRefreshToolStripMenuItem.Enabled = _serverControl.CanRefresh;
         _sharePointServerUploadCurrentImageToolStripMenuItem.Enabled = _viewerControl.RasterImage != null;
      }

      private void _sharePointServerPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ConnectToSharePointServer();
      }

      private void _sharePointServerRefreshToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_serverControl.CanRefresh)
            RefreshServer();
      }

      private void _sharePointServerUploadCurrentImageToolStripMenuItem_Click(object sender, EventArgs e)
      {
         if (_viewerControl.RasterImage != null)
            UploadImage();
      }

      private void _serverControl_ServerClicked(object sender, EventArgs e)
      {
         ConnectToSharePointServer();
      }

      private void _serverControl_RefreshClicked(object sender, EventArgs e)
      {
         RefreshServer();
      }

      private void _serverControl_DownloadClicked(object sender, EventArgs e)
      {
         string name = _serverControl.GetSelectedItemName();
         DownloadImage(name);
      }

      private void _viewerControl_OpenFileClicked(object sender, EventArgs e)
      {
         OpenImageFile();
      }

      private void _viewerControl_UploadClicked(object sender, EventArgs e)
      {
         UploadImage();
      }

      private void OpenImageFile()
      {
         // Open an image file from disk and put it in the viewer
         ImageFileLoader loader = new ImageFileLoader();

         loader.OpenDialogInitialPath = _openInitialPath;

         try
         {
            loader.ShowLoadPagesDialog = true;

            if (loader.Load(this, _codecs, true) > 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               SetViewerImage(loader.FileName, loader.Image, Path.GetFileName(loader.FileName));
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }
      }

      private void DownloadImage(string name)
      {
         // Download the image from the server and put it in the raster image viewer
         SharePointDownloadUploadDialog dlg = new SharePointDownloadUploadDialog(
            _serverProperties,
            _codecs,
            name,
            null);
         if (dlg.ShowDialog(this) == DialogResult.OK)
            SetViewerImage(dlg.ImageServerName, dlg.RasterImage, name);
      }

      private void SetViewerImage(string name, RasterImage image, string imageName)
      {
         _viewerControl.Text = name;
         _viewerControl.RasterImage = image;
         _lastImageName = imageName;
      }

      private void UploadImage()
      {
         // Download the image from the server and put it in the raster image viewer
         SharePointDownloadUploadDialog dlg = new SharePointDownloadUploadDialog(
            _serverProperties,
            _codecs,
            _lastImageName,
            _viewerControl.RasterImage);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            // Refresh the server
            RefreshServer();
         }
      }

      private bool ConnectToSharePointServer()
      {
         bool ret = false;

         SharePointServerProperties serverProperties = _serverProperties;

         // Keep trying till we connect to a valid server or the user cancels
         bool done = false;
         while (!done)
         {
            using (ServerPropertiesDialog propertiesDialog = new ServerPropertiesDialog(_serverProperties))
            {
               if (propertiesDialog.ShowDialog(this) == DialogResult.OK)
               {
                  // Get the properties
                  serverProperties = propertiesDialog.ServerProperties;

                  IList<string> documentNames = ConnectToServer(serverProperties);
                  if (documentNames != null)
                  {
                     _serverProperties = serverProperties;

                     // Populate the server control with the document names
                     PopulateServerControl(documentNames);
                     done = true;
                     ret = true;
                  }
               }
               else
                  done = true;
            }
         }

         return ret;
      }

      private IList<string> ConnectToServer(SharePointServerProperties serverProperties)
      {
         IList<string> documentNames = null;

         // Try to connect to this SharePoint server
         using (SharePointConnectDialog connectDialog = new SharePointConnectDialog(serverProperties))
         {
            if (connectDialog.ShowDialog(this) == DialogResult.OK)
               documentNames = connectDialog.DocumentNames;
         }

         return documentNames;
      }

      private void RefreshServer()
      {
         // Re-get the documents from the last server we used
         IList<string> documentNames = ConnectToServer(_serverProperties);
         if (documentNames != null)
            PopulateServerControl(documentNames);
      }

      private void PopulateServerControl(IList<string> documentNames)
      {
         string url = _serverProperties.Url;
         if (!url.EndsWith("/"))
            url += "/";

         url += "Shared Documents";

         _serverControl.Text = url;
         _serverControl.Populate(documentNames);
      }
   }
}
