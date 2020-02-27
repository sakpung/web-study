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

Imports Leadtools
Imports Leadtools.Controls
Imports BarcodeMainDemo.Leadtools.Demos

''' <summary>
''' This control contains an instance of RasterImageList
''' </summary>
Partial Public Class PagesControl : Inherits UserControl
   Public Sub New()
      InitializeComponent()
   End Sub

#Region "Public"
   ''' <summary>
   ''' The instance of RasterImageList used in this viewer
   ''' </summary>
   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public ReadOnly Property RasterImageList() As ImageViewer
      Get
         Return _rasterImageList
      End Get
   End Property

   ''' <summary>
   ''' Populate the control with thumbnails of the pages in the image
   ''' </summary>
   Public Sub SetDocument(ByVal image As RasterImage)
      _rasterImageList.BeginUpdate()
      _rasterImageList.Items.Clear()

      ' Only add the thumbnails if the image has more than 1 page
      If Not image Is Nothing AndAlso image.PageCount > 1 Then
         image.DisableEvents()
         Dim originalImagePageNumber As Integer = image.Page

         Try
            Dim thumbSize As LeadSize = _rasterImageList.ItemSize

            Dim page As Integer = 1
            Do While page <= image.PageCount
               image.Page = page
               Dim thumbnailImage As RasterImage = image.CreateThumbnail(thumbSize.Width, thumbSize.Height, 24, RasterViewPerspective.TopLeft, RasterSizeFlags.Resample)

               Dim item As ImageViewerItem = New ImageViewerItem()
               item.Image = thumbnailImage
               item.PageNumber = 1
               item.Text = DemosGlobalization.GetResxString(Me.GetType(), "Resx_Page") + page.ToString()

               If page = originalImagePageNumber Then
                  item.IsSelected = True
               End If
               _rasterImageList.Items.Insert(page - 1, item)
               page += 1
            Loop
         Finally
            image.Page = originalImagePageNumber
            image.EnableEvents()
         End Try
      End If

      _rasterImageList.EndUpdate()
   End Sub

   ''' <summary>
   ''' Called from the main form when the user changes the page number
   ''' from outside this control (main menu or the viewer control)
   ''' </summary>
   Public Sub SetCurrentPageNumber(ByVal pageNumber As Integer)
      If pageNumber <> CurrentPageNumber Then
         Dim pageIndex As Integer = pageNumber - 1

         ' De-select all items but 'pageIndex'

         _rasterImageList.BeginUpdate()

         Dim i As Integer = 0
         Do While i < _rasterImageList.Items.Count
            Dim item As ImageViewerItem = _rasterImageList.Items(i)

            If i = pageIndex Then
               item.IsSelected = True
            Else
               item.IsSelected = False
            End If
            i += 1
         Loop

         _rasterImageList.EnsureItemVisibleByIndex(pageIndex)
         _rasterImageList.EndUpdate()
      End If
   End Sub

   ''' <summary>
   ''' Any action that happens in this control that must be handled by the owner
   ''' For example, any of the tool strip buttons clicked
   ''' </summary>
   Public Event Action As EventHandler(Of ActionEventArgs)
#End Region ' Public

#Region "Private"
   Private Sub DoAction(ByVal action As String, ByVal data As Object)
      ' Raise the action event so the main form can handle it

      If Not ActionEvent Is Nothing Then
         RaiseEvent Action(Me, New ActionEventArgs(action, data))
      End If
   End Sub

   Private ReadOnly Property CurrentPageNumber() As Integer
      Get
         ' Find the first selected item in the image list, it is
         ' a single selection control
         Dim i As Integer = 0
         Do While i < _rasterImageList.Items.Count
            If _rasterImageList.Items(i).IsSelected Then
               Return i + 1
            End If
            i += 1
         Loop

         ' No items
         Return 0
      End Get
   End Property
#End Region ' Private

#Region "UI"
   Private Sub _rasterImageList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _rasterImageList.SelectedItemsChanged
      Dim pageNumber As Integer = CurrentPageNumber
      If pageNumber <> 0 Then
         DoAction("PageNumberChanged", pageNumber)
      End If
   End Sub
#End Region ' UI
End Class
