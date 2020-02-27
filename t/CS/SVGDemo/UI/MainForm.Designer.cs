namespace SvgDemo
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
         this._menuStrip = new System.Windows.Forms.MenuStrip();
         this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._separator1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._multiPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._firstPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._previousPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._nextPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._lastPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._documentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._getTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._saveTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._selectTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._separator2ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._showDocInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._useDpiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._transformAtCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._loadSVGOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._controlsPanel = new System.Windows.Forms.Panel();
         this._gbSvgInfo = new System.Windows.Forms.GroupBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.label1 = new System.Windows.Forms.Label();
         this._mousePositionLabel = new System.Windows.Forms.Label();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this._pagePanel = new System.Windows.Forms.Panel();
         this._fileNameLabel = new System.Windows.Forms.Label();
         this._separator3ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._gotoPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._menuStrip.SuspendLayout();
         this._controlsPanel.SuspendLayout();
         this._gbSvgInfo.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this._pagePanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // _menuStrip
         // 
         this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._multiPageToolStripMenuItem,
            this._documentToolStripMenuItem,
            this._preferencesToolStripMenuItem,
            this._helpToolStripMenuItem});
         this._menuStrip.Location = new System.Drawing.Point(0, 0);
         this._menuStrip.Name = "_menuStrip";
         this._menuStrip.Size = new System.Drawing.Size(818, 24);
         this._menuStrip.TabIndex = 0;
         // 
         // _fileToolStripMenuItem
         // 
         this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openToolStripMenuItem,
            this._printToolStripMenuItem,
            this._printPreviewToolStripMenuItem,
            this._separator1ToolStripMenuItem,
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
         this._openToolStripMenuItem.Click += new System.EventHandler(this._openToolStripMenuItem_Click);
         // 
         // _printToolStripMenuItem
         // 
         this._printToolStripMenuItem.Name = "_printToolStripMenuItem";
         this._printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
         this._printToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
         this._printToolStripMenuItem.Text = "&Print...";
         this._printToolStripMenuItem.Click += new System.EventHandler(this._printToolStripMenuItem_Click);
         // 
         // _printPreviewToolStripMenuItem
         // 
         this._printPreviewToolStripMenuItem.Name = "_printPreviewToolStripMenuItem";
         this._printPreviewToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
         this._printPreviewToolStripMenuItem.Text = "Print Pre&view...";
         this._printPreviewToolStripMenuItem.Click += new System.EventHandler(this._printPreviewToolStripMenuItem_Click);
         // 
         // _separator1ToolStripMenuItem
         // 
         this._separator1ToolStripMenuItem.Name = "_separator1ToolStripMenuItem";
         this._separator1ToolStripMenuItem.Size = new System.Drawing.Size(152, 6);
         // 
         // _exitToolStripMenuItem
         // 
         this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
         this._exitToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
         this._exitToolStripMenuItem.Text = "E&xit";
         this._exitToolStripMenuItem.Click += new System.EventHandler(this._exitToolStripMenuItem_Click);
         // 
         // _multiPageToolStripMenuItem
         // 
         this._multiPageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._firstPageToolStripMenuItem,
            this._previousPageToolStripMenuItem,
            this._nextPageToolStripMenuItem,
            this._lastPageToolStripMenuItem,
            this._separator3ToolStripMenuItem,
            this._gotoPageToolStripMenuItem});
         this._multiPageToolStripMenuItem.Name = "_multiPageToolStripMenuItem";
         this._multiPageToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
         this._multiPageToolStripMenuItem.Text = "&Multi-Page";
         // 
         // _firstPageToolStripMenuItem
         // 
         this._firstPageToolStripMenuItem.Name = "_firstPageToolStripMenuItem";
         this._firstPageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._firstPageToolStripMenuItem.Text = "&First";
         this._firstPageToolStripMenuItem.Click += new System.EventHandler(this._firstPageToolStripMenuItem_Click);
         // 
         // _previousPageToolStripMenuItem
         // 
         this._previousPageToolStripMenuItem.Name = "_previousPageToolStripMenuItem";
         this._previousPageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._previousPageToolStripMenuItem.Text = "&Previous";
         this._previousPageToolStripMenuItem.Click += new System.EventHandler(this._previousPageToolStripMenuItem_Click);
         // 
         // _nextPageToolStripMenuItem
         // 
         this._nextPageToolStripMenuItem.Name = "_nextPageToolStripMenuItem";
         this._nextPageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._nextPageToolStripMenuItem.Text = "&Next";
         this._nextPageToolStripMenuItem.Click += new System.EventHandler(this._nextPageToolStripMenuItem_Click);
         // 
         // _lastPageToolStripMenuItem
         // 
         this._lastPageToolStripMenuItem.Name = "_lastPageToolStripMenuItem";
         this._lastPageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._lastPageToolStripMenuItem.Text = "&Last";
         this._lastPageToolStripMenuItem.Click += new System.EventHandler(this._lastPageToolStripMenuItem_Click);
         // 
         // _documentToolStripMenuItem
         // 
         this._documentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._getTextToolStripMenuItem,
            this._saveTextToolStripMenuItem,
            this._selectTextToolStripMenuItem,
            this._separator2ToolStripMenuItem,
            this._showDocInfoToolStripMenuItem});
         this._documentToolStripMenuItem.Name = "_documentToolStripMenuItem";
         this._documentToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
         this._documentToolStripMenuItem.Text = "&Document";
         // 
         // _getTextToolStripMenuItem
         // 
         this._getTextToolStripMenuItem.Name = "_getTextToolStripMenuItem";
         this._getTextToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
         this._getTextToolStripMenuItem.Text = "&Get Text";
         this._getTextToolStripMenuItem.Click += new System.EventHandler(this._getTextToolStripMenuItem_Click);
         // 
         // _saveTextToolStripMenuItem
         // 
         this._saveTextToolStripMenuItem.Name = "_saveTextToolStripMenuItem";
         this._saveTextToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
         this._saveTextToolStripMenuItem.Text = "&Save Text...";
         this._saveTextToolStripMenuItem.Click += new System.EventHandler(this._saveTextToolStripMenuItem_Click);
         // 
         // _selectTextToolStripMenuItem
         // 
         this._selectTextToolStripMenuItem.Name = "_selectTextToolStripMenuItem";
         this._selectTextToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
         this._selectTextToolStripMenuItem.Text = "Select &Text";
         this._selectTextToolStripMenuItem.Click += new System.EventHandler(this._selectTextToolStripMenuItem_Click);
         // 
         // _separator2ToolStripMenuItem
         // 
         this._separator2ToolStripMenuItem.Name = "_separator2ToolStripMenuItem";
         this._separator2ToolStripMenuItem.Size = new System.Drawing.Size(237, 6);
         // 
         // _showDocInfoToolStripMenuItem
         // 
         this._showDocInfoToolStripMenuItem.Name = "_showDocInfoToolStripMenuItem";
         this._showDocInfoToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
         this._showDocInfoToolStripMenuItem.Text = "Show Document &Information ...";
         this._showDocInfoToolStripMenuItem.Click += new System.EventHandler(this._showDocInfoToolStripMenuItem_Click);
         // 
         // _preferencesToolStripMenuItem
         // 
         this._preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._useDpiToolStripMenuItem,
            this._transformAtCenterToolStripMenuItem,
            this._loadSVGOptionsToolStripMenuItem});
         this._preferencesToolStripMenuItem.Name = "_preferencesToolStripMenuItem";
         this._preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
         this._preferencesToolStripMenuItem.Text = "&Preferences";
         // 
         // _useDpiToolStripMenuItem
         // 
         this._useDpiToolStripMenuItem.Name = "_useDpiToolStripMenuItem";
         this._useDpiToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
         this._useDpiToolStripMenuItem.Text = "Use &Dpi";
         this._useDpiToolStripMenuItem.Click += new System.EventHandler(this._useDpiToolStripMenuItem_Click);
         // 
         // _transformAtCenterToolStripMenuItem
         // 
         this._transformAtCenterToolStripMenuItem.Name = "_transformAtCenterToolStripMenuItem";
         this._transformAtCenterToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
         this._transformAtCenterToolStripMenuItem.Text = "Transform At &Center";
         this._transformAtCenterToolStripMenuItem.Click += new System.EventHandler(this._transformAtCenterToolStripMenuItem_Click);
         // 
         // _loadSVGOptionsToolStripMenuItem
         // 
         this._loadSVGOptionsToolStripMenuItem.Name = "_loadSVGOptionsToolStripMenuItem";
         this._loadSVGOptionsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
         this._loadSVGOptionsToolStripMenuItem.Text = "&Load SVG Options...";
         this._loadSVGOptionsToolStripMenuItem.Click += new System.EventHandler(this._loadSVGOptionsToolStripMenuItem_Click);
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
         this._aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._aboutToolStripMenuItem.Text = "&About";
         this._aboutToolStripMenuItem.Click += new System.EventHandler(this._aboutToolStripMenuItem_Click);
         // 
         // _controlsPanel
         // 
         this._controlsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._controlsPanel.Controls.Add(this._gbSvgInfo);
         this._controlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
         this._controlsPanel.Location = new System.Drawing.Point(0, 553);
         this._controlsPanel.Name = "_controlsPanel";
         this._controlsPanel.Size = new System.Drawing.Size(818, 78);
         this._controlsPanel.TabIndex = 1;
         // 
         // _gbSvgInfo
         // 
         this._gbSvgInfo.Controls.Add(this.groupBox2);
         this._gbSvgInfo.Controls.Add(this.groupBox3);
         this._gbSvgInfo.Location = new System.Drawing.Point(13, 3);
         this._gbSvgInfo.Name = "_gbSvgInfo";
         this._gbSvgInfo.Size = new System.Drawing.Size(791, 65);
         this._gbSvgInfo.TabIndex = 0;
         this._gbSvgInfo.TabStop = false;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.label1);
         this.groupBox2.Controls.Add(this._mousePositionLabel);
         this.groupBox2.Location = new System.Drawing.Point(15, 7);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(296, 52);
         this.groupBox2.TabIndex = 16;
         this.groupBox2.TabStop = false;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(7, 22);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(82, 13);
         this.label1.TabIndex = 10;
         this.label1.Text = "Mouse Position:";
         // 
         // _mousePositionLabel
         // 
         this._mousePositionLabel.AutoSize = true;
         this._mousePositionLabel.Location = new System.Drawing.Point(95, 22);
         this._mousePositionLabel.Name = "_mousePositionLabel";
         this._mousePositionLabel.Size = new System.Drawing.Size(0, 13);
         this._mousePositionLabel.TabIndex = 9;
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.label5);
         this.groupBox3.Controls.Add(this.label4);
         this.groupBox3.Controls.Add(this.label3);
         this.groupBox3.Controls.Add(this.label2);
         this.groupBox3.Location = new System.Drawing.Point(322, 7);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(453, 52);
         this.groupBox3.TabIndex = 15;
         this.groupBox3.TabStop = false;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(212, 34);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(137, 13);
         this.label5.TabIndex = 16;
         this.label5.Text = "Right mouse click = Identity";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(18, 35);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(176, 13);
         this.label4.TabIndex = 15;
         this.label4.Text = "Alt + left mouse click + drag = rotate";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(212, 14);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(214, 13);
         this.label3.TabIndex = 14;
         this.label3.Text = "Ctrl + left mouse click + drag = zoom in / out";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(18, 14);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(148, 13);
         this.label2.TabIndex = 13;
         this.label2.Text = "Left mouse click + drag = Pan";
         // 
         // _pagePanel
         // 
         this._pagePanel.Controls.Add(this._fileNameLabel);
         this._pagePanel.Dock = System.Windows.Forms.DockStyle.Top;
         this._pagePanel.Location = new System.Drawing.Point(0, 24);
         this._pagePanel.Name = "_pagePanel";
         this._pagePanel.Size = new System.Drawing.Size(818, 23);
         this._pagePanel.TabIndex = 2;
         // 
         // _fileNameLabel
         // 
         this._fileNameLabel.AutoSize = true;
         this._fileNameLabel.Location = new System.Drawing.Point(16, 5);
         this._fileNameLabel.Name = "_fileNameLabel";
         this._fileNameLabel.Size = new System.Drawing.Size(0, 13);
         this._fileNameLabel.TabIndex = 0;
         // 
         // _separator3ToolStripMenuItem
         // 
         this._separator3ToolStripMenuItem.Name = "_separator3ToolStripMenuItem";
         this._separator3ToolStripMenuItem.Size = new System.Drawing.Size(149, 6);
         // 
         // _gotoPageToolStripMenuItem
         // 
         this._gotoPageToolStripMenuItem.Name = "_gotoPageToolStripMenuItem";
         this._gotoPageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this._gotoPageToolStripMenuItem.Text = "&Goto page...";
         this._gotoPageToolStripMenuItem.Click += new System.EventHandler(this._gotoPageToolStripMenuItem_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(818, 631);
         this.Controls.Add(this._pagePanel);
         this.Controls.Add(this._controlsPanel);
         this.Controls.Add(this._menuStrip);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._menuStrip;
         this.Name = "MainForm";
         this.Text = "MainForm";
         this.Resize += new System.EventHandler(this.MainForm_Resize);
         this._menuStrip.ResumeLayout(false);
         this._menuStrip.PerformLayout();
         this._controlsPanel.ResumeLayout(false);
         this._gbSvgInfo.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this._pagePanel.ResumeLayout(false);
         this._pagePanel.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _menuStrip;
      private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _openToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _separator1ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
      private System.Windows.Forms.Panel _controlsPanel;
      private System.Windows.Forms.ToolStripMenuItem _preferencesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _useDpiToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _transformAtCenterToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _helpToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _aboutToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _documentToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _getTextToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _saveTextToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _separator2ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _showDocInfoToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _printToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _multiPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _firstPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _previousPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _nextPageToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _lastPageToolStripMenuItem;
      private System.Windows.Forms.GroupBox _gbSvgInfo;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label _mousePositionLabel;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ToolStripMenuItem _printPreviewToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _selectTextToolStripMenuItem;
      private System.Windows.Forms.Panel _pagePanel;
      private System.Windows.Forms.Label _fileNameLabel;
      private System.Windows.Forms.ToolStripMenuItem _loadSVGOptionsToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator _separator3ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem _gotoPageToolStripMenuItem;
   }
}

