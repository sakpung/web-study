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
using System.Configuration;
using System.Runtime.InteropServices;
using System.IO;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Dicom;
using Leadtools.Demos;
using Leadtools.DicomDemos;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.Effects;

using Leadtools.Dicom.Common;
using Leadtools.Dicom.Common.Extensions;
using ImageProcessingDemo;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Controls;
using Leadtools.Demos.Dialogs;
using DicomDemo.UI;
#endif

namespace DicomDemo
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu mainMenu1;
      private System.Windows.Forms.MenuItem menuItemTables;
      private System.Windows.Forms.MenuItem menuItem5;
      private System.Windows.Forms.MenuItem menuItemAbout;
      private System.Windows.Forms.MenuItem menuItemNew;
      private System.Windows.Forms.MenuItem menuItemOpen;
      private System.Windows.Forms.MenuItem menuItemClose;
      private System.Windows.Forms.MenuItem menuItem6;
      private System.Windows.Forms.MenuItem menuItemSave;
      private System.Windows.Forms.MenuItem menuItem7;
      private System.Windows.Forms.MenuItem menuItemInfo;
      private System.Windows.Forms.MenuItem menuItem8;
      private System.Windows.Forms.MenuItem menuItemExit;
      private System.Windows.Forms.MenuItem menuItemVR;
      private System.Windows.Forms.MenuItem menuItemUID;
      private System.Windows.Forms.MenuItem menuItemTag;
      private System.Windows.Forms.MenuItem menuItemIOD;
      private System.Windows.Forms.MenuItem menuItemGroups;
      private System.Windows.Forms.MenuItem menuItemElementInsert;
      private System.Windows.Forms.MenuItem menuItemElementDelete;
      private System.ComponentModel.IContainer components;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.Splitter splitter1;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.MenuItem menuItemView;
      private System.Windows.Forms.MenuItem menuItemNormal;
      private System.Windows.Forms.MenuItem menuItemFit;
      private System.Windows.Forms.MenuItem menuItem15;
      private System.Windows.Forms.MenuItem menuItemZoom2;
      private System.Windows.Forms.MenuItem menuItemZoom4;
      private System.Windows.Forms.MenuItem menuItemZoomHalf;
      private System.Windows.Forms.MenuItem menuItemZoomFourth;
      private System.Windows.Forms.MenuItem menuItemAnimation;
      private System.Windows.Forms.MenuItem menuItemZoomIn;
      private System.Windows.Forms.MenuItem menuItemZoomOut;
      private System.Windows.Forms.MenuItem menuItemDataset;
      private System.Windows.Forms.ImageList imageList1;
      private System.Windows.Forms.MenuItem menuItemFile;
      private System.Windows.Forms.MenuItem menuItemProcessing;
      private System.Windows.Forms.MenuItem menuItem3;
      private System.Windows.Forms.MenuItem menuItemInvert;
      private System.Windows.Forms.MenuItem menuItemBrightness;
      private System.Windows.Forms.MenuItem menuItemContrast;
      private System.Windows.Forms.MenuItem menuItemGrayscale;
      private System.Windows.Forms.MenuItem menuItemGrayscale8;
      private System.Windows.Forms.MenuItem menuItemGrayscale12;
      private System.Windows.Forms.MenuItem menuItemGrayscale16;

      private DicomDataSet ds;
      private System.Windows.Forms.MenuItem menuItemFlip;
      private System.Windows.Forms.MenuItem menuItemReverse;
      private System.Windows.Forms.MenuItem menuItemRotate;
      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem menuItemUpdate;
      private System.Windows.Forms.MenuItem menuItemPlay;
      private System.Windows.Forms.MenuItem menuItem13;
      private System.Windows.Forms.MenuItem menuItemFirst;
      private System.Windows.Forms.MenuItem menuItemNext;
      private System.Windows.Forms.MenuItem menuItemPrevious;
      private System.Windows.Forms.MenuItem menuItemLast;
      private System.Windows.Forms.PropertyGrid propertyGridElement;
      private System.Windows.Forms.SaveFileDialog saveFileDialog1;
      private System.Windows.Forms.MenuItem menuItemEdit;
      private int imgIndex = 0;
      private DicomImageInformation imageInfo = null;

      private bool _fileMenuEnabled = false;
      private bool _viewMenuEnabled = false;
      private bool _tablesMenuEnabled = false;
      private bool _datasetMenuEnabled = false;
      private bool _animationMenuEnabled = false;
      private bool _processingMenuEnabled = false;

      private WindowLevel wl = new WindowLevel();
      private TabControl tabControl1;
      private TabPage tabPage1;
      private TreeView treeViewElements;
      private Panel panel3;
      private TextBox textBoxValues;
      private Splitter splitter3;
      private Splitter splitter2;
      private MenuItem menuItem10;
      private MenuItem menuItemListView;
      private MenuItem menuItemModuleView;
      private MenuItem menuItem9;
      private MenuItem menuItem11;
      private MenuItem menuItemUnsharpMask;
      private MenuItem menuItem12;
      private MenuItem menuItemLoadXml;
      private MenuItem menuItemSaveXml;
      private MenuItem menuItem14;
      private MenuItem menuItem2;
      private MenuItem menuItemModifyTables;

      private bool listView = true;
      private MenuItem menuItemSaveNativeDicomModel;
      private MenuItem menuItemSaveDicomJsonModel;
      private MenuItem menuItem17;
      private MenuItem menuItemSaveNativeDicomOptions;
      private MenuItem menuItemSaveNativeDicom;
      private MenuItem menuItemSaveJsonOptions;
      private MenuItem menuItemSaveJson;
      private MenuItem menuItemLoadJson;
      private MenuItem menuItemViewHistogram;
      private MenuItem menuItemOptions;
      private MenuItem menuItemOptionsLoad;
      private string _openInitialPath = string.Empty;

      [DllImport("user32.dll")]
      static extern short GetKeyState(int nVirtKey);

      const int VK_CONTROL = 0x11;

      public bool isMonochrome1;

      public ToolTip _toolTip;

      public MainForm( )
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         Utils.EngineStartup();
         isMonochrome1 = false;
         _toolTip = new ToolTip();
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
         this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
         this.menuItemFile = new System.Windows.Forms.MenuItem();
         this.menuItemNew = new System.Windows.Forms.MenuItem();
         this.menuItemOpen = new System.Windows.Forms.MenuItem();
         this.menuItem12 = new System.Windows.Forms.MenuItem();
         this.menuItemLoadXml = new System.Windows.Forms.MenuItem();
         this.menuItemLoadJson = new System.Windows.Forms.MenuItem();
         this.menuItem17 = new System.Windows.Forms.MenuItem();
         this.menuItemSaveXml = new System.Windows.Forms.MenuItem();
         this.menuItemSaveNativeDicomModel = new System.Windows.Forms.MenuItem();
         this.menuItemSaveNativeDicomOptions = new System.Windows.Forms.MenuItem();
         this.menuItemSaveNativeDicom = new System.Windows.Forms.MenuItem();
         this.menuItemSaveDicomJsonModel = new System.Windows.Forms.MenuItem();
         this.menuItemSaveJsonOptions = new System.Windows.Forms.MenuItem();
         this.menuItemSaveJson = new System.Windows.Forms.MenuItem();
         this.menuItem6 = new System.Windows.Forms.MenuItem();
         this.menuItemSave = new System.Windows.Forms.MenuItem();
         this.menuItem14 = new System.Windows.Forms.MenuItem();
         this.menuItemClose = new System.Windows.Forms.MenuItem();
         this.menuItem7 = new System.Windows.Forms.MenuItem();
         this.menuItemInfo = new System.Windows.Forms.MenuItem();
         this.menuItem8 = new System.Windows.Forms.MenuItem();
         this.menuItemExit = new System.Windows.Forms.MenuItem();
         this.menuItemView = new System.Windows.Forms.MenuItem();
         this.menuItemNormal = new System.Windows.Forms.MenuItem();
         this.menuItemFit = new System.Windows.Forms.MenuItem();
         this.menuItem15 = new System.Windows.Forms.MenuItem();
         this.menuItemZoomIn = new System.Windows.Forms.MenuItem();
         this.menuItemZoom2 = new System.Windows.Forms.MenuItem();
         this.menuItemZoom4 = new System.Windows.Forms.MenuItem();
         this.menuItemZoomOut = new System.Windows.Forms.MenuItem();
         this.menuItemZoomHalf = new System.Windows.Forms.MenuItem();
         this.menuItemZoomFourth = new System.Windows.Forms.MenuItem();
         this.menuItemTables = new System.Windows.Forms.MenuItem();
         this.menuItemVR = new System.Windows.Forms.MenuItem();
         this.menuItemUID = new System.Windows.Forms.MenuItem();
         this.menuItemTag = new System.Windows.Forms.MenuItem();
         this.menuItemIOD = new System.Windows.Forms.MenuItem();
         this.menuItemGroups = new System.Windows.Forms.MenuItem();
         this.menuItem2 = new System.Windows.Forms.MenuItem();
         this.menuItemModifyTables = new System.Windows.Forms.MenuItem();
         this.menuItemDataset = new System.Windows.Forms.MenuItem();
         this.menuItemEdit = new System.Windows.Forms.MenuItem();
         this.menuItem9 = new System.Windows.Forms.MenuItem();
         this.menuItemElementInsert = new System.Windows.Forms.MenuItem();
         this.menuItemElementDelete = new System.Windows.Forms.MenuItem();
         this.menuItem11 = new System.Windows.Forms.MenuItem();
         this.menuItemUpdate = new System.Windows.Forms.MenuItem();
         this.menuItem10 = new System.Windows.Forms.MenuItem();
         this.menuItemListView = new System.Windows.Forms.MenuItem();
         this.menuItemModuleView = new System.Windows.Forms.MenuItem();
         this.menuItemAnimation = new System.Windows.Forms.MenuItem();
         this.menuItemPlay = new System.Windows.Forms.MenuItem();
         this.menuItem13 = new System.Windows.Forms.MenuItem();
         this.menuItemFirst = new System.Windows.Forms.MenuItem();
         this.menuItemNext = new System.Windows.Forms.MenuItem();
         this.menuItemPrevious = new System.Windows.Forms.MenuItem();
         this.menuItemLast = new System.Windows.Forms.MenuItem();
         this.menuItemProcessing = new System.Windows.Forms.MenuItem();
         this.menuItemFlip = new System.Windows.Forms.MenuItem();
         this.menuItemReverse = new System.Windows.Forms.MenuItem();
         this.menuItemRotate = new System.Windows.Forms.MenuItem();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this.menuItemGrayscale = new System.Windows.Forms.MenuItem();
         this.menuItemGrayscale8 = new System.Windows.Forms.MenuItem();
         this.menuItemGrayscale12 = new System.Windows.Forms.MenuItem();
         this.menuItemGrayscale16 = new System.Windows.Forms.MenuItem();
         this.menuItem3 = new System.Windows.Forms.MenuItem();
         this.menuItemInvert = new System.Windows.Forms.MenuItem();
         this.menuItemBrightness = new System.Windows.Forms.MenuItem();
         this.menuItemContrast = new System.Windows.Forms.MenuItem();
         this.menuItemUnsharpMask = new System.Windows.Forms.MenuItem();
         this.menuItemViewHistogram = new System.Windows.Forms.MenuItem();
         this.menuItemOptions = new System.Windows.Forms.MenuItem();
         this.menuItemOptionsLoad = new System.Windows.Forms.MenuItem();
         this.menuItem5 = new System.Windows.Forms.MenuItem();
         this.menuItemAbout = new System.Windows.Forms.MenuItem();
         this.panel1 = new System.Windows.Forms.Panel();
         this.panel2 = new System.Windows.Forms.Panel();
         this.panel3 = new System.Windows.Forms.Panel();
         this.textBoxValues = new System.Windows.Forms.TextBox();
         this.splitter3 = new System.Windows.Forms.Splitter();
         this.propertyGridElement = new System.Windows.Forms.PropertyGrid();
         this.splitter2 = new System.Windows.Forms.Splitter();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPage1 = new System.Windows.Forms.TabPage();
         this.treeViewElements = new System.Windows.Forms.TreeView();
         this.imageList1 = new System.Windows.Forms.ImageList(this.components);
         this.splitter1 = new System.Windows.Forms.Splitter();
         this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
         this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
         this.panel2.SuspendLayout();
         this.panel3.SuspendLayout();
         this.tabControl1.SuspendLayout();
         this.tabPage1.SuspendLayout();
         this.SuspendLayout();
         // 
         // mainMenu1
         // 
         this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemView,
            this.menuItemTables,
            this.menuItemDataset,
            this.menuItemAnimation,
            this.menuItemProcessing,
            this.menuItemOptions,
            this.menuItem5});
         // 
         // menuItemFile
         // 
         this.menuItemFile.Index = 0;
         this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNew,
            this.menuItemOpen,
            this.menuItem12,
            this.menuItemLoadXml,
            this.menuItemLoadJson,
            this.menuItem17,
            this.menuItemSaveXml,
            this.menuItemSaveNativeDicomModel,
            this.menuItemSaveDicomJsonModel,
            this.menuItem6,
            this.menuItemSave,
            this.menuItem14,
            this.menuItemClose,
            this.menuItem7,
            this.menuItemInfo,
            this.menuItem8,
            this.menuItemExit});
         this.menuItemFile.Text = "&File";
         this.menuItemFile.Popup += new System.EventHandler(this.menuItemFile_Popup);
         // 
         // menuItemNew
         // 
         this.menuItemNew.Index = 0;
         this.menuItemNew.Text = "&New...";
         this.menuItemNew.Click += new System.EventHandler(this.menuItemNew_Click);
         // 
         // menuItemOpen
         // 
         this.menuItemOpen.Index = 1;
         this.menuItemOpen.Text = "&Open...";
         this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
         // 
         // menuItem12
         // 
         this.menuItem12.Index = 2;
         this.menuItem12.Text = "-";
         // 
         // menuItemLoadXml
         // 
         this.menuItemLoadXml.Index = 3;
         this.menuItemLoadXml.Text = "Open DICOM XML...";
         this.menuItemLoadXml.Click += new System.EventHandler(this.menuItemLoadXml_Click);
         // 
         // menuItemLoadJson
         // 
         this.menuItemLoadJson.Index = 4;
         this.menuItemLoadJson.Text = "Open DICOM JSON...";
         this.menuItemLoadJson.Click += new System.EventHandler(this.menuItemLoadJson_Click);
         // 
         // menuItem17
         // 
         this.menuItem17.Index = 5;
         this.menuItem17.Text = "-";
         // 
         // menuItemSaveXml
         // 
         this.menuItemSaveXml.Index = 6;
         this.menuItemSaveXml.Text = "Save DICOM XML...";
         this.menuItemSaveXml.Click += new System.EventHandler(this.menuItemSaveXml_Click);
         // 
         // menuItemSaveNativeDicomModel
         // 
         this.menuItemSaveNativeDicomModel.Index = 7;
         this.menuItemSaveNativeDicomModel.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSaveNativeDicomOptions,
            this.menuItemSaveNativeDicom});
         this.menuItemSaveNativeDicomModel.Text = "Save Native DICOM Model (xml)";
         // 
         // menuItemSaveNativeDicomOptions
         // 
         this.menuItemSaveNativeDicomOptions.Index = 0;
         this.menuItemSaveNativeDicomOptions.Text = "Options...";
         this.menuItemSaveNativeDicomOptions.Click += new System.EventHandler(this.menuItemSaveNativeDicomOptions_Click);
         // 
         // menuItemSaveNativeDicom
         // 
         this.menuItemSaveNativeDicom.Index = 1;
         this.menuItemSaveNativeDicom.Text = "Save...";
         this.menuItemSaveNativeDicom.Click += new System.EventHandler(this.menuItemSaveNativeDicom_Click);
         // 
         // menuItemSaveDicomJsonModel
         // 
         this.menuItemSaveDicomJsonModel.Index = 8;
         this.menuItemSaveDicomJsonModel.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSaveJsonOptions,
            this.menuItemSaveJson});
         this.menuItemSaveDicomJsonModel.Text = "Save DICOM JSON Model (json)";
         // 
         // menuItemSaveJsonOptions
         // 
         this.menuItemSaveJsonOptions.Index = 0;
         this.menuItemSaveJsonOptions.Text = "Options...";
         this.menuItemSaveJsonOptions.Click += new System.EventHandler(this.menuItemSaveJsonOptions_Click);
         // 
         // menuItemSaveJson
         // 
         this.menuItemSaveJson.Index = 1;
         this.menuItemSaveJson.Text = "Save...";
         this.menuItemSaveJson.Click += new System.EventHandler(this.menuItemSaveJson_Click);
         // 
         // menuItem6
         // 
         this.menuItem6.Index = 9;
         this.menuItem6.Text = "-";
         // 
         // menuItemSave
         // 
         this.menuItemSave.Enabled = false;
         this.menuItemSave.Index = 10;
         this.menuItemSave.Text = "&Save DICOM (dcm)...";
         this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
         // 
         // menuItem14
         // 
         this.menuItem14.Index = 11;
         this.menuItem14.Text = "-";
         // 
         // menuItemClose
         // 
         this.menuItemClose.Enabled = false;
         this.menuItemClose.Index = 12;
         this.menuItemClose.Text = "&Close";
         this.menuItemClose.Click += new System.EventHandler(this.menuItemClose_Click);
         // 
         // menuItem7
         // 
         this.menuItem7.Index = 13;
         this.menuItem7.Text = "-";
         // 
         // menuItemInfo
         // 
         this.menuItemInfo.Index = 14;
         this.menuItemInfo.Text = "&Info...";
         this.menuItemInfo.Click += new System.EventHandler(this.menuItemInfo_Click);
         // 
         // menuItem8
         // 
         this.menuItem8.Index = 15;
         this.menuItem8.Text = "-";
         // 
         // menuItemExit
         // 
         this.menuItemExit.Index = 16;
         this.menuItemExit.Text = "&Exit";
         this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
         // 
         // menuItemView
         // 
         this.menuItemView.Index = 1;
         this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNormal,
            this.menuItemFit,
            this.menuItem15,
            this.menuItemZoomIn,
            this.menuItemZoomOut});
         this.menuItemView.Text = "&View";
         this.menuItemView.Popup += new System.EventHandler(this.menuItemView_Popup);
         // 
         // menuItemNormal
         // 
         this.menuItemNormal.Checked = true;
         this.menuItemNormal.Index = 0;
         this.menuItemNormal.Text = "&Normal";
         this.menuItemNormal.Click += new System.EventHandler(this.menuItemNormal_Click);
         // 
         // menuItemFit
         // 
         this.menuItemFit.Index = 1;
         this.menuItemFit.Text = "&Fit";
         this.menuItemFit.Click += new System.EventHandler(this.menuItemFit_Click);
         // 
         // menuItem15
         // 
         this.menuItem15.Index = 2;
         this.menuItem15.Text = "-";
         // 
         // menuItemZoomIn
         // 
         this.menuItemZoomIn.Index = 3;
         this.menuItemZoomIn.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemZoom2,
            this.menuItemZoom4});
         this.menuItemZoomIn.Text = "Zoom &In";
         // 
         // menuItemZoom2
         // 
         this.menuItemZoom2.Index = 0;
         this.menuItemZoom2.Text = "&2x";
         this.menuItemZoom2.Click += new System.EventHandler(this.menuItemZoom2_Click);
         // 
         // menuItemZoom4
         // 
         this.menuItemZoom4.Index = 1;
         this.menuItemZoom4.Text = "&4x";
         this.menuItemZoom4.Click += new System.EventHandler(this.menuItemZoom4_Click);
         // 
         // menuItemZoomOut
         // 
         this.menuItemZoomOut.Index = 4;
         this.menuItemZoomOut.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemZoomHalf,
            this.menuItemZoomFourth});
         this.menuItemZoomOut.Text = "Zoom &Out";
         // 
         // menuItemZoomHalf
         // 
         this.menuItemZoomHalf.Index = 0;
         this.menuItemZoomHalf.Text = "1/2x";
         this.menuItemZoomHalf.Click += new System.EventHandler(this.menuItemZoomHalf_Click);
         // 
         // menuItemZoomFourth
         // 
         this.menuItemZoomFourth.Index = 1;
         this.menuItemZoomFourth.Text = "1/4x";
         this.menuItemZoomFourth.Click += new System.EventHandler(this.menuItemZoomFourth_Click);
         // 
         // menuItemTables
         // 
         this.menuItemTables.Index = 2;
         this.menuItemTables.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemVR,
            this.menuItemUID,
            this.menuItemTag,
            this.menuItemIOD,
            this.menuItemGroups,
            this.menuItem2,
            this.menuItemModifyTables});
         this.menuItemTables.Text = "&Tables";
         // 
         // menuItemVR
         // 
         this.menuItemVR.Index = 0;
         this.menuItemVR.Text = "&Value Representation (VR)...";
         this.menuItemVR.Click += new System.EventHandler(this.menuItemVR_Click);
         // 
         // menuItemUID
         // 
         this.menuItemUID.Index = 1;
         this.menuItemUID.Text = "&Unique Identifier (UID)...";
         this.menuItemUID.Click += new System.EventHandler(this.menuItemUID_Click);
         // 
         // menuItemTag
         // 
         this.menuItemTag.Index = 2;
         this.menuItemTag.Text = "&Element Tag...";
         this.menuItemTag.Click += new System.EventHandler(this.menuItemTag_Click);
         // 
         // menuItemIOD
         // 
         this.menuItemIOD.Index = 3;
         this.menuItemIOD.Text = "Information Object Definition (IOD)...";
         this.menuItemIOD.Click += new System.EventHandler(this.menuItemIOD_Click);
         // 
         // menuItemGroups
         // 
         this.menuItemGroups.Index = 4;
         this.menuItemGroups.Text = "Context Groups...";
         this.menuItemGroups.Click += new System.EventHandler(this.menuItemGroups_Click);
         // 
         // menuItem2
         // 
         this.menuItem2.Index = 5;
         this.menuItem2.Text = "-";
         // 
         // menuItemModifyTables
         // 
         this.menuItemModifyTables.Index = 6;
         this.menuItemModifyTables.Text = "Modify Tables...";
         this.menuItemModifyTables.Click += new System.EventHandler(this.menuItemModifyTables_Click);
         // 
         // menuItemDataset
         // 
         this.menuItemDataset.Enabled = false;
         this.menuItemDataset.Index = 3;
         this.menuItemDataset.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemEdit,
            this.menuItem9,
            this.menuItemElementInsert,
            this.menuItemElementDelete,
            this.menuItem11,
            this.menuItemUpdate,
            this.menuItem10,
            this.menuItemListView,
            this.menuItemModuleView});
         this.menuItemDataset.Text = "&Dataset";
         this.menuItemDataset.Popup += new System.EventHandler(this.menuItemDataset_Popup);
         // 
         // menuItemEdit
         // 
         this.menuItemEdit.Index = 0;
         this.menuItemEdit.Text = "&Edit Values...";
         this.menuItemEdit.Click += new System.EventHandler(this.menuItemEdit_Click);
         // 
         // menuItem9
         // 
         this.menuItem9.Index = 1;
         this.menuItem9.Text = "-";
         // 
         // menuItemElementInsert
         // 
         this.menuItemElementInsert.Index = 2;
         this.menuItemElementInsert.Text = "&Insert...";
         this.menuItemElementInsert.Click += new System.EventHandler(this.menuItemElementInsert_Click);
         // 
         // menuItemElementDelete
         // 
         this.menuItemElementDelete.Index = 3;
         this.menuItemElementDelete.Text = "&Delete";
         this.menuItemElementDelete.Click += new System.EventHandler(this.menuItemElementDelete_Click);
         // 
         // menuItem11
         // 
         this.menuItem11.Index = 4;
         this.menuItem11.Text = "-";
         // 
         // menuItemUpdate
         // 
         this.menuItemUpdate.Index = 5;
         this.menuItemUpdate.Text = "Update Pixel Data Element...";
         this.menuItemUpdate.Click += new System.EventHandler(this.menuItemUpdate_Click);
         // 
         // menuItem10
         // 
         this.menuItem10.Index = 6;
         this.menuItem10.Text = "-";
         // 
         // menuItemListView
         // 
         this.menuItemListView.Index = 7;
         this.menuItemListView.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftL;
         this.menuItemListView.Text = "&List View";
         this.menuItemListView.Click += new System.EventHandler(this.menuItemListView_Click);
         // 
         // menuItemModuleView
         // 
         this.menuItemModuleView.Index = 8;
         this.menuItemModuleView.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftM;
         this.menuItemModuleView.Text = "&Module View";
         this.menuItemModuleView.Click += new System.EventHandler(this.menuItemModuleView_Click);
         // 
         // menuItemAnimation
         // 
         this.menuItemAnimation.Enabled = false;
         this.menuItemAnimation.Index = 4;
         this.menuItemAnimation.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemPlay,
            this.menuItem13,
            this.menuItemFirst,
            this.menuItemNext,
            this.menuItemPrevious,
            this.menuItemLast});
         this.menuItemAnimation.Text = "&Animation";
         this.menuItemAnimation.Popup += new System.EventHandler(this.menuItemAnimation_Popup);
         // 
         // menuItemPlay
         // 
         this.menuItemPlay.Index = 0;
         this.menuItemPlay.Text = "&Play";
         this.menuItemPlay.Click += new System.EventHandler(this.menuItemPlay_Click);
         // 
         // menuItem13
         // 
         this.menuItem13.Index = 1;
         this.menuItem13.Text = "-";
         // 
         // menuItemFirst
         // 
         this.menuItemFirst.Index = 2;
         this.menuItemFirst.Text = "&First";
         this.menuItemFirst.Click += new System.EventHandler(this.menuItemFirst_Click);
         // 
         // menuItemNext
         // 
         this.menuItemNext.Index = 3;
         this.menuItemNext.Text = "&Next";
         this.menuItemNext.Click += new System.EventHandler(this.menuItemNext_Click);
         // 
         // menuItemPrevious
         // 
         this.menuItemPrevious.Index = 4;
         this.menuItemPrevious.Text = "Pre&vious";
         this.menuItemPrevious.Click += new System.EventHandler(this.menuItemPrevious_Click);
         // 
         // menuItemLast
         // 
         this.menuItemLast.Index = 5;
         this.menuItemLast.Text = "L&ast";
         this.menuItemLast.Click += new System.EventHandler(this.menuItemLast_Click);
         // 
         // menuItemProcessing
         // 
         this.menuItemProcessing.Enabled = false;
         this.menuItemProcessing.Index = 5;
         this.menuItemProcessing.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFlip,
            this.menuItemReverse,
            this.menuItemRotate,
            this.menuItem1,
            this.menuItemGrayscale,
            this.menuItem3,
            this.menuItemInvert,
            this.menuItemBrightness,
            this.menuItemContrast,
            this.menuItemUnsharpMask,
            this.menuItemViewHistogram});
         this.menuItemProcessing.Text = "&Processing";
         this.menuItemProcessing.Popup += new System.EventHandler(this.menuItemProcessing_Popup);
         // 
         // menuItemFlip
         // 
         this.menuItemFlip.Index = 0;
         this.menuItemFlip.Text = "&Flip";
         this.menuItemFlip.Click += new System.EventHandler(this.menuItemFlip_Click);
         // 
         // menuItemReverse
         // 
         this.menuItemReverse.Index = 1;
         this.menuItemReverse.Text = "&Reverse";
         this.menuItemReverse.Click += new System.EventHandler(this.menuItemReverse_Click);
         // 
         // menuItemRotate
         // 
         this.menuItemRotate.Index = 2;
         this.menuItemRotate.Text = "Ro&tate...";
         this.menuItemRotate.Click += new System.EventHandler(this.menuItemRotate_Click);
         // 
         // menuItem1
         // 
         this.menuItem1.Index = 3;
         this.menuItem1.Text = "-";
         // 
         // menuItemGrayscale
         // 
         this.menuItemGrayscale.Index = 4;
         this.menuItemGrayscale.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemGrayscale8,
            this.menuItemGrayscale12,
            this.menuItemGrayscale16});
         this.menuItemGrayscale.Text = "GrayScale";
         // 
         // menuItemGrayscale8
         // 
         this.menuItemGrayscale8.Index = 0;
         this.menuItemGrayscale8.Text = "&8";
         this.menuItemGrayscale8.Click += new System.EventHandler(this.menuItemGrayscale8_Click);
         // 
         // menuItemGrayscale12
         // 
         this.menuItemGrayscale12.Index = 1;
         this.menuItemGrayscale12.Text = "1&2";
         this.menuItemGrayscale12.Click += new System.EventHandler(this.menuItemGrayscale12_Click);
         // 
         // menuItemGrayscale16
         // 
         this.menuItemGrayscale16.Index = 2;
         this.menuItemGrayscale16.Text = "1&6";
         this.menuItemGrayscale16.Click += new System.EventHandler(this.menuItemGrayscale16_Click);
         // 
         // menuItem3
         // 
         this.menuItem3.Index = 5;
         this.menuItem3.Text = "-";
         // 
         // menuItemInvert
         // 
         this.menuItemInvert.Index = 6;
         this.menuItemInvert.Text = "&Invert";
         this.menuItemInvert.Click += new System.EventHandler(this.menuItemInvert_Click);
         // 
         // menuItemBrightness
         // 
         this.menuItemBrightness.Index = 7;
         this.menuItemBrightness.Text = "&Brightness...";
         this.menuItemBrightness.Click += new System.EventHandler(this.menuItemBrightness_Click);
         // 
         // menuItemContrast
         // 
         this.menuItemContrast.Index = 8;
         this.menuItemContrast.Text = "&Contrast...";
         this.menuItemContrast.Click += new System.EventHandler(this.menuItemContrast_Click);
         // 
         // menuItemUnsharpMask
         // 
         this.menuItemUnsharpMask.Index = 9;
         this.menuItemUnsharpMask.Text = "&Unsharp Mask...";
         this.menuItemUnsharpMask.Click += new System.EventHandler(this.menuItemUnsharpMask_Click);
         // 
         // menuItemViewHistogram
         // 
         this.menuItemViewHistogram.Index = 10;
         this.menuItemViewHistogram.Text = "&View Histogram...";
         this.menuItemViewHistogram.Click += new System.EventHandler(this.menuItemViewHistogram_Click);
         // 
         // menuItemOptions
         // 
         this.menuItemOptions.Index = 6;
         this.menuItemOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOptionsLoad});
         this.menuItemOptions.Text = "&Options";
         // 
         // menuItemOptionsLoad
         // 
         this.menuItemOptionsLoad.Index = 0;
         this.menuItemOptionsLoad.Text = "Load...";
         this.menuItemOptionsLoad.Click += new System.EventHandler(this.menuItemOptionsLoad_Click);
         // 
         // menuItem5
         // 
         this.menuItem5.Index = 7;
         this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemAbout});
         this.menuItem5.Text = "&Help";
         // 
         // menuItemAbout
         // 
         this.menuItemAbout.Index = 0;
         this.menuItemAbout.Text = "&About";
         this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
         // 
         // panel1
         // 
         this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(688, 337);
         this.panel1.TabIndex = 0;
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.panel3);
         this.panel2.Controls.Add(this.splitter2);
         this.panel2.Controls.Add(this.tabControl1);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel2.Location = new System.Drawing.Point(0, 337);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(688, 160);
         this.panel2.TabIndex = 1;
         // 
         // panel3
         // 
         this.panel3.Controls.Add(this.textBoxValues);
         this.panel3.Controls.Add(this.splitter3);
         this.panel3.Controls.Add(this.propertyGridElement);
         this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel3.Location = new System.Drawing.Point(422, 0);
         this.panel3.Name = "panel3";
         this.panel3.Size = new System.Drawing.Size(266, 160);
         this.panel3.TabIndex = 7;
         // 
         // textBoxValues
         // 
         this.textBoxValues.Dock = System.Windows.Forms.DockStyle.Fill;
         this.textBoxValues.Location = new System.Drawing.Point(0, 92);
         this.textBoxValues.Multiline = true;
         this.textBoxValues.Name = "textBoxValues";
         this.textBoxValues.ReadOnly = true;
         this.textBoxValues.Size = new System.Drawing.Size(266, 68);
         this.textBoxValues.TabIndex = 4;
         // 
         // splitter3
         // 
         this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
         this.splitter3.Location = new System.Drawing.Point(0, 89);
         this.splitter3.Name = "splitter3";
         this.splitter3.Size = new System.Drawing.Size(266, 3);
         this.splitter3.TabIndex = 3;
         this.splitter3.TabStop = false;
         // 
         // propertyGridElement
         // 
         this.propertyGridElement.Dock = System.Windows.Forms.DockStyle.Top;
         this.propertyGridElement.HelpVisible = false;
         this.propertyGridElement.LineColor = System.Drawing.SystemColors.ScrollBar;
         this.propertyGridElement.Location = new System.Drawing.Point(0, 0);
         this.propertyGridElement.Name = "propertyGridElement";
         this.propertyGridElement.PropertySort = System.Windows.Forms.PropertySort.NoSort;
         this.propertyGridElement.Size = new System.Drawing.Size(266, 89);
         this.propertyGridElement.TabIndex = 2;
         this.propertyGridElement.ToolbarVisible = false;
         // 
         // splitter2
         // 
         this.splitter2.Location = new System.Drawing.Point(419, 0);
         this.splitter2.Name = "splitter2";
         this.splitter2.Size = new System.Drawing.Size(3, 160);
         this.splitter2.TabIndex = 6;
         this.splitter2.TabStop = false;
         // 
         // tabControl1
         // 
         this.tabControl1.Controls.Add(this.tabPage1);
         this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
         this.tabControl1.Location = new System.Drawing.Point(0, 0);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(419, 160);
         this.tabControl1.TabIndex = 5;
         // 
         // tabPage1
         // 
         this.tabPage1.Controls.Add(this.treeViewElements);
         this.tabPage1.Location = new System.Drawing.Point(4, 22);
         this.tabPage1.Name = "tabPage1";
         this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
         this.tabPage1.Size = new System.Drawing.Size(411, 134);
         this.tabPage1.TabIndex = 0;
         this.tabPage1.Text = "List View";
         this.tabPage1.UseVisualStyleBackColor = true;
         // 
         // treeViewElements
         // 
         this.treeViewElements.Dock = System.Windows.Forms.DockStyle.Fill;
         this.treeViewElements.FullRowSelect = true;
         this.treeViewElements.HideSelection = false;
         this.treeViewElements.ImageIndex = 0;
         this.treeViewElements.ImageList = this.imageList1;
         this.treeViewElements.Location = new System.Drawing.Point(3, 3);
         this.treeViewElements.Name = "treeViewElements";
         this.treeViewElements.SelectedImageIndex = 0;
         this.treeViewElements.Size = new System.Drawing.Size(405, 128);
         this.treeViewElements.TabIndex = 0;
         this.treeViewElements.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewElements_AfterSelect);
         // 
         // imageList1
         // 
         this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
         this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
         this.imageList1.Images.SetKeyName(0, "");
         this.imageList1.Images.SetKeyName(1, "");
         this.imageList1.Images.SetKeyName(2, "");
         this.imageList1.Images.SetKeyName(3, "");
         // 
         // splitter1
         // 
         this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.splitter1.Location = new System.Drawing.Point(0, 334);
         this.splitter1.Name = "splitter1";
         this.splitter1.Size = new System.Drawing.Size(688, 3);
         this.splitter1.TabIndex = 2;
         this.splitter1.TabStop = false;
         // 
         // openFileDialog1
         // 
         this.openFileDialog1.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*";
         this.openFileDialog1.Multiselect = true;
         this.openFileDialog1.Title = "Open Dicom File";
         // 
         // MainForm
         // 
         this.AllowDrop = true;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(688, 497);
         this.Controls.Add(this.splitter1);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.panel2);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this.mainMenu1;
         this.Name = "MainForm";
         this.Text = "DICOM Demo - C#";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
         this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
         this.panel2.ResumeLayout(false);
         this.panel3.ResumeLayout(false);
         this.panel3.PerformLayout();
         this.tabControl1.ResumeLayout(false);
         this.tabPage1.ResumeLayout(false);
         this.ResumeLayout(false);

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

         if (RasterSupport.IsLocked(RasterSupportType.Medical))
         {
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Medical.ToString()), "Warning");
            return;
         }

         Application.Run(new MainForm());
      }

      private DicomGetImageFlags _getImageFlags =
                              DicomGetImageFlags.AutoApplyModalityLut |
                              DicomGetImageFlags.AutoApplyVoiLut |
                              DicomGetImageFlags.AutoScaleModalityLut |
                              DicomGetImageFlags.AutoScaleVoiLut |
                              DicomGetImageFlags.AutoDetectInvalidRleCompression | 
                              DicomGetImageFlags.LoadCorrupted;

      // Raster viewer object.
      private ImageViewer _viewer;
      private string TempOutPdf = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\TempPdf";
      private void menuItemAbout_Click(object sender, System.EventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         using (AboutDialog aboutDialog = new AboutDialog("DICOM", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("DICOM"))
            aboutDialog.ShowDialog(this);
#endif
      }

      private void menuItemExit_Click(object sender, System.EventArgs e)
      {
         Application.Exit();
      }

      private void menuItemGroups_Click(object sender, System.EventArgs e)
      {
         Cursor = Cursors.WaitCursor;
         Tools.ShowContextGroupTable();
         Cursor = Cursors.Arrow;
      }

      private bool IsIodTableLoaded()
      {
         DicomIod iod = DicomIodTable.Instance.GetFirst(null, false);
         return (iod != null);
      }

      private void MainForm_Load(object sender, System.EventArgs e)
      {
         // Initialize the viewer object.
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.Zoom(ControlSizeMode.ActualSize, 1, _viewer.DefaultZoomOrigin);  
         _viewer.BackColor = SystemColors.ControlText;
         panel1.Controls.Add(_viewer);

         _viewer.BringToFront();
         _viewer.MouseDown+=new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseUp +=new MouseEventHandler(_viewer_MouseUp);
         _viewer.MouseMove +=new MouseEventHandler(_viewer_MouseMove);

         ds = new DicomDataSet();

         if(ds == null)
         {
            MessageBox.Show("Can't create dicom object. Quitting app.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
            return;
         }

         panel2.Height = Convert.ToInt32(ClientSize.Height * .30);
         tabControl1.Width = Convert.ToInt32(ClientSize.Width * .75);
         textBoxValues.Height = Convert.ToInt32(panel3.Height / 2);
         BringToFront();

         Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

         LoadImage(true);

         menuItem12.Visible = false;
         menuItemLoadXml.Visible = false;
         menuItemSaveXml.Visible = false;
         menuItem12.Visible = true;
         menuItemLoadXml.Visible = true;
         menuItemSaveXml.Visible = true;

         if (false == IsIodTableLoaded())
         {
            MessageBox.Show("The IOD Table is empty because Leadtools.Dicom.Tables.dll is missing.\n\nThe 'Module View' is consqeuently disabled.  To re-enable the 'Module View', load the IOD Table as follows:\n\n\tTables->Modify Tables->Load from file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listView = true;
         }
#if LEADTOOLS_V19_OR_LATER
         menuItemSaveNativeDicomModel.Visible = true;
         menuItemSaveDicomJsonModel.Visible = true;
         menuItemLoadJson.Visible = true;
#else
         menuItemSaveNativeDicomModel.Visible = false;
         menuItemSaveDicomJsonModel.Visible = false;
         menuItemLoadJson.Visible = false;
#endif // #if LEADTOOLS_V19_OR_LATER
      }

      void Application_ApplicationExit(object sender, EventArgs e)
      {
         Utils.EngineShutdown();
      }

      private void FreeImage( )
      {
         if(_viewer.Image != null)
         {
            if(_viewer.Image.PageCount > 1)
            {
               _viewer.Image.RemoveAllPages();
            }

            _viewer.Image.Dispose();
            _viewer.Image = null;
         }
      }

      private DicomGetValueResult GetWindowValuesFromDataset(WindowLevel wl)
      {
         double width = ds.GetValue(DicomTag.WindowWidth, 0.0);
         if (ds.GetValueResult != DicomGetValueResult.Success)
            return ds.GetValueResult;

         double center = ds.GetValue(DicomTag.WindowCenter, 0.0);
         if (ds.GetValueResult != DicomGetValueResult.Success)
            return ds.GetValueResult;

         wl.WindowWidth = width;
         wl.WindowCenter = center;

         return DicomGetValueResult.Success;
      }

      private void GetWindowLevelValues()
      {
         bool bSuccess = false;
         string sPhoto = ds.GetValue(DicomTag.PhotometricInterpretation, string.Empty);
         isMonochrome1 =  (string.Compare(sPhoto, "MONOCHROME1", true) == 0);

         try
         {
            DicomGetValueResult vr = GetWindowValuesFromDataset(wl);
            if (vr == DicomGetValueResult.Success)
               bSuccess = true;
         }
         catch (Exception)
         {
         }

         if (bSuccess)
            return;

         try
         {
            // First see if there is a linear VOI LUT
            GetLinearVoiLookupTableCommand command = new GetLinearVoiLookupTableCommand();
            command.Flags = GetLinearVoiLookupTableCommandFlags.None;
            command.Run(_viewer.Image);
            wl.WindowCenter = command.Center;
            wl.WindowWidth = command.Width;
            bSuccess = true;
         }
         catch (Exception)
         {
         }

         if (bSuccess)
            return;

         try
         {
            // Next try for a non-linear VOI LUT
            DicomVoiLutAttributes voiLut = ds.GetVoiLut(0);
            int[] data = ds.GetVoiLutData(0);

            int nMin = Math.Min(data[0], data[data.Length - 1]);
            int nMax = Math.Max(data[0], data[data.Length - 1]);
            wl.WindowCenter = (nMax + nMin) / 2;
            wl.WindowWidth = (nMax - nMin) / 2;

            bSuccess = true;
         }
         catch (Exception)
         {
         }

         if (bSuccess)
            return;

         try
         {
            // Finally, just use max and min value
            int nMax = _viewer.Image.MaxValue;
            int nMin = _viewer.Image.MinValue;
            wl.WindowCenter = (nMax + nMin) / 2;
            wl.WindowWidth = (nMax - nMin) / 2;
         }
         catch (Exception)
         {
         }

      }

      private void menuItemVR_Click(object sender, System.EventArgs e)
      {
         ValueRepresentationDlg dlgVR = new ValueRepresentationDlg(ds);

         dlgVR.ShowDialog();
      }

      private void menuItemUID_Click(object sender, System.EventArgs e)
      {
         Cursor = Cursors.WaitCursor;
         Tools.ShowUidTable();
         Cursor = Cursors.Arrow;
      }

      private void menuItemTag_Click(object sender, System.EventArgs e)
      {
         Cursor = Cursors.WaitCursor;
         Tools.ShowTagTable();
         Cursor = Cursors.Arrow;
      }

      private void menuItemIOD_Click(object sender, System.EventArgs e)
      {
         Cursor = Cursors.WaitCursor;
         Tools.ShowIodTable();
         Cursor = Cursors.Arrow;
      }

      private void menuItemOpen_Click(object sender, System.EventArgs e)
      {
         LoadImage(false);
      }

      private void LoadImage(bool loadDefaultImage)
      {
         try
         {
            if (loadDefaultImage)
            {
               menuItemClose_Click(null, new EventArgs());
#if LT_CLICKONCE
               OpenDataset(Path.GetDirectoryName(Application.ExecutablePath) + @"\image2.dcm");
#else
               OpenDataset(DemosGlobal.ImagesFolder + @"\image2.dcm");
#endif // LT_CLICKONCE
            }
            else
            {
               this.openFileDialog1.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*";
               this.openFileDialog1.Multiselect = true;
               this.openFileDialog1.Title = "Open Dicom File";
               this.openFileDialog1.InitialDirectory = _openInitialPath;
               if (openFileDialog1.ShowDialog() == DialogResult.OK)
               {
                  _openInitialPath = Path.GetDirectoryName(openFileDialog1.FileName);
                  menuItemClose_Click(null, new EventArgs());
                  OpenDataset(openFileDialog1.FileName);
               }
            }
         }
         catch
         {
            MessageBox.Show("Error loading image");
         }
      }

      public static void DisplayInvalidImageMessage(string errorMsg)
      {
         if (string.Compare("Improper Image.", errorMsg, true) == 0)
            errorMsg = "Note that this dataset contains an invalid image.";
         MessageBox.Show(errorMsg + "\n\nUnable to display the image data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

      }

      private void ShowImage( )
      {
         if (ds.InformationClass == DicomClassType.EncapsulatedPdfStorage)
         {
            try
            {
               DicomEncapsulatedDocument encapsulatedDocument = new DicomEncapsulatedDocument();
               DicomCodeSequenceItem conceptNameCodeSequence = new DicomCodeSequenceItem();

               //Get the Encapsulated Pdf file and store it in the Temp File
               ds.GetEncapsulatedDocument(null, false, TempOutPdf, encapsulatedDocument, conceptNameCodeSequence);

               //Get extra info about DicomEncapsulatedDocument and DicomCodeSequenceItem here...

               encapsulatedDocument.Dispose();
               conceptNameCodeSequence.Dispose();

               //View the stored Pdf file
               using(RasterCodecs codecs = new RasterCodecs())
               {
                  try
                  {
                     _viewer.Image = codecs.Load(TempOutPdf, 0, CodecsLoadByteOrder.Bgr, 1, -1);
                  }
                  catch
                  {
                     MessageBox.Show("Unable to load the Encapsulated Pdf file.");
                  }
               }
            }
            catch (Exception exception)
            {
               System.Diagnostics.Debug.Assert(false);
               throw exception;
            }
            finally
            {
               //delete the Temp Pdf file if exists
               if (System.IO.File.Exists(TempOutPdf))
                  System.IO.File.Delete(TempOutPdf);
            }
         }
         else
         {
            try
            {
               DicomElement element = null;
               element = ds.FindFirstElement(null, DemoDicomTags.PixelData, true);
               int bitmapCount = ds.GetImageCount(element);
               if (bitmapCount > 0)
               {
                  if (bitmapCount == 1)
                  {
                     if (element != null)
                     {
                        try
                        {
                           RasterImage image = ds.GetImage(element, 0, 0, RasterByteOrder.Gray, _getImageFlags);

                           _viewer.Image = image;
                        }
                        catch (Exception ex)
                        {
                           DisplayInvalidImageMessage(ex.Message);
                        }
                     }
                  }
                  else
                  {
                     if (element != null)
                     {
                        LoadBitmapList(element);
                     }
                  }

                  GetWindowLevelValues();
                  if (element != null)
                  {
                     imageInfo = ds.GetImageInformation(element, 0);
                  }

               }
               else
               {
                  MessageBox.Show("Note that this dataset does not include any images.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
            }

            catch (Exception exception)
            {
               System.Diagnostics.Debug.Assert(false);
               throw exception;
            }
         }
      }

      public enum DicomDemoFormat
      {
         Standard,
         Xml,
         Json
      };

      private void OpenDataset(string file)
      {
         OpenDataset(file, DicomDemoFormat.Standard);
      }

      private void OpenDataset(string file, DicomDemoFormat format)
      {
         FreeImage();

         Cursor = Cursors.WaitCursor;

         try
         {
            DicomElement element = null;

            if (format == DicomDemoFormat.Standard)
            {
               try
               {
                  ds.Load(file, DicomDataSetLoadFlags.None);
               }
               catch (Exception)
               {
                  string msg = string.Format("Failed to load '{0}'.  Make sure that this is a valid DICOM file.", file);
                  MessageBox.Show(msg);
                  return;
               }
            }
            else if (format == DicomDemoFormat.Xml)
            {
               try
               {
                  ds.LoadXml(file, DicomDataSetLoadXmlFlags.None);
               }
               catch (Exception)
               {
                  string msg = string.Format("Failed to load '{0}'.  Make sure that this is a valid DICOM XML file.", file);
                  MessageBox.Show(msg);
                  return;
               }
            }
            else
            {
               try
               {
                  ds.LoadJson(file, DicomDataSetLoadJsonFlags.None);
               }
               catch (Exception)
               {
                  string msg = string.Format("Failed to load '{0}'.  Make sure that this is a valid DICOM Json Model file.", file);
                  MessageBox.Show(msg);
                  return;
               }
            }
            if (ds.InformationClass == DicomClassType.BasicDirectory)
            {
               MessageBox.Show("This demo does not support opening Dicom Directory datasets.  " +
                   "Please see the Dicom Directory demo.");
               return;
            }

            bool bImage = false;
            try
            {
               ShowImage();
               bImage = (_viewer.Image != null);
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }

            menuItemDataset.Enabled = true;
            menuItemProcessing.Enabled = bImage;

            if (_viewer.Image != null)
            {
               if (ds.InformationClass == DicomClassType.EncapsulatedPdfStorage)
                  menuItemAnimation.Enabled = (_viewer.Image.PageCount > 1);
               else
                  menuItemAnimation.Enabled = ds.GetImageCount(element) > 1;
            }

            UpdateTree();
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
         finally
         {
            Cursor = Cursors.Arrow;
         }

         if (treeViewElements.Nodes.Count > 0)
         {
            treeViewElements.SelectedNode = treeViewElements.Nodes[0];
         }
      }

      private void LoadBitmapList(DicomElement element)
      {
         int count;
         bool getImagesSuccess = true;
         string errorMsg = string.Empty;

         count = ds.GetImageCount(element);
         for(int x = 0; (x < count) && (getImagesSuccess == true); x++)
         {
            RasterImage image = null;

            try
            {
               image = ds.GetImage(element, x, 0, RasterByteOrder.Rgb | RasterByteOrder.Gray, _getImageFlags);
            }
            catch (Exception ex)
            {
               getImagesSuccess = false;
               errorMsg = ex.Message;
            }


            if(image != null)
            {
               if(x == 0)
               {
                  _viewer.Image = image;
               }
               else
               {
                  _viewer.Image.AddPage(image);
               }
            }
         }

         if (getImagesSuccess == false)
         {
            DisplayInvalidImageMessage(errorMsg);
         }

         if(_viewer.Image != null && _viewer.Image.PageCount > 0)
         {
            _viewer.Image.Page = 1;
         }
      }

      private void FillTree( )
      {
         DicomElement element;

         element = ds.GetFirstElement(null, false, true);
         if(element == null)
         {
            string err = string.Format("Error reading dicom dataset!");

            MessageBox.Show(err, "Error");
            return;
         }

         FillSubTree(element, null);
      }

      void FillSubTree(DicomElement element, TreeNode ParentNode)
      {
         TreeNode node;
         string name;
         string temp = "";
         DicomTag tag;
         DicomElement tempElement;

         tag = DicomTagTable.Instance.Find(element.Tag);

         if(tag != null)
         {
            name = tag.Name;
         }
         else
            name = "Item";

         long tagValue = 0;

         tagValue = element.Tag;

         temp = string.Format("{0:x4}:{1:x4} - ", Utils.GetGroup(tagValue), Utils.GetElement(tagValue));
         temp = temp + name;

         if(ParentNode != null)
         {
            node = ParentNode.Nodes.Add(temp);
         }
         else
         {
            node = treeViewElements.Nodes.Add(temp);
         }

         node.Tag = element;

         if(ds.IsVolatileElement(element))
         {
            node.ForeColor = Color.Red;
         }

         node.ImageIndex = 1;
         node.SelectedImageIndex = 1;

         tempElement = ds.GetChildElement(element, true);
         if(tempElement != null)
         {
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            FillSubTree(tempElement, node);
         }


         tempElement = ds.GetNextElement(element, true, true);
         if(tempElement != null)
         {
            FillSubTree(tempElement, ParentNode);
         }
         else
         {
            element = ds.GetParentElement(element);
         }
      }

      private void FillTreeModules( )
      {
         for(int x = 0; x < ds.ModuleCount; x++)
         {
            TreeNode node;
            DicomModule module;
            DicomIod iod;

            module = ds.FindModuleByIndex(x);
            iod = DicomIodTable.Instance.FindModule(ds.InformationClass, module.Type);

            node = treeViewElements.Nodes.Add(iod.Name);
            node.Tag = module;
            foreach(DicomElement element in module.Elements)
            {
               FillModuleSubTree(element, node, false);
            }
         }
      }

      void FillModuleSubTree(DicomElement element, TreeNode ParentNode, bool recurse)
      {
         TreeNode node;
         string name;
         string temp = "";
         DicomElement tempElement;

         DicomTag tag;

         tag = DicomTagTable.Instance.Find(element.Tag);
         temp = string.Format("{0:x4}:{1:x4} - ", Utils.GetGroup((long)element.Tag), Utils.GetElement((long)element.Tag));

         if(tag == null)
            name = "Item";
         else
            name = tag.Name;

         temp = temp + name;

         if(ParentNode != null)
         {
            node = ParentNode.Nodes.Add(temp);
         }
         else
         {
            node = treeViewElements.Nodes.Add(temp);
         }

         node.Tag = element;

         if(ds.IsVolatileElement(element))
         {
            node.ForeColor = Color.Red;
         }

         node.ImageIndex = 1;
         node.SelectedImageIndex = 1;

         tempElement = ds.GetChildElement(element, true);
         if(tempElement != null)
         {
            node.ImageIndex = 0;
            node.SelectedImageIndex = 0;
            FillModuleSubTree(tempElement, node, true);
         }

         if(recurse)
         {
            tempElement = ds.GetNextElement(element, true, true);
            if(tempElement != null)
            {
               FillModuleSubTree(tempElement, ParentNode, true);
            }
         }
      }

      private void menuItemView_Popup(object sender, System.EventArgs e)
      {
         bool enable = false;
         if(_viewer.Image == null || (_viewer.Image.PageCount < 1))
         {
            enable = false;
         }
         else
         {
            enable = true;
         }

         menuItemNormal.Enabled = enable;
         menuItemNormal.Checked = ((_viewer.SizeMode == ControlSizeMode.ActualSize) && (_viewer.ScaleFactor == 1));

         menuItemFit.Enabled = enable;
         menuItemFit.Checked = _viewer.SizeMode == ControlSizeMode.Fit;

         menuItemZoomIn.Enabled = enable;
         menuItemZoomOut.Enabled = enable;
         menuItemAnimation.Enabled = enable;

         menuItemZoom2.Checked = _viewer.ScaleFactor == (2 * 100);
         menuItemZoom4.Checked = _viewer.ScaleFactor == (4 * 100);
         menuItemZoomHalf.Checked = _viewer.ScaleFactor == (100 / 2);
         menuItemZoomFourth.Checked = _viewer.ScaleFactor == (100 / 4);
      }

      private void menuItemNormal_Click(object sender, System.EventArgs e)
      {
         _viewer.Zoom(ControlSizeMode.ActualSize, 1, _viewer.DefaultZoomOrigin);
      }

      private void menuItemFit_Click(object sender, System.EventArgs e)
      {
         _viewer.Zoom(ControlSizeMode.Fit, 1, _viewer.DefaultZoomOrigin);
      }

      private void menuItemZoom2_Click(object sender, System.EventArgs e)
      {
         _viewer.Zoom(ControlSizeMode.None, _viewer.ScaleFactor * 2, _viewer.DefaultZoomOrigin);         
      }

      private void menuItemZoom4_Click(object sender, System.EventArgs e)
      {
         _viewer.Zoom(ControlSizeMode.None, _viewer.ScaleFactor * 4, _viewer.DefaultZoomOrigin);         
      }

      private void menuItemZoomHalf_Click(object sender, System.EventArgs e)
      {
         _viewer.Zoom(ControlSizeMode.None, _viewer.ScaleFactor * 0.5F, _viewer.DefaultZoomOrigin);         
      }

      private void menuItemZoomFourth_Click(object sender, System.EventArgs e)
      {
         _viewer.Zoom(ControlSizeMode.None, _viewer.ScaleFactor * 0.25F, _viewer.DefaultZoomOrigin);          
      }

      private void menuItemClose_Click(object sender, System.EventArgs e)
      {
         propertyGridElement.SelectedObject = null;
         treeViewElements.BeginUpdate();
         treeViewElements.Nodes.Clear();
         treeViewElements.EndUpdate();

         menuItemDataset.Enabled = false;
         menuItemProcessing.Enabled = false;
         menuItemAnimation.Enabled = false;
         ds.Reset();

         FreeImage();
      }

      private void menuItemFile_Popup(object sender, System.EventArgs e)
      {
         bool valid = IsDatasetValid();

         menuItemClose.Enabled = valid;
         menuItemSave.Enabled = valid;
         menuItemInfo.Enabled = valid;
         menuItemSaveXml.Enabled = valid;
         menuItemSaveNativeDicomModel.Enabled = valid;
         menuItemSaveDicomJsonModel.Enabled = valid;
      }

      private bool IsDatasetValid( )
      {
         DicomElement element;

         element = ds.FindFirstElement(null, DemoDicomTags.SOPClassUID, true);
         if(element == null)
         {
            return false;
         }
         return true;
      }

      private void menuItemInfo_Click(object sender, System.EventArgs e)
      {
         InfoDlg dlgInfo = new InfoDlg(ds);

         dlgInfo.ShowDialog();
      }

      private void menuItemNew_Click(object sender, System.EventArgs e)
      {
         NewDatasetDlg dlgNew = new NewDatasetDlg(ds);

         if(dlgNew.ShowDialog() == DialogResult.OK)
         {
            Cursor = Cursors.WaitCursor;

            menuItemClose_Click(null, null);
            try
            {
               ds.Initialize(dlgNew.Class, dlgNew.InitializeFlags);

               menuItemDataset.Enabled = true;
               menuItemProcessing.Enabled = true;

               UpdateTree();
               if(treeViewElements.Nodes.Count > 0)
               {
                  treeViewElements.SelectedNode = treeViewElements.Nodes[0];
               }
            }
            catch(DicomException de)
            {
               System.Diagnostics.Debug.Assert(false);

               throw de;
            }
            finally
            {
               Cursor = Cursors.Arrow;
            }
         }
      }

      private void menuItemProcessing_Popup(object sender, System.EventArgs e)
      {
         bool valid = false;
         try
         {
            if (_viewer.Image != null)
               valid = (_viewer.Image.PageCount > 0);
         }
         catch
         {
            valid = false;
         }
         menuItemGrayscale8.Enabled = valid;
         menuItemGrayscale12.Enabled = valid;
         menuItemGrayscale16.Enabled = valid;
         menuItemInvert.Enabled = valid;
         menuItemBrightness.Enabled = valid;
         menuItemContrast.Enabled = valid;
         menuItemFlip.Enabled = valid;
         menuItemReverse.Enabled = valid;
         menuItemRotate.Enabled = valid;
         menuItemUpdate.Enabled = valid;
         menuItemUnsharpMask.Enabled = valid;
      }

      private void menuItemGrayscale8_Click(object sender, System.EventArgs e)
      {
         GrayscaleCommand command = new GrayscaleCommand();

         command.BitsPerPixel = 8;
         command.Run(_viewer.Image);
      }

      private void menuItemGrayscale12_Click(object sender, System.EventArgs e)
      {
         GrayscaleCommand command = new GrayscaleCommand();

         command.BitsPerPixel = 12;
         command.Run(_viewer.Image);
      }

      private void menuItemGrayscale16_Click(object sender, System.EventArgs e)
      {
         GrayscaleCommand command = new GrayscaleCommand();

         command.BitsPerPixel = 16;
         command.Run(_viewer.Image);
      }

      private void menuItemInvert_Click(object sender, System.EventArgs e)
      {
         InvertCommand command = new InvertCommand();

         command.Run(_viewer.Image);
      }

      private void menuItemBrightness_Click(object sender, System.EventArgs e)
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Intensity);

         if(dlg.ShowDialog(this) == DialogResult.OK)
         {

            ChangeIntensityCommand command = new ChangeIntensityCommand(dlg.Value);

            command.Run(_viewer.Image);
            //GetWindowLevelValues();
         }
      }

      private void menuItemContrast_Click(object sender, System.EventArgs e)
      {
         ValueDialog dlg = new ValueDialog(ValueDialog.TypeConstants.Contrast);

         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            ChangeContrastCommand command = new ChangeContrastCommand(dlg.Value);

            command.Run(_viewer.Image);
         }
      }

      private void menuItemFlip_Click(object sender, System.EventArgs e)
      {
         FlipCommand command = new FlipCommand();

         command.Horizontal = false;
         command.Run(_viewer.Image);

      }

      private void menuItemReverse_Click(object sender, System.EventArgs e)
      {
         FlipCommand command = new FlipCommand();

         command.Horizontal = true;
         command.Run(_viewer.Image);
      }

      private void menuItemRotate_Click(object sender, System.EventArgs e)
      {
         RotateCommand command;
         RotateDialog dlg = new RotateDialog();

         if(dlg.ShowDialog(this) == DialogResult.OK)
         {
            command = new RotateCommand(dlg.Angle, dlg.Flags, dlg.FillColor);
            command.Run(_viewer.Image);
         }
      }

      private void UpdateTree( )
      {
         try
         {
            treeViewElements.BeginUpdate();
            treeViewElements.Nodes.Clear();
            if (listView)
                FillTree();
            else
               FillTreeModules();
            treeViewElements.EndUpdate();
         }
         catch
         {
         }
      }
      private void menuItemUpdate_Click(object sender, System.EventArgs e)
      {
         DicomElement imgElement = ds.FindFirstElement(null, DemoDicomTags.PixelData, true);
         ImageOptionsDlg dlgOptions = new ImageOptionsDlg(ds, imgElement);

         if(dlgOptions.ShowDialog() == DialogResult.OK)
         {
            try
            {
               RasterImage image = _viewer.Image;

               Cursor = Cursors.WaitCursor;
               try
               {
                  treeViewElements.BeginUpdate();
                  treeViewElements.Nodes.Clear();
                  treeViewElements.EndUpdate();

                  if(dlgOptions.Compression != DicomImageCompressionType.None)
                  {
                     try
                     {
                        ds.ChangeTransferSyntax(DicomUidType.ExplicitVRLittleEndian, dlgOptions.QFactor, ChangeTransferSyntaxFlags.None);
                        imgElement = ds.FindFirstElement(null, DemoDicomTags.PixelData, true);
                     }
                     catch(DicomException de)
                     {
                        string err = string.Format("Error changing transfer syntax!\r\n\r\n{0}", de.Code.ToString());

                        MessageBox.Show(err, "Error");

                        Cursor = Cursors.Arrow;
                        UpdateTree();
                        return;
                     }
                  }

                  if(dlgOptions.UseNewImageFile && dlgOptions.NewImage != null)
                  {
                     image = dlgOptions.NewImage.Clone();
                     GetWindowLevelValues();
                  }

                  if(dlgOptions.NewImage != null)
                  {
                     dlgOptions.NewImage.Dispose();
                  }

                  if((_viewer.Image != null) && (_viewer.Image.PageCount == 1) && image != null)
                  {
                     ds.SetImage(imgElement, image, dlgOptions.Compression,
                        dlgOptions.PhotoMetric,
                        dlgOptions.BitsPerPixel,
                        dlgOptions.QFactor,
                        DicomSetImageFlags.AutoSetVoiLut);
                  }
                  else if(image != null)
                  {
                     ds.SetImages(imgElement, image, dlgOptions.Compression,
                        dlgOptions.PhotoMetric,
                        dlgOptions.BitsPerPixel,
                        dlgOptions.QFactor,
                        DicomSetImageFlags.AutoSetVoiLut);
                  }
                  ShowImage();
                  UpdateTree();
                  imageInfo = ds.GetImageInformation(imgElement, 0);
               }
               catch
               {
                  UpdateTree();
               }
               finally
               {
                  Cursor = Cursors.Arrow;
               }

            }
            catch(Exception Ex)
            {
               MessageBox.Show(Ex.Message, "Error");
            }
         }
      }

      private void PushMenuItemsState( )
      {
         try
         {
            _fileMenuEnabled = menuItemFile.Enabled;
            _viewMenuEnabled = menuItemView.Enabled;
            _tablesMenuEnabled = menuItemTables.Enabled;
            _datasetMenuEnabled = menuItemDataset.Enabled;
            _animationMenuEnabled = menuItemAnimation.Enabled;
            _processingMenuEnabled = menuItemProcessing.Enabled;
         }
         catch
         {

         }

      }

      private void PopMenuItemsState( )
      {
         try
         {
            menuItemFile.Enabled = _fileMenuEnabled;
            menuItemView.Enabled = _viewMenuEnabled;
            menuItemTables.Enabled = _tablesMenuEnabled;
            menuItemDataset.Enabled = _datasetMenuEnabled;
            menuItemAnimation.Enabled = _animationMenuEnabled;
            menuItemProcessing.Enabled = _processingMenuEnabled;
         }
         catch
         {

         }
      }

      private void DisableMenuItems( )
      {
         try
         {
            menuItemFile.Enabled = false;
            menuItemView.Enabled = false;
            menuItemTables.Enabled = false;
            menuItemDataset.Enabled = false;
            menuItemAnimation.Enabled = false;
            menuItemProcessing.Enabled = false;
         }
         catch
         {
         }
      }


      private void menuItemPlay_Click(object sender, System.EventArgs e)
      {
         int count;
         Cursor = Cursors.WaitCursor;
         PushMenuItemsState();

         try
         {
            DisableMenuItems();
            _viewer.Zoom(ControlSizeMode.ActualSize, _viewer.ScaleFactor, _viewer.DefaultZoomOrigin);
            count = _viewer.Image.PageCount;
            for(int x = 1; x <= count; x++)
            {
               if((_viewer != null) && (_viewer.Image != null))
               {
                  _viewer.Image.Page = x;
                  _viewer.Refresh();
               }
               System.Threading.Thread.Sleep(20);
               Application.DoEvents();
            }
         }

         finally
         {
            PopMenuItemsState();
            Cursor = Cursors.Arrow;
            if((_viewer != null) && (_viewer.Image != null))
               _viewer.Image.Page = 1;
         }
      }

      private void menuItemAnimation_Popup(object sender, System.EventArgs e)
      {
         if(menuItemAnimation.Enabled)
         {
            menuItemFirst.Enabled = _viewer.Image.Page != 1;
            menuItemNext.Enabled = _viewer.Image.Page != (_viewer.Image.PageCount);
            menuItemPrevious.Enabled = _viewer.Image.Page != 1;
            menuItemLast.Enabled = _viewer.Image.Page != (_viewer.Image.PageCount);
         }
      }

      private void menuItemFirst_Click(object sender, System.EventArgs e)
      {
         _viewer.Image.Page = 1;
      }

      private void menuItemNext_Click(object sender, System.EventArgs e)
      {
         _viewer.Image.Page = (_viewer.Image.Page + 1);
      }

      private void menuItemPrevious_Click(object sender, System.EventArgs e)
      {
         _viewer.Image.Page = (_viewer.Image.Page - 1);
      }

      private void menuItemLast_Click(object sender, System.EventArgs e)
      {
         _viewer.Image.Page = _viewer.Image.PageCount;
      }

      private void treeViewElements_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
      {
         try
         {
            textBoxValues.Text = "";

            if(treeViewElements.SelectedNode != null && treeViewElements.SelectedNode.Tag != null)
            {
               TreeNode node = treeViewElements.SelectedNode;

               if(node.Tag.GetType() == typeof(DicomElement))
               {
                  SelectElement(node.Tag as DicomElement);
               }
               else
               {
                  propertyGridElement.SelectedObject = null;
               }
            }
         }
         catch
         {
         }
      }

      private void SelectElement(DicomElement element)
      {
         if(!IsImageElement(element))
         {
            GetElementValues(element);
         }
         else
         {
            if(treeViewElements.SelectedNode.Parent == null)
            {
               if(_viewer.Image.PageCount != 1)
                  _viewer.Image.Page = 1;
            }
            else
            {
               TreeNode parent;

               parent = treeViewElements.SelectedNode.Parent;
               imgIndex = parent.Nodes.IndexOf(treeViewElements.SelectedNode) + 1;
               if(imgIndex > _viewer.Image.PageCount)
               {
                  imgIndex = _viewer.Image.PageCount;
               }
               _viewer.Image.Page = (short)imgIndex;
            }
         }
         propertyGridElement.SelectedObject = element;
      }

      private bool IsImageElement(DicomElement element)
      {
         if(element != null)
         {
            DicomTag tag;

            tag = DicomTagTable.Instance.Find(element.Tag);

            //
            // Pixel Data tags will not be display in our list box instead we will load
            //  them in the image viewer
            //
            if(tag != null && tag.Name.IndexOf("Pixel Data") == -1)
            {
               element = ds.GetParentElement(element);
               if(element != null)
               {
                  tag = DicomTagTable.Instance.Find(element.Tag);

                  if(tag != null && tag.Name.IndexOf("Pixel Data") != -1)
                  {
                     return true;
                  }
               }
            }
            else
            {
               return false;
            }
         }
         return false;
      }

      private void GetElementValues(DicomElement element)
      {
         string value = "";
         if (element.Length > 0xfff)
         {
            byte[] b = ds.GetBinaryValue(element, 0xfff);
            if (b != null)
            {
               value = BitConverter.ToString(b);
               value = value.Replace("-", " ");
            }
         }
         else
         {
            value = ds.GetConvertValue(element);
            if (value != null && value.Length > 0)
            {
               value = value.Replace(@"\", "\r\n");
            }
         }
         textBoxValues.Text = value;
      }

      private DicomTag FindTag(long Tag)
      {
         DicomTag tag = null;

         tag = DicomTagTable.Instance.Find(Tag);
         return tag;
      }

      private void menuItemSave_Click(object sender, System.EventArgs e)
      {
         saveFileDialog1.Filter = "DCM File(*.dcm)|*.dcm|All files (*.*)|*.*";
         saveFileDialog1.AddExtension = true;
         saveFileDialog1.Title = "Save Dicom File";
         if(saveFileDialog1.ShowDialog() == DialogResult.OK)
         {
            try
            {
               ds.Save(saveFileDialog1.FileName, DicomDataSetSaveFlags.None);
            }
            catch(DicomException de)
            {
               string err = string.Format("Error saving dicom dataset!\r\n\r\n{0}", de.Code.ToString());

               MessageBox.Show(err, "Error");
               return;
            }
         }
      }

      private DicomCharacterSetType ReadCharacterSet()
      {
         // If we do not find one of the character sets below, use the default
         DicomCharacterSetType characterSet = DicomCharacterSetType.Default;
         DicomElement element = ds.FindFirstElement(null, DemoDicomTags.SpecificCharacterSet, false);
         if (element != null)
         {
            string sValue = ds.GetStringValue(element, 0);
            if (sValue != null)
            {
               if (sValue.Trim().Contains("ISO_IR 6"))
                  characterSet = DicomCharacterSetType.Default;
               else if (sValue.Trim().Contains("ISO_IR 100"))
                  characterSet = DicomCharacterSetType.LatinAlphabetNo1;
               else if (sValue.Trim().Contains("ISO_IR 101"))
                  characterSet = DicomCharacterSetType.LatinAlphabetNo2;
               else if (sValue.Trim().Contains("ISO_IR 109"))
                  characterSet = DicomCharacterSetType.LatinAlphabetNo3;
               else if (sValue.Trim().Contains("ISO_IR 110"))
                  characterSet = DicomCharacterSetType.LatinAlphabetNo4;
               else if (sValue.Trim().Contains("ISO_IR 144"))
                  characterSet = DicomCharacterSetType.Cyrillic;
               else if (sValue.Trim().Contains("ISO_IR 127"))
                  characterSet = DicomCharacterSetType.Arabic;
               else if (sValue.Trim().Contains("ISO_IR 126"))
                  characterSet = DicomCharacterSetType.Greek;
               else if (sValue.Trim().Contains("ISO_IR 138"))
                  characterSet = DicomCharacterSetType.Hebrew;
               else if (sValue.Trim().Contains("ISO_IR 148"))
                  characterSet = DicomCharacterSetType.LatinAlphabetNo5;
               else if (sValue.Trim().Contains("ISO_IR 13"))
                  characterSet = DicomCharacterSetType.JapaneseJisX0201;
               else if (sValue.Trim().Contains("ISO_IR 166"))
                  characterSet = DicomCharacterSetType.Thai;
               else if (sValue.Trim().Contains("ISO_IR 149"))
                  characterSet = DicomCharacterSetType.Korean;
               else if (sValue.Trim().Contains("ISO_IR 192"))
                  characterSet = DicomCharacterSetType.UnicodeInUtf8;
               else if (sValue.Trim().Contains("GB18030"))
                  characterSet = DicomCharacterSetType.Gb18030;
            }
         }
         return characterSet;
      }

      private void menuItemEdit_Click(object sender, System.EventArgs e)
      {
         DicomElement element = treeViewElements.SelectedNode.Tag as DicomElement;
         EditValueDlg dlgEdit = new EditValueDlg(ds, element);

         if(!IsImageElement(element))
         {
            if(dlgEdit.ShowDialog() == DialogResult.OK)
            {
               int count;

               count = dlgEdit.listBoxValues.Items.Count;
               if(count > 0)
               {
                  string values = "";

                  foreach(string item in dlgEdit.listBoxValues.Items)
                  {
                     if(values.Length > 0)
                        values += @"\";

                     values += item;
                  }
                  ds.FreeElementValue(element);

                  bool ret = false;
                  switch (element.VR)
                  {
                     case DicomVRType.SH:
                     case DicomVRType.LO:
                     case DicomVRType.ST:
                     case DicomVRType.PN:
                     case DicomVRType.LT:
                     case DicomVRType.UT:
                        {
                           // could be another code page (i.e. arabic)
                           // Call SetStringValue instead and set the 'Specific Character Set (0008,0005)'
                           DicomCharacterSetType characterSet = ReadCharacterSet();
                           ret = ds.SetStringValue(element, values, characterSet);

                           // If default fails, try adding as UTF-8
                           if (ret == false)
                              ret = ds.SetStringValue(element, values, DicomCharacterSetType.UnicodeInUtf8);
                        }
                        break;
                     default:
                        ret = ds.SetConvertValue(element, values, count);
                        break;
                  }
               }
               else
               {
                  ds.FreeElementValue(element);
               }

               treeViewElements_AfterSelect(null, null);
            }
         }
         else
         {
            menuItemUpdate_Click(null, null);
         }
      }

      private bool IsControlPressed( )
      {
         bool pressed;

         pressed = (((ushort)GetKeyState(VK_CONTROL)) & 0x8000) != 0;
         return pressed;
      }


      private void menuItemDataset_Popup(object sender, System.EventArgs e)
      {
         if(treeViewElements.SelectedNode == null || treeViewElements.SelectedNode.Tag.GetType() != typeof(DicomElement))
         {
            menuItemEdit.Enabled = false;
            menuItemElementDelete.Enabled = false;
         }
         else
         {
            DicomElement element = treeViewElements.SelectedNode.Tag as DicomElement;

            bool enable = !ds.IsVolatileElement(element) ||
                          (ds.IsVolatileElement(element) && IsControlPressed());

            menuItemEdit.Enabled = enable;
            menuItemElementDelete.Enabled = enable;
         }
         menuItemListView.Checked = listView;
         menuItemModuleView.Checked = !listView;

         menuItemModuleView.Enabled = IsIodTableLoaded();
      }

      private void menuItemElementDelete_Click(object sender, System.EventArgs e)
      {
         DicomElement element = treeViewElements.SelectedNode.Tag as DicomElement;

         try
         {
            ds.DeleteElement(element);
            if (element.Tag == DemoDicomTags.PixelData)
            {
               FreeImage();
               menuItemAnimation.Enabled = false;
            }
            treeViewElements.SelectedNode.Remove();
         }
         catch(DicomException de)
         {
            string err = string.Format("Error deleting element!\r\n\r\n{0}", de.Code.ToString());

            MessageBox.Show(err, "Error");
         }
      }

      private void menuItemElementInsert_Click(object sender, System.EventArgs e)
      {
         Cursor = Cursors.WaitCursor;

         try
         {
            if(treeViewElements.SelectedNode == null)
            {
               MessageBox.Show("No element selected, please start by selecting an element from the tree and try again.");
               return;
            }
            DicomElement element = treeViewElements.SelectedNode.Tag as DicomElement;
            if (element == null)
            {
               MessageBox.Show("No element selected, please start by selecting an element from the tree and try again.");
               return;
            }

            InsertElementDlg dlgInsert = new InsertElementDlg(ds, element);

            if(dlgInsert.ShowDialog() == DialogResult.OK)
            {
               try
               {
                  string temp;
                  DicomElement newElement;
                  TreeNode node = new TreeNode();

                  newElement = ds.InsertElement(element, dlgInsert.Child,
                                                dlgInsert.Tag.Code,
                                                DicomVRType.UN,
                                                dlgInsert.Sequence, -1);

                  temp = string.Format("{0:x4}:{1:x4} - ", Utils.GetGroup((long)dlgInsert.Tag.Code), Utils.GetElement((long)dlgInsert.Tag.Code));
                  temp = temp + dlgInsert.Tag.Name;

                  node.Text = temp;
                  node.Tag = newElement;
                  node.ImageIndex = dlgInsert.Sequence ? 0 : 1;
                  node.SelectedImageIndex = dlgInsert.Sequence ? 0 : 1;
                  if(ds.IsVolatileElement(newElement))
                     node.ForeColor = Color.Red;

                  if(dlgInsert.Child)
                  {
                     treeViewElements.SelectedNode.Nodes.Add(node);
                     treeViewElements.SelectedNode.ImageIndex = 0;
                     treeViewElements.SelectedNode.SelectedImageIndex = 0;
                  }
                  else
                     treeViewElements.Nodes.Insert(treeViewElements.SelectedNode.Index + 1, node);
                  treeViewElements.SelectedNode = node;
               }
               catch(DicomException de)
               {
                  string err = string.Format("Error inserting element. Element might already exist in the dataset!\r\n\r\nReturn Code: {0}", de.Code.ToString());


                  MessageBox.Show(err, "Error");
                  return;
               }
            }
         }
         catch(Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
         finally
         {
            Cursor = Cursors.Arrow;
         }
      }

      private void _viewer_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if (_viewer.Image != null)
         {
            if (e.Button.IsFlagged(MouseButtons.Left))
            {
               string tipMessage = GetPixelInformation(e.X, e.Y);
               _toolTip.Show(tipMessage, _viewer, e.X + 25, e.Y + 25);
            }

            if (e.Button.IsFlagged(MouseButtons.Right))
            {
               wl.ReverseOrder = (_viewer.Image.GrayscaleMode == RasterGrayscaleMode.OrderedInverse) || (isMonochrome1);
               wl.Start(_viewer.Image, e.Location);
            }
         }
      }

      private void _viewer_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if(wl.WindowLeveling)
         {
            wl.Stop(e.Location);
         }

         _toolTip.Hide(_viewer);
      }

      private void _viewer_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if (e.Button.IsFlagged(MouseButtons.Left))
         {
            string tipMessage = GetPixelInformation(e.X, e.Y);
            _toolTip.Show(tipMessage, _viewer, e.X + 25, e.Y + 25);
         }
         if (e.Button.IsFlagged(MouseButtons.Right))
         {
            if (wl.WindowLeveling)
            {
               wl.Process(new Point(e.X, e.Y));
               _viewer.Update();
            }
         }
      }

      bool IsBitSet(byte b, int pos)
      {
         return (b & (1 << pos)) != 0;
      }

      bool IsBitSet(byte[] ba, int highBit)
      {
         int byteArrayIndex = highBit / 8;
         if (ba.Length >=  (byteArrayIndex+1))
         {
            int newBitToCheck = highBit % 8;
            return IsBitSet(ba[byteArrayIndex], newBitToCheck);
         }
         return false;
      }

      string GetHexPixelValue(byte[] bytes)
      {
         string hexPixelValue = string.Empty;
         switch (bytes.Length)
         {
            case 1:
               {
                  hexPixelValue = string.Format("0x{0:X2}", bytes[0]);
               }
               break;

            case 2:
               {
                  hexPixelValue = string.Format("0x{0:X4}", bytes[0] | ((int)bytes[1] << 8));
               }
               break;

            case 3:
               {
                  hexPixelValue = string.Format("0x{0:X6}", bytes[0] | ((int)bytes[1] << 8) | ((int)bytes[2] << 16));
               }
               break;

            case 4:
               {
                  hexPixelValue = string.Format("0x{0:X8}", bytes[0] | ((int)bytes[1] << 8) | ((int)bytes[2] << 16) | ((int)bytes[3] << 24));
               }
               break;
         }
         return hexPixelValue;
      }

      string GetPixelValue(byte[] bytes, int highBit, bool signed)
      {
         string pixelValue = string.Empty;


         if (signed && IsBitSet(bytes, highBit))
         {
            uint mask = 0xFFFFFFFF;
            mask = (mask << (highBit));

            if (bytes.Length >= 1)
               bytes[0] |= (byte)(mask & 0xFF);

            if (bytes.Length >= 2)
               bytes[1] |= (byte)((mask & 0xFF00) >> 8);

            if (bytes.Length >= 3)
               bytes[2] |= (byte)((mask & 0xFF0000) >> 16);

            if (bytes.Length >= 4)
               bytes[3] |= (byte)((mask & 0xFF000000) >> 24);
         }

         switch (bytes.Length)
         {
            case 1:
               {
                  byte[] bytesCopy2 = { bytes[0], 0 };
                  pixelValue = (_viewer.Image.Signed) ? BitConverter.ToInt16(bytes, 0).ToString() : BitConverter.ToUInt16(bytesCopy2, 0).ToString();
               }
               break;

            case 2:
               {
                  pixelValue = (_viewer.Image.Signed) ? BitConverter.ToInt16(bytes, 0).ToString() : BitConverter.ToUInt16(bytes, 0).ToString();
               }
               break;

            case 3:
               {
                  byte[] bytesCopy4 = { bytes[0], bytes[1], bytes[2], 0 };
                  pixelValue = (_viewer.Image.Signed) ? BitConverter.ToInt32(bytesCopy4, 0).ToString() : BitConverter.ToUInt32(bytesCopy4, 0).ToString();
               }
               break;

            case 4:
               {
                  pixelValue = (_viewer.Image.Signed) ? BitConverter.ToInt32(bytes, 0).ToString() : BitConverter.ToUInt32(bytes, 0).ToString();
               }
               break;
         }
         return pixelValue;
      }


      string GetPixelInformation(int xOld, int yOld)
      {
         LeadPoint leadPoint = new LeadPoint(xOld, yOld);

         // from mouse to where it is in the image, taking care of scroll/zoom/DPI
         LeadPoint convertedLeadTemp = _viewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, leadPoint);

         LeadPoint leadPointFinal = _viewer.Image.PointToImage(RasterViewPerspective.TopLeft, convertedLeadTemp);

         int xNew = leadPointFinal.X;
         int yNew = leadPointFinal.Y;

         string hexPixelValue = string.Empty;
         string pixelValue = string.Empty;
         string rgbColor = string.Empty;
         string paletteOrLookupTable = string.Empty;

         if (xNew < _viewer.Image.Width && yNew < _viewer.Image.Height && xNew >= 0 && yNew >= 0 && /*_viewer.Image.GrayscaleMode != RasterGrayscaleMode.None  &&*/ _viewer.Image.BitsPerPixel != 1)
         {
            _viewer.Image.Access();
            byte[] bytes = _viewer.Image.GetPixelData(yNew, xNew);

            hexPixelValue = GetHexPixelValue(bytes);
            pixelValue = GetPixelValue(bytes, _viewer.Image.HighBit, _viewer.Image.Signed);

            RasterColor pixelColor = _viewer.Image.GetPixelColor(yNew, xNew);

            if (pixelColor.Reserved == 0x04)
            {
               paletteOrLookupTable = "Lookup Table (Palette)";
            }
            else if (pixelColor.Reserved == 0x01)
            {
               // 8 bit index
               paletteOrLookupTable = "Palette";
            }
            pixelColor = _viewer.Image.GetTrueColorValue(pixelColor);

            rgbColor = string.Format("({0},{1},{2})", pixelColor.R, pixelColor.G, pixelColor.B);

            _viewer.Image.Release();
         }

         int highBit = _viewer.Image.HighBit;
         string imageInfo = string.Format("Bits Per Pixel = {0},  Bits Used = {1}, High Bit = {2}", _viewer.Image.BitsPerPixel, highBit + 1, highBit);
         string msg = string.Format("X = {1} , Y = {2}{0}Pixel Value (hex) = {3}{0}Pixel Value (dec) = {4}{0}RGB = {5}{0}{6}{0}{7}",  
            Environment.NewLine, 
            xNew, 
            yNew, 
            hexPixelValue,
            pixelValue,
            rgbColor,
            _viewer.Image.Signed ? "Signed" : "Unsigned",
            imageInfo);

         if (!string.IsNullOrEmpty(paletteOrLookupTable))
         {
            msg = msg + Environment.NewLine + paletteOrLookupTable;
         }

         return msg;
      }

      private void ShowListView()
      {
         if (listView)
            return;

         WaitCursor wc = new WaitCursor();

         treeViewElements.BeginUpdate();
         treeViewElements.Nodes.Clear();
         tabPage1.Text = "List View";
         FillTree();
         listView = true;
         if (treeViewElements.Nodes.Count > 0)
            treeViewElements.SelectedNode = treeViewElements.Nodes[0];

         treeViewElements.EndUpdate();
      }

      private void menuItemListView_Click(object sender, EventArgs e)
      {
         ShowListView();
      }

      private void menuItemModuleView_Click(object sender, EventArgs e)
      {
         if(!listView)
            return;

         WaitCursor wc = new WaitCursor();

         treeViewElements.BeginUpdate();
         treeViewElements.Nodes.Clear();
         tabPage1.Text = "Module View";
            FillTreeModules();
         listView = false;
         if(treeViewElements.Nodes.Count > 0)
            treeViewElements.SelectedNode = treeViewElements.Nodes[0];
         treeViewElements.EndUpdate();
      }

      private void menuItemUnsharpMask_Click(object sender, EventArgs e)
      {
         UnsharpMaskDialog dlg = new UnsharpMaskDialog();
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            UnsharpMaskCommand command = new UnsharpMaskCommand(dlg.Amount, dlg.Radius, dlg.Threshold, dlg.ColorSpace);
            command.Run(_viewer.Image);
         }
      }

      private void LoadXml()
      {
         this.openFileDialog1.Filter = "DICOM XML Files (*.xml)|*.xml|All files (*.*)|*.*";
         this.openFileDialog1.Multiselect = true;
         this.openFileDialog1.Title = "Open DICOM XML File";

         if (openFileDialog1.ShowDialog() == DialogResult.OK)
         {
            menuItemClose_Click(null, new EventArgs());
            OpenDataset(openFileDialog1.FileName, DicomDemoFormat.Xml);
         }
      }

      private void LoadJson()
      {
         this.openFileDialog1.Filter = "DICOM Json Model Files (*.json)|*.json|All files (*.*)|*.*";
         this.openFileDialog1.Multiselect = true;
         this.openFileDialog1.Title = "Open DICOM Json Model File";

         if (openFileDialog1.ShowDialog() == DialogResult.OK)
         {
            menuItemClose_Click(null, new EventArgs());
            OpenDataset(openFileDialog1.FileName, DicomDemoFormat.Json);
         }
      }

      private void menuItemLoadXml_Click(object sender, EventArgs e)
      {
         LoadXml();
      }

      private void menuItemLoadJson_Click(object sender, EventArgs e)
      {
         LoadJson();
      }

      private void menuItemSaveXml_Click(object sender, EventArgs e)
      {
         saveFileDialog1.Filter = "XML File(*.xml)|*.xml|All files (*.*)|*.*";
         saveFileDialog1.AddExtension = true;
         saveFileDialog1.Title = "Save Dicom XML File";
         if(saveFileDialog1.ShowDialog() == DialogResult.OK)
         {
            try
            {
               ds.SaveXml(saveFileDialog1.FileName, DicomDataSetSaveXmlFlags.None);
            }
            catch(DicomException de)
            {
               string err = string.Format("Error saving dicom dataset!\r\n\r\n{0}", de.Code.ToString());

               MessageBox.Show(err, "Error");
               return;
            }
         }
      }


      private void menuItemModifyTables_Click(object sender, EventArgs e)
      {
         ModifyTablesDlg dlg = new ModifyTablesDlg();
         dlg.ShowDialog();

         if (false == IsIodTableLoaded())
         {
            ShowListView();
         }
      }

      private void MainForm_DragEnter(object sender, DragEventArgs e)
      {
         if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
         {
            e.Effect = DragDropEffects.All;
         }
      }

      private void MainForm_DragDrop(object sender, DragEventArgs e)
      {
         string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
         if (files.Length > 0)
         {
            try
            {
               DicomDemoFormat format = DicomDemoFormat.Standard;
               if (files[0].EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                  format = DicomDemoFormat.Xml;
               OpenDataset(files[0], format);
            }
            catch
            {
               MessageBox.Show("Error loading image");
            }

         }
      }

#if LEADTOOLS_V19_OR_LATER
      private DicomDataSetSaveXmlFlags _saveXmlFlags = 
               DicomDataSetSaveXmlFlags.NativeDicomModel | 
               DicomDataSetSaveXmlFlags.BulkDataUuid | 
               DicomDataSetSaveXmlFlags.TrimWhiteSpace;

      private DicomDataSetSaveJsonFlags _saveJsonFlags = DicomDataSetSaveJsonFlags.BulkDataUri | DicomDataSetSaveJsonFlags.TrimWhiteSpace;

      private void menuItemSaveNativeDicomOptions_Click(object sender, EventArgs e)
      {
         SaveDlg saveDlg = new SaveDlg(SaveOptionsEnum.NativeDicomModel);
         saveDlg.SetXmlFlags(_saveXmlFlags);
         saveDlg.DicomDS = ds;
         if (saveDlg.ShowDialog() == DialogResult.OK)
         {
            _saveXmlFlags = saveDlg.GetXmlFlags();
         }
      }

      private void menuItemSaveJsonOptions_Click(object sender, EventArgs e)
      {
         SaveDlg saveDlg = new SaveDlg(SaveOptionsEnum.JsonModel);
         saveDlg.SetJsonFlags(_saveJsonFlags);
         saveDlg.DicomDS = ds;
         if (saveDlg.ShowDialog() == DialogResult.OK)
         {
            _saveJsonFlags = saveDlg.GetJsonFlags();
         }
      }

      private void menuItemSaveNativeDicom_Click(object sender, EventArgs e)
      {
         SaveDlg.SaveXmlFile(ds, _saveXmlFlags);
      }

      private void menuItemSaveJson_Click(object sender, EventArgs e)
      {
         SaveDlg.SaveJsonFile(ds, _saveJsonFlags);
      }

      private void menuItemViewHistogram_Click(object sender, EventArgs e)
      {
         bool isGrayscale = false;
         if (_viewer.Image.GrayscaleMode != RasterGrayscaleMode.None)
            isGrayscale = true;

         HistogramDlg dlg = new HistogramDlg(_viewer.Image, isGrayscale);
         dlg.ShowDialog();
      }

      private void menuItemOptionsLoad_Click(object sender, EventArgs e)
      {
         LoadOptionsDlg dlg = new LoadOptionsDlg();
         dlg.GetImageFlags = _getImageFlags;

         dlg.Viewer = _viewer;
         dlg.ds = ds;

         dlg.ShowDialog();

         _getImageFlags = dlg.GetImageFlags;
         ShowImage();
      }


#endif // 

   }
}

#if !FOR_DOTNET4
// Extension methods support
namespace System.Runtime.CompilerServices
{
   internal class ExtensionAttribute : Attribute { }
}
#endif
