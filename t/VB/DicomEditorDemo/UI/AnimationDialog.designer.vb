Imports Microsoft.VisualBasic
Imports System
Namespace DicomEditorDemo
   Partial Public Class AnimationDialog
	  ''' <summary>
	  ''' Required designer variable.
	  ''' </summary>
	  Private components As System.ComponentModel.IContainer = Nothing

	  ''' <summary>
	  ''' Clean up any resources being used.
	  ''' </summary>
	  ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
		 Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AnimationDialog))
		 Me.groupBox1 = New System.Windows.Forms.GroupBox()
		 Me._chkForward = New System.Windows.Forms.CheckBox()
		 Me._chkStop = New System.Windows.Forms.CheckBox()
		 Me._chkBackward = New System.Windows.Forms.CheckBox()
		 Me.label2 = New System.Windows.Forms.Label()
		 Me.label1 = New System.Windows.Forms.Label()
		 Me._tbSpeed = New System.Windows.Forms.TrackBar()
		 Me._btnAdvance = New System.Windows.Forms.Button()
		 Me._grpExtendedParameters = New System.Windows.Forms.GroupBox()
		 Me._chkShowAnnotation = New System.Windows.Forms.CheckBox()
		 Me._chkShowRegion = New System.Windows.Forms.CheckBox()
		 Me._chkAnimateAllSubCells = New System.Windows.Forms.CheckBox()
		 Me._cmbInterpolation = New System.Windows.Forms.ComboBox()
		 Me.label4 = New System.Windows.Forms.Label()
		 Me._radShuffle = New System.Windows.Forms.RadioButton()
		 Me._radLoop = New System.Windows.Forms.RadioButton()
		 Me.label3 = New System.Windows.Forms.Label()
		 Me.groupBox3 = New System.Windows.Forms.GroupBox()
		 Me._chkToEnd = New System.Windows.Forms.CheckBox()
		 Me.label8 = New System.Windows.Forms.Label()
		 Me.label7 = New System.Windows.Forms.Label()
		 Me.label6 = New System.Windows.Forms.Label()
		 Me.label5 = New System.Windows.Forms.Label()
		 Me._cmbFrames = New System.Windows.Forms.ComboBox()
		 Me._btnHidden = New System.Windows.Forms.Button()
		 Me._txtTo = New NumericTextBox()
		 Me._txtFrom = New NumericTextBox()
		 Me._txtFrames = New NumericTextBox()
		 Me.groupBox1.SuspendLayout()
		 CType(Me._tbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
		 Me._grpExtendedParameters.SuspendLayout()
		 Me.groupBox3.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' groupBox1
		 ' 
		 Me.groupBox1.Controls.Add(Me._chkForward)
		 Me.groupBox1.Controls.Add(Me._chkStop)
		 Me.groupBox1.Controls.Add(Me._chkBackward)
		 Me.groupBox1.Controls.Add(Me.label2)
		 Me.groupBox1.Controls.Add(Me.label1)
		 Me.groupBox1.Controls.Add(Me._tbSpeed)
		 Me.groupBox1.Location = New System.Drawing.Point(8, 4)
		 Me.groupBox1.Name = "groupBox1"
		 Me.groupBox1.Size = New System.Drawing.Size(251, 135)
		 Me.groupBox1.TabIndex = 0
		 Me.groupBox1.TabStop = False
		 Me.groupBox1.Text = "&General"
		 ' 
		 ' _chkForward
		 ' 
		 Me._chkForward.Appearance = System.Windows.Forms.Appearance.Button
		 Me._chkForward.AutoCheck = False
		 Me._chkForward.Image = (CType(resources.GetObject("_chkForward.Image"), System.Drawing.Image))
		 Me._chkForward.Location = New System.Drawing.Point(158, 81)
		 Me._chkForward.Name = "_chkForward"
		 Me._chkForward.Size = New System.Drawing.Size(51, 37)
		 Me._chkForward.TabIndex = 5
		 Me._chkForward.UseVisualStyleBackColor = True
'		 Me._chkForward.Click += New System.EventHandler(Me._chkForward_Click);
		 ' 
		 ' _chkStop
		 ' 
		 Me._chkStop.Appearance = System.Windows.Forms.Appearance.Button
		 Me._chkStop.AutoCheck = False
		 Me._chkStop.Image = (CType(resources.GetObject("_chkStop.Image"), System.Drawing.Image))
		 Me._chkStop.Location = New System.Drawing.Point(102, 81)
		 Me._chkStop.Name = "_chkStop"
		 Me._chkStop.Size = New System.Drawing.Size(51, 37)
		 Me._chkStop.TabIndex = 4
		 Me._chkStop.UseVisualStyleBackColor = True
'		 Me._chkStop.Click += New System.EventHandler(Me._chkStop_Click);
		 ' 
		 ' _chkBackward
		 ' 
		 Me._chkBackward.Appearance = System.Windows.Forms.Appearance.Button
		 Me._chkBackward.AutoCheck = False
		 Me._chkBackward.Image = (CType(resources.GetObject("_chkBackward.Image"), System.Drawing.Image))
		 Me._chkBackward.Location = New System.Drawing.Point(46, 81)
		 Me._chkBackward.Name = "_chkBackward"
		 Me._chkBackward.Size = New System.Drawing.Size(51, 37)
		 Me._chkBackward.TabIndex = 3
		 Me._chkBackward.UseVisualStyleBackColor = True
'		 Me._chkBackward.Click += New System.EventHandler(Me._chkBackward_Click);
		 ' 
		 ' label2
		 ' 
		 Me.label2.AutoSize = True
		 Me.label2.Location = New System.Drawing.Point(207, 39)
		 Me.label2.Name = "label2"
		 Me.label2.Size = New System.Drawing.Size(27, 13)
		 Me.label2.TabIndex = 2
		 Me.label2.Text = "Fast"
		 ' 
		 ' label1
		 ' 
		 Me.label1.AutoSize = True
		 Me.label1.Location = New System.Drawing.Point(16, 40)
		 Me.label1.Name = "label1"
		 Me.label1.Size = New System.Drawing.Size(30, 13)
		 Me.label1.TabIndex = 1
		 Me.label1.Text = "Slow"
		 ' 
		 ' _tbSpeed
		 ' 
		 Me._tbSpeed.AutoSize = False
		 Me._tbSpeed.Location = New System.Drawing.Point(49, 25)
		 Me._tbSpeed.Maximum = 300
		 Me._tbSpeed.Minimum = 1
		 Me._tbSpeed.Name = "_tbSpeed"
		 Me._tbSpeed.Size = New System.Drawing.Size(155, 39)
		 Me._tbSpeed.TabIndex = 0
		 Me._tbSpeed.TickFrequency = 0
		 Me._tbSpeed.TickStyle = System.Windows.Forms.TickStyle.Both
		 Me._tbSpeed.Value = 150
'		 Me._tbSpeed.Scroll += New System.EventHandler(Me._tbSpeed_Scroll);
		 ' 
		 ' _btnAdvance
		 ' 
		 Me._btnAdvance.Location = New System.Drawing.Point(186, 145)
		 Me._btnAdvance.Name = "_btnAdvance"
		 Me._btnAdvance.Size = New System.Drawing.Size(73, 29)
		 Me._btnAdvance.TabIndex = 1
		 Me._btnAdvance.Text = "Ad&vance >>"
		 Me._btnAdvance.UseVisualStyleBackColor = True
'		 Me._btnAdvance.Click += New System.EventHandler(Me._btnAdvance_Click);
		 ' 
		 ' _grpExtendedParameters
		 ' 
		 Me._grpExtendedParameters.Controls.Add(Me._chkShowAnnotation)
		 Me._grpExtendedParameters.Controls.Add(Me._chkShowRegion)
		 Me._grpExtendedParameters.Controls.Add(Me._chkAnimateAllSubCells)
		 Me._grpExtendedParameters.Controls.Add(Me._cmbInterpolation)
		 Me._grpExtendedParameters.Controls.Add(Me.label4)
		 Me._grpExtendedParameters.Controls.Add(Me._radShuffle)
		 Me._grpExtendedParameters.Controls.Add(Me._radLoop)
		 Me._grpExtendedParameters.Controls.Add(Me.label3)
		 Me._grpExtendedParameters.Location = New System.Drawing.Point(10, 174)
		 Me._grpExtendedParameters.Name = "_grpExtendedParameters"
		 Me._grpExtendedParameters.Size = New System.Drawing.Size(248, 143)
		 Me._grpExtendedParameters.TabIndex = 2
		 Me._grpExtendedParameters.TabStop = False
		 Me._grpExtendedParameters.Text = "&Extended Parameters"
		 ' 
		 ' _chkShowAnnotation
		 ' 
		 Me._chkShowAnnotation.AutoSize = True
		 Me._chkShowAnnotation.Location = New System.Drawing.Point(27, 122)
		 Me._chkShowAnnotation.Name = "_chkShowAnnotation"
		 Me._chkShowAnnotation.Size = New System.Drawing.Size(107, 17)
		 Me._chkShowAnnotation.TabIndex = 7
		 Me._chkShowAnnotation.Text = "Show A&nnotation"
		 Me._chkShowAnnotation.UseVisualStyleBackColor = True
'		 Me._chkShowAnnotation.CheckedChanged += New System.EventHandler(Me._chkShowAnnotation_CheckedChanged);
		 ' 
		 ' _chkShowRegion
		 ' 
		 Me._chkShowRegion.AutoSize = True
		 Me._chkShowRegion.Location = New System.Drawing.Point(27, 101)
		 Me._chkShowRegion.Name = "_chkShowRegion"
		 Me._chkShowRegion.Size = New System.Drawing.Size(90, 17)
		 Me._chkShowRegion.TabIndex = 6
		 Me._chkShowRegion.Text = "&Show Region"
		 Me._chkShowRegion.UseVisualStyleBackColor = True
'		 Me._chkShowRegion.CheckedChanged += New System.EventHandler(Me._chkShowRegion_CheckedChanged);
		 ' 
		 ' _chkAnimateAllSubCells
		 ' 
		 Me._chkAnimateAllSubCells.AutoSize = True
		 Me._chkAnimateAllSubCells.Location = New System.Drawing.Point(27, 81)
		 Me._chkAnimateAllSubCells.Name = "_chkAnimateAllSubCells"
		 Me._chkAnimateAllSubCells.Size = New System.Drawing.Size(122, 17)
		 Me._chkAnimateAllSubCells.TabIndex = 5
		 Me._chkAnimateAllSubCells.Text = "&Animate All sub-cells"
		 Me._chkAnimateAllSubCells.UseVisualStyleBackColor = True
'		 Me._chkAnimateAllSubCells.CheckedChanged += New System.EventHandler(Me._chkAnimateAllSubCells_CheckedChanged);
		 ' 
		 ' _cmbInterpolation
		 ' 
		 Me._cmbInterpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbInterpolation.FormattingEnabled = True
		 Me._cmbInterpolation.Items.AddRange(New Object() { "Normal", "Resample", "Bicubic"})
		 Me._cmbInterpolation.Location = New System.Drawing.Point(99, 49)
		 Me._cmbInterpolation.Name = "_cmbInterpolation"
		 Me._cmbInterpolation.Size = New System.Drawing.Size(105, 21)
		 Me._cmbInterpolation.TabIndex = 4
'		 Me._cmbInterpolation.SelectedIndexChanged += New System.EventHandler(Me._cmbInterpolation_SelectedIndexChanged);
		 ' 
		 ' label4
		 ' 
		 Me.label4.AutoSize = True
		 Me.label4.Location = New System.Drawing.Point(26, 53)
		 Me.label4.Name = "label4"
		 Me.label4.Size = New System.Drawing.Size(65, 13)
		 Me.label4.TabIndex = 3
		 Me.label4.Text = "&Interpolation"
		 ' 
		 ' _radShuffle
		 ' 
		 Me._radShuffle.AutoSize = True
		 Me._radShuffle.Location = New System.Drawing.Point(156, 22)
		 Me._radShuffle.Name = "_radShuffle"
		 Me._radShuffle.Size = New System.Drawing.Size(58, 17)
		 Me._radShuffle.TabIndex = 2
		 Me._radShuffle.Text = "&Shuffle"
		 Me._radShuffle.UseVisualStyleBackColor = True
'		 Me._radShuffle.CheckedChanged += New System.EventHandler(Me._radShuffle_CheckedChanged);
		 ' 
		 ' _radLoop
		 ' 
		 Me._radLoop.AutoSize = True
		 Me._radLoop.Checked = True
		 Me._radLoop.Location = New System.Drawing.Point(100, 22)
		 Me._radLoop.Name = "_radLoop"
		 Me._radLoop.Size = New System.Drawing.Size(49, 17)
		 Me._radLoop.TabIndex = 1
		 Me._radLoop.TabStop = True
		 Me._radLoop.Text = "&Loop"
		 Me._radLoop.UseVisualStyleBackColor = True
		 ' 
		 ' label3
		 ' 
		 Me.label3.AutoSize = True
		 Me.label3.Location = New System.Drawing.Point(26, 24)
		 Me.label3.Name = "label3"
		 Me.label3.Size = New System.Drawing.Size(57, 13)
		 Me.label3.TabIndex = 0
		 Me.label3.Text = "&Play Mode"
		 ' 
		 ' groupBox3
		 ' 
		 Me.groupBox3.Controls.Add(Me._chkToEnd)
		 Me.groupBox3.Controls.Add(Me.label8)
		 Me.groupBox3.Controls.Add(Me.label7)
		 Me.groupBox3.Controls.Add(Me._txtTo)
		 Me.groupBox3.Controls.Add(Me._txtFrom)
		 Me.groupBox3.Controls.Add(Me.label6)
		 Me.groupBox3.Controls.Add(Me._txtFrames)
		 Me.groupBox3.Controls.Add(Me.label5)
		 Me.groupBox3.Controls.Add(Me._cmbFrames)
		 Me.groupBox3.Location = New System.Drawing.Point(10, 319)
		 Me.groupBox3.Name = "groupBox3"
		 Me.groupBox3.Size = New System.Drawing.Size(247, 79)
		 Me.groupBox3.TabIndex = 3
		 Me.groupBox3.TabStop = False
		 Me.groupBox3.Text = "&Frames"
		 ' 
		 ' _chkToEnd
		 ' 
		 Me._chkToEnd.AutoSize = True
		 Me._chkToEnd.Checked = True
		 Me._chkToEnd.CheckState = System.Windows.Forms.CheckState.Checked
		 Me._chkToEnd.Location = New System.Drawing.Point(180, 53)
		 Me._chkToEnd.Name = "_chkToEnd"
		 Me._chkToEnd.Size = New System.Drawing.Size(61, 17)
		 Me._chkToEnd.TabIndex = 8
		 Me._chkToEnd.Text = "To &End"
		 Me._chkToEnd.UseVisualStyleBackColor = True
'		 Me._chkToEnd.CheckedChanged += New System.EventHandler(Me._chkToEnd_CheckedChanged);
		 ' 
		 ' label8
		 ' 
		 Me.label8.AutoSize = True
		 Me.label8.Location = New System.Drawing.Point(96, 53)
		 Me.label8.Name = "label8"
		 Me.label8.Size = New System.Drawing.Size(20, 13)
		 Me.label8.TabIndex = 7
		 Me.label8.Text = "&To"
		 ' 
		 ' label7
		 ' 
		 Me.label7.AutoSize = True
		 Me.label7.Location = New System.Drawing.Point(12, 53)
		 Me.label7.Name = "label7"
		 Me.label7.Size = New System.Drawing.Size(30, 13)
		 Me.label7.TabIndex = 6
		 Me.label7.Text = "Fr&om"
		 ' 
		 ' label6
		 ' 
		 Me.label6.AutoSize = True
		 Me.label6.Location = New System.Drawing.Point(200, 21)
		 Me.label6.Name = "label6"
		 Me.label6.Size = New System.Drawing.Size(41, 13)
		 Me.label6.TabIndex = 3
		 Me.label6.Text = "F&rames"
		 ' 
		 ' label5
		 ' 
		 Me.label5.AutoSize = True
		 Me.label5.Location = New System.Drawing.Point(10, 21)
		 Me.label5.Name = "label5"
		 Me.label5.Size = New System.Drawing.Size(41, 13)
		 Me.label5.TabIndex = 1
		 Me.label5.Text = "&Frames"
		 ' 
		 ' _cmbFrames
		 ' 
		 Me._cmbFrames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		 Me._cmbFrames.FormattingEnabled = True
		 Me._cmbFrames.Items.AddRange(New Object() { "All Frames", "Odd Frames", "Even Frames", "Jump every"})
		 Me._cmbFrames.Location = New System.Drawing.Point(57, 18)
		 Me._cmbFrames.Name = "_cmbFrames"
		 Me._cmbFrames.Size = New System.Drawing.Size(92, 21)
		 Me._cmbFrames.TabIndex = 0
'		 Me._cmbFrames.SelectedIndexChanged += New System.EventHandler(Me._cmbFrames_SelectedIndexChanged);
		 ' 
		 ' _btnHidden
		 ' 
		 Me._btnHidden.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnHidden.Location = New System.Drawing.Point(1000, 391)
		 Me._btnHidden.Name = "_btnHidden"
		 Me._btnHidden.Size = New System.Drawing.Size(19, 8)
		 Me._btnHidden.TabIndex = 4
		 Me._btnHidden.UseVisualStyleBackColor = True
'		 Me._btnHidden.Click += New System.EventHandler(Me._btnHidden_Click);
		 ' 
		 ' _txtTo
		 ' 
		 Me._txtTo.Enabled = False
		 Me._txtTo.Location = New System.Drawing.Point(118, 50)
		 Me._txtTo.MaximumAllowed = 1000
		 Me._txtTo.MinimumAllowed = 1
		 Me._txtTo.Name = "_txtTo"
		 Me._txtTo.Size = New System.Drawing.Size(42, 20)
		 Me._txtTo.TabIndex = 5
		 Me._txtTo.Text = "0"
		 Me._txtTo.Value = 0
'		 Me._txtTo.TextChanged += New System.EventHandler(Me._txtTo_TextChanged);
		 ' 
		 ' _txtFrom
		 ' 
		 Me._txtFrom.Location = New System.Drawing.Point(43, 50)
		 Me._txtFrom.MaximumAllowed = 1000
		 Me._txtFrom.MinimumAllowed = 1
		 Me._txtFrom.Name = "_txtFrom"
		 Me._txtFrom.Size = New System.Drawing.Size(42, 20)
		 Me._txtFrom.TabIndex = 4
		 Me._txtFrom.Text = "0"
		 Me._txtFrom.Value = 0
'		 Me._txtFrom.TextChanged += New System.EventHandler(Me._txtFrom_TextChanged);
		 ' 
		 ' _txtFrames
		 ' 
		 Me._txtFrames.Location = New System.Drawing.Point(155, 18)
		 Me._txtFrames.MaximumAllowed = 1000
		 Me._txtFrames.MinimumAllowed = 1
		 Me._txtFrames.Name = "_txtFrames"
		 Me._txtFrames.Size = New System.Drawing.Size(40, 20)
		 Me._txtFrames.TabIndex = 2
		 Me._txtFrames.Text = "3"
		 Me._txtFrames.Value = 3
'		 Me._txtFrames.TextChanged += New System.EventHandler(Me._txtFrames_TextChanged);
		 ' 
		 ' AnimationDialog
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(266, 406)
		 Me.Controls.Add(Me._btnHidden)
		 Me.Controls.Add(Me.groupBox3)
		 Me.Controls.Add(Me._grpExtendedParameters)
		 Me.Controls.Add(Me._btnAdvance)
		 Me.Controls.Add(Me.groupBox1)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "AnimationDialog"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Animation Dialog"
		 Me.groupBox1.ResumeLayout(False)
		 Me.groupBox1.PerformLayout()
		 CType(Me._tbSpeed, System.ComponentModel.ISupportInitialize).EndInit()
		 Me._grpExtendedParameters.ResumeLayout(False)
		 Me._grpExtendedParameters.PerformLayout()
		 Me.groupBox3.ResumeLayout(False)
		 Me.groupBox3.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private WithEvents _btnAdvance As System.Windows.Forms.Button
	  Private _grpExtendedParameters As System.Windows.Forms.GroupBox
	  Private groupBox3 As System.Windows.Forms.GroupBox
	  Private label1 As System.Windows.Forms.Label
	  Private WithEvents _tbSpeed As System.Windows.Forms.TrackBar
	  Private WithEvents _chkForward As System.Windows.Forms.CheckBox
	  Private WithEvents _chkStop As System.Windows.Forms.CheckBox
	  Private WithEvents _chkBackward As System.Windows.Forms.CheckBox
	  Private label2 As System.Windows.Forms.Label
	  Private WithEvents _cmbInterpolation As System.Windows.Forms.ComboBox
	  Private label4 As System.Windows.Forms.Label
	  Private WithEvents _radShuffle As System.Windows.Forms.RadioButton
	  Private _radLoop As System.Windows.Forms.RadioButton
	  Private label3 As System.Windows.Forms.Label
	  Private WithEvents _chkAnimateAllSubCells As System.Windows.Forms.CheckBox
	  Private WithEvents _chkShowAnnotation As System.Windows.Forms.CheckBox
	  Private WithEvents _chkShowRegion As System.Windows.Forms.CheckBox
	  Private label8 As System.Windows.Forms.Label
	  Private label7 As System.Windows.Forms.Label
	  Private WithEvents _txtTo As NumericTextBox
	  Private WithEvents _txtFrom As NumericTextBox
	  Private label6 As System.Windows.Forms.Label
	  Private WithEvents _txtFrames As NumericTextBox
	  Private label5 As System.Windows.Forms.Label
	  Private WithEvents _cmbFrames As System.Windows.Forms.ComboBox
	  Private WithEvents _chkToEnd As System.Windows.Forms.CheckBox
	  Private WithEvents _btnHidden As System.Windows.Forms.Button
   End Class
End Namespace
