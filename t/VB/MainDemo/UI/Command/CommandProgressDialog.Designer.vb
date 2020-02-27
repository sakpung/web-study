Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class CommandProgressDialog
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
		 Me._progressBarCommand = New System.Windows.Forms.ProgressBar()
		 Me.SuspendLayout()
		 ' 
		 ' _btnCancel
		 ' 
		 Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		 Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
		 Me._btnCancel.Location = New System.Drawing.Point(200, 46)
		 Me._btnCancel.Name = "_btnCancel"
		 Me._btnCancel.Size = New System.Drawing.Size(90, 27)
		 Me._btnCancel.TabIndex = 4
		 Me._btnCancel.Text = "Cancel"
		 Me._btnCancel.UseVisualStyleBackColor = True
'		 Me._btnCancel.Click += New System.EventHandler(Me._btnCancel_Click);
		 ' 
		 ' _progressBarCommand
		 ' 
		 Me._progressBarCommand.Location = New System.Drawing.Point(10, 9)
		 Me._progressBarCommand.Name = "_progressBarCommand"
		 Me._progressBarCommand.Size = New System.Drawing.Size(470, 27)
		 Me._progressBarCommand.TabIndex = 5
		 ' 
		 ' CommandProgressDialog
		 ' 
		 Me.AcceptButton = Me._btnCancel
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.CancelButton = Me._btnCancel
		 Me.ClientSize = New System.Drawing.Size(489, 79)
		 Me.Controls.Add(Me._progressBarCommand)
		 Me.Controls.Add(Me._btnCancel)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		 Me.MaximizeBox = False
		 Me.MinimizeBox = False
		 Me.Name = "CommandProgressDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		 Me.Text = "Processing..."
'		 Me.Load += New System.EventHandler(Me.CommandProgressDialog_Load);
		 Me.ResumeLayout(False)

	  End Sub
	  #End Region

	  Private WithEvents _btnCancel As System.Windows.Forms.Button
	  Private _progressBarCommand As System.Windows.Forms.ProgressBar
   End Class
End Namespace