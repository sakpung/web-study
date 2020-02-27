' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Net

Imports Leadtools.SharePoint.Client

Namespace Ocr2SharePointDemo
   Partial Public Class SharePointBrowserControl : Inherits UserControl
      Public Sub New()
         InitializeComponent()
      End Sub

      Private _mainForm As MainForm
      Public Sub SetOwner(ByVal mainForm As MainForm)
         _mainForm = mainForm
         _sharePointItemsListView.FillHeaders()
      End Sub

      Private _serverSettings As SharePoint.SharePointServerSettings

      Public Sub SetSharePointSettings(ByVal serverSettings As SharePoint.SharePointServerSettings, ByVal lists As SharePoint.SPListInfo())
         _serverSettings = serverSettings

         _curerntFolderItem = Nothing
         _errorLabel.Visible = False

         ' Populate the document libraries, select "Shared Documents" initially if it exists

         _documentLibrariesListBox.BeginUpdate()
         _documentLibrariesListBox.Items.Clear()

         Dim sharedDocumentList As SharePoint.SPListInfo = Nothing

         For Each list As SharePoint.SPListInfo In lists
            _documentLibrariesListBox.Items.Add(list)

            If String.Compare(list.Title, "Shared Documents", StringComparison.OrdinalIgnoreCase) = 0 Then
               sharedDocumentList = list
            End If
         Next list
         _documentLibrariesListBox.EndUpdate()

         If _documentLibrariesListBox.Items.Count > 0 Then
            If Not sharedDocumentList Is Nothing Then
               _documentLibrariesListBox.SelectedItem = sharedDocumentList
            Else
               _documentLibrariesListBox.SelectedIndex = 0
            End If
         End If

         UpdateUIState()
      End Sub

      Private Sub _documentLibrariesListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _documentLibrariesListBox.SelectedIndexChanged
         ' Fill in the folders and documents from share point

         FillItems(Nothing)
      End Sub

      Private _curerntFolderItem As SharePoint.SPItemInfo

      Private Sub FillItems(ByVal parentItem As SharePoint.SPItemInfo)
         _curerntFolderItem = parentItem
         _errorLabel.Visible = False

         _sharePointItemsListView.BeginUpdate()
         _sharePointItemsListView.Items.Clear()

         ' Get the items of the selected list
         Dim listInfo As SharePoint.SPListInfo = TryCast(_documentLibrariesListBox.SelectedItem, SharePoint.SPListInfo)
         If Not listInfo Is Nothing Then
            Try
               Using wait As WaitCursor = New WaitCursor()
                  Dim helper As SharePoint.SPHelper = New SharePoint.SPHelper(_serverSettings)
                  Dim items As SharePoint.SPItemInfo() = helper.GetChildren(listInfo, parentItem)

                  ' If we have a parent item, add the special "move folder up" item
                  If Not parentItem Is Nothing Then
                     Dim item As SharePoint.SPItemInfo = New SharePoint.SPItemInfo()
                     item.ItemType = SharePoint.SPItemType.Folder
                     item.Name = ".."
                     item.ParentItem = parentItem.ParentItem
                     _sharePointItemsListView.AddSharePointItem(item)
                  End If

                  ' Add the children (folders first) to the list view
                  For Each item As SharePoint.SPItemInfo In items
                     If item.ItemType = Ocr2SharePointDemo.SharePoint.SPItemType.Folder Then
                        _sharePointItemsListView.AddSharePointItem(item)
                     End If
                  Next item

                  For Each item As SharePoint.SPItemInfo In items
                     If item.ItemType = Ocr2SharePointDemo.SharePoint.SPItemType.File Then
                        _sharePointItemsListView.AddSharePointItem(item)
                     End If
                  Next item
               End Using
            Catch ex As Exception
               _errorLabel.Text = "Error: " & ex.Message
               _errorLabel.Visible = True
            End Try
         End If

         _sharePointItemsListView.EndUpdate()

         UpdateUIState()
      End Sub

      Private Sub _sharePointItemsListView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _sharePointItemsListView.SelectedIndexChanged
         UpdateUIState()
      End Sub

      Private Sub _sharePointItemsListView_ItemActivate(ByVal sender As Object, ByVal e As EventArgs) Handles _sharePointItemsListView.ItemActivate
         If Not _sharePointItemsListView.SelectedItems Is Nothing AndAlso _sharePointItemsListView.SelectedItems.Count > 0 Then
            Dim lvItem As ListViewItem = _sharePointItemsListView.SelectedItems(0)
            Dim item As SharePoint.SPItemInfo = TryCast(lvItem.Tag, SharePoint.SPItemInfo)

            If item.ItemType = SharePoint.SPItemType.Folder Then
               ' If this is our special ".." folder, go up
               ' Go into this folder
               If String.Compare(item.Name, "..", StringComparison.OrdinalIgnoreCase) = 0 Then
                  FillItems(item.ParentItem)
               Else
                  FillItems(item)
               End If
            ElseIf item.ItemType = SharePoint.SPItemType.File Then
            End If
         End If

         UpdateUIState()
      End Sub

      Private Sub UpdateUIState()
         Dim folderPath As String = GetCurrentFolderPath(False)
         If Not folderPath Is Nothing Then
            _selectedFolderTextBox.Text = folderPath
         Else
            _selectedFolderTextBox.Text = String.Empty
         End If

         Dim filePath As String = GetCurrentFilePath(False)
         If Not filePath Is Nothing Then
            _selectedFileTextBox.Text = filePath
            _downloadButton.Enabled = True
         Else
            _selectedFileTextBox.Text = String.Empty
            _downloadButton.Enabled = False
         End If

         _mainForm.UpdateUIState()
      End Sub

      Public Function GetCurrentFolderPath(ByVal absolute As Boolean) As String
         Dim folderPath As String = Nothing

         If Not _curerntFolderItem Is Nothing Then
            If absolute Then
               If Not _curerntFolderItem.AbsoluteUri Is Nothing Then
                  folderPath = _curerntFolderItem.AbsoluteUri.ToString()
               End If
            Else
               folderPath = _curerntFolderItem.ServerRelativeUrl
            End If
         Else
            ' Get the folder path from the parent list
            Dim list As SharePoint.SPListInfo = TryCast(_documentLibrariesListBox.SelectedItem, SharePoint.SPListInfo)
            If Not list Is Nothing Then
               If absolute Then
                  folderPath = list.AbsoluteUri.ToString()
               Else
                  folderPath = list.ServerRelativeUrl
               End If
            End If
         End If

         Return folderPath
      End Function

      Public Function GetCurrentFilePath(ByVal absolute As Boolean) As String
         Dim filePath As String = Nothing

         If Not _sharePointItemsListView.SelectedItems Is Nothing AndAlso _sharePointItemsListView.SelectedItems.Count > 0 Then
            Dim lvItem As ListViewItem = _sharePointItemsListView.SelectedItems(0)
            Dim item As SharePoint.SPItemInfo = TryCast(lvItem.Tag, SharePoint.SPItemInfo)

            If item.ItemType = SharePoint.SPItemType.File Then
               If absolute Then
                  If Not item.AbsoluteUri Is Nothing Then
                     filePath = item.AbsoluteUri.ToString()
                  End If
               Else
                  filePath = item.ServerRelativeUrl
               End If
            End If
         End If

         Return filePath
      End Function

      Private Sub _listsContextMenuStrip_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) Handles _listsContextMenuStrip.Opening
         e.Cancel = _documentLibrariesListBox.SelectedItem Is Nothing
      End Sub

      Private Sub _listsCopyAbsoluteURLToClipboardToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _listsCopyAbsoluteURLToClipboardToolStripMenuItem.Click
         Dim list As SharePoint.SPListInfo = TryCast(_documentLibrariesListBox.SelectedItem, SharePoint.SPListInfo)
         If Not list Is Nothing Then
            Clipboard.SetText(list.AbsoluteUri.ToString())
         End If
      End Sub

      Private Sub _itemsContextMenuStrip_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) Handles _itemsContextMenuStrip.Opening
         If Not _sharePointItemsListView.SelectedItems Is Nothing AndAlso _sharePointItemsListView.SelectedItems.Count > 0 Then
            Dim item As SharePoint.SPItemInfo = TryCast(_sharePointItemsListView.SelectedItems(0).Tag, SharePoint.SPItemInfo)
            e.Cancel = String.Compare(item.Name, "..", StringComparison.OrdinalIgnoreCase) = 0

            If (Not e.Cancel) AndAlso item.ItemType <> SharePoint.SPItemType.File Then
               _itemsDownloadToDiskToolStripMenuItem.Enabled = False
            Else
               _itemsDownloadToDiskToolStripMenuItem.Enabled = True
            End If
         Else
            e.Cancel = True
         End If
      End Sub

      Private Sub _itemsCopyAbsoluteURLToClipboardToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _itemsCopyAbsoluteURLToClipboardToolStripMenuItem.Click
         If Not _sharePointItemsListView.SelectedItems Is Nothing AndAlso _sharePointItemsListView.SelectedItems.Count > 0 Then
            Dim item As SharePoint.SPItemInfo = TryCast(_sharePointItemsListView.SelectedItems(0).Tag, SharePoint.SPItemInfo)
            If Not item.AbsoluteUri Is Nothing AndAlso String.Compare(item.Name, "..", StringComparison.OrdinalIgnoreCase) <> 0 Then
               Clipboard.SetText(item.AbsoluteUri.ToString())
            End If
         End If
      End Sub

      Private Sub _itemsDownloadToDiskToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _itemsDownloadToDiskToolStripMenuItem.Click
         _downloadButton.PerformClick()
      End Sub

      Private Sub _refreshButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _refreshButton.Click
         RefreshCurrentFolder()
      End Sub

      Public Sub RefreshCurrentFolder()
         FillItems(_curerntFolderItem)
      End Sub

      Public Sub SelectItem(ByVal serverDocumentUri As Uri)
         If Not serverDocumentUri Is Nothing Then
            ' In current items, find if the absolute URI is equivalant to 'serverDocumentUri'
            For Each lvItem As ListViewItem In _sharePointItemsListView.Items
               Dim item As SharePoint.SPItemInfo = TryCast(lvItem.Tag, SharePoint.SPItemInfo)
               If Not item.AbsoluteUri Is Nothing AndAlso String.CompareOrdinal(item.AbsoluteUri.ToString(), serverDocumentUri.ToString()) = 0 Then
                  _sharePointItemsListView.SelectedItems.Clear()
                  lvItem.Selected = True
                  _sharePointItemsListView.Focus()
                  Exit For
               End If
            Next lvItem
         End If
      End Sub

      Private _tryDownloadItem As SharePoint.SPItemInfo
      Private _tryDownloadFileName As String
      Private Sub _downloadButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _downloadButton.Click
         If Not _sharePointItemsListView.SelectedItems Is Nothing AndAlso _sharePointItemsListView.SelectedItems.Count > 0 Then
            Dim lvItem As ListViewItem = _sharePointItemsListView.SelectedItems(0)
            _tryDownloadItem = TryCast(lvItem.Tag, SharePoint.SPItemInfo)
            If _tryDownloadItem.ItemType = SharePoint.SPItemType.File Then
               Using dlg As SaveFileDialog = New SaveFileDialog()
                  If (Not String.IsNullOrEmpty(_tryDownloadItem.FileExtension)) Then
                     dlg.Filter = String.Format("*.{0}|*.{0}|All Files|*.*", _tryDownloadItem.FileExtension)
                  Else
                     dlg.Filter = "All Files|*.*"
                  End If

                  dlg.FileName = _tryDownloadItem.Name
                  If dlg.ShowDialog(Me) = DialogResult.OK Then
                     _tryDownloadFileName = dlg.FileName
                     _mainForm.BeginOperation(New MethodInvoker(AddressOf TryDownload))
                  End If
               End Using
            End If
         End If
      End Sub

      Private Sub TryDownload()
         BeginInvoke(New SetOperationTextDelegate(AddressOf _mainForm.SetOperationText), New Object() {"Downloading " & _tryDownloadItem.AbsoluteUri.ToString()})

         Dim err As Exception = Nothing

         ' Download the file
         Try
            Dim spClient As SharePointClient = New SharePointClient()

            ' Set the credentials and proxy
            If Not _serverSettings.UserName Is Nothing Then
               spClient.Credentials = New NetworkCredential(_serverSettings.UserName, _serverSettings.Password, _serverSettings.Domain)
            End If

            If Not _serverSettings.ProxyUri Is Nothing Then
               Dim proxy As WebProxy = New WebProxy(_serverSettings.ProxyUri, _serverSettings.ProxyPort)
               If proxy.Credentials Is Nothing AndAlso Not spClient.Credentials Is Nothing Then
                  proxy.Credentials = spClient.Credentials
               Else
                  proxy.Credentials = CredentialCache.DefaultCredentials
               End If

               spClient.Proxy = proxy
            Else
               spClient.Proxy = WebRequest.GetSystemWebProxy() ' Get default system proxy settings
            End If

            ' Download the file
            spClient.DownloadFile(_tryDownloadItem.AbsoluteUri, _tryDownloadFileName)
            System.Diagnostics.Process.Start(_tryDownloadFileName)
         Catch ex As Exception
            err = ex
         End Try

         _mainForm.EndOperation(err)
      End Sub
   End Class
End Namespace
