Namespace OcrDemo
   Partial Class OcrProgressDialog
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
         Me._descriptionLabel = New System.Windows.Forms.Label()
         Me._progressBar = New System.Windows.Forms.ProgressBar()
         Me._panel = New System.Windows.Forms.Panel()
         Me._panel.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _cancelButton
         ' 
         Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._cancelButton.Location = New System.Drawing.Point(172, 76)
         Me._cancelButton.Name = "_cancelButton"
         Me._cancelButton.Size = New System.Drawing.Size(75, 23)
         Me._cancelButton.TabIndex = 2
         Me._cancelButton.Text = "Cancel"
         Me._cancelButton.UseVisualStyleBackColor = True
         ' 
         ' _descriptionLabel
         ' 
         Me._descriptionLabel.Location = New System.Drawing.Point(26, 21)
         Me._descriptionLabel.Name = "_descriptionLabel"
         Me._descriptionLabel.Size = New System.Drawing.Size(367, 23)
         Me._descriptionLabel.TabIndex = 0
         Me._descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _progressBar
         ' 
         Me._progressBar.Location = New System.Drawing.Point(27, 47)
         Me._progressBar.MarqueeAnimationSpeed = 50
         Me._progressBar.Name = "_progressBar"
         Me._progressBar.Size = New System.Drawing.Size(364, 23)
         Me._progressBar.TabIndex = 1
         ' 
         ' _panel
         ' 
         Me._panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me._panel.Controls.Add(Me._descriptionLabel)
         Me._panel.Controls.Add(Me._progressBar)
         Me._panel.Controls.Add(Me._cancelButton)
         Me._panel.Dock = System.Windows.Forms.DockStyle.Fill
         Me._panel.Location = New System.Drawing.Point(0, 0)
         Me._panel.Name = "_panel"
         Me._panel.Size = New System.Drawing.Size(420, 118)
         Me._panel.TabIndex = 3
         ' 
         ' OcrProgressDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._cancelButton
         Me.ClientSize = New System.Drawing.Size(420, 118)
         Me.Controls.Add(Me._panel)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "OcrProgressDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "OcrProgressDialog"
         Me._panel.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _cancelButton As System.Windows.Forms.Button
      Private _descriptionLabel As System.Windows.Forms.Label
      Private _progressBar As System.Windows.Forms.ProgressBar
      Private _panel As System.Windows.Forms.Panel
   End Class
End Namespace
