Namespace DicomVideoCaptureDemo.UI
	Partial Class Edit_Item
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
			Me._btn_OK = New System.Windows.Forms.Button()
			Me._btn_Cancel = New System.Windows.Forms.Button()
			Me._txtBox_DateTimePicker = New System.Windows.Forms.TextBox()
			Me._txtBox_VR_Info = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' _btn_OK
			' 
			Me._btn_OK.Location = New System.Drawing.Point(115, 125)
			Me._btn_OK.Name = "_btn_OK"
			Me._btn_OK.Size = New System.Drawing.Size(75, 23)
			Me._btn_OK.TabIndex = 11
			Me._btn_OK.Text = "OK"
			Me._btn_OK.UseVisualStyleBackColor = True
			' 
			' _btn_Cancel
			' 
			Me._btn_Cancel.Location = New System.Drawing.Point(196, 125)
			Me._btn_Cancel.Name = "_btn_Cancel"
			Me._btn_Cancel.Size = New System.Drawing.Size(75, 23)
			Me._btn_Cancel.TabIndex = 10
			Me._btn_Cancel.Text = "Cancel"
			Me._btn_Cancel.UseVisualStyleBackColor = True
			' 
			' _txtBox_DateTimePicker
			' 
			Me._txtBox_DateTimePicker.Location = New System.Drawing.Point(53, 97)
			Me._txtBox_DateTimePicker.Name = "_txtBox_DateTimePicker"
			Me._txtBox_DateTimePicker.Size = New System.Drawing.Size(219, 20)
			Me._txtBox_DateTimePicker.TabIndex = 9
			' 
			' _txtBox_VR_Info
			' 
			Me._txtBox_VR_Info.Location = New System.Drawing.Point(55, 22)
			Me._txtBox_VR_Info.Multiline = True
			Me._txtBox_VR_Info.Name = "_txtBox_VR_Info"
			Me._txtBox_VR_Info.[ReadOnly] = True
			Me._txtBox_VR_Info.Size = New System.Drawing.Size(217, 61)
			Me._txtBox_VR_Info.TabIndex = 8
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 97)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(34, 13)
			Me.label2.TabIndex = 7
			Me.label2.Text = "Value"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(13, 22)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(35, 13)
			Me.label1.TabIndex = 6
			Me.label1.Text = "Notes"
			' 
			' Edit_Item
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(284, 162)
			Me.Controls.Add(Me._btn_OK)
			Me.Controls.Add(Me._btn_Cancel)
			Me.Controls.Add(Me._txtBox_DateTimePicker)
			Me.Controls.Add(Me._txtBox_VR_Info)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Name = "Edit_Item"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private _btn_OK As System.Windows.Forms.Button
		Private _btn_Cancel As System.Windows.Forms.Button
		Private _txtBox_DateTimePicker As System.Windows.Forms.TextBox
		Private _txtBox_VR_Info As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
	End Class
End Namespace
