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

using Leadtools.Demos;
using Leadtools;
using Leadtools.ImageProcessing.Core;
using Leadtools.Controls;
using Leadtools.ImageProcessing;

namespace OcrDemo
{
   public partial class UnWarpDialog : Form
   {
      private ImageViewer _viewer;
      private OcrDemo.ViewerControl.ViewerControl _form;
      private List<Point> _unWarpPoints;
      private Point _lastPoint;
      private Point _currentMousePoint;
      private bool _firstPointSelected;
      private bool _drawing;
      private bool _applied;
      public bool OkButtonPressed = false;
      private int _movingPntIdx;
      private LeadPoint[] _upperCurvePath = null;
      private LeadPoint[] _lowerCurvePath = null;
      private RasterImage _orgImage;

      public UnWarpDialog(MainForm form, OcrDemo.ViewerControl.ViewerControl viewer)
      {
         _form = viewer;
         _viewer = viewer.ImageViewer;
         InitializeComponent();
      }

      private void UnWarpDialog_Load(object sender, EventArgs e)
      {
         _viewer.PostRender += new EventHandler<ImageViewerRenderEventArgs>(_viewer_PostRender);
         _viewer.MouseMove += new MouseEventHandler(_viewer_MouseMove);
         _viewer.MouseDown += new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseUp += new MouseEventHandler(_viewer_MouseUp);
         _unWarpPoints = new List<Point>();
         _firstPointSelected = false;
         _drawing = true;
         _applied = false;
         _movingPntIdx = -1;
         _orgImage = _viewer.Image.Clone();
         _btnApply.Enabled = false;
         _btnReset.Enabled = false;

         try
         {
            if (_viewer.Floater != null)
            {
               _viewer.Floater.Dispose();
               _viewer.Floater = null;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private Rectangle CreateRectFromPoint(Point point, int size)
      {
         return new Rectangle(point.X - size, point.Y - size, size * 2, size * 2);
      }

      void _viewer_MouseDown(object sender, MouseEventArgs e)
      {
         LeadPoint pixels = _form.PhysicalToLogical(new LeadPoint(e.X, e.Y));
         LeadRect imageBounds = new LeadRect(0, 0, _viewer.Image.ImageWidth, _viewer.Image.ImageHeight);
         if (imageBounds.Contains(pixels))
         {
            if (e.Button == MouseButtons.Left)
            {
               double xFactor = 1;
               double yFactor = 1;

               int xOffset = 0;
               int yOffset = 0;

               Point pnt = new Point((int)Math.Ceiling(((pixels.X - xOffset) * 1.0 / xFactor + 0.5)), (int)Math.Ceiling(((pixels.Y - yOffset) * 1.0 / yFactor + 0.5)));

               _movingPntIdx = -1;

               if (!_drawing)
               {
                  Rectangle[] hyberAreas = new Rectangle[_unWarpPoints.Count];
                  for (int idx = 0; idx < hyberAreas.Length; idx++)
                  {
                     hyberAreas[idx] = CreateRectFromPoint(_unWarpPoints[idx], 20);
                     if (hyberAreas[idx].Contains(pnt))
                     {
                        _movingPntIdx = idx;
                        break;
                     }
                  }
               }

               if (_movingPntIdx == -1)
               {
                  if (_unWarpPoints.Count < 4)
                  {
                     if (pnt.Equals(_lastPoint))
                        return;
                     _firstPointSelected = true;
                     _unWarpPoints.Add(pnt);
                     _currentMousePoint = pnt;
                     UpdateDialogPoints(_unWarpPoints.Count - 1, pnt);
                     _lastPoint = pnt;
                  }

                  if (_unWarpPoints.Count == 4)
                  {
                     for (int ii = 1; ii <= 2; ii++)
                     {
                        pnt.X = (_unWarpPoints[1].X - _unWarpPoints[0].X) * ii / 3 + _unWarpPoints[0].X;
                        pnt.Y = (_unWarpPoints[1].Y - _unWarpPoints[0].Y) * ii / 3 + _unWarpPoints[0].Y;
                        _currentMousePoint = pnt;
                        _unWarpPoints.Add(pnt);
                        Invalidate();
                        UpdateDialogPoints(_unWarpPoints.Count - 1, pnt);
                     }

                     for (int ii = 1; ii <= 2; ii++)
                     {
                        pnt.X = (_unWarpPoints[2].X - _unWarpPoints[3].X) * ii / 3 + _unWarpPoints[3].X;
                        pnt.Y = (_unWarpPoints[2].Y - _unWarpPoints[3].Y) * ii / 3 + _unWarpPoints[3].Y;
                        _unWarpPoints.Add(pnt);
                        Invalidate();
                        UpdateDialogPoints(_unWarpPoints.Count - 1, pnt);
                     }

                     _drawing = false;
                     _viewer.Invalidate();
                     _btnApply.Enabled = true;
                  }
               }
            }
         }
      }

      void _viewer_MouseMove(object sender, MouseEventArgs e)
      {
         double xFactor = 1 ;
         double yFactor = 1 ;

         int xOffset = 0;
         int yOffset = 0;
         LeadPoint pixels = _form.PhysicalToLogical(new LeadPoint(e.X, e.Y));

         Point pnt = new Point((int)((pixels.X - xOffset) * 1.0 / xFactor + 0.5), (int)((pixels.Y - yOffset) * 1.0 / yFactor + 0.5));
         _txtCursorX.Text = pnt.X.ToString();
         _txtCursorY.Text = pnt.Y.ToString();

         LeadRect imageBounds = new LeadRect(0, 0, _viewer.Image.ImageWidth, _viewer.Image.ImageHeight);
         if (imageBounds.Contains(pixels))
         {
            if (_firstPointSelected)
               _currentMousePoint = pnt;

            if (_movingPntIdx != -1)
            {
               if (pnt.X < 0) pnt.X = 0;
               if (pnt.X > _viewer.Image.ImageWidth - 1) pnt.X = _viewer.Image.ImageWidth - 1;
               if (pnt.Y < 0) pnt.Y = 0;
               if (pnt.Y > _viewer.Image.ImageHeight - 1) pnt.Y = _viewer.Image.ImageHeight - 1;

               _unWarpPoints[_movingPntIdx] = pnt;
               UpdateDialogPoints(_movingPntIdx, pnt);
            }
            _viewer.Invalidate();
         }
      }

      void _viewer_MouseUp(object sender, MouseEventArgs e)
      {
         LeadPoint pixels = _form.PhysicalToLogical(new LeadPoint(e.X, e.Y));
         LeadRect imageBounds = new LeadRect(0, 0, _viewer.Image.ImageWidth, _viewer.Image.ImageHeight);
         if (imageBounds.Contains(pixels))
         {
            if (e.Button == MouseButtons.Left)
            {
               _movingPntIdx = -1;
            }
         }

         if (_unWarpPoints.Count >= 4)
         {
            double xFactor = 1;
            double yFactor = 1;
            int xOffset = 0;
            int yOffset = 0;

            LeadPoint[] inUpperPoints = new LeadPoint[4];
            inUpperPoints[0] = new LeadPoint((int)Math.Ceiling(((_unWarpPoints[0].X - xOffset) * 1.0 / xFactor + 0.5)), (int)Math.Ceiling(((_unWarpPoints[0].Y - yOffset) * 1.0 / yFactor + 0.5)));
            inUpperPoints[1] = new LeadPoint((int)Math.Ceiling(((_unWarpPoints[4].X - xOffset) * 1.0 / xFactor + 0.5)), (int)Math.Ceiling(((_unWarpPoints[4].Y - yOffset) * 1.0 / yFactor + 0.5)));
            inUpperPoints[2] = new LeadPoint((int)Math.Ceiling(((_unWarpPoints[5].X - xOffset) * 1.0 / xFactor + 0.5)), (int)Math.Ceiling(((_unWarpPoints[5].Y - yOffset) * 1.0 / yFactor + 0.5)));
            inUpperPoints[3] = new LeadPoint((int)Math.Ceiling(((_unWarpPoints[1].X - xOffset) * 1.0 / xFactor + 0.5)), (int)Math.Ceiling(((_unWarpPoints[1].Y - yOffset) * 1.0 / yFactor + 0.5)));
            BezierPathCommand cmd = new BezierPathCommand(inUpperPoints);
            cmd.Run(_viewer.Image);
            _upperCurvePath = cmd.PathPoints;

            LeadPoint[] inLowerPoints = new LeadPoint[4];
            inLowerPoints[0] = new LeadPoint((int)Math.Ceiling(((_unWarpPoints[3].X - xOffset) * 1.0 / xFactor + 0.5)), (int)Math.Ceiling(((_unWarpPoints[3].Y - yOffset) * 1.0 / yFactor + 0.5)));
            inLowerPoints[1] = new LeadPoint((int)Math.Ceiling(((_unWarpPoints[6].X - xOffset) * 1.0 / xFactor + 0.5)), (int)Math.Ceiling(((_unWarpPoints[6].Y - yOffset) * 1.0 / yFactor + 0.5)));
            inLowerPoints[2] = new LeadPoint((int)Math.Ceiling(((_unWarpPoints[7].X - xOffset) * 1.0 / xFactor + 0.5)), (int)Math.Ceiling(((_unWarpPoints[7].Y - yOffset) * 1.0 / yFactor + 0.5)));
            inLowerPoints[3] = new LeadPoint((int)Math.Ceiling(((_unWarpPoints[2].X - xOffset) * 1.0 / xFactor + 0.5)), (int)Math.Ceiling(((_unWarpPoints[2].Y - yOffset) * 1.0 / yFactor + 0.5)));
            cmd = new BezierPathCommand(inLowerPoints);
            cmd.Run(_viewer.Image);
            _lowerCurvePath = cmd.PathPoints;

            Invalidate();
         }
      }

      void _viewer_PostRender(object sender, ImageViewerRenderEventArgs e)
      {
         if (_firstPointSelected)
         {
            double xFactor = _viewer.XScaleFactor;
            double yFactor = _viewer.YScaleFactor;
            float xOffset = -_viewer.ImageBounds.Left;
            float yOffset = -_viewer.ImageBounds.Top;

            Point[] drawPoints = new Point[_unWarpPoints.Count];

            for (int idx = 0; idx < drawPoints.Length; idx++)
            {
               LeadPointD TempPoint = new LeadPointD(_unWarpPoints[idx].X, _unWarpPoints[idx].Y);
               TempPoint = _viewer.ImageTransform.Transform(TempPoint);
               drawPoints[idx] = new Point((int)TempPoint.X, (int)TempPoint.Y);
            }

            /************************************************************************/

            const int controlPointSize = 5;
            for (int i = 0; i < drawPoints.Length; i++)
            {
               e.PaintEventArgs.Graphics.FillRectangle(Brushes.Red, CreateRectFromPoint(drawPoints[i], controlPointSize));
            }

            if (drawPoints.Length >= 4)
            {
               _drawing = false;
               Point[] line = new Point[2];

               line[0] = drawPoints[0];
               line[1] = drawPoints[3];
               e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, line[0], line[1]);

               line[0] = drawPoints[1];
               line[1] = drawPoints[2];
               e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, line[0], line[1]);

               if (_upperCurvePath == null || _upperCurvePath.Length == 0)
                  return;

               Point[] curvePoints = new Point[_upperCurvePath.Length];
               for (int j = 0; j < _upperCurvePath.Length; j++)
               {
                  LeadPointD TempPoint = new LeadPointD(_upperCurvePath[j].X, _upperCurvePath[j].Y);
                  TempPoint = _viewer.ImageTransform.Transform(TempPoint);
                  curvePoints[j] = new Point((int)TempPoint.X, (int)TempPoint.Y);
               }
               e.PaintEventArgs.Graphics.DrawCurve(Pens.Yellow, curvePoints);

               if (_lowerCurvePath == null || _lowerCurvePath.Length == 0)
                  return;

               curvePoints = new Point[_lowerCurvePath.Length];
               for (int j = 0; j < _lowerCurvePath.Length; j++)
               {
                  LeadPointD TempPoint = new LeadPointD(_lowerCurvePath[j].X, _lowerCurvePath[j].Y);
                  TempPoint = _viewer.ImageTransform.Transform(TempPoint);
                  curvePoints[j] = new Point((int)TempPoint.X, (int)TempPoint.Y);
               }
               e.PaintEventArgs.Graphics.DrawCurve(Pens.Yellow, curvePoints);
            }
            else
            {
               for (int i = 1; i < drawPoints.Length; i++)
               {
                  Point prev = drawPoints[i-1];
                  Point curnt = drawPoints[i];
                  e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, prev, curnt);
                  if (!_drawing)
                  {
                     e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, drawPoints[0], drawPoints[drawPoints.Length - 1]);
                  }
               }
            }
         }
      }

      private void ApplyFilter()
      {
         using (WaitCursor wait = new WaitCursor())
         {
            if (_unWarpPoints.Count > 4 && _firstPointSelected)
            {
               _applied = true;
               LeadPoint[] UnWarpPoints = new LeadPoint[8];
               for (int i = 0; i < 8; i++)
               {
                  UnWarpPoints[i].X = _unWarpPoints[i].X;
                  UnWarpPoints[i].Y = _unWarpPoints[i].Y;
               }

               _viewer.Image.MakeRegionEmpty();

               UnWarpCommand command = new UnWarpCommand(UnWarpPoints);

               try
               {
                  command.Run(_viewer.Image);
               }
               catch (System.Exception ex)
               {
                  Messager.ShowError(this, ex);
                  return;
               }

               if (command.OutputImage != null)
               {
                  _viewer.Image = command.OutputImage.Clone();
               }

               DoAction("UnWarpCommand", this);

               _viewer.Invalidate();
               _form.Invalidate();
               _firstPointSelected = false;
               _btnReset.Enabled = true;
               _btnApply.Enabled = false;
            }
         }
      }

      private void _bntApply_Click(object sender, EventArgs e)
      {
         ApplyFilter();
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         OkButtonPressed = true;
         MainForm.UnWarpActive = false;
         ApplyFilter();
         this.Close();
      }

      private void UnWarpDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         _viewer.PostRender -= new EventHandler<ImageViewerRenderEventArgs>(_viewer_PostRender);
         _viewer.MouseMove -= new MouseEventHandler(_viewer_MouseMove);
         _viewer.MouseDown -= new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseUp -= new MouseEventHandler(_viewer_MouseUp);
         _viewer.Invalidate();
         _form.Invalidate();

         MainForm.UnWarpActive = false;
         DoAction("UnWarpCommand", this);
      }

      private void _btnReset_Click(object sender, EventArgs e)
      {
         if (!_firstPointSelected && _unWarpPoints.Count > 4)
         {
            _firstPointSelected = true;
            _viewer.Image = _orgImage.Clone();
            _btnApply.Enabled = true;
            _btnReset.Enabled = false;
         }
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         if (_applied)
         {
            _viewer.Image = _orgImage.Clone();
         }
         this.Close();
      }

      private void UpdateDialogPoints(int pointIndex, Point pt)
      {
         switch (pointIndex)
         {
            case 0:
               _numFirstPtX.Text = pt.X.ToString();
               _numFirstPtY.Text = pt.Y.ToString();
               break;
            case 1:
               _numSecondPtX.Text = pt.X.ToString();
               _numSecondPtY.Text = pt.Y.ToString();
               break;
            case 2:
               _numThirdPtX.Text = pt.X.ToString();
               _numThirdPtY.Text = pt.Y.ToString();
               break;
            case 3:
               _numFourthPtX.Text = pt.X.ToString();
               _numFourthPtY.Text = pt.Y.ToString();
               break;
         }
      }

      /// <summary>
      /// Any action that happens in this control that must be handled by the owner
      /// </summary>
      public event EventHandler<ActionEventArgs> Action;

      private void DoAction(string action, object data)
      {
         // Raise the action event so the main form can handle it

         if (Action != null)
            Action(this, new ActionEventArgs(action, data));
      }
   }
}
