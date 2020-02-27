// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Demos;
using Leadtools.Drawing;

namespace MainDemo
{
   public class PanImageEvent : EventArgs
   {
      private Point _offset;

      public PanImageEvent(Point offset)
      {
         _offset = offset;
      }

      public Point Offset
      {
         get
         {
            return _offset;
         }
      }
   }

   public partial class ImagePreviewCtrl : UserControl
   {
      private RasterImage _image;
      private RasterPaintProperties _paintProperties;
      private bool _fitView;
      private Rectangle _sourceRectangle;
      private Rectangle _destinationRectangle;
      private BorderStyle _borderStyle;
      private bool _isPanAllowed;
      private bool _isPanModeBusy;
      private bool _isCursorClipped;
      private Rectangle _rcClip;
      private Point _panPoint;
      private Point _offset;

      private const int WS_BORDER = 0x00800000;
      private const int WS_EX_CLIENTEDGE = 0x00000200;

      public ImagePreviewCtrl(RasterImage image, RasterPaintProperties paintProperties, Point previewPosition, Size previewSize)
      {
         this.Location = previewPosition;
         this.Size = previewSize;

         InitializeComponent();
         SetStyle(ControlStyles.ResizeRedraw, true);
         SetStyle(ControlStyles.AllPaintingInWmPaint, true);
         SetStyle(ControlStyles.ContainerControl, true);
         SetStyle(ControlStyles.SupportsTransparentBackColor, true);
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
         SetStyle(ControlStyles.UserPaint, true);

         _image = image;
         _paintProperties = paintProperties;
         _fitView = false;
         _sourceRectangle = _destinationRectangle = Rectangle.Empty;
         _borderStyle = BorderStyle.Fixed3D;
         _isPanAllowed = false;
         _isPanModeBusy = false;
         _isCursorClipped = false;
         _panPoint = Point.Empty;
         _offset = Point.Empty;

         CalculateAll();
      }

      public RasterImage Image
      {
         get
         {
            return _image;
         }
         set
         {
            if (_image != value)
            {
               _image = value;
               OnImageChanged(EventArgs.Empty);
            }
         }
      }

      public event EventHandler ImageChanged;

      protected virtual void OnImageChanged(EventArgs e)
      {
         CalculateAll();
         Invalidate();

         if (ImageChanged != null)
            ImageChanged(this, e);
      }

      protected override CreateParams CreateParams
      {
         get
         {
            CreateParams cp = base.CreateParams;

            switch (BorderStyle)
            {
               case BorderStyle.None:
                  cp.Style &= ~WS_BORDER;
                  cp.ExStyle &= ~WS_EX_CLIENTEDGE;
                  break;

               case BorderStyle.FixedSingle:
                  cp.Style |= WS_BORDER;
                  cp.ExStyle &= ~WS_EX_CLIENTEDGE;
                  break;

               case BorderStyle.Fixed3D:
                  cp.Style &= ~WS_BORDER;
                  cp.ExStyle |= WS_EX_CLIENTEDGE;
                  break;
            }

            return cp;
         }
      }

      protected override void OnPaint(PaintEventArgs e)
      {
         try
         {
            Rectangle dstRect = DestinationRectangle;

            RasterImagePainter.Paint(
               _image,
               e.Graphics,
               Converters.ConvertRect(SourceRectangle),
               LeadRect.Empty,
               Converters.ConvertRect(dstRect),
               Converters.ConvertRect(e.ClipRectangle),
               _paintProperties);

         }
         catch
         {
         }
      }

      public event EventHandler FitViewChanged;

      protected virtual void OnFitViewChanged(EventArgs e)
      {
         CalculateAll();
         Invalidate();

         if (FitViewChanged != null)
            FitViewChanged(this, e);
      }

      public event EventHandler BorderStyleChanged;

      protected virtual void OnBorderStyleChanged(EventArgs e)
      {
         UpdateStyles();
         Invalidate();

         if (BorderStyleChanged != null)
            BorderStyleChanged(this, e);
      }

      private void CalculateAll()
      {
         double currentXScaleFactor = 1;
         double currentYScaleFactor = 1;

         bool fitView = FitView;
         _sourceRectangle = Rectangle.Empty;
         if (_image != null)
         {
            _sourceRectangle = new Rectangle(0, 0, _image.Width, _image.Height);
         }

         _destinationRectangle = ClientRectangle;

         if (fitView)
         {
            if (_sourceRectangle.Width > 0 && _sourceRectangle.Height > 0)
            {
               if (_destinationRectangle.Width > 0 && _destinationRectangle.Height > 0)
               {
                  double factor;

                  if (_destinationRectangle.Width > _destinationRectangle.Height)
                  {
                     factor = _destinationRectangle.Width / (double)_sourceRectangle.Width;
                     if ((factor * (double)_sourceRectangle.Height) > _destinationRectangle.Height)
                        factor = _destinationRectangle.Height / (double)_sourceRectangle.Height;
                  }
                  else
                  {
                     factor = _destinationRectangle.Height / (double)_sourceRectangle.Height;
                     if ((factor * (double)_sourceRectangle.Width) > _destinationRectangle.Width)
                        factor = _destinationRectangle.Width / (double)_sourceRectangle.Width;
                  }

                  currentXScaleFactor = factor;
                  currentYScaleFactor = factor;
               }
            }
         }

         if (currentXScaleFactor <= 0.0)
            currentXScaleFactor = 1;
         if (currentYScaleFactor <= 0.0)
            currentYScaleFactor = 1;

         _destinationRectangle = new Rectangle(0, 0, (int)(SourceRectangle.Width * currentXScaleFactor), (int)(SourceRectangle.Height * currentYScaleFactor));
         int left = 0;
         int top = 0;

         // Center the Image.
         left = (int)((ClientRectangle.Width - _destinationRectangle.Width) / 2);
         top = (int)((ClientRectangle.Height - _destinationRectangle.Height) / 2);

         _isPanAllowed = !FitView && (SourceRectangle.Width > ClientRectangle.Width || SourceRectangle.Height > ClientRectangle.Height);

         _offset = Point.Empty;
         _destinationRectangle.Offset(left, top);
      }

      public bool FitView
      {
         get
         {
            return _fitView;
         }
         set
         {
            if (_fitView != value)
            {
               _fitView = value;
               OnFitViewChanged(EventArgs.Empty);
            }
         }
      }

      public new BorderStyle BorderStyle
      {
         get
         {
            return _borderStyle;
         }

         set
         {
            if (value != BorderStyle)
            {
               _borderStyle = value;
               OnBorderStyleChanged(EventArgs.Empty);
            }
         }
      }

      public Point Offset
      {
         get
         {
            return _offset;
         }
      }

      private bool IsPanModeBusy
      {
         get
         {
            return _isPanModeBusy;
         }
      }

      private Rectangle SourceRectangle
      {
         get
         {
            return _sourceRectangle;
         }
      }

      private Rectangle DestinationRectangle
      {
         get
         {
            return _destinationRectangle;
         }
      }

      private bool IsPanAllowed
      {
         get
         {
            return _isPanAllowed;
         }
      }

      private void CancelPanMode()
      {
         if (IsPanModeBusy)
         {
            EndPanMode();
         }
      }

      private void EndPanMode()
      {
         if (IsPanModeBusy)
         {
            Capture = false;
            _isPanModeBusy = false;

            EndClipCursor();
         }
      }

      private void BeginPanMode(bool clipCursor)
      {
         _isPanModeBusy = true;
         Capture = true;

         if (clipCursor)
            BeginClipCursor();
      }

      private void BeginClipCursor()
      {
         Rectangle rc = Rectangle.Intersect(DemosGlobal.FixRectangle(SourceRectangle), ClientRectangle);
         rc = RectangleToScreen(rc);
         Control parent = Parent;
         while (parent != null)
         {
            rc = Rectangle.Intersect(rc, Parent.RectangleToScreen(Parent.ClientRectangle));
            if (parent is Form)
            {
               Form form = parent as Form;
               if (form.IsMdiChild && form.Owner != null)
                  rc = Rectangle.Intersect(rc, form.Owner.RectangleToScreen(form.Owner.ClientRectangle));
            }

            parent = parent.Parent;
         }

         _rcClip = Cursor.Clip;
         Cursor.Clip = rc;
         _isCursorClipped = true;
      }

      private void EndClipCursor()
      {
         if (_isCursorClipped)
         {
            Cursor.Clip = _rcClip;
            _isCursorClipped = false;
            _rcClip = Rectangle.Empty;
         }
      }

      protected override void OnMouseDown(MouseEventArgs e)
      {
         Focus();

         if (Image != null)
         {
            if (e.Button == MouseButtons.Left)
            {
               if (IsPanAllowed)
               {
                  if (IsPanModeBusy)
                     CancelPanMode();
                  else
                  {
                     Point pt = new Point(e.X, e.Y);
                     Rectangle rc = SourceRectangle;
                     if (rc.Contains(pt))
                     {
                        BeginPanMode(false);
                        _panPoint = pt;
                     }
                  }
               }
            }
            else if (IsPanModeBusy)
               CancelPanMode();
         }

         base.OnMouseDown(e);
      }

      protected override void OnMouseMove(MouseEventArgs e)
      {
         if (IsPanModeBusy)
         {
            if ((_panPoint.X - e.X) != 0 || (_panPoint.Y - e.Y) != 0)
            {
               Point offset = new Point(
                  -(_panPoint.X - e.X),
                  -(_panPoint.Y - e.Y));

               UpdateDestinationRect(offset);
               _panPoint = new Point(e.X, e.Y);
            }
         }
         base.OnMouseMove(e);
      }

      protected override void OnMouseUp(MouseEventArgs e)
      {
         if (IsPanAllowed)
         {
            EndPanMode();
         }
         base.OnMouseUp(e);
      }

      private void UpdateDestinationRect(Point offset)
      {
         bool updatePan = false;
         Point panPoint = Point.Empty;

         if ((_destinationRectangle.Left + offset.X <= 0) &&
            (Math.Abs(_destinationRectangle.Left) + ClientRectangle.Width - offset.X <= SourceRectangle.Width))
         {
            updatePan = true;
            panPoint.X = offset.X;
         }

         if ((_destinationRectangle.Top + offset.Y <= 0) &&
              (Math.Abs(_destinationRectangle.Top) + ClientRectangle.Height - offset.Y <= SourceRectangle.Height))
         {
            updatePan = true;
            panPoint.Y = offset.Y;
         }

         if (updatePan)
         {
            PanImageEvent e = new PanImageEvent(panPoint);
            OnPanImage(e);
         }
      }

      public event EventHandler<PanImageEvent> PanImage;

      protected virtual void OnPanImage(PanImageEvent e)
      {
         OffsetImage(e.Offset);
         if (PanImage != null)
            PanImage(this, e);
      }

      public void OffsetImage(Point offset)
      {
         _destinationRectangle.Offset(offset);
         _offset.Offset(offset);

         Invalidate();
      }
   }
}
