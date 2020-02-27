Imports Microsoft.VisualBasic
Imports System
Namespace MedicalViewerLayoutDemo
   Public Partial Class NudgeToolDialog
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
		 Me.label8 = New System.Windows.Forms.Label()
		 Me.groupBox3 = New System.Windows.Forms.GroupBox()
		 Me._rdoBackSlash = New System.Windows.Forms.RadioButton()
		 Me._rdoSlash = New System.Windows.Forms.RadioButton()
		 Me._rdoEllipse = New System.Windows.Forms.RadioButton()
		 Me._rdoRectangle = New System.Windows.Forms.RadioButton()
		 Me._txtHeight = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me._txtWidth = New MedicalViewerLayoutDemo.NumericTextBox()
		 Me.label7 = New System.Windows.Forms.Label()
		 Me._btnCancel = New System.Windows.Forms.Button()
		 Me._btnOK = New System.Windows.Forms.Button()
		 Me.groupBox3.SuspendLayout()
		 Me.SuspendLayout()
		 ' 
		 ' label8
		 ' 
		 Me.label8.AutoSize = True
		 Me.label8.Location = New System.Drawing.Point(9, 165)
		 Me.label8.Name = "label8"
		 Me.label8.Size = New System.Drawing.Size(38, 13)
		 Me.label8.TabIndex = 13
		 Me.label8.Text = "&Height"
		 ' 
		 ' groupBox3
		 ' 
		 Me.groupBox3.Controls.Add(Me._rdoBackSlash)
		 Me.groupBox3.Controls.Add(Me._rdoSlash)
		 Me.groupBox3.Controls.Add(Me._rdoEllipse)
		 Me.groupBox3.Controls.Add(Me._rdoRectangle)
		 Me.groupBox3.Controls.Add(Me._txtHeight)
		 Me.groupBox3.Controls.Add(Me.label8)
		 Me.groupBox3.Controls.Add(Me._txtWidth)
		 Me.groupBox3.Controls.Add(Me.label7)
		 Me.groupBox3.Location = New System.Drawing.Point(12, 12)
		 Me.groupBox3.Name = "groupBox3"
		 Me.groupBox3.Size = New System.Drawing.Size(152, 200)
		 Me.groupBox3.TabIndex = 17
		 Me.groupBox3.TabStop = False
		 Me.groupBox3.Text = "&Nudge tool brush properties"
		 ' 
		 ' _rdoBackSlash
		 ' 
		 Me._rdoBackSlash.AutoSize = True
		 Me._rdoBackSlash.Location = New System.Drawing.Point(18, 93)
		 Me._rdoBackSlash.Name = "_rdoBackSlash"
		 Me._rdoBackSlash.Size = New System.Drawing.Size(77, 17)
		 Me._rdoBackSlash.TabIndex = 18
		 Me._rdoBackSlash.TabStop = True
		 Me._rdoBackSlash.Text = "&Back slash"
		 Me._rdoBackSlash.UseVisualStyleBackColor = True
		 ' 
		 ' _rdoSlash
		 ' 
		 Me._rdoSlash.AutoSize = True
		 Me._rdoSlash.Location = New System.Drawing.Point(18, 70)
		 Me._rdoSlash.Name = "_rdoSlash"
		 Me._rdoSlash.Size = New System.Drawing.Size(51, 17)
		 Me._rdoSlash.TabIndex = 17
		 Me._rdoSlash.TabStop = True
		 Me._rdoSlash.Text = "&Slash"
		 Me._rdoSlash.UseVisualStyleBackColor = True
		 ' 
		 ' _rdoEllipse
		 ' 
		 Me._rdoEllipse.AutoSize = True
		 Me._rdoEllipse.Location = New System.Drawing.Point(18, 47)
		 Me._rdoEllipse.Name = "_rdoEllipse"
		 Me._rdoEllipse.Size = New System.Drawing.Size(55, 17)
		 Me._rdoEllipse.TabIndex = 16
		 Me._rdoEllipse.TabStop = True
		 Me._rdoEllipse.Text = "&Ellipse"
		 Me._rdoEllipse.UseVisualStyleBackColor = True
		 ' 
		 ' _rdoRectangle
		 ' 
		 Me._rdoRectangle.AutoSize = True
		 Me._rdoRectangle.Location = New System.Drawing.Point(18, 24)
		 Me._rdoRectangle.Name = "_rdoRectangle"
		 Me._rdoRectangle.Size = New System.Drawing.Size(74, 17)
		 Me._rdoRectangle.TabIndex = 15
		 Me._rdoRectangle.TabStop = True
		 Me._rdoRectangle.Text = "&Rectangle"
		 Me._rdoRectangle.UseVisualStyleBackColor = True
		 ' 
		 ' _txtHeight
		 ' 
		 Me._txtHeight.Location = New System.Drawing.Point(56, 162)
		 Me._txtHeight.MaximumAllowed = 100
		 Me._txtHeight.MinimumAllowed = 0
		 Me._txtHeight.Name = "_txtHeight"
		 Me._txtHeight.Size = New System.Drawing.Size(41, 20)
		 Me._txtHeight.TabIndex = 14
		 Me._txtHeight.Text = "0"
		 Me._txtHeight.Value = 0
		 ' 
		 ' _txtWidth
		 ' 
		 Me._txtWidth.Location = New System.Drawing.Point(56, 127)
		 Me._txtWidth.MaximumAllowed = 100
		 Me._txtWidth.MinimumAllowed = 0
		 Me._txtWidth.Name = "_txtWidth"
		 Me._txtWidth.Size = New System.Drawing.Size(41, 20)
		 Me._txtWidth.TabIndex = 10
		 Me._txtWidth.Text = "0"
		 Me._txtWidth.Value = 0
		 ' 
		 ' label7
		 ' 
		 Me.label7.AutoSize = True
		 Me.label7.Location = New System.Drawing.Point(10, 130)
		 Me.label7.Name = "label7"
		 Me.label7.Size = New System.Drawing.Size(35, 13)
		 Me.label7.TabIndex = 4
		 Me.label7.Text = "&Width"
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.Location = New System.Drawing.Point(92, 220)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(70, 29)
		 Me._btnCancel.TabIndex = 19
		 Me._btnCancel.Text = "Canc&el"
		 Me._btnCancel.UseVisualStyleBackColor = True
		 ' 
		 ' _btnOK
		 ' 
		 Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnOK.Location = New System.Drawing.Point(12, 220)
		 Me._btnOK.Name = "_btnOK"
		 Me._btnOK.Size = New System.Drawing.Size(70, 29)
		 Me._btnOK.TabIndex = 18
		 Me._btnOK.Text = "&OK"
		 Me._btnOK.UseVisualStyleBackColor = True
'		 Me._btnOK.Click += New System.EventHandler(Me._btnOK_Click);
		 ' 
		 ' NudgeToolDialog
		 ' 
		 Me.AcceptButton = Me._btnOK
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(175, 259)
		 Me.Controls.Add(Me.groupBox3)
		 Me.Controls.Add(Me._btnCancel)
		 Me.Controls.Add(Me._btnOK)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "NudgeToolDialog"
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Stack Dialog"
		 Me.groupBox3.ResumeLayout(False)
		 Me.groupBox3.PerformLayout()
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _txtHeight As NumericTextBox
	  Private label8 As System.Windows.Forms.Label
	  Private groupBox3 As System.Windows.Forms.GroupBox
	  Private _txtWidth As NumericTextBox
	  Private label7 As System.Windows.Forms.Label
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOK As System.Windows.Forms.Button
	  Private _rdoBackSlash As System.Windows.Forms.RadioButton
	  Private _rdoSlash As System.Windows.Forms.RadioButton
	  Private _rdoEllipse As System.Windows.Forms.RadioButton
	  Private _rdoRectangle As System.Windows.Forms.RadioButton
   End Class
End Namespace