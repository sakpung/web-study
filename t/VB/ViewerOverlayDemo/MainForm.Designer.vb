Imports Leadtools.Controls

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
   Inherits System.Windows.Forms.Form

   'Form overrides dispose to clean up the component list.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._bottomPanel = New System.Windows.Forms.Panel
      Me._colorCursorPanel = New System.Windows.Forms.Panel
      Me._cursorColorValueLabel = New System.Windows.Forms.Label
      Me._cursorColorLabel = New System.Windows.Forms.Label
      Me._mousePositionLabel = New System.Windows.Forms.Label
      Me._fastRotate90ClockwiseButton = New System.Windows.Forms.Button
      Me._zoomValueLabel = New System.Windows.Forms.Label
      Me._zoomOutButton = New System.Windows.Forms.Button
      Me._viewPropertiesGroupBox = New System.Windows.Forms.GroupBox
      Me._zoomInButton = New System.Windows.Forms.Button
      Me._zoomNoneButton = New System.Windows.Forms.Button
      Me._sizeModeComboBox = New System.Windows.Forms.ComboBox
      Me._sizeModeLabel = New System.Windows.Forms.Label
      Me._verticalAlignmentComboBox = New System.Windows.Forms.ComboBox
      Me._verticalAlignmentLabel = New System.Windows.Forms.Label
      Me._horizontalAlignmentComboBox = New System.Windows.Forms.ComboBox
      Me._horizontalAlignmentLabel = New System.Windows.Forms.Label
      Me._paddingCheckBox = New System.Windows.Forms.CheckBox
      Me._useDpiCheckBox = New System.Windows.Forms.CheckBox
      Me._imageViewer = New ImageViewer
      Me._topPanel = New System.Windows.Forms.Panel
      Me._imageInfoLabel = New System.Windows.Forms.Label
      Me._fastRotate90CounterClockwiseButton = New System.Windows.Forms.Button
      Me._mainMenuStrip = New System.Windows.Forms.MenuStrip
      Me._fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._closeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._fileSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
      Me._exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._readMeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
      Me._invertImageUnderOverlayRectButton = New System.Windows.Forms.Button
      Me._actionsGroupBox = New System.Windows.Forms.GroupBox
      Me._drawOverlayRectangleButton = New System.Windows.Forms.Button
      Me._leftPanel = New System.Windows.Forms.Panel
      Me._bottomPanel.SuspendLayout()
      Me._viewPropertiesGroupBox.SuspendLayout()
      Me._topPanel.SuspendLayout()
      Me._mainMenuStrip.SuspendLayout()
      Me._actionsGroupBox.SuspendLayout()
      Me._leftPanel.SuspendLayout()
      Me.SuspendLayout()
      '
      '_bottomPanel
      '
      Me._bottomPanel.Controls.Add(Me._colorCursorPanel)
      Me._bottomPanel.Controls.Add(Me._cursorColorValueLabel)
      Me._bottomPanel.Controls.Add(Me._cursorColorLabel)
      Me._bottomPanel.Controls.Add(Me._mousePositionLabel)
      Me._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
      Me._bottomPanel.Location = New System.Drawing.Point(283, 534)
      Me._bottomPanel.Name = "_bottomPanel"
      Me._bottomPanel.Size = New System.Drawing.Size(533, 42)
      Me._bottomPanel.TabIndex = 4
      '
      '_colorCursorPanel
      '
      Me._colorCursorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._colorCursorPanel.Location = New System.Drawing.Point(264, 14)
      Me._colorCursorPanel.Name = "_colorCursorPanel"
      Me._colorCursorPanel.Size = New System.Drawing.Size(36, 24)
      Me._colorCursorPanel.TabIndex = 2
      '
      '_cursorColorValueLabel
      '
      Me._cursorColorValueLabel.Location = New System.Drawing.Point(109, 15)
      Me._cursorColorValueLabel.Name = "_cursorColorValueLabel"
      Me._cursorColorValueLabel.Size = New System.Drawing.Size(149, 23)
      Me._cursorColorValueLabel.TabIndex = 1
      Me._cursorColorValueLabel.Text = "_cursorColorValueLabel"
      Me._cursorColorValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_cursorColorLabel
      '
      Me._cursorColorLabel.AutoSize = True
      Me._cursorColorLabel.Location = New System.Drawing.Point(7, 20)
      Me._cursorColorLabel.Name = "_cursorColorLabel"
      Me._cursorColorLabel.Size = New System.Drawing.Size(96, 13)
      Me._cursorColorLabel.TabIndex = 0
      Me._cursorColorLabel.Text = "Color under cursor:"
      '
      '_mousePositionLabel
      '
      Me._mousePositionLabel.AutoSize = True
      Me._mousePositionLabel.Location = New System.Drawing.Point(306, 20)
      Me._mousePositionLabel.Name = "_mousePositionLabel"
      Me._mousePositionLabel.Size = New System.Drawing.Size(107, 13)
      Me._mousePositionLabel.TabIndex = 3
      Me._mousePositionLabel.Text = "_mousePositionLabel"
      '
      '_fastRotate90ClockwiseButton
      '
      Me._fastRotate90ClockwiseButton.Location = New System.Drawing.Point(15, 60)
      Me._fastRotate90ClockwiseButton.Name = "_fastRotate90ClockwiseButton"
      Me._fastRotate90ClockwiseButton.Size = New System.Drawing.Size(234, 23)
      Me._fastRotate90ClockwiseButton.TabIndex = 1
      Me._fastRotate90ClockwiseButton.Text = "Fast Rotate 90 clockwise"
      Me._fastRotate90ClockwiseButton.UseVisualStyleBackColor = True
      '
      '_zoomValueLabel
      '
      Me._zoomValueLabel.AutoSize = True
      Me._zoomValueLabel.Location = New System.Drawing.Point(12, 78)
      Me._zoomValueLabel.Name = "_zoomValueLabel"
      Me._zoomValueLabel.Size = New System.Drawing.Size(101, 13)
      Me._zoomValueLabel.TabIndex = 5
      Me._zoomValueLabel.Text = "Current zoom value:"
      '
      '_zoomOutButton
      '
      Me._zoomOutButton.Location = New System.Drawing.Point(171, 42)
      Me._zoomOutButton.Name = "_zoomOutButton"
      Me._zoomOutButton.Size = New System.Drawing.Size(75, 23)
      Me._zoomOutButton.TabIndex = 4
      Me._zoomOutButton.Text = "Zoom out"
      Me._zoomOutButton.UseVisualStyleBackColor = True
      '
      '_viewPropertiesGroupBox
      '
      Me._viewPropertiesGroupBox.Controls.Add(Me._zoomValueLabel)
      Me._viewPropertiesGroupBox.Controls.Add(Me._zoomOutButton)
      Me._viewPropertiesGroupBox.Controls.Add(Me._zoomInButton)
      Me._viewPropertiesGroupBox.Controls.Add(Me._zoomNoneButton)
      Me._viewPropertiesGroupBox.Controls.Add(Me._sizeModeComboBox)
      Me._viewPropertiesGroupBox.Controls.Add(Me._sizeModeLabel)
      Me._viewPropertiesGroupBox.Controls.Add(Me._verticalAlignmentComboBox)
      Me._viewPropertiesGroupBox.Controls.Add(Me._verticalAlignmentLabel)
      Me._viewPropertiesGroupBox.Controls.Add(Me._horizontalAlignmentComboBox)
      Me._viewPropertiesGroupBox.Controls.Add(Me._horizontalAlignmentLabel)
      Me._viewPropertiesGroupBox.Controls.Add(Me._paddingCheckBox)
      Me._viewPropertiesGroupBox.Controls.Add(Me._useDpiCheckBox)
      Me._viewPropertiesGroupBox.Location = New System.Drawing.Point(12, 13)
      Me._viewPropertiesGroupBox.Name = "_viewPropertiesGroupBox"
      Me._viewPropertiesGroupBox.Size = New System.Drawing.Size(260, 193)
      Me._viewPropertiesGroupBox.TabIndex = 0
      Me._viewPropertiesGroupBox.TabStop = False
      Me._viewPropertiesGroupBox.Text = "Viewer properties:"
      '
      '_zoomInButton
      '
      Me._zoomInButton.Location = New System.Drawing.Point(90, 42)
      Me._zoomInButton.Name = "_zoomInButton"
      Me._zoomInButton.Size = New System.Drawing.Size(75, 23)
      Me._zoomInButton.TabIndex = 3
      Me._zoomInButton.Text = "Zoom in"
      Me._zoomInButton.UseVisualStyleBackColor = True
      '
      '_zoomNoneButton
      '
      Me._zoomNoneButton.Location = New System.Drawing.Point(9, 42)
      Me._zoomNoneButton.Name = "_zoomNoneButton"
      Me._zoomNoneButton.Size = New System.Drawing.Size(75, 23)
      Me._zoomNoneButton.TabIndex = 2
      Me._zoomNoneButton.Text = "Zoom none"
      Me._zoomNoneButton.UseVisualStyleBackColor = True
      '
      '_sizeModeComboBox
      '
      Me._sizeModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._sizeModeComboBox.FormattingEnabled = True
      Me._sizeModeComboBox.Location = New System.Drawing.Point(119, 101)
      Me._sizeModeComboBox.Name = "_sizeModeComboBox"
      Me._sizeModeComboBox.Size = New System.Drawing.Size(127, 21)
      Me._sizeModeComboBox.TabIndex = 7
      '
      '_sizeModeLabel
      '
      Me._sizeModeLabel.AutoSize = True
      Me._sizeModeLabel.Location = New System.Drawing.Point(54, 104)
      Me._sizeModeLabel.Name = "_sizeModeLabel"
      Me._sizeModeLabel.Size = New System.Drawing.Size(59, 13)
      Me._sizeModeLabel.TabIndex = 6
      Me._sizeModeLabel.Text = "Size mode:"
      '
      '_verticalAlignmentComboBox
      '
      Me._verticalAlignmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._verticalAlignmentComboBox.FormattingEnabled = True
      Me._verticalAlignmentComboBox.Location = New System.Drawing.Point(119, 155)
      Me._verticalAlignmentComboBox.Name = "_verticalAlignmentComboBox"
      Me._verticalAlignmentComboBox.Size = New System.Drawing.Size(127, 21)
      Me._verticalAlignmentComboBox.TabIndex = 11
      '
      '_verticalAlignmentLabel
      '
      Me._verticalAlignmentLabel.AutoSize = True
      Me._verticalAlignmentLabel.Location = New System.Drawing.Point(20, 158)
      Me._verticalAlignmentLabel.Name = "_verticalAlignmentLabel"
      Me._verticalAlignmentLabel.Size = New System.Drawing.Size(93, 13)
      Me._verticalAlignmentLabel.TabIndex = 10
      Me._verticalAlignmentLabel.Text = "Vertical alignment:"
      '
      '_horizontalAlignmentComboBox
      '
      Me._horizontalAlignmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._horizontalAlignmentComboBox.FormattingEnabled = True
      Me._horizontalAlignmentComboBox.Location = New System.Drawing.Point(119, 128)
      Me._horizontalAlignmentComboBox.Name = "_horizontalAlignmentComboBox"
      Me._horizontalAlignmentComboBox.Size = New System.Drawing.Size(127, 21)
      Me._horizontalAlignmentComboBox.TabIndex = 9
      '
      '_horizontalAlignmentLabel
      '
      Me._horizontalAlignmentLabel.AutoSize = True
      Me._horizontalAlignmentLabel.Location = New System.Drawing.Point(8, 131)
      Me._horizontalAlignmentLabel.Name = "_horizontalAlignmentLabel"
      Me._horizontalAlignmentLabel.Size = New System.Drawing.Size(105, 13)
      Me._horizontalAlignmentLabel.TabIndex = 8
      Me._horizontalAlignmentLabel.Text = "Horizontal alignment:"
      '
      '_paddingCheckBox
      '
      Me._paddingCheckBox.AutoSize = True
      Me._paddingCheckBox.Location = New System.Drawing.Point(91, 19)
      Me._paddingCheckBox.Name = "_paddingCheckBox"
      Me._paddingCheckBox.Size = New System.Drawing.Size(65, 17)
      Me._paddingCheckBox.TabIndex = 1
      Me._paddingCheckBox.Text = "Padding"
      Me._paddingCheckBox.UseVisualStyleBackColor = True
      '
      '_useDpiCheckBox
      '
      Me._useDpiCheckBox.AutoSize = True
      Me._useDpiCheckBox.Location = New System.Drawing.Point(12, 19)
      Me._useDpiCheckBox.Name = "_useDpiCheckBox"
      Me._useDpiCheckBox.Size = New System.Drawing.Size(66, 17)
      Me._useDpiCheckBox.TabIndex = 0
      Me._useDpiCheckBox.Text = "Use DPI"
      Me._useDpiCheckBox.UseVisualStyleBackColor = True
      '
      '_ImageViewer
      '
      Me._imageViewer.Dock = System.Windows.Forms.DockStyle.Fill
      Me._imageViewer.Location = New System.Drawing.Point(283, 66)
      Me._imageViewer.Name = "_ImageViewer"
      Me._imageViewer.Size = New System.Drawing.Size(533, 468)
      Me._imageViewer.TabIndex = 3
      '
      '_topPanel
      '
      Me._topPanel.Controls.Add(Me._imageInfoLabel)
      Me._topPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me._topPanel.Location = New System.Drawing.Point(283, 24)
      Me._topPanel.Name = "_topPanel"
      Me._topPanel.Size = New System.Drawing.Size(533, 42)
      Me._topPanel.TabIndex = 2
      '
      '_imageInfoLabel
      '
      Me._imageInfoLabel.AutoSize = True
      Me._imageInfoLabel.Location = New System.Drawing.Point(7, 13)
      Me._imageInfoLabel.Name = "_imageInfoLabel"
      Me._imageInfoLabel.Size = New System.Drawing.Size(85, 13)
      Me._imageInfoLabel.TabIndex = 0
      Me._imageInfoLabel.Text = "_imageInfoLabel"
      '
      '_fastRotate90CounterClockwiseButton
      '
      Me._fastRotate90CounterClockwiseButton.Location = New System.Drawing.Point(15, 89)
      Me._fastRotate90CounterClockwiseButton.Name = "_fastRotate90CounterClockwiseButton"
      Me._fastRotate90CounterClockwiseButton.Size = New System.Drawing.Size(234, 23)
      Me._fastRotate90CounterClockwiseButton.TabIndex = 2
      Me._fastRotate90CounterClockwiseButton.Text = "Fast Rotate 90 counter-clockwise"
      Me._fastRotate90CounterClockwiseButton.UseVisualStyleBackColor = True
      '
      '_mainMenuStrip
      '
      Me._mainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileToolStripMenuItem, Me._helpToolStripMenuItem})
      Me._mainMenuStrip.Location = New System.Drawing.Point(0, 0)
      Me._mainMenuStrip.Name = "_mainMenuStrip"
      Me._mainMenuStrip.Size = New System.Drawing.Size(816, 24)
      Me._mainMenuStrip.TabIndex = 1
      '
      '_fileToolStripMenuItem
      '
      Me._fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._openToolStripMenuItem, Me._closeToolStripMenuItem, Me._fileSep1ToolStripMenuItem, Me._exitToolStripMenuItem})
      Me._fileToolStripMenuItem.Name = "_fileToolStripMenuItem"
      Me._fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
      Me._fileToolStripMenuItem.Text = "&File"
      '
      '_openToolStripMenuItem
      '
      Me._openToolStripMenuItem.Name = "_openToolStripMenuItem"
      Me._openToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
      Me._openToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
      Me._openToolStripMenuItem.Text = "&Open..."
      '
      '_closeToolStripMenuItem
      '
      Me._closeToolStripMenuItem.Name = "_closeToolStripMenuItem"
      Me._closeToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
      Me._closeToolStripMenuItem.Text = "C&lose"
      '
      '_fileSep1ToolStripMenuItem
      '
      Me._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem"
      Me._fileSep1ToolStripMenuItem.Size = New System.Drawing.Size(152, 6)
      '
      '_exitToolStripMenuItem
      '
      Me._exitToolStripMenuItem.Name = "_exitToolStripMenuItem"
      Me._exitToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
      Me._exitToolStripMenuItem.Text = "E&xit"
      '
      '_helpToolStripMenuItem
      '
      Me._helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._aboutToolStripMenuItem, Me._readMeToolStripMenuItem})
      Me._helpToolStripMenuItem.Name = "_helpToolStripMenuItem"
      Me._helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
      Me._helpToolStripMenuItem.Text = "&Help"
      '
      '_aboutToolStripMenuItem
      '
      Me._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem"
      Me._aboutToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
      Me._aboutToolStripMenuItem.Text = "&About..."
      '
      '_readMeToolStripMenuItem
      '
      Me._readMeToolStripMenuItem.Name = "_readMeToolStripMenuItem"
      Me._readMeToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
      Me._readMeToolStripMenuItem.Text = "&Read me..."
      '
      '_invertImageUnderOverlayRectButton
      '
      Me._invertImageUnderOverlayRectButton.Location = New System.Drawing.Point(15, 118)
      Me._invertImageUnderOverlayRectButton.Name = "_invertImageUnderOverlayRectButton"
      Me._invertImageUnderOverlayRectButton.Size = New System.Drawing.Size(234, 23)
      Me._invertImageUnderOverlayRectButton.TabIndex = 3
      Me._invertImageUnderOverlayRectButton.Text = "Invert image under overlay rectangle"
      Me._invertImageUnderOverlayRectButton.UseVisualStyleBackColor = True
      '
      '_actionsGroupBox
      '
      Me._actionsGroupBox.Controls.Add(Me._drawOverlayRectangleButton)
      Me._actionsGroupBox.Controls.Add(Me._invertImageUnderOverlayRectButton)
      Me._actionsGroupBox.Controls.Add(Me._fastRotate90CounterClockwiseButton)
      Me._actionsGroupBox.Controls.Add(Me._fastRotate90ClockwiseButton)
      Me._actionsGroupBox.Location = New System.Drawing.Point(12, 212)
      Me._actionsGroupBox.Name = "_actionsGroupBox"
      Me._actionsGroupBox.Size = New System.Drawing.Size(260, 151)
      Me._actionsGroupBox.TabIndex = 1
      Me._actionsGroupBox.TabStop = False
      Me._actionsGroupBox.Text = "Actions:"
      '
      '_drawOverlayRectangleButton
      '
      Me._drawOverlayRectangleButton.Location = New System.Drawing.Point(15, 19)
      Me._drawOverlayRectangleButton.Name = "_drawOverlayRectangleButton"
      Me._drawOverlayRectangleButton.Size = New System.Drawing.Size(234, 23)
      Me._drawOverlayRectangleButton.TabIndex = 0
      Me._drawOverlayRectangleButton.Text = "Draw overlay rectangle"
      Me._drawOverlayRectangleButton.UseVisualStyleBackColor = True
      '
      '_leftPanel
      '
      Me._leftPanel.Controls.Add(Me._actionsGroupBox)
      Me._leftPanel.Controls.Add(Me._viewPropertiesGroupBox)
      Me._leftPanel.Dock = System.Windows.Forms.DockStyle.Left
      Me._leftPanel.Location = New System.Drawing.Point(0, 24)
      Me._leftPanel.Name = "_leftPanel"
      Me._leftPanel.Size = New System.Drawing.Size(283, 552)
      Me._leftPanel.TabIndex = 0
      '
      'MainForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(816, 576)
      Me.Controls.Add(Me._imageViewer)
      Me.Controls.Add(Me._bottomPanel)
      Me.Controls.Add(Me._topPanel)
      Me.Controls.Add(Me._leftPanel)
      Me.Controls.Add(Me._mainMenuStrip)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "MainForm"
      Me.Text = "MainForm"
      Me._bottomPanel.ResumeLayout(False)
      Me._bottomPanel.PerformLayout()
      Me._viewPropertiesGroupBox.ResumeLayout(False)
      Me._viewPropertiesGroupBox.PerformLayout()
      Me._topPanel.ResumeLayout(False)
      Me._topPanel.PerformLayout()
      Me._mainMenuStrip.ResumeLayout(False)
      Me._mainMenuStrip.PerformLayout()
      Me._actionsGroupBox.ResumeLayout(False)
      Me._leftPanel.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents _bottomPanel As System.Windows.Forms.Panel
   Private WithEvents _colorCursorPanel As System.Windows.Forms.Panel
   Private WithEvents _cursorColorValueLabel As System.Windows.Forms.Label
   Private WithEvents _cursorColorLabel As System.Windows.Forms.Label
   Private WithEvents _mousePositionLabel As System.Windows.Forms.Label
   Private WithEvents _fastRotate90ClockwiseButton As System.Windows.Forms.Button
   Private WithEvents _zoomValueLabel As System.Windows.Forms.Label
   Private WithEvents _zoomOutButton As System.Windows.Forms.Button
   Private WithEvents _viewPropertiesGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _zoomInButton As System.Windows.Forms.Button
   Private WithEvents _zoomNoneButton As System.Windows.Forms.Button
   Private WithEvents _sizeModeComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _sizeModeLabel As System.Windows.Forms.Label
   Private WithEvents _verticalAlignmentComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _verticalAlignmentLabel As System.Windows.Forms.Label
   Private WithEvents _horizontalAlignmentComboBox As System.Windows.Forms.ComboBox
   Private WithEvents _horizontalAlignmentLabel As System.Windows.Forms.Label
   Private WithEvents _paddingCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _useDpiCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _imageViewer As ImageViewer
   Private WithEvents _topPanel As System.Windows.Forms.Panel
   Private WithEvents _imageInfoLabel As System.Windows.Forms.Label
   Private WithEvents _fastRotate90CounterClockwiseButton As System.Windows.Forms.Button
   Private WithEvents _mainMenuStrip As System.Windows.Forms.MenuStrip
   Private WithEvents _fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _closeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _fileSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _readMeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _invertImageUnderOverlayRectButton As System.Windows.Forms.Button
   Private WithEvents _actionsGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _drawOverlayRectangleButton As System.Windows.Forms.Button
   Private WithEvents _leftPanel As System.Windows.Forms.Panel

End Class
