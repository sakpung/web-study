Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class DeinterlaceDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DeinterlaceDialog))
            Me._gbDeinterlaceImage = New System.Windows.Forms.GroupBox
            Me._rbNormal = New System.Windows.Forms.RadioButton
            Me._rbSmooth = New System.Windows.Forms.RadioButton
            Me._gbRemoveLines = New System.Windows.Forms.GroupBox
            Me._rbEvenLines = New System.Windows.Forms.RadioButton
            Me._rbOddLines = New System.Windows.Forms.RadioButton
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbDeinterlaceImage.SuspendLayout()
            Me._gbRemoveLines.SuspendLayout()
            Me.SuspendLayout()
            '
            '_gbDeinterlaceImage
            '
            Me._gbDeinterlaceImage.Controls.Add(Me._rbNormal)
            Me._gbDeinterlaceImage.Controls.Add(Me._rbSmooth)
            Me._gbDeinterlaceImage.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbDeinterlaceImage.Location = New System.Drawing.Point(10, 10)
            Me._gbDeinterlaceImage.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDeinterlaceImage.Name = "_gbDeinterlaceImage"
            Me._gbDeinterlaceImage.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDeinterlaceImage.Size = New System.Drawing.Size(309, 54)
            Me._gbDeinterlaceImage.TabIndex = 0
            Me._gbDeinterlaceImage.TabStop = False
            Me._gbDeinterlaceImage.Text = "How to deinterlace the image"
            '
            '_rbNormal
            '
            Me._rbNormal.AutoSize = True
            Me._rbNormal.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbNormal.Location = New System.Drawing.Point(174, 20)
            Me._rbNormal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbNormal.Name = "_rbNormal"
            Me._rbNormal.Size = New System.Drawing.Size(64, 18)
            Me._rbNormal.TabIndex = 1
            Me._rbNormal.TabStop = True
            Me._rbNormal.Text = "Normal"
            Me._rbNormal.UseVisualStyleBackColor = True
            '
            '_rbSmooth
            '
            Me._rbSmooth.AutoSize = True
            Me._rbSmooth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbSmooth.Location = New System.Drawing.Point(18, 20)
            Me._rbSmooth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbSmooth.Name = "_rbSmooth"
            Me._rbSmooth.Size = New System.Drawing.Size(67, 18)
            Me._rbSmooth.TabIndex = 0
            Me._rbSmooth.TabStop = True
            Me._rbSmooth.Text = "Smooth"
            Me._rbSmooth.UseVisualStyleBackColor = True
            '
            '_gbRemoveLines
            '
            Me._gbRemoveLines.Controls.Add(Me._rbEvenLines)
            Me._gbRemoveLines.Controls.Add(Me._rbOddLines)
            Me._gbRemoveLines.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbRemoveLines.Location = New System.Drawing.Point(10, 68)
            Me._gbRemoveLines.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRemoveLines.Name = "_gbRemoveLines"
            Me._gbRemoveLines.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRemoveLines.Size = New System.Drawing.Size(309, 51)
            Me._gbRemoveLines.TabIndex = 1
            Me._gbRemoveLines.TabStop = False
            Me._gbRemoveLines.Text = "Remove lines"
            '
            '_rbEvenLines
            '
            Me._rbEvenLines.AutoSize = True
            Me._rbEvenLines.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbEvenLines.Location = New System.Drawing.Point(174, 19)
            Me._rbEvenLines.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbEvenLines.Name = "_rbEvenLines"
            Me._rbEvenLines.Size = New System.Drawing.Size(84, 18)
            Me._rbEvenLines.TabIndex = 1
            Me._rbEvenLines.Text = "Even Lines"
            Me._rbEvenLines.UseVisualStyleBackColor = True
            '
            '_rbOddLines
            '
            Me._rbOddLines.AutoSize = True
            Me._rbOddLines.Checked = True
            Me._rbOddLines.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbOddLines.Location = New System.Drawing.Point(18, 19)
            Me._rbOddLines.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbOddLines.Name = "_rbOddLines"
            Me._rbOddLines.Size = New System.Drawing.Size(79, 18)
            Me._rbOddLines.TabIndex = 0
            Me._rbOddLines.TabStop = True
            Me._rbOddLines.Text = "Odd Lines"
            Me._rbOddLines.UseVisualStyleBackColor = True
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(328, 39)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(75, 23)
            Me._btnCancel.TabIndex = 3
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(328, 11)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(75, 23)
            Me._btnOk.TabIndex = 2
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'DeinterlaceDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(413, 135)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbRemoveLines)
            Me.Controls.Add(Me._gbDeinterlaceImage)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "DeinterlaceDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Deinterlace"
            Me._gbDeinterlaceImage.ResumeLayout(False)
            Me._gbDeinterlaceImage.PerformLayout()
            Me._gbRemoveLines.ResumeLayout(False)
            Me._gbRemoveLines.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbDeinterlaceImage As System.Windows.Forms.GroupBox
	  Private _rbNormal As System.Windows.Forms.RadioButton
	  Private _rbSmooth As System.Windows.Forms.RadioButton
	  Private _gbRemoveLines As System.Windows.Forms.GroupBox
	  Private _rbEvenLines As System.Windows.Forms.RadioButton
	  Private _rbOddLines As System.Windows.Forms.RadioButton
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace