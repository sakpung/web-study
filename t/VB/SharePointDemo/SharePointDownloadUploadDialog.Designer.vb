Imports Microsoft.VisualBasic
Imports System
Namespace SharePointDemo
   Partial Public Class SharePointDownloadUploadDialog
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
         Me._busyProgressBar = New System.Windows.Forms.ProgressBar()
         Me._messageLabel = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' _busyProgressBar
         ' 
         Me._busyProgressBar.Location = New System.Drawing.Point(14, 59)
         Me._busyProgressBar.MarqueeAnimationSpeed = 0
         Me._busyProgressBar.Name = "_busyProgressBar"
         Me._busyProgressBar.Size = New System.Drawing.Size(401, 23)
         Me._busyProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
         Me._busyProgressBar.TabIndex = 4
         ' 
         ' _messageLabel
         ' 
         Me._messageLabel.Location = New System.Drawing.Point(12, 22)
         Me._messageLabel.Name = "_messageLabel"
         Me._messageLabel.Size = New System.Drawing.Size(401, 23)
         Me._messageLabel.TabIndex = 3
         Me._messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
         ' 
         ' SharePointDownloadUploadDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(429, 98)
         Me.ControlBox = False
         Me.Controls.Add(Me._busyProgressBar)
         Me.Controls.Add(Me._messageLabel)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "SharePointDownloadUploadDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "SharePoint Demo"
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _busyProgressBar As System.Windows.Forms.ProgressBar
      Private _messageLabel As System.Windows.Forms.Label
   End Class
End Namespace