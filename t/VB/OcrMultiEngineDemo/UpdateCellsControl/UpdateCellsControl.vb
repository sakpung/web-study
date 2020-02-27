' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Ocr

Partial Public Class UpdateCellsControl : Inherits UserControl
   Private _ocrEngine As IOcrEngine
   Private _ocrPage As IOcrPage
   Private _tvZonesList As TreeView
   Private _zones As IOcrZoneCollection
   Private _cells As IList(Of OcrZoneCell)

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub Activate(ByVal ocrEngine As IOcrEngine, ByVal ocrPage As IOcrPage, ByVal tvZonesList As TreeView, ByVal zones As IOcrZoneCollection, ByVal cells As IList(Of OcrZoneCell))
      _ocrEngine = ocrEngine
      _ocrPage = ocrPage
      _tvZonesList = tvZonesList
      _zones = zones
      _cells = cells

      ' Fill the cell type combo box.
      _cmbCellType.Items.Clear()
      Dim a As Array = ocrPage.TableZoneManager.GetSupportedCellTypes()
      For Each i As OcrZoneType In a
         _cmbCellType.Items.Add(i)
      Next i

      ' Fill the cell border style combo boxes.
      _cmbLeftBorderStyle.Items.Clear()
      _cmbTopBorderStyle.Items.Clear()
      _cmbRightBorderStyle.Items.Clear()
      _cmbBottomBorderStyle.Items.Clear()

      Dim b As Array = System.Enum.GetValues(GetType(OcrCellBorderLineStyle))
      For Each i As OcrCellBorderLineStyle In b
         _cmbLeftBorderStyle.Items.Add(i)
         _cmbTopBorderStyle.Items.Add(i)
         _cmbRightBorderStyle.Items.Add(i)
         _cmbBottomBorderStyle.Items.Add(i)
      Next i

      UpdateUIControls()
   End Sub

   Public Sub CellToControls(ByVal cell As OcrZoneCell)
      ' Cell Type
      _cmbCellType.SelectedItem = cell.CellType

      ' Convert the cell bounds to pixels
      Dim bounds As LeadRect = cell.Bounds
      _tbLeft.Text = bounds.X.ToString()
      _tbTop.Text = bounds.Y.ToString()
      _tbWidth.Text = bounds.Width.ToString()
      _tbHeight.Text = bounds.Height.ToString()

      ' Border Width
      _numLeftBorderWidth.Value = CDec(cell.LeftBorderWidth)
      _numTopBorderWidth.Value = CDec(cell.TopBorderWidth)
      _numRightBorderWidth.Value = CDec(cell.RightBorderWidth)
      _numBottomBorderWidth.Value = CDec(cell.BottomBorderWidth)

      ' Border Style
      _cmbLeftBorderStyle.SelectedItem = cell.LeftBorderStyle
      _cmbTopBorderStyle.SelectedItem = cell.TopBorderStyle
      _cmbRightBorderStyle.SelectedItem = cell.RightBorderStyle
      _cmbBottomBorderStyle.SelectedItem = cell.BottomBorderStyle

      ' Border Colors
      _btnLeftBorderColor.BackColor = MainForm.ConvertColor(cell.LeftBorderColor)
      _btnTopBorderColor.BackColor = MainForm.ConvertColor(cell.TopBorderColor)
      _btnRightBorderColor.BackColor = MainForm.ConvertColor(cell.RightBorderColor)
      _btnBottomBorderColor.BackColor = MainForm.ConvertColor(cell.BottomBorderColor)
   End Sub

   Private Sub _cmbCellType_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbCellType.SelectedIndexChanged
      If _tvZonesList.SelectedNode.Tag.GetType() Is GetType(OcrZoneCell) Then
         Dim cell As OcrZoneCell = CType(_tvZonesList.SelectedNode.Tag, OcrZoneCell)
         Dim index As Integer = _cells.IndexOf(cell)
         If index >= 0 Then
            _cells(index).CellType = CType(_cmbCellType.SelectedItem, OcrZoneType)
         End If
      End If
   End Sub

   Private Sub ResetBoundsValue(ByVal tb As TextBox, ByVal bounds As LeadRect)
      ' An error occurred while entering the bounds value
      ' Reset to original value
      If tb Is _tbLeft Then
         tb.Text = bounds.X.ToString()
      ElseIf tb Is _tbTop Then
         tb.Text = bounds.Y.ToString()
      ElseIf tb Is _tbWidth Then
         tb.Text = bounds.Width.ToString()
      ElseIf tb Is _tbHeight Then
         tb.Text = bounds.Height.ToString()
      End If
   End Sub

   Private Sub _widthNumericBox_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles _numBottomBorderWidth.Leave, _numTopBorderWidth.Leave, _numRightBorderWidth.Leave, _numLeftBorderWidth.Leave
      Dim numCtrl As NumericUpDown = TryCast(sender, NumericUpDown)

      If _tvZonesList.SelectedNode.Tag.GetType() Is GetType(OcrZoneCell) Then
         Dim cell As OcrZoneCell = CType(_tvZonesList.SelectedNode.Tag, OcrZoneCell)
         Dim index As Integer = _cells.IndexOf(cell)
         If index >= 0 Then
            If numCtrl Is _numLeftBorderWidth Then
               _cells(index).LeftBorderWidth = CInt(numCtrl.Value)
            ElseIf numCtrl Is _numTopBorderWidth Then
               _cells(index).TopBorderWidth = CInt(numCtrl.Value)
            ElseIf numCtrl Is _numRightBorderWidth Then
               _cells(index).RightBorderWidth = CInt(numCtrl.Value)
            ElseIf numCtrl Is _numBottomBorderWidth Then
               _cells(index).BottomBorderWidth = CInt(numCtrl.Value)
            End If
         End If
      End If
   End Sub

   Private Sub _cmbBorderStyle_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _cmbRightBorderStyle.SelectedIndexChanged, _cmbBottomBorderStyle.SelectedIndexChanged, _cmbTopBorderStyle.SelectedIndexChanged, _cmbLeftBorderStyle.SelectedIndexChanged
      Dim combo As ComboBox = TryCast(sender, ComboBox)

      If _tvZonesList.SelectedNode.Tag.GetType() Is GetType(OcrZoneCell) Then
         Dim cell As OcrZoneCell = CType(_tvZonesList.SelectedNode.Tag, OcrZoneCell)
         Dim index As Integer = _cells.IndexOf(cell)
         If index >= 0 Then
            If combo Is _cmbLeftBorderStyle Then
               _cells(index).LeftBorderStyle = CType(combo.SelectedItem, OcrCellBorderLineStyle)
               If combo.Text = "None" Then
                  _numLeftBorderWidth.Value = 0
                  cell.LeftBorderWidth = 0
               Else
                  If _numLeftBorderWidth.Value = 0 Then
                     _numLeftBorderWidth.Value = 1
                     cell.LeftBorderWidth = 1
                  End If
               End If
            ElseIf combo Is _cmbTopBorderStyle Then
               _cells(index).TopBorderStyle = CType(combo.SelectedItem, OcrCellBorderLineStyle)
               If combo.Text = "None" Then
                  _numTopBorderWidth.Value = 0
                  cell.TopBorderWidth = 0
               Else
                  If _numTopBorderWidth.Value = 0 Then
                     _numTopBorderWidth.Value = 1
                     cell.TopBorderWidth = 1
                  End If
               End If
            ElseIf combo Is _cmbRightBorderStyle Then
               _cells(index).RightBorderStyle = CType(combo.SelectedItem, OcrCellBorderLineStyle)
               If combo.Text = "None" Then
                  _numRightBorderWidth.Value = 0
                  cell.RightBorderWidth = 0
               Else
                  If _numRightBorderWidth.Value = 0 Then
                     _numRightBorderWidth.Value = 1
                     cell.RightBorderWidth = 1
                  End If
               End If
            ElseIf combo Is _cmbBottomBorderStyle Then
               _cells(index).BottomBorderStyle = CType(combo.SelectedItem, OcrCellBorderLineStyle)
               If combo.Text = "None" Then
                  _numBottomBorderWidth.Value = 0
                  cell.BottomBorderWidth = 0
               Else
                  If _numBottomBorderWidth.Value = 0 Then
                     _numBottomBorderWidth.Value = 1
                     cell.BottomBorderWidth = 1
                  End If
               End If
            End If

            _tvZonesList.SelectedNode.Tag = cell
         End If

         UpdateUIControls()
      End If
   End Sub

   Private Sub UpdateUIControls()
      ' Disable the border color and border width controls for the border that has the "None" style
      '_lblLeftBorderColor.Enabled = _cmbLeftBorderStyle.Text <> "None"
      '_btnLeftBorderColor.Enabled = _cmbLeftBorderStyle.Text <> "None"
      '_lblLeftBorderWidth.Enabled = _cmbLeftBorderStyle.Text <> "None"
      '_numLeftBorderWidth.Enabled = _cmbLeftBorderStyle.Text <> "None"

      '_lblTopBorderColor.Enabled = _cmbTopBorderStyle.Text <> "None"
      '_btnTopBorderColor.Enabled = _cmbTopBorderStyle.Text <> "None"
      '_lblTopBorderWidth.Enabled = _cmbTopBorderStyle.Text <> "None"
      '_numTopBorderWidth.Enabled = _cmbTopBorderStyle.Text <> "None"

      '_lblRightBorderColor.Enabled = _cmbRightBorderStyle.Text <> "None"
      '_btnRightBorderColor.Enabled = _cmbRightBorderStyle.Text <> "None"
      '_lblRightBorderWidth.Enabled = _cmbRightBorderStyle.Text <> "None"
      '_numRightBorderWidth.Enabled = _cmbRightBorderStyle.Text <> "None"

      '_lblBottomBorderColor.Enabled = _cmbBottomBorderStyle.Text <> "None"
      '_btnBottomBorderColor.Enabled = _cmbBottomBorderStyle.Text <> "None"
      '_lblBottomBorderWidth.Enabled = _cmbBottomBorderStyle.Text <> "None"
      '_numBottomBorderWidth.Enabled = _cmbBottomBorderStyle.Text <> "None"
   End Sub

   Private Sub _btnLeftBorderColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnLeftBorderColor.Click
      Using dlg As ColorDialog = New ColorDialog()
         dlg.Color = _btnLeftBorderColor.BackColor
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _btnLeftBorderColor.BackColor = dlg.Color
            If _tvZonesList.SelectedNode.Tag.GetType() Is GetType(OcrZoneCell) Then
               Dim cell As OcrZoneCell = CType(_tvZonesList.SelectedNode.Tag, OcrZoneCell)
               Dim index As Integer = _cells.IndexOf(cell)
               If index >= 0 Then
                  _cells(index).LeftBorderColor = MainForm.ConvertColor(dlg.Color)
               End If
            End If
         End If
      End Using
   End Sub

   Private Sub _btnTopBorderColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnTopBorderColor.Click
      Using dlg As ColorDialog = New ColorDialog()
         dlg.Color = _btnTopBorderColor.BackColor
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _btnTopBorderColor.BackColor = dlg.Color
            If _tvZonesList.SelectedNode.Tag.GetType() Is GetType(OcrZoneCell) Then
               Dim cell As OcrZoneCell = CType(_tvZonesList.SelectedNode.Tag, OcrZoneCell)
               Dim index As Integer = _cells.IndexOf(cell)
               If index >= 0 Then
                  _cells(index).TopBorderColor = MainForm.ConvertColor(dlg.Color)
               End If
            End If
         End If
      End Using
   End Sub

   Private Sub _btnRightBorderColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnRightBorderColor.Click
      Using dlg As ColorDialog = New ColorDialog()
         dlg.Color = _btnRightBorderColor.BackColor
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _btnRightBorderColor.BackColor = dlg.Color
            If _tvZonesList.SelectedNode.Tag.GetType() Is GetType(OcrZoneCell) Then
               Dim cell As OcrZoneCell = CType(_tvZonesList.SelectedNode.Tag, OcrZoneCell)
               Dim index As Integer = _cells.IndexOf(cell)
               If index >= 0 Then
                  _cells(index).RightBorderColor = MainForm.ConvertColor(dlg.Color)
               End If
            End If
         End If
      End Using
   End Sub

   Private Sub _btnBottomBorderColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBottomBorderColor.Click
      Using dlg As ColorDialog = New ColorDialog()
         dlg.Color = _btnBottomBorderColor.BackColor
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _btnBottomBorderColor.BackColor = dlg.Color
            If _tvZonesList.SelectedNode.Tag.GetType() Is GetType(OcrZoneCell) Then
               Dim cell As OcrZoneCell = CType(_tvZonesList.SelectedNode.Tag, OcrZoneCell)
               Dim index As Integer = _cells.IndexOf(cell)
               If index >= 0 Then
                  _cells(index).BottomBorderColor = MainForm.ConvertColor(dlg.Color)
               End If
            End If
         End If
      End Using
   End Sub
End Class
