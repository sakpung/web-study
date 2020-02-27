Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class AlphaBlendDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlphaBlendDialog))
            Me._gbDestinationRectangle = New System.Windows.Forms.GroupBox
            Me._numHeight = New System.Windows.Forms.NumericUpDown
            Me._numY1 = New System.Windows.Forms.NumericUpDown
            Me._numWidth = New System.Windows.Forms.NumericUpDown
            Me._numX1 = New System.Windows.Forms.NumericUpDown
            Me._lblHeight = New System.Windows.Forms.Label
            Me._lblWidth = New System.Windows.Forms.Label
            Me._lblY1 = New System.Windows.Forms.Label
            Me._lblX1 = New System.Windows.Forms.Label
            Me._gbSourcePoint = New System.Windows.Forms.GroupBox
            Me._numY2 = New System.Windows.Forms.NumericUpDown
            Me._numX2 = New System.Windows.Forms.NumericUpDown
            Me._lblY2 = New System.Windows.Forms.Label
            Me._lblX2 = New System.Windows.Forms.Label
            Me._lblOpacity = New System.Windows.Forms.Label
            Me._tbOpacity = New System.Windows.Forms.TrackBar
            Me._numOpacity = New System.Windows.Forms.NumericUpDown
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gb1 = New System.Windows.Forms.GroupBox
            Me._gbDestinationRectangle.SuspendLayout()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numY1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numX1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbSourcePoint.SuspendLayout()
            CType(Me._numY2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numX2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numOpacity, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gb1.SuspendLayout()
            Me.SuspendLayout()
            '
            '_gbDestinationRectangle
            '
            Me._gbDestinationRectangle.Controls.Add(Me._numHeight)
            Me._gbDestinationRectangle.Controls.Add(Me._numY1)
            Me._gbDestinationRectangle.Controls.Add(Me._numWidth)
            Me._gbDestinationRectangle.Controls.Add(Me._numX1)
            Me._gbDestinationRectangle.Controls.Add(Me._lblHeight)
            Me._gbDestinationRectangle.Controls.Add(Me._lblWidth)
            Me._gbDestinationRectangle.Controls.Add(Me._lblY1)
            Me._gbDestinationRectangle.Controls.Add(Me._lblX1)
            Me._gbDestinationRectangle.Location = New System.Drawing.Point(10, 10)
            Me._gbDestinationRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDestinationRectangle.Name = "_gbDestinationRectangle"
            Me._gbDestinationRectangle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDestinationRectangle.Size = New System.Drawing.Size(303, 107)
            Me._gbDestinationRectangle.TabIndex = 0
            Me._gbDestinationRectangle.TabStop = False
            Me._gbDestinationRectangle.Text = "Destination Rectangle"
            '
            '_numHeight
            '
            Me._numHeight.Location = New System.Drawing.Point(212, 71)
            Me._numHeight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numHeight.Name = "_numHeight"
            Me._numHeight.Size = New System.Drawing.Size(62, 20)
            Me._numHeight.TabIndex = 7
            Me._numHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_numY1
            '
            Me._numY1.Location = New System.Drawing.Point(54, 67)
            Me._numY1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numY1.Name = "_numY1"
            Me._numY1.Size = New System.Drawing.Size(49, 20)
            Me._numY1.TabIndex = 6
            '
            '_numWidth
            '
            Me._numWidth.Location = New System.Drawing.Point(212, 20)
            Me._numWidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numWidth.Name = "_numWidth"
            Me._numWidth.Size = New System.Drawing.Size(62, 20)
            Me._numWidth.TabIndex = 5
            Me._numWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_numX1
            '
            Me._numX1.Location = New System.Drawing.Point(54, 22)
            Me._numX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numX1.Name = "_numX1"
            Me._numX1.Size = New System.Drawing.Size(49, 20)
            Me._numX1.TabIndex = 4
            '
            '_lblHeight
            '
            Me._lblHeight.AutoSize = True
            Me._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblHeight.Location = New System.Drawing.Point(171, 72)
            Me._lblHeight.Name = "_lblHeight"
            Me._lblHeight.Size = New System.Drawing.Size(38, 13)
            Me._lblHeight.TabIndex = 3
            Me._lblHeight.Text = "Height"
            '
            '_lblWidth
            '
            Me._lblWidth.AutoSize = True
            Me._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblWidth.Location = New System.Drawing.Point(171, 20)
            Me._lblWidth.Name = "_lblWidth"
            Me._lblWidth.Size = New System.Drawing.Size(35, 13)
            Me._lblWidth.TabIndex = 2
            Me._lblWidth.Text = "Width"
            '
            '_lblY1
            '
            Me._lblY1.AutoSize = True
            Me._lblY1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblY1.Location = New System.Drawing.Point(13, 63)
            Me._lblY1.Name = "_lblY1"
            Me._lblY1.Size = New System.Drawing.Size(14, 13)
            Me._lblY1.TabIndex = 1
            Me._lblY1.Text = "Y"
            '
            '_lblX1
            '
            Me._lblX1.AutoSize = True
            Me._lblX1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblX1.Location = New System.Drawing.Point(13, 24)
            Me._lblX1.Name = "_lblX1"
            Me._lblX1.Size = New System.Drawing.Size(14, 13)
            Me._lblX1.TabIndex = 0
            Me._lblX1.Text = "X"
            '
            '_gbSourcePoint
            '
            Me._gbSourcePoint.Controls.Add(Me._numY2)
            Me._gbSourcePoint.Controls.Add(Me._numX2)
            Me._gbSourcePoint.Controls.Add(Me._lblY2)
            Me._gbSourcePoint.Controls.Add(Me._lblX2)
            Me._gbSourcePoint.Location = New System.Drawing.Point(10, 122)
            Me._gbSourcePoint.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSourcePoint.Name = "_gbSourcePoint"
            Me._gbSourcePoint.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSourcePoint.Size = New System.Drawing.Size(303, 54)
            Me._gbSourcePoint.TabIndex = 1
            Me._gbSourcePoint.TabStop = False
            Me._gbSourcePoint.Text = "Source Point"
            '
            '_numY2
            '
            Me._numY2.Location = New System.Drawing.Point(212, 19)
            Me._numY2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numY2.Name = "_numY2"
            Me._numY2.Size = New System.Drawing.Size(62, 20)
            Me._numY2.TabIndex = 3
            '
            '_numX2
            '
            Me._numX2.Location = New System.Drawing.Point(54, 15)
            Me._numX2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numX2.Name = "_numX2"
            Me._numX2.Size = New System.Drawing.Size(49, 20)
            Me._numX2.TabIndex = 2
            '
            '_lblY2
            '
            Me._lblY2.AutoSize = True
            Me._lblY2.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblY2.Location = New System.Drawing.Point(171, 21)
            Me._lblY2.Name = "_lblY2"
            Me._lblY2.Size = New System.Drawing.Size(14, 13)
            Me._lblY2.TabIndex = 1
            Me._lblY2.Text = "Y"
            '
            '_lblX2
            '
            Me._lblX2.AutoSize = True
            Me._lblX2.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblX2.Location = New System.Drawing.Point(13, 16)
            Me._lblX2.Name = "_lblX2"
            Me._lblX2.Size = New System.Drawing.Size(14, 13)
            Me._lblX2.TabIndex = 0
            Me._lblX2.Text = "X"
            '
            '_lblOpacity
            '
            Me._lblOpacity.AutoSize = True
            Me._lblOpacity.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblOpacity.Location = New System.Drawing.Point(16, 200)
            Me._lblOpacity.Name = "_lblOpacity"
            Me._lblOpacity.Size = New System.Drawing.Size(43, 13)
            Me._lblOpacity.TabIndex = 2
            Me._lblOpacity.Text = "Opacity"
            '
            '_tbOpacity
            '
            Me._tbOpacity.AutoSize = False
            Me._tbOpacity.Location = New System.Drawing.Point(64, 191)
            Me._tbOpacity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbOpacity.Name = "_tbOpacity"
            Me._tbOpacity.Size = New System.Drawing.Size(157, 32)
            Me._tbOpacity.TabIndex = 3
            Me._tbOpacity.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_numOpacity
            '
            Me._numOpacity.Location = New System.Drawing.Point(226, 194)
            Me._numOpacity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numOpacity.Name = "_numOpacity"
            Me._numOpacity.Size = New System.Drawing.Size(57, 20)
            Me._numOpacity.TabIndex = 4
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(179, 13)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(86, 27)
            Me._btnCancel.TabIndex = 9
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(9, 13)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(86, 27)
            Me._btnOk.TabIndex = 8
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_gb1
            '
            Me._gb1.Controls.Add(Me._btnCancel)
            Me._gb1.Controls.Add(Me._btnOk)
            Me._gb1.Location = New System.Drawing.Point(19, 242)
            Me._gb1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gb1.Name = "_gb1"
            Me._gb1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gb1.Size = New System.Drawing.Size(278, 53)
            Me._gb1.TabIndex = 10
            Me._gb1.TabStop = False
            '
            'AlphaBlendDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(321, 303)
            Me.Controls.Add(Me._gb1)
            Me.Controls.Add(Me._numOpacity)
            Me.Controls.Add(Me._tbOpacity)
            Me.Controls.Add(Me._lblOpacity)
            Me.Controls.Add(Me._gbSourcePoint)
            Me.Controls.Add(Me._gbDestinationRectangle)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AlphaBlendDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Alpha Blend"
            Me._gbDestinationRectangle.ResumeLayout(False)
            Me._gbDestinationRectangle.PerformLayout()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numY1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numX1, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbSourcePoint.ResumeLayout(False)
            Me._gbSourcePoint.PerformLayout()
            CType(Me._numY2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numX2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbOpacity, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numOpacity, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gb1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

	  #End Region

	  Private _gbDestinationRectangle As System.Windows.Forms.GroupBox
	  Private _gbSourcePoint As System.Windows.Forms.GroupBox
	  Private WithEvents _numHeight As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numY1 As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numWidth As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numX1 As System.Windows.Forms.NumericUpDown
	  Private _lblHeight As System.Windows.Forms.Label
	  Private _lblWidth As System.Windows.Forms.Label
	  Private _lblY1 As System.Windows.Forms.Label
	  Private _lblX1 As System.Windows.Forms.Label
	  Private WithEvents _numY2 As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numX2 As System.Windows.Forms.NumericUpDown
	  Private _lblY2 As System.Windows.Forms.Label
	  Private _lblX2 As System.Windows.Forms.Label
	  Private _lblOpacity As System.Windows.Forms.Label
	  Public WithEvents _tbOpacity As System.Windows.Forms.TrackBar
	  Private WithEvents _numOpacity As System.Windows.Forms.NumericUpDown
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gb1 As System.Windows.Forms.GroupBox
   End Class
End Namespace