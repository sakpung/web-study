Imports Leadtools
Imports Leadtools.Ocr
Imports Leadtools.Forms.Processing.Omr
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports Leadtools.Forms.Processing.Omr.Fields
Imports Leadtools.ImageProcessing.Core

Class ProcessOmrDocumentsOperation
   Inherits BusyOperation

   Private _toLoad As Dictionary(Of String, String)
   Private _imageManager As IImageManager
   Private _key As RasterImage
   Private _errorList As List(Of String) = New List(Of String)()
   Private _templateForm As ITemplateForm
   Private _results As List(Of IRecognitionForm)
   Private _answers As IRecognitionForm

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

   Public Property TemplateForm As ITemplateForm
      Get
         Return _templateForm
      End Get
      Set(ByVal value As ITemplateForm)
         _templateForm = value
      End Set
   End Property

   Public ReadOnly Property ErrorList As List(Of String)
      Get
         Return _errorList
      End Get
   End Property

   Public Sub New(ByVal answerKey As RasterImage, ByVal template As ITemplateForm, ByVal imageManager As IImageManager, ByVal images As Dictionary(Of String, String))
      _imageManager = imageManager
      _key = answerKey
      _toLoad = images
      _templateForm = template
   End Sub

   Private Function RecognizeForm(ByVal formImage As RasterImage, ByVal id As String, ByVal name As String) As IRecognitionForm
      Dim recogForm As IRecognitionForm = MainForm.GetOmrEngine().CreateRecognitionForm()

      For i As Integer = 0 To formImage.PageCount - 1
         formImage.Page = i + 1
         Dim dskcmd As DeskewCommand = New DeskewCommand()
         dskcmd.FillColor = RasterColor.White
         dskcmd.Flags = DeskewCommandFlags.DoNotUseCheckDeskew
         dskcmd.Run(formImage)
         recogForm.Pages.AddPage(formImage)
      Next

      recogForm.Recognize(_templateForm)
      recogForm.Id = id
      recogForm.SaveEmbeddedImage = False
      recogForm.Name = name
      Return recogForm
   End Function

   Protected Overrides Sub Run()
      Dim checkAnswers As Boolean = _key IsNot Nothing
      Dim ticker As Integer = 0
      Dim stepVar As Integer = If(_toLoad Is Nothing, 101, Math.Max(CInt(100 / (_toLoad.Count + 2)), 1))

      ticker = ticker + stepVar
      Progress(ticker, "Initializing objects")

      If checkAnswers Then
         Progress(ticker, "Recognizing key")

         Try
            _answers = RecognizeForm(_key, Workspace.IMGMGR_ANSWERS, Workspace.IMGMGR_ANSWERS)
         Catch ex As Exception
            _errorList.Add(Workspace.IMGMGR_ANSWERS)
            _answers = Nothing
         End Try
      End If

      _results = New List(Of IRecognitionForm)()

      If _toLoad IsNot Nothing Then

         For Each kvp As KeyValuePair(Of String, String) In _toLoad
            Dim imageKey As String = kvp.Key
            Dim fname As String = System.IO.Path.GetFileNameWithoutExtension(kvp.Value)
            Progress(ticker, String.Format("Recognizing {0}", fname))

            Using image As RasterImage = _imageManager.[Get](imageKey)

               Try
                  Dim frm As IRecognitionForm = RecognizeForm(image, imageKey, fname)
                  _results.Add(frm)
               Catch ex As Exception
                  _errorList.Add(fname)
               End Try
            End Using
         Next
      End If

      MyBase.Run()
   End Sub
End Class
