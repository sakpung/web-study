Imports Leadtools.Forms.Processing.Omr.Fields
Imports Leadtools.Forms.Processing.Omr
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Class GradeOperation
   Inherits BusyOperation

   Private resultsVar As List(Of IRecognitionForm)
   Private answers As IRecognitionForm
   Private omrAnalysisEngine As OmrAnalysisEngine
   Private statsStrArray As String(,)
   Private invertedStrStats As String(,)

   Public ReadOnly Property Results As List(Of IRecognitionForm)
      Get
         Return resultsVar
      End Get
   End Property

   Private passingScoreVal As Integer
   Private omrStatistics As OmrGradesStatistics

   Public ReadOnly Property PassingScore As Integer
      Get
         Return passingScoreVal
      End Get
   End Property

   Public ReadOnly Property Statistics As OmrGradesStatistics
      Get
         Return omrStatistics
      End Get
   End Property

   Public ReadOnly Property QuestionAnswers As Dictionary(Of String, QuestionAnswers)
      Get
         Return If(omrAnalysisEngine IsNot Nothing, omrAnalysisEngine.QuestionsAnswers, Nothing)
      End Get
   End Property

   Public ReadOnly Property StatsArray As String(,)
      Get
         Return statsStrArray
      End Get
   End Property

   Public ReadOnly Property InvertedStats As String(,)
      Get
         Return invertedStrStats
      End Get
   End Property

   Public Sub New(ByVal answerKey As IRecognitionForm, ByVal toGrade As List(Of IRecognitionForm), ByVal passingGrade As Integer)
      Me.answers = answerKey
      Me.resultsVar = toGrade
      Me.passingScoreVal = passingGrade
      useWaitWindow = False
   End Sub

   Protected Overrides Sub StartThread()
      Try
         Run()
      Catch ex As Exception
         ' don't interfere with exceptions to still generate as much info as possible
      Finally
         Complete()
      End Try
   End Sub

   Protected Overrides Sub Run()
      Dim stepVal As Integer = Math.Max(Convert.ToInt32(100 / (resultsVar.Count + 1)), 1)
      Progress(101, "Grading...")
      omrAnalysisEngine = New OmrAnalysisEngine(results, answers)
      omrAnalysisEngine.PassingScore = passingScore
      Generate()
      Invert()
      omrStatistics = omrAnalysisEngine.GradeForms()
      MyBase.Run()
   End Sub

   Private Sub Generate()
      Dim localQa As Dictionary(Of String, QuestionAnswers) = omrAnalysisEngine.QuestionsAnswers
      Dim detectedKeys As List(Of String) = New List(Of String)()

      For Each kvp As KeyValuePair(Of String, QuestionAnswers) In localQa
         detectedKeys.AddRange(kvp.Value.AnswersCount.Keys)
      Next

      detectedKeys = detectedKeys.Distinct().ToList()
      Dim length As Integer = detectedKeys.Count + 1
      Dim width As Integer = localQa.Count + 1
      statsStrArray = New String(length - 1, width - 1) {}
      Dim ticker As Integer = 1

      For Each kvp As KeyValuePair(Of String, QuestionAnswers) In localQa
         statsStrArray(0, ticker) = kvp.Key
         ticker += 1
      Next

      For i As Integer = 0 To detectedKeys.Count - 1
         Dim masterKey As String = detectedKeys(i)
         statsStrArray(i + 1, 0) = masterKey

         For j As Integer = 0 To width - 1
            Dim currentKey As String = statsStrArray(0, j)

            If currentKey Is Nothing OrElse localQa.ContainsKey(currentKey) = False Then
               Continue For
            End If

            Dim qa As QuestionAnswers = localQa(currentKey)

            If qa.AnswersCount Is Nothing OrElse qa.AnswersCount.ContainsKey(masterKey) = False Then
               Continue For
            End If

            statsStrArray(i + 1, j) = qa.AnswersCount(detectedKeys(i)).ToString()
         Next
      Next
   End Sub

   Private Sub Invert()
      Dim length As Integer = statsStrArray.GetLength(1)
      Dim width As Integer = statsStrArray.GetLength(0)
      invertedStrStats = New String(length - 1, width - 1) {}

      For i As Integer = 0 To length - 1

         For j As Integer = 0 To width - 1
            invertedStrStats(i, j) = statsStrArray(j, i)
         Next
      Next
   End Sub
End Class
