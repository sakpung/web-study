' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Ocr
Imports OcrDemo.OcrDemo.UpdateZonesControl

Namespace OcrDemo
   Partial Public Class ZonePropertiesDialog
      Inherits Form
      Private _ocrEngine As IOcrEngine
      Private _ocrPage As IOcrPage
      Private _newZoneCount As Integer

      Private _updateZonesControl As OcrDemo.UpdateZonesControl.UpdateZonesControl
      Private _viewerControl As OcrDemo.ViewerControl.ViewerControl

      Public Sub New(ocrEngine As IOcrEngine, ocrPage As IOcrPage, viewerControl As OcrDemo.ViewerControl.ViewerControl, selectedZoneIndex As Integer)
         InitializeComponent()

         _ocrEngine = ocrEngine
         _ocrPage = ocrPage
         _viewerControl = viewerControl
         _newZoneCount = 0

         _updateZonesControl = New OcrDemo.UpdateZonesControl.UpdateZonesControl(_viewerControl)
         AddHandler _updateZonesControl.Action, AddressOf _updateZonesControl_Action
         _pnlContainer.Controls.Add(_updateZonesControl)

         ' Initialize the zones list
         RemoveHandler _lbZonesList.SelectedIndexChanged, AddressOf _lbZonesList_SelectedIndexChanged
         For i As Integer = 0 To _ocrPage.Zones.Count - 1
            _lbZonesList.Items.Add(New ZoneItem("Zone", i))
         Next
         AddHandler _lbZonesList.SelectedIndexChanged, AddressOf _lbZonesList_SelectedIndexChanged

         _updateZonesControl.Activate(ocrEngine, ocrPage, _lbZonesList, _ocrPage.Zones)

         If _lbZonesList.Items.Count > 0 Then
            _lbZonesList.SelectedIndex = If((selectedZoneIndex >= 0), selectedZoneIndex, 0)
         End If

         _lbZonesList.[Select]()
         UpdateUIState()
      End Sub

      Private Sub _updateZonesControl_Action(sender As Object, e As ActionEventArgs)
         Select Case e.Action
            Case "ZonePropertiesChanged"
               UpdateUIState()
               Exit Select
         End Select
      End Sub

      Private Sub UpdateUIState()
         ' Zones controls
         _btnDeleteZone.Enabled = _lbZonesList.SelectedIndex <> -1
         _btnClearZones.Enabled = _lbZonesList.Items.Count > 0
         _btnInvertSelection.Enabled = _lbZonesList.Items.Count > 1 AndAlso _lbZonesList.SelectedItems.Count > 0
      End Sub

      Private Sub _lbZonesList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles _lbZonesList.SelectedIndexChanged
         Dim index As Integer = 0
         If _lbZonesList.SelectedIndex <> -1 Then
            index = If((_lbZonesList.SelectedItem IsNot Nothing), _lbZonesList.SelectedIndex, -1)
            If index >= 0 Then
               _updateZonesControl.ZoneToControls(index)
            End If
         End If

         _updateZonesControl.UpdateUIState()
         UpdateUIState()
      End Sub

      Private Sub _btnAddZone_Click(sender As System.Object, e As System.EventArgs) Handles _btnAddZone.Click
         ' Add a new zone
         Dim zone As New OcrZone()
         zone.Bounds = New LeadRect(0, 0, 1, 1)
         _ocrPage.Zones.Add(zone)

         _lbZonesList.Items.Add(New ZoneItem("New zone", _newZoneCount))
         _newZoneCount += 1

         _lbZonesList.ClearSelected()
         _lbZonesList.SelectedIndex = _lbZonesList.Items.Count - 1
         _updateZonesControl.UpdateUIState()
         UpdateUIState()
      End Sub

      Private Sub _btnDeleteZone_Click(sender As System.Object, e As System.EventArgs) Handles _btnDeleteZone.Click
         RemoveHandler _lbZonesList.SelectedIndexChanged, AddressOf _lbZonesList_SelectedIndexChanged

         Dim selectedItem As Integer = If((_lbZonesList.SelectedItems.Count > 0), _lbZonesList.SelectedIndices(0), 0)
         For i As Integer = _lbZonesList.SelectedItems.Count - 1 To 0 Step -1
            Dim item As ZoneItem = TryCast(_lbZonesList.SelectedItems(i), ZoneItem)
            _ocrPage.Zones.RemoveAt(_lbZonesList.SelectedIndices(i))
            _lbZonesList.Items.Remove(item)
         Next

         AddHandler _lbZonesList.SelectedIndexChanged, AddressOf _lbZonesList_SelectedIndexChanged

         _lbZonesList.SelectedIndex = If((selectedItem >= _lbZonesList.Items.Count), _lbZonesList.Items.Count - 1, selectedItem)
         _updateZonesControl.UpdateUIState()
         UpdateUIState()
         _lbZonesList.Focus()
      End Sub

      Private Sub _btnClearZones_Click(sender As System.Object, e As System.EventArgs) Handles _btnClearZones.Click
         ' Delete all the zones
         _lbZonesList.Items.Clear()
         _ocrPage.Zones.Clear()
         _newZoneCount = 0

         _updateZonesControl.ZoneToControls(-1)
         _updateZonesControl.UpdateUIState()
         UpdateUIState()
      End Sub

      Private Sub _btnInvertSelection_Click(sender As System.Object, e As System.EventArgs) Handles _btnInvertSelection.Click
         If _lbZonesList.SelectedIndices.Count > 0 Then
            Dim selectedIndices As New List(Of Integer)()
            For Each index As Integer In _lbZonesList.SelectedIndices
               selectedIndices.Add(index)
            Next

            For i As Integer = 0 To _lbZonesList.Items.Count - 1
               _lbZonesList.SetSelected(i, True)
            Next

            For Each index As Integer In selectedIndices
               _lbZonesList.SetSelected(index, False)
            Next
         End If
      End Sub
   End Class
End Namespace
