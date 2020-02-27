Imports Microsoft.VisualBasic
Imports System
Namespace DicomDemo
	Public Partial Class MainForm
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.btnNext = New System.Windows.Forms.Button()
			Me.btnBack = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' panel1
			' 
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
			Me.panel1.Location = New System.Drawing.Point(0, 0)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(618, 452)
			Me.panel1.TabIndex = 0
			Me.panel1.Visible = False
			' 
			' btnNext
			' 
			Me.btnNext.Location = New System.Drawing.Point(450, 467)
			Me.btnNext.Name = "btnNext"
			Me.btnNext.Size = New System.Drawing.Size(75, 23)
			Me.btnNext.TabIndex = 1
			Me.btnNext.Text = "&Next >"
			Me.btnNext.UseVisualStyleBackColor = True
'			Me.btnNext.Click += New System.EventHandler(Me.btnNext_Click);
			' 
			' btnBack
			' 
			Me.btnBack.Location = New System.Drawing.Point(369, 467)
			Me.btnBack.Name = "btnBack"
			Me.btnBack.Size = New System.Drawing.Size(75, 23)
			Me.btnBack.TabIndex = 2
			Me.btnBack.Text = "< &Back"
			Me.btnBack.UseVisualStyleBackColor = True
'			Me.btnBack.Click += New System.EventHandler(Me.btnBack_Click);
			' 
			' btnCancel
			' 
			Me.btnCancel.Location = New System.Drawing.Point(531, 467)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 3
			Me.btnCancel.Text = "&Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
'			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click);
			' 
			' label1
			' 
			Me.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.label1.Location = New System.Drawing.Point(0, 455)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(626, 2)
			Me.label1.TabIndex = 5
			' 
			' MainForm
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(618, 502)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnBack)
			Me.Controls.Add(Me.btnNext)
			Me.Controls.Add(Me.panel1)
			Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.Name = "MainForm"
			Me.Text = "MainForm"
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.MainForm_FormClosing);
'			Me.Load += New System.EventHandler(Me.MainForm_Load);
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private panel1 As System.Windows.Forms.Panel
		Public WithEvents btnNext As System.Windows.Forms.Button
		Private label1 As System.Windows.Forms.Label
		Public WithEvents btnBack As System.Windows.Forms.Button
		Private WithEvents btnCancel As System.Windows.Forms.Button
	End Class
End Namespace