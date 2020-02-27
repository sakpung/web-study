
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
      Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
      Me._mainMenuStrip = New System.Windows.Forms.MenuStrip()
      Me._fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._fileSep1ToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
      Me._exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._layoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._singleLayoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._verticalLayoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._doubleLayoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._horizontalLayoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
      Me._topPanel = New System.Windows.Forms.Panel()
      Me._imageInfoLabel = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me._mainMenuStrip.SuspendLayout()
      Me._topPanel.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _mainMenuStrip
      ' 
      Me._mainMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._fileToolStripMenuItem, Me._layoutToolStripMenuItem, Me._helpToolStripMenuItem})
      Me._mainMenuStrip.Location = New System.Drawing.Point(0, 0)
      Me._mainMenuStrip.Name = "_mainMenuStrip"
      Me._mainMenuStrip.Size = New System.Drawing.Size(936, 24)
      Me._mainMenuStrip.TabIndex = 0
      ' 
      ' _fileToolStripMenuItem
      ' 
      Me._fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._openToolStripMenuItem, Me._fileSep1ToolStripMenuItem, Me._exitToolStripMenuItem})
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
      Me._openToolStripMenuItem.ToolTipText = "Load an image file"
      ' 
      ' _fileSep1ToolStripMenuItem
      ' 
      Me._fileSep1ToolStripMenuItem.Name = "_fileSep1ToolStripMenuItem"
      Me._fileSep1ToolStripMenuItem.Size = New System.Drawing.Size(152, 6)
      ' 
      ' _exitToolStripMenuItem
      ' 
      Me._exitToolStripMenuItem.Name = "_exitToolStripMenuItem"
      Me._exitToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
      Me._exitToolStripMenuItem.Text = "E&xit"
      Me._exitToolStripMenuItem.ToolTipText = "Exit this application"
      ' 
      ' _layoutToolStripMenuItem
      ' 
      Me._layoutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._singleLayoutToolStripMenuItem, Me._verticalLayoutToolStripMenuItem, Me._doubleLayoutToolStripMenuItem, Me._horizontalLayoutToolStripMenuItem})
      Me._layoutToolStripMenuItem.Name = "_layoutToolStripMenuItem"
      Me._layoutToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
      Me._layoutToolStripMenuItem.Text = "&Layout"
      ' 
      ' _singleLayoutToolStripMenuItem
      ' 
      Me._singleLayoutToolStripMenuItem.Name = "_singleLayoutToolStripMenuItem"
      Me._singleLayoutToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
      Me._singleLayoutToolStripMenuItem.Text = "&Single"
      Me._singleLayoutToolStripMenuItem.ToolTipText = "Single page display"
      ' 
      ' _verticalLayoutToolStripMenuItem
      ' 
      Me._verticalLayoutToolStripMenuItem.Name = "_verticalLayoutToolStripMenuItem"
      Me._verticalLayoutToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
      Me._verticalLayoutToolStripMenuItem.Text = "&Vertical"
      Me._verticalLayoutToolStripMenuItem.ToolTipText = "Vertical page display"
      ' 
      ' _doubleLayoutToolStripMenuItem
      ' 
      Me._doubleLayoutToolStripMenuItem.Name = "_doubleLayoutToolStripMenuItem"
      Me._doubleLayoutToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
      Me._doubleLayoutToolStripMenuItem.Text = "&Double"
      Me._doubleLayoutToolStripMenuItem.ToolTipText = "Double page display"
      ' 
      ' _horizontalLayoutToolStripMenuItem
      ' 
      Me._horizontalLayoutToolStripMenuItem.Name = "_horizontalLayoutToolStripMenuItem"
      Me._horizontalLayoutToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
      Me._horizontalLayoutToolStripMenuItem.Text = "&Horizontal"
      Me._horizontalLayoutToolStripMenuItem.ToolTipText = "Horizontal page display"
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
      Me._aboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
      Me._aboutToolStripMenuItem.Text = "&About..."
      Me._aboutToolStripMenuItem.ToolTipText = "About this demo"
      ' 
      ' _topPanel
      ' 
      Me._topPanel.Controls.Add(Me._imageInfoLabel)
      Me._topPanel.Controls.Add(Me.label1)
      Me._topPanel.Dock = System.Windows.Forms.DockStyle.Top
      Me._topPanel.Location = New System.Drawing.Point(0, 24)
      Me._topPanel.Name = "_topPanel"
      Me._topPanel.Size = New System.Drawing.Size(936, 56)
      Me._topPanel.TabIndex = 1
      ' 
      ' _imageInfoLabel
      ' 
      Me._imageInfoLabel.AutoSize = True
      Me._imageInfoLabel.Location = New System.Drawing.Point(4, 29)
      Me._imageInfoLabel.Name = "_imageInfoLabel"
      Me._imageInfoLabel.Size = New System.Drawing.Size(85, 13)
      Me._imageInfoLabel.TabIndex = 2
      Me._imageInfoLabel.Text = "_imageInfoLabel"
      Me._imageInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(4, 4)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(732, 13)
      Me.label1.TabIndex = 0
      Me.label1.Text = "Load an image then click and drag the mouse to pan, ctrl+click to zoom in and out" + ", double click to reset the view. Select the Layout to use from the menu."
      Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      ' 
      ' MainForm
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(936, 491)
      Me.Controls.Add(Me._topPanel)
      Me.Controls.Add(Me._mainMenuStrip)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MainMenuStrip = Me._mainMenuStrip
      Me.Name = "MainForm"
      Me.Text = "MainForm"
      Me._mainMenuStrip.ResumeLayout(False)
      Me._mainMenuStrip.PerformLayout()
      Me._topPanel.ResumeLayout(False)
      Me._topPanel.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _mainMenuStrip As System.Windows.Forms.MenuStrip
   Private _fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _fileSep1ToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _layoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _singleLayoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _verticalLayoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _doubleLayoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _horizontalLayoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
   Private _topPanel As System.Windows.Forms.Panel
   Private label1 As System.Windows.Forms.Label
   Private _imageInfoLabel As System.Windows.Forms.Label
End Class