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
using System.Drawing.Printing;
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
using Leadtools.Wia;
using Leadtools.Twain;
using Leadtools.WinForms.CommonDialogs.Color;
using Leadtools.Drawing;

namespace DocumentCleanupDemo
{
   public partial class MainForm : Form
   {
      private RasterCodecs _codecs;
      private RasterColor _fillColor;

      private TwainSession _twainSession;
      private bool _inTwainAcquire;
      private int _acquirePageCount;

      private WiaSession _wiaSession;
      private bool _wiaSourceSelected;
      private bool _wiaAcquiring;
      public ProgressForm _progressDlg;
      public WiaAcquireOptions _wiaAcquireOptions = WiaAcquireOptions.Empty;

      private RasterPaintProperties _paintProperties;
      private bool _animateRegions;
      private RawData _rawdataLoad;
      private RawData _rawdataSave;
      private static readonly float _minimumScaleFactor = 0.05f;
      private static readonly float _maximumScaleFactor = 11f;
      private ImageFileSaver _saver;
      private bool _useDpi = false;

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         if (RasterSupport.IsLocked(RasterSupportType.Document))
         {
            MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }

      public MainForm()
      {
         InitializeComponent();
         InitClass();
         _saver = new ImageFileSaver();
      }

      private void MainForm_Closing(object sender, CancelEventArgs e)
      {
         if (_inTwainAcquire)
            e.Cancel = true;
         CleanUp();
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

         if (_wiaSession != null)
         {
            try
            {
               _wiaSession.Shutdown();
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void InitClass()
      {
         Messager.Caption = "LEADTOOLS For .Net C# Document CleanUp";
         Text = Messager.Caption;

         // initialize the codecs object
         _codecs = new RasterCodecs();
         _codecs.Options.Txt.Load.Enabled = false;
         _fillColor = new RasterColor(255, 255, 255);
         _paintProperties = RasterPaintProperties.Default;
         _paintProperties.PaintEngine = RasterPaintEngine.GdiPlus;
         _paintProperties.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray;
         _animateRegions = false;
         _rawdataLoad = RawData.Default;
         _rawdataSave = RawData.Default;

         _wiaSourceSelected = false;
         _wiaAcquiring = false;

         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               // Determine whether a TWAIN source is installed.
               if (TwainSession.IsAvailable(this.Handle))
               {
                  _twainSession = new TwainSession();
                  // Start a TwainSession to acquire images from a Twain device.
                  // This method must be called before calling any other methods that require a TWAIN session.
                  _twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
                  _twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(_twainSession_AcquirePage);
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            _twainSession = null;
         }

         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               // Determine whether a WIA source is installed.
               if (WiaSession.IsAvailable(WiaVersion.Version1))
               {
                  _wiaSession = new WiaSession();
                  // Start a WiaSession to acquire images from a Wia device.
                  // This method must be called before calling any other methods that require a WIA session.
                  _wiaSession.Startup(WiaVersion.Version1);
                  _wiaSession.AcquireEvent += new EventHandler<WiaAcquireEventArgs>(_wiaSession_AcquireEvent);
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            _wiaSession = null;
         }
      }
      void _wiaSession_AcquireEvent(object sender, WiaAcquireEventArgs e)
      {
         // This event occurs for each page acquired using the Acquire method.
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
               NewImage(new ImageInformation(e.Image, "WIA Image"));
            else
               ActiveViewerForm.Image.AddPage(e.Image);

            _acquirePageCount++;
            Application.DoEvents();
         }
      }

      private void _twainSession_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         // This event occurs for each page acquired using the Acquire method.
         Application.DoEvents();

         if (e.Image != null)
         {
            if (_acquirePageCount == 1)
               NewImage(new ImageInformation(e.Image, "Twain Image"));
            else
               ActiveViewerForm.Image.AddPage(e.Image);

            _acquirePageCount++;
         }
      }

      private void _menuItemFileOpen_Click(object sender, EventArgs e)
      {
         LoadImage(false);
         UpdateMenus();
      }

      private void UpdateMenus()
      {
         _menuItemDocument.Enabled = false;

         if (ActiveViewerForm != null)
         {
            _menuItemFileSave.Enabled = true;
            editToolStripMenuItem.Enabled = true;
            vToolStripMenuItem.Enabled = true;
            imageToolStripMenuItem.Enabled = true;
            _menuItemFileSaveRaw.Enabled = true;
            _menuItemEditCopy.Enabled = true;
            _menuItemEditRegion.Enabled = true;
            _menuItemEditCancelRegion.Enabled = ActiveViewerForm.Viewer.Image.HasRegion;

            if (ActiveViewerForm.Viewer.Image.BitsPerPixel == 1)
               _menuItemDocument.Enabled = true;

            _menuItemMagGlassStart.Checked = ActiveViewerForm.IsMagGlass;
            _menuItemMagGlassStop.Checked = !ActiveViewerForm.IsMagGlass;
         }
         else
         {
            _menuItemFileSave.Enabled = false;
            vToolStripMenuItem.Enabled = false;
            imageToolStripMenuItem.Enabled = false;
            _menuItemDocument.Enabled = false;
            _menuItemFileSaveRaw.Enabled = false;
            _menuItemEditCopy.Enabled = false;
            _menuItemEditCancelRegion.Enabled = false;
            _menuItemEditRegion.Enabled = false;
         }

         RasterImage image = RasterClipboard.Paste(this.Handle);
         if (image != null)
            _menuItemEditPaste.Enabled = true;
         else
            _menuItemEditPaste.Enabled = false;

         _menuItemFileWiaSelectSource.Enabled = (_wiaSession != null && !_wiaAcquiring);
         _menuItemFileWiaAcquire.Enabled = (_wiaSession != null && _wiaSourceSelected && !_wiaAcquiring);
         EnableAndVisibleMenu(_menuItemFileTwainSelectSource, _twainSession != null);
         EnableAndVisibleMenu(_menuItemFileTwainAcquire, _twainSession != null);
         toolStripSeparator2.Visible = _twainSession != null;
      }

      private void EnableAndVisibleMenu(ToolStripMenuItem menu, bool value)
      {
         menu.Enabled = value;
         menu.Visible = value;
      }
      private void NewImage(ImageInformation info)
      {
         ViewerForm child = new ViewerForm();
         child.MdiParent = this;
         child.Viewer.Dock = DockStyle.Fill;
         child.Initialize(info, _paintProperties, _animateRegions, true, _useDpi);
         child.Viewer.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty);
         child.Disposed += new EventHandler(child_Disposed);
         child.Viewer.PropertyChanged += new PropertyChangedEventHandler(Viewer_PropertyChanged);
         child.Show();
      }

      void Viewer_PropertyChanged(object sender, PropertyChangedEventArgs e)
      {
         try
         {
            if (e.PropertyName == "WorkingInteractiveMode")
            {
               UpdateMenus();
            }
            throw new NotImplementedException();
         }
         catch (Exception)
         {
         }
      }


      private void LoadImage(bool loadDefaultImage)
      {
         // Load a defualt image on the viewer.
         ImageFileLoader loader = new ImageFileLoader();

         try
         {
            if (loadDefaultImage)
            {
               if (loader.Load(this, DemosGlobal.ImagesFolder + @"\clean.tif", _codecs, 1, 1))
               {
                  NewImage(new ImageInformation(loader.Image, loader.FileName));
               }
            }
            else
            {
               if (loader.Load(this, _codecs, true) > 0)
               {
                  NewImage(new ImageInformation(loader.Image, loader.FileName));
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }
      }

      private void child_Disposed(object sender, EventArgs e)
      {
         UpdateMenus();

      }

      private void Form1_MdiChildActivate(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;
         UpdateMenus();
      }

      public ViewerForm ActiveViewerForm
      {
         get
         {
            return ActiveMdiChild as ViewerForm;
         }
      }

      private void _menuItemFileSave_Click(object sender, EventArgs e)
      {
         try
         {
            DemosGlobal.SetDefaultComments(ActiveViewerForm.Viewer.Image, _codecs);
            _saver.Save(this, _codecs, ActiveViewerForm.Viewer.Image);
         }
         catch (Exception ex)
         {
            Messager.ShowFileSaveError(this, _saver.FileName, ex);
         }
      }

      private void _menuItemCleanupLineRemove_Click(object sender, EventArgs e)
      {
         try
         {
            LineRemoveCommand _LineRemove = null;
            LineRemoveDialog dlg = new LineRemoveDialog(new LineRemoveCommand(), ActiveViewerForm.Viewer.Image.XResolution, ActiveViewerForm.Viewer.Image.YResolution);
            // Open the LineRemoveCommand dialog
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               _LineRemove = new LineRemoveCommand();
               _LineRemove.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
               // Update the LineRemoveCommand.Type to select which lines to remove
               _LineRemove.Type = dlg.LineRemoveCommand.Type;
               // Update the LineRemoveCommand UseDpi flag 
               _LineRemove.Flags = dlg.LineRemoveCommand.Flags;
               // Update the LineRemoveCommand.GapLength to set the maximum length of a break or a hole in a line.
               _LineRemove.GapLength = dlg.LineRemoveCommand.GapLength;
               // Update the LineRemoveCommand.MaximumLineWidth to set the maximum average width of a line that is considered for removal.   
               _LineRemove.MaximumLineWidth = dlg.LineRemoveCommand.MaximumLineWidth;
               // Update the LineRemoveCommand.MinimumLineLength to set the minimum length of a line considered for removal.   
               _LineRemove.MinimumLineLength = dlg.LineRemoveCommand.MinimumLineLength;
               // Update the LineRemoveCommand.MaximumWallPercent to set the maximum number of wall slices (expressed as a percent of the total length of the line) that are allowed.
               _LineRemove.MaximumWallPercent = dlg.LineRemoveCommand.MaximumWallPercent;
               // Update LineRemoveCommand.Wall to set the height of a wall. Walls are slices of a line that are too wide to be considered part of the line. 
               _LineRemove.Wall = dlg.LineRemoveCommand.Wall;
               ProgressBar.Visible = true;
               // Run the command on the loaded image
               _LineRemove.Run(ActiveViewerForm.Viewer.Image);

            }

         }
         catch (RasterException ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void dotRemoveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            DotRemoveCommand _DotRemove = null;
            DotRemoveDialog dlg = new DotRemoveDialog(new DotRemoveCommand(), ActiveViewerForm.Viewer.Image.XResolution, ActiveViewerForm.Viewer.Image.YResolution);
            // Open the DotRemoveCommand Dialog
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               _DotRemove = new DotRemoveCommand();
               _DotRemove.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
               // Update the flags used to determine how to run this command.
               _DotRemove.Flags = dlg.DotRemoveCommand.Flags;
               // Update the DotRemoveCommand.MaximumDotHeight to set the maximum height of a dot to be removed.
               _DotRemove.MaximumDotHeight = dlg.DotRemoveCommand.MaximumDotHeight;
               // Update the DotRemoveCommand.MaximumDotWidth to set the maximum width of a dot to be removed.
               _DotRemove.MaximumDotWidth = dlg.DotRemoveCommand.MaximumDotWidth;
               // Update the DotRemoveCommand.MinimumDotHeight to set the minimum height of a dot to be removed.
               _DotRemove.MinimumDotHeight = dlg.DotRemoveCommand.MinimumDotHeight;
               // Update the DotRemoveCommand.MinimumDotWidth to set the minimum width of a dot to be removed.
               _DotRemove.MinimumDotWidth = dlg.DotRemoveCommand.MinimumDotWidth;
               ProgressBar.Visible = true;
               // Run the command on loaded image.
               _DotRemove.Run(ActiveViewerForm.Viewer.Image);
            }

         }
         catch (RasterException ex)
         {
            Messager.ShowError(this, ex);
         }

      }

      private void _menuItemCleanupHolePunchRemove_Click(object sender, EventArgs e)
      {
         try
         {
            HolePunchRemoveCommand _HolePunchRemove = null;

            HolePunchRemoveDialog dlg = new HolePunchRemoveDialog();
            // Open the HolePunchRemover Dialog.
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _HolePunchRemove = new HolePunchRemoveCommand();
               _HolePunchRemove.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
               // Update the HolePunchRemoveCommand flags that determine how to process it.
               _HolePunchRemove.Flags = dlg.Flags;
               // Update the HolePunchRemoveCommand.Location that indicates the location within the document of the hole punches to remove.
               _HolePunchRemove.Location = dlg.HoleLocation;
               // Update the HolePunchRemoveCommand.MaximumHoleCount to set the maximum number of holes to detect.
               _HolePunchRemove.MaximumHoleCount = dlg.MaxCount;
               // Update the HolePunchRemoveCommand.MinimumHoleCount to set the minimum number of holes to detect.
               _HolePunchRemove.MinimumHoleCount = dlg.MinCount;
               // Update the HolePunchRemoveCommand.MaximumHoleWidth to set the maximum width of one of the holes of the hole punch configuration to be removed.
               _HolePunchRemove.MaximumHoleWidth = dlg.MaxWidth;
               // Update the HolePunchRemoveCommand.MaximumHoleHeight to set the maximum height of one of the holes of the hole punch configuration to be removed.
               _HolePunchRemove.MaximumHoleHeight = dlg.MaxHeight;
               // Update the HolePunchRemoveCommand.MinimumHoleHeight to set the minimum height of one of the holes of the hole punch configuration to be removed.
               _HolePunchRemove.MinimumHoleWidth = dlg.MinWidth;
               // Update the HolePunchRemoveCommand.MinimumHoleWidth to set the minimum width of one of the holes of the hole punch configuration to be removed.
               _HolePunchRemove.MinimumHoleHeight = dlg.MinHeight;

               ProgressBar.Visible = true;
               // Run the HolePunchRemoveCommand on the loaded image.
               _HolePunchRemove.Run(ActiveViewerForm.Viewer.Image);
            }

         }
         catch (RasterException ex)
         {
            Messager.ShowError(this, ex);
         }

      }
      void Command_Progress(object sender, RasterCommandProgressEventArgs e)
      {
         ProgressBar.Value = e.Percent;
         if (e.Percent == 100)
            ProgressBar.Visible = false;
      }
      private void borderRemoveToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            BorderRemoveCommand _BorderRemove = null;

            BorderRemoveDialog dlg = new BorderRemoveDialog(new BorderRemoveCommand());
            // Open BorderRemove Dialog.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               _BorderRemove = new BorderRemoveCommand();
               _BorderRemove.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
               // Update the BorderRemoveCommand.Border Flag to indicate which border to remove.
               _BorderRemove.Border = dlg.BorderRemoveCommand.Border;
               // Update the BorderRemoveCommand.Flags to determine the behavior of the border removal process.
               _BorderRemove.Flags = dlg.BorderRemoveCommand.Flags;
               // Update the BorderRemoveCommand.Percent to set the percent of the image dimension in which the border will be found.
               _BorderRemove.Percent = dlg.BorderRemoveCommand.Percent;
               // Update BorderRemoveCommand.Variance to set the amount of variance tolerated in the border.  
               _BorderRemove.Variance = dlg.BorderRemoveCommand.Variance;
               // Update the BorderRemoveCommand.WhiteNoiseLength to set the amount of white noise tolerated when determining the border.
               _BorderRemove.WhiteNoiseLength = dlg.BorderRemoveCommand.WhiteNoiseLength;
               ProgressBar.Visible = true;
               // Run the BorderRemoveCommand on the loaded image.
               _BorderRemove.Run(ActiveViewerForm.Viewer.Image);

            }

         }
         catch (RasterException ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void characterSmoothToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            SmoothCommand _Smooth = null;
            // Open the SmoothCommand dialog.
            SmoothTextDialog dlg = new SmoothTextDialog(new SmoothCommand());
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               _Smooth = new SmoothCommand();
               _Smooth.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
               // Update the command with selected flags value SmoothCommandFlags.FavorLong or SmoothCommandFlags.FavorShor.
               _Smooth.Flags = dlg.SmoothCommand.Flags;
               // Update the SmoothCommand.Length property.
               if (dlg.SmoothCommand.Length == 0)
                  _Smooth.Length = 1;
               else
                  _Smooth.Length = dlg.SmoothCommand.Length;

               ProgressBar.Visible = true;
               // Apply the command on the loaded image.
               _Smooth.Run(ActiveViewerForm.Viewer.Image);
            }
         }
         catch (RasterException ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _menuItemFileTwainSelectSource_Click(object sender, EventArgs e)
      {
         // Display the TWAIN dialog box to be used to select a TWAIN source for acquiring images
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
         // Acquire one or more images from a TWAIN source.
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

      private void _menuItemFileWiaSelectSource_Click(object sender, EventArgs e)
      {
         // Display the WIA dialog box to be used to select a WIA source for acquiring images.
         try
         {
            if (_wiaSession != null)
            {
               DialogResult res = _wiaSession.SelectDeviceDlg(this.Handle, WiaDeviceType.Default, WiaSelectSourceFlags.NoDefault);
               if (res == DialogResult.OK)
               {
                  _wiaSourceSelected = true;
               }
            }

            UpdateMenus();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            _wiaSourceSelected = false;
         }
      }

      private void _menuItemFileWiaAcquire_Click(object sender, EventArgs e)
      {
         // Acquire one or more images from a WIA source.
         try
         {
            _wiaAcquiring = true;
            _acquirePageCount = 1;

            // Disable the minimize and maximize buttons.
            this.MinimizeBox = false;
            this.MaximizeBox = false;

            if (_wiaSession.SelectedDeviceType != WiaDeviceType.Scanner)
            {
               _wiaAcquireOptions.FileName = "C:\\WiaTest.jpg";
               _wiaSession.AcquireOptions = _wiaAcquireOptions;
            }

            this._mainMenu.Enabled = false;

            _progressDlg = new ProgressForm("Transferring...", "", 100);
            _progressDlg.Show(this);

            _wiaSession.Acquire(this.Handle, null, WiaAcquireFlags.ShowUserInterface | WiaAcquireFlags.UseCommonUI);
            this._mainMenu.Enabled = true;

            // Enable back the minimize and maximize buttons.
            this.MinimizeBox = true;
            this.MaximizeBox = true;

            if (_progressDlg.Visible)
            {
               if (!_progressDlg.Abort)
                  _progressDlg.Dispose();
            }

            if (_wiaSession.FilesCount > 0)  // This property indicates how many files where saved when the transfer mode is File mode.
            {
               string strMsg = "Acquired page(s) were saved to:\n\n";
               if (_wiaSession.FilesPaths.Count > 0)
               {
                  for (int i = 0; i < _wiaSession.FilesPaths.Count; i++)
                  {
                     string strTemp = string.Format("{0}\n", _wiaSession.FilesPaths[i]);
                     strMsg += strTemp;
                  }
                  MessageBox.Show(this, strMsg, "File Transfer", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
            }

            _wiaAcquiring = false;

            UpdateMenus();
         }
         catch (Exception ex)
         {
            this._mainMenu.Enabled = true;

            // Enable back the minimize and maximize buttons.
            this.MinimizeBox = true;
            this.MaximizeBox = true;

            _wiaAcquiring = false;

            if (_progressDlg.Visible)
            {
               if (!_progressDlg.Abort)
                  _progressDlg.Dispose();
            }

            Messager.ShowError(this, ex);
         }
         finally
         {
            _acquirePageCount = -1;
            UpdateMenus();
         }
      }

      private void _menuItemFileExit_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _menuItemCleanupInvertedText_Click(object sender, EventArgs e)
      {
         try
         {
            InvertedTextCommand _InvertedText = null;

            InvertedTextDialog dlg = new InvertedTextDialog(new InvertedTextCommand(), ActiveViewerForm.Viewer.Image.XResolution, ActiveViewerForm.Viewer.Image.YResolution);
            // Open the InvertedText dialog.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               _InvertedText = new InvertedTextCommand();
               _InvertedText.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
               // Update the InvertedTextCommand.Flags to determine how this command will process.
               _InvertedText.Flags = dlg.InvertedTextCommand.Flags;
               // Update the InvertedTextCommand.MaximumBlackPercent to set the maximum percent of total pixels in an inverted text area that must be black.
               _InvertedText.MaximumBlackPercent = dlg.InvertedTextCommand.MaximumBlackPercent;
               // Update the InvertedTextCommand.MinimumBlackPercent to set the minimum percent of total pixels in an inverted text area that must be black.
               _InvertedText.MinimumBlackPercent = dlg.InvertedTextCommand.MinimumBlackPercent;
               // Update the InvertedTextCommand.MinimumInvertHeight to set the minimum height of an area that is considered to be inverted text.
               _InvertedText.MinimumInvertHeight = dlg.InvertedTextCommand.MinimumInvertHeight;
               // InvertedTextCommand.MinimumInvertWidth to set the minimum Width of an area that is considered to be inverted text.
               _InvertedText.MinimumInvertWidth = dlg.InvertedTextCommand.MinimumInvertWidth;

               ProgressBar.Visible = true;
               // Run the command on the loaded image.
               _InvertedText.Run(ActiveViewerForm.Viewer.Image);
            }
         }
         catch (RasterException ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _menuItemCleanupDeskew_Click(object sender, EventArgs e)
      {
         try
         {
            DeskewCommand _Deskew = null;

            DeskewDialog dlg = new DeskewDialog(new DeskewCommand());
            // Open the DeskewCommand dialog.
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               _Deskew = new DeskewCommand();
               _Deskew.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
               // Update the DeskewCommandFlags, these flags will indicate whether to deskew the image, which background color to use, whether to deskew the image if the skew angle is very small, which type of interpolation to use, whether the image contains mostly text, and whether to use normal or fast rotation.
               _Deskew.Flags = dlg.DeskewCommand.Flags;
               // Update the DeskewCommandFlags.FillExposedArea to fill areas exposed by rotation using the FillColor property.
               _Deskew.FillColor = dlg.DeskewCommand.FillColor;
               ProgressBar.Visible = true;
               // Run the DeskewCommand on the loaded image.
               _Deskew.Run(ActiveViewerForm.Viewer.Image);
            }
         }
         catch (RasterException ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _menuItemCleanupDespeckle_Click(object sender, EventArgs e)
      {
         try
         {
            DespeckleCommand _Despeckle = new DespeckleCommand();
            //Remove speckles from the image.
            _Despeckle.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
            ProgressBar.Visible = true;
            // Run the DespeckleCommand on the loaded image.
            _Despeckle.Run(ActiveViewerForm.Viewer.Image);
         }
         catch (RasterException ex)
         {
            Messager.ShowError(this, ex);
         }

      }

      private void _menuItemCleanupInverte_Click(object sender, EventArgs e)
      {
         InvertCommand _Invert = new InvertCommand();
         //Invert the colors of the image.
         _Invert.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
         ProgressBar.Visible = true;
         // Run the InvertCommand on the loaded image.
         _Invert.Run(ActiveViewerForm.Viewer.Image);

      }

      private void _menuItemCleanupfillWhite_Click(object sender, EventArgs e)
      {
         // Fill the image with White color.
         FillCommand command = new FillCommand();
         command.Color = new RasterColor(255, 255, 255);

         command.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
         ProgressBar.Visible = true;
         // Run the FillCommand on the loaded image.
         command.Run(ActiveViewerForm.Viewer.Image);
      }

      private void _menuItemCleanupfillBlack_Click(object sender, EventArgs e)
      {
         // Fill the image with Black color.
         FillCommand command = new FillCommand();
         command.Color = new RasterColor(0, 0, 0);

         command.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
         ProgressBar.Visible = true;
         // Run the FillCommand on the loaded image.
         command.Run(ActiveViewerForm.Viewer.Image);
      }

      private void _menuItemCleanupDilate_Click(object sender, EventArgs e)
      {
         // Apply the Minimum filter using MinimumCommand.  
         MinimumCommand command = new MinimumCommand();
         // Update the MinimumCommand.Dimension property.
         command.Dimension = 3;

         ProgressBar.Visible = true;
         command.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
         // Run the MinimumCommand on th eloaded image.
         command.Run(ActiveViewerForm.Viewer.Image);
      }

      private void _menuItemCleanupErode_Click(object sender, EventArgs e)
      {
         // Apply the Maximum filter using MaximumCommand. 
         MaximumCommand command = new MaximumCommand();
         // Update the MaximumCommand.Dimension property.
         command.Dimension = 3;

         command.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
         ProgressBar.Visible = true;
         // Run the MinimumCommand on th eloaded image.
         command.Run(ActiveViewerForm.Viewer.Image);
      }

      private void _menuItemImageRotateAnyAngle_Click(object sender, EventArgs e)
      {
         // Apply the RotateCommand.
         RotateCommand _Rotate = null;

         RotateDialog dlg = new RotateDialog();
         // Open the Rotate dialog.
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            // Update the RotateCommand members.
            _Rotate = new RotateCommand(dlg.Angle, dlg.Flags, dlg.FillColor);
            // Run the RotateCommand on the loaded image.
            _Rotate.Run(ActiveViewerForm.Viewer.Image);
         }

      }

      private void _menuItemImageRotateRight90_Click(object sender, EventArgs e)
      {
         RotateCommand _Rotate = null;
         // Run the RotateCommand on the loaded image with 90 degree angle to the right.
         _Rotate = new RotateCommand(90 * 100, RotateCommandFlags.Resize, new RasterColor(0, 0, 0));
         _Rotate.Run(ActiveViewerForm.Viewer.Image);

      }

      private void _menuItemImageRotateLeft90_Click(object sender, EventArgs e)
      {
         RotateCommand _Rotate = null;
         // Run the RotateCommand on the loaded image with 90 degree angle to the left.
         _Rotate = new RotateCommand(-90 * 100, RotateCommandFlags.Resize, new RasterColor(0, 0, 0));
         _Rotate.Run(ActiveViewerForm.Viewer.Image);
      }

      private void rotate180DegreesToolStripMenuItem_Click(object sender, EventArgs e)
      {
         RotateCommand _Rotate = null;
         // Run the RotateCommand on the loaded image with 180 degree angle.
         _Rotate = new RotateCommand(180 * 100, RotateCommandFlags.Resize, new RasterColor(0, 0, 0));
         _Rotate.Run(ActiveViewerForm.Viewer.Image);
      }

      private void _menuItemImageflipHorizontal_Click(object sender, EventArgs e)
      {
         // Flip the image horizontally (reverse) 
         FlipCommand cmd = new FlipCommand();
         cmd.Horizontal = true;
         cmd.Run(ActiveViewerForm.Viewer.Image);

      }

      private void _menuItemImagflipVerticalToolStripMenuItem_Click(object sender, EventArgs e)
      {
         // Flip the image horizontally (reverse) 
         FlipCommand cmd = new FlipCommand();
         cmd.Horizontal = false;
         cmd.Run(ActiveViewerForm.Viewer.Image);

      }

      private void _menuItemResize_Click(object sender, EventArgs e)
      {
         SizeCommand _Resize = null;

         ResizeDialog dlg = new ResizeDialog(ActiveViewerForm.Viewer.Image.Width, ActiveViewerForm.Viewer.Image.Height);
         // Open the ResizeCommand dialog.
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            // Update the ResizeCommand members.
            _Resize = new SizeCommand(dlg.ImageWidth, dlg.ImageHeight, dlg.Flags);
            // Run the ResizeCommand on the loaded image.
            _Resize.Run(ActiveViewerForm.Viewer.Image);
         }
      }

      private void _menuItemEditCopy_Click(object sender, EventArgs e)
      {
         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               // Call the RasterClipboard.Copy to copy the loaded image to a clipboard.
               RasterClipboard.Copy(
                  this.Handle,
                  ActiveViewerForm.Viewer.Image,
                  RasterClipboardCopyFlags.Empty |
                  RasterClipboardCopyFlags.Dib |
                  RasterClipboardCopyFlags.Palette |
                  RasterClipboardCopyFlags.Region);

               UpdateMenus();

            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateMenus();
         }
      }

      private void _menuItemEditPaste_Click(object sender, EventArgs e)
      {
         try
         {
            using (WaitCursor wait = new WaitCursor())
            {
               // Call the RasterClipboard.Paste to copy image data from the clipboard.
               RasterImage image = RasterClipboard.Paste(this.Handle);
               if (image != null)
               {
                  ViewerForm activeForm = ActiveViewerForm;

                  if (image.HasRegion && activeForm == null)
                     image.MakeRegionEmpty();
                  NewImage(new ImageInformation(image));
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }

      }

      private void _menuItemEditRegion_Click(object sender, EventArgs e)
      {
         ImageViewer viewer = ActiveViewerForm.Viewer;

         ImageViewerAddRegionInteractiveMode regionInteractiveMode = new ImageViewerAddRegionInteractiveMode();
         regionInteractiveMode.AutoRegionToFloater = false;

         if (sender == _menuItemEditRegionRectangle)
         {
            regionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle; //change the shape to rectangle
         }
         else if (sender == _menuItemEditRegionEllipse)
         {
            regionInteractiveMode.Shape = ImageViewerRubberBandShape.Ellipse; //change the shape to ellipse
         }
         else if (sender == _menuItemEditRegionFreehand)
         {
            regionInteractiveMode.Shape = ImageViewerRubberBandShape.Freehand;  //change the shape to freehand
         }

         viewer.InteractiveModes.BeginUpdate();
         viewer.InteractiveModes.Clear();
         viewer.InteractiveModes.Add(regionInteractiveMode);
         viewer.InteractiveModes.EndUpdate();

         ActiveViewerForm.IsMagGlass = false;
         UpdateMenus();
      }

      private void _menuItemEditCancelRegion_Click(object sender, EventArgs e)
      {
         CancelFloater();
      }
      private void CancelFloater()
      {
         // Delete drawn region.
         try
         {
            if (ActiveViewerForm.Viewer.Image.HasRegion)
            {
               ActiveViewerForm.Viewer.Image.MakeRegionEmpty();
               ActiveViewerForm.Viewer.InteractiveModes.BeginUpdate();
               ActiveViewerForm.Viewer.InteractiveModes.Clear();
               ActiveViewerForm.Viewer.InteractiveModes.EndUpdate();
            }

            UpdateMenus();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _menuItemViewSizeModeNormal_Click(object sender, EventArgs e)
      {
         // Display the loaded image with 100% Zoom.
         ActiveViewerForm.Viewer.BeginUpdate();
         ActiveViewerForm.Viewer.Zoom(ControlSizeMode.None, 1, LeadPoint.Empty);
         ActiveViewerForm.Viewer.EndUpdate();
      }

      private void _menuItemViewSizeModeStretch_Click(object sender, EventArgs e)
      {
         // Display the loaded image setting the Width the Height to the same value of the viewer width and height without maintaining the aspect ratio.
         ActiveViewerForm.Viewer.BeginUpdate();
         ActiveViewerForm.Viewer.Zoom(ControlSizeMode.Stretch, 1, LeadPoint.Empty);
         ActiveViewerForm.Viewer.EndUpdate();
      }

      private void _menuItemViewSizeModeFitAlways_Click(object sender, EventArgs e)
      {
         // Display the loaded image setting the Width the Height to the same value of the viewer width and height maintaining the aspect ratio.
         ActiveViewerForm.Viewer.BeginUpdate();
         ActiveViewerForm.Viewer.Zoom(ControlSizeMode.FitAlways, 1, LeadPoint.Empty);
         ActiveViewerForm.Viewer.EndUpdate();
      }

      private void _menuItemViewSizeModeFitWidth_Click(object sender, EventArgs e)
      {
         // Display the loaded image setting the Width to the same value of the viewer width.
         ActiveViewerForm.Viewer.BeginUpdate();
         ActiveViewerForm.Viewer.Zoom(ControlSizeMode.FitWidth, 1, LeadPoint.Empty);
         ActiveViewerForm.Viewer.EndUpdate();
      }

      private void _menuItemViewSizeModeFit_Click(object sender, EventArgs e)
      {
         // Display the loaded image with its original Width and height.
         ActiveViewerForm.Viewer.BeginUpdate();
         ActiveViewerForm.Viewer.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty);
         ActiveViewerForm.Viewer.EndUpdate();
      }

      private void _menuItemViewSizeModeSnap_Click(object sender, EventArgs e)
      {
         ActiveViewerForm.Viewer.BeginUpdate();
         ActiveViewerForm.Snap();
         if (ActiveViewerForm.WindowState != FormWindowState.Normal)
            ActiveViewerForm.WindowState = FormWindowState.Normal;
         ActiveViewerForm.Viewer.Zoom(ActiveViewerForm.Viewer.SizeMode, 1, LeadPoint.Empty);
         ActiveViewerForm.Viewer.EndUpdate();
      }

      private void _menuItemViewAlignModeHorizontalNear_Click(object sender, EventArgs e)
      {
         // Display the loaded image on the left Horizontal side of the viwere.
         ActiveViewerForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Near;
      }

      private void _menuItemViewAlignModeHorizontalCenter_Click(object sender, EventArgs e)
      {
         // Display the loaded image on the center Horizontal side of the viwere.
         ActiveViewerForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Center;
      }

      private void _menuItemViewAlignModeHorizontalFar_Click(object sender, EventArgs e)
      {
         // Display the loaded image on the right Horizontal side of the viwere.
         ActiveViewerForm.Viewer.ViewHorizontalAlignment = ControlAlignment.Far;
      }

      private void _menuItemViewAlignModeVerticalNear_Click(object sender, EventArgs e)
      {
         // Display the loaded image on the top Vertical side of the viwere.
         ActiveViewerForm.Viewer.ViewVerticalAlignment = ControlAlignment.Near;
      }

      private void _menuItemViewAlignModeVerticalCenter_Click(object sender, EventArgs e)
      {
         // Display the loaded image on the center Vertical side of the viwere.
         ActiveViewerForm.Viewer.ViewVerticalAlignment = ControlAlignment.Center;
      }

      private void _menuItemViewAlignModeVerticalFar_Click(object sender, EventArgs e)
      {
         // Display the loaded image on the bottom Vertical side of the viwere.
         ActiveViewerForm.Viewer.ViewVerticalAlignment = ControlAlignment.Far;
      }

      private void ViewZoom(int zoom)
      {
         ImageViewer viewer = ActiveViewerForm.Viewer; // get the active viewer

         // zoom     
         double scaleFactor = viewer.ScaleFactor;
         const float ratio = 1.2F;

         if (zoom == 1)
         {
            scaleFactor *= ratio;
         }
         else if (zoom == 2)
         {
            scaleFactor /= ratio;
         }
         else if (zoom == 3)
         {
            scaleFactor = 1;
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
         }
      }

      private void _menuItemViewZoomIn_Click(object sender, EventArgs e)
      {
         // Display the image with increased zoom level.
         ViewZoom(1);
      }

      private void _menuItemViewZoomOut_Click(object sender, EventArgs e)
      {
         // Display the image with decreased zoom level.
         ViewZoom(2);
      }

      private void _menuItemViewZoomNormal_Click(object sender, EventArgs e)
      {
         // Diaplay the image with 100% zoom level.
         ViewZoom(3);
      }

      private void _menuItemViewZoomValue_Click(object sender, EventArgs e)
      {
         // Display the image with custom zoom level (User specify the zoom level value).
         ViewZoom(4);
      }

      private void _menuItemImageColorResolution_Click(object sender, EventArgs e)
      {
         ColorResolutionCommand _ColorResolution = null;

         ColorResolutionDialog dlg = new ColorResolutionDialog(new ColorResolutionCommand(), ActiveViewerForm.Viewer.Image.BitsPerPixel);
         // Open the ColorResolution dialog.
         if (dlg.ShowDialog() == DialogResult.OK)
         {
            _ColorResolution = new ColorResolutionCommand();
            _ColorResolution.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
            // Update the behaviour of the ColorResolutionCommand. 
            _ColorResolution.Mode = dlg.ColorResolutionCommand.Mode;
            // Update the ColorResolutionCommand.BitsPerPixel to set the number of bits per pixel for the conversion
            _ColorResolution.BitsPerPixel = dlg.ColorResolutionCommand.BitsPerPixel;
            // Update the ColorResolutionCommand.Order to set the desired color byte order of the image data for the conversion.
            _ColorResolution.Order = dlg.ColorResolutionCommand.Order;
            // Update the ColorResolutionCommand.DitheringMethod to set the dithering options used when converted the image.
            _ColorResolution.DitheringMethod = dlg.ColorResolutionCommand.DitheringMethod;
            // Update the ColorResolutionCommand.PaletteFlags to set the Palette options used when converted the image.
            _ColorResolution.PaletteFlags = dlg.ColorResolutionCommand.PaletteFlags;
            // Run the ColorResolutionCommand on the loaded image.
            _ColorResolution.Run(ActiveViewerForm.Viewer.Image);

            ActiveViewerForm.UpdateDataAfterCommand();

            UpdateMenus();

         }
      }

      private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Document Cleanup", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _menuItemFileOpenRaw_Click(object sender, EventArgs e)
      {
         try
         {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = @"All Files (*.*)|*.*|RAW (*.raw)|*.raw|Fax (*.fax)|*.fax|ABIC (*.abic;*.abc)|*.abic;*.abc";
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
               MessageBox.Show("Invalid File Parameter " + ex.Message);
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

      private void _menuItemFileSaveRaw_Click(object sender, EventArgs e)
      {
         ImageFileSaver saver = new ImageFileSaver();

         try
         {
            //CombineFloater();
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
               MessageBox.Show("Invalid File Parameter " + ex.Message);
            }
         }
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (_inTwainAcquire)
            e.Cancel = true;
      }

      private void MainForm_Activated(object sender, EventArgs e)
      {
         UpdateMenus();
      }

      private void MainForm_DragDrop(object sender, DragEventArgs e)
      {
         if (Tools.CanDrop(e.Data))
         {
            string[] files = Tools.GetDropFiles(e.Data);
            if (files != null)
               LoadDropFiles(null, files);
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
                     UpdateMenus();
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
      }
      private void MainForm_DragEnter(object sender, DragEventArgs e)
      {
         if (Tools.CanDrop(e.Data))
            e.Effect = DragDropEffects.Copy;
      }

      private void MainForm_Load(object sender, EventArgs e)
      {
         LoadImage(true);
         UpdateMenus();
      }

      private void rrrToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Clipboard.Clear();
         UpdateMenus();
      }

      public static string IsValidNumber(string OrgStr, float minVal, float maxVal)
      {
         string str = "";

         foreach (char c1 in OrgStr)
            if (char.IsNumber(c1))
               str += c1.ToString();
         if (str != "")
         {
            if (float.Parse(str) < minVal)
               str = minVal.ToString();

            if (float.Parse(str) > maxVal)
               str = maxVal.ToString();
         }

         return str;
      }

      private void _menuItemImagefillImage_Click(object sender, EventArgs e)
      {
         // Use the FillCommand to fill the image with a specified color
         FillCommand command = new FillCommand();
         command.Color = new RasterColor(0, 0, 0);

         ColorDialog dlg = new ColorDialog();

         if (dlg.ShowDialog() == DialogResult.OK)
         {
            command.Color = Converters.FromGdiPlusColor(dlg.Color);
            command.Progress += new EventHandler<RasterCommandProgressEventArgs>(Command_Progress);
            ProgressBar.Visible = true;
            command.Run(ActiveViewerForm.Viewer.Image);
         }
      }

      private void _menuItemMagGlassStart_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;
         activeForm.StartMagGlass();
         UpdateMenus();
      }

      private void _menuItemMagGlassStop_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;
         activeForm.StopMagGlass();
         UpdateMenus();
      }

      private void _menuItemHistogram_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;
         activeForm.Histogram();
      }
   }
}
