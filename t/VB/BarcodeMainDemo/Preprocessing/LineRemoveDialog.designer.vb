
Partial Class LineRemoveDialog
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
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LineRemoveDialog))
      Me._gb1 = New System.Windows.Forms.GroupBox()
      Me._tbDPI = New System.Windows.Forms.TextBox()
      Me._cbUseDPI = New System.Windows.Forms.CheckBox()
      Me._gb2 = New System.Windows.Forms.GroupBox()
      Me._rbVerticalLines = New System.Windows.Forms.RadioButton()
      Me._rbHorizontalLines = New System.Windows.Forms.RadioButton()
      Me._gb3 = New System.Windows.Forms.GroupBox()
      Me._lbl7 = New System.Windows.Forms.Label()
      Me._lbl6 = New System.Windows.Forms.Label()
      Me._lbl5 = New System.Windows.Forms.Label()
      Me._tbMaximumWallPercent = New System.Windows.Forms.TextBox()
      Me._lblMaxWallPercent = New System.Windows.Forms.Label()
      Me._tbWallHeight = New System.Windows.Forms.TextBox()
      Me._lblWallHeight = New System.Windows.Forms.Label()
      Me._tbMaximumLineWidth = New System.Windows.Forms.TextBox()
      Me._lblMaximumWidth = New System.Windows.Forms.Label()
      Me._tbMinimumLineLength = New System.Windows.Forms.TextBox()
      Me._lblMinimumLength = New System.Windows.Forms.Label()
      Me._gb4 = New System.Windows.Forms.GroupBox()
      Me._lbl9 = New System.Windows.Forms.Label()
      Me._lbl8 = New System.Windows.Forms.Label()
      Me._tbGapLength = New System.Windows.Forms.TextBox()
      Me._tbVariance = New System.Windows.Forms.TextBox()
      Me._cbRemoveEntireLine = New System.Windows.Forms.CheckBox()
      Me._cbMaximumGap = New System.Windows.Forms.CheckBox()
      Me._cbLineVariance = New System.Windows.Forms.CheckBox()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._gb1.SuspendLayout()
      Me._gb2.SuspendLayout()
      Me._gb3.SuspendLayout()
      Me._gb4.SuspendLayout()
      Me.SuspendLayout()
      ' 
      ' _gb1
      ' 
      Me._gb1.Controls.Add(Me._tbDPI)
      Me._gb1.Controls.Add(Me._cbUseDPI)
      Me._gb1.Location = New System.Drawing.Point(12, 12)
      Me._gb1.Name = "_gb1"
      Me._gb1.Size = New System.Drawing.Size(280, 48)
      Me._gb1.TabIndex = 0
      Me._gb1.TabStop = False
      Me._gb1.Text = "Flags"
      ' 
      ' _tbDPI
      ' 
      Me._tbDPI.Enabled = False
      Me._tbDPI.Location = New System.Drawing.Point(90, 17)
      Me._tbDPI.Name = "_tbDPI"
      Me._tbDPI.Size = New System.Drawing.Size(100, 20)
      Me._tbDPI.TabIndex = 1
      ' 
      ' _cbUseDPI
      ' 
      Me._cbUseDPI.AutoSize = True
      Me._cbUseDPI.Location = New System.Drawing.Point(18, 19)
      Me._cbUseDPI.Name = "_cbUseDPI"
      Me._cbUseDPI.Size = New System.Drawing.Size(66, 17)
      Me._cbUseDPI.TabIndex = 0
      Me._cbUseDPI.Text = "Use DPI"
      Me._cbUseDPI.UseVisualStyleBackColor = True
      ' 
      ' _gb2
      ' 
      Me._gb2.Controls.Add(Me._rbVerticalLines)
      Me._gb2.Controls.Add(Me._rbHorizontalLines)
      Me._gb2.Location = New System.Drawing.Point(12, 66)
      Me._gb2.Name = "_gb2"
      Me._gb2.Size = New System.Drawing.Size(280, 70)
      Me._gb2.TabIndex = 1
      Me._gb2.TabStop = False
      Me._gb2.Text = "Lines To Remove"
      ' 
      ' _rbVerticalLines
      ' 
      Me._rbVerticalLines.AutoSize = True
      Me._rbVerticalLines.Location = New System.Drawing.Point(18, 42)
      Me._rbVerticalLines.Name = "_rbVerticalLines"
      Me._rbVerticalLines.Size = New System.Drawing.Size(131, 17)
      Me._rbVerticalLines.TabIndex = 1
      Me._rbVerticalLines.TabStop = True
      Me._rbVerticalLines.Text = "Remove Vertical Lines"
      Me._rbVerticalLines.UseVisualStyleBackColor = True
      ' 
      ' _rbHorizontalLines
      ' 
      Me._rbHorizontalLines.AutoSize = True
      Me._rbHorizontalLines.Location = New System.Drawing.Point(18, 19)
      Me._rbHorizontalLines.Name = "_rbHorizontalLines"
      Me._rbHorizontalLines.Size = New System.Drawing.Size(143, 17)
      Me._rbHorizontalLines.TabIndex = 0
      Me._rbHorizontalLines.TabStop = True
      Me._rbHorizontalLines.Text = "Remove Horizontal Lines"
      Me._rbHorizontalLines.UseVisualStyleBackColor = True
      ' 
      ' _gb3
      ' 
      Me._gb3.Controls.Add(Me._lbl7)
      Me._gb3.Controls.Add(Me._lbl6)
      Me._gb3.Controls.Add(Me._lbl5)
      Me._gb3.Controls.Add(Me._tbMaximumWallPercent)
      Me._gb3.Controls.Add(Me._lblMaxWallPercent)
      Me._gb3.Controls.Add(Me._tbWallHeight)
      Me._gb3.Controls.Add(Me._lblWallHeight)
      Me._gb3.Controls.Add(Me._tbMaximumLineWidth)
      Me._gb3.Controls.Add(Me._lblMaximumWidth)
      Me._gb3.Controls.Add(Me._tbMinimumLineLength)
      Me._gb3.Controls.Add(Me._lblMinimumLength)
      Me._gb3.Location = New System.Drawing.Point(12, 142)
      Me._gb3.Name = "_gb3"
      Me._gb3.Size = New System.Drawing.Size(280, 130)
      Me._gb3.TabIndex = 1
      Me._gb3.TabStop = False
      Me._gb3.Text = "Dimensions"
      ' 
      ' _lbl7
      ' 
      Me._lbl7.AutoSize = True
      Me._lbl7.Location = New System.Drawing.Point(175, 76)
      Me._lbl7.Name = "_lbl7"
      Me._lbl7.Size = New System.Drawing.Size(29, 13)
      Me._lbl7.TabIndex = 10
      Me._lbl7.Text = "_lbl7"
      ' 
      ' _lbl6
      ' 
      Me._lbl6.AutoSize = True
      Me._lbl6.Location = New System.Drawing.Point(175, 52)
      Me._lbl6.Name = "_lbl6"
      Me._lbl6.Size = New System.Drawing.Size(29, 13)
      Me._lbl6.TabIndex = 9
      Me._lbl6.Text = "_lbl6"
      ' 
      ' _lbl5
      ' 
      Me._lbl5.AutoSize = True
      Me._lbl5.Location = New System.Drawing.Point(175, 26)
      Me._lbl5.Name = "_lbl5"
      Me._lbl5.Size = New System.Drawing.Size(29, 13)
      Me._lbl5.TabIndex = 8
      Me._lbl5.Text = "_lbl5"
      ' 
      ' _tbMaximumWallPercent
      ' 
      Me._tbMaximumWallPercent.Location = New System.Drawing.Point(114, 98)
      Me._tbMaximumWallPercent.Name = "_tbMaximumWallPercent"
      Me._tbMaximumWallPercent.Size = New System.Drawing.Size(45, 20)
      Me._tbMaximumWallPercent.TabIndex = 7
      ' 
      ' _lblMaxWallPercent
      ' 
      Me._lblMaxWallPercent.AutoSize = True
      Me._lblMaxWallPercent.Location = New System.Drawing.Point(12, 104)
      Me._lblMaxWallPercent.Name = "_lblMaxWallPercent"
      Me._lblMaxWallPercent.Size = New System.Drawing.Size(91, 13)
      Me._lblMaxWallPercent.TabIndex = 6
      Me._lblMaxWallPercent.Text = "Max Wall Percent"
      ' 
      ' _tbWallHeight
      ' 
      Me._tbWallHeight.Location = New System.Drawing.Point(114, 71)
      Me._tbWallHeight.Name = "_tbWallHeight"
      Me._tbWallHeight.Size = New System.Drawing.Size(45, 20)
      Me._tbWallHeight.TabIndex = 5
      ' 
      ' _lblWallHeight
      ' 
      Me._lblWallHeight.AutoSize = True
      Me._lblWallHeight.Location = New System.Drawing.Point(12, 78)
      Me._lblWallHeight.Name = "_lblWallHeight"
      Me._lblWallHeight.Size = New System.Drawing.Size(62, 13)
      Me._lblWallHeight.TabIndex = 4
      Me._lblWallHeight.Text = "Wall Height"
      ' 
      ' _tbMaximumLineWidth
      ' 
      Me._tbMaximumLineWidth.Location = New System.Drawing.Point(114, 45)
      Me._tbMaximumLineWidth.Name = "_tbMaximumLineWidth"
      Me._tbMaximumLineWidth.Size = New System.Drawing.Size(45, 20)
      Me._tbMaximumLineWidth.TabIndex = 3
      ' 
      ' _lblMaximumWidth
      ' 
      Me._lblMaximumWidth.AutoSize = True
      Me._lblMaximumWidth.Location = New System.Drawing.Point(12, 52)
      Me._lblMaximumWidth.Name = "_lblMaximumWidth"
      Me._lblMaximumWidth.Size = New System.Drawing.Size(82, 13)
      Me._lblMaximumWidth.TabIndex = 2
      Me._lblMaximumWidth.Text = "Maximum Width"
      ' 
      ' _tbMinimumLineLength
      ' 
      Me._tbMinimumLineLength.Location = New System.Drawing.Point(114, 19)
      Me._tbMinimumLineLength.Name = "_tbMinimumLineLength"
      Me._tbMinimumLineLength.Size = New System.Drawing.Size(45, 20)
      Me._tbMinimumLineLength.TabIndex = 1
      ' 
      ' _lblMinimumLength
      ' 
      Me._lblMinimumLength.AutoSize = True
      Me._lblMinimumLength.Location = New System.Drawing.Point(12, 26)
      Me._lblMinimumLength.Name = "_lblMinimumLength"
      Me._lblMinimumLength.Size = New System.Drawing.Size(84, 13)
      Me._lblMinimumLength.TabIndex = 0
      Me._lblMinimumLength.Text = "Minimum Length"
      ' 
      ' _gb4
      ' 
      Me._gb4.Controls.Add(Me._lbl9)
      Me._gb4.Controls.Add(Me._lbl8)
      Me._gb4.Controls.Add(Me._tbGapLength)
      Me._gb4.Controls.Add(Me._tbVariance)
      Me._gb4.Controls.Add(Me._cbRemoveEntireLine)
      Me._gb4.Controls.Add(Me._cbMaximumGap)
      Me._gb4.Controls.Add(Me._cbLineVariance)
      Me._gb4.Location = New System.Drawing.Point(12, 278)
      Me._gb4.Name = "_gb4"
      Me._gb4.Size = New System.Drawing.Size(280, 100)
      Me._gb4.TabIndex = 1
      Me._gb4.TabStop = False
      Me._gb4.Text = "Optional Processing"
      ' 
      ' _lbl9
      ' 
      Me._lbl9.AutoSize = True
      Me._lbl9.Location = New System.Drawing.Point(175, 46)
      Me._lbl9.Name = "_lbl9"
      Me._lbl9.Size = New System.Drawing.Size(29, 13)
      Me._lbl9.TabIndex = 6
      Me._lbl9.Text = "_lbl9"
      ' 
      ' _lbl8
      ' 
      Me._lbl8.AutoSize = True
      Me._lbl8.Location = New System.Drawing.Point(175, 19)
      Me._lbl8.Name = "_lbl8"
      Me._lbl8.Size = New System.Drawing.Size(29, 13)
      Me._lbl8.TabIndex = 5
      Me._lbl8.Text = "_lbl8"
      ' 
      ' _tbGapLength
      ' 
      Me._tbGapLength.Location = New System.Drawing.Point(114, 39)
      Me._tbGapLength.Name = "_tbGapLength"
      Me._tbGapLength.Size = New System.Drawing.Size(45, 20)
      Me._tbGapLength.TabIndex = 4
      ' 
      ' _tbVariance
      ' 
      Me._tbVariance.Location = New System.Drawing.Point(114, 13)
      Me._tbVariance.Name = "_tbVariance"
      Me._tbVariance.Size = New System.Drawing.Size(45, 20)
      Me._tbVariance.TabIndex = 3
      ' 
      ' _cbRemoveEntireLine
      ' 
      Me._cbRemoveEntireLine.AutoSize = True
      Me._cbRemoveEntireLine.Location = New System.Drawing.Point(18, 65)
      Me._cbRemoveEntireLine.Name = "_cbRemoveEntireLine"
      Me._cbRemoveEntireLine.Size = New System.Drawing.Size(119, 17)
      Me._cbRemoveEntireLine.TabIndex = 2
      Me._cbRemoveEntireLine.Text = "Remove Entire Line"
      Me._cbRemoveEntireLine.UseVisualStyleBackColor = True
      ' 
      ' _cbMaximumGap
      ' 
      Me._cbMaximumGap.AutoSize = True
      Me._cbMaximumGap.Location = New System.Drawing.Point(18, 42)
      Me._cbMaximumGap.Name = "_cbMaximumGap"
      Me._cbMaximumGap.Size = New System.Drawing.Size(93, 17)
      Me._cbMaximumGap.TabIndex = 1
      Me._cbMaximumGap.Text = "Maximum Gap"
      Me._cbMaximumGap.UseVisualStyleBackColor = True
      ' 
      ' _cbLineVariance
      ' 
      Me._cbLineVariance.AutoSize = True
      Me._cbLineVariance.Location = New System.Drawing.Point(18, 19)
      Me._cbLineVariance.Name = "_cbLineVariance"
      Me._cbLineVariance.Size = New System.Drawing.Size(91, 17)
      Me._cbLineVariance.TabIndex = 0
      Me._cbLineVariance.Text = "Line Variance"
      Me._cbLineVariance.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.Location = New System.Drawing.Point(298, 12)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(75, 23)
      Me._btnOk.TabIndex = 2
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.Location = New System.Drawing.Point(298, 41)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(75, 23)
      Me._btnCancel.TabIndex = 3
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' LineRemoveDialog
      ' 
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(381, 389)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._gb2)
      Me.Controls.Add(Me._gb3)
      Me.Controls.Add(Me._gb4)
      Me.Controls.Add(Me._gb1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "LineRemoveDialog"
      Me.Text = "Line Removal"
      Me._gb1.ResumeLayout(False)
      Me._gb1.PerformLayout()
      Me._gb2.ResumeLayout(False)
      Me._gb2.PerformLayout()
      Me._gb3.ResumeLayout(False)
      Me._gb3.PerformLayout()
      Me._gb4.ResumeLayout(False)
      Me._gb4.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gb1 As System.Windows.Forms.GroupBox
   Private _cbUseDPI As System.Windows.Forms.CheckBox
   Private _gb2 As System.Windows.Forms.GroupBox
   Private _rbVerticalLines As System.Windows.Forms.RadioButton
   Private _rbHorizontalLines As System.Windows.Forms.RadioButton
   Private _gb3 As System.Windows.Forms.GroupBox
   Private _lbl7 As System.Windows.Forms.Label
   Private _lbl6 As System.Windows.Forms.Label
   Private _lbl5 As System.Windows.Forms.Label
   Private WithEvents _tbMaximumWallPercent As System.Windows.Forms.TextBox
   Private _lblMaxWallPercent As System.Windows.Forms.Label
   Private WithEvents _tbWallHeight As System.Windows.Forms.TextBox
   Private _lblWallHeight As System.Windows.Forms.Label
   Private WithEvents _tbMaximumLineWidth As System.Windows.Forms.TextBox
   Private _lblMaximumWidth As System.Windows.Forms.Label
   Private WithEvents _tbMinimumLineLength As System.Windows.Forms.TextBox
   Private _lblMinimumLength As System.Windows.Forms.Label
   Private _gb4 As System.Windows.Forms.GroupBox
   Private _lbl9 As System.Windows.Forms.Label
   Private _lbl8 As System.Windows.Forms.Label
   Private WithEvents _tbGapLength As System.Windows.Forms.TextBox
   Private WithEvents _tbVariance As System.Windows.Forms.TextBox
   Private _cbRemoveEntireLine As System.Windows.Forms.CheckBox
   Private WithEvents _cbMaximumGap As System.Windows.Forms.CheckBox
   Private WithEvents _cbLineVariance As System.Windows.Forms.CheckBox
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private _tbDPI As System.Windows.Forms.TextBox
End Class
