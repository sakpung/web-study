Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class GaussianDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GaussianDialog))
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gbRadius = New System.Windows.Forms.GroupBox
            Me._txbRadius = New System.Windows.Forms.TextBox
            Me._tbRadius = New System.Windows.Forms.TrackBar
            Me._gbRadius.SuspendLayout()
            CType(Me._tbRadius, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(411, 39)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(75, 23)
            Me._btnCancel.TabIndex = 5
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(411, 11)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(75, 23)
            Me._btnOk.TabIndex = 4
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_gbRadius
            '
            Me._gbRadius.Controls.Add(Me._txbRadius)
            Me._gbRadius.Controls.Add(Me._tbRadius)
            Me._gbRadius.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbRadius.Location = New System.Drawing.Point(10, 2)
            Me._gbRadius.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRadius.Name = "_gbRadius"
            Me._gbRadius.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbRadius.Size = New System.Drawing.Size(383, 69)
            Me._gbRadius.TabIndex = 6
            Me._gbRadius.TabStop = False
            Me._gbRadius.Text = "Radius"
            '
            '_txbRadius
            '
            Me._txbRadius.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbRadius.Location = New System.Drawing.Point(13, 19)
            Me._txbRadius.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbRadius.Name = "_txbRadius"
            Me._txbRadius.Size = New System.Drawing.Size(59, 20)
            Me._txbRadius.TabIndex = 1
            '
            '_tbRadius
            '
            Me._tbRadius.Location = New System.Drawing.Point(80, 15)
            Me._tbRadius.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbRadius.Maximum = 1000
            Me._tbRadius.Minimum = 1
            Me._tbRadius.Name = "_tbRadius"
            Me._tbRadius.Size = New System.Drawing.Size(283, 45)
            Me._tbRadius.TabIndex = 0
            Me._tbRadius.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbRadius.Value = 1
            '
            'GaussianDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(495, 83)
            Me.Controls.Add(Me._gbRadius)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "GaussianDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Gaussian"
            Me._gbRadius.ResumeLayout(False)
            Me._gbRadius.PerformLayout()
            CType(Me._tbRadius, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbRadius As System.Windows.Forms.GroupBox
	  Private WithEvents _txbRadius As System.Windows.Forms.TextBox
	  Public WithEvents _tbRadius As System.Windows.Forms.TrackBar
   End Class
End Namespace