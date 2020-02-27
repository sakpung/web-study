Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class PasswordOptionsView
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
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.checkBoxNumber = New System.Windows.Forms.CheckBox()
         Me.checkBoxSymbol = New System.Windows.Forms.CheckBox()
         Me.checkBoxUppercase = New System.Windows.Forms.CheckBox()
         Me.checkBoxLowercase = New System.Windows.Forms.CheckBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.label2 = New System.Windows.Forms.Label()
         Me.label3 = New System.Windows.Forms.Label()
         Me.numericUpDownMinLength = New System.Windows.Forms.NumericUpDown()
         Me.numericUpDownExpire = New System.Windows.Forms.NumericUpDown()
         Me.numericUpDownMax = New System.Windows.Forms.NumericUpDown()
         Me.numericUpDownIdleTimeout = New System.Windows.Forms.NumericUpDown()
         Me.label4 = New System.Windows.Forms.Label()
         Me.checkBoxIdleTimeout = New System.Windows.Forms.CheckBox()
         Me.groupBox2 = New System.Windows.Forms.GroupBox()
         Me.groupBox1.SuspendLayout()
         CType(Me.numericUpDownMinLength, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.numericUpDownExpire, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.numericUpDownMax, System.ComponentModel.ISupportInitialize).BeginInit()
         CType(Me.numericUpDownIdleTimeout, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.groupBox2.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me.checkBoxNumber)
         Me.groupBox1.Controls.Add(Me.checkBoxSymbol)
         Me.groupBox1.Controls.Add(Me.checkBoxUppercase)
         Me.groupBox1.Controls.Add(Me.checkBoxLowercase)
         Me.groupBox1.Location = New System.Drawing.Point(4, 4)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(246, 73)
         Me.groupBox1.TabIndex = 0
         Me.groupBox1.TabStop = False
         Me.groupBox1.Text = "Complexity"
         ' 
         ' checkBoxNumber
         ' 
         Me.checkBoxNumber.AutoSize = True
         Me.checkBoxNumber.Location = New System.Drawing.Point(113, 44)
         Me.checkBoxNumber.Name = "checkBoxNumber"
         Me.checkBoxNumber.Size = New System.Drawing.Size(63, 17)
         Me.checkBoxNumber.TabIndex = 3
         Me.checkBoxNumber.Text = "Number"
         Me.checkBoxNumber.UseVisualStyleBackColor = True
         ' 
         ' checkBoxSymbol
         ' 
         Me.checkBoxSymbol.AutoSize = True
         Me.checkBoxSymbol.Location = New System.Drawing.Point(113, 20)
         Me.checkBoxSymbol.Name = "checkBoxSymbol"
         Me.checkBoxSymbol.Size = New System.Drawing.Size(60, 17)
         Me.checkBoxSymbol.TabIndex = 2
         Me.checkBoxSymbol.Text = "Symbol"
         Me.checkBoxSymbol.UseVisualStyleBackColor = True
         ' 
         ' checkBoxUppercase
         ' 
         Me.checkBoxUppercase.AutoSize = True
         Me.checkBoxUppercase.Location = New System.Drawing.Point(7, 44)
         Me.checkBoxUppercase.Name = "checkBoxUppercase"
         Me.checkBoxUppercase.Size = New System.Drawing.Size(78, 17)
         Me.checkBoxUppercase.TabIndex = 1
         Me.checkBoxUppercase.Text = "Uppercase"
         Me.checkBoxUppercase.UseVisualStyleBackColor = True
         ' 
         ' checkBoxLowercase
         ' 
         Me.checkBoxLowercase.AutoSize = True
         Me.checkBoxLowercase.Location = New System.Drawing.Point(7, 20)
         Me.checkBoxLowercase.Name = "checkBoxLowercase"
         Me.checkBoxLowercase.Size = New System.Drawing.Size(78, 17)
         Me.checkBoxLowercase.TabIndex = 0
         Me.checkBoxLowercase.Text = "Lowercase"
         Me.checkBoxLowercase.UseVisualStyleBackColor = True
         ' 
         ' label1
         ' 
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(4, 92)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(87, 13)
         Me.label1.TabIndex = 1
         Me.label1.Text = "Minimum Length:"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(4, 114)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(99, 13)
         Me.label2.TabIndex = 2
         Me.label2.Text = "Days To Expiration:"
         ' 
         ' label3
         ' 
         Me.label3.AutoSize = True
         Me.label3.Location = New System.Drawing.Point(4, 138)
         Me.label3.Name = "label3"
         Me.label3.Size = New System.Drawing.Size(96, 13)
         Me.label3.TabIndex = 3
         Me.label3.Text = "Max Remembered:"
         ' 
         ' numericUpDownMinLength
         ' 
         Me.numericUpDownMinLength.Location = New System.Drawing.Point(117, 84)
         Me.numericUpDownMinLength.Name = "numericUpDownMinLength"
         Me.numericUpDownMinLength.Size = New System.Drawing.Size(133, 20)
         Me.numericUpDownMinLength.TabIndex = 4
         ' 
         ' numericUpDownExpire
         ' 
         Me.numericUpDownExpire.Location = New System.Drawing.Point(117, 107)
         Me.numericUpDownExpire.Name = "numericUpDownExpire"
         Me.numericUpDownExpire.Size = New System.Drawing.Size(133, 20)
         Me.numericUpDownExpire.TabIndex = 5
         ' 
         ' numericUpDownMax
         ' 
         Me.numericUpDownMax.Location = New System.Drawing.Point(117, 131)
         Me.numericUpDownMax.Name = "numericUpDownMax"
         Me.numericUpDownMax.Size = New System.Drawing.Size(133, 20)
         Me.numericUpDownMax.TabIndex = 6
         ' 
         ' numericUpDownIdleTimeout
         ' 
         Me.numericUpDownIdleTimeout.Increment = New Decimal(New Integer() {30, 0, 0, 0})
         Me.numericUpDownIdleTimeout.Location = New System.Drawing.Point(113, 41)
         Me.numericUpDownIdleTimeout.Maximum = New Decimal(New Integer() {1200, 0, 0, 0})
         Me.numericUpDownIdleTimeout.Name = "numericUpDownIdleTimeout"
         Me.numericUpDownIdleTimeout.Size = New System.Drawing.Size(127, 20)
         Me.numericUpDownIdleTimeout.TabIndex = 8
         ' 
         ' label4
         ' 
         Me.label4.AutoSize = True
         Me.label4.Location = New System.Drawing.Point(29, 48)
         Me.label4.Name = "label4"
         Me.label4.Size = New System.Drawing.Size(79, 13)
         Me.label4.TabIndex = 7
         Me.label4.Text = "Timeout (secs):"
         ' 
         ' checkBoxIdleTimeout
         ' 
         Me.checkBoxIdleTimeout.AutoSize = True
         Me.checkBoxIdleTimeout.Location = New System.Drawing.Point(9, 28)
         Me.checkBoxIdleTimeout.Name = "checkBoxIdleTimeout"
         Me.checkBoxIdleTimeout.Size = New System.Drawing.Size(59, 17)
         Me.checkBoxIdleTimeout.TabIndex = 9
         Me.checkBoxIdleTimeout.Text = "Enable"
         Me.checkBoxIdleTimeout.UseVisualStyleBackColor = True
         ' 
         ' groupBox2
         ' 
         Me.groupBox2.Controls.Add(Me.checkBoxIdleTimeout)
         Me.groupBox2.Controls.Add(Me.numericUpDownIdleTimeout)
         Me.groupBox2.Controls.Add(Me.label4)
         Me.groupBox2.Location = New System.Drawing.Point(4, 176)
         Me.groupBox2.Name = "groupBox2"
         Me.groupBox2.Size = New System.Drawing.Size(246, 100)
         Me.groupBox2.TabIndex = 10
         Me.groupBox2.TabStop = False
         Me.groupBox2.Text = "Idle Timeout"
         ' 
         ' PasswordOptionsView
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.Controls.Add(Me.groupBox2)
         Me.Controls.Add(Me.numericUpDownMax)
         Me.Controls.Add(Me.numericUpDownExpire)
         Me.Controls.Add(Me.numericUpDownMinLength)
         Me.Controls.Add(Me.label3)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.label1)
         Me.Controls.Add(Me.groupBox1)
         Me.Name = "PasswordOptionsView"
         Me.Size = New System.Drawing.Size(488, 365)
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         CType(Me.numericUpDownMinLength, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.numericUpDownExpire, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.numericUpDownMax, System.ComponentModel.ISupportInitialize).EndInit()
         CType(Me.numericUpDownIdleTimeout, System.ComponentModel.ISupportInitialize).EndInit()
         Me.groupBox2.ResumeLayout(False)
         Me.groupBox2.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

#End Region

      Private groupBox1 As System.Windows.Forms.GroupBox
      Private WithEvents checkBoxNumber As System.Windows.Forms.CheckBox
      Private WithEvents checkBoxSymbol As System.Windows.Forms.CheckBox
      Private WithEvents checkBoxUppercase As System.Windows.Forms.CheckBox
      Private WithEvents checkBoxLowercase As System.Windows.Forms.CheckBox
      Private label1 As System.Windows.Forms.Label
      Private label2 As System.Windows.Forms.Label
      Private label3 As System.Windows.Forms.Label
      Private WithEvents numericUpDownMinLength As System.Windows.Forms.NumericUpDown
      Private WithEvents numericUpDownExpire As System.Windows.Forms.NumericUpDown
      Private WithEvents numericUpDownMax As System.Windows.Forms.NumericUpDown
      Private WithEvents numericUpDownIdleTimeout As System.Windows.Forms.NumericUpDown
      Private label4 As System.Windows.Forms.Label
      Private WithEvents checkBoxIdleTimeout As System.Windows.Forms.CheckBox
      Private groupBox2 As System.Windows.Forms.GroupBox
   End Class
End Namespace
