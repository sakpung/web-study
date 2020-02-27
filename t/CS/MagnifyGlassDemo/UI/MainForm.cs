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

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Controls;
using Leadtools.WinForms;

#if LEADTOOLS_V17_OR_LATER
using Leadtools.Drawing;
#endif // #if LEADTOOLS_V17_OR_LATER

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace MagnifyGlassDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miMagnifyGlass;
      private System.Windows.Forms.MenuItem _miMagnifyGlassStart;
      private System.Windows.Forms.MenuItem _miMagnifyGlassStop;
      private System.Windows.Forms.MenuItem _miMagnifyGlassSep1;
      private System.Windows.Forms.MenuItem _miMagnifyGlassResizeWidth;
      private System.Windows.Forms.MenuItem _miMagnifyGlassResizeHeight;
      private System.Windows.Forms.MenuItem _miMagnifyGlassResizeBorder;
      private System.Windows.Forms.MenuItem _miColors;
      private System.Windows.Forms.MenuItem _miColorsBorderColor;
      private System.Windows.Forms.MenuItem _miColorsCrosshairColor;
      private System.Windows.Forms.MenuItem _miOptions;
      private System.Windows.Forms.MenuItem _miOptionsCrosshair;
      private System.Windows.Forms.MenuItem _miOptionsCrosshairNone;
      private System.Windows.Forms.MenuItem _miOptionsCrosshairFine;
      private System.Windows.Forms.MenuItem _miShape;
      private System.Windows.Forms.MenuItem _miShapeRectangle;
      private System.Windows.Forms.MenuItem _miShapeEllipse;
      private System.Windows.Forms.MenuItem _miShapeRoundRectangle;
      private System.Windows.Forms.MenuItem _miShapeNone;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miAbout;
      private System.Windows.Forms.MenuItem _miOptions3DBorderAdjust;
      private System.Windows.Forms.MenuItem _miOptions3DBorderBump;
      private System.Windows.Forms.MenuItem _miOptions3DBorderEtched;
      private System.Windows.Forms.MenuItem _miOptions3DBorderFlat;
      private System.Windows.Forms.MenuItem _miOptions3DBorderRaised;
      private System.Windows.Forms.MenuItem _miOptions3DBorderRaisedInner;
      private System.Windows.Forms.MenuItem _miOptions3DBorderRaisedOuter;
      private System.Windows.Forms.MenuItem _miOptions3DBorderRaisedBoth;
      private System.Windows.Forms.MenuItem _miOptions3DBorderSunken;
      private System.Windows.Forms.MenuItem _miOptions3DBorderSunkenInner;
      private System.Windows.Forms.MenuItem _miOptions3DBorderSunkenOuter;
      private System.Windows.Forms.MenuItem _miOptions3DBorderSunkenBoth;
      private System.Windows.Forms.MenuItem _miMagnifyGlassScaleFactor;
      private System.Windows.Forms.MenuItem _miMagnifyGlassRoundRectangleEllipseSize;

      private ImageViewerMagnifyGlassInteractiveMode magGlass = new ImageViewerMagnifyGlassInteractiveMode();
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
         this._miMagnifyGlass = new System.Windows.Forms.MenuItem();
         this._miMagnifyGlassStart = new System.Windows.Forms.MenuItem();
         this._miMagnifyGlassStop = new System.Windows.Forms.MenuItem();
         this._miMagnifyGlassSep1 = new System.Windows.Forms.MenuItem();
         this._miMagnifyGlassResizeWidth = new System.Windows.Forms.MenuItem();
         this._miMagnifyGlassResizeHeight = new System.Windows.Forms.MenuItem();
         this._miMagnifyGlassResizeBorder = new System.Windows.Forms.MenuItem();
         this._miMagnifyGlassScaleFactor = new System.Windows.Forms.MenuItem();
         this._miMagnifyGlassRoundRectangleEllipseSize = new System.Windows.Forms.MenuItem();
         this._miColors = new System.Windows.Forms.MenuItem();
         this._miColorsBorderColor = new System.Windows.Forms.MenuItem();
         this._miColorsCrosshairColor = new System.Windows.Forms.MenuItem();
         this._miOptions = new System.Windows.Forms.MenuItem();
         this._miOptionsCrosshair = new System.Windows.Forms.MenuItem();
         this._miOptionsCrosshairNone = new System.Windows.Forms.MenuItem();
         this._miOptionsCrosshairFine = new System.Windows.Forms.MenuItem();
         this._miShape = new System.Windows.Forms.MenuItem();
         this._miShapeRectangle = new System.Windows.Forms.MenuItem();
         this._miShapeEllipse = new System.Windows.Forms.MenuItem();
         this._miShapeRoundRectangle = new System.Windows.Forms.MenuItem();
         this._miShapeNone = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miAbout = new System.Windows.Forms.MenuItem();
         this._miOptions3DBorderAdjust = new System.Windows.Forms.MenuItem();
         this._miOptions3DBorderBump = new System.Windows.Forms.MenuItem();
         this._miOptions3DBorderEtched = new System.Windows.Forms.MenuItem();
         this._miOptions3DBorderFlat = new System.Windows.Forms.MenuItem();
         this._miOptions3DBorderRaised = new System.Windows.Forms.MenuItem();
         this._miOptions3DBorderRaisedInner = new System.Windows.Forms.MenuItem();
         this._miOptions3DBorderRaisedOuter = new System.Windows.Forms.MenuItem();
         this._miOptions3DBorderRaisedBoth = new System.Windows.Forms.MenuItem();
         this._miOptions3DBorderSunken = new System.Windows.Forms.MenuItem();
         this._miOptions3DBorderSunkenInner = new System.Windows.Forms.MenuItem();
         this._miOptions3DBorderSunkenOuter = new System.Windows.Forms.MenuItem();
         this._miOptions3DBorderSunkenBoth = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miMagnifyGlass,
            this._miColors,
            this._miOptions,
            this._miShape,
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
         // _miMagnifyGlass
         // 
         this._miMagnifyGlass.Index = 1;
         this._miMagnifyGlass.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miMagnifyGlassStart,
            this._miMagnifyGlassStop,
            this._miMagnifyGlassSep1,
            this._miMagnifyGlassResizeWidth,
            this._miMagnifyGlassResizeHeight,
            this._miMagnifyGlassResizeBorder,
            this._miMagnifyGlassScaleFactor,
            this._miMagnifyGlassRoundRectangleEllipseSize});
         this._miMagnifyGlass.Text = "&MagnifyGlass";
         // 
         // _miMagnifyGlassStart
         // 
         this._miMagnifyGlassStart.Index = 0;
         this._miMagnifyGlassStart.Text = "&Start";
         this._miMagnifyGlassStart.Click += new System.EventHandler(this._miMagnifyGlassStart_Click);
         // 
         // _miMagnifyGlassStop
         // 
         this._miMagnifyGlassStop.Index = 1;
         this._miMagnifyGlassStop.Text = "Sto&p";
         this._miMagnifyGlassStop.Click += new System.EventHandler(this._miMagnifyGlassStop_Click);
         // 
         // _miMagnifyGlassSep1
         // 
         this._miMagnifyGlassSep1.Index = 2;
         this._miMagnifyGlassSep1.Text = "-";
         // 
         // _miMagnifyGlassResizeWidth
         // 
         this._miMagnifyGlassResizeWidth.Index = 3;
         this._miMagnifyGlassResizeWidth.Text = "Resize &Width...";
         this._miMagnifyGlassResizeWidth.Click += new System.EventHandler(this._miMagnifyGlassResizeWidth_Click);
         // 
         // _miMagnifyGlassResizeHeight
         // 
         this._miMagnifyGlassResizeHeight.Index = 4;
         this._miMagnifyGlassResizeHeight.Text = "Resize &Height...";
         this._miMagnifyGlassResizeHeight.Click += new System.EventHandler(this._miMagnifyGlassResizeHeight_Click);
         // 
         // _miMagnifyGlassResizeBorder
         // 
         this._miMagnifyGlassResizeBorder.Index = 5;
         this._miMagnifyGlassResizeBorder.Text = "Resize &Border...";
         this._miMagnifyGlassResizeBorder.Click += new System.EventHandler(this._miMagnifyGlassResizeBorder_Click);
         // 
         // _miMagnifyGlassScaleFactor
         // 
         this._miMagnifyGlassScaleFactor.Index = 6;
         this._miMagnifyGlassScaleFactor.Text = "&Scale Factor...";
         this._miMagnifyGlassScaleFactor.Click += new System.EventHandler(this._miMagnifyGlassScaleFactor_Click);
         // 
         // _miMagnifyGlassRoundRectangleEllipseSize
         // 
         this._miMagnifyGlassRoundRectangleEllipseSize.Index = 7;
         this._miMagnifyGlassRoundRectangleEllipseSize.Text = "Round Rectangle Ellipse Size...";
         this._miMagnifyGlassRoundRectangleEllipseSize.Click += new System.EventHandler(this._miMagnifyGlassRoundRectangleEllipseSize_Click);
         // 
         // _miColors
         // 
         this._miColors.Index = 2;
         this._miColors.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miColorsBorderColor,
            this._miColorsCrosshairColor});
         this._miColors.Text = "&Colors";
         // 
         // _miColorsBorderColor
         // 
         this._miColorsBorderColor.Index = 0;
         this._miColorsBorderColor.Text = "&Border Color...";
         this._miColorsBorderColor.Click += new System.EventHandler(this._miColorsBorderColor_Click);
         // 
         // _miColorsCrosshairColor
         // 
         this._miColorsCrosshairColor.Index = 1;
         this._miColorsCrosshairColor.Text = "&Crosshair Color...";
         this._miColorsCrosshairColor.Click += new System.EventHandler(this._miColorsCrosshairColor_Click);
         // 
         // _miOptions
         // 
         this._miOptions.Index = 3;
         this._miOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miOptionsCrosshair});
         this._miOptions.Text = "&Options";
         // 
         // _miOptionsCrosshair
         // 
         this._miOptionsCrosshair.Index = 0;
         this._miOptionsCrosshair.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miOptionsCrosshairNone,
            this._miOptionsCrosshairFine});
         this._miOptionsCrosshair.Text = "&Crosshair";
         // 
         // _miOptionsCrosshairNone
         // 
         this._miOptionsCrosshairNone.Index = 0;
         this._miOptionsCrosshairNone.Text = "&None";
         this._miOptionsCrosshairNone.Click += new System.EventHandler(this._miOptionsCrosshair_Click);
         // 
         // _miOptionsCrosshairFine
         // 
         this._miOptionsCrosshairFine.Index = 1;
         this._miOptionsCrosshairFine.Text = "&Fine";
         this._miOptionsCrosshairFine.Click += new System.EventHandler(this._miOptionsCrosshair_Click);
         // 
         // _miShape
         // 
         this._miShape.Index = 4;
         this._miShape.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miShapeRectangle,
            this._miShapeEllipse,
            this._miShapeRoundRectangle,
            this._miShapeNone});
         this._miShape.Text = "&Shape";
         // 
         // _miShapeRectangle
         // 
         this._miShapeRectangle.Index = 0;
         this._miShapeRectangle.Text = "&Rectangle";
         this._miShapeRectangle.Click += new System.EventHandler(this._miShape_Click);
         // 
         // _miShapeEllipse
         // 
         this._miShapeEllipse.Index = 1;
         this._miShapeEllipse.Text = "&Ellipse";
         this._miShapeEllipse.Click += new System.EventHandler(this._miShape_Click);
         // 
         // _miShapeRoundRectangle
         // 
         this._miShapeRoundRectangle.Index = 2;
         this._miShapeRoundRectangle.Text = "&Round Rectangle";
         this._miShapeRoundRectangle.Click += new System.EventHandler(this._miShape_Click);
         // 
         // _miShapeNone
         // 
         this._miShapeNone.Index = 3;
         this._miShapeNone.Text = "&None";
         this._miShapeNone.Click += new System.EventHandler(this._miShape_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 5;
         this._miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miAbout});
         this._miHelp.Text = "&Help";
         // 
         // _miAbout
         // 
         this._miAbout.Index = 0;
         this._miAbout.Text = "&About...";
         this._miAbout.Click += new System.EventHandler(this._miAbout_Click);
         // 
         // _miOptions3DBorderAdjust
         // 
         this._miOptions3DBorderAdjust.Index = -1;
         this._miOptions3DBorderAdjust.Text = "";
         // 
         // _miOptions3DBorderBump
         // 
         this._miOptions3DBorderBump.Index = -1;
         this._miOptions3DBorderBump.Text = "";
         // 
         // _miOptions3DBorderEtched
         // 
         this._miOptions3DBorderEtched.Index = -1;
         this._miOptions3DBorderEtched.Text = "";
         // 
         // _miOptions3DBorderFlat
         // 
         this._miOptions3DBorderFlat.Index = -1;
         this._miOptions3DBorderFlat.Text = "";
         // 
         // _miOptions3DBorderRaised
         // 
         this._miOptions3DBorderRaised.Index = -1;
         this._miOptions3DBorderRaised.Text = "";
         // 
         // _miOptions3DBorderRaisedInner
         // 
         this._miOptions3DBorderRaisedInner.Index = -1;
         this._miOptions3DBorderRaisedInner.Text = "";
         // 
         // _miOptions3DBorderRaisedOuter
         // 
         this._miOptions3DBorderRaisedOuter.Index = -1;
         this._miOptions3DBorderRaisedOuter.Text = "";
         // 
         // _miOptions3DBorderRaisedBoth
         // 
         this._miOptions3DBorderRaisedBoth.Index = -1;
         this._miOptions3DBorderRaisedBoth.Text = "";
         // 
         // _miOptions3DBorderSunken
         // 
         this._miOptions3DBorderSunken.Index = -1;
         this._miOptions3DBorderSunken.Text = "";
         // 
         // _miOptions3DBorderSunkenInner
         // 
         this._miOptions3DBorderSunkenInner.Index = -1;
         this._miOptions3DBorderSunkenInner.Text = "";
         // 
         // _miOptions3DBorderSunkenOuter
         // 
         this._miOptions3DBorderSunkenOuter.Index = -1;
         this._miOptions3DBorderSunkenOuter.Text = "";
         // 
         // _miOptions3DBorderSunkenBoth
         // 
         this._miOptions3DBorderSunkenBoth.Index = -1;
         this._miOptions3DBorderSunkenBoth.Text = "";
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.BackColor = System.Drawing.Color.DarkGray;
         this.ClientSize = new System.Drawing.Size(608, 393);
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

      // the raster codecs used in load
      private RasterCodecs _codecs;

      // MagnifyGlass border color
      private Color _borderColor;

      // MagnifyGlass border width
      private int _borderWidth;

      // MagnifyGlass crosshair type
      private ImageViewerSpyGlassCrosshair _crosshair;

      // MagnifyGlass crosshair color
      private Color _crosshairColor;

      // MagnifyGlass crosshair width
      private int _crosshairWidth;

      // MagnifyGlass round rectangle ellipse size
      private LeadSize _roundRectangleEllipseSize;

      // MagnifyGlass scale factor (zoom factor)
      private float _scaleFactor;

      // MagnifyGlass shape type
      private ImageViewerSpyGlassShape _shape;

      // MagnifyGlass size
      private LeadSize _size;

      private string _openInitialPath = string.Empty;

      private void MainForm_Load(object sender, System.EventArgs e)
      {
         // setup our caption
         Messager.Caption = "LEADTOOLS for .NET C# MagnifyGlass Demo";
         Text = Messager.Caption;

         // initialize the _viewer object    
         _viewer = new ImageViewer();

         // Add the MagnifyGlass InteractiveMode
         _viewer.InteractiveModes.Add(magGlass);

         RasterPaintProperties paintProperties = RasterPaintProperties.Default;
         paintProperties.PaintDisplayMode |= RasterPaintDisplayModeFlags.Bicubic | RasterPaintDisplayModeFlags.ScaleToGray;
         paintProperties.PaintEngine = RasterPaintEngine.GdiPlus;
         _viewer.PaintProperties = paintProperties;
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();

         // initialize the codecs object
         _codecs = new RasterCodecs();

         // initialize the other variables
         _borderColor = Color.Red;
         _borderWidth = 2;
         _crosshair = ImageViewerSpyGlassCrosshair.Fine;
         _crosshairColor = Color.Green;
         _crosshairWidth = 1;
         _roundRectangleEllipseSize = new LeadSize(20, 20);
         _scaleFactor = 2;
         _shape = ImageViewerSpyGlassShape.Rectangle;
         _size = new LeadSize(150, 150);

         UpdateMyControls();
      }

      /// <summary>
      /// Updates the UI depending on the program state.
      /// </summary>
      private void UpdateMyControls()
      {
         if (_viewer.Image != null)
         {
            // update the menu items
            _miMagnifyGlass.Enabled = true;
            _miMagnifyGlass.Visible = true;

            _miColors.Enabled = true;
            _miColors.Visible = true;

            _miOptions.Enabled = true;
            _miOptions.Visible = true;

            _miShape.Enabled = true;
            _miShape.Visible = true;

            foreach (ImageViewerInteractiveMode _interactivemode in _viewer.InteractiveModes)
            {
               if (_interactivemode.Name == "MagnifyGlass")
                  magGlass = _interactivemode as ImageViewerMagnifyGlassInteractiveMode;
            }

            _miMagnifyGlassStart.Enabled = !(magGlass.IsStarted);
            _miMagnifyGlassStop.Enabled = (magGlass.IsStarted);

            _miOptionsCrosshairNone.Checked = (_crosshair == ImageViewerSpyGlassCrosshair.None);
            _miOptionsCrosshairFine.Checked = (_crosshair == ImageViewerSpyGlassCrosshair.Fine);
            _miShapeRectangle.Checked = (_shape == ImageViewerSpyGlassShape.Rectangle);
            _miShapeEllipse.Checked = (_shape == ImageViewerSpyGlassShape.Ellipse);
            _miShapeRoundRectangle.Checked = (_shape == ImageViewerSpyGlassShape.RoundRectangle);
            _miShapeNone.Checked = (_shape == ImageViewerSpyGlassShape.None);

            // update the MagnifyGlass members                
            magGlass.Crosshair = _crosshair;
            magGlass.BorderPen = new Pen(_borderColor, _borderWidth);
            magGlass.CrosshairPen = new Pen(_crosshairColor, _crosshairWidth);
            magGlass.RoundRectangleRadius = _roundRectangleEllipseSize;
            magGlass.ScaleFactor = _scaleFactor;
            magGlass.Shape = _shape;
            magGlass.Size = _size;

         }
         else
         {
            _miMagnifyGlass.Enabled = false;
            _miMagnifyGlass.Visible = false;

            _miColors.Enabled = false;
            _miColors.Visible = false;

            _miOptions.Enabled = false;
            _miOptions.Visible = false;

            _miShape.Enabled = false;
            _miShape.Visible = false;
         }
      }

      /// <summary>
      /// load new image
      /// </summary>

      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         try
         {
            // load the image
            ImageFileLoader loader = new ImageFileLoader();

            loader.OpenDialogInitialPath = _openInitialPath;

            if (loader.Load(this, _codecs, true) > 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               // update the caption
               Text = string.Format("{0} - {1}", loader.FileName, Messager.Caption);

               // set the new image in the viewer.
               _viewer.Image = loader.Image;
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
      /// Shutdown
      /// </summary>
      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      /// <summary>
      /// Start MagnifyGlass
      /// </summary>
      private void _miMagnifyGlassStart_Click(object sender, System.EventArgs e)
      {

         foreach (ImageViewerInteractiveMode _interactivemode in _viewer.InteractiveModes)
         {

            if (_interactivemode.Name == "MagnifyGlass")
               magGlass = _interactivemode as ImageViewerMagnifyGlassInteractiveMode;
         }

         magGlass.Start(_viewer);

         UpdateMyControls();
      }

      /// <summary>
      /// Stop MagnifyGlass
      /// </summary>
      private void _miMagnifyGlassStop_Click(object sender, System.EventArgs e)
      {
         foreach (ImageViewerInteractiveMode _interactivemode in _viewer.InteractiveModes)
         {

            if (_interactivemode.Name == "MagnifyGlass")
               magGlass = _interactivemode as ImageViewerMagnifyGlassInteractiveMode;
         }

         magGlass.Stop(_viewer);

         UpdateMyControls();
      }

      /// <summary>
      /// Resize the MagnifyGlass width
      /// </summary>
      private void _miMagnifyGlassResizeWidth_Click(object sender, System.EventArgs e)
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Width);
         dlg.Value = _size.Width;
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            _size = new LeadSize(dlg.Value, _size.Height);

            UpdateMyControls();
         }

      }

      /// <summary>
      /// Resize the MagnifyGlass height
      /// </summary>
      private void _miMagnifyGlassResizeHeight_Click(object sender, System.EventArgs e)
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Height);
         dlg.Value = _size.Height;
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            _size = new LeadSize(_size.Width, dlg.Value);
            UpdateMyControls();
         }
      }

      /// <summary>
      /// Resize the MagnifyGlass border width
      /// </summary>
      private void _miMagnifyGlassResizeBorder_Click(object sender, System.EventArgs e)
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Border);
         dlg.Value = _borderWidth;
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            _borderWidth = dlg.Value;
            UpdateMyControls();
         }
      }

      /// <summary>
      /// Resize the MagnifyGlass Scale factor
      /// </summary>
      private void _miMagnifyGlassScaleFactor_Click(object sender, System.EventArgs e)
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.ScaleFactor);
         dlg.Value = (int)_scaleFactor;
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            _scaleFactor = dlg.Value;
            UpdateMyControls();
         }
      }

      /// <summary>
      /// Change the Round Rectangle Ellipse Size
      /// </summary>
      private void _miMagnifyGlassRoundRectangleEllipseSize_Click(object sender, System.EventArgs e)
      {
         RoundRectSizeDialog dlg = new RoundRectSizeDialog(_roundRectangleEllipseSize.Width,
            _roundRectangleEllipseSize.Height,
            _size.Width,
            _size.Height);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            _roundRectangleEllipseSize = new LeadSize(dlg.RoundRectEllipseSize.Width, dlg.RoundRectEllipseSize.Height);
            UpdateMyControls();
         }
      }

      /// <summary>
      /// Resize the MagnifyGlass border color
      /// </summary>
      private void _miColorsBorderColor_Click(object sender, System.EventArgs e)
      {
         ColorDialog dlg = new ColorDialog();
         dlg.AllowFullOpen = true;
         dlg.AnyColor = true;
         dlg.Color = _borderColor;
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            _borderColor = dlg.Color;
            UpdateMyControls();
         }
      }

      /// <summary>
      /// Resize the MagnifyGlass crosshair color
      /// </summary>
      private void _miColorsCrosshairColor_Click(object sender, System.EventArgs e)
      {
         ColorDialog dlg = new ColorDialog();
         dlg.AllowFullOpen = true;
         dlg.AnyColor = true;
         dlg.Color = _crosshairColor;
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            _crosshairColor = dlg.Color;
            UpdateMyControls();
         }
      }

      /// <summary>
      /// Display or not the MagnifyGlass border as 3D
      /// </summary>


      /// <summary>
      /// Change the MagnifyGlass crosshair style
      /// </summary>
      private void _miOptionsCrosshair_Click(object sender, System.EventArgs e)
      {
         if (sender == _miOptionsCrosshairNone)
            _crosshair = ImageViewerSpyGlassCrosshair.None;
         else
            _crosshair = ImageViewerSpyGlassCrosshair.Fine;

         UpdateMyControls();
      }

      /// <summary>
      /// Choose the MagnifyGlass Shape
      /// </summary>
      private void _miShape_Click(object sender, System.EventArgs e)
      {
         if (sender == _miShapeRectangle)
            _shape = ImageViewerSpyGlassShape.Rectangle;
         else if (sender == _miShapeEllipse)
            _shape = ImageViewerSpyGlassShape.Ellipse;
         else if (sender == _miShapeRoundRectangle)
            _shape = ImageViewerSpyGlassShape.RoundRectangle;
         else if (sender == _miShapeNone)
            _shape = ImageViewerSpyGlassShape.None;

         UpdateMyControls();
      }

      /// <summary>
      /// Show the about dialog
      /// </summary>
      private void _miAbout_Click(object sender, System.EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("MagnifyGlass", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("MagnifyGlass"))
            aboutDialog.ShowDialog(this);
#endif
      }
   }
}
