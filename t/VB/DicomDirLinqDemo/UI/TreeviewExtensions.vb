' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Common.Extensions

Namespace VBDicomDirLinqDemo.UI
	Public Module TreeviewExtensions
		Sub New()
		End Sub
		<System.Runtime.CompilerServices.Extension> _
		Public Sub LoadDirectory(ByVal treeview As TreeView, ByVal ds As DicomDataSet)
			FillTreeKeys(treeview,ds,Nothing, Nothing)
		End Sub

		Private Sub FillTreeKeys(ByVal treeview As TreeView, ByVal ds As DicomDataSet, ByVal ParentKeyElement As DicomElement, ByVal ParentNode As TreeNode)
			Dim CurrentKeyElement, CurrentKeyChildElement As DicomElement
			Dim node As TreeNode
			Dim name As String
			Dim temp As String = ""

			If ParentKeyElement Is Nothing Then
				CurrentKeyElement = ds.GetFirstKey(Nothing, True)
			Else
				CurrentKeyElement = ds.GetChildKey(ParentKeyElement)
			End If

			' Add the keys to the TreeView
			Do While CurrentKeyElement IsNot Nothing
				' Get key name
				temp = ds.GetKeyValueString(CurrentKeyElement)

				If (temp IsNot Nothing) OrElse (temp = "") Then
					name = temp
				Else
					name = "UNKNOWN"
				End If

				' Add at root or beneath its parent
				If ParentNode Is Nothing Then
					node = treeview.Nodes.Add(name)
				Else
					node = ParentNode.Nodes.Add(name)
				End If

				node.Tag = CurrentKeyElement

				' Add the current key's non-key child elements
				CurrentKeyChildElement = ds.GetChildElement(CurrentKeyElement, True)
				Do While CurrentKeyChildElement IsNot Nothing
					FillKeySubTree(treeview,ds,CurrentKeyChildElement, node, False)
					CurrentKeyChildElement = ds.GetNextElement(CurrentKeyChildElement, True, True)
				Loop


				' Recursively add child keys
				If ds.GetChildKey(CurrentKeyElement) IsNot Nothing Then
					FillTreeKeys(treeview,ds,CurrentKeyElement, node)
				End If

				CurrentKeyElement = ds.GetNextKey(CurrentKeyElement, True)
			Loop
		End Sub

		Private Sub FillKeySubTree(ByVal treeview As TreeView, ByVal ds As DicomDataSet, ByVal element As DicomElement, ByVal ParentNode As TreeNode, ByVal recurse As Boolean)
			Dim node As TreeNode
			Dim name As String
			Dim temp As String = ""
			Dim tempElement As DicomElement
			Dim tag As DicomTag

			' Get the tag's numerical display value (XXXX:XXXX)
			tag = DicomTagTable.Instance.Find(element.Tag)
			temp = String.Format("{0:x4}:{1:x4} - ", element.Tag.GetGroup(), element.Tag.GetElement())

			' Get the tag's name
			If tag Is Nothing Then
				name = "Item"
			Else
				name = tag.Name
			End If

			temp = temp & name

			' Add the node either on the root or beneath its parent
			If ParentNode IsNot Nothing Then
				node = ParentNode.Nodes.Add(temp)
			Else
				node = treeview.Nodes.Add(temp)
			End If

			node.Tag = element
			node.ImageIndex = 1
			node.SelectedImageIndex = 1

			' If the element has children, recursively add them
			tempElement = ds.GetChildElement(element, True)
			If tempElement IsNot Nothing Then
				node.ImageIndex = 0
				node.SelectedImageIndex = 0
				FillKeySubTree(treeview,ds,tempElement, node, True)
			End If

			If recurse Then
				tempElement = ds.GetNextElement(element, True, True)
				If tempElement IsNot Nothing Then
					FillKeySubTree(treeview,ds,tempElement, ParentNode, True)
				End If
			End If
		End Sub
	End Module
End Namespace
