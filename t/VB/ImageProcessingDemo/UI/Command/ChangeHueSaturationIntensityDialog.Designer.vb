Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class ChangeHueSaturationIntensityDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangeHueSaturationIntensityDialog))
            Me._cmbMask = New System.Windows.Forms.ComboBox
            Me._lblMask = New System.Windows.Forms.Label
            Me._gbSourceChannels = New System.Windows.Forms.GroupBox
            Me._lblIntensity = New System.Windows.Forms.Label
            Me._lblSaturation = New System.Windows.Forms.Label
            Me._lblHue = New System.Windows.Forms.Label
            Me._tbIntensity = New System.Windows.Forms.TrackBar
            Me._tbSaturation = New System.Windows.Forms.TrackBar
            Me._tbHue = New System.Windows.Forms.TrackBar
            Me._numIntensity = New System.Windows.Forms.NumericUpDown
            Me._numSaturation = New System.Windows.Forms.NumericUpDown
            Me._numHue = New System.Windows.Forms.NumericUpDown
            Me._gbOuterRange = New System.Windows.Forms.GroupBox
            Me._numOuterHigh = New System.Windows.Forms.NumericUpDown
            Me._numOuterLow = New System.Windows.Forms.NumericUpDown
            Me._tbOuterHigh = New System.Windows.Forms.TrackBar
            Me._tbOuterLow = New System.Windows.Forms.TrackBar
            Me._lblOuterHigh = New System.Windows.Forms.Label
            Me._lblOuterLow = New System.Windows.Forms.Label
            Me._gbInnerRange = New System.Windows.Forms.GroupBox
            Me._lblInnerHigh = New System.Windows.Forms.Label
            Me._numInnerHigh = New System.Windows.Forms.NumericUpDown
            Me._lblInnerLow = New System.Windows.Forms.Label
            Me._tbInnerLow = New System.Windows.Forms.TrackBar
            Me._numInnerLow = New System.Windows.Forms.NumericUpDown
            Me._tbInnerHigh = New System.Windows.Forms.TrackBar
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnok = New System.Windows.Forms.Button
            Me._gbSourceChannels.SuspendLayout()
            CType(Me._tbIntensity, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbSaturation, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbHue, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numIntensity, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numSaturation, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numHue, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbOuterRange.SuspendLayout()
            CType(Me._numOuterHigh, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numOuterLow, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbOuterHigh, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbOuterLow, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbInnerRange.SuspendLayout()
            CType(Me._numInnerHigh, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbInnerLow, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numInnerLow, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbInnerHigh, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_cmbMask
            '
            Me._cmbMask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbMask.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbMask.FormattingEnabled = True
            Me._cmbMask.Location = New System.Drawing.Point(74, 25)
            Me._cmbMask.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbMask.Name = "_cmbMask"
            Me._cmbMask.Size = New System.Drawing.Size(130, 21)
            Me._cmbMask.TabIndex = 0
            '
            '_lblMask
            '
            Me._lblMask.AutoSize = True
            Me._lblMask.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblMask.Location = New System.Drawing.Point(24, 28)
            Me._lblMask.Name = "_lblMask"
            Me._lblMask.Size = New System.Drawing.Size(33, 13)
            Me._lblMask.TabIndex = 1
            Me._lblMask.Text = "Mask"
            '
            '_gbSourceChannels
            '
            Me._gbSourceChannels.Controls.Add(Me._lblIntensity)
            Me._gbSourceChannels.Controls.Add(Me._lblSaturation)
            Me._gbSourceChannels.Controls.Add(Me._lblHue)
            Me._gbSourceChannels.Controls.Add(Me._tbIntensity)
            Me._gbSourceChannels.Controls.Add(Me._tbSaturation)
            Me._gbSourceChannels.Controls.Add(Me._tbHue)
            Me._gbSourceChannels.Controls.Add(Me._numIntensity)
            Me._gbSourceChannels.Controls.Add(Me._numSaturation)
            Me._gbSourceChannels.Controls.Add(Me._numHue)
            Me._gbSourceChannels.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbSourceChannels.Location = New System.Drawing.Point(10, 61)
            Me._gbSourceChannels.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSourceChannels.Name = "_gbSourceChannels"
            Me._gbSourceChannels.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSourceChannels.Size = New System.Drawing.Size(291, 124)
            Me._gbSourceChannels.TabIndex = 2
            Me._gbSourceChannels.TabStop = False
            Me._gbSourceChannels.Text = "Source Channels"
            '
            '_lblIntensity
            '
            Me._lblIntensity.AutoSize = True
            Me._lblIntensity.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblIntensity.Location = New System.Drawing.Point(6, 91)
            Me._lblIntensity.Name = "_lblIntensity"
            Me._lblIntensity.Size = New System.Drawing.Size(46, 13)
            Me._lblIntensity.TabIndex = 8
            Me._lblIntensity.Text = "Intensity"
            '
            '_lblSaturation
            '
            Me._lblSaturation.AutoSize = True
            Me._lblSaturation.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblSaturation.Location = New System.Drawing.Point(6, 52)
            Me._lblSaturation.Name = "_lblSaturation"
            Me._lblSaturation.Size = New System.Drawing.Size(55, 13)
            Me._lblSaturation.TabIndex = 7
            Me._lblSaturation.Text = "Saturation"
            '
            '_lblHue
            '
            Me._lblHue.AutoSize = True
            Me._lblHue.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblHue.Location = New System.Drawing.Point(6, 20)
            Me._lblHue.Name = "_lblHue"
            Me._lblHue.Size = New System.Drawing.Size(27, 13)
            Me._lblHue.TabIndex = 6
            Me._lblHue.Text = "Hue"
            '
            '_tbIntensity
            '
            Me._tbIntensity.AutoSize = False
            Me._tbIntensity.Location = New System.Drawing.Point(57, 89)
            Me._tbIntensity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbIntensity.Maximum = 100
            Me._tbIntensity.Minimum = -100
            Me._tbIntensity.Name = "_tbIntensity"
            Me._tbIntensity.Size = New System.Drawing.Size(171, 27)
            Me._tbIntensity.TabIndex = 5
            Me._tbIntensity.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_tbSaturation
            '
            Me._tbSaturation.AutoSize = False
            Me._tbSaturation.Location = New System.Drawing.Point(57, 52)
            Me._tbSaturation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbSaturation.Maximum = 100
            Me._tbSaturation.Minimum = -100
            Me._tbSaturation.Name = "_tbSaturation"
            Me._tbSaturation.Size = New System.Drawing.Size(171, 27)
            Me._tbSaturation.TabIndex = 4
            Me._tbSaturation.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_tbHue
            '
            Me._tbHue.AutoSize = False
            Me._tbHue.Location = New System.Drawing.Point(57, 19)
            Me._tbHue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbHue.Maximum = 180
            Me._tbHue.Minimum = -180
            Me._tbHue.Name = "_tbHue"
            Me._tbHue.Size = New System.Drawing.Size(171, 27)
            Me._tbHue.TabIndex = 3
            Me._tbHue.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_numIntensity
            '
            Me._numIntensity.Location = New System.Drawing.Point(234, 89)
            Me._numIntensity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numIntensity.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
            Me._numIntensity.Name = "_numIntensity"
            Me._numIntensity.Size = New System.Drawing.Size(52, 20)
            Me._numIntensity.TabIndex = 2
            '
            '_numSaturation
            '
            Me._numSaturation.Location = New System.Drawing.Point(234, 54)
            Me._numSaturation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numSaturation.Minimum = New Decimal(New Integer() {100, 0, 0, -2147483648})
            Me._numSaturation.Name = "_numSaturation"
            Me._numSaturation.Size = New System.Drawing.Size(52, 20)
            Me._numSaturation.TabIndex = 1
            '
            '_numHue
            '
            Me._numHue.Location = New System.Drawing.Point(234, 19)
            Me._numHue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numHue.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
            Me._numHue.Minimum = New Decimal(New Integer() {180, 0, 0, -2147483648})
            Me._numHue.Name = "_numHue"
            Me._numHue.Size = New System.Drawing.Size(52, 20)
            Me._numHue.TabIndex = 0
            '
            '_gbOuterRange
            '
            Me._gbOuterRange.Controls.Add(Me._numOuterHigh)
            Me._gbOuterRange.Controls.Add(Me._numOuterLow)
            Me._gbOuterRange.Controls.Add(Me._tbOuterHigh)
            Me._gbOuterRange.Controls.Add(Me._tbOuterLow)
            Me._gbOuterRange.Controls.Add(Me._lblOuterHigh)
            Me._gbOuterRange.Controls.Add(Me._lblOuterLow)
            Me._gbOuterRange.Enabled = False
            Me._gbOuterRange.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbOuterRange.Location = New System.Drawing.Point(10, 189)
            Me._gbOuterRange.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOuterRange.Name = "_gbOuterRange"
            Me._gbOuterRange.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOuterRange.Size = New System.Drawing.Size(291, 96)
            Me._gbOuterRange.TabIndex = 3
            Me._gbOuterRange.TabStop = False
            Me._gbOuterRange.Text = "Outer Range"
            '
            '_numOuterHigh
            '
            Me._numOuterHigh.Location = New System.Drawing.Point(234, 58)
            Me._numOuterHigh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numOuterHigh.Maximum = New Decimal(New Integer() {359, 0, 0, 0})
            Me._numOuterHigh.Name = "_numOuterHigh"
            Me._numOuterHigh.Size = New System.Drawing.Size(52, 20)
            Me._numOuterHigh.TabIndex = 10
            '
            '_numOuterLow
            '
            Me._numOuterLow.Location = New System.Drawing.Point(234, 20)
            Me._numOuterLow.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numOuterLow.Maximum = New Decimal(New Integer() {356, 0, 0, 0})
            Me._numOuterLow.Name = "_numOuterLow"
            Me._numOuterLow.Size = New System.Drawing.Size(52, 20)
            Me._numOuterLow.TabIndex = 9
            '
            '_tbOuterHigh
            '
            Me._tbOuterHigh.AutoSize = False
            Me._tbOuterHigh.Location = New System.Drawing.Point(57, 56)
            Me._tbOuterHigh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbOuterHigh.Maximum = 359
            Me._tbOuterHigh.Name = "_tbOuterHigh"
            Me._tbOuterHigh.Size = New System.Drawing.Size(171, 27)
            Me._tbOuterHigh.TabIndex = 9
            Me._tbOuterHigh.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_tbOuterLow
            '
            Me._tbOuterLow.AutoSize = False
            Me._tbOuterLow.Location = New System.Drawing.Point(57, 16)
            Me._tbOuterLow.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbOuterLow.Maximum = 356
            Me._tbOuterLow.Name = "_tbOuterLow"
            Me._tbOuterLow.Size = New System.Drawing.Size(171, 27)
            Me._tbOuterLow.TabIndex = 9
            Me._tbOuterLow.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_lblOuterHigh
            '
            Me._lblOuterHigh.AutoSize = True
            Me._lblOuterHigh.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblOuterHigh.Location = New System.Drawing.Point(6, 63)
            Me._lblOuterHigh.Name = "_lblOuterHigh"
            Me._lblOuterHigh.Size = New System.Drawing.Size(29, 13)
            Me._lblOuterHigh.TabIndex = 1
            Me._lblOuterHigh.Text = "High"
            '
            '_lblOuterLow
            '
            Me._lblOuterLow.AutoSize = True
            Me._lblOuterLow.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblOuterLow.Location = New System.Drawing.Point(6, 25)
            Me._lblOuterLow.Name = "_lblOuterLow"
            Me._lblOuterLow.Size = New System.Drawing.Size(27, 13)
            Me._lblOuterLow.TabIndex = 0
            Me._lblOuterLow.Text = "Low"
            '
            '_gbInnerRange
            '
            Me._gbInnerRange.Controls.Add(Me._lblInnerHigh)
            Me._gbInnerRange.Controls.Add(Me._numInnerHigh)
            Me._gbInnerRange.Controls.Add(Me._lblInnerLow)
            Me._gbInnerRange.Controls.Add(Me._tbInnerLow)
            Me._gbInnerRange.Controls.Add(Me._numInnerLow)
            Me._gbInnerRange.Controls.Add(Me._tbInnerHigh)
            Me._gbInnerRange.Enabled = False
            Me._gbInnerRange.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbInnerRange.Location = New System.Drawing.Point(8, 290)
            Me._gbInnerRange.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbInnerRange.Name = "_gbInnerRange"
            Me._gbInnerRange.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbInnerRange.Size = New System.Drawing.Size(294, 88)
            Me._gbInnerRange.TabIndex = 4
            Me._gbInnerRange.TabStop = False
            Me._gbInnerRange.Text = "Inner Range"
            '
            '_lblInnerHigh
            '
            Me._lblInnerHigh.AutoSize = True
            Me._lblInnerHigh.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblInnerHigh.Location = New System.Drawing.Point(9, 62)
            Me._lblInnerHigh.Name = "_lblInnerHigh"
            Me._lblInnerHigh.Size = New System.Drawing.Size(29, 13)
            Me._lblInnerHigh.TabIndex = 12
            Me._lblInnerHigh.Text = "High"
            '
            '_numInnerHigh
            '
            Me._numInnerHigh.Location = New System.Drawing.Point(237, 60)
            Me._numInnerHigh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numInnerHigh.Maximum = New Decimal(New Integer() {358, 0, 0, 0})
            Me._numInnerHigh.Name = "_numInnerHigh"
            Me._numInnerHigh.Size = New System.Drawing.Size(52, 20)
            Me._numInnerHigh.TabIndex = 14
            '
            '_lblInnerLow
            '
            Me._lblInnerLow.AutoSize = True
            Me._lblInnerLow.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblInnerLow.Location = New System.Drawing.Point(9, 24)
            Me._lblInnerLow.Name = "_lblInnerLow"
            Me._lblInnerLow.Size = New System.Drawing.Size(27, 13)
            Me._lblInnerLow.TabIndex = 11
            Me._lblInnerLow.Text = "Low"
            '
            '_tbInnerLow
            '
            Me._tbInnerLow.AutoSize = False
            Me._tbInnerLow.Location = New System.Drawing.Point(60, 19)
            Me._tbInnerLow.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbInnerLow.Maximum = 357
            Me._tbInnerLow.Name = "_tbInnerLow"
            Me._tbInnerLow.Size = New System.Drawing.Size(171, 27)
            Me._tbInnerLow.TabIndex = 12
            Me._tbInnerLow.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_numInnerLow
            '
            Me._numInnerLow.Location = New System.Drawing.Point(237, 22)
            Me._numInnerLow.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numInnerLow.Maximum = New Decimal(New Integer() {357, 0, 0, 0})
            Me._numInnerLow.Name = "_numInnerLow"
            Me._numInnerLow.Size = New System.Drawing.Size(52, 20)
            Me._numInnerLow.TabIndex = 13
            '
            '_tbInnerHigh
            '
            Me._tbInnerHigh.AutoSize = False
            Me._tbInnerHigh.Location = New System.Drawing.Point(60, 58)
            Me._tbInnerHigh.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbInnerHigh.Maximum = 358
            Me._tbInnerHigh.Name = "_tbInnerHigh"
            Me._tbInnerHigh.Size = New System.Drawing.Size(171, 27)
            Me._tbInnerHigh.TabIndex = 11
            Me._tbInnerHigh.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(167, 397)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(72, 20)
            Me._btnCancel.TabIndex = 6
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnok
            '
            Me._btnok.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnok.Location = New System.Drawing.Point(39, 396)
            Me._btnok.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnok.Name = "_btnok"
            Me._btnok.Size = New System.Drawing.Size(72, 22)
            Me._btnok.TabIndex = 5
            Me._btnok.Text = "OK"
            Me._btnok.UseVisualStyleBackColor = True
            '
            'ChangeHueSaturationIntensityDialog
            '
            Me.AcceptButton = Me._btnok
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(312, 440)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnok)
            Me.Controls.Add(Me._gbInnerRange)
            Me.Controls.Add(Me._gbOuterRange)
            Me.Controls.Add(Me._gbSourceChannels)
            Me.Controls.Add(Me._lblMask)
            Me.Controls.Add(Me._cmbMask)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ChangeHueSaturationIntensityDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Change Hue Saturation Intensity"
            Me._gbSourceChannels.ResumeLayout(False)
            Me._gbSourceChannels.PerformLayout()
            CType(Me._tbIntensity, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbSaturation, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbHue, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numIntensity, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numSaturation, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numHue, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbOuterRange.ResumeLayout(False)
            Me._gbOuterRange.PerformLayout()
            CType(Me._numOuterHigh, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numOuterLow, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbOuterHigh, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbOuterLow, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbInnerRange.ResumeLayout(False)
            Me._gbInnerRange.PerformLayout()
            CType(Me._numInnerHigh, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbInnerLow, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numInnerLow, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbInnerHigh, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

	  #End Region

	  Private WithEvents _cmbMask As System.Windows.Forms.ComboBox
	  Private _lblMask As System.Windows.Forms.Label
	  Private _gbSourceChannels As System.Windows.Forms.GroupBox
	  Private _gbOuterRange As System.Windows.Forms.GroupBox
	  Private _gbInnerRange As System.Windows.Forms.GroupBox
	  Public WithEvents _tbIntensity As System.Windows.Forms.TrackBar
	  Public WithEvents _tbSaturation As System.Windows.Forms.TrackBar
	  Public WithEvents _tbHue As System.Windows.Forms.TrackBar
	  Private WithEvents _numIntensity As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numSaturation As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numHue As System.Windows.Forms.NumericUpDown
	  Private _lblIntensity As System.Windows.Forms.Label
	  Private _lblSaturation As System.Windows.Forms.Label
	  Private _lblHue As System.Windows.Forms.Label
	  Private WithEvents _numOuterHigh As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numOuterLow As System.Windows.Forms.NumericUpDown
	  Public WithEvents _tbOuterHigh As System.Windows.Forms.TrackBar
	  Public WithEvents _tbOuterLow As System.Windows.Forms.TrackBar
	  Private _lblOuterHigh As System.Windows.Forms.Label
	  Private _lblOuterLow As System.Windows.Forms.Label
	  Private _lblInnerHigh As System.Windows.Forms.Label
	  Private WithEvents _numInnerHigh As System.Windows.Forms.NumericUpDown
	  Private _lblInnerLow As System.Windows.Forms.Label
	  Public WithEvents _tbInnerLow As System.Windows.Forms.TrackBar
	  Private WithEvents _numInnerLow As System.Windows.Forms.NumericUpDown
	  Public WithEvents _tbInnerHigh As System.Windows.Forms.TrackBar
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnok As System.Windows.Forms.Button
   End Class
End Namespace