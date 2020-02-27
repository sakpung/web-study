Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class ColorHalftoneDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ColorHalftoneDialog))
            Me._gbBlackAngle = New System.Windows.Forms.GroupBox
            Me._numBlackAngle = New System.Windows.Forms.NumericUpDown
            Me._tbBlackAngle = New System.Windows.Forms.TrackBar
            Me._gbCyanAngle = New System.Windows.Forms.GroupBox
            Me._numCyanAngle = New System.Windows.Forms.NumericUpDown
            Me._tbCyanAngle = New System.Windows.Forms.TrackBar
            Me._gbMagentaAngle = New System.Windows.Forms.GroupBox
            Me._numMagentaAngle = New System.Windows.Forms.NumericUpDown
            Me._tbMagentaAngle = New System.Windows.Forms.TrackBar
            Me._gbYellowAngle = New System.Windows.Forms.GroupBox
            Me._numYellowAngle = New System.Windows.Forms.NumericUpDown
            Me._tbYellowAngle = New System.Windows.Forms.TrackBar
            Me._tbRadius = New System.Windows.Forms.TrackBar
            Me._gbRadius = New System.Windows.Forms.GroupBox
            Me._numRadius = New System.Windows.Forms.NumericUpDown
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbBlackAngle.SuspendLayout()
            CType(Me._numBlackAngle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbBlackAngle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbCyanAngle.SuspendLayout()
            CType(Me._numCyanAngle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbCyanAngle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbMagentaAngle.SuspendLayout()
            CType(Me._numMagentaAngle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbMagentaAngle, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbYellowAngle.SuspendLayout()
            CType(Me._numYellowAngle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbYellowAngle, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbRadius, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbRadius.SuspendLayout()
            CType(Me._numRadius, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbBlackAngle
            '
            Me._gbBlackAngle.Controls.Add(Me._numBlackAngle)
            Me._gbBlackAngle.Controls.Add(Me._tbBlackAngle)
            Me._gbBlackAngle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbBlackAngle.Location = New System.Drawing.Point(10, 10)
            Me._gbBlackAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbBlackAngle.Name = "_gbBlackAngle"
            Me._gbBlackAngle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbBlackAngle.Size = New System.Drawing.Size(364, 60)
            Me._gbBlackAngle.TabIndex = 0
            Me._gbBlackAngle.TabStop = False
            Me._gbBlackAngle.Text = "Black"
            '
            '_numBlackAngle
            '
            Me._numBlackAngle.Location = New System.Drawing.Point(5, 19)
            Me._numBlackAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numBlackAngle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
            Me._numBlackAngle.Minimum = New Decimal(New Integer() {360, 0, 0, -2147483648})
            Me._numBlackAngle.Name = "_numBlackAngle"
            Me._numBlackAngle.Size = New System.Drawing.Size(74, 20)
            Me._numBlackAngle.TabIndex = 1
            '
            '_tbBlackAngle
            '
            Me._tbBlackAngle.Location = New System.Drawing.Point(82, 12)
            Me._tbBlackAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbBlackAngle.Maximum = 360
            Me._tbBlackAngle.Minimum = -360
            Me._tbBlackAngle.Name = "_tbBlackAngle"
            Me._tbBlackAngle.Size = New System.Drawing.Size(275, 45)
            Me._tbBlackAngle.TabIndex = 0
            Me._tbBlackAngle.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_gbCyanAngle
            '
            Me._gbCyanAngle.Controls.Add(Me._numCyanAngle)
            Me._gbCyanAngle.Controls.Add(Me._tbCyanAngle)
            Me._gbCyanAngle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbCyanAngle.Location = New System.Drawing.Point(10, 75)
            Me._gbCyanAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbCyanAngle.Name = "_gbCyanAngle"
            Me._gbCyanAngle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbCyanAngle.Size = New System.Drawing.Size(364, 60)
            Me._gbCyanAngle.TabIndex = 1
            Me._gbCyanAngle.TabStop = False
            Me._gbCyanAngle.Text = "Cyan"
            '
            '_numCyanAngle
            '
            Me._numCyanAngle.Location = New System.Drawing.Point(5, 20)
            Me._numCyanAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numCyanAngle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
            Me._numCyanAngle.Minimum = New Decimal(New Integer() {360, 0, 0, -2147483648})
            Me._numCyanAngle.Name = "_numCyanAngle"
            Me._numCyanAngle.Size = New System.Drawing.Size(74, 20)
            Me._numCyanAngle.TabIndex = 1
            '
            '_tbCyanAngle
            '
            Me._tbCyanAngle.Location = New System.Drawing.Point(82, 12)
            Me._tbCyanAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbCyanAngle.Maximum = 360
            Me._tbCyanAngle.Minimum = -360
            Me._tbCyanAngle.Name = "_tbCyanAngle"
            Me._tbCyanAngle.Size = New System.Drawing.Size(275, 45)
            Me._tbCyanAngle.TabIndex = 0
            Me._tbCyanAngle.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_gbMagentaAngle
            '
            Me._gbMagentaAngle.Controls.Add(Me._numMagentaAngle)
            Me._gbMagentaAngle.Controls.Add(Me._tbMagentaAngle)
            Me._gbMagentaAngle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbMagentaAngle.Location = New System.Drawing.Point(10, 137)
            Me._gbMagentaAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbMagentaAngle.Name = "_gbMagentaAngle"
            Me._gbMagentaAngle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbMagentaAngle.Size = New System.Drawing.Size(364, 60)
            Me._gbMagentaAngle.TabIndex = 2
            Me._gbMagentaAngle.TabStop = False
            Me._gbMagentaAngle.Text = "Magenta"
            '
            '_numMagentaAngle
            '
            Me._numMagentaAngle.Location = New System.Drawing.Point(5, 19)
            Me._numMagentaAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numMagentaAngle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
            Me._numMagentaAngle.Minimum = New Decimal(New Integer() {360, 0, 0, -2147483648})
            Me._numMagentaAngle.Name = "_numMagentaAngle"
            Me._numMagentaAngle.Size = New System.Drawing.Size(74, 20)
            Me._numMagentaAngle.TabIndex = 1
            '
            '_tbMagentaAngle
            '
            Me._tbMagentaAngle.Location = New System.Drawing.Point(84, 12)
            Me._tbMagentaAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbMagentaAngle.Maximum = 360
            Me._tbMagentaAngle.Minimum = -360
            Me._tbMagentaAngle.Name = "_tbMagentaAngle"
            Me._tbMagentaAngle.Size = New System.Drawing.Size(273, 45)
            Me._tbMagentaAngle.TabIndex = 0
            Me._tbMagentaAngle.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_gbYellowAngle
            '
            Me._gbYellowAngle.Controls.Add(Me._numYellowAngle)
            Me._gbYellowAngle.Controls.Add(Me._tbYellowAngle)
            Me._gbYellowAngle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbYellowAngle.Location = New System.Drawing.Point(10, 202)
            Me._gbYellowAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbYellowAngle.Name = "_gbYellowAngle"
            Me._gbYellowAngle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbYellowAngle.Size = New System.Drawing.Size(364, 60)
            Me._gbYellowAngle.TabIndex = 3
            Me._gbYellowAngle.TabStop = False
            Me._gbYellowAngle.Text = "Yellow"
            '
            '_numYellowAngle
            '
            Me._numYellowAngle.Location = New System.Drawing.Point(5, 19)
            Me._numYellowAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numYellowAngle.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
            Me._numYellowAngle.Minimum = New Decimal(New Integer() {360, 0, 0, -2147483648})
            Me._numYellowAngle.Name = "_numYellowAngle"
            Me._numYellowAngle.Size = New System.Drawing.Size(74, 20)
            Me._numYellowAngle.TabIndex = 1
            '
            '_tbYellowAngle
            '
            Me._tbYellowAngle.Location = New System.Drawing.Point(84, 12)
            Me._tbYellowAngle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbYellowAngle.Maximum = 360
            Me._tbYellowAngle.Minimum = -360
            Me._tbYellowAngle.Name = "_tbYellowAngle"
            Me._tbYellowAngle.Size = New System.Drawing.Size(273, 45)
            Me._tbYellowAngle.TabIndex = 0
            Me._tbYellowAngle.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_tbRadius
            '
            Me._tbRadius.Location = New System.Drawing.Point(84, 32)
            Me._tbRadius.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbRadius.Maximum = 127
            Me._tbRadius.Minimum = 5
            Me._tbRadius.Name = "_tbRadius"
            Me._tbRadius.Size = New System.Drawing.Size(267, 45)
            Me._tbRadius.TabIndex = 5
            Me._tbRadius.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbRadius.Value = 5
            '
            '_gbRadius
            '
            Me._gbRadius.Controls.Add(Me._numRadius)
            Me._gbRadius.Controls.Add(Me._tbRadius)
            Me._gbRadius.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbRadius.Location = New System.Drawing.Point(10, 267)
            Me._gbRadius.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRadius.Name = "_gbRadius"
            Me._gbRadius.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRadius.Size = New System.Drawing.Size(364, 81)
            Me._gbRadius.TabIndex = 6
            Me._gbRadius.TabStop = False
            Me._gbRadius.Text = "Radius"
            '
            '_numRadius
            '
            Me._numRadius.Location = New System.Drawing.Point(5, 32)
            Me._numRadius.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numRadius.Maximum = New Decimal(New Integer() {127, 0, 0, 0})
            Me._numRadius.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
            Me._numRadius.Name = "_numRadius"
            Me._numRadius.Size = New System.Drawing.Size(74, 20)
            Me._numRadius.TabIndex = 6
            Me._numRadius.Value = New Decimal(New Integer() {5, 0, 0, 0})
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(380, 53)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(86, 27)
            Me._btnCancel.TabIndex = 15
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(380, 21)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(86, 27)
            Me._btnOk.TabIndex = 14
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'ColorHalftoneDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(469, 361)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbRadius)
            Me.Controls.Add(Me._gbYellowAngle)
            Me.Controls.Add(Me._gbMagentaAngle)
            Me.Controls.Add(Me._gbCyanAngle)
            Me.Controls.Add(Me._gbBlackAngle)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ColorHalftoneDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Color Halftone"
            Me._gbBlackAngle.ResumeLayout(False)
            Me._gbBlackAngle.PerformLayout()
            CType(Me._numBlackAngle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbBlackAngle, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbCyanAngle.ResumeLayout(False)
            Me._gbCyanAngle.PerformLayout()
            CType(Me._numCyanAngle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbCyanAngle, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbMagentaAngle.ResumeLayout(False)
            Me._gbMagentaAngle.PerformLayout()
            CType(Me._numMagentaAngle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbMagentaAngle, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbYellowAngle.ResumeLayout(False)
            Me._gbYellowAngle.PerformLayout()
            CType(Me._numYellowAngle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbYellowAngle, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbRadius, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbRadius.ResumeLayout(False)
            Me._gbRadius.PerformLayout()
            CType(Me._numRadius, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbBlackAngle As System.Windows.Forms.GroupBox
	  Private WithEvents _numBlackAngle As System.Windows.Forms.NumericUpDown
	  Private _gbCyanAngle As System.Windows.Forms.GroupBox
	  Private WithEvents _numCyanAngle As System.Windows.Forms.NumericUpDown
	  Private _gbMagentaAngle As System.Windows.Forms.GroupBox
	  Private WithEvents _numMagentaAngle As System.Windows.Forms.NumericUpDown
	  Private _gbYellowAngle As System.Windows.Forms.GroupBox
	  Private WithEvents _numYellowAngle As System.Windows.Forms.NumericUpDown
	  Public WithEvents _tbBlackAngle As System.Windows.Forms.TrackBar
	  Public WithEvents _tbCyanAngle As System.Windows.Forms.TrackBar
	  Public WithEvents _tbMagentaAngle As System.Windows.Forms.TrackBar
	  Public WithEvents _tbYellowAngle As System.Windows.Forms.TrackBar
	  Public WithEvents _tbRadius As System.Windows.Forms.TrackBar
	  Private _gbRadius As System.Windows.Forms.GroupBox
	  Private WithEvents _numRadius As System.Windows.Forms.NumericUpDown
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace