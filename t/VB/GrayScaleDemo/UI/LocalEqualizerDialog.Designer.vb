
Partial Class LocalEqualizerDialog
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
      Me._gbOptions = New System.Windows.Forms.GroupBox()
      Me._numSmooth = New System.Windows.Forms.NumericUpDown()
      Me._numHeightExt = New System.Windows.Forms.NumericUpDown()
      Me._numWidthExt = New System.Windows.Forms.NumericUpDown()
      Me._numHeight = New System.Windows.Forms.NumericUpDown()
      Me._numWidth = New System.Windows.Forms.NumericUpDown()
      Me.label5 = New System.Windows.Forms.Label()
      Me.label4 = New System.Windows.Forms.Label()
      Me.label3 = New System.Windows.Forms.Label()
      Me.label2 = New System.Windows.Forms.Label()
      Me.label1 = New System.Windows.Forms.Label()
      Me._cbEqualizeType = New System.Windows.Forms.ComboBox()
      Me._lblColorSpace = New System.Windows.Forms.Label()
      Me._gbOptions.SuspendLayout()
      CType(Me._numSmooth, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numHeightExt, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numWidthExt, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(307, 68)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 8
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(307, 38)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 7
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me._numSmooth)
      Me._gbOptions.Controls.Add(Me._numHeightExt)
      Me._gbOptions.Controls.Add(Me._numWidthExt)
      Me._gbOptions.Controls.Add(Me._numHeight)
      Me._gbOptions.Controls.Add(Me._numWidth)
      Me._gbOptions.Controls.Add(Me.label5)
      Me._gbOptions.Controls.Add(Me.label4)
      Me._gbOptions.Controls.Add(Me.label3)
      Me._gbOptions.Controls.Add(Me.label2)
      Me._gbOptions.Controls.Add(Me.label1)
      Me._gbOptions.Controls.Add(Me._cbEqualizeType)
      Me._gbOptions.Controls.Add(Me._lblColorSpace)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbOptions.Location = New System.Drawing.Point(5, -1)
      Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Size = New System.Drawing.Size(298, 190)
      Me._gbOptions.TabIndex = 6
      Me._gbOptions.TabStop = False
      ' 
      ' _numSmooth
      ' 
      Me._numSmooth.Location = New System.Drawing.Point(131, 128)
      Me._numSmooth.Margin = New System.Windows.Forms.Padding(2)
      Me._numSmooth.Maximum = New Decimal(New Integer() {7, 0, 0, 0})
      Me._numSmooth.Name = "_numSmooth"
      Me._numSmooth.Size = New System.Drawing.Size(116, 20)
      Me._numSmooth.TabIndex = 11
      ' 
      ' _numHeightExt
      ' 
      Me._numHeightExt.Location = New System.Drawing.Point(131, 97)
      Me._numHeightExt.Margin = New System.Windows.Forms.Padding(2)
      Me._numHeightExt.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numHeightExt.Name = "_numHeightExt"
      Me._numHeightExt.Size = New System.Drawing.Size(116, 20)
      Me._numHeightExt.TabIndex = 10
      ' 
      ' _numWidthExt
      ' 
      Me._numWidthExt.Location = New System.Drawing.Point(131, 71)
      Me._numWidthExt.Margin = New System.Windows.Forms.Padding(2)
      Me._numWidthExt.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numWidthExt.Name = "_numWidthExt"
      Me._numWidthExt.Size = New System.Drawing.Size(116, 20)
      Me._numWidthExt.TabIndex = 9
      ' 
      ' _numHeight
      ' 
      Me._numHeight.Location = New System.Drawing.Point(131, 43)
      Me._numHeight.Margin = New System.Windows.Forms.Padding(2)
      Me._numHeight.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numHeight.Name = "_numHeight"
      Me._numHeight.Size = New System.Drawing.Size(116, 20)
      Me._numHeight.TabIndex = 8
      ' 
      ' _numWidth
      ' 
      Me._numWidth.Location = New System.Drawing.Point(131, 15)
      Me._numWidth.Margin = New System.Windows.Forms.Padding(2)
      Me._numWidth.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numWidth.Name = "_numWidth"
      Me._numWidth.Size = New System.Drawing.Size(116, 20)
      Me._numWidth.TabIndex = 7
      ' 
      ' label5
      ' 
      Me.label5.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.label5.Location = New System.Drawing.Point(11, 128)
      Me.label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me.label5.Name = "label5"
      Me.label5.Size = New System.Drawing.Size(65, 21)
      Me.label5.TabIndex = 6
      Me.label5.Text = "Smooth "
      Me.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' label4
      ' 
      Me.label4.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.label4.Location = New System.Drawing.Point(11, 97)
      Me.label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(81, 21)
      Me.label4.TabIndex = 5
      Me.label4.Text = "HeightExtension "
      Me.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' label3
      ' 
      Me.label3.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.label3.Location = New System.Drawing.Point(11, 71)
      Me.label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(81, 21)
      Me.label3.TabIndex = 4
      Me.label3.Text = "WidthExtension"
      Me.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' label2
      ' 
      Me.label2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.label2.Location = New System.Drawing.Point(11, 40)
      Me.label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(65, 21)
      Me.label2.TabIndex = 3
      Me.label2.Text = "Height"
      Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' label1
      ' 
      Me.label1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.label1.Location = New System.Drawing.Point(11, 13)
      Me.label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(65, 21)
      Me.label1.TabIndex = 2
      Me.label1.Text = "Width"
      Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _cbEqualizeType
      ' 
      Me._cbEqualizeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cbEqualizeType.FormattingEnabled = True
      Me._cbEqualizeType.Location = New System.Drawing.Point(131, 161)
      Me._cbEqualizeType.Margin = New System.Windows.Forms.Padding(2)
      Me._cbEqualizeType.Name = "_cbEqualizeType"
      Me._cbEqualizeType.Size = New System.Drawing.Size(152, 21)
      Me._cbEqualizeType.TabIndex = 1
      ' 
      ' _lblColorSpace
      ' 
      Me._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblColorSpace.Location = New System.Drawing.Point(11, 161)
      Me._lblColorSpace.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblColorSpace.Name = "_lblColorSpace"
      Me._lblColorSpace.Size = New System.Drawing.Size(81, 21)
      Me._lblColorSpace.TabIndex = 0
      Me._lblColorSpace.Text = "Equalize Type"
      Me._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' LocalEqualizerDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(386, 198)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.Controls.Add(Me._gbOptions)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "LocalEqualizerDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Local Equalizer"
      Me._gbOptions.ResumeLayout(False)
      CType(Me._numSmooth, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numHeightExt, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numWidthExt, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _gbOptions As System.Windows.Forms.GroupBox
   Private _cbEqualizeType As System.Windows.Forms.ComboBox
   Private _lblColorSpace As System.Windows.Forms.Label
   Private label5 As System.Windows.Forms.Label
   Private label4 As System.Windows.Forms.Label
   Private label3 As System.Windows.Forms.Label
   Private label2 As System.Windows.Forms.Label
   Private label1 As System.Windows.Forms.Label
   Private _numSmooth As System.Windows.Forms.NumericUpDown
   Private _numHeightExt As System.Windows.Forms.NumericUpDown
   Private _numWidthExt As System.Windows.Forms.NumericUpDown
   Private _numHeight As System.Windows.Forms.NumericUpDown
   Private _numWidth As System.Windows.Forms.NumericUpDown
End Class