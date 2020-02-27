
Partial Class ColumnOptions
   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.IContainer = Nothing

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (Not components Is Nothing) Then
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ColumnOptions))
      Me._gbFieldMethod = New System.Windows.Forms.GroupBox()
      Me._chkEnableIcr = New System.Windows.Forms.CheckBox()
      Me._chkEnableOcr = New System.Windows.Forms.CheckBox()
      Me._gbFieldTextType = New System.Windows.Forms.GroupBox()
      Me._rbtextTypeNum = New System.Windows.Forms.RadioButton()
      Me._rbTextTypeChar = New System.Windows.Forms.RadioButton()
      Me._gb_OcrColumnOption = New System.Windows.Forms.GroupBox()
      Me._gbOMRFrame = New System.Windows.Forms.GroupBox()
      Me._rbOMRWithoutFrame = New System.Windows.Forms.RadioButton()
      Me._rbOMRWithFrame = New System.Windows.Forms.RadioButton()
      Me._rbOMRAutoFrame = New System.Windows.Forms.RadioButton()
      Me._gbOMRSensitivity = New System.Windows.Forms.GroupBox()
      Me._rbOMRSensitivityHighest = New System.Windows.Forms.RadioButton()
      Me._rbOMRSensitivityHigh = New System.Windows.Forms.RadioButton()
      Me._rbOMRSensitivityLowest = New System.Windows.Forms.RadioButton()
      Me._rbOMRSensitivityLow = New System.Windows.Forms.RadioButton()
      Me._gb_OmrColumnOptions = New System.Windows.Forms.GroupBox()
      Me._gbBounds = New System.Windows.Forms.GroupBox()
      Me._nudHeight = New System.Windows.Forms.NumericUpDown()
      Me._nudWidth = New System.Windows.Forms.NumericUpDown()
      Me._nudTop = New System.Windows.Forms.NumericUpDown()
      Me._nudLeft = New System.Windows.Forms.NumericUpDown()
      Me._lblFieldHeight = New System.Windows.Forms.Label()
      Me._lblFieldWidth = New System.Windows.Forms.Label()
      Me._lblFieldTop = New System.Windows.Forms.Label()
      Me._lblFieldLeft = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me._txt_ColumnOptionsFieldName = New System.Windows.Forms.TextBox()
      Me._gbKeyColumn = New System.Windows.Forms.GroupBox()
      Me._cbIsKeyColumn = New System.Windows.Forms.CheckBox()
      Me._gbDropoutOptions = New System.Windows.Forms.GroupBox()
      Me._chkDropoutCells = New System.Windows.Forms.CheckBox()
      Me._chkDropoutWords = New System.Windows.Forms.CheckBox()
      Me._btnOK = New System.Windows.Forms.Button()
      Me._gbFieldMethod.SuspendLayout()
      Me._gbFieldTextType.SuspendLayout()
      Me._gb_OcrColumnOption.SuspendLayout()
      Me._gbOMRFrame.SuspendLayout()
      Me._gbOMRSensitivity.SuspendLayout()
      Me._gb_OmrColumnOptions.SuspendLayout()
      Me._gbBounds.SuspendLayout()
      CType(Me._nudHeight, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._nudWidth, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._nudTop, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._nudLeft, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._gbKeyColumn.SuspendLayout()
      Me._gbDropoutOptions.SuspendLayout()
      Me.SuspendLayout()
      '
      '_gbFieldMethod
      '
      Me._gbFieldMethod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbFieldMethod.Controls.Add(Me._chkEnableIcr)
      Me._gbFieldMethod.Controls.Add(Me._chkEnableOcr)
      Me._gbFieldMethod.Location = New System.Drawing.Point(153, 26)
      Me._gbFieldMethod.Name = "_gbFieldMethod"
      Me._gbFieldMethod.Size = New System.Drawing.Size(101, 74)
      Me._gbFieldMethod.TabIndex = 15
      Me._gbFieldMethod.TabStop = False
      Me._gbFieldMethod.Text = "Method"
      '
      '_chkEnableIcr
      '
      Me._chkEnableIcr.AutoSize = True
      Me._chkEnableIcr.Checked = True
      Me._chkEnableIcr.CheckState = System.Windows.Forms.CheckState.Checked
      Me._chkEnableIcr.Location = New System.Drawing.Point(10, 42)
      Me._chkEnableIcr.Name = "_chkEnableIcr"
      Me._chkEnableIcr.Size = New System.Drawing.Size(79, 17)
      Me._chkEnableIcr.TabIndex = 7
      Me._chkEnableIcr.Text = "Enable ICR"
      Me._chkEnableIcr.TextAlign = System.Drawing.ContentAlignment.TopLeft
      Me._chkEnableIcr.UseVisualStyleBackColor = True
      '
      '_chkEnableOcr
      '
      Me._chkEnableOcr.AutoSize = True
      Me._chkEnableOcr.Checked = True
      Me._chkEnableOcr.CheckState = System.Windows.Forms.CheckState.Checked
      Me._chkEnableOcr.Location = New System.Drawing.Point(10, 19)
      Me._chkEnableOcr.Name = "_chkEnableOcr"
      Me._chkEnableOcr.Size = New System.Drawing.Size(83, 17)
      Me._chkEnableOcr.TabIndex = 6
      Me._chkEnableOcr.Text = "Enable OCR"
      Me._chkEnableOcr.UseVisualStyleBackColor = True
      '
      '_gbFieldTextType
      '
      Me._gbFieldTextType.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbFieldTextType.Controls.Add(Me._rbtextTypeNum)
      Me._gbFieldTextType.Controls.Add(Me._rbTextTypeChar)
      Me._gbFieldTextType.Location = New System.Drawing.Point(6, 19)
      Me._gbFieldTextType.Name = "_gbFieldTextType"
      Me._gbFieldTextType.Size = New System.Drawing.Size(101, 75)
      Me._gbFieldTextType.TabIndex = 16
      Me._gbFieldTextType.TabStop = False
      Me._gbFieldTextType.Text = "Text Type"
      '
      '_rbtextTypeNum
      '
      Me._rbtextTypeNum.AutoSize = True
      Me._rbtextTypeNum.Location = New System.Drawing.Point(10, 45)
      Me._rbtextTypeNum.Name = "_rbtextTypeNum"
      Me._rbtextTypeNum.Size = New System.Drawing.Size(71, 17)
      Me._rbtextTypeNum.TabIndex = 9
      Me._rbtextTypeNum.Text = "Numerical"
      Me._rbtextTypeNum.UseVisualStyleBackColor = True
      '
      '_rbTextTypeChar
      '
      Me._rbTextTypeChar.AutoSize = True
      Me._rbTextTypeChar.Location = New System.Drawing.Point(10, 19)
      Me._rbTextTypeChar.Name = "_rbTextTypeChar"
      Me._rbTextTypeChar.Size = New System.Drawing.Size(73, 17)
      Me._rbTextTypeChar.TabIndex = 8
      Me._rbTextTypeChar.Text = "Character"
      Me._rbTextTypeChar.UseVisualStyleBackColor = True
      '
      '_gb_OcrColumnOption
      '
      Me._gb_OcrColumnOption.Controls.Add(Me._gbFieldTextType)
      Me._gb_OcrColumnOption.Controls.Add(Me._gbFieldMethod)
      Me._gb_OcrColumnOption.Location = New System.Drawing.Point(12, 52)
      Me._gb_OcrColumnOption.Name = "_gb_OcrColumnOption"
      Me._gb_OcrColumnOption.Size = New System.Drawing.Size(260, 100)
      Me._gb_OcrColumnOption.TabIndex = 17
      Me._gb_OcrColumnOption.TabStop = False
      Me._gb_OcrColumnOption.Text = "Ocr Options"
      '
      '_gbOMRFrame
      '
      Me._gbOMRFrame.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbOMRFrame.Controls.Add(Me._rbOMRWithoutFrame)
      Me._gbOMRFrame.Controls.Add(Me._rbOMRWithFrame)
      Me._gbOMRFrame.Controls.Add(Me._rbOMRAutoFrame)
      Me._gbOMRFrame.Location = New System.Drawing.Point(130, 38)
      Me._gbOMRFrame.Name = "_gbOMRFrame"
      Me._gbOMRFrame.Size = New System.Drawing.Size(113, 94)
      Me._gbOMRFrame.TabIndex = 18
      Me._gbOMRFrame.TabStop = False
      Me._gbOMRFrame.Text = "Frame"
      '
      '_rbOMRWithoutFrame
      '
      Me._rbOMRWithoutFrame.AutoSize = True
      Me._rbOMRWithoutFrame.Location = New System.Drawing.Point(10, 71)
      Me._rbOMRWithoutFrame.Name = "_rbOMRWithoutFrame"
      Me._rbOMRWithoutFrame.Size = New System.Drawing.Size(96, 17)
      Me._rbOMRWithoutFrame.TabIndex = 13
      Me._rbOMRWithoutFrame.TabStop = True
      Me._rbOMRWithoutFrame.Text = "Without Frame"
      Me._rbOMRWithoutFrame.UseVisualStyleBackColor = True
      '
      '_rbOMRWithFrame
      '
      Me._rbOMRWithFrame.AutoSize = True
      Me._rbOMRWithFrame.Location = New System.Drawing.Point(10, 45)
      Me._rbOMRWithFrame.Name = "_rbOMRWithFrame"
      Me._rbOMRWithFrame.Size = New System.Drawing.Size(80, 17)
      Me._rbOMRWithFrame.TabIndex = 12
      Me._rbOMRWithFrame.TabStop = True
      Me._rbOMRWithFrame.Text = "With Frame"
      Me._rbOMRWithFrame.UseVisualStyleBackColor = True
      '
      '_rbOMRAutoFrame
      '
      Me._rbOMRAutoFrame.AutoSize = True
      Me._rbOMRAutoFrame.Location = New System.Drawing.Point(10, 19)
      Me._rbOMRAutoFrame.Name = "_rbOMRAutoFrame"
      Me._rbOMRAutoFrame.Size = New System.Drawing.Size(48, 17)
      Me._rbOMRAutoFrame.TabIndex = 11
      Me._rbOMRAutoFrame.TabStop = True
      Me._rbOMRAutoFrame.Text = "Auto"
      Me._rbOMRAutoFrame.UseVisualStyleBackColor = True
      '
      '_gbOMRSensitivity
      '
      Me._gbOMRSensitivity.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbOMRSensitivity.Controls.Add(Me._rbOMRSensitivityHighest)
      Me._gbOMRSensitivity.Controls.Add(Me._rbOMRSensitivityHigh)
      Me._gbOMRSensitivity.Controls.Add(Me._rbOMRSensitivityLowest)
      Me._gbOMRSensitivity.Controls.Add(Me._rbOMRSensitivityLow)
      Me._gbOMRSensitivity.Location = New System.Drawing.Point(22, 38)
      Me._gbOMRSensitivity.Name = "_gbOMRSensitivity"
      Me._gbOMRSensitivity.Size = New System.Drawing.Size(101, 121)
      Me._gbOMRSensitivity.TabIndex = 19
      Me._gbOMRSensitivity.TabStop = False
      Me._gbOMRSensitivity.Text = "Sensitivity"
      '
      '_rbOMRSensitivityHighest
      '
      Me._rbOMRSensitivityHighest.AutoSize = True
      Me._rbOMRSensitivityHighest.Location = New System.Drawing.Point(10, 99)
      Me._rbOMRSensitivityHighest.Name = "_rbOMRSensitivityHighest"
      Me._rbOMRSensitivityHighest.Size = New System.Drawing.Size(61, 17)
      Me._rbOMRSensitivityHighest.TabIndex = 11
      Me._rbOMRSensitivityHighest.TabStop = True
      Me._rbOMRSensitivityHighest.Text = "Highest"
      Me._rbOMRSensitivityHighest.UseVisualStyleBackColor = True
      '
      '_rbOMRSensitivityHigh
      '
      Me._rbOMRSensitivityHigh.AutoSize = True
      Me._rbOMRSensitivityHigh.Location = New System.Drawing.Point(10, 71)
      Me._rbOMRSensitivityHigh.Name = "_rbOMRSensitivityHigh"
      Me._rbOMRSensitivityHigh.Size = New System.Drawing.Size(46, 17)
      Me._rbOMRSensitivityHigh.TabIndex = 10
      Me._rbOMRSensitivityHigh.TabStop = True
      Me._rbOMRSensitivityHigh.Text = "High"
      Me._rbOMRSensitivityHigh.UseVisualStyleBackColor = True
      '
      '_rbOMRSensitivityLowest
      '
      Me._rbOMRSensitivityLowest.AutoSize = True
      Me._rbOMRSensitivityLowest.Location = New System.Drawing.Point(10, 19)
      Me._rbOMRSensitivityLowest.Name = "_rbOMRSensitivityLowest"
      Me._rbOMRSensitivityLowest.Size = New System.Drawing.Size(59, 17)
      Me._rbOMRSensitivityLowest.TabIndex = 9
      Me._rbOMRSensitivityLowest.TabStop = True
      Me._rbOMRSensitivityLowest.Text = "Lowest"
      Me._rbOMRSensitivityLowest.UseVisualStyleBackColor = True
      '
      '_rbOMRSensitivityLow
      '
      Me._rbOMRSensitivityLow.AutoSize = True
      Me._rbOMRSensitivityLow.Location = New System.Drawing.Point(10, 45)
      Me._rbOMRSensitivityLow.Name = "_rbOMRSensitivityLow"
      Me._rbOMRSensitivityLow.Size = New System.Drawing.Size(44, 17)
      Me._rbOMRSensitivityLow.TabIndex = 8
      Me._rbOMRSensitivityLow.TabStop = True
      Me._rbOMRSensitivityLow.Text = "Low"
      Me._rbOMRSensitivityLow.UseVisualStyleBackColor = True
      '
      '_gb_OmrColumnOptions
      '
      Me._gb_OmrColumnOptions.Controls.Add(Me._gbOMRSensitivity)
      Me._gb_OmrColumnOptions.Controls.Add(Me._gbOMRFrame)
      Me._gb_OmrColumnOptions.Location = New System.Drawing.Point(12, 158)
      Me._gb_OmrColumnOptions.Name = "_gb_OmrColumnOptions"
      Me._gb_OmrColumnOptions.Size = New System.Drawing.Size(260, 165)
      Me._gb_OmrColumnOptions.TabIndex = 20
      Me._gb_OmrColumnOptions.TabStop = False
      Me._gb_OmrColumnOptions.Text = "Omr Options"
      '
      '_gbBounds
      '
      Me._gbBounds.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbBounds.Controls.Add(Me._nudHeight)
      Me._gbBounds.Controls.Add(Me._nudWidth)
      Me._gbBounds.Controls.Add(Me._nudTop)
      Me._gbBounds.Controls.Add(Me._nudLeft)
      Me._gbBounds.Controls.Add(Me._lblFieldHeight)
      Me._gbBounds.Controls.Add(Me._lblFieldWidth)
      Me._gbBounds.Controls.Add(Me._lblFieldTop)
      Me._gbBounds.Controls.Add(Me._lblFieldLeft)
      Me._gbBounds.Location = New System.Drawing.Point(12, 435)
      Me._gbBounds.Name = "_gbBounds"
      Me._gbBounds.Size = New System.Drawing.Size(237, 66)
      Me._gbBounds.TabIndex = 21
      Me._gbBounds.TabStop = False
      Me._gbBounds.Text = "Bounds"
      '
      '_nudHeight
      '
      Me._nudHeight.Location = New System.Drawing.Point(170, 39)
      Me._nudHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
      Me._nudHeight.Name = "_nudHeight"
      Me._nudHeight.Size = New System.Drawing.Size(60, 20)
      Me._nudHeight.TabIndex = 16
      '
      '_nudWidth
      '
      Me._nudWidth.Location = New System.Drawing.Point(170, 14)
      Me._nudWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
      Me._nudWidth.Name = "_nudWidth"
      Me._nudWidth.Size = New System.Drawing.Size(60, 20)
      Me._nudWidth.TabIndex = 15
      '
      '_nudTop
      '
      Me._nudTop.Location = New System.Drawing.Point(47, 39)
      Me._nudTop.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
      Me._nudTop.Name = "_nudTop"
      Me._nudTop.Size = New System.Drawing.Size(60, 20)
      Me._nudTop.TabIndex = 14
      '
      '_nudLeft
      '
      Me._nudLeft.Location = New System.Drawing.Point(47, 14)
      Me._nudLeft.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
      Me._nudLeft.Name = "_nudLeft"
      Me._nudLeft.Size = New System.Drawing.Size(60, 20)
      Me._nudLeft.TabIndex = 13
      '
      '_lblFieldHeight
      '
      Me._lblFieldHeight.AutoSize = True
      Me._lblFieldHeight.Location = New System.Drawing.Point(129, 41)
      Me._lblFieldHeight.Name = "_lblFieldHeight"
      Me._lblFieldHeight.Size = New System.Drawing.Size(38, 13)
      Me._lblFieldHeight.TabIndex = 12
      Me._lblFieldHeight.Text = "Height"
      '
      '_lblFieldWidth
      '
      Me._lblFieldWidth.AutoSize = True
      Me._lblFieldWidth.Location = New System.Drawing.Point(129, 16)
      Me._lblFieldWidth.Name = "_lblFieldWidth"
      Me._lblFieldWidth.Size = New System.Drawing.Size(35, 13)
      Me._lblFieldWidth.TabIndex = 10
      Me._lblFieldWidth.Text = "Width"
      '
      '_lblFieldTop
      '
      Me._lblFieldTop.AutoSize = True
      Me._lblFieldTop.Location = New System.Drawing.Point(7, 41)
      Me._lblFieldTop.Name = "_lblFieldTop"
      Me._lblFieldTop.Size = New System.Drawing.Size(25, 13)
      Me._lblFieldTop.TabIndex = 8
      Me._lblFieldTop.Text = "Top"
      '
      '_lblFieldLeft
      '
      Me._lblFieldLeft.AutoSize = True
      Me._lblFieldLeft.Location = New System.Drawing.Point(7, 16)
      Me._lblFieldLeft.Name = "_lblFieldLeft"
      Me._lblFieldLeft.Size = New System.Drawing.Size(26, 13)
      Me._lblFieldLeft.TabIndex = 7
      Me._lblFieldLeft.Text = "Left"
      '
      'label1
      '
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(13, 13)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(44, 13)
      Me.label1.TabIndex = 22
      Me.label1.Text = "Name : "
      '
      '_txt_ColumnOptionsFieldName
      '
      Me._txt_ColumnOptionsFieldName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._txt_ColumnOptionsFieldName.Location = New System.Drawing.Point(56, 13)
      Me._txt_ColumnOptionsFieldName.Name = "_txt_ColumnOptionsFieldName"
      Me._txt_ColumnOptionsFieldName.Size = New System.Drawing.Size(199, 20)
      Me._txt_ColumnOptionsFieldName.TabIndex = 23
      '
      '_gbKeyColumn
      '
      Me._gbKeyColumn.Controls.Add(Me._cbIsKeyColumn)
      Me._gbKeyColumn.Location = New System.Drawing.Point(12, 386)
      Me._gbKeyColumn.Name = "_gbKeyColumn"
      Me._gbKeyColumn.Size = New System.Drawing.Size(260, 43)
      Me._gbKeyColumn.TabIndex = 24
      Me._gbKeyColumn.TabStop = False
      Me._gbKeyColumn.Text = "Key Column"
      '
      '_cbIsKeyColumn
      '
      Me._cbIsKeyColumn.AutoSize = True
      Me._cbIsKeyColumn.Location = New System.Drawing.Point(7, 20)
      Me._cbIsKeyColumn.Name = "_cbIsKeyColumn"
      Me._cbIsKeyColumn.Size = New System.Drawing.Size(82, 17)
      Me._cbIsKeyColumn.TabIndex = 0
      Me._cbIsKeyColumn.Text = "Key Column"
      Me._cbIsKeyColumn.UseVisualStyleBackColor = True
      '
      '_gbDropoutOptions
      '
      Me._gbDropoutOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._gbDropoutOptions.Controls.Add(Me._chkDropoutCells)
      Me._gbDropoutOptions.Controls.Add(Me._chkDropoutWords)
      Me._gbDropoutOptions.Location = New System.Drawing.Point(12, 329)
      Me._gbDropoutOptions.Name = "_gbDropoutOptions"
      Me._gbDropoutOptions.Size = New System.Drawing.Size(260, 51)
      Me._gbDropoutOptions.TabIndex = 25
      Me._gbDropoutOptions.TabStop = False
      Me._gbDropoutOptions.Text = "Dropout"
      '
      '_chkDropoutCells
      '
      Me._chkDropoutCells.AutoSize = True
      Me._chkDropoutCells.Location = New System.Drawing.Point(102, 19)
      Me._chkDropoutCells.Name = "_chkDropoutCells"
      Me._chkDropoutCells.Size = New System.Drawing.Size(88, 17)
      Me._chkDropoutCells.TabIndex = 8
      Me._chkDropoutCells.Text = "Cells Borders"
      Me._chkDropoutCells.UseVisualStyleBackColor = True
      '
      '_chkDropoutWords
      '
      Me._chkDropoutWords.AutoSize = True
      Me._chkDropoutWords.Location = New System.Drawing.Point(10, 19)
      Me._chkDropoutWords.Name = "_chkDropoutWords"
      Me._chkDropoutWords.Size = New System.Drawing.Size(57, 17)
      Me._chkDropoutWords.TabIndex = 7
      Me._chkDropoutWords.Text = "Words"
      Me._chkDropoutWords.UseVisualStyleBackColor = True
      '
      '_btnOK
      '
      Me._btnOK.Location = New System.Drawing.Point(77, 507)
      Me._btnOK.Name = "_btnOK"
      Me._btnOK.Size = New System.Drawing.Size(132, 33)
      Me._btnOK.TabIndex = 26
      Me._btnOK.Text = "OK"
      Me._btnOK.UseVisualStyleBackColor = True
      '
      'ColumnOptions
      '
      Me.AcceptButton = Me._btnOK
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(284, 547)
      Me.Controls.Add(Me._btnOK)
      Me.Controls.Add(Me._gbDropoutOptions)
      Me.Controls.Add(Me._gbKeyColumn)
      Me.Controls.Add(Me._txt_ColumnOptionsFieldName)
      Me.Controls.Add(Me.label1)
      Me.Controls.Add(Me._gbBounds)
      Me.Controls.Add(Me._gb_OmrColumnOptions)
      Me.Controls.Add(Me._gb_OcrColumnOption)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ColumnOptions"
      Me.Text = "Column Options"
      Me._gbFieldMethod.ResumeLayout(False)
      Me._gbFieldMethod.PerformLayout()
      Me._gbFieldTextType.ResumeLayout(False)
      Me._gbFieldTextType.PerformLayout()
      Me._gb_OcrColumnOption.ResumeLayout(False)
      Me._gbOMRFrame.ResumeLayout(False)
      Me._gbOMRFrame.PerformLayout()
      Me._gbOMRSensitivity.ResumeLayout(False)
      Me._gbOMRSensitivity.PerformLayout()
      Me._gb_OmrColumnOptions.ResumeLayout(False)
      Me._gbBounds.ResumeLayout(False)
      Me._gbBounds.PerformLayout()
      CType(Me._nudHeight, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._nudWidth, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._nudTop, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._nudLeft, System.ComponentModel.ISupportInitialize).EndInit()
      Me._gbKeyColumn.ResumeLayout(False)
      Me._gbKeyColumn.PerformLayout()
      Me._gbDropoutOptions.ResumeLayout(False)
      Me._gbDropoutOptions.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _gbFieldMethod As System.Windows.Forms.GroupBox
   Private WithEvents _chkEnableIcr As System.Windows.Forms.CheckBox
   Private WithEvents _chkEnableOcr As System.Windows.Forms.CheckBox
   Private _gbFieldTextType As System.Windows.Forms.GroupBox
   Private WithEvents _rbtextTypeNum As System.Windows.Forms.RadioButton
   Private WithEvents _rbTextTypeChar As System.Windows.Forms.RadioButton
   Private _gb_OcrColumnOption As System.Windows.Forms.GroupBox
   Private _gbOMRFrame As System.Windows.Forms.GroupBox
   Private WithEvents _rbOMRWithoutFrame As System.Windows.Forms.RadioButton
   Private WithEvents _rbOMRWithFrame As System.Windows.Forms.RadioButton
   Private WithEvents _rbOMRAutoFrame As System.Windows.Forms.RadioButton
   Private _gbOMRSensitivity As System.Windows.Forms.GroupBox
   Private WithEvents _rbOMRSensitivityHighest As System.Windows.Forms.RadioButton
   Private WithEvents _rbOMRSensitivityHigh As System.Windows.Forms.RadioButton
   Private WithEvents _rbOMRSensitivityLowest As System.Windows.Forms.RadioButton
   Private WithEvents _rbOMRSensitivityLow As System.Windows.Forms.RadioButton
   Private _gb_OmrColumnOptions As System.Windows.Forms.GroupBox
   Private _gbBounds As System.Windows.Forms.GroupBox
   Private _lblFieldHeight As System.Windows.Forms.Label
   Private _lblFieldWidth As System.Windows.Forms.Label
   Private _lblFieldTop As System.Windows.Forms.Label
   Private _lblFieldLeft As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private WithEvents _txt_ColumnOptionsFieldName As System.Windows.Forms.TextBox
   Private WithEvents _nudHeight As System.Windows.Forms.NumericUpDown
   Private WithEvents _nudWidth As System.Windows.Forms.NumericUpDown
   Private WithEvents _nudTop As System.Windows.Forms.NumericUpDown
   Private WithEvents _nudLeft As System.Windows.Forms.NumericUpDown
   Private _gbKeyColumn As System.Windows.Forms.GroupBox
   Private WithEvents _cbIsKeyColumn As System.Windows.Forms.CheckBox
   Private _gbDropoutOptions As System.Windows.Forms.GroupBox
   Private _chkDropoutWords As System.Windows.Forms.CheckBox
   Private _chkDropoutCells As System.Windows.Forms.CheckBox
   Friend WithEvents _btnOK As System.Windows.Forms.Button
End Class
