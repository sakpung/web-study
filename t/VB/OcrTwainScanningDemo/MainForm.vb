' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO
Imports Microsoft.Win32

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Ocr
Imports Leadtools.Document.Writer
Imports Leadtools.Twain

#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Demos.Dialogs
#End If

Public Class MainForm
   Private _ocrEngineType As OcrEngineType
   Private _ocrEngine As IOcrEngine
   Private _twainSession As TwainSession = Nothing


   ''' <summary>
   ''' The main entry point for the application.
   ''' </summary>
   <STAThread()> _
   Shared Sub Main()
      
      If Not Support.SetLicense() Then
         Return
      End If

      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New MainForm())
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      ' Setup the Messager
      Messager.Caption = "VB OCR Twain Scanning Demo"
      Text = Messager.Caption

      If Not DesignMode Then
         BeginInvoke(New MethodInvoker(AddressOf Startup))
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub Startup()
      ' Initialize the TWAIN session
#If Not LEADTOOLS_V19_OR_LATER Then
        If (TwainSession.IsAvailable(Me)) Then
#Else
      If (TwainSession.IsAvailable(Me.Handle)) Then
#End If ' #If Not LEADTOOLS_V19_OR_LATER Then
         Try
            _twainSession = New TwainSession()
#If Not LEADTOOLS_V19_OR_LATER Then
            _twainSession.Startup(Me, "LEAD Technologies, Inc.", "LEADTOOLS", "Version 1.0", "OCR Twain Scanning Demo", TwainStartupFlags.None)
#Else
            _twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEADTOOLS", "Version 1.0", "OCR Twain Scanning Demo", TwainStartupFlags.None)
#End If ' #If Not LEADTOOLS_V19_OR_LATER Then

            Dim temp As String = _twainSession.SelectedSourceName()
         Catch ex As TwainException
            If (ex.Code = TwainExceptionCode.InvalidDll) Then
               _twainSession = Nothing
               Messager.ShowError(Me, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org")
            Else
               _twainSession = Nothing
               Messager.ShowError(Me, ex)
            End If

            Close()
            Return
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            _twainSession = Nothing
            Close()
            Return
         End Try
        Else
            Messager.ShowInformation(Me, "Could not find any TWAIN compatible scanners in the machine. Me demo cannot function without TWAIN support and therefore will exit now")
            Close()
            Return
        End If

        ' Load the settings from app.config
        If (Not LoadSettings()) Then
            Close()
            Return
        End If

        UpdateMyControls()
   End Sub

   Protected Overrides Sub OnFormClosed(ByVal e As FormClosedEventArgs)
      ' Save the settings
      SaveSettings()

      ' Shutdown the OCR engine if started
      If (Not _ocrEngine Is Nothing) Then
         _ocrEngine.Shutdown()
         _ocrEngine.Dispose()
      End If

      If (Not _twainSession Is Nothing) Then
         _twainSession.Shutdown()
      End If
      MyBase.OnFormClosed(e)
   End Sub


   Private Sub _miFileExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miFileExit.Click
      Close()
   End Sub

   Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miHelpAbout.Click
#If LEADTOOLS_V19_OR_LATER Then
      Using aboutDialog As New AboutDialog("OCR Twain Scanning", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
#Else
      Using aboutDialog As New AboutDialog("OCR Twain Scanning")
	      aboutDialog.ShowDialog(Me)
      End Using
#End If
   End Sub

   Private Sub _miOcrSettings_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miOcrSettings.Click
      Dim dlg As OcrEngineSettingsDialog = New OcrEngineSettingsDialog(_ocrEngine)
      dlg.ShowDialog(Me)
   End Sub

   Private Sub _miOcrComponents_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miOcrComponents.Click
      Dim dlg As OcrEngineComponentsDialog = New OcrEngineComponentsDialog(_ocrEngine)
      dlg.ShowDialog(Me)
   End Sub

   Private Sub _miTwainSelectSource_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miTwainSelectSource.Click
      Try
         _twainSession.SelectSource(Nothing)
      Catch ex As Exception
         ShowError(ex, Me, _ocrEngineType)
      Finally
         UpdateMyControls()
      End Try
   End Sub

   Private Sub _tbFinalDocumentFileName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _tbFinalDocumentFileName.TextChanged
      UpdateMyControls()
   End Sub

   Private Function LoadSettings() As Boolean

      Dim settings As Settings = New Settings()

      Dim engineType As String = settings.OcrEngineType

      ' Show the engine selection dialog
      Using dlg As OcrEngineSelectDialog = New OcrEngineSelectDialog(Messager.Caption, engineType, True)
         If (dlg.ShowDialog(Me) = DialogResult.OK) Then
            _ocrEngine = dlg.OcrEngine
            _ocrEngineType = dlg.SelectedOcrEngineType

            Dim codecs As RasterCodecs = _ocrEngine.RasterCodecsInstance
#If Not LEADTOOLS_V175_OR_LATER Then
            codecs.Options.Pdf.Load.XResolution = 300
            codecs.Options.Pdf.Load.YResolution = 300
            codecs.Options.RasterizeDocument.Load.Enabled = True
#End If

#If LEADTOOLS_V16_OR_LATER Then
            ' Use the new RasterizeDocumentOptions to default loading document files at 300 DPI

            codecs.Options.RasterizeDocument.Load.XResolution = 300
            codecs.Options.RasterizeDocument.Load.YResolution = 300
            codecs.Options.Pdf.Load.EnableInterpolate = True
            codecs.Options.Load.AutoFixImageResolution = True
#End If

         Else
            Return False
         End If
      End Using

      UpdateDocumentFormats()

      Dim twainSourceName As String = settings.TwainSourceName
      If (Not String.IsNullOrEmpty(twainSourceName)) Then
         Try
            _twainSession.SelectSource(twainSourceName)
         Catch

         End Try
      End If

      _tbFinalDocumentFileName.Text = settings.DocumentFileName.Trim()
      If (String.IsNullOrEmpty(_tbFinalDocumentFileName.Text)) Then
         _tbFinalDocumentFileName.Text = Path.Combine(Path.GetFullPath(DemosGlobal.ImagesFolder), "OcrTwainScanningDemo")
      End If
      SelectFormatByName(settings.DocumentFormat)

      _documentFormatSelector_SelectedFormatChanged(Nothing, EventArgs.Empty)

      Return True
   End Function

   Private Sub UpdateDocumentFormats()
      _documentFormatSelector.SetDocumentWriter(_ocrEngine.DocumentWriterInstance, False)
      _documentFormatSelector.SetOcrEngineType(_ocrEngineType)
      _documentFormatSelector.SelectedFormat = DocumentFormat.Pdf
   End Sub

   Private Sub SelectFormatByName(ByVal documentFormatName As String)
      Dim format As DocumentFormat = DocumentFormat.Pdf
      Try
         format = CType(System.Enum.Parse(GetType(DocumentFormat), documentFormatName), DocumentFormat)
      Catch
      End Try

      _documentFormatSelector.SelectedFormat = format
   End Sub

   Private Sub _documentFormatSelector_SelectedFormatChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _documentFormatSelector.SelectedFormatChanged
      ' Update the file name of the document with the correct extension
      Dim documentFileName As String = _tbFinalDocumentFileName.Text.Trim()
      If Not (String.IsNullOrEmpty(documentFileName)) Then
         Dim format As DocumentFormat = _documentFormatSelector.SelectedFormat
         Dim extension As String = DocumentWriter.GetFormatFileExtension(format)
         documentFileName = Path.ChangeExtension(documentFileName, extension)
         _tbFinalDocumentFileName.Text = documentFileName
      End If

      Dim options As DocumentOptions = _ocrEngine.DocumentWriterInstance.GetOptions(_documentFormatSelector.SelectedFormat)

      _documentFormatSelector.FormatHasOptions = True
      _documentFormatSelector.TotalPages = 1
      Select Case _documentFormatSelector.SelectedFormat
         Case DocumentFormat.Xps
            _documentFormatSelector.FormatHasOptions = False
            Exit Select

         Case DocumentFormat.Doc
            _documentFormatSelector.FormatHasOptions = True
            Exit Select

         Case DocumentFormat.Docx
            _documentFormatSelector.FormatHasOptions = True
            Exit Select

         Case DocumentFormat.Rtf
            _documentFormatSelector.FormatHasOptions = True
            Exit Select

#If LEADTOOLS_V17_OR_LATER Then
         Case DocumentFormat.Xls
            _documentFormatSelector.FormatHasOptions = False
            Exit Select
#End If ' #if LEADTOOLS_V17_OR_LATER

#If LEADTOOLS_V19_OR_LATER Then
         Case DocumentFormat.AltoXml
            _documentFormatSelector.FormatHasOptions = True
            Exit Select

         Case DocumentFormat.Pub
            _documentFormatSelector.FormatHasOptions = False
            Exit Select

         Case DocumentFormat.Mob
            _documentFormatSelector.FormatHasOptions = False
            Exit Select

         Case DocumentFormat.Svg
            _documentFormatSelector.FormatHasOptions = False
            Exit Select
#End If ' #if LEADTOOLS_V19_OR_LATER
      End Select

      If Not options Is Nothing Then
         _ocrEngine.DocumentWriterInstance.SetOptions(_documentFormatSelector.SelectedFormat, options)
      End If
   End Sub

   Private Sub _btnFinalDocumentFileName_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnFinalDocumentFileName.Click
      Dim format As DocumentFormat = _documentFormatSelector.SelectedFormat
      Dim extension As String = DocumentWriter.GetFormatFileExtension(format)

      Dim dlg As New SaveFileDialog()
      dlg.Filter = String.Format("{0} Files (*.{1})|*.{1}|All Files|*.*", DocumentWriter.GetFormatFriendlyName(format), extension)
      dlg.DefaultExt = extension
      dlg.FileName = _tbFinalDocumentFileName.Text.Trim()
      If (dlg.ShowDialog(Me) = DialogResult.OK) Then
         _tbFinalDocumentFileName.Text = dlg.FileName
      End If
   End Sub

   Private Sub SaveSettings()
      Try
         Dim settings As Settings = New Settings()
         settings.OcrEngineType = _ocrEngineType.ToString()
         If (Not _twainSession Is Nothing) Then
            settings.TwainSourceName = _twainSession.SelectedSourceName()
         Else
            settings.TwainSourceName = String.Empty
         End If

         settings.DocumentFileName = _tbFinalDocumentFileName.Text
         settings.DocumentFormat = _documentFormatSelector.SelectedFormat.ToString()
         settings.Save()
      Catch
      End Try
   End Sub

   Private Sub UpdateMyControls()
      If (Not _twainSession Is Nothing) Then
         _lblTwainSourceName.Text = _twainSession.SelectedSourceName()
      Else
         _lblTwainSourceName.Text = String.Empty
      End If
      _lblOcrEngineName.Text = String.Format("LEADTOOLS OCR {0} Engine", _ocrEngineType.ToString())
      _btnScan.Enabled = (Not _twainSession Is Nothing) AndAlso (_tbFinalDocumentFileName.Text.Trim().Length > 0)
   End Sub

   Public Shared Sub ShowError(ByVal ex As Exception, ByVal owner As IWin32Window, ByVal ocrEngineType As OcrEngineType)
      If (TypeOf ex Is OcrException) Then
         Dim oe As OcrException = CType(ex, OcrException)
         Messager.ShowError(owner, String.Format("LEADTOOLS Error\nCode: {0}\nMessage:{1}", oe.Code, ex.Message))
      ElseIf (TypeOf ex Is RasterException) Then
         Dim re As RasterException = CType(ex, RasterException)
         Messager.ShowError(owner, String.Format("OCR Error\nCode: {0}\nMessage:{1}", re.Code, ex.Message))
      Else
         Messager.ShowError(owner, ex)
      End If
   End Sub

   Private Sub _btnScan_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnScan.Click
      Dim documentFileName As String = _tbFinalDocumentFileName.Text.Trim()
      Dim format As DocumentFormat = _documentFormatSelector.SelectedFormat
      Dim dlg As ProcessDialog = New ProcessDialog(_twainSession, _ocrEngine, documentFileName, format)
      dlg.ShowDialog(Me)
   End Sub
End Class
