Namespace DicomDigitalSignatureDemo
	Partial Class MainForm
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(disposing As Boolean)
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label9 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label10 = New System.Windows.Forms.Label()
			Me.label12 = New System.Windows.Forms.Label()
			Me.label11 = New System.Windows.Forms.Label()
			Me.label13 = New System.Windows.Forms.Label()
			Me.label14 = New System.Windows.Forms.Label()
			Me._txBx_DataSet = New System.Windows.Forms.TextBox()
			Me._btn_Sign = New System.Windows.Forms.Button()
			Me._btn_Verify = New System.Windows.Forms.Button()
			Me._btn_Open = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(13, 13)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(131, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "This is a simple demo that:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(13, 35)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(239, 13)
			Me.label2.TabIndex = 1
			Me.label2.Text = "-- Creates Digital Signatures in the main Data Set."
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(13, 57)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(274, 13)
			Me.label3.TabIndex = 2
			Me.label3.Text = "-- Verifies all the Digital Signatures in the whole Data Set."
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(26, 129)
			Me.label6.MaximumSize = New System.Drawing.Size(419, 13)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(419, 13)
			Me.label6.TabIndex = 5
			Me.label6.Text = "you can specify the MAC Calculation Transfer Syntax UID, the MAC Algorithm, the D" & "ata"
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(13, 107)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(445, 13)
			Me.label5.TabIndex = 4
			Me.label5.Text = "-- Create Digital Signatures in the main Data Set as well as in an Item of a Sequ" & "ence of Items;"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(13, 85)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(345, 13)
			Me.label4.TabIndex = 3
			Me.label4.Text = "With the complete LEADTOOLS support for Digital Signatures, you can:"
			' 
			' label9
			' 
			Me.label9.AutoSize = True
			Me.label9.Location = New System.Drawing.Point(13, 197)
			Me.label9.Name = "label9"
			Me.label9.Size = New System.Drawing.Size(255, 13)
			Me.label9.TabIndex = 8
			Me.label9.Text = "-- Get information about a particular Digital Signature."
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(13, 175)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(436, 13)
			Me.label8.TabIndex = 7
			Me.label8.Text = "-- Verify a single Digital Signature or all the Digital Signatures in the whole D" & "ata Set at once."
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(26, 153)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(374, 13)
			Me.label7.TabIndex = 6
			Me.label7.Text = "Elements to be signed, and the Digital Signature Security Profile to conform to."
			' 
			' label10
			' 
			Me.label10.AutoSize = True
			Me.label10.Location = New System.Drawing.Point(13, 219)
			Me.label10.Name = "label10"
			Me.label10.Size = New System.Drawing.Size(440, 13)
			Me.label10.TabIndex = 9
			Me.label10.Text = "-- Enumerate the Digital Signatures in the main Data Set as well as in an Item of" & " a Sequence"
			' 
			' label12
			' 
			Me.label12.AutoSize = True
			Me.label12.Location = New System.Drawing.Point(13, 263)
			Me.label12.Name = "label12"
			Me.label12.Size = New System.Drawing.Size(259, 13)
			Me.label12.TabIndex = 11
			Me.label12.Text = "-- Search the Data Set for a specific Digital Signature."
			' 
			' label11
			' 
			Me.label11.AutoSize = True
			Me.label11.Location = New System.Drawing.Point(26, 241)
			Me.label11.Name = "label11"
			Me.label11.Size = New System.Drawing.Size(47, 13)
			Me.label11.TabIndex = 10
			Me.label11.Text = "of Items."
			' 
			' label13
			' 
			Me.label13.AutoSize = True
			Me.label13.Location = New System.Drawing.Point(13, 291)
			Me.label13.MaximumSize = New System.Drawing.Size(400, 39)
			Me.label13.Name = "label13"
			Me.label13.Size = New System.Drawing.Size(393, 39)
			Me.label13.TabIndex = 12
			Me.label13.Text = resources.GetString("label13.Text")
			' 
			' label14
			' 
			Me.label14.AutoSize = True
			Me.label14.Location = New System.Drawing.Point(13, 374)
			Me.label14.MaximumSize = New System.Drawing.Size(400, 39)
			Me.label14.Name = "label14"
			Me.label14.Size = New System.Drawing.Size(52, 13)
			Me.label14.TabIndex = 13
			Me.label14.Text = "Data Set:"
			' 
			' _txBx_DataSet
			' 
			Me._txBx_DataSet.Location = New System.Drawing.Point(72, 374)
			Me._txBx_DataSet.Name = "_txBx_DataSet"
			Me._txBx_DataSet.Size = New System.Drawing.Size(309, 20)
			Me._txBx_DataSet.TabIndex = 14
         ' 
         ' _btn_Sign
         ' 
         Me._btn_Sign.Enabled = False
			Me._btn_Sign.Location = New System.Drawing.Point(151, 426)
			Me._btn_Sign.Name = "_btn_Sign"
			Me._btn_Sign.Size = New System.Drawing.Size(75, 23)
			Me._btn_Sign.TabIndex = 15
			Me._btn_Sign.Text = "&Sign..."
         Me._btn_Sign.UseVisualStyleBackColor = True
         ' 
         ' _btn_Verify
         ' 
         Me._btn_Verify.Enabled = False
			Me._btn_Verify.Location = New System.Drawing.Point(262, 426)
			Me._btn_Verify.Name = "_btn_Verify"
			Me._btn_Verify.Size = New System.Drawing.Size(75, 23)
			Me._btn_Verify.TabIndex = 16
			Me._btn_Verify.Text = "&Verify"
			Me._btn_Verify.UseVisualStyleBackColor = True
         ' 
         ' _btn_Open
         ' 
         Me._btn_Open.Location = New System.Drawing.Point(387, 371)
			Me._btn_Open.Name = "_btn_Open"
			Me._btn_Open.Size = New System.Drawing.Size(75, 23)
			Me._btn_Open.TabIndex = 17
			Me._btn_Open.Text = "..."
			Me._btn_Open.UseVisualStyleBackColor = True
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(494, 472)
			Me.Controls.Add(Me._btn_Open)
			Me.Controls.Add(Me._btn_Verify)
			Me.Controls.Add(Me._btn_Sign)
			Me.Controls.Add(Me._txBx_DataSet)
			Me.Controls.Add(Me.label14)
			Me.Controls.Add(Me.label13)
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
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Name = "MainForm"
			Me.Text = "DICOM Digital Signatures Demo"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label6 As System.Windows.Forms.Label
		Private label5 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
		Private label9 As System.Windows.Forms.Label
		Private label8 As System.Windows.Forms.Label
		Private label7 As System.Windows.Forms.Label
		Private label10 As System.Windows.Forms.Label
		Private label12 As System.Windows.Forms.Label
		Private label11 As System.Windows.Forms.Label
		Private label13 As System.Windows.Forms.Label
		Private label14 As System.Windows.Forms.Label
      Private WithEvents _txBx_DataSet As System.Windows.Forms.TextBox
      Private WithEvents _btn_Sign As System.Windows.Forms.Button
      Private WithEvents _btn_Verify As System.Windows.Forms.Button
      Private WithEvents _btn_Open As System.Windows.Forms.Button
   End Class
End Namespace
