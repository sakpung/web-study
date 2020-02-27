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

Imports Leadtools.Document
Imports System

Partial Public Class OpenDocumentUrlDialog
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Property DocumentUrl() As String
      Get
         Return m_DocumentUrl
      End Get
      Set(value As String)
         m_DocumentUrl = value
      End Set
   End Property
   Private m_DocumentUrl As String
   Public Property AnnotationsUrl() As String
      Get
         Return m_AnnotationsUrl
      End Get
      Set(value As String)
         m_AnnotationsUrl = value
      End Set
   End Property
   Private m_AnnotationsUrl As String
   Public Property LoadEmbeddedAnnotations() As Boolean
      Get
         Return m_LoadEmbeddedAnnotations
      End Get
      Set(value As Boolean)
         m_LoadEmbeddedAnnotations = value
      End Set
   End Property
   Private m_LoadEmbeddedAnnotations As Boolean

   Public Property FirstPageNumber() As Integer
      Get
         Return _firstPageNumber
      End Get
      Set(value As Integer)
         _firstPageNumber = value
      End Set
   End Property
   Private _firstPageNumber As Integer

   Public Property LastPageNumber() As Integer
      Get
         Return _lastPageNumber
      End Get
      Set(value As Integer)
         _lastPageNumber = value
      End Set
   End Property
   Private _lastPageNumber As Integer

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         _documentLocationTextBox.Text = If(Not String.IsNullOrEmpty(Me.DocumentUrl), Me.DocumentUrl.Trim(), String.Empty)
         _annotationsLocationTextBox.Text = If(Not String.IsNullOrEmpty(Me.AnnotationsUrl), Me.AnnotationsUrl.Trim(), String.Empty)

         If Me.AnnotationsUrl IsNot Nothing Then
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
         _progressBar.Visible = False
      End If

      MyBase.OnLoad(e)
   End Sub

   Protected Overrides Sub OnFormClosing(e As FormClosingEventArgs)
      e.Cancel = _isLoading
      MyBase.OnFormClosing(e)
   End Sub

   Private Sub _locationTextBox_TextChanged(sender As Object, e As EventArgs) Handles _documentLocationTextBox.TextChanged, _annotationsLocationTextBox.TextChanged
      UpdateUIState()
   End Sub

   Private Sub _annotationsRadioButton_CheckedChanged(sender As Object, e As EventArgs) Handles _embeddedAnnotationsRadioButton.TextChanged, _externalAnnotationsRadioButton.TextChanged, _noAnnotationsRadioButton.TextChanged
      UpdateUIState()
   End Sub

   Private Sub UpdateUIState()
      Dim externalAnnotations As Boolean = _externalAnnotationsRadioButton.Checked

      _externalAnnotationsLocationLabel.Enabled = externalAnnotations
      _annotationsLocationTextBox.Enabled = externalAnnotations

      Dim enableLoad As Boolean = Not String.IsNullOrEmpty(_documentLocationTextBox.Text) AndAlso (Not externalAnnotations OrElse Not String.IsNullOrEmpty(_annotationsLocationTextBox.Text))
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
      _loadButton.Enabled = enableLoad
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

   Private _isLoading As Boolean

   Private Sub _loadButton_Click(sender As Object, e As EventArgs)
      Dim documentUri As Uri
      Dim annotationsUri As Uri
      Dim loadEmbeddedAnnotations As Boolean

      ' Get the URI
      Try
         documentUri = New Uri(_documentLocationTextBox.Text.Trim())

         If _noAnnotationsRadioButton.Checked Then
            annotationsUri = Nothing
            loadEmbeddedAnnotations = False
         ElseIf _embeddedAnnotationsRadioButton.Checked Then
            annotationsUri = Nothing
            loadEmbeddedAnnotations = True
         Else
            annotationsUri = New Uri(_annotationsLocationTextBox.Text.Trim())
            loadEmbeddedAnnotations = False
         End If
      Catch ex As Exception
         Helper.ShowError(Me, ex)
         Return
      End Try

      Me.FirstPageNumber = _firstPageNumber
      Me.LastPageNumber = _lastPageNumber

      _isCancelPending = False
      _isLoading = False
      Dim mainForm As MainForm = TryCast(Me.Owner, MainForm)
      If mainForm.LoadDocumentFromUri(Me, documentUri, FirstPageNumber, LastPageNumber, annotationsUri, loadEmbeddedAnnotations) Then
         ' Means the main form has started loading the document
         _isLoading = True
         _documentLocationGroupBox.Enabled = False
         _annotationsGroupBox.Enabled = False
         _progressBar.Visible = True
      End If
   End Sub

   Public Sub SetProgress(percentage As Integer)
      _progressBar.Value = percentage
   End Sub

   Public Sub Finish(closeDialog As Boolean)
      _isLoading = False

      If closeDialog Then
         DialogResult = DialogResult.OK
         Close()
      Else
         _documentLocationGroupBox.Enabled = True
         _annotationsGroupBox.Enabled = True
         _progressBar.Visible = False
      End If
   End Sub

   Private _isCancelPending As Boolean
   Public ReadOnly Property IsCancelPending() As Boolean
      Get
         Return _isCancelPending
      End Get
   End Property

   Private Sub _cancelButton_Click(sender As Object, e As EventArgs) Handles _cancelButton.Click
      If _isLoading Then
         ' Means we are loading, stop this dialog from closing and let main form knows
         DialogResult = DialogResult.None
         _isCancelPending = True
      End If
   End Sub
End Class
