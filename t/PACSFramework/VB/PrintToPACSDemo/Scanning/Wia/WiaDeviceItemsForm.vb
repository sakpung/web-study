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
   Partial Public Class WiaDeviceItemsForm : Inherits Form
      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub WiaDeviceItemsForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         FrmMain._selectedItemIndex = -1

         ' Enumerate the device child items.
         EnumWiaDeviceItems()

         ' Disable the OK button since there will be no initial selection
         _btnOk.Enabled = False
      End Sub

      Private Sub EnumWiaDeviceItems()
         Dim deviceName As String
         Dim itemName As String
         Dim value As Integer

         Try
            If FrmMain._enumeratedItemsList.Count > 0 Then
               FrmMain._enumeratedItemsList.Clear()
               _tvWiaDeviceItems.Nodes.Clear()
            End If

            Dim rootItem As Object

            rootItem = FrmMain._wiaSession.GetRootItem(Nothing)

            ' Get the selected device name.
            deviceName = FrmMain._wiaSession.GetPropertyString(rootItem, Nothing, WiaPropertyId.DeviceInfoDevName)

            ' Add the root item as the first item in the array.
            FrmMain._enumeratedItemsList.Add(rootItem)

            ' Enable the enumerate items event.
            AddHandler FrmMain._wiaSession.EnumItemsEvent, AddressOf wiaSession_EnumItemsEvent

            ' Enumerate the child items for the root item.
            FrmMain._wiaSession.EnumChildItems(rootItem)

            ' Disable the enumerate items event.
            RemoveHandler FrmMain._wiaSession.EnumItemsEvent, AddressOf wiaSession_EnumItemsEvent

            ' Loop through the items array adding them all to the items list.
            For Each i As Object In FrmMain._enumeratedItemsList
               itemName = FrmMain._wiaSession.GetPropertyString(i, Nothing, WiaPropertyId.ItemName)

               If FrmMain._wiaVersion = WiaVersion.Version1 Then
                  If i Is rootItem Then ' This is the root item.
                     If FrmMain._wiaSession.SelectedDeviceType = WiaDeviceType.Scanner Then
                        ' Get the selected device source type (Feeder or Flatbed)
                        value = FrmMain._wiaSession.GetPropertyLong(i, Nothing, WiaPropertyId.ScannerDeviceDocumentHandlingSelect)

                        If (value And CInt(WiaScanningModeFlags.Feeder)) = CInt(WiaScanningModeFlags.Feeder) Then
                           itemName &= " - Feeder"
                        End If
                        If (value And CInt(WiaScanningModeFlags.Flatbed)) = CInt(WiaScanningModeFlags.Flatbed) Then
                           itemName &= " - Flatbed"
                        End If
                     End If
                  End If
               End If

               If String.IsNullOrEmpty(itemName) Then
                  itemName = "Item"
               End If

               AddTreeViewNode(itemName)
            Next i

            ' Expand the tree items
            _tvWiaDeviceItems.ExpandAll()
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            DialogResult = DialogResult.Cancel
         End Try
      End Sub

      Private Sub wiaSession_EnumItemsEvent(ByVal sender As Object, ByVal e As WiaEnumItemsEventArgs)
         FrmMain._enumeratedItemsList.Add(e.Item)
      End Sub

      Private Sub AddTreeViewNode(ByVal nodeName As String)
         If _tvWiaDeviceItems.Nodes.Count = 0 Then
            _tvWiaDeviceItems.Nodes.Add(nodeName)
         Else
            _tvWiaDeviceItems.Nodes(_tvWiaDeviceItems.Nodes.Count - 1).Nodes.Add(nodeName)
         End If
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOk.Click
         FrmMain._selectedItemIndex = _tvWiaDeviceItems.SelectedNode.Index + _tvWiaDeviceItems.SelectedNode.Level
         DialogResult = DialogResult.OK
      End Sub

      Private Sub _tvWiaDeviceItems_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles _tvWiaDeviceItems.AfterSelect
         FrmMain._selectedItemIndex = _tvWiaDeviceItems.SelectedNode.Index + _tvWiaDeviceItems.SelectedNode.Level

         If (Not FrmMain._forCapabilities) Then
            If FrmMain._selectedItemIndex <= 0 Then
               _btnOk.Enabled = False
            Else
               ' If the OK button is disabled then enable it unless the root item is selected.
               If (Not _btnOk.Enabled) Then
                  _btnOk.Enabled = True
               End If
            End If
         Else
            _btnOk.Enabled = True
         End If
      End Sub

      Private Sub _tvWiaDeviceItems_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles _tvWiaDeviceItems.DoubleClick
         FrmMain._selectedItemIndex = _tvWiaDeviceItems.SelectedNode.Index + _tvWiaDeviceItems.SelectedNode.Level

         If FrmMain._selectedItemIndex > 0 Then
            DialogResult = DialogResult.OK
         End If
      End Sub
   End Class
End Namespace
