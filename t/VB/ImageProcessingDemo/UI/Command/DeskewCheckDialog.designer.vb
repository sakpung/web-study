Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class DeskewCheckDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeskewCheckDialog))
            Me._btnOk = New System.Windows.Forms.Button
            Me._btnCancel = New System.Windows.Forms.Button
            Me._gb1 = New System.Windows.Forms.GroupBox
            Me._btnColor = New System.Windows.Forms.Button
            Me._lblColor = New System.Windows.Forms.Label
            Me._cbFillExposedArea = New System.Windows.Forms.CheckBox
            Me._gb2 = New System.Windows.Forms.GroupBox
            Me._lblThreshold = New System.Windows.Forms.Label
            Me._label1 = New System.Windows.Forms.Label
            Me._cbThreshold = New System.Windows.Forms.CheckBox
            Me._gb3 = New System.Windows.Forms.GroupBox
            Me._rbHigh = New System.Windows.Forms.RadioButton
            Me._rbMedium = New System.Windows.Forms.RadioButton
            Me._rbLow = New System.Windows.Forms.RadioButton
            Me._gp4 = New System.Windows.Forms.GroupBox
            Me._rbTextImages = New System.Windows.Forms.RadioButton
            Me._rbTextOnly = New System.Windows.Forms.RadioButton
            Me._gb5 = New System.Windows.Forms.GroupBox
            Me._rbFast = New System.Windows.Forms.RadioButton
            Me._rbNormal = New System.Windows.Forms.RadioButton
            Me._gbDeskew = New System.Windows.Forms.GroupBox
            Me._rbReturnAngleOnly = New System.Windows.Forms.RadioButton
            Me._rbDeskewImage = New System.Windows.Forms.RadioButton
            Me._gbalgorithm = New System.Windows.Forms.GroupBox
            Me._rbLineDetectionDeskew = New System.Windows.Forms.RadioButton
            Me._rbBankCheckDeskew = New System.Windows.Forms.RadioButton
            Me._rbOrdinaryDeskew = New System.Windows.Forms.RadioButton
            Me._gb1.SuspendLayout()
            Me._gb2.SuspendLayout()
            Me._gb3.SuspendLayout()
            Me._gp4.SuspendLayout()
            Me._gb5.SuspendLayout()
            Me._gbDeskew.SuspendLayout()
            Me._gbalgorithm.SuspendLayout()
            Me.SuspendLayout()
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(387, 12)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(75, 23)
            Me._btnOk.TabIndex = 0
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(387, 41)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(75, 23)
            Me._btnCancel.TabIndex = 1
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_gb1
            '
            Me._gb1.Controls.Add(Me._btnColor)
            Me._gb1.Controls.Add(Me._lblColor)
            Me._gb1.Controls.Add(Me._cbFillExposedArea)
            Me._gb1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gb1.Location = New System.Drawing.Point(10, 80)
            Me._gb1.Name = "_gb1"
            Me._gb1.Size = New System.Drawing.Size(357, 52)
            Me._gb1.TabIndex = 2
            Me._gb1.TabStop = False
            Me._gb1.Text = "Fill"
            '
            '_btnColor
            '
            Me._btnColor.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnColor.Location = New System.Drawing.Point(235, 17)
            Me._btnColor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnColor.Name = "_btnColor"
            Me._btnColor.Size = New System.Drawing.Size(21, 21)
            Me._btnColor.TabIndex = 7
            Me._btnColor.Text = "..."
            Me._btnColor.UseVisualStyleBackColor = True
            '
            '_lblColor
            '
            Me._lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._lblColor.Enabled = False
            Me._lblColor.Location = New System.Drawing.Point(134, 16)
            Me._lblColor.Name = "_lblColor"
            Me._lblColor.Size = New System.Drawing.Size(101, 23)
            Me._lblColor.TabIndex = 1
            '
            '_cbFillExposedArea
            '
            Me._cbFillExposedArea.AutoSize = True
            Me._cbFillExposedArea.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cbFillExposedArea.Location = New System.Drawing.Point(13, 16)
            Me._cbFillExposedArea.Name = "_cbFillExposedArea"
            Me._cbFillExposedArea.Size = New System.Drawing.Size(113, 18)
            Me._cbFillExposedArea.TabIndex = 0
            Me._cbFillExposedArea.Text = "Fill Exposed Area"
            Me._cbFillExposedArea.UseVisualStyleBackColor = True
            '
            '_gb2
            '
            Me._gb2.Controls.Add(Me._lblThreshold)
            Me._gb2.Controls.Add(Me._label1)
            Me._gb2.Controls.Add(Me._cbThreshold)
            Me._gb2.Location = New System.Drawing.Point(10, 137)
            Me._gb2.Name = "_gb2"
            Me._gb2.Size = New System.Drawing.Size(357, 58)
            Me._gb2.TabIndex = 3
            Me._gb2.TabStop = False
            Me._gb2.Text = "Threshold"
            '
            '_lblThreshold
            '
            Me._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblThreshold.Location = New System.Drawing.Point(31, 20)
            Me._lblThreshold.Name = "_lblThreshold"
            Me._lblThreshold.Size = New System.Drawing.Size(288, 35)
            Me._lblThreshold.TabIndex = 2
            Me._lblThreshold.Text = "Do not deskew the image if the deskew angle is very small (less than 0.5 degrees)" & _
                ". "
            '
            '_label1
            '
            Me._label1.Location = New System.Drawing.Point(42, 19)
            Me._label1.MaximumSize = New System.Drawing.Size(0, 50)
            Me._label1.Name = "_label1"
            Me._label1.Size = New System.Drawing.Size(0, 36)
            Me._label1.TabIndex = 1
            Me._label1.Text = "Do not deskew the image if the deskew angle is very small (less than 0.5 degrees)" & _
                ". "
            '
            '_cbThreshold
            '
            Me._cbThreshold.AutoSize = True
            Me._cbThreshold.Location = New System.Drawing.Point(13, 19)
            Me._cbThreshold.Name = "_cbThreshold"
            Me._cbThreshold.Size = New System.Drawing.Size(15, 14)
            Me._cbThreshold.TabIndex = 0
            Me._cbThreshold.UseVisualStyleBackColor = True
            '
            '_gb3
            '
            Me._gb3.Controls.Add(Me._rbHigh)
            Me._gb3.Controls.Add(Me._rbMedium)
            Me._gb3.Controls.Add(Me._rbLow)
            Me._gb3.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gb3.Location = New System.Drawing.Point(10, 202)
            Me._gb3.Name = "_gb3"
            Me._gb3.Size = New System.Drawing.Size(357, 70)
            Me._gb3.TabIndex = 3
            Me._gb3.TabStop = False
            Me._gb3.Text = "Quality"
            '
            '_rbHigh
            '
            Me._rbHigh.AutoSize = True
            Me._rbHigh.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbHigh.Location = New System.Drawing.Point(149, 19)
            Me._rbHigh.Name = "_rbHigh"
            Me._rbHigh.Size = New System.Drawing.Size(53, 18)
            Me._rbHigh.TabIndex = 2
            Me._rbHigh.TabStop = True
            Me._rbHigh.Text = "High"
            Me._rbHigh.UseVisualStyleBackColor = True
            '
            '_rbMedium
            '
            Me._rbMedium.AutoSize = True
            Me._rbMedium.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbMedium.Location = New System.Drawing.Point(13, 42)
            Me._rbMedium.Name = "_rbMedium"
            Me._rbMedium.Size = New System.Drawing.Size(68, 18)
            Me._rbMedium.TabIndex = 1
            Me._rbMedium.TabStop = True
            Me._rbMedium.Text = "Medium"
            Me._rbMedium.UseVisualStyleBackColor = True
            '
            '_rbLow
            '
            Me._rbLow.AutoSize = True
            Me._rbLow.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbLow.Location = New System.Drawing.Point(13, 19)
            Me._rbLow.Name = "_rbLow"
            Me._rbLow.Size = New System.Drawing.Size(51, 18)
            Me._rbLow.TabIndex = 0
            Me._rbLow.TabStop = True
            Me._rbLow.Text = "Low"
            Me._rbLow.UseVisualStyleBackColor = True
            '
            '_gp4
            '
            Me._gp4.Controls.Add(Me._rbTextImages)
            Me._gp4.Controls.Add(Me._rbTextOnly)
            Me._gp4.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gp4.Location = New System.Drawing.Point(10, 277)
            Me._gp4.Name = "_gp4"
            Me._gp4.Size = New System.Drawing.Size(357, 56)
            Me._gp4.TabIndex = 3
            Me._gp4.TabStop = False
            Me._gp4.Text = "Type"
            '
            '_rbTextImages
            '
            Me._rbTextImages.AutoSize = True
            Me._rbTextImages.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbTextImages.Location = New System.Drawing.Point(149, 19)
            Me._rbTextImages.Name = "_rbTextImages"
            Me._rbTextImages.Size = New System.Drawing.Size(110, 18)
            Me._rbTextImages.TabIndex = 1
            Me._rbTextImages.TabStop = True
            Me._rbTextImages.Text = "Text and Images"
            Me._rbTextImages.UseVisualStyleBackColor = True
            '
            '_rbTextOnly
            '
            Me._rbTextOnly.AutoSize = True
            Me._rbTextOnly.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbTextOnly.Location = New System.Drawing.Point(13, 19)
            Me._rbTextOnly.Name = "_rbTextOnly"
            Me._rbTextOnly.Size = New System.Drawing.Size(76, 18)
            Me._rbTextOnly.TabIndex = 0
            Me._rbTextOnly.TabStop = True
            Me._rbTextOnly.Text = "Text Only"
            Me._rbTextOnly.UseVisualStyleBackColor = True
            '
            '_gb5
            '
            Me._gb5.Controls.Add(Me._rbFast)
            Me._gb5.Controls.Add(Me._rbNormal)
            Me._gb5.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gb5.Location = New System.Drawing.Point(10, 340)
            Me._gb5.Name = "_gb5"
            Me._gb5.Size = New System.Drawing.Size(357, 56)
            Me._gb5.TabIndex = 4
            Me._gb5.TabStop = False
            Me._gb5.Text = "Speed"
            '
            '_rbFast
            '
            Me._rbFast.AutoSize = True
            Me._rbFast.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbFast.Location = New System.Drawing.Point(149, 20)
            Me._rbFast.Name = "_rbFast"
            Me._rbFast.Size = New System.Drawing.Size(187, 18)
            Me._rbFast.TabIndex = 1
            Me._rbFast.TabStop = True
            Me._rbFast.Text = "Fast (Intended for 1 bits per pixel)"
            Me._rbFast.UseVisualStyleBackColor = True
            '
            '_rbNormal
            '
            Me._rbNormal.AutoSize = True
            Me._rbNormal.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbNormal.Location = New System.Drawing.Point(13, 20)
            Me._rbNormal.Name = "_rbNormal"
            Me._rbNormal.Size = New System.Drawing.Size(129, 18)
            Me._rbNormal.TabIndex = 0
            Me._rbNormal.TabStop = True
            Me._rbNormal.Text = "Normal (Best Quality)"
            Me._rbNormal.UseVisualStyleBackColor = True
            '
            '_gbDeskew
            '
            Me._gbDeskew.Controls.Add(Me._rbReturnAngleOnly)
            Me._gbDeskew.Controls.Add(Me._rbDeskewImage)
            Me._gbDeskew.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbDeskew.Location = New System.Drawing.Point(10, 9)
            Me._gbDeskew.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDeskew.Name = "_gbDeskew"
            Me._gbDeskew.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDeskew.Size = New System.Drawing.Size(357, 65)
            Me._gbDeskew.TabIndex = 5
            Me._gbDeskew.TabStop = False
            Me._gbDeskew.Text = "Deskew Image"
            '
            '_rbReturnAngleOnly
            '
            Me._rbReturnAngleOnly.AutoSize = True
            Me._rbReturnAngleOnly.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbReturnAngleOnly.Location = New System.Drawing.Point(13, 38)
            Me._rbReturnAngleOnly.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbReturnAngleOnly.Name = "_rbReturnAngleOnly"
            Me._rbReturnAngleOnly.Size = New System.Drawing.Size(226, 18)
            Me._rbReturnAngleOnly.TabIndex = 1
            Me._rbReturnAngleOnly.TabStop = True
            Me._rbReturnAngleOnly.Text = "Do not deskew (find the angle of rotation)"
            Me._rbReturnAngleOnly.UseVisualStyleBackColor = True
            '
            '_rbDeskewImage
            '
            Me._rbDeskewImage.AutoSize = True
            Me._rbDeskewImage.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbDeskewImage.Location = New System.Drawing.Point(13, 19)
            Me._rbDeskewImage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbDeskewImage.Name = "_rbDeskewImage"
            Me._rbDeskewImage.Size = New System.Drawing.Size(102, 18)
            Me._rbDeskewImage.TabIndex = 0
            Me._rbDeskewImage.TabStop = True
            Me._rbDeskewImage.Text = "Deskew Image"
            Me._rbDeskewImage.UseVisualStyleBackColor = True
            '
            '_gbalgorithm
            '
            Me._gbalgorithm.Controls.Add(Me._rbLineDetectionDeskew)
            Me._gbalgorithm.Controls.Add(Me._rbBankCheckDeskew)
            Me._gbalgorithm.Controls.Add(Me._rbOrdinaryDeskew)
            Me._gbalgorithm.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbalgorithm.Location = New System.Drawing.Point(10, 401)
            Me._gbalgorithm.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbalgorithm.Name = "_gbalgorithm"
            Me._gbalgorithm.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbalgorithm.Size = New System.Drawing.Size(357, 76)
            Me._gbalgorithm.TabIndex = 6
            Me._gbalgorithm.TabStop = False
            Me._gbalgorithm.Text = "Deskew Algorithm"
            '
            '_rbLineDetectionDeskew
            '
            Me._rbLineDetectionDeskew.AutoSize = True
            Me._rbLineDetectionDeskew.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbLineDetectionDeskew.Location = New System.Drawing.Point(13, 46)
            Me._rbLineDetectionDeskew.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbLineDetectionDeskew.Name = "_rbLineDetectionDeskew"
            Me._rbLineDetectionDeskew.Size = New System.Drawing.Size(138, 18)
            Me._rbLineDetectionDeskew.TabIndex = 2
            Me._rbLineDetectionDeskew.TabStop = True
            Me._rbLineDetectionDeskew.Text = "Line detection deskew"
            Me._rbLineDetectionDeskew.UseVisualStyleBackColor = True
            '
            '_rbBankCheckDeskew
            '
            Me._rbBankCheckDeskew.AutoSize = True
            Me._rbBankCheckDeskew.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbBankCheckDeskew.Location = New System.Drawing.Point(149, 19)
            Me._rbBankCheckDeskew.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbBankCheckDeskew.Name = "_rbBankCheckDeskew"
            Me._rbBankCheckDeskew.Size = New System.Drawing.Size(129, 18)
            Me._rbBankCheckDeskew.TabIndex = 1
            Me._rbBankCheckDeskew.TabStop = True
            Me._rbBankCheckDeskew.Text = "Bank check deskew"
            Me._rbBankCheckDeskew.UseVisualStyleBackColor = True
            '
            '_rbOrdinaryDeskew
            '
            Me._rbOrdinaryDeskew.AutoSize = True
            Me._rbOrdinaryDeskew.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbOrdinaryDeskew.Location = New System.Drawing.Point(13, 19)
            Me._rbOrdinaryDeskew.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbOrdinaryDeskew.Name = "_rbOrdinaryDeskew"
            Me._rbOrdinaryDeskew.Size = New System.Drawing.Size(110, 18)
            Me._rbOrdinaryDeskew.TabIndex = 0
            Me._rbOrdinaryDeskew.TabStop = True
            Me._rbOrdinaryDeskew.Text = "Ordinary deskew"
            Me._rbOrdinaryDeskew.UseVisualStyleBackColor = True
            '
            'DeskewCheckDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(470, 487)
            Me.Controls.Add(Me._gbalgorithm)
            Me.Controls.Add(Me._gbDeskew)
            Me.Controls.Add(Me._gb5)
            Me.Controls.Add(Me._gb2)
            Me.Controls.Add(Me._gb3)
            Me.Controls.Add(Me._gp4)
            Me.Controls.Add(Me._gb1)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "DeskewCheckDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Deskew Check"
            Me._gb1.ResumeLayout(False)
            Me._gb1.PerformLayout()
            Me._gb2.ResumeLayout(False)
            Me._gb2.PerformLayout()
            Me._gb3.ResumeLayout(False)
            Me._gb3.PerformLayout()
            Me._gp4.ResumeLayout(False)
            Me._gp4.PerformLayout()
            Me._gb5.ResumeLayout(False)
            Me._gb5.PerformLayout()
            Me._gbDeskew.ResumeLayout(False)
            Me._gbDeskew.PerformLayout()
            Me._gbalgorithm.ResumeLayout(False)
            Me._gbalgorithm.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private _gb1 As System.Windows.Forms.GroupBox
	  Private WithEvents _cbFillExposedArea As System.Windows.Forms.CheckBox
	  Private _gb2 As System.Windows.Forms.GroupBox
	  Private _gb3 As System.Windows.Forms.GroupBox
	  Private _gp4 As System.Windows.Forms.GroupBox
	  Private WithEvents _lblColor As System.Windows.Forms.Label
	  Private _label1 As System.Windows.Forms.Label
	  Private _cbThreshold As System.Windows.Forms.CheckBox
	  Private _rbHigh As System.Windows.Forms.RadioButton
	  Private _rbMedium As System.Windows.Forms.RadioButton
	  Private _rbLow As System.Windows.Forms.RadioButton
	  Private _rbTextImages As System.Windows.Forms.RadioButton
	  Private _rbTextOnly As System.Windows.Forms.RadioButton
	  Private _gb5 As System.Windows.Forms.GroupBox
	  Private _rbFast As System.Windows.Forms.RadioButton
	  Private _rbNormal As System.Windows.Forms.RadioButton
	  Private _lblThreshold As System.Windows.Forms.Label
	  Private WithEvents _btnColor As System.Windows.Forms.Button
	  Private _gbDeskew As System.Windows.Forms.GroupBox
	  Private _rbReturnAngleOnly As System.Windows.Forms.RadioButton
	  Private _rbDeskewImage As System.Windows.Forms.RadioButton
	  Private _gbalgorithm As System.Windows.Forms.GroupBox
	  Private _rbLineDetectionDeskew As System.Windows.Forms.RadioButton
	  Private _rbBankCheckDeskew As System.Windows.Forms.RadioButton
	  Private _rbOrdinaryDeskew As System.Windows.Forms.RadioButton
   End Class
End Namespace