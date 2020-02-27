Imports Microsoft.VisualBasic
Imports System
Namespace MainDemo
   Public Partial Class ViewerForm
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
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewerForm))
         Me.SuspendLayout()
         '
         'ViewerForm
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(292, 272)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Name = "ViewerForm"
         Me.ShowInTaskbar = False
         Me.Text = "ViewerForm"
         Me.ResumeLayout(False)

      End Sub

	  #End Region
   End Class
End Namespace