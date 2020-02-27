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
using Leadtools.ImageProcessing.Effects;
using Leadtools.Controls;

namespace GrayScaleDemo
{
   public partial class ShrinkWrapDialog : Form
   {
      private ImageViewer _viewer;
      private ViewerForm _form;
      private MainForm _mainForm;

      private int _radius;
      private LeadPoint _center;
      private ShrinkWrapCommand command;
      private LeadPoint _curntMousePoint;
      private bool _drawing;
      private bool _mousedown;
      private bool _isCircle;

      public ShrinkWrapDialog(MainForm form, ViewerForm viewer)
      {
         InitializeComponent();
         _mainForm = form;
         _form = viewer;
         _viewer = viewer.Viewer;
         _cbType.SelectedIndex = 0;
         _cbCombine.SelectedIndex = 1;
         _form.DisableInteractiveModes(_form.Viewer);
         _form.Viewer.InteractiveModes.EnableById(_form.NoneInteractiveMode.Id);

         _isCircle = true;
      }

      private void _btnApply_Click(object sender, EventArgs e)
      {
         if (command != null)
         {
            _drawing = true;
            command.Threshold = (int)_numThreshold.Value;
            command.Flags = (_cbType.SelectedIndex == 0) ? ShrinkWrapFlags.ShrinkCircle : ShrinkWrapFlags.ShrinkRect;
            _isCircle = (_cbType.SelectedIndex == 0);
            return;
         }

         command = new ShrinkWrapCommand();
         command.Threshold = (int)_numThreshold.Value;
         command.Flags = (_cbType.SelectedIndex == 0) ? ShrinkWrapFlags.ShrinkCircle : ShrinkWrapFlags.ShrinkRect;
         _viewer.PostRender += new EventHandler<ImageViewerRenderEventArgs>(_viewer_PostRender);
         _viewer.MouseMove += new MouseEventHandler(_viewer_MouseMove);
         _viewer.MouseDown += new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseUp += new MouseEventHandler(_viewer_MouseUp);
         _form.FormClosing += new FormClosingEventHandler(_form_FormClosing);
         _drawing = true;
         _mousedown = false;
         _isCircle = (_cbType.SelectedIndex == 0);
      }

      void _form_FormClosing(object sender, FormClosingEventArgs e)
      {
         this.Close();
         _mainForm.IsSegmentation = false;
         _mainForm.UpdateMyControls();
      }

      void _viewer_MouseUp(object sender, MouseEventArgs e)
      {
         if (command != null && e.Button == MouseButtons.Left && _drawing && _mousedown)
         {
            double xFactor = _viewer.XScaleFactor;
            double yFactor = _viewer.YScaleFactor;

            int xOffset = _viewer.ClientRectangle.Left;
            int yOffset = _viewer.ClientRectangle.Top;

            LeadPoint pnt = new LeadPoint((int)((e.X - xOffset) * 1.0 / xFactor + 0.5), (int)((e.Y - yOffset) * 1.0 / yFactor + 0.5));

            _curntMousePoint = pnt;
            _radius = Length(_center, _curntMousePoint);

            _drawing = false;
            _mousedown = false;

            if (_radius <= 1)
            {
               _viewer.Invalidate();
               return;
            }

            command.Center = _center;
            command.Radius = Math.Min(_radius, Math.Max(_viewer.Image.Width, _viewer.Image.Height));

            try
            {
               command.Flags = (_isCircle) ? ShrinkWrapFlags.ShrinkCircle : ShrinkWrapFlags.ShrinkRect;
               command.Flags |= (ShrinkWrapFlags)_cbCombine.SelectedIndex;
               command.Run(_viewer.Image);
            }
            catch (System.Exception ex)
            {
               Messager.ShowError(this, ex);
            }

         }
      }

      void _viewer_MouseDown(object sender, MouseEventArgs e)
      {
         if (command != null && e.Button == MouseButtons.Left)
         {
            if (_viewer.ViewBounds.Contains(LeadPoint.Create(e.X, e.Y)))
            {
               double xFactor = _viewer.XScaleFactor;
               double yFactor = _viewer.YScaleFactor;

               int xOffset = _viewer.ClientRectangle.Left;
               int yOffset = _viewer.ClientRectangle.Top;

               LeadPoint pnt = new LeadPoint((int)((e.X - xOffset) * 1.0 / xFactor + 0.5), (int)((e.Y - yOffset) * 1.0 / yFactor + 0.5));

               _drawing = true;
               _mousedown = true;
               _center = pnt;
               _curntMousePoint = _center;
               _viewer.Invalidate();

               if (_viewer.InteractiveModes.FindById(_form.FloaterInteractiveMode.Id).IsEnabled)
               {
                  _form.DisableInteractiveModes(_viewer);
                  _viewer.InteractiveModes.EnableById(_form.NoneInteractiveMode.Id);
                  try
                  {
                     if (_viewer.Floater != null)
                     {
                        RasterRegionXForm xForm = new RasterRegionXForm();
                        xForm.ViewPerspective = RasterViewPerspective.TopLeft;
                        xForm.XOffset = (int)_viewer.FloaterTransform.OffsetX;
                        xForm.YOffset = (int)_viewer.FloaterTransform.OffsetY;
                        xForm.YScalarDenominator =
                        xForm.XScalarDenominator =
                        xForm.XScalarNumerator =
                        xForm.YScalarNumerator = 1;

                        _viewer.Image.SetRegion(xForm, _viewer.Floater.GetRegion(null), RasterRegionCombineMode.Set);

                        _viewer.Floater.Dispose();
                        _viewer.Floater = null;
                     }
                  }
                  catch (Exception ex)
                  {
                     Messager.ShowError(this, ex);
                  }
               }
            }
         }
      }


      void _viewer_MouseMove(object sender, MouseEventArgs e)
      {
         if (command != null && e.Button == MouseButtons.Left && _drawing && _mousedown)
         {
            double xFactor = _viewer.XScaleFactor;
            double yFactor = _viewer.YScaleFactor;

            int xOffset = _viewer.ClientRectangle.Left;
            int yOffset = _viewer.ClientRectangle.Top;

            LeadPoint pnt = new LeadPoint((int)((e.X - xOffset) * 1.0 / xFactor + 0.5), (int)((e.Y - yOffset) * 1.0 / yFactor + 0.5));
            _curntMousePoint = pnt;
            _viewer.Invalidate();
         }
      }

      Rectangle RectFromCenterRadius(LeadPoint center, int radius)
      {
         return new Rectangle(new Point(center.X - radius, center.Y - radius), new Size(radius * 2, radius * 2));
      }

      int Length(LeadPoint center, LeadPoint current)
      {
         int xDiff = center.X - current.X;
         int yDiff = center.Y - current.Y;

         return (int)(Math.Sqrt((double)(xDiff * xDiff + yDiff * yDiff)) + 0.5);
      }


      void _viewer_PostRender(object sender, ImageViewerRenderEventArgs args)
      {
         PaintEventArgs e = args.PaintEventArgs;

         if (command != null)
         {
            if (_drawing)
            {
               double xFactor = _viewer.XScaleFactor;
               double yFactor = _viewer.YScaleFactor;
               float xOffset = -_viewer.DisplayRectangle.Left;
               float yOffset = -_viewer.DisplayRectangle.Top;
               LeadPoint center = new LeadPoint((int)((_center.X + xOffset) * xFactor + 0.5), (int)((_center.Y + yOffset) * yFactor + 0.5));
               LeadPoint current = new LeadPoint((int)((_curntMousePoint.X + xOffset) * xFactor + 0.5), (int)((_curntMousePoint.Y + yOffset) * yFactor + 0.5));

               int Radius = Length(center, current);

               e.Graphics.FillEllipse(Brushes.Red, RectFromCenterRadius(center, 2));
               e.Graphics.IntersectClip(_viewer.ClientRectangle);

               if (!_isCircle)
               {
                  e.Graphics.DrawRectangle(Pens.Yellow, RectFromCenterRadius(center, Radius));
               }
               else
               {
                  e.Graphics.DrawEllipse(Pens.Yellow, RectFromCenterRadius(center, Radius));
               }
            }
         }
      }

      private void ShrinkWrapDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         _viewer.PostRender -= new EventHandler<ImageViewerRenderEventArgs>(_viewer_PostRender);
         _viewer.MouseMove -= new MouseEventHandler(_viewer_MouseMove);
         _viewer.MouseDown -= new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseUp -= new MouseEventHandler(_viewer_MouseUp);

         try
         {
            if (_viewer.Image.HasRegion)
            {
               _viewer.ActiveItem.ImageRegionToFloater();
               _viewer.Image.SetRegion(null, null, RasterRegionCombineMode.Set);
               _form.DisableInteractiveModes(_viewer);
               _viewer.InteractiveModes.EnableById(_form.FloaterInteractiveMode.Id);
               _viewer.FloaterOpacity = 1;
            }
            _viewer.Invalidate();
         }
         catch (Exception /*ex*/)
         {
         }
         _mainForm.IsSegmentation = false;
         _mainForm.UpdateMyControls();
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
