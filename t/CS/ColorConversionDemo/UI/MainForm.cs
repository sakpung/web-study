// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.ColorConversion;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.ImageProcessing;
using Leadtools.Controls;
using Leadtools.WinForms.CommonDialogs.File;

namespace ColorConversionDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miFileClose;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miFileSaveAs;
      private System.Windows.Forms.MenuItem _miFileSep2;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.MenuItem _miConvert;
      private System.Windows.Forms.MenuItem _miConvertConvertTo;
      private System.Windows.Forms.MenuItem _miView;
      private System.Windows.Forms.MenuItem _miViewFitImageToWindow;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public MainForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         InitClass();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            CleanUp();

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
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
         this._mmMain = new System.Windows.Forms.MainMenu();
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileOpen = new System.Windows.Forms.MenuItem();
         this._miFileClose = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFileSaveAs = new System.Windows.Forms.MenuItem();
         this._miFileSep2 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miConvert = new System.Windows.Forms.MenuItem();
         this._miConvertConvertTo = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this._miView = new System.Windows.Forms.MenuItem();
         this._miViewFitImageToWindow = new System.Windows.Forms.MenuItem();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this._miFile,
                                                                                this._miView,
                                                                                this._miConvert,
                                                                                this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this._miFileOpen,
                                                                                this._miFileClose,
                                                                                this._miFileSep1,
                                                                                this._miFileSaveAs,
                                                                                this._miFileSep2,
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
         // _miFileClose
         // 
         this._miFileClose.Index = 1;
         this._miFileClose.Text = "&Close";
         this._miFileClose.Click += new System.EventHandler(this._miFileClose_Click);
         // 
         // _miFileSep1
         // 
         this._miFileSep1.Index = 2;
         this._miFileSep1.Text = "-";
         // 
         // _miFileSaveAs
         // 
         this._miFileSaveAs.Index = 3;
         this._miFileSaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this._miFileSaveAs.Text = "&Save As...";
         this._miFileSaveAs.Click += new System.EventHandler(this._miFileSaveAs_Click);
         // 
         // _miFileSep2
         // 
         this._miFileSep2.Index = 4;
         this._miFileSep2.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 5;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miConvert
         // 
         this._miConvert.Index = 2;
         this._miConvert.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                   this._miConvertConvertTo});
         this._miConvert.Text = "&Convert";
         // 
         // _miConvertConvertTo
         // 
         this._miConvertConvertTo.Index = 0;
         this._miConvertConvertTo.Text = "Convert &To...";
         this._miConvertConvertTo.Click += new System.EventHandler(this._miConvertConvertTo_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 3;
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
         // _miView
         // 
         this._miView.Index = 1;
         this._miView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this._miViewFitImageToWindow});
         this._miView.Text = "&View";
         // 
         // _miViewFitImageToWindow
         // 
         this._miViewFitImageToWindow.Index = 0;
         this._miViewFitImageToWindow.RadioCheck = true;
         this._miViewFitImageToWindow.Text = "&Fit Image to Window";
         this._miViewFitImageToWindow.Click += new System.EventHandler(this._miViewFitImageToWindow_Click);
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(608, 393);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";

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

         Application.EnableVisualStyles();
         Application.DoEvents();

         Application.Run(new MainForm());
      }

      // The raster image viewer
      private ImageViewer _viewer;

      // The raster codecs used in load/save.
      private RasterCodecs _codecs;

      // The type of conversion as a text
      private static String _conversionType;
      private string _openInitialPath = string.Empty;

      public static String ConversionType
      {
         set { _conversionType = value; }
      }

      /// <summary>
      /// Initialize the application.
      /// </summary>
      private void InitClass()
      {
         // Setup our caption
         Messager.Caption = "LEADTOOLS for .NET C# Color Conversion Demo";
         Text = Messager.Caption;

         // Conversion type is nothing for now
         _conversionType = String.Empty;

         // Initialize the _viewer object
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();

         _viewer.Zoom(ControlSizeMode.Fit, 1, _viewer.DefaultZoomOrigin);

         // initialize the raster codecs object
         _codecs = new RasterCodecs();

         try
         {
            RasterColorConverterEngine.Startup();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }

         LoadImage(true);
         UpdateMyControls();
      }

      /// <summary>
      /// Shutting down
      /// </summary>
      private void CleanUp()
      {
         RasterColorConverterEngine.Shutdown();
      }

      /// <summary>
      /// Update the UI depending on the program state.
      /// </summary>
      private void UpdateMyControls()
      {
         // Update the menus and the Caption
         if (_viewer.Image != null)
         {
            _miFileClose.Visible = true;
            _miFileClose.Enabled = true;
            _miFileSaveAs.Visible = true;
            _miFileSaveAs.Enabled = true;
            _miFileSep2.Visible = true;
            _miFileSep2.Enabled = true;
            _miConvert.Visible = true;
            _miConvert.Enabled = true;
            _miConvertConvertTo.Enabled = true;
         }
         else
         {
            _miFileClose.Visible = false;
            _miFileClose.Enabled = false;
            _miFileSaveAs.Visible = false;
            _miFileSaveAs.Enabled = false;
            _miFileSep2.Visible = false;
            _miFileSep2.Enabled = false;
            _miConvert.Visible = false;
            _miConvert.Enabled = false;
         }

         _miViewFitImageToWindow.Checked = _viewer.SizeMode == ControlSizeMode.Fit;
      }

      /// <summary>
      /// Open a new image.
      /// </summary>
      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         LoadImage(false);
      }

      private void LoadImage(bool loadDefaultImage)
      {
         RasterOpenDialogLoadFormat[] loaderFilters = new RasterOpenDialogLoadFormat[3];
         loaderFilters[0] = new RasterOpenDialogLoadFormat("Bitmap Files (*.dib;*.bmp)", "*.dib;*.bmp");
         loaderFilters[1] = new RasterOpenDialogLoadFormat("TIFF Files (*.tif)", "*.tif");
         loaderFilters[2] = new RasterOpenDialogLoadFormat("All Files (*.tif, *.bmp)", "*.tif;*.bmp");

         ImageFileLoader loader = new ImageFileLoader();
         loader.OpenDialogInitialPath = _openInitialPath;
         loader.Filters = loaderFilters;

         bool bLoaded = false;

         try
         {
            if (loadDefaultImage)
               bLoaded = loader.Load(this, DemosGlobal.ImagesFolder + @"\ET\dst_rgb_image.tif", _codecs, 1, 1);
            else
               bLoaded = loader.Load(this, _codecs, true) > 0;

            if (bLoaded)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               // Resize the image so each dimension becomes a multiple of 4. This is done because it's required by some color spaces 
               int width = loader.Image.Width;
               int height = loader.Image.Height;

               width += (width % 4 == 0) ? 0 : (4 - (width % 4));
               height += (height % 4 == 0) ? 0 : (4 - (height % 4));

               // If the width and the height were the same, the SizeCommand will return immediately.
               SizeCommand sizeCommand = new SizeCommand(width, height, RasterSizeFlags.None);
               sizeCommand.Run(loader.Image);

               CodecsImageInfo info = _codecs.GetInformation(loader.FileName, false, 1);
               if (info.BitsPerPixel == 24)
               {
                  _viewer.Image = loader.Image;
                  Text = "LEADTOOLS for .NET C# Color Conversion Demo";
               }
               else
               {
                  Messager.ShowError(this, "Format not supported\nthis demo supports simple TIFF - (RGB24, CMYK, YCC and LAB) and BMP - (RGB24)");
               }
            }
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
      /// Close the opened Image.
      /// </summary>
      private void _miFileClose_Click(object sender, System.EventArgs e)
      {
         _viewer.Image = null;
         Text = Messager.Caption;
         UpdateMyControls();
      }

      /// <summary>
      /// Save the viewer Image.
      /// </summary>
      private void _miFileSaveAs_Click(object sender, System.EventArgs e)
      {
         ImageFileSaver saver = new ImageFileSaver();

         try
         {
            saver.Save(this, _codecs, _viewer.Image);
         }
         catch (Exception ex)
         {
            Messager.ShowFileSaveError(this, saver.FileName, ex);
         }
      }

      /// <summary>
      /// Shutdown.
      /// </summary>
      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      /// <summary>
      /// Converting between Color Spaces.
      /// </summary>
      private void _miConvertConvertTo_Click(object sender, System.EventArgs e)
      {
         ConvertToDialog dlg = new ConvertToDialog(_viewer.Image, ConversionColorFormat.Bgr);

         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            _viewer.Image = dlg.ResultImage;
            Text = string.Format("Converted image ({1})- {0}", Messager.Caption, _conversionType);
         }
      }

      /// <summary>
      /// Show the About dialog.
      /// </summary>
      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Color Conversion", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _miViewFitImageToWindow_Click(object sender, System.EventArgs e)
      {
         ControlSizeMode sizeMode = _viewer.SizeMode;
         if (sizeMode == ControlSizeMode.Fit)
            sizeMode = ControlSizeMode.ActualSize;
         else
            sizeMode = ControlSizeMode.Fit;

         _viewer.Zoom(sizeMode, 1, _viewer.DefaultZoomOrigin);
         UpdateMyControls();
      }
   }
}
