Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class HalfToneDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HalfToneDialog))
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbAngle = New System.Windows.Forms.GroupBox
            Me._numAngle = New System.Windows.Forms.NumericUpDown
            Me._tbAngle = New System.Windows.Forms.TrackBar
            Me._gbDimension = New System.Windows.Forms.GroupBox
            Me._numDimension = New System.Windows.Forms.NumericUpDown
            Me._tbDimension = New System.Windows.Forms.TrackBar
            Me._lblType = New System.Windows.Forms.Label
            Me._cmbType = New System.Windows.Forms.ComboBox
            Me._gbAngle.SuspendLayout()
            CType(Me._numAngle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbAngle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbDimension.SuspendLayout()
            CType(Me._numDimension, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbDimension, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(372, 41)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(86, 27)
            Me._btnCancel.TabIndex = 13
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(372, 10)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(86, 27)
            Me._btnOk.TabIndex = 12
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_gbAngle
            '
            Me._gbAngle.Controls.Add(Me._numAngle)
            Me._gbAngle.Controls.Add(Me._tbAngle)
            Me._gbAngle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbAngle.Location = New System.Drawing.Point(10, 10)
            Me._gbAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbAngle.Name = "_gbAngle"
            Me._gbAngle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbAngle.Size = New System.Drawing.Size(343, 67)
            Me._gbAngle.TabIndex = 14
            Me._gbAngle.TabStop = False
            Me._gbAngle.Text = "Angle"
            '
            '_numAngle
            '
            Me._numAngle.Location = New System.Drawing.Point(5, 19)
            Me._numAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numAngle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
            Me._numAngle.Minimum = New Decimal(New Integer() {360, 0, 0, -2147483648})
            Me._numAngle.Name = "_numAngle"
            Me._numAngle.Size = New System.Drawing.Size(57, 20)
            Me._numAngle.TabIndex = 1
            '
            '_tbAngle
            '
            Me._tbAngle.Location = New System.Drawing.Point(80, 15)
            Me._tbAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbAngle.Maximum = 360
            Me._tbAngle.Minimum = -360
            Me._tbAngle.Name = "_tbAngle"
            Me._tbAngle.Size = New System.Drawing.Size(258, 45)
            Me._tbAngle.TabIndex = 0
            Me._tbAngle.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_gbDimension
            '
            Me._gbDimension.Controls.Add(Me._numDimension)
            Me._gbDimension.Controls.Add(Me._tbDimension)
            Me._gbDimension.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbDimension.Location = New System.Drawing.Point(10, 94)
            Me._gbDimension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDimension.Name = "_gbDimension"
            Me._gbDimension.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDimension.Size = New System.Drawing.Size(343, 72)
            Me._gbDimension.TabIndex = 15
            Me._gbDimension.TabStop = False
            Me._gbDimension.Text = "Dimension"
            '
            '_numDimension
            '
            Me._numDimension.Location = New System.Drawing.Point(5, 19)
            Me._numDimension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numDimension.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
            Me._numDimension.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numDimension.Name = "_numDimension"
            Me._numDimension.Size = New System.Drawing.Size(57, 20)
            Me._numDimension.TabIndex = 1
            Me._numDimension.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_tbDimension
            '
            Me._tbDimension.Location = New System.Drawing.Point(80, 19)
            Me._tbDimension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbDimension.Maximum = 30
            Me._tbDimension.Minimum = 1
            Me._tbDimension.Name = "_tbDimension"
            Me._tbDimension.Size = New System.Drawing.Size(258, 45)
            Me._tbDimension.TabIndex = 0
            Me._tbDimension.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbDimension.Value = 1
            '
            '_lblType
            '
            Me._lblType.AutoSize = True
            Me._lblType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblType.Location = New System.Drawing.Point(13, 184)
            Me._lblType.Name = "_lblType"
            Me._lblType.Size = New System.Drawing.Size(31, 13)
            Me._lblType.TabIndex = 16
            Me._lblType.Text = "Type"
            '
            '_cmbType
            '
            Me._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbType.FormattingEnabled = True
            Me._cmbType.Location = New System.Drawing.Point(57, 180)
            Me._cmbType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbType.Name = "_cmbType"
            Me._cmbType.Size = New System.Drawing.Size(163, 21)
            Me._cmbType.TabIndex = 17
            '
            'HalfToneDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(468, 212)
            Me.Controls.Add(Me._cmbType)
            Me.Controls.Add(Me._lblType)
            Me.Controls.Add(Me._gbDimension)
            Me.Controls.Add(Me._gbAngle)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "HalfToneDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "HalfTone"
            Me._gbAngle.ResumeLayout(False)
            Me._gbAngle.PerformLayout()
            CType(Me._numAngle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbAngle, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbDimension.ResumeLayout(False)
            Me._gbDimension.PerformLayout()
            CType(Me._numDimension, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbDimension, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

	  #End Region

	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbAngle As System.Windows.Forms.GroupBox
	  Private _gbDimension As System.Windows.Forms.GroupBox
	  Private _lblType As System.Windows.Forms.Label
	  Private WithEvents _cmbType As System.Windows.Forms.ComboBox
	  Public WithEvents _tbAngle As System.Windows.Forms.TrackBar
	  Public WithEvents _tbDimension As System.Windows.Forms.TrackBar
	  Private WithEvents _numAngle As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numDimension As System.Windows.Forms.NumericUpDown
   End Class
End Namespace