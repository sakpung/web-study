
Namespace AnimationDemo
   Partial Class ViewerForm
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
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
         Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(ViewerForm))
         Me.SuspendLayout()
         ' 
         ' ViewerForm
         ' 
         Me.ClientSize = New System.Drawing.Size(292, 260)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.Name = "ViewerForm"
         Me.ResumeLayout(False)

      End Sub

#End Region
   End Class
End Namespace