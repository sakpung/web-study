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

Imports Leadtools.MedicalViewer
Imports Leadtools

Namespace MedicalViewerDemo
   Partial Public Class StatisticsDialog : Inherits Form
      Public Sub New(ByVal owner As MainForm)
         InitializeComponent()

         Dim cellIndex As Integer = owner.SearchForFirstSelected()

         Dim cell As MedicalViewerMultiCell = Nothing

         If cellIndex <> -1 Then
            cell = CType(owner.Viewer.Cells(cellIndex), MedicalViewerMultiCell)
         End If

         If cell Is Nothing Then
            Return
         End If

         If cell.Image.GetRegionBounds(Nothing).IsEmpty Then
            cell.Image.MakeRegionEmpty()
         End If



         Dim page As Integer = cell.Image.Page
         Dim image As RasterImage = cell.Image
         image.Page = cell.ActiveSubCell + 1

         If cell.Image.HasRegion Then
            _hasRegionLbl.Text = "True"
            _hasRegionLbl.BackColor = Color.FromArgb(128, 255, 128)

            Dim bounds As LeadRect = image.GetRegionBounds(Nothing)

            _xLbl.Text = bounds.X.ToString()
            _yLbl.Text = bounds.Y.ToString()
            _widthLbl.Text = bounds.Width.ToString()
            _heightLbl.Text = bounds.Height.ToString()

            _areaLbl.Text = image.CalculateRegionArea().ToString()
         Else
            _hasRegionLbl.Text = "False"
            _hasRegionLbl.BackColor = Color.FromArgb(255, 128, 128)
         End If

         image.Page = page
      End Sub

      Private Sub okButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Me.Close()
      End Sub

   End Class
End Namespace
