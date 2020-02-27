Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class LocalHistogramEqualizeDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LocalHistogramEqualizeDialog))
            Me._lblColorSpace = New System.Windows.Forms.Label
            Me._cmbColorSpace = New System.Windows.Forms.ComboBox
            Me._gbParameter = New System.Windows.Forms.GroupBox
            Me._numSmooth = New System.Windows.Forms.NumericUpDown
            Me._lblSmooth = New System.Windows.Forms.Label
            Me._tbSmooth = New System.Windows.Forms.TrackBar
            Me._numHeightExtension = New System.Windows.Forms.NumericUpDown
            Me._lblHeightExtension = New System.Windows.Forms.Label
            Me._tbHeightExtension = New System.Windows.Forms.TrackBar
            Me._numWidthExtension = New System.Windows.Forms.NumericUpDown
            Me._lblWidthExtension = New System.Windows.Forms.Label
            Me._tbWidthExtension = New System.Windows.Forms.TrackBar
            Me._numHeight = New System.Windows.Forms.NumericUpDown
            Me._lblHeight = New System.Windows.Forms.Label
            Me._tbHeight = New System.Windows.Forms.TrackBar
            Me._numWidth = New System.Windows.Forms.NumericUpDown
            Me._lblWidth = New System.Windows.Forms.Label
            Me._tbWidth = New System.Windows.Forms.TrackBar
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbParameter.SuspendLayout()
            CType(Me._numSmooth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbSmooth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numHeightExtension, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbHeightExtension, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numWidthExtension, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbWidthExtension, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbHeight, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbWidth, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_lblColorSpace
            '
            Me._lblColorSpace.AutoSize = True
            Me._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblColorSpace.Location = New System.Drawing.Point(69, 20)
            Me._lblColorSpace.Name = "_lblColorSpace"
            Me._lblColorSpace.Size = New System.Drawing.Size(65, 13)
            Me._lblColorSpace.TabIndex = 0
            Me._lblColorSpace.Text = "Color Space"
            '
            '_cmbColorSpace
            '
            Me._cmbColorSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbColorSpace.FormattingEnabled = True
            Me._cmbColorSpace.Location = New System.Drawing.Point(143, 20)
            Me._cmbColorSpace.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbColorSpace.Name = "_cmbColorSpace"
            Me._cmbColorSpace.Size = New System.Drawing.Size(176, 21)
            Me._cmbColorSpace.TabIndex = 1
            '
            '_gbParameter
            '
            Me._gbParameter.Controls.Add(Me._numSmooth)
            Me._gbParameter.Controls.Add(Me._lblSmooth)
            Me._gbParameter.Controls.Add(Me._tbSmooth)
            Me._gbParameter.Controls.Add(Me._numHeightExtension)
            Me._gbParameter.Controls.Add(Me._lblHeightExtension)
            Me._gbParameter.Controls.Add(Me._tbHeightExtension)
            Me._gbParameter.Controls.Add(Me._numWidthExtension)
            Me._gbParameter.Controls.Add(Me._lblWidthExtension)
            Me._gbParameter.Controls.Add(Me._tbWidthExtension)
            Me._gbParameter.Controls.Add(Me._numHeight)
            Me._gbParameter.Controls.Add(Me._lblHeight)
            Me._gbParameter.Controls.Add(Me._tbHeight)
            Me._gbParameter.Controls.Add(Me._numWidth)
            Me._gbParameter.Controls.Add(Me._lblWidth)
            Me._gbParameter.Controls.Add(Me._tbWidth)
            Me._gbParameter.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbParameter.Location = New System.Drawing.Point(21, 54)
            Me._gbParameter.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbParameter.Name = "_gbParameter"
            Me._gbParameter.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbParameter.Size = New System.Drawing.Size(363, 261)
            Me._gbParameter.TabIndex = 2
            Me._gbParameter.TabStop = False
            Me._gbParameter.Text = "Parameter"
            '
            '_numSmooth
            '
            Me._numSmooth.Location = New System.Drawing.Point(298, 198)
            Me._numSmooth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numSmooth.Name = "_numSmooth"
            Me._numSmooth.Size = New System.Drawing.Size(60, 20)
            Me._numSmooth.TabIndex = 14
            '
            '_lblSmooth
            '
            Me._lblSmooth.AutoSize = True
            Me._lblSmooth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblSmooth.Location = New System.Drawing.Point(12, 198)
            Me._lblSmooth.Name = "_lblSmooth"
            Me._lblSmooth.Size = New System.Drawing.Size(43, 13)
            Me._lblSmooth.TabIndex = 13
            Me._lblSmooth.Text = "Smooth"
            '
            '_tbSmooth
            '
            Me._tbSmooth.Location = New System.Drawing.Point(5, 214)
            Me._tbSmooth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbSmooth.Maximum = 7
            Me._tbSmooth.Name = "_tbSmooth"
            Me._tbSmooth.Size = New System.Drawing.Size(353, 45)
            Me._tbSmooth.TabIndex = 12
            Me._tbSmooth.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_numHeightExtension
            '
            Me._numHeightExtension.Location = New System.Drawing.Point(298, 153)
            Me._numHeightExtension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numHeightExtension.Name = "_numHeightExtension"
            Me._numHeightExtension.Size = New System.Drawing.Size(60, 20)
            Me._numHeightExtension.TabIndex = 11
            '
            '_lblHeightExtension
            '
            Me._lblHeightExtension.AutoSize = True
            Me._lblHeightExtension.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblHeightExtension.Location = New System.Drawing.Point(12, 153)
            Me._lblHeightExtension.Name = "_lblHeightExtension"
            Me._lblHeightExtension.Size = New System.Drawing.Size(90, 13)
            Me._lblHeightExtension.TabIndex = 10
            Me._lblHeightExtension.Text = "Height Extension "
            '
            '_tbHeightExtension
            '
            Me._tbHeightExtension.Location = New System.Drawing.Point(5, 169)
            Me._tbHeightExtension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbHeightExtension.Name = "_tbHeightExtension"
            Me._tbHeightExtension.Size = New System.Drawing.Size(353, 45)
            Me._tbHeightExtension.TabIndex = 9
            Me._tbHeightExtension.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_numWidthExtension
            '
            Me._numWidthExtension.Location = New System.Drawing.Point(298, 107)
            Me._numWidthExtension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numWidthExtension.Name = "_numWidthExtension"
            Me._numWidthExtension.Size = New System.Drawing.Size(60, 20)
            Me._numWidthExtension.TabIndex = 8
            '
            '_lblWidthExtension
            '
            Me._lblWidthExtension.AutoSize = True
            Me._lblWidthExtension.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblWidthExtension.Location = New System.Drawing.Point(12, 107)
            Me._lblWidthExtension.Name = "_lblWidthExtension"
            Me._lblWidthExtension.Size = New System.Drawing.Size(84, 13)
            Me._lblWidthExtension.TabIndex = 7
            Me._lblWidthExtension.Text = "Width Extension"
            '
            '_tbWidthExtension
            '
            Me._tbWidthExtension.Location = New System.Drawing.Point(5, 124)
            Me._tbWidthExtension.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbWidthExtension.Name = "_tbWidthExtension"
            Me._tbWidthExtension.Size = New System.Drawing.Size(353, 45)
            Me._tbWidthExtension.TabIndex = 6
            Me._tbWidthExtension.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_numHeight
            '
            Me._numHeight.Location = New System.Drawing.Point(298, 62)
            Me._numHeight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numHeight.Name = "_numHeight"
            Me._numHeight.Size = New System.Drawing.Size(60, 20)
            Me._numHeight.TabIndex = 5
            Me._numHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_lblHeight
            '
            Me._lblHeight.AutoSize = True
            Me._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblHeight.Location = New System.Drawing.Point(12, 62)
            Me._lblHeight.Name = "_lblHeight"
            Me._lblHeight.Size = New System.Drawing.Size(38, 13)
            Me._lblHeight.TabIndex = 4
            Me._lblHeight.Text = "Height"
            '
            '_tbHeight
            '
            Me._tbHeight.Location = New System.Drawing.Point(5, 78)
            Me._tbHeight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbHeight.Minimum = 1
            Me._tbHeight.Name = "_tbHeight"
            Me._tbHeight.Size = New System.Drawing.Size(353, 45)
            Me._tbHeight.TabIndex = 3
            Me._tbHeight.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbHeight.Value = 1
            '
            '_numWidth
            '
            Me._numWidth.Location = New System.Drawing.Point(298, 16)
            Me._numWidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numWidth.Name = "_numWidth"
            Me._numWidth.Size = New System.Drawing.Size(60, 20)
            Me._numWidth.TabIndex = 2
            Me._numWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_lblWidth
            '
            Me._lblWidth.AutoSize = True
            Me._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblWidth.Location = New System.Drawing.Point(12, 16)
            Me._lblWidth.Name = "_lblWidth"
            Me._lblWidth.Size = New System.Drawing.Size(35, 13)
            Me._lblWidth.TabIndex = 1
            Me._lblWidth.Text = "Width"
            '
            '_tbWidth
            '
            Me._tbWidth.Location = New System.Drawing.Point(5, 32)
            Me._tbWidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbWidth.Minimum = 1
            Me._tbWidth.Name = "_tbWidth"
            Me._tbWidth.Size = New System.Drawing.Size(353, 45)
            Me._tbWidth.TabIndex = 0
            Me._tbWidth.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbWidth.Value = 1
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(94, 319)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(68, 22)
            Me._btnCancel.TabIndex = 5
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(21, 319)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(68, 22)
            Me._btnOk.TabIndex = 4
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'LocalHistogramEqualizeDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(415, 355)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbParameter)
            Me.Controls.Add(Me._cmbColorSpace)
            Me.Controls.Add(Me._lblColorSpace)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "LocalHistogramEqualizeDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Local Histogram Equalize"
            Me._gbParameter.ResumeLayout(False)
            Me._gbParameter.PerformLayout()
            CType(Me._numSmooth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbSmooth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numHeightExtension, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbHeightExtension, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numWidthExtension, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbWidthExtension, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbHeight, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbWidth, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

	  #End Region

	  Private _lblColorSpace As System.Windows.Forms.Label
	  Private _cmbColorSpace As System.Windows.Forms.ComboBox
	  Private _gbParameter As System.Windows.Forms.GroupBox
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _numWidth As System.Windows.Forms.NumericUpDown
	  Private _lblWidth As System.Windows.Forms.Label
	  Public WithEvents _tbWidth As System.Windows.Forms.TrackBar
	  Private WithEvents _numHeight As System.Windows.Forms.NumericUpDown
	  Private _lblHeight As System.Windows.Forms.Label
	  Public WithEvents _tbHeight As System.Windows.Forms.TrackBar
	  Private WithEvents _numSmooth As System.Windows.Forms.NumericUpDown
	  Private _lblSmooth As System.Windows.Forms.Label
	  Public WithEvents _tbSmooth As System.Windows.Forms.TrackBar
	  Private WithEvents _numHeightExtension As System.Windows.Forms.NumericUpDown
	  Private _lblHeightExtension As System.Windows.Forms.Label
	  Public WithEvents _tbHeightExtension As System.Windows.Forms.TrackBar
	  Private WithEvents _numWidthExtension As System.Windows.Forms.NumericUpDown
	  Private _lblWidthExtension As System.Windows.Forms.Label
	  Public WithEvents _tbWidthExtension As System.Windows.Forms.TrackBar
   End Class
End Namespace