// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Svg;
using Leadtools.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace SvgDemo
{
   public class Viewer : Control
   {
      public Viewer()
      {
         var styles = ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint;
         SetStyle(styles, true);
         _currentPageIndex = 0;
         _totalPages = 1;
      }

      private BorderStyle _borderStyle = BorderStyle.None;
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public BorderStyle BorderStyle
      {
         get
         {
            return _borderStyle;
         }
         set
         {
            if (_borderStyle != value)
            {
               _borderStyle = value;
               UpdateStyles();
               Invalidate();
            }
         }
      }

      // To support border styles
      protected override CreateParams CreateParams
      {
         get
         {
            CreateParams cp = base.CreateParams;

            switch (BorderStyle)
            {
               case BorderStyle.None:
                  cp.Style &= ~SafeNativeMethods.WS_BORDER;
                  cp.ExStyle &= ~SafeNativeMethods.WS_EX_CLIENTEDGE;
                  break;

               case BorderStyle.FixedSingle:
                  cp.Style |= SafeNativeMethods.WS_BORDER;
                  cp.ExStyle &= ~SafeNativeMethods.WS_EX_CLIENTEDGE;
                  break;

               case BorderStyle.Fixed3D:
                  cp.Style &= ~SafeNativeMethods.WS_BORDER;
                  cp.ExStyle |= SafeNativeMethods.WS_EX_CLIENTEDGE;
                  break;
            }

            return cp;
         }
      }

      private LeadMatrix _transformInverse = LeadMatrix.Identity;
      private LeadMatrix _transform = LeadMatrix.Identity;
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public LeadMatrix Transform
      {
         get { return _transform; }
         set
         {
            _transform = value;
            _transformInverse = _transform.Clone();
            if (_transformInverse.HasInverse)
               _transformInverse.Invert();

            Invalidate();
         }
      }

      private List<SvgDocumentInformation> _documents = new List<SvgDocumentInformation>();
      public List<SvgDocumentInformation> DocumentList
      {
         get
         {
            return _documents;
         }

         set
         {
            foreach (SvgDocumentInformation doc in _documents)
            {
               doc.Document.Dispose();
            }

            _documents.Clear();
            _currentPageIndex = 0;
            _totalPages = 0;

            if (value != null)
            {
               foreach (SvgDocumentInformation doc in value)
                  _documents.Add(doc);
            }
         }
      }

      [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
      public SvgDocument CurrentDocument
      {
         get
         {
            if (_documents.Count == 0)
               return null;

            return _documents[_currentPageIndex].Document;
         }
      }

      public enum CoordinateType
      {
         Image,
         Control
      }

      public LeadPointD ConvertPoint(CoordinateType source, CoordinateType destination, LeadPointD point)
      {
         if (source == destination)
            return point;

         LeadPointD[] points = { point };

         if (source == CoordinateType.Control)
            _transformInverse.TransformPoints(points);
         else
            _transform.TransformPoints(points);

         return points[0];
      }

      private bool _isPanning = false;

      private void StopPanning()
      {
         if (_documents.Count != 0 && _isPanning)
         {
            this.Capture = false;
            _isPanning = false;

            if (PanEnd != null)
               PanEnd(this, EventArgs.Empty);
         }
      }

      private void StartPanning(MouseEventArgs e)
      {
         if (_documents.Count == 0)
            return;

         _isPanning = true;
         this.Capture = true;

         if (PanBegin != null)
            PanBegin(this, e);
      }

      protected override void OnMouseDown(MouseEventArgs e)
      {
         StopPanning();

         Focus();
         StartPanning(e);

         base.OnMouseDown(e);
      }

      public event MouseEventHandler Panning;
      public event MouseEventHandler PanBegin;
      public event EventHandler PanEnd;

      protected override void OnMouseMove(MouseEventArgs e)
      {
         if (_documents.Count != 0 && _isPanning)
         {
            if (Panning != null)
               Panning(this, e);
         }

         base.OnMouseMove(e);
      }

      protected override void OnMouseUp(MouseEventArgs e)
      {
         StopPanning();

         base.OnMouseUp(e);
      }

      protected override void OnLostFocus(EventArgs e)
      {
         StopPanning();

         base.OnLostFocus(e);
      }

      private bool _useDpi;

      public bool UseDpi
      {
         get { return _useDpi; }
         set { _useDpi = value; Identity(); }
      }

      public LeadSize ImageSize
      {
         get
         {
            if (_documents[_currentPageIndex].Document == null)
               return LeadSize.Create(0, 0);

            var svgBounds = _documents[_currentPageIndex].Document.Bounds;
            return LeadSize.Create(Tools.ToInt(svgBounds.Bounds.Width), Tools.ToInt(svgBounds.Bounds.Height));
         }
      }

      public void Identity()
      {
         if (_documents.Count == 0)
            return;

         if (_documents[_currentPageIndex].Document == null)
            return;

         var svgBounds = _documents[_currentPageIndex].Document.Bounds;
         var bounds = svgBounds.Bounds;
         var transform = LeadMatrix.Identity;

         if (_useDpi)
         {
            var imageSize = this.ImageSize;
            var resolution = LeadSizeD.Create(96, 96);
            if (!svgBounds.Resolution.IsEmpty)
            {
               if (svgBounds.Resolution.Width > 0)
                  resolution.Width = svgBounds.Resolution.Width;
               if (svgBounds.Resolution.Height > 0)
                  resolution.Height = svgBounds.Resolution.Height;
            }

            transform.Scale(
               (double)96.0 / resolution.Width,
               (double)96.0 / resolution.Height);
         }

         this.Transform = transform;
         Invalidate();
      }

      private bool _drawClipRectangle = true;
      public bool DrawClipRectangle
      {
         get { return _drawClipRectangle; }
         set
         {
            _drawClipRectangle = value;
            Invalidate();
         }
      }

      private int _updateCounter = 0;
      public void BeginUpdate()
      {
         _updateCounter++;
      }

      public void EndUpdate()
      {
         if (_updateCounter == 0) throw new InvalidOperationException("EndUpdate without matching BeginUpdate");
         _updateCounter--;

         if (_updateCounter == 0)
            Invalidate();
      }

      protected bool CanUpdate
      {
         get { return _updateCounter == 0; }
      }

      protected override void OnPaint(PaintEventArgs e)
      {
         DrawImage(e, this.ClientRectangle);
         base.OnPaint(e);
      }

      private static void DrawBounds(Graphics graphics, Pen pen, Brush brush, Brush textBrush, Font font, string text, LeadRectD bounds, LeadMatrix transform)
      {
         var corners = Tools.GetCornerPoints(bounds);
         transform.TransformPoints(corners);
         var cornersBounds = Tools.GetBoundingRect(corners);

         var cornersF = new PointF[4];
         for (var i = 0; i < cornersF.Length; i++)
         {
            // if any point empty, then return
            if (corners[i].IsEmpty)
               return;

            cornersF[i] = new PointF((float)corners[i].X, (float)corners[i].Y);
         }

         if (pen != null)
            graphics.DrawPolygon(pen, cornersF);
         if (brush != null)
            graphics.FillPolygon(brush, cornersF);
         if (text != null && textBrush != null)
            graphics.DrawString(text, font, textBrush, (float)cornersBounds.X, (float)cornersBounds.Y);
      }

      private void DrawImage(PaintEventArgs e, Rectangle clipRect)
      {
         if (_documents.Count == 0)
            return;

         if (_documents[_currentPageIndex].Document == null || !this.CanUpdate)
            return;

         var graphics = e.Graphics;

         var options = new SvgRenderOptions();
         options.Transform = _transform;
         options.Bounds = _documents[_currentPageIndex].Document.Bounds.Bounds;
         options.UseBackgroundColor = true;
         options.ClipBounds = LeadRectD.Create(clipRect.X, clipRect.Y, clipRect.Width, clipRect.Height);
         options.BackgroundColor = RasterColor.FromKnownColor(RasterKnownColor.White);

         try
         {
            using (var engine = RenderingEngineFactory.Create(graphics))
               _documents[_currentPageIndex].Document.Render(engine, options);
         }
         catch
         {
            Console.WriteLine();
         }

         DrawBounds(graphics, Pens.Black, null, null, null, null, options.Bounds, options.Transform);

         if (_documents[_currentPageIndex].DocumentText != null && _documents[_currentPageIndex].ShowText)
         {
            LeadRectD docBounds = _documents[_currentPageIndex].Document.Bounds.Bounds;

            // Could be rotated, so
            LeadPointD topLeft = docBounds.TopLeft;
            LeadPointD bottomRight = docBounds.BottomRight;

            LeadPointD[] corners = new LeadPointD[4];
            corners[0].X = topLeft.X;
            corners[0].Y = topLeft.Y;
            corners[1].X = bottomRight.X;
            corners[1].Y = topLeft.Y;
            corners[2].X = bottomRight.X;
            corners[2].Y = bottomRight.Y;
            corners[3].X = topLeft.X;
            corners[3].Y = bottomRight.Y;

            options.Transform.TransformPoints(corners);

            GraphicsPath path = new GraphicsPath();
            PointF[] pts = new PointF[4];
            for (int i = 0; i < corners.Length; i++)
            {
               pts[i].X = (float)corners[i].X;
               pts[i].Y = (float)corners[i].Y;
            }
            path.AddPolygon(pts);
            graphics.SetClip(path, System.Drawing.Drawing2D.CombineMode.Intersect);

            using (var brush = new SolidBrush(Color.FromArgb(64, Color.Black)))
            {
               foreach (var character in _documents[_currentPageIndex].DocumentText.Characters)
               {
                  var bounds = character.Bounds;
                  var text = new string(new char[] { character.Code });

                  DrawBounds(graphics, Pens.Yellow, brush, Brushes.Yellow, Font, text, character.Bounds, options.Transform);
               }
            }
         }

         base.OnPaint(e);
      }

      private int _currentPageIndex;
      public int CurrentPageIndex
      {
         get { return _currentPageIndex; }
         set
         {
            _currentPageIndex = value;

            Identity();
            Invalidate();
         }
      }

      private int _totalPages;
      public int TotalPages
      {
         get { return _totalPages; }
         set { _totalPages = value; }
      }
   }
}
