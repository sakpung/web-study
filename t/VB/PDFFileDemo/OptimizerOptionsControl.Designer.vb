Imports Microsoft.VisualBasic
Imports System
Namespace PDFFileDemo
   Public Partial Class OptimizerOptionsControl
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

	  #Region "Component Designer generated code"

	  ''' <summary> 
	  ''' Required method for Designer support - do not modify 
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
		 Me._autoOptimizerModeComboBox = New System.Windows.Forms.ComboBox()
		 Me._autoOptimizerModeLabel = New System.Windows.Forms.Label()
		 Me._imageSettingsGroupBox = New System.Windows.Forms.GroupBox()
		 Me._monoImagesDownsamplingFactorNumericUpDown = New System.Windows.Forms.NumericUpDown()
		 Me._grayscaleImagesDownsamplingFactorNumericUpDown = New System.Windows.Forms.NumericUpDown()
		 Me._colorImagesDownsamplingFactorNumericUpDown = New System.Windows.Forms.NumericUpDown()
		 Me._monoImagesCompressionComboBox = New System.Windows.Forms.ComboBox()
		 Me.label11 = New System.Windows.Forms.Label()
		 Me._monoImagesDpiTextBox = New System.Windows.Forms.TextBox()
		 Me.label12 = New System.Windows.Forms.Label()
		 Me.label13 = New System.Windows.Forms.Label()
		 Me._monoImagesDownsamplingModeComboBox = New System.Windows.Forms.ComboBox()
		 Me.label14 = New System.Windows.Forms.Label()
		 Me.label15 = New System.Windows.Forms.Label()
		 Me._grayscaleImagesCompressionComboBox = New System.Windows.Forms.ComboBox()
		 Me.label6 = New System.Windows.Forms.Label()
		 Me._grayscaleImagesDpiTextBox = New System.Windows.Forms.TextBox()
		 Me.label7 = New System.Windows.Forms.Label()
		 Me.label8 = New System.Windows.Forms.Label()
		 Me._grayscaleImagesDownsamplingModeComboBox = New System.Windows.Forms.ComboBox()
		 Me.label9 = New System.Windows.Forms.Label()
		 Me.label10 = New System.Windows.Forms.Label()
		 Me._colorImagesCompressionComboBox = New System.Windows.Forms.ComboBox()
		 Me.label5 = New System.Windows.Forms.Label()
		 Me._colorImagesDpiTextBox = New System.Windows.Forms.TextBox()
		 Me.label4 = New System.Windows.Forms.Label()
		 Me.label3 = New System.Windows.Forms.Label()
		 Me._colorImagesDownsamplingModeComboBox = New System.Windows.Forms.ComboBox()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me._fontsGroupBox = New System.Windows.Forms.GroupBox()
		 Me._subsetAllEmbeddedFontsCheckBox = New System.Windows.Forms.CheckBox()
		 Me._embedAllFontsCheckBox = New System.Windows.Forms.CheckBox()
		 Me._imageSettingsGroupBox.SuspendLayout()
		 CType(Me._monoImagesDownsamplingFactorNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._grayscaleImagesDownsamplingFactorNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
		 CType(Me._colorImagesDownsamplingFactorNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me._fontsGroupBox.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' _autoOptimizerModeComboBox
		 ' 
		 Me._autoOptimizerModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._autoOptimizerModeComboBox.FormattingEnabled = True
		 Me._autoOptimizerModeComboBox.Location = New System.Drawing.Point(114, 3)
		 Me._autoOptimizerModeComboBox.Name = "_autoOptimizerModeComboBox"
		 Me._autoOptimizerModeComboBox.Size = New System.Drawing.Size(181, 21)
		 Me._autoOptimizerModeComboBox.TabIndex = 0
'		 Me._autoOptimizerModeComboBox.SelectedIndexChanged += New System.EventHandler(Me._autoOptimizerModeComboBox_SelectedIndexChanged);
		 ' 
		 ' _autoOptimizerModeLabel
		 ' 
		 Me._autoOptimizerModeLabel.AutoSize = True
		 Me._autoOptimizerModeLabel.Location = New System.Drawing.Point(3, 6)
		 Me._autoOptimizerModeLabel.Name = "_autoOptimizerModeLabel"
		 Me._autoOptimizerModeLabel.Size = New System.Drawing.Size(105, 13)
		 Me._autoOptimizerModeLabel.TabIndex = 12
		 Me._autoOptimizerModeLabel.Text = "Auto optimizer mode:"
		 ' 
		 ' _imageSettingsGroupBox
		 ' 
		 Me._imageSettingsGroupBox.Controls.Add(Me._monoImagesDownsamplingFactorNumericUpDown)
		 Me._imageSettingsGroupBox.Controls.Add(Me._grayscaleImagesDownsamplingFactorNumericUpDown)
		 Me._imageSettingsGroupBox.Controls.Add(Me._colorImagesDownsamplingFactorNumericUpDown)
		 Me._imageSettingsGroupBox.Controls.Add(Me._monoImagesCompressionComboBox)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label11)
		 Me._imageSettingsGroupBox.Controls.Add(Me._monoImagesDpiTextBox)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label12)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label13)
		 Me._imageSettingsGroupBox.Controls.Add(Me._monoImagesDownsamplingModeComboBox)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label14)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label15)
		 Me._imageSettingsGroupBox.Controls.Add(Me._grayscaleImagesCompressionComboBox)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label6)
		 Me._imageSettingsGroupBox.Controls.Add(Me._grayscaleImagesDpiTextBox)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label7)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label8)
		 Me._imageSettingsGroupBox.Controls.Add(Me._grayscaleImagesDownsamplingModeComboBox)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label9)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label10)
		 Me._imageSettingsGroupBox.Controls.Add(Me._colorImagesCompressionComboBox)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label5)
		 Me._imageSettingsGroupBox.Controls.Add(Me._colorImagesDpiTextBox)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label4)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label3)
		 Me._imageSettingsGroupBox.Controls.Add(Me._colorImagesDownsamplingModeComboBox)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label2)
		 Me._imageSettingsGroupBox.Controls.Add(Me.label1)
		 Me._imageSettingsGroupBox.Location = New System.Drawing.Point(6, 30)
		 Me._imageSettingsGroupBox.Name = "_imageSettingsGroupBox"
		 Me._imageSettingsGroupBox.Size = New System.Drawing.Size(549, 313)
		 Me._imageSettingsGroupBox.TabIndex = 11
		 Me._imageSettingsGroupBox.TabStop = False
		 Me._imageSettingsGroupBox.Text = "Image Settings"
		 ' 
		 ' _monoImagesDownsamplingFactorNumericUpDown
		 ' 
		 Me._monoImagesDownsamplingFactorNumericUpDown.DecimalPlaces = 1
		 Me._monoImagesDownsamplingFactorNumericUpDown.Location = New System.Drawing.Point(355, 246)
		 Me._monoImagesDownsamplingFactorNumericUpDown.Maximum = New Decimal(New Integer() { 100, 0, 0, 65536})
		 Me._monoImagesDownsamplingFactorNumericUpDown.Minimum = New Decimal(New Integer() { 10, 0, 0, 65536})
		 Me._monoImagesDownsamplingFactorNumericUpDown.Name = "_monoImagesDownsamplingFactorNumericUpDown"
		 Me._monoImagesDownsamplingFactorNumericUpDown.Size = New System.Drawing.Size(65, 20)
		 Me._monoImagesDownsamplingFactorNumericUpDown.TabIndex = 10
		 Me._monoImagesDownsamplingFactorNumericUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 65536})
		 ' 
		 ' _grayscaleImagesDownsamplingFactorNumericUpDown
		 ' 
		 Me._grayscaleImagesDownsamplingFactorNumericUpDown.DecimalPlaces = 1
		 Me._grayscaleImagesDownsamplingFactorNumericUpDown.Location = New System.Drawing.Point(355, 147)
		 Me._grayscaleImagesDownsamplingFactorNumericUpDown.Maximum = New Decimal(New Integer() { 100, 0, 0, 65536})
		 Me._grayscaleImagesDownsamplingFactorNumericUpDown.Minimum = New Decimal(New Integer() { 10, 0, 0, 65536})
		 Me._grayscaleImagesDownsamplingFactorNumericUpDown.Name = "_grayscaleImagesDownsamplingFactorNumericUpDown"
		 Me._grayscaleImagesDownsamplingFactorNumericUpDown.Size = New System.Drawing.Size(65, 20)
		 Me._grayscaleImagesDownsamplingFactorNumericUpDown.TabIndex = 6
		 Me._grayscaleImagesDownsamplingFactorNumericUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 65536})
		 ' 
		 ' _colorImagesDownsamplingFactorNumericUpDown
		 ' 
		 Me._colorImagesDownsamplingFactorNumericUpDown.DecimalPlaces = 1
		 Me._colorImagesDownsamplingFactorNumericUpDown.Location = New System.Drawing.Point(355, 50)
		 Me._colorImagesDownsamplingFactorNumericUpDown.Maximum = New Decimal(New Integer() { 100, 0, 0, 65536})
		 Me._colorImagesDownsamplingFactorNumericUpDown.Minimum = New Decimal(New Integer() { 10, 0, 0, 65536})
		 Me._colorImagesDownsamplingFactorNumericUpDown.Name = "_colorImagesDownsamplingFactorNumericUpDown"
		 Me._colorImagesDownsamplingFactorNumericUpDown.Size = New System.Drawing.Size(65, 20)
		 Me._colorImagesDownsamplingFactorNumericUpDown.TabIndex = 2
		 Me._colorImagesDownsamplingFactorNumericUpDown.Value = New Decimal(New Integer() { 10, 0, 0, 65536})
		 ' 
		 ' _monoImagesCompressionComboBox
		 ' 
		 Me._monoImagesCompressionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._monoImagesCompressionComboBox.FormattingEnabled = True
		 Me._monoImagesCompressionComboBox.Location = New System.Drawing.Point(129, 272)
		 Me._monoImagesCompressionComboBox.Name = "_monoImagesCompressionComboBox"
		 Me._monoImagesCompressionComboBox.Size = New System.Drawing.Size(99, 21)
		 Me._monoImagesCompressionComboBox.TabIndex = 12
		 ' 
		 ' label11
		 ' 
		 Me.label11.AutoSize = True
		 Me.label11.Location = New System.Drawing.Point(24, 275)
		 Me.label11.Name = "label11"
		 Me.label11.Size = New System.Drawing.Size(70, 13)
		 Me.label11.TabIndex = 25
		 Me.label11.Text = "Compression:"
		 ' 
		 ' _monoImagesDpiTextBox
		 ' 
		 Me._monoImagesDpiTextBox.Location = New System.Drawing.Point(469, 245)
		 Me._monoImagesDpiTextBox.Name = "_monoImagesDpiTextBox"
		 Me._monoImagesDpiTextBox.Size = New System.Drawing.Size(65, 20)
		 Me._monoImagesDpiTextBox.TabIndex = 11
		 ' 
		 ' label12
		 ' 
		 Me.label12.AutoSize = True
		 Me.label12.Location = New System.Drawing.Point(437, 248)
		 Me.label12.Name = "label12"
		 Me.label12.Size = New System.Drawing.Size(26, 13)
		 Me.label12.TabIndex = 23
		 Me.label12.Text = "Dpi:"
		 ' 
		 ' label13
		 ' 
		 Me.label13.AutoSize = True
		 Me.label13.Location = New System.Drawing.Point(247, 248)
		 Me.label13.Name = "label13"
		 Me.label13.Size = New System.Drawing.Size(104, 13)
		 Me.label13.TabIndex = 21
		 Me.label13.Text = "Downsample Factor:"
		 ' 
		 ' _monoImagesDownsamplingModeComboBox
		 ' 
		 Me._monoImagesDownsamplingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._monoImagesDownsamplingModeComboBox.FormattingEnabled = True
		 Me._monoImagesDownsamplingModeComboBox.Location = New System.Drawing.Point(129, 245)
		 Me._monoImagesDownsamplingModeComboBox.Name = "_monoImagesDownsamplingModeComboBox"
		 Me._monoImagesDownsamplingModeComboBox.Size = New System.Drawing.Size(99, 21)
		 Me._monoImagesDownsamplingModeComboBox.TabIndex = 9
		 ' 
		 ' label14
		 ' 
		 Me.label14.AutoSize = True
		 Me.label14.Location = New System.Drawing.Point(24, 248)
		 Me.label14.Name = "label14"
		 Me.label14.Size = New System.Drawing.Size(101, 13)
		 Me.label14.TabIndex = 19
		 Me.label14.Text = "Downsample Mode:"
		 ' 
		 ' label15
		 ' 
		 Me.label15.AutoSize = True
		 Me.label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
		 Me.label15.Location = New System.Drawing.Point(21, 221)
		 Me.label15.Name = "label15"
		 Me.label15.Size = New System.Drawing.Size(127, 13)
		 Me.label15.TabIndex = 18
		 Me.label15.Text = "Monochrome Images:"
		 ' 
		 ' _grayscaleImagesCompressionComboBox
		 ' 
		 Me._grayscaleImagesCompressionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._grayscaleImagesCompressionComboBox.FormattingEnabled = True
		 Me._grayscaleImagesCompressionComboBox.Location = New System.Drawing.Point(129, 173)
		 Me._grayscaleImagesCompressionComboBox.Name = "_grayscaleImagesCompressionComboBox"
		 Me._grayscaleImagesCompressionComboBox.Size = New System.Drawing.Size(99, 21)
		 Me._grayscaleImagesCompressionComboBox.TabIndex = 8
		 ' 
		 ' label6
		 ' 
		 Me.label6.AutoSize = True
		 Me.label6.Location = New System.Drawing.Point(24, 176)
		 Me.label6.Name = "label6"
		 Me.label6.Size = New System.Drawing.Size(70, 13)
		 Me.label6.TabIndex = 16
		 Me.label6.Text = "Compression:"
		 ' 
		 ' _grayscaleImagesDpiTextBox
		 ' 
		 Me._grayscaleImagesDpiTextBox.Location = New System.Drawing.Point(469, 146)
		 Me._grayscaleImagesDpiTextBox.Name = "_grayscaleImagesDpiTextBox"
		 Me._grayscaleImagesDpiTextBox.Size = New System.Drawing.Size(65, 20)
		 Me._grayscaleImagesDpiTextBox.TabIndex = 7
		 ' 
		 ' label7
		 ' 
		 Me.label7.AutoSize = True
		 Me.label7.Location = New System.Drawing.Point(437, 149)
		 Me.label7.Name = "label7"
		 Me.label7.Size = New System.Drawing.Size(26, 13)
		 Me.label7.TabIndex = 14
		 Me.label7.Text = "Dpi:"
		 ' 
		 ' label8
		 ' 
		 Me.label8.AutoSize = True
		 Me.label8.Location = New System.Drawing.Point(247, 149)
		 Me.label8.Name = "label8"
		 Me.label8.Size = New System.Drawing.Size(104, 13)
		 Me.label8.TabIndex = 12
		 Me.label8.Text = "Downsample Factor:"
		 ' 
		 ' _grayscaleImagesDownsamplingModeComboBox
		 ' 
		 Me._grayscaleImagesDownsamplingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._grayscaleImagesDownsamplingModeComboBox.FormattingEnabled = True
		 Me._grayscaleImagesDownsamplingModeComboBox.Location = New System.Drawing.Point(129, 146)
		 Me._grayscaleImagesDownsamplingModeComboBox.Name = "_grayscaleImagesDownsamplingModeComboBox"
		 Me._grayscaleImagesDownsamplingModeComboBox.Size = New System.Drawing.Size(99, 21)
		 Me._grayscaleImagesDownsamplingModeComboBox.TabIndex = 5
		 ' 
		 ' label9
		 ' 
		 Me.label9.AutoSize = True
		 Me.label9.Location = New System.Drawing.Point(24, 149)
		 Me.label9.Name = "label9"
		 Me.label9.Size = New System.Drawing.Size(101, 13)
		 Me.label9.TabIndex = 10
		 Me.label9.Text = "Downsample Mode:"
		 ' 
		 ' label10
		 ' 
		 Me.label10.AutoSize = True
		 Me.label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
		 Me.label10.Location = New System.Drawing.Point(21, 122)
		 Me.label10.Name = "label10"
		 Me.label10.Size = New System.Drawing.Size(111, 13)
		 Me.label10.TabIndex = 9
		 Me.label10.Text = "Grayscale Images:"
		 ' 
		 ' _colorImagesCompressionComboBox
		 ' 
		 Me._colorImagesCompressionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._colorImagesCompressionComboBox.FormattingEnabled = True
		 Me._colorImagesCompressionComboBox.Location = New System.Drawing.Point(129, 76)
		 Me._colorImagesCompressionComboBox.Name = "_colorImagesCompressionComboBox"
		 Me._colorImagesCompressionComboBox.Size = New System.Drawing.Size(99, 21)
		 Me._colorImagesCompressionComboBox.TabIndex = 4
		 ' 
		 ' label5
		 ' 
		 Me.label5.AutoSize = True
		 Me.label5.Location = New System.Drawing.Point(24, 79)
		 Me.label5.Name = "label5"
		 Me.label5.Size = New System.Drawing.Size(70, 13)
		 Me.label5.TabIndex = 7
		 Me.label5.Text = "Compression:"
		 ' 
		 ' _colorImagesDpiTextBox
		 ' 
		 Me._colorImagesDpiTextBox.Location = New System.Drawing.Point(469, 49)
		 Me._colorImagesDpiTextBox.Name = "_colorImagesDpiTextBox"
		 Me._colorImagesDpiTextBox.Size = New System.Drawing.Size(65, 20)
		 Me._colorImagesDpiTextBox.TabIndex = 3
		 ' 
		 ' label4
		 ' 
		 Me.label4.AutoSize = True
		 Me.label4.Location = New System.Drawing.Point(437, 52)
		 Me.label4.Name = "label4"
		 Me.label4.Size = New System.Drawing.Size(26, 13)
		 Me.label4.TabIndex = 5
		 Me.label4.Text = "Dpi:"
		 ' 
		 ' label3
		 ' 
		 Me.label3.AutoSize = True
		 Me.label3.Location = New System.Drawing.Point(247, 52)
		 Me.label3.Name = "label3"
		 Me.label3.Size = New System.Drawing.Size(104, 13)
		 Me.label3.TabIndex = 3
		 Me.label3.Text = "Downsample Factor:"
		 ' 
		 ' _colorImagesDownsamplingModeComboBox
		 ' 
		 Me._colorImagesDownsamplingModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._colorImagesDownsamplingModeComboBox.FormattingEnabled = True
		 Me._colorImagesDownsamplingModeComboBox.Location = New System.Drawing.Point(129, 49)
		 Me._colorImagesDownsamplingModeComboBox.Name = "_colorImagesDownsamplingModeComboBox"
		 Me._colorImagesDownsamplingModeComboBox.Size = New System.Drawing.Size(99, 21)
		 Me._colorImagesDownsamplingModeComboBox.TabIndex = 1
		 ' 
		 ' label2
		 ' 
		 Me.label2.AutoSize = True
		 Me.label2.Location = New System.Drawing.Point(24, 52)
		 Me.label2.Name = "label2"
		 Me.label2.Size = New System.Drawing.Size(101, 13)
		 Me.label2.TabIndex = 1
		 Me.label2.Text = "Downsample Mode:"
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (CByte(0)))
		 Me.label1.Location = New System.Drawing.Point(21, 25)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(84, 13)
		 Me.label1.TabIndex = 0
		 Me.label1.Text = "Color Images:"
		 ' 
		 ' _fontsGroupBox
		 ' 
		 Me._fontsGroupBox.Controls.Add(Me._subsetAllEmbeddedFontsCheckBox)
		 Me._fontsGroupBox.Controls.Add(Me._embedAllFontsCheckBox)
		 Me._fontsGroupBox.Location = New System.Drawing.Point(6, 349)
		 Me._fontsGroupBox.Name = "_fontsGroupBox"
		 Me._fontsGroupBox.Size = New System.Drawing.Size(549, 67)
		 Me._fontsGroupBox.TabIndex = 10
		 Me._fontsGroupBox.TabStop = False
		 Me._fontsGroupBox.Text = "Fonts:"
		 ' 
		 ' _subsetAllEmbeddedFontsCheckBox
		 ' 
		 Me._subsetAllEmbeddedFontsCheckBox.AutoSize = True
		 Me._subsetAllEmbeddedFontsCheckBox.Location = New System.Drawing.Point(24, 42)
		 Me._subsetAllEmbeddedFontsCheckBox.Name = "_subsetAllEmbeddedFontsCheckBox"
		 Me._subsetAllEmbeddedFontsCheckBox.Size = New System.Drawing.Size(151, 17)
		 Me._subsetAllEmbeddedFontsCheckBox.TabIndex = 14
		 Me._subsetAllEmbeddedFontsCheckBox.Text = "&Subset all embedded fonts"
		 Me._subsetAllEmbeddedFontsCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' _embedAllFontsCheckBox
		 ' 
		 Me._embedAllFontsCheckBox.AutoSize = True
		 Me._embedAllFontsCheckBox.Location = New System.Drawing.Point(24, 19)
		 Me._embedAllFontsCheckBox.Name = "_embedAllFontsCheckBox"
		 Me._embedAllFontsCheckBox.Size = New System.Drawing.Size(98, 17)
		 Me._embedAllFontsCheckBox.TabIndex = 13
		 Me._embedAllFontsCheckBox.Text = "E&mbed all fonts"
		 Me._embedAllFontsCheckBox.UseVisualStyleBackColor = True
		 ' 
		 ' OptimizerOptionsControl
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.Controls.Add(Me._autoOptimizerModeComboBox)
		 Me.Controls.Add(Me._autoOptimizerModeLabel)
		 Me.Controls.Add(Me._imageSettingsGroupBox)
		 Me.Controls.Add(Me._fontsGroupBox)
		 Me.Name = "OptimizerOptionsControl"
		 Me.Size = New System.Drawing.Size(561, 424)
		 Me._imageSettingsGroupBox.ResumeLayout(False)
		 Me._imageSettingsGroupBox.PerformLayout()
		 CType(Me._monoImagesDownsamplingFactorNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._grayscaleImagesDownsamplingFactorNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
		 CType(Me._colorImagesDownsamplingFactorNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
		 Me._fontsGroupBox.ResumeLayout(False)
		 Me._fontsGroupBox.PerformLayout()
		 Me.ResumeLayout(False)
		 Me.PerformLayout()

	  End Sub

	  #End Region

	  Private WithEvents _autoOptimizerModeComboBox As System.Windows.Forms.ComboBox
	  Private _autoOptimizerModeLabel As System.Windows.Forms.Label
	  Private _imageSettingsGroupBox As System.Windows.Forms.GroupBox
	  Private label1 As System.Windows.Forms.Label
	  Private _fontsGroupBox As System.Windows.Forms.GroupBox
	  Private _subsetAllEmbeddedFontsCheckBox As System.Windows.Forms.CheckBox
	  Private _embedAllFontsCheckBox As System.Windows.Forms.CheckBox
	  Private _colorImagesDownsamplingModeComboBox As System.Windows.Forms.ComboBox
	  Private label2 As System.Windows.Forms.Label
	  Private label3 As System.Windows.Forms.Label
	  Private _colorImagesDpiTextBox As System.Windows.Forms.TextBox
	  Private label4 As System.Windows.Forms.Label
	  Private _colorImagesCompressionComboBox As System.Windows.Forms.ComboBox
	  Private label5 As System.Windows.Forms.Label
	  Private _monoImagesCompressionComboBox As System.Windows.Forms.ComboBox
	  Private label11 As System.Windows.Forms.Label
	  Private _monoImagesDpiTextBox As System.Windows.Forms.TextBox
	  Private label12 As System.Windows.Forms.Label
	  Private label13 As System.Windows.Forms.Label
	  Private _monoImagesDownsamplingModeComboBox As System.Windows.Forms.ComboBox
	  Private label14 As System.Windows.Forms.Label
	  Private label15 As System.Windows.Forms.Label
	  Private _grayscaleImagesCompressionComboBox As System.Windows.Forms.ComboBox
	  Private label6 As System.Windows.Forms.Label
	  Private _grayscaleImagesDpiTextBox As System.Windows.Forms.TextBox
	  Private label7 As System.Windows.Forms.Label
	  Private label8 As System.Windows.Forms.Label
	  Private _grayscaleImagesDownsamplingModeComboBox As System.Windows.Forms.ComboBox
	  Private label9 As System.Windows.Forms.Label
	  Private label10 As System.Windows.Forms.Label
	  Private _monoImagesDownsamplingFactorNumericUpDown As System.Windows.Forms.NumericUpDown
	  Private _grayscaleImagesDownsamplingFactorNumericUpDown As System.Windows.Forms.NumericUpDown
	  Private _colorImagesDownsamplingFactorNumericUpDown As System.Windows.Forms.NumericUpDown
   End Class
End Namespace
