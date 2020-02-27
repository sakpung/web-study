// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Drawing;
using Leadtools.ImageProcessing.Effects;

namespace AbcDemo
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miFileClose;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _FileSeperator1;
      private System.Windows.Forms.MenuItem _miEdit;
      private System.Windows.Forms.MenuItem _miEditCopy;
      private System.Windows.Forms.MenuItem _miView;
      private System.Windows.Forms.MenuItem _miViewNormal;
      private System.Windows.Forms.MenuItem _miViewSnapToImage;
      private System.Windows.Forms.MenuItem _miViewZoomIn;
      private System.Windows.Forms.MenuItem _miViewZoomOut;
      private System.Windows.Forms.MenuItem _miQuality;
      private System.Windows.Forms.MenuItem _miQualityCombineTwoImages;
      private System.Windows.Forms.MenuItem _QualitySeperator1;
      private System.Windows.Forms.MenuItem _miQualityLossless;
      private System.Windows.Forms.MenuItem _miQualityVirtualLossless;
      private System.Windows.Forms.MenuItem _miQualityRemoveBorder;
      private System.Windows.Forms.MenuItem _miQualityEnhanced;
      private System.Windows.Forms.MenuItem _miQualityModified1;
      private System.Windows.Forms.MenuItem _miQualityFastModified1;
      private System.Windows.Forms.MenuItem _miQualityModified2;
      private System.Windows.Forms.MenuItem _miQualityFastModified2;
      private System.Windows.Forms.MenuItem _miQualityModified3;
      private System.Windows.Forms.MenuItem _miWindow;
      private System.Windows.Forms.MenuItem _miWindowCascade;
      private System.Windows.Forms.MenuItem _miWindowTileHorizontal;
      private System.Windows.Forms.MenuItem _miWindowTileVertical;
      private System.Windows.Forms.MenuItem _miWindowArrangeIcons;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.MenuItem _miViewFitToWindow;
      private System.Windows.Forms.MenuItem _miFileSaveCurrentAsAbc;
      private System.Windows.Forms.MenuItem _miFileSaveAllPagesAsTIFF;
      private System.Windows.Forms.MenuItem _miFileSaveCurrentAsTIFF;
      private System.Windows.Forms.MenuItem _ViewSeparator1;
      private System.Windows.Forms.MenuItem _ViewSeparator2;
      private System.Windows.Forms.MenuItem _miQualityFastModified3;
      private System.Windows.Forms.MenuItem _miQualityFastLossless;
      private System.Windows.Forms.MenuItem _miQualityFastLossy;
      private System.Windows.Forms.StatusBar _sbMainStatus;
      private IContainer components;

      public MainForm( )
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._mmMain = new System.Windows.Forms.MainMenu(this.components);
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileOpen = new System.Windows.Forms.MenuItem();
         this._miFileClose = new System.Windows.Forms.MenuItem();
         this._miFileSaveCurrentAsAbc = new System.Windows.Forms.MenuItem();
         this._miFileSaveCurrentAsTIFF = new System.Windows.Forms.MenuItem();
         this._miFileSaveAllPagesAsTIFF = new System.Windows.Forms.MenuItem();
         this._FileSeperator1 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miEdit = new System.Windows.Forms.MenuItem();
         this._miEditCopy = new System.Windows.Forms.MenuItem();
         this._miView = new System.Windows.Forms.MenuItem();
         this._miViewNormal = new System.Windows.Forms.MenuItem();
         this._miViewFitToWindow = new System.Windows.Forms.MenuItem();
         this._ViewSeparator1 = new System.Windows.Forms.MenuItem();
         this._miViewSnapToImage = new System.Windows.Forms.MenuItem();
         this._ViewSeparator2 = new System.Windows.Forms.MenuItem();
         this._miViewZoomIn = new System.Windows.Forms.MenuItem();
         this._miViewZoomOut = new System.Windows.Forms.MenuItem();
         this._miQuality = new System.Windows.Forms.MenuItem();
         this._miQualityCombineTwoImages = new System.Windows.Forms.MenuItem();
         this._QualitySeperator1 = new System.Windows.Forms.MenuItem();
         this._miQualityLossless = new System.Windows.Forms.MenuItem();
         this._miQualityFastLossless = new System.Windows.Forms.MenuItem();
         this._miQualityVirtualLossless = new System.Windows.Forms.MenuItem();
         this._miQualityFastLossy = new System.Windows.Forms.MenuItem();
         this._miQualityRemoveBorder = new System.Windows.Forms.MenuItem();
         this._miQualityEnhanced = new System.Windows.Forms.MenuItem();
         this._miQualityModified1 = new System.Windows.Forms.MenuItem();
         this._miQualityFastModified1 = new System.Windows.Forms.MenuItem();
         this._miQualityModified2 = new System.Windows.Forms.MenuItem();
         this._miQualityFastModified2 = new System.Windows.Forms.MenuItem();
         this._miQualityModified3 = new System.Windows.Forms.MenuItem();
         this._miQualityFastModified3 = new System.Windows.Forms.MenuItem();
         this._miWindow = new System.Windows.Forms.MenuItem();
         this._miWindowCascade = new System.Windows.Forms.MenuItem();
         this._miWindowTileHorizontal = new System.Windows.Forms.MenuItem();
         this._miWindowTileVertical = new System.Windows.Forms.MenuItem();
         this._miWindowArrangeIcons = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this._sbMainStatus = new System.Windows.Forms.StatusBar();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miEdit,
            this._miView,
            this._miQuality,
            this._miWindow,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileOpen,
            this._miFileClose,
            this._miFileSaveCurrentAsAbc,
            this._miFileSaveCurrentAsTIFF,
            this._miFileSaveAllPagesAsTIFF,
            this._FileSeperator1,
            this._miFileExit});
         this._miFile.Text = "&File";
         this._miFile.Popup += new System.EventHandler(this._miFile_Popup);
         // 
         // _miFileOpen
         // 
         this._miFileOpen.Index = 0;
         this._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this._miFileOpen.Text = "&Open...";
         this._miFileOpen.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileClose
         // 
         this._miFileClose.Index = 1;
         this._miFileClose.Text = "&Close";
         this._miFileClose.Click += new System.EventHandler(this._miFileClose_Click);
         // 
         // _miFileSaveCurrentAsAbc
         // 
         this._miFileSaveCurrentAsAbc.Index = 2;
         this._miFileSaveCurrentAsAbc.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this._miFileSaveCurrentAsAbc.Text = "Save Current As ABC...";
         this._miFileSaveCurrentAsAbc.Click += new System.EventHandler(this._miFileSaveCurrentAsAbc_Click);
         // 
         // _miFileSaveCurrentAsTIFF
         // 
         this._miFileSaveCurrentAsTIFF.Index = 3;
         this._miFileSaveCurrentAsTIFF.Text = "Save Current As TIFF...";
         this._miFileSaveCurrentAsTIFF.Click += new System.EventHandler(this._miFileSaveCurrentAsTIFF_Click);
         // 
         // _miFileSaveAllPagesAsTIFF
         // 
         this._miFileSaveAllPagesAsTIFF.Index = 4;
         this._miFileSaveAllPagesAsTIFF.Text = "Save All Pages As TIFF...";
         this._miFileSaveAllPagesAsTIFF.Click += new System.EventHandler(this._miFileSaveAllPagesAsTIFF_Click);
         // 
         // _FileSeperator1
         // 
         this._FileSeperator1.Index = 5;
         this._FileSeperator1.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 6;
         this._miFileExit.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miEdit
         // 
         this._miEdit.Index = 1;
         this._miEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miEditCopy});
         this._miEdit.Text = "&Edit";
         // 
         // _miEditCopy
         // 
         this._miEditCopy.Index = 0;
         this._miEditCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
         this._miEditCopy.Text = "&Copy";
         this._miEditCopy.Click += new System.EventHandler(this._miEditCopy_Click);
         // 
         // _miView
         // 
         this._miView.Index = 2;
         this._miView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miViewNormal,
            this._miViewFitToWindow,
            this._ViewSeparator1,
            this._miViewSnapToImage,
            this._ViewSeparator2,
            this._miViewZoomIn,
            this._miViewZoomOut});
         this._miView.Text = "&View";
         this._miView.Popup += new System.EventHandler(this._miView_Popup);
         // 
         // _miViewNormal
         // 
         this._miViewNormal.Checked = true;
         this._miViewNormal.Index = 0;
         this._miViewNormal.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
         this._miViewNormal.Text = "&Normal";
         this._miViewNormal.Click += new System.EventHandler(this._miView_Click);
         // 
         // _miViewFitToWindow
         // 
         this._miViewFitToWindow.Index = 1;
         this._miViewFitToWindow.Text = "&Fit Image To Window";
         this._miViewFitToWindow.Click += new System.EventHandler(this._miView_Click);
         // 
         // _ViewSeparator1
         // 
         this._ViewSeparator1.Index = 2;
         this._ViewSeparator1.Text = "-";
         // 
         // _miViewSnapToImage
         // 
         this._miViewSnapToImage.Index = 3;
         this._miViewSnapToImage.Text = "Sna&p Window To Image";
         this._miViewSnapToImage.Click += new System.EventHandler(this._miView_Click);
         // 
         // _ViewSeparator2
         // 
         this._ViewSeparator2.Index = 4;
         this._ViewSeparator2.Text = "-";
         // 
         // _miViewZoomIn
         // 
         this._miViewZoomIn.Index = 5;
         this._miViewZoomIn.Text = "Zoom &In";
         this._miViewZoomIn.Click += new System.EventHandler(this._miView_Click);
         // 
         // _miViewZoomOut
         // 
         this._miViewZoomOut.Index = 6;
         this._miViewZoomOut.Text = "Zoom &Out";
         this._miViewZoomOut.Click += new System.EventHandler(this._miView_Click);
         // 
         // _miQuality
         // 
         this._miQuality.Index = 3;
         this._miQuality.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miQualityCombineTwoImages,
            this._QualitySeperator1,
            this._miQualityLossless,
            this._miQualityFastLossless,
            this._miQualityVirtualLossless,
            this._miQualityFastLossy,
            this._miQualityRemoveBorder,
            this._miQualityEnhanced,
            this._miQualityModified1,
            this._miQualityFastModified1,
            this._miQualityModified2,
            this._miQualityFastModified2,
            this._miQualityModified3,
            this._miQualityFastModified3});
         this._miQuality.Text = "&Quality";
         // 
         // _miQualityCombineTwoImages
         // 
         this._miQualityCombineTwoImages.Index = 0;
         this._miQualityCombineTwoImages.Text = "Combine Two Images";
         this._miQualityCombineTwoImages.Click += new System.EventHandler(this._miQualityCombineTwoImages_Click);
         // 
         // _QualitySeperator1
         // 
         this._QualitySeperator1.Index = 1;
         this._QualitySeperator1.Text = "-";
         // 
         // _miQualityLossless
         // 
         this._miQualityLossless.Index = 2;
         this._miQualityLossless.Text = "Lossless";
         this._miQualityLossless.Click += new System.EventHandler(this._miQuality_Click);
         // 
         // _miQualityFastLossless
         // 
         this._miQualityFastLossless.Index = 3;
         this._miQualityFastLossless.Text = "Fast Lossless";
         this._miQualityFastLossless.Click += new System.EventHandler(this._miQuality_Click);
         // 
         // _miQualityVirtualLossless
         // 
         this._miQualityVirtualLossless.Index = 4;
         this._miQualityVirtualLossless.Text = "Virtual Lossless";
         this._miQualityVirtualLossless.Click += new System.EventHandler(this._miQuality_Click);
         // 
         // _miQualityFastLossy
         // 
         this._miQualityFastLossy.Index = 5;
         this._miQualityFastLossy.Text = "Fast Lossy";
         this._miQualityFastLossy.Click += new System.EventHandler(this._miQuality_Click);
         // 
         // _miQualityRemoveBorder
         // 
         this._miQualityRemoveBorder.Index = 6;
         this._miQualityRemoveBorder.Text = "Remove Border ";
         this._miQualityRemoveBorder.Click += new System.EventHandler(this._miQuality_Click);
         // 
         // _miQualityEnhanced
         // 
         this._miQualityEnhanced.Index = 7;
         this._miQualityEnhanced.Text = "Enhanced";
         this._miQualityEnhanced.Click += new System.EventHandler(this._miQuality_Click);
         // 
         // _miQualityModified1
         // 
         this._miQualityModified1.Index = 8;
         this._miQualityModified1.Text = "Modified 1";
         this._miQualityModified1.Click += new System.EventHandler(this._miQuality_Click);
         // 
         // _miQualityFastModified1
         // 
         this._miQualityFastModified1.Index = 9;
         this._miQualityFastModified1.Text = "Fast Modified 1";
         this._miQualityFastModified1.Click += new System.EventHandler(this._miQuality_Click);
         // 
         // _miQualityModified2
         // 
         this._miQualityModified2.Index = 10;
         this._miQualityModified2.Text = "Modified 2";
         this._miQualityModified2.Click += new System.EventHandler(this._miQuality_Click);
         // 
         // _miQualityFastModified2
         // 
         this._miQualityFastModified2.Index = 11;
         this._miQualityFastModified2.Text = "Fast Modified 2";
         this._miQualityFastModified2.Click += new System.EventHandler(this._miQuality_Click);
         // 
         // _miQualityModified3
         // 
         this._miQualityModified3.Index = 12;
         this._miQualityModified3.Text = "Modified 3";
         this._miQualityModified3.Click += new System.EventHandler(this._miQuality_Click);
         // 
         // _miQualityFastModified3
         // 
         this._miQualityFastModified3.Index = 13;
         this._miQualityFastModified3.Text = "Fast Modified 3";
         this._miQualityFastModified3.Click += new System.EventHandler(this._miQuality_Click);
         // 
         // _miWindow
         // 
         this._miWindow.Index = 4;
         this._miWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miWindowCascade,
            this._miWindowTileHorizontal,
            this._miWindowTileVertical,
            this._miWindowArrangeIcons});
         this._miWindow.Text = "&Window";
         // 
         // _miWindowCascade
         // 
         this._miWindowCascade.Index = 0;
         this._miWindowCascade.Text = "&Cascade";
         this._miWindowCascade.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowTileHorizontal
         // 
         this._miWindowTileHorizontal.Index = 1;
         this._miWindowTileHorizontal.Text = "Tile &Horizontal";
         this._miWindowTileHorizontal.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowTileVertical
         // 
         this._miWindowTileVertical.Index = 2;
         this._miWindowTileVertical.Text = "Tile &Vertical";
         this._miWindowTileVertical.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowArrangeIcons
         // 
         this._miWindowArrangeIcons.Index = 3;
         this._miWindowArrangeIcons.Text = "&Arrange Icons";
         this._miWindowArrangeIcons.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 5;
         this._miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miHelpAbout});
         this._miHelp.Text = "&Help";
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Index = 0;
         this._miHelpAbout.Text = "&About...";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // _sbMainStatus
         // 
         this._sbMainStatus.Location = new System.Drawing.Point(0, 449);
         this._sbMainStatus.Name = "_sbMainStatus";
         this._sbMainStatus.Size = new System.Drawing.Size(712, 22);
         this._sbMainStatus.TabIndex = 1;
         // 
         // MainForm
         // 
         this.AllowDrop = true;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(712, 471);
         this.Controls.Add(this._sbMainStatus);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.IsMdiContainer = true;
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
         this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
         this.ResumeLayout(false);

      }
      #endregion

      private RasterCodecs _codecs;
      private RasterPaintProperties _paintProperties;
      private bool _viewerOpened;
      private string _fileName;
      private string _quality;
      private bool _showSave;
      private MenuItem _previousCheckQuality;
      private bool _stopSaving;

      private static readonly float _minimumScaleFactor = 0.05f;
      private static readonly float _maximumScaleFactor = 11f;

      private const string _saveDirectory = @"c:\Temp";
      private const string _saveFileName = _saveDirectory + @"\preview";
      private const string _saveFileNameG4 = _saveDirectory + @"\preview.g4";

      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main( )
      {
         if (!Support.SetLicense())
            return;


         Application.Run(new MainForm());
      }

      private void InitClass( )
      {
         Messager.Caption = "LEADTOOLS for .NET C# ABC Demo";
         Text = Messager.Caption;

         _codecs = new RasterCodecs();

         _paintProperties = RasterPaintProperties.Default;
         _paintProperties.PaintDisplayMode |= RasterPaintDisplayModeFlags.ScaleToGray;
         _paintProperties.PaintEngine = RasterPaintEngine.GdiPlus;

         _showSave = false;
         _viewerOpened = false;

         _quality = "(Lossless)";

         setCheckWindow(_miWindowCascade);

         LoadImage(true);
         UpdateControls();
      }

      public bool StopSaving
      {
         get
         {
            return _stopSaving;
         }
         set
         {
            _stopSaving = value;
         }
      }

      public MenuItem ZoomIn
      {
         get
         {
            return _miViewZoomIn;
         }
      }

      public MenuItem ZoomOut
      {
         get
         {
            return _miViewZoomOut;
         }
      }

      public ViewerForm ActiveViewerForm
      {
         get
         {
            return ActiveMdiChild as ViewerForm;
         }
      }

      public bool ViewerOpened
      {
         set
         {
            _viewerOpened = value;
         }
      }

      private RasterImage ImageToRun
      {
         get
         {
            ViewerForm activeForm = ActiveViewerForm;

            return activeForm.Viewer.Image;
         }
         set
         {
            if(value != null)
            {
               ViewerForm activeForm = ActiveViewerForm;

               activeForm.Viewer.Image = value;
            }
         }
      }
      public bool ShowSave
      {
         set
         {
            _showSave = value;
         }
      }
      public MenuItem PreviousCheckQuality
      {
         get
         {
            return _previousCheckQuality;
         }
      }

      public void UpdateControls( )
      {
         ViewerForm activeForm = ActiveViewerForm;

         EnableAndVisibleMenu(_miFileSaveCurrentAsAbc, activeForm != null);
         EnableAndVisibleMenu(_miFileSaveCurrentAsTIFF, activeForm != null);
         EnableAndVisibleMenu(_miFileSaveAllPagesAsTIFF, activeForm != null);
         EnableAndVisibleMenu(_miFileClose, activeForm != null);
         EnableAndVisibleMenu(_miEdit, activeForm != null);
         EnableAndVisibleMenu(_miView, activeForm != null);
         EnableAndVisibleMenu(_miQuality, activeForm != null);
         EnableAndVisibleMenu(_miWindow, activeForm != null);

         _miFileSaveCurrentAsAbc.Enabled = _showSave;
         _miFileSaveAllPagesAsTIFF.Enabled = _showSave;
         _miFileSaveCurrentAsTIFF.Enabled = _showSave;

         if(activeForm != null)
         {
            _miViewNormal.Checked = activeForm.Viewer.SizeMode != ControlSizeMode.Fit;
            _miViewFitToWindow.Checked = activeForm.Viewer.SizeMode == ControlSizeMode.Fit;
         }
      }

      private void EnableAndVisibleMenu(MenuItem menu, bool value)
      {
         menu.Enabled = value;
         menu.Visible = value;
      }

      private void NewImage(ImageInformation info, bool originalViewer)
      {
         ViewerForm child = new ViewerForm();
         child.MdiParent = this;
         child.Initialize(info, _paintProperties, true);
         child.OriginalViewer = originalViewer;
         child.Show();
      }

      public void LoadDropFiles(ViewerForm viewer, string[] files)
      {
         try
         {
            if(files != null)
            {
               for(int nI = 0; nI < files.Length; nI++)
               {
                  try
                  {
                     RasterImage image = _codecs.Load(files[nI]);
                     ImageInformation info = new ImageInformation(image, files[nI]);
                     if(nI == 0 && viewer != null)
                        viewer.Initialize(info, _paintProperties, false);
                     else
                     {
                        ViewerForm activeViewer = ActiveViewerForm;

                        _fileName = info.Name;
                        info.Name += " (Original)";

                        if(!_viewerOpened)
                        {
                           NewImage(info, true);
                           _viewerOpened = true;
                        }
                        else
                        {
                           activeViewer.Image = info.Image;
                           activeViewer.Text = info.Name;
                           if(!((ViewerForm)MdiChildren[0]).OriginalViewer)
                              MdiChildren[0].Close();

                           if(MdiChildren.Length > 1)
                              if(!((ViewerForm)MdiChildren[1]).OriginalViewer)
                                 MdiChildren[1].Close();

                           ShowSave = false;
                           if(PreviousCheckQuality != null)
                              PreviousCheckQuality.Checked = false;
                        }
                     }
                  }
                  catch(Exception ex)
                  {
                     Messager.ShowFileOpenError(this, files[nI], ex);
                  }
               }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void MainForm_MdiChildActivate(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void _miFile_Popup(object sender, System.EventArgs e)
      {
         if(MdiChildren.Length != 0)
         {
            if(((ViewerForm)MdiChildren[0]).OriginalViewer)
               ((ViewerForm)MdiChildren[0]).Activate();
            else
               ((ViewerForm)MdiChildren[1]).Activate();
         }
      }

      private void LoadImage(bool loadDefaultImage)
      {
         ImageFileLoader loader = new ImageFileLoader();
         ViewerForm activeViewer = ActiveViewerForm;

         try
         {
            ImageInformation info = null;

            if (loadDefaultImage)
            {
               
               if (loader.Load(this, DemosGlobal.ImagesFolder + @"\clean.tif", _codecs, 1, 1))
               {
                  info = new ImageInformation(loader.Image, loader.FileName);
               }
            }
            else
            {
               int filesCount = loader.Load(this, _codecs, true);
               if (filesCount > 0 && loader.Images[0] != null)
                  info = loader.Images[0];
            }

            if (info != null)
            {
               if (info.Image.HasRegion)
                  info.Image.MakeRegionEmpty();

               _fileName = info.Name;
               info.Name += " (Original)";

               if (!_viewerOpened)
               {
                  NewImage(info, true);
                  _viewerOpened = true;
               }
               else
               {
                  activeViewer.Image = info.Image;
                  activeViewer.Text = info.Name;
                  if (!((ViewerForm)MdiChildren[0]).OriginalViewer)
                     MdiChildren[0].Close();

                  if (MdiChildren.Length > 1)
                     if (!((ViewerForm)MdiChildren[1]).OriginalViewer)
                        MdiChildren[1].Close();

                  ShowSave = false;
                  if (PreviousCheckQuality != null)
                     PreviousCheckQuality.Checked = false;
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         LoadImage(false);
      }

      private void _miFileClose_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeViewer = ActiveViewerForm;

         activeViewer.Close();
      }

      private void _miFileSaveCurrentAsAbc_Click(object sender, System.EventArgs e)
      {
         SaveFileDialog saveDlg = new SaveFileDialog();
         saveDlg.FileName = _fileName.Remove(_fileName.Length - 4, 4);
         saveDlg.OverwritePrompt = true;

         string formatString = _quality;
         formatString = (formatString.Trim()).Substring(1, formatString.Length - 3);

         saveDlg.FileName += "_Abc_" + formatString + ".abc";
         saveDlg.Title = "Save As ABC (LEAD ABC Format)";
         saveDlg.Filter = "LEAD ABC Format (*.abc)|*.abc";

         try
         {
            if(saveDlg.ShowDialog() == DialogResult.OK)
            {
               ViewerForm activeViewer = ActiveViewerForm;
               _codecs.Save(activeViewer.Image, saveDlg.FileName, RasterImageFormat.Abc, 1);
            }
         }
         catch(Exception ex)
         {
            Messager.ShowFileSaveError(this, saveDlg.FileName, ex);
         }
      }

      private void _miFileSaveCurrentAsTIFF_Click(object sender, System.EventArgs e)
      {
         SaveFileDialog saveDlg = new SaveFileDialog();
         saveDlg.FileName = _fileName.Remove(_fileName.Length - 4, 4);
         saveDlg.OverwritePrompt = true;

         string formatString = _quality;
         formatString = (formatString.Trim()).Substring(1, formatString.Length - 3);

         saveDlg.FileName += "_Tiff_" + formatString + ".tif";
         saveDlg.Title = "Save As TIFF (TIFF LEAD ABC Format)";
         saveDlg.Filter = "TIFF LEAD ABC Format (*.tif)|*.tif";

         try
         {
            if(saveDlg.ShowDialog() == DialogResult.OK)
            {
               ViewerForm activeViewer = ActiveViewerForm;
               _codecs.Save(activeViewer.Image, saveDlg.FileName, RasterImageFormat.TifAbc, 1, 1, 1, 1, CodecsSavePageMode.Append);
            }
         }
         catch(Exception ex)
         {
            Messager.ShowFileSaveError(this, saveDlg.FileName, ex);
         }
      }

      private void _miFileSaveAllPagesAsTIFF_Click(object sender, System.EventArgs e)
      {
         SaveFileDialog saveDlg = new SaveFileDialog();
         saveDlg.FileName = _fileName.Remove(_fileName.Length - 4, 4);
         saveDlg.OverwritePrompt = true;

         string formatString = _quality;
         formatString = (formatString.Trim()).Substring(1, formatString.Length - 3);

         saveDlg.FileName += "_M_" + formatString + ".tif";
         saveDlg.Title = "Save All Pages (TIFF LEAD ABC Format)";
         saveDlg.Filter = "TIFF LEAD ABC Format (*.tif)|*.tif";

         using(WaitCursor wait = new WaitCursor())
         {
            try
            {
               if(saveDlg.ShowDialog() == DialogResult.OK)
               {
                  if(File.Exists(saveDlg.FileName))
                     File.Delete(saveDlg.FileName);

                  int index;
                  CombineCommand cmd = new CombineCommand();
                  int loopStep = (_miQualityCombineTwoImages.Checked) ? 2 : 1;

                  RasterImage fullImage = _codecs.Load(_fileName, 0, CodecsLoadByteOrder.BgrOrGray, 1, -1);
                  if(fullImage.HasRegion)
                     fullImage.MakeRegionEmpty();

                  StopSaving = false;

                  for(index = 1; index <= fullImage.PageCount && !StopSaving; index += loopStep)
                  {
                     _sbMainStatus.Text = string.Format("Saving page {0}/{1}. Press Esc to cancel.", index, fullImage.PageCount);

                     fullImage.Page = index;
                     int newWidth = fullImage.Width;
                     int newHeight = fullImage.Height;

                     if(index + 1 > fullImage.PageCount || !_miQualityCombineTwoImages.Checked)
                     {
                        RasterImage newImage = fullImage.Clone();
                        _codecs.Save(newImage, saveDlg.FileName, RasterImageFormat.TifAbc, 1, 1, 1, 1, CodecsSavePageMode.Append);
                     }
                     else
                     {
                        fullImage.Page = index + 1;
                        newWidth = Math.Max(newWidth, fullImage.Width);
                        newHeight += fullImage.Height;
                        RasterImage newImage = new RasterImage(RasterMemoryFlags.Conventional, newWidth, newHeight, 24, RasterByteOrder.Bgr, RasterViewPerspective.TopLeft, null, IntPtr.Zero, 0);

                        fullImage.Page = index;

                        cmd.SourceImage = fullImage;
                        cmd.DestinationRectangle = new LeadRect(0, 0, fullImage.Width, fullImage.Height);
                        cmd.Run(newImage);

                        fullImage.Page = index + 1;

                        cmd.SourceImage = fullImage;
                        cmd.DestinationRectangle = new LeadRect(0, newHeight - fullImage.Height, fullImage.Width, fullImage.Height);
                        cmd.Run(newImage);

                        _codecs.Save(newImage, saveDlg.FileName, RasterImageFormat.TifAbc, 1, 1, 1, 1, CodecsSavePageMode.Append);
                     }
                     Application.DoEvents();
                  }
                  fullImage.Page = 1;
               }
            }
            catch(Exception ex)
            {
               Messager.ShowFileSaveError(this, saveDlg.FileName, ex);
            }
            _sbMainStatus.Text = "";
         }
      }

      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void _miEditCopy_Click(object sender, System.EventArgs e)
      {
         try
         {
            using(WaitCursor wait = new WaitCursor())
            {
               RasterClipboard.Copy(
                  this.Handle,
                  ImageToRun,
                  RasterClipboardCopyFlags.Empty |
                  RasterClipboardCopyFlags.Dib |
                  RasterClipboardCopyFlags.Palette |
                  RasterClipboardCopyFlags.Region);
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _miView_Popup(object sender, System.EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;
         _miViewFitToWindow.Checked = false;
         _miViewNormal.Checked = false;
         if (activeForm.Viewer.SizeMode == ControlSizeMode.Fit)
            _miViewFitToWindow.Checked = true;
         else if (activeForm.Viewer.SizeMode == ControlSizeMode.ActualSize)
            _miViewNormal.Checked = true;
      }


      public void _miView_Click(object sender, System.EventArgs e)
      {
         // get the current center in logical units
         ImageViewer viewer = ActiveViewerForm.Viewer; // get the active viewer

         // zoom     
         double scaleFactor = viewer.ScaleFactor;
         ControlSizeMode sizeMode = ControlSizeMode.None;
         const float ratio = 1.2F;

         if(sender == _miViewZoomIn)
         {
            sizeMode = ControlSizeMode.None;
            scaleFactor *= ratio;
         }
         else if(sender == _miViewZoomOut)
         {
            sizeMode = ControlSizeMode.None;
            scaleFactor /= ratio;
         }
         else if(sender == _miViewNormal)
         {
            sizeMode = ControlSizeMode.ActualSize;
            scaleFactor = 1.0;
         }
         else if(sender == _miViewFitToWindow)
         {
            sizeMode = ControlSizeMode.Fit;
            scaleFactor = 1.0;
         }
         else if(sender == _miViewSnapToImage)
         {
            ViewerForm activeViewer = ActiveViewerForm;
            activeViewer.Snap();
            if(activeViewer.WindowState != FormWindowState.Normal)
               activeViewer.WindowState = FormWindowState.Normal;
         }

         scaleFactor = Math.Max(_minimumScaleFactor, Math.Min(_maximumScaleFactor, scaleFactor));

         if((viewer.ScaleFactor != scaleFactor) || (viewer.SizeMode != sizeMode))
         {
            viewer.Zoom(sizeMode, scaleFactor, viewer.DefaultZoomOrigin);
         }
      }

      private void _miQualityCombineTwoImages_Click(object sender, System.EventArgs e)
      {
         _miQualityCombineTwoImages.Checked = !_miQualityCombineTwoImages.Checked;
      }

      private void _miQuality_Click(object sender, System.EventArgs e)
      {
         WaitCursor wait = new WaitCursor();

         if(!((ViewerForm)MdiChildren[0]).OriginalViewer)
            MdiChildren[0].Close();

         if(MdiChildren.Length > 1)
            if(!((ViewerForm)MdiChildren[1]).OriginalViewer)
               MdiChildren[1].Close();

         ((ViewerForm)MdiChildren[0]).Activate();

         if (!Directory.Exists(_saveDirectory))
            Directory.CreateDirectory(_saveDirectory);

         if(File.Exists(_saveFileName))
            File.Delete(_saveFileName);

         if(File.Exists(_saveFileNameG4))
            File.Delete(_saveFileNameG4);

         if(sender == _miQualityLossless)
         {
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Lossless;
            _quality = " (Lossless)";
         }
         else if(sender == _miQualityFastLossless)
         {
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.LosslessFast;
            _quality = " (Fast Lossless)";
         }
         else if(sender == _miQualityFastLossy)
         {
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.LossyFast;
            _quality = " (Fast Lossy)";
         }
         else if(sender == _miQualityVirtualLossless)
         {
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.VirtualLossless;
            _quality = " (Virtual Lossless)";
         }
         else if(sender == _miQualityRemoveBorder)
         {
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.RemoveBorder;
            _quality = " (Remove Border)";
         }
         else if(sender == _miQualityEnhanced)
         {
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Enhance;
            _quality = " (Enhance)";
         }
         else if(sender == _miQualityModified1)
         {
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Modified1;
            _quality = " (Modified1)";
         }
         else if(sender == _miQualityFastModified1)
         {
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Modified1Fast;
            _quality = " (Fast Modified1)";
         }
         else if(sender == _miQualityModified2)
         {
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Modified2;
            _quality = " (Modified2)";
         }
         else if(sender == _miQualityFastModified2)
         {
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Modified2Fast;
            _quality = " (Fast Modified2)";
         }
         else if(sender == _miQualityModified3)
         {
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Modified3;
            _quality = " (Modified3)";
         }
         else if(sender == _miQualityFastModified3)
         {
            _codecs.Options.Abc.Save.QualityFactor = CodecsAbcQualityFactor.Modified3Fast;
            _quality = " (Fast Modified3)";
         }

         string tempFileName = _saveFileName;

         if(_previousCheckQuality != null)
            _previousCheckQuality.Checked = false;

         _previousCheckQuality = (MenuItem)sender;
         _previousCheckQuality.Checked = true;

         try
         {
            ViewerForm activeViewer = ActiveViewerForm;

            _codecs.Save(activeViewer.Image, _saveFileName, RasterImageFormat.Abc, 1);

            tempFileName = _saveFileNameG4;

            _codecs.Save(activeViewer.Image, _saveFileNameG4, RasterImageFormat.CcittGroup4, 1);

            ImageInformation savedImageInformation = new ImageInformation(_codecs.Load(_saveFileName), _saveFileName);

            savedImageInformation.Name += _quality;

            NewImage(savedImageInformation, false);

            LayoutMdi(MdiLayout.TileVertical);
            setCheckWindow(_miWindowTileVertical);

            FileInfo fileInformation = new FileInfo(_saveFileName);

            long previewSize = fileInformation.Length;

            fileInformation = new FileInfo(_saveFileNameG4);

            long previewG4Size = fileInformation.Length;

            int improvement = (int)(((double)previewG4Size / previewSize) * 10000.0 - 10000);

            Messager.ShowInformation(this, string.Format("CCITT G4: {0:#,##0}  bytes\nLEAD ABC: {1:#,##0} bytes\n\n{2:0.00}% Reduction", previewG4Size, previewSize, improvement / 100.0));
            _showSave = true;
         }
         catch(Exception ex)
         {
            Messager.ShowFileSaveError(this, tempFileName, ex);
         }
         wait.Dispose();
         UpdateControls();
      }

      private void setCheckWindow(MenuItem menuItem)
      {
         _miWindowCascade.Checked = false;
         _miWindowTileHorizontal.Checked = false;
         _miWindowTileVertical.Checked = false;
         _miWindowArrangeIcons.Checked = false;

         menuItem.Checked = true;
      }

      private void _miWindow_Click(object sender, System.EventArgs e)
      {
         if(sender == _miWindowCascade)
            LayoutMdi(MdiLayout.Cascade);
         else if(sender == _miWindowTileHorizontal)
            LayoutMdi(MdiLayout.TileHorizontal);
         else if(sender == _miWindowTileVertical)
            LayoutMdi(MdiLayout.TileVertical);
         else if(sender == _miWindowArrangeIcons)
            LayoutMdi(MdiLayout.ArrangeIcons);

         setCheckWindow((MenuItem)sender);
      }

      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("ABC", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }
   }
}
