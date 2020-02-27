// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Data;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Drawing;
using Leadtools.ImageProcessing;
using Leadtools.Mrc;
using Leadtools.PdfCompressor;
using Leadtools.WinForms.CommonDialogs.File;

namespace PdfCompDemo
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miFileSave;
      private System.Windows.Forms.MenuItem _miPdfOptions;
      private System.Windows.Forms.MenuItem _miWindow;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.MenuItem _miWindowCascade;
      private System.Windows.Forms.MenuItem _miWindowTileHorizontally;
      private System.Windows.Forms.MenuItem _miWindowTileVertically;
      private System.Windows.Forms.MenuItem _miWindowArrangeIcons;
      private System.Windows.Forms.MenuItem _miWindowCloseAll;
      private System.Windows.Forms.MenuItem _miPdfOptionsAdd;
      private System.Windows.Forms.MenuItem _miPdfOptionsModify;
      private System.Windows.Forms.MenuItem _miPdfOptionsDelete;
      private System.Windows.Forms.MenuItem menuItem4;
      private System.Windows.Forms.MenuItem _miPdfOptionsAdvanced;
      private System.Windows.Forms.ToolBar _tbMain;
      private System.Windows.Forms.ToolBarButton _tbbFileOpen;
      private System.Windows.Forms.ToolBarButton _tbbFileSave;
      private System.Windows.Forms.ToolBarButton _tbbPdfOptionsAdd;
      private System.Windows.Forms.ToolBarButton _tbbPdfOptionsDelete;
      private System.Windows.Forms.ToolBarButton _tbbHelpAbout;
      private System.Windows.Forms.ToolBarButton _tbbPdfOptionsModify;
      private System.Windows.Forms.MenuItem _miFilePrint;
      private System.Windows.Forms.MenuItem _miFilePrintPreview;
      private System.Windows.Forms.MenuItem _miSparator1;
      private System.Windows.Forms.MenuItem _miSparator2;
      private System.Windows.Forms.MenuItem menuItem2;
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
         this._miSparator1 = new System.Windows.Forms.MenuItem();
         this._miFilePrint = new System.Windows.Forms.MenuItem();
         this._miFilePrintPreview = new System.Windows.Forms.MenuItem();
         this._miSparator2 = new System.Windows.Forms.MenuItem();
         this.menuItem2 = new System.Windows.Forms.MenuItem();
         this._miPdfOptions = new System.Windows.Forms.MenuItem();
         this._miPdfOptionsAdd = new System.Windows.Forms.MenuItem();
         this._miPdfOptionsModify = new System.Windows.Forms.MenuItem();
         this._miPdfOptionsDelete = new System.Windows.Forms.MenuItem();
         this.menuItem4 = new System.Windows.Forms.MenuItem();
         this._miPdfOptionsAdvanced = new System.Windows.Forms.MenuItem();
         this._miWindow = new System.Windows.Forms.MenuItem();
         this._miWindowCascade = new System.Windows.Forms.MenuItem();
         this._miWindowTileHorizontally = new System.Windows.Forms.MenuItem();
         this._miWindowTileVertically = new System.Windows.Forms.MenuItem();
         this._miWindowArrangeIcons = new System.Windows.Forms.MenuItem();
         this._miWindowCloseAll = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this._tbMain = new System.Windows.Forms.ToolBar();
         this._tbbFileOpen = new System.Windows.Forms.ToolBarButton();
         this._tbbFileSave = new System.Windows.Forms.ToolBarButton();
         this._tbbPdfOptionsAdd = new System.Windows.Forms.ToolBarButton();
         this._tbbPdfOptionsModify = new System.Windows.Forms.ToolBarButton();
         this._tbbPdfOptionsDelete = new System.Windows.Forms.ToolBarButton();
         this._tbbHelpAbout = new System.Windows.Forms.ToolBarButton();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miPdfOptions,
            this._miWindow,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileOpen,
            this._miFileSave,
            this._miSparator1,
            this._miFilePrint,
            this._miFilePrintPreview,
            this._miSparator2,
            this.menuItem2});
         this._miFile.Text = "&File";
         // 
         // _miFileOpen
         // 
         this._miFileOpen.Index = 0;
         this._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this._miFileOpen.Text = "&Open";
         this._miFileOpen.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileSave
         // 
         this._miFileSave.Index = 1;
         this._miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this._miFileSave.Text = "&Save all";
         this._miFileSave.Click += new System.EventHandler(this._miFileSave_Click);
         // 
         // _miSparator1
         // 
         this._miSparator1.Index = 2;
         this._miSparator1.Text = "-";
         // 
         // _miFilePrint
         // 
         this._miFilePrint.Index = 3;
         this._miFilePrint.Text = "&Print";
         this._miFilePrint.Click += new System.EventHandler(this._miFilePrint_Click);
         // 
         // _miFilePrintPreview
         // 
         this._miFilePrintPreview.Index = 4;
         this._miFilePrintPreview.Text = "Print Pre&view...";
         this._miFilePrintPreview.Click += new System.EventHandler(this._miFilePrintPreview_Click);
         // 
         // _miSparator2
         // 
         this._miSparator2.Index = 5;
         this._miSparator2.Text = "-";
         // 
         // menuItem2
         // 
         this.menuItem2.Index = 6;
         this.menuItem2.Text = "E&xit";
         this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
         // 
         // _miPdfOptions
         // 
         this._miPdfOptions.Index = 1;
         this._miPdfOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miPdfOptionsAdd,
            this._miPdfOptionsModify,
            this._miPdfOptionsDelete,
            this.menuItem4,
            this._miPdfOptionsAdvanced});
         this._miPdfOptions.Text = "&Pdf Options";
         // 
         // _miPdfOptionsAdd
         // 
         this._miPdfOptionsAdd.Index = 0;
         this._miPdfOptionsAdd.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
         this._miPdfOptionsAdd.Text = "&Add Image->Pdf";
         this._miPdfOptionsAdd.Click += new System.EventHandler(this._miPdfOptionsAdd_Click);
         // 
         // _miPdfOptionsModify
         // 
         this._miPdfOptionsModify.Index = 1;
         this._miPdfOptionsModify.Shortcut = System.Windows.Forms.Shortcut.CtrlM;
         this._miPdfOptionsModify.Text = "&Modify Pdf Settings";
         this._miPdfOptionsModify.Click += new System.EventHandler(this._miPdfOptionsAdd_Click);
         // 
         // _miPdfOptionsDelete
         // 
         this._miPdfOptionsDelete.Index = 2;
         this._miPdfOptionsDelete.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
         this._miPdfOptionsDelete.Text = "&Delete Image->Pdf";
         this._miPdfOptionsDelete.Click += new System.EventHandler(this._miPdfOptionsDelete_Click);
         // 
         // menuItem4
         // 
         this.menuItem4.Index = 3;
         this.menuItem4.Text = "-";
         // 
         // _miPdfOptionsAdvanced
         // 
         this._miPdfOptionsAdvanced.Index = 4;
         this._miPdfOptionsAdvanced.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
         this._miPdfOptionsAdvanced.Text = "Ad&vanced";
         this._miPdfOptionsAdvanced.Click += new System.EventHandler(this._miPdfOptionsAdvanced_Click);
         // 
         // _miWindow
         // 
         this._miWindow.Index = 2;
         this._miWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miWindowCascade,
            this._miWindowTileHorizontally,
            this._miWindowTileVertically,
            this._miWindowArrangeIcons,
            this._miWindowCloseAll});
         this._miWindow.Text = "&Window";
         this._miWindow.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowCascade
         // 
         this._miWindowCascade.Index = 0;
         this._miWindowCascade.Text = "&Cascade";
         this._miWindowCascade.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowTileHorizontally
         // 
         this._miWindowTileHorizontally.Index = 1;
         this._miWindowTileHorizontally.Text = "Tile &Horizontally";
         this._miWindowTileHorizontally.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowTileVertically
         // 
         this._miWindowTileVertically.Index = 2;
         this._miWindowTileVertically.Text = "Tile &Vertically";
         this._miWindowTileVertically.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowArrangeIcons
         // 
         this._miWindowArrangeIcons.Index = 3;
         this._miWindowArrangeIcons.Text = "Arrange &Icons";
         this._miWindowArrangeIcons.Click += new System.EventHandler(this._miWindow_Click);
         // 
         // _miWindowCloseAll
         // 
         this._miWindowCloseAll.Index = 4;
         this._miWindowCloseAll.Text = "Close &All";
         this._miWindowCloseAll.Click += new System.EventHandler(this._miWindow_Click);
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
         this._miHelpAbout.Text = "&About";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // _tbMain
         // 
         this._tbMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
         this._tbMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this._tbbFileOpen,
            this._tbbFileSave,
            this._tbbPdfOptionsAdd,
            this._tbbPdfOptionsModify,
            this._tbbPdfOptionsDelete,
            this._tbbHelpAbout});
         this._tbMain.ButtonSize = new System.Drawing.Size(24, 22);
         this._tbMain.DropDownArrows = true;
         this._tbMain.Location = new System.Drawing.Point(0, 0);
         this._tbMain.Name = "_tbMain";
         this._tbMain.ShowToolTips = true;
         this._tbMain.Size = new System.Drawing.Size(711, 28);
         this._tbMain.TabIndex = 0;
         this._tbMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this._tbMain_ButtonClick);
         // 
         // _tbbFileOpen
         // 
         this._tbbFileOpen.ImageIndex = 0;
         this._tbbFileOpen.Name = "_tbbFileOpen";
         this._tbbFileOpen.ToolTipText = "Open";
         // 
         // _tbbFileSave
         // 
         this._tbbFileSave.ImageIndex = 1;
         this._tbbFileSave.Name = "_tbbFileSave";
         this._tbbFileSave.ToolTipText = "Save all added images";
         // 
         // _tbbPdfOptionsAdd
         // 
         this._tbbPdfOptionsAdd.ImageIndex = 2;
         this._tbbPdfOptionsAdd.Name = "_tbbPdfOptionsAdd";
         this._tbbPdfOptionsAdd.ToolTipText = "Add image to Pdf file";
         // 
         // _tbbPdfOptionsModify
         // 
         this._tbbPdfOptionsModify.ImageIndex = 3;
         this._tbbPdfOptionsModify.Name = "_tbbPdfOptionsModify";
         this._tbbPdfOptionsModify.ToolTipText = "Modify Image settings";
         // 
         // _tbbPdfOptionsDelete
         // 
         this._tbbPdfOptionsDelete.ImageIndex = 4;
         this._tbbPdfOptionsDelete.Name = "_tbbPdfOptionsDelete";
         this._tbbPdfOptionsDelete.ToolTipText = "Delete Image from queue";
         // 
         // _tbbHelpAbout
         // 
         this._tbbHelpAbout.ImageIndex = 5;
         this._tbbHelpAbout.Name = "_tbbHelpAbout";
         this._tbbHelpAbout.ToolTipText = "About Pdf Compressor";
         // 
         // MainForm
         // 
         this.AllowDrop = true;
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(711, 470);
         this.Controls.Add(this._tbMain);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.IsMdiContainer = true;
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
         this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
         this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

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

      public ViewerForm ActiveViewerForm
      {
         get
         {
            return ActiveMdiChild as ViewerForm;
         }
      }

      // the raster codecs used in load/save
      private RasterCodecs _codecs;
      private RasterPaintProperties _paintProperties;
      private PrintDocument _printDocument;


      private void NewImage(ImageInformation info)
      {
         ViewerForm child = new ViewerForm();
         child.StandardOptions = new PdfStandardOptions();
         child.AdvancedOptions = new PdfAdvancedOptions();
         child.MdiParent = this;
         _paintProperties = RasterPaintProperties.Default;
         child.Initialize(info, _paintProperties, true);
         child.Show();
      }

      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         try
         {
            ImageInformation info = LoadImage();
            if (info != null)
               NewImage(info);
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

      private ImageInformation LoadImage()
      {
         PdfImageFileLoader loader = new PdfImageFileLoader();

         try
         {
            if (loader.Load(this, _codecs, true))
            {

               if (loader.Image.HasRegion)
                  loader.Image.MakeRegionEmpty();
               return new ImageInformation(loader.Image, loader.FileName);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }

         return null;
      }

      private void _miWindow_Click(object sender, System.EventArgs e)
      {
         if (sender == _miWindowCascade)
            LayoutMdi(MdiLayout.Cascade);
         else if (sender == _miWindowTileHorizontally)
            LayoutMdi(MdiLayout.TileHorizontal);
         else if (sender == _miWindowTileVertically)
            LayoutMdi(MdiLayout.TileVertical);
         else if (sender == _miWindowArrangeIcons)
            LayoutMdi(MdiLayout.ArrangeIcons);
         else if (sender == _miWindowCloseAll)
         {
            while (MdiChildren.Length > 0)
               MdiChildren[0].Close();
            UpdateControls();
         }
      }

      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Pdf Compressor", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _miPdfOptionsAdd_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;
         PdfOptionsAddDialog();
         MainForm.ActiveForm.Refresh();

      }
      public void PdfOptionsAddDialog()
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;
            PdfOptionsDialog OptionsDlg = new PdfOptionsDialog();
            OptionsDlg.StandardOptions = new PdfStandardOptions();

            if (activeForm.StandardOptions.Added)
               OptionsDlg.StandardOptions = activeForm.StandardOptions;
            OptionsDlg.ShowDialog(this);
            if (OptionsDlg.StandardOptions.Added)
               activeForm.StandardOptions = OptionsDlg.StandardOptions;
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

      private void MainForm_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
      {
         if (Tools.CanDrop(e.Data))
            e.Effect = DragDropEffects.Copy;
      }

      private void MainForm_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
      {
         if (Tools.CanDrop(e.Data))
         {
            string[] files = Tools.GetDropFiles(e.Data);
            if (files != null)
               LoadDropFiles(null, files);
         }
      }

      public void LoadDropFiles(ViewerForm viewer, string[] files)
      {
         try
         {
            if (files != null)
            {
               for (int i = 0; i < files.Length; i++)
               {
                  try
                  {
                     RasterImage image = _codecs.Load(files[i]);
                     ImageInformation info = new ImageInformation(image, files[i]);
                     if (i == 0 && viewer != null)
                        viewer.Initialize(info, _paintProperties, false);
                     else
                        NewImage(info);
                  }
                  catch (Exception ex)
                  {
                     Messager.ShowFileOpenError(this, files[i], ex);
                  }
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


      private void _miPdfOptionsAdvanced_Click(object sender, System.EventArgs e)
      {
         try
         {
            ViewerForm activeForm = ActiveViewerForm;
            PdfAdvancedOptionsDialog AdvancedOptionsDlg = new PdfAdvancedOptionsDialog();
            AdvancedOptionsDlg.AdvancedOptions = new PdfAdvancedOptions();

            AdvancedOptionsDlg.AdvancedOptions = activeForm.AdvancedOptions;

            if (AdvancedOptionsDlg.ShowDialog(this) == DialogResult.OK)
            {
               activeForm.AdvancedOptions = AdvancedOptionsDlg.AdvancedOptions;
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }

      }

      public void UpdateControls()
      {
         ViewerForm activeForm = ActiveViewerForm;
         try
         {
            EnableAndVisibleMenu(_miFileSave, activeForm != null);
            EnableAndVisibleMenu(_miPdfOptions, activeForm != null);
            EnableAndVisibleMenu(_miWindow, activeForm != null);
            EnableAndVisibleMenu(_miFilePrint, _printDocument != null && activeForm != null);
            EnableAndVisibleMenu(_miFilePrintPreview, _printDocument != null && activeForm != null);
            EnableAndVisibleMenu(_miSparator1, activeForm != null);
            EnableAndVisibleMenu(_miSparator2, activeForm != null);

            _tbbFileSave.Enabled = _miFileSave.Enabled;

            if (activeForm != null)
            {
               _miPdfOptionsModify.Enabled = _tbbPdfOptionsModify.Enabled = activeForm.StandardOptions.Added;
               _miPdfOptionsDelete.Enabled = _tbbPdfOptionsDelete.Enabled = activeForm.StandardOptions.Added;
               _miPdfOptionsAdd.Enabled = _tbbPdfOptionsAdd.Enabled = !activeForm.StandardOptions.Added;
            }
            else
            {
               _tbbPdfOptionsAdd.Enabled = false;
               _tbbPdfOptionsModify.Enabled = false;
               _tbbPdfOptionsDelete.Enabled = false;

            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void EnableAndVisibleMenu(MenuItem menu, bool value)
      {
         menu.Enabled = value;
         menu.Visible = value;
      }

      private void MainForm_Load(object sender, System.EventArgs e)
      {
         Bitmap btmp = new Bitmap(GetType(), "Resources.ToolBar.bmp");
         btmp.MakeTransparent(btmp.GetPixel(0, 0));
         _tbMain.ImageList = new ImageList();
         _tbMain.ImageList.ColorDepth = ColorDepth.Depth24Bit;
         _tbMain.ImageList.ImageSize = new Size(btmp.Height, btmp.Height);
         _tbMain.ImageList.Images.AddStrip(btmp);

         // intitialize the codecs object
         _codecs = new RasterCodecs();

         // setup our caption
         Messager.Caption = "LEADTOOLS for .NET C# Pdf Compressor Demo";

         try
         {

            if (PrinterSettings.InstalledPrinters != null && PrinterSettings.InstalledPrinters.Count > 0)
            {
               _printDocument = new PrintDocument();
               _printDocument.BeginPrint += new PrintEventHandler(_printDocument_BeginPrint);
               _printDocument.PrintPage += new PrintPageEventHandler(_printDocument_PrintPage);
               _printDocument.EndPrint += new PrintEventHandler(_printDocument_EndPrint);
            }
            else
               _printDocument = null;
         }
         catch (Exception)
         {
            _printDocument = null;
         }

         Text = Messager.Caption;
         UpdateControls();
      }



      private void _miPdfOptionsDelete_Click(object sender, System.EventArgs e)
      {
         ViewerForm activeForm = ActiveViewerForm;
         activeForm.StandardOptions.Added = false;


         DeletePage();
         UpdateControls();
         MainForm.ActiveForm.Refresh();
      }

      public void DeletePage()
      {
         ViewerForm activeForm = ActiveViewerForm;
         try
         {
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
               if (((ViewerForm)this.MdiChildren[i]).StandardOptions.PageNumber > activeForm.StandardOptions.PageNumber)
                  ((ViewerForm)this.MdiChildren[i]).StandardOptions.PageNumber--;
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


      private void ApplyPdfSave(String FileName)
      {
         int n = GetLeastNumber();
         PdfCompressorEngine pdfCompressor = new PdfCompressorEngine();
         PdfCompressorCompressionTypes compressionTypes = new PdfCompressorCompressionTypes();
         PdfCompressorOptions pdfCompressorOptions = new PdfCompressorOptions();
         for (int i = 0; i < this.MdiChildren.Length; i++)
         {
            for (int j = 0; j < this.MdiChildren.Length; j++)
            {
               if (true == ((ViewerForm)this.MdiChildren[j]).StandardOptions.Added &&
                  n == ((ViewerForm)this.MdiChildren[j]).StandardOptions.PageNumber
                  )
               {

                  //Sets compression types needed for each segment
                  compressionTypes.Comp1Bit = (PdfCompressor1BitCompression)((ViewerForm)this.MdiChildren[j]).AdvancedOptions.OneBitComboSel;
                  compressionTypes.Comp2Bit = (PdfCompressor2BitCompression)((ViewerForm)this.MdiChildren[j]).AdvancedOptions.TwoBitComboSel;
                  compressionTypes.CompPicture = (PdfCompressorPictureCompression)((ViewerForm)this.MdiChildren[j]).AdvancedOptions.PictComboSel;
                  compressionTypes.QFactor = ((ViewerForm)this.MdiChildren[j]).AdvancedOptions.QFactor;


                  //Flags for used compression types should be set
                  compressionTypes.Flags = EnabledCompressionsFlags.EnableOneBit |
                                           EnabledCompressionsFlags.EnableTwoBit |
                                           EnabledCompressionsFlags.EnablePicture;

                  pdfCompressorOptions.ImageQuality = PdfCompressorImageQuality.User;
                  pdfCompressorOptions.OutputQuality = PdfCompressorOutputQuality.User;

                  pdfCompressorOptions.BackGroundThreshold = ((ViewerForm)this.MdiChildren[j]).StandardOptions.BKThreshold;
                  pdfCompressorOptions.CleanSize = ((ViewerForm)this.MdiChildren[j]).StandardOptions.CleanSize;
                  pdfCompressorOptions.ColorThreshold = ((ViewerForm)this.MdiChildren[j]).StandardOptions.CLRThreshold;
                  pdfCompressorOptions.CombineThreshold = ((ViewerForm)this.MdiChildren[j]).StandardOptions.CombThreshold;
                  pdfCompressorOptions.SegmentQuality = ((ViewerForm)this.MdiChildren[j]).StandardOptions.SegQuality;

                  if (((ViewerForm)this.MdiChildren[j]).AdvancedOptions.CheckBackground)
                     pdfCompressorOptions.Flags = SegmentationOptionsFlags.WithBackground;
                  else
                     pdfCompressorOptions.Flags = SegmentationOptionsFlags.WithoutBackground;

                  pdfCompressorOptions.Flags = pdfCompressorOptions.Flags | ((SegmentationOptionsFlags)((ViewerForm)this.MdiChildren[j]).AdvancedOptions.SegmentationComboSel);
                  pdfCompressor.SetCompression(compressionTypes);


                  if (((ViewerForm)this.MdiChildren[j]).StandardOptions.NOMRC)
                     pdfCompressor.Insert(((ViewerForm)this.MdiChildren[j]).Image);
                  else
                     pdfCompressor.Insert(((ViewerForm)this.MdiChildren[j]).Image, pdfCompressorOptions);
                  n++;
                  break;
               }
            }

         }
         pdfCompressor.Write(FileName);
         pdfCompressor.Dispose();

      }

      private int GetLeastNumber()
      {
         bool bFirstTime = true;
         int j = 0;
         for (int i = 0; i < this.MdiChildren.Length; i++)
         {

            if (true == ((ViewerForm)this.MdiChildren[i]).StandardOptions.Added)
            {
               if (bFirstTime)
               {
                  j = ((ViewerForm)this.MdiChildren[i]).StandardOptions.PageNumber;
                  bFirstTime = false;
               }
               if (((ViewerForm)this.MdiChildren[i]).StandardOptions.PageNumber < j)
                  j = ((ViewerForm)this.MdiChildren[i]).StandardOptions.PageNumber;
            }

         }
         return j;
      }

      private void _miFileSave_Click(object sender, System.EventArgs e)
      {
         ImageFileSaver saver = new ImageFileSaver();

         try
         {
            SaveFileDialog saveDlg = new SaveFileDialog();
            SaveFileDialog sfd = new SaveFileDialog();
            bool added = false;
            for (int i = 0; i < this.MdiChildren.Length; i++)
            {
               if (((ViewerForm)this.MdiChildren[i]).StandardOptions.Added == true)
                  added = true;
            }

            if (!added)
               Messager.ShowWarning(this, "No image is added, at least one image should be added");
            else
            {
               sfd.Filter = @"Acrobat Pdf (*.pdf)|*.pdf";
               sfd.FilterIndex = 1;
               if (sfd.ShowDialog(this) == DialogResult.OK)
               {
                  ApplyPdfSave(sfd.FileName);
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowFileSaveError(this, saver.FileName, ex);
         }

      }

      private void _tbMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
      {
         if (e.Button == _tbbFileOpen)
            _miFileOpen.PerformClick();
         if (e.Button == _tbbFileSave)
            _miFileSave.PerformClick();
         if (e.Button == _tbbPdfOptionsAdd)
            _miPdfOptionsAdd.PerformClick();
         if (e.Button == _tbbPdfOptionsModify)
            _miPdfOptionsModify.PerformClick();
         if (e.Button == _tbbPdfOptionsDelete)
            _miPdfOptionsDelete.PerformClick();
         if (e.Button == _tbbHelpAbout)
            _miHelpAbout.PerformClick();
         UpdateControls();
      }

      private void _miFilePrint_Click(object sender, System.EventArgs e)
      {
         if (_printDocument != null)
         {
            try
            {
               RasterImage image = ActiveViewerForm.Viewer.Image;
               _printDocument.PrinterSettings.MinimumPage = 1;
               _printDocument.PrinterSettings.MaximumPage = image.PageCount;
               _printDocument.PrinterSettings.FromPage = 1;
               _printDocument.PrinterSettings.ToPage = image.PageCount;

               _printDocument.Print();
            }
            catch { }
         }
      }

      private void CombineFloater()
      {
         ViewerForm activeForm = ActiveViewerForm;

         if (activeForm.Viewer.Image.HasRegion)
            activeForm.Viewer.Image.MakeRegionEmpty();

         UpdateControls();
      }

      private void _printDocument_BeginPrint(object sender, PrintEventArgs e)
      {
         // This demo only loads one page at a time, so no need to re-set the print page number
      }

      private void _printDocument_PrintPage(object sender, PrintPageEventArgs e)
      {
         CombineFloater();
         RasterImage image = ActiveViewerForm.Image;

         // Get the print document object
         PrintDocument document = sender as PrintDocument;

         // Create an new LEADTOOLS image printer class
         RasterImagePrinter printer = new RasterImagePrinter();

         // Set the document object so page calculations can be performed
         printer.PrintDocument = document;

         // We want to fit and center the image into the maximum print area
         printer.SizeMode = RasterPaintSizeMode.FitAlways;
         printer.HorizontalAlignMode = RasterPaintAlignMode.Center;
         printer.VerticalAlignMode = RasterPaintAlignMode.Center;

         // Account for FAX images that may have different horizontal and vertical resolution
         printer.UseDpi = true;

         // Print the whole image
         printer.ImageRectangle = Rectangle.Empty;

         // Use maximum page dimension ignoring the margins, this will be equivalant of printing
         // using Windows Photo Gallery
         printer.PageRectangle = RectangleF.Empty;
         printer.UseMargins = false;

         // Print the current page
         printer.Print(image, 1, e);

         // Inform the printer that we have no more pages to print
         e.HasMorePages = false;
      }

      private void _printDocument_EndPrint(object sender, PrintEventArgs e)
      {
         // Nothing to do here
      }

      private void _miFilePrintPreview_Click(object sender, System.EventArgs e)
      {
         if (_printDocument != null)
         {
            try
            {
               using (PrintPreviewDialog dlg = new PrintPreviewDialog())
               {
                  RasterImage image = ActiveViewerForm.Viewer.Image;
                  _printDocument.PrinterSettings.MinimumPage = 1;
                  _printDocument.PrinterSettings.MaximumPage = image.PageCount;
                  _printDocument.PrinterSettings.FromPage = 1;
                  _printDocument.PrinterSettings.ToPage = image.PageCount;

                  dlg.Document = _printDocument;
                  dlg.WindowState = FormWindowState.Maximized;
                  dlg.ShowDialog(this);
               }
            }
            catch { }
         }

      }

      private void MainForm_MdiChildActivate(object sender, System.EventArgs e)
      {
         UpdateControls();
      }

      private void menuItem2_Click(object sender, System.EventArgs e)
      {
         Close();
      }
   }
}
