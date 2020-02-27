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
Imports System.Net
Imports System.Threading

Imports Leadtools
Imports Leadtools.Codecs

Namespace SharePointDemo
   Partial Public Class SharePointDownloadUploadDialog : Inherits Form
      ' Set the server properties to use
      Private _serverProperties As SharePointServerProperties
      ' The RasterCodecs objects used to download/upload
      Private _rasterCodecs As RasterCodecs
      ' The Image file name
      Private _imageFileName As String
      ' The RasterImage object
      Private _rasterImage As RasterImage
      ' The image name on the server
      Private _imageServerName As String
      ' Are we downloading (or uploading?)
      Private _isDownloading As Boolean
      ' We are busy
      Private _isBusy As Boolean

      Public Sub New(ByVal serverProperties As SharePointServerProperties, ByVal codecs As RasterCodecs, ByVal imageFileName As String, ByVal image As RasterImage)
         InitializeComponent()

         _rasterCodecs = codecs
         _serverProperties = serverProperties

         _imageFileName = imageFileName
         _rasterImage = image

         If _rasterImage Is Nothing Then
            ' We are downloading
            _isDownloading = True
         Else
            ' We are uploading
            _isDownloading = False
         End If
      End Sub

      Public ReadOnly Property RasterImage() As RasterImage
         Get
            Return _rasterImage
         End Get
      End Property

      Public ReadOnly Property ImageServerName() As String
         Get
            Return _imageServerName
         End Get
      End Property

      Private Delegate Sub StartupDelegate()

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         _isBusy = True

         BeginInvoke(New StartupDelegate(AddressOf Startup))

         MyBase.OnLoad(e)
      End Sub

      Private Sub Startup()
         If _isDownloading Then
            _messageLabel.Text = String.Format("Downloading '{0}' from '{1}'", _imageFileName, _serverProperties.Url)
         Else
            _messageLabel.Text = String.Format("Uploading '{0}' to '{1}'", _imageFileName, _serverProperties.Url)
         End If
         _busyProgressBar.MarqueeAnimationSpeed = 100
         Application.DoEvents()

         Dim t As Thread = New Thread(AddressOf UploadDownload)
         t.Start()
      End Sub

      Private Sub UploadDownload()
         Try
            ' Set the credentials
            If _serverProperties.UseCredentials Then
               _rasterCodecs.UriOperationCredentials = New NetworkCredential(_serverProperties.UserName, _serverProperties.Password, _serverProperties.Domain)
            Else
               _rasterCodecs.UriOperationCredentials = CredentialCache.DefaultCredentials
            End If

            ' Set the proxy
            If _serverProperties.UseProxy Then
               _rasterCodecs.UriOperationProxy = New WebProxy(_serverProperties.Host, _serverProperties.Port)
            Else
               _rasterCodecs.UriOperationProxy = Nothing
            End If

            ' Create the URL for the image
            Dim url As String = _serverProperties.Url
            If (Not url.EndsWith("/")) Then
               url &= "/"
            End If

            ' Use the SharePoint Lists web service
            url &= "Shared Documents/" & _imageFileName

            Dim uri As Uri = New Uri(url)
            _imageServerName = uri.ToString()

            ' Upload or download this image
            If _isDownloading Then
               _rasterImage = _rasterCodecs.Load(uri)
            Else
               _rasterCodecs.Save(_rasterImage, uri, _rasterImage.OriginalFormat, 0)
            End If

            CloseMe(True, Nothing)
         Catch ex As Exception
            CloseMe(False, ex)
         End Try
      End Sub

      Private Delegate Sub CloseMeDelegate(ByVal success As Boolean, ByVal ex As Exception)

      Private Sub CloseMe(ByVal success As Boolean, ByVal ex As Exception)
         Me.BeginInvoke(New CloseMeDelegate(AddressOf DoCloseMe), New Object() {success, ex})
      End Sub

      Private Sub DoCloseMe(ByVal success As Boolean, ByVal ex As Exception)
         If success Then
            _isBusy = False
            DialogResult = DialogResult.OK
         Else
            ' Stop the animation and show the error
            _busyProgressBar.MarqueeAnimationSpeed = 0
            Application.DoEvents()

            Messager.ShowError(Me, ex)

            ' Cancel
            _isBusy = False
            DialogResult = DialogResult.Cancel
         End If
      End Sub

      Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
         ' If we are busy, cancel but do not close the dialog
         ' The ConnectToServer method will eventually exists
         If _isBusy Then
            e.Cancel = True
         End If

         MyBase.OnFormClosing(e)
      End Sub
   End Class
End Namespace
