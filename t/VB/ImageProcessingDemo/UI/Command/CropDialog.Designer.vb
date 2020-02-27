Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class CropDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CropDialog))
            Me._gbRectangle = New System.Windows.Forms.GroupBox
            Me._numHeight = New System.Windows.Forms.NumericUpDown
            Me._numWidth = New System.Windows.Forms.NumericUpDown
            Me._numY = New System.Windows.Forms.NumericUpDown
            Me._numX = New System.Windows.Forms.NumericUpDown
            Me._lblHeight = New System.Windows.Forms.Label
            Me._lblWidth = New System.Windows.Forms.Label
            Me._lblY = New System.Windows.Forms.Label
            Me._lblX = New System.Windows.Forms.Label
            Me._btnOk = New System.Windows.Forms.Button
            Me._btnCancel = New System.Windows.Forms.Button
            Me._gbRectangle.SuspendLayout()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numY, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numX, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbRectangle
            '
            Me._gbRectangle.Controls.Add(Me._numHeight)
            Me._gbRectangle.Controls.Add(Me._numWidth)
            Me._gbRectangle.Controls.Add(Me._numY)
            Me._gbRectangle.Controls.Add(Me._numX)
            Me._gbRectangle.Controls.Add(Me._lblHeight)
            Me._gbRectangle.Controls.Add(Me._lblWidth)
            Me._gbRectangle.Controls.Add(Me._lblY)
            Me._gbRectangle.Controls.Add(Me._lblX)
            Me._gbRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbRectangle.Location = New System.Drawing.Point(3, 3)
            Me._gbRectangle.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRectangle.Name = "_gbRectangle"
            Me._gbRectangle.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRectangle.Size = New System.Drawing.Size(148, 136)
            Me._gbRectangle.TabIndex = 0
            Me._gbRectangle.TabStop = False
            Me._gbRectangle.Text = "Crop Rectangle"
            '
            '_numHeight
            '
            Me._numHeight.Location = New System.Drawing.Point(49, 102)
            Me._numHeight.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numHeight.Name = "_numHeight"
            Me._numHeight.Size = New System.Drawing.Size(67, 20)
            Me._numHeight.TabIndex = 7
            Me._numHeight.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_numWidth
            '
            Me._numWidth.Location = New System.Drawing.Point(49, 76)
            Me._numWidth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me._numWidth.Name = "_numWidth"
            Me._numWidth.Size = New System.Drawing.Size(67, 20)
            Me._numWidth.TabIndex = 6
            Me._numWidth.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            '_numY
            '
            Me._numY.Location = New System.Drawing.Point(49, 43)
            Me._numY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numY.Name = "_numY"
            Me._numY.Size = New System.Drawing.Size(67, 20)
            Me._numY.TabIndex = 5
            '
            '_numX
            '
            Me._numX.Location = New System.Drawing.Point(49, 20)
            Me._numX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numX.Name = "_numX"
            Me._numX.Size = New System.Drawing.Size(67, 20)
            Me._numX.TabIndex = 4
            '
            '_lblHeight
            '
            Me._lblHeight.AutoSize = True
            Me._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblHeight.Location = New System.Drawing.Point(5, 104)
            Me._lblHeight.Name = "_lblHeight"
            Me._lblHeight.Size = New System.Drawing.Size(41, 13)
            Me._lblHeight.TabIndex = 3
            Me._lblHeight.Text = "Height "
            '
            '_lblWidth
            '
            Me._lblWidth.AutoSize = True
            Me._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblWidth.Location = New System.Drawing.Point(5, 78)
            Me._lblWidth.Name = "_lblWidth"
            Me._lblWidth.Size = New System.Drawing.Size(35, 13)
            Me._lblWidth.TabIndex = 2
            Me._lblWidth.Text = "Width"
            '
            '_lblY
            '
            Me._lblY.AutoSize = True
            Me._lblY.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblY.Location = New System.Drawing.Point(16, 50)
            Me._lblY.Name = "_lblY"
            Me._lblY.Size = New System.Drawing.Size(14, 13)
            Me._lblY.TabIndex = 1
            Me._lblY.Text = "Y"
            '
            '_lblX
            '
            Me._lblX.AutoSize = True
            Me._lblX.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblX.Location = New System.Drawing.Point(16, 20)
            Me._lblX.Name = "_lblX"
            Me._lblX.Size = New System.Drawing.Size(14, 13)
            Me._lblX.TabIndex = 0
            Me._lblX.Text = "X"
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(157, 10)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(72, 28)
            Me._btnOk.TabIndex = 1
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(157, 42)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(72, 28)
            Me._btnCancel.TabIndex = 2
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            'CropDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(235, 146)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbRectangle)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "CropDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Crop"
            Me._gbRectangle.ResumeLayout(False)
            Me._gbRectangle.PerformLayout()
            CType(Me._numHeight, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numWidth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numY, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numX, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbRectangle As System.Windows.Forms.GroupBox
	  Private _lblHeight As System.Windows.Forms.Label
	  Private _lblWidth As System.Windows.Forms.Label
	  Private _lblY As System.Windows.Forms.Label
	  Private _lblX As System.Windows.Forms.Label
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _numHeight As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numWidth As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numY As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numX As System.Windows.Forms.NumericUpDown
   End Class
End Namespace