Namespace OcrDemo
   Partial Class LoadResolutionDialog
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
         Me._cancelButton = New System.Windows.Forms.Button()
         Me._okButton = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._yResolutionTextBox = New System.Windows.Forms.TextBox()
         Me._xResolutionTextBox = New System.Windows.Forms.TextBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label1 = New System.Windows.Forms.Label()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _cancelButton
         ' 
         Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._cancelButton.Location = New System.Drawing.Point(238, 50)
         Me._cancelButton.Name = "_cancelButton"
         Me._cancelButton.Size = New System.Drawing.Size(75, 23)
         Me._cancelButton.TabIndex = 2
         Me._cancelButton.Text = "Cancel"
         Me._cancelButton.UseVisualStyleBackColor = True
         ' 
         ' _okButton
         ' 
         Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._okButton.Location = New System.Drawing.Point(238, 21)
         Me._okButton.Name = "_okButton"
         Me._okButton.Size = New System.Drawing.Size(75, 23)
         Me._okButton.TabIndex = 1
         Me._okButton.Text = "OK"
         Me._okButton.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._yResolutionTextBox)
         Me.groupBox1.Controls.Add(Me._xResolutionTextBox)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(12, 12)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(211, 89)
         Me.groupBox1.TabIndex = 3
         Me.groupBox1.TabStop = False
         ' 
         ' _yResolutionTextBox
         ' 
         Me._yResolutionTextBox.Location = New System.Drawing.Point(88, 52)
         Me._yResolutionTextBox.MaxLength = 5
         Me._yResolutionTextBox.Name = "_yResolutionTextBox"
         Me._yResolutionTextBox.Size = New System.Drawing.Size(100, 20)
         Me._yResolutionTextBox.TabIndex = 3
         ' 
         ' _xResolutionTextBox
         ' 
         Me._xResolutionTextBox.Location = New System.Drawing.Point(88, 26)
         Me._xResolutionTextBox.MaxLength = 5
         Me._xResolutionTextBox.Name = "_xResolutionTextBox"
         Me._xResolutionTextBox.Size = New System.Drawing.Size(100, 20)
         Me._xResolutionTextBox.TabIndex = 2
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(15, 55)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(67, 13)
         Me.label2.TabIndex = 1
         Me.label2.Text = "Y Resolution"
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(15, 29)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(67, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "X Resolution"
         ' 
         ' LoadResolutionDialog
         ' 
         Me.AcceptButton = Me._okButton
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._cancelButton
         Me.ClientSize = New System.Drawing.Size(325, 117)
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me._okButton)
         Me.Controls.Add(Me._cancelButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "LoadResolutionDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "PDF Load Resolution Dialog"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _cancelButton As System.Windows.Forms.Button
      Private WithEvents _okButton As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private _yResolutionTextBox As System.Windows.Forms.TextBox
      Private _xResolutionTextBox As System.Windows.Forms.TextBox
      Private label2 As System.Windows.Forms.Label
      Private label1 As System.Windows.Forms.Label
   End Class
End Namespace
