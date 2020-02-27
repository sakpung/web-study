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

Imports Leadtools
Imports Leadtools.Ocr

Partial Public Class ZonePropertiesDialog : Inherits Form
   Private _ocrEngine As IOcrEngine
   Private _ocrPage As IOcrPage
   Private _newZoneCount As Integer

   Private _updateZonesControl As UpdateZonesControl
   Private _updateCellsControl As UpdateCellsControl
   Private _viewerControl As ViewerControl

   Public Sub New(ByVal ocrEngine As IOcrEngine, ByVal ocrPage As IOcrPage, ByVal viewerControl As ViewerControl, ByVal selectedZoneIndex As Integer)
      InitializeComponent()

      _ocrEngine = ocrEngine
      _ocrPage = ocrPage
      _viewerControl = viewerControl

      ' Initialize the zones list
      Dim i As Integer = 0
      Do While i < _ocrPage.Zones.Count
         Dim addedZone As TreeNode = _tvZonesList.Nodes.Add("Zone " & (i + 1).ToString())
         addedZone.Tag = i

         Dim cells As OcrZoneCell() = Nothing
         cells = _ocrPage.Zones.GetZoneCells(_ocrPage.Zones(i))
         If Not _ocrPage.TableZoneManager Is Nothing And Not cells Is Nothing AndAlso cells.Length > 0 Then
            Dim j As Integer = 0
            Do While j < cells.Length
               Dim addedCell As TreeNode = addedZone.Nodes.Add("Cell " & (j + 1).ToString())
               addedCell.Tag = cells(j)
               j += 1
            Loop
         End If
         i += 1
      Loop

      If _tvZonesList.Nodes.Count > 0 Then
         If (selectedZoneIndex >= 0) Then
            _tvZonesList.SelectedNode = _tvZonesList.Nodes(selectedZoneIndex)
         Else
            _tvZonesList.SelectedNode = _tvZonesList.Nodes(0)
         End If
      End If

      _updateZonesControl = New UpdateZonesControl(_viewerControl)
      AddHandler _updateZonesControl.Action, AddressOf _updateZonesControl_Action
      _pnlContainer.Controls.Add(_updateZonesControl)

      _updateCellsControl = New UpdateCellsControl()
      _pnlContainer.Controls.Add(_updateCellsControl)

      _pnlContainer.Controls("UpdateCellsControl").Visible = False

      _updateZonesControl.Activate(ocrEngine, ocrPage, _tvZonesList, _ocrPage.Zones)
      _tvZonesList.Select()
      UpdateUIState()
   End Sub

   Private Sub _updateZonesControl_Action(ByVal sender As Object, ByVal e As ActionEventArgs)
      Select Case e.Action
         Case "ZonePropertiesChanged"
            UpdateUIState()
      End Select
   End Sub

   Private Sub UpdateUIState()
      ' Zones controls
      _btnDeleteZone.Enabled = (Not _tvZonesList.SelectedNode Is Nothing) AndAlso (_tvZonesList.SelectedNode.Tag.GetType() Is GetType(Integer))
      _btnClearZones.Enabled = _tvZonesList.Nodes.Count > 0

      ' Cells Controls
      _btnDetectCells.Enabled = False
      If _ocrPage.Zones.Count > 0 Then
         Dim zoneIndex As Integer = -1
         If Not _tvZonesList.SelectedNode Is Nothing Then
            If _tvZonesList.SelectedNode.Parent Is Nothing Then
               zoneIndex = CInt(_tvZonesList.SelectedNode.Tag)
            Else
               zoneIndex = CInt(_tvZonesList.SelectedNode.Parent.Tag)
            End If

            If zoneIndex >= 0 Then
               Dim zone As OcrZone = _ocrPage.Zones(zoneIndex)
               _btnDetectCells.Enabled = (zone.ZoneType = OcrZoneType.Table) AndAlso (_tvZonesList.SelectedNode.Tag.GetType() Is GetType(Integer))
            End If
         End If
      End If

      _btnClearCells.Enabled = (Not _tvZonesList.SelectedNode Is Nothing) AndAlso (_tvZonesList.SelectedNode.Tag.GetType() Is GetType(Integer)) AndAlso (_tvZonesList.SelectedNode.Nodes.Count > 0)

      ' Only show the cells manipulation controls in case of OmniPage engines only (Professional and Arabic engines)
      _cellsGroupBox.Visible = _ocrEngine.EngineType = OcrEngineType.OmniPage OrElse _ocrEngine.EngineType = OcrEngineType.OmniPageArabic
   End Sub

   Private Sub _tvZonesList_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles _tvZonesList.AfterSelect
      Dim index As Integer = 0
      If _tvZonesList.SelectedNode.Tag.GetType() Is GetType(Integer) Then
         If _pnlContainer.Controls("UpdateZonesControl").Visible = False Then
            _pnlContainer.Controls("UpdateCellsControl").Visible = False
            _pnlContainer.Controls("UpdateZonesControl").Visible = True

            _updateZonesControl.Activate(_ocrEngine, _ocrPage, _tvZonesList, _ocrPage.Zones)
         End If

         If (Not _tvZonesList.SelectedNode Is Nothing) Then
            index = CInt(_tvZonesList.SelectedNode.Tag)
         Else
            index = -1
         End If
         If index >= 0 Then
            _updateZonesControl.ZoneToControls(index)
         End If
      Else
         Dim cells As OcrZoneCell() = Nothing
         cells = _ocrPage.Zones.GetZoneCells(_ocrPage.Zones(CInt(_tvZonesList.SelectedNode.Parent.Tag)))
         If _pnlContainer.Controls("UpdateCellsControl").Visible = False Then
            _pnlContainer.Controls("UpdateZonesControl").Visible = False
            _pnlContainer.Controls("UpdateCellsControl").Visible = True

            _updateCellsControl.Activate(_ocrEngine, _ocrPage, _tvZonesList, _ocrPage.Zones, cells)
         End If

         Dim cell As OcrZoneCell = CType(_tvZonesList.SelectedNode.Tag, OcrZoneCell)
         _updateCellsControl.CellToControls(cell)
      End If

      _updateZonesControl.UpdateUIState()
      UpdateUIState()
   End Sub

   Private Sub _btnAddZone_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnAddZone.Click
      ' Add a new zone
      Dim zone As OcrZone = New OcrZone()
      zone.Bounds = New LeadRect(0, 0, 1, 1)
      _ocrPage.Zones.Add(zone)

      Dim addedZone As TreeNode = _tvZonesList.Nodes.Add("New zone " & (_newZoneCount + 1).ToString())
      addedZone.Tag = _ocrPage.Zones.Count - 1
      _tvZonesList.SelectedNode = addedZone

      _newZoneCount += 1

      _updateZonesControl.UpdateUIState()
      UpdateUIState()
   End Sub

   Private Sub UpdateZonesIndices()
      Dim index As Integer = 0
      For Each parentNode As TreeNode In _tvZonesList.Nodes
         EnumerateChildNodes(parentNode, index)
      Next parentNode
   End Sub

   Private Sub EnumerateChildNodes(ByVal parentNode As TreeNode, ByRef index As Integer)
      If parentNode.Tag.GetType() Is GetType(Integer) Then
         parentNode.Tag = index
         index += 1
      End If

      For Each node As TreeNode In parentNode.Nodes
         EnumerateChildNodes(node, index)
      Next node
   End Sub

   Private Sub _btnDeleteZone_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnDeleteZone.Click
      Dim selectedZoneIndex As Integer = CInt(_tvZonesList.SelectedNode.Tag)
      _ocrPage.Zones.RemoveAt(selectedZoneIndex)

      RemoveHandler _tvZonesList.AfterSelect, AddressOf _tvZonesList_AfterSelect
      _tvZonesList.Nodes.Remove(_tvZonesList.SelectedNode)
      AddHandler _tvZonesList.AfterSelect, AddressOf _tvZonesList_AfterSelect

      _updateZonesControl.UpdateUIState()
      UpdateZonesIndices()
      UpdateUIState()
      _tvZonesList.Focus()

      Dim selectedNode As TreeNode = _tvZonesList.SelectedNode
      _tvZonesList.SelectedNode = Nothing
      _tvZonesList.SelectedNode = selectedNode
   End Sub

   Private Sub _btnClearZones_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnClearZones.Click
      ' Delete all the zones
      _tvZonesList.Nodes.Clear()
      _ocrPage.Zones.Clear()

      _updateZonesControl.Activate(_ocrEngine, _ocrPage, _tvZonesList, _ocrPage.Zones)

      _updateZonesControl.ZoneToControls(-1)
      _updateZonesControl.UpdateUIState()
      UpdateUIState()
   End Sub

   Private Sub _btnDetectCells_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnDetectCells.Click
      Dim selectedZoneIndex As Integer = CInt(_tvZonesList.SelectedNode.Tag)

      Try
         _ocrPage.TableZoneManager.AutoDetectCells(selectedZoneIndex)
      Catch e1 As Exception
      End Try

      Dim cells As OcrZoneCell() = Nothing
      cells = _ocrPage.Zones.GetZoneCells(_ocrPage.Zones(selectedZoneIndex))
      If Not cells Is Nothing AndAlso cells.Length > 0 Then
         _tvZonesList.SelectedNode.Nodes.Clear()
         Dim i As Integer = 0
         Do While i < cells.Length
            Dim addedNode As TreeNode = _tvZonesList.SelectedNode.Nodes.Add("Cell " & (i + 1).ToString())
            addedNode.Tag = cells(i)
            i += 1
         Loop

         _tvZonesList.SelectedNode.Expand()
         _viewerControl.ZonesUpdated()
         UpdateUIState()
      End If

      _tvZonesList.Focus()
   End Sub

   Private Sub _btnClearCells_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnClearCells.Click
      Dim selectedZoneIndex As Integer = CInt(_tvZonesList.SelectedNode.Tag)

      _tvZonesList.SelectedNode.Nodes.Clear()
      _viewerControl.ClearZoneCells(CInt(_tvZonesList.SelectedNode.Tag))

      _tvZonesList.Focus()
      UpdateUIState()
   End Sub

   Private Sub _okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _okButton.Click
      _okButton.Focus()

      ' Force checking the LostFocus events before proceed with this code in order to accept the user 
      ' Input when he/she press enter in any of the edit boxes.
      Application.DoEvents()
   End Sub
End Class
