Partial Class PanViewerForm
   Private components As System.ComponentModel.IContainer = Nothing

   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso (components IsNot Nothing) Then
         components.Dispose()
      End If

      MyBase.Dispose(disposing)
   End Sub

   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PanViewerForm))
      Me.SuspendLayout()
      resources.ApplyResources(Me, "$this")
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "PanViewerForm"
      Me.ShowIcon = False
      Me.ShowInTaskbar = False
      Me.ResumeLayout(False)
   End Sub
End Class
