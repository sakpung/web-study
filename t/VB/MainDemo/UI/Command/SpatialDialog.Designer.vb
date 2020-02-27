Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class SpatialDialog
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
            Me._grbOptions = New System.Windows.Forms.GroupBox
            Me._cbFilter = New System.Windows.Forms.ComboBox
            Me._lblFilter = New System.Windows.Forms.Label
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._grbOptions.SuspendLayout()
            Me.SuspendLayout()
            '
            '_grbOptions
            '
            Me._grbOptions.Controls.Add(Me._cbFilter)
            Me._grbOptions.Controls.Add(Me._lblFilter)
            Me._grbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._grbOptions.Location = New System.Drawing.Point(12, 12)
            Me._grbOptions.Name = "_grbOptions"
            Me._grbOptions.Size = New System.Drawing.Size(374, 74)
            Me._grbOptions.TabIndex = 0
            Me._grbOptions.TabStop = False
            '
            '_cbFilter
            '
            Me._cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cbFilter.Location = New System.Drawing.Point(67, 28)
            Me._cbFilter.Name = "_cbFilter"
            Me._cbFilter.Size = New System.Drawing.Size(288, 24)
            Me._cbFilter.TabIndex = 1
            '
            '_lblFilter
            '
            Me._lblFilter.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblFilter.Location = New System.Drawing.Point(19, 28)
            Me._lblFilter.Name = "_lblFilter"
            Me._lblFilter.Size = New System.Drawing.Size(39, 26)
            Me._lblFilter.TabIndex = 0
            Me._lblFilter.Text = "Filter"
            Me._lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(405, 58)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(90, 27)
            Me._btnCancel.TabIndex = 2
            Me._btnCancel.Text = "Cancel"
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(405, 23)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(90, 27)
            Me._btnOk.TabIndex = 3
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'SpatialDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(507, 104)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._grbOptions)
            Me.Controls.Add(Me._btnCancel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "SpatialDialog"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Spatial"
            Me._grbOptions.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private _grbOptions As System.Windows.Forms.GroupBox
        Private _cbFilter As System.Windows.Forms.ComboBox
        Private _lblFilter As System.Windows.Forms.Label
        Private _btnCancel As System.Windows.Forms.Button
        Friend WithEvents _btnOk As System.Windows.Forms.Button
    End Class
End Namespace