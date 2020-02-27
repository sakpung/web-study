Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class GrayScaleExtendedDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GrayScaleExtendedDialog))
            Me._gb1 = New System.Windows.Forms.GroupBox
            Me._numBlue = New System.Windows.Forms.NumericUpDown
            Me._numGreen = New System.Windows.Forms.NumericUpDown
            Me._numRed = New System.Windows.Forms.NumericUpDown
            Me._tbBlue = New System.Windows.Forms.TrackBar
            Me._tbGreen = New System.Windows.Forms.TrackBar
            Me._tbRed = New System.Windows.Forms.TrackBar
            Me._lblBlue = New System.Windows.Forms.Label
            Me._lblGreen = New System.Windows.Forms.Label
            Me._lblRed = New System.Windows.Forms.Label
            Me._btnCancel = New System.Windows.Forms.Button
            Me._btnOk = New System.Windows.Forms.Button
            Me._gb1.SuspendLayout()
            CType(Me._numBlue, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numGreen, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._numRed, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbBlue, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbGreen, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me._tbRed, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gb1
            '
            Me._gb1.Controls.Add(Me._numBlue)
            Me._gb1.Controls.Add(Me._numGreen)
            Me._gb1.Controls.Add(Me._numRed)
            Me._gb1.Controls.Add(Me._tbBlue)
            Me._gb1.Controls.Add(Me._tbGreen)
            Me._gb1.Controls.Add(Me._tbRed)
            Me._gb1.Controls.Add(Me._lblBlue)
            Me._gb1.Controls.Add(Me._lblGreen)
            Me._gb1.Controls.Add(Me._lblRed)
            Me._gb1.Location = New System.Drawing.Point(6, 10)
            Me._gb1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gb1.Name = "_gb1"
            Me._gb1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gb1.Size = New System.Drawing.Size(356, 155)
            Me._gb1.TabIndex = 0
            Me._gb1.TabStop = False
            '
            '_numBlue
            '
            Me._numBlue.Location = New System.Drawing.Point(303, 108)
            Me._numBlue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numBlue.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me._numBlue.Name = "_numBlue"
            Me._numBlue.Size = New System.Drawing.Size(44, 20)
            Me._numBlue.TabIndex = 8
            '
            '_numGreen
            '
            Me._numGreen.Location = New System.Drawing.Point(303, 64)
            Me._numGreen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numGreen.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me._numGreen.Name = "_numGreen"
            Me._numGreen.Size = New System.Drawing.Size(44, 20)
            Me._numGreen.TabIndex = 7
            '
            '_numRed
            '
            Me._numRed.Location = New System.Drawing.Point(303, 19)
            Me._numRed.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._numRed.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
            Me._numRed.Name = "_numRed"
            Me._numRed.Size = New System.Drawing.Size(44, 20)
            Me._numRed.TabIndex = 6
            '
            '_tbBlue
            '
            Me._tbBlue.AutoSize = False
            Me._tbBlue.Location = New System.Drawing.Point(57, 105)
            Me._tbBlue.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbBlue.Maximum = 1000
            Me._tbBlue.Name = "_tbBlue"
            Me._tbBlue.Size = New System.Drawing.Size(241, 32)
            Me._tbBlue.TabIndex = 5
            Me._tbBlue.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_tbGreen
            '
            Me._tbGreen.AutoSize = False
            Me._tbGreen.Location = New System.Drawing.Point(57, 63)
            Me._tbGreen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbGreen.Maximum = 1000
            Me._tbGreen.Name = "_tbGreen"
            Me._tbGreen.Size = New System.Drawing.Size(241, 32)
            Me._tbGreen.TabIndex = 4
            Me._tbGreen.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_tbRed
            '
            Me._tbRed.AutoSize = False
            Me._tbRed.Location = New System.Drawing.Point(57, 14)
            Me._tbRed.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbRed.Maximum = 1000
            Me._tbRed.Name = "_tbRed"
            Me._tbRed.Size = New System.Drawing.Size(241, 32)
            Me._tbRed.TabIndex = 3
            Me._tbRed.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_lblBlue
            '
            Me._lblBlue.AutoSize = True
            Me._lblBlue.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblBlue.Location = New System.Drawing.Point(15, 110)
            Me._lblBlue.Name = "_lblBlue"
            Me._lblBlue.Size = New System.Drawing.Size(28, 13)
            Me._lblBlue.TabIndex = 2
            Me._lblBlue.Text = "Blue"
            '
            '_lblGreen
            '
            Me._lblGreen.AutoSize = True
            Me._lblGreen.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblGreen.Location = New System.Drawing.Point(15, 64)
            Me._lblGreen.Name = "_lblGreen"
            Me._lblGreen.Size = New System.Drawing.Size(36, 13)
            Me._lblGreen.TabIndex = 1
            Me._lblGreen.Text = "Green"
            '
            '_lblRed
            '
            Me._lblRed.AutoSize = True
            Me._lblRed.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._lblRed.Location = New System.Drawing.Point(15, 20)
            Me._lblRed.Name = "_lblRed"
            Me._lblRed.Size = New System.Drawing.Size(27, 13)
            Me._lblRed.TabIndex = 0
            Me._lblRed.Text = "Red"
            '
            '_btnCancel
            '
            Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnCancel.Location = New System.Drawing.Point(218, 170)
            Me._btnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnCancel.Name = "_btnCancel"
            Me._btnCancel.Size = New System.Drawing.Size(71, 20)
            Me._btnCancel.TabIndex = 5
            Me._btnCancel.Text = "Cancel"
            Me._btnCancel.UseVisualStyleBackColor = True
            '
            '_btnOk
            '
            Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnOk.Location = New System.Drawing.Point(63, 170)
            Me._btnOk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnOk.Name = "_btnOk"
            Me._btnOk.Size = New System.Drawing.Size(70, 20)
            Me._btnOk.TabIndex = 4
            Me._btnOk.Text = "OK"
            Me._btnOk.UseVisualStyleBackColor = True
            '
            'GrayScaleExtendedDialog
            '
            Me.AcceptButton = Me._btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btnCancel
            Me.ClientSize = New System.Drawing.Size(372, 199)
            Me.Controls.Add(Me._btnCancel)
            Me.Controls.Add(Me._btnOk)
            Me.Controls.Add(Me._gb1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "GrayScaleExtendedDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "GrayScale Extended"
            Me._gb1.ResumeLayout(False)
            Me._gb1.PerformLayout()
            CType(Me._numBlue, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numGreen, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._numRed, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbBlue, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbGreen, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me._tbRed, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gb1 As System.Windows.Forms.GroupBox
	  Private WithEvents _numBlue As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numGreen As System.Windows.Forms.NumericUpDown
	  Private WithEvents _numRed As System.Windows.Forms.NumericUpDown
	  Private _lblBlue As System.Windows.Forms.Label
	  Private _lblGreen As System.Windows.Forms.Label
	  Private _lblRed As System.Windows.Forms.Label
	  Public WithEvents _tbBlue As System.Windows.Forms.TrackBar
	  Public WithEvents _tbGreen As System.Windows.Forms.TrackBar
	  Public WithEvents _tbRed As System.Windows.Forms.TrackBar
	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
   End Class
End Namespace