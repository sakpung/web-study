Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class EdgeDetectEffectDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EdgeDetectEffectDialog))
            Me._gbLevel = New System.Windows.Forms.GroupBox
            Me._tbLevel = New System.Windows.Forms.TrackBar
            Me._txbLevel = New System.Windows.Forms.TextBox
            Me._gbThreshold = New System.Windows.Forms.GroupBox
            Me._tbThreshold = New System.Windows.Forms.TrackBar
            Me._txbThreshold = New System.Windows.Forms.TextBox
            Me._gbType = New System.Windows.Forms.GroupBox
            Me._cmbType = New System.Windows.Forms.ComboBox
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbLevel.SuspendLayout()
            CType(Me._tbLevel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbThreshold.SuspendLayout()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbType.SuspendLayout()
            Me.SuspendLayout()
            '
            '_gbLevel
            '
            Me._gbLevel.Controls.Add(Me._tbLevel)
            Me._gbLevel.Controls.Add(Me._txbLevel)
            Me._gbLevel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbLevel.Location = New System.Drawing.Point(10, 10)
            Me._gbLevel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbLevel.Name = "_gbLevel"
            Me._gbLevel.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbLevel.Size = New System.Drawing.Size(351, 60)
            Me._gbLevel.TabIndex = 0
            Me._gbLevel.TabStop = False
            Me._gbLevel.Text = "Level"
            '
            '_tbLevel
            '
            Me._tbLevel.Location = New System.Drawing.Point(84, 13)
            Me._tbLevel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbLevel.Maximum = 100
            Me._tbLevel.Minimum = 1
            Me._tbLevel.Name = "_tbLevel"
            Me._tbLevel.Size = New System.Drawing.Size(249, 45)
            Me._tbLevel.TabIndex = 1
            Me._tbLevel.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbLevel.Value = 1
            '
            '_txbLevel
            '
            Me._txbLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbLevel.Location = New System.Drawing.Point(14, 19)
            Me._txbLevel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbLevel.Name = "_txbLevel"
            Me._txbLevel.Size = New System.Drawing.Size(60, 20)
            Me._txbLevel.TabIndex = 0
            '
            '_gbThreshold
            '
            Me._gbThreshold.Controls.Add(Me._tbThreshold)
            Me._gbThreshold.Controls.Add(Me._txbThreshold)
            Me._gbThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbThreshold.Location = New System.Drawing.Point(10, 79)
            Me._gbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbThreshold.Name = "_gbThreshold"
            Me._gbThreshold.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbThreshold.Size = New System.Drawing.Size(351, 63)
            Me._gbThreshold.TabIndex = 1
            Me._gbThreshold.TabStop = False
            Me._gbThreshold.Text = "Threshold"
            '
            '_tbThreshold
            '
            Me._tbThreshold.Location = New System.Drawing.Point(84, 15)
            Me._tbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbThreshold.Maximum = 255
            Me._tbThreshold.Name = "_tbThreshold"
            Me._tbThreshold.Size = New System.Drawing.Size(249, 45)
            Me._tbThreshold.TabIndex = 1
            Me._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_txbThreshold
            '
            Me._txbThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbThreshold.Location = New System.Drawing.Point(14, 21)
            Me._txbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbThreshold.Name = "_txbThreshold"
            Me._txbThreshold.Size = New System.Drawing.Size(60, 20)
            Me._txbThreshold.TabIndex = 0
            '
            '_gbType
            '
            Me._gbType.Controls.Add(Me._cmbType)
            Me._gbType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbType.Location = New System.Drawing.Point(9, 150)
            Me._gbType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbType.Name = "_gbType"
            Me._gbType.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbType.Size = New System.Drawing.Size(351, 62)
            Me._gbType.TabIndex = 2
            Me._gbType.TabStop = False
            Me._gbType.Text = "Type"
            '
            '_cmbType
            '
            Me._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbType.FormattingEnabled = True
            Me._cmbType.Location = New System.Drawing.Point(15, 27)
            Me._cmbType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbType.Name = "_cmbType"
            Me._cmbType.Size = New System.Drawing.Size(248, 21)
            Me._cmbType.TabIndex = 0
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(381, 47)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(75, 23)
            Me._btnCancel.TabIndex = 7
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(381, 18)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(75, 23)
            Me._btnOk.TabIndex = 6
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'EdgeDetectEffectDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(460, 228)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbType)
            Me.Controls.Add(Me._gbThreshold)
            Me.Controls.Add(Me._gbLevel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "EdgeDetectEffectDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "EdgeDetectEffect"
            Me.TopMost = True
            Me._gbLevel.ResumeLayout(False)
            Me._gbLevel.PerformLayout()
            CType(Me._tbLevel, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbThreshold.ResumeLayout(False)
            Me._gbThreshold.PerformLayout()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbType.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbLevel As System.Windows.Forms.GroupBox
	  Private _gbThreshold As System.Windows.Forms.GroupBox
	  Private _gbType As System.Windows.Forms.GroupBox
	  Private WithEvents _tbLevel As System.Windows.Forms.TrackBar
	  Private WithEvents _txbLevel As System.Windows.Forms.TextBox
	  Private WithEvents _tbThreshold As System.Windows.Forms.TrackBar
	  Private WithEvents _txbThreshold As System.Windows.Forms.TextBox
	  Private _cmbType As System.Windows.Forms.ComboBox
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace