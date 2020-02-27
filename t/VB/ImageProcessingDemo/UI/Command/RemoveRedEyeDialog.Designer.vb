Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class RemoveRedEyeDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RemoveRedEyeDialog))
            Me._gbRemoveRedEye = New System.Windows.Forms.GroupBox
            Me._lblLightness = New System.Windows.Forms.Label
            Me._lblThreshold = New System.Windows.Forms.Label
            Me._lblBlue = New System.Windows.Forms.Label
            Me._lblGreen = New System.Windows.Forms.Label
            Me._lblRed = New System.Windows.Forms.Label
            Me._tbLightness = New System.Windows.Forms.TrackBar
            Me._tbThreshold = New System.Windows.Forms.TrackBar
            Me._tbBlue = New System.Windows.Forms.TrackBar
            Me._tbGreen = New System.Windows.Forms.TrackBar
            Me._tbRed = New System.Windows.Forms.TrackBar
            Me._numLightness = New System.Windows.Forms.NumericUpDown
            Me._numThreshold = New System.Windows.Forms.NumericUpDown
            Me._numBlue = New System.Windows.Forms.NumericUpDown
            Me._numGreen = New System.Windows.Forms.NumericUpDown
            Me._numRed = New System.Windows.Forms.NumericUpDown
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbRemoveRedEye.SuspendLayout()
            CType(Me._tbLightness, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbBlue, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbGreen, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbRed, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numLightness, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numBlue, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numGreen, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numRed, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbRemoveRedEye
            '
            Me._gbRemoveRedEye.Controls.Add(Me._lblLightness)
            Me._gbRemoveRedEye.Controls.Add(Me._lblThreshold)
            Me._gbRemoveRedEye.Controls.Add(Me._lblBlue)
            Me._gbRemoveRedEye.Controls.Add(Me._lblGreen)
            Me._gbRemoveRedEye.Controls.Add(Me._lblRed)
            Me._gbRemoveRedEye.Controls.Add(Me._tbLightness)
            Me._gbRemoveRedEye.Controls.Add(Me._tbThreshold)
            Me._gbRemoveRedEye.Controls.Add(Me._tbBlue)
            Me._gbRemoveRedEye.Controls.Add(Me._tbGreen)
            Me._gbRemoveRedEye.Controls.Add(Me._tbRed)
            Me._gbRemoveRedEye.Controls.Add(Me._numLightness)
            Me._gbRemoveRedEye.Controls.Add(Me._numThreshold)
            Me._gbRemoveRedEye.Controls.Add(Me._numBlue)
            Me._gbRemoveRedEye.Controls.Add(Me._numGreen)
            Me._gbRemoveRedEye.Controls.Add(Me._numRed)
            Me._gbRemoveRedEye.Location = New System.Drawing.Point(10, 10)
            Me._gbRemoveRedEye.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRemoveRedEye.Name = "_gbRemoveRedEye"
            Me._gbRemoveRedEye.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRemoveRedEye.Size = New System.Drawing.Size(446, 284)
            Me._gbRemoveRedEye.TabIndex = 0
            Me._gbRemoveRedEye.TabStop = False
            '
            '_lblLightness
            '
            Me._lblLightness.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblLightness.Location = New System.Drawing.Point(13, 239)
            Me._lblLightness.Name = "_lblLightness"
            Me._lblLightness.Size = New System.Drawing.Size(62, 20)
            Me._lblLightness.TabIndex = 14
            Me._lblLightness.Text = "Lightness"
            '
            '_lblThreshold
            '
            Me._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblThreshold.Location = New System.Drawing.Point(13, 185)
            Me._lblThreshold.Name = "_lblThreshold"
            Me._lblThreshold.Size = New System.Drawing.Size(62, 20)
            Me._lblThreshold.TabIndex = 13
            Me._lblThreshold.Text = "Threshold"
            '
            '_lblBlue
            '
            Me._lblBlue.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblBlue.Location = New System.Drawing.Point(13, 122)
            Me._lblBlue.Name = "_lblBlue"
            Me._lblBlue.Size = New System.Drawing.Size(62, 20)
            Me._lblBlue.TabIndex = 12
            Me._lblBlue.Text = "Blue"
            '
            '_lblGreen
            '
            Me._lblGreen.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblGreen.Location = New System.Drawing.Point(13, 67)
            Me._lblGreen.Name = "_lblGreen"
            Me._lblGreen.Size = New System.Drawing.Size(62, 20)
            Me._lblGreen.TabIndex = 11
            Me._lblGreen.Text = "Green"
            '
            '_lblRed
            '
            Me._lblRed.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblRed.Location = New System.Drawing.Point(13, 22)
            Me._lblRed.Name = "_lblRed"
            Me._lblRed.Size = New System.Drawing.Size(62, 20)
            Me._lblRed.TabIndex = 10
            Me._lblRed.Text = "Red"
            '
            '_tbLightness
            '
            Me._tbLightness.AutoSize = False
            Me._tbLightness.Location = New System.Drawing.Point(75, 237)
            Me._tbLightness.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbLightness.Maximum = 255
            Me._tbLightness.Name = "_tbLightness"
            Me._tbLightness.Size = New System.Drawing.Size(288, 34)
            Me._tbLightness.TabIndex = 9
            Me._tbLightness.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_tbThreshold
            '
            Me._tbThreshold.AutoSize = False
            Me._tbThreshold.Location = New System.Drawing.Point(75, 184)
            Me._tbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbThreshold.Maximum = 255
            Me._tbThreshold.Name = "_tbThreshold"
            Me._tbThreshold.Size = New System.Drawing.Size(288, 34)
            Me._tbThreshold.TabIndex = 8
            Me._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_tbBlue
            '
            Me._tbBlue.AutoSize = False
            Me._tbBlue.Location = New System.Drawing.Point(75, 123)
            Me._tbBlue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbBlue.Maximum = 255
            Me._tbBlue.Name = "_tbBlue"
            Me._tbBlue.Size = New System.Drawing.Size(288, 34)
            Me._tbBlue.TabIndex = 7
            Me._tbBlue.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_tbGreen
            '
            Me._tbGreen.AutoSize = False
            Me._tbGreen.Location = New System.Drawing.Point(75, 66)
            Me._tbGreen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbGreen.Maximum = 255
            Me._tbGreen.Name = "_tbGreen"
            Me._tbGreen.Size = New System.Drawing.Size(288, 34)
            Me._tbGreen.TabIndex = 6
            Me._tbGreen.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_tbRed
            '
            Me._tbRed.AutoSize = False
            Me._tbRed.Location = New System.Drawing.Point(75, 17)
            Me._tbRed.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbRed.Maximum = 255
            Me._tbRed.Name = "_tbRed"
            Me._tbRed.Size = New System.Drawing.Size(288, 34)
            Me._tbRed.TabIndex = 5
            Me._tbRed.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_numLightness
            '
            Me._numLightness.Location = New System.Drawing.Point(368, 237)
            Me._numLightness.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numLightness.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
            Me._numLightness.Name = "_numLightness"
            Me._numLightness.Size = New System.Drawing.Size(59, 20)
            Me._numLightness.TabIndex = 4
            '
            '_numThreshold
            '
            Me._numThreshold.Location = New System.Drawing.Point(368, 184)
            Me._numThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numThreshold.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
            Me._numThreshold.Name = "_numThreshold"
            Me._numThreshold.Size = New System.Drawing.Size(59, 20)
            Me._numThreshold.TabIndex = 3
            '
            '_numBlue
            '
            Me._numBlue.Location = New System.Drawing.Point(368, 123)
            Me._numBlue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numBlue.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
            Me._numBlue.Name = "_numBlue"
            Me._numBlue.Size = New System.Drawing.Size(59, 20)
            Me._numBlue.TabIndex = 2
            '
            '_numGreen
            '
            Me._numGreen.Location = New System.Drawing.Point(368, 66)
            Me._numGreen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numGreen.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
            Me._numGreen.Name = "_numGreen"
            Me._numGreen.Size = New System.Drawing.Size(59, 20)
            Me._numGreen.TabIndex = 1
            '
            '_numRed
            '
            Me._numRed.Location = New System.Drawing.Point(368, 17)
            Me._numRed.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numRed.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
            Me._numRed.Name = "_numRed"
            Me._numRed.Size = New System.Drawing.Size(59, 20)
            Me._numRed.TabIndex = 0
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(263, 306)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(86, 22)
            Me._btnCancel.TabIndex = 8
            Me._btnCancel.Text = "Cancel"
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(94, 306)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(86, 22)
            Me._btnOk.TabIndex = 7
            Me._btnOk.Text = "OK"
            '
            'RemoveRedEyeDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(466, 347)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbRemoveRedEye)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "RemoveRedEyeDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Remove Red Eye"
            Me._gbRemoveRedEye.ResumeLayout(False)
            CType(Me._tbLightness, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbBlue, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbGreen, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbRed, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numLightness, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numBlue, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numGreen, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numRed, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbRemoveRedEye As System.Windows.Forms.GroupBox
	  Private _lblLightness As System.Windows.Forms.Label
	  Private _lblThreshold As System.Windows.Forms.Label
	  Private _lblBlue As System.Windows.Forms.Label
	  Private _lblGreen As System.Windows.Forms.Label
	  Private _lblRed As System.Windows.Forms.Label
	  Public WithEvents _tbLightness As System.Windows.Forms.TrackBar
	  Public WithEvents _tbThreshold As System.Windows.Forms.TrackBar
	  Public WithEvents _tbBlue As System.Windows.Forms.TrackBar
	  Public WithEvents _tbGreen As System.Windows.Forms.TrackBar
	  Public WithEvents _tbRed As System.Windows.Forms.TrackBar
	  Private WithEvents _numLightness As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numThreshold As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numBlue As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numGreen As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numRed As System.Windows.Forms.NumericUpDown
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace