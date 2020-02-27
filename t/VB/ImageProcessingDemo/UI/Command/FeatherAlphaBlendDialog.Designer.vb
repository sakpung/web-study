Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class FeatherAlphaBlendDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FeatherAlphaBlendDialog))
            Me._gbDestinationRectangle = New System.Windows.Forms.GroupBox
            Me._numHeight = New System.Windows.Forms.NumericUpDown
            Me._numWidth = New System.Windows.Forms.NumericUpDown
            Me._numY = New System.Windows.Forms.NumericUpDown
            Me._numX = New System.Windows.Forms.NumericUpDown
            Me._lblWidth = New System.Windows.Forms.Label
            Me._lblHeight = New System.Windows.Forms.Label
            Me._lblY = New System.Windows.Forms.Label
            Me._lblX = New System.Windows.Forms.Label
            Me._gbSourcePoint = New System.Windows.Forms.GroupBox
            Me._numY1 = New System.Windows.Forms.NumericUpDown
            Me._numX1 = New System.Windows.Forms.NumericUpDown
            Me._lblY1 = New System.Windows.Forms.Label
            Me._lblPX1 = New System.Windows.Forms.Label
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbMaskSourcePoint = New System.Windows.Forms.GroupBox
            Me._numY2 = New System.Windows.Forms.NumericUpDown
            Me._numX2 = New System.Windows.Forms.NumericUpDown
            Me._lblY2 = New System.Windows.Forms.Label
            Me._lblX2 = New System.Windows.Forms.Label
            Me._gbDestinationRectangle.SuspendLayout()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numY, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numX, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbSourcePoint.SuspendLayout()
            CType(Me._numY1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numX1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbMaskSourcePoint.SuspendLayout()
            CType(Me._numY2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numX2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbDestinationRectangle
            '
            Me._gbDestinationRectangle.Controls.Add(Me._numHeight)
            Me._gbDestinationRectangle.Controls.Add(Me._numWidth)
            Me._gbDestinationRectangle.Controls.Add(Me._numY)
            Me._gbDestinationRectangle.Controls.Add(Me._numX)
            Me._gbDestinationRectangle.Controls.Add(Me._lblWidth)
            Me._gbDestinationRectangle.Controls.Add(Me._lblHeight)
            Me._gbDestinationRectangle.Controls.Add(Me._lblY)
            Me._gbDestinationRectangle.Controls.Add(Me._lblX)
            Me._gbDestinationRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbDestinationRectangle.Location = New System.Drawing.Point(10, 10)
            Me._gbDestinationRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDestinationRectangle.Name = "_gbDestinationRectangle"
            Me._gbDestinationRectangle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDestinationRectangle.Size = New System.Drawing.Size(331, 110)
            Me._gbDestinationRectangle.TabIndex = 0
            Me._gbDestinationRectangle.TabStop = False
            Me._gbDestinationRectangle.Text = "Destination Rectangle"
            '
            '_numHeight
            '
            Me._numHeight.Location = New System.Drawing.Point(229, 63)
            Me._numHeight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numHeight.Name = "_numHeight"
            Me._numHeight.Size = New System.Drawing.Size(76, 20)
            Me._numHeight.TabIndex = 7
            Me._numHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_numWidth
            '
            Me._numWidth.Location = New System.Drawing.Point(229, 25)
            Me._numWidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numWidth.Name = "_numWidth"
            Me._numWidth.Size = New System.Drawing.Size(76, 20)
            Me._numWidth.TabIndex = 6
            Me._numWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_numY
            '
            Me._numY.Location = New System.Drawing.Point(55, 63)
            Me._numY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numY.Name = "_numY"
            Me._numY.Size = New System.Drawing.Size(76, 20)
            Me._numY.TabIndex = 5
            '
            '_numX
            '
            Me._numX.Location = New System.Drawing.Point(55, 25)
            Me._numX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numX.Name = "_numX"
            Me._numX.Size = New System.Drawing.Size(76, 20)
            Me._numX.TabIndex = 4
            '
            '_lblWidth
            '
            Me._lblWidth.AutoSize = True
            Me._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblWidth.Location = New System.Drawing.Point(188, 31)
            Me._lblWidth.Name = "_lblWidth"
            Me._lblWidth.Size = New System.Drawing.Size(35, 13)
            Me._lblWidth.TabIndex = 3
            Me._lblWidth.Text = "Width"
            '
            '_lblHeight
            '
            Me._lblHeight.AutoSize = True
            Me._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblHeight.Location = New System.Drawing.Point(188, 64)
            Me._lblHeight.Name = "_lblHeight"
            Me._lblHeight.Size = New System.Drawing.Size(38, 13)
            Me._lblHeight.TabIndex = 2
            Me._lblHeight.Text = "Height"
            '
            '_lblY
            '
            Me._lblY.AutoSize = True
            Me._lblY.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblY.Location = New System.Drawing.Point(14, 64)
            Me._lblY.Name = "_lblY"
            Me._lblY.Size = New System.Drawing.Size(14, 13)
            Me._lblY.TabIndex = 1
            Me._lblY.Text = "Y"
            '
            '_lblX
            '
            Me._lblX.AutoSize = True
            Me._lblX.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblX.Location = New System.Drawing.Point(14, 31)
            Me._lblX.Name = "_lblX"
            Me._lblX.Size = New System.Drawing.Size(14, 13)
            Me._lblX.TabIndex = 0
            Me._lblX.Text = "X"
            '
            '_gbSourcePoint
            '
            Me._gbSourcePoint.Controls.Add(Me._numY1)
            Me._gbSourcePoint.Controls.Add(Me._numX1)
            Me._gbSourcePoint.Controls.Add(Me._lblY1)
            Me._gbSourcePoint.Controls.Add(Me._lblPX1)
            Me._gbSourcePoint.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbSourcePoint.Location = New System.Drawing.Point(10, 124)
            Me._gbSourcePoint.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSourcePoint.Name = "_gbSourcePoint"
            Me._gbSourcePoint.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSourcePoint.Size = New System.Drawing.Size(331, 50)
            Me._gbSourcePoint.TabIndex = 1
            Me._gbSourcePoint.TabStop = False
            Me._gbSourcePoint.Text = "Source Point"
            '
            '_numY1
            '
            Me._numY1.Location = New System.Drawing.Point(229, 20)
            Me._numY1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numY1.Name = "_numY1"
            Me._numY1.Size = New System.Drawing.Size(64, 20)
            Me._numY1.TabIndex = 3
            '
            '_numX1
            '
            Me._numX1.Location = New System.Drawing.Point(55, 20)
            Me._numX1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numX1.Name = "_numX1"
            Me._numX1.Size = New System.Drawing.Size(64, 20)
            Me._numX1.TabIndex = 2
            '
            '_lblY1
            '
            Me._lblY1.AutoSize = True
            Me._lblY1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblY1.Location = New System.Drawing.Point(188, 24)
            Me._lblY1.Name = "_lblY1"
            Me._lblY1.Size = New System.Drawing.Size(14, 13)
            Me._lblY1.TabIndex = 1
            Me._lblY1.Text = "Y"
            '
            '_lblPX1
            '
            Me._lblPX1.AutoSize = True
            Me._lblPX1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblPX1.Location = New System.Drawing.Point(14, 24)
            Me._lblPX1.Name = "_lblPX1"
            Me._lblPX1.Size = New System.Drawing.Size(14, 13)
            Me._lblPX1.TabIndex = 0
            Me._lblPX1.Text = "X"
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(357, 51)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(86, 27)
            Me._btnCancel.TabIndex = 7
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(357, 20)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(86, 27)
            Me._btnOk.TabIndex = 6
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_gbMaskSourcePoint
            '
            Me._gbMaskSourcePoint.Controls.Add(Me._numY2)
            Me._gbMaskSourcePoint.Controls.Add(Me._numX2)
            Me._gbMaskSourcePoint.Controls.Add(Me._lblY2)
            Me._gbMaskSourcePoint.Controls.Add(Me._lblX2)
            Me._gbMaskSourcePoint.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbMaskSourcePoint.Location = New System.Drawing.Point(10, 193)
            Me._gbMaskSourcePoint.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbMaskSourcePoint.Name = "_gbMaskSourcePoint"
            Me._gbMaskSourcePoint.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbMaskSourcePoint.Size = New System.Drawing.Size(331, 50)
            Me._gbMaskSourcePoint.TabIndex = 8
            Me._gbMaskSourcePoint.TabStop = False
            Me._gbMaskSourcePoint.Text = "Mask Source Point"
            '
            '_numY2
            '
            Me._numY2.Location = New System.Drawing.Point(229, 20)
            Me._numY2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numY2.Name = "_numY2"
            Me._numY2.Size = New System.Drawing.Size(64, 20)
            Me._numY2.TabIndex = 3
            '
            '_numX2
            '
            Me._numX2.Location = New System.Drawing.Point(55, 20)
            Me._numX2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numX2.Name = "_numX2"
            Me._numX2.Size = New System.Drawing.Size(64, 20)
            Me._numX2.TabIndex = 2
            '
            '_lblY2
            '
            Me._lblY2.AutoSize = True
            Me._lblY2.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblY2.Location = New System.Drawing.Point(188, 24)
            Me._lblY2.Name = "_lblY2"
            Me._lblY2.Size = New System.Drawing.Size(14, 13)
            Me._lblY2.TabIndex = 1
            Me._lblY2.Text = "Y"
            '
            '_lblX2
            '
            Me._lblX2.AutoSize = True
            Me._lblX2.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblX2.Location = New System.Drawing.Point(14, 24)
            Me._lblX2.Name = "_lblX2"
            Me._lblX2.Size = New System.Drawing.Size(14, 13)
            Me._lblX2.TabIndex = 0
            Me._lblX2.Text = "X"
            '
            'FeatherAlphaBlendDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(447, 253)
            Me.Controls.Add(Me._gbMaskSourcePoint)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbSourcePoint)
            Me.Controls.Add(Me._gbDestinationRectangle)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FeatherAlphaBlendDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Feather Alpha Blend"
            Me._gbDestinationRectangle.ResumeLayout(False)
            Me._gbDestinationRectangle.PerformLayout()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numY, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numX, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbSourcePoint.ResumeLayout(False)
            Me._gbSourcePoint.PerformLayout()
            CType(Me._numY1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numX1, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbMaskSourcePoint.ResumeLayout(False)
            Me._gbMaskSourcePoint.PerformLayout()
            CType(Me._numY2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numX2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbDestinationRectangle As System.Windows.Forms.GroupBox
	  Private _numHeight As System.Windows.Forms.NumericUpDown
	  Private _numWidth As System.Windows.Forms.NumericUpDown
	  Private _numY As System.Windows.Forms.NumericUpDown
	  Private _numX As System.Windows.Forms.NumericUpDown
	  Private _lblWidth As System.Windows.Forms.Label
	  Private _lblHeight As System.Windows.Forms.Label
	  Private _lblY As System.Windows.Forms.Label
	  Private _lblX As System.Windows.Forms.Label
	  Private _gbSourcePoint As System.Windows.Forms.GroupBox
	  Private _numY1 As System.Windows.Forms.NumericUpDown
	  Private _numX1 As System.Windows.Forms.NumericUpDown
	  Private _lblY1 As System.Windows.Forms.Label
	  Private _lblPX1 As System.Windows.Forms.Label
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbMaskSourcePoint As System.Windows.Forms.GroupBox
	  Private _numY2 As System.Windows.Forms.NumericUpDown
	  Private _numX2 As System.Windows.Forms.NumericUpDown
	  Private _lblY2 As System.Windows.Forms.Label
	  Private _lblX2 As System.Windows.Forms.Label
   End Class
End Namespace