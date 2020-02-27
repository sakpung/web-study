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
Imports System.Text
Imports System.Windows.Forms
Imports System.IO

Namespace SharePointDemo
   Partial Public Class ServerControl : Inherits UserControl
      Public Sub New()
         InitializeComponent()

         ' Initialize the list view sorter
         _listView.ListViewItemSorter = New FileListViewColumnSorter()

         _refreshToolStripButton.Enabled = False
         _downloadToolStripButton.Enabled = False
      End Sub

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         ' Resize the second column to fill the client area
         _listView.Columns(1).Width = _listView.ClientSize.Width - _listView.Columns(0).Width
         MyBase.OnLoad(e)
      End Sub

      Private Sub _listView_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles _listView.ColumnClick
         ' Sort
         Dim sorter As FileListViewColumnSorter = TryCast(_listView.ListViewItemSorter, FileListViewColumnSorter)
         sorter.Sort(_listView, e.Column)
      End Sub

      Private Sub _listView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _listView.SelectedIndexChanged
         _downloadToolStripButton.Enabled = _listView.SelectedItems.Count > 0
      End Sub

      Private Sub _listView_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _listView.MouseDoubleClick
         If _downloadToolStripButton.Enabled Then
            _downloadToolStripButton.PerformClick()
         End If
      End Sub

      Private Sub _listView_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _listView.KeyPress
         If e.KeyChar = ControlChars.Cr AndAlso _downloadToolStripButton.Enabled Then
            _downloadToolStripButton.PerformClick()
         End If
      End Sub

      Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
         _titleLabel.Text = Text

         MyBase.OnTextChanged(e)
      End Sub

      Public Event ServerClicked As EventHandler(Of EventArgs)

      Private Sub _serverToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _serverToolStripButton.Click
         If Not ServerClickedEvent Is Nothing Then
            RaiseEvent ServerClicked(Me, e)
         End If
      End Sub

      Public Event RefreshClicked As EventHandler(Of EventArgs)

      Private Sub _refreshToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _refreshToolStripButton.Click
         If Not RefreshClickedEvent Is Nothing Then
            RaiseEvent RefreshClicked(Me, e)
         End If
      End Sub

      Public Event DownloadClicked As EventHandler(Of EventArgs)

      Private Sub _downloadToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _downloadToolStripButton.Click
         If Not DownloadClickedEvent Is Nothing Then
            RaiseEvent DownloadClicked(Me, e)
         End If
      End Sub

      Public Sub Populate(ByVal fileNames As IList(Of String))
         ' Populate the list

         ' First, remove all old items
         _listView.BeginUpdate()

         _listView.Items.Clear()

         Dim dictionary As FileTypeDictionary = New FileTypeDictionary(_imageList)

         Dim i As Integer = 0
         Do While i < fileNames.Count
            Dim fileName As String = fileNames(i)

            ' Get the extension of the file name without the leading "."
            ' We will use this to find the icon and description of this
            ' file from the system

            Dim extension As String = Path.GetExtension(fileName)
            If (Not String.IsNullOrEmpty(extension)) Then
               extension = extension.Substring(1, extension.Length - 1).ToLower()
            End If

            ' Add this extension to our dictionary
            ' The dictionary will check if it is already added and does nothing

            dictionary.Add(extension)

            Dim item As ListViewItem = New ListViewItem()

            ' Set the item text and image index
            item.Text = fileName
            item.ImageIndex = dictionary.GetImageIndex(extension)

            ' Add the description to the second column
            Dim description As String = dictionary.GetDescription(extension)

            item.SubItems.Add(description)

            _listView.Items.Add(item)
            i += 1
         Loop

         _listView.EndUpdate()
         _listView_SelectedIndexChanged(Me, EventArgs.Empty)

         ' Since this is populated, we can enable the refresh button
         _refreshToolStripButton.Enabled = True
      End Sub

      Public ReadOnly Property CanRefresh() As Boolean
         Get
            Return _refreshToolStripButton.Enabled
         End Get
      End Property

      Public Function GetSelectedItemName() As String
         Dim name As String = String.Empty

         If _listView.SelectedItems.Count > 0 Then
            name = _listView.SelectedItems(0).Text
         End If

         Return name
      End Function
   End Class
End Namespace
