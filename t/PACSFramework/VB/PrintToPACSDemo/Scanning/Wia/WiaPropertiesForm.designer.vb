Imports Microsoft.VisualBasic
Imports System
Namespace PrintToPACSDemo
   Public Partial Class WiaPropertiesForm
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
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me._numMaxPagesCount = New System.Windows.Forms.NumericUpDown()
		 Me._lblMaxPagesCount = New System.Windows.Forms.Label()
		 Me._gbTransferMode = New System.Windows.Forms.GroupBox()
		 Me._rdFileMode = New System.Windows.Forms.RadioButton()
		 Me._rdMemoryMode = New System.Windows.Forms.RadioButton()
		 Me._cmbCompression = New System.Windows.Forms.ComboBox()
		 Me._lblCompression = New System.Windows.Forms.Label()
		 Me._cmbImageDataType = New System.Windows.Forms.ComboBox()
		 Me._lblImageDataType = New System.Windows.Forms.Label()
		 Me._cmbFormat = New System.Windows.Forms.ComboBox()
		 Me._lblFormat = New System.Windows.Forms.Label()
		 Me.groupBox2 = New System.Windows.Forms.GroupBox()
		 Me._cmbOrientation = New System.Windows.Forms.ComboBox()
		 Me._lblOrientation = New System.Windows.Forms.Label()
		 Me.groupBox3 = New System.Windows.Forms.GroupBox()
		 Me._cbAutoAdvance = New System.Windows.Forms.CheckBox()
		 Me._cbPrefeed = New System.Windows.Forms.CheckBox()
		 Me._cbNextPage = New System.Windows.Forms.CheckBox()
		 Me._cbBackFirst = New System.Windows.Forms.CheckBox()
		 Me._cbFrontFirst = New System.Windows.Forms.CheckBox()
		 Me._cbBackOnly = New System.Windows.Forms.CheckBox()
		 Me._cbFrontOnly = New System.Windows.Forms.CheckBox()
		 Me._cbDuplex = New System.Windows.Forms.CheckBox()
		 Me._cbFlatbed = New System.Windows.Forms.CheckBox()
		 Me._cbFeeder = New System.Windows.Forms.CheckBox()
		 Me.groupBox4 = New System.Windows.Forms.GroupBox()
		 Me._cbColored = New System.Windows.Forms.CheckBox()
		 Me._cbGrayscale = New System.Windows.Forms.CheckBox()
		 Me._cbText = New System.Windows.Forms.CheckBox()
		 Me._gbImageResolutionProperties = New System.Windows.Forms.GroupBox()
		 Me._cmbVerticalResolution = New System.Windows.Forms.ComboBox()
		 Me._cmbHorizontalResolution = New System.Windows.Forms.ComboBox()
		 Me._numHeight = New System.Windows.Forms.NumericUpDown()
		 Me._numWidth = New System.Windows.Forms.NumericUpDown()
		 Me._numYPos = New System.Windows.Forms.NumericUpDown()
		 Me._numXPos = New System.Windows.Forms.NumericUpDown()
		 Me._numVerticalResolution = New System.Windows.Forms.NumericUpDown()
		 Me._numVerticalScaling = New System.Windows.Forms.NumericUpDown()
		 Me._numHorizontalResolution = New System.Windows.Forms.NumericUpDown()
		 Me._numHorizontalScaling = New System.Windows.Forms.NumericUpDown()
		 Me._lblHeight = New System.Windows.Forms.Label()
		 Me._lblWidth = New System.Windows.Forms.Label()
		 Me._lblYPos = New System.Windows.Forms.Label()
		 Me._lblXPos = New System.Windows.Forms.Label()
		 Me._lblVerticalScaling = New System.Windows.Forms.Label()
		 Me._lblHorizontalScaling = New System.Windows.Forms.Label()
		 Me._lblVerticalResolution = New System.Windows.Forms.Label()
		 Me._lblHorizontalResolution = New System.Windows.Forms.Label()
		 Me._cmbRotationAngle = New System.Windows.Forms.ComboBox()
		 Me._lblRotationAngle = New System.Windows.Forms.Label()
		 Me._cmbBitsPerPixel = New System.Windows.Forms.ComboBox()
		 Me._lblBitsPerPixel = New System.Windows.Forms.Label()
		 Me._gbImageEffectsProperties = New System.Windows.Forms.GroupBox()
		 Me._numContrast = New System.Windows.Forms.NumericUpDown()
		 Me._numBrightness = New System.Windows.Forms.NumericUpDown()
		 Me._lblContrast = New System.Windows.Forms.Label()
		 Me._lblBrightness = New System.Windows.Forms.Label()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOk = New System.Windows.Forms.Button()
		 Me.groupBox1.SuspendLayout()
		 CType(Me._numMaxPagesCount, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me._gbTransferMode.SuspendLayout()
		 Me.groupBox2.SuspendLayout()
		 Me.groupBox3.SuspendLayout()
		 Me.groupBox4.SuspendLayout()
		 Me._gbImageResolutionProperties.SuspendLayout()
		 CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numYPos, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numXPos, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numVerticalResolution, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numVerticalScaling, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numHorizontalResolution, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numHorizontalScaling, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me._gbImageEffectsProperties.SuspendLayout()
		 CType(Me._numContrast, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._numBrightness, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me.SuspendLayout()
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me._numMaxPagesCount)
		 Me.groupBox1.Controls.Add(Me._lblMaxPagesCount)
		 Me.groupBox1.Controls.Add(Me._gbTransferMode)
		 Me.groupBox1.Controls.Add(Me._cmbCompression)
		 Me.groupBox1.Controls.Add(Me._lblCompression)
		 Me.groupBox1.Controls.Add(Me._cmbImageDataType)
		 Me.groupBox1.Controls.Add(Me._lblImageDataType)
		 Me.groupBox1.Controls.Add(Me._cmbFormat)
		 Me.groupBox1.Controls.Add(Me._lblFormat)
		 Me.groupBox1.Location = New System.Drawing.Point(313, 12)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(295, 239)
		 Me.groupBox1.TabIndex = 1
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "Scanner Properties"
		 ' 
		 ' _numMaxPagesCount
		 ' 
		 Me._numMaxPagesCount.Enabled = False
		 Me._numMaxPagesCount.Location = New System.Drawing.Point(189, 175)
		 Me._numMaxPagesCount.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
		 Me._numMaxPagesCount.Name = "_numMaxPagesCount"
		 Me._numMaxPagesCount.Size = New System.Drawing.Size(100, 20)
		 Me._numMaxPagesCount.TabIndex = 29
'		 Me._numMaxPagesCount.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblMaxPagesCount
		 ' 
		 Me._lblMaxPagesCount.AutoSize = True
		 Me._lblMaxPagesCount.Location = New System.Drawing.Point(6, 178)
		 Me._lblMaxPagesCount.Name = "_lblMaxPagesCount"
		 Me._lblMaxPagesCount.Size = New System.Drawing.Size(115, 13)
		 Me._lblMaxPagesCount.TabIndex = 27
		 Me._lblMaxPagesCount.Text = "Maximum Pages Count"
		 ' 
		 ' _gbTransferMode
		 ' 
		 Me._gbTransferMode.Controls.Add(Me._rdFileMode)
		 Me._gbTransferMode.Controls.Add(Me._rdMemoryMode)
		 Me._gbTransferMode.Location = New System.Drawing.Point(6, 103)
		 Me._gbTransferMode.Name = "_gbTransferMode"
		 Me._gbTransferMode.Size = New System.Drawing.Size(283, 60)
		 Me._gbTransferMode.TabIndex = 26
		 Me._gbTransferMode.TabStop = False
		 Me._gbTransferMode.Text = "Transfer Mode"
		 ' 
		 ' _rdFileMode
		 ' 
		 Me._rdFileMode.AutoSize = True
		 Me._rdFileMode.Enabled = False
		 Me._rdFileMode.Location = New System.Drawing.Point(129, 23)
		 Me._rdFileMode.Name = "_rdFileMode"
		 Me._rdFileMode.Size = New System.Drawing.Size(71, 17)
		 Me._rdFileMode.TabIndex = 28
		 Me._rdFileMode.TabStop = True
		 Me._rdFileMode.Text = "File Mode"
		 Me._rdFileMode.UseVisualStyleBackColor = True
'		 Me._rdFileMode.Click += New System.EventHandler(Me._rdFileMode_Click);
		 ' 
		 ' _rdMemoryMode
		 ' 
		 Me._rdMemoryMode.AutoSize = True
		 Me._rdMemoryMode.Enabled = False
		 Me._rdMemoryMode.Location = New System.Drawing.Point(6, 23)
		 Me._rdMemoryMode.Name = "_rdMemoryMode"
		 Me._rdMemoryMode.Size = New System.Drawing.Size(92, 17)
		 Me._rdMemoryMode.TabIndex = 27
		 Me._rdMemoryMode.TabStop = True
		 Me._rdMemoryMode.Text = "Memory Mode"
		 Me._rdMemoryMode.UseVisualStyleBackColor = True
'		 Me._rdMemoryMode.Click += New System.EventHandler(Me._rdMemoryMode_Click);
		 ' 
		 ' _cmbCompression
		 ' 
		 Me._cmbCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbCompression.Enabled = False
		 Me._cmbCompression.FormattingEnabled = True
		 Me._cmbCompression.Location = New System.Drawing.Point(135, 49)
		 Me._cmbCompression.Name = "_cmbCompression"
		 Me._cmbCompression.Size = New System.Drawing.Size(154, 21)
		 Me._cmbCompression.TabIndex = 25
		 ' 
		 ' _lblCompression
		 ' 
		 Me._lblCompression.AutoSize = True
		 Me._lblCompression.Location = New System.Drawing.Point(6, 52)
		 Me._lblCompression.Name = "_lblCompression"
		 Me._lblCompression.Size = New System.Drawing.Size(67, 13)
		 Me._lblCompression.TabIndex = 24
		 Me._lblCompression.Text = "Compression"
		 ' 
		 ' _cmbImageDataType
		 ' 
		 Me._cmbImageDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbImageDataType.Enabled = False
		 Me._cmbImageDataType.FormattingEnabled = True
		 Me._cmbImageDataType.Location = New System.Drawing.Point(135, 76)
		 Me._cmbImageDataType.Name = "_cmbImageDataType"
		 Me._cmbImageDataType.Size = New System.Drawing.Size(154, 21)
		 Me._cmbImageDataType.TabIndex = 26
		 ' 
		 ' _lblImageDataType
		 ' 
		 Me._lblImageDataType.AutoSize = True
		 Me._lblImageDataType.Location = New System.Drawing.Point(6, 79)
		 Me._lblImageDataType.Name = "_lblImageDataType"
		 Me._lblImageDataType.Size = New System.Drawing.Size(89, 13)
		 Me._lblImageDataType.TabIndex = 22
		 Me._lblImageDataType.Text = "Image Data Type"
		 ' 
		 ' _cmbFormat
		 ' 
		 Me._cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbFormat.Enabled = False
		 Me._cmbFormat.FormattingEnabled = True
		 Me._cmbFormat.Location = New System.Drawing.Point(135, 22)
		 Me._cmbFormat.Name = "_cmbFormat"
		 Me._cmbFormat.Size = New System.Drawing.Size(154, 21)
		 Me._cmbFormat.TabIndex = 24
		 ' 
		 ' _lblFormat
		 ' 
		 Me._lblFormat.AutoSize = True
		 Me._lblFormat.Location = New System.Drawing.Point(6, 25)
		 Me._lblFormat.Name = "_lblFormat"
		 Me._lblFormat.Size = New System.Drawing.Size(39, 13)
		 Me._lblFormat.TabIndex = 20
		 Me._lblFormat.Text = "Format"
		 ' 
		 ' groupBox2
		 ' 
		 Me.groupBox2.Controls.Add(Me._cmbOrientation)
		 Me.groupBox2.Controls.Add(Me._lblOrientation)
		 Me.groupBox2.Controls.Add(Me.groupBox3)
		 Me.groupBox2.Controls.Add(Me.groupBox4)
		 Me.groupBox2.Location = New System.Drawing.Point(12, 12)
		 Me.groupBox2.Name = "groupBox2"
		 Me.groupBox2.Size = New System.Drawing.Size(295, 239)
		 Me.groupBox2.TabIndex = 0
		 Me.groupBox2.TabStop = False
		 Me.groupBox2.Text = "Scanner Properties"
		 ' 
		 ' _cmbOrientation
		 ' 
		 Me._cmbOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbOrientation.Enabled = False
		 Me._cmbOrientation.FormattingEnabled = True
		 Me._cmbOrientation.Location = New System.Drawing.Point(135, 205)
		 Me._cmbOrientation.Name = "_cmbOrientation"
		 Me._cmbOrientation.Size = New System.Drawing.Size(154, 21)
		 Me._cmbOrientation.TabIndex = 13
		 ' 
		 ' _lblOrientation
		 ' 
		 Me._lblOrientation.AutoSize = True
		 Me._lblOrientation.Location = New System.Drawing.Point(6, 208)
		 Me._lblOrientation.Name = "_lblOrientation"
		 Me._lblOrientation.Size = New System.Drawing.Size(58, 13)
		 Me._lblOrientation.TabIndex = 2
		 Me._lblOrientation.Text = "Orientation"
		 ' 
		 ' groupBox3
		 ' 
		 Me.groupBox3.Controls.Add(Me._cbAutoAdvance)
		 Me.groupBox3.Controls.Add(Me._cbPrefeed)
		 Me.groupBox3.Controls.Add(Me._cbNextPage)
		 Me.groupBox3.Controls.Add(Me._cbBackFirst)
		 Me.groupBox3.Controls.Add(Me._cbFrontFirst)
		 Me.groupBox3.Controls.Add(Me._cbBackOnly)
		 Me.groupBox3.Controls.Add(Me._cbFrontOnly)
		 Me.groupBox3.Controls.Add(Me._cbDuplex)
		 Me.groupBox3.Controls.Add(Me._cbFlatbed)
		 Me.groupBox3.Controls.Add(Me._cbFeeder)
		 Me.groupBox3.Location = New System.Drawing.Point(6, 78)
		 Me.groupBox3.Name = "groupBox3"
		 Me.groupBox3.Size = New System.Drawing.Size(283, 121)
		 Me.groupBox3.TabIndex = 1
		 Me.groupBox3.TabStop = False
		 Me.groupBox3.Text = "Paper Source and Duplex Modes"
		 ' 
		 ' _cbAutoAdvance
		 ' 
		 Me._cbAutoAdvance.AutoSize = True
		 Me._cbAutoAdvance.Enabled = False
		 Me._cbAutoAdvance.Location = New System.Drawing.Point(6, 92)
		 Me._cbAutoAdvance.Name = "_cbAutoAdvance"
		 Me._cbAutoAdvance.Size = New System.Drawing.Size(94, 17)
		 Me._cbAutoAdvance.TabIndex = 12
		 Me._cbAutoAdvance.Text = "Auto Advance"
		 Me._cbAutoAdvance.UseVisualStyleBackColor = True
'		 Me._cbAutoAdvance.Click += New System.EventHandler(Me._cbAutoAdvance_Click);
		 ' 
		 ' _cbPrefeed
		 ' 
		 Me._cbPrefeed.AutoSize = True
		 Me._cbPrefeed.Enabled = False
		 Me._cbPrefeed.Location = New System.Drawing.Point(206, 69)
		 Me._cbPrefeed.Name = "_cbPrefeed"
		 Me._cbPrefeed.Size = New System.Drawing.Size(66, 17)
		 Me._cbPrefeed.TabIndex = 11
		 Me._cbPrefeed.Text = "Pre-feed"
		 Me._cbPrefeed.UseVisualStyleBackColor = True
		 ' 
		 ' _cbNextPage
		 ' 
		 Me._cbNextPage.AutoSize = True
		 Me._cbNextPage.Enabled = False
		 Me._cbNextPage.Location = New System.Drawing.Point(106, 69)
		 Me._cbNextPage.Name = "_cbNextPage"
		 Me._cbNextPage.Size = New System.Drawing.Size(76, 17)
		 Me._cbNextPage.TabIndex = 10
		 Me._cbNextPage.Text = "Next Page"
		 Me._cbNextPage.UseVisualStyleBackColor = True
		 ' 
		 ' _cbBackFirst
		 ' 
		 Me._cbBackFirst.AutoSize = True
		 Me._cbBackFirst.Enabled = False
		 Me._cbBackFirst.Location = New System.Drawing.Point(6, 69)
		 Me._cbBackFirst.Name = "_cbBackFirst"
		 Me._cbBackFirst.Size = New System.Drawing.Size(73, 17)
		 Me._cbBackFirst.TabIndex = 9
		 Me._cbBackFirst.Text = "Back First"
		 Me._cbBackFirst.UseVisualStyleBackColor = True
		 ' 
		 ' _cbFrontFirst
		 ' 
		 Me._cbFrontFirst.AutoSize = True
		 Me._cbFrontFirst.Enabled = False
		 Me._cbFrontFirst.Location = New System.Drawing.Point(206, 46)
		 Me._cbFrontFirst.Name = "_cbFrontFirst"
		 Me._cbFrontFirst.Size = New System.Drawing.Size(72, 17)
		 Me._cbFrontFirst.TabIndex = 8
		 Me._cbFrontFirst.Text = "Front First"
		 Me._cbFrontFirst.UseVisualStyleBackColor = True
		 ' 
		 ' _cbBackOnly
		 ' 
		 Me._cbBackOnly.AutoSize = True
		 Me._cbBackOnly.Enabled = False
		 Me._cbBackOnly.Location = New System.Drawing.Point(106, 46)
		 Me._cbBackOnly.Name = "_cbBackOnly"
		 Me._cbBackOnly.Size = New System.Drawing.Size(75, 17)
		 Me._cbBackOnly.TabIndex = 7
		 Me._cbBackOnly.Text = "Back Only"
		 Me._cbBackOnly.UseVisualStyleBackColor = True
		 ' 
		 ' _cbFrontOnly
		 ' 
		 Me._cbFrontOnly.AutoSize = True
		 Me._cbFrontOnly.Enabled = False
		 Me._cbFrontOnly.Location = New System.Drawing.Point(6, 46)
		 Me._cbFrontOnly.Name = "_cbFrontOnly"
		 Me._cbFrontOnly.Size = New System.Drawing.Size(74, 17)
		 Me._cbFrontOnly.TabIndex = 6
		 Me._cbFrontOnly.Text = "Front Only"
		 Me._cbFrontOnly.UseVisualStyleBackColor = True
		 ' 
		 ' _cbDuplex
		 ' 
		 Me._cbDuplex.AutoSize = True
		 Me._cbDuplex.Enabled = False
		 Me._cbDuplex.Location = New System.Drawing.Point(206, 23)
		 Me._cbDuplex.Name = "_cbDuplex"
		 Me._cbDuplex.Size = New System.Drawing.Size(59, 17)
		 Me._cbDuplex.TabIndex = 5
		 Me._cbDuplex.Text = "Duplex"
		 Me._cbDuplex.UseVisualStyleBackColor = True
'		 Me._cbDuplex.Click += New System.EventHandler(Me._cbDuplex_Click);
		 ' 
		 ' _cbFlatbed
		 ' 
		 Me._cbFlatbed.AutoSize = True
		 Me._cbFlatbed.Enabled = False
		 Me._cbFlatbed.Location = New System.Drawing.Point(106, 23)
		 Me._cbFlatbed.Name = "_cbFlatbed"
		 Me._cbFlatbed.Size = New System.Drawing.Size(61, 17)
		 Me._cbFlatbed.TabIndex = 4
		 Me._cbFlatbed.Text = "Flatbed"
		 Me._cbFlatbed.UseVisualStyleBackColor = True
		 ' 
		 ' _cbFeeder
		 ' 
		 Me._cbFeeder.AutoSize = True
		 Me._cbFeeder.Enabled = False
		 Me._cbFeeder.Location = New System.Drawing.Point(6, 23)
		 Me._cbFeeder.Name = "_cbFeeder"
		 Me._cbFeeder.Size = New System.Drawing.Size(59, 17)
		 Me._cbFeeder.TabIndex = 3
		 Me._cbFeeder.Text = "Feeder"
		 Me._cbFeeder.UseVisualStyleBackColor = True
		 ' 
		 ' groupBox4
		 ' 
		 Me.groupBox4.Controls.Add(Me._cbColored)
		 Me.groupBox4.Controls.Add(Me._cbGrayscale)
		 Me.groupBox4.Controls.Add(Me._cbText)
		 Me.groupBox4.Location = New System.Drawing.Point(6, 19)
		 Me.groupBox4.Name = "groupBox4"
		 Me.groupBox4.Size = New System.Drawing.Size(283, 53)
		 Me.groupBox4.TabIndex = 0
		 Me.groupBox4.TabStop = False
		 Me.groupBox4.Text = "Image Type"
		 ' 
		 ' _cbColored
		 ' 
		 Me._cbColored.AutoSize = True
		 Me._cbColored.Enabled = False
		 Me._cbColored.Location = New System.Drawing.Point(6, 23)
		 Me._cbColored.Name = "_cbColored"
		 Me._cbColored.Size = New System.Drawing.Size(62, 17)
		 Me._cbColored.TabIndex = 0
		 Me._cbColored.Text = "Colored"
		 Me._cbColored.UseVisualStyleBackColor = True
'		 Me._cbColored.Click += New System.EventHandler(Me._cbColored_Click);
		 ' 
		 ' _cbGrayscale
		 ' 
		 Me._cbGrayscale.AutoSize = True
		 Me._cbGrayscale.Enabled = False
		 Me._cbGrayscale.Location = New System.Drawing.Point(106, 23)
		 Me._cbGrayscale.Name = "_cbGrayscale"
		 Me._cbGrayscale.Size = New System.Drawing.Size(73, 17)
		 Me._cbGrayscale.TabIndex = 1
		 Me._cbGrayscale.Text = "Grayscale"
		 Me._cbGrayscale.UseVisualStyleBackColor = True
'		 Me._cbGrayscale.Click += New System.EventHandler(Me._cbGrayscale_Click);
		 ' 
		 ' _cbText
		 ' 
		 Me._cbText.AutoSize = True
		 Me._cbText.Enabled = False
		 Me._cbText.Location = New System.Drawing.Point(206, 23)
		 Me._cbText.Name = "_cbText"
		 Me._cbText.Size = New System.Drawing.Size(47, 17)
		 Me._cbText.TabIndex = 2
		 Me._cbText.Text = "Text"
		 Me._cbText.UseVisualStyleBackColor = True
'		 Me._cbText.Click += New System.EventHandler(Me._cbText_Click);
		 ' 
		 ' _gbImageResolutionProperties
		 ' 
		 Me._gbImageResolutionProperties.Controls.Add(Me._cmbVerticalResolution)
		 Me._gbImageResolutionProperties.Controls.Add(Me._cmbHorizontalResolution)
		 Me._gbImageResolutionProperties.Controls.Add(Me._numHeight)
		 Me._gbImageResolutionProperties.Controls.Add(Me._numWidth)
		 Me._gbImageResolutionProperties.Controls.Add(Me._numYPos)
		 Me._gbImageResolutionProperties.Controls.Add(Me._numXPos)
		 Me._gbImageResolutionProperties.Controls.Add(Me._numVerticalResolution)
		 Me._gbImageResolutionProperties.Controls.Add(Me._numVerticalScaling)
		 Me._gbImageResolutionProperties.Controls.Add(Me._numHorizontalResolution)
		 Me._gbImageResolutionProperties.Controls.Add(Me._numHorizontalScaling)
		 Me._gbImageResolutionProperties.Controls.Add(Me._lblHeight)
		 Me._gbImageResolutionProperties.Controls.Add(Me._lblWidth)
		 Me._gbImageResolutionProperties.Controls.Add(Me._lblYPos)
		 Me._gbImageResolutionProperties.Controls.Add(Me._lblXPos)
		 Me._gbImageResolutionProperties.Controls.Add(Me._lblVerticalScaling)
		 Me._gbImageResolutionProperties.Controls.Add(Me._lblHorizontalScaling)
		 Me._gbImageResolutionProperties.Controls.Add(Me._lblVerticalResolution)
		 Me._gbImageResolutionProperties.Controls.Add(Me._lblHorizontalResolution)
		 Me._gbImageResolutionProperties.Controls.Add(Me._cmbRotationAngle)
		 Me._gbImageResolutionProperties.Controls.Add(Me._lblRotationAngle)
		 Me._gbImageResolutionProperties.Controls.Add(Me._cmbBitsPerPixel)
		 Me._gbImageResolutionProperties.Controls.Add(Me._lblBitsPerPixel)
		 Me._gbImageResolutionProperties.Location = New System.Drawing.Point(12, 257)
		 Me._gbImageResolutionProperties.Name = "_gbImageResolutionProperties"
		 Me._gbImageResolutionProperties.Size = New System.Drawing.Size(295, 294)
		 Me._gbImageResolutionProperties.TabIndex = 2
		 Me._gbImageResolutionProperties.TabStop = False
		 Me._gbImageResolutionProperties.Text = "Image Resolution Properties"
		 ' 
		 ' _cmbVerticalResolution
		 ' 
		 Me._cmbVerticalResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbVerticalResolution.FormattingEnabled = True
		 Me._cmbVerticalResolution.Location = New System.Drawing.Point(135, 105)
		 Me._cmbVerticalResolution.Name = "_cmbVerticalResolution"
		 Me._cmbVerticalResolution.Size = New System.Drawing.Size(154, 21)
		 Me._cmbVerticalResolution.TabIndex = 17
		 Me._cmbVerticalResolution.Visible = False
'		 Me._cmbVerticalResolution.SelectedIndexChanged += New System.EventHandler(Me._cmbVerticalResolution_SelectedIndexChanged);
		 ' 
		 ' _cmbHorizontalResolution
		 ' 
		 Me._cmbHorizontalResolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbHorizontalResolution.FormattingEnabled = True
		 Me._cmbHorizontalResolution.Location = New System.Drawing.Point(135, 78)
		 Me._cmbHorizontalResolution.Name = "_cmbHorizontalResolution"
		 Me._cmbHorizontalResolution.Size = New System.Drawing.Size(154, 21)
		 Me._cmbHorizontalResolution.TabIndex = 16
		 Me._cmbHorizontalResolution.Visible = False
'		 Me._cmbHorizontalResolution.SelectedIndexChanged += New System.EventHandler(Me._cmbHorizontalResolution_SelectedIndexChanged);
		 ' 
		 ' _numHeight
		 ' 
		 Me._numHeight.Enabled = False
		 Me._numHeight.Location = New System.Drawing.Point(189, 261)
		 Me._numHeight.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
		 Me._numHeight.Name = "_numHeight"
		 Me._numHeight.Size = New System.Drawing.Size(100, 20)
		 Me._numHeight.TabIndex = 23
'		 Me._numHeight.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _numWidth
		 ' 
		 Me._numWidth.Enabled = False
		 Me._numWidth.Location = New System.Drawing.Point(189, 235)
		 Me._numWidth.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
		 Me._numWidth.Name = "_numWidth"
		 Me._numWidth.Size = New System.Drawing.Size(100, 20)
		 Me._numWidth.TabIndex = 22
'		 Me._numWidth.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _numYPos
		 ' 
		 Me._numYPos.Enabled = False
		 Me._numYPos.Location = New System.Drawing.Point(189, 209)
		 Me._numYPos.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
		 Me._numYPos.Name = "_numYPos"
		 Me._numYPos.Size = New System.Drawing.Size(100, 20)
		 Me._numYPos.TabIndex = 21
'		 Me._numYPos.Leave += New System.EventHandler(Me._numYPos_Leave);
		 ' 
		 ' _numXPos
		 ' 
		 Me._numXPos.Enabled = False
		 Me._numXPos.Location = New System.Drawing.Point(189, 183)
		 Me._numXPos.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
		 Me._numXPos.Name = "_numXPos"
		 Me._numXPos.Size = New System.Drawing.Size(100, 20)
		 Me._numXPos.TabIndex = 20
'		 Me._numXPos.Leave += New System.EventHandler(Me._numXPos_Leave);
		 ' 
		 ' _numVerticalResolution
		 ' 
		 Me._numVerticalResolution.Enabled = False
		 Me._numVerticalResolution.ImeMode = System.Windows.Forms.ImeMode.NoControl
		 Me._numVerticalResolution.Location = New System.Drawing.Point(189, 104)
		 Me._numVerticalResolution.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
		 Me._numVerticalResolution.Name = "_numVerticalResolution"
		 Me._numVerticalResolution.Size = New System.Drawing.Size(100, 20)
		 Me._numVerticalResolution.TabIndex = 17
'		 Me._numVerticalResolution.Leave += New System.EventHandler(Me._numVerticalResolution_Leave);
		 ' 
		 ' _numVerticalScaling
		 ' 
		 Me._numVerticalScaling.Enabled = False
		 Me._numVerticalScaling.Location = New System.Drawing.Point(189, 157)
		 Me._numVerticalScaling.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
		 Me._numVerticalScaling.Name = "_numVerticalScaling"
		 Me._numVerticalScaling.Size = New System.Drawing.Size(100, 20)
		 Me._numVerticalScaling.TabIndex = 19
'		 Me._numVerticalScaling.Leave += New System.EventHandler(Me._numVerticalScaling_Leave);
		 ' 
		 ' _numHorizontalResolution
		 ' 
		 Me._numHorizontalResolution.Enabled = False
		 Me._numHorizontalResolution.ImeMode = System.Windows.Forms.ImeMode.NoControl
		 Me._numHorizontalResolution.Location = New System.Drawing.Point(189, 78)
		 Me._numHorizontalResolution.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
		 Me._numHorizontalResolution.Name = "_numHorizontalResolution"
		 Me._numHorizontalResolution.Size = New System.Drawing.Size(100, 20)
		 Me._numHorizontalResolution.TabIndex = 16
'		 Me._numHorizontalResolution.Leave += New System.EventHandler(Me._numHorizontalResolution_Leave);
		 ' 
		 ' _numHorizontalScaling
		 ' 
		 Me._numHorizontalScaling.Enabled = False
		 Me._numHorizontalScaling.Location = New System.Drawing.Point(189, 130)
		 Me._numHorizontalScaling.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
		 Me._numHorizontalScaling.Name = "_numHorizontalScaling"
		 Me._numHorizontalScaling.Size = New System.Drawing.Size(100, 20)
		 Me._numHorizontalScaling.TabIndex = 18
'		 Me._numHorizontalScaling.Leave += New System.EventHandler(Me._numHorizontalScaling_Leave);
		 ' 
		 ' _lblHeight
		 ' 
		 Me._lblHeight.AutoSize = True
		 Me._lblHeight.Location = New System.Drawing.Point(6, 263)
		 Me._lblHeight.Name = "_lblHeight"
		 Me._lblHeight.Size = New System.Drawing.Size(38, 13)
		 Me._lblHeight.TabIndex = 19
		 Me._lblHeight.Text = "Height"
		 ' 
		 ' _lblWidth
		 ' 
		 Me._lblWidth.AutoSize = True
		 Me._lblWidth.Location = New System.Drawing.Point(6, 237)
		 Me._lblWidth.Name = "_lblWidth"
		 Me._lblWidth.Size = New System.Drawing.Size(35, 13)
		 Me._lblWidth.TabIndex = 17
		 Me._lblWidth.Text = "Width"
		 ' 
		 ' _lblYPos
		 ' 
		 Me._lblYPos.AutoSize = True
		 Me._lblYPos.Location = New System.Drawing.Point(6, 211)
		 Me._lblYPos.Name = "_lblYPos"
		 Me._lblYPos.Size = New System.Drawing.Size(32, 13)
		 Me._lblYPos.TabIndex = 15
		 Me._lblYPos.Text = "YPos"
		 ' 
		 ' _lblXPos
		 ' 
		 Me._lblXPos.AutoSize = True
		 Me._lblXPos.Location = New System.Drawing.Point(6, 185)
		 Me._lblXPos.Name = "_lblXPos"
		 Me._lblXPos.Size = New System.Drawing.Size(32, 13)
		 Me._lblXPos.TabIndex = 13
		 Me._lblXPos.Text = "XPos"
		 ' 
		 ' _lblVerticalScaling
		 ' 
		 Me._lblVerticalScaling.AutoSize = True
		 Me._lblVerticalScaling.Location = New System.Drawing.Point(6, 159)
		 Me._lblVerticalScaling.Name = "_lblVerticalScaling"
		 Me._lblVerticalScaling.Size = New System.Drawing.Size(80, 13)
		 Me._lblVerticalScaling.TabIndex = 11
		 Me._lblVerticalScaling.Text = "Vertical Scaling"
		 ' 
		 ' _lblHorizontalScaling
		 ' 
		 Me._lblHorizontalScaling.AutoSize = True
		 Me._lblHorizontalScaling.Location = New System.Drawing.Point(6, 133)
		 Me._lblHorizontalScaling.Name = "_lblHorizontalScaling"
		 Me._lblHorizontalScaling.Size = New System.Drawing.Size(92, 13)
		 Me._lblHorizontalScaling.TabIndex = 9
		 Me._lblHorizontalScaling.Text = "Horizontal Scaling"
		 ' 
		 ' _lblVerticalResolution
		 ' 
		 Me._lblVerticalResolution.AutoSize = True
		 Me._lblVerticalResolution.Location = New System.Drawing.Point(6, 107)
		 Me._lblVerticalResolution.Name = "_lblVerticalResolution"
		 Me._lblVerticalResolution.Size = New System.Drawing.Size(95, 13)
		 Me._lblVerticalResolution.TabIndex = 7
		 Me._lblVerticalResolution.Text = "Vertical Resolution"
		 ' 
		 ' _lblHorizontalResolution
		 ' 
		 Me._lblHorizontalResolution.AutoSize = True
		 Me._lblHorizontalResolution.Location = New System.Drawing.Point(6, 81)
		 Me._lblHorizontalResolution.Name = "_lblHorizontalResolution"
		 Me._lblHorizontalResolution.Size = New System.Drawing.Size(107, 13)
		 Me._lblHorizontalResolution.TabIndex = 5
		 Me._lblHorizontalResolution.Text = "Horizontal Resolution"
		 ' 
		 ' _cmbRotationAngle
		 ' 
		 Me._cmbRotationAngle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbRotationAngle.Enabled = False
		 Me._cmbRotationAngle.FormattingEnabled = True
		 Me._cmbRotationAngle.Location = New System.Drawing.Point(135, 51)
		 Me._cmbRotationAngle.Name = "_cmbRotationAngle"
		 Me._cmbRotationAngle.Size = New System.Drawing.Size(154, 21)
		 Me._cmbRotationAngle.TabIndex = 15
		 ' 
		 ' _lblRotationAngle
		 ' 
		 Me._lblRotationAngle.AutoSize = True
		 Me._lblRotationAngle.Location = New System.Drawing.Point(6, 54)
		 Me._lblRotationAngle.Name = "_lblRotationAngle"
		 Me._lblRotationAngle.Size = New System.Drawing.Size(77, 13)
		 Me._lblRotationAngle.TabIndex = 2
		 Me._lblRotationAngle.Text = "Rotation Angle"
		 ' 
		 ' _cmbBitsPerPixel
		 ' 
		 Me._cmbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbBitsPerPixel.Enabled = False
		 Me._cmbBitsPerPixel.FormattingEnabled = True
		 Me._cmbBitsPerPixel.Location = New System.Drawing.Point(135, 24)
		 Me._cmbBitsPerPixel.Name = "_cmbBitsPerPixel"
		 Me._cmbBitsPerPixel.Size = New System.Drawing.Size(154, 21)
		 Me._cmbBitsPerPixel.TabIndex = 14
		 ' 
		 ' _lblBitsPerPixel
		 ' 
		 Me._lblBitsPerPixel.AutoSize = True
		 Me._lblBitsPerPixel.Location = New System.Drawing.Point(6, 27)
		 Me._lblBitsPerPixel.Name = "_lblBitsPerPixel"
		 Me._lblBitsPerPixel.Size = New System.Drawing.Size(68, 13)
		 Me._lblBitsPerPixel.TabIndex = 0
		 Me._lblBitsPerPixel.Text = "Bits Per Pixel"
		 ' 
		 ' _gbImageEffectsProperties
		 ' 
		 Me._gbImageEffectsProperties.Controls.Add(Me._numContrast)
		 Me._gbImageEffectsProperties.Controls.Add(Me._numBrightness)
		 Me._gbImageEffectsProperties.Controls.Add(Me._lblContrast)
		 Me._gbImageEffectsProperties.Controls.Add(Me._lblBrightness)
		 Me._gbImageEffectsProperties.Location = New System.Drawing.Point(313, 257)
		 Me._gbImageEffectsProperties.Name = "_gbImageEffectsProperties"
		 Me._gbImageEffectsProperties.Size = New System.Drawing.Size(295, 88)
		 Me._gbImageEffectsProperties.TabIndex = 3
		 Me._gbImageEffectsProperties.TabStop = False
		 Me._gbImageEffectsProperties.Text = "Image Effects Properties"
		 ' 
		 ' _numContrast
		 ' 
		 Me._numContrast.Enabled = False
		 Me._numContrast.Location = New System.Drawing.Point(189, 50)
		 Me._numContrast.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
		 Me._numContrast.Name = "_numContrast"
		 Me._numContrast.Size = New System.Drawing.Size(100, 20)
		 Me._numContrast.TabIndex = 31
'		 Me._numContrast.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _numBrightness
		 ' 
		 Me._numBrightness.Enabled = False
		 Me._numBrightness.Location = New System.Drawing.Point(189, 24)
		 Me._numBrightness.Minimum = New Decimal(New Integer() { 100, 0, 0, -2147483648})
		 Me._numBrightness.Name = "_numBrightness"
		 Me._numBrightness.Size = New System.Drawing.Size(100, 20)
		 Me._numBrightness.TabIndex = 30
'		 Me._numBrightness.Leave += New System.EventHandler(Me._num_Leave);
		 ' 
		 ' _lblContrast
		 ' 
		 Me._lblContrast.AutoSize = True
		 Me._lblContrast.Location = New System.Drawing.Point(6, 53)
		 Me._lblContrast.Name = "_lblContrast"
		 Me._lblContrast.Size = New System.Drawing.Size(46, 13)
		 Me._lblContrast.TabIndex = 1
		 Me._lblContrast.Text = "Contrast"
		 ' 
		 ' _lblBrightness
		 ' 
		 Me._lblBrightness.AutoSize = True
		 Me._lblBrightness.Location = New System.Drawing.Point(6, 27)
		 Me._lblBrightness.Name = "_lblBrightness"
		 Me._lblBrightness.Size = New System.Drawing.Size(56, 13)
		 Me._lblBrightness.TabIndex = 0
		 Me._lblBrightness.Text = "Brightness"
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(533, 528)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(75, 23)
		 Me._btnCancel.TabIndex = 33
		 Me._btnCancel.Text = "&Cancel"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' _btnOk
		 ' 
		 Me._btnOk.Location = New System.Drawing.Point(452, 528)
		 Me._btnOk.Name = "_btnOk"
		 Me._btnOk.Size = New System.Drawing.Size(75, 23)
		 Me._btnOk.TabIndex = 32
		 Me._btnOk.Text = "&OK"
		 Me._btnOk.UseVisualStyleBackColor = True
'		 Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
		 ' 
		 ' WiaPropertiesForm
		 ' 
		 Me.AcceptButton = Me._btnOk
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(620, 563)
		 Me.Controls.Add(Me._btnOk)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._gbImageEffectsProperties)
		 Me.Controls.Add(Me._gbImageResolutionProperties)
		 Me.Controls.Add(Me.groupBox1)
		 Me.Controls.Add(Me.groupBox2)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "WiaPropertiesForm"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "WIA Properties Dialog"
'		 Me.FormClosed += New System.Windows.Forms.FormClosedEventHandler(Me.WiaPropertiesForm_FormClosed);
'		 Me.Load += New System.EventHandler(Me.WiaPropertiesForm_Load);
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 CType(Me._numMaxPagesCount, System.ComponentModel.ISupportInitialize).EndInit()
		 Me._gbTransferMode.ResumeLayout(False)
		 Me._gbTransferMode.PerformLayout()
		 Me.groupBox2.ResumeLayout(False)
		 Me.groupBox2.PerformLayout()
		 Me.groupBox3.ResumeLayout(False)
		 Me.groupBox3.PerformLayout()
		 Me.groupBox4.ResumeLayout(False)
		 Me.groupBox4.PerformLayout()
		 Me._gbImageResolutionProperties.ResumeLayout(False)
		 Me._gbImageResolutionProperties.PerformLayout()
		 CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numYPos, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numXPos, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numVerticalResolution, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numVerticalScaling, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numHorizontalResolution, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numHorizontalScaling, System.ComponentModel.ISupportInitialize).EndInit()
		 Me._gbImageEffectsProperties.ResumeLayout(False)
		 Me._gbImageEffectsProperties.PerformLayout()
		 CType(Me._numContrast, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._numBrightness, System.ComponentModel.ISupportInitialize).EndInit()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private groupBox2 As System.Windows.Forms.GroupBox
	  Private _lblOrientation As System.Windows.Forms.Label
	  Private groupBox3 As System.Windows.Forms.GroupBox
	  Private WithEvents _cbAutoAdvance As System.Windows.Forms.CheckBox
	  Private _cbPrefeed As System.Windows.Forms.CheckBox
	  Private _cbNextPage As System.Windows.Forms.CheckBox
	  Private _cbBackFirst As System.Windows.Forms.CheckBox
	  Private _cbFrontFirst As System.Windows.Forms.CheckBox
	  Private _cbBackOnly As System.Windows.Forms.CheckBox
	  Private _cbFrontOnly As System.Windows.Forms.CheckBox
	  Private WithEvents _cbDuplex As System.Windows.Forms.CheckBox
	  Private _cbFlatbed As System.Windows.Forms.CheckBox
	  Private _cbFeeder As System.Windows.Forms.CheckBox
	  Private groupBox4 As System.Windows.Forms.GroupBox
	  Private WithEvents _cbColored As System.Windows.Forms.CheckBox
	  Private WithEvents _cbGrayscale As System.Windows.Forms.CheckBox
	  Private WithEvents _cbText As System.Windows.Forms.CheckBox
	  Private _cmbOrientation As System.Windows.Forms.ComboBox
	  Private _gbImageResolutionProperties As System.Windows.Forms.GroupBox
	  Private _lblBitsPerPixel As System.Windows.Forms.Label
	  Private _cmbRotationAngle As System.Windows.Forms.ComboBox
	  Private _lblRotationAngle As System.Windows.Forms.Label
	  Private _cmbBitsPerPixel As System.Windows.Forms.ComboBox
	  Private _lblHorizontalResolution As System.Windows.Forms.Label
	  Private _lblHorizontalScaling As System.Windows.Forms.Label
	  Private _lblVerticalResolution As System.Windows.Forms.Label
	  Private _lblHeight As System.Windows.Forms.Label
	  Private _lblWidth As System.Windows.Forms.Label
	  Private _lblYPos As System.Windows.Forms.Label
	  Private _lblXPos As System.Windows.Forms.Label
	  Private _lblVerticalScaling As System.Windows.Forms.Label
	  Private _cmbCompression As System.Windows.Forms.ComboBox
	  Private _lblCompression As System.Windows.Forms.Label
	  Private _cmbImageDataType As System.Windows.Forms.ComboBox
	  Private _lblImageDataType As System.Windows.Forms.Label
	  Private _cmbFormat As System.Windows.Forms.ComboBox
	  Private _lblFormat As System.Windows.Forms.Label
	  Private _gbTransferMode As System.Windows.Forms.GroupBox
	  Private WithEvents _rdFileMode As System.Windows.Forms.RadioButton
	  Private WithEvents _rdMemoryMode As System.Windows.Forms.RadioButton
	  Private _lblMaxPagesCount As System.Windows.Forms.Label
	  Private _gbImageEffectsProperties As System.Windows.Forms.GroupBox
	  Private _lblContrast As System.Windows.Forms.Label
	  Private _lblBrightness As System.Windows.Forms.Label
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _numHorizontalResolution As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numVerticalResolution As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numHeight As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numWidth As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numYPos As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numXPos As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numVerticalScaling As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numHorizontalScaling As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numMaxPagesCount As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numContrast As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numBrightness As System.Windows.Forms.NumericUpDown
	  Private WithEvents _cmbHorizontalResolution As System.Windows.Forms.ComboBox
	  Private WithEvents _cmbVerticalResolution As System.Windows.Forms.ComboBox
   End Class
End Namespace