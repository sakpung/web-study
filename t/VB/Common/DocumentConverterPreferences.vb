' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Diagnostics
Imports System.Globalization
Imports System.Collections.Generic
Imports Microsoft.VisualBasic

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Ocr
Imports Leadtools.Document.Writer
Imports Leadtools.Caching
Imports Leadtools.Document
Imports Leadtools.Document.Converter
Imports Leadtools.Annotations.Engine
Imports System

' Options for the DocumentConverterDialog
<Serializable()> _
Public Class DocumentConverterPreferences
   Public Sub New()
      Me.InputFirstPage = 1
      Me.InputLastPage = -1
      Me.DocumentFormat = DocumentFormat.User
      Me.RasterImageFormat = RasterImageFormat.Unknown
      Me.RasterImageBitsPerPixel = 24
      Me.OutputAnnotationsMode = DocumentConverterAnnotationsMode.None
      Me.EnableSvgConversion = True
      Me.SvgImagesRecognitionMode = DocumentConverterSvgImagesRecognitionMode.Auto
      Me.EmptyPageMode = DocumentConverterEmptyPageMode.None
      Me.UseThreads = True
      Me.ErrorMode = DocumentConverterJobErrorMode.[Continue]
      Me.EnableTrace = True
      Me.JobName = "My Job"
      Me.OpenOutputDocument = True
      Me.OpenOutputDocumentAllowed = True
      Me.OCREngineType = OCREngineType.LEAD
   End Sub

   Public Function Clone() As DocumentConverterPreferences
      Dim result As DocumentConverterPreferences = New DocumentConverterPreferences()
      result.InputDocumentFileName = Me.InputDocumentFileName
      result.InputDocumentPageCount = Me.InputDocumentPageCount
      result.InputFirstPage = Me.InputFirstPage
      result.InputLastPage = Me.InputLastPage
      result.InputMaximumPages = Me.InputMaximumPages
      result.InputAnnotationsFileName = Me.InputAnnotationsFileName
      result.LoadEmbeddedAnnotation = Me.LoadEmbeddedAnnotation
      result.DocumentFormat = Me.DocumentFormat
      result.RasterImageFormat = Me.RasterImageFormat
      result.RasterImageBitsPerPixel = Me.RasterImageBitsPerPixel
      result.OutputDocumentFileName = Me.OutputDocumentFileName
      result.OutputAnnotationsMode = Me.OutputAnnotationsMode
      result.OutputAnnotationsFileName = Me.OutputAnnotationsFileName
      result.PageNumberingTemplate = Me.PageNumberingTemplate
      result.EnableSvgConversion = Me.EnableSvgConversion
      result.SvgImagesRecognitionMode = Me.SvgImagesRecognitionMode
      result.EmptyPageMode = Me.EmptyPageMode
      result.UseThreads = Me.UseThreads
      result.PreprocessingDeskew = Me.PreprocessingDeskew
      result.PreprocessingInvert = Me.PreprocessingInvert
      result.PreprocessingOrient = Me.PreprocessingOrient
      result.ErrorMode = Me.ErrorMode
      result.EnableTrace = Me.EnableTrace
      result.JobName = Me.JobName
      result.OpenOutputDocument = Me.OpenOutputDocument
      result.OpenOutputDocumentAllowed = Me.OpenOutputDocumentAllowed
      result.OCREngineType = Me.OCREngineType
      result.OCREngineRuntimePath = Me.OCREngineRuntimePath
      result.RasterCodecsOptionsPath = Me.RasterCodecsOptionsPath
      result.DocumentWriterOptionsPath = Me.DocumentWriterOptionsPath
      result.CacheDirectory = Me.CacheDirectory
      result.CacheDataSerializationMode = Me.CacheDataSerializationMode
      result.CachePolicySerializationMode = Me.CachePolicySerializationMode

      result.DocumentId = Me.DocumentId
      result.OutputFiles = Me.OutputFiles
      result.PurgeOutputFilesOnError = Me.PurgeOutputFilesOnError

      ' Be careful, we are using the same objects here
      result.RasterCodecsInstance = Me.RasterCodecsInstance
      result.OcrEngineInstance = Me.OcrEngineInstance
      result.DocumentWriterInstance = Me.DocumentWriterInstance
      result.IsSilentMode = Me.IsSilentMode
      result.ErrorMessage = Me.ErrorMessage
      result.AnnRenderingEngine = Me.AnnRenderingEngine

      Return result
   End Function

   ' The input document file name
   Public Property InputDocumentFileName() As String
      Get
         Return m_InputDocumentFileName
      End Get
      Set(value As String)
         m_InputDocumentFileName = value
      End Set
   End Property
   Private m_InputDocumentFileName As String

   ' Used by the UI. If it has 0 means we do not know
   <XmlIgnore()> _
   Public Property InputDocumentPageCount() As Integer
      Get
         Return m_InputDocumentPageCount
      End Get
      Set(value As Integer)
         m_InputDocumentPageCount = value
      End Set
   End Property
   Private m_InputDocumentPageCount As Integer

   ' Used by the UI. If it has 1 means first page
   Public Property InputFirstPage() As Integer
      Get
         Return m_InputFirstPage
      End Get
      Set(value As Integer)
         m_InputFirstPage = value
      End Set
   End Property
   Private m_InputFirstPage As Integer

   ' Used by the UI. If it has -1 means last page
   Public Property InputLastPage() As Integer
      Get
         Return m_InputLastPage
      End Get
      Set(value As Integer)
         m_InputLastPage = value
      End Set
   End Property
   Private m_InputLastPage As Integer

   ' Maximum number of pages to convert, less than 1 means no limit. Works with a Document input only
   Public Property InputMaximumPages() As Integer
      Get
         Return m_InputMaximumPages
      End Get
      Set(value As Integer)
         m_InputMaximumPages = value
      End Set
   End Property
   Private m_InputMaximumPages As Integer

   ' The input annotation file
   Public Property InputAnnotationsFileName() As String
      Get
         Return m_InputAnnotationsFileName
      End Get
      Set(value As String)
         m_InputAnnotationsFileName = value
      End Set
   End Property
   Private m_InputAnnotationsFileName As String

   ' Or if the annotations will be loaded from the input document file directly
   Public Property LoadEmbeddedAnnotation() As Boolean
      Get
         Return m_LoadEmbeddedAnnotation
      End Get
      Set(value As Boolean)
         m_LoadEmbeddedAnnotation = value
      End Set
   End Property
   Private m_LoadEmbeddedAnnotation As Boolean

   ' Document format to use
   Public Property DocumentFormat() As DocumentFormat
      Get
         Return m_DocumentFormat
      End Get
      Set(value As DocumentFormat)
         m_DocumentFormat = value
      End Set
   End Property
   Private m_DocumentFormat As DocumentFormat
   ' Or RasterImage format
   Public Property RasterImageFormat() As RasterImageFormat
      Get
         Return m_RasterImageFormat
      End Get
      Set(value As RasterImageFormat)
         m_RasterImageFormat = value
      End Set
   End Property
   Private m_RasterImageFormat As RasterImageFormat
   ' Options to use when saving as Raster
   Public Property RasterImageBitsPerPixel() As Integer
      Get
         Return m_RasterImageBitsPerPixel
      End Get
      Set(value As Integer)
         m_RasterImageBitsPerPixel = value
      End Set
   End Property
   Private m_RasterImageBitsPerPixel As Integer

   ' The output document file name
   Public Property OutputDocumentFileName() As String
      Get
         Return m_OutputDocumentFileName
      End Get
      Set(value As String)
         m_OutputDocumentFileName = value
      End Set
   End Property
   Private m_OutputDocumentFileName As String

   ' Output annotation mode and file name
   Public Property OutputAnnotationsMode() As DocumentConverterAnnotationsMode
      Get
         Return m_OutputAnnotationsMode
      End Get
      Set(value As DocumentConverterAnnotationsMode)
         m_OutputAnnotationsMode = value
      End Set
   End Property
   Private m_OutputAnnotationsMode As DocumentConverterAnnotationsMode
   Public Property OutputAnnotationsFileName() As String
      Get
         Return m_OutputAnnotationsFileName
      End Get
      Set(value As String)
         m_OutputAnnotationsFileName = value
      End Set
   End Property
   Private m_OutputAnnotationsFileName As String

   ' Page Numbering Template
   Public Property PageNumberingTemplate() As String
      Get
         Return m_PageNumberingTemplate
      End Get
      Set(value As String)
         m_PageNumberingTemplate = value
      End Set
   End Property
   Private m_PageNumberingTemplate As String

   ' SVG conversion
   Public Property EnableSvgConversion() As Boolean
      Get
         Return m_EnableSvgConversion
      End Get
      Set(value As Boolean)
         m_EnableSvgConversion = value
      End Set
   End Property
   Private m_EnableSvgConversion As Boolean

   ' If to recognize embedded images in SVG images
   Public Property SvgImagesRecognitionMode() As DocumentConverterSvgImagesRecognitionMode
      Get
         Return m_SvgImagesRecognitionMode
      End Get
      Set(value As DocumentConverterSvgImagesRecognitionMode)
         m_SvgImagesRecognitionMode = value
      End Set
   End Property
   Private m_SvgImagesRecognitionMode As DocumentConverterSvgImagesRecognitionMode

   ' Empty page mode
   Public Property EmptyPageMode() As DocumentConverterEmptyPageMode
      Get
         Return m_EmptyPageMode
      End Get
      Set(value As DocumentConverterEmptyPageMode)
         m_EmptyPageMode = value
      End Set
   End Property
   Private m_EmptyPageMode As DocumentConverterEmptyPageMode

   ' Use threads
   Public Property UseThreads() As Boolean
      Get
         Return m_UseThreads
      End Get
      Set(value As Boolean)
         m_UseThreads = value
      End Set
   End Property
   Private m_UseThreads As Boolean

   ' Preprocessing
   Public Property PreprocessingDeskew() As Boolean
      Get
         Return m_PreprocessingDeskew
      End Get
      Set(value As Boolean)
         m_PreprocessingDeskew = value
      End Set
   End Property
   Private m_PreprocessingDeskew As Boolean
   Public Property PreprocessingInvert() As Boolean
      Get
         Return m_PreprocessingInvert
      End Get
      Set(value As Boolean)
         m_PreprocessingInvert = value
      End Set
   End Property
   Private m_PreprocessingInvert As Boolean
   Public Property PreprocessingOrient() As Boolean
      Get
         Return m_PreprocessingOrient
      End Get
      Set(value As Boolean)
         m_PreprocessingOrient = value
      End Set
   End Property
   Private m_PreprocessingOrient As Boolean

   ' Misc.
   Public Property ErrorMode() As DocumentConverterJobErrorMode
      Get
         Return m_ErrorMode
      End Get
      Set(value As DocumentConverterJobErrorMode)
         m_ErrorMode = value
      End Set
   End Property
   Private m_ErrorMode As DocumentConverterJobErrorMode
   Public Property EnableTrace() As Boolean
      Get
         Return m_EnableTrace
      End Get
      Set(value As Boolean)
         m_EnableTrace = value
      End Set
   End Property
   Private m_EnableTrace As Boolean
   Public Property JobName() As String
      Get
         Return m_JobName
      End Get
      Set(value As String)
         m_JobName = value
      End Set
   End Property
   Private m_JobName As String
   Public Property OpenOutputDocument() As Boolean
      Get
         Return m_OpenOutputDocument
      End Get
      Set(value As Boolean)
         m_OpenOutputDocument = value
      End Set
   End Property
   Private m_OpenOutputDocument As Boolean
   <XmlIgnore()> _
   Public Property OpenOutputDocumentAllowed() As Boolean
      Get
         Return m_OpenOutputDocumentAllowed
      End Get
      Set(value As Boolean)
         m_OpenOutputDocumentAllowed = value
      End Set
   End Property
   Private m_OpenOutputDocumentAllowed As Boolean

   ' OCR
   Public Property OCREngineType() As OcrEngineType
      Get
         Return m_OCREngineType
      End Get
      Set(value As OcrEngineType)
         m_OCREngineType = value
      End Set
   End Property
   Private m_OCREngineType As OcrEngineType
   Public Property OCREngineRuntimePath() As String
      Get
         Return m_OCREngineRuntimePath
      End Get
      Set(value As String)
         m_OCREngineRuntimePath = value
      End Set
   End Property
   Private m_OCREngineRuntimePath As String

   ' RasterCodecs
   Public Property RasterCodecsOptionsPath() As String
      Get
         Return m_RasterCodecsOptionsPath
      End Get
      Set(value As String)
         m_RasterCodecsOptionsPath = value
      End Set
   End Property
   Private m_RasterCodecsOptionsPath As String

   ' DocumentWriter options
   Public Property DocumentWriterOptionsPath() As String
      Get
         Return m_DocumentWriterOptionsPath
      End Get
      Set(value As String)
         m_DocumentWriterOptionsPath = value
      End Set
   End Property
   Private m_DocumentWriterOptionsPath As String

   ' Cache directory
   Public Property CacheDirectory() As String
      Get
         Return m_CacheDirectory
      End Get
      Set(value As String)
         m_CacheDirectory = value
      End Set
   End Property
   Private m_CacheDirectory As String

   ' Cache Data Serialization Mode
   Public Property CacheDataSerializationMode() As CacheSerializationMode
      Get
         Return m_CacheDataSerializationMode
      End Get
      Set(value As CacheSerializationMode)
         m_CacheDataSerializationMode = value
      End Set
   End Property
   Private m_CacheDataSerializationMode As CacheSerializationMode

   ' Cache Policy Serialization Mode
   Public Property CachePolicySerializationMode() As CacheSerializationMode
      Get
         Return m_CachePolicySerializationMode
      End Get
      Set(value As CacheSerializationMode)
         m_CachePolicySerializationMode = value
      End Set
   End Property
   Private m_CachePolicySerializationMode As CacheSerializationMode

   ' Input Document ID
   Public Property DocumentId() As String
      Get
         Return m_DocumentId
      End Get
      Set(value As String)
         m_DocumentId = value
      End Set
   End Property
   Private m_DocumentId As String

   ' Output files
   <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")> _
   Public Property OutputFiles() As String()
      Get
         Return m_OutputFiles
      End Get
      Set(value As String())
         m_OutputFiles = value
      End Set
   End Property
   Private m_OutputFiles As String()

   ' Delete the output files if an error occurs
   Public Property PurgeOutputFilesOnError() As Boolean
      Get
         Return m_PurgeOutputFilesOnError
      End Get
      Set(value As Boolean)
         m_PurgeOutputFilesOnError = value
      End Set
   End Property
   Private m_PurgeOutputFilesOnError As Boolean

   <XmlIgnore()> _
   Public Property RasterCodecsInstance() As RasterCodecs
      Get
         Return m_RasterCodecsInstance
      End Get
      Set(value As RasterCodecs)
         m_RasterCodecsInstance = value
      End Set
   End Property
   Private m_RasterCodecsInstance As RasterCodecs

   <XmlIgnore()> _
   Public Property OcrEngineInstance() As IOcrEngine
      Get
         Return m_OcrEngineInstance
      End Get
      Set(value As IOcrEngine)
         m_OcrEngineInstance = value
      End Set
   End Property
   Private m_OcrEngineInstance As IOcrEngine

   <XmlIgnore()> _
   Public Property DocumentWriterInstance() As DocumentWriter
      Get
         Return m_DocumentWriterInstance
      End Get
      Set(value As DocumentWriter)
         m_DocumentWriterInstance = value
      End Set
   End Property
   Private m_DocumentWriterInstance As DocumentWriter

   <XmlIgnore()> _
   Public Property AnnRenderingEngine() As AnnRenderingEngine
      Get
         Return m_AnnRenderingEngine
      End Get
      Set(value As AnnRenderingEngine)
         m_AnnRenderingEngine = value
      End Set
   End Property
   Private m_AnnRenderingEngine As AnnRenderingEngine

   <XmlIgnore()> _
   Public Property IsSilentMode() As Boolean
      Get
         Return m_IsSilentMode
      End Get
      Set(value As Boolean)
         m_IsSilentMode = value
      End Set
   End Property
   Private m_IsSilentMode As Boolean

   Public Property ErrorMessage() As String
      Get
         Return m_ErrorMessage
      End Get
      Set(value As String)
         m_ErrorMessage = value
      End Set
   End Property
   Private m_ErrorMessage As String

   ' The demo name
   Public Shared Property DemoName() As String
      Get
         Return m_DemoName
      End Get
      Set(value As String)
         m_DemoName = value
      End Set
   End Property
   Private Shared m_DemoName As String

   Public Shared Property XmlFileName() As String
      Get
         Return m_XmlFileName
      End Get
      Set(value As String)
         m_XmlFileName = value
      End Set
   End Property
   Private Shared m_XmlFileName As String

   Private Shared Function GetOutputFileName() As String
      If String.IsNullOrEmpty(XmlFileName) Then
         Throw New InvalidOperationException("Set XmlFileName before calling this method")
      End If

      Return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), XmlFileName & Convert.ToString(".xml"))
   End Function

   Private Shared _serializer As New XmlSerializer(GetType(DocumentConverterPreferences))

   ' Load the preferences from local application data, if not found or error, returns default preferences
   Public Shared Function Load() As DocumentConverterPreferences
      Try
         Dim fileName As String = GetOutputFileName()
         If File.Exists(fileName) Then
            Return Load(fileName)
         End If
      Catch ex As Exception
         Debug.WriteLine(ex.Message)
      End Try

      Return New DocumentConverterPreferences()
   End Function

   Public Shared Function Load(fileName As String) As DocumentConverterPreferences
      Using reader As XmlTextReader = New XmlTextReader(fileName)
         Return TryCast(_serializer.Deserialize(reader), DocumentConverterPreferences)
      End Using
   End Function

   ' Save the preferences to local application data
   Public Sub Save()
      Try
         Dim fileName As String = GetOutputFileName()
         Save(fileName)
      Catch
      End Try
   End Sub

   Public Sub Save(fileName As String)
      Using writer As XmlTextWriter = New XmlTextWriter(fileName, Encoding.Unicode)
         writer.Formatting = Formatting.Indented
         writer.Indentation = 2
         _serializer.Serialize(writer, Me)
      End Using
   End Sub

   ' Run the conversion
   Public Function Run(cache As ObjectCache, document As LEADDocument, converter As DocumentConverter, redactionOptions As ConvertRedactionOptions) As Boolean
      Me.ErrorMessage = Nothing
      Me.OutputFiles = Nothing

      ' Show its info
      ShowInfo(document)

      Dim disposeConverter As Boolean = False

      Try
         ' If the user did not specify a document converter, create one
         If converter Is Nothing Then
            converter = New DocumentConverter()
            disposeConverter = True
         End If

         ' Set the options in the document converter from our data
         SetOptions(converter, cache, document, redactionOptions)

         ' Create the document converter job job
         Dim job As DocumentConverterJob = CreateConverterJob(converter, document)

         ' Run it
         Trace.WriteLine("Running job...")
         Dim stopwatch As Stopwatch = New Stopwatch()
         stopwatch.Start()
         converter.Jobs.RunJob(job)
         stopwatch.[Stop]()

         ' Show the results
         ShowResults(job)

         ' Handle the output files (if any)
         HandleOutputFiles(job)

         Trace.WriteLine("----------------------------")
         Trace.WriteLine("Total conversion time: " + stopwatch.Elapsed.ToString())

         ' See if we need to open the final document. LTD format has no viewer ...
         ViewOutputFile(job)

         ' Check the errors
         If job.Status = DocumentConverterJobStatus.Aborted Then
            ' Get the first error
            If job.Errors.Count > 0 Then
               Me.ErrorMessage = job.Errors(0).[Error].Message
            End If
         End If

         Return job.Status <> DocumentConverterJobStatus.Aborted
      Catch ex As OcrException
         Me.ErrorMessage = ex.Message
         Trace.WriteLine(String.Format("OCR error code: {0}" & vbLf & "{1}", ex.Code, ex.Message))
      Catch ex As RasterException
         Me.ErrorMessage = ex.Message
         Trace.WriteLine(String.Format("LEADTOOLS error code: {0}" & vbLf & "{1}", ex.Code, ex.Message))
      Catch ex As Exception
         Me.ErrorMessage = ex.Message
         Trace.WriteLine("Error: " + ex.Message)
      Finally
         ' If we created the converter, dispose it
         If converter IsNot Nothing AndAlso disposeConverter Then
            converter.Dispose()
         End If
      End Try

      Return False
   End Function

   Private Sub HandleOutputFiles(job As DocumentConverterJob)
      If job.Status <> DocumentConverterJobStatus.Aborted Then
         ' Copy the output files to job.OutputFiles so the user can get them
         Me.OutputFiles = New String(job.OutputFiles.Count - 1) {}
         job.OutputFiles.CopyTo(Me.OutputFiles, 0)

         ' Show output files
         Trace.WriteLine("----------------------------")
         Trace.WriteLine("Output files:")
         For Each outputFile As String In job.OutputFiles
            Trace.WriteLine(outputFile)
         Next
      Else
         ' An error occured, see if we need to delete the output files
         If Me.PurgeOutputFilesOnError Then
            DeleteAllFiles(job.OutputFiles)
         End If
      End If
   End Sub

   Private Shared Sub ShowResults(job As DocumentConverterJob)
      ' If we have errors, show them
      Trace.WriteLine("----------------------------------")
      Trace.WriteLine("Status: " + Convert.ToString(job.Status))

      If job.Errors.Count > 0 Then
         ' We have errors, show them
         Trace.WriteLine("----------------------------------")
         Trace.WriteLine("Errors found:")
         For Each [error] As DocumentConverterJobError In job.Errors
            If [error].InputDocumentPageNumber <> 0 Then
               Trace.WriteLine(String.Format("Operation: {0} - Page: {1} - Error: {2}", [error].Operation, [error].InputDocumentPageNumber, [error].[Error]))
            Else
               Trace.WriteLine(String.Format("Operation: {0} - Error: {1}", [error].Operation, [error].[Error]))
            End If
         Next
      End If
   End Sub

   Private Function CreateConverterJob(converter As DocumentConverter, document As LEADDocument) As DocumentConverterJob
      ' Set the maximum page
      Dim firstPage As Integer = Me.InputFirstPage
      If firstPage = 0 Then
         firstPage = 1
      End If

      Dim lastPage As Integer = Me.InputLastPage
      If lastPage = 0 Then
         lastPage = -1
      End If

      If document IsNot Nothing AndAlso Me.InputMaximumPages > 0 Then
         If lastPage = -1 Then
            lastPage = document.Pages.Count
         End If
         lastPage = Math.Min(lastPage, firstPage + Me.InputMaximumPages - 1)
      End If

      ' Create a job
      Dim jobData As DocumentConverterJobData = New DocumentConverterJobData() With {
        .InputDocumentFileName = If(document Is Nothing, Me.InputDocumentFileName, Nothing),
        .Document = document,
        .InputDocumentFirstPageNumber = firstPage,
        .InputDocumentLastPageNumber = lastPage,
        .DocumentFormat = Me.DocumentFormat,
        .RasterImageFormat = Me.RasterImageFormat,
        .RasterImageBitsPerPixel = Me.RasterImageBitsPerPixel,
        .OutputDocumentFileName = Me.OutputDocumentFileName,
        .AnnotationsMode = Me.OutputAnnotationsMode,
        .OutputAnnotationsFileName = Me.OutputAnnotationsFileName,
        .JobName = Me.JobName,
        .UserData = Nothing
      }

      If document IsNot Nothing Then
         jobData.InputAnnotationsFileName = Me.InputAnnotationsFileName
      End If

      Dim job As DocumentConverterJob = converter.Jobs.CreateJob(jobData)
      Return job
   End Function

   Private Sub SetOptions(converter As DocumentConverter, cache As ObjectCache, document As LEADDocument, redactionOptions As ConvertRedactionOptions)
      converter.SetAnnRenderingEngineInstance(Me.AnnRenderingEngine)

      ' Set the RasterCodecs instance, should go into the DocumentFactory class which will be used to load the document
      If Me.RasterCodecsInstance IsNot Nothing Then
         DocumentFactory.RasterCodecsTemplate = Me.RasterCodecsInstance
      End If

      ' Set the OCR engine
      If Me.OcrEngineInstance IsNot Nothing AndAlso Me.OcrEngineInstance.IsStarted Then
         converter.SetOcrEngineInstance(Me.OcrEngineInstance, False)
      End If

      If Me.DocumentWriterInstance IsNot Nothing Then
         converter.SetDocumentWriterInstance(Me.DocumentWriterInstance)
      End If

      ' Set pre-processing options
      converter.Preprocessor.Deskew = Me.PreprocessingDeskew
      converter.Preprocessor.Invert = Me.PreprocessingInvert
      converter.Preprocessor.Orient = Me.PreprocessingOrient

      ' Enable trace
      converter.Diagnostics.EnableTrace = Me.EnableTrace

      ' Setup the load document options
      Dim loadDocumentOptions As LoadDocumentOptions = New LoadDocumentOptions()
      ' Setup cachce
      loadDocumentOptions.Cache = cache
      loadDocumentOptions.UseCache = cache IsNot Nothing

      If document Is Nothing Then
         ' Set the input annotation mode or file name
         loadDocumentOptions.LoadEmbeddedAnnotations = Me.LoadEmbeddedAnnotation
         If Not Me.LoadEmbeddedAnnotation AndAlso Not String.IsNullOrEmpty(Me.InputAnnotationsFileName) AndAlso File.Exists(Me.InputAnnotationsFileName) Then
            ' We will use this instead of DocumentConverterJobData.InputAnnotationsFileName (this will override it anyway if we give the
            ' document converter a loadDocumentOptions)
            loadDocumentOptions.AnnotationsUri = New Uri(Me.InputAnnotationsFileName)
         End If
      End If

      converter.LoadDocumentOptions = loadDocumentOptions

      ' Set options
      converter.Options.JobErrorMode = Me.ErrorMode
      If Not String.IsNullOrEmpty(Me.PageNumberingTemplate) Then
         converter.Options.PageNumberingTemplate = Me.PageNumberingTemplate
      End If
      converter.Options.EnableSvgConversion = Me.EnableSvgConversion
      converter.Options.SvgImagesRecognitionMode = If((Me.OcrEngineInstance IsNot Nothing AndAlso Me.OcrEngineInstance.IsStarted), Me.SvgImagesRecognitionMode, DocumentConverterSvgImagesRecognitionMode.Disabled)
      converter.Options.EmptyPageMode = Me.EmptyPageMode
      converter.Options.UseThreads = Me.UseThreads
      converter.Diagnostics.EnableTrace = Me.EnableTrace

      If redactionOptions IsNot Nothing Then
         Dim documentRedactionOptions As DocumentRedactionOptions = New DocumentRedactionOptions()
         documentRedactionOptions.ConvertOptions = redactionOptions

         If document IsNot Nothing Then
            documentRedactionOptions.ViewOptions = document.Annotations.RedactionOptions.ViewOptions
            document.Annotations.RedactionOptions = documentRedactionOptions
         Else
            converter.LoadDocumentOptions.RedactionOptions = documentRedactionOptions
         End If
      End If
   End Sub

   Private Sub ShowInfo(document As LEADDocument)
      Console.WriteLine("-----------------------")

      If document Is Nothing Then
         Console.WriteLine(Convert.ToString("  InputDocumentFileName: ") & InputDocumentFileName)
      Else
         Console.WriteLine("  InputDocument: " + document.DocumentId)
         Dim documentPath As String
         Dim documentUri As Uri = document.Uri
         If documentUri.IsFile Then
            documentPath = documentUri.LocalPath
         Else
            documentPath = documentUri.ToString()
         End If
         Console.WriteLine(Convert.ToString("  InputDocumentPath: ") & documentPath)
      End If

      Console.WriteLine("  InputDocumentPageCount: " + Convert.ToString(InputDocumentPageCount))
      Console.WriteLine("  InputFirstPage: " + Convert.ToString(InputFirstPage))
      Console.WriteLine("  InputLastPage: " + Convert.ToString(InputLastPage))

      If document Is Nothing Then
         Console.WriteLine(Convert.ToString("  InputAnnotationsFileName: ") & InputAnnotationsFileName)
         Console.WriteLine("  LoadEmbeddedAnnotation: " + Convert.ToString(LoadEmbeddedAnnotation))
      End If

      Console.WriteLine("  DocumentFormat: " + Convert.ToString(DocumentFormat))
      Console.WriteLine("  RasterImageFormat: " + Convert.ToString(RasterImageFormat))
      Console.WriteLine("  RasterImageBitsPerPixel: " + Convert.ToString(RasterImageBitsPerPixel))
      Console.WriteLine(Convert.ToString("  OutputDocumentFileName: ") & Convert.ToString(OutputDocumentFileName))
      Console.WriteLine(Convert.ToString("  OutputAnnotationsFileName: ") & Convert.ToString(OutputAnnotationsFileName))
      Console.WriteLine("  OutputAnnotationsMode: " + Convert.ToString(OutputAnnotationsMode))
      Console.WriteLine("  EnableSvgConversion: " + Convert.ToString(EnableSvgConversion))
      Console.WriteLine("  SvgImagesRecognitionMode: " + Convert.ToString(SvgImagesRecognitionMode))
      Console.WriteLine("  EmptyPageMode: " + Convert.ToString(EmptyPageMode))
      Console.WriteLine("  UseThreads: " + Convert.ToString(UseThreads))
      Console.WriteLine("  PreprocessingDeskew: " + Convert.ToString(PreprocessingDeskew))
      Console.WriteLine("  PreprocessingInvert: " + Convert.ToString(PreprocessingInvert))
      Console.WriteLine("  PreprocessingOrient: " + Convert.ToString(PreprocessingOrient))
      Console.WriteLine("  ErrorMode: " + Convert.ToString(ErrorMode))
      Console.WriteLine("  EnableTrace: " + Convert.ToString(EnableTrace))
      Console.WriteLine(Convert.ToString("  JobName: ") & JobName)
      Console.WriteLine("  OpenOutputDocument: " + Convert.ToString(OpenOutputDocument))
   End Sub

   Private Sub ViewOutputFile(job As DocumentConverterJob)
      If job.Status = DocumentConverterJobStatus.Aborted OrElse Not Me.OpenOutputDocument OrElse job.JobData.DocumentFormat = DocumentFormat.Ltd Then
         Return
      End If

      Try
         If File.Exists(job.JobData.OutputDocumentFileName) Then
            Process.Start(job.JobData.OutputDocumentFileName)
         Else
            ' Might be multiple files, try the directory
            Dim outputDocumentDir As String = Path.GetDirectoryName(job.JobData.OutputDocumentFileName)
            If Directory.Exists(outputDocumentDir) Then
               Process.Start(outputDocumentDir)
            End If
         End If
      Catch ex As Exception
         Me.ErrorMessage = ex.Message
         Throw
      End Try
   End Sub

   Private Shared Sub DeleteAllFiles(files As IList(Of String))
      If files Is Nothing Then
         Return
      End If

      For Each file__1 As String In files
         If File.Exists(file__1) Then
            Try
               File.Delete(file__1)
            Catch
            End Try
         End If
      Next
   End Sub
End Class
