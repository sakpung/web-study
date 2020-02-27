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
   public partial class PerspectiveDialog : Form
   {
      private ImageViewer _viewer;
      private OcrDemo.ViewerControl.ViewerControl _form;
      private MainForm _mainForm;
      private List<Point> _polyPoints;
      private Point _lastPoint;
      private Point _currentMousePoint;
      private bool _firstPointSelected;
      private bool _drawing;
      private bool _applied;
      public bool OkButtonPressed = false;
      private int _movingPntIdx;
      private RasterImage _orgImage;
      private bool _manualPerspectiveDeskew;

      public PerspectiveDialog(MainForm form, OcrDemo.ViewerControl.ViewerControl viewer, bool manualPerspectiveDeskew)
      {
         _mainForm = form;
         _form = viewer;
         _viewer = viewer.ImageViewer;
         _manualPerspectiveDeskew = manualPerspectiveDeskew;
         InitializeComponent();
      }

      private void PerspectiveDialog_Load(object sender, EventArgs e)
      {
         _viewer.PostRender += new EventHandler<ImageViewerRenderEventArgs>(_viewer_PostRender);
         _viewer.MouseMove += new MouseEventHandler(_viewer_MouseMove);
         _viewer.MouseDown += new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseUp += new MouseEventHandler(_viewer_MouseUp);
         _polyPoints = new List<Point>();
         _firstPointSelected = false;
         _drawing = true;
         _applied = false;
         _movingPntIdx = -1;
         _orgImage = _viewer.Image.Clone();
         _btnApply.Enabled = false;
         _btnReset.Enabled = false;

         if (_manualPerspectiveDeskew)
         {
            _polyPoints.Add(new Point(5, 10));
            _polyPoints.Add(new Point(_viewer.Image.ImageWidth - 10, 10));
            _polyPoints.Add(new Point(_viewer.Image.ImageWidth - 5, _viewer.Image.ImageHeight - 10));
            _polyPoints.Add(new Point(0, _viewer.Image.ImageHeight - 10));
            UpdateDialogPoints(0, _polyPoints[0]);
            UpdateDialogPoints(1, _polyPoints[1]);
            UpdateDialogPoints(2, _polyPoints[2]);
            UpdateDialogPoints(3, _polyPoints[3]);

            _firstPointSelected = true;
            _lastPoint = _polyPoints[3];
            _drawing = false;
            _viewer.Invalidate();
            _btnApply.Enabled = true;

            this.Text = "Manual Perspective";
         }
         else
            this.Text = "Inverse Perspective";

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
                  Rectangle[] hyberAreas = new Rectangle[_polyPoints.Count];
                  for (int idx = 0; idx < hyberAreas.Length; idx++)
                  {
                     hyberAreas[idx] = CreateRectFromPoint(_polyPoints[idx], 15);
                     if (hyberAreas[idx].Contains(pnt))
                     {
                        _movingPntIdx = idx;
                        break;
                     }
                  }
               }

               if (_movingPntIdx == -1)
               {
                  if (_polyPoints.Count < 4)
                  {
                     if (pnt.Equals(_lastPoint))
                        return;
                     _firstPointSelected = true;
                     _polyPoints.Add(pnt);
                     _currentMousePoint = pnt;
                     UpdateDialogPoints(_polyPoints.Count - 1, pnt);
                     _lastPoint = pnt;
                  }

                  if (_polyPoints.Count == 4)
                  {
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
            //_viewer.Cursor = Cursors.Cross;

            if (_firstPointSelected)
            {
               _currentMousePoint = pnt;
            }

            if (_movingPntIdx != -1)
            {
               if (pnt.X < 0) pnt.X = 0;
               if (pnt.X > _viewer.Image.ImageWidth - 1) pnt.X = _viewer.Image.ImageWidth - 1;
               if (pnt.Y < 0) pnt.Y = 0;
               if (pnt.Y > _viewer.Image.ImageHeight - 1) pnt.Y = _viewer.Image.ImageHeight - 1;

               _polyPoints.RemoveAt(_movingPntIdx);
               _polyPoints.Insert(_movingPntIdx, pnt);
               UpdateDialogPoints(_movingPntIdx, pnt);
            }
            _viewer.Invalidate();
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

            Point[] drawPoints = new Point[_polyPoints.Count];

            for (int idx = 0; idx < drawPoints.Length; idx++)
            {
               LeadPointD TempPoint = new LeadPointD(_polyPoints[idx].X, _polyPoints[idx].Y);
               TempPoint = _viewer.ImageTransform.Transform(TempPoint);
               drawPoints[idx] = new Point((int)TempPoint.X, (int)TempPoint.Y);
            }

            LeadPointD lastPointTemp = new LeadPointD(_lastPoint.X, _lastPoint.Y);
            lastPointTemp = _viewer.ImageTransform.Transform(lastPointTemp);
            Point lastPoint = new Point((int)lastPointTemp.X, (int)lastPointTemp.Y);
            LeadPointD currentMousePointTemp = new LeadPointD(_currentMousePoint.X, _currentMousePoint.Y);
            currentMousePointTemp = _viewer.ImageTransform.Transform(currentMousePointTemp);
            Point currentMousePoint = new Point((int)currentMousePointTemp.X, (int)currentMousePointTemp.Y);

            const int controlPointSize = 5;
            e.PaintEventArgs.Graphics.FillRectangle(Brushes.Red, CreateRectFromPoint(drawPoints[0], controlPointSize));
            for (int i = 1; i < drawPoints.Length; i++)
            {
               Point prev = drawPoints[i - 1];
               Point curnt = drawPoints[i];
               e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, prev, curnt);
               if (!_drawing)
               {
                  e.PaintEventArgs.Graphics.DrawLine(Pens.Yellow, drawPoints[0], drawPoints[drawPoints.Length - 1]);
               }

               e.PaintEventArgs.Graphics.FillRectangle(Brushes.Red, CreateRectFromPoint(prev, controlPointSize));
               e.PaintEventArgs.Graphics.FillRectangle(Brushes.Red, CreateRectFromPoint(curnt, controlPointSize));
            }

            e.PaintEventArgs.Graphics.FillRectangle(Brushes.Red, CreateRectFromPoint(drawPoints[0], controlPointSize));

            if (_drawing && drawPoints.Length < 4)
               e.PaintEventArgs.Graphics.DrawLine(Pens.Red, lastPoint, currentMousePoint);
         }
      }

      private void ApplyFilter()
      {
         using (WaitCursor wait = new WaitCursor())
         {
            if (_polyPoints.Count == 4 && _firstPointSelected)
            {
               _applied = true;
               LeadPoint[] PolyPoints = new LeadPoint[4];
               for (int i = 0; i < 4; i++)
               {
                  PolyPoints[i].X = _polyPoints[i].X;
                  PolyPoints[i].Y = _polyPoints[i].Y;
               }

               _viewer.Image.MakeRegionEmpty();

               RasterCommand command = null;
               if (!_manualPerspectiveDeskew)
               {
                  command = new KeyStoneCommand(PolyPoints);
               }
               else
               {
                  LeadPoint[] inputPoints = 
               {
                  new LeadPoint(0, 0),
                  new LeadPoint(_viewer.Image.ImageWidth, 0),
                  new LeadPoint(_viewer.Image.ImageWidth, _viewer.Image.ImageHeight),
                  new LeadPoint(0, _viewer.Image.ImageHeight),
               };

                  command = new ManualPerspectiveDeskewCommand(inputPoints, PolyPoints);
               }

               try
               {
                  command.Run(_viewer.Image);
               }
               catch (System.Exception ex)
               {
                  Messager.ShowError(this, ex);
                  return;
               }

               //_viewer.Cursor = Cursors.Default;
               if (command.GetType() == typeof(KeyStoneCommand))
               {
                  KeyStoneCommand cmd = command as KeyStoneCommand;
                  if (cmd.TransformedImage != null)
                  {
                     _viewer.Image = cmd.TransformedImage.Clone();
                  }
               }
               else
               {
                  // ManualPerspectiveDeskewCommand
                  ManualPerspectiveDeskewCommand cmd = command as ManualPerspectiveDeskewCommand;
                  if (cmd.OutputImage != null)
                  {
                     _viewer.Image = cmd.OutputImage.Clone();
                  }
               }

               if (_manualPerspectiveDeskew)
                  DoAction("ManualPerspectiveCommand", this);
               else
                  DoAction("InversePerspectiveCommand", this);

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
         MainForm.PerspectiveDeskewActive = false;
         ApplyFilter();
         this.Close();
      }

      private void PerspectiveDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         _viewer.PostRender -= new EventHandler<ImageViewerRenderEventArgs>(_viewer_PostRender);
         _viewer.MouseMove -= new MouseEventHandler(_viewer_MouseMove);
         _viewer.MouseDown -= new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseUp -= new MouseEventHandler(_viewer_MouseUp);
         //_viewer.Cursor = Cursors.Default;
         _viewer.Invalidate();
         _form.Invalidate();

         MainForm.PerspectiveDeskewActive = false;
         if (_manualPerspectiveDeskew)
            DoAction("ManualPerspectiveCommand", this);
         else
            DoAction("InversePerspectiveCommand", this);
      }

      private void _btnReset_Click(object sender, EventArgs e)
      {
         if (!_firstPointSelected && _polyPoints.Count == 4)
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
