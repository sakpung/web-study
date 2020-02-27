Namespace MedicalViewerDemo
   Partial Class ModifyStent
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
         Me._cbFrames = New System.Windows.Forms.CheckedListBox()
         Me._btnOk = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' _cbFrames
         ' 
         Me._cbFrames.FormattingEnabled = True
         Me._cbFrames.Location = New System.Drawing.Point(12, 12)
         Me._cbFrames.Name = "_cbFrames"
         Me._cbFrames.Size = New System.Drawing.Size(227, 244)
         Me._cbFrames.TabIndex = 0
         ' 
         ' _btnOk
         ' 
         Me._btnOk.Location = New System.Drawing.Point(80, 261)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(91, 23)
         Me._btnOk.TabIndex = 1
         Me._btnOk.Text = "Ok"
         Me._btnOk.UseVisualStyleBackColor = True
         ' 
         ' ModifyStent
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(251, 293)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me._cbFrames)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MaximumSize = New System.Drawing.Size(257, 321)
         Me.MinimizeBox = False
         Me.MinimumSize = New System.Drawing.Size(257, 321)
         Me.Name = "ModifyStent"
         Me.ShowIcon = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "Unselect Stent Frames"
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _cbFrames As System.Windows.Forms.CheckedListBox
      Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace
