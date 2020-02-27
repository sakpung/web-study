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
Imports Leadtools.Wia

Namespace PrintToPACSDemo
   Public Partial Class CapabilitiesListValuesForm : Inherits Form
	  Public _selItemIndex As Integer

	  Public Sub New()
		 InitializeComponent()
	  End Sub

	  Private Sub CapabilitiesListValuesForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
		 Dim value As Int32
		 Dim valueString As String = String.Empty
		 Dim capability As WiaCapability = CType(FrmMain._capabilitiesList(_selItemIndex), WiaCapability)

		 _tbPropertyName.Text = capability.PropertyName

		 If (capability.PropertyAttributes And WiaPropertyAttributesFlags.List) = WiaPropertyAttributesFlags.List Then
			' Set the dialog caption.
			Me.Text = "WIA List Property Values"

			' Change the list control label text.
			_lblValues.Text = "List Values"

			If capability.Values.ListValues.ValuesCount <= 0 Then
			   Return
			End If

			Dim index As Integer = 0
			' Add the list values to the list.
			For Each i As Object In capability.Values.ListValues.Values
			   If capability.VariableType = WiaVariableTypes.Bstr Then
				  valueString = Convert.ToString(capability.Values.ListValues.Values(index))
			   Else If capability.VariableType = WiaVariableTypes.Clsid Then
				  Dim guidValue As System.Guid = CType(capability.Values.ListValues.Values(index), System.Guid)
				  valueString = guidValue.ToString()
			   Else
				  value = Convert.ToInt32(capability.Values.ListValues.Values(index))
				  Dim ret As Integer = HelperFunctions.GetWiaListPropertyValueString(capability.PropertyId, CInt(value))
				  If ret = 0 Then
					 ' Add the received value as is to the values list.
					 valueString = value.ToString()
				  Else
					 valueString = HelperFunctions.ListPropertyValueString
				  End If
			   End If
			   If (Not String.IsNullOrEmpty(valueString)) Then
				  _lbValues.Items.Add(valueString)
			   End If

			   index += 1
			Next i
		 Else
			' Set the dialog caption.
			Me.Text = "WIA Flag Property Values"

			' Change the list control label text.
			_lblValues.Text = "Flag Values"

			value = capability.Values.FlagsValues.FlagValues
			Dim ret As Integer = HelperFunctions.GetWiaFlagPropertyValueString(capability.PropertyId, value)
			If ret = 0 Then
			   ' add the values with their native ID's
			   _lbValues.Items.Add(value.ToString())
			Else
			   For Each i As String In FrmMain._flagValuesStrings
				  _lbValues.Items.Add(i)
			   Next i
			End If
		 End If
	  End Sub
   End Class
End Namespace
