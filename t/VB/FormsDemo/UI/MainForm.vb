' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Diagnostics
Imports Microsoft.Win32

Imports Leadtools
Imports Leadtools.ImageProcessing
Imports Leadtools.WinForms
Imports Leadtools.WinForms.CommonDialogs.File
Imports Leadtools.Codecs
Imports Leadtools.Forms.Common
Imports Leadtools.Forms.Processing
Imports Leadtools.Forms.Recognition
Imports Leadtools.Ocr
Imports Leadtools.Forms.Recognition.Barcode
Imports Leadtools.Forms.Recognition.Ocr
#If FOR_DOTNET4 Then
Imports Leadtools.Forms.Recognition.Search
#End If
Imports Leadtools.Forms.Auto
Imports Leadtools.Twain
Imports Leadtools.Barcode
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.Demos.Dialogs

Namespace FormsDemo
   Partial Public Class MainForm : Inherits Form
      'These enums will work with Passed Args to application.
      Private Enum DemoDefaultModes
            [Default] = 0 'Default Ocr
         DL = 1 'Driving License
            Invoice = 2 'Invoice
            Omr = 3 'OMR
      End Enum

      Private ocrEngines As List(Of IOcrEngine)
      Private cleanUpOcrEngine As IOcrEngine
      Private barcodeEngine As BarcodeEngine
      Private rasterCodecs As RasterCodecs
      Private scannedImage As RasterImage
      Private canceled As Boolean = False
      Private ocrEngineType As OcrEngineType
      Private workingRepository As DiskMasterFormsRepository
      Private autoEngine As AutoFormsEngine
      Private recognitionTimer As Stopwatch = New Stopwatch()
      Private isScanning As Boolean = False
      Private twainSession As TwainSession = Nothing
      Private recognitionInProcess As Boolean = False
      Private _lastFolder As String
      Private currentMasterCount As Integer = 0
      Private demoMode_Renamed As DemoDefaultModes = DemoDefaultModes.Default
      Private scannerMessage As String = String.Format("Although scanning can be implemented in multiple ways within a Forms Recognition and processing application, this demo uses the below implementation:{0}{0}" & "1) The scanner must have a feeder{0}" & "2) Any number of filled forms can be loaded into the scanner in any order. Pages within each filled form must be in order however.{0}" & "3) Only the first page will be used for recognition. Once the first page of a form is scanned, recognized, and processed, the rest of the pages for that form (if multipage) will be scanned and processed as needed. This process is repeated for all forms.{0}" & "4) We will attempt to set your scanner to scan in B/W at 300DPI. If your scanner does not support this configuration, an error message will appear and the scanner dialog will be shown so that you can configure the scanner's settings.", Environment.NewLine)

      Public Sub New()
         InitializeComponent()
      End Sub

      <STAThread()> _
      Shared Sub Main(ByVal args As String())
         
         If Not Support.SetLicense() Then
            Return
         End If

         Dim bLocked As Boolean = RasterSupport.IsLocked(RasterSupportType.Forms)
         If bLocked Then
            MessageBox.Show("Forms support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         End If

         Dim bOCRLocked As Boolean = (RasterSupport.IsLocked(RasterSupportType.OcrLEAD)) Or (RasterSupport.IsLocked(RasterSupportType.OcrOmniPage))
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

      Private ReadOnly Property DemoMode() As DemoDefaultModes
         Get
            Return demoMode_Renamed
         End Get
      End Property

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         If (Not DesignMode) Then
            BeginInvoke(New MethodInvoker(AddressOf Startup))
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Sub Startup()
         Try
            'Check if repository directory was passed in. The master forms editor demo has the ability to launch this demo
            'and it will pass it's repository directory. It will also pass the ocr engine it was using so we can default to it.
            'First argument is the ocr engine. The next is the repository path.
            Dim commandArgs As String() = Environment.GetCommandLineArgs()
            If commandArgs.Length >= 2 Then
                    If commandArgs(1) = "DrivingLicense" OrElse commandArgs(1) = "Invoice" OrElse commandArgs(1) = "Omr" Then
                        If commandArgs(1) = "DrivingLicense" Then
                            demoMode_Renamed = DemoDefaultModes.DL
                        ElseIf commandArgs(1) = "Invoice" Then
                            demoMode_Renamed = DemoDefaultModes.Invoice
                        ElseIf commandArgs(1) = "Omr" Then
                            demoMode_Renamed = DemoDefaultModes.Omr
                        End If
                    Else
                  Dim settings As Settings = New Settings()
                  settings.OcrEngineType = commandArgs(1)
                        settings.Save()

                        If commandArgs.Length = 3 AndAlso Directory.Exists(commandArgs(2)) Then
                            _txtMasterFormRespository.Text = commandArgs(2)
                        End If
                    End If

               ' Application can have the following args:
               ' 1- DrivingLicense
               ' 2- Invoice
               '
               ' If you pass one of these args Demo will Start
               ' Demo will Load default Masters for selected mode
               ' And will open sample image related to this mode.
            ElseIf commandArgs.Length = 1 Then
               If commandArgs(0) = "DrivingLicense" Then
                  demoMode_Renamed = DemoDefaultModes.DL
               ElseIf commandArgs(0) = "Invoice" Then
                        demoMode_Renamed = DemoDefaultModes.Invoice
                    ElseIf commandArgs(0) = "Omr" Then
                        demoMode_Renamed = DemoDefaultModes.Omr
                    End If
            End If

            InitDemoWithMode()
            If (Not StartUpEngines()) Then
               Messager.ShowError(Me, "One or more required engines did not start. The application will now close.")
               Me.Close()
               Return
            End If

            If String.IsNullOrEmpty(_txtMasterFormRespository.Text) Then
               _txtMasterFormRespository.Text = GetFormsDir()
            End If

            CreateRepository()
            SetupAutoFormsEngine()

            If Me.DemoMode = DemoDefaultModes.Default Then
               Messager.Caption = "LEADTOOLS Forms Demo"
            ElseIf Me.DemoMode = DemoDefaultModes.DL Then
                    Messager.Caption = "LEADTOOLS Driving License Demo"
                    _rb_DL.Checked = True
               ProcessImageFormPath(DemosGlobal.ImagesFolder & "\" & "Forms\Forms to be Recognized\Driving License\License.png")
            ElseIf Me.DemoMode = DemoDefaultModes.Invoice Then
               Messager.Caption = "LEADTOOLS Invoice Demo"
                    ProcessImageFormPath(DemosGlobal.ImagesFolder & "\" & "Forms\Forms to be Recognized\Invoice\Invoice.tif")
                ElseIf Me.DemoMode = DemoDefaultModes.Omr Then
                    Messager.Caption = "LEADTOOLS Omr Demo"
                    _rb_OMR.Checked = True
                    ProcessImageFormPath(DemosGlobal.ImagesFolder & "\" & "Forms\Forms to be Recognized\OMR\AnswerSheet1.jpg")
                End If
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try

         UpdateControls()
      End Sub

      Private Sub InitDemoWithMode()
         If Me.DemoMode <> DemoDefaultModes.Default Then
            _btnBrowseMasterFormRespository.Enabled = False
            _rb_OCR.Enabled = False
            _rb_OCR_ICR.Enabled = False
            _rb_DL.Enabled = False
            _rb_Invoice.Enabled = False
            _rb_OMR.Enabled = False

            _rb_OCR.Visible = False
            _rb_OCR_ICR.Visible = False
            _rb_DL.Visible = False
            _rb_Invoice.Visible = False
            _rb_OMR.Visible = False
         End If
         If Me.DemoMode = DemoDefaultModes.DL Then
            Me.Text = "Driver License Reader"
         ElseIf Me.DemoMode = DemoDefaultModes.Invoice Then
                Me.Text = "Invoice Processing"
            ElseIf Me.DemoMode = DemoDefaultModes.Omr Then
                Me.Text = "Omr Processing"
            End If
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
         If Me.DemoMode = DemoDefaultModes.Default Then
            _btnBrowseMasterFormRespository.Enabled = Not recognitionInProcess
         End If

         _btnCancel.Enabled = recognitionInProcess

         If (Not recognitionInProcess) Then
            _lblFormName.Text = "Form Name: NA"
            _pbProgress.Value = 0
         End If
      End Sub

      Private Function GetMasterFormCount(ByVal rootCategory As IMasterFormsCategory) As Integer
         Try
            Dim count As Integer = rootCategory.MasterFormsCount
            For Each childCategory As IMasterFormsCategory In rootCategory.ChildCategories
               count = count + GetMasterFormCount(childCategory)
            Next childCategory
            Return count
         Catch
            Return 0
         End Try
      End Function

        Private Function GetFormsDir() As String
            Dim formsDir As String = ""
            If Me.DemoMode = DemoDefaultModes.Default Then
                If _rb_OCR.Checked = True Then
                    formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\MasterForm Sets\OCR"
                ElseIf _rb_OCR_ICR.Checked = True Then
                    formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\MasterForm Sets\OCR_ICR"
                ElseIf _rb_DL.Checked = True Then
                    formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\MasterForm Sets\Driving License"
                ElseIf _rb_Invoice.Checked = True Then
                    formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\MasterForm Sets\Invoice"
                Else
                    formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\MasterForm Sets\OMR"
                End If
            ElseIf Me.DemoMode = DemoDefaultModes.DL Then
                formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\MasterForm Sets\Driving License"
            ElseIf Me.DemoMode = DemoDefaultModes.Invoice Then
                formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\MasterForm Sets\Invoice"
            ElseIf Me.DemoMode = DemoDefaultModes.Omr Then
                formsDir = DemosGlobal.ImagesFolder & "\" & "Forms\MasterForm Sets\OMR"
            End If
            Return formsDir
        End Function

      Private Sub _menuItemRecognizeMultipleForms_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemRecognizeMultipleForms.Click

         Try
            recognitionInProcess = True
            UpdateControls()

            Using fbd As New FolderBrowserDialogEx()
               If [String].IsNullOrEmpty(_lastFolder) Then
                  fbd.SelectedPath = GetSamplesPath()
               Else
                  fbd.SelectedPath = _lastFolder
               End If

               fbd.ShowNewFolderButton = False
               fbd.ShowFullPathInEditBox = True
               fbd.ShowEditBox = True
               If fbd.ShowDialog(Me) = DialogResult.OK Then
                  canceled = False
                  _lastFolder = fbd.SelectedPath
                  Dim files As String() = Directory.GetFiles(fbd.SelectedPath)
                  AddOperationTime(Nothing, Nothing, TimeSpan.Zero, True)
                  Dim recognizedForms As New List(Of FilledForm)()
                  For Each file As String In files
                     'recognize and process each file in the directory
                     Application.DoEvents()
                     If Not canceled Then
                        Try
                           Dim newForm As New FilledForm()
                           newForm.FileName = file
                           'if(Path.GetExtension(file).Equals("db"))
                           '    continue;
                           newForm.Name = Path.GetFileNameWithoutExtension(file)
                           _lblFormName.Text = [String].Concat("Form Name: ", newForm.Name)
                           _lblStatus.Text = "Status: NA"
                           'Load the image
                           newForm.Image = LoadImageFile(file, 1, -1)
                           'Run the recognition and processing
                           If RunFormRecognitionAndProcessing(newForm) Then
                              recognizedForms.Add(newForm)
                           End If
                           'Do nothing since we are processing a directory of images
                           'and do not want to stop execution
                        Catch
                        End Try
                     End If
                  Next

                  ShowResults(recognizedForms)
               End If
            End Using
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

            AddOperationTime(Nothing, Nothing, TimeSpan.Zero, True)
            If loader.Load(Me, rasterCodecs, False) > 0 Then
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

      Private Sub ProcessImageFormPath(ByVal imagePath As String)
         Try
            recognitionInProcess = True
            UpdateControls()

            Dim newForm As FilledForm = New FilledForm()
            newForm.FileName = Path.GetFileName(imagePath)
            newForm.Name = Path.GetFileNameWithoutExtension(imagePath)
            _lblFormName.Text = String.Concat("Form Name: ", newForm.Name)
            _lblStatus.Text = "Status: NA"
            'Load the image
            newForm.Image = LoadImageFile(imagePath, 1, 1)
            'Run the recognition and processing
            Dim recognizedForms As List(Of FilledForm) = New List(Of FilledForm)()
            If RunFormRecognitionAndProcessing(newForm) Then
               recognizedForms.Add(newForm)
            End If

            ShowResults(recognizedForms)
         Catch exp As Exception
            Messager.ShowError(Me, exp)
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

        Private Function GetPageType() As FormsPageType
            Dim pageType As FormsPageType = FormsPageType.Normal
            If _rb_DL.Checked = True Then
                pageType = FormsPageType.IDCard
            ElseIf _rb_OMR.Checked = True Then
                pageType = FormsPageType.Omr
            End If
            Return pageType
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

      Private Sub _menuItemRecognizeScannedForms_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemRecognizeScannedForms.Click
         Try
            recognitionInProcess = True
            isScanning = True
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
            isScanning = False
            UpdateControls()
         End Try
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
         If Not autoEngine Is Nothing Then
            autoEngine.Dispose()
         End If

         Dim settings As Settings = New Settings()
         settings.OcrEngineType = ocrEngineType.ToString()
         settings.Save()

         Dim i As Integer = 0
         Do While i < ocrEngines.Count
            If Not ocrEngines(i) Is Nothing AndAlso ocrEngines(i).IsStarted Then
               ocrEngines(i).Shutdown()
               ocrEngines(i).Dispose()
            End If
            i += 1
         Loop
         If Not cleanUpOcrEngine Is Nothing AndAlso cleanUpOcrEngine.IsStarted Then
            cleanUpOcrEngine.Shutdown()
            cleanUpOcrEngine.Dispose()
         End If
         If Not twainSession Is Nothing Then
            twainSession.Shutdown()
         End If
      End Sub

      Private Sub _btnHowTo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemHowto.Click
         Try
            DemosGlobal.LaunchHowTo("FormsRecognitionDemo.html")
         Catch ex As Exception
            Messager.ShowError(Me, ex.Message)
         End Try
      End Sub

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

      Public Function LoadImageFile(ByVal fileName As String, ByVal firstPage As Integer, ByVal lastPage As Integer) As RasterImage
         ' Load the image 
         Dim stopWatch As Stopwatch = New Stopwatch()
         stopWatch.Start()
         Dim image As RasterImage = rasterCodecs.Load(fileName, 0, CodecsLoadByteOrder.Bgr, firstPage, lastPage)
         stopWatch.Stop()
         AddOperationTime(Path.GetFileNameWithoutExtension(fileName), "Load Image", stopWatch.Elapsed, False)
         Return image
      End Function

#If FOR_DOTNET4 Then
      Private Function CreateFullTextSearchManager(path__1 As String) As IFullTextSearchManager
         Dim fullTextSearchManager As New DiskFullTextSearchManager()
         fullTextSearchManager.IndexDirectory = Path.Combine(path__1, "index")
         Return fullTextSearchManager
      End Function
#End If

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
         Application.DoEvents()
         autoEngine.RecognizeFirstPageOnly = True
         recognitionTimer.Reset()
         recognitionTimer.Start()
         Dim result As AutoFormsRunResult = autoEngine.Run(filledForm.Image, AddressOf MyPageRequestCallback, filledForm, Nothing)
         Application.DoEvents()
         recognitionTimer.Stop()
         AddOperationTime(filledForm.Name, "Recognize and Process", recognitionTimer.Elapsed, False)
         If Not result Is Nothing AndAlso (Not canceled) Then
            'We need to make sure we scanned all the pages for this form. 
            'We check the master to see how many pages this form needs and scan
            'until we have all pages. 
            If result.RecognitionResult.Properties.Pages - scannedImage.PageCount > 0 Then
               LoadImageScanner(result.RecognitionResult.Properties.Pages - scannedImage.PageCount)
               'Add the rest of the already scanned pages to the filled form image collection
               filledForm.Image.AddPages(scannedImage, filledForm.Image.PageCount + 1, -1)
            End If

            Dim master As MasterForm = New MasterForm()
            master.Properties = result.RecognitionResult.Properties
            filledForm.Master = master
            filledForm.Result = result.RecognitionResult.Result
            filledForm.Alignment = result.RecognitionResult.Alignments

            If Not result.FormFields Is Nothing Then
               filledForm.ProcessingPages = result.FormFields
            End If

            'We have successfully recognized and processed a form
            Return True
         End If
         Return False
      End Function

      'In some cases, only a single page is provided to the engine for recognition,
      'but the form is multiple pages so more pages are needed for processing. 
      'This callback is called to notify you that it needs more pages for processing
      'The required page is passed here.
      Public Sub MyPageRequestCallback(ByVal data As PageRequestCallbackData)
         'Stop the timer. We do not want to skew attribute generation,recognition,
         'or processing times with work done in this event (image loading, scanning, etc). 
         'Those times are recorded separately
         recognitionTimer.Stop()

         Dim workingForm As FilledForm = CType(IIf(TypeOf data.UserData Is FilledForm, data.UserData, Nothing), FilledForm)

         If isScanning Then
            'if it is asking for a page we do not have yet, scan until we have that page
            If scannedImage.PageCount < data.FormPageNumber Then
               LoadImageScanner(data.FormPageNumber - scannedImage.PageCount)
            End If

            'Give the new page to the engine for processing
            scannedImage.Page = data.FormPageNumber
            data.Page = scannedImage.Clone()
            workingForm.Image.AddPages(scannedImage.CloneAll(), workingForm.Image.PageCount + 1, -1)
         Else
            'Load all pages up to the page we need
            Dim image As RasterImage = LoadImageFile(workingForm.FileName, workingForm.Image.PageCount + 1, data.FormPageNumber).CloneAll()
            CleanupImage(image, workingForm.Name, 1, image.PageCount)
            image.Page = image.PageCount 'Set current page to last page (data.FormPageNumber)
            data.Page = image.Clone()
            workingForm.Image.AddPages(image, 1, -1)
         End If

         'Resume timer
         recognitionTimer.Start()
         Application.DoEvents()
      End Sub

      'This callback is fired during the recognition and processing process.
      'It provides progress information, as well as the specific operation being performed
      Private Sub autoEngine_Progress(sender As Object, e As AutoFormsProgressEventArgs)
         Application.DoEvents()
         If canceled Then
            e.Cancel = True
         Else

            Select Case e.Operation
               Case AutoFormsOperation.Generating
                  If Me.InvokeRequired Then
                     Me.BeginInvoke(New MethodInvoker(Sub() _lblStatus.Text = "Status: Generating Form Attributes..."))
                  Else
                     _lblStatus.Text = "Status: Generating Form Attributes..."
                  End If
                  Exit Select
               Case AutoFormsOperation.Recognizing
                  If Me.InvokeRequired Then
                     Me.BeginInvoke(New MethodInvoker(Sub() _lblStatus.Text = "Status: Recognizing Form..."))
                  Else
                     _lblStatus.Text = "Status: Recognizing Form..."
                  End If
                  Exit Select
               Case AutoFormsOperation.Processing
                  If Me.InvokeRequired Then
                     Me.BeginInvoke(New MethodInvoker(Sub() _lblStatus.Text = "Status: Processing Form..."))
                  Else
                     _lblStatus.Text = "Status: Processing Form..."
                  End If
                  Exit Select
               Case Else
                  Exit Select
            End Select

            If Me.InvokeRequired Then
               Me.BeginInvoke(New MethodInvoker(Sub() _pbProgress.Value = Math.Min(100, e.Percentage)))
            Else
               _pbProgress.Value = Math.Min(100, e.Percentage)
            End If
         End If

         Application.DoEvents()
      End Sub

      'Used to display the amount of time a specific operation may take
      'private delegate void AddOperationTimeDelagate(string imageFile, string operationName, TimeSpan operationTime, bool clearExisting);
      Private Sub AddOperationTime(ByVal imageFile As String, ByVal operationName As String, ByVal operationTime As TimeSpan, ByVal clearExisting As Boolean)
         If clearExisting Then
            _lvLastOperation.Items.Clear()
         End If

         If (Not String.IsNullOrEmpty(imageFile)) Then
            _lvLastOperation.Items.Add(imageFile)
            _lvLastOperation.Items(_lvLastOperation.Items.Count - 1).SubItems.Add(operationName)
            _lvLastOperation.Items(_lvLastOperation.Items.Count - 1).SubItems.Add(Convert.ToString(Math.Round(operationTime.TotalSeconds, 2)))
         End If

         'ensure last item is visible
         If _lvLastOperation.Items.Count > 0 Then
            _lvLastOperation.EnsureVisible(_lvLastOperation.Items.Count - 1)
            _lvLastOperation.Refresh()
         End If

         Application.DoEvents()
      End Sub

      'This function is used to cleanup images
      Private Sub CleanupImage(ByVal imageToClean As RasterImage, ByVal fileName As String, ByVal startIndex As Integer, ByVal count As Integer)
         Dim stopWatch As Stopwatch = New Stopwatch()
         Try
            stopWatch.Start()
            Dim oldPageNumber As Integer = imageToClean.Page
                'Deskew
                If _rb_OMR.Checked Then
                    Dim i As Integer = startIndex
                    Do While i < startIndex + count
                        imageToClean.Page = i
                        Dim deskew As DeskewCommand = New DeskewCommand()

                        deskew.Flags = DeskewCommandFlags.DeskewImage Or DeskewCommandFlags.DoNotFillExposedArea Or DeskewCommandFlags.RotateResample
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

      Public Function RunFormRecognitionAndProcessing(ByVal form As FilledForm) As Boolean
         form.Image.ChangeViewPerspective(RasterViewPerspective.TopLeft)
         CleanupImage(form.Image, form.Name, 1, form.Image.PageCount)
         Application.DoEvents()
         autoEngine.RecognizeFirstPageOnly = _menuItemRecognizeFirstPageOnly.Checked
         recognitionTimer.Reset()
         recognitionTimer.Start()
         Dim result As AutoFormsRunResult = autoEngine.Run(form.Image, AddressOf MyPageRequestCallback, form, Nothing)
         Application.DoEvents()
         recognitionTimer.Stop()
         AddOperationTime(form.Name, "Recognize and Process", recognitionTimer.Elapsed, False)
         If Not result Is Nothing AndAlso (Not canceled) Then
            'We need to make sure we loaded all the pages for this form. 
            'We check the master to see how many pages this form needs and load
            'the rest of the pages. 
            If result.RecognitionResult.Properties.Pages - form.Image.PageCount > 0 Then
               Dim remainingPages As RasterImage = LoadImageFile(form.FileName, form.Image.PageCount + 1, result.RecognitionResult.Properties.Pages)
               CleanupImage(remainingPages, form.Name, 1, remainingPages.PageCount)
               form.Image.AddPages(remainingPages, 1, -1)
            End If

            form.Alignment = result.RecognitionResult.Alignments
            Dim master As MasterForm = New MasterForm()
            master.Properties = result.RecognitionResult.Properties
            form.Master = master
            form.Result = result.RecognitionResult.Result

            If Not result.FormFields Is Nothing Then
               form.ProcessingPages = result.FormFields
            End If

            'We have successfully recognized and processed a form
            Return True
         End If
         Return False
      End Function

      Private Sub StartUpOcrEngine()
         Try
            Dim settings As Settings = New Settings()
            Dim engineType As String = settings.OcrEngineType
            ocrEngines = New List(Of IOcrEngine)()

            ' Show the engine selection dialog
            Dim dlg As OcrEngineSelectDialog = New OcrEngineSelectDialog(Messager.Caption, engineType, False)
            Try
               If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                  ocrEngineType = dlg.SelectedOcrEngineType

                  If ocrEngineType = ocrEngineType.LEAD Then
                     'For Advantage Engine we need only one Engine to be used with ThreadPool
                     Dim engine As IOcrEngine = OcrEngineManager.CreateEngine(ocrEngineType, False)

                     ocrEngines.Add(engine)
                     ocrEngines(0).Startup(Nothing, Nothing, Nothing, Nothing)
                     SetEngineSettings(engine)
                  Else
                     Dim engine As IOcrEngine = OcrEngineManager.CreateEngine(ocrEngineType, False)

                     ocrEngines.Add(engine)
                     ocrEngines(0).Startup(Nothing, Nothing, Nothing, Nothing)
                  End If

                  cleanUpOcrEngine = OcrEngineManager.CreateEngine(ocrEngineType, False)

                  cleanUpOcrEngine.Startup(Nothing, Nothing, Nothing, Nothing)

                  Me.Text = String.Format("{0} [{1} Engine]", Me.Text, ocrEngineType.ToString())
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

            If engine.SettingManager.IsSettingNameSupported("Recognition.RecognitionModuleTradeoff") Then
               engine.SettingManager.SetEnumValue("Recognition.RecognitionModuleTradeoff", "Accurate")
            End If



            'If engine.SettingManager.IsSettingNameSupported("Recognition.Zoning.EnableDoubleZoning") Then
            'engine.SettingManager.SetBooleanValue("Recognition.Zoning.EnableDoubleZoning", False)
            'End If
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

      Private Sub SetupAutoFormsEngine()
         Try
            If Not autoEngine Is Nothing Then
               autoEngine.Dispose()
            End If

            'Add appropriate object managers to AutoForms engine. We need to recreate it first
            Dim managers As AutoFormsRecognitionManager = AutoFormsRecognitionManager.None
            If _menuItemBarcodeManager.Checked Then
               managers = managers Or AutoFormsRecognitionManager.Barcode
            End If
            If _menuItemDefaultManager.Checked Then
               managers = managers Or AutoFormsRecognitionManager.Default
            End If
            If _menuItemOCRManager.Checked Then
               managers = managers Or AutoFormsRecognitionManager.Ocr
            End If

            If Not ocrEngines Is Nothing AndAlso ocrEngines.Count = 1 AndAlso ocrEngines(0).EngineType = OcrEngineType.LEAD Then
               autoEngine = New AutoFormsEngine(workingRepository, ocrEngines(0), barcodeEngine, managers, 30, 80, _menuItemRecognizeFirstPageOnly.Checked)
               autoEngine.UseThreadPool = True
            ElseIf Not ocrEngines Is Nothing Then
               autoEngine = New AutoFormsEngine(workingRepository, ocrEngines(0), barcodeEngine, managers, 30, 80, _menuItemRecognizeFirstPageOnly.Checked)
            Else
               Return
            End If

#If FOR_DOTNET4 Then
            If Directory.Exists(Path.Combine(workingRepository.Path, "index")) Then
               autoEngine.SetFullTextSearchManager(CreateFullTextSearchManager(workingRepository.Path), "index", Nothing)
            End If
#End If

            autoEngine.FilledFormType = GetPageType()

            AddHandler autoEngine.Progress, AddressOf autoEngine_Progress
            If Me.DemoMode = DemoDefaultModes.Default Then
               If ocrEngines Is Nothing OrElse ocrEngines.Count = 0 OrElse ocrEngines(0).EngineType = OcrEngineType.LEAD Then
                  _rb_OCR_ICR.Enabled = False
               Else
                  If ocrEngines(0).ZoneManager.IsZoneTypeSupported(OcrZoneType.Icr) Then
                     _rb_OCR_ICR.Enabled = True
                  Else
                     _rb_OCR_ICR.Enabled = False
                  End If
               End If
            End If
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
         UpdateControls()
      End Sub

      Private Sub CreateRepository()
         Dim path As String = ""
         If Me.DemoMode = DemoDefaultModes.Default Then
            path = _txtMasterFormRespository.Text
         Else
            path = GetFormsDir()
         End If

         workingRepository = New DiskMasterFormsRepository(rasterCodecs, path)
         currentMasterCount = GetMasterFormCount(workingRepository.RootCategory)
      End Sub

      Public Function StartUpEngines() As Boolean
         Try
            StartUpRasterCodecs()
            StartUpOcrEngine()
            StartUpBarcodeEngine()
            StartupTwain()
            Return True
         Catch
            Return False
         End Try
      End Function

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

      Private Sub _menuItemExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemExit.Click
         Me.Close()
      End Sub

      Private Sub _btnBrowseMasterFormRespository_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBrowseMasterFormRespository.Click
         Try
            Using fbd As New FolderBrowserDialogEx()
               fbd.Description = "Select Master Form Repository"
               fbd.SelectedPath = GetFormsDir()
               fbd.ShowEditBox = True
               fbd.ShowFullPathInEditBox = True
               fbd.ShowNewFolderButton = False
               If fbd.ShowDialog() = DialogResult.OK Then
                  _txtMasterFormRespository.Text = fbd.SelectedPath
                  CreateRepository()
                  SetupAutoFormsEngine()
               End If
            End Using
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Sub

      Private Sub RecognitionOptionsChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemOCRManager.Click, _menuItemBarcodeManager.Click, _menuItemDefaultManager.Click, _menuItemRecognizeFirstPageOnly.Click
         SetupAutoFormsEngine()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
         canceled = True
      End Sub

      Private Sub _menuItemAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemAbout.Click
         Using aboutDialog As New AboutDialog("Forms", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _menuItemLaunchMasterFormsEditor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemLaunchMasterFormsEditor.Click
         Dim startInfo As ProcessStartInfo = New ProcessStartInfo()
         startInfo.FileName = Path.Combine(Application.StartupPath, "VBMasterFormsEditor_Original.exe")
         startInfo.FileName = startInfo.FileName.Replace("\DotNet4\", "\Dotnet\") 'since the LEADTOOLS Installation has the XXX_Original exes for Dotnet

         ' Make sure either CSMasterFormsEditor_Original.exe Or CSMasterFormsEditor.exe exist before attempting to start it
         If Not File.Exists(startInfo.FileName) Then
            startInfo.FileName = startInfo.FileName.Replace("VBMasterFormsEditor_Original.exe", "VBMasterFormsEditor.exe")
            If Not File.Exists(startInfo.FileName) Then
               MessageBox.Show(String.Format("Cannot find: {0}{1}{1}Please build the VBMasterFormsEditor.exe from the MasterFormsEditor project.", startInfo.FileName, Environment.NewLine), "File Not Found")
               Return
            End If
         End If

         startInfo.Arguments = String.Format("""{0}""", ocrEngines(0).EngineType.ToString())

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

      Private Sub _menuItemLanguages_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemLanguages.Click
         ' Show the dialog to let the user change the current enabled languages
         
         Dim dlg As EnableLanguagesDialog = New EnableLanguagesDialog(ocrEngines(0))
         Try
            dlg.ShowDialog(Me)
         Finally
            CType(dlg, IDisposable).Dispose()
         End Try

         'Enable selected languages for all OCR engines
         Dim enabledLanguages As String() = ocrEngines(0).LanguageManager.GetEnabledLanguages()
         Dim i As Integer = 1
         Do While i < ocrEngines.Count
            ocrEngines(i).LanguageManager.EnableLanguages(enabledLanguages)
            i += 1
         Loop
      End Sub

      Private Sub _menuItemComponents_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemComponents.Click
         ' Show the dialog to let the user see the OCR components installed on this system
         
         Dim dlg As OcrEngineComponentsDialog = New OcrEngineComponentsDialog(ocrEngines(0))
         Try
            dlg.ShowDialog(Me)
         Finally
            CType(dlg, IDisposable).Dispose()
         End Try
      End Sub

        Private Sub _rb_Respository_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _rb_OCR.CheckedChanged, _rb_OCR_ICR.CheckedChanged, _rb_DL.CheckedChanged, _rb_Invoice.CheckedChanged, _rb_OMR.CheckedChanged
            If Not TryCast(sender, RadioButton).Checked Then
                Return
            End If

            _txtMasterFormRespository.Text = GetFormsDir()
            CreateRepository()
            SetupAutoFormsEngine()
        End Sub
   End Class
End Namespace
