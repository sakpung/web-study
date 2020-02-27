
Partial Class SetPixelColorDialog
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
      Me._gbPoint = New System.Windows.Forms.GroupBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me._numY = New System.Windows.Forms.NumericUpDown()
      Me._numX = New System.Windows.Forms.NumericUpDown()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbGray = New System.Windows.Forms.GroupBox()
      Me.label6 = New System.Windows.Forms.Label()
      Me._numLevel = New System.Windows.Forms.NumericUpDown()
      Me._gbRGB = New System.Windows.Forms.GroupBox()
      Me.label5 = New System.Windows.Forms.Label()
      Me.label4 = New System.Windows.Forms.Label()
      Me.label3 = New System.Windows.Forms.Label()
      Me._numB = New System.Windows.Forms.NumericUpDown()
      Me._numG = New System.Windows.Forms.NumericUpDown()
      Me._numR = New System.Windows.Forms.NumericUpDown()
      Me._gbPoint.SuspendLayout()
      CType(Me._numY, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numX, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._gbGray.SuspendLayout()
      CType(Me._numLevel, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._gbRGB.SuspendLayout()
      CType(Me._numB, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numG, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numR, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gbPoint
      ' 
      Me._gbPoint.Controls.Add(Me.label2)
      Me._gbPoint.Controls.Add(Me.label1)
      Me._gbPoint.Controls.Add(Me._numY)
      Me._gbPoint.Controls.Add(Me._numX)
      Me._gbPoint.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbPoint.Location = New System.Drawing.Point(11, 11)
      Me._gbPoint.Margin = New System.Windows.Forms.Padding(2)
      Me._gbPoint.Name = "_gbPoint"
      Me._gbPoint.Padding = New System.Windows.Forms.Padding(2)
      Me._gbPoint.Size = New System.Drawing.Size(190, 51)
      Me._gbPoint.TabIndex = 13
      Me._gbPoint.TabStop = False
      Me._gbPoint.Text = "Value"
      ' 
      ' label2
      ' 
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(110, 23)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(23, 13)
      Me.label2.TabIndex = 3
      Me.label2.Text = "Y ="
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(17, 23)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(23, 13)
      Me.label1.TabIndex = 2
      Me.label1.Text = "X ="
      ' 
      ' _numY
      ' 
      Me._numY.Location = New System.Drawing.Point(139, 21)
      Me._numY.Name = "_numY"
      Me._numY.Size = New System.Drawing.Size(46, 20)
      Me._numY.TabIndex = 1
      ' 
      ' _numX
      ' 
      Me._numX.Location = New System.Drawing.Point(46, 21)
      Me._numX.Name = "_numX"
      Me._numX.Size = New System.Drawing.Size(46, 20)
      Me._numX.TabIndex = 0
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(205, 41)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 15
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(205, 11)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 14
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _gbGray
      ' 
      Me._gbGray.Controls.Add(Me.label6)
      Me._gbGray.Controls.Add(Me._numLevel)
      Me._gbGray.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbGray.Location = New System.Drawing.Point(11, 66)
      Me._gbGray.Margin = New System.Windows.Forms.Padding(2)
      Me._gbGray.Name = "_gbGray"
      Me._gbGray.Padding = New System.Windows.Forms.Padding(2)
      Me._gbGray.Size = New System.Drawing.Size(190, 68)
      Me._gbGray.TabIndex = 16
      Me._gbGray.TabStop = False
      Me._gbGray.Text = "Value"
      Me._gbGray.Visible = False
      ' 
      ' label6
      ' 
      Me.label6.AutoSize = True
      Me.label6.Location = New System.Drawing.Point(70, 21)
      Me.label6.Name = "label6"
      Me.label6.Size = New System.Drawing.Size(36, 13)
      Me.label6.TabIndex = 2
      Me.label6.Text = "Level:"
      ' 
      ' _numLevel
      ' 
      Me._numLevel.Location = New System.Drawing.Point(35, 42)
      Me._numLevel.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numLevel.Name = "_numLevel"
      Me._numLevel.Size = New System.Drawing.Size(120, 20)
      Me._numLevel.TabIndex = 1
      ' 
      ' _gbRGB
      ' 
      Me._gbRGB.Controls.Add(Me.label5)
      Me._gbRGB.Controls.Add(Me.label4)
      Me._gbRGB.Controls.Add(Me.label3)
      Me._gbRGB.Controls.Add(Me._numB)
      Me._gbRGB.Controls.Add(Me._numG)
      Me._gbRGB.Controls.Add(Me._numR)
      Me._gbRGB.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbRGB.Location = New System.Drawing.Point(11, 66)
      Me._gbRGB.Margin = New System.Windows.Forms.Padding(2)
      Me._gbRGB.Name = "_gbRGB"
      Me._gbRGB.Padding = New System.Windows.Forms.Padding(2)
      Me._gbRGB.Size = New System.Drawing.Size(190, 68)
      Me._gbRGB.TabIndex = 17
      Me._gbRGB.TabStop = False
      Me._gbRGB.Text = "RGB"
      Me._gbRGB.Visible = False
      ' 
      ' label5
      ' 
      Me.label5.AutoSize = True
      Me.label5.Location = New System.Drawing.Point(142, 19)
      Me.label5.Name = "label5"
      Me.label5.Size = New System.Drawing.Size(17, 13)
      Me.label5.TabIndex = 19
      Me.label5.Text = "B:"
      ' 
      ' label4
      ' 
      Me.label4.AutoSize = True
      Me.label4.Location = New System.Drawing.Point(87, 19)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(18, 13)
      Me.label4.TabIndex = 18
      Me.label4.Text = "G:"
      ' 
      ' label3
      ' 
      Me.label3.AutoSize = True
      Me.label3.Location = New System.Drawing.Point(34, 19)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(18, 13)
      Me.label3.TabIndex = 4
      Me.label3.Text = "R:"
      ' 
      ' _numB
      ' 
      Me._numB.Location = New System.Drawing.Point(132, 39)
      Me._numB.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numB.Name = "_numB"
      Me._numB.Size = New System.Drawing.Size(43, 20)
      Me._numB.TabIndex = 3
      ' 
      ' _numG
      ' 
      Me._numG.Location = New System.Drawing.Point(78, 39)
      Me._numG.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numG.Name = "_numG"
      Me._numG.Size = New System.Drawing.Size(43, 20)
      Me._numG.TabIndex = 2
      ' 
      ' _numR
      ' 
      Me._numR.Location = New System.Drawing.Point(25, 39)
      Me._numR.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numR.Name = "_numR"
      Me._numR.Size = New System.Drawing.Size(43, 20)
      Me._numR.TabIndex = 1
      ' 
      ' PointDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(286, 153)
      Me.Controls.Add(Me._gbGray)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._gbPoint)
      Me.Controls.Add(Me._gbRGB)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PointDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Set Pixel Color"
      Me._gbPoint.ResumeLayout(False)
      Me._gbPoint.PerformLayout()
      CType(Me._numY, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numX, System.ComponentModel.ISupportInitialize).EndInit()
      Me._gbGray.ResumeLayout(False)
      Me._gbGray.PerformLayout()
      CType(Me._numLevel, System.ComponentModel.ISupportInitialize).EndInit()
      Me._gbRGB.ResumeLayout(False)
      Me._gbRGB.PerformLayout()
      CType(Me._numB, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numG, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numR, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbPoint As System.Windows.Forms.GroupBox
   Private label2 As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private _numY As System.Windows.Forms.NumericUpDown
   Private _numX As System.Windows.Forms.NumericUpDown
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _gbGray As System.Windows.Forms.GroupBox
   Private _numLevel As System.Windows.Forms.NumericUpDown
   Private _gbRGB As System.Windows.Forms.GroupBox
   Private _numR As System.Windows.Forms.NumericUpDown
   Private _numB As System.Windows.Forms.NumericUpDown
   Private _numG As System.Windows.Forms.NumericUpDown
   Private label6 As System.Windows.Forms.Label
   Private label5 As System.Windows.Forms.Label
   Private label4 As System.Windows.Forms.Label
   Private label3 As System.Windows.Forms.Label
End Class