Imports Microsoft.VisualBasic
Imports System
Namespace DocumentCleanupDemo
   Public Partial Class BorderRemoveDialog
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
		  Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BorderRemoveDialog))
		  Me._gb1 = New System.Windows.Forms.GroupBox()
		  Me._cbTopBorder = New System.Windows.Forms.CheckBox()
		  Me._cbBottomBorder = New System.Windows.Forms.CheckBox()
		  Me._cbRightBorder = New System.Windows.Forms.CheckBox()
		  Me._cbLeftBorder = New System.Windows.Forms.CheckBox()
		  Me._btnOK = New System.Windows.Forms.Button()
		  Me._btnCancel = New System.Windows.Forms.Button()
		  Me._gb2 = New System.Windows.Forms.GroupBox()
		  Me._lblVariance = New System.Windows.Forms.Label()
		  Me._lblWhiteNoise = New System.Windows.Forms.Label()
		  Me._lblBorderPercent = New System.Windows.Forms.Label()
		  Me._tnVariance = New System.Windows.Forms.TextBox()
		  Me._tbWhiteNoiseLength = New System.Windows.Forms.TextBox()
		  Me._bBorderPercent = New System.Windows.Forms.TextBox()
		  Me._gbFlags = New System.Windows.Forms.GroupBox()
		  Me._cbUseVariance = New System.Windows.Forms.CheckBox()
		  Me._cbImageUnchanged = New System.Windows.Forms.CheckBox()
		  Me._gb1.SuspendLayout()
		  Me._gb2.SuspendLayout()
		  Me._gbFlags.SuspendLayout()
		  Me.SuspendLayout()
		  ' 
		  ' _gb1
		  ' 
		  Me._gb1.Controls.Add(Me._cbTopBorder)
		  Me._gb1.Controls.Add(Me._cbBottomBorder)
		  Me._gb1.Controls.Add(Me._cbRightBorder)
		  Me._gb1.Controls.Add(Me._cbLeftBorder)
		  Me._gb1.Location = New System.Drawing.Point(140, 12)
		  Me._gb1.Name = "_gb1"
		  Me._gb1.Size = New System.Drawing.Size(113, 118)
		  Me._gb1.TabIndex = 0
		  Me._gb1.TabStop = False
		  Me._gb1.Text = "Border To Remove"
		  ' 
		  ' _cbTopBorder
		  ' 
		  Me._cbTopBorder.AutoSize = True
		  Me._cbTopBorder.Location = New System.Drawing.Point(11, 66)
		  Me._cbTopBorder.Name = "_cbTopBorder"
		  Me._cbTopBorder.Size = New System.Drawing.Size(45, 17)
		  Me._cbTopBorder.TabIndex = 3
		  Me._cbTopBorder.Text = "Top"
		  Me._cbTopBorder.UseVisualStyleBackColor = True
		  ' 
		  ' _cbBottomBorder
		  ' 
		  Me._cbBottomBorder.AutoSize = True
		  Me._cbBottomBorder.Location = New System.Drawing.Point(11, 89)
		  Me._cbBottomBorder.Name = "_cbBottomBorder"
		  Me._cbBottomBorder.Size = New System.Drawing.Size(59, 17)
		  Me._cbBottomBorder.TabIndex = 2
		  Me._cbBottomBorder.Text = "Bottom"
		  Me._cbBottomBorder.UseVisualStyleBackColor = True
		  ' 
		  ' _cbRightBorder
		  ' 
		  Me._cbRightBorder.AutoSize = True
		  Me._cbRightBorder.Location = New System.Drawing.Point(11, 43)
		  Me._cbRightBorder.Name = "_cbRightBorder"
		  Me._cbRightBorder.Size = New System.Drawing.Size(51, 17)
		  Me._cbRightBorder.TabIndex = 1
		  Me._cbRightBorder.Text = "Right"
		  Me._cbRightBorder.UseVisualStyleBackColor = True
		  ' 
		  ' _cbLeftBorder
		  ' 
		  Me._cbLeftBorder.AutoSize = True
		  Me._cbLeftBorder.Location = New System.Drawing.Point(11, 20)
		  Me._cbLeftBorder.Name = "_cbLeftBorder"
		  Me._cbLeftBorder.Size = New System.Drawing.Size(44, 17)
		  Me._cbLeftBorder.TabIndex = 0
		  Me._cbLeftBorder.Text = "Left"
		  Me._cbLeftBorder.UseVisualStyleBackColor = True
		  ' 
		  ' _btnOK
		  ' 
		  Me._btnOK.Location = New System.Drawing.Point(267, 12)
		  Me._btnOK.Name = "_btnOK"
		  Me._btnOK.Size = New System.Drawing.Size(75, 23)
		  Me._btnOK.TabIndex = 1
		  Me._btnOK.Text = "OK"
		  Me._btnOK.UseVisualStyleBackColor = True
'		  Me._btnOK.Click += New System.EventHandler(Me._btnOK_Click);
		  ' 
		  ' _btnCancel
		  ' 
		  Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		  Me._btnCancel.Location = New System.Drawing.Point(267, 41)
		  Me._btnCancel.Name = "_btnCancel"
		  Me._btnCancel.Size = New System.Drawing.Size(75, 23)
		  Me._btnCancel.TabIndex = 2
		  Me._btnCancel.Text = "Cancel"
		  Me._btnCancel.UseVisualStyleBackColor = True
'		  Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
		  ' 
		  ' _gb2
		  ' 
		  Me._gb2.Controls.Add(Me._lblVariance)
		  Me._gb2.Controls.Add(Me._lblWhiteNoise)
		  Me._gb2.Controls.Add(Me._lblBorderPercent)
		  Me._gb2.Controls.Add(Me._tnVariance)
		  Me._gb2.Controls.Add(Me._tbWhiteNoiseLength)
		  Me._gb2.Controls.Add(Me._bBorderPercent)
		  Me._gb2.Location = New System.Drawing.Point(12, 136)
		  Me._gb2.Name = "_gb2"
		  Me._gb2.Size = New System.Drawing.Size(241, 106)
		  Me._gb2.TabIndex = 3
		  Me._gb2.TabStop = False
		  ' 
		  ' _lblVariance
		  ' 
		  Me._lblVariance.AutoSize = True
		  Me._lblVariance.Location = New System.Drawing.Point(22, 78)
		  Me._lblVariance.Name = "_lblVariance"
		  Me._lblVariance.Size = New System.Drawing.Size(49, 13)
		  Me._lblVariance.TabIndex = 5
		  Me._lblVariance.Text = "Variance"
		  ' 
		  ' _lblWhiteNoise
		  ' 
		  Me._lblWhiteNoise.AutoSize = True
		  Me._lblWhiteNoise.Location = New System.Drawing.Point(22, 52)
		  Me._lblWhiteNoise.Name = "_lblWhiteNoise"
		  Me._lblWhiteNoise.Size = New System.Drawing.Size(101, 13)
		  Me._lblWhiteNoise.TabIndex = 4
		  Me._lblWhiteNoise.Text = "White Noise Length"
		  ' 
		  ' _lblBorderPercent
		  ' 
		  Me._lblBorderPercent.AutoSize = True
		  Me._lblBorderPercent.Location = New System.Drawing.Point(22, 26)
		  Me._lblBorderPercent.Name = "_lblBorderPercent"
		  Me._lblBorderPercent.Size = New System.Drawing.Size(78, 13)
		  Me._lblBorderPercent.TabIndex = 3
		  Me._lblBorderPercent.Text = "Border Percent"
		  ' 
		  ' _tnVariance
		  ' 
		  Me._tnVariance.Location = New System.Drawing.Point(139, 71)
		  Me._tnVariance.Name = "_tnVariance"
		  Me._tnVariance.Size = New System.Drawing.Size(68, 20)
		  Me._tnVariance.TabIndex = 2
'		  Me._tnVariance.TextChanged += New System.EventHandler(Me._tnVariance_TextChanged);
		  ' 
		  ' _tbWhiteNoiseLength
		  ' 
		  Me._tbWhiteNoiseLength.Location = New System.Drawing.Point(139, 45)
		  Me._tbWhiteNoiseLength.Name = "_tbWhiteNoiseLength"
		  Me._tbWhiteNoiseLength.Size = New System.Drawing.Size(68, 20)
		  Me._tbWhiteNoiseLength.TabIndex = 1
'		  Me._tbWhiteNoiseLength.TextChanged += New System.EventHandler(Me._tbWhiteNoiseLength_TextChanged);
		  ' 
		  ' _bBorderPercent
		  ' 
		  Me._bBorderPercent.Location = New System.Drawing.Point(139, 19)
		  Me._bBorderPercent.MaxLength = 3
		  Me._bBorderPercent.Name = "_bBorderPercent"
		  Me._bBorderPercent.Size = New System.Drawing.Size(68, 20)
		  Me._bBorderPercent.TabIndex = 0
'		  Me._bBorderPercent.TextChanged += New System.EventHandler(Me._bBorderPercent_TextChanged);
		  ' 
		  ' _gbFlags
		  ' 
		  Me._gbFlags.Controls.Add(Me._cbUseVariance)
		  Me._gbFlags.Controls.Add(Me._cbImageUnchanged)
		  Me._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System
		  Me._gbFlags.Location = New System.Drawing.Point(8, 12)
		  Me._gbFlags.Name = "_gbFlags"
		  Me._gbFlags.Size = New System.Drawing.Size(126, 117)
		  Me._gbFlags.TabIndex = 4
		  Me._gbFlags.TabStop = False
		  Me._gbFlags.Text = "Flags"
		  ' 
		  ' _cbUseVariance
		  ' 
		  Me._cbUseVariance.AutoSize = True
		  Me._cbUseVariance.Checked = True
		  Me._cbUseVariance.CheckState = System.Windows.Forms.CheckState.Checked
		  Me._cbUseVariance.Location = New System.Drawing.Point(6, 53)
		  Me._cbUseVariance.Name = "_cbUseVariance"
		  Me._cbUseVariance.Size = New System.Drawing.Size(90, 17)
		  Me._cbUseVariance.TabIndex = 1
		  Me._cbUseVariance.Text = "Use Variance"
		  Me._cbUseVariance.UseVisualStyleBackColor = True
'		  Me._cbUseVariance.CheckedChanged += New System.EventHandler(Me._cbUseVariance_CheckedChanged);
		  ' 
		  ' _cbImageUnchanged
		  ' 
		  Me._cbImageUnchanged.AutoSize = True
		  Me._cbImageUnchanged.Location = New System.Drawing.Point(6, 25)
		  Me._cbImageUnchanged.Name = "_cbImageUnchanged"
		  Me._cbImageUnchanged.Size = New System.Drawing.Size(117, 17)
		  Me._cbImageUnchanged.TabIndex = 0
		  Me._cbImageUnchanged.Text = " Image Unchanged"
		  Me._cbImageUnchanged.UseVisualStyleBackColor = True
		  ' 
		  ' BorderRemoveDialog
		  ' 
		  Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		  Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		  Me.ClientSize = New System.Drawing.Size(345, 252)
		  Me.Controls.Add(Me._gbFlags)
		  Me.Controls.Add(Me._gb2)
		  Me.Controls.Add(Me._btnCancel)
		  Me.Controls.Add(Me._btnOK)
		  Me.Controls.Add(Me._gb1)
		  Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		  Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
		  Me.MaximizeBox = False
		  Me.MinimizeBox = False
		  Me.Name = "BorderRemoveDialog"
		  Me.Text = "Border Removal"
		  Me._gb1.ResumeLayout(False)
		  Me._gb1.PerformLayout()
		  Me._gb2.ResumeLayout(False)
		  Me._gb2.PerformLayout()
		  Me._gbFlags.ResumeLayout(False)
		  Me._gbFlags.PerformLayout()
		  Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _gb1 As System.Windows.Forms.GroupBox
	  Private WithEvents _btnOK As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private _gb2 As System.Windows.Forms.GroupBox
	  Private _lblVariance As System.Windows.Forms.Label
	  Private _lblWhiteNoise As System.Windows.Forms.Label
	  Private _lblBorderPercent As System.Windows.Forms.Label
	  Private _cbTopBorder As System.Windows.Forms.CheckBox
	  Private _cbBottomBorder As System.Windows.Forms.CheckBox
	  Private _cbRightBorder As System.Windows.Forms.CheckBox
	  Private _cbLeftBorder As System.Windows.Forms.CheckBox
	  Private WithEvents _tnVariance As System.Windows.Forms.TextBox
	  Private WithEvents _tbWhiteNoiseLength As System.Windows.Forms.TextBox
	  Private WithEvents _bBorderPercent As System.Windows.Forms.TextBox
	   Private _gbFlags As System.Windows.Forms.GroupBox
	   Private WithEvents _cbUseVariance As System.Windows.Forms.CheckBox
	   Private _cbImageUnchanged As System.Windows.Forms.CheckBox
   End Class
End Namespace