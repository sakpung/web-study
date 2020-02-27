// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using System.Text;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Annotations;
using Leadtools.WinForms;
using Leadtools.Codecs;
using Leadtools.Internal;

using Leadtools.Drawing;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.BatesStamp;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Designers;
using Leadtools.Annotations.Rendering;
using System.Media;
using System.Diagnostics;
using Leadtools.Annotations.WinForms;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;
using Leadtools.Controls;

namespace AnnotationsBatesStampComposer
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   ///
   public class MainForm : System.Windows.Forms.Form
   {
      private Random _randomNumber = new Random();
      private AutomationManagerHelper _managerHelper = null;
      private AnnBatesStampComposer _batesStampComposer = new AnnBatesStampComposer();
      private AnnContainer _batesStampContainer = new AnnContainer();
      private string _openInitialPath = string.Empty;

      public AutomationManagerHelper ManagerHelper
      {
         get { return _managerHelper; }
      }

      private System.Windows.Forms.MainMenu _mainMenu;
      private System.Windows.Forms.MenuItem _menuItemFile;
      private System.Windows.Forms.MenuItem _menuItemFileOpen;
      private System.Windows.Forms.MenuItem _menuItemFileSep1;
      private System.Windows.Forms.MenuItem _menuItemFileExit;
      private System.Windows.Forms.MenuItem _menuItemFilePrint;
      private System.Windows.Forms.MenuItem _menuItemFilePrintPreview;
      private System.Windows.Forms.MenuItem _menuItemFileSep2;
      private System.Windows.Forms.MenuItem _menuItemFileSep3;
      private System.Windows.Forms.MenuItem _menuItemHelp;
      private System.Windows.Forms.MenuItem _menuItemHelpAbout;
      private System.Windows.Forms.MenuItem _menuItemWindow;
      private System.Windows.Forms.MenuItem _menuItemWindowCascade;
      private System.Windows.Forms.MenuItem _menuItemWindowTileHorizontally;
      private System.Windows.Forms.MenuItem _menuItemWindowTileVertically;
      private System.Windows.Forms.MenuItem _menuItemWindowArrangeIcons;
      private System.Windows.Forms.MenuItem _menuItemWindowCloseAll;
      private System.Windows.Forms.MenuItem _menuItemView;
      private System.Windows.Forms.MenuItem _menuItemViewSizeMode;
      private System.Windows.Forms.MenuItem _menuItemViewSizeModeNormal;
      private System.Windows.Forms.MenuItem _menuItemViewSizeModeStretch;
      private System.Windows.Forms.MenuItem _menuItemViewSizeModeFitAlways;
      private System.Windows.Forms.MenuItem _menuItemViewSizeModeFitWidth;
      private System.Windows.Forms.MenuItem _menuItemViewZoom;
      private System.Windows.Forms.MenuItem _menuItemViewZoomIn;
      private System.Windows.Forms.MenuItem _menuItemViewZoomOut;
      private System.Windows.Forms.MenuItem _menuItemViewZoomSep1;
      private System.Windows.Forms.MenuItem _menuItemViewZoomNormal;
      private System.Windows.Forms.MenuItem _menuItemViewPaintProperties;
      private System.Windows.Forms.MenuItem _menuItemViewSep1;
      private System.Windows.Forms.ToolBar _toolBarMain;
      private System.Windows.Forms.ToolBarButton _tbbSave;
      private System.Windows.Forms.ToolBarButton _tbbOpen;
      private System.Windows.Forms.MenuItem _menuItemFileSaveBatesStamp;
      private System.Windows.Forms.MenuItem _menuItemFileSaveImage;
      private System.Windows.Forms.ToolBarButton _tbbZoomIn;
      private System.Windows.Forms.ToolBarButton _tbbZoomOut;
      private System.Windows.Forms.ToolBarButton _tbbNoZoom;
      private System.Windows.Forms.StatusBar _sbMain;
      private System.Windows.Forms.ToolBarButton _tbbSep3;
      private System.Windows.Forms.MenuItem _menuItemViewZoomValue;
      private System.Windows.Forms.MenuItem _menuItemViewSizeModeFit;
      private System.Windows.Forms.MenuItem _menuItemViewSep2;
      private MenuItem _menuItemViewUseDpi;
      private MenuItem _menuItemBatesStamp;
      private MenuItem _menuItemBatesStampProperties;
      private MenuItem _menuItemAnnotationsBurnBatesStamp;
      private MenuItem _menuItemFileSaveImageAs;
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mainMenu = new System.Windows.Forms.MainMenu(this.components);
         this._menuItemFile = new System.Windows.Forms.MenuItem();
         this._menuItemFileOpen = new System.Windows.Forms.MenuItem();
         this._menuItemFileSaveImage = new System.Windows.Forms.MenuItem();
         this._menuItemFileSaveImageAs = new System.Windows.Forms.MenuItem();
         this._menuItemFileSaveBatesStamp = new System.Windows.Forms.MenuItem();
         this._menuItemFileSep1 = new System.Windows.Forms.MenuItem();
         this._menuItemFilePrint = new System.Windows.Forms.MenuItem();
         this._menuItemFilePrintPreview = new System.Windows.Forms.MenuItem();
         this._menuItemFileSep2 = new System.Windows.Forms.MenuItem();
         this._menuItemFileSep3 = new System.Windows.Forms.MenuItem();
         this._menuItemFileExit = new System.Windows.Forms.MenuItem();
         this._menuItemView = new System.Windows.Forms.MenuItem();
         this._menuItemViewSizeMode = new System.Windows.Forms.MenuItem();
         this._menuItemViewSizeModeNormal = new System.Windows.Forms.MenuItem();
         this._menuItemViewSizeModeStretch = new System.Windows.Forms.MenuItem();
         this._menuItemViewSizeModeFitAlways = new System.Windows.Forms.MenuItem();
         this._menuItemViewSizeModeFitWidth = new System.Windows.Forms.MenuItem();
         this._menuItemViewSizeModeFit = new System.Windows.Forms.MenuItem();
         this._menuItemViewZoom = new System.Windows.Forms.MenuItem();
         this._menuItemViewZoomIn = new System.Windows.Forms.MenuItem();
         this._menuItemViewZoomOut = new System.Windows.Forms.MenuItem();
         this._menuItemViewZoomValue = new System.Windows.Forms.MenuItem();
         this._menuItemViewZoomSep1 = new System.Windows.Forms.MenuItem();
         this._menuItemViewZoomNormal = new System.Windows.Forms.MenuItem();
         this._menuItemViewSep1 = new System.Windows.Forms.MenuItem();
         this._menuItemViewPaintProperties = new System.Windows.Forms.MenuItem();
         this._menuItemViewUseDpi = new System.Windows.Forms.MenuItem();
         this._menuItemViewSep2 = new System.Windows.Forms.MenuItem();
         this._menuItemBatesStamp = new System.Windows.Forms.MenuItem();
         this._menuItemBatesStampProperties = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsBurnBatesStamp = new System.Windows.Forms.MenuItem();
         this._menuItemWindow = new System.Windows.Forms.MenuItem();
         this._menuItemWindowCascade = new System.Windows.Forms.MenuItem();
         this._menuItemWindowTileHorizontally = new System.Windows.Forms.MenuItem();
         this._menuItemWindowTileVertically = new System.Windows.Forms.MenuItem();
         this._menuItemWindowArrangeIcons = new System.Windows.Forms.MenuItem();
         this._menuItemWindowCloseAll = new System.Windows.Forms.MenuItem();
         this._menuItemHelp = new System.Windows.Forms.MenuItem();
         this._menuItemHelpAbout = new System.Windows.Forms.MenuItem();
         this._toolBarMain = new System.Windows.Forms.ToolBar();
         this._tbbOpen = new System.Windows.Forms.ToolBarButton();
         this._tbbSave = new System.Windows.Forms.ToolBarButton();
         this._tbbSep3 = new System.Windows.Forms.ToolBarButton();
         this._tbbZoomIn = new System.Windows.Forms.ToolBarButton();
         this._tbbZoomOut = new System.Windows.Forms.ToolBarButton();
         this._tbbNoZoom = new System.Windows.Forms.ToolBarButton();
         this._sbMain = new System.Windows.Forms.StatusBar();
         this.SuspendLayout();
         // 
         // _mainMenu
         // 
         this._mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFile,
            this._menuItemView,
            this._menuItemBatesStamp,
            this._menuItemWindow,
            this._menuItemHelp});
         // 
         // _menuItemFile
         // 
         this._menuItemFile.Index = 0;
         this._menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFileOpen,
            this._menuItemFileSaveImage,
            this._menuItemFileSaveImageAs,
            this._menuItemFileSaveBatesStamp,
            this._menuItemFileSep1,
            this._menuItemFilePrint,
            this._menuItemFilePrintPreview,
            this._menuItemFileSep2,
            this._menuItemFileSep3,
            this._menuItemFileExit});
         this._menuItemFile.Text = "&File";
         // 
         // _menuItemFileOpen
         // 
         this._menuItemFileOpen.Index = 0;
         this._menuItemFileOpen.RadioCheck = true;
         this._menuItemFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this._menuItemFileOpen.Text = "&Open...";
         this._menuItemFileOpen.Click += new System.EventHandler(this._menuItemFileOpen_Click);
         // 
         // _menuItemFileSaveImage
         // 
         this._menuItemFileSaveImage.Index = 1;
         this._menuItemFileSaveImage.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this._menuItemFileSaveImage.Text = "&Save Image";
         this._menuItemFileSaveImage.Click += new System.EventHandler(this._menuItemFileSaveImage_Click);
         // 
         // _menuItemFileSaveImageAs
         // 
         this._menuItemFileSaveImageAs.Index = 2;
         this._menuItemFileSaveImageAs.Text = "Save Image &As...";
         this._menuItemFileSaveImageAs.Click += new System.EventHandler(this._menuItemFileSaveImageAs_Click);
         // 
         // _menuItemFileSaveBatesStamp
         // 
         this._menuItemFileSaveBatesStamp.Enabled = false;
         this._menuItemFileSaveBatesStamp.Index = 3;
         this._menuItemFileSaveBatesStamp.RadioCheck = true;
         this._menuItemFileSaveBatesStamp.Text = "Save &Bates Stamp";
         this._menuItemFileSaveBatesStamp.Click += new System.EventHandler(this._menuItemFileSaveBatesStamp_Click);
         // 
         // _menuItemFileSep1
         // 
         this._menuItemFileSep1.Index = 4;
         this._menuItemFileSep1.RadioCheck = true;
         this._menuItemFileSep1.Text = "-";
         // 
         // _menuItemFilePrint
         // 
         this._menuItemFilePrint.Index = 5;
         this._menuItemFilePrint.RadioCheck = true;
         this._menuItemFilePrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
         this._menuItemFilePrint.Text = "&Print...";
         this._menuItemFilePrint.Click += new System.EventHandler(this._menuItemFilePrint_Click);
         // 
         // _menuItemFilePrintPreview
         // 
         this._menuItemFilePrintPreview.Index = 6;
         this._menuItemFilePrintPreview.RadioCheck = true;
         this._menuItemFilePrintPreview.Text = "Print Pre&view...";
         this._menuItemFilePrintPreview.Click += new System.EventHandler(this._menuItemFilePrintPreview_Click);
         // 
         // _menuItemFileSep2
         // 
         this._menuItemFileSep2.Index = 7;
         this._menuItemFileSep2.RadioCheck = true;
         this._menuItemFileSep2.Text = "-";
         // 
         // _menuItemFileSep3
         // 
         this._menuItemFileSep3.Index = 8;
         this._menuItemFileSep3.RadioCheck = true;
         this._menuItemFileSep3.Text = "-";
         // 
         // _menuItemFileExit
         // 
         this._menuItemFileExit.Index = 9;
         this._menuItemFileExit.RadioCheck = true;
         this._menuItemFileExit.Text = "E&xit";
         this._menuItemFileExit.Click += new System.EventHandler(this._menuItemFileExit_Click);
         // 
         // _menuItemView
         // 
         this._menuItemView.Index = 1;
         this._menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemViewSizeMode,
            this._menuItemViewZoom,
            this._menuItemViewSep1,
            this._menuItemViewPaintProperties,
            this._menuItemViewUseDpi,
            this._menuItemViewSep2});
         this._menuItemView.Text = "&View";
         // 
         // _menuItemViewSizeMode
         // 
         this._menuItemViewSizeMode.Index = 0;
         this._menuItemViewSizeMode.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemViewSizeModeNormal,
            this._menuItemViewSizeModeStretch,
            this._menuItemViewSizeModeFitAlways,
            this._menuItemViewSizeModeFitWidth,
            this._menuItemViewSizeModeFit});
         this._menuItemViewSizeMode.RadioCheck = true;
         this._menuItemViewSizeMode.Text = "&Size Mode";
         // 
         // _menuItemViewSizeModeNormal
         // 
         this._menuItemViewSizeModeNormal.Index = 0;
         this._menuItemViewSizeModeNormal.RadioCheck = true;
         this._menuItemViewSizeModeNormal.Text = "&Normal";
         this._menuItemViewSizeModeNormal.Click += new System.EventHandler(this._menuItemViewSizeMode_Click);
         // 
         // _menuItemViewSizeModeStretch
         // 
         this._menuItemViewSizeModeStretch.Index = 1;
         this._menuItemViewSizeModeStretch.RadioCheck = true;
         this._menuItemViewSizeModeStretch.Text = "&Stretch";
         this._menuItemViewSizeModeStretch.Click += new System.EventHandler(this._menuItemViewSizeMode_Click);
         // 
         // _menuItemViewSizeModeFitAlways
         // 
         this._menuItemViewSizeModeFitAlways.Index = 2;
         this._menuItemViewSizeModeFitAlways.RadioCheck = true;
         this._menuItemViewSizeModeFitAlways.Text = "Fit &Always";
         this._menuItemViewSizeModeFitAlways.Click += new System.EventHandler(this._menuItemViewSizeMode_Click);
         // 
         // _menuItemViewSizeModeFitWidth
         // 
         this._menuItemViewSizeModeFitWidth.Index = 3;
         this._menuItemViewSizeModeFitWidth.RadioCheck = true;
         this._menuItemViewSizeModeFitWidth.Text = "Fit &Width";
         this._menuItemViewSizeModeFitWidth.Click += new System.EventHandler(this._menuItemViewSizeMode_Click);
         // 
         // _menuItemViewSizeModeFit
         // 
         this._menuItemViewSizeModeFit.Index = 4;
         this._menuItemViewSizeModeFit.RadioCheck = true;
         this._menuItemViewSizeModeFit.Text = "&Fit";
         this._menuItemViewSizeModeFit.Click += new System.EventHandler(this._menuItemViewSizeMode_Click);
         // 
         // _menuItemViewZoom
         // 
         this._menuItemViewZoom.Index = 1;
         this._menuItemViewZoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemViewZoomIn,
            this._menuItemViewZoomOut,
            this._menuItemViewZoomValue,
            this._menuItemViewZoomSep1,
            this._menuItemViewZoomNormal});
         this._menuItemViewZoom.RadioCheck = true;
         this._menuItemViewZoom.Text = "&Zoom";
         // 
         // _menuItemViewZoomIn
         // 
         this._menuItemViewZoomIn.Index = 0;
         this._menuItemViewZoomIn.RadioCheck = true;
         this._menuItemViewZoomIn.Text = "&In";
         this._menuItemViewZoomIn.Click += new System.EventHandler(this._menuItemViewZoom_Click);
         // 
         // _menuItemViewZoomOut
         // 
         this._menuItemViewZoomOut.Index = 1;
         this._menuItemViewZoomOut.RadioCheck = true;
         this._menuItemViewZoomOut.Text = "&Out";
         this._menuItemViewZoomOut.Click += new System.EventHandler(this._menuItemViewZoom_Click);
         // 
         // _menuItemViewZoomValue
         // 
         this._menuItemViewZoomValue.Index = 2;
         this._menuItemViewZoomValue.Text = "&Value...";
         this._menuItemViewZoomValue.Click += new System.EventHandler(this._menuItemViewZoom_Click);
         // 
         // _menuItemViewZoomSep1
         // 
         this._menuItemViewZoomSep1.Index = 3;
         this._menuItemViewZoomSep1.RadioCheck = true;
         this._menuItemViewZoomSep1.Text = "-";
         // 
         // _menuItemViewZoomNormal
         // 
         this._menuItemViewZoomNormal.Index = 4;
         this._menuItemViewZoomNormal.RadioCheck = true;
         this._menuItemViewZoomNormal.Text = "&Normal (100%)";
         this._menuItemViewZoomNormal.Click += new System.EventHandler(this._menuItemViewZoom_Click);
         // 
         // _menuItemViewSep1
         // 
         this._menuItemViewSep1.Index = 2;
         this._menuItemViewSep1.RadioCheck = true;
         this._menuItemViewSep1.Text = "-";
         // 
         // _menuItemViewPaintProperties
         // 
         this._menuItemViewPaintProperties.Index = 3;
         this._menuItemViewPaintProperties.RadioCheck = true;
         this._menuItemViewPaintProperties.Text = "&Paint Properties...";
         this._menuItemViewPaintProperties.Click += new System.EventHandler(this._menuItemViewPaintProperties_Click);
         // 
         // _menuItemViewUseDpi
         // 
         this._menuItemViewUseDpi.Index = 4;
         this._menuItemViewUseDpi.Text = "&Use Dpi";
         this._menuItemViewUseDpi.Click += new System.EventHandler(this._menuItemViewUseDpi_Click);
         // 
         // _menuItemViewSep2
         // 
         this._menuItemViewSep2.Index = 5;
         this._menuItemViewSep2.Text = "-";
         // 
         // _menuItemBatesStamp
         // 
         this._menuItemBatesStamp.Index = 2;
         this._menuItemBatesStamp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemBatesStampProperties,
            this._menuItemAnnotationsBurnBatesStamp});
         this._menuItemBatesStamp.Text = "&Bates Stamp";
         // 
         // _menuItemBatesStampProperties
         // 
         this._menuItemBatesStampProperties.Index = 0;
         this._menuItemBatesStampProperties.Text = "Bates Stamp &Properties";
         this._menuItemBatesStampProperties.Click += new System.EventHandler(this._menuItemBatesStampProperties_Click);
         // 
         // _menuItemAnnotationsBurnBatesStamp
         // 
         this._menuItemAnnotationsBurnBatesStamp.Index = 1;
         this._menuItemAnnotationsBurnBatesStamp.Text = "Burn Bates &Stamp";
         this._menuItemAnnotationsBurnBatesStamp.Click += new System.EventHandler(this._menuItemAnnotationsBurnBatesStamp_Click);
         // 
         // _menuItemWindow
         // 
         this._menuItemWindow.Index = 3;
         this._menuItemWindow.MdiList = true;
         this._menuItemWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemWindowCascade,
            this._menuItemWindowTileHorizontally,
            this._menuItemWindowTileVertically,
            this._menuItemWindowArrangeIcons,
            this._menuItemWindowCloseAll});
         this._menuItemWindow.Text = "&Window";
         // 
         // _menuItemWindowCascade
         // 
         this._menuItemWindowCascade.Index = 0;
         this._menuItemWindowCascade.RadioCheck = true;
         this._menuItemWindowCascade.Shortcut = System.Windows.Forms.Shortcut.ShiftF5;
         this._menuItemWindowCascade.Text = "&Cascade";
         this._menuItemWindowCascade.Click += new System.EventHandler(this._menuItemWindow_Click);
         // 
         // _menuItemWindowTileHorizontally
         // 
         this._menuItemWindowTileHorizontally.Index = 1;
         this._menuItemWindowTileHorizontally.RadioCheck = true;
         this._menuItemWindowTileHorizontally.Shortcut = System.Windows.Forms.Shortcut.ShiftF4;
         this._menuItemWindowTileHorizontally.Text = "Tile &Horizontally";
         this._menuItemWindowTileHorizontally.Click += new System.EventHandler(this._menuItemWindow_Click);
         // 
         // _menuItemWindowTileVertically
         // 
         this._menuItemWindowTileVertically.Index = 2;
         this._menuItemWindowTileVertically.RadioCheck = true;
         this._menuItemWindowTileVertically.Text = "Tile &Vertically";
         this._menuItemWindowTileVertically.Click += new System.EventHandler(this._menuItemWindow_Click);
         // 
         // _menuItemWindowArrangeIcons
         // 
         this._menuItemWindowArrangeIcons.Index = 3;
         this._menuItemWindowArrangeIcons.RadioCheck = true;
         this._menuItemWindowArrangeIcons.Text = "Arrange &Icons";
         this._menuItemWindowArrangeIcons.Click += new System.EventHandler(this._menuItemWindow_Click);
         // 
         // _menuItemWindowCloseAll
         // 
         this._menuItemWindowCloseAll.Index = 4;
         this._menuItemWindowCloseAll.RadioCheck = true;
         this._menuItemWindowCloseAll.Text = "Close &All";
         this._menuItemWindowCloseAll.Click += new System.EventHandler(this._menuItemWindow_Click);
         // 
         // _menuItemHelp
         // 
         this._menuItemHelp.Index = 4;
         this._menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemHelpAbout});
         this._menuItemHelp.Text = "&Help";
         // 
         // _menuItemHelpAbout
         // 
         this._menuItemHelpAbout.Index = 0;
         this._menuItemHelpAbout.RadioCheck = true;
         this._menuItemHelpAbout.Text = "&About...";
         this._menuItemHelpAbout.Click += new System.EventHandler(this._menuItemHelpAbout_Click);
         // 
         // _toolBarMain
         // 
         this._toolBarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
         this._toolBarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this._tbbOpen,
            this._tbbSave,
            this._tbbSep3,
            this._tbbZoomIn,
            this._tbbZoomOut,
            this._tbbNoZoom});
         this._toolBarMain.DropDownArrows = true;
         this._toolBarMain.Location = new System.Drawing.Point(0, 0);
         this._toolBarMain.Name = "_toolBarMain";
         this._toolBarMain.ShowToolTips = true;
         this._toolBarMain.Size = new System.Drawing.Size(768, 28);
         this._toolBarMain.TabIndex = 0;
         this._toolBarMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this._toolBarMain_ButtonClick);
         // 
         // _tbbOpen
         // 
         this._tbbOpen.ImageIndex = 0;
         this._tbbOpen.Name = "_tbbOpen";
         this._tbbOpen.ToolTipText = "Open File";
         // 
         // _tbbSave
         // 
         this._tbbSave.ImageIndex = 1;
         this._tbbSave.Name = "_tbbSave";
         this._tbbSave.ToolTipText = "Save Image";
         // 
         // _tbbSep3
         // 
         this._tbbSep3.Name = "_tbbSep3";
         this._tbbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // _tbbZoomIn
         // 
         this._tbbZoomIn.ImageIndex = 7;
         this._tbbZoomIn.Name = "_tbbZoomIn";
         this._tbbZoomIn.ToolTipText = "Zoom In";
         // 
         // _tbbZoomOut
         // 
         this._tbbZoomOut.ImageIndex = 8;
         this._tbbZoomOut.Name = "_tbbZoomOut";
         this._tbbZoomOut.ToolTipText = "Zoom Out";
         // 
         // _tbbNoZoom
         // 
         this._tbbNoZoom.ImageIndex = 9;
         this._tbbNoZoom.Name = "_tbbNoZoom";
         this._tbbNoZoom.ToolTipText = "No Zoom (100%)";
         // 
         // _sbMain
         // 
         this._sbMain.Location = new System.Drawing.Point(0, 593);
         this._sbMain.Name = "_sbMain";
         this._sbMain.Size = new System.Drawing.Size(768, 22);
         this._sbMain.TabIndex = 2;
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(768, 615);
         this.Controls.Add(this._sbMain);
         this.Controls.Add(this._toolBarMain);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.IsMdiContainer = true;
         this.Menu = this._mainMenu;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         StartupMessageBox startupMsgBox = new StartupMessageBox("CSAnnotationsBatesStampComposerDemo");
         if (startupMsgBox.ShowStartUpDialog)
            startupMsgBox.ShowDialog();

         if (!Support.SetLicense())
            return;

         if (RasterSupport.IsLocked(RasterSupportType.Document))
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Document.ToString()), "Warning");
            return;
         }

         Application.EnableVisualStyles();
         Application.DoEvents();

         Application.Run(new MainForm());
      }

      private RasterCodecs _codecs;
      private AnnCodecs _annCodecs;
      private PrintDocument _printDocument;
      private RasterPaintProperties _paintProperties;
      private AnnAutomationManager _automationManager;

      private static readonly float _minimumScaleFactor = 0.05f;
      private static readonly float _maximumScaleFactor = 11f;

      public AnnAutomationManager AutomationManager
      {
         get
         {
            return _automationManager;
         }
      }

      public AnnCodecs AnnCodecs
      {
         get
         {
            return _annCodecs;
         }
      }

      private void InitClass()
      {
         Messager.Caption = "LEADTOOLS C# BatesStamp Composer Demo";
         Text = Messager.Caption;

         _codecs = new RasterCodecs();
         _annCodecs = new AnnCodecs();
         AnnDeserializeOptions options = new AnnDeserializeOptions();

         _annCodecs.DeserializeOptions = options;

         _paintProperties = RasterPaintProperties.Default;
         _paintProperties.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray;

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

         InitToolbar();
         InitAutomation();

         LoadImage(true);

         UpdateControls();
      }

      private void InitToolbar()
      {
         Bitmap btmp = new Bitmap(GetType(), "Resources.MainToolbar.bmp");
         btmp.MakeTransparent(btmp.GetPixel(0, 0));

         _toolBarMain.ImageList = new ImageList();
         _toolBarMain.ImageList.ImageSize = new Size(btmp.Height, btmp.Height);
         _toolBarMain.ImageList.Images.AddStrip(btmp);
      }

      private void InitAutomation()
      {
         _automationManager = new AnnAutomationManager();
         _automationManager.CreateDefaultObjects();
         _managerHelper = new AutomationManagerHelper(_automationManager);
      }

      public void UpdateControls()
      {
         AnnotationsForm annForm = ActiveAnnotationsForm;

         if (annForm == null)
         {
            _menuItemFileSaveImage.Enabled = false;
            _menuItemFileSaveImage.Visible = false;
            _menuItemFileSaveImageAs.Enabled = false;
            _menuItemFileSaveImageAs.Visible = false;
            _menuItemFileSaveBatesStamp.Enabled = false;
            _menuItemFileSaveBatesStamp.Visible = false;
            _tbbSave.Enabled = false;
            _tbbSave.Visible = false;

            _menuItemFilePrint.Enabled = false;
            _menuItemFilePrint.Visible = false;
            _menuItemFilePrintPreview.Enabled = false;
            _menuItemFilePrintPreview.Visible = false;
            _menuItemFileSep2.Visible = false;

            _menuItemView.Enabled = false;
            _menuItemView.Visible = false;

            _menuItemWindow.Enabled = false;
            _menuItemWindow.Visible = false;

            _tbbSep3.Visible = false;
            _tbbZoomIn.Visible = false;
            _tbbZoomOut.Visible = false;
            _tbbNoZoom.Visible = false;

            _menuItemBatesStamp.Visible = false;
         }
         else
         {
            AnnAutomation automation = annForm.Automation;
            ImageViewer viewer = annForm.Viewer;

            bool designMode = _automationManager.UserMode == AnnUserMode.Design;

            _menuItemFileSaveImage.Enabled = true;
            _menuItemFileSaveImage.Visible = true;
            _menuItemFileSaveImageAs.Enabled = true;
            _menuItemFileSaveImageAs.Visible = true;

            if (_batesStampComposer != null && _batesStampComposer.Stamps.Count > 0)
               _menuItemFileSaveBatesStamp.Enabled = true;

            _menuItemFileSaveBatesStamp.Visible = true;
            _tbbSave.Enabled = true;
            _tbbSave.Visible = true;

            _menuItemFilePrint.Enabled = _printDocument != null;
            _menuItemFilePrint.Visible = _printDocument != null;
            _menuItemFilePrintPreview.Enabled = _printDocument != null && DialogUtilities.CanRunPrintPreview;
            _menuItemFilePrintPreview.Visible = _printDocument != null && DialogUtilities.CanRunPrintPreview;
            _menuItemFileSep2.Visible = _printDocument != null;

            _menuItemView.Enabled = true;
            _menuItemView.Visible = true;

            _menuItemViewSizeModeNormal.Checked = (viewer.SizeMode == ControlSizeMode.None);
            _menuItemViewSizeModeStretch.Checked = (viewer.SizeMode == ControlSizeMode.Stretch);
            _menuItemViewSizeModeFitAlways.Checked = (viewer.SizeMode == ControlSizeMode.FitAlways);
            _menuItemViewSizeModeFitWidth.Checked = (viewer.SizeMode == ControlSizeMode.FitWidth);
            _menuItemViewSizeModeFit.Checked = (viewer.SizeMode == ControlSizeMode.Fit);
            _menuItemViewZoom.Enabled = (viewer.SizeMode == ControlSizeMode.None);

            _menuItemViewUseDpi.Checked = viewer.UseDpi;

            _menuItemWindow.Enabled = true;
            _menuItemWindow.Visible = true;

            _tbbSep3.Visible = true;

            _tbbZoomIn.Visible = true;
            _tbbZoomOut.Visible = true;
            _tbbNoZoom.Visible = true;

            _tbbZoomIn.Enabled = _menuItemViewZoom.Enabled;
            _tbbZoomOut.Enabled = _menuItemViewZoom.Enabled;
            _tbbNoZoom.Enabled = _menuItemViewZoom.Enabled;

            _menuItemBatesStamp.Visible = true;
         }
      }

      private void CleanUp()
      {
         _managerHelper.Dispose();
      }

      private AnnotationsForm ActiveAnnotationsForm
      {
         get
         {
            return ActiveMdiChild as AnnotationsForm;
         }
      }

      private void MainForm_MdiChildActivate(object sender, System.EventArgs e)
      {
         if (ActiveMdiChild != null)
         {
            AnnotationsForm annForm = ActiveMdiChild as AnnotationsForm;
            AnnAutomation automation = annForm.Automation;
            if (!automation.Active)
               automation.Active = true;
         }

         UpdateControls();
      }

      private void _menuItemFileOpen_Click(object sender, System.EventArgs e)
      {
         LoadImage(false);
      }

      private void LoadImage(bool loadDefaultImage)
      {
         ImageFileLoader loader = new ImageFileLoader();
         bool bLoaded = false;

         loader.OpenDialogInitialPath = _openInitialPath;
         try
         {
            loader.LoadOnlyOnePage = true;

            if (loadDefaultImage)
            {
#if LT_CLICKONCE
               bLoaded = loader.Load(this, "clean.tif", _codecs, 1, 1);
#else
               bLoaded = loader.Load(this, DemosGlobal.ImagesFolder + @"\ocr1.tif", _codecs, 1, 1);
#endif // LT_CLICKONCE

            }
            else
               bLoaded = loader.Load(this, _codecs, true) > 0;

            if (bLoaded)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               loader.Image.ChangeViewPerspective(RasterViewPerspective.TopLeft);
               NewAnnotationForm(loader.Image, loader.FileName);
            }
         }
         catch (Exception ex)
         {
            if (ex is TargetInvocationException && ex.InnerException != null)
               Messager.ShowFileOpenError(this, loader.FileName, ex.InnerException);
            else
               Messager.ShowFileOpenError(this, loader.FileName, ex);
         }
      }

      private void NewAnnotationForm(RasterImage image, string fileName)
      {
         AnnotationsForm child = new AnnotationsForm();
         child.MdiParent = this;
         child.Initialize(_paintProperties, image, fileName);
         child.WindowState = FormWindowState.Maximized;

         AnnAutomation automation = child.Automation;
         AnnContainer mainContainer = automation.Container;

         _batesStampContainer.Size = mainContainer.Size;
         _batesStampContainer.Mapper = mainContainer.Mapper.Clone();

         //Clear old ones
         _batesStampComposer.TargetContainers.Clear();

         //Attach batesStampContainer to _batesStampComposer to start applying stamp to it
         _batesStampComposer.TargetContainers.Add(_batesStampContainer);

         //Insert bates stamp container below all containers , to draw annotations objects above bates stamp
         automation.Containers.Insert(0, _batesStampContainer);

         automation.Invalidate(LeadRectD.Empty);

         child.Show();
      }

      private void _menuItemFileSaveImage_Click(object sender, System.EventArgs e)
      {
         try
         {
            Save(true, ActiveAnnotationsForm.Viewer.Image.OriginalFormat);
         }
         catch (Exception ex)
         {
            if (ex is TargetInvocationException && ex.InnerException != null)
               Messager.ShowFileSaveError(this, ActiveAnnotationsForm.Text, ex.InnerException);
            else
               Messager.ShowFileSaveError(this, ActiveAnnotationsForm.Text, ex);
         }
      }

      private void _menuItemFileSaveImageAs_Click(object sender, EventArgs e)
      {
         ImageFileSaver saver = new ImageFileSaver();

         try
         {
            AnnotationsForm activeForm = ActiveAnnotationsForm;

            if (saver.Save(this, _codecs, activeForm.Viewer.Image))
            {
               activeForm.Text = saver.FileName;
               Save(false, saver.Format);
            }
         }
         catch (Exception ex)
         {
            if (ex is TargetInvocationException && ex.InnerException != null)
               Messager.ShowFileSaveError(this, saver.FileName, ex.InnerException);
            else
               Messager.ShowFileSaveError(this, saver.FileName, ex);
         }
      }

      private void _menuItemFileSaveBatesStamp_Click(object sender, System.EventArgs e)
      {
         try
         {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
               saveDialog.Filter = "Xml Files | *.xml";
               saveDialog.DefaultExt = "xml";
               saveDialog.Title = "Save Bates Stamp";

               if (saveDialog.ShowDialog() == DialogResult.OK)
               {
                  SaveBatesStamp(saveDialog.FileName, _batesStampComposer);
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }


      private void _menuItemFilePrint_Click(object sender, System.EventArgs e)
      {
         if (_printDocument != null)
         {
            try
            {
               RasterImage image = ActiveAnnotationsForm.Viewer.Image;
               _printDocument.PrinterSettings.MinimumPage = 1;
               _printDocument.PrinterSettings.MaximumPage = image.PageCount;
               _printDocument.PrinterSettings.FromPage = 1;
               _printDocument.PrinterSettings.ToPage = image.PageCount;

               _printDocument.Print();
            }
            catch { }
         }
      }

      private void _menuItemFilePrintPreview_Click(object sender, System.EventArgs e)
      {
         if (_printDocument != null)
         {
            try
            {
               using (PrintPreviewDialog dlg = new PrintPreviewDialog())
               {
                  RasterImage image = ActiveAnnotationsForm.Viewer.Image;
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

      private void _printDocument_BeginPrint(object sender, PrintEventArgs e)
      {
         // Our document has only 1 page so there is no need to reset the print page number
      }

      private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
      {
         AnnotationsForm form = ActiveAnnotationsForm;
         RasterImage image = form.Viewer.Image;
         Graphics g = e.Graphics;

         Rectangle pageBounds = e.PageBounds;
         LeadRect bounds = LeadRect.Create(pageBounds.X, pageBounds.Y, pageBounds.Width, pageBounds.Height);

         LeadRect destRect = RasterImage.CalculatePaintModeRectangle(
            image.ImageWidth,
            image.ImageHeight,
            bounds,
            RasterPaintSizeMode.Fit,
            RasterPaintAlignMode.Near,
            RasterPaintAlignMode.Near);

         AnnContainer container = _batesStampContainer;

         RasterImagePainter.Paint(image, g, destRect, RasterPaintProperties.Default);

         AnnContainerMapper mapper = container.Mapper;
         container.Mapper = new AnnContainerMapper(96, 96, 96, 96);

         AnnWinFormsRenderingEngine engine = new AnnWinFormsRenderingEngine(container, g);

         ImageViewer viewer = ActiveAnnotationsForm.Viewer;
         engine.BurnToRectWithDpi(container.Mapper.RectToContainerCoordinates(destRect.ToLeadRectD()), 96, 96, 96, 96);

         container.Mapper = mapper;

         // Inform the printer whether we have no more pages to print
         e.HasMorePages = false;
      }

      private void _printDocument_EndPrint(object sender, PrintEventArgs e)
      {
         // Nothing to do here
      }

      private void _menuItemFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void _toolBarMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
      {
         if (e.Button == _tbbOpen)
            _menuItemFileOpen.PerformClick();
         else if (e.Button == _tbbSave)
            _menuItemFileSaveImage.PerformClick();
         else if (e.Button == _tbbZoomIn)
            _menuItemViewZoomIn.PerformClick();
         else if (e.Button == _tbbZoomOut)
            _menuItemViewZoomOut.PerformClick();
         else if (e.Button == _tbbNoZoom)
            _menuItemViewZoomNormal.PerformClick();
      }

      private void _menuItemViewSizeMode_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;

         activeForm.Viewer.BeginUpdate();

         ImageViewer viewer = activeForm.Viewer;
         LeadPoint defaultZoomOrigin = viewer.DefaultZoomOrigin;
         if (sender == _menuItemViewSizeModeNormal)
            viewer.Zoom(ControlSizeMode.ActualSize, 1, defaultZoomOrigin);
         else if (sender == _menuItemViewSizeModeFitAlways)
            viewer.Zoom(ControlSizeMode.FitAlways, 1, defaultZoomOrigin);
         else if (sender == _menuItemViewSizeModeFitWidth)
            viewer.Zoom(ControlSizeMode.FitWidth, 1, defaultZoomOrigin);
         else if (sender == _menuItemViewSizeModeStretch)
            viewer.Zoom(ControlSizeMode.Stretch, 1, defaultZoomOrigin);
         else if (sender == _menuItemViewSizeModeFit)
            viewer.Zoom(ControlSizeMode.Fit, 1, defaultZoomOrigin);

         activeForm.Viewer.EndUpdate();

         UpdateControls();
      }

      public void Zoom(bool zoomIn)
      {
         if (zoomIn)
            _menuItemViewZoomIn.PerformClick();
         else
            _menuItemViewZoomOut.PerformClick();
      }

      private void _menuItemViewZoom_Click(object sender, System.EventArgs e)
      {
         // get the current center in logical units
         ImageViewer viewer = ActiveAnnotationsForm.Viewer; // get the active viewer
         LeadPoint defaultZoomOrigin = viewer.DefaultZoomOrigin;

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
            viewer.Zoom(ControlSizeMode.None, 1, defaultZoomOrigin);
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
            viewer.Zoom(ControlSizeMode.None, scaleFactor, defaultZoomOrigin);
         }
      }

      private void _menuItemViewPaintProperties_Click(object sender, System.EventArgs e)
      {
         PaintPropertiesDialog dlg = new PaintPropertiesDialog();
         dlg.PaintProperties = _paintProperties;
         dlg.Apply += new EventHandler(PaintPropertiesDialog_Apply);
         dlg.ShowDialog(this);
      }

      private void PaintPropertiesDialog_Apply(object sender, EventArgs e)
      {
         PaintPropertiesDialog dlg = sender as PaintPropertiesDialog;
         _paintProperties = dlg.PaintProperties;
         foreach (AnnotationsForm i in MdiChildren)
            i.UpdatePaintProperties(_paintProperties);
      }

      private void _menuItemBatesStampProperties_Click(object sender, EventArgs e)
      {
         try
         {
            AnnotationsForm activeAutomationForm = ActiveAnnotationsForm;
            //Remove the old attached containers
            _batesStampComposer.TargetContainers.Clear();
            BatesStampDialog batesStampDialog = new BatesStampDialog(activeAutomationForm.Viewer.Image, _batesStampComposer);
            batesStampDialog.ShowDialog();

            //Attach new container to let and to apply bates stamp to it
            _batesStampComposer.TargetContainers.Add(_batesStampContainer);
            activeAutomationForm.Automation.Invalidate(LeadRectD.Empty);
            UpdateControls();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _menuItemAnnotationsBurnBatesStamp_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;
         if (activeForm == null)
            return;

         RasterImage rasterImage = activeForm.Viewer.Image;

         try
         {
            AnnWinFormsRenderingEngine renderingEngine = new AnnWinFormsRenderingEngine();
            renderingEngine.Renderers = _managerHelper.AutomationManager.RenderingEngine.Renderers;
            renderingEngine.Resources = _automationManager.Resources;

            ImageViewerAutoResetOptions autoResetOptions = activeForm.Viewer.AutoResetOptions;
            activeForm.Viewer.AutoResetOptions = ImageViewerAutoResetOptions.None;
            activeForm.Viewer.Image = renderingEngine.RenderOnImage(_batesStampContainer, rasterImage);
            activeForm.Viewer.AutoResetOptions = autoResetOptions;
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


      private void _menuItemWindow_Click(object sender, System.EventArgs e)
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
            int i;
            for (i = MdiChildren.Length - 1; i >= 0; i--)
               MdiChildren[i].Close();

            UpdateControls();
         }
      }

      private void _menuItemHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("BatesStampComposer", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      public void SetStatusBarText(string text)
      {
         _sbMain.Text = text;
      }

      public void Save(bool saveImage, RasterImageFormat format)
      {
         AnnotationsForm form = ActiveAnnotationsForm;
         AnnAutomation automation = form.Automation;
         RasterImage image = form.Viewer.Image;

         if (saveImage)
         {
            try
            {
               _codecs.Save(image, form.Text, image.OriginalFormat, image.BitsPerPixel);
            }
            catch (RasterException ex)
            {
               if (ex.Code == RasterExceptionCode.BitsPerPixel)
               {
                  _codecs.Save(image, form.Text, image.OriginalFormat, 0);
               }
            }

            format = image.OriginalFormat;
         }
      }

      private void SaveBatesStamp(string fileName, AnnBatesStampComposer composer)
      {
         try
         {
            AnnBatesStampComposer.Save(fileName, composer);
         }
         catch (Exception ex)
         {
            if (ex is TargetInvocationException && ex.InnerException != null)
               Messager.ShowError(this, ex.InnerException);
            else
               Messager.ShowError(this, ex);
         }
      }

      private void _menuItemViewUseDpi_Click(object sender, EventArgs e)
      {
         _menuItemViewUseDpi.Checked = !_menuItemViewUseDpi.Checked;
         ActiveAnnotationsForm.Viewer.UseDpi = _menuItemViewUseDpi.Checked;
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         _managerHelper.Dispose();
         _batesStampComposer.Dispose();
         _batesStampComposer = null;
      }
   }
}
