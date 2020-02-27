Namespace SvgDemo
   Partial Class SelectPage
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
         Me._selectPageGroupBox = New System.Windows.Forms.GroupBox()
         Me._pageNumberTextBox = New System.Windows.Forms.TextBox()
         Me._pageNumberLabel = New System.Windows.Forms.Label()
         Me._okButton = New System.Windows.Forms.Button()
         Me._cancelButton = New System.Windows.Forms.Button()
         Me._selectPageGroupBox.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _selectPageGroupBox
         ' 
         Me._selectPageGroupBox.Controls.Add(Me._pageNumberTextBox)
         Me._selectPageGroupBox.Controls.Add(Me._pageNumberLabel)
         Me._selectPageGroupBox.Location = New System.Drawing.Point(12, 12)
         Me._selectPageGroupBox.Name = "_selectPageGroupBox"
         Me._selectPageGroupBox.Size = New System.Drawing.Size(203, 73)
         Me._selectPageGroupBox.TabIndex = 1
         Me._selectPageGroupBox.TabStop = False
         Me._selectPageGroupBox.Text = "Select page to view"
         ' 
         ' _pageNumberTextBox
         ' 
         Me._pageNumberTextBox.Location = New System.Drawing.Point(87, 35)
         Me._pageNumberTextBox.Name = "_pageNumberTextBox"
         Me._pageNumberTextBox.Size = New System.Drawing.Size(100, 20)
         Me._pageNumberTextBox.TabIndex = 1
         ' 
         ' _pageNumberLabel
         ' 
         Me._pageNumberLabel.AutoSize = True
         Me._pageNumberLabel.Location = New System.Drawing.Point(6, 37)
         Me._pageNumberLabel.Name = "_pageNumberLabel"
         Me._pageNumberLabel.Size = New System.Drawing.Size(75, 13)
         Me._pageNumberLabel.TabIndex = 0
         Me._pageNumberLabel.Text = "Page Number:"
         ' 
         ' _okButton
         ' 
         Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._okButton.Location = New System.Drawing.Point(221, 22)
         Me._okButton.Name = "_okButton"
         Me._okButton.Size = New System.Drawing.Size(75, 23)
         Me._okButton.TabIndex = 2
         Me._okButton.Text = "OK"
         Me._okButton.UseVisualStyleBackColor = True
         ' 
         ' _cancelButton
         ' 
         Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._cancelButton.Location = New System.Drawing.Point(221, 51)
         Me._cancelButton.Name = "_cancelButton"
         Me._cancelButton.Size = New System.Drawing.Size(75, 23)
         Me._cancelButton.TabIndex = 3
         Me._cancelButton.Text = "Cancel"
         Me._cancelButton.UseVisualStyleBackColor = True
         ' 
         ' SelectPage
         ' 
         Me.AcceptButton = Me._okButton
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._cancelButton
         Me.ClientSize = New System.Drawing.Size(307, 100)
         Me.Controls.Add(Me._cancelButton)
         Me.Controls.Add(Me._okButton)
         Me.Controls.Add(Me._selectPageGroupBox)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "SelectPage"
         Me.Text = "SelectPage"
         Me._selectPageGroupBox.ResumeLayout(False)
         Me._selectPageGroupBox.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _selectPageGroupBox As System.Windows.Forms.GroupBox
      Private WithEvents _pageNumberTextBox As System.Windows.Forms.TextBox
      Private _pageNumberLabel As System.Windows.Forms.Label
      Private _okButton As System.Windows.Forms.Button
      Private _cancelButton As System.Windows.Forms.Button
   End Class
End Namespace
