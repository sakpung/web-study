Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class PanViewerForm
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
         Me.SuspendLayout()
         '
         'PanViewerForm
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(136, 162)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
         Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "PanViewerForm"
         Me.ShowIcon = False
         Me.ShowInTaskbar = False
         Me.Text = "PanViewerForm"
         Me.ResumeLayout(False)

      End Sub

	  #End Region
   End Class
End Namespace