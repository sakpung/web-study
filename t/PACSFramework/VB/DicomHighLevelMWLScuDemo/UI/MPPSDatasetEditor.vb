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
Imports System.Reflection
Imports Leadtools.Dicom.Common.DataTypes.Modality
Imports Leadtools.Dicom.Common.DataTypes
Imports Leadtools.Dicom.Common.Extensions
Imports Leadtools.Dicom
Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.IO

Namespace DicomDemo
	Public Partial Class MPPSDatasetEditor : Inherits Form
		Private _ExcludeList As List(Of Long) = New List(Of Long)()

		Public Property ExcludeList() As List(Of Long)
			Get
				Return _ExcludeList
			End Get
			Set
				_ExcludeList = Value
			End Set
		End Property

		' constants used to hide a checkbox
		Private Const TVIF_STATE As Integer = &H8
		Private Const TVIS_STATEIMAGEMASK As Integer = &HF000
		Private Const TV_FIRST As Integer = &H1100
		Private Const TVM_SETITEM As Integer = TV_FIRST + 63

		<DllImport("user32.dll")> _
		Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
		End Function

		' struct used to set node properties
		Public Structure TVITEM
			Public mask As Integer
			Public hItem As IntPtr
			Public state As Integer
			Public stateMask As Integer
			<MarshalAs(UnmanagedType.LPTStr)> _
			Public lpszText As String
			Public cchTextMax As Integer
			Public iImage As Integer
			Public iSelectedImage As Integer
			Public cChildren As Integer
			Public lParam As IntPtr
		End Structure

		Private Sub RemoveNodeCheckBox(ByVal node As TreeNode)
			Dim tvi As TVITEM = New TVITEM()
			Dim lparam As IntPtr = IntPtr.Zero

			tvi.hItem = node.Handle
			tvi.mask = TVIF_STATE
			tvi.stateMask = TVIS_STATEIMAGEMASK
			tvi.state = 0
			lparam = Marshal.AllocHGlobal(Marshal.SizeOf(tvi))
			Marshal.StructureToPtr(tvi, lparam, False)
			SendMessage(treeViewDataset.Handle, TVM_SETITEM, IntPtr.Zero, lparam)
		End Sub

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub MPPSDatasetEditor_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			LoadTree()
		End Sub

		Private Sub LoadTree()
			Dim type As Type = GetType(ModalityPerformedProcedureStep)
			Dim node As TreeNode = New TreeNode("Modality Performed Procedure Step")
			Dim mpps As ModalityPerformedProcedureStep = New ModalityPerformedProcedureStep()

			mpps.ScheduledStepAttributeSequence.Add(New ScheduledStepAttribute())
			mpps.ScheduledStepAttributeSequence(0).RequestedProcedureCodeSequence.Add(New CodeSequence())
			BuildNode(mpps, type, node)
			treeViewDataset.Nodes.Add(node)
			treeViewDataset.ExpandAll()
			RemoveNodeCheckBox(node)
			BuildDataSet()
		End Sub

		Private Sub BuildNode(ByVal data As Object, ByVal t1 As Type, ByRef parentNode As TreeNode)
			Dim currentElement As String = String.Empty

			Try
				Dim childMain As TreeNode = Nothing
				Dim childProp As TreeNode = Nothing
				Dim value As Object = Nothing

				If data Is Nothing Then
					Return
				End If

				Dim props As PropertyInfo() = t1.GetProperties()

				For Each prop As PropertyInfo In props
					Dim attribs As ElementAttribute() = TryCast(prop.GetCustomAttributes(GetType(ElementAttribute), False), ElementAttribute())
					Dim tag As DicomTag
					Dim vr As DicomVRType = DicomVRType.UN

					If attribs Is Nothing OrElse attribs.Length = 0 Then
						Continue For
					End If

					tag = DicomTagTable.Instance.Find(attribs(0).Tag)
					If Not tag Is Nothing Then
						vr = tag.VR
					End If

                    If (attribs(0).Requirement = DicomIodUsageType.Type1MandatoryElement OrElse attribs(0).Requirement = DicomIodUsageType.Type2MandatoryElement) AndAlso vr <> DicomVRType.SQ Then
                        Continue For
                    End If

					If (Not prop.Name.StartsWith("ExtensionData")) Then
						' For exceptions
						currentElement = GetName(t1) & "." & prop.Name
						' Property value
						value = prop.GetValue(data, Nothing)
						If prop.Name.EndsWith("PrimaryID") Then
							parentNode.Text += String.Format(" - [{0}]", value)
						End If
						If IsGenericType(GetType(List(Of )), prop.PropertyType) Then
							Dim list As IList = CType(prop.GetValue(data, Nothing), IList)

							If Not list Is Nothing Then
								For Each child As Object In list
									childMain = New TreeNode(String.Format("{0}", prop.Name))
									CheckNode(childMain, attribs(0))
									childMain.Tag = attribs(0)
									If attribs(0).Requirement = DicomIodUsageType.Type1MandatoryElement OrElse attribs(0).Requirement = DicomIodUsageType.Type2MandatoryElement Then
										childMain.ForeColor = Color.Red
									End If

									BuildNode(child, child.GetType(), childMain)
									parentNode.Nodes.Add(childMain)
								Next child
							End If
						ElseIf prop.PropertyType.IsClass AndAlso Not prop.PropertyType Is GetType(String) AndAlso Not prop.PropertyType Is GetType(PersonName) Then
							Dim child_object As Object

							childMain = New TreeNode(prop.Name)
							childMain.Tag = attribs(0)
							CheckNode(childMain, attribs(0))
							child_object = Convert.ChangeType(value, prop.PropertyType)
							BuildNode(child_object, prop.PropertyType, childMain)
							parentNode.Nodes.Add(childMain)
						Else
							childProp = New TreeNode(prop.Name)
							childProp.Tag = attribs(0)
							CheckNode(childProp, attribs(0))
							If attribs(0).Requirement = DicomIodUsageType.Type1MandatoryElement OrElse attribs(0).Requirement = DicomIodUsageType.Type2MandatoryElement Then
								childProp.ForeColor = Color.Red
							End If
							parentNode.Nodes.Add(childProp)
						End If
					End If
				Next prop
			Catch ex As Exception
				Throw New Exception(currentElement, ex)
			End Try
		End Sub

		Private Function GetName(ByVal t As Type) As String
			Dim result As String = t.ToString()
			If result.Contains(".") Then
				result = result.Substring(result.LastIndexOf(".") + 1)
			End If
			If result.EndsWith("[]") Then
				result = result.Substring(0, result.Length - 2)
			End If
			Return result
		End Function

		Private Function IsGenericType(ByVal genericType As Type, ByVal type As Type) As Boolean
			Do While Not type Is Nothing
				If type.IsGenericType AndAlso type.GetGenericTypeDefinition() Is genericType Then
					Return True
				End If
				type = type.BaseType
			Loop
			Return False
		End Function

		Private Sub CheckNode(ByVal node As TreeNode, ByVal attrib As ElementAttribute)
			node.Checked = attrib.Requirement = DicomIodUsageType.Type1MandatoryElement OrElse attrib.Requirement = DicomIodUsageType.Type2MandatoryElement OrElse Not _ExcludeList.Contains(attrib.Tag)

		End Sub

		Private Sub treeViewDataset_BeforeCheck(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs) Handles treeViewDataset.BeforeCheck
			Dim attrib As ElementAttribute = TryCast(e.Node.Tag, ElementAttribute)

			If Not attrib Is Nothing Then
				If attrib.Requirement = DicomIodUsageType.Type1MandatoryElement OrElse attrib.Requirement = DicomIodUsageType.Type2MandatoryElement Then
					e.Cancel = True
					Return
				End If
			End If
			If e.Node.ForeColor = SystemColors.InactiveCaption Then
				e.Cancel = True
				Return
			End If
			EnableChildNodes(e.Node, (Not e.Node.Checked))
		End Sub

		Public Sub EnableChildNodes(ByVal parent As TreeNode, ByVal enable As Boolean)
			If parent.Nodes.Count > 0 Then
				For Each node As TreeNode In parent.Nodes
					If (Not enable) Then
						node.ForeColor = SystemColors.InactiveCaption
					Else
						node.ForeColor = SystemColors.WindowText
					End If

					EnableChildNodes(node, enable)
				Next node
			End If
		End Sub

		Private Function OnBeforeAdd(ByVal parent As LinkedList(Of Long), ByVal data As Object, ByVal tag As Long) As Boolean
			Return _ExcludeList.Contains(tag)
		End Function

		Private Sub BuildDataSet()
			Using ds As DicomDataSet = New DicomDataSet()
				Dim mpps As ModalityPerformedProcedureStep = New ModalityPerformedProcedureStep()

				ds.Initialize(DicomClassType.Undefined, DicomDataSetInitializeType.ExplicitVRLittleEndian)
                ds.Set(New BeforeAddTagDelegate(AddressOf OnBeforeAdd), mpps)

				treeViewMPPSDataset.BeginUpdate()
				treeViewMPPSDataset.Nodes.Clear()
				Try
					FillTree(ds)
				Finally
					treeViewMPPSDataset.EndUpdate()
				End Try
			End Using
		End Sub

		Private Sub FillTree(ByVal ds As DicomDataSet)
			Dim element As DicomElement

			element = ds.GetFirstElement(Nothing, False, True)
			If element Is Nothing Then
				Dim err As String = String.Format("Error reading dicom dataset!")

				MessageBox.Show(err, "Error")
				Return
			End If

			FillSubTree(ds,element, Nothing)
		End Sub

		Private Sub FillSubTree(ByVal ds As DicomDataSet, ByVal element As DicomElement, ByVal ParentNode As TreeNode)
			Dim node As TreeNode
			Dim name As String
			Dim temp As String = ""
			Dim tag As DicomTag
			Dim tempElement As DicomElement

			tag = DicomTagTable.Instance.Find(element.Tag)
			If Not tag Is Nothing Then
				name = tag.Name
			Else
				name = "Item"
			End If

			Dim tagValue As Long = 0

			tagValue = element.Tag
			temp = String.Format("{0:x4}:{1:x4} - ", tagValue.GetGroup(), tagValue.GetElement())
			temp = temp & name

			If Not ParentNode Is Nothing Then
				node = ParentNode.Nodes.Add(temp)
			Else
				node = treeViewMPPSDataset.Nodes.Add(temp)
			End If

			node.Tag = element.Tag

			If ds.IsVolatileElement(element) Then
				node.ForeColor = Color.Red
			End If

			node.ImageIndex = 1
			node.SelectedImageIndex = 1

			tempElement = ds.GetChildElement(element, True)
			If Not tempElement Is Nothing Then
				node.ImageIndex = 0
				node.SelectedImageIndex = 0
				FillSubTree(ds,tempElement, node)
			End If


			tempElement = ds.GetNextElement(element, True, True)
			If Not tempElement Is Nothing Then
				FillSubTree(ds,tempElement, ParentNode)
			Else
				element = ds.GetParentElement(element)
			End If
		End Sub

		Private Function FindDatasetTag(ByVal nodes As TreeNodeCollection, ByVal tag As Long) As TreeNode

			For Each node As TreeNode In nodes
				If Not node.Tag Is Nothing Then
					Dim dsTag As Long = CLng(node.Tag)

					If dsTag = tag Then
						Return node
					End If
				End If

				Dim candidate As TreeNode = FindDatasetTag(node.Nodes, tag)

				If Not candidate Is Nothing Then
					Return candidate
				End If
			Next node

			Return Nothing
		End Function

		Private Sub treeViewDataset_AfterCheck(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles treeViewDataset.AfterCheck
			Dim attrib As ElementAttribute = TryCast(e.Node.Tag, ElementAttribute)

			If e.Node.Checked Then
				If _ExcludeList.Contains(attrib.Tag) Then
					_ExcludeList.Remove(attrib.Tag)
				End If
			Else
				_ExcludeList.Add(attrib.Tag)
			End If
			BuildDataSet()
			SelectMPPSDatasetNode(e.Node)
		End Sub

		Private Sub SelectMPPSDatasetNode(ByVal node As TreeNode)
			If node.IsSelected Then
				Dim attrib As ElementAttribute = TryCast(node.Tag, ElementAttribute)

				If Not attrib Is Nothing Then
					Dim datasetNode As TreeNode = FindDatasetTag(treeViewMPPSDataset.Nodes, attrib.Tag)

					If Not datasetNode Is Nothing Then
						treeViewMPPSDataset.SelectedNode = datasetNode
						datasetNode.EnsureVisible()
					End If
				End If
			End If
		End Sub

		Private Sub treeViewDataset_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles treeViewDataset.AfterSelect
			SelectMPPSDatasetNode(e.Node)
		End Sub
	End Class
End Namespace
