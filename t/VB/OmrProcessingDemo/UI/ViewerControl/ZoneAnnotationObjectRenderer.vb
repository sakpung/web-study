Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Leadtools
Imports Leadtools.Forms.Common
Imports Leadtools.Ocr
Imports Leadtools.Drawing
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Designers
Imports Leadtools.Annotations.Rendering

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

   Public ReadOnly Property ZoneIndex As Integer
      Get
         Return _zoneIndex
      End Get
   End Property

   Public Property CellPen As AnnStroke
      Get
         Return _cellPen
      End Get
      Set(ByVal value As AnnStroke)
         _cellPen = value
      End Set
   End Property

   Public Overrides Sub Render(ByVal mapper As AnnContainerMapper, ByVal annObject As AnnObject)
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
                     Dim rc As LeadRectD = New LeadRectD(cell.Bounds.X, cell.Bounds.Y, cell.Bounds.Width, cell.Bounds.Height)
                     rc = mapper.RectFromContainerCoordinates(rc, AnnFixedStateOperations.None)
                  Next
               End If
            End If
         End If
      End If

      MyBase.Render(mapper, annObject)
   End Sub

   Private Sub DrawLine(ByVal g As Graphics, ByVal border As OcrCellBorder, ByVal lineStyle As OcrCellBorderLineStyle, ByVal penWidth As Integer, ByVal x1 As Single, ByVal y1 As Single, ByVal x2 As Single, ByVal y2 As Single)
      If lineStyle <> OcrCellBorderLineStyle.None AndAlso penWidth > 0 Then

         Using pen As Pen = New Pen(Color.FromName((TryCast(CellPen.Stroke, AnnSolidColorBrush)).Color))
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

            If lineStyle <> OcrCellBorderLineStyle.Double Then g.DrawLine(pen, x1, y1, x2, y2)
         End Using
      Else

         Using pen As Pen = New Pen(Color.FromName((TryCast(CellPen.Stroke, AnnSolidColorBrush)).Color))
            pen.Width = 1
            pen.DashStyle = DashStyle.Dot
            pen.Color = Color.FromArgb(16, Color.FromName((TryCast(CellPen.Stroke, AnnSolidColorBrush)).Color))
            g.DrawLine(pen, x1, y1, x2, y2)
         End Using
      End If
   End Sub
End Class
