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

Partial Public Class SupportedCapabilitiesForm : Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Private Sub SupportedCapabilitiesForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
      ' Add the list view columns.
      _lvCapabilities.Columns.Add("Property ID", 230, HorizontalAlignment.Left)
      _lvCapabilities.Columns.Add("Property Name", 165, HorizontalAlignment.Left)
      _lvCapabilities.Columns.Add("Property Type", 80, HorizontalAlignment.Left)
      _lvCapabilities.Columns.Add("Property Access", 150, HorizontalAlignment.Left)

      Try
         MainForm._capabilitiesList.Clear()

         ' Enable the EnumCapabilities event.
         AddHandler MainForm._wiaSession.EnumCapabilitiesEvent, AddressOf _wiaSession_EnumCapabilitiesEvent

         ' enumerate the selected WIA item capabilities.
         MainForm._wiaSession.EnumCapabilities(MainForm._selectedWiaItem, 0)

         ' Disable the EnumCapabilities event.
         RemoveHandler MainForm._wiaSession.EnumCapabilitiesEvent, AddressOf _wiaSession_EnumCapabilitiesEvent

         ' Loop through the capabilities array adding them to the capabilities list.
         For Each i As WiaCapability In MainForm._capabilitiesList
            Dim item As ListViewItem

            item = _lvCapabilities.Items.Add(i.PropertyId.ToString())

            item.SubItems.Add(i.PropertyName)
            item.SubItems.Add(i.VariableType.ToString())
            item.SubItems.Add(i.PropertyAttributes.ToString())
         Next i

         _lblCapabilitiesCount.Text = MainForm._capabilitiesList.Count.ToString()
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub _wiaSession_EnumCapabilitiesEvent(ByVal sender As Object, ByVal e As WiaEnumCapabilitiesEventArgs)
      If e.CapabilitiesCount > 0 Then
         MainForm._capabilitiesList.Add(e.Capability)
      End If
   End Sub

   Private Sub _lvCapabilities_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _lvCapabilities.MouseDoubleClick
      If _lvCapabilities.FocusedItem.Index < 0 Then
         Return
      End If

      ShowCapabilityValidValues(_lvCapabilities.FocusedItem.Index)
   End Sub

   Private Sub ShowCapabilityValidValues(ByVal itemIndex As Integer)
      Dim capability As WiaCapability = CType(MainForm._capabilitiesList(itemIndex), WiaCapability)
      If ((capability.PropertyAttributes And WiaPropertyAttributesFlags.List) = WiaPropertyAttributesFlags.List) OrElse ((capability.PropertyAttributes And WiaPropertyAttributesFlags.Flag) = WiaPropertyAttributesFlags.Flag) Then
         Using CapsListValuesDlg As CapabilitiesListValuesForm = New CapabilitiesListValuesForm()
            CapsListValuesDlg._selItemIndex = itemIndex
            CapsListValuesDlg.ShowDialog(Me)
         End Using
      ElseIf (capability.PropertyAttributes And WiaPropertyAttributesFlags.Range) = WiaPropertyAttributesFlags.Range Then
         Using CapsRangeValuesDlg As CapabilitiesRangeValuesForm = New CapabilitiesRangeValuesForm()
            CapsRangeValuesDlg._selItemIndex = itemIndex
            CapsRangeValuesDlg.ShowDialog(Me)
         End Using
      End If
   End Sub
End Class
