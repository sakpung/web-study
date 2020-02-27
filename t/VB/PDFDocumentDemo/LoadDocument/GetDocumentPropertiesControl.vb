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

Imports Leadtools.Pdf
Imports PDFDocumentDemo.Leadtools.Demos

Namespace PDFDocumentDemo.LoadDocument
   Partial Public Class GetDocumentPropertiesControl : Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         _fileTypeLabel.Visible = False
         _fileTypeValueLabel.Visible = False
         _encryptionLabel.Visible = False
         _encryptionValueLabel.Visible = False
         _createDocumentLabel.Visible = False
         _createDocumentValueLabel.Visible = False

         MyBase.OnLoad(e)
      End Sub

      Private _fileName As String
      Private _password As String

      Public Function Run(ByVal fileName As String) As PDFDocument
         Dim document As PDFDocument = Nothing

         _fileName = fileName

         Try
            ' - Get the file type, must be PDF
            GetFileType()

            ' - Check its encryption
            If CheckEncryption() Then
               ' Create the PDF document and get its properties
               document = CreateDocument()
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try

         Return document
      End Function

      Private Sub GetFileType()
         _fileTypeLabel.Visible = True
         Application.DoEvents()

         Dim wait As WaitCursor = New WaitCursor()
         Try
            Dim fileType As PDFFileType = PDFFile.GetPDFFileType(_fileName, True)
            _fileTypeValueLabel.Visible = True
            _fileTypeValueLabel.Text = DemosGlobalization.GetResxString(Me.GetType(), "resx_Finished")
            Application.DoEvents()
         Finally
            CType(wait, IDisposable).Dispose()
         End Try
      End Sub

      Private Function CheckEncryption() As Boolean
         _encryptionLabel.Visible = True
         Application.DoEvents()

         Dim success As Boolean = False

         Dim wait As WaitCursor = New WaitCursor()
         Try
            Dim encrypted As Boolean = PDFFile.IsEncrypted(_fileName)

            _encryptionValueLabel.Visible = True
            If encrypted Then
               _encryptionValueLabel.Text = DemosGlobalization.GetResxString(Me.GetType(), "resx_Encrypted")
            Else
               _encryptionValueLabel.Text = DemosGlobalization.GetResxString(Me.GetType(), "resx_NotEncrypted")
            End If
            Application.DoEvents()

            If encrypted Then
               Dim dlg As GetPasswordDialog = New GetPasswordDialog()
               Try
                  If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                     success = True
                     _password = dlg.Password
                  End If
               Finally
                  CType(dlg, IDisposable).Dispose()
               End Try
            Else
               success = True
            End If
         Finally
            CType(wait, IDisposable).Dispose()
         End Try

         Return success
      End Function

      Private Function CreateDocument() As PDFDocument
         _createDocumentLabel.Visible = True
         Application.DoEvents()

         Dim wait As WaitCursor = New WaitCursor()
         Try
            Dim document As PDFDocument = New PDFDocument(_fileName, _password)

            If String.IsNullOrEmpty(document.DocumentProperties.Creator) Then
               document.DocumentProperties.Creator = "LEADTOOLS PDFWriter"
            End If
            If String.IsNullOrEmpty(document.DocumentProperties.Producer) Then
               document.DocumentProperties.Producer = "LEAD Technologies, Inc."
            End If

            _createDocumentValueLabel.Visible = True
            _createDocumentValueLabel.Text = DemosGlobalization.GetResxString(Me.GetType(), "resx_Finished")
            Application.DoEvents()

            Return document
         Finally
            CType(wait, IDisposable).Dispose()
         End Try
      End Function
   End Class
End Namespace
