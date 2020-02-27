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
Imports Leadtools.Barcode

Partial Public Class BarcodeControl : Inherits UserControl
   Private _rasterImage As RasterImage
   Private _documentBarcodes As DocumentBarcodes
   Private _ignoreAction As Boolean

   Public Sub New()
      InitializeComponent()
   End Sub

   ''' <summary>
   ''' Called from MainForm to set the barcodes and selected barcodes list
   ''' </summary>
   Public Sub SetDocument(ByVal image As RasterImage, ByVal documentBarcodes As DocumentBarcodes)
      _rasterImage = image
      _documentBarcodes = documentBarcodes

      Populate()
   End Sub

   ''' <summary>
   ''' Called by MainForm and internally whenever the document barcodes are updated
   ''' </summary>
   Public Sub Populate()
      _barcodesListView.Items.Clear()

      If Not _documentBarcodes Is Nothing AndAlso Not _rasterImage Is Nothing Then
         Dim pageBarcodes As PageBarcodes = _documentBarcodes.Pages(_rasterImage.Page - 1)
         For Each data As BarcodeData In pageBarcodes.Barcodes
            Dim item As ListViewItem = New ListViewItem()

            item.Text = BarcodeEngine.GetSymbologyFriendlyName(data.Symbology)
            Dim rc As LeadRect = data.Bounds
            item.SubItems.Add(String.Format("{0}, {1}, {2}, {3}", rc.Left, rc.Top, rc.Right, rc.Bottom))

            Dim value As String = data.Value
            If (Not String.IsNullOrEmpty(value)) Then
               Dim eciData As String = Nothing
               If data.Symbology = BarcodeSymbology.QR OrElse data.Symbology = BarcodeSymbology.MicroQR Then
                  eciData = BarcodeData.ParseECIData(data.GetData())
               End If

               If Not String.IsNullOrEmpty(eciData) Then
                  item.SubItems.Add(eciData)
               Else
                  item.SubItems.Add(value)
               End If
            Else
               item.SubItems.Add("<NO DATA>")
            End If

            _barcodesListView.Items.Add(item)
         Next data

         If pageBarcodes.SelectedIndex <> -1 Then
            _barcodesListView.Items(pageBarcodes.SelectedIndex).Selected = True
            _barcodesListView.EnsureVisible(pageBarcodes.SelectedIndex)
         End If
      End If

      UpdateUIState()
   End Sub

   ''' <summary>
   ''' Called by MainForm when the selected barcode has changed
   ''' </summary>
   Public Sub SelectedBarcodeChanged()
      _ignoreAction = True

      If Not _documentBarcodes Is Nothing Then
         Dim selectedIndex As Integer = _documentBarcodes.Pages(_rasterImage.Page - 1).SelectedIndex

         For Each item As ListViewItem In _barcodesListView.Items
            item.Selected = (item.Index = selectedIndex)
         Next item

         If selectedIndex <> -1 Then
            _barcodesListView.EnsureVisible(selectedIndex)
         End If
      End If

      _ignoreAction = False

      UpdateUIState()
   End Sub

   Public Event Action As EventHandler(Of ActionEventArgs)

   Private Sub DoAction(ByVal action As String, ByVal data As Object)
      If Not ActionEvent Is Nothing Then
         RaiseEvent Action(Me, New ActionEventArgs(action, Nothing))
      End If
   End Sub

   Private Sub _barcodesListView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _barcodesListView.SelectedIndexChanged
      If (Not _ignoreAction) AndAlso Not ActionEvent Is Nothing Then
         Dim selectedIndex As Integer

         If _barcodesListView.SelectedIndices.Count > 0 Then
            selectedIndex = _barcodesListView.SelectedIndices(0)
         Else
            selectedIndex = -1
         End If

         RaiseEvent Action(Me, New ActionEventArgs("SelectedBarcodeChanged", selectedIndex))

         UpdateUIState()
      End If
   End Sub

   Private Sub _barcodesListView_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles _barcodesListView.DoubleClick
      If (Not _ignoreAction) Then
         DoZoomTo()
      End If
   End Sub

   Private Sub UpdateUIState()
      Dim itemSelected As Boolean = _barcodesListView.SelectedItems.Count > 0
      _deleteButton.Enabled = itemSelected
      _zoomToButton.Enabled = itemSelected
#If LEADTOOLS_V20_OR_LATER Then
      If Not _rasterImage Is Nothing Then
         Dim pageBarcodes As PageBarcodes = _documentBarcodes.Pages(_rasterImage.Page - 1)
         If pageBarcodes.SelectedIndex > -1 Then
            Dim data As BarcodeData = pageBarcodes.Barcodes(pageBarcodes.SelectedIndex)
            If data.Symbology = BarcodeSymbology.PDF417 Then
               Dim id As AAMVAID = BarcodeData.ParseAAMVAData(data.GetData(), False)
               If id IsNot Nothing Then
                  _aamvaButton.Enabled = True
                  id.Dispose()
               Else
                  _aamvaButton.Enabled = False
               End If
            Else
               _aamvaButton.Enabled = False
            End If
         Else
            _aamvaButton.Enabled = False
         End If
      End If
#End If '#If LEADTOOLS_V20_OR_LATER Then
   End Sub

   Private Sub _deleteButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _deleteButton.Click
      If _barcodesListView.SelectedItems.Count > 0 Then
         DoAction("DeleteSelectedBarcode", Nothing)
      End If
   End Sub

   Private Sub _zoomToButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _zoomToButton.Click
      DoZoomTo()
   End Sub

   Private Sub DoZoomTo()
      If _barcodesListView.SelectedItems.Count > 0 Then
         DoAction("ZoomToSelectedBarcode", Nothing)
      End If
   End Sub

   Private Sub _aamvaButton_Click(sender As Object, e As EventArgs) Handles _aamvaButton.Click
      If _barcodesListView.SelectedItems.Count > 0 Then
         DoAction("ViewSelectedBarcodeIDData", Nothing)
      End If
   End Sub
End Class
