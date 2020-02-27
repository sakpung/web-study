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
Imports Leadtools.MedicalViewer

Namespace MedicalViewerDemo
   Partial Public Class ViewerPropertiesDialog : Inherits Form
      Public Sub New(ByVal owner As MainForm)
         InitializeComponent()
         Dim _mainForm As MainForm = CType(owner, MainForm)
         _txtRows.Text = _mainForm.Viewer.Rows.ToString()
         _txtColumns.Text = _mainForm.Viewer.Columns.ToString()
         _cmbRuler.SelectedIndex = CInt(MainForm.DefaultCell.RulerStyle)
         _cmbSplitterType.SelectedIndex = CInt(_mainForm.Viewer.SplitterStyle)
         _cmbPaintMethod.SelectedIndex = CInt(MainForm.DefaultCell.PaintingMethod)
         _cmbTextQuality.SelectedIndex = CInt(MainForm.DefaultCell.TextQuality)
         _cmbBorderStyle.SelectedIndex = CInt(MainForm.DefaultCell.BorderStyle)
         _cmbMeasurmentUnit.SelectedIndex = CInt(MainForm.DefaultCell.MeasurementUnit)
         _chkShowViewerScroll.Checked = _mainForm.Viewer.AutoScroll
         _chkShowCellScroll.Checked = MainForm.DefaultCell.ShowCellScroll
         _chkMaintainSize.Checked = _mainForm.Viewer.CellMaintenance
         _chkUseExtraSplitters.Checked = _mainForm.Viewer.UseExtraSplitters
         _chkShowFreeze.Checked = MainForm.DefaultCell.ShowFreezeText

         _chkCustomSplitterColor.Checked = _mainForm.Viewer.CustomSplitterColor
         _lblEmptyCellBackColor.BoxColor = _mainForm.Viewer.BackColor
         _lblText.BoxColor = MainForm.DefaultCell.TextColor
         _lblShadowColor.BoxColor = MainForm.DefaultCell.TextShadowColor
         _lblActiveBorderColor.BoxColor = MainForm.DefaultCell.ActiveBorderColor
         _lblNonActiveBorderColor.BoxColor = MainForm.DefaultCell.NonActiveBorderColor
         _lblRulerInColor.BoxColor = MainForm.DefaultCell.RulerInColor
         _lblRulerOutColor.BoxColor = MainForm.DefaultCell.RulerOutColor
         _lblBackgroundColor.BoxColor = MainForm.DefaultCell.CellBackColor
         _lblActiveSubcellColor.BoxColor = MainForm.DefaultCell.ActiveSubCellBorderColor
         _lblSplitterColor.BoxColor = _mainForm.Viewer.SplitterColor
         _lblSplitterColor.Enabled = _btnSplitterColor.Enabled = _chkCustomSplitterColor.Checked

         _btnVerticalCursor.ButtonCursor = _mainForm.Viewer.ResizeVerticalCursor
         _btnBothCursor.ButtonCursor = _mainForm.Viewer.ResizeBoth
         _btnHorizontalCursor.ButtonCursor = _mainForm.Viewer.ResizeHorizontalCursor
         _btnDefaultCursor.ButtonCursor = _mainForm.Viewer.Cursor

         Dim index As Integer = 0
         For Each icon As MedicalViewerIcon In MainForm.DefaultCell.Titlebar.Icons
            CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColor1) + index), ColorBox).BoxColor = icon.Color
            CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColorPressed1) + index), ColorBox).BoxColor = icon.ColorPressed
            CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColorHover1) + index), ColorBox).BoxColor = icon.ColorHover
            CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_chkReadOnly1) + index), CheckBox).Checked = icon.ReadOnly
            CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_chkShowIcon1) + index), CheckBox).Checked = icon.Visible

            index += 1
         Next icon

         _chkShowTitlebar.Checked = MainForm.DefaultCell.Titlebar.Visible
         _lblTitlebarColor.BackColor = MainForm.DefaultCell.Titlebar.Color

         If (Not _chkShowTitlebar.Checked) Then
            For Each control As Control In _tabTitlebar.Controls
               If (Not control.Equals(_chkShowTitlebar)) Then
                  control.Enabled = False
               End If
            Next control
         Else
            _chkCustomTitlebarColor.Checked = MainForm.DefaultCell.Titlebar.UseCustomColor
            _lblTitlebarColor.Enabled = MainForm.DefaultCell.Titlebar.UseCustomColor
            _btnTitlebarColor.Enabled = MainForm.DefaultCell.Titlebar.UseCustomColor
         End If
      End Sub

      Private Sub _chkModifyRowsColumns_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkModifyRowsColumns.CheckedChanged
         _txtRows.Enabled = _chkModifyRowsColumns.Checked
         _lblRows.Enabled = _chkModifyRowsColumns.Checked
         _txtColumns.Enabled = _chkModifyRowsColumns.Checked
         _lblColumns.Enabled = _chkModifyRowsColumns.Checked
         If _chkModifyRowsColumns.Checked Then
            _txtRows.Focus()
         End If
      End Sub

      Private Sub applyButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         Dim index As Integer = 0
         Dim checkShowindex As Integer = _tabTitlebar.Controls.IndexOf(_chkShowIcon1)
         Dim colorIndex As Integer = _tabTitlebar.Controls.IndexOf(_lblColor1)
         Dim colorHoverIndex As Integer = _tabTitlebar.Controls.IndexOf(_lblColorHover1)
         Dim colorPressedIndex As Integer = _tabTitlebar.Controls.IndexOf(_lblColorPressed1)
         Dim checkReadOnlyIndex As Integer = _tabTitlebar.Controls.IndexOf(_chkReadOnly1)
         Dim viewer As MedicalViewer = (CType(Me.Owner, MainForm)).Viewer
         Dim icon As MedicalViewerIcon
         Dim defaultCell As MedicalViewerCell = MainForm.DefaultCell

         If viewer.BackColor <> _lblEmptyCellBackColor.BackColor Then
            viewer.BackColor = _lblEmptyCellBackColor.BackColor
         End If

         If _chkCustomSplitterColor.Checked Then
            If viewer.SplitterColor <> _lblSplitterColor.BoxColor Then
               viewer.SplitterColor = _lblSplitterColor.BackColor
            End If
         End If

         If viewer.CustomSplitterColor <> _chkCustomSplitterColor.Checked Then
            viewer.CustomSplitterColor = _chkCustomSplitterColor.Checked
         End If


         If _chkModifyRowsColumns.Checked Then
            If viewer.Rows <> _txtRows.Value Then
               viewer.Rows = _txtRows.Value
            End If

            If viewer.Columns <> _txtColumns.Value Then
               viewer.Columns = _txtColumns.Value
            End If
         End If

         If viewer.SplitterStyle <> CType(_cmbSplitterType.SelectedIndex, MedicalViewerSplitterStyle) Then
            viewer.SplitterStyle = CType(_cmbSplitterType.SelectedIndex, MedicalViewerSplitterStyle)
         End If

         If viewer.UseExtraSplitters <> _chkUseExtraSplitters.Checked Then
            viewer.UseExtraSplitters = _chkUseExtraSplitters.Checked
         End If

         If viewer.CellMaintenance <> _chkMaintainSize.Checked Then
            viewer.CellMaintenance = _chkMaintainSize.Checked
         End If


         index = 0
         Do While index < (MainForm.DefaultCell.Titlebar.Icons.Length)
            icon = defaultCell.Titlebar.Icons(index)

            If icon.Visible <> (CType(_tabTitlebar.Controls(checkShowindex + index), CheckBox)).Checked Then
               icon.Visible = (CType(_tabTitlebar.Controls(checkShowindex + index), CheckBox)).Checked
            End If

            If icon.Color <> (CType(_tabTitlebar.Controls(colorIndex + index), ColorBox)).BoxColor Then
               icon.Color = (CType(_tabTitlebar.Controls(colorIndex + index), ColorBox)).BoxColor
            End If

            If icon.ColorPressed <> (CType(_tabTitlebar.Controls(colorPressedIndex + index), ColorBox)).BoxColor Then
               icon.ColorPressed = (CType(_tabTitlebar.Controls(colorPressedIndex + index), ColorBox)).BoxColor
            End If

            If icon.ColorHover <> (CType(_tabTitlebar.Controls(colorHoverIndex + index), ColorBox)).BoxColor Then
               icon.ColorHover = (CType(_tabTitlebar.Controls(colorHoverIndex + index), ColorBox)).BoxColor
            End If

            If icon.ReadOnly <> (CType(_tabTitlebar.Controls(checkReadOnlyIndex + index), CheckBox)).Checked Then
               icon.ReadOnly = (CType(_tabTitlebar.Controls(checkReadOnlyIndex + index), CheckBox)).Checked
            End If
            index += 1
         Loop

         If viewer.AutoScroll <> _chkShowViewerScroll.Checked Then
            viewer.AutoScroll = _chkShowViewerScroll.Checked
         End If

         If defaultCell.CellBackColor <> _lblBackgroundColor.BoxColor Then
            defaultCell.CellBackColor = _lblBackgroundColor.BackColor
         End If

         If defaultCell.TextColor <> _lblText.BoxColor Then
            defaultCell.TextColor = _lblText.BackColor
         End If

         If defaultCell.TextShadowColor <> _lblShadowColor.BoxColor Then
            defaultCell.TextShadowColor = _lblShadowColor.BackColor
         End If

         If defaultCell.ActiveBorderColor <> _lblActiveBorderColor.BoxColor Then
            defaultCell.ActiveBorderColor = _lblActiveBorderColor.BackColor
         End If

         If defaultCell.NonActiveBorderColor <> _lblNonActiveBorderColor.BoxColor Then
            defaultCell.NonActiveBorderColor = _lblNonActiveBorderColor.BackColor
         End If

         If defaultCell.ActiveSubCellBorderColor <> _lblActiveSubcellColor.BoxColor Then
            defaultCell.ActiveSubCellBorderColor = _lblActiveSubcellColor.BackColor
         End If

         If defaultCell.RulerInColor <> _lblRulerInColor.BoxColor Then
            defaultCell.RulerInColor = _lblRulerInColor.BackColor
         End If

         If defaultCell.RulerOutColor <> _lblRulerOutColor.BoxColor Then
            defaultCell.RulerOutColor = _lblRulerOutColor.BackColor
         End If

         If defaultCell.Titlebar.UseCustomColor <> _chkCustomTitlebarColor.Checked Then
            defaultCell.Titlebar.UseCustomColor = _chkCustomTitlebarColor.Checked
         End If

         If defaultCell.Titlebar.Color <> _lblTitlebarColor.BoxColor Then
            defaultCell.Titlebar.Color = _lblTitlebarColor.BackColor
         End If

         If defaultCell.Titlebar.Visible <> _chkShowTitlebar.Checked Then
            defaultCell.Titlebar.Visible = _chkShowTitlebar.Checked
         End If

         If defaultCell.TextQuality <> CType(_cmbTextQuality.SelectedIndex, MedicalViewerTextQuality) Then
            defaultCell.TextQuality = CType(_cmbTextQuality.SelectedIndex, MedicalViewerTextQuality)
         End If

         If defaultCell.RulerStyle <> CType(_cmbRuler.SelectedIndex, MedicalViewerRulerStyle) Then
            defaultCell.RulerStyle = CType(_cmbRuler.SelectedIndex, MedicalViewerRulerStyle)
         End If

         If defaultCell.ShowCellScroll <> _chkShowCellScroll.Checked Then
            defaultCell.ShowCellScroll = _chkShowCellScroll.Checked
         End If

         If defaultCell.ShowFreezeText <> _chkShowFreeze.Checked Then
            defaultCell.ShowFreezeText = _chkShowFreeze.Checked
         End If

         If defaultCell.PaintingMethod <> CType(_cmbPaintMethod.SelectedIndex, MedicalViewerPaintingMethod) Then
            defaultCell.PaintingMethod = CType(_cmbPaintMethod.SelectedIndex, MedicalViewerPaintingMethod)
         End If

         If defaultCell.MeasurementUnit <> CType(_cmbMeasurmentUnit.SelectedIndex, MedicalViewerMeasurementUnit) Then
            defaultCell.MeasurementUnit = CType(_cmbMeasurmentUnit.SelectedIndex, MedicalViewerMeasurementUnit)
         End If

         If defaultCell.BorderStyle <> CType(_cmbBorderStyle.SelectedIndex, MedicalViewerBorderStyle) Then
            defaultCell.BorderStyle = CType(_cmbBorderStyle.SelectedIndex, MedicalViewerBorderStyle)
         End If


         If (Not _btnVerticalCursor.ButtonCursor.Equals(viewer.ResizeVerticalCursor)) Then
            viewer.ResizeVerticalCursor = _btnVerticalCursor.ButtonCursor
         End If

         If (Not _btnBothCursor.ButtonCursor.Equals(viewer.ResizeBoth)) Then
            viewer.ResizeBoth = _btnBothCursor.ButtonCursor
         End If

         If (Not _btnHorizontalCursor.ButtonCursor.Equals(viewer.ResizeHorizontalCursor)) Then
            viewer.ResizeHorizontalCursor = _btnHorizontalCursor.ButtonCursor
         End If

         If (Not _btnDefaultCursor.ButtonCursor.Equals(defaultCell.Cursor)) Then
            defaultCell.Cursor = _btnDefaultCursor.ButtonCursor
         End If

         If (Not _btnDefaultCursor.ButtonCursor.Equals(viewer.Cursor)) Then
            viewer.Cursor = _btnDefaultCursor.ButtonCursor
         End If

         For Each cell As MedicalViewerCell In viewer.Cells
            CType(Owner, MainForm).ApplyToCell(cell)
         Next cell
      End Sub

      Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         applyButton_Click(sender, e)
         Me.Close()
      End Sub



      Private Sub resetButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnReset.Click
         Dim viewer As MedicalViewer = (CType(Me.Owner, MainForm)).Viewer
         Dim defaultCell As MedicalViewerCell = MainForm.DefaultCell

         _txtRows.Text = viewer.Rows.ToString()
         _txtColumns.Text = viewer.Columns.ToString()
         _cmbSplitterType.SelectedIndex = CInt(viewer.SplitterStyle)
         _chkShowViewerScroll.Checked = viewer.AutoScroll

         _cmbRuler.SelectedIndex = CInt(defaultCell.RulerStyle)
         _cmbPaintMethod.SelectedIndex = CInt(defaultCell.PaintingMethod)
         _cmbTextQuality.SelectedIndex = CInt(defaultCell.TextQuality)
         _cmbBorderStyle.SelectedIndex = CInt(defaultCell.BorderStyle)
         _cmbMeasurmentUnit.SelectedIndex = CInt(defaultCell.MeasurementUnit)
         _chkShowCellScroll.Checked = defaultCell.ShowCellScroll
         _chkShowFreeze.Checked = defaultCell.ShowFreezeText
         _lblText.BoxColor = defaultCell.TextColor
         _lblShadowColor.BoxColor = defaultCell.TextShadowColor
         _lblActiveBorderColor.BoxColor = defaultCell.ActiveBorderColor
         _lblNonActiveBorderColor.BoxColor = defaultCell.NonActiveBorderColor
         _lblRulerInColor.BoxColor = defaultCell.RulerInColor
         _lblRulerOutColor.BoxColor = defaultCell.RulerOutColor
         _lblBackgroundColor.BoxColor = defaultCell.CellBackColor
         _lblActiveSubcellColor.BoxColor = defaultCell.ActiveSubCellBorderColor
         _btnHorizontalCursor.ButtonCursor = viewer.ResizeHorizontalCursor

         Dim index As Integer = 0
         For Each icon As MedicalViewerIcon In defaultCell.Titlebar.Icons
            CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColor1) + index), ColorBox).BoxColor = icon.Color
            CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColorPressed1) + index), ColorBox).BoxColor = icon.ColorPressed
            CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColorHover1) + index), ColorBox).BoxColor = icon.ColorHover
            CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_chkReadOnly1) + index), CheckBox).Checked = icon.ReadOnly
            CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_chkShowIcon1) + index), CheckBox).Checked = icon.Visible

            index += 1
         Next icon

         _chkShowTitlebar.Checked = defaultCell.Titlebar.Visible
         _lblTitlebarColor.BackColor = defaultCell.Titlebar.Color


         _chkMaintainSize.Checked = viewer.CellMaintenance
         _chkUseExtraSplitters.Checked = viewer.UseExtraSplitters
         _chkCustomSplitterColor.Checked = viewer.CustomSplitterColor
         _lblEmptyCellBackColor.BoxColor = viewer.BackColor
         _lblSplitterColor.BoxColor = viewer.SplitterColor
         _lblSplitterColor.Enabled = _chkCustomSplitterColor.Checked

         _btnVerticalCursor.ButtonCursor = viewer.ResizeVerticalCursor
         _btnBothCursor.ButtonCursor = viewer.ResizeBoth
         _btnDefaultCursor.ButtonCursor = viewer.Cursor


         If (Not _chkShowTitlebar.Checked) Then
            For Each control As Control In _tabTitlebar.Controls
               If (Not control.Equals(_chkShowTitlebar)) Then
                  control.Enabled = False
               End If
            Next control
         Else
            _chkCustomTitlebarColor.Checked = defaultCell.Titlebar.UseCustomColor
            _lblTitlebarColor.Enabled = defaultCell.Titlebar.UseCustomColor
            _btnTitlebarColor.Enabled = defaultCell.Titlebar.UseCustomColor
         End If

         For Each cell As MedicalViewerCell In viewer.Cells
            CType(Owner, MainForm).ApplyToCell(cell)
         Next cell
      End Sub

      Private Sub _chkShowIcon_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkShowIcon1.CheckedChanged, _chkShowIcon2.CheckedChanged, _chkShowIcon3.CheckedChanged, _chkShowIcon4.CheckedChanged, _chkShowIcon5.CheckedChanged, _chkShowIcon6.CheckedChanged, _chkShowIcon7.CheckedChanged, _chkShowIcon8.CheckedChanged
         Dim index As Integer = _tabTitlebar.Controls.IndexOf(CType(sender, Control)) - _tabTitlebar.Controls.IndexOf(_chkShowIcon1)
         Dim CheckBoxChecked As Boolean = (CType(sender, CheckBox)).Checked

         CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColor1) + index), ColorBox).Enabled = CheckBoxChecked
         CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColorPressed1) + index), ColorBox).Enabled = CheckBoxChecked
         CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColorHover1) + index), ColorBox).Enabled = CheckBoxChecked
         CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_chkReadOnly1) + index), CheckBox).Enabled = CheckBoxChecked
      End Sub

      Private Sub _chkShowTitlebar_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkShowTitlebar.CheckedChanged
         If (Not _chkShowTitlebar.Checked) Then
            For Each control As Control In _tabTitlebar.Controls
               If (Not control.Equals(_chkShowTitlebar)) Then
                  control.Enabled = False
               End If
            Next control
         Else
            Dim index As Integer

            For index = 0 To 7
               Dim iconEnabled As Boolean = (CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_chkShowIcon1) + index), CheckBox)).Checked

               CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_chkShowIcon1) + index), CheckBox).Enabled = True
               CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColor1) + index), ColorBox).Enabled = iconEnabled
               CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColorPressed1) + index), ColorBox).Enabled = iconEnabled
               CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColorHover1) + index), ColorBox).Enabled = iconEnabled
               CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_chkReadOnly1) + index), CheckBox).Enabled = iconEnabled
            Next index

            _chkCustomTitlebarColor.Enabled = True

            If _chkCustomTitlebarColor.Checked Then
               _btnTitlebarColor.Enabled = _chkCustomTitlebarColor.Checked
               _lblTitlebarColor.Enabled = _chkCustomTitlebarColor.Checked
            End If
         End If
      End Sub

      Private Sub _chkCustomTitlebarColor_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkCustomTitlebarColor.CheckedChanged
         _btnTitlebarColor.Enabled = _chkCustomTitlebarColor.Checked
         _lblTitlebarColor.Enabled = _chkCustomTitlebarColor.Checked
      End Sub

      Private Sub _btnSplitterColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnSplitterColor.Click
         MainForm.ShowColorDialog(_lblSplitterColor)
      End Sub

      Private Sub _btnEmptyCellBackColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnEmptyCellBackColor.Click
         MainForm.ShowColorDialog(_lblEmptyCellBackColor)
      End Sub

      Private Sub _btnText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnText.Click
         MainForm.ShowColorDialog(_lblText)
      End Sub

      Private Sub _btnShadowColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnShadowColor.Click
         MainForm.ShowColorDialog(_lblShadowColor)
      End Sub

      Private Sub _btnActiveBorderColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnActiveBorderColor.Click
         MainForm.ShowColorDialog(_lblActiveBorderColor)
      End Sub

      Private Sub _btnActiveSubcellColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnActiveSubcellColor.Click
         MainForm.ShowColorDialog(_lblActiveSubcellColor)
      End Sub

      Private Sub _btnBackgroundColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBackgroundColor.Click
         MainForm.ShowColorDialog(_lblBackgroundColor)
      End Sub

      Private Sub _btnRulerInColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnRulerInColor.Click
         MainForm.ShowColorDialog(_lblRulerInColor)
      End Sub

      Private Sub _btnRulerOutColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnRulerOutColor.Click
         MainForm.ShowColorDialog(_lblRulerOutColor)
      End Sub

      Private Sub _btnNonActiveBorderColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnNonActiveBorderColor.Click
         MainForm.ShowColorDialog(_lblNonActiveBorderColor)
      End Sub

      Private Sub _btnTitlebarColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnTitlebarColor.Click
         MainForm.ShowColorDialog(_lblTitlebarColor)
      End Sub

      Private Sub _chkCustomSplitterColor_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkCustomSplitterColor.CheckedChanged
         _btnSplitterColor.Enabled = _chkCustomSplitterColor.Checked
         _lblSplitterColor.Enabled = _chkCustomSplitterColor.Checked
      End Sub
   End Class
End Namespace
