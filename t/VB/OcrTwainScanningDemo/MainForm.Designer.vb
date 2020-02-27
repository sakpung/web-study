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
      Me._gbFinalDocument = New System.Windows.Forms.GroupBox
      Me._documentFormatSelector = New OcrTwainScanningDemo.DocumentFormatSelector
      Me._btnFinalDocumentFileName = New System.Windows.Forms.Button
      Me._tbFinalDocumentFileName = New System.Windows.Forms.TextBox
      Me._lblFinalDocumentFormat = New System.Windows.Forms.Label
      Me._lblFinalDocumentFileName = New System.Windows.Forms.Label
      Me._lblInfo = New System.Windows.Forms.Label
      Me._lblOcrEngineName = New System.Windows.Forms.Label
      Me._msMain = New System.Windows.Forms.MenuStrip
      Me._miFile = New System.Windows.Forms.ToolStripMenuItem
      Me._miFileExit = New System.Windows.Forms.ToolStripMenuItem
      Me._miTwain = New System.Windows.Forms.ToolStripMenuItem
      Me._miTwainSelectSource = New System.Windows.Forms.ToolStripMenuItem
      Me._miOcr = New System.Windows.Forms.ToolStripMenuItem
      Me._miOcrSettings = New System.Windows.Forms.ToolStripMenuItem
      Me._miOcrComponents = New System.Windows.Forms.ToolStripMenuItem
      Me._miHelp = New System.Windows.Forms.ToolStripMenuItem
      Me._miHelpAbout = New System.Windows.Forms.ToolStripMenuItem
      Me._gbEngines = New System.Windows.Forms.GroupBox
      Me._lblOcrEngine = New System.Windows.Forms.Label
      Me._lblTwainSourceName = New System.Windows.Forms.Label
      Me._lblTwainSource = New System.Windows.Forms.Label
      Me._btnScan = New System.Windows.Forms.Button
      Me._gbFinalDocument.SuspendLayout()
      Me._msMain.SuspendLayout()
      Me._gbEngines.SuspendLayout()
      Me.SuspendLayout()
      '
      '_gbFinalDocument
      '
      Me._gbFinalDocument.Controls.Add(Me._documentFormatSelector)
      Me._gbFinalDocument.Controls.Add(Me._btnFinalDocumentFileName)
      Me._gbFinalDocument.Controls.Add(Me._tbFinalDocumentFileName)
      Me._gbFinalDocument.Controls.Add(Me._lblFinalDocumentFormat)
      Me._gbFinalDocument.Controls.Add(Me._lblFinalDocumentFileName)
      Me._gbFinalDocument.Location = New System.Drawing.Point(15, 281)
      Me._gbFinalDocument.Name = "_gbFinalDocument"
      Me._gbFinalDocument.Size = New System.Drawing.Size(619, 138)
      Me._gbFinalDocument.TabIndex = 8
      Me._gbFinalDocument.TabStop = False
      Me._gbFinalDocument.Text = "Final document properties:"
      '
      '_documentFormatSelector
      '
      Me._documentFormatSelector.Location = New System.Drawing.Point(13, 106)
      Me._documentFormatSelector.Name = "_documentFormatSelector"
      Me._documentFormatSelector.Size = New System.Drawing.Size(449, 23)
      Me._documentFormatSelector.TabIndex = 4
      '
      '_btnFinalDocumentFileName
      '
      Me._btnFinalDocumentFileName.Location = New System.Drawing.Point(433, 46)
      Me._btnFinalDocumentFileName.Name = "_btnFinalDocumentFileName"
      Me._btnFinalDocumentFileName.Size = New System.Drawing.Size(29, 23)
      Me._btnFinalDocumentFileName.TabIndex = 2
      Me._btnFinalDocumentFileName.Text = "&..."
      Me._btnFinalDocumentFileName.UseVisualStyleBackColor = True
      '
      '_tbFinalDocumentFileName
      '
      Me._tbFinalDocumentFileName.Location = New System.Drawing.Point(13, 48)
      Me._tbFinalDocumentFileName.Name = "_tbFinalDocumentFileName"
      Me._tbFinalDocumentFileName.Size = New System.Drawing.Size(414, 20)
      Me._tbFinalDocumentFileName.TabIndex = 1
      '
      '_lblFinalDocumentFormat
      '
      Me._lblFinalDocumentFormat.AutoSize = True
      Me._lblFinalDocumentFormat.Location = New System.Drawing.Point(10, 89)
      Me._lblFinalDocumentFormat.Name = "_lblFinalDocumentFormat"
      Me._lblFinalDocumentFormat.Size = New System.Drawing.Size(276, 13)
      Me._lblFinalDocumentFormat.TabIndex = 3
      Me._lblFinalDocumentFormat.Text = "Document format to use when saving the final document:"
      Me._lblFinalDocumentFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_lblFinalDocumentFileName
      '
      Me._lblFinalDocumentFileName.AutoSize = True
      Me._lblFinalDocumentFileName.Location = New System.Drawing.Point(10, 31)
      Me._lblFinalDocumentFileName.Name = "_lblFinalDocumentFileName"
      Me._lblFinalDocumentFileName.Size = New System.Drawing.Size(157, 13)
      Me._lblFinalDocumentFileName.TabIndex = 0
      Me._lblFinalDocumentFileName.Text = "&File name of the final document:"
      Me._lblFinalDocumentFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_lblInfo
      '
      Me._lblInfo.AutoSize = True
      Me._lblInfo.Location = New System.Drawing.Point(12, 46)
      Me._lblInfo.Name = "_lblInfo"
      Me._lblInfo.Size = New System.Drawing.Size(622, 91)
      Me._lblInfo.TabIndex = 6
      Me._lblInfo.Text = resources.GetString("_lblInfo.Text")
      '
      '_lblOcrEngineName
      '
      Me._lblOcrEngineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lblOcrEngineName.Location = New System.Drawing.Point(102, 64)
      Me._lblOcrEngineName.Name = "_lblOcrEngineName"
      Me._lblOcrEngineName.Size = New System.Drawing.Size(325, 23)
      Me._lblOcrEngineName.TabIndex = 3
      Me._lblOcrEngineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_msMain
      '
      Me._msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFile, Me._miTwain, Me._miOcr, Me._miHelp})
      Me._msMain.Location = New System.Drawing.Point(0, 0)
      Me._msMain.Name = "_msMain"
      Me._msMain.Size = New System.Drawing.Size(649, 24)
      Me._msMain.TabIndex = 5
      '
      '_miFile
      '
      Me._miFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miFileExit})
      Me._miFile.Name = "_miFile"
      Me._miFile.Size = New System.Drawing.Size(37, 20)
      Me._miFile.Text = "&File"
      '
      '_miFileExit
      '
      Me._miFileExit.Name = "_miFileExit"
      Me._miFileExit.Size = New System.Drawing.Size(92, 22)
      Me._miFileExit.Text = "E&xit"
      '
      '_miTwain
      '
      Me._miTwain.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miTwainSelectSource})
      Me._miTwain.Name = "_miTwain"
      Me._miTwain.Size = New System.Drawing.Size(51, 20)
      Me._miTwain.Text = "&Twain"
      '
      '_miTwainSelectSource
      '
      Me._miTwainSelectSource.Name = "_miTwainSelectSource"
      Me._miTwainSelectSource.Size = New System.Drawing.Size(153, 22)
      Me._miTwainSelectSource.Text = "&Select Source..."
      '
      '_miOcr
      '
      Me._miOcr.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miOcrSettings, Me._miOcrComponents})
      Me._miOcr.Name = "_miOcr"
      Me._miOcr.Size = New System.Drawing.Size(43, 20)
      Me._miOcr.Text = "&OCR"
      '
      '_miOcrSettings
      '
      Me._miOcrSettings.Name = "_miOcrSettings"
      Me._miOcrSettings.Size = New System.Drawing.Size(152, 22)
      Me._miOcrSettings.Text = "&Settings..."
      '
      '_miOcrComponents
      '
      Me._miOcrComponents.Name = "_miOcrComponents"
      Me._miOcrComponents.Size = New System.Drawing.Size(152, 22)
      Me._miOcrComponents.Text = "&Components..."
      '
      '_miHelp
      '
      Me._miHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._miHelpAbout})
      Me._miHelp.Name = "_miHelp"
      Me._miHelp.Size = New System.Drawing.Size(44, 20)
      Me._miHelp.Text = "&Help"
      '
      '_miHelpAbout
      '
      Me._miHelpAbout.Name = "_miHelpAbout"
      Me._miHelpAbout.Size = New System.Drawing.Size(116, 22)
      Me._miHelpAbout.Text = "&About..."
      '
      '_gbEngines
      '
      Me._gbEngines.Controls.Add(Me._lblOcrEngineName)
      Me._gbEngines.Controls.Add(Me._lblOcrEngine)
      Me._gbEngines.Controls.Add(Me._lblTwainSourceName)
      Me._gbEngines.Controls.Add(Me._lblTwainSource)
      Me._gbEngines.Location = New System.Drawing.Point(15, 160)
      Me._gbEngines.Name = "_gbEngines"
      Me._gbEngines.Size = New System.Drawing.Size(619, 102)
      Me._gbEngines.TabIndex = 7
      Me._gbEngines.TabStop = False
      Me._gbEngines.Text = "Engines to use in scan and convert:"
      '
      '_lblOcrEngine
      '
      Me._lblOcrEngine.Location = New System.Drawing.Point(10, 64)
      Me._lblOcrEngine.Name = "_lblOcrEngine"
      Me._lblOcrEngine.Size = New System.Drawing.Size(86, 23)
      Me._lblOcrEngine.TabIndex = 2
      Me._lblOcrEngine.Text = "OCR engine:"
      Me._lblOcrEngine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_lblTwainSourceName
      '
      Me._lblTwainSourceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me._lblTwainSourceName.Location = New System.Drawing.Point(102, 31)
      Me._lblTwainSourceName.Name = "_lblTwainSourceName"
      Me._lblTwainSourceName.Size = New System.Drawing.Size(325, 23)
      Me._lblTwainSourceName.TabIndex = 1
      Me._lblTwainSourceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_lblTwainSource
      '
      Me._lblTwainSource.Location = New System.Drawing.Point(10, 31)
      Me._lblTwainSource.Name = "_lblTwainSource"
      Me._lblTwainSource.Size = New System.Drawing.Size(86, 23)
      Me._lblTwainSource.TabIndex = 0
      Me._lblTwainSource.Text = "Twain source:"
      Me._lblTwainSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      '_btnScan
      '
      Me._btnScan.Location = New System.Drawing.Point(15, 438)
      Me._btnScan.Name = "_btnScan"
      Me._btnScan.Size = New System.Drawing.Size(75, 23)
      Me._btnScan.TabIndex = 9
      Me._btnScan.Text = "&Scan..."
      Me._btnScan.UseVisualStyleBackColor = True
      '
      'MainForm
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(649, 468)
      Me.Controls.Add(Me._gbFinalDocument)
      Me.Controls.Add(Me._lblInfo)
      Me.Controls.Add(Me._msMain)
      Me.Controls.Add(Me._gbEngines)
      Me.Controls.Add(Me._btnScan)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.Name = "MainForm"
      Me.Text = "MainForm"
      Me._gbFinalDocument.ResumeLayout(False)
      Me._gbFinalDocument.PerformLayout()
      Me._msMain.ResumeLayout(False)
      Me._msMain.PerformLayout()
      Me._gbEngines.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Private WithEvents _gbFinalDocument As System.Windows.Forms.GroupBox
   Private WithEvents _btnFinalDocumentFileName As System.Windows.Forms.Button
   Private WithEvents _tbFinalDocumentFileName As System.Windows.Forms.TextBox
   Private WithEvents _lblFinalDocumentFormat As System.Windows.Forms.Label
   Private WithEvents _lblFinalDocumentFileName As System.Windows.Forms.Label
   Private WithEvents _lblInfo As System.Windows.Forms.Label
   Private WithEvents _lblOcrEngineName As System.Windows.Forms.Label
   Private WithEvents _msMain As System.Windows.Forms.MenuStrip
   Private WithEvents _miFile As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miFileExit As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miTwain As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miTwainSelectSource As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miOcr As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miOcrSettings As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miOcrComponents As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miHelp As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _miHelpAbout As System.Windows.Forms.ToolStripMenuItem
   Private WithEvents _gbEngines As System.Windows.Forms.GroupBox
   Private WithEvents _lblOcrEngine As System.Windows.Forms.Label
   Private WithEvents _lblTwainSourceName As System.Windows.Forms.Label
   Private WithEvents _lblTwainSource As System.Windows.Forms.Label
   Private WithEvents _btnScan As System.Windows.Forms.Button
   Friend WithEvents _documentFormatSelector As OcrTwainScanningDemo.DocumentFormatSelector

End Class
