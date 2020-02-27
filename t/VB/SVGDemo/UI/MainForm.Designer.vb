Namespace SvgDemo
   Partial Class MainForm
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
         If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._menuStrip = New System.Windows.Forms.MenuStrip()
         Me._fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._printToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._printPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._separator1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._multiPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._firstPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._previousPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._nextPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._lastPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._documentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._getTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._saveTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._selectTextToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._separator2ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._showDocInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._preferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._useDpiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._transformAtCenterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._loadSVGOptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._controlsPanel = New System.Windows.Forms.Panel()
         Me._gbSvgInfo = New System.Windows.Forms.GroupBox()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me._mousePositionLabel = New System.Windows.Forms.Label()
         Me.groupBox3 = New System.Windows.Forms.GroupBox()
         Me.label5 = New System.Windows.Forms.Label()
         Me.label4 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me._pagePanel = New System.Windows.Forms.Panel()
         Me._fileNameLabel = New System.Windows.Forms.Label()
         Me._separator3ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
         Me._gotoPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
         Me._menuStrip.SuspendLayout()
         Me._controlsPanel.SuspendLayout()
         Me._gbSvgInfo.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me.groupBox3.SuspendLayout()
         Me._pagePanel.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _menuStrip
         ' 
         Me._menuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileToolStripMenuItem, Me._multiPageToolStripMenuItem, Me._documentToolStripMenuItem, Me._preferencesToolStripMenuItem, Me._helpToolStripMenuItem})
         Me._menuStrip.Location = New System.Drawing.Point(0, 0)
         Me._menuStrip.Name = "_menuStrip"
         Me._menuStrip.Size = New System.Drawing.Size(818, 24)
         Me._menuStrip.TabIndex = 0
         ' 
         ' _fileToolStripMenuItem
         ' 
         Me._fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._openToolStripMenuItem, Me._printToolStripMenuItem, Me._printPreviewToolStripMenuItem, Me._separator1ToolStripMenuItem, Me._exitToolStripMenuItem})
         Me._fileToolStripMenuItem.Name = "_fileToolStripMenuItem"
         Me._fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
         Me._fileToolStripMenuItem.Text = "&File"
         ' 
         ' _openToolStripMenuItem
         ' 
         Me._openToolStripMenuItem.Name = "_openToolStripMenuItem"
         Me._openToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
         Me._openToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
         Me._openToolStripMenuItem.Text = "&Open..."
         ' 
         ' _printToolStripMenuItem
         ' 
         Me._printToolStripMenuItem.Name = "_printToolStripMenuItem"
         Me._printToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
         Me._printToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
         Me._printToolStripMenuItem.Text = "&Print..."
         ' 
         ' _printPreviewToolStripMenuItem
         ' 
         Me._printPreviewToolStripMenuItem.Name = "_printPreviewToolStripMenuItem"
         Me._printPreviewToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
         Me._printPreviewToolStripMenuItem.Text = "Print Pre&view..."
         ' 
         ' _separator1ToolStripMenuItem
         ' 
         Me._separator1ToolStripMenuItem.Name = "_separator1ToolStripMenuItem"
         Me._separator1ToolStripMenuItem.Size = New System.Drawing.Size(152, 6)
         ' 
         ' _exitToolStripMenuItem
         ' 
         Me._exitToolStripMenuItem.Name = "_exitToolStripMenuItem"
         Me._exitToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
         Me._exitToolStripMenuItem.Text = "E&xit"
         ' 
         ' _multiPageToolStripMenuItem
         ' 
         Me._multiPageToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._firstPageToolStripMenuItem, Me._previousPageToolStripMenuItem, Me._nextPageToolStripMenuItem, Me._lastPageToolStripMenuItem, Me._separator3ToolStripMenuItem, Me._gotoPageToolStripMenuItem})
         Me._multiPageToolStripMenuItem.Name = "_multiPageToolStripMenuItem"
         Me._multiPageToolStripMenuItem.Size = New System.Drawing.Size(78, 20)
         Me._multiPageToolStripMenuItem.Text = "&Multi-Page"
         ' 
         ' _firstPageToolStripMenuItem
         ' 
         Me._firstPageToolStripMenuItem.Name = "_firstPageToolStripMenuItem"
         Me._firstPageToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me._firstPageToolStripMenuItem.Text = "&First"
         ' 
         ' _previousPageToolStripMenuItem
         ' 
         Me._previousPageToolStripMenuItem.Name = "_previousPageToolStripMenuItem"
         Me._previousPageToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me._previousPageToolStripMenuItem.Text = "&Previous"
         ' 
         ' _nextPageToolStripMenuItem
         ' 
         Me._nextPageToolStripMenuItem.Name = "_nextPageToolStripMenuItem"
         Me._nextPageToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me._nextPageToolStripMenuItem.Text = "&Next"
         ' 
         ' _lastPageToolStripMenuItem
         ' 
         Me._lastPageToolStripMenuItem.Name = "_lastPageToolStripMenuItem"
         Me._lastPageToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me._lastPageToolStripMenuItem.Text = "&Last"
         ' 
         ' _documentToolStripMenuItem
         ' 
         Me._documentToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._getTextToolStripMenuItem, Me._saveTextToolStripMenuItem, Me._selectTextToolStripMenuItem, Me._separator2ToolStripMenuItem, Me._showDocInfoToolStripMenuItem})
         Me._documentToolStripMenuItem.Name = "_documentToolStripMenuItem"
         Me._documentToolStripMenuItem.Size = New System.Drawing.Size(75, 20)
         Me._documentToolStripMenuItem.Text = "&Document"
         ' 
         ' _getTextToolStripMenuItem
         ' 
         Me._getTextToolStripMenuItem.Name = "_getTextToolStripMenuItem"
         Me._getTextToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
         Me._getTextToolStripMenuItem.Text = "&Get Text"
         ' 
         ' _saveTextToolStripMenuItem
         ' 
         Me._saveTextToolStripMenuItem.Name = "_saveTextToolStripMenuItem"
         Me._saveTextToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
         Me._saveTextToolStripMenuItem.Text = "&Save Text..."
         ' 
         ' _selectTextToolStripMenuItem
         ' 
         Me._selectTextToolStripMenuItem.Name = "_selectTextToolStripMenuItem"
         Me._selectTextToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
         Me._selectTextToolStripMenuItem.Text = "Select &Text"
         ' 
         ' _separator2ToolStripMenuItem
         ' 
         Me._separator2ToolStripMenuItem.Name = "_separator2ToolStripMenuItem"
         Me._separator2ToolStripMenuItem.Size = New System.Drawing.Size(237, 6)
         ' 
         ' _showDocInfoToolStripMenuItem
         ' 
         Me._showDocInfoToolStripMenuItem.Name = "_showDocInfoToolStripMenuItem"
         Me._showDocInfoToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
         Me._showDocInfoToolStripMenuItem.Text = "Show Document &Information ..."
         ' 
         ' _preferencesToolStripMenuItem
         ' 
         Me._preferencesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._useDpiToolStripMenuItem, Me._transformAtCenterToolStripMenuItem, Me._loadSVGOptionsToolStripMenuItem})
         Me._preferencesToolStripMenuItem.Name = "_preferencesToolStripMenuItem"
         Me._preferencesToolStripMenuItem.Size = New System.Drawing.Size(80, 20)
         Me._preferencesToolStripMenuItem.Text = "&Preferences"
         ' 
         ' _useDpiToolStripMenuItem
         ' 
         Me._useDpiToolStripMenuItem.Name = "_useDpiToolStripMenuItem"
         Me._useDpiToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
         Me._useDpiToolStripMenuItem.Text = "Use &Dpi"
         ' 
         ' _transformAtCenterToolStripMenuItem
         ' 
         Me._transformAtCenterToolStripMenuItem.Name = "_transformAtCenterToolStripMenuItem"
         Me._transformAtCenterToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
         Me._transformAtCenterToolStripMenuItem.Text = "Transform At &Center"
         ' 
         ' _loadSVGOptionsToolStripMenuItem
         ' 
         Me._loadSVGOptionsToolStripMenuItem.Name = "_loadSVGOptionsToolStripMenuItem"
         Me._loadSVGOptionsToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
         Me._loadSVGOptionsToolStripMenuItem.Text = "&Load SVG Options..."
         ' 
         ' _helpToolStripMenuItem
         ' 
         Me._helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._aboutToolStripMenuItem})
         Me._helpToolStripMenuItem.Name = "_helpToolStripMenuItem"
         Me._helpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
         Me._helpToolStripMenuItem.Text = "&Help"
         ' 
         ' _aboutToolStripMenuItem
         ' 
         Me._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem"
         Me._aboutToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me._aboutToolStripMenuItem.Text = "&About"
         ' 
         ' _controlsPanel
         ' 
         Me._controlsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._controlsPanel.Controls.Add(Me._gbSvgInfo)
         Me._controlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom
         Me._controlsPanel.Location = New System.Drawing.Point(0, 553)
         Me._controlsPanel.Name = "_controlsPanel"
         Me._controlsPanel.Size = New System.Drawing.Size(818, 78)
         Me._controlsPanel.TabIndex = 1
         ' 
         ' _gbSvgInfo
         ' 
         Me._gbSvgInfo.Controls.Add(Me.groupBox2)
         Me._gbSvgInfo.Controls.Add(Me.groupBox3)
         Me._gbSvgInfo.Location = New System.Drawing.Point(13, 3)
         Me._gbSvgInfo.Name = "_gbSvgInfo"
         Me._gbSvgInfo.Size = New System.Drawing.Size(791, 65)
         Me._gbSvgInfo.TabIndex = 0
         Me._gbSvgInfo.TabStop = False
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.Controls.Add(Me.label1)
         Me.groupBox2.Controls.Add(Me._mousePositionLabel)
         Me.groupBox2.Location = New System.Drawing.Point(15, 7)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(296, 52)
         Me.groupBox2.TabIndex = 16
         Me.groupBox2.TabStop = False
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(7, 22)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(82, 13)
         Me.label1.TabIndex = 10
         Me.label1.Text = "Mouse Position:"
         ' 
         ' _mousePositionLabel
         ' 
         Me._mousePositionLabel.AutoSize = True
         Me._mousePositionLabel.Location = New System.Drawing.Point(95, 22)
         Me._mousePositionLabel.Name = "_mousePositionLabel"
         Me._mousePositionLabel.Size = New System.Drawing.Size(0, 13)
         Me._mousePositionLabel.TabIndex = 9
         ' 
         ' groupBox3
         ' 
         Me.groupBox3.Controls.Add(Me.label5)
         Me.groupBox3.Controls.Add(Me.label4)
         Me.groupBox3.Controls.Add(Me.label3)
         Me.groupBox3.Controls.Add(Me.label2)
         Me.groupBox3.Location = New System.Drawing.Point(322, 7)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(453, 52)
         Me.groupBox3.TabIndex = 15
         Me.groupBox3.TabStop = False
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(212, 34)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(137, 13)
         Me.label5.TabIndex = 16
         Me.label5.Text = "Right mouse click = Identity"
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(18, 35)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(176, 13)
         Me.label4.TabIndex = 15
         Me.label4.Text = "Alt + left mouse click + drag = rotate"
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(212, 14)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(214, 13)
         Me.label3.TabIndex = 14
         Me.label3.Text = "Ctrl + left mouse click + drag = zoom in / out"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(18, 14)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(148, 13)
         Me.label2.TabIndex = 13
         Me.label2.Text = "Left mouse click + drag = Pan"
         ' 
         ' _pagePanel
         ' 
         Me._pagePanel.Controls.Add(Me._fileNameLabel)
         Me._pagePanel.Dock = System.Windows.Forms.DockStyle.Top
         Me._pagePanel.Location = New System.Drawing.Point(0, 24)
         Me._pagePanel.Name = "_pagePanel"
         Me._pagePanel.Size = New System.Drawing.Size(818, 23)
         Me._pagePanel.TabIndex = 2
         ' 
         ' _fileNameLabel
         ' 
         Me._fileNameLabel.AutoSize = True
         Me._fileNameLabel.Location = New System.Drawing.Point(16, 5)
         Me._fileNameLabel.Name = "_fileNameLabel"
         Me._fileNameLabel.Size = New System.Drawing.Size(0, 13)
         Me._fileNameLabel.TabIndex = 0
         ' 
         ' _separator3ToolStripMenuItem
         ' 
         Me._separator3ToolStripMenuItem.Name = "_separator3ToolStripMenuItem"
         Me._separator3ToolStripMenuItem.Size = New System.Drawing.Size(149, 6)
         ' 
         ' _gotoPageToolStripMenuItem
         ' 
         Me._gotoPageToolStripMenuItem.Name = "_gotoPageToolStripMenuItem"
         Me._gotoPageToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
         Me._gotoPageToolStripMenuItem.Text = "&Goto page..."
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(818, 631)
         Me.Controls.Add(Me._pagePanel)
         Me.Controls.Add(Me._controlsPanel)
         Me.Controls.Add(Me._menuStrip)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MainMenuStrip = Me._menuStrip
         Me.Name = "MainForm"
         Me.Text = "MainForm"
         Me._menuStrip.ResumeLayout(False)
         Me._menuStrip.PerformLayout()
         Me._controlsPanel.ResumeLayout(False)
         Me._gbSvgInfo.ResumeLayout(False)
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.groupBox3.ResumeLayout(False)
         Me.groupBox3.PerformLayout()
         Me._pagePanel.ResumeLayout(False)
         Me._pagePanel.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _menuStrip As System.Windows.Forms.MenuStrip
      Private _fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _separator1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _controlsPanel As System.Windows.Forms.Panel
      Private _preferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _useDpiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _transformAtCenterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _documentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _getTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _saveTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _separator2ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _showDocInfoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _printToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _multiPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _firstPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _previousPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _nextPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _lastPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _gbSvgInfo As System.Windows.Forms.GroupBox
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private label1 As System.Windows.Forms.Label
      Private _mousePositionLabel As System.Windows.Forms.Label
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private label5 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private WithEvents _printPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _selectTextToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _pagePanel As System.Windows.Forms.Panel
      Private _fileNameLabel As System.Windows.Forms.Label
      Private WithEvents _loadSVGOptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
      Private _separator3ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _gotoPageToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   End Class
End Namespace
