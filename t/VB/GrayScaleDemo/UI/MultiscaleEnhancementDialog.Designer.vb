
Partial Class MultiscaleEnhancementDialog
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
      Me.groupBox2 = New System.Windows.Forms.GroupBox()
      Me._cbLatCoef = New System.Windows.Forms.CheckBox()
      Me._cbLatLevel = New System.Windows.Forms.CheckBox()
      Me._cbLatitude = New System.Windows.Forms.CheckBox()
      Me._numLatLevel = New System.Windows.Forms.NumericUpDown()
      Me._numLatCoef = New System.Windows.Forms.NumericUpDown()
      Me.groupBox1 = New System.Windows.Forms.GroupBox()
      Me._cbEdgeCoef = New System.Windows.Forms.CheckBox()
      Me._cbEdgeLevel = New System.Windows.Forms.CheckBox()
      Me._cbEdge = New System.Windows.Forms.CheckBox()
      Me._numEdgeLevel = New System.Windows.Forms.NumericUpDown()
      Me._numEdgeCoef = New System.Windows.Forms.NumericUpDown()
      Me._numContrast = New System.Windows.Forms.NumericUpDown()
      Me._lblAmount = New System.Windows.Forms.Label()
      Me._cbFilter = New System.Windows.Forms.ComboBox()
      Me._lblColorSpace = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._btnApply = New System.Windows.Forms.Button()
      Me._gbOptions.SuspendLayout()
      Me.groupBox2.SuspendLayout()
      CType(Me._numLatLevel, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numLatCoef, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.groupBox1.SuspendLayout()
      CType(Me._numEdgeLevel, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numEdgeCoef, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numContrast, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me.groupBox2)
      Me._gbOptions.Controls.Add(Me.groupBox1)
      Me._gbOptions.Controls.Add(Me._numContrast)
      Me._gbOptions.Controls.Add(Me._lblAmount)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbOptions.Location = New System.Drawing.Point(9, 4)
      Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Size = New System.Drawing.Size(285, 277)
      Me._gbOptions.TabIndex = 0
      Me._gbOptions.TabStop = False
      Me._gbOptions.Text = "Enhancement"
      ' 
      ' groupBox2
      ' 
      Me.groupBox2.Controls.Add(Me._cbLatCoef)
      Me.groupBox2.Controls.Add(Me._cbLatLevel)
      Me.groupBox2.Controls.Add(Me._cbLatitude)
      Me.groupBox2.Controls.Add(Me._numLatLevel)
      Me.groupBox2.Controls.Add(Me._numLatCoef)
      Me.groupBox2.Location = New System.Drawing.Point(11, 162)
      Me.groupBox2.Name = "groupBox2"
      Me.groupBox2.Size = New System.Drawing.Size(259, 100)
      Me.groupBox2.TabIndex = 6
      Me.groupBox2.TabStop = False
      ' 
      ' _cbLatCoef
      ' 
      Me._cbLatCoef.AutoSize = True
      Me._cbLatCoef.Enabled = False
      Me._cbLatCoef.Location = New System.Drawing.Point(12, 64)
      Me._cbLatCoef.Name = "_cbLatCoef"
      Me._cbLatCoef.Size = New System.Drawing.Size(122, 17)
      Me._cbLatCoef.TabIndex = 12
      Me._cbLatCoef.Text = "Latitude Coefficients"
      Me._cbLatCoef.UseVisualStyleBackColor = True
      ' 
      ' _cbLatLevel
      ' 
      Me._cbLatLevel.AutoSize = True
      Me._cbLatLevel.Enabled = False
      Me._cbLatLevel.Location = New System.Drawing.Point(12, 33)
      Me._cbLatLevel.Name = "_cbLatLevel"
      Me._cbLatLevel.Size = New System.Drawing.Size(98, 17)
      Me._cbLatLevel.TabIndex = 11
      Me._cbLatLevel.Text = "Latitude Levels"
      Me._cbLatLevel.UseVisualStyleBackColor = True
      ' 
      ' _cbLatitude
      ' 
      Me._cbLatitude.AutoSize = True
      Me._cbLatitude.Location = New System.Drawing.Point(6, 0)
      Me._cbLatitude.Name = "_cbLatitude"
      Me._cbLatitude.Size = New System.Drawing.Size(116, 17)
      Me._cbLatitude.TabIndex = 10
      Me._cbLatitude.Text = "Latitude Reduction"
      Me._cbLatitude.UseVisualStyleBackColor = True
      ' 
      ' _numLatLevel
      ' 
      Me._numLatLevel.Enabled = False
      Me._numLatLevel.Location = New System.Drawing.Point(144, 30)
      Me._numLatLevel.Margin = New System.Windows.Forms.Padding(2)
      Me._numLatLevel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numLatLevel.Name = "_numLatLevel"
      Me._numLatLevel.Size = New System.Drawing.Size(109, 20)
      Me._numLatLevel.TabIndex = 7
      Me._numLatLevel.Value = New Decimal(New Integer() {5, 0, 0, 0})
      ' 
      ' _numLatCoef
      ' 
      Me._numLatCoef.DecimalPlaces = 2
      Me._numLatCoef.Enabled = False
      Me._numLatCoef.Increment = New Decimal(New Integer() {2, 0, 0, 65536})
      Me._numLatCoef.Location = New System.Drawing.Point(144, 61)
      Me._numLatCoef.Margin = New System.Windows.Forms.Padding(2)
      Me._numLatCoef.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
      Me._numLatCoef.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numLatCoef.Name = "_numLatCoef"
      Me._numLatCoef.Size = New System.Drawing.Size(109, 20)
      Me._numLatCoef.TabIndex = 9
      Me._numLatCoef.Value = New Decimal(New Integer() {14, 0, 0, 65536})
      ' 
      ' groupBox1
      ' 
      Me.groupBox1.Controls.Add(Me._cbEdgeCoef)
      Me.groupBox1.Controls.Add(Me._cbEdgeLevel)
      Me.groupBox1.Controls.Add(Me._cbEdge)
      Me.groupBox1.Controls.Add(Me._numEdgeLevel)
      Me.groupBox1.Controls.Add(Me._numEdgeCoef)
      Me.groupBox1.Location = New System.Drawing.Point(11, 56)
      Me.groupBox1.Name = "groupBox1"
      Me.groupBox1.Size = New System.Drawing.Size(259, 100)
      Me.groupBox1.TabIndex = 8
      Me.groupBox1.TabStop = False
      ' 
      ' _cbEdgeCoef
      ' 
      Me._cbEdgeCoef.AutoSize = True
      Me._cbEdgeCoef.Enabled = False
      Me._cbEdgeCoef.Location = New System.Drawing.Point(12, 63)
      Me._cbEdgeCoef.Name = "_cbEdgeCoef"
      Me._cbEdgeCoef.Size = New System.Drawing.Size(109, 17)
      Me._cbEdgeCoef.TabIndex = 10
      Me._cbEdgeCoef.Text = "Edge Coefficients"
      Me._cbEdgeCoef.UseVisualStyleBackColor = True
      ' 
      ' _cbEdgeLevel
      ' 
      Me._cbEdgeLevel.AutoSize = True
      Me._cbEdgeLevel.Enabled = False
      Me._cbEdgeLevel.Location = New System.Drawing.Point(12, 32)
      Me._cbEdgeLevel.Name = "_cbEdgeLevel"
      Me._cbEdgeLevel.Size = New System.Drawing.Size(85, 17)
      Me._cbEdgeLevel.TabIndex = 9
      Me._cbEdgeLevel.Text = "Edge Levels"
      Me._cbEdgeLevel.UseVisualStyleBackColor = True
      ' 
      ' _cbEdge
      ' 
      Me._cbEdge.AutoSize = True
      Me._cbEdge.Location = New System.Drawing.Point(6, 0)
      Me._cbEdge.Name = "_cbEdge"
      Me._cbEdge.Size = New System.Drawing.Size(120, 17)
      Me._cbEdge.TabIndex = 8
      Me._cbEdge.Text = "Edge Enhancement"
      Me._cbEdge.UseVisualStyleBackColor = True
      ' 
      ' _numEdgeLevel
      ' 
      Me._numEdgeLevel.Enabled = False
      Me._numEdgeLevel.Location = New System.Drawing.Point(144, 29)
      Me._numEdgeLevel.Margin = New System.Windows.Forms.Padding(2)
      Me._numEdgeLevel.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me._numEdgeLevel.Name = "_numEdgeLevel"
      Me._numEdgeLevel.Size = New System.Drawing.Size(109, 20)
      Me._numEdgeLevel.TabIndex = 3
      Me._numEdgeLevel.Value = New Decimal(New Integer() {3, 0, 0, 0})
      ' 
      ' _numEdgeCoef
      ' 
      Me._numEdgeCoef.DecimalPlaces = 2
      Me._numEdgeCoef.Enabled = False
      Me._numEdgeCoef.Increment = New Decimal(New Integer() {2, 0, 0, 65536})
      Me._numEdgeCoef.Location = New System.Drawing.Point(144, 60)
      Me._numEdgeCoef.Margin = New System.Windows.Forms.Padding(2)
      Me._numEdgeCoef.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
      Me._numEdgeCoef.Name = "_numEdgeCoef"
      Me._numEdgeCoef.Size = New System.Drawing.Size(109, 20)
      Me._numEdgeCoef.TabIndex = 5
      Me._numEdgeCoef.Value = New Decimal(New Integer() {17, 0, 0, 65536})
      ' 
      ' _numContrast
      ' 
      Me._numContrast.DecimalPlaces = 2
      Me._numContrast.Increment = New Decimal(New Integer() {50, 0, 0, 131072})
      Me._numContrast.Location = New System.Drawing.Point(155, 27)
      Me._numContrast.Margin = New System.Windows.Forms.Padding(2)
      Me._numContrast.Name = "_numContrast"
      Me._numContrast.Size = New System.Drawing.Size(109, 20)
      Me._numContrast.TabIndex = 1
      Me._numContrast.Value = New Decimal(New Integer() {15, 0, 0, 0})
      ' 
      ' _lblAmount
      ' 
      Me._lblAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblAmount.Location = New System.Drawing.Point(14, 27)
      Me._lblAmount.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblAmount.Name = "_lblAmount"
      Me._lblAmount.Size = New System.Drawing.Size(65, 22)
      Me._lblAmount.TabIndex = 0
      Me._lblAmount.Text = "Contrast"
      Me._lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _cbFilter
      ' 
      Me._cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbFilter.Items.AddRange(New Object() {"Normal", "Resample", "Bicubic", "Gaussian"})
      Me._cbFilter.Location = New System.Drawing.Point(163, 285)
      Me._cbFilter.Margin = New System.Windows.Forms.Padding(2)
      Me._cbFilter.Name = "_cbFilter"
      Me._cbFilter.Size = New System.Drawing.Size(110, 21)
      Me._cbFilter.TabIndex = 7
      ' 
      ' _lblColorSpace
      ' 
      Me._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblColorSpace.Location = New System.Drawing.Point(29, 289)
      Me._lblColorSpace.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblColorSpace.Name = "_lblColorSpace"
      Me._lblColorSpace.Size = New System.Drawing.Size(65, 22)
      Me._lblColorSpace.TabIndex = 6
      Me._lblColorSpace.Text = "Filter"
      Me._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(211, 321)
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
      Me._btnOk.Location = New System.Drawing.Point(122, 321)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 1
      Me._btnOk.Text = "OK"
      ' 
      ' _btnApply
      ' 
      Me._btnApply.Location = New System.Drawing.Point(26, 321)
      Me._btnApply.Name = "_btnApply"
      Me._btnApply.Size = New System.Drawing.Size(75, 23)
      Me._btnApply.TabIndex = 8
      Me._btnApply.Text = "Apply"
      Me._btnApply.UseVisualStyleBackColor = True
      ' 
      ' MultiscaleEnhancementDialog
      ' 
      Me.AcceptButton = Me._btnOk
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.CancelButton = Me._btnCancel
      Me.ClientSize = New System.Drawing.Size(315, 354)
      Me.Controls.Add(Me._btnApply)
      Me.Controls.Add(Me._lblColorSpace)
      Me.Controls.Add(Me._cbFilter)
      Me.Controls.Add(Me._gbOptions)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.Margin = New System.Windows.Forms.Padding(2)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "MultiscaleEnhancementDialog"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Multiscale Enhancement"
      Me._gbOptions.ResumeLayout(False)
      Me.groupBox2.ResumeLayout(False)
      Me.groupBox2.PerformLayout()
      CType(Me._numLatLevel, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numLatCoef, System.ComponentModel.ISupportInitialize).EndInit()
      Me.groupBox1.ResumeLayout(False)
      Me.groupBox1.PerformLayout()
      CType(Me._numEdgeLevel, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numEdgeCoef, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numContrast, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbOptions As System.Windows.Forms.GroupBox
   Private _cbFilter As System.Windows.Forms.ComboBox
   Private _lblColorSpace As System.Windows.Forms.Label
   Private WithEvents _numEdgeLevel As System.Windows.Forms.NumericUpDown
   Private WithEvents _numContrast As System.Windows.Forms.NumericUpDown
   Private _lblAmount As System.Windows.Forms.Label
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _numEdgeCoef As System.Windows.Forms.NumericUpDown
   Private groupBox2 As System.Windows.Forms.GroupBox
   Private _numLatLevel As System.Windows.Forms.NumericUpDown
   Private _numLatCoef As System.Windows.Forms.NumericUpDown
   Private groupBox1 As System.Windows.Forms.GroupBox
   Private WithEvents _cbLatitude As System.Windows.Forms.CheckBox
   Private WithEvents _cbEdge As System.Windows.Forms.CheckBox
   Private WithEvents _cbEdgeLevel As System.Windows.Forms.CheckBox
   Private WithEvents _cbLatCoef As System.Windows.Forms.CheckBox
   Private WithEvents _cbLatLevel As System.Windows.Forms.CheckBox
   Private WithEvents _cbEdgeCoef As System.Windows.Forms.CheckBox
   Private WithEvents _btnApply As System.Windows.Forms.Button
End Class