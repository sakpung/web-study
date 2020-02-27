Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Leadtools

<Serializable()>
Class ReviewParameters
   Private _answerVals As String
   Private _errors As List(Of String)
   Private _omrValues As List(Of String)
   Private _owningId As String
   Private _reviewRequired As Boolean
   Private _pageNumber As Integer
   Private _erroredParams As VerificationParameters

   Public ReadOnly Property Errors As List(Of String)
      Get
         Return _errors
      End Get
   End Property

   Public ReadOnly Property AnswerVals As String
      Get
         Return _answerVals
      End Get
   End Property

   Public ReadOnly Property OmrFieldValues As List(Of String)
      Get
         Return _omrValues
      End Get
   End Property

   Public ReadOnly Property OwningId As String
      Get
         Return _owningId
      End Get
   End Property

   Public Property ReviewRequired As Boolean
      Get
         Return _reviewRequired
      End Get
      Set(ByVal value As Boolean)
         _reviewRequired = value
      End Set
   End Property

   Public ReadOnly Property PageNumber As Integer
      Get
         Return _pageNumber
      End Get
   End Property

   Public Property ErroredParameters As VerificationParameters
      Get
         Return _erroredParams
      End Get
      Set(ByVal value As VerificationParameters)
         _erroredParams = value
      End Set
   End Property

   Public Sub New(ByVal list As List(Of String), ByVal errors As List(Of String), ByVal answerVals As String, ByVal id As String, ByVal erroredParams As VerificationParameters, ByVal pageNumber As Integer)
      _omrValues = list
      _errors = errors
      _answerVals = answerVals
      _owningId = id
      _erroredParams = erroredParams
      _pageNumber = pageNumber
      reviewRequired = errors.Count > 0
   End Sub
End Class
