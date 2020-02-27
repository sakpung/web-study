
Namespace PDFFormsDemo
   Partial Class GoToPageDailog
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
         Me._pageLabel = New System.Windows.Forms.Label()
         Me._ofLabel = New System.Windows.Forms.Label()
         Me._pagesCountLabel = New System.Windows.Forms.Label()
         Me._pageNumberTextBox = New System.Windows.Forms.TextBox()
         Me._okButton = New System.Windows.Forms.Button()
         Me._cancelButton = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' _pageLabel
         ' 
         Me._pageLabel.AutoSize = True
         Me._pageLabel.Font = New System.Drawing.Font("Tahoma", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me._pageLabel.Location = New System.Drawing.Point(45, 14)
         Me._pageLabel.Name = "_pageLabel"
         Me._pageLabel.Size = New System.Drawing.Size(43, 19)
         Me._pageLabel.TabIndex = 0
         Me._pageLabel.Text = "Page"
         ' 
         ' _ofLabel
         ' 
         Me._ofLabel.AutoSize = True
         Me._ofLabel.Font = New System.Drawing.Font("Tahoma", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me._ofLabel.Location = New System.Drawing.Point(154, 14)
         Me._ofLabel.Name = "_ofLabel"
         Me._ofLabel.Size = New System.Drawing.Size(23, 19)
         Me._ofLabel.TabIndex = 1
         Me._ofLabel.Text = "of"
         ' 
         ' _pagesCountLabel
         ' 
         Me._pagesCountLabel.AutoSize = True
         Me._pagesCountLabel.Font = New System.Drawing.Font("Tahoma", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me._pagesCountLabel.Location = New System.Drawing.Point(183, 14)
         Me._pagesCountLabel.Name = "_pagesCountLabel"
         Me._pagesCountLabel.Size = New System.Drawing.Size(18, 19)
         Me._pagesCountLabel.TabIndex = 2
         Me._pagesCountLabel.Text = "_"
         ' 
         ' _pageNumberTextBox
         ' 
         Me._pageNumberTextBox.Font = New System.Drawing.Font("Tahoma", 12.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me._pageNumberTextBox.Location = New System.Drawing.Point(94, 11)
         Me._pageNumberTextBox.Name = "_pageNumberTextBox"
         Me._pageNumberTextBox.Size = New System.Drawing.Size(54, 27)
         Me._pageNumberTextBox.TabIndex = 3
         Me._pageNumberTextBox.Text = "1"
         ' 
         ' _okButton
         ' 
         Me._okButton.Location = New System.Drawing.Point(21, 44)
         Me._okButton.Name = "_okButton"
         Me._okButton.Size = New System.Drawing.Size(101, 23)
         Me._okButton.TabIndex = 4
         Me._okButton.Text = "Ok"
         Me._okButton.UseVisualStyleBackColor = True
         ' 
         ' _cancelButton
         ' 
         Me._cancelButton.Location = New System.Drawing.Point(128, 44)
         Me._cancelButton.Name = "_cancelButton"
         Me._cancelButton.Size = New System.Drawing.Size(101, 23)
         Me._cancelButton.TabIndex = 5
         Me._cancelButton.Text = "Cancel"
         Me._cancelButton.UseVisualStyleBackColor = True
         ' 
         ' GoToPageDailog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(247, 79)
         Me.ControlBox = False
         Me.Controls.Add(Me._cancelButton)
         Me.Controls.Add(Me._okButton)
         Me.Controls.Add(Me._pageNumberTextBox)
         Me.Controls.Add(Me._pagesCountLabel)
         Me.Controls.Add(Me._ofLabel)
         Me.Controls.Add(Me._pageLabel)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Name = "GoToPageDailog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Go To Page"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _pageLabel As System.Windows.Forms.Label
      Private _ofLabel As System.Windows.Forms.Label
      Private _pagesCountLabel As System.Windows.Forms.Label
      Private _pageNumberTextBox As System.Windows.Forms.TextBox
      Private WithEvents _okButton As System.Windows.Forms.Button
      Private WithEvents _cancelButton As System.Windows.Forms.Button
   End Class
End Namespace