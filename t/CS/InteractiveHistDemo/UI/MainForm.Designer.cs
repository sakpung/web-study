using Leadtools.Codecs;

namespace InteractiveHist
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
         this._miFile = new System.Windows.Forms.ToolStripMenuItem();
         this._miFileOpen = new System.Windows.Forms.ToolStripMenuItem();
         this._miFileSave = new System.Windows.Forms.ToolStripMenuItem();
         this._miFileClose = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._menuFileHowTo = new System.Windows.Forms.ToolStripMenuItem();
         this._miFileSeperator1 = new System.Windows.Forms.ToolStripSeparator();
         this._miFileExit = new System.Windows.Forms.ToolStripMenuItem();
         this._miEdit = new System.Windows.Forms.ToolStripMenuItem();
         this._miEditUndo = new System.Windows.Forms.ToolStripMenuItem();
         this._miEditRedo = new System.Windows.Forms.ToolStripMenuItem();
         this._miEditSeperator1 = new System.Windows.Forms.ToolStripSeparator();
         this._miEditCopy = new System.Windows.Forms.ToolStripMenuItem();
         this._miEditPaste = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnalysis = new System.Windows.Forms.ToolStripMenuItem();
         this._miAnalysisInteractiveHistogram = new System.Windows.Forms.ToolStripMenuItem();
         this._miWindow = new System.Windows.Forms.ToolStripMenuItem();
         this._miWindowCascade = new System.Windows.Forms.ToolStripMenuItem();
         this._miWindowTileHorizontally = new System.Windows.Forms.ToolStripMenuItem();
         this._miWindowTileVertically = new System.Windows.Forms.ToolStripMenuItem();
         this._miWindowArrangeIcons = new System.Windows.Forms.ToolStripMenuItem();
         this._miWindowCloseAll = new System.Windows.Forms.ToolStripMenuItem();
         this._miHelp = new System.Windows.Forms.ToolStripMenuItem();
         this._miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._menuHelpHowTo = new System.Windows.Forms.ToolStripMenuItem();
         this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.magnifyGlassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemMagGlassStart = new System.Windows.Forms.ToolStripMenuItem();
         this._menuItemMagGlassStop = new System.Windows.Forms.ToolStripMenuItem();
         this._mainMenu.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenu
         // 
         this._mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFile,
            this._miEdit,
            this.viewToolStripMenuItem,
            this._miAnalysis,
            this._miWindow,
            this._miHelp});
         this._mainMenu.Location = new System.Drawing.Point(0, 0);
         this._mainMenu.Name = "_mainMenu";
         this._mainMenu.Size = new System.Drawing.Size(698, 24);
         this._mainMenu.TabIndex = 1;
         this._mainMenu.Text = "menuStrip1";
         // 
         // _miFile
         // 
         this._miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFileOpen,
            this._miFileSave,
            this._miFileClose,
            this.toolStripSeparator2,
            this._menuFileHowTo,
            this._miFileSeperator1,
            this._miFileExit});
         this._miFile.Name = "_miFile";
         this._miFile.Size = new System.Drawing.Size(37, 20);
         this._miFile.Text = "&File";
         this._miFile.DropDownOpening += new System.EventHandler(this._mi_DropDownOpening);
         // 
         // _miFileOpen
         // 
         this._miFileOpen.Name = "_miFileOpen";
         this._miFileOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this._miFileOpen.Size = new System.Drawing.Size(146, 22);
         this._miFileOpen.Text = "&Open";
         this._miFileOpen.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileSave
         // 
         this._miFileSave.Name = "_miFileSave";
         this._miFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
         this._miFileSave.Size = new System.Drawing.Size(146, 22);
         this._miFileSave.Text = "&Save";
         this._miFileSave.Click += new System.EventHandler(this._miFileSave_Click);
         // 
         // _miFileClose
         // 
         this._miFileClose.Name = "_miFileClose";
         this._miFileClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
         this._miFileClose.Size = new System.Drawing.Size(146, 22);
         this._miFileClose.Text = "&Close";
         this._miFileClose.Click += new System.EventHandler(this._miFileClose_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
         // 
         // _menuFileHowTo
         // 
         this._menuFileHowTo.Name = "_menuFileHowTo";
         this._menuFileHowTo.Size = new System.Drawing.Size(146, 22);
         this._menuFileHowTo.Text = "&How To...";
         this._menuFileHowTo.Click += new System.EventHandler(this._menuFileHowTo_Click);
         // 
         // _miFileSeperator1
         // 
         this._miFileSeperator1.Name = "_miFileSeperator1";
         this._miFileSeperator1.Size = new System.Drawing.Size(143, 6);
         // 
         // _miFileExit
         // 
         this._miFileExit.Name = "_miFileExit";
         this._miFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
         this._miFileExit.Size = new System.Drawing.Size(146, 22);
         this._miFileExit.Text = "&Exit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miEdit
         // 
         this._miEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miEditUndo,
            this._miEditRedo,
            this._miEditSeperator1,
            this._miEditCopy,
            this._miEditPaste});
         this._miEdit.Name = "_miEdit";
         this._miEdit.Size = new System.Drawing.Size(39, 20);
         this._miEdit.Text = "&Edit";
         this._miEdit.DropDownOpening += new System.EventHandler(this._mi_DropDownOpening);
         // 
         // _miEditUndo
         // 
         this._miEditUndo.Name = "_miEditUndo";
         this._miEditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
         this._miEditUndo.Size = new System.Drawing.Size(152, 22);
         this._miEditUndo.Text = "&Undo";
         this._miEditUndo.Click += new System.EventHandler(this._miEditUndo_Click);
         // 
         // _miEditRedo
         // 
         this._miEditRedo.Name = "_miEditRedo";
         this._miEditRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
         this._miEditRedo.Size = new System.Drawing.Size(152, 22);
         this._miEditRedo.Text = "&Redo";
         this._miEditRedo.Click += new System.EventHandler(this._miEditRedo_Click);
         // 
         // _miEditSeperator1
         // 
         this._miEditSeperator1.Name = "_miEditSeperator1";
         this._miEditSeperator1.Size = new System.Drawing.Size(149, 6);
         // 
         // _miEditCopy
         // 
         this._miEditCopy.Name = "_miEditCopy";
         this._miEditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
         this._miEditCopy.Size = new System.Drawing.Size(152, 22);
         this._miEditCopy.Text = "&Copy";
         this._miEditCopy.Click += new System.EventHandler(this._miEditCopy_Click);
         // 
         // _miEditPaste
         // 
         this._miEditPaste.Name = "_miEditPaste";
         this._miEditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
         this._miEditPaste.Size = new System.Drawing.Size(152, 22);
         this._miEditPaste.Text = "&Paste";
         this._miEditPaste.Click += new System.EventHandler(this._miEditPaste_Click);
         // 
         // _miAnalysis
         // 
         this._miAnalysis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miAnalysisInteractiveHistogram});
         this._miAnalysis.Name = "_miAnalysis";
         this._miAnalysis.Size = new System.Drawing.Size(62, 20);
         this._miAnalysis.Text = "&Analysis";
         // 
         // _miAnalysisInteractiveHistogram
         // 
         this._miAnalysisInteractiveHistogram.Name = "_miAnalysisInteractiveHistogram";
         this._miAnalysisInteractiveHistogram.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
         this._miAnalysisInteractiveHistogram.Size = new System.Drawing.Size(225, 22);
         this._miAnalysisInteractiveHistogram.Text = "&Interactive Histogram";
         this._miAnalysisInteractiveHistogram.Click += new System.EventHandler(this._miAnalysisInteractiveHistogram_Click);
         // 
         // _miWindow
         // 
         this._miWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miWindowCascade,
            this._miWindowTileHorizontally,
            this._miWindowTileVertically,
            this._miWindowArrangeIcons,
            this._miWindowCloseAll});
         this._miWindow.Name = "_miWindow";
         this._miWindow.Size = new System.Drawing.Size(63, 20);
         this._miWindow.Text = "&Window";
         // 
         // _miWindowCascade
         // 
         this._miWindowCascade.Name = "_miWindowCascade";
         this._miWindowCascade.Size = new System.Drawing.Size(160, 22);
         this._miWindowCascade.Text = "&Cascade";
         this._miWindowCascade.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowTileHorizontally
         // 
         this._miWindowTileHorizontally.Name = "_miWindowTileHorizontally";
         this._miWindowTileHorizontally.Size = new System.Drawing.Size(160, 22);
         this._miWindowTileHorizontally.Text = "Tile &Horizontally";
         this._miWindowTileHorizontally.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowTileVertically
         // 
         this._miWindowTileVertically.Name = "_miWindowTileVertically";
         this._miWindowTileVertically.Size = new System.Drawing.Size(160, 22);
         this._miWindowTileVertically.Text = "Tile &Vertically";
         this._miWindowTileVertically.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowArrangeIcons
         // 
         this._miWindowArrangeIcons.Name = "_miWindowArrangeIcons";
         this._miWindowArrangeIcons.Size = new System.Drawing.Size(160, 22);
         this._miWindowArrangeIcons.Text = "Arrange &Icons";
         this._miWindowArrangeIcons.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowCloseAll
         // 
         this._miWindowCloseAll.Name = "_miWindowCloseAll";
         this._miWindowCloseAll.Size = new System.Drawing.Size(160, 22);
         this._miWindowCloseAll.Text = "Close &All";
         this._miWindowCloseAll.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miHelp
         // 
         this._miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miHelpAbout,
            this.toolStripSeparator1,
            this._menuHelpHowTo});
         this._miHelp.Name = "_miHelp";
         this._miHelp.Size = new System.Drawing.Size(44, 20);
         this._miHelp.Text = "&Help";
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Name = "_miHelpAbout";
         this._miHelpAbout.Size = new System.Drawing.Size(152, 22);
         this._miHelpAbout.Text = "&About";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
         // 
         // _menuHelpHowTo
         // 
         this._menuHelpHowTo.Name = "_menuHelpHowTo";
         this._menuHelpHowTo.Size = new System.Drawing.Size(152, 22);
         this._menuHelpHowTo.Text = "&How To...";
         this._menuHelpHowTo.Click += new System.EventHandler(this._menuHelpHowTo_Click);
         // 
         // viewToolStripMenuItem
         // 
         this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.magnifyGlassToolStripMenuItem});
         this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
         this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.viewToolStripMenuItem.Text = "View";
         // 
         // magnifyGlassToolStripMenuItem
         // 
         this.magnifyGlassToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuItemMagGlassStart,
            this._menuItemMagGlassStop});
         this.magnifyGlassToolStripMenuItem.Name = "magnifyGlassToolStripMenuItem";
         this.magnifyGlassToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.magnifyGlassToolStripMenuItem.Text = "Magnify Glass";
         // 
         // _menuItemMagGlassStart
         // 
         this._menuItemMagGlassStart.Name = "_menuItemMagGlassStart";
         this._menuItemMagGlassStart.Size = new System.Drawing.Size(152, 22);
         this._menuItemMagGlassStart.Text = "Start";
         this._menuItemMagGlassStart.Click += new System.EventHandler(this._menuItemMagGlassStart_Click);
         // 
         // _menuItemMagGlassStop
         // 
         this._menuItemMagGlassStop.Name = "_menuItemMagGlassStop";
         this._menuItemMagGlassStop.Size = new System.Drawing.Size(152, 22);
         this._menuItemMagGlassStop.Text = "Stop";
         this._menuItemMagGlassStop.Click += new System.EventHandler(this._menuItemMagGlassStop_Click);
         // 
         // MainForm
         // 
         this.AllowDrop = true;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(698, 512);
         this.Controls.Add(this._mainMenu);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.IsMdiContainer = true;
         this.MainMenuStrip = this._mainMenu;
         this.Name = "MainForm";
         this.Text = "Interactive Histogram Demo";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
         this._mainMenu.ResumeLayout(false);
         this._mainMenu.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _mainMenu;
      private System.Windows.Forms.ToolStripMenuItem _miFile;
      private System.Windows.Forms.ToolStripMenuItem _miFileOpen;
      private System.Windows.Forms.ToolStripMenuItem _miFileSave;
      private System.Windows.Forms.ToolStripMenuItem _miFileClose;
      private System.Windows.Forms.ToolStripSeparator _miFileSeperator1;
      private System.Windows.Forms.ToolStripMenuItem _miFileExit;
      private System.Windows.Forms.ToolStripMenuItem _miEdit;
      private System.Windows.Forms.ToolStripMenuItem _miEditUndo;
      private System.Windows.Forms.ToolStripMenuItem _miEditRedo;
      private System.Windows.Forms.ToolStripSeparator _miEditSeperator1;
      private System.Windows.Forms.ToolStripMenuItem _miEditCopy;
      private System.Windows.Forms.ToolStripMenuItem _miEditPaste;
      private System.Windows.Forms.ToolStripMenuItem _miAnalysis;
      private System.Windows.Forms.ToolStripMenuItem _miAnalysisInteractiveHistogram;
      private System.Windows.Forms.ToolStripMenuItem _miWindow;
      private System.Windows.Forms.ToolStripMenuItem _miWindowCascade;
      private System.Windows.Forms.ToolStripMenuItem _miWindowTileHorizontally;
      private System.Windows.Forms.ToolStripMenuItem _miWindowTileVertically;
      private System.Windows.Forms.ToolStripMenuItem _miWindowArrangeIcons;
      private System.Windows.Forms.ToolStripMenuItem _miWindowCloseAll;
      private System.Windows.Forms.ToolStripMenuItem _miHelp;
      private System.Windows.Forms.ToolStripMenuItem _miHelpAbout;
      private System.Windows.Forms.ToolStripMenuItem _menuHelpHowTo;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripMenuItem _menuFileHowTo;
      private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem magnifyGlassToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _menuItemMagGlassStart;
      private System.Windows.Forms.ToolStripMenuItem _menuItemMagGlassStop;
   }
}
