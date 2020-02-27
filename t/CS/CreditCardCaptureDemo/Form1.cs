// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Drawing;
using Leadtools.Multimedia;
using LMVCallbackLib;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Codecs;
using Leadtools.CreditCards;
using System.Diagnostics;
using System.Text;
using Leadtools.ImageProcessing;

namespace CreditCardCapture
{
   public partial class Form1 : Form
   {
      private CaptureCtrl _captureCtrl;
      private ILMVCallback _lmvCallBkPlay;
      private Callback _lmvMyCallback;

      public Form1()
      {
         InitializeComponent();

         _lmvMyCallback = new Callback(this);
         InitializeCaptureCtrl();
      }

      private void Form1_FormClosing(object sender, FormClosingEventArgs e)
      {
         RemoveCallback();
      }

      private void Form1_Paint(object sender, PaintEventArgs e)
      {
         if (_lmvMyCallback != null && _lmvMyCallback.Image != null)
         {
            LeadRect destRect = LeadRect.Create(0, 0, this.ClientSize.Width, this.ClientSize.Height);

            using (RasterImage destImage = new RasterImage(RasterMemoryFlags.Conventional, this.ClientSize.Width, this.ClientSize.Height,
               _lmvMyCallback.Image.BitsPerPixel, _lmvMyCallback.Image.Order, _lmvMyCallback.Image.ViewPerspective,
               _lmvMyCallback.Image.GetPalette(), IntPtr.Zero, 0))
            {
               // Resize the source image into the destination image
               ResizeCommand command = new ResizeCommand();
               command.DestinationImage = destImage;
               command.Flags = RasterSizeFlags.Bicubic;
               command.Run(_lmvMyCallback.Image);

               destRect = RasterImage.CalculatePaintModeRectangle(destImage.ImageWidth, destImage.ImageHeight, destRect, RasterPaintSizeMode.FitAlways, RasterPaintAlignMode.Center, RasterPaintAlignMode.Center);
               LeadRect destClipRect = LeadRect.Create(e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle.Width, e.ClipRectangle.Height);

               using (RasterGraphics rg = RasterImagePainter.CreateGraphics(destImage))
               {
                  rg.Graphics.DrawRectangle(new Pen(Color.Red), _lmvMyCallback.GuideRect.X, _lmvMyCallback.GuideRect.Y, _lmvMyCallback.GuideRect.Width, _lmvMyCallback.GuideRect.Height);
               }

               RasterImagePainter.Paint(destImage, e.Graphics, LeadRect.Empty, LeadRect.Empty, destRect, destClipRect, RasterPaintProperties.Default);
            }
         }
      }

      public void RemoveCallback()
      {
         if (_lmvMyCallback != null)
            _lmvMyCallback.Dispose();

         foreach (Processor vp in _captureCtrl.VideoProcessors)
         {
            if (vp.FriendlyName.Equals("LEAD Video Callback Filter (2.0)"))
            {
               _captureCtrl.SelectedVideoProcessors.Remove(vp);
               break;
            }
         }
      }

      private void InitializeCaptureCtrl()
      {
         try
         {
            _captureCtrl = new CaptureCtrl();
            ((System.ComponentModel.ISupportInitialize)(_captureCtrl)).BeginInit();
            _captureCtrl.AudioCompressors.Selection = -1;
            _captureCtrl.AudioDevices.Selection = -1;
            _captureCtrl.Location = new Point(0, 0);
            _captureCtrl.Name = "_captureCtrl";
            _captureCtrl.Size = new Size(618, 382);
            _captureCtrl.TabIndex = 3;
            _captureCtrl.TargetDevices.Selection = -1;
            _captureCtrl.VideoCompressors.Selection = -1;
            _captureCtrl.VideoDevices.Selection = -1;
            _captureCtrl.WMProfile.Description = "";
            _captureCtrl.WMProfile.Name = "";
            _captureCtrl.VideoWindowSizeMode = SizeMode.Normal;
            _captureCtrl.Preview = true;
            _captureCtrl.Visible = false;

            this.MinimumSize = _captureCtrl.Size;

            if (_captureCtrl.VideoDevices.Count > 0)
            {
               foreach (Device dev in _captureCtrl.VideoDevices)
               {
                  if (dev.FriendlyName == "LEAD Screen Capture (2.0)")
                     continue;

                  var menuItem2 = new MenuItem(dev.FriendlyName);
                  _optionsMenuVideoDevice.MenuItems.Add(menuItem2);
                  menuItem2.Click += new EventHandler(VideoDevice_Click);
               }
            }

            this.Controls.Add(_captureCtrl);

            ((System.ComponentModel.ISupportInitialize)(_captureCtrl)).EndInit();
         }
         catch (RasterException ex)
         {
            MessageBox.Show("Can't Initialize the Capture Control.\n\nThis Demo Uses Capture Devices to Capture Video and Recognize the Content of a Credit Card in the Video. The LEADTOOLS Multimedia SDK Needs to be Installed in Order for this Demo to Function Correctly.\n\nIf the LEADTOOLS Multimedia SDK is Not Installed, Please Install the LEADTOOLS Multimedia SDK.\n\nThis Demo will Now Exit.");
            Environment.Exit(0);
         }
      }

      private void VideoDevice_Click(object sender, System.EventArgs e)
      {
         //Point to menu item clicked
         MenuItem objCurMenuItem = (MenuItem)sender;

         foreach (MenuItem item in _optionsMenuVideoDevice.MenuItems)
         {
            if (item == objCurMenuItem)
               item.Checked = true;
            else
               item.Checked = false;
         }

         try
         {
            _captureCtrl.VideoDevices.Selection = objCurMenuItem.Index - 1;
            AddCallback(_lmvMyCallback);

            if (_captureCtrl.VideoDevices.Selection >= 0)
               _optionsMenu.MenuItems[2].Enabled = true;
            else
               _optionsMenu.MenuItems[2].Enabled = false;
         }
         catch
         {
            MessageBox.Show("This video capture device is not available. Make sure no other program is using the device or try changing the display resolution", "Error");
         }

         objCurMenuItem = null;
      }

      private void CaptureOptions_Click(object sender, EventArgs e)
      {
         _captureCtrl.ShowDialog(CaptureDlg.Capture, this);
      }

      private void FileExit_Click(object sender, EventArgs e)
      {
         _captureCtrl.StopCapture();
         // Give the threads from the Callback time to stop
         System.Threading.Thread.Sleep(500);

         this.Close();
      }

      private void AddCallback(object pCallback)
      {
         try
         {
            if (_lmvCallBkPlay == null)
            {
               foreach (Processor vp in _captureCtrl.VideoProcessors)
               {
                  if (vp.FriendlyName.Equals("LEAD Video Callback Filter (2.0)"))
                  {
                     _captureCtrl.SelectedVideoProcessors.Add(vp);
                     _lmvCallBkPlay = _captureCtrl.GetSubObject(CaptureObject.SelVideoProcessor) as ILMVCallback;
                     _lmvCallBkPlay.ReceiveProcObj = pCallback;
                  }
               }
            }
            else
            {
               _lmvCallBkPlay.ReceiveProcObj = pCallback;
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      public CaptureCtrl CaptureCtrl { get { return _captureCtrl; } }

      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("CreditCardCapture", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }
   }
}
