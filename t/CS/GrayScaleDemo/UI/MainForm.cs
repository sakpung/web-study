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
using System.Collections.Generic;
using System.IO;
using System.Drawing.Drawing2D;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.WinForms;
using Leadtools.Demos;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing;
using Leadtools.Dicom;
using Leadtools.Drawing;
using Leadtools.Controls;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace GrayScaleDemo
{
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.MenuItem _menuItemPage;
      private System.Windows.Forms.MenuItem _menuItemPageFirst;
      private System.Windows.Forms.MenuItem _menuItemPagePrevious;
      private System.Windows.Forms.MenuItem _menuItemPageNext;
      private System.Windows.Forms.MenuItem _menuItemPageLast;
      private IContainer components;
      private MenuItem _menuItemEffect;
      private bool _isSegmentation = false;
      public RasterImage CopyedImage;
      private List<ViewerImages> _childPath;
      private string _directoryPath;
      private RawData _rawdataLoad;
      private RawData _rawdataSave;
      private RasterPaintProperties _paintProperties;

      public bool IsSegmentation
      {
         get { return _isSegmentation; }
         set { _isSegmentation = value; }
      }
       
      private MenuItem _menuItemImageRotate;
      private MenuItem _menuItemFileOpen;
      private MenuItem _menuItemFileSave;
      private MenuItem _menuItemLUTInvert;
      private MenuItem _menuItemWindow;
      private MenuItem _menuItemWindowCascade;
      private MenuItem _menuItemWindowTileHorizontally;
      private MenuItem _menuItemWindowTileVertically;
      private MenuItem _menuItemWindowArrangeIcons;
      private MenuItem _menuItemWindowCloseAll;
      private MenuItem _menuItemEdit;
      private MenuItem _menuItemRegion;
      private MenuItem _menuItemRegionRectangle;
      private MenuItem _menuItemRegionEllipse;
      private MenuItem _menuItemRegionFreehand;
      private MenuItem _menuItemRegionCancel;
      private MenuItem _menuItemColor;
      private MenuItem _menuItemColorHistogram;
      private MenuItem _menuItemFillCommand;
      private MenuItem _menuItemAddBorderToRegion;
      private MenuItem _menuItemSetPixelColor;
      private MenuItem menuItem9;
      private MenuItem _menuItemEffectsBlurAvg;
      private MenuItem menuItem10;
      private MenuItem _menuItemEffectNoiseMax;
      private MenuItem _menuItemEffectNoiseMin;
      private MenuItem _menuItemEffectNoiseMedian;
      private MenuItem menuItem11;
      private MenuItem _menuItemEffectsSharpenSharpen;
      private MenuItem _menuItemEffectsSharpenUnsharpen;
      private MenuItem menuItem12;
      private MenuItem _menuItemEffectsEdgesDetection;
      private MenuItem _menuItemEffectsEdgeContour;
      private MenuItem menuItem13;
      private MenuItem _menuItemImage;
      private MenuItem _menuItemEffectsSpecialGauissian;
      private MenuItem _menuItemImageFlipH;
      private MenuItem _menuItemImageFlipV;
      private MenuItem menuItem1;
      private MenuItem _menuItemColorAdjustContrast;
      private MenuItem _menuItemColorAdjustBrightness;
      private MenuItem menuItem3;
      private MenuItem _menuItemColorHistogramEqualizer;
      private MenuItem _menuItemColorHistogramAdaptiveContrast;
      private MenuItem _menuItemColorHistogramLocalEqualizer;
      private MenuItem _menuItemColorAdjustAutoLevel;
      private MenuItem _menuItemColorAdjustAutoContrast;
      private MenuItem _menuItemColorHistogramIntensity;
      private MenuItem menuItem4;
      private MenuItem _menuItemImageDeskew;
      private MenuItem _menuItemImageBlankPageDetection;
      private MenuItem _menuItemImageRotateFast90;
      private MenuItem _menuItemImageRotateFast180;
      private MenuItem _menuItemRotateFast270;
      private MenuItem _menuItemRotateCustom;
      private MenuItem _menuItemImageShear;
      private MenuItem _menuItemColorAutoBinarize;
      private MenuItem _menuItemColorIntensityDetect;
      private MenuItem _menuItemSegmentation;
      private MenuItem _menuItemSegmentationKMeans;
      private MenuItem _menuItemSegmentationOtsu;
      private MenuItem _menuItemSegmentationLambda;
      private MenuItem _menuItemSegmentationLevelSet;
      private MenuItem _menuItemSegmentationTDAFilter;
      private MenuItem _menuItemSegmentationSRADFilter;
      private MenuItem _menuItemDocument;
      private MenuItem _menuItemDocumentAutoCrop;
      private MenuItem _menuItemDocumentDespeckle;
      private MenuItem _menuItemDocumentErode;
      private MenuItem _menuItemDocumentDilate;
      private MenuItem _menuItemDocumentUnditherText;
      private MenuItem _menuItemDocumentFixBrokenLetters;
      private MenuItem _menuItemSegmentationInvPerspective;
      private MenuItem _menuItemSegmentationShrinkTool;
      private MenuItem _menuItemSegmentationGWireTool;
      private MenuItem _menuItemMedical;
      private MenuItem _menuItemMedicalAnisotropicDiffusion;
      private MenuItem _menuItemMedicalDigitalSubtract;
      private MenuItem _menuItemMedicalMeanShift;
      private MenuItem _menuItemMedicalMultiscaleEnhancement;
      private MenuItem _menuItemMedicalSelectData;
      private MenuItem _menuItemMedicalShiftData;
      private MenuItem _menuItemMedicalSigma;
      private MenuItem _menuItemMedicalTissueEqualize;
      private MenuItem _menuItemMedicalSkeleton;
      private MenuItem menuItem7;
      private MenuItem menuItem8;
      private MenuItem menuItem14;
      private MenuItem menuItem15;
      private MenuItem menuItem16;
      private MenuItem _menuItemRegionNone;
      private MenuItem _menuItemRegionRoundRectangle;
      private MenuItem _menuItemRegionAutoSegment;
      private MenuItem _menuItemRegionCombine;
      private MenuItem _menuItemWLManually;
      private MenuItem menuItem5;
      private MenuItem _menuItemImageDataInvert;
      private MenuItem _menuItemWL;
      private MenuItem _menuItemSensitivity;
      private MenuItem _menuItemView;
      private MenuItem _menuItemViewMagnifyGlass;
      private MenuItem _menuItemInterActiveNone;
      private MenuItem _menuItemCombine;
      private MenuItem _menuItemCopyImage;
      private MenuItem _menuItemImageInfo;
      private MenuItem _menuItemLineHistogram;
      private MenuItem _menuItemSeparation;
      private MenuItem _menuItemSepRGB;
      private MenuItem _menuItemSepCMYK;
      private MenuItem _menuItemSepHSV;
      private MenuItem _menuItemSepHLS;
      private MenuItem _menuItemSepCMY;
      private MenuItem _menuItemSepAlpha;
      private MenuItem _menuItemMerge;
      private MenuItem _menuItemSepYUV;
      private MenuItem _menuItemSepXYZ;
      private MenuItem _menuItemSepLAB;
      private MenuItem _menuItemSepYCRCB;
      private MenuItem _menuItemSepSCT;
      private MenuItem _menuItemMagGlassSettings;
      private MenuItem _menuItemInteractive;
      private MenuItem _menuItemSize;
      private MenuItem _menuItemSizeFit;
      private MenuItem _menuItemSizeNormal;
      private MenuItem _menuItemInterActivePan;
      private MenuItem _menuItemUndo;
      private MenuItem _menuItemRedo;
      private MenuItem menuItem6;
      private MenuItem _menuItemCLAHE;
      private MenuItem menuItem17;
      private MenuItem menuItem20;
      private MenuItem _menuItemCopy;
      private MenuItem _menuItemPaste;
      private MenuItem _menuItemOpenRaw;
      private MenuItem _menuItemSaveRaw;
      private MenuItem menuItem21;
      private MenuItem _menuItemSegmentationWatershed;
      private MenuItem _menuItemDeskewToolStrip;
      private MenuItem _menuItemEffectFlip;
      private MenuItem _menuItemColorGrayScale;
      private MenuItem _miBackgroundRemoval;
      private MenuItem _menuItemColorResolution;

      public MainForm()
      {
         InitializeComponent();
      }

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
      private void InitializeComponent()
      {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._mmMain = new System.Windows.Forms.MainMenu(this.components);
            this._miFile = new System.Windows.Forms.MenuItem();
            this._menuItemFileOpen = new System.Windows.Forms.MenuItem();
            this._menuItemFileSave = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this._menuItemOpenRaw = new System.Windows.Forms.MenuItem();
            this._menuItemSaveRaw = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this._miFileExit = new System.Windows.Forms.MenuItem();
            this._menuItemEdit = new System.Windows.Forms.MenuItem();
            this._menuItemUndo = new System.Windows.Forms.MenuItem();
            this._menuItemRedo = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this._menuItemRegion = new System.Windows.Forms.MenuItem();
            this._menuItemRegionNone = new System.Windows.Forms.MenuItem();
            this._menuItemRegionRectangle = new System.Windows.Forms.MenuItem();
            this._menuItemRegionRoundRectangle = new System.Windows.Forms.MenuItem();
            this._menuItemRegionEllipse = new System.Windows.Forms.MenuItem();
            this._menuItemRegionFreehand = new System.Windows.Forms.MenuItem();
            this._menuItemRegionAutoSegment = new System.Windows.Forms.MenuItem();
            this._menuItemAddBorderToRegion = new System.Windows.Forms.MenuItem();
            this._menuItemRegionCombine = new System.Windows.Forms.MenuItem();
            this._menuItemRegionCancel = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this._menuItemMagGlassSettings = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this._menuItemCopy = new System.Windows.Forms.MenuItem();
            this._menuItemPaste = new System.Windows.Forms.MenuItem();
            this._menuItemPage = new System.Windows.Forms.MenuItem();
            this._menuItemPageFirst = new System.Windows.Forms.MenuItem();
            this._menuItemPagePrevious = new System.Windows.Forms.MenuItem();
            this._menuItemPageNext = new System.Windows.Forms.MenuItem();
            this._menuItemPageLast = new System.Windows.Forms.MenuItem();
            this._menuItemView = new System.Windows.Forms.MenuItem();
            this._menuItemWL = new System.Windows.Forms.MenuItem();
            this._menuItemWLManually = new System.Windows.Forms.MenuItem();
            this._menuItemSensitivity = new System.Windows.Forms.MenuItem();
            this._menuItemInteractive = new System.Windows.Forms.MenuItem();
            this._menuItemInterActiveNone = new System.Windows.Forms.MenuItem();
            this._menuItemViewMagnifyGlass = new System.Windows.Forms.MenuItem();
            this._menuItemInterActivePan = new System.Windows.Forms.MenuItem();
            this._menuItemSize = new System.Windows.Forms.MenuItem();
            this._menuItemSizeNormal = new System.Windows.Forms.MenuItem();
            this._menuItemSizeFit = new System.Windows.Forms.MenuItem();
            this._menuItemImage = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this._menuItemColorHistogram = new System.Windows.Forms.MenuItem();
            this._menuItemImageInfo = new System.Windows.Forms.MenuItem();
            this._menuItemLineHistogram = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this._menuItemEffectFlip = new System.Windows.Forms.MenuItem();
            this._menuItemImageFlipH = new System.Windows.Forms.MenuItem();
            this._menuItemImageFlipV = new System.Windows.Forms.MenuItem();
            this._menuItemImageDeskew = new System.Windows.Forms.MenuItem();
            this._menuItemImageShear = new System.Windows.Forms.MenuItem();
            this._menuItemImageRotate = new System.Windows.Forms.MenuItem();
            this._menuItemImageRotateFast90 = new System.Windows.Forms.MenuItem();
            this._menuItemImageRotateFast180 = new System.Windows.Forms.MenuItem();
            this._menuItemRotateFast270 = new System.Windows.Forms.MenuItem();
            this._menuItemRotateCustom = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this._menuItemImageBlankPageDetection = new System.Windows.Forms.MenuItem();
            this._menuItemCombine = new System.Windows.Forms.MenuItem();
            this._menuItemCopyImage = new System.Windows.Forms.MenuItem();
            this._menuItemEffect = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this._menuItemEffectsBlurAvg = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this._menuItemEffectsEdgesDetection = new System.Windows.Forms.MenuItem();
            this._menuItemEffectsEdgeContour = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this._menuItemEffectNoiseMax = new System.Windows.Forms.MenuItem();
            this._menuItemEffectNoiseMin = new System.Windows.Forms.MenuItem();
            this._menuItemEffectNoiseMedian = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this._menuItemEffectsSharpenSharpen = new System.Windows.Forms.MenuItem();
            this._menuItemEffectsSharpenUnsharpen = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this._menuItemEffectsSpecialGauissian = new System.Windows.Forms.MenuItem();
            this._menuItemColor = new System.Windows.Forms.MenuItem();
            this._menuItemColorGrayScale = new System.Windows.Forms.MenuItem();
            this._menuItemColorResolution = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this._menuItemLUTInvert = new System.Windows.Forms.MenuItem();
            this._menuItemImageDataInvert = new System.Windows.Forms.MenuItem();
            this._menuItemFillCommand = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this._menuItemColorAdjustAutoLevel = new System.Windows.Forms.MenuItem();
            this._menuItemColorAdjustAutoContrast = new System.Windows.Forms.MenuItem();
            this._menuItemColorHistogramIntensity = new System.Windows.Forms.MenuItem();
            this._menuItemColorAdjustContrast = new System.Windows.Forms.MenuItem();
            this._menuItemColorAdjustBrightness = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this._menuItemColorHistogramEqualizer = new System.Windows.Forms.MenuItem();
            this._menuItemColorHistogramAdaptiveContrast = new System.Windows.Forms.MenuItem();
            this._menuItemColorHistogramLocalEqualizer = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this._menuItemColorAutoBinarize = new System.Windows.Forms.MenuItem();
            this._menuItemColorIntensityDetect = new System.Windows.Forms.MenuItem();
            this._menuItemSetPixelColor = new System.Windows.Forms.MenuItem();
            this._menuItemSeparation = new System.Windows.Forms.MenuItem();
            this._menuItemSepRGB = new System.Windows.Forms.MenuItem();
            this._menuItemSepCMYK = new System.Windows.Forms.MenuItem();
            this._menuItemSepHSV = new System.Windows.Forms.MenuItem();
            this._menuItemSepHLS = new System.Windows.Forms.MenuItem();
            this._menuItemSepCMY = new System.Windows.Forms.MenuItem();
            this._menuItemSepAlpha = new System.Windows.Forms.MenuItem();
            this._menuItemSepYUV = new System.Windows.Forms.MenuItem();
            this._menuItemSepXYZ = new System.Windows.Forms.MenuItem();
            this._menuItemSepLAB = new System.Windows.Forms.MenuItem();
            this._menuItemSepYCRCB = new System.Windows.Forms.MenuItem();
            this._menuItemSepSCT = new System.Windows.Forms.MenuItem();
            this._menuItemMerge = new System.Windows.Forms.MenuItem();
            this._menuItemMedical = new System.Windows.Forms.MenuItem();
            this._menuItemMedicalAnisotropicDiffusion = new System.Windows.Forms.MenuItem();
            this._menuItemMedicalDigitalSubtract = new System.Windows.Forms.MenuItem();
            this._menuItemMedicalMeanShift = new System.Windows.Forms.MenuItem();
            this._menuItemMedicalMultiscaleEnhancement = new System.Windows.Forms.MenuItem();
            this._menuItemMedicalSelectData = new System.Windows.Forms.MenuItem();
            this._menuItemMedicalShiftData = new System.Windows.Forms.MenuItem();
            this._menuItemMedicalSigma = new System.Windows.Forms.MenuItem();
            this._menuItemMedicalTissueEqualize = new System.Windows.Forms.MenuItem();
            this._menuItemMedicalSkeleton = new System.Windows.Forms.MenuItem();
            this._menuItemCLAHE = new System.Windows.Forms.MenuItem();
            this._miBackgroundRemoval = new System.Windows.Forms.MenuItem();
            this._menuItemSegmentation = new System.Windows.Forms.MenuItem();
            this._menuItemSegmentationKMeans = new System.Windows.Forms.MenuItem();
            this._menuItemSegmentationOtsu = new System.Windows.Forms.MenuItem();
            this._menuItemSegmentationLevelSet = new System.Windows.Forms.MenuItem();
            this._menuItemSegmentationLambda = new System.Windows.Forms.MenuItem();
            this._menuItemSegmentationGWireTool = new System.Windows.Forms.MenuItem();
            this._menuItemSegmentationInvPerspective = new System.Windows.Forms.MenuItem();
            this._menuItemSegmentationShrinkTool = new System.Windows.Forms.MenuItem();
            this._menuItemSegmentationTDAFilter = new System.Windows.Forms.MenuItem();
            this._menuItemSegmentationSRADFilter = new System.Windows.Forms.MenuItem();
            this._menuItemSegmentationWatershed = new System.Windows.Forms.MenuItem();
            this._menuItemDeskewToolStrip = new System.Windows.Forms.MenuItem();
            this._menuItemDocument = new System.Windows.Forms.MenuItem();
            this._menuItemDocumentAutoCrop = new System.Windows.Forms.MenuItem();
            this._menuItemDocumentDespeckle = new System.Windows.Forms.MenuItem();
            this._menuItemDocumentErode = new System.Windows.Forms.MenuItem();
            this._menuItemDocumentDilate = new System.Windows.Forms.MenuItem();
            this._menuItemDocumentUnditherText = new System.Windows.Forms.MenuItem();
            this._menuItemDocumentFixBrokenLetters = new System.Windows.Forms.MenuItem();
            this._menuItemWindow = new System.Windows.Forms.MenuItem();
            this._menuItemWindowCascade = new System.Windows.Forms.MenuItem();
            this._menuItemWindowTileHorizontally = new System.Windows.Forms.MenuItem();
            this._menuItemWindowTileVertically = new System.Windows.Forms.MenuItem();
            this._menuItemWindowArrangeIcons = new System.Windows.Forms.MenuItem();
            this._menuItemWindowCloseAll = new System.Windows.Forms.MenuItem();
            this._miHelp = new System.Windows.Forms.MenuItem();
            this._miHelpAbout = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // _mmMain
            // 
            this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._menuItemEdit,
            this._menuItemPage,
            this._menuItemView,
            this._menuItemImage,
            this._menuItemEffect,
            this._menuItemColor,
            this._menuItemMedical,
            this._menuItemSegmentation,
            this._menuItemDocument,
            this._menuItemWindow,
            this._miHelp});
            // 
            // _miFile
            // 
            this._miFile.Index = 0;
            this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFileOpen,
            this._menuItemFileSave,
            this.menuItem7,
            this._menuItemOpenRaw,
            this._menuItemSaveRaw,
            this.menuItem21,
            this._miFileExit});
            this._miFile.Text = "&File";
            // 
            // _menuItemFileOpen
            // 
            this._menuItemFileOpen.Index = 0;
            this._menuItemFileOpen.Text = "&Open";
            this._menuItemFileOpen.Click += new System.EventHandler(this.open_Click);
            // 
            // _menuItemFileSave
            // 
            this._menuItemFileSave.Index = 1;
            this._menuItemFileSave.Text = "&Save";
            this._menuItemFileSave.Click += new System.EventHandler(this.save_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.Text = "-";
            // 
            // _menuItemOpenRaw
            // 
            this._menuItemOpenRaw.Index = 3;
            this._menuItemOpenRaw.Text = "Open Raw";
            this._menuItemOpenRaw.Click += new System.EventHandler(this._menuItemOpenRaw_Click);
            // 
            // _menuItemSaveRaw
            // 
            this._menuItemSaveRaw.Index = 4;
            this._menuItemSaveRaw.Text = "Save Raw";
            this._menuItemSaveRaw.Click += new System.EventHandler(this._menuItemSaveRaw_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 5;
            this.menuItem21.Text = "-";
            // 
            // _miFileExit
            // 
            this._miFileExit.Index = 6;
            this._miFileExit.Text = "E&xit";
            this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
            // 
            // _menuItemEdit
            // 
            this._menuItemEdit.Index = 1;
            this._menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemUndo,
            this._menuItemRedo,
            this.menuItem6,
            this._menuItemRegion,
            this._menuItemRegionCombine,
            this._menuItemRegionCancel,
            this.menuItem17,
            this._menuItemMagGlassSettings,
            this.menuItem20,
            this._menuItemCopy,
            this._menuItemPaste});
            this._menuItemEdit.Text = "&Edit";
            this._menuItemEdit.Popup += new System.EventHandler(this._menuItemEdit_Popup);
            // 
            // _menuItemUndo
            // 
            this._menuItemUndo.Index = 0;
            this._menuItemUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this._menuItemUndo.Text = "Undo";
            this._menuItemUndo.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemRedo
            // 
            this._menuItemRedo.Index = 1;
            this._menuItemRedo.Shortcut = System.Windows.Forms.Shortcut.CtrlY;
            this._menuItemRedo.Text = "Redo";
            this._menuItemRedo.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "-";
            // 
            // _menuItemRegion
            // 
            this._menuItemRegion.Index = 3;
            this._menuItemRegion.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemRegionNone,
            this._menuItemRegionRectangle,
            this._menuItemRegionRoundRectangle,
            this._menuItemRegionEllipse,
            this._menuItemRegionFreehand,
            this._menuItemRegionAutoSegment,
            this._menuItemAddBorderToRegion});
            this._menuItemRegion.Text = "&Region";
            // 
            // _menuItemRegionNone
            // 
            this._menuItemRegionNone.Index = 0;
            this._menuItemRegionNone.Text = "None";
            this._menuItemRegionNone.Click += new System.EventHandler(this.Region_Click);
            // 
            // _menuItemRegionRectangle
            // 
            this._menuItemRegionRectangle.Index = 1;
            this._menuItemRegionRectangle.Text = "Rectangle";
            this._menuItemRegionRectangle.Click += new System.EventHandler(this.Region_Click);
            // 
            // _menuItemRegionRoundRectangle
            // 
            this._menuItemRegionRoundRectangle.Index = 2;
            this._menuItemRegionRoundRectangle.Text = "Round Rectangle";
            this._menuItemRegionRoundRectangle.Click += new System.EventHandler(this.Region_Click);
            // 
            // _menuItemRegionEllipse
            // 
            this._menuItemRegionEllipse.Index = 3;
            this._menuItemRegionEllipse.Text = "Ellipse";
            this._menuItemRegionEllipse.Click += new System.EventHandler(this.Region_Click);
            // 
            // _menuItemRegionFreehand
            // 
            this._menuItemRegionFreehand.Index = 4;
            this._menuItemRegionFreehand.Text = "Free Hand";
            this._menuItemRegionFreehand.Click += new System.EventHandler(this.Region_Click);
            // 
            // _menuItemRegionAutoSegment
            // 
            this._menuItemRegionAutoSegment.Index = 5;
            this._menuItemRegionAutoSegment.Text = "Auto Segment";
            this._menuItemRegionAutoSegment.Click += new System.EventHandler(this.Region_Click);
            // 
            // _menuItemAddBorderToRegion
            // 
            this._menuItemAddBorderToRegion.Index = 6;
            this._menuItemAddBorderToRegion.Text = "Border";
            this._menuItemAddBorderToRegion.Click += new System.EventHandler(this.Region_Click);
            // 
            // _menuItemRegionCombine
            // 
            this._menuItemRegionCombine.Index = 4;
            this._menuItemRegionCombine.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this._menuItemRegionCombine.Text = "Combine Region";
            this._menuItemRegionCombine.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemRegionCancel
            // 
            this._menuItemRegionCancel.Index = 5;
            this._menuItemRegionCancel.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this._menuItemRegionCancel.Text = "Cancel Region";
            this._menuItemRegionCancel.Visible = false;
            this._menuItemRegionCancel.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 6;
            this.menuItem17.Text = "-";
            // 
            // _menuItemMagGlassSettings
            // 
            this._menuItemMagGlassSettings.Index = 7;
            this._menuItemMagGlassSettings.Text = "Magnify Glass Settings ...";
            this._menuItemMagGlassSettings.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 8;
            this.menuItem20.Text = "-";
            // 
            // _menuItemCopy
            // 
            this._menuItemCopy.Index = 9;
            this._menuItemCopy.Text = "Copy";
            this._menuItemCopy.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemPaste
            // 
            this._menuItemPaste.Index = 10;
            this._menuItemPaste.Text = "Paste";
            this._menuItemPaste.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemPage
            // 
            this._menuItemPage.Index = 2;
            this._menuItemPage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemPageFirst,
            this._menuItemPagePrevious,
            this._menuItemPageNext,
            this._menuItemPageLast});
            this._menuItemPage.Text = "&Page";
            this._menuItemPage.Visible = false;
            // 
            // _menuItemPageFirst
            // 
            this._menuItemPageFirst.Index = 0;
            this._menuItemPageFirst.RadioCheck = true;
            this._menuItemPageFirst.Text = "&First";
            this._menuItemPageFirst.Click += new System.EventHandler(this._menuItemPage_Click);
            // 
            // _menuItemPagePrevious
            // 
            this._menuItemPagePrevious.Index = 1;
            this._menuItemPagePrevious.RadioCheck = true;
            this._menuItemPagePrevious.Text = "&Previous";
            this._menuItemPagePrevious.Click += new System.EventHandler(this._menuItemPage_Click);
            // 
            // _menuItemPageNext
            // 
            this._menuItemPageNext.Index = 2;
            this._menuItemPageNext.RadioCheck = true;
            this._menuItemPageNext.Text = "&Next";
            this._menuItemPageNext.Click += new System.EventHandler(this._menuItemPage_Click);
            // 
            // _menuItemPageLast
            // 
            this._menuItemPageLast.Index = 3;
            this._menuItemPageLast.RadioCheck = true;
            this._menuItemPageLast.Text = "&Last";
            this._menuItemPageLast.Click += new System.EventHandler(this._menuItemPage_Click);
            // 
            // _menuItemView
            // 
            this._menuItemView.Index = 3;
            this._menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemWL,
            this._menuItemInteractive,
            this._menuItemSize});
            this._menuItemView.Text = "View";
            this._menuItemView.Visible = false;
            // 
            // _menuItemWL
            // 
            this._menuItemWL.Index = 0;
            this._menuItemWL.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemWLManually,
            this._menuItemSensitivity});
            this._menuItemWL.Text = "Window Level";
            // 
            // _menuItemWLManually
            // 
            this._menuItemWLManually.Index = 0;
            this._menuItemWLManually.Text = "Set W \\ L Manually";
            this._menuItemWLManually.Click += new System.EventHandler(this._menuItem_WL_Click);
            // 
            // _menuItemSensitivity
            // 
            this._menuItemSensitivity.Index = 1;
            this._menuItemSensitivity.Text = "Sensitivity ";
            this._menuItemSensitivity.Click += new System.EventHandler(this._menuItemSensitivity_Click);
            // 
            // _menuItemInteractive
            // 
            this._menuItemInteractive.Index = 1;
            this._menuItemInteractive.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemInterActiveNone,
            this._menuItemViewMagnifyGlass,
            this._menuItemInterActivePan});
            this._menuItemInteractive.Text = "Interactive";
            // 
            // _menuItemInterActiveNone
            // 
            this._menuItemInterActiveNone.Index = 0;
            this._menuItemInterActiveNone.Text = "None";
            this._menuItemInterActiveNone.Click += new System.EventHandler(this.interactiveMode_Click);
            // 
            // _menuItemViewMagnifyGlass
            // 
            this._menuItemViewMagnifyGlass.Index = 1;
            this._menuItemViewMagnifyGlass.Text = "&Magnify Glass";
            this._menuItemViewMagnifyGlass.Click += new System.EventHandler(this.interactiveMode_Click);
            // 
            // _menuItemInterActivePan
            // 
            this._menuItemInterActivePan.Index = 2;
            this._menuItemInterActivePan.Text = "Pan";
            this._menuItemInterActivePan.Click += new System.EventHandler(this.interactiveMode_Click);
            // 
            // _menuItemSize
            // 
            this._menuItemSize.Index = 2;
            this._menuItemSize.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemSizeNormal,
            this._menuItemSizeFit});
            this._menuItemSize.Text = "Size Mode";
            // 
            // _menuItemSizeNormal
            // 
            this._menuItemSizeNormal.Checked = true;
            this._menuItemSizeNormal.Index = 0;
            this._menuItemSizeNormal.Text = "Normal";
            this._menuItemSizeNormal.Click += new System.EventHandler(this._menuItemSize_Click);
            // 
            // _menuItemSizeFit
            // 
            this._menuItemSizeFit.Index = 1;
            this._menuItemSizeFit.Text = "Fit";
            this._menuItemSizeFit.Click += new System.EventHandler(this._menuItemSize_Click);
            // 
            // _menuItemImage
            // 
            this._menuItemImage.Index = 4;
            this._menuItemImage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4,
            this.menuItem15,
            this._menuItemEffectFlip,
            this._menuItemImageDeskew,
            this._menuItemImageShear,
            this._menuItemImageRotate,
            this.menuItem16,
            this._menuItemImageBlankPageDetection,
            this._menuItemCombine,
            this._menuItemCopyImage});
            this._menuItemImage.Text = "Image";
            this._menuItemImage.Visible = false;
            this._menuItemImage.Popup += new System.EventHandler(this._menuItemImage_Popup);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemColorHistogram,
            this._menuItemImageInfo,
            this._menuItemLineHistogram});
            this.menuItem4.Text = "Analysis";
            // 
            // _menuItemColorHistogram
            // 
            this._menuItemColorHistogram.Index = 0;
            this._menuItemColorHistogram.Text = "Histogram ...";
            this._menuItemColorHistogram.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemImageInfo
            // 
            this._menuItemImageInfo.Index = 1;
            this._menuItemImageInfo.Text = "Image Info ...";
            this._menuItemImageInfo.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemLineHistogram
            // 
            this._menuItemLineHistogram.Index = 2;
            this._menuItemLineHistogram.Text = "Line Histogram ...";
            this._menuItemLineHistogram.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 1;
            this.menuItem15.Text = "-";
            // 
            // _menuItemEffectFlip
            // 
            this._menuItemEffectFlip.Index = 2;
            this._menuItemEffectFlip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemImageFlipH,
            this._menuItemImageFlipV});
            this._menuItemEffectFlip.Text = "&Flip";
            // 
            // _menuItemImageFlipH
            // 
            this._menuItemImageFlipH.Index = 0;
            this._menuItemImageFlipH.Text = "Horizontal";
            this._menuItemImageFlipH.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemImageFlipV
            // 
            this._menuItemImageFlipV.Index = 1;
            this._menuItemImageFlipV.Text = "Vertical";
            this._menuItemImageFlipV.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemImageDeskew
            // 
            this._menuItemImageDeskew.Index = 3;
            this._menuItemImageDeskew.Text = "Deskew";
            this._menuItemImageDeskew.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemImageShear
            // 
            this._menuItemImageShear.Index = 4;
            this._menuItemImageShear.Text = "Shear";
            this._menuItemImageShear.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemImageRotate
            // 
            this._menuItemImageRotate.Index = 5;
            this._menuItemImageRotate.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemImageRotateFast90,
            this._menuItemImageRotateFast180,
            this._menuItemRotateFast270,
            this._menuItemRotateCustom});
            this._menuItemImageRotate.Text = "&Rotate";
            // 
            // _menuItemImageRotateFast90
            // 
            this._menuItemImageRotateFast90.Index = 0;
            this._menuItemImageRotateFast90.Text = "9&0° clockwise";
            this._menuItemImageRotateFast90.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemImageRotateFast180
            // 
            this._menuItemImageRotateFast180.Index = 1;
            this._menuItemImageRotateFast180.Text = "1&80° clockwise";
            this._menuItemImageRotateFast180.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemRotateFast270
            // 
            this._menuItemRotateFast270.Index = 2;
            this._menuItemRotateFast270.Text = "2&70° clockwise";
            this._menuItemRotateFast270.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemRotateCustom
            // 
            this._menuItemRotateCustom.Index = 3;
            this._menuItemRotateCustom.Text = "&Custom...";
            this._menuItemRotateCustom.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 6;
            this.menuItem16.Text = "-";
            // 
            // _menuItemImageBlankPageDetection
            // 
            this._menuItemImageBlankPageDetection.Index = 7;
            this._menuItemImageBlankPageDetection.Text = "Blank Page Detection";
            this._menuItemImageBlankPageDetection.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemCombine
            // 
            this._menuItemCombine.Index = 8;
            this._menuItemCombine.Text = "Combine ...";
            this._menuItemCombine.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemCopyImage
            // 
            this._menuItemCopyImage.Index = 9;
            this._menuItemCopyImage.Text = "Copy ";
            this._menuItemCopyImage.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemEffect
            // 
            this._menuItemEffect.Index = 5;
            this._menuItemEffect.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem9,
            this.menuItem12,
            this.menuItem10,
            this.menuItem11,
            this.menuItem13});
            this._menuItemEffect.Text = "Effec&ts";
            this._menuItemEffect.Visible = false;
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 0;
            this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemEffectsBlurAvg});
            this.menuItem9.Text = "Blur ";
            // 
            // _menuItemEffectsBlurAvg
            // 
            this._menuItemEffectsBlurAvg.Index = 0;
            this._menuItemEffectsBlurAvg.Text = "Average";
            this._menuItemEffectsBlurAvg.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 1;
            this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemEffectsEdgesDetection,
            this._menuItemEffectsEdgeContour});
            this.menuItem12.Text = "Edge";
            // 
            // _menuItemEffectsEdgesDetection
            // 
            this._menuItemEffectsEdgesDetection.Index = 0;
            this._menuItemEffectsEdgesDetection.Text = "Detection";
            this._menuItemEffectsEdgesDetection.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemEffectsEdgeContour
            // 
            this._menuItemEffectsEdgeContour.Index = 1;
            this._menuItemEffectsEdgeContour.Text = "Contour";
            this._menuItemEffectsEdgeContour.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 2;
            this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemEffectNoiseMax,
            this._menuItemEffectNoiseMin,
            this._menuItemEffectNoiseMedian});
            this.menuItem10.Text = "Noise ";
            // 
            // _menuItemEffectNoiseMax
            // 
            this._menuItemEffectNoiseMax.Index = 0;
            this._menuItemEffectNoiseMax.Text = "Maximum";
            this._menuItemEffectNoiseMax.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemEffectNoiseMin
            // 
            this._menuItemEffectNoiseMin.Index = 1;
            this._menuItemEffectNoiseMin.Text = "Minimum";
            this._menuItemEffectNoiseMin.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemEffectNoiseMedian
            // 
            this._menuItemEffectNoiseMedian.Index = 2;
            this._menuItemEffectNoiseMedian.Text = "Median";
            this._menuItemEffectNoiseMedian.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 3;
            this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemEffectsSharpenSharpen,
            this._menuItemEffectsSharpenUnsharpen});
            this.menuItem11.Text = "Sharpen";
            // 
            // _menuItemEffectsSharpenSharpen
            // 
            this._menuItemEffectsSharpenSharpen.Index = 0;
            this._menuItemEffectsSharpenSharpen.Text = "Sharpen";
            this._menuItemEffectsSharpenSharpen.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemEffectsSharpenUnsharpen
            // 
            this._menuItemEffectsSharpenUnsharpen.Index = 1;
            this._menuItemEffectsSharpenUnsharpen.Text = "Unsharpen";
            this._menuItemEffectsSharpenUnsharpen.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 4;
            this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemEffectsSpecialGauissian});
            this.menuItem13.Text = "Special";
            // 
            // _menuItemEffectsSpecialGauissian
            // 
            this._menuItemEffectsSpecialGauissian.Index = 0;
            this._menuItemEffectsSpecialGauissian.Text = "Gauissian";
            this._menuItemEffectsSpecialGauissian.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemColor
            // 
            this._menuItemColor.Index = 6;
            this._menuItemColor.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemColorGrayScale,
            this._menuItemColorResolution,
            this.menuItem5,
            this._menuItemFillCommand,
            this.menuItem8,
            this.menuItem1,
            this.menuItem3,
            this.menuItem14,
            this._menuItemSetPixelColor,
            this._menuItemSeparation,
            this._menuItemMerge});
            this._menuItemColor.Text = "&Color";
            this._menuItemColor.Visible = false;
            // 
            // _menuItemColorGrayScale
            // 
            this._menuItemColorGrayScale.Index = 0;
            this._menuItemColorGrayScale.Text = "Gray Scale...";
            this._menuItemColorGrayScale.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemColorResolution
            // 
            this._menuItemColorResolution.Index = 1;
            this._menuItemColorResolution.Text = "Color Resolution...";
            this._menuItemColorResolution.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemLUTInvert,
            this._menuItemImageDataInvert});
            this.menuItem5.Text = "Invert";
            // 
            // _menuItemLUTInvert
            // 
            this._menuItemLUTInvert.Index = 0;
            this._menuItemLUTInvert.Text = "LUT invert ";
            this._menuItemLUTInvert.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemImageDataInvert
            // 
            this._menuItemImageDataInvert.Index = 1;
            this._menuItemImageDataInvert.Text = "Image data invert";
            this._menuItemImageDataInvert.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemFillCommand
            // 
            this._menuItemFillCommand.Index = 3;
            this._menuItemFillCommand.Text = "Fill";
            this._menuItemFillCommand.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 4;
            this.menuItem8.Text = "-";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 5;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemColorAdjustAutoLevel,
            this._menuItemColorAdjustAutoContrast,
            this._menuItemColorHistogramIntensity,
            this._menuItemColorAdjustContrast,
            this._menuItemColorAdjustBrightness});
            this.menuItem1.Text = "Adjust";
            // 
            // _menuItemColorAdjustAutoLevel
            // 
            this._menuItemColorAdjustAutoLevel.Index = 0;
            this._menuItemColorAdjustAutoLevel.Text = "Auto Level";
            this._menuItemColorAdjustAutoLevel.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemColorAdjustAutoContrast
            // 
            this._menuItemColorAdjustAutoContrast.Index = 1;
            this._menuItemColorAdjustAutoContrast.Text = "Auto Contrast";
            this._menuItemColorAdjustAutoContrast.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemColorHistogramIntensity
            // 
            this._menuItemColorHistogramIntensity.Index = 2;
            this._menuItemColorHistogramIntensity.Text = "Auto Intensity";
            this._menuItemColorHistogramIntensity.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemColorAdjustContrast
            // 
            this._menuItemColorAdjustContrast.Index = 3;
            this._menuItemColorAdjustContrast.Text = "Contrast";
            this._menuItemColorAdjustContrast.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemColorAdjustBrightness
            // 
            this._menuItemColorAdjustBrightness.Index = 4;
            this._menuItemColorAdjustBrightness.Text = "Brightness";
            this._menuItemColorAdjustBrightness.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 6;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemColorHistogramEqualizer,
            this._menuItemColorHistogramAdaptiveContrast,
            this._menuItemColorHistogramLocalEqualizer});
            this.menuItem3.Text = "Histogram";
            // 
            // _menuItemColorHistogramEqualizer
            // 
            this._menuItemColorHistogramEqualizer.Index = 0;
            this._menuItemColorHistogramEqualizer.Text = "Equalizer";
            this._menuItemColorHistogramEqualizer.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemColorHistogramAdaptiveContrast
            // 
            this._menuItemColorHistogramAdaptiveContrast.Index = 1;
            this._menuItemColorHistogramAdaptiveContrast.Text = "Adaptive Contrast";
            this._menuItemColorHistogramAdaptiveContrast.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemColorHistogramLocalEqualizer
            // 
            this._menuItemColorHistogramLocalEqualizer.Index = 2;
            this._menuItemColorHistogramLocalEqualizer.Text = "Local Equalizer";
            this._menuItemColorHistogramLocalEqualizer.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 7;
            this.menuItem14.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemColorAutoBinarize,
            this._menuItemColorIntensityDetect});
            this.menuItem14.Text = "Threshold";
            // 
            // _menuItemColorAutoBinarize
            // 
            this._menuItemColorAutoBinarize.Index = 0;
            this._menuItemColorAutoBinarize.Text = "Auto Binarize";
            this._menuItemColorAutoBinarize.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemColorIntensityDetect
            // 
            this._menuItemColorIntensityDetect.Index = 1;
            this._menuItemColorIntensityDetect.Text = "Intensity Detect";
            this._menuItemColorIntensityDetect.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemSetPixelColor
            // 
            this._menuItemSetPixelColor.Index = 8;
            this._menuItemSetPixelColor.Text = "SetPixelColor";
            this._menuItemSetPixelColor.Click += new System.EventHandler(this._menuItemSetPixelColor_Click);
            // 
            // _menuItemSeparation
            // 
            this._menuItemSeparation.Index = 9;
            this._menuItemSeparation.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemSepRGB,
            this._menuItemSepCMYK,
            this._menuItemSepHSV,
            this._menuItemSepHLS,
            this._menuItemSepCMY,
            this._menuItemSepAlpha,
            this._menuItemSepYUV,
            this._menuItemSepXYZ,
            this._menuItemSepLAB,
            this._menuItemSepYCRCB,
            this._menuItemSepSCT});
            this._menuItemSeparation.Text = "S&eparation";
            // 
            // _menuItemSepRGB
            // 
            this._menuItemSepRGB.Index = 0;
            this._menuItemSepRGB.Text = "&RGB";
            this._menuItemSepRGB.Click += new System.EventHandler(this._menuItemSep_Click);
            // 
            // _menuItemSepCMYK
            // 
            this._menuItemSepCMYK.Index = 1;
            this._menuItemSepCMYK.Text = "CMY&K";
            this._menuItemSepCMYK.Click += new System.EventHandler(this._menuItemSep_Click);
            // 
            // _menuItemSepHSV
            // 
            this._menuItemSepHSV.Index = 2;
            this._menuItemSepHSV.Text = "HS&V";
            this._menuItemSepHSV.Click += new System.EventHandler(this._menuItemSep_Click);
            // 
            // _menuItemSepHLS
            // 
            this._menuItemSepHLS.Index = 3;
            this._menuItemSepHLS.Text = "&HLS";
            this._menuItemSepHLS.Click += new System.EventHandler(this._menuItemSep_Click);
            // 
            // _menuItemSepCMY
            // 
            this._menuItemSepCMY.Index = 4;
            this._menuItemSepCMY.Text = "&CMY";
            this._menuItemSepCMY.Click += new System.EventHandler(this._menuItemSep_Click);
            // 
            // _menuItemSepAlpha
            // 
            this._menuItemSepAlpha.Index = 5;
            this._menuItemSepAlpha.Text = "&Alpha";
            this._menuItemSepAlpha.Click += new System.EventHandler(this._menuItemSep_Click);
            // 
            // _menuItemSepYUV
            // 
            this._menuItemSepYUV.Index = 6;
            this._menuItemSepYUV.Text = "&YUV";
            this._menuItemSepYUV.Click += new System.EventHandler(this._menuItemSep_Click);
            // 
            // _menuItemSepXYZ
            // 
            this._menuItemSepXYZ.Index = 7;
            this._menuItemSepXYZ.Text = "&XYZ";
            this._menuItemSepXYZ.Click += new System.EventHandler(this._menuItemSep_Click);
            // 
            // _menuItemSepLAB
            // 
            this._menuItemSepLAB.Index = 8;
            this._menuItemSepLAB.Text = "&LAB";
            this._menuItemSepLAB.Click += new System.EventHandler(this._menuItemSep_Click);
            // 
            // _menuItemSepYCRCB
            // 
            this._menuItemSepYCRCB.Index = 9;
            this._menuItemSepYCRCB.Text = "YCRC&B";
            this._menuItemSepYCRCB.Click += new System.EventHandler(this._menuItemSep_Click);
            // 
            // _menuItemSepSCT
            // 
            this._menuItemSepSCT.Index = 10;
            this._menuItemSepSCT.Text = "&SCT";
            this._menuItemSepSCT.Click += new System.EventHandler(this._menuItemSep_Click);
            // 
            // _menuItemMerge
            // 
            this._menuItemMerge.Index = 10;
            this._menuItemMerge.Text = "Merge ...";
            this._menuItemMerge.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemMedical
            // 
            this._menuItemMedical.Index = 7;
            this._menuItemMedical.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemMedicalAnisotropicDiffusion,
            this._menuItemMedicalDigitalSubtract,
            this._menuItemMedicalMeanShift,
            this._menuItemMedicalMultiscaleEnhancement,
            this._menuItemMedicalSelectData,
            this._menuItemMedicalShiftData,
            this._menuItemMedicalSigma,
            this._menuItemMedicalTissueEqualize,
            this._menuItemMedicalSkeleton,
            this._menuItemCLAHE,
            this._miBackgroundRemoval});
            this._menuItemMedical.Text = "Medical";
            this._menuItemMedical.Visible = false;
            // 
            // _menuItemMedicalAnisotropicDiffusion
            // 
            this._menuItemMedicalAnisotropicDiffusion.Index = 0;
            this._menuItemMedicalAnisotropicDiffusion.Text = "Anisotropic Diffusion";
            this._menuItemMedicalAnisotropicDiffusion.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemMedicalDigitalSubtract
            // 
            this._menuItemMedicalDigitalSubtract.Index = 1;
            this._menuItemMedicalDigitalSubtract.Text = "Digital Subtract";
            this._menuItemMedicalDigitalSubtract.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemMedicalMeanShift
            // 
            this._menuItemMedicalMeanShift.Index = 2;
            this._menuItemMedicalMeanShift.Text = "Mean Shift";
            this._menuItemMedicalMeanShift.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemMedicalMultiscaleEnhancement
            // 
            this._menuItemMedicalMultiscaleEnhancement.Index = 3;
            this._menuItemMedicalMultiscaleEnhancement.Text = "Multiscale Enhancement";
            this._menuItemMedicalMultiscaleEnhancement.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemMedicalSelectData
            // 
            this._menuItemMedicalSelectData.Index = 4;
            this._menuItemMedicalSelectData.Text = "Select Data";
            this._menuItemMedicalSelectData.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemMedicalShiftData
            // 
            this._menuItemMedicalShiftData.Index = 5;
            this._menuItemMedicalShiftData.Text = "Shift Data";
            this._menuItemMedicalShiftData.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemMedicalSigma
            // 
            this._menuItemMedicalSigma.Index = 6;
            this._menuItemMedicalSigma.Text = "Sigma";
            this._menuItemMedicalSigma.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemMedicalTissueEqualize
            // 
            this._menuItemMedicalTissueEqualize.Index = 7;
            this._menuItemMedicalTissueEqualize.Text = "Tissue Equalize";
            this._menuItemMedicalTissueEqualize.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemMedicalSkeleton
            // 
            this._menuItemMedicalSkeleton.Index = 8;
            this._menuItemMedicalSkeleton.Text = "Skeleton";
            this._menuItemMedicalSkeleton.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemCLAHE
            // 
            this._menuItemCLAHE.Index = 9;
            this._menuItemCLAHE.Text = "CLAHE...";
            this._menuItemCLAHE.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _miBackgroundRemoval
            // 
            this._miBackgroundRemoval.Index = 10;
            this._miBackgroundRemoval.Text = "&Background Removal...";
            this._miBackgroundRemoval.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemSegmentation
            // 
            this._menuItemSegmentation.Index = 8;
            this._menuItemSegmentation.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemSegmentationKMeans,
            this._menuItemSegmentationOtsu,
            this._menuItemSegmentationLevelSet,
            this._menuItemSegmentationLambda,
            this._menuItemSegmentationGWireTool,
            this._menuItemSegmentationInvPerspective,
            this._menuItemSegmentationShrinkTool,
            this._menuItemSegmentationTDAFilter,
            this._menuItemSegmentationSRADFilter,
            this._menuItemSegmentationWatershed,
            this._menuItemDeskewToolStrip});
            this._menuItemSegmentation.Text = "Segmentation";
            // 
            // _menuItemSegmentationKMeans
            // 
            this._menuItemSegmentationKMeans.Index = 0;
            this._menuItemSegmentationKMeans.Text = "KMeans";
            this._menuItemSegmentationKMeans.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemSegmentationOtsu
            // 
            this._menuItemSegmentationOtsu.Index = 1;
            this._menuItemSegmentationOtsu.Text = "Otsu";
            this._menuItemSegmentationOtsu.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemSegmentationLevelSet
            // 
            this._menuItemSegmentationLevelSet.Index = 2;
            this._menuItemSegmentationLevelSet.Text = "Level Set";
            this._menuItemSegmentationLevelSet.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemSegmentationLambda
            // 
            this._menuItemSegmentationLambda.Index = 3;
            this._menuItemSegmentationLambda.Text = "Lambda Connectedness";
            this._menuItemSegmentationLambda.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemSegmentationGWireTool
            // 
            this._menuItemSegmentationGWireTool.Index = 4;
            this._menuItemSegmentationGWireTool.Text = "GWire Tool";
            this._menuItemSegmentationGWireTool.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemSegmentationInvPerspective
            // 
            this._menuItemSegmentationInvPerspective.Index = 5;
            this._menuItemSegmentationInvPerspective.Text = "Inv Perspective";
            this._menuItemSegmentationInvPerspective.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemSegmentationShrinkTool
            // 
            this._menuItemSegmentationShrinkTool.Index = 6;
            this._menuItemSegmentationShrinkTool.Text = "Shrink Tool";
            this._menuItemSegmentationShrinkTool.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemSegmentationTDAFilter
            // 
            this._menuItemSegmentationTDAFilter.Index = 7;
            this._menuItemSegmentationTDAFilter.Text = "TAD Filter";
            this._menuItemSegmentationTDAFilter.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemSegmentationSRADFilter
            // 
            this._menuItemSegmentationSRADFilter.Index = 8;
            this._menuItemSegmentationSRADFilter.Text = "SRAD Filter";
            this._menuItemSegmentationSRADFilter.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemSegmentationWatershed
            // 
            this._menuItemSegmentationWatershed.Index = 9;
            this._menuItemSegmentationWatershed.Text = "&Watershed...";
            this._menuItemSegmentationWatershed.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemDeskewToolStrip
            // 
            this._menuItemDeskewToolStrip.Index = 10;
            this._menuItemDeskewToolStrip.Text = "Perspective Deskew";
            this._menuItemDeskewToolStrip.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemDocument
            // 
            this._menuItemDocument.Index = 9;
            this._menuItemDocument.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemDocumentAutoCrop,
            this._menuItemDocumentDespeckle,
            this._menuItemDocumentErode,
            this._menuItemDocumentDilate,
            this._menuItemDocumentUnditherText,
            this._menuItemDocumentFixBrokenLetters});
            this._menuItemDocument.Text = "Document clean up";
            this._menuItemDocument.Visible = false;
            // 
            // _menuItemDocumentAutoCrop
            // 
            this._menuItemDocumentAutoCrop.Index = 0;
            this._menuItemDocumentAutoCrop.Text = "Auto Crop";
            this._menuItemDocumentAutoCrop.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemDocumentDespeckle
            // 
            this._menuItemDocumentDespeckle.Index = 1;
            this._menuItemDocumentDespeckle.Text = "Despeckle";
            this._menuItemDocumentDespeckle.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemDocumentErode
            // 
            this._menuItemDocumentErode.Index = 2;
            this._menuItemDocumentErode.Text = "Erode";
            this._menuItemDocumentErode.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemDocumentDilate
            // 
            this._menuItemDocumentDilate.Index = 3;
            this._menuItemDocumentDilate.Text = "Dilate";
            this._menuItemDocumentDilate.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemDocumentUnditherText
            // 
            this._menuItemDocumentUnditherText.Index = 4;
            this._menuItemDocumentUnditherText.Text = "Undither text";
            this._menuItemDocumentUnditherText.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemDocumentFixBrokenLetters
            // 
            this._menuItemDocumentFixBrokenLetters.Index = 5;
            this._menuItemDocumentFixBrokenLetters.Text = "Fix broken letters";
            this._menuItemDocumentFixBrokenLetters.Click += new System.EventHandler(this._menuItem_Click);
            // 
            // _menuItemWindow
            // 
            this._menuItemWindow.Index = 10;
            this._menuItemWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemWindowCascade,
            this._menuItemWindowTileHorizontally,
            this._menuItemWindowTileVertically,
            this._menuItemWindowArrangeIcons,
            this._menuItemWindowCloseAll});
            this._menuItemWindow.Text = "&Window";
            this._menuItemWindow.Visible = false;
            // 
            // _menuItemWindowCascade
            // 
            this._menuItemWindowCascade.Index = 0;
            this._menuItemWindowCascade.Text = "&Cascade";
            this._menuItemWindowCascade.Click += new System.EventHandler(this._menuItemWindow_Click);
            // 
            // _menuItemWindowTileHorizontally
            // 
            this._menuItemWindowTileHorizontally.Index = 1;
            this._menuItemWindowTileHorizontally.Text = "Tile &Horizontally";
            this._menuItemWindowTileHorizontally.Click += new System.EventHandler(this._menuItemWindow_Click);
            // 
            // _menuItemWindowTileVertically
            // 
            this._menuItemWindowTileVertically.Index = 2;
            this._menuItemWindowTileVertically.Text = "Tile &Vertically";
            this._menuItemWindowTileVertically.Click += new System.EventHandler(this._menuItemWindow_Click);
            // 
            // _menuItemWindowArrangeIcons
            // 
            this._menuItemWindowArrangeIcons.Index = 3;
            this._menuItemWindowArrangeIcons.Text = "Arrange &Icons";
            this._menuItemWindowArrangeIcons.Click += new System.EventHandler(this._menuItemWindow_Click);
            // 
            // _menuItemWindowCloseAll
            // 
            this._menuItemWindowCloseAll.Index = 4;
            this._menuItemWindowCloseAll.Text = "Close &All";
            this._menuItemWindowCloseAll.Click += new System.EventHandler(this._menuItemWindow_Click);
            // 
            // _miHelp
            // 
            this._miHelp.Index = 11;
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
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(894, 289);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this._mmMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LEADTOOLS for .NET C# Gray Scale Demo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.ResumeLayout(false);

      }
      #endregion

      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         if (RasterSupport.IsLocked(RasterSupportType.Medical))
         {
            MessageBox.Show("Medical support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         Application.Run(new MainForm());
      }

      private RasterCodecs _codecs;

      private void MainForm_Load(object sender, System.EventArgs e)
      {
         UpdateMyControls();
         Messager.Caption = "LEADTOOLS for .NET C# Gray Scale Demo";
         Text = Messager.Caption;
         this.IsMdiContainer = true;
         _childPath = new List<ViewerImages>();
         _directoryPath = string.Empty;

         _codecs = new RasterCodecs();
         _rawdataLoad = RawData.Default;
         _rawdataSave = RawData.Default;

         _paintProperties = RasterPaintProperties.Default;
         _paintProperties.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray;
         _paintProperties.PaintDisplayMode |= RasterPaintDisplayModeFlags.Bicubic;

      }

      public void UpdateMyControls()
      {
         try
         {
            ViewerForm activeForm = ActiveMdiChild as ViewerForm;
            EnableAndVisibleMenu(_menuItemPage, activeForm != null);
            EnableAndVisibleMenu(_menuItemWindow, activeForm != null);
            EnableAndVisibleMenu(_menuItemEffect, activeForm != null);
            //EnableAndVisibleMenu(_menuItemEdit, activeForm != null);
            EnableAndVisibleMenu(_menuItemColor, activeForm != null);
            EnableAndVisibleMenu(_menuItemImage, activeForm != null);
            EnableAndVisibleMenu(_menuItemMedical, activeForm != null);
            EnableAndVisibleMenu(_menuItemView, activeForm != null);
            EnableAndVisibleMenu(_menuItemDocument, activeForm != null);
            EnableAndVisibleMenu(_menuItemSegmentation, activeForm != null);
            EnableMenu(_menuItemFileSave, activeForm != null);
            EnableMenu(_menuItemSaveRaw, activeForm != null);
            EnableMenu(_menuItemRegion, activeForm != null);
            EnableMenu(_menuItemCopy, activeForm != null);
            EnableMenu(_menuItemRedo, activeForm != null);
            EnableMenu(_menuItemUndo, activeForm != null);
            EnableMenu(_menuItemMagGlassSettings, activeForm != null);
            EnableMenu(_menuItemRegionCombine, activeForm != null);
             
            if (activeForm == null)
            {
                if (CopyedImage != null)
                {
                    CopyedImage.Dispose();
                }
                CopyedImage = null;
                _menuItemPaste.Enabled = false;
                return;
            }
            _menuItemPaste.Enabled = CopyedImage != null;
            RasterImage tmpImg = (activeForm.Viewer.Floater != null) ? activeForm.Viewer.Floater : activeForm.Image;

            EnableMenu(_menuItemDeskewToolStrip, tmpImg.BitsPerPixel == 8 || tmpImg.BitsPerPixel == 24 || tmpImg.BitsPerPixel == 32);
            //EnableMenu(_menuItemColorResolution, !tmpImg.Signed);

            EnableMenu(_menuItemImageBlankPageDetection, tmpImg.BitsPerPixel != 12 && tmpImg.BitsPerPixel != 16 && tmpImg.BitsPerPixel != 48 && tmpImg.BitsPerPixel != 64);

            EnableAndVisibleMenu(_menuItemWL, activeForm.ImageCategory == ImageCategory.GrayScale_8_12_16_BPP);
            EnableMenu(_menuItemDocumentAutoCrop, !tmpImg.Signed);
            EnableMenu(_menuItemDocumentDespeckle, !tmpImg.Signed);
            EnableMenu(_menuItemSetPixelColor, !tmpImg.Signed);
            EnableMenu(_menuItemColorAutoBinarize, !tmpImg.Signed && tmpImg.BitsPerPixel == 8);
            EnableMenu(_menuItemColorIntensityDetect, !tmpImg.Signed);
            EnableMenu(_menuItemEffectsEdgeContour, !tmpImg.Signed);

            EnableMenu(_menuItemSeparation, !tmpImg.Signed);
            EnableMenu(_menuItemColorAdjustAutoLevel, !(tmpImg.Signed || (activeForm.ImageCategory == ImageCategory.GrayScale_8_12_16_BPP && activeForm.Image.BitsPerPixel != 8)));
            EnableMenu(_menuItemColorAdjustAutoContrast, !(tmpImg.Signed || (activeForm.ImageCategory == ImageCategory.GrayScale_8_12_16_BPP && activeForm.Image.BitsPerPixel != 8)));
            EnableMenu(_menuItemColorHistogramIntensity, !(tmpImg.Signed || (activeForm.ImageCategory == ImageCategory.GrayScale_8_12_16_BPP && activeForm.Image.BitsPerPixel != 8)));
            //EnableMenu(_menuItemFastMagicWandCommand, tmpImg.BitsPerPixel == 8);
            EnableMenu(_menuItemCLAHE, tmpImg.BitsPerPixel == 8 || tmpImg.BitsPerPixel == 16);
            EnableMenu(_miBackgroundRemoval, tmpImg.BitsPerPixel == 16);
            EnableMenu(_menuItemMedicalMultiscaleEnhancement, activeForm.ImageCategory != ImageCategory.GrayScale_32_48_BPP);
            EnableMenu(_menuItemMedicalTissueEqualize, activeForm.ImageCategory != ImageCategory.GrayScale_32_48_BPP && activeForm.ImageCategory != ImageCategory.OneBitImage);
            EnableMenu(_menuItemMedicalSigma, activeForm.ImageCategory != ImageCategory.GrayScale_32_48_BPP && activeForm.ImageCategory != ImageCategory.OneBitImage);

            if (activeForm != null)
            {
               EnableAndVisibleMenu(_menuItemPage, activeForm.Image.PageCount > 1);
               EnableAndVisibleMenu(_menuItemPageFirst, activeForm.Image.PageCount > 1);
               EnableAndVisibleMenu(_menuItemPagePrevious, activeForm.Image.PageCount > 1);
               EnableAndVisibleMenu(_menuItemPageNext, activeForm.Image.PageCount > 1);
               EnableAndVisibleMenu(_menuItemPageLast, activeForm.Image.PageCount > 1);

               if (activeForm.Image.PageCount > 1)
               {
                  _menuItemPageFirst.Enabled = activeForm.Image.Page > 1;
                  _menuItemPagePrevious.Enabled = activeForm.Image.Page > 1;
                  _menuItemPageNext.Enabled = activeForm.Image.Page != activeForm.Image.PageCount;
                  _menuItemPageLast.Enabled = activeForm.Image.Page != activeForm.Image.PageCount;
               }
            }

            if (activeForm.Viewer.Floater != null)
            {
               _menuItemUndo.Enabled = activeForm.FloaterImageIndex != 0;
               _menuItemRedo.Enabled = activeForm.FloaterImageIndex < activeForm.floaterImageslist.Count - 1;
            }
            else
            {
               _menuItemUndo.Enabled = activeForm.ImageIndex != 0;
               _menuItemRedo.Enabled = activeForm.ImageIndex < activeForm.imageslist.Count - 1;
            }

            bool en = !(tmpImg.GrayscaleMode != RasterGrayscaleMode.None &&
                 tmpImg.BitsPerPixel > 16);

            EnableMenu(_menuItemPage, !_isSegmentation);
            EnableMenu(_menuItemWindow, !_isSegmentation);
            EnableMenu(_menuItemFileSave, !_isSegmentation);
            EnableMenu(_menuItemEffect, en && !_isSegmentation);
            //EnableMenu(_menuItemEdit, !_isSegmentation);
            EnableMenu(_menuItemColor, en && !_isSegmentation);
            EnableMenu(_menuItemImage, !_isSegmentation);
            EnableMenu(_menuItemDocument, en && !_isSegmentation);
            EnableMenu(_menuItemMedical, !_isSegmentation);

            EnableMenu(_menuItemColorHistogram, en);
            EnableMenu(_menuItemImageInfo, en);
            EnableMenu(_menuItemLineHistogram, en);
            EnableMenu(_menuItemImageDeskew, en);
            EnableMenu(_menuItemMedicalSkeleton, en);
            EnableMenu(_menuItemMedicalDigitalSubtract, en);

            en = activeForm.ImageCategory == ImageCategory.GrayScale_8_12_16_BPP;
            EnableMenu(_menuItemMedicalAnisotropicDiffusion, !tmpImg.Signed && (activeForm.ImageCategory == ImageCategory.GrayScale_8_12_16_BPP && tmpImg.BitsPerPixel != 8));
            EnableMenu(_menuItemMedicalSelectData, en && !tmpImg.Signed && activeForm.Viewer.Floater == null);
            EnableMenu(_menuItemMedicalShiftData, en);

            EnableMenu(_menuItemSegmentation, !_isSegmentation);
            EnableMenu(_menuItemDeskewToolStrip, tmpImg.BitsPerPixel == 8 || tmpImg.BitsPerPixel == 24 || tmpImg.BitsPerPixel == 32);
            EnableMenu(_menuItemMerge, !tmpImg.Signed);

            EnableMenu(_menuItemLUTInvert, activeForm.ImageCategory == ImageCategory.GrayScale_8_12_16_BPP && tmpImg.BitsPerPixel != 8);

            _menuItemRegionRectangle.Checked = (activeForm.RegionType == RegionType.RECTANGLE);
            _menuItemRegionEllipse.Checked = (activeForm.RegionType == RegionType.ELLIPSE);
            _menuItemRegionRoundRectangle.Checked = (activeForm.RegionType == RegionType.ROUND_RECTANGLE);
            _menuItemRegionFreehand.Checked = (activeForm.RegionType == RegionType.FREE_HAND);
            _menuItemRegionAutoSegment.Checked = (activeForm.RegionType == RegionType.AUTO_SEGMENT);
            //_menuItemFastMagicWandCommand.Checked = (activeForm.RegionType == RegionType.FAST_MAGIC_WAND);
            _menuItemRegionNone.Checked = (activeForm.RegionType == RegionType.NONE);
            _menuItemAddBorderToRegion.Checked = (activeForm.RegionType == RegionType.ADD_BORDER_TO_REGION);


            _menuItemViewMagnifyGlass.Checked = (activeForm.Viewer.InteractiveModes.FindById(activeForm.MagnifyGlassInteractiveMode.Id).IsEnabled);
            _menuItemInterActiveNone.Checked = (activeForm.Viewer.InteractiveModes.FindById(activeForm.NoneInteractiveMode.Id).IsEnabled ||
                activeForm.Viewer.InteractiveModes.FindById(activeForm.FloaterInteractiveMode.Id).IsEnabled);
            _menuItemInterActivePan.Checked = (activeForm.Viewer.InteractiveModes.FindById(activeForm.PanInteractiveMode.Id).IsEnabled);

            _menuItemSizeFit.Checked = (activeForm.Viewer.SizeMode == ControlSizeMode.FitAlways);
            _menuItemSizeNormal.Checked = ((activeForm.Viewer.SizeMode == ControlSizeMode.ActualSize) || (activeForm.Viewer.SizeMode == ControlSizeMode.None));
         }
         catch (Exception /*ex*/)
         {
         }
      }

      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("Gray Scale", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("Gray Scale"))
            aboutDialog.ShowDialog(this);
#endif
      }

      private void EnableAndVisibleMenu(MenuItem menu, bool value)
      {
         menu.Enabled = value;
         menu.Visible = value;
      }

      private void EnableMenu(MenuItem menu, bool value)
      {
         menu.Enabled = value;
      }

      private void _menuItemPage_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;
         try
         {
            if (sender == _menuItemPageFirst)
               activeForm.Viewer.Image.Page = 1;
            else if (sender == _menuItemPagePrevious)
               activeForm.Viewer.Image.Page--;
            else if (sender == _menuItemPageNext)
               activeForm.Viewer.Image.Page++;
            else if (sender == _menuItemPageLast)
               activeForm.Viewer.Image.Page = activeForm.Viewer.Image.PageCount;

            activeForm.page();
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

      private void open_Click(object sender, EventArgs e)
      {
         ImageFileLoader loader = new ImageFileLoader();
         try
         {
            loader.ShowLoadPagesDialog = true;
            loader.OpenDialogInitialPath = _directoryPath;
            if (loader.Load(this, _codecs, true) > 0)
            {
               ViewerForm child = new ViewerForm(this);
               child.MdiParent = this;
               child.WindowState = FormWindowState.Normal;
               child.Initialize();
               child.load(loader.Image, loader.FileName);
               child.FormClosed += new FormClosedEventHandler(form_FormClosed);
               child.Show();
               child.Id = this.MdiChildren.Length - 1;
               if (Path.GetDirectoryName(loader.FileName) != null)
                  _directoryPath = Path.GetDirectoryName(loader.FileName);
               _childPath.Add(new ViewerImages(loader.FileName, child.Id, child.Image));
            }
            UpdateMyControls();
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }
      }

      private void save_Click(object sender, EventArgs e)
      {
         (ActiveMdiChild as ViewerForm).save();
         UpdateMyControls();
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
            UpdateMyControls();
         }
      }

      private void _menuItem_WL_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;
         activeForm.WLManually();
      }

      private void _menuItem_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;
         try
         {
            if (sender == _menuItemFillCommand)
               activeForm.fillCommand();
            //else if (sender == _menuItemFastMagicWandCommand)
            //   activeForm.fastMagicWandCommand();
            else if (sender == _menuItemColorHistogram)
               activeForm.histogram();
            else if (sender == _menuItemRegionCancel)
            {
               if (activeForm.Viewer.Floater != null)
                  activeForm.Viewer.Floater = null;
            }
            else if (sender == _menuItemLUTInvert || sender == _menuItemImageDataInvert)
            {
               activeForm.InvertByCommand = true;
               if (sender == _menuItemLUTInvert)
               {
                  activeForm.invert(true);
               }
               else
               {
                  activeForm.invert(false);
               }
            }
            else if (sender == _miBackgroundRemoval)
                activeForm.BackgroundRemoval(this);
            else if (sender == _menuItemImageFlipH)
               activeForm.flip(true);
            else if (sender == _menuItemImageFlipV)
               activeForm.flip(false);
            else if (sender == _menuItemEffectsBlurAvg)
               activeForm.average();
            else if (sender == _menuItemEffectNoiseMax)
               activeForm.noiseMax();
            else if (sender == _menuItemEffectNoiseMin)
               activeForm.noiseMin();
            else if (sender == _menuItemEffectNoiseMedian)
               activeForm.noiseMedian();
            else if (sender == _menuItemEffectsSharpenSharpen)
               activeForm.sharpen();
            else if (sender == _menuItemEffectsSharpenUnsharpen)
               activeForm.unSharpen();
            else if (sender == _menuItemEffectsEdgesDetection)
               activeForm.edgeDetection();
            else if (sender == _menuItemEffectsEdgeContour)
               activeForm.edgeContour();
            else if (sender == _menuItemEffectsSpecialGauissian)
               activeForm.gauissian();
            else if (sender == _menuItemColorAdjustContrast)
               activeForm.contrast();
            else if (sender == _menuItemColorAdjustBrightness)
               activeForm.brightness();
            else if (sender == _menuItemColorHistogramEqualizer)
               activeForm.histogramEqualizer();
            else if (sender == _menuItemColorHistogramAdaptiveContrast)
               activeForm.histogramAdaptiveContrast();
            else if (sender == _menuItemColorHistogramLocalEqualizer)
               activeForm.histogramLocalEqualizer();
            else if (sender == _menuItemColorAdjustAutoLevel)
               activeForm.autoLevel();
            else if (sender == _menuItemColorAdjustAutoContrast)
               activeForm.autoContrast();
            else if (sender == _menuItemColorHistogramIntensity)
               activeForm.autoIntensity();
            else if (sender == _menuItemImageDeskew)
               activeForm.deskew();
            else if (sender == _menuItemImageBlankPageDetection)
               activeForm.blankPageDetection();
            else if (sender == _menuItemImageRotateFast90)
               activeForm.rotate(90);
            else if (sender == _menuItemImageRotateFast180)
               activeForm.rotate(180);
            else if (sender == _menuItemRotateFast270)
               activeForm.rotate(270);
            else if (sender == _menuItemRotateCustom)
               activeForm.rotate(-1);
            else if (sender == _menuItemImageShear)
               activeForm.shear();
            else if (sender == _menuItemColorAutoBinarize)
               activeForm.autoBinarize();
            else if (sender == _menuItemColorIntensityDetect)
               activeForm.intensityDetect();
            else if (sender == _menuItemSegmentationKMeans)
               activeForm.KMeans();
            else if (sender == _menuItemSegmentationOtsu)
               activeForm.Otsu(this);
            else if (sender == _menuItemSegmentationLambda)
               activeForm.Lambda();
            else if (sender == _menuItemSegmentationLevelSet)
            {
               activeForm.LevelSet();
            }
            else if (sender == _menuItemSegmentationTDAFilter)
               activeForm.TDAFilter();
            else if (sender == _menuItemSegmentationSRADFilter)
               activeForm.SRADFilter();
            else if (sender == _menuItemDocumentAutoCrop)
               activeForm.AutoCrop();
            else if (sender == _menuItemDocumentDespeckle)
               activeForm.Despeckle();
            else if (sender == _menuItemDocumentErode)
               activeForm.Erode();
            else if (sender == _menuItemDocumentDilate)
               activeForm.Dilate();
            else if (sender == _menuItemDocumentUnditherText)
               activeForm.UnditherText();
            else if (sender == _menuItemDocumentFixBrokenLetters)
               activeForm.FixBrokenLetters();
            else if (sender == _menuItemSegmentationInvPerspective)
            {
               activeForm.invPerspective(this);
               _isSegmentation = true;
               activeForm.IsPerspective = true;
            }
            else if (sender == _menuItemSegmentationShrinkTool)
            {
               activeForm.IsRegion = true;
               activeForm.shrinkTool(this);
               _isSegmentation = true;
            }
            else if (sender == _menuItemSegmentationGWireTool)
            {
               activeForm.gWireTool(this);
               _isSegmentation = true;
               activeForm.IsPerspective = true;
            }
            else if (sender == _menuItemMedicalAnisotropicDiffusion)
               activeForm.AnisotropicDiffusion();
            else if (sender == _menuItemMedicalDigitalSubtract)
               activeForm.DigitalSubtract();
            else if (sender == _menuItemMedicalMeanShift)
               activeForm.MeanShift();
            else if (sender == _menuItemMedicalMultiscaleEnhancement)
               activeForm.MultiscaleEnhancement(this);
            else if (sender == _menuItemMedicalSelectData)
               activeForm.SelectData();
            else if (sender == _menuItemMedicalShiftData)
               activeForm.ShiftData();
            else if (sender == _menuItemMedicalSigma)
               activeForm.Sigma();
            else if (sender == _menuItemMedicalTissueEqualize)
               activeForm.TissueEqualize();
            else if (sender == _menuItemMedicalSkeleton)
               activeForm.Skeleton();
            else if (sender == _menuItemRegionCombine)
               activeForm.CombineFloater();
            else if (sender == _menuItemCombine)
               activeForm.CombineImage();
            else if (sender == _menuItemCopyImage)
               activeForm.CopyImage();
            else if (sender == _menuItemImageInfo)
               activeForm.StatisticsInformation();
            else if (sender == _menuItemLineHistogram)
               activeForm.LineHistogram();
            else if (sender == _menuItemMerge)
               activeForm.Merge();
            else if (sender == _menuItemMagGlassSettings)
               activeForm.MagnifyGlass();
            else if (sender == _menuItemUndo)
               activeForm.Undo();
            else if (sender == _menuItemRedo)
               activeForm.Redo();
            else if (sender == _menuItemCLAHE)
               activeForm.CLAHE();
            else if (sender == _menuItemCopy)
               Copy();
            else if (sender == _menuItemPaste)
            {
                Paste();
                activeForm = ActiveMdiChild as ViewerForm;
            }
            else if (sender == _menuItemSegmentationWatershed)
            {
                _isSegmentation = true;
                activeForm.Watershed(this);
            }
            else if (sender == _menuItemDeskewToolStrip)
                activeForm.Auto3DDeskew();
            else if (sender == _menuItemColorGrayScale)
            {
                GrayScaleDialog dlg = new GrayScaleDialog();
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    activeForm.Grayscale(dlg.BitsPerPixel);
            }
            else if (sender == _menuItemColorResolution)
            {
                ColorResolutionDialog dlg = new ColorResolutionDialog(activeForm.Viewer.Image, _paintProperties);
                dlg.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel;
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    activeForm.ColorResolution(dlg.BitsPerPixel, dlg.Order, dlg.DitheringMethod, dlg.PaletteFlags);
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         finally
         {
             if(activeForm != null)
                activeForm.UpdateAfterCommandExecution();
            UpdateMyControls();
         }
      }

      private void MainForm_MdiChildActivate(object sender, EventArgs e)
      {
         UpdateMyControls();
      }

      private void form_FormClosed(object sender, EventArgs e)
      {
         int i = 0;
         try
         {
            ViewerForm child = (ViewerForm)sender;
            foreach (ViewerImages tmp in _childPath)
               if (tmp.ChildFormId == child.Id)
                  break;
               else
                  i++;

            _childPath.RemoveAt(i);

            for (int x = i; x < _childPath.Count; x++)
               _childPath[x].ChildFormId--;
            for (int x = i; x < this.MdiChildren.Length; x++)
               ((ViewerForm)this.MdiChildren[x]).Id = ((ViewerForm)this.MdiChildren[x]).Id - 1;
         }
         catch (Exception /*ex*/)
         {
         }
      }

      private void Region_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;
         activeForm.DisableInteractiveModes(activeForm.Viewer);
         if (activeForm.Viewer.Floater != null)
         {
            activeForm.Viewer.CombineFloater(true);
         }

         activeForm.Viewer.InteractiveModes.EnableById(activeForm.NoneInteractiveMode.Id);
         activeForm.Viewer.InteractiveModes.BeginUpdate();


         if (sender == _menuItemRegionRectangle)
         {
            activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Rectangle;
            activeForm.RegionInteractiveMode.IsEnabled = true;
            activeForm.RegionType = RegionType.RECTANGLE;
         }
         else if (sender == _menuItemRegionEllipse)
         {
            activeForm.RegionType = RegionType.ELLIPSE;
            activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Ellipse;
            activeForm.RegionInteractiveMode.IsEnabled = true;
         }
         else if (sender == _menuItemRegionFreehand)
         {
            activeForm.RegionType = RegionType.FREE_HAND;
            activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.Freehand;
            activeForm.RegionInteractiveMode.IsEnabled = true;
            activeForm.freeHand();
         }
         else if (sender == _menuItemAddBorderToRegion)
         {
            activeForm.RegionType = RegionType.ADD_BORDER_TO_REGION;
         }
         //else if (sender == _menuItemAddMagicWandToRegion)
         //{
         //   activeForm.RegionType = RegionType.MAGIC_WAND;
         //}
         //else if (sender == _menuItemFastMagicWandCommand)
         //{
         //   activeForm.RegionType = RegionType.FAST_MAGIC_WAND;
         //   activeForm.fastMagicWandCommand();
         //}
         else if (sender == _menuItemRegionNone)
            activeForm.RegionType = RegionType.NONE;
         else if (sender == _menuItemRegionRoundRectangle)
         {
            activeForm.RegionInteractiveMode.Shape = ImageViewerRubberBandShape.RoundRectangle;
            activeForm.RegionInteractiveMode.IsEnabled = true;
            activeForm.RegionType = RegionType.ROUND_RECTANGLE;
         }
         else if (sender == _menuItemRegionAutoSegment)
            activeForm.RegionType = RegionType.AUTO_SEGMENT;


         activeForm.Viewer.InteractiveModes.EndUpdate();

         UpdateMyControls();
         activeForm.UpdateAfterCommandExecution();
      }

      private void _menuItemSensitivity_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;
         activeForm.Sensitivity();
      }

      private void interactiveMode_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;

         activeForm.DisableInteractiveModes(activeForm.Viewer);
         if (sender == _menuItemViewMagnifyGlass)
         {
            activeForm.Viewer.InteractiveModes.EnableById(activeForm.MagnifyGlassInteractiveMode.Id);
            activeForm.RegionType = RegionType.NONE;
            activeForm.Viewer.Floater = null;
            activeForm.Viewer.Invalidate();
         }
         else if (sender == _menuItemInterActiveNone)
            if (activeForm.Viewer.Floater == null)
               activeForm.Viewer.InteractiveModes.EnableById(activeForm.NoneInteractiveMode.Id);
            else
               activeForm.Viewer.InteractiveModes.EnableById(activeForm.FloaterInteractiveMode.Id);
         else if (sender == _menuItemInterActivePan)
            activeForm.Viewer.InteractiveModes.EnableById(activeForm.PanInteractiveMode.Id);
         UpdateMyControls();
      }

      private void _menuItemSep_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;

         if (sender == _menuItemSepRGB)
            activeForm.SepType = SeparationType.RGB;
         else if (sender == _menuItemSepHSV)
            activeForm.SepType = SeparationType.HSV;
         else if (sender == _menuItemSepHLS)
            activeForm.SepType = SeparationType.HLS;
         else if (sender == _menuItemSepCMYK)
            activeForm.SepType = SeparationType.CMYK;
         else if (sender == _menuItemSepCMY)
            activeForm.SepType = SeparationType.CMY;
         else if (sender == _menuItemSepAlpha)
            activeForm.SepType = SeparationType.ALPHA;
         else if (sender == _menuItemSepYUV)
            activeForm.SepType = SeparationType.YUV;
         else if (sender == _menuItemSepXYZ)
            activeForm.SepType = SeparationType.XYZ;
         else if (sender == _menuItemSepLAB)
            activeForm.SepType = SeparationType.LAB;
         else if (sender == _menuItemSepYCRCB)
            activeForm.SepType = SeparationType.YCRCB;
         else if (sender == _menuItemSepSCT)
            activeForm.SepType = SeparationType.SCT;

         activeForm.Separation();
      }

      private void MainForm_DragEnter(object sender, DragEventArgs e)
      {
         if (Tools.CanDrop(e.Data))
            e.Effect = DragDropEffects.Copy;
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
                        viewer.Initialize();
                     else
                     {
                        ViewerForm child = new ViewerForm(this);
                        child.MdiParent = this;
                        child.WindowState = FormWindowState.Normal;
                        child.Initialize();
                        child.load(image, info.Name);
                        child.Show();
                     }
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
            UpdateMyControls();
         }
      }

      private void _menuItemSize_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;

         if (sender == _menuItemSizeNormal)
         {
            activeForm.Viewer.Zoom(ControlSizeMode.ActualSize, 1, activeForm.Viewer.DefaultZoomOrigin);
         }
         else if (sender == _menuItemSizeFit)
         {
            activeForm.Viewer.Zoom(ControlSizeMode.FitAlways, 1, activeForm.Viewer.DefaultZoomOrigin);
         }
         UpdateMyControls();

      }

      public void Copy()
      {
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;
         if (CopyedImage != null)
            CopyedImage.Dispose();

         if (activeForm.Viewer.Floater == null)
         {
            RasterClipboard.Copy(activeForm.Handle, activeForm.Viewer.Image, RasterClipboardCopyFlags.Dib);
            CopyedImage = new RasterImage(activeForm.Viewer.Image);
         }
         else
         {
            RasterClipboard.Copy(activeForm.Handle, activeForm.Viewer.Floater, RasterClipboardCopyFlags.Dib);
            CopyedImage = new RasterImage(activeForm.Viewer.Floater);
         }

         CopyedImage.SetRegion(null, null, RasterRegionCombineMode.Set);
      }

      private void NewImage(ImageInformation info)
      {
          ViewerForm child = new ViewerForm(this);
          child.MdiParent = this;
          child.Initialize();
          child.load(info.Image, info.Name);
          child.FormClosed += new FormClosedEventHandler(form_FormClosed);

          child.Viewer.Zoom(ControlSizeMode.ActualSize, 1, child.Viewer.DefaultZoomOrigin);
          child.Viewer.InteractiveModes.BeginUpdate();
          child.NoneInteractiveMode.IsEnabled = true;

          //Set the DoubleTapSizeMode property for all ImageViewerPanZoomInteractiveModes to use the current size mode of the image viewer control
          foreach (ImageViewerInteractiveMode mode in child.Viewer.InteractiveModes)
          {
              if (mode is ImageViewerPanZoomInteractiveMode)
                  ((ImageViewerPanZoomInteractiveMode)mode).DoubleTapSizeMode = child.Viewer.SizeMode;
          }

          child.Viewer.InteractiveModes.EndUpdate();
          child.Show();
      }

      public void Paste()
      {
          try
          {
              using (WaitCursor wait = new WaitCursor())
              {
                  RasterImage image = null;
                  if (CopyedImage != null && (CopyedImage.BitsPerPixel == 16 || CopyedImage.BitsPerPixel == 12))
                  {
                      image = CopyedImage.Clone();
                  }
                  else
                  {
                      image = RasterClipboard.Paste(this.Handle);
                  }

                  if (image != null)
                  {
                      ViewerForm activeForm = ActiveMdiChild as ViewerForm;

                      if (image.HasRegion && activeForm == null)
                          image.MakeRegionEmpty();

                      if (image.HasRegion)
                      {

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

                          activeForm.Viewer.InteractiveModes.BeginUpdate();
                          activeForm.FloaterInteractiveMode.IsEnabled = true;
                          activeForm.Viewer.InteractiveModes.EndUpdate();
                      }
                      else
                      {
                          NewImage(new ImageInformation(image) { Name = "Clipboard Data" });
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
              UpdateMyControls();
          }
      }

      private void _menuItemOpenRaw_Click(object sender, EventArgs e)
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
         finally
         {
            UpdateMyControls();
         }
      }

      private void _menuItemSaveRaw_Click(object sender, EventArgs e)
      {
         ImageFileSaver saver = new ImageFileSaver();

         try
         {
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


      private void LoadRaw(string fileName)
      {
         EventHandler<CodecsLoadInformationEventArgs> handler = null;
         try
         {
            RawDialog dlg = new RawDialog(true);
            dlg.CurrentRawData = _rawdataLoad;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               ImageInformation imageInfo = new ImageInformation();
               imageInfo.Name = fileName;
               _rawdataLoad = dlg.CurrentRawData;

               handler = new EventHandler<CodecsLoadInformationEventArgs>(codecs_LoadInformation);
               _codecs.Options.Load.Format = _rawdataLoad.Format;
               _codecs.LoadInformation += new EventHandler<CodecsLoadInformationEventArgs>(codecs_LoadInformation);

               using (WaitCursor wait = new WaitCursor())
               {
                  imageInfo.Image = _codecs.Load(fileName);

                  if ((imageInfo.Image.BitsPerPixel == 12 || imageInfo.Image.BitsPerPixel == 16) && imageInfo.Image.Order == RasterByteOrder.Gray)
                  {
                     MinMaxValuesCommand cmd = new MinMaxValuesCommand();
                     cmd.Run(imageInfo.Image);
                     int highValue = cmd.MaximumValue;
                     int lowValue = cmd.MinimumValue;
                  }

                  ViewerForm child = new ViewerForm(this);
                  child.MdiParent = this;
                  child.WindowState = FormWindowState.Normal;
                  child.Initialize();
                  child.load(imageInfo.Image, imageInfo.Name);
                  child.FormClosed += new FormClosedEventHandler(form_FormClosed);
                  child.Show();
                  child.Id = this.MdiChildren.Length - 1;
                  if (Path.GetDirectoryName(imageInfo.Name) != null)
                     _directoryPath = Path.GetDirectoryName(imageInfo.Name);
                  _childPath.Add(new ViewerImages(imageInfo.Name, child.Id, child.Image));
               }
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
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;

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

      private void _menuItemSetPixelColor_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveMdiChild as ViewerForm;
         activeForm.setPixelColor();
      }

      private void _menuItemImage_Popup(object sender, EventArgs e)
      {
         _menuItemCopyImage.Enabled = this.MdiChildren.Length > 1;

         ViewerForm activeForm = ActiveMdiChild as ViewerForm;
         _menuItemImageDeskew.Enabled = (activeForm.Viewer.Floater == null);
      }

      private void _menuItemEdit_Popup(object sender, EventArgs e)
      {
          ViewerForm activeForm = ActiveMdiChild as ViewerForm;

          _menuItemPaste.Enabled = RasterClipboard.IsReady;

          if (activeForm != null)
          {
              EnableAndVisibleMenu(_menuItemRegionCancel, activeForm.Viewer.Floater != null);
              EnableAndVisibleMenu(_menuItemRegionCombine, activeForm.Viewer.Floater != null);
          }
      }
   }
}
