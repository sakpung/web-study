' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports Leadtools.Jpip.Server




   Partial Public Class ImagesEnumerationService

      Public Event ServiceStarted As EventHandler
      Public Event ServiceStoped As EventHandler

      Public Sub New(ByVal server As JpipServer)
         _server = server
         IpAddress = IpAddress.Parse("127.0.0.1")
      Port = 49202
         _started = False
         _extensions = New List(Of String)()
      End Sub

      Public Sub Start()
         _listner = New HttpListener()

         _listner.Prefixes.Add(String.Format("http://{0}:{1}/", IpAddress, Port))

         _listner.Start()

         _started = True

         _listner.BeginGetContext(New AsyncCallback(AddressOf ClientRequestReceived), Nothing)

         RaiseEvent ServiceStarted(Me, New EventArgs())
      End Sub

      Public Sub [Stop]()
         _listner.Stop()

         _started = False

         RaiseEvent ServiceStoped(Me, New EventArgs())
      End Sub

      Public ReadOnly Property ImagesExtension() As List(Of String)
         Get
            Return _extensions
         End Get
      End Property

      Public ReadOnly Property Running() As Boolean
         Get
            Return _started
         End Get
      End Property

      Private Sub ClientRequestReceived(ByVal ar As IAsyncResult)
         Dim context As HttpListenerContext


         If Nothing Is _listner OrElse (Not _listner.IsListening) Then
            Return
         End If

         Try
            context = _listner.EndGetContext(ar)
         Catch
            Return
         End Try

         Try

            Dim formattedImages As String
            Dim sendBuffer As Byte()

            _listner.BeginGetContext(New AsyncCallback(AddressOf ClientRequestReceived), Nothing)

            formattedImages = GetFormattedServerImagesString()

            sendBuffer = Encoding.ASCII.GetBytes(formattedImages)

            context.Response.OutputStream.Write(sendBuffer, 0, sendBuffer.Length)

            context.Response.Close()
         Catch e1 As Exception
            If Not Nothing Is context Then
               context.Response.Close()
            End If
         End Try
      End Sub

      Public Function GetFormattedServerImagesString() As String
         Dim searchImages As List(Of String)
         Dim serverImages As List(Of String)
         Dim serverImageFile As String
         Dim formattedServerImagesString As String = String.Empty


         searchImages = New List(Of String)()
         serverImages = New List(Of String)()

         For Each extension As String In ImagesExtension
            searchImages.AddRange(Directory.GetFiles(_server.Configuration.ImagesFolder, extension, SearchOption.AllDirectories))
         Next extension

         For Each file As String In searchImages
            serverImageFile = file.Replace(_server.Configuration.ImagesFolder, String.Empty)

            serverImageFile = serverImageFile.TrimStart("\"c)

            formattedServerImagesString &= serverImageFile & ";"
         Next file

         searchImages.Clear()

         For Each aliasFolder As KeyValuePair(Of String, String) In _server.Configuration.AliasFolders
            If (Not Directory.Exists(aliasFolder.Value)) Then
               Continue For
            End If

            For Each extension As String In ImagesExtension
               searchImages.AddRange(Directory.GetFiles(aliasFolder.Value, extension, SearchOption.AllDirectories))
            Next extension

            For Each imageFile As String In searchImages
               serverImageFile = imageFile.Replace(aliasFolder.Value, aliasFolder.Key)

               serverImageFile = serverImageFile.TrimStart("\"c)

               formattedServerImagesString &= serverImageFile & ";"
            Next imageFile

            searchImages.Clear()
         Next aliasFolder

         Return formattedServerImagesString.TrimEnd(";"c)
      End Function

      Public Property IpAddress() As IPAddress
         Get
            Return _ipAddress
         End Get

         Set(ByVal value As IPAddress)
            _ipAddress = Value
         End Set
      End Property

      Public Property Port() As Integer
         Get
            Return _port
         End Get

         Set(ByVal value As Integer)
            _port = Value
         End Set
      End Property


      Private _listner As HttpListener
      Private _server As JpipServer
      Private _ipAddress As IPAddress
      Private _port As Integer
      Private _started As Boolean = False
      Private _extensions As List(Of String)
   End Class

