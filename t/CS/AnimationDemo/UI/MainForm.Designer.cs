namespace AnimationDemo
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
         this._mainMenu = new System.Windows.Forms.MenuStrip();
         this._menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemFileOpen = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemFileSave = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemFileSep5 = new System.Windows.Forms.ToolStripSeparator();
         this._menuItemFileExit = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemEditCopy = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemEditPaste = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAnimation = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAnimationCreate = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._menuItemAnimationFrameSettings = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemBackground = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAnimationOptimizeColors = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAnimationLoop = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._menuItemAnimationPlay = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemAnimationPause = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemPage = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemPageFirst = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemPagePrevious = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemPageNext = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemPageLast = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemPageSep1 = new System.Windows.Forms.ToolStripSeparator();
         this._menuItemPageAdd = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemPageDeleteCurrentPage = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemView = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemViewSizeMode = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemViewSizeModeNormal = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemViewSizeModeStretch = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemViewSizeModeCenter = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemViewSizeModeZoom = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemViewSizeModeAuto = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemPreferences = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemPreferencesPaintProperties = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemPreferencesUseDpi = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemWindow = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemWindowCascade = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemWindowTileHorizontally = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemWindowTileVertically = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemWindowArrangeIcons = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemWindowCloseAll = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
         this._mainMenu.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenu
         // 
         this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemFile,
            this._menuItemEdit,
            this._menuItemAnimation,
            this._menuItemPage,
            this._menuItemView,
            this._menuItemPreferences,
            this._menuItemWindow,
            this._menuItemHelp});
         this._mainMenu.Location = new System.Drawing.Point(0, 0);
         this._mainMenu.Name = "_mainMenu";
         this._mainMenu.Padding = new System.Windows.Forms.Padding(2, 2, 0, 2);
         this._mainMenu.Size = new System.Drawing.Size(749, 23);
         this._mainMenu.Stretch = false;
         this._mainMenu.TabIndex = 1;
         this._mainMenu.Text = "menuStrip1";
         // 
         // _menuItemFile
         // 
         this._menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemFileOpen,
            this._menuItemFileSave,
            this._menuItemFileSep5,
            this._menuItemFileExit});
         this._menuItemFile.Name = "_menuItemFile";
         this._menuItemFile.Size = new System.Drawing.Size(35, 17);
         this._menuItemFile.Text = "&File";
         // 
         // _menuItemFileOpen
         // 
         this._menuItemFileOpen.Name = "_menuItemFileOpen";
         this._menuItemFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this._menuItemFileOpen.Size = new System.Drawing.Size(152, 22);
         this._menuItemFileOpen.Text = "&Open...";
         this._menuItemFileOpen.Click += new System.EventHandler(this._menuItemFileOpen_Click);
         // 
         // _menuItemFileSave
         // 
         this._menuItemFileSave.Name = "_menuItemFileSave";
         this._menuItemFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
         this._menuItemFileSave.Size = new System.Drawing.Size(152, 22);
         this._menuItemFileSave.Text = "&Save...";
         this._menuItemFileSave.Click += new System.EventHandler(this._menuItemFileSave_Click);
         // 
         // _menuItemFileSep5
         // 
         this._menuItemFileSep5.Name = "_menuItemFileSep5";
         this._menuItemFileSep5.Size = new System.Drawing.Size(149, 6);
         // 
         // _menuItemFileExit
         // 
         this._menuItemFileExit.Name = "_menuItemFileExit";
         this._menuItemFileExit.Size = new System.Drawing.Size(152, 22);
         this._menuItemFileExit.Text = "E&xit";
         this._menuItemFileExit.Click += new System.EventHandler(this._menuItemFileExit_Click);
         // 
         // _menuItemEdit
         // 
         this._menuItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemEditCopy,
            this._menuItemEditPaste});
         this._menuItemEdit.Name = "_menuItemEdit";
         this._menuItemEdit.Size = new System.Drawing.Size(37, 17);
         this._menuItemEdit.Text = "&Edit";
         this._menuItemEdit.DropDownOpened += new System.EventHandler(this._menuItemEdit_DropDownOpened);
         // 
         // _menuItemEditCopy
         // 
         this._menuItemEditCopy.Name = "_menuItemEditCopy";
         this._menuItemEditCopy.Size = new System.Drawing.Size(101, 22);
         this._menuItemEditCopy.Text = "&Copy";
         this._menuItemEditCopy.Click += new System.EventHandler(this._menuItemEditCopy_Click);
         // 
         // _menuItemEditPaste
         // 
         this._menuItemEditPaste.Name = "_menuItemEditPaste";
         this._menuItemEditPaste.Size = new System.Drawing.Size(101, 22);
         this._menuItemEditPaste.Text = "&Paste";
         this._menuItemEditPaste.Click += new System.EventHandler(this._menuItemEditPaste_Click);
         // 
         // _menuItemAnimation
         // 
         this._menuItemAnimation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemAnimationCreate,
            this.toolStripSeparator2,
            this._menuItemAnimationFrameSettings,
            this._menuItemBackground,
            this._menuItemAnimationOptimizeColors,
            this._menuItemAnimationLoop,
            this.toolStripSeparator1,
            this._menuItemAnimationPlay,
            this._menuItemAnimationPause});
         this._menuItemAnimation.Name = "_menuItemAnimation";
         this._menuItemAnimation.Size = new System.Drawing.Size(66, 17);
         this._menuItemAnimation.Text = "&Animation";
         // 
         // _menuItemAnimationCreate
         // 
         this._menuItemAnimationCreate.Name = "_menuItemAnimationCreate";
         this._menuItemAnimationCreate.Size = new System.Drawing.Size(160, 22);
         this._menuItemAnimationCreate.Text = "Create";
         this._menuItemAnimationCreate.Click += new System.EventHandler(this._menuItemAnimationCreate_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
         // 
         // _menuItemAnimationFrameSettings
         // 
         this._menuItemAnimationFrameSettings.Name = "_menuItemAnimationFrameSettings";
         this._menuItemAnimationFrameSettings.Size = new System.Drawing.Size(160, 22);
         this._menuItemAnimationFrameSettings.Text = "&Frame Settings...";
         this._menuItemAnimationFrameSettings.Click += new System.EventHandler(this._menuItemAnimationFrameSettings_Click);
         // 
         // _menuItemBackground
         // 
         this._menuItemBackground.Name = "_menuItemBackground";
         this._menuItemBackground.Size = new System.Drawing.Size(160, 22);
         this._menuItemBackground.Text = "&Background...";
         this._menuItemBackground.Click += new System.EventHandler(this._menuItemBackground_Click);
         // 
         // _menuItemAnimationOptimizeColors
         // 
         this._menuItemAnimationOptimizeColors.Name = "_menuItemAnimationOptimizeColors";
         this._menuItemAnimationOptimizeColors.Size = new System.Drawing.Size(160, 22);
         this._menuItemAnimationOptimizeColors.Text = "&Optimize Colors...";
         this._menuItemAnimationOptimizeColors.Click += new System.EventHandler(this._menuItemAnimationOptimizeColors_Click);
         // 
         // _menuItemAnimationLoop
         // 
         this._menuItemAnimationLoop.Checked = true;
         this._menuItemAnimationLoop.CheckState = System.Windows.Forms.CheckState.Checked;
         this._menuItemAnimationLoop.Name = "_menuItemAnimationLoop";
         this._menuItemAnimationLoop.Size = new System.Drawing.Size(160, 22);
         this._menuItemAnimationLoop.Text = "&Loop";
         this._menuItemAnimationLoop.Click += new System.EventHandler(this._menuItemAnimationLoop_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
         // 
         // _menuItemAnimationPlay
         // 
         this._menuItemAnimationPlay.Name = "_menuItemAnimationPlay";
         this._menuItemAnimationPlay.Size = new System.Drawing.Size(160, 22);
         this._menuItemAnimationPlay.Text = "Pl&ay";
         this._menuItemAnimationPlay.Click += new System.EventHandler(this._menuItemAnimationPlay_Click);
         // 
         // _menuItemAnimationPause
         // 
         this._menuItemAnimationPause.Name = "_menuItemAnimationPause";
         this._menuItemAnimationPause.Size = new System.Drawing.Size(160, 22);
         this._menuItemAnimationPause.Text = "&Pause";
         this._menuItemAnimationPause.Click += new System.EventHandler(this._menuItemAnimationPause_Click);
         // 
         // _menuItemPage
         // 
         this._menuItemPage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemPageFirst,
            this._menuItemPagePrevious,
            this._menuItemPageNext,
            this._menuItemPageLast,
            this._menuItemPageSep1,
            this._menuItemPageAdd,
            this._menuItemPageDeleteCurrentPage});
         this._menuItemPage.Name = "_menuItemPage";
         this._menuItemPage.Size = new System.Drawing.Size(69, 17);
         this._menuItemPage.Text = "&Multi-Page";
         // 
         // _menuItemPageFirst
         // 
         this._menuItemPageFirst.Name = "_menuItemPageFirst";
         this._menuItemPageFirst.Size = new System.Drawing.Size(172, 22);
         this._menuItemPageFirst.Text = "&First";
         this._menuItemPageFirst.Click += new System.EventHandler(this._menuItemPage_Click);
         // 
         // _menuItemPagePrevious
         // 
         this._menuItemPagePrevious.Name = "_menuItemPagePrevious";
         this._menuItemPagePrevious.Size = new System.Drawing.Size(172, 22);
         this._menuItemPagePrevious.Text = "&Previous";
         this._menuItemPagePrevious.Click += new System.EventHandler(this._menuItemPage_Click);
         // 
         // _menuItemPageNext
         // 
         this._menuItemPageNext.Name = "_menuItemPageNext";
         this._menuItemPageNext.Size = new System.Drawing.Size(172, 22);
         this._menuItemPageNext.Text = "&Next";
         this._menuItemPageNext.Click += new System.EventHandler(this._menuItemPage_Click);
         // 
         // _menuItemPageLast
         // 
         this._menuItemPageLast.Name = "_menuItemPageLast";
         this._menuItemPageLast.Size = new System.Drawing.Size(172, 22);
         this._menuItemPageLast.Text = "&Last";
         this._menuItemPageLast.Click += new System.EventHandler(this._menuItemPage_Click);
         // 
         // _menuItemPageSep1
         // 
         this._menuItemPageSep1.Name = "_menuItemPageSep1";
         this._menuItemPageSep1.Size = new System.Drawing.Size(169, 6);
         // 
         // _menuItemPageAdd
         // 
         this._menuItemPageAdd.Name = "_menuItemPageAdd";
         this._menuItemPageAdd.Size = new System.Drawing.Size(172, 22);
         this._menuItemPageAdd.Text = "&Add...";
         this._menuItemPageAdd.Click += new System.EventHandler(this._menuItemPageAdd_Click);
         // 
         // _menuItemPageDeleteCurrentPage
         // 
         this._menuItemPageDeleteCurrentPage.Name = "_menuItemPageDeleteCurrentPage";
         this._menuItemPageDeleteCurrentPage.Size = new System.Drawing.Size(172, 22);
         this._menuItemPageDeleteCurrentPage.Text = "&Delete Current Page";
         this._menuItemPageDeleteCurrentPage.Click += new System.EventHandler(this._menuItemPageDeleteCurrentPage_Click);
         // 
         // _menuItemView
         // 
         this._menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemViewSizeMode});
         this._menuItemView.Name = "_menuItemView";
         this._menuItemView.Size = new System.Drawing.Size(41, 17);
         this._menuItemView.Text = "&View";
         // 
         // _menuItemViewSizeMode
         // 
         this._menuItemViewSizeMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemViewSizeModeNormal,
            this._menuItemViewSizeModeStretch,
            this._menuItemViewSizeModeCenter,
            this._menuItemViewSizeModeZoom,
            this._menuItemViewSizeModeAuto});
         this._menuItemViewSizeMode.Name = "_menuItemViewSizeMode";
         this._menuItemViewSizeMode.Size = new System.Drawing.Size(152, 22);
         this._menuItemViewSizeMode.Text = "&Size Mode";
         // 
         // _menuItemViewSizeModeNormal
         // 
         this._menuItemViewSizeModeNormal.Name = "_menuItemViewSizeModeNormal";
         this._menuItemViewSizeModeNormal.Size = new System.Drawing.Size(152, 22);
         this._menuItemViewSizeModeNormal.Text = "&Normal";
         this._menuItemViewSizeModeNormal.Click += new System.EventHandler(this._menuItemViewSizeMode_Click);
         // 
         // _menuItemViewSizeModeStretch
         // 
         this._menuItemViewSizeModeStretch.Name = "_menuItemViewSizeModeStretch";
         this._menuItemViewSizeModeStretch.Size = new System.Drawing.Size(152, 22);
         this._menuItemViewSizeModeStretch.Text = "&Stretch";
         this._menuItemViewSizeModeStretch.Click += new System.EventHandler(this._menuItemViewSizeMode_Click);
         // 
         // _menuItemViewSizeModeCenter
         // 
         this._menuItemViewSizeModeCenter.Name = "_menuItemViewSizeModeCenter";
         this._menuItemViewSizeModeCenter.Size = new System.Drawing.Size(152, 22);
         this._menuItemViewSizeModeCenter.Text = "&Center";
         this._menuItemViewSizeModeCenter.Click += new System.EventHandler(this._menuItemViewSizeMode_Click);
         // 
         // _menuItemViewSizeModeZoom
         // 
         this._menuItemViewSizeModeZoom.Name = "_menuItemViewSizeModeZoom";
         this._menuItemViewSizeModeZoom.Size = new System.Drawing.Size(152, 22);
         this._menuItemViewSizeModeZoom.Text = "&Fit";
         this._menuItemViewSizeModeZoom.Click += new System.EventHandler(this._menuItemViewSizeMode_Click);
         // 
         // _menuItemViewSizeModeAuto
         // 
         this._menuItemViewSizeModeAuto.Name = "_menuItemViewSizeModeAuto";
         this._menuItemViewSizeModeAuto.Size = new System.Drawing.Size(152, 22);
         this._menuItemViewSizeModeAuto.Text = "&Auto";
         this._menuItemViewSizeModeAuto.Click += new System.EventHandler(this._menuItemViewSizeMode_Click);
         // 
         // _menuItemPreferences
         // 
         this._menuItemPreferences.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemPreferencesPaintProperties,
            this._menuItemPreferencesUseDpi});
         this._menuItemPreferences.Name = "_menuItemPreferences";
         this._menuItemPreferences.Size = new System.Drawing.Size(77, 17);
         this._menuItemPreferences.Text = "P&references";
         // 
         // _menuItemPreferencesPaintProperties
         // 
         this._menuItemPreferencesPaintProperties.Name = "_menuItemPreferencesPaintProperties";
         this._menuItemPreferencesPaintProperties.Size = new System.Drawing.Size(162, 22);
         this._menuItemPreferencesPaintProperties.Text = "Pa&int Properties...";
         this._menuItemPreferencesPaintProperties.Click += new System.EventHandler(this._menuItemPreferencesPaintProperties_Click);
         // 
         // _menuItemPreferencesUseDpi
         // 
         this._menuItemPreferencesUseDpi.Checked = true;
         this._menuItemPreferencesUseDpi.CheckState = System.Windows.Forms.CheckState.Checked;
         this._menuItemPreferencesUseDpi.Name = "_menuItemPreferencesUseDpi";
         this._menuItemPreferencesUseDpi.Size = new System.Drawing.Size(162, 22);
         this._menuItemPreferencesUseDpi.Text = "&Use Dpi";
         this._menuItemPreferencesUseDpi.Click += new System.EventHandler(this._menuItemPreferencesUseDpi_Click);
         // 
         // _menuItemWindow
         // 
         this._menuItemWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemWindowCascade,
            this._menuItemWindowTileHorizontally,
            this._menuItemWindowTileVertically,
            this._menuItemWindowArrangeIcons,
            this._menuItemWindowCloseAll});
         this._menuItemWindow.Name = "_menuItemWindow";
         this._menuItemWindow.Size = new System.Drawing.Size(57, 17);
         this._menuItemWindow.Text = "&Window";
         // 
         // _menuItemWindowCascade
         // 
         this._menuItemWindowCascade.Name = "_menuItemWindowCascade";
         this._menuItemWindowCascade.Size = new System.Drawing.Size(149, 22);
         this._menuItemWindowCascade.Text = "&Cascade";
         this._menuItemWindowCascade.Click += new System.EventHandler(this._menuItemWindow_Click);
         // 
         // _menuItemWindowTileHorizontally
         // 
         this._menuItemWindowTileHorizontally.Name = "_menuItemWindowTileHorizontally";
         this._menuItemWindowTileHorizontally.Size = new System.Drawing.Size(149, 22);
         this._menuItemWindowTileHorizontally.Text = "Tile &Horizontally";
         this._menuItemWindowTileHorizontally.Click += new System.EventHandler(this._menuItemWindow_Click);
         // 
         // _menuItemWindowTileVertically
         // 
         this._menuItemWindowTileVertically.Name = "_menuItemWindowTileVertically";
         this._menuItemWindowTileVertically.Size = new System.Drawing.Size(149, 22);
         this._menuItemWindowTileVertically.Text = "Tile &Vertically";
         this._menuItemWindowTileVertically.Click += new System.EventHandler(this._menuItemWindow_Click);
         // 
         // _menuItemWindowArrangeIcons
         // 
         this._menuItemWindowArrangeIcons.Name = "_menuItemWindowArrangeIcons";
         this._menuItemWindowArrangeIcons.Size = new System.Drawing.Size(149, 22);
         this._menuItemWindowArrangeIcons.Text = "Arrange &Icons";
         this._menuItemWindowArrangeIcons.Click += new System.EventHandler(this._menuItemWindow_Click);
         // 
         // _menuItemWindowCloseAll
         // 
         this._menuItemWindowCloseAll.Name = "_menuItemWindowCloseAll";
         this._menuItemWindowCloseAll.Size = new System.Drawing.Size(149, 22);
         this._menuItemWindowCloseAll.Text = "Close &All";
         this._menuItemWindowCloseAll.Click += new System.EventHandler(this._menuItemWindow_Click);
         // 
         // _menuItemHelp
         // 
         this._menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemHelpAbout});
         this._menuItemHelp.Name = "_menuItemHelp";
         this._menuItemHelp.Size = new System.Drawing.Size(40, 17);
         this._menuItemHelp.Text = "&Help";
         // 
         // _menuItemHelpAbout
         // 
         this._menuItemHelpAbout.Name = "_menuItemHelpAbout";
         this._menuItemHelpAbout.Size = new System.Drawing.Size(115, 22);
         this._menuItemHelpAbout.Text = "&About...";
         this._menuItemHelpAbout.Click += new System.EventHandler(this._menuItemHelpAbout_Click);
         // 
         // MainForm
         // 
         this.AllowDrop = true;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
         this.ClientSize = new System.Drawing.Size(749, 454);
         this.Controls.Add(this._mainMenu);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.IsMdiContainer = true;
         this.MainMenuStrip = this._mainMenu;
         this.Margin = new System.Windows.Forms.Padding(2);
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
         this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
         this._mainMenu.ResumeLayout(false);
         this._mainMenu.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }
      #endregion

      private System.Windows.Forms.MenuStrip _mainMenu;
      private System.Windows.Forms.ToolStripMenuItem _menuItemFile;
      private System.Windows.Forms.ToolStripMenuItem _menuItemEdit;
      private System.Windows.Forms.ToolStripMenuItem _menuItemPage;
      private System.Windows.Forms.ToolStripMenuItem _menuItemView;
      private System.Windows.Forms.ToolStripMenuItem _menuItemPreferences;
      private System.Windows.Forms.ToolStripMenuItem _menuItemWindow;
      private System.Windows.Forms.ToolStripMenuItem _menuItemHelp;
      private System.Windows.Forms.ToolStripMenuItem _menuItemFileOpen;
      private System.Windows.Forms.ToolStripMenuItem _menuItemFileSave;
      private System.Windows.Forms.ToolStripSeparator _menuItemFileSep5;
      private System.Windows.Forms.ToolStripMenuItem _menuItemFileExit;
      private System.Windows.Forms.ToolStripMenuItem _menuItemEditCopy;
      private System.Windows.Forms.ToolStripMenuItem _menuItemEditPaste;
      private System.Windows.Forms.ToolStripMenuItem _menuItemPageFirst;
      private System.Windows.Forms.ToolStripMenuItem _menuItemPagePrevious;
      private System.Windows.Forms.ToolStripMenuItem _menuItemPageNext;
      private System.Windows.Forms.ToolStripMenuItem _menuItemPageLast;
      private System.Windows.Forms.ToolStripSeparator _menuItemPageSep1;
      private System.Windows.Forms.ToolStripMenuItem _menuItemPageAdd;
      private System.Windows.Forms.ToolStripMenuItem _menuItemPageDeleteCurrentPage;
      private System.Windows.Forms.ToolStripMenuItem _menuItemViewSizeMode;
      private System.Windows.Forms.ToolStripMenuItem _menuItemViewSizeModeStretch;
      private System.Windows.Forms.ToolStripMenuItem _menuItemViewSizeModeCenter;
      private System.Windows.Forms.ToolStripMenuItem _menuItemViewSizeModeZoom;
      private System.Windows.Forms.ToolStripMenuItem _menuItemViewSizeModeAuto;
      private System.Windows.Forms.ToolStripMenuItem _menuItemWindowCascade;
      private System.Windows.Forms.ToolStripMenuItem _menuItemWindowTileHorizontally;
      private System.Windows.Forms.ToolStripMenuItem _menuItemWindowTileVertically;
      private System.Windows.Forms.ToolStripMenuItem _menuItemWindowArrangeIcons;
      private System.Windows.Forms.ToolStripMenuItem _menuItemWindowCloseAll;
      private System.Windows.Forms.ToolStripMenuItem _menuItemHelpAbout;
      private System.Windows.Forms.ToolStripMenuItem _menuItemPreferencesPaintProperties;
      private System.Windows.Forms.ToolStripMenuItem _menuItemPreferencesUseDpi;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAnimation;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAnimationFrameSettings;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAnimationOptimizeColors;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAnimationLoop;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAnimationPause;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAnimationPlay;
      private System.Windows.Forms.ToolStripMenuItem _menuItemAnimationCreate;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem _menuItemViewSizeModeNormal;
      private System.Windows.Forms.ToolStripMenuItem _menuItemBackground;

   }
}