// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Drawing;
using Leadtools.WinForms.CommonDialogs.File;



namespace JPEG2000Demo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miFileSave;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miZoomSep1;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.MenuItem _miZoom;
      private System.Windows.Forms.MenuItem _miZoomIn;
      private System.Windows.Forms.MenuItem _miZoomOut;
      private System.Windows.Forms.MenuItem _miZoomNormal;

      private int _originalWidth;
      private int _originalHeight;
      private string _fileName;
      private GraphicsPath _mousePath;
      private Rectangle _drawRect;
      private bool _startDrawing;
      private Pen _myDrawPen;
      private Graphics _graph;
      private Point _originPoint;
      private MenuItem _miPreferences;
      private MenuItem _miUseROI;
      private bool _useROI;
      private IContainer components;

      public MainForm()
      {
         //
         // Required for Windows Form Designer support
         //

         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //

         _originalWidth = 0;
         _originalHeight = 0;
      }

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            if (components != null)
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
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mmMain = new System.Windows.Forms.MainMenu(this.components);
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileOpen = new System.Windows.Forms.MenuItem();
         this._miFileSave = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miZoom = new System.Windows.Forms.MenuItem();
         this._miZoomIn = new System.Windows.Forms.MenuItem();
         this._miZoomOut = new System.Windows.Forms.MenuItem();
         this._miZoomSep1 = new System.Windows.Forms.MenuItem();
         this._miZoomNormal = new System.Windows.Forms.MenuItem();
         this._miPreferences = new System.Windows.Forms.MenuItem();
         this._miUseROI = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miZoom,
            this._miPreferences,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileOpen,
            this._miFileSave,
            this._miFileSep1,
            this._miFileExit});
         resources.ApplyResources(this._miFile, "_miFile");
         // 
         // _miFileOpen
         // 
         this._miFileOpen.Index = 0;
         resources.ApplyResources(this._miFileOpen, "_miFileOpen");
         this._miFileOpen.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileSave
         // 
         this._miFileSave.Index = 1;
         resources.ApplyResources(this._miFileSave, "_miFileSave");
         this._miFileSave.Click += new System.EventHandler(this._miFileSave_Click);
         // 
         // _miFileSep1
         // 
         this._miFileSep1.Index = 2;
         resources.ApplyResources(this._miFileSep1, "_miFileSep1");
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 3;
         resources.ApplyResources(this._miFileExit, "_miFileExit");
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miZoom
         // 
         this._miZoom.Index = 1;
         this._miZoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miZoomIn,
            this._miZoomOut,
            this._miZoomSep1,
            this._miZoomNormal});
         this._miZoom.RadioCheck = true;
         resources.ApplyResources(this._miZoom, "_miZoom");
         // 
         // _miZoomIn
         // 
         this._miZoomIn.Index = 0;
         this._miZoomIn.RadioCheck = true;
         resources.ApplyResources(this._miZoomIn, "_miZoomIn");
         this._miZoomIn.Click += new System.EventHandler(this._miZoom_Click);
         // 
         // _miZoomOut
         // 
         this._miZoomOut.Index = 1;
         this._miZoomOut.RadioCheck = true;
         resources.ApplyResources(this._miZoomOut, "_miZoomOut");
         this._miZoomOut.Click += new System.EventHandler(this._miZoom_Click);
         // 
         // _miZoomSep1
         // 
         this._miZoomSep1.Index = 2;
         this._miZoomSep1.RadioCheck = true;
         resources.ApplyResources(this._miZoomSep1, "_miZoomSep1");
         // 
         // _miZoomNormal
         // 
         this._miZoomNormal.Index = 3;
         this._miZoomNormal.RadioCheck = true;
         resources.ApplyResources(this._miZoomNormal, "_miZoomNormal");
         this._miZoomNormal.Click += new System.EventHandler(this._miZoom_Click);
         // 
         // _miPrefrences
         // 
         this._miPreferences.Index = 2;
         this._miPreferences.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miUseROI});
         resources.ApplyResources(this._miPreferences, "_miPrefrences");
         // 
         // _miUseROI
         // 
         this._miUseROI.Index = 0;
         resources.ApplyResources(this._miUseROI, "_miUseROI");
         this._miUseROI.Click += new System.EventHandler(this._miUseROI_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 3;
         this._miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miHelpAbout});
         resources.ApplyResources(this._miHelp, "_miHelp");
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Index = 0;
         resources.ApplyResources(this._miHelpAbout, "_miHelpAbout");
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // MainForm
         // 
         resources.ApplyResources(this, "$this");
         this.BackColor = System.Drawing.SystemColors.Control;
         this.ForeColor = System.Drawing.SystemColors.ControlText;
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.ResumeLayout(false);

      }
      #endregion

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         Application.Run(new MainForm());
      }

      // The raster image viewer
      private ImageViewer _viewer;

      // The raster codecs used in load/save
      private RasterCodecs _codecs;

      /// <summary>
      /// Hook the KeyPress event of the viewer
      /// </summary>
      private void _viewer_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (_viewer.Image != null)
         {
            if (e.KeyChar == '+')
               _miZoom_Click(_miZoomIn, null);
            if (e.KeyChar == '-')
               _miZoom_Click(_miZoomOut, null);
         }
      }

      /// <summary>
      /// Initialize the application
      /// </summary>
      private void MainForm_Load(object sender, System.EventArgs e)
      {
         // setup our caption
         Messager.Caption = "LEADTOOLS for .NET C# JPEG 2000 Demo";
         Text = Messager.Caption;

         // initialize the _viewer object
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.KeyPress += new KeyPressEventHandler(_viewer_KeyPress);
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();
         _viewer.MouseDown += new MouseEventHandler(MyMouseDown);
         _viewer.MouseUp += new MouseEventHandler(MyMouseUp);
         _viewer.MouseMove += new MouseEventHandler(MyMouseMove);

         // initialize the codecs object
         _codecs = new RasterCodecs();

         LoadImage(true);
         UpdateMyControls();

         _mousePath = new System.Drawing.Drawing2D.GraphicsPath();
         _startDrawing = false;
         _myDrawPen = new Pen(Color.Black, 2);
         _useROI = false;
      }

      /// <summary>
      /// Updates the UI depending on the program state
      /// </summary>
      private void UpdateMyControls()
      {
         // update the menu items
         if (_viewer.Image != null)
         {
            _miFileSave.Enabled = true;
            _miFileSave.Visible = true;

            _miZoom.Enabled = true;
            _miZoom.Visible = true;
         }
         else
         {
            _miFileSave.Enabled = false;
            _miFileSave.Visible = false;

            _miZoom.Enabled = false;
            _miZoom.Visible = false;
         }
      }

      /// <summary>
      /// Load a new image
      /// </summary>
      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         LoadImage(false);
      }

      private void LoadImage(bool loadDefaultImage)
      {
         try
         {
            ImageFileLoader loader = new ImageFileLoader();
            bool bLoaded = false;

            if (loadDefaultImage)
               bLoaded = loader.Load(this, DemosGlobal.ImagesFolder + @"\image1.j2k", _codecs, 1, 1);
            else
            {
               ImageFileLoader.FilterIndex = 5;
               bLoaded = loader.Load(this, _codecs, true) > 0;
            }

            if (bLoaded)
            {
               // Load and set the new image in the viewer
               _viewer.Image = loader.Image;

               // Get the information about the image
               CodecsImageInfo imageInformation = _codecs.GetInformation(loader.FileName, false);
               switch (imageInformation.Format)
               {
                  case RasterImageFormat.J2k:
                  case RasterImageFormat.Jp2:
                  case RasterImageFormat.Cmw:
                     {
                        this.Text = String.Format("LEADTOOLS for .NET C# JPEG 2000 Demo {0} X {1}", _viewer.Image.Width, _viewer.Image.Height);
                        break;
                     }
                  default:
                     {
                        this.Text = string.Format("{0} - {1}", loader.FileName, Messager.Caption);
                        break;
                     }
               }

               _fileName = loader.FileName;

               _originalWidth = imageInformation.Width;
               _originalHeight = imageInformation.Height;

               _viewer.Invalidate(true);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateMyControls();
         }
      }

      /// <summary>
      /// Save the image
      /// </summary>
      private void _miFileSave_Click(object sender, System.EventArgs e)
      {
         RasterSaveDialogFileFormatsList saveFormats = new RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.User);
         ImageFileSaver saver = new ImageFileSaver();

         saveFormats.Add(RasterDialogFileTypesIndex.Jpeg2000, RasterDialogBitsPerPixelDataContent.Default);
         saveFormats.Add(RasterDialogFileTypesIndex.Cmw, RasterDialogBitsPerPixelDataContent.Default);
         saveFormats.Add(RasterDialogFileTypesIndex.Jpeg, RasterDialogBitsPerPixelDataContent.Default);
         saveFormats.Add(RasterDialogFileTypesIndex.Lead, RasterDialogBitsPerPixelDataContent.Default);

         saver.SaveFormats = saveFormats;
         saver.FormatIndex = RasterDialogFileTypesIndex.Jpeg2000;

         try
         {
            if (_useROI)
            {
               _codecs.Options.Jpeg2000.Save.RegionOfInterest = CodecsJpeg2000RegionOfInterest.UseLeadRegion;
            }

            saver.Save(this, _codecs, _viewer.Image);
         }
         catch (Exception ex)
         {
            Messager.ShowFileSaveError(this, saver.FileName, ex);
         }
      }

      /// <summary>
      /// Shutdown
      /// </summary>
      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }
      /// <summary>
      /// Zoom the image
      /// </summary>
      private void _miZoom_Click(object sender, System.EventArgs e)
      {
         double scaleFactor = _viewer.ScaleFactor;

         if (sender == _miZoomIn)
         {
            if (_originalWidth > _viewer.Image.Width && (scaleFactor == 1))
            {
               using (RasterCodecs codecs = new RasterCodecs())
               {
                  CodecsImageInfo _imageInformation = codecs.GetInformation(_fileName, false);
                  switch (_imageInformation.Format)
                  {
                     case RasterImageFormat.J2k:
                        codecs.Options.Jpeg2000.Load.J2kResolution = new LeadSize(_viewer.Image.Width * 2, _viewer.Image.Height * 2);
                        break;
                     case RasterImageFormat.Jp2:
                        codecs.Options.Jpeg2000.Load.Jp2Resolution = new LeadSize(_viewer.Image.Width * 2, _viewer.Image.Height * 2);
                        break;
                     case RasterImageFormat.Cmw:
                        codecs.Options.Jpeg2000.Load.CmwResolution = new LeadSize(_viewer.Image.Width * 2, _viewer.Image.Height * 2);
                        break;
                  }

                  _viewer.Cursor = Cursors.WaitCursor;
                  _viewer.Image.Dispose();
                  _viewer.Image = codecs.Load(_fileName);
                  this.Text = String.Format("LEADTOOLS for .NET C# JPEG 2000 Demo {0} X {1}", _viewer.Image.Width, _viewer.Image.Height);
                  _viewer.Cursor = Cursors.Arrow;
               }
            }
            else
               scaleFactor *= 2;
         }
         else if (sender == _miZoomOut)
            scaleFactor /= 2;
         else if (sender == _miZoomNormal)
         {
            scaleFactor = 1;
            _viewer.Zoom(ControlSizeMode.None, scaleFactor, _viewer.DefaultZoomOrigin);
         }
         if ((scaleFactor > 0.009) && (scaleFactor < 11))
            _viewer.Zoom(ControlSizeMode.None, scaleFactor, _viewer.DefaultZoomOrigin);
      }

      /// <summary>
      /// Show the About dialog
      /// </summary>
      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("JPEG 2000", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private Rectangle MakeRect(Point originPoint, Point endPoint)
      {
         Rectangle tmpRect = new Rectangle(0, 0, 0, 0);
         if (originPoint.X > endPoint.X)
            tmpRect.X = endPoint.X;
         else
            tmpRect.X = originPoint.X;

         if (originPoint.Y > endPoint.Y)
            tmpRect.Y = endPoint.Y;
         else
            tmpRect.Y = originPoint.Y;

         tmpRect.Width = (originPoint.X > endPoint.X) ? originPoint.X - endPoint.X : endPoint.X - originPoint.X;
         tmpRect.Height = (originPoint.Y > endPoint.Y) ? originPoint.Y - endPoint.Y : endPoint.Y - originPoint.Y;
         return tmpRect;
      }

      private void MyMouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if (_useROI)
         {
            _drawRect = new Rectangle(0, 0, 0, 0);
            _drawRect.X = e.X;
            _drawRect.Y = e.Y;

            _drawRect.Width = 0;
            _drawRect.Height = 0;
            _originPoint = new Point(e.X, e.Y);

            _mousePath.Reset();
            _mousePath.AddRectangle(_drawRect);

            // Draw the path to the screen.
            _graph = _viewer.CreateGraphics();
            _graph.DrawPath(_myDrawPen, _mousePath);
            _startDrawing = true;
         }
      }

      private void MyMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if (_useROI && _startDrawing)
         {
            Point endPt = new Point(e.X, e.Y);
            if (e.X > _viewer.Image.Width)
               endPt.X = _viewer.Image.Width;
            if (e.Y > _viewer.Image.Height)
               endPt.Y = _viewer.Image.Height;
            if (e.X < 0)
               endPt.X = 0;
            if (e.Y < 0)
               endPt.Y = 0;

            _drawRect = MakeRect(_originPoint, endPt);

            _mousePath.Reset();
            _mousePath.AddRectangle(_drawRect);

            // Draw the path to the screen.
            _viewer.Refresh();
            _graph.DrawPath(_myDrawPen, _mousePath);
            _graph.Dispose();

            double power = Math.Log(_viewer.ScaleFactor) / Math.Log(2.0);
            int numerator = (power > 0.0) ? 1 : (int)(Math.Pow(2.0, -1 * power));
            int denominator = (power > 0.0) ? (int)(Math.Pow(2.0, power)) : 1;

            Leadtools.RasterRegionXForm xForm = new RasterRegionXForm();
            xForm.ViewPerspective = RasterViewPerspective.TopLeft;
            xForm.XScalarNumerator = numerator;
            xForm.XScalarDenominator = denominator;
            xForm.YScalarNumerator = numerator;
            xForm.YScalarDenominator = denominator;
            xForm.XOffset = _viewer.ScrollOffset.X;
            xForm.YOffset = _viewer.ScrollOffset.Y;

            _viewer.BeginRender();
            if (!_viewer.Image.HasRegion)
               _viewer.Image.AddRectangleToRegion(xForm, Leadtools.Demos.Converters.ConvertRect(_drawRect), RasterRegionCombineMode.Set);
            else
               _viewer.Image.AddRectangleToRegion(xForm, Leadtools.Demos.Converters.ConvertRect(_drawRect), RasterRegionCombineMode.Or);
            _viewer.EndRender();
         }

         _startDrawing = false;
      }

      private void MyMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
      {
         if (_useROI && _startDrawing)
         {
            Point endPt = new Point(e.X, e.Y);
            if (e.X > _viewer.Image.Width)
               endPt.X = _viewer.Image.Width;
            if (e.Y > _viewer.Image.Height)
               endPt.Y = _viewer.Image.Height;
            if (e.X < 0)
               endPt.X = 0;
            if (e.Y < 0)
               endPt.Y = 0;

            _drawRect = MakeRect(_originPoint, endPt);

            _mousePath.Reset();
            _mousePath.AddRectangle(_drawRect);

            // Draw the path to the screen.
            _viewer.Refresh();
            _graph.DrawPath(_myDrawPen, _mousePath);
         }
      }

      private void _miUseROI_Click(object sender, EventArgs e)
      {
         _useROI = !_useROI;
         _miUseROI.Checked = _useROI;
      }
   }
}
