Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class FastFourierTransformDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FastFourierTransformDialog))
            Me._gbOperationChannel = New System.Windows.Forms.GroupBox
            Me._rbGray = New System.Windows.Forms.RadioButton
            Me._rbRed = New System.Windows.Forms.RadioButton
            Me._rbGreen = New System.Windows.Forms.RadioButton
            Me._rbBlue = New System.Windows.Forms.RadioButton
            Me._gbFrequencyDataType = New System.Windows.Forms.GroupBox
            Me._rbBoth = New System.Windows.Forms.RadioButton
            Me._rbPhase = New System.Windows.Forms.RadioButton
            Me._rbMagnitude = New System.Windows.Forms.RadioButton
            Me._gbClippingType = New System.Windows.Forms.GroupBox
            Me._rbScale = New System.Windows.Forms.RadioButton
            Me._rbClip = New System.Windows.Forms.RadioButton
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbXFilter = New System.Windows.Forms.GroupBox
            Me._rbNoneX = New System.Windows.Forms.RadioButton
            Me._rbOutsideX = New System.Windows.Forms.RadioButton
            Me._rbInsideX = New System.Windows.Forms.RadioButton
            Me._gbYFilter = New System.Windows.Forms.GroupBox
            Me._rbNoneY = New System.Windows.Forms.RadioButton
            Me._rbInsideY = New System.Windows.Forms.RadioButton
            Me._rbOutsideY = New System.Windows.Forms.RadioButton
            Me._gbOperationChannel.SuspendLayout()
            Me._gbFrequencyDataType.SuspendLayout()
            Me._gbClippingType.SuspendLayout()
            Me._gbXFilter.SuspendLayout()
            Me._gbYFilter.SuspendLayout()
            Me.SuspendLayout()
            '
            '_gbOperationChannel
            '
            Me._gbOperationChannel.Controls.Add(Me._rbGray)
            Me._gbOperationChannel.Controls.Add(Me._rbRed)
            Me._gbOperationChannel.Controls.Add(Me._rbGreen)
            Me._gbOperationChannel.Controls.Add(Me._rbBlue)
            Me._gbOperationChannel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbOperationChannel.Location = New System.Drawing.Point(10, 128)
            Me._gbOperationChannel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOperationChannel.Name = "_gbOperationChannel"
            Me._gbOperationChannel.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOperationChannel.Size = New System.Drawing.Size(274, 89)
            Me._gbOperationChannel.TabIndex = 1
            Me._gbOperationChannel.TabStop = False
            Me._gbOperationChannel.Text = "Operation Channel"
            '
            '_rbGray
            '
            Me._rbGray.AutoSize = True
            Me._rbGray.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbGray.Location = New System.Drawing.Point(181, 50)
            Me._rbGray.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbGray.Name = "_rbGray"
            Me._rbGray.Size = New System.Drawing.Size(53, 18)
            Me._rbGray.TabIndex = 3
            Me._rbGray.TabStop = True
            Me._rbGray.Text = "Gray"
            Me._rbGray.UseVisualStyleBackColor = True
            '
            '_rbRed
            '
            Me._rbRed.AutoSize = True
            Me._rbRed.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbRed.Location = New System.Drawing.Point(18, 50)
            Me._rbRed.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbRed.Name = "_rbRed"
            Me._rbRed.Size = New System.Drawing.Size(51, 18)
            Me._rbRed.TabIndex = 2
            Me._rbRed.TabStop = True
            Me._rbRed.Text = "Red"
            Me._rbRed.UseVisualStyleBackColor = True
            '
            '_rbGreen
            '
            Me._rbGreen.AutoSize = True
            Me._rbGreen.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbGreen.Location = New System.Drawing.Point(181, 20)
            Me._rbGreen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbGreen.Name = "_rbGreen"
            Me._rbGreen.Size = New System.Drawing.Size(60, 18)
            Me._rbGreen.TabIndex = 1
            Me._rbGreen.TabStop = True
            Me._rbGreen.Text = "Green"
            Me._rbGreen.UseVisualStyleBackColor = True
            '
            '_rbBlue
            '
            Me._rbBlue.AutoSize = True
            Me._rbBlue.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbBlue.Location = New System.Drawing.Point(18, 20)
            Me._rbBlue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbBlue.Name = "_rbBlue"
            Me._rbBlue.Size = New System.Drawing.Size(52, 18)
            Me._rbBlue.TabIndex = 0
            Me._rbBlue.TabStop = True
            Me._rbBlue.Text = "Blue"
            Me._rbBlue.UseVisualStyleBackColor = True
            '
            '_gbFrequencyDataType
            '
            Me._gbFrequencyDataType.Controls.Add(Me._rbBoth)
            Me._gbFrequencyDataType.Controls.Add(Me._rbPhase)
            Me._gbFrequencyDataType.Controls.Add(Me._rbMagnitude)
            Me._gbFrequencyDataType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbFrequencyDataType.Location = New System.Drawing.Point(9, 227)
            Me._gbFrequencyDataType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbFrequencyDataType.Name = "_gbFrequencyDataType"
            Me._gbFrequencyDataType.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbFrequencyDataType.Size = New System.Drawing.Size(275, 84)
            Me._gbFrequencyDataType.TabIndex = 2
            Me._gbFrequencyDataType.TabStop = False
            Me._gbFrequencyDataType.Text = "Frequency Data Type"
            '
            '_rbBoth
            '
            Me._rbBoth.AutoSize = True
            Me._rbBoth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbBoth.Location = New System.Drawing.Point(102, 51)
            Me._rbBoth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbBoth.Name = "_rbBoth"
            Me._rbBoth.Size = New System.Drawing.Size(53, 18)
            Me._rbBoth.TabIndex = 2
            Me._rbBoth.TabStop = True
            Me._rbBoth.Text = "Both"
            Me._rbBoth.UseVisualStyleBackColor = True
            '
            '_rbPhase
            '
            Me._rbPhase.AutoSize = True
            Me._rbPhase.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbPhase.Location = New System.Drawing.Point(182, 28)
            Me._rbPhase.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbPhase.Name = "_rbPhase"
            Me._rbPhase.Size = New System.Drawing.Size(61, 18)
            Me._rbPhase.TabIndex = 1
            Me._rbPhase.TabStop = True
            Me._rbPhase.Text = "Phase"
            Me._rbPhase.UseVisualStyleBackColor = True
            '
            '_rbMagnitude
            '
            Me._rbMagnitude.AutoSize = True
            Me._rbMagnitude.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbMagnitude.Location = New System.Drawing.Point(19, 28)
            Me._rbMagnitude.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbMagnitude.Name = "_rbMagnitude"
            Me._rbMagnitude.Size = New System.Drawing.Size(81, 18)
            Me._rbMagnitude.TabIndex = 0
            Me._rbMagnitude.TabStop = True
            Me._rbMagnitude.Text = "Magnitude"
            Me._rbMagnitude.UseVisualStyleBackColor = True
            '
            '_gbClippingType
            '
            Me._gbClippingType.Controls.Add(Me._rbScale)
            Me._gbClippingType.Controls.Add(Me._rbClip)
            Me._gbClippingType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbClippingType.Location = New System.Drawing.Point(10, 315)
            Me._gbClippingType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbClippingType.Name = "_gbClippingType"
            Me._gbClippingType.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbClippingType.Size = New System.Drawing.Size(274, 61)
            Me._gbClippingType.TabIndex = 5
            Me._gbClippingType.TabStop = False
            Me._gbClippingType.Text = "Clipping Type"
            '
            '_rbScale
            '
            Me._rbScale.AutoSize = True
            Me._rbScale.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbScale.Location = New System.Drawing.Point(181, 31)
            Me._rbScale.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbScale.Name = "_rbScale"
            Me._rbScale.Size = New System.Drawing.Size(58, 18)
            Me._rbScale.TabIndex = 1
            Me._rbScale.TabStop = True
            Me._rbScale.Text = "Scale"
            Me._rbScale.UseVisualStyleBackColor = True
            '
            '_rbClip
            '
            Me._rbClip.AutoSize = True
            Me._rbClip.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbClip.Location = New System.Drawing.Point(18, 31)
            Me._rbClip.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbClip.Name = "_rbClip"
            Me._rbClip.Size = New System.Drawing.Size(48, 18)
            Me._rbClip.TabIndex = 0
            Me._rbClip.TabStop = True
            Me._rbClip.Text = "Clip"
            Me._rbClip.UseVisualStyleBackColor = True
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(290, 52)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(75, 23)
            Me._btnCancel.TabIndex = 11
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(290, 23)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(75, 23)
            Me._btnOk.TabIndex = 10
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_gbXFilter
            '
            Me._gbXFilter.Controls.Add(Me._rbNoneX)
            Me._gbXFilter.Controls.Add(Me._rbOutsideX)
            Me._gbXFilter.Controls.Add(Me._rbInsideX)
            Me._gbXFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbXFilter.Location = New System.Drawing.Point(10, 10)
            Me._gbXFilter.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbXFilter.Name = "_gbXFilter"
            Me._gbXFilter.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbXFilter.Size = New System.Drawing.Size(135, 113)
            Me._gbXFilter.TabIndex = 12
            Me._gbXFilter.TabStop = False
            Me._gbXFilter.Text = "X Filter"
            '
            '_rbNoneX
            '
            Me._rbNoneX.AutoSize = True
            Me._rbNoneX.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbNoneX.Location = New System.Drawing.Point(24, 86)
            Me._rbNoneX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbNoneX.Name = "_rbNoneX"
            Me._rbNoneX.Size = New System.Drawing.Size(57, 18)
            Me._rbNoneX.TabIndex = 2
            Me._rbNoneX.TabStop = True
            Me._rbNoneX.Text = "None"
            Me._rbNoneX.UseVisualStyleBackColor = True
            '
            '_rbOutsideX
            '
            Me._rbOutsideX.AutoSize = True
            Me._rbOutsideX.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbOutsideX.Location = New System.Drawing.Point(24, 51)
            Me._rbOutsideX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbOutsideX.Name = "_rbOutsideX"
            Me._rbOutsideX.Size = New System.Drawing.Size(67, 18)
            Me._rbOutsideX.TabIndex = 1
            Me._rbOutsideX.TabStop = True
            Me._rbOutsideX.Text = "Outside"
            Me._rbOutsideX.UseVisualStyleBackColor = True
            '
            '_rbInsideX
            '
            Me._rbInsideX.AutoSize = True
            Me._rbInsideX.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbInsideX.Location = New System.Drawing.Point(24, 22)
            Me._rbInsideX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbInsideX.Name = "_rbInsideX"
            Me._rbInsideX.Size = New System.Drawing.Size(59, 18)
            Me._rbInsideX.TabIndex = 0
            Me._rbInsideX.TabStop = True
            Me._rbInsideX.Text = "Inside"
            Me._rbInsideX.UseVisualStyleBackColor = True
            '
            '_gbYFilter
            '
            Me._gbYFilter.Controls.Add(Me._rbNoneY)
            Me._gbYFilter.Controls.Add(Me._rbInsideY)
            Me._gbYFilter.Controls.Add(Me._rbOutsideY)
            Me._gbYFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbYFilter.Location = New System.Drawing.Point(150, 10)
            Me._gbYFilter.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbYFilter.Name = "_gbYFilter"
            Me._gbYFilter.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbYFilter.Size = New System.Drawing.Size(135, 113)
            Me._gbYFilter.TabIndex = 13
            Me._gbYFilter.TabStop = False
            Me._gbYFilter.Text = "Y Filter"
            '
            '_rbNoneY
            '
            Me._rbNoneY.AutoSize = True
            Me._rbNoneY.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbNoneY.Location = New System.Drawing.Point(21, 83)
            Me._rbNoneY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbNoneY.Name = "_rbNoneY"
            Me._rbNoneY.Size = New System.Drawing.Size(57, 18)
            Me._rbNoneY.TabIndex = 5
            Me._rbNoneY.TabStop = True
            Me._rbNoneY.Text = "None"
            Me._rbNoneY.UseVisualStyleBackColor = True
            '
            '_rbInsideY
            '
            Me._rbInsideY.AutoSize = True
            Me._rbInsideY.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbInsideY.Location = New System.Drawing.Point(21, 19)
            Me._rbInsideY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbInsideY.Name = "_rbInsideY"
            Me._rbInsideY.Size = New System.Drawing.Size(59, 18)
            Me._rbInsideY.TabIndex = 3
            Me._rbInsideY.TabStop = True
            Me._rbInsideY.Text = "Inside"
            Me._rbInsideY.UseVisualStyleBackColor = True
            '
            '_rbOutsideY
            '
            Me._rbOutsideY.AutoSize = True
            Me._rbOutsideY.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbOutsideY.Location = New System.Drawing.Point(21, 48)
            Me._rbOutsideY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbOutsideY.Name = "_rbOutsideY"
            Me._rbOutsideY.Size = New System.Drawing.Size(67, 18)
            Me._rbOutsideY.TabIndex = 4
            Me._rbOutsideY.TabStop = True
            Me._rbOutsideY.Text = "Outside"
            Me._rbOutsideY.UseVisualStyleBackColor = True
            '
            'FastFourierTransformDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(369, 396)
            Me.Controls.Add(Me._gbYFilter)
            Me.Controls.Add(Me._gbXFilter)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbClippingType)
            Me.Controls.Add(Me._gbFrequencyDataType)
            Me.Controls.Add(Me._gbOperationChannel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "FastFourierTransformDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "FastFourierTransform"
            Me._gbOperationChannel.ResumeLayout(False)
            Me._gbOperationChannel.PerformLayout()
            Me._gbFrequencyDataType.ResumeLayout(False)
            Me._gbFrequencyDataType.PerformLayout()
            Me._gbClippingType.ResumeLayout(False)
            Me._gbClippingType.PerformLayout()
            Me._gbXFilter.ResumeLayout(False)
            Me._gbXFilter.PerformLayout()
            Me._gbYFilter.ResumeLayout(False)
            Me._gbYFilter.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbOperationChannel As System.Windows.Forms.GroupBox
	  Private _gbFrequencyDataType As System.Windows.Forms.GroupBox
	  Private _rbGray As System.Windows.Forms.RadioButton
	  Private _rbRed As System.Windows.Forms.RadioButton
	  Private _rbGreen As System.Windows.Forms.RadioButton
	  Private _rbBlue As System.Windows.Forms.RadioButton
	  Private _rbBoth As System.Windows.Forms.RadioButton
	  Private _rbPhase As System.Windows.Forms.RadioButton
	  Private _rbMagnitude As System.Windows.Forms.RadioButton
	  Private _gbClippingType As System.Windows.Forms.GroupBox
	  Private _rbScale As System.Windows.Forms.RadioButton
	  Private _rbClip As System.Windows.Forms.RadioButton
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbXFilter As System.Windows.Forms.GroupBox
	  Private _rbNoneX As System.Windows.Forms.RadioButton
	  Private _rbOutsideX As System.Windows.Forms.RadioButton
	  Private _rbInsideX As System.Windows.Forms.RadioButton
	  Private _gbYFilter As System.Windows.Forms.GroupBox
	  Private _rbNoneY As System.Windows.Forms.RadioButton
	  Private _rbInsideY As System.Windows.Forms.RadioButton
	  Private _rbOutsideY As System.Windows.Forms.RadioButton
   End Class
End Namespace