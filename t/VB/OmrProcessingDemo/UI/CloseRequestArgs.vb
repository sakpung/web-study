Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Public Class CloseRequestArgs
   Inherits EventArgs

   Public Property ClosingState As ClosingReason

   Public Enum ClosingReason
      RevertToIntro
      ExplicitNew
      ToLoadExisting
      ApplicationExiting
   End Enum

   Public Sub New(ByVal closeState As ClosingReason)
      MyBase.New()
      Me.ClosingState = closeState
   End Sub
End Class
