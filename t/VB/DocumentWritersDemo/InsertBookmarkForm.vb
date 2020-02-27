' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Document.Writer
Imports System

Namespace DocumentWritersDemo
   Partial Public Class InsertBookmarkForm
      Inherits Form
      Private _treeNode As TreeNode
      Private _pagesCount As Integer = 0
      Private _selectedPageIndex As Integer = 0
      Private _maxPageWidth As Integer = 0
      Private _maxPageHeight As Integer = 0

      Public Sub New(treeNode As TreeNode, pagesCount As Integer, selectedPageIndex As Integer, maxPageWidth As Integer, maxPageHeight As Integer)
         InitializeComponent()
         _treeNode = treeNode
         _pagesCount = pagesCount
         _selectedPageIndex = selectedPageIndex
         _maxPageWidth = maxPageWidth
         _maxPageHeight = maxPageHeight
      End Sub

      ''' <summary>
      ''' This action will be fired when the user changes the PageNumber selection from the combo box
      ''' which causes the MainForm to handle this event and activate the corresponding page.
      ''' </summary>
      Public Event Action As EventHandler(Of ActionEventArgs)

      Private Sub DoAction(action As String, data As Object)
         ' Raise the action event so the main form can handle it
         RaiseEvent Action(Me, New ActionEventArgs(action, data))
      End Sub

      Public ReadOnly Property PositionX() As TextBox
         Get
            Return _tbX
         End Get
      End Property

      Public ReadOnly Property PositionY() As TextBox
         Get
            Return _tbY
         End Get
      End Property

      Private Sub InsertBookmarkForm_Load(sender As Object, e As EventArgs) Handles Me.Load
         For i As Integer = 1 To _pagesCount
            _cbPageNumber.Items.Add(i.ToString())
         Next

         _tbName.Text = "Untitled"

         _cbPageNumber.SelectedIndex = _selectedPageIndex

         _tbX.Text = (0).ToString()
         _tbY.Text = (0).ToString()

         ' check if the tree node tag has value then re-update the controls
         If _treeNode IsNot Nothing Then
            _tbName.Text = _treeNode.Text
            If _treeNode.Tag IsNot Nothing Then
               Dim bookmark As PdfCustomBookmark = CType(_treeNode.Tag, PdfCustomBookmark)

               Dim pageIndex As Integer = bookmark.PageNumber - 1
               If pageIndex > _selectedPageIndex Then
                  pageIndex = _selectedPageIndex
               End If
               _cbPageNumber.SelectedIndex = pageIndex

               _tbX.Text = bookmark.XCoordinate.ToString()
               _tbY.Text = bookmark.YCoordinate.ToString()
            End If
         End If

         UpdateUIState()
      End Sub

      Private Sub UpdateUIState()
         _btnOk.Enabled = Not String.IsNullOrEmpty(_tbName.Text)
      End Sub

      Private Sub _tbName_TextChanged(sender As Object, e As EventArgs) Handles _tbName.TextChanged
         UpdateUIState()
      End Sub

      Private Sub _tbX_TextChanged(sender As Object, e As EventArgs) Handles _tbX.TextChanged
         Dim val As Integer
         If Not Integer.TryParse(_tbX.Text, val) OrElse val < 0 Then
            _tbX.Text = (0).ToString()
         End If

         If val < 0 Then
            val = 0
         End If
         If val > _maxPageWidth Then
            val = _maxPageWidth
         End If

         _tbX.Text = val.ToString()
         UpdateUIState()
      End Sub

      Private Sub _tbY_TextChanged(sender As Object, e As EventArgs) Handles _tbY.TextChanged
         Dim val As Integer
         If Not Integer.TryParse(_tbY.Text, val) OrElse val < 0 Then
            _tbY.Text = (0).ToString()
         End If

         If val < 0 Then
            val = 0
         End If
         If val > _maxPageHeight Then
            val = _maxPageHeight
         End If

         _tbY.Text = val.ToString()
         UpdateUIState()
      End Sub

      Private Sub _btnOk_Click(sender As Object, e As EventArgs) Handles _btnOk.Click
         Dim val As Integer = 0
         Dim bookmark As New PdfCustomBookmark()

         bookmark.LevelNumber = _treeNode.Level
         bookmark.Name = _tbName.Text
         bookmark.PageNumber = _cbPageNumber.SelectedIndex + 1
         Integer.TryParse(_tbX.Text, val)
         bookmark.XCoordinate = val
         Integer.TryParse(_tbY.Text, val)
         bookmark.YCoordinate = val

         _treeNode.Text = _tbName.Text
         _treeNode.Tag = bookmark

         Close()
      End Sub

      Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
         If _treeNode IsNot Nothing Then
            _treeNode.Remove()
         End If
         Close()
      End Sub

      Private Sub _cbPageNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cbPageNumber.SelectedIndexChanged
         DoAction("PageNumberChanged", _cbPageNumber.SelectedIndex + 1)
      End Sub
   End Class
End Namespace
