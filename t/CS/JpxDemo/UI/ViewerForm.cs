// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.Drawing;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Effects;
using Leadtools.Jpeg2000;

namespace JPXDemo
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

      public ViewerForm(Form parent, bool isComposite)
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
         MdiParent = parent;
         IsComposite = isComposite;
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

            if(ImageListControl != null)
               ImageListControl.Items.Clear();

            if (ImagesList != null)
               ImagesList.Clear();

            if (ColorList != null)
               ColorList.Clear();

            if(OpacityList != null)
               OpacityList.Clear();

            if(PreOpacityList != null)
               PreOpacityList.Clear();
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
         this._pnlImageList = new System.Windows.Forms.Panel();
         this._pnlViewer = new System.Windows.Forms.Panel();
         this.SuspendLayout();
         // 
         // _pnlImageList
         // 
         this._pnlImageList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this._pnlImageList.Location = new System.Drawing.Point(0, 1);
         this._pnlImageList.Name = "_pnlImageList";
         this._pnlImageList.Size = new System.Drawing.Size(128, 376);
         this._pnlImageList.TabIndex = 0;
         // 
         // _pnlViewer
         // 
         this._pnlViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._pnlViewer.Location = new System.Drawing.Point(134, 1);
         this._pnlViewer.Name = "_pnlViewer";
         this._pnlViewer.Size = new System.Drawing.Size(678, 375);
         this._pnlViewer.TabIndex = 1;
         // 
         // ViewerForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(809, 373);
         this.Controls.Add(this._pnlViewer);
         this.Controls.Add(this._pnlImageList);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "ViewerForm";
         this.ShowInTaskbar = false;
         this.Text = "ViewerForm";
         this.Closed += new System.EventHandler(this.ViewerForm_Closed);
         this.Deactivate += new System.EventHandler(this.ViewerForm_Deactivate);
         this.ResumeLayout(false);

      }
      #endregion

      private ImageViewer _viewer;
      private ImageViewer _imageListControl;

      private List<RasterImage> _imagesList;
      private List<RasterImage> _colorList;
      private List<RasterImage> _opacityList;
      private List<RasterImage> _preOpacityList;
      private Panel _pnlImageList;
      private Panel _pnlViewer;
      private string _name;
      private ActiveImageLists _activeList;
      private bool _isComposite;
      private int _delay;
      private int _renderWidth;
      private int _renderHeight;
      private bool _playingAnnimation;
      private bool _stopAnimation;
      private bool _loopAnimation;

      private const int DefaultViewerWidth = 600;
      private const int DefaultViewerHeight = 600;
      private const int DefaultDelay = 100;

      public enum ActiveImageLists
      {
         ImagesList = 0,
         ColorList = 1,
         OpacityList = 2,
         PreOpacityList = 3,
      }

      public bool LoopAnimation
      {
         get
         {
            return _loopAnimation;
         }
         set
         {
            _loopAnimation = value;
         }
      }

      public bool StopAnimation
      {
         get
         {
            return _stopAnimation;
         }
         set
         {
            _stopAnimation = value;
         }
      }

      public int RenderHeight
      {
         get
         {
            return _renderHeight;
         }
         set
         {
            _renderHeight = value;
         }
      }

      public int RenderWidth
      {
         get
         {
            return _renderWidth;
         }
         set
         {
            _renderWidth = value;
         }
      }
      public bool PlayingAnnimation
      {
         get
         {
            return _playingAnnimation;
         }
         set
         {
            _playingAnnimation = value;
         }
      }

      public int AnimationDelay
      {
         get
         {
            return _delay;
         }
         set
         {
            _delay = value;
         }
      }

      public RasterImage Image
      {
         get
         {
            return _viewer.Image;
         }
      }

      public bool IsComposite
      {
         get
         {
            return _isComposite;
         }
         set
         {
            _isComposite = value;
         }
      }

      public ImageViewer Viewer
      {
         get
         {
            return _viewer;
         }
      }

      public ImageViewer ImageListControl
      {
         get
         {
            return _imageListControl;
         }
         set
         {
            _imageListControl = value;
         }
      }

      public List<RasterImage> ImagesList
      {
         get
         {
            return _imagesList;
         }
         set
         {
            _imagesList = value;
         }
      }

      public ActiveImageLists ActiveList
      {
         get
         {
            return _activeList;
         }
         set
         {
            _activeList = value;
         }
      }

      public List<RasterImage> ColorList
      {
         get
         {
            return _colorList;
         }
         set
         {
            _colorList = value;
         }
      }

      private List<RasterImage> OpacityList
      {
         get
         {
            return _opacityList;
         }
         set
         {
            _opacityList = value;
         }
      }

      private List<RasterImage> PreOpacityList
      {
         get
         {
            return _preOpacityList;
         }
         set
         {
            _preOpacityList = value;
         }
      }

      private void InitClass( )
      {
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BorderStyle = BorderStyle.None;
         _pnlViewer.Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.AllowDrop = true;
         _viewer.AutoDisposeImages = false;

         // Create a new RasterImageList control. 
         ImageViewerVerticalViewLayout viewLayout = new Leadtools.Controls.ImageViewerVerticalViewLayout() { Columns = 1 };
         ImageListControl = new ImageViewer(viewLayout);
         Size = new Size(200, 200);
         ImageListControl.Bounds = new Rectangle(new Point(0, 0), Size);

         ImageListControl.SelectedItemBorderColor = Color.Red;
         ImageListControl.SelectedItemBackgroundColor = Color.LightBlue;
         ImageListControl.BackColor = Color.LightGray;
         ImageListControl.BorderStyle = BorderStyle.FixedSingle;
         ImageListControl.ImageBorderThickness = 1;
         ImageListControl.ImageHorizontalAlignment = ControlAlignment.Far;
         ImageListControl.ImageVerticalAlignment = ControlAlignment.Center;
         ImageListControl.ItemBackgroundColor = Color.LightGray;
         ImageListControl.ItemBorderThickness = 0;
         ImageListControl.ItemPadding = new Padding(20);
         ImageListControl.ItemTextColor = Color.Black;
         ImageListControl.ItemSize = LeadSize.Create(60, 80);
         ImageListControl.ItemSizeMode = ControlSizeMode.Fit;
         ImageListControl.Dock = DockStyle.Fill;
         RasterPaintProperties paintProperties = ImageListControl.PaintProperties;
         paintProperties.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic;
         ImageListControl.PaintProperties = paintProperties;
         ImageListControl.Height = _viewer.Height;
         ImageListControl.TextHorizontalAlignment = ControlAlignment.Center;
         ImageListControl.TextVerticalAlignment = ControlAlignment.Center;
         ImageListControl.InteractiveModes.BeginUpdate();
         ImageListControl.InteractiveModes.Add(new ImageViewerSelectItemsInteractiveMode() { SelectionMode = ImageViewerSelectionMode.Single });
         ImageListControl.InteractiveModes.EndUpdate();
         ImageListControl.SelectedItemsChanged += new EventHandler(ImageListControl_SelectedItemsChanged);
         ImageListControl.AutoDisposeImages = false;

         // Add the RasterImageList to the control collection. 
         _pnlImageList.Controls.Add(ImageListControl);

         PlayingAnnimation = false;
         StopAnimation = false;
         LoopAnimation = false;
         
         ActiveList = ActiveImageLists.ColorList;

         ImagesList = new List<RasterImage>();
         ColorList = new List<RasterImage>();
         OpacityList = new List<RasterImage>();
         PreOpacityList = new List<RasterImage>();

         ((MainForm)MdiParent).ClearCheck();
         ((MainForm)MdiParent).SetCheck(ActiveList);

         RenderHeight = DefaultViewerHeight;
         RenderWidth = DefaultViewerWidth;
         AnimationDelay = DefaultDelay;

      }      

      private bool LoadSaveAnimationStruct()
      {
         CompositionBox _compositionBox = new CompositionBox();

         try
         {
            _compositionBox = (CompositionBox) ((MainForm)MdiParent).Jpeg2000Eng.ReadBox(_name, Jpeg2000BoxType.CompositionBox, 0);
         }
         catch
         {
            return false;
         }

         // There must be only one composition box
         RenderHeight = _compositionBox.CompositionOptions.Height;
         if(RenderHeight == 0)
            RenderHeight = DefaultViewerHeight;

         RenderWidth = _compositionBox.CompositionOptions.Width;
         if (RenderWidth == 0)
            RenderWidth = DefaultViewerWidth;

         LoopAnimation = (Convert.ToInt32(_compositionBox.CompositionOptions.Loop) == 255) ? true : false;
         AnimationDelay = 0;

         if (_compositionBox.Instructions[0].Type == 4)
            AnimationDelay = _compositionBox.Instructions[0].Instructions[0].Life * _compositionBox.Instructions[0].Tick;

         if (AnimationDelay == 0)
            AnimationDelay = DefaultDelay;

         return true;
      }

      private List<RasterImage> GetActiveList()
      {
         switch (ActiveList)
         {
            case ActiveImageLists.ColorList:
               return ColorList;

            case ActiveImageLists.OpacityList:
               return OpacityList;

            case ActiveImageLists.PreOpacityList:
               return PreOpacityList;

            default:
               return ImagesList;
         }
      }

      void ImageListControl_SelectedItemsChanged(object sender, EventArgs e)
      {
         var items = ImageListControl.Items.GetSelected();
         if (items.Length == 0)
         {
            _viewer.Image = null;
         }
         else
         {
            //Get the only item in the list since it is single selection
            var item = items[0];
            var itemIndex = ImageListControl.Items.IndexOf(item);
            
            _viewer.Image = ImageListControl.Items[itemIndex].Image;

         }

         Viewer.Invalidate();
      }

      private void FillImageList(RasterImage image)
      {
         using(RasterCodecs codecs = new RasterCodecs())
         {
            ImageListControl.Items.Clear();

            for(int index = 1; index <= image.PageCount; index++)
            {
               image.Page = index;
               // Create the item of the image list 
               ImageViewerItem item = new ImageViewerItem();
               item.Size = LeadSize.Create(120, 120);
               item.Text = "Page: " + (index - 1).ToString();
               item.Image = image.Clone();
               item.Tag = index;

               // Add the item to the image list 
               ImageListControl.Items.Add(item);
            }

            ImageListControl.Items[0].IsSelected = true;
            _viewer.Image = ImageListControl.Items[0].Image;
         }
      }

      public void FillImageList()
      {
         using(RasterCodecs codecs = new RasterCodecs())
         {
            List<RasterImage> activeList = GetActiveList();

            if(activeList == null)
            {
               Messager.ShowError(this, "No List Avaliable");
               return;
            }

            RasterImage tempImage = new RasterImage(activeList[0]);
            for(int index = 1; index < activeList.Count; index++)
            {
               tempImage.AddPage(activeList[index].CloneAll());
            }
            FillImageList(tempImage);
         }
      }

      public void FillImages(List<CompositeJpxImages> compositeImage)
      {
         for (int index = 0; index < compositeImage.Count; index++)
         {
            ColorList.Add(compositeImage[index].ColorImage);

            if (compositeImage[index].OpacityImage != null)
               OpacityList.Add(compositeImage[index].OpacityImage);
            else
               OpacityList.Add(((MainForm)MdiParent).NoOpacityBitmap);

            if (compositeImage[index].PreOpacityImage != null)
               PreOpacityList.Add(compositeImage[index].PreOpacityImage);
            else
               PreOpacityList.Add(((MainForm)MdiParent).NoPreOpacityBitmap);

            if (compositeImage[index].OpacityImage != null)
            {
               RasterImage combineImage = new RasterImage(compositeImage[index].ColorImage);

               CombineCommand command = new CombineCommand(compositeImage[index].OpacityImage,
                                                           new LeadRect(0, 0, compositeImage[index].OpacityImage.Width, compositeImage[index].OpacityImage.Height),
                                                           new LeadPoint(0, 0),
                                                           CombineCommandFlags.OperationMultiply);
               command.Run(combineImage);

               ImagesList.Add(combineImage);
            }
            else
            {
               ImagesList.Add(compositeImage[index].ColorImage);
            }
         }
      }

      public void Initialize(ImageInformation info, RasterPaintProperties paintProperties, bool snap,bool isFile)
      {
         _viewer.BeginUpdate();
         UpdatePaintProperties(paintProperties);
         FillImageList(info.Image);
         if (_viewer.Image != null)
            _viewer.Image.Changed += new EventHandler<RasterImageChangedEventArgs>(Image_Changed);
         _name = info.Name;
         if(snap)
            Snap();
         if(isFile)
            LoadSaveAnimationStruct();
         UpdateCaption();
         _viewer.EndUpdate();
      }

      public void Initialize(List<CompositeJpxImages> compositeImage, string fileName, RasterPaintProperties paintProperties, bool snap)
      {
         _viewer.BeginUpdate();
         UpdatePaintProperties(paintProperties);
         FillImages(compositeImage);
         FillImageList();
         if (_viewer.Image != null)
            _viewer.Image.Changed += new EventHandler<RasterImageChangedEventArgs>(Image_Changed);
         _name = fileName;
         if (snap)
            Snap();
         LoadSaveAnimationStruct();
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
         if(MdiParent != null && !PlayingAnnimation)
            ((MainForm)MdiParent).UpdateControls();
      }

      private void _viewer_SizeModeChanged(object sender, EventArgs e)
      {
         ((MainForm)MdiParent).UpdateControls();
      }

      public void Snap( )
      {
         _viewer.ClientSize = new Size(_pnlImageList.Width + DefaultViewerWidth, DefaultViewerHeight);
         ClientSize = _viewer.ClientSize;
      }

      private void ViewerForm_Closed(object sender, System.EventArgs e)
      {
      }

      private void ViewerForm_Deactivate(object sender, System.EventArgs e)
      {
      }
   }
}
