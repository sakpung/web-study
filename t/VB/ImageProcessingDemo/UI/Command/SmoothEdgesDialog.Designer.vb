Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class SmoothEdgesDialog
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
            Me._gbSmoothEdges = New System.Windows.Forms.GroupBox
            Me._lblThreshold = New System.Windows.Forms.Label
            Me._lblAmount = New System.Windows.Forms.Label
            Me._numThreshold = New System.Windows.Forms.NumericUpDown
            Me._numAmount = New System.Windows.Forms.NumericUpDown
            Me._tbThreshold = New System.Windows.Forms.TrackBar
            Me._tbAmount = New System.Windows.Forms.TrackBar
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbSmoothEdges.SuspendLayout()
            CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numAmount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbAmount, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbSmoothEdges
            '
            Me._gbSmoothEdges.Controls.Add(Me._lblThreshold)
            Me._gbSmoothEdges.Controls.Add(Me._lblAmount)
            Me._gbSmoothEdges.Controls.Add(Me._numThreshold)
            Me._gbSmoothEdges.Controls.Add(Me._numAmount)
            Me._gbSmoothEdges.Controls.Add(Me._tbThreshold)
            Me._gbSmoothEdges.Controls.Add(Me._tbAmount)
            Me._gbSmoothEdges.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbSmoothEdges.Location = New System.Drawing.Point(11, 13)
            Me._gbSmoothEdges.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSmoothEdges.Name = "_gbSmoothEdges"
            Me._gbSmoothEdges.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSmoothEdges.Size = New System.Drawing.Size(416, 109)
            Me._gbSmoothEdges.TabIndex = 0
            Me._gbSmoothEdges.TabStop = False
            Me._gbSmoothEdges.Text = "Parameters"
            '
            '_lblThreshold
            '
            Me._lblThreshold.AutoSize = True
            Me._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblThreshold.Location = New System.Drawing.Point(18, 67)
            Me._lblThreshold.Name = "_lblThreshold"
            Me._lblThreshold.Size = New System.Drawing.Size(54, 13)
            Me._lblThreshold.TabIndex = 5
            Me._lblThreshold.Text = "Threshold"
            '
            '_lblAmount
            '
            Me._lblAmount.AutoSize = True
            Me._lblAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblAmount.Location = New System.Drawing.Point(18, 25)
            Me._lblAmount.Name = "_lblAmount"
            Me._lblAmount.Size = New System.Drawing.Size(43, 13)
            Me._lblAmount.TabIndex = 4
            Me._lblAmount.Text = "Amount"
            '
            '_numThreshold
            '
            Me._numThreshold.Location = New System.Drawing.Point(344, 66)
            Me._numThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numThreshold.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
            Me._numThreshold.Name = "_numThreshold"
            Me._numThreshold.Size = New System.Drawing.Size(61, 20)
            Me._numThreshold.TabIndex = 3
            '
            '_numAmount
            '
            Me._numAmount.Location = New System.Drawing.Point(344, 22)
            Me._numAmount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numAmount.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numAmount.Name = "_numAmount"
            Me._numAmount.Size = New System.Drawing.Size(61, 20)
            Me._numAmount.TabIndex = 2
            Me._numAmount.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_tbThreshold
            '
            Me._tbThreshold.Location = New System.Drawing.Point(98, 62)
            Me._tbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbThreshold.Maximum = 255
            Me._tbThreshold.Name = "_tbThreshold"
            Me._tbThreshold.Size = New System.Drawing.Size(237, 45)
            Me._tbThreshold.TabIndex = 1
            Me._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_tbAmount
            '
            Me._tbAmount.Location = New System.Drawing.Point(98, 19)
            Me._tbAmount.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbAmount.Maximum = 100
            Me._tbAmount.Minimum = 1
            Me._tbAmount.Name = "_tbAmount"
            Me._tbAmount.Size = New System.Drawing.Size(237, 45)
            Me._tbAmount.TabIndex = 0
            Me._tbAmount.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbAmount.Value = 1
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(249, 133)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(98, 20)
            Me._btnCancel.TabIndex = 6
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(81, 133)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(98, 20)
            Me._btnOk.TabIndex = 5
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'SmoothEdgesDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(437, 163)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbSmoothEdges)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.Name = "SmoothEdgesDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Smooth Edges"
            Me._gbSmoothEdges.ResumeLayout(False)
            Me._gbSmoothEdges.PerformLayout()
            CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numAmount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbAmount, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbSmoothEdges As System.Windows.Forms.GroupBox
	  Private _lblThreshold As System.Windows.Forms.Label
	  Private _lblAmount As System.Windows.Forms.Label
	  Private WithEvents _numThreshold As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numAmount As System.Windows.Forms.NumericUpDown
	  Public WithEvents _tbThreshold As System.Windows.Forms.TrackBar
	  Public WithEvents _tbAmount As System.Windows.Forms.TrackBar
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace