Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Public Class WizardStep
   Inherits UserControl

   Public Event CanProceed As EventHandler(Of UpdatedEventArgs)
   Public Property Title As String

   Protected Sub New()
      AddHandler Me.VisibleChanged, AddressOf WizardStep_VisibleChanged
   End Sub

   Private Sub WizardStep_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
      If Visible Then
         OnCanProceed()
      End If
   End Sub

   Protected Overridable Sub OnCanProceed()
   End Sub

   Protected Sub OnCanProceed(ByVal canProceed As Boolean)
      RaiseEvent CanProceed(Me, New UpdatedEventArgs(canProceed))
   End Sub

   Private Sub InitializeComponent()
      Me.SuspendLayout()
      Me.Name = "WizardStep"
      Me.Size = New System.Drawing.Size(617, 198)
      Me.ResumeLayout(False)
   End Sub
End Class

Public Class UpdatedEventArgs
   Inherits EventArgs

   Public Property CanProceed As Boolean

   Public Sub New(ByVal canProceed As Boolean)
      Me.CanProceed = canProceed
   End Sub
End Class
