// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

using Leadtools;
using Leadtools.Mrc;
using Leadtools.Demos;

using Leadtools.Twain;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Effects;
using Leadtools.WinForms.CommonDialogs.File;

using Leadtools.Drawing;
using System.Drawing.Drawing2D;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace MrcSegmentationDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mainMenu;
      private System.Windows.Forms.MenuItem _miFileSeperator1;
      private System.Windows.Forms.MenuItem _miFileTwainSelectSource;
      private System.Windows.Forms.MenuItem _miFileTwainAcquire;
      private System.Windows.Forms.MenuItem _miFileSeperator2;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miFileSave;
      private System.Windows.Forms.MenuItem _miFileSeperator3;
      private System.Windows.Forms.MenuItem _miFileOpenMrc;
      private System.Windows.Forms.MenuItem _miFileSaveLeadMrc;
      private System.Windows.Forms.MenuItem _miFileSaveMrc;
      private System.Windows.Forms.MenuItem _miFileSeperator4;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miEdit;
      private System.Windows.Forms.MenuItem _miEditCopy;
      private System.Windows.Forms.MenuItem _miEditPaste;
      private System.Windows.Forms.MenuItem _miWindow;
      private System.Windows.Forms.MenuItem _miWindowCascade;
      private System.Windows.Forms.MenuItem _miWindowTileHorizontally;
      private System.Windows.Forms.MenuItem _miWindowTileVertically;
      private System.Windows.Forms.MenuItem _miWindowArrangeIcons;
      private System.Windows.Forms.MenuItem _miWindowCloseAll;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.MenuItem _miFileSavePDF;
      private System.Windows.Forms.MenuItem _miFileExportSegment;
      private System.Windows.Forms.MenuItem _miFileImportSegment;
      private System.Windows.Forms.MenuItem _miColor;
      private System.Windows.Forms.MenuItem _miColorUniqueColors;
      private System.Windows.Forms.MenuItem _miColorResolution;
      private System.Windows.Forms.MenuItem _miColorHistogram;
      private System.Windows.Forms.MenuItem _EditSeperator2;
      private System.Windows.Forms.MenuItem _EditSeperator1;
      private System.Windows.Forms.MenuItem _miView;
      private System.Windows.Forms.MenuItem _miViewSelectedSegment;
      private System.Windows.Forms.MenuItem _miViewFitToWindow;
      private System.Windows.Forms.MenuItem _miViewNormal;
      private System.Windows.Forms.MenuItem _miViewZoomIn;
      private System.Windows.Forms.MenuItem _miViewZoomOut;
      private System.Windows.Forms.MenuItem _miSegmentation;
      private System.Windows.Forms.MenuItem _miSegDraw;
      private System.Windows.Forms.MenuItem _miSegDrawSegment;
      private System.Windows.Forms.MenuItem _miSegDrawCancelDrawing;
      private System.Windows.Forms.MenuItem _miSegStartClearManual;
      private System.Windows.Forms.MenuItem _miSegStartPreserveManual;
      private System.Windows.Forms.MenuItem _miEditUndo;
      private System.Windows.Forms.MenuItem _miSegSeperator1;
      private System.Windows.Forms.MenuItem _miSegSeperator2;
      private System.Windows.Forms.MenuItem _miSegClearSegments;
      private System.Windows.Forms.MenuItem _miEditSelectAllSegments;
      private System.Windows.Forms.MenuItem _miEditDeleteSelectedSegment;
      private System.Windows.Forms.MenuItem _miPreference;
      private System.Windows.Forms.MenuItem _miPrefSegAndComOptions;
      private System.Windows.Forms.MenuItem _miPrefShowSegType;
      private System.Windows.Forms.MenuItem _miPrefSeperator1;
      private System.Windows.Forms.MenuItem _miViewEnlargeSegment;
      private System.Windows.Forms.MenuItem _miViewShowInNewWindow;
      private System.Windows.Forms.MenuItem _miViewShowType;
      private System.Windows.Forms.MenuItem _miViewShowProperties;
      private System.Windows.Forms.MenuItem _miViewShowHistogram;
      private System.Windows.Forms.MenuItem _miViewUniqueColors;
      private System.Windows.Forms.MenuItem _miViewCombineSegments;
      private System.Windows.Forms.MenuItem _viewSeperator2;
      private System.Windows.Forms.MenuItem _viewSeperator3;
      private System.Windows.Forms.MenuItem _viewSeperator1;
      private System.Windows.Forms.MenuItem _miFileSaveMultiPage;
      private System.Windows.Forms.MenuItem _miFileOpenImage;
      private System.Windows.Forms.MenuItem _miEditDeselectAll;
      private MenuItem menuItem1;
      private MenuItem menuItem2;
      private MenuItem menuItem3;
      private System.ComponentModel.IContainer components;

      public MainForm( )
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
         if(disposing)
         {
            CleanUp();

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
         this._mainMenu = new System.Windows.Forms.MainMenu(this.components);
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileOpenImage = new System.Windows.Forms.MenuItem();
         this._miFileOpenMrc = new System.Windows.Forms.MenuItem();
         this._miFileSeperator1 = new System.Windows.Forms.MenuItem();
         this._miFileTwainSelectSource = new System.Windows.Forms.MenuItem();
         this._miFileTwainAcquire = new System.Windows.Forms.MenuItem();
         this._miFileSeperator2 = new System.Windows.Forms.MenuItem();
         this._miFileSave = new System.Windows.Forms.MenuItem();
         this._miFileSaveLeadMrc = new System.Windows.Forms.MenuItem();
         this._miFileSaveMrc = new System.Windows.Forms.MenuItem();
         this._miFileSavePDF = new System.Windows.Forms.MenuItem();
         this._miFileSaveMultiPage = new System.Windows.Forms.MenuItem();
         this._miFileSeperator3 = new System.Windows.Forms.MenuItem();
         this._miFileExportSegment = new System.Windows.Forms.MenuItem();
         this._miFileImportSegment = new System.Windows.Forms.MenuItem();
         this._miFileSeperator4 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miEdit = new System.Windows.Forms.MenuItem();
         this._miEditUndo = new System.Windows.Forms.MenuItem();
         this._EditSeperator1 = new System.Windows.Forms.MenuItem();
         this._miEditCopy = new System.Windows.Forms.MenuItem();
         this._miEditPaste = new System.Windows.Forms.MenuItem();
         this._EditSeperator2 = new System.Windows.Forms.MenuItem();
         this._miEditSelectAllSegments = new System.Windows.Forms.MenuItem();
         this._miEditDeselectAll = new System.Windows.Forms.MenuItem();
         this._miEditDeleteSelectedSegment = new System.Windows.Forms.MenuItem();
         this._miView = new System.Windows.Forms.MenuItem();
         this._miViewSelectedSegment = new System.Windows.Forms.MenuItem();
         this._miViewEnlargeSegment = new System.Windows.Forms.MenuItem();
         this._miViewShowInNewWindow = new System.Windows.Forms.MenuItem();
         this._viewSeperator2 = new System.Windows.Forms.MenuItem();
         this._miViewShowType = new System.Windows.Forms.MenuItem();
         this._miViewShowProperties = new System.Windows.Forms.MenuItem();
         this._miViewShowHistogram = new System.Windows.Forms.MenuItem();
         this._miViewUniqueColors = new System.Windows.Forms.MenuItem();
         this._viewSeperator3 = new System.Windows.Forms.MenuItem();
         this._miViewCombineSegments = new System.Windows.Forms.MenuItem();
         this._viewSeperator1 = new System.Windows.Forms.MenuItem();
         this._miViewFitToWindow = new System.Windows.Forms.MenuItem();
         this._miViewNormal = new System.Windows.Forms.MenuItem();
         this._miViewZoomIn = new System.Windows.Forms.MenuItem();
         this._miViewZoomOut = new System.Windows.Forms.MenuItem();
         this._miSegmentation = new System.Windows.Forms.MenuItem();
         this._miSegDraw = new System.Windows.Forms.MenuItem();
         this._miSegDrawSegment = new System.Windows.Forms.MenuItem();
         this._miSegDrawCancelDrawing = new System.Windows.Forms.MenuItem();
         this._miSegSeperator1 = new System.Windows.Forms.MenuItem();
         this._miSegStartClearManual = new System.Windows.Forms.MenuItem();
         this._miSegStartPreserveManual = new System.Windows.Forms.MenuItem();
         this._miSegSeperator2 = new System.Windows.Forms.MenuItem();
         this._miSegClearSegments = new System.Windows.Forms.MenuItem();
         this._miColor = new System.Windows.Forms.MenuItem();
         this._miColorResolution = new System.Windows.Forms.MenuItem();
         this._miColorHistogram = new System.Windows.Forms.MenuItem();
         this._miColorUniqueColors = new System.Windows.Forms.MenuItem();
         this._miPreference = new System.Windows.Forms.MenuItem();
         this._miPrefSegAndComOptions = new System.Windows.Forms.MenuItem();
         this._miPrefSeperator1 = new System.Windows.Forms.MenuItem();
         this._miPrefShowSegType = new System.Windows.Forms.MenuItem();
         this._miWindow = new System.Windows.Forms.MenuItem();
         this._miWindowCascade = new System.Windows.Forms.MenuItem();
         this._miWindowTileHorizontally = new System.Windows.Forms.MenuItem();
         this._miWindowTileVertically = new System.Windows.Forms.MenuItem();
         this._miWindowArrangeIcons = new System.Windows.Forms.MenuItem();
         this._miWindowCloseAll = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.menuItem2 = new System.Windows.Forms.MenuItem();
         this.menuItem3 = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // _mainMenu
         // 
         this._mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miEdit,
            this._miView,
            this._miSegmentation,
            this._miColor,
            this._miPreference,
            this._miWindow,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileOpenImage,
            this._miFileOpenMrc,
            this._miFileSeperator1,
            this._miFileTwainSelectSource,
            this._miFileTwainAcquire,
            this._miFileSeperator2,
            this._miFileSave,
            this._miFileSaveLeadMrc,
            this._miFileSaveMrc,
            this._miFileSavePDF,
            this._miFileSaveMultiPage,
            this._miFileSeperator3,
            this._miFileExportSegment,
            this._miFileImportSegment,
            this._miFileSeperator4,
            this._miFileExit});
         this._miFile.Text = "&File";
         this._miFile.Popup += new System.EventHandler(this._menusPopUp);
         // 
         // _miFileOpenImage
         // 
         this._miFileOpenImage.Index = 0;
         this._miFileOpenImage.RadioCheck = true;
         this._miFileOpenImage.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this._miFileOpenImage.Text = "Open &Image...";
         this._miFileOpenImage.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileOpenMrc
         // 
         this._miFileOpenMrc.Index = 1;
         this._miFileOpenMrc.Text = "Open &Mrc...";
         this._miFileOpenMrc.Click += new System.EventHandler(this._miFileOpenMrc_Click);
         // 
         // _miFileSeperator1
         // 
         this._miFileSeperator1.Index = 2;
         this._miFileSeperator1.Text = "-";
         // 
         // _miFileTwainSelectSource
         // 
         this._miFileTwainSelectSource.Index = 3;
         this._miFileTwainSelectSource.RadioCheck = true;
         this._miFileTwainSelectSource.Text = "TWAIN Se&lect Source...";
         this._miFileTwainSelectSource.Click += new System.EventHandler(this._miFileTwainSelectSource_Click);
         // 
         // _miFileTwainAcquire
         // 
         this._miFileTwainAcquire.Index = 4;
         this._miFileTwainAcquire.RadioCheck = true;
         this._miFileTwainAcquire.Text = "TWAIN Ac&quire...";
         this._miFileTwainAcquire.Click += new System.EventHandler(this._miFileTwainAcquire_Click);
         // 
         // _miFileSeperator2
         // 
         this._miFileSeperator2.Index = 5;
         this._miFileSeperator2.Text = "-";
         // 
         // _miFileSave
         // 
         this._miFileSave.Index = 6;
         this._miFileSave.RadioCheck = true;
         this._miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this._miFileSave.Text = "Sa&ve As...";
         this._miFileSave.Click += new System.EventHandler(this._miFileSave_Click);
         // 
         // _miFileSaveLeadMrc
         // 
         this._miFileSaveLeadMrc.Index = 7;
         this._miFileSaveLeadMrc.Text = "Save As &Lead Mrc...";
         this._miFileSaveLeadMrc.Click += new System.EventHandler(this._miFileSaveLeadMrc_Click);
         // 
         // _miFileSaveMrc
         // 
         this._miFileSaveMrc.Index = 8;
         this._miFileSaveMrc.Text = "&Save As Mrc...";
         this._miFileSaveMrc.Click += new System.EventHandler(this._miFileSaveMrc_Click);
         // 
         // _miFileSavePDF
         // 
         this._miFileSavePDF.Index = 9;
         this._miFileSavePDF.Text = "Save As &PDF...";
         this._miFileSavePDF.Click += new System.EventHandler(this._miFileSavePDF_Click);
         // 
         // _miFileSaveMultiPage
         // 
         this._miFileSaveMultiPage.Index = 10;
         this._miFileSaveMultiPage.Text = "Save Multi-Pa&ge...";
         this._miFileSaveMultiPage.Click += new System.EventHandler(this._miFileSaveMultiPage_Click);
         // 
         // _miFileSeperator3
         // 
         this._miFileSeperator3.Index = 11;
         this._miFileSeperator3.RadioCheck = true;
         this._miFileSeperator3.Text = "-";
         // 
         // _miFileExportSegment
         // 
         this._miFileExportSegment.Enabled = false;
         this._miFileExportSegment.Index = 12;
         this._miFileExportSegment.Text = "&Export Segments...";
         this._miFileExportSegment.Click += new System.EventHandler(this._miFileExportSegment_Click);
         // 
         // _miFileImportSegment
         // 
         this._miFileImportSegment.Index = 13;
         this._miFileImportSegment.Text = "&Import Segments...";
         this._miFileImportSegment.Click += new System.EventHandler(this._miFileImportSegment_Click);
         // 
         // _miFileSeperator4
         // 
         this._miFileSeperator4.Index = 14;
         this._miFileSeperator4.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 15;
         this._miFileExit.RadioCheck = true;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miEdit
         // 
         this._miEdit.Index = 1;
         this._miEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miEditUndo,
            this._EditSeperator1,
            this._miEditCopy,
            this._miEditPaste,
            this._EditSeperator2,
            this._miEditSelectAllSegments,
            this._miEditDeselectAll,
            this._miEditDeleteSelectedSegment});
         this._miEdit.Text = "&Edit";
         this._miEdit.Popup += new System.EventHandler(this._miEdit_Popup);
         // 
         // _miEditUndo
         // 
         this._miEditUndo.Index = 0;
         this._miEditUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
         this._miEditUndo.Text = "&Undo";
         this._miEditUndo.Click += new System.EventHandler(this._miEditUndo_Click);
         // 
         // _EditSeperator1
         // 
         this._EditSeperator1.Index = 1;
         this._EditSeperator1.Text = "-";
         // 
         // _miEditCopy
         // 
         this._miEditCopy.Index = 2;
         this._miEditCopy.RadioCheck = true;
         this._miEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
         this._miEditCopy.Text = "&Copy";
         this._miEditCopy.Click += new System.EventHandler(this._miEditCopy_Click);
         // 
         // _miEditPaste
         // 
         this._miEditPaste.Index = 3;
         this._miEditPaste.RadioCheck = true;
         this._miEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
         this._miEditPaste.Text = "&Paste";
         this._miEditPaste.Click += new System.EventHandler(this._miEditPaste_Click);
         // 
         // _EditSeperator2
         // 
         this._EditSeperator2.Index = 4;
         this._EditSeperator2.Text = "-";
         // 
         // _miEditSelectAllSegments
         // 
         this._miEditSelectAllSegments.Index = 5;
         this._miEditSelectAllSegments.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
         this._miEditSelectAllSegments.Text = "Select All Segments";
         this._miEditSelectAllSegments.Click += new System.EventHandler(this._miEditSelectAllSegments_Click);
         // 
         // _miEditDeselectAll
         // 
         this._miEditDeselectAll.Index = 6;
         this._miEditDeselectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
         this._miEditDeselectAll.Text = "&Deselect All";
         this._miEditDeselectAll.Click += new System.EventHandler(this._miEditDeselectAll_Click);
         // 
         // _miEditDeleteSelectedSegment
         // 
         this._miEditDeleteSelectedSegment.Index = 7;
         this._miEditDeleteSelectedSegment.Shortcut = System.Windows.Forms.Shortcut.Del;
         this._miEditDeleteSelectedSegment.Text = "Delete Selected Segment";
         this._miEditDeleteSelectedSegment.Click += new System.EventHandler(this._miDeleteSelectedSegment_Click);
         // 
         // _miView
         // 
         this._miView.Index = 2;
         this._miView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miViewSelectedSegment,
            this._viewSeperator1,
            this._miViewFitToWindow,
            this._miViewNormal,
            this._miViewZoomIn,
            this._miViewZoomOut});
         this._miView.Text = "&View";
         this._miView.Popup += new System.EventHandler(this._menusPopUp);
         // 
         // _miViewSelectedSegment
         // 
         this._miViewSelectedSegment.Index = 0;
         this._miViewSelectedSegment.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miViewEnlargeSegment,
            this._miViewShowInNewWindow,
            this._viewSeperator2,
            this._miViewShowType,
            this._miViewShowProperties,
            this._miViewShowHistogram,
            this._miViewUniqueColors,
            this._viewSeperator3,
            this._miViewCombineSegments});
         this._miViewSelectedSegment.Text = "Selected Segment";
         this._miViewSelectedSegment.Popup += new System.EventHandler(this._miViewSelectedSegment_Popup);
         // 
         // _miViewEnlargeSegment
         // 
         this._miViewEnlargeSegment.Index = 0;
         this._miViewEnlargeSegment.Text = "Enlarge Segment";
         this._miViewEnlargeSegment.Click += new System.EventHandler(this._miViewEnlargeSegment_Click);
         // 
         // _miViewShowInNewWindow
         // 
         this._miViewShowInNewWindow.Index = 1;
         this._miViewShowInNewWindow.Text = "Show In New Window";
         this._miViewShowInNewWindow.Click += new System.EventHandler(this._miViewShowInNewWindow_Click);
         // 
         // _viewSeperator2
         // 
         this._viewSeperator2.Index = 2;
         this._viewSeperator2.Text = "-";
         // 
         // _miViewShowType
         // 
         this._miViewShowType.Index = 3;
         this._miViewShowType.Text = "Show Type...";
         this._miViewShowType.Click += new System.EventHandler(this._miViewShowType_Click);
         // 
         // _miViewShowProperties
         // 
         this._miViewShowProperties.Index = 4;
         this._miViewShowProperties.Text = "Show Properties...";
         this._miViewShowProperties.Click += new System.EventHandler(this._miViewShowProperties_Click);
         // 
         // _miViewShowHistogram
         // 
         this._miViewShowHistogram.Index = 5;
         this._miViewShowHistogram.Text = "Show Histogram...";
         this._miViewShowHistogram.Click += new System.EventHandler(this._miViewShowHistogram_Click);
         // 
         // _miViewUniqueColors
         // 
         this._miViewUniqueColors.Index = 6;
         this._miViewUniqueColors.Text = "Unique Colors...";
         this._miViewUniqueColors.Click += new System.EventHandler(this._miViewUniqueColors_Click);
         // 
         // _viewSeperator3
         // 
         this._viewSeperator3.Index = 7;
         this._viewSeperator3.Text = "-";
         // 
         // _miViewCombineSegments
         // 
         this._miViewCombineSegments.Index = 8;
         this._miViewCombineSegments.Text = "Combine Segments";
         this._miViewCombineSegments.Click += new System.EventHandler(this._miViewCombineSegments_Click);
         // 
         // _viewSeperator1
         // 
         this._viewSeperator1.Index = 1;
         this._viewSeperator1.Text = "-";
         // 
         // _miViewFitToWindow
         // 
         this._miViewFitToWindow.Index = 2;
         this._miViewFitToWindow.Text = "&Fit To Window";
         this._miViewFitToWindow.Click += new System.EventHandler(this._miView_Click);
         // 
         // _miViewNormal
         // 
         this._miViewNormal.Index = 3;
         this._miViewNormal.Text = "&Normal";
         this._miViewNormal.Click += new System.EventHandler(this._miView_Click);
         // 
         // _miViewZoomIn
         // 
         this._miViewZoomIn.Index = 4;
         this._miViewZoomIn.Text = "Zoom &In +";
         this._miViewZoomIn.Click += new System.EventHandler(this._miView_Click);
         // 
         // _miViewZoomOut
         // 
         this._miViewZoomOut.Index = 5;
         this._miViewZoomOut.Text = "Zoom &Out -";
         this._miViewZoomOut.Click += new System.EventHandler(this._miView_Click);
         // 
         // _miSegmentation
         // 
         this._miSegmentation.Index = 3;
         this._miSegmentation.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miSegDraw,
            this.menuItem1,
            this._miSegSeperator1,
            this._miSegStartClearManual,
            this._miSegStartPreserveManual,
            this._miSegSeperator2,
            this._miSegClearSegments});
         this._miSegmentation.Text = "&Segmentation";
         this._miSegmentation.Popup += new System.EventHandler(this._miSegmentation_Popup);
         // 
         // _miSegDraw
         // 
         this._miSegDraw.Index = 0;
         this._miSegDraw.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miSegDrawSegment,
            this._miSegDrawCancelDrawing});
         this._miSegDraw.Text = "Draw";
         // 
         // _miSegDrawSegment
         // 
         this._miSegDrawSegment.Index = 0;
         this._miSegDrawSegment.Text = "Draw Se&gment";
         this._miSegDrawSegment.Click += new System.EventHandler(this._miSegDrawSegment_Click);
         // 
         // _miSegDrawCancelDrawing
         // 
         this._miSegDrawCancelDrawing.Enabled = false;
         this._miSegDrawCancelDrawing.Index = 1;
         this._miSegDrawCancelDrawing.Text = "Cancel D&rawing";
         this._miSegDrawCancelDrawing.Click += new System.EventHandler(this._miSegDrawCancelDrawing_Click);
         // 
         // _miSegSeperator1
         // 
         this._miSegSeperator1.Index = 2;
         this._miSegSeperator1.Text = "-";
         // 
         // _miSegStartClearManual
         // 
         this._miSegStartClearManual.Index = 3;
         this._miSegStartClearManual.Text = "Start Auto And C&lear Manual Segment";
         this._miSegStartClearManual.Click += new System.EventHandler(this._miSegStartClearManual_Click);
         // 
         // _miSegStartPreserveManual
         // 
         this._miSegStartPreserveManual.Enabled = false;
         this._miSegStartPreserveManual.Index = 4;
         this._miSegStartPreserveManual.Text = "Start Auto And P&reserve Manual Segment";
         this._miSegStartPreserveManual.Click += new System.EventHandler(this._miSegStartPreserveManual_Click);
         // 
         // _miSegSeperator2
         // 
         this._miSegSeperator2.Index = 5;
         this._miSegSeperator2.Text = "-";
         // 
         // _miSegClearSegments
         // 
         this._miSegClearSegments.Enabled = false;
         this._miSegClearSegments.Index = 6;
         this._miSegClearSegments.Text = "&Clear Segments";
         this._miSegClearSegments.Click += new System.EventHandler(this._miSegClearSegments_Click);
         // 
         // _miColor
         // 
         this._miColor.Index = 4;
         this._miColor.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miColorResolution,
            this._miColorHistogram,
            this._miColorUniqueColors});
         this._miColor.Text = "&Color";
         this._miColor.Popup += new System.EventHandler(this._menusPopUp);
         // 
         // _miColorResolution
         // 
         this._miColorResolution.Index = 0;
         this._miColorResolution.Text = "Color &Resolution...";
         this._miColorResolution.Click += new System.EventHandler(this._miColorResolution_Click);
         // 
         // _miColorHistogram
         // 
         this._miColorHistogram.Index = 1;
         this._miColorHistogram.Text = "View &Histogram...";
         this._miColorHistogram.Click += new System.EventHandler(this._miColorHistogram_Click);
         // 
         // _miColorUniqueColors
         // 
         this._miColorUniqueColors.Index = 2;
         this._miColorUniqueColors.Text = "&Unique Colors...";
         this._miColorUniqueColors.Click += new System.EventHandler(this._miColorUniqueColors_Click);
         // 
         // _miPreference
         // 
         this._miPreference.Index = 5;
         this._miPreference.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miPrefSegAndComOptions,
            this._miPrefSeperator1,
            this._miPrefShowSegType});
         this._miPreference.Text = "&Preference";
         this._miPreference.Popup += new System.EventHandler(this._menusPopUp);
         // 
         // _miPrefSegAndComOptions
         // 
         this._miPrefSegAndComOptions.Index = 0;
         this._miPrefSegAndComOptions.Text = "Segmentation And Compression &Options...";
         this._miPrefSegAndComOptions.Click += new System.EventHandler(this._miPrefSegAndComOptions_Click);
         // 
         // _miPrefSeperator1
         // 
         this._miPrefSeperator1.Index = 1;
         this._miPrefSeperator1.Text = "-";
         // 
         // _miPrefShowSegType
         // 
         this._miPrefShowSegType.Checked = true;
         this._miPrefShowSegType.Index = 2;
         this._miPrefShowSegType.Text = "Show Segments &Type";
         this._miPrefShowSegType.Click += new System.EventHandler(this._miPrefShowSegType_Click);
         // 
         // _miWindow
         // 
         this._miWindow.Index = 6;
         this._miWindow.MdiList = true;
         this._miWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miWindowCascade,
            this._miWindowTileHorizontally,
            this._miWindowTileVertically,
            this._miWindowArrangeIcons,
            this._miWindowCloseAll});
         this._miWindow.Text = "&Window";
         // 
         // _miWindowCascade
         // 
         this._miWindowCascade.Index = 0;
         this._miWindowCascade.Shortcut = System.Windows.Forms.Shortcut.ShiftF5;
         this._miWindowCascade.Text = "&Cascade";
         this._miWindowCascade.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowTileHorizontally
         // 
         this._miWindowTileHorizontally.Index = 1;
         this._miWindowTileHorizontally.Shortcut = System.Windows.Forms.Shortcut.ShiftF4;
         this._miWindowTileHorizontally.Text = "Tile &Horizontally";
         this._miWindowTileHorizontally.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowTileVertically
         // 
         this._miWindowTileVertically.Index = 2;
         this._miWindowTileVertically.Text = "Tile &Vertically";
         this._miWindowTileVertically.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowArrangeIcons
         // 
         this._miWindowArrangeIcons.Index = 3;
         this._miWindowArrangeIcons.Text = "Arrange &Icons";
         this._miWindowArrangeIcons.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowCloseAll
         // 
         this._miWindowCloseAll.Index = 4;
         this._miWindowCloseAll.Text = "Close &All";
         this._miWindowCloseAll.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 7;
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
         // menuItem1
         // 
         this.menuItem1.Index = 1;
         this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3});
         this.menuItem1.Text = "Segmentation &Method";
         // 
         // menuItem2
         // 
         this.menuItem2.Checked = true;
         this.menuItem2.Index = 0;
         this.menuItem2.Text = "N&ormal Segmentation";
         this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
         // 
         // menuItem3
         // 
         this.menuItem3.Index = 1;
         this.menuItem3.Text = "Ad&vanced Feature-Based Segmentation";
         this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
         // 
         // MainForm
         // 
         this.AllowDrop = true;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(712, 471);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.IsMdiContainer = true;
         this.Menu = this._mainMenu;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
         this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
         this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
         this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
         this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
         this.ResumeLayout(false);

      }
      #endregion

      private RasterCodecs _codecs;
      private RasterColor _fillColor;

      private TwainSession _twainSession;
      private int _acquirePageCount;
      private bool _inTwainAcquire;
      private RasterPaintProperties _paintProperties;

      private static readonly float _minimumScaleFactor = 0.05f;
      private static readonly float _maximumScaleFactor = 11f;

      //    Mrc:
      public int _pictureCoder;
      public int _grayscaleCoder8Bit;
      public int _textCoder2Bit;
      public int _grayscaleCoder2Bit;
      public int _maskCoder;
      public int _qFactor;
      public int _gSQFactor;

      //    PDF:
      public int _pDFPictureCoder;
      public int _pDFTextCoder2Bit;
      public int _pDFMaskCoder;
      public int _pDFQFactor;

      //    Segmentation:
      public int _inputImageType;
      public int _outputImageType;

      public int _bGThreshold;
      public int _cleanSize;
      public int _combineThreshold;
      public int _quality;
      public int _clrThreshold;
      public int _typeIndex;
      public bool _check;

      public int _userDefineBGThreshold;
      public int _userDefineCleanSize;
      public int _userDefineCombineThreshold;
      public int _userDefineQuality;
      public int _userDefineclrThreshold;
      public int _userDefineTypeIndex;
      public bool _userDefineCheck;

      public bool _segmentationMethod;

      //    Combine:
      public int _combineType;
      public int _combineFactor;

      public Color _backColor;
      public Color _foreColor;

      private MenuItem checkedWindowMenu;
      private MenuItem checkedViewMenu;

      private bool _setPdfOptions;
      private int _xResolution;
      private int _yResolution;

      private string _openInitialPath = string.Empty;

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main( )
      {
         if (!Support.SetLicense())
            return;

         if (RasterSupport.IsLocked(RasterSupportType.Document))
         {
            MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }

         Application.EnableVisualStyles();
         Application.DoEvents();

         Application.Run(new MainForm());
      }

      private void InitClass( )
      {
         Messager.Caption = "LEADTOOLS for .NET C# Mrc Segmentation Demo";
         Text = Messager.Caption;

         _codecs = new RasterCodecs();

         _fillColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White);
         _paintProperties = RasterPaintProperties.Default;
         _paintProperties.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray;

         checkedWindowMenu = _miWindowCascade;
         checkedWindowMenu.Checked = true;

         checkedViewMenu = _miViewNormal;
         checkedViewMenu.Checked = true;

         //    Mrc:
         _pictureCoder = 6;
         _grayscaleCoder8Bit = 4;
         _textCoder2Bit = 0;
         _grayscaleCoder2Bit = 0;
         _maskCoder = 0;
         _qFactor = 20;
         _gSQFactor = 20;

         //    PDF:
         _pDFPictureCoder = 2;
         _pDFTextCoder2Bit = 0;
         _pDFMaskCoder = 0;
         _pDFQFactor = 50;

         //    Segmentation:
         _inputImageType = 0;
         _outputImageType = 0;

         _bGThreshold = 15;
         _cleanSize = 7;
         _combineThreshold = 100;
         _quality = 50;
         _clrThreshold = 25;
         _typeIndex = 1;
         _check = false;

         _userDefineBGThreshold = 15;
         _userDefineCleanSize = 7;
         _userDefineCombineThreshold = 100;
         _userDefineclrThreshold = 25;
         _userDefineQuality = 50;
         _userDefineTypeIndex = 1;
         _userDefineCheck = false;

         _segmentationMethod = false;


         //    Combine:
         _combineType = 2;
         _combineFactor = 30;

         _backColor = Color.White;
         _foreColor = Color.Black;

         _setPdfOptions = false;
         _xResolution = 150;
         _yResolution = 150;


         try
         {
            using(WaitCursor wait = new WaitCursor())
            {

               if (TwainSession.IsAvailable(this.Handle))
               {
                  _twainSession = new TwainSession();

                  _twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
                  _twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(_twainSession_AcquirePage);
               }
            }
         }
         catch (TwainException ex)
         {
            if (ex.Code == TwainExceptionCode.InvalidDll)
            {
               _twainSession = null;
               Messager.ShowError(this, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org");
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

         LoadMRC(true);
         UpdateControls();

         menuItem1.Visible = false;
      }

      private void CleanUp( )
      {

         if(_twainSession != null)
         {
            try
            {
               _twainSession.Shutdown();
            }
            catch(Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      public MenuItem ZoomIn
      {
         get
         {
            return _miViewZoomIn;
         }
      }

      public MenuItem ZoomOut
      {
         get
         {
            return _miViewZoomOut;
         }
      }

      public MenuItem PreserveManualMenuItem
      {
         get
         {
            return _miSegStartPreserveManual;
         }
      }

      public ViewerForm ActiveViewerForm
      {
         get
         {
            return ActiveMdiChild as ViewerForm;
         }
      }

      public bool ShowSegmentType
      {
         get
         {
            return _miPrefShowSegType.Checked;
         }
      }

      public void UpdateControls( )
      {
         ViewerForm activeForm = ActiveViewerForm;

         EnableAndVisibleMenu(_miFileTwainSelectSource, _twainSession != null);
         EnableAndVisibleMenu(_miFileTwainAcquire, _twainSession != null);
         EnableAndVisibleMenu(_miFileSeperator2, _twainSession != null);
         EnableAndVisibleMenu(_miFileSave, activeForm != null);
         EnableAndVisibleMenu(_miFileSaveLeadMrc, activeForm != null);
         EnableAndVisibleMenu(_miFileSaveMrc, activeForm != null);
         EnableAndVisibleMenu(_miFileSavePDF, activeForm != null);
         EnableAndVisibleMenu(_miFileSaveMultiPage, activeForm != null);
         EnableAndVisibleMenu(_miFileSeperator3, activeForm != null);
         EnableAndVisibleMenu(_miFileExportSegment, activeForm != null);
         EnableAndVisibleMenu(_miFileImportSegment, activeForm != null);
         EnableAndVisibleMenu(_miFileSeperator4, activeForm != null);
         EnableAndVisibleMenu(_miEditUndo, activeForm != null);
         EnableAndVisibleMenu(_EditSeperator1, activeForm != null);
         EnableAndVisibleMenu(_miEditCopy, activeForm != null);
         EnableAndVisibleMenu(_EditSeperator2, activeForm != null);
         EnableAndVisibleMenu(_miEditSelectAllSegments, activeForm != null);
         EnableAndVisibleMenu(_miEditDeleteSelectedSegment, activeForm != null);
         EnableAndVisibleMenu(_miEditDeselectAll, activeForm != null);
         EnableAndVisibleMenu(_miView, activeForm != null);
         if(activeForm != null)
         {
            EnableAndVisibleMenu(_miEditSelectAllSegments, activeForm.MrcStarted);
            EnableAndVisibleMenu(_miEditDeleteSelectedSegment, activeForm.MrcStarted);
            EnableAndVisibleMenu(_miEditDeselectAll, activeForm.MrcStarted);
            EnableAndVisibleMenu(_EditSeperator2, activeForm.MrcStarted);
            EnableAndVisibleMenu(_miViewSelectedSegment, activeForm.MrcStarted);
            EnableAndVisibleMenu(_viewSeperator1, activeForm.MrcStarted);
            EnableAndVisibleMenu(_miViewSelectedSegment, (activeForm.SelectedSegment >= 0));
            EnableAndVisibleMenu(_viewSeperator1, (activeForm.SelectedSegment >= 0));
            _miEditDeselectAll.Enabled = (activeForm.SelectedSegment >= 0);
         }
         EnableAndVisibleMenu(_miSegmentation, activeForm != null);
         EnableAndVisibleMenu(_miColor, activeForm != null);
         EnableAndVisibleMenu(_miPreference, activeForm != null);
         EnableAndVisibleMenu(_miWindow, activeForm != null);
      }

      private void EnableAndVisibleMenu(MenuItem menu, bool value)
      {
         menu.Enabled = value;
         menu.Visible = value;
      }

      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         try
         {
            ImageInformation info = LoadImage();
             
            if (info != null)
               NewImage(info);
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

      private void _miFileOpenMrc_Click(object sender, System.EventArgs e)
      {
         LoadMRC(false);
         UpdateControls();
      }

      private void LoadMRC(bool loadDefaultImage)
      {
         string fileName = String.Empty;

         try
         {
            if (loadDefaultImage)
               fileName = DemosGlobal.ImagesFolder + @"\sample.mrc";
            else
            {
               OpenFileDialog ofd = new OpenFileDialog();

               ofd.Filter = "Mrc Files (*.mrc)|*.mrc";
               ofd.Title = "Open Mrc";

               if (ofd.ShowDialog() == DialogResult.OK)
                  fileName = ofd.FileName;
            }
            if (!String.IsNullOrEmpty(fileName))
            {
               RasterImage image = MrcSegmenter.LoadImage(fileName, 1);
               NewImage(new ImageInformation(image, fileName));
            }
               
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, fileName, ex);
         }
      }

      private void _miFileSave_Click(object sender, System.EventArgs e)
      {
         ImageFileSaver saver = new ImageFileSaver();

         try
         {
            saver.Save(this, _codecs, ActiveViewerForm.Viewer.Image);
         }
         catch(Exception ex)
         {
            Messager.ShowFileSaveError(this, saver.FileName, ex);
         }
      }

      private void _miFileTwainSelectSource_Click(object sender, System.EventArgs e)
      {
         _inTwainAcquire = true;
         try
         {
            if(_twainSession != null)
               _twainSession.SelectSource(String.Empty);
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         _inTwainAcquire = false;
      }

      private void _miFileTwainAcquire_Click(object sender, System.EventArgs e)
      {
         _inTwainAcquire = true;
         _acquirePageCount = 1;

         try
         {
            if(_twainSession != null)
            {
               if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, _twainSession.SelectedSourceName()))
                  return;
               DialogResult res = _twainSession.Acquire(TwainUserInterfaceFlags.Modal | TwainUserInterfaceFlags.Show);
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            _acquirePageCount = -1;
            _inTwainAcquire = false;
         }
      }

      private void _twainSession_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         Application.DoEvents();

         if(e.Image != null)
         {
            if(_acquirePageCount == 1)
               NewImage(new ImageInformation(e.Image, "Twain Image"));
            else
               ActiveViewerForm.Image.AddPage(e.Image);

            _acquirePageCount++;
         }
      }

      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void MainForm_MdiChildActivate(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void _miEdit_Popup(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         if(activeViewer == null)
            return;



         _miEditPaste.Enabled = RasterClipboard.IsReady;

         _miEditSelectAllSegments.Enabled = activeViewer.MrcStarted;

         if(activeViewer.SelectedSegment == -1)
         {
            _miEditSelectAllSegments.Enabled = false;
         }
         else
         {
            _miEditSelectAllSegments.Enabled = _miEditDeleteSelectedSegment.Enabled = true;
         }

         _miEditDeselectAll.Enabled = (!_miEditSelectAllSegments.Enabled) || (activeViewer.SelectedSegment >= 0);

         _miEditUndo.Enabled = activeViewer.EnableUndo;
      }

      private void _miEditCopy_Click(object sender, System.EventArgs e)
      {
         try
         {
            using(WaitCursor wait = new WaitCursor())
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
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _miEditPaste_Click(object sender, System.EventArgs e)
      {
         try
         {
            using(WaitCursor wait = new WaitCursor())
            {
               RasterImage image = RasterClipboard.Paste(this.Handle);
               if(image != null)
               {
                  ViewerForm activeForm = ActiveViewerForm;

                  if(image.HasRegion && activeForm == null)
                     image.MakeRegionEmpty();

                  if(image.HasRegion)
                  {
                     // make sure the images have the same BitsPerPixel and Palette
                     if(activeForm.Viewer.Image.BitsPerPixel > 8)
                     {
                        if(image.BitsPerPixel != activeForm.Viewer.Image.BitsPerPixel)
                        {
                           try
                           {
                              ColorResolutionCommand colorRes = new ColorResolutionCommand();
                              colorRes.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel;
                              colorRes.Order = activeForm.Viewer.Image.Order;
                              colorRes.Mode = Leadtools.ImageProcessing.ColorResolutionCommandMode.InPlace;
                              colorRes.Run(image);
                           }
                           catch(Exception ex)
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
                           colorRes.PaletteFlags = Leadtools.ImageProcessing.ColorResolutionCommandPaletteFlags.UsePalette;
                           colorRes.Mode = Leadtools.ImageProcessing.ColorResolutionCommandMode.InPlace;
                           colorRes.Run(image);
                        }
                        catch(Exception ex)
                        {
                           Messager.ShowError(this, ex);
                        }
                     }
                  }
                  else
                     NewImage(new ImageInformation(image));
               }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("Mrc Segmentation", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("Mrc Segmentation"))
            aboutDialog.ShowDialog(this);
#endif
      }

      private void _miWindow_Click(object sender, System.EventArgs e)
      {
         checkedWindowMenu.Checked = false;

         if(sender == _miWindowCascade)
         {
            LayoutMdi(MdiLayout.Cascade);
            checkedWindowMenu = _miWindowCascade;
         }
         else if(sender == _miWindowTileHorizontally)
         {
            LayoutMdi(MdiLayout.TileHorizontal);
            checkedWindowMenu = _miWindowTileHorizontally;
         }
         else if(sender == _miWindowTileVertically)
         {
            LayoutMdi(MdiLayout.TileVertical);
            checkedWindowMenu = _miWindowTileVertically;
         }
         else if(sender == _miWindowArrangeIcons)
         {
            LayoutMdi(MdiLayout.ArrangeIcons);
            checkedWindowMenu = _miWindowArrangeIcons;
         }
         else if(sender == _miWindowCloseAll)
         {
            while(MdiChildren.Length > 0)
               MdiChildren[0].Close();
            UpdateControls();
            checkedWindowMenu = _miWindowCascade;
         }
         checkedWindowMenu.Checked = true;
      }


      private ImageInformation LoadImage()
      {
         ImageFileLoader loader = new ImageFileLoader();

         loader.OpenDialogInitialPath = _openInitialPath;

         try
         {
            if (loader.Load(this, _codecs, false) > 0)
            {


               using (WaitCursor wait = new WaitCursor())
               {
                  RasterImage loadedImage = _codecs.Load(loader.FileName, 0, CodecsLoadByteOrder.BgrOrGray, loader.FirstPage, loader.LastPage);
                  _openInitialPath = Path.GetDirectoryName(loader.FileName);
                  if (loadedImage.HasRegion)
                     loadedImage.MakeRegionEmpty();
                  return new ImageInformation(loadedImage, loader.FileName);
               }
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
         ViewerForm child = new ViewerForm();
         child.MdiParent = this;
         child.Initialize(info, _paintProperties, true);
         child.Show();
      }

      private RasterImage ImageToRun
      {
         get
         {
            ViewerForm activeForm = ActiveViewerForm;

            return activeForm.Viewer.Image;
         }
         set
         {
            if(value != null)
            {
               ViewerForm activeForm = ActiveViewerForm;

               activeForm.Viewer.Image = value;
            }
         }
      }

      private void MainForm_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
      {
         if(Tools.CanDrop(e.Data))
            e.Effect = DragDropEffects.Copy;
      }

      private void MainForm_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
      {
         if(Tools.CanDrop(e.Data))
         {
            string[] files = Tools.GetDropFiles(e.Data);
            if(files != null)
               LoadDropFiles(null, files);
         }
      }

      public void LoadDropFiles(ViewerForm viewer, string[] files)
      {
         try
         {
            if(files != null)
            {
               for(int nI = 0; nI < files.Length; nI++)
               {
                  try
                  {
                     RasterImage image = _codecs.Load(files[nI]);
                     ImageInformation info = new ImageInformation(image, files[nI]);
                     if(nI == 0 && viewer != null)
                        viewer.Initialize(info, _paintProperties, false);
                     else
                        NewImage(info);
                  }
                  catch(Exception ex)
                  {
                     Messager.ShowFileOpenError(this, files[nI], ex);
                  }
               }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {

         if(_inTwainAcquire)
            e.Cancel = true;
      }

      private void _miColorResolution_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;
         ColorResolutionCommand command;
         ColorResolutionDialog colorResolutionDlg = new ColorResolutionDialog();

         colorResolutionDlg.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel;
         colorResolutionDlg.Order = activeForm.Viewer.Image.Order;

         if(colorResolutionDlg.ShowDialog(this) == DialogResult.OK)
         {
            command = new ColorResolutionCommand(ColorResolutionCommandMode.InPlace,
               colorResolutionDlg.BitsPerPixel, colorResolutionDlg.Order, colorResolutionDlg.DitheringMethod,
               colorResolutionDlg.PaletteFlags, null);

            command.Run(activeForm.Image);
         }
      }

      private void _miColorHistogram_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         activeViewer.ShowHistogram();
      }

      private void _miColorUniqueColors_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         activeViewer.GetUniqueColorsCount();
      }

      public void _miView_Click(object sender, System.EventArgs e)
      {
         // get the current center in logical units
         ImageViewer viewer = ActiveViewerForm.Viewer; // get the active viewer
         Rectangle rc = Rectangle.Intersect(viewer.ClientRectangle, viewer.ClientRectangle); // get what you see in physical coordinates
         PointF center = new PointF(rc.Left + rc.Width / 2, rc.Top + rc.Height / 2); // get the center of what you see in physical coordinates
         Transformer t = new Transformer(Tools.ToMatrix(viewer.ImageTransform)); 
         center = t.PointToLogical(center);  // get the center of what you see in logical coordinates

         // zoom     
         double scaleFactor = viewer.ScaleFactor;

         const float ratio = 1.2F;

         checkedViewMenu.Checked = false;

         if(sender == _miViewZoomIn)
         {
            scaleFactor *= ratio;
            checkedViewMenu = _miViewZoomIn;
         }
         else if(sender == _miViewZoomOut)
         {
            scaleFactor /= ratio;
            checkedViewMenu = _miViewZoomOut;
         }
         else if(sender == _miViewNormal)
         {
            scaleFactor = 1;
            if (viewer.SizeMode != ControlSizeMode.ActualSize)
               viewer.Zoom(ControlSizeMode.ActualSize, scaleFactor, viewer.DefaultZoomOrigin);
            checkedViewMenu = _miViewNormal;
         }
         else if(sender == _miViewFitToWindow)
         {
            viewer.BeginUpdate();
            viewer.Zoom(ControlSizeMode.Fit, scaleFactor, viewer.DefaultZoomOrigin);
            checkedViewMenu = _miViewFitToWindow;
            scaleFactor = 1;
            viewer.EndUpdate();
         }

         scaleFactor = Math.Max(_minimumScaleFactor, Math.Min(_maximumScaleFactor, scaleFactor));

         if(viewer.ScaleFactor != scaleFactor)
         {
            viewer.Zoom(ControlSizeMode.None, scaleFactor, viewer.DefaultZoomOrigin);
            // bring the original center into the view center
            t = new Transformer(Tools.ToMatrix(viewer.ImageTransform));
            center = t.PointToPhysical(center); // get the center of what you saw before the zoom in physical coordinates
            LeadPoint lPoint = new LeadPoint(Point.Round(center).X, Point.Round(center).Y);
            viewer.CenterAtPoint(lPoint); // bring the old center into the center of the view
         }
         checkedViewMenu.Checked = true;
      }

      private void _miSegStartClearManual_Click(object sender, System.EventArgs e)
      {
         CancelDrawing();
         ViewerForm activeViewer = ActiveViewerForm;
         activeViewer.AddSegment = false;
         activeViewer.AddToUndoList();

         

         using(WaitCursor wait = new WaitCursor())
         {
            activeViewer.StartAutoMrcSegmentation(false);
         }

         _miSegClearSegments.Enabled = true;
         _miSegStartPreserveManual.Enabled = true;
         _miSegDrawSegment.Enabled = true;
         _miSegDrawCancelDrawing.Enabled = false;
      }

      private void _miDeleteSelectedSegment_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;
         activeViewer.AddToUndoList();
         if(activeViewer.AddSegment)
            activeViewer.Viewer.Cursor = Cursors.Cross;
         else
            activeViewer.Viewer.Cursor = Cursors.Default;

         using(WaitCursor wait = new WaitCursor())
         {
            activeViewer.DeleteSelectedSegment();
         }
      }

      private void _miSegClearSegments_Click(object sender, System.EventArgs e)
      {
         CancelDrawing();
         ViewerForm activeViewer = ActiveViewerForm;
         activeViewer.AddToUndoList();

         using(WaitCursor wait = new WaitCursor())
         {
            activeViewer.ClearSegments();
         }

         _miSegDrawSegment.Enabled = true;
         _miSegStartPreserveManual.Enabled = false;
         _miSegClearSegments.Enabled = false;
         _miSegDrawCancelDrawing.Enabled = false;
         _miEditSelectAllSegments.Enabled = false;
         _miEditDeleteSelectedSegment.Enabled = false;
      }

      private void _miSegDrawSegment_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         activeViewer.AddSegment = true;

         _miSegDrawSegment.Enabled = false;
         _miSegDrawCancelDrawing.Enabled = true;
         activeViewer.Cursor = Cursors.Cross;
      }

      private void _miSegDrawCancelDrawing_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         activeViewer.AddSegment = false;

         _miSegDrawSegment.Enabled = true;
         _miSegDrawCancelDrawing.Enabled = false;
      }

      private void _miSegStartPreserveManual_Click(object sender, System.EventArgs e)
      {
         CancelDrawing();
         ViewerForm activeViewer = ActiveViewerForm;
         activeViewer.AddToUndoList();

         using(WaitCursor wait = new WaitCursor())
         {
            activeViewer.StartAutoMrcSegmentation(true);
         }
         _miSegClearSegments.Enabled = true;
      }

      private void _miPrefShowSegType_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         _miPrefShowSegType.Checked = !_miPrefShowSegType.Checked;

         activeViewer.Viewer.Invalidate(true);
      }

      private void _miEditSelectAllSegments_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;
         activeViewer.SelectAllSegments();
         _miEditSelectAllSegments.Enabled = false;
         activeViewer.SetSelectionArray(true);
         UpdateControls();
         activeViewer.Viewer.Invalidate(true);
      }

      private void _miFileSaveLeadMrc_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         RasterSaveDialogFileFormatsList saveDlgFormatList = new RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.User);

         // Adding Mrc format
         saveDlgFormatList.Add(RasterDialogFileTypesIndex.Mrc, RasterDialogBitsPerPixelDataContent.User);
         saveDlgFormatList[0].BitsPerPixelList.Add(RasterDialogFileTypesIndex.Mrc, 24, RasterDialogFileSubTypeDataContent.User);
         saveDlgFormatList[0].BitsPerPixelList[0].SubFormatsList.Add(RasterDialogFileTypesIndex.Mrc, 24, (int)RasterDialogMrcSubTypesIndex.LeadMrc);

         // Adding Tiff format
         saveDlgFormatList.Add(RasterDialogFileTypesIndex.Tiff, RasterDialogBitsPerPixelDataContent.User);
         saveDlgFormatList[1].BitsPerPixelList.Add(RasterDialogFileTypesIndex.Tiff, 24, RasterDialogFileSubTypeDataContent.User);
         saveDlgFormatList[1].BitsPerPixelList[0].SubFormatsList.Add(RasterDialogFileTypesIndex.Tiff, 24, (int)RasterDialogTiff24SubTypesIndex.LeadMrc);

         ImageFileSaver saver = new ImageFileSaver();

         saver.SaveFormats = saveDlgFormatList;
         saver.AutoSave = false;

         try
         {
            if(saver.Save(this, _codecs, activeViewer.Image))
            {
               using(WaitCursor wait = new WaitCursor())
               {
                  activeViewer.SaveLeadMrc(saver.FileName, _codecs, saver.Format);
               }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowFileSaveError(this, saver.FileName, ex);
         }
      }

      public void CancelDrawing( )
      {
         ViewerForm activeViewer = ActiveViewerForm;

         activeViewer.AddSegment = false;
         activeViewer.DrawNewSegment = false;
         _miSegDrawSegment.Enabled = true;
         _miSegDrawCancelDrawing.Enabled = false;

         activeViewer.Cursor = Cursors.Default;
         activeViewer.Invalidate(true);
      }

      private void _menusPopUp(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         if(activeViewer != null)
         {


            if(sender == _miFile)
            {
               _miFileExportSegment.Enabled = activeViewer.MrcStarted;
            }
         }
      }

      private void _miPrefSegAndComOptions_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;
         Options optionsDialog = new Options();

         activeViewer.SetValuesToDialog(ref optionsDialog);
         optionsDialog.SetSelections();

         if(optionsDialog.ShowDialog() == DialogResult.OK)
         {
            using(WaitCursor wait = new WaitCursor())
            {
               activeViewer.SetValuesToVariables(optionsDialog);
               activeViewer.OptionsChanged = true;
            }
         }
      }

      private void _miFileSaveMrc_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         RasterSaveDialogFileFormatsList saveDlgFormatList = new RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.User);

         // Adding Mrc format
         saveDlgFormatList.Add(RasterDialogFileTypesIndex.Mrc, RasterDialogBitsPerPixelDataContent.User);
         saveDlgFormatList[0].BitsPerPixelList.Add(RasterDialogFileTypesIndex.Mrc, 24, RasterDialogFileSubTypeDataContent.User);
         saveDlgFormatList[0].BitsPerPixelList[0].SubFormatsList.Add(RasterDialogFileTypesIndex.Mrc, 24, (int)RasterDialogMrcSubTypesIndex.Mrc);

         // Adding Tiff format
         saveDlgFormatList.Add(RasterDialogFileTypesIndex.Tiff, RasterDialogBitsPerPixelDataContent.User);
         saveDlgFormatList[1].BitsPerPixelList.Add(RasterDialogFileTypesIndex.Tiff, 24, RasterDialogFileSubTypeDataContent.User);
         saveDlgFormatList[1].BitsPerPixelList[0].SubFormatsList.Add(RasterDialogFileTypesIndex.Tiff, 24, (int)RasterDialogTiff24SubTypesIndex.Mrc);

         ImageFileSaver saver = new ImageFileSaver();

         saver.SaveFormats = saveDlgFormatList;
         saver.AutoSave = false;

         try
         {
            if(saver.Save(this, _codecs, activeViewer.Image))
            {
               using(WaitCursor wait = new WaitCursor())
               {
                  activeViewer.SaveMrc(saver.FileName, _codecs, saver.Format);
               }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowFileSaveError(this, saver.FileName, ex);
         }
      }

      private void _miFileSavePDF_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         RasterSaveDialogFileFormatsList saveDlgFormatList = new RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.User);

         // Adding Pdf format
         saveDlgFormatList.Add(RasterDialogFileTypesIndex.Pdf, RasterDialogBitsPerPixelDataContent.User);
         saveDlgFormatList[0].BitsPerPixelList.Add(RasterDialogFileTypesIndex.Pdf, 24, RasterDialogFileSubTypeDataContent.User);
         saveDlgFormatList[0].BitsPerPixelList[0].SubFormatsList.Add(RasterDialogFileTypesIndex.Pdf, 24, (int)RasterDialogPdf24SubTypesIndex.Uncompressed);

         ImageFileSaver saver = new ImageFileSaver();

         saver.SaveFormats = saveDlgFormatList;

         try
         {
            if(saver.Save(this, _codecs, activeViewer.Image))
            {
               using(WaitCursor wait = new WaitCursor())
               {
                  activeViewer.SavePDF(saver.FileName, _codecs);
               }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowFileSaveError(this, saver.FileName, ex);
         }
      }

      private void _miFileExportSegment_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;
         SaveFileDialog dlg = new SaveFileDialog();

         dlg.Filter = "Segments files|*.sgm";
         dlg.Title = "Export Segments";

         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            using(WaitCursor wait = new WaitCursor())
            {
               activeViewer.SaveSegments(dlg.FileName);
            }
         }
      }

      private void _miFileImportSegment_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;
         OpenFileDialog dlg = new OpenFileDialog();

         dlg.Filter = "Segments files|*.sgm";
         dlg.Title = "Import Segments Files";

         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            using(WaitCursor wait = new WaitCursor())
            {
               activeViewer.LoadSegments(dlg.FileName);
               UpdateControls();
            }
         }
      }

      private void _miViewEnlargeSegment_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;
         activeViewer.AddToUndoList();

         activeViewer.EnlargeSegment();
      }

      public void _miViewShowInNewWindow_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         NewImage(new ImageInformation(activeViewer.GetRectangleAsImage()));
      }

      private void _miViewShowType_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         activeViewer.ShowSegmentType();
      }

      private void _miViewShowHistogram_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         activeViewer.ShowSegmentHistogram();
      }

      private void _miViewUniqueColors_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         activeViewer.GetSegmentUniqueColorsCount();
      }

      private void _miViewCombineSegments_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;
         activeViewer.AddToUndoList();

         activeViewer.CombineSegments();
      }

      private void _miViewSelectedSegment_Popup(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         if(activeViewer.SelectedSegment == -1)
            _miViewEnlargeSegment.Enabled = _miViewShowInNewWindow.Enabled =
               _miViewShowType.Enabled = _miViewShowProperties.Enabled =
               _miViewShowHistogram.Enabled = _miViewUniqueColors.Enabled = false;
         else
            _miViewEnlargeSegment.Enabled = _miViewShowInNewWindow.Enabled =
               _miViewShowType.Enabled = _miViewShowProperties.Enabled =
               _miViewShowHistogram.Enabled = _miViewUniqueColors.Enabled = true;

         if(activeViewer.SelectedCombineSegment == -1)
            _miViewCombineSegments.Enabled = false;
         else
            _miViewCombineSegments.Enabled = true;
      }

      private void _miEditUndo_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         activeViewer.Undo();

         activeViewer.Viewer.Invalidate(true);
      }

      private void _miViewShowProperties_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         activeViewer.ShowSegmentInformation();
      }

      public MrcPictureCompression GetPictureCompression(int index)
      {
         switch(index)
         {
            case 0:
               return MrcPictureCompression.Cmw;
            case 1:
               return MrcPictureCompression.LosslessCmw;
            case 2:
               return MrcPictureCompression.Cmp;
            case 3:
               return MrcPictureCompression.Jpeg;
            case 4:
               return MrcPictureCompression.LosslessJpeg;
            case 5:
               return MrcPictureCompression.JpegYUV422;
            case 6:
               return MrcPictureCompression.JpegYUV411;
            case 7:
               return MrcPictureCompression.JpegProgressive;
            case 8:
               return MrcPictureCompression.JpegProgressiveYUV422;
            default:
               return MrcPictureCompression.JpegProgressiveYUV411;
         }
      }

      public MrcGrayscaleCompression8BitCoder GetGrayscaleCompression8BitCoder(int index)
      {
         switch(index)
         {
            case 0:
               return MrcGrayscaleCompression8BitCoder.LosslessCmw;
            case 1:
               return MrcGrayscaleCompression8BitCoder.GrayscaleCmw;
            case 2:
               return MrcGrayscaleCompression8BitCoder.GrayscaleCmp;
            case 3:
               return MrcGrayscaleCompression8BitCoder.LosslessJpeg;
            case 4:
               return MrcGrayscaleCompression8BitCoder.GrayscaleJpeg;
            default:
               return MrcGrayscaleCompression8BitCoder.GrayscaleJpegProgressive;
         }
      }

      public MrcTextCompression2BitCoder GetTextCompressionCoder(int index)
      {
         switch(index)
         {
            case 0:
               return MrcTextCompression2BitCoder.Jbig2Bit;
            default:
               return MrcTextCompression2BitCoder.Gif2Bit;
         }
      }

      public MrcGrayscaleCompression2BitCoder GetGrayscaleCompression2BitCoder(int index)
      {
         switch(index)
         {
            default:
               return MrcGrayscaleCompression2BitCoder.Jbig2;
         }
      }

      public MrcMaskCompression GetMaskCompression(int index)
      {
         switch(index)
         {
            case 0:
               return MrcMaskCompression.Jbig;
            case 1:
               return MrcMaskCompression.FaxG4;
            case 2:
               return MrcMaskCompression.FaxG31D;
            default:
               return MrcMaskCompression.FaxG32D;
         }
      }

      public MrcMaskCompression GetPDF1Compression(int index)
      {
         switch(index)
         {
            case 0:
               return MrcMaskCompression.PdfZip;
            case 1:
               return MrcMaskCompression.PdfLzw;
            case 2:
               return MrcMaskCompression.PdfG31D;
            case 3:
               return MrcMaskCompression.PdfG32D;
            case 4:
               return MrcMaskCompression.PdfG4;
            default:
               return MrcMaskCompression.PdfJbig;
         }
      }

      public MrcTextCompression2BitCoder GetPDF2Compression(int index)
      {
         switch(index)
         {
            case 0:
               return MrcTextCompression2BitCoder.PdfZip;
            default:
               return MrcTextCompression2BitCoder.PdfLzw;
         }
      }

      public MrcPictureCompression GetPDFPictureCompression(int index)
      {
         switch(index)
         {
            case 0:
               return MrcPictureCompression.PdfJpeg;
            case 1:
               return MrcPictureCompression.PdfJpegYUV422;
            case 2:
               return MrcPictureCompression.PdfJpegYUV411;
            case 3:
               return MrcPictureCompression.PdfJpegProgressive;
            case 4:
               return MrcPictureCompression.PdfJpegProgressiveYUV422;
            case 5:
               return MrcPictureCompression.PdfJpegProgressiveYUV411;
            case 6:
               return MrcPictureCompression.PdfZip;
            default:
               return MrcPictureCompression.PdfLzw;
         }
      }

      private void _miFileSaveMultiPage_Click(object sender, System.EventArgs e)
      {
         try
         {
            ViewerForm activeViewer = ActiveViewerForm;
            SaveMultiPageDialog dlgMultiPage = new SaveMultiPageDialog(this);

            if(dlgMultiPage.ShowDialog(this) == DialogResult.OK)
            {
               SaveFileDialog dlgSave = new SaveFileDialog();

               switch(dlgMultiPage.SaveType)
               {
                  case 0:
                  case 1:
                     dlgSave.Filter = "Tiff|*.tif;*.tiff";
                     break;
                  case 2:
                     dlgSave.Filter = "PDF|*.pdf";
                     break;
               }
               dlgSave.Title = "Save Multi-Page";

               if(dlgSave.ShowDialog(this) == DialogResult.OK)
               {
                  MrcImageListFormat imageListFormat;
                  MrcCompressionOptions compressionOptions = new MrcCompressionOptions();
                  List<MrcSegmenter> segmenterList = new List<MrcSegmenter>();

                  switch(dlgMultiPage.SaveType)
                  {
                     case 0:
                        compressionOptions.PictureCoder = MrcPictureCompression.Jpeg;
                        compressionOptions.PictureQualityFactor = _qFactor;

                        switch(GetPictureCompression(_pictureCoder))
                        {
                           case MrcPictureCompression.LosslessJpeg:
                           case MrcPictureCompression.LosslessCmw:
                              compressionOptions.PictureQualityFactor = 0;
                              break;
                        }
                        compressionOptions.MaskCoder = GetMaskCompression(_maskCoder);
                        imageListFormat = MrcImageListFormat.MrcT44Tif;
                        break;
                     case 1:
                        compressionOptions.PictureCoder = GetPictureCompression(_pictureCoder);
                        compressionOptions.Text2BitCoder = GetTextCompressionCoder(_textCoder2Bit);
                        compressionOptions.MaskCoder = GetMaskCompression(_maskCoder);
                        compressionOptions.PictureQualityFactor = _qFactor;

                        switch(compressionOptions.PictureCoder)
                        {
                           case MrcPictureCompression.LosslessJpeg:
                           case MrcPictureCompression.LosslessCmw:
                              compressionOptions.PictureQualityFactor = 0;
                              break;
                        }
                        compressionOptions.Grayscale2BitCoder = GetGrayscaleCompression2BitCoder(_grayscaleCoder2Bit);
                        compressionOptions.Grayscale8BitCoder = GetGrayscaleCompression8BitCoder(_grayscaleCoder8Bit);
                        compressionOptions.Grayscale8BitFactor = _gSQFactor;
                        switch(compressionOptions.Grayscale8BitCoder)
                        {
                           case MrcGrayscaleCompression8BitCoder.LosslessCmw:
                           case MrcGrayscaleCompression8BitCoder.LosslessJpeg:
                              compressionOptions.Grayscale8BitFactor = 0;
                              break;
                        }
                        imageListFormat = MrcImageListFormat.MrcTif;
                        break;
                     default:
                        compressionOptions.PictureCoder = GetPDFPictureCompression(_pDFPictureCoder);
                        compressionOptions.Text2BitCoder = GetPDF2Compression(_pDFTextCoder2Bit);
                        compressionOptions.MaskCoder = GetPDF1Compression(_pDFMaskCoder);
                        compressionOptions.PictureQualityFactor = _pDFQFactor;

                        switch(compressionOptions.PictureCoder)
                        {
                           case MrcPictureCompression.LosslessJpeg:
                           case MrcPictureCompression.LosslessCmw:
                              compressionOptions.PictureQualityFactor = 0;
                              break;
                        }
                        imageListFormat = MrcImageListFormat.MrcPdf;
                        break;
                  }

                  MrcSegmenter.SaveBitmapList(dlgMultiPage.SegmenterCollection, dlgMultiPage.ImageCollection, dlgSave.FileName, imageListFormat, compressionOptions);
               }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _miSegmentation_Popup(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;
         _miSegClearSegments.Enabled = activeViewer.MrcStarted;
         _miSegStartPreserveManual.Enabled = activeViewer.MrcStarted;
      }

      private void _miEditDeselectAll_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;
         activeViewer.SelectedSegment = -2;
         activeViewer.Viewer.Cursor = Cursors.Default;
         UpdateControls();
         activeViewer.Invalidate(true);
      }

      private void MainForm_Deactivate(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;
         if(activeViewer != null)
            if(activeViewer.AddSegment && activeViewer.DrawNewSegment)
               CancelDrawing();
      }

      private void menuItem2_Click(object sender, EventArgs e)
      {
         if (menuItem2.Checked == false)
         {
            menuItem2.Checked = true;
            menuItem3.Checked = false;
            _segmentationMethod = false;
         }
                  
      }

      private void menuItem3_Click(object sender, EventArgs e)
      {
         if (menuItem3.Checked == false)
         {
            menuItem3.Checked = true;
            menuItem2.Checked = false;
            _segmentationMethod = true;
         }
      }
   }
}
