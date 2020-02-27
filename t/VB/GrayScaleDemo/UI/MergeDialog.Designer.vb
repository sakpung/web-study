
Partial Class MergeDialog
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
      Me._cLbImages = New System.Windows.Forms.CheckedListBox()
      Me._rbSCT = New System.Windows.Forms.RadioButton()
      Me._rbYCRCB = New System.Windows.Forms.RadioButton()
      Me._rbLAB = New System.Windows.Forms.RadioButton()
      Me._rbXYZ = New System.Windows.Forms.RadioButton()
      Me._rbYUV = New System.Windows.Forms.RadioButton()
      Me._rbCMY = New System.Windows.Forms.RadioButton()
      Me._rbHLS = New System.Windows.Forms.RadioButton()
      Me._rbHSV = New System.Windows.Forms.RadioButton()
      Me._rbCMYK = New System.Windows.Forms.RadioButton()
      Me._rbRGB = New System.Windows.Forms.RadioButton()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._gbMergeType = New System.Windows.Forms.GroupBox()
      Me._gbMergeType.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _cLbImages
      ' 
      Me._cLbImages.FormattingEnabled = True
      Me._cLbImages.Location = New System.Drawing.Point(153, 16)
      Me._cLbImages.Name = "_cLbImages"
      Me._cLbImages.Size = New System.Drawing.Size(754, 244)
      Me._cLbImages.TabIndex = 0
      ' 
      ' _rbSCT
      ' 
      Me._rbSCT.AutoSize = True
      Me._rbSCT.Location = New System.Drawing.Point(22, 226)
      Me._rbSCT.Name = "_rbSCT"
      Me._rbSCT.Size = New System.Drawing.Size(46, 17)
      Me._rbSCT.TabIndex = 9
      Me._rbSCT.TabStop = True
      Me._rbSCT.Text = "SCT"
      Me._rbSCT.UseVisualStyleBackColor = True
      ' 
      ' _rbYCRCB
      ' 
      Me._rbYCRCB.AutoSize = True
      Me._rbYCRCB.Location = New System.Drawing.Point(21, 203)
      Me._rbYCRCB.Name = "_rbYCRCB"
      Me._rbYCRCB.Size = New System.Drawing.Size(61, 17)
      Me._rbYCRCB.TabIndex = 8
      Me._rbYCRCB.TabStop = True
      Me._rbYCRCB.Text = "YCRCB"
      Me._rbYCRCB.UseVisualStyleBackColor = True
      ' 
      ' _rbLAB
      ' 
      Me._rbLAB.AutoSize = True
      Me._rbLAB.Location = New System.Drawing.Point(21, 180)
      Me._rbLAB.Name = "_rbLAB"
      Me._rbLAB.Size = New System.Drawing.Size(48, 17)
      Me._rbLAB.TabIndex = 7
      Me._rbLAB.TabStop = True
      Me._rbLAB.Text = "LAB "
      Me._rbLAB.UseVisualStyleBackColor = True
      ' 
      ' _rbXYZ
      ' 
      Me._rbXYZ.AutoSize = True
      Me._rbXYZ.Location = New System.Drawing.Point(21, 157)
      Me._rbXYZ.Name = "_rbXYZ"
      Me._rbXYZ.Size = New System.Drawing.Size(46, 17)
      Me._rbXYZ.TabIndex = 6
      Me._rbXYZ.TabStop = True
      Me._rbXYZ.Text = "XYZ"
      Me._rbXYZ.UseVisualStyleBackColor = True
      ' 
      ' _rbYUV
      ' 
      Me._rbYUV.AutoSize = True
      Me._rbYUV.Location = New System.Drawing.Point(21, 134)
      Me._rbYUV.Name = "_rbYUV"
      Me._rbYUV.Size = New System.Drawing.Size(47, 17)
      Me._rbYUV.TabIndex = 5
      Me._rbYUV.TabStop = True
      Me._rbYUV.Text = "YUV"
      Me._rbYUV.UseVisualStyleBackColor = True
      ' 
      ' _rbCMY
      ' 
      Me._rbCMY.AutoSize = True
      Me._rbCMY.Location = New System.Drawing.Point(21, 111)
      Me._rbCMY.Name = "_rbCMY"
      Me._rbCMY.Size = New System.Drawing.Size(48, 17)
      Me._rbCMY.TabIndex = 4
      Me._rbCMY.TabStop = True
      Me._rbCMY.Text = "CMY"
      Me._rbCMY.UseVisualStyleBackColor = True
      ' 
      ' _rbHLS
      ' 
      Me._rbHLS.AutoSize = True
      Me._rbHLS.Location = New System.Drawing.Point(21, 88)
      Me._rbHLS.Name = "_rbHLS"
      Me._rbHLS.Size = New System.Drawing.Size(46, 17)
      Me._rbHLS.TabIndex = 3
      Me._rbHLS.TabStop = True
      Me._rbHLS.Text = "HLS"
      Me._rbHLS.UseVisualStyleBackColor = True
      ' 
      ' _rbHSV
      ' 
      Me._rbHSV.AutoSize = True
      Me._rbHSV.Location = New System.Drawing.Point(21, 65)
      Me._rbHSV.Name = "_rbHSV"
      Me._rbHSV.Size = New System.Drawing.Size(47, 17)
      Me._rbHSV.TabIndex = 2
      Me._rbHSV.TabStop = True
      Me._rbHSV.Text = "HSV"
      Me._rbHSV.UseVisualStyleBackColor = True
      ' 
      ' _rbCMYK
      ' 
      Me._rbCMYK.AutoSize = True
      Me._rbCMYK.Location = New System.Drawing.Point(21, 42)
      Me._rbCMYK.Name = "_rbCMYK"
      Me._rbCMYK.Size = New System.Drawing.Size(55, 17)
      Me._rbCMYK.TabIndex = 1
      Me._rbCMYK.TabStop = True
      Me._rbCMYK.Text = "CMYK"
      Me._rbCMYK.UseVisualStyleBackColor = True
      ' 
      ' _rbRGB
      ' 
      Me._rbRGB.AutoSize = True
      Me._rbRGB.Location = New System.Drawing.Point(21, 19)
      Me._rbRGB.Name = "_rbRGB"
      Me._rbRGB.Size = New System.Drawing.Size(48, 17)
      Me._rbRGB.TabIndex = 0
      Me._rbRGB.TabStop = True
      Me._rbRGB.Text = "RGB"
      Me._rbRGB.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.Location = New System.Drawing.Point(790, 267)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(56, 27)
      Me._btnOk.TabIndex = 2
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.Location = New System.Drawing.Point(852, 267)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(55, 26)
      Me._btnCancel.TabIndex = 3
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _gbMergeType
      ' 
      Me._gbMergeType.Controls.Add(Me._rbRGB)
      Me._gbMergeType.Controls.Add(Me._rbSCT)
      Me._gbMergeType.Controls.Add(Me._rbHSV)
      Me._gbMergeType.Controls.Add(Me._rbHLS)
      Me._gbMergeType.Controls.Add(Me._rbYCRCB)
      Me._gbMergeType.Controls.Add(Me._rbCMYK)
      Me._gbMergeType.Controls.Add(Me._rbCMY)
      Me._gbMergeType.Controls.Add(Me._rbLAB)
      Me._gbMergeType.Controls.Add(Me._rbYUV)
      Me._gbMergeType.Controls.Add(Me._rbXYZ)
      Me._gbMergeType.Location = New System.Drawing.Point(14, 10)
      Me._gbMergeType.Name = "_gbMergeType"
      Me._gbMergeType.Size = New System.Drawing.Size(123, 250)
      Me._gbMergeType.TabIndex = 10
      Me._gbMergeType.TabStop = False
      Me._gbMergeType.Text = "Merge Type :"
      ' 
      ' MergeDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(919, 302)
      Me.Controls.Add(Me._gbMergeType)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._cLbImages)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "MergeDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Merge"
      Me._gbMergeType.ResumeLayout(False)
      Me._gbMergeType.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _cLbImages As System.Windows.Forms.CheckedListBox
   Private WithEvents _rbCMY As System.Windows.Forms.RadioButton
   Private WithEvents _rbHLS As System.Windows.Forms.RadioButton
   Private WithEvents _rbHSV As System.Windows.Forms.RadioButton
   Private WithEvents _rbCMYK As System.Windows.Forms.RadioButton
   Private WithEvents _rbRGB As System.Windows.Forms.RadioButton
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _rbSCT As System.Windows.Forms.RadioButton
   Private WithEvents _rbYCRCB As System.Windows.Forms.RadioButton
   Private WithEvents _rbLAB As System.Windows.Forms.RadioButton
   Private WithEvents _rbXYZ As System.Windows.Forms.RadioButton
   Private WithEvents _rbYUV As System.Windows.Forms.RadioButton
   Private _gbMergeType As System.Windows.Forms.GroupBox
End Class