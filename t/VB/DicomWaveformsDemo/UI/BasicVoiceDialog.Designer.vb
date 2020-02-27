Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
	Public Partial Class BasicVoiceDialog
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BasicVoiceDialog))
			Me.txtInfo = New System.Windows.Forms.TextBox()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.btnBrowse1 = New System.Windows.Forms.Button()
			Me.txtInputFile = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.btnBrowse2 = New System.Windows.Forms.Button()
			Me.txtOutputFile = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.groupBox3 = New System.Windows.Forms.GroupBox()
			Me.btnCreate = New System.Windows.Forms.Button()
			Me.label2 = New System.Windows.Forms.Label()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.groupBox3.SuspendLayout()
			Me.SuspendLayout()
			' 
			' txtInfo
			' 
			Me.txtInfo.Location = New System.Drawing.Point(12, 12)
			Me.txtInfo.Multiline = True
			Me.txtInfo.Name = "txtInfo"
			Me.txtInfo.ReadOnly = True
			Me.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me.txtInfo.Size = New System.Drawing.Size(681, 195)
			Me.txtInfo.TabIndex = 0
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.btnBrowse1)
			Me.groupBox1.Controls.Add(Me.txtInputFile)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Location = New System.Drawing.Point(12, 226)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(681, 87)
			Me.groupBox1.TabIndex = 1
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "Step 1"
			' 
			' btnBrowse1
			' 
			Me.btnBrowse1.Location = New System.Drawing.Point(595, 52)
			Me.btnBrowse1.Name = "btnBrowse1"
			Me.btnBrowse1.Size = New System.Drawing.Size(75, 23)
			Me.btnBrowse1.TabIndex = 3
			Me.btnBrowse1.Text = "Browse..."
			Me.btnBrowse1.UseVisualStyleBackColor = True
'			Me.btnBrowse1.Click += New System.EventHandler(Me.btnBrowse1_Click);
			' 
			' txtInputFile
			' 
			Me.txtInputFile.Location = New System.Drawing.Point(11, 52)
			Me.txtInputFile.Name = "txtInputFile"
			Me.txtInputFile.Size = New System.Drawing.Size(578, 20)
			Me.txtInputFile.TabIndex = 1
			' 
			' label3
			' 
			Me.label3.Location = New System.Drawing.Point(8, 16)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(481, 33)
			Me.label3.TabIndex = 0
			Me.label3.Text = "Please select the input wave file. The audio format for the file needs to be PCM," & " mu-Law or a-Law and the sampling frequency needs to be 8KHz."
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.btnBrowse2)
			Me.groupBox2.Controls.Add(Me.txtOutputFile)
			Me.groupBox2.Controls.Add(Me.label1)
			Me.groupBox2.Location = New System.Drawing.Point(12, 319)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(681, 80)
			Me.groupBox2.TabIndex = 0
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Step 2"
			' 
			' btnBrowse2
			' 
			Me.btnBrowse2.Location = New System.Drawing.Point(595, 39)
			Me.btnBrowse2.Name = "btnBrowse2"
			Me.btnBrowse2.Size = New System.Drawing.Size(75, 23)
			Me.btnBrowse2.TabIndex = 2
			Me.btnBrowse2.Text = "Browse..."
			Me.btnBrowse2.UseVisualStyleBackColor = True
'			Me.btnBrowse2.Click += New System.EventHandler(Me.btnBrowse2_Click);
			' 
			' txtOutputFile
			' 
			Me.txtOutputFile.Location = New System.Drawing.Point(11, 41)
			Me.txtOutputFile.Name = "txtOutputFile"
			Me.txtOutputFile.Size = New System.Drawing.Size(578, 20)
			Me.txtOutputFile.TabIndex = 1
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(8, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(207, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Please select the output DICOM file name."
			' 
			' groupBox3
			' 
			Me.groupBox3.Controls.Add(Me.btnCreate)
			Me.groupBox3.Controls.Add(Me.label2)
			Me.groupBox3.Location = New System.Drawing.Point(12, 405)
			Me.groupBox3.Name = "groupBox3"
			Me.groupBox3.Size = New System.Drawing.Size(681, 68)
			Me.groupBox3.TabIndex = 0
			Me.groupBox3.TabStop = False
			Me.groupBox3.Text = "Step 3"
			' 
			' btnCreate
			' 
			Me.btnCreate.Location = New System.Drawing.Point(568, 11)
			Me.btnCreate.Name = "btnCreate"
			Me.btnCreate.Size = New System.Drawing.Size(102, 49)
			Me.btnCreate.TabIndex = 1
			Me.btnCreate.Text = "Create"
			Me.btnCreate.UseVisualStyleBackColor = True
'			Me.btnCreate.Click += New System.EventHandler(Me.btnCreate_Click);
			' 
			' label2
			' 
			Me.label2.Location = New System.Drawing.Point(8, 16)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(554, 44)
			Me.label2.TabIndex = 0
			Me.label2.Text = resources.GetString("label2.Text")
			' 
			' BasicVoiceDialog
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(705, 484)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox3)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me.txtInfo)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "BasicVoiceDialog"
			Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
			Me.Text = "Create Basic Voice Audio"
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.groupBox2.ResumeLayout(False)
			Me.groupBox2.PerformLayout()
			Me.groupBox3.ResumeLayout(False)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private txtInfo As System.Windows.Forms.TextBox
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private groupBox2 As System.Windows.Forms.GroupBox
		Private groupBox3 As System.Windows.Forms.GroupBox
		Private WithEvents btnBrowse1 As System.Windows.Forms.Button
		Private txtInputFile As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents btnBrowse2 As System.Windows.Forms.Button
		Private txtOutputFile As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents btnCreate As System.Windows.Forms.Button
		Private label2 As System.Windows.Forms.Label
	End Class
End Namespace