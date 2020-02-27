Namespace FusionDemo
   Partial Public Class CounterDialog
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
		 Me._progress = New System.Windows.Forms.ProgressBar()
		 Me._lblCounter = New System.Windows.Forms.Label()
		 Me.SuspendLayout()
		 ' 
		 ' _progress
		 ' 
		 Me._progress.Location = New System.Drawing.Point(10, 48)
		 Me._progress.Name = "_progress"
		 Me._progress.Size = New System.Drawing.Size(248, 16)
		 Me._progress.TabIndex = 0
		 ' 
		 ' _lblCounter
		 ' 
		 Me._lblCounter.Location = New System.Drawing.Point(41, 13)
		 Me._lblCounter.Name = "_lblCounter"
		 Me._lblCounter.Size = New System.Drawing.Size(181, 23)
		 Me._lblCounter.TabIndex = 1
		 ' 
		 ' CounterDialog
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		 Me.ClientSize = New System.Drawing.Size(268, 73)
		 Me.Controls.Add(Me._lblCounter)
		 Me.Controls.Add(Me._progress)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		 Me.Name = "CounterDialog"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		 Me.Text = "CounterDialog"
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region

	  Private _progress As System.Windows.Forms.ProgressBar
	  Private _lblCounter As System.Windows.Forms.Label
   End Class
End Namespace