Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class GrayScaleToDuotoneDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GrayScaleToDuotoneDialog))
            Me._gb1 = New System.Windows.Forms.GroupBox
            Me._btnColor = New System.Windows.Forms.Button
            Me._lblColor = New System.Windows.Forms.Label
            Me._lblType = New System.Windows.Forms.Label
            Me._cmbType = New System.Windows.Forms.ComboBox
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gb1.SuspendLayout()
            Me.SuspendLayout()
            '
            '_gb1
            '
            Me._gb1.Controls.Add(Me._btnColor)
            Me._gb1.Controls.Add(Me._lblColor)
            Me._gb1.Controls.Add(Me._lblType)
            Me._gb1.Controls.Add(Me._cmbType)
            Me._gb1.Location = New System.Drawing.Point(13, 10)
            Me._gb1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gb1.Name = "_gb1"
            Me._gb1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gb1.Size = New System.Drawing.Size(243, 119)
            Me._gb1.TabIndex = 0
            Me._gb1.TabStop = False
            '
            '_btnColor
            '
            Me._btnColor.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnColor.Location = New System.Drawing.Point(162, 67)
            Me._btnColor.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnColor.Name = "_btnColor"
            Me._btnColor.Size = New System.Drawing.Size(54, 20)
            Me._btnColor.TabIndex = 3
            Me._btnColor.Text = "Color..."
            Me._btnColor.UseVisualStyleBackColor = True
            '
            '_lblColor
            '
            Me._lblColor.BackColor = System.Drawing.Color.Black
            Me._lblColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me._lblColor.Location = New System.Drawing.Point(55, 67)
            Me._lblColor.Name = "_lblColor"
            Me._lblColor.Size = New System.Drawing.Size(108, 20)
            Me._lblColor.TabIndex = 2
            '
            '_lblType
            '
            Me._lblType.AutoSize = True
            Me._lblType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblType.Location = New System.Drawing.Point(19, 19)
            Me._lblType.Name = "_lblType"
            Me._lblType.Size = New System.Drawing.Size(31, 13)
            Me._lblType.TabIndex = 1
            Me._lblType.Text = "Type"
            '
            '_cmbType
            '
            Me._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbType.FormattingEnabled = True
            Me._cmbType.Location = New System.Drawing.Point(57, 16)
            Me._cmbType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbType.Name = "_cmbType"
            Me._cmbType.Size = New System.Drawing.Size(159, 21)
            Me._cmbType.TabIndex = 0
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(270, 50)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(71, 20)
            Me._btnCancel.TabIndex = 7
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(270, 23)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(70, 20)
            Me._btnOk.TabIndex = 6
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'GrayScaleToDuotoneDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(345, 138)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gb1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "GrayScaleToDuotoneDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "GrayScale To Duotone"
            Me._gb1.ResumeLayout(False)
            Me._gb1.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gb1 As System.Windows.Forms.GroupBox
	  Private WithEvents _btnColor As System.Windows.Forms.Button
	  Private _lblColor As System.Windows.Forms.Label
	  Private _lblType As System.Windows.Forms.Label
	  Private _cmbType As System.Windows.Forms.ComboBox
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace