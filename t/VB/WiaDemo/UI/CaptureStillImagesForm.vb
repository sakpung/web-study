' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.WinForms
Imports Leadtools.Wia

Partial Public Class CaptureStillImagesForm : Inherits Form
   Private _browser As RasterThumbnailBrowser

   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub CaptureStillImagesForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      Dim imagesFolder As String = String.Empty

      _browser = New RasterThumbnailBrowser()
      _browser.UseDpi = True
      _browser.Codecs = New RasterCodecs()
      _browser.Dock = DockStyle.Fill
      _browser.SelectionMode = RasterImageListSelectionMode.Multi
      _browser.ViewStyle = RasterImageListViewStyle.Button
      _browser.ScrollStyle = RasterImageListScrollStyle.Vertical
      _browser.EnableKeyboard = True
      _browser.EnableRubberBandSelection = True
      _browser.ShowItemText = True
      _browser.ItemSize = New Size(120, 120)
      _browser.ItemSpacingSize = New Size(5, 5)
      _browser.BackColor = Color.Bisque
      _browser.ItemImageSize = New Size(100, 100)

      _pnlBrowser.Controls.Add(_browser)
      _browser.BringToFront()

      Try
         Dim rootItem As Object = Nothing
#If Not LEADTOOLS_V17_OR_LATER Then
         MainForm._wiaSession.GetRootItem(Nothing)
         If Not MainForm._wiaSession.RootItem Is Nothing Then
            MainForm._wiaSession.GetPropertyString(MainForm._wiaSession.RootItem, Nothing, Leadtools.Wia.WiaPropertyId.VideoDeviceImagesDirectory)
            imagesFolder = MainForm._wiaSession.StringValue
         End If
#Else
         rootItem = MainForm._wiaSession.GetRootItem(Nothing)
         If Not rootItem Is Nothing Then
            imagesFolder = MainForm._wiaSession.GetPropertyString(rootItem, Nothing, WiaPropertyId.VideoDeviceImagesDirectory)
         End If
#End If ' #if !LEADTOOLS_V17_OR_LATER

         ' Enable Events
         AddHandler _browser.LoadThumbnail, AddressOf _browser_LoadThumbnail
         AddHandler _browser.Click, AddressOf _browser_Click

         _browser.LoadThumbnails(imagesFolder, "*.jpg", RasterThumbnailBrowserLoadFlags.None)

         ' Start the video preview
#If Not LEADTOOLS_V19_OR_LATER Then
         MainForm._wiaSession.StartVideoPreview(_pnlVideoPreview, False)
#Else
         MainForm._wiaSession.StartVideoPreview(_pnlVideoPreview.Handle, False)
#End If ' #If Not LEADTOOLS_V19_OR_LATER Then

         UpdateDialogControls(False)
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub _browser_Click(ByVal sender As Object, ByVal e As EventArgs)
      _browser.Focus()
      If _browser.SelectedItems.Count > 0 Then
         UpdateDialogControls(True)
      Else
         UpdateDialogControls(False)
      End If
   End Sub

   Private Sub _browser_LoadThumbnail(ByVal sender As Object, ByVal e As RasterThumbnailBrowserLoadThumbnailEventArgs)
      _browser.EnsureVisible(e.Index)
   End Sub

   Private Sub CaptureStillImagesForm_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
      _browser.Items.Clear()

      ' Disable Events
      RemoveHandler _browser.LoadThumbnail, AddressOf _browser_LoadThumbnail

      Dim videoPreviewAvailable As Boolean = MainForm._wiaSession.IsVideoPreviewAvailable()
      If videoPreviewAvailable Then
         MainForm._wiaSession.EndVideoPreview()
      End If
   End Sub

   Private Sub _pnlVideoPreview_SizeChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _pnlVideoPreview.SizeChanged
      If (MainForm._wiaSession.IsVideoPreviewAvailable) Then
         MainForm._wiaSession.ResizeVideoPreview(False)
      End If
   End Sub

   Private Sub UpdateDialogControls(ByVal imageListItemsSelected As Boolean)
      Dim videoPreviewAvailable As Boolean = MainForm._wiaSession.IsVideoPreviewAvailable()

      _btnTakePicture.Enabled = videoPreviewAvailable
      _btnLoadPictures.Enabled = imageListItemsSelected
   End Sub

   Private Sub _btnTakePicture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnTakePicture.Click
      If MainForm._wiaSession.IsVideoPreviewAvailable() Then
         Try
            Dim takenPictureFileName As String
#If Not LEADTOOLS_V17_OR_LATER Then
            MainForm._wiaSession.AcquireImageFromVideo()
            takenPictureFileName = MainForm._wiaSession.TakenPictureFileName
#Else
            takenPictureFileName = MainForm._wiaSession.AcquireImageFromVideo()
#End If ' #if !LEADTOOLS_V17_OR_LATER

            ' Add the new captured image thumbnail to the image list.
            Dim image As RasterImage = MainForm._codecs.Load(takenPictureFileName)
            Dim imageName As String = Path.GetFileName(takenPictureFileName)
            Dim item As RasterImageListItem = New RasterImageListItem(image, 1, imageName)
            item.FileName = takenPictureFileName
            _browser.Items.Add(item)
            _browser.EnsureVisible(_browser.Items.Count - 1)
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End If
   End Sub

   Private Sub _btnLoadPictures_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnLoadPictures.Click
      Try
         For Each i As RasterImageListItem In _browser.SelectedItems
            Dim image As RasterImage = MainForm._codecs.Load(i.FileName)
            FormParent.CreateChildForm(image, i.FileName)
         Next i
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private _parentForm As MainForm = Nothing
   Public Property FormParent() As MainForm
      Get
         Return _parentForm
      End Get
      Set(ByVal value As MainForm)
         _parentForm = Value
      End Set
   End Property
End Class
