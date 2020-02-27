Partial Class ExportTextDialog
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
      Me._textBox = New System.Windows.Forms.TextBox()
      Me._saveButton = New System.Windows.Forms.Button()
      Me._closeButton = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      ' 
      ' _textBox
      ' 
      Me._textBox.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._textBox.Location = New System.Drawing.Point(13, 13)
      Me._textBox.Multiline = True
      Me._textBox.Name = "_textBox"
      Me._textBox.ReadOnly = True
      Me._textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me._textBox.Size = New System.Drawing.Size(450, 266)
      Me._textBox.TabIndex = 0
      ' 
      ' _saveButton
      ' 
      Me._saveButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._saveButton.Location = New System.Drawing.Point(478, 10)
      Me._saveButton.Name = "_saveButton"
      Me._saveButton.Size = New System.Drawing.Size(75, 23)
      Me._saveButton.TabIndex = 1
      Me._saveButton.Text = "&Save..."
      Me._saveButton.UseVisualStyleBackColor = True
      ' 
      ' _closeButton
      ' 
      Me._closeButton.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
      Me._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._closeButton.Location = New System.Drawing.Point(478, 39)
      Me._closeButton.Name = "_closeButton"
      Me._closeButton.Size = New System.Drawing.Size(75, 23)
      Me._closeButton.TabIndex = 2
      Me._closeButton.Text = "Close"
      Me._closeButton.UseVisualStyleBackColor = True
      ' 
      ' ExportTextDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._closeButton
      Me.ClientSize = New System.Drawing.Size(565, 291)
      Me.Controls.Add(Me._closeButton)
      Me.Controls.Add(Me._saveButton)
      Me.Controls.Add(Me._textBox)
      Me.MinimizeBox = False
      Me.Name = "ExportTextDialog"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Export Text"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _textBox As System.Windows.Forms.TextBox
   Private WithEvents _saveButton As System.Windows.Forms.Button
   Private _closeButton As System.Windows.Forms.Button

End Class
