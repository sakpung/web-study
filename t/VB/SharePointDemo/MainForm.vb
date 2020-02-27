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

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Demos.Dialogs

Namespace SharePointDemo
   Partial Public Class MainForm : Inherits Form
      ' Ths RasterCodecs instance used to load/save raster images
      Private _codecs As RasterCodecs
      ' SharePoint server properties
      Private _serverProperties As SharePointServerProperties
      ' The name (without path) of the last image we put in the viewer
      Private _lastImageName As String

      Private panMode As ImageViewerPanZoomInteractiveMode
      Private zoomToMode As ImageViewerZoomToInteractiveMode
      Private noneMode As ImageViewerNoneInteractiveMode
      Private _openInitialPath As String = String.Empty

      Public Sub New()
         InitializeComponent()

         InitInteractiveModes()

         ' Initialize the messager class (used to show error messages)
         Messager.Caption = "C# SharePoint Demo"
         Me.Text = Messager.Caption

         ' Init the RasterCodecs object
         _codecs = New RasterCodecs()
      End Sub

      Private Sub InitInteractiveModes()
         noneMode = _viewerControl.NoneInteractiveMode
         panMode = _viewerControl.PanZoomInteractiveMode
         zoomToMode = _viewerControl.ZoomToInteractiveMode
      End Sub

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         ' We must connect to a valid SharePoint server
         ' Otherwise, this demo will exit

         _serverProperties = New SharePointServerProperties()

         ' Load the last settings we used
         Dim settings As New Settings

         _serverProperties.Url = settings.Url
         Boolean.TryParse(settings.UseCredentials, _serverProperties.UseCredentials)
         _serverProperties.UserName = settings.UserName
         _serverProperties.Password = String.Empty
         _serverProperties.Domain = settings.Domain
         Boolean.TryParse(settings.UseProxy, _serverProperties.UseProxy)
         _serverProperties.Host = settings.Host
         Integer.TryParse(settings.Port, _serverProperties.Port)

         If (Not ConnectToSharePointServer()) Then
            Close()
         End If

         MyBase.OnLoad(e)
      End Sub

      Protected Overrides Sub OnFormClosed(ByVal e As FormClosedEventArgs)
         ' Save last settings used
         Dim settings As New Settings()

         settings.Url = _serverProperties.Url
         settings.UseCredentials = _serverProperties.UseCredentials.ToString()
         settings.UserName = _serverProperties.UserName
         settings.Domain = _serverProperties.Domain
         settings.UseProxy = _serverProperties.UseProxy.ToString()
         settings.Host = _serverProperties.Host
         settings.Port = _serverProperties.Port.ToString()

         settings.Save()

         ' Dispose the RasterCodecs object we used
         If Not _codecs Is Nothing Then
            _codecs.Dispose()
         End If

         MyBase.OnFormClosed(e)
      End Sub

      Private Sub _fileOpenToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _fileOpenToolStripMenuItem.Click
         OpenImageFile()
      End Sub

      Private Sub _fileExitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _fileExitToolStripMenuItem.Click
         Close()
      End Sub

      Private Sub _helpAboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _helpAboutToolStripMenuItem.Click
         Using aboutDialog As New AboutDialog("SharePoint", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _viewToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _viewToolStripMenuItem.DropDownOpening
         Dim isImageAvailable As Boolean = Not _viewerControl.RasterImage Is Nothing
         _viewZoomInToolStripMenuItem.Enabled = isImageAvailable
         _viewZoomOutToolStripMenuItem.Enabled = isImageAvailable
         _viewFitPageWidthToolStripMenuItem.Enabled = isImageAvailable
         _viewFitPageToolStripMenuItem.Enabled = isImageAvailable
      End Sub

      Private Sub _viewZoomOutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _viewZoomOutToolStripMenuItem.Click
         _viewerControl.ZoomViewer(True)
      End Sub

      Private Sub _viewZoomInToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _viewZoomInToolStripMenuItem.Click
         _viewerControl.ZoomViewer(False)
      End Sub

      Private Sub _viewFitPageWidthToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _viewFitPageWidthToolStripMenuItem.Click
         _viewerControl.FitPage(True)
      End Sub

      Private Sub _viewFitPageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _viewFitPageToolStripMenuItem.Click
         _viewerControl.FitPage(False)
      End Sub

      Private Sub _pagesToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _pagesToolStripMenuItem.DropDownOpening
         Dim isImageAvailable As Boolean = Not _viewerControl.RasterImage Is Nothing

         If isImageAvailable Then
            _pagesPreviousToolStripMenuItem.Enabled = _viewerControl.RasterImage.Page > 1
            _pagesNextToolStripMenuItem.Enabled = _viewerControl.RasterImage.Page < _viewerControl.RasterImage.PageCount
         Else
            _pagesPreviousToolStripMenuItem.Enabled = False
            _pagesNextToolStripMenuItem.Enabled = False
         End If
      End Sub

      Private Sub _pagesPreviousToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _pagesPreviousToolStripMenuItem.Click
         _viewerControl.MoveToPage(True)
      End Sub

      Private Sub _pagesNextToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _pagesNextToolStripMenuItem.Click
         _viewerControl.MoveToPage(False)
      End Sub

      Private Sub _interactiveToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _interactiveToolStripMenuItem.DropDownOpening
         _interactiveSelectModeToolStripMenuItem.Checked = noneMode.IsEnabled
         _interactivePanModeToolStripMenuItem.Checked = panMode.IsEnabled
         _interactiveZoomToSelectionModeToolStripMenuItem.Checked = zoomToMode.IsEnabled

         Dim isImageAvailable As Boolean = Not _viewerControl.RasterImage Is Nothing

         _interactiveSelectModeToolStripMenuItem.Enabled = isImageAvailable
         _interactivePanModeToolStripMenuItem.Enabled = isImageAvailable
         _interactiveZoomToSelectionModeToolStripMenuItem.Enabled = isImageAvailable
      End Sub

      Private Sub _interactiveSelectModeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _interactiveSelectModeToolStripMenuItem.Click
         _viewerControl.SetMode(noneMode)
      End Sub

      Private Sub _interactivePanModeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _interactivePanModeToolStripMenuItem.Click
         _viewerControl.SetMode(panMode)
      End Sub

      Private Sub _interactiveZoomToSelectionModeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _interactiveZoomToSelectionModeToolStripMenuItem.Click
         _viewerControl.SetMode(zoomToMode)
      End Sub

      Private Sub _sharePointServerToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _sharePointServerToolStripMenuItem.DropDownOpening
         _sharePointServerRefreshToolStripMenuItem.Enabled = _serverControl.CanRefresh
         _sharePointServerUploadCurrentImageToolStripMenuItem.Enabled = Not _viewerControl.RasterImage Is Nothing
      End Sub

      Private Sub _sharePointServerPropertiesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _sharePointServerPropertiesToolStripMenuItem.Click
         ConnectToSharePointServer()
      End Sub

      Private Sub _sharePointServerRefreshToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _sharePointServerRefreshToolStripMenuItem.Click
         If _serverControl.CanRefresh Then
            RefreshServer()
         End If
      End Sub

      Private Sub _sharePointServerUploadCurrentImageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _sharePointServerUploadCurrentImageToolStripMenuItem.Click
         If Not _viewerControl.RasterImage Is Nothing Then
            UploadImage()
         End If
      End Sub

      Private Sub _serverControl_ServerClicked(ByVal sender As Object, ByVal e As EventArgs) Handles _serverControl.ServerClicked
         ConnectToSharePointServer()
      End Sub

      Private Sub _serverControl_RefreshClicked(ByVal sender As Object, ByVal e As EventArgs) Handles _serverControl.RefreshClicked
         RefreshServer()
      End Sub

      Private Sub _serverControl_DownloadClicked(ByVal sender As Object, ByVal e As EventArgs) Handles _serverControl.DownloadClicked
         Dim name As String = _serverControl.GetSelectedItemName()
         DownloadImage(name)
      End Sub

      Private Sub _viewerControl_OpenFileClicked(ByVal sender As Object, ByVal e As EventArgs) Handles _viewerControl.OpenFileClicked
         OpenImageFile()
      End Sub

      Private Sub _viewerControl_UploadClicked(ByVal sender As Object, ByVal e As EventArgs) Handles _viewerControl.UploadClicked
         UploadImage()
      End Sub

      Private Sub OpenImageFile()
         ' Open an image file from disk and put it in the viewer
         Dim loader As ImageFileLoader = New ImageFileLoader()

         Try
            loader.ShowLoadPagesDialog = True

            If loader.Load(Me, _codecs, True) > 0 Then
               SetViewerImage(loader.FileName, loader.Image, Path.GetFileName(loader.FileName))
            End If
         Catch ex As Exception
            Messager.ShowFileOpenError(Me, loader.FileName, ex)
         End Try
      End Sub

      Private Sub DownloadImage(ByVal name As String)
         ' Download the image from the server and put it in the raster image viewer
         Dim dlg As SharePointDownloadUploadDialog = New SharePointDownloadUploadDialog(_serverProperties, _codecs, name, Nothing)
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            SetViewerImage(dlg.ImageServerName, dlg.RasterImage, name)
         End If
      End Sub

      Private Sub SetViewerImage(ByVal name As String, ByVal image As RasterImage, ByVal imageName As String)
         _viewerControl.Text = name
         _viewerControl.RasterImage = image
         _lastImageName = imageName
      End Sub

      Private Sub UploadImage()
         ' Download the image from the server and put it in the raster image viewer
         Dim dlg As SharePointDownloadUploadDialog = New SharePointDownloadUploadDialog(_serverProperties, _codecs, _lastImageName, _viewerControl.RasterImage)
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            ' Refresh the server
            RefreshServer()
         End If
      End Sub

      Private Function ConnectToSharePointServer() As Boolean
         Dim ret As Boolean = False

         Dim serverProperties As SharePointServerProperties = _serverProperties

         ' Keep trying till we connect to a valid server or the user cancels
         Dim done As Boolean = False
         Do While Not done
            Using propertiesDialog As ServerPropertiesDialog = New ServerPropertiesDialog(_serverProperties)
               If propertiesDialog.ShowDialog(Me) = DialogResult.OK Then
                  ' Get the properties
                  serverProperties = propertiesDialog.ServerProperties

                  Dim documentNames As IList(Of String) = ConnectToServer(serverProperties)
                  If Not documentNames Is Nothing Then
                     _serverProperties = serverProperties

                     ' Populate the server control with the document names
                     PopulateServerControl(documentNames)
                     done = True
                     ret = True
                  End If
               Else
                  done = True
               End If
            End Using
         Loop

         Return ret
      End Function

      Private Function ConnectToServer(ByVal serverProperties As SharePointServerProperties) As IList(Of String)
         Dim documentNames As IList(Of String) = Nothing

         ' Try to connect to this SharePoint server
         Using connectDialog As SharePointConnectDialog = New SharePointConnectDialog(serverProperties)
            If connectDialog.ShowDialog(Me) = DialogResult.OK Then
               documentNames = connectDialog.DocumentNames
            End If
         End Using

         Return documentNames
      End Function

      Private Sub RefreshServer()
         ' Re-get the documents from the last server we used
         Dim documentNames As IList(Of String) = ConnectToServer(_serverProperties)
         If Not documentNames Is Nothing Then
            PopulateServerControl(documentNames)
         End If
      End Sub

      Private Sub PopulateServerControl(ByVal documentNames As IList(Of String))
         Dim url As String = _serverProperties.Url
         If (Not url.EndsWith("/")) Then
            url &= "/"
         End If

         url &= "Shared Documents"

         _serverControl.Text = url
         _serverControl.Populate(documentNames)
      End Sub
   End Class
End Namespace
