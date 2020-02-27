Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class GrayScaleToMultitoneDialog
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GrayScaleToMultitoneDialog))
         Me._gbInk = New System.Windows.Forms.GroupBox
         Me._lblColor4 = New System.Windows.Forms.Label
         Me._lblColor3 = New System.Windows.Forms.Label
         Me._lblColor2 = New System.Windows.Forms.Label
         Me._lblColor1 = New System.Windows.Forms.Label
         Me._cmbChannels = New System.Windows.Forms.ComboBox
         Me._lblChannels = New System.Windows.Forms.Label
         Me._lblType = New System.Windows.Forms.Label
         Me._cmbType = New System.Windows.Forms.ComboBox
         Me._btnCancel = New System.Windows.Forms.Button
         Me._btnOk = New System.Windows.Forms.Button
         Me._gbInk.SuspendLayout()
         Me.SuspendLayout()
         '
         '_gbInk
         '
         Me._gbInk.Controls.Add(Me._lblColor4)
         Me._gbInk.Controls.Add(Me._lblColor3)
         Me._gbInk.Controls.Add(Me._lblColor2)
         Me._gbInk.Controls.Add(Me._lblColor1)
         Me._gbInk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbInk.Location = New System.Drawing.Point(23, 109)
         Me._gbInk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._gbInk.Name = "_gbInk"
         Me._gbInk.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._gbInk.Size = New System.Drawing.Size(231, 60)
         Me._gbInk.TabIndex = 0
         Me._gbInk.TabStop = False
         Me._gbInk.Text = "Ink"
         '
         '_lblColor4
         '
         Me._lblColor4.BackColor = System.Drawing.Color.White
         Me._lblColor4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblColor4.Enabled = False
         Me._lblColor4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
         Me._lblColor4.Location = New System.Drawing.Point(168, 16)
         Me._lblColor4.Name = "_lblColor4"
         Me._lblColor4.Size = New System.Drawing.Size(48, 38)
         Me._lblColor4.TabIndex = 3
         Me._lblColor4.Visible = False
         '
         '_lblColor3
         '
         Me._lblColor3.BackColor = System.Drawing.Color.White
         Me._lblColor3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblColor3.Enabled = False
         Me._lblColor3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
         Me._lblColor3.Location = New System.Drawing.Point(115, 16)
         Me._lblColor3.Name = "_lblColor3"
         Me._lblColor3.Size = New System.Drawing.Size(48, 38)
         Me._lblColor3.TabIndex = 2
         Me._lblColor3.Visible = False
         '
         '_lblColor2
         '
         Me._lblColor2.BackColor = System.Drawing.Color.White
         Me._lblColor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblColor2.Enabled = False
         Me._lblColor2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
         Me._lblColor2.Location = New System.Drawing.Point(58, 16)
         Me._lblColor2.Name = "_lblColor2"
         Me._lblColor2.Size = New System.Drawing.Size(48, 38)
         Me._lblColor2.TabIndex = 1
         Me._lblColor2.Visible = False
         '
         '_lblColor1
         '
         Me._lblColor1.BackColor = System.Drawing.Color.Black
         Me._lblColor1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblColor1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
         Me._lblColor1.Location = New System.Drawing.Point(5, 16)
         Me._lblColor1.Name = "_lblColor1"
         Me._lblColor1.Size = New System.Drawing.Size(48, 38)
         Me._lblColor1.TabIndex = 0
         '
         '_cmbChannels
         '
         Me._cmbChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbChannels.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._cmbChannels.FormattingEnabled = True
         Me._cmbChannels.Location = New System.Drawing.Point(25, 84)
         Me._cmbChannels.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._cmbChannels.Name = "_cmbChannels"
         Me._cmbChannels.Size = New System.Drawing.Size(189, 21)
         Me._cmbChannels.TabIndex = 1
         '
         '_lblChannels
         '
         Me._lblChannels.AutoSize = True
         Me._lblChannels.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblChannels.Location = New System.Drawing.Point(22, 67)
         Me._lblChannels.Name = "_lblChannels"
         Me._lblChannels.Size = New System.Drawing.Size(51, 13)
         Me._lblChannels.TabIndex = 2
         Me._lblChannels.Text = "Channels"
         '
         '_lblType
         '
         Me._lblType.AutoSize = True
         Me._lblType.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblType.Location = New System.Drawing.Point(26, 14)
         Me._lblType.Name = "_lblType"
         Me._lblType.Size = New System.Drawing.Size(31, 13)
         Me._lblType.TabIndex = 6
         Me._lblType.Text = "Type"
         '
         '_cmbType
         '
         Me._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cmbType.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._cmbType.FormattingEnabled = True
         Me._cmbType.Location = New System.Drawing.Point(23, 32)
         Me._cmbType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._cmbType.Name = "_cmbType"
         Me._cmbType.Size = New System.Drawing.Size(191, 21)
         Me._cmbType.TabIndex = 7
         '
         '_btnCancel
         '
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(233, 40)
         Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.Size = New System.Drawing.Size(71, 20)
         Me._btnCancel.TabIndex = 9
         Me._btnCancel.Text = "Cancel"
         Me._btnCancel.UseVisualStyleBackColor = True
         '
         '_btnOk
         '
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(233, 15)
         Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(70, 20)
         Me._btnOk.TabIndex = 8
         Me._btnOk.Text = "OK"
         Me._btnOk.UseVisualStyleBackColor = True
         '
         'GrayScaleToMultitoneDialog
         '
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(313, 176)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me._cmbType)
         Me.Controls.Add(Me._lblType)
         Me.Controls.Add(Me._lblChannels)
         Me.Controls.Add(Me._cmbChannels)
         Me.Controls.Add(Me._gbInk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "GrayScaleToMultitoneDialog"
         Me.ShowIcon = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "GrayScale To Multitone"
         Me._gbInk.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

	  #End Region

	  Private _gbInk As System.Windows.Forms.GroupBox
	  Private WithEvents _lblColor4 As System.Windows.Forms.Label
	  Private WithEvents _lblColor3 As System.Windows.Forms.Label
	  Private WithEvents _lblColor2 As System.Windows.Forms.Label
	  Private WithEvents _lblColor1 As System.Windows.Forms.Label
	  Private WithEvents _cmbChannels As System.Windows.Forms.ComboBox
	  Private _lblChannels As System.Windows.Forms.Label
      Private _lblType As System.Windows.Forms.Label
	  Private _cmbType As System.Windows.Forms.ComboBox
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace