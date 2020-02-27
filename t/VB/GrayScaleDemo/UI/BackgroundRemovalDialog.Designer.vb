
Partial Class BackgroundRemovalDialog
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
      Me._gbOptions = New System.Windows.Forms.GroupBox()
      Me._cbEnableEnhancements = New System.Windows.Forms.CheckBox()
      Me._txtRemovalFactor = New System.Windows.Forms.TextBox()
      Me._numRemovalFactor = New System.Windows.Forms.TrackBar()
      Me._numContrast = New System.Windows.Forms.NumericUpDown()
      Me._lblAmount = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me._cbInvert = New System.Windows.Forms.CheckBox()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me._lblLevels = New System.Windows.Forms.Label()
      Me._lblCoefficients = New System.Windows.Forms.Label()
      Me._numEdgeLevel = New System.Windows.Forms.NumericUpDown()
      Me._numEdgeCoef = New System.Windows.Forms.NumericUpDown()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnApply = New System.Windows.Forms.Button()
      Me._gbOptions.SuspendLayout()
      CType(Me._numRemovalFactor, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numContrast, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.groupBox1.SuspendLayout()
      CType(Me._numEdgeLevel, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numEdgeCoef, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me._cbEnableEnhancements)
      Me._gbOptions.Controls.Add(Me._txtRemovalFactor)
      Me._gbOptions.Controls.Add(Me._numRemovalFactor)
      Me._gbOptions.Controls.Add(Me._numContrast)
      Me._gbOptions.Controls.Add(Me._lblAmount)
      Me._gbOptions.Controls.Add(Me.label1)
      Me._gbOptions.Controls.Add(Me._cbInvert)
      Me._gbOptions.Controls.Add(Me.groupBox1)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbOptions.Location = New System.Drawing.Point(9, 4)
      Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Size = New System.Drawing.Size(285, 279)
      Me._gbOptions.TabIndex = 0
      Me._gbOptions.TabStop = False
      Me._gbOptions.Text = "Parameters"
      ' 
      ' _cbEnableEnhancements
      ' 
      Me._cbEnableEnhancements.AutoSize = True
      Me._cbEnableEnhancements.Checked = True
      Me._cbEnableEnhancements.CheckState = System.Windows.Forms.CheckState.Checked
      Me._cbEnableEnhancements.Location = New System.Drawing.Point(25, 112)
      Me._cbEnableEnhancements.Name = "_cbEnableEnhancements"
      Me._cbEnableEnhancements.Size = New System.Drawing.Size(133, 17)
      Me._cbEnableEnhancements.TabIndex = 9
      Me._cbEnableEnhancements.Text = "Enable Enhancements"
      Me._cbEnableEnhancements.UseVisualStyleBackColor = True
      ' 
      ' _txtRemovalFactor
      ' 
      Me._txtRemovalFactor.Location = New System.Drawing.Point(227, 72)
      Me._txtRemovalFactor.MaxLength = 4
      Me._txtRemovalFactor.Name = "_txtRemovalFactor"
      Me._txtRemovalFactor.[ReadOnly] = True
      Me._txtRemovalFactor.Size = New System.Drawing.Size(43, 20)
      Me._txtRemovalFactor.TabIndex = 14
      Me._txtRemovalFactor.Text = "800"
      ' 
      ' _numRemovalFactor
      ' 
      Me._numRemovalFactor.Location = New System.Drawing.Point(12, 72)
      Me._numRemovalFactor.Maximum = 1000
      Me._numRemovalFactor.Name = "_numRemovalFactor"
      Me._numRemovalFactor.Size = New System.Drawing.Size(209, 45)
      Me._numRemovalFactor.TabIndex = 13
      Me._numRemovalFactor.Value = 800
      ' 
      ' _numContrast
      ' 
      Me._numContrast.DecimalPlaces = 2
      Me._numContrast.Increment = New Decimal(New Integer() {50, 0, 0, 131072})
      Me._numContrast.Location = New System.Drawing.Point(161, 141)
      Me._numContrast.Margin = New System.Windows.Forms.Padding(2)
      Me._numContrast.Name = "_numContrast"
      Me._numContrast.Size = New System.Drawing.Size(109, 20)
      Me._numContrast.TabIndex = 1
      Me._numContrast.Value = New Decimal(New Integer() {60, 0, 0, 65536})
      ' 
      ' _lblAmount
      ' 
      Me._lblAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblAmount.Location = New System.Drawing.Point(27, 143)
      Me._lblAmount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblAmount.Name = "_lblAmount"
      Me._lblAmount.Size = New System.Drawing.Size(65, 22)
      Me._lblAmount.TabIndex = 0
      Me._lblAmount.Text = "Contrast"
      ' 
      ' label1
      ' 
      Me.label1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.label1.Location = New System.Drawing.Point(27, 47)
      Me.label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(89, 22)
      Me.label1.TabIndex = 9
      Me.label1.Text = "Removal Factor"
      ' 
      ' _cbInvert
      ' 
      Me._cbInvert.AutoSize = True
      Me._cbInvert.Location = New System.Drawing.Point(28, 19)
      Me._cbInvert.Name = "_cbInvert"
      Me._cbInvert.Size = New System.Drawing.Size(53, 17)
      Me._cbInvert.TabIndex = 4
      Me._cbInvert.Text = "Invert"
      Me._cbInvert.UseVisualStyleBackColor = True
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.Add(Me._lblLevels)
      Me.groupBox1.Controls.Add(Me._lblCoefficients)
      Me.groupBox1.Controls.Add(Me._numEdgeLevel)
      Me.groupBox1.Controls.Add(Me._numEdgeCoef)
      Me.groupBox1.Location = New System.Drawing.Point(11, 179)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(259, 83)
      Me.groupBox1.TabIndex = 8
      Me.groupBox1.TabStop = False
      Me.groupBox1.Text = "Edge Enhancment"
      ' 
      ' _lblLevels
      ' 
      Me._lblLevels.AutoSize = True
      Me._lblLevels.Location = New System.Drawing.Point(16, 21)
      Me._lblLevels.Name = "_lblLevels"
      Me._lblLevels.Size = New System.Drawing.Size(66, 13)
      Me._lblLevels.TabIndex = 11
      Me._lblLevels.Text = "Edge Levels"
      ' 
      ' _lblCoefficients
      ' 
      Me._lblCoefficients.AutoSize = True
      Me._lblCoefficients.Location = New System.Drawing.Point(16, 51)
      Me._lblCoefficients.Name = "_lblCoefficients"
      Me._lblCoefficients.Size = New System.Drawing.Size(90, 13)
      Me._lblCoefficients.TabIndex = 10
      Me._lblCoefficients.Text = "Edge Coefficients"
      ' 
      ' _numEdgeLevel
      ' 
      Me._numEdgeLevel.Location = New System.Drawing.Point(143, 16)
      Me._numEdgeLevel.Margin = New System.Windows.Forms.Padding(2)
      Me._numEdgeLevel.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
      Me._numEdgeLevel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numEdgeLevel.Name = "_numEdgeLevel"
      Me._numEdgeLevel.Size = New System.Drawing.Size(109, 20)
      Me._numEdgeLevel.TabIndex = 3
      Me._numEdgeLevel.Value = New Decimal(New Integer() {9, 0, 0, 0})
      ' 
      ' _numEdgeCoef
      ' 
      Me._numEdgeCoef.DecimalPlaces = 2
      Me._numEdgeCoef.Increment = New Decimal(New Integer() {2, 0, 0, 65536})
      Me._numEdgeCoef.Location = New System.Drawing.Point(143, 49)
      Me._numEdgeCoef.Margin = New System.Windows.Forms.Padding(2)
      Me._numEdgeCoef.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
      Me._numEdgeCoef.Name = "_numEdgeCoef"
      Me._numEdgeCoef.Size = New System.Drawing.Size(109, 20)
      Me._numEdgeCoef.TabIndex = 5
      Me._numEdgeCoef.Value = New Decimal(New Integer() {17, 0, 0, 65536})
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(211, 300)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 2
      Me._btnCancel.Text = "Cancel"
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(122, 300)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 1
      Me._btnOk.Text = "OK"
      ' 
      ' _btnApply
      ' 
      Me._btnApply.Location = New System.Drawing.Point(26, 300)
      Me._btnApply.Name = "_btnApply"
      Me._btnApply.Size = New System.Drawing.Size(75, 23)
      Me._btnApply.TabIndex = 8
      Me._btnApply.Text = "Apply"
      Me._btnApply.UseVisualStyleBackColor = True
      ' 
      ' BackgroundRemovalDialog
      ' 
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(315, 339)
      Me.Controls.Add(Me._btnApply)
      Me.Controls.Add(Me._gbOptions)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Margin = New System.Windows.Forms.Padding(2)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "BackgroundRemovalDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Background Removal"
      Me._gbOptions.ResumeLayout(False)
      Me._gbOptions.PerformLayout()
      CType(Me._numRemovalFactor, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numContrast, System.ComponentModel.ISupportInitialize).EndInit()
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      CType(Me._numEdgeLevel, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numEdgeCoef, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbOptions As System.Windows.Forms.GroupBox
   Private WithEvents _numEdgeLevel As System.Windows.Forms.NumericUpDown
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _numEdgeCoef As System.Windows.Forms.NumericUpDown
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private WithEvents _btnApply As System.Windows.Forms.Button
   Private _lblLevels As System.Windows.Forms.Label
   Private _lblCoefficients As System.Windows.Forms.Label
   Private WithEvents _numContrast As System.Windows.Forms.NumericUpDown
   Private _lblAmount As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private _cbInvert As System.Windows.Forms.CheckBox
   Private WithEvents _numRemovalFactor As System.Windows.Forms.TrackBar
   Private _txtRemovalFactor As System.Windows.Forms.TextBox
   Private WithEvents _cbEnableEnhancements As System.Windows.Forms.CheckBox
End Class