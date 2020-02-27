Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class ResizeInterpolateDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResizeInterpolateDialog))
            Me._lblWidth = New System.Windows.Forms.Label
            Me._lblHeight = New System.Windows.Forms.Label
            Me._gbOptions = New System.Windows.Forms.GroupBox
            Me._cmbInterpolation = New System.Windows.Forms.ComboBox
            Me._lblInterpolation = New System.Windows.Forms.Label
            Me._gbOptionsFlags = New System.Windows.Forms.GroupBox
            Me._numHeight = New System.Windows.Forms.NumericUpDown
            Me._numWidth = New System.Windows.Forms.NumericUpDown
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbOptions.SuspendLayout()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_lblWidth
            '
            Me._lblWidth.AutoSize = True
            Me._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblWidth.Location = New System.Drawing.Point(5, 16)
            Me._lblWidth.Name = "_lblWidth"
            Me._lblWidth.Size = New System.Drawing.Size(60, 13)
            Me._lblWidth.TabIndex = 0
            Me._lblWidth.Text = "New Width"
            '
            '_lblHeight
            '
            Me._lblHeight.AutoSize = True
            Me._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblHeight.Location = New System.Drawing.Point(5, 41)
            Me._lblHeight.Name = "_lblHeight"
            Me._lblHeight.Size = New System.Drawing.Size(63, 13)
            Me._lblHeight.TabIndex = 1
            Me._lblHeight.Text = "New Height"
            '
            '_gbOptions
            '
            Me._gbOptions.Controls.Add(Me._cmbInterpolation)
            Me._gbOptions.Controls.Add(Me._lblInterpolation)
            Me._gbOptions.Controls.Add(Me._gbOptionsFlags)
            Me._gbOptions.Controls.Add(Me._numHeight)
            Me._gbOptions.Controls.Add(Me._numWidth)
            Me._gbOptions.Controls.Add(Me._lblHeight)
            Me._gbOptions.Controls.Add(Me._lblWidth)
            Me._gbOptions.Location = New System.Drawing.Point(8, 1)
            Me._gbOptions.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptions.Name = "_gbOptions"
            Me._gbOptions.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptions.Size = New System.Drawing.Size(226, 124)
            Me._gbOptions.TabIndex = 4
            Me._gbOptions.TabStop = False
            '
            '_cmbInterpolation
            '
            Me._cmbInterpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbInterpolation.FormattingEnabled = True
            Me._cmbInterpolation.Location = New System.Drawing.Point(72, 84)
            Me._cmbInterpolation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbInterpolation.Name = "_cmbInterpolation"
            Me._cmbInterpolation.Size = New System.Drawing.Size(150, 21)
            Me._cmbInterpolation.TabIndex = 7
            '
            '_lblInterpolation
            '
            Me._lblInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblInterpolation.Location = New System.Drawing.Point(5, 85)
            Me._lblInterpolation.Name = "_lblInterpolation"
            Me._lblInterpolation.Size = New System.Drawing.Size(90, 21)
            Me._lblInterpolation.TabIndex = 6
            Me._lblInterpolation.Text = "Interpolation"
            Me._lblInterpolation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            '_gbOptionsFlags
            '
            Me._gbOptionsFlags.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbOptionsFlags.Location = New System.Drawing.Point(3, 65)
            Me._gbOptionsFlags.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptionsFlags.Name = "_gbOptionsFlags"
            Me._gbOptionsFlags.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptionsFlags.Size = New System.Drawing.Size(209, 7)
            Me._gbOptionsFlags.TabIndex = 5
            Me._gbOptionsFlags.TabStop = False
            '
            '_numHeight
            '
            Me._numHeight.Location = New System.Drawing.Point(109, 41)
            Me._numHeight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
            Me._numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numHeight.Name = "_numHeight"
            Me._numHeight.Size = New System.Drawing.Size(103, 20)
            Me._numHeight.TabIndex = 3
            Me._numHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_numWidth
            '
            Me._numWidth.Location = New System.Drawing.Point(109, 16)
            Me._numWidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numWidth.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
            Me._numWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numWidth.Name = "_numWidth"
            Me._numWidth.Size = New System.Drawing.Size(103, 20)
            Me._numWidth.TabIndex = 2
            Me._numWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(239, 39)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(68, 22)
            Me._btnCancel.TabIndex = 6
            Me._btnCancel.Text = "Cancel"
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(239, 9)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(68, 22)
            Me._btnOk.TabIndex = 5
            Me._btnOk.Text = "OK"
            '
            'ResizeInterpolateDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(317, 131)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbOptions)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ResizeInterpolateDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Resize Interpolate"
            Me._gbOptions.ResumeLayout(False)
            Me._gbOptions.PerformLayout()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _lblWidth As System.Windows.Forms.Label
	  Private _lblHeight As System.Windows.Forms.Label
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _numHeight As System.Windows.Forms.NumericUpDown
	  Private _numWidth As System.Windows.Forms.NumericUpDown
	  Private _gbOptionsFlags As System.Windows.Forms.GroupBox
	  Private _cmbInterpolation As System.Windows.Forms.ComboBox
	  Private _lblInterpolation As System.Windows.Forms.Label
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace