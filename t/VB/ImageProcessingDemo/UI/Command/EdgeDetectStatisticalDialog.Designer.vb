Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class EdgeDetectStatisticalDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EdgeDetectStatisticalDialog))
            Me._gbEdge = New System.Windows.Forms.GroupBox
            Me._lblThreshold = New System.Windows.Forms.Label
            Me._lblDimension = New System.Windows.Forms.Label
            Me._tbThreshold = New System.Windows.Forms.TrackBar
            Me._tbDimension = New System.Windows.Forms.TrackBar
            Me._numThreshold = New System.Windows.Forms.NumericUpDown
            Me._numDimension = New System.Windows.Forms.NumericUpDown
            Me._gbColor = New System.Windows.Forms.GroupBox
            Me._lblBackGroundColor = New System.Windows.Forms.Label
            Me._lblEdgeColor = New System.Windows.Forms.Label
            Me._BtnBackGroundColor = New System.Windows.Forms.Button
            Me._BtnEdgeColor = New System.Windows.Forms.Button
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbEdge.SuspendLayout()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbDimension, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numDimension, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbColor.SuspendLayout()
            Me.SuspendLayout()
            '
            '_gbEdge
            '
            Me._gbEdge.Controls.Add(Me._lblThreshold)
            Me._gbEdge.Controls.Add(Me._lblDimension)
            Me._gbEdge.Controls.Add(Me._tbThreshold)
            Me._gbEdge.Controls.Add(Me._tbDimension)
            Me._gbEdge.Controls.Add(Me._numThreshold)
            Me._gbEdge.Controls.Add(Me._numDimension)
            Me._gbEdge.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbEdge.Location = New System.Drawing.Point(10, 10)
            Me._gbEdge.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbEdge.Name = "_gbEdge"
            Me._gbEdge.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbEdge.Size = New System.Drawing.Size(421, 126)
            Me._gbEdge.TabIndex = 0
            Me._gbEdge.TabStop = False
            Me._gbEdge.Text = "Edge"
            '
            '_lblThreshold
            '
            Me._lblThreshold.AutoSize = True
            Me._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblThreshold.Location = New System.Drawing.Point(29, 67)
            Me._lblThreshold.Name = "_lblThreshold"
            Me._lblThreshold.Size = New System.Drawing.Size(54, 13)
            Me._lblThreshold.TabIndex = 5
            Me._lblThreshold.Text = "Threshold"
            '
            '_lblDimension
            '
            Me._lblDimension.AutoSize = True
            Me._lblDimension.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblDimension.Location = New System.Drawing.Point(27, 16)
            Me._lblDimension.Name = "_lblDimension"
            Me._lblDimension.Size = New System.Drawing.Size(56, 13)
            Me._lblDimension.TabIndex = 4
            Me._lblDimension.Text = "Dimension"
            '
            '_tbThreshold
            '
            Me._tbThreshold.AutoSize = False
            Me._tbThreshold.Location = New System.Drawing.Point(103, 63)
            Me._tbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbThreshold.Maximum = 255
            Me._tbThreshold.Name = "_tbThreshold"
            Me._tbThreshold.Size = New System.Drawing.Size(251, 28)
            Me._tbThreshold.TabIndex = 3
            Me._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_tbDimension
            '
            Me._tbDimension.AutoSize = False
            Me._tbDimension.Location = New System.Drawing.Point(103, 11)
            Me._tbDimension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbDimension.Maximum = 100
            Me._tbDimension.Minimum = 1
            Me._tbDimension.Name = "_tbDimension"
            Me._tbDimension.Size = New System.Drawing.Size(251, 26)
            Me._tbDimension.TabIndex = 2
            Me._tbDimension.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbDimension.Value = 1
            '
            '_numThreshold
            '
            Me._numThreshold.Location = New System.Drawing.Point(359, 63)
            Me._numThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numThreshold.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
            Me._numThreshold.Name = "_numThreshold"
            Me._numThreshold.Size = New System.Drawing.Size(57, 20)
            Me._numThreshold.TabIndex = 1
            '
            '_numDimension
            '
            Me._numDimension.Location = New System.Drawing.Point(359, 11)
            Me._numDimension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numDimension.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numDimension.Name = "_numDimension"
            Me._numDimension.Size = New System.Drawing.Size(57, 20)
            Me._numDimension.TabIndex = 0
            Me._numDimension.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_gbColor
            '
            Me._gbColor.Controls.Add(Me._lblBackGroundColor)
            Me._gbColor.Controls.Add(Me._lblEdgeColor)
            Me._gbColor.Controls.Add(Me._BtnBackGroundColor)
            Me._gbColor.Controls.Add(Me._BtnEdgeColor)
            Me._gbColor.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbColor.Location = New System.Drawing.Point(12, 144)
            Me._gbColor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbColor.Name = "_gbColor"
            Me._gbColor.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbColor.Size = New System.Drawing.Size(418, 81)
            Me._gbColor.TabIndex = 1
            Me._gbColor.TabStop = False
            Me._gbColor.Text = "Color"
            '
            '_lblBackGroundColor
            '
            Me._lblBackGroundColor.BackColor = System.Drawing.Color.Black
            Me._lblBackGroundColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me._lblBackGroundColor.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblBackGroundColor.Location = New System.Drawing.Point(339, 27)
            Me._lblBackGroundColor.Name = "_lblBackGroundColor"
            Me._lblBackGroundColor.Size = New System.Drawing.Size(44, 29)
            Me._lblBackGroundColor.TabIndex = 3
            '
            '_lblEdgeColor
            '
            Me._lblEdgeColor.BackColor = System.Drawing.Color.White
            Me._lblEdgeColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me._lblEdgeColor.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblEdgeColor.Location = New System.Drawing.Point(119, 27)
            Me._lblEdgeColor.Name = "_lblEdgeColor"
            Me._lblEdgeColor.Size = New System.Drawing.Size(44, 29)
            Me._lblEdgeColor.TabIndex = 2
            '
            '_BtnBackGroundColor
            '
            Me._BtnBackGroundColor.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._BtnBackGroundColor.Location = New System.Drawing.Point(226, 27)
            Me._BtnBackGroundColor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._BtnBackGroundColor.Name = "_BtnBackGroundColor"
            Me._BtnBackGroundColor.Size = New System.Drawing.Size(113, 29)
            Me._BtnBackGroundColor.TabIndex = 1
            Me._BtnBackGroundColor.Text = "Background Color ..."
            Me._BtnBackGroundColor.UseVisualStyleBackColor = True
            '
            '_BtnEdgeColor
            '
            Me._BtnEdgeColor.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._BtnEdgeColor.Location = New System.Drawing.Point(27, 27)
            Me._BtnEdgeColor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._BtnEdgeColor.Name = "_BtnEdgeColor"
            Me._BtnEdgeColor.Size = New System.Drawing.Size(93, 29)
            Me._BtnEdgeColor.TabIndex = 0
            Me._BtnEdgeColor.Text = "Edge Color ..."
            Me._BtnEdgeColor.UseVisualStyleBackColor = True
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(263, 239)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(83, 22)
            Me._btnCancel.TabIndex = 4
            Me._btnCancel.Text = "Cancel"
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(69, 239)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(83, 22)
            Me._btnOk.TabIndex = 3
            Me._btnOk.Text = "OK"
            '
            'EdgeDetectStatisticalDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(441, 273)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbColor)
            Me.Controls.Add(Me._gbEdge)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "EdgeDetectStatisticalDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Edge Detect Statistical"
            Me._gbEdge.ResumeLayout(False)
            Me._gbEdge.PerformLayout()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbDimension, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numThreshold, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numDimension, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbColor.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbEdge As System.Windows.Forms.GroupBox
	  Private _gbColor As System.Windows.Forms.GroupBox
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _lblThreshold As System.Windows.Forms.Label
	  Private _lblDimension As System.Windows.Forms.Label
	  Public WithEvents _tbThreshold As System.Windows.Forms.TrackBar
	  Public WithEvents _tbDimension As System.Windows.Forms.TrackBar
	  Private WithEvents _numThreshold As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numDimension As System.Windows.Forms.NumericUpDown
	  Private _lblBackGroundColor As System.Windows.Forms.Label
	  Private _lblEdgeColor As System.Windows.Forms.Label
	  Private WithEvents _BtnBackGroundColor As System.Windows.Forms.Button
	  Private WithEvents _BtnEdgeColor As System.Windows.Forms.Button
   End Class
End Namespace