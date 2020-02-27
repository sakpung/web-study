' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Document
Imports System

Partial Public Class OpenDocumentFileDialog
   Inherits Form
   Public Property DocumentFileName() As String
      Get
         Return m_DocumentFileName
      End Get
      Set(value As String)
         m_DocumentFileName = value
      End Set
   End Property
   Private m_DocumentFileName As String
   Public Property AnnotationsFileName() As String
      Get
         Return m_AnnotationsFileName
      End Get
      Set(value As String)
         m_AnnotationsFileName = value
      End Set
   End Property
   Private m_AnnotationsFileName As String
   Public Property LoadEmbeddedAnnotations() As Boolean
      Get
         Return m_LoadEmbeddedAnnotations
      End Get
      Set(value As Boolean)
         m_LoadEmbeddedAnnotations = value
      End Set
   End Property
   Private m_LoadEmbeddedAnnotations As Boolean

   Public Property FirstPageNumber As Integer
      Get
         Return _firstPageNumber
      End Get
      Set(value As Integer)
         _firstPageNumber = value
      End Set
   End Property
   Private _firstPageNumber As Integer

   Public Property LastPageNumber As Integer
      Get
         Return _lastPageNumber
      End Get
      Set(value As Integer)
         _lastPageNumber = value
      End Set
   End Property
   Private _lastPageNumber As Integer

   Public Sub New()
      InitializeComponent()
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         _documentLocationTextBox.Text = If(Not String.IsNullOrEmpty(Me.DocumentFileName), Me.DocumentFileName.Trim(), String.Empty)
         _annotationsLocationTextBox.Text = If(Not String.IsNullOrEmpty(Me.AnnotationsFileName), Me.AnnotationsFileName.Trim(), String.Empty)

         If Me.AnnotationsFileName IsNot Nothing Then
            _externalAnnotationsRadioButton.Checked = True
         ElseIf Me.LoadEmbeddedAnnotations Then
            _embeddedAnnotationsRadioButton.Checked = True
         Else
            _noAnnotationsRadioButton.Checked = True
         End If

         _firstPageNumber = Me.FirstPageNumber
         _lastPageNumber = Me.LastPageNumber
         If _firstPageNumber = 0 Then
            _firstPageNumber = 1
         End If
         If _lastPageNumber = 0 Then
            _lastPageNumber = -1
         End If

         UpdateUIState()
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _documentLocationBrowseButton_Click(sender As Object, e As EventArgs)
      Dim dlg As OpenFileDialog = New OpenFileDialog()
      dlg.Filter = "All Files|*.*"
      dlg.Title = "Select Document File Name"
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         _documentLocationTextBox.Text = dlg.FileName
         _annotationsLocationTextBox.Text = String.Empty

         ' Check if there is a corresponding annotation file
         If File.Exists(dlg.FileName) Then
            Dim annotationFileName As String = Path.ChangeExtension(dlg.FileName, "xml")
            If File.Exists(annotationFileName) Then
               _annotationsLocationTextBox.Text = annotationFileName
               _externalAnnotationsRadioButton.Checked = True
            End If
         End If

         If _externalAnnotationsRadioButton.Checked AndAlso String.IsNullOrEmpty(_annotationsLocationTextBox.Text) Then
            _embeddedAnnotationsRadioButton.Checked = True
         End If

         _firstPageNumber = 1
         _lastPageNumber = -1

         UpdateUIState()
      End If
   End Sub

   Private Sub _annotationsLocationBrowseButton_Click(sender As Object, e As EventArgs) Handles _annotationsLocationBrowseButton.Click
      Using dlg As OpenFileDialog = New OpenFileDialog()
         dlg.Filter = "Annotation Files|*.xml|All Files|*.*"
         dlg.Title = "Select Annotations File Name"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _annotationsLocationTextBox.Text = dlg.FileName
            UpdateUIState()
         End If
      End Using
   End Sub

   Private Sub _locationTextBox_TextChanged(sender As Object, e As EventArgs) Handles _documentLocationTextBox.TextChanged, _annotationsLocationTextBox.TextChanged
      UpdateUIState()
   End Sub

   Private Sub _annotationsRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles _externalAnnotationsRadioButton.CheckedChanged, _embeddedAnnotationsRadioButton.CheckedChanged, _noAnnotationsRadioButton.CheckedChanged
      UpdateUIState()
   End Sub

   Private Sub UpdateUIState()
      Dim externalAnnotations As Boolean = _externalAnnotationsRadioButton.Checked

      _externalAnnotationsLocationLabel.Enabled = externalAnnotations
      _annotationsLocationTextBox.Enabled = externalAnnotations
      _annotationsLocationBrowseButton.Enabled = externalAnnotations

      Dim enableOk As Boolean = Not String.IsNullOrEmpty(_documentLocationTextBox.Text) AndAlso (Not externalAnnotations OrElse Not String.IsNullOrEmpty(_annotationsLocationTextBox.Text))

      Dim pagesText As String

      If _firstPageNumber = 1 AndAlso _lastPageNumber = -1 Then
         pagesText = "All pages"
      Else
         If _lastPageNumber = -1 Then
            pagesText = String.Format("From {0} to last page", _firstPageNumber)
         Else
            pagesText = String.Format("From {0} to {1}", _firstPageNumber, _lastPageNumber)
         End If
      End If

      _pagesLabel.Text = pagesText

      _okButton.Enabled = enableOk
   End Sub

   Private Sub _pagesButton_Click(ByVal sender As Object, ByVal e As EventArgs)
      Using dlg As PagesDialog = New PagesDialog()
         dlg.SinglePageMode = False
         dlg.ShowCurrentPageNumber = False
         dlg.Operation = "load document"
         dlg.PageCount = -1
         dlg.FirstPageNumber = _firstPageNumber
         dlg.LastPageNumber = _lastPageNumber
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _firstPageNumber = dlg.FirstPageNumber
            _lastPageNumber = dlg.LastPageNumber
            UpdateUIState()
         End If
      End Using
   End Sub

   Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
      Me.DocumentFileName = _documentLocationTextBox.Text.Trim()
      Me.FirstPageNumber = _firstPageNumber
      Me.LastPageNumber = _lastPageNumber

      If _noAnnotationsRadioButton.Checked Then
         Me.AnnotationsFileName = Nothing
         Me.LoadEmbeddedAnnotations = False
      ElseIf _embeddedAnnotationsRadioButton.Checked Then
         Me.AnnotationsFileName = Nothing
         Me.LoadEmbeddedAnnotations = True
      Else
         Me.AnnotationsFileName = _annotationsLocationTextBox.Text.Trim()
         Me.LoadEmbeddedAnnotations = False
      End If
   End Sub
End Class
