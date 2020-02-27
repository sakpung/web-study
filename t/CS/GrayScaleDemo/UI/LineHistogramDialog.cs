// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools.ImageProcessing.Color;
using Leadtools;
using Leadtools.Controls;

namespace GrayScaleDemo
{
   enum downButtonPosition
   {
      NONE = 0,
      START_RECT = 1,
      END_RECT = 2
   }

   public partial class LineHistogramDialog : Form
   {
      private int _xStart, _yStart, _xEnd, _yEnd, _scale, _div;
      private LeadPoint _ptStart, _ptEnd;
      private int[] _redData;
      private int[] _greenData;
      private int[] _blueData;
      private RasterImage _image;
      private Pen _redPen, _greenPen, _bluePen;
      private Point[] _redPoints, _greenPoints, _bluePoints;
      private bool _firstTime = true;
      private bool _isGrayScale, _pressed;
      private ViewerForm _form;
      private ImageViewer _viewer;
      downButtonPosition _button;
      private Rectangle _startRect, _endRect;

      public LineHistogramDialog(ViewerForm form, ImageViewer viewer, bool isGray)
      {
         InitializeComponent();
         _image = viewer.Image;
         _isGrayScale = isGray;
         _form = form;
         _viewer = viewer;
         _button = downButtonPosition.NONE;
         _viewer.PostRender += new EventHandler<ImageViewerRenderEventArgs>(_viewer_PostRender);
      }

      private void LineHistogramDialog_Load(object sender, EventArgs e)
      {
         try
         {
            _xStart = _yStart = _xEnd = _yEnd = 0;
            _redPen = new Pen(Color.Red);
            _greenPen = new Pen(Color.Green);
            _bluePen = new Pen(Color.Blue);
            _numXStart.Maximum = _numXEnd.Maximum = _image.Width - 1;
            _numYStart.Maximum = _numYEnd.Maximum = _image.Height - 1;
            //_viewer.Paint += new PaintEventHandler(_viewer_Paint);
            _viewer.MouseMove += new MouseEventHandler(_viewer_MouseMove);
            _viewer.MouseDown += new MouseEventHandler(_viewer_MouseDown);
            _viewer.MouseUp += new MouseEventHandler(_viewer_MouseUp);
            _pressed = false;
         }
         catch (Exception /*ex*/)
         {
         }
      }

      void ApplyLineHistogram()
      {
         try
         {
            _ptStart = new LeadPoint(_xStart, _yStart);
            _ptEnd = new LeadPoint(_xEnd, _yEnd);

            LineProfileCommand cmd = new LineProfileCommand();
            cmd.FirstPoint = _ptStart;
            cmd.SecondPoint = _ptEnd;
            _image.UseLookupTable = false;
            cmd.Run(_image);
            _image.UseLookupTable = true;

            _redData = cmd.RedBuffer;
            _greenData = cmd.GreenBuffer;
            _blueData = cmd.BlueBuffer;

            if (_redData.Length > 350)
               _tbTabs.Maximum = Convert.ToInt32(Math.Floor(_redData.Length / 50.0));
            else
               _tbTabs.Maximum = 0;

            _redPoints = new Point[_redData.Length - _scale];
            _greenPoints = new Point[_greenData.Length - _scale];
            _bluePoints = new Point[_blueData.Length - _scale];

            int x = 0;
            int start = (_scale == 0) ? 0 : _scale;

            if (_isGrayScale == true)
               _div = Convert.ToInt32(Math.Ceiling(Max(_redData) / 250.0));
            else
               _div = 1;

            for (int i = start; i < _redData.Length; i++)
               _redPoints[x] = new Point(x++, _tabRed.Height - _redData[i] / _div);


            x = 0;
            for (int i = start; i < _greenData.Length; i++)
               _greenPoints[x] = new Point(x++, _tabGreen.Height - _greenData[i] / _div);


            x = 0;
            for (int i = start; i < _blueData.Length; i++)
               _bluePoints[x] = new Point(x++, _tabBlue.Height - _blueData[i] / _div);

            if (_redData.Length > 1)
               _firstTime = false;

            _txtPixelNumber.Text = _redData.Length.ToString();
            _txtRedMax.Text = Max(_redData).ToString();
            _txtGreenMax.Text = Max(_greenData).ToString();
            _txtBlueMax.Text = Max(_blueData).ToString();
            _txtRedMin.Text = Min(_redData).ToString();
            _txtGreenMin.Text = Min(_greenData).ToString();
            _txtBlueMin.Text = Min(_blueData).ToString();
         }
         catch (Exception)
         {
         }
      }

      int Max(int[] array)
      {
         int max = array[0];
         for (int i = 1; i < array.Length; i++)
            if (array[i] > max)
               max = array[i];

         return max;
      }

      int Min(int[] array)
      {
         int min = array[0];
         for (int i = 1; i < array.Length; i++)
            if (array[i] < min)
               min = array[i];

         return min;
      }

      private void _tabAll_Paint(object sender, PaintEventArgs e)
      {
         if (!_firstTime && _redPoints.Length > 1)
         {
            if (_cbFillCurve.Checked)
            {
               Point[] redPoints, greenPoints, bluePoints;

               redPoints = new Point[_redData.Length + 2];
               greenPoints = new Point[_greenPoints.Length + 2];
               bluePoints = new Point[_bluePoints.Length + 2];

               FillCurve(redPoints, 0);
               FillCurve(greenPoints, 1);
               FillCurve(bluePoints, 2);

               e.Graphics.FillPolygon(new SolidBrush(Color.Red), redPoints);
               e.Graphics.FillPolygon(new SolidBrush(Color.Green), greenPoints);
               e.Graphics.FillPolygon(new SolidBrush(Color.Blue), bluePoints);
            }
            else
            {
               e.Graphics.DrawCurve(_redPen, _redPoints);
               e.Graphics.DrawCurve(_greenPen, _greenPoints);
               e.Graphics.DrawCurve(_bluePen, _bluePoints);
            }
         }
      }

      private void FillCurve(Point[] array, int index)
      {
         int i;
         switch (index)
         {
            case 0:
               for (i = 0; i < _redPoints.Length; i++)
                  array[i] = new Point(_redPoints[i].X, _redPoints[i].Y);
               array[i++] = new Point(_redPoints.Length, 255);
               array[i] = new Point(0, 255);
               break;

            case 1:
               for (i = 0; i < _greenPoints.Length; i++)
                  array[i] = new Point(_greenPoints[i].X, _greenPoints[i].Y);
               array[i++] = new Point(i - 1, 255);
               array[i] = new Point(0, 255);
               break;

            case 2:
               for (i = 0; i < _bluePoints.Length; i++)
                  array[i] = new Point(_bluePoints[i].X, _bluePoints[i].Y);
               array[i++] = new Point(i - 1, 255);
               array[i] = new Point(0, 255);
               break;
         }
      }

      private void _tabRed_Paint(object sender, PaintEventArgs e)
      {
         if (!_firstTime && _redPoints.Length > 1)
            if (_cbFillCurve.Checked)
            {
               Point[] redPoints;
               redPoints = new Point[_redPoints.Length + 2];
               FillCurve(redPoints, 0);
               e.Graphics.FillPolygon(new SolidBrush(Color.Red), redPoints);
            }
            else
            {
               e.Graphics.DrawCurve(_redPen, _redPoints);
            }
      }

      private void _tabGreen_Paint(object sender, PaintEventArgs e)
      {
         if (!_firstTime && _redPoints.Length > 1)
            if (_cbFillCurve.Checked)
            {
               Point[] greenPoints;
               greenPoints = new Point[_greenPoints.Length + 2];
               FillCurve(greenPoints, 1);
               e.Graphics.FillPolygon(new SolidBrush(Color.Green), greenPoints);
            }
            else
            {
               e.Graphics.DrawCurve(_greenPen, _greenPoints);
            }
      }

      private void _tabBlue_Paint(object sender, PaintEventArgs e)
      {
         if (!_firstTime && _redPoints.Length > 1)
            if (_cbFillCurve.Checked)
            {
               Point[] bluePoints;
               bluePoints = new Point[_bluePoints.Length + 2];
               FillCurve(bluePoints, 2);
               e.Graphics.FillPolygon(new SolidBrush(Color.Blue), bluePoints);
            }
            else
            {
               e.Graphics.DrawCurve(_bluePen, _bluePoints);
            }
      }

      private void _tab_MouseMove(object sender, MouseEventArgs e)
      {
         try
         {
            if (_firstTime || e.X >= _redData.Length)
               return;

            LeadPoint start, end;
            if (_ptStart.X <= _ptEnd.X)
            {
               start = _ptStart;
               end = _ptEnd;
            }
            else
            {
               start = _ptEnd;
               end = _ptStart;
            }

            double dx = Math.Abs((end.X - start.X) * 1.0 / _redData.Length);
            double dy = Math.Abs((end.Y - start.Y) * 1.0 / _redData.Length);

            _txtXPixel.Text = Convert.ToInt32((e.X + _scale) * dx).ToString();
            _txtYPixel.Text = Convert.ToInt32((e.X + _scale) * dy).ToString();

            _txtRed.Text = _redData[e.X].ToString();
            _txtGreen.Text = _greenData[e.X].ToString();
            _txtBlue.Text = _blueData[e.X].ToString();
         }
         catch (Exception)
         {
         }
      }

      private void _tbTabs_Scroll(object sender, EventArgs e)
      {
         try
         {
            _scale = _tbTabs.Value * 50;
            ApplyLineHistogram();
            _tabs.Refresh();
            //_viewer.Invalidate();
         }
         catch (Exception)
         {
         }
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         Close();
      }

      void _viewer_MouseMove(object sender, MouseEventArgs e)
      {
         LeadPoint tmpPnt = _viewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, LeadPoint.Create(e.X, e.Y));
         if (_pressed)
         {
            switch (_button)
            {
               case downButtonPosition.END_RECT:
               case downButtonPosition.NONE:
                  _xEnd = tmpPnt.X;
                  _yEnd = tmpPnt.Y;
                  _numXEnd.Text = _xEnd.ToString();
                  _numYEnd.Text = _yEnd.ToString();
                  if (_cbMovable.Checked)
                     _endRect = new Rectangle(_ptEnd.X - 10, _ptEnd.Y - 10, 20, 20);
                  if (_cbMovable.Checked && _button == downButtonPosition.NONE)
                     _startRect = new Rectangle(_ptStart.X - 10, _ptStart.Y - 10, 20, 20);
                  break;
               case downButtonPosition.START_RECT:
                  _xStart = tmpPnt.X;
                  _yStart = tmpPnt.Y;
                  _numXStart.Text = _xStart.ToString();
                  _numYStart.Text = _yStart.ToString();
                  if (_cbMovable.Checked)
                     _startRect = new Rectangle(_ptStart.X - 10, _ptStart.Y - 10, 20, 20);
                  break;
            }
            _viewer.Invalidate();
         }
         _yCursorPosition.Text = tmpPnt.Y.ToString();
         _xCursorPosition.Text = tmpPnt.X.ToString();
      }

      void _viewer_MouseDown(object sender, MouseEventArgs e)
      {
         Point point = _viewer.PointToScreen(new Point(0, 0));
         Cursor.Clip = new Rectangle(point.X + Math.Max(0, _viewer.ViewBounds.Left), point.Y + Math.Max(0, _viewer.ViewBounds.Top), _viewer.ViewBounds.Width, _viewer.ViewBounds.Height);
         if (e.Button == MouseButtons.Left)
         {
            LeadPoint tmpPnt = _viewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, LeadPoint.Create(e.X, e.Y));
            _pressed = true;

            if (_cbMovable.Checked)
            {
               if (_startRect.Contains(tmpPnt.X, tmpPnt.Y))
                  _button = downButtonPosition.START_RECT;
               else if (_endRect.Contains(tmpPnt.X, tmpPnt.Y))
                  _button = downButtonPosition.END_RECT;
               else
               {
                  _button = downButtonPosition.NONE;
                  _xEnd = _xStart = tmpPnt.X;
                  _yEnd = _yStart = tmpPnt.Y;
                  _numXStart.Text = _xStart.ToString();
                  _numYStart.Text = _yStart.ToString();
                  _startRect = new Rectangle(_ptStart.X - 10, _ptStart.Y - 10, 20, 20);
                  _endRect = new Rectangle(_ptEnd.X - 10, _ptEnd.Y - 10, 20, 20);
               }
            }
            else
            {
               _xEnd = _xStart = tmpPnt.X;
               _yEnd = _yStart = tmpPnt.Y;
               _numXStart.Text = _xStart.ToString();
               _numYStart.Text = _yStart.ToString();
            }
         }
      }

      void _viewer_PostRender(object sender, ImageViewerRenderEventArgs args)
      {
         LeadPoint firstPoint = _viewer.ConvertPoint(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, LeadPoint.Create(_xStart, _yStart));
         LeadPoint endPoint = _viewer.ConvertPoint(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, LeadPoint.Create(_xEnd, _yEnd));
         float[] dashValuesWhite = { 4, 4, 4, 4 };
         Pen penBlack = new Pen(Color.Black, 1);
         Pen penWhite = new Pen(Color.White, 1);
         PaintEventArgs e = args.PaintEventArgs;
         penWhite.DashPattern = dashValuesWhite;
         
         e.Graphics.DrawLine(penBlack, firstPoint.X, firstPoint.Y, endPoint.X, endPoint.Y);
         e.Graphics.DrawLine(penWhite, firstPoint.X, firstPoint.Y, endPoint.X, endPoint.Y);
         LeadRect startRect = _viewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, LeadRect.Create(_startRect.X, _startRect.Y, _startRect.Width, _startRect.Height));
         LeadRect endRect = _viewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, LeadRect.Create(_endRect.X, _endRect.Y, _endRect.Width, _endRect.Height));
         if (_cbMovable.Checked)
         {
            e.Graphics.DrawRectangle(penBlack, startRect.X, startRect.Y, startRect.Width, startRect.Height);
            e.Graphics.DrawRectangle(penWhite, startRect.X, startRect.Y, startRect.Width, startRect.Height);
            e.Graphics.DrawRectangle(penBlack, endRect.X, endRect.Y, endRect.Width, endRect.Height);
            e.Graphics.DrawRectangle(penWhite, endRect.X, endRect.Y, endRect.Width, endRect.Height);
         }
      }

      void _viewer_MouseUp(object sender, MouseEventArgs e)
      {
         Cursor.Clip = Rectangle.Empty;

         if (e.Button == MouseButtons.Left)
         {
            LeadPoint tmpPnt = _viewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, LeadPoint.Create(e.X, e.Y));
            _pressed = false;

            switch (_button)
            {
               case downButtonPosition.END_RECT:
               case downButtonPosition.NONE:
                  _xEnd = tmpPnt.X;
                  _yEnd = tmpPnt.Y;
                  _numXEnd.Text = _xEnd.ToString();
                  _numYEnd.Text = _yEnd.ToString();
                  break;
               case downButtonPosition.START_RECT:
                  _xStart = tmpPnt.X;
                  _yStart = tmpPnt.Y;
                  _numXStart.Text = _xStart.ToString();
                  _numYStart.Text = _yStart.ToString();
                  break;
            }
            if (_cbMovable.Checked)
            {
               _startRect = new Rectangle(_ptStart.X - 10, _ptStart.Y - 10, 20, 20);
               _endRect = new Rectangle(_ptEnd.X - 10, _ptEnd.Y - 10, 20, 20);
            }
         }
      }

      private void LineHistogramDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         _viewer.MouseMove -= new MouseEventHandler(_viewer_MouseMove);
         _viewer.MouseDown -= new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseUp -= new MouseEventHandler(_viewer_MouseUp);
         _viewer.PostRender -= new EventHandler<ImageViewerRenderEventArgs>(_viewer_PostRender);

         _viewer.Invalidate();

         _viewer.MouseUp += new System.Windows.Forms.MouseEventHandler(_form.Viewer_MouseUp);
         _viewer.MouseDown += new System.Windows.Forms.MouseEventHandler(_form.Viewer_MouseDown);
         _viewer.MouseMove += new System.Windows.Forms.MouseEventHandler(_form.Viewer_MouseMove);
         _viewer.MouseWheel += new System.Windows.Forms.MouseEventHandler(_form.Viewer_MouseWheel);
         _viewer.Paint += new PaintEventHandler(_form._viewer_Paint);
      }

      private void _numXStart_ValueChanged(object sender, EventArgs e)
      {
         try
         {
            _xStart = int.Parse(_numXStart.Text);

            ApplyLineHistogram();
            _tabs.Refresh();
            _viewer.Invalidate();
         }
         catch (Exception)
         {
         }
      }

      private void _numYStart_ValueChanged(object sender, EventArgs e)
      {
         try
         {
            _yStart = int.Parse(_numYStart.Text);

            ApplyLineHistogram();
            _tabs.Refresh();
            _viewer.Invalidate();
         }
         catch (Exception)
         {
         }
      }

      private void _numXEnd_ValueChanged(object sender, EventArgs e)
      {
         try
         {
            _xEnd = int.Parse(_numXEnd.Text);

            ApplyLineHistogram();
            _tabs.Refresh();
            _viewer.Invalidate();
         }
         catch (Exception)
         {
         }
      }

      private void _numYEnd_ValueChanged(object sender, EventArgs e)
      {
         try
         {
            _yEnd = int.Parse(_numYEnd.Text);

            ApplyLineHistogram();
            _tabs.Refresh();
            _viewer.Invalidate();
         }
         catch (Exception)
         {
         }
      }

      private void _cbFillCurve_CheckedChanged(object sender, EventArgs e)
      {
         ApplyLineHistogram();
         _tabs.Refresh();
         _viewer.Invalidate();
      }

      private void _cbMovable_CheckedChanged(object sender, EventArgs e)
      {
         _startRect = new Rectangle(_ptStart.X - 10, _ptStart.Y - 10, 20, 20);
         _endRect = new Rectangle(_ptEnd.X - 10, _ptEnd.Y - 10, 20, 20);
         ApplyLineHistogram();
         _tabs.Refresh();
         _viewer.Invalidate();
      }
   }
}
