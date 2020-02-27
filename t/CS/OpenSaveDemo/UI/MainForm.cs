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
using Leadtools.Controls;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;

namespace OpenSaveDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.MenuItem _miFileSave;
      private System.Windows.Forms.MenuItem _menuItemPage;
      private System.Windows.Forms.MenuItem _menuItemPageFirst;
      private System.Windows.Forms.MenuItem _menuItemPagePrevious;
      private System.Windows.Forms.MenuItem _menuItemPageNext;
      private System.Windows.Forms.MenuItem _menuItemPageLast;
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.Container components = null;

      public MainForm( )
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
         System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
         this._mmMain = new System.Windows.Forms.MainMenu();
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileOpen = new System.Windows.Forms.MenuItem();
         this._miFileSave = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this._menuItemPage = new System.Windows.Forms.MenuItem();
         this._menuItemPageFirst = new System.Windows.Forms.MenuItem();
         this._menuItemPagePrevious = new System.Windows.Forms.MenuItem();
         this._menuItemPageNext = new System.Windows.Forms.MenuItem();
         this._menuItemPageLast = new System.Windows.Forms.MenuItem();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                this._miFile,
                                                                                this._menuItemPage,
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
         this._miFile.Text = "&File";
         // 
         // _miFileOpen
         // 
         this._miFileOpen.Index = 0;
         this._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this._miFileOpen.Text = "&Open...";
         this._miFileOpen.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileSave
         // 
         this._miFileSave.Index = 1;
         this._miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this._miFileSave.Text = "&Save...";
         this._miFileSave.Click += new System.EventHandler(this._miFileSave_Click);
         // 
         // _miFileSep1
         // 
         this._miFileSep1.Index = 2;
         this._miFileSep1.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 3;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
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
         // _menuItemPage
         // 
         this._menuItemPage.Index = 1;
         this._menuItemPage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this._menuItemPageFirst,
                                                                                      this._menuItemPagePrevious,
                                                                                      this._menuItemPageNext,
                                                                                      this._menuItemPageLast});
         this._menuItemPage.Text = "&Page";
         // 
         // _menuItemPageFirst
         // 
         this._menuItemPageFirst.Index = 0;
         this._menuItemPageFirst.RadioCheck = true;
         this._menuItemPageFirst.Text = "&First";
         this._menuItemPageFirst.Click += new System.EventHandler(this._menuItemPage_Click);
         // 
         // _menuItemPagePrevious
         // 
         this._menuItemPagePrevious.Index = 1;
         this._menuItemPagePrevious.RadioCheck = true;
         this._menuItemPagePrevious.Text = "&Previous";
         this._menuItemPagePrevious.Click += new System.EventHandler(this._menuItemPage_Click);
         // 
         // _menuItemPageNext
         // 
         this._menuItemPageNext.Index = 2;
         this._menuItemPageNext.RadioCheck = true;
         this._menuItemPageNext.Text = "&Next";
         this._menuItemPageNext.Click += new System.EventHandler(this._menuItemPage_Click);
         // 
         // _menuItemPageLast
         // 
         this._menuItemPageLast.Index = 3;
         this._menuItemPageLast.RadioCheck = true;
         this._menuItemPageLast.Text = "&Last";
         this._menuItemPageLast.Click += new System.EventHandler(this._menuItemPage_Click);
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(624, 385);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Open and Save Demo";
         this.Load += new System.EventHandler(this.MainForm_Load);

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

      // raster codecs used in load\save
      private RasterCodecs _codecs;

      private string _openInitialPath = string.Empty;

      /// <summary>
      /// Initialize the Application.
      /// </summary>
      private void MainForm_Load(object sender, System.EventArgs e)
      {
         Messager.Caption = "LEADTOOLS for .NET C# Open and Save Demo";
         Text = Messager.Caption;

         // initialize the _viewer object
         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();

         // initialize the codecs object.
         _codecs = new RasterCodecs();

         UpdateMyControls();
      }

      /// <summary>
      /// Update the UI depending on the program state
      /// </summary>
      private void UpdateMyControls( )
      {
         EnableAndVisibleMenu(_menuItemPage, _viewer.Image != null);
         if(_viewer.Image != null)
         {
            EnableAndVisibleMenu(_menuItemPage, _viewer.Image.PageCount > 1);
            EnableAndVisibleMenu(_menuItemPageFirst, _viewer.Image.PageCount > 1);
            EnableAndVisibleMenu(_menuItemPagePrevious, _viewer.Image.PageCount > 1);
            EnableAndVisibleMenu(_menuItemPageNext, _viewer.Image.PageCount > 1);
            EnableAndVisibleMenu(_menuItemPageLast, _viewer.Image.PageCount > 1);

            if(_viewer.Image.PageCount > 1)
            {
               _menuItemPageFirst.Enabled = _viewer.Image.Page > 1;
               _menuItemPagePrevious.Enabled = _viewer.Image.Page > 1;
               _menuItemPageNext.Enabled = _viewer.Image.Page != _viewer.Image.PageCount;
               _menuItemPageLast.Enabled = _viewer.Image.Page != _viewer.Image.PageCount;
            }

            _miFileSave.Enabled = true;
            _miFileSave.Visible = true;
         }
         else
         {
            _miFileSave.Enabled = false;
            _miFileSave.Visible = false;
         }
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

            loader.ShowLoadPagesDialog = true;
            if (loader.Load(this, _codecs, true) > 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);

               // update the caption
               Text = string.Format("{0} - {1}", loader.FileName, Messager.Caption);

               // set the new image in the viewer.
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
      /// save the original image
      /// </summary>
      private void _miFileSave_Click(object sender, System.EventArgs e)
      {
         try
         {
            ImageFileSaver saver = new ImageFileSaver();
            if(saver.Save(this, _codecs, _viewer.Image))
            {
               // we need to load this new image
               RasterImage temp = _codecs.Load(saver.FileName);

               // update the caption
               Text = string.Format("{0} - {1}", saver.FileName, Messager.Caption);
               _viewer.Image = temp;
            }
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
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

      /// <summary>
      /// show the about dialog
      /// </summary>
      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Open and Save", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }
      private void EnableAndVisibleMenu(MenuItem menu, bool value)
      {
         menu.Enabled = value;
         menu.Visible = value;
      }

      private void _menuItemPage_Click(object sender, System.EventArgs e)
      {
         try
         {
            if(sender == _menuItemPageFirst)
               _viewer.Image.Page = 1;
            else if(sender == _menuItemPagePrevious)
               _viewer.Image.Page--;
            else if(sender == _menuItemPageNext)
               _viewer.Image.Page++;
            else if(sender == _menuItemPageLast)
               _viewer.Image.Page = _viewer.Image.PageCount;
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
         finally
         {
            UpdateMyControls();
         }
      }

   }
}
