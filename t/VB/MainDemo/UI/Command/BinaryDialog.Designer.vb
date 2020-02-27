Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class BinaryDialog
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
         Me._cbFilter = New System.Windows.Forms.ComboBox
         Me._lblFilter = New System.Windows.Forms.Label
         Me._gbOptions.SuspendLayout()
         Me.SuspendLayout()
         '
         '_btnCancel
         '
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(256, 40)
         Me._btnCancel.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
         Me._btnOk.Location = New System.Drawing.Point(256, 13)
         Me._btnOk.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.Size = New System.Drawing.Size(68, 22)
         Me._btnOk.TabIndex = 1
         Me._btnOk.Text = "OK"
         Me._btnOk.UseVisualStyleBackColor = True
         '
         '_gbOptions
         '
         Me._gbOptions.Controls.Add(Me._cbFilter)
         Me._gbOptions.Controls.Add(Me._lblFilter)
         Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbOptions.Location = New System.Drawing.Point(8, 7)
         Me._gbOptions.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._gbOptions.Size = New System.Drawing.Size(237, 60)
         Me._gbOptions.TabIndex = 0
         Me._gbOptions.TabStop = False
         '
         '_cbFilter
         '
         Me._cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._cbFilter.FormattingEnabled = True
         Me._cbFilter.Location = New System.Drawing.Point(80, 23)
         Me._cbFilter.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me._cbFilter.Name = "_cbFilter"
         Me._cbFilter.Size = New System.Drawing.Size(145, 21)
         Me._cbFilter.TabIndex = 1
         '
         '_lblFilter
         '
         Me._lblFilter.AutoSize = True
         Me._lblFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._lblFilter.Location = New System.Drawing.Point(14, 23)
         Me._lblFilter.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
         Me._lblFilter.Name = "_lblFilter"
         Me._lblFilter.Size = New System.Drawing.Size(31, 13)
         Me._lblFilter.TabIndex = 0
         Me._lblFilter.Text = "Filter"
         Me._lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         '
         'BinaryDialog
         '
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(339, 81)
         Me.Controls.Add(Me._gbOptions)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "BinaryDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Binary Filter Effects"
         Me._gbOptions.ResumeLayout(False)
         Me._gbOptions.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private _cbFilter As System.Windows.Forms.ComboBox
	  Private _lblFilter As System.Windows.Forms.Label
   End Class
End Namespace