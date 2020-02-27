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
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Document.Writer
Imports Leadtools.Annotations.Rendering
Imports Leadtools.Drawing
Imports System

Namespace DocumentWritersDemo
   ''' <summary>
   ''' This control contains an instance of RasterImageList plus
   ''' a tool strip control for common operations
   ''' </summary>
   Partial Public Class PagesControl : Inherits UserControl
      ' The automation manager object
      Private _automationManager As AnnAutomationManager
      Private _automation As AnnAutomation
      Private _viewerImage As RasterImage = Nothing
      Private _insertBookmaksForm As InsertBookmarkForm = Nothing
      Private _bookmarkPosition As Point = Point.Empty


      Public Sub New()
         InitializeComponent()

         UpdateUIState()
      End Sub

      ''' <summary>
      ''' Called by the main form to tie the automation manager to the object in the viewer control
      ''' </summary>
      Public Sub SetAutomation(automationManager As AnnAutomationManager, automation As AnnAutomation)
         _automationManager = automationManager
         _automation = automation
      End Sub

      ''' <summary>
      ''' The image list control is needed by the main form
      ''' </summary>
      Public ReadOnly Property RasterImageList() As ImageViewer
         Get
            Return _rasterImageList
         End Get
      End Property

      ''' <summary>
      ''' The image list control is needed by the main form
      ''' </summary>
      Public ReadOnly Property PdfBookmarksList() As TreeView
         Get
            Return _treeBookmarks
         End Get
      End Property

      Public Property ViewerImage() As RasterImage
         Get
            Return _viewerImage
         End Get
         Set(value As RasterImage)
            _viewerImage = value
         End Set
      End Property

      ''' <summary>
      ''' Called from the main form when the user changes the page number
      ''' from outside this control (main menu or the viewer control)
      ''' </summary>
      Public Sub SetCurrentPageNumber(pageNumber As Integer)
         If pageNumber <> CurrentPageNumber AndAlso pageNumber <= _rasterImageList.Items.Count Then
            ' De-select all items but 'pageNumber'

            _rasterImageList.BeginUpdate()

            For i As Integer = 0 To _rasterImageList.Items.Count - 1
               Dim item As ImageViewerItem = _rasterImageList.Items(i)

               If i = (pageNumber - 1) Then
                  item.IsSelected = True
               Else
                  item.IsSelected = False
               End If
            Next

            _rasterImageList.EnsureItemVisibleByIndex(pageNumber - 1)
            _rasterImageList.EndUpdate()
         End If

         UpdateUIState()
      End Sub

      ''' <summary>
      ''' Called by the main form to delete the current selected page
      ''' </summary>
      Public Sub DeleteCurrentPage()
         Dim pageNumber As Integer = CurrentPageNumber
         _rasterImageList.Items.RemoveAt(pageNumber - 1)
      End Sub

      ''' <summary>
      ''' Called by the main form to update the UI state
      ''' </summary>
      Public Sub UpdateUIState()

         ' Update the UI based on the state of the control
         Dim pageCount As Integer = _rasterImageList.Items.Count
         _deleteCurrentPageToolStripButton.Enabled = pageCount > 0

         Dim pageNumber As Integer = CurrentPageNumber
         _deleteCurrentPageToolStripButton.Enabled = pageCount > 1
         _movePageUpToolStripButton.Enabled = pageCount > 0 AndAlso pageNumber > 1
         _movePageDownToolStripButton.Enabled = pageCount > 0 AndAlso pageNumber < pageCount

         ' Update the bookmarks tool strip items
         _deleteToolStripDropDownButton.Enabled = _treeBookmarks.SelectedNode IsNot Nothing
         _deleteSelectedBookmarkToolStripMenuItem.Enabled = _treeBookmarks.SelectedNode IsNot Nothing
         _clearAllBookmarksToolStripMenuItem.Enabled = _treeBookmarks.Nodes.Count > 0
         _bookmarkPropertiesToolStripButton.Enabled = _treeBookmarks.SelectedNode IsNot Nothing
      End Sub

      ''' <summary>
      ''' Any action that happens in this control that must be handled by the owner
      ''' For example, any of the tool strip buttons clicked
      ''' </summary>
      Public Event Action As EventHandler(Of ActionEventArgs)
      Public ReadOnly Property CurrentPageNumber() As Integer
         Get
            ' Find the first selected item in the image list, it is
            ' a single selection control
            For i As Integer = 0 To _rasterImageList.Items.Count - 1
               If _rasterImageList.Items(i).IsSelected Then
                  Return i + 1
               End If
            Next

            ' No items
            Return -1
         End Get
      End Property

      Private Sub _rasterImageList_SelectedIndexChanged(sender As Object, e As EventArgs)
         Dim pageNumber As Integer = CurrentPageNumber
         DoAction("PageNumberChanged", pageNumber)
         UpdateUIState()
      End Sub

      Private Sub _newPageToolStripButton_Click(sender As Object, e As EventArgs) Handles _newPageToolStripButton.Click
         DoAction("NewPage", Nothing)
      End Sub

      Private Sub _deleteCurrentPageToolStripButton_Click(sender As Object, e As EventArgs) Handles _deleteCurrentPageToolStripButton.Click
         DoAction("DeletePage", Nothing)
      End Sub

      Private Sub _movePageUpToolStripButton_Click(sender As Object, e As EventArgs) Handles _movePageUpToolStripButton.Click
         DoAction("MovePageUp", Nothing)
      End Sub

      Private Sub _movePageDownToolStripButton_Click(sender As Object, e As EventArgs) Handles _movePageDownToolStripButton.Click
         DoAction("MovePageDown", Nothing)
      End Sub

      Private Sub DoAction(action As String, data As Object)
         ' Raise the action event so the main form can handle it

         RaiseEvent Action(Me, New ActionEventArgs(action, data))
      End Sub

      Private Sub _rasterImageList_PostRender(sender As Object, e As ImageViewerRenderEventArgs) Handles _rasterImageList.PostRender

         For i As Integer = 0 To _rasterImageList.Items.Count - 1
            Dim item As ImageViewerItem = _rasterImageList.Items(i)

            Dim itemLeadRect As LeadRectD = _rasterImageList.GetItemBounds(item, ImageViewerItemPart.Item)
            Dim itemRect As New Rectangle(CInt(itemLeadRect.X), CInt(itemLeadRect.Y), CInt(itemLeadRect.Width), CInt(itemLeadRect.Height))
            Dim itemImageSize As LeadSize = _rasterImageList.GetItemImageSize(item, False)

            Dim imageRect As New LeadRect(itemRect.Left + (itemRect.Width - itemImageSize.Width) \ 2, itemRect.Top + (itemRect.Height - itemImageSize.Height) \ 2, itemImageSize.Width, itemImageSize.Height)

            itemLeadRect = ImageViewer.GetDestinationRectangle(item.Image.ImageWidth, item.Image.ImageHeight, imageRect, ControlSizeMode.None, ControlAlignment.Near, ControlAlignment.Near).ToLeadRectD()

            Dim destRect As LeadRectD = LeadRectD.Create(itemLeadRect.X, itemLeadRect.Y, itemLeadRect.Width * 720.0 / 96.0, itemLeadRect.Height * 720.0 / 96.0)

            destRect.X = 0.0
            destRect.Y = 0.0

            'Get the graphic object from the item's image to draw (burn) annotations on it.
            Dim GdiPlusGraphicsContainer As RasterImageGdiPlusGraphicsContainer = New RasterImageGdiPlusGraphicsContainer(item.Image)
            Dim g As Graphics = GdiPlusGraphicsContainer.Graphics

            ' Use anti-aliasing
            g.SmoothingMode = SmoothingMode.AntiAlias

            ' We show the text on the items, get the text height
            Dim textHeight As Integer = CInt(Math.Truncate(g.MeasureString("WWW", _rasterImageList.Font).Height + 4))

            ' Now draw the annotation s on this rectangle
            If _automationManager IsNot Nothing AndAlso _automation.Containers.Count > 0 AndAlso _automation.Containers.Count > i Then
               Dim container As AnnContainer = _automation.Containers(i)

               'Clear the old painting
               g.Clear(Color.White)

               'Burn the current annotations to the image list item
               If container IsNot Nothing Then
                  Dim engine As New AnnWinFormsRenderingEngine()
                  engine.Resources = _automationManager.Resources

                  engine.Attach(container, g)
                  engine.BurnToRectWithDpi(destRect, 96, 96, 96, 96)
                  engine.Detach()
               End If
            End If
         Next
      End Sub

      Private Sub _rasterImageList_SelectedItemsChanged(sender As Object, e As System.EventArgs) Handles _rasterImageList.SelectedItemsChanged
         Dim pageNumber As Integer = CurrentPageNumber

         If pageNumber <> -1 Then
            DoAction("PageNumberChanged", pageNumber)
            UpdateUIState()
         End If
      End Sub


      Public Property BookmarkPosition() As Point
         Get
            Return _bookmarkPosition
         End Get
         Set(value As Point)
            _bookmarkPosition = value

            If _insertBookmaksForm IsNot Nothing AndAlso _insertBookmaksForm.Visible Then
               _insertBookmaksForm.PositionX.Text = _bookmarkPosition.X.ToString()
               _insertBookmaksForm.PositionY.Text = _bookmarkPosition.Y.ToString()
            End If
         End Set
      End Property

      Private Function GetDefaultPdfBookmark(node As TreeNode) As PdfCustomBookmark
         Dim pdfBookmark As New PdfCustomBookmark()
         pdfBookmark.Name = node.Text
         pdfBookmark.LevelNumber = node.Level
         pdfBookmark.PageNumber = CurrentPageNumber
         pdfBookmark.XCoordinate = 0
         pdfBookmark.YCoordinate = 0

         Return pdfBookmark
      End Function

      Private Sub ShowBookmarksDialog(node As TreeNode)
         Dim page As RasterImage = CType(_rasterImageList.Items.GetSelected()(0).Tag, RasterImage)
         _insertBookmaksForm = New InsertBookmarkForm(node, _rasterImageList.Items.Count, CurrentPageNumber - 1, page.Width, page.Height)
         AddHandler _insertBookmaksForm.Action, AddressOf _insertBookmaksForm_Action
         _insertBookmaksForm.Show(Me)
      End Sub

      Private Sub _insertBookmaksForm_Action(sender As Object, e As ActionEventArgs)
         Dim pageNumber As Integer = CInt(e.Data)
         DoAction("PageNumberChanged", pageNumber)
      End Sub



      Private Sub _insertBookmarkAfterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _insertBookmarkAfterToolStripMenuItem.Click, _insertBookmarkAfterMenuItem.Click

         _treeBookmarks.Focus()

         Dim selectedNode As TreeNode = _treeBookmarks.SelectedNode
         If selectedNode Is Nothing Then
            selectedNode = _treeBookmarks.Nodes.Add("Untitled")
         Else
            If selectedNode.Parent Is Nothing Then
               selectedNode = _treeBookmarks.Nodes.Insert(selectedNode.Index + 1, "Untitled")
            Else
               selectedNode = selectedNode.Parent.Nodes.Insert(selectedNode.Index + 1, "Untitled")
            End If
         End If

         Dim pdfBookmark As PdfCustomBookmark = GetDefaultPdfBookmark(selectedNode)
         selectedNode.Tag = pdfBookmark
         _treeBookmarks.SelectedNode = selectedNode

         ShowBookmarksDialog(_treeBookmarks.SelectedNode)
         UpdateUIState()

      End Sub

      Private Sub _insertBookmarkBeforeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _insertBookmarkBeforeToolStripMenuItem.Click, _insertBookmarkBeforeMenuItem.Click

         _treeBookmarks.Focus()

         Dim selectedNode As TreeNode = _treeBookmarks.SelectedNode
         If selectedNode Is Nothing Then
            selectedNode = _treeBookmarks.Nodes.Add("Untitled")
         Else
            If selectedNode.Parent Is Nothing Then
               selectedNode = _treeBookmarks.Nodes.Insert(selectedNode.Index, "Untitled")
            Else
               selectedNode = selectedNode.Parent.Nodes.Insert(selectedNode.Index, "Untitled")
            End If
         End If

         Dim pdfBookmark As PdfCustomBookmark = GetDefaultPdfBookmark(selectedNode)
         selectedNode.Tag = pdfBookmark
         _treeBookmarks.SelectedNode = selectedNode

         ShowBookmarksDialog(_treeBookmarks.SelectedNode)
         UpdateUIState()

      End Sub

      Private Sub _insertChildBookmarkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _insertChildBookmarkToolStripMenuItem.Click, _insertChildBookmarkMenuItem.Click

         _treeBookmarks.Focus()

         Dim selectedNode As TreeNode = _treeBookmarks.SelectedNode
         If selectedNode Is Nothing Then
            selectedNode = _treeBookmarks.Nodes.Add("Untitled")
         Else
            selectedNode = selectedNode.Nodes.Add("Untitled")
         End If

         Dim pdfBookmark As PdfCustomBookmark = GetDefaultPdfBookmark(selectedNode)
         selectedNode.Tag = pdfBookmark
         _treeBookmarks.SelectedNode = selectedNode

         ShowBookmarksDialog(_treeBookmarks.SelectedNode)
         UpdateUIState()

      End Sub

      Private Sub _deleteSelectedBookmarkToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _deleteSelectedBookmarkToolStripMenuItem.Click, _deleteBookmarkMenuItem.Click

         Dim selectedNode As TreeNode = _treeBookmarks.SelectedNode
         If selectedNode IsNot Nothing Then
            Dim index As Integer = selectedNode.Index
            _treeBookmarks.Nodes.Remove(selectedNode)
            If _treeBookmarks.Nodes.Count > index Then
               _treeBookmarks.SelectedNode = _treeBookmarks.Nodes(index)
            End If
         End If

         UpdateUIState()

      End Sub

      Private Sub _clearAllBookmarksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _clearAllBookmarksToolStripMenuItem.Click

         _treeBookmarks.Nodes.Clear()
         UpdateUIState()

      End Sub

      Private Sub _bookmarkPropertiesToolStripButton_Click(sender As Object, e As EventArgs) Handles _bookmarkPropertiesToolStripButton.Click, _bookmarkPropertiesMenuItem.Click

         If _treeBookmarks.SelectedNode IsNot Nothing Then
            ShowBookmarksDialog(_treeBookmarks.SelectedNode)
         End If

      End Sub

      Private Sub _treeBookmarks_MouseDown(sender As Object, e As MouseEventArgs) Handles _treeBookmarks.MouseDown
         If e.Button = MouseButtons.Right Then
            ' Show the context menu.
            _contextMenuBookmarks.Show(CType(sender, TreeView), e.X, e.Y)
         End If
      End Sub

      Private Sub _treeBookmarks_Click(sender As Object, e As EventArgs) Handles _treeBookmarks.Click

         Dim mouseArgs As MouseEventArgs = CType(e, MouseEventArgs)
         If mouseArgs.Button <> MouseButtons.Right Then
            Dim selectedNode As TreeNode = _treeBookmarks.GetNodeAt(mouseArgs.X, mouseArgs.Y)
            If selectedNode IsNot Nothing AndAlso selectedNode.Tag IsNot Nothing Then
               Dim pdfBookmark As PdfCustomBookmark = CType(selectedNode.Tag, PdfCustomBookmark)
               If pdfBookmark.PageNumber > _rasterImageList.Items.Count Then
                  MessageBox.Show("The page this bookmark points to was deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                  Return
               End If
               DoAction("CenterAtPoint", pdfBookmark)
            End If
         End If

      End Sub
   End Class
End Namespace
