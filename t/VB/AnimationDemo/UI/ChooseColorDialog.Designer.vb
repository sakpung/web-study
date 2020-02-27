
Namespace AnimationDemo
   Partial Class ChooseColorDialog
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
         Me._gpBitmapColors = New System.Windows.Forms.GroupBox()
         Me._gpCurrentColor = New System.Windows.Forms.GroupBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me._gpRGB = New System.Windows.Forms.GroupBox()
         Me._txtBlue = New System.Windows.Forms.TextBox()
         Me._txtGreen = New System.Windows.Forms.TextBox()
         Me._txtRed = New System.Windows.Forms.TextBox()
         Me._lblBlue = New System.Windows.Forms.Label()
         Me._lblGreen = New System.Windows.Forms.Label()
         Me._lblRed = New System.Windows.Forms.Label()
         Me.panel1 = New System.Windows.Forms.Panel()
         Me._btnOK = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._gpCurrentColor.SuspendLayout()
         Me._gpRGB.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _gpBitmapColors
         ' 
         Me._gpBitmapColors.Location = New System.Drawing.Point(12, 8)
         Me._gpBitmapColors.Name = "_gpBitmapColors"
         Me._gpBitmapColors.Size = New System.Drawing.Size(400, 44)
         Me._gpBitmapColors.TabIndex = 0
         Me._gpBitmapColors.TabStop = False
         Me._gpBitmapColors.Text = "Bitmap Colors"
         ' 
         ' _gpCurrentColor
         ' 
         Me._gpCurrentColor.Controls.Add(Me.label1)
         Me._gpCurrentColor.Controls.Add(Me._gpRGB)
         Me._gpCurrentColor.Controls.Add(Me.panel1)
         Me._gpCurrentColor.Location = New System.Drawing.Point(12, 68)
         Me._gpCurrentColor.Name = "_gpCurrentColor"
         Me._gpCurrentColor.Size = New System.Drawing.Size(314, 113)
         Me._gpCurrentColor.TabIndex = 1
         Me._gpCurrentColor.TabStop = False
         Me._gpCurrentColor.Text = "Bitmap Colors"
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(13, 49)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(34, 13)
         Me.label1.TabIndex = 8
         Me.label1.Text = "Color:"
         ' 
         ' _gpRGB
         ' 
         Me._gpRGB.Controls.Add(Me._txtBlue)
         Me._gpRGB.Controls.Add(Me._txtGreen)
         Me._gpRGB.Controls.Add(Me._txtRed)
         Me._gpRGB.Controls.Add(Me._lblBlue)
         Me._gpRGB.Controls.Add(Me._lblGreen)
         Me._gpRGB.Controls.Add(Me._lblRed)
         Me._gpRGB.Location = New System.Drawing.Point(198, 13)
         Me._gpRGB.Name = "_gpRGB"
         Me._gpRGB.Size = New System.Drawing.Size(107, 94)
         Me._gpRGB.TabIndex = 7
         Me._gpRGB.TabStop = False
         ' 
         ' _txtBlue
         ' 
         Me._txtBlue.Location = New System.Drawing.Point(53, 62)
         Me._txtBlue.Name = "_txtBlue"
         Me._txtBlue.[ReadOnly] = True
         Me._txtBlue.Size = New System.Drawing.Size(48, 20)
         Me._txtBlue.TabIndex = 6
         ' 
         ' _txtGreen
         ' 
         Me._txtGreen.Location = New System.Drawing.Point(53, 38)
         Me._txtGreen.Name = "_txtGreen"
         Me._txtGreen.[ReadOnly] = True
         Me._txtGreen.Size = New System.Drawing.Size(48, 20)
         Me._txtGreen.TabIndex = 5
         ' 
         ' _txtRed
         ' 
         Me._txtRed.Location = New System.Drawing.Point(53, 14)
         Me._txtRed.Name = "_txtRed"
         Me._txtRed.[ReadOnly] = True
         Me._txtRed.Size = New System.Drawing.Size(48, 20)
         Me._txtRed.TabIndex = 4
         ' 
         ' _lblBlue
         ' 
         Me._lblBlue.AutoSize = True
         Me._lblBlue.Location = New System.Drawing.Point(11, 65)
         Me._lblBlue.Name = "_lblBlue"
         Me._lblBlue.Size = New System.Drawing.Size(31, 13)
         Me._lblBlue.TabIndex = 3
         Me._lblBlue.Text = "Blue:"
         ' 
         ' _lblGreen
         ' 
         Me._lblGreen.AutoSize = True
         Me._lblGreen.Location = New System.Drawing.Point(11, 41)
         Me._lblGreen.Name = "_lblGreen"
         Me._lblGreen.Size = New System.Drawing.Size(39, 13)
         Me._lblGreen.TabIndex = 2
         Me._lblGreen.Text = "Green:"
         ' 
         ' _lblRed
         ' 
         Me._lblRed.AutoSize = True
         Me._lblRed.Location = New System.Drawing.Point(11, 17)
         Me._lblRed.Name = "_lblRed"
         Me._lblRed.Size = New System.Drawing.Size(30, 13)
         Me._lblRed.TabIndex = 1
         Me._lblRed.Text = "Red:"
         ' 
         ' panel1
         ' 
         Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         Me.panel1.Location = New System.Drawing.Point(63, 30)
         Me.panel1.Name = "panel1"
         Me.panel1.Size = New System.Drawing.Size(119, 62)
         Me.panel1.TabIndex = 0
         ' 
         ' _btnOK
         ' 
         Me._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOK.Location = New System.Drawing.Point(337, 83)
         Me._btnOK.Name = "_btnOK"
         Me._btnOK.Size = New System.Drawing.Size(75, 23)
         Me._btnOK.TabIndex = 0
         Me._btnOK.Text = "&OK"
         Me._btnOK.UseVisualStyleBackColor = True
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.Location = New System.Drawing.Point(337, 112)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(75, 23)
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "&Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         ' 
         ' ChooseColorDialog
         ' 
         Me.AcceptButton = Me._btnOK
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(421, 199)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOK)
         Me.Controls.Add(Me._gpCurrentColor)
         Me.Controls.Add(Me._gpBitmapColors)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ChooseColorDialog"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Choose color"
         Me._gpCurrentColor.ResumeLayout(False)
         Me._gpCurrentColor.PerformLayout()
         Me._gpRGB.ResumeLayout(False)
         Me._gpRGB.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _gpBitmapColors As System.Windows.Forms.GroupBox
      Private _gpCurrentColor As System.Windows.Forms.GroupBox
      Private WithEvents _btnOK As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
      Private panel1 As System.Windows.Forms.Panel
      Private _lblBlue As System.Windows.Forms.Label
      Private _lblGreen As System.Windows.Forms.Label
      Private _lblRed As System.Windows.Forms.Label
      Private _gpRGB As System.Windows.Forms.GroupBox
      Private _txtBlue As System.Windows.Forms.TextBox
      Private _txtGreen As System.Windows.Forms.TextBox
      Private _txtRed As System.Windows.Forms.TextBox
      Private label1 As System.Windows.Forms.Label
   End Class
End Namespace