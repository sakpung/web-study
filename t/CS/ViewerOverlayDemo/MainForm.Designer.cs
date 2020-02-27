namespace ViewerOverlayDemo
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
         if(disposing && (components != null))
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
         this._closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._fileSep1ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
         this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._readMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this._leftPanel = new System.Windows.Forms.Panel();
         this._actionsGroupBox = new System.Windows.Forms.GroupBox();
         this._drawOverlayRectangleButton = new System.Windows.Forms.Button();
         this._invertImageUnderOverlayRectButton = new System.Windows.Forms.Button();
         this._fastRotate90CounterClockwiseButton = new System.Windows.Forms.Button();
         this._fastRotate90ClockwiseButton = new System.Windows.Forms.Button();
         this._viewPropertiesGroupBox = new System.Windows.Forms.GroupBox();
         this._zoomValueLabel = new System.Windows.Forms.Label();
         this._zoomOutButton = new System.Windows.Forms.Button();
         this._zoomInButton = new System.Windows.Forms.Button();
         this._zoomNoneButton = new System.Windows.Forms.Button();
         this._sizeModeComboBox = new System.Windows.Forms.ComboBox();
         this._sizeModeLabel = new System.Windows.Forms.Label();
         this._verticalAlignmentComboBox = new System.Windows.Forms.ComboBox();
         this._verticalAlignmentLabel = new System.Windows.Forms.Label();
         this._horizontalAlignmentComboBox = new System.Windows.Forms.ComboBox();
         this._horizontalAlignmentLabel = new System.Windows.Forms.Label();
         this._paddingCheckBox = new System.Windows.Forms.CheckBox();
         this._useDpiCheckBox = new System.Windows.Forms.CheckBox();
         this._imageViewer = new Leadtools.Controls.ImageViewer();
         this._topPanel = new System.Windows.Forms.Panel();
         this._imageInfoLabel = new System.Windows.Forms.Label();
         this._bottomPanel = new System.Windows.Forms.Panel();
         this._colorCursorPanel = new System.Windows.Forms.Panel();
         this._cursorColorValueLabel = new System.Windows.Forms.Label();
         this._cursorColorLabel = new System.Windows.Forms.Label();
         this._mousePositionLabel = new System.Windows.Forms.Label();
         this._mainMenuStrip.SuspendLayout();
         this._leftPanel.SuspendLayout();
         this._actionsGroupBox.SuspendLayout();
         this._viewPropertiesGroupBox.SuspendLayout();
         this._topPanel.SuspendLayout();
         this._bottomPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenuStrip
         // 
         this._mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._helpToolStripMenuItem});
         this._mainMenuStrip.Location = new System.Drawing.Point(0, 0);
         this._mainMenuStrip.Name = "_mainMenuStrip";
         this._mainMenuStrip.Size = new System.Drawing.Size(816, 24);
         this._mainMenuStrip.TabIndex = 0;
         // 
         // _fileToolStripMenuItem
         // 
         this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openToolStripMenuItem,
            this._closeToolStripMenuItem,
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
         this._openToolStripMenuItem.Click += new System.EventHandler(this._openToolStripMenuItem_Click);
         // 
         // _closeToolStripMenuItem
         // 
         this._closeToolStripMenuItem.Name = "_closeToolStripMenuItem";
         this._closeToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
         this._closeToolStripMenuItem.Text = "C&lose";
         this._closeToolStripMenuItem.Click += new System.EventHandler(this._closeToolStripMenuItem_Click);
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
         this._exitToolStripMenuItem.Click += new System.EventHandler(this._exitToolStripMenuItem_Click);
         // 
         // _helpToolStripMenuItem
         // 
         this._helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem,
            this._readMeToolStripMenuItem});
         this._helpToolStripMenuItem.Name = "_helpToolStripMenuItem";
         this._helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this._helpToolStripMenuItem.Text = "&Help";
         // 
         // _aboutToolStripMenuItem
         // 
         this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
         this._aboutToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
         this._aboutToolStripMenuItem.Text = "&About...";
         this._aboutToolStripMenuItem.Click += new System.EventHandler(this._aboutToolStripMenuItem_Click);
         // 
         // _readMeToolStripMenuItem
         // 
         this._readMeToolStripMenuItem.Name = "_readMeToolStripMenuItem";
         this._readMeToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
         this._readMeToolStripMenuItem.Text = "&Read me...";
         this._readMeToolStripMenuItem.Click += new System.EventHandler(this._readMeToolStripMenuItem_Click);
         // 
         // _leftPanel
         // 
         this._leftPanel.Controls.Add(this._actionsGroupBox);
         this._leftPanel.Controls.Add(this._viewPropertiesGroupBox);
         this._leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
         this._leftPanel.Location = new System.Drawing.Point(0, 24);
         this._leftPanel.Name = "_leftPanel";
         this._leftPanel.Size = new System.Drawing.Size(283, 552);
         this._leftPanel.TabIndex = 1;
         // 
         // _actionsGroupBox
         // 
         this._actionsGroupBox.Controls.Add(this._drawOverlayRectangleButton);
         this._actionsGroupBox.Controls.Add(this._invertImageUnderOverlayRectButton);
         this._actionsGroupBox.Controls.Add(this._fastRotate90CounterClockwiseButton);
         this._actionsGroupBox.Controls.Add(this._fastRotate90ClockwiseButton);
         this._actionsGroupBox.Location = new System.Drawing.Point(12, 212);
         this._actionsGroupBox.Name = "_actionsGroupBox";
         this._actionsGroupBox.Size = new System.Drawing.Size(260, 151);
         this._actionsGroupBox.TabIndex = 1;
         this._actionsGroupBox.TabStop = false;
         this._actionsGroupBox.Text = "Actions:";
         // 
         // _drawOverlayRectangleButton
         // 
         this._drawOverlayRectangleButton.Location = new System.Drawing.Point(15, 19);
         this._drawOverlayRectangleButton.Name = "_drawOverlayRectangleButton";
         this._drawOverlayRectangleButton.Size = new System.Drawing.Size(234, 23);
         this._drawOverlayRectangleButton.TabIndex = 0;
         this._drawOverlayRectangleButton.Text = "Draw overlay rectangle";
         this._drawOverlayRectangleButton.UseVisualStyleBackColor = true;
         this._drawOverlayRectangleButton.Click += new System.EventHandler(this._drawOverlayRectangleButton_Click);
         // 
         // _invertImageUnderOverlayRectButton
         // 
         this._invertImageUnderOverlayRectButton.Location = new System.Drawing.Point(15, 118);
         this._invertImageUnderOverlayRectButton.Name = "_invertImageUnderOverlayRectButton";
         this._invertImageUnderOverlayRectButton.Size = new System.Drawing.Size(234, 23);
         this._invertImageUnderOverlayRectButton.TabIndex = 3;
         this._invertImageUnderOverlayRectButton.Text = "Invert image under overlay rectangle";
         this._invertImageUnderOverlayRectButton.UseVisualStyleBackColor = true;
         this._invertImageUnderOverlayRectButton.Click += new System.EventHandler(this._invertImageUnderOverlayRectButton_Click);
         // 
         // _fastRotate90CounterClockwiseButton
         // 
         this._fastRotate90CounterClockwiseButton.Location = new System.Drawing.Point(15, 89);
         this._fastRotate90CounterClockwiseButton.Name = "_fastRotate90CounterClockwiseButton";
         this._fastRotate90CounterClockwiseButton.Size = new System.Drawing.Size(234, 23);
         this._fastRotate90CounterClockwiseButton.TabIndex = 2;
         this._fastRotate90CounterClockwiseButton.Text = "Fast Rotate 90 counter-clockwise";
         this._fastRotate90CounterClockwiseButton.UseVisualStyleBackColor = true;
         this._fastRotate90CounterClockwiseButton.Click += new System.EventHandler(this._fastRotate90CounterClockwiseButton_Click);
         // 
         // _fastRotate90ClockwiseButton
         // 
         this._fastRotate90ClockwiseButton.Location = new System.Drawing.Point(15, 60);
         this._fastRotate90ClockwiseButton.Name = "_fastRotate90ClockwiseButton";
         this._fastRotate90ClockwiseButton.Size = new System.Drawing.Size(234, 23);
         this._fastRotate90ClockwiseButton.TabIndex = 1;
         this._fastRotate90ClockwiseButton.Text = "Fast Rotate 90 clockwise";
         this._fastRotate90ClockwiseButton.UseVisualStyleBackColor = true;
         this._fastRotate90ClockwiseButton.Click += new System.EventHandler(this._fastRotate90ClockwiseButton_Click);
         // 
         // _viewPropertiesGroupBox
         // 
         this._viewPropertiesGroupBox.Controls.Add(this._zoomValueLabel);
         this._viewPropertiesGroupBox.Controls.Add(this._zoomOutButton);
         this._viewPropertiesGroupBox.Controls.Add(this._zoomInButton);
         this._viewPropertiesGroupBox.Controls.Add(this._zoomNoneButton);
         this._viewPropertiesGroupBox.Controls.Add(this._sizeModeComboBox);
         this._viewPropertiesGroupBox.Controls.Add(this._sizeModeLabel);
         this._viewPropertiesGroupBox.Controls.Add(this._verticalAlignmentComboBox);
         this._viewPropertiesGroupBox.Controls.Add(this._verticalAlignmentLabel);
         this._viewPropertiesGroupBox.Controls.Add(this._horizontalAlignmentComboBox);
         this._viewPropertiesGroupBox.Controls.Add(this._horizontalAlignmentLabel);
         this._viewPropertiesGroupBox.Controls.Add(this._paddingCheckBox);
         this._viewPropertiesGroupBox.Controls.Add(this._useDpiCheckBox);
         this._viewPropertiesGroupBox.Location = new System.Drawing.Point(12, 13);
         this._viewPropertiesGroupBox.Name = "_viewPropertiesGroupBox";
         this._viewPropertiesGroupBox.Size = new System.Drawing.Size(260, 193);
         this._viewPropertiesGroupBox.TabIndex = 0;
         this._viewPropertiesGroupBox.TabStop = false;
         this._viewPropertiesGroupBox.Text = "Viewer properties:";
         // 
         // _zoomValueLabel
         // 
         this._zoomValueLabel.AutoSize = true;
         this._zoomValueLabel.Location = new System.Drawing.Point(12, 78);
         this._zoomValueLabel.Name = "_zoomValueLabel";
         this._zoomValueLabel.Size = new System.Drawing.Size(101, 13);
         this._zoomValueLabel.TabIndex = 5;
         this._zoomValueLabel.Text = "Current zoom value:";
         // 
         // _zoomOutButton
         // 
         this._zoomOutButton.Location = new System.Drawing.Point(171, 42);
         this._zoomOutButton.Name = "_zoomOutButton";
         this._zoomOutButton.Size = new System.Drawing.Size(75, 23);
         this._zoomOutButton.TabIndex = 4;
         this._zoomOutButton.Text = "Zoom out";
         this._zoomOutButton.UseVisualStyleBackColor = true;
         this._zoomOutButton.Click += new System.EventHandler(this._zoomOutButton_Click);
         // 
         // _zoomInButton
         // 
         this._zoomInButton.Location = new System.Drawing.Point(90, 42);
         this._zoomInButton.Name = "_zoomInButton";
         this._zoomInButton.Size = new System.Drawing.Size(75, 23);
         this._zoomInButton.TabIndex = 3;
         this._zoomInButton.Text = "Zoom in";
         this._zoomInButton.UseVisualStyleBackColor = true;
         this._zoomInButton.Click += new System.EventHandler(this._zoomInButton_Click);
         // 
         // _zoomNoneButton
         // 
         this._zoomNoneButton.Location = new System.Drawing.Point(9, 42);
         this._zoomNoneButton.Name = "_zoomNoneButton";
         this._zoomNoneButton.Size = new System.Drawing.Size(75, 23);
         this._zoomNoneButton.TabIndex = 2;
         this._zoomNoneButton.Text = "Zoom none";
         this._zoomNoneButton.UseVisualStyleBackColor = true;
         this._zoomNoneButton.Click += new System.EventHandler(this._zoomNoneButton_Click);
         // 
         // _sizeModeComboBox
         // 
         this._sizeModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._sizeModeComboBox.FormattingEnabled = true;
         this._sizeModeComboBox.Location = new System.Drawing.Point(119, 101);
         this._sizeModeComboBox.Name = "_sizeModeComboBox";
         this._sizeModeComboBox.Size = new System.Drawing.Size(127, 21);
         this._sizeModeComboBox.TabIndex = 7;
         this._sizeModeComboBox.SelectionChangeCommitted += new System.EventHandler(_sizeModeComboBox_SelectionChangeCommitted);         
         // 
         // _sizeModeLabel
         // 
         this._sizeModeLabel.AutoSize = true;
         this._sizeModeLabel.Location = new System.Drawing.Point(54, 104);
         this._sizeModeLabel.Name = "_sizeModeLabel";
         this._sizeModeLabel.Size = new System.Drawing.Size(59, 13);
         this._sizeModeLabel.TabIndex = 6;
         this._sizeModeLabel.Text = "Size mode:";
         // 
         // _verticalAlignmentComboBox
         // 
         this._verticalAlignmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._verticalAlignmentComboBox.FormattingEnabled = true;
         this._verticalAlignmentComboBox.Location = new System.Drawing.Point(119, 155);
         this._verticalAlignmentComboBox.Name = "_verticalAlignmentComboBox";
         this._verticalAlignmentComboBox.Size = new System.Drawing.Size(127, 21);
         this._verticalAlignmentComboBox.TabIndex = 11;
         this._verticalAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this._verticalAlignmentComboBox_SelectedIndexChanged);
         // 
         // _verticalAlignmentLabel
         // 
         this._verticalAlignmentLabel.AutoSize = true;
         this._verticalAlignmentLabel.Location = new System.Drawing.Point(20, 158);
         this._verticalAlignmentLabel.Name = "_verticalAlignmentLabel";
         this._verticalAlignmentLabel.Size = new System.Drawing.Size(93, 13);
         this._verticalAlignmentLabel.TabIndex = 10;
         this._verticalAlignmentLabel.Text = "Vertical alignment:";
         // 
         // _horizontalAlignmentComboBox
         // 
         this._horizontalAlignmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._horizontalAlignmentComboBox.FormattingEnabled = true;
         this._horizontalAlignmentComboBox.Location = new System.Drawing.Point(119, 128);
         this._horizontalAlignmentComboBox.Name = "_horizontalAlignmentComboBox";
         this._horizontalAlignmentComboBox.Size = new System.Drawing.Size(127, 21);
         this._horizontalAlignmentComboBox.TabIndex = 9;
         this._horizontalAlignmentComboBox.SelectedIndexChanged += new System.EventHandler(this._horizontalAlignmentComboBox_SelectedIndexChanged);
         // 
         // _horizontalAlignmentLabel
         // 
         this._horizontalAlignmentLabel.AutoSize = true;
         this._horizontalAlignmentLabel.Location = new System.Drawing.Point(8, 131);
         this._horizontalAlignmentLabel.Name = "_horizontalAlignmentLabel";
         this._horizontalAlignmentLabel.Size = new System.Drawing.Size(105, 13);
         this._horizontalAlignmentLabel.TabIndex = 8;
         this._horizontalAlignmentLabel.Text = "Horizontal alignment:";
         // 
         // _paddingCheckBox
         // 
         this._paddingCheckBox.AutoSize = true;
         this._paddingCheckBox.Location = new System.Drawing.Point(91, 19);
         this._paddingCheckBox.Name = "_paddingCheckBox";
         this._paddingCheckBox.Size = new System.Drawing.Size(65, 17);
         this._paddingCheckBox.TabIndex = 1;
         this._paddingCheckBox.Text = "Padding";
         this._paddingCheckBox.UseVisualStyleBackColor = true;
         this._paddingCheckBox.CheckedChanged += new System.EventHandler(this._paddingCheckBox_CheckedChanged);
         // 
         // _useDpiCheckBox
         // 
         this._useDpiCheckBox.AutoSize = true;
         this._useDpiCheckBox.Location = new System.Drawing.Point(12, 19);
         this._useDpiCheckBox.Name = "_useDpiCheckBox";
         this._useDpiCheckBox.Size = new System.Drawing.Size(66, 17);
         this._useDpiCheckBox.TabIndex = 0;
         this._useDpiCheckBox.Text = "Use DPI";
         this._useDpiCheckBox.UseVisualStyleBackColor = true;
         this._useDpiCheckBox.CheckedChanged += new System.EventHandler(this._useDpiCheckBox_CheckedChanged);
         // 
         // _rasterImageViewer
         // 
         this._imageViewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._imageViewer.Location = new System.Drawing.Point(283, 66);
         this._imageViewer.Name = "_imageViewer";
         this._imageViewer.Size = new System.Drawing.Size(533, 468);
         this._imageViewer.TabIndex = 3;
         // 
         // _topPanel
         // 
         this._topPanel.Controls.Add(this._imageInfoLabel);
         this._topPanel.Dock = System.Windows.Forms.DockStyle.Top;
         this._topPanel.Location = new System.Drawing.Point(283, 24);
         this._topPanel.Name = "_topPanel";
         this._topPanel.Size = new System.Drawing.Size(533, 42);
         this._topPanel.TabIndex = 2;
         // 
         // _imageInfoLabel
         // 
         this._imageInfoLabel.AutoSize = true;
         this._imageInfoLabel.Location = new System.Drawing.Point(7, 13);
         this._imageInfoLabel.Name = "_imageInfoLabel";
         this._imageInfoLabel.Size = new System.Drawing.Size(85, 13);
         this._imageInfoLabel.TabIndex = 0;
         this._imageInfoLabel.Text = "_imageInfoLabel";
         // 
         // _bottomPanel
         // 
         this._bottomPanel.Controls.Add(this._colorCursorPanel);
         this._bottomPanel.Controls.Add(this._cursorColorValueLabel);
         this._bottomPanel.Controls.Add(this._cursorColorLabel);
         this._bottomPanel.Controls.Add(this._mousePositionLabel);
         this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
         this._bottomPanel.Location = new System.Drawing.Point(283, 534);
         this._bottomPanel.Name = "_bottomPanel";
         this._bottomPanel.Size = new System.Drawing.Size(533, 42);
         this._bottomPanel.TabIndex = 4;
         // 
         // _colorCursorPanel
         // 
         this._colorCursorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._colorCursorPanel.Location = new System.Drawing.Point(264, 14);
         this._colorCursorPanel.Name = "_colorCursorPanel";
         this._colorCursorPanel.Size = new System.Drawing.Size(36, 24);
         this._colorCursorPanel.TabIndex = 2;
         // 
         // _cursorColorValueLabel
         // 
         this._cursorColorValueLabel.Location = new System.Drawing.Point(109, 15);
         this._cursorColorValueLabel.Name = "_cursorColorValueLabel";
         this._cursorColorValueLabel.Size = new System.Drawing.Size(149, 23);
         this._cursorColorValueLabel.TabIndex = 1;
         this._cursorColorValueLabel.Text = "_cursorColorValueLabel";
         this._cursorColorValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _cursorColorLabel
         // 
         this._cursorColorLabel.AutoSize = true;
         this._cursorColorLabel.Location = new System.Drawing.Point(7, 20);
         this._cursorColorLabel.Name = "_cursorColorLabel";
         this._cursorColorLabel.Size = new System.Drawing.Size(96, 13);
         this._cursorColorLabel.TabIndex = 0;
         this._cursorColorLabel.Text = "Color under cursor:";
         // 
         // _mousePositionLabel
         // 
         this._mousePositionLabel.AutoSize = true;
         this._mousePositionLabel.Location = new System.Drawing.Point(306, 20);
         this._mousePositionLabel.Name = "_mousePositionLabel";
         this._mousePositionLabel.Size = new System.Drawing.Size(107, 13);
         this._mousePositionLabel.TabIndex = 3;
         this._mousePositionLabel.Text = "_mousePositionLabel";
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(816, 576);
         this.Controls.Add(this._imageViewer);
         this.Controls.Add(this._bottomPanel);
         this.Controls.Add(this._topPanel);
         this.Controls.Add(this._leftPanel);
         this.Controls.Add(this._mainMenuStrip);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._mainMenuStrip;
         this.Name = "MainForm";
         this.Text = "MainForm";
         this._mainMenuStrip.ResumeLayout(false);
         this._mainMenuStrip.PerformLayout();
         this._leftPanel.ResumeLayout(false);
         this._actionsGroupBox.ResumeLayout(false);
         this._viewPropertiesGroupBox.ResumeLayout(false);
         this._viewPropertiesGroupBox.PerformLayout();
         this._topPanel.ResumeLayout(false);
         this._topPanel.PerformLayout();
         this._bottomPanel.ResumeLayout(false);
         this._bottomPanel.PerformLayout();
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
      private System.Windows.Forms.ToolStripMenuItem _closeToolStripMenuItem;
      private System.Windows.Forms.Panel _leftPanel;
      private Leadtools.Controls.ImageViewer _imageViewer;
      private System.Windows.Forms.GroupBox _viewPropertiesGroupBox;
      private System.Windows.Forms.CheckBox _useDpiCheckBox;
      private System.Windows.Forms.CheckBox _paddingCheckBox;
      private System.Windows.Forms.Label _horizontalAlignmentLabel;
      private System.Windows.Forms.ComboBox _horizontalAlignmentComboBox;
      private System.Windows.Forms.ComboBox _verticalAlignmentComboBox;
      private System.Windows.Forms.Label _verticalAlignmentLabel;
      private System.Windows.Forms.ComboBox _sizeModeComboBox;
      private System.Windows.Forms.Label _sizeModeLabel;
      private System.Windows.Forms.Panel _topPanel;
      private System.Windows.Forms.Label _imageInfoLabel;
      private System.Windows.Forms.Panel _bottomPanel;
      private System.Windows.Forms.Label _mousePositionLabel;
      private System.Windows.Forms.Label _cursorColorLabel;
      private System.Windows.Forms.Label _cursorColorValueLabel;
      private System.Windows.Forms.Panel _colorCursorPanel;
      private System.Windows.Forms.Label _zoomValueLabel;
      private System.Windows.Forms.Button _zoomOutButton;
      private System.Windows.Forms.Button _zoomInButton;
      private System.Windows.Forms.Button _zoomNoneButton;
      private System.Windows.Forms.GroupBox _actionsGroupBox;
      private System.Windows.Forms.Button _invertImageUnderOverlayRectButton;
      private System.Windows.Forms.Button _fastRotate90CounterClockwiseButton;
      private System.Windows.Forms.Button _fastRotate90ClockwiseButton;
      private System.Windows.Forms.Button _drawOverlayRectangleButton;
      private System.Windows.Forms.ToolStripMenuItem _readMeToolStripMenuItem;
   }
}