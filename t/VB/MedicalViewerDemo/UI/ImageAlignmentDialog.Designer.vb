Namespace MedicalViewerDemo
   Partial Class ImageAlignmentDialog
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
         Me._btnReset = New System.Windows.Forms.Button()
         Me._bntCancel = New System.Windows.Forms.Button()
         Me._cbTransformation = New System.Windows.Forms.ComboBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' _btnApply
         ' 
         Me._btnApply.Enabled = False
         Me._btnApply.Location = New System.Drawing.Point(27, 76)
         Me._btnApply.Name = "_btnApply"
         Me._btnApply.Size = New System.Drawing.Size(75, 23)
         Me._btnApply.TabIndex = 0
         Me._btnApply.Text = "Apply"
         Me._btnApply.UseVisualStyleBackColor = True
         ' 
         ' _btnReset
         ' 
         Me._btnReset.Location = New System.Drawing.Point(128, 76)
         Me._btnReset.Name = "_btnReset"
         Me._btnReset.Size = New System.Drawing.Size(75, 23)
         Me._btnReset.TabIndex = 1
         Me._btnReset.Text = "Reset"
         Me._btnReset.UseVisualStyleBackColor = True
         ' 
         ' _bntCancel
         ' 
         Me._bntCancel.Location = New System.Drawing.Point(228, 76)
         Me._bntCancel.Name = "_bntCancel"
         Me._bntCancel.Size = New System.Drawing.Size(75, 23)
         Me._bntCancel.TabIndex = 2
         Me._bntCancel.Text = "Cancel"
         Me._bntCancel.UseVisualStyleBackColor = True
         ' 
         ' _cbTransformation
         ' 
         Me._cbTransformation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbTransformation.FormattingEnabled = True
         Me._cbTransformation.Items.AddRange(New Object() {"Unknown ", "XY      ", "RSXY    ", "Affine6 ", "Perspective"})
         Me._cbTransformation.Location = New System.Drawing.Point(169, 27)
         Me._cbTransformation.Name = "_cbTransformation"
         Me._cbTransformation.Size = New System.Drawing.Size(121, 21)
         Me._cbTransformation.TabIndex = 3
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(43, 30)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(104, 13)
         Me.label1.TabIndex = 4
         Me.label1.Text = "Transformation Type"
         ' 
         ' ImageAlignmentDialog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(323, 111)
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me._cbTransformation)
         Me.Controls.Add(Me._bntCancel)
         Me.Controls.Add(Me._btnReset)
         Me.Controls.Add(Me._btnApply)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ImageAlignmentDialog"
         Me.ShowIcon = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
         Me.Text = "Image Alignment"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private WithEvents _btnApply As System.Windows.Forms.Button
      Private WithEvents _btnReset As System.Windows.Forms.Button
      Private WithEvents _bntCancel As System.Windows.Forms.Button
      Private WithEvents _cbTransformation As System.Windows.Forms.ComboBox
      Private label1 As System.Windows.Forms.Label
   End Class
End Namespace
