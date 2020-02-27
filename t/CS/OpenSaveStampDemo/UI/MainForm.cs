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
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Codecs;
using Leadtools.Controls;

#if ! LEADTOOLS_V17_OR_LATER
using LeadPoint = System.Drawing.Point;
using LeadSize = System.Drawing.Size;
using LeadRect = System.Drawing.Rectangle;
#endif // #if !LEADTOOLS_V17_OR_LATER

#if LEADTOOLS_V17_OR_LATER
using Leadtools.Drawing;
#endif // #if LEADTOOLS_V17_OR_LATER

namespace OpenSaveStampDemo
{
   /// <summary>
   /// Summary description for MainForm.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miFileSaveWithStamp;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
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
            this._miFileSaveWithStamp = new System.Windows.Forms.MenuItem();
            this._miFileSep1 = new System.Windows.Forms.MenuItem();
            this._miFileExit = new System.Windows.Forms.MenuItem();
            this._miHelp = new System.Windows.Forms.MenuItem();
            this._miHelpAbout = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // _mmMain
            // 
            this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miHelp});
            // 
            // _miFile
            // 
            this._miFile.Index = 0;
            this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileOpen,
            this._miFileSaveWithStamp,
            this._miFileSep1,
            this._miFileExit});
            this._miFile.Text = "&File";
            // 
            // _miFileOpen
            // 
            this._miFileOpen.Index = 0;
            this._miFileOpen.Text = "&Open...";
            this._miFileOpen.Click += new System.EventHandler(this._miFileOpen_Click);
            // 
            // _miFileSaveWithStamp
            // 
            this._miFileSaveWithStamp.Index = 1;
            this._miFileSaveWithStamp.Text = "&Save with Stamp...";
            this._miFileSaveWithStamp.Click += new System.EventHandler(this._miFileSaveWithStamp_Click);
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
            this._miHelp.Index = 1;
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
            this.ClientSize = new System.Drawing.Size(800, 600);
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
      static void Main( )
      {
         if (!Support.SetLicense())
            return;

         Application.Run(new MainForm());
      }

      // the raster codecs used in load\save
      private RasterCodecs _codecs;

      // Image/Stamp viewer, label, and stamp objects.

      private ImageViewer _viewerStamp;
      private Panel _pnlStamp;
      private Label _lblStamp;
      private ImageViewer _viewerImage;
      private Panel _pnlImage;
      private Label _lblImage;
      private string _openInitialPath = string.Empty;

      /// <summary>
      /// initialize the application
      /// </summary>
      private void MainForm_Load(object sender, System.EventArgs e)
      {
         // Initialize image/stamp viewer, label, and stamp objects.

         _viewerStamp = new ImageViewer();
         _pnlStamp = new Panel();
         _lblStamp = new Label();
         _viewerImage = new ImageViewer();
         _pnlImage = new Panel();
         _lblImage = new Label();

         // Image viewer object.
         _viewerImage.Dock = DockStyle.Fill;
         _viewerImage.ViewHorizontalAlignment = ControlAlignment.Center;
         _viewerImage.ViewVerticalAlignment = ControlAlignment.Near;

         // Image Panel object.
         _pnlImage.BorderStyle = BorderStyle.Fixed3D;
         _pnlImage.Controls.Add(_lblImage);
         _pnlImage.Dock = System.Windows.Forms.DockStyle.Top;
         _pnlImage.Size = new Size(800, 24);

         // Image Label object.
         _lblImage.BorderStyle = BorderStyle.Fixed3D;
         _lblImage.Dock = DockStyle.Fill;
         _lblImage.FlatStyle = FlatStyle.System;
         _lblImage.TextAlign = ContentAlignment.MiddleCenter;

         // Stamp viewer object.
         _viewerStamp.Dock = DockStyle.Bottom;
         _viewerStamp.ViewHorizontalAlignment = ControlAlignment.Center;    
         _viewerStamp.ViewVerticalAlignment = ControlAlignment.Center;

         // Stamp Panel object.
         _pnlStamp.BorderStyle = BorderStyle.Fixed3D;
         _pnlStamp.Controls.Add(_lblStamp);
         _pnlStamp.Dock = DockStyle.Bottom;
         _pnlStamp.Size = new Size(800, 24);

         // Stamp Label object.
         _lblStamp.BorderStyle = BorderStyle.Fixed3D;
         _lblStamp.Dock = DockStyle.Fill;
         _lblStamp.FlatStyle = FlatStyle.System;
         _lblStamp.TextAlign = ContentAlignment.MiddleCenter;

         Controls.Add(_viewerImage);
         Controls.Add(_pnlImage);
         Controls.Add(_pnlStamp);
         Controls.Add(_viewerStamp);

         // setup our caption
         Messager.Caption = "LEADTOOLS for .NET C# Open and Save Stamp Demo";
         Text = Messager.Caption;

         // initialize the codecs object
         _codecs = new RasterCodecs();

         UpdateMyControls();
      }

      /// <summary>
      /// updates the UI depending on the program state
      /// </summary>
      private void UpdateMyControls( )
      {
         if(_viewerImage.Image != null)
         {
            _miFileSaveWithStamp.Enabled = true;
            _miFileSaveWithStamp.Visible = true;
         }
         else
         {
            _miFileSaveWithStamp.Enabled = false;
            _miFileSaveWithStamp.Visible = false;
         }
      }

      /// <summary>
      /// load a new image with its stamp, if it has one
      /// </summary>
      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         try
         {
            // load an image with its stamp, if it has stamp
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All Files|*.*";
            ofd.InitialDirectory = _openInitialPath;
            if(ofd.ShowDialog(this) == DialogResult.OK)
            {
               // clear the previous image and stamp (if applicable)
               _viewerImage.Image = null;
               _viewerStamp.Image = null;

               // load the image
               _viewerImage.Image = _codecs.Load(ofd.FileName, 0, CodecsLoadByteOrder.BgrOrGray, 1, 1);
               _openInitialPath = Path.GetDirectoryName(ofd.FileName);
               // update the labels
               _lblImage.Text = ofd.FileName;

               // load the stamp
               _viewerStamp.Image = _codecs.ReadStamp(ofd.FileName, 1);

               // update the labels
               _lblStamp.Text = string.Format("Stamp - {0}", ofd.FileName);
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
      /// Save the current image with stamp
      /// </summary>
      private void _miFileSaveWithStamp_Click(object sender, System.EventArgs e)
      {
         try
         {
            // take the destination JPEG file name
            SaveFileDialog sfd = new SaveFileDialog();
            // the destination image format should be JPEG.
            sfd.Filter = "JPEG(*.jpg;*.jpeg)|*.jpg;*.jpeg";
            if(sfd.ShowDialog(this) == DialogResult.OK)
            {
               // Enable saving with stamp
               _codecs.Options.Jpeg.Save.SaveWithStamp = true;
               _codecs.Options.Jpeg.Save.StampBitsPerPixel = 24;

               // Calculate the stamp size (fit it in a 128 by 128 pixels)
               LeadRect rc = RasterImage.CalculatePaintModeRectangle(
                  _viewerImage.Image.ImageWidth,
                  _viewerImage.Image.ImageHeight,
                  new LeadRect(0, 0, 128, 128),
                  RasterPaintSizeMode.Fit,
                  RasterPaintAlignMode.Near,
                  RasterPaintAlignMode.Near);

               _codecs.Options.Jpeg.Save.StampWidth = rc.Width;
               _codecs.Options.Jpeg.Save.StampHeight = rc.Height;

               // save the image as JPEG with stamp with the closest bits per pixel
               _codecs.Save(_viewerImage.Image, sfd.FileName, RasterImageFormat.Jpeg, 0);
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
         using (AboutDialog aboutDialog = new AboutDialog("Open and Save Stamp", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }
   }
}
