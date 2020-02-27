Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class GammaCorrectDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GammaCorrectDialog))
            Me._gbGamma = New System.Windows.Forms.GroupBox
            Me._txbGamma = New System.Windows.Forms.TextBox
            Me._tbGamma = New System.Windows.Forms.TrackBar
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbGamma.SuspendLayout()
            CType(Me._tbGamma, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbGamma
            '
            Me._gbGamma.Controls.Add(Me._txbGamma)
            Me._gbGamma.Controls.Add(Me._tbGamma)
            Me._gbGamma.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbGamma.Location = New System.Drawing.Point(18, 10)
            Me._gbGamma.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbGamma.Name = "_gbGamma"
            Me._gbGamma.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbGamma.Size = New System.Drawing.Size(379, 63)
            Me._gbGamma.TabIndex = 0
            Me._gbGamma.TabStop = False
            Me._gbGamma.Text = "Gamma"
            '
            '_txbGamma
            '
            Me._txbGamma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbGamma.Location = New System.Drawing.Point(14, 19)
            Me._txbGamma.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbGamma.Name = "_txbGamma"
            Me._txbGamma.Size = New System.Drawing.Size(65, 20)
            Me._txbGamma.TabIndex = 1
            '
            '_tbGamma
            '
            Me._tbGamma.Location = New System.Drawing.Point(84, 13)
            Me._tbGamma.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbGamma.Maximum = 500
            Me._tbGamma.Minimum = 1
            Me._tbGamma.Name = "_tbGamma"
            Me._tbGamma.Size = New System.Drawing.Size(279, 45)
            Me._tbGamma.TabIndex = 0
            Me._tbGamma.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbGamma.Value = 1
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(413, 40)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(75, 23)
            Me._btnCancel.TabIndex = 9
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(413, 11)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(75, 23)
            Me._btnOk.TabIndex = 8
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'GammaCorrectDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(498, 82)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbGamma)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "GammaCorrectDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Gamma Correct"
            Me._gbGamma.ResumeLayout(False)
            Me._gbGamma.PerformLayout()
            CType(Me._tbGamma, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbGamma As System.Windows.Forms.GroupBox
	  Private WithEvents _txbGamma As System.Windows.Forms.TextBox
	  Public WithEvents _tbGamma As System.Windows.Forms.TrackBar
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace