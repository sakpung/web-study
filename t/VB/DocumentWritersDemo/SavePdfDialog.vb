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

Imports Leadtools.Document.Writer
Imports System

Namespace DocumentWritersDemo
   Partial Public Class SavePdfDialog
      Inherits Form
      Private _documentFileName As String
      Private _pdfOptions As PdfDocumentOptions
      Private _defaultResolution As Integer
      Private _totalPages As Integer

      Public Sub New(documentFileName As String, pdfOptions As PdfDocumentOptions, defaultResolution As Integer, totalPages As Integer)
         InitializeComponent()

         _documentFileName = documentFileName
         _pdfOptions = pdfOptions
         _defaultResolution = defaultResolution
         _totalPages = totalPages
      End Sub

      Public Sub New(documentFileName As String, pdfOptions As PdfDocumentOptions)
         InitializeComponent()

         _documentFileName = documentFileName
         _pdfOptions = pdfOptions
      End Sub

      Public ReadOnly Property DocumentFileName() As String
         Get
            Return _documentFileName
         End Get
      End Property

      Protected Overrides Sub OnLoad(e As EventArgs)
         If Not DesignMode Then
            _documentFileNameTextBox.Text = _documentFileName

            Dim a As Array = [Enum].GetValues(GetType(PdfDocumentType))
            For Each i As PdfDocumentType In a
               If i <> PdfDocumentType.PdfA AndAlso i <> PdfDocumentType.Pdf16 Then
                  _documentTypeComboBox.Items.Add(i)
               End If
            Next
            _documentTypeComboBox.SelectedItem = _pdfOptions.DocumentType
            _resolutionComboBox.SelectedIndex = 0
            _resolutionNumericUpDown.Value = _defaultResolution
            _resolutionNumericUpDown.Enabled = False

            UpdateUIState()
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Sub _documentTypeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _documentTypeComboBox.SelectedIndexChanged
         UpdateUIState()
      End Sub

      Private Sub _protectedCheckBox_CheckedChanged(sender As Object, e As EventArgs)
         UpdateUIState()
      End Sub

      Private Sub _encryptionModeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
         UpdateUIState()
      End Sub

      Private Sub _browseDocumentFileNameButton_Click(sender As Object, e As EventArgs) Handles _browseDocumentFileNameButton.Click
         Using dlg As New SaveFileDialog()
            dlg.Filter = "PDF Files (*.pdf)|*.pdf"
            dlg.DefaultExt = "pdf"
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               _documentFileNameTextBox.Text = dlg.FileName
            End If
         End Using
      End Sub

      Private Sub UpdateUIState()
         Me.SuspendLayout()

         Me.ResumeLayout()
      End Sub

      Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
         Dim documentFileName As String = _documentFileNameTextBox.Text.Trim()
         If String.IsNullOrEmpty(documentFileName) Then
            Messager.ShowWarning(Me, "Enter the PDF document output file name or click the browse button.")
            _documentFileNameTextBox.Focus()
            DialogResult = DialogResult.None
            Return
         End If

         _documentFileName = documentFileName

         _pdfOptions.DocumentType = CType(_documentTypeComboBox.SelectedItem, PdfDocumentType)
         _pdfOptions.ImageOverText = False
         ' We will not support image/text in this demo
         _pdfOptions.DocumentResolution = If(_resolutionComboBox.SelectedIndex = 0, _defaultResolution, Convert.ToInt32(_resolutionNumericUpDown.Value))
      End Sub

      Private Sub _printEnabledCheckBox_CheckedChanged(sender As Object, e As EventArgs)
         UpdateUIState()
      End Sub

      Private Sub _editEnabledCheckBox_CheckedChanged(sender As Object, e As EventArgs)
         UpdateUIState()
      End Sub


      Private Sub _resolutionComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _resolutionComboBox.SelectedIndexChanged
         _resolutionNumericUpDown.Enabled = _resolutionComboBox.SelectedIndex = 1
      End Sub


      Private Sub _pdfAdvancedOptionsButton_Click(sender As Object, e As EventArgs) Handles _pdfAdvancedOptionsButton.Click
         Dim settings As New Properties.Settings()
         Dim tabIndex As Integer = settings.AdvancedPdfOptionsSelectedTabIndex

         Using dlg As New AdvancedPdfDocumentOptionsDialog(_pdfOptions, _totalPages, tabIndex)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               settings.AdvancedPdfOptionsSelectedTabIndex = dlg.TabControl.SelectedIndex
               settings.Save()
            End If
         End Using
      End Sub
   End Class
End Namespace
