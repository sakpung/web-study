Namespace MedicalViewerDemo
   Partial Class AngleAnnotationDialog
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
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._lblColor = New System.Windows.Forms.Label()
         Me._btnColor = New System.Windows.Forms.Button()
         Me._cmbApplyTo = New System.Windows.Forms.ComboBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me._btnApply = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOK = New System.Windows.Forms.Button()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._lblColor)
         Me.groupBox1.Controls.Add(Me._btnColor)
         Me.groupBox1.Controls.Add(Me._cmbApplyTo)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(8, 6)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(176, 110)
         Me.groupBox1.TabIndex = 0
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "&Angle Properties"
         ' 
         ' _lblColor
         ' 
         Me._lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._lblColor.Location = New System.Drawing.Point(90, 68)
         Me._lblColor.Name = "_lblColor"
         Me._lblColor.Size = New System.Drawing.Size(60, 26)
         Me._lblColor.TabIndex = 3
         ' 
         ' _btnColor
         ' 
         Me._btnColor.Location = New System.Drawing.Point(19, 68)
         Me._btnColor.Name = "_btnColor"
         Me._btnColor.Size = New System.Drawing.Size(60, 27)
         Me._btnColor.TabIndex = 2
         Me._btnColor.Text = "&Color"
         Me._btnColor.UseVisualStyleBackColor = True
         ' 
         ' _cmbApplyTo
         ' 
         Me._cmbApplyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbApplyTo.FormattingEnabled = True
         Me._cmbApplyTo.Items.AddRange(New Object() {"Selected", "All Angles", "All Objects"})
         Me._cmbApplyTo.Location = New System.Drawing.Point(77, 27)
         Me._cmbApplyTo.Name = "_cmbApplyTo"
         Me._cmbApplyTo.Size = New System.Drawing.Size(75, 21)
         Me._cmbApplyTo.TabIndex = 1
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(22, 30)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(45, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "&Apply to"
         ' 
         ' _btnApply
         ' 
         Me._btnApply.Location = New System.Drawing.Point(129, 122)
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.Size = New System.Drawing.Size(57, 29)
         Me._btnApply.TabIndex = 11
         Me._btnApply.Text = "App&ly"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(68, 122)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(57, 29)
         Me._btnCancel.TabIndex = 10
         Me._btnCancel.Text = "Canc&el"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOK
         ' 
         Me._btnOK.Location = New System.Drawing.Point(7, 122)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(57, 29)
         Me._btnOK.TabIndex = 9
         Me._btnOK.Text = "&OK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' AngleAnnotationDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(192, 156)
         Me.Controls.Add(Me._btnApply)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me.groupBox1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "AngleAnnotationDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Angle Dialog"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private groupBox1 As System.Windows.Forms.GroupBox
      Private _cmbApplyTo As System.Windows.Forms.ComboBox
      Private label1 As System.Windows.Forms.Label
      Private WithEvents _btnApply As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private WithEvents _btnColor As System.Windows.Forms.Button
      Private _lblColor As System.Windows.Forms.Label
   End Class
End Namespace
