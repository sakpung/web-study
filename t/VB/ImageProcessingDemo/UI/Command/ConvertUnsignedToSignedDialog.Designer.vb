Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class ConvertUnsignedToSignedDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ConvertUnsignedToSignedDialog))
            Me._gbType = New System.Windows.Forms.GroupBox
            Me._cmbType = New System.Windows.Forms.ComboBox
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbType.SuspendLayout()
            Me.SuspendLayout()
            '
            '_gbType
            '
            Me._gbType.Controls.Add(Me._cmbType)
            Me._gbType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbType.Location = New System.Drawing.Point(10, 10)
            Me._gbType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbType.Name = "_gbType"
            Me._gbType.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbType.Size = New System.Drawing.Size(282, 59)
            Me._gbType.TabIndex = 0
            Me._gbType.TabStop = False
            Me._gbType.Text = "Type"
            '
            '_cmbType
            '
            Me._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbType.FormattingEnabled = True
            Me._cmbType.Location = New System.Drawing.Point(16, 22)
            Me._cmbType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbType.Name = "_cmbType"
            Me._cmbType.Size = New System.Drawing.Size(241, 21)
            Me._cmbType.TabIndex = 0
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(306, 46)
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
            Me._btnOk.Location = New System.Drawing.Point(306, 10)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(86, 27)
            Me._btnOk.TabIndex = 6
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'ConvertUnsignedToSignedDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(395, 77)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbType)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ConvertUnsignedToSignedDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Convert Unsigned To Signed"
            Me._gbType.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbType As System.Windows.Forms.GroupBox
	  Private _cmbType As System.Windows.Forms.ComboBox
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace