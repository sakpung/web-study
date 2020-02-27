Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class CombineDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CombineDialog))
            Me._gbSourceRectangle = New System.Windows.Forms.GroupBox
            Me._cmbSourceRectangle = New System.Windows.Forms.ComboBox
            Me._gbDestinationRectangle = New System.Windows.Forms.GroupBox
            Me._cmbDestinationRectangle = New System.Windows.Forms.ComboBox
            Me._gbOperation = New System.Windows.Forms.GroupBox
            Me._cmbOperation = New System.Windows.Forms.ComboBox
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbResultImageRectangle = New System.Windows.Forms.GroupBox
            Me._cmbResultImageRectangle = New System.Windows.Forms.ComboBox
            Me.groupBox1 = New System.Windows.Forms.GroupBox
            Me._cmbSourceImageRectangle = New System.Windows.Forms.ComboBox
            Me._gbDestinationImageRectangle = New System.Windows.Forms.GroupBox
            Me._cmbDestinationImageRectangle = New System.Windows.Forms.ComboBox
            Me._gbChannelResultImageRectangle = New System.Windows.Forms.GroupBox
            Me._cmbChannelResultImageRectangle = New System.Windows.Forms.ComboBox
            Me._rbDestinationRectangle = New System.Windows.Forms.GroupBox
            Me._numHeight = New System.Windows.Forms.NumericUpDown
            Me._numWidth = New System.Windows.Forms.NumericUpDown
            Me._numY = New System.Windows.Forms.NumericUpDown
            Me._numX = New System.Windows.Forms.NumericUpDown
            Me._lblHeight = New System.Windows.Forms.Label
            Me._lblWidth = New System.Windows.Forms.Label
            Me._lblY = New System.Windows.Forms.Label
            Me._lblX = New System.Windows.Forms.Label
            Me._gbSourcePoint = New System.Windows.Forms.GroupBox
            Me._numPointY = New System.Windows.Forms.NumericUpDown
            Me._numPointX = New System.Windows.Forms.NumericUpDown
            Me._lblPointY = New System.Windows.Forms.Label
            Me._lblPointX = New System.Windows.Forms.Label
            Me._gbSourceRectangle.SuspendLayout()
            Me._gbDestinationRectangle.SuspendLayout()
            Me._gbOperation.SuspendLayout()
            Me._gbResultImageRectangle.SuspendLayout()
            Me.groupBox1.SuspendLayout()
            Me._gbDestinationImageRectangle.SuspendLayout()
            Me._gbChannelResultImageRectangle.SuspendLayout()
            Me._rbDestinationRectangle.SuspendLayout()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numY, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numX, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbSourcePoint.SuspendLayout()
            CType(Me._numPointY, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numPointX, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbSourceRectangle
            '
            Me._gbSourceRectangle.Controls.Add(Me._cmbSourceRectangle)
            Me._gbSourceRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbSourceRectangle.Location = New System.Drawing.Point(10, 161)
            Me._gbSourceRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSourceRectangle.Name = "_gbSourceRectangle"
            Me._gbSourceRectangle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSourceRectangle.Size = New System.Drawing.Size(183, 53)
            Me._gbSourceRectangle.TabIndex = 0
            Me._gbSourceRectangle.TabStop = False
            Me._gbSourceRectangle.Text = "Source Rectangle"
            '
            '_cmbSourceRectangle
            '
            Me._cmbSourceRectangle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbSourceRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbSourceRectangle.FormattingEnabled = True
            Me._cmbSourceRectangle.Location = New System.Drawing.Point(5, 19)
            Me._cmbSourceRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbSourceRectangle.Name = "_cmbSourceRectangle"
            Me._cmbSourceRectangle.Size = New System.Drawing.Size(173, 21)
            Me._cmbSourceRectangle.TabIndex = 0
            '
            '_gbDestinationRectangle
            '
            Me._gbDestinationRectangle.Controls.Add(Me._cmbDestinationRectangle)
            Me._gbDestinationRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbDestinationRectangle.Location = New System.Drawing.Point(198, 161)
            Me._gbDestinationRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDestinationRectangle.Name = "_gbDestinationRectangle"
            Me._gbDestinationRectangle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDestinationRectangle.Size = New System.Drawing.Size(198, 53)
            Me._gbDestinationRectangle.TabIndex = 1
            Me._gbDestinationRectangle.TabStop = False
            Me._gbDestinationRectangle.Text = "Destination Rectangle"
            '
            '_cmbDestinationRectangle
            '
            Me._cmbDestinationRectangle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbDestinationRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbDestinationRectangle.FormattingEnabled = True
            Me._cmbDestinationRectangle.Location = New System.Drawing.Point(5, 19)
            Me._cmbDestinationRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbDestinationRectangle.Name = "_cmbDestinationRectangle"
            Me._cmbDestinationRectangle.Size = New System.Drawing.Size(188, 21)
            Me._cmbDestinationRectangle.TabIndex = 0
            '
            '_gbOperation
            '
            Me._gbOperation.Controls.Add(Me._cmbOperation)
            Me._gbOperation.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbOperation.Location = New System.Drawing.Point(11, 219)
            Me._gbOperation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOperation.Name = "_gbOperation"
            Me._gbOperation.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOperation.Size = New System.Drawing.Size(183, 53)
            Me._gbOperation.TabIndex = 2
            Me._gbOperation.TabStop = False
            Me._gbOperation.Text = "Operation"
            '
            '_cmbOperation
            '
            Me._cmbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbOperation.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbOperation.FormattingEnabled = True
            Me._cmbOperation.Location = New System.Drawing.Point(5, 19)
            Me._cmbOperation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbOperation.Name = "_cmbOperation"
            Me._cmbOperation.Size = New System.Drawing.Size(172, 21)
            Me._cmbOperation.TabIndex = 0
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(310, 41)
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
            Me._btnOk.Location = New System.Drawing.Point(310, 10)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(86, 27)
            Me._btnOk.TabIndex = 6
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_gbResultImageRectangle
            '
            Me._gbResultImageRectangle.Controls.Add(Me._cmbResultImageRectangle)
            Me._gbResultImageRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbResultImageRectangle.Location = New System.Drawing.Point(203, 219)
            Me._gbResultImageRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbResultImageRectangle.Name = "_gbResultImageRectangle"
            Me._gbResultImageRectangle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbResultImageRectangle.Size = New System.Drawing.Size(193, 53)
            Me._gbResultImageRectangle.TabIndex = 8
            Me._gbResultImageRectangle.TabStop = False
            Me._gbResultImageRectangle.Text = "Result Image Rectangle"
            '
            '_cmbResultImageRectangle
            '
            Me._cmbResultImageRectangle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbResultImageRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbResultImageRectangle.FormattingEnabled = True
            Me._cmbResultImageRectangle.Location = New System.Drawing.Point(5, 19)
            Me._cmbResultImageRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbResultImageRectangle.Name = "_cmbResultImageRectangle"
            Me._cmbResultImageRectangle.Size = New System.Drawing.Size(183, 21)
            Me._cmbResultImageRectangle.TabIndex = 0
            '
            'groupBox1
            '
            Me.groupBox1.Controls.Add(Me._cmbSourceImageRectangle)
            Me.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.groupBox1.Location = New System.Drawing.Point(11, 284)
            Me.groupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.groupBox1.Size = New System.Drawing.Size(183, 53)
            Me.groupBox1.TabIndex = 9
            Me.groupBox1.TabStop = False
            Me.groupBox1.Text = "Channel of the source image"
            '
            '_cmbSourceImageRectangle
            '
            Me._cmbSourceImageRectangle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbSourceImageRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbSourceImageRectangle.FormattingEnabled = True
            Me._cmbSourceImageRectangle.Location = New System.Drawing.Point(5, 19)
            Me._cmbSourceImageRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbSourceImageRectangle.Name = "_cmbSourceImageRectangle"
            Me._cmbSourceImageRectangle.Size = New System.Drawing.Size(172, 21)
            Me._cmbSourceImageRectangle.TabIndex = 0
            '
            '_gbDestinationImageRectangle
            '
            Me._gbDestinationImageRectangle.Controls.Add(Me._cmbDestinationImageRectangle)
            Me._gbDestinationImageRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbDestinationImageRectangle.Location = New System.Drawing.Point(203, 284)
            Me._gbDestinationImageRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDestinationImageRectangle.Name = "_gbDestinationImageRectangle"
            Me._gbDestinationImageRectangle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDestinationImageRectangle.Size = New System.Drawing.Size(193, 53)
            Me._gbDestinationImageRectangle.TabIndex = 10
            Me._gbDestinationImageRectangle.TabStop = False
            Me._gbDestinationImageRectangle.Text = "Channel of the destination image"
            '
            '_cmbDestinationImageRectangle
            '
            Me._cmbDestinationImageRectangle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbDestinationImageRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbDestinationImageRectangle.FormattingEnabled = True
            Me._cmbDestinationImageRectangle.Location = New System.Drawing.Point(5, 19)
            Me._cmbDestinationImageRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbDestinationImageRectangle.Name = "_cmbDestinationImageRectangle"
            Me._cmbDestinationImageRectangle.Size = New System.Drawing.Size(183, 21)
            Me._cmbDestinationImageRectangle.TabIndex = 0
            '
            '_gbChannelResultImageRectangle
            '
            Me._gbChannelResultImageRectangle.Controls.Add(Me._cmbChannelResultImageRectangle)
            Me._gbChannelResultImageRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbChannelResultImageRectangle.Location = New System.Drawing.Point(11, 349)
            Me._gbChannelResultImageRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbChannelResultImageRectangle.Name = "_gbChannelResultImageRectangle"
            Me._gbChannelResultImageRectangle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbChannelResultImageRectangle.Size = New System.Drawing.Size(385, 53)
            Me._gbChannelResultImageRectangle.TabIndex = 11
            Me._gbChannelResultImageRectangle.TabStop = False
            Me._gbChannelResultImageRectangle.Text = "Channel of the resulting image"
            '
            '_cmbChannelResultImageRectangle
            '
            Me._cmbChannelResultImageRectangle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbChannelResultImageRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbChannelResultImageRectangle.FormattingEnabled = True
            Me._cmbChannelResultImageRectangle.Location = New System.Drawing.Point(11, 19)
            Me._cmbChannelResultImageRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbChannelResultImageRectangle.Name = "_cmbChannelResultImageRectangle"
            Me._cmbChannelResultImageRectangle.Size = New System.Drawing.Size(369, 21)
            Me._cmbChannelResultImageRectangle.TabIndex = 0
            '
            '_rbDestinationRectangle
            '
            Me._rbDestinationRectangle.Controls.Add(Me._numHeight)
            Me._rbDestinationRectangle.Controls.Add(Me._numWidth)
            Me._rbDestinationRectangle.Controls.Add(Me._numY)
            Me._rbDestinationRectangle.Controls.Add(Me._numX)
            Me._rbDestinationRectangle.Controls.Add(Me._lblHeight)
            Me._rbDestinationRectangle.Controls.Add(Me._lblWidth)
            Me._rbDestinationRectangle.Controls.Add(Me._lblY)
            Me._rbDestinationRectangle.Controls.Add(Me._lblX)
            Me._rbDestinationRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbDestinationRectangle.Location = New System.Drawing.Point(10, 10)
            Me._rbDestinationRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbDestinationRectangle.Name = "_rbDestinationRectangle"
            Me._rbDestinationRectangle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbDestinationRectangle.Size = New System.Drawing.Size(263, 89)
            Me._rbDestinationRectangle.TabIndex = 12
            Me._rbDestinationRectangle.TabStop = False
            Me._rbDestinationRectangle.Text = "Destination Rectangle"
            '
            '_numHeight
            '
            Me._numHeight.Location = New System.Drawing.Point(188, 58)
            Me._numHeight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numHeight.Name = "_numHeight"
            Me._numHeight.Size = New System.Drawing.Size(65, 20)
            Me._numHeight.TabIndex = 7
            Me._numHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_numWidth
            '
            Me._numWidth.Location = New System.Drawing.Point(188, 19)
            Me._numWidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numWidth.Name = "_numWidth"
            Me._numWidth.Size = New System.Drawing.Size(65, 20)
            Me._numWidth.TabIndex = 6
            Me._numWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_numY
            '
            Me._numY.Location = New System.Drawing.Point(29, 58)
            Me._numY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numY.Name = "_numY"
            Me._numY.Size = New System.Drawing.Size(65, 20)
            Me._numY.TabIndex = 5
            '
            '_numX
            '
            Me._numX.Location = New System.Drawing.Point(29, 19)
            Me._numX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numX.Name = "_numX"
            Me._numX.Size = New System.Drawing.Size(65, 20)
            Me._numX.TabIndex = 4
            '
            '_lblHeight
            '
            Me._lblHeight.AutoSize = True
            Me._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblHeight.Location = New System.Drawing.Point(144, 64)
            Me._lblHeight.Name = "_lblHeight"
            Me._lblHeight.Size = New System.Drawing.Size(38, 13)
            Me._lblHeight.TabIndex = 3
            Me._lblHeight.Text = "Height"
            '
            '_lblWidth
            '
            Me._lblWidth.AutoSize = True
            Me._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblWidth.Location = New System.Drawing.Point(144, 20)
            Me._lblWidth.Name = "_lblWidth"
            Me._lblWidth.Size = New System.Drawing.Size(35, 13)
            Me._lblWidth.TabIndex = 2
            Me._lblWidth.Text = "Width"
            '
            '_lblY
            '
            Me._lblY.AutoSize = True
            Me._lblY.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblY.Location = New System.Drawing.Point(10, 64)
            Me._lblY.Name = "_lblY"
            Me._lblY.Size = New System.Drawing.Size(14, 13)
            Me._lblY.TabIndex = 1
            Me._lblY.Text = "Y"
            '
            '_lblX
            '
            Me._lblX.AutoSize = True
            Me._lblX.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblX.Location = New System.Drawing.Point(10, 20)
            Me._lblX.Name = "_lblX"
            Me._lblX.Size = New System.Drawing.Size(14, 13)
            Me._lblX.TabIndex = 0
            Me._lblX.Text = "X"
            '
            '_gbSourcePoint
            '
            Me._gbSourcePoint.Controls.Add(Me._numPointY)
            Me._gbSourcePoint.Controls.Add(Me._numPointX)
            Me._gbSourcePoint.Controls.Add(Me._lblPointY)
            Me._gbSourcePoint.Controls.Add(Me._lblPointX)
            Me._gbSourcePoint.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbSourcePoint.Location = New System.Drawing.Point(11, 104)
            Me._gbSourcePoint.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSourcePoint.Name = "_gbSourcePoint"
            Me._gbSourcePoint.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbSourcePoint.Size = New System.Drawing.Size(262, 52)
            Me._gbSourcePoint.TabIndex = 13
            Me._gbSourcePoint.TabStop = False
            Me._gbSourcePoint.Text = "Source Point"
            '
            '_numPointY
            '
            Me._numPointY.Location = New System.Drawing.Point(187, 21)
            Me._numPointY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numPointY.Name = "_numPointY"
            Me._numPointY.Size = New System.Drawing.Size(59, 20)
            Me._numPointY.TabIndex = 3
            '
            '_numPointX
            '
            Me._numPointX.Location = New System.Drawing.Point(58, 21)
            Me._numPointX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numPointX.Name = "_numPointX"
            Me._numPointX.Size = New System.Drawing.Size(59, 20)
            Me._numPointX.TabIndex = 2
            '
            '_lblPointY
            '
            Me._lblPointY.AutoSize = True
            Me._lblPointY.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblPointY.Location = New System.Drawing.Point(143, 24)
            Me._lblPointY.Name = "_lblPointY"
            Me._lblPointY.Size = New System.Drawing.Size(41, 13)
            Me._lblPointY.TabIndex = 1
            Me._lblPointY.Text = "Point Y"
            '
            '_lblPointX
            '
            Me._lblPointX.AutoSize = True
            Me._lblPointX.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblPointX.Location = New System.Drawing.Point(9, 24)
            Me._lblPointX.Name = "_lblPointX"
            Me._lblPointX.Size = New System.Drawing.Size(41, 13)
            Me._lblPointX.TabIndex = 0
            Me._lblPointX.Text = "Point X"
            '
            'CombineDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(402, 412)
            Me.Controls.Add(Me._gbSourcePoint)
            Me.Controls.Add(Me._rbDestinationRectangle)
            Me.Controls.Add(Me._gbChannelResultImageRectangle)
            Me.Controls.Add(Me._gbDestinationImageRectangle)
            Me.Controls.Add(Me.groupBox1)
            Me.Controls.Add(Me._gbResultImageRectangle)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbOperation)
            Me.Controls.Add(Me._gbDestinationRectangle)
            Me.Controls.Add(Me._gbSourceRectangle)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "CombineDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "CombineDialog"
            Me._gbSourceRectangle.ResumeLayout(False)
            Me._gbDestinationRectangle.ResumeLayout(False)
            Me._gbOperation.ResumeLayout(False)
            Me._gbResultImageRectangle.ResumeLayout(False)
            Me.groupBox1.ResumeLayout(False)
            Me._gbDestinationImageRectangle.ResumeLayout(False)
            Me._gbChannelResultImageRectangle.ResumeLayout(False)
            Me._rbDestinationRectangle.ResumeLayout(False)
            Me._rbDestinationRectangle.PerformLayout()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numY, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numX, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbSourcePoint.ResumeLayout(False)
            Me._gbSourcePoint.PerformLayout()
            CType(Me._numPointY, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numPointX, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbSourceRectangle As System.Windows.Forms.GroupBox
	  Private _cmbSourceRectangle As System.Windows.Forms.ComboBox
	  Private _gbDestinationRectangle As System.Windows.Forms.GroupBox
	  Private _cmbDestinationRectangle As System.Windows.Forms.ComboBox
	  Private _gbOperation As System.Windows.Forms.GroupBox
	  Private _cmbOperation As System.Windows.Forms.ComboBox
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbResultImageRectangle As System.Windows.Forms.GroupBox
	  Private _cmbResultImageRectangle As System.Windows.Forms.ComboBox
	  Private groupBox1 As System.Windows.Forms.GroupBox
	  Private _cmbSourceImageRectangle As System.Windows.Forms.ComboBox
	  Private _gbDestinationImageRectangle As System.Windows.Forms.GroupBox
	  Private _cmbDestinationImageRectangle As System.Windows.Forms.ComboBox
	  Private _gbChannelResultImageRectangle As System.Windows.Forms.GroupBox
	  Private _cmbChannelResultImageRectangle As System.Windows.Forms.ComboBox
	  Private _rbDestinationRectangle As System.Windows.Forms.GroupBox
	  Private WithEvents _numHeight As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numWidth As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numY As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numX As System.Windows.Forms.NumericUpDown
	  Private _lblHeight As System.Windows.Forms.Label
	  Private _lblWidth As System.Windows.Forms.Label
	  Private _lblY As System.Windows.Forms.Label
	  Private _lblX As System.Windows.Forms.Label
	  Private _gbSourcePoint As System.Windows.Forms.GroupBox
	  Private WithEvents _numPointY As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numPointX As System.Windows.Forms.NumericUpDown
	  Private _lblPointY As System.Windows.Forms.Label
	  Private _lblPointX As System.Windows.Forms.Label
   End Class
End Namespace