Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class EmbossDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmbossDialog))
            Me._tbDepth = New System.Windows.Forms.TrackBar
            Me._lblDepth = New System.Windows.Forms.Label
            Me._txbDepth = New System.Windows.Forms.TextBox
            Me._gbDepth = New System.Windows.Forms.GroupBox
            Me._lblDirection = New System.Windows.Forms.Label
            Me._cmbDirection = New System.Windows.Forms.ComboBox
            Me._btnOk = New System.Windows.Forms.Button
            Me._btnCancel = New System.Windows.Forms.Button
            CType(Me._tbDepth, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbDepth.SuspendLayout()
            Me.SuspendLayout()
            '
            '_tbDepth
            '
            Me._tbDepth.AutoSize = False
            Me._tbDepth.Location = New System.Drawing.Point(44, 11)
            Me._tbDepth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbDepth.Maximum = 1000
            Me._tbDepth.Name = "_tbDepth"
            Me._tbDepth.Size = New System.Drawing.Size(196, 27)
            Me._tbDepth.TabIndex = 0
            Me._tbDepth.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_lblDepth
            '
            Me._lblDepth.AutoSize = True
            Me._lblDepth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblDepth.Location = New System.Drawing.Point(11, 19)
            Me._lblDepth.Name = "_lblDepth"
            Me._lblDepth.Size = New System.Drawing.Size(36, 13)
            Me._lblDepth.TabIndex = 1
            Me._lblDepth.Text = "Depth"
            '
            '_txbDepth
            '
            Me._txbDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbDepth.Location = New System.Drawing.Point(243, 13)
            Me._txbDepth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbDepth.Name = "_txbDepth"
            Me._txbDepth.Size = New System.Drawing.Size(48, 20)
            Me._txbDepth.TabIndex = 2
            '
            '_gbDepth
            '
            Me._gbDepth.Controls.Add(Me._lblDirection)
            Me._gbDepth.Controls.Add(Me._cmbDirection)
            Me._gbDepth.Controls.Add(Me._tbDepth)
            Me._gbDepth.Controls.Add(Me._txbDepth)
            Me._gbDepth.Controls.Add(Me._lblDepth)
            Me._gbDepth.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbDepth.Location = New System.Drawing.Point(10, 10)
            Me._gbDepth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDepth.Name = "_gbDepth"
            Me._gbDepth.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbDepth.Size = New System.Drawing.Size(297, 94)
            Me._gbDepth.TabIndex = 3
            Me._gbDepth.TabStop = False
            '
            '_lblDirection
            '
            Me._lblDirection.AutoSize = True
            Me._lblDirection.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblDirection.Location = New System.Drawing.Point(11, 58)
            Me._lblDirection.Name = "_lblDirection"
            Me._lblDirection.Size = New System.Drawing.Size(49, 13)
            Me._lblDirection.TabIndex = 4
            Me._lblDirection.Text = "Direction"
            '
            '_cmbDirection
            '
            Me._cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me._cmbDirection.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._cmbDirection.FormattingEnabled = True
            Me._cmbDirection.Location = New System.Drawing.Point(69, 56)
            Me._cmbDirection.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._cmbDirection.Name = "_cmbDirection"
            Me._cmbDirection.Size = New System.Drawing.Size(183, 21)
            Me._cmbDirection.TabIndex = 3
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(312, 20)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(75, 27)
            Me._btnOk.TabIndex = 4
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(312, 52)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(75, 27)
            Me._btnCancel.TabIndex = 5
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            'EmbossDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(404, 110)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbDepth)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "EmbossDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Emboss"
            CType(Me._tbDepth, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbDepth.ResumeLayout(False)
            Me._gbDepth.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Public WithEvents _tbDepth As System.Windows.Forms.TrackBar
	  Private _lblDepth As System.Windows.Forms.Label
	  Private WithEvents _txbDepth As System.Windows.Forms.TextBox
	  Private _gbDepth As System.Windows.Forms.GroupBox
	  Private _lblDirection As System.Windows.Forms.Label
	  Private _cmbDirection As System.Windows.Forms.ComboBox
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button

   End Class
End Namespace