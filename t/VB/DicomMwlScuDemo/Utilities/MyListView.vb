' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Dicom


Namespace DicomDemo
   Friend Class MyListView : Inherits ListView
      Private m_TreeView As MyTreeView

      Public Sub SetTreeView(ByRef tv As MyTreeView)
         m_TreeView = tv
      End Sub

      '
      '* Parses through the data set, finds the mandatory type 1 elements, and adds them
      '*   to the ListView.
      '
      Public Overloads Sub Update(ByVal ds As MyDicomDataSet, ByVal nClass As DicomClassType)
         Try
            If ds Is Nothing Then
               Return
            End If

            Dim currentItem As MyListViewItem
            Dim strTag As String = ""
            Dim strDesc As String = ""

            Dim element As DicomElement
            element = ds.GetFirstEmptyElementType1(nClass, strTag, strDesc)
            Do While Not element Is Nothing
               currentItem = New MyListViewItem()
               currentItem.Text = strTag
               currentItem.SubItems.Add(strDesc)
               currentItem.SubItems.Add("")
               currentItem.m_Element = element
               currentItem.ImageIndex = CInt(MyIconIndex.Missing)

               Dim treeNode As MyTreeNode = m_TreeView.FindNodeByElement(element, Nothing, Nothing)
               If Not treeNode Is Nothing Then
                  m_TreeView.FindNodeByElement(element, Nothing, Nothing).ImageIndex = CInt(MyIconIndex.Missing)
                  m_TreeView.FindNodeByElement(element, Nothing, Nothing).SelectedImageIndex = CInt(MyIconIndex.Missing)
                  Items.Add(currentItem)
               End If

               element = ds.GetNextEmptyElementType1(element, nClass, strTag, strDesc)
            Loop
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub
   End Class
End Namespace
