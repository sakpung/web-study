Namespace MedicalViewerDemo
   Partial Class StentEnhancementDialog
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
         Me._btnApply = New System.Windows.Forms.Button()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._stentProgressBar = New System.Windows.Forms.ProgressBar()
         Me._btnReset = New System.Windows.Forms.Button()
         Me._btnResetAvg = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' _btnApply
         ' 
         Me._btnApply.Location = New System.Drawing.Point(22, 79)
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.Size = New System.Drawing.Size(75, 23)
         Me._btnApply.TabIndex = 0
         Me._btnApply.Text = "Apply"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' _btnOk
         ' 
         Me._btnOk.Location = New System.Drawing.Point(292, 79)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(75, 23)
         Me._btnOk.TabIndex = 1
         Me._btnOk.Text = "Ok"
         Me._btnOk.UseVisualStyleBackColor = True
         ' 
         ' _stentProgressBar
         ' 
         Me._stentProgressBar.Location = New System.Drawing.Point(22, 31)
         Me._stentProgressBar.Name = "_stentProgressBar"
         Me._stentProgressBar.Size = New System.Drawing.Size(345, 23)
         Me._stentProgressBar.TabIndex = 3
         ' 
         ' _btnReset
         ' 
         Me._btnReset.Enabled = False
         Me._btnReset.Location = New System.Drawing.Point(103, 79)
         Me._btnReset.Name = "_btnReset"
         Me._btnReset.Size = New System.Drawing.Size(90, 23)
         Me._btnReset.TabIndex = 4
         Me._btnReset.Text = "Reset Region"
         Me._btnReset.UseVisualStyleBackColor = True
         ' 
         ' _btnResetAvg
         ' 
         Me._btnResetAvg.Enabled = False
         Me._btnResetAvg.Location = New System.Drawing.Point(199, 79)
         Me._btnResetAvg.Name = "_btnResetAvg"
         Me._btnResetAvg.Size = New System.Drawing.Size(87, 23)
         Me._btnResetAvg.TabIndex = 5
         Me._btnResetAvg.Text = "Reset Avg"
         Me._btnResetAvg.UseVisualStyleBackColor = True
         ' 
         ' StentEnhancementDialog
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(386, 114)
         Me.Controls.Add(Me._btnResetAvg)
         Me.Controls.Add(Me._btnReset)
         Me.Controls.Add(Me._stentProgressBar)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me._btnApply)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "StentEnhancementDialog"
         Me.ShowIcon = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "Stent Enhancement Dialog"
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _btnApply As System.Windows.Forms.Button
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _stentProgressBar As System.Windows.Forms.ProgressBar
      Private WithEvents _btnReset As System.Windows.Forms.Button
      Private WithEvents _btnResetAvg As System.Windows.Forms.Button
   End Class
End Namespace
