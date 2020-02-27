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
Imports System.Xml

Namespace SharePointDemo
   Partial Public Class SharePointConnectDialog : Inherits Form
      ' Set the server properties to use
      Private _serverProperties As SharePointServerProperties
      ' Did we cancel this dialog
      Private _canceled As Boolean
      ' We are busy
      Private _isBusy As Boolean
      ' The list of the documents in the "Shared Document" folder on the server
      Private _documentNames As List(Of String)

      Public Sub New(ByVal serverProperties As SharePointServerProperties)
         InitializeComponent()

         _serverProperties = serverProperties
      End Sub

      Public ReadOnly Property DocumentNames() As IList(Of String)
         Get
            Return _documentNames
         End Get
      End Property

      Private Delegate Sub ConnectToServerDelegate()

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         _isBusy = True

         BeginInvoke(New ConnectToServerDelegate(AddressOf ConnectToServer))

         MyBase.OnLoad(e)
      End Sub

      Private Sub ConnectToServer()
         _messageLabel.Text = "Connecting to " & _serverProperties.Url
         _busyProgressBar.MarqueeAnimationSpeed = 100
         Application.DoEvents()

         ' Connect to SharePoint server
         Dim listsService As SharePointLists.Lists = New SharePointLists.Lists()

         Try
            ' Set the credentials
            If _serverProperties.UseCredentials Then
               listsService.Credentials = New NetworkCredential(_serverProperties.UserName, _serverProperties.Password, _serverProperties.Domain)
            Else
               listsService.Credentials = CredentialCache.DefaultCredentials
            End If

            ' Set the proxy
            If _serverProperties.UseProxy Then
               listsService.Proxy = New WebProxy(_serverProperties.Host, _serverProperties.Port)
            Else
               listsService.Proxy = Nothing
            End If

            ' Set the URL
            Dim url As String = _serverProperties.Url
            If (Not url.EndsWith("/")) Then
               url &= "/"
            End If

            ' Use the SharePoint Lists web service
            url &= "_vti_bin/lists.asmx"
            listsService.Url = url

            ' Setup the XML document we need as a parameter to the GetListItems method of the service
            Dim doc As XmlDocument = New XmlDocument()
            doc.LoadXml("<Document><Query/><ViewFields /><QueryOptions /></Document>")
            Dim queryNode As XmlNode = doc.SelectSingleNode("//Query")
            Dim viewFieldsNode As XmlNode = doc.SelectSingleNode("//ViewFields")
            Dim queryOptionsNode As XmlNode = doc.SelectSingleNode("//QueryOptions")

            Dim documentLibraryName As String = "Shared Documents"

            ' Now connect to this server asynchronisly
            AddHandler listsService.GetListItemsCompleted, AddressOf listsService_GetListItemsCompleted
            listsService.GetListItemsAsync(documentLibraryName, Nothing, queryNode, viewFieldsNode, Nothing, queryOptionsNode)
         Catch ex As Exception
            ' Stop the animation and show the error
            _busyProgressBar.MarqueeAnimationSpeed = 0
            Application.DoEvents()

            Messager.ShowError(Me, ex)

            ' Cancel
            listsService.Dispose()
            _isBusy = False
            DialogResult = DialogResult.Cancel
         End Try
      End Sub

      Private Sub listsService_GetListItemsCompleted(ByVal sender As Object, ByVal e As SharePointLists.GetListItemsCompletedEventArgs)
         ' Get the services
         Dim listsService As SharePointLists.Lists = TryCast(sender, SharePointLists.Lists)

         ' Unhook from the event
         RemoveHandler listsService.GetListItemsCompleted, AddressOf listsService_GetListItemsCompleted

         ' Check if we caneled
         If e.Cancelled OrElse _canceled OrElse Not e.Error Is Nothing Then
            If Not e.Error Is Nothing Then
               ' Stop the animation and show the error
               _busyProgressBar.MarqueeAnimationSpeed = 0
               Application.DoEvents()
               Messager.ShowError(Me, e.Error)
            End If

            ' Cancel
            listsService.Dispose()
            _isBusy = False
            DialogResult = DialogResult.Cancel
            Return
         End If

         ' We are done, get the results
         Dim listItemsNode As XmlNode = e.Result

         ' Loop through all the items, get the documents
         _documentNames = New List(Of String)()
         Dim childNodes As XmlNodeList = listItemsNode.ChildNodes
         For Each childNode As XmlNode In childNodes
            Dim reader As XmlNodeReader = New XmlNodeReader(childNode)

            Do While reader.Read()
               If Not reader("ows_EncodedAbsUrl") Is Nothing AndAlso Not reader("ows_LinkFilename") Is Nothing Then
                  Dim objType As String = reader("ows_FSObjType").ToString()

                  ' If the objType is of this format: number;#1 then it is a folder
                  ' and we should not use it
                  If (Not objType.EndsWith(";#1")) Then
                     ' Get the file name
                     Dim fileName As String = reader("ows_LinkFilename").ToString()
                     _documentNames.Add(fileName)
                  End If
               End If
            Loop
         Next childNode

         listsService.Dispose()
         DialogResult = DialogResult.OK
         _isBusy = False
      End Sub

      Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
         ' If we are busy, cancel but do not close the dialog
         ' The ConnectToServer method will eventually exists
         If _isBusy Then
            e.Cancel = True
            _canceled = True
         End If

         MyBase.OnFormClosing(e)
      End Sub

      Private Sub _cancelButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _cancelButton.Click
         ' Cancel and stay in the dialog
         ' The ConnectToServer method will eventually exists
         _canceled = True
         DialogResult = DialogResult.None
      End Sub
   End Class
End Namespace
