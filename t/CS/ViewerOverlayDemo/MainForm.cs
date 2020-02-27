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
using System.IO;
using System.Drawing.Drawing2D;

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Drawing;
using Leadtools.ImageProcessing.Color;

namespace ViewerOverlayDemo
{
   public partial class MainForm : Form
   {
      // This is overlay rectangle in image coordinates
      private LeadRect _overlayRect;

      // This is the Interactive Mode to create the Overlay Rectangle
      private ImageViewerRubberBandInteractiveMode rubberBandMode;

      // If we are currently moving _overRect with the mouse
      private bool _isMovingOverlayRect;

      // This the original moving point, first point that was clicked
      private LeadPoint _lastMovePoint;

      private string _openInitialPath = string.Empty;

      public MainForm()
      {
         InitializeComponent();

         // Setup the caption for this demo
         Messager.Caption = "C# Viewer Overlay Demo";
      }

      protected override void OnLoad(EventArgs e)
      {
         if (!DesignMode)
         {
            foreach (ControlAlignment i in Enum.GetValues(typeof(ControlAlignment)))
            {
               _horizontalAlignmentComboBox.Items.Add(i);
               _verticalAlignmentComboBox.Items.Add(i);
            }

            foreach (ControlSizeMode i in Enum.GetValues(typeof(ControlSizeMode)))
            {
               _sizeModeComboBox.Items.Add(i);
            }

            _imageViewer.BorderStyle = BorderStyle.FixedSingle;
            _imageViewer.UseDpi = true;
            
            InitInteractiveModes();

            // So we can track the mouse and show its position related to the viewer and the image
            _imageViewer.MouseDown += new MouseEventHandler(_imageViewer_MouseDown);
            _imageViewer.MouseMove += new MouseEventHandler(_imageViewer_MouseMove);
            _imageViewer.MouseUp += new MouseEventHandler(_imageViewer_MouseUp);
            _imageViewer.LostFocus += new EventHandler(_imageViewer_LostFocus);

            // So we can draw our overlays
            _imageViewer.PostRender += new EventHandler<ImageViewerRenderEventArgs>(_imageViewer_PostRender);

            string defaultImageFileName = Path.Combine(DemosGlobal.ImagesFolder, "Ocr1.tif");
            LoadImage(defaultImageFileName);

            ReadMe(true);
         }

         base.OnLoad(e);
      }

      private void InitInteractiveModes()
      {
         _imageViewer.InteractiveModes.BeginUpdate();
         _imageViewer.InteractiveModes.Clear();
         rubberBandMode = new ImageViewerRubberBandInteractiveMode();
         rubberBandMode.IdleCursor = Cursors.Cross;
         rubberBandMode.WorkingCursor = Cursors.Cross;
         rubberBandMode.Shape = ImageViewerRubberBandShape.Rectangle;
         rubberBandMode.RubberBandCompleted += new EventHandler<ImageViewerRubberBandEventArgs>(rubberBandMode_RubberBandCompleted);
         rubberBandMode.IsEnabled = false;
         _imageViewer.InteractiveModes.Add(rubberBandMode);
         _imageViewer.InteractiveModes.EndUpdate();
      }

      protected override void OnFormClosed(FormClosedEventArgs e)
      {
         _imageViewer.LostFocus -= new EventHandler(_imageViewer_LostFocus);
         _imageViewer.MouseDown -= new MouseEventHandler(_imageViewer_MouseDown);
         _imageViewer.MouseMove -= new MouseEventHandler(_imageViewer_MouseMove);
         _imageViewer.MouseUp -= new MouseEventHandler(_imageViewer_MouseUp);
         _imageViewer.PostRender -= new EventHandler<ImageViewerRenderEventArgs>(_imageViewer_PostRender);

         base.OnFormClosed(e);
      }

      private void _openToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (OpenFileDialog dlg = new OpenFileDialog())
         {
            dlg.Filter = "All Files|*.*";
            dlg.InitialDirectory = _openInitialPath;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _openInitialPath = Path.GetDirectoryName(dlg.FileName);
               LoadImage(dlg.FileName);
            }
         }
      }

      private void _closeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         LoadImage(null);
      }

      private void _exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _aboutToolStripMenuItem_Click(object sender, EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Viewer Overlay", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _readMeToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ReadMe(false);
      }

      private void ReadMe(bool showHint)
      {
         StringBuilder sb = new StringBuilder();

         sb.AppendLine("This demo lets you draw a rectangle on top of the ImageViewer control in image coordinates and use the mouse cursor to drag it.");
         sb.AppendLine();
         sb.AppendLine("The purpose of this demo is to show how to map points and rectangles from viewer to client coordinates and back. Also, how to transform these coordinates to actual pixel coordinates in the image regardless of the view perspective.");
         sb.AppendLine();
         sb.AppendLine("The demo uses the following methods to achieve that:");
         sb.AppendLine("ImageViewer.ConvertPoint");
         sb.AppendLine("ImageViewer.ConvertRect");
         sb.AppendLine("RasterImage.RectangleToImage");
         sb.AppendLine("RasterImage.RectangleFromImage");
         sb.AppendLine();
         sb.AppendLine("Make sure an image is loaded, then click the 'Draw overlay rectangle' button to an overlay rectangle. You can then use the mouse to click on it and move it around the image.");
         sb.AppendLine();
         sb.AppendLine("Click the 'Fast rotate' buttons to rotate the image using its own view perspective, notice how everything is calculated correctly and the overlay rectangle should rotate with the image.");
         sb.AppendLine();
         sb.AppendLine("Click the 'Invert image under overlay rectangle' button to invert the image under the current overlay rectangle.");
         sb.AppendLine();
         sb.AppendLine("You can use the controls in 'Viewer Properties' group box to change the scroll, zoom, size mode and alignment of the image viewer.");

         if (showHint)
         {
            sb.AppendLine();
            sb.AppendLine("Select 'Help/Read me' from the menu to show this dialog box again.");
         }

         Messager.ShowInformation(this, sb.ToString());
      }

      private void LoadImage(string fileName)
      {
         RasterImage newImage = null;

         // Try to load the new image
         if (fileName != null)
         {
            try
            {
               using (RasterCodecs codecs = new RasterCodecs())
               {
                  using (WaitCursor wait = new WaitCursor())
                  {
                     newImage = codecs.Load(fileName, 0, CodecsLoadByteOrder.BgrOrGray, 1, 1);
                  }
               }
            }
            catch (Exception ex)
            {
               Messager.ShowFileOpenError(this, fileName, ex);
               return;
            }
         }

         _overlayRect = LeadRect.Empty;
         _imageViewer.Image = newImage;

         if (fileName != null)
         {
            Text = string.Format("{0} - {1}", Messager.Caption, fileName);
         }
         else
         {
            Text = Messager.Caption;
         }

         UpdateImageInfo();
         UpdateUIState();
      }

      private static string GetRasterViewPerspectiveName(RasterViewPerspective value)
      {
         switch (value)
         {
            case RasterViewPerspective.TopLeft: return "TopLeft";
            case RasterViewPerspective.TopRight: return "TopRight";
            case RasterViewPerspective.BottomRight: return "BottomRight";
            case RasterViewPerspective.BottomLeft: return "BottomLeft";
            case RasterViewPerspective.LeftTop: return "LeftTop";
            case RasterViewPerspective.RightTop: return "RightTop";
            case RasterViewPerspective.RightBottom: return "RightBottom";
            case RasterViewPerspective.LeftBottom: return "LeftBottom";
            default: throw new ArgumentException("Invalid view perspective");
         }
      }

      private void UpdateImageInfo()
      {
         RasterImage image = _imageViewer.Image;

         if (image != null)
         {
            double xResolution = image.XResolution > 0 ? image.XResolution : 96.0;
            double yResolution = image.YResolution > 0 ? image.YResolution : 96.0;

            double widthInches = (double)image.ImageWidth / xResolution;
            double heightInches = (double)image.ImageHeight / yResolution;

            _imageInfoLabel.Text = string.Format(
               "Size: {0} by {1} px ({2} by {3} in), Resolution: {4} by {5} dpi, View perspective: {6}",
               image.ImageWidth, image.ImageHeight,
               widthInches.ToString("F02"), heightInches.ToString("F02"),
               image.XResolution, image.YResolution,
               GetRasterViewPerspectiveName(image.ViewPerspective));
         }
         else
         {
            _imageInfoLabel.Text = string.Empty;
         }
      }

      private void UpdateUIState()
      {
         _leftPanel.Enabled = _imageViewer.Image != null;
         _bottomPanel.Enabled = _imageViewer.Image != null;

         _useDpiCheckBox.Checked = _imageViewer.UseDpi;
         _paddingCheckBox.Checked = _imageViewer.ViewPadding.All != 0;
         _horizontalAlignmentComboBox.SelectedItem = _imageViewer.ViewHorizontalAlignment;
         _verticalAlignmentComboBox.SelectedItem = _imageViewer.ViewVerticalAlignment;
         _sizeModeComboBox.Text = ((ControlSizeMode)_imageViewer.SizeMode).ToString();
         _zoomValueLabel.Text = string.Format("Current zoom value: {0}%", (int)(_imageViewer.ScaleFactor * 100.0));
         _drawOverlayRectangleButton.Enabled = !rubberBandMode.IsEnabled;
         _invertImageUnderOverlayRectButton.Enabled = !_overlayRect.IsEmpty;
      }

      private void _useDpiCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         _imageViewer.UseDpi = _useDpiCheckBox.Checked;
         UpdateUIState();
      }

      private void _paddingCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         if (_imageViewer.ViewPadding.All == 0)
         {
            _imageViewer.ViewPadding = new Padding(8);
         }
         else
         {
            _imageViewer.ViewPadding = new Padding(0);
         }

         UpdateUIState();
      }

      private void _zoomNoneButton_Click(object sender, EventArgs e)
      {
         ZoomViewer(1.0);
      }

      private void _zoomInButton_Click(object sender, EventArgs e)
      {
         ZoomViewer(_imageViewer.ScaleFactor * 1.2);
      }

      private void _zoomOutButton_Click(object sender, EventArgs e)
      {
         ZoomViewer(_imageViewer.ScaleFactor / 1.2);
      }

      private void ZoomViewer(double value)
      {
         //// zoom         
         // We will do zoom/center, so save the current center in logical units
         // get what you see in physical coordinates
         LeadRect LeadPhysicalViewRectangle = _imageViewer.ViewBounds;
         //LeadRect LeadLogicalViewRectangle = _imageViewer.ImageBounds;

         Rectangle PhysicalViewRectangle = new Rectangle(LeadPhysicalViewRectangle.X, LeadPhysicalViewRectangle.Y, LeadPhysicalViewRectangle.Width, LeadPhysicalViewRectangle.Height);
         Rectangle LogicalViewRectangle = _imageViewer.ClientRectangle;

         Rectangle rc = Rectangle.Intersect(PhysicalViewRectangle, LogicalViewRectangle);
         
         // get the center of what you see in physical coordinates
         PointF center = new PointF(rc.Left + rc.Width / 2, rc.Top + rc.Height / 2);

         LeadMatrix m = _imageViewer.GetImageTransformWithDpi(_imageViewer.UseDpi);
         Matrix mm = new Matrix((float)m.M11, (float)m.M12, (float)m.M21, (float)m.M22, (float)m.OffsetX, (float)m.OffsetY);   
         Transformer t = new Transformer(mm);
         // get the center of what you see in logical coordinates
         center = t.PointToLogical(center);
         // zoom
         const double minimumScaleFactor = 0.05;
         const double maximumScaleFactor = 11;
         double scaleFactor = Math.Max(minimumScaleFactor, Math.Min(maximumScaleFactor, value));
         if (_imageViewer.ScaleFactor != scaleFactor)
         {
            _imageViewer.Zoom(ControlSizeMode.None, scaleFactor, _imageViewer.DefaultZoomOrigin);
            // bring the original center into the view center
            m = _imageViewer.GetImageTransformWithDpi(_imageViewer.UseDpi);
            mm = new Matrix((float)m.M11, (float)m.M12, (float)m.M21, (float)m.M22, (float)m.OffsetX, (float)m.OffsetY);            
            t = new Transformer(mm);
            // get the center of what you saw before the zoom in physical coordinates
            center = t.PointToPhysical(center);
            // bring the old center into the center of the view
            _imageViewer.CenterAtPoint(LeadPoint.Create((int)center.X,(int)center.Y));
            UpdateUIState();
         }
      }

      private void _horizontalAlignmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         _imageViewer.ViewHorizontalAlignment = (ControlAlignment)_horizontalAlignmentComboBox.SelectedItem;
         UpdateUIState();
      }

      private void _verticalAlignmentComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         _imageViewer.ViewVerticalAlignment = (ControlAlignment)_verticalAlignmentComboBox.SelectedItem;
         UpdateUIState();
      }     

      void _sizeModeComboBox_SelectionChangeCommitted(object sender, System.EventArgs e)
      {
         ControlSizeMode sizeMode = (ControlSizeMode)_sizeModeComboBox.SelectedItem;
         _imageViewer.Zoom(sizeMode, 1, _imageViewer.DefaultZoomOrigin);
         UpdateUIState();
      }

      private void _imageViewer_MouseDown(object sender, MouseEventArgs e)
      {
         RasterImage image = _imageViewer.Image;

         if (image == null || rubberBandMode.IsEnabled)
         {
            // Nothing for us to do
            return;
         }

         if (_isMovingOverlayRect)
         {
            // Previously moving the rectangle, end the move operation
            EndMovingOverlayRect();
         }

         if (!_overlayRect.IsEmpty && e.Button == MouseButtons.Left)
         {
            // Check if we are on the overlay rect. Get current mouse position
            // in image coordinates. Using TopLeft since the overlay rect is in
            // TopLeft always
            LeadPoint viewerPoint = LeadPoint.Create(e.X, e.Y);
            LeadPoint imagePoint = _imageViewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, viewerPoint);

            if (_overlayRect.Contains(imagePoint.X, imagePoint.Y))
            {
               // Yes, start moving 
               _lastMovePoint = viewerPoint;
               _isMovingOverlayRect = true;

               // Optional: clip the cursor to not move outside the image bounds
               LeadRect imageRect = LeadRect.Create(0, 0, image.ImageWidth, image.ImageHeight);
               LeadRect viewerRect = _imageViewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, imageRect);
               // Note, the above returns the same value as _rasterImageViewer.PhysicalViewRectangle
               Rectangle clipRect = Rectangle.Intersect(Rectangle.FromLTRB(viewerRect.Left, viewerRect.Top, viewerRect.Right, viewerRect.Bottom), _imageViewer.ClientRectangle);
               Cursor.Clip = _imageViewer.RectangleToScreen(clipRect);
               _imageViewer.Capture = true;
            }
         }
      }

      private void _imageViewer_MouseMove(object sender, MouseEventArgs e)
      {
         RasterImage image = _imageViewer.Image;

         if (image == null)
         {
            return;
         }

         // Here is the point in viewer (physical or client) coordinates
         // This point is the mouse position
         LeadPoint viewerPoint = LeadPoint.Create(e.X, e.Y);

         // Convert to image coordinates (top-left view perspective, since we are
         // only interested in the zoom/scroll values and not trying to get to a
         // certain pixel in the image data)
         LeadPoint imagePoint = _imageViewer.ConvertPoint(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, viewerPoint);

         ShowMousePositionAndImageColor(image, viewerPoint, imagePoint);

         if (_isMovingOverlayRect)
         {
            // We are moving the overlay rect

            // After we are done with moving the overlay rect to a new position,
            // we need to re-paint to show the effect. To optimize the code, we will
            // only repaint the combination of the old and new rects

            // Get the current (soon to be old) overlay rect in viewer coordinates
            LeadRect oldImageRect = LeadRect.Create(_overlayRect.X, _overlayRect.Y, _overlayRect.Width, _overlayRect.Height);
            LeadRect oldViewerRect = _imageViewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, oldImageRect);

            // Get the difference
            int dx = e.X - _lastMovePoint.X;
            int dy = e.Y - _lastMovePoint.Y;

            if (dx != 0 || dy != 0)
            {
               // Has moved

               LeadRect newViewerRect = oldViewerRect;
               newViewerRect.Offset(dx, dy);

               // Now re-calculate new overlay rectangle in image coordinates
               LeadRect newImageRect = _imageViewer.ConvertRect(null, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, newViewerRect);

               // Make sure the image rectangle does not go outside the image boundaries
               if (newImageRect.X < 0)
               {
                  newImageRect.Offset(-newImageRect.X, 0);
               }
               if (newImageRect.Y < 0)
               {
                  newImageRect.Offset(0, -newImageRect.Y);
               }
               if ((newImageRect.X + newImageRect.Width) > image.ImageWidth)
               {
                  newImageRect.Offset(-(newImageRect.X + newImageRect.Width - image.ImageWidth), 0);
               }
               if ((newImageRect.Y + newImageRect.Height) > image.ImageHeight)
               {
                  newImageRect.Offset(0, -(newImageRect.Y + newImageRect.Height - image.ImageHeight));
               }

               // Check if it has really changed
               if (newImageRect.X != oldImageRect.X ||
                  newImageRect.Y != oldImageRect.Y ||
                  newImageRect.Width != oldImageRect.Width ||
                  newImageRect.Height != oldImageRect.Height)
               {
                  // Yes
                  _overlayRect = new LeadRect(newImageRect.X, newImageRect.Y, newImageRect.Width, newImageRect.Height);

                  _imageViewer.Invalidate();
               }

               // Save the new moving position
               _lastMovePoint = LeadPoint.Create(e.X, e.Y);
            }
         }
      }

      private void _imageViewer_MouseUp(object sender, MouseEventArgs e)
      {
         if (_isMovingOverlayRect)
         {
            EndMovingOverlayRect();
         }
      }

      private void _imageViewer_LostFocus(object sender, EventArgs e)
      {
         if (_isMovingOverlayRect)
         {
            EndMovingOverlayRect();
         }
      }

      private void EndMovingOverlayRect()
      {
         _imageViewer.Capture = false;
         _isMovingOverlayRect = false;
         Cursor.Clip = Rectangle.Empty;
      }

      private void ShowMousePositionAndImageColor(RasterImage image, LeadPoint viewerPoint, LeadPoint imagePoint)
      {
         // This point is now in image coordinates, i.e., 0,0 is the top-left area of the image
         // Since we passed 'false' to 'accountForViewPerspective' above, the point is what we see
         // if the data in the image is top-left (point 0, 0, is the most left-top point in the image data)
         // This is called the ViewPerspective of the image. Not all images supported by LEADTOOLS have top-left coordinates,
         // for example, when you load a BMP file, by the default, the image data is "flipped" and has a view perspective of
         // bottom-left. We could pass 'true' for images like that if we need to convert the point to the
         // actual pixel x, y in the image. We will do that later in the code below

         string imagePointText;
         bool outside = false;

         // Check if the viewer point is outside the image coordinates
         if (imagePoint.X < 0 || imagePoint.Y < 0 || imagePoint.X > image.ImageWidth || imagePoint.Y > image.ImageHeight)
         {
            outside = true;
         }

         if (outside)
         {
            // Outside
            imagePointText = "OUTSIDE";
         }
         else
         {
            imagePointText = string.Format("{0}, {1}", imagePoint.X, imagePoint.Y);
         }

         // Show both points
         _mousePositionLabel.Text = string.Format(
            "Viewer: {0}, {1} - Image: {2}",
            viewerPoint.X, viewerPoint.Y,
            imagePointText);

         // Get the color under the cursor

         RasterColor pointCursorColor;

         // Use the imagePoint, we will use Raster.GetPixel. This method except the points
         // to be in image coordinates and in the image view perspective.
         // Since we had the point in top-left (by not passing true to accountForViewPerspective),
         // we must convert it to image coordinate first using RasterImage.PointToImage
         if (!outside)
         {
            LeadPoint colorPoint = new LeadPoint(imagePoint.X, imagePoint.Y);
            colorPoint = image.PointToImage(RasterViewPerspective.TopLeft, colorPoint);

            // GetPixel takes row/column, or Y and X
            pointCursorColor = image.GetPixel(colorPoint.Y, colorPoint.X);
         }
         else
         {
            // Either outside the image or we do not have an image
            pointCursorColor = RasterColor.FromKnownColor(RasterKnownColor.Transparent);
         }

         _cursorColorValueLabel.Text = pointCursorColor.ToString();
         _colorCursorPanel.BackColor = RasterColorConverter.ToColor(pointCursorColor);

         // Finally, if we are not drawing an interactive user rectangle and the cursor is over the
         // overlay rect, change its shape to a Hand

         if (!rubberBandMode.IsEnabled)
         {
            if (!_overlayRect.IsEmpty && _overlayRect.Contains(imagePoint.X, imagePoint.Y))
            {
               _imageViewer.Cursor = Cursors.Hand;
            }
            else
            {
               _imageViewer.Cursor = Cursors.Default;
            }
         }
      }

      private void rubberBandMode_RubberBandCompleted(object sender, ImageViewerRubberBandEventArgs e)
      {
         // User selected a new rectangle
         _overlayRect = _imageViewer.ConvertRect(
            null,
            ImageViewerCoordinateType.Control,
            ImageViewerCoordinateType.Image,
            LeadRect.FromLTRB(e.Points[0].X, e.Points[0].Y, e.Points[1].X, e.Points[1].Y));

         // We need to change the interactive mode back to "None"
         ResetInteractiveMode();
      }

      private void ResetInteractiveMode()
      {
         // Set the interactive mode back to None
         _imageViewer.InteractiveModes.BeginUpdate();
         rubberBandMode.IsEnabled = false;
         _imageViewer.InteractiveModes.EndUpdate();

         // To enable/disable controls
         UpdateUIState();

         // Re-paint
         _imageViewer.Invalidate();
      }

      private void _imageViewer_PostRender(object sender, ImageViewerRenderEventArgs e)
      {
         RasterImage image = _imageViewer.Image;

         if (image == null || _overlayRect.IsEmpty)
         {
            // No image or the overlay rectangle hasn't been set yet
            return;
         }

         // Convert the overlay rectangle (it is in image coordinates) to viewer coordinates
         LeadRect imageRect = LeadRect.Create(_overlayRect.X, _overlayRect.Y, _overlayRect.Width, _overlayRect.Height);
         // We must pass false for 'accountForViewPerspective' in this case because _overlayRect is always
         // in top-left coordinates in this demo
         LeadRect viewerRect = _imageViewer.ConvertRect(null, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, imageRect);

         if (!viewerRect.IsEmpty)
         {
            // Otherwise, we zoomed out too much and it is too small to paint
            Graphics g = e.PaintEventArgs.Graphics;

            using (Brush brush = new SolidBrush(Color.FromArgb(128, Color.Black)))
            {
               Rectangle rect = Rectangle.FromLTRB(viewerRect.Left, viewerRect.Top, viewerRect.Right, viewerRect.Bottom);
               g.FillRectangle(brush, rect);
               g.DrawRectangle(Pens.Yellow, viewerRect.X, viewerRect.Y, viewerRect.Width - 1, viewerRect.Height - 1);
            }
         }
      }

      private void _invertImageUnderOverlayRectButton_Click(object sender, EventArgs e)
      {
         RasterImage image = _imageViewer.Image;

         // Add the overlay rect as a region to the image

         // The overlay rect is in image coordinates already but it is at top-left
         // view perspective, the image might not be. If you load a BMP file or click
         // the fast rotate buttons, you will notice this.

         // We can do one of two things:

         // 1. Use RasterRegionXForm to tell the AddRectangleToRegion method the
         // rect passed is in TopLeft:
         /*
         RasterRegionXForm xForm = RasterRegionXForm.Default;
         xForm.ViewPerspective = RasterViewPerspective.TopLeft;
         image.AddRectangleToRegion(xForm, _overlayRect, RasterRegionCombineMode.Set);
         */

         // RasterRegionXForm is a matrix that allows you to perform many more actions,
         // such as transform the rectangle from any coordinates to another.

         // 2. Use RasterImage.RectangleToImage to convert the rect from TopLeft
         // to the view perspective of the image:
         LeadRect dataRect = image.RectangleToImage(RasterViewPerspective.TopLeft, _overlayRect);
         image.AddRectangleToRegion(null, dataRect, RasterRegionCombineMode.Set);

         InvertCommand cmd = new InvertCommand();
         cmd.Run(image);

         // Remove the region
         image.MakeRegionEmpty();
      }

      private void _fastRotate90ClockwiseButton_Click(object sender, EventArgs e)
      {
         Rotate(90);
      }

      private void _fastRotate90CounterClockwiseButton_Click(object sender, EventArgs e)
      {
         Rotate(-90);
      }

      private void Rotate(int angle)
      {
         RasterImage image = _imageViewer.Image;

         // We must rotate our overlay rect too. We could rotate it ourselves or we could do this:
         // Get the rect in image coordinates (regardless of the view persective)
         // Rotate the image
         // Get the rect again in top-left from the image coordinates we saved

         LeadRect imageRect = LeadRect.Empty;

         if (!_overlayRect.IsEmpty)
         {
            // Save the overlay rect in image coordinates
            imageRect = image.RectangleToImage(RasterViewPerspective.TopLeft, _overlayRect);
         }

         if (RasterSupport.IsLocked(RasterSupportType.Document))
         {
            MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
         }
         // Fast rotation involves changing the image view-perspective
         image.RotateViewPerspective(angle);

         if (!_overlayRect.IsEmpty)
         {
            // Now re-get the overlay rectangle as top left from the image data coordinates
            // we saved
            _overlayRect = image.RectangleFromImage(RasterViewPerspective.TopLeft, imageRect);
         }

         UpdateImageInfo();
      }

      private void _drawOverlayRectangleButton_Click(object sender, EventArgs e)
      {
         // Start the interactive mode
         _imageViewer.InteractiveModes.BeginUpdate();
         rubberBandMode.IsEnabled = true;
         _imageViewer.InteractiveModes.EndUpdate();
         UpdateUIState();
      }
   }
}
