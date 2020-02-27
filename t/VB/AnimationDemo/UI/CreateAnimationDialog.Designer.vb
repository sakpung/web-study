
Namespace AnimationDemo
   Partial Class CreateAnimationDialog
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
         Me._btnRemove = New System.Windows.Forms.Button()
         Me._btnAdd = New System.Windows.Forms.Button()
         Me._lstSourceImages = New System.Windows.Forms.ListBox()
         Me._lstAnimationImages = New System.Windows.Forms.ListBox()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOk = New System.Windows.Forms.Button()
         Me.SuspendLayout()
         ' 
         ' _btnRemove
         ' 
         Me._btnRemove.Location = New System.Drawing.Point(165, 88)
         Me._btnRemove.Name = "_btnRemove"
         Me._btnRemove.Size = New System.Drawing.Size(45, 24)
         Me._btnRemove.TabIndex = 12
         Me._btnRemove.Text = "<--"
         Me._btnRemove.UseVisualStyleBackColor = True
         ' 
         ' _btnAdd
         ' 
         Me._btnAdd.Location = New System.Drawing.Point(165, 58)
         Me._btnAdd.Name = "_btnAdd"
         Me._btnAdd.Size = New System.Drawing.Size(45, 24)
         Me._btnAdd.TabIndex = 11
         Me._btnAdd.Text = "-->"
         Me._btnAdd.UseVisualStyleBackColor = True
         ' 
         ' _lstSourceImages
         ' 
         Me._lstSourceImages.FormattingEnabled = True
         Me._lstSourceImages.HorizontalScrollbar = True
         Me._lstSourceImages.Location = New System.Drawing.Point(11, 18)
         Me._lstSourceImages.Name = "_lstSourceImages"
         Me._lstSourceImages.Size = New System.Drawing.Size(148, 173)
         Me._lstSourceImages.TabIndex = 10
         ' 
         ' _lstAnimationImages
         ' 
         Me._lstAnimationImages.FormattingEnabled = True
         Me._lstAnimationImages.HorizontalScrollbar = True
         Me._lstAnimationImages.Location = New System.Drawing.Point(216, 18)
         Me._lstAnimationImages.Name = "_lstAnimationImages"
         Me._lstAnimationImages.Size = New System.Drawing.Size(148, 173)
         Me._lstAnimationImages.TabIndex = 9
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(383, 41)
         Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(68, 22)
         Me._btnCancel.TabIndex = 8
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.Enabled = False
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(383, 11)
         Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(68, 22)
         Me._btnOk.TabIndex = 7
         Me._btnOk.Text = "OK"
         Me._btnOk.UseVisualStyleBackColor = True
         ' 
         ' CreateAnimationDialog
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(458, 206)
         Me.Controls.Add(Me._btnRemove)
         Me.Controls.Add(Me._btnAdd)
         Me.Controls.Add(Me._lstSourceImages)
         Me.Controls.Add(Me._lstAnimationImages)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "CreateAnimationDialog"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "CreateAnimationDialog"
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _btnRemove As System.Windows.Forms.Button
      Private WithEvents _btnAdd As System.Windows.Forms.Button
      Private _lstSourceImages As System.Windows.Forms.ListBox
      Private WithEvents _lstAnimationImages As System.Windows.Forms.ListBox
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace