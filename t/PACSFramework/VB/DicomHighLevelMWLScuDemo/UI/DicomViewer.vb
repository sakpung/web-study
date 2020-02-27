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

Namespace DicomDemo
	Public Partial Class DicomViewer : Inherits Form
		Private _EditableDicom As DicomEditableObject = New DicomEditableObject()
        Private _Result As DicomDataSet = Nothing

        Private _ModuleView As Boolean = False

        Public Property ModuleView() As Boolean
            Get
                Return _ModuleView
            End Get
            Set(ByVal value As Boolean)
                If _ModuleView <> value Then
                    _ModuleView = value
                    SetPropertyView()
                End If
            End Set
        End Property


		Public Sub New(ByVal ds As DicomDataSet)
			InitializeComponent()
			_Result = ds
            AddHandler _EditableDicom.BeforeAddElement, AddressOf _EditableDicom_BeforeAddElement
			'_EditableDicom.SetServiceProvider(propertyGridDataset);
		End Sub

		Private Sub _EditableDicom_BeforeAddElement(ByVal sender As Object, ByVal e As BeforeAddElementEventArgs)
			e.Element.Attributes.Add(New ReadOnlyAttribute(True))
		End Sub

		Private Sub DicomViewer_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			_EditableDicom.DataSet = _Result
            propertyGridDataset.SelectedObject = _EditableDicom
            SetPropertyView()
        End Sub

        Private Sub SetPropertyView()
            propertyGridDataset.PropertySort = If(_ModuleView = True, PropertySort.Categorized, PropertySort.NoSort)
        End Sub

	End Class
End Namespace
