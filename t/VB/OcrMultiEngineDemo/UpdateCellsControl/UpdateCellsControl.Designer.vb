Imports Microsoft.VisualBasic
Imports System

Partial Public Class UpdateCellsControl
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

#Region "Component Designer generated code"

   ''' <summary> 
   ''' Required method for Designer support - do not modify 
   ''' the contents of this method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Me._areaGroupBox = New System.Windows.Forms.GroupBox
      Me._tbHeight = New System.Windows.Forms.TextBox
      Me._heightLabel = New System.Windows.Forms.Label
      Me._tbWidth = New System.Windows.Forms.TextBox
      Me._widthLabel = New System.Windows.Forms.Label
      Me._tbTop = New System.Windows.Forms.TextBox
      Me._topLabel = New System.Windows.Forms.Label
      Me._tbLeft = New System.Windows.Forms.TextBox
      Me._leftLabel = New System.Windows.Forms.Label
      Me.groupBox1 = New System.Windows.Forms.GroupBox
      Me.label6 = New System.Windows.Forms.Label
      Me._cmbCellType = New System.Windows.Forms.ComboBox
      Me.groupBox3 = New System.Windows.Forms.GroupBox
      Me._btnBottomBorderColor = New System.Windows.Forms.Button
      Me._btnRightBorderColor = New System.Windows.Forms.Button
      Me._btnTopBorderColor = New System.Windows.Forms.Button
      Me._btnLeftBorderColor = New System.Windows.Forms.Button
      Me._lblBottomBorderColor = New System.Windows.Forms.Label
      Me._lblRightBorderColor = New System.Windows.Forms.Label
      Me._lblTopBorderColor = New System.Windows.Forms.Label
      Me._lblLeftBorderColor = New System.Windows.Forms.Label
      Me.groupBox2 = New System.Windows.Forms.GroupBox
      Me._cmbRightBorderStyle = New System.Windows.Forms.ComboBox
      Me._cmbBottomBorderStyle = New System.Windows.Forms.ComboBox
      Me._cmbTopBorderStyle = New System.Windows.Forms.ComboBox
      Me._cmbLeftBorderStyle = New System.Windows.Forms.ComboBox
      Me.label7 = New System.Windows.Forms.Label
      Me.label8 = New System.Windows.Forms.Label
      Me.label9 = New System.Windows.Forms.Label
      Me.label10 = New System.Windows.Forms.Label
      Me.groupBox4 = New System.Windows.Forms.GroupBox
      Me._numBottomBorderWidth = New System.Windows.Forms.NumericUpDown
      Me._numTopBorderWidth = New System.Windows.Forms.NumericUpDown
      Me._numRightBorderWidth = New System.Windows.Forms.NumericUpDown
      Me._numLeftBorderWidth = New System.Windows.Forms.NumericUpDown
      Me._lblBottomBorderWidth = New System.Windows.Forms.Label
      Me._lblRightBorderWidth = New System.Windows.Forms.Label
      Me._lblTopBorderWidth = New System.Windows.Forms.Label
      Me._lblLeftBorderWidth = New System.Windows.Forms.Label
      Me._areaGroupBox.SuspendLayout()
      Me.groupBox1.SuspendLayout()
      Me.groupBox3.SuspendLayout()
      Me.groupBox2.SuspendLayout()
      Me.groupBox4.SuspendLayout()
      CType(Me._numBottomBorderWidth, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numTopBorderWidth, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numRightBorderWidth, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numLeftBorderWidth, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      '_areaGroupBox
      '
      Me._areaGroupBox.Controls.Add(Me._tbHeight)
      Me._areaGroupBox.Controls.Add(Me._heightLabel)
      Me._areaGroupBox.Controls.Add(Me._tbWidth)
      Me._areaGroupBox.Controls.Add(Me._widthLabel)
      Me._areaGroupBox.Controls.Add(Me._tbTop)
      Me._areaGroupBox.Controls.Add(Me._topLabel)
      Me._areaGroupBox.Controls.Add(Me._tbLeft)
      Me._areaGroupBox.Controls.Add(Me._leftLabel)
      Me._areaGroupBox.Location = New System.Drawing.Point(3, 111)
      Me._areaGroupBox.Name = "_areaGroupBox"
      Me._areaGroupBox.Size = New System.Drawing.Size(273, 97)
      Me._areaGroupBox.TabIndex = 2
      Me._areaGroupBox.TabStop = False
      Me._areaGroupBox.Text = "&Area (in pixels):"
      '
      '_tbHeight
      '
      Me._tbHeight.Location = New System.Drawing.Point(186, 60)
      Me._tbHeight.Name = "_tbHeight"
      Me._tbHeight.ReadOnly = True
      Me._tbHeight.Size = New System.Drawing.Size(69, 20)
      Me._tbHeight.TabIndex = 5
      '
      '_heightLabel
      '
      Me._heightLabel.AutoSize = True
      Me._heightLabel.Location = New System.Drawing.Point(137, 63)
      Me._heightLabel.Name = "_heightLabel"
      Me._heightLabel.Size = New System.Drawing.Size(42, 13)
      Me._heightLabel.TabIndex = 6
      Me._heightLabel.Text = "&Height:"
      '
      '_tbWidth
      '
      Me._tbWidth.Location = New System.Drawing.Point(62, 60)
      Me._tbWidth.Name = "_tbWidth"
      Me._tbWidth.ReadOnly = True
      Me._tbWidth.Size = New System.Drawing.Size(69, 20)
      Me._tbWidth.TabIndex = 4
      '
      '_widthLabel
      '
      Me._widthLabel.AutoSize = True
      Me._widthLabel.Location = New System.Drawing.Point(17, 63)
      Me._widthLabel.Name = "_widthLabel"
      Me._widthLabel.Size = New System.Drawing.Size(39, 13)
      Me._widthLabel.TabIndex = 4
      Me._widthLabel.Text = "&Width:"
      '
      '_tbTop
      '
      Me._tbTop.Location = New System.Drawing.Point(186, 34)
      Me._tbTop.Name = "_tbTop"
      Me._tbTop.ReadOnly = True
      Me._tbTop.Size = New System.Drawing.Size(69, 20)
      Me._tbTop.TabIndex = 3
      '
      '_topLabel
      '
      Me._topLabel.AutoSize = True
      Me._topLabel.Location = New System.Drawing.Point(137, 37)
      Me._topLabel.Name = "_topLabel"
      Me._topLabel.Size = New System.Drawing.Size(29, 13)
      Me._topLabel.TabIndex = 2
      Me._topLabel.Text = "&Top:"
      '
      '_tbLeft
      '
      Me._tbLeft.Location = New System.Drawing.Point(62, 34)
      Me._tbLeft.Name = "_tbLeft"
      Me._tbLeft.ReadOnly = True
      Me._tbLeft.Size = New System.Drawing.Size(69, 20)
      Me._tbLeft.TabIndex = 2
      '
      '_leftLabel
      '
      Me._leftLabel.AutoSize = True
      Me._leftLabel.Location = New System.Drawing.Point(17, 37)
      Me._leftLabel.Name = "_leftLabel"
      Me._leftLabel.Size = New System.Drawing.Size(30, 13)
      Me._leftLabel.TabIndex = 0
      Me._leftLabel.Text = "&Left:"
      '
      'groupBox1
      '
      Me.groupBox1.Controls.Add(Me.label6)
      Me.groupBox1.Controls.Add(Me._cmbCellType)
      Me.groupBox1.Location = New System.Drawing.Point(3, 3)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(273, 93)
      Me.groupBox1.TabIndex = 0
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Cell"
      '
      'label6
      '
      Me.label6.AutoSize = True
      Me.label6.Location = New System.Drawing.Point(16, 41)
      Me.label6.Name = "label6"
      Me.label6.Size = New System.Drawing.Size(31, 13)
      Me.label6.TabIndex = 9
      Me.label6.Text = "Type"
      '
      '_cmbCellType
      '
      Me._cmbCellType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbCellType.Enabled = False
      Me._cmbCellType.FormattingEnabled = True
      Me._cmbCellType.Location = New System.Drawing.Point(62, 38)
      Me._cmbCellType.Name = "_cmbCellType"
      Me._cmbCellType.Size = New System.Drawing.Size(193, 21)
      Me._cmbCellType.TabIndex = 0
      '
      'groupBox3
      '
      Me.groupBox3.Controls.Add(Me._btnBottomBorderColor)
      Me.groupBox3.Controls.Add(Me._btnRightBorderColor)
      Me.groupBox3.Controls.Add(Me._btnTopBorderColor)
      Me.groupBox3.Controls.Add(Me._btnLeftBorderColor)
      Me.groupBox3.Controls.Add(Me._lblBottomBorderColor)
      Me.groupBox3.Controls.Add(Me._lblRightBorderColor)
      Me.groupBox3.Controls.Add(Me._lblTopBorderColor)
      Me.groupBox3.Controls.Add(Me._lblLeftBorderColor)
      Me.groupBox3.Location = New System.Drawing.Point(292, 111)
      Me.groupBox3.Name = "groupBox3"
      Me.groupBox3.Size = New System.Drawing.Size(307, 93)
      Me.groupBox3.TabIndex = 14
      Me.groupBox3.TabStop = False
      Me.groupBox3.Text = "Border Colors"
      '
      '_btnBottomBorderColor
      '
      Me._btnBottomBorderColor.BackColor = System.Drawing.Color.Black
      Me._btnBottomBorderColor.Enabled = False
      Me._btnBottomBorderColor.Location = New System.Drawing.Point(184, 50)
      Me._btnBottomBorderColor.Name = "_btnBottomBorderColor"
      Me._btnBottomBorderColor.Size = New System.Drawing.Size(79, 23)
      Me._btnBottomBorderColor.TabIndex = 17
      Me._btnBottomBorderColor.UseVisualStyleBackColor = False
      '
      '_btnRightBorderColor
      '
      Me._btnRightBorderColor.BackColor = System.Drawing.Color.Black
      Me._btnRightBorderColor.Enabled = False
      Me._btnRightBorderColor.Location = New System.Drawing.Point(48, 50)
      Me._btnRightBorderColor.Name = "_btnRightBorderColor"
      Me._btnRightBorderColor.Size = New System.Drawing.Size(79, 23)
      Me._btnRightBorderColor.TabIndex = 16
      Me._btnRightBorderColor.UseVisualStyleBackColor = False
      '
      '_btnTopBorderColor
      '
      Me._btnTopBorderColor.BackColor = System.Drawing.Color.Black
      Me._btnTopBorderColor.Enabled = False
      Me._btnTopBorderColor.Location = New System.Drawing.Point(184, 20)
      Me._btnTopBorderColor.Name = "_btnTopBorderColor"
      Me._btnTopBorderColor.Size = New System.Drawing.Size(79, 23)
      Me._btnTopBorderColor.TabIndex = 15
      Me._btnTopBorderColor.UseVisualStyleBackColor = False
      '
      '_btnLeftBorderColor
      '
      Me._btnLeftBorderColor.BackColor = System.Drawing.Color.Black
      Me._btnLeftBorderColor.Enabled = False
      Me._btnLeftBorderColor.Location = New System.Drawing.Point(48, 19)
      Me._btnLeftBorderColor.Name = "_btnLeftBorderColor"
      Me._btnLeftBorderColor.Size = New System.Drawing.Size(79, 23)
      Me._btnLeftBorderColor.TabIndex = 14
      Me._btnLeftBorderColor.UseVisualStyleBackColor = False
      '
      '_lblBottomBorderColor
      '
      Me._lblBottomBorderColor.AutoSize = True
      Me._lblBottomBorderColor.Location = New System.Drawing.Point(137, 55)
      Me._lblBottomBorderColor.Name = "_lblBottomBorderColor"
      Me._lblBottomBorderColor.Size = New System.Drawing.Size(41, 13)
      Me._lblBottomBorderColor.TabIndex = 3
      Me._lblBottomBorderColor.Text = "Bottom"
      '
      '_lblRightBorderColor
      '
      Me._lblRightBorderColor.AutoSize = True
      Me._lblRightBorderColor.Location = New System.Drawing.Point(16, 55)
      Me._lblRightBorderColor.Name = "_lblRightBorderColor"
      Me._lblRightBorderColor.Size = New System.Drawing.Size(32, 13)
      Me._lblRightBorderColor.TabIndex = 2
      Me._lblRightBorderColor.Text = "Right"
      '
      '_lblTopBorderColor
      '
      Me._lblTopBorderColor.AutoSize = True
      Me._lblTopBorderColor.Location = New System.Drawing.Point(137, 25)
      Me._lblTopBorderColor.Name = "_lblTopBorderColor"
      Me._lblTopBorderColor.Size = New System.Drawing.Size(25, 13)
      Me._lblTopBorderColor.TabIndex = 1
      Me._lblTopBorderColor.Text = "Top"
      '
      '_lblLeftBorderColor
      '
      Me._lblLeftBorderColor.AutoSize = True
      Me._lblLeftBorderColor.Location = New System.Drawing.Point(16, 25)
      Me._lblLeftBorderColor.Name = "_lblLeftBorderColor"
      Me._lblLeftBorderColor.Size = New System.Drawing.Size(26, 13)
      Me._lblLeftBorderColor.TabIndex = 0
      Me._lblLeftBorderColor.Text = "Left"
      '
      'groupBox2
      '
      Me.groupBox2.Controls.Add(Me._cmbRightBorderStyle)
      Me.groupBox2.Controls.Add(Me._cmbBottomBorderStyle)
      Me.groupBox2.Controls.Add(Me._cmbTopBorderStyle)
      Me.groupBox2.Controls.Add(Me._cmbLeftBorderStyle)
      Me.groupBox2.Controls.Add(Me.label7)
      Me.groupBox2.Controls.Add(Me.label8)
      Me.groupBox2.Controls.Add(Me.label9)
      Me.groupBox2.Controls.Add(Me.label10)
      Me.groupBox2.Location = New System.Drawing.Point(292, 3)
      Me.groupBox2.Name = "groupBox2"
      Me.groupBox2.Size = New System.Drawing.Size(307, 93)
      Me.groupBox2.TabIndex = 10
      Me.groupBox2.TabStop = False
      Me.groupBox2.Text = "Border Style"
      '
      '_cmbRightBorderStyle
      '
      Me._cmbRightBorderStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbRightBorderStyle.Enabled = False
      Me._cmbRightBorderStyle.FormattingEnabled = True
      Me._cmbRightBorderStyle.Location = New System.Drawing.Point(48, 52)
      Me._cmbRightBorderStyle.Name = "_cmbRightBorderStyle"
      Me._cmbRightBorderStyle.Size = New System.Drawing.Size(79, 21)
      Me._cmbRightBorderStyle.TabIndex = 12
      '
      '_cmbBottomBorderStyle
      '
      Me._cmbBottomBorderStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbBottomBorderStyle.Enabled = False
      Me._cmbBottomBorderStyle.FormattingEnabled = True
      Me._cmbBottomBorderStyle.Location = New System.Drawing.Point(184, 52)
      Me._cmbBottomBorderStyle.Name = "_cmbBottomBorderStyle"
      Me._cmbBottomBorderStyle.Size = New System.Drawing.Size(79, 21)
      Me._cmbBottomBorderStyle.TabIndex = 13
      '
      '_cmbTopBorderStyle
      '
      Me._cmbTopBorderStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbTopBorderStyle.Enabled = False
      Me._cmbTopBorderStyle.FormattingEnabled = True
      Me._cmbTopBorderStyle.Location = New System.Drawing.Point(184, 22)
      Me._cmbTopBorderStyle.Name = "_cmbTopBorderStyle"
      Me._cmbTopBorderStyle.Size = New System.Drawing.Size(79, 21)
      Me._cmbTopBorderStyle.TabIndex = 11
      '
      '_cmbLeftBorderStyle
      '
      Me._cmbLeftBorderStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbLeftBorderStyle.Enabled = False
      Me._cmbLeftBorderStyle.FormattingEnabled = True
      Me._cmbLeftBorderStyle.Location = New System.Drawing.Point(48, 22)
      Me._cmbLeftBorderStyle.Name = "_cmbLeftBorderStyle"
      Me._cmbLeftBorderStyle.Size = New System.Drawing.Size(79, 21)
      Me._cmbLeftBorderStyle.TabIndex = 10
      '
      'label7
      '
      Me.label7.AutoSize = True
      Me.label7.Location = New System.Drawing.Point(137, 55)
      Me.label7.Name = "label7"
      Me.label7.Size = New System.Drawing.Size(41, 13)
      Me.label7.TabIndex = 3
      Me.label7.Text = "Bottom"
      '
      'label8
      '
      Me.label8.AutoSize = True
      Me.label8.Location = New System.Drawing.Point(16, 55)
      Me.label8.Name = "label8"
      Me.label8.Size = New System.Drawing.Size(32, 13)
      Me.label8.TabIndex = 2
      Me.label8.Text = "Right"
      '
      'label9
      '
      Me.label9.AutoSize = True
      Me.label9.Location = New System.Drawing.Point(137, 25)
      Me.label9.Name = "label9"
      Me.label9.Size = New System.Drawing.Size(25, 13)
      Me.label9.TabIndex = 1
      Me.label9.Text = "Top"
      '
      'label10
      '
      Me.label10.AutoSize = True
      Me.label10.Location = New System.Drawing.Point(16, 25)
      Me.label10.Name = "label10"
      Me.label10.Size = New System.Drawing.Size(26, 13)
      Me.label10.TabIndex = 0
      Me.label10.Text = "Left"
      '
      'groupBox4
      '
      Me.groupBox4.Controls.Add(Me._numBottomBorderWidth)
      Me.groupBox4.Controls.Add(Me._numTopBorderWidth)
      Me.groupBox4.Controls.Add(Me._numRightBorderWidth)
      Me.groupBox4.Controls.Add(Me._numLeftBorderWidth)
      Me.groupBox4.Controls.Add(Me._lblBottomBorderWidth)
      Me.groupBox4.Controls.Add(Me._lblRightBorderWidth)
      Me.groupBox4.Controls.Add(Me._lblTopBorderWidth)
      Me.groupBox4.Controls.Add(Me._lblLeftBorderWidth)
      Me.groupBox4.Location = New System.Drawing.Point(3, 225)
      Me.groupBox4.Name = "groupBox4"
      Me.groupBox4.Size = New System.Drawing.Size(273, 93)
      Me.groupBox4.TabIndex = 6
      Me.groupBox4.TabStop = False
      Me.groupBox4.Text = "Border Width"
      '
      '_numBottomBorderWidth
      '
      Me._numBottomBorderWidth.Enabled = False
      Me._numBottomBorderWidth.Location = New System.Drawing.Point(186, 53)
      Me._numBottomBorderWidth.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
      Me._numBottomBorderWidth.Name = "_numBottomBorderWidth"
      Me._numBottomBorderWidth.Size = New System.Drawing.Size(69, 20)
      Me._numBottomBorderWidth.TabIndex = 9
      '
      '_numTopBorderWidth
      '
      Me._numTopBorderWidth.Enabled = False
      Me._numTopBorderWidth.Location = New System.Drawing.Point(186, 23)
      Me._numTopBorderWidth.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
      Me._numTopBorderWidth.Name = "_numTopBorderWidth"
      Me._numTopBorderWidth.Size = New System.Drawing.Size(69, 20)
      Me._numTopBorderWidth.TabIndex = 7
      '
      '_numRightBorderWidth
      '
      Me._numRightBorderWidth.Enabled = False
      Me._numRightBorderWidth.Location = New System.Drawing.Point(62, 53)
      Me._numRightBorderWidth.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
      Me._numRightBorderWidth.Name = "_numRightBorderWidth"
      Me._numRightBorderWidth.Size = New System.Drawing.Size(69, 20)
      Me._numRightBorderWidth.TabIndex = 8
      '
      '_numLeftBorderWidth
      '
      Me._numLeftBorderWidth.Enabled = False
      Me._numLeftBorderWidth.Location = New System.Drawing.Point(62, 23)
      Me._numLeftBorderWidth.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
      Me._numLeftBorderWidth.Name = "_numLeftBorderWidth"
      Me._numLeftBorderWidth.Size = New System.Drawing.Size(69, 20)
      Me._numLeftBorderWidth.TabIndex = 6
      '
      '_lblBottomBorderWidth
      '
      Me._lblBottomBorderWidth.AutoSize = True
      Me._lblBottomBorderWidth.Location = New System.Drawing.Point(137, 55)
      Me._lblBottomBorderWidth.Name = "_lblBottomBorderWidth"
      Me._lblBottomBorderWidth.Size = New System.Drawing.Size(41, 13)
      Me._lblBottomBorderWidth.TabIndex = 3
      Me._lblBottomBorderWidth.Text = "Bottom"
      '
      '_lblRightBorderWidth
      '
      Me._lblRightBorderWidth.AutoSize = True
      Me._lblRightBorderWidth.Location = New System.Drawing.Point(17, 55)
      Me._lblRightBorderWidth.Name = "_lblRightBorderWidth"
      Me._lblRightBorderWidth.Size = New System.Drawing.Size(32, 13)
      Me._lblRightBorderWidth.TabIndex = 2
      Me._lblRightBorderWidth.Text = "Right"
      '
      '_lblTopBorderWidth
      '
      Me._lblTopBorderWidth.AutoSize = True
      Me._lblTopBorderWidth.Location = New System.Drawing.Point(137, 25)
      Me._lblTopBorderWidth.Name = "_lblTopBorderWidth"
      Me._lblTopBorderWidth.Size = New System.Drawing.Size(25, 13)
      Me._lblTopBorderWidth.TabIndex = 1
      Me._lblTopBorderWidth.Text = "Top"
      '
      '_lblLeftBorderWidth
      '
      Me._lblLeftBorderWidth.AutoSize = True
      Me._lblLeftBorderWidth.Location = New System.Drawing.Point(17, 25)
      Me._lblLeftBorderWidth.Name = "_lblLeftBorderWidth"
      Me._lblLeftBorderWidth.Size = New System.Drawing.Size(26, 13)
      Me._lblLeftBorderWidth.TabIndex = 0
      Me._lblLeftBorderWidth.Text = "Left"
      '
      'UpdateCellsControl
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.groupBox4)
      Me.Controls.Add(Me.groupBox2)
      Me.Controls.Add(Me.groupBox3)
      Me.Controls.Add(Me.groupBox1)
      Me.Controls.Add(Me._areaGroupBox)
      Me.Name = "UpdateCellsControl"
      Me.Size = New System.Drawing.Size(608, 327)
      Me._areaGroupBox.ResumeLayout(False)
      Me._areaGroupBox.PerformLayout()
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      Me.groupBox3.ResumeLayout(False)
      Me.groupBox3.PerformLayout()
      Me.groupBox2.ResumeLayout(False)
      Me.groupBox2.PerformLayout()
      Me.groupBox4.ResumeLayout(False)
      Me.groupBox4.PerformLayout()
      CType(Me._numBottomBorderWidth, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numTopBorderWidth, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numRightBorderWidth, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numLeftBorderWidth, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _areaGroupBox As System.Windows.Forms.GroupBox
   Private _tbHeight As System.Windows.Forms.TextBox
   Private _heightLabel As System.Windows.Forms.Label
   Private _tbWidth As System.Windows.Forms.TextBox
   Private _widthLabel As System.Windows.Forms.Label
   Private _tbTop As System.Windows.Forms.TextBox
   Private _topLabel As System.Windows.Forms.Label
   Private _tbLeft As System.Windows.Forms.TextBox
   Private _leftLabel As System.Windows.Forms.Label
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private groupBox3 As System.Windows.Forms.GroupBox
   Private _lblBottomBorderColor As System.Windows.Forms.Label
   Private _lblRightBorderColor As System.Windows.Forms.Label
   Private _lblTopBorderColor As System.Windows.Forms.Label
   Private _lblLeftBorderColor As System.Windows.Forms.Label
   Private WithEvents _cmbCellType As System.Windows.Forms.ComboBox
   Private WithEvents _btnBottomBorderColor As System.Windows.Forms.Button
   Private WithEvents _btnRightBorderColor As System.Windows.Forms.Button
   Private WithEvents _btnTopBorderColor As System.Windows.Forms.Button
   Private WithEvents _btnLeftBorderColor As System.Windows.Forms.Button
   Private label6 As System.Windows.Forms.Label
   Private groupBox2 As System.Windows.Forms.GroupBox
   Private label7 As System.Windows.Forms.Label
   Private label8 As System.Windows.Forms.Label
   Private label9 As System.Windows.Forms.Label
   Private label10 As System.Windows.Forms.Label
   Private WithEvents _cmbLeftBorderStyle As System.Windows.Forms.ComboBox
   Private WithEvents _cmbRightBorderStyle As System.Windows.Forms.ComboBox
   Private WithEvents _cmbBottomBorderStyle As System.Windows.Forms.ComboBox
   Private WithEvents _cmbTopBorderStyle As System.Windows.Forms.ComboBox
   Private groupBox4 As System.Windows.Forms.GroupBox
   Private _lblBottomBorderWidth As System.Windows.Forms.Label
   Private _lblRightBorderWidth As System.Windows.Forms.Label
   Private _lblTopBorderWidth As System.Windows.Forms.Label
   Private _lblLeftBorderWidth As System.Windows.Forms.Label
   Private WithEvents _numBottomBorderWidth As System.Windows.Forms.NumericUpDown
   Private WithEvents _numTopBorderWidth As System.Windows.Forms.NumericUpDown
   Private WithEvents _numRightBorderWidth As System.Windows.Forms.NumericUpDown
   Private WithEvents _numLeftBorderWidth As System.Windows.Forms.NumericUpDown
End Class
