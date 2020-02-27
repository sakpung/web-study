// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Text;

using Leadtools;
using Leadtools.Forms.Recognition;
using Leadtools.Forms.Processing;

namespace FormsDemo
{
   public enum ProcessingFieldType
   {
      None,
      Text,
      Omr,
      Barcode,
      Image
   }

   public enum HitTestPosition
   {
      Inside,
      Outside,
      LeftTop,
      RightTop,
      LeftBottom,
      RightBottom,
      LeftEdge,
      RightEdge,
      UpperEdge,
      LowerEdge
   }

   public class ProcessingField
   {
      private FormField _processingBox = null;
      private Rectangle _ProcessingBoxRect;
      private SolidBrush _brush = null;
      private Pen _pen = null;
      private ProcessingFieldType _type;
      private Rectangle _leftTopHandle;
      private Rectangle _rightTopHandle;
      private Rectangle _leftBottomHandle;
      private Rectangle _rightBottomHandle;
      private Rectangle _upperHandle;
      private Rectangle _lowerHandle;
      private Rectangle _leftHandle;
      private Rectangle _rightHandle;
      private bool _selected = true;      
      private int _dpiX = 0;
      private int _dpiY = 0;

      public ProcessingField(FormField processingBox, ProcessingFieldType type, RasterImage image, SolidBrush brush, Pen pen)
      {
         _type = type;
         _brush = brush;
         _pen = pen;
         _processingBox = processingBox;
         _ProcessingBoxRect = _processingBox.Bounds.ToRectangle(_dpiX, _dpiX);
         AdjustRectPoints();
      }

      public BarcodeFormField BarcodeBox
      {
         get { return _processingBox as BarcodeFormField; }
         set { _processingBox = value; }
      }

      public ImageFormField ImageBox
      {
         get { return _processingBox as ImageFormField; }
         set { _processingBox = value; }
      }

      public TextFormField OcrBox
      {
         get { return _processingBox as TextFormField; }
         set { _processingBox = value; }
      }

      public OmrFormField OmrBox
      {
         get { return _processingBox as OmrFormField; }
         set { _processingBox = value; }
      }

      public ProcessingFieldType Type
      {
         get { return _type; }
      }

      public bool Selected
      {
         get { return _selected; }
         set { _selected = value; }
      }

      private void AdjustRectPoints()
      {
         int x = 0;
         int y = 0;
         int width = Math.Abs(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Width);
         int height = Math.Abs(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Height);

         if (_processingBox.Bounds.Width <= 0 && _processingBox.Bounds.Height <= 0)
         {
            x = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left;
            y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top;

            if (width == 0)
               width = 1;

            if (height == 0)
               height = 1;

            _processingBox.Bounds = new LogicalRectangle(new RectangleF(x, y, width, height));
         }
         else if (_processingBox.Bounds.Width <= 0 && _processingBox.Bounds.Height > 0)
         {
            x = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left;
            y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top;

            if (width == 0)
               width = 1;

            _processingBox.Bounds = new LogicalRectangle(new RectangleF(x, y, width, height));
         }
         else if (_processingBox.Bounds.Width > 0 && _processingBox.Bounds.Height <= 0)
         {
            x = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left;
            y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top;

            if (height == 0)
               height = 1;

            _processingBox.Bounds = new LogicalRectangle(new RectangleF(x, y, width, height));
         }

         CreateHandles();
         _ProcessingBoxRect = _processingBox.Bounds.ToRectangle(_dpiX, _dpiX);
      }

      public string Name
      {
         get { return _processingBox.Name; }
         set { _processingBox.Name = value; }
      }

      public RectangleF Rectangle
      {
         get { return _processingBox.Bounds.ToRectangleF(_dpiX, _dpiY); }
         set 
         { 
            _processingBox.Bounds = new LogicalRectangle(value);
            _ProcessingBoxRect = System.Drawing.Rectangle.Round(value);
            CreateHandles();
         }
      }

      public FormField ProcessingBox
      {
         get { return _processingBox; }
      }

      private bool PointInRectangle(PointF position, Rectangle rect)
      {
         if ((position.X > rect.Left && position.X < rect.Right) && (position.Y > rect.Top && position.Y < rect.Bottom))
            return true;
         else
            return false;
      }

      public HitTestPosition HitTest(PointF position)
      {
         if (PointInRectangle(position, _leftTopHandle))
            return HitTestPosition.LeftTop;
         else if (PointInRectangle(position, _rightTopHandle))
            return HitTestPosition.RightTop;
         else if (PointInRectangle(position, _leftBottomHandle))
            return HitTestPosition.LeftBottom;
         else if (PointInRectangle(position, _rightBottomHandle))
            return HitTestPosition.RightBottom;
         else if (PointInRectangle(position, _upperHandle))
            return HitTestPosition.UpperEdge;
         else if (PointInRectangle(position, _lowerHandle))
            return HitTestPosition.LowerEdge;
         else if (PointInRectangle(position, _rightHandle))
            return HitTestPosition.RightEdge;
         else if (PointInRectangle(position, _leftHandle))
            return HitTestPosition.LeftEdge;
         else if (PointInRectangle(position, _processingBox.Bounds.ToRectangle(_dpiX, _dpiY)))
            return HitTestPosition.Inside;
         else
            return HitTestPosition.Outside;
      }

      public void Resize(Point newCorner, HitTestPosition resizeOrigin)
      {
         int left = 0;
         int top = 0;
         int width = 0;
         int height = 0;

         switch (resizeOrigin)
         {
            case HitTestPosition.LeftTop:
               left = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left;
               top = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top;
               width = newCorner.X - left;
               height = newCorner.Y - top;
               break;

            case HitTestPosition.RightTop:
               left = newCorner.X;
               top = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top;
               width = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Right - left;
               height = newCorner.Y - top;
               break;

            case HitTestPosition.LeftBottom:
               left = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left;
               top = newCorner.Y;
               width = newCorner.X - left;
               height = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Bottom - top;
               break;

            case HitTestPosition.RightBottom:
               left = newCorner.X;
               top = newCorner.Y;
               width = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Right - left;
               height = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Bottom - top;
               break;

            case HitTestPosition.LowerEdge:
               left = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left;
               top = newCorner.Y;
               width = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Width;
               height = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Bottom - top;
               break;

            case HitTestPosition.UpperEdge:
               left = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left;
               top = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top;
               width = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Width;
               height = newCorner.Y - top;
               break;

            case HitTestPosition.LeftEdge:
               left = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left;
               top = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top;
               width = newCorner.X - _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left;
               height = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Height;
               break;

            case HitTestPosition.RightEdge:
               left = newCorner.X;
               top = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top;
               width = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Right - left;
               height = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Height;
               break;
         }

         _processingBox.Bounds = new LogicalRectangle(new RectangleF(left, top, width, height));
         _ProcessingBoxRect = _processingBox.Bounds.ToRectangle(_dpiX, _dpiX);
         AdjustRectPoints();
      }      

      public void Move(int dx, int dy)
      {
         _processingBox.Bounds = new LogicalRectangle(new RectangleF(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left + dx, _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top + dy, _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Width, _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Height));
         _ProcessingBoxRect = _processingBox.Bounds.ToRectangle(_dpiX, _dpiX);
         CreateHandles();
      }

      public void ChangeAlpha(int alpha)
      {
         int newAlpha = _brush.Color.A + alpha;
         Color brushColor = _brush.Color;
         _brush = new SolidBrush(Color.FromArgb(newAlpha, brushColor.R, brushColor.G, brushColor.B));
         _pen = new Pen(Color.FromArgb(newAlpha, _pen.Color.R, _pen.Color.G, _pen.Color.B));
      }

      private void CreateHandles()
      {
         Point leftTop = new Point();
         int handleEdgeLength = 6;
         int handleEdgeHalf = handleEdgeLength / 2;

         leftTop.X = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left - handleEdgeHalf;
         leftTop.Y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top - handleEdgeHalf;
         _leftTopHandle = new Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength);

         leftTop.X = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Right - handleEdgeHalf;
         leftTop.Y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top - handleEdgeHalf;
         _rightTopHandle = new Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength);

         leftTop.X = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left - handleEdgeHalf;
         leftTop.Y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Bottom - handleEdgeHalf;
         _leftBottomHandle = new Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength);

         leftTop.X = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Right - handleEdgeHalf;
         leftTop.Y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Bottom - handleEdgeHalf;
         _rightBottomHandle = new Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength);

         leftTop.X = (_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left + _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Width / 2) - handleEdgeHalf;
         leftTop.Y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top - handleEdgeHalf;
         _upperHandle = new Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength);

         leftTop.X = (_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left + _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Width / 2) - handleEdgeHalf;
         leftTop.Y = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Bottom - handleEdgeHalf;
         _lowerHandle = new Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength);

         leftTop.X = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Left - handleEdgeHalf;
         leftTop.Y = (_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top + _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Height / 2) - handleEdgeHalf;
         _leftHandle = new Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength);

         leftTop.X = _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Right - handleEdgeHalf;
         leftTop.Y = (_processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Top + _processingBox.Bounds.ToRectangle(_dpiX, _dpiY).Height / 2) - handleEdgeHalf;
         _rightHandle = new Rectangle(leftTop.X, leftTop.Y, handleEdgeLength, handleEdgeLength);

      }

      private void DrawHandles(Graphics graphics, Transformer transformer)
      {
         Rectangle transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_leftTopHandle));
         graphics.DrawRectangle(Pens.Black, transformedRect);
         graphics.FillRectangle(Brushes.Black, transformedRect);

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_rightTopHandle));
         graphics.DrawRectangle(Pens.Black, transformedRect);
         graphics.FillRectangle(Brushes.Black, transformedRect);

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_leftBottomHandle));
         graphics.DrawRectangle(Pens.Black, transformedRect);
         graphics.FillRectangle(Brushes.Black, transformedRect);

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_rightBottomHandle));
         graphics.DrawRectangle(Pens.Black, transformedRect);
         graphics.FillRectangle(Brushes.Black, transformedRect);

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_upperHandle));
         graphics.DrawRectangle(Pens.Black, transformedRect);
         graphics.FillRectangle(Brushes.Black, transformedRect);

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_lowerHandle));
         graphics.DrawRectangle(Pens.Black, transformedRect);
         graphics.FillRectangle(Brushes.Black, transformedRect);

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_leftHandle));
         graphics.DrawRectangle(Pens.Black, transformedRect);
         graphics.FillRectangle(Brushes.Black, transformedRect);

         transformedRect = System.Drawing.Rectangle.Round(transformer.RectangleToPhysical(_rightHandle));
         graphics.DrawRectangle(Pens.Black, transformedRect);
         graphics.FillRectangle(Brushes.Black, transformedRect);
      }

      public void Draw(Graphics graphics, Matrix transform)
      {
         Transformer tranformer = new Transformer(transform);
         Rectangle transformedRect = System.Drawing.Rectangle.Round(tranformer.RectangleToPhysical(_processingBox.Bounds.ToRectangle(_dpiX, _dpiY)));
         graphics.DrawRectangle(_pen, transformedRect);
         graphics.FillRectangle(_brush, transformedRect);

         if (_selected)
            DrawHandles(graphics, tranformer);
      }
   }
}
