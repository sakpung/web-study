using System;
using System.Drawing;
using System.Windows.Forms;
using Leadtools.Codecs;
namespace ScreenCaptureDemo
{
   partial class MainForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
          this._sbMain = new System.Windows.Forms.StatusStrip();
          this._sbiText = new System.Windows.Forms.ToolStripStatusLabel();
          this._mmMain = new System.Windows.Forms.MenuStrip();
          this._miFile = new System.Windows.Forms.ToolStripMenuItem();
          this._miFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
          this._miFileExit = new System.Windows.Forms.ToolStripMenuItem();
          this._miEdit = new System.Windows.Forms.ToolStripMenuItem();
          this._miEditCut = new System.Windows.Forms.ToolStripMenuItem();
          this._miEditCopy = new System.Windows.Forms.ToolStripMenuItem();
          this._miCapture = new System.Windows.Forms.ToolStripMenuItem();
          this._miCaptureActiveWindow = new System.Windows.Forms.ToolStripMenuItem();
          this._miCaptureActiveClient = new System.Windows.Forms.ToolStripMenuItem();
          this._miCaptureFullScreen = new System.Windows.Forms.ToolStripMenuItem();
          this._miCaptureSelectedObject = new System.Windows.Forms.ToolStripMenuItem();
          this._miCaptureMenuUnderCursor = new System.Windows.Forms.ToolStripMenuItem();
          this._miCaptureSelectedArea = new System.Windows.Forms.ToolStripMenuItem();
          this._miCaptureWallpaper = new System.Windows.Forms.ToolStripMenuItem();
          this._miCaptureMouseCursor = new System.Windows.Forms.ToolStripMenuItem();
          this._miCaptureWindowUnderCursor = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this._miCaptureStopCapture = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
          this._miCaptureFromExeDialogTree = new System.Windows.Forms.ToolStripMenuItem();
          this._miCaptureFromExeDialogTabbedView = new System.Windows.Forms.ToolStripMenuItem();
          this._miOptions = new System.Windows.Forms.ToolStripMenuItem();
          this._miOptionsCaptureOptions = new System.Windows.Forms.ToolStripMenuItem();
          this._miOptionsCaptureAreaOptions = new System.Windows.Forms.ToolStripMenuItem();
          this._miOptionsCaptureObjectOptions = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
          this._miOptionsMinimizeApplicationOnCapture = new System.Windows.Forms.ToolStripMenuItem();
          this._miOptionsActivateApplicationAfterCapture = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
          this._miOptionsBeepOnCapture = new System.Windows.Forms.ToolStripMenuItem();
          this._miView = new System.Windows.Forms.ToolStripMenuItem();
          this._miViewStatusBar = new System.Windows.Forms.ToolStripMenuItem();
          this._miHelp = new System.Windows.Forms.ToolStripMenuItem();
          this._miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
          this._sbMain.SuspendLayout();
          this._mmMain.SuspendLayout();
          this.SuspendLayout();
          // 
          // _sbMain
          // 
          this._sbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._sbiText});
          resources.ApplyResources(this._sbMain, "_sbMain");
          this._sbMain.Name = "_sbMain";
          // 
          // _sbiText
          // 
          this._sbiText.Name = "_sbiText";
          resources.ApplyResources(this._sbiText, "_sbiText");
          // 
          // _mmMain
          // 
          this._mmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFile,
            this._miEdit,
            this._miCapture,
            this._miOptions,
            this._miView,
            this._miHelp});
          resources.ApplyResources(this._mmMain, "_mmMain");
          this._mmMain.Name = "_mmMain";
          // 
          // _miFile
          // 
          this._miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFileSaveAs,
            this._miFileExit});
          this._miFile.Name = "_miFile";
          resources.ApplyResources(this._miFile, "_miFile");
          // 
          // _miFileSaveAs
          // 
          resources.ApplyResources(this._miFileSaveAs, "_miFileSaveAs");
          this._miFileSaveAs.Name = "_miFileSaveAs";
          this._miFileSaveAs.Click += new System.EventHandler(this._miFileSaveAs_Click);
          // 
          // _miFileExit
          // 
          this._miFileExit.Name = "_miFileExit";
          resources.ApplyResources(this._miFileExit, "_miFileExit");
          this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
          // 
          // _miEdit
          // 
          this._miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miEditCut,
            this._miEditCopy});
          this._miEdit.Name = "_miEdit";
          resources.ApplyResources(this._miEdit, "_miEdit");
          // 
          // _miEditCut
          // 
          resources.ApplyResources(this._miEditCut, "_miEditCut");
          this._miEditCut.Name = "_miEditCut";
          this._miEditCut.Click += new System.EventHandler(this._miEditCut_Click);
          // 
          // _miEditCopy
          // 
          resources.ApplyResources(this._miEditCopy, "_miEditCopy");
          this._miEditCopy.Name = "_miEditCopy";
          this._miEditCopy.Click += new System.EventHandler(this._miEditCopy_Click);
          // 
          // _miCapture
          // 
          this._miCapture.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miCaptureActiveWindow,
            this._miCaptureActiveClient,
            this._miCaptureFullScreen,
            this._miCaptureSelectedObject,
            this._miCaptureMenuUnderCursor,
            this._miCaptureSelectedArea,
            this._miCaptureWallpaper,
            this._miCaptureMouseCursor,
            this._miCaptureWindowUnderCursor,
            this.toolStripSeparator1,
            this._miCaptureStopCapture,
            this.toolStripSeparator2,
            this._miCaptureFromExeDialogTree,
            this._miCaptureFromExeDialogTabbedView});
          this._miCapture.Name = "_miCapture";
          resources.ApplyResources(this._miCapture, "_miCapture");
          // 
          // _miCaptureActiveWindow
          // 
          this._miCaptureActiveWindow.Name = "_miCaptureActiveWindow";
          resources.ApplyResources(this._miCaptureActiveWindow, "_miCaptureActiveWindow");
          this._miCaptureActiveWindow.Click += new System.EventHandler(this._miCaptureActiveWindow_Click);
          // 
          // _miCaptureActiveClient
          // 
          this._miCaptureActiveClient.Name = "_miCaptureActiveClient";
          resources.ApplyResources(this._miCaptureActiveClient, "_miCaptureActiveClient");
          this._miCaptureActiveClient.Click += new System.EventHandler(this._miCaptureActiveClient_Click);
          // 
          // _miCaptureFullScreen
          // 
          this._miCaptureFullScreen.Name = "_miCaptureFullScreen";
          resources.ApplyResources(this._miCaptureFullScreen, "_miCaptureFullScreen");
          this._miCaptureFullScreen.Click += new System.EventHandler(this._miCaptureFullScreen_Click);
          // 
          // _miCaptureSelectedObject
          // 
          this._miCaptureSelectedObject.Name = "_miCaptureSelectedObject";
          resources.ApplyResources(this._miCaptureSelectedObject, "_miCaptureSelectedObject");
          this._miCaptureSelectedObject.Click += new System.EventHandler(this._miCaptureSelectedObject_Click);
          // 
          // _miCaptureMenuUnderCursor
          // 
          this._miCaptureMenuUnderCursor.Name = "_miCaptureMenuUnderCursor";
          resources.ApplyResources(this._miCaptureMenuUnderCursor, "_miCaptureMenuUnderCursor");
          this._miCaptureMenuUnderCursor.Click += new System.EventHandler(this._miCaptureMenuUnderCursor_Click);
          // 
          // _miCaptureSelectedArea
          // 
          this._miCaptureSelectedArea.Name = "_miCaptureSelectedArea";
          resources.ApplyResources(this._miCaptureSelectedArea, "_miCaptureSelectedArea");
          this._miCaptureSelectedArea.Click += new System.EventHandler(this._miCaptureSelectedArea_Click);
          // 
          // _miCaptureWallpaper
          // 
          this._miCaptureWallpaper.Name = "_miCaptureWallpaper";
          resources.ApplyResources(this._miCaptureWallpaper, "_miCaptureWallpaper");
          this._miCaptureWallpaper.Click += new System.EventHandler(this._miCaptureWallpaper_Click);
          // 
          // _miCaptureMouseCursor
          // 
          this._miCaptureMouseCursor.Name = "_miCaptureMouseCursor";
          resources.ApplyResources(this._miCaptureMouseCursor, "_miCaptureMouseCursor");
          this._miCaptureMouseCursor.Click += new System.EventHandler(this._miCaptureMouseCursor_Click);
          // 
          // _miCaptureWindowUnderCursor
          // 
          this._miCaptureWindowUnderCursor.Name = "_miCaptureWindowUnderCursor";
          resources.ApplyResources(this._miCaptureWindowUnderCursor, "_miCaptureWindowUnderCursor");
          this._miCaptureWindowUnderCursor.Click += new System.EventHandler(this._miCaptureWindowUnderCursor_Click);
          // 
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
          // 
          // _miCaptureStopCapture
          // 
          resources.ApplyResources(this._miCaptureStopCapture, "_miCaptureStopCapture");
          this._miCaptureStopCapture.Name = "_miCaptureStopCapture";
          this._miCaptureStopCapture.Click += new System.EventHandler(this._miCaptureStopCapture_Click);
          // 
          // toolStripSeparator2
          // 
          this.toolStripSeparator2.Name = "toolStripSeparator2";
          resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
          // 
          // _miCaptureFromExeDialogTree
          // 
          this._miCaptureFromExeDialogTree.Name = "_miCaptureFromExeDialogTree";
          resources.ApplyResources(this._miCaptureFromExeDialogTree, "_miCaptureFromExeDialogTree");
          this._miCaptureFromExeDialogTree.Click += new System.EventHandler(this._miCaptureFromExeDialogTree_Click);
          // 
          // _miCaptureFromExeDialogTabbedView
          // 
          this._miCaptureFromExeDialogTabbedView.Name = "_miCaptureFromExeDialogTabbedView";
          resources.ApplyResources(this._miCaptureFromExeDialogTabbedView, "_miCaptureFromExeDialogTabbedView");
          this._miCaptureFromExeDialogTabbedView.Click += new System.EventHandler(this._miCaptureFromExeDialogTabbedView_Click);
          // 
          // _miOptions
          // 
          this._miOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miOptionsCaptureOptions,
            this._miOptionsCaptureAreaOptions,
            this._miOptionsCaptureObjectOptions,
            this.toolStripSeparator3,
            this._miOptionsMinimizeApplicationOnCapture,
            this._miOptionsActivateApplicationAfterCapture,
            this.toolStripSeparator4,
            this._miOptionsBeepOnCapture});
          this._miOptions.Name = "_miOptions";
          resources.ApplyResources(this._miOptions, "_miOptions");
          // 
          // _miOptionsCaptureOptions
          // 
          this._miOptionsCaptureOptions.Name = "_miOptionsCaptureOptions";
          resources.ApplyResources(this._miOptionsCaptureOptions, "_miOptionsCaptureOptions");
          this._miOptionsCaptureOptions.Click += new System.EventHandler(this._miOptionsCaptureOptions_Click);
          // 
          // _miOptionsCaptureAreaOptions
          // 
          this._miOptionsCaptureAreaOptions.Name = "_miOptionsCaptureAreaOptions";
          resources.ApplyResources(this._miOptionsCaptureAreaOptions, "_miOptionsCaptureAreaOptions");
          this._miOptionsCaptureAreaOptions.Click += new System.EventHandler(this._miOptionsCaptureAreaOptions_Click);
          // 
          // _miOptionsCaptureObjectOptions
          // 
          this._miOptionsCaptureObjectOptions.Name = "_miOptionsCaptureObjectOptions";
          resources.ApplyResources(this._miOptionsCaptureObjectOptions, "_miOptionsCaptureObjectOptions");
          this._miOptionsCaptureObjectOptions.Click += new System.EventHandler(this._miOptionsCaptureObjectOptions_Click);
          // 
          // toolStripSeparator3
          // 
          this.toolStripSeparator3.Name = "toolStripSeparator3";
          resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
          // 
          // _miOptionsMinimizeApplicationOnCapture
          // 
          this._miOptionsMinimizeApplicationOnCapture.Checked = true;
          this._miOptionsMinimizeApplicationOnCapture.CheckState = System.Windows.Forms.CheckState.Checked;
          this._miOptionsMinimizeApplicationOnCapture.Name = "_miOptionsMinimizeApplicationOnCapture";
          resources.ApplyResources(this._miOptionsMinimizeApplicationOnCapture, "_miOptionsMinimizeApplicationOnCapture");
          this._miOptionsMinimizeApplicationOnCapture.Click += new System.EventHandler(this._miOptionsMinimizeApplicationOnCapture_Click);
          // 
          // _miOptionsActivateApplicationAfterCapture
          // 
          this._miOptionsActivateApplicationAfterCapture.Checked = true;
          this._miOptionsActivateApplicationAfterCapture.CheckState = System.Windows.Forms.CheckState.Checked;
          this._miOptionsActivateApplicationAfterCapture.Name = "_miOptionsActivateApplicationAfterCapture";
          resources.ApplyResources(this._miOptionsActivateApplicationAfterCapture, "_miOptionsActivateApplicationAfterCapture");
          this._miOptionsActivateApplicationAfterCapture.Click += new System.EventHandler(this._miOptionsActivateApplicationAfterCapture_Click);
          // 
          // toolStripSeparator4
          // 
          this.toolStripSeparator4.Name = "toolStripSeparator4";
          resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
          // 
          // _miOptionsBeepOnCapture
          // 
          this._miOptionsBeepOnCapture.Name = "_miOptionsBeepOnCapture";
          resources.ApplyResources(this._miOptionsBeepOnCapture, "_miOptionsBeepOnCapture");
          this._miOptionsBeepOnCapture.Click += new System.EventHandler(this._miOptionsBeepOnCapture_Click);
          // 
          // _miView
          // 
          this._miView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miViewStatusBar});
          this._miView.Name = "_miView";
          resources.ApplyResources(this._miView, "_miView");
          // 
          // _miViewStatusBar
          // 
          this._miViewStatusBar.Name = "_miViewStatusBar";
          resources.ApplyResources(this._miViewStatusBar, "_miViewStatusBar");
          this._miViewStatusBar.Click += new System.EventHandler(this._miViewStatusBar_Click);
          // 
          // _miHelp
          // 
          this._miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miHelpAbout});
          this._miHelp.Name = "_miHelp";
          resources.ApplyResources(this._miHelp, "_miHelp");
          // 
          // _miHelpAbout
          // 
          this._miHelpAbout.Name = "_miHelpAbout";
          resources.ApplyResources(this._miHelpAbout, "_miHelpAbout");
          this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
          // 
          // MainForm
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this._sbMain);
          this.Controls.Add(this._mmMain);
          this.IsMdiContainer = true;
          this.Name = "MainForm";
          this.Load += new System.EventHandler(this.MainForm_Load);
          this.Activated += new System.EventHandler(this.MainForm_Activated);
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
          this._sbMain.ResumeLayout(false);
          this._sbMain.PerformLayout();
          this._mmMain.ResumeLayout(false);
          this._mmMain.PerformLayout();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private StatusStrip _sbMain;
      private MenuStrip _mmMain;
      private ToolStripMenuItem _miFile;
      private ToolStripMenuItem _miFileSaveAs;
      private ToolStripMenuItem _miFileExit;
      private ToolStripMenuItem _miEdit;
      private ToolStripMenuItem _miEditCopy;
      private ToolStripMenuItem _miEditCut;
      private ToolStripMenuItem _miCapture;
      private ToolStripMenuItem _miCaptureActiveWindow;
      private ToolStripMenuItem _miCaptureActiveClient;
      private ToolStripMenuItem _miCaptureFullScreen;
      private ToolStripMenuItem _miCaptureSelectedObject;
      private ToolStripMenuItem _miCaptureMenuUnderCursor;
      private ToolStripMenuItem _miCaptureSelectedArea;
      private ToolStripMenuItem _miCaptureWallpaper;
      private ToolStripMenuItem _miCaptureMouseCursor;
      private ToolStripMenuItem _miCaptureWindowUnderCursor;
      private ToolStripSeparator toolStripSeparator1;
      private ToolStripMenuItem _miCaptureStopCapture;
      private ToolStripSeparator toolStripSeparator2;
      private ToolStripMenuItem _miCaptureFromExeDialogTree;
      private ToolStripMenuItem _miCaptureFromExeDialogTabbedView;
      private ToolStripMenuItem _miOptions;
      private ToolStripMenuItem _miOptionsCaptureOptions;
      private ToolStripMenuItem _miOptionsCaptureAreaOptions;
      private ToolStripMenuItem _miOptionsCaptureObjectOptions;
      private ToolStripSeparator toolStripSeparator3;
      private ToolStripMenuItem _miOptionsMinimizeApplicationOnCapture;
      private ToolStripMenuItem _miOptionsActivateApplicationAfterCapture;
      private ToolStripSeparator toolStripSeparator4;
      private ToolStripMenuItem _miOptionsBeepOnCapture;
      private ToolStripMenuItem _miView;
      private ToolStripMenuItem _miViewStatusBar;
      private ToolStripMenuItem _miHelp;
      private ToolStripMenuItem _miHelpAbout;
      private ToolStripStatusLabel _sbiText;
   }
}

