// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Leadtools.Demos;
using Leadtools;
using Leadtools.ImageProcessing.Core;
using Leadtools.ImageProcessing;
using Leadtools.Controls;

namespace GrayScaleDemo
{
   public partial class WatershedDialog : Form
   {
      private ImageViewer _viewer;
      private ViewerForm _form;
      private MainForm _mainForm;
      private List<int> _lengths;
      private List<List<Point>> _points;
      private List<Point> _currentSegment;
      private int _segIndex;
      private bool _drawing;
      private RasterImage _maskImage;
      private RasterImage _orgImage;

      public WatershedDialog(MainForm form, ViewerForm viewer)
      {
         _mainForm = form;
         _form = viewer;
         _viewer = viewer.Viewer;

         InitializeComponent();
      }

      private void WatershedDialog_Load(object sender, EventArgs e)
      {
         _viewer.PostRender += new EventHandler<ImageViewerRenderEventArgs>(_viewer_Paint);
         _viewer.MouseDown += new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseUp += new MouseEventHandler(_viewer_MouseUp);
         _viewer.MouseMove += new MouseEventHandler(_viewer_MouseMove);
         _form.FormClosing += new FormClosingEventHandler(_form_FormClosing);

         _maskImage = new RasterImage(_viewer.Image);
         FillCommand command = new FillCommand(RasterColor.White);
         command.Run(_maskImage);

         _orgImage = _viewer.Image.Clone();

         _lengths = new List<int>();
         _points = new List<List<Point>>();
         _currentSegment = new List<Point>();

         _segIndex = -1;
         _drawing = false;

         _viewer.Cursor = Cursors.Cross;
      }

      void _form_FormClosing(object sender, FormClosingEventArgs e)
      {
         this.Close();
      }

      void _viewer_MouseMove(object sender, MouseEventArgs e)
      {
         if (_viewer.ViewBounds.Contains(LeadPoint.Create(e.X, e.Y)))
         {
            if (_drawing)
            {
               _currentSegment.Add(new Point(e.X, e.Y));
               _viewer.Invalidate();
            }
         }
      }

      void _viewer_MouseUp(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            _drawing = false;
            List<Point> lst = new List<Point>(_currentSegment);
            _points.Add(lst);
            _currentSegment.Clear();
            ApplyWatershed();
         }
      }

      void _viewer_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            _drawing = true;
            _segIndex++;
            _viewer.Image = _orgImage.Clone();
            _viewer.Invalidate();
         }
      }

      void _viewer_Paint(object sender, ImageViewerRenderEventArgs e)
      {
         if (_currentSegment.Count >= 2)
            e.PaintEventArgs.Graphics.DrawLines(Pens.Yellow, _currentSegment.ToArray());

         foreach (List<Point> pnts in _points)
         {
            if (pnts.Count >= 2)
               e.PaintEventArgs.Graphics.DrawLines(Pens.Yellow, pnts.ToArray());
         }
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         _viewer.Image = _orgImage.Clone();
         _orgImage.Dispose();
         this.Close();
      }

      private void WatershedDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         _viewer.PostRender -= _viewer_Paint;
         _viewer.MouseMove -= new MouseEventHandler(_viewer_MouseMove);
         _viewer.MouseDown -= new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseUp -= new MouseEventHandler(_viewer_MouseUp);
         _viewer.Cursor = Cursors.Default;
         _viewer.Invalidate();

         _mainForm.IsSegmentation = false;
         _mainForm.UpdateMyControls();
      }

      private void _btnReset_Click(object sender, EventArgs e)
      {
         _points.Clear();
         _currentSegment.Clear();
         _viewer.Image = _orgImage.Clone();
         _viewer.Invalidate();
      }

      private void ApplyWatershed()
      {
         if (_points.Count > 0)
         {
            _viewer.Image = _orgImage.Clone();

            WatershedCommand command = new WatershedCommand();

            LeadPoint[][] points = new LeadPoint[_points.Count][];

            double xFactor = _viewer.XScaleFactor;
            double yFactor = _viewer.YScaleFactor;

            int xOffset = _viewer.ViewBounds.Left;
            int yOffset = _viewer.ViewBounds.Top;

            for (int idx = 0; idx < points.Length; idx++)
            {
               points[idx] = new LeadPoint[_points.ToArray()[idx].ToArray().Length];

               for (int idx2 = 0; idx2 < points[idx].Length; idx2++)
               {
                  points[idx][idx2].X = (int)((_points.ToArray()[idx].ToArray()[idx2].X - xOffset) * 1.0 / xFactor + 0.5);
                  points[idx][idx2].Y = (int)((_points.ToArray()[idx].ToArray()[idx2].Y - yOffset) * 1.0 / yFactor + 0.5);
               }
            }

            command.PointsArray = points;

            command.Run(_viewer.Image);
            _viewer.Invalidate();
         }
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         ApplyWatershed();
         (_mainForm.ActiveMdiChild as ViewerForm).addToImageList();
         (_mainForm.ActiveMdiChild as ViewerForm).UpdateAfterCommandExecution();
         this.Close();
      }
   }
}
