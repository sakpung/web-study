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
Imports Leadtools.MedicalViewer

Namespace MedicalViewerLayoutDemo
	Public Partial Class OverlapDialog : Inherits Form
		Private _Items As List(Of ListBoxCellItem)

		Public ReadOnly Property Items() As List(Of ListBoxCellItem)
			Get
				Return _Items
			End Get
		End Property
		Public Sub New(ByVal cells As MedicalViewerCellCollection(Of MedicalViewerBaseCell))
			Dim lbc As List(Of ListBoxCellItem) = New List(Of ListBoxCellItem)()
			InitializeComponent()

			For Each cell As MedicalViewerCell In cells
				lbc.Add(New ListBoxCellItem(cell))
			Next cell
			lbc.Sort(New ListBoxCellComparer())

			For Each item As ListBoxCellItem In lbc
				listBoxCells.Items.Add(item)
			Next item
			UnSelectCells()
		End Sub

		Private Sub UnSelectCells()
			For Each item As ListBoxCellItem In listBoxCells.Items
				item.Cell.Selected = False
			Next item
		End Sub

		Private Sub listBoxCells_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listBoxCells.SelectedIndexChanged
			Dim selectedItem As ListBoxCellItem = TryCast(listBoxCells.SelectedItem, ListBoxCellItem)

			buttonMoveUp.Enabled = listBoxCells.SelectedIndex <> 0 AndAlso listBoxCells.Items.Count > 1
			buttonMoveDown.Enabled = listBoxCells.SelectedIndex <> listBoxCells.Items.Count - 1 AndAlso listBoxCells.Items.Count <> 0
			For Each item As ListBoxCellItem In listBoxCells.Items
				item.Cell.Selected = (item Is selectedItem)
			Next item
		End Sub

		Private Sub buttonMoveUp_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonMoveUp.Click
			Dim iSelectedIndex As Int32 = listBoxCells.SelectedIndex
			Dim sSelectedItem As ListBoxCellItem = TryCast(listBoxCells.SelectedItem, ListBoxCellItem)

			listBoxCells.Items.RemoveAt(iSelectedIndex)
			listBoxCells.Items.Insert(iSelectedIndex-1, sSelectedItem)
			listBoxCells.SelectedIndex = iSelectedIndex - 1
		End Sub

		Private Sub buttonMoveDown_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonMoveDown.Click
			Dim iSelectedIndex As Int32 = listBoxCells.SelectedIndex
			Dim sSelectedItem As ListBoxCellItem = TryCast(listBoxCells.SelectedItem, ListBoxCellItem)

			listBoxCells.Items.RemoveAt(iSelectedIndex)
			listBoxCells.Items.Insert(iSelectedIndex + 1, sSelectedItem)
			listBoxCells.SelectedIndex = iSelectedIndex + 1
		End Sub

		Private Sub OverlapDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			If DialogResult = System.Windows.Forms.DialogResult.OK Then
				_Items = New List(Of ListBoxCellItem)()

				For Each item As ListBoxCellItem In listBoxCells.Items
					_Items.Add(item)
				Next item
			End If
			UnSelectCells()
		End Sub
	End Class

	Public Class ListBoxCellComparer : Implements IComparer(Of ListBoxCellItem)

		#Region "IComparer<ListBoxCellItem> Members"

		Public Function Compare(ByVal x As ListBoxCellItem, ByVal y As ListBoxCellItem) As Integer Implements IComparer(Of ListBoxCellItem).Compare
			Return x.Cell.OverlapPriority.CompareTo(y.Cell.OverlapPriority)
		End Function

		#End Region
	End Class

	Public Class ListBoxCellItem
		Private _Cell As MedicalViewerCell

		Public ReadOnly Property Cell() As MedicalViewerCell
			Get
				Return _Cell
			End Get
		End Property

      Public Sub New(ByVal cell_Renamed As MedicalViewerCell)
         _Cell = cell_Renamed
      End Sub

		Public Overrides Function ToString() As String
            Return "Image Box " & _Cell.Tag.ToString()
		End Function
	End Class
End Namespace
