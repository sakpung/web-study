' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms

Imports Leadtools.Demos
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Document.Writer
Imports Leadtools.Ocr
Imports Leadtools.Document
Imports Leadtools.Document.Converter
Imports System
Imports System.Runtime.InteropServices

Module Main

#Region "unmanaged"
   ' Declare the SetConsoleCtrlHandler function as external and receiving a delegate.
   <DllImport("Kernel32")>
   Private Function SetConsoleCtrlHandler(ByVal handler As EventHandler, ByVal add As Boolean) As Boolean
   End Function

   Private Delegate Function EventHandler(ByVal sig As Integer) As Boolean
   Private _handler As EventHandler

   Private Function MyExitHandler(ByVal sig As Integer) As Boolean
      Return True
   End Function
#End Region

   NotInheritable Class Program
      Private Sub New()
      End Sub
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()>
      Shared Sub Main()

         If Not Support.SetLicense() Then
            Return
         End If

         _handler = New EventHandler(AddressOf MyExitHandler)
         SetConsoleCtrlHandler(_handler, True)

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)

         Messager.Caption = "Document Converter Folder Demo"

         ' Initialize Trace
         Trace.Listeners.Add(New TextWriterTraceListener(Console.Out))

         Console.WriteLine("LEADTOOLS " + Messager.Caption)

         ' Load the preferences file
         DocumentConverterPreferences.DemoName = "Document Converter Folder Demo"
         DocumentConverterPreferences.XmlFileName = "DocumentConverterFolderDemo"
         Dim preferences As DocumentConverterPreferences = DocumentConverterPreferences.Load()
         preferences.OpenOutputDocumentAllowed = False

         MyOptions.XmlFileName = "DocumentConverterFolderOptions"
         Dim theOptions As MyOptions = MyOptions.Load()

         Dim runTheConversion As Boolean = False

         Using dlg As MyOptionsDialog = New MyOptionsDialog()
            dlg.MyOptions = theOptions.Clone()
            If dlg.ShowDialog() = DialogResult.OK Then
               runTheConversion = True
               theOptions = dlg.MyOptions.Clone()
               theOptions.Save()
            End If
         End Using

         If Not runTheConversion Then
            Return
         End If

         ' Initialize OCR engine
         ' Show the OCR engine selection dialog to startup the OCR engine
         Trace.WriteLine("Starting OCR engine")
         Dim engineType As OcrEngineType = preferences.OCREngineType
         Using dlg As OcrEngineSelectDialog = New OcrEngineSelectDialog(DocumentConverterPreferences.DemoName, engineType.ToString(), True)
            dlg.AllowNoOcr = True
            dlg.AllowNoOcrMessage = "The demo runs without OCR functionality but you will not be able to parse text from non-document files such as TIFF or Raster PDF. Click 'Cancel' to start this demo without an OCR engine."
            If dlg.ShowDialog() = DialogResult.OK Then
               preferences.OcrEngineInstance = dlg.OcrEngine
               preferences.OCREngineType = dlg.OcrEngine.EngineType
               Trace.WriteLine(String.Format("OCR engine {0} started", preferences.OCREngineType))
            End If
         End Using

         ' Initialize the RasterCodecs instance
         Dim rasterCodecs As New RasterCodecs()
         rasterCodecs.Options = DocumentFactory.RasterCodecsTemplate.Options.Clone()
         preferences.RasterCodecsInstance = rasterCodecs

         ' Initialize the DocumentWriter instance
         preferences.DocumentWriterInstance = New DocumentWriter()

         ' Get the options
         Console.WriteLine("Obtaining conversion options")

         ' Collect the options
         Using dlg As DocumentConverterDialog = New DocumentConverterDialog()
            ' Create a dummy document so the options do not bug us about a input/output files
            Using document As LEADDocument = DocumentFactory.Create("Raster", New CreateDocumentOptions() With {
            .MimeType = "image/tiff"
         })
               dlg.InputDocument = document
               dlg.Preferences = preferences.Clone()
               dlg.InputDocument = document
               If dlg.ShowDialog() = DialogResult.OK Then
                  preferences = dlg.Preferences.Clone()
                  ' Save the preferences
                  preferences.Save()
               Else
                  runTheConversion = False
               End If
            End Using
         End Using

         If runTheConversion Then
            ' Set the RasterCodecs instance, should go into the DocumentFactory class which will be used to load the document
            If preferences.RasterCodecsInstance IsNot Nothing Then
               DocumentFactory.RasterCodecsTemplate = preferences.RasterCodecsInstance
            End If

            Dim converter As New DocumentConverter()

            ' Set the OCR engine
            If preferences.OcrEngineInstance IsNot Nothing Then
               converter.SetOcrEngineInstance(preferences.OcrEngineInstance, False)
            End If

            If preferences.DocumentWriterInstance IsNot Nothing Then
               converter.SetDocumentWriterInstance(preferences.DocumentWriterInstance)
            End If

            ' Set pre-processing options
            converter.Preprocessor.Deskew = preferences.PreprocessingDeskew
            converter.Preprocessor.Invert = preferences.PreprocessingInvert
            converter.Preprocessor.Orient = preferences.PreprocessingOrient

            ' Enable trace
            converter.Diagnostics.EnableTrace = preferences.EnableTrace

            ' Set options
            converter.Options.JobErrorMode = preferences.ErrorMode
            converter.Options.EnableSvgConversion = preferences.EnableSvgConversion
            converter.Options.SvgImagesRecognitionMode = If((preferences.OcrEngineInstance IsNot Nothing AndAlso preferences.OcrEngineInstance.IsStarted), preferences.SvgImagesRecognitionMode, DocumentConverterSvgImagesRecognitionMode.Disabled)
            converter.Diagnostics.EnableTrace = preferences.EnableTrace

            Try
               RunConversion(converter, preferences, theOptions)
            Catch ex As Exception
               Trace.WriteLine("Error " + ex.Message)
            End Try

         End If

         If preferences.OcrEngineInstance IsNot Nothing Then
            preferences.OcrEngineInstance.Dispose()
         End If

         If preferences.RasterCodecsInstance IsNot Nothing Then
            preferences.RasterCodecsInstance.Dispose()
         End If

         Console.WriteLine(vbLf & "Done, Press and key to close demo.")
         Console.ReadKey()
      End Sub

      Private Shared Function GetExtension(preferences As DocumentConverterPreferences) As String
         If preferences.DocumentFormat <> DocumentFormat.User Then
            Return DocumentWriter.GetFormatFileExtension(preferences.DocumentFormat)
         Else
            Return RasterCodecs.GetExtension(preferences.RasterImageFormat)
         End If
      End Function

      Private Shared Sub RunConversion(converter As DocumentConverter, preferences As DocumentConverterPreferences, myOptions As MyOptions)
         If String.IsNullOrEmpty(myOptions.InputFolder) OrElse Not Directory.Exists(myOptions.InputFolder) Then
            Trace.WriteLine("Input filder does not exist")
            Return
         End If

         If Not Directory.Exists(myOptions.OutputFolder) Then
            Directory.CreateDirectory(myOptions.OutputFolder)
         End If

         _logFile = Path.Combine(myOptions.OutputFolder, "_log.txt")
         If File.Exists(_logFile) Then
            File.Delete(_logFile)
         End If

         _totalTime = 0

         ' Run here
         Dim filter As String = Nothing
         If Not IsNothing(myOptions.Extension) Then
            filter = myOptions.Extension.Trim()
         End If
         If String.IsNullOrEmpty(filter) Then
            filter = "*.*"
         End If
         Dim files As String() = Directory.GetFiles(myOptions.InputFolder, filter)
         Dim temp As List(Of String) = New List(Of String)()
         For Each file__1 As String In files
            If Path.GetExtension(file__1).ToLower() <> ".db" Then
               temp.Add(file__1)
            End If
         Next

         files = temp.ToArray()

         Trace.WriteLine(String.Format("{0} files", files.Length))

         Dim extension As String = GetExtension(preferences)

         Dim index As Integer = 0
         Dim count As Integer = files.Length
         For Each inFile As String In files
            Dim tmp As String = Path.GetFileName(inFile)
            tmp = tmp.Remove(tmp.IndexOf(Path.GetExtension(inFile)))

            Dim outFile As String = (tmp + "_" + Path.GetExtension(inFile).Replace(".", "")).Replace(".", "_")

            outFile = Path.Combine(myOptions.OutputFolder, Path.ChangeExtension(outFile, extension))
            Trace.WriteLine(String.Format("{0}:{1}", index + 1, count))
            Trace.WriteLine(inFile)
            Trace.WriteLine(outFile)
            index += 1

            Convert(converter, inFile, outFile, preferences)
         Next

         Log("Overall conversion time: " + _totalTime.ToString())
         Trace.WriteLine("Overall conversion time: " + _totalTime.ToString())
      End Sub

      Private Shared _totalTime As Double
      Private Shared _logFile As String
      Private Shared Sub Log(message As String)
         File.AppendAllText(_logFile, String.Format("{0} - {1}" & vbCr & vbLf, DateTime.Now, message))
      End Sub

      Private Shared Function Convert(converter As DocumentConverter, inFile As String, outFile As String, preferences As DocumentConverterPreferences) As Boolean
         ' Setup the load document options
         Dim loadDocumentOptions As LoadDocumentOptions = New LoadDocumentOptions()
         ' Not using cache
         loadDocumentOptions.UseCache = False

         ' Set the input annotation mode or file name
         loadDocumentOptions.LoadEmbeddedAnnotations = preferences.LoadEmbeddedAnnotation

         converter.LoadDocumentOptions = loadDocumentOptions

         If (preferences.DocumentFormat = DocumentFormat.Ltd AndAlso File.Exists(outFile)) Then
            File.Delete(outFile)
         End If

         ' Create a job
         Dim jobData As DocumentConverterJobData = New DocumentConverterJobData() With {
         .InputDocumentFileName = inFile,
         .InputDocumentFirstPageNumber = preferences.InputFirstPage,
         .InputDocumentLastPageNumber = preferences.InputLastPage,
         .DocumentFormat = preferences.DocumentFormat,
         .RasterImageFormat = preferences.RasterImageFormat,
         .RasterImageBitsPerPixel = preferences.RasterImageBitsPerPixel,
         .OutputDocumentFileName = outFile,
         .AnnotationsMode = preferences.OutputAnnotationsMode,
         .JobName = preferences.JobName,
         .UserData = Nothing
      }

         ' Create the job
         Dim job As DocumentConverterJob = converter.Jobs.CreateJob(jobData)
         Dim ret As Boolean = True

         ' Run it
         Try
            Trace.WriteLine("Running job...")

            Dim stopwatch As Stopwatch = New Stopwatch()
            stopwatch.Start()
            converter.Jobs.RunJob(job)
            stopwatch.[Stop]()
            Dim elapsed As Long = stopwatch.ElapsedMilliseconds
            _totalTime += elapsed

            ' If we have errors, show them
            Trace.WriteLine("----------------------------------")
            Trace.WriteLine("Status: " & job.Status)
            Trace.WriteLine("----------------------------------")
            Trace.WriteLine("Conversion modes: " & job.ConversionModes)

            Log(String.Format("{0} - {1} - {2}", job.Status, job.ConversionModes, inFile))

            ret = job.Status = DocumentConverterJobStatus.Success

            If job.Errors.Count > 0 Then
               ret = False
               ' We have errors, show them
               Trace.WriteLine("Errors found:")
               Log("Errors found:")
               For Each [error] As DocumentConverterJobError In job.Errors
                  Dim message As String = String.Format("Page: {0} - Operation: {1} - Error: {2}", [error].InputDocumentPageNumber, [error].Operation, [error].[Error])
                  Trace.WriteLine(message)
                  Log(message)
               Next
            End If

            Trace.WriteLine("Total conversion time: " + elapsed.ToString())
            Log("Total conversion time: " + elapsed.ToString())
            Trace.WriteLine("----------------------------")
         Catch ex As OcrException
            Dim message As String = String.Format("OCR error code: {0} - {1}", ex.Code, ex.Message)
            Trace.WriteLine(message)
            Log(String.Format("{0} - {1}", message, inFile))
            ret = False
         Catch ex As RasterException
            Dim message As String = String.Format("LEADTOOLS error code: {0} - {1}", ex.Code, ex.Message)
            Trace.WriteLine(message)
            Log(String.Format("{0} - {1}", message, inFile))
            ret = False
         Catch ex As Exception
            Dim message As String = String.Format("Error: {0} - {1}", ex.[GetType]().FullName, ex.Message)
            Trace.WriteLine(message)
            Log(String.Format("{0} - {1}", message, inFile))
            ret = False
         End Try

         Return ret
      End Function
   End Class
End Module