Namespace MedicalViewerDemo
   Partial Class SetNudgeShrinkActionDialog
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
         Me._cmbNudgeMouseButton = New System.Windows.Forms.ComboBox()
         Me._cmbNudgeApplyTo = New System.Windows.Forms.ComboBox()
         Me._cmbNudgeApplyingMethod = New System.Windows.Forms.ComboBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._btnApply = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.label4 = New System.Windows.Forms.Label()
         Me.label5 = New System.Windows.Forms.Label()
         Me.label6 = New System.Windows.Forms.Label()
         Me._cmbShrinkApplyingMethod = New System.Windows.Forms.ComboBox()
         Me._cmbShrinkApplyTo = New System.Windows.Forms.ComboBox()
         Me._cmbShrinkMouseButton = New System.Windows.Forms.ComboBox()
         Me.groupBox1.SuspendLayout()
         Me.groupBox2.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _cmbNudgeMouseButton
         ' 
         Me._cmbNudgeMouseButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbNudgeMouseButton.FormattingEnabled = True
         Me._cmbNudgeMouseButton.Items.AddRange(New Object() {"None", "Left Button", "Right Button", "Middle Button"})
         Me._cmbNudgeMouseButton.Location = New System.Drawing.Point(104, 19)
         Me._cmbNudgeMouseButton.Name = "_cmbNudgeMouseButton"
         Me._cmbNudgeMouseButton.Size = New System.Drawing.Size(92, 21)
         Me._cmbNudgeMouseButton.TabIndex = 0
         ' 
         ' _cmbNudgeApplyTo
         ' 
         Me._cmbNudgeApplyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbNudgeApplyTo.FormattingEnabled = True
         Me._cmbNudgeApplyTo.Items.AddRange(New Object() {"Active Cell"})
         Me._cmbNudgeApplyTo.Location = New System.Drawing.Point(78, 60)
         Me._cmbNudgeApplyTo.Name = "_cmbNudgeApplyTo"
         Me._cmbNudgeApplyTo.Size = New System.Drawing.Size(118, 21)
         Me._cmbNudgeApplyTo.TabIndex = 1
         ' 
         ' _cmbNudgeApplyingMethod
         ' 
         Me._cmbNudgeApplyingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbNudgeApplyingMethod.FormattingEnabled = True
         Me._cmbNudgeApplyingMethod.Items.AddRange(New Object() {"RealTime"})
         Me._cmbNudgeApplyingMethod.Location = New System.Drawing.Point(107, 101)
         Me._cmbNudgeApplyingMethod.Name = "_cmbNudgeApplyingMethod"
         Me._cmbNudgeApplyingMethod.Size = New System.Drawing.Size(89, 21)
         Me._cmbNudgeApplyingMethod.TabIndex = 2
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(14, 23)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(73, 13)
         Me.label1.TabIndex = 3
         Me.label1.Text = "&Mouse button"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(14, 64)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(47, 13)
         Me.label2.TabIndex = 4
         Me.label2.Text = "&Apply to"
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(14, 105)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(87, 13)
         Me.label3.TabIndex = 5
         Me.label3.Text = "A&pplying method"
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Controls.Add(Me._cmbNudgeApplyingMethod)
         Me.groupBox1.Controls.Add(Me._cmbNudgeApplyTo)
         Me.groupBox1.Controls.Add(Me._cmbNudgeMouseButton)
         Me.groupBox1.Location = New System.Drawing.Point(10, 5)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(210, 137)
         Me.groupBox1.TabIndex = 6
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Nudge Properties"
         ' 
         ' _btnApply
         ' 
         Me._btnApply.Location = New System.Drawing.Point(265, 149)
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.Size = New System.Drawing.Size(64, 29)
         Me._btnApply.TabIndex = 17
         Me._btnApply.Text = "App&ly"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(190, 149)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(64, 29)
         Me._btnCancel.TabIndex = 16
         Me._btnCancel.Text = "Canc&el"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.Location = New System.Drawing.Point(118, 149)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(64, 29)
         Me._btnOK.TabIndex = 15
         Me._btnOK.Text = "O&K"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.Controls.Add(Me.label4)
         Me.groupBox2.Controls.Add(Me.label5)
         Me.groupBox2.Controls.Add(Me.label6)
         Me.groupBox2.Controls.Add(Me._cmbShrinkApplyingMethod)
         Me.groupBox2.Controls.Add(Me._cmbShrinkApplyTo)
         Me.groupBox2.Controls.Add(Me._cmbShrinkMouseButton)
         Me.groupBox2.Location = New System.Drawing.Point(226, 5)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(210, 137)
         Me.groupBox2.TabIndex = 7
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "Shrink Properties"
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(14, 105)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(87, 13)
         Me.label4.TabIndex = 5
         Me.label4.Text = "A&pplying method"
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(14, 64)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(47, 13)
         Me.label5.TabIndex = 4
         Me.label5.Text = "&Apply to"
         ' 
         ' label6
         ' 
         Me.label6.AutoSize = True
         Me.label6.Location = New System.Drawing.Point(14, 23)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(73, 13)
         Me.label6.TabIndex = 3
         Me.label6.Text = "&Mouse button"
         ' 
         ' _cmbShrinkApplyingMethod
         ' 
         Me._cmbShrinkApplyingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbShrinkApplyingMethod.FormattingEnabled = True
         Me._cmbShrinkApplyingMethod.Items.AddRange(New Object() {"RealTime"})
         Me._cmbShrinkApplyingMethod.Location = New System.Drawing.Point(107, 101)
         Me._cmbShrinkApplyingMethod.Name = "_cmbShrinkApplyingMethod"
         Me._cmbShrinkApplyingMethod.Size = New System.Drawing.Size(89, 21)
         Me._cmbShrinkApplyingMethod.TabIndex = 2
         ' 
         ' _cmbShrinkApplyTo
         ' 
         Me._cmbShrinkApplyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbShrinkApplyTo.FormattingEnabled = True
         Me._cmbShrinkApplyTo.Items.AddRange(New Object() {"Active Cell"})
         Me._cmbShrinkApplyTo.Location = New System.Drawing.Point(78, 60)
         Me._cmbShrinkApplyTo.Name = "_cmbShrinkApplyTo"
         Me._cmbShrinkApplyTo.Size = New System.Drawing.Size(118, 21)
         Me._cmbShrinkApplyTo.TabIndex = 1
         ' 
         ' _cmbShrinkMouseButton
         ' 
         Me._cmbShrinkMouseButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbShrinkMouseButton.FormattingEnabled = True
         Me._cmbShrinkMouseButton.Items.AddRange(New Object() {"None", "Left Button", "Right Button", "Middle Button"})
         Me._cmbShrinkMouseButton.Location = New System.Drawing.Point(104, 19)
         Me._cmbShrinkMouseButton.Name = "_cmbShrinkMouseButton"
         Me._cmbShrinkMouseButton.Size = New System.Drawing.Size(92, 21)
         Me._cmbShrinkMouseButton.TabIndex = 0
         ' 
         ' SetNudgeShrinkActionDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(446, 185)
         Me.Controls.Add(Me.groupBox2)
         Me.Controls.Add(Me._btnApply)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "SetNudgeShrinkActionDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Set Nudge Tool Action"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _cmbNudgeMouseButton As System.Windows.Forms.ComboBox
      Private WithEvents _cmbNudgeApplyTo As System.Windows.Forms.ComboBox
      Private _cmbNudgeApplyingMethod As System.Windows.Forms.ComboBox
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents _btnApply As System.Windows.Forms.Button
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private groupBox2 As System.Windows.Forms.GroupBox
      Private label4 As System.Windows.Forms.Label
      Private label5 As System.Windows.Forms.Label
      Private label6 As System.Windows.Forms.Label
      Private _cmbShrinkApplyingMethod As System.Windows.Forms.ComboBox
      Private WithEvents _cmbShrinkApplyTo As System.Windows.Forms.ComboBox
      Private WithEvents _cmbShrinkMouseButton As System.Windows.Forms.ComboBox
   End Class
End Namespace
