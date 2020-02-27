Imports Microsoft.VisualBasic
Imports System
Namespace Leadtools.Demos.Workstation
   Partial Public Class WorkstationSplashScreen
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
		 Me.SuspendLayout()
		 ' 
		 ' WorkstationSplashScreen
		 ' 
		 Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		 Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.BackgroundImage = Resources.SplashScreen_MedWorkViewer
		 Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
		 Me.ClientSize = New System.Drawing.Size(640, 400)
		 Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		 Me.Name = "WorkstationSplashScreen"
		 Me.ShowInTaskbar = False
		 Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		 Me.Text = "WorkstationSplashScreen"
		 Me.TopMost = True
		 Me.ResumeLayout(False)

	  End Sub

	  #End Region
   End Class
End Namespace