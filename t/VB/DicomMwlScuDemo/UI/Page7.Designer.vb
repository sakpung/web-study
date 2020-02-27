Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
	Public Partial Class Page7
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
			Me.label6 = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel2 = New System.Windows.Forms.LinkLabel()
			Me.linkLabel3 = New System.Windows.Forms.LinkLabel()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(16, 32)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(332, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Thank you for evaluating LEADTOOLS Modality Worklist SCU demo."
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(16, 48)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(404, 13)
			Me.label2.TabIndex = 1
         Me.label2.Text = "This demo application was created with LEADTOOLS PACS Imaging toolkit. "
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(16, 112)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(363, 13)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Please contact us to learn more about LEADTOOLS products and services."
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(48, 144)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(110, 13)
			Me.label4.TabIndex = 3
			Me.label4.Text = "Phone: 704-332-5532"
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(16, 222)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(552, 13)
			Me.label6.TabIndex = 5
         Me.label6.Text = "In order to compile the project, please use LEADTOOLS PACS Imaging toolk" & "it or download a free evaluation"
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(16, 238)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(142, 13)
			Me.label7.TabIndex = 6
			Me.label7.Text = "toolkit from the following link:"
			' 
			' linkLabel1
			' 
			Me.linkLabel1.AutoSize = True
			Me.linkLabel1.Location = New System.Drawing.Point(48, 160)
			Me.linkLabel1.Name = "linkLabel1"
			Me.linkLabel1.Size = New System.Drawing.Size(135, 13)
			Me.linkLabel1.TabIndex = 9
			Me.linkLabel1.TabStop = True
			Me.linkLabel1.Text = "https://www.leadtools.com/"
'			Me.linkLabel1.LinkClicked += New System.Windows.Forms.LinkLabelLinkClickedEventHandler(Me.linkLabels_LinkClicked);
			' 
			' linkLabel2
			' 
			Me.linkLabel2.AutoSize = True
			Me.linkLabel2.Location = New System.Drawing.Point(48, 270)
			Me.linkLabel2.Name = "linkLabel2"
			Me.linkLabel2.Size = New System.Drawing.Size(315, 13)
			Me.linkLabel2.TabIndex = 10
			Me.linkLabel2.TabStop = True
			Me.linkLabel2.Text = "https://www.leadtools.com/SDK/Medical/Medical-Products-n.htm"
'			Me.linkLabel2.LinkClicked += New System.Windows.Forms.LinkLabelLinkClickedEventHandler(Me.linkLabels_LinkClicked);
			' 
			' linkLabel3
			' 
			Me.linkLabel3.AutoSize = True
			Me.linkLabel3.Location = New System.Drawing.Point(48, 286)
			Me.linkLabel3.Name = "linkLabel3"
			Me.linkLabel3.Size = New System.Drawing.Size(328, 13)
			Me.linkLabel3.TabIndex = 11
			Me.linkLabel3.TabStop = True
         Me.linkLabel3.Text = "https://www.leadtools.com/SDK/Medical/Pacs-Imaging.htm"
'			Me.linkLabel3.LinkClicked += New System.Windows.Forms.LinkLabelLinkClickedEventHandler(Me.linkLabels_LinkClicked);
			' 
			' Page7
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.Controls.Add(Me.linkLabel3)
			Me.Controls.Add(Me.linkLabel2)
			Me.Controls.Add(Me.linkLabel1)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "Page7"
			Me.Size = New System.Drawing.Size(618, 452)
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
		Private WithEvents linkLabel2 As System.Windows.Forms.LinkLabel
		Private WithEvents linkLabel3 As System.Windows.Forms.LinkLabel
	End Class
End Namespace
