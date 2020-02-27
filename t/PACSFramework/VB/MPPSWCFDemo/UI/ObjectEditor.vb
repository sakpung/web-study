' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System
Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Reflection
Imports Leadtools.Demos

Namespace MPPSWCFDemo.UI
	Partial Public Class ObjectEditor(Of T As Class)
		Inherits Form
	   Private _CodeValue As PropertyInfo
	   Private _CodingScheme As PropertyInfo

		Private _EditObject As T

		Public Property EditObject() As T
			Get
				Return _EditObject
			End Get
			Set(ByVal value As T)
			   _EditObject = value
			   GetPropertyInfo()
			End Set
		End Property

		Public Sub New(ByVal sequence As T, ByVal description As String)
			InitializeComponent()
			_EditObject = Copy(sequence)
			If _EditObject Is Nothing Then
				_EditObject = Activator.CreateInstance(Of T)()
			End If
			GetPropertyInfo()

			propertyGridEditObject.SelectedObject = _EditObject
			Icon = My.Resources.LvSample
			labelDescription.Text = description
		End Sub

		Private Sub GetPropertyInfo()
		   If _EditObject IsNot Nothing Then
			  Dim type As Type = _EditObject.GetType()

			  _CodeValue = type.GetProperty("CodeValue")
			  _CodingScheme = type.GetProperty("CodingSchemeDesignator")
		   End If
		End Sub

		Private Function Copy(ByVal source As T) As T
			If source Is Nothing Then
				Return Nothing
			Else
				Dim ms As New MemoryStream()
				Dim bf As New BinaryFormatter()
				Dim copy_Renamed As T

				bf.Serialize(ms, source)
				ms.Position = 0
				copy_Renamed = TryCast(bf.Deserialize(ms), T)
				ms.Close()

				Return copy_Renamed
			End If
		End Function

		Private Sub propertyGridEditObject_PropertyValueChanged(ByVal s As Object, ByVal e As PropertyValueChangedEventArgs) Handles propertyGridEditObject.PropertyValueChanged
		   If e.ChangedItem.PropertyDescriptor.Name = "CodeValue" OrElse e.ChangedItem.PropertyDescriptor.Name = "CodingSchemeDesignator" Then
			  If String.IsNullOrEmpty(e.ChangedItem.Value.ToString()) Then
				 If e.ChangedItem.PropertyDescriptor.Name = "CodeValue" Then
					Messager.ShowError(Me, "Must provide a value for CodeValue.")
					SetValue(_CodeValue, e.OldValue.ToString())
				 Else
					Messager.ShowError(Me, "Must provide a value for CodingSchemeDesignator.")
					SetValue(_CodingScheme, e.OldValue.ToString())
				 End If
			  End If
		   End If
		End Sub

		Private Sub SetValue(ByVal [property] As PropertyInfo, ByVal oldValue As String)
		   If [property] IsNot Nothing Then
			  [property].SetValue(propertyGridEditObject.SelectedObject, oldValue, Nothing)
			  propertyGridEditObject.Refresh()
		   End If
		End Sub
	End Class
End Namespace
