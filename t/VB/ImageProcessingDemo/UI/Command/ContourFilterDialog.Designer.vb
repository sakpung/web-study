Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class ContourFilterDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContourFilterDialog))
            Me._gbDeltaDirection = New System.Windows.Forms.GroupBox
            Me._tbDeltaDirection = New System.Windows.Forms.TrackBar
            Me._txbDeltaDirection = New System.Windows.Forms.TextBox
            Me._gbMaximumError = New System.Windows.Forms.GroupBox
            Me._tbMaximumError = New System.Windows.Forms.TrackBar
            Me._txbMaximumError = New System.Windows.Forms.TextBox
            Me._gbThreshold = New System.Windows.Forms.GroupBox
            Me._tbThreshold = New System.Windows.Forms.TrackBar
            Me._txbThreshold = New System.Windows.Forms.TextBox
            Me._gbType = New System.Windows.Forms.GroupBox
            Me._cmbType = New System.Windows.Forms.ComboBox
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbDeltaDirection.SuspendLayout()
            CType(Me._tbDeltaDirection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbMaximumError.SuspendLayout()
            CType(Me._tbMaximumError, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbThreshold.SuspendLayout()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbType.SuspendLayout()
            Me.SuspendLayout()
            '
            '_gbDeltaDirection
            '
            Me._gbDeltaDirection.Controls.Add(Me._tbDeltaDirection)
            Me._gbDeltaDirection.Controls.Add(Me._txbDeltaDirection)
            Me._gbDeltaDirection.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbDeltaDirection.Location = New System.Drawing.Point(10, 10)
            Me._gbDeltaDirection.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDeltaDirection.Name = "_gbDeltaDirection"
            Me._gbDeltaDirection.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDeltaDirection.Size = New System.Drawing.Size(321, 63)
            Me._gbDeltaDirection.TabIndex = 0
            Me._gbDeltaDirection.TabStop = False
            Me._gbDeltaDirection.Text = "DeltaDirection"
            '
            '_tbDeltaDirection
            '
            Me._tbDeltaDirection.Location = New System.Drawing.Point(77, 15)
            Me._tbDeltaDirection.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbDeltaDirection.Maximum = 64
            Me._tbDeltaDirection.Minimum = 1
            Me._tbDeltaDirection.Name = "_tbDeltaDirection"
            Me._tbDeltaDirection.Size = New System.Drawing.Size(236, 45)
            Me._tbDeltaDirection.TabIndex = 1
            Me._tbDeltaDirection.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbDeltaDirection.Value = 1
            '
            '_txbDeltaDirection
            '
            Me._txbDeltaDirection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbDeltaDirection.Location = New System.Drawing.Point(5, 19)
            Me._txbDeltaDirection.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbDeltaDirection.Name = "_txbDeltaDirection"
            Me._txbDeltaDirection.Size = New System.Drawing.Size(67, 20)
            Me._txbDeltaDirection.TabIndex = 0
            '
            '_gbMaximumError
            '
            Me._gbMaximumError.Controls.Add(Me._tbMaximumError)
            Me._gbMaximumError.Controls.Add(Me._txbMaximumError)
            Me._gbMaximumError.Enabled = False
            Me._gbMaximumError.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbMaximumError.Location = New System.Drawing.Point(10, 78)
            Me._gbMaximumError.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbMaximumError.Name = "_gbMaximumError"
            Me._gbMaximumError.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbMaximumError.Size = New System.Drawing.Size(321, 66)
            Me._gbMaximumError.TabIndex = 1
            Me._gbMaximumError.TabStop = False
            Me._gbMaximumError.Text = "MaximumError"
            '
            '_tbMaximumError
            '
            Me._tbMaximumError.Location = New System.Drawing.Point(77, 19)
            Me._tbMaximumError.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbMaximumError.Maximum = 255
            Me._tbMaximumError.Name = "_tbMaximumError"
            Me._tbMaximumError.Size = New System.Drawing.Size(236, 45)
            Me._tbMaximumError.TabIndex = 1
            Me._tbMaximumError.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_txbMaximumError
            '
            Me._txbMaximumError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbMaximumError.Location = New System.Drawing.Point(5, 26)
            Me._txbMaximumError.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbMaximumError.Name = "_txbMaximumError"
            Me._txbMaximumError.Size = New System.Drawing.Size(67, 20)
            Me._txbMaximumError.TabIndex = 0
            '
            '_gbThreshold
            '
            Me._gbThreshold.Controls.Add(Me._tbThreshold)
            Me._gbThreshold.Controls.Add(Me._txbThreshold)
            Me._gbThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbThreshold.Location = New System.Drawing.Point(10, 149)
            Me._gbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbThreshold.Name = "_gbThreshold"
            Me._gbThreshold.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbThreshold.Size = New System.Drawing.Size(321, 63)
            Me._gbThreshold.TabIndex = 2
            Me._gbThreshold.TabStop = False
            Me._gbThreshold.Text = "Threshold"
            '
            '_tbThreshold
            '
            Me._tbThreshold.Location = New System.Drawing.Point(77, 15)
            Me._tbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbThreshold.Maximum = 254
            Me._tbThreshold.Minimum = 1
            Me._tbThreshold.Name = "_tbThreshold"
            Me._tbThreshold.Size = New System.Drawing.Size(236, 45)
            Me._tbThreshold.TabIndex = 1
            Me._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbThreshold.Value = 1
            '
            '_txbThreshold
            '
            Me._txbThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbThreshold.Location = New System.Drawing.Point(5, 28)
            Me._txbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbThreshold.Name = "_txbThreshold"
            Me._txbThreshold.Size = New System.Drawing.Size(67, 20)
            Me._txbThreshold.TabIndex = 0
            '
            '_gbType
            '
            Me._gbType.Controls.Add(Me._cmbType)
            Me._gbType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbType.Location = New System.Drawing.Point(10, 227)
            Me._gbType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbType.Name = "_gbType"
            Me._gbType.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbType.Size = New System.Drawing.Size(321, 69)
            Me._gbType.TabIndex = 3
            Me._gbType.TabStop = False
            Me._gbType.Text = "Type"
            '
            '_cmbType
            '
            Me._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbType.FormattingEnabled = True
            Me._cmbType.Location = New System.Drawing.Point(5, 30)
            Me._cmbType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbType.Name = "_cmbType"
            Me._cmbType.Size = New System.Drawing.Size(275, 21)
            Me._cmbType.TabIndex = 0
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(347, 58)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(86, 27)
            Me._btnCancel.TabIndex = 11
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(347, 21)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(86, 27)
            Me._btnOk.TabIndex = 10
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'ContourFilterDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(439, 310)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbType)
            Me.Controls.Add(Me._gbThreshold)
            Me.Controls.Add(Me._gbMaximumError)
            Me.Controls.Add(Me._gbDeltaDirection)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ContourFilterDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Contour Filter"
            Me._gbDeltaDirection.ResumeLayout(False)
            Me._gbDeltaDirection.PerformLayout()
            CType(Me._tbDeltaDirection, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbMaximumError.ResumeLayout(False)
            Me._gbMaximumError.PerformLayout()
            CType(Me._tbMaximumError, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbThreshold.ResumeLayout(False)
            Me._gbThreshold.PerformLayout()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbType.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbDeltaDirection As System.Windows.Forms.GroupBox
	  Private _gbMaximumError As System.Windows.Forms.GroupBox
	  Private _gbThreshold As System.Windows.Forms.GroupBox
	  Public WithEvents _tbDeltaDirection As System.Windows.Forms.TrackBar
	  Private WithEvents _txbDeltaDirection As System.Windows.Forms.TextBox
	  Public WithEvents _tbMaximumError As System.Windows.Forms.TrackBar
	  Private WithEvents _txbMaximumError As System.Windows.Forms.TextBox
	  Public WithEvents _tbThreshold As System.Windows.Forms.TrackBar
	  Private WithEvents _txbThreshold As System.Windows.Forms.TextBox
	  Private _gbType As System.Windows.Forms.GroupBox
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Protected WithEvents _cmbType As System.Windows.Forms.ComboBox
   End Class
End Namespace