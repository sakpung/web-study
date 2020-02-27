
Partial Class RichTextMenu
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RichTextMenu))
      Me._tbRtf = New ToolStripEx()
      Me._cmbFont = New System.Windows.Forms.ToolStripComboBox()
      Me._cmbFontSize = New System.Windows.Forms.ToolStripComboBox()
      Me._btnBold = New System.Windows.Forms.ToolStripButton()
      Me._btnItalic = New System.Windows.Forms.ToolStripButton()
      Me._btnUnderline = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me._btnTextColor = New System.Windows.Forms.ToolStripSplitButton()
      Me._btnBackgroundColor = New System.Windows.Forms.ToolStripSplitButton()
      Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me._btnBullets = New System.Windows.Forms.ToolStripButton()
      Me._btnNumbers = New System.Windows.Forms.ToolStripButton()
      Me._btnIncreaseIdent = New System.Windows.Forms.ToolStripButton()
      Me._btnDecreaseIdent = New System.Windows.Forms.ToolStripButton()
      Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me._btnLeft = New System.Windows.Forms.ToolStripButton()
      Me._btnCenter = New System.Windows.Forms.ToolStripButton()
      Me._btnRight = New System.Windows.Forms.ToolStripButton()
      Me._miRtf = New System.Windows.Forms.MenuStrip()
      Me._miRtfFile = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFileOpen = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFileSave = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFilePrint = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFileExit = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfEdit = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfEditUndo = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfEditSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me._miRtfEditCut = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfEditCopy = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfEditPaste = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfEditDelete = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfEditSelectAll = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFormat = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFormatFont = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFormatSeparator1 = New System.Windows.Forms.ToolStripSeparator()
      Me._miRtfFormatBackgroundColor = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFormatTextColor = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFormatSeparator2 = New System.Windows.Forms.ToolStripSeparator()
      Me._miRtfFormatBullets = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFormatNumbering = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFormatSeparator3 = New System.Windows.Forms.ToolStripSeparator()
      Me._miRtfFormatDecreaseIndent = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFormatIncreaseIndent = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFormatSeparator4 = New System.Windows.Forms.ToolStripSeparator()
      Me._miRtfFormatLeft = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFormatCenter = New System.Windows.Forms.ToolStripMenuItem()
      Me._miRtfFormatRight = New System.Windows.Forms.ToolStripMenuItem()
      Me._tbRtf.SuspendLayout()
      Me._miRtf.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _tbRtf
      ' 
      Me._tbRtf.ClickThrough = True
      Me._tbRtf.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._cmbFont, Me._cmbFontSize, Me._btnBold, Me._btnItalic, Me._btnUnderline, Me.toolStripSeparator2, _
       Me._btnTextColor, Me._btnBackgroundColor, Me.toolStripSeparator3, Me._btnBullets, Me._btnNumbers, Me._btnIncreaseIdent, _
       Me._btnDecreaseIdent, Me.toolStripSeparator4, Me._btnLeft, Me._btnCenter, Me._btnRight})
      Me._tbRtf.Location = New System.Drawing.Point(0, 24)
      Me._tbRtf.Name = "_tbRtf"
      Me._tbRtf.Size = New System.Drawing.Size(608, 25)
      Me._tbRtf.TabIndex = 0
      Me._tbRtf.Text = "_tbRtf"
      ' 
      ' _cmbFont
      ' 
      Me._cmbFont.Name = "_cmbFont"
      Me._cmbFont.Size = New System.Drawing.Size(200, 25)
      ' 
      ' _cmbFontSize
      ' 
      Me._cmbFontSize.Name = "_cmbFontSize"
      Me._cmbFontSize.Size = New System.Drawing.Size(75, 25)
      ' 
      ' _btnBold
      ' 
      Me._btnBold.CheckOnClick = True
      Me._btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnBold.Image = CType(resources.GetObject("_btnBold.Image"), System.Drawing.Image)
      Me._btnBold.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnBold.Name = "_btnBold"
      Me._btnBold.Size = New System.Drawing.Size(23, 22)
      Me._btnBold.Text = "toolStripButton5"
      ' 
      ' _btnItalic
      ' 
      Me._btnItalic.CheckOnClick = True
      Me._btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnItalic.Image = CType(resources.GetObject("_btnItalic.Image"), System.Drawing.Image)
      Me._btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnItalic.Name = "_btnItalic"
      Me._btnItalic.Size = New System.Drawing.Size(23, 22)
      Me._btnItalic.Text = "toolStripButton6"
      ' 
      ' _btnUnderline
      ' 
      Me._btnUnderline.CheckOnClick = True
      Me._btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnUnderline.Image = CType(resources.GetObject("_btnUnderline.Image"), System.Drawing.Image)
      Me._btnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnUnderline.Name = "_btnUnderline"
      Me._btnUnderline.Size = New System.Drawing.Size(23, 22)
      Me._btnUnderline.Text = "toolStripButton4"
      ' 
      ' toolStripSeparator2
      ' 
      Me.toolStripSeparator2.Name = "toolStripSeparator2"
      Me.toolStripSeparator2.Size = New System.Drawing.Size(6, 25)
      ' 
      ' _btnTextColor
      ' 
      Me._btnTextColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnTextColor.Image = CType(resources.GetObject("_btnTextColor.Image"), System.Drawing.Image)
      Me._btnTextColor.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnTextColor.Name = "_btnTextColor"
      Me._btnTextColor.Size = New System.Drawing.Size(32, 22)
      Me._btnTextColor.Text = "toolStripSplitButton1"
      ' 
      ' _btnBackgroundColor
      ' 
      Me._btnBackgroundColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnBackgroundColor.Image = CType(resources.GetObject("_btnBackgroundColor.Image"), System.Drawing.Image)
      Me._btnBackgroundColor.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnBackgroundColor.Name = "_btnBackgroundColor"
      Me._btnBackgroundColor.Size = New System.Drawing.Size(32, 22)
      Me._btnBackgroundColor.Text = "toolStripSplitButton2"
      ' 
      ' toolStripSeparator3
      ' 
      Me.toolStripSeparator3.Name = "toolStripSeparator3"
      Me.toolStripSeparator3.Size = New System.Drawing.Size(6, 25)
      ' 
      ' _btnBullets
      ' 
      Me._btnBullets.CheckOnClick = True
      Me._btnBullets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnBullets.Image = CType(resources.GetObject("_btnBullets.Image"), System.Drawing.Image)
      Me._btnBullets.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnBullets.Name = "_btnBullets"
      Me._btnBullets.Size = New System.Drawing.Size(23, 22)
      Me._btnBullets.Text = "toolStripButton7"
      ' 
      ' _btnNumbers
      ' 
      Me._btnNumbers.CheckOnClick = True
      Me._btnNumbers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnNumbers.Image = CType(resources.GetObject("_btnNumbers.Image"), System.Drawing.Image)
      Me._btnNumbers.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnNumbers.Name = "_btnNumbers"
      Me._btnNumbers.Size = New System.Drawing.Size(23, 22)
      Me._btnNumbers.Text = "toolStripButton8"
      ' 
      ' _btnIncreaseIdent
      ' 
      Me._btnIncreaseIdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnIncreaseIdent.Image = CType(resources.GetObject("_btnIncreaseIdent.Image"), System.Drawing.Image)
      Me._btnIncreaseIdent.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnIncreaseIdent.Name = "_btnIncreaseIdent"
      Me._btnIncreaseIdent.Size = New System.Drawing.Size(23, 22)
      Me._btnIncreaseIdent.Text = "toolStripButton9"
      ' 
      ' _btnDecreaseIdent
      ' 
      Me._btnDecreaseIdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnDecreaseIdent.Image = CType(resources.GetObject("_btnDecreaseIdent.Image"), System.Drawing.Image)
      Me._btnDecreaseIdent.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnDecreaseIdent.Name = "_btnDecreaseIdent"
      Me._btnDecreaseIdent.Size = New System.Drawing.Size(23, 22)
      Me._btnDecreaseIdent.Text = "toolStripButton10"
      ' 
      ' toolStripSeparator4
      ' 
      Me.toolStripSeparator4.Name = "toolStripSeparator4"
      Me.toolStripSeparator4.Size = New System.Drawing.Size(6, 25)
      ' 
      ' _btnLeft
      ' 
      Me._btnLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnLeft.Image = CType(resources.GetObject("_btnLeft.Image"), System.Drawing.Image)
      Me._btnLeft.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnLeft.Name = "_btnLeft"
      Me._btnLeft.Size = New System.Drawing.Size(23, 22)
      Me._btnLeft.Text = "toolStripButton1"
      ' 
      ' _btnCenter
      ' 
      Me._btnCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnCenter.Image = CType(resources.GetObject("_btnCenter.Image"), System.Drawing.Image)
      Me._btnCenter.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnCenter.Name = "_btnCenter"
      Me._btnCenter.Size = New System.Drawing.Size(23, 22)
      Me._btnCenter.Text = "toolStripButton1"
      ' 
      ' _btnRight
      ' 
      Me._btnRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
      Me._btnRight.Image = CType(resources.GetObject("_btnRight.Image"), System.Drawing.Image)
      Me._btnRight.ImageTransparentColor = System.Drawing.Color.Magenta
      Me._btnRight.Name = "_btnRight"
      Me._btnRight.Size = New System.Drawing.Size(23, 22)
      Me._btnRight.Text = "toolStripButton1"
      ' 
      ' _miRtf
      ' 
      Me._miRtf.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRtfFile, Me._miRtfEdit, Me._miRtfFormat})
      Me._miRtf.Location = New System.Drawing.Point(0, 0)
      Me._miRtf.Name = "_miRtf"
      Me._miRtf.Size = New System.Drawing.Size(608, 24)
      Me._miRtf.TabIndex = 1
      Me._miRtf.Text = "menuStrip1"
      ' 
      ' _miRtfFile
      ' 
      Me._miRtfFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRtfFileOpen, Me._miRtfFileSave, Me._miRtfFilePrint, Me._miRtfFileExit})
      Me._miRtfFile.Name = "_miRtfFile"
      Me._miRtfFile.Size = New System.Drawing.Size(37, 20)
      Me._miRtfFile.Text = "&File"
      ' 
      ' _miRtfFileOpen
      ' 
      Me._miRtfFileOpen.Name = "_miRtfFileOpen"
      Me._miRtfFileOpen.Size = New System.Drawing.Size(124, 22)
      Me._miRtfFileOpen.Text = "&Open"
      ' 
      ' _miRtfFileSave
      ' 
      Me._miRtfFileSave.Name = "_miRtfFileSave"
      Me._miRtfFileSave.Size = New System.Drawing.Size(124, 22)
      Me._miRtfFileSave.Text = "&Save as ..."
      ' 
      ' _miRtfFilePrint
      ' 
      Me._miRtfFilePrint.Name = "_miRtfFilePrint"
      Me._miRtfFilePrint.Size = New System.Drawing.Size(124, 22)
      Me._miRtfFilePrint.Text = "&Print..."
      ' 
      ' _miRtfFileExit
      ' 
      Me._miRtfFileExit.Name = "_miRtfFileExit"
      Me._miRtfFileExit.Size = New System.Drawing.Size(124, 22)
      Me._miRtfFileExit.Text = "E&xit"
      ' 
      ' _miRtfEdit
      ' 
      Me._miRtfEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRtfEditUndo, Me._miRtfEditSeparator1, Me._miRtfEditCut, Me._miRtfEditCopy, Me._miRtfEditPaste, Me._miRtfEditDelete, _
       Me._miRtfEditSelectAll})
      Me._miRtfEdit.Name = "_miRtfEdit"
      Me._miRtfEdit.Size = New System.Drawing.Size(39, 20)
      Me._miRtfEdit.Text = "&Edit"
      ' 
      ' _miRtfEditUndo
      ' 
      Me._miRtfEditUndo.Name = "_miRtfEditUndo"
      Me._miRtfEditUndo.Size = New System.Drawing.Size(152, 22)
      Me._miRtfEditUndo.Text = "&Undo"
      ' 
      ' _miRtfEditSeparator1
      ' 
      Me._miRtfEditSeparator1.Name = "_miRtfEditSeparator1"
      Me._miRtfEditSeparator1.Size = New System.Drawing.Size(149, 6)
      ' 
      ' _miRtfEditCut
      ' 
      Me._miRtfEditCut.Name = "_miRtfEditCut"
      Me._miRtfEditCut.Size = New System.Drawing.Size(152, 22)
      Me._miRtfEditCut.Text = "Cu&t"
      ' 
      ' _miRtfEditCopy
      ' 
      Me._miRtfEditCopy.Name = "_miRtfEditCopy"
      Me._miRtfEditCopy.Size = New System.Drawing.Size(152, 22)
      Me._miRtfEditCopy.Text = "&Copy"
      ' 
      ' _miRtfEditPaste
      ' 
      Me._miRtfEditPaste.Name = "_miRtfEditPaste"
      Me._miRtfEditPaste.Size = New System.Drawing.Size(152, 22)
      Me._miRtfEditPaste.Text = "&Paste"
      ' 
      ' _miRtfEditDelete
      ' 
      Me._miRtfEditDelete.Name = "_miRtfEditDelete"
      Me._miRtfEditDelete.Size = New System.Drawing.Size(152, 22)
      Me._miRtfEditDelete.Text = "&Delete"
      ' 
      ' _miRtfEditSelectAll
      ' 
      Me._miRtfEditSelectAll.Name = "_miRtfEditSelectAll"
      Me._miRtfEditSelectAll.Size = New System.Drawing.Size(152, 22)
      Me._miRtfEditSelectAll.Text = "Select &All"
      ' 
      ' _miRtfFormat
      ' 
      Me._miRtfFormat.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miRtfFormatFont, Me._miRtfFormatSeparator1, Me._miRtfFormatBackgroundColor, Me._miRtfFormatTextColor, Me._miRtfFormatSeparator2, Me._miRtfFormatBullets, _
       Me._miRtfFormatNumbering, Me._miRtfFormatSeparator3, Me._miRtfFormatDecreaseIndent, Me._miRtfFormatIncreaseIndent, Me._miRtfFormatSeparator4, Me._miRtfFormatLeft, _
       Me._miRtfFormatCenter, Me._miRtfFormatRight})
      Me._miRtfFormat.Name = "_miRtfFormat"
      Me._miRtfFormat.Size = New System.Drawing.Size(57, 20)
      Me._miRtfFormat.Text = "F&ormat"
      ' 
      ' _miRtfFormatFont
      ' 
      Me._miRtfFormatFont.Name = "_miRtfFormatFont"
      Me._miRtfFormatFont.Size = New System.Drawing.Size(170, 22)
      Me._miRtfFormatFont.Text = "&Font..."
      ' 
      ' _miRtfFormatSeparator1
      ' 
      Me._miRtfFormatSeparator1.Name = "_miRtfFormatSeparator1"
      Me._miRtfFormatSeparator1.Size = New System.Drawing.Size(167, 6)
      ' 
      ' _miRtfFormatBackgroundColor
      ' 
      Me._miRtfFormatBackgroundColor.Name = "_miRtfFormatBackgroundColor"
      Me._miRtfFormatBackgroundColor.Size = New System.Drawing.Size(170, 22)
      Me._miRtfFormatBackgroundColor.Text = "&Background Color"
      ' 
      ' _miRtfFormatTextColor
      ' 
      Me._miRtfFormatTextColor.Name = "_miRtfFormatTextColor"
      Me._miRtfFormatTextColor.Size = New System.Drawing.Size(170, 22)
      Me._miRtfFormatTextColor.Text = "&Text Color"
      ' 
      ' _miRtfFormatSeparator2
      ' 
      Me._miRtfFormatSeparator2.Name = "_miRtfFormatSeparator2"
      Me._miRtfFormatSeparator2.Size = New System.Drawing.Size(167, 6)
      ' 
      ' _miRtfFormatBullets
      ' 
      Me._miRtfFormatBullets.Name = "_miRtfFormatBullets"
      Me._miRtfFormatBullets.Size = New System.Drawing.Size(170, 22)
      Me._miRtfFormatBullets.Text = "Bullet&s"
      ' 
      ' _miRtfFormatNumbering
      ' 
      Me._miRtfFormatNumbering.Name = "_miRtfFormatNumbering"
      Me._miRtfFormatNumbering.Size = New System.Drawing.Size(170, 22)
      Me._miRtfFormatNumbering.Text = "&Numbering"
      ' 
      ' _miRtfFormatSeparator3
      ' 
      Me._miRtfFormatSeparator3.Name = "_miRtfFormatSeparator3"
      Me._miRtfFormatSeparator3.Size = New System.Drawing.Size(167, 6)
      ' 
      ' _miRtfFormatDecreaseIndent
      ' 
      Me._miRtfFormatDecreaseIndent.Name = "_miRtfFormatDecreaseIndent"
      Me._miRtfFormatDecreaseIndent.Size = New System.Drawing.Size(170, 22)
      Me._miRtfFormatDecreaseIndent.Text = "&Decrease Indent"
      ' 
      ' _miRtfFormatIncreaseIndent
      ' 
      Me._miRtfFormatIncreaseIndent.Name = "_miRtfFormatIncreaseIndent"
      Me._miRtfFormatIncreaseIndent.Size = New System.Drawing.Size(170, 22)
      Me._miRtfFormatIncreaseIndent.Text = "&Increase Indent"
      ' 
      ' _miRtfFormatSeparator4
      ' 
      Me._miRtfFormatSeparator4.Name = "_miRtfFormatSeparator4"
      Me._miRtfFormatSeparator4.Size = New System.Drawing.Size(167, 6)
      ' 
      ' _miRtfFormatLeft
      ' 
      Me._miRtfFormatLeft.Name = "_miRtfFormatLeft"
      Me._miRtfFormatLeft.Size = New System.Drawing.Size(170, 22)
      Me._miRtfFormatLeft.Text = "&Left"
      ' 
      ' _miRtfFormatCenter
      ' 
      Me._miRtfFormatCenter.Name = "_miRtfFormatCenter"
      Me._miRtfFormatCenter.Size = New System.Drawing.Size(170, 22)
      Me._miRtfFormatCenter.Text = "&Center"
      ' 
      ' _miRtfFormatRight
      ' 
      Me._miRtfFormatRight.Name = "_miRtfFormatRight"
      Me._miRtfFormatRight.Size = New System.Drawing.Size(170, 22)
      Me._miRtfFormatRight.Text = "&Right"
      ' 
      ' RichTextMenu
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(608, 51)
      Me.Controls.Add(Me._tbRtf)
      Me.Controls.Add(Me._miRtf)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MainMenuStrip = Me._miRtf
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "RichTextMenu"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
      Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
      Me.Text = "RichTextMenu"
      Me._tbRtf.ResumeLayout(False)
      Me._tbRtf.PerformLayout()
      Me._miRtf.ResumeLayout(False)
      Me._miRtf.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _tbRtf As ToolStripEx
   Private WithEvents _cmbFont As System.Windows.Forms.ToolStripComboBox
   Private WithEvents _cmbFontSize As System.Windows.Forms.ToolStripComboBox
   Private WithEvents _btnTextColor As System.Windows.Forms.ToolStripSplitButton
   Private toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _btnBold As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnItalic As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnUnderline As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnBackgroundColor As System.Windows.Forms.ToolStripSplitButton
   Private toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _btnBullets As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnNumbers As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnIncreaseIdent As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnDecreaseIdent As System.Windows.Forms.ToolStripButton
   Private toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
   Private _miRtf As System.Windows.Forms.MenuStrip
   Private _miRtfFile As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfFileOpen As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfFileSave As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfFilePrint As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfFileExit As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfEdit As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfEditUndo As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfEditCut As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfEditCopy As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfEditPaste As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfEditDelete As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfEditSelectAll As System.Windows.Forms.ToolStripMenuItem
   Private _miRtfEditSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private _miRtfFormat As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfFormatFont As System.Windows.Forms.ToolStripMenuItem
   Private _miRtfFormatSeparator1 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miRtfFormatBackgroundColor As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfFormatTextColor As System.Windows.Forms.ToolStripMenuItem
   Private _miRtfFormatSeparator2 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miRtfFormatBullets As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfFormatNumbering As System.Windows.Forms.ToolStripMenuItem
   Private _miRtfFormatSeparator3 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miRtfFormatDecreaseIndent As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfFormatIncreaseIndent As System.Windows.Forms.ToolStripMenuItem
   Private _miRtfFormatSeparator4 As System.Windows.Forms.ToolStripSeparator
   Private WithEvents _miRtfFormatLeft As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfFormatCenter As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miRtfFormatRight As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _btnLeft As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnCenter As System.Windows.Forms.ToolStripButton
   Private WithEvents _btnRight As System.Windows.Forms.ToolStripButton
End Class
