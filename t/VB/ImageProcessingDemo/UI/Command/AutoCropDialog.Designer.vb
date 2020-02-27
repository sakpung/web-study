Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class AutoCropDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AutoCropDialog))
            Me._btnok = New System.Windows.Forms.Button
            Me._btncancel = New System.Windows.Forms.Button
            Me._gpThreshold = New System.Windows.Forms.GroupBox
            Me._txbThreshold = New System.Windows.Forms.TextBox
            Me._tbThreshold = New System.Windows.Forms.TrackBar
            Me._gpThreshold.SuspendLayout()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_btnok
            '
            Me._btnok.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnok.Location = New System.Drawing.Point(351, 16)
            Me._btnok.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnok.Name = "_btnok"
            Me._btnok.Size = New System.Drawing.Size(70, 24)
            Me._btnok.TabIndex = 0
            Me._btnok.Text = "OK"
            Me._btnok.UseVisualStyleBackColor = True
            '
            '_btncancel
            '
            Me._btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btncancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btncancel.Location = New System.Drawing.Point(351, 50)
            Me._btncancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btncancel.Name = "_btncancel"
            Me._btncancel.Size = New System.Drawing.Size(70, 24)
            Me._btncancel.TabIndex = 1
            Me._btncancel.Text = "cancel"
            Me._btncancel.UseVisualStyleBackColor = True
            '
            '_gpThreshold
            '
            Me._gpThreshold.Controls.Add(Me._txbThreshold)
            Me._gpThreshold.Controls.Add(Me._tbThreshold)
            Me._gpThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gpThreshold.Location = New System.Drawing.Point(10, 10)
            Me._gpThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gpThreshold.Name = "_gpThreshold"
            Me._gpThreshold.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gpThreshold.Size = New System.Drawing.Size(321, 63)
            Me._gpThreshold.TabIndex = 2
            Me._gpThreshold.TabStop = False
            Me._gpThreshold.Text = "Threshold"
            '
            '_txbThreshold
            '
            Me._txbThreshold.Location = New System.Drawing.Point(5, 19)
            Me._txbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbThreshold.Name = "_txbThreshold"
            Me._txbThreshold.Size = New System.Drawing.Size(61, 20)
            Me._txbThreshold.TabIndex = 1
            '
            '_tbThreshold
            '
            Me._tbThreshold.Location = New System.Drawing.Point(80, 13)
            Me._tbThreshold.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbThreshold.Maximum = 255
            Me._tbThreshold.Name = "_tbThreshold"
            Me._tbThreshold.Size = New System.Drawing.Size(236, 45)
            Me._tbThreshold.TabIndex = 0
            Me._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbThreshold.Value = 1
            '
            'AutoCropDialog
            '
            Me.AcceptButton = Me._btnok
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btncancel
            Me.ClientSize = New System.Drawing.Size(425, 85)
            Me.Controls.Add(Me._gpThreshold)
            Me.Controls.Add(Me._btncancel)
            Me.Controls.Add(Me._btnok)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AutoCropDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "AutoCrop"
            Me._gpThreshold.ResumeLayout(False)
            Me._gpThreshold.PerformLayout()
            CType(Me._tbThreshold, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private WithEvents _btnok As System.Windows.Forms.Button
	  Private WithEvents _btncancel As System.Windows.Forms.Button
	  Private _gpThreshold As System.Windows.Forms.GroupBox
	  Private WithEvents _txbThreshold As System.Windows.Forms.TextBox
	  Public WithEvents _tbThreshold As System.Windows.Forms.TrackBar
   End Class
End Namespace