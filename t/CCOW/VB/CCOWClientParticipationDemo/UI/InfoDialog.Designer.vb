Imports Microsoft.VisualBasic
Imports System
Namespace CCOWClientParticipationDemo.UI
	Public Partial Class InfoDialog
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfoDialog))
			Me.labelDescription = New System.Windows.Forms.Label()
			Me.progressBar1 = New System.Windows.Forms.ProgressBar()
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
			' InfoDialog
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(386, 94)
			Me.ControlBox = False
			Me.Controls.Add(Me.progressBar1)
			Me.Controls.Add(Me.labelDescription)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
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
	End Class
End Namespace