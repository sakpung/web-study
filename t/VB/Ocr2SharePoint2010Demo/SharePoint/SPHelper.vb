' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Net

Imports Microsoft.SharePoint.Client

Namespace Ocr2SharePointDemo.SharePoint
   Public Enum SPTemplateType
      All = 0 ' Get all SharePoint lists of all the types listed below
      DocumentLibrary = 101 ' Get SharePoint lists with DocumentLibrary base template
      PictureLibrary = 109 ' Get SharePoint lists with PictureLibrary base template
      AssetLibrary = 851 ' Get SharePoint lists with AssetLibrary base template
   End Enum

   Public Class SPListInfo
      Public Id As Guid
      Public Title As String
      Public BaseTemplate As SPTemplateType
      Public Created As DateTime
      Public Description As String
      Public ServerRelativeUrl As String
      Public AbsoluteUri As Uri

      Public Sub New()
      End Sub

      Public Sub New(ByVal siteUri As Uri, ByVal list As List)
         Id = list.Id
         Title = list.Title
         ServerRelativeUrl = list.RootFolder.ServerRelativeUrl
         AbsoluteUri = SPHelper.CombineUrl(siteUri, ServerRelativeUrl)
         BaseTemplate = CType(list.BaseTemplate, SPTemplateType)
         Created = list.Created
         Description = list.Description
      End Sub

      Public Overrides Function ToString() As String
         Return Title
      End Function
   End Class

   Public Enum SPItemType
      File
      Folder
      Other
   End Enum

   Public Class SPItemInfo
      Public Id As Integer
      Public ParentListId As Guid
      Public ParentItem As SPItemInfo
      Public ItemType As SPItemType
      Public Created As DateTime
      Public DisplayName As String
      Public Name As String
      Public Title As String
      Public ServerRelativeUrl As String
      Public AbsoluteUri As Uri
      Public Author As String
      Public FileExtension As String

      Public Sub New()
      End Sub

      Public Sub New(ByVal siteUri As Uri, ByVal item As ListItem, ByVal parentList As SPListInfo, ByVal parentItem_Renamed As SPItemInfo)
         Id = item.Id
         ParentListId = parentList.Id
         ParentItem = parentItem_Renamed
         If item.FileSystemObjectType = FileSystemObjectType.File Then
            ItemType = SPItemType.File
         Else
            ItemType = SPItemType.Folder
         End If
         If (Not DateTime.TryParse(item.FieldValuesAsText("Created"), Created)) Then
            Created = DateTime.Now
         End If
         DisplayName = item.DisplayName
         Name = item.FieldValuesAsText("FileLeafRef")
         Title = item.FieldValuesAsText("Title")
         ServerRelativeUrl = item.FieldValuesAsText("FileRef")
         AbsoluteUri = SPHelper.CombineUrl(siteUri, ServerRelativeUrl)
         Author = item.FieldValuesAsText("Author")
         FileExtension = item.FieldValuesAsText("File_x0020_Type")
      End Sub

      Public Overrides Function ToString() As String
         Return DisplayName
      End Function
   End Class

   Public Class SPHelper
      Private _serverSettings As SharePointServerSettings

      Private Sub New()
      End Sub

      Public Sub New(ByVal serverSettings As SharePointServerSettings)
         _serverSettings = serverSettings
      End Sub

      Private Function CreateContext() As ClientContext
         Dim clientContext As ClientContext = New ClientContext(New Uri(_serverSettings.Uri))
         If Not _serverSettings.UserName Is Nothing Then
            clientContext.Credentials = New NetworkCredential(_serverSettings.UserName, _serverSettings.Password, _serverSettings.Domain)
         End If

         If Not _serverSettings.ProxyUri Is Nothing Then
            Dim proxy As System.Net.WebProxy = New System.Net.WebProxy(_serverSettings.ProxyUri, _serverSettings.ProxyPort)
            If proxy.Credentials Is Nothing AndAlso Not clientContext.Credentials Is Nothing Then
               proxy.Credentials = clientContext.Credentials
            Else
               proxy.Credentials = CredentialCache.DefaultCredentials
            End If

            WebRequest.DefaultWebProxy = proxy
         Else
            WebRequest.DefaultWebProxy = WebRequest.GetSystemWebProxy() ' Get default system proxy settings
         End If

         Return clientContext
      End Function

      Public Function GetLists() As SPListInfo()
         Dim ret As List(Of SPListInfo) = New List(Of SPListInfo)()

         Using clientContext As ClientContext = CreateContext()
            clientContext.Load(clientContext.Web.Lists)
            clientContext.Load(clientContext.Web.Lists, Function(lists) lists.Include(Function(l) l.RootFolder.ServerRelativeUrl, Function(l) l.OnQuickLaunch))
            clientContext.ExecuteQuery()

            Dim baseTemplateType As SPTemplateType = SPTemplateType.All
            Dim siteUri As Uri = New Uri(_serverSettings.Uri)

            If clientContext.Web.Lists.Count > 0 Then
               For Each list As List In clientContext.Web.Lists
                  If EnsureValidListTemplate(list, baseTemplateType) Then
                     Dim spListInfo As SPListInfo = New SPListInfo(siteUri, list)
                     ret.Add(spListInfo)
                  End If
               Next list
            End If
         End Using

         Return ret.ToArray()
      End Function

      Private Function EnsureValidListTemplate(ByVal list As List, ByVal baseTemplateType As SPTemplateType) As Boolean
         Dim listBaseType As BaseType = CType(list.BaseType, BaseType)
         If list.Hidden OrElse listBaseType <> BaseType.DocumentLibrary Then
            Return False
         End If

         Dim listBaseTemplate As SPTemplateType = CType(list.BaseTemplate, SPTemplateType)

         If baseTemplateType = SPTemplateType.All Then
            Return listBaseTemplate = SPTemplateType.DocumentLibrary OrElse listBaseTemplate = SPTemplateType.PictureLibrary OrElse listBaseTemplate = SPTemplateType.AssetLibrary
         Else
            Return listBaseTemplate = baseTemplateType
         End If
      End Function

      Friend Shared Function CombineUrl(ByVal uri As Uri, ByVal name As String) As Uri
         If Not name Is Nothing Then
            Dim urib As UriBuilder = New UriBuilder(uri)
            urib.Path = System.IO.Path.Combine(urib.Path, name)
            uri = urib.Uri
         End If

         Return uri
      End Function

      Public Function GetChildren(ByVal parentList As SPListInfo, ByVal parentItemInfo As SPItemInfo) As SPItemInfo()
         Dim query As CamlQuery = New CamlQuery()
         query.ViewXml = "<View/>"

         If Not parentItemInfo Is Nothing Then
            query.FolderServerRelativeUrl = parentItemInfo.ServerRelativeUrl
         End If

         Dim ret As List(Of SPItemInfo) = New List(Of SPItemInfo)()
         Dim siteUri As Uri = New Uri(_serverSettings.Uri)

         Using clientContext As ClientContext = CreateContext()
            clientContext.Load(clientContext.Web.Lists)
            clientContext.Load(clientContext.Web.Lists, Function(lists) lists.Include(Function(l) l.RootFolder.ServerRelativeUrl, Function(l) l.OnQuickLaunch))
            clientContext.ExecuteQuery()

            Dim list As List = clientContext.Web.Lists.GetById(parentList.Id)
            Dim listItems As ListItemCollection = list.GetItems(query)
            If Not listItems Is Nothing Then
               clientContext.Load(listItems)
               clientContext.Load(listItems, Function(items) items.Include(Function(item) item.Id, Function(item) item.FileSystemObjectType, Function(item) item.DisplayName, Function(item) item.FieldValuesAsText))
               clientContext.ExecuteQuery()

               For Each item As ListItem In listItems
                  If item.FileSystemObjectType = FileSystemObjectType.File OrElse item.FileSystemObjectType = FileSystemObjectType.Folder Then
                     Dim spItemInfo As SPItemInfo = New SPItemInfo(siteUri, item, parentList, parentItemInfo)
                     ret.Add(spItemInfo)
                  End If
               Next item
            End If
         End Using

         Return ret.ToArray()
      End Function
   End Class
End Namespace
