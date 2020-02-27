Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
	Public Partial Class Page0
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.label9 = New System.Windows.Forms.Label()
			Me.label10 = New System.Windows.Forms.Label()
			Me.label11 = New System.Windows.Forms.Label()
			Me.label12 = New System.Windows.Forms.Label()
			Me.txtTimeout = New System.Windows.Forms.TextBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(16, 16)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(297, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Set the maximum value for communcations timeout (seconds)."
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(48, 48)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(332, 13)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Thank you for evaluating LEADTOOLS Modality Worklist SCU demo."
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(48, 80)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(404, 13)
			Me.label3.TabIndex = 2
         Me.label3.Text = "This demo application was created with LEADTOOLS PACS Imaging toolkit. "
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(48, 112)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(554, 13)
			Me.label4.TabIndex = 3
			Me.label4.Text = "This is a generic Modality Worklist SCU example that will query a MWL SCP for a w" & "orklist and copy most of the data "
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(48, 128)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(280, 13)
			Me.label5.TabIndex = 4
			Me.label5.Text = "from MWL response attributes to the requested IOD class."
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(48, 160)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(505, 13)
			Me.label6.TabIndex = 5
			Me.label6.Text = "The user is required to add proper values to certain attributes in the IOD to cre" & "ate a valid DICOM data set."
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(48, 192)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(183, 13)
			Me.label7.TabIndex = 6
			Me.label7.Text = "This demo demonstrates the steps for"
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(80, 208)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(185, 13)
			Me.label8.TabIndex = 7
			Me.label8.Text = "1) Querying a Modality Worklist server"
			' 
			' label9
			' 
			Me.label9.AutoSize = True
			Me.label9.Location = New System.Drawing.Point(80, 224)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(223, 13)
			Me.label9.TabIndex = 8
			Me.label9.Text = "2) Choosing a modality worklist item to perform"
			' 
			' label10
			' 
			Me.label10.AutoSize = True
			Me.label10.Location = New System.Drawing.Point(80, 240)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(159, 13)
			Me.label10.TabIndex = 9
			Me.label10.Text = "3) Creating the resulting data set"
			' 
			' label11
			' 
			Me.label11.AutoSize = True
			Me.label11.Location = New System.Drawing.Point(80, 256)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(244, 13)
			Me.label11.TabIndex = 10
			Me.label11.Text = "4) Storing the resulting data set to a DICOM server"
			' 
			' label12
			' 
			Me.label12.AutoSize = True
			Me.label12.Location = New System.Drawing.Point(48, 288)
			Me.label12.Name = "label12"
			Me.label12.Size = New System.Drawing.Size(212, 13)
			Me.label12.TabIndex = 11
			Me.label12.Text = "Communications timeout (15 - 120 seconds)"
			' 
			' txtTimeout
			' 
			Me.txtTimeout.Location = New System.Drawing.Point(266, 285)
			Me.txtTimeout.Name = "txtTimeout"
			Me.txtTimeout.Size = New System.Drawing.Size(57, 20)
			Me.txtTimeout.TabIndex = 14
'			Me.txtTimeout.TextChanged += New System.EventHandler(Me.txtTimeout_TextChanged);
			' 
			' Page0
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.txtTimeout)
			Me.Controls.Add(Me.label12)
			Me.Controls.Add(Me.label11)
			Me.Controls.Add(Me.label10)
			Me.Controls.Add(Me.label9)
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "Page0"
			Me.Size = New System.Drawing.Size(618, 452)
'			Me.Load += New System.EventHandler(Me.Page0_Load);
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
		Private label11 As System.Windows.Forms.Label
		Private label12 As System.Windows.Forms.Label
		Public WithEvents txtTimeout As System.Windows.Forms.TextBox
	End Class
End Namespace
