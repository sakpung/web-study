Imports Microsoft.VisualBasic
Imports System
Namespace ImageProcessingDemo
   Public Partial Class ImpressionistDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImpressionistDialog))
            Me._gbHorizontal = New System.Windows.Forms.GroupBox
            Me._txbHorizontal = New System.Windows.Forms.TextBox
            Me._tbHorizontal = New System.Windows.Forms.TrackBar
            Me._gbVertical = New System.Windows.Forms.GroupBox
            Me._txbVertical = New System.Windows.Forms.TextBox
            Me._tbVertical = New System.Windows.Forms.TrackBar
            Me._btnok = New System.Windows.Forms.Button
            Me._btncancel = New System.Windows.Forms.Button
            Me._gbHorizontal.SuspendLayout()
            CType(Me._tbHorizontal, System.ComponentModel.ISupportInitialize).BeginInit()
            Me._gbVertical.SuspendLayout()
            CType(Me._tbVertical, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_gbHorizontal
            '
            Me._gbHorizontal.Controls.Add(Me._txbHorizontal)
            Me._gbHorizontal.Controls.Add(Me._tbHorizontal)
            Me._gbHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbHorizontal.Location = New System.Drawing.Point(10, 2)
            Me._gbHorizontal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbHorizontal.Name = "_gbHorizontal"
            Me._gbHorizontal.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbHorizontal.Size = New System.Drawing.Size(342, 63)
            Me._gbHorizontal.TabIndex = 0
            Me._gbHorizontal.TabStop = False
            Me._gbHorizontal.Text = "Horizontal size"
            '
            '_txbHorizontal
            '
            Me._txbHorizontal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbHorizontal.Location = New System.Drawing.Point(5, 20)
            Me._txbHorizontal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbHorizontal.Name = "_txbHorizontal"
            Me._txbHorizontal.Size = New System.Drawing.Size(67, 20)
            Me._txbHorizontal.TabIndex = 1
            '
            '_tbHorizontal
            '
            Me._tbHorizontal.Location = New System.Drawing.Point(77, 15)
            Me._tbHorizontal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbHorizontal.Name = "_tbHorizontal"
            Me._tbHorizontal.Size = New System.Drawing.Size(260, 45)
            Me._tbHorizontal.TabIndex = 0
            Me._tbHorizontal.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_gbVertical
            '
            Me._gbVertical.Controls.Add(Me._txbVertical)
            Me._gbVertical.Controls.Add(Me._tbVertical)
            Me._gbVertical.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._gbVertical.Location = New System.Drawing.Point(10, 71)
            Me._gbVertical.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbVertical.Name = "_gbVertical"
            Me._gbVertical.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._gbVertical.Size = New System.Drawing.Size(342, 72)
            Me._gbVertical.TabIndex = 1
            Me._gbVertical.TabStop = False
            Me._gbVertical.Text = "Vertical size"
            '
            '_txbVertical
            '
            Me._txbVertical.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me._txbVertical.Location = New System.Drawing.Point(5, 28)
            Me._txbVertical.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._txbVertical.Name = "_txbVertical"
            Me._txbVertical.Size = New System.Drawing.Size(67, 20)
            Me._txbVertical.TabIndex = 1
            '
            '_tbVertical
            '
            Me._tbVertical.Location = New System.Drawing.Point(77, 24)
            Me._tbVertical.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._tbVertical.Name = "_tbVertical"
            Me._tbVertical.Size = New System.Drawing.Size(260, 45)
            Me._tbVertical.TabIndex = 0
            Me._tbVertical.TickStyle = System.Windows.Forms.TickStyle.None
            '
            '_btnok
            '
            Me._btnok.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btnok.Location = New System.Drawing.Point(378, 10)
            Me._btnok.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btnok.Name = "_btnok"
            Me._btnok.Size = New System.Drawing.Size(72, 28)
            Me._btnok.TabIndex = 2
            Me._btnok.Text = "OK"
            Me._btnok.UseVisualStyleBackColor = True
            '
            '_btncancel
            '
            Me._btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me._btncancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me._btncancel.Location = New System.Drawing.Point(378, 47)
            Me._btncancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me._btncancel.Name = "_btncancel"
            Me._btncancel.Size = New System.Drawing.Size(72, 28)
            Me._btncancel.TabIndex = 3
            Me._btncancel.Text = "Cancel"
            Me._btncancel.UseVisualStyleBackColor = True
            '
            'ImpressionistDialog
            '
            Me.AcceptButton = Me._btnok
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.CancelButton = Me._btncancel
            Me.ClientSize = New System.Drawing.Size(460, 152)
            Me.Controls.Add(Me._btncancel)
            Me.Controls.Add(Me._btnok)
            Me.Controls.Add(Me._gbVertical)
            Me.Controls.Add(Me._gbHorizontal)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "ImpressionistDialog"
            Me.ShowIcon = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Impressionist"
            Me._gbHorizontal.ResumeLayout(False)
            Me._gbHorizontal.PerformLayout()
            CType(Me._tbHorizontal, System.ComponentModel.ISupportInitialize).EndInit()
            Me._gbVertical.ResumeLayout(False)
            Me._gbVertical.PerformLayout()
            CType(Me._tbVertical, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

	  #End Region

	  Private _gbHorizontal As System.Windows.Forms.GroupBox
	  Private WithEvents _txbHorizontal As System.Windows.Forms.TextBox
	  Private _gbVertical As System.Windows.Forms.GroupBox
	  Private WithEvents _txbVertical As System.Windows.Forms.TextBox
	  Private WithEvents _btnok As System.Windows.Forms.Button
	  Private WithEvents _btncancel As System.Windows.Forms.Button
	  Public WithEvents _tbHorizontal As System.Windows.Forms.TrackBar
	  Public WithEvents _tbVertical As System.Windows.Forms.TrackBar
   End Class
End Namespace