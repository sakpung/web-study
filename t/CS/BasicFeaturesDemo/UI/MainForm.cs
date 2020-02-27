// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Effects;

namespace BasicFeaturesDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : Form
   {
      private MainMenu _mmMain;
      private MenuItem _miFileOpen;
      private MenuItem _miFile;
      private MenuItem _miFileSep1;
      private MenuItem _miFileExit;
      private MenuItem _miBasicFeatures;
      private MenuItem _miBasicFeaturesBatch1;
      private MenuItem _miBasicFeaturesBatch2;
      private MenuItem _miBasicFeaturesUnderlay;
      private MenuItem _miBasicFeaturesGetSetRow;
      private MenuItem _miHelp;
      private MenuItem _miHelpAbout;
      private IContainer components;

      public MainForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
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
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mmMain = new System.Windows.Forms.MainMenu(this.components);
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileOpen = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miBasicFeatures = new System.Windows.Forms.MenuItem();
         this._miBasicFeaturesBatch1 = new System.Windows.Forms.MenuItem();
         this._miBasicFeaturesBatch2 = new System.Windows.Forms.MenuItem();
         this._miBasicFeaturesUnderlay = new System.Windows.Forms.MenuItem();
         this._miBasicFeaturesGetSetRow = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miBasicFeatures,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileOpen,
            this._miFileSep1,
            this._miFileExit});
         this._miFile.Text = "&File";
         // 
         // _miFileOpen
         // 
         this._miFileOpen.Index = 0;
         this._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this._miFileOpen.Text = "&Open...";
         this._miFileOpen.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileSep1
         // 
         this._miFileSep1.Index = 1;
         this._miFileSep1.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 2;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miBasicFeatures
         // 
         this._miBasicFeatures.Index = 1;
         this._miBasicFeatures.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miBasicFeaturesBatch1,
            this._miBasicFeaturesBatch2,
            this._miBasicFeaturesUnderlay,
            this._miBasicFeaturesGetSetRow});
         this._miBasicFeatures.Text = "&Basic Features";
         // 
         // _miBasicFeaturesBatch1
         // 
         this._miBasicFeaturesBatch1.Index = 0;
         this._miBasicFeaturesBatch1.Text = "Batch &1";
         this._miBasicFeaturesBatch1.Click += new System.EventHandler(this._miBasicFeaturesBatch1_Click);
         // 
         // _miBasicFeaturesBatch2
         // 
         this._miBasicFeaturesBatch2.Index = 1;
         this._miBasicFeaturesBatch2.Text = "Batch &2";
         this._miBasicFeaturesBatch2.Click += new System.EventHandler(this._miBasicFeaturesBatch2_Click);
         // 
         // _miBasicFeaturesUnderlay
         // 
         this._miBasicFeaturesUnderlay.Index = 2;
         this._miBasicFeaturesUnderlay.Text = "&Underlay";
         this._miBasicFeaturesUnderlay.Click += new System.EventHandler(this._miBasicFeaturesUnderlay_Click);
         // 
         // _miBasicFeaturesGetSetRow
         // 
         this._miBasicFeaturesGetSetRow.Index = 3;
         this._miBasicFeaturesGetSetRow.Text = "Get/Set Row";
         this._miBasicFeaturesGetSetRow.Click += new System.EventHandler(this._miBasicFeaturesGetSetRow_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 2;
         this._miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miHelpAbout});
         this._miHelp.Text = "&Help";
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Index = 0;
         this._miHelpAbout.Text = "&About...";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(552, 401);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.ResumeLayout(false);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         Application.Run(new MainForm());
      }

      // the raster image viewer
      private ImageViewer _viewer;

      // the raster codecs used in load/save
      RasterCodecs _codecs;
      private string _openInitialPath = string.Empty;
      /// <summary>
      /// Initialize the application
      /// </summary>
      private void MainForm_Load(object sender, EventArgs e)
      {
         // setup our caption
         Messager.Caption = "LEADTOOLS for .NET C# Basic Features Demo";
         Text = Messager.Caption;

         // initialize the _viewer object
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();

         // initialize the codecs object
         _codecs = new RasterCodecs();

         UpdateMyControls();
      }

      /// <summary>
      /// Update the UI depending on the program state
      /// </summary>
      private void UpdateMyControls()
      {
         // update the menu items
         if (_viewer.Image != null)
         {
            _miBasicFeatures.Enabled = true;
            _miBasicFeatures.Visible = true;
         }
         else
         {
            _miBasicFeatures.Enabled = false;
            _miBasicFeatures.Visible = false;
         }
      }

      /// <summary>
      /// load a new image
      /// </summary>
      private void _miFileOpen_Click(object sender, EventArgs e)
      {
         try
         {
            // load the image
            ImageFileLoader loader = new ImageFileLoader();
            loader.OpenDialogInitialPath = _openInitialPath;
            if (loader.Load(this, _codecs, true) <= 0) return;
            _openInitialPath = Path.GetDirectoryName(loader.FileName);
            // update the caption
            Text = string.Format("{0} - {1}", loader.FileName, Messager.Caption);

            //set the new image in the viewer
            _viewer.Image = loader.Image;
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateMyControls();
         }
      }

      /// <summary>
      /// Shutdown
      /// </summary>
      private void _miFileExit_Click(object sender, EventArgs e)
      {
         Close();
      }

      /// <summary>
      /// Select the Batch 1 functions
      /// </summary>
      private void _miBasicFeaturesBatch1_Click(object sender, EventArgs e)
      {
         const string message = @"Batch1 does the following:
   1. Color Resolution
   2. Flip
   3. Intensity
   4. Resize
   5. Rotate";

         Messager.ShowInformation(this, message);
         DoBatch1();
      }

      /// <summary>
      /// Batch 1 Functions
      /// </summary>
      private void DoBatch1()
      {
         // save the current caption
         string tmpCaption = Text;
         // change cursor
         Cursor = Cursors.SizeNS;
         // disable the form
         Enabled = false;
         // Do Color Resolution
         Text = "Optimizing Image To 8 Bits Per Pixel With Burkes Dithering...";
         ColorResolutionCommand colorResCommand = new ColorResolutionCommand();
         colorResCommand.BitsPerPixel = 8;
         colorResCommand.DitheringMethod = RasterDitheringMethod.Burkes;
         colorResCommand.PaletteFlags = ColorResolutionCommandPaletteFlags.Optimized;
         colorResCommand.Mode = ColorResolutionCommandMode.InPlace;
         colorResCommand.Order = RasterByteOrder.Bgr;
         colorResCommand.SetPalette(null);
         colorResCommand.Run(_viewer.Image);
         Text = "Image Is Optimized";
         _viewer.Refresh();
         Thread.Sleep(2000);

         // change cursor
         Cursor = Cursors.SizeWE;
         // Do Flip
         Text = "Flipping Image...";
         FlipCommand flipCommand = new FlipCommand();
         flipCommand.Horizontal = false;
         flipCommand.Run(_viewer.Image);
         Text = "Image Is Flipped";
         _viewer.Refresh();
         Thread.Sleep(2000);

         // change cursor
         Cursor = Cursors.SizeNS;
         // Do Lightening
         Text = "Lightening Image...";
         ChangeIntensityCommand changeIntensityCommand = new ChangeIntensityCommand();
         changeIntensityCommand.Brightness = 200;
         changeIntensityCommand.Run(_viewer.Image);
         Text = "Image Is Lightened";
         _viewer.Refresh();
         Thread.Sleep(2000);

         // change cursor
         Cursor = Cursors.SizeWE;
         // Do Resize
         Text = "Resizing Image...";
         ResizeCommand resizeCommand = new ResizeCommand();
         resizeCommand.Flags = RasterSizeFlags.None;
         resizeCommand.DestinationImage = new RasterImage(RasterMemoryFlags.Conventional,
            (_viewer.Image.Width + 1) / 2,
            (_viewer.Image.Height + 1) / 2,
            _viewer.Image.BitsPerPixel,
            _viewer.Image.Order,
            _viewer.Image.ViewPerspective,
            _viewer.Image.GetPalette(),
            IntPtr.Zero,
            0);
         resizeCommand.Run(_viewer.Image);
         _viewer.Image = resizeCommand.DestinationImage;
         Text = "Image Is Resized";
         _viewer.Refresh();
         Thread.Sleep(2000);

         Cursor = Cursors.SizeNS;
         // Do Rotate
         Text = "Rotating Image...";
         RotateCommand rotateCommand = new RotateCommand();
         rotateCommand.Angle = -4500;
         rotateCommand.FillColor = new RasterColor(255, 0, 0);
         rotateCommand.Flags = RotateCommandFlags.None;

         rotateCommand.Run(_viewer.Image);
         Text = "Image Is Rotated, Batch Is Complete";
         _viewer.Refresh();
         Thread.Sleep(2000);

         // change the cursor to arrow
         Cursor = Cursors.Arrow;

         // return the old caption
         Text = tmpCaption;

         // enable the form
         Enabled = true;
      }

      /// <summary>
      /// Select the Batch 2 functions
      /// </summary>
      private void _miBasicFeaturesBatch2_Click(object sender, EventArgs e)
      {
         const string message = @"Batch2 does the following:
   1. AntiAliasing
   2. Reverse
   3. Grayscale
   4. Invert";

         Messager.ShowInformation(this, message);
         DoBatch2();
      }

      /// <summary>
      /// Batch 2 Functions
      /// </summary>
      private void DoBatch2()
      {
         // save the current caption
         string tmpCaption = Text;

         // disable the form
         Enabled = false;

         // change cursor
         Cursor = Cursors.SizeNS;

         // Do AntiAlias
         Text = "AntiAliasing Image...";
         AntiAliasingCommand antiAliasingCommand = new AntiAliasingCommand();
         antiAliasingCommand.Threshold = 25;
         antiAliasingCommand.Dimension = 7;
         antiAliasingCommand.Filter = AntiAliasingCommandType.Type1;
         antiAliasingCommand.Run(_viewer.Image);
         Text = "Image Is AntiAliased";
         _viewer.Refresh();
         Thread.Sleep(2000);

         // change cursor
         Cursor = Cursors.SizeWE;
         // Do Reverse
         Text = "Reversing Image...";
         FlipCommand flipCommand = new FlipCommand();
         flipCommand.Horizontal = true;
         flipCommand.Run(_viewer.Image);
         Text = "Image Is Reversed";
         _viewer.Refresh();
         Thread.Sleep(2000);

         // change cursor
         Cursor = Cursors.SizeNS;
         // Do Grayscale
         Text = "Grayscaling Image...";
         GrayscaleCommand grayScaleCommand = new GrayscaleCommand();
         grayScaleCommand.BitsPerPixel = 8;
         grayScaleCommand.Run(_viewer.Image);
         Text = "Image Is Grayscaled";
         _viewer.Refresh();
         Thread.Sleep(2000);

         // change cursor
         Cursor = Cursors.SizeWE;
         // Do Invert
         Text = "Inverting Image...";
         InvertCommand invertCommand = new InvertCommand();
         invertCommand.Run(_viewer.Image);
         Text = "Image Is Inverted, Batch Is Complete";
         _viewer.Refresh();
         Thread.Sleep(2000);

         // change the cursor to arrow
         Cursor = Cursors.Arrow;

         // enable the form
         Enabled = true;

         // return the old caption
         Text = tmpCaption;
      }

      /// <summary>
      /// Underlay an Image
      /// </summary>
      private void _miBasicFeaturesUnderlay_Click(object sender, EventArgs e)
      {
         try
         {
            ImageFileLoader loader = new ImageFileLoader();
            if (loader.Load(this, _codecs, true) <= 0) return;
            using (UnderlayDialog dlg = new UnderlayDialog())
            {
               if (dlg.ShowDialog(this) != DialogResult.OK) return;
               using (WaitCursor wait = new WaitCursor())
                  _viewer.Image.Underlay(loader.Image, dlg.Flags);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      /// <summary>
      /// Optimizing the Image to 8 bpp, and Rotating the Image using GetRow and SetRowColumn methods
      /// </summary>
      private void _miBasicFeaturesGetSetRow_Click(object sender, EventArgs e)
      {
         try
         {
            // convert the image to 8 bpp
            ColorResolutionCommand colorResCommand = new ColorResolutionCommand();
            colorResCommand.BitsPerPixel = 8;
            colorResCommand.DitheringMethod = RasterDitheringMethod.FloydStein;
            colorResCommand.PaletteFlags = ColorResolutionCommandPaletteFlags.Optimized;
            colorResCommand.Mode = ColorResolutionCommandMode.InPlace;
            colorResCommand.Order = RasterByteOrder.Bgr;
            colorResCommand.SetPalette(null);
            colorResCommand.Run(_viewer.Image);
            _viewer.Refresh();

            // the row number
            int outRow = _viewer.Image.Width - 1;
            // the column number
            int outCol = 0;
            // Allocate the buffer.
            byte[] buffer = new byte[_viewer.Image.BytesPerLine];
            // the temp image to save the rotated image (8 bpp, and Height*Width).
            RasterImage tmpImg = new RasterImage(RasterMemoryFlags.Conventional, _viewer.Image.Height, _viewer.Image.Width, 8, _viewer.Image.Order, _viewer.Image.ViewPerspective, _viewer.Image.GetPalette(), IntPtr.Zero, 0);

            for (int i = 0; i < _viewer.Image.Height; i++)
            {
               _viewer.Image.Access();

               _viewer.Image.GetRow(i, buffer, 0, _viewer.Image.BytesPerLine);

               // loop into the image
               for (int j = 0; j < tmpImg.Height; j++)
               {
                  // set the row as column
                  tmpImg.SetRowColumn(outRow, outCol, buffer, j, 1);
                  // move to the next row
                  outRow--;
               }
               // move to the next column
               outCol++;
               // reset the row number
               outRow = _viewer.Image.Width - 1;
            }
            // set the rotated image into the viewer
            _viewer.Image = tmpImg;

            _viewer.Image.Release();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      /// <summary>
      /// display the about dialog
      /// </summary>
      private void _miHelpAbout_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Basic Features", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }
   }
}
