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
using System.Drawing.Drawing2D;
using Leadtools.Drawing;

namespace MainDemo
{
   public partial class ShrinkWrapDialog : Form
   {
      private int _radius;
      private LeadPoint _center;
      private ImageViewer _viewer;
      private ViewerForm _form;
      private MainForm _mainForm;
      private ShrinkWrapCommand command;
      private LeadPoint _curntMousePoint;
      private bool _drawing;
      private bool _isCircle;
      private bool _mousedown;

      public ShrinkWrapDialog(MainForm form, ViewerForm viewer)
      {
         InitializeComponent();
         _mainForm = form;
         _form = viewer;
         _viewer = viewer.Viewer;
         _cbType.SelectedIndex = 0;
         _cbCombine.SelectedIndex = 1;
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
         _viewer.PostRender += new EventHandler<ImageViewerRenderEventArgs>(_viewer_Paint);
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
      }

      void _viewer_MouseUp(object sender, MouseEventArgs e)
      {
         if (command != null && e.Button == MouseButtons.Left && _drawing && _mousedown)
         {
            double xFactor = _viewer.XScaleFactor;
            double yFactor = _viewer.YScaleFactor;

            int xOffset = _viewer.ViewBounds.Left;
            int yOffset = _viewer.ViewBounds.Top;

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

               int xOffset = _viewer.ViewBounds.Left;
               int yOffset = _viewer.ViewBounds.Top;

               LeadPoint pnt = new LeadPoint((int)((e.X - xOffset) * 1.0 / xFactor + 0.5), (int)((e.Y - yOffset) * 1.0 / yFactor + 0.5));

               _drawing = true;
               _mousedown = true;
               _center = pnt;
               _curntMousePoint = _center;
               _viewer.Invalidate();


               if (_viewer.WorkingInteractiveMode is ImageViewerFloaterInteractiveMode)
               {
                  _mainForm.DisableAllInteractiveModes(_viewer);
                  _form.Viewer.InteractiveModes.BeginUpdate();
                  _form.NoneInteractiveMode.IsEnabled = true;
                  _form.Viewer.InteractiveModes.EndUpdate();
                  try
                  {
                     if (_viewer.Floater != null)
                     {
                        RasterRegionXForm xForm = new RasterRegionXForm();
                        xForm.ViewPerspective = RasterViewPerspective.TopLeft;
                        /*LeadMatrix mm = _viewer.FloaterTransform.OffsetY;
                        Matrix m = new Matrix((float)mm.M11, (float)mm.M12, (float)mm.M21, (float)mm.M22, (float)mm.OffsetX, (float)mm.OffsetY);                           
                        Transformer t = new Transformer(m);*/
                        LeadMatrix floaterTransform = _viewer.FloaterTransform;

                        xForm.XOffset = (int)floaterTransform.OffsetX;
                        xForm.YOffset = (int)floaterTransform.OffsetY;
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

            int xOffset = _viewer.ViewBounds.Left;
            int yOffset = _viewer.ViewBounds.Top;

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

      void _viewer_Paint(object sender, ImageViewerRenderEventArgs e)
      {
         if (command != null)
         {
            if (_drawing)
            {
               double xFactor = _viewer.XScaleFactor;
               double yFactor = _viewer.YScaleFactor;
               float xOffset = -_viewer.ViewBounds.Left;
               float yOffset = -_viewer.ViewBounds.Top;
               LeadPoint center = new LeadPoint((int)((_center.X + xOffset) * xFactor + 0.5), (int)((_center.Y + yOffset) * yFactor + 0.5));
               LeadPoint current = new LeadPoint((int)((_curntMousePoint.X + xOffset) * xFactor + 0.5), (int)((_curntMousePoint.Y + yOffset) * yFactor + 0.5));

               int Radius = Length(center, current);

               e.PaintEventArgs.Graphics.FillEllipse(Brushes.Red, RectFromCenterRadius(center, 2));
               e.PaintEventArgs.Graphics.IntersectClip(new Rectangle(_viewer.ViewBounds.X, _viewer.ViewBounds.Y, _viewer.ViewBounds.Width, _viewer.ViewBounds.Height));

               if (!_isCircle)
               {
                   e.PaintEventArgs.Graphics.DrawRectangle(Pens.Yellow, RectFromCenterRadius(center, Radius));
               }
               else
               {
                   e.PaintEventArgs.Graphics.DrawEllipse(Pens.Yellow, RectFromCenterRadius(center, Radius));
               }
            }
         }
      }

      private void ShrinkWrapDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
          _viewer.PostRender -= _viewer_Paint ;
         _viewer.MouseMove -= new MouseEventHandler(_viewer_MouseMove);
         _viewer.MouseDown -= new MouseEventHandler(_viewer_MouseDown);
         _viewer.MouseUp -= new MouseEventHandler(_viewer_MouseUp);

         if (_viewer.Image.HasRegion)
         {
             try
             {
                 _viewer.ActiveItem.ImageRegionToFloater();
                 _viewer.Image.SetRegion(null, null, RasterRegionCombineMode.Set);
                 _mainForm.DisableAllInteractiveModes(_viewer);
                 _form.Viewer.InteractiveModes.BeginUpdate();
                 _form.FloaterInteractiveMode.IsEnabled = true;
                 _viewer.FloaterOpacity = 1.0;//Visible = true;
                 _form.Viewer.InteractiveModes.EndUpdate();
             }
             catch (Exception /*ex*/)
             {

             }
         }

         _viewer.Invalidate();
         _mainForm.InteractiveToolsList.Remove(_viewer);
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         this.Close();
      }
   }
}
