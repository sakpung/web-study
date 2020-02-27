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

Imports Leadtools.Document.Viewer
Imports System

Partial Public Class DocumentViewerOptionsDialog
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Private _documentViewer As DocumentViewer
   Public Property DocumentViewer() As DocumentViewer
      Get
         Return _documentViewer
      End Get
      Set(value As DocumentViewer)
         _documentViewer = value
      End Set
   End Property

   Private _loadDocumentTimeoutMilliseconds As Integer
   Public Property LoadDocumentTimeoutMilliseconds() As Integer
      Get
         Return _loadDocumentTimeoutMilliseconds
      End Get
      Set
         _loadDocumentTimeoutMilliseconds = Value
      End Set
   End Property

   Private _maximumImagesPixelSize As Integer
   Public Property MaximumImagesPixelSize As Integer
      Get
         Return _maximumImagesPixelSize
      End Get
      Set
         _maximumImagesPixelSize = Value
      End Set
   End Property

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         Dim hasThumbnails As Boolean = (_documentViewer.Thumbnails IsNot Nothing)
         _thumbnailsOptionsGroupBox.Enabled = hasThumbnails
         _thumbnailsUseGridsCheckBox.Checked = hasThumbnails AndAlso _documentViewer.Thumbnails.UseGrids
         If hasThumbnails Then
            _thumbnailsGridPixelSizeTextBox.Text = _documentViewer.Thumbnails.GridPixelSize.ToString()
         Else
            _thumbnailsGridPixelSizeTextBox.Text = [String].Empty
         End If

         _thumbnailsUseGridsCheckBox_CheckedChanged(Nothing, Nothing)

         _loadDocumentTimeoutTextBox.Text = _loadDocumentTimeoutMilliseconds.ToString()
         _maximumImagesPixelSizeTextBox.Text = _maximumImagesPixelSize.ToString()
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _thumbnailsUseGridsCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _thumbnailsUseGridsCheckBox.CheckedChanged
      If _documentViewer.Thumbnails Is Nothing Then
         Return
      End If

      _thumbnailsGridPixelSizeLabel.Enabled = _thumbnailsUseGridsCheckBox.Checked
      _thumbnailsGridPixelSizeTextBox.Enabled = _thumbnailsUseGridsCheckBox.Checked
   End Sub

   Private Sub _okButton_Click(sender As Object, e As EventArgs) Handles _okButton.Click
      Dim loadDocumentTimeout As Integer
      If Not Integer.TryParse(_loadDocumentTimeoutTextBox.Text, loadDocumentTimeout) OrElse loadDocumentTimeout < 0 Then
         MessageBox.Show(Me, "Must be a value greater or equal to 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         _loadDocumentTimeoutTextBox.SelectAll()
         _loadDocumentTimeoutTextBox.Focus()
         DialogResult = DialogResult.None
         Return
      End If

      Dim MaximumImagesPixelSize As Integer
      If Not Integer.TryParse(_maximumImagesPixelSizeTextBox.Text, MaximumImagesPixelSize) OrElse MaximumImagesPixelSize < 0 Then
         MessageBox.Show(Me, "Must be a value greater or equal to 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         _maximumImagesPixelSizeTextBox.SelectAll()
         _maximumImagesPixelSizeTextBox.Focus()
         DialogResult = DialogResult.None
         Return
      End If

      Dim hasThumbnails As Boolean = (_documentViewer.Thumbnails IsNot Nothing)
      If hasThumbnails Then
         Dim useGrid As Boolean = _thumbnailsUseGridsCheckBox.Checked
         If useGrid Then
            Dim gridPixelSize As Integer
            If Not Integer.TryParse(_thumbnailsGridPixelSizeTextBox.Text, gridPixelSize) OrElse gridPixelSize < 1 OrElse gridPixelSize > 4000 Then
               MessageBox.Show(Me, "Must be a value greater than 0 and less than or equal to 4000", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               _thumbnailsGridPixelSizeTextBox.SelectAll()
               _thumbnailsGridPixelSizeTextBox.Focus()
               DialogResult = DialogResult.None
               Return
            End If

            _documentViewer.Thumbnails.GridPixelSize = gridPixelSize
         End If

         _documentViewer.Thumbnails.UseGrids = useGrid
      End If

      Me.LoadDocumentTimeoutMilliseconds = loadDocumentTimeout
      Me.MaximumImagesPixelSize = MaximumImagesPixelSize
   End Sub
End Class
