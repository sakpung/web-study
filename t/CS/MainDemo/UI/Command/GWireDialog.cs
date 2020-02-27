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

namespace MainDemo
{
   public partial class GWireDialog : Form
   {
      private ImageViewer _viewer;
      private ViewerForm _form;
      private MainForm _mainForm;

      private GWireCommand _gwireCommand;
      private bool _gwireStarted;
      private bool _gwireSeedSelected;
      private bool _gwireNewSeed;
      private Point[] _gwirePath;
      private List<Point> _gwirePrevPath;

      private List<Point> _anchorPoints;

      public GWireDialog(ViewerForm viewer, MainForm mainForm)
      {
         _form = viewer;
         _viewer = viewer.Viewer;
         _mainForm = mainForm;
         _form.FormClosing += new FormClosingEventHandler(_form_FormClosing);

         InitializeComponent();
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         FinishGWire();
         this.Close();
      }

      private void _bntApply_Click(object sender, EventArgs e)
      {
         StartGWire((int)_numExternal.Value);
      }

      public void StartGWire(int ExternalEnergy)
      {
         if (_gwireCommand != null)
            return;

         RasterImage image = _viewer.Image;

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
         finally
         {
            _mainForm.UpdateControls();
         }

         if (image.HasRegion)
            image.SetRegion(null, null, RasterRegionCombineMode.Set);

         if (image.ViewPerspective != RasterViewPerspective.TopLeft)
            image.ChangeViewPerspective(RasterViewPerspective.TopLeft);
         _gwireCommand = new GWireCommand(image, ExternalEnergy);
         _gwirePrevPath = new List<Point>();
         _anchorPoints = new List<Point>();

         _viewer.MouseDown += new MouseEventHandler(ActiveViewerForm_MouseDown);
         _viewer.MouseMove += new MouseEventHandler(ActiveViewerForm_MouseMove);
         _viewer.PostRender += new EventHandler<ImageViewerRenderEventArgs>(ActiveViewerForm_Paint);

         _gwireStarted = true;
         _gwireSeedSelected = _gwireNewSeed = false;
      }

      void _form_FormClosing(object sender, FormClosingEventArgs e)
      {
         this.Close();
      }

      private Rectangle CreateRectangleFromPoint(Point point)
      {
         int size = 3;
         return new Rectangle(point.X - size, point.Y - size, size * 2, size * 2);
      }

      void ActiveViewerForm_Paint(object sender, ImageViewerRenderEventArgs e)
      {
         if (_gwireCommand != null)
         {
            if (_gwireStarted)
            {
               if (_gwirePath != null && _anchorPoints != null)
               {
                  double xFactor = _viewer.XScaleFactor;
                  double yFactor = _viewer.YScaleFactor;
                  float xOffset = -_viewer.ImageBounds.Left;
                  float yOffset = -_viewer.ImageBounds.Top;

                  try
                  {
                     if (_gwirePath.Length > 1)
                     {
                        Point[] currentPath = (Point[])_gwirePath.Clone();
                        for (int idx = 0; idx < currentPath.Length; idx++)
                        {
                           currentPath[idx].X = (int)(xFactor * (currentPath[idx].X + xOffset) + 0.5);
                           currentPath[idx].Y = (int)(yFactor * (currentPath[idx].Y + yOffset) + 0.5);
                        }
                        e.PaintEventArgs.Graphics.DrawLines(Pens.Yellow, currentPath);
                     }
                     if (_gwirePrevPath != null)
                     {
                        if (_gwirePrevPath.Count > 1)
                        {
                           Point[] oldPath = _gwirePrevPath.ToArray();
                           for (int idx = 0; idx < oldPath.Length; idx++)
                           {
                              oldPath[idx].X = (int)(xFactor * (oldPath[idx].X + xOffset) + 0.5);
                              oldPath[idx].Y = (int)(yFactor * (oldPath[idx].Y + yOffset) + 0.5);
                           }
                           e.PaintEventArgs.Graphics.DrawLines(Pens.Yellow, oldPath);
                        }
                     }

                     for (int i = 0; i < _anchorPoints.Count; i++)
                     {
                         e.PaintEventArgs.Graphics.FillEllipse(Brushes.Yellow, CreateRectangleFromPoint(new Point((int)((_anchorPoints[i].X + xOffset) * xFactor + 0.5), (int)((_anchorPoints[i].Y + yOffset) * yFactor + 0.5))));
                     }
                  }
                  catch (System.Exception ex)
                  {
                     Messager.ShowError(null, ex);
                  }
               }
            }
         }
      }

      void ActiveViewerForm_MouseMove(object sender, MouseEventArgs e)
      {
         if (_gwireCommand != null)
         {
            _viewer.Cursor = Cursors.Cross;
            if (_gwireStarted)
            {

               if (_gwireSeedSelected && _viewer.ViewBounds.Contains(LeadPoint.Create(e.Location.X, e.Location.Y)))
               {
                  double xFactor = _viewer.XScaleFactor;
                  double yFactor = _viewer.YScaleFactor;

                  int xOffset = _viewer.ViewBounds.Left;
                  int yOffset = _viewer.ViewBounds.Top;

                  LeadPoint[] GWirePath = _gwireCommand.GetMinPath(new LeadPoint((int)((e.X - xOffset) * 1.0 / xFactor + 0.5), (int)((e.Y - yOffset) * 1.0 / yFactor + 0.5)));

                  if (GWirePath != null)
                  {
                     if (_gwireNewSeed)
                     {
                        if (_gwirePath != null)
                        {
                           _gwirePrevPath.AddRange(_gwirePath);
                           _gwireNewSeed = false;
                        }
                     }

                     _gwirePath = new Point[GWirePath.Length];

                     for (int i = 0; i < GWirePath.Length; i++)
                     {
                        _gwirePath[i].X = GWirePath[i].X;
                        _gwirePath[i].Y = GWirePath[i].Y;
                     }

                     _viewer.Invalidate();
                  }
               }
            }
         }
      }

      public void FinishGWire()
      {
         if (_gwireCommand == null)
            return;

         if (_gwirePath != null && _gwirePrevPath != null)
         {
            int prevPathLength = _gwirePrevPath.Count;
            int curPathLength = _gwirePath.Length;

            List<LeadPoint> pts = new List<LeadPoint>();
            for (int i = 0; i < prevPathLength; i++)
            {
               pts.Add(new LeadPoint(_gwirePrevPath[i].X, _gwirePrevPath[i].Y));
            }
            for (int i = 0; i < curPathLength; i++)
            {
               pts.Add(new LeadPoint(_gwirePath[i].X, _gwirePath[i].Y));
            }

            _viewer.Image.AddPolygonToRegion(null, pts.ToArray(), LeadFillMode.Alternate, RasterRegionCombineMode.Set);
            _viewer.ActiveItem.ImageRegionToFloater();
            _viewer.Image.SetRegion(null, null, RasterRegionCombineMode.Set);
            _mainForm.DisableAllInteractiveModes(_viewer);
            _viewer.InteractiveModes.BeginUpdate(); 
            _form.FloaterInteractiveMode.IsEnabled = true;
            _viewer.FloaterOpacity = 1.0;
            _viewer.InteractiveModes.EndUpdate(); 
         }

         _viewer.MouseDown -= ActiveViewerForm_MouseDown;
         _viewer.MouseMove -= ActiveViewerForm_MouseMove;
         _viewer.PostRender -= ActiveViewerForm_Paint;
         _viewer.Cursor = Cursors.Default;
         _gwireCommand.Dispose();
         _gwireCommand = null;
         _gwireSeedSelected = _gwireStarted = _gwireNewSeed = false;
         _gwirePrevPath = null;
         _gwirePath = null;

         _viewer.Invalidate();
      }

      void ActiveViewerForm_MouseDown(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            if (_gwireCommand != null)
            {
               if (_gwireStarted)
               {
                  if (_viewer.ViewBounds.Contains(LeadPoint.Create(e.Location.X, e.Location.Y)))
                  {
                     double xFactor = _viewer.XScaleFactor;
                     double yFactor = _viewer.YScaleFactor;

                     int xOffset = _viewer.ViewBounds.Left;
                     int yOffset = _viewer.ViewBounds.Top;
                     int x = (int)((e.X - xOffset) * 1.0f / xFactor + 0.5);
                     int y = (int)((e.Y - yOffset) * 1.0f / yFactor + 0.5);
                     if (!_gwireSeedSelected)
                     {
                        _gwireCommand.SetSeedPoint(new LeadPoint(x, y));
                        Application.DoEvents();

                        _gwireSeedSelected = true;
                        _gwireNewSeed = false;
                        _anchorPoints.Add(new Point(x, y));
                     }
                     else
                     {
                        _gwireCommand.SetSeedPoint(new LeadPoint(x, y));
                        _gwireNewSeed = true;
                        _anchorPoints.Add(new Point(x, y));
                        Rectangle rect = CreateRectangleFromPoint(new Point(x, y));
                        if (rect.Contains(_anchorPoints[0]))
                           FinishGWire();
                     }
                  }
               }
            }
         }
         else if (e.Button == MouseButtons.Right)
         {
            FinishGWire();
         }
      }

      private void GWireDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         _mainForm.InteractiveToolsList.Remove(_viewer);
      }
   }
}
