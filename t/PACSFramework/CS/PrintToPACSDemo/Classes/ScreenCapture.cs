// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Leadtools.ScreenCapture;
using PrintToPACSDemo.UI;
using Leadtools;
using System.IO;
using Leadtools.Demos;

namespace PrintToPACSDemo
{
   public partial class FrmMain 
   {

      private ScreenCaptureEngine _engine = null;
      private ScreenCaptureAreaOptions _areaOptions;
      private ScreenCaptureObjectOptions _objectOptions;
      private ScreenCaptureOptions _options;
      private bool _isHotKeyEnabled;
      private CaptureType _captureType;
      private ScreenCaptureInformation _captureInformation = null;

      void _engine_CaptureInformation(object sender, ScreenCaptureInformationEventArgs e)
      {
         ListImageBox.ImageCollection imagecollection = new ListImageBox.ImageCollection("Captured Image");
         Page page = new Page();
         string strTemp = null;
         page = new Page();
         strTemp = Path.GetTempFileName();
         _codec.Save(e.Image, strTemp, RasterImageFormat.Tif, 0);
         page.FilePath = strTemp;
         page.DeleteOnDispose = true;
         imagecollection.Images.Add(new ListImageBox.ImageItem(_codec.Load(strTemp), imagecollection, page));
         e.Image.Dispose();

         _lstBoxPages.AddImageCollection(imagecollection);
         _captureType = CaptureType.None;
         _engine.StopCapture();
         UpdateScreenCaptureItems();
         this.Invalidate();
      }

      private void InitializeScreenCapture()
      {
         ScreenCaptureEngine.Startup();
         // initialize Screen Capture Variables
         _engine = new ScreenCaptureEngine();
         _engine.CaptureInformation += new EventHandler<ScreenCaptureInformationEventArgs>(_engine_CaptureInformation);
         _areaOptions = ScreenCaptureEngine.DefaultCaptureAreaOptions;
         _objectOptions = ScreenCaptureEngine.DefaultCaptureObjectOptions;
         _options = _engine.CaptureOptions;
         _isHotKeyEnabled = true;
      }

      private static void FinilizeScreenCapture()
      {
         ScreenCaptureEngine.Shutdown();
      }

      private void _miCaptureOptions_Click(object sender, EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         if (_captureType != CaptureType.None)
         {
            _captureType = CaptureType.None;
            _engine.StopCapture();
            UpdateScreenCaptureItems();
         }

         try
         {
            _options = _engine.ShowCaptureOptionsDialog(this, ScreenCaptureDialogFlags.None, _options, null);
            _engine.CaptureOptions = _options;
            _isHotKeyEnabled = (_options.Hotkey == Keys.None) ? false : true;
         }
         catch (Exception ex)
         {
            if (ex.Message != "UserAbort" && ex.Message != "User has aborted operation")
               Messager.ShowError(this, ex);
         }
         logWindow.TopMost = bTopMost;
      }

      private void _miCaptureAreaOptions_Click(object sender, EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         if (_captureType != CaptureType.None)
         {
            _captureType = CaptureType.None;
            _engine.StopCapture();
            UpdateScreenCaptureItems();
         }

         try
         {
            _areaOptions = _engine.ShowCaptureAreaOptionsDialog(this, ScreenCaptureDialogFlags.None, _areaOptions, false, null);
         }
         catch (Exception ex)
         {
            if (ex.Message != "UserAbort" && ex.Message != "User has aborted operation")
               Messager.ShowError(this, ex);
         }
         logWindow.TopMost = bTopMost;
      }

      private void _miCaptureObjectOptions_Click(object sender, EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         if (_captureType != CaptureType.None)
         {
            _captureType = CaptureType.None;
            _engine.StopCapture();
            UpdateScreenCaptureItems();
         }

         try
         {
            _objectOptions = _engine.ShowCaptureObjectOptionsDialog(this, ScreenCaptureDialogFlags.None, _objectOptions, false, null);
         }
         catch (Exception ex)
         {
            if (ex.Message != "UserAbort" && ex.Message != "User has aborted operation")
               Messager.ShowError(this, ex);
         }
         logWindow.TopMost = bTopMost;
      }

      private void _miCaptureActiveWindow_Click(object sender, EventArgs e)
      {
         DoCapture(CaptureType.ActiveWindow);
      }

      private void _miCaptureFullScreen_Click(object sender, EventArgs e)
      {
         DoCapture(CaptureType.FullScreen);
      }

      private void _miCaptureSelectedObject_Click(object sender, EventArgs e)
      {
         DoCapture(CaptureType.SelectedObject);
      }

      private void _miCaptureSelectedArea_Click(object sender, EventArgs e)
      {
         DoCapture(CaptureType.Area);
      }

      private void _miCaptureStopCapture_Click(object sender, EventArgs e)
      {
         _captureType = CaptureType.None;
         _engine.StopCapture();
         UpdateScreenCaptureItems();
      }

      private void UpdateScreenCaptureItems()
      {
         _miCaptureActiveWindow.Checked = false;
         _miCaptureFullScreen.Checked = false;
         _miCaptureSelectedObject.Checked = false;
         _miCaptureSelectedArea.Checked = false;

         switch (_captureType)
         {
            case CaptureType.ActiveWindow:
               _miCaptureActiveWindow.Checked = true;
               _miCaptureStopCapture.Enabled = true;
               break;
            case CaptureType.FullScreen:
               _miCaptureFullScreen.Checked = true;
               _miCaptureStopCapture.Enabled = true;
               break;
            case CaptureType.SelectedObject:
               _miCaptureSelectedObject.Checked = true;
               _miCaptureStopCapture.Enabled = true;
               break;
            case CaptureType.Area:
               _miCaptureSelectedArea.Checked = true;
               _miCaptureStopCapture.Enabled = true;
               break;
            default:
               _miCaptureStopCapture.Enabled = false;
               break;
         }
      }

      private void DoCapture(CaptureType captureType)
      {
         if (_isHotKeyEnabled)
            if (_captureType == captureType)
            {
               UpdateScreenCaptureItems();
               return;
            }

         _mySettings._settings.capturetype = captureType;
         _mySettings.Save();
         UpdateToolBarState();
         _captureType = captureType;
         UpdateScreenCaptureItems();
         _engine.StopCapture();
         try
         {
            switch (captureType)
            {
               case CaptureType.ActiveWindow:
                  do
                  {
                     RasterImage image = null;
                     try
                     {
                        image = _engine.CaptureActiveWindow(_captureInformation);
                     }
                     catch (RasterException ex)
                     {
                        if (ex.Message == "UserAbort" || ex.Message == "User has aborted operation")
                        {
                           _captureType = CaptureType.None;
                        }
                     }
                     if (image == null)
                        _captureType = CaptureType.None;
                     else
                        _isHotKeyEnabled = false;
                     UpdateScreenCaptureItems();
                  } while ((_captureType == CaptureType.ActiveWindow) && (_isHotKeyEnabled));
                  break;

               case CaptureType.FullScreen:
                  do
                  {
                     RasterImage image = null;
                     try
                     {
                        image = _engine.CaptureFullScreen(_captureInformation);
                     }
                     catch (RasterException ex)
                     {
                        if (ex.Message == "UserAbort" || ex.Message == "User has aborted operation")
                        {
                           _captureType = CaptureType.None;
                        }
                     }
                     if (image == null)
                        _captureType = CaptureType.None;
                     UpdateScreenCaptureItems();
                  } while ((_captureType == CaptureType.FullScreen) && (_isHotKeyEnabled));
                  break;

               case CaptureType.SelectedObject:
                  do
                  {
                     RasterImage image = null;
                     try
                     {
                        image = _engine.CaptureSelectedObject(_objectOptions, _captureInformation);
                     }
                     catch (RasterException ex)
                     {
                        if (ex.Message == "UserAbort" || ex.Message == "User has aborted operation")
                        {
                           _captureType = CaptureType.None;
                        }
                     }
                     if (image == null)
                        _captureType = CaptureType.None;
                     UpdateScreenCaptureItems();
                  } while ((_captureType == CaptureType.SelectedObject) && (_isHotKeyEnabled));
                  break;

               case CaptureType.Area:
                  do
                  {
                     RasterImage image = null;
                     try
                     {
                        image = _engine.CaptureArea(_areaOptions, _captureInformation);
                     }
                     catch (RasterException ex)
                     {
                        if (ex.Message == "UserAbort" || ex.Message == "User has aborted operation")
                        {
                           _captureType = CaptureType.None;
                        }
                     }
                     if (image == null)
                        _captureType = CaptureType.None;
                     UpdateScreenCaptureItems();
                  } while ((_captureType == CaptureType.Area) && (_isHotKeyEnabled));
                  break;
            }
         }
         catch (Exception ex)
         {
            bool bTopMost = logWindow.TopMost;
            logWindow.TopMost = false;
            if (ex.Message != "NoImage" && ex.Message != "UserAbort" && ex.Message != "Invalid image" &&
               ex.Message != "User has aborted operation" && ex.Message != "No menu")
               Messager.ShowError(this, ex);
            logWindow.TopMost = bTopMost;
            _captureType = CaptureType.None;
            UpdateScreenCaptureItems();
         }
      }
   }
   public enum CaptureType
   {
      None,
      ActiveWindow,
      FullScreen,
      SelectedObject,
      Area,
   }

}
