namespace ImageViewerDemo
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
         this._mainMenuStrip = new System.Windows.Forms.MenuStrip();
         this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._layoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._singleLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._verticalLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._doubleLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._horizontalLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._topPanel = new System.Windows.Forms.Panel();
         this._imageInfoLabel = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._mainMenuStrip.SuspendLayout();
         this._topPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenuStrip
         // 
         this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._layoutToolStripMenuItem,
            this._helpToolStripMenuItem});
         this._mainMenuStrip.Location = new System.Drawing.Point(0, 0);
         this._mainMenuStrip.Name = "_mainMenuStrip";
         this._mainMenuStrip.Size = new System.Drawing.Size(936, 24);
         this._mainMenuStrip.TabIndex = 0;
         // 
         // _fileToolStripMenuItem
         // 
         this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openToolStripMenuItem,
            this._fileSep1ToolStripMenuItem,
            this._exitToolStripMenuItem});
         this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
         this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this._fileToolStripMenuItem.Text = "&File";
         // 
         // _openToolStripMenuItem
         // 
         this._openToolStripMenuItem.Name = "_openToolStripMenuItem";
         this._openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this._openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
         this._openToolStripMenuItem.Text = "&Open...";
         this._openToolStripMenuItem.ToolTipText = "Load an image file";
         this._openToolStripMenuItem.Click += new System.EventHandler(this._openToolStripMenuItem_Click);
         // 
         // _fileSep1ToolStripMenuItem
         // 
         this._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem";
         this._fileSep1ToolStripMenuItem.Size = new System.Drawing.Size(152, 6);
         // 
         // _exitToolStripMenuItem
         // 
         this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
         this._exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
         this._exitToolStripMenuItem.Text = "E&xit";
         this._exitToolStripMenuItem.ToolTipText = "Exit this application";
         this._exitToolStripMenuItem.Click += new System.EventHandler(this._exitToolStripMenuItem_Click);
         // 
         // _layoutToolStripMenuItem
         // 
         this._layoutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._singleLayoutToolStripMenuItem,
            this._verticalLayoutToolStripMenuItem,
            this._doubleLayoutToolStripMenuItem,
            this._horizontalLayoutToolStripMenuItem});
         this._layoutToolStripMenuItem.Name = "_layoutToolStripMenuItem";
         this._layoutToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
         this._layoutToolStripMenuItem.Text = "&Layout";
         this._layoutToolStripMenuItem.DropDownOpening += new System.EventHandler(this._layoutToolStripMenuItem_DropDownOpening);
         // 
         // _singleLayoutToolStripMenuItem
         // 
         this._singleLayoutToolStripMenuItem.Name = "_singleLayoutToolStripMenuItem";
         this._singleLayoutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
         this._singleLayoutToolStripMenuItem.Text = "&Single";
         this._singleLayoutToolStripMenuItem.ToolTipText = "Single page display";
         this._singleLayoutToolStripMenuItem.Click += new System.EventHandler(this._layoutToolStripMenuItem_Click);
         // 
         // _verticalLayoutToolStripMenuItem
         // 
         this._verticalLayoutToolStripMenuItem.Name = "_verticalLayoutToolStripMenuItem";
         this._verticalLayoutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
         this._verticalLayoutToolStripMenuItem.Text = "&Vertical";
         this._verticalLayoutToolStripMenuItem.ToolTipText = "Vertical page display";
         this._verticalLayoutToolStripMenuItem.Click += new System.EventHandler(this._layoutToolStripMenuItem_Click);
         // 
         // _doubleLayoutToolStripMenuItem
         // 
         this._doubleLayoutToolStripMenuItem.Name = "_doubleLayoutToolStripMenuItem";
         this._doubleLayoutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
         this._doubleLayoutToolStripMenuItem.Text = "&Double";
         this._doubleLayoutToolStripMenuItem.ToolTipText = "Double page display";
         this._doubleLayoutToolStripMenuItem.Click += new System.EventHandler(this._layoutToolStripMenuItem_Click);
         // 
         // _horizontalLayoutToolStripMenuItem
         // 
         this._horizontalLayoutToolStripMenuItem.Name = "_horizontalLayoutToolStripMenuItem";
         this._horizontalLayoutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
         this._horizontalLayoutToolStripMenuItem.Text = "&Horizontal";
         this._horizontalLayoutToolStripMenuItem.ToolTipText = "Horizontal page display";
         this._horizontalLayoutToolStripMenuItem.Click += new System.EventHandler(this._layoutToolStripMenuItem_Click);
         // 
         // _helpToolStripMenuItem
         // 
         this._helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
         this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
         this._helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this._helpToolStripMenuItem.Text = "&Help";
         // 
         // _aboutToolStripMenuItem
         // 
         this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
         this._aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
         this._aboutToolStripMenuItem.Text = "&About...";
         this._aboutToolStripMenuItem.ToolTipText = "About this demo";
         this._aboutToolStripMenuItem.Click += new System.EventHandler(this._aboutToolStripMenuItem_Click);
         // 
         // _topPanel
         // 
         this._topPanel.Controls.Add(this._imageInfoLabel);
         this._topPanel.Controls.Add(this.label1);
         this._topPanel.Dock = System.Windows.Forms.DockStyle.Top;
         this._topPanel.Location = new System.Drawing.Point(0, 24);
         this._topPanel.Name = "_topPanel";
         this._topPanel.Size = new System.Drawing.Size(936, 56);
         this._topPanel.TabIndex = 1;
         // 
         // _imageInfoLabel
         // 
         this._imageInfoLabel.AutoSize = true;
         this._imageInfoLabel.Location = new System.Drawing.Point(4, 29);
         this._imageInfoLabel.Name = "_imageInfoLabel";
         this._imageInfoLabel.Size = new System.Drawing.Size(85, 13);
         this._imageInfoLabel.TabIndex = 2;
         this._imageInfoLabel.Text = "_imageInfoLabel";
         this._imageInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(4, 4);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(732, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Load an image then click and drag the mouse to pan, ctrl+click to zoom in and out" +
    ", double click to reset the view. Select the Layout to use from the menu.";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(936, 491);
         this.Controls.Add(this._topPanel);
         this.Controls.Add(this._mainMenuStrip);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._mainMenuStrip;
         this.Name = "MainForm";
         this.Text = "MainForm";
         this._mainMenuStrip.ResumeLayout(false);
         this._mainMenuStrip.PerformLayout();
         this._topPanel.ResumeLayout(false);
         this._topPanel.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _mainMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _openToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _fileSep1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _layoutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _singleLayoutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _verticalLayoutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _doubleLayoutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _horizontalLayoutToolStripMenuItem;
      private System.Windows.Forms.Panel _topPanel;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label _imageInfoLabel;
   }
}

