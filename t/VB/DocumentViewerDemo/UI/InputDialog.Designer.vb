Partial Class InputDialog
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
      Me._okButton = New System.Windows.Forms.Button()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._valueLabel1 = New System.Windows.Forms.Label()
      Me._valueTextBox = New System.Windows.Forms.TextBox()
      Me._valueGroupBox = New System.Windows.Forms.GroupBox()
      Me._valueLabel2 = New System.Windows.Forms.Label()
      Me._valueGroupBox.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _okButton
      ' 
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(415, 28)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 1
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True      ' 
      ' _cancelButton
      ' 
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(415, 57)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 2
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      ' 
      ' _valueLabel1
      ' 
      Me._valueLabel1.Location = New System.Drawing.Point(6, 26)
      Me._valueLabel1.Name = "_valueLabel1"
      Me._valueLabel1.Size = New System.Drawing.Size(382, 13)
      Me._valueLabel1.TabIndex = 0
      Me._valueLabel1.Text = "_valueLabel1"
      ' 
      ' _valueTextBox
      ' 
      Me._valueTextBox.Location = New System.Drawing.Point(6, 61)
      Me._valueTextBox.Name = "_valueTextBox"
      Me._valueTextBox.Size = New System.Drawing.Size(382, 20)
      Me._valueTextBox.TabIndex = 1
      ' 
      ' _valueGroupBox
      ' 
      Me._valueGroupBox.Controls.Add(Me._valueLabel2)
      Me._valueGroupBox.Controls.Add(Me._valueLabel1)
      Me._valueGroupBox.Controls.Add(Me._valueTextBox)
      Me._valueGroupBox.Location = New System.Drawing.Point(12, 12)
      Me._valueGroupBox.Name = "_valueGroupBox"
      Me._valueGroupBox.Size = New System.Drawing.Size(397, 93)
      Me._valueGroupBox.TabIndex = 0
      Me._valueGroupBox.TabStop = False
      Me._valueGroupBox.Text = "_valueGroupBox"
      ' 
      ' _valueLabel2
      ' 
      Me._valueLabel2.Location = New System.Drawing.Point(6, 45)
      Me._valueLabel2.Name = "_valueLabel2"
      Me._valueLabel2.Size = New System.Drawing.Size(382, 13)
      Me._valueLabel2.TabIndex = 2
      Me._valueLabel2.Text = "_valueLabel2"
      ' 
      ' InputDialog
      ' 
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(502, 115)
      Me.Controls.Add(Me._valueGroupBox)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._okButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "InputDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "InputDialog"
      Me._valueGroupBox.ResumeLayout(False)
      Me._valueGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private WithEvents _okButton As System.Windows.Forms.Button
   Private _cancelButton As System.Windows.Forms.Button
   Private _valueLabel1 As System.Windows.Forms.Label
   Private _valueTextBox As System.Windows.Forms.TextBox
   Private _valueGroupBox As System.Windows.Forms.GroupBox
   Private _valueLabel2 As System.Windows.Forms.Label
End Class
