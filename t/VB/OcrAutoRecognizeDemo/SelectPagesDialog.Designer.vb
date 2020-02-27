<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectPagesDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
      Me._lastPageCheckBox = New System.Windows.Forms.CheckBox
      Me._allPagesCheckBox = New System.Windows.Forms.CheckBox
      Me._toPageTextBox = New System.Windows.Forms.TextBox
      Me._okButton = New System.Windows.Forms.Button
      Me._toPageLabel = New System.Windows.Forms.Label
      Me._fromPageTextBox = New System.Windows.Forms.TextBox
      Me._fromLabel = New System.Windows.Forms.Label
      Me._pagesGroupBox = New System.Windows.Forms.GroupBox
      Me._cancelButton = New System.Windows.Forms.Button
      Me._pagesGroupBox.SuspendLayout()
      Me.SuspendLayout()
      '
      '_lastPageCheckBox
      '
      Me._lastPageCheckBox.AutoSize = True
      Me._lastPageCheckBox.Location = New System.Drawing.Point(99, 104)
      Me._lastPageCheckBox.Name = "_lastPageCheckBox"
      Me._lastPageCheckBox.Size = New System.Drawing.Size(73, 17)
      Me._lastPageCheckBox.TabIndex = 5
      Me._lastPageCheckBox.Text = "Last page"
      Me._lastPageCheckBox.UseVisualStyleBackColor = True
      '
      '_allPagesCheckBox
      '
      Me._allPagesCheckBox.AutoSize = True
      Me._allPagesCheckBox.Location = New System.Drawing.Point(24, 19)
      Me._allPagesCheckBox.Name = "_allPagesCheckBox"
      Me._allPagesCheckBox.Size = New System.Drawing.Size(69, 17)
      Me._allPagesCheckBox.TabIndex = 0
      Me._allPagesCheckBox.Text = "All pages"
      Me._allPagesCheckBox.UseVisualStyleBackColor = True
      '
      '_toPageTextBox
      '
      Me._toPageTextBox.Location = New System.Drawing.Point(99, 77)
      Me._toPageTextBox.Name = "_toPageTextBox"
      Me._toPageTextBox.Size = New System.Drawing.Size(100, 20)
      Me._toPageTextBox.TabIndex = 4
      '
      '_okButton
      '
      Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._okButton.Location = New System.Drawing.Point(294, 25)
      Me._okButton.Name = "_okButton"
      Me._okButton.Size = New System.Drawing.Size(75, 23)
      Me._okButton.TabIndex = 1
      Me._okButton.Text = "OK"
      Me._okButton.UseVisualStyleBackColor = True
      '
      '_toPageLabel
      '
      Me._toPageLabel.AutoSize = True
      Me._toPageLabel.Location = New System.Drawing.Point(43, 77)
      Me._toPageLabel.Name = "_toPageLabel"
      Me._toPageLabel.Size = New System.Drawing.Size(50, 13)
      Me._toPageLabel.TabIndex = 3
      Me._toPageLabel.Text = "To page:"
      '
      '_fromPageTextBox
      '
      Me._fromPageTextBox.Location = New System.Drawing.Point(99, 51)
      Me._fromPageTextBox.Name = "_fromPageTextBox"
      Me._fromPageTextBox.Size = New System.Drawing.Size(100, 20)
      Me._fromPageTextBox.TabIndex = 2
      '
      '_fromLabel
      '
      Me._fromLabel.AutoSize = True
      Me._fromLabel.Location = New System.Drawing.Point(33, 54)
      Me._fromLabel.Name = "_fromLabel"
      Me._fromLabel.Size = New System.Drawing.Size(60, 13)
      Me._fromLabel.TabIndex = 1
      Me._fromLabel.Text = "From page:"
      '
      '_pagesGroupBox
      '
      Me._pagesGroupBox.Controls.Add(Me._lastPageCheckBox)
      Me._pagesGroupBox.Controls.Add(Me._allPagesCheckBox)
      Me._pagesGroupBox.Controls.Add(Me._toPageTextBox)
      Me._pagesGroupBox.Controls.Add(Me._toPageLabel)
      Me._pagesGroupBox.Controls.Add(Me._fromPageTextBox)
      Me._pagesGroupBox.Controls.Add(Me._fromLabel)
      Me._pagesGroupBox.Location = New System.Drawing.Point(12, 12)
      Me._pagesGroupBox.Name = "_pagesGroupBox"
      Me._pagesGroupBox.Size = New System.Drawing.Size(267, 138)
      Me._pagesGroupBox.TabIndex = 0
      Me._pagesGroupBox.TabStop = False
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(294, 54)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 2
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      'SelectPagesDialog
      '
      Me.AcceptButton = Me._okButton
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(382, 166)
      Me.Controls.Add(Me._okButton)
      Me.Controls.Add(Me._pagesGroupBox)
      Me.Controls.Add(Me._cancelButton)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "SelectPagesDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Select Image Pages"
      Me._pagesGroupBox.ResumeLayout(False)
      Me._pagesGroupBox.PerformLayout()
      Me.ResumeLayout(False)

   End Sub
   Private WithEvents _lastPageCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _allPagesCheckBox As System.Windows.Forms.CheckBox
   Private WithEvents _toPageTextBox As System.Windows.Forms.TextBox
   Private WithEvents _okButton As System.Windows.Forms.Button
   Private WithEvents _toPageLabel As System.Windows.Forms.Label
   Private WithEvents _fromPageTextBox As System.Windows.Forms.TextBox
   Private WithEvents _fromLabel As System.Windows.Forms.Label
   Private WithEvents _pagesGroupBox As System.Windows.Forms.GroupBox
   Private WithEvents _cancelButton As System.Windows.Forms.Button
End Class
