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
Imports Leadtools.Barcode


Partial Public Class WriteBarcodeDialogBox : Inherits Form
   Private _barcodeEngine As BarcodeEngine
   Private _bounds As LeadRect

   Public Delegate Function WriteBarcodeDelegate(ByVal data As BarcodeData) As Boolean
   Private _writeBarcodeDelegate As WriteBarcodeDelegate

   Private _selectedGroupIndex As Integer
   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public ReadOnly Property SelectedGroupIndex() As Integer
      Get
         Return _selectedGroupIndex
      End Get
   End Property

   Private _selectedSymbology As BarcodeSymbology
   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public ReadOnly Property SelectedSymbology() As BarcodeSymbology
      Get
         Return _selectedSymbology
      End Get
   End Property

   Public Sub New(ByVal barcodeEngine As BarcodeEngine, ByVal sampleSymbologiesRasterImage As RasterImage, ByVal bounds As LeadRect, ByVal groupIndex As Integer, ByVal symbology As BarcodeSymbology, ByVal writeBarcodeDelegate As WriteBarcodeDelegate)
      InitializeComponent()

      _availableSymbologyListBox.SampleSymbologiesRasterImage = sampleSymbologiesRasterImage

      _barcodeEngine = barcodeEngine
      _bounds = bounds

      _selectedGroupIndex = groupIndex
      _selectedSymbology = symbology

      _writeBarcodeDelegate = writeBarcodeDelegate
   End Sub

   Private Class SymbologyGroup
      Public Sub New(ByVal writeOptions_Renamed As BarcodeWriteOptions)
         _writeOptions = writeOptions_Renamed
      End Sub

      Private _writeOptions As BarcodeWriteOptions
      Public Property WriteOptions() As BarcodeWriteOptions
         Get
            Return _writeOptions
         End Get
         Set(value As BarcodeWriteOptions)
            _writeOptions = value
         End Set
      End Property

      Public Overrides Function ToString() As String
         Return WriteOptions.FriendlyName
      End Function
   End Class

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If (Not DesignMode) Then
         For Each writeOptions As BarcodeWriteOptions In _barcodeEngine.Writer.GetAllDefaultOptions()
            _groupsListBox.Items.Add(New SymbologyGroup(CType(IIf(TypeOf writeOptions.Clone() Is BarcodeWriteOptions, writeOptions.Clone(), Nothing), BarcodeWriteOptions)))
         Next writeOptions

         _groupsListBox.SelectedIndex = _selectedGroupIndex

         For Each symbology As BarcodeSymbology In _availableSymbologyListBox.Items
            If symbology = _selectedSymbology Then
               _availableSymbologyListBox.SelectedItem = symbology
               Exit For
            End If
         Next symbology

         If _availableSymbologyListBox.SelectedIndex = -1 Then
            _availableSymbologyListBox.SelectedIndex = 0
         End If

         ResizePropertyGridFirstColumn(_dataPropertyGrid, 20)
         Dim data As BarcodeData = CType(IIf(TypeOf _dataPropertyGrid.SelectedObject Is BarcodeData, _dataPropertyGrid.SelectedObject, Nothing), BarcodeData)
         data.Bounds = _bounds

         _groupPropertyGrid.ExpandAllGridItems()
         _dataPropertyGrid.ExpandAllGridItems()

         UpdateUIState()
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Shared Sub ResizePropertyGridFirstColumn(ByVal thePropertyGrid As PropertyGrid, ByVal percentage As Integer)
      Dim type As Type = GetType(PropertyGrid)
      Dim fi As System.Reflection.FieldInfo = type.GetField("gridView", System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance)
      Dim gridView As Object = fi.GetValue(thePropertyGrid)
      Dim gridViewType As Type = gridView.GetType()
      Dim gridColWidth As Integer = CInt(CDbl(thePropertyGrid.Width) * percentage / 100.0)
      gridViewType.InvokeMember("MoveSplitterTo", System.Reflection.BindingFlags.NonPublic Or System.Reflection.BindingFlags.Instance Or System.Reflection.BindingFlags.InvokeMethod, Nothing, gridView, New Object() {gridColWidth})
   End Sub

   Private Sub _groupOptionsResetToDefaultsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _groupOptionsResetToDefaultsButton.Click
      Dim group As SymbologyGroup = CType(IIf(TypeOf _groupsListBox.SelectedItem Is SymbologyGroup, _groupsListBox.SelectedItem, Nothing), SymbologyGroup)
      group.WriteOptions = CType(IIf(TypeOf Activator.CreateInstance(group.WriteOptions.GetType()) Is BarcodeWriteOptions, Activator.CreateInstance(group.WriteOptions.GetType()), Nothing), BarcodeWriteOptions)
      _groupPropertyGrid.SelectedObject = group.WriteOptions
   End Sub

   Private Sub _groupsListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _groupsListBox.SelectedIndexChanged
      Dim group As SymbologyGroup = CType(IIf(TypeOf _groupsListBox.SelectedItem Is SymbologyGroup, _groupsListBox.SelectedItem, Nothing), SymbologyGroup)

      _groupPropertyGrid.SelectedObject = group.WriteOptions

      UpdateAvailableSymbologies()
   End Sub

   Private Sub UpdateAvailableSymbologies()
      Dim group As SymbologyGroup = CType(IIf(TypeOf _groupsListBox.SelectedItem Is SymbologyGroup, _groupsListBox.SelectedItem, Nothing), SymbologyGroup)

      ' Clear the extra symbologies box and add the new ones not found in the right pane
      _availableSymbologyListBox.BeginUpdate()

      _availableSymbologyListBox.Items.Clear()

      Dim groupSymbologies As BarcodeSymbology() = group.WriteOptions.GetSupportedSymbologies()
      For Each groupSymbology As BarcodeSymbology In groupSymbologies
         _availableSymbologyListBox.Items.Add(groupSymbology)
      Next groupSymbology

      _availableSymbologyListBox.EndUpdate()

      _availableSymbologyListBox.SelectedIndex = 0

      UpdateUIState()
   End Sub

   Private Sub _availableSymbologyListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _availableSymbologyListBox.SelectedIndexChanged
      Dim symbology As BarcodeSymbology = CType(_availableSymbologyListBox.SelectedItem, BarcodeSymbology)

      Dim oldData As BarcodeData = CType(IIf(TypeOf _dataPropertyGrid.SelectedObject Is BarcodeData, _dataPropertyGrid.SelectedObject, Nothing), BarcodeData)
      Dim newData As BarcodeData = BarcodeData.CreateDefaultBarcodeData(symbology)

      ' Get the old data bounds and set it into the new barcode
      If Not oldData Is Nothing Then
         newData.Bounds = oldData.Bounds
      End If

      _dataPropertyGrid.SelectedObject = newData

      UpdateUIState()
   End Sub

   Private Sub UpdateUIState()
      Dim validated As Boolean = False

      If (Not validated) Then
         validated = _availableSymbologyListBox.SelectedIndex <> -1
      End If

      _okButton.Enabled = validated
   End Sub

   Private Sub _okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _okButton.Click
      ' Set all the options to the engine
      Dim defaultOptions As BarcodeWriteOptions() = _barcodeEngine.Writer.GetAllDefaultOptions()

      For Each group As SymbologyGroup In _groupsListBox.Items
         For Each defaultOption As BarcodeWriteOptions In defaultOptions
            If defaultOption.GetType() Is group.WriteOptions.GetType() Then
               group.WriteOptions.CopyTo(defaultOption)
            End If
         Next defaultOption
      Next group

      _selectedGroupIndex = _groupsListBox.SelectedIndex
      _selectedSymbology = CType(_availableSymbologyListBox.SelectedItem, BarcodeSymbology)

      Dim data As BarcodeData = CType(IIf(TypeOf _dataPropertyGrid.SelectedObject Is BarcodeData, _dataPropertyGrid.SelectedObject, Nothing), BarcodeData)
      If (Not _writeBarcodeDelegate(data)) Then
         DialogResult = DialogResult.None
      End If
   End Sub
End Class
