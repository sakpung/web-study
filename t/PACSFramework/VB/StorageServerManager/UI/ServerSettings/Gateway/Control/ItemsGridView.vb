' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class ItemsGridView : Inherits UserControl
      Public Sub New()
         InitializeComponent()

         CanAdd = True

         UpdateToolStripButtons()

         AddHandler ItemsDataGridView.SelectionChanged, AddressOf ItemsDataGridView_SelectionChanged

         AddHandler AddItemToolStrip.Click, AddressOf AddItemToolStrip_Click
         AddHandler ModifyToolStripButton.Click, AddressOf ModifyToolStripButton_Click
         AddHandler DeleteToolStripButton.Click, AddressOf DeleteToolStripButton_Click

         AddHandler ItemsDataGridView.CellDoubleClick, AddressOf ItemsDataGridView_CellDoubleClick
      End Sub

      Public Event SelectedItemChanged As EventHandler

      Public ReadOnly Property SelectedRow() As DataGridViewRow
         Get
            If ItemsDataGridView.SelectedRows.Count > 0 Then
               Return ItemsDataGridView.SelectedRows(0)
            Else
               Return Nothing
            End If
         End Get
      End Property

      Public Property CanAdd() As Boolean
         Get
            Return AddItemToolStrip.Enabled
         End Get
         Set(ByVal value As Boolean)
            AddItemToolStrip.Enabled = value
         End Set
      End Property

      Private Sub ItemsDataGridView_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
         If ItemsDataGridView.SelectedRows.Count > 0 Then
            OnModifyItem()
         End If
      End Sub

      Public Property Title() As String
         Get
            Return ContainerGroupBox.Text
         End Get

         Set(ByVal value As String)
            ContainerGroupBox.Text = value
         End Set
      End Property

      Private Sub ItemsDataGridView_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
         UpdateToolStripButtons()

         If Not Nothing Is SelectedItemChangedEvent Then
            RaiseEvent SelectedItemChanged(Me, e)
         End If
      End Sub

      Private Sub UpdateToolStripButtons()
         If ItemsDataGridView.SelectedRows.Count > 0 Then
            AddItemToolStrip.Enabled = CanAdd
            DeleteToolStripButton.Enabled = True
            ModifyToolStripButton.Enabled = True
         Else
            AddItemToolStrip.Enabled = CanAdd
            DeleteToolStripButton.Enabled = False
            ModifyToolStripButton.Enabled = False
         End If
      End Sub

      Public Property DataSource() As Object
         Get
            Return ItemsDataGridView.DataSource
         End Get

         Set(ByVal value As Object)
            ItemsDataGridView.DataSource = value

            UpdateToolStripButtons()
         End Set
      End Property

      Public Property DataMember() As String
         Get
            Return ItemsDataGridView.DataMember
         End Get

         Set(ByVal value As String)
            ItemsDataGridView.DataMember = value

            UpdateToolStripButtons()
         End Set
      End Property

      Public Property AddText() As String
         Get
            Return AddItemToolStrip.Text
         End Get

         Set(ByVal value As String)
            AddItemToolStrip.Text = value
         End Set
      End Property

      Public Property ModifyText() As String
         Get
            Return ModifyToolStripButton.Text
         End Get

         Set(ByVal value As String)
            ModifyToolStripButton.Text = value
         End Set
      End Property

      Public Property DeleteText() As String
         Get
            Return DeleteToolStripButton.Text
         End Get

         Set(ByVal value As String)
            DeleteToolStripButton.Text = value
         End Set
      End Property

      Public Event AddItem As EventHandler
      Public Event ModifyItem As EventHandler
      Public Event DeleteItem As EventHandler

      Private Sub OnAddItem()
         If Not Nothing Is AddItemEvent Then
            RaiseEvent AddItem(Me, EventArgs.Empty)
         End If
      End Sub

      Private Sub OnModifyItem()
         If Not Nothing Is ModifyItemEvent Then
            RaiseEvent ModifyItem(Me, EventArgs.Empty)
         End If
      End Sub

      Private Sub OnDeleteItem()
         If Not Nothing Is DeleteItemEvent Then
            RaiseEvent DeleteItem(Me, EventArgs.Empty)
         End If
      End Sub

      Private Sub AddItemToolStrip_Click(ByVal sender As Object, ByVal e As EventArgs)
         OnAddItem()
      End Sub

      Private Sub ModifyToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         OnModifyItem()
      End Sub


      Private Sub DeleteToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         OnDeleteItem()
      End Sub
   End Class
End Namespace
