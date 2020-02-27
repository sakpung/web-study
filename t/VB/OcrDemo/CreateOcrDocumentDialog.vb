' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Ocr
Imports System

Namespace OcrDemo
   Partial Public Class CreateOcrDocumentDialog
      Inherits Form
      Private _createOcrDocumentOptions As OcrCreateDocumentOptions

      Public Sub New(ocrDocumentFilePath As String)
         InitializeComponent()

         _createOcrDocumentOptions = OcrCreateDocumentOptions.AutoDeleteFile
         If Not String.IsNullOrEmpty(ocrDocumentFilePath) Then
            _tbOcrDocumentFile.Text = ocrDocumentFilePath
         End If
      End Sub

      Private Sub CreateOcrDocumentDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
         _cmbDocumentMode.Focus()
         _cmbDocumentMode.SelectedIndex = 0
      End Sub

      Public ReadOnly Property OcrDocumentOptions() As OcrCreateDocumentOptions
         Get
            Return _createOcrDocumentOptions
         End Get
      End Property

      Public ReadOnly Property OcrDocumentFilePath() As String
         Get
            Return _tbOcrDocumentFile.Text
         End Get
      End Property


      Private Sub _cmbDocumentMode_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbDocumentMode.SelectedIndexChanged
         Select Case _cmbDocumentMode.SelectedIndex
            Case 0
               ' File
               _createOcrDocumentOptions = If((_tbOcrDocumentFile.Text.Length > 0), OcrCreateDocumentOptions.None, OcrCreateDocumentOptions.AutoDeleteFile)
               _lblHints.Text = "In OCR document file mode you can only handle one page at a time, " + "so you can load one page, OCR it and then add it to the document, then " + "you can repeat the steps for other pages of your source document(s)." & Environment.NewLine & Environment.NewLine + "This is the RECOMMENDED mode to use when dealing with wide number of pages " + "since it saves your system memory and keeps the work on disk."
               Exit Select

            Case 1
               ' Memory
               _createOcrDocumentOptions = OcrCreateDocumentOptions.InMemory
               _lblHints.Text = "OCR document memory mode is ONLY recommended when dealing with a few number " + "of pages since each loaded page will remain in memory which will consume your " + "system memory." & Environment.NewLine & Environment.NewLine + "Multi-page support is enabled when using this mode, you don't have to OCR the pages " + "before adding them to the OCR document while using the memory mode, you can do that even " + "after adding the pages to the document."
               Exit Select
         End Select

         UpdateUIState()
      End Sub

      Private Sub UpdateUIState()
         _lblOcrDocumentFile.Visible = _cmbDocumentMode.SelectedIndex = 0
         _tbOcrDocumentFile.Visible = _cmbDocumentMode.SelectedIndex = 0
         _btnBrowse.Visible = _cmbDocumentMode.SelectedIndex = 0
      End Sub

      Private Sub _btnBrowse_Click(sender As Object, e As EventArgs) Handles _btnBrowse.Click
         Using dlg As New SaveFileDialog()
            Dim extension As String = "ltd"
            Dim friendlyName As String = "LEAD Temporary Document"
            dlg.Filter = String.Format("{0} (*.{1})|*.{1}|All Files (*.*)|*.*", friendlyName, extension)
            dlg.DefaultExt = extension
            dlg.Title = "Select path to save LEAD Temporary Document (LTD)"
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               _tbOcrDocumentFile.Text = dlg.FileName
            End If
         End Using
      End Sub
   End Class
End Namespace
