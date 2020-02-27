Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class GammaCorrectExtendedDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GammaCorrectExtendedDialog))
            Me._gbGamma = New System.Windows.Forms.GroupBox
            Me._tbGamma = New System.Windows.Forms.TrackBar
            Me._txbGamma = New System.Windows.Forms.TextBox
            Me._gbType = New System.Windows.Forms.GroupBox
            Me._rbYuv = New System.Windows.Forms.RadioButton
            Me._rbRgb = New System.Windows.Forms.RadioButton
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbGamma.SuspendLayout()
            CType(Me._tbGamma, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbType.SuspendLayout()
            Me.SuspendLayout()
            '
            '_gbGamma
            '
            Me._gbGamma.Controls.Add(Me._tbGamma)
            Me._gbGamma.Controls.Add(Me._txbGamma)
            Me._gbGamma.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbGamma.Location = New System.Drawing.Point(10, 10)
            Me._gbGamma.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbGamma.Name = "_gbGamma"
            Me._gbGamma.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbGamma.Size = New System.Drawing.Size(366, 81)
            Me._gbGamma.TabIndex = 0
            Me._gbGamma.TabStop = False
            Me._gbGamma.Text = "Gamma"
            '
            '_tbGamma
            '
            Me._tbGamma.Location = New System.Drawing.Point(70, 24)
            Me._tbGamma.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbGamma.Maximum = 500
            Me._tbGamma.Minimum = 1
            Me._tbGamma.Name = "_tbGamma"
            Me._tbGamma.Size = New System.Drawing.Size(291, 45)
            Me._tbGamma.TabIndex = 1
            Me._tbGamma.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbGamma.Value = 1
            '
            '_txbGamma
            '
            Me._txbGamma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbGamma.Location = New System.Drawing.Point(5, 28)
            Me._txbGamma.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbGamma.Name = "_txbGamma"
            Me._txbGamma.Size = New System.Drawing.Size(60, 20)
            Me._txbGamma.TabIndex = 0
            '
            '_gbType
            '
            Me._gbType.Controls.Add(Me._rbYuv)
            Me._gbType.Controls.Add(Me._rbRgb)
            Me._gbType.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbType.Location = New System.Drawing.Point(10, 96)
            Me._gbType.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbType.Name = "_gbType"
            Me._gbType.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbType.Size = New System.Drawing.Size(366, 59)
            Me._gbType.TabIndex = 1
            Me._gbType.TabStop = False
            Me._gbType.Text = "Color Space"
            '
            '_rbYuv
            '
            Me._rbYuv.AutoSize = True
            Me._rbYuv.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbYuv.Location = New System.Drawing.Point(225, 30)
            Me._rbYuv.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbYuv.Name = "_rbYuv"
            Me._rbYuv.Size = New System.Drawing.Size(53, 18)
            Me._rbYuv.TabIndex = 1
            Me._rbYuv.TabStop = True
            Me._rbYuv.Text = "YUV"
            Me._rbYuv.UseVisualStyleBackColor = True
            '
            '_rbRgb
            '
            Me._rbRgb.AutoSize = True
            Me._rbRgb.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._rbRgb.Location = New System.Drawing.Point(22, 30)
            Me._rbRgb.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._rbRgb.Name = "_rbRgb"
            Me._rbRgb.Size = New System.Drawing.Size(54, 18)
            Me._rbRgb.TabIndex = 0
            Me._rbRgb.TabStop = True
            Me._rbRgb.Text = "RGB"
            Me._rbRgb.UseVisualStyleBackColor = True
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(381, 54)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(86, 27)
            Me._btnCancel.TabIndex = 9
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(381, 18)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(86, 27)
            Me._btnOk.TabIndex = 8
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'GammaCorrectExtendedDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(476, 165)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbType)
            Me.Controls.Add(Me._gbGamma)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "GammaCorrectExtendedDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Gamma Correct Extended"
            Me._gbGamma.ResumeLayout(False)
            Me._gbGamma.PerformLayout()
            CType(Me._tbGamma, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbType.ResumeLayout(False)
            Me._gbType.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbGamma As System.Windows.Forms.GroupBox
	  Private WithEvents _txbGamma As System.Windows.Forms.TextBox
	  Private _gbType As System.Windows.Forms.GroupBox
	  Private _rbYuv As System.Windows.Forms.RadioButton
	  Private _rbRgb As System.Windows.Forms.RadioButton
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Public WithEvents _tbGamma As System.Windows.Forms.TrackBar
   End Class
End Namespace