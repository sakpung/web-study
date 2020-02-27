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
   Partial Public Class ReadPDFDocumentControl : Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Private _stopReading As Boolean

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         If (Not DesignMode) Then
            _readDocumentStructureLabel.Visible = False
            _readDocumentStructureValueLabel.Visible = False
            _readObjectsLabel.Visible = False
            _readObjectsValueLabel.Visible = False
            _readObjectsProgressBar.Visible = False
            _stopButton.Visible = False
            _errorsGroupBox.Visible = False
            _errorsLabel.Visible = False
            _copyToClipboardButton.Visible = False
            _stopReading = False
         End If

         MyBase.OnLoad(e)
      End Sub

      Public Function Run(ByVal document As PDFDocument, ByVal parseDocumentStructureOptions As PDFParseDocumentStructureOptions, ByVal parsePagesOptions As PDFParsePagesOptions, ByVal parseChunks As Boolean) As Boolean
         ' - Read the document structure
         ReadDocumentStructure(document, parseDocumentStructureOptions)

         ' - Parse the document objects
         ParseObjects(document, parsePagesOptions, parseChunks)

         If _errorsListBox.Items.Count > 0 Then
            _errorsLabel.Visible = True
            _copyToClipboardButton.Visible = True
            Return False
         End If

         Return True
      End Function

      Private Sub ReadDocumentStructure(ByVal document As PDFDocument, ByVal parseDocumentStructureOptions As PDFParseDocumentStructureOptions)
         _readDocumentStructureLabel.Visible = True
         _readDocumentStructureValueLabel.Visible = True
         Application.DoEvents()

         Try
            If Not parseDocumentStructureOptions = PDFParseDocumentStructureOptions.None Then
               Dim wait As WaitCursor = New WaitCursor()
               Try
                  document.ParseDocumentStructure(parseDocumentStructureOptions)
                  _readDocumentStructureValueLabel.Text = DemosGlobalization.GetResxString(Me.GetType(), "resx_Finished")
               Finally
                  CType(wait, IDisposable).Dispose()
               End Try
            Else
               _readDocumentStructureValueLabel.Text = DemosGlobalization.GetResxString(Me.GetType(), "resx_Skipped")
            End If
         Catch ex As Exception
            _readDocumentStructureValueLabel.Text = DemosGlobalization.GetResxString(Me.GetType(), "resx_Error")
            AddError(DemosGlobalization.GetResxString(Me.GetType(), "resx_ReadingDocumentStructure"), ex)
         End Try

         Application.DoEvents()
      End Sub

      Private Sub ParseObjects(ByVal document As PDFDocument, ByVal parsePagesOptions As PDFParsePagesOptions, ByVal parseChunks As Boolean)
         If parsePagesOptions = PDFParsePagesOptions.None Then
            Return
         End If

         _readObjectsLabel.Visible = True

         Dim pageCount As Integer = document.Pages.Count

         Dim chunkSize As Integer

         If parseChunks Then
            _readObjectsValueLabel.Visible = False
            _readObjectsProgressBar.Visible = True
            _stopButton.Visible = True
            _readObjectsProgressBar.Minimum = 1
            _readObjectsProgressBar.Maximum = pageCount
            chunkSize = 50
         Else
            _readObjectsValueLabel.Visible = True
            _readObjectsProgressBar.Visible = False
            chunkSize = pageCount
            Application.DoEvents()
         End If

         Dim pagesLeft As Integer = pageCount

         Dim firstPageNumber As Integer = 1
         Do While pagesLeft > 0 AndAlso Not _stopReading
            Dim toRead As Integer = Math.Min(pagesLeft, chunkSize)
            If toRead > 0 Then
               If parseChunks Then
                  Application.DoEvents()
               End If

               Dim lastPageNumber As Integer = firstPageNumber + toRead - 1

               Try
                  If parseChunks Then
                     document.ParsePages(parsePagesOptions, firstPageNumber, lastPageNumber)
                  Else
                     Dim wait As WaitCursor = New WaitCursor()
                     Try
                        document.ParsePages(parsePagesOptions, firstPageNumber, lastPageNumber)
                     Finally
                        CType(wait, IDisposable).Dispose()
                     End Try
                  End If
               Catch ex As Exception
                  AddError(String.Format("{0} {1} {2} {3}", DemosGlobalization.GetResxString(Me.GetType(), "resx_ReadingPages"), firstPageNumber, DemosGlobalization.GetResxString(Me.GetType(), "resx_To"), lastPageNumber), ex)
               End Try

               pagesLeft -= toRead
               firstPageNumber += toRead

               If _readObjectsProgressBar.Visible Then
                  _readObjectsProgressBar.Value = firstPageNumber - 1
                  Application.DoEvents()
               End If
            End If
         Loop

         If (Not parseChunks) Then
            _readObjectsValueLabel.Text = DemosGlobalization.GetResxString(Me.GetType(), "resx_Finished")
            Application.DoEvents()
         End If
      End Sub

      Private Sub AddError(ByVal message As String, ByVal ex As Exception)
         If (Not _errorsGroupBox.Visible) Then
            _errorsGroupBox.Visible = True
         End If

         _errorsListBox.TopIndex = _errorsListBox.Items.Add(String.Format("{0}: {1}", message, ex.Message))
      End Sub

      Private Sub _stopButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _stopButton.Click
         _stopReading = True
      End Sub

      Private Sub _copyToClipboardButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _copyToClipboardButton.Click
         Dim sb As StringBuilder = New StringBuilder()
         Dim i As Integer = 0
         Do While i < _errorsListBox.Items.Count
            sb.AppendLine(_errorsListBox.Items(i).ToString())
            i += 1
         Loop

         Clipboard.SetText(sb.ToString(), TextDataFormat.Text)
      End Sub
   End Class
End Namespace
