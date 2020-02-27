' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.Win32

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.WinForms
Imports Leadtools.WinForms.CommonDialogs.File
Imports Leadtools.Codecs
Imports Leadtools.Forms.Processing
Imports Leadtools.Forms.Recognition
Imports Leadtools.Ocr
Imports Leadtools.Forms.Recognition.Barcode
Imports Leadtools.Forms.Recognition.Ocr
Imports Leadtools.Demos
Imports Leadtools.Twain
Imports Leadtools.Barcode
Imports Leadtools.ImageProcessing.Core
Imports System.Diagnostics
Imports Leadtools.Demos.Dialogs
Imports Leadtools.Forms.Common

Namespace FormsDemo
   Partial Public Class MainForm : Inherits Form
      Private ocrEngine As IOcrEngine
      Private cleanUpOcrEngine As IOcrEngine
      Private barcodeEngine As BarcodeEngine
      Private recognitionEngine As FormRecognitionEngine
      Private processingEngine As FormProcessingEngine
      Private rasterCodecs As RasterCodecs
      Private scannedImage As RasterImage
      Private canceled As Boolean = False
      Private ocrEngineType As OcrEngineType
      Private recognitionTimer As Stopwatch = New Stopwatch()
      Private twainSession As TwainSession = Nothing
      Private recognitionInProcess As Boolean = False
      Private currentMasterCount As Integer = 0
      Private scannerMessage As String = String.Format("Although scanning can be implemented in multiple ways within a Forms Recognition and processing application, this demo uses the below implementation:{0}{0}" & "1) The scanner must have a feeder{0}" & "2) Any number of filled forms can be loaded into the scanner in any order. Pages within each filled form must be in order however.{0}" & "3) Only the first page will be used for recognition. Once the first page of a form is scanned, recognized, and processed, the rest of the pages for that form (if multipage) will be scanned and processed as needed. This process is repeated for all forms.{0}" & "4) We will attempt to set your scanner to scan in B/W at 300DPI. If your scanner does not support this configuration, an error message will appear and the scanner dialog will be shown so that you can configure the scanner's settings.", Environment.NewLine)
      Private _openInitialPath As String = String.Empty

      Public Sub New()
         InitializeComponent()
      End Sub

      <STAThread()> _
      Shared Sub Main()
         
         If Not Support.SetLicense() Then
            Return
         End If

         Dim bLocked As Boolean = RasterSupport.IsLocked(RasterSupportType.Forms)
         If bLocked Then
            MessageBox.Show("Forms support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End If

         Dim bOCRLocked As Boolean = RasterSupport.IsLocked(RasterSupportType.OcrLEAD) Or RasterSupport.IsLocked(RasterSupportType.OcrOmniPage)
            If bOCRLocked Then
                MessageBox.Show("OCR support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If bLocked Or bOCRLocked Then
                Return
            End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainForm())
      End Sub

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         If (Not DesignMode) Then
            BeginInvoke(New MethodInvoker(AddressOf Startup))
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Sub Startup()
         Try
            If (Not StartUpEngines()) Then
               Messager.ShowError(Me, "One or more required engines did not start. The application will now close.")
               Me.Close()
               Return
            End If

            _txtMasterFormRespository.Text = GetFormsDir()
            currentMasterCount = GetMasterFormCount()
            SetupRecognitionEngine()
            SetupProcessingEngine()

            Messager.Caption = "LEADTOOLS Forms Demo"
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try

         UpdateControls()
      End Sub

      Private Sub UpdateControls()

         Dim twainIsAvailable As Boolean = TwainSession.IsAvailable(Me.Handle)

         _lblMasterFormRespository.Text = String.Format("Master Form Respository (Count = {0})", currentMasterCount)
         _menuItemRecognition.Enabled = Not recognitionInProcess
         _menuItemRecognizeScannedForms.Enabled = currentMasterCount > 0 AndAlso Not twainSession Is Nothing AndAlso twainIsAvailable AndAlso Not recognitionInProcess
         _menuItemRecognizeSingleForm.Enabled = currentMasterCount > 0 AndAlso Not recognitionInProcess
         _menuItemRecognizeMultipleForms.Enabled = currentMasterCount > 0 AndAlso Not recognitionInProcess

         _menuItemFile.Enabled = Not recognitionInProcess
         _menuItemOptions.Enabled = Not recognitionInProcess
         _menuItemHelp.Enabled = Not recognitionInProcess
         _btnBrowseMasterFormRespository.Enabled = Not recognitionInProcess

         _btnCancel.Enabled = recognitionInProcess

         If (Not recognitionInProcess) Then
            _lblFormName.Text = "Form Name: NA"
            _pbProgress.Value = 0
         End If
      End Sub

      Private Function GetMasterFormCount() As Integer
         Try
            Dim files As String() = Directory.GetFiles(_txtMasterFormRespository.Text, "*.bin", SearchOption.AllDirectories)
            Return files.Length
         Catch
            Return 0
         End Try
      End Function

      Private Function GetFormsDir() As String
         Dim formsDir As String
         If _rb_OCR.Checked = True Then
            formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\MasterForm Sets\OCR"
         ElseIf _rb_OCR_ICR.Checked = True Then
            formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\MasterForm Sets\OCR_ICR"
            ElseIf _rb_DL.Checked = True Then
                formsDir = DemosGlobal.ImagesFolder + "\" + "Forms\MasterForm Sets\Driving License"
            ElseIf _rb_Invoice.Checked = True Then
                formsDir = DemosGlobal.ImagesFolder + "\" + "Forms\MasterForm Sets\Invoice"
            Else
                formsDir = DemosGlobal.ImagesFolder + "\" + "Forms\MasterForm Sets\OMR"
            End If

            Return formsDir
      End Function

        Private Function GetPageType() As FormsPageType
            Dim pageType As FormsPageType = FormsPageType.Normal
            If _rb_DL.Checked = True Then
                pageType = FormsPageType.IDCard
            ElseIf _rb_Omr.Checked = True Then
                pageType = FormsPageType.Omr
            End If
            Return pageType
        End Function

        Private Sub _menuItemRecognizeMultipleForms_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemRecognizeMultipleForms.Click
            Try
                recognitionInProcess = True
                UpdateControls()

            Dim fbd As FolderBrowserDialogEx = New FolderBrowserDialogEx()
                Try
               fbd.SelectedPath = GetSamplesPath()
               fbd.ShowNewFolderButton = False
               fbd.ShowFullPathInEditBox = True
               fbd.ShowEditBox = True
                    If fbd.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                        canceled = False
                        Dim files As String() = Directory.GetFiles(fbd.SelectedPath)
                        AddOperationTime(Nothing, Nothing, TimeSpan.Zero, True)
                        Dim recognizedForms As List(Of FilledForm) = New List(Of FilledForm)()
                        For Each file As String In files
                            'recognize and process each file in the directory
                            Application.DoEvents()
                            If (Not canceled) Then
                                Try
                                    Dim newForm As FilledForm = New FilledForm()
                                    newForm.FileName = file
                                    newForm.Name = Path.GetFileNameWithoutExtension(file)
                                    _lblFormName.Text = String.Concat("Form Name: ", newForm.Name)
                                    _lblStatus.Text = "Status: NA"
                                    'Load the image
                                    newForm.Image = LoadImageFile(file, 1, -1)
                                    'Run the recognition and processing
                                    If RunFormRecognitionAndProcessing(newForm) Then
                                        recognizedForms.Add(newForm)
                                    End If
                                Catch
                                    'Do nothing since we are processing a directory of images
                                    'and do not want to stop execution
                                End Try
                            End If
                        Next file

                        ShowResults(recognizedForms)
                    End If
                Finally
                    CType(fbd, IDisposable).Dispose()
                End Try
            Catch exp As Exception
                Messager.ShowError(Me, exp)
            Finally
                recognitionInProcess = False
                UpdateControls()
            End Try
        End Sub

      Private Sub _menuItemRecognizeSingleForm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemRecognizeSingleForm.Click
         Try
            recognitionInProcess = True
            UpdateControls()

            'Create and initialize ImageFileLoader class
            Dim loader As ImageFileLoader = New ImageFileLoader()
            loader.ShowLoadPagesDialog = True
            loader.OpenDialogInitialPath = GetSamplesPath()
            'loader.OpenDialogInitialPath = _openInitialPath

            AddOperationTime(Nothing, Nothing, TimeSpan.Zero, True)
            If loader.Load(Me, rasterCodecs, False) > 0 Then
               _openInitialPath = Path.GetDirectoryName(loader.FileName)
               canceled = False
               Dim newForm As FilledForm = New FilledForm()
               newForm.FileName = loader.FileName
               newForm.Name = Path.GetFileNameWithoutExtension(loader.FileName)
               _lblFormName.Text = String.Concat("Form Name: ", newForm.Name)
               _lblStatus.Text = "Status: NA"
               'Load the image
               newForm.Image = LoadImageFile(loader.FileName, loader.FirstPage, loader.LastPage)
               'Run the recognition and processing
               Dim recognizedForms As List(Of FilledForm) = New List(Of FilledForm)()
               If RunFormRecognitionAndProcessing(newForm) Then
                  recognizedForms.Add(newForm)
               End If

               ShowResults(recognizedForms)
            End If
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         Finally
            recognitionInProcess = False
            UpdateControls()
         End Try
      End Sub

      Private Sub _menuItemRecognizeScannedForms_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemRecognizeScannedForms.Click
         Try
            recognitionInProcess = True
            UpdateControls()

            If MessageBox.Show(scannerMessage, "Scanning", MessageBoxButtons.OKCancel) = DialogResult.Cancel Then
               Return
            End If

            'select the desired scanner
            If twainSession.SelectSource(String.Empty) <> System.Windows.Forms.DialogResult.OK Then
               Return
            End If

            canceled = False
            _lblStatus.Text = "Status: NA"

            Application.DoEvents()
            'keep scanning until the feeder is empty
            AddOperationTime(Nothing, Nothing, TimeSpan.Zero, True)
            Dim recognizedForms As List(Of FilledForm) = New List(Of FilledForm)()
            Do While FeederLoaded() AndAlso Not canceled
               Dim filledForm As FilledForm = New FilledForm()
               If Not scannedImage Is Nothing Then
                  scannedImage.Dispose()
               End If
               'recognize and process the scanned images
               If RunFormRecognitionAndProcessingScanner(filledForm) Then
                  recognizedForms.Add(filledForm)
               End If
               Application.DoEvents()
            Loop

            ShowResults(recognizedForms)
         Catch exp As Exception
            If (Not exp.Message.Contains("no need for your app to report the error")) Then
               Messager.ShowError(Me, exp)
            End If
         Finally
            recognitionInProcess = False
            UpdateControls()
         End Try
      End Sub

      Private Function GetSamplesPath() As String
         Dim formsDir As String
         If _rb_OCR.Checked = True Then
            formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\Forms to be Recognized\OCR"
            ElseIf _rb_OCR_ICR.Checked = True Then
                formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\Forms to be Recognized\OCR_ICR"
            ElseIf _rb_DL.Checked = True Then
                formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\Forms to be Recognized\Driving License"
            ElseIf _rb_Invoice.Checked = True Then
                formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\Forms to be Recognized\Invoice"
            Else
                formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\Forms to be Recognized\OMR"

         End If
         Return formsDir
      End Function

      Private Sub ShowResults(ByVal recognizedForms As List(Of FilledForm))
         If (Not canceled) Then
            If recognizedForms.Count > 0 Then
               'Show the results
               _lblStatus.Text = "Status: Complete"
               Dim resultDialog As RecognitionResult = New RecognitionResult(recognizedForms)
               resultDialog.ShowDialog(Me)
            Else
               _lblStatus.Text = "Status: No Forms Recognized"
            End If
         Else
            _lblStatus.Text = "Status: Canceled"
         End If
      End Sub

      Private Sub twnSession_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs)
         Try
            If e.Image Is Nothing Then
               Return
            End If
            If Not scannedImage Is Nothing AndAlso (Not scannedImage.IsDisposed) Then
               scannedImage.AddPage(e.Image.Clone())
            Else
               scannedImage = e.Image.Clone()
            End If
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         ShutDownEngines()
      End Sub

      Private Sub ShutDownEngines()
         Dim settings As My.Settings = New My.Settings()
         settings.OcrEngineType = ocrEngineType.ToString()
         settings.Save()

         If Not ocrEngine Is Nothing AndAlso ocrEngine.IsStarted Then
            ocrEngine.Shutdown()
            ocrEngine.Dispose()
         End If

         If Not cleanUpOcrEngine Is Nothing AndAlso cleanUpOcrEngine.IsStarted Then
            cleanUpOcrEngine.Shutdown()
            cleanUpOcrEngine.Dispose()
         End If

         If Not twainSession Is Nothing Then
            twainSession.Shutdown()
         End If
      End Sub

      Private Function FeederLoaded() As Boolean
         Try
            'first enable feeder
            Dim autoFeedCap As TwainCapability = New TwainCapability()

            autoFeedCap.Information.Type = TwainCapabilityType.FeederEnabled
            autoFeedCap.Information.ContainerType = TwainContainerType.OneValue

            autoFeedCap.OneValueCapability.ItemType = TwainItemType.Bool
            autoFeedCap.OneValueCapability.Value = True

            twainSession.SetCapability(autoFeedCap, TwainSetCapabilityMode.Set)

            'now check if feeder is loaded
            Dim feederLoadedCap As TwainCapability = New TwainCapability()
            feederLoadedCap = twainSession.GetCapability(TwainCapabilityType.FeederLoaded, TwainGetCapabilityMode.GetValues)
            Return CBool(feederLoadedCap.OneValueCapability.Value)
         Catch
            Throw New Exception("To recognize scanned pages in this demo, your scanner must have a feeder")
         End Try
      End Function

      Public Sub LoadImageScanner(ByVal numPages As Integer)
         If (Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, twainSession.SelectedSourceName())) Then
            Return
         End If
         Dim showUI As Boolean = False
         'Set the scanner to scan a specified number of pages, scan at 1bpp B/W, and at 300DPI
         Try
            twainSession.MaximumTransferCount = numPages
            twainSession.Resolution = New SizeF(300, 300)
            Dim twainProps As TwainProperties = twainSession.Properties
            Dim imageEfx As TwainImageEffectsProperties = twainProps.ImageEffects
            imageEfx.ColorScheme = TwainColorScheme.BlackWhite
            twainProps.ImageEffects = imageEfx
            twainSession.Properties = twainProps
            twainSession.ImageBitsPerPixel = 1
         Catch
            MessageBox.Show("Unable to set scanner to 1BPP B/W - 300DPI.")
            showUI = True
         End Try

         Dim stopWatch As Stopwatch = New Stopwatch()
         stopWatch.Start()
         If showUI Then
            twainSession.Acquire(TwainUserInterfaceFlags.Modal)
         Else
            twainSession.Acquire(TwainUserInterfaceFlags.None)
         End If
         stopWatch.Stop()
         AddOperationTime("NA", "Scan Image", stopWatch.Elapsed, False)
         'Only clean new pages
         CleanupImage(scannedImage, String.Empty, (scannedImage.PageCount - numPages) + 1, numPages)
      End Sub

      'Used to display the amount of time a specific operation may take
      Private Sub AddOperationTime(ByVal imageFile As String, ByVal operationName As String, ByVal operationTime As TimeSpan, ByVal clearExisting As Boolean)
         If clearExisting Then
            _lvLastOperation.Items.Clear()
         End If

         If (Not String.IsNullOrEmpty(imageFile)) Then
            _lvLastOperation.Items.Add(imageFile)
            _lvLastOperation.Items(_lvLastOperation.Items.Count - 1).SubItems.Add(operationName)
            _lvLastOperation.Items(_lvLastOperation.Items.Count - 1).SubItems.Add(Convert.ToString(Math.Round(operationTime.TotalSeconds, 2)))
         End If
         Application.DoEvents()
      End Sub

      Public Function LoadImageFile(ByVal fileName As String, ByVal firstPage As Integer, ByVal lastPage As Integer) As RasterImage
         ' Load the image 
         Dim stopWatch As Stopwatch = New Stopwatch()
         stopWatch.Start()
         Dim image As RasterImage = rasterCodecs.Load(fileName, 0, CodecsLoadByteOrder.Bgr, firstPage, lastPage)
         stopWatch.Stop()
         AddOperationTime(Path.GetFileNameWithoutExtension(fileName), "Load Image", stopWatch.Elapsed, False)
         Return image
      End Function


      Public Sub CreateFormForRecognition(ByVal form As FilledForm, ByVal method As FormsRecognitionMethod)

         form.Attributes = CreateForm(method)
         Dim saveCurrentPageIndex As Integer = form.Image.Page
         Dim image As RasterImage = form.Image.CloneAll()
         Dim i As Integer = 0
         Do While i < form.Image.PageCount
            If (Not canceled) Then
               form.Image.Page = i + 1 'page index is a 1-based starts from 1 not zero

                    Dim pageOptions As PageRecognitionOptions = New PageRecognitionOptions()
                    pageOptions.UpdateImage = True
                    pageOptions.PageType = GetPageType()

               AddPageToForm(form.Image, form.Attributes, pageOptions)

               Application.DoEvents()
            End If
            i += 1
         Loop
         form.Image = image
         form.Image.Page = saveCurrentPageIndex
      End Sub

      Public Function CreateForm(ByVal method As FormsRecognitionMethod) As FormRecognitionAttributes
         Dim options As FormRecognitionOptions = New FormRecognitionOptions()
         options.RecognitionMethod = method
         Dim attributes As FormRecognitionAttributes = recognitionEngine.CreateForm(options)
         recognitionEngine.CloseForm(attributes)
         Return attributes
      End Function

      Public Sub AddPageToForm(ByVal image As RasterImage, ByVal attributes As FormRecognitionAttributes, ByVal options As PageRecognitionOptions)
         recognitionEngine.OpenForm(attributes)
         recognitionEngine.AddFormPage(attributes, image, options)
         recognitionEngine.CloseForm(attributes)
      End Sub

      Private Function CompareFormsFast(ByVal formAttributes As FormRecognitionAttributes, ByVal masterForms As List(Of MasterForm), ByRef foundedMasterForm As MasterForm) As FormRecognitionResult
         Dim mastersAttributes As List(Of FormRecognitionAttributes) = New List(Of FormRecognitionAttributes)()
         Dim i As Integer = 0
         Do While i < masterForms.Count
            mastersAttributes.Add(masterForms(i).Attributes)
            mastersAttributes(mastersAttributes.Count - 1).Image = masterForms(i).Image
            i += 1
         Loop

         Dim result As FormRecognitionResult = recognitionEngine.CompareFormFast(mastersAttributes, formAttributes, Nothing)
         'Find selected MasterForm
         Dim masterAttributes As FormRecognitionAttributes = result.MasterAttributes
         If Not masterAttributes Is Nothing Then
            i = 0
            Do While i < mastersAttributes.Count
               If mastersAttributes(i) Is masterAttributes Then
                  foundedMasterForm = masterForms(i)
                  Exit Do
               End If
               i += 1
            Loop
         End If

         'check for missing page results
         If result.Reason = FormRecognitionReason.Success AndAlso result.Confidence > 0 Then
            Dim missingPageIndeces As List(Of Integer) = New List(Of Integer)()
            i = 0
            Do While i < result.PageResults.Count
               If result.PageResults(i) Is Nothing Then
                  missingPageIndeces.Add(i)
               End If
               i += 1
            Loop

            If missingPageIndeces.Count > 0 Then

               recognitionEngine.OpenForm(formAttributes)
               recognitionEngine.OpenMasterForm(masterAttributes)

               i = 0
               Do While i < missingPageIndeces.Count
                  Dim pageOptions As PageRecognitionOptions = New PageRecognitionOptions()
                        formAttributes.Image.Page = missingPageIndeces(i) + 1
                        pageOptions.PageType = GetPageType()
                        recognitionEngine.DeleteFormPage(formAttributes, missingPageIndeces(i) + 1)
                  recognitionEngine.InsertFormPage(missingPageIndeces(i) + 1, formAttributes, formAttributes.Image, pageOptions, Nothing)
                  result.PageResults(missingPageIndeces(i)) = recognitionEngine.ComparePage(masterAttributes, missingPageIndeces(i) + 1, formAttributes, missingPageIndeces(i) + 1)
                  i += 1
               Loop

               recognitionEngine.CloseForm(formAttributes)
               recognitionEngine.CloseMasterForm(masterAttributes)

               ' Total the confidence
               Dim maxPageIndex As Integer = 0
               Dim maxConfidence As Integer = 0
               Dim confidenceSum As Integer = 0
               i = 0
               Do While i < result.PageResults.Count
                  Dim pageResult As PageRecognitionResult = result.PageResults(i)
                  confidenceSum += pageResult.Confidence
                  If pageResult.Confidence > maxConfidence Then
                     maxConfidence = pageResult.Confidence
                     maxPageIndex = i
                  End If
                  i += 1
               Loop

               ' all pages have the same weight here , this meight change in the future, we may give more weight to the first pages

               ' rounded to the closest integer
               If result.PageResults.Count > 0 Then
                  result.Confidence = CInt((confidenceSum + result.PageResults.Count / 2) / result.PageResults.Count)
               Else
                  result.Confidence = 0
               End If

               result.LargestConfidencePageNumber = maxPageIndex + 1
            End If
         End If

         Return result
      End Function



      Private Function CompareForm(ByVal master As FormRecognitionAttributes, ByVal form As FormRecognitionAttributes, ByVal isExtended As Boolean) As FormRecognitionResult
         _pbProgress.Step = 1
         _pbProgress.Minimum = 0
         _pbProgress.Value = 0
         _pbProgress.Maximum = 100
         If isExtended Then
            Return recognitionEngine.CompareExtendedForm(master, form, New FormProgressCallback(AddressOf RecognitionFormCallback), Nothing)
         Else
            Return recognitionEngine.CompareForm(master, form, New FormProgressCallback(AddressOf RecognitionFormCallback))
         End If
      End Function

      Private Function CompareFirstPage(ByVal master As FormRecognitionAttributes, ByVal form As FormRecognitionAttributes) As FormRecognitionResult
         _pbProgress.Step = 1
         _pbProgress.Minimum = 0
         _pbProgress.Value = 0
         _pbProgress.Maximum = 100
         Dim resultPage As PageRecognitionResult = recognitionEngine.ComparePage(master, 1, form, 1, New PageProgressCallback(AddressOf RecognitionPageCallback))
         Dim result As FormRecognitionResult = New FormRecognitionResult()
         result.Confidence = resultPage.Confidence
         result.LargestConfidencePageNumber = 1
         result.PageResults.Add(resultPage)
         result.Reason = FormRecognitionReason.Success
         Return result
      End Function

      'Finds the master form with the highest confidence and returns it's index. 
      'If the highest confidence is < 30, we consider this form having no match
      Public Function IdentifyForm(ByVal results As List(Of FormRecognitionResult)) As Integer
         Dim maxIndex As Integer = 0
         Dim i As Integer = 1
         Do While i < results.Count
            If results(maxIndex).Confidence < results(i).Confidence Then
               maxIndex = i
            End If
            i += 1
         Loop
         If results(maxIndex).Confidence < 30 Then
            maxIndex = -1 'no match
         End If
         Return maxIndex
      End Function

      Private Function RecognitionFormCallback(ByVal currentPage As Integer, ByVal totalPages As Integer, ByVal percentage As Integer) As Boolean
         If canceled Then
            Return False
         End If

         _pbProgress.Value = percentage
         Return True
      End Function

      Private Sub RecognitionPageCallback(ByVal data As PageProgressCallbackData)
         _pbProgress.Value = data.Percentage
      End Sub


      Public Function RecognizeFormComplex(ByVal form As FilledForm) As Boolean
         _lblStatus.Text = "Status: Generating Form Attributes..."
         Application.DoEvents()

         Dim stopWatch As Stopwatch = New Stopwatch()
         stopWatch.Start()
         CreateFormForRecognition(form, FormsRecognitionMethod.Complex)
         stopWatch.Stop()
         AddOperationTime(form.Name, "Generate Attributes", stopWatch.Elapsed, False)

         stopWatch.Reset()
         stopWatch.Start()
         Dim results As List(Of FormRecognitionResult) = New List(Of FormRecognitionResult)()
         Dim masterFormAttributes As String() = Directory.GetFiles(_txtMasterFormRespository.Text, "*.bin", SearchOption.AllDirectories)
         Dim currentMasterForm As MasterForm = Nothing
         For Each masterFormAttribute As String In masterFormAttributes
            Dim fieldsfName As String = String.Concat(Path.GetFileNameWithoutExtension(masterFormAttribute), ".xml")
            Dim fieldsfullPath As String = Path.Combine(Path.GetDirectoryName(masterFormAttribute), fieldsfName)
            currentMasterForm = LoadMasterForm(masterFormAttribute, fieldsfullPath)

            If (Not canceled) Then
               _pbProgress.Value = 0
               _lblStatus.Text = String.Concat("Status: Comparing with Master form: ", currentMasterForm.Properties.Name)
               Application.DoEvents()

               If _menuItemRecognizeFirstPageOnly.Checked AndAlso (Not currentMasterForm.IsExtendable) Then
                  results.Add(CompareFirstPage(currentMasterForm.Attributes, form.Attributes))
               Else
                  results.Add(CompareForm(currentMasterForm.Attributes, form.Attributes, currentMasterForm.IsExtendable))
               End If

               'If we recognize a form with 80% or higher confidence, stop searching
               If results(results.Count - 1).Confidence >= 80 Then
                  Exit For
               End If
            Else
               stopWatch.Stop()
               Return False
            End If
         Next masterFormAttribute

         stopWatch.Stop()
         AddOperationTime(form.Name, "Recognize Form", stopWatch.Elapsed, False)

         If (Not canceled) Then
            Dim index As Integer = IdentifyForm(results)
            If index >= 0 Then
               Dim fieldsfName As String = String.Concat(Path.GetFileNameWithoutExtension(masterFormAttributes(index)), ".xml")
               Dim fieldsfullPath As String = Path.Combine(Path.GetDirectoryName(masterFormAttributes(index)), fieldsfName)
               form.Master = LoadMasterForm(masterFormAttributes(index), fieldsfullPath)
               Dim formPages As FormPages = form.Master.ProcessingPages
               Dim alignments As List(Of PageAlignment) = New List(Of PageAlignment)()
               Dim i As Integer = 0
               Do While i < results(index).PageResults.Count
                  alignments.Add(results(index).PageResults(i).Alignment)
                  i += 1
               Loop
               recognitionEngine.FillFieldsInformation(form.Image, form.Master.Attributes, form.Attributes, formPages, alignments)
               form.ProcessingPages = formPages
               form.Result = results(index)
               Return True
            Else
               Return False 'no match
            End If
         Else
            Return False
         End If
      End Function

      Public Function RecognizeFormSimple(ByVal form As FilledForm) As Boolean
         _lblStatus.Text = "Status: Generating Form Attributes..."
         Application.DoEvents()
         Dim stopWatch As Stopwatch = New Stopwatch()
         stopWatch.Start()
         CreateFormForRecognition(form, FormsRecognitionMethod.Simple)
         stopWatch.Stop()
         AddOperationTime(form.Name, "Generate Attributes", stopWatch.Elapsed, False)

         stopWatch.Reset()
         stopWatch.Start()
         Dim masterFormAttributes As String() = Directory.GetFiles(_txtMasterFormRespository.Text, "*.bin", SearchOption.AllDirectories)
         Dim masterForms As List(Of MasterForm) = New List(Of MasterForm)()
         Dim currentMasterForm As MasterForm = Nothing
         For Each masterFormAttribute As String In masterFormAttributes
            Dim fieldsfName As String = String.Concat(Path.GetFileNameWithoutExtension(masterFormAttribute), ".xml")
            Dim fieldsfullPath As String = Path.Combine(Path.GetDirectoryName(masterFormAttribute), fieldsfName)
            currentMasterForm = LoadMasterForm(masterFormAttribute, fieldsfullPath)

            Dim isCard As Boolean = HasIDCard(currentMasterForm.Attributes, currentMasterForm.Properties)
            If (Not currentMasterForm.IsExtendable) AndAlso (Not isCard) Then
               masterForms.Add(currentMasterForm)
               Dim imageName As String = String.Concat(Path.GetFileNameWithoutExtension(masterFormAttribute), ".tif")
               Dim imagefullPath As String = Path.Combine(Path.GetDirectoryName(masterFormAttribute), imageName)
               masterForms(masterForms.Count - 1).Image = rasterCodecs.Load(imagefullPath, 0, CodecsLoadByteOrder.BgrOrGrayOrRomm, 1, -1)
            End If
         Next masterFormAttribute

         'we must add image to Form Attributes to use Simple Method
         form.Attributes.Image = form.Image
         Dim foundedMasterForm As MasterForm = Nothing
         Dim result As FormRecognitionResult = CompareFormsFast(form.Attributes, masterForms, foundedMasterForm)

         stopWatch.Stop()
         AddOperationTime(form.Name, "Recognize Form", stopWatch.Elapsed, False)

         If (Not canceled) Then
            If Not foundedMasterForm Is Nothing Then
               form.Master = foundedMasterForm
               Dim formPages As FormPages = form.Master.ProcessingPages
               Dim alignments As List(Of PageAlignment) = New List(Of PageAlignment)()
               Dim i As Integer = 0
               Do While i < result.PageResults.Count
                  alignments.Add(result.PageResults(i).Alignment)
                  i += 1
               Loop
               recognitionEngine.FillFieldsInformation(form.Image, form.Master.Attributes, form.Attributes, formPages, Nothing)
               form.ProcessingPages = formPages
               form.Result = result
               Return True
            Else
               Return False 'no match
            End If
         Else
            Return False
         End If
      End Function

      Private Function HasIDCard(ByVal masterAttributes As FormRecognitionAttributes, ByVal properties As FormRecognitionProperties) As Boolean
         Dim engine As FormRecognitionEngine = New FormRecognitionEngine()
         engine.OpenMasterForm(masterAttributes)

         Dim isCard As Boolean = False
         Dim i As Integer = 0
         Do While i < properties.Pages
            Dim options As PageRecognitionOptions = engine.GetPageOptions(masterAttributes, i)
            If Not options Is Nothing Then
               If options.PageType = FormsPageType.IDCard Then
                  isCard = True
                  Exit Do
               End If
            End If
            i += 1
         Loop

         engine.CloseMasterForm(masterAttributes)


         Return isCard
      End Function

      Public Sub AlignForm(ByVal form As FilledForm, ByVal calculateAlignment As Boolean)
         If calculateAlignment Then

            CreateFormForRecognition(form, FormsRecognitionMethod.Complex)

            form.Alignment = recognitionEngine.GetFormAlignment(form.Master.Attributes, form.Attributes, Nothing)
         Else
            form.Alignment = New List(Of PageAlignment)()
            Dim i As Integer = 0
            Do While i < form.Result.PageResults.Count
               form.Alignment.Add(form.Result.PageResults(i).Alignment)
               i += 1
            Loop
         End If
      End Sub

      Private Sub processingEngine_ProcessField(ByVal sender As Object, ByVal e As ProcessFieldEventArgs)
         If canceled Then
            e.Cancel = True
            Return
         End If

         If Not e.Field Is Nothing Then
            _lblStatus.Text = String.Format("Status: Processing form fields... (Page: {0} of {1} Field Name: {2})", e.FormCurrentPageNumber, e.FormLastPageNumber, e.Field.Name)
         End If

         _pbProgress.PerformStep()
         Application.DoEvents()
      End Sub

      Private Function GetTotalFieldCount(ByVal form As FilledForm) As Integer
         Dim count As Integer = 0
         For Each page As FormPage In form.ProcessingPages
            For Each field As FormField In page
               count += 1
            Next field
         Next page

         Return count
      End Function

      Public Sub ProcessForm(ByVal form As FilledForm)
         If form.Master.ProcessingPages Is Nothing Then
            Return 'no fields
         End If

         _lblStatus.Text = "Status: Processing form fields..."

         If form.ProcessingPages Is Nothing Then
            form.ProcessingPages = form.Master.ProcessingPages
         End If

         processingEngine.Pages.Clear()
         processingEngine.Pages.AddRange(form.ProcessingPages)

         _pbProgress.Step = 1
         _pbProgress.Minimum = 0
         _pbProgress.Value = 0
         _pbProgress.Maximum = GetTotalFieldCount(form)
         AddHandler processingEngine.ProcessField, AddressOf processingEngine_ProcessField

         Application.DoEvents()
         Dim stopWatch As Stopwatch = New Stopwatch()
         stopWatch.Start()
         processingEngine.Process(form.Image, form.Alignment)
         stopWatch.Stop()
         AddOperationTime(form.Name, "Process Form", stopWatch.Elapsed, False)
         Application.DoEvents()

         RemoveHandler processingEngine.ProcessField, AddressOf processingEngine_ProcessField
      End Sub

      'This function is used to cleanup images
      Private Sub CleanupImage(ByVal imageToClean As RasterImage, ByVal fileName As String, ByVal startIndex As Integer, ByVal count As Integer)
         Dim stopWatch As Stopwatch = New Stopwatch()
         Try
            stopWatch.Start()
            Dim oldPageNumber As Integer = imageToClean.Page
                'Deskew
                If _rb_Omr.Checked Then
                    Dim i As Integer = startIndex
                    Do While i < startIndex + count
                        imageToClean.Page = i
                        Dim deskew As DeskewCommand = New DeskewCommand()

                        deskew.Flags = DeskewCommandFlags.DeskewImage Or DeskewCommandFlags.DoNotFillExposedArea
                        deskew.Run(imageToClean)
                        i += 1
                    Loop
                ElseIf Not cleanUpOcrEngine Is Nothing AndAlso cleanUpOcrEngine.IsStarted Then

                    Dim document As IOcrDocument = cleanUpOcrEngine.DocumentManager.CreateDocument()
                    Try
                        Dim i As Integer = startIndex
                        Do While i < startIndex + count
                            imageToClean.Page = i
                            document.Pages.AddPage(imageToClean, Nothing)
                            Dim angle As Integer = -document.Pages(0).GetDeskewAngle()
                            Dim cmd As RotateCommand = New RotateCommand(angle * 10, RotateCommandFlags.Bicubic, RasterColor.FromKnownColor(RasterKnownColor.White))
                            cmd.Run(imageToClean)
                            document.Pages.Clear()
                            i += 1
                        Loop
                    Finally
                        CType(document, IDisposable).Dispose()
                    End Try

                Else
                    Dim i As Integer = startIndex
                    Do While i < startIndex + count
                        imageToClean.Page = i

                        Dim deskewCommand As DeskewCommand = New DeskewCommand()
                        If imageToClean.Height > 3500 Then
                            deskewCommand.Flags = DeskewCommandFlags.DocumentAndPictures Or DeskewCommandFlags.DoNotPerformPreProcessing Or DeskewCommandFlags.UseNormalDetection Or DeskewCommandFlags.DoNotFillExposedArea
                        Else
                            deskewCommand.Flags = DeskewCommandFlags.DeskewImage Or DeskewCommandFlags.DoNotFillExposedArea
                        End If
                        deskewCommand.Run(imageToClean)
                        i += 1
                    Loop
                End If
            stopWatch.Stop()
            If String.IsNullOrEmpty(fileName) Then
               AddOperationTime("NA", "Clean Image", stopWatch.Elapsed, False)
            Else
               AddOperationTime(fileName, "Clean Image", stopWatch.Elapsed, False)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            stopWatch.Stop()
         End Try
      End Sub

      Public Function RunFormRecognitionAndProcessingScanner(ByVal filledForm As FilledForm) As Boolean
         'Scan the first page
         LoadImageScanner(1)

         If (Not scannedImage Is Nothing AndAlso scannedImage.PageCount < 1) OrElse scannedImage Is Nothing Then
            Throw New Exception("No forms were scanned.")
         End If

         filledForm.Name = "Scanned Form"
         filledForm.Image = scannedImage.Clone()
         filledForm.Image.ChangeViewPerspective(RasterViewPerspective.TopLeft)

         _lblFormName.Text = String.Concat("Form Name: ", filledForm.Name)
         'In this demo, we only use the first page when recognizing scanned forms
         Dim oldRecognizeFirstPage As Boolean = _menuItemRecognizeFirstPageOnly.Checked
         _menuItemRecognizeFirstPageOnly.Checked = True
         Application.DoEvents()
         Dim bRecognized As Boolean = False

         bRecognized = RecognizeFormComplex(filledForm)

         If (Not canceled) AndAlso bRecognized Then
            'We need to make sure we scanned all the pages for this form. 
            'We check the master to see how many pages this form needs and scan
            'until we have all pages. 
            If filledForm.Master.Properties.Pages - scannedImage.PageCount > 0 Then
               LoadImageScanner(filledForm.Master.Properties.Pages - scannedImage.PageCount)
            End If

            'Add the rest of the already scanned pages to the filled form image collection
            If scannedImage.PageCount > filledForm.Image.PageCount Then
               filledForm.Image.AddPages(scannedImage, filledForm.Image.PageCount + 1, -1)
            End If

            'Only calculate the alignment if the form has multiple pages and only
            'the first page was loaded and used for recognition. In that case, the alignment has
            'only been calculated for the first page but we need it calculated for all pages
            AlignForm(filledForm, _menuItemRecognizeFirstPageOnly.Checked AndAlso (filledForm.Master.Properties.Pages > 1) AndAlso (Not filledForm.Master.IsExtendable))
            ProcessForm(filledForm)

            'We have successfully recognized and processed a form
            Return True
         End If
         Return False
      End Function

      Public Function RunFormRecognitionAndProcessing(ByVal form As FilledForm) As Boolean
         form.Image.ChangeViewPerspective(RasterViewPerspective.TopLeft)
            CleanupImage(form.Image, form.Name, 1, form.Image.PageCount)
         Dim bRecognizedSimple As Boolean = False
         Dim bRecognizedComplex As Boolean = False

         bRecognizedSimple = RecognizeFormSimple(form)
         If (Not bRecognizedSimple) Then
            bRecognizedComplex = RecognizeFormComplex(form)
         End If

         If (Not canceled) AndAlso (bRecognizedSimple Or bRecognizedComplex) Then
            'We need to make sure we loaded all the pages for this form. 
            'We check the master to see how many pages this form needs and load
            'the rest of the pages. 

            'Only calculate the alignment if the form has multiple pages and only
            'the first page was loaded and used for recognition. In that case, the alignment has
            'only been calculated for the first page but we need it calculated for all pages
            If _menuItemRecognizeFirstPageOnly.Checked AndAlso form.Master.Properties.Pages > 1 AndAlso (Not bRecognizedSimple) AndAlso (Not form.Master.IsExtendable) Then
               If form.Master.Properties.Pages - form.Image.PageCount > 0 Then
                  Dim neededPages As RasterImage = LoadImageFile(form.FileName, form.Image.PageCount + 1, form.Master.Properties.Pages)
                  CleanupImage(neededPages, form.Name, 1, neededPages.PageCount)
                  form.Image.AddPages(neededPages, 1, -1)
               End If
               AlignForm(form, True)
            Else
               AlignForm(form, False)
            End If

            ProcessForm(form)
            'We have successfully recognized and processed a form
            Return True
         End If
         Return False
      End Function

      Public Function LoadMasterForm(ByVal attributesFileName As String, ByVal fieldsFileName As String) As MasterForm
         Dim tempProcessingEngine As FormProcessingEngine = New FormProcessingEngine()
         tempProcessingEngine.OcrEngine = ocrEngine
         tempProcessingEngine.BarcodeEngine = barcodeEngine

         Dim form As MasterForm = New MasterForm()

         If File.Exists(attributesFileName) Then
            Dim formData As Byte() = File.ReadAllBytes(attributesFileName)
            form.Attributes.SetData(formData)
            form.Properties = recognitionEngine.GetFormProperties(form.Attributes)
         End If

         If File.Exists(fieldsFileName) Then
            tempProcessingEngine.LoadFields(fieldsFileName)
            form.ProcessingPages = tempProcessingEngine.Pages
         End If

         Return form
      End Function

      Private Sub StartUpOcrEngine()
         Try
            Dim settings As My.Settings = New My.Settings()
            Dim engineType As String = settings.OcrEngineType

            ' Show the engine selection dialog
            
            Dim dlg As OcrEngineSelectDialog = New OcrEngineSelectDialog(Messager.Caption, engineType, False)
            Try
               If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                  ocrEngineType = dlg.SelectedOcrEngineType
                  ocrEngine = OcrEngineManager.CreateEngine(ocrEngineType, True)
                  ocrEngine.Startup(Nothing, Nothing, Nothing, Nothing)

                  cleanUpOcrEngine = OcrEngineManager.CreateEngine(ocrEngineType, True)
                  cleanUpOcrEngine.Startup(Nothing, Nothing, Nothing, Nothing)
                  Me.Text = String.Format("{0} [{1} Engine]", Me.Text, ocrEngineType.ToString())
                  If ocrEngineType = ocrEngineType.LEAD Then
                     _rb_OCR_ICR.Enabled = False
                     SetEngineSettings(ocrEngine)
                  Else
                     _rb_OCR_ICR.Enabled = True
                  End If
               Else
                  Throw New Exception("No engine selected.")
               End If
            Finally
               CType(dlg, IDisposable).Dispose()
            End Try

         Catch exp As Exception
            Messager.ShowError(Me, exp)
            Throw
         End Try
      End Sub

      Private Sub SetEngineSettings(ByVal engine As IOcrEngine)
         Try
            engine.SettingManager.SetEnumValue("Recognition.Fonts.DetectFontStyles", 0)
            engine.SettingManager.SetBooleanValue("Recognition.Fonts.RecognizeFontAttributes", False)
            If engine.SettingManager.IsSettingNameSupported("Recognition.Zoning.EnableDoubleZoning") Then
               engine.SettingManager.SetBooleanValue("Recognition.Zoning.EnableDoubleZoning", False)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try

      End Sub

      Private Sub StartUpBarcodeEngine()
         Try
            barcodeEngine = New BarcodeEngine()
         Catch exp As Exception
            Messager.ShowError(Me, exp)
            Throw
         End Try
      End Sub

      Private Sub SetupProcessingEngine()
         processingEngine.OcrEngine = ocrEngine
         If Not barcodeEngine Is Nothing Then
            processingEngine.BarcodeEngine = barcodeEngine
         End If
      End Sub

      Public Sub SetupRecognitionEngine()
         Try
            'Add appropriate object managers to recognition engine
            recognitionEngine.ObjectsManagers.Clear()
            If _menuItemDefaultManager.Checked Then
               Dim defaultObjectManager As DefaultObjectsManager = New DefaultObjectsManager()
               recognitionEngine.ObjectsManagers.Add(defaultObjectManager)
            End If

            If _menuItemOCRManager.Checked AndAlso ocrEngine.IsStarted Then
               Dim ocrObjectManager As OcrObjectsManager = New OcrObjectsManager(ocrEngine)
               recognitionEngine.ObjectsManagers.Add(ocrObjectManager)
            End If

            If _menuItemBarcodeManager.Checked AndAlso Not barcodeEngine Is Nothing Then
               Dim barcodeObjectManager As BarcodeObjectsManager = New BarcodeObjectsManager(barcodeEngine)
               recognitionEngine.ObjectsManagers.Add(barcodeObjectManager)
            End If
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
         UpdateControls()
      End Sub

      Private Function StartUpEngines() As Boolean
         Try
            recognitionEngine = New FormRecognitionEngine()
            processingEngine = New FormProcessingEngine()
            StartUpRasterCodecs()
            StartUpOcrEngine()
            StartUpBarcodeEngine()
            StartupTwain()
            Return True
         Catch
            Return False
         End Try
      End Function

      Private Sub StartUpRasterCodecs()
            Try
                rasterCodecs = New RasterCodecs()

                'To turn off the dithering method when converting colored images to 1-bit black and white image during the load
                'so the text in the image is not damaged.
                RasterDefaults.DitheringMethod = RasterDitheringMethod.None

                'To ensure better results from OCR engine, set the loading resolution to 300 DPI 
                rasterCodecs.Options.Load.Resolution = 300
                rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300
            Catch exp As Exception
                Messager.ShowError(Me, exp)
                Throw
            End Try
        End Sub

      Private Sub StartupTwain()
         Try
            twainSession = New TwainSession()

            If TwainSession.IsAvailable(Me.Handle) Then
               twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
               AddHandler twainSession.AcquirePage, AddressOf twnSession_AcquirePage
            End If

         Catch ex As TwainException
            If ex.Code = TwainExceptionCode.InvalidDll Then
               twainSession = Nothing
               Messager.ShowError(Me, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org")
            Else
               twainSession = Nothing
               Messager.ShowError(Me, ex)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            twainSession = Nothing
         End Try
      End Sub

      Private Sub _menuItemHowto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemHowto.Click
         Try
            DemosGlobal.LaunchHowTo("FormsRecognitionDemo.html")
         Catch ex As Exception
            Messager.ShowError(Me, ex.Message)
         End Try
      End Sub

      Private Sub _menuItemAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemAbout.Click
         Using aboutDialog As New AboutDialog("Low Level Forms", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _menuItemExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemExit.Click
         Me.Close()
      End Sub

      Private Sub _btnBrowseMasterFormRespository_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBrowseMasterFormRespository.Click
         Try
            
            Dim fbd As FolderBrowserDialogEx = New FolderBrowserDialogEx()
            Try
               fbd.Description = "Select Master Form Repository"
               fbd.SelectedPath = GetFormsDir()
               fbd.ShowNewFolderButton = False
               fbd.ShowEditBox = True
               fbd.ShowFullPathInEditBox = True
               If fbd.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                  _txtMasterFormRespository.Text = fbd.SelectedPath
                  currentMasterCount = GetMasterFormCount()
               End If
            Finally
               CType(fbd, IDisposable).Dispose()
            End Try

         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
         UpdateControls()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         canceled = True
      End Sub

      Private Sub _menuItemLaunchMasterFormsEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemLaunchMasterFormsEditor.Click
         Dim startInfo As ProcessStartInfo = New ProcessStartInfo()
         startInfo.FileName = Path.Combine(Application.StartupPath, "CSMasterFormsEditor_Original.exe")
         startInfo.FileName = startInfo.FileName.Replace("\DotNet4\", "\Dotnet\") 'since the LEADTOOLS Installation has the XXX_Original exes for Dotnet
         startInfo.Arguments = String.Format("""{0}""", ocrEngine.EngineType.ToString())

         Try

            Dim process As Process = New Process()
            Try
               process.StartInfo = startInfo
               process.Start()
               process.Close()
            Finally
               CType(process, IDisposable).Dispose()
            End Try

         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

        Private Sub _rb_Respository_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _rb_OCR_ICR.CheckedChanged, _rb_OCR.CheckedChanged, _rb_DL.CheckedChanged, _rb_Invoice.CheckedChanged, _rb_Omr.CheckedChanged
            _txtMasterFormRespository.Text = GetFormsDir()
            currentMasterCount = GetMasterFormCount()
            UpdateControls()
      End Sub

      Private Sub ManagerChange_Click(sender As Object, e As EventArgs) Handles _menuItemOCRManager.Click, _menuItemBarcodeManager.Click, _menuItemDefaultManager.Click
         SetupRecognitionEngine()
      End Sub

   End Class
End Namespace
