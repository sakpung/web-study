Namespace DicomVideoCaptureDemo.UI
	Partial Class Edit_Element_Value
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
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.label5 = New System.Windows.Forms.Label()
			Me.label6 = New System.Windows.Forms.Label()
			Me.label7 = New System.Windows.Forms.Label()
			Me.label8 = New System.Windows.Forms.Label()
			Me._txtBox_Code = New System.Windows.Forms.TextBox()
			Me._txtBox_Name = New System.Windows.Forms.TextBox()
			Me._txtBox_Usage = New System.Windows.Forms.TextBox()
			Me._txtBox_VR = New System.Windows.Forms.TextBox()
			Me._txtBox_Description = New System.Windows.Forms.TextBox()
			Me._txtBox_VR_Multiplicity = New System.Windows.Forms.TextBox()
			Me._txtBox_ValueMulti = New System.Windows.Forms.TextBox()
			Me._btn_Modify = New System.Windows.Forms.Button()
			Me._btn_InsertBefore = New System.Windows.Forms.Button()
			Me._btn_Delete = New System.Windows.Forms.Button()
			Me._btn_OK = New System.Windows.Forms.Button()
			Me._btn_InsertAfter = New System.Windows.Forms.Button()
			Me._btn_Cancel = New System.Windows.Forms.Button()
			Me._lstBox_Value = New System.Windows.Forms.ListBox()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(13, 13)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(117, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Instruct Modify Element"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(32, 61)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(32, 13)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Code"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(32, 88)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(35, 13)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Name"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(32, 115)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(38, 13)
			Me.label4.TabIndex = 3
			Me.label4.Text = "Usage"
			' 
			' label5
			' 
			Me.label5.AutoSize = True
			Me.label5.Location = New System.Drawing.Point(32, 182)
			Me.label5.Name = "label5"
			Me.label5.Size = New System.Drawing.Size(60, 13)
			Me.label5.TabIndex = 4
			Me.label5.Text = "Description"
			' 
			' label6
			' 
			Me.label6.AutoSize = True
			Me.label6.Location = New System.Drawing.Point(32, 142)
			Me.label6.MaximumSize = New System.Drawing.Size(100, 26)
			Me.label6.Name = "label6"
			Me.label6.Size = New System.Drawing.Size(79, 26)
			Me.label6.TabIndex = 5
			Me.label6.Text = "Value Representation"
			' 
			' label7
			' 
			Me.label7.AutoSize = True
			Me.label7.Location = New System.Drawing.Point(32, 250)
			Me.label7.Name = "label7"
			Me.label7.Size = New System.Drawing.Size(65, 13)
			Me.label7.TabIndex = 6
			Me.label7.Text = "Value Count"
			' 
			' label8
			' 
			Me.label8.AutoSize = True
			Me.label8.Location = New System.Drawing.Point(32, 292)
			Me.label8.Name = "label8"
			Me.label8.Size = New System.Drawing.Size(34, 13)
			Me.label8.TabIndex = 7
			Me.label8.Text = "Value"
			' 
			' _txtBox_Code
			' 
			Me._txtBox_Code.Location = New System.Drawing.Point(126, 54)
			Me._txtBox_Code.Name = "_txtBox_Code"
			Me._txtBox_Code.Size = New System.Drawing.Size(286, 20)
			Me._txtBox_Code.TabIndex = 8
			' 
			' _txtBox_Name
			' 
			Me._txtBox_Name.Location = New System.Drawing.Point(126, 81)
			Me._txtBox_Name.Name = "_txtBox_Name"
			Me._txtBox_Name.Size = New System.Drawing.Size(286, 20)
			Me._txtBox_Name.TabIndex = 9
			' 
			' _txtBox_Usage
			' 
			Me._txtBox_Usage.Location = New System.Drawing.Point(126, 108)
			Me._txtBox_Usage.Name = "_txtBox_Usage"
			Me._txtBox_Usage.Size = New System.Drawing.Size(286, 20)
			Me._txtBox_Usage.TabIndex = 10
			' 
			' _txtBox_VR
			' 
			Me._txtBox_VR.Location = New System.Drawing.Point(126, 142)
			Me._txtBox_VR.Name = "_txtBox_VR"
			Me._txtBox_VR.Size = New System.Drawing.Size(286, 20)
			Me._txtBox_VR.TabIndex = 11
			' 
			' _txtBox_Description
			' 
			Me._txtBox_Description.Location = New System.Drawing.Point(126, 175)
			Me._txtBox_Description.Multiline = True
			Me._txtBox_Description.Name = "_txtBox_Description"
			Me._txtBox_Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
			Me._txtBox_Description.Size = New System.Drawing.Size(286, 69)
			Me._txtBox_Description.TabIndex = 12
			' 
			' _txtBox_VR_Multiplicity
			' 
			Me._txtBox_VR_Multiplicity.Location = New System.Drawing.Point(126, 250)
			Me._txtBox_VR_Multiplicity.Name = "_txtBox_VR_Multiplicity"
			Me._txtBox_VR_Multiplicity.Size = New System.Drawing.Size(286, 20)
			Me._txtBox_VR_Multiplicity.TabIndex = 13
			' 
			' _txtBox_ValueMulti
			' 
			Me._txtBox_ValueMulti.Enabled = False
			Me._txtBox_ValueMulti.Location = New System.Drawing.Point(126, 276)
			Me._txtBox_ValueMulti.Multiline = True
			Me._txtBox_ValueMulti.Name = "_txtBox_ValueMulti"
			Me._txtBox_ValueMulti.Size = New System.Drawing.Size(286, 100)
			Me._txtBox_ValueMulti.TabIndex = 14
			' 
			' _btn_Modify
			' 
			Me._btn_Modify.Location = New System.Drawing.Point(5, 406)
			Me._btn_Modify.Name = "_btn_Modify"
			Me._btn_Modify.Size = New System.Drawing.Size(70, 23)
			Me._btn_Modify.TabIndex = 16
			Me._btn_Modify.Text = "Modify"
			Me._btn_Modify.UseVisualStyleBackColor = True
			' 
			' _btn_InsertBefore
			' 
			Me._btn_InsertBefore.Location = New System.Drawing.Point(157, 406)
			Me._btn_InsertBefore.Name = "_btn_InsertBefore"
			Me._btn_InsertBefore.Size = New System.Drawing.Size(84, 23)
			Me._btn_InsertBefore.TabIndex = 17
			Me._btn_InsertBefore.Text = "Insert Before"
			Me._btn_InsertBefore.UseVisualStyleBackColor = True
			' 
			' _btn_Delete
			' 
			Me._btn_Delete.Location = New System.Drawing.Point(81, 406)
			Me._btn_Delete.Name = "_btn_Delete"
			Me._btn_Delete.Size = New System.Drawing.Size(70, 23)
			Me._btn_Delete.TabIndex = 18
			Me._btn_Delete.Text = "Delete"
			Me._btn_Delete.UseVisualStyleBackColor = True
			' 
			' _btn_OK
			' 
			Me._btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK
			Me._btn_OK.Location = New System.Drawing.Point(351, 406)
			Me._btn_OK.Name = "_btn_OK"
			Me._btn_OK.Size = New System.Drawing.Size(70, 23)
			Me._btn_OK.TabIndex = 20
			Me._btn_OK.Text = "OK"
			Me._btn_OK.UseVisualStyleBackColor = True
			' 
			' _btn_InsertAfter
			' 
			Me._btn_InsertAfter.Location = New System.Drawing.Point(247, 406)
			Me._btn_InsertAfter.Name = "_btn_InsertAfter"
			Me._btn_InsertAfter.Size = New System.Drawing.Size(70, 23)
			Me._btn_InsertAfter.TabIndex = 19
			Me._btn_InsertAfter.Text = "Insert After"
			Me._btn_InsertAfter.UseVisualStyleBackColor = True
			' 
			' _btn_Cancel
			' 
			Me._btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me._btn_Cancel.Location = New System.Drawing.Point(427, 406)
			Me._btn_Cancel.Name = "_btn_Cancel"
			Me._btn_Cancel.Size = New System.Drawing.Size(70, 23)
			Me._btn_Cancel.TabIndex = 21
			Me._btn_Cancel.Text = "Cancel"
			Me._btn_Cancel.UseVisualStyleBackColor = True
			' 
			' _lstBox_Value
			' 
			Me._lstBox_Value.FormattingEnabled = True
			Me._lstBox_Value.Location = New System.Drawing.Point(16, 318)
			Me._lstBox_Value.Name = "_lstBox_Value"
			Me._lstBox_Value.Size = New System.Drawing.Size(76, 69)
			Me._lstBox_Value.TabIndex = 22
			' 
			' Edit_Element_Value
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(504, 462)
			Me.Controls.Add(Me._lstBox_Value)
			Me.Controls.Add(Me._btn_Cancel)
			Me.Controls.Add(Me._btn_OK)
			Me.Controls.Add(Me._btn_InsertAfter)
			Me.Controls.Add(Me._btn_Delete)
			Me.Controls.Add(Me._btn_InsertBefore)
			Me.Controls.Add(Me._btn_Modify)
			Me.Controls.Add(Me._txtBox_ValueMulti)
			Me.Controls.Add(Me._txtBox_VR_Multiplicity)
			Me.Controls.Add(Me._txtBox_Description)
			Me.Controls.Add(Me._txtBox_VR)
			Me.Controls.Add(Me._txtBox_Usage)
			Me.Controls.Add(Me._txtBox_Name)
			Me.Controls.Add(Me._txtBox_Code)
			Me.Controls.Add(Me.label8)
			Me.Controls.Add(Me.label7)
			Me.Controls.Add(Me.label6)
			Me.Controls.Add(Me.label5)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "Edit_Element_Value"
			Me.Text = "Edit Element Value"
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
		Private _txtBox_Code As System.Windows.Forms.TextBox
		Private _txtBox_Name As System.Windows.Forms.TextBox
		Private _txtBox_Usage As System.Windows.Forms.TextBox
		Private _txtBox_VR As System.Windows.Forms.TextBox
		Private _txtBox_Description As System.Windows.Forms.TextBox
		Private _txtBox_VR_Multiplicity As System.Windows.Forms.TextBox
		Private _txtBox_ValueMulti As System.Windows.Forms.TextBox
		Private _btn_Modify As System.Windows.Forms.Button
		Private _btn_InsertBefore As System.Windows.Forms.Button
		Private _btn_Delete As System.Windows.Forms.Button
		Private _btn_OK As System.Windows.Forms.Button
		Private _btn_InsertAfter As System.Windows.Forms.Button
		Private _btn_Cancel As System.Windows.Forms.Button
		Private _lstBox_Value As System.Windows.Forms.ListBox

	End Class
End Namespace
