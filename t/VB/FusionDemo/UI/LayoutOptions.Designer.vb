Namespace FusionDemo
	Partial Public Class LayoutOptions
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
			Me._btnCancel = New System.Windows.Forms.Button()
			Me._btnOK = New System.Windows.Forms.Button()
			Me._btnApply = New System.Windows.Forms.Button()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me._txtColumns = New NumericTextBox()
			Me._txtRows = New NumericTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me._interpolateAlwaysImage = New System.Windows.Forms.CheckBox()
			Me.groupBox1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' _btnCancel
			' 
			Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me._btnCancel.Location = New System.Drawing.Point(94, 124)
			Me._btnCancel.Name = "_btnCancel"
			Me._btnCancel.Size = New System.Drawing.Size(72, 26)
			Me._btnCancel.TabIndex = 17
			Me._btnCancel.Text = "&Cancel"
			Me._btnCancel.UseVisualStyleBackColor = True
			' 
			' _btnOK
			' 
			Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
			Me._btnOK.Location = New System.Drawing.Point(12, 124)
			Me._btnOK.Name = "_btnOK"
			Me._btnOK.Size = New System.Drawing.Size(72, 26)
			Me._btnOK.TabIndex = 16
			Me._btnOK.Text = "&OK"
			Me._btnOK.UseVisualStyleBackColor = True
			' 
			' _btnApply
			' 
			Me._btnApply.Location = New System.Drawing.Point(178, 124)
			Me._btnApply.Name = "_btnApply"
			Me._btnApply.Size = New System.Drawing.Size(72, 26)
			Me._btnApply.TabIndex = 19
			Me._btnApply.Text = "&Apply"
			Me._btnApply.UseVisualStyleBackColor = True
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me._interpolateAlwaysImage)
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me._txtColumns)
			Me.groupBox1.Controls.Add(Me._txtRows)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Location = New System.Drawing.Point(10, 8)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(242, 106)
			Me.groupBox1.TabIndex = 20
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "&Layout"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(156, 40)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(14, 13)
			Me.label3.TabIndex = 5
			Me.label3.Text = "X"
			' 
			' _txtColumns
			' 
			Me._txtColumns.Location = New System.Drawing.Point(175, 37)
			Me._txtColumns.MaximumAllowed = 8
			Me._txtColumns.MinimumAllowed = 1
			Me._txtColumns.Name = "_txtColumns"
			Me._txtColumns.Size = New System.Drawing.Size(51, 20)
			Me._txtColumns.TabIndex = 4
			Me._txtColumns.Text = "1"
			Me._txtColumns.Value = 1
			' 
			' _txtRows
			' 
			Me._txtRows.Location = New System.Drawing.Point(98, 37)
			Me._txtRows.MaximumAllowed = 8
			Me._txtRows.MinimumAllowed = 1
			Me._txtRows.Name = "_txtRows"
			Me._txtRows.Size = New System.Drawing.Size(51, 20)
			Me._txtRows.TabIndex = 3
			Me._txtRows.Text = "1"
			Me._txtRows.Value = 1
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 40)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(74, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Viewer Layout"
			' 
			' _interpolateAlwaysImage
			' 
			Me._interpolateAlwaysImage.AutoSize = True
			Me._interpolateAlwaysImage.Location = New System.Drawing.Point(15, 74)
			Me._interpolateAlwaysImage.Name = "_interpolateAlwaysImage"
			Me._interpolateAlwaysImage.Size = New System.Drawing.Size(161, 17)
			Me._interpolateAlwaysImage.TabIndex = 6
			Me._interpolateAlwaysImage.Text = "Always Interpolate the image"
			Me._interpolateAlwaysImage.UseVisualStyleBackColor = True
			' 
			' LayoutOptions
			' 
			Me.AcceptButton = Me._btnOK
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.CancelButton = Me._btnCancel
			Me.ClientSize = New System.Drawing.Size(264, 160)
			Me.Controls.Add(Me.groupBox1)
			Me.Controls.Add(Me._btnApply)
			Me.Controls.Add(Me._btnCancel)
			Me.Controls.Add(Me._btnOK)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "LayoutOptions"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Medical 3D Properties"
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private _btnCancel As System.Windows.Forms.Button
		Private WithEvents _btnOK As System.Windows.Forms.Button
		Private WithEvents _btnApply As System.Windows.Forms.Button
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private label3 As System.Windows.Forms.Label
		Private _txtColumns As NumericTextBox
		Private _txtRows As NumericTextBox
		Private label1 As System.Windows.Forms.Label
		Private _interpolateAlwaysImage As System.Windows.Forms.CheckBox
	End Class
End Namespace