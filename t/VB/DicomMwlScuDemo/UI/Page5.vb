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

Imports Leadtools.Dicom
Imports Leadtools.DicomDemos

Namespace DicomDemo
   Partial Public Class Page5 : Inherits UserControl
      Private _globals As Globals

      Public Sub New(ByRef pGlobals As Globals)
         InitializeComponent()

         _globals = pGlobals
      End Sub

      Private Sub Page5_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.VisibleChanged
         If Visible Then
            UpdateListAndTree()
         End If
      End Sub

      '
      '* When the user selects an element tree node, it will update the textbox with the element's value
      '
      Private Sub treeDSResult_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs)
         If Not (CType(e.Node, MyTreeNode)).m_Element Is Nothing Then
            txtElementValue.Text = (CType(e.Node, MyTreeNode)).m_DS.GetConvertValue((CType(e.Node, MyTreeNode)).m_Element)
         Else
            txtElementValue.Text = ""
         End If
      End Sub

      Private Sub Page5_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Try
            lstEmptyTags.SmallImageList = _globals.m_IconImageList
            lstEmptyTags.SetTreeView(treeDSResult)
            treeDSResult.ImageList = _globals.m_IconImageList
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* When a ListView item is selected, the corresponding node in the treeview will also get selected
      '
      Private Sub lstEmptyTags_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lstEmptyTags.SelectedIndexChanged
         If lstEmptyTags.SelectedItems.Count > 0 Then
            Dim selItem As MyListViewItem = CType(lstEmptyTags.SelectedItems(0), MyListViewItem)
            Dim selNode As MyTreeNode = CType(treeDSResult.SelectedNode, MyTreeNode)

            Try
               If (Not selNode Is Nothing) AndAlso (Not selNode.m_Element Is Nothing) Then
#if (LTV15_CONFIG)
                  If Not ((selItem.m_Element.Tag = selNode.m_Element.Tag) AndAlso (selItem.m_Element.UserTag = selNode.m_Element.UserTag)) Then
#else
                  If Not (selItem.m_Element.Tag = selNode.m_Element.Tag) Then
#End If
                            treeDSResult.SelectNodeByElement(selItem.m_Element)
                  End If
               Else
                  treeDSResult.SelectNodeByElement(selItem.m_Element)
               End If
            Catch ex As Exception
               MessageBox.Show(ex.ToString())
            End Try
         End If
      End Sub

      '
      '* When a list view item is double-clicked, the user can modify the element's data
      '
      Private Sub lstEmptyTags_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lstEmptyTags.DoubleClick
         Try
            UpdateElement((CType(lstEmptyTags.SelectedItems(0), MyListViewItem)).m_Element)
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Clears and populates the tree and list view based on the global dataset.
      '* Called each time the dataset on which the tree and list view get their information from.
      '
      Private Sub UpdateListAndTree()
         Try
            treeDSResult.Nodes.Clear()
            lstEmptyTags.Items.Clear()
            treeDSResult.BuildTreeFromDataset(_globals.m_DS, False)
            lstEmptyTags.Update(_globals.m_DS, _globals.m_nClass)
            _globals.m_bMandatoryElementsFilled = (lstEmptyTags.Items.Count = 0)
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try

      End Sub

      '
      '* When a tree view item with an element is double-clicked, the user can modify the element's data
      '
      Private Sub treeDSResult_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles treeDSResult.DoubleClick
         Try
            If (Not treeDSResult.SelectedNode Is Nothing) AndAlso (Not (CType(treeDSResult.SelectedNode, MyTreeNode)).m_Element Is Nothing) Then

               If (Not IsImageElement((CType(treeDSResult.SelectedNode, MyTreeNode)).m_Element)) Then
                  Try
                     UpdateElement((CType(treeDSResult.SelectedNode, MyTreeNode)).m_Element)
                  Catch ex As Exception
                     MessageBox.Show(ex.ToString())
                  End Try
               End If
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Modifys an element from a MyTreeNode or a MyListViewItem, updates the global dataset
      '*   and redisplays the dataset in the tree and list views.
      '
      Private Sub UpdateElement(ByVal element As DicomElement)
         Try
            Dim dlgEdit As EditValueDlg = New EditValueDlg(_globals.m_DS, element)

            If dlgEdit.ShowDialog() = DialogResult.OK Then
               Dim count As Integer

               count = dlgEdit.listBoxValues.Items.Count
               If count > 0 Then
                  Dim values As String = ""

                  For Each item As String In dlgEdit.listBoxValues.Items
                     If values.Length > 0 Then
                        values &= "\"
                     End If

                     values &= item
                  Next item
                  _globals.m_DS.FreeElementValue(element)
                  _globals.m_DS.SetConvertValue(element, values, count)
               Else
                  _globals.m_DS.FreeElementValue(element)
               End If

               UpdateListAndTree()
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Determines whether or not the element is an image
      '
      Private Function IsImageElement(ByVal element As DicomElement) As Boolean
         Try
            If Not element Is Nothing Then
               Dim tag As DicomTag

#if (LTV15_CONFIG)
               If element.UserTag <> 0 Then
                  tag = DicomTagTable.Instance.Find(element.UserTag)
               Else
                  tag = DicomTagTable.Instance.Find(element.Tag)
               End If
#else
                tag = DicomTagTable.Instance.Find(element.Tag)
#End If


                    ' Pixel Data tags will not be displayed in our list box instead we will load
                    '  them in the image viewer
                    If Not tag Is Nothing AndAlso tag.Name.IndexOf("Pixel Data") = -1 Then
                  element = _globals.m_DS.GetParentElement(element)
                  If Not element Is Nothing Then
#if (LTV15_CONFIG)
                     If element.UserTag <> 0 Then
                        tag = DicomTagTable.Instance.Find(element.UserTag)
                     Else
                        tag = DicomTagTable.Instance.Find(element.Tag)
                     End If
#else
                     tag = DicomTagTable.Instance.Find(element.Tag)
#End If

                            If Not tag Is Nothing AndAlso tag.Name.IndexOf("Pixel Data") <> -1 Then
                        Return True
                     End If
                  End If
               Else
                  Return True
               End If
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try

         Return False
      End Function
   End Class
End Namespace
