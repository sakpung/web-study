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
Imports Leadtools.MedicalViewer

Namespace MedicalViewerLayoutDemo
   Public Partial Class ViewerPropertiesDialog : Inherits Form
	  Private _cell As MedicalViewerMultiCell
	  Public Sub New(ByVal owner As MainForm, ByVal cell As MedicalViewerMultiCell)
		  InitializeComponent()
		  Dim _mainForm As MainForm = CType(owner, MainForm)
		  _cell = cell

		  _cmbRuler.SelectedIndex = CInt(_cell.RulerStyle)
		  _cmbPaintMethod.SelectedIndex = CInt(_cell.PaintingMethod)
		  _cmbTextQuality.SelectedIndex = CInt(_cell.TextQuality)
		  _cmbBorderStyle.SelectedIndex = CInt(_cell.BorderStyle)
		  _cmbMeasurmentUnit.SelectedIndex = CInt(_cell.MeasurementUnit)
		  _chkShowCellScroll.Checked = _cell.ShowCellScroll
		  _chkMaintainSize.Checked = _mainForm.Viewer.CellMaintenance
		  _chkShowFreeze.Checked = _cell.ShowFreezeText

            _lblBackgroundColor.BoxColor = _mainForm.Viewer.BackColor
		  _lblText.BoxColor = _cell.TextColor
		  _lblShadowColor.BoxColor = _cell.TextShadowColor
		  _lblActiveBorderColor.BoxColor = _cell.ActiveBorderColor
		  _lblNonActiveBorderColor.BoxColor = _cell.NonActiveBorderColor
		  _lblRulerInColor.BoxColor = _cell.RulerInColor
		  _lblRulerOutColor.BoxColor = _cell.RulerOutColor
		  _lblBackgroundColor.BoxColor = _cell.CellBackColor
		  _lblActiveSubcellColor.BoxColor = _cell.ActiveSubCellBorderColor
		 _labelDesignForeColor.BoxColor = _mainForm.Viewer.LayoutOptions.RectForeColor
		 _labelDesignBackColor.BoxColor = _mainForm.Viewer.LayoutOptions.RectBackColor

		 Dim index As Integer = 0
		 For Each icon As MedicalViewerIcon In _cell.Titlebar.Icons
			CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColor1) + index), ColorBox).BoxColor = icon.Color
			CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColorPressed1) + index), ColorBox).BoxColor = icon.ColorPressed
			CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColorHover1) + index), ColorBox).BoxColor = icon.ColorHover
			CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_chkReadOnly1) + index), CheckBox).Checked = icon.ReadOnly
			CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_chkShowIcon1) + index), CheckBox).Checked = icon.Visible

			index += 1
		 Next icon

		 _chkShowTitlebar.Checked = _cell.Titlebar.Visible
		 _lblTitlebarColor.BackColor = _cell.Titlebar.Color

		 If (Not _chkShowTitlebar.Checked) Then
			For Each control As Control In _tabTitlebar.Controls
			   If (Not control.Equals(_chkShowTitlebar)) Then
				  control.Enabled = False
			   End If
			Next control
		 Else
			_chkCustomTitlebarColor.Checked = _cell.Titlebar.UseCustomColor
			_lblTitlebarColor.Enabled = _cell.Titlebar.UseCustomColor
			_btnTitlebarColor.Enabled = _cell.Titlebar.UseCustomColor
		 End If
	  End Sub

	  Private Sub _chkModifyRowsColumns_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

	  End Sub

	  Private Sub applyButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
		 Dim viewer As MedicalViewer = (CType(Me.Owner, MainForm)).Viewer

            If viewer.BackColor <> _lblBackgroundColor.BackColor Then
                viewer.BackColor = _lblBackgroundColor.BackColor
            End If

		 If viewer.CellMaintenance <> _chkMaintainSize.Checked Then
			viewer.CellMaintenance = _chkMaintainSize.Checked
		 End If

		 If Not viewer.LayoutOptions.RectForeColor.Equals(_labelDesignForeColor.BoxColor) Then
			viewer.LayoutOptions.RectForeColor = _labelDesignForeColor.BoxColor
		 End If

		 If Not viewer.LayoutOptions.RectBackColor.Equals(_labelDesignBackColor.BoxColor) Then
			viewer.LayoutOptions.RectBackColor = _labelDesignBackColor.BoxColor
		 End If

		 ApplyCellProperties(_cell)

		 For Each cell As MedicalViewerMultiCell In (CType(Me.Owner, MainForm)).Viewer.Cells
			ApplyCellProperties(cell)
		 Next cell

	  End Sub

	  Private Sub ApplyCellProperties(ByVal cell As MedicalViewerMultiCell)
		 Dim index As Integer = 0
		 Dim checkShowindex As Integer = _tabTitlebar.Controls.IndexOf(_chkShowIcon1)
		 Dim colorIndex As Integer = _tabTitlebar.Controls.IndexOf(_lblColor1)
		 Dim colorHoverIndex As Integer = _tabTitlebar.Controls.IndexOf(_lblColorHover1)
		 Dim colorPressedIndex As Integer = _tabTitlebar.Controls.IndexOf(_lblColorPressed1)
		 Dim checkReadOnlyIndex As Integer = _tabTitlebar.Controls.IndexOf(_chkReadOnly1)
		 Dim viewer As MedicalViewer = (CType(Me.Owner, MainForm)).Viewer

		 Dim icon As MedicalViewerIcon

		 index = 0
		 Do While index < cell.Titlebar.Icons.Length
			icon = cell.Titlebar.Icons(index)

			If icon.Visible <> (CType(_tabTitlebar.Controls(checkShowindex + index), CheckBox)).Checked Then
			   icon.Visible = (CType(_tabTitlebar.Controls(checkShowindex + index), CheckBox)).Checked
			End If

			If Not icon.Color.Equals((CType(_tabTitlebar.Controls(colorIndex + index), ColorBox)).BoxColor) Then
			   icon.Color = (CType(_tabTitlebar.Controls(colorIndex + index), ColorBox)).BoxColor
			End If

			If Not icon.ColorPressed.Equals((CType(_tabTitlebar.Controls(colorPressedIndex + index), ColorBox)).BoxColor) Then
			   icon.ColorPressed = (CType(_tabTitlebar.Controls(colorPressedIndex + index), ColorBox)).BoxColor
			End If

			If Not icon.ColorHover.Equals((CType(_tabTitlebar.Controls(colorHoverIndex + index), ColorBox)).BoxColor) Then
			   icon.ColorHover = (CType(_tabTitlebar.Controls(colorHoverIndex + index), ColorBox)).BoxColor
			End If

			If icon.ReadOnly <> (CType(_tabTitlebar.Controls(checkReadOnlyIndex + index), CheckBox)).Checked Then
			   icon.ReadOnly = (CType(_tabTitlebar.Controls(checkReadOnlyIndex + index), CheckBox)).Checked
			End If
			 index += 1
		 Loop

		 If Not cell.CellBackColor.Equals(_lblBackgroundColor.BoxColor) Then
			cell.CellBackColor = _lblBackgroundColor.BackColor
		 End If

		 If Not cell.TextColor.Equals(_lblText.BoxColor) Then
			cell.TextColor = _lblText.BackColor
		 End If

		 If Not cell.TextShadowColor.Equals(_lblShadowColor.BoxColor) Then
			cell.TextShadowColor = _lblShadowColor.BackColor
		 End If

		 If Not cell.ActiveBorderColor.Equals(_lblActiveBorderColor.BoxColor) Then
			cell.ActiveBorderColor = _lblActiveBorderColor.BackColor
		 End If

		 If Not cell.NonActiveBorderColor.Equals(_lblNonActiveBorderColor.BoxColor) Then
			cell.NonActiveBorderColor = _lblNonActiveBorderColor.BackColor
		 End If

		 If Not cell.ActiveSubCellBorderColor.Equals(_lblActiveSubcellColor.BoxColor) Then
			cell.ActiveSubCellBorderColor = _lblActiveSubcellColor.BackColor
		 End If

		 If Not cell.RulerInColor.Equals(_lblRulerInColor.BoxColor) Then
			cell.RulerInColor = _lblRulerInColor.BackColor
		 End If

		 If Not cell.RulerOutColor.Equals(_lblRulerOutColor.BoxColor) Then
			cell.RulerOutColor = _lblRulerOutColor.BackColor
		 End If

		 If cell.Titlebar.UseCustomColor <> _chkCustomTitlebarColor.Checked Then
			cell.Titlebar.UseCustomColor = _chkCustomTitlebarColor.Checked
		 End If

		 If Not cell.Titlebar.Color.Equals(_lblTitlebarColor.BoxColor) Then
			cell.Titlebar.Color = _lblTitlebarColor.BackColor
		 End If

		 If cell.Titlebar.Visible <> _chkShowTitlebar.Checked Then
			cell.Titlebar.Visible = _chkShowTitlebar.Checked
		 End If

		 If cell.TextQuality <> CType(_cmbTextQuality.SelectedIndex, MedicalViewerTextQuality) Then
			cell.TextQuality = CType(_cmbTextQuality.SelectedIndex, MedicalViewerTextQuality)
		 End If

		 If cell.RulerStyle <> CType(_cmbRuler.SelectedIndex, MedicalViewerRulerStyle) Then
			cell.RulerStyle = CType(_cmbRuler.SelectedIndex, MedicalViewerRulerStyle)
		 End If

		 If cell.ShowCellScroll <> _chkShowCellScroll.Checked Then
			cell.ShowCellScroll = _chkShowCellScroll.Checked
		 End If

		 If cell.ShowFreezeText <> _chkShowFreeze.Checked Then
			cell.ShowFreezeText = _chkShowFreeze.Checked
		 End If

		 If cell.PaintingMethod <> CType(_cmbPaintMethod.SelectedIndex, MedicalViewerPaintingMethod) Then
			cell.PaintingMethod = CType(_cmbPaintMethod.SelectedIndex, MedicalViewerPaintingMethod)
		 End If

		 If cell.MeasurementUnit <> CType(_cmbMeasurmentUnit.SelectedIndex, MedicalViewerMeasurementUnit) Then
			cell.MeasurementUnit = CType(_cmbMeasurmentUnit.SelectedIndex, MedicalViewerMeasurementUnit)
		 End If

		 If cell.BorderStyle <> CType(_cmbBorderStyle.SelectedIndex, MedicalViewerBorderStyle) Then
			cell.BorderStyle = CType(_cmbBorderStyle.SelectedIndex, MedicalViewerBorderStyle)
		 End If
	  End Sub

	  Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
		 applyButton_Click(sender, e)
		 Me.Close()
	  End Sub

	  Private Sub resetButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnReset.Click
		 Dim viewer As MedicalViewer = (CType(Me.Owner, MainForm)).Viewer

		 _cmbRuler.SelectedIndex = CInt(_cell.RulerStyle)
		 _cmbPaintMethod.SelectedIndex = CInt(_cell.PaintingMethod)
		 _cmbTextQuality.SelectedIndex = CInt(_cell.TextQuality)
		 _cmbBorderStyle.SelectedIndex = CInt(_cell.BorderStyle)
		 _cmbMeasurmentUnit.SelectedIndex = CInt(_cell.MeasurementUnit)
		 _chkShowCellScroll.Checked = _cell.ShowCellScroll
		 _chkMaintainSize.Checked = viewer.CellMaintenance
		 _chkShowFreeze.Checked = _cell.ShowFreezeText

		 _lblText.BoxColor = _cell.TextColor
		 _lblShadowColor.BoxColor = _cell.TextShadowColor
		 _lblActiveBorderColor.BoxColor = _cell.ActiveBorderColor
		 _lblNonActiveBorderColor.BoxColor = _cell.NonActiveBorderColor
		 _lblRulerInColor.BoxColor = _cell.RulerInColor
		 _lblRulerOutColor.BoxColor = _cell.RulerOutColor
		 _lblBackgroundColor.BoxColor = _cell.CellBackColor
		 _lblActiveSubcellColor.BoxColor = _cell.ActiveSubCellBorderColor

		 Dim index As Integer = 0
		 For Each icon As MedicalViewerIcon In _cell.Titlebar.Icons
			CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColor1) + index), ColorBox).BoxColor = icon.Color
			CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColorPressed1) + index), ColorBox).BoxColor = icon.ColorPressed
			CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_lblColorHover1) + index), ColorBox).BoxColor = icon.ColorHover
			CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_chkReadOnly1) + index), CheckBox).Checked = icon.ReadOnly
			CType(_tabTitlebar.Controls(_tabTitlebar.Controls.IndexOf(_chkShowIcon1) + index), CheckBox).Checked = icon.Visible

			index += 1
		 Next icon

		 _chkShowTitlebar.Checked = _cell.Titlebar.Visible
		 _lblTitlebarColor.BackColor = _cell.Titlebar.Color

		 If (Not _chkShowTitlebar.Checked) Then
			For Each control As Control In _tabTitlebar.Controls
			   If (Not control.Equals(_chkShowTitlebar)) Then
				  control.Enabled = False
			   End If
			Next control
		 Else
			_chkCustomTitlebarColor.Checked = _cell.Titlebar.UseCustomColor
			_lblTitlebarColor.Enabled = _cell.Titlebar.UseCustomColor
			_btnTitlebarColor.Enabled = _cell.Titlebar.UseCustomColor
		 End If
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

	   Private Sub _btnDesignForeColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnDesignForeColor.Click
		   MainForm.ShowColorDialog(_labelDesignForeColor)
	   End Sub

	   Private Sub _btnDesignBackColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnDesignBackColor.Click
		   MainForm.ShowColorDialog(_labelDesignBackColor)
	   End Sub
   End Class
End Namespace
