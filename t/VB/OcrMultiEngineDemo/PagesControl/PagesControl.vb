' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.ComponentModel

Imports Leadtools
Imports Leadtools.Controls

''' <summary>
''' This control contains an instance of RasterImageList plus
''' a tool strip control for common operations
''' </summary>
Public Class PagesControl
   Public Sub New()

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      _rasterImageList.Dock = System.Windows.Forms.DockStyle.Fill
      _rasterImageList.ItemBorderThickness = 1
      _rasterImageList.ItemSpacing = New LeadSize(20, 20)
      _rasterImageList.ItemSize = New LeadSize(160, 180)
      _rasterImageList.ViewPadding = New System.Windows.Forms.Padding(6)
      _rasterImageList.ItemPadding = New System.Windows.Forms.Padding(5, 0, 5, 20)

      ' Add any initialization after the InitializeComponent() call.
      UpdateUIState()
   End Sub

   Private Sub __rasterImageList_Paint(ByVal sender As Object, ByVal e As ImageViewerRenderEventArgs) Handles _rasterImageList.PostRender, _rasterImageList.PostRender
      ' Draw the letter R on each recognized page 

      Dim itemImageSize As LeadSize = _rasterImageList.ItemSize
      Dim g As Graphics = e.PaintEventArgs.Graphics

      Using textBrush As Brush = New SolidBrush(Color.FromArgb(128, Color.Black))
         For Each item As ImageViewerItem In _rasterImageList.Items
            Dim isPageRecognized As Boolean = False

            If item.Tag IsNot Nothing Then
               isPageRecognized = CBool(item.Tag)
            End If

            If isPageRecognized Then
               Dim itemRect As LeadRectD = _rasterImageList.GetItemBounds(item, ImageViewerItemPart.Image)
               Dim transform As LeadMatrix = _rasterImageList.GetItemImageTransform(item)
               itemRect.X = transform.OffsetX
               itemRect.Y = transform.OffsetY

               Dim textSize As SizeF = g.MeasureString("R", _rasterImageList.Font)
               Dim textRect As New RectangleF(Convert.ToSingle(itemRect.X + 2), Convert.ToSingle(itemRect.Y + 2), textSize.Width, textSize.Height)

               g.FillRectangle(textBrush, textRect)

               g.DrawString("R", _rasterImageList.Font, Brushes.White, textRect.Location)
            End If
         Next
      End Using
   End Sub

   ''' <summary>
   ''' The image list control is needed by the main form
   ''' </summary>
   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public ReadOnly Property RasterImageList() As ImageViewer
      Get
         Return _rasterImageList
      End Get
   End Property

   ''' <summary>
   ''' Called from the main form when the user changes the page index
   ''' from outside this control (main menu or the viewer control)
   ''' </summary>
   Private _oldSelectedItem As ImageViewerItem() = Nothing
   Public Sub SetCurrentPageIndex(ByVal pageIndex As Integer)
      If (pageIndex <> CurrentPageIndex) Then
         ' De-select all items but 'pageIndex'

         _rasterImageList.BeginUpdate()

         For i As Integer = 0 To _rasterImageList.Items.Count - 1
            Dim item As ImageViewerItem = _rasterImageList.Items(i)

            If (i = pageIndex) Then
               item.IsSelected = True
            Else
               item.IsSelected = False
            End If
         Next

         _rasterImageList.EnsureItemVisible(_rasterImageList.Items(pageIndex))
         _rasterImageList.EndUpdate()
         _oldSelectedItem = _rasterImageList.Items.GetSelected()
      End If

      UpdateUIState()
   End Sub

   ''' <summary>
   ''' Called by the main form to update the UI state
   ''' </summary>
   Public Sub UpdateUIState()
      If MainForm.PerspectiveDeskewActive Then
         _toolStrip.Enabled = False
         Return
      End If

      _toolStrip.Enabled = True
      ' Update the UI based on the state of the control
      Dim pageCount As Integer = _rasterImageList.Items.Count
      _deleteCurrentPageToolStripButton.Enabled = (pageCount > 0)

      Dim pageIndex As Integer = CurrentPageIndex
      _movePageUpToolStripButton.Enabled = (pageCount > 0) AndAlso (pageIndex > 0)
      _movePageDownToolStripButton.Enabled = (pageCount > 0) AndAlso (pageIndex < (pageCount - 1))
   End Sub

   ''' <summary>
   ''' Any action that happens in this control that must be handled by the owner
   ''' For example, any of the tool strip buttons clicked
   ''' </summary>
   Public Event Action As EventHandler(Of ActionEventArgs)

   Private ReadOnly Property CurrentPageIndex() As Integer
      Get
         ' Find the first selected item in the image list, it is
         ' a single selection control
         For i As Integer = 0 To _rasterImageList.Items.Count - 1
            If (_rasterImageList.Items(i).IsSelected) Then
               Return i
            End If
         Next

         ' No items
         Return -1
      End Get
   End Property

   Private Sub __rasterImageList_SelectedItemChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _rasterImageList.SelectedItemsChanged, _rasterImageList.SelectedItemsChanged
      If MainForm.PerspectiveDeskewActive Then
         ' Prevent selecting other items from image list while Inverse perspective is active.
         RemoveHandler _rasterImageList.SelectedItemsChanged, AddressOf Me.__rasterImageList_SelectedItemChanged
         _rasterImageList.Items.[Select](Nothing)
         _rasterImageList.Items.[Select](_oldSelectedItem)
         AddHandler _rasterImageList.SelectedItemsChanged, AddressOf Me.__rasterImageList_SelectedItemChanged
         Return
      End If

      Dim pageIndex As Integer = CurrentPageIndex
      _oldSelectedItem = _rasterImageList.Items.GetSelected()
      If pageIndex <> -1 Then
         DoAction("PageIndexChanged", pageIndex)
         UpdateUIState()
      End If
   End Sub

   Private Sub _insertPageToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _insertPageToolStripButton.Click
      DoAction("InsertPage", Nothing)
   End Sub

   Private Sub _deleteCurrentPageToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _deleteCurrentPageToolStripButton.Click
      DoAction("DeletePage", Nothing)
   End Sub

   Private Sub _movePageUpToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _movePageUpToolStripButton.Click
      DoAction("MovePageUp", Nothing)
   End Sub

   Private Sub _movePageDownToolStripButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _movePageDownToolStripButton.Click
      DoAction("MovePageDown", Nothing)
   End Sub

   Private Sub DoAction(ByVal action As String, ByVal data As Object)
      ' Raise the action event so the main form can handle it

      RaiseEvent Action(Me, New ActionEventArgs(action, data))
   End Sub
End Class
