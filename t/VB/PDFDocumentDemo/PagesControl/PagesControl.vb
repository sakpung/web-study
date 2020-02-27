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
Imports Microsoft.VisualBasic

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Drawing
Imports Leadtools.Pdf
Imports System

Namespace PDFDocumentDemo.PagesControl
   Partial Public Class PagesControl
      Inherits UserControl
      Private _generateThumbnailsWorker As Workers.GenerateThumbnailsWorker

      Public Sub New()
         InitializeComponent()

         ' Use GDI+ paint
         Dim props As RasterPaintProperties = _rasterImageList.PaintProperties
         props.PaintEngine = RasterPaintEngine.GdiPlus
         _rasterImageList.PaintProperties = props

         _thumbnailsToolStripButton.Checked = True
         _bookmarksToolStripButton.Checked = False
         _signaturesToolStripButton.Checked = False

         ' This object generates the thumbnails for the pages in a separate thread
         _generateThumbnailsWorker = New Workers.GenerateThumbnailsWorker()
         AddHandler _generateThumbnailsWorker.PrePageProcessed, AddressOf _generateThumbnailsWorker_PrePageProcessed
         AddHandler _generateThumbnailsWorker.PostPageProcessed, AddressOf _generateThumbnailsWorker_PostPageProcessed
         AddHandler _generateThumbnailsWorker.ProcessFinished, AddressOf _generateThumbnailsWorker_ProcessFinished

         UpdateUIState()
      End Sub

      Private Sub Cleanup(disposing As Boolean)
         If disposing Then
            If _generateThumbnailsWorker IsNot Nothing Then
               _generateThumbnailsWorker.[Stop]()
               RemoveHandler _generateThumbnailsWorker.PostPageProcessed, AddressOf _generateThumbnailsWorker_PostPageProcessed
               RemoveHandler _generateThumbnailsWorker.PrePageProcessed, AddressOf _generateThumbnailsWorker_PrePageProcessed
               RemoveHandler _generateThumbnailsWorker.ProcessFinished, AddressOf _generateThumbnailsWorker_ProcessFinished
               _generateThumbnailsWorker.Dispose()
               _generateThumbnailsWorker = Nothing
            End If
         End If
      End Sub

#Region "Public"
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property RasterImageList() As ImageViewer
         Get
            Return _rasterImageList
         End Get
      End Property

      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property ShowThumbnails() As Boolean
         Get
            Return _thumbnailsToolStripButton.Checked
         End Get
      End Property

      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property ShowBookmarks() As Boolean
         Get
            Return _bookmarksToolStripButton.Checked
         End Get
      End Property

      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property ShowSignatures() As Boolean
         Get
            Return _signaturesToolStripButton.Checked
         End Get
      End Property

      Public Sub SetActiveTab(thumbnails As Boolean, bookmarks As Boolean, signatures As Boolean)
         _thumbnailsToolStripButton.Checked = thumbnails
         _bookmarksToolStripButton.Checked = bookmarks
         _signaturesToolStripButton.Checked = signatures

         UpdateUIState()

      End Sub

      Private Sub UpdateUIState()
         If _thumbnailsToolStripButton.Checked Then
            _rasterImageList.Visible = True
            _bookmarksTreeView.Visible = False
            _noBookmarksLabel.Visible = False
            _signaturesTreeView.Visible = False
            _noSignaturesLabel.Visible = False
         ElseIf _bookmarksToolStripButton.Checked Then
            _rasterImageList.Visible = False
            Dim hasBookmarks As Boolean = _bookmarksTreeView.Nodes.Count > 0
            _bookmarksTreeView.Visible = hasBookmarks
            _noBookmarksLabel.Visible = Not hasBookmarks
            _signaturesTreeView.Visible = False
            _noSignaturesLabel.Visible = False
         Else
            _rasterImageList.Visible = False
            _bookmarksTreeView.Visible = False
            _noBookmarksLabel.Visible = False
            Dim hasSignatures As Boolean = _signaturesTreeView.Nodes.Count > 0
            _signaturesTreeView.Visible = hasSignatures
            _noSignaturesLabel.Visible = Not hasSignatures
         End If
      End Sub

      Public Sub SetDocument(document As PDFDocument)
         _rasterImageList.BeginUpdate()
         _bookmarksTreeView.BeginUpdate()
         _signaturesTreeView.BeginUpdate()

         _rasterImageList.Items.Clear()
         _bookmarksTreeView.Nodes.Clear()
         _signaturesTreeView.Nodes.Clear()

         ' This is the image we will load till the thumbnails are loaded
         Using loadingThumbnailBitmap As Bitmap = Global.PDFDocumentDemo.Resources.LoadingThumbnail
            Using itemImage As RasterImage = RasterImageConverter.ConvertFromImage(loadingThumbnailBitmap, ConvertFromImageOptions.None)
               If document IsNot Nothing AndAlso document.Pages.Count >= 1 Then
                  For page As Integer = 1 To document.Pages.Count
                     ' We need to clone itemImage since the image list has AutoDisposeImages set to true
                     Dim item As New ImageViewerItem()
                     item.Image = itemImage.Clone()
                     item.PageNumber = page
                     item.Text = "Page " + page.ToString()
                     _rasterImageList.Items.Add(item)
                  Next
               End If
            End Using
         End Using

         ' Add the bookmarks (if any)
         If document IsNot Nothing AndAlso document.Bookmarks IsNot Nothing Then
            AddBookmarks(document.Bookmarks)
         End If
         ' Add the signatures (if any)
         If document IsNot Nothing Then
            AddSignatures(document)
         End If

         _rasterImageList.EndUpdate()
         _bookmarksTreeView.EndUpdate()
         _signaturesTreeView.EndUpdate()


         If document IsNot Nothing AndAlso document.Pages.Count >= 1 Then
            ' Start reading the thumbnails            
            _generateThumbnailsWorker.Start(document, _rasterImageList.GetItemImageSize(_rasterImageList.ActiveItem, True).Width, _rasterImageList.GetItemImageSize(_rasterImageList.ActiveItem, True).Height)
         End If

         UpdateUIState()
      End Sub

      Private Sub AddBookmarks(bookmarks As IList(Of PDFBookmark))
         Dim lastNode As TreeNode = Nothing
         Dim lastNodeLevel As Integer = 0

         For Each bookmark As PDFBookmark In bookmarks
            Dim node As New TreeNode(bookmark.Title)
            node.Tag = bookmark

            Dim sb As New StringBuilder()
            sb.AppendFormat("Level: {0}" & vbLf, bookmark.Level)
            sb.AppendFormat("Target page number: {0}" & Constants.vbLf, bookmark.TargetPageNumber)
            sb.AppendFormat("Target X/Y: {0}, {1}" & Constants.vbLf, bookmark.TargetPosition.X, bookmark.TargetPosition.Y)
            sb.AppendFormat("Target Zoom: {0}%" & Constants.vbLf, bookmark.TargetZoomPercent)
            sb.AppendFormat("Target Page Fit: {0}" & Constants.vbLf, bookmark.TargetPageFitType.ToString())
            sb.AppendFormat("Style: {0}", bookmark.BookmarkStyle.ToString())

            node.ToolTipText = sb.ToString()

            ' This code takes care of PDF files that might have bookmarks with levels
            ' that are not right: previous/next node level is homogeneous

            If bookmark.Level = lastNodeLevel Then
               ' Same as last level
               AddNode(_bookmarksTreeView, lastNode, node, True)
            ElseIf bookmark.Level > lastNodeLevel Then
               ' Add it as a child

               ' Add empty nodes if the difference is greater than 1
               For i As Integer = lastNodeLevel + 1 To bookmark.Level - 1
                  Dim emptyNode As New TreeNode("Missing")
                  ' These nodes do not have a bookmarks
                  emptyNode.Tag = Nothing

                  AddNode(_bookmarksTreeView, lastNode, emptyNode, False)

                  lastNode = emptyNode
               Next

               ' Now add it as a child
               AddNode(_bookmarksTreeView, lastNode, node, False)
            Else
               ' Move up

               ' Go back to the last level equal to our level
               Dim i As Integer = bookmark.Level
               While i < lastNodeLevel AndAlso lastNode IsNot Nothing
                  lastNode = lastNode.Parent
                  i += 1
               End While

               ' Now add it as a sibling
               AddNode(_bookmarksTreeView, lastNode, node, True)
            End If

            lastNode = node
            lastNodeLevel = node.Level
         Next
      End Sub


      Private Sub AddSignatures(document As PDFDocument)
         For i As Integer = 0 To document.Pages.Count - 1
            If document.Pages(i).Signatures Is Nothing Then
               Continue For
            End If

            For Each signature As PDFSignature In document.Pages(i).Signatures
               ' Create Parent Node
               Dim title As String = String.Format("Signed By {0}", PDFSignaturesHelper.GetSubstring(signature.CertificateInfo("Subject"), "/CN=", "/"))

               Dim signatureNode As New TreeNode(title)

               AddNode(_signaturesTreeView, Nothing, signatureNode, False)

               ' Add Validity Node
               Dim validity As String = String.Format("Signature is {0}", PDFSignaturesHelper.GetState(signature.State))

               Dim validityNode As New TreeNode(validity)

               AddNode(_signaturesTreeView, signatureNode, validityNode, False)

               Dim info As String = "The Document has not been modified since this signature was applied."

               Dim validityInfoNode As New TreeNode(info)

               AddNode(_signaturesTreeView, validityNode, validityInfoNode, False)

               If signature.State = PDFSignature.StateUnknown Then
                  Dim unknownInfo As String = "The signer's identity is unknown because it not trusted identity."

                  Dim unknownInfoNode As New TreeNode(unknownInfo)

                  AddNode(_signaturesTreeView, validityNode, unknownInfoNode, False)
               End If

               ' Add details Node
               Dim details As String = String.Format("Signature Details...")

               Dim detailsNode As New TreeNode(details)

               AddNode(_signaturesTreeView, signatureNode, detailsNode, False)

               Dim certificateDetails As String = String.Format("Certificate Details...")

               Dim certificateDetailsNode As New TreeNode(certificateDetails)
               certificateDetailsNode.Tag = signature

               AddNode(_signaturesTreeView, detailsNode, certificateDetailsNode, False)
            Next
         Next
      End Sub

      Private Shared Sub AddNode(treeView As TreeView, relativeNode As TreeNode, node As TreeNode, sibling As Boolean)
         If sibling Then
            If relativeNode IsNot Nothing AndAlso relativeNode.Parent IsNot Nothing Then
               relativeNode.Parent.Nodes.Add(node)
            Else
               treeView.Nodes.Add(node)
            End If
         Else
            If relativeNode IsNot Nothing Then
               relativeNode.Nodes.Add(node)
            Else
               treeView.Nodes.Add(node)
            End If
         End If
      End Sub

      Private _ignoreSelectedChanged As Boolean = False

      Public Sub SetCurrentPageNumber(pageNumber As Integer)
         _ignoreSelectedChanged = True
         Dim pageIndex As Integer = pageNumber - 1

         ' De-select all items but 'pageIndex'

         _rasterImageList.BeginUpdate()

         For i As Integer = 0 To _rasterImageList.Items.Count - 1
            Dim item As ImageViewerItem = _rasterImageList.Items(i)

            If i = pageIndex Then
               item.IsSelected = True
            Else
               item.IsSelected = False
            End If
         Next

         _rasterImageList.EnsureItemVisibleByIndex(pageIndex)
         _rasterImageList.EndUpdate()
         _ignoreSelectedChanged = False
      End Sub

      Public Sub StopLoadingThumbnails()
         If _generateThumbnailsWorker IsNot Nothing Then
            _generateThumbnailsWorker.[Stop]()
         End If
      End Sub

      Public Event Action As EventHandler(Of ActionEventArgs)
#End Region

#Region "Private"
      Private Sub DoAction(action As String, data As Object)
         ' Raise the action event so the main form can handle it

         RaiseEvent Action(Me, New ActionEventArgs(action, data))
      End Sub

      Private ReadOnly Property CurrentPageNumber() As Integer
         Get
            ' Find the first selected item in the image list, it is
            ' a single selection control
            For i As Integer = 0 To _rasterImageList.Items.Count - 1
               If _rasterImageList.Items(i).IsSelected Then
                  Return i + 1
               End If
            Next

            ' No items
            Return 0
         End Get
      End Property

      Private Delegate Sub PageThumbnailDelegate(e As Workers.ThreadedPageWorkerPageProcessedEventArgs)

      Private Sub PreSetPageThumbnail(e As Workers.ThreadedPageWorkerPageProcessedEventArgs)
         _titleLabel.Text = String.Format("Page {0}...", e.PageNumber)
      End Sub

      Private Sub PostSetPageThumbnail(e As Workers.ThreadedPageWorkerPageProcessedEventArgs)
         Dim itemIndex As Integer = e.PageNumber - 1
         If itemIndex >= 0 AndAlso itemIndex < _rasterImageList.Items.Count Then
            Dim item As ImageViewerItem = _rasterImageList.Items(itemIndex)

            Dim image As RasterImage = TryCast(e.Data, RasterImage)
            If image Is Nothing OrElse e.[Error] IsNot Nothing Then
               ' Could no be loaded
               Using loadingThumbnailBitmap As Bitmap = Global.PDFDocumentDemo.Resources.ErrorThumbnail
                  image = RasterImageConverter.ConvertFromImage(loadingThumbnailBitmap, ConvertFromImageOptions.None)
               End Using
            End If

            item.Image = image
            _rasterImageList.Invalidate(True)
         End If
      End Sub

      Private Sub SetPageThumbnailsFinished()
         _titleLabel.Text = String.Empty
      End Sub

      Private Sub _generateThumbnailsWorker_PrePageProcessed(sender As Object, e As Workers.ThreadedPageWorkerPageProcessedEventArgs)
         ' This fires in the thumbnails generator thread context, so invoke our updates
         BeginInvoke(New PageThumbnailDelegate(AddressOf PreSetPageThumbnail), New Object() {e})
      End Sub

      Private Sub _generateThumbnailsWorker_PostPageProcessed(sender As Object, e As Workers.ThreadedPageWorkerPageProcessedEventArgs)
         ' This fires in the thumbnails generator thread context, so invoke our updates
         BeginInvoke(New PageThumbnailDelegate(AddressOf PostSetPageThumbnail), New Object() {e})
      End Sub

      Private Sub _generateThumbnailsWorker_ProcessFinished(sender As Object, e As EventArgs)
         BeginInvoke(New MethodInvoker(AddressOf SetPageThumbnailsFinished))
      End Sub

#End Region

#Region "UI"
      Private Sub _thumbnailsToolStripButton_Click(sender As Object, e As EventArgs) Handles _thumbnailsToolStripButton.Click
         SetActiveTab(True, False, False)
      End Sub

      Private Sub _bookmarksToolStripButton_Click(sender As Object, e As EventArgs) Handles _bookmarksToolStripButton.Click
         SetActiveTab(False, True, False)
      End Sub

      Private Sub _signaturesToolStripButton_Click(sender As Object, e As System.EventArgs) Handles _signaturesToolStripButton.Click
         SetActiveTab(False, False, True)
      End Sub

      Private Sub _bookmarksTreeView_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles _bookmarksTreeView.NodeMouseClick
         If e.Node IsNot Nothing Then
            GotoBookmark(e.Node)
         End If
      End Sub

      Private Sub _bookmarksTreeView_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _bookmarksTreeView.KeyPress
         If e.KeyChar = CChar(Microsoft.VisualBasic.ChrW(Keys.Return)) AndAlso _bookmarksTreeView.SelectedNode IsNot Nothing Then
            GotoBookmark(_bookmarksTreeView.SelectedNode)
         End If
      End Sub

      Private Sub _signaturesTreeView_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles _signaturesTreeView.NodeMouseClick
         If e.Node IsNot Nothing Then
            If TypeOf e.Node.Tag Is PDFSignature Then
               Dim signature As PDFSignature = TryCast(e.Node.Tag, PDFSignature)
               Using signaturesDialog As New DigitalSignaturesDialog(signature)
                  signaturesDialog.ShowDialog()
               End Using
            End If
         End If
      End Sub

      Private Sub _signaturesTreeView_KeyPress(sender As Object, e As KeyPressEventArgs) Handles _signaturesTreeView.KeyPress
         If e.KeyChar = CChar(Microsoft.VisualBasic.ChrW(Keys.Return)) AndAlso _signaturesTreeView.SelectedNode IsNot Nothing Then
            Dim node As TreeNode = _signaturesTreeView.SelectedNode

            If node IsNot Nothing AndAlso TypeOf node.Tag Is PDFSignature Then
               Dim signature As PDFSignature = TryCast(node.Tag, PDFSignature)
               Using signaturesDialog As New DigitalSignaturesDialog(signature)
                  signaturesDialog.ShowDialog()
               End Using
            End If
         End If
      End Sub

      Private Sub GotoBookmark(node As TreeNode)
         If node IsNot Nothing AndAlso node.Tag IsNot Nothing Then
            Dim bookmark As PDFBookmark = CType(node.Tag, PDFBookmark)
            DoAction("GotoBookmark", bookmark)
         End If
      End Sub

      Private Sub _rasterImageList_SelectedItemsChanged(sender As Object, e As System.EventArgs) Handles _rasterImageList.SelectedItemsChanged
         If _ignoreSelectedChanged Then
            Return
         End If
         Dim pageNumber As Integer = CurrentPageNumber
         DoAction("PageNumberChanged", pageNumber)
      End Sub

      Private Sub _rasterImageList_Scroll(sender As Object, e As EventArgs) Handles _rasterImageList.Scroll
         ' Find the an item above where the user clicked.
         Dim index As Integer = _rasterImageList.GetFirstVisibleItemIndex(ImageViewerItemPart.Item)

         If index <> -1 AndAlso _generateThumbnailsWorker IsNot Nothing AndAlso _generateThumbnailsWorker.IsWorking Then
            _generateThumbnailsWorker.NextPageNumber = index
         End If
      End Sub
#End Region
   End Class
End Namespace
