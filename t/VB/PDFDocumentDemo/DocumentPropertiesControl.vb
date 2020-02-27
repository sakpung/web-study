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

Namespace PDFDocumentDemo
   Partial Public Class DocumentPropertiesControl : Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Private Shared Function FixDate(ByVal picker As DateTimePicker, ByVal dt As DateTime) As DateTime
         If dt < picker.MinDate Then
            Return picker.MinDate
         End If
         If dt > picker.MaxDate Then
            Return picker.MaxDate
         End If
         Return dt
      End Function

      Public Sub SetDocumentProperties(ByVal pdfDocproperties As PDFDocumentProperties, [ReadOnly] As Boolean)
         _titleTextBox.Text = pdfDocproperties.Title
         _authorTextBox.Text = pdfDocproperties.Author
         _subjectTextBox.Text = pdfDocproperties.Subject
         _keywordsTextBox.Text = pdfDocproperties.Keywords
         _creatorTextBox.Text = pdfDocproperties.Creator
         _producerTextBox.Text = pdfDocproperties.Producer
         _createdDateTimePicker.Value = FixDate(_createdDateTimePicker, pdfDocproperties.Created)
         _createdTextBox.Text = _createdDateTimePicker.Value.ToString(_createdDateTimePicker.CustomFormat)
         _modifiedDateTimePicker.Value = FixDate(_modifiedDateTimePicker, pdfDocproperties.Modified)
         _modifiedTextBox.Text = _modifiedDateTimePicker.Value.ToString(_modifiedDateTimePicker.CustomFormat)

         If [ReadOnly] Then
            _titleTextBox.ReadOnly = True
            _authorTextBox.ReadOnly = True
            _subjectTextBox.ReadOnly = True
            _keywordsTextBox.ReadOnly = True
            _creatorTextBox.ReadOnly = True
            _producerTextBox.ReadOnly = True
            _createdTextBox.ReadOnly = True
            _createdDateTimePicker.Visible = False
            _modifiedTextBox.ReadOnly = True
            _modifiedDateTimePicker.Visible = False
         Else
            _createdTextBox.Visible = False
            _modifiedTextBox.Visible = False
         End If
      End Sub

      Public Sub UpdateDocumentProperties(ByVal pdfDocproperties As PDFDocumentProperties)
         pdfDocproperties.Title = _titleTextBox.Text
         pdfDocproperties.Author = _authorTextBox.Text
         pdfDocproperties.Subject = _subjectTextBox.Text
         pdfDocproperties.Keywords = _keywordsTextBox.Text
         pdfDocproperties.Creator = _creatorTextBox.Text
         pdfDocproperties.Producer = _producerTextBox.Text
         pdfDocproperties.Created = _createdDateTimePicker.Value
         pdfDocproperties.Modified = _modifiedDateTimePicker.Value
      End Sub
   End Class
End Namespace
