// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Core;
using Leadtools.Controls;
using Leadtools.Twain;
using Leadtools.WinForms.CommonDialogs.Color;
using Leadtools.Wia;
using Leadtools.Drawing;
using System.Drawing.Drawing2D;

namespace MainDemo
{
   public partial class MainForm : Form
   {
      private RasterCodecs _codecs;
      private RasterColor _fillColor;
      private PrintDocument _printDocument;
      private int _currentPrintPageNumber;
      private TwainSession _twainSession;
      private bool _inTwainAcquire;
      private int _acquirePageCount;
      private WiaSession _wiaSession = null;
      private bool _wiaAcquiring;
      public WiaVersion _wiaVersion;
      public WiaAcquireOptions _wiaAcquireOptions = WiaAcquireOptions.Empty;
      public ProgressForm _progressDlg;
      private RasterPaintProperties _paintProperties;
      private bool _animateRegions;
      private PanViewerForm _panViewerForm;
      private RawData _rawdataLoad;
      private RawData _rawdataSave;
      private static readonly float _minimumScaleFactor = 0.05f;
      private static readonly float _maximumScaleFactor = 11f;
      private ImageFileSaver _saver;
      private bool _useDpi = false;
      private string _openInitialPath = string.Empty;
      public bool _addMagicWand = false;
      public int _threshold = 25;
      private bool bMRZRunMessage = true;
      private bool bMICRRunMessage = true;

      Dictionary<ImageViewer, Form> _interactiveToolsList;
      public Dictionary<ImageViewer, Form> InteractiveToolsList
      {
         get
         {
            return _interactiveToolsList;
         }
      }
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }

      public MainForm()
      {
         InitializeComponent();

         InitClass();

         _saver = new ImageFileSaver();

#if LT_CLICKONCE
         LoadDefaultImage("image2.cmp", 1, -1);
#endif // #if LT_CLICKONCE
      }

      string _ignoreVectorList = "dxf,dwg,dwf,cgm,cmx,plt,vec,drw,dgn,gbr,shp,pcl,prn,prt,vpg,mif,e00,wmz,nap,stl,3js";

      private void EnableLoadVectorFiles(RasterCodecs codecs, bool enable)
      {
         string[] ignoreList = _ignoreVectorList.Split(',');
         foreach (string flt in ignoreList)
         {
            try
            {
               var info = codecs.GetCodecInformation(flt);
               info.CheckedByInformation = enable;
               codecs.SetCodecInformation(info);
            }
            catch{ }
         }
      }

      private void EnableTextFiles(RasterCodecs codecs, bool enable)
      {
         _codecs.Options.Txt.Load.Enabled = enable;
         var info = codecs.GetCodecInformation("TXT");
         info.CheckedByInformation = enable;
         codecs.SetCodecInformation(info);
      }

      private void InitClass()
      {
         Messager.Caption = "LEADTOOLS for .NET C# Main Demo";
         Text = Messager.Caption;

         _codecs = new RasterCodecs();
         EnableLoadVectorFiles(_codecs, false);
         EnableTextFiles(_codecs, false);
         _fillColor = Converters.FromGdiPlusColor(Color.White);
         _paintProperties = RasterPaintProperties.Default;
         _paintProperties.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray;
         _paintProperties.PaintDisplayMode |= RasterPaintDisplayModeFlags.Bicubic;
         _animateRegions = false;
         _rawdataLoad = RawData.Default;
         _rawdataSave = RawData.Default;

         _menuItemPreferencesProgressBar.Checked = true;
         _interactiveToolsList = new Dictionary<ImageViewer, Form>();
         _wiaAcquiring = false;

         try
         {

            if (PrinterSettings.InstalledPrinters != null && PrinterSettings.InstalledPrinters.Count > 0)
            {
               _printDocument = new PrintDocument();
               _printDocument.BeginPrint += new PrintEventHandler(_printDocument_BeginPrint);
               _printDocument.PrintPage += new PrintPageEventHandler(_printDocument_PrintPage);
               _printDocument.EndPrint += new PrintEventHandler(_printDocument_EndPrint);
            }
            else
               _printDocument = null;
         }
         catch (Exception)
         {
            _printDocument = null;
         }


         try
         {
            using (WaitCursor wait = new WaitCursor())
            {

               if (TwainSession.IsAvailable(this.Handle))
               {
                  _twainSession = new TwainSession();

                  _twainSession.Startup(this.Handle, "LEADTOOLS", "LEADTOOLS for .NET", String.Empty, Messager.Caption, TwainStartupFlags.None);

                  _twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(_twainSession_AcquirePage);
               }
            }
         }
         catch (TwainException ex)
         {
            if (ex.Code == TwainExceptionCode.InvalidDll)
            {
               _twainSession = null;
               Messager.ShowError(this, DemosGlobalization.GetResxString(GetType(), "Resx_OldTWAINVersion"));
            }
            else
            {
               _twainSession = null;
               Messager.ShowError(this, ex);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            _twainSession = null;
         }

         _panViewerForm = new PanViewerForm();
         _panViewerForm.Owner = this;

         UpdateControls();
      }

      private void CleanUp()
      {
         if (_twainSession != null)
         {
            try
            {
               _twainSession.Shutdown();
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      public ViewerForm ActiveViewerForm
      {
         get
         {
            return ActiveMdiChild as ViewerForm;
         }
      }

      public void UpdateControls()
      {
         ViewerForm activeForm = ActiveViewerForm;

         EnableAndVisibleMenu(_menuItemFileSave, activeForm != null);
         EnableAndVisibleMenu(_menuItemFileSaveRaw, activeForm != null);
         EnableAndVisibleMenu(_menuItemFilePrint, _printDocument != null && activeForm != null);
         EnableAndVisibleMenu(_menuItemFilePrintPreview, _printDocument != null && activeForm != null && DialogUtilities.CanRunPrintPreview);
         _menuItemFileSep4.Visible = (_printDocument != null && activeForm != null);
         _menuItemFileSep2.Visible = _twainSession != null;
         EnableAndVisibleMenu(_menuItemFileTwainSelectSource, _twainSession != null);
         EnableAndVisibleMenu(_menuItemFileTwainAcquire, _twainSession != null);
         _menuItemFileWiaAcquire.Enabled = (!_wiaAcquiring);
         EnableAndVisibleMenu(_menuItemEditCut, (activeForm != null) && (activeForm.Viewer.Floater != null) && (activeForm.Viewer.FloaterOpacity > 0.0));
         EnableAndVisibleMenu(_menuItemEditCopy, activeForm != null);
         EnableAndVisibleMenu(_menuItemEditCombine, activeForm != null && activeForm.Viewer.Floater != null && (activeForm.Viewer.FloaterOpacity > 0.0));
         _menuItemEditSep1.Visible = _menuItemEditCombine.Visible;
         EnableAndVisibleMenu(_menuItemEditRegion, activeForm != null);
         _menuItemEditSep2.Visible = _menuItemEditRegion.Visible;
         EnableAndVisibleMenu(_menuItemEditCancelRegion, activeForm != null && activeForm.Viewer.Floater != null && (activeForm.Viewer.FloaterOpacity > 0.0));
         _menuItemPreferencesInitAlpha.Checked = _codecs.Options.Load.InitAlpha;

         EnableAndVisibleMenu(_menuItemImage, activeForm != null);
         EnableAndVisibleMenu(_menuItemPage, activeForm != null);
         EnableAndVisibleMenu(_menuItemView, activeForm != null);
         EnableAndVisibleMenu(_menuItemColor, activeForm != null);
         EnableAndVisibleMenu(_menuItemSegmentation, activeForm != null);
         EnableAndVisibleMenu(_menuItemDetection, activeForm != null);

         EnableAndVisibleMenu(_menuItemEffects, activeForm != null);
         EnableAndVisibleMenu(_menuItemWindow, activeForm != null && MdiChildren.Length > 0);
         EnableAndVisibleMenu(_menuItemColorWindowLevel, (activeForm != null) &&
                                                         ((activeForm.Image.BitsPerPixel == 12 || activeForm.Image.BitsPerPixel == 16) && activeForm.Image.GrayscaleMode != RasterGrayscaleMode.None));

         if (activeForm != null)
         {
            EnableAndVisibleMenu(_menuItemPageFirst, activeForm.Image.PageCount > 1);
            EnableAndVisibleMenu(_menuItemPagePrevious, activeForm.Image.PageCount > 1);
            EnableAndVisibleMenu(_menuItemPageNext, activeForm.Image.PageCount > 1);
            EnableAndVisibleMenu(_menuItemPageLast, activeForm.Image.PageCount > 1);
            _menuItemPageSep1.Visible = activeForm.Image.PageCount > 1;
            EnableAndVisibleMenu(_menuItemPageDeleteCurrentPage, activeForm.Image.PageCount > 1);

            if (activeForm.Image.PageCount > 1)
            {
               _menuItemPageFirst.Enabled = activeForm.Image.Page > 1;
               _menuItemPagePrevious.Enabled = activeForm.Image.Page > 1;
               _menuItemPageNext.Enabled = activeForm.Image.Page != activeForm.Image.PageCount;
               _menuItemPageLast.Enabled = activeForm.Image.Page != activeForm.Image.PageCount;
            }

            _menuItemViewSizeModeNormal.Checked = activeForm.Viewer.SizeMode == ControlSizeMode.ActualSize;
            _menuItemViewSizeModeStretch.Checked = activeForm.Viewer.SizeMode == ControlSizeMode.Stretch;
            _menuItemViewSizeModeFitAlways.Checked = activeForm.Viewer.SizeMode == ControlSizeMode.FitAlways;
            _menuItemViewSizeModeFitWidth.Checked = activeForm.Viewer.SizeMode == ControlSizeMode.FitWidth;
            _menuItemViewSizeModeFit.Checked = activeForm.Viewer.SizeMode == ControlSizeMode.Fit;

            _menuItemViewAlignModeHorizontalNear.Checked = activeForm.Viewer.ViewHorizontalAlignment == ControlAlignment.Near;
            _menuItemViewAlignModeHorizontalCenter.Checked = activeForm.Viewer.ViewHorizontalAlignment == ControlAlignment.Center;
            _menuItemViewAlignModeHorizontalFar.Checked = activeForm.Viewer.ViewHorizontalAlignment == ControlAlignment.Far;

            _menuItemViewAlignModeVerticalNear.Checked = activeForm.Viewer.ViewVerticalAlignment == ControlAlignment.Near;
            _menuItemViewAlignModeVerticalCenter.Checked = activeForm.Viewer.ViewVerticalAlignment == ControlAlignment.Center;
            _menuItemViewAlignModeVerticalFar.Checked = activeForm.Viewer.ViewVerticalAlignment == ControlAlignment.Far;

            _menuItemViewPalette.Enabled = activeForm.Image.BitsPerPixel <= 8;
            _menuItemViewPaddingFrame.Checked = activeForm.Viewer.ViewBorderThickness != 0;
            _menuItemViewPaddingFrameShadow.Checked = activeForm.Viewer.ViewDropShadow.IsVisible;
            _menuItemViewPaddingBorder.Checked = activeForm.Viewer.ViewMargin.All != 0;

            _menuItemViewInteractiveNone.Checked = activeForm.Viewer.DefaultInteractiveMode is ImageViewerNoneInteractiveMode || activeForm.Viewer.DefaultInteractiveMode is ImageViewerFloaterInteractiveMode;

            if (activeForm.PanInteractiveMode.IsEnabled)
            _menuItemViewInteractivePan.Checked = activeForm.Viewer.DefaultInteractiveMode is ImageViewerPanZoomInteractiveMode;
            else
               _menuItemViewInteractivePan.Checked = false;
            _menuItemViewInteractiveCenterAt.Checked = activeForm.Viewer.DefaultInteractiveMode is ImageViewerCenterAtInteractiveMode;
            _menuItemViewInteractiveZoomTo.Checked = activeForm.Viewer.DefaultInteractiveMode is ImageViewerZoomToInteractiveMode;

            if (activeForm.ScaleInteractiveMode.IsEnabled)
               _menuItemViewInteractiveScale.Checked = activeForm.Viewer.DefaultInteractiveMode is ImageViewerPanZoomInteractiveMode;
            else
               _menuItemViewInteractiveScale.Checked = false;
            _menuItemViewInteractivePage.Checked = activeForm.Viewer.DefaultInteractiveMode is ImageViewerPagerInteractiveMode;
            _menuItemViewInteractiveMagnifyGlass.Checked = activeForm.Viewer.DefaultInteractiveMode is ImageViewerMagnifyGlassInteractiveMode;

            if (_addMagicWand)
            {
               _menuItemEditRegionMagicWand.Checked = _addMagicWand;
               _menuItemEditRegionRectangle.Checked = false;
               _menuItemEditRegionEllipse.Checked = false;
               _menuItemEditRegionFreehand.Checked = false;
            }
            else
            {
               _menuItemEditRegionRectangle.Checked = activeForm.RegionInteractiveMode.IsEnabled && activeForm.RegionInteractiveMode.Shape == ImageViewerRubberBandShape.Rectangle;
               _menuItemEditRegionEllipse.Checked = activeForm.RegionInteractiveMode.IsEnabled && activeForm.RegionInteractiveMode.Shape == ImageViewerRubberBandShape.Ellipse;
               _menuItemEditRegionFreehand.Checked = activeForm.RegionInteractiveMode.IsEnabled && activeForm.RegionInteractiveMode.Shape == ImageViewerRubberBandShape.Freehand;
               _menuItemEditRegionMagicWand.Checked = false;
            }

            _menuItemEditRegionNone.Enabled = activeForm.Viewer.Image.HasRegion || (activeForm.Viewer.Floater != null && (activeForm.Viewer.FloaterOpacity > 0.0));

            _menuItemViewInteractivePanWindow.Checked = _panViewerForm.Visible;

            _menuItemColorAdjustBalanceColors.Enabled = activeForm.Viewer.Image.GrayscaleMode == RasterGrayscaleMode.None;

            _menuItemViewPaint.Enabled = (_paintProperties.PaintEngine == RasterPaintEngine.Gdi);

            EnableAndVisibleMenu(_menuItemEffectsTextureUnderlay, (activeForm != null) && ((activeForm.Image.BitsPerPixel == 8 || activeForm.Image.GrayscaleMode == RasterGrayscaleMode.None)));
            EnableAndVisibleMenu(_menuItemEffectsTexture, (activeForm != null) && ((activeForm.Image.BitsPerPixel == 8 || activeForm.Image.GrayscaleMode == RasterGrayscaleMode.None)));

            EnableAndVisibleMenu(_menuItemColorAutoBinarize, (activeForm != null) && ((activeForm.Image.BitsPerPixel == 8 || activeForm.Image.GrayscaleMode == RasterGrayscaleMode.None)));
            _menuItemEffectsNoiseSaltPepper.Enabled = activeForm.Viewer.Image.BitsPerPixel == 8;
            _menuItemColorMatchHistogram.Enabled = activeForm.Viewer.Image.BitsPerPixel == 8 || activeForm.Viewer.Image.BitsPerPixel == 24;

            _menuItemImageBlankPageDetection.Enabled = activeForm.Viewer.Image.BitsPerPixel != 12 && activeForm.Viewer.Image.BitsPerPixel != 16 && activeForm.Viewer.Image.BitsPerPixel != 48 && activeForm.Viewer.Image.BitsPerPixel != 64;
         }
      }

      private void EnableAndVisibleMenu(ToolStripMenuItem menu, bool value)
      {
         menu.Enabled = value;
         menu.Visible = value;
      }

      private void EnableMenu(ToolStripMenuItem menu, bool value)
      {
         menu.Enabled = value;
      }

      private void _menuItemFileOpen_Click(object sender, EventArgs e)
      {
         try
         {
            List<ImageInformation> imagesInfo = LoadImage(true);
            if (imagesInfo != null)
            {
               foreach (ImageInformation info in imagesInfo)
               {
                  if (info != null)
                     NewImage(info);
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _menuItemFileSave_Click(object sender, EventArgs e)
      {
         try
         {
            CombineFloater();
            DemosGlobal.SetDefaultComments(ActiveViewerForm.Viewer.Image, _codecs);
            _saver.FileName = Path.GetFileNameWithoutExtension(ActiveViewerForm.FileName);
            _saver.Save(this, _codecs, ActiveViewerForm.Viewer.Image);
         }
         catch (Exception ex)
         {
            Messager.ShowFileSaveError(this, _saver.FileName, ex);
         }
      }

      private void _menuItemFileTwainSelectSource_Click(object sender, EventArgs e)
      {


         _inTwainAcquire = true;
         try
         {
            if (_twainSession != null)
               _twainSession.SelectSource(null);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         _inTwainAcquire = false;

      }

      private void _menuItemFileTwainAcquire_Click(object sender, EventArgs e)
      {

         _inTwainAcquire = true;
         _acquirePageCount = 1;

         try
         {
            if (_twainSession != null)
            {
               if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, _twainSession.SelectedSourceName()))
                  return;

               DialogResult res = _twainSession.Acquire(TwainUserInterfaceFlags.Modal | TwainUserInterfaceFlags.Show);
            }
         }
         catch (Exception ex)
         {
            if (ex is TwainException)
            {
               TwainException twnEx = ex as TwainException;
               if (twnEx.Code != TwainExceptionCode.OperationError)
                  Messager.ShowError(this, ex);
            }
            else
               Messager.ShowError(this, ex);
         }
         finally
         {
            _acquirePageCount = -1;
            _inTwainAcquire = false;
         }
      }

      private void _menuItemFilePrint_Click(object sender, EventArgs e)
      {
         if (_printDocument != null)
         {
            try
            {
               RasterImage image = ActiveViewerForm.Viewer.Image;
               _printDocument.PrinterSettings.MinimumPage = 1;
               _printDocument.PrinterSettings.MaximumPage = image.PageCount;
               _printDocument.PrinterSettings.FromPage = 1;
               _printDocument.PrinterSettings.ToPage = image.PageCount;

               _printDocument.Print();
            }
            catch { }
         }
      }

      private void _menuItemFilePrintPreview_Click(object sender, EventArgs e)
      {
         if (_printDocument != null)
         {
            try
            {
               using (PrintPreviewDialog dlg = new PrintPreviewDialog())
               {
                  RasterImage image = ActiveViewerForm.Viewer.Image;
                  _printDocument.PrinterSettings.MinimumPage = 1;
                  _printDocument.PrinterSettings.MaximumPage = image.PageCount;
                  _printDocument.PrinterSettings.FromPage = 1;
                  _printDocument.PrinterSettings.ToPage = image.PageCount;

                  dlg.Document = _printDocument;
                  dlg.WindowState = FormWindowState.Maximized;
                  dlg.ShowDialog(this);
               }
            }
            catch { }
         }
      }

      private void _menuItemFileExit_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void MainForm_MdiChildActivate(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;

         if (activeForm != null)
            _panViewerForm.SetViewer(activeForm.Viewer);
         else
            _panViewerForm.SetViewer(null);

         UpdateControls();
      }

      void _menuItemEdit_DropDownOpened(object sender, EventArgs e)
      {
         _menuItemEditPaste.Enabled = RasterClipboard.IsReady;
      }

      private void _menuItemEditCut_Click(object sender, EventArgs e)
      {
         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               RasterClipboard.Copy(
                  this.Handle,
                  ImageToRun,
                  RasterClipboardCopyFlags.Empty |
                  RasterClipboardCopyFlags.Dib |
                  RasterClipboardCopyFlags.Palette |
                  RasterClipboardCopyFlags.Region);

               ViewerForm activeForm = ActiveViewerForm;

               if ((activeForm.Viewer.Floater != null) && (activeForm.Viewer.FloaterOpacity > 0.0))
                  activeForm.Viewer.Floater = null;

               activeForm.Viewer.Invalidate(true);  
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _menuItemEditCopy_Click(object sender, EventArgs e)
      {
         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               RasterClipboard.Copy(
                  this.Handle,
                  ImageToRun,
                  RasterClipboardCopyFlags.Empty |
                  RasterClipboardCopyFlags.Dib |
                  RasterClipboardCopyFlags.Palette |
                  RasterClipboardCopyFlags.Region);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _menuItemEditPaste_Click(object sender, EventArgs e)
      {
         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               RasterImage image = RasterClipboard.Paste(this.Handle);
               if (image != null)
               {
                  ViewerForm activeForm = ActiveViewerForm;

                  if (image.HasRegion && activeForm == null)
                     image.MakeRegionEmpty();

                  if (image.HasRegion)
                  {
                     CombineFloater();
                     // make sure the images have the same BitsPerPixel and Palette
                     if (activeForm.Viewer.Image.BitsPerPixel > 8)
                     {
                        if (image.BitsPerPixel != activeForm.Viewer.Image.BitsPerPixel)
                        {
                           try
                           {
                              ColorResolutionCommand colorRes = new ColorResolutionCommand();
                              colorRes.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel;
                              colorRes.Order = activeForm.Viewer.Image.Order;
                              colorRes.Mode = ColorResolutionCommandMode.InPlace;
                              colorRes.Run(image);
                           }
                           catch (Exception ex)
                           {
                              Messager.ShowError(this, ex);
                           }
                        }
                     }
                     else
                     {
                        try
                        {
                           ColorResolutionCommand colorRes = new ColorResolutionCommand();
                           colorRes.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel;
                           colorRes.SetPalette(activeForm.Viewer.Image.GetPalette());
                           colorRes.PaletteFlags = ColorResolutionCommandPaletteFlags.UsePalette;
                           colorRes.Mode = ColorResolutionCommandMode.InPlace;
                           colorRes.Run(image);
                        }
                        catch (Exception ex)
                        {
                           Messager.ShowError(this, ex);
                        }
                     }
                     activeForm.Viewer.Floater = image;
                     activeForm.Viewer.FloaterOpacity = 1.0;
                     LeadMatrix MyMatrix = activeForm.Viewer.ImageTransform;
                     Matrix m = new Matrix((float)MyMatrix.M11, (float)MyMatrix.M12, (float)MyMatrix.M21, (float)MyMatrix.M22, (float)MyMatrix.OffsetX, (float)MyMatrix.OffsetY);
                     Transformer t = new Transformer(m);

                     Point FloaterPosition = new Point((int)activeForm.Viewer.FloaterTransform.OffsetX, (int)activeForm.Viewer.FloaterTransform.OffsetY);

                     LeadMatrix floatertransform = activeForm.Viewer.FloaterTransform;
                     floatertransform.OffsetX = Point.Round(t.PointToLogical(Point.Empty)).X;
                     floatertransform.OffsetY = Point.Round(t.PointToLogical(Point.Empty)).Y;
                     activeForm.Viewer.FloaterTransform = floatertransform;

                     DisableAllInteractiveModes(activeForm.Viewer);
                     activeForm.Viewer.InteractiveModes.BeginUpdate();
                     activeForm.FloaterInteractiveMode.IsEnabled = true;
                     activeForm.Viewer.InteractiveModes.EndUpdate();
                  }
                  else
                     NewImage(new ImageInformation(image));
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void CancelFloater()
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;

            if (activeForm.Viewer.Floater != null)
            {
               activeForm.Viewer.Floater.Dispose();
               activeForm.Viewer.Floater = null;
               activeForm.Viewer.Invalidate(true);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _menuItemEditCombine_Click(object sender, EventArgs e)
      {
         try
         {
            CombineFloater();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _menuItemImageInformation_Click(object sender, EventArgs e)
      {
         ImageInformationDialog dlg = new ImageInformationDialog();
         dlg.Image = ActiveViewerForm.Image;
         dlg.ShowDialog(this);
      }

      private void _menuItemImageUnderlay_Click(object sender, EventArgs e)
      {
         try
         {
            List<ImageInformation> imagesInfo = LoadImage(false);
            if (imagesInfo != null && imagesInfo.Count > 0 && imagesInfo[0] != null)
            {
               UnderlayDialog dlg = new UnderlayDialog();
               if (dlg.ShowDialog(this) == DialogResult.OK)
               {
                  using (WaitCursor wait = new WaitCursor())
                  {
                     ViewerForm activeForm = ActiveViewerForm;

                     if ((activeForm.Viewer.FloaterOpacity > 0.0) && (activeForm.Viewer.Floater != null))
                        activeForm.Viewer.Floater.Underlay(imagesInfo[0].Image, dlg.Flags);
                     else
                        activeForm.Viewer.Image.Underlay(imagesInfo[0].Image, dlg.Flags);
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _menuItemViewInteractive_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;
         DisableAllInteractiveModes(activeForm.Viewer);

         activeForm.Viewer.InteractiveModes.BeginUpdate();

         if (sender == _menuItemViewInteractiveNone)
         {
            if ((activeForm.Viewer.Floater != null) && (activeForm.Viewer.FloaterOpacity > 0.0))
            {
               activeForm.FloaterInteractiveMode.IsEnabled = true;
            }
            else
            {
               activeForm.NoneInteractiveMode.IsEnabled = true;
            }
         }
         else if (sender == _menuItemViewInteractivePan)
         {
            activeForm.PanInteractiveMode.IsEnabled = true;
         }
         else if (sender == _menuItemViewInteractiveCenterAt)
         {
            activeForm.CenterAtInteractiveMode.IsEnabled = true;
         }
         else if (sender == _menuItemViewInteractiveZoomTo)
         {
            activeForm.ZoomToInteractiveMode.IsEnabled = true;
         }
         else if (sender == _menuItemViewInteractiveScale)
         {
            activeForm.ScaleInteractiveMode.IsEnabled = true;
         }
         else if (sender == _menuItemViewInteractivePage)
         {
            CancelFloater();
            activeForm.PagerInteractiveMode.IsEnabled = true;
         }
         else if (sender == _menuItemViewInteractiveMagnifyGlass)
         {
            CancelFloater();
            DisableAllInteractiveModes(activeForm.Viewer);
            activeForm.MagnifyGlassInteractiveMode.IsEnabled = true;
         }

         activeForm.Viewer.InteractiveModes.EndUpdate();

         UpdateControls();
      }

      private void _menuItemViewInteractivePanWindow_Click(object sender, EventArgs e)
      {
         _panViewerForm.Visible = !_panViewerForm.Visible;
         UpdateControls();
      }

      private void _menuItemPage_Click(object sender, EventArgs e)
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;

            if (activeForm.Viewer.Image.HasRegion)
               activeForm.Viewer.Image.MakeRegionEmpty();
            if (activeForm.Viewer.Floater != null)
            {
               activeForm.Viewer.Floater.Dispose();
               activeForm.Viewer.Floater = null;
            }

            if (sender == _menuItemPageFirst)
               activeForm.Image.Page = 1;
            else if (sender == _menuItemPagePrevious)
               activeForm.Image.Page--;
            else if (sender == _menuItemPageNext)
               activeForm.Image.Page++;
            else if (sender == _menuItemPageLast)
               activeForm.Image.Page = activeForm.Image.PageCount;
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _menuItemPageAdd_Click(object sender, EventArgs e)
      {
         try
         {
            List<ImageInformation> imagesInfo = LoadImage(false);
            if (imagesInfo != null && imagesInfo[0] != null)
               ActiveViewerForm.Image.AddPages(imagesInfo[0].Image, 1, imagesInfo[0].Image.PageCount);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _menuItemPageDeleteCurrentPage_Click(object sender, EventArgs e)
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;

            activeForm.Image.RemovePageAt(activeForm.Image.Page);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }


      private void _menuItemViewSizeMode_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;

         if (sender == _menuItemViewSizeModeNormal)
         {
            activeForm.Viewer.Zoom(ControlSizeMode.ActualSize, 1, activeForm.Viewer.DefaultZoomOrigin);
         }
         else if (sender == _menuItemViewSizeModeSnap)
         {
            activeForm.Snap();
            if (activeForm.WindowState != FormWindowState.Normal)
               activeForm.WindowState = FormWindowState.Normal;
         }
         else
         {
            activeForm.Viewer.BeginUpdate();
            if (sender == _menuItemViewSizeModeStretch)
               activeForm.Viewer.Zoom(ControlSizeMode.Stretch, 1, activeForm.Viewer.DefaultZoomOrigin);
            else if (sender == _menuItemViewSizeModeFitAlways)
               activeForm.Viewer.Zoom(ControlSizeMode.FitAlways, 1, activeForm.Viewer.DefaultZoomOrigin);
            else if (sender == _menuItemViewSizeModeFitWidth)
               activeForm.Viewer.Zoom(ControlSizeMode.FitWidth, 1, activeForm.Viewer.DefaultZoomOrigin);
            else if (sender == _menuItemViewSizeModeFit)
               activeForm.Viewer.Zoom(ControlSizeMode.Fit, 1, activeForm.Viewer.DefaultZoomOrigin);
            activeForm.Viewer.EndUpdate();
         }

         UpdateControls();

         //Set the DoubleTapSizeMode property for all ImageViewerPanZoomInteractiveModes to use the current size mode of the image viewer control
         activeForm.Viewer.InteractiveModes.BeginUpdate(); 
         foreach (ImageViewerInteractiveMode mode in activeForm.Viewer.InteractiveModes)
         {
            if(mode is ImageViewerPanZoomInteractiveMode)
            {
               ((ImageViewerPanZoomInteractiveMode)mode).DoubleTapSizeMode = activeForm.Viewer.SizeMode;
            }
         }         
         activeForm.Viewer.InteractiveModes.EndUpdate();
      }

      private void _menuItemViewAlignMode_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;

         if (sender == _menuItemViewAlignModeHorizontalNear)
            activeForm.Viewer.ImageHorizontalAlignment = ControlAlignment.Near;
         else if (sender == _menuItemViewAlignModeHorizontalCenter)
            activeForm.Viewer.ImageHorizontalAlignment = ControlAlignment.Center;
         else if (sender == _menuItemViewAlignModeHorizontalFar)
            activeForm.Viewer.ImageHorizontalAlignment = ControlAlignment.Far;
         else if (sender == _menuItemViewAlignModeVerticalNear)
            activeForm.Viewer.ImageVerticalAlignment = ControlAlignment.Near;
         else if (sender == _menuItemViewAlignModeVerticalCenter)
            activeForm.Viewer.ImageVerticalAlignment = ControlAlignment.Center;
         else if (sender == _menuItemViewAlignModeVerticalFar)
            activeForm.Viewer.ImageVerticalAlignment = ControlAlignment.Far;
         UpdateControls();
      }

      public void Zoom(bool zoomIn)
      {
         if (zoomIn)
            _menuItemViewZoomIn.PerformClick();
         else
            _menuItemViewZoomOut.PerformClick();
      }

      private void _menuItemViewZoom_Click(object sender, EventArgs e)
      {
         // get the current center in logical units
         ImageViewer viewer = ActiveViewerForm.Viewer; // get the active viewer
         LeadRect LeadPhysicalRect = viewer.ViewBounds;
         LeadRect LeadLogicalRect = viewer.ImageBounds;
         Rectangle PhysicalRect = new Rectangle(LeadPhysicalRect.X, LeadPhysicalRect.Y, LeadPhysicalRect.Width, LeadPhysicalRect.Height);
         Rectangle LogicalRect = new Rectangle(LeadLogicalRect.X, LeadLogicalRect.Y, LeadLogicalRect.Width, LeadLogicalRect.Height);
         Rectangle rc = Rectangle.Intersect(PhysicalRect, LogicalRect); // get what you see in physical coordinates
         PointF center = new PointF(rc.Left + rc.Width / 2, rc.Top + rc.Height / 2); // get the center of what you see in physical coordinates
         LeadMatrix MyMatrix = viewer.ImageTransform;
         Matrix m = new Matrix((float)MyMatrix.M11, (float)MyMatrix.M12, (float)MyMatrix.M21, (float)MyMatrix.M22, (float)MyMatrix.OffsetX, (float)MyMatrix.OffsetY);
         Transformer t = new Transformer(m);
         center = t.PointToLogical(center);  // get the center of what you see in logical coordinates

         // zoom     
         double scaleFactor = viewer.ScaleFactor;

         const float ratio = 1.2F;

         if (sender == _menuItemViewZoomIn)
         {
            scaleFactor *= ratio;
         }
         else if (sender == _menuItemViewZoomOut)
         {
            scaleFactor /= ratio;
         }
         else if (sender == _menuItemViewZoomNormal)
         {
            scaleFactor = 1;
            if (viewer.SizeMode != ControlSizeMode.ActualSize)
               viewer.Zoom(ControlSizeMode.ActualSize, 1, viewer.DefaultZoomOrigin);
         }
         else
         {
            ZoomDialog dlg = new ZoomDialog();
            dlg.Value = (int)(scaleFactor * 100);
            dlg.MinimumValue = (int)(_minimumScaleFactor * 100F);
            dlg.MaximumValue = (int)(_maximumScaleFactor * 100F);

            if (dlg.ShowDialog(this) == DialogResult.OK)
               scaleFactor = (float)dlg.Value / 100f;
         }

         scaleFactor = Math.Max(_minimumScaleFactor, Math.Min(_maximumScaleFactor, scaleFactor));

         if (viewer.ScaleFactor != scaleFactor)
         {
            viewer.Zoom(ControlSizeMode.None, scaleFactor, viewer.DefaultZoomOrigin);

            // bring the original center into the view center
            MyMatrix = viewer.ImageTransform;
            m = new Matrix((float)MyMatrix.M11, (float)MyMatrix.M12, (float)MyMatrix.M21, (float)MyMatrix.M22, (float)MyMatrix.OffsetX, (float)MyMatrix.OffsetY);
            t = new Transformer(m);
            center = t.PointToPhysical(center); // get the center of what you saw before the zoom in physical coordinates
            LeadPoint LeadCenter = new LeadPoint((int)center.X, (int)center.Y);
            viewer.CenterAtPoint(LeadCenter); // bring the old center into the center of the view
         }
      }

      private void _menuItemViewPadding_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;

         if (sender == _menuItemViewPaddingFrame)
         {
            activeForm.Viewer.ViewBorderThickness = activeForm.Viewer.ViewBorderThickness == 0 ? 1 : 0;
         }
         else if (sender == _menuItemViewPaddingFrameShadow)
         {
            ControlDropShadowOptions dropShadow = activeForm.Viewer.ViewDropShadow;
            dropShadow.IsVisible = !dropShadow.IsVisible;
            activeForm.Viewer.ViewDropShadow = dropShadow;
         }
         else if (sender == _menuItemViewPaddingBorder)
         {
            var currentpadding = activeForm.Viewer.ViewMargin;
            currentpadding.All = currentpadding.All == 0 ? 10 : 0;
            activeForm.Viewer.ViewMargin = currentpadding;
         }

         UpdateControls();
      }

      private void _menuItemViewPalette_Click(object sender, EventArgs e)
      {
         PaletteDialog dlg = new PaletteDialog();
         dlg.Palette = ActiveViewerForm.Image.GetPalette();
         dlg.ShowDialog(this);
      }

      private void _menuItemViewPaint_Click(object sender, EventArgs e)
      {
         ValueDialog dlg = null;

         ViewerForm activeForm = ActiveViewerForm;

         if (sender == _menuItemViewPaintIntensity)
         {
            dlg = new ValueDialog(ValueDialog.TypeConstants.PaintIntensity);
            dlg.Value = dlg.Value = activeForm.Viewer.Image.PaintIntensity;
         }
         else if (sender == _menuItemViewPaintContrast)
         {
            dlg = new ValueDialog(ValueDialog.TypeConstants.PaintContrast);
            dlg.Value = dlg.Value = activeForm.Viewer.Image.PaintContrast;
         }
         else if (sender == _menuItemViewPaintGamma)
         {
            dlg = new ValueDialog(ValueDialog.TypeConstants.PaintGamma);
            dlg.Value = dlg.Value = activeForm.Viewer.Image.PaintGamma;
         }

         if (dlg != null && dlg.ShowDialog(this) == DialogResult.OK)
         {
            if (sender == _menuItemViewPaintIntensity)
               activeForm.Viewer.Image.PaintIntensity = dlg.Value;
            else if (sender == _menuItemViewPaintContrast)
               activeForm.Viewer.Image.PaintContrast = dlg.Value;
            else if (sender == _menuItemViewPaintGamma)
               activeForm.Viewer.Image.PaintGamma = dlg.Value;

            SetFloaterPaintValues();
         }
      }

      public void SetFloaterPaintValues()
      {
         ViewerForm activeForm = ActiveViewerForm;
         if (activeForm != null)
         {
            if ((activeForm.Viewer.Floater != null) && (activeForm.Viewer.FloaterOpacity > 0.0))
            {
               activeForm.Viewer.Floater.PaintIntensity = activeForm.Viewer.Image.PaintIntensity;
               activeForm.Viewer.Floater.PaintContrast = activeForm.Viewer.Image.PaintContrast;
               activeForm.Viewer.Floater.PaintGamma = activeForm.Viewer.Image.PaintGamma;
            }
         }
      }

      private void _menuItemPreferencesPaintProperties_Click(object sender, EventArgs e)
      {
         PaintPropertiesDialog dlg = new PaintPropertiesDialog();
         dlg.PaintProperties = _paintProperties;
         dlg.Apply += new EventHandler(PaintPropertiesDialog_Apply);
         dlg.ShowDialog(this);
         UpdateControls();
      }

      private void PaintPropertiesDialog_Apply(object sender, EventArgs e)
      {
         PaintPropertiesDialog dlg = sender as PaintPropertiesDialog;
         _paintProperties = dlg.PaintProperties;
         foreach (ViewerForm i in MdiChildren)
            i.UpdatePaintProperties(_paintProperties);
         UpdateControls();
      }

      private void _menuItemPreferencesAnimateRegions_Click(object sender, EventArgs e)
      {
         _animateRegions = !_animateRegions;
         _menuItemPreferencesAnimateRegions.Checked = _animateRegions;

         foreach (ViewerForm i in MdiChildren)
            i.UpdateAnimateRegions(_animateRegions);
      }

      private void _menuItemImageFastFlip_Click(object sender, EventArgs e)
      {
         try
         {
            ImageToRun.FlipViewPerspective(sender == _menuItemImageFastFlipHorizontal);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _menuItemImageFastRotate_Click(object sender, EventArgs e)
      {
         int degrees;
         if (sender == _menuItemImageRotateFast180)
            degrees = 180;
         else if (sender == _menuItemImageRotateFast270)
            degrees = 270;
         else
            degrees = 90;

         try
         {
            ViewerForm activeForm = ActiveViewerForm;
            ControlRegionRenderMode saveMode = activeForm.Viewer.FloaterRegionRenderMode;
            activeForm.Viewer.FloaterRegionRenderMode = ControlRegionRenderMode.None;

            ImageToRun.RotateViewPerspective(degrees);

            activeForm.Viewer.FloaterRegionRenderMode = saveMode;
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _menuItemEditRegion_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;

         _addMagicWand = false;


         DisableAllInteractiveModes(activeForm.Viewer);

         activeForm.Viewer.InteractiveModes.BeginUpdate();

         if (sender == _menuItemEditRegionRectangle)
         {
            activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle;
            activeForm.RegionInteractiveMode.IsEnabled = true;
         }
         else if (sender == _menuItemEditRegionEllipse)
         {
            activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Ellipse;
            activeForm.RegionInteractiveMode.IsEnabled = true;
         }
         else if (sender == _menuItemEditRegionFreehand)
         {
            activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Freehand;
            activeForm.RegionInteractiveMode.IsEnabled = true;
         }

         else if (sender == _menuItemEditRegionMagicWand)
         {
            _addMagicWand = true;
            activeForm.AddMagicWandInteractivMode.IsEnabled = true;

            MagicWandThresholdDialog dlg = new MagicWandThresholdDialog();
            dlg.Value = _threshold;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _threshold = dlg.Value;
               activeForm.AddMagicWandInteractivMode.Threshold = _threshold;
            }

         }

         activeForm.Viewer.InteractiveModes.EndUpdate();

         UpdateControls();
      }

      private void _menuItemEditRegionNone_Click(object sender, EventArgs e)
      {
         CombineFloater();

         UpdateControls();
      }

      private void _menuItemEditCancelRegion_Click(object sender, EventArgs e)
      {
         CancelFloater();

         UpdateControls();
      }

      private void _menuItemFormat_Click(object sender, EventArgs e)
      {
         RasterCommand command = null;

         if (sender == _menuItemColorTransformColorResolution)
         {
            ViewerForm activeForm = ActiveViewerForm;
            ColorResolutionDialog dlg = new ColorResolutionDialog(activeForm.Viewer.Image, _paintProperties);
            dlg.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel;
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace, dlg.BitsPerPixel, dlg.Order, dlg.DitheringMethod, dlg.PaletteFlags, null);
         }
         else if (sender == _menuItemColorTransformHalftone)
         {
            HalftoneDialog dlg = new HalftoneDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new HalfToneCommand(dlg.Type, dlg.Angle, dlg.Dimension, null);
         }
         else if (sender == _menuItemColorGrayScale)
         {
            GrayScaleDialog dlg = new GrayScaleDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new GrayscaleCommand(dlg.BitsPerPixel);
         }
         else if (sender == _menuItemColorTransformGrayScaleFactor)
         {
            GrayScaleFactorDialog dlg = new GrayScaleFactorDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new GrayScaleExtendedCommand(dlg.RedFactor, dlg.GreenFactor, dlg.BlueFactor);
         }

         if (command != null)
            RunCommand(command);
      }

      private void _menuItemImage_Click(object sender, EventArgs e)
      {
         RasterCommand command = null;
         ViewerForm activeForm = ActiveViewerForm;

         if (sender == _menuItemImageAutoTrim)
         {
            ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.AutoCrop);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new AutoCropCommand(dlg.Value);
         }
         else if (sender == _menuItemImageTrim)
         {
            if ((activeForm.Viewer.Floater != null) && (activeForm.Viewer.FloaterOpacity > 0.0))
            {
               RasterImage floater = activeForm.Viewer.Floater;
               RasterImage image = activeForm.Viewer.Image;
               activeForm.Viewer.AutoDisposeImages = false;
               activeForm.Viewer.Image = floater;
               activeForm.Viewer.Floater = null;
               activeForm.Viewer.AutoDisposeImages = true;
               image.Dispose();
               if (activeForm.Viewer.Image.HasRegion)
                  activeForm.Viewer.Image.MakeRegionEmpty();
            }
            else
            {
               CropDialog dlg = new CropDialog(activeForm.Image.Width, activeForm.Image.Height);
               if (dlg.ShowDialog(this) == DialogResult.OK)
               {
                  RasterImage image = activeForm.Image;
                  if (dlg.CropLeft > image.Width ||
                     dlg.CropTop > image.Height ||
                     (dlg.CropLeft + dlg.CropWidth) > image.Width ||
                     (dlg.CropTop + dlg.CropHeight) > image.Height)
                     Messager.ShowError(this, DemosGlobalization.GetResxString(GetType(), "Resx_InvalidCropValues"));
                  else
                     command = new CropCommand(new LeadRect(dlg.CropLeft, dlg.CropTop, dlg.CropWidth, dlg.CropHeight));
               }
            }
         }
         else if (sender == _menuItemImageDeskew)
         {
            DeskewDialog dlg = new DeskewDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new DeskewCommand(dlg.FillColor, dlg.Flags);
         }
         else if (sender == _menuItemImageFlipCustom)
         {
            FlipDialog dlg = new FlipDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new FlipCommand(dlg.Horizontal);
         }
         else if (sender == _menuItemImageRotateCustom)
         {
            RotateDialog dlg = new RotateDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new RotateCommand(dlg.Angle, dlg.Flags, dlg.FillColor);
         }
         else if (sender == _menuItemImageResize)
         {
            ResizeDialog dlg = new ResizeDialog(activeForm.Image.Width, activeForm.Image.Height);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new SizeCommand(dlg.ImageWidth, dlg.ImageHeight, dlg.Flags);
         }
         else if (sender == _menuItemImageShear)
         {
            ShearDialog dlg = new ShearDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new ShearCommand(dlg.Angle, dlg.Horizontal, dlg.FillColor);
         }

         if (command != null)
            RunCommand(command);
      }

      private void _menuItemEffectsSpecial_Click(object sender, EventArgs e)
      {
         RasterCommand command = null;
         ViewerForm activeForm = ActiveViewerForm;

         if (sender == _menuItemEffectsNoiseAddNoise)
         {
            AddNoiseDialog dlg = new AddNoiseDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new AddNoiseCommand(dlg.Range, dlg.Channel);
         }
         else if (sender == _menuItemEffectsBlurAntiAlias)
         {
            AntiAliasDialog dlg = new AntiAliasDialog(activeForm.Image.BitsPerPixel);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new AntiAliasingCommand(dlg.Threshold, dlg.Dimension, dlg.Filter);
         }
         else if (sender == _menuItemEffectsBlurAverage)
         {
            ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Average);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new AverageCommand(dlg.Value);
         }
         else if (sender == _menuItemEffectsEdgeDetector)
         {
            EdgeDetectorDialog dlg = new EdgeDetectorDialog(activeForm.Image);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new EdgeDetectorCommand(dlg.Threshold, dlg.Filter);
         }
         else if (sender == _menuItemEffects3DEffectsEmboss)
         {
            EmbossDialog dlg = new EmbossDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new EmbossCommand(dlg.Direction, dlg.Depth);
         }
         else if (sender == _menuItemEffectsSpecialGaussian)
         {
            ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Gaussian);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new GaussianCommand(dlg.Value);
         }
         else if (sender == _menuItemEffectsNoiseMedian)
         {
            ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Median);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new MedianCommand(dlg.Value);
         }
         else if (sender == _menuItemEffectsPixelateMosaic)
         {
            ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Mosaic);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new MosaicCommand(dlg.Value);
         }
         else if (sender == _menuItemEffectsBlurMotionBlur)
         {
            MotionBlurDialog dlg = new MotionBlurDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new MotionBlurCommand(dlg.Dimension, dlg.Angle, dlg.UniDirectional);
         }
         else if (sender == _menuItemEffectsArtisticOilify)
         {
            ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Oilify);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new OilifyCommand(dlg.Value);
         }
         else if (sender == _menuItemColorPosterize)
         {
            ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Posterize);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new PosterizeCommand(dlg.Value);
         }
         else if (sender == _menuItemEffectsSharpenSharpen)
         {
            ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Sharpen);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new SharpenCommand(dlg.Value);
         }
         else if (sender == _menuItemEffectsSharpenUnsharpMask)
         {
            UnsharpMaskDialog dlg = new UnsharpMaskDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new UnsharpMaskCommand(dlg.Amount, dlg.Radius, dlg.Threshold, dlg.ColorSpace);
         }


         if (command != null)
            RunCommand(command);
      }

      private void _menuItemEffectsSpatialSpatialFilters_Click(object sender, EventArgs e)
      {
         SpatialDialog dlg = new SpatialDialog();
         if (dlg.ShowDialog(this) == DialogResult.OK)
            RunCommand(new SpatialFilterCommand(dlg.Filter));
      }

      private void _menuItemEffectsBinary_Click(object sender, EventArgs e)
      {
         RasterCommand command = null;

         if (sender == _menuItemEffectsBinaryBinaryFilters)
         {
            BinaryDialog dlg = new BinaryDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new BinaryFilterCommand(dlg.Filter);
         }
         else if (sender == _menuItemEffectsNoiseMin)
         {
            ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Min);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new MinimumCommand(dlg.Value);
         }
         else if (sender == _menuItemEffectsNoiseMax)
         {
            ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Max);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new MaximumCommand(dlg.Value);
         }
          else if (sender == _menuItemEffectsNoiseSaltPepper)
 	      {
 	         command = new RemoveSaltPepperCommand();
 	      } 

         if (command != null)
            RunCommand(command);
      }

#if LEADTOOLS_V20_OR_LATER
      private void _menuItemEffectsOther_Click(object sender, EventArgs e)
      {
         if (sender == _menuItemEffectsOtherWienerFilter)
         {
            WienerFilterDialog dlg = new WienerFilterDialog(this, ActiveViewerForm);
            dlg.ShowDialog(this);
         }
      }
#endif //#if LEADTOOLS_V20_OR_LATER

      private void _menuItemColorSwapColorOrder_Click(object sender, EventArgs e)
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;
            if (activeForm.Viewer.Image.Order == RasterByteOrder.Rgb)
               activeForm.Viewer.Image.Order = RasterByteOrder.Bgr;
            else
               activeForm.Viewer.Image.Order = RasterByteOrder.Rgb;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      private void _menuItemColorAdjustBalanceColors_Click(object sender, EventArgs e)
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;

            BalanceColorsDialog dlg = new BalanceColorsDialog(activeForm.Viewer.Image, _paintProperties);

            dlg.RedWeights.ToRed = 1;
            dlg.GreenWeights.ToGreen = 1;
            dlg.BlueWeights.ToBlue = 1;

            if (DialogResult.OK == dlg.ShowDialog())
            {
               BalanceColorsCommand command = new BalanceColorsCommand(dlg.RedWeights,
                                                                       dlg.GreenWeights,
                                                                       dlg.BlueWeights);

               RunCommand(command);
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      void _menuItemColorAdjustBrightness_Click(object sender, EventArgs e)
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;

            BrightnessDialog dlg = new BrightnessDialog(activeForm.Viewer.Image, _paintProperties);

            if (DialogResult.OK == dlg.ShowDialog())
            {
               ChangeIntensityCommand command = new ChangeIntensityCommand(dlg.Brightness);

               RunCommand(command);
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      void _menuItemColorMatchHistogram_Click(object sender, EventArgs e)
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;

            MatchHistogramDialog dlg = new MatchHistogramDialog(activeForm.Viewer.Image, _paintProperties, this.MdiChildren);

            if (DialogResult.OK == dlg.ShowDialog())
            {
               MatchHistogramCommand command = new MatchHistogramCommand(((ViewerForm)this.MdiChildren[dlg.ImageIndex]).Image);
               RunCommand(command);
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      void _menuItemColorAdjustContrast_Click(object sender, EventArgs e)
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;

            ContrastDialog dlg = new ContrastDialog(activeForm.Viewer.Image, _paintProperties);

            if (DialogResult.OK == dlg.ShowDialog())
            {
               ChangeContrastCommand command = new ChangeContrastCommand(dlg.Contrast);

               RunCommand(command);
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      void _menuItemColorAdjustSaturation_Click(object sender, EventArgs e)
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;

            SaturationDialog dlg = new SaturationDialog(activeForm.Viewer.Image, _paintProperties);

            if (DialogResult.OK == dlg.ShowDialog())
            {
               ChangeSaturationCommand command = new ChangeSaturationCommand(dlg.Saturation);

               RunCommand(command);
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      void _menuItemColorAdjustGammaCorrect_Click(object sender, EventArgs e)
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;

            GammaAdjustmentDialog dlg = new GammaAdjustmentDialog(activeForm.Viewer.Image, _paintProperties);
            dlg.Gamma = 150;

            if (DialogResult.OK == dlg.ShowDialog())
            {
               GammaCorrectCommand command = new GammaCorrectCommand(dlg.Gamma);

               RunCommand(command);
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
      private void _menuItemColor_Click(object sender, EventArgs e)
      {
         RasterCommand command = null;

         if (sender == _menuItemEffectsEdgeContour)
         {
            ContourDialog dlg = new ContourDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new ContourFilterCommand(dlg.Threshold, dlg.DeltaDirection, dlg.MaximumError, dlg.Type);
         }
         else if (sender == _menuItemColorFill)
         {
            if (Tools.ShowColorDialog(this, ref _fillColor))
               command = new FillCommand(_fillColor);
         }
         else if (sender == _menuItemColorHistogramContrast)
         {
            ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.HistoContrast);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new HistogramContrastCommand(dlg.Value);
         }
         else if (sender == _menuItemColorHistogramEqualize)
         {
            HistogramEqualizeDialog dlg = new HistogramEqualizeDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new HistogramEqualizeCommand(dlg.ColorSpace);
         }
         else if (sender == _menuItemColorAdjustHue)
         {
            ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Hue);
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    command = new ChangeHueCommand(dlg.Value);
         }
         else if (sender == _menuItemColorInvert)
         {
            command = new InvertCommand();
         }
         else if (sender == _menuItemColorIntensityDetect)
         {
            IntensityDetectDialog dlg = new IntensityDetectDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new IntensityDetectCommand(dlg.Low, dlg.High, dlg.InColor, dlg.OutColor, dlg.Channel);
         }
         else if (sender == _menuItemColorSolarize)
         {
            ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Solarize);
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new SolarizeCommand(dlg.Value);
         }
         else if (sender == _menuItemColorHistogramStretchIntensity)
         {
            command = new StretchIntensityCommand();
         }
         else if (sender == _menuItemColorSwapColors)
         {
            SwapColorsDialog dlg = new SwapColorsDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new SwapColorsCommand(dlg.Type);
         }

         if (command != null)
            RunCommand(command);
      }

      private void _menuItemDocument_Click(object sender, EventArgs e)
      {
         RasterCommand command = null;

         if (sender == _menuItemDocumentBorderRemove)
         {
            BorderRemoveDialog dlg = new BorderRemoveDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new BorderRemoveCommand(dlg.Flags, dlg.Border, dlg.Percent, dlg.WhiteNoiseLength, dlg.Variance);
         }
         else if (sender == _menuItemDocumentDespeckle)
         {
            command = new DespeckleCommand();
         }
         else if (sender == _menuItemDocumentDotRemove)
         {
            DotRemoveDialog dlg = new DotRemoveDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new DotRemoveCommand(dlg.Flags, dlg.MinWidth, dlg.MinHeight, dlg.MaxWidth, dlg.MaxHeight);
         }
         else if (sender == _menuItemDocumentHolePunchRemove)
         {
            HolePunchRemoveDialog dlg = new HolePunchRemoveDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new HolePunchRemoveCommand(dlg.Flags, dlg.HoleLocation, dlg.MinCount, dlg.MaxCount, dlg.MinWidth, dlg.MinHeight, dlg.MaxWidth, dlg.MaxHeight);
         }
         else if (sender == _menuItemDocumentInvertedText)
         {
            InvertedTextDialog dlg = new InvertedTextDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new InvertedTextCommand(dlg.Flags, dlg.MinInvertWidth, dlg.MinInvertHeight, dlg.MinBlackPercent, dlg.MaxBlackPercent);
         }
         else if (sender == _menuItemDocumentLineRemove)
         {
            LineRemoveDialog dlg = new LineRemoveDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new LineRemoveCommand(dlg.Flags, dlg.MinLineLength, dlg.MaxLineWidth, dlg.Wall, dlg.MaxWallPercent, dlg.GapLength, dlg.LineVariance, dlg.Remove);
         }
         else if (sender == _menuItemDocumentSmooth)
         {
            SmoothDialog dlg = new SmoothDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
               command = new SmoothCommand(dlg.Flags, dlg.Length);
         }


         if (command != null)
            RunCommand(command);
      }

      private void _menuItemPreferencesProgressBar_Click(object sender, EventArgs e)
      {
         _menuItemPreferencesProgressBar.Checked = !_menuItemPreferencesProgressBar.Checked;
      }

      private void _menuItemHelpAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Main", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _menuItemWindow_Click(object sender, EventArgs e)
      {
         if (sender == _menuItemWindowCascade)
            LayoutMdi(MdiLayout.Cascade);
         else if (sender == _menuItemWindowTileHorizontally)
            LayoutMdi(MdiLayout.TileHorizontal);
         else if (sender == _menuItemWindowTileVertically)
            LayoutMdi(MdiLayout.TileVertical);
         else if (sender == _menuItemWindowArrangeIcons)
            LayoutMdi(MdiLayout.ArrangeIcons);
         else if (sender == _menuItemWindowCloseAll)
         {
            while (MdiChildren.Length > 0)
               MdiChildren[0].Close();
            UpdateControls();
         }
      }

      //used to load default images
      private void LoadDefaultImage(string fileName, int firstPage, int lastPage)
      {
         ImageFileLoader loader = new ImageFileLoader();

         try
         {
            if (loader.Load(this, fileName, _codecs, firstPage, lastPage))
            {
               ImageInformation info = new ImageInformation(loader.Image, loader.FileName);
               if (info != null)
               {
                  NewImage(info);

                  _menuItemPreferencesLoadMultithreaded.Checked = _codecs.Options.Jpeg.Load.Multithreaded;
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }
      }

      private List<ImageInformation> LoadImage(bool multiSelect)
      {
         ImageFileLoader loader = new ImageFileLoader();

         try
         {
            loader.OpenDialogInitialPath = _openInitialPath;
            loader.ShowLoadPagesDialog = true;
            loader.MultiSelect = multiSelect;
            loader.UseGdiPlus = (_paintProperties.PaintEngine == RasterPaintEngine.GdiPlus);
            loader.LoadCorrupted = _menuItemLoadingCorruptedImages.Checked;
            loader.PreferVector = _menuItemPreferVector.Checked;
            int filesCount = loader.Load(this, _codecs, true);

            if (filesCount > 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               _menuItemPreferencesLoadMultithreaded.Checked = _codecs.Options.Jpeg.Load.Multithreaded;
               return loader.Images;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }

         return null;
      }

      private void NewImage(ImageInformation info)
      {
         // If we are loading a 32-bit image and the paint engine is GDI
         // Ask if the user wants to switch to GDI+2. GDI engine does not support alpha.
         if (info.Image != null && info.Image.BitsPerPixel == 32 && _paintProperties.PaintEngine == RasterPaintEngine.Gdi)
         {
            string message = DemosGlobalization.GetResxString(GetType(), "Resx_EngineError");
            if (Messager.ShowQuestion(
               this,
               message,
               MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
               _paintProperties.PaintEngine = RasterPaintEngine.GdiPlus;
               foreach (ViewerForm i in MdiChildren)
                  i.UpdatePaintProperties(_paintProperties);
            }
         }
         ViewerForm child = new ViewerForm();
         child.MdiParent = this;
         child.Initialize(info, _paintProperties, _animateRegions, true, _useDpi);
         child.Viewer.Zoom(ControlSizeMode.ActualSize, 1, child.Viewer.DefaultZoomOrigin);
         child.Viewer.InteractiveModes.BeginUpdate();
         child.NoneInteractiveMode.IsEnabled = true;

         //Set the DoubleTapSizeMode property for all ImageViewerPanZoomInteractiveModes to use the current size mode of the image viewer control
         foreach( ImageViewerInteractiveMode mode in child.Viewer.InteractiveModes)
         {
            if (mode is ImageViewerPanZoomInteractiveMode) 
               ((ImageViewerPanZoomInteractiveMode)mode).DoubleTapSizeMode = child.Viewer.SizeMode;
         }
         
         child.Viewer.InteractiveModes.EndUpdate();
         child.Show();

         _menuItemColorWindowLevel.Enabled = (info.Image.GrayscaleMode != RasterGrayscaleMode.None);
      }

      private bool ShouldProcessMainImage(RasterCommand command)
      {
         ViewerForm activeForm = ActiveViewerForm;
         if ((activeForm.Viewer.Floater != null) && (activeForm.Viewer.FloaterOpacity > 0.0))
         {
            if (command is GrayscaleCommand)
               return true;
            if (command is GrayScaleExtendedCommand)
               return true;
            if (command is ColorResolutionCommand)
               return true;
            if (command is HalfToneCommand)
               return true;
         }
         return false;
      }

      private RasterImage ImageToRun
      {
         get
         {
            ViewerForm activeForm = ActiveViewerForm;

            if ((activeForm.Viewer.Floater != null) && (activeForm.Viewer.FloaterOpacity > 0.0))
               return activeForm.Viewer.Floater;
            else
               return activeForm.Viewer.Image;
         }
         set
         {
            if (value != null)
            {
               ViewerForm activeForm = ActiveViewerForm;

               if ((activeForm.Viewer.Floater != null) && (activeForm.Viewer.FloaterOpacity > 0.0))
                  activeForm.Viewer.Floater = value;
               else
                  activeForm.Viewer.Image = value;
            }
         }
      }

      private void RunCommand(RasterCommand command)
      {
         ViewerForm activeForm = ActiveViewerForm;

         try
         {
            // save the floater position so we preserve the center
            Point oldFloaterCenter = new Point(0, 0);
            if ((activeForm.Viewer.FloaterOpacity > 0.0) && (activeForm.Viewer.Floater != null))
            {
               activeForm.Viewer.RenderItemFloater += new EventHandler<ImageViewerRenderEventArgs>(Viewer_RenderItemFloater);

               LeadMatrix floaterTransform = ActiveViewerForm.Viewer.FloaterTransform;

               oldFloaterCenter = new Point((int)floaterTransform.OffsetX, (int)floaterTransform.OffsetY);
               Rectangle rect = Converters.ConvertRect(activeForm.Viewer.Floater.GetRegionBounds(null));
               oldFloaterCenter.Offset(rect.Right / 2, rect.Bottom / 2);
            }
            if (_menuItemPreferencesProgressBar.Checked)
            {
               CommandProgressDialog dlg = new CommandProgressDialog();
               dlg.Command = command;
               dlg.Image = ImageToRun;
               // save the image, in case the command is canceled
               int currentPage = ImageToRun.Page;
               using (RasterImage backupImage = ImageToRun.CloneAll())
               {
                  dlg.ShowDialog(this);
                  if (dlg.Cancel)
                  {
                     ImageToRun = backupImage.CloneAll();
                     ImageToRun.Page = currentPage;
                  }
                  dlg.Hide();
                  dlg.Dispose();
                  Application.DoEvents();
               }
               if (ShouldProcessMainImage(command))// if true, then the floater has been processed
               {
                  dlg.Image = activeForm.Viewer.Image;
                  // save the image, in case the command is canceled
                  currentPage = activeForm.Viewer.Image.Page;
                  using (RasterImage backupImage = activeForm.Viewer.Image.CloneAll())
                  {
                     CommandProgressDialog dlg2 = new CommandProgressDialog();
                     dlg2.Command = dlg.Command;
                     dlg2.Image = dlg.Image;
                     dlg2.ShowDialog(this);
                     if (dlg2.Cancel)
                     {
                        activeForm.Viewer.Image = backupImage.CloneAll();
                        activeForm.Viewer.Image.Page = currentPage;
                     }
                     dlg2.Hide();
                     dlg2.Dispose();
                     Application.DoEvents();
                  }
               }
            }
            else
            {
               using (WaitCursor wait = new WaitCursor())
               {
                  command.Run(ImageToRun);
                  if (ShouldProcessMainImage(command))// if true, then the floater has been processed
                     command.Run(activeForm.Viewer.Image); // now process the main image
               }
            }
            if ((activeForm.Viewer.FloaterOpacity > 0.0) && (activeForm.Viewer.Floater != null))
            {
               ControlRegionRenderMode saveMode = activeForm.Viewer.FloaterRegionRenderMode;
               activeForm.Viewer.FloaterRegionRenderMode = ControlRegionRenderMode.None;

               LeadMatrix floaterTransform = activeForm.Viewer.FloaterTransform;
               floaterTransform.OffsetX = floaterTransform.OffsetX;
               floaterTransform.OffsetY = floaterTransform.OffsetY;

               Point newFloaterCenter = new Point((int)floaterTransform.OffsetX, (int)floaterTransform.OffsetY);
               newFloaterCenter.Offset(activeForm.Viewer.Floater.Width / 2, activeForm.Viewer.Floater.Height / 2);
               // move the floater so the center is preserved
               Point floaterPosition = new Point((int)floaterTransform.OffsetX, (int)floaterTransform.OffsetY);
               floaterPosition.Offset(oldFloaterCenter.X - newFloaterCenter.X,
                  oldFloaterCenter.Y - newFloaterCenter.Y);

               floaterTransform.OffsetX = floaterPosition.X;
               floaterTransform.OffsetY = floaterPosition.Y;

               activeForm.Viewer.FloaterTransform = floaterTransform;

               activeForm.Viewer.FloaterRegionRenderMode = saveMode;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      void Viewer_RenderItemFloater(object sender, ImageViewerRenderEventArgs e)
      {

      }

      private void _printDocument_BeginPrint(object sender, PrintEventArgs e)
      {
         // Start from first page in the image
         _currentPrintPageNumber = 1;
      }

      private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
      {
         CombineFloater();
         RasterImage image = ActiveViewerForm.Viewer.Image;

         // Get the print document object
         PrintDocument document = sender as PrintDocument;

         // Create an new LEADTOOLS image printer class
         RasterImagePrinter printer = new RasterImagePrinter();

         // Set the document object so page calculations can be performed
         printer.PrintDocument = document;

         // We want to fit and center the image into the maximum print area
         printer.SizeMode = RasterPaintSizeMode.FitAlways;
         printer.HorizontalAlignMode = RasterPaintAlignMode.Center;
         printer.VerticalAlignMode = RasterPaintAlignMode.Center;

         // Account for FAX images that may have different horizontal and vertical resolution
         printer.UseDpi = true;

         // Print the whole image
         printer.ImageRectangle = Rectangle.Empty;

         // Use maximum page dimension ignoring the margins, this will be equivalant of printing
         // using Windows Photo Gallery
         printer.PageRectangle = RectangleF.Empty;
         printer.UseMargins = false;

         // Print the current page
         printer.Print(image, _currentPrintPageNumber, e);

         // Go to the next page
         _currentPrintPageNumber++;

         // Inform the printer whether we have more pages to print
         if (_currentPrintPageNumber <= document.PrinterSettings.ToPage)
            e.HasMorePages = true;
         else
            e.HasMorePages = false;
      }

      private void _printDocument_EndPrint(object sender, PrintEventArgs e)
      {
         // Nothing to do here
      }


      private void _twainSession_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         Application.DoEvents();

         if (e.Image != null)
         {
            if (_acquirePageCount == 1)
               NewImage(new ImageInformation(e.Image, DemosGlobalization.GetResxString(GetType(), "Resx_TwainImage")));
            else
               ActiveViewerForm.Image.AddPage(e.Image);

            _acquirePageCount++;
         }
      }


      private void MainForm_DragEnter(object sender, DragEventArgs e)
      {
         if (CanFocus)
         {
         if (Tools.CanDrop(e.Data))
            e.Effect = DragDropEffects.Copy;
      }
      }

      private void MainForm_DragDrop(object sender, DragEventArgs e)
      {
         if (CanFocus)
         {
         if (Tools.CanDrop(e.Data))
         {
            string[] files = Tools.GetDropFiles(e.Data);
            if (files != null)
               LoadDropFiles(null, files);
            }
         }
      }

      public void LoadDropFiles(ViewerForm viewer, string[] files)
      {
         try
         {
            if (files != null)
            {
               for (int i = 0; i < files.Length; i++)
               {
                  try
                  {
                     RasterImage image = _codecs.Load(files[i]);
                     ImageInformation info = new ImageInformation(image, files[i]);
                     if (i == 0 && viewer != null)
                        viewer.Initialize(info, _paintProperties, _animateRegions, false, _useDpi);
                     else
                        NewImage(info);
                  }
                  catch (Exception ex)
                  {
                     Messager.ShowFileOpenError(this, files[i], ex);
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void CombineFloater()
      {
         ViewerForm activeForm = ActiveViewerForm;

         if (activeForm.Viewer.Image.HasRegion)
            activeForm.Viewer.Image.MakeRegionEmpty();
         else if ((activeForm.Viewer.FloaterOpacity > 0.0) && (activeForm.Viewer.Floater != null))
         {
            DisableAllInteractiveModes(activeForm.Viewer);
            activeForm.Viewer.InteractiveModes.BeginUpdate();
            activeForm.NoneInteractiveMode.IsEnabled = true;
            activeForm.Viewer.InteractiveModes.EndUpdate();
            activeForm.Viewer.CombineFloater(false);
            activeForm.Viewer.Floater = null;
            activeForm.Viewer.Refresh();
         }

         UpdateControls();
      }

      private void _menuItemImage_DropDownOpened(object sender, EventArgs e)
      {
         if (ActiveViewerForm.Viewer.Image.BitsPerPixel > 1)
            _menuItemDocument.Enabled = false;
         else
            _menuItemDocument.Enabled = true;
      }

      private void MainForm_Closing(object sender, CancelEventArgs e)
      {

         if (_inTwainAcquire)
            e.Cancel = true;

         CleanUp();
      }

      private void LoadRaw(string fileName)
      {
         RawDialog dlg = new RawDialog(true);
         dlg.CurrentRawData = _rawdataLoad;
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            ImageInformation imageInfo = new ImageInformation();
            imageInfo.Name = fileName;
            _rawdataLoad = dlg.CurrentRawData;

            EventHandler<CodecsLoadInformationEventArgs> handler = new EventHandler<CodecsLoadInformationEventArgs>(codecs_LoadInformation);
            _codecs.Options.Load.Format = _rawdataLoad.Format;
            _codecs.LoadInformation += new EventHandler<CodecsLoadInformationEventArgs>(codecs_LoadInformation);

            try
            {
               using (WaitCursor wait = new WaitCursor())
               {
                  imageInfo.Image = _codecs.Load(fileName);
                  NewImage(imageInfo);
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_InvalidFileParameter") + "  " + ex.Message);
            }
            finally
            {
               _codecs.LoadInformation -= handler;
               _codecs.Options.Load.Format = RasterImageFormat.Unknown;
            }
         }
      }

      private void codecs_LoadInformation(object sender, CodecsLoadInformationEventArgs e)
      {
         // Set the information
         e.Format = _rawdataLoad.Format;
         e.Width = _rawdataLoad.Width;
         e.Height = _rawdataLoad.Height;
         e.BitsPerPixel = _rawdataLoad.BitsPerPixel;
         e.XResolution = _rawdataLoad.XResolution;
         e.YResolution = _rawdataLoad.YResolution;
         e.Offset = _rawdataLoad.Offset;
         e.WhiteOnBlack = _rawdataLoad.WhiteOnBlack;

         if (_rawdataLoad.Padding)
            e.Pad4 = true;

         e.Order = _rawdataLoad.Order;

         if (_rawdataLoad.ReverseBits)
            e.LeastSignificantBitFirst = true;

         e.ViewPerspective = _rawdataLoad.ViewPerspective;

         // If image is palettized create a grayscale palette
         if (_rawdataLoad.PaletteEnabled)
         {
            if (e.BitsPerPixel <= 8)
            {
               if (!_rawdataLoad.FixedPalette)
               {
                  int colors = 1 << e.BitsPerPixel;
                  RasterColor[] palette = new RasterColor[colors];
                  for (int i = 0; i < palette.Length; i++)
                  {
                     byte val = (byte)((i * 256) / colors);
                     palette[i] = new RasterColor(val, val, val);
                  }

                  e.SetPalette(palette);
               }
               else
               {
                  e.SetPalette(RasterPalette.Fixed(e.BitsPerPixel));
               }
            }
         }
      }

      private void SaveRaw(string fileName)
      {
         ViewerForm activeForm = ActiveViewerForm;

         RawDialog dlg = new RawDialog(false);
         _rawdataSave.Width = activeForm.Viewer.Image.Width;
         _rawdataSave.Height = activeForm.Viewer.Image.Height;
         _rawdataSave.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel;
         dlg.CurrentRawData = _rawdataSave;
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            ImageInformation imageInfo = new ImageInformation();
            _rawdataSave = dlg.CurrentRawData;
            try
            {
               using (WaitCursor wait = new WaitCursor())
               {
                  // Set RAW options
                  _codecs.Options.Raw.Save.Pad4 = _rawdataSave.Padding;
                  _codecs.Options.Raw.Save.ReverseBits = _rawdataSave.ReverseBits;
                  _codecs.Options.Save.OptimizedPalette = false;
                  if (_rawdataSave.Format == RasterImageFormat.Unknown)
                     _rawdataSave.Format = RasterImageFormat.Raw;

                  FileStream fs = File.Create(fileName);
                  using (fs)
                  {
                     _codecs.Save(activeForm.Viewer.Image,
                        fs,
                        _rawdataSave.Offset,
                        _rawdataSave.Format,
                        _rawdataSave.BitsPerPixel,
                        1,
                        1,
                        1,
                        CodecsSavePageMode.Overwrite);
                     fs.Close();
                  }
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_InvalidFileParameter") + "  " + ex.Message);
            }
         }
      }

      private void _menuItemFileOpenRaw_Click(object sender, EventArgs e)
      {
         try
         {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = DemosGlobalization.GetResxString(GetType(), "Resx_AllFilter") + "(*.*)|*.*|RAW (*.raw)|*.raw|Fax (*.fax)|*.fax|ABIC (*.abic;*.abc)|*.abic;*.abc";
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
               LoadRaw(ofd.FileName);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _menuItemFileSaveRaw_Click(object sender, EventArgs e)
      {
         ImageFileSaver saver = new ImageFileSaver();

         try
         {
            CombineFloater();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = @"RAW (*.raw)|*.raw|Fax (*.fax)|*.fax";
            sfd.FilterIndex = 1;
            if (sfd.ShowDialog(this) == DialogResult.OK)
            {
               SaveRaw(sfd.FileName);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileSaveError(this, saver.FileName, ex);
         }
      }

      private void _menuItemColorWindowLevel_Click(object sender, EventArgs e)
      {
         try
         {
            RasterWindowLevelDialog windowLevelDlg = new RasterWindowLevelDialog();
            ViewerForm activeForm = ActiveViewerForm;
            int lookupSize;
            MinMaxBitsCommand minMaxBits = new MinMaxBitsCommand();
            MinMaxValuesCommand minMaxValues = new MinMaxValuesCommand();
            RasterColor[] lookupTable;

            minMaxBits.Run(activeForm.Viewer.Image);
            minMaxValues.Run(activeForm.Viewer.Image);

            lookupSize = (1 << (minMaxBits.MaximumBit - minMaxBits.MinimumBit + 1));
            lookupTable = new RasterColor[lookupSize];


            windowLevelDlg.Image = activeForm.Viewer.Image;
            windowLevelDlg.ShowPreview = true;
            windowLevelDlg.ShowRange = true;
            windowLevelDlg.ShowZoomLevel = true;
            windowLevelDlg.ZoomToFit = false;
            windowLevelDlg.LowBit = minMaxBits.MinimumBit;
            windowLevelDlg.HighBit = minMaxBits.MaximumBit;
            windowLevelDlg.Low = minMaxValues.MinimumValue;
            windowLevelDlg.High = minMaxValues.MaximumValue;
            windowLevelDlg.WindowLevelFlags = RasterPaletteWindowLevelFlags.Inside | RasterPaletteWindowLevelFlags.Linear;
            windowLevelDlg.LookupTable = lookupTable;
            windowLevelDlg.Signed = activeForm.Viewer.Image.Signed;

            switch (activeForm.Viewer.Image.GrayscaleMode)
            {
               case RasterGrayscaleMode.OrderedNormal:
                  {
                     windowLevelDlg.StartColor = new RasterColor(0, 0, 0);
                     windowLevelDlg.EndColor = new RasterColor(255, 255, 255);

                     break;
                  }

               case RasterGrayscaleMode.OrderedInverse:
                  {
                     windowLevelDlg.StartColor = new RasterColor(255, 255, 255);
                     windowLevelDlg.EndColor = new RasterColor(0, 0, 0);

                     break;
                  }

               case RasterGrayscaleMode.NotOrdered:
                  {
                     windowLevelDlg.StartColor = new RasterColor(0, 0, 0);
                     windowLevelDlg.EndColor = new RasterColor(255, 255, 255);

                     break;
                  }

               default:
                  {
                     MessageBox.Show(Owner,
                                       DemosGlobalization.GetResxString(GetType(), "Resx_WindowLevelSupportError"),
                                       DemosGlobalization.GetResxString(GetType(), "Resx_WindowLevelError"),
                                       MessageBoxButtons.OK);

                     _menuItemColorWindowLevel.Enabled = false;

                     return;
                  }
            }

            if (windowLevelDlg.ShowDialog(Owner) == DialogResult.OK)
            {
               RasterPalette.WindowLevelFillLookupTable(lookupTable,
                                                         windowLevelDlg.StartColor,
                                                         windowLevelDlg.EndColor,
                                                         windowLevelDlg.Low,
                                                         windowLevelDlg.High,
                                                         windowLevelDlg.LowBit,
                                                         windowLevelDlg.HighBit,
                                                         minMaxValues.MinimumValue,
                                                         minMaxValues.MaximumValue,
                                                         windowLevelDlg.Factor,
                                                         windowLevelDlg.WindowLevelFlags |
                                                         (windowLevelDlg.Signed ? RasterPaletteWindowLevelFlags.Signed : RasterPaletteWindowLevelFlags.None));

               activeForm.Viewer.Image.WindowLevel(windowLevelDlg.LowBit,
                                                   windowLevelDlg.HighBit,
                                                   lookupTable,
                                                   RasterWindowLevelMode.PaintAndProcessing);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _menuItemPreferencesLoadTextFile_Click(object sender, EventArgs e)
      {
         _menuItemPreferencesLoadTextFile.Checked = !_menuItemPreferencesLoadTextFile.Checked;
         EnableTextFiles(_codecs, _menuItemPreferencesLoadTextFile.Checked);
      }

      private void _menuItemColorSeparation_Click(object sender, EventArgs e)
      {
         try
         {
            ColorSeparateCommand command = new ColorSeparateCommand();
            CombineFloater();

            if (sender == _menuItemColorSeparationRGB)
            {
               command.Type = ColorSeparateCommandType.Rgb;
               RunCommand(command);

               // Create Blue Plane Window
               command.DestinationImage.Page = 1;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_BluePlane"));

               // Create Green Plane Window
               command.DestinationImage.Page = 2;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_GreenPlane"));

               // Create Red Plane Window
               command.DestinationImage.Page = 3;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_RedPlane"));

            }
            else if (sender == _menuItemColorSeparationCMY)
            {
               command.Type = ColorSeparateCommandType.Cmy;
               RunCommand(command);

               // Create Cyan Plane Window
               command.DestinationImage.Page = 1;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_CyanPlane"));

               // Create Magenta Plane Window
               command.DestinationImage.Page = 2;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_MagentaPlane"));

               // Create Yellow Plane Window
               command.DestinationImage.Page = 3;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_YellowPlane"));
            }
            else if (sender == _menuItemColorSeparationCMYK)
            {
               command.Type = ColorSeparateCommandType.Cmyk;
               RunCommand(command);

               // Create Cyan Plane Window
               command.DestinationImage.Page = 1;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_CyanPlane"));

               // Create Magenta Plane Window
               command.DestinationImage.Page = 2;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_MagentaPlane"));

               // Create Yellow Plane Window
               command.DestinationImage.Page = 3;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_YellowPlane"));

               // Create Black Window
               command.DestinationImage.Page = 4;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_BlackPlane"));
            }
            else if (sender == _menuItemColorSeparationHSV)
            {
               command.Type = ColorSeparateCommandType.Hsv;
               RunCommand(command);

               // Create Hue Plane Window
               command.DestinationImage.Page = 1;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_HuePlane"));

               // Create Saturation Plane Window
               command.DestinationImage.Page = 2;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_SaturationPlane"));

               // Create Value Plane Window
               command.DestinationImage.Page = 3;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_ValuePlane"));
            }
            else if (sender == _menuItemColorSeparationHLS)
            {
               command.Type = ColorSeparateCommandType.Hls;
               RunCommand(command);

               // Create Hue Plane Window
               command.DestinationImage.Page = 1;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_HuePlane"));

               // Create Lightness Plane Window
               command.DestinationImage.Page = 2;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_LightnessPlane"));

               // Create Saturation Plane Window
               command.DestinationImage.Page = 3;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_SaturationPlane"));
            }
            else if (sender == _menuItemColorSeparationLAB)
            {
               command.Type = ColorSeparateCommandType.Lab;
               RunCommand(command);

               // Create Lightness Plane Window
               command.DestinationImage.Page = 1;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_LightnessPlane"));

               // Create A Color-Opponent Plane Window.
               command.DestinationImage.Page = 2;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_AColorOpponentPlane"));

               // Create B Color-Opponent Plane Window.
               command.DestinationImage.Page = 3;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_BColorOpponentPlane"));

            }
            else if(sender == _menuItemColorSeparationSCT)
            {
               command.Type = ColorSeparateCommandType.Sct;
               RunCommand(command);

               // Create S Plane Window
               command.DestinationImage.Page = 1;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_SColorPlane"));

               // Create C Plane Window
               command.DestinationImage.Page = 2;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_CColorPlane"));

               // Create T Plane Window
               command.DestinationImage.Page = 3;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_TColorPlane"));
            }
            else if (sender == _menuItemColorSeparationXYZ)
            {
               command.Type = ColorSeparateCommandType.Xyz;
               RunCommand(command);

               // Create X Plane Window
               command.DestinationImage.Page = 1;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_XColorPlane"));

               // Create Y Plane Window
               command.DestinationImage.Page = 2;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_YColorPlane"));

               // Create Z Plane Window
               command.DestinationImage.Page = 3;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_ZColorPlane"));
            }
            else if (sender == _menuItemColorSeparationYCrCb)
            {
               RunCommand(command);

               // Create Y Plane Window
               command.DestinationImage.Page = 1;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_YColorPlane"));

               // Create U Plane Window
               command.DestinationImage.Page = 2;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_UColorPlane"));

               // Create V Plane Window
               command.DestinationImage.Page = 3;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_VColorPlane"));
            }
            else if (sender == _menuItemColorSeparationYUV)
            {
               RunCommand(command);

               // Create Y Plane Window
               command.DestinationImage.Page = 1;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_YColorPlane"));

               // Create U Plane Window
               command.DestinationImage.Page = 2;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_UColorPlane"));

               // Create V Plane Window
               command.DestinationImage.Page = 3;
               CreateColorPlaneWindow(command.DestinationImage.Clone(), DemosGlobalization.GetResxString(GetType(), "Resx_VColorPlane"));
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _menuItemColorSeparationAlpha_Click(object sender, EventArgs e)
      {
         CreateColorPlaneWindow(ActiveViewerForm.Image.CreateAlphaImage(), DemosGlobalization.GetResxString(GetType(), "Resx_Alpha"));
      }

      private void _menuItemColorUniqueColors_Click(object sender, EventArgs e)
      {
         try
         {
            ColorCountCommand command = new ColorCountCommand();
            int colorCount = 0;

            //Get the number of colors in the image.
            command.Run(ActiveViewerForm.Image);
            colorCount = command.ColorCount;

            MessageBox.Show((DemosGlobalization.GetResxString(GetType(), "Resx_ImageContains") + "  " + colorCount.ToString() + " " + DemosGlobalization.GetResxString(GetType(), "Resx_UniqueColors")),
                            "",
                            MessageBoxButtons.OK);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void CreateColorPlaneWindow(RasterImage image, string caption)
      {
         ImageInformation info = new ImageInformation(image, caption);

         NewImage(info);
      }

      private void _menuItemViewAlignModeHorizontal_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;

         if (sender == _menuItemViewAlignModeHorizontalNear)
         {
            activeForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Near;
         }
         else if (sender == _menuItemViewAlignModeHorizontalCenter)
         {
            activeForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Center;
         }
         else
         {
            activeForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Far;
         }

         UpdateControls();
      }

      private void _menuItemViewAlignModeVertical_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;

         if (sender == _menuItemViewAlignModeVerticalNear)
         {
            activeForm.Viewer.ViewVerticalAlignment = ControlAlignment.Near;
         }
         else if (sender == _menuItemViewAlignModeVerticalCenter)
         {
            activeForm.Viewer.ViewVerticalAlignment = ControlAlignment.Center;
         }
         else
         {
            activeForm.Viewer.ViewVerticalAlignment = ControlAlignment.Far;
         }

         UpdateControls();
      }

      private void _menuItemPreferencesUseDpi_Click(object sender, EventArgs e)
      {
         _menuItemPreferencesUseDpi.Checked = !_menuItemPreferencesUseDpi.Checked;
         foreach (ViewerForm i in MdiChildren)
         {
            i.Viewer.UseDpi = _menuItemPreferencesUseDpi.Checked;
            i.Viewer.Zoom(ControlSizeMode.Fit, i.Viewer.ScaleFactor, i.Viewer.DefaultZoomOrigin);
         }
         _useDpi = _menuItemPreferencesUseDpi.Checked;
      }

      private void _menuItemPreferencesInitAlpha_Click(object sender, EventArgs e)
      {
         _codecs.Options.Load.InitAlpha = !_codecs.Options.Load.InitAlpha;
         _codecs.Options.Save.InitAlpha = !_codecs.Options.Save.InitAlpha;
         UpdateControls();
      }

      private void _menuItemImageBlankPageDetection_Click(object sender, EventArgs e)
      {
         int bpp = 24;
         try
         {
            ViewerForm activeForm = ActiveViewerForm;
            BlankPageDetectorCommand command = new BlankPageDetectorCommand(BlankPageDetectorCommandFlags.UseAdvanced | BlankPageDetectorCommandFlags.DetectNoisyPage | BlankPageDetectorCommandFlags.UseBleedThrough, 0, 0, 0, 0);

            bpp = activeForm.Image.BitsPerPixel;
            command.Run(activeForm.Image);
            MessageBox.Show(" " + DemosGlobalization.GetResxString(GetType(), "Resx_IsBlank") + "   : " + command.IsBlank + "\n " + DemosGlobalization.GetResxString(GetType(), "Resx_Accuracy") + " : " + (command.Accuracy * 1.0 / 100) + "%", DemosGlobalization.GetResxString(GetType(), "Resx_BlankPageDetectionResults"));
         }
         catch (Exception ex)
         {
            if ((bpp == 12) || (bpp == 16) || (bpp == 48) || (bpp == 64))
               Messager.ShowError(this, DemosGlobalization.GetResxString(GetType(), "Resx_SupportError"));
            else
               Messager.ShowError(this, ex);
         }

      }

      private void _menuItemFileWiaAcquire_Click(object sender, EventArgs e)
      {

         try
         {
            using (WiaVersionForm WiaVersionDlg = new WiaVersionForm())
            {
               if (WiaVersionDlg.ShowDialog() == DialogResult.OK)
               {
                  _wiaVersion = WiaVersionDlg._selectedWiaVersion;
                  using (WaitCursor wait = new WaitCursor())
                  {
                     if (WiaSession.IsAvailable(_wiaVersion))
                     {
                        _wiaSession = new WiaSession();
                        _wiaSession.Startup(_wiaVersion);
                        _wiaSession.AcquireEvent += new EventHandler<WiaAcquireEventArgs>(_wiaSession_AcquireEvent);
                     }
                     else
                     {
                        return;
                     }
                  }
               }
               else
               {
                  return;
               }
            }


            DialogResult res = _wiaSession.SelectDeviceDlg(this.Handle, WiaDeviceType.Default, WiaSelectSourceFlags.NoDefault);

            if (res != DialogResult.OK)
               return;

            _wiaAcquiring = true;
            _acquirePageCount = 1;
            UpdateControls();

            // Disable the minimize and maximize buttons.
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            if (_wiaVersion == WiaVersion.Version2)
            {
               _wiaAcquireOptions.FileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + DemosGlobalization.GetResxString(GetType(), "Resx_WiaTest");
               _wiaSession.AcquireOptions = _wiaAcquireOptions;
            }

            this._mainMenu.Enabled = false;

            _progressDlg = new ProgressForm(DemosGlobalization.GetResxString(GetType(), "Resx_Transfering"), "", 100);
            _progressDlg.Show(this);

            res = _wiaSession.Acquire(this.Handle, null, WiaAcquireFlags.ShowUserInterface | WiaAcquireFlags.UseCommonUI);

            if (res != DialogResult.OK)
               return;

            this._mainMenu.Enabled = true;

            // Enable back the minimize and maximize buttons.
            this.MinimizeBox = true;
            this.MaximizeBox = true;

            if (_progressDlg.Visible)
            {
               if (!_progressDlg.Abort)
                  _progressDlg.Dispose();
            }

            if (_wiaVersion == WiaVersion.Version2)
            {
               if (_wiaSession.FilesCount > 0)  // This property indicates how many files where saved when the transfer mode is File mode.
               {
                  string strMsg = DemosGlobalization.GetResxString(GetType(), "Resx_SavedPages") + "\n\n";
                  if (_wiaSession.FilesPaths.Count > 0)
                  {
                     for (int i = 0; i < _wiaSession.FilesPaths.Count; i++)
                     {
                        string strTemp = string.Format("{0}\n", _wiaSession.FilesPaths[i]);
                        strMsg += strTemp;
                     }
                     MessageBox.Show(this, strMsg, DemosGlobalization.GetResxString(GetType(), "Resx_FileTransfer"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
               }
               else
               {
                  string strMsg = DemosGlobalization.GetResxString(GetType(), "Resx_SavedPages") + "\n\n" + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                  MessageBox.Show(this, strMsg, DemosGlobalization.GetResxString(GetType(), "Resx_FileTransfer"), MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
            }

            _wiaAcquiring = false;
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            this._mainMenu.Enabled = true;

            // Enable back the minimize and maximize buttons.
            this.MinimizeBox = true;
            this.MaximizeBox = true;

            _wiaAcquiring = false;

            if (_progressDlg != null && _progressDlg.Visible)
            {
               if (!_progressDlg.Abort)
                  _progressDlg.Dispose();
            }

            _acquirePageCount = -1;
            if (_wiaSession != null)
               _wiaSession.Shutdown();
         }

         UpdateControls();

      }


      void _wiaSession_AcquireEvent(object sender, WiaAcquireEventArgs e)
      {
         // Update the progress bar with the received percent value;
         if (_progressDlg.Visible)
         {
            if (((e.Flags & WiaAcquiredPageFlags.StartOfPage) == WiaAcquiredPageFlags.StartOfPage) &&
                ((e.Flags & WiaAcquiredPageFlags.EndOfPage) != WiaAcquiredPageFlags.EndOfPage))
            {
               _progressDlg.Percent = 0;
            }
            else
            {
               _progressDlg.Percent = e.Percent;
            }

            Application.DoEvents();

            if (_progressDlg.Abort)
               e.Cancel = true;
         }

         if (e.Image != null)
         {
            if (_acquirePageCount == 1)
               NewImage(new ImageInformation(e.Image, DemosGlobalization.GetResxString(GetType(), "Resx_WIAImage")));
            else
               ActiveViewerForm.Image.AddPage(e.Image);

            _acquirePageCount++;
            Application.DoEvents();
         }
      }


      private void _menuItemColorAutoBinarize_Click(object sender, EventArgs e)
      {

         try
         {
            ViewerForm activeForm = ActiveViewerForm;
            AutoBinarizeCommand command = new AutoBinarizeCommand();

            RunCommand(command);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }

      }

      private void _menuItemPreferencesLoadCompressed_Click(object sender, EventArgs e)
      {
         _menuItemPreferencesLoadCompressed.Checked = !_menuItemPreferencesLoadCompressed.Checked;
         _codecs.Options.Load.SuperCompressed = _menuItemPreferencesLoadCompressed.Checked;
      }

      private void _menuItemPreferencesLoadMultithreaded_Click(object sender, EventArgs e)
      {
         _menuItemPreferencesLoadMultithreaded.Checked = !_menuItemPreferencesLoadMultithreaded.Checked;
         _codecs.Options.Jpeg.Load.Multithreaded = _menuItemPreferencesLoadMultithreaded.Checked;
      }

        private void _menuItemPreferencesDisableMMX_Click(object sender, EventArgs e)
        {
            _menuItemPreferencesDisableMMX.Checked = !_menuItemPreferencesDisableMMX.Checked;
            _codecs.Options.Jpeg.Load.DisableMmx = _menuItemPreferencesDisableMMX.Checked;
        }

        private void _menuItemImageColorType_Click(object sender, EventArgs e)
      {

         ImageColorTypeCommand colorType = new ImageColorTypeCommand(ImageColorTypeCommandFlags.None);
         ViewerForm activeForm = ActiveViewerForm;
         colorType.Run(activeForm.Image);
         MessageBox.Show("Color Type = " + colorType.ColorType.ToString() + "\n" + DemosGlobalization.GetResxString(GetType(), "Resx_Confidence") + " = " + colorType.Confidence.ToString() + "%", DemosGlobalization.GetResxString(GetType(), "Resx_TypeOfImage"));

      }

      private void _menuItemSupportVectorFiles_Click(object sender, EventArgs e)
      {
         _menuItemSupportVectorFiles.Checked = !_menuItemSupportVectorFiles.Checked;
         EnableLoadVectorFiles(_codecs, _menuItemSupportVectorFiles.Checked);
      }

      private void _menuItemColorAdjust_menuItemColorAdjustTemperature_Click(object sender, EventArgs e)
      {

         TemperatureCommand command = null;

         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Temperature);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            command = new TemperatureCommand(dlg.Value);
            RunCommand(command);
         }

      }

      private void _menuItemColorAdjust_DropDownOpening(object sender, EventArgs e)
      {

         _menuItemColorAdjust_menuItemColorAdjustTemperature.Enabled = true;

      }

      private void kmeansToolStripMenuItem_Click(object sender, EventArgs e)
      {

         KMeansDialog dlg = new KMeansDialog();

         if (dlg.ShowDialog() == DialogResult.OK)
         {
            KMeansCommand command = new KMeansCommand(dlg.Clusters, dlg.Type, null);
            RunCommand(command);
         }

      }

      private void otsuToolStripMenuItem_Click(object sender, EventArgs e)
      {

         OtsuThresholdDialog dlg = new OtsuThresholdDialog();

         if (dlg.ShowDialog() == DialogResult.OK)
         {
            OtsuThresholdCommand command = new OtsuThresholdCommand(dlg.Clusters);
            RunCommand(command);
         }

      }

      private void lambdaConnectednessToolStripMenuItem_Click(object sender, EventArgs e)
      {

         LambdaConnectednessDialog dlg = new LambdaConnectednessDialog();
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            LambdaConnectednessCommand command = new LambdaConnectednessCommand(dlg.Lambda);
            RunCommand(command);
         }

      }

      public void DisableAllInteractiveModes(ImageViewer CurrentViewer)
      {
         CurrentViewer.InteractiveModes.BeginUpdate();
         foreach (ImageViewerInteractiveMode mode in CurrentViewer.InteractiveModes)
            mode.IsEnabled = false;
         CurrentViewer.InteractiveModes.EndUpdate();
      }
      private void levelSetToolStripMenuItem_Click(object sender, EventArgs e)
      {

         LevelsetCommand command = new LevelsetCommand();

         if (ActiveViewerForm.Viewer.Floater != null)
         {
            RasterRegionXForm xForm = new RasterRegionXForm();

            RasterRegion region = ActiveViewerForm.Viewer.Floater.GetRegion(xForm);

            LeadMatrix floaterTransform = ActiveViewerForm.Viewer.FloaterTransform;

            xForm.XOffset = (int)floaterTransform.OffsetX;
            xForm.YOffset = (int)floaterTransform.OffsetY;

            ActiveViewerForm.Viewer.Image.SetRegion(xForm, region, RasterRegionCombineMode.Set);
            ActiveViewerForm.Viewer.Invalidate();
            CancelFloater();
         }

         try
         {
            command.Run(ActiveViewerForm.Viewer.Image);

            ImageViewerItem test = new ImageViewerItem();
            test.ImageRegionToFloater();
            ActiveViewerForm.Viewer.ActiveItem.ImageRegionToFloater();
            ActiveViewerForm.Viewer.Image.SetRegion(null, null, RasterRegionCombineMode.Set);

            DisableAllInteractiveModes(ActiveViewerForm.Viewer);
            ActiveViewerForm.Viewer.InteractiveModes.BeginUpdate();
            ActiveViewerForm.FloaterInteractiveMode.IsEnabled = true;
            ActiveViewerForm.Viewer.InteractiveModes.EndUpdate();
            ActiveViewerForm.Viewer.FloaterOpacity = 1.0;
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }

      }

      private void segmentationToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
      {

         bool enable = (ActiveViewerForm != null);
         int BitsPerPixel = ActiveViewerForm.Viewer.Image.BitsPerPixel;
         bool enable2 = (enable) && ((BitsPerPixel == 8) || (BitsPerPixel == 16) || (BitsPerPixel == 24) || (BitsPerPixel == 32));
         _menuItemSegmentationGWire.Enabled =
             _menuItemSegmentationKmeans.Enabled =
             _menuItemSegmentationShrinkWrap.Enabled =
             _menuItemSegmentationLevelset.Enabled = enable;

         _menuItemSegmentationOtsu.Enabled =
         _menuItemSegmentationLambda.Enabled =
         _menuItemSegmentationSRAD.Enabled =
         _menuItemSegmentationTAD.Enabled = enable2;

         _menuItemSegmentationWatershed.Enabled = enable2;

      }

      private void gWireToolToolStripMenuItem_Click(object sender, EventArgs e)
      {

         if (_interactiveToolsList.ContainsKey(ActiveViewerForm.Viewer))
            return;

         GWireDialog dlg = new GWireDialog(ActiveViewerForm, this);
         dlg.Show();

         _interactiveToolsList.Add(ActiveViewerForm.Viewer, dlg);

      }

      private void _menuItemSegmentationShrinkWrap_Click(object sender, EventArgs e)
      {

         if (_interactiveToolsList.ContainsKey(ActiveViewerForm.Viewer))
            return;

         ShrinkWrapDialog dlg = new ShrinkWrapDialog(this, ActiveViewerForm);
         dlg.Show();

         _interactiveToolsList.Add(ActiveViewerForm.Viewer, dlg);

      }

      private void _menuItemSegmentationTAD_Click(object sender, EventArgs e)
      {

         TADAnisotropicDialog dlg = new TADAnisotropicDialog();

         if (dlg.ShowDialog() == DialogResult.OK)
         {
            TADAnisotropicDiffusionCommand command = new TADAnisotropicDiffusionCommand(dlg.Iterations, dlg.Lambda, dlg.Kappa, dlg.Flux);
            RunCommand(command);
         }

      }

      private void _menuItemSegmentationSRAD_Click(object sender, EventArgs e)
      {

         SRADAnisotropicDialog dlg = new SRADAnisotropicDialog();

         if (dlg.ShowDialog() == DialogResult.OK)
         {
            SRADAnisotropicDiffusionCommand command = new SRADAnisotropicDiffusionCommand(dlg.Iterations, dlg.Lambda, LeadRect.Create(10, 10, ActiveViewerForm.Viewer.Image.Width - 20, ActiveViewerForm.Viewer.Image.Height - 20));

            if (ActiveViewerForm.Viewer.Floater != null)
            {
               LeadRect rect = LeadRect.Empty;
               LeadRect boundRect = ActiveViewerForm.Viewer.Floater.GetRegionBoundsClipped(null);
               LeadMatrix floaterTransform = ActiveViewerForm.Viewer.FloaterTransform;
               int xOff = (int)floaterTransform.OffsetX;
               int yOff = (int)floaterTransform.OffsetY;

               rect.Top = boundRect.Top + yOff;
               rect.Left = boundRect.Left + xOff;
               rect.Right = boundRect.Right + xOff;
               rect.Bottom = boundRect.Bottom + yOff;

               CancelFloater();
               command.Rect = rect;
            }

            RunCommand(command);
         }

      }

      private void _menuItemSegmentationWatershed_Click(object sender, EventArgs e)
      {
         if (_interactiveToolsList.ContainsKey(ActiveViewerForm.Viewer))
            return;

         WatershedDialog dlg = new WatershedDialog(this, ActiveViewerForm);

         dlg.Show();

         _interactiveToolsList.Add(ActiveViewerForm.Viewer, dlg);

      }

      private void _menuItemLoadingCorruptedImages_Click(object sender, EventArgs e)
      {
         _menuItemLoadingCorruptedImages.Checked = !_menuItemLoadingCorruptedImages.Checked;
         _codecs.Options.Load.LoadCorrupted = _menuItemLoadingCorruptedImages.Checked;
      }

      private void _menuItemGlareDetection_Click(object sender, EventArgs e)
      {

         ViewerForm activeForm = ActiveViewerForm;
         GlareDetectionCommand command = new GlareDetectionCommand();
         try
         {
            command.Run(activeForm.Image);
            if (activeForm.Image.HasRegion)
            {
               ImageViewerItem test = new ImageViewerItem();
               test.ImageRegionToFloater();
               ActiveViewerForm.Viewer.ActiveItem.ImageRegionToFloater();
               ActiveViewerForm.Viewer.Image.SetRegion(null, null, RasterRegionCombineMode.Set);

               DisableAllInteractiveModes(ActiveViewerForm.Viewer);
               ActiveViewerForm.Viewer.InteractiveModes.BeginUpdate();
               ActiveViewerForm.FloaterInteractiveMode.IsEnabled = true;
               ActiveViewerForm.Viewer.InteractiveModes.EndUpdate();
               ActiveViewerForm.Viewer.FloaterOpacity = 0.5;
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void _menuItemSignalToNoiseRatio_Click(object sender, EventArgs e)
      {

         ViewerForm activeForm = ActiveViewerForm;
         SignalToNoiseRatioCommand command = new SignalToNoiseRatioCommand();
         try
         {
            command.Run(activeForm.Image);
            MessageBox.Show("Result : " + command.SNR, "Signal to noise ratio");
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void _menuItemTextBlurDetector_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;
         TextBlurDetectorCommand command = new TextBlurDetectorCommand();
         try
         {
            command.Run(activeForm.Image);
            if (command.InFocusBlocks != null && command.InFocusBlocks.Length >= 1)
            {
               activeForm.Image.AddRectangleToRegion(null, command.InFocusBlocks[0], RasterRegionCombineMode.Set);

               for (int i = 1; i < command.InFocusBlocks.Length; i++)
               {
                  activeForm.Image.AddRectangleToRegion(null, command.InFocusBlocks[i], RasterRegionCombineMode.Or);
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void _menuItemMICRDetection_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;
         RasterImage tmpImage = new RasterImage(activeForm.Image);
         MICRCodeDetectionCommand command = new MICRCodeDetectionCommand();
         try
         {
            if(bMICRRunMessage)
            {
               MessageBox.Show(this, DemosGlobalization.GetResxString(GetType(), "Resx_MICRRunMessage"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
               bMICRRunMessage = false;
            }
            command.Run(tmpImage);
            activeForm.Image.AddRectangleToRegion(null, command.MICRZone, RasterRegionCombineMode.Set);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void _menuItemMRZDetection_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;
         RasterImage tmpImage = new RasterImage(activeForm.Image);
         MRZCodeDetectionCommand command = new MRZCodeDetectionCommand();
         try
         {
            if (bMRZRunMessage)
            {
               MessageBox.Show(this, DemosGlobalization.GetResxString(GetType(), "Resx_MICRRunMessage"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
               bMRZRunMessage = false;
            }
            command.Run(tmpImage);
            activeForm.Image.AddRectangleToRegion(null, command.MRZZone, RasterRegionCombineMode.Set);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void _menuItemColorBlurDetection_Click(object sender, EventArgs e)
      {
         BlurDetectionCommand command = new BlurDetectionCommand();
         RasterImage image = ActiveViewerForm.Image;
         try
         {
            command.Run(image);
            if (command.Blurred)
            {
               MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_IsBlurTrue") + command.BlurExtent, DemosGlobalization.GetResxString(GetType(), "Resx_IsBlurTitle"));
            }
            else
            {
               MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "Resx_IsBlurFalse"), DemosGlobalization.GetResxString(GetType(), "Resx_IsBlurTitle"));
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show("Error : \n" + ex.Message);
         }
      }

      private void _menuItemPreferVector_Click(object sender, EventArgs e)
      {
         _menuItemPreferVector.Checked = !_menuItemPreferVector.Checked;
         _codecs.Options.Load.PreferVector = _menuItemPreferVector.Checked;
      }
   }
}
