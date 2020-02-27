
Partial Class ShearDialog
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
      Me._gb = New System.Windows.Forms.GroupBox()
      Me._lblDirection = New System.Windows.Forms.Label()
      Me._numAngle = New System.Windows.Forms.NumericUpDown()
      Me._lblAngle = New System.Windows.Forms.Label()
      Me._rbHorizontal = New System.Windows.Forms.RadioButton()
      Me._rbVertical = New System.Windows.Forms.RadioButton()
      Me._pnlColor = New System.Windows.Forms.Panel()
      Me._pnlRevColor = New System.Windows.Forms.Panel()
      Me._lblFillClr = New System.Windows.Forms.Label()
      Me._btnDlgColor = New System.Windows.Forms.Button()
      Me._pnlLevel = New System.Windows.Forms.Panel()
      Me._numFillColorLevel = New System.Windows.Forms.NumericUpDown()
      Me._lblFillColor = New System.Windows.Forms.Label()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gb.SuspendLayout()
      CType(Me._numAngle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me._pnlColor.SuspendLayout()
      Me._pnlLevel.SuspendLayout()
      CType(Me._numFillColorLevel, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gb
      ' 
      Me._gb.Controls.Add(Me._lblDirection)
      Me._gb.Controls.Add(Me._numAngle)
      Me._gb.Controls.Add(Me._lblAngle)
      Me._gb.Controls.Add(Me._rbHorizontal)
      Me._gb.Controls.Add(Me._rbVertical)
      Me._gb.Controls.Add(Me._pnlColor)
      Me._gb.Controls.Add(Me._pnlLevel)
      Me._gb.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gb.Location = New System.Drawing.Point(11, 11)
      Me._gb.Margin = New System.Windows.Forms.Padding(2)
      Me._gb.Name = "_gb"
      Me._gb.Padding = New System.Windows.Forms.Padding(2)
      Me._gb.Size = New System.Drawing.Size(257, 188)
      Me._gb.TabIndex = 3
      Me._gb.TabStop = False
      ' 
      ' _lblDirection
      ' 
      Me._lblDirection.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblDirection.Location = New System.Drawing.Point(14, 98)
      Me._lblDirection.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblDirection.Name = "_lblDirection"
      Me._lblDirection.Size = New System.Drawing.Size(90, 22)
      Me._lblDirection.TabIndex = 6
      Me._lblDirection.Text = "Direction"
      Me._lblDirection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _numAngle
      ' 
      Me._numAngle.Location = New System.Drawing.Point(116, 23)
      Me._numAngle.Margin = New System.Windows.Forms.Padding(2)
      Me._numAngle.Maximum = New Decimal(New Integer() {45, 0, 0, 0})
      Me._numAngle.Name = "_numAngle"
      Me._numAngle.Size = New System.Drawing.Size(108, 20)
      Me._numAngle.TabIndex = 1
      ' 
      ' _lblAngle
      ' 
      Me._lblAngle.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblAngle.Location = New System.Drawing.Point(14, 23)
      Me._lblAngle.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblAngle.Name = "_lblAngle"
      Me._lblAngle.Size = New System.Drawing.Size(90, 21)
      Me._lblAngle.TabIndex = 0
      Me._lblAngle.Text = "Angle"
      Me._lblAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _rbHorizontal
      ' 
      Me._rbHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbHorizontal.Location = New System.Drawing.Point(14, 128)
      Me._rbHorizontal.Margin = New System.Windows.Forms.Padding(2)
      Me._rbHorizontal.Name = "_rbHorizontal"
      Me._rbHorizontal.Size = New System.Drawing.Size(116, 23)
      Me._rbHorizontal.TabIndex = 7
      Me._rbHorizontal.Text = "Horizontal"
      ' 
      ' _rbVertical
      ' 
      Me._rbVertical.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbVertical.Location = New System.Drawing.Point(14, 158)
      Me._rbVertical.Margin = New System.Windows.Forms.Padding(2)
      Me._rbVertical.Name = "_rbVertical"
      Me._rbVertical.Size = New System.Drawing.Size(116, 23)
      Me._rbVertical.TabIndex = 8
      Me._rbVertical.Text = "Vertical"
      ' 
      ' _pnlColor
      ' 
      Me._pnlColor.Controls.Add(Me._pnlRevColor)
      Me._pnlColor.Controls.Add(Me._lblFillClr)
      Me._pnlColor.Controls.Add(Me._btnDlgColor)
      Me._pnlColor.Location = New System.Drawing.Point(5, 48)
      Me._pnlColor.Name = "_pnlColor"
      Me._pnlColor.Size = New System.Drawing.Size(241, 43)
      Me._pnlColor.TabIndex = 11
      ' 
      ' _pnlRevColor
      ' 
      Me._pnlRevColor.Location = New System.Drawing.Point(151, 12)
      Me._pnlRevColor.Name = "_pnlRevColor"
      Me._pnlRevColor.Size = New System.Drawing.Size(59, 24)
      Me._pnlRevColor.TabIndex = 4
      ' 
      ' _lblFillClr
      ' 
      Me._lblFillClr.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblFillClr.Location = New System.Drawing.Point(9, 14)
      Me._lblFillClr.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblFillClr.Name = "_lblFillClr"
      Me._lblFillClr.Size = New System.Drawing.Size(90, 21)
      Me._lblFillClr.TabIndex = 2
      Me._lblFillClr.Text = "Fill Color "
      Me._lblFillClr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _btnDlgColor
      ' 
      Me._btnDlgColor.Location = New System.Drawing.Point(102, 12)
      Me._btnDlgColor.Name = "_btnDlgColor"
      Me._btnDlgColor.Size = New System.Drawing.Size(35, 24)
      Me._btnDlgColor.TabIndex = 3
      Me._btnDlgColor.Text = "..."
      Me._btnDlgColor.UseVisualStyleBackColor = True
      ' 
      ' _pnlLevel
      ' 
      Me._pnlLevel.Controls.Add(Me._numFillColorLevel)
      Me._pnlLevel.Controls.Add(Me._lblFillColor)
      Me._pnlLevel.Location = New System.Drawing.Point(11, 47)
      Me._pnlLevel.Name = "_pnlLevel"
      Me._pnlLevel.Size = New System.Drawing.Size(232, 47)
      Me._pnlLevel.TabIndex = 10
      ' 
      ' _numFillColorLevel
      ' 
      Me._numFillColorLevel.Location = New System.Drawing.Point(105, 15)
      Me._numFillColorLevel.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numFillColorLevel.Name = "_numFillColorLevel"
      Me._numFillColorLevel.Size = New System.Drawing.Size(108, 20)
      Me._numFillColorLevel.TabIndex = 9
      ' 
      ' _lblFillColor
      ' 
      Me._lblFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblFillColor.Location = New System.Drawing.Point(0, 13)
      Me._lblFillColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblFillColor.Name = "_lblFillColor"
      Me._lblFillColor.Size = New System.Drawing.Size(90, 21)
      Me._lblFillColor.TabIndex = 2
      Me._lblFillColor.Text = "Fill Color Level"
      Me._lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(272, 52)
      Me._btnCancel.Margin = New System.Windows.Forms.Padding(2)
      Me._btnCancel.Name = "_btnCancel"
      Me._btnCancel.Size = New System.Drawing.Size(68, 22)
      Me._btnCancel.TabIndex = 5
      Me._btnCancel.Text = "Cancel"
      ' 
      ' _btnOk
      ' 
      Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnOk.Location = New System.Drawing.Point(272, 22)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 4
      Me._btnOk.Text = "OK"
      ' 
      ' ShearDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(351, 213)
      Me.Controls.Add(Me._gb)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ShearDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "Shear"
      Me._gb.ResumeLayout(False)
      CType(Me._numAngle, System.ComponentModel.ISupportInitialize).EndInit()
      Me._pnlColor.ResumeLayout(False)
      Me._pnlLevel.ResumeLayout(False)
      CType(Me._numFillColorLevel, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gb As System.Windows.Forms.GroupBox
   Private _lblDirection As System.Windows.Forms.Label
   Private _lblFillColor As System.Windows.Forms.Label
   Private _numAngle As System.Windows.Forms.NumericUpDown
   Private _lblAngle As System.Windows.Forms.Label
   Private _rbHorizontal As System.Windows.Forms.RadioButton
   Private _rbVertical As System.Windows.Forms.RadioButton
   Private _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _numFillColorLevel As System.Windows.Forms.NumericUpDown
   Private _pnlLevel As System.Windows.Forms.Panel
   Private _pnlColor As System.Windows.Forms.Panel
   Private WithEvents _btnDlgColor As System.Windows.Forms.Button
   Private _lblFillClr As System.Windows.Forms.Label
   Private _pnlRevColor As System.Windows.Forms.Panel
End Class