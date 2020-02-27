Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class GrayScaleDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GrayScaleDialog))
            Me._lblBitsPerPixel = New System.Windows.Forms.Label
            Me._cmbBitsPerPixel = New System.Windows.Forms.ComboBox
            Me._btnOk = New System.Windows.Forms.Button
            Me._btnCancel = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            '_lblBitsPerPixel
            '
            Me._lblBitsPerPixel.AutoSize = True
            Me._lblBitsPerPixel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblBitsPerPixel.Location = New System.Drawing.Point(10, 27)
            Me._lblBitsPerPixel.Name = "_lblBitsPerPixel"
            Me._lblBitsPerPixel.Size = New System.Drawing.Size(68, 13)
            Me._lblBitsPerPixel.TabIndex = 0
            Me._lblBitsPerPixel.Text = "Bits Per Pixel"
            '
            '_cmbBitsPerPixel
            '
            Me._cmbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbBitsPerPixel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbBitsPerPixel.FormattingEnabled = True
            Me._cmbBitsPerPixel.Location = New System.Drawing.Point(87, 27)
            Me._cmbBitsPerPixel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbBitsPerPixel.Name = "_cmbBitsPerPixel"
            Me._cmbBitsPerPixel.Size = New System.Drawing.Size(181, 21)
            Me._cmbBitsPerPixel.TabIndex = 1
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(281, 10)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(70, 20)
            Me._btnOk.TabIndex = 2
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(281, 34)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(71, 20)
            Me._btnCancel.TabIndex = 3
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            'GrayScaleDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(362, 63)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._cmbBitsPerPixel)
            Me.Controls.Add(Me._lblBitsPerPixel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "GrayScaleDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "GrayScale"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

	  #End Region

	  Private _lblBitsPerPixel As System.Windows.Forms.Label
	  Private _cmbBitsPerPixel As System.Windows.Forms.ComboBox
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
   End Class
End Namespace