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
using System.Threading;
using System.IO;

using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Drawing;

namespace PaintWhileLoadDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;
      private System.Windows.Forms.MenuItem _miMode;
      private System.Windows.Forms.MenuItem _miModePartialImage;
      private System.Windows.Forms.MenuItem _miModeBuffer;
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;

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
         this._mmMain = new System.Windows.Forms.MainMenu();
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileOpen = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miMode = new System.Windows.Forms.MenuItem();
         this._miModePartialImage = new System.Windows.Forms.MenuItem();
         this._miModeBuffer = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this._miFile,
                                                                                this._miMode,
                                                                                this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this._miFileOpen,
                                                                                this._miFileSep1,
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
         // _miFileExit
         // 
         this._miFileExit.Index = 2;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miMode
         // 
         this._miMode.Index = 1;
         this._miMode.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this._miModePartialImage,
                                                                                this._miModeBuffer});
         this._miMode.Text = "&Mode";
         // 
         // _miModePartialImage
         // 
         this._miModePartialImage.Index = 0;
         this._miModePartialImage.Text = "&Partial Image";
         this._miModePartialImage.Click += new System.EventHandler(this._miMode_Click);
         // 
         // _miModeBuffer
         // 
         this._miModeBuffer.Index = 1;
         this._miModeBuffer.Text = "&Buffer";
         this._miModeBuffer.Click += new System.EventHandler(this._miMode_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 2;
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
         this.ClientSize = new System.Drawing.Size(624, 385);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
         this.Load += new System.EventHandler(this.MainForm_Load);

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

      private enum PaintWhileLoadOption
      {
         PartialImage,
         Buffer
      }

      // the raster image viewer
      private ImageViewer _viewer;

      // raster codecs used in load\save
      private RasterCodecs _codecs;

      private PaintWhileLoadOption _paintWhileLoadOption;
      private bool _isLoading;
      private bool _cancelLoad;
      private string _openInitialPath = string.Empty;

      /// <summary>
      /// Initialize the Application.
      /// </summary>
      private void MainForm_Load(object sender, System.EventArgs e)
      {
         Messager.Caption = "LEADTOOLS for .NET C# Paint While Load Demo";
         Text = Messager.Caption;
         KeyPreview = true;

         // initialize the _viewer object
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();

         // initialize the codecs object.
         _codecs = new RasterCodecs();
         _codecs.Options.Load.Passes = -2; // load all passes

         // initialize other variables
         _paintWhileLoadOption = PaintWhileLoadOption.Buffer;
         _isLoading = false;
         _cancelLoad = false;

         UpdateMyControls();
      }

      /// <summary>
      /// Update the UI depending on the program state
      /// </summary>
      private void UpdateMyControls()
      {
         _miModePartialImage.Checked = (_paintWhileLoadOption == PaintWhileLoadOption.PartialImage);
         _miModeBuffer.Checked = (_paintWhileLoadOption == PaintWhileLoadOption.Buffer);
         this.EnableMenu(_miFile, !_isLoading);
         this.EnableMenu(_miMode, !_isLoading);
      }

      /// <summary>
      /// Load a new image
      /// </summary>
      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         try
         {
            // load the image
            ImageFileLoader loader = new ImageFileLoader();
            loader.OpenDialogInitialPath = _openInitialPath;
            loader.LoadOnlyOnePage = true;
            _isLoading = true;
            _cancelLoad = false;
            UpdateMyControls();
            if (loader.Load(this, _codecs, false) > 0)
            {
               _viewer.Image = null;
               Text = Messager.Caption;
               _openInitialPath = Path.GetDirectoryName(loader.FileName);

               _codecs.LoadImage += new EventHandler<CodecsLoadImageEventArgs>(_codecs_LoadImage);

               try
               {
                  _viewer.Image = _codecs.Load(loader.FileName, 0, CodecsLoadByteOrder.BgrOrGray, loader.FirstPage, loader.LastPage);

                  // update the caption
                  Text = string.Format("{0} - {1}", loader.FileName, Messager.Caption);
               }
               catch (Exception ex)
               {
                  Messager.ShowError(this, ex);
               }
               finally
               {
                  _codecs.LoadImage -= new EventHandler<CodecsLoadImageEventArgs>(_codecs_LoadImage);
               }
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            _isLoading = false;
            _cancelLoad = false;
            UpdateMyControls();
         }
      }

      /// <summary>
      /// Shutdown
      /// </summary>
      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void _miMode_Click(object sender, System.EventArgs e)
      {
         if (sender == _miModePartialImage) //_miModePartialImage
            _paintWhileLoadOption = PaintWhileLoadOption.PartialImage;
         else //_miModeBuffer
            _paintWhileLoadOption = PaintWhileLoadOption.Buffer;
         UpdateMyControls();
      }

      private void EnableMenu(MenuItem menu, bool value)
      {
         menu.Enabled = value;
      }

      private void _codecs_LoadImage(object sender, CodecsLoadImageEventArgs e)
      {
         if (_paintWhileLoadOption == PaintWhileLoadOption.PartialImage)
         {
            // One method is to use the Partial Image that is provided during this event to update
            // the RasterImageViewer control
            if ((e.Flags & CodecsLoadImageFlags.FirstRow) == CodecsLoadImageFlags.FirstRow)
            {
               if (e.ImagePage == 1)
               {
                  _viewer.Image = e.Image;
                  _viewer.Image.DisableEvents();
               }
            }

            if (e.ImagePage == 1)
            {
               Application.DoEvents();
               Rectangle rc = new Rectangle(0, e.Row, _viewer.Image.Width, e.Lines);
               _viewer.Invalidate(rc);
            }

            if ((e.Flags & CodecsLoadImageFlags.LastRow) == CodecsLoadImageFlags.LastRow && e.Page == e.LastPage)
            {
               _viewer.Image.EnableEvents();
            }
         }
         // A second method, is to use PaintBuffer, and paint the data buffer that this event provides
         else
         {
            Application.DoEvents();
            Graphics g = _viewer.CreateGraphics();
            LeadRect rcDest = new LeadRect(0, 0, e.Image.Width, e.Image.Height);
            RasterPaintProperties paintProps = _viewer.PaintProperties;
            if ((e.Flags & CodecsLoadImageFlags.Compressed) == CodecsLoadImageFlags.Compressed)
               RasterImagePainter.PaintBuffer(e.Image, g, LeadRect.Empty, LeadRect.Empty, rcDest, LeadRect.Empty, e.Buffer.Data, e.Row, -e.Lines, paintProps);
            else
               RasterImagePainter.PaintBuffer(e.Image, g, LeadRect.Empty, LeadRect.Empty, rcDest, LeadRect.Empty, e.Buffer.Data, e.Row, e.Lines, paintProps);

            g.Dispose();
         }

         if (_cancelLoad)
         {
            if (_viewer.Image != null)
               _viewer.Image = null;
            e.Cancel = true;
         }

         // simulate a slow load
         Thread.Sleep(25);
      }

      private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         e.Cancel = _isLoading;
      }

      /// <summary>
      /// show the about dialog
      /// </summary>
      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Paint While Load", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }
   }
}
