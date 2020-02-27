' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Ocr
Imports Leadtools.Drawing
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Designers
Imports Leadtools.Annotations.Rendering

Namespace OcrDemo
   Public Class ZoneAnnotationObjectRenderer
      Inherits AnnRectangleObjectRenderer
      Private _zoneIndex As Integer
      Private _ocrPage As IOcrPage
      Private _cellPen As AnnStroke

      Public Sub New()
         MyBase.New()
         _ocrPage = Nothing
         _zoneIndex = 0
      End Sub


      Public ReadOnly Property ZoneIndex() As Integer
         Get
            Return _zoneIndex
         End Get
      End Property

      Public Property CellPen() As AnnStroke
         Get
            Return _cellPen
         End Get
         Set(value As AnnStroke)
            _cellPen = value
         End Set
      End Property

      Public Overrides Sub Render(mapper As AnnContainerMapper, annObject As AnnObject)
         If _ocrPage IsNot Nothing AndAlso _zoneIndex >= 0 AndAlso _zoneIndex < _ocrPage.Zones.Count Then
            Dim engine As AnnWinFormsRenderingEngine = TryCast(RenderingEngine, AnnWinFormsRenderingEngine)
            If engine IsNot Nothing AndAlso engine.Context IsNot Nothing Then
               Dim graphics As Graphics = engine.Context
               Dim zone As OcrZone = _ocrPage.Zones(_zoneIndex)
               Dim cells As OcrZoneCell() = Nothing
               cells = _ocrPage.Zones.GetZoneCells(zone)

               If _ocrPage.TableZoneManager IsNot Nothing AndAlso zone.ZoneType = OcrZoneType.Table AndAlso cells IsNot Nothing AndAlso cells.Length > 0 AndAlso CellPen IsNot Nothing Then
                  Dim gState As GraphicsState = graphics.Save()
                  If gState IsNot Nothing Then
                     For Each cell As OcrZoneCell In cells
                        Dim rc As New LeadRectD(cell.Bounds.X, cell.Bounds.Y, cell.Bounds.Width, cell.Bounds.Height)
                        rc = mapper.RectFromContainerCoordinates(rc, AnnFixedStateOperations.None)

                        If Not rc.IsEmpty Then
                           ' Draw cells borders as lines in order not to draw the borders with 0 width
                           DrawLine(graphics, OcrCellBorder.Left, cell.LeftBorderStyle, cell.LeftBorderWidth, CSng(rc.Left), CSng(rc.Top),
                            CSng(rc.Left), CSng(rc.Bottom))
                           DrawLine(graphics, OcrCellBorder.Top, cell.TopBorderStyle, cell.TopBorderWidth, CSng(rc.Left), CSng(rc.Top),
                            CSng(rc.Right), CSng(rc.Top))
                           DrawLine(graphics, OcrCellBorder.Right, cell.RightBorderStyle, cell.RightBorderWidth, CSng(rc.Right), CSng(rc.Top),
                            CSng(rc.Right), CSng(rc.Bottom))
                           DrawLine(graphics, OcrCellBorder.Bottom, cell.BottomBorderStyle, cell.BottomBorderWidth, CSng(rc.Left), CSng(rc.Bottom),
                            CSng(rc.Right), CSng(rc.Bottom))
                        End If

                        ' EndDraw(graphics, gState);
                     Next
                  End If
               End If
            End If
         End If

         MyBase.Render(mapper, annObject)
      End Sub

      Private Sub DrawLine(g As Graphics, border As OcrCellBorder, lineStyle As OcrCellBorderLineStyle, penWidth As Integer, x1 As Single, y1 As Single, _
       x2 As Single, y2 As Single)
         If lineStyle <> OcrCellBorderLineStyle.None AndAlso penWidth > 0 Then
            Using pen As New Pen(Color.FromName(TryCast(CellPen.Stroke, AnnSolidColorBrush).Color))
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
                           Exit Select

                        Case OcrCellBorder.Top, OcrCellBorder.Bottom
                           g.DrawLine(pen, x1, y1 - pen.Width, x2, y2 - pen.Width)
                           g.DrawLine(pen, x1, y1 + pen.Width, x2, y2 + pen.Width)
                           Exit Select
                     End Select
                     Exit Select

                  Case OcrCellBorderLineStyle.Dashed
                     pen.DashStyle = DashStyle.Dash
                     Exit Select

                  Case OcrCellBorderLineStyle.Dotted
                     pen.DashStyle = DashStyle.Dot
                     Exit Select

                  Case Else
                     pen.DashStyle = DashStyle.Solid
                     Exit Select
               End Select

               If lineStyle <> OcrCellBorderLineStyle.Double Then
                  g.DrawLine(pen, x1, y1, x2, y2)
               End If
            End Using
         Else
            ' Draw invisible cell border
            Using pen As New Pen(Color.FromName(TryCast(CellPen.Stroke, AnnSolidColorBrush).Color))
               pen.Width = 1
               pen.DashStyle = DashStyle.Dot
               pen.Color = Color.FromArgb(16, Color.FromName(TryCast(CellPen.Stroke, AnnSolidColorBrush).Color))
               g.DrawLine(pen, x1, y1, x2, y2)
            End Using
         End If
      End Sub

   End Class
End Namespace
