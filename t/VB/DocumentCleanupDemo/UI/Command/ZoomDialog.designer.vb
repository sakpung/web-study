Imports Microsoft.VisualBasic
Imports System
Namespace DocumentCleanupDemo
   Public Partial Class ZoomDialog
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
		  Me._btnCancel = New System.Windows.Forms.Button()
		  Me._btnOk = New System.Windows.Forms.Button()
		  Me._gbOptions = New System.Windows.Forms.GroupBox()
		  Me._tbZoom = New System.Windows.Forms.TrackBar()
		  Me._tbPercentage = New System.Windows.Forms.TextBox()
		  Me._lblZoom = New System.Windows.Forms.Label()
		  Me._gbOptions.SuspendLayout()
		  CType(Me._tbZoom, System.ComponentModel.ISupportInitialize).BeginInit()
		  Me.SuspendLayout()
		  ' 
		  ' _btnCancel
		  ' 
		  Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		  Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		  Me._btnCancel.Location = New System.Drawing.Point(365, 55)
		  Me._btnCancel.Name = "_btnCancel"
		  Me._btnCancel.Size = New System.Drawing.Size(90, 27)
		  Me._btnCancel.TabIndex = 2
		  Me._btnCancel.Text = "Cancel"
		  Me._btnCancel.UseVisualStyleBackColor = True
		  ' 
		  ' _btnOk
		  ' 
		  Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
		  Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
		  Me._btnOk.Location = New System.Drawing.Point(365, 18)
		  Me._btnOk.Name = "_btnOk"
		  Me._btnOk.Size = New System.Drawing.Size(90, 27)
		  Me._btnOk.TabIndex = 1
		  Me._btnOk.Text = "OK"
		  Me._btnOk.UseVisualStyleBackColor = True
'		  Me._btnOk.Click += New System.EventHandler(_btnOk_Click);
		  ' 
		  ' _gbOptions
		  ' 
		  Me._gbOptions.Controls.Add(Me._tbZoom)
		  Me._gbOptions.Controls.Add(Me._tbPercentage)
		  Me._gbOptions.Controls.Add(Me._lblZoom)
		  Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
		  Me._gbOptions.Location = New System.Drawing.Point(6, 0)
		  Me._gbOptions.Name = "_gbOptions"
		  Me._gbOptions.Size = New System.Drawing.Size(344, 119)
		  Me._gbOptions.TabIndex = 0
		  Me._gbOptions.TabStop = False
		  ' 
		  ' _tbZoom
		  ' 
		  Me._tbZoom.Location = New System.Drawing.Point(14, 54)
		  Me._tbZoom.Maximum = 30000
		  Me._tbZoom.Minimum = 5
		  Me._tbZoom.Name = "_tbZoom"
		  Me._tbZoom.Size = New System.Drawing.Size(317, 56)
		  Me._tbZoom.TabIndex = 2
		  Me._tbZoom.TickStyle = System.Windows.Forms.TickStyle.None
		  Me._tbZoom.Value = 5
'		  Me._tbZoom.Scroll += New System.EventHandler(Me._tbZoom_Scroll);
		  ' 
		  ' _tbPercentage
		  ' 
		  Me._tbPercentage.Location = New System.Drawing.Point(110, 17)
		  Me._tbPercentage.Name = "_tbPercentage"
		  Me._tbPercentage.Size = New System.Drawing.Size(120, 22)
		  Me._tbPercentage.TabIndex = 1
'		  Me._tbPercentage.KeyPress += New System.Windows.Forms.KeyPressEventHandler(Me._tbPercentage_KeyPress);
'		  Me._tbPercentage.TextChanged += New System.EventHandler(Me._tbPercentage_TextChanged);
		  ' 
		  ' _lblZoom
		  ' 
		  Me._lblZoom.FlatStyle = System.Windows.Forms.FlatStyle.System
		  Me._lblZoom.Location = New System.Drawing.Point(14, 16)
		  Me._lblZoom.Name = "_lblZoom"
		  Me._lblZoom.Size = New System.Drawing.Size(87, 27)
		  Me._lblZoom.TabIndex = 0
		  Me._lblZoom.Text = "&Percentage:"
		  Me._lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		  ' 
		  ' ZoomDialog
		  ' 
		  Me.AcceptButton = Me._btnOk
		  Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		  Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		  Me.CancelButton = Me._btnCancel
		  Me.ClientSize = New System.Drawing.Size(464, 128)
		  Me.Controls.Add(Me._gbOptions)
		  Me.Controls.Add(Me._btnCancel)
		  Me.Controls.Add(Me._btnOk)
		  Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		  Me.MaximizeBox = False
		  Me.MinimizeBox = False
		  Me.Name = "ZoomDialog"
		  Me.ShowInTaskbar = False
		  Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		  Me.Text = "Zoom"
'		  Me.Load += New System.EventHandler(Me.ZoomDialog_Load);
		  Me._gbOptions.ResumeLayout(False)
		  Me._gbOptions.PerformLayout()
		  CType(Me._tbZoom, System.ComponentModel.ISupportInitialize).EndInit()
		  Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _btnCancel As System.Windows.Forms.Button
	  Private WithEvents _btnOk As System.Windows.Forms.Button
	  Private _gbOptions As System.Windows.Forms.GroupBox
	  Private WithEvents _tbZoom As System.Windows.Forms.TrackBar
	  Private WithEvents _tbPercentage As System.Windows.Forms.TextBox
	  Private _lblZoom As System.Windows.Forms.Label
   End Class
End Namespace