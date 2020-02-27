// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
//using System.Windows.Forms;

using Leadtools;
using Leadtools.Mrc;
using Leadtools.Demos;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Color;

using Leadtools.Drawing;
using System.Drawing.Drawing2D;

namespace MrcSegmentationDemo
{
   /// <summary>
   /// Summary description for ViewerForm.
   /// </summary>
   public class ViewerForm : System.Windows.Forms.Form
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public ViewerForm( )
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         InitClass();
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if(disposing)
         {
            if(components != null)
            {
               components.Dispose();
            }
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent( )
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerForm));
         this._cmenuCombine = new System.Windows.Forms.ContextMenu();
         this._cmenuCombineSegments = new System.Windows.Forms.MenuItem();
         this._cmenuEnlargeSegment = new System.Windows.Forms.MenuItem();
         this._cmenuShowInNewWindow = new System.Windows.Forms.MenuItem();
         this._cmenuSeperator1 = new System.Windows.Forms.MenuItem();
         this._cmenuShowType = new System.Windows.Forms.MenuItem();
         this._cmenuShowProperties = new System.Windows.Forms.MenuItem();
         this._cmenuShowHistogram = new System.Windows.Forms.MenuItem();
         this._cmenuUniqueColors = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // _cmenuCombine
         // 
         this._cmenuCombine.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._cmenuCombineSegments,
            this._cmenuEnlargeSegment,
            this._cmenuShowInNewWindow,
            this._cmenuSeperator1,
            this._cmenuShowType,
            this._cmenuShowProperties,
            this._cmenuShowHistogram,
            this._cmenuUniqueColors});
         this._cmenuCombine.Popup += new System.EventHandler(this._cmenuCombine_Popup);
         // 
         // _cmenuCombineSegments
         // 
         this._cmenuCombineSegments.Index = 0;
         this._cmenuCombineSegments.Text = "Combine Segments";
         this._cmenuCombineSegments.Click += new System.EventHandler(this._cmenuCombineSegments_Click);
         // 
         // _cmenuEnlargeSegment
         // 
         this._cmenuEnlargeSegment.Index = 1;
         this._cmenuEnlargeSegment.Text = "Enlarge Segment";
         this._cmenuEnlargeSegment.Click += new System.EventHandler(this._cmenuEnlargeSegment_Click);
         // 
         // _cmenuShowInNewWindow
         // 
         this._cmenuShowInNewWindow.Index = 2;
         this._cmenuShowInNewWindow.Text = "Show In New Window";
         this._cmenuShowInNewWindow.Click += new System.EventHandler(this._cmenuShowInNewWindow_Click);
         // 
         // _cmenuSeperator1
         // 
         this._cmenuSeperator1.Index = 3;
         this._cmenuSeperator1.Text = "-";
         // 
         // _cmenuShowType
         // 
         this._cmenuShowType.Index = 4;
         this._cmenuShowType.Text = "Show Type...";
         this._cmenuShowType.Click += new System.EventHandler(this._cmenuShowType_Click);
         // 
         // _cmenuShowProperties
         // 
         this._cmenuShowProperties.Index = 5;
         this._cmenuShowProperties.Text = "Show Properties...";
         this._cmenuShowProperties.Click += new System.EventHandler(this._cmenuShowProperties_Click);
         // 
         // _cmenuShowHistogram
         // 
         this._cmenuShowHistogram.Index = 6;
         this._cmenuShowHistogram.Text = "Show Histogram...";
         this._cmenuShowHistogram.Click += new System.EventHandler(this._cmenuShowHistogram_Click);
         // 
         // _cmenuUniqueColors
         // 
         this._cmenuUniqueColors.Index = 7;
         this._cmenuUniqueColors.Text = "Unique Colors...";
         this._cmenuUniqueColors.Click += new System.EventHandler(this._cmenuUniqueColors_Click);
         // 
         // ViewerForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(724, 448);
         this.ContextMenu = this._cmenuCombine;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "ViewerForm";
         this.ShowInTaskbar = false;
         this.Text = "ViewerForm";
         this.Deactivate += new System.EventHandler(this.ViewerForm_Deactivate);
         this.Closed += new System.EventHandler(this.ViewerForm_Closed);
         this.ResumeLayout(false);

      }
      #endregion

      private ImageViewer _viewer;
      private string _name;
      private MrcSegmenter _mrcSegmenter;
      private MrcSegmentData[] _segmentsData;
      private int _index;
      private int _selectedSegment;
      private int _selectedCombineSegment;
      private Rectangle[] _selectionRectangle;
      private Rectangle[] _selectionCombineRectangle;
      private bool _resizeSegment;
      private ContextMenu _cmenuCombine;
      private MenuItem _cmenuCombineSegments;
      private MrcEnumerateSegmentsInfo _callback;
      private bool _mrcStart;
      private bool _addSegment;
      private bool _drawNewSegment;
      private int _resizeIndex;
      private bool _enableUndo;
      private bool _moveSegment;
      private Point _movePoint;
      private Rectangle _drawRectangle;
      private Rectangle _preResize;
      private bool _optionsChanged;
      private MrcSegmenter _previousSegmenter;
      private bool _multiSelection;
      private bool[] _selectionArray;
      //      private MrcSegmenter _testSegmenter;

      private System.Windows.Forms.MenuItem _cmenuEnlargeSegment;
      private System.Windows.Forms.MenuItem _cmenuShowInNewWindow;
      private System.Windows.Forms.MenuItem _cmenuShowType;
      private System.Windows.Forms.MenuItem _cmenuShowProperties;
      private System.Windows.Forms.MenuItem _cmenuShowHistogram;
      private System.Windows.Forms.MenuItem _cmenuUniqueColors;
      private System.Windows.Forms.MenuItem _cmenuSeperator1;

      public bool OptionsChanged
      {
         get
         {
            return _optionsChanged;
         }
         set
         {
            _optionsChanged = value;
         }
      }

      public MrcSegmenter ViewerSegmenter
      {
         get
         {
            return _mrcSegmenter;
         }
      }

      public bool EnableUndo
      {
         get
         {
            return _enableUndo;
         }
      }

      public int SelectedSegment
      {
         get
         {
            return _selectedSegment;
         }
         set
         {
            _selectedSegment = value;
         }
      }

      public int SelectedCombineSegment
      {
         get
         {
            return _selectedCombineSegment;
         }
      }

      public bool MrcStarted
      {
         get
         {
            return _mrcStart;
         }
      }

      public RasterImage Image
      {
         get
         {
            return _viewer.Image;
         }
      }

      public ImageViewer Viewer
      {
         get
         {
            return _viewer;
         }
      }

      public bool AddSegment
      {
         get
         {
            return _addSegment;
         }
         set
         {
            _addSegment = value;
         }
      }

      public bool DrawNewSegment
      {
         get
         {
            return _drawNewSegment;
         }
         set
         {
            _drawNewSegment = value;
         }
      }

      private void InitClass( )
      {
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BorderStyle = BorderStyle.None;
         _viewer.ImeModeChanged += new EventHandler(_viewer_SizeModeChanged);
         _viewer.DragEnter += new DragEventHandler(_viewer_DragEnter);
         _viewer.DragDrop += new DragEventHandler(_viewer_DragDrop);
         _viewer.PostRender +=new EventHandler<ImageViewerRenderEventArgs>(_viewer_PostRender);
         _viewer.MouseDown += new MouseEventHandler(_viewer_mouseDown);
         _viewer.MouseUp += new MouseEventHandler(_viewer_mouseUp);
         _viewer.MouseMove += new MouseEventHandler(_viewer_mouseMove);
         _viewer.KeyDown += new KeyEventHandler(_viewer_KeyDown);
         Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.AllowDrop = true;

         _callback = new MrcEnumerateSegmentsInfo(MrcEnumerateSegmentInfoCallback);

         _selectedSegment = -1;
         _selectedCombineSegment = -1;
         _index = 1;

         _mrcStart = false;
         _addSegment = false;
         _moveSegment = false;
         _drawNewSegment = false;
         _optionsChanged = false;
         _cmenuCombineSegments.Enabled = false;

         _segmentsData = new MrcSegmentData[_index];
         _selectionArray = new bool[_index];

         _selectionRectangle = new Rectangle[8];
         _selectionCombineRectangle = new Rectangle[8];
      }

      void _viewer_PostRender(object sender, ImageViewerRenderEventArgs e)
      {
         Font drawFont = new Font("Arial", 9, FontStyle.Bold);

         try
         {
            Graphics g = e.PaintEventArgs.Graphics;
            Transformer t = new Transformer(Tools.ToMatrix(_viewer.ImageTransform));

            if (_mrcStart)
            {
               for (int index = 0; index < _segmentsData.Length; index++)
               {
                  Rectangle segmentRect = Leadtools.Demos.Converters.ConvertRect(_segmentsData[index].ImageSegment);
                  segmentRect = Rectangle.Round(t.RectangleToPhysical(segmentRect));

                  g.DrawRectangle(Pens.Red, segmentRect);

                  string text = string.Empty;
                  if (_segmentsData[index].SegmentType == MrcSegmentType.Background)
                     text = "BG";
                  else if (_segmentsData[index].SegmentType == MrcSegmentType.OneColor)
                     text = "1C";
                  else if (_segmentsData[index].SegmentType == MrcSegmentType.Text2BitBw)
                     text = "T2BW";
                  else if (_segmentsData[index].SegmentType == MrcSegmentType.Text1BitBw)
                     text = "T1BW";
                  else if (_segmentsData[index].SegmentType == MrcSegmentType.Text1BitColor)
                     text = "T1C";
                  else if (_segmentsData[index].SegmentType == MrcSegmentType.Text2BitColor)
                     text = "T2C";
                  else if (_segmentsData[index].SegmentType == MrcSegmentType.Grayscale2Bit)
                     text = "G2";
                  else if (_segmentsData[index].SegmentType == MrcSegmentType.Grayscale8Bit)
                     text = "G8";
                  else if (_segmentsData[index].SegmentType == MrcSegmentType.Picture)
                     text = "P";

                  if (((MainForm)MdiParent).ShowSegmentType)
                  {
                     Point textStart = new Point(segmentRect.Left + 5, segmentRect.Top + 5);
                     Size textSize = Size.Round(g.MeasureString(text, drawFont));
                     Rectangle textRect = new Rectangle(textStart.X, textStart.Y, textSize.Width + 1, textSize.Height + 1);
                     g.FillRectangle(Brushes.White, textRect);
                     g.DrawString(text, drawFont, Brushes.Black, textRect);
                  }
               }

               if (_mrcStart && _selectedSegment != -2)
               {
                  if (_selectedSegment != -1)
                  {
                     _selectionArray[_selectedSegment] = true;
                     if (_multiSelection)
                     {
                        for (int index = 0; index < _index - 1; index++)
                        {
                           if (_selectionArray[index])
                           {
                              GetSelectionRectangles(index);
                              for (int index1 = 0; index1 < 8; index1++)
                              {
                                 Rectangle rc = _selectionRectangle[index1];
                                 rc = Rectangle.Round(t.RectangleToPhysical(rc));
                                 g.FillRectangle(Brushes.White, rc);
                                 g.DrawRectangle(Pens.Black, rc);
                              }
                           }
                        }
                     }
                     else
                     {
                        for (int index = 0; index < 8; index++)
                        {
                           Rectangle rc = _selectionRectangle[index];
                           rc = Rectangle.Round(t.RectangleToPhysical(rc));
                           g.FillRectangle(Brushes.White, rc);
                           g.DrawRectangle(Pens.Black, rc);

                           if (_selectedCombineSegment != -1)
                           {
                              rc = _selectionCombineRectangle[index];
                              rc = Rectangle.Round(t.RectangleToPhysical(rc));
                              g.FillRectangle(Brushes.White, rc);
                              g.DrawRectangle(Pens.Black, rc);
                           }
                        }
                     }
                  }
                  else
                  {
                     for (int index1 = 0; index1 < _index - 1; index1++)
                     {
                        if (_selectionArray[index1])
                        {
                           GetSelectionRectangles(index1);
                           for (int index = 0; index < 8; index++)
                           {
                              Rectangle rc = _selectionRectangle[index];
                              rc = Rectangle.Round(t.RectangleToPhysical(rc));
                              g.FillRectangle(Brushes.White, rc);
                              g.DrawRectangle(Pens.Black, rc);
                           }
                        }
                     }
                  }
               }
            }

            if (_addSegment && _drawNewSegment)
            {
               Rectangle rc = DemosGlobal.FixRectangle(_drawRectangle);
               g.DrawRectangle(Pens.Red, rc);
            }
         }
         finally
         {
            drawFont.Dispose();
         }

      }

      public void Initialize(ImageInformation info, RasterPaintProperties paintProperties, bool snap)
      {
         _viewer.BeginUpdate();
         UpdatePaintProperties(paintProperties);
         _viewer.Image = info.Image;
         if(_viewer.Image != null)
            _viewer.Image.Changed += new EventHandler<RasterImageChangedEventArgs>(Image_Changed);
         _name = info.Name;
         if(snap)
            Snap();
         UpdateCaption();
         _viewer.EndUpdate();
      }

      public void UpdatePaintProperties(RasterPaintProperties paintProperties)
      {
         _viewer.PaintProperties = paintProperties;
      }

      private void UpdateCaption( )
      {
         Text = string.Format(_name);
      }

      private void Image_Changed(object sender, RasterImageChangedEventArgs e)
      {
         UpdateCaption();
         if(MdiParent != null)
            ((MainForm)MdiParent).UpdateControls();
      }

      private void _viewer_SizeModeChanged(object sender, EventArgs e)
      {
         ((MainForm)MdiParent).UpdateControls();
      }

      public void Snap( )
      {
         _viewer.ClientSize = _viewer.ClientRectangle.Size;
         ClientSize = _viewer.ClientSize;
      }

      private void _viewer_DragEnter(object sender, DragEventArgs e)
      {
         if(Tools.CanDrop(e.Data))
            e.Effect = DragDropEffects.Copy;
      }

      private void _viewer_DragDrop(object sender, DragEventArgs e)
      {
         if(Tools.CanDrop(e.Data))
         {
            ClearSegments();
            string[] files = Tools.GetDropFiles(e.Data);
            if(files != null)
               ((MainForm)MdiParent).LoadDropFiles(this, files);
         }
      }

      public MrcSegmenter GetNewSegmenter( )
      {
         MainForm mainForm = ((MainForm)MdiParent);
         return (new MrcSegmenter(_viewer.Image, Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._backColor), Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._foreColor)));

      }

      public void SetValuesToDialog(ref Options optionsDialog)
      {
         MainForm mainForm = ((MainForm)MdiParent);
         //    Color:
         optionsDialog.foregroundColor = mainForm._foreColor;
         optionsDialog.backgroundColor = mainForm._backColor;

         //    Mrc:
         optionsDialog.tempPictureCoder = mainForm._pictureCoder;
         optionsDialog.tempGrayscaleCoder8Bit = mainForm._grayscaleCoder8Bit;
         optionsDialog.tempTextCoder2Bit = mainForm._textCoder2Bit;
         optionsDialog.tempGrayscaleCoder2Bit = mainForm._grayscaleCoder2Bit;
         optionsDialog.tempMaskCode = mainForm._maskCoder;
         optionsDialog.tempQFactor = mainForm._qFactor;
         optionsDialog.tempGSQFactor = mainForm._gSQFactor;

         //    PDF:
         optionsDialog.tempPDFPictureCoder = mainForm._pDFPictureCoder;
         optionsDialog.tempPDFTextCoder2Bit = mainForm._pDFTextCoder2Bit;
         optionsDialog.tempPDFMaskCoder = mainForm._pDFMaskCoder;
         optionsDialog.tempPDFQFactor = mainForm._pDFQFactor;

         //    Segmentation:
         optionsDialog.tempInputImageType = mainForm._inputImageType;
         optionsDialog.tempOutputImageType = mainForm._outputImageType;

         optionsDialog.tempBGThreshold = mainForm._bGThreshold;
         optionsDialog.tempCleanSize = mainForm._cleanSize;
         optionsDialog.tempCombineThreshold = mainForm._combineThreshold;
         optionsDialog.tempQuality = mainForm._quality;
         optionsDialog.tempClrThreshold = mainForm._clrThreshold;
         optionsDialog.tempTypeIndex = mainForm._typeIndex;
         optionsDialog.tempCheck = mainForm._check;

         optionsDialog.tempUserDefineBGThreshold = mainForm._userDefineBGThreshold;
         optionsDialog.tempUserDefineCleanSize = mainForm._userDefineCleanSize;
         optionsDialog.tempUserDefineCombineThreshold = mainForm._userDefineCombineThreshold;
         optionsDialog.tempUserDefineQuality = mainForm._userDefineQuality;
         optionsDialog.tempUserDefineClrThreshold = mainForm._userDefineclrThreshold;
         optionsDialog.tempUserDefineTypeIndex = mainForm._userDefineTypeIndex;
         optionsDialog.tempUserDefineCheck = mainForm._userDefineCheck;

         //    Combine:
         optionsDialog.tempCombineFactor = mainForm._combineFactor;
         optionsDialog.tempCombineType = mainForm._combineType;
      }

      public void SetValuesToVariables(Options optionsDialog)
      {
         MainForm mainForm = ((MainForm)MdiParent);
         //    Color:
         mainForm._foreColor = optionsDialog.foregroundColor;
         mainForm._backColor = optionsDialog.backgroundColor;

         //    Mrc:
         mainForm._pictureCoder = optionsDialog.tempPictureCoder;
         mainForm._grayscaleCoder8Bit = optionsDialog.tempGrayscaleCoder8Bit;
         mainForm._textCoder2Bit = optionsDialog.tempTextCoder2Bit;
         mainForm._grayscaleCoder2Bit = optionsDialog.tempGrayscaleCoder2Bit;
         mainForm._maskCoder = optionsDialog.tempMaskCode;
         mainForm._qFactor = optionsDialog.tempQFactor;
         mainForm._gSQFactor = optionsDialog.tempGSQFactor;

         //    PDF:
         mainForm._pDFPictureCoder = optionsDialog.tempPDFPictureCoder;
         mainForm._pDFTextCoder2Bit = optionsDialog.tempPDFTextCoder2Bit;
         mainForm._pDFMaskCoder = optionsDialog.tempPDFMaskCoder;
         mainForm._pDFQFactor = optionsDialog.tempPDFQFactor;

         //    Segmentation
         mainForm._inputImageType = optionsDialog.tempInputImageType;
         mainForm._outputImageType = optionsDialog.tempOutputImageType;

         mainForm._bGThreshold = optionsDialog.tempBGThreshold;
         mainForm._cleanSize = optionsDialog.tempCleanSize;
         mainForm._combineThreshold = optionsDialog.tempCombineThreshold;
         mainForm._quality = optionsDialog.tempQuality;
         mainForm._clrThreshold = optionsDialog.tempClrThreshold;
         mainForm._typeIndex = optionsDialog.tempTypeIndex;
         mainForm._check = optionsDialog.tempCheck;

         mainForm._userDefineBGThreshold = optionsDialog.tempUserDefineBGThreshold;
         mainForm._userDefineCleanSize = optionsDialog.tempUserDefineCleanSize;
         mainForm._userDefineCombineThreshold = optionsDialog.tempUserDefineCombineThreshold;
         mainForm._userDefineQuality = optionsDialog.tempUserDefineQuality;
         mainForm._userDefineclrThreshold = optionsDialog.tempUserDefineClrThreshold;
         mainForm._userDefineTypeIndex = optionsDialog.tempUserDefineTypeIndex;
         mainForm._userDefineCheck = optionsDialog.tempUserDefineCheck;

         //    Combine:
         mainForm._combineFactor = optionsDialog.tempCombineFactor;
         mainForm._combineType = optionsDialog.tempCombineType;

      }

      private bool MrcEnumerateSegmentInfoCallback(MrcSegmenter segmentHandle, MrcSegmentData data, int id)
      {
         AddToSegment(data);
         return true;
      }

      private void RefreshSegments( )
      {
         _index = 1;
         _segmentsData = new MrcSegmentData[_index];
         _selectionArray = new bool[_index];

         _mrcSegmenter.EnumerateSegments(_callback);

         if(_index > 1)
            _selectedSegment = 0;
         else
            _selectedSegment = -2;
         _selectedCombineSegment = -1;
         _multiSelection = false;

         if(_mrcSegmenter.EnumerateSegments(null) == 0)
            _mrcStart = false;

         SetSelectionRectangles(_selectedSegment);
         ((MainForm)MdiParent).UpdateControls();
         _viewer.Invalidate(true);
      }

      private MrcSegmentImageFlags GetSegmentImageFlags(int index, bool searchBackground)
      {
         switch(index)
         {
            case 0:
               return (MrcSegmentImageFlags.FavorOneBit |
                  ((searchBackground) ? MrcSegmentImageFlags.SegmentWithBackground :
                  MrcSegmentImageFlags.SegmentWithOutBackground));
            case 1:
               return (MrcSegmentImageFlags.FavorTwoBit |
                  ((searchBackground) ? MrcSegmentImageFlags.SegmentWithBackground :
                  MrcSegmentImageFlags.SegmentWithOutBackground));
            case 2:
               return (MrcSegmentImageFlags.ForceOneBit |
                  ((searchBackground) ? MrcSegmentImageFlags.SegmentWithBackground :
                  MrcSegmentImageFlags.SegmentWithOutBackground));
            default:
               return (MrcSegmentImageFlags.ForceTwoBit |
                 ((searchBackground) ? MrcSegmentImageFlags.SegmentWithBackground :
                 MrcSegmentImageFlags.SegmentWithOutBackground));
         }
      }
      public void StartAutoMrcSegmentation(bool preserveManual)
      {
         MainForm mainForm = ((MainForm)MdiParent);

         MrcSegmentImageOptions segmentImageOptions = new MrcSegmentImageOptions();

         if(mainForm._inputImageType == 6)
         {
            segmentImageOptions.BackgroundThreshold = mainForm._userDefineBGThreshold;
            segmentImageOptions.CleanSize = mainForm._userDefineCleanSize;
            segmentImageOptions.ColorThreshold = mainForm._userDefineclrThreshold;
         }
         else
         {
            segmentImageOptions.BackgroundThreshold = mainForm._bGThreshold;
            segmentImageOptions.CleanSize = mainForm._cleanSize;
            segmentImageOptions.ColorThreshold = mainForm._clrThreshold;
         }

         if(mainForm._outputImageType == 5)
         {
            segmentImageOptions.CombineThreshold = mainForm._userDefineCombineThreshold;
            segmentImageOptions.Flags = GetSegmentImageFlags(mainForm._userDefineTypeIndex, mainForm._userDefineCheck) | MrcSegmentImageFlags.NormalSegmentation;
            segmentImageOptions.SegmentQuality = mainForm._userDefineQuality;
         }
         else
         {
            segmentImageOptions.CombineThreshold = mainForm._combineThreshold;
            segmentImageOptions.Flags = GetSegmentImageFlags(mainForm._typeIndex, mainForm._check) | MrcSegmentImageFlags.NormalSegmentation;
            segmentImageOptions.SegmentQuality = mainForm._quality;
         }

         if(!preserveManual)
            ClearSegments();

         try
         {
            _mrcSegmenter.SegmentImage(_viewer.Image, segmentImageOptions);
         }
         catch(Exception ex)
         {
            MrcError("An error occurred while trying to segment the image.", ex);
         }

         _mrcStart = true;

         RefreshSegments();

         SetSelectionRectangles(_selectedSegment);

         _resizeSegment = false;
         _optionsChanged = false;
         ((MainForm)MdiParent).UpdateControls();
      }

      private void GetSelectionRectangles(int index)
      {
         int x1, y1;

         x1 = _segmentsData[index].ImageSegment.Left - 2;
         y1 = _segmentsData[index].ImageSegment.Top - 2;
         _selectionRectangle[0] = new Rectangle(x1, y1, 5, 5);

         x1 = _segmentsData[index].ImageSegment.Left +
            (_segmentsData[index].ImageSegment.Width / 2) - 2;
         y1 = _segmentsData[index].ImageSegment.Top - 2;
         _selectionRectangle[1] = new Rectangle(x1, y1, 5, 5);

         x1 = _segmentsData[index].ImageSegment.Right - 2;
         y1 = _segmentsData[index].ImageSegment.Top - 2;
         _selectionRectangle[2] = new Rectangle(x1, y1, 5, 5);

         x1 = _segmentsData[index].ImageSegment.Left - 2;
         y1 = _segmentsData[index].ImageSegment.Top +
            (_segmentsData[index].ImageSegment.Height / 2) - 2;
         _selectionRectangle[3] = new Rectangle(x1, y1, 5, 5);

         x1 = _segmentsData[index].ImageSegment.Right - 2;
         y1 = _segmentsData[index].ImageSegment.Top +
            (_segmentsData[index].ImageSegment.Height / 2) - 2;
         _selectionRectangle[4] = new Rectangle(x1, y1, 5, 5);

         x1 = _segmentsData[index].ImageSegment.Left - 2;
         y1 = _segmentsData[index].ImageSegment.Bottom - 2;
         _selectionRectangle[5] = new Rectangle(x1, y1, 5, 5);

         x1 = _segmentsData[index].ImageSegment.Left +
            (_segmentsData[index].ImageSegment.Width / 2) - 2;
         y1 = _segmentsData[index].ImageSegment.Bottom - 2;
         _selectionRectangle[6] = new Rectangle(x1, y1, 5, 5);

         x1 = _segmentsData[index].ImageSegment.Right - 2;
         y1 = _segmentsData[index].ImageSegment.Bottom - 2;
         _selectionRectangle[7] = new Rectangle(x1, y1, 5, 5);
      }

      private void SetSelectionRectangles(int index)
      {
         int x1;
         int y1;

         if(_mrcStart)
         {
            if(_selectedCombineSegment != -1)
            {
               x1 = _segmentsData[_selectedCombineSegment].ImageSegment.Left - 2;
               y1 = _segmentsData[_selectedCombineSegment].ImageSegment.Top - 2;
               _selectionCombineRectangle[0] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedCombineSegment].ImageSegment.Left +
                  (_segmentsData[_selectedCombineSegment].ImageSegment.Width / 2) - 2;
               y1 = _segmentsData[_selectedCombineSegment].ImageSegment.Top - 2;
               _selectionCombineRectangle[1] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedCombineSegment].ImageSegment.Right - 2;
               y1 = _segmentsData[_selectedCombineSegment].ImageSegment.Top - 2;
               _selectionRectangle[2] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedCombineSegment].ImageSegment.Left - 2;
               y1 = _segmentsData[_selectedCombineSegment].ImageSegment.Top +
                  (_segmentsData[_selectedCombineSegment].ImageSegment.Height / 2) - 2;
               _selectionCombineRectangle[3] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedCombineSegment].ImageSegment.Right - 2;
               y1 = _segmentsData[_selectedCombineSegment].ImageSegment.Top +
                  (_segmentsData[_selectedCombineSegment].ImageSegment.Height / 2) - 2;
               _selectionCombineRectangle[4] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedCombineSegment].ImageSegment.Left - 2;
               y1 = _segmentsData[_selectedCombineSegment].ImageSegment.Bottom - 2;
               _selectionCombineRectangle[5] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedCombineSegment].ImageSegment.Left +
                  (_segmentsData[_selectedCombineSegment].ImageSegment.Width / 2) - 2;
               y1 = _segmentsData[_selectedCombineSegment].ImageSegment.Bottom - 2;
               _selectionCombineRectangle[6] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedCombineSegment].ImageSegment.Right - 2;
               y1 = _segmentsData[_selectedCombineSegment].ImageSegment.Bottom - 2;
               _selectionCombineRectangle[7] = new Rectangle(x1, y1, 5, 5);
            }

            if(_selectedSegment != -1 && _selectedSegment != -2)
            {
               x1 = _segmentsData[_selectedSegment].ImageSegment.Left - 2;
               y1 = _segmentsData[_selectedSegment].ImageSegment.Top - 2;
               _selectionRectangle[0] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedSegment].ImageSegment.Left +
                   (_segmentsData[_selectedSegment].ImageSegment.Width / 2) - 2;
               y1 = _segmentsData[_selectedSegment].ImageSegment.Top - 2;
               _selectionRectangle[1] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedSegment].ImageSegment.Right - 2;
               y1 = _segmentsData[_selectedSegment].ImageSegment.Top - 2;
               _selectionRectangle[2] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedSegment].ImageSegment.Left - 2;
               y1 = _segmentsData[_selectedSegment].ImageSegment.Top +
                   (_segmentsData[_selectedSegment].ImageSegment.Height / 2) - 2;
               _selectionRectangle[3] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedSegment].ImageSegment.Right - 2;
               y1 = _segmentsData[_selectedSegment].ImageSegment.Top +
                   (_segmentsData[_selectedSegment].ImageSegment.Height / 2) - 2;
               _selectionRectangle[4] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedSegment].ImageSegment.Left - 2;
               y1 = _segmentsData[_selectedSegment].ImageSegment.Bottom - 2;
               _selectionRectangle[5] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedSegment].ImageSegment.Left +
                   (_segmentsData[_selectedSegment].ImageSegment.Width / 2) - 2;
               y1 = _segmentsData[_selectedSegment].ImageSegment.Bottom - 2;
               _selectionRectangle[6] = new Rectangle(x1, y1, 5, 5);

               x1 = _segmentsData[_selectedSegment].ImageSegment.Right - 2;
               y1 = _segmentsData[_selectedSegment].ImageSegment.Bottom - 2;
               _selectionRectangle[7] = new Rectangle(x1, y1, 5, 5);
            }
         }
      }

      private void AddToSegment(MrcSegmentData mrcData)
      {
         MrcSegmentData[] tempMrcData = new MrcSegmentData[_index - 1];
         bool[] tempSelection = new bool[_index - 1];

         tempMrcData = _segmentsData;
         tempSelection = _selectionArray;

         _segmentsData = new MrcSegmentData[_index];
         _selectionArray = new bool[_index];

         Array.Copy(tempMrcData, _segmentsData, (_index - 1));
         Array.Copy(tempSelection, _selectionArray, (_index - 1));

         _segmentsData[(_index++) - 1] = mrcData;
         _selectionArray[_index - 2] = false;
      }

      public void SetSelectionArray(bool value)
      {
         for(int index = 0; index < _index - 1; index++)
         {
            _selectionArray[index] = value;
         }
      }

      private void _viewer_mouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if(e.Button == MouseButtons.Left)
         {
            if (e.X < _viewer.ClientRectangle.Width && e.Y < _viewer.ClientRectangle.Height)
            {
               if(_addSegment)
               {
                  _drawNewSegment = true;
                  _drawRectangle = new Rectangle(e.X, e.Y, 0, 0);
               }
               else if(this.Cursor == Cursors.SizeNWSE ||
                  this.Cursor == Cursors.SizeNS ||
                  this.Cursor == Cursors.SizeNESW ||
                  this.Cursor == Cursors.SizeWE)
               {
                  _resizeSegment = true;
                  _preResize = Leadtools.Demos.Converters.ConvertRect(_segmentsData[_selectedSegment].ImageSegment);
                  ((MainForm)MdiParent).CancelDrawing();
               }
               else if(this.Cursor == Cursors.SizeAll)
               {
                  _moveSegment = true;
                  _movePoint = new Point(e.X, e.Y);
                  ((MainForm)MdiParent).CancelDrawing();
               }
            }
         }
      }

      private void _viewer_mouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if(_drawNewSegment && e.Button == MouseButtons.Left)
         {
            SegmentTypeDialog segmentTypeDlg = new SegmentTypeDialog();

            _drawRectangle = DemosGlobal.FixRectangle(_drawRectangle);

            _drawNewSegment = false;
            if(!_drawRectangle.IsEmpty && segmentTypeDlg.ShowDialog() == DialogResult.OK)
            {
               AddToUndoList();
               MrcSegmentData mrcSegmentData = new MrcSegmentData();

               _drawRectangle.Width = Math.Max(15, _drawRectangle.Width);
               _drawRectangle.Height = Math.Max(15, _drawRectangle.Height);

               Transformer t = new Transformer(Tools.ToMatrix(_viewer.ImageTransform));

               mrcSegmentData.ImageSegment = Leadtools.Demos.Converters.ConvertRect(Rectangle.Round(t.RectangleToLogical(_drawRectangle)));
               mrcSegmentData.SegmentType = segmentTypeDlg.SegmentType;

               if(!_mrcStart)
               {
                  MainForm mainForm = ((MainForm)MdiParent);
                  _mrcSegmenter = new MrcSegmenter(_viewer.Image, Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._backColor), Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._foreColor));

                  _mrcStart = true;
               }

               mrcSegmentData.ImageSegment = new LeadRect(mrcSegmentData.ImageSegment.X, mrcSegmentData.ImageSegment.Y,
                  (Math.Min(_viewer.Image.Width, mrcSegmentData.ImageSegment.Right) - mrcSegmentData.ImageSegment.Left),
                  (Math.Min(_viewer.Image.Height, mrcSegmentData.ImageSegment.Bottom) - mrcSegmentData.ImageSegment.Top));

               if(mrcSegmentData.ImageSegment.Width < 10 ||
                  mrcSegmentData.ImageSegment.Height < 10)
                  return;

               int index = _mrcSegmenter.AddSegment(_viewer.Image, mrcSegmentData);
               AddToSegment(mrcSegmentData);
               SetSelectionRectangles(index);
               if(!_mrcStart)
                  _mrcStart = true;

               ((MainForm)MdiParent).PreserveManualMenuItem.Enabled = true;

               _selectedSegment = index;
            }
            _viewer.Invalidate(true);
         }
         else if(_resizeSegment)
         {
            AddToUndoList();
            _segmentsData[_selectedSegment].ImageSegment = new LeadRect(_segmentsData[_selectedSegment].ImageSegment.X,
               _segmentsData[_selectedSegment].ImageSegment.Y,
               (Math.Min(_viewer.Image.Width, _segmentsData[_selectedSegment].ImageSegment.Right) - _segmentsData[_selectedSegment].ImageSegment.Left),
               (Math.Min(_viewer.Image.Height, _segmentsData[_selectedSegment].ImageSegment.Bottom) - _segmentsData[_selectedSegment].ImageSegment.Top));
            _mrcSegmenter.SetSegmentData(_viewer.Image, _selectedSegment, _segmentsData[_selectedSegment]);
            RefreshSegments();
            _resizeSegment = false;
         }
         else if(_moveSegment && _selectedSegment != -2)
         {
            try
            {
               AddToUndoList();
               _mrcSegmenter.SetSegmentData(_viewer.Image, _selectedSegment, _segmentsData[_selectedSegment]);
               RefreshSegments();
            }
            catch(Exception ex)
            {
               MrcError("Could not update segment.", ex);
            }
         }

         if(_index > 1 && e.Button == MouseButtons.Left)
         {
            bool done = false;
            int index = 0;
            do
            {
               Transformer t = new Transformer(Tools.ToMatrix(_viewer.ImageTransform));
               Rectangle rc = Rectangle.Round(t.RectangleToPhysical(Leadtools.Demos.Converters.ConvertRect(_segmentsData[index].ImageSegment)));
               if(rc.Contains(e.X, e.Y))
               {
                  if((Control.ModifierKeys & Keys.Control) == Keys.Control)
                  {
                     if(_selectedCombineSegment == -1)
                     {
                        _selectedCombineSegment = index;
                        _selectionArray[_selectedCombineSegment] = true;
                        _cmenuCombineSegments.Enabled = true;
                        SetSelectionRectangles(_selectedCombineSegment);
                     }
                     else
                     {
                        _selectionArray[index] = !_selectionArray[index];
                        _multiSelection = true;
                     }
                  }
                  else
                  {
                     _selectedSegment = index;
                     _selectedCombineSegment = -1;
                     _multiSelection = false;
                     SetSelectionArray(false);
                  }
                  SetSelectionRectangles(_selectedSegment);
                  done = true;
               }

               index++;
            }
            while(index < _segmentsData.Length && !done);

            _viewer.Invalidate(true);
         }
         _moveSegment = false;
         _resizeSegment = false;
         ((MainForm)MdiParent).UpdateControls();
      }

      private void _viewer_mouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if(_multiSelection)
            return;

         if(_addSegment && _drawNewSegment)
         {
            int maxMinX = Math.Max(0, Math.Min(e.X, _viewer.ClientRectangle.Width));
            int maxMinY = Math.Max(0, Math.Min(e.Y, _viewer.ClientRectangle.Height));
            _drawRectangle = Rectangle.FromLTRB(_drawRectangle.Left, _drawRectangle.Top, maxMinX, maxMinY);
            _viewer.Invalidate(true);
         }
         else if(!_resizeSegment && _selectedSegment != -1 && _selectedSegment != -2)
         {
            if(_addSegment)
            {
               this.Cursor = Cursors.Cross;
            }
            else
            {
               Transformer t = new Transformer(Tools.ToMatrix(_viewer.ImageTransform));
               Point pt = Point.Round(t.PointToLogical(new Point(e.X, e.Y)));

               int index = 0;
               bool done = false;
               do
               {
                  if(_selectionRectangle[index].Contains(pt))
                     done = true;
                  else
                     index++;
               }
               while(index < 8 && !done);

               if(index != 8)
                  _resizeIndex = index;

               if(index == 8 && _mrcStart && _segmentsData[_selectedSegment].ImageSegment.Contains(Leadtools.Demos.Converters.ConvertPoint(pt)))
                  index = -1;

               switch (index)
               {
                  case 0:
                  case 7:
                     this.Cursor = Cursors.SizeNWSE;
                     break;
                  case 1:
                  case 6:
                     this.Cursor = Cursors.SizeNS;
                     break;
                  case 2:
                  case 5:
                     this.Cursor = Cursors.SizeNESW;
                     break;
                  case 3:
                  case 4:
                     this.Cursor = Cursors.SizeWE;
                     break;
                  case -1:
                     this.Cursor = Cursors.SizeAll;
                     break;
                  default:
                     this.Cursor = Cursors.Default;
                     break;
               }
            }
         }

         if(_moveSegment && _selectedSegment != -2)
         {
            Transformer t = new Transformer(Tools.ToMatrix(_viewer.ImageTransform));
            Point pt1 = Point.Round(t.PointToLogical(_movePoint));
            _movePoint = new Point(e.X, e.Y);
            Point pt2 = Point.Round(t.PointToLogical(_movePoint));

            int xDifference = pt2.X - pt1.X;
            int yDifference = pt2.Y - pt1.Y;
            int x = _segmentsData[_selectedSegment].ImageSegment.X;
            int y = _segmentsData[_selectedSegment].ImageSegment.Y;
            int width = _segmentsData[_selectedSegment].ImageSegment.Width;
            int height = _segmentsData[_selectedSegment].ImageSegment.Height;

            LeadRect rc = _segmentsData[_selectedSegment].ImageSegment;
            //rc.Offset(xDifference, yDifference);
            rc = new LeadRect(rc.Left + xDifference, rc.Top + yDifference, rc.Width, rc.Height);
            LeadRect imageRect = new LeadRect(0, 0, _viewer.Image.ImageWidth, _viewer.Image.ImageHeight);

            if(imageRect.Contains(rc))
               _segmentsData[_selectedSegment].ImageSegment = rc;

            _viewer.Invalidate(true);
         }

         if(_resizeSegment)
         {
            Transformer t = new Transformer(Tools.ToMatrix(_viewer.ImageTransform));
            int maxMinX = Math.Max(0, Math.Min(e.X, _viewer.ClientRectangle.Width));
            int maxMinY = Math.Max(0, Math.Min(e.Y, _viewer.ClientRectangle.Height));
            Point pt = Point.Round(t.PointToLogical(new Point(maxMinX, maxMinY)));

            int x = _segmentsData[_selectedSegment].ImageSegment.X;
            int y = _segmentsData[_selectedSegment].ImageSegment.Y;
            int width = _segmentsData[_selectedSegment].ImageSegment.Width;
            int height = _segmentsData[_selectedSegment].ImageSegment.Height;
            int right = _segmentsData[_selectedSegment].ImageSegment.Right;
            int bottom = _segmentsData[_selectedSegment].ImageSegment.Bottom;

            switch(_resizeIndex)
            {
               case 0:
                  if(pt.X < x)
                  {
                     width += Math.Abs(x - pt.X);
                     x = pt.X;
                  }
                  else
                  {
                     width -= Math.Abs(x - pt.X);
                     x = pt.X;
                  }
                  if(pt.Y < y)
                  {
                     height += Math.Abs(y - pt.Y);
                     y = pt.Y;
                  }
                  else
                  {
                     height -= Math.Abs(y - pt.Y);
                     y = pt.Y;
                  }
                  break;

               case 1:
                  if(pt.Y < y)
                  {
                     height += Math.Abs(y - pt.Y);
                     y = pt.Y;
                  }
                  else
                  {
                     height -= Math.Abs(y - pt.Y);
                     y = pt.Y;
                  }
                  break;

               case 2:
                  if(pt.X < right)
                  {
                     width -= Math.Abs(right - pt.X);
                  }
                  else
                  {
                     width += Math.Abs(right - pt.X);
                  }
                  if(pt.Y < y)
                  {
                     height += Math.Abs(y - pt.Y);
                     y = pt.Y;
                  }
                  else
                  {
                     height -= Math.Abs(y - pt.Y);
                     y = pt.Y;
                  }
                  break;

               case 3:
                  if(pt.X < x)
                  {
                     width += Math.Abs(x - pt.X);
                     x = pt.X;
                  }
                  else
                  {
                     width -= Math.Abs(x - pt.X);
                     x = pt.X;
                  }
                  break;

               case 4:
                  if(pt.X < right)
                  {
                     width -= Math.Abs(right - pt.X);
                  }
                  else
                  {
                     width += Math.Abs(right - pt.X);
                  }
                  break;

               case 5:
                  if(pt.X < x)
                  {
                     width += Math.Abs(x - pt.X);
                     x = pt.X;
                  }
                  else
                  {
                     width -= Math.Abs(x - pt.X);
                     x = pt.X;
                  }
                  if(pt.Y < bottom)
                  {
                     height -= Math.Abs(bottom - pt.Y);
                  }
                  else
                  {
                     height += Math.Abs(bottom - pt.Y);
                  }
                  break;

               case 6:
                  if(pt.Y < bottom)
                  {
                     height -= Math.Abs(bottom - pt.Y);
                  }
                  else
                  {
                     height += Math.Abs(bottom - pt.Y);
                  }
                  break;

               case 7:
                  if(pt.X < right)
                  {
                     width -= Math.Abs(right - pt.X);
                  }
                  else
                  {
                     width += Math.Abs(right - pt.X);
                  }
                  if(pt.Y < bottom)
                  {
                     height -= Math.Abs(bottom - pt.Y);
                  }
                  else
                  {
                     height += Math.Abs(bottom - pt.Y);
                  }
                  break;
            }

            if(width >= 10 && height >= 10)
            {
               _segmentsData[_selectedSegment].ImageSegment = new LeadRect(x, y, width, height);
            }

            _viewer.Invalidate(true);
         }

         SetSelectionRectangles(_selectedSegment);
      }

      private MrcCombineSegmentFlags GetCombineFlags(int index)
      {
         switch(index)
         {
            case 0:
               return MrcCombineSegmentFlags.CombineForce;
            case 1:
               return MrcCombineSegmentFlags.ForeSimilar;
            default:
               return MrcCombineSegmentFlags.TryFactor;
         }
      }

      public void CombineSegments( )
      {
         try
         {
            MainForm mainForm = ((MainForm)MdiParent);

            _mrcSegmenter.CombineSegments(_selectedSegment, _selectedCombineSegment,
               GetCombineFlags(mainForm._combineType), mainForm._combineFactor);

            _selectedCombineSegment = -1;
            RefreshSegments();
         }
         catch(Exception ex)
         {
            MrcError(string.Format("Error combining segments; the segments are of different types or not adjacent.{0}If you want to force combining segments of different types go to Preferences -> 'Segmentation and Compression Options. and change the combining type to (Force)", Environment.NewLine), ex);
         }
         _selectedCombineSegment = -1;
      }

      private void _cmenuCombineSegments_Click(object sender, System.EventArgs e)
      {
         AddToUndoList();
         CombineSegments();
      }

      public void DeleteSelectedSegment( )
      {
         if(_index > 1 && _selectedSegment != -2)
         {
            try
            {
               for(int index = 0; index < _index - 1; index++)
               {
                  if(_selectionArray[index])
                     _mrcSegmenter.DeleteSegment(index);
               }
               RefreshSegments();
            }
            catch(Exception ex)
            {
               MrcError("Error deleting segment.", ex);
            }
         }
      }

      public void SelectAllSegments( )
      {
         _selectedSegment = -1;
         _selectedCombineSegment = -1;
      }

      public void ClearSegments( )
      {
         MainForm mainForm = ((MainForm)MdiParent);

         _selectedCombineSegment = -1;
         _selectedSegment = -2;
         _index = 1;

         _mrcStart = false;
         _cmenuCombineSegments.Enabled = false;

         _segmentsData = new MrcSegmentData[_index];
         _selectionArray = new bool[_index];

         if(_mrcSegmenter != null)
            _mrcSegmenter.Dispose();

         try
         {
            _mrcSegmenter = new MrcSegmenter(_viewer.Image, Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._backColor), Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._foreColor));

         }
         catch(Exception ex)
         {
            MrcError("An error occurred while trying to initialize the segmentation process.", ex);
         }
         finally
         {
            _viewer.Invalidate(true);
            ((MainForm)MdiParent).UpdateControls();
         }
      }

      private bool CanEnlargeFromLeft(Rectangle leftRectangle, Rectangle selectedRectangle)
      {
         if((leftRectangle.Top <= selectedRectangle.Top) &&
            (leftRectangle.Bottom > selectedRectangle.Top) &&
            (leftRectangle.Bottom < selectedRectangle.Bottom) &&
            (leftRectangle.Right <= selectedRectangle.Left))
            return true;

         else if((leftRectangle.Top >= selectedRectangle.Top) &&
            (leftRectangle.Top < selectedRectangle.Bottom) &&
            (leftRectangle.Bottom > selectedRectangle.Top) &&
            (leftRectangle.Bottom <= selectedRectangle.Bottom) &&
            (leftRectangle.Right <= selectedRectangle.Left))
            return true;

         else if((leftRectangle.Top > selectedRectangle.Top) &&
            (leftRectangle.Top < selectedRectangle.Bottom) &&
            (leftRectangle.Bottom >= selectedRectangle.Bottom) &&
            (leftRectangle.Right <= selectedRectangle.Left))

            return true;
         else if((leftRectangle.Top <= selectedRectangle.Top) &&
            (leftRectangle.Bottom >= selectedRectangle.Bottom) &&
            (leftRectangle.Right <= selectedRectangle.Left))
            return true;
         else
            return false;
      }

      private bool CanEnlargeFromTop(Rectangle topRectangle, Rectangle selectedRectangle)
      {
         if((topRectangle.Left <= selectedRectangle.Left) &&
            (topRectangle.Right > selectedRectangle.Left) &&
            (topRectangle.Right < selectedRectangle.Right) &&
            (topRectangle.Bottom <= selectedRectangle.Top))

            return true;
         else if((topRectangle.Left >= selectedRectangle.Left) &&
            (topRectangle.Left < selectedRectangle.Right) &&
            (topRectangle.Right > selectedRectangle.Left) &&
            (topRectangle.Right <= selectedRectangle.Right) &&
            (topRectangle.Bottom <= selectedRectangle.Top))

            return true;

         else if((topRectangle.Left > selectedRectangle.Left) &&
            (topRectangle.Left < selectedRectangle.Right) &&
            (topRectangle.Right >= selectedRectangle.Right) &&
            (topRectangle.Bottom < selectedRectangle.Top))
            return true;
         else if((topRectangle.Left <= selectedRectangle.Left) &&
            (topRectangle.Right >= selectedRectangle.Right) &&
            (topRectangle.Bottom <= selectedRectangle.Top))

            return true;
         else
            return false;
      }

      private bool CanEnlargeFromRight(Rectangle rightRectangle, Rectangle selectedRectangle)
      {
         if((rightRectangle.Top <= selectedRectangle.Top) &&
            (rightRectangle.Bottom > selectedRectangle.Top) &&
            (rightRectangle.Bottom < selectedRectangle.Bottom) &&
            (rightRectangle.Left >= selectedRectangle.Right))
            return true;
         else if((rightRectangle.Top >= selectedRectangle.Top) &&
            (rightRectangle.Top < selectedRectangle.Bottom) &&
            (rightRectangle.Bottom > selectedRectangle.Top) &&
            (rightRectangle.Bottom <= selectedRectangle.Bottom) &&
            (rightRectangle.Left >= selectedRectangle.Right))

            return true;
         else if((rightRectangle.Top > selectedRectangle.Top) &&
            (rightRectangle.Top < selectedRectangle.Bottom) &&
            (rightRectangle.Bottom >= selectedRectangle.Bottom) &&
            (rightRectangle.Left >= selectedRectangle.Right))

            return true;
         else if((rightRectangle.Top <= selectedRectangle.Top) &&
            (rightRectangle.Bottom >= selectedRectangle.Bottom) &&
            (rightRectangle.Left >= selectedRectangle.Right))
            return true;
         else
            return false;
      }

      private bool CanEnlargeFromBottom(Rectangle bottomRectangle, Rectangle selectedRectangle)
      {
         if((bottomRectangle.Left <= selectedRectangle.Left) &&
            (bottomRectangle.Right > selectedRectangle.Left) &&
            (bottomRectangle.Right < selectedRectangle.Right) &&
            (bottomRectangle.Top >= selectedRectangle.Bottom))
            return true;
         else if((bottomRectangle.Left >= selectedRectangle.Left) &&
            (bottomRectangle.Left < selectedRectangle.Right) &&
            (bottomRectangle.Right > selectedRectangle.Left) &&
            (bottomRectangle.Right <= selectedRectangle.Right) &&
            (bottomRectangle.Top >= selectedRectangle.Bottom))
            return true;
         else if((bottomRectangle.Left > selectedRectangle.Left) &&
            (bottomRectangle.Left < selectedRectangle.Right) &&
            (bottomRectangle.Right >= selectedRectangle.Right) &&
            (bottomRectangle.Top >= selectedRectangle.Bottom))
            return true;
         else if((bottomRectangle.Left <= selectedRectangle.Left) &&
            (bottomRectangle.Right >= selectedRectangle.Right) &&
            (bottomRectangle.Top >= selectedRectangle.Bottom))
            return true;
         else
            return false;
      }

      public void EnlargeSegment( )
      {
         int index, left, right, top, bottom;
         Rectangle selectedRectangle, tempRectangle;

         left = 0;
         right = _viewer.Image.Width;
         top = 0;
         bottom = _viewer.Image.Height;

         selectedRectangle = Leadtools.Demos.Converters.ConvertRect(_segmentsData[_selectedSegment].ImageSegment);

         for(index = 0; index < _segmentsData.Length; index++)
         {
            if(index == _selectedSegment)
               continue;

            tempRectangle = Leadtools.Demos.Converters.ConvertRect(_segmentsData[index].ImageSegment);

            // Find the left value
            if(CanEnlargeFromLeft(tempRectangle, selectedRectangle))
            {
               left = Math.Max(left, tempRectangle.Right);
            }
         }

         for(index = 0; index < _segmentsData.Length; index++)
         {
            if(index == _selectedSegment)
               continue;

            tempRectangle = Leadtools.Demos.Converters.ConvertRect(_segmentsData[index].ImageSegment);

            // Find the left value
            if(CanEnlargeFromTop(tempRectangle, selectedRectangle))
            {
               top = Math.Max(top, tempRectangle.Bottom);
            }
         }

         for(index = 0; index < _segmentsData.Length; index++)
         {
            if(index == _selectedSegment)
               continue;

            tempRectangle = Leadtools.Demos.Converters.ConvertRect(_segmentsData[index].ImageSegment);

            // Find the left value
            if(CanEnlargeFromRight(tempRectangle, selectedRectangle))
            {
               right = Math.Min(right, tempRectangle.Left);
            }
         }

         for(index = 0; index < _segmentsData.Length; index++)
         {
            if(index == _selectedSegment)
               continue;

            tempRectangle = Leadtools.Demos.Converters.ConvertRect(_segmentsData[index].ImageSegment);

            // Find the left value
            if(CanEnlargeFromBottom(tempRectangle, selectedRectangle))
            {
               bottom = Math.Min(bottom, tempRectangle.Top);
            }
         }
         _segmentsData[_selectedSegment].ImageSegment = new LeadRect(left, top, (right - left), (bottom - top));

         _mrcSegmenter.SetSegmentData(_viewer.Image, _selectedSegment, _segmentsData[_selectedSegment]);
         RefreshSegments();
      }

      public void SaveLeadMrc(string fileName, RasterCodecs codecs, RasterImageFormat saveFormat)
      {
         MainForm mainForm = ((MainForm)MdiParent);
         MrcCompressionOptions compressionOptions = new MrcCompressionOptions();

         compressionOptions.PictureCoder = mainForm.GetPictureCompression(mainForm._pictureCoder);
         compressionOptions.Grayscale8BitCoder = mainForm.GetGrayscaleCompression8BitCoder(mainForm._grayscaleCoder8Bit);
         compressionOptions.Text2BitCoder = mainForm.GetTextCompressionCoder(mainForm._textCoder2Bit);
         compressionOptions.Grayscale2BitCoder = mainForm.GetGrayscaleCompression2BitCoder(mainForm._grayscaleCoder2Bit);
         compressionOptions.MaskCoder = mainForm.GetMaskCompression(mainForm._maskCoder);
         compressionOptions.PictureQualityFactor = mainForm._qFactor;
         compressionOptions.Grayscale8BitFactor = mainForm._gSQFactor;

         switch(compressionOptions.PictureCoder)
         {
            case MrcPictureCompression.LosslessJpeg:
            case MrcPictureCompression.LosslessCmw:
               compressionOptions.PictureQualityFactor = 0;
               break;
         }
         switch(compressionOptions.Grayscale8BitCoder)
         {
            case MrcGrayscaleCompression8BitCoder.LosslessCmw:
            case MrcGrayscaleCompression8BitCoder.LosslessJpeg:
               compressionOptions.Grayscale8BitFactor = 0;
               break;
         }

         if(_optionsChanged || _mrcSegmenter == null)
         {
            try
            {
               _mrcSegmenter = new MrcSegmenter(Image, Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._backColor), Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._foreColor));

               _optionsChanged = false;
            }
            catch(Exception ex)
            {
               MrcError("An error occurred while trying to initialize the segmentation process.", ex);
            }

            for(int index = 0; index < _index - 1; index++)
               _mrcSegmenter.AddSegment(Image, _segmentsData[index]);
         }

         try
         {
            if(saveFormat == RasterImageFormat.LeadMrc)
               _mrcSegmenter.SaveImage(_viewer.Image, fileName, MrcImageFormat.Mrc, compressionOptions, codecs);
            else if(saveFormat == RasterImageFormat.TifLeadMrc)
               _mrcSegmenter.SaveImage(_viewer.Image, fileName, MrcImageFormat.MrcTif, compressionOptions, codecs);
         }
         catch(Exception ex)
         {
            MrcError("An error occurred while trying to save the image as LEAD Mrc.", ex);
         }
      }

      public void SaveMrc(string fileName, RasterCodecs codecs, RasterImageFormat saveFormat)
      {
         MainForm mainForm = ((MainForm)MdiParent);
         MrcCompressionOptions compressionOptions = new MrcCompressionOptions();

         compressionOptions.PictureCoder = mainForm.GetPictureCompression(mainForm._pictureCoder);
         compressionOptions.Text2BitCoder = mainForm.GetTextCompressionCoder(mainForm._textCoder2Bit);
         compressionOptions.MaskCoder = mainForm.GetMaskCompression(mainForm._maskCoder);
         compressionOptions.PictureQualityFactor = mainForm._qFactor;

         if(compressionOptions.PictureCoder != MrcPictureCompression.Jpeg)
         {
            Messager.ShowWarning(this, "Invalid picture compression, it will be replaced with \"JPEG compression\".");
            compressionOptions.PictureCoder = MrcPictureCompression.Jpeg;
         }

         if(_optionsChanged || _mrcSegmenter == null)
         {
            try
            {
               _mrcSegmenter = new MrcSegmenter(Image, Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._backColor), Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._foreColor));

               _optionsChanged = false;
            }
            catch(Exception ex)
            {
               MrcError("An error occurred while trying to initialize the segmentation process.", ex);
            }

            for(int index = 0; index < _index - 1; index++)
               _mrcSegmenter.AddSegment(Image, _segmentsData[index]);
         }

         try
         {
            if(saveFormat == RasterImageFormat.Mrc)
               _mrcSegmenter.SaveImageT44(_viewer.Image, fileName, MrcT44ImageFormat.MrcT44, compressionOptions, codecs);
            else if(saveFormat == RasterImageFormat.TifMrc)
               _mrcSegmenter.SaveImageT44(_viewer.Image, fileName, MrcT44ImageFormat.MrcT44Tif, compressionOptions, codecs);
         }
         catch(Exception ex)
         {
            MrcError("An error occurred while trying to save the image as T44 Mrc.", ex);
         }

      }

      public void SavePDF(string fileName, RasterCodecs codecs)
      {
         MainForm mainForm = ((MainForm)MdiParent);
         MrcCompressionOptions compressionOptions = new MrcCompressionOptions();

         compressionOptions.MaskCoder = mainForm.GetPDF1Compression(mainForm._pDFMaskCoder);
         compressionOptions.PictureQualityFactor = mainForm._pDFQFactor;
         compressionOptions.PictureCoder = mainForm.GetPDFPictureCompression(mainForm._pDFPictureCoder);
         compressionOptions.Text2BitCoder = mainForm.GetPDF2Compression(mainForm._pDFTextCoder2Bit);

         if(_optionsChanged || _mrcSegmenter == null)
         {
            try
            {
               _mrcSegmenter = new MrcSegmenter(_viewer.Image, Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._backColor), Leadtools.Demos.Converters.FromGdiPlusColor(mainForm._foreColor));

               _optionsChanged = false;
            }
            catch(Exception ex)
            {
               MrcError("An error occurred while trying to initialize the segmentation process.", ex);
            }

            for(int index = 0; index < _index - 1; index++)
               _mrcSegmenter.AddSegment(_viewer.Image, _segmentsData[index]);
         }

         try
         {
            _mrcSegmenter.SaveImage(_viewer.Image, fileName, MrcImageFormat.MrcPdf, compressionOptions, codecs);
         }
         catch(Exception ex)
         {
            MrcError("An error occurred while trying to save the image as PDF.", ex);
         }
      }

      public void SaveSegments(string fileName)
      {
         try
         {
            _mrcSegmenter.Save(fileName);
         }
         catch(Exception ex)
         {
            MrcError("Error exporting segments.", ex);
         }
      }

      public void LoadSegments(string fileName)
      {
         ClearSegments();
         _mrcSegmenter = new MrcSegmenter(_viewer.Image, fileName);
         RefreshSegments();
         _mrcStart = true;
      }

      public RasterImage GetRectangleAsImage( )
      {
         try
         {
            // Make sure the coordinates are in the ViewPerspective of the _viewer.Image.
            _viewer.Image.RectangleFromImage(RasterViewPerspective.TopLeft, _segmentsData[_selectedSegment].ImageSegment);

            // Copy the rectangle.
            CopyRectangleCommand command = new CopyRectangleCommand();
            command.Rectangle = _segmentsData[_selectedSegment].ImageSegment;
            command.CreateFlags = RasterMemoryFlags.None;
            command.Run(_viewer.Image);

            return command.DestinationImage;
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex.Message);
            return null;
         }
      }

      public void ShowSegmentType( )
      {
         SegmentTypeDialog segmentTypeDlg = new SegmentTypeDialog();

         segmentTypeDlg.SegmentType = _segmentsData[_selectedSegment].SegmentType;

         if(segmentTypeDlg.ShowDialog() == DialogResult.OK)
         {
            AddToUndoList();
            _segmentsData[_selectedSegment].SegmentType = segmentTypeDlg.SegmentType;
            _mrcSegmenter.SetSegmentData(_viewer.Image, _selectedSegment, _segmentsData[_selectedSegment]);
            RefreshSegments();
         }
      }

      public void ShowSegmentHistogram( )
      {
         HistogramDialog histogramDialog =
            new HistogramDialog(GetRectangleAsImage());

         histogramDialog.ShowDialog();
      }

      public void ShowHistogram( )
      {
         HistogramDialog histogramDialog = new HistogramDialog(_viewer.Image);

         histogramDialog.ShowDialog();
      }

      public void GetUniqueColorsCount( )
      {
         ColorCountCommand command = new ColorCountCommand();

         command.Run(_viewer.Image);

         Messager.ShowInformation(this, "The image has " + command.ColorCount.ToString() + " colors.");
      }

      public void GetSegmentUniqueColorsCount( )
      {
         ColorCountCommand command = new ColorCountCommand();

         command.Run(GetRectangleAsImage());

         Messager.ShowInformation(this, "The Segment has " + command.ColorCount.ToString() + " colors.");
      }

      public void AddToUndoList( )
      {
         if(_mrcSegmenter != null && _index > 1)
         {
            _previousSegmenter = (MrcSegmenter)_mrcSegmenter.Clone();
            _enableUndo = true;
         }
      }

      public void Undo( )
      {
         if(_previousSegmenter != null)
         {
            _mrcSegmenter = (MrcSegmenter)_previousSegmenter.Clone();
            _selectedSegment = 0;
            SetSelectionRectangles(_selectedSegment);
            RefreshSegments();
            _mrcStart = true;
            _enableUndo = false;
            _multiSelection = false;
            ((MainForm)MdiParent).UpdateControls();
         }
      }

      public void ShowSegmentInformation( )
      {
         SegmentInformationDialog dlg = new SegmentInformationDialog
            (_segmentsData[_selectedSegment].SegmentType.ToString(), _viewer.Image.Width,
            _viewer.Image.Height);

         // The NewRight value should be filled before the NewLeft value because the
         // NewLeft value checks on the NewRight value for validation purposes...
         dlg.NewRight = _segmentsData[_selectedSegment].ImageSegment.Right;
         dlg.NewLeft = _segmentsData[_selectedSegment].ImageSegment.Left;

         // The NewBottom value should be filled before the NewTop value because the
         // NewTop value checks on the NewBottom value for validation purposes...
         dlg.NewBottom = _segmentsData[_selectedSegment].ImageSegment.Bottom;
         dlg.NewTop = _segmentsData[_selectedSegment].ImageSegment.Top;

         if(dlg.ShowDialog() == DialogResult.OK)
         {
            AddToUndoList();
            _segmentsData[_selectedSegment].ImageSegment =
               new LeadRect(dlg.NewLeft, dlg.NewTop, (dlg.NewRight - dlg.NewLeft), (dlg.NewBottom - dlg.NewTop));

            _mrcSegmenter.SetSegmentData(_viewer.Image, _selectedSegment, _segmentsData[_selectedSegment]);
            RefreshSegments();
         }
      }

      private void _cmenuCombine_Popup(object sender, System.EventArgs e)
      {
         if(_selectedSegment != -2 && !_multiSelection)
         {
            if(_index > 1 && _selectedSegment != -1)
            {
               ((MainForm)MdiParent).CancelDrawing();

               bool checkCombine = (_selectedCombineSegment == -1) ? false : true;

               _cmenuCombineSegments.Visible = checkCombine;
               _cmenuEnlargeSegment.Visible = !checkCombine;
               _cmenuShowInNewWindow.Visible = !checkCombine;
               _cmenuSeperator1.Visible = !checkCombine;
               _cmenuShowType.Visible = !checkCombine;
               _cmenuShowProperties.Visible = !checkCombine;
               _cmenuShowHistogram.Visible = !checkCombine;
               _cmenuUniqueColors.Visible = !checkCombine;
            }
            else
            {
               if(_index == 3)
               {
                  _cmenuCombineSegments.Visible = true;
                  _cmenuCombineSegments.Enabled = true;
                  _selectedSegment = 0;
                  _selectedCombineSegment = 1;
               }
               else
               {
                  _cmenuCombineSegments.Visible = false;
               }

               _cmenuEnlargeSegment.Visible = false;
               _cmenuShowInNewWindow.Visible = false;
               _cmenuSeperator1.Visible = false;
               _cmenuShowType.Visible = false;
               _cmenuShowProperties.Visible = false;
               _cmenuShowHistogram.Visible = false;
               _cmenuUniqueColors.Visible = false;
            }
         }
         else
         {
            _cmenuCombineSegments.Visible = false;
            _cmenuEnlargeSegment.Visible = false;
            _cmenuShowInNewWindow.Visible = false;
            _cmenuSeperator1.Visible = false;
            _cmenuShowType.Visible = false;
            _cmenuShowProperties.Visible = false;
            _cmenuShowHistogram.Visible = false;
            _cmenuUniqueColors.Visible = false;
         }
      }

      private void _cmenuEnlargeSegment_Click(object sender, System.EventArgs e)
      {
         AddToUndoList();
         EnlargeSegment();
      }

      private void _cmenuShowInNewWindow_Click(object sender, System.EventArgs e)
      {
         ((MainForm)MdiParent)._miViewShowInNewWindow_Click(sender, e);
      }

      private void _cmenuShowType_Click(object sender, System.EventArgs e)
      {
         ShowSegmentType();
      }

      private void _cmenuShowProperties_Click(object sender, System.EventArgs e)
      {
         ShowSegmentInformation();
      }

      private void _cmenuShowHistogram_Click(object sender, System.EventArgs e)
      {
         ShowSegmentHistogram();
      }

      private void _cmenuUniqueColors_Click(object sender, System.EventArgs e)
      {
         GetSegmentUniqueColorsCount();
      }

      private void MrcError(string message, Exception ex)
      {
         Messager.ShowError(this, string.Format("{0}{1}{1}Error: {2}", message, Environment.NewLine, ex.Message));
      }

      private void _viewer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
      {
         if(!e.Handled)
         {
            if(e.KeyCode == Keys.Add || e.KeyCode == Keys.Oemplus)
            {
               e.Handled = true;

               ((MainForm)MdiParent)._miView_Click(((MainForm)MdiParent).ZoomIn, null);
            }
            else if(e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
               e.Handled = true;

               ((MainForm)MdiParent)._miView_Click(((MainForm)MdiParent).ZoomOut, null);
            }
            else if(e.KeyCode == Keys.Escape)
            {
               e.Handled = true;

               ((MainForm)MdiParent).CancelDrawing();
            }
         }
      }

      private void ViewerForm_Closed(object sender, System.EventArgs e)
      {
         if(AddSegment)
            ((MainForm)MdiParent).CancelDrawing();
      }

      private void ViewerForm_Deactivate(object sender, System.EventArgs e)
      {
         if(AddSegment && _drawNewSegment)
            ((MainForm)MdiParent).CancelDrawing();
      }
   }
}
