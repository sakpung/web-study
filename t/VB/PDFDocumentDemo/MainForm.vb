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
Imports System.IO

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Pdf
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Controls
Imports PDFDocumentDemo.PDFDocumentDemo.Annotations
Imports System
Imports PDFDocumentDemo.Leadtools.Demos
Imports Leadtools.Demos.Dialogs

Namespace PDFDocumentDemo
   Partial Public Class MainForm
      Inherits Form
      ' The RasterCodecs objects to use when loading the images
      Private _rasterCodecs As RasterCodecs
      ' Current demo options
      Private _demoOptions As DemoOptions = DemoOptions.[Default]
      ' The current document
      Private _document As PDFDocument
      ' Current annotations
      Private _documentAnnotations As DocumentAnnotations
      ' Current page number
      Private _currentPageNumber As Integer
      ' This is the words for each page
      Private _documentText As Dictionary(Of Integer, MyWord())
      ' These are the highlighted words in each page
      Private _selectedText As Dictionary(Of Integer, MyWord())
      ' Helper class for "find" text
      Private _findTextHelper As FindTextHelper

      Public Sub New()
         InitializeComponent()

         Messager.Caption = "PDF Document VB Demo"
         Text = Messager.Caption
      End Sub

#Region "UI"
      Protected Overrides Sub OnLoad(e As EventArgs)
         If Not DesignMode Then
            BeginInvoke(New MethodInvoker(AddressOf Startup))
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Sub Startup()
         Try
            If Not Init() Then
               Close()
               Return
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            Close()
         End Try
      End Sub

      Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
         CleanUp()

         MyBase.OnFormClosed(e)
      End Sub

      Private Sub _openToolStripButton_Click(sender As Object, e As EventArgs) Handles _openToolStripButton.Click
         OpenDocument()
      End Sub

      Private Sub _findToolStripTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _findToolStripTextBox.KeyPress
         If _document Is Nothing OrElse _documentText Is Nothing OrElse String.IsNullOrEmpty(_findToolStripTextBox.Text) Then
            Return
         End If

         If e.KeyChar = CChar(Microsoft.VisualBasic.ChrW(Keys.Return)) Then
            FindText(True)
         End If
      End Sub

      Private Sub _findToolStripTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles _findToolStripTextBox.KeyDown
         If _document Is Nothing OrElse _documentText Is Nothing OrElse String.IsNullOrEmpty(_findToolStripTextBox.Text) Then
            Return
         End If

         If e.KeyCode = Keys.F3 Then
            FindText(e.Modifiers <> Keys.Shift)
         End If
      End Sub

      Private Sub _findPreviousToolStripButton_Click(sender As Object, e As EventArgs) Handles _findPreviousToolStripButton.Click
         If _document Is Nothing OrElse _documentText Is Nothing OrElse String.IsNullOrEmpty(_findToolStripTextBox.Text) Then
            Return
         End If

         FindText(False)
      End Sub

      Private Sub _findNextToolStripButton_Click(sender As Object, e As EventArgs) Handles _findNextToolStripButton.Click
         If _document Is Nothing OrElse _documentText Is Nothing OrElse String.IsNullOrEmpty(_findToolStripTextBox.Text) Then
            Return
         End If

         FindText(True)
      End Sub

      Private Sub _fileToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _fileToolStripMenuItem.DropDownOpening
         _saveToolStripMenuItem.Visible = _document IsNot Nothing
         _saveAsToolStripMenuItem.Visible = _document IsNot Nothing
         _closeToolStripMenuItem.Visible = _document IsNot Nothing
         _fileSep1ToolStripMenuItem.Visible = _document IsNot Nothing
         _exportTextToolStripMenuItem.Visible = _document IsNot Nothing
         _exportTextToolStripMenuItem.Enabled = _documentText IsNot Nothing
         _propertiesToolStripMenuItem.Visible = _document IsNot Nothing
         _fontsToolStripMenuItem.Visible = _document IsNot Nothing
         _fileSep2ToolStripMenuItem.Visible = _document IsNot Nothing
      End Sub

      Private Sub _openToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _openToolStripMenuItem.Click
         OpenDocument()
      End Sub


      Private Sub _saveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _saveToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         ' Check if the file exist and is accessible

         Dim fileName As String = _document.FileName
         Dim isFileAccessible As Boolean = False

         ' Try to open it
         Try
            Using file__1 As FileStream = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None)
               isFileAccessible = True
            End Using
         Catch
            isFileAccessible = False
         End Try

         ' If the file is not accessible, then offer to do SaveAs
         If Not isFileAccessible Then
            Dim message As String = "The file:\n" & fileName & "\nIs not accessible at this time. Do you want to save the file using another name?"
            If Messager.ShowQuestion(Me, message, MessageBoxButtons.YesNo) = DialogResult.Yes Then
               _saveAsToolStripMenuItem.PerformClick()
            End If
         Else
            ' Otherwise into the original file
            SaveDocument(fileName)
         End If
      End Sub

      Private Sub _saveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _saveAsToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         Using dlg As New SaveFileDialog()
            dlg.Filter = "PDF files|*.pdf|All files|*.*"
            dlg.DefaultExt = "pdf"
            dlg.FileName = Path.GetFileName(_document.FileName)

            If dlg.ShowDialog(Me) = DialogResult.OK Then
               SaveDocument(dlg.FileName)
            End If
         End Using
      End Sub

      Private Sub _closeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _closeToolStripMenuItem.Click
         CloseDocument()
      End Sub

      Private Sub _exportTextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _exportTextToolStripMenuItem.Click
         If _document Is Nothing OrElse _documentText Is Nothing Then
            Return
         End If

         ExportDocumentText()
      End Sub

      Private Sub _propertiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _propertiesToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         ShowDocumentProperties()
      End Sub

      Private Sub _fontsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _fontsToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         Using dlg As New PDFFontsDialog(_document)
            dlg.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _exitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _exitToolStripMenuItem.Click
         Close()
      End Sub

      Private Sub _editToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _editToolStripMenuItem2.DropDownOpening
         If _document Is Nothing Then
            Return
         End If

         ' These with text
         Dim textSelected As Boolean = IsTextSelected
         _copyToolStripMenuItem.Enabled = textSelected
         _selectAllToolStripMenuItem.Enabled = _documentText IsNot Nothing
         _clearSelectionToolStripMenuItem.Enabled = textSelected
         _findToolStripMenuItem.Enabled = _documentText IsNot Nothing
         _findNextToolStripMenuItem.Enabled = _documentText IsNot Nothing AndAlso Not String.IsNullOrEmpty(_findToolStripTextBox.Text)
         _findPreviousToolStripMenuItem.Enabled = _documentText IsNot Nothing AndAlso Not String.IsNullOrEmpty(_findToolStripTextBox.Text)
      End Sub

      Private Sub _copyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _copyToolStripMenuItem.Click
         If _document Is Nothing OrElse _documentText Is Nothing OrElse _selectedText(_currentPageNumber) Is Nothing OrElse _selectedText(_currentPageNumber).Length = 0 Then
            Return
         End If

         CopySelectedText()
      End Sub

      Private Sub _selectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _selectAllToolStripMenuItem.Click
         If _document Is Nothing OrElse _documentText Is Nothing Then
            Return
         End If

         SelectAllText()
      End Sub

      Private Sub _clearSelectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _clearSelectionToolStripMenuItem.Click
         If _document Is Nothing OrElse _documentText Is Nothing Then
            Return
         End If

         ClearTextSelection()
      End Sub

      Private Sub _findToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _findToolStripMenuItem.Click
         If _document Is Nothing OrElse _documentText Is Nothing Then
            Return
         End If

         _findToolStripTextBox.Focus()
         _findToolStripTextBox.SelectAll()
      End Sub

      Private Sub _findNextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _findNextToolStripMenuItem.Click
         If _document Is Nothing OrElse _documentText Is Nothing OrElse String.IsNullOrEmpty(_findToolStripTextBox.Text) Then
            Return
         End If

         FindText(True)
      End Sub

      Private Sub _findPreviousToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _findPreviousToolStripMenuItem.Click
         If _document Is Nothing OrElse _documentText Is Nothing OrElse String.IsNullOrEmpty(_findToolStripTextBox.Text) Then
            Return
         End If

         FindText(False)
      End Sub

      Private Sub _viewToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _viewToolStripMenuItem.DropDownOpening
         If _document Is Nothing Then
            Return
         End If

         _fitWidthToolStripMenuItem.Checked = _viewerControl.RasterImageViewer.SizeMode = ControlSizeMode.FitWidth
         _fitPageToolStripMenuItem.Checked = _viewerControl.RasterImageViewer.SizeMode = ControlSizeMode.FitAlways
         _thumbnailsToolStripMenuItem.Checked = _pagesControl.ShowThumbnails
         _bookmarksToolStripMenuItem.Checked = _pagesControl.ShowBookmarks
         _signaturesToolStripMenuItem.Checked = _pagesControl.ShowSignatures
         _highlightObjectsToolStripMenuItem.Checked = _viewerControl.HighlightObjects

         _thumbnailsToolStripMenuItem.Visible = _pagesControl.Visible
         _bookmarksToolStripMenuItem.Visible = _pagesControl.Visible
         _signaturesToolStripMenuItem.Visible = _pagesControl.Visible
         _viewSep3ToolStripMenuItem.Visible = _pagesControl.Visible
      End Sub

      Private Sub _zoomOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _zoomOutToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         _viewerControl.ZoomViewer(True)
      End Sub

      Private Sub _zoomInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _zoomInToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         _viewerControl.ZoomViewer(False)
      End Sub

      Private Sub _fitWidthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _fitWidthToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         _viewerControl.FitPage(True)
      End Sub

      Private Sub _fitPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _fitPageToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         _viewerControl.FitPage(False)
      End Sub

      Private Sub _thumbnailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _thumbnailsToolStripMenuItem.Click
         _pagesControl.SetActiveTab(True, False, False)
      End Sub

      Private Sub _bookmarksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _bookmarksToolStripMenuItem.Click
         _pagesControl.SetActiveTab(False, True, False)
      End Sub

      Private Sub _signaturesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _signaturesToolStripMenuItem.Click
         _pagesControl.SetActiveTab(False, False, True)
      End Sub

      Private Sub _highlightObjectsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _highlightObjectsToolStripMenuItem.Click
         _viewerControl.HighlightObjects = Not _viewerControl.HighlightObjects
      End Sub

      Private Sub _pageToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _pageToolStripMenuItem.DropDownOpening
         If _document Is Nothing Then
            Return
         End If

         Dim pageCount As Integer = _document.Pages.Count
         _previousPageToolStripMenuItem.Enabled = _currentPageNumber > 1
         _nextPageToolStripMenuItem.Enabled = _currentPageNumber < pageCount
         _gotoPageToolStripMenuItem.Enabled = pageCount > 1
      End Sub

      Private Sub _previousPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _previousPageToolStripMenuItem.Click
         GotoPage(_currentPageNumber - 1, True)
      End Sub

      Private Sub _nextPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _nextPageToolStripMenuItem.Click
         GotoPage(_currentPageNumber + 1, True)
      End Sub

      Private Sub _gotoPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _gotoPageToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         Using dlg As New GotoPageDialog()
            dlg.DocumentPage = _currentPageNumber
            dlg.DocumentPageCount = _document.Pages.Count
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               GotoPage(dlg.DocumentPage, True)
            End If
         End Using
      End Sub

      Private Sub _interactiveToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _interactiveToolStripMenuItem.DropDownOpening
         If _document Is Nothing Then
            Return
         End If

         Dim interactiveMode As ViewerControl.ViewerControlInteractiveMode = _viewerControl.InteractiveMode

         _selectModeToolStripMenuItem.Checked = (interactiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode)
         _highlightTextModeToolStripMenuItem.Checked = (interactiveMode = ViewerControl.ViewerControlInteractiveMode.HighlightTextMode)
         _panModeToolStripMenuItem.Checked = (interactiveMode = ViewerControl.ViewerControlInteractiveMode.PanMode)
         _zoomToModeToolStripMenuItem.Checked = (interactiveMode = ViewerControl.ViewerControlInteractiveMode.ZoomToSelectionMode)
      End Sub

      Private Sub _selectModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _selectModeToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode
      End Sub

      Private Sub _highlightTextModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _highlightTextModeToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.HighlightTextMode
      End Sub

      Private Sub _panModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _panModeToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.PanMode
      End Sub

      Private Sub _zoomToModeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _zoomToModeToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.ZoomToSelectionMode
      End Sub


      Private Sub _annotationsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _annotationsToolStripMenuItem.DropDownOpening
         UpdateAnnotationsToolStrip()
      End Sub


      Private Sub UpdateAnnotationsToolStrip()
         If _document Is Nothing Then
            Return
         End If

         Dim canDoAnnotations As Boolean = _documentAnnotations.IsAnnotationsVisible AndAlso _documentAnnotations.IsEnabled
         Dim automation As AnnAutomation = _documentAnnotations.Automation

         Dim isSignatureObject As Boolean = (automation.CurrentEditObject IsNot Nothing AndAlso automation.CurrentEditObject.Id = AnnObject.None)

         _showAnnotationsToolStripMenuItem.Checked = _documentAnnotations.IsAnnotationsVisible
         _annotationsObjectToolStripMenuItem.Enabled = _documentAnnotations.IsEnabled
         _selectNextObjectToolStripMenuItem.Enabled = canDoAnnotations
         _selectPreviousObjectToolStripMenuItem.Enabled = canDoAnnotations
         _objectPropertiesToolStripMenuItem.Enabled = canDoAnnotations AndAlso (automation.CurrentEditObject IsNot Nothing AndAlso Not isSignatureObject)
         _objectContentToolStripMenuItem.Enabled = canDoAnnotations AndAlso (automation.CurrentEditObject IsNot Nothing AndAlso Not isSignatureObject)
         _deleteObjectToolStripMenuItem.Enabled = canDoAnnotations AndAlso (automation.CanDeleteObjects AndAlso Not isSignatureObject)
      End Sub

      Private Sub _showAnnotationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _showAnnotationsToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         _documentAnnotations.IsAnnotationsVisible = Not _documentAnnotations.IsAnnotationsVisible
         _viewerControl.InteractiveMode = ViewerControl.ViewerControlInteractiveMode.SelectMode
         _viewerControl.RasterImageViewer.Invalidate()
         _annotationsControl.Enabled = _documentAnnotations.IsAnnotationsVisible
      End Sub

      Private Sub _annotationsObjectToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _annotationsObjectToolStripMenuItem.DropDownOpening
         Dim currentObjectId As Integer = _documentAnnotations.AutomationManagerHelper.AutomationManager.CurrentObjectId
         For Each item As ToolStripMenuItem In _annotationsObjectToolStripMenuItem.DropDownItems
            item.Checked = (currentObjectId = CInt(item.Tag))
         Next
      End Sub

      Private Sub _selectNextObjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _selectNextObjectToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         If _documentAnnotations.IsAnnotationsVisible AndAlso _documentAnnotations.IsEnabled Then
            _documentAnnotations.SelectNextPreviousObject(True)
         End If

         UpdateAnnotationsToolStrip()
      End Sub

      Private Sub _selectPreviousObjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _selectPreviousObjectToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         If _documentAnnotations.IsAnnotationsVisible AndAlso _documentAnnotations.IsEnabled Then
            _documentAnnotations.SelectNextPreviousObject(False)
         End If

         UpdateAnnotationsToolStrip()
      End Sub

      Private Sub _objectPropertiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _objectPropertiesToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         If _documentAnnotations.IsAnnotationsVisible AndAlso _documentAnnotations.IsEnabled AndAlso _documentAnnotations.Automation.CurrentEditObject IsNot Nothing Then
            _documentAnnotations.Automation.ShowObjectProperties()
         End If
      End Sub

      Private Sub _objectContentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _objectContentToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         If _documentAnnotations.IsAnnotationsVisible AndAlso _documentAnnotations.IsEnabled AndAlso _documentAnnotations.Automation.CurrentEditObject IsNot Nothing Then
            _documentAnnotations.ShowObjectContent(_documentAnnotations.Automation.CurrentEditObject)
         End If
      End Sub

      Private Sub _deleteObjectToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _deleteObjectToolStripMenuItem.Click
         If _document Is Nothing Then
            Return
         End If

         If _documentAnnotations.IsAnnotationsVisible AndAlso _documentAnnotations.IsEnabled AndAlso _documentAnnotations.Automation.CanDeleteObjects Then
            _documentAnnotations.DeleteSelectedObject()
         End If

         UpdateAnnotationsToolStrip()
      End Sub

      Private Sub _aboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _aboutToolStripMenuItem.Click
         Using aboutDialog As New AboutDialog("PDF Document", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _pagesControl_Action(sender As Object, e As ActionEventArgs) Handles _pagesControl.Action
         Select Case e.Action
            Case "PageNumberChanged"
               GotoPage(CInt(e.Data), True)
               Exit Select

            Case "GotoBookmark"
               Dim bookmark As PDFBookmark = CType(e.Data, PDFBookmark)
               GotoLink(bookmark.TargetPageNumber, bookmark.TargetPageFitType, bookmark.TargetZoomPercent)
               Exit Select
            Case Else

               Exit Select
         End Select
      End Sub

      Private Sub _viewerControl_Action(sender As Object, e As ActionEventArgs) Handles _viewerControl.Action
         Select Case e.Action
            Case "PageNumberChanged"
               GotoPage(CInt(e.Data), True)
               Exit Select

            Case "HighlightText"
               HighlightText(CType(e.Data, LeadRect))
               Exit Select

            Case "GotoInternalLink"
               Dim internalLink As PDFInternalLink = CType(e.Data, PDFInternalLink)
               GotoLink(internalLink.TargetPageNumber, internalLink.TargetPageFitType, internalLink.TargetZoomPercent)
               Exit Select

            Case "GotoHyperlink"
               Dim hyperlink As PDFHyperlink = CType(e.Data, PDFHyperlink)
               GotoHyperlink(hyperlink.Hyperlink)
               Exit Select
            Case Else

               Exit Select
         End Select
      End Sub

      Private Sub _viewerControl_InteractiveModeChanged(sender As Object, e As EventArgs) Handles _viewerControl.InteractiveModeChanged
         ' Let our annotations knows, to enable/disable the toolbar
         If _documentAnnotations IsNot Nothing Then
            _documentAnnotations.InteractiveModeChanged(_viewerControl.InteractiveMode)
         End If
      End Sub

      Private Sub UpdateUIState()
         ' Update the status of the various UI controls

         Dim documentOk As Boolean = False
         Dim pageCount As Integer = 1

         If _document IsNot Nothing Then
            documentOk = True
            pageCount = _document.Pages.Count
         End If

         _viewerControl.Visible = documentOk
         _pagesControl.Visible = documentOk AndAlso pageCount >= 1

         _annotationsControl.Visible = documentOk
         _bottomPanel.Visible = documentOk

         _editToolStripMenuItem2.Visible = documentOk
         _viewToolStripMenuItem.Visible = documentOk
         _pageToolStripMenuItem.Visible = documentOk
         _interactiveToolStripMenuItem.Visible = documentOk
         _annotationsToolStripMenuItem.Visible = documentOk

         _toolStripSeparator1.Visible = documentOk

         _findToolStripTextBox.Visible = documentOk
         _findToolStripTextBox.Enabled = _documentText IsNot Nothing

         _findToolStripTextBox.Visible = documentOk
         _findToolStripTextBox.Enabled = _documentText IsNot Nothing

         _findPreviousToolStripButton.Visible = documentOk
         _findPreviousToolStripButton.Enabled = _documentText IsNot Nothing

         _findNextToolStripButton.Visible = documentOk
         _findNextToolStripButton.Enabled = _documentText IsNot Nothing
      End Sub
#End Region

      Private Function Init() As Boolean
         ' Check support required to use this demo
         If RasterSupport.IsLocked(RasterSupportType.Document) Then
            Messager.ShowError(Me, String.Format(DemosGlobalization.GetResxString([GetType](), "resx_DemoWillExit"), "RasterSupportType.Document"))
            Return False
         End If

         _rasterCodecs = New RasterCodecs()

         _demoOptions = DemoOptions.Load()

         _viewerControl.Visible = False
         _pagesControl.Visible = False

         _documentAnnotations = New DocumentAnnotations(Me)

         _viewerControl.BringToFront()

         UpdateUIState()

         LoadDefaultDocument()

         Return True
      End Function

      Private Sub LoadDefaultDocument()
         Dim defaultDocumentFileName As String = Path.GetFullPath(Path.Combine(DemosGlobal.ImagesFolder, "Leadtools.pdf"))
         If File.Exists(defaultDocumentFileName) Then
            If Messager.ShowQuestion(Me, String.Format(DemosGlobalization.GetResxString([GetType](), "resx_OpenDefault"), defaultDocumentFileName), MessageBoxButtons.YesNo) = DialogResult.Yes Then
               OpenDocument(defaultDocumentFileName)
            End If
         End If
      End Sub

      Private Sub CleanUp()
         _demoOptions.Save()

         _pagesControl.StopLoadingThumbnails()

         ' Delete all resources
         If _document IsNot Nothing Then
            _document.Dispose()
            _document = Nothing
         End If

         _selectedText = Nothing
         _findTextHelper = Nothing
         _documentText = Nothing
      End Sub

      Private Sub OpenDocument()
         Using dlg As New OpenFileDialog()
            If String.IsNullOrEmpty(_demoOptions.OpenCommonDialogFolder) OrElse Not Directory.Exists(_demoOptions.OpenCommonDialogFolder) Then
               _demoOptions.OpenCommonDialogFolder = DemosGlobal.ImagesFolder
            End If

            dlg.InitialDirectory = _demoOptions.OpenCommonDialogFolder

            dlg.Filter = "PDF Documents (*.pdf)|*.pdf|All Files|*.*"
            If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               Dim dir As String = Path.GetDirectoryName(dlg.FileName)
               If Directory.Exists(dir) Then
                  _demoOptions.OpenCommonDialogFolder = dir
               End If

               OpenDocument(dlg.FileName)
            End If
         End Using
      End Sub

      Private Sub OpenDocument(fileName As String)
         Using dlg As New LoadDocument.LoadDocumentDialog(fileName)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               Try
                  Using wait As New WaitCursor()
                     Dim document As PDFDocument = dlg.PDFDocument

                     ' Parse the document text
                     Dim documentText As Dictionary(Of Integer, MyWord()) = MyWord.BuildWord(document)

                     ' Initialize the document with annotations
                     SetDocument(document, documentText, fileName)
                  End Using
               Catch ex As Exception
                  Messager.ShowError(Me, ex.Message)
               Finally
                  UpdateUIState()
               End Try
            End If
         End Using
      End Sub

      Private Sub SetDocument(document As PDFDocument, documentText As Dictionary(Of Integer, MyWord()), documentName As String)
         Me.SuspendLayout()

         Try
            ' Stop the thumbnails generator if it is running
            _pagesControl.StopLoadingThumbnails()

            If _document IsNot Nothing Then
               _document.Dispose()
               _document = Nothing
            End If

            _documentText = Nothing

            _document = document
            _documentAnnotations.SetDocument(document)

            If _document IsNot Nothing Then
               _selectedText = New Dictionary(Of Integer, MyWord())()
               _findTextHelper = New FindTextHelper()
               _documentText = New Dictionary(Of Integer, MyWord())()

               For pageNumber As Integer = 1 To _document.Pages.Count
                  _selectedText.Add(pageNumber, Nothing)
                  _documentText.Add(pageNumber, Nothing)
               Next
            Else
               _selectedText = Nothing
               _findTextHelper = Nothing
            End If

            _viewerControl.SetDocument(_document, _selectedText)
            _pagesControl.SetDocument(_document)

            If _document IsNot Nothing Then
               ' Build words
               _documentText = documentText

               _viewerControl.Visible = True

               If _document.Pages.Count > 1 Then
                  _pagesControl.SetCurrentPageNumber(1)
                  _pagesControl.Visible = True
               End If

               Text = String.Format("{0} - {1}", documentName, Messager.Caption)

               GotoPage(1, True)
            Else
               Text = Messager.Caption
            End If
         Finally
            Me.ResumeLayout()
         End Try
      End Sub

      Private Sub CloseDocument()
         Try
            Using wait As New WaitCursor()
               SetDocument(Nothing, Nothing, Nothing)
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex.Message)
         Finally
            UpdateUIState()
         End Try
      End Sub

      Private Sub SaveDocument(fileName As String)
         Try
            Using wait As New WaitCursor()
               _documentAnnotations.SaveDocument(fileName)
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub ShowDocumentProperties()
         Using dlg As New DocumentPropertiesDialog(_document, Nothing)
            dlg.ShowDialog(Me)
         End Using
      End Sub

      Public Sub GotoPage(pageNumber As Integer, resetFindText As Boolean)
         If _document Is Nothing OrElse pageNumber <= 0 Then
            Return
         End If

         Try
            _viewerControl.HighlightSelectedImageObject = False
            Using wait As New WaitCursor()
               DocumentAnnotations.SetRasterCodecsOptions(_document, _rasterCodecs, pageNumber)
               Dim pageImage As RasterImage = _document.GetPageImage(_rasterCodecs, pageNumber)

               _currentPageNumber = pageNumber

               _pagesControl.SetCurrentPageNumber(pageNumber)
               _viewerControl.SetCurrentPageNumber(pageNumber, pageImage)
               _documentAnnotations.SetCurrentPageNumber(pageNumber)
               'set function will hide/show objects
               _documentAnnotations.IsAnnotationsVisible = _documentAnnotations.IsAnnotationsVisible
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            If resetFindText Then
               _findTextHelper.Reset()
            End If

            UpdateUIState()
         End Try
      End Sub

      Private Function BuildPageText(words As MyWord()) As String
         If words Is Nothing OrElse words.Length = 0 Then
            Return String.Empty
         End If

         Dim sb As New StringBuilder()
         For i As Integer = 0 To words.Length - 1
            Dim word As MyWord = words(i)
            sb.Append(word.Value)

            If word.IsEndOfLine Then
               sb.AppendLine()
            ElseIf i <> (words.Length - 1) Then
               sb.Append(" ")
            End If
         Next

         Return sb.ToString()
      End Function

      Private Sub ExportDocumentText()
         Using dlg As New SaveFileDialog()
            dlg.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*"
            If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               Dim sb As New StringBuilder()

               For Each page As PDFDocumentPage In _document.Pages
                  Dim text As String = String.Empty
                  If _documentText(page.PageNumber) IsNot Nothing Then
                     text = BuildPageText(_documentText(page.PageNumber))
                  End If

                  sb.Append(text)

                  If Not text.EndsWith(Environment.NewLine) Then
                     sb.AppendLine()
                  End If

                  File.WriteAllText(dlg.FileName, sb.ToString())
               Next
            End If
         End Using
      End Sub

      Private Sub CopySelectedText()
         ' Convert the selected words to a single string

         Dim words As MyWord() = _selectedText(_currentPageNumber)
         If words IsNot Nothing Then
            Dim sb As New StringBuilder()
            For i As Integer = 0 To words.Length - 1
               Dim word As MyWord = words(i)
               sb.Append(word.Value)

               If word.IsEndOfLine Then
                  sb.AppendLine()
               ElseIf i <> (words.Length - 1) Then
                  sb.Append(" ")
               End If
            Next

            Clipboard.SetText(sb.ToString())
         End If
      End Sub

      Private Sub SelectAllText()
         If _document Is Nothing OrElse _documentText(_currentPageNumber) Is Nothing Then
            Return
         End If

         ' Get the text for the current page

         _selectedText(_currentPageNumber) = New MyWord(_documentText(_currentPageNumber).Length - 1) {}
         _documentText(_currentPageNumber).CopyTo(_selectedText(_currentPageNumber), 0)
         ' Select it all (by replacing the selected text for the page for all text in the page)
         ' Re-paint the viewer
         _viewerControl.RasterImageViewer.Invalidate()
      End Sub

      Public Sub ClearTextSelection()
         If _document Is Nothing Then
            Return
         End If

         ' Clear the selected text of the current page
         _selectedText(_currentPageNumber) = Nothing
         ' Re-paint the viewer
         _viewerControl.RasterImageViewer.Invalidate()
      End Sub

      Public Sub HighlightText(bounds As LeadRect)
         If _document Is Nothing OrElse _documentText Is Nothing OrElse _documentText(_currentPageNumber) Is Nothing Then
            Return
         End If

         ' Select new text
         Dim allWords As IList(Of MyWord) = _documentText(_currentPageNumber)
         Dim selectedWords As New List(Of MyWord)()

         If allWords IsNot Nothing Then
            For Each word As MyWord In allWords
               If word.Bounds.IntersectsWith(bounds) Then
                  selectedWords.Add(word)
               End If
            Next
         End If

         ' Set the new words
         _selectedText(_currentPageNumber) = selectedWords.ToArray()
         ' Re-paint the viewer
         _viewerControl.RasterImageViewer.Invalidate()
      End Sub

      Private Sub FindText([next] As Boolean)
         Dim textToFind As String = _findToolStripTextBox.Text
         Dim textFound As Boolean = _findTextHelper.FindText(_documentText, _currentPageNumber, _document.Pages.Count, _findToolStripTextBox.Text, [next])
         If textFound Then
            Dim textPageNumber As Integer = _findTextHelper.GotoPageNumber
            _selectedText(textPageNumber) = _findTextHelper.GetSelectedWords()

            If textPageNumber <> _currentPageNumber Then
               GotoPage(textPageNumber, False)
            End If
         Else
            For pageNumber As Integer = 1 To _document.Pages.Count
               _selectedText(pageNumber) = Nothing
            Next

            Messager.ShowInformation(Me, String.Format(DemosGlobalization.GetResxString([GetType](), "resx_NotFound"), textToFind))
         End If

         _viewerControl.RasterImageViewer.Invalidate()
      End Sub

      Private Sub GotoLink(pageNumber As Integer, pageFitType As PDFPageFitType, zoomPercent As Integer)
         If pageNumber >= 1 AndAlso pageNumber <= _document.Pages.Count Then
            If _currentPageNumber <> pageNumber Then
               GotoPage(pageNumber, True)
            End If

            _viewerControl.RunLink(_document, pageFitType, zoomPercent)
         End If
      End Sub

      Private Sub GotoHyperlink(hyperlink As String)
         If Not String.IsNullOrEmpty(hyperlink) Then
            If Uri.IsWellFormedUriString(hyperlink, UriKind.RelativeOrAbsolute) Then
               Try
                  System.Diagnostics.Process.Start(hyperlink)
               Catch ex As Exception
                  Messager.ShowError(Me, ex)
               End Try
            Else
               Messager.ShowWarning(Me, String.Format(DemosGlobalization.GetResxString([GetType](), "resx_HyperlinkValNotWellFormatted"), hyperlink))
            End If
         End If
      End Sub

      Public ReadOnly Property IsTextSelected() As Boolean
         Get
            Return _documentText IsNot Nothing AndAlso _selectedText(_currentPageNumber) IsNot Nothing AndAlso _selectedText(_currentPageNumber).Length > 0
         End Get
      End Property

      Public ReadOnly Property AnnotationsViewer() As AutomationImageViewer
         Get
            Return _viewerControl.RasterImageViewer
         End Get
      End Property

      Public ReadOnly Property AnnotationsControl() As AnnotationsControl
         Get
            Return _annotationsControl
         End Get
      End Property

      Public ReadOnly Property AnnotationsMenuItem() As ToolStripMenuItem
         Get
            Return _annotationsObjectToolStripMenuItem
         End Get
      End Property

      Public ReadOnly Property SelectedText() As Dictionary(Of Integer, MyWord())
         Get
            Return _selectedText
         End Get
      End Property
   End Class
End Namespace
