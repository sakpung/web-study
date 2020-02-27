// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Leadtools.Demos
{
   /// <summary>
   /// Ruler unit
   /// </summary>
   public enum RulerPainterUnit
   {
      /// <summary>
      /// Inches
      /// </summary>
      Inch,

      /// <summary>
      /// Millimeters
      /// </summary>
      Millimeter
   }

   /// <summary>
   /// Ruler orientation
   /// </summary>
   public enum RulerPainterOrientation
   {
      Horizontal,
      Vertical
   }

   /// <summary>
   /// Ruler alignment
   /// </summary>
   public enum RulerPainterAlignment
   {
      Bottom,
      Top
   }

   /// <summary>
   /// Ruler style
   /// </summary>
   public enum RulerPainterStyle
   {
      Middle,
      Edge
   }

   /// <summary>
   /// Paints a ruler to a destination rectangle
   /// </summary>
   public class RulerPainter
   {
      #region Properties

      private Color _backColor = Color.White;

      /// <summary>
      /// Back color, used for the background of in range ruler and edge of pad area
      /// </summary>
      public Color BackColor
      {
         get
         {
            return _backColor;
         }
         set
         {
            _backColor = value;
         }
      }

      private Color _padColor = Color.LightGray;

      /// <summary>
      /// Pad color, used for the background of out of range ruler and edge of in range area
      /// </summary>
      public Color PadColor
      {
         get
         {
            return _padColor;
         }
         set
         {
            _padColor = value;
         }
      }

      private Color _foreColor = Color.Black;

      /// <summary>
      /// Fore color, used for ticks and text
      /// </summary>
      public Color ForeColor
      {
         get
         {
            return _foreColor;
         }
         set
         {
            _foreColor = value;
         }
      }

      private string _fontFamilyName = "Times New Roman";

      /// <summary>
      /// Font family name
      /// </summary>
      public string FontFamilyName
      {
         get
         {
            return _fontFamilyName;
         }
         set
         {
            _fontFamilyName = value;
         }
      }

      private float _fontPointSize = 8.5f;

      /// <summary>
      /// Font point size
      /// </summary>
      public float FontPointSize
      {
         get
         {
            return _fontPointSize;
         }
         set
         {
            _fontPointSize = value;
         }
      }

      private FontStyle _fontStyle = FontStyle.Regular;

      /// <summary>
      /// Font style
      /// </summary>
      public FontStyle FontStyle
      {
         get
         {
            return _fontStyle;
         }
         set
         {
            _fontStyle = value;
         }
      }

      private RulerPainterOrientation _orientation = RulerPainterOrientation.Horizontal;

      /// <summary>
      /// Ruler orientation (horizontal or vertical)
      /// </summary>
      public RulerPainterOrientation Orientation
      {
         get
         {
            return _orientation;
         }
         set
         {
            _orientation = value;
         }
      }

      private RulerPainterAlignment _alignment = RulerPainterAlignment.Bottom;

      /// <summary>
      /// Ruler alignment (top or bottom)
      /// </summary>
      public RulerPainterAlignment Alignment
      {
         get
         {
            return _alignment;
         }
         set
         {
            _alignment = value;
         }
      }

      private RulerPainterStyle _style = RulerPainterStyle.Middle;

      /// <summary>
      /// Ruler style (middle or edge)
      /// </summary>
      public RulerPainterStyle Style
      {
         get
         {
            return _style;
         }
         set
         {
            _style = value;
         }
      }

      private RulerPainterUnit _unit = RulerPainterUnit.Inch;

      /// <summary>
      /// Ruler units (inches, centimeters)
      /// </summary>
      public RulerPainterUnit Unit
      {
         get
         {
            return _unit;
         }
         set
         {
            if(value != _unit)
            {
               _unit = value;

               // Change the length to be in the new units
               double newLength;

               if(_unit == RulerPainterUnit.Inch)
               {
                  // Old units were in millimeters, convert them to inches
                  newLength = _length / _mmRatio;
               }
               else
               {
                  // Old units were in inches, convert them to millimeters
                  newLength = _length * _mmRatio;
               }

               Length = newLength;
            }
         }
      }

      private double _length = 8.5;

      /// <summary>
      /// Ruler length in current units
      /// </summary>
      public double Length
      {
         get
         {
            return _length;
         }
         set
         {
            if(value < 0)
               throw new ArgumentException("Must be a value greater to or equal to 0", "Length");

            _length = value;
         }
      }

      private int _originPixelOffset = 0;

      /// <summary>
      /// Ruler pixel origin (The number of pixels where the 0 in the ruler is)
      /// </summary>
      public int OriginPixelOffset
      {
         get
         {
            return _originPixelOffset;
         }
         set
         {
            _originPixelOffset = value;
         }
      }

      private float _resolution = 0;

      /// <summary>
      /// Ruler resolution. 0 for current screen resolution
      /// </summary>
      public float Resolution
      {
         get
         {
            return _resolution;
         }
         set
         {
            if(value < 0)
               throw new ArgumentException("Must be a value greater than or equal to 0", "Resolution");

            _resolution = value;
         }
      }

      private double _scaleFactor = 1;

      /// <summary>
      /// Ruler scale factor (zooming)
      /// </summary>
      public double ScaleFactor
      {
         get
         {
            return _scaleFactor;
         }
         set
         {
            if(value < 0)
               throw new ArgumentException("Must be a value greater than or equal to 0", "ScaleFactor");

            _scaleFactor = value;
         }
      }

      #endregion Properties

      #region Painting

      private const double _mmRatio = 25.400000025908000026426160026955;

      // Current dpi
      private float _dpi;

      // Current convert to/from pixels factor
      private double _toPixelsFactor = 1.0;

      // Convert from pixels to units
      private double ConvertFromPixels(double value)
      {
         return value / _toPixelsFactor;
      }

      // Convert from units to pixels
      private double ConvertToPixels(double value)
      {
         return value * _toPixelsFactor;
      }

      public void Paint(Graphics g, Rectangle bounds)
      {
         GraphicsState gstate = g.Save();
         try
         {
            // Smooth text painting
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Get the current DPIs
            _dpi = (_orientation == RulerPainterOrientation.Horizontal) ? g.DpiX : g.DpiY;
            float actualResolution = (_resolution != 0) ? _resolution : _dpi;

            // Calculate the conversion factor
            _toPixelsFactor = _scaleFactor * actualResolution;
            if(_unit == RulerPainterUnit.Millimeter)
               _toPixelsFactor /= _mmRatio;

            // Calculate the padding, how many units we need to pad the length from left and right (or top and bottom in vertical rulers)
            // 1 inch or 10 mm (1 cm)
            int extraPad = (_unit == RulerPainterUnit.Inch) ? 1 : 10;

            int padBefore = (int)(ConvertFromPixels(_originPixelOffset) + extraPad);
            int boundsLength = (_orientation == RulerPainterOrientation.Horizontal) ? bounds.Width : bounds.Height;
            int padAfter = (int)ConvertFromPixels((boundsLength - _originPixelOffset - ConvertToPixels(_length))) + extraPad;

            // If this is mm, the pads needs to be a multiple of 10
            if(_unit == RulerPainterUnit.Millimeter)
            {
               if((double)padBefore / 10.0 != (int)(padBefore / 10))
                  padBefore = ((int)(padBefore / 10) + 1) * 10;

               if((double)padAfter / 10.0 != (int)(padAfter / 10))
                  padAfter = ((int)(padAfter / 10) + 1) * 10;
            }

            // Set the clip region
            g.SetClip(bounds);

            // Fill the pads background
            FillPads(g, bounds, padAfter);

            // Draw the ruler
            DrawRuler(g, bounds, padBefore, padAfter);
         }
         finally
         {
            g.Restore(gstate);
         }
      }

      [Flags]
      private enum FillAndStrokeSides
      {
         None = 0,
         Left = 1 << 0,
         Top = 1 << 1,
         Right = 1 << 2,
         Bottom = 1 << 3
      }

      private static void FillAndStrokeRectangle(Graphics g, Pen pen, Brush brush, RectangleF rc, FillAndStrokeSides sides)
      {
         g.FillRectangle(brush, rc);

         if((sides & FillAndStrokeSides.Left) == FillAndStrokeSides.Left)
            g.DrawLine(pen, rc.X, rc.Y, rc.X, rc.Bottom - 1);

         if((sides & FillAndStrokeSides.Top) == FillAndStrokeSides.Top)
            g.DrawLine(pen, rc.X, rc.Y, rc.Right - 1, rc.Y);

         if((sides & FillAndStrokeSides.Right) == FillAndStrokeSides.Right)
            g.DrawLine(pen, rc.Right, rc.Y, rc.Right, rc.Bottom - 1);

         if((sides & FillAndStrokeSides.Bottom) == FillAndStrokeSides.Bottom)
            g.DrawLine(pen, rc.X, rc.Bottom, rc.Right - 1, rc.Bottom);
      }

      private void FillPads(Graphics g, Rectangle bounds, int padAfter)
      {
         double boundsStart = (_orientation == RulerPainterOrientation.Horizontal) ? bounds.X : bounds.Y;
         double rulerStart = boundsStart + _originPixelOffset;
         double rulerStop = rulerStart + ConvertToPixels(_length);

         RectangleF rc;
         FillAndStrokeSides sides;

         // Everything before padBefore and after padAfter needs to be filled with pad color
         using(Brush brush = new SolidBrush(PadColor))
         using(Pen pen = new Pen(BackColor))
         {
            if(_orientation == RulerPainterOrientation.Horizontal)
            {
               rc = RectangleF.FromLTRB(
               (float)boundsStart,
               (float)bounds.Y,
               (float)rulerStart,
               (float)bounds.Bottom - 1);

               sides = FillAndStrokeSides.Left | FillAndStrokeSides.Top | FillAndStrokeSides.Bottom;
            }
            else
            {
               rc = RectangleF.FromLTRB(
                  (float)bounds.X,
                  (float)boundsStart,
                  (float)bounds.Right - 1,
                  (float)rulerStart);

               sides = FillAndStrokeSides.Left | FillAndStrokeSides.Top | FillAndStrokeSides.Right;
            }

            FillAndStrokeRectangle(g, pen, brush, rc, sides);

            if(_orientation == RulerPainterOrientation.Horizontal)
            {
               rc = RectangleF.FromLTRB(
                  (float)rulerStop,
                  rc.Y,
                  Math.Min((float)(ConvertToPixels(padAfter) + rulerStop), bounds.Right - 1),
                  rc.Bottom);

               sides = FillAndStrokeSides.Right | FillAndStrokeSides.Top | FillAndStrokeSides.Bottom;
            }
            else
            {
               rc = RectangleF.FromLTRB(
                  rc.X,
                  (float)rulerStop,
                  rc.Right,
                  Math.Min((float)(ConvertToPixels(padAfter) + rulerStop), bounds.Bottom - 1));

               sides = FillAndStrokeSides.Left | FillAndStrokeSides.Bottom | FillAndStrokeSides.Right;
            }

            FillAndStrokeRectangle(g, pen, brush, rc, sides);
         }

         // Everything in between needs to be filled with back color
         using(Brush brush = new SolidBrush(BackColor))
         using(Pen pen = new Pen(PadColor))
         {
            if(_orientation == RulerPainterOrientation.Horizontal)
            {
               rc = RectangleF.FromLTRB(
               (float)rulerStart - 1,
               (float)bounds.Y,
               (float)rulerStop + 1,
               (float)bounds.Bottom - 1);
               sides = FillAndStrokeSides.Top | FillAndStrokeSides.Bottom;
            }
            else
            {
               rc = RectangleF.FromLTRB(
               (float)bounds.X,
               (float)rulerStart - 1,
               (float)bounds.Right - 1,
               (float)rulerStop + 1);
               sides = FillAndStrokeSides.Left | FillAndStrokeSides.Right;
            }

            FillAndStrokeRectangle(g, pen, brush, rc, sides);
         }
      }

      private void DrawRuler(Graphics g, Rectangle bounds, int padBefore, int padAfter)
      {
         // The minimum distance between tick marks, otherwise, hide close ticks
         double minimumTickDistance = ConvertFromPixels(2.0);

         // Find the full, large and small tick increments
         double fullIncrement;
         double largeIncrement;
         double smallIncrement;

         if(_unit == RulerPainterUnit.Inch)
         {
            // Ticks at 1, 1/2 and 1/4 of an inch
            fullIncrement = 1;
            largeIncrement = 0.5;
            smallIncrement = 0.25;
         }
         else
         {
            // Ticks at 1cm, 5mm and 1mm
            fullIncrement = 10;
            largeIncrement = 5;
            smallIncrement = 1;
         }

         // Find the tick increment to use based on the unit and current scale

         // Use smallest increment
         double tickIncrement = smallIncrement;
         if(tickIncrement < minimumTickDistance)
         {
            // Too small, use next
            tickIncrement = largeIncrement;
            if(tickIncrement < minimumTickDistance)
            {
               // Too small, use next
               tickIncrement = fullIncrement;
               if(tickIncrement < minimumTickDistance)
               {
                  // Too small, we need to keep going till we run at ouf length
                  while(tickIncrement < minimumTickDistance && tickIncrement < _length)
                     tickIncrement *= 2;
               }
            }
         }

         using(Font font = new Font(_fontFamilyName, _fontPointSize, _fontStyle, GraphicsUnit.Point))
         using(StringFormat sf = new StringFormat())
         using(Pen pen = new Pen(ForeColor))
         using(Brush textBrush = new SolidBrush(ForeColor))
         {
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            if(_orientation == RulerPainterOrientation.Vertical)
               sf.FormatFlags |= StringFormatFlags.DirectionVertical;

            // Draw the ruler ticks
            DrawRulerTicks(g, bounds, font, pen, textBrush, sf, padBefore, padAfter, tickIncrement, largeIncrement, fullIncrement);
         }
      }

      private void DrawRulerTicks(Graphics g, Rectangle bounds, Font font, Pen pen, Brush textBrush, StringFormat sf, double padBefore, double padAfter, double tickIncrement, double largeIncrement, double fullIncrement)
      {
         // The 0,0 origin of the ruler
         double xOrigin = bounds.X;
         double yOrigin = bounds.Y;
         double tickOrigin;
         double tickPosition;

         if(_orientation == RulerPainterOrientation.Horizontal)
         {
            xOrigin += _originPixelOffset;
            tickOrigin = xOrigin;
            tickPosition = yOrigin;
         }
         else
         {
            yOrigin += _originPixelOffset;
            tickOrigin = yOrigin;
            tickPosition = xOrigin;
         }

         SizeF textSize = g.MeasureString("WW", font, PointF.Empty, sf);
         double textHeight = (_orientation == RulerPainterOrientation.Horizontal) ? textSize.Height : textSize.Width;

         // Calculate the lengths of the tick marks
         double fullTickLength = (_orientation == RulerPainterOrientation.Horizontal) ? bounds.Height : bounds.Width;
         double largeTickLength = fullTickLength * 0.25;
         double smallTickLength = fullTickLength * 0.15;

         double fullTickStart;
         double fullTickStop;
         double largeTickStart;
         double largeTickStop;
         double smallTickStart;
         double smallTickStop;
         double legendStart;
         bool centerLegend;

         if(_style == RulerPainterStyle.Middle)
         {
            if(_alignment == RulerPainterAlignment.Bottom)
            {
               fullTickStart = tickPosition + (fullTickLength - smallTickLength);
               fullTickStop = tickPosition + fullTickLength;
            }
            else
            {
               fullTickStart = tickPosition;
               fullTickStop = tickPosition + smallTickLength;
            }

            largeTickStart = tickPosition + (fullTickLength - largeTickLength) / 2.0;
            largeTickStop = largeTickStart + largeTickLength;
            smallTickStart = tickPosition + (fullTickLength - smallTickLength) / 2.0;
            smallTickStop = smallTickStart + smallTickLength;

            // Calculate the location of the tick lenegds
            legendStart = tickPosition + (fullTickLength - textHeight) / 2.0;
            centerLegend = true;
         }
         else
         {
            fullTickStart = tickPosition;
            fullTickStop = tickPosition + fullTickLength;

            if(_alignment == RulerPainterAlignment.Bottom)
            {
               largeTickStart = tickPosition + fullTickLength;
               largeTickStop = largeTickStart - largeTickLength;
               smallTickStart = tickPosition + fullTickLength;
               smallTickStop = smallTickStart - smallTickLength;

               legendStart = tickPosition;
            }
            else
            {
               largeTickStart = tickPosition;
               largeTickStop = largeTickStart + largeTickLength;
               smallTickStart = tickPosition;
               smallTickStop = smallTickStart + smallTickLength;

               legendStart = tickPosition + (fullTickLength - textHeight);
            }

            centerLegend = false;
         }

         // Calculate the minimum distance between subsequent tick legends
         double lastLegendStop = double.MinValue;

         // For double calculations round-up errors
         const double delta = 0.0001;

         // Size of the full increment in pixels
         double fullIncrementPixels = ConvertToPixels(fullIncrement);

         // Calculate the tick scale
         // For mm, we need to scale everything by 10, since we will base our painting on centimeters and not mm
         double tickScale = (_unit == RulerPainterUnit.Inch) ? 1 : 10;

         fullIncrement /= tickScale;
         largeIncrement /= tickScale;

         // Draw the full length plus the pads
         for(double tick = -padBefore;
            tickIncrement < _length && tick <= (_length + padAfter);
            tick += tickIncrement)
         {
            // This is where the tick should go
            double tickPixels = tickOrigin + ConvertToPixels(tick);

            // Compensate for double rounding errors
            double tickToCheck;
            if(tick < 0)
               tickToCheck = (int)((tick / tickScale - delta) * 1000) / 1000.0;
            else
               tickToCheck = (int)((tick / tickScale + delta) * 1000) / 1000.0;

            // Find out the tick length (full, large or small)
            double tickStart = 0;
            double tickStop = 0;

            if(tickToCheck * fullIncrement == (int)(tickToCheck * fullIncrement))
            {
               tickStart = fullTickStart;
               tickStop = fullTickStop;

               // Only draw the legengds if we are inside the ruler length
               if(tick >= 0 && tick <= _length)
               {
                  // Here we need to draw the tick lengend
                  string legendText = ((int)tickToCheck).ToString();
                  SizeF legendTextSize = g.MeasureString(legendText, font, PointF.Empty, sf);

                  double legendShift = 0;

                  if(centerLegend)
                  {
                     if(_orientation == RulerPainterOrientation.Horizontal)
                        legendShift = legendTextSize.Width / 2.0f;
                     else
                        legendShift = legendTextSize.Height / 2.0f;
                  }

                  RectangleF legendRect;
                  double currentLegendStart;
                  double currentLegendStop;

                  if(_orientation == RulerPainterOrientation.Horizontal)
                  {
                     legendRect = new RectangleF(
                        (float)(tickPixels - legendShift),
                        (float)legendStart,
                        legendTextSize.Width,
                        legendTextSize.Height);

                     currentLegendStart = legendRect.X;
                     currentLegendStop = legendRect.Right;
                  }
                  else
                  {
                     legendRect = new RectangleF(
                        (float)(legendStart - legendShift / 2),
                        (float)(tickPixels - legendShift),
                        legendTextSize.Width,
                        legendTextSize.Height);

                     currentLegendStart = legendRect.Y;
                     currentLegendStop = legendRect.Bottom;
                  }

                  // First, check if we dont overlap the previous legend
                  if(currentLegendStart > lastLegendStop)
                  {
                     g.DrawString(legendText, font, textBrush, legendRect, sf);
                     lastLegendStop = currentLegendStop;
                  }
               }
            }
            else if(tickToCheck / largeIncrement == (int)(tickToCheck / largeIncrement))
            {
               tickStart = largeTickStart;
               tickStop = largeTickStop;
            }
            else
            {
               tickStart = smallTickStart;
               tickStop = smallTickStop;
            }

            // Draw the tick
            if(_orientation == RulerPainterOrientation.Horizontal)
            {
               g.DrawLine(
                  pen,
                  (float)tickPixels,
                  (float)tickStart,
                  (float)tickPixels,
                  (float)tickStop);
            }
            else
            {
               g.DrawLine(
                  pen,
                  (float)tickStart,
                  (float)tickPixels,
                  (float)tickStop,
                  (float)tickPixels);
            }
         }
      }

      #endregion Painting
   }
}
