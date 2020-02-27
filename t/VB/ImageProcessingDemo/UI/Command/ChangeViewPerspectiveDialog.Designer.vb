Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class ChangeViewPerspectiveDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangeViewPerspectiveDialog))
            Me._gbViewPerspective = New System.Windows.Forms.GroupBox
            Me._cmbViewPerspective = New System.Windows.Forms.ComboBox
            Me._btnok = New System.Windows.Forms.Button
            Me._btncancel = New System.Windows.Forms.Button
            Me._gbViewPerspective.SuspendLayout()
            Me.SuspendLayout()
            '
            '_gbViewPerspective
            '
            Me._gbViewPerspective.Controls.Add(Me._cmbViewPerspective)
            Me._gbViewPerspective.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbViewPerspective.Location = New System.Drawing.Point(3, 4)
            Me._gbViewPerspective.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbViewPerspective.Name = "_gbViewPerspective"
            Me._gbViewPerspective.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbViewPerspective.Size = New System.Drawing.Size(283, 60)
            Me._gbViewPerspective.TabIndex = 0
            Me._gbViewPerspective.TabStop = False
            Me._gbViewPerspective.Text = "ViewPerspective"
            '
            '_cmbViewPerspective
            '
            Me._cmbViewPerspective.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbViewPerspective.FormattingEnabled = True
            Me._cmbViewPerspective.Location = New System.Drawing.Point(15, 20)
            Me._cmbViewPerspective.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbViewPerspective.Name = "_cmbViewPerspective"
            Me._cmbViewPerspective.Size = New System.Drawing.Size(253, 21)
            Me._cmbViewPerspective.TabIndex = 0
            '
            '_btnok
            '
            Me._btnok.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnok.Location = New System.Drawing.Point(296, 10)
            Me._btnok.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnok.Name = "_btnok"
            Me._btnok.Size = New System.Drawing.Size(75, 20)
            Me._btnok.TabIndex = 1
            Me._btnok.Text = "OK"
            Me._btnok.UseVisualStyleBackColor = True
            '
            '_btncancel
            '
            Me._btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btncancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btncancel.Location = New System.Drawing.Point(296, 42)
            Me._btncancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btncancel.Name = "_btncancel"
            Me._btncancel.Size = New System.Drawing.Size(75, 20)
            Me._btncancel.TabIndex = 2
            Me._btncancel.Text = "Cancel"
            Me._btncancel.UseVisualStyleBackColor = True
            '
            'ChangeViewPerspectiveDialog
            '
            Me.AcceptButton = Me._btnok
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btncancel
            Me.ClientSize = New System.Drawing.Size(381, 67)
            Me.Controls.Add(Me._btncancel)
            Me.Controls.Add(Me._btnok)
            Me.Controls.Add(Me._gbViewPerspective)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ChangeViewPerspectiveDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "ChangeViewPerspective"
            Me._gbViewPerspective.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbViewPerspective As System.Windows.Forms.GroupBox
	  Private _cmbViewPerspective As System.Windows.Forms.ComboBox
	  Private WithEvents _btnok As System.Windows.Forms.Button
	  Private WithEvents _btncancel As System.Windows.Forms.Button
   End Class
End Namespace