// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data;
using System.IO;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Controls;
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Core;

using Leadtools.Drawing;

namespace PrintPreviewDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.ToolBarButton _tbbFileOpen;
      private System.Windows.Forms.ToolBarButton _tbbSep1;
      private System.Windows.Forms.ToolBarButton _tbbZoomIn;
      private System.Windows.Forms.ToolBarButton _tbbZoomOut;
      private System.Windows.Forms.ToolBarButton _tbbSep2;
      private System.Windows.Forms.ToolBar _tbMain;
      private System.Windows.Forms.ToolBarButton _tbbSep3;
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.MenuItem _miFilePrint;
      private System.Windows.Forms.MenuItem _miFileSep2;
      private System.Windows.Forms.MenuItem _miFilePrintPreview;
      private System.Windows.Forms.MenuItem _miPage;
      private System.Windows.Forms.MenuItem _miPageFirst;
      private System.Windows.Forms.MenuItem _miPagePrevious;
      private System.Windows.Forms.MenuItem _miPageNext;
      private System.Windows.Forms.MenuItem _miPageLast;
      private System.Windows.Forms.ToolBarButton _tbbFilePrint;
      private System.Windows.Forms.ToolBarButton _tbbFilePrintPreview;
      private System.Windows.Forms.ToolBarButton _tbbPagePrevious;
      private System.Windows.Forms.ToolBarButton _tbbPageNext;
      private System.Windows.Forms.MenuItem _miZoom;
      private System.Windows.Forms.MenuItem _miZoomIn;
      private System.Windows.Forms.MenuItem _miZoomOut;
      private System.Windows.Forms.MenuItem _miZoomSep1;
      private System.Windows.Forms.MenuItem _miZoomNormal;
      private System.Windows.Forms.ToolBarButton _tbbZoomNone;
      private System.Windows.Forms.MenuItem _miFilePageSetup;
      private System.Windows.Forms.ToolBarButton _tbbPageFirst;
      private System.Windows.Forms.ToolBarButton _tbbPageLast;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public MainForm()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();

         //
         // TODO: Add any constructor code after InitializeComponent call
         //
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
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
         this._tbMain = new System.Windows.Forms.ToolBar();
         this._tbbFileOpen = new System.Windows.Forms.ToolBarButton();
         this._tbbSep1 = new System.Windows.Forms.ToolBarButton();
         this._tbbFilePrint = new System.Windows.Forms.ToolBarButton();
         this._tbbSep2 = new System.Windows.Forms.ToolBarButton();
         this._tbbZoomIn = new System.Windows.Forms.ToolBarButton();
         this._tbbZoomOut = new System.Windows.Forms.ToolBarButton();
         this._tbbZoomNone = new System.Windows.Forms.ToolBarButton();
         this._tbbFilePrintPreview = new System.Windows.Forms.ToolBarButton();
         this._tbbSep3 = new System.Windows.Forms.ToolBarButton();
         this._tbbPageFirst = new System.Windows.Forms.ToolBarButton();
         this._tbbPagePrevious = new System.Windows.Forms.ToolBarButton();
         this._tbbPageNext = new System.Windows.Forms.ToolBarButton();
         this._tbbPageLast = new System.Windows.Forms.ToolBarButton();
         this._mmMain = new System.Windows.Forms.MainMenu();
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileOpen = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFilePrint = new System.Windows.Forms.MenuItem();
         this._miFilePageSetup = new System.Windows.Forms.MenuItem();
         this._miFilePrintPreview = new System.Windows.Forms.MenuItem();
         this._miFileSep2 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miZoom = new System.Windows.Forms.MenuItem();
         this._miZoomIn = new System.Windows.Forms.MenuItem();
         this._miZoomOut = new System.Windows.Forms.MenuItem();
         this._miZoomSep1 = new System.Windows.Forms.MenuItem();
         this._miZoomNormal = new System.Windows.Forms.MenuItem();
         this._miPage = new System.Windows.Forms.MenuItem();
         this._miPageFirst = new System.Windows.Forms.MenuItem();
         this._miPagePrevious = new System.Windows.Forms.MenuItem();
         this._miPageNext = new System.Windows.Forms.MenuItem();
         this._miPageLast = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // _tbMain
         // 
         this._tbMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
         this._tbMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                   this._tbbFileOpen,
                                                                                   this._tbbSep1,
                                                                                   this._tbbFilePrint,
                                                                                   this._tbbSep2,
                                                                                   this._tbbZoomIn,
                                                                                   this._tbbZoomOut,
                                                                                   this._tbbZoomNone,
                                                                                   this._tbbFilePrintPreview,
                                                                                   this._tbbSep3,
                                                                                   this._tbbPageFirst,
                                                                                   this._tbbPagePrevious,
                                                                                   this._tbbPageNext,
                                                                                   this._tbbPageLast});
         this._tbMain.DropDownArrows = true;
         this._tbMain.Location = new System.Drawing.Point(0, 0);
         this._tbMain.Name = "_tbMain";
         this._tbMain.ShowToolTips = true;
         this._tbMain.Size = new System.Drawing.Size(680, 28);
         this._tbMain.TabIndex = 0;
         this._tbMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this._tbMain_ButtonClick);
         // 
         // _tbbFileOpen
         // 
         this._tbbFileOpen.ImageIndex = 0;
         this._tbbFileOpen.ToolTipText = "Open";
         // 
         // _tbbSep1
         // 
         this._tbbSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // _tbbFilePrint
         // 
         this._tbbFilePrint.ImageIndex = 1;
         this._tbbFilePrint.ToolTipText = "Print";
         // 
         // _tbbSep2
         // 
         this._tbbSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // _tbbZoomIn
         // 
         this._tbbZoomIn.ImageIndex = 2;
         this._tbbZoomIn.ToolTipText = "Zoom In";
         // 
         // _tbbZoomOut
         // 
         this._tbbZoomOut.ImageIndex = 3;
         this._tbbZoomOut.ToolTipText = "Zoom Out";
         // 
         // _tbbZoomNone
         // 
         this._tbbZoomNone.ImageIndex = 4;
         this._tbbZoomNone.ToolTipText = "No Zoom (100%)";
         // 
         // _tbbFilePrintPreview
         // 
         this._tbbFilePrintPreview.ImageIndex = 5;
         this._tbbFilePrintPreview.ToolTipText = "Print Preview";
         // 
         // _tbbSep3
         // 
         this._tbbSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
         // 
         // _tbbPageFirst
         // 
         this._tbbPageFirst.ImageIndex = 6;
         // 
         // _tbbPagePrevious
         // 
         this._tbbPagePrevious.ImageIndex = 7;
         this._tbbPagePrevious.ToolTipText = "Previous Page";
         // 
         // _tbbPageNext
         // 
         this._tbbPageNext.ImageIndex = 8;
         this._tbbPageNext.ToolTipText = "Next Page";
         // 
         // _tbbPageLast
         // 
         this._tbbPageLast.ImageIndex = 9;
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this._miFile,
                                                                                this._miZoom,
                                                                                this._miPage,
                                                                                this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this._miFileOpen,
                                                                                this._miFileSep1,
                                                                                this._miFilePrint,
                                                                                this._miFilePageSetup,
                                                                                this._miFilePrintPreview,
                                                                                this._miFileSep2,
                                                                                this._miFileExit});
         this._miFile.Text = "&File";
         // 
         // _miFileOpen
         // 
         this._miFileOpen.Index = 0;
         this._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this._miFileOpen.Text = "&Open...";
         this._miFileOpen.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileSep1
         // 
         this._miFileSep1.Index = 1;
         this._miFileSep1.Text = "-";
         // 
         // _miFilePrint
         // 
         this._miFilePrint.Index = 2;
         this._miFilePrint.Text = "&Print...";
         this._miFilePrint.Click += new System.EventHandler(this._miFilePrint_Click);
         // 
         // _miFilePageSetup
         // 
         this._miFilePageSetup.Index = 3;
         this._miFilePageSetup.Text = "Page &Setup...";
         this._miFilePageSetup.Click += new System.EventHandler(this._miFilePageSetup_Click);
         // 
         // _miFilePrintPreview
         // 
         this._miFilePrintPreview.Index = 4;
         this._miFilePrintPreview.Text = "Print Pre&view...";
         this._miFilePrintPreview.Click += new System.EventHandler(this._miFilePrintPreview_Click);
         // 
         // _miFileSep2
         // 
         this._miFileSep2.Index = 5;
         this._miFileSep2.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 6;
         this._miFileExit.Text = "E&xit";
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
         this._miZoom.Text = "&Zoom";
         // 
         // _miZoomIn
         // 
         this._miZoomIn.Index = 0;
         this._miZoomIn.RadioCheck = true;
         this._miZoomIn.Text = "&In (2x)";
         this._miZoomIn.Click += new System.EventHandler(this._miZoom_Click);
         // 
         // _miZoomOut
         // 
         this._miZoomOut.Index = 1;
         this._miZoomOut.RadioCheck = true;
         this._miZoomOut.Text = "&Out (2x)";
         this._miZoomOut.Click += new System.EventHandler(this._miZoom_Click);
         // 
         // _miZoomSep1
         // 
         this._miZoomSep1.Index = 2;
         this._miZoomSep1.RadioCheck = true;
         this._miZoomSep1.Text = "-";
         // 
         // _miZoomNormal
         // 
         this._miZoomNormal.Index = 3;
         this._miZoomNormal.RadioCheck = true;
         this._miZoomNormal.Text = "&Normal (100%)";
         this._miZoomNormal.Click += new System.EventHandler(this._miZoom_Click);
         // 
         // _miPage
         // 
         this._miPage.Index = 2;
         this._miPage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this._miPageFirst,
                                                                                this._miPagePrevious,
                                                                                this._miPageNext,
                                                                                this._miPageLast});
         this._miPage.Text = "&Page";
         // 
         // _miPageFirst
         // 
         this._miPageFirst.Index = 0;
         this._miPageFirst.Text = "&First";
         this._miPageFirst.Click += new System.EventHandler(this._miPage_Click);
         // 
         // _miPagePrevious
         // 
         this._miPagePrevious.Index = 1;
         this._miPagePrevious.Text = "&Previous";
         this._miPagePrevious.Click += new System.EventHandler(this._miPage_Click);
         // 
         // _miPageNext
         // 
         this._miPageNext.Index = 2;
         this._miPageNext.Text = "&Next";
         this._miPageNext.Click += new System.EventHandler(this._miPage_Click);
         // 
         // _miPageLast
         // 
         this._miPageLast.Index = 3;
         this._miPageLast.Text = "&Last";
         this._miPageLast.Click += new System.EventHandler(this._miPage_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 3;
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
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(680, 417);
         this.Controls.Add(this._tbMain);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
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

      // the raster image viewer
      private ImageViewer _viewer;

      // codecs used in loading images
      private RasterCodecs _codecs;

      // Print document object
      private PrintDocument _printDocument;
      private int _printPage;

      private const float _minScaleFactor = 0.009F;
      private const float _maxScaleFactor = 11F;

      private const int _defaultXResolution = 96;
      private const int _defaultYResolution = 96;

      private string _openInitialPath = string.Empty;

      /// <summary>
      /// Initialize the Application
      /// </summary>
      private void MainForm_Load(object sender, System.EventArgs e)
      {
         // setup the toolbar images
         Bitmap btmp = new Bitmap(GetType(), "Resources.ToolBar.bmp");
         btmp.MakeTransparent(btmp.GetPixel(0, 0));
         _tbMain.ImageList = new ImageList();
         _tbMain.ImageList.ColorDepth = ColorDepth.Depth24Bit;
         _tbMain.ImageList.ImageSize = new Size(btmp.Height, btmp.Height);
         _tbMain.ImageList.Images.AddStrip(btmp);

         // setup our caption
         Messager.Caption = "LEADTOOLS for .NET C# Print Preview Demo";
         Text = Messager.Caption;

         // initialize the _viewer object
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();

         // check if there is printer installed
         try
         {
            if (PrinterSettings.InstalledPrinters != null && PrinterSettings.InstalledPrinters.Count > 0)
            {
               _printDocument = new PrintDocument();
               _printDocument.PrintPage += new PrintPageEventHandler(_printDocument_PrintPage);
            }
            else
               _printDocument = null;
         }
         catch (Exception)
         {
            _printDocument = null;
         }

         // initialize the codecs object
         _codecs = new RasterCodecs();

         // initialize controls
         UpdateMyControls();
      }

      /// <summary>
      /// Updates the UI, depending on the application state.
      /// </summary>
      private void UpdateMyControls()
      {
         _miFilePrint.Enabled = ((_printDocument != null) && (_viewer.Image != null));
         _miFilePrint.Visible = ((_printDocument != null) && (_viewer.Image != null));
         _miFilePageSetup.Enabled = (_printDocument != null);
         _miFilePageSetup.Visible = (_printDocument != null);
         _miFilePrintPreview.Enabled = ((_printDocument != null) && (_viewer.Image != null));
         _miFilePrintPreview.Visible = ((_printDocument != null) && (_viewer.Image != null));
         _miFileSep2.Enabled = (_printDocument != null);
         _miFileSep2.Visible = (_printDocument != null);
         _miZoom.Enabled = (_viewer.Image != null);
         _miZoom.Visible = (_viewer.Image != null);
         if ((_viewer.Image != null) && (_viewer.Image.PageCount > 1))
         {
            _miPage.Enabled = true;
            _miPage.Visible = true;
            int page = _viewer.Image.Page;
            _miPageFirst.Enabled = (page != 1);
            _miPageFirst.Visible = true;
            _miPagePrevious.Enabled = (page != 1);
            _miPagePrevious.Visible = true;
            _miPageNext.Enabled = (page != _viewer.Image.PageCount);
            _miPageNext.Visible = true;
            _miPageLast.Enabled = (page != _viewer.Image.PageCount);
            _miPageLast.Visible = true;

            _tbbPageFirst.Enabled = _miPageFirst.Enabled;
            _tbbPageFirst.Visible = true;
            _tbbPagePrevious.Enabled = _miPagePrevious.Enabled;
            _tbbPagePrevious.Visible = true;
            _tbbPageNext.Enabled = _miPageNext.Enabled;
            _tbbPageNext.Visible = true;
            _tbbPageLast.Enabled = _miPageLast.Enabled;
            _tbbPageLast.Visible = true;
         }
         else
         {
            _miPage.Enabled = false;
            _miPage.Visible = false;
            _tbbPageFirst.Enabled = false;
            _tbbPageFirst.Visible = false;
            _tbbPagePrevious.Enabled = false;
            _tbbPagePrevious.Visible = false;
            _tbbPageNext.Enabled = false;
            _tbbPageNext.Visible = false;
            _tbbPageLast.Enabled = false;
            _tbbPageLast.Visible = false;
         }
         _tbbFilePrint.Enabled = _miFilePrint.Enabled;
         _tbbFilePrint.Visible = _miFilePrint.Visible;
         _tbbSep2.Enabled = (_viewer.Image != null);
         _tbbSep2.Visible = (_viewer.Image != null);
         _tbbZoomIn.Enabled = (_viewer.Image != null);
         _tbbZoomIn.Visible = (_viewer.Image != null);
         _tbbZoomOut.Enabled = (_viewer.Image != null);
         _tbbZoomOut.Visible = (_viewer.Image != null);
         _tbbZoomNone.Enabled = (_viewer.Image != null);
         _tbbZoomNone.Visible = (_viewer.Image != null);
         _tbbFilePrintPreview.Enabled = _miFilePrintPreview.Enabled;
         _tbbFilePrintPreview.Visible = _miFilePrintPreview.Visible;
         _tbbSep3.Enabled = (_viewer.Image != null);
         _tbbSep3.Visible = (_viewer.Image != null);

         _tbbZoomOut.Enabled = (_viewer.ScaleFactor > _minScaleFactor);
         _tbbZoomIn.Enabled = (_viewer.ScaleFactor < _maxScaleFactor);
         _tbbZoomNone.Enabled = (_viewer.ScaleFactor != 1);

         _miZoomIn.Enabled = _tbbZoomIn.Enabled;
         _miZoomOut.Enabled = _tbbZoomOut.Enabled;
         _miZoomNormal.Enabled = _tbbZoomNone.Enabled;
      }

      /// <summary>
      /// Open new image
      /// </summary>
      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         try
         {
            ImageFileLoader loader = new ImageFileLoader();

            loader.OpenDialogInitialPath = _openInitialPath;
            loader.ShowLoadPagesDialog = true;
            if (loader.Load(this, _codecs, true) > 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               // update the caption
               Text = string.Format("{0} - {1}", loader.FileName, Messager.Caption);

               // set the new image in the viewer
               _viewer.Image = loader.Image;

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
      /// Print the current image
      /// </summary>
      private void _miFilePrint_Click(object sender, System.EventArgs e)
      {
         _printPage = 1;
         if (_printDocument != null)
         {
            try
            {
               _printDocument.Print();
            }
            catch
            {
            }
         }
      }

      /// <summary>
      /// Setup the Page for printing
      /// </summary>
      private void _miFilePageSetup_Click(object sender, System.EventArgs e)
      {
         try
         {
            _printPage = 1;
            PageSetupDialog dlg = new PageSetupDialog();
            dlg.Document = _printDocument;
            dlg.ShowDialog(this);
         }
         catch { }
      }

      /// <summary>
      /// Show the Print Preview dialog
      /// </summary>
      private void _miFilePrintPreview_Click(object sender, System.EventArgs e)
      {
         try
         {
            _printPage = 1;
            if (_printDocument != null)
            {
               PrintPreviewDialog dlg = new PrintPreviewDialog();

               dlg.Icon = Icon;

               foreach (Control i in dlg.Controls)
               {
                  PrintPreviewControl c = i as PrintPreviewControl;
                  if (c != null)
                  {
                     c.StartPage = _viewer.Image.Page - 1;
                     break;
                  }
               }
               dlg.Document = _printDocument;
               dlg.ShowDialog(this);
            }
         }
         catch { }
      }

      /// <summary>
      /// Shutdown
      /// </summary>
      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      /// <summary>
      /// Handles Zoom menu
      /// </summary>
      private void _miZoom_Click(object sender, System.EventArgs e)
      {
         double scaleFactor = _viewer.ScaleFactor;

         if (sender == _miZoomIn)
            scaleFactor *= 2;
         else if (sender == _miZoomOut)
            scaleFactor /= 2;
         else if (sender == _miZoomNormal)
            scaleFactor = 1;
         _viewer.Zoom(ControlSizeMode.None, Math.Max(_minScaleFactor, Math.Min(_maxScaleFactor, scaleFactor)), _viewer.DefaultZoomOrigin);
         UpdateMyControls();
      }

      /// <summary>
      /// Handles Page menu
      /// </summary>
      private void _miPage_Click(object sender, System.EventArgs e)
      {
         int page = _viewer.Image.Page;
         if (sender == _miPageFirst)
            page = 1;
         else if (sender == _miPagePrevious)
            page--;
         else if (sender == _miPageNext)
            page++;
         else if (sender == _miPageLast)
            page = _viewer.Image.PageCount;

         page = Math.Max(1, Math.Min(_viewer.Image.PageCount, page));

         if (page != _viewer.Image.Page)
         {
            _viewer.Image.Page = page;
            UpdateMyControls();
         }
      }

      /// <summary>
      /// Show the About dialog
      /// </summary>
      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Print Preview", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      /// <summary>
      /// Toolbar button is clicked, call the corresponding menu PreformClick method
      /// </summary>
      private void _tbMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
      {
         if (e.Button == _tbbFileOpen)
            _miFileOpen.PerformClick();
         else if (e.Button == _tbbFilePrint)
            _miFilePrint.PerformClick();
         else if (e.Button == _tbbZoomIn)
            _miZoomIn.PerformClick();
         else if (e.Button == _tbbZoomOut)
            _miZoomOut.PerformClick();
         else if (e.Button == _tbbZoomNone)
            _miZoomNormal.PerformClick();
         else if (e.Button == _tbbFilePrintPreview)
            _miFilePrintPreview.PerformClick();
         else if (e.Button == _tbbPageFirst)
            _miPageFirst.PerformClick();
         else if (e.Button == _tbbPagePrevious)
            _miPagePrevious.PerformClick();
         else if (e.Button == _tbbPageNext)
            _miPageNext.PerformClick();
         else if (e.Button == _tbbPageLast)
            _miPageLast.PerformClick();
      }

      /// <summary>
      /// Print Page event
      /// </summary>
      private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
      {
         int savePage = _viewer.Image.Page;

         try
         {
            _viewer.Image.Page = _printPage;
            _printPage++;

            using (Image img = RasterImageConverter.ConvertToImage(_viewer.Image, ConvertToImageOptions.None))
            {
               if (DialogUtilities.CanRunPrintPreview)
                  e.Graphics.DrawImage(img, 0, 0);
            }

            e.HasMorePages = _printPage <= _viewer.Image.PageCount;
            if (_printPage > _viewer.Image.PageCount)
               _printPage = 1;
         }
         finally
         {
            _viewer.Image.Page = savePage;
         }
      }
   }
}
