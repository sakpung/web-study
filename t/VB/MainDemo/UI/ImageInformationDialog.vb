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

Namespace MainDemo
   Partial Public Class ImageInformationDialog : Inherits Form
      Public Image As RasterImage

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub ImageInformationDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Dim i As Integer = 0
         Do While i < _lvInfo.Items.Count
            _lvInfo.Items(i).SubItems.Add(String.Empty)
            i += 1
         Loop

         UpdateControls()
      End Sub

      Private Sub UpdateControls()
         Dim index As Integer = 0

         _lblPage.Text = String.Format("Page {0}:{1}", Image.Page, Image.PageCount)
         _btnPageFirst.Enabled = (Image.Page > 1)
         _btnPagePrevious.Enabled = (Image.Page > 1)
         _btnPageNext.Enabled = (Image.Page < Image.PageCount)
         _btnPageLast.Enabled = (Image.Page < Image.PageCount)

         _lvInfo.Items(index + 0).SubItems(1).Text = Image.OriginalFormat.ToString()
         _lvInfo.Items(index + 1).SubItems(1).Text = String.Format("{0} x {1} pixels", Image.Width, Image.Height)
         _lvInfo.Items(index + 2).SubItems(1).Text = String.Format("{0} x {1} pixels", Image.ImageWidth, Image.ImageHeight)
         _lvInfo.Items(index + 3).SubItems(1).Text = String.Format("{0} x {1} dpi", Image.XResolution, Image.YResolution)
         _lvInfo.Items(index + 4).SubItems(1).Text = Image.BitsPerPixel.ToString()
         _lvInfo.Items(index + 5).SubItems(1).Text = Image.BytesPerLine.ToString()
         _lvInfo.Items(index + 6).SubItems(1).Text = Image.DataSize.ToString()
         _lvInfo.Items(index + 7).SubItems(1).Text = Leadtools.Demos.Constants.GetNameFromValue(GetType(RasterViewPerspective), Image.ViewPerspective)
         _lvInfo.Items(index + 8).SubItems(1).Text = Leadtools.Demos.Constants.GetNameFromValue(GetType(RasterByteOrder), Image.Order)

         If (Image.HasRegion) Then
            _lvInfo.Items(index + 9).SubItems(1).Text = "Yes"
         Else
            _lvInfo.Items(index + 9).SubItems(1).Text = "No"
         End If

         If (Image.IsCompressed) Then
            _lvInfo.Items(index + 10).SubItems(1).Text = "Run Length Limited (RLE)"
         Else
            _lvInfo.Items(index + 10).SubItems(1).Text = "Not compressed"
         End If

         If (Image.IsDiskMemory) Then
            _lvInfo.Items(index + 11).SubItems(1).Text = "Disk"
         ElseIf (Image.IsTiled) Then
            _lvInfo.Items(index + 11).SubItems(1).Text = "Tiled"
         ElseIf (Image.IsConventionalMemory) Then
            _lvInfo.Items(index + 11).SubItems(1).Text = "Managed memory"
         Else
            _lvInfo.Items(index + 11).SubItems(1).Text = "Unmanaged memory"
         End If

         If (Image.Signed) Then
            _lvInfo.Items(index + 12).SubItems(1).Text = "Yes"
         Else
            _lvInfo.Items(index + 12).SubItems(1).Text = "No"
         End If

         _lvInfo.Items(index + 13).SubItems(1).Text = Leadtools.Demos.Constants.GetNameFromValue(GetType(RasterGrayscaleMode), Image.GrayscaleMode)

         _lvInfo.Items(index + 14).SubItems(1).Text = Image.LowBit.ToString()
         _lvInfo.Items(index + 15).SubItems(1).Text = Image.HighBit.ToString()

         index = index + 16
         For Each data As KeyValuePair(Of String, Object) In Image.CustomData
            If index = _lvInfo.Items.Count Then
               Dim item As ListViewItem = New ListViewItem(String.Format("{0}:", data.Key))
               item.SubItems.Add(New ListViewItem.ListViewSubItem(item, data.Value.ToString()))
               _lvInfo.Items.Add(item)
            Else
               Dim item As ListViewItem = New ListViewItem(String.Format("{0}:", data.Key))
               item.SubItems.Add(New ListViewItem.ListViewSubItem(item, data.Value.ToString()))

               _lvInfo.Items(index).SubItems(0).Text = item.Text
               _lvInfo.Items(index).SubItems(1).Text = item.SubItems(1).Text
               index = index + 1
            End If
         Next data

         If (Not Image.GetPalette() Is Nothing) Then
            _btnPalette.Enabled = (Image.GetPalette().Length > 0)
         Else
            _btnPalette.Enabled = False
         End If
      End Sub

      Private Sub _btnPalette_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnPalette.Click
         Dim dlg As PaletteDialog = New PaletteDialog()
         dlg.Palette = Image.GetPalette()
         dlg.ShowDialog(Me)
      End Sub

      Private Sub _btnPageFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnPageFirst.Click
         Image.Page = 1
         UpdateControls()
      End Sub

      Private Sub _btnPagePrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnPagePrevious.Click
         Image.Page -= 1
         UpdateControls()
      End Sub

      Private Sub _btnPageNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnPageNext.Click
         Image.Page += 1
         UpdateControls()
      End Sub

      Private Sub _btnPageLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnPageLast.Click
         Image.Page = Image.PageCount
         UpdateControls()
      End Sub
   End Class
End Namespace
