
Partial Class AdaptiveContrastDialog
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
      Me._cmbAdaptiveType = New System.Windows.Forms.ComboBox()
      Me._lblColorSpace = New System.Windows.Forms.Label()
      Me._lblEnd = New System.Windows.Forms.Label()
      Me._lblStart = New System.Windows.Forms.Label()
      Me._numDimension = New System.Windows.Forms.NumericUpDown()
      Me._numAmount = New System.Windows.Forms.NumericUpDown()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbOptions.SuspendLayout()
      CType(Me._numDimension, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numAmount, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me._cmbAdaptiveType)
      Me._gbOptions.Controls.Add(Me._lblColorSpace)
      Me._gbOptions.Controls.Add(Me._lblEnd)
      Me._gbOptions.Controls.Add(Me._lblStart)
      Me._gbOptions.Controls.Add(Me._numDimension)
      Me._gbOptions.Controls.Add(Me._numAmount)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbOptions.Location = New System.Drawing.Point(4, -3)
      Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Size = New System.Drawing.Size(252, 121)
      Me._gbOptions.TabIndex = 9
      Me._gbOptions.TabStop = False
      ' 
      ' _cmbAdaptiveType
      ' 
      Me._cmbAdaptiveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me._cmbAdaptiveType.FormattingEnabled = True
      Me._cmbAdaptiveType.Items.AddRange(New Object() {"Exponential", "Linear"})
      Me._cmbAdaptiveType.Location = New System.Drawing.Point(94, 87)
      Me._cmbAdaptiveType.Margin = New System.Windows.Forms.Padding(2)
      Me._cmbAdaptiveType.Name = "_cmbAdaptiveType"
      Me._cmbAdaptiveType.Size = New System.Drawing.Size(152, 21)
      Me._cmbAdaptiveType.TabIndex = 5
      ' 
      ' _lblColorSpace
      ' 
      Me._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblColorSpace.Location = New System.Drawing.Point(9, 81)
      Me._lblColorSpace.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblColorSpace.Name = "_lblColorSpace"
      Me._lblColorSpace.Size = New System.Drawing.Size(81, 38)
      Me._lblColorSpace.TabIndex = 4
      Me._lblColorSpace.Text = "Adaptive Contrast Type"
      Me._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _lblEnd
      ' 
      Me._lblEnd.AutoSize = True
      Me._lblEnd.Location = New System.Drawing.Point(9, 52)
      Me._lblEnd.Name = "_lblEnd"
      Me._lblEnd.Size = New System.Drawing.Size(56, 13)
      Me._lblEnd.TabIndex = 3
      Me._lblEnd.Text = "Dimension"
      ' 
      ' _lblStart
      ' 
      Me._lblStart.AutoSize = True
      Me._lblStart.Location = New System.Drawing.Point(9, 19)
      Me._lblStart.Name = "_lblStart"
      Me._lblStart.Size = New System.Drawing.Size(43, 13)
      Me._lblStart.TabIndex = 2
      Me._lblStart.Text = "Amount"
      ' 
      ' _numDimension
      ' 
      Me._numDimension.Location = New System.Drawing.Point(94, 50)
      Me._numDimension.Margin = New System.Windows.Forms.Padding(2)
      Me._numDimension.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
      Me._numDimension.Name = "_numDimension"
      Me._numDimension.Size = New System.Drawing.Size(116, 20)
      Me._numDimension.TabIndex = 1
      Me._numDimension.Value = New Decimal(New Integer() {2, 0, 0, 0})
      ' 
      ' _numAmount
      ' 
      Me._numAmount.Location = New System.Drawing.Point(94, 14)
      Me._numAmount.Margin = New System.Windows.Forms.Padding(2)
      Me._numAmount.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
      Me._numAmount.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
      Me._numAmount.Name = "_numAmount"
      Me._numAmount.Size = New System.Drawing.Size(116, 20)
      Me._numAmount.TabIndex = 0
      Me._numAmount.Value = New Decimal(New Integer() {100, 0, 0, 0})
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(260, 56)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 11
      Me._btnCancel.Text = "Cancel"
      Me._btnCancel.UseVisualStyleBackColor = True
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(260, 26)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 10
      Me._btnOk.Text = "OK"
      Me._btnOk.UseVisualStyleBackColor = True
      ' 
      ' AdaptiveContrastDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(332, 125)
      Me.Controls.Add(Me._gbOptions)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AdaptiveContrastDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Adaptive Contrast"
      Me._gbOptions.ResumeLayout(False)
      Me._gbOptions.PerformLayout()
      CType(Me._numDimension, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numAmount, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbOptions As System.Windows.Forms.GroupBox
   Private _lblEnd As System.Windows.Forms.Label
   Private _lblStart As System.Windows.Forms.Label
   Private _numDimension As System.Windows.Forms.NumericUpDown
   Private _numAmount As System.Windows.Forms.NumericUpDown
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _cmbAdaptiveType As System.Windows.Forms.ComboBox
   Private _lblColorSpace As System.Windows.Forms.Label
End Class