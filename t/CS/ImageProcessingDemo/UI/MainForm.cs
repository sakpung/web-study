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
using System.Text;

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Color;
using Leadtools.ImageProcessing.SpecialEffects;
using Leadtools.Codecs;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing.Effects;
using Leadtools.WinForms.CommonDialogs.Color;
using Leadtools.Drawing;
using Leadtools.Controls;
using System.Drawing.Drawing2D;

#if !LEADTOOLS_V20_OR_LATER
using VignetteCommand = Leadtools.ImageProcessing.SpecialEffects.VignnetCommand;
using VignetteCommandFlags = Leadtools.ImageProcessing.SpecialEffects.VignnetCommandFlags;
#endif

namespace ImageProcessingDemo
{
   public enum MouseButton
   {
      None = 0,
      Rigth = 1,
      Left = 2,
   }

   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mainMenu;
      private System.Windows.Forms.MenuItem _menuItemFile;
      private System.Windows.Forms.MenuItem _menuItemFileExit;
      private System.Windows.Forms.MenuItem _menuItemHelp;
      private System.Windows.Forms.MenuItem _menuItemHelpAbout;
      private System.Windows.Forms.ProgressBar _progressBar;
      private System.Windows.Forms.Button _buttonCancel;
      private System.Windows.Forms.Panel _panelControls;
      private System.Windows.Forms.Panel _panelBefore;
      private System.Windows.Forms.Panel _panelAfter;
      private System.Windows.Forms.CheckBox _checkBoxProgress;
      private System.Windows.Forms.CheckBox _checkBoxUseRegion;
      private System.Windows.Forms.Panel _panelProgress;
      private System.Windows.Forms.ListBox _listBoxCommands;
      private System.Windows.Forms.Button _buttonRun;
      private System.Windows.Forms.Button _buttonPrevious;
      private System.Windows.Forms.Button _buttonNext;
      private System.Windows.Forms.Panel _panelBeforeControls;
      private System.Windows.Forms.Label _labelBefore;
      private System.Windows.Forms.Button _buttonBeforePageLast;
      private System.Windows.Forms.Button _buttonBeforePageNext;
      private System.Windows.Forms.Label _labelBeforePage;
      private System.Windows.Forms.Button _buttonBeforePagePrevious;
      private System.Windows.Forms.Button _buttonBeforePageFirst;
      private System.Windows.Forms.Panel _panelAfterControls;
      private System.Windows.Forms.Button _buttonAfterPageLast;
      private System.Windows.Forms.Button _buttonAfterPageNext;
      private System.Windows.Forms.Label _labelAfterPage;
      private System.Windows.Forms.Button _buttonAfterPagePrevious;
      private System.Windows.Forms.Button _buttonAfterPageFirst;
      private System.Windows.Forms.Label _labelAfter;
      private System.Windows.Forms.ComboBox _comboBoxSizeMode;
      private System.Windows.Forms.Button _buttonZoomIn;
      private System.Windows.Forms.Button _buttonZoomNone;
      private System.Windows.Forms.Button _buttonZoomOut;
      private System.Windows.Forms.Label _labelBeforeInfo;
      private System.Windows.Forms.Label _labelAfterInfo;
      private System.Windows.Forms.ComboBox _comboBoxNamespace;
      private GroupBox _groupBoxRegion;
      private RadioButton _radioButtonRectangle;
      private RadioButton _radioButtonMagicWand;
      private RadioButton _radioButtonFreeHand;
      private RadioButton _radioButtonEllipse;
      private GroupBox _groupBoxRegionMode;
      private RadioButton _radioButtonInvert;
      private RadioButton _radioButtonIntersect;
      private RadioButton _radioButtonMulti;
      private RadioButton _radioButtonSingle;
      private RadioButton _radioButtonOldXORNew;
      private RadioButton _radioButtonNewandNotOld;
      private RadioButton _radioButtonOldandNotNew;
      private IContainer components;
      private RasterRegionCombineMode RegionCombineMode;
      private CheckBox _checkBoxOptionsDialog;
      private bool AddMagicWand;
      private MenuItem _menuItemView;
      private MenuItem _menuItemMagGlass;
      private MenuItem _menuItemMagGlassStart;
      private MenuItem _menuItemMagGlassStop;
      private MenuItem _menuItemImage;
      private MenuItem _menuItemHistogram;
      private bool FreeHandRgn;

      public MainForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //

         SizeModeItem[] items =
         {
            new SizeModeItem(ControlSizeMode.ActualSize, DemosGlobalization.GetResxString(GetType(), "resx_SizeModeActualSize")),
            new SizeModeItem(ControlSizeMode.Fit, DemosGlobalization.GetResxString(GetType(), "resx_SizeModeFit")),
            new SizeModeItem(ControlSizeMode.FitWidth, DemosGlobalization.GetResxString(GetType(), "resx_SizeModeFitWidth")),
            new SizeModeItem(ControlSizeMode.Stretch, DemosGlobalization.GetResxString(GetType(), "resx_SizeModeStretch"))
         };

         foreach (SizeModeItem i in items)
         {
            _comboBoxSizeMode.Items.Add(i);
         }

         this.Load += (s, e) =>
            {
               InitClass();
            };
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
         this._menuItemFileExit = new System.Windows.Forms.MenuItem();
         this._menuItemView = new System.Windows.Forms.MenuItem();
         this._menuItemMagGlass = new System.Windows.Forms.MenuItem();
         this._menuItemMagGlassStart = new System.Windows.Forms.MenuItem();
         this._menuItemMagGlassStop = new System.Windows.Forms.MenuItem();
         this._menuItemImage = new System.Windows.Forms.MenuItem();
         this._menuItemHistogram = new System.Windows.Forms.MenuItem();
         this._menuItemHelp = new System.Windows.Forms.MenuItem();
         this._menuItemHelpAbout = new System.Windows.Forms.MenuItem();
         this._panelProgress = new System.Windows.Forms.Panel();
         this._progressBar = new System.Windows.Forms.ProgressBar();
         this._buttonCancel = new System.Windows.Forms.Button();
         this._panelControls = new System.Windows.Forms.Panel();
         this._checkBoxOptionsDialog = new System.Windows.Forms.CheckBox();
         this._groupBoxRegionMode = new System.Windows.Forms.GroupBox();
         this._radioButtonOldXORNew = new System.Windows.Forms.RadioButton();
         this._radioButtonNewandNotOld = new System.Windows.Forms.RadioButton();
         this._radioButtonOldandNotNew = new System.Windows.Forms.RadioButton();
         this._radioButtonInvert = new System.Windows.Forms.RadioButton();
         this._radioButtonIntersect = new System.Windows.Forms.RadioButton();
         this._radioButtonMulti = new System.Windows.Forms.RadioButton();
         this._radioButtonSingle = new System.Windows.Forms.RadioButton();
         this._groupBoxRegion = new System.Windows.Forms.GroupBox();
         this._radioButtonMagicWand = new System.Windows.Forms.RadioButton();
         this._radioButtonFreeHand = new System.Windows.Forms.RadioButton();
         this._radioButtonEllipse = new System.Windows.Forms.RadioButton();
         this._radioButtonRectangle = new System.Windows.Forms.RadioButton();
         this._comboBoxNamespace = new System.Windows.Forms.ComboBox();
         this._buttonZoomOut = new System.Windows.Forms.Button();
         this._buttonZoomIn = new System.Windows.Forms.Button();
         this._buttonZoomNone = new System.Windows.Forms.Button();
         this._comboBoxSizeMode = new System.Windows.Forms.ComboBox();
         this._buttonNext = new System.Windows.Forms.Button();
         this._buttonPrevious = new System.Windows.Forms.Button();
         this._buttonRun = new System.Windows.Forms.Button();
         this._listBoxCommands = new System.Windows.Forms.ListBox();
         this._checkBoxUseRegion = new System.Windows.Forms.CheckBox();
         this._checkBoxProgress = new System.Windows.Forms.CheckBox();
         this._panelBefore = new System.Windows.Forms.Panel();
         this._labelBeforeInfo = new System.Windows.Forms.Label();
         this._panelBeforeControls = new System.Windows.Forms.Panel();
         this._buttonBeforePageLast = new System.Windows.Forms.Button();
         this._buttonBeforePageNext = new System.Windows.Forms.Button();
         this._labelBeforePage = new System.Windows.Forms.Label();
         this._buttonBeforePagePrevious = new System.Windows.Forms.Button();
         this._buttonBeforePageFirst = new System.Windows.Forms.Button();
         this._labelBefore = new System.Windows.Forms.Label();
         this._panelAfter = new System.Windows.Forms.Panel();
         this._labelAfterInfo = new System.Windows.Forms.Label();
         this._panelAfterControls = new System.Windows.Forms.Panel();
         this._buttonAfterPageLast = new System.Windows.Forms.Button();
         this._buttonAfterPageNext = new System.Windows.Forms.Button();
         this._labelAfterPage = new System.Windows.Forms.Label();
         this._buttonAfterPagePrevious = new System.Windows.Forms.Button();
         this._buttonAfterPageFirst = new System.Windows.Forms.Button();
         this._labelAfter = new System.Windows.Forms.Label();
         this._panelProgress.SuspendLayout();
         this._panelControls.SuspendLayout();
         this._groupBoxRegionMode.SuspendLayout();
         this._groupBoxRegion.SuspendLayout();
         this._panelBefore.SuspendLayout();
         this._panelBeforeControls.SuspendLayout();
         this._panelAfter.SuspendLayout();
         this._panelAfterControls.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenu
         // 
         this._mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFile,
            this._menuItemView,
            this._menuItemImage,
            this._menuItemHelp});
         // 
         // _menuItemFile
         // 
         this._menuItemFile.Index = 0;
         this._menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFileExit});
         resources.ApplyResources(this._menuItemFile, "_menuItemFile");
         // 
         // _menuItemFileExit
         // 
         this._menuItemFileExit.Index = 0;
         resources.ApplyResources(this._menuItemFileExit, "_menuItemFileExit");
         this._menuItemFileExit.Click += new System.EventHandler(this._menuItemFileExit_Click);
         // 
         // _menuItemView
         // 
         this._menuItemView.Index = 1;
         this._menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemMagGlass});
         resources.ApplyResources(this._menuItemView, "_menuItemView");
         // 
         // _menuItemMagGlass
         // 
         this._menuItemMagGlass.Index = 0;
         this._menuItemMagGlass.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemMagGlassStart,
            this._menuItemMagGlassStop});
         resources.ApplyResources(this._menuItemMagGlass, "_menuItemMagGlass");
         // 
         // _menuItemMagGlassStart
         // 
         this._menuItemMagGlassStart.Index = 0;
         resources.ApplyResources(this._menuItemMagGlassStart, "_menuItemMagGlassStart");
         this._menuItemMagGlassStart.Click += new System.EventHandler(this._menuItemMagGlassStart_Click);
         // 
         // _menuItemMagGlassStop
         // 
         this._menuItemMagGlassStop.Index = 1;
         resources.ApplyResources(this._menuItemMagGlassStop, "_menuItemMagGlassStop");
         this._menuItemMagGlassStop.Click += new System.EventHandler(this._menuItemMagGlassStop_Click);
         // 
         // _menuItemImage
         // 
         this._menuItemImage.Index = 2;
         this._menuItemImage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemHistogram});
         resources.ApplyResources(this._menuItemImage, "_menuItemImage");
         // 
         // _menuItemHistogram
         // 
         this._menuItemHistogram.Index = 0;
         resources.ApplyResources(this._menuItemHistogram, "_menuItemHistogram");
         this._menuItemHistogram.Click += new System.EventHandler(this._menuItemHistogram_Click);
         // 
         // _menuItemHelp
         // 
         this._menuItemHelp.Index = 3;
         this._menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemHelpAbout});
         resources.ApplyResources(this._menuItemHelp, "_menuItemHelp");
         // 
         // _menuItemHelpAbout
         // 
         this._menuItemHelpAbout.Index = 0;
         resources.ApplyResources(this._menuItemHelpAbout, "_menuItemHelpAbout");
         this._menuItemHelpAbout.Click += new System.EventHandler(this._menuItemHelpAbout_Click);
         // 
         // _panelProgress
         // 
         this._panelProgress.Controls.Add(this._progressBar);
         this._panelProgress.Controls.Add(this._buttonCancel);
         resources.ApplyResources(this._panelProgress, "_panelProgress");
         this._panelProgress.Name = "_panelProgress";
         // 
         // _progressBar
         // 
         resources.ApplyResources(this._progressBar, "_progressBar");
         this._progressBar.Name = "_progressBar";
         // 
         // _buttonCancel
         // 
         resources.ApplyResources(this._buttonCancel, "_buttonCancel");
         this._buttonCancel.Name = "_buttonCancel";
         this._buttonCancel.Click += new System.EventHandler(this._buttonCancel_Click);
         // 
         // _panelControls
         // 
         this._panelControls.Controls.Add(this._checkBoxOptionsDialog);
         this._panelControls.Controls.Add(this._groupBoxRegionMode);
         this._panelControls.Controls.Add(this._groupBoxRegion);
         this._panelControls.Controls.Add(this._comboBoxNamespace);
         this._panelControls.Controls.Add(this._buttonZoomOut);
         this._panelControls.Controls.Add(this._buttonZoomIn);
         this._panelControls.Controls.Add(this._buttonZoomNone);
         this._panelControls.Controls.Add(this._comboBoxSizeMode);
         this._panelControls.Controls.Add(this._buttonNext);
         this._panelControls.Controls.Add(this._buttonPrevious);
         this._panelControls.Controls.Add(this._buttonRun);
         this._panelControls.Controls.Add(this._listBoxCommands);
         this._panelControls.Controls.Add(this._checkBoxUseRegion);
         this._panelControls.Controls.Add(this._checkBoxProgress);
         resources.ApplyResources(this._panelControls, "_panelControls");
         this._panelControls.Name = "_panelControls";
         // 
         // _checkBoxOptionsDialog
         // 
         resources.ApplyResources(this._checkBoxOptionsDialog, "_checkBoxOptionsDialog");
         this._checkBoxOptionsDialog.Name = "_checkBoxOptionsDialog";
         this._checkBoxOptionsDialog.UseVisualStyleBackColor = true;
         // 
         // _groupBoxRegionMode
         // 
         this._groupBoxRegionMode.Controls.Add(this._radioButtonOldXORNew);
         this._groupBoxRegionMode.Controls.Add(this._radioButtonNewandNotOld);
         this._groupBoxRegionMode.Controls.Add(this._radioButtonOldandNotNew);
         this._groupBoxRegionMode.Controls.Add(this._radioButtonInvert);
         this._groupBoxRegionMode.Controls.Add(this._radioButtonIntersect);
         this._groupBoxRegionMode.Controls.Add(this._radioButtonMulti);
         this._groupBoxRegionMode.Controls.Add(this._radioButtonSingle);
         resources.ApplyResources(this._groupBoxRegionMode, "_groupBoxRegionMode");
         this._groupBoxRegionMode.Name = "_groupBoxRegionMode";
         this._groupBoxRegionMode.TabStop = false;
         // 
         // _radioButtonOldXORNew
         // 
         resources.ApplyResources(this._radioButtonOldXORNew, "_radioButtonOldXORNew");
         this._radioButtonOldXORNew.Name = "_radioButtonOldXORNew";
         this._radioButtonOldXORNew.TabStop = true;
         this._radioButtonOldXORNew.UseVisualStyleBackColor = true;
         this._radioButtonOldXORNew.CheckedChanged += new System.EventHandler(this._radioButtonOldXORNew_CheckedChanged);
         // 
         // _radioButtonNewandNotOld
         // 
         resources.ApplyResources(this._radioButtonNewandNotOld, "_radioButtonNewandNotOld");
         this._radioButtonNewandNotOld.Name = "_radioButtonNewandNotOld";
         this._radioButtonNewandNotOld.TabStop = true;
         this._radioButtonNewandNotOld.UseVisualStyleBackColor = true;
         this._radioButtonNewandNotOld.CheckedChanged += new System.EventHandler(this._radioButtonNewandNotOld_CheckedChanged);
         // 
         // _radioButtonOldandNotNew
         // 
         resources.ApplyResources(this._radioButtonOldandNotNew, "_radioButtonOldandNotNew");
         this._radioButtonOldandNotNew.Name = "_radioButtonOldandNotNew";
         this._radioButtonOldandNotNew.TabStop = true;
         this._radioButtonOldandNotNew.UseVisualStyleBackColor = true;
         this._radioButtonOldandNotNew.CheckedChanged += new System.EventHandler(this._radioButtonOldandNotNew_CheckedChanged);
         // 
         // _radioButtonInvert
         // 
         resources.ApplyResources(this._radioButtonInvert, "_radioButtonInvert");
         this._radioButtonInvert.Name = "_radioButtonInvert";
         this._radioButtonInvert.TabStop = true;
         this._radioButtonInvert.UseVisualStyleBackColor = true;
         this._radioButtonInvert.CheckedChanged += new System.EventHandler(this._radioButtonInvert_CheckedChanged);
         // 
         // _radioButtonIntersect
         // 
         resources.ApplyResources(this._radioButtonIntersect, "_radioButtonIntersect");
         this._radioButtonIntersect.Name = "_radioButtonIntersect";
         this._radioButtonIntersect.TabStop = true;
         this._radioButtonIntersect.UseVisualStyleBackColor = true;
         this._radioButtonIntersect.CheckedChanged += new System.EventHandler(this._radioButtonIntersect_CheckedChanged);
         // 
         // _radioButtonMulti
         // 
         resources.ApplyResources(this._radioButtonMulti, "_radioButtonMulti");
         this._radioButtonMulti.Name = "_radioButtonMulti";
         this._radioButtonMulti.TabStop = true;
         this._radioButtonMulti.UseVisualStyleBackColor = true;
         this._radioButtonMulti.CheckedChanged += new System.EventHandler(this._radioButtonMulti_CheckedChanged);
         // 
         // _radioButtonSingle
         // 
         resources.ApplyResources(this._radioButtonSingle, "_radioButtonSingle");
         this._radioButtonSingle.Name = "_radioButtonSingle";
         this._radioButtonSingle.TabStop = true;
         this._radioButtonSingle.UseVisualStyleBackColor = true;
         this._radioButtonSingle.CheckedChanged += new System.EventHandler(this._radioButtonSingle_CheckedChanged);
         // 
         // _groupBoxRegion
         // 
         this._groupBoxRegion.Controls.Add(this._radioButtonMagicWand);
         this._groupBoxRegion.Controls.Add(this._radioButtonFreeHand);
         this._groupBoxRegion.Controls.Add(this._radioButtonEllipse);
         this._groupBoxRegion.Controls.Add(this._radioButtonRectangle);
         resources.ApplyResources(this._groupBoxRegion, "_groupBoxRegion");
         this._groupBoxRegion.Name = "_groupBoxRegion";
         this._groupBoxRegion.TabStop = false;
         // 
         // _radioButtonMagicWand
         // 
         resources.ApplyResources(this._radioButtonMagicWand, "_radioButtonMagicWand");
         this._radioButtonMagicWand.Name = "_radioButtonMagicWand";
         this._radioButtonMagicWand.TabStop = true;
         this._radioButtonMagicWand.UseVisualStyleBackColor = true;
         this._radioButtonMagicWand.CheckedChanged += new System.EventHandler(this._radioButtonMagicWand_CheckedChanged);
         // 
         // _radioButtonFreeHand
         // 
         resources.ApplyResources(this._radioButtonFreeHand, "_radioButtonFreeHand");
         this._radioButtonFreeHand.Name = "_radioButtonFreeHand";
         this._radioButtonFreeHand.TabStop = true;
         this._radioButtonFreeHand.UseVisualStyleBackColor = true;
         this._radioButtonFreeHand.CheckedChanged += new System.EventHandler(this._radioButtonFreeHand_CheckedChanged);
         // 
         // _radioButtonEllipse
         // 
         resources.ApplyResources(this._radioButtonEllipse, "_radioButtonEllipse");
         this._radioButtonEllipse.Name = "_radioButtonEllipse";
         this._radioButtonEllipse.TabStop = true;
         this._radioButtonEllipse.UseVisualStyleBackColor = true;
         this._radioButtonEllipse.CheckedChanged += new System.EventHandler(this._radioButtonEllipse_CheckedChanged);
         // 
         // _radioButtonRectangle
         // 
         resources.ApplyResources(this._radioButtonRectangle, "_radioButtonRectangle");
         this._radioButtonRectangle.Name = "_radioButtonRectangle";
         this._radioButtonRectangle.TabStop = true;
         this._radioButtonRectangle.UseVisualStyleBackColor = true;
         this._radioButtonRectangle.CheckedChanged += new System.EventHandler(this._radioButtonRectangle_CheckedChanged);
         // 
         // _comboBoxNamespace
         // 
         resources.ApplyResources(this._comboBoxNamespace, "_comboBoxNamespace");
         this._comboBoxNamespace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboBoxNamespace.Name = "_comboBoxNamespace";
         this._comboBoxNamespace.SelectedIndexChanged += new System.EventHandler(this._comboBoxNamespace_SelectedIndexChanged);
         // 
         // _buttonZoomOut
         // 
         resources.ApplyResources(this._buttonZoomOut, "_buttonZoomOut");
         this._buttonZoomOut.Name = "_buttonZoomOut";
         this._buttonZoomOut.Click += new System.EventHandler(this._buttonZoom_Click);
         // 
         // _buttonZoomIn
         // 
         resources.ApplyResources(this._buttonZoomIn, "_buttonZoomIn");
         this._buttonZoomIn.Name = "_buttonZoomIn";
         this._buttonZoomIn.Click += new System.EventHandler(this._buttonZoom_Click);
         // 
         // _buttonZoomNone
         // 
         resources.ApplyResources(this._buttonZoomNone, "_buttonZoomNone");
         this._buttonZoomNone.Name = "_buttonZoomNone";
         this._buttonZoomNone.Click += new System.EventHandler(this._buttonZoom_Click);
         // 
         // _comboBoxSizeMode
         // 
         resources.ApplyResources(this._comboBoxSizeMode, "_comboBoxSizeMode");
         this._comboBoxSizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboBoxSizeMode.Name = "_comboBoxSizeMode";
         this._comboBoxSizeMode.SelectedIndexChanged += new System.EventHandler(this._comboBoxSizeMode_SelectedIndexChanged);
         // 
         // _buttonNext
         // 
         resources.ApplyResources(this._buttonNext, "_buttonNext");
         this._buttonNext.Name = "_buttonNext";
         this._buttonNext.Click += new System.EventHandler(this._buttonNext_Click);
         // 
         // _buttonPrevious
         // 
         resources.ApplyResources(this._buttonPrevious, "_buttonPrevious");
         this._buttonPrevious.Name = "_buttonPrevious";
         this._buttonPrevious.Click += new System.EventHandler(this._buttonPrevious_Click);
         // 
         // _buttonRun
         // 
         resources.ApplyResources(this._buttonRun, "_buttonRun");
         this._buttonRun.Name = "_buttonRun";
         this._buttonRun.Click += new System.EventHandler(this._buttonRun_Click);
         // 
         // _listBoxCommands
         // 
         resources.ApplyResources(this._listBoxCommands, "_listBoxCommands");
         this._listBoxCommands.Name = "_listBoxCommands";
         this._listBoxCommands.Sorted = true;
         this._listBoxCommands.SelectedIndexChanged += new System.EventHandler(this._listBoxCommands_SelectedIndexChanged);
         this._listBoxCommands.DoubleClick += new System.EventHandler(this._listBoxCommands_DoubleClick);
         // 
         // _checkBoxUseRegion
         // 
         resources.ApplyResources(this._checkBoxUseRegion, "_checkBoxUseRegion");
         this._checkBoxUseRegion.Name = "_checkBoxUseRegion";
         this._checkBoxUseRegion.CheckedChanged += new System.EventHandler(this._checkBoxUseRegion_CheckedChanged);
         // 
         // _checkBoxProgress
         // 
         resources.ApplyResources(this._checkBoxProgress, "_checkBoxProgress");
         this._checkBoxProgress.Name = "_checkBoxProgress";
         this._checkBoxProgress.CheckedChanged += new System.EventHandler(this._checkBoxProgress_CheckedChanged);
         // 
         // _panelBefore
         // 
         this._panelBefore.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._panelBefore.Controls.Add(this._labelBeforeInfo);
         this._panelBefore.Controls.Add(this._panelBeforeControls);
         resources.ApplyResources(this._panelBefore, "_panelBefore");
         this._panelBefore.Name = "_panelBefore";
         // 
         // _labelBeforeInfo
         // 
         this._labelBeforeInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         resources.ApplyResources(this._labelBeforeInfo, "_labelBeforeInfo");
         this._labelBeforeInfo.Name = "_labelBeforeInfo";
         // 
         // _panelBeforeControls
         // 
         this._panelBeforeControls.Controls.Add(this._buttonBeforePageLast);
         this._panelBeforeControls.Controls.Add(this._buttonBeforePageNext);
         this._panelBeforeControls.Controls.Add(this._labelBeforePage);
         this._panelBeforeControls.Controls.Add(this._buttonBeforePagePrevious);
         this._panelBeforeControls.Controls.Add(this._buttonBeforePageFirst);
         this._panelBeforeControls.Controls.Add(this._labelBefore);
         resources.ApplyResources(this._panelBeforeControls, "_panelBeforeControls");
         this._panelBeforeControls.Name = "_panelBeforeControls";
         // 
         // _buttonBeforePageLast
         // 
         resources.ApplyResources(this._buttonBeforePageLast, "_buttonBeforePageLast");
         this._buttonBeforePageLast.Name = "_buttonBeforePageLast";
         this._buttonBeforePageLast.Click += new System.EventHandler(this._buttonBeforePage_Click);
         // 
         // _buttonBeforePageNext
         // 
         resources.ApplyResources(this._buttonBeforePageNext, "_buttonBeforePageNext");
         this._buttonBeforePageNext.Name = "_buttonBeforePageNext";
         this._buttonBeforePageNext.Click += new System.EventHandler(this._buttonBeforePage_Click);
         // 
         // _labelBeforePage
         // 
         this._labelBeforePage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         resources.ApplyResources(this._labelBeforePage, "_labelBeforePage");
         this._labelBeforePage.Name = "_labelBeforePage";
         // 
         // _buttonBeforePagePrevious
         // 
         resources.ApplyResources(this._buttonBeforePagePrevious, "_buttonBeforePagePrevious");
         this._buttonBeforePagePrevious.Name = "_buttonBeforePagePrevious";
         this._buttonBeforePagePrevious.Click += new System.EventHandler(this._buttonBeforePage_Click);
         // 
         // _buttonBeforePageFirst
         // 
         resources.ApplyResources(this._buttonBeforePageFirst, "_buttonBeforePageFirst");
         this._buttonBeforePageFirst.Name = "_buttonBeforePageFirst";
         this._buttonBeforePageFirst.Click += new System.EventHandler(this._buttonBeforePage_Click);
         // 
         // _labelBefore
         // 
         resources.ApplyResources(this._labelBefore, "_labelBefore");
         this._labelBefore.Name = "_labelBefore";
         // 
         // _panelAfter
         // 
         this._panelAfter.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
         this._panelAfter.Controls.Add(this._labelAfterInfo);
         this._panelAfter.Controls.Add(this._panelAfterControls);
         resources.ApplyResources(this._panelAfter, "_panelAfter");
         this._panelAfter.Name = "_panelAfter";
         // 
         // _labelAfterInfo
         // 
         this._labelAfterInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         resources.ApplyResources(this._labelAfterInfo, "_labelAfterInfo");
         this._labelAfterInfo.Name = "_labelAfterInfo";
         // 
         // _panelAfterControls
         // 
         this._panelAfterControls.Controls.Add(this._buttonAfterPageLast);
         this._panelAfterControls.Controls.Add(this._buttonAfterPageNext);
         this._panelAfterControls.Controls.Add(this._labelAfterPage);
         this._panelAfterControls.Controls.Add(this._buttonAfterPagePrevious);
         this._panelAfterControls.Controls.Add(this._buttonAfterPageFirst);
         this._panelAfterControls.Controls.Add(this._labelAfter);
         resources.ApplyResources(this._panelAfterControls, "_panelAfterControls");
         this._panelAfterControls.Name = "_panelAfterControls";
         // 
         // _buttonAfterPageLast
         // 
         resources.ApplyResources(this._buttonAfterPageLast, "_buttonAfterPageLast");
         this._buttonAfterPageLast.Name = "_buttonAfterPageLast";
         this._buttonAfterPageLast.Click += new System.EventHandler(this._buttonAfterPage_Click);
         // 
         // _buttonAfterPageNext
         // 
         resources.ApplyResources(this._buttonAfterPageNext, "_buttonAfterPageNext");
         this._buttonAfterPageNext.Name = "_buttonAfterPageNext";
         this._buttonAfterPageNext.Click += new System.EventHandler(this._buttonAfterPage_Click);
         // 
         // _labelAfterPage
         // 
         this._labelAfterPage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         resources.ApplyResources(this._labelAfterPage, "_labelAfterPage");
         this._labelAfterPage.Name = "_labelAfterPage";
         // 
         // _buttonAfterPagePrevious
         // 
         resources.ApplyResources(this._buttonAfterPagePrevious, "_buttonAfterPagePrevious");
         this._buttonAfterPagePrevious.Name = "_buttonAfterPagePrevious";
         this._buttonAfterPagePrevious.Click += new System.EventHandler(this._buttonAfterPage_Click);
         // 
         // _buttonAfterPageFirst
         // 
         resources.ApplyResources(this._buttonAfterPageFirst, "_buttonAfterPageFirst");
         this._buttonAfterPageFirst.Name = "_buttonAfterPageFirst";
         this._buttonAfterPageFirst.Click += new System.EventHandler(this._buttonAfterPage_Click);
         // 
         // _labelAfter
         // 
         resources.ApplyResources(this._labelAfter, "_labelAfter");
         this._labelAfter.Name = "_labelAfter";
         // 
         // MainForm
         // 
         resources.ApplyResources(this, "$this");
         this.Controls.Add(this._panelAfter);
         this.Controls.Add(this._panelBefore);
         this.Controls.Add(this._panelControls);
         this.Controls.Add(this._panelProgress);
         this.Menu = this._mainMenu;
         this.Name = "MainForm";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
         this.Resize += new System.EventHandler(this.MainForm_Resize);
         this._panelProgress.ResumeLayout(false);
         this._panelControls.ResumeLayout(false);
         this._groupBoxRegionMode.ResumeLayout(false);
         this._groupBoxRegionMode.PerformLayout();
         this._groupBoxRegion.ResumeLayout(false);
         this._groupBoxRegion.PerformLayout();
         this._panelBefore.ResumeLayout(false);
         this._panelBeforeControls.ResumeLayout(false);
         this._panelAfter.ResumeLayout(false);
         this._panelAfterControls.ResumeLayout(false);
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

         Boolean bDocLocked = RasterSupport.IsLocked(RasterSupportType.Document);
         if (bDocLocked)
            MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

         Boolean bLocked = RasterSupport.IsLocked(RasterSupportType.Medical);
         if (bLocked)
            MessageBox.Show("Medical support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

         if (bLocked | bDocLocked)
            return;

         Application.EnableVisualStyles();
         Application.DoEvents();

         Application.Run(new MainForm());
      }

      private ImageViewer _viewerBefore;
      private ImageViewer _viewerAfter;
      private RasterCodecs _codecs;
      private CommandProperties _lastProps;
      private bool _runAlready;
      private bool _canClose;
      private bool _canceled;
      private Control _activeControl;
      private bool _allowEventDuringProcess;
      private int _xLastPos, _yLastPos, _windowLevelWidth, _windowLevelCenter;
      private MouseButton _buttonPressed;
      private RasterColor[] _currentPalette = null;
      private RasterColor16[] _currentPalette16 = null;
      private ToolTip _toolTip;
      private RasterPaletteWindowLevelFlags _flags;
      private bool _isWLImage, _isMagGlass;
      private bool _isViewerBefore;
      private int _LUTSize, _LUTSize16, _scale = 1, _maxWidth, _minWidth, _maxLevel, _minLevel, _minValue, _maxValue, _highBit;
      private RasterColor _startColor;
      private RasterColor16 _startColor16;
      private RasterColor _endColor;
      private RasterColor16 _endColor16;
      private ImageViewerAddRegionInteractiveMode _addRegion;
      private ImageViewerAddMagicWandInteractivMode _addMagicWand;
      private ImageViewerMagnifyGlassInteractiveMode _magnifyGlassInteractiveMode;
      private ImageViewerNoneInteractiveMode _noneInteractiveMode;
      private ImageViewerMagnifyGlassInteractiveMode _magnifyGlassInteractiveModeViewerAfter;
      private ImageViewerNoneInteractiveMode _noneInteractiveModeViewerAfter;

      public ImageViewerAddMagicWandInteractivMode AddMagicWandMode
      {
         get { return _addMagicWand; }
         set { _addMagicWand = value; }
      }

      //The SizeModeItem structure is used to determine 
      //how to fit the image in the viewer
      private struct SizeModeItem
      {
         private ControlSizeMode _sizeMode;
         private string _name;

         public SizeModeItem(ControlSizeMode sizeMode, string name)
         {
            _sizeMode = sizeMode;
            _name = name;
         }

         public ControlSizeMode SizeMode
         {
            get
            {
               return _sizeMode;
            }
         }

         public override string ToString()
         {
            return _name;
         }
      }

      //Use this function to check if the value is 
      //between minimum and maximum
      public static string IsValidNumber(string OrgStr, float minVal, float maxVal)
      {
         string str = "";

         foreach (char c1 in OrgStr)
            if (char.IsNumber(c1))
               str += c1.ToString();

         if (str != "")
         {
            if (float.Parse(str) < minVal)
               str = minVal.ToString();

            if (float.Parse(str) > maxVal)
               str = maxVal.ToString();
         }

         if (str == "")
            str = minVal.ToString();

         return str;
      }

      //Create the Before and After viewers, fill the lists
      //and set the default values
      private void InitClass()
      {
         _canClose = true;

         Messager.Caption = DemosGlobalization.GetResxString(GetType(), "resx_MessagerCaption");
         Text = Messager.Caption;

         _codecs = new RasterCodecs();

         _viewerBefore = new ImageViewer();
         _viewerBefore.BackColor = Color.DarkCyan;
         _viewerBefore.Dock = DockStyle.Fill;
         _viewerBefore.InteractiveModes.Clear();
         ImageViewerAutoPanInteractiveMode autoPan = new ImageViewerAutoPanInteractiveMode();
         autoPan.MouseButtons = System.Windows.Forms.MouseButtons.Left;
         _viewerBefore.InteractiveModes.Add(autoPan);
         _viewerBefore.ViewHorizontalAlignment = ControlAlignment.Center;
         _viewerBefore.ViewVerticalAlignment = ControlAlignment.Center;
         _panelBefore.Controls.Add(_viewerBefore);
         _viewerBefore.BringToFront();
         _viewerBefore.MouseDown += new MouseEventHandler(_viewer_MouseDown);
         _viewerBefore.MouseMove += new MouseEventHandler(_viewerBefore_MouseMove);
         _viewerBefore.MouseUp += new MouseEventHandler(_viewerBefore_MouseUp);

         _addRegion = new ImageViewerAddRegionInteractiveMode();
         _addRegion.AutoRegionToFloater = false;
         _addRegion.WorkCompleted += new EventHandler(viewerBefore_InteractiveModeEnded);
         _magnifyGlassInteractiveMode = new ImageViewerMagnifyGlassInteractiveMode();
         _noneInteractiveMode = new ImageViewerNoneInteractiveMode();
         _magnifyGlassInteractiveModeViewerAfter = new ImageViewerMagnifyGlassInteractiveMode();
         _noneInteractiveModeViewerAfter = new ImageViewerNoneInteractiveMode();
         
         AddMagicWandMode = new ImageViewerAddMagicWandInteractivMode();
         AddMagicWandMode.Threshold = 50;
         AddMagicWandMode.AutoItemMode = ImageViewerAutoItemMode.AutoSetActive;
         AddMagicWandMode.WorkOnBounds = true;
         AddMagicWandMode.MagicWandRegionCombineMode = RegionCombineMode;
         AddMagicWandMode.WorkCompleted += new EventHandler(_addMagicWand_WorkCompleted);

         _viewerBefore.InteractiveModes.BeginUpdate();
         _viewerBefore.InteractiveModes.Add(_addRegion);
         _viewerBefore.InteractiveModes.Add(AddMagicWandMode);
         _viewerBefore.InteractiveModes.Add(_magnifyGlassInteractiveMode);
         _viewerBefore.InteractiveModes.Add(_noneInteractiveMode);
         _noneInteractiveMode.IsEnabled = true;
         _viewerBefore.InteractiveModes.EndUpdate();

         _viewerAfter = new ImageViewer();
         _viewerAfter.BackColor = _viewerBefore.BackColor;
         _viewerAfter.Dock = _viewerBefore.Dock;
         _viewerAfter.InteractiveModes.Clear();
         _viewerAfter.MouseDown += new MouseEventHandler(_viewer_MouseDown);
         _viewerAfter.MouseMove += new MouseEventHandler(_viewerBefore_MouseMove);
         _viewerAfter.MouseUp += new MouseEventHandler(_viewerBefore_MouseUp);

         _viewerAfter.InteractiveModes.BeginUpdate();
         _viewerAfter.InteractiveModes.Add(_magnifyGlassInteractiveModeViewerAfter);
         _viewerAfter.InteractiveModes.Add(_noneInteractiveModeViewerAfter);
         _viewerAfter.InteractiveModes.EndUpdate();

         _viewerAfter.ViewHorizontalAlignment = _viewerBefore.ImageHorizontalAlignment;
         _viewerAfter.ViewVerticalAlignment = _viewerBefore.ImageVerticalAlignment;
         _panelAfter.Controls.Add(_viewerAfter);
         _viewerAfter.BringToFront();

         _viewerBefore.Zoom(ControlSizeMode.ActualSize, 1, _viewerBefore.DefaultZoomOrigin);

         _toolTip = new ToolTip();

         _flags = RasterPaletteWindowLevelFlags.Logarithmic |
                        RasterPaletteWindowLevelFlags.DicomStyle | RasterPaletteWindowLevelFlags.Outside;


         foreach (SizeModeItem i in _comboBoxSizeMode.Items)
            if (i.SizeMode == _viewerBefore.SizeMode)
               _comboBoxSizeMode.SelectedItem = i;


         foreach (CommandNamespace i in CommandNamespace.Namespaces)
            _comboBoxNamespace.Items.Add(i);

         _checkBoxProgress.Checked = true;

         DoResize();

         _lastProps = CommandProperties.Empty;
         _runAlready = false;

         _isMagGlass = false;

         _menuItemMagGlassStart.Checked = false;
         _menuItemMagGlassStop.Checked = true;

         _comboBoxNamespace.SelectedIndex = 0;
         RegionCombineMode = RasterRegionCombineMode.Set;

         AddMagicWand = false;
         FreeHandRgn = false;

         DisableInteractiveModes(true);

         _startColor = new RasterColor(0, 0, 0);
         _startColor16 = new RasterColor16(0, 0, 0);

         _endColor = new RasterColor(Leadtools.RasterColor.MaximumComponent, Leadtools.RasterColor.MaximumComponent, Leadtools.RasterColor.MaximumComponent);
         _endColor16 = new RasterColor16(RasterColor16.MaximumComponent, RasterColor16.MaximumComponent, RasterColor16.MaximumComponent);
      }

      void _addMagicWand_WorkCompleted(object sender, EventArgs e)
      {
         if (_viewerBefore.Image.HasRegion && _viewerAfter.Image != null)
         {
            byte[] RegionData = RasterRegionConverter.GetGdiRegionData(_viewerBefore.Image, null);
            RasterRegionConverter.AddGdiDataToRegion(_viewerAfter.Image, null, RegionData, 0, RasterRegionCombineMode.Set);
            AddMagicWand = _radioButtonMagicWand.Checked;
         }
      }

      //Cleanup the images
      private void CleanUp()
      {
         if (_viewerBefore.Image != null)
            _viewerBefore.Image = null;

         if (_viewerAfter.Image != null)
            _viewerAfter.Image = null;
      }

      //Terminate the application
      private void _menuItemFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void _menuItemHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Image Processing", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void MainForm_Resize(object sender, System.EventArgs e)
      {
         DoResize();
      }

      private void DoResize()
      {
         _panelBefore.Width = ClientSize.Width / 2;
      }

      private void _checkBoxProgress_CheckedChanged(object sender, System.EventArgs e)
      {
         _panelProgress.Visible = _checkBoxProgress.Checked;
      }

      private void _listBoxCommands_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         _isViewerBefore = true;
         UpdateImageValues();
         if (!_checkBoxUseRegion.Checked)
         {
            if (_viewerBefore.Image != null && _viewerBefore.Image.HasRegion)
               _viewerBefore.Image.MakeRegionEmpty();

            if (_viewerAfter.Image != null && _viewerAfter.Image.HasRegion)
               _viewerAfter.Image.MakeRegionEmpty();
         }

         PrepareCommand();

         _isWLImage = false;

         try
         {
            if (_viewerBefore.Image.GrayscaleMode != RasterGrayscaleMode.None)
            {
               switch (_viewerBefore.Image.BitsPerPixel)
               {
                  case 8:
                     _currentPalette = _viewerBefore.Image.GetPalette();
                     _LUTSize = 256;
                     _minValue = 0;
                     _maxValue = 255;
                     _isWLImage = true;
                     break;
                  case 12:
                  case 16:
                     _viewerBefore.Image.UseLookupTable = true;
                     _currentPalette = _viewerBefore.Image.GetLookupTable();
                     _highBit = _viewerBefore.Image.HighBit;
                     if (_highBit == -1)
                        _highBit = _viewerBefore.Image.BitsPerPixel - 1;
                     if (_currentPalette == null)
                     {
                        _LUTSize = (int)Math.Pow(2, _highBit + 1);
                        _maxValue = (_viewerBefore.Image.Signed) ? _LUTSize / 2 - 1 : _LUTSize - 1;
                        _minValue = (_viewerBefore.Image.Signed) ? -_LUTSize / 2 : 0;
                     }
                     else
                     {
                        _LUTSize = _currentPalette.Length;
                        MinMaxValuesCommand minMaxValueCmd = new MinMaxValuesCommand();
                        minMaxValueCmd.Run(_viewerBefore.Image);
                        _maxValue = minMaxValueCmd.MaximumValue;
                        _minValue = minMaxValueCmd.MinimumValue;
                     }
                     _isWLImage = true;
                     break;
               }
               _scale = ((_maxValue - _minValue) / 1000 > 0) ? (_maxValue - _minValue) / 1000 : 1;
               _maxWidth = (int)Math.Pow(2, _viewerBefore.Image.BitsPerPixel);
               _minWidth = 1;
               _maxLevel = (int)Math.Pow(2, _viewerBefore.Image.BitsPerPixel) - 1;
               _minLevel = (int)Math.Pow(2, _viewerBefore.Image.BitsPerPixel) * -1 + 1;
               _windowLevelCenter = (_maxValue - _minValue) / 2;
               _windowLevelWidth = _maxValue - _minValue;
               if (_viewerBefore.Image.Signed)
                  _flags |= RasterPaletteWindowLevelFlags.Signed;
            }
         }
         catch { }
      }

      private void _listBoxCommands_DoubleClick(object sender, System.EventArgs e)
      {
         if (_listBoxCommands.SelectedItem != null)
            Run();
      }

      //Load the Before and After images and set the default region
      //on the viewers
      private void PrepareCommand()
      {
         RasterRegion r = null;

         try
         {
            CommandProperties props = (CommandProperties)_listBoxCommands.SelectedItem;
            bool loadBeforeImage = true;//false
            bool loadAfterImage = true;//false
            bool cloneAfterImage = false;
            
            if (props.BeforeImage != _lastProps.BeforeImage)
               loadBeforeImage = true;
            if (_runAlready || loadBeforeImage || _lastProps.AfterImage != props.AfterImage)
            {
               if (props.BeforeImage != props.AfterImage)
                  loadAfterImage = true;
               else
                  cloneAfterImage = true;
            }

            if (loadBeforeImage)
            {
               using (WaitCursor wait = new WaitCursor())
               {
                  //Get the image file name for this command
                  string imageFileName = CommandProperties.GetImageNameFileName(props.BeforeImage);
                  //Load the Before image
                  int BeforeImageW = 0;
                  int BeforeImageH = 0;

                  if (_viewerBefore.Image != null)
                  {
                     BeforeImageW = _viewerBefore.Image.Width;
                     BeforeImageH = _viewerBefore.Image.Height;
                  }

                  if (_viewerBefore.Image != null)
                  {
                     if (_viewerBefore.Image.HasRegion)
                     {
                        r = _viewerBefore.Image.GetRegion(null);
                     }

                     _viewerBefore.Image.Dispose();
                  }

                  _viewerBefore.Image = _codecs.Load(imageFileName, 0, CodecsLoadByteOrder.BgrOrGray, 1, -1);




                  if (_isWLImage)
                  {
                     _isViewerBefore = true;
                     ChangeThePalette();
                  }
               }
            }

            if (loadAfterImage)
            {
               using (WaitCursor wait = new WaitCursor())
               {
                  if (props.AfterImage != CommandImage.None)
                  {
                     //Get the image file name for this command
                     string imageFileName = CommandProperties.GetImageNameFileName(props.AfterImage);
                     //Load the After image
                     int BeforeImageW = 0;
                     int BeforeImageH = 0;

                     if (_viewerAfter.Image != null)
                     {
                        BeforeImageW = _viewerAfter.Image.Width;
                        BeforeImageH = _viewerAfter.Image.Height;
                     }

                     if (_viewerAfter.Image != null)
                     {
                        _viewerAfter.Image.Dispose();
                     }

                     _viewerAfter.Image = _codecs.Load(imageFileName);

                     if (_isWLImage)
                     {
                        _isViewerBefore = false;
                        ChangeThePalette();
                     }
                  }
                  else
                     _viewerAfter.Image = null;
               }
            }

            if (cloneAfterImage)
               _viewerAfter.Image = _viewerBefore.Image.Clone();

            if (loadBeforeImage)
            {
               if (_checkBoxUseRegion.Checked)
               {
                  if (r != null)
                  {
                     if (_viewerBefore.Image != null)
                        _viewerBefore.Image.SetRegion(null, r, RasterRegionCombineMode.Set);

                     if (_viewerAfter.Image != null)
                        _viewerAfter.Image.SetRegion(null, r, RasterRegionCombineMode.Set);
                  }
                  else
                  {
                      // in case the region has been remove due to the previous effect.
                      _checkBoxUseRegion_CheckedChanged(null, null);
                  }
               }
            }


            _lastProps = props;

            UpdatePages(_viewerBefore.Image, _buttonBeforePageFirst, _buttonBeforePagePrevious, _buttonBeforePageNext, _buttonBeforePageLast, _labelBeforePage);
            UpdatePages(_viewerAfter.Image, _buttonAfterPageFirst, _buttonAfterPagePrevious, _buttonAfterPageNext, _buttonAfterPageLast, _labelAfterPage);

            _checkBoxOptionsDialog.Enabled = props.HasDialog;
            //}
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            _runAlready = false;
            UpdateImageInformation();

            if (_isWLImage)
            {
                UpdateImageValues();
                try
                {
                    if (_viewerBefore.Image.GrayscaleMode != RasterGrayscaleMode.None)
                    {
                        switch (_viewerBefore.Image.BitsPerPixel)
                        {
                            case 8:
                                _currentPalette = _viewerBefore.Image.GetPalette();
                                _LUTSize = 256;
                                _minValue = 0;
                                _maxValue = 255;
                                _isWLImage = true;
                                break;
                            case 12:
                            case 16:
                                _viewerBefore.Image.UseLookupTable = true;
                                _currentPalette = _viewerBefore.Image.GetLookupTable();
                                _highBit = _viewerBefore.Image.HighBit;
                                if (_highBit == -1)
                                    _highBit = _viewerBefore.Image.BitsPerPixel - 1;
                                if (_currentPalette == null)
                                {
                                    _LUTSize = (int)Math.Pow(2, _highBit + 1);
                                    _maxValue = (_viewerBefore.Image.Signed) ? _LUTSize / 2 - 1 : _LUTSize - 1;
                                    _minValue = (_viewerBefore.Image.Signed) ? -_LUTSize / 2 : 0;
                                }
                                else
                                {
                                    _LUTSize = _currentPalette.Length;
                                    MinMaxValuesCommand minMaxValueCmd = new MinMaxValuesCommand();
                                    minMaxValueCmd.Run(_viewerBefore.Image);
                                    _maxValue = minMaxValueCmd.MaximumValue;
                                    _minValue = minMaxValueCmd.MinimumValue;
                                }
                                _isWLImage = true;
                                break;
                        }
                        _scale = ((_maxValue - _minValue) / 1000 > 0) ? (_maxValue - _minValue) / 1000 : 1;
                        _maxWidth = (int)Math.Pow(2, _viewerBefore.Image.BitsPerPixel);
                        _minWidth = 1;
                        _maxLevel = (int)Math.Pow(2, _viewerBefore.Image.BitsPerPixel) - 1;
                        _minLevel = (int)Math.Pow(2, _viewerBefore.Image.BitsPerPixel) * -1 + 1;
                        _windowLevelCenter = (_maxValue - _minValue) / 2;
                        _windowLevelWidth = _maxValue - _minValue;
                        if (_viewerBefore.Image.Signed)
                            _flags |= RasterPaletteWindowLevelFlags.Signed;
                    }

                    _isViewerBefore = true;
                    ChangeThePalette();
                    _isViewerBefore = false;
                    ChangeThePalette();
                }
                catch { }
            }
         }
      }

      private void UpdateImageInformation()
      {
         SetInformation(_labelBeforeInfo, _viewerBefore.Image);
         SetInformation(_labelAfterInfo, _viewerAfter.Image);
      }
      //Set and display the image information
      private void SetInformation(Label label, RasterImage image)
      {
         if (image != null)
         {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Size: {0} by {1} pixels{2}", image.Width, image.Height, Environment.NewLine));
            sb.Append(string.Format("Bits/Pixel: {0}{1}", image.BitsPerPixel, Environment.NewLine));
            sb.Append(string.Format("ViewPerspective: {0}", image.ViewPerspective));
            label.Text = sb.ToString();
         }
         else
            label.Text = string.Empty;
      }

      private void UpdatePages(RasterImage image, Button buttonFirst, Button buttonPrevious, Button buttonNext, Button buttonLast, Label labelPage)
      {
         buttonFirst.Visible = image != null && image.PageCount > 1;
         buttonFirst.Enabled = image != null && image.Page > 1;
         buttonPrevious.Visible = image != null && image.PageCount > 1;
         buttonPrevious.Enabled = image != null && image.Page > 1;
         buttonNext.Visible = image != null && image.PageCount > 1;
         buttonNext.Enabled = image != null && image.Page < image.PageCount;
         buttonLast.Visible = image != null && image.PageCount > 1;
         buttonLast.Enabled = image != null && image.Page < image.PageCount;
         labelPage.Visible = image != null && image.PageCount > 1;
         labelPage.Text = image != null ? string.Format("{0} {1}:{2}", DemosGlobalization.GetResxString(GetType(), "resx_Page"), image.Page, image.PageCount) : string.Empty;
      }
      //Enable and Disable regions options
      private void _checkBoxUseRegion_CheckedChanged(object sender, System.EventArgs e)
      {
         if (_checkBoxUseRegion.Checked)
         {
            _groupBoxRegion.Enabled = true;
            _groupBoxRegionMode.Enabled = true;
            _radioButtonRectangle.Checked = true;
            _radioButtonSingle.Checked = true;

            if (_viewerBefore.Image != null)
            {
               _viewerBefore.Image.MakeRegionEmpty();
               _viewerBefore.Image.AddRectangleToRegion(null, new LeadRect(_viewerBefore.Image.Width / 4, _viewerBefore.Image.Height / 4, _viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2), RasterRegionCombineMode.Set);
            }

            if (_viewerAfter.Image != null)
               _viewerAfter.Image.AddRectangleToRegion(null, new LeadRect(_viewerAfter.Image.Width / 4, _viewerAfter.Image.Height / 4, _viewerAfter.Image.Width / 2, _viewerAfter.Image.Height / 2), RasterRegionCombineMode.Set);


            PrepareCommand();
         }
         else
         {
            _viewerBefore.Image.MakeRegionEmpty();
            _radioButtonRectangle.Checked = true;
            _radioButtonSingle.Checked = true;
            _groupBoxRegion.Enabled = false;
            _groupBoxRegionMode.Enabled = false;
            DisableInteractiveModes(true);
            _viewerBefore.InteractiveModes.BeginUpdate();
            _noneInteractiveMode.IsEnabled = true;
            _viewerBefore.InteractiveModes.EndUpdate();
            if (_viewerAfter.Image != null)
               _viewerAfter.Image.MakeRegionEmpty();
         }
      }

      private void viewerBefore_InteractiveModeEnded(object sender, EventArgs e)
      {
         LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);

         if (_viewerBefore.Image.HasRegion)
         {
            byte[] RegionData = RasterRegionConverter.GetGdiRegionData(_viewerBefore.Image, null);
            if (_viewerAfter.Image != null)
               RasterRegionConverter.AddGdiDataToRegion(_viewerAfter.Image, null, RegionData, 0, RasterRegionCombineMode.Set);
         }
      }


      private void _comboBoxNamespace_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         _listBoxCommands.Items.Clear();

         CommandProperties Temp = new CommandProperties(typeof(ClearCommand), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, false);
         CommandNamespace ns = (CommandNamespace)_comboBoxNamespace.SelectedItem;

         foreach (CommandProperties i in ns.Properties)
         {
            _listBoxCommands.Items.Add(i);
         }
         if (ns.Properties[1].Type == Temp.Type)
         {
            string str = "Add Border";
            _listBoxCommands.Items.Add(new CommandProperties(str.GetType(), CommandImage.ImageProcessingDemo__Image1_jpg, CommandImage.ImageProcessingDemo__Image1_jpg, false));
         }
         _runAlready = true;
         _listBoxCommands.SelectedIndex = 0;
      }

      private void _comboBoxSizeMode_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         if (_comboBoxSizeMode.SelectedItem != null)
         {
            SizeModeItem item = (SizeModeItem)_comboBoxSizeMode.SelectedItem;
            if (_viewerBefore.SizeMode != item.SizeMode)
               _viewerBefore.Zoom(item.SizeMode, 1, _viewerBefore.DefaultZoomOrigin);
         }
      }

      private void _buttonZoom_Click(object sender, System.EventArgs e)
      {
         if (sender == _buttonZoomNone)
            _viewerBefore.Zoom(_viewerBefore.SizeMode, 1, _viewerBefore.DefaultZoomOrigin);
         else if (sender == _buttonZoomIn)
         {
            double scaleFactor = _viewerBefore.ScaleFactor;
            scaleFactor *= 2;
            // making sure not to enlarge its size more than 32 times.
            if (scaleFactor > 32)
               scaleFactor = 32;
            _viewerBefore.Zoom(ControlSizeMode.None, scaleFactor, _viewerBefore.DefaultZoomOrigin);
         }
         else if (sender == _buttonZoomOut)
         {
            double scaleFactor = _viewerBefore.ScaleFactor;
            scaleFactor /= 2;
            // making sure that the image doesn't become too small.
            if (scaleFactor < 0.001)
               scaleFactor = 0.001f;
            _viewerBefore.Zoom(ControlSizeMode.None, scaleFactor, _viewerBefore.DefaultZoomOrigin);

         }
      }

      private void _buttonRun_Click(object sender, System.EventArgs e)
      {
         _isViewerBefore = true;
         UpdateImageValues();
         Run();
      }

      private void _buttonNext_Click(object sender, System.EventArgs e)
      {
         byte[] MyRegion = null;
         if (!_checkBoxUseRegion.Checked)
         {
            if (_viewerBefore.Image != null && _viewerBefore.Image.HasRegion)
               _viewerBefore.Image.MakeRegionEmpty();

            if (_viewerAfter.Image != null && _viewerAfter.Image.HasRegion)
               _viewerAfter.Image.MakeRegionEmpty();
         }
         else
         {
            MyRegion = RasterRegionConverter.GetGdiRegionData(_viewerBefore.Image, null);

            if (_viewerBefore.Image != null && _viewerBefore.Image.HasRegion)
               _viewerBefore.Image.MakeRegionEmpty();

            RasterRegionConverter.AddGdiDataToRegion(_viewerBefore.Image, null, MyRegion, 0, RasterRegionCombineMode.Set);

            if (_viewerAfter.Image != null && _viewerAfter.Image.HasRegion)
               _viewerAfter.Image.MakeRegionEmpty();

            if (_viewerAfter.Image != null)

               RasterRegionConverter.AddGdiDataToRegion(_viewerAfter.Image, null, MyRegion, 0, RasterRegionCombineMode.Set);
         }
         if (_listBoxCommands.SelectedIndex < (_listBoxCommands.Items.Count - 1))
            _listBoxCommands.SelectedIndex++;
         else
            _listBoxCommands.SelectedIndex = 0;

         Run();
      }

      private void _buttonPrevious_Click(object sender, System.EventArgs e)
      {
         if (_listBoxCommands.SelectedIndex > 0)
            _listBoxCommands.SelectedIndex--;
         else
            _listBoxCommands.SelectedIndex = _listBoxCommands.Items.Count - 1;

         Run();
      }

      private void _buttonBeforePage_Click(object sender, System.EventArgs e)
      {
         try
         {
            if (sender == _buttonBeforePageFirst)
               _viewerBefore.Image.Page = 1;
            else if (sender == _buttonBeforePagePrevious)
               _viewerBefore.Image.Page--;
            else if (sender == _buttonBeforePageNext)
               _viewerBefore.Image.Page++;
            else if (sender == _buttonBeforePageLast)
               _viewerBefore.Image.Page = _viewerBefore.Image.PageCount;
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdatePages(_viewerBefore.Image, _buttonBeforePageFirst, _buttonBeforePagePrevious, _buttonBeforePageNext, _buttonBeforePageLast, _labelBeforePage);
         }
      }

      private void _buttonAfterPage_Click(object sender, System.EventArgs e)
      {
         try
         {
            if (sender == _buttonAfterPageFirst)
               _viewerAfter.Image.Page = 1;
            else if (sender == _buttonAfterPagePrevious)
               _viewerAfter.Image.Page--;
            else if (sender == _buttonAfterPageNext)
               _viewerAfter.Image.Page++;
            else if (sender == _buttonAfterPageLast)
               _viewerAfter.Image.Page = _viewerAfter.Image.PageCount;
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdatePages(_viewerAfter.Image, _buttonAfterPageFirst, _buttonAfterPagePrevious, _buttonAfterPageNext, _buttonAfterPageLast, _labelAfterPage);
         }
      }

      private int Increment(int x, int lutLen)
      {
         return ((x + 1) % lutLen);
      }

      private int Decrement(int x, int lutLen)
      {
         return ((x + (lutLen - 1)) % lutLen);
      }

      private int Add(int x, int y, int lutLen)
      {
         return ((x + y) % lutLen);
      }

      private void Run()
      {
         PrepareCommand();

         if (_checkBoxProgress.Checked)
            Progress(false);

         try
         {
             bool UseRegionChecked = _checkBoxUseRegion.Checked;
            _allowEventDuringProcess = true;
            CommandProperties props = (CommandProperties)_listBoxCommands.SelectedItem;

            if (props.Type.Name == "String")//Add Border
            {
               RasterImage SrcImage, backImage;
               RasterCodecs _codecs;

               _codecs = new RasterCodecs();

               SrcImage = _viewerBefore.Image.Clone();

               backImage = new RasterImage(RasterMemoryFlags.Conventional, SrcImage.Width + 50, SrcImage.Height + 50, 24, RasterByteOrder.Bgr, RasterViewPerspective.TopLeft, null, IntPtr.Zero, 0);

               FillCommand Fill = new FillCommand();
               Fill.Color = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Black);
               Fill.Run(backImage);

               CombineCommand Combine = new CombineCommand();
               Combine.DestinationRectangle = new LeadRect(25, 25, SrcImage.Width, SrcImage.Height);
               Combine.SourcePoint = new LeadPoint(0, 0);
               Combine.SourceImage = SrcImage;
               Combine.Run(backImage);

               _viewerAfter.Image = backImage.Clone();

               return;
            }
            else
            {


               RasterCommand command = Activator.CreateInstance(props.Type) as RasterCommand;
               bool runAfterImage = true;
               byte[] Regiondata = null;

               Regiondata = RasterRegionConverter.GetGdiRegionData(_viewerBefore.Image, null);
               if (command is ChangeViewPerspectiveCommand)
               {
                  ChangeViewPerspectiveCommand cmd = command as ChangeViewPerspectiveCommand;

                  if (_checkBoxOptionsDialog.Checked)
                  {
                     ChangeViewPerspectiveDialog ChangeViewPerspectiveDlg = new ChangeViewPerspectiveDialog();
                     if (ChangeViewPerspectiveDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.InPlace = true;
                        cmd.ViewPerspective = ChangeViewPerspectiveDlg.ChangeViewPerspectivecommand.ViewPerspective;
                        cmd.Run(_viewerAfter.Image);

                        RasterRegionConverter.AddGdiDataToRegion(_viewerAfter.Image, null, Regiondata, 0, RasterRegionCombineMode.Set);

                        return;

                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.InPlace = true;
                     cmd.ViewPerspective = _viewerBefore.Image.ViewPerspective == RasterViewPerspective.TopLeft ?
                     RasterViewPerspective.BottomLeft :
                     RasterViewPerspective.TopLeft;

                     cmd.Run(_viewerAfter.Image);

                     RasterRegionConverter.AddGdiDataToRegion(_viewerAfter.Image, null, Regiondata, 0, RasterRegionCombineMode.Set);

                     return;
                  }

               }
               else if (command is ShearCommand)
               {
                  _viewerAfter.Image.Dispose();
                  _viewerAfter.Image = _viewerBefore.Image.Clone();
                  _viewerAfter.Image.MakeRegionEmpty();
               }
               else if (command is CloneCommand)
               {
                  CloneCommand cmd = command as CloneCommand;
                  runAfterImage = false;
               }
               else if (command is RotateCommand)
               {
                  RotateCommand cmd = command as RotateCommand;

                  if (_checkBoxOptionsDialog.Checked)
                  {
                     RotateDialog dlg = new RotateDialog();

                     if (dlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Angle = dlg.Angle;
                        cmd.Flags = dlg.Flags;
                        cmd.FillColor = dlg.FillColor;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Angle = 45 * 100;
                     cmd.FillColor = new RasterColor(255, 255, 255);
                     cmd.Flags = RotateCommandFlags.Bicubic;
                  }
               }
               else if (command is ColorResolutionCommand)
               {
                  ColorResolutionCommand cmd = command as ColorResolutionCommand;

                  if (_checkBoxOptionsDialog.Checked)
                  {
                     ColorResolutionDialog dlg = new ColorResolutionDialog(new ColorResolutionCommand(), _viewerBefore.Image.BitsPerPixel);
                     if (dlg.ShowDialog() == DialogResult.OK)
                     {
                        cmd.Mode = dlg.ColorResolutionCommand.Mode;
                        cmd.BitsPerPixel = dlg.ColorResolutionCommand.BitsPerPixel;
                        cmd.Order = dlg.ColorResolutionCommand.Order;
                        cmd.DitheringMethod = dlg.ColorResolutionCommand.DitheringMethod;
                        cmd.PaletteFlags = dlg.ColorResolutionCommand.PaletteFlags;
                     }
                     else
                        return;
                  }
                  else
                     cmd.BitsPerPixel = _viewerBefore.Image.BitsPerPixel == 8 ? 24 : 8;
               }
               else if (command is CombineFastCommand)
               {
                  CombineFastCommand cmd = command as CombineFastCommand;
                  cmd.DestinationRectangle = new LeadRect(0, 0, _viewerBefore.Image.Width, _viewerBefore.Image.Height);
                  cmd.SourcePoint = LeadPoint.Empty;
                  cmd.Flags = CombineFastCommandFlags.OperationAverage;
                  cmd.DestinationImage = _viewerAfter.Image;
                  runAfterImage = false;
               }
               else if (command is CombineWarpCommand)
               {
                  CombineWarpCommand cmd = command as CombineWarpCommand;
                  int eighth = _viewerAfter.Image.Width / 8;
                  LeadPoint[] pts = new LeadPoint[]
               {
                  new LeadPoint(eighth * 2, eighth),
                  new LeadPoint(_viewerAfter.Image.Width - eighth, eighth * 2),
                  new LeadPoint(_viewerAfter.Image.Width - eighth * 2, _viewerAfter.Image.Height - eighth * 2),
                  new LeadPoint(eighth, _viewerAfter.Image.Height - eighth)
               };
                  cmd.SetDestinationPoints(pts);

                  cmd.SourceRectangle = new LeadRect(0, 0, _viewerBefore.Image.Width, _viewerBefore.Image.Height);
                  cmd.Flags = CombineWarpCommandFlags.Bilinear;
                  cmd.DestinationImage = _viewerAfter.Image;
                  runAfterImage = false;
               }
               else if (command is FillCommand)
               {
                  FillCommand cmd = command as FillCommand;

                  if (_checkBoxOptionsDialog.Checked)
                  {
                     ColorDialog dlg = new ColorDialog();
                     if (dlg.ShowDialog() == DialogResult.OK)
                     {
                        cmd.Color = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color);
                     }
                     else
                        return;
                  }
                  else
                     cmd.Color = Leadtools.Demos.Converters.FromGdiPlusColor(Color.Red);
               }
               else if (command is CopyDataCommand)
               {
                  CopyDataCommand cmd = command as CopyDataCommand;
                  cmd.DestinationImage = _viewerAfter.Image;
                  runAfterImage = false;
               }
               else if (command is CopyRectangleCommand)
               {
                  CopyRectangleCommand cmd = command as CopyRectangleCommand;
                  int eighth = _viewerBefore.Image.Width / 8;
                  cmd.Rectangle = new LeadRect(eighth, eighth, _viewerBefore.Image.Width - eighth * 2, _viewerBefore.Image.Height - eighth * 2);
                  runAfterImage = false;
               }
               else if (command is CropCommand)
               {
                  CropCommand cmd = command as CropCommand;
                  CropDialog CropDlg = new CropDialog(new CropCommand(), _viewerBefore.Image);
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     if (CropDlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Rectangle = CropDlg.Cropcommand.Rectangle;
                     else
                        return;
                  }
                  else
                  {
                     int eighth = _viewerBefore.Image.Width / 8;
                     cmd.Rectangle = new LeadRect(eighth, eighth, _viewerBefore.Image.Width - eighth * 2, _viewerBefore.Image.Height - eighth * 2);
                  }
               }
               else if (command is ResizeCommand)
               {
                  ResizeCommand cmd = command as ResizeCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     ResizeCommandDialog ResizeCommandDlg = new ResizeCommandDialog(_viewerBefore.Image);
                     if (ResizeCommandDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        RasterImage destImage = new RasterImage(
                           RasterMemoryFlags.Conventional,
                           ResizeCommandDlg.ImageWidth,
                           ResizeCommandDlg.ImageHeight,
                           _viewerBefore.Image.BitsPerPixel,
                           _viewerBefore.Image.Order,
                           _viewerBefore.Image.ViewPerspective,
                           _viewerBefore.Image.GetPalette(),
                           IntPtr.Zero,
                           0);
                        cmd.Flags = ResizeCommandDlg.ResizeCommand.Flags;
                        cmd.DestinationImage = destImage;

                        cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);

                        if (_checkBoxProgress.Checked)
                           cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                        cmd.Run(_viewerBefore.Image);

                        _viewerAfter.Image = destImage.Clone();

                        destImage.Dispose();
                        destImage = null;

                        return;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.DestinationImage = _viewerAfter.Image;
                     runAfterImage = false;
                  }
               }
               else if (command is SizeCommand)
               {
                  SizeCommand cmd = command as SizeCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     ResizeDialog dlg = new ResizeDialog(_viewerBefore.Image.Width, _viewerBefore.Image.Height);
                     if (dlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Width = dlg.ImageWidth;
                        cmd.Height = dlg.ImageHeight;
                        cmd.Flags = dlg.Flags;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Width = _viewerAfter.Image.Width / 2;
                     cmd.Height = _viewerAfter.Image.Height / 2;
                  }
               }
               else if (command is AddWeightedCommand)
               {
                  AddWeightedCommand cmd = command as AddWeightedCommand;
                  cmd.Factor = new int[10];
                  cmd.Type = AddWeightedCommandType.Average;
                  runAfterImage = false;
               }
               else if (command is AddCommand)
               {
                  runAfterImage = false;
               }
               else if (command is AddNoiseCommand)
               {
                  AddNoiseCommand cmd = command as AddNoiseCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     AddNoiseDialog AddNoiseDlg = new AddNoiseDialog();

                     if (AddNoiseDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Channel = AddNoiseDlg.AddNoisecommand.Channel;
                        cmd.Range = AddNoiseDlg.AddNoisecommand.Range;
                     }
                     else
                        return;

                  }
                  else
                  {
                     cmd.Range = 100;
                     cmd.Channel = RasterColorChannel.Green;
                  }
               }
               else if (command is AverageCommand)
               {
                  AverageCommand cmd = command as AverageCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     AverageDialog AverageDlg = new AverageDialog();
                     if (AverageDlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Dimension = AverageDlg.Dimension;
                     else
                        return;

                  }
                  else
                     cmd.Dimension = 3;
               }
               else if (command is MeanShiftCommand)
               {
                  MeanShiftCommand cmd = command as MeanShiftCommand;
                  cmd.ColorDistance = 10;
                  cmd.Radius = 5;
               }
               else if (command is SigmaCommand)
               {
                  SigmaCommand cmd = command as SigmaCommand;
                  cmd.Dimension = 10;
                  cmd.Sigma = 2;
                  cmd.Threshold = 0.2f;
                  cmd.Outline = false;
               }
               else if (command is AnisotropicDiffusionCommand)
               {
                  AnisotropicDiffusionCommand cmd = command as AnisotropicDiffusionCommand;
                  cmd.Iterations = 20;
                  cmd.Smoothing = 1;
                  cmd.TimeStep = 200.0f;
                  cmd.MinVariation = .5f;
                  cmd.MaxVariation = .8f;
                  cmd.EdgeHeight = 4.0f;
                  cmd.Update = 10;

               }

               else if (command is TissueEqualizeCommand)
               {
                  TissueEqualizeCommand cmd = command as TissueEqualizeCommand;

                  cmd.Flags = TissueEqualizeCommandFlags.UseIntensifyOption;
               }
               else if (command is AutoSegmentCommand)
               {
                  AutoSegmentCommand cmd = command as AutoSegmentCommand ;
                  LeadRect rect = new LeadRect(194, 161, 111, 153);
                  cmd.SegmentationRectangle = rect;
               }
               else if (command is RakeRemoveCommand)
               {
                  RakeRemoveCommand cmd = command as RakeRemoveCommand;
                  cmd.MinLength = 50;
                  cmd.MinWallHeight = 10;
                  cmd.MaxWidth = 3;
                  cmd.MaxWallPercent = 25;
                  cmd.MaxSideteethLength = 60;
                  cmd.MaxMidteethLength = 50;
                  cmd.Gaps = 1;
                  cmd.Variance = 1;
                  cmd.TeethSpacing = 5;
                  cmd.AutoFilter = true;

                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  cmd.Run(_viewerAfter.Image);
                  return;
               }
               else if (command is ObjectCounterCommand)
               {
                  ObjectCounterCommand cmd = command as ObjectCounterCommand;


                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  cmd.Run(_viewerAfter.Image);
                  Messager.ShowInformation(this, cmd.Count.ToString());
                  return;
               }
               else if (command is SliceCommand)
               {
                  SliceCommand cmd = command as SliceCommand;
                  cmd.Slice += new EventHandler<Leadtools.ImageProcessing.Core.SliceCommandEventArgs>(cmd_Slice);
                  cmd.MaximumDeskewAngle = 40;
                  cmd.Flags = SliceCommandFlags.WithoutCut | SliceCommandFlags.Bicubic | SliceCommandFlags.DeskewImage;
                  cmd.FillColor = new Leadtools.RasterColor(0, 0, 0);
               }
               else if (command is EmbossCommand)
               {
                  EmbossCommand cmd = command as EmbossCommand;
                  EmbossDialog EmbossDlg = new EmbossDialog();
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     if (EmbossDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Depth = EmbossDlg.Embosscommand.Depth;
                        cmd.Direction = EmbossDlg.Embosscommand.Direction;
                     }
                     else
                        return;

                  }
                  else
                  {
                     cmd.Depth = 0;
                     cmd.Direction = EmbossCommandDirection.North;
                  }
               }
               else if (command is MedianCommand)
               {
                  MedianCommand cmd = command as MedianCommand;
                  MedianDialog MedianDlg = new MedianDialog();
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     if (MedianDlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Dimension = MedianDlg.Mediancommand.Dimension;
                     else
                        return;
                  }
                  else

                     cmd.Dimension = 3;
               }
               else if (command is MosaicCommand)
               {
                  MosaicCommand cmd = command as MosaicCommand;
                  MedianDialog MosaicDlg = new MedianDialog();
                  MosaicDlg.Text = DemosGlobalization.GetResxString(GetType(), "resx_MosaicDlgTitle");
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     if (MosaicDlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Dimension = MosaicDlg.Mediancommand.Dimension;
                     else
                        return;
                  }
                  else
                  {
                     cmd.Dimension = 2;
                  }
               }
               else if (command is SharpenCommand)
               {
                  SharpenCommand cmd = command as SharpenCommand;
                  SharpenDialog SharpenDlg = new SharpenDialog();
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     if (SharpenDlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Sharpness = SharpenDlg.Sharpencommand.Sharpness;
                     else
                        return;
                  }
                  else
                     cmd.Sharpness = 100;


               }
               else if (command is AutoCropRectangleCommand)
               {
                  AutoCropRectangleCommand cmd = command as AutoCropRectangleCommand;
                  cmd.Threshold = 0;
               }
               else if (command is OilifyCommand)
               {
                  OilifyCommand cmd = command as OilifyCommand;
                  OilifyDialog OilifyDlg = new OilifyDialog();
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     if (OilifyDlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Dimension = OilifyDlg.Oilifycommand.Dimension;
                     else
                        return;
                  }
                  else
                     cmd.Dimension = 1;
               }
               else if (command is MinimumCommand)
               {
                  MinimumCommand cmd = command as MinimumCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     MinimumDialog MinimumDlg = new MinimumDialog();
                     if (MinimumDlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Dimension = MinimumDlg.Dimension;
                     else
                        return;
                  }
                  else
                     cmd.Dimension = 1;
               }
               else if (command is MaximumCommand)
               {
                  MaximumCommand cmd = command as MaximumCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     MinimumDialog MinimumDlg = new MinimumDialog();
                     MinimumDlg.Text = DemosGlobalization.GetResxString(GetType(), "resx_MaximumDlgTitle");
                     if (MinimumDlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Dimension = MinimumDlg.Dimension;
                     else
                        return;
                  }
                  else
                     cmd.Dimension = 1;
               }
               else if (command is PicturizeSingleCommand)
               {
                  PicturizeSingleCommand cmd = command as PicturizeSingleCommand;
                  cmd.CellHeight = 10;
                  cmd.CellWidth = 10;
                  cmd.LightnessFactor = 0;
                  cmd.ThumbImage = _viewerBefore.Image;
               }
               else if (command is PicturizeListCommand)
               {
                  PicturizeListCommand cmd = command as PicturizeListCommand;
                  cmd.CellHeight = 20;
                  cmd.CellWidth = 20;
                  cmd.LightnessFactor = 0;
               }
               else if (command is ContourFilterCommand)
               {

                  ContourFilterCommand cmd = command as ContourFilterCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     ContourFilterDialog ContourFilterDlg = new ContourFilterDialog();
                     if (ContourFilterDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Type = ContourFilterDlg.ContourFilterCommand.Type;
                        cmd.DeltaDirection = ContourFilterDlg.ContourFilterCommand.DeltaDirection;
                        cmd.Threshold = ContourFilterDlg.ContourFilterCommand.Threshold;
                        cmd.MaximumError = ContourFilterDlg.ContourFilterCommand.MaximumError;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Type = ContourFilterCommandType.Thin;
                     cmd.Threshold = 5;
                     cmd.MaximumError = 20;
                     cmd.DeltaDirection = 35;

                  }

                  _viewerAfter.Image.Dispose();
                  _viewerAfter.Image = _viewerBefore.Image.Clone();

                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  cmd.Run(_viewerAfter.Image);

                  return;
               }
               else if (command is SegmentCommand)
               {
                  SegmentCommand cmd = command as SegmentCommand;
                  cmd.Flags = SegmentCommandFlags.Rgb;
                  cmd.Threshold = 25;
               }
               else if (command is WindCommand)
               {
                  WindCommand cmd = command as WindCommand;
                  cmd.Dimension = 5;
                  cmd.Angle = 0;
                  cmd.Opacity = 0;
               }
               else if (command is RadialWaveCommand)
               {
                  RadialWaveCommand cmd = command as RadialWaveCommand;
                  cmd.Amplitude = 5;
                  cmd.Flags = RadialWaveCommandFlags.Repeat | RadialWaveCommandFlags.Frequency;
                  cmd.Phase = 0;
                  cmd.WaveLength = 25;
                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else
                     cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
               }
               else if (command is FreeHandShearCommand)
               {
                  FreeHandShearCommand cmd = command as FreeHandShearCommand;
                  LeadPoint[] points =
               {
                  new LeadPoint(0, 0),
                  new LeadPoint(3, 10),
                  new LeadPoint(9, -10),
                  new LeadPoint(12, 0)
               };

                  cmd.Amplitudes = new int[13];
                  EffectsUtilities.GetCurvePoints(cmd.Amplitudes, points, CurvePointsType.Linear);

                  int max = 0;
                  for (int i = 0; i < 13; i++)
                  {
                     if (max < cmd.Amplitudes[i])
                        max = cmd.Amplitudes[i];
                  }

                  if (max != 0)
                  {
                     for (int i = 0; i < 13; i++)
                        cmd.Amplitudes[i] = (1000 * cmd.Amplitudes[i] / Math.Abs(max));
                  }

                  cmd.Flags = FreeHandShearCommandFlags.Repeat | FreeHandShearCommandFlags.Horizontal;
                  cmd.Scale = 50;
                  cmd.FillColor = new RasterColor(0, 0, 0);
               }
               else if (command is FreeHandWaveCommand)
               {
                  FreeHandWaveCommand cmd = command as FreeHandWaveCommand;
                  LeadPoint[] points =
               {
                  new LeadPoint(0, 0),
                  new LeadPoint(3, 10),
                  new LeadPoint(9, -10),
                  new LeadPoint(12, 0)
               };

                  cmd.Angle = 4500;
                  cmd.Amplitudes = new int[13];
                  EffectsUtilities.GetCurvePoints(cmd.Amplitudes, points, CurvePointsType.Linear);

                  int max = 0;
                  for (int i = 0; i < 13; i++)
                  {
                     if (max < cmd.Amplitudes[i])
                        max = cmd.Amplitudes[i];
                  }

                  if (max != 0)
                  {
                     for (int i = 0; i < 13; i++)
                        cmd.Amplitudes[i] = (1000 * cmd.Amplitudes[i] / Math.Abs(max));
                  }

                  cmd.Flags = FreeHandWaveCommandFlags.Repeat | FreeHandWaveCommandFlags.Frequency;
                  cmd.Scale = 100;
                  cmd.WaveLength = 25;
                  cmd.FillColor = new RasterColor(0, 0, 0);
               }
               else if (command is ImpressionistCommand)
               {
                  ImpressionistCommand cmd = command as ImpressionistCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     ImpressionistDialog ImpressionistDlg = new ImpressionistDialog(_viewerBefore.Image.Clone());
                     if (ImpressionistDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.HorizontalDimension = ImpressionistDlg.HorizontalSize;
                        cmd.VerticalDimension = ImpressionistDlg.VerticalSize;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.HorizontalDimension = (_viewerBefore.Image.Width * 4) / 100;
                     cmd.VerticalDimension = (_viewerBefore.Image.Height * 4) / 100;
                  }
               }
               else if (command is SphereCommand)
               {
                  SphereCommand cmd = command as SphereCommand;
                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else
                     cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  cmd.FillColor = new RasterColor(0, 0, 0);
                  cmd.Flags = SphereCommandFlags.Color | SphereCommandFlags.WithoutRotate;
                  cmd.Value = 50;
               }
               else if (command is CylinderCommand)
               {
                  CylinderCommand cmd = command as CylinderCommand;
                  cmd.Type = CylinderCommandType.Horizontal;
                  cmd.Value = 50;
               }
               else if (command is BendCommand)
               {
                  BendCommand cmd = command as BendCommand;

                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else
                     cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  cmd.FillColor = new RasterColor(0, 0, 0);
                  cmd.Flags = BendCommandFlags.Color | BendCommandFlags.WithoutRotate | BendCommandFlags.NoChange;
                  cmd.Value = 50;
               }
               else if (command is PunchCommand)
               {
                  PunchCommand cmd = command as PunchCommand;
                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else
                     cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  cmd.FillColor = new RasterColor(0, 0, 0);
                  cmd.Flags = PunchCommandFlags.NoChange | PunchCommandFlags.WithoutRotate;
                  cmd.Value = -50;
                  cmd.Stress = 1;
               }
               else if (command is PolarCommand)
               {
                  PolarCommand cmd = command as PolarCommand;
                  cmd.FillColor = new RasterColor(0, 0, 0);
                  cmd.Flags = PolarCommandFlags.CartToPolar | PolarCommandFlags.Color;
               }
               else if (command is PixelateCommand)
               {
                  PixelateCommand cmd = command as PixelateCommand;
                  cmd.CellHeight = 10;
                  cmd.CellWidth = 10;
                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else
                     cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  cmd.Flags = PixelateCommandFlags.Average | PixelateCommandFlags.Radial | PixelateCommandFlags.WidthPeriod | PixelateCommandFlags.HeightPeriod;
                  cmd.Opacity = 100;
               }
               else if (command is RadialBlurCommand)
               {
                  RadialBlurCommand cmd = command as RadialBlurCommand;
                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else
                     cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  cmd.Dimension = 25;
                  cmd.Stress = 1;
               }
               else if (command is RippleCommand)
               {
                  RippleCommand cmd = command as RippleCommand;
                  cmd.Amplitude = 30;
                  cmd.Attenuation = 0;
                  cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  cmd.FillColor = new RasterColor(0, 0, 0);
                  cmd.Phase = 0;
                  cmd.Type = RippleCommandType.NoChange;
                  cmd.Frequency = 6;
               }
               else if (command is SwirlCommand)
               {
                  SwirlCommand cmd = command as SwirlCommand;
                  cmd.Angle = 50;
                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else
                     cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
               }
               else if (command is ZoomBlurCommand)
               {
                  ZoomBlurCommand cmd = command as ZoomBlurCommand;
                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else
                     cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  cmd.Dimension = 30;
                  cmd.Stress = 1;
               }
               else if (command is DeinterlaceCommand)
               {
                  DeinterlaceCommand cmd = command as DeinterlaceCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     DeinterlaceDialog DeinterlaceDlg = new DeinterlaceDialog();
                     if (DeinterlaceDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Flags = DeinterlaceDlg.DeinterlaceCommand.Flags;
                     }
                     else
                        return;
                  }
                  else
                     cmd.Flags = DeinterlaceCommandFlags.Smooth | DeinterlaceCommandFlags.Odd;
               }
               else if (command is SampleTargetCommand)
               {
                  SampleTargetCommand cmd = command as SampleTargetCommand;
                  cmd.Flags = SampleTargetCommandFlags.Rgb | SampleTargetCommandFlags.Mid;
                  cmd.SampleColor = new RasterColor(50, 50, 50);
                  cmd.TargetColor = new RasterColor(100, 100, 100);
               }
               else if (command is RegionHolesRemovalCommand)
               {
                  RegionHolesRemovalCommand cmd = command as RegionHolesRemovalCommand;
                  LeadRect rc = new LeadRect(_viewerBefore.Image.Width / 8, _viewerBefore.Image.Height / 8, _viewerBefore.Image.Width / 2 + _viewerBefore.Image.Width / 8, _viewerBefore.Image.Height / 2 + _viewerBefore.Image.Height / 8);
                  _viewerBefore.Image.AddEllipseToRegion(null, rc, RasterRegionCombineMode.SetNot);
                  _viewerAfter.Image.AddEllipseToRegion(null, rc, RasterRegionCombineMode.SetNot);
               }
               else if (command is CubismCommand)
               {
                  CubismCommand cmd = command as CubismCommand;
                  cmd.Angle = 0;
                  cmd.Brightness = 0;
                  cmd.FillColor = new RasterColor(0, 0, 0);
                  cmd.Flags = CubismCommandFlags.Background | CubismCommandFlags.Random | CubismCommandFlags.Square;
                  cmd.Length = 200;
                  cmd.Space = 90;
               }
               else if (command is GlassEffectCommand)
               {
                  GlassEffectCommand cmd = command as GlassEffectCommand;
                  cmd.CellHeight = 20;
                  cmd.CellWidth = 20;
                  cmd.Flags = GlassEffectCommandFlags.WidthFrequency | GlassEffectCommandFlags.HeightFrequency;
               }
               else if (command is LensFlareCommand)
               {
                  LensFlareCommand cmd = command as LensFlareCommand;
                  cmd.Brightness = 100;
                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else
                     cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 4, _viewerBefore.Image.Height / 4);
                  cmd.Color = new RasterColor(0, 0, 0);
                  cmd.Type = LensFlareCommandType.Type1;
               }
               else if (command is ColorSeparateCommand)
               {
                  runAfterImage = false;
               }

               else if (command is ResizeRegionCommand) //Update
               {
                  LeadRect rc = new LeadRect(_viewerBefore.Image.Width / 2 - _viewerBefore.Image.Width / 8, _viewerBefore.Image.Height / 2 - _viewerBefore.Image.Height / 8, _viewerBefore.Image.Width / 4, _viewerBefore.Image.Height / 4);
                  if (!(_viewerBefore.Image.HasRegion))
                  {
                     _viewerBefore.Image.AddRectangleToRegion(null, rc, RasterRegionCombineMode.Set);
                     _viewerAfter.Image.AddRectangleToRegion(null, rc, RasterRegionCombineMode.Set);
                  }
                  ResizeRegionCommand cmd = command as ResizeRegionCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     ResizeRegionDialog ResizeRegionDlg = new ResizeRegionDialog();
                     if (ResizeRegionDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.AsFrame = ResizeRegionDlg.ResizeRegionCommand.AsFrame;
                        cmd.Dimension = ResizeRegionDlg.ResizeRegionCommand.Dimension;
                        cmd.Type = ResizeRegionDlg.ResizeRegionCommand.Type;
                        cmd.Run(_viewerAfter.Image);
                        return;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.AsFrame = true;
                     cmd.Dimension = 60;
                     cmd.Type = ResizeRegionCommandType.ExpandRegion;
                     cmd.Run(_viewerAfter.Image);
                     return;
                  }
               }
               else if (command is ConvertUnsignedToSignedCommand)//Update
               {
                  ConvertUnsignedToSignedCommand cmd = command as ConvertUnsignedToSignedCommand;
                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  ConvertUnsignedToSignedDialog ConvertUnsignedToSignedDlg = new ConvertUnsignedToSignedDialog();
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     if (ConvertUnsignedToSignedDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Type = ConvertUnsignedToSignedDlg.ConvertUnsignedToSignedCommand.Type;
                        cmd.Run(_viewerAfter.Image);
                        Messager.ShowInformation(this, DemosGlobalization.GetResxString(GetType(), "resx_SignedImage"));
                        ConvertSignedToUnsignedCommand command1 = new ConvertSignedToUnsignedCommand();
                        if (_checkBoxProgress.Checked)
                           command1.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                        command1.Run(_viewerAfter.Image);
                        Messager.ShowInformation(this, DemosGlobalization.GetResxString(GetType(), "resx_UnSignedImage"));
                        return;
                     }
                     else
                        return;
                  }
                  else
                  {
                     if (_checkBoxProgress.Checked)
                        cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                     cmd.Run(_viewerAfter.Image);
                     //Messager.ShowInformation(this, DemosGlobalization.GetResxString(GetType(), "resx_SignedImage"));
                     ConvertSignedToUnsignedCommand command1 = new ConvertSignedToUnsignedCommand();
                     if (_checkBoxProgress.Checked)
                        command1.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                     command1.Run(_viewerAfter.Image);
                     Messager.ShowInformation(this, DemosGlobalization.GetResxString(GetType(), "resx_UnSignedImage"));
                     return;


                  }
               }
               else if (command is BumpMapCommand)
               {
                  BumpMapCommand cmd = command as BumpMapCommand;
                  cmd.Azimuth = 50;
                  cmd.Brightness = 50;
                  cmd.BumpImage = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__Ulay3_Bmp));
                  cmd.BumpPoint = new LeadPoint(0, 0);
                  cmd.Depth = 1;
                  cmd.DestinationPoint = new LeadPoint(0, 0);
                  cmd.Elevation = 5;
                  cmd.Intensity = 0;
                  cmd.LookupTable = null;
                  cmd.Tile = true;
               }
               else if (command is GlowCommand)
               {
                  GlowCommand cmd = command as GlowCommand;
                  cmd.Brightness = 7;
                  cmd.Dimension = 3;
                  cmd.Threshold = 0;
               }
               else if (command is EdgeDetectStatisticalCommand)
               {
                  EdgeDetectStatisticalCommand cmd = command as EdgeDetectStatisticalCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     EdgeDetectStatisticalDialog EdgeDetectStatisticalDlg = new EdgeDetectStatisticalDialog();
                     if (EdgeDetectStatisticalDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.BackGroundColor = EdgeDetectStatisticalDlg.EdgeDetectStatisticalCommand.BackGroundColor;
                        cmd.Dimension = EdgeDetectStatisticalDlg.EdgeDetectStatisticalCommand.Dimension;
                        cmd.EdgeColor = EdgeDetectStatisticalDlg.EdgeDetectStatisticalCommand.EdgeColor;
                        cmd.Threshold = EdgeDetectStatisticalDlg.EdgeDetectStatisticalCommand.Threshold;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.BackGroundColor = new RasterColor(0, 0, 0);
                     cmd.Dimension = 3;
                     cmd.EdgeColor = new RasterColor(255, 255, 255);
                     cmd.Threshold = 35;
                  }
               }
               else if (command is SmoothEdgesCommand)
               {
                  SmoothEdgesCommand cmd = command as SmoothEdgesCommand;

                  if (_checkBoxOptionsDialog.Checked)
                  {
                     SmoothEdgesDialog SmoothEdgesDlg = new SmoothEdgesDialog();
                     if (SmoothEdgesDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Amount = SmoothEdgesDlg.SmoothEdgesCommand.Amount;
                        cmd.Threshold = SmoothEdgesDlg.SmoothEdgesCommand.Threshold;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Amount = 100;
                     cmd.Threshold = 0;
                  }
               }
               else if (command is PlaneCommand)
               {
                  PlaneCommand cmd = command as PlaneCommand;
                  cmd.BrightColor = new RasterColor(255, 255, 255);
                  cmd.BrightLength = 25;
                  cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  cmd.Distance = _viewerBefore.Image.Height / 2;
                  cmd.EndBright = 100;
                  cmd.FillColor = new RasterColor(255, 255, 255);
                  cmd.Flags = PlaneCommandFlags.Color | PlaneCommandFlags.Down | PlaneCommandFlags.Up | PlaneCommandFlags.Left | PlaneCommandFlags.Right;
                  cmd.PlaneOffset = _viewerBefore.Image.Height / 2;
                  cmd.PyramidAngle = 0;
                  cmd.Repeat = -1;
                  cmd.StartBright = 0;
                  cmd.Stretch = 100;
                  cmd.ZValue = 0;
               }
               else if (command is PlaneBendCommand)
               {
                  PlaneBendCommand cmd = command as PlaneBendCommand;
                  cmd.BrightColor = new RasterColor(255, 255, 255);
                  cmd.BrightLength = 50;
                  cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width * 2 / 3, _viewerBefore.Image.Height / 2);
                  cmd.Distance = _viewerBefore.Image.Height / 2;
                  cmd.EndBright = 0;
                  cmd.FillColor = new RasterColor(0, 0, 0);
                  cmd.Flags = PlaneCommandFlags.Color | PlaneCommandFlags.Down;
                  cmd.PlaneOffset = _viewerBefore.Image.Height / 2;
                  cmd.PyramidAngle = 0;
                  cmd.Repeat = -1;
                  cmd.StartBright = 0;
                  cmd.Stretch = 75;
                  cmd.ZValue = 0;
                  cmd.BendFactor = 300;
               }
               else if (command is ColorIntensityBalanceCommand)
               {
                  ColorIntensityBalanceCommand cmd = command as ColorIntensityBalanceCommand;
                  cmd.HighLight = new ColorIntensityBalanceCommandData(70, 0, 0);
                  cmd.Shadows = new ColorIntensityBalanceCommandData(60, 0, 0);
                  cmd.MidTone = new ColorIntensityBalanceCommandData(40, 0, 0);
                  cmd.Luminance = false;
               }
               else if (command is TunnelCommand)
               {
                  TunnelCommand cmd = command as TunnelCommand;
                  cmd.BrightColor = new RasterColor(255, 255, 255);
                  cmd.BrightLength = 50;
                  cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width * 2 / 3, _viewerBefore.Image.Height / 2);
                  cmd.Distance = _viewerBefore.Image.Height / 2;
                  cmd.EndBright = 0;
                  cmd.FillColor = new RasterColor(255, 255, 255);
                  cmd.Flags = TunnelCommandFlags.Color | TunnelCommandFlags.WidthAxis;
                  cmd.Repeat = -1;
                  cmd.StartBright = 0;
                  cmd.Stretch = 75;
                  cmd.ZValue = 0;
                  cmd.Radius = _viewerBefore.Image.Height / 2;
                  cmd.RotationOffset = 0;
               }
               else if (command is FreeRadialBendCommand)
               {
                  LeadPoint[] Points =
               {
                  new LeadPoint(0, 0),
                  new LeadPoint(3, 1),
                  new LeadPoint(9, -1),
                  new LeadPoint(12, 0),
               };

                  FreeRadialBendCommand cmd = command as FreeRadialBendCommand;
                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else
                     cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  cmd.Curve = new int[13];
                  EffectsUtilities.GetCurvePoints(cmd.Curve, Points, CurvePointsType.Linear);
                  for (int i = 0; i < cmd.Curve.Length; i++)
                     cmd.Curve[i] /= 2;

                  cmd.FillColor = new RasterColor(0, 0, 0);
                  cmd.Flags = FreeRadialBendCommandFlags.Color | FreeRadialBendCommandFlags.WithoutRotate;
                  cmd.Scale = 50;
               }
               else if (command is AutoCropCommand)
               {
                  AutoCropCommand cmd = command as AutoCropCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     AutoCropDialog AutoCropDlg = new AutoCropDialog();
                     if (AutoCropDlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Threshold = AutoCropDlg.Threshold;
                     else
                        return;
                  }
                  else
                     cmd.Threshold = 128;
               }
               else if (command is FreePlaneBendCommand)
               {
                  LeadPoint[] Points =
               {
                  new LeadPoint(0, 0),
                  new LeadPoint(3, 1),
                  new LeadPoint(5, -1),
                  new LeadPoint(7, 0)
               };

                  FreePlaneBendCommand cmd = command as FreePlaneBendCommand;
                  cmd.Curve = new int[13];
                  EffectsUtilities.GetCurvePoints(cmd.Curve, Points, CurvePointsType.Linear);
                  for (int i = 0; i < cmd.Curve.Length; i++)
                     cmd.Curve[i] /= 2;

                  cmd.FillColor = new RasterColor(0, 0, 0);
                  cmd.Flags = FreePlaneBendCommandFlags.Color | FreePlaneBendCommandFlags.HorizontalVertical;
                  cmd.Scale = 50;
               }
               else if (command is OceanCommand)
               {
                  OceanCommand cmd = command as OceanCommand;
                  cmd.Amplitude = 25;
                  cmd.Frequency = 20;
                  cmd.LowerTransparency = false;
               }
               else if (command is LightCommand)
               {
                  LightCommand cmd = command as LightCommand;
                  cmd.Ambient = 100;
                  cmd.AmbientColor = new RasterColor(255, 255, 255);
                  cmd.Bright = 100;
                  cmd.Data = new LightCommandData[1];
                  cmd.Data[0].Angle = 4500;
                  cmd.Data[0].Brightness = 100;
                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.Data[0].CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else

                     cmd.Data[0].CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  cmd.Data[0].Edge = 100;
                  cmd.Data[0].FillColor = new RasterColor(255, 255, 255);
                  cmd.Data[0].Height = _viewerBefore.Image.Width / 10;
                  cmd.Data[0].Opacity = 100;
                  cmd.Data[0].Type = LightCommandType.Spot;
                  cmd.Data[0].Width = _viewerBefore.Image.Width / 5;
               }
               else if (command is DryCommand)
               {
                  DryCommand cmd = command as DryCommand;
                  cmd.Dimension = 9;
               }
               else if (command is DrawStarCommand)
               {
                  DrawStarCommand cmd = command as DrawStarCommand;
                  cmd.Angle = 4500;
                  cmd.AngleOpacity = 100;
                  cmd.BorderOpacity = 100;
                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else
                     cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  cmd.DistanceOpacity = 0;
                  cmd.Flags = DrawStarCommandFlags.Outside | DrawStarCommandFlags.Inner;
                  cmd.HoleSize = 50;
                  cmd.LowerColorFill = new RasterColor(255, 0, 0);
                  cmd.Opacity = 100;
                  cmd.Phase = 0;
                  cmd.Spoke = 8;
                  cmd.SpokeDivision = 0;
                  cmd.StarHeight = _viewerBefore.Image.Height / 2;
                  cmd.StarWidth = _viewerBefore.Image.Width * 3 / 4;
                  cmd.UpperColorFill = new RasterColor(0, 255, 0);
               }
               else if (command is FunctionalLightCommand)
               {
                  FunctionalLightCommand cmd = command as FunctionalLightCommand;
                  cmd.Angle = 0;
                  cmd.BlueAmplitude = 50;
                  cmd.Buffer = null;
                  cmd.Flags = FunctionalLightCommandFlags.Trigonometry | FunctionalLightCommandFlags.Addition | FunctionalLightCommandFlags.Circles;
                  cmd.Frequency = 1500;
                  cmd.GreenAmplitude = 50;
                  cmd.Origin = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  ;
                  cmd.PhaseShift = 0;
                  cmd.RedAmplitude = 50;
               }
               else if (command is DiceEffectCommand)
               {
                  DiceEffectCommand cmd = command as DiceEffectCommand;
                  cmd.BorderColor = new RasterColor(0, 0, 0);
                  cmd.Flags = DiceEffectCommandFlags.Border | DiceEffectCommandFlags.ResizeImage | DiceEffectCommandFlags.Size;
                  cmd.Randomize = 0;
                  cmd.XBlock = 16;
                  cmd.YBlock = 16;
               }
               else if (command is PuzzleEffectCommand)
               {
                  PuzzleEffectCommand cmd = command as PuzzleEffectCommand;
                  cmd.BorderColor = new RasterColor(255, 255, 255);
                  cmd.Flags = PuzzleEffectCommandFlags.Border | PuzzleEffectCommandFlags.Resize | PuzzleEffectCommandFlags.Shuffle | PuzzleEffectCommandFlags.Count;
                  cmd.Randomize = 0;
                  cmd.XBlock = 16;
                  cmd.YBlock = 16;
               }
               else if (command is RingEffectCommand)
               {
                  RingEffectCommand cmd = command as RingEffectCommand;
                  cmd.Angle = 250;
                  cmd.Color = new RasterColor(0, 0, 0);
                  cmd.Flags = RingEffectCommandFlags.Color | RingEffectCommandFlags.Radius | RingEffectCommandFlags.FixedAngle;
                  cmd.Origin = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  ;
                  cmd.Radius = 2;
                  cmd.Randomize = 0;
                  cmd.RingCount = 50;
               }
               else if (command is ShiftDataCommand)
               {
                  ShiftDataCommand cmd = command as ShiftDataCommand;
                  cmd.DestinationBitsPerPixel = 8;
                  cmd.DestinationLowBit = 5;
                  cmd.SourceLowBit = 2;
                  cmd.SourceHighBit = 7;
                  runAfterImage = false;

               }
               else if (command is SelectDataCommand)
               {
                  SelectDataCommand cmd = command as SelectDataCommand;
                  cmd.SourceHighBit = _viewerBefore.Image.BitsPerPixel - 1;
                  cmd.SourceLowBit = 4;
                  cmd.Combine = true;
                  cmd.Color = new RasterColor(0, 0, 255);
                  cmd.Threshold = 4;
                  runAfterImage = false;
               }
               else if (command is AddMessageCommand)
               {
                  AddMessageCommand cmd = command as AddMessageCommand;
                  cmd.Message = DemosGlobalization.GetResxString(GetType(), "resx_cmdMessage");
               }
               else if (command is ExtractMessageCommand)
               {
                  AddMessageCommand addCommand = new AddMessageCommand();
                  addCommand.Message = DemosGlobalization.GetResxString(GetType(), "resx_cmdMessage");
                  if (_checkBoxProgress.Checked)
                     addCommand.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);

                  addCommand.Run(_viewerBefore.Image);
                  ExtractMessageCommand cmd = command as ExtractMessageCommand;
                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  cmd.Run(_viewerBefore.Image);
                  Messager.ShowInformation(this, string.Format("{0} = {1}", DemosGlobalization.GetResxString(GetType(), "resx_Message"), cmd.Message));
                  return;
               }
               else if (command is WaveCommand)
               {
                  WaveCommand cmd = command as WaveCommand;
                  cmd.Amplitude = _viewerBefore.Image.Width * 4 / 100;
                  cmd.Angle = 4500;
                  cmd.FillColor = new RasterColor(0, 0, 0);
                  cmd.Flags = WaveCommandFlags.Repeat | WaveCommandFlags.Repeat | WaveCommandFlags.Frequency | WaveCommandFlags.SinWave;
                  cmd.HorizontalFactor = 100;
                  cmd.VerticalFactor = 100;
                  cmd.WaveLength = 15;
               }
               else if (command is ZoomWaveCommand)
               {
                  ZoomWaveCommand cmd = command as ZoomWaveCommand;
                  cmd.Amplitude = 1;
                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else
                     cmd.CenterPoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  cmd.FillColor = new RasterColor(0, 0, 0);
                  cmd.Frequency = 25;
                  cmd.Phase = 0;
                  cmd.Type = ZoomWaveCommandType.Repeat;
                  cmd.ZoomFactor = 0;
               }
               else if (command is EdgeDetectEffectCommand)
               {
                  EdgeDetectEffectCommand cmd = command as EdgeDetectEffectCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     EdgeDetectEffectDialog EdgeDetectEffectDlg = new EdgeDetectEffectDialog();
                     if (EdgeDetectEffectDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Level = EdgeDetectEffectDlg.EdgeDetectEffectCommand.Level;
                        cmd.Threshold = EdgeDetectEffectDlg.EdgeDetectEffectCommand.Threshold;
                        cmd.Type = EdgeDetectEffectDlg.EdgeDetectEffectCommand.Type;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Level = 50;
                     cmd.Threshold = 0;
                     cmd.Type = EdgeDetectEffectCommandType.Smooth;
                  }
               }
               else if (command is GaussianCommand)
               {
                  GaussianCommand cmd = command as GaussianCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     GaussianDialog GaussianDlg = new GaussianDialog();
                     if (GaussianDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Radius = GaussianDlg.Radius;
                     }
                     else
                        return;
                  }
                  else
                     cmd.Radius = 5;
               }
               else if (command is UnsharpMaskCommand)
               {
                  UnsharpMaskCommand cmd = command as UnsharpMaskCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     UnsharpMaskDialog UnsharpMaskDlg = new UnsharpMaskDialog();
                     if (UnsharpMaskDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Amount = UnsharpMaskDlg.UnsharpMaskCommand.Amount;
                        cmd.ColorType = UnsharpMaskDlg.UnsharpMaskCommand.ColorType;
                        cmd.Radius = UnsharpMaskDlg.UnsharpMaskCommand.Radius;
                        cmd.Threshold = UnsharpMaskDlg.UnsharpMaskCommand.Threshold;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Amount = 100;
                     cmd.ColorType = UnsharpMaskCommandColorType.Rgb;
                     cmd.Radius = 20;
                     cmd.Threshold = 0;
                  }
               }
               else if (command is FeatherAlphaBlendCommand)
               {
                  FeatherAlphaBlendCommand cmd = command as FeatherAlphaBlendCommand;
                  RasterImage MaskImage = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__FadeMask_bmp));

                  if (_checkBoxOptionsDialog.Checked)
                  {
                     FeatherAlphaBlendDialog FeatherAlphaBlendDlg = new FeatherAlphaBlendDialog(_viewerAfter.Image, MaskImage);
                     if (FeatherAlphaBlendDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.DestinationRectangle = FeatherAlphaBlendDlg.FeatherAlphaBlendCommand.DestinationRectangle;
                        cmd.SourcePoint = FeatherAlphaBlendDlg.FeatherAlphaBlendCommand.SourcePoint;
                        cmd.MaskSourcePoint = FeatherAlphaBlendDlg.FeatherAlphaBlendCommand.MaskSourcePoint;
                        cmd.MaskImage = MaskImage;
                        cmd.SourceImage = _viewerAfter.Image;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.DestinationRectangle = new LeadRect(0, 0, _viewerAfter.Image.Width / 2, _viewerAfter.Image.Height / 2);
                     cmd.MaskImage = MaskImage;
                     cmd.SourceImage = _viewerAfter.Image;
                     cmd.SourcePoint = new LeadPoint(_viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  }
               }
               else if (command is AlphaBlendCommand)
               {
                  AlphaBlendCommand cmd = command as AlphaBlendCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     AlphaBlendDialog AlphaBlendDlg = new AlphaBlendDialog(_viewerBefore.Image);
                     if (AlphaBlendDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.DestinationRectangle = AlphaBlendDlg.AlphaBlendCommand.DestinationRectangle;
                        cmd.Opacity = AlphaBlendDlg.AlphaBlendCommand.Opacity;
                        cmd.SourceImage = _viewerBefore.Image;
                        cmd.SourcePoint = AlphaBlendDlg.AlphaBlendCommand.SourcePoint;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.DestinationRectangle = new LeadRect(_viewerAfter.Image.Width / 2 - _viewerBefore.Image.Width / 2, _viewerAfter.Image.Height / 2 - _viewerBefore.Image.Height / 2, _viewerAfter.Image.Width / 2 + _viewerBefore.Image.Width / 8, _viewerAfter.Image.Height / 2 + _viewerBefore.Image.Height / 8);
                     cmd.Opacity = 128;
                     cmd.SourceImage = _viewerBefore.Image;
                     cmd.SourcePoint = new LeadPoint(0, 0);
                  }
               }
               else if (command is CombineCommand)
               {
                  CombineCommand cmd = command as CombineCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     CombineDialog CombineDlg = new CombineDialog(_viewerAfter.Image);
                     if (CombineDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.SourceImage = _viewerAfter.Image;
                        cmd.DestinationRectangle = CombineDlg.CombineCommand.DestinationRectangle;
                        cmd.SourcePoint = CombineDlg.CombineCommand.SourcePoint;
                        cmd.Flags = CombineDlg.CombineCommand.Flags;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.SourceImage = _viewerAfter.Image;
                     cmd.DestinationRectangle = new LeadRect(_viewerAfter.Image.Width / 8, _viewerAfter.Image.Height / 8, _viewerAfter.Image.Width - _viewerAfter.Image.Width / 8, _viewerAfter.Image.Height - _viewerAfter.Image.Height / 8);
                     cmd.SourcePoint = new LeadPoint(0, 0);
                     cmd.Flags = CombineCommandFlags.OperationAdd |
                        CombineCommandFlags.Destination0 |
                        CombineCommandFlags.SourceRed |
                        CombineCommandFlags.DestinationGreen |
                        CombineCommandFlags.ResultBlue;
                  }
               }
               else if (command is AntiAliasingCommand)
               {
                  AntiAliasingCommand cmd = command as AntiAliasingCommand;
                  AntiAliasingDialog AntiAliasingDlg = new AntiAliasingDialog();
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     if (AntiAliasingDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Dimension = AntiAliasingDlg.AntiAliasingCommand.Dimension;
                        cmd.Filter = AntiAliasingDlg.AntiAliasingCommand.Filter;
                        cmd.Threshold = AntiAliasingDlg.AntiAliasingCommand.Threshold;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Dimension = 9;
                     cmd.Filter = AntiAliasingCommandType.Type1;
                     cmd.Threshold = 0;
                  }
               }
               else if (command is BalanceColorsCommand)
               {
                  BalanceColorsCommand cmd = command as BalanceColorsCommand;
                  cmd.BlueFactor = new BalanceColorCommandFactor(1.0, 0.5, 0.7);
                  cmd.GreenFactor = new BalanceColorCommandFactor(0.8, 0.3, 0.7);
                  cmd.RedFactor = new BalanceColorCommandFactor(0.5, 0.4, 0.7);
               }
               else if (command is EdgeDetectorCommand)
               {
                  EdgeDetectorCommand cmd = command as EdgeDetectorCommand;
                  EdgeDetectorDialog EdgeDetectorDlg = new EdgeDetectorDialog();

                  if (_checkBoxOptionsDialog.Checked)
                  {
                     if (EdgeDetectorDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Filter = EdgeDetectorDlg.EdgeDetectorCommand.Filter;
                        cmd.Threshold = EdgeDetectorDlg.EdgeDetectorCommand.Threshold;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Filter = EdgeDetectorCommandType.SobelHorizontal;
                     cmd.Threshold = 60;
                  }
               }
               else if (command is MotionBlurCommand)
               {
                  MotionBlurCommand cmd = command as MotionBlurCommand;
                  cmd.Angle = 4500;
                  cmd.Dimension = 50;
                  cmd.UniDirection = true;
               }
               else if (command is HalfToneCommand)
               {
                  HalfToneCommand cmd = command as HalfToneCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     HalfToneDialog HalfToneDlg = new HalfToneDialog();
                     RasterImage[] images = new RasterImage[2];
                     if (HalfToneDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Type = HalfToneDlg.HalfToneCommand.Type;
                        cmd.Angle = HalfToneDlg.HalfToneCommand.Angle;
                        cmd.Dimension = HalfToneDlg.HalfToneCommand.Dimension;
                        if (HalfToneDlg.UserDefined)
                        {
                           images[0] = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__Image1_jpg));
                           images[1] = images[0];
                           images[0].AddPage(images[1]);
                           cmd.UserDefinedImage = images[0];
                        }
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Type = HalfToneCommandType.Print;
                     cmd.Angle = 0;
                     cmd.Dimension = 0;
                  }
               }
               else if (command is TextureAlphaBlendCommand)
               {
                  TextureAlphaBlendCommand cmd = command as TextureAlphaBlendCommand;
                  cmd.MaskImage = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__FadeMask_bmp));
                  cmd.DestinationRectangle = new LeadRect(_viewerAfter.Image.Width / 2 - cmd.MaskImage.Width / 2, _viewerAfter.Image.Height / 2 - cmd.MaskImage.Height / 2, cmd.MaskImage.Width, cmd.MaskImage.Height);
                  cmd.Opacity = 128;
                  cmd.SourceImage = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__Image1_jpg));
                  cmd.SourcePoint = new LeadPoint(0, 0);
                  cmd.UnderlayImage = _viewerAfter.Image;
                  cmd.UnderlayOffset = new LeadPoint(0, 0);
               }
               else if (command is AddWeightedCommand)
               {
                  AddWeightedCommand cmd = command as AddWeightedCommand;
                  cmd.Type = AddWeightedCommandType.Average;
                  cmd.Factor = new int[4];
                  cmd.Factor[0] = 50;
                  cmd.Factor[1] = 70;
                  cmd.Factor[2] = 80;
                  cmd.Factor[3] = 90;
               }
               else if (command is FastFourierTransformCommand)
               {
                  if (command is FrequencyFilterMask)
                  {
                     // Resize the image to make sure the image's dimensions are power of two.
                     SizeCommand sizecommand = new SizeCommand(256, 256, RasterSizeFlags.Bicubic);
                     sizecommand.Run(_viewerAfter.Image);

                     FourierTransformInformation ftArray = new FourierTransformInformation(_viewerAfter.Image);
                     // Apply FFT.
                     FastFourierTransformCommand ftCommand = new FastFourierTransformCommand(ftArray, FastFourierTransformCommandFlags.FastFourierTransform | FastFourierTransformCommandFlags.Gray);
                     if (_checkBoxProgress.Checked)
                        ftCommand.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                     ftCommand.Run(_viewerAfter.Image);

                     FrequencyFilterMaskCommand freqCommand = new FrequencyFilterMaskCommand(_codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__FreqFilterMask_jpg)), ftArray, false);
                     freqCommand.Run();

                     ftCommand.Flags = FastFourierTransformCommandFlags.InverseFastFourierTransform | FastFourierTransformCommandFlags.Gray | FastFourierTransformCommandFlags.Scale | FastFourierTransformCommandFlags.Both;
                     ftCommand.Run(_viewerAfter.Image);
                     return;
                  }
                  else
                  {
                     // Resize the image to make sure the image's dimensions are power of two.
                     SizeCommand sizecommand = new SizeCommand(256, 256, RasterSizeFlags.Bicubic);
                     sizecommand.Run(_viewerAfter.Image);

                     FourierTransformInformation ftArray = new FourierTransformInformation(_viewerAfter.Image);
                     // Apply FFT.
                     FastFourierTransformCommand ftCommand;

                     if (_checkBoxOptionsDialog.Checked)
                     {
                        FastFourierTransformDialog Dlg = new FastFourierTransformDialog();
                        if (Dlg.ShowDialog(this) == DialogResult.OK)
                        {
                           ftCommand = new FastFourierTransformCommand(ftArray, Dlg.FastFourierTransformCommand.Flags);
                           if (_checkBoxProgress.Checked)
                              ftCommand.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                           ftCommand.Run(_viewerAfter.Image);

                           LeadRect rc = new LeadRect(0, 0, _viewerAfter.Image.Width / 2, _viewerAfter.Image.Height / 2);
                           FrequencyFilterCommand freqCommand = new FrequencyFilterCommand(ftArray, rc, Dlg.FrequencyFilterCommand.Flags);
                           freqCommand.Run();

                           ftCommand.Flags = FastFourierTransformCommandFlags.InverseFastFourierTransform | FastFourierTransformCommandFlags.Gray | FastFourierTransformCommandFlags.Scale | FastFourierTransformCommandFlags.Both;
                           ftCommand.Run(_viewerAfter.Image);
                        }
                        else
                           return;
                     }
                     else
                     {
                        ftCommand = new FastFourierTransformCommand(ftArray, FastFourierTransformCommandFlags.FastFourierTransform | FastFourierTransformCommandFlags.Gray);
                        if (_checkBoxProgress.Checked)
                           ftCommand.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);

                        ftCommand.Run(_viewerAfter.Image);

                        LeadRect rc = new LeadRect(0, 0, _viewerAfter.Image.Width / 2, _viewerAfter.Image.Height / 2);
                        FrequencyFilterCommand freqCommand = new FrequencyFilterCommand(ftArray, rc, FrequencyFilterCommandFlags.OutsideX | FrequencyFilterCommandFlags.OutsideY);
                        freqCommand.Run();

                        ftCommand.Flags = FastFourierTransformCommandFlags.InverseFastFourierTransform | FastFourierTransformCommandFlags.Gray | FastFourierTransformCommandFlags.Scale | FastFourierTransformCommandFlags.Both;
                        ftCommand.Run(_viewerAfter.Image);
                     }
                     return;
                  }
               }
               else if (command is DiscreteFourierTransformCommand)
               {
                  DiscreteFourierTransformCommand cmd = command as DiscreteFourierTransformCommand;
                  FourierTransformInformation ft = new FourierTransformInformation(_viewerAfter.Image);
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     DiscreteFourierTransformDialog Dlg = new DiscreteFourierTransformDialog(_viewerAfter.Image);
                     if (Dlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.FourierTransformInformation = ft;
                        cmd.Range = Dlg.DiscreteFourierTransformCommand.Range;
                        cmd.Flags = Dlg.DiscreteFourierTransformCommand.Flags;

                        if (_checkBoxProgress.Checked)
                           cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                        cmd.Run(_viewerAfter.Image);

                        FourierTransformDisplayCommand disCommand = new FourierTransformDisplayCommand();
                        disCommand.Flags = Dlg.FourierTransformDisplayCommand.Flags;
                        disCommand.FourierTransformInformation = cmd.FourierTransformInformation;
                        // plot frequency magnitude
                        if (_checkBoxProgress.Checked)
                           disCommand.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                        disCommand.Run(_viewerAfter.Image);
                        return;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.FourierTransformInformation = ft;
                     LeadRect rect = new LeadRect(0, 0, _viewerAfter.Image.Width - 1, _viewerAfter.Image.Height - 1);
                     cmd.Range = rect;
                     cmd.Flags = DiscreteFourierTransformCommandFlags.DiscreteFourierTransform |
                        DiscreteFourierTransformCommandFlags.Gray |
                        DiscreteFourierTransformCommandFlags.Range |
                        DiscreteFourierTransformCommandFlags.InsideX |
                        DiscreteFourierTransformCommandFlags.InsideY;

                     if (_checkBoxProgress.Checked)
                        cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                     cmd.Run(_viewerAfter.Image);

                     FourierTransformDisplayCommand disCommand = new FourierTransformDisplayCommand();
                     disCommand.Flags = FourierTransformDisplayCommandFlags.Log | FourierTransformDisplayCommandFlags.Magnitude;
                     disCommand.FourierTransformInformation = cmd.FourierTransformInformation;
                     // plot frequency magnitude
                     if (_checkBoxProgress.Checked)
                        disCommand.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                     disCommand.Run(_viewerAfter.Image);
                  }

               }
               else if (command is FrequencyFilterMaskCommand)
               {
                  // Resize the image to make sure the image's dimensions are power of two.
                  SizeCommand sizecommand = new SizeCommand(256, 256, RasterSizeFlags.Bicubic);
                  sizecommand.Run(_viewerBefore.Image);

                  FourierTransformInformation ftArray = new FourierTransformInformation(_viewerBefore.Image);
                  // Apply FFT.
                  FastFourierTransformCommand ftCommand = new FastFourierTransformCommand(ftArray, FastFourierTransformCommandFlags.FastFourierTransform | FastFourierTransformCommandFlags.Gray);
                  if (_checkBoxProgress.Checked)
                     ftCommand.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);

                  ftCommand.Run(_viewerBefore.Image);

                  LeadRect rc = new LeadRect(0, 0, _viewerBefore.Image.Width / 2, _viewerBefore.Image.Height / 2);
                  FrequencyFilterMaskCommand freqCommand = new FrequencyFilterMaskCommand(_viewerBefore.Image, ftArray, false);
                  freqCommand.Run();

                  ftCommand.Flags = FastFourierTransformCommandFlags.InverseFastFourierTransform | FastFourierTransformCommandFlags.Gray | FastFourierTransformCommandFlags.Scale | FastFourierTransformCommandFlags.Both;
                  ftCommand.Run(_viewerBefore.Image);
                  return;

               }
               else if (command is SkeletonCommand)
               {
                  SkeletonCommand cmd = command as SkeletonCommand;
                  cmd.Threshold = 128;
               }
               else if (command is CorrelationListCommand)
               {
                  if (_viewerAfter.Image.HasRegion)
                     _viewerAfter.Image.MakeRegionEmpty();

                  CorrelationListCommand cmd = command as CorrelationListCommand;
                  CopyRectangleCommand copyRectangle = new CopyRectangleCommand();

                  LeadRect rc_cor = new LeadRect(327, 378, 22, 28);
                  copyRectangle.Rectangle = rc_cor;
                  copyRectangle.Run(_viewerBefore.Image);
                  cmd.CorrelationImage = copyRectangle.DestinationImage.Clone();

                  rc_cor = new LeadRect(283, 378, 22, 28);
                  copyRectangle.Rectangle = rc_cor;
                  copyRectangle.Run(_viewerBefore.Image);
                  cmd.CorrelationImage.AddPage(copyRectangle.DestinationImage.Clone());

                  cmd.Points = new LeadPoint[30];
                  cmd.ListIndex = new int[30];
                  cmd.Threshold = 90;
                  cmd.XStep = 1;
                  cmd.YStep = 1;
                  runAfterImage = false;
                  cmd.Run(_viewerAfter.Image);

                  for (int i_cor = 0; i_cor < cmd.NumberOfPoints; i_cor++)
                  {
                     rc_cor = new LeadRect(cmd.Points[i_cor].X, cmd.Points[i_cor].Y, 22, 28);
                     if (i_cor == 0)
                        _viewerAfter.Image.AddRectangleToRegion(null, rc_cor, RasterRegionCombineMode.Set);
                     else
                        _viewerAfter.Image.AddRectangleToRegion(null, rc_cor, RasterRegionCombineMode.Or);
                  }
                  return;
               }
               else if (command is CorrelationCommand)
               {
                  if (_viewerAfter.Image.HasRegion)
                     _viewerAfter.Image.MakeRegionEmpty();

                  LeadRect rc_cor = new LeadRect(327, 378, 22, 28);
                  CorrelationCommand cmd = command as CorrelationCommand;
                  cmd.CorrelationImage = _viewerBefore.Image.Clone();
                  cmd.CorrelationImage.AddRectangleToRegion(null, rc_cor, RasterRegionCombineMode.Set);
                  cmd.Points = new LeadPoint[10];
                  cmd.Threshold = 80;
                  cmd.XStep = 2;
                  cmd.YStep = 2;
                  runAfterImage = false;
                  cmd.Run(_viewerAfter.Image);

                  for (int i_cor = 0; i_cor < cmd.NumberOfPoints; i_cor++)
                  {
                     rc_cor = new LeadRect(cmd.Points[i_cor].X, cmd.Points[i_cor].Y, 22, 28);
                     if (i_cor == 0)
                        _viewerAfter.Image.AddRectangleToRegion(null, rc_cor, RasterRegionCombineMode.Set);
                     else
                        _viewerAfter.Image.AddRectangleToRegion(null, rc_cor, RasterRegionCombineMode.Or);
                  }
                  return;
               }
               else if (command is ObjectInformationCommand)
               {
                  ObjectInformationCommand cmd = command as ObjectInformationCommand;
                  cmd.Weighted = false;
                  runAfterImage = false;
               }
               else if (command is UserFilterCommand)
               {
                  UserFilterCommand cmd = command as UserFilterCommand;
                  cmd.CenterPoint = new LeadPoint(1, 1);
                  cmd.Divisor = 1;
                  cmd.FilterHeight = 3;
                  cmd.FilterWidth = 3;
                  cmd.Matrix = new int[] { 0, -1, 0, -1, 5, -1, 0, -1, 0 };
                  cmd.Offset = 0;
                  cmd.Type = UserFilterCommandType.Sum;
               }
               else if (command is DirectionEdgeStatisticalCommand)
               {
                  DirectionEdgeStatisticalCommand cmd = command as DirectionEdgeStatisticalCommand;
                  cmd.Angle = 4500;
                  cmd.BackGroundColor = new RasterColor(0, 0, 0);
                  cmd.Dimension = 3;
                  cmd.EdgeColor = new RasterColor(255, 255, 255);
                  cmd.Threshold = 35;
               }
               else if (command is RevEffectCommand)
               {
                  RevEffectCommand cmd = command as RevEffectCommand;
                  cmd.LineSpace = 3;
                  cmd.MaximumHeight = 37;
               }
               else if (command is ShadowCommand)
               {
                  ShadowCommand cmd = command as ShadowCommand;
                  cmd.Angle = ShadowCommandAngle.NorthWest;
                  cmd.Threshold = 0;
                  cmd.Type = ShadowCommandType.GrayShadow;
               }
               else if (command is SubtractBackgroundCommand)
               {
                  SubtractBackgroundCommand cmd = command as SubtractBackgroundCommand;
                  cmd.BrightnessFactor = 150;
                  cmd.Flags = SubtractBackgroundCommandFlags.BackgroundIsDarker | SubtractBackgroundCommandFlags.SubtractedImage;
                  cmd.RollingBall = 100;
                  cmd.ShrinkingSize = SubtractBackgroundCommandType.DependOnRollingBallSize;

                  cmd.Run(_viewerAfter.Image);
                  return;

               }
               else if (command is AgingCommand)
               {
                  if (command is PerimeterLength)
                  {
                     if (_viewerBefore.Image.HasRegion)
                        Messager.ShowInformation(this, DemosGlobalization.GetResxString(GetType(), "resx_MessagerPerimeterLength") + string.Format(" = {0}", EffectsUtilities.GetRegionPerimeterLength(_viewerBefore.Image, null)));
                     else
                        Messager.ShowInformation(this, DemosGlobalization.GetResxString(GetType(), "resx_MessagerImageMustHaveRegion"));
                     return;
                  }
                  else if (command is IsRegistrationMark)
                  {
                     Messager.ShowInformation(this, DemosGlobalization.GetResxString(GetType(), "resx_MessagerIsRegistrationMark") + string.Format(" = {0}", CoreUtilities.IsRegistrationMark(_viewerBefore.Image, RegistrationMarkCommandType.TShape, 90, 110, 31, 29)));
                     return;
                  }

                  AgingCommand cmd = command as AgingCommand;
                  cmd.DustColor = new RasterColor(0, 0, 0);
                  cmd.DustDensity = 10;
                  cmd.Flags = AgingCommandFlags.AddDust | AgingCommandFlags.ScratchColor | AgingCommandFlags.DustColor | AgingCommandFlags.PitsInverse;
                  cmd.HorizontalScratchCount = 10;
                  cmd.MaximumPitSize = 15;
                  cmd.MaximumScratchLength = _viewerBefore.Image.Width / 3;
                  cmd.PitsColor = new RasterColor(0, 0, 0);
                  cmd.PitsDensity = 10;
                  cmd.ScratchColor = new RasterColor(255, 255, 255);
                  cmd.VerticalScratchCount = 15;
               }
               else if (command is AdaptiveContrastCommand)
               {
                  AdaptiveContrastCommand cmd = command as AdaptiveContrastCommand;
                  cmd.Amount = 255;
                  cmd.Dimension = 9;
                  cmd.Type = AdaptiveContrastCommandType.Linear;
               }
               else if (command is ChangeIntensityCommand)
               {
                  ChangeIntensityCommand cmd = command as ChangeIntensityCommand;
                  ChangeIntensityDialog dlg = new ChangeIntensityDialog();
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     dlg.Value = 250;
                     dlg.Text = DemosGlobalization.GetResxString(GetType(), "resx_ChangeIntensity");
                     dlg._lblBrightness.Text = DemosGlobalization.GetResxString(GetType(), "resx_Brightness");
                     dlg._tbBrightness.Minimum = -1000;
                     dlg._tbBrightness.Maximum = 1000;

                     if (dlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Brightness = dlg.Value;
                     else
                        return;
                  }
                  else
                     cmd.Brightness = 250;

               }
               else if (command is ChangeContrastCommand)
               {
                  ChangeContrastCommand cmd = command as ChangeContrastCommand;
                  ChangeIntensityDialog dlg = new ChangeIntensityDialog();
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     dlg.Value = 250;
                     dlg.Text = DemosGlobalization.GetResxString(GetType(), "resx_ChangeContrast");
                     dlg._lblBrightness.Text = DemosGlobalization.GetResxString(GetType(), "resx_Contrast");
                     dlg._tbBrightness.Minimum = -1000;
                     dlg._tbBrightness.Maximum = 1000;


                     if (dlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Contrast = dlg.Value;
                     else
                        return;
                  }
                  else
                     cmd.Contrast = 250;
               }
               else if (command is ChangeHueCommand)
               {
                  ChangeHueCommand cmd = command as ChangeHueCommand;
                  ChangeIntensityDialog dlg = new ChangeIntensityDialog();
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     dlg.Value = 180;
                     dlg.Text = DemosGlobalization.GetResxString(GetType(), "resx_ChangeHue");
                     dlg._lblBrightness.Text = DemosGlobalization.GetResxString(GetType(), "resx_Angle");
                     dlg._tbBrightness.Minimum = -360;
                     dlg._tbBrightness.Maximum = 360;

                     if (dlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Angle = dlg.Value;
                     else
                        return;
                  }
                  else
                     cmd.Angle = 180;
               }
               else if (command is SmoothCommand)
               {
                  _allowEventDuringProcess = false;
                  SmoothCommand cmd = command as SmoothCommand;
                  cmd.Flags = 0;
                  cmd.Length = 10;
                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);

                  cmd.Run(_viewerAfter.Image);
                  return;
               }
               else if (command is LineRemoveCommand)
               {
                  _allowEventDuringProcess = false;
                  LineRemoveCommand cmd = command as LineRemoveCommand;
                  cmd.Type = LineRemoveCommandType.Horizontal;
                  cmd.Flags = LineRemoveCommandFlags.UseGap;
                  cmd.GapLength = 2;
                  cmd.MaximumLineWidth = 5;
                  cmd.MinimumLineLength = 200;
                  cmd.MaximumWallPercent = 10;
                  cmd.Wall = 7;
                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  cmd.Run(_viewerAfter.Image);
                  return;
               }
               else if (command is BorderRemoveCommand)
               {
                  _allowEventDuringProcess = false;
                  BorderRemoveCommand cmd = command as BorderRemoveCommand;
                  cmd.Border = BorderRemoveBorderFlags.All;
                  cmd.Flags = BorderRemoveCommandFlags.UseVariance;
                  cmd.Percent = 20;
                  cmd.Variance = 2;
                  cmd.WhiteNoiseLength = 5;
                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  cmd.Run(_viewerAfter.Image);
                  return;
               }
               else if (command is InvertedTextCommand)
               {
                  _allowEventDuringProcess = false;
                  InvertedTextCommand cmd = command as InvertedTextCommand;
                  cmd.Flags = 0;
                  cmd.MaximumBlackPercent = 95;
                  cmd.MinimumBlackPercent = 75;
                  cmd.MinimumInvertHeight = 65;
                  cmd.MinimumInvertWidth = 900;
                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  cmd.Run(_viewerAfter.Image);
                  return;
               }
               else if (command is DotRemoveCommand)
               {
                  _allowEventDuringProcess = false;
                  DotRemoveCommand cmd = command as DotRemoveCommand;
                  cmd.Flags = DotRemoveCommandFlags.UseSize;
                  cmd.MaximumDotHeight = 8;
                  cmd.MaximumDotWidth = 8;
                  cmd.MinimumDotHeight = 6;
                  cmd.MinimumDotWidth = 6;
                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  cmd.Run(_viewerAfter.Image);
                  return;
               }
               else if (command is HolePunchRemoveCommand)
               {
                  _allowEventDuringProcess = false;
                  HolePunchRemoveCommand cmd = command as HolePunchRemoveCommand;
                  cmd.Flags = HolePunchRemoveCommandFlags.UseLocation;
                  cmd.Location = HolePunchRemoveCommandLocation.Left;
                  cmd.MaximumHoleCount = 4;
                  cmd.MinimumHoleCount = 2;
                  cmd.MaximumHoleWidth = 1500;
                  cmd.MaximumHoleHeight = 1500;
                  cmd.MinimumHoleHeight = 100;
                  cmd.MinimumHoleWidth = 100;
                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);

                  cmd.Run(_viewerAfter.Image);
                  return;
               }
               else if (command is ChangeSaturationCommand)
               {
                  ChangeSaturationCommand cmd = command as ChangeSaturationCommand;
                  ChangeIntensityDialog dlg = new ChangeIntensityDialog();
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     dlg.Value = 250;
                     dlg.Text = DemosGlobalization.GetResxString(GetType(), "resx_ChangeSaturation");
                     dlg._lblBrightness.Text = DemosGlobalization.GetResxString(GetType(), "resx_Change");
                     dlg._tbBrightness.Minimum = -1000;
                     dlg._tbBrightness.Maximum = 1000;

                     if (dlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Change = dlg.Value;
                     else
                        return;
                  }
                  else
                     cmd.Change = 250;
               }
               else if (command is GammaCorrectCommand)
               {
                  GammaCorrectCommand cmd = command as GammaCorrectCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     GammaCorrectDialog GammaCorrectDlg = new GammaCorrectDialog();
                     if (GammaCorrectDlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Gamma = GammaCorrectDlg.GammaCorrectCommand.Gamma;
                     else
                        return;
                  }
                  else
                     cmd.Gamma = 250;
               }
               else if (command is HistogramContrastCommand)
               {
                  HistogramContrastCommand cmd = command as HistogramContrastCommand;
                  ChangeIntensityDialog dlg = new ChangeIntensityDialog();
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     dlg.Value = 750;
                     dlg.Text = DemosGlobalization.GetResxString(GetType(), "resx_HistogramContrast");
                     dlg._lblBrightness.Text = DemosGlobalization.GetResxString(GetType(), "resx_Contrast");
                     dlg._tbBrightness.Minimum = -1000;
                     dlg._tbBrightness.Maximum = 1000;

                     if (dlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Contrast = dlg.Value;
                     else
                        return;
                  }
                  else
                     cmd.Contrast = 750;
               }
               else if (command is HistogramEqualizeCommand)
               {
                  HistogramEqualizeCommand cmd = command as HistogramEqualizeCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     HistogramEqualizeDialog HistogramEqualizeDlg = new HistogramEqualizeDialog();
                     if (HistogramEqualizeDlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Type = HistogramEqualizeDlg.HistogramEqualizeCommand.Type;
                     else
                        return;
                  }
                  else
                     cmd.Type = HistogramEqualizeType.Yuv;
               }
               else if (command is IntensityDetectCommand)
               {
                  IntensityDetectCommand cmd = command as IntensityDetectCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     IntensityDetectDialog IntensityDetectdlg = new IntensityDetectDialog();
                     if (IntensityDetectdlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Channel = IntensityDetectdlg.Channel;
                        cmd.HighThreshold = IntensityDetectdlg.High;
                        cmd.InColor = IntensityDetectdlg.InColor;
                        cmd.LowThreshold = IntensityDetectdlg.Low;
                        cmd.OutColor = IntensityDetectdlg.OutColor;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Channel = IntensityDetectCommandFlags.Master;
                     cmd.HighThreshold = 255;
                     cmd.InColor = new RasterColor(255, 255, 255);
                     cmd.LowThreshold = 128;
                     cmd.OutColor = new RasterColor(0, 0, 0);
                  }
               }
               else if (command is PosterizeCommand)
               {
                  PosterizeCommand cmd = command as PosterizeCommand;
                  cmd.Levels = 6;
               }
               else if (command is RemapIntensityCommand)
               {
                  RemapIntensityCommand cmd = command as RemapIntensityCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     RemapIntensityDialog Dlg = new RemapIntensityDialog();
                     if (Dlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Flags = Dlg.RemapIntensityCommand.Flags;
                        cmd.LookupTable = Dlg.RemapIntensityCommand.LookupTable;
                     }
                     else
                        return;
                  }
                  else
                  {
                     int[] lut = new int[256];
                     lut[0] = 255;
                     lut[255] = 0;
                     EffectsUtilities.GetFunctionalLookupTable(lut, 0, 255, 0, FunctionalLookupTableFlags.Linear);

                     cmd.Flags = RemapIntensityCommandFlags.Master;
                     cmd.LookupTable = lut;
                  }
               }
               else if (command is MinMaxBitsCommand)
               {
                  MinMaxBitsCommand cmd = command as MinMaxBitsCommand;
                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  cmd.Run(_viewerBefore.Image);
                  Messager.ShowInformation(this, DemosGlobalization.GetResxString(GetType(), "resx_MessagerMinimumBit") + string.Format(" = {0}{1}", cmd.MinimumBit, Environment.NewLine) + DemosGlobalization.GetResxString(GetType(), "resx_MessagerMaximumBit") + string.Format(" = {0}", cmd.MaximumBit));
                  return;
               }
               else if (command is MinMaxValuesCommand)
               {
                  MinMaxValuesCommand cmd = command as MinMaxValuesCommand;
                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  cmd.Run(_viewerBefore.Image);
                  Messager.ShowInformation(this, DemosGlobalization.GetResxString(GetType(), "resx_MessagerMinimumValue") + string.Format(" = {0}{1}", cmd.MinimumValue, Environment.NewLine) + DemosGlobalization.GetResxString(GetType(), "resx_MessagerMaximumValue") + string.Format(" = {0}", cmd.MaximumValue));
                  return;
               }
               else if (command is ApplyTransformationParametersCommand)
               {
                  _viewerAfter.Image = _viewerBefore.Image.Clone();
                  if (_viewerAfter.Image.HasRegion)
                     _viewerAfter.Image.MakeRegionEmpty();
                  if (_viewerBefore.Image.HasRegion)
                     _viewerBefore.Image.MakeRegionEmpty();
                  SearchRegistrationMarksCommandData[] rmData = new SearchRegistrationMarksCommandData[3];

                  //Mark1
                  rmData[0] = new SearchRegistrationMarksCommandData();
                  rmData[0].Rectangle = new LeadRect(680, 20, 941 - 680, 218 - 20);
                  rmData[0].MarkDetectedPoints = new LeadPoint[1];
                  rmData[0].Width = 31;
                  rmData[0].Height = 29;
                  rmData[0].Type = RegistrationMarkCommandType.TShape;
                  rmData[0].MinimumScale = 90;
                  rmData[0].MaximumScale = 110;
                  rmData[0].SearchMarkCount = 1;

                  //Mark2
                  rmData[1] = new SearchRegistrationMarksCommandData();
                  rmData[1].Rectangle = new LeadRect(665, 790, 899 - 665, 961 - 790);
                  rmData[1].MarkDetectedPoints = new LeadPoint[1];
                  rmData[1].Width = 31;
                  rmData[1].Height = 29;
                  rmData[1].Type = RegistrationMarkCommandType.TShape;
                  rmData[1].MinimumScale = 90;
                  rmData[1].MaximumScale = 110;
                  rmData[1].SearchMarkCount = 1;

                  //Mark3
                  rmData[2] = new SearchRegistrationMarksCommandData();
                  rmData[2].Rectangle = new LeadRect(7, 1073, 298 - 7, 1246 - 1073);
                  rmData[2].MarkDetectedPoints = new LeadPoint[1];
                  rmData[2].Width = 31;
                  rmData[2].Height = 29;
                  rmData[2].Type = RegistrationMarkCommandType.TShape;
                  rmData[2].MinimumScale = 90;
                  rmData[2].MaximumScale = 110;
                  rmData[2].SearchMarkCount = 1;
                  SearchRegistrationMarksCommand command1 = new SearchRegistrationMarksCommand(rmData);
                  command1.Run(_viewerBefore.Image);
                  if ((rmData[2].MarkDetectedCount != 1) || (rmData[1].MarkDetectedCount != 1) || (rmData[0].MarkDetectedCount != 1))
                     return;

                  LeadPoint[] original =
               {
                  new LeadPoint(81400, 11300),
                  new LeadPoint(78600, 87400),
                  new LeadPoint(14300, 115400)
               };

                  LeadPoint[] detected =
               {
                  rmData[0].MarkDetectedPoints[0],
                  rmData[1].MarkDetectedPoints[0],
                  rmData[2].MarkDetectedPoints[0]
               };

                  //Find center of mass for detected registration marks in the transformed image
                  LeadPoint[] transformed = CoreUtilities.GetRegistrationMarksCenterMass(_viewerBefore.Image, detected);
                  //Find transformation parameters
                  TransformationParameters parameters = CoreUtilities.GetTransformationParameters(_viewerBefore.Image, original, transformed);
                  //Apply transformatin parameters to correct the image
                  ApplyTransformationParametersCommand applyCommand = new ApplyTransformationParametersCommand(parameters.XTranslation, parameters.YTranslation, parameters.Angle, parameters.XScale, parameters.YScale, ApplyTransformationParametersCommandFlags.Normal);
                  if (_checkBoxProgress.Checked)
                     applyCommand.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  applyCommand.Run(_viewerAfter.Image);
                  return;
               }
               else if (command is SolarizeCommand)
               {
                  SolarizeCommand cmd = command as SolarizeCommand;
                  cmd.Threshold = 90;
               }
               else if (command is GrayscaleCommand)
               {
                  GrayscaleCommand cmd = command as GrayscaleCommand;
                  GrayScaleDialog GrayScaleDlg = new GrayScaleDialog();

                  if (_checkBoxOptionsDialog.Checked)
                  {
                     if (GrayScaleDlg.ShowDialog(this) == DialogResult.OK)
                        cmd.BitsPerPixel = GrayScaleDlg.Grayscalecommand.BitsPerPixel;
                     else
                        return;
                  }
                  else
                  {
                     cmd.BitsPerPixel = 8;
                  }
               }
               else if (command is WindowLevelCommand)
               {
                  _viewerAfter.Image.Dispose();
                  _viewerAfter.Image = _viewerBefore.Image.Clone();
                  WindowLevelCommand cmd = command as WindowLevelCommand;
                  int lookupSize;
                  RasterColor[] lookupTable;

                  // Change the bitmap to 16-bit grayscale
                  GrayscaleCommand graycommand = new GrayscaleCommand(16);
                  graycommand.Run(_viewerBefore.Image);

                  MinMaxBitsCommand minMaxBits = new MinMaxBitsCommand();
                  MinMaxValuesCommand minMaxValues = new MinMaxValuesCommand();

                  minMaxBits.Run(_viewerBefore.Image);
                  minMaxValues.Run(_viewerBefore.Image);

                  lookupSize = (1 << (minMaxBits.MaximumBit - minMaxBits.MinimumBit + 1));
                  lookupTable = new RasterColor[lookupSize];

                  if (_viewerAfter.Image.HasRegion)
                  {
                     MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "resx_MessageBoxHasRegionError"), DemosGlobalization.GetResxString(GetType(), "resx_MessageBoxHasRegionErrorTitel"));
                     return;
                  }
                  else
                  {
                     if (_checkBoxOptionsDialog.Checked)
                     {
                        RasterWindowLevelDialog windowLevelDlg = new RasterWindowLevelDialog();
                        windowLevelDlg.Image = _viewerBefore.Image;
                        windowLevelDlg.ShowPreview = true;
                        windowLevelDlg.ShowRange = true;
                        windowLevelDlg.ShowZoomLevel = true;
                        windowLevelDlg.ZoomToFit = false;
                        windowLevelDlg.LowBit = minMaxBits.MinimumBit;
                        windowLevelDlg.HighBit = minMaxBits.MaximumBit;
                        windowLevelDlg.Low = minMaxValues.MinimumValue;
                        windowLevelDlg.High = minMaxValues.MaximumValue;
                        windowLevelDlg.WindowLevelFlags = RasterPaletteWindowLevelFlags.Inside | RasterPaletteWindowLevelFlags.Linear;
                        windowLevelDlg.LookupTable = lookupTable;
                        windowLevelDlg.StartColor = new RasterColor(0, 0, 0);
                        windowLevelDlg.EndColor = new RasterColor(255, 255, 255);

                        if (windowLevelDlg.ShowDialog(Owner) == DialogResult.OK)
                        {
                           RasterPalette.WindowLevelFillLookupTable(lookupTable,
                                                            windowLevelDlg.StartColor,
                                                            windowLevelDlg.EndColor,
                                                            windowLevelDlg.Low,
                                                            windowLevelDlg.High,
                                                            windowLevelDlg.LowBit,
                                                            windowLevelDlg.HighBit,
                                                            minMaxValues.MinimumValue,
                                                            minMaxValues.MaximumValue,
                                                            windowLevelDlg.Factor,
                                                            windowLevelDlg.WindowLevelFlags |
                                                            (windowLevelDlg.Signed ? 0 : RasterPaletteWindowLevelFlags.None));

                           cmd.LowBit = minMaxBits.MinimumBit;
                           cmd.HighBit = minMaxBits.MaximumBit;
                           cmd.LookupTable = lookupTable;
                           cmd.Order = RasterByteOrder.Bgr;
                        }
                        else
                           return;

                     }
                     else
                     {
                        int size = (1 << (minMaxBits.MaximumBit - minMaxBits.MinimumBit + 1));
                        RasterColor[] lut = new RasterColor[size];

                        for (int x = 0; x < size / 2; x++)
                           lut[x] = new RasterColor(255, 0, 0);

                        for (int x = size / 2; x < size; x++)
                        {
                           byte y = (byte)((x - minMaxValues.MinimumValue) * 255 / (minMaxValues.MaximumValue - minMaxValues.MinimumValue));
                           lut[x] = new RasterColor(y, y, y);
                        }
                        cmd.LowBit = minMaxBits.MinimumBit;
                        cmd.HighBit = minMaxBits.MaximumBit;
                        cmd.LookupTable = lut;
                        cmd.Order = RasterByteOrder.Bgr;
                     }
                  }
               }
               else if (command is LightControlCommand)
               {
                  LightControlCommand cmd = command as LightControlCommand;
                  cmd.Average = new int[] { 150, 140, 128 };
                  cmd.Type = LightControlCommandType.Yuv;
                  cmd.LowerAverage = new int[] { 100, 120, 80 };
                  cmd.UpperAverage = new int[] { 190, 200, 220 };
               }
               else if (command is SpatialFilterCommand)
               {
                  command = new SpatialFilterCommand(SpatialFilterCommandPredefined.EmbossEast);
               }
               else if (command is BinaryFilterCommand)
               {
                  command = new BinaryFilterCommand(BinaryFilterCommandPredefined.DilationOmniDirectional);
               }
               else if (command is ChannelMixerCommand)
               {
                  ChannelMixerCommand cmd = command as ChannelMixerCommand;
                  cmd.RedFactor = new ChannelMixerCommandFactor(150, 0, 0, 0);
                  cmd.GreenFactor = new ChannelMixerCommandFactor(0, 100, 0, 0);
                  cmd.BlueFactor = new ChannelMixerCommandFactor(0, 0, 100, 0);
               }
               else if (command is MultiscaleEnhancementCommand)
               {
                  MultiscaleEnhancementCommand cmd = command as MultiscaleEnhancementCommand;
                  cmd.Contrast = 1500;
                  cmd.EdgeCoefficient = -1;
                  cmd.EdgeLevels = -1;
                  cmd.Flags = MultiscaleEnhancementCommandFlags.EdgeEnhancement;
                  cmd.LatitudeCoefficient = -1;
                  cmd.LatitudeLevels = -1;
                  cmd.Type = MultiscaleEnhancementCommandType.Gaussian;
               }
               else if (command is ColorizeGrayCommand)
               {
                  ColorizeGrayCommand cmd = command as ColorizeGrayCommand;
                  ColorizeGrayCommandData[] grayColors = new ColorizeGrayCommandData[6];
                  for (int i = 0; i < 6; i++)
                     grayColors[i] = new ColorizeGrayCommandData();

                  grayColors[0].Threshold = 9999;
                  grayColors[1].Threshold = 19999;
                  grayColors[2].Threshold = 29999;
                  grayColors[3].Threshold = 39999;
                  grayColors[4].Threshold = 49999;
                  grayColors[5].Threshold = 59999; // This value will be ignored

                  grayColors[0].Color = new RasterColor(255, 0, 0);
                  grayColors[1].Color = new RasterColor(0, 255, 0);
                  grayColors[2].Color = new RasterColor(0, 0, 255);
                  grayColors[3].Color = new RasterColor(0, 255, 255);
                  grayColors[4].Color = new RasterColor(255, 0, 255);
                  grayColors[5].Color = new RasterColor(255, 255, 0);

                  cmd.GrayColors = grayColors;
                  runAfterImage = false;
               }
               else if (command is StatisticsInformationCommand)
               {
                  StatisticsInformationCommand cmd = command as StatisticsInformationCommand;
                  cmd.Channel = RasterColorChannel.Master;
                  cmd.Start = 0;
                  cmd.End = 255;
               }
               else if (command is DigitalSubtractCommand)
               {
                  DigitalSubtractCommand cmd = command as DigitalSubtractCommand;
                  cmd.MaskImage = _viewerBefore.Image;
                  cmd.Flags = DigitalSubtractCommandFlags.ContrastEnhancement | DigitalSubtractCommandFlags.OptimizeRange;
               }
               else if (command is ContrastBrightnessIntensityCommand)
               {
                  ContrastBrightnessIntensityCommand cmd = command as ContrastBrightnessIntensityCommand;
                  cmd.Contrast = -146;
                  cmd.Brightness = 385;
                  cmd.Intensity = 240;
               }
               else if (command is ApplyMathematicalLogicCommand)
               {
                  ApplyMathematicalLogicCommand cmd = command as ApplyMathematicalLogicCommand;
                  cmd.Factor = 151;
                  cmd.Flags = ApplyMathematicalLogicCommandFlags.OperationMultiply |
                     ApplyMathematicalLogicCommandFlags.Master |
                     ApplyMathematicalLogicCommandFlags.ValueDoNothing |
                     ApplyMathematicalLogicCommandFlags.ResultDoNothing;
               }
               else if (command is LocalHistogramEqualizeCommand)
               {
                  LocalHistogramEqualizeCommand cmd = command as LocalHistogramEqualizeCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     LocalHistogramEqualizeDialog LocalHistogramEqualizeDlg = new LocalHistogramEqualizeDialog(_viewerAfter.Image);
                     if (LocalHistogramEqualizeDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Height = LocalHistogramEqualizeDlg.LocalHistogramEqualizeCommand.Height;
                        cmd.HeightExtension = LocalHistogramEqualizeDlg.LocalHistogramEqualizeCommand.HeightExtension;
                        cmd.Smooth = LocalHistogramEqualizeDlg.LocalHistogramEqualizeCommand.Smooth;
                        cmd.Type = LocalHistogramEqualizeDlg.LocalHistogramEqualizeCommand.Type;
                        cmd.Width = LocalHistogramEqualizeDlg.LocalHistogramEqualizeCommand.Width;
                        cmd.WidthExtension = LocalHistogramEqualizeDlg.LocalHistogramEqualizeCommand.WidthExtension;

                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Height = 15;
                     cmd.HeightExtension = 100;
                     cmd.Smooth = 0;
                     cmd.Type = HistogramEqualizeType.Yuv;
                     cmd.Width = 15;
                     cmd.WidthExtension = 100;
                  }
               }
               else if (command is DynamicBinaryCommand)
               {
                  DynamicBinaryCommand cmd = command as DynamicBinaryCommand;
                  cmd.Dimension = 8;
                  cmd.LocalContrast = 16;
               }
               else if (command is RemapHueCommand)
               {
                  RemapHueCommand cmd = command as RemapHueCommand;

                  int length;

                  if (_viewerBefore.Image.BitsPerPixel >= 48)
                     length = 0x10000;
                  else if (!(_viewerBefore.Image.BitsPerPixel == 16 || _viewerBefore.Image.BitsPerPixel == 12))
                     length = 256;
                  else if (_viewerBefore.Image.GetLookupTable() != null && _viewerBefore.Image.UseLookupTable)
                     length = 256;
                  else
                     length = (1 << _viewerBefore.Image.BitsPerPixel);

                  //Allocate tables
                  int[] maskTable = new int[length];
                  int[] hueTable = new int[length];

                  //Initialize tables
                  for (int i = 0; i < length / 3; i++)
                     hueTable[i] = 0;

                  for (int i = length / 3; i < length * 2 / 3; i++)
                  {
                     hueTable[i] = 255;
                     maskTable[i] = 1;
                  }

                  for (int i = length * 2 / 3; i < length / 3; i++)
                     hueTable[i] = 0;

                  //Get the hue for green
                  RasterHsvColor hsvRef = RasterHsvColor.FromRasterColor(new RasterColor(0, 255, 0));

                  int hueGreen = hsvRef.H;

                  //Obtain new hue  
                  hsvRef = RasterHsvColor.FromRasterColor(new RasterColor(255, 128, 0));
                  int hueChange = (int)hsvRef.H - (int)hueGreen;
                  hueChange = (hueChange > 0) ? (int)hueChange : (int)(hueChange + length - 1);
                  hueGreen *= (length - 1) / 255;
                  hueChange *= (length - 1) / 255;

                  //Set values in hueTable, maskTable 
                  hueTable[hueGreen] = (hueTable[hueGreen] + hueChange);
                  maskTable[hueGreen] = 1;

                  //set the hues near green (+/- 15)
                  int count = (15 * (length - 1)) / 255;
                  for (int i = Increment(hueGreen, length); count > 0; i = Increment(i, length), count--)
                  {
                     hueTable[i] = Add(hueTable[i], hueChange, length);
                     maskTable[i] = 1;
                  }

                  count = (15 * (length - 1)) / 255;
                  for (int i = Decrement(hueGreen, length); count > 0; i = Decrement(i, length), count--)
                  {
                     hueTable[i] = Add(hueTable[i], hueChange, length);
                     maskTable[i] = 1;
                  }

                  cmd.HueTable = hueTable;
                  cmd.LookUpTableLength = length;
                  cmd.Mask = maskTable;
               }
               else if (command is GrayScaleExtendedCommand)
               {
                  GrayScaleExtendedCommand cmd = command as GrayScaleExtendedCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     GrayScaleExtendedDialog GrayScaleExtendedDlg = new GrayScaleExtendedDialog();
                     if (GrayScaleExtendedDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.RedFactor = GrayScaleExtendedDlg.GrayScaleExtendedCommand.RedFactor;
                        cmd.GreenFactor = GrayScaleExtendedDlg.GrayScaleExtendedCommand.GreenFactor;
                        cmd.BlueFactor = GrayScaleExtendedDlg.GrayScaleExtendedCommand.BlueFactor;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.RedFactor = 300;
                     cmd.GreenFactor = 590;
                     cmd.BlueFactor = 110;
                  }
               }
               else if (command is SwapColorsCommand)
               {
                  SwapColorsCommand cmd = command as SwapColorsCommand;
                  cmd.Type = SwapColorsCommandType.RedGreen;
               }
               else if (command is ConvertToColoredGrayCommand)
               {
                  ConvertToColoredGrayCommand cmd = command as ConvertToColoredGrayCommand;
                  cmd.RedFactor = 250;
                  cmd.GreenFactor = 625;
                  cmd.BlueFactor = 125;
                  cmd.RedGrayFactor = 300;
                  cmd.GreenGrayFactor = 200;
                  cmd.BlueGrayFactor = 100;
               }
               else if (command is RemoveRedEyeCommand)
               {
                  RemoveRedEyeCommand cmd = command as RemoveRedEyeCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     RemoveRedEyeDialog RemoveRedEyeDlg = new RemoveRedEyeDialog();
                     if (RemoveRedEyeDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Lightness = RemoveRedEyeDlg.RemoveRedEyeCommand.Lightness;
                        cmd.NewColor = RemoveRedEyeDlg.RemoveRedEyeCommand.NewColor;
                        cmd.Threshold = RemoveRedEyeDlg.RemoveRedEyeCommand.Threshold;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Lightness = 100;
                     cmd.NewColor = new RasterColor(128, 128, 128);
                     cmd.Threshold = 0;
                  }
               }
               else if (command is MultiplyCommand)
               {
                  MultiplyCommand cmd = command as MultiplyCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     MultiplyDialog MultiplyDlg = new MultiplyDialog();

                     if (MultiplyDlg.ShowDialog(this) == DialogResult.OK)
                        cmd.Factor = MultiplyDlg.MultiplyCommand.Factor;
                     else
                        return;
                  }
                  else
                     cmd.Factor = 151;
               }
               else if (command is GrayScaleToDuotoneCommand)
               {
                  GrayscaleCommand graycommand = new GrayscaleCommand(8);
                  graycommand.Run(_viewerAfter.Image);
                  GrayScaleToDuotoneCommand cmd = command as GrayScaleToDuotoneCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     GrayScaleToDuotoneDialog GrayScaleToDuotoneDlg = new GrayScaleToDuotoneDialog();
                     if (GrayScaleToDuotoneDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Color = GrayScaleToDuotoneDlg.GrayScaleToDuotoneCommand.Color;
                        cmd.NewColor = null;
                        cmd.Type = GrayScaleToDuotoneDlg.GrayScaleToDuotoneCommand.Type;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Color = new RasterColor(255, 0, 0);
                     cmd.NewColor = null;
                     cmd.Type = GrayScaleToDuotoneCommandMixingType.ReplaceOldWithNew;
                  }
               }
               else if (command is GrayScaleToMultitoneCommand)
               {
                  GrayscaleCommand graycommand = new GrayscaleCommand(8);
                  graycommand.Run(_viewerAfter.Image);
                  GrayScaleToMultitoneCommand cmd = command as GrayScaleToMultitoneCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     GrayScaleToMultitoneDialog GrayScaleToMultitoneDlg = new GrayScaleToMultitoneDialog();
                     if (GrayScaleToMultitoneDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Colors = GrayScaleToMultitoneDlg.GrayScaleToMultitoneCommand.Colors;
                        cmd.Distribution = GrayScaleToMultitoneCommandDistributionType.Linear;
                        cmd.Gradient = null;
                        cmd.Tone = GrayScaleToMultitoneDlg.GrayScaleToMultitoneCommand.Tone;
                        cmd.Type = GrayScaleToMultitoneDlg.GrayScaleToMultitoneCommand.Type;

                        if (_checkBoxProgress.Checked)
                           cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                        cmd.Run(_viewerAfter.Image);
                        return;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Colors = new RasterColor[2];
                     cmd.Colors[0] = new RasterColor(255, 255, 0);
                     cmd.Colors[1] = new RasterColor(255, 0, 0);
                     cmd.Distribution = GrayScaleToMultitoneCommandDistributionType.Linear;
                     cmd.Gradient = null;
                     cmd.Tone = GrayScaleToMultitoneCommandToneType.Duotone;
                     cmd.Type = GrayScaleToDuotoneCommandMixingType.MixWithOldValue;
                  }
               }
               else if (command is ColorLevelCommand)
               {
                  ColorLevelCommand cmd = command as ColorLevelCommand;
                  cmd.Master = new ColorLevelCommandData(20, 200, 0, 255, 100);
                  cmd.Blue = new ColorLevelCommandData(0, 255, 255, 0, 100);
                  cmd.Flags = ColorLevelCommandFlags.Blue | ColorLevelCommandFlags.Master;
               }
               else if (command is AutoColorLevelCommand)
               {
                  AutoColorLevelCommand cmd = command as AutoColorLevelCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     AutoColorLevelDialog AutoColorLevelDlg = new AutoColorLevelDialog();
                     if (AutoColorLevelDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.BlackClip = AutoColorLevelDlg.AutoColorLevelCommand.BlackClip;
                        cmd.WhiteClip = AutoColorLevelDlg.AutoColorLevelCommand.WhiteClip;
                        cmd.Flag = AutoColorLevelDlg.AutoColorLevelCommand.Flag;
                        cmd.Type = AutoColorLevelDlg.AutoColorLevelCommand.Type;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.BlackClip = 50;
                     cmd.WhiteClip = 50;
                     cmd.Flag = AutoColorLevelCommandFlags.None;
                     cmd.Type = AutoColorLevelCommandType.Level;
                  }
               }
               else if (command is SelectiveColorCommand)
               {
                  SelectiveColorCommand cmd = command as SelectiveColorCommand;
                  SelectiveColorCommandData[] selColors = new SelectiveColorCommandData[9];

                  for (int i = 0; i < 9; i++)
                     selColors[i] = new SelectiveColorCommandData();
                  selColors[(int)SelectiveCommandColorTypes.Red].Cyan = -100;
                  selColors[(int)SelectiveCommandColorTypes.Yellow].Cyan = 34;
                  selColors[(int)SelectiveCommandColorTypes.Yellow].Magenta = 100;
                  selColors[(int)SelectiveCommandColorTypes.Yellow].Yellow = 40;
                  selColors[(int)SelectiveCommandColorTypes.Green].Black = 100;
                  selColors[(int)SelectiveCommandColorTypes.Neutral].Cyan = -65;
                  selColors[(int)SelectiveCommandColorTypes.Neutral].Magenta = -39;
                  selColors[(int)SelectiveCommandColorTypes.Neutral].Yellow = 63;
                  cmd.ColorsData = selColors;
               }
               else if (command is ColorReplaceCommand)
               {
                  ColorReplaceCommand cmd = command as ColorReplaceCommand;
                  ColorReplaceCommandColor[] colors = new ColorReplaceCommandColor[1];
                  colors[0] = new ColorReplaceCommandColor(new RasterColor(200, 0, 35), 100);
                  cmd.Hue = 9000;
                  cmd.Saturation = 0;
                  cmd.Brightness = 0;
               }
               else if (command is ChangeHueSaturationIntensityCommand)
               {
                  ChangeHueSaturationIntensityCommand cmd = command as ChangeHueSaturationIntensityCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     ChangeHueSaturationIntensityDialog Dlg = new ChangeHueSaturationIntensityDialog();
                     if (Dlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Hue = Dlg.ChangeHueSaturationIntensityCommand.Hue;
                        cmd.Intensity = Dlg.ChangeHueSaturationIntensityCommand.Intensity;
                        cmd.Saturation = Dlg.ChangeHueSaturationIntensityCommand.Saturation;
                        cmd.Data = Dlg.ChangeHueSaturationIntensityCommand.Data;
                     }
                     else
                        return;
                  }
                  else
                  {
                     ChangeHueSaturationIntensityCommandData[] data = new ChangeHueSaturationIntensityCommandData[1];
                     data[0] = new ChangeHueSaturationIntensityCommandData(18000, 0, 50, 115, 45, 145, 15);
                     cmd.Hue = 0;
                     cmd.Intensity = 0;
                     cmd.Saturation = 0;
                  }
               }
               else if (command is MathematicalFunctionCommand)
               {
                  MathematicalFunctionCommand cmd = command as MathematicalFunctionCommand;
                  cmd.Factor = 100;
                  cmd.Type = MathematicalFunctionCommandType.Logarithm;
               }
               else if (command is ColorMergeCommand)
               {
                  byte[] MyRegion = null;
                  bool RegionChecked = _checkBoxUseRegion.Checked;
                  if (_viewerBefore.Image.HasRegion)
                     MyRegion = RasterRegionConverter.GetGdiRegionData(_viewerBefore.Image, null);

                  ColorMergeCommand cmd = command as ColorMergeCommand;
                  cmd.Type = ColorMergeCommandType.Rgb;
                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  cmd.Run(_viewerBefore.Image);
                  _viewerAfter.Image = cmd.DestinationImage.Clone();
                  ChangeViewPerspectiveCommand ChangeViewPerspective = new ChangeViewPerspectiveCommand(true, _viewerBefore.Image.ViewPerspective);
                  ChangeViewPerspective.Run(_viewerAfter.Image);

                  if (RegionChecked)
                  {

                     RasterRegionConverter.AddGdiDataToRegion(_viewerBefore.Image, null, MyRegion, 0, RasterRegionCombineMode.Set);
                     RasterRegionConverter.AddGdiDataToRegion(_viewerAfter.Image, null, MyRegion, 0, RasterRegionCombineMode.Set);
                  }

                  return;
               }
               else if (command is ColorThresholdCommand)
               {
                  ColorThresholdCommandComponent[] Components = new ColorThresholdCommandComponent[3];
                  for (int i = 0; i < 3; i++)
                     Components[i] = new ColorThresholdCommandComponent();

                  Components[0].MinimumRange = 0;
                  Components[0].MaximumRange = 360;
                  Components[0].Flags = ColorThresholdCommandFlags.EffectAll;
                  Components[1].MinimumRange = 24;
                  Components[1].MaximumRange = 100;
                  Components[1].Flags = ColorThresholdCommandFlags.EffectAll;
                  Components[2].MinimumRange = 230;
                  Components[2].MaximumRange = 255;
                  Components[2].Flags = ColorThresholdCommandFlags.EffectAll;
                  ColorThresholdCommand cmd = command as ColorThresholdCommand;
                  cmd.ColorSpace = ColorThresholdCommandType.Hsv;
                  cmd.Components = Components;
               }
               else if (command is OffsetCommand)
               {
                  OffsetCommand cmd = command as OffsetCommand;
                  cmd.HorizontalShift = _viewerBefore.Image.Width / 2;
                  cmd.VerticalShift = _viewerBefore.Image.Height / 2;
                  cmd.BackColor = new Leadtools.RasterColor(255, 0, 0);
                  cmd.Type = OffsetCommandType.WrapAround;
               }
               else if (command is BricksTextureCommand)
               {
                  BricksTextureCommand cmd = command as BricksTextureCommand;
                  cmd.BricksHeight = 20;
                  cmd.BricksWidth = 60;
                  cmd.EdgeWidth = 4;
                  cmd.MortarWidth = 3;
                  cmd.RowDifference = 35;
                  cmd.ShadeAngle = 315;
                  cmd.Flags = BricksTextureCommandFlags.ColoredMortar | BricksTextureCommandFlags.SmoothedOutEdges;
                  cmd.MortarColor = new RasterColor(128, 128, 128);
                  cmd.MortarRoughness = 50;
                  cmd.MortarRoughnessEvenness = 0;
                  cmd.BricksRoughness = 100;
                  cmd.BricksRoughnessEvenness = 1;
               }
               else if (command is CanvasCommand)
               {
                  CanvasCommand cmd = command as CanvasCommand;
                  cmd.CanvasImage = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__Ulay3_Bmp));
                  cmd.XOffset = 0;
                  cmd.YOffset = 0;
                  cmd.Transparency = 100;
                  cmd.Emboss = 100;
                  cmd.Flags = CanvasCommandFlags.TileShift;
               }
               else if (command is CloudsCommand)
               {
                  CloudsCommand cmd = command as CloudsCommand;
                  cmd.Type = CloudsCommandType.Opacity;
                  cmd.Seed = 0;
                  cmd.Opacity = 70;
                  cmd.Frequency = 8;
                  cmd.Density = 4;
                  cmd.BackColor = new Leadtools.RasterColor(0, 0, 0);
                  cmd.CloudsColor = new Leadtools.RasterColor(255, 255, 255);
               }
               else if (command is RomanMosaicCommand)
               {
                  RomanMosaicCommand cmd = command as RomanMosaicCommand;
                  cmd.Border = 3;
                  cmd.Color = new Leadtools.RasterColor(0, 0, 0);
                  cmd.Flags = RomanMosaicCommandFlags.GrayShadow | RomanMosaicCommandFlags.Both;
                  cmd.TileWidth = 15;
                  cmd.TileHeight = 15;
                  cmd.ShadowThresh = 0;
                  cmd.ShadowAngle = ShadowCommandAngle.SouthEast;
               }
               else if (command is MosaicTilesCommand)
               {
                  MosaicTilesCommand cmd = command as MosaicTilesCommand;
                  cmd.BorderColor = new Leadtools.RasterColor(0, 0, 0);
                  cmd.Flags = MosaicTilesCommandFlags.ShadowGray | MosaicTilesCommandFlags.Cartesian;
                  cmd.Opacity = 50;
                  cmd.TileWidth = 40;
                  cmd.TileHeight = 40;
                  cmd.TilesColor = new Leadtools.RasterColor(128, 128, 128);
                  cmd.ShadowThreshold = 0;
                  cmd.ShadowAngle = ShadowCommandAngle.SouthEast;
                  cmd.PenWidth = 3;
               }
               else if (command is VignetteCommand)
               {
                  VignetteCommand cmd = command as VignetteCommand;
                  if (_viewerAfter.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerAfter.Image.GetRegionBounds(null);
                     cmd.Origin = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                     cmd.Width = Rect.Width / 2;
                     cmd.Height = Rect.Height / 2;
                     cmd.Origin = new LeadPoint(Rect.Width / 2, Rect.Height / 2);
                  }
                  else
                  {
                     cmd.Width = _viewerAfter.Image.Width / 2;
                     cmd.Height = _viewerAfter.Image.Height / 2;
                     cmd.Origin = new LeadPoint(_viewerAfter.Image.Width / 2, _viewerAfter.Image.Height / 2);
                  }
                  cmd.Fading = 40;
                  cmd.FadingRate = 20;
                  cmd.Flags = VignetteCommandFlags.Ellipse | VignetteCommandFlags.FillOut;
                  cmd.VignetteColor = new Leadtools.RasterColor(255, 255, 255);
                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  cmd.Run(_viewerAfter.Image);
                  return;
               }
               else if (command is FragmentCommand)
               {
                  FragmentCommand cmd = command as FragmentCommand;
                  cmd.Offset = 4;
                  cmd.Opacity = 100;
               }
               else if (command is GammaCorrectExtendedCommand)
               {
                  GammaCorrectExtendedCommand cmd = command as GammaCorrectExtendedCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     GammaCorrectExtendedDialog GammaCorrectExtendedDlg = new GammaCorrectExtendedDialog();
                     if (GammaCorrectExtendedDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Type = GammaCorrectExtendedDlg.GammaCorrectExtendedCommand.Type;
                        cmd.Gamma = GammaCorrectExtendedDlg.GammaCorrectExtendedCommand.Gamma;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Type = GammaCorrectExtendedCommandType.YuvSpace;
                     cmd.Gamma = 200;
                  }
               }
               else if (command is PlasmaCommand)
               {
                  PlasmaCommand cmd = command as PlasmaCommand;
                  cmd.Shift = 0;
                  cmd.Size = 200;
                  cmd.Opacity = 50;
                  cmd.RedFrequency = 200;
                  cmd.GreenFrequency = 0;
                  cmd.BlueFrequency = 100;
                  cmd.Flags = PlasmaCommandFlags.Cross | PlasmaCommandFlags.CustomColor;
                  //cmd.Flags = PlasmaCommandFlags.Random1;
               }
               else if (command is PerspectiveCommand)
               {
                  LeadPoint[] pt = new LeadPoint[4];
                  PerspectiveCommand cmd = command as PerspectiveCommand;
                  if (_viewerAfter.Image.HasRegion)
                  {
                     MessageBox.Show(DemosGlobalization.GetResxString(GetType(), "resx_MessageBoxHasRegionError"), DemosGlobalization.GetResxString(GetType(), "resx_MessageBoxHasRegionErrorTitel"));
                     return;
                  }
                  else
                  {
                     pt[0].X = 10;
                     pt[0].Y = 10;
                     pt[1].X = _viewerAfter.Image.Width - 10;
                     pt[1].Y = 20;
                     pt[2].X = 40;
                     pt[2].Y = _viewerAfter.Image.Height - 20;
                     pt[3].X = _viewerAfter.Image.Width - 10;
                     pt[3].Y = _viewerAfter.Image.Height - 10;
                     cmd.CornerPoints = pt;
                     cmd.Type = PerspectiveCommandType.Color;
                     cmd.FillColor = new Leadtools.RasterColor(0, 0, 0);
                     if (_checkBoxProgress.Checked)
                        cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                     cmd.Run(_viewerAfter.Image);
                     return;
                  }
               }
               else if (command is ColoredBallsCommand)
               {
                  ColoredBallsCommand cmd = command as ColoredBallsCommand;
                  cmd.Ripple = 1000;
                  cmd.ShadingColor = new Leadtools.RasterColor(0, 0, 0);
                  cmd.BackGroundColor = new Leadtools.RasterColor(255, 255, 0);
                  cmd.BallColorOpacity = 10;
                  cmd.BallColorOpacityVariation = 0;
                  cmd.Flags = ColoredBallsCommandFlags.BackGroundColor | ColoredBallsCommandFlags.ShadingCircular | ColoredBallsCommandFlags.Sticker | ColoredBallsCommandFlags.BallsColorOpacity;
                  cmd.HighLightAngle = 0;
                  cmd.HighLightColor = new Leadtools.RasterColor(255, 255, 255);
                  cmd.NumberOfBalls = 1000;
                  cmd.Size = 10;
                  cmd.SizeVariation = 0;
                  cmd.BallColors = new Leadtools.RasterColor[1];
                  cmd.BallColors[0] = new Leadtools.RasterColor(255, 0, 0);

                  cmd.Run(_viewerAfter.Image);
                  return;
               }
               else if (command is PointillistCommand)
               {
                  PointillistCommand cmd = command as PointillistCommand;
                  cmd.FillColor = new RasterColor(0, 0, 0);
                  cmd.Flags = PointillistCommandFlags.BackGroundColor | PointillistCommandFlags.Sticker;
                  cmd.Size = 5;

                  cmd.Run(_viewerAfter.Image);
                  return;

               }
               else if (command is HalfTonePatternCommand)
               {
                  HalfTonePatternCommand cmd = command as HalfTonePatternCommand;
                  cmd.Type = HalfTonePatternCommandType.Dot;
                  cmd.Ripple = 1000;
                  cmd.ForeGroundColor = new Leadtools.RasterColor(0, 0, 0);
                  cmd.BackGroundColor = new Leadtools.RasterColor(255, 255, 255);
                  cmd.Contrast = 100;

                  cmd.Run(_viewerAfter.Image);
                  return;
               }
               else if (command is ColorHalftoneCommand)
               {
                  ColorHalftoneCommand cmd = command as ColorHalftoneCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     ColorHalftoneDialog ColorHalftoneDlg = new ColorHalftoneDialog();
                     if (ColorHalftoneDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.BlackAngle = ColorHalftoneDlg.ColorHalftoneCommand.BlackAngle;
                        cmd.CyanAngle = ColorHalftoneDlg.ColorHalftoneCommand.CyanAngle;
                        cmd.MagentaAngle = ColorHalftoneDlg.ColorHalftoneCommand.MagentaAngle;
                        cmd.YellowAngle = ColorHalftoneDlg.ColorHalftoneCommand.YellowAngle;
                        cmd.MaximumRadius = ColorHalftoneDlg.ColorHalftoneCommand.MaximumRadius;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.BlackAngle = 0;
                     cmd.CyanAngle = 10;
                     cmd.MagentaAngle = 40;
                     cmd.YellowAngle = 10;
                     cmd.MaximumRadius = 40;
                  }
               }
               else if (command is ZigZagCommand)
               {
                  ZigZagCommand cmd = command as ZigZagCommand;
                  cmd.Amplitude = 30;
                  cmd.Attenuation = 10;
                  if (_viewerBefore.Image.HasRegion)
                  {
                     LeadRect Rect = _viewerBefore.Image.GetRegionBounds(null);
                     cmd.CenterPoint = new LeadPoint((Rect.Right + Rect.Left) / 2, (Rect.Bottom + Rect.Top) / 2);
                  }
                  else
                     cmd.CenterPoint = new LeadPoint(_viewerAfter.Image.Width / 2, _viewerAfter.Image.Height / 2);
                  cmd.FillColor = new Leadtools.RasterColor(0, 0, 0);
                  cmd.Frequency = 20;
                  cmd.Flags = ZigZagCommandFlags.PondRippleWave;
                  cmd.Phase = 0;
               }
               else if (command is HighPassCommand)
               {
                  HighPassCommand cmd = command as HighPassCommand;
                  cmd.Opacity = 50;
                  cmd.Radius = 10;
               }
               else if (command is ResizeInterpolateCommand)
               {
                  ResizeInterpolateCommand cmd = command as ResizeInterpolateCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     ResizeInterpolateDialog ResizeInterpolateDlg = new ResizeInterpolateDialog(_viewerBefore.Image.Clone());
                     if (ResizeInterpolateDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Width = ResizeInterpolateDlg.ResizeInterpolatecommand.Width;
                        cmd.Height = ResizeInterpolateDlg.ResizeInterpolatecommand.Height;
                        cmd.ResizeType = ResizeInterpolateDlg.ResizeInterpolatecommand.ResizeType;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Width = _viewerBefore.Image.Width / 2;
                     cmd.Height = _viewerBefore.Image.Height / 2;
                     cmd.ResizeType = ResizeInterpolateCommandType.Lanczos;
                  }
               }
               else if (command is DiffuseGlowCommand)
               {
                  DiffuseGlowCommand cmd = command as DiffuseGlowCommand;
                  cmd.ClearAmount = 80;
                  cmd.GlowAmount = 10;
                  cmd.GlowColor = new Leadtools.RasterColor(255, 255, 255);
                  cmd.SpreadAmount = 80;
                  cmd.WhiteNoiseRange = 0;
               }
               else if (command is DisplacementCommand)
               {
                  DisplacementCommand cmd = command as DisplacementCommand;
                  cmd.DisplacementMapImage = _codecs.Load(CommandProperties.GetImageNameFileName(CommandImage.ImageProcessingDemo__Ulay3_Bmp));
                  cmd.Flags = DisplacementCommandFlags.Repeat | DisplacementCommandFlags.Tile;
                  cmd.HorizontalFactor = 100;
                  cmd.VerticalFactor = 100;
               }
               else if (command is DeskewCommand)
               {
                  DeskewCommand cmd = command as DeskewCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     DeskewDialog DeskewDlg = new DeskewDialog(cmd);
                     if (DeskewDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Flags = DeskewDlg.DeskewCommand.Flags;
                        cmd.FillColor = DeskewDlg.DeskewCommand.FillColor;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Flags = DeskewCommandFlags.DeskewImage | DeskewCommandFlags.DoNotFillExposedArea;
                     cmd.FillColor = new Leadtools.RasterColor(255, 255, 255);
                  }

                  cmd.Run(_viewerAfter.Image);
                  return;
               }
               else if (command is BlankPageDetectorCommand)
               {
                  BlankPageDetectorCommand cmd = command as BlankPageDetectorCommand;
                  if (_checkBoxOptionsDialog.Checked)
                  {
                     BlankPageDetectorDialog BlankPageDetectorDlg = new BlankPageDetectorDialog(_viewerBefore.Image.Clone());
                     if (BlankPageDetectorDlg.ShowDialog(this) == DialogResult.OK)
                     {
                        cmd.Flags = BlankPageDetectorDlg.BlankPageDetectorcommand.Flags;
                        cmd.LeftMargin = BlankPageDetectorDlg.BlankPageDetectorcommand.LeftMargin;
                        cmd.TopMargin = BlankPageDetectorDlg.BlankPageDetectorcommand.TopMargin;
                        cmd.RightMargin = BlankPageDetectorDlg.BlankPageDetectorcommand.RightMargin;
                        cmd.BottomMargin = BlankPageDetectorDlg.BlankPageDetectorcommand.BottomMargin;
                     }
                     else
                        return;
                  }
                  else
                  {
                     cmd.Flags = BlankPageDetectorCommandFlags.DetectNoisyPage;
                  }

                  if (_checkBoxProgress.Checked)
                     cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                  cmd.Run(_viewerBefore.Image);
                  MessageBox.Show(string.Format(" {0} : ", DemosGlobalization.GetResxString(GetType(), "resx_IsBlank")) + cmd.IsBlank + string.Format("\n {0} : ", DemosGlobalization.GetResxString(GetType(), "resx_Accuracy")) + (cmd.Accuracy * 1.0 / 100) + "%", DemosGlobalization.GetResxString(GetType(), "resx_BlankPageDetectionResults"));
                  return;
               }
               else if (command is AdjustTintCommand)
               {
                  AdjustTintCommand cmd = command as AdjustTintCommand;
                  cmd.AngleA = 315;
                  cmd.AngleB = 45;
               }
               else if (command is PerlinCommand)
               {
                  PerlinCommand cmd = command as PerlinCommand;
                  cmd.Backcolor = new Leadtools.RasterColor(255, 0, 0);
                  cmd.PerlinColor = new Leadtools.RasterColor(255, 255, 0);
                  cmd.PerlinFlags = NoiseLayoutType.PF_Pure | NoiseLayoutType.PF_Random;
                  cmd.Seed = 0;
                  cmd.Opacity = 40;
               }
               else if (command is ColoredPencilCommand)
               {
                  ColoredPencilCommand cmd = command as ColoredPencilCommand;
                  cmd.Dimension = 20;
                  cmd.Ratio = 50;
               }
               else if (command is MaskConvolutionCommand)
               {
                  MaskConvolutionCommand cmd = command as MaskConvolutionCommand;
                  cmd.Angle = 315;
                  cmd.Depth = 5;
                  cmd.Height = 10;
                  cmd.Type = MaskConvolutionCommandType.EmbossSplotch;
               }
               else if (command is KaufmannRegionCommand)
               {
                  KaufmannRegionCommand cmd = command as KaufmannRegionCommand;
                  GrayscaleCommand GrayCommand = new GrayscaleCommand(8);
                  GrayCommand.Run(_viewerAfter.Image);
                  cmd.RegionStart = new LeadPoint(258, 254);
                  cmd.RegionThreshold = 127;
                  cmd.Radius = 12;
                  cmd.RemoveHoles = true;
                  cmd.MaximumInput = 255;
                  cmd.MinimumInput = 73;
                  cmd.CombineMode = Leadtools.RasterRegionCombineMode.Set;
               }
               else if (command is FadedMaskCommand)
               {
                  if (!UseRegionChecked)
                     _checkBoxUseRegion.Checked = true;

                  FadedMaskCommand cmd = command as FadedMaskCommand;
                  cmd.Length = 60;
                  cmd.FadeRate = 20;
                  cmd.StepSize = 3;
                  cmd.Inflate = 0;
                  cmd.Flags = FadedMaskCommandFlags.DumpColorStart | FadedMaskCommandFlags.NoTransparencyFill;
                  cmd.MaximumGray = 255;
                  cmd.Transparent = new RasterColor(0, 0, 255);
                  runAfterImage = true;



               }
               using (WaitCursor wait = new WaitCursor())
               {
                  if (command != null)
                  {
                     RasterImage image = runAfterImage ? _viewerAfter.Image : _viewerBefore.Image;

                     if (_checkBoxProgress.Checked)
                        command.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);

                     RasterImageChangedFlags a = command.Run(image);
                  }
                  if (command is ObjectCounterCommand)
                  {
                     ObjectCounterCommand cmd = command as ObjectCounterCommand;
                     Messager.ShowInformation(this, cmd.Count.ToString());
                     return;
                  }
                  if (command is CloneCommand)
                  {
                     CloneCommand cmd = command as CloneCommand;
                     _viewerAfter.Image = cmd.DestinationImage;
                  }
                  else if (command is CopyRectangleCommand)
                  {
                     CopyRectangleCommand cmd = command as CopyRectangleCommand;
                     _viewerAfter.Image = cmd.DestinationImage;
                  }
                  else if (command is FadedMaskCommand)
                  {
                      if (UseRegionChecked)
                          _checkBoxUseRegion.Checked = true;
                      else
                          _checkBoxUseRegion.Checked = false;

                      FadedMaskCommand cmd = command as FadedMaskCommand;
                      _viewerAfter.Image = cmd.MaskImage;
                  }
                  else if (command is AddWeightedCommand)
                  {
                      AddWeightedCommand cmd = command as AddWeightedCommand;
                      cmd.Factor = new int[10];
                      cmd.Type = AddWeightedCommandType.Average;
                      _viewerAfter.Image = cmd.DestinationImage;
                  }
                  else if (command is ShiftDataCommand)
                  {
                      ShiftDataCommand cmd = command as ShiftDataCommand;
                      _viewerAfter.Image = cmd.DestinationImage;
                  }
                  else if (command is SelectDataCommand)
                  {
                      SelectDataCommand cmd = command as SelectDataCommand;
                      _viewerAfter.Image = cmd.DestinationImage;
                  }
                  else if (command is ColorizeGrayCommand)
                  {
                      ColorizeGrayCommand cmd = command as ColorizeGrayCommand;
                      _viewerAfter.Image = cmd.DestinationImage;
                  }
                  else if (command is StatisticsInformationCommand)
                  {
                      StatisticsInformationCommand cmd = command as StatisticsInformationCommand;
                      StringBuilder sb = new StringBuilder();
                      sb.Append(string.Format("{0} = ", DemosGlobalization.GetResxString(GetType(), "resx_StatisticsMax")));
                      sb.Append(cmd.Maximum);
                      sb.Append(Environment.NewLine);
                      sb.Append(string.Format("{0} = ", DemosGlobalization.GetResxString(GetType(), "resx_StatisticsMean")));
                      sb.Append(cmd.Mean);
                      sb.Append(Environment.NewLine);
                      sb.Append(string.Format("{0} = ", DemosGlobalization.GetResxString(GetType(), "resx_StatisticsMedian")));
                      sb.Append(cmd.Median);
                      sb.Append(Environment.NewLine);
                      sb.Append(string.Format("{0} = ", DemosGlobalization.GetResxString(GetType(), "resx_StatisticsMin")));
                      sb.Append(cmd.Minimum);
                      sb.Append(Environment.NewLine);
                      sb.Append(string.Format("{0} = ", DemosGlobalization.GetResxString(GetType(), "resx_StatisticsPercent")));
                      sb.Append(cmd.Percent);
                      sb.Append(Environment.NewLine);
                      sb.Append(string.Format("{0} = ", DemosGlobalization.GetResxString(GetType(), "resx_StatisticsPixelCount")));
                      sb.Append(cmd.PixelCount);
                      sb.Append(Environment.NewLine);
                      sb.Append(string.Format("{0} = ", DemosGlobalization.GetResxString(GetType(), "resx_StatisticsStdDiv")));
                      sb.Append(cmd.StandardDeviation);
                      sb.Append(Environment.NewLine);
                      sb.Append(string.Format("{0} = ", DemosGlobalization.GetResxString(GetType(), "resx_StatisticsTotalPixelCount")));
                      sb.Append(cmd.TotalPixelCount);
                      Messager.ShowInformation(this, sb.ToString());
                  }
                  else if (command is AddCommand)
                  {
                      AddCommand cmd = command as AddCommand;
                      _viewerAfter.Image = cmd.DestinationImage;
                  }
                  else if (command is AutoCropRectangleCommand)
                  {
                      AutoCropRectangleCommand cmd = command as AutoCropRectangleCommand;
                      Messager.ShowInformation(this, DemosGlobalization.GetResxString(GetType(), "resx_MessagerRectangle") + string.Format(" = {0}", cmd.Rectangle));
                  }
                  else if (command is ColorCountCommand)
                  {
                      ColorCountCommand cmd = command as ColorCountCommand;
                      Messager.ShowInformation(this, DemosGlobalization.GetResxString(GetType(), "resx_MessagerColorCount") + string.Format(" = {0}", cmd.ColorCount));
                  }
                  else if (command is ObjectInformationCommand)
                  {
                      ObjectInformationCommand cmd = command as ObjectInformationCommand;
                      cmd.Weighted = false;
                      Messager.ShowInformation(this, string.Format("{1} = {2}{0}{3} = {4}{0}{5} = {6}{0}", Environment.NewLine, DemosGlobalization.GetResxString(GetType(), "resx_MessagerAngle"), cmd.Angle, DemosGlobalization.GetResxString(GetType(), "resx_MessagerRoundness"),
                         cmd.Roundness, DemosGlobalization.GetResxString(GetType(), "resx_MessagerPtOfCenterMass"), cmd.CenterOfMass));
                  }
                  else if (command is ColorSeparateCommand)
                  {
                      ColorSeparateCommand cmd = command as ColorSeparateCommand;
                      cmd.Type = ColorSeparateCommandType.Rgb;
                      _viewerAfter.Image = cmd.DestinationImage;
                  }
                  else if (command is KaufmannRegionCommand)
                  {
                      KaufmannRegionCommand cmd = command as KaufmannRegionCommand;
                      int innerPixelCount = cmd.PixelsCount;
                      cmd.RegionStart = new LeadPoint(228, 305);
                      cmd.RegionThreshold = 29;
                      cmd.Radius = 12;
                      cmd.RemoveHoles = true;
                      cmd.MaximumInput = 255;
                      cmd.MinimumInput = 40;
                      cmd.CombineMode = Leadtools.RasterRegionCombineMode.Xor;
                      if (_checkBoxProgress.Checked)
                          cmd.Progress += new EventHandler<RasterCommandProgressEventArgs>(command_Progress);
                      cmd.Run(_viewerAfter.Image);
                      int outerPixelCount = cmd.PixelsCount;
                      int ratio = (int)(((float)innerPixelCount / outerPixelCount) * 10000);
                      Messager.ShowInformation(this, string.Format("{0} = {1}%", DemosGlobalization.GetResxString(GetType(), "resx_MessagerAreaRatio"), (float)ratio / 100));
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
            _runAlready = true;
            UpdateImageInformation();
            UpdatePages(_viewerBefore.Image, _buttonBeforePageFirst, _buttonBeforePagePrevious, _buttonBeforePageNext, _buttonBeforePageLast, _labelBeforePage);
            UpdatePages(_viewerAfter.Image, _buttonAfterPageFirst, _buttonAfterPagePrevious, _buttonAfterPageNext, _buttonAfterPageLast, _labelAfterPage);

            if (_checkBoxProgress.Checked)
               Progress(true);

            // making sure that the resulted image has been displayed correctly
            _isViewerBefore = false;
            UpdateImageValues();
            _viewerAfter.Invalidate();
         }
      }

      private void command_Progress(object sender, RasterCommandProgressEventArgs e)
      {
         _progressBar.Value = e.Percent;
         if (_allowEventDuringProcess)
            Application.DoEvents();

         if (_canceled)
            e.Cancel = true;
      }

      private void Progress(bool enable)
      {
         if (!enable)
            _activeControl = ActiveControl;

         _canceled = false;

         _canClose = enable;
         _panelControls.Enabled = enable;
         if (_panelBefore != null)
            _panelBefore.Enabled = enable;
         if (_panelAfter != null)
            _panelAfter.Enabled = enable;

         foreach (MenuItem i in _mainMenu.MenuItems)
            EnableMenus(i, enable);

         if (enable)
         {
            _progressBar.Value = 0;
            if (_activeControl != null)
               _activeControl.Focus();
         }
      }

      private void EnableMenus(MenuItem menu, bool enable)
      {
         menu.Enabled = enable;
         foreach (MenuItem i in menu.MenuItems)
            EnableMenus(i, enable);
      }

      private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         if (!_canClose)
            e.Cancel = true;
      }

      private void _buttonCancel_Click(object sender, System.EventArgs e)
      {
         _canceled = true;
      }

      private void cmd_Slice(object sender, SliceCommandEventArgs e)
      {
         if (_viewerAfter.Image.HasRegion)
            _viewerAfter.Image.AddRectangleToRegion(null, e.SliceRectangle, Leadtools.RasterRegionCombineMode.Xor);
         else
            _viewerAfter.Image.AddRectangleToRegion(null, e.SliceRectangle, Leadtools.RasterRegionCombineMode.Set);
      }

      private void _radioButtonRectangle_CheckedChanged(object sender, EventArgs e)
      {
         DisableInteractiveModes(false);
         _addRegion.Shape = ImageViewerRubberBandShape.Rectangle;
         _viewerBefore.InteractiveModes.BeginUpdate();
         _addRegion.IsEnabled = true;
         _viewerBefore.InteractiveModes.EndUpdate();
         _addRegion.CombineMode = RegionCombineMode;
      }

      private void _radioButtonEllipse_CheckedChanged(object sender, EventArgs e)
      {
         DisableInteractiveModes(false);
         _addRegion.Shape = ImageViewerRubberBandShape.Ellipse;
         _viewerBefore.InteractiveModes.BeginUpdate();
         _addRegion.IsEnabled = true;
         _viewerBefore.InteractiveModes.EndUpdate();
         _addRegion.CombineMode = RegionCombineMode;
      }

      private void _radioButtonFreeHand_CheckedChanged(object sender, EventArgs e)
      {
         DisableInteractiveModes(false);
         FreeHandRgn = _radioButtonFreeHand.Checked;
         _addRegion.Shape = ImageViewerRubberBandShape.Freehand;
         _viewerBefore.InteractiveModes.BeginUpdate();
         _addRegion.IsEnabled = true;
         _viewerBefore.InteractiveModes.EndUpdate();
         _addRegion.CombineMode = RegionCombineMode;
      }

      private void _radioButtonMagicWand_CheckedChanged(object sender, EventArgs e)
      {
         DisableInteractiveModes(false);
         AddMagicWand = _radioButtonMagicWand.Checked;
         _viewerBefore.InteractiveModes.BeginUpdate();
         AddMagicWandMode.MagicWandRegionCombineMode = RegionCombineMode;
         AddMagicWandMode.IsEnabled = true;
         _viewerBefore.InteractiveModes.EndUpdate();
      }

      public void DisableInteractiveModes(bool check)
      {
         _viewerBefore.InteractiveModes.BeginUpdate();
         foreach (ImageViewerInteractiveMode mode in _viewerBefore.InteractiveModes)
         {
            mode.IsEnabled = false;
         }
         _viewerBefore.InteractiveModes.BeginUpdate();

         _viewerAfter.InteractiveModes.BeginUpdate();
         if (check)
         {
            foreach (ImageViewerInteractiveMode mode in _viewerAfter.InteractiveModes)
            {
               mode.IsEnabled = false;
            }
         }
         _viewerAfter.InteractiveModes.BeginUpdate();
      }

      private void _radioButtonSingle_CheckedChanged(object sender, EventArgs e)
      {
         RegionCombineMode = RasterRegionCombineMode.Set;

         _addRegion.CombineMode = RegionCombineMode;
      }

      private void _radioButtonMulti_CheckedChanged(object sender, EventArgs e)
      {
         RegionCombineMode = RasterRegionCombineMode.Or;
         _addRegion.CombineMode = RegionCombineMode;
      }

      private void _radioButtonInvert_CheckedChanged(object sender, EventArgs e)
      {
         RegionCombineMode = RasterRegionCombineMode.SetNot;
         _addRegion.CombineMode = RegionCombineMode;
      }

      private void _radioButtonIntersect_CheckedChanged(object sender, EventArgs e)
      {
         RegionCombineMode = RasterRegionCombineMode.And;
         _addRegion.CombineMode = RegionCombineMode;
      }

      private void _radioButtonOldandNotNew_CheckedChanged(object sender, EventArgs e)
      {
         RegionCombineMode = RasterRegionCombineMode.AndNotRegion;
         _addRegion.CombineMode = RegionCombineMode;
      }

      private void _radioButtonNewandNotOld_CheckedChanged(object sender, EventArgs e)
      {
         RegionCombineMode = RasterRegionCombineMode.AndNotImage;
         _addRegion.CombineMode = RegionCombineMode;
      }

      private void _radioButtonOldXORNew_CheckedChanged(object sender, EventArgs e)
      {
         RegionCombineMode = RasterRegionCombineMode.Xor;
         _addRegion.CombineMode = RegionCombineMode;
      }

      private void _radioButtonNone_CheckedChanged(object sender, EventArgs e)
      {
         _viewerBefore.Image.MakeRegionEmpty();
         DisableInteractiveModes((_viewerAfter.Image != null));
         _viewerBefore.InteractiveModes.BeginUpdate();
         _noneInteractiveMode.IsEnabled = true;
         _viewerBefore.InteractiveModes.EndUpdate();

         if (_viewerAfter.Image != null)
         {
            _viewerAfter.Image.MakeRegionEmpty();
            _viewerAfter.InteractiveModes.BeginUpdate();
            _noneInteractiveMode.IsEnabled = true;
            _viewerAfter.InteractiveModes.EndUpdate();
         }
      }
      private void _viewer_MouseDown(object sender, MouseEventArgs e)
      {
         try
         {
            if (!AddMagicWand)
            {
               if (FreeHandRgn)
               {
                  byte[] Regiondata = null;
                  if (!(_viewerBefore.Image == null) && (_checkBoxUseRegion.Checked))
                  {
                     ImageViewerAddRegionInteractiveMode addRegion = new ImageViewerAddRegionInteractiveMode();

                     foreach (ImageViewerInteractiveMode oMode in _viewerBefore.InteractiveModes)
                     {
                        if (oMode.IsEnabled)
                           addRegion = oMode as ImageViewerAddRegionInteractiveMode;
                     }

                     if (addRegion != null)
                     {
                        Regiondata = RasterRegionConverter.GetGdiRegionData(_viewerBefore.Image, null);
                        if ((Regiondata == null) && (RegionCombineMode == RasterRegionCombineMode.And))
                           addRegion.CombineMode = RasterRegionCombineMode.Set;
                        else
                        {
                           if (Regiondata != null)
                              if ((Regiondata.Length == 32) && (RegionCombineMode == RasterRegionCombineMode.And))
                                 addRegion.CombineMode = RasterRegionCombineMode.Set;
                              else
                                 addRegion.CombineMode = RegionCombineMode;
                        }
                     }
                  }
               }

               _isViewerBefore = sender == _viewerBefore;
               ImageViewer Viewer = (_isViewerBefore) ? _viewerBefore : _viewerAfter;

               if (!_isMagGlass)
               {
                  int x, y;
                  LeadPointD pt = Viewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, new LeadPointD(e.X, e.Y));
                  x = Convert.ToInt32(pt.X);
                  y = Convert.ToInt32(pt.Y);

                  switch (e.Button)
                  {
                     case MouseButtons.Right:
                        _buttonPressed = MouseButton.Rigth;
                        _xLastPos = x;
                        _yLastPos = y;
                        break;

                     case MouseButtons.Left:
                        _buttonPressed = MouseButton.Left;
                        GetCursorData(x, y, e.X, e.Y);
                        break;
                     default:
                        _buttonPressed = MouseButton.None;
                        break;
                  }
               }
            }
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.ToString());
         }
      }

      private void _menuItemMagGlassStart_Click(object sender, EventArgs e)
      {
         DisableInteractiveModes(true);
         _viewerAfter.InteractiveModes.EnableById(_magnifyGlassInteractiveModeViewerAfter.Id);
         _viewerBefore.InteractiveModes.EnableById(_magnifyGlassInteractiveMode.Id);

         _isMagGlass = true;
         _menuItemMagGlassStart.Checked = true;
         _menuItemMagGlassStop.Checked = false;
      }

      private void _menuItemMagGlassStop_Click(object sender, EventArgs e)
      {
         DisableInteractiveModes(true);
         _viewerAfter.InteractiveModes.EnableById(_noneInteractiveModeViewerAfter.Id);
         _viewerBefore.InteractiveModes.EnableById(_noneInteractiveMode.Id);

         _isMagGlass = false;
         _menuItemMagGlassStart.Checked = false;
         _menuItemMagGlassStop.Checked = true;
      }

      private void _menuItemHistogram_Click(object sender, EventArgs e)
      {
         HistogramDlg dlg = new HistogramDlg(_viewerBefore.Image, _isWLImage);
         dlg.ShowDialog();
      }

      private void _viewerBefore_MouseMove(object sender, MouseEventArgs e)
      {
         if (!AddMagicWand)
         {
            ImageViewer Viewer = (_isViewerBefore) ? _viewerBefore : _viewerAfter;
            int x, y;
            LeadPointD pt = Viewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, new LeadPointD(e.X, e.Y));
            x = Convert.ToInt32(pt.X);
            y = Convert.ToInt32(pt.Y);

            if (_buttonPressed == MouseButton.Rigth && Viewer.Image.GrayscaleMode != RasterGrayscaleMode.None)
            {
               if (_xLastPos < x)
                  _windowLevelWidth = _windowLevelWidth + (x - _xLastPos) * _scale;
               else if (_xLastPos > x)
                  _windowLevelWidth = _windowLevelWidth - (_xLastPos - x) * _scale;

               _xLastPos = x;

               CheckValue(ref _windowLevelWidth, _maxWidth, _minWidth);

               if (_yLastPos < y)
                  _windowLevelCenter = _windowLevelCenter + (y - _yLastPos) * _scale;
               else if (_yLastPos > y)
                  _windowLevelCenter = _windowLevelCenter - (_yLastPos - y) * _scale;

               _yLastPos = y;

               CheckValue(ref _windowLevelCenter, _maxLevel, _minLevel);

               ChangeThePalette();
            }
            else if (_buttonPressed == MouseButton.Left)
            {
               if (!(_xLastPos == x && _yLastPos == y))
               {
                  GetCursorData(x, y, e.X, e.Y);
                  _xLastPos = x;
                  _yLastPos = y;
               }
            }
         }
      }

      private void _viewerBefore_MouseUp(object sender, MouseEventArgs e)
      {
         if (!AddMagicWand)
         {
            _isViewerBefore = sender == _viewerBefore;
            _buttonPressed = MouseButton.None;
            _toolTip.Hide((_isViewerBefore) ? _viewerBefore : _viewerAfter);
         }
      }

      private void ChangeThePalette()
      {
         ImageViewer Viewer = (_isViewerBefore) ? _viewerBefore : _viewerAfter;
         if (_isWLImage == false ) return;

         try
         {
            bool inverted = false ;
            if (Viewer.Image.GrayscaleMode == RasterGrayscaleMode.OrderedInverse)
            {
                inverted = true;
            }

            int low = (int)(_windowLevelCenter - _windowLevelWidth / 2.0);
            int high = (int)(_windowLevelCenter + _windowLevelWidth / 2.0);

            if (Viewer.Image.BitsPerPixel == 8)
            {
               _currentPalette = new RasterColor[_LUTSize];

               RasterPalette.WindowLevelFillLookupTable(_currentPalette,
                                                          inverted ? _endColor : _startColor, inverted ? _startColor : _endColor,
                                                          low, high,
                                                          Viewer.Image.LowBit, _highBit,
                                                          _minValue, _maxValue,
                                                          0, _flags);

               Viewer.Image.SetPalette(_currentPalette, 0, _currentPalette.Length);
            }
            else
            {
               _currentPalette16 = new RasterColor16[_LUTSize16];

               RasterPalette.WindowLevelFillLookupTableExt(_currentPalette16,
                                                            inverted ? _endColor16 : _startColor16, inverted ? _startColor16 : _endColor16,
                                                            low, high,
                                                            Viewer.Image.LowBit, _highBit,
                                                            _minValue, _maxValue,
                                                            0, _flags);

               Viewer.Image.WindowLevelExt(Viewer.Image.LowBit, _highBit, _currentPalette16, RasterWindowLevelMode.PaintAndProcessing);
            }
         }
         catch { }
      }

      private RasterColor RasterColor(int p, int p_2, int p_3)
      {
         throw new NotImplementedException();
      }

      private void CheckValue(ref int value, int max, int min)
      {
         if (value > max)
            value = max;
         if (value < min)
            value = min;
      }

      void GetCursorData(int x, int y, int CurX, int CurY)
      {
         try
         {
            string paletteValue, RGB;
            ImageViewer Viewer = (_isViewerBefore) ? _viewerBefore : _viewerAfter;
            if (x < Viewer.Image.Width && y < Viewer.Image.Height && x >= 0 && y >= 0 && Viewer.Image.GrayscaleMode != RasterGrayscaleMode.None
                && Viewer.Image.BitsPerPixel != 1)
            {
               byte[] Data;
               int originalValue = 0, originalValueT = 0;
               Viewer.Image.Access();
               Data = Viewer.Image.GetPixelData(y, x);
               Viewer.Image.Release();
               switch (Viewer.Image.BitsPerPixel)
               {
                  case 16:
                  case 12:
                     int high = (Viewer.Image.HighBit != -1) ? Viewer.Image.HighBit : Viewer.Image.BitsPerPixel;
                     int signedBit = Viewer.Image.HighBit;
                     int checkValue = (int)Math.Pow(2, signedBit);
                     originalValue = Data[1] * 256 + Data[0];
                     if (originalValue >= checkValue && Viewer.Image.Signed)
                     {
                        originalValue = Data[1] * 256 + Data[0];
                        originalValueT = -1 * (((Convert.ToInt32(Math.Pow(2, signedBit - 7) - 1) - Data[1]) * 256 + 255 - Data[0]) + 1);
                     }
                     else
                        originalValueT = originalValue = Data[1] * 256 + Data[0];
                     break;
                  case 8:
                     originalValueT = originalValue = Data[0];
                     break;
               }

               paletteValue = "Palette map value = " + _currentPalette[originalValue].B;
               RGB = "RGB in the original image = " + originalValueT;
            }
            else
            {
               RasterColor tmpColor = Viewer.Image.GetPixelColor(y, x);
               RGB = string.Format("RGB = ({0},{1},{2})", tmpColor.R, tmpColor.G, tmpColor.B);
               paletteValue = "Palette map value = " + " 0";
            }

            if (_buttonPressed == MouseButton.Left && !Viewer.InteractiveModes.Contains(new ImageViewerAddRegionInteractiveMode()))
            {
               string tipMessage = string.Format("X = {1} , Y = {2} {0}{3} {0}{4}",
                     Environment.NewLine, x, y, paletteValue, RGB);
               _toolTip.Show(tipMessage, Viewer, CurX + 25, CurY + 25);
            }
         }
         catch { }
      }

      void getWindowLevel()
      {
         ImageViewer Viewer = (_isViewerBefore) ? _viewerBefore : _viewerAfter;
         if (_isWLImage == false || Viewer.Image.BitsPerPixel == 0) return;

         try
         {
            int lowValue = 0, highValue = 0;
            int max = _maxValue;
            int min = _minValue;

            if (Viewer.Image.BitsPerPixel != 8)
            {
               RasterColor[] palette = Viewer.Image.GetLookupTable();
               if (palette != null && palette.Length != 0)
               {
                  GetLinearVoiLookupTableCommand cmd = new GetLinearVoiLookupTableCommand();
                  cmd.Run(Viewer.Image);
                  highValue = (int)(cmd.Center + cmd.Width / 2);
                  lowValue = (int)(cmd.Center - cmd.Width / 2);
               }
               else
               {
                  MinMaxValuesCommand cmd = new MinMaxValuesCommand();
                  cmd.Run(Viewer.Image);
                  highValue = cmd.MaximumValue;
                  lowValue = cmd.MinimumValue;
               }
            }
            else
            {
               RasterColor[] palette = Viewer.Image.GetPalette();

               if (palette != null && palette.Length == 256)
               {
                  int value1 = palette[0].R;
                  int value2 = palette[0xff].R;
                  int i;
                  int nFrom = 0;
                  int nTo = 255;

                  for (i = 1; i < 256; i++)
                  {
                     if (palette[i].R != value1)
                     {
                        nFrom = i - 1;
                        break;
                     }
                  }

                  for (i = 254; i > 0; i--)
                  {
                     if (palette[i].R != value2)
                     {
                        nTo = i + 1;
                        break;
                     }
                  }

                  highValue = nTo;
                  lowValue = nFrom;
               }
            }

            _windowLevelWidth = highValue - lowValue + 1;
            _windowLevelCenter = (highValue + lowValue) / 2;
            CheckValue(ref _windowLevelWidth, (int)Math.Pow(2, Viewer.Image.BitsPerPixel), 1);
            CheckValue(ref _windowLevelCenter, (int)Math.Pow(2, Viewer.Image.BitsPerPixel) - 1, (int)Math.Pow(2, Viewer.Image.BitsPerPixel) * -1 + 1);

            ChangeThePalette();
         }
         catch (Exception /*ex*/)
         {
         }
      }

      public void UpdateImageValues()
      {
         try
         {
            ImageViewer Viewer = (_isViewerBefore) ? _viewerBefore : _viewerAfter;
            if (Viewer.Image == null)
               return;

            if (Viewer.Image.GrayscaleMode != RasterGrayscaleMode.None)
            {
               switch (Viewer.Image.BitsPerPixel)
               {
                  case 1:
                     _isWLImage = false;
                     break;
                  case 8:
                     _currentPalette = Viewer.Image.GetPalette();
                     _LUTSize = 256;
                     _minValue = 0;
                     _maxValue = 255;
                     _isWLImage = true;
                     break;
                  case 12:
                  case 16:
                     _highBit = Viewer.Image.HighBit;
                     if (_highBit == -1) _highBit = Viewer.Image.BitsPerPixel - 1;
                     _LUTSize = 1 << (_highBit - Viewer.Image.LowBit + 1);
                     _LUTSize16 = 1 << (_highBit - Viewer.Image.LowBit + 1);

                     _maxValue = (Viewer.Image.Signed) ? ((_LUTSize + 1) / 2 - 1) : (_LUTSize - 1);
                     _minValue = (Viewer.Image.Signed) ? (-(_LUTSize + 1) / 2) : 0;

                     _flags = RasterPaletteWindowLevelFlags.None;
                     _flags = RasterPaletteWindowLevelFlags.Linear | RasterPaletteWindowLevelFlags.DicomStyle | RasterPaletteWindowLevelFlags.Outside ;
                     if (Viewer.Image.Signed) _flags |= RasterPaletteWindowLevelFlags.Signed;

                     _isWLImage = true;
                     break;

               }

               _scale = ((_maxValue - _minValue) / 1000 > 0) ? (_maxValue - _minValue) / 1000 : 1;
               _minWidth = 1;
               _maxWidth = (int)Math.Pow(2, Viewer.Image.BitsPerPixel);
               _minLevel = (int)Math.Pow(2, Viewer.Image.BitsPerPixel) * -1 + 1;
               _maxLevel = (int)Math.Pow(2, Viewer.Image.BitsPerPixel) - 1;

               getWindowLevel();
            }
            else
            {
               _isWLImage = false;
            }
         }
         catch (Exception)
         {
         }
      }
   }
}
