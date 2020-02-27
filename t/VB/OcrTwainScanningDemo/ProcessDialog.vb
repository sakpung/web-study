' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports Leadtools
Imports Leadtools.Twain
Imports Leadtools.Ocr
Imports Leadtools.Document.Writer
Imports Leadtools.ImageProcessing.Core

Public Class ProcessDialog

   Private _twainSession As TwainSession
   Private _document As IOcrDocument
   Private _documentFileName As String
   Private _format As DocumentFormat

   Private _canceled As Boolean

   Private Delegate Sub DoWorkDelegate()

   Sub New(ByVal twainSession As TwainSession, ByVal ocrEngine As IOcrEngine, ByVal documentFileName As String, ByVal format As DocumentFormat)

      InitializeComponent()

      _twainSession = twainSession
#If LEADTOOLS_V19_OR_LATER Then
      _document = ocrEngine.DocumentManager.CreateDocument(Nothing, OcrCreateDocumentOptions.InMemory)
#Else
      _document = ocrEngine.DocumentManager.CreateDocument()
#End If
      _documentFileName = documentFileName
      _format = format
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      BeginInvoke(New DoWorkDelegate(AddressOf DoWork))

      MyBase.OnLoad(e)
   End Sub

   Private Sub DoWork()
      If (Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, _twainSession.SelectedSourceName())) Then
         _canceled = True
         DialogResult = DialogResult.Cancel
         Return
      End If
      ' Create an OCR document
      ' Acquire the page(s)
      ' Deskew the page
      ' Add the pages to the engine
      ' Recognize
      ' Save to final document

      _lblProcessing.Text = "Acquiring a page..."

      _canceled = False

      AddHandler _twainSession.AcquirePage, AddressOf _twainSession_AcquirePage

      Try
         If (Not _canceled) Then
            Dim res As DialogResult = _twainSession.Acquire(TwainUserInterfaceFlags.Show)
            If (res <> DialogResult.OK And _document.Pages.Count <= 0) Then
               _canceled = True
            End If
         End If

         If (_document.Pages.Count > 0) Then
            ' We have the pages in the OCR engine, recognize them
            If (Not _canceled) Then
               _document.Pages.Recognize(New OcrProgressCallback(AddressOf OcrProgress))
            End If
            If (Not _canceled) Then
               _document.Save(_documentFileName, _format, New OcrProgressCallback(AddressOf OcrProgress))
            End If
            ' Show the final document
            If (Not _canceled AndAlso System.IO.File.Exists(_documentFileName)) Then
               Process.Start(_documentFileName)
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      Finally

         ' Unhook from the twain events
         RemoveHandler _twainSession.AcquirePage, AddressOf _twainSession_AcquirePage

         ' Remove all the pages from the document
         _document.Pages.Clear()
         _document.Dispose()

         If (Not _canceled) Then
            DialogResult = DialogResult.OK
         Else
            DialogResult = DialogResult.Cancel
         End If
      End Try
   End Sub

   Private Sub ShowError(ByVal ex As Exception)
      If (TypeOf ex Is OcrException) Then
         Dim oe As OcrException = CType(ex, OcrException)
         Messager.ShowError(Me, String.Format("LEADTOOLS Error\nCode: {0}\nMessage:{1}", oe.Code, ex.Message))
         _canceled = True
      ElseIf (TypeOf ex Is RasterException) Then
         Dim re As RasterException = CType(ex, RasterException)
         Messager.ShowError(Me, String.Format("OCR Error\nCode: {0}\nMessage:{1}", re.Code, ex.Message))
         _canceled = True
      Else
         Messager.ShowError(Me, ex)
         _canceled = True
      End If
   End Sub

   Private Sub _twainSession_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs)
      If (Not _canceled) Then
         Try
            Dim image As RasterImage = e.Image
            ' Deskew the image
            Dim cmd As DeskewCommand = New DeskewCommand()
            cmd.FillColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White)
            cmd.Flags = DeskewCommandFlags.DocumentImage
            cmd.Run(Image)

            ' Add the page to the OCR engine
            _document.Pages.AddPage(image, New OcrProgressCallback(AddressOf OcrProgress))
         Catch ex As Exception
            ShowError(ex)
            e.Cancel = True
         End Try

         ' Check if we canceled
         If (_canceled) Then
            e.Cancel = True
         End If
      End If
   End Sub

   Private Delegate Sub UpdateOcrProgressDelegate(ByVal str As String)
   Private Sub OcrProgress(ByVal data As IOcrProgressData)
      If (Not _canceled) Then
         If (InvokeRequired) Then
            BeginInvoke(New UpdateOcrProgressDelegate(AddressOf DoUpdateOcrProgress), New Object() {"OCR operation: " + data.Operation.ToString()})
         Else
            DoUpdateOcrProgress("OCR operation: " + data.Operation.ToString())
         End If
         Application.DoEvents()
      Else
         data.Status = OcrProgressStatus.Abort
      End If
   End Sub

   Private Sub DoUpdateOcrProgress(ByVal str As String)
      _lblProcessing.Text = str
   End Sub

   Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnCancel.Click
      ' Signal canceling
      _canceled = True

      ' We will set the dialog result in DoWork
      DialogResult = DialogResult.None
   End Sub
End Class
