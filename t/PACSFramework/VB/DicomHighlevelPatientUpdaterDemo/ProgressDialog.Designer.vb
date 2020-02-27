Namespace DicomDemo
   Partial Friend Class ProgressDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProgressDialog))
         Me.ProgressLabel = New System.Windows.Forms.Label()
         Me.progressBar = New System.Windows.Forms.ProgressBar()
         Me.CancelOperationButton = New System.Windows.Forms.Button()
         Me.ProgressInfoLabel = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' ProgressLabel
         ' 
         resources.ApplyResources(Me.ProgressLabel, "ProgressLabel")
         Me.ProgressLabel.Name = "ProgressLabel"
         ' 
         ' progressBar
         ' 
         resources.ApplyResources(Me.progressBar, "progressBar")
         Me.progressBar.Name = "progressBar"
         ' 
         ' CancelOperationButton
         ' 
         Me.CancelOperationButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
         resources.ApplyResources(Me.CancelOperationButton, "CancelOperationButton")
         Me.CancelOperationButton.Name = "CancelOperationButton"
         Me.CancelOperationButton.UseVisualStyleBackColor = True
         ' 
         ' ProgressInfoLabel
         ' 
         resources.ApplyResources(Me.ProgressInfoLabel, "ProgressInfoLabel")
         Me.ProgressInfoLabel.Name = "ProgressInfoLabel"
         ' 
         ' ProgressDialog
         ' 
         resources.ApplyResources(Me, "$this")
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ControlBox = False
         Me.Controls.Add(Me.ProgressInfoLabel)
         Me.Controls.Add(Me.CancelOperationButton)
         Me.Controls.Add(Me.progressBar)
         Me.Controls.Add(Me.ProgressLabel)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Name = "ProgressDialog"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private ProgressLabel As System.Windows.Forms.Label
      Private progressBar As System.Windows.Forms.ProgressBar
      Private ProgressInfoLabel As System.Windows.Forms.Label
      Private WithEvents CancelOperationButton As System.Windows.Forms.Button
   End Class
End Namespace