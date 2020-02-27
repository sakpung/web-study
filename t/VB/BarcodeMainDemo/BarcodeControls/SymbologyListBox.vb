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
Imports Leadtools.Drawing
Imports Leadtools.Barcode

Partial Public Class SymbologyListBox : Inherits ListBox
   Public Sub New()
      InitializeComponent()

      Me.DrawMode = DrawMode.OwnerDrawFixed
      Me.ColumnWidth = 200
      Me.ItemHeight = 70

      SetStyle(ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
   End Sub

   Private Sub CleanUp(ByVal disposing As Boolean)
      If disposing Then
         If Not _stringFormat Is Nothing Then
            _stringFormat.Dispose()
            _stringFormat = Nothing
         End If

         If Not _itemPen Is Nothing Then
            _itemPen.Dispose()
            _itemPen = Nothing
         End If
      End If
   End Sub

   Private _sampleSymbologiesRasterImage As RasterImage
   <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
   Public Property SampleSymbologiesRasterImage() As RasterImage
      Get
         Return _sampleSymbologiesRasterImage
      End Get
      Set(value As RasterImage)
         _sampleSymbologiesRasterImage = value
         Invalidate()
      End Set
   End Property

   Private Const _delta As Integer = 5
   Private _itemPen As Pen
   Private _stringFormat As StringFormat

   Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)
      If _sampleSymbologiesRasterImage Is Nothing Then
         Return
      End If

      If e.Index = -1 Then
         Return
      End If

      Dim rc As Rectangle = New Rectangle(e.Bounds.X + _delta, e.Bounds.Y + _delta, e.Bounds.Width - 10, e.Bounds.Height - _delta)

      If _stringFormat Is Nothing Then
         _stringFormat = New StringFormat()
         _stringFormat.Alignment = StringAlignment.Center
         _stringFormat.LineAlignment = StringAlignment.Far
      End If

      Dim symbology As BarcodeSymbology = CType(Items(e.Index), BarcodeSymbology)
      Dim name As String = BarcodeEngine.GetSymbologyFriendlyName(symbology)
      _sampleSymbologiesRasterImage.Page = CInt(symbology)

      If _itemPen Is Nothing Then
         _itemPen = New Pen(Brushes.Black, 2)
      End If

      e.Graphics.DrawRectangle(_itemPen, rc)
      e.Graphics.FillRectangle(Brushes.White, rc)

      Dim paintProperties As RasterPaintProperties = RasterPaintProperties.Default

      If RasterSupport.IsLocked(RasterSupportType.Document) Then
         paintProperties.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic
      Else
         paintProperties.PaintDisplayMode = RasterPaintDisplayModeFlags.ScaleToGray
      End If

      Dim imageRect As LeadRect = New LeadRect(rc.X + 2, rc.Y + 2, rc.Width - 4, CInt(rc.Height * 2 / 3))
      imageRect = RasterImage.CalculatePaintModeRectangle(_sampleSymbologiesRasterImage.ImageWidth, _sampleSymbologiesRasterImage.ImageHeight, imageRect, RasterPaintSizeMode.FitAlways, RasterPaintAlignMode.CenterAlways, RasterPaintAlignMode.CenterAlways)

      If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
         e.Graphics.FillRectangle(SystemBrushes.Highlight, rc)
         RasterImagePainter.Paint(_sampleSymbologiesRasterImage, e.Graphics, imageRect, paintProperties)
         e.Graphics.DrawRectangle(Pens.Black, imageRect.X, imageRect.Y, imageRect.Width, imageRect.Height)
         e.Graphics.DrawString(name, Font, SystemBrushes.HighlightText, rc, _stringFormat)
      Else
         e.Graphics.FillRectangle(SystemBrushes.Control, rc)
         RasterImagePainter.Paint(_sampleSymbologiesRasterImage, e.Graphics, imageRect, paintProperties)
         e.Graphics.DrawRectangle(Pens.Black, imageRect.X, imageRect.Y, imageRect.Width, imageRect.Height)
         e.Graphics.DrawString(name, Font, SystemBrushes.ControlText, rc, _stringFormat)
      End If
   End Sub

   Public Event ItemDoubleClicked As EventHandler(Of SymbologyListBoxItemDoubleClickedEventArgs)

   Protected Overrides Sub OnDoubleClick(ByVal e As EventArgs)
      Dim index As Integer = IndexFromPoint(PointToClient(Cursor.Position))
      If index <> -1 AndAlso Not ItemDoubleClickedEvent Is Nothing Then
         RaiseEvent ItemDoubleClicked(Me, New SymbologyListBoxItemDoubleClickedEventArgs(index))
      End If

      MyBase.OnDoubleClick(e)
   End Sub
End Class
