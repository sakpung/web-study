' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading
Imports System.IO

Imports Leadtools
Imports Leadtools.Ocr
Imports Leadtools.Document.Writer
Imports Leadtools.Codecs

Namespace OcrMultiThreadingDemo
   Partial Public Class ConversionControl
      Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Public Event ConversionFinished As EventHandler

      Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
         SyncLock _abortedLockObject
            _aborted = True
         End SyncLock

         _lblInformation.Text = "Aborting..."
      End Sub

      Public Event ConvertMoreFiles As EventHandler

      Private Sub _btnConvertMoreFiles_Click(sender As Object, e As EventArgs) Handles _btnConvertMoreFiles.Click
         RaiseEvent ConvertMoreFiles(Me, e)
      End Sub

      Private Structure WorkItemData
         Public EngineType As OcrEngineType
         Public OcrEngine As IOcrEngine
         Public DocumentWriterOptions As Byte()
         Public SourceFile As String
         Public DestinationDirectory As String
         Public Format As DocumentFormat
         Public FirstTry As Boolean
      End Structure

      Private _workItemCount As Integer
      Private _batchFinishedEvent As AutoResetEvent
      Private _aborted As Boolean
      Private _abortedLockObject As New Object()

      Private _ocrEngine As IOcrEngine
      Private _docWriter As DocumentWriter
      Private _engineType As OcrEngineType
      Private _sourceFiles As String()
      Private _destinationDirectory As String
      Private _format As DocumentFormat
      Private _loopContinuously As Boolean
      Private _iteration As Integer = 0
      Private _logFileName As String

      Public Sub Convert(docWriter As DocumentWriter, engineType As OcrEngineType, sourceFiles As String(), destinationDirectory As String, format As DocumentFormat, loopContinuously As Boolean)
         _docWriter = docWriter
         _engineType = engineType
         _sourceFiles = sourceFiles
         _destinationDirectory = destinationDirectory
         _format = format
         _loopContinuously = loopContinuously
         _logFileName = Path.Combine(destinationDirectory, "_Log.txt")

         ' number of documents to process together maximum of 8 or number of cores
         Dim maxThreadCount As Integer = Math.Min(8, Environment.ProcessorCount)
         Dim documentCount As Integer = sourceFiles.Length

         If loopContinuously Then
            _lblInformation.Text = String.Format("Total number of documents is {0}, maximum number of threads is {1}, Iteration {2}", documentCount, maxThreadCount, _iteration + 1)
         Else
            _lblInformation.Text = String.Format("Total number of documents is {0}, maximum number of threads is {1}", documentCount, maxThreadCount)
         End If

         _pbProgress.Minimum = 0
         _pbProgress.Maximum = documentCount
         _pbProgress.Value = 0
         _btnConvertMoreFiles.Enabled = False
         _btnCancel.Enabled = True
         _lbSuccess.Items.Clear()

         If Not loopContinuously Then
            _lbError.Items.Clear()
         End If

         _aborted = False

         Dim docWriterOptions As Byte() = Nothing
         Using ms As New MemoryStream()
            docWriter.SaveOptions(ms)
            docWriterOptions = ms.ToArray()
         End Using

         Try
            _ocrEngine = CreateEngine(_engineType, docWriterOptions)
         Catch ex As Exception
            OnError(ex.Message)
            OnDone()
            Return
         End Try

         ThreadPool.QueueUserWorkItem(Sub(state As Object)
                                         ' Queue up to maxThreadCount of threads a time
                                         Dim sourceFileIndex As Integer = 0
                                         Dim documentLeft As Integer = documentCount
                                         While documentLeft > 0 AndAlso Not _aborted
                                            Dim batchCount As Integer = Math.Min(maxThreadCount, documentLeft)
                                            _workItemCount = batchCount

                                            ClearQuarantine()

                                            Using batchFinishedEvent As AutoResetEvent = New AutoResetEvent(False)
                                               For i As Integer = 0 To batchCount - 1
                                                  Dim data As New WorkItemData()
                                                  data.DocumentWriterOptions = docWriterOptions
                                                  data.EngineType = engineType
                                                  data.OcrEngine = _ocrEngine
                                                  data.SourceFile = sourceFiles(i + sourceFileIndex)
                                                  data.DestinationDirectory = destinationDirectory
                                                  data.Format = format
                                                  data.FirstTry = True

                                                  ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf ThreadProc), data)
                                               Next

                                               _batchFinishedEvent = batchFinishedEvent
                                               batchFinishedEvent.WaitOne()

                                               'anything in the quarantine to retry?
                                               Dim quarantineList As New List(Of String)()
                                               GetQuarantine(quarantineList)

                                               For i As Integer = 0 To quarantineList.Count - 1
                                                  Dim data As New WorkItemData()
                                                  data.DocumentWriterOptions = docWriterOptions
                                                  data.EngineType = engineType
                                                  data.OcrEngine = _ocrEngine
                                                  data.SourceFile = quarantineList(i)
                                                  data.DestinationDirectory = destinationDirectory
                                                  data.Format = format
                                                  data.FirstTry = False

                                                  ThreadProc(data)
                                               Next

                                               sourceFileIndex += batchCount
                                               documentLeft -= batchCount
                                            End Using
                                         End While

                                         OnDone()

                                      End Sub)
      End Sub

      Private Shared Function CreateEngine(engineType As OcrEngineType, documentWriterOptions As Byte()) As IOcrEngine
         Dim ocrEngine As IOcrEngine = OcrEngineManager.CreateEngine(engineType, False)

         ocrEngine.Startup(Nothing, Nothing, Nothing, Nothing)

         Using ms As New MemoryStream(documentWriterOptions)
            ocrEngine.DocumentWriterInstance.LoadOptions(ms)
         End Using

         Dim codecs As RasterCodecs = ocrEngine.RasterCodecsInstance

         ' Use the new RasterizeDocumentOptions to default loading document files at 300 DPI
         codecs.Options.RasterizeDocument.Load.XResolution = 300
         codecs.Options.RasterizeDocument.Load.YResolution = 300
         codecs.Options.Pdf.Load.EnableInterpolate = True
         codecs.Options.Load.AutoFixImageResolution = True

         ' We fine-tuned our app to only run a certain number of threads. The OCR engine can spawn it is own
         ' threads to increase the performance of a single recognition process, however, we do not want this
         ' in this scenario, these extra threads will decrease the overall performance of our app and we will
         ' not be able to keep track of how many threads are actually running

         Dim settingManager As IOcrSettingManager = ocrEngine.SettingManager

         ' Disable multi-threaded recognition
         If settingManager.IsSettingNameSupported("Recognition.Threading.MaximumThreads") Then
            settingManager.SetIntegerValue("Recognition.Threading.MaximumThreads", 1)
         End If

         ' Disable multi-threaded auto-zoning
         If settingManager.IsSettingNameSupported("Recognition.Zoning.DisableMultiThreading") Then
            settingManager.SetBooleanValue("Recognition.Zoning.DisableMultiThreading", True)
         End If

         Return ocrEngine
      End Function

      Private Shared Sub SetRecommendedLoadingOptions(rasterCodecs As RasterCodecs, info As CodecsImageInfo, maximumMemorySize As Long)
         ' Do not throw exceptions if we cannot read the file, not our job
         Dim savedValue As Boolean = rasterCodecs.ThrowExceptionsOnInvalidImages

         Try
            Dim forceDiskMemory As Boolean = False
            Dim saveLoadDiskMemory As Boolean = rasterCodecs.Options.Load.DiskMemory
            Dim saveLoadCompressed As Boolean = rasterCodecs.Options.Load.Compressed
            Dim saveLoadSuperCompressed As Boolean = rasterCodecs.Options.Load.SuperCompressed
            Dim resolution As Integer = 300
            'always start with 300
            Dim newResolution As Integer = resolution

            If maximumMemorySize > 0 Then
               '0 means unlimited memory available!
               If info.SizeMemory > maximumMemorySize Then
                  ' Is this a document file format that uses resolution?
                  If info.Document.IsDocumentFile Then
                     ' Calculate the exact new resolution
                     Dim size As Long = CType(info.Width * info.Height * info.BitsPerPixel / 8, Long)
                     newResolution = CInt(Math.Truncate(CDbl(resolution) * CDbl(Math.Sqrt(CDbl(maximumMemorySize) / CDbl(size)))))

                     ' These are the DPI's to try, everything else is not a standard value and we dont want it
                     ' so find the closest to ours
                     Dim validResolutions As Integer() = {200, 150, 96, 72}
                     Dim validIndex As Integer = -1
                     Dim i As Integer = 0
                     While i < validResolutions.Length AndAlso validIndex = -1
                        If newResolution > validResolutions(i) Then
                           validIndex = i
                        End If
                        i += 1
                     End While

                     If validIndex = -1 Then
                        validIndex = validResolutions.Length - 1
                     End If

                     ' Re-calculate the size of memory with new resolution
                     Dim widthInInches As Double = CDbl(info.Width) / CDbl(info.XResolution)
                     Dim heightInInches As Double = CDbl(info.Height) / CDbl(info.YResolution)

                     newResolution = validResolutions(validIndex)
                     size = CLng((widthInInches * newResolution) * (heightInInches * newResolution) * info.BitsPerPixel / 8)
                     If size > maximumMemorySize Then
                        forceDiskMemory = True
                     End If
                  Else
                     forceDiskMemory = True
                  End If
               Else
                  forceDiskMemory = False
               End If
            End If

            If newResolution <> resolution Then
               rasterCodecs.Options.RasterizeDocument.Load.XResolution = newResolution
               rasterCodecs.Options.RasterizeDocument.Load.YResolution = newResolution
            End If

            If forceDiskMemory Then
               rasterCodecs.Options.Load.DiskMemory = True
               rasterCodecs.Options.Load.Compressed = False
               rasterCodecs.Options.Load.SuperCompressed = False
            End If
         Finally
            ' reset
            rasterCodecs.ThrowExceptionsOnInvalidImages = savedValue
         End Try
      End Sub

      Private Sub ThreadProc(stateInfo As Object)
         Dim data As WorkItemData = CType(stateInfo, WorkItemData)
         Dim ocrEngine As IOcrEngine = Nothing
         Dim passedCriticalStage As Boolean = False

         Try
            ' See if we have canceled
            SyncLock _abortedLockObject
               If _aborted Then
                  Return
               End If
            End SyncLock

            Dim destinationFile As String = Path.Combine(data.DestinationDirectory, Path.GetFileName(data.SourceFile))

            ocrEngine = data.OcrEngine

            SyncLock _abortedLockObject
               If _aborted Then
                  Return
               End If
            End SyncLock

            ' Convert this image file to a document
            Dim extension As String = DocumentWriter.GetFormatFileExtension(data.Format)
            destinationFile = String.Concat(destinationFile, ".", extension)
            If (data.Format = DocumentFormat.Ltd AndAlso File.Exists(destinationFile)) Then
               File.Delete(destinationFile)
            End If

            Dim sourceFile As String = Path.GetFileName(data.SourceFile)

            Try
               ' Create a document and add the pages
               Using ocrDocument As IOcrDocument = ocrEngine.DocumentManager.CreateDocument(Nothing, OcrCreateDocumentOptions.AutoDeleteFile)
                  ' Get the image number of pages
                  Dim imagePageCount As Integer

                  Dim codecs As RasterCodecs = ocrDocument.RasterCodecsInstance

                  Using imageInfo As CodecsImageInfo = codecs.GetInformation(data.SourceFile, True)
                     Dim maximumMemorySize As Long = 42187
                     Dim settingManager As IOcrSettingManager = ocrEngine.SettingManager

                     ' Get the maximum size of the bitmap from the setting
                     If settingManager.IsSettingNameSupported("Recognition.MaximumPageConventionalMemorySize") Then
                        Dim maximumConventionalMemorySize As Integer = settingManager.GetIntegerValue("Recognition.MaximumPageConventionalMemorySize")
                        maximumMemorySize = CLng(maximumConventionalMemorySize) * 1024
                     End If

                     SetRecommendedLoadingOptions(codecs, imageInfo, maximumMemorySize)

                     imagePageCount = imageInfo.TotalPages
                  End Using

                  ' Set the DocumentWriter options
                  Using ms As New MemoryStream(data.DocumentWriterOptions)
                     ocrDocument.DocumentWriterInstance.LoadOptions(ms)
                  End Using

                  passedCriticalStage = True

                  'recognize and add pages
                  For pageNumber As Integer = 1 To imagePageCount
                     SyncLock _abortedLockObject
                        If _aborted Then
                           Return
                        End If
                     End SyncLock

                     Dim image As RasterImage = codecs.Load(data.SourceFile, pageNumber)

                     Using ocrPage As IOcrPage = ocrEngine.CreatePage(image, OcrImageSharingMode.AutoDispose)
                        ocrPage.Recognize(Nothing)
                        ocrDocument.Pages.Add(ocrPage)
                     End Using
                  Next

                  ' Save
                  ocrDocument.Save(destinationFile, data.Format, Nothing)
               End Using
            Finally
            End Try

            OnSuccess(destinationFile)
         Catch ex As Exception
            Dim message As String

            If passedCriticalStage AndAlso data.FirstTry Then
               message = String.Format("Error '{0}' while converting file '{1}' (first time, quarantined)", ex.Message, data.SourceFile)
               AddToQuarantine(data.SourceFile)
            ElseIf passedCriticalStage AndAlso Not data.FirstTry Then
               message = String.Format("Error '{0}' while converting file '{1}' (quarantined error)", ex.Message, data.SourceFile)
            Else
               message = String.Format("Error '{0}' while converting file '{1}'", ex.Message, data.SourceFile)
            End If

            OnError(message)
         Finally
            If (ocrEngine IsNot Nothing) AndAlso ocrEngine IsNot data.OcrEngine Then
               ocrEngine.Dispose()
            End If

            If Interlocked.Decrement(_workItemCount) = 0 Then
               _batchFinishedEvent.Set()
            End If
         End Try
      End Sub

      Private Shared Sub ScrollToBottom(listBox As ListBox)
         Dim visibleItems As Integer = listBox.ClientSize.Height \ listBox.ItemHeight
         listBox.TopIndex = Math.Max(listBox.Items.Count - visibleItems + 1, 0)
      End Sub

      Private Sub OnSuccess(destinationFile As String)
         Me.BeginInvoke(New MethodInvoker(Sub()
                                             Dim now As DateTime = DateTime.Now

                                             _pbProgress.Increment(1)
                                             _lbSuccess.Items.Add(destinationFile)
                                             ScrollToBottom(_lbSuccess)

                                             Using sw As StreamWriter = File.AppendText(_logFileName)
                                                sw.WriteLine("Success: Iteration {0} at {1} {2}", _iteration + 1, now, destinationFile)
                                             End Using

                                          End Sub))

         Application.DoEvents()
      End Sub

      Private Sub OnError(message As String)
         Me.BeginInvoke(New MethodInvoker(Sub()
                                             Dim now As DateTime = DateTime.Now

                                             _pbProgress.Increment(1)
                                             _lbError.Items.Add(now & " " & message)
                                             ScrollToBottom(_lbError)

                                             Using sw As StreamWriter = File.AppendText(_logFileName)
                                                sw.WriteLine("Error:  Iteration {0} at {1} {2}", _iteration + 1, now, message)
                                             End Using

                                          End Sub))

         Application.DoEvents()
      End Sub

      Private _quarantineListLockObject As New Object()
      Private _quarantineList As New List(Of String)()
      Private Sub AddToQuarantine(fileName As String)
         SyncLock _quarantineListLockObject
            _quarantineList.Add(fileName)
         End SyncLock
      End Sub

      Private Sub GetQuarantine(quarantineList As List(Of String))
         SyncLock _quarantineListLockObject
            quarantineList.AddRange(_quarantineList)
         End SyncLock
      End Sub

      Private Sub ClearQuarantine()
         SyncLock _quarantineListLockObject
            _quarantineList.Clear()
         End SyncLock
      End Sub

      Private Sub OnMessage(message As String)
         Me.BeginInvoke(New MethodInvoker(Sub() _lbError.Items.Add(message)))

         Application.DoEvents()
      End Sub

      Private Sub OnDone()
         Me.BeginInvoke(New MethodInvoker(Sub()
                                             If _ocrEngine IsNot Nothing Then
                                                _ocrEngine.Dispose()
                                             End If

                                             If _aborted Then
                                                _lblInformation.Text = "Aborted"
                                             Else
                                                _lblInformation.Text = "Done"
                                             End If

                                             _pbProgress.Value = 0
                                             _btnConvertMoreFiles.Enabled = True
                                             _btnCancel.Enabled = False

                                             If Not _aborted AndAlso _loopContinuously Then
                                                _iteration += 1
                                                Convert(_docWriter, _engineType, _sourceFiles, _destinationDirectory, _format, _loopContinuously)
                                             Else
                                                _iteration = 0

                                                RaiseEvent ConversionFinished(Me, EventArgs.Empty)
                                             End If

                                          End Sub))

         Application.DoEvents()
      End Sub
   End Class
End Namespace
