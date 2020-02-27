' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Ocr
Imports Leadtools.Document.Writer
Imports System

<DefaultEvent("SelectedFormatChanged")> _
Partial Public Class DocumentFormatSelector
   Inherits UserControl
   Private _ocrEngineType As OcrEngineType
   Private _documentWriter As DocumentWriter
   Private _formatHasOptions As Boolean = True
   Private _totalPages As Integer

   Public Sub New()
      InitializeComponent()

      DoResize()
   End Sub

   Protected Overrides Sub OnResize(e As EventArgs)
      DoResize()

      MyBase.OnResize(e)
   End Sub

   Private Sub DoResize()
      SuspendLayout()

      Dim maxHeight As Integer = Math.Max(_formatComboBox.Height, _formatOptionsButton.Height)
      Const dx As Integer = 2

      Height = maxHeight
      _formatComboBox.Location = New Point(0, CInt((ClientSize.Height - _formatComboBox.Height) / 2))
      _formatComboBox.Width = ClientSize.Width - _formatOptionsButton.Width - dx * 2

      _formatOptionsButton.Location = New Point(ClientSize.Width - _formatOptionsButton.Width - dx, CInt((ClientSize.Height - _formatOptionsButton.Height) / 2))

      ResumeLayout()
   End Sub

   Private Structure DocumentFormatItem
      Public Format As DocumentFormat
      Private _name As String

      Public Sub New(f As DocumentFormat, n As String)
         Format = f
         _name = n
      End Sub

      Public Overrides Function ToString() As String
         Return _name
      End Function
   End Structure

   Public Sub SetDocumentWriter(docWriter As DocumentWriter, showLtdFormat As Boolean)
      _documentWriter = docWriter

      ' This is the order of importance, show these first then the rest as they come along
      Dim importantFormats As DocumentFormat() = {DocumentFormat.Pdf, DocumentFormat.Docx, DocumentFormat.Rtf, DocumentFormat.Text, DocumentFormat.Doc, DocumentFormat.Xls, _
       DocumentFormat.Html}

      Dim formatsToAdd As New List(Of DocumentFormat)()

      Dim a As Array = [Enum].GetValues(GetType(DocumentFormat))
      Dim allFormats As New List(Of DocumentFormat)()
      For Each format As DocumentFormat In a
         allFormats.Add(format)
      Next

      ' Add important once first:
      For Each format As DocumentFormat In importantFormats
         formatsToAdd.Add(format)
         allFormats.Remove(format)
      Next

      ' Add rest
      formatsToAdd.AddRange(allFormats)

      ' Add rest
      For Each format As DocumentFormat In formatsToAdd
         Dim addItem As Boolean = True

         If format = DocumentFormat.User Then
            addItem = False
         ElseIf format = DocumentFormat.Ltd AndAlso Not showLtdFormat Then
            addItem = False
         End If

         If addItem Then
            Dim name As String = String.Format("{0} ({1})", DocumentWriter.GetFormatFriendlyName(format), DocumentWriter.GetFormatFileExtension(format).ToUpperInvariant())
            Dim item As New DocumentFormatItem(format, name)
            _formatComboBox.Items.Add(item)

            If format = DocumentFormat.Pdf Then
               _formatComboBox.SelectedItem = item
            End If
         End If
      Next

      If _formatComboBox.SelectedIndex = -1 AndAlso _formatComboBox.Items.Count > 0 Then
         _formatComboBox.SelectedIndex = 0
      End If

      Dim pdfOptions As PdfDocumentOptions = TryCast(_documentWriter.GetOptions(DocumentFormat.Pdf), PdfDocumentOptions)
      If (String.IsNullOrEmpty(pdfOptions.Creator)) Then
         pdfOptions.Creator = "LEADTOOLS PDFWriter"
      End If
      If (String.IsNullOrEmpty(pdfOptions.Producer)) Then
         pdfOptions.Producer = "LEAD Technologies, Inc."
      End If
      _documentWriter.SetOptions(DocumentFormat.Pdf, pdfOptions)
   End Sub

   Public Sub SetOcrEngineType(ocrEngineType As OcrEngineType)
      _ocrEngineType = ocrEngineType
   End Sub

   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public Property SelectedFormat() As DocumentFormat
      Get
         If _formatComboBox.SelectedIndex <> -1 Then
            Dim item As DocumentFormatItem = CType(_formatComboBox.SelectedItem, DocumentFormatItem)
            Return item.Format
         Else
            Return DocumentFormat.Pdf
         End If
      End Get
      Set(value As DocumentFormat)
         For Each item As DocumentFormatItem In _formatComboBox.Items
            If item.Format = value Then
               _formatComboBox.SelectedItem = item
               Return
            End If
         Next
      End Set
   End Property

   Public Property FormatHasOptions() As Boolean
      Get
         Return _formatHasOptions
      End Get
      Set(value As Boolean)
         _formatHasOptions = value
      End Set
   End Property

   Public Property TotalPages() As Integer
      Get
         Return _totalPages
      End Get
      Set(value As Integer)
         _totalPages = value
      End Set
   End Property

   Private Sub _formatOptionsButton_Click(sender As Object, e As EventArgs) Handles _formatOptionsButton.Click
      If _documentWriter Is Nothing OrElse _formatComboBox.SelectedIndex = -1 Then
         Return
      End If

      Dim item As DocumentFormatItem = CType(_formatComboBox.SelectedItem, DocumentFormatItem)

      Using dlg As New DocumentFormatOptionsDialog(_ocrEngineType, _documentWriter, item.Format, _totalPages)
         dlg.ShowDialog(Me)
      End Using
   End Sub

   Public Event SelectedFormatChanged As EventHandler(Of EventArgs)

   Private Sub _formatComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _formatComboBox.SelectedIndexChanged
      RaiseEvent SelectedFormatChanged(Me, EventArgs.Empty)

      _formatOptionsButton.Enabled = _formatHasOptions
   End Sub
End Class
