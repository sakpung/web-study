
Partial Class RotateDialog
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
      Me._pnlColor = New System.Windows.Forms.Panel()
      Me._pnlRevColor = New System.Windows.Forms.Panel()
      Me._btnDlgColor = New System.Windows.Forms.Button()
      Me.label1 = New System.Windows.Forms.Label()
      Me._pnlLevel = New System.Windows.Forms.Panel()
      Me._numFillColorLevel = New System.Windows.Forms.NumericUpDown()
      Me._lblFillColor = New System.Windows.Forms.Label()
      Me._lblInterpolation = New System.Windows.Forms.Label()
      Me._gbOptionsInterpolation = New System.Windows.Forms.GroupBox()
      Me._cbResize = New System.Windows.Forms.CheckBox()
      Me._numAngle = New System.Windows.Forms.NumericUpDown()
      Me._lblAngle = New System.Windows.Forms.Label()
      Me._rbButtonBicubic = New System.Windows.Forms.RadioButton()
      Me._rbButtonNormal = New System.Windows.Forms.RadioButton()
      Me._rbButtonResample = New System.Windows.Forms.RadioButton()
      Me._btnCancel = New System.Windows.Forms.Button()
      Me._btnOk = New System.Windows.Forms.Button()
      Me._gbOptions.SuspendLayout()
      Me._pnlColor.SuspendLayout()
      Me._pnlLevel.SuspendLayout()
      CType(Me._numFillColorLevel, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me._numAngle, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      ' 
      ' _gbOptions
      ' 
      Me._gbOptions.Controls.Add(Me._pnlLevel)
      Me._gbOptions.Controls.Add(Me._lblInterpolation)
      Me._gbOptions.Controls.Add(Me._gbOptionsInterpolation)
      Me._gbOptions.Controls.Add(Me._cbResize)
      Me._gbOptions.Controls.Add(Me._numAngle)
      Me._gbOptions.Controls.Add(Me._lblAngle)
      Me._gbOptions.Controls.Add(Me._rbButtonBicubic)
      Me._gbOptions.Controls.Add(Me._rbButtonNormal)
      Me._gbOptions.Controls.Add(Me._rbButtonResample)
      Me._gbOptions.Controls.Add(Me._pnlColor)
      Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbOptions.Location = New System.Drawing.Point(7, 7)
      Me._gbOptions.Margin = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Name = "_gbOptions"
      Me._gbOptions.Padding = New System.Windows.Forms.Padding(2)
      Me._gbOptions.Size = New System.Drawing.Size(252, 271)
      Me._gbOptions.TabIndex = 3
      Me._gbOptions.TabStop = False
      ' 
      ' _pnlColor
      ' 
      Me._pnlColor.Controls.Add(Me._pnlRevColor)
      Me._pnlColor.Controls.Add(Me._btnDlgColor)
      Me._pnlColor.Controls.Add(Me.label1)
      Me._pnlColor.Location = New System.Drawing.Point(5, 49)
      Me._pnlColor.Name = "_pnlColor"
      Me._pnlColor.Size = New System.Drawing.Size(231, 44)
      Me._pnlColor.TabIndex = 13
      ' 
      ' _pnlRevColor
      ' 
      Me._pnlRevColor.Location = New System.Drawing.Point(156, 10)
      Me._pnlRevColor.Name = "_pnlRevColor"
      Me._pnlRevColor.Size = New System.Drawing.Size(63, 26)
      Me._pnlRevColor.TabIndex = 4
      ' 
      ' _btnDlgColor
      ' 
      Me._btnDlgColor.Location = New System.Drawing.Point(111, 10)
      Me._btnDlgColor.Name = "_btnDlgColor"
      Me._btnDlgColor.Size = New System.Drawing.Size(33, 26)
      Me._btnDlgColor.TabIndex = 3
      Me._btnDlgColor.Text = "..."
      Me._btnDlgColor.UseVisualStyleBackColor = True
      ' 
      ' label1
      ' 
      Me.label1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.label1.Location = New System.Drawing.Point(10, 12)
      Me.label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me.label1.Name = "label1"
      Me.label1.Size = New System.Drawing.Size(90, 21)
      Me.label1.TabIndex = 2
      Me.label1.Text = "Fill Color "
      Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _pnlLevel
      ' 
      Me._pnlLevel.Controls.Add(Me._numFillColorLevel)
      Me._pnlLevel.Controls.Add(Me._lblFillColor)
      Me._pnlLevel.Location = New System.Drawing.Point(5, 47)
      Me._pnlLevel.Name = "_pnlLevel"
      Me._pnlLevel.Size = New System.Drawing.Size(231, 44)
      Me._pnlLevel.TabIndex = 12
      ' 
      ' _numFillColorLevel
      ' 
      Me._numFillColorLevel.Location = New System.Drawing.Point(111, 12)
      Me._numFillColorLevel.Margin = New System.Windows.Forms.Padding(2)
      Me._numFillColorLevel.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
      Me._numFillColorLevel.Name = "_numFillColorLevel"
      Me._numFillColorLevel.Size = New System.Drawing.Size(108, 20)
      Me._numFillColorLevel.TabIndex = 11
      ' 
      ' _lblFillColor
      ' 
      Me._lblFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblFillColor.Location = New System.Drawing.Point(6, 11)
      Me._lblFillColor.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblFillColor.Name = "_lblFillColor"
      Me._lblFillColor.Size = New System.Drawing.Size(90, 21)
      Me._lblFillColor.TabIndex = 2
      Me._lblFillColor.Text = "Fill Color Level"
      Me._lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _lblInterpolation
      ' 
      Me._lblInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._lblInterpolation.Location = New System.Drawing.Point(14, 150)
      Me._lblInterpolation.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
      Me._lblInterpolation.Name = "_lblInterpolation"
      Me._lblInterpolation.Size = New System.Drawing.Size(90, 21)
      Me._lblInterpolation.TabIndex = 7
      Me._lblInterpolation.Text = "Interpolation"
      Me._lblInterpolation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      ' 
      ' _gbOptionsInterpolation
      ' 
      Me._gbOptionsInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._gbOptionsInterpolation.Location = New System.Drawing.Point(14, 128)
      Me._gbOptionsInterpolation.Margin = New System.Windows.Forms.Padding(2)
      Me._gbOptionsInterpolation.Name = "_gbOptionsInterpolation"
      Me._gbOptionsInterpolation.Padding = New System.Windows.Forms.Padding(2)
      Me._gbOptionsInterpolation.Size = New System.Drawing.Size(222, 7)
      Me._gbOptionsInterpolation.TabIndex = 6
      Me._gbOptionsInterpolation.TabStop = False
      ' 
      ' _cbResize
      ' 
      Me._cbResize.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._cbResize.Location = New System.Drawing.Point(14, 98)
      Me._cbResize.Margin = New System.Windows.Forms.Padding(2)
      Me._cbResize.Name = "_cbResize"
      Me._cbResize.Size = New System.Drawing.Size(94, 23)
      Me._cbResize.TabIndex = 5
      Me._cbResize.Text = "Resize"
      ' 
      ' _numAngle
      ' 
      Me._numAngle.Location = New System.Drawing.Point(116, 23)
      Me._numAngle.Margin = New System.Windows.Forms.Padding(2)
      Me._numAngle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
      Me._numAngle.Minimum = New Decimal(New Integer() {360, 0, 0, -2147483648})
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
      ' _rbButtonBicubic
      ' 
      Me._rbButtonBicubic.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbButtonBicubic.Location = New System.Drawing.Point(14, 240)
      Me._rbButtonBicubic.Margin = New System.Windows.Forms.Padding(2)
      Me._rbButtonBicubic.Name = "_rbButtonBicubic"
      Me._rbButtonBicubic.Size = New System.Drawing.Size(116, 23)
      Me._rbButtonBicubic.TabIndex = 10
      Me._rbButtonBicubic.Text = "BiCubic"
      ' 
      ' _rbButtonNormal
      ' 
      Me._rbButtonNormal.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbButtonNormal.Location = New System.Drawing.Point(14, 180)
      Me._rbButtonNormal.Margin = New System.Windows.Forms.Padding(2)
      Me._rbButtonNormal.Name = "_rbButtonNormal"
      Me._rbButtonNormal.Size = New System.Drawing.Size(116, 22)
      Me._rbButtonNormal.TabIndex = 8
      Me._rbButtonNormal.Text = "Normal"
      ' 
      ' _rbButtonResample
      ' 
      Me._rbButtonResample.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._rbButtonResample.Location = New System.Drawing.Point(14, 210)
      Me._rbButtonResample.Margin = New System.Windows.Forms.Padding(2)
      Me._rbButtonResample.Name = "_rbButtonResample"
      Me._rbButtonResample.Size = New System.Drawing.Size(116, 23)
      Me._rbButtonResample.TabIndex = 9
      Me._rbButtonResample.Text = "Resample (Bilinear)"
      ' 
      ' _btnCancel
      ' 
      Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me._btnCancel.Location = New System.Drawing.Point(281, 41)
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
      Me._btnOk.Location = New System.Drawing.Point(281, 11)
      Me._btnOk.Margin = New System.Windows.Forms.Padding(2)
      Me._btnOk.Name = "_btnOk"
      Me._btnOk.Size = New System.Drawing.Size(68, 22)
      Me._btnOk.TabIndex = 4
      Me._btnOk.Text = "OK"
      ' 
      ' RotateDialog
      ' 
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(359, 291)
      Me.Controls.Add(Me._gbOptions)
      Me.Controls.Add(Me._btnCancel)
      Me.Controls.Add(Me._btnOk)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "RotateDialog"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      Me.Text = "RotateDialog"
      Me._gbOptions.ResumeLayout(False)
      Me._pnlColor.ResumeLayout(False)
      Me._pnlLevel.ResumeLayout(False)
      CType(Me._numFillColorLevel, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me._numAngle, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Private _gbOptions As System.Windows.Forms.GroupBox
   Private _lblInterpolation As System.Windows.Forms.Label
   Private _gbOptionsInterpolation As System.Windows.Forms.GroupBox
   Private _cbResize As System.Windows.Forms.CheckBox
   Private _numAngle As System.Windows.Forms.NumericUpDown
   Private _lblAngle As System.Windows.Forms.Label
   Private _rbButtonBicubic As System.Windows.Forms.RadioButton
   Private _rbButtonNormal As System.Windows.Forms.RadioButton
   Private _rbButtonResample As System.Windows.Forms.RadioButton
   Private WithEvents _btnCancel As System.Windows.Forms.Button
   Private WithEvents _btnOk As System.Windows.Forms.Button
   Private _numFillColorLevel As System.Windows.Forms.NumericUpDown
   Private _lblFillColor As System.Windows.Forms.Label
   Private _pnlColor As System.Windows.Forms.Panel
   Private WithEvents _btnDlgColor As System.Windows.Forms.Button
   Private label1 As System.Windows.Forms.Label
   Private _pnlLevel As System.Windows.Forms.Panel
   Private _pnlRevColor As System.Windows.Forms.Panel
End Class