
Partial Class OmrSensitivityDialog
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
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me._rbHighest = New System.Windows.Forms.RadioButton()
      Me._rbHigh = New System.Windows.Forms.RadioButton()
      Me._rbLow = New System.Windows.Forms.RadioButton()
      Me._rbLowest = New System.Windows.Forms.RadioButton()
      Me.groupBox1.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _btnOk
      ' 
      Me._btnOk.Location = New System.Drawing.Point(12, 158)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(93, 29)
      Me._btnOk.TabIndex = 0
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.Location = New System.Drawing.Point(123, 158)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(86, 28)
      Me._btnCancel.TabIndex = 1
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.Add(Me._rbHighest)
      Me.groupBox1.Controls.Add(Me._rbHigh)
      Me.groupBox1.Controls.Add(Me._rbLow)
      Me.groupBox1.Controls.Add(Me._rbLowest)
      Me.groupBox1.Location = New System.Drawing.Point(12, 12)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(197, 126)
      Me.groupBox1.TabIndex = 7
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Sensitivity"
      ' 
      ' _rbHighest
      ' 
      Me._rbHighest.AutoSize = True
      Me._rbHighest.Location = New System.Drawing.Point(16, 94)
      Me._rbHighest.Name = "_rbHighest"
      Me._rbHighest.Size = New System.Drawing.Size(61, 17)
      Me._rbHighest.TabIndex = 13
      Me._rbHighest.Text = "Highest"
      Me._rbHighest.UseVisualStyleBackColor = True
      ' 
      ' _rbHigh
      ' 
      Me._rbHigh.AutoSize = True
      Me._rbHigh.Checked = True
      Me._rbHigh.Location = New System.Drawing.Point(16, 71)
      Me._rbHigh.Name = "_rbHigh"
      Me._rbHigh.Size = New System.Drawing.Size(47, 17)
      Me._rbHigh.TabIndex = 12
      Me._rbHigh.TabStop = True
      Me._rbHigh.Text = "High"
      Me._rbHigh.UseVisualStyleBackColor = True
      ' 
      ' _rbLow
      ' 
      Me._rbLow.AutoSize = True
      Me._rbLow.Location = New System.Drawing.Point(16, 48)
      Me._rbLow.Name = "_rbLow"
      Me._rbLow.Size = New System.Drawing.Size(45, 17)
      Me._rbLow.TabIndex = 11
      Me._rbLow.Text = "Low"
      Me._rbLow.UseVisualStyleBackColor = True
      ' 
      ' _rbLowest
      ' 
      Me._rbLowest.AutoSize = True
      Me._rbLowest.Location = New System.Drawing.Point(16, 25)
      Me._rbLowest.Name = "_rbLowest"
      Me._rbLowest.Size = New System.Drawing.Size(59, 17)
      Me._rbLowest.TabIndex = 10
      Me._rbLowest.Text = "Lowest"
      Me._rbLowest.UseVisualStyleBackColor = True
      ' 
      ' OmrSensitivityDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(228, 200)
      Me.Controls.Add(Me.groupBox1)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "OmrSensitivityDialog"
      Me.ShowIcon = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "OmrSensitivityDialog"
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
   Private WithEvents _rbHighest As System.Windows.Forms.RadioButton
   Private WithEvents _rbHigh As System.Windows.Forms.RadioButton
   Private WithEvents _rbLow As System.Windows.Forms.RadioButton
   Private WithEvents _rbLowest As System.Windows.Forms.RadioButton
End Class