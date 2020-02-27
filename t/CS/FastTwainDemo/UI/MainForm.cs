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

using Leadtools;
using Leadtools.Twain;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.Codecs;
using Leadtools.Controls;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;

namespace CSFastTwainDemo
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileSave;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miTwain;
      private System.Windows.Forms.MenuItem _miTwainSelect;
      private System.Windows.Forms.MenuItem _miTwainAcquire;
      private System.Windows.Forms.MenuItem _miTwainSep1;
      private System.Windows.Forms.MenuItem _miTwainCapability;
      private System.Windows.Forms.MenuItem _miTwainCapabilityGet;
      private System.Windows.Forms.MenuItem _miTwainCapabilitySet;
      private System.Windows.Forms.MenuItem _miTwainSep2;
      private System.Windows.Forms.MenuItem _miTwainFastTwain;
      private System.Windows.Forms.MenuItem _miView;
      private System.Windows.Forms.MenuItem _miViewPrevious;
      private System.Windows.Forms.MenuItem _miViewNext;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.MenuItem _miTwainTemplateShow;
      private System.Windows.Forms.MenuItem _miTwainAcquireCleanup;
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
         this._miFileSave = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miTwain = new System.Windows.Forms.MenuItem();
         this._miTwainSelect = new System.Windows.Forms.MenuItem();
         this._miTwainAcquire = new System.Windows.Forms.MenuItem();
         this._miTwainSep1 = new System.Windows.Forms.MenuItem();
         this._miTwainCapability = new System.Windows.Forms.MenuItem();
         this._miTwainCapabilityGet = new System.Windows.Forms.MenuItem();
         this._miTwainCapabilitySet = new System.Windows.Forms.MenuItem();
         this._miTwainTemplateShow = new System.Windows.Forms.MenuItem();
         this._miTwainSep2 = new System.Windows.Forms.MenuItem();
         this._miTwainFastTwain = new System.Windows.Forms.MenuItem();
         this._miView = new System.Windows.Forms.MenuItem();
         this._miViewPrevious = new System.Windows.Forms.MenuItem();
         this._miViewNext = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this._miDocumentCleanup = new System.Windows.Forms.MenuItem();
         this._miDocCleanDeskew = new System.Windows.Forms.MenuItem();
         this._miDocCleanDespeckle = new System.Windows.Forms.MenuItem();
         this._miDocCleanBorderRemove = new System.Windows.Forms.MenuItem();
         this._miDocCleanHolePunchRemoval = new System.Windows.Forms.MenuItem();
         this._miTwainAcquireCleanup = new System.Windows.Forms.MenuItem();
         this._miHelpInfo = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miTwain,
            this._miDocumentCleanup,
            this._miView,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileSave,
            this._miFileSep1,
            this._miFileExit});
         this._miFile.Text = "&File";
         // 
         // _miFileSave
         // 
         this._miFileSave.Index = 0;
         this._miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this._miFileSave.Text = "Sa&ve";
         this._miFileSave.Click += new System.EventHandler(this._miFileSave_Click);
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
         // _miTwain
         // 
         this._miTwain.Index = 1;
         this._miTwain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miTwainSelect,
            this._miTwainAcquire,
            this._miTwainAcquireCleanup,
            this._miTwainSep1,
            this._miTwainCapability,
            this._miTwainTemplateShow,
            this._miTwainSep2,
            this._miTwainFastTwain});
         this._miTwain.Text = "T&wain";
         // 
         // _miTwainSelect
         // 
         this._miTwainSelect.Index = 0;
         this._miTwainSelect.Text = "&Select...";
         this._miTwainSelect.Click += new System.EventHandler(this._miTwainSelect_Click);
         // 
         // _miTwainAcquire
         // 
         this._miTwainAcquire.Index = 1;
         this._miTwainAcquire.Text = "Ac&quire...";
         this._miTwainAcquire.Click += new System.EventHandler(this._miTwainAcquire_Click);
         // 
         // _miTwainSep1
         // 
         this._miTwainSep1.Index = 3;
         this._miTwainSep1.Text = "-";
         // 
         // _miTwainCapability
         // 
         this._miTwainCapability.Index = 4;
         this._miTwainCapability.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miTwainCapabilityGet,
            this._miTwainCapabilitySet});
         this._miTwainCapability.Text = "&Capability";
         // 
         // _miTwainCapabilityGet
         // 
         this._miTwainCapabilityGet.Index = 0;
         this._miTwainCapabilityGet.Text = "&Get...";
         this._miTwainCapabilityGet.Click += new System.EventHandler(this._miTwainCapabilityGet_Click);
         // 
         // _miTwainCapabilitySet
         // 
         this._miTwainCapabilitySet.Index = 1;
         this._miTwainCapabilitySet.Text = "&Set...";
         this._miTwainCapabilitySet.Click += new System.EventHandler(this._miTwainCapabilitySet_Click);
         // 
         // _miTwainTemplateShow
         // 
         this._miTwainTemplateShow.Index = 5;
         this._miTwainTemplateShow.Text = "&Show Template...";
         this._miTwainTemplateShow.Click += new System.EventHandler(this._miTwainTemplateShow_Click);
         // 
         // _miTwainSep2
         // 
         this._miTwainSep2.Index = 6;
         this._miTwainSep2.Text = "-";
         // 
         // _miTwainFastTwain
         // 
         this._miTwainFastTwain.Index = 7;
         this._miTwainFastTwain.Text = "Fast T&wain...";
         this._miTwainFastTwain.Click += new System.EventHandler(this._miTwainFastTwain_Click);
         // 
         // _miView
         // 
         this._miView.Index = 3;
         this._miView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miViewPrevious,
            this._miViewNext});
         this._miView.Text = "&View";
         // 
         // _miViewPrevious
         // 
         this._miViewPrevious.Index = 0;
         this._miViewPrevious.Text = "&Previous";
         this._miViewPrevious.Click += new System.EventHandler(this._miViewPrevious_Click);
         // 
         // _miViewNext
         // 
         this._miViewNext.Index = 1;
         this._miViewNext.Text = "&Next";
         this._miViewNext.Click += new System.EventHandler(this._miViewNext_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 4;
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
         // _miDocumentCleanup
         // 
         this._miDocumentCleanup.Index = 2;
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
         // _miTwainAcquireCleanup
         // 
         this._miTwainAcquireCleanup.Index = 2;
         this._miTwainAcquireCleanup.Text = "Acquire With &Cleanup...";
         this._miTwainAcquireCleanup.Click += new System.EventHandler(this._miTwainAcquireCleanup_Click);
         // 
         // _miHelpInfo
         // 
         this._miHelpInfo.Index = 1;
         this._miHelpInfo.Text = "&Information";
         this._miHelpInfo.Click += new System.EventHandler(this._miHelpInfo_Click);
         // 
         // MainForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(616, 393);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Twain Capabilities and Fast Twain C# demo";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.ResumeLayout(false);

      }
      #endregion
      TwainSession _twainSession;
      ImageViewer _viewer;
      RasterCodecs _codecs;
      TwainCapabilityValue _transferMode = TwainCapabilityValue.TransferMechanismNative;
      static bool _twainAvailable = false;
      TwainDocumentCleanupMessage _infoDlg = new TwainDocumentCleanupMessage();
      bool _cleanupAfterAcquire = false;

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

      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Twain Capabilities and Fast Twain", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      public static bool TwainAvailable
      {
         get { return _twainAvailable; }
      }

      private void MainForm_Load(object sender, System.EventArgs e)
      {
         Messager.Caption = "Twain Capabilities and Fast Twain C# Demo";
         Text = Messager.Caption;

         // initialize the _viewer object
         _viewer = new ImageViewer(); 
         _viewer.Dock = DockStyle.Fill;
         _viewer.BackColor = Color.DarkGray;
         Controls.Add(_viewer);
         _viewer.BringToFront();

         // initialize the codecs object
         _codecs = new RasterCodecs();

         try
         {
            _twainAvailable = TwainSession.IsAvailable(this.Handle);
            if (_twainAvailable)
            {
               _twainSession = new TwainSession();

               //For 32-bit driver support in 64-bit applications, use the following TWAIN initialization method instead:
               //_twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.UseThunkServer);

               _twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
               _twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(_twain_AcquirePage);
            }
            else
            {
               _miTwainSelect.Enabled = false;
               _miTwainAcquire.Enabled = false;
               _miTwainAcquireCleanup.Enabled = false;
               _miTwainCapabilityGet.Enabled = false;
               _miTwainCapabilitySet.Enabled = false;
               _miTwainTemplateShow.Enabled = false;
               _miTwainFastTwain.Enabled = false;
            }

            _miFileSave.Enabled = false;
            _miViewPrevious.Enabled = false;
            _miViewNext.Enabled = false;
         }
         catch (TwainException ex)
         {
            _miTwainSelect.Enabled = false;
            _miTwainAcquire.Enabled = false;
            _miTwainAcquireCleanup.Enabled = false;
            _miTwainCapabilityGet.Enabled = false;
            _miTwainCapabilitySet.Enabled = false;
            _miTwainTemplateShow.Enabled = false;
            _miTwainFastTwain.Enabled = false;
            _miFileSave.Enabled = false;
            _miViewPrevious.Enabled = false;
            _miViewNext.Enabled = false;

            if (ex.Code == TwainExceptionCode.InvalidDll)
            {
               Messager.ShowError(this, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org");
            }
            else
            {
               Messager.ShowError(this, ex);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            _twainSession = null;
         }
      }

      private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         if(_twainSession != null)
            _twainSession.Shutdown();
      }

      private void _miTwainSelect_Click(object sender, System.EventArgs e)
      {
         _twainSession.SelectSource(string.Empty);
      }

      private void _miTwainCapabilitySet_Click(object sender, System.EventArgs e)
      {
         using(CapabilityDialog capDlg = new CapabilityDialog())
         {
            capDlg._useGetCapability = false;
            capDlg._session = _twainSession;

            capDlg.ShowDialog(this);
         }
      }

      private void _miTwainCapabilityGet_Click(object sender, System.EventArgs e)
      {
         using(CapabilityDialog capDlg = new CapabilityDialog())
         {
            capDlg._useGetCapability = true;
            capDlg._session = _twainSession;

            capDlg.ShowDialog(this);
         }
      }

      private void _twain_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         try
         {
            if(_transferMode != TwainCapabilityValue.TransferMechanismFile)
            {

               if (_cleanupAfterAcquire)
                  ApplyDocumentCleanupCommands(e.Image);

               if(e.Image != null)
               {
                  if (_viewer.Image == null)
                  {
                     _viewer.Image = e.Image;

                     _miViewPrevious.Enabled = false;
                     _miViewNext.Enabled = false;
                  }
                  else
                  {
                     _viewer.Image.AddPage(e.Image);
                     _viewer.Image.Page = _viewer.Image.PageCount;

                     _miViewPrevious.Enabled = true;
                     _miViewNext.Enabled = false;
                  }

                  _miFileSave.Enabled = true;
               }
            }
            else
               MessageBox.Show(this, "Acquired page(s) is saved to file(s)", "Acquire to File");
         }
         catch(Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }

      private void _miTwainAcquire_Click(object sender, System.EventArgs e)
      {
         Acquire(false);
      }

      private void _miViewPrevious_Click(object sender, System.EventArgs e)
      {
         int currentPage = _viewer.Image.Page;
         if(currentPage == 1)
         {
            _miViewPrevious.Enabled = false;
         }
         else
         {
            currentPage--;
            _viewer.Image.Page = currentPage;

            _miViewPrevious.Enabled = (currentPage != 1) ? true : false;
         }

         _miViewNext.Enabled = true;
      }

      private void _miViewNext_Click(object sender, System.EventArgs e)
      {
         int currentPage = _viewer.Image.Page;
         if (currentPage == _viewer.Image.PageCount)
         {
            _miViewNext.Enabled = false;
         }
         else
         {
            currentPage++;
            _viewer.Image.Page = currentPage;
            _miViewNext.Enabled = (currentPage != _viewer.Image.PageCount) ? true : false;
         }

         _miViewPrevious.Enabled = true;
      }

      private void _miFileSave_Click(object sender, System.EventArgs e)
      {
         ImageFileSaver saver = new ImageFileSaver();
         try
         {
            saver.Save(this, _codecs, _viewer.Image);
         }
         catch(Exception ex)
         {
            Messager.ShowFileSaveError(this, saver.FileName, ex);
         }
      }

      private void _miTwainFastTwain_Click(object sender, System.EventArgs e)
      {
         using(FastOptions fastOptsDlg = new FastOptions())
         {
            fastOptsDlg._session = _twainSession;
            fastOptsDlg.ShowDialog(this);
         }
      }

      private void _miTwainTemplateShow_Click(object sender, System.EventArgs e)
      {
         using(Template templateDlg = new Template())
         {
            templateDlg._twainSession = _twainSession;
            templateDlg.ShowDialog(this);
            _transferMode = templateDlg._transferMode;
         }
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

      private void _miTwainAcquireCleanup_Click(object sender, EventArgs e)
      {
         Acquire(true);
         _cleanupAfterAcquire = false;
      }

      private void Acquire(bool cleanup)
      {
         try
         {
            if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, _twainSession.SelectedSourceName()))
               return;

            _cleanupAfterAcquire = cleanup;

            if (_cleanupAfterAcquire)
               ShowCleanUpMessage();

            _twainSession.Acquire(TwainUserInterfaceFlags.Show | TwainUserInterfaceFlags.Modal);
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
         }
      }
   }
}
