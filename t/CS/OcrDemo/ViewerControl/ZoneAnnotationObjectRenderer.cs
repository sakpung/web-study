// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;
using System.Drawing.Drawing2D;

using Leadtools;
using Leadtools.Ocr;
using Leadtools.Drawing;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Designers;
using Leadtools.Annotations.Rendering;

namespace OcrDemo
{
   public class ZoneAnnotationObjectRenderer : AnnRectangleObjectRenderer
   {
      private int _zoneIndex;
      private IOcrPage _ocrPage;
      private AnnStroke _cellPen;

      public ZoneAnnotationObjectRenderer() :
         base()
      {
         _ocrPage = null;
         _zoneIndex = 0;
      }


      public int ZoneIndex
      {
         get { return _zoneIndex; }
      }

      public AnnStroke CellPen
      {
         get { return _cellPen; }
         set { _cellPen = value; }
      }

      public override void Render(AnnContainerMapper mapper, AnnObject annObject)
      {
         if (_ocrPage != null && _zoneIndex >= 0 && _zoneIndex < _ocrPage.Zones.Count)
         {
            AnnWinFormsRenderingEngine engine = RenderingEngine as AnnWinFormsRenderingEngine;
            if (engine != null && engine.Context != null)
            {
               Graphics graphics = engine.Context;
               OcrZone zone = _ocrPage.Zones[_zoneIndex];
               OcrZoneCell[] cells = null;
               cells = _ocrPage.Zones.GetZoneCells(zone);

               if (_ocrPage.TableZoneManager != null && zone.ZoneType == OcrZoneType.Table && cells != null && cells.Length > 0 && CellPen != null)
               {
                  GraphicsState gState = graphics.Save();
                  if (gState != null)
                  {
                     foreach (OcrZoneCell cell in cells)
                     {
                        LeadRectD rc = new LeadRectD(cell.Bounds.X, cell.Bounds.Y, cell.Bounds.Width, cell.Bounds.Height);
                        rc = mapper.RectFromContainerCoordinates(rc, AnnFixedStateOperations.None);

                        if (!rc.IsEmpty)
                        {
                           // Draw cells borders as lines in order not to draw the borders with 0 width
                           DrawLine(graphics, OcrCellBorder.Left, cell.LeftBorderStyle, cell.LeftBorderWidth, (float)rc.Left, (float)rc.Top, (float)rc.Left, (float)rc.Bottom);
                           DrawLine(graphics, OcrCellBorder.Top, cell.TopBorderStyle, cell.TopBorderWidth, (float)rc.Left, (float)rc.Top, (float)rc.Right, (float)rc.Top);
                           DrawLine(graphics, OcrCellBorder.Right, cell.RightBorderStyle, cell.RightBorderWidth, (float)rc.Right, (float)rc.Top, (float)rc.Right, (float)rc.Bottom);
                           DrawLine(graphics, OcrCellBorder.Bottom, cell.BottomBorderStyle, cell.BottomBorderWidth, (float)rc.Left, (float)rc.Bottom, (float)rc.Right, (float)rc.Bottom);
                        }
                     }

                     // EndDraw(graphics, gState);
                  }
               }
            }
         }

         base.Render(mapper, annObject);
      }

      void DrawLine(Graphics g, OcrCellBorder border, OcrCellBorderLineStyle lineStyle, int penWidth, float x1, float y1, float x2, float y2)
      {
         if (lineStyle != OcrCellBorderLineStyle.None && penWidth > 0)
         {
            using (Pen pen = new Pen(Color.FromName((CellPen.Stroke as AnnSolidColorBrush).Color)))
            {
               pen.Width = penWidth;
               pen.EndCap = LineCap.Square;
               pen.StartCap = LineCap.Square;

               switch (lineStyle)
               {
                  case OcrCellBorderLineStyle.Double:
                     pen.DashStyle = DashStyle.Solid;
                     switch (border)
                     {
                        case OcrCellBorder.Left:
                        case OcrCellBorder.Right:
                           g.DrawLine(pen, x1 - pen.Width, y1, x2 - pen.Width, y2);
                           g.DrawLine(pen, x1 + pen.Width, y1, x2 + pen.Width, y2);
                           break;

                        case OcrCellBorder.Top:
                        case OcrCellBorder.Bottom:
                           g.DrawLine(pen, x1, y1 - pen.Width, x2, y2 - pen.Width);
                           g.DrawLine(pen, x1, y1 + pen.Width, x2, y2 + pen.Width);
                           break;
                     }
                     break;

                  case OcrCellBorderLineStyle.Dashed:
                     pen.DashStyle = DashStyle.Dash;
                     break;

                  case OcrCellBorderLineStyle.Dotted:
                     pen.DashStyle = DashStyle.Dot;
                     break;

                  case OcrCellBorderLineStyle.Solid:
                  default:
                     pen.DashStyle = DashStyle.Solid;
                     break;
               }

               if (lineStyle != OcrCellBorderLineStyle.Double)
                  g.DrawLine(pen, x1, y1, x2, y2);
            }
         }
         else
         {
            // Draw invisible cell border
            using (Pen pen = new Pen(Color.FromName((CellPen.Stroke as AnnSolidColorBrush).Color)))
            {
               pen.Width = 1;
               pen.DashStyle = DashStyle.Dot;
               pen.Color = Color.FromArgb(16, Color.FromName((CellPen.Stroke as AnnSolidColorBrush).Color));
               g.DrawLine(pen, x1, y1, x2, y2);
            }
         }
      }

   }
}
