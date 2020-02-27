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
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.IO

Namespace Ocr2SharePointDemo
   Public Partial Class SharePointItemsListView : Inherits ListView
	  Public Sub New()
		 InitializeComponent()

		 If (Not DesignMode) Then
			Me.View = View.Details
			Me.HeaderStyle = ColumnHeaderStyle.Nonclickable
			Me.HideSelection = False
			Me.MultiSelect = False

			CreateColumns()
			SmallImageList = New ImageList()
			SmallImageList.ImageSize = New Size(16, 16)
			SmallImageList.ColorDepth = ColorDepth.Depth32Bit

			_fileTypes = New FileTypeDictionary(Me.SmallImageList)
			_fileTypes.Add(FileTypeDictionary.DiretoryType)
		 End If
	  End Sub

	  Private _fileTypes As FileTypeDictionary

	  Private Sub CreateColumns()
		 Dim nameHeader As ColumnHeader = New ColumnHeader()
		 nameHeader.Text = "Name"
		 nameHeader.Width = 150
		 Columns.Add(nameHeader)

		 Dim createdHeader As ColumnHeader = New ColumnHeader()
		 createdHeader.Text = "Created"
		 createdHeader.Width = 150
		 Columns.Add(createdHeader)

		 Dim descriptionHeader As ColumnHeader = New ColumnHeader()
		 descriptionHeader.Text = "Description"
		 descriptionHeader.Width = 150
		 Columns.Add(descriptionHeader)
	  End Sub

	  Public Sub FillHeaders()
		 Columns(0).Width = ClientSize.Width - Columns(1).Width - Columns(2).Width
	  End Sub

	  Public Sub AddSharePointItem(ByVal item As SharePoint.SPItemInfo)
		 Dim extension As String

		 If item.ItemType = SharePoint.SPItemType.File Then
			extension = Path.GetExtension(item.Name)
		 Else If item.ItemType = SharePoint.SPItemType.Folder Then
			extension = FileTypeDictionary.DiretoryType
		 Else
			Return
		 End If

		 _fileTypes.Add(extension)

		 Dim lvItem As ListViewItem = New ListViewItem()
		 lvItem.Text = item.Name
		 lvItem.ImageIndex = _fileTypes.GetImageIndex(extension)

		 Dim subItem As ListViewItem.ListViewSubItem = New ListViewItem.ListViewSubItem()

		 If String.Compare(item.Name, "..", StringComparison.OrdinalIgnoreCase) <> 0 Then
			subItem.Text = item.Created.ToString()
		 Else
			subItem.Text = String.Empty
		 End If
		 lvItem.SubItems.Add(subItem)

		 subItem = New ListViewItem.ListViewSubItem()
		 subItem.Text = _fileTypes.GetDescription(extension)
		 lvItem.SubItems.Add(subItem)

		 lvItem.Tag = item

		 Items.Add(lvItem)
	  End Sub
   End Class
End Namespace
