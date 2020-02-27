Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
	Public Partial Class PlayBasicVoiceDialog
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
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.btnStop = New System.Windows.Forms.Button()
			Me.btnPlay = New System.Windows.Forms.Button()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.btnBrowse = New System.Windows.Forms.Button()
			Me.txtBasicVoiceInputFile = New System.Windows.Forms.TextBox()
			Me.groupBox2.SuspendLayout()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.btnStop)
			Me.groupBox2.Controls.Add(Me.btnPlay)
			Me.groupBox2.Location = New System.Drawing.Point(486, 12)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(100, 85)
			Me.groupBox2.TabIndex = 0
			Me.groupBox2.TabStop = False
			' 
			' btnStop
			' 
			Me.btnStop.Location = New System.Drawing.Point(13, 48)
			Me.btnStop.Name = "btnStop"
			Me.btnStop.Size = New System.Drawing.Size(74, 23)
			Me.btnStop.TabIndex = 1
			Me.btnStop.Text = "Stop"
			Me.btnStop.UseVisualStyleBackColor = True
'			Me.btnStop.Click += New System.EventHandler(Me.btnStop_Click);
			' 
			' btnPlay
			' 
			Me.btnPlay.Location = New System.Drawing.Point(13, 19)
			Me.btnPlay.Name = "btnPlay"
			Me.btnPlay.Size = New System.Drawing.Size(74, 23)
			Me.btnPlay.TabIndex = 0
			Me.btnPlay.Text = "Play"
			Me.btnPlay.UseVisualStyleBackColor = True
'			Me.btnPlay.Click += New System.EventHandler(Me.btnPlay_Click);
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.btnBrowse)
			Me.groupBox1.Controls.Add(Me.txtBasicVoiceInputFile)
			Me.groupBox1.Location = New System.Drawing.Point(12, 12)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(468, 85)
			Me.groupBox1.TabIndex = 1
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "DICOM Basic Voice Audio File Name:"
			' 
			' btnBrowse
			' 
			Me.btnBrowse.Location = New System.Drawing.Point(380, 34)
			Me.btnBrowse.Name = "btnBrowse"
			Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
			Me.btnBrowse.TabIndex = 1
			Me.btnBrowse.Text = "Browse..."
			Me.btnBrowse.UseVisualStyleBackColor = True
'			Me.btnBrowse.Click += New System.EventHandler(Me.btnBrowse_Click);
			' 
			' txtBasicVoiceInputFile
			' 
			Me.txtBasicVoiceInputFile.Location = New System.Drawing.Point(13, 37)
			Me.txtBasicVoiceInputFile.Name = "txtBasicVoiceInputFile"
			Me.txtBasicVoiceInputFile.Size = New System.Drawing.Size(361, 20)
			Me.txtBasicVoiceInputFile.TabIndex = 0
			' 
			' PlayBasicVoiceDialog
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(598, 110)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.groupBox2)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "PlayBasicVoiceDialog"
			Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
			Me.Text = "Play Basic Voice Audio"
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private groupBox2 As System.Windows.Forms.GroupBox
		Private WithEvents btnStop As System.Windows.Forms.Button
		Private WithEvents btnPlay As System.Windows.Forms.Button
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private WithEvents btnBrowse As System.Windows.Forms.Button
		Private txtBasicVoiceInputFile As System.Windows.Forms.TextBox
	End Class
End Namespace