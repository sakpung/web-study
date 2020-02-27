' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Net
Imports System.IO

Imports Leadtools
Imports Leadtools.Ocr
Imports Leadtools.Document.Writer
Imports Leadtools.SharePoint.Client

Namespace Ocr2SharePointDemo
   Partial Public Class RecognizeAndUploadControl : Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Private _mainForm As MainForm
      Public Sub SetOwner(ByVal mainForm As MainForm)
         _mainForm = mainForm
      End Sub

      Private _serverSettings As SharePoint.SharePointServerSettings
      Private _imageDocumentFileName As String
      Private _serverDocumentPathAndFileName As String
      Private _serverDocumentFullUri As Uri
      Private _format As MyDocumentFormat

      Private _lastUploadedDocumentUri As Uri

      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property LastUplodedDocumentUri() As Uri
         Get
            Return _lastUploadedDocumentUri
         End Get
      End Property

      Public Sub SetProperties(ByVal serverSettings As SharePoint.SharePointServerSettings, ByVal imageDocumentFileName As String, ByVal serverDocumentPathAndFileName As String, ByVal format As MyDocumentFormat)

         _serverSettings = serverSettings
         _imageDocumentFileName = imageDocumentFileName
         _serverDocumentPathAndFileName = serverDocumentPathAndFileName
         _format = format

         Dim builder As UriBuilder = New UriBuilder(_serverSettings.Uri)
         builder.Path = Path.Combine(builder.Path, serverDocumentPathAndFileName)
         _serverDocumentFullUri = builder.Uri

         _imageDocumentFileNameTextBox.Text = _imageDocumentFileName
         _serverDocumentNameTextBox.Text = _serverDocumentFullUri.ToString()
      End Sub

      Public Sub Run()
         ' Try to connect
         _successLabel.Visible = False
         _errorLabel.Visible = False
         _lastUploadedDocumentUri = Nothing
         _mainForm.BeginOperation(New MethodInvoker(AddressOf RecognizeAndUpload))
      End Sub

      Private Sub RecognizeAndUpload()
         Dim err As Exception = Nothing
         Dim outputFileName As String = Nothing

         Try
            BeginInvoke(New SetOperationTextDelegate(AddressOf _mainForm.SetOperationText), New Object() {"Creating OCR engine..."})

            Using ocrEngine As IOcrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, False)
               ocrEngine.Startup(Nothing, Nothing, Nothing, Nothing)

               ' Recognize to a temp file name
               BeginInvoke(New SetOperationTextDelegate(AddressOf _mainForm.SetOperationText), New Object() {"Recognizing document..."})
               outputFileName = System.IO.Path.GetTempFileName()
               DoRecognize(ocrEngine, outputFileName)

               BeginInvoke(New SetOperationTextDelegate(AddressOf _mainForm.SetOperationText), New Object() {"Uploading document..."})
               UploadDocument(outputFileName)
            End Using

            BeginInvoke(New ShowUIControlDelegate(AddressOf ShowUIControl), New Object() {_successLabel, True})

            _lastUploadedDocumentUri = _serverDocumentFullUri
         Catch ex As Exception
            err = ex

            BeginInvoke(New ShowUIControlDelegate(AddressOf ShowUIControl), New Object() {_errorLabel, True})
         Finally
            If Not outputFileName Is Nothing AndAlso System.IO.File.Exists(outputFileName) Then
               Try
                  System.IO.File.Delete(outputFileName)
               Catch
               End Try
            End If
         End Try

         _mainForm.EndOperation(err)
      End Sub

      Private Delegate Sub ShowUIControlDelegate(ByRef ctrl As Control, ByVal show As Boolean)
      Private Sub ShowUIControl(ByRef ctrl As Control, ByVal show As Boolean)
         ctrl.Visible = show
      End Sub

      Private Sub DoRecognize(ByVal ocrEngine As IOcrEngine, ByVal outputFileName As String)
         ' Set the output format options
         Dim docFormat As DocumentFormat

         Select Case _format
            Case MyDocumentFormat.DOC
               docFormat = DocumentFormat.Doc

            Case MyDocumentFormat.DOCX
               docFormat = DocumentFormat.Docx

            Case MyDocumentFormat.TEXT
               docFormat = DocumentFormat.Text

            Case Else
               docFormat = DocumentFormat.Pdf
               If _format = MyDocumentFormat.PDFImageOverText Then
                  Dim pdfOptions As PdfDocumentOptions = TryCast(ocrEngine.DocumentWriterInstance.GetOptions(docFormat), PdfDocumentOptions)
                  pdfOptions.ImageOverText = True
                  ocrEngine.DocumentWriterInstance.SetOptions(docFormat, pdfOptions)
               End If
         End Select

         Dim autoRecognizeManager As IOcrAutoRecognizeManager = ocrEngine.AutoRecognizeManager
         autoRecognizeManager.Run(_imageDocumentFileName, outputFileName, docFormat, Nothing, Nothing)
      End Sub

      Private Sub UploadDocument(ByVal outputFileName As String)
         Dim spClient As SharePointClient = New SharePointClient()
         spClient.OverwriteExistingFiles = True

         ' Set the credentials and proxy
         If Not _serverSettings.UserName Is Nothing Then
            spClient.Credentials = New NetworkCredential(_serverSettings.UserName, _serverSettings.Password, _serverSettings.Domain)
         End If

         If Not _serverSettings.ProxyUri Is Nothing Then
            Dim proxy As WebProxy = New WebProxy(_serverSettings.ProxyUri, _serverSettings.ProxyPort)
            If proxy.Credentials Is Nothing AndAlso Not spClient.Credentials Is Nothing Then
               proxy.Credentials = spClient.Credentials
            Else
               proxy.Credentials = CredentialCache.DefaultCredentials
            End If

            spClient.Proxy = proxy
         Else
            spClient.Proxy = WebRequest.GetSystemWebProxy() ' Get default system proxy settings
         End If

         ' Upload the file
         spClient.UploadFile(outputFileName, New Uri(_serverSettings.Uri), _serverDocumentPathAndFileName)
      End Sub
   End Class
End Namespace
