Namespace DicomVideoCaptureDemo.UI
	Partial Class Create_New_DICOM_File
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
			Me._lstBx = New System.Windows.Forms.ListBox()
			Me._btn_OK = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' _lstBx
			' 
			Me._lstBx.FormattingEnabled = True
			Me._lstBx.Location = New System.Drawing.Point(13, 13)
			Me._lstBx.Name = "_lstBx"
			Me._lstBx.Size = New System.Drawing.Size(259, 199)
			Me._lstBx.TabIndex = 0
			' 
			' _btn_OK
			' 
			Me._btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK
			Me._btn_OK.Location = New System.Drawing.Point(105, 227)
			Me._btn_OK.Name = "_btn_OK"
			Me._btn_OK.Size = New System.Drawing.Size(75, 23)
			Me._btn_OK.TabIndex = 1
			Me._btn_OK.Text = "OK"
			Me._btn_OK.UseVisualStyleBackColor = True
			' 
			' Create_New_DICOM_File
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(284, 262)
			Me.Controls.Add(Me._btn_OK)
			Me.Controls.Add(Me._lstBx)
			Me.Name = "Create_New_DICOM_File"
			Me.Text = "Create New DICOM File"
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private _lstBx As System.Windows.Forms.ListBox
		Private _btn_OK As System.Windows.Forms.Button
	End Class
End Namespace
