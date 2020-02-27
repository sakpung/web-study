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
using System.Drawing.Drawing2D;

using Leadtools;
using Leadtools.Controls;
using Leadtools.Drawing;

namespace SharePointDemo
{
   public partial class ViewerControl : UserControl
   {
      // The RasterImageViewer instance
      private ImageViewer _imageViewer;
      private ImageViewerPanZoomInteractiveMode panZoomMode;
      private ImageViewerZoomToInteractiveMode zoomToMode;
      private ImageViewerNoneInteractiveMode noneMode;

      private double _minimumViewerScalePercentage = 1;
      private double _maximumViewerScalePercentage = 6400;

      public ViewerControl()
      {
         InitializeComponent();

         InitViewer();

         InitInteractiveModes();

         // Use ScaleToGray paint
         RasterPaintProperties props = _imageViewer.PaintProperties;
         props.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray | RasterPaintDisplayModeFlags.Resample;
         _imageViewer.PaintProperties = props;

         // Pad the viewer
         _imageViewer.ViewPadding = new Padding(10);

         _zoomToSelectionToolStripButton.PerformClick();

         // These events are needed and not visible from the designer, so
         // hook into them here
         _zoomToolStripComboBox.LostFocus += new EventHandler(_zoomToolStripComboBox_LostFocus);
         _pageToolStripTextBox.LostFocus += new EventHandler(_pageToolStripTextBox_LostFocus);
      }

      private void InitViewer()
      {
         _imageViewer = new ImageViewer();

         _imageViewer.BackColor = SystemColors.AppWorkspace;
         _imageViewer.BorderStyle = BorderStyle.None;
         _imageViewer.Dock = DockStyle.Fill;
         _imageViewer.ViewHorizontalAlignment = ControlAlignment.Center;
         _imageViewer.ViewVerticalAlignment = ControlAlignment.Center;
         _imageViewer.UseDpi = true;
         _imageViewer.TransformChanged += new EventHandler(_imageViewer_TransformChanged);

         Controls.Add(_imageViewer);
         _imageViewer.BringToFront();
         _imageViewer.Zoom(ControlSizeMode.Fit, 1, _imageViewer.DefaultZoomOrigin);
      }

      void _imageViewer_TransformChanged(object sender, EventArgs e)
      {
         if (IsHandleCreated)
         {
            UpdateZoomComboBoxValueFromViewer();
            UpdateMyControls();
         }
      }

      private void InitInteractiveModes()
      {
         _imageViewer.InteractiveModes.BeginUpdate();
         _imageViewer.InteractiveModes.Clear();

         noneMode = new ImageViewerNoneInteractiveMode();
         noneMode.IdleCursor = Cursors.Arrow;
         noneMode.WorkingCursor = Cursors.Arrow;
         noneMode.IsEnabled = true;
         _imageViewer.InteractiveModes.Add(noneMode);

         panZoomMode = new ImageViewerPanZoomInteractiveMode();
         panZoomMode.IdleCursor = Cursors.Hand;
         panZoomMode.WorkingCursor = Cursors.Hand;
         panZoomMode.IsEnabled = false;
         panZoomMode.WorkOnBounds = true;
         _imageViewer.InteractiveModes.Add(panZoomMode);

         zoomToMode = new ImageViewerZoomToInteractiveMode();
         zoomToMode.IdleCursor = Cursors.Cross;
         zoomToMode.WorkingCursor = Cursors.Cross;
         zoomToMode.IsEnabled = false;
         zoomToMode.WorkOnBounds = true;
         _imageViewer.InteractiveModes.Add(zoomToMode);

         _imageViewer.InteractiveModes.EndUpdate();
      }

      protected override void OnLoad(EventArgs e)
      {
         // Call the transform changed
         _imageViewer_TransformChanged(_imageViewer, EventArgs.Empty);

         base.OnLoad(e);
      }

      protected override void OnTextChanged(EventArgs e)
      {
         _titleLabel.Text = Text;

         base.OnTextChanged(e);
      }

      public event EventHandler<EventArgs> OpenFileClicked;

      private void _openFileToolStripButton_Click(object sender, EventArgs e)
      {
         if (OpenFileClicked != null)
            OpenFileClicked(this, e);
      }

      public event EventHandler<EventArgs> UploadClicked;

      private void _uploadToolStripButton_Click(object sender, EventArgs e)
      {
         if (UploadClicked != null)
            UploadClicked(this, e);
      }

      private void UpdateZoomComboBoxValueFromViewer()
      {
         // We are invoking this instead of changing the properties
         // directly because the Text value of a combo box is not updated
         // till after the lost focus or enter event is exited
         BeginInvoke(new MethodInvoker(delegate()
         {
            if (_imageViewer.Image != null)
            {
               double factor = _imageViewer.XScaleFactor * 100.0;
               _zoomToolStripComboBox.Text = factor.ToString("F1") + "%";

               if ((_imageViewer.XScaleFactor * 100) > _maximumViewerScalePercentage && zoomToMode.IsEnabled)
                  SetMode(noneMode);
            }
            else
            {
               _zoomToolStripComboBox.Text = string.Empty;
            }
         }));
      }

      private void UpdateMyControls()
      {
         if (_imageViewer.Image != null)
         {
            _uploadToolStripButton.Enabled = true;

            int page = _imageViewer.Image.Page;
            int pageCount = _imageViewer.Image.PageCount;

            _pageToolStripTextBox.Text = page.ToString();
            _pageToolStripLabel.Enabled = true;
            _pageToolStripLabel.Text = "/ " + pageCount.ToString();

            _previousPageToolStripButton.Enabled = page > 1;
            _nextPageToolStripButton.Enabled = page < pageCount;

            _pageToolStripTextBox.Enabled = true;
            _zoomOutToolStripButton.Enabled = true;
            _zoomInToolStripButton.Enabled = true;
            _zoomToolStripComboBox.Enabled = true;
            _fitPageWidthToolStripButton.Enabled = true;
            _fitPageToolStripButton.Enabled = true;
            _selectModeToolStripButton.Enabled = true;
            _panModeToolStripButton.Enabled = true;

            _fitPageWidthToolStripButton.Checked = _imageViewer.SizeMode == ControlSizeMode.FitWidth;
            _fitPageToolStripButton.Checked = _imageViewer.SizeMode == ControlSizeMode.Fit;

            _selectModeToolStripButton.Checked = noneMode.IsEnabled;
            _panModeToolStripButton.Checked = panZoomMode.IsEnabled;
            _zoomToSelectionToolStripButton.Checked = zoomToMode.IsEnabled;
            _zoomToSelectionToolStripButton.Enabled = (_imageViewer.XScaleFactor * 100) < _maximumViewerScalePercentage;
         }
         else
         {
            _pageToolStripTextBox.Text = "0";
            _pageToolStripLabel.Text = "/ 0";

            _fitPageWidthToolStripButton.Checked = false;
            _fitPageToolStripButton.Checked = false;

            _zoomToolStripComboBox.Text = string.Empty;

            _uploadToolStripButton.Enabled = false;
            _previousPageToolStripButton.Enabled = false;
            _nextPageToolStripButton.Enabled = false;
            _pageToolStripTextBox.Enabled = false;
            _pageToolStripLabel.Enabled = false;
            _zoomOutToolStripButton.Enabled = false;
            _zoomInToolStripButton.Enabled = false;
            _zoomToolStripComboBox.Enabled = false;
            _fitPageWidthToolStripButton.Enabled = false;
            _fitPageToolStripButton.Enabled = false;
            _selectModeToolStripButton.Enabled = false;
            _panModeToolStripButton.Enabled = false;
            _zoomToSelectionToolStripButton.Enabled = false;
         }
      }

      private void _previousPageToolStripButton_Click(object sender, EventArgs e)
      {
         MoveToPage(true);
      }

      private void _nextPageToolStripButton_Click(object sender, EventArgs e)
      {
         MoveToPage(false);
      }

      public void MoveToPage(bool previous)
      {
         if (_imageViewer.Image == null)
            return;

         if (previous)
            SetPage(_imageViewer.Image.Page - 1);
         else
            SetPage(_imageViewer.Image.Page + 1);
      }

      private void _pageToolStripTextBox_LostFocus(object sender, EventArgs e)
      {
         _pageToolStripTextBox.Text = _imageViewer.Image.Page.ToString();
      }

      private void _pageToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == '\r')
         {
            // User has pressed enter
            // Get the new page number

            string str = _pageToolStripTextBox.Text.Trim();

            // Try to parse the integer value
            int page;
            if (int.TryParse(str, out page))
               SetPage(page);

            _pageToolStripTextBox.Text = _imageViewer.Image.Page.ToString();
         }
      }

      private void SetPage(int page)
      {
         if (page >= 1 && page <= _imageViewer.Image.PageCount)
         {
            _imageViewer.Image.Page = page;
            UpdateMyControls();
         }
      }

      private void _zoomOutToolStripButton_Click(object sender, EventArgs e)
      {
         ZoomViewer(true);
      }

      private void _zoomInToolStripButton_Click(object sender, EventArgs e)
      {
         ZoomViewer(false);
      }

      private void _zoomToolStripComboBox_LostFocus(object sender, EventArgs e)
      {
         UpdateZoomComboBoxValueFromViewer();
      }

      private void _zoomToolStripComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         string str = _zoomToolStripComboBox.Text.ToString();

         if (str == "Actual Size")
            SetViewerZoomPercentage(100);
         else if (str == "Fit Page")
            _fitPageToolStripButton.PerformClick();
         else if (str == "Fit Width")
            _fitPageWidthToolStripButton.PerformClick();
         else
         {
            double val = double.Parse(str.Substring(0, str.Length - 1));
            SetViewerZoomPercentage(val);
         }
      }

      private void _zoomToolStripComboBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == '\r')
         {
            // User has pressed enter
            // Get the new scale factor

            string str = _zoomToolStripComboBox.Text.Trim();

            // Remove the % sign if present
            if (str.EndsWith("%"))
               str = str.Remove(str.Length - 1, 1);
            str = str.Trim();

            // Try to parse the double value
            double percentage;
            if (double.TryParse(str, out percentage))
               SetViewerZoomPercentage(percentage);

            UpdateZoomComboBoxValueFromViewer();
         }
      }

      public void ZoomViewer(bool zoomOut)
      {
         // Get the current scale factor
         double percentage = _imageViewer.XScaleFactor * 100.0;

         // The valid scale factors
         double[] validPercentages =
         {
            _minimumViewerScalePercentage, 6.25, 12.5, 25, 33.3, 50, 66.7, 73.6, 92.5, 100,
            125, 150, 200, 300, 400, 600, 800, 1200, 1600, 2400,
            3200, _maximumViewerScalePercentage
         };

         // Find out where we are, move to the next one up or down
         if (zoomOut)
         {
            for (int i = validPercentages.Length - 1; i >= 0; i--)
            {
               if (percentage > validPercentages[i])
               {
                  percentage = validPercentages[i];
                  break;
               }
            }
         }
         else
         {
            for (int i = 0; i < validPercentages.Length; i++)
            {
               if (percentage < validPercentages[i])
               {
                  percentage = validPercentages[i];
                  break;
               }
            }
         }

         SetViewerZoomPercentage(percentage);
      }

      private void SetViewerZoomPercentage(double percentage)
      {
         // Normalize the percentage based on min/max value allowed
         percentage = Math.Max(_minimumViewerScalePercentage, Math.Min(_maximumViewerScalePercentage, percentage));

         if (Math.Abs(_imageViewer.XScaleFactor * 100 - percentage) > 0.01)
         {
            // Save the current center location in the viewer. We will zoom center
            _imageViewer.BeginUpdate();

            // Zoom
            double scaleFactor = percentage / 100.0;

            _imageViewer.Zoom(ControlSizeMode.None, scaleFactor, _imageViewer.DefaultZoomOrigin);

            _imageViewer.EndUpdate();

            UpdateMyControls();
         }
      }

      private void _fitPageWidthToolStripButton_Click(object sender, EventArgs e)
      {
         FitPage(true);
      }

      private void _fitPageToolStripButton_Click(object sender, EventArgs e)
      {
         FitPage(false);
      }

      public void FitPage(bool fitWidth)
      {
         if (_imageViewer.Image == null)
            return;

         double scaleFactor = 1;
         ControlSizeMode sizeMode = ControlSizeMode.Fit;

         if (fitWidth)
            sizeMode = ControlSizeMode.FitWidth;

         _imageViewer.Zoom(sizeMode, scaleFactor, _imageViewer.DefaultZoomOrigin);

         UpdateMyControls();
      }

      private void _selectModeToolStripButton_Click(object sender, EventArgs e)
      {
         SetMode(noneMode);
      }

      private void _panModeToolStripButton_Click(object sender, EventArgs e)
      {
         SetMode(panZoomMode);
      }

      private void _zoomToSelectionToolStripButton_Click(object sender, EventArgs e)
      {
         SetMode(zoomToMode);
      }

      public void SetMode(ImageViewerInteractiveMode modeToSet)
      {
         if (_imageViewer.Image == null)
            return;

         _imageViewer.InteractiveModes.BeginUpdate();
         foreach (ImageViewerInteractiveMode mode in _imageViewer.InteractiveModes)
         {
            if (mode == modeToSet)
               mode.IsEnabled = true;
            else
               mode.IsEnabled = false;
         }
         _imageViewer.InteractiveModes.EndUpdate();

         UpdateMyControls();
      }

      public RasterImage RasterImage
      {
         get
         {
            return _imageViewer.Image;
         }
         set
         {
            _imageViewer.Image = value;
            UpdateMyControls();
         }
      }

      public ImageViewerNoneInteractiveMode NoneInteractiveMode
      {
         get
         {
            return noneMode;
         }
      }

      public ImageViewerPanZoomInteractiveMode PanZoomInteractiveMode
      {
         get
         {
            return panZoomMode;
         }
      }

      public ImageViewerZoomToInteractiveMode ZoomToInteractiveMode
      {
         get
         {
            return zoomToMode;
         }
      }

      public ImageViewer ImageViewer
      {
         get
         {
            return _imageViewer;
         }
      }
   }
}
