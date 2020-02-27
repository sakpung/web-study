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

using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Drawing;
using Leadtools.Controls;

namespace DrawDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miFileSave;
      private System.Windows.Forms.MenuItem _miFileSaveAs;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.ToolBar _tbMain;
      private System.Windows.Forms.ToolBarButton _tbbFileSave;
      private System.Windows.Forms.ToolBarButton _tbbSep1;
      private System.Windows.Forms.ToolBarButton _tbbFileOpen;
      private System.Windows.Forms.StatusBar _sbMain;
      private System.Windows.Forms.MenuItem _miView;
      private System.Windows.Forms.MenuItem _miViewZoom;
      private System.Windows.Forms.MenuItem _miViewZoomIn;
      private System.Windows.Forms.MenuItem _miViewZoomOut;
      private System.Windows.Forms.MenuItem _miViewSizeMode;
      private System.Windows.Forms.MenuItem _miViewSizeModeNormal;
      private System.Windows.Forms.MenuItem _miViewSizeModeFit;
      private System.Windows.Forms.MenuItem _miViewSizeModeFitWidth;
      private System.Windows.Forms.MenuItem _miAction;
      private System.Windows.Forms.MenuItem _miActionNone;
      private System.Windows.Forms.MenuItem _miActionLine;
      private System.Windows.Forms.MenuItem _miActionRectangle;
      private System.Windows.Forms.MenuItem _miActionEllipse;
      private System.Windows.Forms.MenuItem _miActionPan;
      private System.Windows.Forms.MenuItem _miActionZoomToRectangle;
      private System.Windows.Forms.ToolBarButton _tbbZoomNone;
      private System.Windows.Forms.ToolBarButton _tbbZoomIn;
      private System.Windows.Forms.ToolBarButton _tbbZoomOut;
      private System.Windows.Forms.ToolBarButton _tbbSep2;
      private System.Windows.Forms.ToolBarButton _tbbActionNone;
      private System.Windows.Forms.ToolBarButton _tbbActionPan;
      private System.Windows.Forms.ToolBarButton _tbbActionZoomToRectangle;
      private System.Windows.Forms.ToolBarButton _tbbActionLine;
      private System.Windows.Forms.ToolBarButton _tbbActionRectangle;
      private System.Windows.Forms.ToolBarButton _tbbActionEllipse;
      private System.Windows.Forms.MenuItem _miViewZoomNone;
      private System.Windows.Forms.MenuItem _miOptions;
      private System.Windows.Forms.MenuItem _miOptionsPen;
      private System.Windows.Forms.MenuItem _miOptionsBrush;
      private System.Windows.Forms.MainMenu _mmMain;
      private System.ComponentModel.IContainer components = null;

      public MainForm( )
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
         if(disposing)
         {
            if(components != null)
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
      private void InitializeComponent( )
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mmMain = new System.Windows.Forms.MainMenu(this.components);
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileOpen = new System.Windows.Forms.MenuItem();
         this._miFileSave = new System.Windows.Forms.MenuItem();
         this._miFileSaveAs = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miView = new System.Windows.Forms.MenuItem();
         this._miViewZoom = new System.Windows.Forms.MenuItem();
         this._miViewZoomNone = new System.Windows.Forms.MenuItem();
         this._miViewZoomIn = new System.Windows.Forms.MenuItem();
         this._miViewZoomOut = new System.Windows.Forms.MenuItem();
         this._miViewSizeMode = new System.Windows.Forms.MenuItem();
         this._miViewSizeModeNormal = new System.Windows.Forms.MenuItem();
         this._miViewSizeModeFit = new System.Windows.Forms.MenuItem();
         this._miViewSizeModeFitWidth = new System.Windows.Forms.MenuItem();
         this._miOptions = new System.Windows.Forms.MenuItem();
         this._miOptionsPen = new System.Windows.Forms.MenuItem();
         this._miOptionsBrush = new System.Windows.Forms.MenuItem();
         this._miAction = new System.Windows.Forms.MenuItem();
         this._miActionNone = new System.Windows.Forms.MenuItem();
         this._miActionPan = new System.Windows.Forms.MenuItem();
         this._miActionZoomToRectangle = new System.Windows.Forms.MenuItem();
         this._miActionLine = new System.Windows.Forms.MenuItem();
         this._miActionRectangle = new System.Windows.Forms.MenuItem();
         this._miActionEllipse = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this._tbMain = new System.Windows.Forms.ToolBar();
         this._tbbFileOpen = new System.Windows.Forms.ToolBarButton();
         this._tbbFileSave = new System.Windows.Forms.ToolBarButton();
         this._tbbSep1 = new System.Windows.Forms.ToolBarButton();
         this._tbbZoomNone = new System.Windows.Forms.ToolBarButton();
         this._tbbZoomIn = new System.Windows.Forms.ToolBarButton();
         this._tbbZoomOut = new System.Windows.Forms.ToolBarButton();
         this._tbbSep2 = new System.Windows.Forms.ToolBarButton();
         this._tbbActionNone = new System.Windows.Forms.ToolBarButton();
         this._tbbActionPan = new System.Windows.Forms.ToolBarButton();
         this._tbbActionZoomToRectangle = new System.Windows.Forms.ToolBarButton();
         this._tbbActionLine = new System.Windows.Forms.ToolBarButton();
         this._tbbActionRectangle = new System.Windows.Forms.ToolBarButton();
         this._tbbActionEllipse = new System.Windows.Forms.ToolBarButton();
         this._sbMain = new System.Windows.Forms.StatusBar();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miView,
            this._miOptions,
            this._miAction,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileOpen,
            this._miFileSave,
            this._miFileSaveAs,
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
         // _miFileSave
         // 
         this._miFileSave.Index = 1;
         this._miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this._miFileSave.Text = "&Save";
         this._miFileSave.Click += new System.EventHandler(this._miFileSave_Click);
         // 
         // _miFileSaveAs
         // 
         this._miFileSaveAs.Index = 2;
         this._miFileSaveAs.Text = "Save &As...";
         this._miFileSaveAs.Click += new System.EventHandler(this._miFileSaveAs_Click);
         // 
         // _miFileSep1
         // 
         this._miFileSep1.Index = 3;
         this._miFileSep1.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 4;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miView
         // 
         this._miView.Index = 1;
         this._miView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miViewZoom,
            this._miViewSizeMode});
         this._miView.Text = "&View";
         // 
         // _miViewZoom
         // 
         this._miViewZoom.Index = 0;
         this._miViewZoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miViewZoomNone,
            this._miViewZoomIn,
            this._miViewZoomOut});
         this._miViewZoom.Text = "&Zoom";
         // 
         // _miViewZoomNone
         // 
         this._miViewZoomNone.Index = 0;
         this._miViewZoomNone.Text = "&None (100%)";
         this._miViewZoomNone.Click += new System.EventHandler(this._miViewZoom_Click);
         // 
         // _miViewZoomIn
         // 
         this._miViewZoomIn.Index = 1;
         this._miViewZoomIn.Text = "&In";
         this._miViewZoomIn.Click += new System.EventHandler(this._miViewZoom_Click);
         // 
         // _miViewZoomOut
         // 
         this._miViewZoomOut.Index = 2;
         this._miViewZoomOut.Text = "&Out";
         this._miViewZoomOut.Click += new System.EventHandler(this._miViewZoom_Click);
         // 
         // _miViewSizeMode
         // 
         this._miViewSizeMode.Index = 1;
         this._miViewSizeMode.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miViewSizeModeNormal,
            this._miViewSizeModeFit,
            this._miViewSizeModeFitWidth});
         this._miViewSizeMode.Text = "&Size Mode";
         // 
         // _miViewSizeModeNormal
         // 
         this._miViewSizeModeNormal.Index = 0;
         this._miViewSizeModeNormal.Text = "&Normal";
         this._miViewSizeModeNormal.Click += new System.EventHandler(this._miViewSizeMode_Click);
         // 
         // _miViewSizeModeFit
         // 
         this._miViewSizeModeFit.Index = 1;
         this._miViewSizeModeFit.Text = "&Fit";
         this._miViewSizeModeFit.Click += new System.EventHandler(this._miViewSizeMode_Click);
         // 
         // _miViewSizeModeFitWidth
         // 
         this._miViewSizeModeFitWidth.Index = 2;
         this._miViewSizeModeFitWidth.Text = "Fit &Width";
         this._miViewSizeModeFitWidth.Click += new System.EventHandler(this._miViewSizeMode_Click);
         // 
         // _miOptions
         // 
         this._miOptions.Index = 2;
         this._miOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miOptionsPen,
            this._miOptionsBrush});
         this._miOptions.Text = "&Options";
         // 
         // _miOptionsPen
         // 
         this._miOptionsPen.Index = 0;
         this._miOptionsPen.Text = "&Pen...";
         this._miOptionsPen.Click += new System.EventHandler(this._miOptionsPen_Click);
         // 
         // _miOptionsBrush
         // 
         this._miOptionsBrush.Index = 1;
         this._miOptionsBrush.Text = "&Brush...";
         this._miOptionsBrush.Click += new System.EventHandler(this._miOptionsBrush_Click);
         // 
         // _miAction
         // 
         this._miAction.Index = 3;
         this._miAction.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miActionNone,
            this._miActionPan,
            this._miActionZoomToRectangle,
            this._miActionLine,
            this._miActionRectangle,
            this._miActionEllipse});
         this._miAction.Text = "&Action";
         // 
         // _miActionNone
         // 
         this._miActionNone.Index = 0;
         this._miActionNone.Text = "&None";
         this._miActionNone.Click += new System.EventHandler(this._miAction_Click);
         // 
         // _miActionPan
         // 
         this._miActionPan.Index = 1;
         this._miActionPan.Text = "&Pan";
         this._miActionPan.Click += new System.EventHandler(this._miAction_Click);
         // 
         // _miActionZoomToRectangle
         // 
         this._miActionZoomToRectangle.Index = 2;
         this._miActionZoomToRectangle.Text = "&Zoom to Rectangle";
         this._miActionZoomToRectangle.Click += new System.EventHandler(this._miAction_Click);
         // 
         // _miActionLine
         // 
         this._miActionLine.Index = 3;
         this._miActionLine.Text = "&Line";
         this._miActionLine.Click += new System.EventHandler(this._miAction_Click);
         // 
         // _miActionRectangle
         // 
         this._miActionRectangle.Index = 4;
         this._miActionRectangle.Text = "&Rectangle";
         this._miActionRectangle.Click += new System.EventHandler(this._miAction_Click);
         // 
         // _miActionEllipse
         // 
         this._miActionEllipse.Index = 5;
         this._miActionEllipse.Text = "&Ellipse";
         this._miActionEllipse.Click += new System.EventHandler(this._miAction_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 4;
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
         // _tbMain
         // 
         this._tbMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
         this._tbMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this._tbbFileOpen,
            this._tbbFileSave,
            this._tbbSep1,
            this._tbbZoomNone,
            this._tbbZoomIn,
            this._tbbZoomOut,
            this._tbbSep2,
            this._tbbActionNone,
            this._tbbActionPan,
            this._tbbActionZoomToRectangle,
            this._tbbActionLine,
            this._tbbActionRectangle,
            this._tbbActionEllipse});
         this._tbMain.DropDownArrows = true;
         this._tbMain.Location = new System.Drawing.Point(0, 0);
         this._tbMain.Name = "_tbMain";
         this._tbMain.ShowToolTips = true;
         this._tbMain.Size = new System.Drawing.Size(713, 28);
         this._tbMain.TabIndex = 0;
         this._tbMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this._tbMain_ButtonClick);
         // 
         // _tbbFileOpen
         // 
         this._tbbFileOpen.ImageIndex = 0;
         this._tbbFileOpen.Name = "_tbbFileOpen";
         this._tbbFileOpen.ToolTipText = "Open";
         // 
         // _tbbFileSave
         // 
         this._tbbFileSave.ImageIndex = 1;
         this._tbbFileSave.Name = "_tbbFileSave";
         this._tbbFileSave.ToolTipText = "Save";
         // 
         // _tbbSep1
         // 
         this._tbbSep1.Name = "_tbbSep1";
         this._tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // _tbbZoomNone
         // 
         this._tbbZoomNone.ImageIndex = 2;
         this._tbbZoomNone.Name = "_tbbZoomNone";
         this._tbbZoomNone.ToolTipText = "No Zoom (100%)";
         // 
         // _tbbZoomIn
         // 
         this._tbbZoomIn.ImageIndex = 3;
         this._tbbZoomIn.Name = "_tbbZoomIn";
         this._tbbZoomIn.ToolTipText = "Zoom In";
         // 
         // _tbbZoomOut
         // 
         this._tbbZoomOut.ImageIndex = 4;
         this._tbbZoomOut.Name = "_tbbZoomOut";
         this._tbbZoomOut.ToolTipText = "Zoom Out";
         // 
         // _tbbSep2
         // 
         this._tbbSep2.Name = "_tbbSep2";
         this._tbbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // _tbbActionNone
         // 
         this._tbbActionNone.ImageIndex = 5;
         this._tbbActionNone.Name = "_tbbActionNone";
         this._tbbActionNone.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
         this._tbbActionNone.ToolTipText = "None";
         // 
         // _tbbActionPan
         // 
         this._tbbActionPan.ImageIndex = 6;
         this._tbbActionPan.Name = "_tbbActionPan";
         this._tbbActionPan.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
         this._tbbActionPan.ToolTipText = "Pan";
         // 
         // _tbbActionZoomToRectangle
         // 
         this._tbbActionZoomToRectangle.ImageIndex = 7;
         this._tbbActionZoomToRectangle.Name = "_tbbActionZoomToRectangle";
         this._tbbActionZoomToRectangle.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
         this._tbbActionZoomToRectangle.ToolTipText = "Zoom To Rectangle";
         // 
         // _tbbActionLine
         // 
         this._tbbActionLine.ImageIndex = 8;
         this._tbbActionLine.Name = "_tbbActionLine";
         this._tbbActionLine.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
         this._tbbActionLine.ToolTipText = "Line";
         // 
         // _tbbActionRectangle
         // 
         this._tbbActionRectangle.ImageIndex = 9;
         this._tbbActionRectangle.Name = "_tbbActionRectangle";
         this._tbbActionRectangle.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
         this._tbbActionRectangle.ToolTipText = "Rectangle";
         // 
         // _tbbActionEllipse
         // 
         this._tbbActionEllipse.ImageIndex = 10;
         this._tbbActionEllipse.Name = "_tbbActionEllipse";
         this._tbbActionEllipse.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
         this._tbbActionEllipse.ToolTipText = "Ellipse";
         // 
         // _sbMain
         // 
         this._sbMain.Location = new System.Drawing.Point(0, 403);
         this._sbMain.Name = "_sbMain";
         this._sbMain.Size = new System.Drawing.Size(713, 22);
         this._sbMain.TabIndex = 1;
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(713, 425);
         this.Controls.Add(this._sbMain);
         this.Controls.Add(this._tbMain);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main( )
      {
         if (!Support.SetLicense())
            return;

         Application.Run(new MainForm());
      }

      /// <summary>
      /// Actions to do in this app
      /// </summary>
      private enum ActionType
      {
         None,
         Pan,
         ZoomToRectangle,
         Line,
         Rectangle,
         Ellipse
      }

      // current action
      private ActionType _action;

      // if image needs saving or not
      private bool _isDirty;

      // the raster codecs used in load/save
      private RasterCodecs _codecs;

      // save the last image file name
      private string _fileName;

      // origianl bits per pixel of the loaded image
      private int _originalBitsPerPixel;

      // current pen properties
      private int _penWidth;
      private Color _penColor;

      // current brush properties
      private bool _brushUse;
      private Color _brushColor;

      // true if we are currently tracking a line, rectangle or ellipse
      private bool _tracking;

      // holds the coordinates of the tracking line
      private Point _trackingStartPoint;
      private Point _trackingEndPoint;

      // holds the coordinates of the tracking rectangle or ellipse
      private Rectangle _trackingRectangle;

      // The raster image viewer object.
      private ImageViewer _viewer;

      private string _openInitialPath = string.Empty;

      private ImageViewerNoneInteractiveMode _noneInteractiveMode = null;
      private ImageViewerPanZoomInteractiveMode _panInteractiveMode = null;
      private ImageViewerZoomToInteractiveMode _zoomToInteractiveMode = null;

      public ImageViewerNoneInteractiveMode NoneInteractiveMode
      {
         get
         {
            return _noneInteractiveMode;
         }
         set
         {
            _noneInteractiveMode = value;
         }
      }

      public ImageViewerPanZoomInteractiveMode PanInteractiveMode
      {
         get
         {
            return _panInteractiveMode;
         }
         set
         {
            _panInteractiveMode = value;
         }
      }

      public ImageViewerZoomToInteractiveMode ZoomToInteractiveMode
      {
         get
         {
            return _zoomToInteractiveMode;
         }
         set
         {
            _zoomToInteractiveMode = value;
         }
      }

      /// <summary>
      /// Initializes the application
      /// </summary>
      private void MainForm_Load(object sender, System.EventArgs e)
      {
         // Initialize the raster viewer object
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.MouseUp += new System.Windows.Forms.MouseEventHandler(_viewer_MouseUp);
         _viewer.MouseDown += new System.Windows.Forms.MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseMove += new System.Windows.Forms.MouseEventHandler(_viewer_MouseMove);

         _noneInteractiveMode = new ImageViewerNoneInteractiveMode();
         _panInteractiveMode = new ImageViewerPanZoomInteractiveMode();
         _zoomToInteractiveMode = new ImageViewerZoomToInteractiveMode();

         _viewer.InteractiveModes.BeginUpdate();
         _viewer.InteractiveModes.Add(_noneInteractiveMode);
         _viewer.InteractiveModes.Add(_panInteractiveMode);
         _viewer.InteractiveModes.Add(_zoomToInteractiveMode);
         _viewer.InteractiveModes.EndUpdate();

         RasterPaintProperties props = RasterPaintProperties.Default;
         props.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic;
         _viewer.PaintProperties = props;

         // A bug in Visual Studio 2003 prevents the LostFocus event from showing on the
         // control Events property page.  We need to hook into this event manually
         _viewer.LostFocus += new EventHandler(_viewer_LostFocus);

         // setup the toolbar images
         Bitmap btmp = new Bitmap(GetType(), "Resources.ToolBar.bmp");
         btmp.MakeTransparent(btmp.GetPixel(0, 0));
         _tbMain.ImageList = new ImageList();
         _tbMain.ImageList.ColorDepth = ColorDepth.Depth24Bit;
         _tbMain.ImageList.ImageSize = new Size(btmp.Height, btmp.Height);
         _tbMain.ImageList.Images.AddStrip(btmp);

         // setup our caption
         Messager.Caption = "LEADTOOLS for .NET C# Draw Demo";
         Text = Messager.Caption;

         foreach (ImageViewerInteractiveMode mode in _viewer.InteractiveModes)
         {
            mode.IsEnabled = false;
         }

         // make sure the viewer interactive mode is set to none
         _viewer.InteractiveModes.EnableById(_noneInteractiveMode.Id);

         // start with no action
         _action = ActionType.None;
         _isDirty = false;

         // setup the initial pen and brush
         _penWidth = 1;
         _penColor = Color.Red;
         _brushUse = false;
         _brushColor = Color.White;

         // we are not tracking anything yet
         _tracking = false;
         _trackingStartPoint = Point.Empty;
         _trackingEndPoint = Point.Empty;
         _trackingRectangle = Rectangle.Empty;

         // intitialize the codecs object
         _codecs = new RasterCodecs();

         UpdateMyControls();
         UpdateStatusBarText();
      }

      /// <summary>
      /// Updates the UI depending on the program state
      /// </summary>
      private void UpdateMyControls( )
      {
         // update the menus and the toolbar buttons
         if(_viewer.Image != null)
         {
            _miFileSave.Visible = true;
            _miFileSave.Enabled = _isDirty;
            _miFileSaveAs.Visible = true;
            _miFileSaveAs.Enabled = true;
            _miView.Enabled = true;
            _miView.Visible = true;
            _miViewZoomIn.Enabled = (_viewer.SizeMode == ControlSizeMode.ActualSize);
            _miViewZoomOut.Enabled = (_viewer.SizeMode == ControlSizeMode.ActualSize);
            _miViewSizeModeNormal.Checked = (_viewer.SizeMode == ControlSizeMode.ActualSize);
            _miViewSizeModeFit.Checked = (_viewer.SizeMode == ControlSizeMode.Fit);
            _miViewSizeModeFitWidth.Checked = (_viewer.SizeMode == ControlSizeMode.FitWidth);
            _miOptions.Enabled = true;
            _miOptions.Visible = true;
            _miAction.Enabled = true;
            _miAction.Visible = true;
            _miActionNone.Checked = (_action == ActionType.None);
            _miActionPan.Checked = (_action == ActionType.Pan);
            _miActionZoomToRectangle.Checked = (_action == ActionType.ZoomToRectangle);
            _miActionLine.Checked = (_action == ActionType.Line);
            _miActionRectangle.Checked = (_action == ActionType.Rectangle);
            _miActionEllipse.Checked = (_action == ActionType.Ellipse);

            _tbbFileSave.Visible = _miFileSave.Visible;
            _tbbFileSave.Enabled = _miFileSave.Enabled;
            _tbbSep1.Visible = true;
            _tbbZoomNone.Visible = true;
            _tbbZoomNone.Enabled = (_viewer.SizeMode == ControlSizeMode.ActualSize);
            _tbbZoomIn.Visible = true;
            _tbbZoomIn.Enabled = _miViewZoomIn.Enabled;
            _tbbZoomOut.Visible = true;
            _tbbZoomOut.Enabled = _miViewZoomOut.Enabled;
            _tbbSep2.Visible = true;
            _tbbActionNone.Visible = true;
            _tbbActionNone.Pushed = _miActionNone.Checked;
            _tbbActionPan.Visible = true;
            _tbbActionPan.Pushed = _miActionPan.Checked;
            _tbbActionZoomToRectangle.Visible = true;
            _tbbActionZoomToRectangle.Pushed = _miActionZoomToRectangle.Checked;
            _tbbActionLine.Visible = true;
            _tbbActionLine.Pushed = _miActionLine.Checked;
            _tbbActionRectangle.Visible = true;
            _tbbActionRectangle.Pushed = _miActionRectangle.Checked;
            _tbbActionEllipse.Visible = true;
            _tbbActionEllipse.Pushed = _miActionEllipse.Checked;
         }
         else
         {
            _miFileSave.Enabled = false;
            _miFileSave.Visible = false;
            _miFileSaveAs.Enabled = false;
            _miFileSaveAs.Visible = false;
            _miView.Enabled = false;
            _miView.Visible = false;
            _miOptions.Enabled = false;
            _miOptions.Visible = false;
            _miAction.Enabled = false;
            _miAction.Visible = false;

            _tbbFileSave.Visible = false;
            _tbbSep1.Visible = false;
            _tbbZoomNone.Visible = false;
            _tbbZoomIn.Visible = false;
            _tbbZoomOut.Visible = false;
            _tbbSep2.Visible = false;
            _tbbActionNone.Visible = false;
            _tbbActionPan.Visible = false;
            _tbbActionZoomToRectangle.Visible = false;
            _tbbActionLine.Visible = false;
            _tbbActionRectangle.Visible = false;
            _tbbActionEllipse.Visible = false;
         }
         _miViewZoom.Enabled = (_viewer.SizeMode == ControlSizeMode.ActualSize);

      }

      /// <summary>
      /// Updates the status bar text depending on current action
      /// </summary>
      private void UpdateStatusBarText( )
      {
         // update the status bar text
         switch(_action)
         {
            case ActionType.Pan:
               _sbMain.Text = "Click and drag to pan the image inside the viewer";
               break;

            case ActionType.ZoomToRectangle:
               _sbMain.Text = "Draw the rectangle area to zoom to";
               break;

            case ActionType.Line:
               _sbMain.Text = "Draw a line on the image";
               break;

            case ActionType.Rectangle:
               _sbMain.Text = "Draw a rectangle on the image";
               break;

            case ActionType.Ellipse:
               _sbMain.Text = "Draw an ellipse on the image";
               break;

            case ActionType.None:
            default:
               _sbMain.Text = "Ready";
               break;
         }
      }

      /// <summary>
      /// Check if the image is dirty, if so, offer to save it before you exit the app
      /// </summary>
      private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         e.Cancel = !CheckDirty();
      }

      /// <summary>
      /// Checks if the image is dirty, if so, offers to save the image or cancel
      /// </summary>
      private bool CheckDirty( )
      {
         bool ret = true;

         if(_viewer.Image != null && _isDirty)
         {
            string message = string.Format("The image in the {0} file has changed.{1}{1}Do you want to save the changes?", _fileName, Environment.NewLine);
            switch(Messager.ShowQuestion(this, message, MessageBoxIcon.Question, MessageBoxButtons.YesNoCancel))
            {
               case DialogResult.Yes:
                  ret = Save();
                  break;

               case DialogResult.Cancel:
                  ret = false;
                  break;

               case DialogResult.No:
               default:
                  break;
            }
         }

         return ret;
      }

      /// <summary>
      /// Save to original file, return true if saved correctly
      /// </summary>
      private bool Save( )
      {
         try
         {
            RasterImageFormat fmt = RasterImageFormat.Bmp;
            if (_viewer.Image.OriginalFormat != RasterImageFormat.Unknown)
               fmt = _viewer.Image.OriginalFormat;
            try
            {
               _codecs.Save(_viewer.Image, _fileName, fmt, _originalBitsPerPixel);
            }
            catch(RasterException ex)
            {
               if(ex.Code == RasterExceptionCode.BitsPerPixel)
                  _codecs.Save(_viewer.Image, _fileName, fmt, 0);
               else
                  throw ex;
            }

            _isDirty = false;
            return true;
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
            return false;
         }
         finally
         {
            UpdateMyControls();
         }
      }

      /// <summary>
      /// Load a new image
      /// </summary>
      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         try
         {
            if(CheckDirty())
            {
               // load the image
               ImageFileLoader loader = new ImageFileLoader();
               loader.OpenDialogInitialPath = _openInitialPath;
               if(loader.Load(this, _codecs, true) > 0)
               {
                  _openInitialPath = Path.GetDirectoryName(loader.FileName);
                  int bitsPerPixel = loader.Image.BitsPerPixel;
                  // we are going to draw on the image surface, so make sure its GDI+ compatible
                  RasterImageConverter.MakeCompatible(loader.Image, PixelFormat.DontCare, true);

                  // update the caption
                  Text = string.Format("{0} - {1}", loader.FileName, Messager.Caption);

                  // set the new image in the viewer and save the file name
                  _viewer.Image = loader.Image;
                  _viewer.Zoom(ControlSizeMode.ActualSize, 1, _viewer.DefaultZoomOrigin);
                  _fileName = loader.FileName;
                  _originalBitsPerPixel = bitsPerPixel;
               }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateMyControls();
         }
      }

      /// <summary>
      /// Save to original file
      /// </summary>
      private void _miFileSave_Click(object sender, System.EventArgs e)
      {
         Save();
      }

      /// <summary>
      /// Save to a new file
      /// </summary>
      private void _miFileSaveAs_Click(object sender, System.EventArgs e)
      {
         try
         {
            ImageFileSaver saver = new ImageFileSaver();
            if(saver.Save(this, _codecs, _viewer.Image))
            {
               // we need to load this new image
               RasterImage temp = _codecs.Load(saver.FileName);

               // update the caption
               Text = string.Format("{0} - {1}", saver.FileName, Messager.Caption);
               double scaleFactor = _viewer.ScaleFactor;
               Point position = _viewer.AutoScrollPosition;
               _viewer.Image = temp;
               _viewer.Zoom(_viewer.SizeMode, scaleFactor, _viewer.DefaultZoomOrigin);
               position.X = -position.X;
               position.Y = -position.Y;
               _viewer.AutoScrollPosition = position;
               _fileName = saver.FileName;
               _isDirty = false;
            }
         }
         catch(Exception ex)
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
      /// Handles View/Zoom menu
      /// </summary>
      private void _miViewZoom_Click(object sender, System.EventArgs e)
      {
         double scaleFactor = _viewer.ScaleFactor;

         if(sender == _miViewZoomNone)
            scaleFactor = 1;
         else if(sender == _miViewZoomIn)
            scaleFactor *= 1.2f;
         else if(sender == _miViewZoomOut)
            scaleFactor /= 1.2f;

         if(scaleFactor > 11)
            scaleFactor = 11;
         if(scaleFactor < 0.009)
            scaleFactor = 0.009F;

         if(scaleFactor != _viewer.ScaleFactor)
            _viewer.Zoom(ControlSizeMode.None, scaleFactor, _viewer.DefaultZoomOrigin);
      }

      /// <summary>
      /// Handles View/Size Mode menu
      /// </summary>
      private void _miViewSizeMode_Click(object sender, System.EventArgs e)
      {
         ControlSizeMode sizeMode = _viewer.SizeMode;

         if(sender == _miViewSizeModeNormal)
            sizeMode = ControlSizeMode.ActualSize;
         else if(sender == _miViewSizeModeFit)
            sizeMode = ControlSizeMode.Fit;
         else if(sender == _miViewSizeModeFitWidth)
            sizeMode = ControlSizeMode.FitWidth;

         if(sizeMode != _viewer.SizeMode)
         {
            _viewer.Zoom(sizeMode, _viewer.ScaleFactor, _viewer.DefaultZoomOrigin);
            // in this demo, we do not want to enable zooming when scale mode is not Normal
            if (_viewer.SizeMode != ControlSizeMode.ActualSize)
               _viewer.Zoom(_viewer.SizeMode, 1, _viewer.DefaultZoomOrigin);
            UpdateMyControls();
         }
      }

      /// <summary>
      /// Show the pen dialog and update current pen properties
      /// </summary>
      private void _miOptionsPen_Click(object sender, System.EventArgs e)
      {
         PenDialog dlg = new PenDialog();
         dlg.PenWidth = _penWidth;
         dlg.PenColor = _penColor;
         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            _penWidth = dlg.PenWidth;
            _penColor = dlg.PenColor;
         }
      }

      /// <summary>
      /// Show the brush dialog and update current brush properties
      /// </summary>
      private void _miOptionsBrush_Click(object sender, System.EventArgs e)
      {
         BrushDialog dlg = new BrushDialog();
         dlg.BrushUse = _brushUse;
         dlg.BrushColor = _brushColor;
         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            _brushUse = dlg.BrushUse;
            _brushColor = dlg.BrushColor;
         }
      }

      /// <summary>
      /// User either clicked the action menu or the action toobar.  Setup the new action
      /// </summary>
      private void _miAction_Click(object sender, System.EventArgs e)
      {
         // get the new action
         ActionType action = _action;

         if(sender == _miActionNone)
            action = ActionType.None;
         else if(sender == _miActionPan)
            action = ActionType.Pan;
         else if(sender == _miActionZoomToRectangle)
            action = ActionType.ZoomToRectangle;
         else if(sender == _miActionLine)
            action = ActionType.Line;
         else if(sender == _miActionRectangle)
            action = ActionType.Rectangle;
         else if(sender == _miActionEllipse)
            action = ActionType.Ellipse;

         if(action != _action)
         {
            // action has changed
            _action = action;


            foreach (ImageViewerInteractiveMode mode in _viewer.InteractiveModes)
            {
               mode.IsEnabled = false;
            }

            // setup the action and update the mouse cursor

            switch(_action)
            {
               case ActionType.Pan:
                  _viewer.InteractiveModes.EnableById(_panInteractiveMode.Id);
                  _viewer.Cursor = Cursors.Hand;
                  break;

               case ActionType.ZoomToRectangle:
                  _viewer.InteractiveModes.EnableById(_zoomToInteractiveMode.Id);
                  _viewer.Cursor = Cursors.Cross;
                  break;

               case ActionType.Line:
               case ActionType.Rectangle:
               case ActionType.Ellipse:
                  _viewer.InteractiveModes.EnableById(_noneInteractiveMode.Id);
                  _viewer.Cursor = Cursors.Cross;
                  break;

               case ActionType.None:
               default:
                  _viewer.InteractiveModes.EnableById(_noneInteractiveMode.Id);
                  _viewer.Cursor = Cursors.Default;
                  break;
            }

            UpdateMyControls();
            UpdateStatusBarText();
         }
      }

      /// <summary>
      /// Show the about dialog
      /// </summary>
      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Draw", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      /// <summary>
      /// Toolbar button is clicked, call the corresponding menu PerformClick method
      /// </summary>
      private void _tbMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
      {
         if(e.Button == _tbbFileOpen)
            _miFileOpen.PerformClick();
         else if(e.Button == _tbbFileSave)
            _miFileSave.PerformClick();
         else if(e.Button == _tbbZoomNone)
            _miViewZoomNone.PerformClick();
         else if(e.Button == _tbbZoomIn)
            _miViewZoomIn.PerformClick();
         else if(e.Button == _tbbZoomOut)
            _miViewZoomOut.PerformClick();
         else if(e.Button == _tbbActionNone)
            _miActionNone.PerformClick();
         else if(e.Button == _tbbActionPan)
            _miActionPan.PerformClick();
         else if(e.Button == _tbbActionZoomToRectangle)
            _miActionZoomToRectangle.PerformClick();
         else if(e.Button == _tbbActionLine)
            _miActionLine.PerformClick();
         else if(e.Button == _tbbActionRectangle)
            _miActionRectangle.PerformClick();
         else if(e.Button == _tbbActionEllipse)
            _miActionEllipse.PerformClick();
      }

      /// <summary>
      /// User clicks on the viewer.  Depending on the current action, we might need to start tracking a line, rectangle or an ellipse.
      /// </summary>
      private void _viewer_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if(_tracking)
         {
            // probably a right button down while we are tracking, cancel.
            EndTracking();
         }
         else
         {
            // only start tracking if the viewer has an image and the click was a left button click
            if(_viewer.Image != null && e.Button == MouseButtons.Left)
            {
               switch(_action)
               {
                  case ActionType.Line:
                     // start tracking a line
                     _trackingStartPoint = new Point(e.X, e.Y);
                     _trackingEndPoint = _trackingStartPoint;
                     BeginTracking();
                     break;

                  case ActionType.Rectangle:
                  case ActionType.Ellipse:
                     // start tracking a rectangle or an ellipse
                     _trackingRectangle = new Rectangle(e.X, e.Y, 0, 0);
                     BeginTracking();
                     break;

                  default:
                     break;
               }
            }
         }
      }

      /// <summary>
      /// User moves the mouse over the viewer.  Depending on the current action, we might need to update the tracking process
      /// </summary>
      private void _viewer_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if(_tracking)
         {
            switch(_action)
            {
               case ActionType.Line:
                  // update the end point of the tracking line

                  // first erase the line already on screen
                  Track();

                  // update the point and draw the new tracking line
                  _trackingEndPoint = new Point(e.X, e.Y);
                  Track();
                  break;

               case ActionType.Rectangle:
               case ActionType.Ellipse:
                  // update the bottom-right coordinate of the tracking rectangle

                  // first erase the rectangle already on screen
                  Track();

                  // update and draw the new tracking rectangle
                  _trackingRectangle = Rectangle.FromLTRB(_trackingRectangle.Left, _trackingRectangle.Top, e.X, e.Y);
                  Track();
                  break;

               default:
                  break;
            }
         }
      }

      private Matrix ToMatrix(LeadMatrix LMatrix)
      {
         return new Matrix((float)LMatrix.M11, (float)LMatrix.M12, (float)LMatrix.M21, (float)LMatrix.M22, (float)LMatrix.OffsetX, (float)LMatrix.OffsetY);
      }

      /// <summary>
      /// Users has released the mouse button on the viewer.  If we are tracking, we need to end it and draw a line, rectangle or an ellipse on the image
      /// </summary>
      private void _viewer_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if(_tracking)
         {
            // end the tracking
            EndTracking();

            switch(_action)
            {
               case ActionType.Line:
                  // only draw the line if it has some length
                  if(_trackingStartPoint.X != _trackingEndPoint.X || _trackingStartPoint.Y != _trackingEndPoint.Y)
                  {
                     // convert the tracking points to image coordinates
                     Transformer t = new Transformer(ToMatrix(_viewer.ImageTransform));
                     _trackingStartPoint = Point.Round(t.PointToLogical(_trackingStartPoint));
                     _trackingEndPoint = Point.Round(t.PointToLogical(_trackingEndPoint));
                     _trackingStartPoint = Leadtools.Demos.Converters.ConvertPoint(_viewer.Image.PointToImage(RasterViewPerspective.TopLeft, Leadtools.Demos.Converters.ConvertPoint(_trackingStartPoint)));
                     _trackingEndPoint = Leadtools.Demos.Converters.ConvertPoint(_viewer.Image.PointToImage(RasterViewPerspective.TopLeft, Leadtools.Demos.Converters.ConvertPoint(_trackingEndPoint)));

                     // create the graphics container for the image and draw the line
                     using (RasterImageGdiPlusGraphicsContainer container = new RasterImageGdiPlusGraphicsContainer(_viewer.Image))

                     {
                        using(Pen pen = new Pen(_penColor, _penWidth))
                        {
                           // use anti-alias lines
                           container.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                           container.Graphics.DrawLine(pen, _trackingStartPoint, _trackingEndPoint);
                        }
                     }

                     _viewer.Invalidate();

                     _isDirty = true;
                     UpdateMyControls();
                  }
                  break;

               case ActionType.Rectangle:
               case ActionType.Ellipse:
                  // only draw the rectangle/ellipse if it has some width and height
                  _trackingRectangle = DemosGlobal.FixRectangle(_trackingRectangle);
                  if(_trackingRectangle.Width > 0 && _trackingRectangle.Height > 0)
                  {
                     // convert the tracking rectangle to image coordinates
                     Transformer t = new Transformer(ToMatrix(_viewer.ImageTransform));
                     _trackingRectangle = Rectangle.Round(t.RectangleToLogical(_trackingRectangle));
                     _trackingRectangle = Leadtools.Demos.Converters.ConvertRect(_viewer.Image.RectangleToImage(RasterViewPerspective.TopLeft, Leadtools.Demos.Converters.ConvertRect(_trackingRectangle)));

                     // create the graphics container for the image and draw the rectangle/ellipse
                     using (RasterImageGdiPlusGraphicsContainer container = new RasterImageGdiPlusGraphicsContainer(_viewer.Image))
                     {
                        // we are going to use a graphics path to correctly align the rectangle/ellipse edge with the interior
                        using(GraphicsPath path = new GraphicsPath())
                        {
                           if(_action == ActionType.Rectangle)
                              path.AddRectangle(_trackingRectangle);
                           else
                              path.AddEllipse(_trackingRectangle);

                           // fill this path
                           if(_brushUse)
                           {
                              using(Brush brush = new SolidBrush(_brushColor))
                                 container.Graphics.FillPath(brush, path);
                           }

                           // stroke the path
                           using(Pen pen = new Pen(_penColor, _penWidth))
                           {
                              // use anti-alias lines
                              container.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                              container.Graphics.DrawPath(pen, path);
                           }
                        }
                     }

                     _viewer.Invalidate();

                     _isDirty = true;
                     UpdateMyControls();
                  }
                  break;
            }
         }
      }

      /// <summary>
      /// The viewer has lost the focus.  If we are tracking, end it
      /// </summary>
      private void _viewer_LostFocus(object sender, EventArgs e)
      {
         if(_tracking)
            EndTracking();
      }

      /// <summary>
      /// Begins the tracking process
      /// </summary>
      private void BeginTracking( )
      {
         // first thing we need to do is set the mouse capture to the viewer
         _viewer.Capture = true;

         // limit the cursor movement inside the current image rectangle of the viewer.
         // we first obtain the rectangle for the image, transform it to physical coordinates
         // depending on the current transformation of in the viewer, finally we intersect this
         // rectangle with the viewer's client rectangle for the cases where the image rectangle
         // is bigger than the viewer's client rectangle (i.e. when the viewer has scrollbars)

         RectangleF imageRectangle = new RectangleF(PointF.Empty, new SizeF(_viewer.ImageSize.Width,_viewer.ImageSize.Height));

         // Leadtools.Helper.Transformer class can transform a rectangle from logical to physical
         Transformer t = new Transformer(ToMatrix(_viewer.ImageTransform));
         imageRectangle = t.RectangleToPhysical(imageRectangle);

         // intersect this rectangle with the viewer client rectangle
         Rectangle clip = Rectangle.Intersect(Rectangle.Round(imageRectangle), _viewer.ClientRectangle);

         // setup this rectangle as our cursor clip
         Cursor.Clip = _viewer.RectangleToScreen(clip);

         // draw the tracking object on screen
         Track();

         _tracking = true;
      }

      /// <summary>
      /// Ends the tracking process
      /// </summary>
      private void EndTracking( )
      {
         if(_tracking)
         {
            // we have drawn the tracking object on screen, erase it
            Track();

            // release the capture and reset the cursor clipping rectangle
            _viewer.Capture = false;
            Cursor.Clip = Rectangle.Empty;

            _tracking = false;
         }
      }

      /// <summary>
      /// Draws the current tracking shape on the screen
      /// </summary>
      private void Track( )
      {
         // use the ControlPaint.DrawReversibleXXX, do not forget, these methods take screen coordinates

         switch(_action)
         {
            case ActionType.Line:
               ControlPaint.DrawReversibleLine(
                  _viewer.PointToScreen(_trackingStartPoint),
                  _viewer.PointToScreen(_trackingEndPoint),
                  Color.Transparent);
               break;

            case ActionType.Ellipse:
            case ActionType.Rectangle:
               // notice that ControlPaint does not have a method to draw a reversible ellipse.  We could
               // draw our own ellipse by generating a series of lines and call DrawReversibleLine on them.
               // In this demo, we simply chose to track an ellipse by its bounding rectangle
               ControlPaint.DrawReversibleFrame(
                  _viewer.RectangleToScreen(_trackingRectangle),
                  Color.Transparent,
                  FrameStyle.Thick);
               break;

            default:
               break;
         }
      }
   }
}
