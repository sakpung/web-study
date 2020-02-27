Namespace MainDemo
   Partial Public Class MagicWandThresholdDialog
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
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._gbOptions = New System.Windows.Forms.GroupBox()
         Me._tbThreshold = New System.Windows.Forms.TrackBar()
         Me._txtThreshold = New System.Windows.Forms.TextBox()
         Me._gbOptions.SuspendLayout()
         CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(205, 55)
         Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(68, 22)
         Me._btnCancel.TabIndex = 5
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(205, 25)
         Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(68, 22)
         Me._btnOk.TabIndex = 4
         Me._btnOk.Text = "OK"
         Me._btnOk.UseVisualStyleBackColor = True
         ' 
         ' _gbOptions
         ' 
         Me._gbOptions.Controls.Add(Me._tbThreshold)
         Me._gbOptions.Controls.Add(Me._txtThreshold)
         Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbOptions.Location = New System.Drawing.Point(8, 11)
         Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
         Me._gbOptions.Size = New System.Drawing.Size(191, 78)
         Me._gbOptions.TabIndex = 1
         Me._gbOptions.TabStop = False
         Me._gbOptions.Text = "Threshold"
         ' 
         ' _tbThreshold
         ' 
         Me._tbThreshold.LargeChange = 1
         Me._tbThreshold.Location = New System.Drawing.Point(10, 23)
         Me._tbThreshold.Margin = New System.Windows.Forms.Padding(2)
         Me._tbThreshold.Maximum = 255
         Me._tbThreshold.Minimum = 1
         Me._tbThreshold.Name = "_tbThreshold"
         Me._tbThreshold.Size = New System.Drawing.Size(117, 45)
         Me._tbThreshold.TabIndex = 2
         Me._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None
         Me._tbThreshold.Value = 5
         ' 
         ' _txtThreshold
         ' 
         Me._txtThreshold.Location = New System.Drawing.Point(131, 23)
         Me._txtThreshold.Margin = New System.Windows.Forms.Padding(2)
         Me._txtThreshold.Name = "_txtThreshold"
         Me._txtThreshold.Size = New System.Drawing.Size(45, 20)
         Me._txtThreshold.TabIndex = 3
         ' 
         ' MagicWandThresholdDialog
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(284, 103)
         Me.Controls.Add(Me._gbOptions)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "MagicWandThresholdDialog"
         Me.Text = "Magic Wand"
         Me._gbOptions.ResumeLayout(False)
         Me._gbOptions.PerformLayout()
         CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _gbOptions As System.Windows.Forms.GroupBox
      Private WithEvents _tbThreshold As System.Windows.Forms.TrackBar
      Private WithEvents _txtThreshold As System.Windows.Forms.TextBox

   End Class

End Namespace