
Partial Class CombineImageDialog
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
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbDigitalSubtract = New System.Windows.Forms.GroupBox()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me.label6 = New System.Windows.Forms.Label()
      Me.label5 = New System.Windows.Forms.Label()
      Me._numHeight = New System.Windows.Forms.NumericUpDown()
      Me._numWidth = New System.Windows.Forms.NumericUpDown()
      Me.groupBox2 = New System.Windows.Forms.GroupBox()
      Me.label4 = New System.Windows.Forms.Label()
      Me.label2 = New System.Windows.Forms.Label()
      Me._numDestY = New System.Windows.Forms.NumericUpDown()
      Me._numDestX = New System.Windows.Forms.NumericUpDown()
      Me._gbMaskStratPoint = New System.Windows.Forms.GroupBox()
      Me.label3 = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me._numMaskY = New System.Windows.Forms.NumericUpDown()
      Me._numMaskX = New System.Windows.Forms.NumericUpDown()
      Me._cmbCombiningOperation = New System.Windows.Forms.ComboBox()
      Me._lblCombiningOperation = New System.Windows.Forms.Label()
      Me._cmbMaskImage = New System.Windows.Forms.ComboBox()
      Me._lblMaskImage = New System.Windows.Forms.Label()
      Me._gbDigitalSubtract.SuspendLayout()
      Me.groupBox1.SuspendLayout()
      CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.groupBox2.SuspendLayout()
      CType(Me._numDestY, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numDestX, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._gbMaskStratPoint.SuspendLayout()
      CType(Me._numMaskY, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numMaskX, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(554, 297)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 14
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(482, 297)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 13
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _gbDigitalSubtract
      ' 
      Me._gbDigitalSubtract.Controls.Add(Me.groupBox1)
      Me._gbDigitalSubtract.Controls.Add(Me.groupBox2)
      Me._gbDigitalSubtract.Controls.Add(Me._gbMaskStratPoint)
      Me._gbDigitalSubtract.Controls.Add(Me._cmbCombiningOperation)
      Me._gbDigitalSubtract.Controls.Add(Me._lblCombiningOperation)
      Me._gbDigitalSubtract.Controls.Add(Me._cmbMaskImage)
      Me._gbDigitalSubtract.Controls.Add(Me._lblMaskImage)
      Me._gbDigitalSubtract.Location = New System.Drawing.Point(5, 3)
      Me._gbDigitalSubtract.Name = "_gbDigitalSubtract"
      Me._gbDigitalSubtract.Size = New System.Drawing.Size(617, 289)
      Me._gbDigitalSubtract.TabIndex = 12
      Me._gbDigitalSubtract.TabStop = False
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.Add(Me.label6)
      Me.groupBox1.Controls.Add(Me.label5)
      Me.groupBox1.Controls.Add(Me._numHeight)
      Me.groupBox1.Controls.Add(Me._numWidth)
      Me.groupBox1.Location = New System.Drawing.Point(22, 226)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(261, 52)
      Me.groupBox1.TabIndex = 9
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Destination Rectangle :"
      ' 
      ' label6
      ' 
      Me.label6.AutoSize = True
      Me.label6.Location = New System.Drawing.Point(132, 26)
      Me.label6.Name = "label6"
      Me.label6.Size = New System.Drawing.Size(44, 13)
      Me.label6.TabIndex = 7
      Me.label6.Text = "Height :"
      ' 
      ' label5
      ' 
      Me.label5.AutoSize = True
      Me.label5.Location = New System.Drawing.Point(9, 26)
      Me.label5.Name = "label5"
      Me.label5.Size = New System.Drawing.Size(41, 13)
      Me.label5.TabIndex = 6
      Me.label5.Text = "Width :"
      ' 
      ' _numHeight
      ' 
      Me._numHeight.Location = New System.Drawing.Point(179, 24)
      Me._numHeight.Name = "_numHeight"
      Me._numHeight.Size = New System.Drawing.Size(72, 20)
      Me._numHeight.TabIndex = 5
      ' 
      ' _numWidth
      ' 
      Me._numWidth.Location = New System.Drawing.Point(50, 24)
      Me._numWidth.Name = "_numWidth"
      Me._numWidth.Size = New System.Drawing.Size(72, 20)
      Me._numWidth.TabIndex = 4
      ' 
      ' groupBox2
      ' 
      Me.groupBox2.Controls.Add(Me.label4)
      Me.groupBox2.Controls.Add(Me.label2)
      Me.groupBox2.Controls.Add(Me._numDestY)
      Me.groupBox2.Controls.Add(Me._numDestX)
      Me.groupBox2.Location = New System.Drawing.Point(22, 163)
      Me.groupBox2.Name = "groupBox2"
      Me.groupBox2.Size = New System.Drawing.Size(261, 52)
      Me.groupBox2.TabIndex = 8
      Me.groupBox2.TabStop = False
      Me.groupBox2.Text = "Destination Image Start Point :"
      ' 
      ' label4
      ' 
      Me.label4.AutoSize = True
      Me.label4.Location = New System.Drawing.Point(146, 26)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(20, 13)
      Me.label4.TabIndex = 5
      Me.label4.Text = "Y :"
      ' 
      ' label2
      ' 
      Me.label2.AutoSize = True
      Me.label2.Location = New System.Drawing.Point(15, 26)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(20, 13)
      Me.label2.TabIndex = 3
      Me.label2.Text = "X :"
      ' 
      ' _numDestY
      ' 
      Me._numDestY.Location = New System.Drawing.Point(174, 24)
      Me._numDestY.Name = "_numDestY"
      Me._numDestY.Size = New System.Drawing.Size(72, 20)
      Me._numDestY.TabIndex = 3
      ' 
      ' _numDestX
      ' 
      Me._numDestX.Location = New System.Drawing.Point(43, 24)
      Me._numDestX.Name = "_numDestX"
      Me._numDestX.Size = New System.Drawing.Size(72, 20)
      Me._numDestX.TabIndex = 2
      ' 
      ' _gbMaskStratPoint
      ' 
      Me._gbMaskStratPoint.Controls.Add(Me.label3)
      Me._gbMaskStratPoint.Controls.Add(Me.label1)
      Me._gbMaskStratPoint.Controls.Add(Me._numMaskY)
      Me._gbMaskStratPoint.Controls.Add(Me._numMaskX)
      Me._gbMaskStratPoint.Location = New System.Drawing.Point(22, 96)
      Me._gbMaskStratPoint.Name = "_gbMaskStratPoint"
      Me._gbMaskStratPoint.Size = New System.Drawing.Size(261, 52)
      Me._gbMaskStratPoint.TabIndex = 7
      Me._gbMaskStratPoint.TabStop = False
      Me._gbMaskStratPoint.Text = "Mask Image Start Point :"
      ' 
      ' label3
      ' 
      Me.label3.AutoSize = True
      Me.label3.Location = New System.Drawing.Point(146, 26)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(20, 13)
      Me.label3.TabIndex = 4
      Me.label3.Text = "Y :"
      ' 
      ' label1
      ' 
      Me.label1.AutoSize = True
      Me.label1.Location = New System.Drawing.Point(15, 26)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(20, 13)
      Me.label1.TabIndex = 2
      Me.label1.Text = "X :"
      ' 
      ' _numMaskY
      ' 
      Me._numMaskY.Location = New System.Drawing.Point(174, 24)
      Me._numMaskY.Name = "_numMaskY"
      Me._numMaskY.Size = New System.Drawing.Size(72, 20)
      Me._numMaskY.TabIndex = 1
      ' 
      ' _numMaskX
      ' 
      Me._numMaskX.Location = New System.Drawing.Point(43, 24)
      Me._numMaskX.Name = "_numMaskX"
      Me._numMaskX.Size = New System.Drawing.Size(72, 20)
      Me._numMaskX.TabIndex = 0
      Me._numMaskX.Value = New Decimal(New Integer() {1, 0, 0, 0})
      ' 
      ' _cmbCombiningOperation
      ' 
      Me._cmbCombiningOperation.FormattingEnabled = True
      Me._cmbCombiningOperation.Items.AddRange(New Object() {"Or ", "Xor ", "Add", "SubtractSource", "SubtractDestination", "Multiply", _
       "DivideSource ", "DivideDestination ", "Average ", "Minimum ", "Maximum"})
      Me._cmbCombiningOperation.Location = New System.Drawing.Point(159, 69)
      Me._cmbCombiningOperation.Name = "_cmbCombiningOperation"
      Me._cmbCombiningOperation.Size = New System.Drawing.Size(125, 21)
      Me._cmbCombiningOperation.TabIndex = 6
      ' 
      ' _lblCombiningOperation
      ' 
      Me._lblCombiningOperation.AutoSize = True
      Me._lblCombiningOperation.Location = New System.Drawing.Point(19, 69)
      Me._lblCombiningOperation.Name = "_lblCombiningOperation"
      Me._lblCombiningOperation.Size = New System.Drawing.Size(111, 13)
      Me._lblCombiningOperation.TabIndex = 5
      Me._lblCombiningOperation.Text = "Combining Operation :"
      ' 
      ' _cmbMaskImage
      ' 
      Me._cmbMaskImage.FormattingEnabled = True
      Me._cmbMaskImage.Location = New System.Drawing.Point(22, 38)
      Me._cmbMaskImage.Name = "_cmbMaskImage"
      Me._cmbMaskImage.Size = New System.Drawing.Size(589, 21)
      Me._cmbMaskImage.TabIndex = 4
      ' 
      ' _lblMaskImage
      ' 
      Me._lblMaskImage.AutoSize = True
      Me._lblMaskImage.Location = New System.Drawing.Point(19, 22)
      Me._lblMaskImage.Name = "_lblMaskImage"
      Me._lblMaskImage.Size = New System.Drawing.Size(71, 13)
      Me._lblMaskImage.TabIndex = 3
      Me._lblMaskImage.Text = "Mask Image :"
      ' 
      ' CombineImageDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(634, 326)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._gbDigitalSubtract)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CombineImageDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Combine Image"
      Me._gbDigitalSubtract.ResumeLayout(False)
      Me._gbDigitalSubtract.PerformLayout()
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
      Me.groupBox2.ResumeLayout(False)
      Me.groupBox2.PerformLayout()
      CType(Me._numDestY, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numDestX, System.ComponentModel.ISupportInitialize).EndInit()
      Me._gbMaskStratPoint.ResumeLayout(False)
      Me._gbMaskStratPoint.PerformLayout()
      CType(Me._numMaskY, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numMaskX, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _gbDigitalSubtract As System.Windows.Forms.GroupBox
   Private WithEvents _cmbMaskImage As System.Windows.Forms.ComboBox
   Private _lblMaskImage As System.Windows.Forms.Label
   Private _cmbCombiningOperation As System.Windows.Forms.ComboBox
   Private _lblCombiningOperation As System.Windows.Forms.Label
   Private groupBox2 As System.Windows.Forms.GroupBox
   Private _gbMaskStratPoint As System.Windows.Forms.GroupBox
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private label6 As System.Windows.Forms.Label
   Private label5 As System.Windows.Forms.Label
   Private _numHeight As System.Windows.Forms.NumericUpDown
   Private _numWidth As System.Windows.Forms.NumericUpDown
   Private label4 As System.Windows.Forms.Label
   Private label2 As System.Windows.Forms.Label
   Private WithEvents _numDestY As System.Windows.Forms.NumericUpDown
   Private WithEvents _numDestX As System.Windows.Forms.NumericUpDown
   Private label3 As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private WithEvents _numMaskY As System.Windows.Forms.NumericUpDown
   Private WithEvents _numMaskX As System.Windows.Forms.NumericUpDown

End Class