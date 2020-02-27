
Partial Class SensitivityDialog
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
      Me._gbOptions = New System.Windows.Forms.GroupBox()
      Me._numValue = New System.Windows.Forms.NumericUpDown()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbOptions.SuspendLayout()
      CType(Me._numValue, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me._numValue)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbOptions.Location = New System.Drawing.Point(4, 4)
      Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Size = New System.Drawing.Size(144, 60)
      Me._gbOptions.TabIndex = 6
      Me._gbOptions.TabStop = False
      Me._gbOptions.Text = "Sensitivity"
      ' 
      ' _numValue
      ' 
      Me._numValue.Location = New System.Drawing.Point(14, 30)
      Me._numValue.Margin = New System.Windows.Forms.Padding(2)
      Me._numValue.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numValue.Name = "_numValue"
      Me._numValue.Size = New System.Drawing.Size(116, 20)
      Me._numValue.TabIndex = 0
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(152, 41)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 8
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(152, 11)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 7
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' SensitivityDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(232, 77)
      Me.Controls.Add(Me._gbOptions)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SensitivityDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Sensitivity"
      Me._gbOptions.ResumeLayout(False)
      CType(Me._numValue, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbOptions As System.Windows.Forms.GroupBox
   Private _numValue As System.Windows.Forms.NumericUpDown
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
End Class