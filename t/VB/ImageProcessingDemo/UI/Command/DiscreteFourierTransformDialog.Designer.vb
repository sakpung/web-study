Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class DiscreteFourierTransformDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DiscreteFourierTransformDialog))
            Me._gpTransformation = New System.Windows.Forms.GroupBox
            Me._rbInverseDiscreteFourierTransform = New System.Windows.Forms.RadioButton
            Me._rbDiscreteFourierTransform = New System.Windows.Forms.RadioButton
            Me._gbChannel = New System.Windows.Forms.GroupBox
            Me._rbGray = New System.Windows.Forms.RadioButton
            Me._rbBlue = New System.Windows.Forms.RadioButton
            Me._rbGreen = New System.Windows.Forms.RadioButton
            Me._rbRed = New System.Windows.Forms.RadioButton
            Me._gbFrequency = New System.Windows.Forms.GroupBox
            Me._rbBoth = New System.Windows.Forms.RadioButton
            Me._rbPhase = New System.Windows.Forms.RadioButton
            Me._rbMagnitude = New System.Windows.Forms.RadioButton
            Me._gbClipping = New System.Windows.Forms.GroupBox
            Me._rbScale = New System.Windows.Forms.RadioButton
            Me._rbClip = New System.Windows.Forms.RadioButton
            Me._gbHarmonics = New System.Windows.Forms.GroupBox
            Me._rbRange = New System.Windows.Forms.RadioButton
            Me._rbAll = New System.Windows.Forms.RadioButton
            Me._gbXHarmonics = New System.Windows.Forms.GroupBox
            Me._rbOutsideX = New System.Windows.Forms.RadioButton
            Me._rbInsideX = New System.Windows.Forms.RadioButton
            Me._gbYHarmonics = New System.Windows.Forms.GroupBox
            Me._rbOutsideY = New System.Windows.Forms.RadioButton
            Me._rbInsideY = New System.Windows.Forms.RadioButton
            Me._gbData = New System.Windows.Forms.GroupBox
            Me._rbDPhase = New System.Windows.Forms.RadioButton
            Me._rbDMagnitude = New System.Windows.Forms.RadioButton
            Me._gbPlotting = New System.Windows.Forms.GroupBox
            Me._rbLogarithm = New System.Windows.Forms.RadioButton
            Me._rbNormal = New System.Windows.Forms.RadioButton
            Me._gbRange = New System.Windows.Forms.GroupBox
            Me._numHeight = New System.Windows.Forms.NumericUpDown
            Me._numWidth = New System.Windows.Forms.NumericUpDown
            Me._numY = New System.Windows.Forms.NumericUpDown
            Me._numX = New System.Windows.Forms.NumericUpDown
            Me._lblHeight = New System.Windows.Forms.Label
            Me._lblWidth = New System.Windows.Forms.Label
            Me._lblY = New System.Windows.Forms.Label
            Me._lblX = New System.Windows.Forms.Label
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gpTransformation.SuspendLayout()
            Me._gbChannel.SuspendLayout()
            Me._gbFrequency.SuspendLayout()
            Me._gbClipping.SuspendLayout()
            Me._gbHarmonics.SuspendLayout()
            Me._gbXHarmonics.SuspendLayout()
            Me._gbYHarmonics.SuspendLayout()
            Me._gbData.SuspendLayout()
            Me._gbPlotting.SuspendLayout()
            Me._gbRange.SuspendLayout()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numY, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numX, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gpTransformation
            '
            Me._gpTransformation.Controls.Add(Me._rbInverseDiscreteFourierTransform)
            Me._gpTransformation.Controls.Add(Me._rbDiscreteFourierTransform)
            Me._gpTransformation.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gpTransformation.Location = New System.Drawing.Point(10, 10)
            Me._gpTransformation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gpTransformation.Name = "_gpTransformation"
            Me._gpTransformation.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gpTransformation.Size = New System.Drawing.Size(232, 67)
            Me._gpTransformation.TabIndex = 0
            Me._gpTransformation.TabStop = False
            Me._gpTransformation.Text = "Transformation"
            '
            '_rbInverseDiscreteFourierTransform
            '
            Me._rbInverseDiscreteFourierTransform.AutoSize = True
            Me._rbInverseDiscreteFourierTransform.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbInverseDiscreteFourierTransform.Location = New System.Drawing.Point(5, 41)
            Me._rbInverseDiscreteFourierTransform.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbInverseDiscreteFourierTransform.Name = "_rbInverseDiscreteFourierTransform"
            Me._rbInverseDiscreteFourierTransform.Size = New System.Drawing.Size(184, 18)
            Me._rbInverseDiscreteFourierTransform.TabIndex = 1
            Me._rbInverseDiscreteFourierTransform.TabStop = True
            Me._rbInverseDiscreteFourierTransform.Text = "InverseDiscreteFourierTransform"
            Me._rbInverseDiscreteFourierTransform.UseVisualStyleBackColor = True
            '
            '_rbDiscreteFourierTransform
            '
            Me._rbDiscreteFourierTransform.AutoSize = True
            Me._rbDiscreteFourierTransform.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbDiscreteFourierTransform.Location = New System.Drawing.Point(5, 19)
            Me._rbDiscreteFourierTransform.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbDiscreteFourierTransform.Name = "_rbDiscreteFourierTransform"
            Me._rbDiscreteFourierTransform.Size = New System.Drawing.Size(149, 18)
            Me._rbDiscreteFourierTransform.TabIndex = 0
            Me._rbDiscreteFourierTransform.TabStop = True
            Me._rbDiscreteFourierTransform.Text = "DiscreteFourierTransform"
            Me._rbDiscreteFourierTransform.UseVisualStyleBackColor = True
            '
            '_gbChannel
            '
            Me._gbChannel.Controls.Add(Me._rbGray)
            Me._gbChannel.Controls.Add(Me._rbBlue)
            Me._gbChannel.Controls.Add(Me._rbGreen)
            Me._gbChannel.Controls.Add(Me._rbRed)
            Me._gbChannel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbChannel.Location = New System.Drawing.Point(10, 81)
            Me._gbChannel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbChannel.Name = "_gbChannel"
            Me._gbChannel.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbChannel.Size = New System.Drawing.Size(235, 69)
            Me._gbChannel.TabIndex = 1
            Me._gbChannel.TabStop = False
            Me._gbChannel.Text = "Channel"
            '
            '_rbGray
            '
            Me._rbGray.AutoSize = True
            Me._rbGray.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbGray.Location = New System.Drawing.Point(129, 41)
            Me._rbGray.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbGray.Name = "_rbGray"
            Me._rbGray.Size = New System.Drawing.Size(53, 18)
            Me._rbGray.TabIndex = 3
            Me._rbGray.TabStop = True
            Me._rbGray.Text = "Gray"
            Me._rbGray.UseVisualStyleBackColor = True
            '
            '_rbBlue
            '
            Me._rbBlue.AutoSize = True
            Me._rbBlue.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbBlue.Location = New System.Drawing.Point(129, 19)
            Me._rbBlue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbBlue.Name = "_rbBlue"
            Me._rbBlue.Size = New System.Drawing.Size(52, 18)
            Me._rbBlue.TabIndex = 2
            Me._rbBlue.TabStop = True
            Me._rbBlue.Text = "Blue"
            Me._rbBlue.UseVisualStyleBackColor = True
            '
            '_rbGreen
            '
            Me._rbGreen.AutoSize = True
            Me._rbGreen.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbGreen.Location = New System.Drawing.Point(13, 41)
            Me._rbGreen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbGreen.Name = "_rbGreen"
            Me._rbGreen.Size = New System.Drawing.Size(60, 18)
            Me._rbGreen.TabIndex = 1
            Me._rbGreen.TabStop = True
            Me._rbGreen.Text = "Green"
            Me._rbGreen.UseVisualStyleBackColor = True
            '
            '_rbRed
            '
            Me._rbRed.AutoSize = True
            Me._rbRed.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbRed.Location = New System.Drawing.Point(13, 19)
            Me._rbRed.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbRed.Name = "_rbRed"
            Me._rbRed.Size = New System.Drawing.Size(51, 18)
            Me._rbRed.TabIndex = 0
            Me._rbRed.TabStop = True
            Me._rbRed.Text = "Red"
            Me._rbRed.UseVisualStyleBackColor = True
            '
            '_gbFrequency
            '
            Me._gbFrequency.Controls.Add(Me._rbBoth)
            Me._gbFrequency.Controls.Add(Me._rbPhase)
            Me._gbFrequency.Controls.Add(Me._rbMagnitude)
            Me._gbFrequency.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbFrequency.Location = New System.Drawing.Point(10, 155)
            Me._gbFrequency.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbFrequency.Name = "_gbFrequency"
            Me._gbFrequency.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbFrequency.Size = New System.Drawing.Size(232, 67)
            Me._gbFrequency.TabIndex = 2
            Me._gbFrequency.TabStop = False
            Me._gbFrequency.Text = "Frequency Data Type "
            '
            '_rbBoth
            '
            Me._rbBoth.AutoSize = True
            Me._rbBoth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbBoth.Location = New System.Drawing.Point(74, 41)
            Me._rbBoth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbBoth.Name = "_rbBoth"
            Me._rbBoth.Size = New System.Drawing.Size(53, 18)
            Me._rbBoth.TabIndex = 2
            Me._rbBoth.TabStop = True
            Me._rbBoth.Text = "Both"
            Me._rbBoth.UseVisualStyleBackColor = True
            '
            '_rbPhase
            '
            Me._rbPhase.AutoSize = True
            Me._rbPhase.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbPhase.Location = New System.Drawing.Point(129, 19)
            Me._rbPhase.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbPhase.Name = "_rbPhase"
            Me._rbPhase.Size = New System.Drawing.Size(61, 18)
            Me._rbPhase.TabIndex = 1
            Me._rbPhase.TabStop = True
            Me._rbPhase.Text = "Phase"
            Me._rbPhase.UseVisualStyleBackColor = True
            '
            '_rbMagnitude
            '
            Me._rbMagnitude.AutoSize = True
            Me._rbMagnitude.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbMagnitude.Location = New System.Drawing.Point(13, 19)
            Me._rbMagnitude.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbMagnitude.Name = "_rbMagnitude"
            Me._rbMagnitude.Size = New System.Drawing.Size(81, 18)
            Me._rbMagnitude.TabIndex = 0
            Me._rbMagnitude.TabStop = True
            Me._rbMagnitude.Text = "Magnitude"
            Me._rbMagnitude.UseVisualStyleBackColor = True
            '
            '_gbClipping
            '
            Me._gbClipping.Controls.Add(Me._rbScale)
            Me._gbClipping.Controls.Add(Me._rbClip)
            Me._gbClipping.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbClipping.Location = New System.Drawing.Point(248, 10)
            Me._gbClipping.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbClipping.Name = "_gbClipping"
            Me._gbClipping.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbClipping.Size = New System.Drawing.Size(127, 67)
            Me._gbClipping.TabIndex = 3
            Me._gbClipping.TabStop = False
            Me._gbClipping.Text = "Clipping"
            '
            '_rbScale
            '
            Me._rbScale.AutoSize = True
            Me._rbScale.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbScale.Location = New System.Drawing.Point(8, 41)
            Me._rbScale.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbScale.Name = "_rbScale"
            Me._rbScale.Size = New System.Drawing.Size(58, 18)
            Me._rbScale.TabIndex = 1
            Me._rbScale.TabStop = True
            Me._rbScale.Text = "Scale"
            Me._rbScale.UseVisualStyleBackColor = True
            '
            '_rbClip
            '
            Me._rbClip.AutoSize = True
            Me._rbClip.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbClip.Location = New System.Drawing.Point(8, 19)
            Me._rbClip.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbClip.Name = "_rbClip"
            Me._rbClip.Size = New System.Drawing.Size(48, 18)
            Me._rbClip.TabIndex = 0
            Me._rbClip.TabStop = True
            Me._rbClip.Text = "Clip"
            Me._rbClip.UseVisualStyleBackColor = True
            '
            '_gbHarmonics
            '
            Me._gbHarmonics.Controls.Add(Me._rbRange)
            Me._gbHarmonics.Controls.Add(Me._rbAll)
            Me._gbHarmonics.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbHarmonics.Location = New System.Drawing.Point(250, 81)
            Me._gbHarmonics.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbHarmonics.Name = "_gbHarmonics"
            Me._gbHarmonics.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbHarmonics.Size = New System.Drawing.Size(126, 67)
            Me._gbHarmonics.TabIndex = 4
            Me._gbHarmonics.TabStop = False
            Me._gbHarmonics.Text = "Harmonics"
            '
            '_rbRange
            '
            Me._rbRange.AutoSize = True
            Me._rbRange.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbRange.Location = New System.Drawing.Point(5, 41)
            Me._rbRange.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbRange.Name = "_rbRange"
            Me._rbRange.Size = New System.Drawing.Size(63, 18)
            Me._rbRange.TabIndex = 1
            Me._rbRange.TabStop = True
            Me._rbRange.Text = "Range"
            Me._rbRange.UseVisualStyleBackColor = True
            '
            '_rbAll
            '
            Me._rbAll.AutoSize = True
            Me._rbAll.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbAll.Location = New System.Drawing.Point(5, 19)
            Me._rbAll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbAll.Name = "_rbAll"
            Me._rbAll.Size = New System.Drawing.Size(42, 18)
            Me._rbAll.TabIndex = 0
            Me._rbAll.TabStop = True
            Me._rbAll.Text = "All"
            Me._rbAll.UseVisualStyleBackColor = True
            '
            '_gbXHarmonics
            '
            Me._gbXHarmonics.Controls.Add(Me._rbOutsideX)
            Me._gbXHarmonics.Controls.Add(Me._rbInsideX)
            Me._gbXHarmonics.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbXHarmonics.Location = New System.Drawing.Point(250, 158)
            Me._gbXHarmonics.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbXHarmonics.Name = "_gbXHarmonics"
            Me._gbXHarmonics.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbXHarmonics.Size = New System.Drawing.Size(126, 64)
            Me._gbXHarmonics.TabIndex = 5
            Me._gbXHarmonics.TabStop = False
            Me._gbXHarmonics.Text = "X Harmonics range"
            '
            '_rbOutsideX
            '
            Me._rbOutsideX.AutoSize = True
            Me._rbOutsideX.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbOutsideX.Location = New System.Drawing.Point(5, 39)
            Me._rbOutsideX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbOutsideX.Name = "_rbOutsideX"
            Me._rbOutsideX.Size = New System.Drawing.Size(77, 18)
            Me._rbOutsideX.TabIndex = 1
            Me._rbOutsideX.TabStop = True
            Me._rbOutsideX.Text = "Outside X"
            Me._rbOutsideX.UseVisualStyleBackColor = True
            '
            '_rbInsideX
            '
            Me._rbInsideX.AutoSize = True
            Me._rbInsideX.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbInsideX.Location = New System.Drawing.Point(5, 17)
            Me._rbInsideX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbInsideX.Name = "_rbInsideX"
            Me._rbInsideX.Size = New System.Drawing.Size(69, 18)
            Me._rbInsideX.TabIndex = 0
            Me._rbInsideX.TabStop = True
            Me._rbInsideX.Text = "Inside X"
            Me._rbInsideX.UseVisualStyleBackColor = True
            '
            '_gbYHarmonics
            '
            Me._gbYHarmonics.Controls.Add(Me._rbOutsideY)
            Me._gbYHarmonics.Controls.Add(Me._rbInsideY)
            Me._gbYHarmonics.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbYHarmonics.Location = New System.Drawing.Point(250, 228)
            Me._gbYHarmonics.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbYHarmonics.Name = "_gbYHarmonics"
            Me._gbYHarmonics.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbYHarmonics.Size = New System.Drawing.Size(126, 67)
            Me._gbYHarmonics.TabIndex = 6
            Me._gbYHarmonics.TabStop = False
            Me._gbYHarmonics.Text = "Y Harmonics range"
            '
            '_rbOutsideY
            '
            Me._rbOutsideY.AutoSize = True
            Me._rbOutsideY.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbOutsideY.Location = New System.Drawing.Point(5, 39)
            Me._rbOutsideY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbOutsideY.Name = "_rbOutsideY"
            Me._rbOutsideY.Size = New System.Drawing.Size(77, 18)
            Me._rbOutsideY.TabIndex = 1
            Me._rbOutsideY.TabStop = True
            Me._rbOutsideY.Text = "Outside Y"
            Me._rbOutsideY.UseVisualStyleBackColor = True
            '
            '_rbInsideY
            '
            Me._rbInsideY.AutoSize = True
            Me._rbInsideY.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbInsideY.Location = New System.Drawing.Point(5, 17)
            Me._rbInsideY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbInsideY.Name = "_rbInsideY"
            Me._rbInsideY.Size = New System.Drawing.Size(69, 18)
            Me._rbInsideY.TabIndex = 0
            Me._rbInsideY.TabStop = True
            Me._rbInsideY.Text = "Inside Y"
            Me._rbInsideY.UseVisualStyleBackColor = True
            '
            '_gbData
            '
            Me._gbData.Controls.Add(Me._rbDPhase)
            Me._gbData.Controls.Add(Me._rbDMagnitude)
            Me._gbData.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbData.Location = New System.Drawing.Point(10, 309)
            Me._gbData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbData.Name = "_gbData"
            Me._gbData.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbData.Size = New System.Drawing.Size(184, 75)
            Me._gbData.TabIndex = 7
            Me._gbData.TabStop = False
            Me._gbData.Text = "Data To Be Shown"
            '
            '_rbDPhase
            '
            Me._rbDPhase.AutoSize = True
            Me._rbDPhase.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbDPhase.Location = New System.Drawing.Point(5, 49)
            Me._rbDPhase.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbDPhase.Name = "_rbDPhase"
            Me._rbDPhase.Size = New System.Drawing.Size(61, 18)
            Me._rbDPhase.TabIndex = 1
            Me._rbDPhase.TabStop = True
            Me._rbDPhase.Text = "Phase"
            Me._rbDPhase.UseVisualStyleBackColor = True
            '
            '_rbDMagnitude
            '
            Me._rbDMagnitude.AutoSize = True
            Me._rbDMagnitude.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbDMagnitude.Location = New System.Drawing.Point(5, 19)
            Me._rbDMagnitude.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbDMagnitude.Name = "_rbDMagnitude"
            Me._rbDMagnitude.Size = New System.Drawing.Size(81, 18)
            Me._rbDMagnitude.TabIndex = 0
            Me._rbDMagnitude.TabStop = True
            Me._rbDMagnitude.Text = "Magnitude"
            Me._rbDMagnitude.UseVisualStyleBackColor = True
            '
            '_gbPlotting
            '
            Me._gbPlotting.Controls.Add(Me._rbLogarithm)
            Me._gbPlotting.Controls.Add(Me._rbNormal)
            Me._gbPlotting.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbPlotting.Location = New System.Drawing.Point(200, 309)
            Me._gbPlotting.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbPlotting.Name = "_gbPlotting"
            Me._gbPlotting.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbPlotting.Size = New System.Drawing.Size(177, 75)
            Me._gbPlotting.TabIndex = 8
            Me._gbPlotting.TabStop = False
            Me._gbPlotting.Text = "Plotting Scale"
            '
            '_rbLogarithm
            '
            Me._rbLogarithm.AutoSize = True
            Me._rbLogarithm.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbLogarithm.Location = New System.Drawing.Point(5, 49)
            Me._rbLogarithm.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbLogarithm.Name = "_rbLogarithm"
            Me._rbLogarithm.Size = New System.Drawing.Size(77, 18)
            Me._rbLogarithm.TabIndex = 1
            Me._rbLogarithm.TabStop = True
            Me._rbLogarithm.Text = "Logarithm"
            Me._rbLogarithm.UseVisualStyleBackColor = True
            '
            '_rbNormal
            '
            Me._rbNormal.AutoSize = True
            Me._rbNormal.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbNormal.Location = New System.Drawing.Point(5, 19)
            Me._rbNormal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbNormal.Name = "_rbNormal"
            Me._rbNormal.Size = New System.Drawing.Size(64, 18)
            Me._rbNormal.TabIndex = 0
            Me._rbNormal.TabStop = True
            Me._rbNormal.Text = "Normal"
            Me._rbNormal.UseVisualStyleBackColor = True
            '
            '_gbRange
            '
            Me._gbRange.Controls.Add(Me._numHeight)
            Me._gbRange.Controls.Add(Me._numWidth)
            Me._gbRange.Controls.Add(Me._numY)
            Me._gbRange.Controls.Add(Me._numX)
            Me._gbRange.Controls.Add(Me._lblHeight)
            Me._gbRange.Controls.Add(Me._lblWidth)
            Me._gbRange.Controls.Add(Me._lblY)
            Me._gbRange.Controls.Add(Me._lblX)
            Me._gbRange.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbRange.Location = New System.Drawing.Point(10, 228)
            Me._gbRange.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRange.Name = "_gbRange"
            Me._gbRange.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRange.Size = New System.Drawing.Size(232, 67)
            Me._gbRange.TabIndex = 9
            Me._gbRange.TabStop = False
            Me._gbRange.Text = "Range"
            '
            '_numHeight
            '
            Me._numHeight.Location = New System.Drawing.Point(167, 43)
            Me._numHeight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numHeight.Name = "_numHeight"
            Me._numHeight.Size = New System.Drawing.Size(51, 20)
            Me._numHeight.TabIndex = 7
            '
            '_numWidth
            '
            Me._numWidth.Location = New System.Drawing.Point(167, 19)
            Me._numWidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numWidth.Name = "_numWidth"
            Me._numWidth.Size = New System.Drawing.Size(51, 20)
            Me._numWidth.TabIndex = 6
            '
            '_numY
            '
            Me._numY.Enabled = False
            Me._numY.Location = New System.Drawing.Point(47, 43)
            Me._numY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numY.Name = "_numY"
            Me._numY.Size = New System.Drawing.Size(51, 20)
            Me._numY.TabIndex = 5
            '
            '_numX
            '
            Me._numX.Enabled = False
            Me._numX.Location = New System.Drawing.Point(47, 19)
            Me._numX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numX.Name = "_numX"
            Me._numX.Size = New System.Drawing.Size(51, 20)
            Me._numX.TabIndex = 4
            '
            '_lblHeight
            '
            Me._lblHeight.AutoSize = True
            Me._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblHeight.Location = New System.Drawing.Point(126, 46)
            Me._lblHeight.Name = "_lblHeight"
            Me._lblHeight.Size = New System.Drawing.Size(38, 13)
            Me._lblHeight.TabIndex = 3
            Me._lblHeight.Text = "Height"
            '
            '_lblWidth
            '
            Me._lblWidth.AutoSize = True
            Me._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblWidth.Location = New System.Drawing.Point(126, 21)
            Me._lblWidth.Name = "_lblWidth"
            Me._lblWidth.Size = New System.Drawing.Size(35, 13)
            Me._lblWidth.TabIndex = 2
            Me._lblWidth.Text = "Width"
            '
            '_lblY
            '
            Me._lblY.AutoSize = True
            Me._lblY.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblY.Location = New System.Drawing.Point(10, 46)
            Me._lblY.Name = "_lblY"
            Me._lblY.Size = New System.Drawing.Size(14, 13)
            Me._lblY.TabIndex = 1
            Me._lblY.Text = "Y"
            '
            '_lblX
            '
            Me._lblX.AutoSize = True
            Me._lblX.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblX.Location = New System.Drawing.Point(10, 21)
            Me._lblX.Name = "_lblX"
            Me._lblX.Size = New System.Drawing.Size(14, 13)
            Me._lblX.TabIndex = 0
            Me._lblX.Text = "X"
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(224, 403)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(75, 23)
            Me._btnCancel.TabIndex = 13
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(84, 403)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(75, 23)
            Me._btnOk.TabIndex = 12
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'DiscreteFourierTransformDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(389, 446)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbRange)
            Me.Controls.Add(Me._gbPlotting)
            Me.Controls.Add(Me._gbData)
            Me.Controls.Add(Me._gbYHarmonics)
            Me.Controls.Add(Me._gbXHarmonics)
            Me.Controls.Add(Me._gbHarmonics)
            Me.Controls.Add(Me._gbClipping)
            Me.Controls.Add(Me._gbFrequency)
            Me.Controls.Add(Me._gbChannel)
            Me.Controls.Add(Me._gpTransformation)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "DiscreteFourierTransformDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Discrete Fourier Transform"
            Me._gpTransformation.ResumeLayout(False)
            Me._gpTransformation.PerformLayout()
            Me._gbChannel.ResumeLayout(False)
            Me._gbChannel.PerformLayout()
            Me._gbFrequency.ResumeLayout(False)
            Me._gbFrequency.PerformLayout()
            Me._gbClipping.ResumeLayout(False)
            Me._gbClipping.PerformLayout()
            Me._gbHarmonics.ResumeLayout(False)
            Me._gbHarmonics.PerformLayout()
            Me._gbXHarmonics.ResumeLayout(False)
            Me._gbXHarmonics.PerformLayout()
            Me._gbYHarmonics.ResumeLayout(False)
            Me._gbYHarmonics.PerformLayout()
            Me._gbData.ResumeLayout(False)
            Me._gbData.PerformLayout()
            Me._gbPlotting.ResumeLayout(False)
            Me._gbPlotting.PerformLayout()
            Me._gbRange.ResumeLayout(False)
            Me._gbRange.PerformLayout()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numY, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numX, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gpTransformation As System.Windows.Forms.GroupBox
	  Private _rbInverseDiscreteFourierTransform As System.Windows.Forms.RadioButton
	  Private _rbDiscreteFourierTransform As System.Windows.Forms.RadioButton
	  Private _gbChannel As System.Windows.Forms.GroupBox
	  Private _rbGray As System.Windows.Forms.RadioButton
	  Private _rbBlue As System.Windows.Forms.RadioButton
	  Private _rbGreen As System.Windows.Forms.RadioButton
	  Private _rbRed As System.Windows.Forms.RadioButton
	  Private _gbFrequency As System.Windows.Forms.GroupBox
	  Private _rbBoth As System.Windows.Forms.RadioButton
	  Private _rbPhase As System.Windows.Forms.RadioButton
	  Private _rbMagnitude As System.Windows.Forms.RadioButton
	  Private _gbClipping As System.Windows.Forms.GroupBox
	  Private _rbScale As System.Windows.Forms.RadioButton
	  Private _rbClip As System.Windows.Forms.RadioButton
	  Private _gbHarmonics As System.Windows.Forms.GroupBox
	  Private _rbRange As System.Windows.Forms.RadioButton
	  Private _rbAll As System.Windows.Forms.RadioButton
	  Private _gbXHarmonics As System.Windows.Forms.GroupBox
	  Private _rbOutsideX As System.Windows.Forms.RadioButton
	  Private _rbInsideX As System.Windows.Forms.RadioButton
	  Private _gbYHarmonics As System.Windows.Forms.GroupBox
	  Private _rbOutsideY As System.Windows.Forms.RadioButton
	  Private _rbInsideY As System.Windows.Forms.RadioButton
	  Private _gbData As System.Windows.Forms.GroupBox
	  Private _rbDPhase As System.Windows.Forms.RadioButton
	  Private _rbDMagnitude As System.Windows.Forms.RadioButton
	  Private _gbPlotting As System.Windows.Forms.GroupBox
	  Private _rbLogarithm As System.Windows.Forms.RadioButton
	  Private _rbNormal As System.Windows.Forms.RadioButton
	  Private _gbRange As System.Windows.Forms.GroupBox
	  Private WithEvents _numHeight As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numWidth As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numY As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numX As System.Windows.Forms.NumericUpDown
	  Private _lblHeight As System.Windows.Forms.Label
	  Private _lblWidth As System.Windows.Forms.Label
	  Private _lblY As System.Windows.Forms.Label
	  Private _lblX As System.Windows.Forms.Label
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button


   End Class
End Namespace