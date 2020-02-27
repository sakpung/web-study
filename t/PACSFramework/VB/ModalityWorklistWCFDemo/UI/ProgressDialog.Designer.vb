Imports Microsoft.VisualBasic
Imports System
Namespace ModalityWorklistWCFDemo.UI
	Partial Public Class ProgressDialog
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
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
			Me.labelProgressInfo = New System.Windows.Forms.Label()
			Me.progressBar = New System.Windows.Forms.ProgressBar()
			Me.buttonCancel = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' labelProgressInfo
			' 
			Me.labelProgressInfo.AutoSize = True
			Me.labelProgressInfo.Location = New System.Drawing.Point(12, 29)
			Me.labelProgressInfo.Name = "labelProgressInfo"
			Me.labelProgressInfo.Size = New System.Drawing.Size(35, 13)
			Me.labelProgressInfo.TabIndex = 0
			Me.labelProgressInfo.Text = "label1"
			' 
			' progressBar
			' 
			Me.progressBar.Location = New System.Drawing.Point(15, 46)
			Me.progressBar.Name = "progressBar"
			Me.progressBar.Size = New System.Drawing.Size(363, 23)
			Me.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
			Me.progressBar.TabIndex = 1
			' 
			' buttonCancel
			' 
			Me.buttonCancel.Location = New System.Drawing.Point(302, 76)
			Me.buttonCancel.Name = "buttonCancel"
			Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
			Me.buttonCancel.TabIndex = 2
			Me.buttonCancel.Text = "Cancel"
			Me.buttonCancel.UseVisualStyleBackColor = True
'			Me.buttonCancel.Click += New System.EventHandler(Me.buttonCancel_Click);
			' 
			' ProgressDialog
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(390, 115)
			Me.Controls.Add(Me.buttonCancel)
			Me.Controls.Add(Me.progressBar)
			Me.Controls.Add(Me.labelProgressInfo)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "ProgressDialog"
			Me.ShowIcon = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "ProgressDialog"
'			Me.Shown += New System.EventHandler(Me.ProgressDialog_Shown);
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private labelProgressInfo As System.Windows.Forms.Label
		Private progressBar As System.Windows.Forms.ProgressBar
		Private WithEvents buttonCancel As System.Windows.Forms.Button
	End Class
End Namespace