' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Windows.Forms

Imports Leadtools.Demos
Imports Leadtools.Document.Viewer
Imports System

' Contains the preferences menu and toolbar part of the viewer
Partial Public Class MainForm
   Private Sub _preferencesToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs)
      _autoGetTextToolStripMenuItem.Checked = _preferences.AutoGetText
      _showOperationsToolStripMenuItem.Checked = _preferences.ShowOperations
      _showTextIndicatorsToolStripMenuItem.Checked = _preferences.ShowTextIndicators
   End Sub

   Private Sub _userNameToolStripMenuItem_Click(sender As Object, e As EventArgs)
      Using dlg As InputDialog = New InputDialog()
         dlg.Text = "User Name"
         dlg.ValueTitle = Nothing
         dlg.ValueDescription1 = "Enter user name for modifying annotations in the document"
         dlg.Value = _documentViewer.UserName
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _documentViewer.UserName = dlg.Value
         End If
      End Using
   End Sub

   Private Sub _cacheDirectoryToolStripMenuItem_Click(sender As Object, e As EventArgs)
      Using dlg As FolderBrowserDialog = New FolderBrowserDialog()
         dlg.RootFolder = Environment.SpecialFolder.Desktop
         ' so we can set the initial folder
         dlg.SelectedPath = _preferences.CacheDir
         dlg.ShowNewFolderButton = True
         dlg.Description = "Select the directory to use for caching the documents data"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _preferences.CacheDir = dlg.SelectedPath
            Helper.ShowInformation(Me, "Cache directory has been updated. You need to re-start this demo to use the new value")
         End If
      End Using
   End Sub

   Private Sub _autoGetTextToolStripMenuItem_Click(sender As Object, e As EventArgs)
      _preferences.AutoGetText = Not _preferences.AutoGetText
      If _documentViewer IsNot Nothing Then
         _documentViewer.Text.AutoGetText = _preferences.AutoGetText
      End If
   End Sub

   Private Sub _documentTextOptionsToolStripMenuItem_Click(sender As Object, e As EventArgs)
      Using dlg As New DocumentTextOptionsDialog()
         dlg.ImagesRecognitionMode = _imagesRecognitionMode
         dlg.TextExtractionMode = _textExtractionMode
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _imagesRecognitionMode = dlg.ImagesRecognitionMode
            _textExtractionMode = dlg.TextExtractionMode

            If _documentViewer IsNot Nothing AndAlso _documentViewer.Document IsNot Nothing Then
               _documentViewer.Document.Text.ImagesRecognitionMode = _imagesRecognitionMode
               _documentViewer.Document.Text.TextExtractionMode = _textExtractionMode
            End If
         End If
      End Using
   End Sub

   Private Sub _showTextIndicatorsToolStripMenuItem_Click(sender As Object, e As EventArgs)
      _preferences.ShowTextIndicators = Not _preferences.ShowTextIndicators
      UpdateShowTextIndicators()
   End Sub

   Private Sub _showOperationsToolStripMenuItem_Click(sender As Object, e As EventArgs)
      _preferences.ShowOperations = Not _preferences.ShowOperations
      UpdateShowOperation()
   End Sub

   Private Sub _diagnosticsToolStripMenuItem_Click(sender As Object, e As EventArgs)
      Using dlg As ObjectPropertiesDialog = New ObjectPropertiesDialog()
         dlg.Text = "Diagnostics"
         dlg.PropertyGrid.ToolbarVisible = False
         dlg.PropertyGrid.PropertySort = PropertySort.Alphabetical
         dlg.PropertyGrid.SelectedObject = _documentViewer.Diagnostics
         dlg.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _documentViewerOptionsToolStripMenuItem_Click(sender As Object, e As EventArgs)
      Using dlg As DocumentViewerOptionsDialog = New DocumentViewerOptionsDialog()
         dlg.LoadDocumentTimeoutMilliseconds = _loadDocumentTimeoutMilliseconds
         dlg.MaximumImagesPixelSize = _maximumImagePixelSize
         dlg.DocumentViewer = _documentViewer
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _loadDocumentTimeoutMilliseconds = dlg.LoadDocumentTimeoutMilliseconds
            _maximumImagePixelSize = dlg.MaximumImagesPixelSize
         End If
      End Using
   End Sub
End Class
