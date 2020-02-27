Imports Leadtools.Forms.Processing.Omr.Fields
Imports Leadtools.Forms.Processing.Omr
Imports System
Imports System.Collections.Generic

Class ExtractReviewCollectionOperation
   Inherits BusyOperation

   Private answers As IRecognitionForm
   Private forms As List(Of IRecognitionForm)
   Private verificationParameters As VerificationParameters
   Public Property AnswerReviewCount As Workspace.ReviewCounter
   Public Property ResultsReviewCount As Workspace.ReviewCounter

   Public Sub New(ByVal answers As IRecognitionForm, ByVal forms As List(Of IRecognitionForm), ByVal verificationParameters As VerificationParameters)
      MyBase.New()
      Me.answers = answers
      Me.forms = forms
      Me.verificationParameters = verificationParameters
      useWaitWindow = False
   End Sub

   Protected Overrides Sub Run()
      Dim ticker As Integer = 0
      Dim stepVal As Integer = Math.Max(Convert.ToInt32(100 / ((If(forms Is Nothing OrElse forms.Count = 0, 1, forms.Count)) + (If(answers Is Nothing, 0, 1)))), 1)
      AnswerReviewCount = New Workspace.ReviewCounter()
      ResultsReviewCount = New Workspace.ReviewCounter()

      If answers IsNot Nothing Then
         ticker = ticker + stepVal
         Progress(ticker, "Analyzing key...")
         AnswerReviewCount = Workspace.GetManualReviewCollection(answers, verificationParameters)
      End If

      If forms Is Nothing OrElse forms.Count = 0 Then
         Return
      End If

      For i As Integer = 0 To forms.Count - 1
         Dim form As IRecognitionForm = forms(i)

         ticker = ticker + stepVal
         Progress(ticker, String.Format("Analyzing {0}...", form.Name))
         ResultsReviewCount = ResultsReviewCount + Workspace.GetManualReviewCollection(form, verificationParameters, answers)
      Next

      MyBase.Run()
   End Sub
End Class
