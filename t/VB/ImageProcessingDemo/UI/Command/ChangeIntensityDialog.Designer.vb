Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class ChangeIntensityDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangeIntensityDialog))
            Me._gbOptions = New System.Windows.Forms.GroupBox
            Me._lblBrightness = New System.Windows.Forms.Label
            Me._txbBrightness = New System.Windows.Forms.TextBox
            Me._tbBrightness = New System.Windows.Forms.TrackBar
            Me._btnOk = New System.Windows.Forms.Button
            Me._btnCancel = New System.Windows.Forms.Button
            Me._gbOptions.SuspendLayout()
            CType(Me._tbBrightness, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbOptions
            '
            Me._gbOptions.Controls.Add(Me._lblBrightness)
            Me._gbOptions.Controls.Add(Me._txbBrightness)
            Me._gbOptions.Controls.Add(Me._tbBrightness)
            Me._gbOptions.Location = New System.Drawing.Point(10, 10)
            Me._gbOptions.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptions.Name = "_gbOptions"
            Me._gbOptions.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbOptions.Size = New System.Drawing.Size(327, 74)
            Me._gbOptions.TabIndex = 3
            Me._gbOptions.TabStop = False
            '
            '_lblBrightness
            '
            Me._lblBrightness.AutoSize = True
            Me._lblBrightness.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblBrightness.Location = New System.Drawing.Point(5, 28)
            Me._lblBrightness.Name = "_lblBrightness"
            Me._lblBrightness.Size = New System.Drawing.Size(56, 13)
            Me._lblBrightness.TabIndex = 5
            Me._lblBrightness.Text = "Brightness"
            '
            '_txbBrightness
            '
            Me._txbBrightness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbBrightness.Location = New System.Drawing.Point(280, 24)
            Me._txbBrightness.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbBrightness.Name = "_txbBrightness"
            Me._txbBrightness.Size = New System.Drawing.Size(42, 20)
            Me._txbBrightness.TabIndex = 4
            '
            '_tbBrightness
            '
            Me._tbBrightness.AutoSize = False
            Me._tbBrightness.Location = New System.Drawing.Point(57, 22)
            Me._tbBrightness.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbBrightness.Maximum = 1000
            Me._tbBrightness.Minimum = -1000
            Me._tbBrightness.Name = "_tbBrightness"
            Me._tbBrightness.Size = New System.Drawing.Size(226, 37)
            Me._tbBrightness.TabIndex = 3
            Me._tbBrightness.TickStyle = System.Windows.Forms.TickStyle.None
            Me._tbBrightness.Value = 10
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(51, 97)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(72, 24)
            Me._btnOk.TabIndex = 4
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(186, 98)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(72, 23)
            Me._btnCancel.TabIndex = 5
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            'ChangeIntensityDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(345, 131)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gbOptions)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ChangeIntensityDialog"
            Me.ShowIcon = False
            Me.Text = "Form1"
            Me._gbOptions.ResumeLayout(False)
            Me._gbOptions.PerformLayout()
            CType(Me._tbBrightness, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Public _lblBrightness As System.Windows.Forms.Label
	  Private WithEvents _txbBrightness As System.Windows.Forms.TextBox
	  Public WithEvents _tbBrightness As System.Windows.Forms.TrackBar
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private WithEvents _btnCancel As System.Windows.Forms.Button

   End Class
End Namespace