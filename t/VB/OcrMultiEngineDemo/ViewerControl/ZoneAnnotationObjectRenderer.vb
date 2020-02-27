' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Ocr
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Designers
Imports Leadtools.Annotations.Rendering
Imports Leadtools.Drawing

Public Class ZoneAnnotationObjectRenderer : Inherits AnnRectangleObjectRenderer
   Private _ocrPage As IOcrPage
   Private _cellPen As AnnStroke

   Public Sub New()
      MyBase.New()
      _ocrPage = Nothing
   End Sub

   Public Property OcrPage() As IOcrPage
      Get
         Return _ocrPage
      End Get
      Set(value As IOcrPage)
         _ocrPage = value
      End Set
   End Property

   Public Property CellPen() As AnnStroke
      Get
         Return _cellPen
      End Get
      Set(ByVal value As AnnStroke)
         _cellPen = value
      End Set
   End Property

   Public Overrides Sub Render(mapper As AnnContainerMapper, annObject As AnnObject)
      Dim zoneObject As ZoneAnnotationObject = TryCast(annObject, ZoneAnnotationObject)
      If Not IsNothing(_ocrPage) AndAlso zoneObject.ZoneIndex >= 0 AndAlso zoneObject.ZoneIndex < _ocrPage.Zones.Count Then
         Dim engine As AnnWinFormsRenderingEngine = CType(RenderingEngine, AnnWinFormsRenderingEngine)
         If Not engine Is Nothing AndAlso Not engine.Context Is Nothing AndAlso Not zoneObject Is Nothing AndAlso Not zoneObject.Cells Is Nothing Then

            Dim graphics As Graphics = engine.Context
            Dim zone As OcrZone = _ocrPage.Zones(zoneObject.ZoneIndex)
            Dim cells As OcrZoneCell() = Nothing
            cells = _ocrPage.Zones.GetZoneCells(zone)
            If Not _ocrPage.TableZoneManager Is Nothing And zone.ZoneType = OcrZoneType.Table AndAlso Not cells Is Nothing AndAlso cells.Length > 0 AndAlso Not CellPen Is Nothing Then
               Dim gState As GraphicsState = graphics.Save()
               If Not gState Is Nothing Then
                  For Each cell As OcrZoneCell In zoneObject.Cells
                     Dim rc As LeadRectD = New LeadRectD(cell.Bounds.X, cell.Bounds.Y, cell.Bounds.Width, cell.Bounds.Height)
                     rc = mapper.RectFromContainerCoordinates(rc, AnnFixedStateOperations.None)
                     If (Not rc.IsEmpty) Then
                        ' Draw cells borders as lines in order not to draw the borders with 0 width
                        DrawLine(graphics, OcrCellBorder.Left, cell.LeftBorderStyle, cell.LeftBorderWidth, Convert.ToSingle(rc.Left), Convert.ToSingle(rc.Top), Convert.ToSingle(rc.Left), Convert.ToSingle(rc.Bottom))
                        DrawLine(graphics, OcrCellBorder.Top, cell.TopBorderStyle, cell.TopBorderWidth, Convert.ToSingle(rc.Left), Convert.ToSingle(rc.Top), Convert.ToSingle(rc.Right), Convert.ToSingle(rc.Top))
                        DrawLine(graphics, OcrCellBorder.Right, cell.RightBorderStyle, cell.RightBorderWidth, Convert.ToSingle(rc.Right), Convert.ToSingle(rc.Top), Convert.ToSingle(rc.Right), Convert.ToSingle(rc.Bottom))
                        DrawLine(graphics, OcrCellBorder.Bottom, cell.BottomBorderStyle, cell.BottomBorderWidth, Convert.ToSingle(rc.Left), Convert.ToSingle(rc.Bottom), Convert.ToSingle(rc.Right), Convert.ToSingle(rc.Bottom))
                     End If
                  Next cell
                  graphics.Restore(gState)
               End If
            End If
         End If
      End If
      MyBase.Render(mapper, annObject)
   End Sub

   Private Sub DrawLine(ByVal g As Graphics, ByVal border As OcrCellBorder, ByVal lineStyle As OcrCellBorderLineStyle, ByVal penWidth As Integer, ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single)
      If Not lineStyle = OcrCellBorderLineStyle.None AndAlso penWidth > 0 Then
         Using pen As Pen = New Pen(Color.FromName((CType(CellPen.Stroke, AnnSolidColorBrush)).Color))
            pen.Width = penWidth
            pen.EndCap = LineCap.Square
            pen.StartCap = LineCap.Square

            Select Case lineStyle
               Case OcrCellBorderLineStyle.Double
                  pen.DashStyle = DashStyle.Solid
                  Select Case border
                     Case OcrCellBorder.Left, OcrCellBorder.Right
                        g.DrawLine(pen, x1 - pen.Width, y1, x2 - pen.Width, y2)
                        g.DrawLine(pen, x1 + pen.Width, y1, x2 + pen.Width, y2)

                     Case OcrCellBorder.Top, OcrCellBorder.Bottom
                        g.DrawLine(pen, x1, y1 - pen.Width, x2, y2 - pen.Width)
                        g.DrawLine(pen, x1, y1 + pen.Width, x2, y2 + pen.Width)
                  End Select

               Case OcrCellBorderLineStyle.Dashed
                  pen.DashStyle = DashStyle.Dash

               Case OcrCellBorderLineStyle.Dotted
                  pen.DashStyle = DashStyle.Dot

               Case Else
                  pen.DashStyle = DashStyle.Solid
            End Select

            If Not lineStyle = OcrCellBorderLineStyle.Double Then
               g.DrawLine(pen, x1, y1, x2, y2)
            End If
         End Using
      Else
         ' Draw invisible cell border
         Using pen As Pen = New Pen(Color.FromName((CType(CellPen.Stroke, AnnSolidColorBrush)).Color))
            pen.Width = 1
            pen.DashStyle = DashStyle.Dot
            pen.Color = Color.FromArgb(16, Color.FromName((CType(CellPen.Stroke, AnnSolidColorBrush)).Color))
            g.DrawLine(pen, x1, y1, x2, y2)
         End Using
      End If
   End Sub
End Class
