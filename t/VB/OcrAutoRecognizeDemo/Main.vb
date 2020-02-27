' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Document.Writer
Imports Leadtools.Ocr
Imports System.Runtime.InteropServices

Module Main

#Region "unmanaged"
   ' Declare the SetConsoleCtrlHandler function as external and receiving a delegate.
   <DllImport("Kernel32")> _
   Private Function SetConsoleCtrlHandler(ByVal handler As EventHandler, ByVal add As Boolean) As Boolean
   End Function

   Private Delegate Function EventHandler(ByVal sig As Integer) As Boolean
   Private _handler As EventHandler

   Private Function MyExitHandler(ByVal sig As Integer) As Boolean
      Return True
   End Function
#End Region

   <STAThread()> _
   Sub Main()
      Messager.Caption = "VB OCR Auto Recognize Demo"
#If LEADTOOLS_V175_OR_LATER Then
      If Not Support.SetLicense() Then
         Return
      End If
#Else
      Support.Unlock(False)
#End If
      

      _handler = New EventHandler(AddressOf MyExitHandler)
      SetConsoleCtrlHandler(_handler, True)

      ' Trace to the console
      Trace.Listeners.Add(New TextWriterTraceListener(Console.Out))

      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)

      Dim jobData As New JobData()
      Dim _rasterCodecs As New RasterCodecs()
#If Not LEADTOOLS_V175_OR_LATER Then
         _rasterCodecs.Options.RasterizeDocument.Load.Enabled = True
#End If
      _rasterCodecs.Options.Pdf.Load.DisplayDepth = 24
#If LEADTOOLS_V16_OR_LATER Then
      ' Use the new RasterizeDocumentOptions to default loading document files at 300 DPI
      _rasterCodecs.Options.RasterizeDocument.Load.XResolution = 300
      _rasterCodecs.Options.RasterizeDocument.Load.YResolution = 300
      _rasterCodecs.Options.Pdf.Load.EnableInterpolate = True
      _rasterCodecs.Options.Load.AutoFixImageResolution = True
#End If ' #if LEADTOOLS_V16_OR_LATER

      Dim unexpectedShutdown As Boolean = False

      Try
         Do
            ' Get the demo job data
            Dim form As New JobForm(_rasterCodecs)
            form.JobData = jobData
            If form.ShowDialog() <> DialogResult.OK Then
               Console.WriteLine("Exiting")
               Return
            End If

            Dim deleteExistingFile As Boolean = File.Exists(form.JobData.DocumentFileName)

            If deleteExistingFile AndAlso form.JobData.Format = DocumentFormat.Ltd Then
               ' This is an LTD file that already exists, so ask the user what to do here, delete or append to it
               Dim message As String = String.Format("Delete the existing output file '{0}' first?{1}The file already exists. Select 'Yes' to delete it and create a new one or 'No' to append this result to it.", _
                  form.JobData.DocumentFileName, Environment.NewLine)
               Select Messager.ShowQuestion(Nothing, message, MessageBoxButtons.YesNoCancel)
                  Case DialogResult.Yes
                     deleteExistingFile = True

                  Case DialogResult.No
                     deleteExistingFile = False

                  Case Else
                     Continue Do
               End Select
            End If

            ' Delete the output file first
            If deleteExistingFile Then
               File.Delete(form.JobData.DocumentFileName)
            End If

            ' Now run
            Dim ocrAutoRecognizeManager As IOcrAutoRecognizeManager = jobData.OcrEngine.AutoRecognizeManager
            ocrAutoRecognizeManager.EnableTrace = jobData.EnableTrace
            ocrAutoRecognizeManager.MaximumThreadsPerJob = jobData.MaximumThreadsPerJob
            ocrAutoRecognizeManager.MaximumPagesBeforeLtd = jobData.MaximumPagesBeforeLtd
            ocrAutoRecognizeManager.JobErrorMode = jobData.JobErrorMode
            ocrAutoRecognizeManager.PreprocessPageCommands.Clear()
            For Each command As OcrAutoPreprocessPageCommand In jobData.PreprocessPageCommands
               ocrAutoRecognizeManager.PreprocessPageCommands.Add(command)
            Next

            Console.WriteLine("Running job...")

            Dim watch As New Stopwatch()
            watch.Start()

            ' get an OCR job
            Dim ocrJobData As New OcrAutoRecognizeJobData( _
               jobData.ImageFileName, _
               jobData.FirstPageNumber, _
               jobData.LastPageNumber, _
               jobData.ZonesFileName, _
               jobData.Format, _
               jobData.DocumentFileName)
            ocrJobData.JobName = "MyJob"

            Dim ocrJob As IOcrAutoRecognizeJob = ocrAutoRecognizeManager.CreateJob(ocrJobData)

            Try
               ocrAutoRecognizeManager.RunJob(ocrJob)
            Catch ex As Exception
            End Try

            watch.Stop()
            Console.WriteLine("----------------------------")
            If ocrJob.Errors.Count > 0 Then
               Console.WriteLine("Errors found:")
               For Each err As OcrAutoRecognizeManagerJobError In ocrJob.Errors
                  Console.WriteLine("Page: {0} - Operation: {1} - Error: {2}", err.ImagePageNumber, err.Operation, err.Exception)
               Next
            End If

            Console.WriteLine("Total conversion time: " + watch.Elapsed.ToString())
            Console.WriteLine("----------------------------")

            If jobData.ViewFinalDocument AndAlso jobData.Format <> DocumentFormat.Ltd Then
               Try
                  System.Diagnostics.Process.Start(jobData.DocumentFileName)
               Catch ex As Exception
                  Messager.ShowError(Nothing, ex)
               End Try
            End If
         Loop While True
      Catch ex As OcrException
         unexpectedShutdown = True
         Console.WriteLine("OCR error code: {0}\n{1}", ex.Code, ex.Message)
         Return
      Catch ex As RasterException
         unexpectedShutdown = True
         Console.WriteLine("LEADTOOLS error code: {0}\n{1}", ex.Code, ex.Message)
         Return
      Catch ex As Exception
         unexpectedShutdown = True
         Console.WriteLine("Error: " + ex.Message)
         Return
      Finally
         If Not IsNothing(jobData.OcrEngine) Then
            ' Dispose the OCR engine (this will call Shutdown as well)
            jobData.OcrEngine.Dispose()
            jobData.OcrEngine = Nothing
         End If
         If Not IsNothing(_rasterCodecs) Then
            ' Dispose raster codecs
            _rasterCodecs.Dispose()
            _rasterCodecs = Nothing
         End If

         If unexpectedShutdown Then
            Console.WriteLine("Hit Enter...")
            While Console.ReadKey(True).Key <> ConsoleKey.Enter
            End While
         End If
      End Try
   End Sub
End Module
