Namespace DicomDigitalSignatureDemo.UI
	Partial Class CreateSignature
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateSignature))
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me._txtBx_PrivateKey = New System.Windows.Forms.TextBox()
			Me._txtBx_DigitalCertificate = New System.Windows.Forms.TextBox()
			Me._txtBx_Password = New System.Windows.Forms.TextBox()
			Me._txtBox_SignedDataSet = New System.Windows.Forms.TextBox()
			Me._btn_PrivateKey = New System.Windows.Forms.Button()
			Me._btn_DigitalCertificate = New System.Windows.Forms.Button()
			Me._btn_SignedDataSet = New System.Windows.Forms.Button()
			Me._btn_OK = New System.Windows.Forms.Button()
			Me._btn_Cancel = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(64, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Private &Key:"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 51)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(89, 13)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Digital &Certificate:"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(12, 93)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(56, 13)
			Me.label3.TabIndex = 2
			Me.label3.Text = "&Password:"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(12, 135)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(126, 13)
			Me.label4.TabIndex = 3
			Me.label4.Text = "Save signed &Data Set to:"
			' 
			' _txtBx_PrivateKey
			' 
			Me._txtBx_PrivateKey.Location = New System.Drawing.Point(109, 9)
			Me._txtBx_PrivateKey.Name = "_txtBx_PrivateKey"
			Me._txtBx_PrivateKey.Size = New System.Drawing.Size(228, 20)
			Me._txtBx_PrivateKey.TabIndex = 4

         ' 
         ' _txtBx_DigitalCertificate
         ' 
         Me._txtBx_DigitalCertificate.Location = New System.Drawing.Point(109, 48)
			Me._txtBx_DigitalCertificate.Name = "_txtBx_DigitalCertificate"
			Me._txtBx_DigitalCertificate.Size = New System.Drawing.Size(228, 20)
			Me._txtBx_DigitalCertificate.TabIndex = 5
			' 
			' _txtBx_Password
			' 
			Me._txtBx_Password.Location = New System.Drawing.Point(109, 90)
			Me._txtBx_Password.Name = "_txtBx_Password"
			Me._txtBx_Password.PasswordChar = "*"C
			Me._txtBx_Password.Size = New System.Drawing.Size(228, 20)
			Me._txtBx_Password.TabIndex = 6
			' 
			' _txtBox_SignedDataSet
			' 
			Me._txtBox_SignedDataSet.Location = New System.Drawing.Point(15, 163)
			Me._txtBox_SignedDataSet.Name = "_txtBox_SignedDataSet"
			Me._txtBox_SignedDataSet.Size = New System.Drawing.Size(322, 20)
			Me._txtBox_SignedDataSet.TabIndex = 7
			' 
			' _btn_PrivateKey
			' 
			Me._btn_PrivateKey.Location = New System.Drawing.Point(344, 9)
			Me._btn_PrivateKey.Name = "_btn_PrivateKey"
			Me._btn_PrivateKey.Size = New System.Drawing.Size(40, 23)
			Me._btn_PrivateKey.TabIndex = 8
			Me._btn_PrivateKey.Text = "..."
			Me._btn_PrivateKey.UseVisualStyleBackColor = True
			' 
			' _btn_DigitalCertificate
			' 
			Me._btn_DigitalCertificate.Location = New System.Drawing.Point(344, 48)
			Me._btn_DigitalCertificate.Name = "_btn_DigitalCertificate"
			Me._btn_DigitalCertificate.Size = New System.Drawing.Size(40, 23)
			Me._btn_DigitalCertificate.TabIndex = 9
			Me._btn_DigitalCertificate.Text = "..."
			Me._btn_DigitalCertificate.UseVisualStyleBackColor = True
			' 
			' _btn_SignedDataSet
			' 
			Me._btn_SignedDataSet.Location = New System.Drawing.Point(344, 163)
			Me._btn_SignedDataSet.Name = "_btn_SignedDataSet"
			Me._btn_SignedDataSet.Size = New System.Drawing.Size(40, 23)
			Me._btn_SignedDataSet.TabIndex = 10
			Me._btn_SignedDataSet.Text = "..."
			Me._btn_SignedDataSet.UseVisualStyleBackColor = True
			' 
			' _btn_OK
			' 
			Me._btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK
			Me._btn_OK.Location = New System.Drawing.Point(127, 227)
			Me._btn_OK.Name = "_btn_OK"
			Me._btn_OK.Size = New System.Drawing.Size(60, 23)
			Me._btn_OK.TabIndex = 11
			Me._btn_OK.Text = "OK"
			Me._btn_OK.UseVisualStyleBackColor = True
			' 
			' _btn_Cancel
			' 
			Me._btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me._btn_Cancel.Location = New System.Drawing.Point(207, 227)
			Me._btn_Cancel.Name = "_btn_Cancel"
			Me._btn_Cancel.Size = New System.Drawing.Size(60, 23)
			Me._btn_Cancel.TabIndex = 12
			Me._btn_Cancel.Text = "Cancel"
			Me._btn_Cancel.UseVisualStyleBackColor = True
			' 
			' CreateSignature
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(394, 262)
			Me.Controls.Add(Me._btn_Cancel)
			Me.Controls.Add(Me._btn_OK)
			Me.Controls.Add(Me._btn_SignedDataSet)
			Me.Controls.Add(Me._btn_DigitalCertificate)
			Me.Controls.Add(Me._btn_PrivateKey)
			Me.Controls.Add(Me._txtBox_SignedDataSet)
			Me.Controls.Add(Me._txtBx_Password)
			Me.Controls.Add(Me._txtBx_DigitalCertificate)
			Me.Controls.Add(Me._txtBx_PrivateKey)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "CreateSignature"
			Me.Text = "Create Signature"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label3 As System.Windows.Forms.Label
		Private label4 As System.Windows.Forms.Label
      Private WithEvents _txtBx_PrivateKey As System.Windows.Forms.TextBox
      Private _txtBx_DigitalCertificate As System.Windows.Forms.TextBox
		Private _txtBx_Password As System.Windows.Forms.TextBox
		Private _txtBox_SignedDataSet As System.Windows.Forms.TextBox
		Private WithEvents _btn_PrivateKey As System.Windows.Forms.Button
      Private WithEvents _btn_DigitalCertificate As System.Windows.Forms.Button
      Private WithEvents _btn_SignedDataSet As System.Windows.Forms.Button
		Private _btn_OK As System.Windows.Forms.Button
		Private _btn_Cancel As System.Windows.Forms.Button
	End Class
End Namespace
