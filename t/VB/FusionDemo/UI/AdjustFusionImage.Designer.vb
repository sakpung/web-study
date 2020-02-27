Namespace FusionDemo
   Partial Public Class AdjustFusionImage
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
         Me._btnClose = New System.Windows.Forms.Button()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me._orgImagePalettePreview = New System.Windows.Forms.PictureBox()
         Me.label9 = New System.Windows.Forms.Label()
         Me.label10 = New System.Windows.Forms.Label()
         Me._cmbOrgImagePalette = New System.Windows.Forms.ComboBox()
         Me.label8 = New System.Windows.Forms.Label()
         Me._txtScaleY = New FusionDemo.FNumericTextBox()
         Me._palettePreview = New System.Windows.Forms.PictureBox()
         Me._txtRotate = New FusionDemo.FNumericTextBox()
         Me.label6 = New System.Windows.Forms.Label()
         Me.label4 = New System.Windows.Forms.Label()
         Me._cmbFusedIndex = New System.Windows.Forms.ComboBox()
         Me._txtOffsetY = New FusionDemo.FNumericTextBox()
         Me._txtOffsetX = New FusionDemo.FNumericTextBox()
         Me.label5 = New System.Windows.Forms.Label()
         Me.label7 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me._cmbPalette = New System.Windows.Forms.ComboBox()
         Me.label2 = New System.Windows.Forms.Label()
         Me._txtScaleX = New FusionDemo.FNumericTextBox()
         Me._chkFit = New System.Windows.Forms.CheckBox()
         Me._txtWLCenter = New FusionDemo.NumericTextBox()
         Me._txtWLWidth = New FusionDemo.NumericTextBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me._btnReset = New System.Windows.Forms.Button()
         Me.groupBox1.SuspendLayout()
         CType(Me._orgImagePalettePreview, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me._palettePreview, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnClose
         ' 
         Me._btnClose.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnClose.Location = New System.Drawing.Point(250, 366)
         Me._btnClose.Name = "_btnClose"
         Me._btnClose.Size = New System.Drawing.Size(74, 26)
         Me._btnClose.TabIndex = 11
         Me._btnClose.Text = "&Close"
         Me._btnClose.UseVisualStyleBackColor = True
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me._orgImagePalettePreview)
         Me.groupBox1.Controls.Add(Me.label9)
         Me.groupBox1.Controls.Add(Me.label10)
         Me.groupBox1.Controls.Add(Me._cmbOrgImagePalette)
         Me.groupBox1.Controls.Add(Me.label8)
         Me.groupBox1.Controls.Add(Me._txtScaleY)
         Me.groupBox1.Controls.Add(Me._palettePreview)
         Me.groupBox1.Controls.Add(Me._txtRotate)
         Me.groupBox1.Controls.Add(Me.label6)
         Me.groupBox1.Controls.Add(Me.label4)
         Me.groupBox1.Controls.Add(Me._cmbFusedIndex)
         Me.groupBox1.Controls.Add(Me._txtOffsetY)
         Me.groupBox1.Controls.Add(Me._txtOffsetX)
         Me.groupBox1.Controls.Add(Me.label5)
         Me.groupBox1.Controls.Add(Me.label7)
         Me.groupBox1.Controls.Add(Me.label3)
         Me.groupBox1.Controls.Add(Me._cmbPalette)
         Me.groupBox1.Controls.Add(Me.label2)
         Me.groupBox1.Controls.Add(Me._txtScaleX)
         Me.groupBox1.Controls.Add(Me._chkFit)
         Me.groupBox1.Controls.Add(Me._txtWLCenter)
         Me.groupBox1.Controls.Add(Me._txtWLWidth)
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(10, 8)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(314, 352)
         Me.groupBox1.TabIndex = 20
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "&Fusion Parameters"
         ' 
         ' _orgImagePalettePreview
         ' 
         Me._orgImagePalettePreview.Location = New System.Drawing.Point(162, 96)
         Me._orgImagePalettePreview.Name = "_orgImagePalettePreview"
         Me._orgImagePalettePreview.Size = New System.Drawing.Size(128, 19)
         Me._orgImagePalettePreview.TabIndex = 26
         Me._orgImagePalettePreview.TabStop = False
         ' 
         ' label9
         ' 
         Me.label9.AutoSize = True
         Me.label9.Location = New System.Drawing.Point(65, 98)
         Me.label9.Name = "label9"
         Me.label9.Size = New System.Drawing.Size(82, 13)
         Me.label9.TabIndex = 25
         Me.label9.Text = "Palette Preview"
         ' 
         ' label10
         ' 
         Me.label10.AutoSize = True
         Me.label10.Location = New System.Drawing.Point(106, 65)
         Me.label10.Name = "label10"
         Me.label10.Size = New System.Drawing.Size(41, 13)
         Me.label10.TabIndex = 24
         Me.label10.Text = "Palette"
         ' 
         ' _cmbOrgImagePalette
         ' 
         Me._cmbOrgImagePalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbOrgImagePalette.FormattingEnabled = True
         Me._cmbOrgImagePalette.Items.AddRange(New Object() {"None", "Cool", "CyanHot", "Fire", "ICA2", "Ice", "OrangeHot ", "RainbowRGB", "RedHot", "Spectrum"})
         Me._cmbOrgImagePalette.Location = New System.Drawing.Point(162, 63)
         Me._cmbOrgImagePalette.Name = "_cmbOrgImagePalette"
         Me._cmbOrgImagePalette.Size = New System.Drawing.Size(129, 21)
         Me._cmbOrgImagePalette.TabIndex = 23
         ' 
         ' label8
         ' 
         Me.label8.AutoSize = True
         Me.label8.Location = New System.Drawing.Point(106, 219)
         Me.label8.Name = "label8"
         Me.label8.Size = New System.Drawing.Size(41, 13)
         Me.label8.TabIndex = 22
         Me.label8.Text = "Scale Y"
         ' 
         ' _txtScaleY
         ' 
         Me._txtScaleY.Location = New System.Drawing.Point(163, 217)
         Me._txtScaleY.MaximumAllowed = 1000.0F
         Me._txtScaleY.MinimumAllowed = 1.0F
         Me._txtScaleY.Name = "_txtScaleY"
         Me._txtScaleY.Size = New System.Drawing.Size(51, 20)
         Me._txtScaleY.TabIndex = 4
         Me._txtScaleY.Text = "1"
         Me._txtScaleY.Value = 1.0F
         ' 
         ' _palettePreview
         ' 
         Me._palettePreview.Location = New System.Drawing.Point(162, 161)
         Me._palettePreview.Name = "_palettePreview"
         Me._palettePreview.Size = New System.Drawing.Size(128, 19)
         Me._palettePreview.TabIndex = 20
         Me._palettePreview.TabStop = False
         ' 
         ' _txtRotate
         ' 
         Me._txtRotate.Location = New System.Drawing.Point(162, 286)
         Me._txtRotate.MaximumAllowed = 360.0F
         Me._txtRotate.MinimumAllowed = -360.0F
         Me._txtRotate.Name = "_txtRotate"
         Me._txtRotate.Size = New System.Drawing.Size(51, 20)
         Me._txtRotate.TabIndex = 8
         Me._txtRotate.Text = "1"
         Me._txtRotate.Value = 1.0F
         ' 
         ' label6
         ' 
         Me.label6.AutoSize = True
         Me.label6.Location = New System.Drawing.Point(73, 288)
         Me.label6.Name = "label6"
         Me.label6.Size = New System.Drawing.Size(75, 13)
         Me.label6.TabIndex = 18
         Me.label6.Text = "Rotate Angle°"
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(78, 322)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(69, 13)
         Me.label4.TabIndex = 17
         Me.label4.Text = "Fused Image"
         ' 
         ' _cmbFusedIndex
         ' 
         Me._cmbFusedIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbFusedIndex.FormattingEnabled = True
         Me._cmbFusedIndex.Location = New System.Drawing.Point(162, 319)
         Me._cmbFusedIndex.Name = "_cmbFusedIndex"
         Me._cmbFusedIndex.Size = New System.Drawing.Size(129, 21)
         Me._cmbFusedIndex.TabIndex = 9
         ' 
         ' _txtOffsetY
         ' 
         Me._txtOffsetY.Location = New System.Drawing.Point(240, 252)
         Me._txtOffsetY.MaximumAllowed = 1000.0F
         Me._txtOffsetY.MinimumAllowed = -1000.0F
         Me._txtOffsetY.Name = "_txtOffsetY"
         Me._txtOffsetY.Size = New System.Drawing.Size(51, 20)
         Me._txtOffsetY.TabIndex = 7
         Me._txtOffsetY.Text = "1"
         Me._txtOffsetY.Value = 1.0F
         ' 
         ' _txtOffsetX
         ' 
         Me._txtOffsetX.Location = New System.Drawing.Point(163, 252)
         Me._txtOffsetX.MaximumAllowed = 1000.0F
         Me._txtOffsetX.MinimumAllowed = -1000.0F
         Me._txtOffsetX.Name = "_txtOffsetX"
         Me._txtOffsetX.Size = New System.Drawing.Size(51, 20)
         Me._txtOffsetX.TabIndex = 6
         Me._txtOffsetX.Text = "1"
         Me._txtOffsetX.Value = 1.0F
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(110, 253)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(38, 13)
         Me.label5.TabIndex = 13
         Me.label5.Text = "Offset"
         ' 
         ' label7
         ' 
         Me.label7.AutoSize = True
         Me.label7.Location = New System.Drawing.Point(3, 161)
         Me.label7.Name = "label7"
         Me.label7.Size = New System.Drawing.Size(147, 13)
         Me.label7.TabIndex = 10
         Me.label7.Text = "Fused Image Palette Preview"
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(44, 130)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(106, 13)
         Me.label3.TabIndex = 10
         Me.label3.Text = "Fused Image Palette"
         ' 
         ' _cmbPalette
         ' 
         Me._cmbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbPalette.FormattingEnabled = True
         Me._cmbPalette.Items.AddRange(New Object() {"None", "Cool", "CyanHot", "Fire", "ICA2", "Ice", "OrangeHot ", "RainbowRGB", "RedHot", "Spectrum"})
         Me._cmbPalette.Location = New System.Drawing.Point(162, 128)
         Me._cmbPalette.Name = "_cmbPalette"
         Me._cmbPalette.Size = New System.Drawing.Size(129, 21)
         Me._cmbPalette.TabIndex = 2
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(106, 193)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(41, 13)
         Me.label2.TabIndex = 8
         Me.label2.Text = "Scale X"
         ' 
         ' _txtScaleX
         ' 
         Me._txtScaleX.Location = New System.Drawing.Point(163, 191)
         Me._txtScaleX.MaximumAllowed = 1000.0F
         Me._txtScaleX.MinimumAllowed = 1.0F
         Me._txtScaleX.Name = "_txtScaleX"
         Me._txtScaleX.Size = New System.Drawing.Size(51, 20)
         Me._txtScaleX.TabIndex = 3
         Me._txtScaleX.Text = "1"
         Me._txtScaleX.Value = 1.0F
         ' 
         ' _chkFit
         ' 
         Me._chkFit.AutoSize = True
         Me._chkFit.Location = New System.Drawing.Point(220, 205)
         Me._chkFit.Name = "_chkFit"
         Me._chkFit.Size = New System.Drawing.Size(38, 17)
         Me._chkFit.TabIndex = 5
         Me._chkFit.Text = "&Fit"
         Me._chkFit.UseVisualStyleBackColor = True
         ' 
         ' _txtWLCenter
         ' 
         Me._txtWLCenter.Location = New System.Drawing.Point(240, 28)
         Me._txtWLCenter.MaximumAllowed = 65535
         Me._txtWLCenter.MinimumAllowed = -65535
         Me._txtWLCenter.Name = "_txtWLCenter"
         Me._txtWLCenter.Size = New System.Drawing.Size(51, 20)
         Me._txtWLCenter.TabIndex = 1
         Me._txtWLCenter.Text = "1"
         Me._txtWLCenter.Value = 1
         ' 
         ' _txtWLWidth
         ' 
         Me._txtWLWidth.Location = New System.Drawing.Point(163, 28)
         Me._txtWLWidth.MaximumAllowed = 65535
         Me._txtWLWidth.MinimumAllowed = 0
         Me._txtWLWidth.Name = "_txtWLWidth"
         Me._txtWLWidth.Size = New System.Drawing.Size(51, 20)
         Me._txtWLWidth.TabIndex = 0
         Me._txtWLWidth.Text = "1"
         Me._txtWLWidth.Value = 1
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(77, 30)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(73, 13)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Window Level"
         ' 
         ' _btnReset
         ' 
         Me._btnReset.Location = New System.Drawing.Point(10, 366)
         Me._btnReset.Name = "_btnReset"
         Me._btnReset.Size = New System.Drawing.Size(74, 26)
         Me._btnReset.TabIndex = 10
         Me._btnReset.Text = "&Reset"
         Me._btnReset.UseVisualStyleBackColor = True
         ' 
         ' AdjustFusionImage
         ' 
         Me.AcceptButton = Me._btnClose
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(336, 404)
         Me.Controls.Add(Me._btnReset)
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me._btnClose)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "AdjustFusionImage"
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Fusion Properties"
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         CType(Me._orgImagePalettePreview, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me._palettePreview, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private WithEvents _btnClose As System.Windows.Forms.Button
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents _txtWLCenter As NumericTextBox
      Private WithEvents _txtWLWidth As NumericTextBox
      Private label1 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private WithEvents _cmbPalette As System.Windows.Forms.ComboBox
      Private WithEvents _chkFit As System.Windows.Forms.CheckBox
      Private WithEvents _txtOffsetY As FNumericTextBox
      Private WithEvents _txtOffsetX As FNumericTextBox
      Private label5 As System.Windows.Forms.Label
      Private label4 As System.Windows.Forms.Label
      Private WithEvents _cmbFusedIndex As System.Windows.Forms.ComboBox
      Private WithEvents _txtRotate As FNumericTextBox
      Private label6 As System.Windows.Forms.Label
      Private _palettePreview As System.Windows.Forms.PictureBox
      Private label7 As System.Windows.Forms.Label
      Private label8 As System.Windows.Forms.Label
      Private WithEvents _txtScaleY As FNumericTextBox
      Private label2 As System.Windows.Forms.Label
      Private WithEvents _txtScaleX As FNumericTextBox
      Private WithEvents _btnReset As System.Windows.Forms.Button
      Private _orgImagePalettePreview As System.Windows.Forms.PictureBox
      Private label9 As System.Windows.Forms.Label
      Private label10 As System.Windows.Forms.Label
      Private WithEvents _cmbOrgImagePalette As System.Windows.Forms.ComboBox
   End Class
End Namespace
