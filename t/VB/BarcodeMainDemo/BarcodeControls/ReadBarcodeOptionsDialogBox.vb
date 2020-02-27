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
Imports BarcodeMainDemo.Leadtools.Demos

Partial Public Class ReadBarcodeOptionsDialogBox : Inherits Form
   Private _barcodeEngine As BarcodeEngine

   Private _selectedGroupIndex As Integer
   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public ReadOnly Property SelectedGroupIndex() As Integer
      Get
         Return _selectedGroupIndex
      End Get
   End Property

   Private _selectedSymbologies As BarcodeSymbology()
   Public Function GetSelectedSymbologies() As BarcodeSymbology()
      Return _selectedSymbologies
   End Function

   Private _readBarcodesWhenDialogCloses As Boolean
   Public ReadOnly Property ReadBarcodesWhenDialogCloses() As Boolean
      Get
         Return _readBarcodesWhenDialogCloses
      End Get
   End Property

   Private _totalSymbologiesCount As Integer

   Public Sub New(ByVal barcodeEngine As BarcodeEngine, ByVal sampleSymbologiesRasterImage As RasterImage, ByVal selectedGroupIndex_Renamed As Integer, ByVal selectedSymbologies As BarcodeSymbology(), ByVal readBarcodesWhenDialogCloses_Renamed As Boolean)
      InitializeComponent()

      _availableSymbologyListBox.SampleSymbologiesRasterImage = sampleSymbologiesRasterImage
      _toReadSymbologyListBox.SampleSymbologiesRasterImage = sampleSymbologiesRasterImage

      _barcodeEngine = barcodeEngine

      _selectedGroupIndex = selectedGroupIndex_Renamed
      _selectedSymbologies = selectedSymbologies

      _readBarcodesWhenDialogClosesCheckBox.Checked = readBarcodesWhenDialogCloses_Renamed
   End Sub

   Private Class SymbologyGroup
      Public Sub New(ByVal readOptions_Renamed As BarcodeReadOptions)
         _readOptions = readOptions_Renamed
      End Sub

      Private _readOptions As BarcodeReadOptions
      Public Property ReadOptions() As BarcodeReadOptions
         Get
            Return _readOptions
         End Get
         Set(value As BarcodeReadOptions)
            _readOptions = value
         End Set
      End Property

      Public Overrides Function ToString() As String
         Return ReadOptions.FriendlyName
      End Function
   End Class

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If (Not DesignMode) Then
         _totalSymbologiesCount = _barcodeEngine.Reader.GetAvailableSymbologies().Length

         For Each readOptions As BarcodeReadOptions In _barcodeEngine.Reader.GetAllDefaultOptions()
            _groupsListBox.Items.Add(New SymbologyGroup(CType(IIf(TypeOf readOptions.Clone() Is BarcodeReadOptions, readOptions.Clone(), Nothing), BarcodeReadOptions)))
         Next readOptions

         _toReadSymbologyListBox.BeginUpdate()
         For Each symbology As BarcodeSymbology In _selectedSymbologies
            _toReadSymbologyListBox.Items.Add(symbology)
         Next symbology
         _toReadSymbologyListBox.EndUpdate()

         _groupsListBox.SelectedIndex = _selectedGroupIndex

         _groupPropertyGrid.ExpandAllGridItems()

         UpdateUIState()
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _groupOptionsResetToDefaultsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _groupOptionsResetToDefaultsButton.Click
      Dim group As SymbologyGroup = CType(IIf(TypeOf _groupsListBox.SelectedItem Is SymbologyGroup, _groupsListBox.SelectedItem, Nothing), SymbologyGroup)
      group.ReadOptions = CType(IIf(TypeOf Activator.CreateInstance(group.ReadOptions.GetType()) Is BarcodeReadOptions, Activator.CreateInstance(group.ReadOptions.GetType()), Nothing), BarcodeReadOptions)
      _groupPropertyGrid.SelectedObject = group.ReadOptions
   End Sub

   Private Sub _groupsListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _groupsListBox.SelectedIndexChanged
      Dim group As SymbologyGroup = CType(IIf(TypeOf _groupsListBox.SelectedItem Is SymbologyGroup, _groupsListBox.SelectedItem, Nothing), SymbologyGroup)

      _groupPropertyGrid.SelectedObject = group.ReadOptions

      UpdateAvailableSymbologies()
   End Sub

   Private Sub UpdateAvailableSymbologies()
      Dim group As SymbologyGroup = CType(IIf(TypeOf _groupsListBox.SelectedItem Is SymbologyGroup, _groupsListBox.SelectedItem, Nothing), SymbologyGroup)

      ' Clear the extra symbologies box and add the new ones not found in the right pane
      _availableSymbologyListBox.BeginUpdate()

      _availableSymbologyListBox.Items.Clear()

      Dim groupSymbologies As BarcodeSymbology() = group.ReadOptions.GetSupportedSymbologies()
      For Each groupSymbology As BarcodeSymbology In groupSymbologies
         Dim found As Boolean = False

         For Each toReadSymbology As BarcodeSymbology In _toReadSymbologyListBox.Items
            If groupSymbology = toReadSymbology Then
               found = True
               Exit For
            End If
         Next toReadSymbology

         If (Not found) Then
            _availableSymbologyListBox.Items.Add(groupSymbology)
         End If
      Next groupSymbology

      _availableSymbologyListBox.EndUpdate()

      UpdateUIState()
   End Sub

   Private Sub _removeButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _removeButton.Click
      _toReadSymbologyListBox.BeginUpdate()

      Do While _toReadSymbologyListBox.SelectedItems.Count > 0
         _toReadSymbologyListBox.Items.Remove(_toReadSymbologyListBox.SelectedItem)
      Loop

      _toReadSymbologyListBox.EndUpdate()

      UpdateAvailableSymbologies()
   End Sub

   Private Sub _removeAllButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _removeAllButton.Click
      _toReadSymbologyListBox.Items.Clear()
      UpdateAvailableSymbologies()
   End Sub

   Private Sub _addAllSupportedSymbologiesButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _addAllSupportedSymbologiesButton.Click
      _toReadSymbologyListBox.Items.Clear()
      _toReadSymbologyListBox.BeginUpdate()
      Dim symbologies As BarcodeSymbology() = _barcodeEngine.Reader.GetAvailableSymbologies()
      For Each symbology As BarcodeSymbology In symbologies
         _toReadSymbologyListBox.Items.Add(symbology)
      Next symbology
      _toReadSymbologyListBox.EndUpdate()

      UpdateAvailableSymbologies()
   End Sub

   Private Sub _addButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _addButton.Click
      _toReadSymbologyListBox.BeginUpdate()
      For Each symbology As BarcodeSymbology In _availableSymbologyListBox.SelectedItems
         _toReadSymbologyListBox.Items.Add(symbology)
      Next symbology
      _toReadSymbologyListBox.EndUpdate()

      UpdateAvailableSymbologies()
   End Sub

   Private Sub _addAllButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _addAllButton.Click
      _toReadSymbologyListBox.BeginUpdate()
      For Each symbology As BarcodeSymbology In _availableSymbologyListBox.Items
         _toReadSymbologyListBox.Items.Add(symbology)
      Next symbology
      _toReadSymbologyListBox.EndUpdate()

      UpdateAvailableSymbologies()
   End Sub

   Private Sub _helpButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _helpButton.Click
      Dim sb As StringBuilder = New StringBuilder()

      sb.AppendLine(DemosGlobalization.GetResxString(Me.GetType(), "Resx_Help1stLine"))
      sb.AppendLine()
      sb.AppendLine(DemosGlobalization.GetResxString(Me.GetType(), "Resx_Help2ndLine"))
      sb.AppendLine()
      sb.AppendLine(DemosGlobalization.GetResxString(Me.GetType(), "Resx_Help3rdLine"))
      sb.AppendLine(DemosGlobalization.GetResxString(Me.GetType(), "Resx_Help4thLine"))
      sb.AppendLine()
      sb.AppendLine(DemosGlobalization.GetResxString(Me.GetType(), "Resx_Help5thLine"))

      MessageBox.Show(Me, sb.ToString(), DemosGlobalization.GetResxString(Me.GetType(), "Resx_HelpMsg"), MessageBoxButtons.OK, MessageBoxIcon.Information)
   End Sub

   Private Sub _availableSymbologyListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _availableSymbologyListBox.SelectedIndexChanged
      UpdateUIState()
   End Sub

   Private Sub _availableSymbologyListBox_ItemDoubleClicked(ByVal sender As Object, ByVal e As SymbologyListBoxItemDoubleClickedEventArgs) Handles _availableSymbologyListBox.ItemDoubleClicked
      _toReadSymbologyListBox.BeginUpdate()
      Dim symbology As BarcodeSymbology = CType(_availableSymbologyListBox.Items(e.Index), BarcodeSymbology)
      _toReadSymbologyListBox.Items.Add(symbology)
      _toReadSymbologyListBox.EndUpdate()

      UpdateAvailableSymbologies()
   End Sub

   Private Sub _toReadSymbologyListBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _toReadSymbologyListBox.SelectedIndexChanged
      UpdateUIState()
   End Sub

   Private Sub _toReadSymbologyListBox_ItemDoubleClicked(ByVal sender As Object, ByVal e As SymbologyListBoxItemDoubleClickedEventArgs) Handles _toReadSymbologyListBox.ItemDoubleClicked
      _toReadSymbologyListBox.BeginUpdate()
      _toReadSymbologyListBox.Items.RemoveAt(e.Index)
      _toReadSymbologyListBox.EndUpdate()

      UpdateAvailableSymbologies()
   End Sub

   Private Sub UpdateUIState()
      _addButton.Enabled = _availableSymbologyListBox.SelectedItems.Count > 0
      _addAllButton.Enabled = _availableSymbologyListBox.Items.Count > 0
      _removeButton.Enabled = _toReadSymbologyListBox.SelectedItems.Count > 0
      _removeAllButton.Enabled = _toReadSymbologyListBox.Items.Count > 0
      _okButton.Enabled = _toReadSymbologyListBox.Items.Count > 0
      _addAllSupportedSymbologiesButton.Enabled = _toReadSymbologyListBox.Items.Count <> _totalSymbologiesCount

      _allGroupSymbologesAddedLabel.Visible = _availableSymbologyListBox.Items.Count = 0
   End Sub

   Private Sub _okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _okButton.Click
      ' Set all the options to the engine
      Dim defaultOptions As BarcodeReadOptions() = _barcodeEngine.Reader.GetAllDefaultOptions()

      For Each group As SymbologyGroup In _groupsListBox.Items
         For Each defaultOption As BarcodeReadOptions In defaultOptions
            If defaultOption.GetType() Is group.ReadOptions.GetType() Then
               group.ReadOptions.CopyTo(defaultOption)
            End If
         Next defaultOption
      Next group

      _selectedGroupIndex = _groupsListBox.SelectedIndex
      _selectedSymbologies = New BarcodeSymbology(_toReadSymbologyListBox.Items.Count - 1) {}
      Dim i As Integer = 0
      Do While i < _toReadSymbologyListBox.Items.Count
         _selectedSymbologies(i) = CType(_toReadSymbologyListBox.Items(i), BarcodeSymbology)
         i += 1
      Loop

      _readBarcodesWhenDialogCloses = _readBarcodesWhenDialogClosesCheckBox.Checked
   End Sub
End Class
