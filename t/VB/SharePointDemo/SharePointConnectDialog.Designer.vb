Imports Microsoft.VisualBasic
Imports System
Namespace SharePointDemo
   Partial Public Class SharePointConnectDialog
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
         Me._cancelButton = New System.Windows.Forms.Button()
         Me._messageLabel = New System.Windows.Forms.Label()
         Me._busyProgressBar = New System.Windows.Forms.ProgressBar()
         Me.SuspendLayout()
         ' 
         ' _cancelButton
         ' 
         Me._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._cancelButton.Location = New System.Drawing.Point(177, 102)
         Me._cancelButton.Name = "_cancelButton"
         Me._cancelButton.Size = New System.Drawing.Size(75, 23)
         Me._cancelButton.TabIndex = 2
         Me._cancelButton.Text = "Cancel"
         Me._cancelButton.UseVisualStyleBackColor = True
         '		 Me._cancelButton.Click += New System.EventHandler(Me._cancelButton_Click);
         ' 
         ' _messageLabel
         ' 
         Me._messageLabel.Location = New System.Drawing.Point(14, 25)
         Me._messageLabel.Name = "_messageLabel"
         Me._messageLabel.Size = New System.Drawing.Size(401, 23)
         Me._messageLabel.TabIndex = 0
         Me._messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' _busyProgressBar
         ' 
         Me._busyProgressBar.Location = New System.Drawing.Point(14, 62)
         Me._busyProgressBar.MarqueeAnimationSpeed = 0
         Me._busyProgressBar.Name = "_busyProgressBar"
         Me._busyProgressBar.Size = New System.Drawing.Size(401, 23)
         Me._busyProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
         Me._busyProgressBar.TabIndex = 1
         ' 
         ' SharePointConnectDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._cancelButton
         Me.ClientSize = New System.Drawing.Size(429, 140)
         Me.Controls.Add(Me._busyProgressBar)
         Me.Controls.Add(Me._messageLabel)
         Me.Controls.Add(Me._cancelButton)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "SharePointConnectDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "SharePoint Demo"
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _cancelButton As System.Windows.Forms.Button
      Private _messageLabel As System.Windows.Forms.Label
      Private _busyProgressBar As System.Windows.Forms.ProgressBar
   End Class
End Namespace