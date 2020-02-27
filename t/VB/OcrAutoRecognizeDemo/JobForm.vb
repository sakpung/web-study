' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO
Imports System.Text

Imports Leadtools
Imports Leadtools.Ocr
Imports Leadtools.Codecs
Imports Leadtools.Document.Writer

Public Class JobForm

   Private _loadedOk As Boolean = False
   Private _documentFormatSelector As DocumentFormatSelector
   Private _imageFirstPageNumber As Integer
   Private _imageLastPageNumber As Integer
   Private _rasterCodecs As RasterCodecs
   Private _coresWarningMessageDisplayed As Boolean

   Public Sub New(ByVal rasterCodecs As RasterCodecs)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        'Initialize the RasterCodecs object
        _rasterCodecs = RasterCodecs
    End Sub

   Private _jobData As JobData
   Public Property JobData() As JobData
      Get
         Return _jobData
      End Get
      Set(ByVal value As JobData)
         _jobData = value
      End Set
   End Property

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      If Not DesignMode Then
         _documentFormatSelector = New DocumentFormatSelector()
         _documentFormatSelector.Dock = DockStyle.Fill
         _documentFormatsSelectorPanel.Controls.Add(_documentFormatSelector)
         _documentFormatSelector.BringToFront()

         AddHandler _documentFormatSelector.SelectedFormatChanged, AddressOf _documentFormatSelector_SelectedFormatChanged

         Text = Messager.Caption

         Dim settings As New My.MySettings

         ' Show the OCR engine selection dialog to startup the OCR engine
         Dim engineType As String = settings.OcrEngineType

         If IsNothing(JobData.OcrEngine) Then
                Using dlg As New OcrEngineSelectDialog(Messager.Caption, engineType, True)
                    ' Use the same RasterCodecs instance in the OCR engine
                    dlg.RasterCodecsInstance = _rasterCodecs
                    If dlg.ShowDialog(Me) <> DialogResult.OK Then
                        ' Close the demo
                        DialogResult = DialogResult.Cancel
                        Close()
                        Return
                    Else
                        JobData.OcrEngine = dlg.OcrEngine
                    End If
                End Using
         End If

         Text = String.Format("{0} [{1} Engine]", Messager.Caption, JobData.OcrEngine.EngineType.ToString())

         _imageFileNameTextBox.Text = settings.ImageFileName
         _imageFirstPageNumber = settings.FirstPageNumber
         If _imageFirstPageNumber < 1 Then _imageFirstPageNumber = 1
         _imageLastPageNumber = settings.LastPageNumber
         If _imageLastPageNumber < _imageFirstPageNumber Then _imageLastPageNumber = -1

         InitFormats(settings)

         _zonesFileNameTextBox.Text = settings.ZonesFileName

         Try
            _maximumThreadsPerJobTextBox.Text = settings.MaximumThreadsPerJob.ToString()
         Catch
            _maximumThreadsPerJobTextBox.Text = "0"
         End Try

         Try
            _maximumPagesBeforeLtdTextBox.Text = settings.MaximumPagesBeforeLtd.ToString()
         Catch
            _maximumPagesBeforeLtdTextBox.Text = "4"
         End Try

         If Not JobData.OcrEngine.AutoRecognizeManager.IsMultiThreadedSupported Then
            _maximumThreadsPerJobLabel.Visible = False
            _maximumThreadsPerJobTextBox.Visible = False
            _maximumThreadsPerJobInfoLabel.Text = "Multi-threaded documents is not supported in this engine"
         End If

         _preprocessingComboBox.Items.Add("None")
         For Each command As OcrAutoPreprocessPageCommand In System.Enum.GetValues(GetType(OcrAutoPreprocessPageCommand))
            _preprocessingComboBox.Items.Add(command.ToString())
         Next

         _preprocessingComboBox.SelectedItem = "None"

         If Not String.IsNullOrEmpty(settings.Preprocessing) Then
            If String.Compare(settings.Preprocessing, "none", True) = 0 Then
               _preprocessingComboBox.SelectedItem = "None"
            Else
               Try
                  Dim command As OcrAutoPreprocessPageCommand = CType(System.Enum.Parse(GetType(OcrAutoPreprocessPageCommand), settings.Preprocessing), OcrAutoPreprocessPageCommand)
                  _preprocessingComboBox.SelectedItem = command.ToString()
               Catch
               End Try
            End If
         End If

         _continueOnErrorCheckBox.Checked = settings.ContinueOnRecoverableErrors
         _enableTraceCheckBox.Checked = settings.EnableTrace
         _viewFinalDocumentCheckBox.Checked = settings.ViewFinalDocument

         UpdateMyControls()

         _loadedOk = True
      End If

      MyBase.OnLoad(e)
   End Sub

   Protected Overrides Sub OnFormClosed(ByVal e As System.Windows.Forms.FormClosedEventArgs)
      If Not DesignMode Then
         RemoveHandler _documentFormatSelector.SelectedFormatChanged, AddressOf _documentFormatSelector_SelectedFormatChanged

         ' Clean up
         If _loadedOk Then
            ' Save the last setting
            Dim settings As New My.MySettings

            If Not IsNothing(JobData.OcrEngine) Then
               settings.OcrEngineType = JobData.OcrEngine.EngineType.ToString()

               Using ms As New MemoryStream()
                  JobData.OcrEngine.DocumentWriterInstance.SaveOptions(ms)
                  settings.FormatOptionsXml = Encoding.Unicode.GetString(ms.ToArray())
               End Using
            End If

            settings.ImageFileName = _imageFileNameTextBox.Text
            settings.FirstPageNumber = _imageFirstPageNumber
            settings.LastPageNumber = _imageLastPageNumber
            settings.Format = _documentFormatSelector.SelectedFormat.ToString()
            settings.DocumentFileName = _documentFileNameTextBox.Text
            settings.ZonesFileName = _zonesFileNameTextBox.Text

            Dim val As Integer
            If Integer.TryParse(_maximumThreadsPerJobTextBox.Text.Trim(), val) Then
               settings.MaximumThreadsPerJob = val
            End If

            If Integer.TryParse(_maximumPagesBeforeLtdTextBox.Text.Trim(), val) Then
               settings.MaximumPagesBeforeLtd = val
            End If

            settings.Preprocessing = _preprocessingComboBox.SelectedItem.ToString()

            settings.ContinueOnRecoverableErrors = _continueOnErrorCheckBox.Checked
            settings.EnableTrace = _enableTraceCheckBox.Checked
            settings.ViewFinalDocument = _viewFinalDocumentCheckBox.Checked

            settings.Save()
         End If

      End If

      MyBase.OnFormClosed(e)
   End Sub

   Private Sub UpdateMyControls()
      If _imageFirstPageNumber = 1 AndAlso _imageLastPageNumber = -1 Then
         _imageFileNamePagesValueLabel.Text = "All pages"
      ElseIf _imageLastPageNumber = -1 Then
         _imageFileNamePagesValueLabel.Text = String.Format("{0} to last", _imageFirstPageNumber)
      Else
         _imageFileNamePagesValueLabel.Text = String.Format("{0} to {1}", _imageFirstPageNumber, _imageLastPageNumber)
      End If
   End Sub

   Private Sub InitFormats(ByVal settings As My.MySettings)
      Dim initialFormat As DocumentFormat = DocumentFormat.Pdf

      If Not String.IsNullOrEmpty(settings.Format) Then
         Try
            initialFormat = CType(System.Enum.Parse(GetType(DocumentFormat), settings.Format), DocumentFormat)
         Catch
         End Try
      End If

      If Not String.IsNullOrEmpty(settings.FormatOptionsXml) Then
         ' Set the document writer options from the last one we saved
         Try
            Dim buffer() As Byte = Encoding.Unicode.GetBytes(settings.FormatOptionsXml)
            Using ms As New MemoryStream(buffer)
               JobData.OcrEngine.DocumentWriterInstance.LoadOptions(ms)
            End Using
         Catch
         End Try
      End If

      _documentFormatSelector.SetDocumentWriter(JobData.OcrEngine.DocumentWriterInstance, True)
      _documentFormatSelector.SetOcrEngineType(JobData.OcrEngine.EngineType)
      _documentFormatSelector.SelectedFormat = initialFormat

      _documentFileNameTextBox.Text = settings.DocumentFileName
      Dim extension As String = DocumentWriter.GetFormatFileExtension(_documentFormatSelector.SelectedFormat)

      If String.IsNullOrEmpty(_documentFileNameTextBox.Text) Then
         _documentFileNameTextBox.Text += settings.ImageFileName + "." + extension
      End If
   End Sub

   Private Sub _imageFileNameBrowseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _imageFileNameBrowseButton.Click
      Using dlg As New OpenFileDialog()
         dlg.Title = "Select image file to OCR"
         dlg.Filter = "All Files|*.*"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _imageFileNameTextBox.Text = dlg.FileName
            If Not String.IsNullOrEmpty(_documentFileNameTextBox.Text) Then
               Dim trimChars As Char() = {"\"c}
               _documentFileNameTextBox.Text = (If((String.IsNullOrEmpty(Path.GetDirectoryName(_documentFileNameTextBox.Text))), Path.GetDirectoryName(dlg.FileName), Path.GetDirectoryName(_documentFileNameTextBox.Text).TrimEnd(trimChars))) + "\" + Path.GetFileName(dlg.FileName)
            Else
               _documentFileNameTextBox.Text = dlg.FileName
            End If

            _documentFileNameTextBox.Text += "." + DocumentWriter.GetFormatFileExtension(_documentFormatSelector.SelectedFormat)
         End If
      End Using
   End Sub

   Private Sub _imageFilePagesBrowseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _imageFilePagesBrowseButton.Click
      Using dlg As New SelectPagesDialog()
         dlg.FirstPageNumber = _imageFirstPageNumber
         dlg.LastPageNumber = _imageLastPageNumber
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _imageFirstPageNumber = dlg.FirstPageNumber
            _imageLastPageNumber = dlg.LastPageNumber
            UpdateMyControls()
         End If
      End Using
   End Sub

   Private Sub _documentFileNameBrowseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _documentFileNameBrowseButton.Click
      Using dlg As New SaveFileDialog()
         dlg.Title = "Select output document file name"
         Dim format As DocumentFormat = _documentFormatSelector.SelectedFormat
         Dim extension As String = DocumentWriter.GetFormatFileExtension(format)
         Dim formatName As String = DocumentWriter.GetFormatFriendlyName(format)
         dlg.Filter = String.Format("{0} (*.{1})|*.{1}|All Files|*.*", formatName, extension)
         dlg.DefaultExt = extension
         dlg.FileName = Path.GetFileName(_documentFileNameTextBox.Text)

         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _documentFileNameTextBox.Text = dlg.FileName
         End If
      End Using
   End Sub

   Private Sub _documentFormatSelector_SelectedFormatChanged(ByVal sender As Object, ByVal e As EventArgs)
      ' Change the Document Image file extension when the document format is changed.
      Dim format As DocumentFormat = _documentFormatSelector.SelectedFormat
      Dim extension As String = DocumentWriter.GetFormatFileExtension(format)
      _documentFileNameTextBox.Text = Path.ChangeExtension(_documentFileNameTextBox.Text, extension)

      Dim options As DocumentOptions = JobData.OcrEngine.DocumentWriterInstance.GetOptions(_documentFormatSelector.SelectedFormat)
      _documentFormatSelector.TotalPages = JobData.LastPageNumber - JobData.FirstPageNumber

      Select Case _documentFormatSelector.SelectedFormat
         Case DocumentFormat.Xps
            _documentFormatSelector.FormatHasOptions = False

         Case DocumentFormat.Doc
            _documentFormatSelector.FormatHasOptions = True

         Case DocumentFormat.Docx
            _documentFormatSelector.FormatHasOptions = True

         Case DocumentFormat.Rtf
            _documentFormatSelector.FormatHasOptions = True
#If LEADTOOLS_V17_OR_LATER Then
         Case DocumentFormat.Xls
            _documentFormatSelector.FormatHasOptions = False
#End If

#If LEADTOOLS_V19_OR_LATER Then
         Case DocumentFormat.AltoXml
            _documentFormatSelector.FormatHasOptions = True

         Case DocumentFormat.Pub
            _documentFormatSelector.FormatHasOptions = False

         Case DocumentFormat.Mob
            _documentFormatSelector.FormatHasOptions = False

         Case DocumentFormat.Svg
            _documentFormatSelector.FormatHasOptions = False
#End If ' #if LEADTOOLS_V19_OR_LATER

         Case Else
            _documentFormatSelector.FormatHasOptions = True
      End Select

      If Not IsNothing(options) Then
         JobData.OcrEngine.DocumentWriterInstance.SetOptions(_documentFormatSelector.SelectedFormat, options)
      End If
   End Sub

   Private Sub _zonesFileNameBrowseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _zonesFileNameBrowseButton.Click
      Using dlg As New OpenFileDialog()
         dlg.Title = "Select input zones file name"
         dlg.Filter = "OCR zone files (*.ozf)|*.ozf|All Files|*.*"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _zonesFileNameTextBox.Text = dlg.FileName
         End If
      End Using
   End Sub

   Private Sub _exitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _exitButton.Click
      DialogResult = DialogResult.Cancel
      Close()
   End Sub

   Private Sub _runButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _runButton.Click
      ' Collect the job data
      Dim imageFileName As String = _imageFileNameTextBox.Text.Trim()
      If String.IsNullOrEmpty(imageFileName) Then
         Messager.ShowInformation(Me, "Enter a valid image file name")
         _imageFileNameTextBox.SelectAll()
         _imageFileNameTextBox.Focus()
         Return
      End If

      Dim documentFileName As String = _documentFileNameTextBox.Text.Trim()
      If String.IsNullOrEmpty(documentFileName) Then
         Messager.ShowInformation(Me, "Enter a valid document file name")
         _documentFileNameTextBox.SelectAll()
         _documentFileNameTextBox.Focus()
         Return
      End If

      Dim zonesFileName As String = _zonesFileNameTextBox.Text.Trim()

      Dim maximumPagesBeforeLtd As Integer
      If Not Integer.TryParse(_maximumPagesBeforeLtdTextBox.Text, maximumPagesBeforeLtd) OrElse maximumPagesBeforeLtd < 0 Then
         Messager.ShowInformation(Me, "Enter a valud equals to or greater than zero for LTD pages")
         _maximumPagesBeforeLtdTextBox.SelectAll()
         _maximumPagesBeforeLtdTextBox.Focus()
         Return
      End If

      Dim maximumThreadsPerJob As Integer = 0
      If _maximumThreadsPerJobTextBox.Visible Then
         If Not Integer.TryParse(_maximumThreadsPerJobTextBox.Text, maximumThreadsPerJob) OrElse maximumThreadsPerJob < 0 Then
            Messager.ShowInformation(Me, "Enter a valud equals to or greater than zero for multi-threaded documents")
            _maximumThreadsPerJobTextBox.SelectAll()
            _maximumThreadsPerJobTextBox.Focus()
            Return
         End If
      End If

      JobData.ImageFileName = imageFileName
      JobData.FirstPageNumber = _imageFirstPageNumber
      JobData.LastPageNumber = _imageLastPageNumber
      JobData.Format = _documentFormatSelector.SelectedFormat
      JobData.DocumentFileName = documentFileName
      If Not String.IsNullOrEmpty(zonesFileName) Then
         JobData.ZonesFileName = zonesFileName
      Else
         JobData.ZonesFileName = Nothing
      End If
      JobData.EnableTrace = _enableTraceCheckBox.Checked
      If _continueOnErrorCheckBox.Checked Then
         JobData.JobErrorMode = OcrAutoRecognizeManagerJobErrorMode.Continue
      Else
         JobData.JobErrorMode = OcrAutoRecognizeManagerJobErrorMode.Abort
      End If
      JobData.MaximumPagesBeforeLtd = maximumPagesBeforeLtd
      JobData.MaximumThreadsPerJob = maximumThreadsPerJob

      If IsNothing(JobData.PreprocessPageCommands) Then
         JobData.PreprocessPageCommands = New List(Of OcrAutoPreprocessPageCommand)
      End If

      JobData.PreprocessPageCommands.Clear()

      If _preprocessingComboBox.SelectedItem.ToString() <> "None" Then
         JobData.PreprocessPageCommands.Add(CType(System.Enum.Parse(GetType(OcrAutoPreprocessPageCommand), _preprocessingComboBox.SelectedItem.ToString()), OcrAutoPreprocessPageCommand))
      End If

      JobData.ViewFinalDocument = _viewFinalDocumentCheckBox.Checked

      If (Not _coresWarningMessageDisplayed AndAlso JobData.MaximumThreadsPerJob > Environment.ProcessorCount) Then
         _coresWarningMessageDisplayed = True

         If (MessageBox.Show( _
            Me, _
            String.Format( _
               "You selected a maximum number of threads per job ({0}) that is greater than the number of cores in this machine ({1}).\n" + _
               "This will result in performance that is not optimal. Continue with these values?\n\nThis message will not be displayed again.", _
            JobData.MaximumThreadsPerJob, Environment.ProcessorCount), _
            Messager.Caption, _
            MessageBoxButtons.YesNo, _
            MessageBoxIcon.Warning) = DialogResult.No) Then
            DialogResult = DialogResult.None
            Return
         End If
      End If

      DialogResult = DialogResult.OK
      Close()
   End Sub

   Private Sub _engineSettingsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _engineSettingsButton.Click
      Using dlg As New EngineSettingsDialog(JobData.OcrEngine)
         dlg.ShowDialog(Me)
      End Using

   End Sub

   Private Sub _engineLanguagesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _engineLanguagesButton.Click
      Using dlg As New EnableLanguagesDialog(JobData.OcrEngine)
         dlg.ShowDialog(Me)
      End Using
   End Sub
End Class
