Namespace OcrDemo
   Partial Class SpellCheckEngineDialog
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
         Me._engineComboBox = New System.Windows.Forms.ComboBox()
         Me._enginesGroupBox = New System.Windows.Forms.GroupBox()
         Me._helpButton = New System.Windows.Forms.Button()
         Me._enginesGroupBox.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _cancelButton
         ' 
         Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._cancelButton.Location = New System.Drawing.Point(229, 55)
         Me._cancelButton.Name = "_cancelButton"
         Me._cancelButton.Size = New System.Drawing.Size(75, 23)
         Me._cancelButton.TabIndex = 2
         Me._cancelButton.Text = "Cancel"
         Me._cancelButton.UseVisualStyleBackColor = True
         ' 
         ' _okButton
         ' 
         Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._okButton.Location = New System.Drawing.Point(229, 26)
         Me._okButton.Name = "_okButton"
         Me._okButton.Size = New System.Drawing.Size(75, 23)
         Me._okButton.TabIndex = 1
         Me._okButton.Text = "OK"
         Me._okButton.UseVisualStyleBackColor = True
         ' 
         ' _engineComboBox
         ' 
         Me._engineComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._engineComboBox.FormattingEnabled = True
         Me._engineComboBox.Location = New System.Drawing.Point(23, 38)
         Me._engineComboBox.Name = "_engineComboBox"
         Me._engineComboBox.Size = New System.Drawing.Size(151, 21)
         Me._engineComboBox.TabIndex = 0
         ' 
         ' _enginesGroupBox
         ' 
         Me._enginesGroupBox.Controls.Add(Me._engineComboBox)
         Me._enginesGroupBox.Location = New System.Drawing.Point(12, 12)
         Me._enginesGroupBox.Name = "_enginesGroupBox"
         Me._enginesGroupBox.Size = New System.Drawing.Size(200, 76)
         Me._enginesGroupBox.TabIndex = 0
         Me._enginesGroupBox.TabStop = False
         Me._enginesGroupBox.Text = "Select the OCR spell check engine:"
         ' 
         ' _helpButton
         ' 
         Me._helpButton.Location = New System.Drawing.Point(12, 94)
         Me._helpButton.Name = "_helpButton"
         Me._helpButton.Size = New System.Drawing.Size(75, 23)
         Me._helpButton.TabIndex = 3
         Me._helpButton.Text = "&Help..."
         Me._helpButton.UseVisualStyleBackColor = True
         ' 
         ' SpellCheckEngineDialog
         ' 
         Me.AcceptButton = Me._okButton
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._cancelButton
         Me.ClientSize = New System.Drawing.Size(325, 125)
         Me.Controls.Add(Me._helpButton)
         Me.Controls.Add(Me._enginesGroupBox)
         Me.Controls.Add(Me._okButton)
         Me.Controls.Add(Me._cancelButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "SpellCheckEngineDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "OCR Spell Check Engine"
         Me._enginesGroupBox.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _cancelButton As System.Windows.Forms.Button
      Private WithEvents _okButton As System.Windows.Forms.Button
      Private _engineComboBox As System.Windows.Forms.ComboBox
      Private _enginesGroupBox As System.Windows.Forms.GroupBox
      Private WithEvents _helpButton As System.Windows.Forms.Button
   End Class
End Namespace
