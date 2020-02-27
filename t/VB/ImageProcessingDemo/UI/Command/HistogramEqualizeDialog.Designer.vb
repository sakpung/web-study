Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class HistogramEqualizeDialog
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
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbOptions = New System.Windows.Forms.GroupBox
            Me._cmbColorSpace = New System.Windows.Forms.ComboBox
            Me._lblColorSpace = New System.Windows.Forms.Label
            Me._gbOptions.SuspendLayout()
            Me.SuspendLayout()
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(208, 45)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(68, 22)
            Me._btnCancel.TabIndex = 2
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(208, 15)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(68, 22)
            Me._btnOk.TabIndex = 1
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_gbOptions
            '
            Me._gbOptions.Controls.Add(Me._cmbColorSpace)
            Me._gbOptions.Controls.Add(Me._lblColorSpace)
            Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbOptions.Location = New System.Drawing.Point(8, 7)
            Me._gbOptions.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptions.Name = "_gbOptions"
            Me._gbOptions.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptions.Size = New System.Drawing.Size(180, 83)
            Me._gbOptions.TabIndex = 0
            Me._gbOptions.TabStop = False
            '
            '_cmbColorSpace
            '
            Me._cmbColorSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbColorSpace.FormattingEnabled = True
            Me._cmbColorSpace.Location = New System.Drawing.Point(15, 53)
            Me._cmbColorSpace.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbColorSpace.Name = "_cmbColorSpace"
            Me._cmbColorSpace.Size = New System.Drawing.Size(152, 21)
            Me._cmbColorSpace.TabIndex = 1
            '
            '_lblColorSpace
            '
            Me._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblColorSpace.Location = New System.Drawing.Point(15, 23)
            Me._lblColorSpace.Name = "_lblColorSpace"
            Me._lblColorSpace.Size = New System.Drawing.Size(65, 21)
            Me._lblColorSpace.TabIndex = 0
            Me._lblColorSpace.Text = "Color Space"
            Me._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'HistogramEqualizeDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(289, 106)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbOptions)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "HistogramEqualizeDialog"
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Histo Equalize"
            Me._gbOptions.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _cmbColorSpace As System.Windows.Forms.ComboBox
	  Private _lblColorSpace As System.Windows.Forms.Label
   End Class
End Namespace