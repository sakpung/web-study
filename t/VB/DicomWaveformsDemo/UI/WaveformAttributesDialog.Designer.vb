Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
	Public Partial Class WaveformAttributesDialog
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
			Me.txtWaveformPaddingValue = New System.Windows.Forms.TextBox()
			Me.txtSampleInterpretation = New System.Windows.Forms.TextBox()
			Me.txtNumberOfWaveformSamples = New System.Windows.Forms.TextBox()
			Me.txtWaveformBitsAllocated = New System.Windows.Forms.TextBox()
			Me.label6 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.txtNumberOfChannels = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.txtSamplingFrequency = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.lvChannelAttributes = New System.Windows.Forms.ListView()
			Me.btnClose = New System.Windows.Forms.Button()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.txtWaveformPaddingValue)
			Me.groupBox1.Controls.Add(Me.txtSampleInterpretation)
			Me.groupBox1.Controls.Add(Me.txtNumberOfWaveformSamples)
			Me.groupBox1.Controls.Add(Me.txtWaveformBitsAllocated)
			Me.groupBox1.Controls.Add(Me.label6)
			Me.groupBox1.Controls.Add(Me.label5)
			Me.groupBox1.Controls.Add(Me.txtNumberOfChannels)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Controls.Add(Me.txtSamplingFrequency)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.label4)
			Me.groupBox1.Location = New System.Drawing.Point(12, 12)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(726, 77)
			Me.groupBox1.TabIndex = 0
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Waveform Attributes"
			' 
			' txtWaveformPaddingValue
			' 
			Me.txtWaveformPaddingValue.Location = New System.Drawing.Point(643, 45)
			Me.txtWaveformPaddingValue.Name = "txtWaveformPaddingValue"
			Me.txtWaveformPaddingValue.ReadOnly = True
			Me.txtWaveformPaddingValue.Size = New System.Drawing.Size(74, 20)
			Me.txtWaveformPaddingValue.TabIndex = 11
			' 
			' txtSampleInterpretation
			' 
			Me.txtSampleInterpretation.Location = New System.Drawing.Point(119, 45)
			Me.txtSampleInterpretation.Name = "txtSampleInterpretation"
			Me.txtSampleInterpretation.ReadOnly = True
			Me.txtSampleInterpretation.Size = New System.Drawing.Size(152, 20)
			Me.txtSampleInterpretation.TabIndex = 7
			' 
			' txtNumberOfWaveformSamples
			' 
			Me.txtNumberOfWaveformSamples.Location = New System.Drawing.Point(643, 19)
			Me.txtNumberOfWaveformSamples.Name = "txtNumberOfWaveformSamples"
			Me.txtNumberOfWaveformSamples.ReadOnly = True
			Me.txtNumberOfWaveformSamples.Size = New System.Drawing.Size(74, 20)
			Me.txtNumberOfWaveformSamples.TabIndex = 10
			' 
			' txtWaveformBitsAllocated
			' 
			Me.txtWaveformBitsAllocated.Location = New System.Drawing.Point(406, 45)
			Me.txtWaveformBitsAllocated.Name = "txtWaveformBitsAllocated"
			Me.txtWaveformBitsAllocated.ReadOnly = True
			Me.txtWaveformBitsAllocated.Size = New System.Drawing.Size(74, 20)
			Me.txtWaveformBitsAllocated.TabIndex = 9
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(486, 48)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(128, 13)
			Me.label6.TabIndex = 5
			Me.label6.Text = "Waveform Padding Value"
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(486, 22)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(151, 13)
			Me.label5.TabIndex = 4
			Me.label5.Text = "Number of Waveform Samples"
			' 
			' txtNumberOfChannels
			' 
			Me.txtNumberOfChannels.Location = New System.Drawing.Point(119, 19)
			Me.txtNumberOfChannels.Name = "txtNumberOfChannels"
			Me.txtNumberOfChannels.ReadOnly = True
			Me.txtNumberOfChannels.Size = New System.Drawing.Size(152, 20)
			Me.txtNumberOfChannels.TabIndex = 6
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(6, 48)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(107, 13)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Sample Interpretation"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(6, 22)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(103, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Number of Channels"
			' 
			' txtSamplingFrequency
			' 
			Me.txtSamplingFrequency.Location = New System.Drawing.Point(406, 19)
			Me.txtSamplingFrequency.Name = "txtSamplingFrequency"
			Me.txtSamplingFrequency.ReadOnly = True
			Me.txtSamplingFrequency.Size = New System.Drawing.Size(74, 20)
			Me.txtSamplingFrequency.TabIndex = 8
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(277, 22)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(103, 13)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Sampling Frequency"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(277, 48)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(123, 13)
			Me.label4.TabIndex = 3
			Me.label4.Text = "Waveform Bits Allocated"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.lvChannelAttributes)
			Me.groupBox2.Location = New System.Drawing.Point(12, 95)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(726, 230)
			Me.groupBox2.TabIndex = 0
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Channel Attributes"
			' 
			' lvChannelAttributes
			' 
			Me.lvChannelAttributes.Location = New System.Drawing.Point(9, 19)
			Me.lvChannelAttributes.Name = "lvChannelAttributes"
			Me.lvChannelAttributes.Size = New System.Drawing.Size(708, 205)
			Me.lvChannelAttributes.TabIndex = 0
			Me.lvChannelAttributes.UseCompatibleStateImageBehavior = False
			Me.lvChannelAttributes.View = System.Windows.Forms.View.Details
			' 
			' btnClose
			' 
			Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnClose.Location = New System.Drawing.Point(340, 331)
			Me.btnClose.Name = "btnClose"
			Me.btnClose.Size = New System.Drawing.Size(76, 23)
			Me.btnClose.TabIndex = 1
			Me.btnClose.Text = "Close"
			Me.btnClose.UseVisualStyleBackColor = True
			' 
			' WaveformAttributesDialog
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me.btnClose
			Me.ClientSize = New System.Drawing.Size(750, 365)
			Me.Controls.Add(Me.btnClose)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "WaveformAttributesDialog"
			Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
			Me.Text = "Waveform Info"
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private groupBox1 As System.Windows.Forms.GroupBox
		Private txtWaveformPaddingValue As System.Windows.Forms.TextBox
		Private txtNumberOfWaveformSamples As System.Windows.Forms.TextBox
		Private txtWaveformBitsAllocated As System.Windows.Forms.TextBox
		Private txtSamplingFrequency As System.Windows.Forms.TextBox
		Private txtSampleInterpretation As System.Windows.Forms.TextBox
		Private txtNumberOfChannels As System.Windows.Forms.TextBox
		Private label6 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private groupBox2 As System.Windows.Forms.GroupBox
		Private btnClose As System.Windows.Forms.Button
		Private lvChannelAttributes As System.Windows.Forms.ListView
	End Class
End Namespace