Namespace OcrDemo
   Partial Class EngineSettingsDialog
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
         Me._descriptionLabel = New System.Windows.Forms.Label()
         Me._ocrEngineSettingsControl = New OcrEngineSettingsControl()
         Me.SuspendLayout()
         ' 
         ' _closeButton
         ' 
         Me._closeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._closeButton.Location = New System.Drawing.Point(452, 324)
         Me._closeButton.Name = "_closeButton"
         Me._closeButton.Size = New System.Drawing.Size(75, 23)
         Me._closeButton.TabIndex = 2
         Me._closeButton.Text = "Close"
         Me._closeButton.UseVisualStyleBackColor = True
         ' 
         ' _descriptionLabel
         ' 
         Me._descriptionLabel.AutoSize = True
         Me._descriptionLabel.Location = New System.Drawing.Point(13, 13)
         Me._descriptionLabel.Name = "_descriptionLabel"
         Me._descriptionLabel.Size = New System.Drawing.Size(150, 13)
         Me._descriptionLabel.TabIndex = 0
         Me._descriptionLabel.Text = "Change OCR Engine Settings:"
         ' 
         ' _ocrEngineSettingsControl
         ' 
         Me._ocrEngineSettingsControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
         Me._ocrEngineSettingsControl.Location = New System.Drawing.Point(16, 45)
         Me._ocrEngineSettingsControl.Name = "_ocrEngineSettingsControl"
         Me._ocrEngineSettingsControl.Size = New System.Drawing.Size(510, 266)
         Me._ocrEngineSettingsControl.TabIndex = 1
         ' 
         ' EngineSettingsDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._closeButton
         Me.ClientSize = New System.Drawing.Size(539, 359)
         Me.Controls.Add(Me._ocrEngineSettingsControl)
         Me.Controls.Add(Me._descriptionLabel)
         Me.Controls.Add(Me._closeButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "EngineSettingsDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "OCR Engine Settings"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private _closeButton As System.Windows.Forms.Button
      Private _descriptionLabel As System.Windows.Forms.Label
      Private _ocrEngineSettingsControl As OcrEngineSettingsControl
   End Class
End Namespace