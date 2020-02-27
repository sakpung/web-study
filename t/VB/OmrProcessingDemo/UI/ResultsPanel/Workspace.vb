Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Forms.Processing.Omr
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Leadtools.Forms.Processing.Omr.Fields
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.CompilerServices

<Serializable()> _
Public Class Workspace

   <NonSerialized()> _
   Private _imageManager As IImageManager

   <NonSerialized()> _
   Public Const IMGMGR_ANSWERS As String = "Answers"

   <NonSerialized()> _
   Private _template As ITemplateForm

   <NonSerialized()> _
   Private _answers As IRecognitionForm

   <NonSerialized()> _
   Private _results As List(Of IRecognitionForm)

   <NonSerialized()> _
   Private _templateImage As RasterImage

   <NonSerialized()> _
   Private _extractor As ExtractReviewCollectionOperation

   <NonSerialized()> _
   Private _omrProcessor As ProcessOmrDocumentsOperation

   <NonSerialized()> _
   Private _images As Dictionary(Of String, String)

   <NonSerialized()> _
   Private _answerReviewCounts As ReviewCounter

   <NonSerialized()> _
   Private _resultReviewCounts As ReviewCounter

   Public ReadOnly Property Template As ITemplateForm
      Get
         Return _template
      End Get
   End Property

   Public ReadOnly Property Answers As IRecognitionForm
      Get
         Return _answers
      End Get
   End Property

   Public ReadOnly Property Results As List(Of IRecognitionForm)
      Get
         Return _results
      End Get
   End Property

   Public ReadOnly Property ErrorList As List(Of String)
      Get
         If _omrProcessor IsNot Nothing Then
            Return _omrProcessor.ErrorList
         Else
            Return New List(Of String)
         End If
      End Get
   End Property

   ' serialized
   'private string workspaceName;
   Private _answerkeyPath As String

   Private _templateBytes As Byte()

   Private _answerBytes As Byte()

   Private _resultsBytes As Byte()()

   Private _filepathDictionaryBytes As Byte()

   Private _filenames As List(Of String)

   Private _verificationParameters As VerificationParameters

   Private _reviewRequiredStatus As Boolean()()()()

   Private _locationOnDisk As String

   Public ReadOnly Property LocationOnDisk As String
      Get
         Return _locationOnDisk
      End Get
   End Property

   Private _passingGrade As Integer
   Public Property PassingGrade As Integer
      Get
         Return _passingGrade
      End Get
      Set(value As Integer)
         _passingGrade = value
      End Set
   End Property

   Public ReadOnly Property TemplateImage As RasterImage
      Get
         Return _templateImage
      End Get
   End Property

   Public ReadOnly Property ImageManager As IImageManager
      Get
         Return _imageManager
      End Get
   End Property

   Public ReadOnly Property AnswerKeyPath As String
      Get
         Return _answerkeyPath
      End Get
   End Property

   Public Property VerificationParameters As VerificationParameters
      Get
         Return _verificationParameters
      End Get
      Set(value As VerificationParameters)
         _verificationParameters = value
      End Set
   End Property

   Public ReadOnly Property AnswerReviewCounts As ReviewCounter
      Get
         Return _answerReviewCounts
      End Get
   End Property

   Public ReadOnly Property ResultsReviewCounts As ReviewCounter
      Get
         Return _resultReviewCounts
      End Get
   End Property

   Public ReadOnly Property AnswersPresent As Boolean
      Get
         Return ((Not (_answers) Is Nothing) _
                     AndAlso ((Not (_answers.Pages) Is Nothing) _
                     AndAlso (_answers.Pages.Count > 0)))
      End Get
   End Property

   Public Sub New()
      MyBase.New()
      Me.InitializeDefaults()
   End Sub

   Public Sub InitializeDefaults()
      _imageManager = New MemoryImageManager
      _images = New Dictionary(Of String, String)
      _template = MainForm.GetOmrEngine.CreateTemplateForm
      _answers = MainForm.GetOmrEngine.CreateRecognitionForm
      _results = New List(Of IRecognitionForm)
   End Sub

   Public Sub New(ByVal ip As InputPanel, ByVal kp As KeyPanel, ByVal currentTemplate As ITemplateForm)
      MyBase.New()
      Me.InitializeDefaults()

      Dim i As Integer = 0
      Do While (i < ip.SelectedInputs.Count)
         Dim guidV As String = Guid.NewGuid.ToString
         _imageManager.Add(guidV, ip.SelectedInputs(i))
         _images.Add(guidV, ip.SelectedInputs(i))
         i = (i + 1)
      Loop

      If (Not (kp.AnswerImage) Is Nothing) Then
         _imageManager.Add(Workspace.IMGMGR_ANSWERS, kp.AnswerImagePath)
         _answerkeyPath = kp.AnswerImagePath
      End If

      _omrProcessor = New ProcessOmrDocumentsOperation(kp.AnswerImage, currentTemplate, _imageManager, _images)
      Me.PassingGrade = kp.PassingGrade
      _verificationParameters = VerificationParameters.GetTemplate(VerificationParameters.FilterTemplate.CommonIssues)
   End Sub

   Public Sub Process()
      _omrProcessor.Start()
      _template = _omrProcessor.TemplateForm
      _answers = _omrProcessor.Answers
      _results = _omrProcessor.Results
      Me.ReprocessVerification(VerificationParameters.AllParameters, _answers, _results)
   End Sub

   Public Sub UpdateAnswerKey(ByVal pid As KeyPanel)
      If (Not (pid.AnswerImage) Is Nothing) Then
         _imageManager.Add(Workspace.IMGMGR_ANSWERS, pid.AnswerImagePath)
         _answerkeyPath = pid.AnswerImagePath
      End If

      Dim podo As ProcessOmrDocumentsOperation = New ProcessOmrDocumentsOperation(pid.AnswerImage, _template, _imageManager, Nothing)
      podo.Start()
      _answers = podo.Answers
      Me.ReprocessVerification(VerificationParameters.AllParameters, _answers, _results)
   End Sub

   Public Sub ReprocessVerification(ByVal parameters As VerificationParameters, ByVal ans As IRecognitionForm, ByVal res As List(Of IRecognitionForm))
      _extractor = New ExtractReviewCollectionOperation(_answers, _results, _verificationParameters)
      _extractor.Start()
      _answerReviewCounts = _extractor.AnswerReviewCount
      _resultReviewCounts = _extractor.ResultsReviewCount
   End Sub

   Private Function Convertor(ByRef oc As Forms.Processing.Omr.Fields.OmrCollection) As Boolean
      Dim rp As ReviewParameters = CType(oc.Tag, ReviewParameters)
      If (rp IsNot Nothing) Then Return rp.ReviewRequired Else Return False
   End Function

   ' this prepares the workspace for serialization to disk
   Public Sub Pack(ByVal filename As String)
      _locationOnDisk = filename
      _filenames = New List(Of String)
      Dim ms As MemoryStream = New MemoryStream
      _template.Save(ms)
      _templateBytes = ms.GetBuffer
      ms.Close()
      If (Not (_answers) Is Nothing) Then
         ms = New MemoryStream
         _answers.Save(ms)
         _answerBytes = ms.GetBuffer
         ms.Close()
      End If

      ms = New MemoryStream()
      Dim bf As BinaryFormatter = New BinaryFormatter
      bf.Serialize(ms, _images)
      _filepathDictionaryBytes = ms.GetBuffer
      ms.Close()

      _reviewRequiredStatus = New Boolean(Results.Count - 1)()()() {}
      _resultsBytes = New Byte((_results.Count) - 1)() {}
      Dim i As Integer = 0
      Do While (i < _results.Count)
         Dim frm As IRecognitionForm = _results(i)
         _reviewRequiredStatus(i) = New Boolean((frm.Pages.Count) - 1)()() {}
         Dim j As Integer = 0
         Do While (j < frm.Pages.Count)
            _reviewRequiredStatus(i)(j) = New Boolean((frm.Pages(j).Fields.Count) - 1)() {}
            Dim k As Integer = 0
            Do While (k < frm.Pages(j).Fields.Count)

               _reviewRequiredStatus(i)(j)(k) = CType(frm.Pages(j).Fields(k), OmrField).Fields.ConvertAll(Of Boolean)(Function(oc As OmrCollection)
                                                                                                                         Dim rp As ReviewParameters = CType(oc.Tag, ReviewParameters)
                                                                                                                         If (rp IsNot Nothing) Then Return rp.ReviewRequired Else Return False
                                                                                                                      End Function).ToArray()

               k = k + 1
            Loop

            j = (j + 1)
         Loop

         ms = New MemoryStream()
         frm.Save(ms)
         _resultsBytes(i) = ms.GetBuffer
         ms.Close()
         i = (i + 1)
      Loop
   End Sub

      ' this prepares a recently deserialized workspace for use
   Friend Sub Unpack()
      Me.InitializeDefaults()
      Dim ms As MemoryStream = New MemoryStream(_filepathDictionaryBytes)
      Dim bf As BinaryFormatter = New BinaryFormatter
      _images = CType(bf.Deserialize(ms), Dictionary(Of String, String))
      ms.Close()
      For Each key As String In _images.Keys
         _imageManager.Add(key, _images(key))
      Next
      If (String.IsNullOrWhiteSpace(_answerkeyPath) = False) Then
         _imageManager.Add(IMGMGR_ANSWERS, _answerkeyPath)
      End If

      _template = MainForm.GetOmrEngine.CreateTemplateForm
      _results = New List(Of IRecognitionForm)

      ms = New MemoryStream(_templateBytes)
      _template.Load(ms)
      _templateImage = _template.Pages(0).Image
      Dim i As Integer = 1
      Do While (i < _template.Pages.Count)
         _templateImage.AddPage(_template.Pages(i).Image)
         i = (i + 1)
      Loop

      If (Not (_answerBytes) Is Nothing) Then
         _answers = MainForm.GetOmrEngine.CreateRecognitionForm
         ms = New MemoryStream(_answerBytes)
         _answers.Load(ms)
         _answerReviewCounts = Workspace.GetManualReviewCollection(_answers, VerificationParameters.AllParameters)
      End If

      _resultReviewCounts = New ReviewCounter
      i = 0
      Do While (i < _resultsBytes.Length)
         ms = New MemoryStream(_resultsBytes(i))
         Dim frm As IRecognitionForm = MainForm.GetOmrEngine.CreateRecognitionForm
         frm.Load(ms)
         _resultReviewCounts = _resultReviewCounts + Workspace.GetManualReviewCollection(frm, VerificationParameters.AllParameters, _answers, _reviewRequiredStatus(i))
         _results.Add(frm)
         i = (i + 1)
      Loop
   End Sub

   Public Structure ReviewCounter

      Public Property AgreeWithKey As Integer
      Public Property DisagreeWithKey As Integer
      Public Property NotExactlyOneBubble As Integer
      Public Property BelowThreshold As Integer

      Public ReadOnly Property Total As Integer
         Get
            Return AgreeWithKey + DisagreeWithKey + NotExactlyOneBubble + BelowThreshold
         End Get
      End Property

      Public Property TotalCounts As Integer

      Public ReadOnly Property IsEmpty As Boolean
         Get
            Return ((Me.AgreeWithKey = 0) _
                        AndAlso ((Me.DisagreeWithKey = 0) _
                        AndAlso ((Me.BelowThreshold = 0) _
                        AndAlso (Me.NotExactlyOneBubble = 0))))
         End Get
      End Property


      Public Shared Operator +(ByVal a As ReviewCounter, ByVal b As ReviewCounter) As ReviewCounter
         Dim sum As ReviewCounter = New ReviewCounter()

         sum.AgreeWithKey = a.AgreeWithKey + b.AgreeWithKey
         sum.DisagreeWithKey = a.DisagreeWithKey + b.DisagreeWithKey
         sum.BelowThreshold = a.BelowThreshold + b.BelowThreshold
         sum.NotExactlyOneBubble = a.NotExactlyOneBubble + b.NotExactlyOneBubble
         sum.TotalCounts = a.TotalCounts + b.TotalCounts

         Return sum
      End Operator
   End Structure

   Public Shared Function GetManualReviewCollection(ByVal recognizeForm As IRecognitionForm, ByVal parameters As VerificationParameters, Optional ByVal answers As IRecognitionForm = Nothing, Optional ByVal reviewed()()() As Boolean = Nothing) As ReviewCounter
      Dim reviewCounter As ReviewCounter = New ReviewCounter
      Dim i As Integer = 0
      Do While (i < recognizeForm.Pages.Count)
         Dim page As Page = recognizeForm.Pages(i)
         Dim j As Integer = 0
         Do While (j < page.Fields.Count)
            Dim field As Field = page.Fields(j)
            field.PageNumber = page.PageNumber
            Dim omrField As OmrField = CType(field, OmrField)
            If (Not (omrField) Is Nothing) Then
               Dim k As Integer = 0
               Do While (k < omrField.Fields.Count)
                  Dim omr As OmrCollection = omrField.Fields(k)
                  reviewCounter.TotalCounts = (reviewCounter.TotalCounts + 1)
                  'string errors = "The field confidence value is below the required confidence value, the field does not have exactly one bubble filled in, the field has the same value as the answer key, the field has a different value from the answer key, ";
                  Dim errors As List(Of String) = New List(Of String)
                  Dim erroredParams As VerificationParameters = New VerificationParameters(False, False, False, False, parameters.Threshold, False, False)
                  Dim rp As ReviewParameters = Nothing
                  If (Not (omr.Tag) Is Nothing) Then
                     rp = CType(omr.Tag, ReviewParameters)
                     erroredParams = rp.ErroredParameters
                  End If

                  Dim answerVals As String = Nothing
                  erroredParams.Threshold = omr.Confidence
                  If (omr.Confidence < parameters.Threshold) Then
                     errors.Add("OMR confidence value too low")
                     erroredParams.UseThreshold = True
                     reviewCounter.BelowThreshold = (reviewCounter.BelowThreshold + 1)
                  End If

                  '                        if (parameters.UseExactlyOneBubble)
                  Dim selectedCells As Integer = omr.Fields.ToArray.Count(Function(bub As OmrBubble)
                                                                             Return bub.IsChecked
                                                                          End Function)

                  If (selectedCells <> 1) Then
                     errors.Add("Does not have exactly one bubble filled in")
                     erroredParams.UseExactlyOneBubble = True
                     reviewCounter.NotExactlyOneBubble = (reviewCounter.NotExactlyOneBubble + 1)
                  End If

                  erroredParams.UseValueChanged = (omr.Value <> omr.OriginalValue)
                  If ((Not (answers) Is Nothing) _
                              AndAlso (answers.Pages.Count > 0)) Then
                     Dim ansField As OmrField = CType(answers.Pages(i).Fields(j), OmrField)
                     Dim ofr As OmrFieldResult = CType(ansField.Result, OmrFieldResult)
                     Dim value As String = ansField.Fields(k).Value
                     answerVals = value
                     If (omr.Value = value) Then
                        errors.Add("Same value as answer key")
                        erroredParams.UseAgreeWithKey = True
                        reviewCounter.AgreeWithKey = (reviewCounter.AgreeWithKey + 1)
                     End If

                     If (omr.Value <> value) Then
                        errors.Add("Different value from answer key")
                        erroredParams.UseDisagreeWithKey = True
                        reviewCounter.DisagreeWithKey = (reviewCounter.DisagreeWithKey + 1)
                     End If

                  End If

                  'page.Image.Page = omrField.PageNumber + 1;
                  If (Not (rp) Is Nothing) Then
                     rp.ErroredParameters = erroredParams
                     omr.Tag = rp
                  Else
                     omr.Tag = New ReviewParameters(omrField.GetValues, errors, answerVals, recognizeForm.Id, erroredParams, page.PageNumber)
                  End If

                  If (errors.Count > 0) Then
                     If (Not (reviewed) Is Nothing) Then
                        Dim flag As Boolean = reviewed(i)(j)(k)
                        Dim rps As ReviewParameters = CType(omr.Tag, ReviewParameters)
                        rps.ReviewRequired = flag
                        Dim vp As VerificationParameters = rps.ErroredParameters
                        vp.IsReviewed = Not flag
                        rps.ErroredParameters = vp
                     End If

                  End If

                  k = (k + 1)
               Loop

            End If

            j = (j + 1)
         Loop

         i = (i + 1)
      Loop

      Return reviewCounter
   End Function

   Friend Function GetImageFilePath(ByVal guid As String) As String
      If _images.ContainsKey(guid) Then
         Return _images(guid)
      Else
         Return String.Empty
      End If
   End Function

   Friend Function DoGrading() As GradeOperation
      Dim grader As GradeOperation = New GradeOperation(_answers, _results, PassingGrade)
      Return grader
   End Function
End Class
