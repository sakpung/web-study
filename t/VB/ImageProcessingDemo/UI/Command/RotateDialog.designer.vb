Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class RotateDialog
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

	  #Region "Windows Form Designer generated code"

	  ''' <summary>
	  ''' Required method for Designer support - do not modify
	  ''' the contents of this method with the code editor.
	  ''' </summary>
	  Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RotateDialog))
            Me._gbOptions = New System.Windows.Forms.GroupBox
            Me._lblInterpolation = New System.Windows.Forms.Label
            Me._gbOptionsInterpolation = New System.Windows.Forms.GroupBox
            Me._cbResize = New System.Windows.Forms.CheckBox
            Me._btnFillColor = New System.Windows.Forms.Button
            Me._pnlFillColor = New System.Windows.Forms.Panel
            Me._lblFillColor = New System.Windows.Forms.Label
            Me._numAngle = New System.Windows.Forms.NumericUpDown
            Me._lblAngle = New System.Windows.Forms.Label
            Me._rbButtonBicubic = New System.Windows.Forms.RadioButton
            Me._rbButtonNormal = New System.Windows.Forms.RadioButton
            Me._rbButtonResample = New System.Windows.Forms.RadioButton
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbOptions.SuspendLayout()
            CType(Me._numAngle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbOptions
            '
            Me._gbOptions.Controls.Add(Me._lblInterpolation)
            Me._gbOptions.Controls.Add(Me._gbOptionsInterpolation)
            Me._gbOptions.Controls.Add(Me._cbResize)
            Me._gbOptions.Controls.Add(Me._btnFillColor)
            Me._gbOptions.Controls.Add(Me._pnlFillColor)
            Me._gbOptions.Controls.Add(Me._lblFillColor)
            Me._gbOptions.Controls.Add(Me._numAngle)
            Me._gbOptions.Controls.Add(Me._lblAngle)
            Me._gbOptions.Controls.Add(Me._rbButtonBicubic)
            Me._gbOptions.Controls.Add(Me._rbButtonNormal)
            Me._gbOptions.Controls.Add(Me._rbButtonResample)
            Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbOptions.Location = New System.Drawing.Point(9, 11)
            Me._gbOptions.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptions.Name = "_gbOptions"
            Me._gbOptions.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptions.Size = New System.Drawing.Size(237, 271)
            Me._gbOptions.TabIndex = 0
            Me._gbOptions.TabStop = False
            '
            '_lblInterpolation
            '
            Me._lblInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblInterpolation.Location = New System.Drawing.Point(15, 150)
            Me._lblInterpolation.Name = "_lblInterpolation"
            Me._lblInterpolation.Size = New System.Drawing.Size(90, 21)
            Me._lblInterpolation.TabIndex = 7
            Me._lblInterpolation.Text = "Interpolation"
            Me._lblInterpolation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            '_gbOptionsInterpolation
            '
            Me._gbOptionsInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbOptionsInterpolation.Location = New System.Drawing.Point(15, 128)
            Me._gbOptionsInterpolation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptionsInterpolation.Name = "_gbOptionsInterpolation"
            Me._gbOptionsInterpolation.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptionsInterpolation.Size = New System.Drawing.Size(209, 7)
            Me._gbOptionsInterpolation.TabIndex = 6
            Me._gbOptionsInterpolation.TabStop = False
            '
            '_cbResize
            '
            Me._cbResize.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cbResize.Location = New System.Drawing.Point(15, 98)
            Me._cbResize.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cbResize.Name = "_cbResize"
            Me._cbResize.Size = New System.Drawing.Size(93, 23)
            Me._cbResize.TabIndex = 5
            Me._cbResize.Text = "Resize"
            '
            '_btnFillColor
            '
            Me._btnFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnFillColor.Location = New System.Drawing.Point(201, 53)
            Me._btnFillColor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnFillColor.Name = "_btnFillColor"
            Me._btnFillColor.Size = New System.Drawing.Size(21, 21)
            Me._btnFillColor.TabIndex = 4
            Me._btnFillColor.Text = "..."
            '
            '_pnlFillColor
            '
            Me._pnlFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._pnlFillColor.Location = New System.Drawing.Point(116, 53)
            Me._pnlFillColor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._pnlFillColor.Name = "_pnlFillColor"
            Me._pnlFillColor.Size = New System.Drawing.Size(87, 22)
            Me._pnlFillColor.TabIndex = 3
            '
            '_lblFillColor
            '
            Me._lblFillColor.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblFillColor.Location = New System.Drawing.Point(15, 53)
            Me._lblFillColor.Name = "_lblFillColor"
            Me._lblFillColor.Size = New System.Drawing.Size(90, 21)
            Me._lblFillColor.TabIndex = 2
            Me._lblFillColor.Text = "Fill Color"
            Me._lblFillColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            '_numAngle
            '
            Me._numAngle.Location = New System.Drawing.Point(116, 23)
            Me._numAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numAngle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
            Me._numAngle.Minimum = New Decimal(New Integer() {360, 0, 0, -2147483648})
            Me._numAngle.Name = "_numAngle"
            Me._numAngle.Size = New System.Drawing.Size(108, 20)
            Me._numAngle.TabIndex = 1
            '
            '_lblAngle
            '
            Me._lblAngle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblAngle.Location = New System.Drawing.Point(15, 23)
            Me._lblAngle.Name = "_lblAngle"
            Me._lblAngle.Size = New System.Drawing.Size(90, 21)
            Me._lblAngle.TabIndex = 0
            Me._lblAngle.Text = "Angle"
            Me._lblAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            '_rbButtonBicubic
            '
            Me._rbButtonBicubic.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbButtonBicubic.Location = New System.Drawing.Point(15, 240)
            Me._rbButtonBicubic.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbButtonBicubic.Name = "_rbButtonBicubic"
            Me._rbButtonBicubic.Size = New System.Drawing.Size(116, 23)
            Me._rbButtonBicubic.TabIndex = 10
            Me._rbButtonBicubic.Text = "BiCubic"
            '
            '_rbButtonNormal
            '
            Me._rbButtonNormal.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbButtonNormal.Location = New System.Drawing.Point(15, 180)
            Me._rbButtonNormal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbButtonNormal.Name = "_rbButtonNormal"
            Me._rbButtonNormal.Size = New System.Drawing.Size(116, 22)
            Me._rbButtonNormal.TabIndex = 8
            Me._rbButtonNormal.Text = "Normal"
            '
            '_rbButtonResample
            '
            Me._rbButtonResample.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbButtonResample.Location = New System.Drawing.Point(15, 210)
            Me._rbButtonResample.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbButtonResample.Name = "_rbButtonResample"
            Me._rbButtonResample.Size = New System.Drawing.Size(116, 23)
            Me._rbButtonResample.TabIndex = 9
            Me._rbButtonResample.Text = "Resample (Bilinear)"
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(261, 49)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(68, 22)
            Me._btnCancel.TabIndex = 2
            Me._btnCancel.Text = "Cancel"
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(261, 19)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(68, 22)
            Me._btnOk.TabIndex = 1
            Me._btnOk.Text = "OK"
            '
            'RotateDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(337, 294)
            Me.Controls.Add(Me._gbOptions)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "RotateDialog"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Rotate"
            Me._gbOptions.ResumeLayout(False)
            CType(Me._numAngle, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _lblInterpolation As System.Windows.Forms.Label
	  Private _gbOptionsInterpolation As System.Windows.Forms.GroupBox
	  Private _cbResize As System.Windows.Forms.CheckBox
	  Private WithEvents _btnFillColor As System.Windows.Forms.Button
	  Private WithEvents _pnlFillColor As System.Windows.Forms.Panel
	  Private _lblFillColor As System.Windows.Forms.Label
	  Private WithEvents _numAngle As System.Windows.Forms.NumericUpDown
	  Private _lblAngle As System.Windows.Forms.Label
	  Private _rbButtonBicubic As System.Windows.Forms.RadioButton
	  Private _rbButtonNormal As System.Windows.Forms.RadioButton
	  Private _rbButtonResample As System.Windows.Forms.RadioButton
	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button

   End Class
End Namespace