// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Text;
using System.IO;
using System.Reflection;

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Drawing;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.BatesStamp;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Designers;
using Leadtools.Annotations.Rendering;
using System.Diagnostics;
using Leadtools.Annotations.WinForms;
using Leadtools.Controls;

namespace AnnotationsDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   ///
   enum AudioState
   {
      Playing,
      Stopped,
      Failed,
      Finished,
   }
   public class MainForm : System.Windows.Forms.Form
   {
      private Random _randomNumber = new Random();
      private AutomationManagerHelper _managerHelper = null;
      private List<string> _loadedPackages = new List<string>();
      private bool _showLoadPackageInfoDialog = true;
      private bool _showLoadBatesStampInfoDialog = true;

      public AutomationManagerHelper ManagerHelper
      {
         get { return _managerHelper; }
      }

      private MainMenu _mainMenu;
      private MenuItem _menuItemFile;
      private MenuItem _menuItemFileOpen;
      private MenuItem _menuItemFileSep1;
      private MenuItem _menuItemFileExit;
      private MenuItem _menuItemFilePrint;
      private MenuItem _menuItemFilePrintPreview;
      private MenuItem _menuItemFileSep2;
      private MenuItem _menuItemFileSep3;
      private MenuItem _menuItemHelp;
      private MenuItem _menuItemHelpAbout;
      private MenuItem _menuItemEdit;
      private MenuItem _menuItemEditCut;
      private MenuItem _menuItemEditCopy;
      private MenuItem _menuItemEditPaste;
      private MenuItem _menuItemEditDelete;
      private MenuItem _menuItemEditSelectAll;
      private MenuItem _menuItemEditSelectNone;
      private MenuItem _menuItemWindow;
      private MenuItem _menuItemWindowCascade;
      private MenuItem _menuItemWindowTileHorizontally;
      private MenuItem _menuItemWindowTileVertically;
      private MenuItem _menuItemWindowArrangeIcons;
      private MenuItem _menuItemWindowCloseAll;
      private MenuItem _menuItemView;
      private MenuItem _menuItemViewSizeMode;
      private MenuItem _menuItemViewSizeModeNormal;
      private MenuItem _menuItemViewSizeModeStretch;
      private MenuItem _menuItemViewSizeModeFitAlways;
      private MenuItem _menuItemViewSizeModeFitWidth;
      private MenuItem _menuItemViewZoom;
      private MenuItem _menuItemViewZoomIn;
      private MenuItem _menuItemViewZoomOut;
      private MenuItem _menuItemViewZoomSep1;
      private MenuItem _menuItemViewZoomNormal;
      private MenuItem _menuItemViewPaintProperties;
      private MenuItem _menuItemViewSep1;
      private MenuItem _menuItemAnnotations;
      private MenuItem _menuItemAnnotationsUserMode;
      private MenuItem _menuItemAnnotationsSep1;
      private MenuItem _menuItemAnnotationsCurrentObject;
      private MenuItem _menuItemAnnotationsSep2;
      private MenuItem _menuItemAnnotationsAlign;
      private MenuItem _menuItemAnnotationsAlignBringToFront;
      private MenuItem _menuItemAnnotationsAlignSendToBack;
      private MenuItem _menuItemAnnotationsAlignBringToFirst;
      private MenuItem _menuItemAnnotationsAlignSendToLast;
      private MenuItem _menuItemAnnotationsAlignSep1;
      private MenuItem _menuItemAnnotationsAlignObjectsAlignmentLefts;
      private MenuItem _menuItemAnnotationsAlignObjectsAlignmentCenters;
      private MenuItem _menuItemAnnotationsAlignObjectsAlignmentRights;
      private MenuItem _menuItemAnnotationsAlignSep2;
      private MenuItem _menuItemAnnotationsAlignObjectsAlignmentTops;
      private MenuItem _menuItemAnnotationsAlignObjectsAlignmenMiddles;
      private MenuItem _menuItemAnnotationsAlignObjectsAlignmenBottoms;
      private MenuItem _menuItemAnnotationsAlignSep3;
      private MenuItem _menuItemAnnotationsAlignObjectsMakeSameWidth;
      private MenuItem _menuItemAnnotationsAlignObjectsMakeSameHeight;
      private MenuItem _menuItemAnnotationsAlignObjectsMakeSameSize;
      private MenuItem _menuItemAnnotationsGroup;
      private MenuItem _menuItemAnnotationsGroupGroupSelectedObjects;
      private MenuItem _menuItemAnnotationsGroupUngroup;
      private MenuItem _menuItemAnnotationsSep3;
      private MenuItem _menuItemAnnotationsProperties;
      private ToolBar _toolBarMain;
      private ToolBarButton _tbbSave;
      private ToolBarButton _tbbCopy;
      private ToolBarButton _tbbPaste;
      private ToolBarButton _tbbDelete;
      private ToolBarButton _tbbSep1;
      private ToolBarButton _tbbRotate;
      private ToolBarButton _tbbGroup;
      private ToolBarButton _tbbProperties;
      private ToolBarButton _tbbBringToFront;
      private ToolBarButton _tbbSendToBack;
      private ToolBarButton _tbbBringToFirst;
      private ToolBarButton _tbbSendToLast;
      private ToolBarButton _tbbAlignLefts;
      private ToolBarButton _tbbAlignCenters;
      private ToolBarButton _tbbAlignRights;
      private ToolBarButton _tbbAlignTops;
      private ToolBarButton _tbbAlignMiddles;
      private ToolBarButton _tbbAlignBottoms;
      private ToolBarButton _tbbMakeSameWidth;
      private ToolBarButton _tbbMakeSameHeight;
      private ToolBarButton _tbbMakeSameSize;
      private ToolBarButton _tbbSep7;
      private ToolBarButton _tbbUngroup;
      private ToolBarButton _tbbOpen;
      private MenuItem _menuItemAnnotationsUserModeRun;
      private MenuItem _menuItemAnnotationsUserModeDesign;
      private ToolBarButton _tbbRunDesign;
      private MenuItem _menuItemFileSaveAsTiff;
      private MenuItem _menuItemFileSaveAs;
      private MenuItem _menuItemFileSaveAnnotations;
      private ToolBarButton _tbbSep2;
      private ToolBarButton _tbbZoomIn;
      private ToolBarButton _tbbZoomOut;
      private ToolBarButton _tbbNoZoom;
      private MenuItem _menuItemEditSep2;
      private MenuItem _menuItemEditUndo;
      private MenuItem _menuItemEditRedo;
      private MenuItem _menuItemEditSep1;
      private StatusBar _sbMain;
      private ToolBarButton _tbbSep4;
      private ToolBarButton _tbbSep5;
      private ToolBarButton _tbbSep6;
      private ToolBarButton _tbbSep3;
      private ToolBarButton _tbbUndo;
      private ToolBarButton _tbbRedo;
      private MenuItem _menuItemAnnotationsPassword;
      private MenuItem _menuItemAnnotationsPasswordLock;
      private MenuItem _menuItemAnnotationsPasswordUnlock;
      private MenuItem _menuItemAnnotationsFlip;
      private MenuItem _menuItemAnnotationsFlipHorizontal;
      private MenuItem _menuItemAnnotationsFlipVertical;
      private MenuItem _menuItemAnnotationsAntiAlias;
      private MenuItem _menuItemAnnotationsEncryptObjects;
      private MenuItem _menuItemAnnotationsEncryptObjectsApplyAllEncryptors;
      private MenuItem _menuItemAnnotationsEncryptObjectsApplyAllDecryptors;
      private MenuItem _menuItemAnnotationsEncryptObjectsApplyEncryptor;
      private MenuItem _menuItemAnnotationsEncryptObjectsApplyDecryptor;
      private MenuItem _menuItemAnnotationsEncryptObjectsSep1;
      private MenuItem _menuItemViewZoomValue;
      private MenuItem _menuItemAnnotationsRedactionObjects;
      private MenuItem _menuItemAnnotationsRedactionObjectsRealize;
      private MenuItem _menuItemAnnotationsRedactionObjectsRestore;
      private MenuItem _menuItemAnnotationsRedactionObjectsSep1;
      private MenuItem _menuItemAnnotationsRedactionObjectsRealizeAll;
      private MenuItem _menuItemAnnotationsRedactionObjectsRestoreAll;
      private MenuItem _menuItemAnnotationsRealize;
      private MenuItem _menuItemViewSizeModeFit;
      private MenuItem _menuItemViewSep2;
      private MenuItem _menuItemViewFlip;
      private MenuItem _menuItemViewFlipHorizontal;
      private MenuItem _menuItemViewFlipVertical;
      private MenuItem _menuItemViewRotate;
      private MenuItem _menuItemViewRotate90;
      private MenuItem _menuItemViewRotate180;
      private MenuItem _menuItemViewRotate270;
      private MenuItem _menuItemAnnotationsSep4;
      private MenuItem _menuItemAnnotationsBehavior;
      private MenuItem _menuItemAnnotationsBehaviorUseRotateThumbs;
      private MenuItem _menuItemAnnotationsBehaviorMaintainAspectRatio;
      private MenuItem _menuItemAnnotationsResetRotatePoints;
      private MenuItem _menuItemAnnotationsBehaviorEnableToolTip;
      private MenuItem _menuItemViewInteractiveMode;
      private MenuItem _menuItemViewInteractiveModeNone;
      private MenuItem _menuItemViewInteractiveModeMagnifyGlass;
      private MenuItem _menuItemViewInteractiveModePan;
      private MenuItem _menuItemViewUseDpi;
      private MenuItem _menuItemLoadAnnPackage;
      private MenuItem _menuItemFileLoadBateStamp;
      private MenuItem _menuItemAnnotationsBehaviorEnableAutoIncrement;
      private MenuItem _menuItemAnnotationsBehaviorRestrictDesigners;
      private MenuItem _menuItemAnnotationsBehaviorEnableObjectsAlignment;
      private MenuItem _menuItemCalibrate;
      private MenuItem _menuItemEditDuplicate;
      private MenuItem _menuItemViewRotateNone;
      private MenuItem _menuItemAnnotationsSnapToGridProperties;
      private MenuItem _menuItemFileSaveAsWang;
      private MenuItem _menuItemAnnotationsBehaviorFreehandSelection;
      private MenuItem _menuItemAnnotationsBehaviorFontRelativeToDPI;
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
         this._menuItemFileSaveAnnotations = new System.Windows.Forms.MenuItem();
         this._menuItemFileSaveAs = new System.Windows.Forms.MenuItem();
         this._menuItemFileSaveAsTiff = new System.Windows.Forms.MenuItem();
         this._menuItemFileSaveAsWang = new System.Windows.Forms.MenuItem();
         this._menuItemFileSep1 = new System.Windows.Forms.MenuItem();
         this._menuItemFilePrint = new System.Windows.Forms.MenuItem();
         this._menuItemFilePrintPreview = new System.Windows.Forms.MenuItem();
         this._menuItemFileSep2 = new System.Windows.Forms.MenuItem();
         this._menuItemLoadAnnPackage = new System.Windows.Forms.MenuItem();
         this._menuItemFileLoadBateStamp = new System.Windows.Forms.MenuItem();
         this._menuItemFileSep3 = new System.Windows.Forms.MenuItem();
         this._menuItemFileExit = new System.Windows.Forms.MenuItem();
         this._menuItemEdit = new System.Windows.Forms.MenuItem();
         this._menuItemEditUndo = new System.Windows.Forms.MenuItem();
         this._menuItemEditRedo = new System.Windows.Forms.MenuItem();
         this._menuItemEditSep1 = new System.Windows.Forms.MenuItem();
         this._menuItemEditCut = new System.Windows.Forms.MenuItem();
         this._menuItemEditCopy = new System.Windows.Forms.MenuItem();
         this._menuItemEditPaste = new System.Windows.Forms.MenuItem();
         this._menuItemEditDelete = new System.Windows.Forms.MenuItem();
         this._menuItemEditSep2 = new System.Windows.Forms.MenuItem();
         this._menuItemEditSelectAll = new System.Windows.Forms.MenuItem();
         this._menuItemEditSelectNone = new System.Windows.Forms.MenuItem();
         this._menuItemEditDuplicate = new System.Windows.Forms.MenuItem();
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
         this._menuItemViewInteractiveMode = new System.Windows.Forms.MenuItem();
         this._menuItemViewInteractiveModeNone = new System.Windows.Forms.MenuItem();
         this._menuItemViewInteractiveModeMagnifyGlass = new System.Windows.Forms.MenuItem();
         this._menuItemViewInteractiveModePan = new System.Windows.Forms.MenuItem();
         this._menuItemViewSep1 = new System.Windows.Forms.MenuItem();
         this._menuItemViewPaintProperties = new System.Windows.Forms.MenuItem();
         this._menuItemViewUseDpi = new System.Windows.Forms.MenuItem();
         this._menuItemViewSep2 = new System.Windows.Forms.MenuItem();
         this._menuItemViewFlip = new System.Windows.Forms.MenuItem();
         this._menuItemViewFlipHorizontal = new System.Windows.Forms.MenuItem();
         this._menuItemViewFlipVertical = new System.Windows.Forms.MenuItem();
         this._menuItemViewRotate = new System.Windows.Forms.MenuItem();
         this._menuItemViewRotate90 = new System.Windows.Forms.MenuItem();
         this._menuItemViewRotate180 = new System.Windows.Forms.MenuItem();
         this._menuItemViewRotate270 = new System.Windows.Forms.MenuItem();
         this._menuItemViewRotateNone = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotations = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsUserMode = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsUserModeRun = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsUserModeDesign = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsSep1 = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsCurrentObject = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsSep2 = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsRedactionObjects = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsRedactionObjectsRealize = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsRedactionObjectsRestore = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsRedactionObjectsSep1 = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsRedactionObjectsRealizeAll = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsRedactionObjectsRestoreAll = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsEncryptObjects = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsEncryptObjectsApplyEncryptor = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsEncryptObjectsApplyDecryptor = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsEncryptObjectsSep1 = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsEncryptObjectsApplyAllEncryptors = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsEncryptObjectsApplyAllDecryptors = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsRealize = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsSep3 = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlign = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignBringToFront = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignSendToBack = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignBringToFirst = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignSendToLast = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignSep1 = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignObjectsAlignmentLefts = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignObjectsAlignmentCenters = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignObjectsAlignmentRights = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignSep2 = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignObjectsAlignmentTops = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignObjectsAlignmenMiddles = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignObjectsAlignmenBottoms = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignSep3 = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignObjectsMakeSameWidth = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignObjectsMakeSameHeight = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAlignObjectsMakeSameSize = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsFlip = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsFlipHorizontal = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsFlipVertical = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsGroup = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsGroupGroupSelectedObjects = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsGroupUngroup = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsPassword = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsPasswordLock = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsPasswordUnlock = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsResetRotatePoints = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsAntiAlias = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsSnapToGridProperties = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsProperties = new System.Windows.Forms.MenuItem();
         this._menuItemCalibrate = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsSep4 = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsBehavior = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsBehaviorUseRotateThumbs = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsBehaviorMaintainAspectRatio = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsBehaviorEnableToolTip = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsBehaviorEnableAutoIncrement = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsBehaviorRestrictDesigners = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsBehaviorEnableObjectsAlignment = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsBehaviorFreehandSelection = new System.Windows.Forms.MenuItem();
         this._menuItemAnnotationsBehaviorFontRelativeToDPI = new System.Windows.Forms.MenuItem();
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
         this._tbbSep1 = new System.Windows.Forms.ToolBarButton();
         this._tbbCopy = new System.Windows.Forms.ToolBarButton();
         this._tbbPaste = new System.Windows.Forms.ToolBarButton();
         this._tbbDelete = new System.Windows.Forms.ToolBarButton();
         this._tbbSep2 = new System.Windows.Forms.ToolBarButton();
         this._tbbUndo = new System.Windows.Forms.ToolBarButton();
         this._tbbRedo = new System.Windows.Forms.ToolBarButton();
         this._tbbSep3 = new System.Windows.Forms.ToolBarButton();
         this._tbbZoomIn = new System.Windows.Forms.ToolBarButton();
         this._tbbZoomOut = new System.Windows.Forms.ToolBarButton();
         this._tbbNoZoom = new System.Windows.Forms.ToolBarButton();
         this._tbbSep4 = new System.Windows.Forms.ToolBarButton();
         this._tbbGroup = new System.Windows.Forms.ToolBarButton();
         this._tbbUngroup = new System.Windows.Forms.ToolBarButton();
         this._tbbProperties = new System.Windows.Forms.ToolBarButton();
         this._tbbSep5 = new System.Windows.Forms.ToolBarButton();
         this._tbbBringToFront = new System.Windows.Forms.ToolBarButton();
         this._tbbSendToBack = new System.Windows.Forms.ToolBarButton();
         this._tbbBringToFirst = new System.Windows.Forms.ToolBarButton();
         this._tbbSendToLast = new System.Windows.Forms.ToolBarButton();
         this._tbbSep6 = new System.Windows.Forms.ToolBarButton();
         this._tbbAlignLefts = new System.Windows.Forms.ToolBarButton();
         this._tbbAlignCenters = new System.Windows.Forms.ToolBarButton();
         this._tbbAlignRights = new System.Windows.Forms.ToolBarButton();
         this._tbbAlignTops = new System.Windows.Forms.ToolBarButton();
         this._tbbAlignMiddles = new System.Windows.Forms.ToolBarButton();
         this._tbbAlignBottoms = new System.Windows.Forms.ToolBarButton();
         this._tbbMakeSameWidth = new System.Windows.Forms.ToolBarButton();
         this._tbbMakeSameHeight = new System.Windows.Forms.ToolBarButton();
         this._tbbMakeSameSize = new System.Windows.Forms.ToolBarButton();
         this._tbbSep7 = new System.Windows.Forms.ToolBarButton();
         this._tbbRunDesign = new System.Windows.Forms.ToolBarButton();
         this._tbbRotate = new System.Windows.Forms.ToolBarButton();
         this._sbMain = new System.Windows.Forms.StatusBar();
         this.SuspendLayout();
         // 
         // _mainMenu
         // 
         this._mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFile,
            this._menuItemEdit,
            this._menuItemView,
            this._menuItemAnnotations,
            this._menuItemWindow,
            this._menuItemHelp});
         // 
         // _menuItemFile
         // 
         this._menuItemFile.Index = 0;
         this._menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFileOpen,
            this._menuItemFileSaveAnnotations,
            this._menuItemFileSaveAs,
            this._menuItemFileSaveAsTiff,
            this._menuItemFileSaveAsWang,
            this._menuItemFileSep1,
            this._menuItemFilePrint,
            this._menuItemFilePrintPreview,
            this._menuItemFileSep2,
            this._menuItemLoadAnnPackage,
            this._menuItemFileLoadBateStamp,
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
         // _menuItemFileSaveAnnotations
         // 
         this._menuItemFileSaveAnnotations.Index = 1;
         this._menuItemFileSaveAnnotations.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this._menuItemFileSaveAnnotations.Text = "&Save Annotations";
         this._menuItemFileSaveAnnotations.Click += new System.EventHandler(this._menuItemFileSave_Click);
         // 
         // _menuItemFileSaveAs
         // 
         this._menuItemFileSaveAs.Index = 2;
         this._menuItemFileSaveAs.RadioCheck = true;
         this._menuItemFileSaveAs.Text = "Save &As...";
         this._menuItemFileSaveAs.Click += new System.EventHandler(this._menuItemFileSaveAs_Click);
         // 
         // _menuItemFileSaveAsTiff
         // 
         this._menuItemFileSaveAsTiff.Index = 3;
         this._menuItemFileSaveAsTiff.RadioCheck = true;
         this._menuItemFileSaveAsTiff.Text = "Save As &Tiff Tag...";
         this._menuItemFileSaveAsTiff.Click += new System.EventHandler(this.SaveAsTag_Click);
         // 
         // _menuItemFileSaveAsWang
         // 
         this._menuItemFileSaveAsWang.Index = 4;
         this._menuItemFileSaveAsWang.Text = "Save As &Wang Tag...";
         this._menuItemFileSaveAsWang.Click += new System.EventHandler(this.SaveAsTag_Click);
         // 
         // _menuItemFileSep1
         // 
         this._menuItemFileSep1.Index = 5;
         this._menuItemFileSep1.RadioCheck = true;
         this._menuItemFileSep1.Text = "-";
         // 
         // _menuItemFilePrint
         // 
         this._menuItemFilePrint.Index = 6;
         this._menuItemFilePrint.RadioCheck = true;
         this._menuItemFilePrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
         this._menuItemFilePrint.Text = "&Print...";
         this._menuItemFilePrint.Click += new System.EventHandler(this._menuItemFilePrint_Click);
         // 
         // _menuItemFilePrintPreview
         // 
         this._menuItemFilePrintPreview.Index = 7;
         this._menuItemFilePrintPreview.RadioCheck = true;
         this._menuItemFilePrintPreview.Text = "Print Pre&view...";
         this._menuItemFilePrintPreview.Click += new System.EventHandler(this._menuItemFilePrintPreview_Click);
         // 
         // _menuItemFileSep2
         // 
         this._menuItemFileSep2.Index = 8;
         this._menuItemFileSep2.RadioCheck = true;
         this._menuItemFileSep2.Text = "-";
         // 
         // _menuItemLoadAnnPackage
         // 
         this._menuItemLoadAnnPackage.Index = 9;
         this._menuItemLoadAnnPackage.Text = "Loa&d Package...";
         this._menuItemLoadAnnPackage.Click += new System.EventHandler(this._menuItemLoadAnnPackage_Click);
         // 
         // _menuItemFileLoadBateStamp
         // 
         this._menuItemFileLoadBateStamp.Index = 10;
         this._menuItemFileLoadBateStamp.Text = "Load &Bates Stamp...";
         this._menuItemFileLoadBateStamp.Click += new System.EventHandler(this._menuItemFileLoadBateStamp_Click);
         // 
         // _menuItemFileSep3
         // 
         this._menuItemFileSep3.Index = 11;
         this._menuItemFileSep3.RadioCheck = true;
         this._menuItemFileSep3.Text = "-";
         // 
         // _menuItemFileExit
         // 
         this._menuItemFileExit.Index = 12;
         this._menuItemFileExit.RadioCheck = true;
         this._menuItemFileExit.Text = "E&xit";
         this._menuItemFileExit.Click += new System.EventHandler(this._menuItemFileExit_Click);
         // 
         // _menuItemEdit
         // 
         this._menuItemEdit.Index = 1;
         this._menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemEditUndo,
            this._menuItemEditRedo,
            this._menuItemEditSep1,
            this._menuItemEditCut,
            this._menuItemEditCopy,
            this._menuItemEditPaste,
            this._menuItemEditDelete,
            this._menuItemEditSep2,
            this._menuItemEditSelectAll,
            this._menuItemEditSelectNone,
            this._menuItemEditDuplicate});
         this._menuItemEdit.Text = "&Edit";
         this._menuItemEdit.Popup += new System.EventHandler(this._menuItemEdit_Popup);
         // 
         // _menuItemEditUndo
         // 
         this._menuItemEditUndo.Index = 0;
         this._menuItemEditUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
         this._menuItemEditUndo.Text = "&Undo";
         this._menuItemEditUndo.Click += new System.EventHandler(this._menuItemEditUndoRedo_Click);
         // 
         // _menuItemEditRedo
         // 
         this._menuItemEditRedo.Index = 1;
         this._menuItemEditRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
         this._menuItemEditRedo.Text = "&Redo";
         this._menuItemEditRedo.Click += new System.EventHandler(this._menuItemEditUndoRedo_Click);
         // 
         // _menuItemEditSep1
         // 
         this._menuItemEditSep1.Index = 2;
         this._menuItemEditSep1.Text = "-";
         // 
         // _menuItemEditCut
         // 
         this._menuItemEditCut.Index = 3;
         this._menuItemEditCut.RadioCheck = true;
         this._menuItemEditCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
         this._menuItemEditCut.Text = "Cu&t";
         this._menuItemEditCut.Click += new System.EventHandler(this._menuItemEditClipboard_Click);
         // 
         // _menuItemEditCopy
         // 
         this._menuItemEditCopy.Index = 4;
         this._menuItemEditCopy.RadioCheck = true;
         this._menuItemEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
         this._menuItemEditCopy.Text = "&Copy";
         this._menuItemEditCopy.Click += new System.EventHandler(this._menuItemEditClipboard_Click);
         // 
         // _menuItemEditPaste
         // 
         this._menuItemEditPaste.Index = 5;
         this._menuItemEditPaste.RadioCheck = true;
         this._menuItemEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
         this._menuItemEditPaste.Text = "&Paste";
         this._menuItemEditPaste.Click += new System.EventHandler(this._menuItemEditClipboard_Click);
         // 
         // _menuItemEditDelete
         // 
         this._menuItemEditDelete.Index = 6;
         this._menuItemEditDelete.RadioCheck = true;
         this._menuItemEditDelete.Shortcut = System.Windows.Forms.Shortcut.Del;
         this._menuItemEditDelete.Text = "&Delete";
         this._menuItemEditDelete.Click += new System.EventHandler(this._menuItemEditClipboard_Click);
         // 
         // _menuItemEditSep2
         // 
         this._menuItemEditSep2.Index = 7;
         this._menuItemEditSep2.RadioCheck = true;
         this._menuItemEditSep2.Text = "-";
         // 
         // _menuItemEditSelectAll
         // 
         this._menuItemEditSelectAll.Index = 8;
         this._menuItemEditSelectAll.RadioCheck = true;
         this._menuItemEditSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
         this._menuItemEditSelectAll.Text = "Select &All";
         this._menuItemEditSelectAll.Click += new System.EventHandler(this._menuItemEditSelect_Click);
         // 
         // _menuItemEditSelectNone
         // 
         this._menuItemEditSelectNone.Index = 9;
         this._menuItemEditSelectNone.RadioCheck = true;
         this._menuItemEditSelectNone.Text = "Select &None";
         this._menuItemEditSelectNone.Click += new System.EventHandler(this._menuItemEditSelect_Click);
         // 
         // _menuItemEditDuplicate
         // 
         this._menuItemEditDuplicate.Index = 10;
         this._menuItemEditDuplicate.Text = "Dup&licate";
         this._menuItemEditDuplicate.Click += new System.EventHandler(this._menuItemEditDuplicate_Click);
         // 
         // _menuItemView
         // 
         this._menuItemView.Index = 2;
         this._menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemViewSizeMode,
            this._menuItemViewZoom,
            this._menuItemViewInteractiveMode,
            this._menuItemViewSep1,
            this._menuItemViewPaintProperties,
            this._menuItemViewUseDpi,
            this._menuItemViewSep2,
            this._menuItemViewFlip,
            this._menuItemViewRotate});
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
         // _menuItemViewInteractiveMode
         // 
         this._menuItemViewInteractiveMode.Index = 2;
         this._menuItemViewInteractiveMode.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemViewInteractiveModeNone,
            this._menuItemViewInteractiveModeMagnifyGlass,
            this._menuItemViewInteractiveModePan});
         this._menuItemViewInteractiveMode.Text = "&Interactive Mode";
         // 
         // _menuItemViewInteractiveModeNone
         // 
         this._menuItemViewInteractiveModeNone.Index = 0;
         this._menuItemViewInteractiveModeNone.Text = "&Annotations";
         this._menuItemViewInteractiveModeNone.Click += new System.EventHandler(this._menuItemViewInteractiveMode_Click);
         // 
         // _menuItemViewInteractiveModeMagnifyGlass
         // 
         this._menuItemViewInteractiveModeMagnifyGlass.Index = 1;
         this._menuItemViewInteractiveModeMagnifyGlass.Text = "&Magnify Glass";
         this._menuItemViewInteractiveModeMagnifyGlass.Click += new System.EventHandler(this._menuItemViewInteractiveMode_Click);
         // 
         // _menuItemViewInteractiveModePan
         // 
         this._menuItemViewInteractiveModePan.Index = 2;
         this._menuItemViewInteractiveModePan.Text = "&Pan";
         this._menuItemViewInteractiveModePan.Click += new System.EventHandler(this._menuItemViewInteractiveMode_Click);
         // 
         // _menuItemViewSep1
         // 
         this._menuItemViewSep1.Index = 3;
         this._menuItemViewSep1.RadioCheck = true;
         this._menuItemViewSep1.Text = "-";
         // 
         // _menuItemViewPaintProperties
         // 
         this._menuItemViewPaintProperties.Index = 4;
         this._menuItemViewPaintProperties.RadioCheck = true;
         this._menuItemViewPaintProperties.Text = "&Paint Properties...";
         this._menuItemViewPaintProperties.Click += new System.EventHandler(this._menuItemViewPaintProperties_Click);
         // 
         // _menuItemViewUseDpi
         // 
         this._menuItemViewUseDpi.Index = 5;
         this._menuItemViewUseDpi.Text = "&Use Dpi";
         this._menuItemViewUseDpi.Click += new System.EventHandler(this._menuItemViewUseDpi_Click);
         // 
         // _menuItemViewSep2
         // 
         this._menuItemViewSep2.Index = 6;
         this._menuItemViewSep2.Text = "-";
         // 
         // _menuItemViewFlip
         // 
         this._menuItemViewFlip.Index = 7;
         this._menuItemViewFlip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemViewFlipHorizontal,
            this._menuItemViewFlipVertical});
         this._menuItemViewFlip.RadioCheck = true;
         this._menuItemViewFlip.Text = "&Flip";
         // 
         // _menuItemViewFlipHorizontal
         // 
         this._menuItemViewFlipHorizontal.Index = 0;
         this._menuItemViewFlipHorizontal.RadioCheck = true;
         this._menuItemViewFlipHorizontal.Text = "&Horizontal";
         this._menuItemViewFlipHorizontal.Click += new System.EventHandler(this._menuItemViewFlip_Click);
         // 
         // _menuItemViewFlipVertical
         // 
         this._menuItemViewFlipVertical.Index = 1;
         this._menuItemViewFlipVertical.RadioCheck = true;
         this._menuItemViewFlipVertical.Text = "&Vertical";
         this._menuItemViewFlipVertical.Click += new System.EventHandler(this._menuItemViewFlip_Click);
         // 
         // _menuItemViewRotate
         // 
         this._menuItemViewRotate.Index = 8;
         this._menuItemViewRotate.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemViewRotate90,
            this._menuItemViewRotate180,
            this._menuItemViewRotate270,
            this._menuItemViewRotateNone});
         this._menuItemViewRotate.RadioCheck = true;
         this._menuItemViewRotate.Text = "&Rotate";
         // 
         // _menuItemViewRotate90
         // 
         this._menuItemViewRotate90.Index = 0;
         this._menuItemViewRotate90.RadioCheck = true;
         this._menuItemViewRotate90.Text = "9&0° clockwise";
         this._menuItemViewRotate90.Click += new System.EventHandler(this._menuItemViewRotate_Click);
         // 
         // _menuItemViewRotate180
         // 
         this._menuItemViewRotate180.Index = 1;
         this._menuItemViewRotate180.RadioCheck = true;
         this._menuItemViewRotate180.Text = "1&80° clockwise";
         this._menuItemViewRotate180.Click += new System.EventHandler(this._menuItemViewRotate_Click);
         // 
         // _menuItemViewRotate270
         // 
         this._menuItemViewRotate270.Index = 2;
         this._menuItemViewRotate270.RadioCheck = true;
         this._menuItemViewRotate270.Text = "2&70° clockwise";
         this._menuItemViewRotate270.Click += new System.EventHandler(this._menuItemViewRotate_Click);
         // 
         // _menuItemViewRotateNone
         // 
         this._menuItemViewRotateNone.Index = 3;
         this._menuItemViewRotateNone.Text = "N&one";
         this._menuItemViewRotateNone.Click += new System.EventHandler(this._menuItemViewRotate_Click);
         // 
         // _menuItemAnnotations
         // 
         this._menuItemAnnotations.Index = 3;
         this._menuItemAnnotations.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemAnnotationsUserMode,
            this._menuItemAnnotationsSep1,
            this._menuItemAnnotationsCurrentObject,
            this._menuItemAnnotationsSep2,
            this._menuItemAnnotationsRedactionObjects,
            this._menuItemAnnotationsEncryptObjects,
            this._menuItemAnnotationsRealize,
            this._menuItemAnnotationsSep3,
            this._menuItemAnnotationsAlign,
            this._menuItemAnnotationsFlip,
            this._menuItemAnnotationsGroup,
            this._menuItemAnnotationsPassword,
            this._menuItemAnnotationsResetRotatePoints,
            this._menuItemAnnotationsAntiAlias,
            this._menuItemAnnotationsSnapToGridProperties,
            this._menuItemAnnotationsProperties,
            this._menuItemCalibrate,
            this._menuItemAnnotationsSep4,
            this._menuItemAnnotationsBehavior});
         this._menuItemAnnotations.Text = "&Annotations";
         // 
         // _menuItemAnnotationsUserMode
         // 
         this._menuItemAnnotationsUserMode.Index = 0;
         this._menuItemAnnotationsUserMode.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemAnnotationsUserModeRun,
            this._menuItemAnnotationsUserModeDesign});
         this._menuItemAnnotationsUserMode.RadioCheck = true;
         this._menuItemAnnotationsUserMode.Text = "&User Mode";
         // 
         // _menuItemAnnotationsUserModeRun
         // 
         this._menuItemAnnotationsUserModeRun.Index = 0;
         this._menuItemAnnotationsUserModeRun.RadioCheck = true;
         this._menuItemAnnotationsUserModeRun.Text = "&Run";
         this._menuItemAnnotationsUserModeRun.Click += new System.EventHandler(this._menuItemAnnotationsUserMode_Click);
         // 
         // _menuItemAnnotationsUserModeDesign
         // 
         this._menuItemAnnotationsUserModeDesign.Index = 1;
         this._menuItemAnnotationsUserModeDesign.RadioCheck = true;
         this._menuItemAnnotationsUserModeDesign.Text = "&Design";
         this._menuItemAnnotationsUserModeDesign.Click += new System.EventHandler(this._menuItemAnnotationsUserMode_Click);
         // 
         // _menuItemAnnotationsSep1
         // 
         this._menuItemAnnotationsSep1.Index = 1;
         this._menuItemAnnotationsSep1.RadioCheck = true;
         this._menuItemAnnotationsSep1.Text = "-";
         // 
         // _menuItemAnnotationsCurrentObject
         // 
         this._menuItemAnnotationsCurrentObject.Index = 2;
         this._menuItemAnnotationsCurrentObject.RadioCheck = true;
         this._menuItemAnnotationsCurrentObject.Text = "&Current Object...";
         this._menuItemAnnotationsCurrentObject.Click += new System.EventHandler(this._menuItemAnnotationsCurrentObject_Click);
         // 
         // _menuItemAnnotationsSep2
         // 
         this._menuItemAnnotationsSep2.Index = 3;
         this._menuItemAnnotationsSep2.RadioCheck = true;
         this._menuItemAnnotationsSep2.Text = "-";
         // 
         // _menuItemAnnotationsRedactionObjects
         // 
         this._menuItemAnnotationsRedactionObjects.Index = 4;
         this._menuItemAnnotationsRedactionObjects.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemAnnotationsRedactionObjectsRealize,
            this._menuItemAnnotationsRedactionObjectsRestore,
            this._menuItemAnnotationsRedactionObjectsSep1,
            this._menuItemAnnotationsRedactionObjectsRealizeAll,
            this._menuItemAnnotationsRedactionObjectsRestoreAll});
         this._menuItemAnnotationsRedactionObjects.RadioCheck = true;
         this._menuItemAnnotationsRedactionObjects.Text = "&Redaction Objects";
         // 
         // _menuItemAnnotationsRedactionObjectsRealize
         // 
         this._menuItemAnnotationsRedactionObjectsRealize.Index = 0;
         this._menuItemAnnotationsRedactionObjectsRealize.RadioCheck = true;
         this._menuItemAnnotationsRedactionObjectsRealize.Text = "&Realize";
         this._menuItemAnnotationsRedactionObjectsRealize.Click += new System.EventHandler(this._menuItemAnnotationsRedactionObjects_Click);
         // 
         // _menuItemAnnotationsRedactionObjectsRestore
         // 
         this._menuItemAnnotationsRedactionObjectsRestore.Index = 1;
         this._menuItemAnnotationsRedactionObjectsRestore.RadioCheck = true;
         this._menuItemAnnotationsRedactionObjectsRestore.Text = "R&estore";
         this._menuItemAnnotationsRedactionObjectsRestore.Click += new System.EventHandler(this._menuItemAnnotationsRedactionObjects_Click);
         // 
         // _menuItemAnnotationsRedactionObjectsSep1
         // 
         this._menuItemAnnotationsRedactionObjectsSep1.Index = 2;
         this._menuItemAnnotationsRedactionObjectsSep1.RadioCheck = true;
         this._menuItemAnnotationsRedactionObjectsSep1.Text = "-";
         // 
         // _menuItemAnnotationsRedactionObjectsRealizeAll
         // 
         this._menuItemAnnotationsRedactionObjectsRealizeAll.Index = 3;
         this._menuItemAnnotationsRedactionObjectsRealizeAll.RadioCheck = true;
         this._menuItemAnnotationsRedactionObjectsRealizeAll.Text = "Realize &All";
         this._menuItemAnnotationsRedactionObjectsRealizeAll.Click += new System.EventHandler(this._menuItemAnnotationsRedactionObjectsAll_Click);
         // 
         // _menuItemAnnotationsRedactionObjectsRestoreAll
         // 
         this._menuItemAnnotationsRedactionObjectsRestoreAll.Index = 4;
         this._menuItemAnnotationsRedactionObjectsRestoreAll.RadioCheck = true;
         this._menuItemAnnotationsRedactionObjectsRestoreAll.Text = "Re&store All";
         this._menuItemAnnotationsRedactionObjectsRestoreAll.Click += new System.EventHandler(this._menuItemAnnotationsRedactionObjectsAll_Click);
         // 
         // _menuItemAnnotationsEncryptObjects
         // 
         this._menuItemAnnotationsEncryptObjects.Index = 5;
         this._menuItemAnnotationsEncryptObjects.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemAnnotationsEncryptObjectsApplyEncryptor,
            this._menuItemAnnotationsEncryptObjectsApplyDecryptor,
            this._menuItemAnnotationsEncryptObjectsSep1,
            this._menuItemAnnotationsEncryptObjectsApplyAllEncryptors,
            this._menuItemAnnotationsEncryptObjectsApplyAllDecryptors});
         this._menuItemAnnotationsEncryptObjects.RadioCheck = true;
         this._menuItemAnnotationsEncryptObjects.Text = "&Encrypt Objects";
         // 
         // _menuItemAnnotationsEncryptObjectsApplyEncryptor
         // 
         this._menuItemAnnotationsEncryptObjectsApplyEncryptor.Index = 0;
         this._menuItemAnnotationsEncryptObjectsApplyEncryptor.Text = "Apply &Encryptor";
         this._menuItemAnnotationsEncryptObjectsApplyEncryptor.Click += new System.EventHandler(this._menuItemAnnotationsEncryptObjects_Click);
         // 
         // _menuItemAnnotationsEncryptObjectsApplyDecryptor
         // 
         this._menuItemAnnotationsEncryptObjectsApplyDecryptor.Index = 1;
         this._menuItemAnnotationsEncryptObjectsApplyDecryptor.Text = "Apply &Decryptor";
         this._menuItemAnnotationsEncryptObjectsApplyDecryptor.Click += new System.EventHandler(this._menuItemAnnotationsEncryptObjects_Click);
         // 
         // _menuItemAnnotationsEncryptObjectsSep1
         // 
         this._menuItemAnnotationsEncryptObjectsSep1.Index = 2;
         this._menuItemAnnotationsEncryptObjectsSep1.Text = "-";
         // 
         // _menuItemAnnotationsEncryptObjectsApplyAllEncryptors
         // 
         this._menuItemAnnotationsEncryptObjectsApplyAllEncryptors.Index = 3;
         this._menuItemAnnotationsEncryptObjectsApplyAllEncryptors.RadioCheck = true;
         this._menuItemAnnotationsEncryptObjectsApplyAllEncryptors.Text = "&Apply All Encryptors";
         this._menuItemAnnotationsEncryptObjectsApplyAllEncryptors.Click += new System.EventHandler(this._menuItemAnnotationsEncryptObjectsAll_Click);
         // 
         // _menuItemAnnotationsEncryptObjectsApplyAllDecryptors
         // 
         this._menuItemAnnotationsEncryptObjectsApplyAllDecryptors.Index = 4;
         this._menuItemAnnotationsEncryptObjectsApplyAllDecryptors.RadioCheck = true;
         this._menuItemAnnotationsEncryptObjectsApplyAllDecryptors.Text = "A&pply All Decryptors";
         this._menuItemAnnotationsEncryptObjectsApplyAllDecryptors.Click += new System.EventHandler(this._menuItemAnnotationsEncryptObjectsAll_Click);
         // 
         // _menuItemAnnotationsRealize
         // 
         this._menuItemAnnotationsRealize.Index = 6;
         this._menuItemAnnotationsRealize.Text = "Reali&ze";
         this._menuItemAnnotationsRealize.Click += new System.EventHandler(this._menuItemAnnotationsRealize_Click);
         // 
         // _menuItemAnnotationsSep3
         // 
         this._menuItemAnnotationsSep3.Index = 7;
         this._menuItemAnnotationsSep3.RadioCheck = true;
         this._menuItemAnnotationsSep3.Text = "-";
         // 
         // _menuItemAnnotationsAlign
         // 
         this._menuItemAnnotationsAlign.Index = 8;
         this._menuItemAnnotationsAlign.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemAnnotationsAlignBringToFront,
            this._menuItemAnnotationsAlignSendToBack,
            this._menuItemAnnotationsAlignBringToFirst,
            this._menuItemAnnotationsAlignSendToLast,
            this._menuItemAnnotationsAlignSep1,
            this._menuItemAnnotationsAlignObjectsAlignmentLefts,
            this._menuItemAnnotationsAlignObjectsAlignmentCenters,
            this._menuItemAnnotationsAlignObjectsAlignmentRights,
            this._menuItemAnnotationsAlignSep2,
            this._menuItemAnnotationsAlignObjectsAlignmentTops,
            this._menuItemAnnotationsAlignObjectsAlignmenMiddles,
            this._menuItemAnnotationsAlignObjectsAlignmenBottoms,
            this._menuItemAnnotationsAlignSep3,
            this._menuItemAnnotationsAlignObjectsMakeSameWidth,
            this._menuItemAnnotationsAlignObjectsMakeSameHeight,
            this._menuItemAnnotationsAlignObjectsMakeSameSize});
         this._menuItemAnnotationsAlign.RadioCheck = true;
         this._menuItemAnnotationsAlign.Text = "A&lign";
         // 
         // _menuItemAnnotationsAlignBringToFront
         // 
         this._menuItemAnnotationsAlignBringToFront.Index = 0;
         this._menuItemAnnotationsAlignBringToFront.RadioCheck = true;
         this._menuItemAnnotationsAlignBringToFront.Text = "&Bring To Front";
         this._menuItemAnnotationsAlignBringToFront.Click += new System.EventHandler(this._menuItemAnnotationsAlign_Click);
         // 
         // _menuItemAnnotationsAlignSendToBack
         // 
         this._menuItemAnnotationsAlignSendToBack.Index = 1;
         this._menuItemAnnotationsAlignSendToBack.RadioCheck = true;
         this._menuItemAnnotationsAlignSendToBack.Text = "&Send To Back";
         this._menuItemAnnotationsAlignSendToBack.Click += new System.EventHandler(this._menuItemAnnotationsAlign_Click);
         // 
         // _menuItemAnnotationsAlignBringToFirst
         // 
         this._menuItemAnnotationsAlignBringToFirst.Index = 2;
         this._menuItemAnnotationsAlignBringToFirst.RadioCheck = true;
         this._menuItemAnnotationsAlignBringToFirst.Text = "Bring To &First";
         this._menuItemAnnotationsAlignBringToFirst.Click += new System.EventHandler(this._menuItemAnnotationsAlign_Click);
         // 
         // _menuItemAnnotationsAlignSendToLast
         // 
         this._menuItemAnnotationsAlignSendToLast.Index = 3;
         this._menuItemAnnotationsAlignSendToLast.RadioCheck = true;
         this._menuItemAnnotationsAlignSendToLast.Text = "Send To &Last";
         this._menuItemAnnotationsAlignSendToLast.Click += new System.EventHandler(this._menuItemAnnotationsAlign_Click);
         // 
         // _menuItemAnnotationsAlignSep1
         // 
         this._menuItemAnnotationsAlignSep1.Index = 4;
         this._menuItemAnnotationsAlignSep1.RadioCheck = true;
         this._menuItemAnnotationsAlignSep1.Text = "-";
         // 
         // _menuItemAnnotationsAlignObjectsAlignmentLefts
         // 
         this._menuItemAnnotationsAlignObjectsAlignmentLefts.Index = 5;
         this._menuItemAnnotationsAlignObjectsAlignmentLefts.RadioCheck = true;
         this._menuItemAnnotationsAlignObjectsAlignmentLefts.Text = "Align To Left";
         this._menuItemAnnotationsAlignObjectsAlignmentLefts.Click += new System.EventHandler(this._menuItemAnnotationsAlign_Click);
         // 
         // _menuItemAnnotationsAlignObjectsAlignmentCenters
         // 
         this._menuItemAnnotationsAlignObjectsAlignmentCenters.Index = 6;
         this._menuItemAnnotationsAlignObjectsAlignmentCenters.RadioCheck = true;
         this._menuItemAnnotationsAlignObjectsAlignmentCenters.Text = "Align To Center";
         this._menuItemAnnotationsAlignObjectsAlignmentCenters.Click += new System.EventHandler(this._menuItemAnnotationsAlign_Click);
         // 
         // _menuItemAnnotationsAlignObjectsAlignmentRights
         // 
         this._menuItemAnnotationsAlignObjectsAlignmentRights.Index = 7;
         this._menuItemAnnotationsAlignObjectsAlignmentRights.RadioCheck = true;
         this._menuItemAnnotationsAlignObjectsAlignmentRights.Text = "Align To Right";
         this._menuItemAnnotationsAlignObjectsAlignmentRights.Click += new System.EventHandler(this._menuItemAnnotationsAlign_Click);
         // 
         // _menuItemAnnotationsAlignSep2
         // 
         this._menuItemAnnotationsAlignSep2.Index = 8;
         this._menuItemAnnotationsAlignSep2.RadioCheck = true;
         this._menuItemAnnotationsAlignSep2.Text = "-";
         // 
         // _menuItemAnnotationsAlignObjectsAlignmentTops
         // 
         this._menuItemAnnotationsAlignObjectsAlignmentTops.Index = 9;
         this._menuItemAnnotationsAlignObjectsAlignmentTops.RadioCheck = true;
         this._menuItemAnnotationsAlignObjectsAlignmentTops.Text = "Align To Top";
         this._menuItemAnnotationsAlignObjectsAlignmentTops.Click += new System.EventHandler(this._menuItemAnnotationsAlign_Click);
         // 
         // _menuItemAnnotationsAlignObjectsAlignmenMiddles
         // 
         this._menuItemAnnotationsAlignObjectsAlignmenMiddles.Index = 10;
         this._menuItemAnnotationsAlignObjectsAlignmenMiddles.RadioCheck = true;
         this._menuItemAnnotationsAlignObjectsAlignmenMiddles.Text = "Align To Middle";
         this._menuItemAnnotationsAlignObjectsAlignmenMiddles.Click += new System.EventHandler(this._menuItemAnnotationsAlign_Click);
         // 
         // _menuItemAnnotationsAlignObjectsAlignmenBottoms
         // 
         this._menuItemAnnotationsAlignObjectsAlignmenBottoms.Index = 11;
         this._menuItemAnnotationsAlignObjectsAlignmenBottoms.RadioCheck = true;
         this._menuItemAnnotationsAlignObjectsAlignmenBottoms.Text = "Align To Bottom";
         this._menuItemAnnotationsAlignObjectsAlignmenBottoms.Click += new System.EventHandler(this._menuItemAnnotationsAlign_Click);
         // 
         // _menuItemAnnotationsAlignSep3
         // 
         this._menuItemAnnotationsAlignSep3.Index = 12;
         this._menuItemAnnotationsAlignSep3.RadioCheck = true;
         this._menuItemAnnotationsAlignSep3.Text = "-";
         // 
         // _menuItemAnnotationsAlignObjectsMakeSameWidth
         // 
         this._menuItemAnnotationsAlignObjectsMakeSameWidth.Index = 13;
         this._menuItemAnnotationsAlignObjectsMakeSameWidth.RadioCheck = true;
         this._menuItemAnnotationsAlignObjectsMakeSameWidth.Text = "Make Same Width";
         this._menuItemAnnotationsAlignObjectsMakeSameWidth.Click += new System.EventHandler(this._menuItemAnnotationsAlign_Click);
         // 
         // _menuItemAnnotationsAlignObjectsMakeSameHeight
         // 
         this._menuItemAnnotationsAlignObjectsMakeSameHeight.Index = 14;
         this._menuItemAnnotationsAlignObjectsMakeSameHeight.RadioCheck = true;
         this._menuItemAnnotationsAlignObjectsMakeSameHeight.Text = "Make Same Height";
         this._menuItemAnnotationsAlignObjectsMakeSameHeight.Click += new System.EventHandler(this._menuItemAnnotationsAlign_Click);
         // 
         // _menuItemAnnotationsAlignObjectsMakeSameSize
         // 
         this._menuItemAnnotationsAlignObjectsMakeSameSize.Index = 15;
         this._menuItemAnnotationsAlignObjectsMakeSameSize.RadioCheck = true;
         this._menuItemAnnotationsAlignObjectsMakeSameSize.Text = "Make Same Size";
         this._menuItemAnnotationsAlignObjectsMakeSameSize.Click += new System.EventHandler(this._menuItemAnnotationsAlign_Click);
         // 
         // _menuItemAnnotationsFlip
         // 
         this._menuItemAnnotationsFlip.Index = 9;
         this._menuItemAnnotationsFlip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemAnnotationsFlipHorizontal,
            this._menuItemAnnotationsFlipVertical});
         this._menuItemAnnotationsFlip.RadioCheck = true;
         this._menuItemAnnotationsFlip.Text = "&Flip";
         // 
         // _menuItemAnnotationsFlipHorizontal
         // 
         this._menuItemAnnotationsFlipHorizontal.Index = 0;
         this._menuItemAnnotationsFlipHorizontal.RadioCheck = true;
         this._menuItemAnnotationsFlipHorizontal.Text = "&Horizontal";
         this._menuItemAnnotationsFlipHorizontal.Click += new System.EventHandler(this._menuItemAnnotationsFlip_Click);
         // 
         // _menuItemAnnotationsFlipVertical
         // 
         this._menuItemAnnotationsFlipVertical.Index = 1;
         this._menuItemAnnotationsFlipVertical.RadioCheck = true;
         this._menuItemAnnotationsFlipVertical.Text = "&Vertical";
         this._menuItemAnnotationsFlipVertical.Click += new System.EventHandler(this._menuItemAnnotationsFlip_Click);
         // 
         // _menuItemAnnotationsGroup
         // 
         this._menuItemAnnotationsGroup.Index = 10;
         this._menuItemAnnotationsGroup.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemAnnotationsGroupGroupSelectedObjects,
            this._menuItemAnnotationsGroupUngroup});
         this._menuItemAnnotationsGroup.RadioCheck = true;
         this._menuItemAnnotationsGroup.Text = "&Group";
         // 
         // _menuItemAnnotationsGroupGroupSelectedObjects
         // 
         this._menuItemAnnotationsGroupGroupSelectedObjects.Index = 0;
         this._menuItemAnnotationsGroupGroupSelectedObjects.RadioCheck = true;
         this._menuItemAnnotationsGroupGroupSelectedObjects.Text = "&Group Selected Objects";
         this._menuItemAnnotationsGroupGroupSelectedObjects.Click += new System.EventHandler(this._menuItemAnnotationsGroupGroupSelectedObjects_Click);
         // 
         // _menuItemAnnotationsGroupUngroup
         // 
         this._menuItemAnnotationsGroupUngroup.Index = 1;
         this._menuItemAnnotationsGroupUngroup.RadioCheck = true;
         this._menuItemAnnotationsGroupUngroup.Text = "&Ungroup";
         this._menuItemAnnotationsGroupUngroup.Click += new System.EventHandler(this._menuItemAnnotationsGroupUngroup_Click);
         // 
         // _menuItemAnnotationsPassword
         // 
         this._menuItemAnnotationsPassword.Index = 11;
         this._menuItemAnnotationsPassword.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemAnnotationsPasswordLock,
            this._menuItemAnnotationsPasswordUnlock});
         this._menuItemAnnotationsPassword.RadioCheck = true;
         this._menuItemAnnotationsPassword.Text = "Pass&word";
         // 
         // _menuItemAnnotationsPasswordLock
         // 
         this._menuItemAnnotationsPasswordLock.Index = 0;
         this._menuItemAnnotationsPasswordLock.RadioCheck = true;
         this._menuItemAnnotationsPasswordLock.Text = "&Lock...";
         this._menuItemAnnotationsPasswordLock.Click += new System.EventHandler(this._menuItemAnnotationsPassword_Click);
         // 
         // _menuItemAnnotationsPasswordUnlock
         // 
         this._menuItemAnnotationsPasswordUnlock.Index = 1;
         this._menuItemAnnotationsPasswordUnlock.RadioCheck = true;
         this._menuItemAnnotationsPasswordUnlock.Text = "&Unlock...";
         this._menuItemAnnotationsPasswordUnlock.Click += new System.EventHandler(this._menuItemAnnotationsPassword_Click);
         // 
         // _menuItemAnnotationsResetRotatePoints
         // 
         this._menuItemAnnotationsResetRotatePoints.Index = 12;
         this._menuItemAnnotationsResetRotatePoints.RadioCheck = true;
         this._menuItemAnnotationsResetRotatePoints.Text = "Re&set Rotate Points";
         this._menuItemAnnotationsResetRotatePoints.Click += new System.EventHandler(this._menuItemAnnotationsResetRotatePoints_Click);
         // 
         // _menuItemAnnotationsAntiAlias
         // 
         this._menuItemAnnotationsAntiAlias.Index = 13;
         this._menuItemAnnotationsAntiAlias.RadioCheck = true;
         this._menuItemAnnotationsAntiAlias.Text = "&Anti Alias";
         this._menuItemAnnotationsAntiAlias.Click += new System.EventHandler(this._menuItemAnnotationsAntiAlias_Click);
         // 
         // _menuItemAnnotationsSnapToGridProperties
         // 
         this._menuItemAnnotationsSnapToGridProperties.Index = 14;
         this._menuItemAnnotationsSnapToGridProperties.Text = "S&nap To Grid Properties";
         this._menuItemAnnotationsSnapToGridProperties.Click += new System.EventHandler(this._menuItemAnnotationsSnapToGridProperties_Click);
         // 
         // _menuItemAnnotationsProperties
         // 
         this._menuItemAnnotationsProperties.Index = 15;
         this._menuItemAnnotationsProperties.RadioCheck = true;
         this._menuItemAnnotationsProperties.Text = "&Properties...";
         this._menuItemAnnotationsProperties.Click += new System.EventHandler(this._menuItemAnnotationsProperties_Click);
         // 
         // _menuItemCalibrate
         // 
         this._menuItemCalibrate.Index = 16;
         this._menuItemCalibrate.Text = "Cal&ibrate...";
         this._menuItemCalibrate.Click += new System.EventHandler(this._menuItemCalibrate_Click);
         // 
         // _menuItemAnnotationsSep4
         // 
         this._menuItemAnnotationsSep4.Index = 17;
         this._menuItemAnnotationsSep4.Text = "-";
         // 
         // _menuItemAnnotationsBehavior
         // 
         this._menuItemAnnotationsBehavior.Index = 18;
         this._menuItemAnnotationsBehavior.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemAnnotationsBehaviorUseRotateThumbs,
            this._menuItemAnnotationsBehaviorMaintainAspectRatio,
            this._menuItemAnnotationsBehaviorEnableToolTip,
            this._menuItemAnnotationsBehaviorEnableAutoIncrement,
            this._menuItemAnnotationsBehaviorRestrictDesigners,
            this._menuItemAnnotationsBehaviorEnableObjectsAlignment,
            this._menuItemAnnotationsBehaviorFreehandSelection,
            this._menuItemAnnotationsBehaviorFontRelativeToDPI});
         this._menuItemAnnotationsBehavior.Text = "&Behavior";
         // 
         // _menuItemAnnotationsBehaviorUseRotateThumbs
         // 
         this._menuItemAnnotationsBehaviorUseRotateThumbs.Index = 0;
         this._menuItemAnnotationsBehaviorUseRotateThumbs.RadioCheck = true;
         this._menuItemAnnotationsBehaviorUseRotateThumbs.Text = "Use &Rotate Control Points";
         this._menuItemAnnotationsBehaviorUseRotateThumbs.Click += new System.EventHandler(this._menuItemAnnotationsBehaviorUseRotateThumbs_Click);
         // 
         // _menuItemAnnotationsBehaviorMaintainAspectRatio
         // 
         this._menuItemAnnotationsBehaviorMaintainAspectRatio.Index = 1;
         this._menuItemAnnotationsBehaviorMaintainAspectRatio.RadioCheck = true;
         this._menuItemAnnotationsBehaviorMaintainAspectRatio.Text = "&Maintain Aspect Ratio";
         this._menuItemAnnotationsBehaviorMaintainAspectRatio.Visible = false;
         this._menuItemAnnotationsBehaviorMaintainAspectRatio.Click += new System.EventHandler(this._menuItemAnnotationsBehaviorMaintainAspectRatio_Click);
         // 
         // _menuItemAnnotationsBehaviorEnableToolTip
         // 
         this._menuItemAnnotationsBehaviorEnableToolTip.Index = 2;
         this._menuItemAnnotationsBehaviorEnableToolTip.RadioCheck = true;
         this._menuItemAnnotationsBehaviorEnableToolTip.Text = "Enable &ToolTip";
         this._menuItemAnnotationsBehaviorEnableToolTip.Click += new System.EventHandler(this._menuItemAnnotationsBehaviorEnableToolTip_Click);
         // 
         // _menuItemAnnotationsBehaviorEnableAutoIncrement
         // 
         this._menuItemAnnotationsBehaviorEnableAutoIncrement.Index = 3;
         this._menuItemAnnotationsBehaviorEnableAutoIncrement.Text = "Enable A&uto Increment Label";
         this._menuItemAnnotationsBehaviorEnableAutoIncrement.Click += new System.EventHandler(this._menuItemAnnotationsBehaviorEnableAutoIncrement_Click);
         // 
         // _menuItemAnnotationsBehaviorRestrictDesigners
         // 
         this._menuItemAnnotationsBehaviorRestrictDesigners.Index = 4;
         this._menuItemAnnotationsBehaviorRestrictDesigners.Text = "&Restrict Designers";
         this._menuItemAnnotationsBehaviorRestrictDesigners.Click += new System.EventHandler(this._menuItemAnnotationsBehaviorRestrictDesigners_Click);
         // 
         // _menuItemAnnotationsBehaviorEnableObjectsAlignment
         // 
         this._menuItemAnnotationsBehaviorEnableObjectsAlignment.Index = 5;
         this._menuItemAnnotationsBehaviorEnableObjectsAlignment.Text = "Enable Objects &Alignment";
         this._menuItemAnnotationsBehaviorEnableObjectsAlignment.Click += new System.EventHandler(this._menuItemAnnotationsBehaviorEnableObjectsAlignment_Click);
         // 
         // _menuItemAnnotationsBehaviorFreehandSelection
         // 
         this._menuItemAnnotationsBehaviorFreehandSelection.Index = 6;
         this._menuItemAnnotationsBehaviorFreehandSelection.Text = "&Use Freehand Selection";
         this._menuItemAnnotationsBehaviorFreehandSelection.Click += new System.EventHandler(this._menuItemAnnotationsBehaviorFreehandSelection_Click);
         // 
         // _menuItemAnnotationsBehaviorFontRelativeToDPI
         // 
         this._menuItemAnnotationsBehaviorFontRelativeToDPI.Index = 7;
         this._menuItemAnnotationsBehaviorFontRelativeToDPI.Text = "&Font Relative To Image DPI";
         this._menuItemAnnotationsBehaviorFontRelativeToDPI.Click += new System.EventHandler(this._menuItemAnnotationsBehaviorFontRelativeToDPI_Click);
         // 
         // _menuItemWindow
         // 
         this._menuItemWindow.Index = 4;
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
         this._menuItemHelp.Index = 5;
         this._menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemHelpAbout});
         this._menuItemHelp.Text = "&Help";
         // 
         // _menuItemHelpAbout
         // 
         this._menuItemHelpAbout.Index = 0;
         this._menuItemHelpAbout.RadioCheck = true;
         this._menuItemHelpAbout.Shortcut = System.Windows.Forms.Shortcut.F1;
         this._menuItemHelpAbout.Text = "&About...";
         this._menuItemHelpAbout.Click += new System.EventHandler(this._menuItemHelpAbout_Click);
         // 
         // _toolBarMain
         // 
         this._toolBarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
         this._toolBarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this._tbbOpen,
            this._tbbSave,
            this._tbbSep1,
            this._tbbCopy,
            this._tbbPaste,
            this._tbbDelete,
            this._tbbSep2,
            this._tbbUndo,
            this._tbbRedo,
            this._tbbSep3,
            this._tbbZoomIn,
            this._tbbZoomOut,
            this._tbbNoZoom,
            this._tbbSep4,
            this._tbbGroup,
            this._tbbUngroup,
            this._tbbProperties,
            this._tbbSep5,
            this._tbbBringToFront,
            this._tbbSendToBack,
            this._tbbBringToFirst,
            this._tbbSendToLast,
            this._tbbSep6,
            this._tbbAlignLefts,
            this._tbbAlignCenters,
            this._tbbAlignRights,
            this._tbbAlignTops,
            this._tbbAlignMiddles,
            this._tbbAlignBottoms,
            this._tbbMakeSameWidth,
            this._tbbMakeSameHeight,
            this._tbbMakeSameSize,
            this._tbbSep7,
            this._tbbRunDesign});
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
         this._tbbSave.ToolTipText = "Save File";
         // 
         // _tbbSep1
         // 
         this._tbbSep1.Name = "_tbbSep1";
         this._tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // _tbbCopy
         // 
         this._tbbCopy.ImageIndex = 2;
         this._tbbCopy.Name = "_tbbCopy";
         this._tbbCopy.ToolTipText = "Save Selected Annotations to Clipboard";
         // 
         // _tbbPaste
         // 
         this._tbbPaste.ImageIndex = 3;
         this._tbbPaste.Name = "_tbbPaste";
         this._tbbPaste.ToolTipText = "Paste Annotations from Clipboard";
         // 
         // _tbbDelete
         // 
         this._tbbDelete.ImageIndex = 4;
         this._tbbDelete.Name = "_tbbDelete";
         this._tbbDelete.ToolTipText = "Delete Selected Annotations";
         // 
         // _tbbSep2
         // 
         this._tbbSep2.Name = "_tbbSep2";
         this._tbbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // _tbbUndo
         // 
         this._tbbUndo.ImageIndex = 5;
         this._tbbUndo.Name = "_tbbUndo";
         this._tbbUndo.ToolTipText = "Undo";
         // 
         // _tbbRedo
         // 
         this._tbbRedo.ImageIndex = 6;
         this._tbbRedo.Name = "_tbbRedo";
         this._tbbRedo.ToolTipText = "Redo";
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
         // _tbbSep4
         // 
         this._tbbSep4.Name = "_tbbSep4";
         this._tbbSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // _tbbGroup
         // 
         this._tbbGroup.ImageIndex = 11;
         this._tbbGroup.Name = "_tbbGroup";
         this._tbbGroup.ToolTipText = "Group Selected Objects";
         // 
         // _tbbUngroup
         // 
         this._tbbUngroup.ImageIndex = 12;
         this._tbbUngroup.Name = "_tbbUngroup";
         this._tbbUngroup.ToolTipText = "Ungroup Selected Group";
         // 
         // _tbbProperties
         // 
         this._tbbProperties.ImageIndex = 13;
         this._tbbProperties.Name = "_tbbProperties";
         this._tbbProperties.ToolTipText = "Properties";
         // 
         // _tbbSep5
         // 
         this._tbbSep5.Name = "_tbbSep5";
         this._tbbSep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // _tbbBringToFront
         // 
         this._tbbBringToFront.ImageIndex = 14;
         this._tbbBringToFront.Name = "_tbbBringToFront";
         this._tbbBringToFront.ToolTipText = "Bring Selected Object(s) to Front";
         // 
         // _tbbSendToBack
         // 
         this._tbbSendToBack.ImageIndex = 15;
         this._tbbSendToBack.Name = "_tbbSendToBack";
         this._tbbSendToBack.ToolTipText = "Send Selected Object(s) to Back";
         // 
         // _tbbBringToFirst
         // 
         this._tbbBringToFirst.ImageIndex = 16;
         this._tbbBringToFirst.Name = "_tbbBringToFirst";
         this._tbbBringToFirst.ToolTipText = "Bring Selected Object(s) to First";
         // 
         // _tbbSendToLast
         // 
         this._tbbSendToLast.ImageIndex = 17;
         this._tbbSendToLast.Name = "_tbbSendToLast";
         this._tbbSendToLast.ToolTipText = "Send Selected Object(s) to Last";
         // 
         // _tbbSep6
         // 
         this._tbbSep6.Name = "_tbbSep6";
         this._tbbSep6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // _tbbAlignLefts
         // 
         this._tbbAlignLefts.ImageIndex = 18;
         this._tbbAlignLefts.Name = "_tbbAlignLefts";
         this._tbbAlignLefts.ToolTipText = "Align Selected Objects to Left";
         // 
         // _tbbAlignCenters
         // 
         this._tbbAlignCenters.ImageIndex = 19;
         this._tbbAlignCenters.Name = "_tbbAlignCenters";
         this._tbbAlignCenters.ToolTipText = "Align Selected Objects to Center";
         // 
         // _tbbAlignRights
         // 
         this._tbbAlignRights.ImageIndex = 20;
         this._tbbAlignRights.Name = "_tbbAlignRights";
         this._tbbAlignRights.ToolTipText = "Align Selected Objects to Right";
         // 
         // _tbbAlignTops
         // 
         this._tbbAlignTops.ImageIndex = 21;
         this._tbbAlignTops.Name = "_tbbAlignTops";
         this._tbbAlignTops.ToolTipText = "Align Selected Objects to Top";
         // 
         // _tbbAlignMiddles
         // 
         this._tbbAlignMiddles.ImageIndex = 22;
         this._tbbAlignMiddles.Name = "_tbbAlignMiddles";
         this._tbbAlignMiddles.ToolTipText = "Align Selected Objects to Middle";
         // 
         // _tbbAlignBottoms
         // 
         this._tbbAlignBottoms.ImageIndex = 23;
         this._tbbAlignBottoms.Name = "_tbbAlignBottoms";
         this._tbbAlignBottoms.ToolTipText = "Align Selected Objects to Bottom";
         // 
         // _tbbMakeSameWidth
         // 
         this._tbbMakeSameWidth.ImageIndex = 24;
         this._tbbMakeSameWidth.Name = "_tbbMakeSameWidth";
         this._tbbMakeSameWidth.ToolTipText = "Make Selected Objects Same Width";
         // 
         // _tbbMakeSameHeight
         // 
         this._tbbMakeSameHeight.ImageIndex = 25;
         this._tbbMakeSameHeight.Name = "_tbbMakeSameHeight";
         this._tbbMakeSameHeight.ToolTipText = "Make Selected Objects Same Height";
         // 
         // _tbbMakeSameSize
         // 
         this._tbbMakeSameSize.ImageIndex = 26;
         this._tbbMakeSameSize.Name = "_tbbMakeSameSize";
         this._tbbMakeSameSize.ToolTipText = "Make Selected Objects Same Size";
         // 
         // _tbbSep7
         // 
         this._tbbSep7.Name = "_tbbSep7";
         this._tbbSep7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // _tbbRunDesign
         // 
         this._tbbRunDesign.ImageIndex = 27;
         this._tbbRunDesign.Name = "_tbbRunDesign";
         // 
         // _tbbRotate
         // 
         this._tbbRotate.ImageIndex = 10;
         this._tbbRotate.Name = "_tbbRotate";
         this._tbbRotate.ToolTipText = "Rotate";
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
         // Set license
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
      private bool _antiAlias;
      private bool _redactionMessage;
      private string _openInitialPath = string.Empty;

      private static readonly float _minimumScaleFactor = 0.05f;
      private static readonly float _maximumScaleFactor = 11f;

      public AnnAutomationManager AutomationManager
      {
         get
         {
            return _automationManager;
         }
      }

      public bool RedactionMessage
      {
         get
         {
            return _redactionMessage;
         }
         set
         {
            _redactionMessage = value;
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
         Messager.Caption = "LEADTOOLS C# Annotations Demo";
         Text = Messager.Caption;

         _codecs = new RasterCodecs();
         _annCodecs = new AnnCodecs();
         AnnDeserializeOptions options = new AnnDeserializeOptions();

         options.DeserializeObject += new EventHandler<AnnSerializeObjectEventArgs>(DeserializeOptions_DeserializeObject);

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

         _redactionMessage = true;

         InitToolbar();
         InitAutomation();

         //DoResize();
         LoadImage(true);

         UpdateControls();
         UpdateCaption();
      }

      private void InitToolbar()
      {
         Bitmap btmp = new Bitmap(GetType(), "Resources.MainToolbar.bmp");
         btmp.MakeTransparent(btmp.GetPixel(0, 0));

         _toolBarMain.ImageList = new ImageList();
         _toolBarMain.ImageList.ImageSize = new Size(btmp.Height, btmp.Height);
         _toolBarMain.ImageList.Images.AddStrip(btmp);
      }

      AnnAutomationObject CreateRichTextAutomationObject()
      {
         AnnAutomationObject automationObj = new AnnAutomationObject();
         AnnRichTextObject annRichTextObject = new AnnRichTextObject();

         automationObj.Id = annRichTextObject.Id;
         automationObj.Name = annRichTextObject.FriendlyName;
         automationObj.DrawDesignerType = typeof(AnnRichDrawDesigner);
         automationObj.EditDesignerType = typeof(AnnRichTextEditDesigner);
         automationObj.ObjectTemplate = annRichTextObject;
         automationObj.RunDesignerType = typeof(AnnRunDesigner);

         return automationObj;

      }

      private void InitAutomation()
      {
         _automationManager = new AnnAutomationManager();

         _automationManager.RedactionRealizePassword = string.Empty;
         _automationManager.EditContentAfterDraw = true;
         _automationManager.EditTextAfterDraw = true;
         _automationManager.RestrictDesigners = true;
         _automationManager.CreateDefaultObjects();

         AnnRichTextObjectRenderer annRichTextObjectRenderer = new AnnRichTextObjectRenderer();
         _automationManager.Objects.Add(CreateRichTextAutomationObject());

         _managerHelper = new AutomationManagerHelper(_automationManager);

         IAnnObjectRenderer annNoteObjectRenderer = _automationManager.RenderingEngine.Renderers[AnnObject.NoteObjectId];
         annRichTextObjectRenderer.LocationsThumbStyle = annNoteObjectRenderer.LocationsThumbStyle;
         annRichTextObjectRenderer.RotateCenterThumbStyle = annNoteObjectRenderer.RotateCenterThumbStyle;
         annRichTextObjectRenderer.RotateGripperThumbStyle = annNoteObjectRenderer.RotateGripperThumbStyle;

         _automationManager.RenderingEngine.Renderers[AnnObject.RichTextObjectId] = annRichTextObjectRenderer;

         _managerHelper.CreateToolBar();
         Controls.Add(_managerHelper.ToolBar);

         _managerHelper.ToolBar.Dock = DockStyle.Right;
         _managerHelper.ToolBar.BringToFront();
         _managerHelper.ToolBar.AutoSize = false;
         _managerHelper.ToolBar.Appearance = ToolBarAppearance.Flat;

         _automationManager.UserModeChanged += new EventHandler(_automationManager_UserModeChanged);
      }

      public bool IsEditingText
      {
         get
         {
            bool isEditingText = false;
            if (ActiveAnnotationsForm != null)
            {
               isEditingText = ActiveAnnotationsForm.IsEditingText;
            }

            return isEditingText;
         }
      }

      public void UpdateControls()
      {
         AnnotationsForm annForm = ActiveAnnotationsForm;

         if (annForm == null)
         {
            _menuItemFileSaveAnnotations.Enabled = false;
            _menuItemFileSaveAnnotations.Visible = false;
            _menuItemFileSaveAs.Enabled = false;
            _menuItemFileSaveAs.Visible = false;
            _menuItemFileSaveAsTiff.Enabled = false;
            _menuItemFileSaveAsTiff.Visible = false;
            _menuItemFileSaveAsWang.Enabled = false;
            _menuItemFileSaveAsWang.Visible = false;
            _menuItemLoadAnnPackage.Enabled = false;
            _menuItemLoadAnnPackage.Visible = false;
            _menuItemFileLoadBateStamp.Enabled = false;
            _menuItemFileLoadBateStamp.Visible = false;
            _tbbSave.Enabled = false;
            _tbbSave.Visible = false;

            _menuItemFilePrint.Enabled = false;
            _menuItemFilePrint.Visible = false;
            _menuItemFilePrintPreview.Enabled = false;
            _menuItemFilePrintPreview.Visible = false;
            _menuItemFileSep2.Visible = false;

            _menuItemEdit.Enabled = false;
            _menuItemEdit.Visible = false;

            _menuItemView.Enabled = false;
            _menuItemView.Visible = false;

            _menuItemAnnotations.Enabled = false;
            _menuItemAnnotations.Visible = false;

            _menuItemWindow.Enabled = false;
            _menuItemWindow.Visible = false;

            _tbbSep1.Visible = false;
            _tbbCopy.Visible = false;
            _tbbPaste.Visible = false;
            _tbbDelete.Visible = false;
            _tbbSep2.Visible = false;
            _tbbUndo.Visible = false;
            _tbbRedo.Visible = false;
            _tbbSep3.Visible = false;
            _tbbZoomIn.Visible = false;
            _tbbZoomOut.Visible = false;
            _tbbNoZoom.Visible = false;
            _tbbSep4.Visible = false;
            _tbbRotate.Visible = false;
            _tbbGroup.Visible = false;
            _tbbUngroup.Visible = false;
            _tbbProperties.Visible = false;
            _tbbSep5.Visible = false;
            _tbbBringToFront.Visible = false;
            _tbbSendToBack.Visible = false;
            _tbbBringToFirst.Visible = false;
            _tbbSendToLast.Visible = false;
            _tbbSep6.Visible = false;
            _tbbAlignLefts.Visible = false;
            _tbbAlignCenters.Visible = false;
            _tbbAlignRights.Visible = false;
            _tbbAlignTops.Visible = false;
            _tbbAlignMiddles.Visible = false;
            _tbbAlignBottoms.Visible = false;
            _tbbMakeSameWidth.Visible = false;
            _tbbMakeSameHeight.Visible = false;
            _tbbMakeSameSize.Visible = false;
            _tbbSep7.Visible = false;
            _tbbRunDesign.Visible = false;
            _tbbRunDesign.Visible = false;
            _managerHelper.ToolBar.Visible = false;
         }
         else
         {
            AnnAutomation automation = annForm.Automation;
            var viewer = annForm.Viewer;

            bool designMode = _automationManager.UserMode == AnnUserMode.Design;
            bool isPolyRulerObject = automation.CurrentEditObject is AnnPolyRulerObject;

            _menuItemFileSaveAnnotations.Enabled = true;
            _menuItemFileSaveAnnotations.Visible = true;
            _menuItemFileSaveAs.Enabled = true;
            _menuItemFileSaveAs.Visible = true;
            _menuItemFileSaveAsTiff.Enabled = true;
            _menuItemFileSaveAsTiff.Visible = true;
            _menuItemFileSaveAsWang.Enabled = true;
            _menuItemFileSaveAsWang.Visible = true;
            _menuItemLoadAnnPackage.Enabled = true;
            _menuItemLoadAnnPackage.Visible = true;
            _menuItemFileLoadBateStamp.Enabled = true;
            _menuItemFileLoadBateStamp.Visible = true;
            _tbbSave.Enabled = true;
            _tbbSave.Visible = true;

            _menuItemFilePrint.Enabled = _printDocument != null;
            _menuItemFilePrint.Visible = _printDocument != null;
            _menuItemFilePrintPreview.Enabled = _printDocument != null && DialogUtilities.CanRunPrintPreview;
            _menuItemFilePrintPreview.Visible = _printDocument != null && DialogUtilities.CanRunPrintPreview;
            _menuItemFileSep2.Visible = _printDocument != null;

            _menuItemEdit.Enabled = designMode && !IsEditingText;
            _menuItemEdit.Visible = designMode && !IsEditingText;
            _menuItemEditUndo.Enabled = automation.CanUndo && !IsEditingText;
            _menuItemEditRedo.Enabled = automation.CanRedo && !IsEditingText;

            _menuItemEditCut.Enabled = automation.CanCopy && !IsEditingText;
            _menuItemEditCopy.Enabled = automation.CanCopy && !IsEditingText;
            _menuItemEditPaste.Enabled = automation.CanPaste && !IsEditingText;
            _menuItemEditDelete.Enabled = automation.CanDeleteObjects && !IsEditingText;
            _menuItemEditSelectAll.Enabled = automation.CanSelectObjects && !IsEditingText;
            _menuItemEditSelectNone.Enabled = automation.Container.SelectionObject.SelectedObjects.Count > 0;
            _menuItemEditDuplicate.Enabled = designMode && (automation.CurrentEditObject != null);

            _menuItemView.Enabled = true;
            _menuItemView.Visible = true;

            _menuItemViewSizeModeNormal.Checked = (viewer.SizeMode == ControlSizeMode.None);
            _menuItemViewSizeModeStretch.Checked = (viewer.SizeMode == ControlSizeMode.Stretch);
            _menuItemViewSizeModeFitAlways.Checked = (viewer.SizeMode == ControlSizeMode.FitAlways);
            _menuItemViewSizeModeFitWidth.Checked = (viewer.SizeMode == ControlSizeMode.FitWidth);
            _menuItemViewSizeModeFit.Checked = (viewer.SizeMode == ControlSizeMode.Fit);

            _menuItemViewZoom.Enabled = true;
            _menuItemViewUseDpi.Checked = viewer.UseDpi;

            _menuItemAnnotations.Enabled = true;
            _menuItemAnnotations.Visible = true;

            _menuItemAnnotationsRedactionObjectsRealize.Enabled = automation.CanRealizeRedaction;
            _menuItemAnnotationsRedactionObjectsRestore.Enabled = automation.CanRestoreRedaction;
            _menuItemAnnotationsRedactionObjectsRealizeAll.Enabled = automation.CanRealizeAllRedactions;
            _menuItemAnnotationsRedactionObjectsRestoreAll.Enabled = automation.CanRestoreAllRedactions;

            _menuItemAnnotationsEncryptObjectsApplyAllEncryptors.Enabled = automation.CanApplyAllEncryptors;
            _menuItemAnnotationsEncryptObjectsApplyAllDecryptors.Enabled = automation.CanApplyAllDecryptors;
            _menuItemAnnotationsEncryptObjectsApplyEncryptor.Enabled = automation.CanApplyEncryptor;
            _menuItemAnnotationsEncryptObjectsApplyDecryptor.Enabled = automation.CanApplyDecryptor;

            _menuItemAnnotationsUserModeRun.Checked = !designMode;
            _menuItemAnnotationsUserModeDesign.Checked = designMode;
            _menuItemAnnotationsCurrentObject.Enabled = designMode;

            _menuItemAnnotationsAlign.Enabled = designMode;

            _menuItemAnnotationsAlignSendToBack.Enabled = (automation.CanSendToBack);
            _menuItemAnnotationsAlignSendToLast.Enabled = (automation.CanSendToLast);
            _menuItemAnnotationsAlignBringToFront.Enabled = (automation.CanBringToFront);
            _menuItemAnnotationsAlignBringToFirst.Enabled = (automation.CanBringToFirst);

            _menuItemAnnotationsAlignSep1.Visible = (automation.Manager.EnableObjectsAlignment);
            _menuItemAnnotationsAlignObjectsAlignmentLefts.Visible = (automation.Manager.EnableObjectsAlignment);
            _menuItemAnnotationsAlignObjectsAlignmentLefts.Enabled = (automation.CanAlign);
            _menuItemAnnotationsAlignObjectsAlignmentCenters.Visible = (automation.Manager.EnableObjectsAlignment);
            _menuItemAnnotationsAlignObjectsAlignmentCenters.Enabled = (automation.CanAlign);
            _menuItemAnnotationsAlignObjectsAlignmentRights.Visible = (automation.Manager.EnableObjectsAlignment);
            _menuItemAnnotationsAlignObjectsAlignmentRights.Enabled = (automation.CanAlign);
            _menuItemAnnotationsAlignSep2.Visible = (automation.Manager.EnableObjectsAlignment);
            _menuItemAnnotationsAlignObjectsAlignmentTops.Visible = (automation.Manager.EnableObjectsAlignment);
            _menuItemAnnotationsAlignObjectsAlignmentTops.Enabled = (automation.CanAlign);
            _menuItemAnnotationsAlignObjectsAlignmenMiddles.Visible = (automation.Manager.EnableObjectsAlignment);
            _menuItemAnnotationsAlignObjectsAlignmenMiddles.Enabled = (automation.CanAlign);
            _menuItemAnnotationsAlignObjectsAlignmenBottoms.Visible = (automation.Manager.EnableObjectsAlignment);
            _menuItemAnnotationsAlignObjectsAlignmenBottoms.Enabled = (automation.CanAlign);
            _menuItemAnnotationsAlignSep3.Visible = (automation.Manager.EnableObjectsAlignment);
            _menuItemAnnotationsAlignObjectsMakeSameWidth.Visible = (automation.Manager.EnableObjectsAlignment);
            _menuItemAnnotationsAlignObjectsMakeSameWidth.Enabled = (automation.CanAlign);
            _menuItemAnnotationsAlignObjectsMakeSameHeight.Visible = (automation.Manager.EnableObjectsAlignment);
            _menuItemAnnotationsAlignObjectsMakeSameHeight.Enabled = (automation.CanAlign);
            _menuItemAnnotationsAlignObjectsMakeSameSize.Visible = (automation.Manager.EnableObjectsAlignment);
            _menuItemAnnotationsAlignObjectsMakeSameSize.Enabled = (automation.CanAlign);

            _menuItemAnnotationsFlip.Enabled = designMode;
            _menuItemAnnotationsFlipHorizontal.Enabled = (automation.CanFlip);
            _menuItemAnnotationsFlipVertical.Enabled = (automation.CanFlip);

            _menuItemAnnotationsGroup.Enabled = designMode;
            _menuItemAnnotationsGroupGroupSelectedObjects.Enabled = automation.CanGroup;
            _menuItemAnnotationsGroupUngroup.Enabled = automation.CanUngroup;
            _menuItemAnnotationsPasswordLock.Enabled = automation.CanLock;
            _menuItemAnnotationsPasswordUnlock.Enabled = automation.CanUnlock;

            _menuItemAnnotationsResetRotatePoints.Enabled = designMode && automation.CanResetRotatePoints;
            _menuItemAnnotationsAntiAlias.Checked = _antiAlias;
            _menuItemAnnotationsBehaviorUseRotateThumbs.Checked = _automationManager.Objects.Count > 0 && _automationManager.Objects[0].UseRotateThumbs;
            _menuItemAnnotationsBehaviorRestrictDesigners.Checked = _automationManager.RestrictDesigners;
            _menuItemAnnotationsBehaviorFontRelativeToDPI.Checked = _automationManager.FontRelativeToImageDpi;
            _menuItemAnnotationsBehaviorFreehandSelection.Checked = _automationManager.UseFreehandSelection;
            _menuItemAnnotationsBehaviorEnableObjectsAlignment.Checked = _automationManager.EnableObjectsAlignment;
            _menuItemAnnotationsBehaviorMaintainAspectRatio.Checked = _automationManager.MaintainAspectRatio;
            _menuItemAnnotationsProperties.Enabled = designMode && automation.CanShowObjectProperties;
            _menuItemCalibrate.Enabled = designMode && isPolyRulerObject && !automation.CurrentEditObject.IsLocked;


            _menuItemAnnotationsBehaviorEnableToolTip.Checked = _automationManager.EnableToolTip;

            _menuItemWindow.Enabled = true;
            _menuItemWindow.Visible = true;

            _tbbSep1.Visible = true;
            _tbbCopy.Visible = true;
            _tbbCopy.Enabled = _menuItemEditCopy.Enabled && designMode;
            _tbbPaste.Visible = true;
            _tbbPaste.Enabled = _menuItemEditPaste.Enabled && designMode;
            _tbbDelete.Visible = true;
            _tbbDelete.Enabled = _menuItemEditDelete.Enabled && designMode;
            _tbbSep2.Visible = true;
            _tbbUndo.Visible = true;
            _tbbUndo.Enabled = automation.CanUndo && designMode;
            _tbbRedo.Visible = true;
            _tbbRedo.Enabled = automation.CanRedo && designMode;
            _tbbSep3.Visible = true;

            _tbbZoomIn.Visible = true;
            _tbbZoomOut.Visible = true;
            _tbbNoZoom.Visible = true;

            _tbbZoomIn.Enabled = _menuItemViewZoom.Enabled;
            _tbbZoomOut.Enabled = _menuItemViewZoom.Enabled;
            _tbbNoZoom.Enabled = _menuItemViewZoom.Enabled;

            _tbbSep4.Visible = true;
            _tbbRotate.Visible = true;
            _tbbGroup.Visible = true;
            _tbbGroup.Enabled = _menuItemAnnotationsGroupGroupSelectedObjects.Enabled && designMode;
            _tbbUngroup.Visible = true;
            _tbbUngroup.Enabled = _menuItemAnnotationsGroupUngroup.Enabled && designMode;
            _tbbProperties.Visible = true;
            _tbbProperties.Enabled = _menuItemAnnotationsProperties.Enabled && designMode;
            _tbbSep5.Visible = true;
            _tbbBringToFront.Visible = true;
            _tbbBringToFront.Enabled = _menuItemAnnotationsAlignBringToFront.Enabled && designMode;
            _tbbSendToBack.Visible = true;
            _tbbSendToBack.Enabled = _menuItemAnnotationsAlignSendToBack.Enabled && designMode;
            _tbbBringToFirst.Visible = true;
            _tbbBringToFirst.Enabled = _menuItemAnnotationsAlignBringToFirst.Enabled && designMode;
            _tbbSendToLast.Visible = true;
            _tbbSendToLast.Enabled = _menuItemAnnotationsAlignSendToLast.Enabled && designMode;
            _tbbSep6.Visible = true;
            _tbbAlignLefts.Visible = automation.Manager.EnableObjectsAlignment;
            _tbbAlignLefts.Enabled = _menuItemAnnotationsAlignObjectsAlignmentLefts.Enabled && designMode;
            _tbbAlignCenters.Visible = automation.Manager.EnableObjectsAlignment;
            _tbbAlignCenters.Enabled = _menuItemAnnotationsAlignObjectsAlignmentCenters.Enabled && designMode;
            _tbbAlignRights.Visible = automation.Manager.EnableObjectsAlignment;
            _tbbAlignRights.Enabled = _menuItemAnnotationsAlignObjectsAlignmentRights.Enabled && designMode;
            _tbbAlignTops.Visible = automation.Manager.EnableObjectsAlignment;
            _tbbAlignTops.Enabled = _menuItemAnnotationsAlignObjectsAlignmentTops.Enabled && designMode;
            _tbbAlignMiddles.Visible = automation.Manager.EnableObjectsAlignment;
            _tbbAlignMiddles.Enabled = _menuItemAnnotationsAlignObjectsAlignmenMiddles.Enabled && designMode;
            _tbbAlignBottoms.Visible = automation.Manager.EnableObjectsAlignment;
            _tbbAlignBottoms.Enabled = _menuItemAnnotationsAlignObjectsAlignmenBottoms.Enabled && designMode;
            _tbbMakeSameWidth.Visible = automation.Manager.EnableObjectsAlignment;
            _tbbMakeSameWidth.Enabled = _menuItemAnnotationsAlignObjectsMakeSameWidth.Enabled && designMode;
            _tbbMakeSameHeight.Visible = automation.Manager.EnableObjectsAlignment;
            _tbbMakeSameHeight.Enabled = _menuItemAnnotationsAlignObjectsMakeSameHeight.Enabled && designMode;
            _tbbMakeSameSize.Visible = automation.Manager.EnableObjectsAlignment;
            _tbbMakeSameSize.Enabled = _menuItemAnnotationsAlignObjectsMakeSameSize.Enabled && designMode;
            _tbbSep7.Visible = automation.Manager.EnableObjectsAlignment;
            _tbbRunDesign.Visible = true;
            _tbbRunDesign.Enabled = true;

            if (_menuItemAnnotationsUserModeRun.Checked)
            {
               _tbbRunDesign.ToolTipText = "Switch to Design Mode";
               _tbbRunDesign.ImageIndex = _toolBarMain.ImageList.Images.Count - 1;
            }
            else
            {
               _tbbRunDesign.ToolTipText = "Switch to Run Mode";
               _tbbRunDesign.ImageIndex = _toolBarMain.ImageList.Images.Count - 2;
            }

            if (designMode && !_managerHelper.ToolBar.Visible)
               _managerHelper.ToolBar.Visible = true;

            _menuItemViewInteractiveModeNone.Checked = annForm.AutomationInteractiveMode.IsEnabled;
            _menuItemViewInteractiveModeMagnifyGlass.Checked = annForm.MagnifyGlassInteractiveMode.IsEnabled;
            _menuItemViewInteractiveModePan.Checked = annForm.PanZoomInteractiveMode.IsEnabled;
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

      protected override void OnSizeChanged(EventArgs e)
      {
         if (AutomationManager != null && _managerHelper.ToolBar != null)
            DoResize();

         base.OnSizeChanged(e);
      }

      private void DoResize()
      {
         SuspendLayout();
         _managerHelper.ToolBar.SuspendLayout();

         _managerHelper.ToolBar.Height = ClientSize.Height;

         int width = 0;
         int height = 0;
         for (int i = 0; i < _managerHelper.ToolBar.Buttons.Count; i++)
         {
            if (i == 0)
            {
               width = _managerHelper.ToolBar.Buttons[i].Rectangle.Width;
               height = _managerHelper.ToolBar.Buttons[i].Rectangle.Height;
            }
            else
            {
               width = Math.Max(width, _managerHelper.ToolBar.Buttons[i].Rectangle.Width);
               height = Math.Max(height, _managerHelper.ToolBar.Buttons[i].Rectangle.Height);
            }
         }

         if (width > 0 && height > 0)
         {
            int rows = _managerHelper.ToolBar.Height / height;
            if (rows > 0)
            {
               int columns = _managerHelper.ToolBar.Buttons.Count / rows;
               if ((_managerHelper.ToolBar.Buttons.Count % rows) != 0)
                  columns++;

               _managerHelper.ToolBar.Width = columns * width;
            }
         }

         _managerHelper.ToolBar.ResumeLayout();
         ResumeLayout();
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
         DoResize();
      }

      private void _menuItemFileOpen_Click(object sender, System.EventArgs e)
      {
         LoadImage(false);
      }

      private void LoadImage(bool loadDefaultImage)
      {
         ImageFileLoader loader = new ImageFileLoader();
         bool bLoaded = false;
         loader.OpenDialogInitialPath = String.IsNullOrEmpty(_openInitialPath) ?
            System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : _openInitialPath;

         try
         {
            loader.LoadOnlyOnePage = true;
            string defaultImageFileName =


#if LT_CLICKONCE
               "clean.tif";
#else
 Path.Combine(DemosGlobal.ImagesFolder, @"ocr1.tif");
#endif // LT_CLICKONCE

            if (loadDefaultImage)
            {
               if (File.Exists(defaultImageFileName))
                  bLoaded = loader.Load(this, defaultImageFileName, _codecs, 1, 1);
            }
            else
               bLoaded = loader.Load(this, _codecs, true) > 0;

            if (bLoaded)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               loader.Image.ChangeViewPerspective(RasterViewPerspective.TopLeft);
               NewAnnotationForm(loader.Image, loader.FileName, 1);
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

      private void NewAnnotationForm(RasterImage image, string fileName, int pageNumber)
      {
         AnnotationsForm child = new AnnotationsForm();
         child.MdiParent = this;
         child.Initialize(_paintProperties, image, fileName, pageNumber);
         child.WindowState = FormWindowState.Maximized;
         child.Show();
         child.Viewer.Dock = DockStyle.Fill;
         child.UpdateAntiAlias(_antiAlias);
         LoadAnnotations(fileName, child.Automation.Container, pageNumber, child.AutomationControl);
         child.AutomationTextAdded += child_AutomationTextAdded;
         child.AutomationTextRemoved += child_AutomationTextRemoved;
         child.FormClosed += child_FormClosed;
      }

      void child_FormClosed(object sender, FormClosedEventArgs e)
      {
         AnnotationsForm child = sender as AnnotationsForm;
         child.FormClosed -= child_FormClosed;
         child.AutomationTextAdded -= child_AutomationTextAdded;
         child.AutomationTextRemoved -= child_AutomationTextRemoved;
      }

      void child_AutomationTextAdded(object sender, EventArgs e)
      {
         //when automation text box is active will leave theses shortcuts to the textbox
         this._menuItemEditUndo.Shortcut = System.Windows.Forms.Shortcut.None;
         this._menuItemEditRedo.Shortcut = System.Windows.Forms.Shortcut.None;
         this._menuItemEditCut.Shortcut = System.Windows.Forms.Shortcut.None;
         this._menuItemEditCopy.Shortcut = System.Windows.Forms.Shortcut.None;
         this._menuItemEditPaste.Shortcut = System.Windows.Forms.Shortcut.None;
         this._menuItemEditDelete.Shortcut = System.Windows.Forms.Shortcut.None;
         this._menuItemEditSelectAll.Shortcut = System.Windows.Forms.Shortcut.None;
      }

      void child_AutomationTextRemoved(object sender, EventArgs e)
      {
         //restore shortcuts
         this._menuItemEditUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
         this._menuItemEditRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
         this._menuItemEditCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
         this._menuItemEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
         this._menuItemEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
         this._menuItemEditDelete.Shortcut = System.Windows.Forms.Shortcut.Del;
         this._menuItemEditSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA;

         this.ActiveAnnotationsForm.Automation.Invalidate(LeadRectD.Empty);
      }

      private void _menuItemFileSave_Click(object sender, System.EventArgs e)
      {
         try
         {
            AnnotationsForm activeForm = ActiveAnnotationsForm;
            Save(activeForm.Text, false, activeForm.Viewer.Image.OriginalFormat, false, false);
         }
         catch (Exception ex)
         {
            if (ex is TargetInvocationException && ex.InnerException != null)
               Messager.ShowFileSaveError(this, ActiveAnnotationsForm.Text, ex.InnerException);
            else
               Messager.ShowFileSaveError(this, ActiveAnnotationsForm.Text, ex);
         }
      }

      private void _menuItemFileSaveAs_Click(object sender, System.EventArgs e)
      {
         ImageFileSaver saver = new ImageFileSaver();

         try
         {
            AnnotationsForm activeForm = ActiveAnnotationsForm;

            RasterImage image = activeForm.Viewer.Image.Clone();
            // This is to save image rotation if we did rotate it in the viewer to have the same state when loading it back
            image.RotateViewPerspective((int)activeForm.Viewer.RotateAngle);
            if (saver.Save(this, _codecs, image))
            {
               Save(saver.FileName, false, saver.Format, false, false);
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

      private void SaveAsTag_Click(object sender, EventArgs e)
      {

         bool saveAsWang = (sender == _menuItemFileSaveAsWang);

         using (SaveFileDialog saveDialog = new SaveFileDialog())
         {
            saveDialog.Filter = "Tiff files (*.tif)|*.tif";
            saveDialog.FilterIndex = 1;

            if (saveDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
               string fileName = saveDialog.FileName;
               try
               {
                  AnnotationsForm activeForm = ActiveAnnotationsForm;

                  if (activeForm.Viewer.Image.BitsPerPixel == 1)
                     Save(fileName, true, RasterImageFormat.CcittGroup4, true, saveAsWang);
                  else
                     Save(fileName, true, RasterImageFormat.TifLzw, true, saveAsWang);
               }
               catch (Exception ex)
               {
                  if (ex is TargetInvocationException && ex.InnerException != null)
                     Messager.ShowFileSaveError(this, fileName, ex.InnerException);
                  else
                     Messager.ShowFileSaveError(this, fileName, ex);
               }
            }
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

         RasterImagePainter.Paint(image, g, destRect, RasterPaintProperties.Default);

         foreach (AnnContainer container in ActiveAnnotationsForm.Automation.Containers)
         {
            BurnContainer(container, g, destRect.ToLeadRectD());
         }

         // Inform the printer whether we have no more pages to print
         e.HasMorePages = false;
      }

      private void BurnContainer(AnnContainer container, Graphics g, LeadRectD destRect)
      {
         if (container == null || destRect.IsEmpty)
            return;

         AnnWinFormsRenderingEngine engine = new AnnWinFormsRenderingEngine(container, g);
         engine.Resources = _automationManager.Resources;
         engine.Renderers = _automationManager.RenderingEngine.Renderers;

         ImageViewer viewer = ActiveAnnotationsForm.Viewer;

         //Get the destination rectangle in annotations coordinates
         destRect = LeadRectD.Create(0, 0, destRect.Width * 720.0 / 96.0, destRect.Height * 720.0 / 96.0);

         engine.BurnToRectWithDpi(destRect, 96, 96, 96, 96);
      }

      private void _printDocument_EndPrint(object sender, PrintEventArgs e)
      {
         // Nothing to do here
      }

      private void _menuItemFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void _menuItemEdit_Popup(object sender, System.EventArgs e)
      {
         _menuItemEditPaste.Enabled = ActiveAnnotationsForm.Automation.CanPaste;
      }

      private void _menuItemEditUndoRedo_Click(object sender, System.EventArgs e)
      {
         try
         {
            AnnotationsForm activeForm = ActiveAnnotationsForm;

            if (sender == _menuItemEditUndo)
               activeForm.Automation.Undo();
            else if (sender == _menuItemEditRedo)
               activeForm.Automation.Redo();
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

      private void _menuItemEditClipboard_Click(object sender, System.EventArgs e)
      {
         try
         {
            AnnotationsForm activeForm = ActiveAnnotationsForm;

            if (sender == _menuItemEditCut)
            {
               activeForm.Automation.Copy();
               activeForm.Automation.DeleteSelectedObjects();
            }
            else if (sender == _menuItemEditCopy)
               activeForm.Automation.Copy();
            else if (sender == _menuItemEditPaste)
               activeForm.Automation.Paste();
            else if (sender == _menuItemEditDelete)
               activeForm.Automation.DeleteSelectedObjects();
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

      private void _menuItemEditSelect_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;

         if (sender == _menuItemEditSelectAll)
            activeForm.Automation.SelectObjects(activeForm.Automation.Container.Children);
         else if (sender == _menuItemEditSelectNone)
            activeForm.Automation.SelectObjects(null);

         activeForm.Viewer.Invalidate();
         UpdateControls();
      }

      private void _toolBarMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
      {
         if (e.Button == _tbbOpen)
            _menuItemFileOpen.PerformClick();
         else if (e.Button == _tbbSave)
            _menuItemFileSaveAnnotations.PerformClick();
         else if (e.Button == _tbbCopy)
            _menuItemEditCopy.PerformClick();
         else if (e.Button == _tbbPaste)
            _menuItemEditPaste.PerformClick();
         else if (e.Button == _tbbDelete)
            _menuItemEditDelete.PerformClick();
         else if (e.Button == _tbbUndo)
            _menuItemEditUndo.PerformClick();
         else if (e.Button == _tbbRedo)
            _menuItemEditRedo.PerformClick();
         else if (e.Button == _tbbZoomIn)
            _menuItemViewZoomIn.PerformClick();
         else if (e.Button == _tbbZoomOut)
            _menuItemViewZoomOut.PerformClick();
         else if (e.Button == _tbbNoZoom)
            _menuItemViewZoomNormal.PerformClick();
         else if (e.Button == _tbbGroup)
            _menuItemAnnotationsGroupGroupSelectedObjects.PerformClick();
         else if (e.Button == _tbbUngroup)
            _menuItemAnnotationsGroupUngroup.PerformClick();
         else if (e.Button == _tbbProperties)
            _menuItemAnnotationsProperties.PerformClick();
         else if (e.Button == _tbbBringToFront)
            _menuItemAnnotationsAlignBringToFront.PerformClick();
         else if (e.Button == _tbbSendToBack)
            _menuItemAnnotationsAlignSendToBack.PerformClick();
         else if (e.Button == _tbbBringToFirst)
            _menuItemAnnotationsAlignBringToFirst.PerformClick();
         else if (e.Button == _tbbSendToLast)
            _menuItemAnnotationsAlignSendToLast.PerformClick();
         else if (e.Button == _tbbAlignLefts)
            _menuItemAnnotationsAlignObjectsAlignmentLefts.PerformClick();
         else if (e.Button == _tbbAlignCenters)
            _menuItemAnnotationsAlignObjectsAlignmentCenters.PerformClick();
         else if (e.Button == _tbbAlignRights)
            _menuItemAnnotationsAlignObjectsAlignmentRights.PerformClick();
         else if (e.Button == _tbbAlignTops)
            _menuItemAnnotationsAlignObjectsAlignmentTops.PerformClick();
         else if (e.Button == _tbbAlignMiddles)
            _menuItemAnnotationsAlignObjectsAlignmenMiddles.PerformClick();
         else if (e.Button == _tbbAlignBottoms)
            _menuItemAnnotationsAlignObjectsAlignmenBottoms.PerformClick();
         else if (e.Button == _tbbMakeSameWidth)
            _menuItemAnnotationsAlignObjectsMakeSameWidth.PerformClick();
         else if (e.Button == _tbbMakeSameHeight)
            _menuItemAnnotationsAlignObjectsMakeSameHeight.PerformClick();
         else if (e.Button == _tbbMakeSameSize)
            _menuItemAnnotationsAlignObjectsMakeSameSize.PerformClick();
         else if (e.Button == _tbbRunDesign)
         {
            if (_automationManager.UserMode == AnnUserMode.Run)
               _menuItemAnnotationsUserModeDesign.PerformClick();
            else if (_automationManager.UserMode == AnnUserMode.Design)
               _menuItemAnnotationsUserModeRun.PerformClick();
         }
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

         if (Math.Abs(viewer.ScaleFactor - scaleFactor) > 0)
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

      private void _menuItemViewFlip_Click(object sender, System.EventArgs e)
      {
         bool horizontal;

         if (sender == _menuItemViewFlipHorizontal)
            horizontal = true;
         else
            horizontal = false;

         try
         {
            using (WaitCursor wait = new WaitCursor())
            {

               AnnotationsForm activeForm = ActiveAnnotationsForm;
               IAnnAutomationControl viewer = activeForm.Automation.AutomationControl;
               bool useDpiPrev = viewer.AutomationUseDpi;
               activeForm.Viewer.UseDpi = false;
               FlipImageAndAnnotations(horizontal, activeForm.Automation.Container, activeForm.Viewer);
               activeForm.Viewer.UseDpi = useDpiPrev;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         UpdateControls();
      }

      private void _menuItemViewRotate_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;

         if (sender == _menuItemViewRotate180)
            activeForm.Viewer.RotateAngle = 180;
         else if (sender == _menuItemViewRotate270)
            activeForm.Viewer.RotateAngle = 270;
         else if (sender == _menuItemViewRotate90)
            activeForm.Viewer.RotateAngle = 90;
         else
            activeForm.Viewer.RotateAngle = 0;

         UpdateControls();
      }

      private void PaintPropertiesDialog_Apply(object sender, EventArgs e)
      {
         PaintPropertiesDialog dlg = sender as PaintPropertiesDialog;
         _paintProperties = dlg.PaintProperties;
         foreach (Form form in MdiChildren)
         {
            var i = form as AnnotationsForm;
            if (i != null) i.UpdatePaintProperties(_paintProperties);
         }
      }

      private void _menuItemAnnotationsRedactionObjects_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;

         if (sender == _menuItemAnnotationsRedactionObjectsRealize)
            activeForm.Automation.RealizeRedaction();
         else if (sender == _menuItemAnnotationsRedactionObjectsRestore)
            activeForm.Automation.RestoreRedaction();
         UpdateControls();
      }

      private void _menuItemAnnotationsRedactionObjectsAll_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;

         if (sender == _menuItemAnnotationsRedactionObjectsRealizeAll)
            activeForm.Automation.RealizeAllRedactions();
         else if (sender == _menuItemAnnotationsRedactionObjectsRestoreAll)
            activeForm.Automation.RestoreAllRedactions();
         UpdateControls();
      }

      private void _menuItemAnnotationsEncryptObjects_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;

         if (sender == _menuItemAnnotationsEncryptObjectsApplyEncryptor)
            activeForm.Automation.ApplyEncryptor();
         else if (sender == _menuItemAnnotationsEncryptObjectsApplyDecryptor)
            activeForm.Automation.ApplyDecryptor();
         UpdateControls();
      }

      private void _menuItemAnnotationsEncryptObjectsAll_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;

         if (sender == _menuItemAnnotationsEncryptObjectsApplyAllEncryptors)
            activeForm.Automation.ApplyAllEncryptors();
         else if (sender == _menuItemAnnotationsEncryptObjectsApplyAllDecryptors)
            activeForm.Automation.ApplyAllDecryptors();
         UpdateControls();
      }

      private void _menuItemAnnotationsRealize_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;
         if (activeForm == null)
            return;

         AnnContainer container = activeForm.Automation.Container;
         RasterImage rasterImage = activeForm.Viewer.Image;

         try
         {
            AnnWinFormsRenderingEngine renderingEngine = new AnnWinFormsRenderingEngine();
            renderingEngine.Renderers = _managerHelper.AutomationManager.RenderingEngine.Renderers;
            renderingEngine.Resources = _automationManager.Resources;

            ImageViewerAutoResetOptions autoResetOptions = activeForm.Viewer.AutoResetOptions;
            activeForm.Viewer.AutoResetOptions = ImageViewerAutoResetOptions.None;
            activeForm.Viewer.Image = renderingEngine.RenderOnImage(container, rasterImage);
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

      private void _menuItemAnnotationsFlip_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;
         if (sender == _menuItemAnnotationsFlipHorizontal)
            activeForm.Automation.Flip(true);
         else if (sender == _menuItemAnnotationsFlipVertical)
            activeForm.Automation.Flip(false);

         UpdateControls();
      }

      private void _menuItemAnnotationsGroupGroupSelectedObjects_Click(object sender, System.EventArgs e)
      {
         AnnContainer annContainer = ActiveAnnotationsForm.Automation.Container;
         if (annContainer.SelectionObject != null && annContainer.SelectionObject.SelectedObjects.Count > 1)
         {
            string groupName = string.Format("Group{0}", _randomNumber.Next() % 100);
            foreach (AnnObject annObject in annContainer.SelectionObject.SelectedObjects)
            {
               annObject.GroupName = groupName;
            }
         }

         UpdateControls();
      }

      private void _menuItemAnnotationsGroupUngroup_Click(object sender, System.EventArgs e)
      {
         AnnContainer annContainer = ActiveAnnotationsForm.Automation.Container;
         if (annContainer.SelectionObject != null && annContainer.SelectionObject.SelectedObjects.Count > 1)
         {
            annContainer.SelectionObject.Ungroup(annContainer.SelectionObject.SelectedObjects[0].GroupName);
         }

         UpdateControls();
      }

      private void _menuItemAnnotationsPassword_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;

         if (sender == _menuItemAnnotationsPasswordLock)
            activeForm.Automation.Lock();
         else if (sender == _menuItemAnnotationsPasswordUnlock)
            activeForm.Automation.Unlock();
         UpdateControls();
      }

      private void _menuItemAnnotationsAlign_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;

         if (sender == _menuItemAnnotationsAlignBringToFront)
            activeForm.Automation.BringToFront(false);
         else if (sender == _menuItemAnnotationsAlignSendToBack)
            activeForm.Automation.SendToBack(false);
         else if (sender == _menuItemAnnotationsAlignBringToFirst)
            activeForm.Automation.BringToFront(true);
         else if (sender == _menuItemAnnotationsAlignSendToLast)
            activeForm.Automation.SendToBack(true);
         else if (sender == _menuItemAnnotationsAlignObjectsAlignmentLefts)
            activeForm.Automation.AlignLefts();
         else if (sender == _menuItemAnnotationsAlignObjectsAlignmentCenters)
            activeForm.Automation.AlignCenters();
         else if (sender == _menuItemAnnotationsAlignObjectsAlignmentRights)
            activeForm.Automation.AlignRights();
         else if (sender == _menuItemAnnotationsAlignObjectsAlignmentTops)
            activeForm.Automation.AlignTops();
         else if (sender == _menuItemAnnotationsAlignObjectsAlignmenMiddles)
            activeForm.Automation.AlignMiddles();
         else if (sender == _menuItemAnnotationsAlignObjectsAlignmenBottoms)
            activeForm.Automation.AlignBottoms();
         else if (sender == _menuItemAnnotationsAlignObjectsMakeSameWidth)
            activeForm.Automation.MakeSameWidth();
         else if (sender == _menuItemAnnotationsAlignObjectsMakeSameHeight)
            activeForm.Automation.MakeSameHeight();
         else if (sender == _menuItemAnnotationsAlignObjectsMakeSameSize)
            activeForm.Automation.MakeSameSize();
         UpdateControls();
      }

      private void _menuItemAnnotationsResetRotatePoints_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;

         activeForm.Automation.ResetRotatePoints();
         UpdateControls();
      }

      private void _menuItemAnnotationsCurrentObject_Click(object sender, System.EventArgs e)
      {
         using (CurrentObjectDialog dlg = new CurrentObjectDialog(_automationManager))
         {
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _automationManager.CurrentObjectId = dlg.ObjectId;
               if (_automationManager.CurrentObjectId == AnnObject.RubberStampObjectId)
                  _automationManager.CurrentRubberStampType = dlg.RubberStampType;
            }
         }
      }

      private void _menuItemAnnotationsAntiAlias_Click(object sender, System.EventArgs e)
      {
         _antiAlias = !_antiAlias;

         foreach (AnnotationsForm i in MdiChildren)
         {
            i.UpdateAntiAlias(_antiAlias);
         }

         UpdateControls();
      }

      private void _menuItemAnnotationsSnapToGridProperties_Click(object sender, EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;
         if (activeForm != null)
         {
            using (SnapToGridPropertiesDialog dlg = new SnapToGridPropertiesDialog())
            {
               dlg.Automation = activeForm.Automation;
               dlg.ShowDialog();
            }
         }

         UpdateControls();
      }

      private void _menuItemAnnotationsProperties_Click(object sender, System.EventArgs e)
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;
         if (activeForm != null && activeForm.Automation.CanShowObjectProperties)
            activeForm.Automation.ShowObjectProperties();

         UpdateControls();
      }

      private void _menuItemAnnotationsBehaviorUseRotateThumbs_Click(object sender, System.EventArgs e)
      {
         bool useRotateControlPoints = !_menuItemAnnotationsBehaviorUseRotateThumbs.Checked;

         foreach (AnnAutomationObject obj in _automationManager.Objects)
            obj.UseRotateThumbs = useRotateControlPoints;

         AnnotationsForm form = ActiveAnnotationsForm;
         if (form != null && form.Automation.CanSelectNone)
         {
            AnnotationsForm activeForm = ActiveAnnotationsForm;

            activeForm.Automation.SelectObjects(null);

            activeForm.Viewer.Invalidate();
         }
         UpdateControls();
      }

      private void _menuItemAnnotationsBehaviorRestrictDesigners_Click(object sender, EventArgs e)
      {
         _automationManager.RestrictDesigners = !_automationManager.RestrictDesigners;
         UpdateControls();
      }

      private void _menuItemAnnotationsBehaviorEnableObjectsAlignment_Click(object sender, EventArgs e)
      {
         _automationManager.EnableObjectsAlignment = !_automationManager.EnableObjectsAlignment;
         UpdateControls();
      }

      private void _menuItemAnnotationsBehaviorEnableAutoIncrement_Click(object sender, EventArgs e)
      {
         _menuItemAnnotationsBehaviorEnableAutoIncrement.Checked = !_menuItemAnnotationsBehaviorEnableAutoIncrement.Checked;
         SetAutoIncrement(_menuItemAnnotationsBehaviorEnableAutoIncrement.Checked);
      }

      private void _menuItemAnnotationsBehaviorFreehandSelection_Click(object sender, EventArgs e)
      {
         _automationManager.UseFreehandSelection = !_automationManager.UseFreehandSelection;
         UpdateControls();
      }

      private void _menuItemAnnotationsBehaviorFontRelativeToDPI_Click(object sender, EventArgs e)
      {
         _automationManager.FontRelativeToImageDpi = !_automationManager.FontRelativeToImageDpi;
         UpdateControls();
      }

      private void SetAutoIncrement(bool autoIncrement)
      {


         foreach (var automationObject in _automationManager.Objects)
         {
            if (autoIncrement)
            {
               automationObject.LabelTemplate = "##";
            }
            else
            {
               automationObject.LabelTemplate = string.Empty;
            }
         }

      }

      private void _menuItemAnnotationsBehaviorEnableToolTip_Click(object sender, System.EventArgs e)
      {
         _menuItemAnnotationsBehaviorEnableToolTip.Checked = !_menuItemAnnotationsBehaviorEnableToolTip.Checked;
         _automationManager.EnableToolTip = !_automationManager.EnableToolTip;
      }

      private void _menuItemAnnotationsBehaviorMaintainAspectRatio_Click(object sender, System.EventArgs e)
      {
         _automationManager.MaintainAspectRatio = !_automationManager.MaintainAspectRatio;

         AnnotationsForm activeForm = ActiveAnnotationsForm;
         if (activeForm != null && activeForm.Automation.Container.SelectionObject.SelectedObjects.Count > 0)
            activeForm.Automation.SelectObjects(null);
      }

      private void _menuItemAnnotationsUserMode_Click(object sender, System.EventArgs e)
      {
         if (_automationManager.UserMode == AnnUserMode.Design)
            _automationManager.UserMode = AnnUserMode.Run;
         else
         {
            _automationManager.UserMode = AnnUserMode.Design;
         }

         UpdateControls();
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
         using (AboutDialog aboutDialog = new AboutDialog("Annotations", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      public void SetStatusBarText(string text)
      {
         _sbMain.Text = text;
      }

      private void _automationManager_UserModeChanged(object sender, EventArgs e)
      {
         UpdateCaption();
         UpdateControls();
      }

      private void UpdateCaption()
      {
         Text = string.Format("{0} [{1}]", Messager.Caption, _automationManager.UserMode == AnnUserMode.Run ? "Run" : "Design");
      }

      public void CurrentDesignerChanged()
      {
         AnnotationsForm activeForm = ActiveAnnotationsForm;

         if (activeForm != null)
         {
            AnnAutomation automation = activeForm.Automation;
            if (automation.CurrentDesigner != null && automation.CurrentDesigner is AnnRunDesigner)
            {
               AnnRunDesigner runDesigner = automation.CurrentDesigner as AnnRunDesigner;
               runDesigner.Run += new EventHandler<AnnRunDesignerEventArgs>(MyRunDesignerHandler);
            }
         }
      }

      private void MyRunDesignerHandler(object sender, AnnRunDesignerEventArgs e)
      {
         if (e.OperationStatus == AnnDesignerOperationStatus.End)
         {
            try
            {
               AnnMediaObject mediaObject = e.Object as AnnMediaObject;
               string mediaSource = null;

               if (mediaObject != null && mediaObject.Media != null)
                  mediaSource = mediaObject.Media.Source1;

               if (mediaSource != null)
               {
                  if (mediaObject.Id == AnnObject.AudioObjectId)
                  {
                     using (MediaForm mediaForm = new MediaForm(mediaSource, MediaControl.Audio))
                     {
                        mediaForm.ShowDialog(this);
                        return;
                     }
                  }
                  else
                  {
                     using (MediaForm mediaForm = new MediaForm(mediaSource, MediaControl.Video))
                     {
                        mediaForm.ShowDialog(this);
                        return;
                     }
                  }
               }

               if (!e.Cancel && string.IsNullOrEmpty(e.Object.Hyperlink))
               {
                  e.Cancel = true;

                  StringBuilder sb = new StringBuilder();
                  sb.Append("You clicked an object that has no hyperlink:");
                  sb.Append(Environment.NewLine);
                  sb.Append(Environment.NewLine);
                  sb.Append(string.Format("Name: {0}", e.Object.FriendlyName));
                  sb.Append(Environment.NewLine);
                  sb.Append(string.Format("Type: {0}", e.Object.GetType().Name));
                  sb.Append(Environment.NewLine);
                  Messager.ShowInformation(this, sb.ToString());
               }
               else
                  Process.Start(e.Object.Hyperlink);
            }

            catch (Exception ex)
            {
               MessageBox.Show(this, ex.Message, null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         }
      }

      public string GetAnnotationsFileName(string fileName)
      {
         // the file name may be (.xml) new design , or (.ann) for old annotations
         string annFileName = Path.ChangeExtension(fileName, "xml");
         if (!File.Exists(annFileName))
         {
            annFileName = Path.ChangeExtension(fileName, "ann");
            if (!File.Exists(annFileName))
               return string.Empty;
         }

         return annFileName;
      }

      public void Save(string fileName, bool saveImage, RasterImageFormat format, bool saveToTiff, bool saveToWang)
      {
         AnnotationsForm form = ActiveAnnotationsForm;
         AnnAutomation automation = form.Automation;
         RasterImage image = form.Viewer.Image.Clone();
         if (saveImage)
         {
            try
            {

               // This is to save image rotation if we did rotate it in the viewer to have the same state when loading it back
               image.RotateViewPerspective((int)form.Viewer.RotateAngle);

               //if we want to attach the annotations as tags we should save the image as Tiff 
               if (saveToTiff && image.OriginalFormat != RasterImageFormat.CcittGroup4 && image.OriginalFormat != RasterImageFormat.TifLzw)
               {
                  _codecs.Save(image, fileName, RasterImageFormat.TifLzw, image.BitsPerPixel);
               }
               else
               {
                  _codecs.Save(image, fileName, image.OriginalFormat, image.BitsPerPixel);
               }

            }
            catch (RasterException ex)
            {
               if (ex.Code == RasterExceptionCode.BitsPerPixel)
               {
                  _codecs.Save(image, form.Text, image.OriginalFormat, 0);
               }
            }
         }

         SaveAnnotations(fileName, image.Page, automation.Container, saveToTiff, saveToWang);
      }

      private List<string> _skippedLoadedObjects;

      void DeserializeOptions_DeserializeObject(object sender, AnnSerializeObjectEventArgs e)
      {
         // Check if the object has an AutomationObject, if not, this means this object
         // was created with a pack loaded, collect the info and warn the user. Skip loading this object

         foreach (AnnAutomationObject automationObject in _automationManager.Objects)
         {
            if (automationObject.ObjectTemplate.GetType().FullName == e.TypeName)
            {
               e.AnnObject = automationObject.ObjectTemplate.Clone();
               return;
            }
         }

         // Not found,
         e.SkipObject = true;
         if (_skippedLoadedObjects != null && !_skippedLoadedObjects.Contains(e.TypeName))
            _skippedLoadedObjects.Add(e.TypeName);
      }

      private void LoadAnnotations(string fileName, AnnContainer container, int pageNumber, IAnnAutomationControl automationControl)
      {
         //Set some properties for the AnnCodecs to update container mapper resolutions during build before updating it on automation
         _annCodecs.LoadUseDpi = automationControl.AutomationUseDpi;
         _annCodecs.LoadSourceResolution = LeadSizeD.Create(automationControl.AutomationXResolution, automationControl.AutomationYResolution);
         _annCodecs.LoadTargetResolution = LeadSizeD.Create(automationControl.AutomationDpiX, automationControl.AutomationDpiY);

         AnnContainer tmpContainer = null;
         CodecsImageInfo info = _codecs.GetInformation(fileName, false);

         try
         {
            // To hold any objects we skipped
            _skippedLoadedObjects = new List<string>();

            //try to load annotations from tif fil tags
            if (IsTiffFormat(info.Format))
            {
               tmpContainer = AnnCodecs.Load(fileName, 1);
            }

            if (tmpContainer == null)
            {
               string annFileName = GetAnnotationsFileName(fileName);
               if (annFileName != string.Empty)
               {
                  tmpContainer = AnnCodecs.Load(annFileName, 1);

                  if (tmpContainer != null)
                  {

                     //Set the Text for rich text object if it is loaded
                     foreach (var annObject in tmpContainer.Children)
                     {
                        if (annObject.Id == AnnObject.TextObjectId)
                        {
                           if (annObject.Metadata.ContainsKey("RichTextData"))
                           {
                              AnnTextObject annTextObject = annObject as AnnTextObject;
                              //convert the rtf string to text , the rich text control will take care of this
                              RichTextBox richTextBox = new RichTextBox();
                              richTextBox.Rtf = annObject.Metadata["RichTextData"]; ;
                              annTextObject.Text = richTextBox.Text;
                           }
                        }

                        if (annObject.Id == AnnObject.EncryptObjectId)
                        {
                           AnnEncryptObject encrypt = annObject as AnnEncryptObject;
                           if (encrypt.IsEncrypted)
                           {
                              encrypt.Encryptor = true;
                              encrypt.Apply(_automationManager.Automations[0].AutomationControl.AutomationDataProvider, _automationManager.Automations[0].Container);
                              _automationManager.Automations[0].InvalidateObject(annObject);
                           }
                        }
                     }

                     if (_skippedLoadedObjects.Count > 0)
                     {
                        // We skipped loading objects that we couldnt automate, show a warning to the user
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("The following object types were found in the file but skipped during load since the demo did not find an automation object for them.");
                        sb.AppendLine("You can fix this by loading the package that contains these objects from File/Load Package and try again");
                        sb.AppendLine();
                        sb.AppendLine("Object types:");
                        sb.AppendLine("-------------");
                        foreach (string typeName in _skippedLoadedObjects)
                        {
                           sb.AppendLine(typeName);
                        }
                        MessageBox.Show(this, sb.ToString(), Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     }
                  }
               }
            }
         }
         catch (Exception ex)
         {
            if (ex is TargetInvocationException && ex.InnerException != null)
               Messager.ShowError(this, ex.InnerException);
            else
               Messager.ShowError(this, ex);
         }

         if (tmpContainer != null)
         {
            container.Children.Clear();

            AnnUnit calibrationUnit = tmpContainer.Mapper.CalibrationUnit;

            // Apply loaded calibration scale
            container.Mapper.Calibrate(LeadLengthD.Create(1), calibrationUnit, LeadLengthD.Create(tmpContainer.Mapper.CalibrationScale), calibrationUnit);

            double rotationAngle = tmpContainer.RotateAngle;
            
            // Switch the width and height of the container if container angle is 90 OR 270
            if (rotationAngle == 90 || rotationAngle == 270)
            {
               double newWidth = container.Size.Height;
               double newHeight = container.Size.Width;
               container.Size = LeadSizeD.Create(newWidth, newHeight);
            }

            // Apply loaded rotation angle
            container.Rotate(rotationAngle);

            foreach (AnnObject annObject in tmpContainer.Children)
            {
               container.Children.Add(annObject);
            }
         }

         if (ActiveAnnotationsForm != null)
            ActiveAnnotationsForm.Automation.Invalidate(LeadRectD.Empty);
      }

      private bool IsTiffFormat(RasterImageFormat format)
      {
         switch (format)
         {
            case RasterImageFormat.Tif:
            case RasterImageFormat.TifLzw:
            case RasterImageFormat.TifJpeg411:
            case RasterImageFormat.TifJpeg422:
            case RasterImageFormat.Ccitt:
            case RasterImageFormat.CcittGroup31Dim:
            case RasterImageFormat.CcittGroup32Dim:
            case RasterImageFormat.CcittGroup4:
            case RasterImageFormat.TifCmyk:
            case RasterImageFormat.TifLzwCmyk:
            case RasterImageFormat.TifPackBits:
            case RasterImageFormat.TifPackBitsCmyk:
            case RasterImageFormat.TifYcc:
            case RasterImageFormat.TifLzwYcc:
            case RasterImageFormat.TifPackbitsYcc:
            case RasterImageFormat.Exif:
            case RasterImageFormat.ExifYcc:
            case RasterImageFormat.TifCmp:
            case RasterImageFormat.TifJbig:
            case RasterImageFormat.TifUnknown:
            case RasterImageFormat.GeoTiff:
            case RasterImageFormat.TifLead1Bit:
            case RasterImageFormat.TifCmw:
            case RasterImageFormat.TifJpeg:
               return true;

            default:
               return false;
         }
      }
      private static void SaveContainerToTiff(RasterCodecs codecs, AnnCodecs annCodecs, string fileName, int pageNumber, AnnContainer container, bool saveToWang)
      {
         RasterTagMetadata tag = annCodecs.SaveToTag(container, saveToWang);
         if (tag != null)
            codecs.WriteTag(fileName, pageNumber, tag);
      }

      private void SaveAnnotations(string imageFileName, int pageNumber, AnnContainer container, bool saveToTiff, bool saveToWang)
      {
         // Rotate the container before saving it to get the same state when loading it back
         container.Rotate(ActiveAnnotationsForm.Viewer.RotateAngle);

         if (saveToTiff)
         {
            SaveContainerToTiff(_codecs, _annCodecs, imageFileName, pageNumber, container, saveToWang);
         }
         else
         {
            string annFileName = Path.ChangeExtension(imageFileName, "xml");

            try
            {
               AnnCodecs.Save(annFileName, container, AnnFormat.Annotations, 1);
            }
            catch (Exception ex)
            {
               if (ex is TargetInvocationException && ex.InnerException != null)
                  Messager.ShowError(this, ex.InnerException);
               else
                  Messager.ShowError(this, ex);
            }
         }
      }

      private bool IsDecryptor(AnnObject obj)
      {
         bool bRet = false;

         AnnEncryptObject annEncryptObject = obj as AnnEncryptObject;
         if (annEncryptObject == null) return false;
         if (annEncryptObject.Encryptor == false)
            bRet = true;

         return bRet;
      }

      private bool IsDecryptorPresent(AnnContainer container)
      {
         foreach (AnnObject obj in container.Children)
         {
            AnnSelectionObject annGroupObject = obj as AnnSelectionObject;
            if (annGroupObject != null)
            {
               foreach (AnnObject obj2 in annGroupObject.SelectedObjects)
               {
                  if (IsDecryptor(obj2))
                     return true;
               }
            }
            else if (IsDecryptor(obj))
               return true;
         }
         return false;
      }

      private void FlipImageAndAnnotations(bool horizontal, AnnContainer container, ImageViewer viewer)
      {
         bool bDecryptor = IsDecryptorPresent(container);
         if (bDecryptor)
         {
            MessageBox.Show(@"You must 'Apply Decryptor' before doing a flip.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         viewer.Image.FlipViewPerspective(horizontal);
         container.Flip(horizontal);

         if (container.SelectionObject != null)
            container.SelectionObject.AdjustBounds();

         ActiveAnnotationsForm.Automation.Invalidate(LeadRectD.Empty);
      }

      private void _menuItemViewInteractiveMode_Click(object sender, EventArgs e)
      {

         foreach (var form in MdiChildren)
         {
            var i = (AnnotationsForm) form;
            var viewer = i.Viewer;

            viewer.InteractiveModes.BeginUpdate();

            foreach (ImageViewerInteractiveMode mode in viewer.InteractiveModes)
            {
               mode.IsEnabled = false;
            }

            if (sender == _menuItemViewInteractiveModeMagnifyGlass)
               i.MagnifyGlassInteractiveMode.IsEnabled = true;
            else if (sender == _menuItemViewInteractiveModePan)
               i.PanZoomInteractiveMode.IsEnabled = true;
            else
               i.AutomationInteractiveMode.IsEnabled = true;

            viewer.InteractiveModes.EndUpdate();
         }

         UpdateControls();
      }

      private void _menuItemViewUseDpi_Click(object sender, EventArgs e)
      {
         _menuItemViewUseDpi.Checked = !_menuItemViewUseDpi.Checked;
         ActiveAnnotationsForm.Viewer.UseDpi = _menuItemViewUseDpi.Checked;
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         _managerHelper.Dispose();

      }

      private void _menuItemLoadAnnPackage_Click(object sender, EventArgs e)
      {
         if (_showLoadPackageInfoDialog)
         {
            StringBuilder info = new StringBuilder();
            info.AppendLine("This allows you to load a .NET dll that contains custom Annotation Objects.\n");
            info.AppendLine("The dll must have a class that implements the IAnnPackage interface defined in the Leadtools.Annotations.Automation Assembly.\n");
            info.AppendLine("For testing, you can load the Custom Medical objects located in Leadtools.Annotations.UserMedicalPack.WinForms.dll.");

            using (UserInfoDialog dlg = new UserInfoDialog(info.ToString()))
            {
               dlg.Text = "Load Package Information";
               dlg.ShowDialog();
               _showLoadPackageInfoDialog = dlg.ShowNextTime;
            }
         }

         using (OpenFileDialog openFileDialog = new OpenFileDialog())
         {
            openFileDialog.Title = "Load Annotations Package";
            openFileDialog.Filter = "Dll files (*.dll)|*.dll";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               LoadPackage(openFileDialog.FileName);
               SetAutoIncrement(_menuItemAnnotationsBehaviorEnableAutoIncrement.Checked);
            }
         }
      }

      private void LoadPackage(string fileName)
      {
         try
         {
            Assembly assembly = Assembly.LoadFrom(fileName);
            Type[] types = assembly.GetTypes();
            Type packageType = typeof(IAnnPackage);
            bool packageFound = false;
            bool packageAlreadyLoaded = false;
            IAnnPackage package = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The following packages were loaded");
            sb.AppendLine();

            // load packages those implement IAnnPackage.
            foreach (Type type in types)
            {
               if (packageType.IsAssignableFrom(type))
               {
                  packageFound = true;

                  package = (IAnnPackage)Activator.CreateInstance(type);
                  if (!_loadedPackages.Contains(package.FriendlyName))
                  {
                     _managerHelper.LoadPackage(package);
                     _loadedPackages.Add(package.FriendlyName);
                  }
                  else
                     packageAlreadyLoaded = true;

                  sb.AppendLine("Name:" + package.FriendlyName);
                  sb.AppendLine("Author:" + package.Author);
                  sb.AppendLine("Description:" + package.Description);
               }
            }

            if (packageFound)
            {
               if (packageAlreadyLoaded)
                  MessageBox.Show(this, string.Format("The Package ({0}) Is Already Loaded", package.FriendlyName), "Annotations Package", MessageBoxButtons.OK, MessageBoxIcon.Information);
               else
                  MessageBox.Show(this, sb.ToString(), "Annotations Package", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
               MessageBox.Show(this, "The specified dll doesn't contain annotations packages", "Annotations Package", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }

      private void _menuItemFileLoadBateStamp_Click(object sender, EventArgs e)
      {
         try
         {
            if (_showLoadBatesStampInfoDialog)
            {
               StringBuilder info = new StringBuilder();
               info.AppendLine("Use this Menu to load Bates stamp xml file.\n");
               info.AppendLine("You can create bates stamp using our Bates Stamp Composer Demo.\n");

               using (UserInfoDialog dlg = new UserInfoDialog(info.ToString()))
               {
                  dlg.Text = @"Load Bates Stamp Information";
                  dlg.ShowDialog();
                  _showLoadBatesStampInfoDialog = dlg.ShowNextTime;
               }
            }

            using (OpenFileDialog openDilaog = new OpenFileDialog())
            {
               openDilaog.Filter = @"Xml Files | *.xml";
               openDilaog.Title = @"Load Bate Stamp";
               if (openDilaog.ShowDialog() == DialogResult.OK)
               {
                  //Set Composer rendering engine
                  AnnBatesStampComposer.RenderingEngine = new AnnWinFormsRenderingEngine();
                  //Load composer instance
                  AnnBatesStampComposer batesStampComposer = AnnBatesStampComposer.Load(openDilaog.FileName);

                  if (ActiveAnnotationsForm != null)
                  {
                     AnnAutomation automation = ActiveAnnotationsForm.Automation;
                     AnnContainer mainContainer = automation.Container;

                     //If there is bates stamp container added then remove it 
                     if (automation.Containers.Count == 2)
                        automation.Containers.RemoveAt(0);

                     //Create Bates stamp container, set its size and mapper
                     AnnContainer batesStampContainer = new AnnContainer();
                     batesStampContainer.Size = mainContainer.Size;
                     batesStampContainer.Mapper = mainContainer.Mapper.Clone();

                     //Apply BatesStamp to our container
                     batesStampComposer.TargetContainers.Add(batesStampContainer);

                     automation.Containers.Insert(0, batesStampContainer);

                     automation.Invalidate(LeadRectD.Empty);
                  }
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _menuItemCalibrate_Click(object sender, EventArgs e)
      {
         using (CalibrationDialog calibrationDialog = new CalibrationDialog(ActiveAnnotationsForm.Automation))
         {
            calibrationDialog.ShowDialog();
         }
      }

      private void _menuItemEditDuplicate_Click(object sender, EventArgs e)
      {
         AnnAutomation automation = ActiveAnnotationsForm.Automation;
         AnnObjectCollection newObjects = new AnnObjectCollection();

         var selectionObject = automation.CurrentEditObject as AnnSelectionObject;
         if (selectionObject != null)
         {
            // clone the objects into a new list

            foreach (AnnObject obj in selectionObject.SelectedObjects)
            {
               newObjects.Add(obj.Clone());
            }
         }
         else
         {
            newObjects.Add(automation.CurrentEditObject.Clone());
         }

         // if needed, one undo operation for this
         automation.BeginUndo();

         // Add them to the container through automation
         foreach (AnnObject obj in newObjects)
         {
            automation.ActiveContainer.Children.Add(obj);
         }

         automation.EndUndo();

         // and you can unselect the old objects
         automation.SelectObjects(null);

         // and select the new ones
         automation.SelectObjects(newObjects);
      }

   }
}
