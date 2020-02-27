// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.WinForms;
using Leadtools.Demos;

namespace WiaDemo
{
   public partial class CaptureStillImagesForm : Form
   {
      private RasterThumbnailBrowser _browser;

      public CaptureStillImagesForm()
      {
         InitializeComponent();
      }

      private void CaptureStillImagesForm_Load(object sender, EventArgs e)
      {
         String imagesFolder = String.Empty;

         _browser = new RasterThumbnailBrowser();
         _browser.UseDpi = true;
         _browser.Codecs = new RasterCodecs();
         _browser.Dock = DockStyle.Fill;
         _browser.SelectionMode = RasterImageListSelectionMode.Multi;
         _browser.ViewStyle = RasterImageListViewStyle.Button;
         _browser.ScrollStyle = RasterImageListScrollStyle.Vertical;
         _browser.EnableKeyboard = true;
         _browser.EnableRubberBandSelection = true;
         _browser.ShowItemText = true;
         _browser.ItemSize = new Size(120, 120);
         _browser.ItemSpacingSize = new Size(5, 5);
         _browser.BackColor = Color.Bisque;
         _browser.ItemImageSize = new Size(100, 100);

         _pnlBrowser.Controls.Add(_browser);
         _browser.BringToFront();

         try
         {
            Object rootItem = null;

#if !LEADTOOLS_V17_OR_LATER
            MainForm._wiaSession.GetRootItem(null);
            rootItem = MainForm._wiaSession.RootItem;
            if (rootItem != null)
            {
               MainForm._wiaSession.GetPropertyString(rootItem, null, Leadtools.Wia.WiaPropertyId.VideoDeviceImagesDirectory);
               imagesFolder = MainForm._wiaSession.StringValue;
            }
#else
            rootItem = MainForm._wiaSession.GetRootItem(null);
            if (rootItem != null)
               imagesFolder = MainForm._wiaSession.GetPropertyString(rootItem, null, Leadtools.Wia.WiaPropertyId.VideoDeviceImagesDirectory);
#endif //#if !LEADTOOLS_V17_OR_LATER

            // Enable Events
            _browser.LoadThumbnail += new EventHandler<RasterThumbnailBrowserLoadThumbnailEventArgs>(_browser_LoadThumbnail);
            _browser.Click += new EventHandler(_browser_Click);

            _browser.LoadThumbnails(imagesFolder, "*.jpg", RasterThumbnailBrowserLoadFlags.None);

            // Start the video preview
#if !LEADTOOLS_V19_OR_LATER
            MainForm._wiaSession.StartVideoPreview(_pnlVideoPreview, false);
#else
            MainForm._wiaSession.StartVideoPreview(_pnlVideoPreview.Handle, false);
#endif // #if !LEADTOOLS_V19_OR_LATER

            UpdateDialogControls(false);
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      void _browser_Click(object sender, EventArgs e)
      {
         _browser.Focus();
         if (_browser.SelectedItems.Count > 0)
         {
            UpdateDialogControls(true);
         }
         else
         {
            UpdateDialogControls(false);
         }
      }

      void _browser_LoadThumbnail(object sender, RasterThumbnailBrowserLoadThumbnailEventArgs e)
      {
         _browser.EnsureVisible(e.Index);
      }

      private void CaptureStillImagesForm_FormClosed(object sender, FormClosedEventArgs e)
      {
         _browser.Items.Clear();

         // Disable Events
         _browser.LoadThumbnail -= new EventHandler<RasterThumbnailBrowserLoadThumbnailEventArgs>(_browser_LoadThumbnail);

         bool videoPreviewAvailable = MainForm._wiaSession.IsVideoPreviewAvailable();
         if (videoPreviewAvailable)
         {
            MainForm._wiaSession.EndVideoPreview();
         }
      }

      private void _pnlVideoPreview_SizeChanged(object sender, EventArgs e)
      {
         MainForm._wiaSession.ResizeVideoPreview(false);
      }

      private void UpdateDialogControls(bool imageListItemsSelected)
      {
         bool videoPreviewAvailable = MainForm._wiaSession.IsVideoPreviewAvailable();

         _btnTakePicture.Enabled = videoPreviewAvailable;
         _btnLoadPictures.Enabled = imageListItemsSelected;
      }

      private void _btnTakePicture_Click(object sender, EventArgs e)
      {
         if (MainForm._wiaSession.IsVideoPreviewAvailable())
         {
            try
            {
               string takenPictureFileName = string.Empty;
#if !LEADTOOLS_V17_OR_LATER
               MainForm._wiaSession.AcquireImageFromVideo();
               takenPictureFileName = MainForm._wiaSession.TakenPictureFileName;
#else
               takenPictureFileName = MainForm._wiaSession.AcquireImageFromVideo();
#endif //#if !LEADTOOLS_V17_OR_LATER

               // Add the new captured image thumbnail to the image list.
               RasterImage image = MainForm._codecs.Load(takenPictureFileName);
               string imageName = Path.GetFileName(takenPictureFileName);
               RasterImageListItem item = new RasterImageListItem(image, 1, imageName);
               item.FileName = takenPictureFileName;
               _browser.Items.Add(item);
               _browser.EnsureVisible(_browser.Items.Count - 1);
            }
            catch(Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void _btnLoadPictures_Click(object sender, EventArgs e)
      {
         try
         {
            foreach (RasterImageListItem i in _browser.SelectedItems)
            {
               RasterImage image = MainForm._codecs.Load(i.FileName);
               FormParent.CreateChildForm(image, i.FileName);
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private MainForm _parentForm = null;
      public MainForm FormParent
      {
         get
         {
            return _parentForm;
         }
         set
         {
            _parentForm = value;
         }
      }
   }
}
