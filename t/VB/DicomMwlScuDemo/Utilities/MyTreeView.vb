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
Imports Leadtools.DicomDemos

Namespace DicomDemo
   Public Class MyTreeView : Inherits TreeView

      Public Sub New()
         MyBase.New()
         ' Do nothing extra
      End Sub

      Public Function GetSelectedRootNode() As MyTreeNode
         ' Get the root parent node of the currently selected node
         Dim RootNode As MyTreeNode = CType(SelectedNode, MyTreeNode)

         Try

            Do While Not RootNode.Parent Is Nothing
               RootNode = CType(RootNode.Parent, MyTreeNode)
            Loop
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Return Nothing
         End Try

         Return RootNode
      End Function

      '
      '* This function takes a DicomDataSet and builds the tree.
      '* If IsMWLDS == true then it will create a new root node because there are likely going to be
      '*   more than one datasets in this tree
      '* If IsMWLDS == false then all of the IOD Class nodes will be put into the root level of the tree
      '*   because there is only expected to be one dataset in the tree
      '
      Public Delegate Sub BuildTreeFromDatasetDelegate(ByVal ds As DicomDataSet, ByVal IsMWLDS As Boolean)
        Public Sub BuildTreeFromDataset(ByVal ds As DicomDataSet, ByVal IsMWLDS As Boolean)
         If Globals._closing = True OrElse Me.Disposing OrElse Me.IsDisposed Then
             Return
         End If
         If InvokeRequired Then
            Invoke(New BuildTreeFromDatasetDelegate(AddressOf BuildTreeFromDataset), ds, IsMWLDS)
         Else
            Try
               Dim IODClassNodes As TreeNodeCollection
               If IsMWLDS Then
                  ' Add a root level node since there could be multiple MWL datasets to be displayed
                  ' Add a root level node since there could be multiple MWL datasets to be displayed
                  Dim parentNodeString As String = String.Format("{0:D3} Modality Work List - {1} ", (Nodes.Count + 1), Utils.GetStringValue(ds, DemoDicomTags.Modality, False))
                  Dim rootNode As MyTreeNode = New MyTreeNode(parentNodeString, ds)
                  Nodes.Add(rootNode)
                  rootNode.ImageIndex = CInt(MyIconIndex.Worklist)
                  rootNode.SelectedImageIndex = CInt(MyIconIndex.Worklist)
                  IODClassNodes = rootNode.Nodes
               Else
                  ' Use the tree's root for IOD classes
                  IODClassNodes = Nodes
               End If

               ' Insert nodes for IOD classes
               Dim i As Integer = 0
               Do While i < ds.ModuleCount
                  Dim dm As DicomModule = ds.FindModuleByIndex(i)
                  Dim dIod As DicomIod = DicomIodTable.Instance.FindModule(ds.InformationClass, dm.Type)

                  If Not dIod Is Nothing Then
                     IODClassNodes.Add(New MyTreeNode(dIod.Name, ds, dIod))
                     IODClassNodes(i).ImageIndex = CInt(MyIconIndex.Folder)
                     IODClassNodes(i).SelectedImageIndex = CInt(MyIconIndex.Folder)
                  Else
                     IODClassNodes.Add(New MyTreeNode("UNKNOWN"))
                     IODClassNodes(i).ImageIndex = CInt(MyIconIndex.Missing)
                     IODClassNodes(i).SelectedImageIndex = CInt(MyIconIndex.Missing)
                  End If

                  ' Insert nodes for the elements within the current IOD class
                  Dim j As Integer = 0
                  Do While j < dm.Elements.Length
                     ' Determine the element tag
                     Dim tag As DicomTag
                     Dim tagValue As Long

#if (LTV15_CONFIG)

                     If dm.Elements(j).Tag <> DemoDicomTags.Undefined Then
                        tag = DicomTagTable.Instance.Find(dm.Elements(j).Tag)
                        tagValue = CLng(dm.Elements(j).Tag)
                     Else
                        tag = DicomTagTable.Instance.Find(dm.Elements(j).UserTag)
                        tagValue = dm.Elements(j).UserTag
                     End If
#else
                        tag = DicomTagTable.Instance.Find(dm.Elements(j).Tag)
                        tagValue = CLng(dm.Elements(j).Tag)
#End If

                            ' Add new element TreeNode
                            IODClassNodes(i).Nodes.Add(New MyTreeNode(String.Format("{0:X4}:{1:X4} - {2}", Utils.GetGroup(tagValue), Utils.GetElement(tagValue), tag.Name), ds, dm.Elements(j)))

                     IODClassNodes(i).Nodes(j).ImageIndex = CInt(MyIconIndex.Element)
                     IODClassNodes(i).Nodes(j).SelectedImageIndex = CInt(MyIconIndex.Element)

                     ' Check to see if the element has children
                     If Not ds.GetChildElement(dm.Elements(j), True) Is Nothing Then
                        IODClassNodes(i).Nodes(j).ImageIndex = CInt(MyIconIndex.Sequence)
                        IODClassNodes(i).Nodes(j).SelectedImageIndex = CInt(MyIconIndex.Sequence)

                        ' Recursively add children of this element
                        AddChildrenOfElement(ds, CType(IODClassNodes(i).Nodes(j), MyTreeNode), dm.Elements(j))
                     End If
                     j += 1
                  Loop
                  i += 1
               Loop
            Catch ex As Exception
               MessageBox.Show(ex.ToString())
            End Try
         End If
      End Sub

      '
      '* Recursively add children of an element TreeNode
      '
      Private Sub AddChildrenOfElement(ByVal ds As DicomDataSet, ByVal parentNode As MyTreeNode, ByVal parentElement As DicomElement)
         Try
            Dim currentElement As DicomElement = ds.GetChildElement(parentElement, True)
            Dim parentNodeChildCount As Integer = 0
            Do While Not currentElement Is Nothing
               Dim dIod As DicomIod = DicomIodTable.Instance.Find(Nothing, parentElement.Tag, DicomIodType.Element, False)

               ' Determine the element tag
               Dim tag As DicomTag
               Dim tagValue As Long
#if (LTV15_CONFIG)
               If currentElement.Tag <> DemoDicomTags.Undefined Then
                  tag = DicomTagTable.Instance.Find(currentElement.Tag)
                  tagValue = CLng(currentElement.Tag)
               Else
                  tag = DicomTagTable.Instance.Find(currentElement.UserTag)
                  tagValue = currentElement.UserTag
               End If
#else
                  tag = DicomTagTable.Instance.Find(currentElement.Tag)
                  tagValue = CLng(currentElement.Tag)
#End If

                    ' Add new element TreeNode
                    parentNode.Nodes.Add(New MyTreeNode(String.Format("{0:X4}:{1:X4} - {2}", Utils.GetGroup(tagValue), Utils.GetElement(tagValue), tag.Name), ds, currentElement))

               ' Check to see if the element has children
               If Not ds.GetChildElement(currentElement, True) Is Nothing Then
                  parentNode.Nodes(parentNodeChildCount).ImageIndex = CInt(MyIconIndex.Sequence)
                  parentNode.Nodes(parentNodeChildCount).SelectedImageIndex = CInt(MyIconIndex.Sequence)

                  ' Recursively add children of this element
                  AddChildrenOfElement(ds, CType(parentNode.Nodes(parentNode.Nodes.Count - 1), MyTreeNode), currentElement)
               End If

               currentElement = ds.GetNextElement(currentElement, True, True)
               parentNodeChildCount += 1
            Loop
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Finds and selects the TreeNode with the specified DicomElement.
      '
      Public Sub SelectNodeByElement(ByVal element As DicomElement)
         Try
            Dim nodeToSelect As MyTreeNode = FindNodeByElement(element, Nothing, Nothing)

            If Not nodeToSelect Is Nothing Then
               SelectedNode = nodeToSelect
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Recursively search the tree for the a node with the specified DicomElement.
      '
      Public Function FindNodeByElement(ByVal element As DicomElement, ByVal parentNode As MyTreeNode, ByVal foundNode As MyTreeNode) As MyTreeNode
         If Nodes.Count = 0 Then
            Return Nothing
         End If
         Dim currentNode As MyTreeNode

         Try
            If parentNode Is Nothing Then
               currentNode = CType(Nodes(0), MyTreeNode)
            Else
               currentNode = CType(parentNode.Nodes(0), MyTreeNode)
            End If


            Do While (Not currentNode Is Nothing) AndAlso (foundNode Is Nothing)
               If Not currentNode.m_Element Is Nothing Then
                  'The current node is an element
#if (LTV15_CONFIG)
                  If (currentNode.m_Element.Tag = element.Tag) AndAlso (currentNode.m_Element.UserTag = element.UserTag) Then
#else
                  If (currentNode.m_Element.Tag = element.Tag) Then
#End If
                            ' We've found the node
                            foundNode = currentNode
                  ElseIf currentNode.Nodes.Count > 0 Then
                     ' We didn't find the node and this node has children
                     foundNode = FindNodeByElement(element, currentNode, Nothing)
                     currentNode = CType(currentNode.NextNode, MyTreeNode)
                  Else
                     ' We didn't find the node and there aren't any children
                     currentNode = CType(currentNode.NextNode, MyTreeNode)
                  End If
               Else
                  'the current node is not an element
                  If currentNode.Nodes.Count > 0 Then
                     ' We didn't find the node and this node has children
                     foundNode = FindNodeByElement(element, currentNode, Nothing)
                     currentNode = CType(currentNode.NextNode, MyTreeNode)
                  Else
                     ' We didn't find the node and there aren't any children
                     currentNode = CType(currentNode.NextNode, MyTreeNode)
                  End If
               End If
            Loop
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
            Return Nothing
         End Try

         Return foundNode
      End Function
   End Class
End Namespace
