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
Imports System.Threading

Imports Leadtools.Pdf

Namespace PDFDocumentDemo.LoadDocument
   Partial Public Class LoadDocumentDialog : Inherits Form
      Private _isWorking As Boolean = True

      Private _document As PDFDocument
      Public ReadOnly Property PDFDocument() As PDFDocument
         Get
            Return _document
         End Get
      End Property

      Public Sub New(ByVal fileName As String)
         InitializeComponent()

         _fileNameTextBox.Text = fileName
      End Sub

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         If (Not DesignMode) Then
            BeginInvoke(New MethodInvoker(AddressOf CheckAndLoadDocument))
         End If

         MyBase.OnLoad(e)
      End Sub

      Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
         e.Cancel = _isWorking

         MyBase.OnFormClosing(e)
      End Sub

      Private Sub CheckAndLoadDocument()
         _isWorking = True
         _cancelButton.Enabled = False
         _okButton.Enabled = False
         Application.DoEvents()

         Dim document As PDFDocument = _getDocumentPropertiesControl.Run(_fileNameTextBox.Text)
         If document Is Nothing Then
            _isWorking = False
            DialogResult = DialogResult.Cancel
            Return
         End If

         _document = document

         _mainWizardControl.SelectedTab = _optionsTabPage
         _loadDocumentOptionsControl.SetDocument(document)

         _isWorking = False
         _cancelButton.Enabled = True
         _okButton.Enabled = True

         Application.DoEvents()
      End Sub

      Private Sub ReadDocument()
         _isWorking = True
         _cancelButton.Enabled = False
         _okButton.Enabled = False
         Application.DoEvents()

         Dim noErrors As Boolean = _readPDFDocumentControl.Run(_document, _loadDocumentOptionsControl.ReadDocumentStructOptions, _loadDocumentOptionsControl.ParsePagesOptions, _loadDocumentOptionsControl.ParseChunks)

         _isWorking = False
         _okButton.Enabled = True

         If noErrors Then
            DialogResult = System.Windows.Forms.DialogResult.OK
            Close()
         End If
      End Sub

      Private Sub _okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _okButton.Click
         If _mainWizardControl.SelectedTab Is _optionsTabPage Then
            _loadDocumentOptionsControl.Apply()
            _document.Resolution = _loadDocumentOptionsControl.Resolution

            _mainWizardControl.SelectedTab = _readTabPage
            BeginInvoke(New MethodInvoker(AddressOf ReadDocument))
            DialogResult = DialogResult.None
            Return
         End If
      End Sub
   End Class
End Namespace
