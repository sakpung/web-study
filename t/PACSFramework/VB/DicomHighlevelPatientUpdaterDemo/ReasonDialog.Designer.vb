Namespace DicomDemo
   Partial Friend Class ReasonDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReasonDialog))
         Me.textBoxReason = New System.Windows.Forms.TextBox()
         Me.label11 = New System.Windows.Forms.Label()
         Me.ReasonCancelButton = New System.Windows.Forms.Button()
         Me.OkButton = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' textBoxReason
         ' 
         Me.textBoxReason.Location = New System.Drawing.Point(12, 27)
         Me.textBoxReason.Multiline = True
         Me.textBoxReason.Name = "textBoxReason"
         Me.textBoxReason.Size = New System.Drawing.Size(474, 136)
         Me.textBoxReason.TabIndex = 31
         ' 
         ' label11
         ' 
         Me.label11.Location = New System.Drawing.Point(12, 11)
         Me.label11.Name = "label11"
         Me.label11.Size = New System.Drawing.Size(168, 16)
         Me.label11.TabIndex = 30
         Me.label11.Text = "Reason:"
         ' 
         ' ReasonCancelButton
         ' 
         Me.ReasonCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.ReasonCancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me.ReasonCancelButton.Location = New System.Drawing.Point(342, 179)
         Me.ReasonCancelButton.Name = "ReasonCancelButton"
         Me.ReasonCancelButton.Size = New System.Drawing.Size(144, 39)
         Me.ReasonCancelButton.TabIndex = 32
         Me.ReasonCancelButton.Text = "Cancel"
         Me.ReasonCancelButton.UseVisualStyleBackColor = True
         ' 
         ' OkButton
         ' 
         Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me.OkButton.Enabled = False
         Me.OkButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
         Me.OkButton.Location = New System.Drawing.Point(192, 179)
         Me.OkButton.Name = "OkButton"
         Me.OkButton.Size = New System.Drawing.Size(144, 39)
         Me.OkButton.TabIndex = 33
         Me.OkButton.Text = "OK"
         Me.OkButton.UseVisualStyleBackColor = True
         ' 
         ' ReasonDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(498, 226)
         Me.Controls.Add(Me.OkButton)
         Me.Controls.Add(Me.ReasonCancelButton)
         Me.Controls.Add(Me.textBoxReason)
         Me.Controls.Add(Me.label11)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ReasonDialog"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Reason For Requested Procedure"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private WithEvents textBoxReason As System.Windows.Forms.TextBox
      Private label11 As System.Windows.Forms.Label
      Private ReasonCancelButton As System.Windows.Forms.Button
      Private OkButton As System.Windows.Forms.Button
   End Class
End Namespace