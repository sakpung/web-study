Imports Microsoft.VisualBasic

Namespace PDFDocumentDemo
   Partial Class SignatureValidationStatusDialog
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
         Me._closeButton = New System.Windows.Forms.Button()
         Me._signaturePropertiesButton = New System.Windows.Forms.Button()
         Me._infoLabel = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' _closeButton
         ' 
         Me._closeButton.Location = New System.Drawing.Point(461, 90)
         Me._closeButton.Name = "_closeButton"
         Me._closeButton.Size = New System.Drawing.Size(75, 23)
         Me._closeButton.TabIndex = 0
         Me._closeButton.Text = "&Close"
         Me._closeButton.UseVisualStyleBackColor = True
         ' 
         ' _signaturePropertiesButton
         ' 
         Me._signaturePropertiesButton.Location = New System.Drawing.Point(264, 90)
         Me._signaturePropertiesButton.Name = "_signaturePropertiesButton"
         Me._signaturePropertiesButton.Size = New System.Drawing.Size(191, 23)
         Me._signaturePropertiesButton.TabIndex = 1
         Me._signaturePropertiesButton.Text = "&Signature Properties..."
         Me._signaturePropertiesButton.UseVisualStyleBackColor = True
         ' 
         ' _infoLabel
         ' 
         Me._infoLabel.AutoSize = True
         Me._infoLabel.Font = New System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
         Me._infoLabel.Location = New System.Drawing.Point(12, 9)
         Me._infoLabel.Name = "_infoLabel"
         Me._infoLabel.Size = New System.Drawing.Size(425, 48)
         Me._infoLabel.TabIndex = 2
         Me._infoLabel.Text = "Signature validity is {0}. " & Constants.vbCr & Constants.vbLf & Constants.vbCr & Constants.vbLf & "- The Document has not been modified since this si" + "gnature was applied. "
         ' 
         ' SignatureValidationStatusDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(544, 121)
         Me.ControlBox = False
         Me.Controls.Add(Me._infoLabel)
         Me.Controls.Add(Me._signaturePropertiesButton)
         Me.Controls.Add(Me._closeButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
         Me.Name = "SignatureValidationStatusDialog"
         Me.ShowIcon = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Signature Validation Status"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private WithEvents _closeButton As System.Windows.Forms.Button
      Private WithEvents _signaturePropertiesButton As System.Windows.Forms.Button
      Private _infoLabel As System.Windows.Forms.Label
   End Class
End Namespace