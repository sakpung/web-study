// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Drawing;
using Leadtools.ImageProcessing;
using Leadtools.Jpeg2000;


namespace JPXDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mainMenu;
      private System.Windows.Forms.MenuItem _miFileSeperator1;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miFileSaveAs;
      private System.Windows.Forms.MenuItem _miFileSaveList;
      private System.Windows.Forms.MenuItem _miFileSaveComposite;
      private System.Windows.Forms.MenuItem _miFileSeperator3;
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
      private System.Windows.Forms.MenuItem _miFileOpen;
      private MenuItem _miFileReadComposite;
      private MenuItem _miFileClose;
      private MenuItem _miFileSeperator2;
      private MenuItem _miAnimation;
      private MenuItem _miAnimationPlay;
      private MenuItem _miAnimationStop;
      private MenuItem _miAnimationSeperator1;
      private MenuItem _miAnimationLoop;
      private MenuItem _miAnimationSeperator2;
      private MenuItem _miAnimationSettings;
      private MenuItem _miFileProcessing;
      private MenuItem _miFileProcessingFileInformation;
      private MenuItem _miFileProcessingSeperator1;
      private MenuItem _miFileProcessingFragmentJPX;
      private MenuItem _miFileProcessingExtractFrames;
      private MenuItem _miBoxProcessing;
      private MenuItem _miBoxProcessingAppend;
      private MenuItem _miBPAppendIntellectualProperty;
      private MenuItem _miBPAppendDigitalSignature;
      private MenuItem _miBPAppendDesiredReproduction;
      private MenuItem _miBPAppendXML;
      private MenuItem _miBPAppendMPEG7;
      private MenuItem _miBPAppendBinaryFilter;
      private MenuItem _miBPAppendAssociation;
      private MenuItem _miBPAppendFreeBox;
      private MenuItem _miBoxProcessingRead;
      private MenuItem _miBPReadIntellectualProperty;
      private MenuItem _miBPReadDigitalSignature;
      private MenuItem _miBPReadDesiredReproduction;
      private MenuItem _miBPReadXML;
      private MenuItem _miBPReadMPEG7;
      private MenuItem _miBPReadBinaryFilter;
      private MenuItem _miBPReadAssociation;
      private MenuItem _miBPReadFreeBox;
      private MenuItem _miView;
      private MenuItem _miViewImages;
      private MenuItem _miViewSeparator1;
      private MenuItem _miViewColor;
      private MenuItem _miViewOpacity;
      private MenuItem _miViewPreOpacity;
      private MenuItem _miAnimationSaveSettings;
      private MenuItem _miBPAppendMediaData;
      private MenuItem _miBPReadMediaData;
      private MenuItem _miGML;
      private MenuItem _miGMLAppend;
      private MenuItem _miGMLRead;
      private MenuItem _miFileAppendFrames;
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
         this._miFileOpen = new System.Windows.Forms.MenuItem();
         this._miFileReadComposite = new System.Windows.Forms.MenuItem();
         this._miFileSeperator1 = new System.Windows.Forms.MenuItem();
         this._miFileClose = new System.Windows.Forms.MenuItem();
         this._miFileSeperator2 = new System.Windows.Forms.MenuItem();
         this._miFileSaveAs = new System.Windows.Forms.MenuItem();
         this._miFileSaveList = new System.Windows.Forms.MenuItem();
         this._miFileSaveComposite = new System.Windows.Forms.MenuItem();
         this._miFileAppendFrames = new System.Windows.Forms.MenuItem();
         this._miFileSeperator3 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miEdit = new System.Windows.Forms.MenuItem();
         this._miEditCopy = new System.Windows.Forms.MenuItem();
         this._miEditPaste = new System.Windows.Forms.MenuItem();
         this._miView = new System.Windows.Forms.MenuItem();
         this._miViewImages = new System.Windows.Forms.MenuItem();
         this._miViewSeparator1 = new System.Windows.Forms.MenuItem();
         this._miViewColor = new System.Windows.Forms.MenuItem();
         this._miViewOpacity = new System.Windows.Forms.MenuItem();
         this._miViewPreOpacity = new System.Windows.Forms.MenuItem();
         this._miAnimation = new System.Windows.Forms.MenuItem();
         this._miAnimationPlay = new System.Windows.Forms.MenuItem();
         this._miAnimationStop = new System.Windows.Forms.MenuItem();
         this._miAnimationSeperator1 = new System.Windows.Forms.MenuItem();
         this._miAnimationLoop = new System.Windows.Forms.MenuItem();
         this._miAnimationSeperator2 = new System.Windows.Forms.MenuItem();
         this._miAnimationSettings = new System.Windows.Forms.MenuItem();
         this._miAnimationSaveSettings = new System.Windows.Forms.MenuItem();
         this._miFileProcessing = new System.Windows.Forms.MenuItem();
         this._miFileProcessingFileInformation = new System.Windows.Forms.MenuItem();
         this._miFileProcessingSeperator1 = new System.Windows.Forms.MenuItem();
         this._miFileProcessingFragmentJPX = new System.Windows.Forms.MenuItem();
         this._miFileProcessingExtractFrames = new System.Windows.Forms.MenuItem();
         this._miBoxProcessing = new System.Windows.Forms.MenuItem();
         this._miBoxProcessingAppend = new System.Windows.Forms.MenuItem();
         this._miBPAppendIntellectualProperty = new System.Windows.Forms.MenuItem();
         this._miBPAppendDigitalSignature = new System.Windows.Forms.MenuItem();
         this._miBPAppendDesiredReproduction = new System.Windows.Forms.MenuItem();
         this._miBPAppendXML = new System.Windows.Forms.MenuItem();
         this._miBPAppendMPEG7 = new System.Windows.Forms.MenuItem();
         this._miBPAppendMediaData = new System.Windows.Forms.MenuItem();
         this._miBPAppendBinaryFilter = new System.Windows.Forms.MenuItem();
         this._miBPAppendAssociation = new System.Windows.Forms.MenuItem();
         this._miBPAppendFreeBox = new System.Windows.Forms.MenuItem();
         this._miBoxProcessingRead = new System.Windows.Forms.MenuItem();
         this._miBPReadIntellectualProperty = new System.Windows.Forms.MenuItem();
         this._miBPReadDigitalSignature = new System.Windows.Forms.MenuItem();
         this._miBPReadDesiredReproduction = new System.Windows.Forms.MenuItem();
         this._miBPReadXML = new System.Windows.Forms.MenuItem();
         this._miBPReadMPEG7 = new System.Windows.Forms.MenuItem();
         this._miBPReadBinaryFilter = new System.Windows.Forms.MenuItem();
         this._miBPReadAssociation = new System.Windows.Forms.MenuItem();
         this._miBPReadFreeBox = new System.Windows.Forms.MenuItem();
         this._miBPReadMediaData = new System.Windows.Forms.MenuItem();
         this._miGML = new System.Windows.Forms.MenuItem();
         this._miGMLAppend = new System.Windows.Forms.MenuItem();
         this._miGMLRead = new System.Windows.Forms.MenuItem();
         this._miWindow = new System.Windows.Forms.MenuItem();
         this._miWindowCascade = new System.Windows.Forms.MenuItem();
         this._miWindowTileHorizontally = new System.Windows.Forms.MenuItem();
         this._miWindowTileVertically = new System.Windows.Forms.MenuItem();
         this._miWindowArrangeIcons = new System.Windows.Forms.MenuItem();
         this._miWindowCloseAll = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // _mainMenu
         // 
         this._mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miEdit,
            this._miView,
            this._miAnimation,
            this._miFileProcessing,
            this._miBoxProcessing,
            this._miGML,
            this._miWindow,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileOpen,
            this._miFileReadComposite,
            this._miFileSeperator1,
            this._miFileClose,
            this._miFileSeperator2,
            this._miFileSaveAs,
            this._miFileSaveList,
            this._miFileSaveComposite,
            this._miFileAppendFrames,
            this._miFileSeperator3,
            this._miFileExit});
         this._miFile.Text = "&File";
         // 
         // _miFileOpen
         // 
         this._miFileOpen.Index = 0;
         this._miFileOpen.RadioCheck = true;
         this._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this._miFileOpen.Text = "&Open...";
         this._miFileOpen.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileReadComposite
         // 
         this._miFileReadComposite.Index = 1;
         this._miFileReadComposite.Text = "Read &Composite...";
         this._miFileReadComposite.Click += new System.EventHandler(this._miFileReadComposite_Click);
         // 
         // _miFileSeperator1
         // 
         this._miFileSeperator1.Index = 2;
         this._miFileSeperator1.Text = "-";
         // 
         // _miFileClose
         // 
         this._miFileClose.Index = 3;
         this._miFileClose.Text = "C&lose";
         this._miFileClose.Click += new System.EventHandler(this._miFileClose_Click);
         // 
         // _miFileSeperator2
         // 
         this._miFileSeperator2.Index = 4;
         this._miFileSeperator2.Text = "-";
         // 
         // _miFileSaveAs
         // 
         this._miFileSaveAs.Index = 5;
         this._miFileSaveAs.RadioCheck = true;
         this._miFileSaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this._miFileSaveAs.Text = "Sa&ve As...";
         this._miFileSaveAs.Click += new System.EventHandler(this._miFileSave_Click);
         // 
         // _miFileSaveList
         // 
         this._miFileSaveList.Index = 6;
         this._miFileSaveList.Text = "&Save List...";
         this._miFileSaveList.Click += new System.EventHandler(this._miFileSaveList_Click);
         // 
         // _miFileSaveComposite
         // 
         this._miFileSaveComposite.Index = 7;
         this._miFileSaveComposite.Text = "S&ave Composite...";
         this._miFileSaveComposite.Click += new System.EventHandler(this._miFileSaveComposite_Click);
         // 
         // _miFileAppendFrames
         // 
         this._miFileAppendFrames.Index = 8;
         this._miFileAppendFrames.Text = "A&ppend Frames...";
         this._miFileAppendFrames.Click += new System.EventHandler(this._miFileAppendFrames_Click);
         // 
         // _miFileSeperator3
         // 
         this._miFileSeperator3.Index = 9;
         this._miFileSeperator3.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 10;
         this._miFileExit.RadioCheck = true;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miEdit
         // 
         this._miEdit.Index = 1;
         this._miEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miEditCopy,
            this._miEditPaste});
         this._miEdit.Text = "&Edit";
         // 
         // _miEditCopy
         // 
         this._miEditCopy.Index = 0;
         this._miEditCopy.RadioCheck = true;
         this._miEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
         this._miEditCopy.Text = "&Copy";
         this._miEditCopy.Click += new System.EventHandler(this._miEditCopy_Click);
         // 
         // _miEditPaste
         // 
         this._miEditPaste.Index = 1;
         this._miEditPaste.RadioCheck = true;
         this._miEditPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
         this._miEditPaste.Text = "&Paste";
         this._miEditPaste.Click += new System.EventHandler(this._miEditPaste_Click);
         // 
         // _miView
         // 
         this._miView.Index = 2;
         this._miView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miViewImages,
            this._miViewSeparator1,
            this._miViewColor,
            this._miViewOpacity,
            this._miViewPreOpacity});
         this._miView.Text = "&View";
         // 
         // _miViewImages
         // 
         this._miViewImages.Index = 0;
         this._miViewImages.Text = "&Images";
         this._miViewImages.Click += new System.EventHandler(this._miView_Click);
         // 
         // _miViewSeparator1
         // 
         this._miViewSeparator1.Index = 1;
         this._miViewSeparator1.Text = "-";
         // 
         // _miViewColor
         // 
         this._miViewColor.Index = 2;
         this._miViewColor.Text = "&Color Images";
         this._miViewColor.Click += new System.EventHandler(this._miView_Click);
         // 
         // _miViewOpacity
         // 
         this._miViewOpacity.Index = 3;
         this._miViewOpacity.Text = "&Opacity Images";
         this._miViewOpacity.Click += new System.EventHandler(this._miView_Click);
         // 
         // _miViewPreOpacity
         // 
         this._miViewPreOpacity.Index = 4;
         this._miViewPreOpacity.Text = "&PreOpacity Images";
         this._miViewPreOpacity.Click += new System.EventHandler(this._miView_Click);
         // 
         // _miAnimation
         // 
         this._miAnimation.Index = 3;
         this._miAnimation.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miAnimationPlay,
            this._miAnimationStop,
            this._miAnimationSeperator1,
            this._miAnimationLoop,
            this._miAnimationSeperator2,
            this._miAnimationSettings,
            this._miAnimationSaveSettings});
         this._miAnimation.Text = "&Animation";
         // 
         // _miAnimationPlay
         // 
         this._miAnimationPlay.Index = 0;
         this._miAnimationPlay.Text = "&Play";
         this._miAnimationPlay.Click += new System.EventHandler(this._miAnnimationPlay_Click);
         // 
         // _miAnimationStop
         // 
         this._miAnimationStop.Index = 1;
         this._miAnimationStop.Text = "&Stop";
         this._miAnimationStop.Click += new System.EventHandler(this._miAnnimationStop_Click);
         // 
         // _miAnimationSeperator1
         // 
         this._miAnimationSeperator1.Index = 2;
         this._miAnimationSeperator1.Text = "-";
         // 
         // _miAnimationLoop
         // 
         this._miAnimationLoop.Index = 3;
         this._miAnimationLoop.Text = "&Loop";
         this._miAnimationLoop.Click += new System.EventHandler(this._miAnnimationLoop_Click);
         // 
         // _miAnimationSeperator2
         // 
         this._miAnimationSeperator2.Index = 4;
         this._miAnimationSeperator2.Text = "-";
         // 
         // _miAnimationSettings
         // 
         this._miAnimationSettings.Index = 5;
         this._miAnimationSettings.Text = "Se&ttings...";
         this._miAnimationSettings.Click += new System.EventHandler(this._miAnnimationSettings_Click);
         // 
         // _miAnimationSaveSettings
         // 
         this._miAnimationSaveSettings.Index = 6;
         this._miAnimationSaveSettings.Text = "S&ave Settings";
         this._miAnimationSaveSettings.Click += new System.EventHandler(this._miAnimationSaveSettings_Click);
         // 
         // _miFileProcessing
         // 
         this._miFileProcessing.Index = 4;
         this._miFileProcessing.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileProcessingFileInformation,
            this._miFileProcessingSeperator1,
            this._miFileProcessingFragmentJPX,
            this._miFileProcessingExtractFrames});
         this._miFileProcessing.Text = "File &Processing";
         // 
         // _miFileProcessingFileInformation
         // 
         this._miFileProcessingFileInformation.Index = 0;
         this._miFileProcessingFileInformation.Text = "File &Information";
         this._miFileProcessingFileInformation.Click += new System.EventHandler(this._miFileProcessingFileInfo_Click);
         // 
         // _miFileProcessingSeperator1
         // 
         this._miFileProcessingSeperator1.Index = 1;
         this._miFileProcessingSeperator1.Text = "-";
         // 
         // _miFileProcessingFragmentJPX
         // 
         this._miFileProcessingFragmentJPX.Index = 2;
         this._miFileProcessingFragmentJPX.Text = "Fragment &Jpx";
         this._miFileProcessingFragmentJPX.Click += new System.EventHandler(this._miFileProcessingFragmentJPX_Click);
         // 
         // _miFileProcessingExtractFrames
         // 
         this._miFileProcessingExtractFrames.Index = 3;
         this._miFileProcessingExtractFrames.Text = "&Extract Frames";
         this._miFileProcessingExtractFrames.Click += new System.EventHandler(this._miFileProcessingExtractFrames_Click);
         // 
         // _miBoxProcessing
         // 
         this._miBoxProcessing.Index = 5;
         this._miBoxProcessing.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miBoxProcessingAppend,
            this._miBoxProcessingRead});
         this._miBoxProcessing.Text = "&Box Processing";
         // 
         // _miBoxProcessingAppend
         // 
         this._miBoxProcessingAppend.Index = 0;
         this._miBoxProcessingAppend.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miBPAppendIntellectualProperty,
            this._miBPAppendDigitalSignature,
            this._miBPAppendDesiredReproduction,
            this._miBPAppendXML,
            this._miBPAppendMPEG7,
            this._miBPAppendMediaData,
            this._miBPAppendBinaryFilter,
            this._miBPAppendAssociation,
            this._miBPAppendFreeBox});
         this._miBoxProcessingAppend.Text = "&Append";
         // 
         // _miBPAppendIntellectualProperty
         // 
         this._miBPAppendIntellectualProperty.Index = 0;
         this._miBPAppendIntellectualProperty.Text = "&Intellectual Property";
         this._miBPAppendIntellectualProperty.Click += new System.EventHandler(this._miBPAppendIntellectualProperty_Click);
         // 
         // _miBPAppendDigitalSignature
         // 
         this._miBPAppendDigitalSignature.Index = 1;
         this._miBPAppendDigitalSignature.Text = "&Digital Signature";
         this._miBPAppendDigitalSignature.Click += new System.EventHandler(this._miBPAppendDigitalSignature_Click);
         // 
         // _miBPAppendDesiredReproduction
         // 
         this._miBPAppendDesiredReproduction.Index = 2;
         this._miBPAppendDesiredReproduction.Text = "Desired &Reproduction";
         this._miBPAppendDesiredReproduction.Click += new System.EventHandler(this._miBPAppendDesiredReproduction_Click);
         // 
         // _miBPAppendXML
         // 
         this._miBPAppendXML.Index = 3;
         this._miBPAppendXML.Text = "&XML";
         this._miBPAppendXML.Click += new System.EventHandler(this._miBPAppendXML_Click);
         // 
         // _miBPAppendMPEG7
         // 
         this._miBPAppendMPEG7.Index = 4;
         this._miBPAppendMPEG7.Text = "&MPEG7";
         this._miBPAppendMPEG7.Click += new System.EventHandler(this._miBPAppendMPEG7_Click);
         // 
         // _miBPAppendMediaData
         // 
         this._miBPAppendMediaData.Index = 5;
         this._miBPAppendMediaData.Text = "M&edia Data";
         this._miBPAppendMediaData.Click += new System.EventHandler(this._miBPAppendMediaData_Click);
         // 
         // _miBPAppendBinaryFilter
         // 
         this._miBPAppendBinaryFilter.Index = 6;
         this._miBPAppendBinaryFilter.Text = "&Binary Filter";
         this._miBPAppendBinaryFilter.Click += new System.EventHandler(this._miBPAppendBinaryFilter_Click);
         // 
         // _miBPAppendAssociation
         // 
         this._miBPAppendAssociation.Index = 7;
         this._miBPAppendAssociation.Text = "&Association";
         this._miBPAppendAssociation.Click += new System.EventHandler(this._miBPAppendAssociation_Click);
         // 
         // _miBPAppendFreeBox
         // 
         this._miBPAppendFreeBox.Index = 8;
         this._miBPAppendFreeBox.Text = "&Free Box";
         this._miBPAppendFreeBox.Click += new System.EventHandler(this._miBPAppendFreeBox_Click);
         // 
         // _miBoxProcessingRead
         // 
         this._miBoxProcessingRead.Index = 1;
         this._miBoxProcessingRead.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miBPReadIntellectualProperty,
            this._miBPReadDigitalSignature,
            this._miBPReadDesiredReproduction,
            this._miBPReadXML,
            this._miBPReadMPEG7,
            this._miBPReadMediaData,
            this._miBPReadBinaryFilter,
            this._miBPReadAssociation,
            this._miBPReadFreeBox});
         this._miBoxProcessingRead.Text = "Read";
         // 
         // _miBPReadIntellectualProperty
         // 
         this._miBPReadIntellectualProperty.Index = 0;
         this._miBPReadIntellectualProperty.Text = "&Intellectual Property";
         this._miBPReadIntellectualProperty.Click += new System.EventHandler(this._miBPReadIntellectualProperty_Click);
         // 
         // _miBPReadDigitalSignature
         // 
         this._miBPReadDigitalSignature.Index = 1;
         this._miBPReadDigitalSignature.Text = "&Digital Signature";
         this._miBPReadDigitalSignature.Click += new System.EventHandler(this._miBPReadDigitalSignature_Click);
         // 
         // _miBPReadDesiredReproduction
         // 
         this._miBPReadDesiredReproduction.Index = 2;
         this._miBPReadDesiredReproduction.Text = "Desired &Reproduction";
         this._miBPReadDesiredReproduction.Click += new System.EventHandler(this._miBPReadDesiredReproduction_Click);
         // 
         // _miBPReadXML
         // 
         this._miBPReadXML.Index = 3;
         this._miBPReadXML.Text = "&XML";
         this._miBPReadXML.Click += new System.EventHandler(this._miBPReadXML_Click);
         // 
         // _miBPReadMPEG7
         // 
         this._miBPReadMPEG7.Index = 4;
         this._miBPReadMPEG7.Text = "&MPEG7";
         this._miBPReadMPEG7.Click += new System.EventHandler(this._miBPReadMPEG7_Click);
         // 
         // _miBPReadBinaryFilter
         // 
         this._miBPReadBinaryFilter.Index = 6;
         this._miBPReadBinaryFilter.Text = "&Binary Filter";
         this._miBPReadBinaryFilter.Click += new System.EventHandler(this._miBPReadBinaryFilter_Click);
         // 
         // _miBPReadAssociation
         // 
         this._miBPReadAssociation.Index = 7;
         this._miBPReadAssociation.Text = "&Association";
         this._miBPReadAssociation.Click += new System.EventHandler(this._miBPReadAssociation_Click);
         // 
         // _miBPReadFreeBox
         // 
         this._miBPReadFreeBox.Index = 8;
         this._miBPReadFreeBox.Text = "&Free Box";
         this._miBPReadFreeBox.Click += new System.EventHandler(this._miBPReadFreeBox_Click);
         // 
         // _miBPReadMediaData
         // 
         this._miBPReadMediaData.Index = 5;
         this._miBPReadMediaData.Text = "M&edia Data";
         this._miBPReadMediaData.Click += new System.EventHandler(this._miBPReadMediaData_Click);
         // 
         // _miGML
         // 
         this._miGML.Index = 6;
         this._miGML.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miGMLAppend,
            this._miGMLRead});
         this._miGML.Text = "GML";
         // 
         // _miGMLAppend
         // 
         this._miGMLAppend.Index = 0;
         this._miGMLAppend.Text = "&Append";
         this._miGMLAppend.Click += new System.EventHandler(this._miGMLAppend_Click);
         // 
         // _miGMLRead
         // 
         this._miGMLRead.Index = 1;
         this._miGMLRead.Text = "&Read";
         this._miGMLRead.Click += new System.EventHandler(this._miGMLRead_Click);
         // 
         // _miWindow
         // 
         this._miWindow.Index = 7;
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
         this._miHelp.Index = 8;
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
         this.ClientSize = new System.Drawing.Size(712, 471);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.IsMdiContainer = true;
         this.Menu = this._mainMenu;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
         this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
         this.ResumeLayout(false);

      }
      #endregion

      private RasterCodecs _codecs;

      private RasterColor _fillColor;
      private RasterPaintProperties _paintProperties;
      private MenuItem _checkedWindowMenu;
      private Jpeg2000Engine _jpeg2000;
      private RasterImage _noOpacityBitmap;
      private RasterImage _noPreOpacityBitmap;
      private Timer _animationTimer;

      public Timer AnimationTimer
      {
         get
         {
            return _animationTimer;
         }
         set
         {
            _animationTimer = value;
         }
      }

      public RasterCodecs Codecs
      {
         get
         {
            return _codecs;
         }
         set
         {
            _codecs = value;
         }
      }

      public RasterImage NoOpacityBitmap
      {
         get
         {
            return _noOpacityBitmap;
         }
         set
         {
            _noOpacityBitmap = value;
         }
      }

      public RasterImage NoPreOpacityBitmap
      {
         get
         {
            return _noPreOpacityBitmap;
         }
         set
         {
            _noPreOpacityBitmap = value;
         }
      }

      public Jpeg2000Engine Jpeg2000Eng
      {
         get
         {
            return _jpeg2000;
         }
         set
         {
            _jpeg2000 = value;
         }
      }

      public ViewerForm ActiveViewerForm
      {
         get
         {
            return ActiveMdiChild as ViewerForm;
         }
      }

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main( )
      {
         if (!Support.SetLicense())
            return;

         Application.EnableVisualStyles();
         Application.DoEvents();

         Application.Run(new MainForm());
      }

      private void InitClass( )
      {
         Messager.Caption = "LEADTOOLS for .NET C# JPX Demo";
         Text = Messager.Caption;

         _codecs = new RasterCodecs();

         try
         {
            Jpeg2000Eng = new Jpeg2000Engine();
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }

         _fillColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White);
         _paintProperties = RasterPaintProperties.Default;
         _paintProperties.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray;

         _checkedWindowMenu = _miWindowCascade;
         _checkedWindowMenu.Checked = true;

         try
         {
            NoOpacityBitmap    = RasterImageConverter.ConvertFromImage(new Bitmap(this.GetType(), "Resources.No_Opacity.bmp"   ), ConvertFromImageOptions.None);
            NoPreOpacityBitmap = RasterImageConverter.ConvertFromImage(new Bitmap(this.GetType(), "Resources.No_PreOpacity.bmp"), ConvertFromImageOptions.None);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }

         AnimationTimer = new Timer();
         AnimationTimer.Tick += new EventHandler(AnimationTimer_Tick);

         LoadImage(true);
         UpdateControls();
      }

      private void CleanUp( )
      {
      }

      public void UpdateControls( )
      {
         ViewerForm activeForm = ActiveViewerForm;

         EnableAndVisibleMenu(_miFileClose, activeForm != null);
         EnableAndVisibleMenu(_miFileSeperator2, activeForm != null);

         EnableAndVisibleMenu(_miFileSaveAs, activeForm != null);
         EnableAndVisibleMenu(_miFileSaveList, activeForm != null);
         EnableAndVisibleMenu(_miFileSaveComposite, activeForm != null);
         EnableAndVisibleMenu(_miFileAppendFrames, activeForm != null);
         EnableAndVisibleMenu(_miFileSeperator3, activeForm != null);

         EnableAndVisibleMenu(_miEditCopy, activeForm != null);
         _miEditPaste.Enabled = RasterClipboard.IsReady;

         EnableAndVisibleMenu(_miView, activeForm != null);
         if (activeForm != null)
         {
            ClearCheck();
            _miViewImages.Enabled = activeForm.IsComposite;
            _miViewSeparator1.Enabled = activeForm.IsComposite;
            _miViewColor.Enabled = activeForm.IsComposite;
            _miViewOpacity.Enabled = activeForm.IsComposite;
            _miViewPreOpacity.Enabled = activeForm.IsComposite;

            if (activeForm.IsComposite)
            {
               SetCheck(ActiveViewerForm.ActiveList);
            }
         }

         EnableAndVisibleMenu(_miAnimation, activeForm != null);
         EnableAndVisibleMenu(_miAnimationPlay, activeForm != null);
         EnableAndVisibleMenu(_miAnimationStop, activeForm != null);
         EnableAndVisibleMenu(_miAnimationLoop, activeForm != null);

         if (activeForm != null)
         {
            _miAnimationLoop.Checked = ActiveViewerForm.LoopAnimation;
            bool enableAnimation = (activeForm.ActiveList == ViewerForm.ActiveImageLists.ColorList ||
                                    activeForm.ActiveList == ViewerForm.ActiveImageLists.ImagesList)
                                    ? true : false;
            _miAnimationPlay.Enabled = enableAnimation;
            _miAnimationStop.Enabled = enableAnimation && activeForm.PlayingAnnimation;
            _miAnimationLoop.Enabled = enableAnimation;
         }

         EnableAndVisibleMenu(_miAnimationSettings, activeForm != null);
         EnableAndVisibleMenu(_miWindow, activeForm != null);
      }

      private void EnableAndVisibleMenu(MenuItem menu, bool value)
      {
         menu.Enabled = value;
         menu.Visible = value;
      }

      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         LoadImage(false);
         UpdateControls();
      }

      private void LoadImage(bool loadDefaultImage)
      {
         ImageFileLoader loader = new ImageFileLoader();

         try
         {
            loader.ShowLoadPagesDialog = true;

            if (loadDefaultImage)
            {
                if (loader.Load(this, DemosGlobal.ImagesFolder + @"\image1.jpx", _codecs, 1, -1))
                {
                    NewImage(new ImageInformation(loader.Image, loader.FileName), true);
                }
            }
            else
            {
                if (loader.Load(this, _codecs, true) > 0)
                {
                    NewImage(new ImageInformation(loader.Image, loader.FileName), true);
                }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }
      }

      private void _miFileReadComposite_Click(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();

         ofd.Filter = "JPX JP2 Files(*.jpx;*.jp2)|*.jpx;*.jp2|All Files(*.*)|*.*";
         ofd.Title = "Read Composite";

         if(ofd.ShowDialog() == DialogResult.OK)
         {
            using (WaitCursor wait = new WaitCursor())
            {
               try
               {
                  List<CompositeJpxImages> imageList = Jpeg2000Eng.LoadComposite(_codecs, ofd.FileName, 0, CodecsLoadByteOrder.BgrOrGray);

                  NewImage(imageList, ofd.FileName);

                  imageList.Clear();
               }
               catch (Exception ex)
               {
                  Messager.ShowFileOpenError(this, ofd.FileName, ex);
               }
            }
         }
      }

      private void _miFileClose_Click(object sender, EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;

         activeForm.Close();
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

      private void _miFileSaveList_Click(object sender, EventArgs e)
      {
         SaveList saveList = new SaveList(this);

         saveList.ShowDialog();
      }

      private void _miFileSaveComposite_Click(object sender, EventArgs e)
      {
         SaveComposite saveComposite = new SaveComposite(this, "Save Composite", "Save", true);

         saveComposite.ShowDialog();
      }

      private void _miFileAppendFrames_Click(object sender, EventArgs e)
      {
         SaveComposite saveComposite = new SaveComposite(this, "Append Frames", "Append", false);

         saveComposite.ShowDialog();
      }

      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void MainForm_MdiChildActivate(object sender, System.EventArgs e)
      {
         UpdateControls();
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
                     NewImage(new ImageInformation(image), false);
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

      private void _miView_Click(object sender, EventArgs e)
      {
         ClearCheck();

         MenuItem senderMenu = (MenuItem)sender;

         senderMenu.Checked = true;

         ActiveViewerForm.ActiveList = (ViewerForm.ActiveImageLists)GetMenuIndex(senderMenu);
         ActiveViewerForm.FillImageList();
         UpdateControls();
      }

      private int GetMenuIndex(MenuItem menuItem)
      {
         if (menuItem == _miViewColor)
            return 1;
         else if (menuItem == _miViewOpacity)
            return 2;
         else if (menuItem == _miViewPreOpacity)
            return 3;
         else
            return 0;
      }

      public void ClearCheck()
      {
         _miViewImages.Checked = false;
         _miViewColor.Checked = false;
         _miViewOpacity.Checked = false;
         _miViewPreOpacity.Checked = false;
      }

      private void _miAnnimationPlay_Click(object sender, EventArgs e)
      {
         ActiveViewerForm.StopAnimation = false;
         ActiveViewerForm.PlayingAnnimation = true;

         AnimationTimer.Interval = Convert.ToInt32(ActiveViewerForm.AnimationDelay);
         AnimationTimer.Start();

         SetViewerLayout();

         UpdateMenusItems();
      }

      private void _miAnnimationStop_Click(object sender, EventArgs e)
      {
         ActiveViewerForm.StopAnimation = true;
         ActiveViewerForm.PlayingAnnimation = false;

         SetViewerLayout();
      }

      private void _miAnnimationLoop_Click(object sender, EventArgs e)
      {
         ActiveViewerForm.LoopAnimation = !ActiveViewerForm.LoopAnimation;
         _miAnimationLoop.Checked = ActiveViewerForm.LoopAnimation;
      }

      private void _miAnnimationSettings_Click(object sender, EventArgs e)
      {
         AnimationSettings settings = new AnimationSettings(ActiveViewerForm.AnimationDelay,
                                                            ActiveViewerForm.RenderWidth,
                                                            ActiveViewerForm.RenderHeight);

         if (settings.ShowDialog() == DialogResult.OK)
         {
            ActiveViewerForm.AnimationDelay = settings.AnnimationDelay;
            ActiveViewerForm.RenderWidth = settings.RenderWidth;
            ActiveViewerForm.RenderHeight = settings.RenderHeight;
         }
      }

      private void _miAnimationSaveSettings_Click(object sender, EventArgs e)
      {
         SaveAnimation saveAnimationDialog = new SaveAnimation(this);

         saveAnimationDialog.ShowDialog();
      }

      private void _miFileProcessingFileInfo_Click(object sender, EventArgs e)
      {
         FileInformation fileInformation = new FileInformation(this);

         fileInformation.ShowDialog();
      }

      private void _miFileProcessingFragmentJPX_Click(object sender, EventArgs e)
      {
         FragmentJPX fragmentJPX = new FragmentJPX(this);

         fragmentJPX.ShowDialog();
      }

      private void _miFileProcessingExtractFrames_Click(object sender, EventArgs e)
      {
         ExtractFrames extractFrames = new ExtractFrames(this);

         extractFrames.ShowDialog();
      }

      private void _miBPAppendIntellectualProperty_Click(object sender, EventArgs e)
      {
         AppendCommon intellectualPropertyDlg = new AppendCommon("Intellectual Property", false, null);

         if (intellectualPropertyDlg.ShowDialog() == DialogResult.OK)
         {
            IprBox _iprBox = new IprBox();

            _iprBox.Data = intellectualPropertyDlg.AppendCommonData.data;

            try
            {
               Jpeg2000Eng.AppendBox(intellectualPropertyDlg.Jpeg2000FileName, _iprBox);

               Messager.ShowInformation(this, "Appending Succeeded!");
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void _miBPAppendDigitalSignature_Click(object sender, EventArgs e)
      {
         AppendDigitalSignature digitalSignatureDlg = new AppendDigitalSignature();

         if (digitalSignatureDlg.ShowDialog() == DialogResult.OK)
         {
            List<DigitalSignatureBox> _digitalSignatureBox = new List<DigitalSignatureBox>();
            DigitalSignatureBox _digitalSignatureBoxNode = new DigitalSignatureBox();

            _digitalSignatureBoxNode.SignatureType = Convert.ToByte(digitalSignatureDlg.DigitalSignatureData.signatureType);
            _digitalSignatureBoxNode.PointerType = Convert.ToByte(digitalSignatureDlg.DigitalSignatureData.pointerType);
            _digitalSignatureBoxNode.Offset = Convert.ToByte(digitalSignatureDlg.DigitalSignatureData.offset);
            _digitalSignatureBoxNode.Length = digitalSignatureDlg.DigitalSignatureData.length;
            _digitalSignatureBoxNode.Data = digitalSignatureDlg.DigitalSignatureData.data;

            _digitalSignatureBox.Add(_digitalSignatureBoxNode);

            try
            {
               Jpeg2000Eng.AppendBoxes(digitalSignatureDlg.DigitalSignatureData.jPG2FileName, _digitalSignatureBox);

               Messager.ShowInformation(this, "Appending Succeeded!");
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void _miBPAppendDesiredReproduction_Click(object sender, EventArgs e)
      {
         AppendCommon desiredReproductionDlg = new AppendCommon("Desired Reproduction", false, null);

         if (desiredReproductionDlg.ShowDialog() == DialogResult.OK)
         {
            GtsoBox _gtsoBox = new GtsoBox();

            _gtsoBox.Data = desiredReproductionDlg.AppendCommonData.data;

            try
            {
               Jpeg2000Eng.AppendBox(desiredReproductionDlg.Jpeg2000FileName, _gtsoBox);

               Messager.ShowInformation(this, "Appending Succeeded!");
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void _miBPAppendXML_Click(object sender, EventArgs e)
      {
         AppendCommon xMLDlg = new AppendCommon("XML", false, null);

         if (xMLDlg.ShowDialog() == DialogResult.OK)
         {
            List<XmlBox> _xmlBox = new List<XmlBox>();
            XmlBox _xmlBoxNode = new XmlBox();

            _xmlBoxNode.Data = xMLDlg.AppendCommonData.data;

            _xmlBox.Add(_xmlBoxNode);

            try
            {
               Jpeg2000Eng.AppendBoxes(xMLDlg.Jpeg2000FileName, _xmlBox);

               Messager.ShowInformation(this, "Appending Succeeded!");
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void _miBPAppendMPEG7_Click(object sender, EventArgs e)
      {
         AppendCommon mPEG7Dlg = new AppendCommon("MPEG7", false, null);

         if (mPEG7Dlg.ShowDialog() == DialogResult.OK)
         {
            List<Mpeg7Box> _mpeg7Box = new List<Mpeg7Box>();
            Mpeg7Box _mpeg7BoxNode = new Mpeg7Box();

            _mpeg7BoxNode.Data = mPEG7Dlg.AppendCommonData.data;

            _mpeg7Box.Add(_mpeg7BoxNode);

            try
            {
               Jpeg2000Eng.AppendBoxes(mPEG7Dlg.Jpeg2000FileName, _mpeg7Box);

               Messager.ShowInformation(this, "Appending Succeeded!");
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void _miBPAppendMediaData_Click(object sender, EventArgs e)
      {
         AppendCommon mediaDataDlg = new AppendCommon("Media Data", false, null);

         if (mediaDataDlg.ShowDialog() == DialogResult.OK)
         {
            List<MediaDataBox> _mediaDataBox = new List<MediaDataBox>();
            MediaDataBox _mediaDataBoxNode = new MediaDataBox();

            _mediaDataBoxNode.Data = mediaDataDlg.AppendCommonData.data;

            _mediaDataBox.Add(_mediaDataBoxNode);

            try
            {
               Jpeg2000Eng.AppendBoxes(mediaDataDlg.Jpeg2000FileName, _mediaDataBox);

               Messager.ShowInformation(this, "Appending Succeeded!");
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void _miBPAppendBinaryFilter_Click(object sender, EventArgs e)
      {
         List<string> binaryList = new List<string>();
         binaryList.Add("Compressed with GZIP");
         binaryList.Add("Encrypted using DES");

         AppendCommon binaryFilterDlg = new AppendCommon("Binary Filter", true, binaryList);

         if (binaryFilterDlg.ShowDialog() == DialogResult.OK)
         {
            List<BinaryFilterBox> _binaryFilterBox = new List<BinaryFilterBox>();
            BinaryFilterBox _binaryFilterBoxNode = new BinaryFilterBox();

            _binaryFilterBoxNode.Data = binaryFilterDlg.AppendCommonData.data;
            _binaryFilterBoxNode.FilterType = binaryFilterDlg.AppendCommonData.type;

            _binaryFilterBox.Add(_binaryFilterBoxNode);

            try
            {
               Jpeg2000Eng.AppendBoxes(binaryFilterDlg.Jpeg2000FileName, _binaryFilterBox);

               Messager.ShowInformation(this, "Appending Succeeded!");
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void _miBPAppendAssociation_Click(object sender, EventArgs e)
      {
         AppendCommon associationDlg = new AppendCommon("Association", false, null);

         if (associationDlg.ShowDialog() == DialogResult.OK)
         {
            List<AssociationBox> _associationBox = new List<AssociationBox>();
            AssociationBox _associationBoxNode = new AssociationBox();

            _associationBoxNode.Data = associationDlg.AppendCommonData.data;

            _associationBox.Add(_associationBoxNode);

            try
            {
               Jpeg2000Eng.AppendBoxes(associationDlg.Jpeg2000FileName, _associationBox);

               Messager.ShowInformation(this, "Appending Succeeded!");
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void _miBPAppendFreeBox_Click(object sender, EventArgs e)
      {
         AppendCommon freeBoxDlg = new AppendCommon("Free", false, null);

         if (freeBoxDlg.ShowDialog() == DialogResult.OK)
         {
            List<FreeBox> _freeBox = new List<FreeBox>();
            FreeBox _freeBoxNode = new FreeBox();

            _freeBoxNode.Data = freeBoxDlg.AppendCommonData.data;

            _freeBox.Add(_freeBoxNode);

            try
            {
               Jpeg2000Eng.AppendBoxes(freeBoxDlg.Jpeg2000FileName, _freeBox);

               Messager.ShowInformation(this, "Appending Succeeded!");
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      private void _miBPReadIntellectualProperty_Click(object sender, EventArgs e)
      {
         ReadCommon intellectualProperty = new ReadCommon(this, "Intellectual Property", false);

         ReadBoxCommonStructure _readBox = new ReadBoxCommonStructure();
         _readBox.boxType = Jpeg2000BoxType.IprBox;
         intellectualProperty.ReadBox = _readBox;

         intellectualProperty.ShowDialog();
      }

      private void _miBPReadDigitalSignature_Click(object sender, EventArgs e)
      {
         ReadDigitalSignature readDigitalSignatureDlg = new ReadDigitalSignature(this);

         readDigitalSignatureDlg.ShowDialog();
      }

      private void _miBPReadDesiredReproduction_Click(object sender, EventArgs e)
      {
         ReadCommon desiredReproduction = new ReadCommon(this, "Desired Reproduction", false);

         ReadBoxCommonStructure _readBox = new ReadBoxCommonStructure();
         _readBox.boxType = Jpeg2000BoxType.GtsoBox;
         desiredReproduction.ReadBox = _readBox;

         desiredReproduction.ShowDialog();
      }

      private void _miBPReadXML_Click(object sender, EventArgs e)
      {
         ReadCommon xML = new ReadCommon(this, "XML", false);

         ReadBoxCommonStructure _readBox = new ReadBoxCommonStructure();
         _readBox.boxType = Jpeg2000BoxType.XmlBox;
         xML.ReadBox = _readBox;

         xML.ShowDialog();
      }

      private void _miBPReadMPEG7_Click(object sender, EventArgs e)
      {
         ReadCommon mPEG7 = new ReadCommon(this, "MPEG7", false);

         ReadBoxCommonStructure _readBox = new ReadBoxCommonStructure();
         _readBox.boxType = Jpeg2000BoxType.Mpeg7Box;
         mPEG7.ReadBox = _readBox;

         mPEG7.ShowDialog();
      }

      private void _miBPReadMediaData_Click(object sender, EventArgs e)
      {
         ReadCommon mediaData = new ReadCommon(this, "Media Data", false);

         ReadBoxCommonStructure _readBox = new ReadBoxCommonStructure();
         _readBox.boxType = Jpeg2000BoxType.MediaDataBox;
         mediaData.ReadBox = _readBox;

         mediaData.ShowDialog();
      }

      private void _miBPReadBinaryFilter_Click(object sender, EventArgs e)
      {
         ReadCommon binaryFilter = new ReadCommon(this, "Binary Filter", true);

         ReadBoxCommonStructure _readBox = new ReadBoxCommonStructure();
         _readBox.boxType = Jpeg2000BoxType.BinaryFilterBox;
         binaryFilter.ReadBox = _readBox;

         binaryFilter.ShowDialog();
      }

      private void _miBPReadAssociation_Click(object sender, EventArgs e)
      {
         ReadCommon association = new ReadCommon(this, "Association", false);

         ReadBoxCommonStructure _readBox = new ReadBoxCommonStructure();
         _readBox.boxType = Jpeg2000BoxType.AssociationBox;
         association.ReadBox = _readBox;

         association.ShowDialog();
      }

      private void _miBPReadFreeBox_Click(object sender, EventArgs e)
      {
         ReadCommon freeBox = new ReadCommon(this, "Free", false);

         ReadBoxCommonStructure _readBox = new ReadBoxCommonStructure();
         _readBox.boxType = Jpeg2000BoxType.FreeBox;
         freeBox.ReadBox = _readBox;

         freeBox.ShowDialog();
      }

      private void _miGMLAppend_Click(object sender, EventArgs e)
      {
         AppendGMLData appendGMLDataDlg = new AppendGMLData(this);

         appendGMLDataDlg.ShowDialog();
      }

      private void _miGMLRead_Click(object sender, EventArgs e)
      {
         ReadGML readGmlDialog = new ReadGML(this);

         readGmlDialog.ShowDialog();
      }

      private void _miWindow_Click(object sender, System.EventArgs e)
      {
         _checkedWindowMenu.Checked = false;

         if(sender == _miWindowCascade)
         {
            LayoutMdi(MdiLayout.Cascade);
            _checkedWindowMenu = _miWindowCascade;
         }
         else if(sender == _miWindowTileHorizontally)
         {
            LayoutMdi(MdiLayout.TileHorizontal);
            _checkedWindowMenu = _miWindowTileHorizontally;
         }
         else if(sender == _miWindowTileVertically)
         {
            LayoutMdi(MdiLayout.TileVertical);
            _checkedWindowMenu = _miWindowTileVertically;
         }
         else if(sender == _miWindowArrangeIcons)
         {
            LayoutMdi(MdiLayout.ArrangeIcons);
            _checkedWindowMenu = _miWindowArrangeIcons;
         }
         else if(sender == _miWindowCloseAll)
         {
            while(MdiChildren.Length > 0)
               MdiChildren[0].Close();
            UpdateControls();
            _checkedWindowMenu = _miWindowCascade;
         }
         _checkedWindowMenu.Checked = true;
      }

      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("JPX", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private ImageInformation LoadImage( )
      {
         ImageFileLoader loader = new ImageFileLoader();

         try
         {
            if(loader.Load(this, _codecs, false) > 0)
            {
               using(WaitCursor wait = new WaitCursor())
               {
                  RasterImage loadedImage = _codecs.Load(loader.FileName, 0, CodecsLoadByteOrder.BgrOrGray, 1, -1);
                  if(loadedImage.HasRegion)
                     loadedImage.MakeRegionEmpty();
                  return new ImageInformation(loadedImage, loader.FileName);
               }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }

         return null;
      }

      private void NewImage(ImageInformation info, bool isFile)
      {
         ViewerForm child = new ViewerForm(this, false);
         child.Initialize(info, _paintProperties, true, isFile);
         child.Show();
      }

      private void NewImage(List<CompositeJpxImages> compositeImage, string fileName)
      {
         ViewerForm child = new ViewerForm(this, true);
         child.Initialize(compositeImage, fileName, _paintProperties, true);
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

      private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
      }

      public void SetCheck(ViewerForm.ActiveImageLists ActiveList)
      {
         switch (ActiveList)
         {
            case ViewerForm.ActiveImageLists.ImagesList:
               _miViewImages.Checked = true;
               break;

            case ViewerForm.ActiveImageLists.ColorList:
               _miViewColor.Checked = true;
               break;

            case ViewerForm.ActiveImageLists.OpacityList:
               _miViewOpacity.Checked = true;
               break;

            case ViewerForm.ActiveImageLists.PreOpacityList:
               _miViewPreOpacity.Checked = true;
               break;
         }
      }

      void AnimationTimer_Tick(object sender, EventArgs e)
      {
         PlayAnimation();
      }

      private void PlayAnimation()
      {
         if(ActiveViewerForm == null || ActiveViewerForm.Viewer == null)
         {
            AnimationTimer.Stop();
            UpdateMenusItems();
            return;
         }

         ActiveViewerForm.Viewer.BeginUpdate();
         var items = ActiveViewerForm.ImageListControl.Items.GetSelected();
         if (items.Length == 0)
            return;

         int selectedIndex = Convert.ToInt32(items[0].Tag) - 1;

         if (selectedIndex < ActiveViewerForm.ImageListControl.Items.Count - 1 && !ActiveViewerForm.StopAnimation)
         {
            ActiveViewerForm.ImageListControl.Items[selectedIndex].IsSelected = false;
            selectedIndex++;
         }
         else
         {
            ActiveViewerForm.ImageListControl.Items[selectedIndex].IsSelected = false;
            selectedIndex = 0;

            if (!ActiveViewerForm.LoopAnimation || ActiveViewerForm.StopAnimation)
            {
               AnimationTimer.Stop();
               ActiveViewerForm.PlayingAnnimation = false;
               SetViewerLayout();

               UpdateMenusItems();
            }
         }

         ActiveViewerForm.ImageListControl.Items[selectedIndex].IsSelected = true;

         ActiveViewerForm.Viewer.Image = ActiveViewerForm.ImageListControl.Items[selectedIndex].Image;
         ActiveViewerForm.Viewer.Image.Page = ActiveViewerForm.ImageListControl.Items[selectedIndex].Image.Page;

         ActiveViewerForm.Viewer.EndUpdate();
      }

      private void SetViewerLayout()
      {
         if (ActiveViewerForm.PlayingAnnimation)
         {
            ActiveViewerForm.Viewer.SuspendLayout();
            Point loc = ActiveViewerForm.Viewer.Location;
            ActiveViewerForm.Viewer.Zoom(ControlSizeMode.Fit, 1.0, ActiveViewerForm.Viewer.DefaultZoomOrigin);
            ActiveViewerForm.Viewer.Dock = DockStyle.None;
            ActiveViewerForm.Viewer.Location = loc;
            ActiveViewerForm.Viewer.ClientSize = new Size(ActiveViewerForm.RenderWidth, ActiveViewerForm.RenderHeight);
            ActiveViewerForm.Viewer.ResumeLayout();
         }
         else
         {
            ActiveViewerForm.Viewer.SuspendLayout();
            ActiveViewerForm.Viewer.Zoom(ControlSizeMode.ActualSize, 1.0, ActiveViewerForm.Viewer.DefaultZoomOrigin);
            ActiveViewerForm.Viewer.Dock = DockStyle.Fill;
            ActiveViewerForm.Viewer.ResumeLayout();
         }
      }

      private void UpdateMenusItems()
      {
         if(ActiveViewerForm != null)
         {
            _miFile.Enabled = !ActiveViewerForm.PlayingAnnimation;
            _miEdit.Enabled = !ActiveViewerForm.PlayingAnnimation;
            _miView.Enabled = !ActiveViewerForm.PlayingAnnimation;

            _miAnimationPlay.Enabled = !ActiveViewerForm.PlayingAnnimation;
            _miAnimationStop.Enabled = ActiveViewerForm.PlayingAnnimation;
            _miAnimationSeperator1.Enabled = !ActiveViewerForm.PlayingAnnimation;
            _miAnimationLoop.Enabled = !ActiveViewerForm.PlayingAnnimation;
            _miAnimationSettings.Enabled = !ActiveViewerForm.PlayingAnnimation;
            _miAnimationSaveSettings.Enabled = !ActiveViewerForm.PlayingAnnimation;

            _miFileProcessing.Enabled = !ActiveViewerForm.PlayingAnnimation;
            _miBoxProcessing.Enabled = !ActiveViewerForm.PlayingAnnimation;
            _miGML.Enabled = !ActiveViewerForm.PlayingAnnimation;
            _miWindow.Enabled = !ActiveViewerForm.PlayingAnnimation;
            _miHelp.Enabled = !ActiveViewerForm.PlayingAnnimation;
         }
         else
         {
            _miFile.Enabled = true;
            _miEdit.Enabled = true;
            _miView.Enabled = true;

            _miAnimationPlay.Enabled = true;
            _miAnimationStop.Enabled = false;
            _miAnimationSeperator1.Enabled = true;
            _miAnimationLoop.Enabled = true;
            _miAnimationSettings.Enabled = true;
            _miAnimationSaveSettings.Enabled = true;

            _miFileProcessing.Enabled = true;
            _miBoxProcessing.Enabled = true;
            _miGML.Enabled = true;
            _miWindow.Enabled = true;
            _miHelp.Enabled = true;
         }
      }

   }
}
