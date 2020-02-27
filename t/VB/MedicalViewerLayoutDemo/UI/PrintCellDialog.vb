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
Imports System.Drawing.Printing

Imports Leadtools
Imports Leadtools.Drawing
Imports Leadtools.MedicalViewer
Imports Leadtools.Codecs
Imports Leadtools.WinForms

Namespace MedicalViewerLayoutDemo
   Partial Public Class PrintCellDialog : Inherits Form
      Private subCellIndex As Integer
      Private image As Image
      Private features As MedicalViewerCellImageFeatures
      Private exploded As Boolean
      Private _SelectedCell As MedicalViewerCell

      Private Function GetCellFeatures() As MedicalViewerCellImageFeatures
         Dim features As MedicalViewerCellImageFeatures = CType(0, MedicalViewerCellImageFeatures)

         If _chkAnnotation.Checked Then
            features = features Or MedicalViewerCellImageFeatures.Annotations
         End If
         If _chkRegion.Checked Then
            features = features Or MedicalViewerCellImageFeatures.Regions
         End If
         If _chkRulers.Checked Then
            features = features Or MedicalViewerCellImageFeatures.Rulers
         End If
         If _chkBorders.Checked Then
            features = features Or MedicalViewerCellImageFeatures.Borders
         End If
         If _chkTags.Checked Then
            features = features Or MedicalViewerCellImageFeatures.Tags
         End If

         Return features
      End Function

      Private Sub UpdateCellImage(ByVal owner As MainForm)
         If owner Is Nothing Then
            Return
         End If
         If Not image Is Nothing Then
            image.Dispose()
         End If
         image = _SelectedCell.GetCellImage(exploded, features)
         _cellImage.Image = image
      End Sub

      Private Sub EnableOptionsCheckBoxs(ByVal enable As Boolean)
         _chkAnnotation.Enabled = enable
         _chkRegion.Enabled = enable
         _chkRulers.Enabled = enable
         _chkBorders.Enabled = enable
         _chkTags.Enabled = enable
      End Sub

      Private Sub EnableAdditionalOptionsCheckBoxs(ByVal enable As Boolean)
         _txtIndex.Enabled = enable
         _lblIndex.Enabled = enable
         _chkExploded.Enabled = enable
         If enable Then
            subCellIndex = Convert.ToInt32(_txtIndex.Text) - 1
         Else
            subCellIndex = -1
         End If
      End Sub

      Public Sub New(ByVal owner As MainForm, ByVal selectedCell As MedicalViewerCell)

         InitializeComponent()
         _SelectedCell = selectedCell

         image = Nothing
         subCellIndex = 0
         exploded = False
         SuspendLayout()
         _chkPrintAll.Checked = True
         _chkAll.Checked = True
         _txtIndex.MaximumAllowed = _SelectedCell.Image.PageCount
         EnableOptionsCheckBoxs(False)
         EnableAdditionalOptionsCheckBoxs(False)
         ResumeLayout(False)

         UpdateCellImage(owner)
      End Sub

      Private Sub _btnPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnPrint.Click
         CType(Me.Owner, MainForm).PrintImage = RasterImageConverter.ConvertFromImage(image, ConvertFromImageOptions.None)
         Dim printImage As RasterImage = (CType(Me.Owner, MainForm)).PrintImage
         Dim printDocument As PrintDocument = (CType(Me.Owner, MainForm)).PrintDocument

         printDocument.PrinterSettings.MinimumPage = 1
         printDocument.PrinterSettings.MaximumPage = printImage.PageCount
         printDocument.PrinterSettings.FromPage = 1
         printDocument.PrinterSettings.ToPage = printImage.PageCount
         printDocument.Print()

         Me.Close()
      End Sub

      Private Sub _chkAll_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkAll.CheckedChanged
         EnableOptionsCheckBoxs((Not _chkAll.Checked))
         If _chkAll.Checked Then
            features = MedicalViewerCellImageFeatures.All
         Else
            features = GetCellFeatures()
         End If
         UpdateCellImage(CType(Me.Owner, MainForm))
      End Sub

      Private Sub _chkAnnotation_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkAnnotation.CheckedChanged
         features = GetCellFeatures()
         UpdateCellImage(CType(Me.Owner, MainForm))
      End Sub

      Private Sub _chkRegion_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkRegion.CheckedChanged
         features = GetCellFeatures()
         UpdateCellImage(CType(Me.Owner, MainForm))
      End Sub

      Private Sub _chkBorders_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkBorders.CheckedChanged
         features = GetCellFeatures()
         UpdateCellImage(CType(Me.Owner, MainForm))
      End Sub

      Private Sub _chkRulers_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkRulers.CheckedChanged
         features = GetCellFeatures()
         UpdateCellImage(CType(Me.Owner, MainForm))
      End Sub

      Private Sub _chkTags_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkTags.CheckedChanged
         features = GetCellFeatures()
         UpdateCellImage(CType(Me.Owner, MainForm))
      End Sub

      Private Sub _chkPrintAll_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkPrintAll.CheckedChanged
         EnableAdditionalOptionsCheckBoxs((Not _chkPrintAll.Checked))
         UpdateCellImage(CType(Me.Owner, MainForm))
      End Sub

      Private Sub _chkExploded_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkExploded.CheckedChanged
         exploded = _chkExploded.Checked
         UpdateCellImage(CType(Me.Owner, MainForm))
      End Sub

      Private Sub _txtIndex_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _txtIndex.TextChanged
         subCellIndex = Convert.ToInt32(_txtIndex.Text) - 1
         UpdateCellImage(CType(Me.Owner, MainForm))
      End Sub

      Private Sub _btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnSave.Click
         Dim _saver As ImageFileSaver = New ImageFileSaver()

         Try
            Using codecs As New RasterCodecs()
               Dim rasterImage As RasterImage = RasterImageConverter.ConvertFromImage(image, ConvertFromImageOptions.None)
               DemosGlobal.SetDefaultComments(rasterImage, codecs)
               _saver.Save(Me, codecs, rasterImage)
               Me.Close()
            End Using
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, _saver.FileName, ex)
         End Try
      End Sub
   End Class
End Namespace
