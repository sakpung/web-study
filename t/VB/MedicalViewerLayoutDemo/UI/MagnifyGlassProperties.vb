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
   Public Partial Class MagnifyGlassProperties : Inherits Form
	   Private _SelectedCell As MedicalViewerCell = Nothing
	   Private _magnifyGlass As MedicalViewerMagnifyGlass = Nothing
	   'private MedicalViewerKeys _keys = null;
	   Private _Viewer As MedicalViewer = Nothing

	  Public Sub New(ByVal owner As MainForm, ByVal selectedCell As MedicalViewerCell)
		 InitializeComponent()

		 _Viewer = owner.Viewer
		 _SelectedCell = selectedCell

		 If Not _SelectedCell Is Nothing Then
			 _magnifyGlass = CType(_SelectedCell.GetActionProperties(MedicalViewerActionType.MagnifyGlass), MedicalViewerMagnifyGlass)
		 Else
			 _magnifyGlass = CType(MainForm.GlobalCell.GetActionProperties(MedicalViewerActionType.MagnifyGlass), MedicalViewerMagnifyGlass)
		 End If

		 _chk3D.Checked = _magnifyGlass.Border3D
		 _chk3D.Enabled = Not _chkElliptical.Checked
		 _chkElliptical.Checked = _magnifyGlass.Elliptical
		 _txtWidth.Value = _magnifyGlass.Width
		 _txtHeight.Value = _magnifyGlass.Height
		 _txtZoom.Value = _magnifyGlass.Zoom
		 _txtBorder.Value = _magnifyGlass.BorderSize
		 _cmbCrosshair.SelectedIndex = CInt(_magnifyGlass.Crosshair)
		 _lblPenColor.BackColor = Color.FromArgb(&Hff, _magnifyGlass.PenColor.R, _magnifyGlass.PenColor.G, _magnifyGlass.PenColor.B)
	  End Sub

	  Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
		 Me.Close()
		 _btnApply_Click(sender, e)
	  End Sub

	  Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
		  _magnifyGlass.Border3D = _chk3D.Checked
		  _magnifyGlass.BorderSize = _txtBorder.Value
		  _magnifyGlass.Crosshair = CType(_cmbCrosshair.SelectedIndex, MedicalViewerCrosshairStyle)
		  _magnifyGlass.Elliptical = _chkElliptical.Checked
		  _magnifyGlass.Height = _txtHeight.Value
		  _magnifyGlass.Width = _txtWidth.Value
		  _magnifyGlass.Zoom = _txtZoom.Value
		  _magnifyGlass.PenColor = _lblPenColor.BackColor

		  MainForm.GlobalCell.SetActionProperties(MedicalViewerActionType.MagnifyGlass, _magnifyGlass)
		  For Each cell As MedicalViewerCell In _Viewer.Cells
			  cell.SetActionProperties(MedicalViewerActionType.MagnifyGlass, _magnifyGlass)
		  Next cell
	  End Sub

	  Private Sub _btnPenColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnPenColor.Click
		 MainForm.ShowColorDialog(_lblPenColor)
	  End Sub

	  Private Sub _chkElliptical_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkElliptical.CheckedChanged
		 _chk3D.Enabled = Not _chkElliptical.Checked
	  End Sub
   End Class
End Namespace
