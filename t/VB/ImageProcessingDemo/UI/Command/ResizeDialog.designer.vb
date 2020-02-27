Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class ResizeDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResizeDialog))
            Me._gbOptionsFlags = New System.Windows.Forms.GroupBox
            Me._numWidth = New System.Windows.Forms.NumericUpDown
            Me._lblWidth = New System.Windows.Forms.Label
            Me._rbButtonResample = New System.Windows.Forms.RadioButton
            Me._btnCancel = New System.Windows.Forms.Button
            Me._gbOptions = New System.Windows.Forms.GroupBox
            Me._lblInterpolation = New System.Windows.Forms.Label
            Me._rbButtonFavorBlackOrBicubic = New System.Windows.Forms.RadioButton
            Me._rbButtonBicubic = New System.Windows.Forms.RadioButton
            Me._rbButtonFavorBlackOrResample = New System.Windows.Forms.RadioButton
            Me._numHeight = New System.Windows.Forms.NumericUpDown
            Me._lblHeight = New System.Windows.Forms.Label
            Me._rbButtonNormal = New System.Windows.Forms.RadioButton
            Me._rbButtonFavorBlack = New System.Windows.Forms.RadioButton
            Me._btnOk = New System.Windows.Forms.Button
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbOptions.SuspendLayout()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbOptionsFlags
            '
            Me._gbOptionsFlags.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbOptionsFlags.Location = New System.Drawing.Point(15, 67)
            Me._gbOptionsFlags.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptionsFlags.Name = "_gbOptionsFlags"
            Me._gbOptionsFlags.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptionsFlags.Size = New System.Drawing.Size(209, 7)
            Me._gbOptionsFlags.TabIndex = 4
            Me._gbOptionsFlags.TabStop = False
            '
            '_numWidth
            '
            Me._numWidth.Location = New System.Drawing.Point(116, 15)
            Me._numWidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
            Me._numWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numWidth.Name = "_numWidth"
            Me._numWidth.Size = New System.Drawing.Size(108, 20)
            Me._numWidth.TabIndex = 1
            Me._numWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_lblWidth
            '
            Me._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblWidth.Location = New System.Drawing.Point(15, 15)
            Me._lblWidth.Name = "_lblWidth"
            Me._lblWidth.Size = New System.Drawing.Size(90, 22)
            Me._lblWidth.TabIndex = 0
            Me._lblWidth.Text = "New Width"
            Me._lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            '_rbButtonResample
            '
            Me._rbButtonResample.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbButtonResample.Location = New System.Drawing.Point(15, 172)
            Me._rbButtonResample.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbButtonResample.Name = "_rbButtonResample"
            Me._rbButtonResample.Size = New System.Drawing.Size(116, 23)
            Me._rbButtonResample.TabIndex = 8
            Me._rbButtonResample.Text = "Resample"
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(261, 47)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(68, 22)
            Me._btnCancel.TabIndex = 2
            Me._btnCancel.Text = "Cancel"
            '
            '_gbOptions
            '
            Me._gbOptions.Controls.Add(Me._lblInterpolation)
            Me._gbOptions.Controls.Add(Me._rbButtonFavorBlackOrBicubic)
            Me._gbOptions.Controls.Add(Me._rbButtonBicubic)
            Me._gbOptions.Controls.Add(Me._rbButtonFavorBlackOrResample)
            Me._gbOptions.Controls.Add(Me._numHeight)
            Me._gbOptions.Controls.Add(Me._lblHeight)
            Me._gbOptions.Controls.Add(Me._gbOptionsFlags)
            Me._gbOptions.Controls.Add(Me._numWidth)
            Me._gbOptions.Controls.Add(Me._lblWidth)
            Me._gbOptions.Controls.Add(Me._rbButtonResample)
            Me._gbOptions.Controls.Add(Me._rbButtonNormal)
            Me._gbOptions.Controls.Add(Me._rbButtonFavorBlack)
            Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbOptions.Location = New System.Drawing.Point(9, 10)
            Me._gbOptions.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptions.Name = "_gbOptions"
            Me._gbOptions.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptions.Size = New System.Drawing.Size(237, 292)
            Me._gbOptions.TabIndex = 0
            Me._gbOptions.TabStop = False
            '
            '_lblInterpolation
            '
            Me._lblInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblInterpolation.Location = New System.Drawing.Point(15, 83)
            Me._lblInterpolation.Name = "_lblInterpolation"
            Me._lblInterpolation.Size = New System.Drawing.Size(90, 21)
            Me._lblInterpolation.TabIndex = 5
            Me._lblInterpolation.Text = "Interpolation"
            Me._lblInterpolation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            '_rbButtonFavorBlackOrBicubic
            '
            Me._rbButtonFavorBlackOrBicubic.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbButtonFavorBlackOrBicubic.Location = New System.Drawing.Point(15, 262)
            Me._rbButtonFavorBlackOrBicubic.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbButtonFavorBlackOrBicubic.Name = "_rbButtonFavorBlackOrBicubic"
            Me._rbButtonFavorBlackOrBicubic.Size = New System.Drawing.Size(152, 23)
            Me._rbButtonFavorBlackOrBicubic.TabIndex = 11
            Me._rbButtonFavorBlackOrBicubic.Text = "Favor Black Or Bicubic"
            '
            '_rbButtonBicubic
            '
            Me._rbButtonBicubic.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbButtonBicubic.Location = New System.Drawing.Point(15, 232)
            Me._rbButtonBicubic.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbButtonBicubic.Name = "_rbButtonBicubic"
            Me._rbButtonBicubic.Size = New System.Drawing.Size(116, 23)
            Me._rbButtonBicubic.TabIndex = 10
            Me._rbButtonBicubic.Text = "Bicubic"
            '
            '_rbButtonFavorBlackOrResample
            '
            Me._rbButtonFavorBlackOrResample.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbButtonFavorBlackOrResample.Location = New System.Drawing.Point(15, 202)
            Me._rbButtonFavorBlackOrResample.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbButtonFavorBlackOrResample.Name = "_rbButtonFavorBlackOrResample"
            Me._rbButtonFavorBlackOrResample.Size = New System.Drawing.Size(152, 23)
            Me._rbButtonFavorBlackOrResample.TabIndex = 9
            Me._rbButtonFavorBlackOrResample.Text = "Favor Black Or Resample"
            '
            '_numHeight
            '
            Me._numHeight.Location = New System.Drawing.Point(116, 45)
            Me._numHeight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
            Me._numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numHeight.Name = "_numHeight"
            Me._numHeight.Size = New System.Drawing.Size(108, 20)
            Me._numHeight.TabIndex = 3
            Me._numHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_lblHeight
            '
            Me._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblHeight.Location = New System.Drawing.Point(15, 45)
            Me._lblHeight.Name = "_lblHeight"
            Me._lblHeight.Size = New System.Drawing.Size(90, 22)
            Me._lblHeight.TabIndex = 2
            Me._lblHeight.Text = "New Height"
            Me._lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            '_rbButtonNormal
            '
            Me._rbButtonNormal.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbButtonNormal.Location = New System.Drawing.Point(15, 112)
            Me._rbButtonNormal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbButtonNormal.Name = "_rbButtonNormal"
            Me._rbButtonNormal.Size = New System.Drawing.Size(116, 23)
            Me._rbButtonNormal.TabIndex = 6
            Me._rbButtonNormal.Text = "Normal"
            '
            '_rbButtonFavorBlack
            '
            Me._rbButtonFavorBlack.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbButtonFavorBlack.Location = New System.Drawing.Point(15, 142)
            Me._rbButtonFavorBlack.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbButtonFavorBlack.Name = "_rbButtonFavorBlack"
            Me._rbButtonFavorBlack.Size = New System.Drawing.Size(116, 23)
            Me._rbButtonFavorBlack.TabIndex = 7
            Me._rbButtonFavorBlack.Text = "Favor Black"
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(261, 17)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(68, 22)
            Me._btnOk.TabIndex = 1
            Me._btnOk.Text = "OK"
            '
            'ResizeDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(337, 314)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._gbOptions)
            Me.Controls.Add(Me._btnOk)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ResizeDialog"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Resize"
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbOptions.ResumeLayout(False)
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbOptionsFlags As System.Windows.Forms.GroupBox
	  Private _numWidth As System.Windows.Forms.NumericUpDown
	  Private _lblWidth As System.Windows.Forms.Label
	  Private _rbButtonResample As System.Windows.Forms.RadioButton
	  Private _btnCancel As System.Windows.Forms.Button
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _lblInterpolation As System.Windows.Forms.Label
	  Private _rbButtonFavorBlackOrBicubic As System.Windows.Forms.RadioButton
	  Private _rbButtonBicubic As System.Windows.Forms.RadioButton
	  Private _rbButtonFavorBlackOrResample As System.Windows.Forms.RadioButton
	  Private _numHeight As System.Windows.Forms.NumericUpDown
	  Private _lblHeight As System.Windows.Forms.Label
	  Private _rbButtonNormal As System.Windows.Forms.RadioButton
	  Private _rbButtonFavorBlack As System.Windows.Forms.RadioButton
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace