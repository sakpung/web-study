Namespace MedicalViewerDemo
   Partial Class NudgeShrinkToolDialog
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
         Me._rdoNudgeBackSlash = New System.Windows.Forms.RadioButton()
         Me._rdoNudgeSlash = New System.Windows.Forms.RadioButton()
         Me._rdoNudgeEllipse = New System.Windows.Forms.RadioButton()
         Me._rdoNudgeRectangle = New System.Windows.Forms.RadioButton()
         Me._txtNudgeHeight = New MedicalViewerDemo.NumericTextBox()
         Me._txtNudgeWidth = New MedicalViewerDemo.NumericTextBox()
         Me.label7 = New System.Windows.Forms.Label()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._rdoShrinkBackSlash = New System.Windows.Forms.RadioButton()
         Me._rdoShrinkSlash = New System.Windows.Forms.RadioButton()
         Me._rdoShrinkEllipse = New System.Windows.Forms.RadioButton()
         Me._rdoShrinkRectangle = New System.Windows.Forms.RadioButton()
         Me._txtShrinkHeight = New MedicalViewerDemo.NumericTextBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me._txtShrinkWidth = New MedicalViewerDemo.NumericTextBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me.groupBox3.SuspendLayout()
         Me.groupBox1.SuspendLayout()
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
         Me.groupBox3.Controls.Add(Me._rdoNudgeBackSlash)
         Me.groupBox3.Controls.Add(Me._rdoNudgeSlash)
         Me.groupBox3.Controls.Add(Me._rdoNudgeEllipse)
         Me.groupBox3.Controls.Add(Me._rdoNudgeRectangle)
         Me.groupBox3.Controls.Add(Me._txtNudgeHeight)
         Me.groupBox3.Controls.Add(Me.label8)
         Me.groupBox3.Controls.Add(Me._txtNudgeWidth)
         Me.groupBox3.Controls.Add(Me.label7)
         Me.groupBox3.Location = New System.Drawing.Point(12, 12)
         Me.groupBox3.Name = "groupBox3"
         Me.groupBox3.Size = New System.Drawing.Size(152, 200)
         Me.groupBox3.TabIndex = 17
         Me.groupBox3.TabStop = False
         Me.groupBox3.Text = "&Nudge tool brush properties"
         ' 
         ' _rdoNudgeBackSlash
         ' 
         Me._rdoNudgeBackSlash.AutoSize = True
         Me._rdoNudgeBackSlash.Location = New System.Drawing.Point(18, 93)
         Me._rdoNudgeBackSlash.Name = "_rdoNudgeBackSlash"
         Me._rdoNudgeBackSlash.Size = New System.Drawing.Size(74, 17)
         Me._rdoNudgeBackSlash.TabIndex = 18
         Me._rdoNudgeBackSlash.TabStop = True
         Me._rdoNudgeBackSlash.Text = "&Back slash"
         Me._rdoNudgeBackSlash.UseVisualStyleBackColor = True
         ' 
         ' _rdoNudgeSlash
         ' 
         Me._rdoNudgeSlash.AutoSize = True
         Me._rdoNudgeSlash.Location = New System.Drawing.Point(18, 70)
         Me._rdoNudgeSlash.Name = "_rdoNudgeSlash"
         Me._rdoNudgeSlash.Size = New System.Drawing.Size(50, 17)
         Me._rdoNudgeSlash.TabIndex = 17
         Me._rdoNudgeSlash.TabStop = True
         Me._rdoNudgeSlash.Text = "&Slash"
         Me._rdoNudgeSlash.UseVisualStyleBackColor = True
         ' 
         ' _rdoNudgeEllipse
         ' 
         Me._rdoNudgeEllipse.AutoSize = True
         Me._rdoNudgeEllipse.Location = New System.Drawing.Point(18, 47)
         Me._rdoNudgeEllipse.Name = "_rdoNudgeEllipse"
         Me._rdoNudgeEllipse.Size = New System.Drawing.Size(54, 17)
         Me._rdoNudgeEllipse.TabIndex = 16
         Me._rdoNudgeEllipse.TabStop = True
         Me._rdoNudgeEllipse.Text = "&Ellipse"
         Me._rdoNudgeEllipse.UseVisualStyleBackColor = True
         ' 
         ' _rdoNudgeRectangle
         ' 
         Me._rdoNudgeRectangle.AutoSize = True
         Me._rdoNudgeRectangle.Location = New System.Drawing.Point(18, 24)
         Me._rdoNudgeRectangle.Name = "_rdoNudgeRectangle"
         Me._rdoNudgeRectangle.Size = New System.Drawing.Size(73, 17)
         Me._rdoNudgeRectangle.TabIndex = 15
         Me._rdoNudgeRectangle.TabStop = True
         Me._rdoNudgeRectangle.Text = "&Rectangle"
         Me._rdoNudgeRectangle.UseVisualStyleBackColor = True
         ' 
         ' _txtNudgeHeight
         ' 
         Me._txtNudgeHeight.Location = New System.Drawing.Point(56, 162)
         Me._txtNudgeHeight.MaximumAllowed = 100
         Me._txtNudgeHeight.MinimumAllowed = 0
         Me._txtNudgeHeight.Name = "_txtNudgeHeight"
         Me._txtNudgeHeight.Size = New System.Drawing.Size(41, 20)
         Me._txtNudgeHeight.TabIndex = 14
         Me._txtNudgeHeight.Text = "0"
         Me._txtNudgeHeight.Value = 0
         ' 
         ' _txtNudgeWidth
         ' 
         Me._txtNudgeWidth.Location = New System.Drawing.Point(56, 127)
         Me._txtNudgeWidth.MaximumAllowed = 100
         Me._txtNudgeWidth.MinimumAllowed = 0
         Me._txtNudgeWidth.Name = "_txtNudgeWidth"
         Me._txtNudgeWidth.Size = New System.Drawing.Size(41, 20)
         Me._txtNudgeWidth.TabIndex = 10
         Me._txtNudgeWidth.Text = "0"
         Me._txtNudgeWidth.Value = 0
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
         Me._btnCancel.Location = New System.Drawing.Point(176, 220)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(70, 29)
         Me._btnCancel.TabIndex = 19
         Me._btnCancel.Text = "Canc&el"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnOK.Location = New System.Drawing.Point(94, 220)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(70, 29)
         Me._btnOK.TabIndex = 18
         Me._btnOK.Text = "&OK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._rdoShrinkBackSlash)
         Me.groupBox1.Controls.Add(Me._rdoShrinkSlash)
         Me.groupBox1.Controls.Add(Me._rdoShrinkEllipse)
         Me.groupBox1.Controls.Add(Me._rdoShrinkRectangle)
         Me.groupBox1.Controls.Add(Me._txtShrinkHeight)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Controls.Add(Me._txtShrinkWidth)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Location = New System.Drawing.Point(176, 12)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(152, 200)
         Me.groupBox1.TabIndex = 19
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "&Shrink tool brush properties"
         ' 
         ' _rdoShrinkBackSlash
         ' 
         Me._rdoShrinkBackSlash.AutoSize = True
         Me._rdoShrinkBackSlash.Location = New System.Drawing.Point(18, 93)
         Me._rdoShrinkBackSlash.Name = "_rdoShrinkBackSlash"
         Me._rdoShrinkBackSlash.Size = New System.Drawing.Size(74, 17)
         Me._rdoShrinkBackSlash.TabIndex = 18
         Me._rdoShrinkBackSlash.TabStop = True
         Me._rdoShrinkBackSlash.Text = "&Back slash"
         Me._rdoShrinkBackSlash.UseVisualStyleBackColor = True
         ' 
         ' _rdoShrinkSlash
         ' 
         Me._rdoShrinkSlash.AutoSize = True
         Me._rdoShrinkSlash.Location = New System.Drawing.Point(18, 70)
         Me._rdoShrinkSlash.Name = "_rdoShrinkSlash"
         Me._rdoShrinkSlash.Size = New System.Drawing.Size(50, 17)
         Me._rdoShrinkSlash.TabIndex = 17
         Me._rdoShrinkSlash.TabStop = True
         Me._rdoShrinkSlash.Text = "&Slash"
         Me._rdoShrinkSlash.UseVisualStyleBackColor = True
         ' 
         ' _rdoShrinkEllipse
         ' 
         Me._rdoShrinkEllipse.AutoSize = True
         Me._rdoShrinkEllipse.Location = New System.Drawing.Point(18, 47)
         Me._rdoShrinkEllipse.Name = "_rdoShrinkEllipse"
         Me._rdoShrinkEllipse.Size = New System.Drawing.Size(54, 17)
         Me._rdoShrinkEllipse.TabIndex = 16
         Me._rdoShrinkEllipse.TabStop = True
         Me._rdoShrinkEllipse.Text = "&Ellipse"
         Me._rdoShrinkEllipse.UseVisualStyleBackColor = True
         ' 
         ' _rdoShrinkRectangle
         ' 
         Me._rdoShrinkRectangle.AutoSize = True
         Me._rdoShrinkRectangle.Location = New System.Drawing.Point(18, 24)
         Me._rdoShrinkRectangle.Name = "_rdoShrinkRectangle"
         Me._rdoShrinkRectangle.Size = New System.Drawing.Size(73, 17)
         Me._rdoShrinkRectangle.TabIndex = 15
         Me._rdoShrinkRectangle.TabStop = True
         Me._rdoShrinkRectangle.Text = "&Rectangle"
         Me._rdoShrinkRectangle.UseVisualStyleBackColor = True
         ' 
         ' _txtShrinkHeight
         ' 
         Me._txtShrinkHeight.Location = New System.Drawing.Point(56, 162)
         Me._txtShrinkHeight.MaximumAllowed = 100
         Me._txtShrinkHeight.MinimumAllowed = 0
         Me._txtShrinkHeight.Name = "_txtShrinkHeight"
         Me._txtShrinkHeight.Size = New System.Drawing.Size(41, 20)
         Me._txtShrinkHeight.TabIndex = 14
         Me._txtShrinkHeight.Text = "0"
         Me._txtShrinkHeight.Value = 0
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(9, 165)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(38, 13)
         Me.label1.TabIndex = 13
         Me.label1.Text = "&Height"
         ' 
         ' _txtShrinkWidth
         ' 
         Me._txtShrinkWidth.Location = New System.Drawing.Point(56, 127)
         Me._txtShrinkWidth.MaximumAllowed = 100
         Me._txtShrinkWidth.MinimumAllowed = 0
         Me._txtShrinkWidth.Name = "_txtShrinkWidth"
         Me._txtShrinkWidth.Size = New System.Drawing.Size(41, 20)
         Me._txtShrinkWidth.TabIndex = 10
         Me._txtShrinkWidth.Text = "0"
         Me._txtShrinkWidth.Value = 0
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(10, 130)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(35, 13)
         Me.label2.TabIndex = 4
         Me.label2.Text = "&Width"
         ' 
         ' NudgeShrinkToolDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(340, 259)
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me.groupBox3)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "NudgeShrinkToolDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Nudge Tool Dialog"
         Me.groupBox3.ResumeLayout(False)
         Me.groupBox3.PerformLayout()
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _txtNudgeHeight As NumericTextBox
      Private label8 As System.Windows.Forms.Label
      Private groupBox3 As System.Windows.Forms.GroupBox
      Private _txtNudgeWidth As NumericTextBox
      Private label7 As System.Windows.Forms.Label
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _rdoNudgeBackSlash As System.Windows.Forms.RadioButton
      Private _rdoNudgeSlash As System.Windows.Forms.RadioButton
      Private _rdoNudgeEllipse As System.Windows.Forms.RadioButton
      Private _rdoNudgeRectangle As System.Windows.Forms.RadioButton
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private _rdoShrinkBackSlash As System.Windows.Forms.RadioButton
      Private _rdoShrinkSlash As System.Windows.Forms.RadioButton
      Private _rdoShrinkEllipse As System.Windows.Forms.RadioButton
      Private _rdoShrinkRectangle As System.Windows.Forms.RadioButton
      Private _txtShrinkHeight As NumericTextBox
      Private label1 As System.Windows.Forms.Label
      Private _txtShrinkWidth As NumericTextBox
      Private label2 As System.Windows.Forms.Label
   End Class
End Namespace
