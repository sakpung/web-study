' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Annotations.Automation
Imports Leadtools.Document.Writer
Imports Leadtools.WinForms.CommonDialogs.File
Imports Leadtools.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports Leadtools.Pdf
Imports Leadtools.Pdf.Annotations
Imports Leadtools.Annotations.BatesStamp
Imports Leadtools.Annotations.Rendering
Imports Leadtools.Demos.Dialogs
Imports Leadtools.Svg

Namespace DocumentWritersDemo
   Partial Public Class MainForm
      Inherits Form
      Private _rasterCodecsInstance As RasterCodecs
      Private _documentWriterInstance As DocumentWriter
      Private _lastSavedDocumentFileName As String
      Private _rasterizeDocOptions As RasterDialogRasterizeDocumentFileOptions
      Private _rtfFileName As String
      Private _emfFileNames As Dictionary(Of Integer, String)
      Private _rtfDictionary As Dictionary(Of Integer, Integer)
      ' to keep rtf pages associated with container pages 
      Private _isRtfLoaded As Boolean
      Private _isEmfLoaded As Boolean
      Private Const _rtfEmfStampTag As Integer = 1234
      ' We use this tag to identify Rtf and Emf stamps
      Private _pdfCustomBookmarks As New List(Of PdfCustomBookmark)()
      Private _randomNumber As New Random()


      Public Sub New()
         InitializeComponent()

         If Not DesignMode Then
            ' Setup the caption for this demo
            Messager.Caption = "VB Document Writers Demo"
            Text = Messager.Caption

            _rasterCodecsInstance = New RasterCodecs()
            _viewerControl.Title = "Document"
            _viewerControl.RasterCodecsInstance = _rasterCodecsInstance

            _documentWriterInstance = New DocumentWriter()
         End If
      End Sub

      Public ReadOnly Property Viewer() As ViewerControl
         Get
            Return _viewerControl
         End Get
      End Property

      Private Sub CreateTextObject(x0 As Integer, y0 As Integer, x1 As Integer, y1 As Integer, text As String)
         Dim annObject As New AnnTextObject()
         annObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("transparent"), LeadLengthD.Create(1))
         annObject.IsVisible = True
         annObject.Text = text
         Dim rect As New RectangleF(x0, y0, x1 - x0, y1 - y0)
         Dim mm As LeadMatrix = _viewerControl.RasterImageViewer.ViewTransform
         Dim m As New Matrix(CSng(mm.M11), CSng(mm.M12), CSng(mm.M21), CSng(mm.M22), CSng(mm.OffsetX), CSng(mm.OffsetY))
         Dim ts As New Transformer(m)
         rect = ts.RectangleToPhysical(rect)

         Dim leadrect As LeadRectD = LeadRectD.Create(rect.X, rect.Y, rect.Width, rect.Height)
         leadrect = _viewerControl.Automation.Container.Mapper.RectToContainerCoordinates(leadrect)
         annObject.Rect = leadrect
         annObject.TextForeground = AnnSolidColorBrush.Create("Red")
         annObject.Font = New AnnFont("Arial", 11)
         annObject.Font.FontStyle = AnnFontStyle.Normal
         _viewerControl.Automation.Container.Children.Add(annObject)
      End Sub

      Private Sub CreateStampAndTextObjects()
         ' stamp
         Dim stamp As New AnnStampObject()
         stamp.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Blue"), New LeadLengthD(4))
         stamp.IsVisible = True

         Dim container As AnnContainer = _viewerControl.Automation.Container
         Dim origin As New LeadPointD(0, 0)
         Dim rect As New RectangleF(CSng(75), CSng(100), CSng(675), CSng(875))
         Dim mm As LeadMatrix = _viewerControl.RasterImageViewer.ViewTransform
         Dim m As New Matrix(CSng(mm.M11), CSng(mm.M12), CSng(mm.M21), CSng(mm.M22), CSng(mm.OffsetX), CSng(mm.OffsetY))
         Dim ts As New Transformer(m)
         rect = ts.RectangleToPhysical(rect)

         Dim leadrect As LeadRectD = LeadRectD.Create(rect.X, rect.Y, rect.Width, rect.Height)
         leadrect = container.Mapper.RectToContainerCoordinates(leadrect)

         stamp.Rect = leadrect
         stamp.Font = New AnnFont("Arial", 48)
         stamp.Text = ""
         stamp.Font.FontStyle = AnnFontStyle.Normal

         Try
            Dim StampPic As System.Drawing.Bitmap = Global.DocumentWritersDemo.Resources.ExpenseReport
            Dim converter As New ImageConverter()
            Using ms As New MemoryStream()
               StampPic.Save(ms, ImageFormat.Bmp)
               stamp.Picture = New AnnPicture(ms.ToArray())
               container.Children.Add(stamp)
            End Using
         Catch generatedExceptionName As Exception
         End Try

         ' text (submitted by)
         CreateTextObject(305, 230, 690, 250, "Terry Smith")

         ' text (submit date)
         CreateTextObject(305, 260, 690, 280, "06/05/2009")

         ' text (description )
         CreateTextObject(305, 285, 690, 305, "Food")

         ' text (item description )
         CreateTextObject(145, 465, 365, 485, "Joe's Restaurant")

         ' text (item cost )
         CreateTextObject(465, 465, 535, 485, "$9.50")

         ' text (item date )
         CreateTextObject(370, 465, 450, 485, "06/01/2009")

         ' text (total )
         CreateTextObject(465, 700, 535, 720, "$9.50")

         ' Ellipse
         Dim ellipse As New AnnEllipseObject()
         ellipse.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Blue"), New LeadLengthD(4))

         rect = New RectangleF(CSng(430), CSng(685), CSng(100), CSng(60))
         mm = _viewerControl.RasterImageViewer.ViewTransform
         m = New Matrix(CSng(mm.M11), CSng(mm.M12), CSng(mm.M21), CSng(mm.M22), CSng(mm.OffsetX), CSng(mm.OffsetY))
         ts = New Transformer(m)
         rect = ts.RectangleToPhysical(rect)

         leadrect = LeadRectD.Create(rect.X, rect.Y, rect.Width, rect.Height)
         leadrect = container.Mapper.RectToContainerCoordinates(leadrect)

         ellipse.Rect = leadrect
         container.Children.Add(ellipse)

         ' StickyNote
         Dim note As New AnnNoteObject()
         note.Text = "\r\nJohn, please review this when you get a chance.\r\n\r\n-- Thanks"
         note.TextForeground = AnnSolidColorBrush.Create("Red")
         note.Font = New AnnFont("Arial", 11)
         note.Font.FontStyle = AnnFontStyle.Normal
         note.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Black"), New LeadLengthD(1))
         note.Fill = AnnSolidColorBrush.Create("Yellow")

         rect = New RectangleF(CSng(540), CSng(130), CSng(200), CSng(130))
         mm = _viewerControl.RasterImageViewer.ViewTransform
         m = New Matrix(CSng(mm.M11), CSng(mm.M12), CSng(mm.M21), CSng(mm.M22), CSng(mm.OffsetX), CSng(mm.OffsetY))
         ts = New Transformer(m)
         rect = ts.RectangleToPhysical(rect)

         leadrect = LeadRectD.Create(rect.X, rect.Y, rect.Width, rect.Height)
         leadrect = container.Mapper.RectToContainerCoordinates(leadrect)

         note.Rect = leadrect
         container.Children.Add(note)
      End Sub

      Protected Overrides Sub OnLoad(e As EventArgs)
         Try
            If Not DesignMode AndAlso _viewerControl.AutomationManager IsNot Nothing Then
               ' Add the objects to the annotations objects menu
               Dim automationManager As AnnAutomationManager = _viewerControl.AutomationManager
               For Each obj As AnnAutomationObject In automationManager.Objects
                  If obj.Id <> AnnObject.GroupObjectId Then
                     Dim item As New ToolStripMenuItem(obj.Name)
                     AddHandler item.Click, New EventHandler(AddressOf _annotationsCurrentObjectItem_Click)
                     item.Tag = obj.Id
                     _annotationsCurrentObjectToolStripMenuItem.DropDownItems.Add(item)
                  End If
               Next

               ' Tie the automation manager objects
               _pagesControl.SetAutomation(_viewerControl.AutomationManager, _viewerControl.Automation)

               ' Create a new document
               NewDocument(8.5F, 11, 300, 300)

               ' Create a stamp annotation with text objects
               CreateStampAndTextObjects()

               Dim pdfOptions As PdfDocumentOptions = TryCast(_documentWriterInstance.GetOptions(DocumentFormat.Pdf), PdfDocumentOptions)
               pdfOptions.FontEmbedMode = DocumentFontEmbedMode.None

               If (String.IsNullOrEmpty(pdfOptions.Creator)) Then
                  pdfOptions.Creator = "LEADTOOLS PDFWriter"
               End If
               If (String.IsNullOrEmpty(pdfOptions.Producer)) Then
                  pdfOptions.Producer = "LEAD Technologies, Inc."
               End If

               _documentWriterInstance.SetOptions(DocumentFormat.Pdf, pdfOptions)

               _viewerControl.automationInteractiveMode.IsEnabled = True
               _viewerControl.RasterImageViewer.InteractiveModes.EnableById(_viewerControl.automationInteractiveMode.Id)

               BeginInvoke(New MethodInvoker(AddressOf ShowWelcomeMessage))
            End If

            MyBase.OnLoad(e)
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub ShowWelcomeMessage()

         Messager.ShowInformation(Me, "This example demonstrates how to use the LEADTOOLS Document Writers functionality to convert RTF and EMF documents into PDF files. This example has annotation functionality, which can be used to create PDF files. This example also allows you to convert RTF and EMF files using the LEADTOOLS Document Writers and then save them to one multi-page PDF file. For a list of Document Writers, see https://www.leadtools.com/sdk/document/document-writers")

      End Sub

      Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
         _rasterCodecsInstance.Dispose()

         MyBase.OnFormClosed(e)
      End Sub

      Private Sub _fileNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _fileNewToolStripMenuItem.Click
         Try
            ' Get the last properties
            Dim settings As New Properties.Settings()

            Dim width As Single = 8.5F
            Dim height As Single = 11
            Dim resolution As Integer = 300

            If Not String.IsNullOrEmpty(settings.NewDocumentWidth) Then
               Dim val As Single
               If Single.TryParse(settings.NewDocumentWidth, val) Then
                  width = val
               End If
            End If

            If Not String.IsNullOrEmpty(settings.NewDocumentHeight) Then
               Dim val As Single
               If Single.TryParse(settings.NewDocumentHeight, val) Then
                  height = val
               End If
            End If

            If Not String.IsNullOrEmpty(settings.NewDocumentResolution) Then
               Dim val As Integer
               If Integer.TryParse(settings.NewDocumentResolution, val) Then
                  resolution = val
               End If
            End If

            Using dlg As New NewDocumentDialogBox(width, height, resolution)
               If dlg.ShowDialog(Me) = DialogResult.OK Then

                  _isEmfLoaded = InlineAssignHelper(_isRtfLoaded, False)

                  ' Save the settings
                  settings.NewDocumentWidth = dlg.DocumentWidth.ToString()
                  settings.NewDocumentHeight = dlg.DocumentHeight.ToString()
                  settings.NewDocumentResolution = dlg.DocumentResolution.ToString()
                  settings.Save()

                  'Clear the existing containers , we will create new one when setting the document to viewer
                  _viewerControl.Automation.Containers.Clear()

                  NewDocument(dlg.DocumentWidth, dlg.DocumentHeight, dlg.DocumentResolution, dlg.DocumentResolution)
               End If
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub _fileSaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _fileSaveToolStripMenuItem.Click
         Dim pdfOptions As PdfDocumentOptions = TryCast(_documentWriterInstance.GetOptions(DocumentFormat.Pdf), PdfDocumentOptions)

         Try
            Dim pageWidth As Double = 0, pageHeight As Double = 0
            ' in inches
            Dim emptyPageResolution As Integer

            Using dlg As New SavePdfDialog(_lastSavedDocumentFileName, pdfOptions, If(_isRtfLoaded, _rasterizeDocOptions.XResolution, _viewerControl.RasterImage.XResolution), _pagesControl.RasterImageList.Items.Count)
               If dlg.ShowDialog(Me) = DialogResult.OK Then
                  _lastSavedDocumentFileName = dlg.DocumentFileName
                  If Not _isEmfLoaded AndAlso Not _isRtfLoaded Then
                     emptyPageResolution = pdfOptions.DocumentResolution
                     ' The saving of annotations only (without loading RTF or EMF) 
                     ' Needs empty page resolution instead of document resolution
                     pdfOptions.EmptyPageResolution = emptyPageResolution
                     pdfOptions.DocumentResolution = 0
                     pageWidth = CDbl(_viewerControl.RasterImage.Width) / pdfOptions.EmptyPageResolution
                     pageHeight = CDbl(_viewerControl.RasterImage.Height) / pdfOptions.EmptyPageResolution
                     pdfOptions.EmptyPageWidth = pageWidth * 72.0 / pdfOptions.EmptyPageResolution
                     pdfOptions.EmptyPageHeight = pageHeight * 72.0 / pdfOptions.EmptyPageResolution
                     pdfOptions.PageRestriction = DocumentPageRestriction.Relaxed
                     pdfOptions.ImageOverText = True

                     ' Clear the bookmarks list we previously created inside the PdfDocumentOptions.
                     If pdfOptions.CustomBookmarks.Count <> 0 Then
                        pdfOptions.CustomBookmarks.Clear()
                     End If

                     ' Set the bookmarks into the PDF options.
                     pdfOptions.AutoBookmarksEnabled = False
                     Dim pdfBookmarks As List(Of PdfCustomBookmark) = GetCustomBookmarks()
                     For Each bookmark As PdfCustomBookmark In pdfBookmarks
                        pdfOptions.CustomBookmarks.Add(bookmark)
                     Next
                  End If

                  _documentWriterInstance.SetOptions(DocumentFormat.Pdf, pdfOptions)

                  SaveDocument(dlg.DocumentFileName, pdfOptions, pageWidth, pageHeight)
               End If
            End Using
         Catch generatedExceptionName As Exception
         End Try

      End Sub

      Private Function GetCustomBookmarks() As List(Of PdfCustomBookmark)
         Dim pdfBookmarks As New List(Of PdfCustomBookmark)()
         For Each parentNode As TreeNode In _pagesControl.PdfBookmarksList.Nodes
            EnumerateChildNodes(parentNode, pdfBookmarks)
         Next

         Return pdfBookmarks
      End Function

      Private Sub EnumerateChildNodes(parentNode As TreeNode, pdfBookmarks As List(Of PdfCustomBookmark))
         Dim pdfBookmark As PdfCustomBookmark = CType(parentNode.Tag, PdfCustomBookmark)
         pdfBookmarks.Add(pdfBookmark)
         For Each node As TreeNode In parentNode.Nodes
            EnumerateChildNodes(node, pdfBookmarks)
         Next
      End Sub


      Private Sub _fileExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _fileExitToolStripMenuItem.Click
         Close()
      End Sub

      Private Sub _editToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _editToolStripMenuItem.DropDownOpening
         Dim automation As AnnAutomation = _viewerControl.Automation
         Dim documentHasPages As Boolean = automation IsNot Nothing AndAlso _viewerControl.RasterImage.PageCount > 0

         If documentHasPages Then
            _editUndoToolStripMenuItem.Enabled = automation.CanUndo
            _editRedoToolStripMenuItem.Enabled = automation.CanRedo
            _editCutToolStripMenuItem.Enabled = automation.CanCopy
            _editCopyToolStripMenuItem.Enabled = automation.CanCopy
            _editPasteToolStripMenuItem.Enabled = automation.CanPaste
            _editDeleteToolStripMenuItem.Enabled = automation.CanDeleteObjects
            _editSelectAllToolStripMenuItem.Enabled = automation.CanSelectObjects
            _editSelectNoneToolStripMenuItem.Enabled = automation.CanSelectNone
         Else
            _editUndoToolStripMenuItem.Enabled = False
            _editRedoToolStripMenuItem.Enabled = False
            _editCutToolStripMenuItem.Enabled = False
            _editCopyToolStripMenuItem.Enabled = False
            _editPasteToolStripMenuItem.Enabled = False
            _editDeleteToolStripMenuItem.Enabled = False
            _editSelectAllToolStripMenuItem.Enabled = False
            _editSelectNoneToolStripMenuItem.Enabled = False
         End If
      End Sub

      Private Sub _editUndoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _editUndoToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation
         If automation IsNot Nothing AndAlso automation.CanUndo Then
            automation.Undo()
         End If
      End Sub

      Private Sub _editRedoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _editRedoToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation
         If automation IsNot Nothing AndAlso automation.CanRedo Then
            automation.Redo()
         End If
      End Sub

      Private Sub _editCutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _editCutToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation
         If automation IsNot Nothing AndAlso automation.CanCopy Then
            automation.Copy()
            automation.DeleteSelectedObjects()
         End If
      End Sub

      Private Sub _editCopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _editCopyToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation
         If automation IsNot Nothing AndAlso automation.CanCopy Then
            automation.Copy()
         End If
      End Sub

      Private Sub _editPasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _editPasteToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation
         If automation IsNot Nothing AndAlso automation.CanPaste Then
            automation.Paste()
         End If
      End Sub

      Private Sub _editDeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _editDeleteToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation
         If automation IsNot Nothing AndAlso automation.CanDeleteObjects Then
            automation.DeleteSelectedObjects()
         End If
      End Sub

      Private Sub _editSelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _editSelectAllToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation
         If automation IsNot Nothing AndAlso automation.CanSelectObjects Then
            automation.SelectObjects(automation.Container.Children)
         End If
      End Sub

      Private Sub _editSelectNoneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _editSelectNoneToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation
         If automation IsNot Nothing AndAlso automation.CanSelectNone Then
            automation.SelectObjects(Nothing)
         End If
      End Sub

      Private Sub _annotationsToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _annotationsToolStripMenuItem.DropDownOpening
         Dim automation As AnnAutomation = _viewerControl.Automation

         If automation IsNot Nothing Then
            _annotationsPropertiesToolStripMenuItem.Enabled = automation.CanShowObjectProperties
         Else
            _annotationsPropertiesToolStripMenuItem.Enabled = False
         End If
      End Sub

      Private Sub _annotationsCurrentObjectToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _annotationsCurrentObjectToolStripMenuItem.DropDownOpening
         ' Check the current object id item
         Dim automationManager As AnnAutomationManager = _viewerControl.AutomationManager
         If automationManager IsNot Nothing Then
            Dim currentObjectId As Integer = automationManager.CurrentObjectId

            For Each item As ToolStripMenuItem In _annotationsCurrentObjectToolStripMenuItem.DropDownItems
               Dim id As Integer = CInt(item.Tag)
               item.Checked = (id = currentObjectId)
            Next
         End If
      End Sub

      Private Sub _annotationsCurrentObjectItem_Click(sender As Object, e As EventArgs)
         ' Select the new object
         Dim automationManager As AnnAutomationManager = _viewerControl.AutomationManager
         Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
         Dim id As Integer = CInt(item.Tag)
         automationManager.CurrentObjectId = id
      End Sub

      Private Sub _annotationsAlignToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _annotationsAlignToolStripMenuItem.DropDownOpening
         Dim automation As AnnAutomation = _viewerControl.Automation
         If automation IsNot Nothing Then
            _alignBringToFrontToolStripMenuItem.Enabled = automation.CanBringToFront
            _alignSendToBackToolStripMenuItem.Enabled = automation.CanSendToBack
            _alignBringToFirstToolStripMenuItem.Enabled = automation.CanBringToFirst
            _alignSendToLastToolStripMenuItem.Enabled = automation.CanSendToLast
         Else
            _alignBringToFrontToolStripMenuItem.Enabled = False
            _alignSendToBackToolStripMenuItem.Enabled = False
            _alignBringToFirstToolStripMenuItem.Enabled = False
            _alignSendToLastToolStripMenuItem.Enabled = False
         End If
      End Sub

      Private Sub _alignBringToFrontToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _alignBringToFrontToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation

         If automation.CanBringToFront Then
            automation.BringToFront(False)
         End If
      End Sub

      Private Sub _alignSendToBackToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _alignSendToBackToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation

         If automation.CanSendToBack Then
            automation.SendToBack(False)
         End If
      End Sub

      Private Sub _alignBringToFirstToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _alignBringToFirstToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation

         If automation.CanBringToFirst Then
            automation.BringToFront(True)
         End If
      End Sub

      Private Sub _alignSendToLastToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _alignSendToLastToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation

         If automation.CanSendToLast Then
            automation.SendToBack(True)
         End If
      End Sub

      Private Sub _flipHorizontallyToolStripMenuItem_Click(sender As Object, e As EventArgs)
         Dim automation As AnnAutomation = _viewerControl.Automation

         If automation.CanFlip Then
            automation.Flip(True)
         End If
      End Sub

      Private Sub _flipVerticallyToolStripMenuItem_Click(sender As Object, e As EventArgs)
         Dim automation As AnnAutomation = _viewerControl.Automation

         If automation.CanFlip Then
            automation.Flip(False)
         End If
      End Sub

      Private Sub _groupSelectedObjectsToolStripMenuItem_Click(sender As Object, e As EventArgs)
         Dim automation As AnnAutomation = _viewerControl.Automation

         Dim annContainer As AnnContainer = _viewerControl.Automation.Container
         If annContainer.SelectionObject IsNot Nothing AndAlso annContainer.SelectionObject.SelectedObjects.Count > 1 Then
            Dim groupName As String = String.Format("Group{0}", _randomNumber.Next() Mod 100)
            For Each annObject As AnnObject In annContainer.SelectionObject.SelectedObjects
               annObject.GroupName = groupName
            Next
         End If
      End Sub

      Private Sub _groupUngroupToolStripMenuItem_Click(sender As Object, e As EventArgs)
         Dim automation As AnnAutomation = _viewerControl.Automation

         If automation.CanUngroup Then
            Dim annContainer As AnnContainer = _viewerControl.Automation.Container
            If annContainer.SelectionObject IsNot Nothing AndAlso annContainer.SelectionObject.SelectedObjects.Count > 1 Then
               annContainer.SelectionObject.Ungroup(annContainer.SelectionObject.SelectedObjects(0).GroupName)
            End If
         End If
      End Sub

      Private Sub _annotationsResetRotatePointsToolStripMenuItem_Click(sender As Object, e As EventArgs)
         Dim automation As AnnAutomation = _viewerControl.Automation

         If automation.CanResetRotatePoints Then
            automation.ResetRotatePoints()
         End If
      End Sub

      Private Sub _annotationsPropertiesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _annotationsPropertiesToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation

         If automation IsNot Nothing Then
            If automation.CanShowObjectProperties Then
               automation.ShowObjectProperties()
            End If
         End If

      End Sub

      Private Sub _helpAboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _helpAboutToolStripMenuItem.Click
         Using aboutDialog As New AboutDialog("Document Writers", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub


      Private Sub _newToolStripButton_Click(sender As Object, e As EventArgs) Handles _newToolStripButton.Click
         _fileNewToolStripMenuItem.PerformClick()
      End Sub

      Private Sub _saveToolStripButton_Click(sender As Object, e As EventArgs) Handles _saveToolStripButton.Click
         _fileSaveToolStripMenuItem.PerformClick()
      End Sub

      Private Sub _copyToolStripButton_Click(sender As Object, e As EventArgs) Handles _copyToolStripButton.Click
         _editCopyToolStripMenuItem.PerformClick()
      End Sub

      Private Sub _pasteToolStripButton_Click(sender As Object, e As EventArgs) Handles _pasteToolStripButton.Click
         _editPasteToolStripMenuItem.PerformClick()
      End Sub

      Private Sub _deleteToolStripButton_Click(sender As Object, e As EventArgs) Handles _deleteToolStripButton.Click
         _editDeleteToolStripMenuItem.PerformClick()
      End Sub

      Private Sub _undoToolStripButton_Click(sender As Object, e As EventArgs) Handles _undoToolStripButton.Click
         _editUndoToolStripMenuItem.PerformClick()
      End Sub

      Private Sub _redoToolStripButton_Click(sender As Object, e As EventArgs) Handles _redoToolStripButton.Click
         _editRedoToolStripMenuItem.PerformClick()
      End Sub

      Private Sub _pagesControl_Action(sender As Object, e As ActionEventArgs) Handles _pagesControl.Action
         Select Case e.Action
            Case "NewPage"
               AddNewPage()
               Exit Select

            Case "DeletePage"
               DeleteCurrentPage()
               Exit Select

            Case "MovePageUp"
               MoveCurrentPage(True)
               Exit Select

            Case "MovePageDown"
               MoveCurrentPage(False)
               Exit Select

            Case "PageNumberChanged"
               If True Then
                  Dim pageNumber As Integer = CInt(e.Data)
                  GotoPage(pageNumber)
               End If
               Exit Select

            Case "CenterAtPoint"
               If True Then
                  Dim pdfBookmark As PdfCustomBookmark = CType(e.Data, PdfCustomBookmark)
                  Dim bookmarkPosition As New PointF(CSng(pdfBookmark.XCoordinate), CSng(pdfBookmark.YCoordinate))

                  bookmarkPosition.X = CInt(bookmarkPosition.X / (_viewerControl.RasterImageViewer.Image.XResolution / 96))
                  bookmarkPosition.Y = CInt(bookmarkPosition.Y / (_viewerControl.RasterImageViewer.Image.YResolution / 96))

                  Dim LMatrix As LeadMatrix = _viewerControl.RasterImageViewer.ImageTransform
                  '.ImageTransform
                  Dim m As New Matrix(CSng(LMatrix.M11), CSng(LMatrix.M12), CSng(LMatrix.M21), CSng(LMatrix.M22), CSng(LMatrix.OffsetX), CSng(LMatrix.OffsetY))
                  Dim t As New Transformer(m)
                  bookmarkPosition = t.PointToPhysical(bookmarkPosition)

                  GotoPage(pdfBookmark.PageNumber)
                  If pdfBookmark.PageNumber <= _pagesControl.RasterImageList.Items.Count Then
                     _viewerControl.RasterImageViewer.CenterAtPoint(LeadPoint.Create(CInt(Math.Truncate(bookmarkPosition.X)), CInt(Math.Truncate(bookmarkPosition.Y))))
                  End If
               End If
               Exit Select
            Case Else

               Exit Select
         End Select
      End Sub

      Private Sub _viewerControl_Action(sender As Object, e As ActionEventArgs) Handles _viewerControl.Action
         Select Case e.Action
            Case "PageNumberChanged"
               If True Then
                  Dim pageNumber As Integer = CInt(e.Data)
                  GotoPage(pageNumber)
               End If
               Exit Select

            Case "UpdateUIState"
               UpdateUIState()
               ' Re-paint the thumbnails
               _pagesControl.RasterImageList.Invalidate()
               Exit Select

            Case "UpdateBookmarkPosition"
               _pagesControl.BookmarkPosition = CType(e.Data, Point)
               Exit Select
            Case Else

               Exit Select
         End Select
      End Sub

      Private Sub NewDocument(widthInInches As Single, heightInInches As Single, dpiX As Integer, dpiY As Integer)
         ' Create a new empty RasterImage object with one page with
         ' the specified DPI

         Try
            Using wait As New WaitCursor()
               Dim image As RasterImage = CreateNewDocumentPage(Nothing, widthInInches, heightInInches, dpiX, dpiY)
               _viewerControl.SetDocument(image)

               If _viewerControl.AutomationManager IsNot Nothing Then
                  ' Clear the pages image list and add the new page
                  Dim imageList As ImageViewer = _pagesControl.RasterImageList
                  imageList.BeginUpdate()
                  imageList.Items.Clear()

                  ' Create a thumbnail for the image and add it to the image list
                  Dim thumbnailImage As RasterImage = CreateThumbnailImage(image, 160, 160, 24)
                  Dim item As New ImageViewerItem()
                  item.Image = thumbnailImage
                  item.PageNumber = 1
                  item.Tag = image.Clone()
                  imageList.Items.Add(item)
                  item.Text = "Page 1"

                  imageList.EndUpdate()

                  GotoPage(1)
               End If
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Function CreateNewDocumentPage(image As RasterImage, widthInInches As Single, heightInInches As Single, dpiX As Integer, dpiY As Integer) As RasterImage
         Dim width As Integer
         Dim height As Integer
         Dim xResolution As Integer
         Dim yResolution As Integer

         ' See if image is not null, then create the new page as the same
         ' size of the image
         If image IsNot Nothing Then
            width = image.Width
            height = image.Height
            xResolution = image.XResolution
            yResolution = image.YResolution
         Else
            width = CInt(Math.Truncate(widthInInches * dpiX))
            height = CInt(Math.Truncate(heightInInches * dpiY))
            xResolution = dpiX
            yResolution = dpiY
         End If

         Dim page As New RasterImage(RasterMemoryFlags.Conventional, width, height, 1, RasterByteOrder.Rgb, RasterViewPerspective.TopLeft, _
          Nothing, IntPtr.Zero, 0)
         page.XResolution = xResolution
         page.YResolution = yResolution

         ' Fill with white

         Dim cmd As New FillCommand(Leadtools.Demos.Converters.FromGdiPlusColor(Color.White))

         cmd.Run(page)

         Return page
      End Function

      Private Shared Function CreateThumbnailImage(image As RasterImage, thumbnailWidth As Integer, thumbnailHeight As Integer, bitsPerPixel As Integer) As RasterImage
         ' Creates a thumbnail for the image
         ' First clone the image
         Dim destinationImage As RasterImage = image.Clone()

         ' See if we need to change the bits/pixel
         If destinationImage.BitsPerPixel <> bitsPerPixel Then
            Dim colorResolutionCommand As New ColorResolutionCommand(ColorResolutionCommandMode.InPlace, bitsPerPixel, RasterByteOrder.Bgr, RasterDitheringMethod.Clustered, ColorResolutionCommandPaletteFlags.Optimized, Nothing)
            colorResolutionCommand.Run(destinationImage)
         End If

         ' See if we need to change the view perspective
         If destinationImage.ViewPerspective <> RasterViewPerspective.TopLeft Then
            Dim changeViewPerspectiveCommand As New ChangeViewPerspectiveCommand(True, RasterViewPerspective.TopLeft)
            changeViewPerspectiveCommand.Run(destinationImage)
         End If

         ' Get the real size of the image (including DPI)
         Dim imageWidth As Integer = CInt(image.ImageWidth * 96 / image.XResolution)
         Dim imageHeight As Integer = CInt(image.ImageHeight * 96 / image.YResolution)

         If imageWidth > thumbnailWidth OrElse imageHeight > thumbnailHeight Then
            Dim factor As Double

            If thumbnailWidth > thumbnailHeight Then
               factor = CDbl(thumbnailWidth) / CDbl(imageWidth)
               If (factor * CDbl(imageHeight)) > CDbl(thumbnailHeight) Then
                  factor = CDbl(thumbnailHeight) / CDbl(imageHeight)
               End If
            Else
               factor = CDbl(thumbnailHeight) / CDbl(imageHeight)
               If (factor * CDbl(imageWidth)) > CDbl(thumbnailWidth) Then
                  factor = CDbl(thumbnailWidth) / CDbl(imageWidth)
               End If
            End If

            Dim scaledImageWidth As Integer = CInt(Math.Truncate(factor * imageWidth))
            Dim scaledImageHeight As Integer = CInt(Math.Truncate(factor * imageHeight))

            ' Resize it
            Dim sizeCommand As New SizeCommand(scaledImageWidth, scaledImageHeight, RasterSizeFlags.Bicubic)
            sizeCommand.Run(destinationImage)
         End If

         Return destinationImage
      End Function

      Private Sub GotoPage(pageNumber As Integer)
         ' Go to the page number in the viewer and pages controls
         _viewerControl.SetCurrentPageNumber(pageNumber)
         _pagesControl.SetCurrentPageNumber(pageNumber)
         UpdateUIState()
      End Sub

      Private Sub AddNewPage()
         ' Add a new page to the document
         Try
            Dim page As RasterImage = CreateNewDocumentPage(_viewerControl.RasterImage, 0, 0, 0, 0)

            ' Clear the pages image list and add the new page
            Dim imageList As ImageViewer = _pagesControl.RasterImageList

            imageList.BeginUpdate()

            ' Create a thumbnail for the image and add it to the image list
            Dim thumbnailImage As RasterImage = CreateThumbnailImage(page, 160, 160, 24)

            Dim pageNumber As Integer = _viewerControl.RasterImage.PageCount + 1
            Dim item As New ImageViewerItem()
            item.Image = thumbnailImage
            item.Tag = pageNumber
            item.Text = "Page " & pageNumber.ToString()
            item.Tag = page.Clone()
            imageList.Items.Add(item)

            imageList.EndUpdate()

            ' Add the page to the viewer
            ' This will call RasterImage.AddPage which will dispose "page"
            _viewerControl.RasterImageViewer.Zoom(ControlSizeMode.ActualSize, 1, _viewerControl.RasterImageViewer.DefaultZoomOrigin)
            _viewerControl.RasterImageViewer.UseDpi = False

            _viewerControl.AddPage(page, page.ImageWidth, page.ImageHeight)

            GotoPage(pageNumber)

            _viewerControl.RasterImageViewer.Zoom(ControlSizeMode.Fit, 1, _viewerControl.RasterImageViewer.DefaultZoomOrigin)
            _viewerControl.RasterImageViewer.UseDpi = True
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub AddNewPage(width As Single, Height As Single, dpiX As Integer, dpiY As Integer)
         ' Add a new page to the document
         Try
            Dim page As RasterImage = CreateNewDocumentPage(Nothing, width, Height, dpiX, dpiY)

            ' Clear the pages image list and add the new page
            Dim imageList As ImageViewer = _pagesControl.RasterImageList

            imageList.BeginUpdate()

            ' Create a thumbnail for the image and add it to the image list
            Dim thumbnailImage As RasterImage = CreateThumbnailImage(page, 160, 160, 24)
            Dim pageNumber As Integer = _viewerControl.RasterImage.PageCount + 1
            Dim item As New ImageViewerItem()
            item.Image = thumbnailImage
            item.Tag = pageNumber
            item.Text = "Page " & pageNumber.ToString()
            imageList.Items.Add(item)

            imageList.EndUpdate()

            ' Add the page to the viewer
            ' This will call RasterImage.AddPage which will dispose "page"
            _viewerControl.AddPage(page, page.ImageWidth, page.ImageHeight)

            GotoPage(pageNumber)
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub DeleteCurrentPage()
         ' Delete the current page
         Dim pageNumber As Integer = _viewerControl.RasterImage.Page

         _viewerControl.DeleteCurrentPage()
         _pagesControl.DeleteCurrentPage()

         ' Update the text for the thumbnails
         Dim imageList As ImageViewer = _pagesControl.RasterImageList
         For i As Integer = 0 To imageList.Items.Count - 1
            imageList.Items(i).Text = "Page " & (i + 1).ToString()
         Next


         ' Update Rtf and Emf pages according to container pages
         If _isRtfLoaded AndAlso _rtfDictionary.ContainsKey(pageNumber) Then
            If _rtfDictionary.ContainsKey(pageNumber + 1) Then
               For i As Integer = pageNumber To _viewerControl.AutomationManager.Automations.Count
                  If _rtfDictionary.ContainsKey(i) Then
                     If _rtfDictionary.ContainsKey(i + 1) Then
                        _rtfDictionary(i) = _rtfDictionary(i + 1)
                     Else
                        _rtfDictionary.Remove(i + 1)
                        Exit For
                     End If
                  End If
               Next
            Else
               _rtfDictionary.Remove(pageNumber + 1)
            End If
         ElseIf _isEmfLoaded AndAlso _emfFileNames.ContainsKey(pageNumber) Then
            If _emfFileNames.ContainsKey(pageNumber + 1) Then
               For i As Integer = pageNumber To _viewerControl.AutomationManager.Automations.Count
                  If _emfFileNames.ContainsKey(i) Then
                     If _emfFileNames.ContainsKey(i + 1) Then
                        _emfFileNames(i) = _emfFileNames(i + 1)
                     Else
                        _emfFileNames.Remove(i + 1)
                        Exit For
                     End If
                  End If
               Next
            Else
               _emfFileNames.Remove(pageNumber + 1)
            End If
         End If


         If pageNumber > _viewerControl.RasterImage.PageCount Then
            pageNumber = _viewerControl.RasterImage.PageCount
         End If

         ' Go to the current page
         GotoPage(pageNumber)
      End Sub

      Private Sub MoveCurrentPage(up As Boolean)
         ' Move the current page up or down
         ' We will do the move by swapping the two pages

         Dim image As RasterImage = _viewerControl.RasterImage
         image.Page = _viewerControl.RasterImage.Page

         ' Get the page numbers to move
         Dim pageNumber1 As Integer = image.Page
         Dim pageNumber2 As Integer

         Dim page1 As RasterImage = Nothing
         Dim page2 As RasterImage = Nothing

         If up Then
            pageNumber2 = pageNumber1 - 1
         Else
            pageNumber2 = pageNumber1 + 1
         End If


         ' Modify rtf and emf page dictionary according to page moving
         If _isRtfLoaded Then
            If _rtfDictionary.ContainsKey(pageNumber1) OrElse _rtfDictionary.ContainsKey(pageNumber2) Then
               Dim tempPageIndex1 As Integer, tempPageIndex2 As Integer
               If _rtfDictionary.ContainsKey(pageNumber1) AndAlso Not _rtfDictionary.ContainsKey(pageNumber2) Then
                  tempPageIndex1 = _rtfDictionary(pageNumber1)
                  _rtfDictionary.Remove(pageNumber1)
                  _rtfDictionary.Add(pageNumber2, tempPageIndex1)
               ElseIf _rtfDictionary.ContainsKey(pageNumber2) AndAlso Not _rtfDictionary.ContainsKey(pageNumber1) Then
                  tempPageIndex2 = _rtfDictionary(pageNumber2)
                  _rtfDictionary.Remove(pageNumber2)
                  _rtfDictionary.Add(pageNumber1, tempPageIndex2)
               Else
                  tempPageIndex1 = _rtfDictionary(pageNumber1)
                  tempPageIndex2 = _rtfDictionary(pageNumber2)
                  _rtfDictionary.Remove(pageNumber1)
                  _rtfDictionary.Remove(pageNumber2)
                  _rtfDictionary.Add(pageNumber2, tempPageIndex1)
                  _rtfDictionary.Add(pageNumber1, tempPageIndex2)
               End If
            End If
         ElseIf _isEmfLoaded Then
            If _emfFileNames.ContainsKey(pageNumber1) OrElse _emfFileNames.ContainsKey(pageNumber2) Then
               Dim tempEmf1 As String, tempEmf2 As String
               If _emfFileNames.ContainsKey(pageNumber1) AndAlso Not _emfFileNames.ContainsKey(pageNumber2) Then
                  tempEmf1 = _emfFileNames(pageNumber1)
                  _emfFileNames.Remove(pageNumber1)
                  _emfFileNames.Add(pageNumber2, tempEmf1)
               ElseIf _emfFileNames.ContainsKey(pageNumber2) AndAlso Not _emfFileNames.ContainsKey(pageNumber1) Then
                  tempEmf2 = _emfFileNames(pageNumber2)
                  _emfFileNames.Remove(pageNumber2)
                  _emfFileNames.Add(pageNumber1, tempEmf2)
               Else
                  tempEmf1 = _emfFileNames(pageNumber1)
                  tempEmf2 = _emfFileNames(pageNumber2)
                  _emfFileNames.Remove(pageNumber1)
                  _emfFileNames.Remove(pageNumber2)
                  _emfFileNames.Add(pageNumber2, tempEmf1)
                  _emfFileNames.Add(pageNumber1, tempEmf2)
               End If
            End If
         End If


         _viewerControl.RasterImageViewer.BeginUpdate()

         Dim imageList As ImageViewer = _pagesControl.RasterImageList

         imageList.BeginUpdate()

         Using wait As New WaitCursor()
            ' First move the pages in the image itself
            image.Page = pageNumber1
            page1 = image.Clone()

            image.Page = pageNumber2
            page2 = image.Clone()

            image.RemovePageAt(pageNumber1)
            image.InsertPage(pageNumber1 - 1, page2)

            image.RemovePageAt(pageNumber2)
            image.InsertPage(pageNumber2 - 1, page1)

            ' Now, exchange the items in the image list
            page1 = imageList.Items(pageNumber1 - 1).Image.Clone()

            imageList.Items(pageNumber1 - 1).Image = imageList.Items(pageNumber2 - 1).Image.Clone()
            imageList.Items(pageNumber2 - 1).Image = page1.Clone()

            ' Finally, swap the  containers
            Dim container1 As AnnContainer = _viewerControl.Automation.Containers(pageNumber1 - 1)
            _viewerControl.Automation.Containers(pageNumber1 - 1) = _viewerControl.Automation.Containers(pageNumber2 - 1)

            _viewerControl.Automation.Containers(pageNumber2 - 1) = container1
         End Using

         imageList.EndUpdate()

         _viewerControl.RasterImageViewer.EndUpdate()

         GotoPage(pageNumber2)

         'Free the temp images
         page1.Dispose()
         page1 = Nothing

         page2.Dispose()
         page2 = Nothing
      End Sub


      Private Sub UpdateUIState()
         Try
            Dim automation As AnnAutomation = _viewerControl.Automation
            If automation IsNot Nothing Then
               _copyToolStripButton.Enabled = automation.CanCopy
               _pasteToolStripButton.Enabled = automation.CanPaste
               _deleteToolStripButton.Enabled = automation.CanDeleteObjects
               _undoToolStripButton.Enabled = automation.CanUndo
               _redoToolStripButton.Enabled = automation.CanRedo
            Else
               _copyToolStripButton.Enabled = False
               _pasteToolStripButton.Enabled = False
               _deleteToolStripButton.Enabled = False
               _undoToolStripButton.Enabled = False
               _redoToolStripButton.Enabled = False
            End If

            _pagesControl.RasterImageList.Refresh()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub


      Private Sub SaveDocument(fileName As String, pdfOptions As PdfDocumentOptions, pageWidth As Double, pageHeight As Double)
         Dim emfFileNames As New List(Of String)()

         Dim currentPageNumber As Integer = _pagesControl.CurrentPageNumber

         Try
            Dim automation As AnnAutomation = _viewerControl.Automation

            'start from first container
            _viewerControl.SetCurrentPageNumber(1)

            ' First, save all the objects as EMF to temporary files
            Dim annCodecsObj As New AnnCodecs()

            Using wait As New WaitCursor()
               ' Start a new PDF document
               _documentWriterInstance.BeginDocument(fileName, DocumentFormat.Pdf)
               Dim i As Integer = 0
               For Each container As AnnContainer In automation.Containers
                  ' If we loaded rtf documents, we should add annotation container with emf file to page
                  If _isRtfLoaded Then
                     Dim page__1 As New DocumentWriterSvgPage()

                     If _rtfDictionary.ContainsKey(i + 1) Then
                        ' Get its handle
                        Using codecs As New RasterCodecs()
                           codecs.Options.RasterizeDocument.Load.TopMargin = _rasterizeDocOptions.TopMargin
                           codecs.Options.RasterizeDocument.Load.BottomMargin = _rasterizeDocOptions.BottomMargin
                           codecs.Options.RasterizeDocument.Load.LeftMargin = _rasterizeDocOptions.LeftMargin
                           codecs.Options.RasterizeDocument.Load.RightMargin = _rasterizeDocOptions.RightMargin
                           codecs.Options.RasterizeDocument.Load.PageWidth = _rasterizeDocOptions.PageWidth
                           codecs.Options.RasterizeDocument.Load.PageHeight = _rasterizeDocOptions.PageHeight
                           ' Use default resolution to get emf from Rtf document
                           codecs.Options.RasterizeDocument.Load.XResolution = _rasterizeDocOptions.XResolution
                           codecs.Options.RasterizeDocument.Load.YResolution = _rasterizeDocOptions.YResolution

                           Dim svgDocument As SvgDocument = TryCast(codecs.LoadSvg(_rtfFileName, _rtfDictionary(i + 1) + 1, Nothing), SvgDocument)
                           If Not svgDocument.IsFlat Then
                              svgDocument.Flat(Nothing)
                           End If

                           If Not svgDocument.Bounds.IsValid OrElse svgDocument.Bounds.IsTrimmed Then
                              svgDocument.CalculateBounds(False)
                           End If

                           page__1.Height = svgDocument.Bounds.Bounds.Height
                           page__1.Width = svgDocument.Bounds.Bounds.Width
                           page__1.SvgDocument = svgDocument

                           ' Add it as a PDF page
                           _documentWriterInstance.AddPage(page__1)
                        End Using
                     Else
                        Dim Page__2 As New DocumentWriterEmptyPage()

                        Page__2.Width = 850
                        Page__2.Height = 1100

                        pageWidth = Page__2.Width
                        pageHeight = Page__2.Height

                        ' Add it as a PDF page
                        _documentWriterInstance.AddPage(Page__2)
                     End If
                  ElseIf _isEmfLoaded Then
                     If _emfFileNames.ContainsKey(i + 1) Then
                        Dim page__1 As New DocumentWriterEmfPage()
                        ' Get its handle
                        Using mf As New Metafile(_emfFileNames(i + 1))
                           pageWidth = mf.Size.Width
                           pageHeight = mf.Size.Height

                           ' Get its handle
                           page__1.EmfHandle = mf.GetHenhmetafile()

                           ' Add it as a PDF page
                           _documentWriterInstance.AddPage(page__1)
                        End Using
                     Else
                        Dim Page__2 As New DocumentWriterEmptyPage()

                        Page__2.Width = 850
                        Page__2.Height = 1100

                        pageWidth = Page__2.Width
                        pageHeight = Page__2.Height

                        ' Add it as a PDF page
                        _documentWriterInstance.AddPage(Page__2)
                     End If
                  Else
                     'Create Empty Raster page
                     Dim page__1 As New DocumentWriterRasterPage()

                     _viewerControl.RasterImageViewer.Image.Page = automation.Containers.IndexOf(container) + 1
                     'Assign the viewer's image to the document writer page
                     page__1.Image = _viewerControl.RasterImageViewer.Image.Clone()

                     If page__1.Image.XResolution > 100 Then
                        pageWidth = page__1.Image.Width / (page__1.Image.XResolution / 100)
                        pageHeight = page__1.Image.Height / (page__1.Image.YResolution / 100)
                     End If

                     'Since standard Annotation's stamp objects are not supported in PDF Annotations
                     'we will burn the stamp object to the original image, before saving the annotations

                     'Get the graphic object from our raster image
                     Dim GdiPlusGraphicsContainer As RasterImageGdiPlusGraphicsContainer = New RasterImageGdiPlusGraphicsContainer(page__1.Image)
                     Dim PageG As Graphics = GdiPlusGraphicsContainer.Graphics

                     'Get the image Bounds
                     Dim ImageLeadRect As LeadRect = _viewerControl.RasterImageViewer.ImageBounds

                     'Set the destination rectangle that will be used to burn the stamp object
                     Dim destRect As LeadRectD = LeadRectD.Create(ImageLeadRect.X, ImageLeadRect.Y, ImageLeadRect.Width * 720.0 / 96.0, ImageLeadRect.Height * 720.0 / 96.0)

                     'Create a Temp Annotation container to hold the stamp object
                     Dim stampContainer As AnnContainer = container.Clone()

                     'Remove all objects from the current , and leave the stamp object only 
                     stampContainer.Children.Clear()
                     Dim stampObject As AnnObject = Nothing

                     For Each annObject As AnnObject In container.Children
                        If annObject.Id = annObject.StampObjectId Then
                           stampObject = annObject.Clone()
                           Exit For
                        End If
                     Next

                     If stampObject IsNot Nothing Then
                        stampContainer.Children.Add(stampObject)
                     End If

                     Dim engine As New AnnWinFormsRenderingEngine()
                     engine.Attach(stampContainer, PageG)
                     engine.BurnToRectWithDpi(destRect, 96, 96, 96, 96)
                     engine.Detach()

                     stampContainer.Children.Clear()
                     stampContainer = Nothing

                     ' Add it as a PDF page
                     _documentWriterInstance.AddPage(page__1)
                  End If

                  i += 1
               Next

               _documentWriterInstance.EndDocument()
            End Using

            'Convert our Annotations to PDF annotations, and then save them to our PDF file
            SaveDocument2(fileName, pdfOptions)

            'restore the page number
            _viewerControl.SetCurrentPageNumber(currentPageNumber)

         Catch ex As Exception
            _documentWriterInstance.EndDocument()
            Messager.ShowError(Me, ex)
         Finally
            ' Clean up by deleteing all the temporay files
            For Each tempFileName As String In emfFileNames
               If File.Exists(tempFileName) Then
                  Try
                     File.Delete(tempFileName)
                  Catch
                  End Try
               End If
            Next
         End Try
      End Sub


      Public Sub SaveDocument2(fileName As String, pdfOptions As PdfDocumentOptions)
         Dim automation As AnnAutomation = _viewerControl.Automation
         Dim fileAnnotations As New List(Of PDFAnnotation)()

         Dim pdfDocument As New PDFDocument(fileName, If(Not String.IsNullOrEmpty(pdfOptions.OwnerPassword), pdfOptions.OwnerPassword, If(Not String.IsNullOrEmpty(pdfOptions.UserPassword), pdfOptions.UserPassword, Nothing)))
         Dim count As Integer = 1

         ' Loop through the containers
         For Each container As AnnContainer In automation.Containers
            ' Get a list of all the annotations in this document
            Dim pageAnnotations As New List(Of PDFAnnotation)()
            AnnPDFConvertor.ConvertToPDF(container, pageAnnotations, pdfDocument.Pages(automation.Containers.IndexOf(container)).Height)
            'Change the page number of each PDFAnnotation to match the reference page
            For Each PDFAnnObj As PDFAnnotation In pageAnnotations
               PDFAnnObj.PageNumber = count
            Next

            fileAnnotations.AddRange(pageAnnotations)

            count += 1
         Next

         ' Make the file writable if exists
         If File.Exists(fileName) Then
            MakeWriteable(fileName)
         End If

         ' Load the original file in a PDFFile object
         Dim pdfFile As New PDFFile(fileName, If(Not String.IsNullOrEmpty(pdfOptions.OwnerPassword), pdfOptions.OwnerPassword, If(Not String.IsNullOrEmpty(pdfOptions.UserPassword), pdfOptions.UserPassword, Nothing)))

         If fileAnnotations.Count > 0 Then
            pdfFile.WriteAnnotations(fileAnnotations, fileName)
         End If

         ' PDF Compatibility Level
         Select Case pdfOptions.DocumentType
            Case PdfDocumentType.Pdf
               pdfFile.CompatibilityLevel = PDFCompatibilityLevel.Default
               Exit Select
            Case PdfDocumentType.PdfA
               pdfFile.CompatibilityLevel = PDFCompatibilityLevel.PDFA
               Exit Select
            Case PdfDocumentType.Pdf12
               pdfFile.CompatibilityLevel = PDFCompatibilityLevel.PDF12
               Exit Select
            Case PdfDocumentType.Pdf13
               pdfFile.CompatibilityLevel = PDFCompatibilityLevel.PDF13
               Exit Select
            Case PdfDocumentType.Pdf15
               pdfFile.CompatibilityLevel = PDFCompatibilityLevel.PDF15
               Exit Select
         End Select

         ' PDF Document Properties
         pdfFile.DocumentProperties = New PDFDocumentProperties()
         pdfFile.DocumentProperties.Author = pdfOptions.Author
         pdfFile.DocumentProperties.Creator = pdfOptions.Creator
         pdfFile.DocumentProperties.Keywords = pdfOptions.Keywords
         pdfFile.DocumentProperties.Producer = pdfOptions.Producer
         pdfFile.DocumentProperties.Subject = pdfOptions.Subject
         pdfFile.DocumentProperties.Title = pdfOptions.Title

         ' PDF Initial View Options
         pdfFile.InitialViewOptions = New PDFInitialViewOptions()
         pdfFile.InitialViewOptions.CenterWindow = pdfOptions.CenterWindow
         pdfFile.InitialViewOptions.DisplayDocTitle = pdfOptions.DisplayDocTitle
         pdfFile.InitialViewOptions.FitWindow = pdfOptions.FitWindow
         pdfFile.InitialViewOptions.HideMenubar = pdfOptions.HideMenubar
         pdfFile.InitialViewOptions.HideToolbar = pdfOptions.HideToolbar
         pdfFile.InitialViewOptions.HideWindowUI = pdfOptions.HideWindowUI
         pdfFile.InitialViewOptions.PageFitType = CType(pdfOptions.PageFitType, PDFPageFitType)
         pdfFile.InitialViewOptions.PageLayoutType = CType(pdfOptions.PageLayoutType, PDFPageLayoutType)
         pdfFile.InitialViewOptions.PageModeType = CType(pdfOptions.PageModeType, PDFPageModeType)
         pdfFile.InitialViewOptions.PageNumber = pdfOptions.InitialPageNumber
         pdfFile.InitialViewOptions.Position = New PDFPoint(pdfOptions.XCoordinate, pdfOptions.YCoordinate)
         pdfFile.InitialViewOptions.ZoomPercent = pdfOptions.ZoomPercent

         ' PDF Security Options
         If (pdfOptions.Protected) Then
            pdfFile.SecurityOptions = New PDFSecurityOptions()
            pdfFile.SecurityOptions.AnnotationsEnabled = pdfOptions.AnnotationsEnabled
            pdfFile.SecurityOptions.AssemblyEnabled = pdfOptions.AssemblyEnabled
            pdfFile.SecurityOptions.CopyEnabled = pdfOptions.CopyEnabled
            pdfFile.SecurityOptions.CopyForAccessibilityEnabled = pdfOptions.CopyEnabled
            pdfFile.SecurityOptions.EditEnabled = pdfOptions.EditEnabled
            pdfFile.SecurityOptions.EncryptionMode = CType(pdfOptions.EncryptionMode, PDFEncryptionMode)
            pdfFile.SecurityOptions.HighQualityPrintEnabled = pdfOptions.HighQualityPrintEnabled
            pdfFile.SecurityOptions.PrintEnabled = pdfOptions.PrintEnabled
            pdfFile.SecurityOptions.OwnerPassword = pdfOptions.OwnerPassword
            pdfFile.SecurityOptions.UserPassword = pdfOptions.UserPassword
         End If

         pdfFile.SetDocumentProperties(fileName)
         pdfFile.SetInitialView(fileName)

         pdfFile.Convert(1, -1, fileName)

         ' If the user wanted Fast Web (linearized), then we need to re-optimize the file
         If pdfOptions.Linearized Then
            pdfFile.Linearize(fileName)
         End If
      End Sub

      Private Sub MakeWriteable(fileName As String)
         ' Remove read-only if there
         Dim attr As FileAttributes = File.GetAttributes(fileName)
         attr = attr And Not FileAttributes.ReadOnly
         File.SetAttributes(fileName, attr)
      End Sub

      Private Sub _viewFitWidthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _viewFitWidthToolStripMenuItem.Click
         _viewerControl.FitPage(True)
      End Sub

      Private Sub _viewFitPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _viewFitPageToolStripMenuItem.Click
         _viewerControl.FitPage(False)
      End Sub

      Private Sub _viewZoomOutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _viewZoomOutToolStripMenuItem.Click
         _viewerControl.ZoomViewer(True)
      End Sub

      Private Sub _viewZoomInToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _viewZoomInToolStripMenuItem.Click
         _viewerControl.ZoomViewer(False)
      End Sub

      Private Sub _fileOpenRtfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _fileOpenRtfToolStripMenuItem.Click
         Dim automation As AnnAutomation = _viewerControl.Automation

         Dim rasterizeDocOptions As RasterDialogRasterizeDocumentFileOptions
         Using codecs As New RasterCodecs()
            Using ofd As New RasterOpenDialog(codecs)
               ofd.DereferenceLinks = True
               ofd.CheckFileExists = True
               ofd.CheckPathExists = True
               ofd.EnableSizing = True

               ofd.Filter = New RasterOpenDialogLoadFormat(0) {New RasterOpenDialogLoadFormat("Rich Text Format", "*.rtf")}
               ofd.LoadFileImage = False
               ofd.ShowLoadOptions = True
               ofd.ShowRasterizeDocumentOptions = True
               ofd.ShowPreview = True
               ofd.ShowRasterOptions = True
               ofd.ShowTotalPages = True
               ofd.ShowFileInformation = True
               ofd.UseFileStamptoPreview = True
               ofd.PreviewWindowVisible = True
               ofd.Multiselect = False
               ofd.Title = "LEADTOOLS Open Dialog"

               If ofd.ShowDialog(Me) = DialogResult.OK Then
                  Dim convertFactor As Double

                  _isRtfLoaded = True
                  _isEmfLoaded = False
                  rasterizeDocOptions = ofd.OpenedFileData(0).Options.RasterizeDocumentOptions

                  _rtfFileName = ofd.FileName
                  If rasterizeDocOptions.XResolution = 0 Then
                     rasterizeDocOptions.XResolution = 96
                  End If
                  If rasterizeDocOptions.YResolution = 0 Then
                     rasterizeDocOptions.YResolution = 96
                  End If

                  If rasterizeDocOptions.Unit = CodecsRasterizeDocumentUnit.Millimeter Then
                     convertFactor = 1.0 / 25.4
                     ' convert from millimeters to inches
                  ElseIf rasterizeDocOptions.Unit = CodecsRasterizeDocumentUnit.Pixel Then
                     convertFactor = 1.0 / rasterizeDocOptions.XResolution
                  Else
                     ' convert from pixels to inches
                     convertFactor = 1.0
                  End If
                  ' inches
                  rasterizeDocOptions.Unit = CodecsRasterizeDocumentUnit.Inch
                  rasterizeDocOptions.TopMargin *= convertFactor
                  rasterizeDocOptions.BottomMargin *= convertFactor
                  rasterizeDocOptions.LeftMargin *= convertFactor
                  rasterizeDocOptions.RightMargin *= convertFactor
                  rasterizeDocOptions.PageHeight *= convertFactor
                  rasterizeDocOptions.PageWidth *= convertFactor
                  'Force loading all pages
                  codecs.Options.Load.AllPages = True

                  _rasterizeDocOptions = rasterizeDocOptions
                  Using rasterImage As RasterImage = codecs.Load(_rtfFileName)
                     NewDocument(CSng(_rasterizeDocOptions.PageWidth), CSng(_rasterizeDocOptions.PageHeight), _rasterizeDocOptions.XResolution, _rasterizeDocOptions.YResolution)
                     Using wait As New WaitCursor()
                        ' Add rtf pages as stamps
                        Dim i As Integer

                        For i = 0 To rasterImage.PageCount - 2
                           AddNewPage()
                        Next
                        _rtfDictionary = New Dictionary(Of Integer, Integer)()



                        For i = 0 To rasterImage.PageCount - 1
                           Dim stamp As AnnStampObject
                           rasterImage.Page = i + 1
                           stamp = New AnnStampObject()
                           stamp.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Blue"), LeadLengthD.Create(4))
                           stamp.IsVisible = True
                           stamp.Rect = New LeadRectD(automation.Container.Size)
                           stamp.Font = New AnnFont("Arial", 48)
                           stamp.Font.FontStyle = AnnFontStyle.Normal
                           Using Mem As New MemoryStream()
                              codecs.Save(rasterImage, Mem, RasterImageFormat.Jpeg, 24)
                              Mem.Seek(0, SeekOrigin.Begin)
                              stamp.Picture = New AnnPicture(Mem.ToArray())
                           End Using
                           stamp.Lock(_rtfFileName)
                           stamp.Tag = _rtfEmfStampTag
                           automation.Containers(i).Children.Clear()
                           automation.Containers(i).Children.Add(stamp)
                           _rtfDictionary.Add(i + 1, i)
                        Next
                     End Using
                  End Using


                  GotoPage(1)
               End If
            End Using
         End Using
      End Sub


      Private Function PrepareAnnotationsContainer(container As AnnContainer) As AnnContainer
         Dim tempContainer As AnnContainer = CType(container.Clone(), AnnContainer)
         Dim j As Integer = 0

         ' Remove Rtf stamps since each Rtf page is atteched to document writer as emf
         While j < tempContainer.Children.Count
            Dim obj As AnnObject = tempContainer.Children(j)
            If TypeOf obj Is AnnStampObject Then
               Dim stamp As AnnStampObject = TryCast(obj, AnnStampObject)
               If CInt(stamp.Tag) = _rtfEmfStampTag Then
                  stamp.Picture.Source = Nothing
                  tempContainer.Children.Remove(obj)
                  j -= 1
               End If
            End If
            j += 1
         End While

         Return tempContainer
      End Function


      Private Sub _fileOpenEmfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _fileOpenEmfToolStripMenuItem.Click

         Dim pageWidth As Single, pageHeight As Single
         Dim dpiX As Integer, dpiY As Integer

         Using codecs As New RasterCodecs()
            Using ofd As New RasterOpenDialog(codecs)
               ofd.DereferenceLinks = True
               ofd.CheckFileExists = True
               ofd.CheckPathExists = True
               ofd.EnableSizing = True

               ofd.Filter = New RasterOpenDialogLoadFormat(0) {New RasterOpenDialogLoadFormat("Enhanced Metafile", "*.emf")}
               ofd.LoadFileImage = False
               ofd.ShowLoadOptions = True
               ofd.ShowPreview = True
               ofd.ShowTotalPages = True
               ofd.ShowFileInformation = True
               ofd.UseFileStamptoPreview = True
               ofd.PreviewWindowVisible = True
               ofd.Multiselect = True
               ofd.Title = "LEADTOOLS Open Dialog"

               If ofd.ShowDialog(Me) = DialogResult.OK Then
                  _viewerControl.Automation.Containers.Clear()
                  _isRtfLoaded = False
                  _isEmfLoaded = True
                  _emfFileNames = New Dictionary(Of Integer, String)()

                  Dim i As Integer = 0
                  For Each item As RasterDialogFileData In ofd.OpenedFileData
                     dpiX = If(item.FileInfo.XResolution > 0, item.FileInfo.XResolution, 96)
                     dpiY = If(item.FileInfo.YResolution > 0, item.FileInfo.YResolution, 96)
                     pageWidth = CSng(item.FileInfo.Width) / dpiX
                     ' Page width in inches
                     pageHeight = CSng(item.FileInfo.Height) / dpiY
                     ' Page height in inches
                     If i = 0 Then
                        NewDocument(pageWidth, pageHeight, dpiX, dpiY)
                     Else
                        AddNewPage(pageWidth, pageHeight, dpiX, dpiY)
                     End If

                     Using wait As New WaitCursor()
                        ' Add emf pages as stamps

                        Dim automation As AnnAutomation = _viewerControl.AutomationManager.Automations(_viewerControl.AutomationManager.Automations.Count - 1)
                        Dim stamp As AnnStampObject
                        stamp = New AnnStampObject()
                        stamp.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Blue"), LeadLengthD.Create(4))
                        stamp.IsVisible = True
                        stamp.Rect = New LeadRectD(automation.Container.Size)
                        stamp.Font = New AnnFont("Arial", 48)
                        stamp.Font.FontStyle = AnnFontStyle.Normal
                        Dim converter As New ImageConverter()
                        Using ms As New MemoryStream()
                           Dim StampPic As RasterImage = codecs.Load(item.Name)
                           codecs.Save(StampPic, ms, RasterImageFormat.Png, 24)
                           stamp.Picture = New AnnPicture(ms.ToArray())
                           StampPic.Dispose()
                           StampPic = Nothing
                        End Using
                        stamp.Lock(item.Name)
                        stamp.Tag = _rtfEmfStampTag
                        _emfFileNames.Add(i + 1, item.Name)
                        automation.Container.Children.Add(stamp)
                     End Using
                     i += 1
                  Next
                  GotoPage(1)
                  _pagesControl.RasterImageList.Invalidate()
               End If
            End Using
         End Using
      End Sub
      Private Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
         target = value
         Return value
      End Function
   End Class
End Namespace
