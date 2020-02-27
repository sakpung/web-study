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
Imports Leadtools.Dicom.Common.Editing
Imports Leadtools.Dicom.Common.DataTypes.Modality
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Common.Extensions
Imports Leadtools.Dicom.Common.DataTypes

Namespace DicomDemo
	Public Partial Class DicomEditor : Inherits Form
		Private _Excluded As List(Of Long) = New List(Of Long)()
		Private _Dataset As DicomDataSet
		Private _EditableDicom As DicomEditableObject = New DicomEditableObject()
		Private OnCheckProperty As Action(Of BeforeAddElementEventArgs)

		Private _Data As Object

		Public ReadOnly Property Data() As Object
			Get
				Return _Data
			End Get
		End Property

		Private _DefaultTag As Long = -1

		Public Property DefaultTag() As Long
			Get
				Return _DefaultTag
			End Get
			Set
				_DefaultTag = Value
			End Set
		End Property

		Public Sub New(ByVal excluded As List(Of Long))
			InitializeComponent()
			_Excluded.AddRange(excluded)
		End Sub

		Private Sub OnBeforeElementAdd(ByVal sender As Object, ByVal e As BeforeAddElementEventArgs)
			If Not OnCheckProperty Is Nothing Then
				OnCheckProperty(e)
			End If
		End Sub

		Public Function Edit(Of T)(ByVal owner As IWin32Window, ByRef Data As T, ByVal checkDelegate As Action(Of BeforeAddElementEventArgs)) As DialogResult
			Dim result As DialogResult

            OnCheckProperty = checkDelegate
            AddHandler _EditableDicom.BeforeAddElement, AddressOf OnBeforeElementAdd
			_Data = Data
			result = ShowDialog(owner)
			If result = DialogResult Then
				Data = CType(_Data, T)
			End If
			Return result
		End Function

		Private Sub DicomEditor_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			_Dataset = New DicomDataSet()
			_Dataset.Initialize(DicomClassType.Undefined, DicomDataSetInitializeType.ExplicitVRLittleEndian)
            _Dataset.Set(New BeforeAddTagDelegate(AddressOf OnBeforeAdd), _Data)
			_EditableDicom.DefaultTag = _DefaultTag
			_EditableDicom.DataSet = _Dataset
			propertyGridDataset.SelectedObject = _EditableDicom
		End Sub

      Private Function OnBeforeAdd(ByVal parent As LinkedList(Of Long), ByVal data_Renamed As Object, ByVal tag As Long) As Boolean
         Return _Excluded.Contains(tag)
      End Function

		Private Sub DicomEditor_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			If DialogResult = System.Windows.Forms.DialogResult.OK Then
				_Data = Activator.CreateInstance(_Data.GetType())
				_EditableDicom.DataSet.Get(_Data)
			End If
		End Sub
	End Class
End Namespace
