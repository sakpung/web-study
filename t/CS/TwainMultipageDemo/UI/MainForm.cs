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
using System.IO;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Twain;
using Leadtools.Controls;
using Leadtools.WinForms.CommonDialogs.File;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;

namespace TwainMultiPageDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileSelectSource;
      private System.Windows.Forms.MenuItem _miFileAcquire;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miPage;
      private System.Windows.Forms.MenuItem _miPageFirst;
      private System.Windows.Forms.MenuItem _miPagePrevious;
      private System.Windows.Forms.MenuItem _miPageNext;
      private System.Windows.Forms.MenuItem _miPageLast;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.StatusBar _sbMain;
      private System.Windows.Forms.MenuItem _miFileAcquireCleanup;
      private System.Windows.Forms.MenuItem _miDocumentCleanup;
      private System.Windows.Forms.MenuItem _miDocCleanDeskew;
      private System.Windows.Forms.MenuItem _miDocCleanDespeckle;
      private System.Windows.Forms.MenuItem _miDocCleanBorderRemove;
      private System.Windows.Forms.MenuItem _miDocCleanHolePunchRemoval;
      private System.Windows.Forms.MenuItem _miHelpInfo;
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
            CleanUp();

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
         this._miFileSelectSource = new System.Windows.Forms.MenuItem();
         this._miFileAcquire = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miPage = new System.Windows.Forms.MenuItem();
         this._miPageFirst = new System.Windows.Forms.MenuItem();
         this._miPagePrevious = new System.Windows.Forms.MenuItem();
         this._miPageNext = new System.Windows.Forms.MenuItem();
         this._miPageLast = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this._sbMain = new System.Windows.Forms.StatusBar();
         this._miDocumentCleanup = new System.Windows.Forms.MenuItem();
         this._miDocCleanDeskew = new System.Windows.Forms.MenuItem();
         this._miDocCleanDespeckle = new System.Windows.Forms.MenuItem();
         this._miDocCleanBorderRemove = new System.Windows.Forms.MenuItem();
         this._miDocCleanHolePunchRemoval = new System.Windows.Forms.MenuItem();
         this._miHelpInfo = new System.Windows.Forms.MenuItem();
         this._miFileAcquireCleanup = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miDocumentCleanup,
            this._miPage,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileSelectSource,
            this._miFileAcquire,
            this._miFileAcquireCleanup,
            this._miFileSep1,
            this._miFileExit});
         this._miFile.Text = "&File";
         // 
         // _miFileSelectSource
         // 
         this._miFileSelectSource.Index = 0;
         this._miFileSelectSource.Text = "&Select Source...";
         this._miFileSelectSource.Click += new System.EventHandler(this._miFileSelectSource_Click);
         // 
         // _miFileAcquire
         // 
         this._miFileAcquire.Index = 1;
         this._miFileAcquire.Text = "&Acquire...";
         this._miFileAcquire.Click += new System.EventHandler(this._miFileAcquire_Click);
         // 
         // _miFileSep1
         // 
         this._miFileSep1.Index = 3;
         this._miFileSep1.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 4;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
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
            this._miHelpAbout,
            this._miHelpInfo});
         this._miHelp.Text = "&Help";
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Index = 0;
         this._miHelpAbout.Text = "&About...";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // _sbMain
         // 
         this._sbMain.Location = new System.Drawing.Point(0, 387);
         this._sbMain.Name = "_sbMain";
         this._sbMain.Size = new System.Drawing.Size(608, 22);
         this._sbMain.TabIndex = 1;
         // 
         // _miDocumentCleanup
         // 
         this._miDocumentCleanup.Index = 1;
         this._miDocumentCleanup.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miDocCleanDeskew,
            this._miDocCleanDespeckle,
            this._miDocCleanBorderRemove,
            this._miDocCleanHolePunchRemoval});
         this._miDocumentCleanup.Text = "Document &Cleanup";
         // 
         // _miDocCleanDeskew
         // 
         this._miDocCleanDeskew.Checked = true;
         this._miDocCleanDeskew.Index = 0;
         this._miDocCleanDeskew.Text = "&Deskew";
         this._miDocCleanDeskew.Click += new System.EventHandler(this._miDocCleanDeskew_Click);
         // 
         // _miDocCleanDespeckle
         // 
         this._miDocCleanDespeckle.Checked = true;
         this._miDocCleanDespeckle.Index = 1;
         this._miDocCleanDespeckle.Text = "Des&peckle";
         this._miDocCleanDespeckle.Click += new System.EventHandler(this._miDocCleanDespeckle_Click);
         // 
         // _miDocCleanBorderRemove
         // 
         this._miDocCleanBorderRemove.Checked = true;
         this._miDocCleanBorderRemove.Index = 2;
         this._miDocCleanBorderRemove.Text = "&Border Remove";
         this._miDocCleanBorderRemove.Click += new System.EventHandler(this._miDocCleanBorderRemove_Click);
         // 
         // _miDocCleanHolePunchRemoval
         // 
         this._miDocCleanHolePunchRemoval.Checked = true;
         this._miDocCleanHolePunchRemoval.Index = 3;
         this._miDocCleanHolePunchRemoval.Text = "&Hole Punch Removal";
         this._miDocCleanHolePunchRemoval.Click += new System.EventHandler(this._miDocCleanHolePunchRemoval_Click);
         // 
         // _miHelpInfo
         // 
         this._miHelpInfo.Index = 1;
         this._miHelpInfo.Text = "&Information";
         this._miHelpInfo.Click += new System.EventHandler(this._miHelpInfo_Click);
         // 
         // _miFileAcquireCleanup
         // 
         this._miFileAcquireCleanup.Index = 2;
         this._miFileAcquireCleanup.Text = "Acquire With &Cleanup...";
         this._miFileAcquireCleanup.Click += new System.EventHandler(this._miFileAcquireCleanup_Click);
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(608, 409);
         this.Controls.Add(this._sbMain);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.ResumeLayout(false);

      }
      #endregion

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

      // the raster image viewer
      private ImageViewer _viewer;

      // the twain session used in acquiring
      private TwainSession _twainSession;

      // the raster codecs used in load\save
      private RasterCodecs _codecs;

      // save the output file name
      private string _fileName;

      // save the output file format
      private RasterImageFormat _fileFormat;
      private int _bitsPerPixel;

      // save the no of pages acquired
      private int _pageNo;

      TwainDocumentCleanupMessage _infoDlg = new TwainDocumentCleanupMessage();
      bool _cleanupAfterAcquire = false;

      /// <summary>
      /// Initialize the application
      /// </summary>
      private void InitClass( )
      {
         // setup our caption
         Messager.Caption = "LEADTOOLS for .NET C# Twain Multipage Demo";
         Text = Messager.Caption;

         // initialize the _viewer object
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();

         // initialize the codecs object
         _codecs = new RasterCodecs();

         if (TwainSession.IsAvailable(this.Handle))
         {
            try
            {
               // setup the Twain session object
               _twainSession = new TwainSession();

               //For 32-bit driver support in 64-bit applications, use the following TWAIN initialization method instead:
               //_twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Twain .NET", "Version 14", "LEADTools Twain test sample", TwainStartupFlags.UseThunkServer);

               // start up the Twain session
               _twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Twain .NET", "Version 14", "LEADTools Twain test sample", TwainStartupFlags.None);
            }
            catch (TwainException ex)
            {
               if (ex.Code == TwainExceptionCode.InvalidDll)
               {
                  _miFileAcquire.Enabled = false;
                  _miFileAcquireCleanup.Enabled = false;
                  _miFileSelectSource.Enabled = false;
                  Messager.ShowError(this, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org");
               }
               else
               {
                  _miFileAcquire.Enabled = false;
                  _miFileAcquireCleanup.Enabled = false;
                  _miFileSelectSource.Enabled = false;
                  Messager.ShowError(this, ex);
               }
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
               _miFileAcquire.Enabled = false;
               _miFileAcquireCleanup.Enabled = false;
               _miFileSelectSource.Enabled = false;
            }
         }
         else
         {
            _miFileAcquire.Enabled = false;
            _miFileAcquireCleanup.Enabled = false;
            _miFileSelectSource.Enabled = false;
         }

         // setup the other variables
         _fileName = string.Empty;
         _fileFormat = RasterImageFormat.Tif;
         _pageNo = 0;

         UpdateMyControls();
         UpdateStatusBarText();
      }

      private void CleanUp( )
      {
         if(_twainSession != null)
         {
            try
            {
               _twainSession.Shutdown();
            }
            catch(Exception ex)
            {
               Messager.ShowError(this, ex);
            }
         }
      }

      /// <summary>
      /// Updates the UI depending on the program state
      /// </summary>
      private void UpdateMyControls( )
      {
         // update the menu items
         if(_viewer.Image != null)
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
         }
         else
         {
            _miPage.Enabled = false;
            _miPage.Visible = false;
            _miPageFirst.Enabled = false;
            _miPageFirst.Visible = false;
            _miPagePrevious.Enabled = false;
            _miPagePrevious.Visible = false;
            _miPageNext.Enabled = false;
            _miPageNext.Visible = false;
            _miPageLast.Enabled = false;
            _miPageLast.Visible = false;
            Text = Messager.Caption;
         }
      }

      /// <summary>
      /// Updates the status bar text depending on the current page
      /// </summary>
      private void UpdateStatusBarText( )
      {
         if(_viewer.Image != null)
            _sbMain.Text = string.Format("Page {0}:{1}", _viewer.Image.Page, _viewer.Image.PageCount);
         else
            _sbMain.Text = "Ready";
      }

      /// <summary>
      /// Select Source to scan from
      /// </summary>
      private void _miFileSelectSource_Click(object sender, System.EventArgs e)
      {
         try
         {
            _twainSession.SelectSource(String.Empty);
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      /// <summary>
      /// Scan pages
      /// </summary>
      private void _miFileAcquire_Click(object sender, System.EventArgs e)
      {
         Acquire(false);
      }

      /// <summary>
      /// Acquire page event
      /// </summary>
      private void _twain_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         try
         {
            if(e.Image != null)
            {
               if (_cleanupAfterAcquire)
                  ApplyDocumentCleanupCommands(e.Image);

               // Check if the required file format supports multi-page
               if((_fileFormat == RasterImageFormat.Tif) || (_fileFormat == RasterImageFormat.Ccitt) ||
                  (_fileFormat == RasterImageFormat.CcittGroup31Dim) || (_fileFormat == RasterImageFormat.CcittGroup32Dim) ||
                  (_fileFormat == RasterImageFormat.CcittGroup4) || (_fileFormat == RasterImageFormat.TifCmp) ||
                  (_fileFormat == RasterImageFormat.TifCmw) || (_fileFormat == RasterImageFormat.TifCmyk) ||
                  (_fileFormat == RasterImageFormat.TifCustom) ||
                  (_fileFormat == RasterImageFormat.TifJ2k) || (_fileFormat == RasterImageFormat.TifJbig) ||
                  (_fileFormat == RasterImageFormat.TifJpeg) || (_fileFormat == RasterImageFormat.TifJpeg411) ||
                  (_fileFormat == RasterImageFormat.TifJpeg422) || (_fileFormat == RasterImageFormat.TifLead1Bit) ||
                  (_fileFormat == RasterImageFormat.TifLzw) || (_fileFormat == RasterImageFormat.TifLzwCmyk) ||
                  (_fileFormat == RasterImageFormat.TifLzwYcc) || (_fileFormat == RasterImageFormat.TifPackBits) ||
                  (_fileFormat == RasterImageFormat.TifPackBitsCmyk) || (_fileFormat == RasterImageFormat.TifPackbitsYcc) ||
                  (_fileFormat == RasterImageFormat.TifUnknown) || (_fileFormat == RasterImageFormat.TifYcc) ||
                  (_fileFormat == RasterImageFormat.Gif))
               {
                  // save the acquired page in multi-page file.
                  _codecs.Save(e.Image, _fileName, _fileFormat, _bitsPerPixel, 1, 1, 1, CodecsSavePageMode.Append);
               }
               else
               { // we are trying to save each page in a separate file

                  // the extension of the file name
                  string ext = string.Empty;

                  // save the extension of the file name if it has one
                  if(Path.HasExtension(_fileName))
                  {
                     ext = Path.GetExtension(_fileName);
                  }
                  // save the file name with no indicates the page no.
                  string tmpFileName = Path.GetFileNameWithoutExtension(_fileName);
                  string tmpDirName = Path.GetDirectoryName(_fileName);
                  string newFileName = string.Format("{0}\\{1}{2}{3}", tmpDirName, tmpFileName, _pageNo.ToString(), ext);

                  _codecs.Save(e.Image, newFileName, _fileFormat, _bitsPerPixel);
                  // increment the page count
                  _pageNo++;
               }

               // Add the acquired page to the viewer
               if(_viewer.Image == null)
               {
                  _viewer.Image = e.Image;
               }
               else
               {
                  _viewer.Image.AddPage(e.Image);
                  _viewer.Image.Page = _viewer.Image.PageCount;
               }
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      /// <summary>
      /// Shutdown.
      /// </summary>
      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      /// <summary>
      /// Handles Page menu
      /// </summary>
      private void _miPage_Click(object sender, System.EventArgs e)
      {
         int page = _viewer.Image.Page;
         if(sender == _miPageFirst)
            page = 1;
         else if(sender == _miPagePrevious)
            page--;
         else if(sender == _miPageNext)
            page++;
         else if(sender == _miPageLast)
            page = _viewer.Image.PageCount;

         page = Math.Max(1, Math.Min(_viewer.Image.PageCount, page));

         if(page != _viewer.Image.Page)
         {
            _viewer.Image.Page = page;
            UpdateMyControls();
            UpdateStatusBarText();
         }
      }

      /// <summary>
      /// Show the about dialog
      /// </summary>
      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Twain Multipage", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _miDocCleanDeskew_Click(object sender, EventArgs e)
      {
         _miDocCleanDeskew.Checked = !_miDocCleanDeskew.Checked;
      }

      private void _miDocCleanDespeckle_Click(object sender, EventArgs e)
      {
         _miDocCleanDespeckle.Checked = !_miDocCleanDespeckle.Checked;
      }

      private void _miDocCleanBorderRemove_Click(object sender, EventArgs e)
      {
         _miDocCleanBorderRemove.Checked = !_miDocCleanBorderRemove.Checked;
      }

      private void _miDocCleanHolePunchRemoval_Click(object sender, EventArgs e)
      {
         _miDocCleanHolePunchRemoval.Checked = !_miDocCleanHolePunchRemoval.Checked;
      }

      private void ShowCleanUpMessage()
      {
         if (_miDocCleanDeskew.Checked || _miDocCleanDespeckle.Checked || _miDocCleanBorderRemove.Checked || _miDocCleanHolePunchRemoval.Checked)
         {
            if (_infoDlg.ShouldShow())
               _infoDlg.ShowDialog();
         }
      }

      private void ApplyDocumentCleanupCommands(RasterImage image)
      {
         try
         {
            if (image.BitsPerPixel != 1)
            {
               ColorResolutionCommand colorRes = new ColorResolutionCommand();
               colorRes.BitsPerPixel = 1;

               colorRes.Order = image.Order;
               colorRes.Mode = ColorResolutionCommandMode.InPlace;
               colorRes.Run(image);
            }

            if (_miDocCleanDeskew.Checked)
            {
               DeskewCommand cmd = new DeskewCommand();
               cmd.FillColor = RasterColor.White;
               cmd.Flags = DeskewCommandFlags.FillExposedArea;

               cmd.Run(image);
            }

            if (_miDocCleanDespeckle.Checked)
            {
               DespeckleCommand cmd = new DespeckleCommand();
               cmd.Run(image);
            }

            if (_miDocCleanBorderRemove.Checked)
            {
               BorderRemoveCommand cmd = new BorderRemoveCommand();
               cmd.Flags = BorderRemoveCommandFlags.AutoRemove;
               cmd.Run(image);
            }

            if (_miDocCleanHolePunchRemoval.Checked)
            {
               HolePunchRemoveCommand cmd = new HolePunchRemoveCommand();

               // try to remove left hole punches
               cmd.Flags = HolePunchRemoveCommandFlags.UseNormalDetection;
               cmd.Run(image);

               // try to remove right hole punches
               cmd.Flags = HolePunchRemoveCommandFlags.UseNormalDetection | HolePunchRemoveCommandFlags.UseLocation;
               cmd.Location = HolePunchRemoveCommandLocation.Right;
               cmd.Run(image);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _miHelpInfo_Click(object sender, EventArgs e)
      {
         _infoDlg.ShowDialog();
      }

      private void _miFileAcquireCleanup_Click(object sender, EventArgs e)
      {
         Acquire(true);
      }

      private void Acquire(bool cleanup)
      {
         try
         {
            if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, _twainSession.SelectedSourceName()))
               return;

            // get the output file name and file format
            RasterSaveDialog dlg = new RasterSaveDialog(_codecs);

            dlg.Title = "File Acquire Path";
            dlg.AutoProcess = false;
            dlg.EnableSizing = true;
            dlg.FileFormatsList = new RasterSaveDialogFileFormatsList(RasterDialogFileFormatDataContent.Default);
            dlg.ShowFileOptionsBasicJ2kOptions = false;
            dlg.ShowFileOptionsJ2kOptions = false;
            dlg.ShowFileOptionsMultipage = false;
            dlg.ShowFileOptionsProgressive = false;
            dlg.ShowFileOptionsQualityFactor = false;
            dlg.ShowFileOptionsStamp = false;
            dlg.ShowHelp = false;
            dlg.ShowOptions = false;
            dlg.ShowQualityFactor = false;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               // save the output file name
               _fileName = dlg.FileName;

               // save the output file format
               _fileFormat = dlg.Format;
               _bitsPerPixel = dlg.BitsPerPixel;

               string pathName = Path.GetDirectoryName(_fileName);
               if (Directory.Exists(pathName))
               {
                  // initialize the page counter
                  _pageNo = 0;

                  // Add the Acquire page event.
                  _twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(_twain_AcquirePage);
                  // Acquire pages

                  _cleanupAfterAcquire = cleanup;

                  if (_cleanupAfterAcquire)
                     ShowCleanUpMessage();

                  _twainSession.Acquire(TwainUserInterfaceFlags.Show);
                  // Remove the Acquire page event.
                  _twainSession.AcquirePage -= new EventHandler<TwainAcquirePageEventArgs>(_twain_AcquirePage);
               }
               else
                  Messager.ShowError(this, "Invalid File Name");
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateMyControls();
            UpdateStatusBarText();
         }
      }
   }
}
