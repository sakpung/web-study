Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos
	Public Partial Class ProgressInfoDialog
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
			Me.labelDescription = New System.Windows.Forms.Label()
			Me.progressBar1 = New System.Windows.Forms.ProgressBar()
			Me.buttonCancel = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' labelDescription
			' 
			Me.labelDescription.AutoSize = True
			Me.labelDescription.Location = New System.Drawing.Point(13, 13)
			Me.labelDescription.Name = "labelDescription"
			Me.labelDescription.Size = New System.Drawing.Size(0, 13)
			Me.labelDescription.TabIndex = 0
			' 
			' progressBar1
			' 
			Me.progressBar1.Location = New System.Drawing.Point(16, 39)
			Me.progressBar1.Name = "progressBar1"
			Me.progressBar1.Size = New System.Drawing.Size(352, 23)
			Me.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
			Me.progressBar1.TabIndex = 1
			' 
			' buttonCancel
			' 
			Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.buttonCancel.Location = New System.Drawing.Point(292, 78)
			Me.buttonCancel.Name = "buttonCancel"
			Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
			Me.buttonCancel.TabIndex = 2
			Me.buttonCancel.Text = "Cancel"
			Me.buttonCancel.UseVisualStyleBackColor = True
'			Me.buttonCancel.Click += New System.EventHandler(Me.buttonCancel_Click);
			' 
			' InfoDialog
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(386, 115)
			Me.Controls.Add(Me.buttonCancel)
			Me.Controls.Add(Me.progressBar1)
			Me.Controls.Add(Me.labelDescription)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "InfoDialog"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "InfoDialog"
'			Me.Shown += New System.EventHandler(Me.InfoDialog_Shown);
'			Me.FormClosed += New System.Windows.Forms.FormClosedEventHandler(Me.InfoDialog_FormClosed);
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private labelDescription As System.Windows.Forms.Label
		Private progressBar1 As System.Windows.Forms.ProgressBar
		Private WithEvents buttonCancel As System.Windows.Forms.Button
	End Class
End Namespace