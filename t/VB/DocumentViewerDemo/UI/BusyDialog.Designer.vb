Partial Class BusyDialog
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
      Me._descriptionLabel = New System.Windows.Forms.Label()
      Me._progressBar = New System.Windows.Forms.ProgressBar()
      Me._cancelButton = New System.Windows.Forms.Button()
      Me._cancellingLabel = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      '_descriptionLabel
      '
      Me._descriptionLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._descriptionLabel.Location = New System.Drawing.Point(12, 9)
      Me._descriptionLabel.Name = "_descriptionLabel"
      Me._descriptionLabel.Size = New System.Drawing.Size(367, 113)
      Me._descriptionLabel.TabIndex = 0
      '
      '_progressBar
      '
      Me._progressBar.ImeMode = System.Windows.Forms.ImeMode.NoControl
      Me._progressBar.Location = New System.Drawing.Point(12, 125)
      Me._progressBar.MarqueeAnimationSpeed = 50
      Me._progressBar.Name = "_progressBar"
      Me._progressBar.Size = New System.Drawing.Size(367, 23)
      Me._progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
      Me._progressBar.TabIndex = 1
      '
      '_cancelButton
      '
      Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._cancelButton.Location = New System.Drawing.Point(304, 154)
      Me._cancelButton.Name = "_cancelButton"
      Me._cancelButton.Size = New System.Drawing.Size(75, 23)
      Me._cancelButton.TabIndex = 3
      Me._cancelButton.Text = "Cancel"
      Me._cancelButton.UseVisualStyleBackColor = True
      '
      '_cancellingLabel
      '
      Me._cancellingLabel.AutoSize = True
      Me._cancellingLabel.Location = New System.Drawing.Point(12, 159)
      Me._cancellingLabel.Name = "_cancellingLabel"
      Me._cancellingLabel.Size = New System.Drawing.Size(116, 13)
      Me._cancellingLabel.TabIndex = 2
      Me._cancellingLabel.Text = "Cancelling operation..."
      '
      'BusyDialog
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._cancelButton
      Me.ClientSize = New System.Drawing.Size(391, 188)
      Me.ControlBox = False
      Me.Controls.Add(Me._cancellingLabel)
      Me.Controls.Add(Me._cancelButton)
      Me.Controls.Add(Me._descriptionLabel)
      Me.Controls.Add(Me._progressBar)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "BusyDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "BusyDialog"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private _descriptionLabel As System.Windows.Forms.Label
   Private _progressBar As System.Windows.Forms.ProgressBar
   Private WithEvents _cancelButton As System.Windows.Forms.Button
   Private _cancellingLabel As System.Windows.Forms.Label
End Class
