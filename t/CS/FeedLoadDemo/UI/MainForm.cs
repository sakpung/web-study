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

using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools;
using Leadtools.Codecs;
using Leadtools.Controls;

namespace FeedLoadDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mainMenu;
      private System.Windows.Forms.MenuItem _menuItemFile;
      private System.Windows.Forms.MenuItem _menuItemFileExit;
      private System.Windows.Forms.MenuItem _menuItemHelp;
      private System.Windows.Forms.MenuItem _menuItemHelpAbout;
      private System.Windows.Forms.Panel _pnlControls;
      private System.Windows.Forms.Label _lblUrl;
      private System.Windows.Forms.TextBox _tbUrl;
      private System.Windows.Forms.ComboBox _cbSizeMode;
      private System.Windows.Forms.Button _btnZoomIn;
      private System.Windows.Forms.Button _btnZoomOut;
      private System.Windows.Forms.Button _btnZoomNone;
      private System.Windows.Forms.Button _btnUrl;
      private System.Windows.Forms.Label _lblFileName;
      private System.Windows.Forms.TextBox _tbFileName;
      private System.Windows.Forms.Button _btnFileName;
      private System.Windows.Forms.Button _btnBrowse;
      private System.Windows.Forms.Label _lblMessage;
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
         this._mainMenu = new System.Windows.Forms.MainMenu(this.components);
         this._menuItemFile = new System.Windows.Forms.MenuItem();
         this._menuItemFileExit = new System.Windows.Forms.MenuItem();
         this._menuItemHelp = new System.Windows.Forms.MenuItem();
         this._menuItemHelpAbout = new System.Windows.Forms.MenuItem();
         this._pnlControls = new System.Windows.Forms.Panel();
         this._lblMessage = new System.Windows.Forms.Label();
         this._btnBrowse = new System.Windows.Forms.Button();
         this._btnFileName = new System.Windows.Forms.Button();
         this._tbFileName = new System.Windows.Forms.TextBox();
         this._lblFileName = new System.Windows.Forms.Label();
         this._btnZoomNone = new System.Windows.Forms.Button();
         this._btnZoomOut = new System.Windows.Forms.Button();
         this._btnZoomIn = new System.Windows.Forms.Button();
         this._cbSizeMode = new System.Windows.Forms.ComboBox();
         this._btnUrl = new System.Windows.Forms.Button();
         this._tbUrl = new System.Windows.Forms.TextBox();
         this._lblUrl = new System.Windows.Forms.Label();
         this._pnlControls.SuspendLayout();
         this.SuspendLayout();
         // 
         // _mainMenu
         // 
         this._mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFile,
            this._menuItemHelp});
         // 
         // _menuItemFile
         // 
         this._menuItemFile.Index = 0;
         this._menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemFileExit});
         this._menuItemFile.Text = "&File";
         // 
         // _menuItemFileExit
         // 
         this._menuItemFileExit.Index = 0;
         this._menuItemFileExit.Text = "E&xit";
         this._menuItemFileExit.Click += new System.EventHandler(this._menuItemFileExit_Click);
         // 
         // _menuItemHelp
         // 
         this._menuItemHelp.Index = 1;
         this._menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._menuItemHelpAbout});
         this._menuItemHelp.Text = "&Help";
         // 
         // _menuItemHelpAbout
         // 
         this._menuItemHelpAbout.Index = 0;
         this._menuItemHelpAbout.Text = "&About...";
         this._menuItemHelpAbout.Click += new System.EventHandler(this._menuItemHelpAbout_Click);
         // 
         // _pnlControls
         // 
         this._pnlControls.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._pnlControls.Controls.Add(this._lblMessage);
         this._pnlControls.Controls.Add(this._btnBrowse);
         this._pnlControls.Controls.Add(this._btnFileName);
         this._pnlControls.Controls.Add(this._tbFileName);
         this._pnlControls.Controls.Add(this._lblFileName);
         this._pnlControls.Controls.Add(this._btnZoomNone);
         this._pnlControls.Controls.Add(this._btnZoomOut);
         this._pnlControls.Controls.Add(this._btnZoomIn);
         this._pnlControls.Controls.Add(this._cbSizeMode);
         this._pnlControls.Controls.Add(this._btnUrl);
         this._pnlControls.Controls.Add(this._tbUrl);
         this._pnlControls.Controls.Add(this._lblUrl);
         this._pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
         this._pnlControls.Location = new System.Drawing.Point(0, 0);
         this._pnlControls.Name = "_pnlControls";
         this._pnlControls.Size = new System.Drawing.Size(616, 144);
         this._pnlControls.TabIndex = 0;
         // 
         // _lblMessage
         // 
         this._lblMessage.Location = new System.Drawing.Point(8, 8);
         this._lblMessage.Name = "_lblMessage";
         this._lblMessage.Size = new System.Drawing.Size(584, 32);
         this._lblMessage.TabIndex = 11;
         this._lblMessage.Text = "Enter a URL to an image file (for example http://www.website.com/image.jpg) or th" +
             "e name of a valid file in your machine then click Go to load the file using Feed" +
             " Load mechanism.";
         this._lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _btnBrowse
         // 
         this._btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnBrowse.Location = new System.Drawing.Point(368, 80);
         this._btnBrowse.Name = "_btnBrowse";
         this._btnBrowse.Size = new System.Drawing.Size(35, 23);
         this._btnBrowse.TabIndex = 5;
         this._btnBrowse.Text = "...";
         this._btnBrowse.Click += new System.EventHandler(this._btnBrowse_Click);
         // 
         // _btnFileName
         // 
         this._btnFileName.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnFileName.Location = new System.Drawing.Point(408, 80);
         this._btnFileName.Name = "_btnFileName";
         this._btnFileName.Size = new System.Drawing.Size(75, 23);
         this._btnFileName.TabIndex = 6;
         this._btnFileName.Text = "Go";
         this._btnFileName.Click += new System.EventHandler(this._btnFileName_Click);
         // 
         // _tbFileName
         // 
         this._tbFileName.Location = new System.Drawing.Point(80, 80);
         this._tbFileName.Name = "_tbFileName";
         this._tbFileName.Size = new System.Drawing.Size(288, 20);
         this._tbFileName.TabIndex = 4;
         this._tbFileName.TextChanged += new System.EventHandler(this._tbFileName_TextChanged);
         // 
         // _lblFileName
         // 
         this._lblFileName.Location = new System.Drawing.Point(8, 80);
         this._lblFileName.Name = "_lblFileName";
         this._lblFileName.Size = new System.Drawing.Size(64, 23);
         this._lblFileName.TabIndex = 3;
         this._lblFileName.Text = "File Name:";
         this._lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _btnZoomNone
         // 
         this._btnZoomNone.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnZoomNone.Location = new System.Drawing.Point(232, 112);
         this._btnZoomNone.Name = "_btnZoomNone";
         this._btnZoomNone.Size = new System.Drawing.Size(32, 23);
         this._btnZoomNone.TabIndex = 10;
         this._btnZoomNone.Text = "1:1";
         this._btnZoomNone.Click += new System.EventHandler(this._btnZoom_Click);
         // 
         // _btnZoomOut
         // 
         this._btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnZoomOut.Location = new System.Drawing.Point(200, 112);
         this._btnZoomOut.Name = "_btnZoomOut";
         this._btnZoomOut.Size = new System.Drawing.Size(32, 23);
         this._btnZoomOut.TabIndex = 9;
         this._btnZoomOut.Text = "-";
         this._btnZoomOut.Click += new System.EventHandler(this._btnZoom_Click);
         // 
         // _btnZoomIn
         // 
         this._btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnZoomIn.Location = new System.Drawing.Point(168, 112);
         this._btnZoomIn.Name = "_btnZoomIn";
         this._btnZoomIn.Size = new System.Drawing.Size(32, 23);
         this._btnZoomIn.TabIndex = 8;
         this._btnZoomIn.Text = "+";
         this._btnZoomIn.Click += new System.EventHandler(this._btnZoom_Click);
         // 
         // _cbSizeMode
         // 
         this._cbSizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbSizeMode.Location = new System.Drawing.Point(8, 112);
         this._cbSizeMode.Name = "_cbSizeMode";
         this._cbSizeMode.Size = new System.Drawing.Size(152, 21);
         this._cbSizeMode.TabIndex = 7;
         this._cbSizeMode.SelectedIndexChanged += new System.EventHandler(this._cbSizeMode_SelectedIndexChanged);
         // 
         // _btnUrl
         // 
         this._btnUrl.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnUrl.Location = new System.Drawing.Point(408, 48);
         this._btnUrl.Name = "_btnUrl";
         this._btnUrl.Size = new System.Drawing.Size(75, 23);
         this._btnUrl.TabIndex = 2;
         this._btnUrl.Text = "Go";
         this._btnUrl.Click += new System.EventHandler(this._btnUrl_Click);
         // 
         // _tbUrl
         // 
         this._tbUrl.Location = new System.Drawing.Point(80, 48);
         this._tbUrl.Name = "_tbUrl";
         this._tbUrl.Size = new System.Drawing.Size(328, 20);
         this._tbUrl.TabIndex = 1;
         this._tbUrl.TextChanged += new System.EventHandler(this._tbUrl_TextChanged);
         // 
         // _lblUrl
         // 
         this._lblUrl.Location = new System.Drawing.Point(8, 48);
         this._lblUrl.Name = "_lblUrl";
         this._lblUrl.Size = new System.Drawing.Size(32, 23);
         this._lblUrl.TabIndex = 0;
         this._lblUrl.Text = "Url:";
         this._lblUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(616, 459);
         this.Controls.Add(this._pnlControls);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.KeyPreview = true;
         this.Menu = this._mainMenu;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
         this._pnlControls.ResumeLayout(false);
         this._pnlControls.PerformLayout();
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

         Application.EnableVisualStyles();
         Application.DoEvents();

         Application.Run(new MainForm());
      }

      private ImageViewer _viewer;
      private RasterPictureBox _pictureBox;
      private bool _isGif;
      private RasterCodecs _codecs;

      private void InitClass( )
      {
         Messager.Caption = "LEADTOOLS C# Feed Load Demo";
         Text = Messager.Caption;

         _viewer = new ImageViewer();
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkCyan;
         _viewer.InteractiveModes.Add(new ImageViewerAutoPanInteractiveMode());
         Controls.Add(_viewer);
         _viewer.BringToFront();
         _pictureBox = new RasterPictureBox();
         _pictureBox.AnimationMode = RasterPictureBoxAnimationMode.Infinite;
         _pictureBox.SizeMode = RasterPictureBoxSizeMode.Fit;
         _pictureBox.Dock = DockStyle.Fill;
         _pictureBox.BackColor = Color.DarkCyan;
         Controls.Add(_pictureBox);
         _pictureBox.Visible = false;
         _isGif = false;
         _viewer.Zoom(ControlSizeMode.ActualSize, 1, _viewer.DefaultZoomOrigin);

         Array a = Enum.GetValues(typeof(ControlSizeMode));
         foreach (ControlSizeMode i in a)
         {
            if (i != ControlSizeMode.None)
               _cbSizeMode.Items.Add(i);
            if (i == _viewer.SizeMode)
               _cbSizeMode.SelectedItem = i;
         }

         //temp image so the nag window will be displayed in this main thread
         RasterImage temp = new RasterImage(RasterMemoryFlags.Conventional, 1, 1, 1, RasterByteOrder.Bgr, RasterViewPerspective.TopLeft, null, IntPtr.Zero, 0);
         temp.Dispose();

         _codecs = new RasterCodecs();

         _tbFileName.Text = DemosGlobal.ImagesFolder + @"\image1.cmp";
         _tbUrl.Text = "https://www.leadtools.com/images/page_graphics/leadlogo.png";
         SetTheImage(_tbFileName.Text, false);
         UpdateButtons();
      }

      private void CleanUp( )
      {
      }

      private void _cbSizeMode_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         _viewer.Zoom((ControlSizeMode)_cbSizeMode.SelectedItem, 1.0, new LeadPoint(0, 0));
      }

      private void _btnZoom_Click(object sender, System.EventArgs e)
      {
         const double minimumScaleFactor = 0.05f;
         const double maximumScaleFactor = 11f;
         const double factor = 1.2f;

         double scaleFactor = _viewer.ScaleFactor;

         if(sender == _btnZoomIn)
            scaleFactor *= factor;
         else if(sender == _btnZoomOut)
            scaleFactor /= factor;
         else
            scaleFactor = 1;

         scaleFactor = Math.Max(minimumScaleFactor, Math.Min(maximumScaleFactor, scaleFactor));
         if ((sender == _btnZoomIn) || (sender == _btnZoomOut))
            _viewer.Zoom(ControlSizeMode.None, scaleFactor, new LeadPoint(0, 0));
         else
            _viewer.Zoom((ControlSizeMode)_cbSizeMode.SelectedItem, scaleFactor, new LeadPoint(0, 0));
      }

      private void _menuItemFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void _menuItemHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Feed Load", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }


      private void _tbUrl_TextChanged(object sender, System.EventArgs e)
      {
         UpdateButtons();
      }

      private void _tbFileName_TextChanged(object sender, System.EventArgs e)
      {
         UpdateButtons();
      }

      private void UpdateButtons( )
      {
         _btnUrl.Enabled = _tbUrl.Text.Trim() != string.Empty;
         _btnFileName.Enabled = _tbFileName.Text.Trim() != string.Empty;
         _cbSizeMode.Enabled = !_isGif;
         _btnZoomIn.Enabled = !_isGif;
         _btnZoomOut.Enabled = !_isGif;
         _btnZoomNone.Enabled = !_isGif;
      }

      private void _btnBrowse_Click(object sender, System.EventArgs e)
      {
         OpenFileDialog dlg = new OpenFileDialog();
         dlg.Filter = "All Files|*.*";
         if(dlg.ShowDialog(this) == DialogResult.OK)
            _tbFileName.Text = dlg.FileName;
      }

      private void SetTheImage(string str, bool isUrl)
      {
         _isGif = str.ToLower().EndsWith("gif");

         FeedLoadDialog dlg;
         if(isUrl)
            dlg = new FeedLoadDialog(_codecs, str, null);
         else
            dlg = new FeedLoadDialog(_codecs, null, str);
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            if (_isGif == true)
            {
               _pictureBox.Image = dlg.Image;
               for (int x = 1; x <= _pictureBox.Image.PageCount; x++)
               {
                  _pictureBox.Image.Page = x;
                  if (_pictureBox.Image.AnimationDelay == 0)
                     _pictureBox.Image.AnimationDelay = 100;
               }
               dlg.Image.Page = 1;
               _pictureBox.BringToFront();
               _pictureBox.Visible = true;
               _pictureBox.PlayAnimation();
            }
            else
            {
               _viewer.Image = dlg.Image;
               _viewer.BringToFront();
            }
            UpdateButtons();
         }
      }

      private void _btnUrl_Click(object sender, System.EventArgs e)
      {
         SetTheImage(_tbUrl.Text, true);
      }

      private void _btnFileName_Click(object sender, System.EventArgs e)
      {
         SetTheImage(_tbFileName.Text, false);
      }

      private void MainForm_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.Escape)
            _pictureBox.PauseAnimation();
      }

   }
}
