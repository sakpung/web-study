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
using Leadtools.Twain;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.WinForms;
using Leadtools.ImageProcessing;
using Leadtools.ImageProcessing.Core;

namespace TwainHighDemo
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miTemplateSep1;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miTwain;
      private System.Windows.Forms.MenuItem _miTwainSelectSource;
      private System.Windows.Forms.MenuItem _miTwainAcquire;
      private System.Windows.Forms.MenuItem _miTemplate;
      private System.Windows.Forms.MenuItem _miTemplateLEAD;
      private System.Windows.Forms.MenuItem _miTemplateShowCaps;
      private System.Windows.Forms.MenuItem _miTemplateShowErrors;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.MenuItem _miFileSave;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miFileClose;
      private System.Windows.Forms.MenuItem _mmFileSep2;
      private System.Windows.Forms.MenuItem _miDocumentCleanup;
      private System.Windows.Forms.MenuItem _miDocCleanDeskew;
      private System.Windows.Forms.MenuItem _miDocCleanDespeckle;
      private System.Windows.Forms.MenuItem _miDocCleanBorderRemove;
      private System.Windows.Forms.MenuItem _miDocCleanHolePunchRemoval;
      private System.Windows.Forms.MenuItem _miTwainAcquireCleanup;
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
         this._miFileOpen = new System.Windows.Forms.MenuItem();
         this._miFileSave = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFileClose = new System.Windows.Forms.MenuItem();
         this._mmFileSep2 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this._miTwain = new System.Windows.Forms.MenuItem();
         this._miTwainSelectSource = new System.Windows.Forms.MenuItem();
         this._miTwainAcquire = new System.Windows.Forms.MenuItem();
         this._miDocumentCleanup = new System.Windows.Forms.MenuItem();
         this._miDocCleanDeskew = new System.Windows.Forms.MenuItem();
         this._miDocCleanDespeckle = new System.Windows.Forms.MenuItem();
         this._miDocCleanBorderRemove = new System.Windows.Forms.MenuItem();
         this._miDocCleanHolePunchRemoval = new System.Windows.Forms.MenuItem();
         this._miTemplate = new System.Windows.Forms.MenuItem();
         this._miTemplateLEAD = new System.Windows.Forms.MenuItem();
         this._miTemplateShowCaps = new System.Windows.Forms.MenuItem();
         this._miTemplateSep1 = new System.Windows.Forms.MenuItem();
         this._miTemplateShowErrors = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
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
            this._miTemplate,
            this._miHelp});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileOpen,
            this._miFileSave,
            this._miFileSep1,
            this._miFileClose,
            this._mmFileSep2,
            this._miFileExit});
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
         this._miFileSave.Text = "&Save";
         this._miFileSave.Click += new System.EventHandler(this._miFileSave_Click);
         // 
         // _miFileSep1
         // 
         this._miFileSep1.Index = 2;
         this._miFileSep1.Text = "-";
         // 
         // _miFileClose
         // 
         this._miFileClose.Index = 3;
         this._miFileClose.Text = "&Close";
         this._miFileClose.Click += new System.EventHandler(this._miFileClose_Click);
         // 
         // _mmFileSep2
         // 
         this._mmFileSep2.Index = 4;
         this._mmFileSep2.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 5;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miTwain
         // 
         this._miTwain.Index = 1;
         this._miTwain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miTwainSelectSource,
            this._miTwainAcquire,
            this._miTwainAcquireCleanup});
         this._miTwain.Text = "T&wain";
         // 
         // _miTwainSelectSource
         // 
         this._miTwainSelectSource.Index = 0;
         this._miTwainSelectSource.Text = "&Select Source";
         this._miTwainSelectSource.Click += new System.EventHandler(this._miTwainSelectSource_Click);
         // 
         // _miTwainAcquire
         // 
         this._miTwainAcquire.Index = 1;
         this._miTwainAcquire.Text = "Ac&quire";
         this._miTwainAcquire.Click += new System.EventHandler(this._miTwainAcquire_Click);
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
         // _miTemplate
         // 
         this._miTemplate.Index = 3;
         this._miTemplate.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miTemplateLEAD,
            this._miTemplateShowCaps,
            this._miTemplateSep1,
            this._miTemplateShowErrors});
         this._miTemplate.Text = "Te&mplate";
         // 
         // _miTemplateLEAD
         // 
         this._miTemplateLEAD.Index = 0;
         this._miTemplateLEAD.Text = "&LEAD Template";
         this._miTemplateLEAD.Click += new System.EventHandler(this._miTemplateLEAD_Click);
         // 
         // _miTemplateShowCaps
         // 
         this._miTemplateShowCaps.Index = 1;
         this._miTemplateShowCaps.Text = "Show Supported &Capabilities";
         this._miTemplateShowCaps.Click += new System.EventHandler(this._miTemplateShowCaps_Click);
         // 
         // _miTemplateSep1
         // 
         this._miTemplateSep1.Index = 2;
         this._miTemplateSep1.Text = "-";
         // 
         // _miTemplateShowErrors
         // 
         this._miTemplateShowErrors.Index = 3;
         this._miTemplateShowErrors.Text = "Show &Error Codes...";
         this._miTemplateShowErrors.Click += new System.EventHandler(this._miTemplateShowErrors_Click);
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
         this._miHelpAbout.Text = "&About";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // _miTwainAcquireCleanup
         // 
         this._miTwainAcquireCleanup.Index = 2;
         this._miTwainAcquireCleanup.Text = "Acquire With &Cleanup";
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
         this.ClientSize = new System.Drawing.Size(480, 302);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.IsMdiContainer = true;
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "TWAIN C# Demo";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.ResumeLayout(false);

      }
      #endregion
      TwainSession _twainSession;
      RasterCodecs _codecs;
      int _scanCount;
      static ArrayList _errorList;
      public TwainTransferMode _transferMode = TwainTransferMode.Native;
      bool _twainAvailable = false;
      public int _transferComp = (int)TwainCapabilityValue.CompressionNone;
      public int _transferFormat = (int)TwainCapabilityValue.FileFormatBmp;
      public string _transferFile = "";
      private string _openInitialPath = string.Empty;
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

      private void MainForm_Load(object sender, System.EventArgs e)
      {
         Messager.Caption = "Twain High C# Demo";
         Text = Messager.Caption;

         // initialize the codecs object
         _codecs = new RasterCodecs();

#if !LEADTOOLS_V19_OR_LATER
         _twainAvailable = TwainSession.IsAvailable(this);
#else
         _twainAvailable = TwainSession.IsAvailable(this.Handle);
#endif // #if !LEADTOOLS_V19_OR_LATER
         if (_twainAvailable)
         {
            try
            {
               _twainSession = new TwainSession();
#if !LEADTOOLS_V19_OR_LATER
               _twainSession.Startup(this, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
#else
               //For 32-bit driver support in 64-bit applications, use the following TWAIN initialization method instead:
               //_twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.UseThunkServer);

               _twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
#endif // #if !LEADTOOLS_V19_OR_LATER

               _twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(_twain_AcquirePage);
            }
            catch (TwainException ex)
            {
               if (ex.Code == TwainExceptionCode.InvalidDll)
               {
                  _miTwainSelectSource.Enabled = false;
                  _miTwainAcquire.Enabled = false;
                  _miTwainAcquireCleanup.Enabled = false;
                  _miTemplateLEAD.Enabled = false;
                  _miTemplateShowCaps.Enabled = false;
                  _miTemplateShowErrors.Enabled = false;
                  Messager.ShowError(this, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org");
               }
               else
               {
                  _miTwainSelectSource.Enabled = false;
                  _miTwainAcquire.Enabled = false;
                  _miTwainAcquireCleanup.Enabled = false;
                  _miTemplateLEAD.Enabled = false;
                  _miTemplateShowCaps.Enabled = false;
                  _miTemplateShowErrors.Enabled = false;
                  Messager.ShowError(this, ex);
               }
            }
            catch (Exception ex)
            {
               Messager.ShowError(this, ex);
               _miTwainSelectSource.Enabled = false;
               _miTwainAcquire.Enabled = false;
               _miTwainAcquireCleanup.Enabled = false;
               _miTemplateLEAD.Enabled = false;
               _miTemplateShowCaps.Enabled = false;
               _miTemplateShowErrors.Enabled = false;
            }
         }
         else
         {
            _miTwainSelectSource.Enabled = false;
            _miTwainAcquire.Enabled = false;
            _miTwainAcquireCleanup.Enabled = false;
            _miTemplateLEAD.Enabled = false;
            _miTemplateShowCaps.Enabled = false;
            _miTemplateShowErrors.Enabled = false;
         }

         EnableMenuItems(false);
         _errorList = new ArrayList();
      }

      private void _miFileOpen_Click(object sender, System.EventArgs e)
      {
         ImageFileLoader loader = new ImageFileLoader();

         loader.OpenDialogInitialPath = _openInitialPath;

         try
         {
            loader.LoadOnlyOnePage = true;
            if (loader.Load(this, _codecs, true) > 0)
            {
               _openInitialPath = Path.GetDirectoryName(loader.FileName);
               CreateChildForm(loader.Image, loader.FileName);
            }
         }
         catch(Exception ex)
         {
            Messager.ShowFileOpenError(this, loader.FileName, ex);
         }
      }

      private void CreateChildForm(RasterImage img, string caption)
      {
         ChildForm child = new ChildForm();
         child.MdiParent = this;
         child.InsertImage(img, caption);
         child.Show();

         EnableMenuItems(true);
      }

      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void _miFileSave_Click(object sender, System.EventArgs e)
      {
         ImageFileSaver saver = new ImageFileSaver();

         try
         {
            ChildForm child = (ChildForm)ActiveMdiChild;
            saver.Save(this, _codecs, child._viewer.Image);
         }
         catch(Exception ex)
         {
            Messager.ShowFileSaveError(this, saver.FileName, ex);
         }
      }

      public void EnableMenuItems(bool enable)
      {
         _miFileSave.Enabled = enable;
         _miFileClose.Enabled = enable;
      }

      private void _miFileClose_Click(object sender, System.EventArgs e)
      {
         ActiveMdiChild.Close();
      }

      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog("Twain High", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _miTwainSelectSource_Click(object sender, System.EventArgs e)
      {
         _twainSession.SelectSource(String.Empty);
      }

      private void _twain_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         try
         {
            if(_transferMode != TwainTransferMode.File)
            {
               if(e.Image != null)
               {
                  _scanCount++;
                  string childCaption;
                  childCaption = string.Format("Twain Scanned page {0}", _scanCount.ToString());

                  if (_cleanupAfterAcquire)
                     ApplyDocumentCleanupCommands(e.Image);

                  CreateChildForm(e.Image, childCaption);
               }
            }
            else
               MessageBox.Show(this, "Acquired page(s) is saved to file(s)", "Acquire to File");
         }
         catch(Exception ex)
         {
            AddErrorToErrorList(ex.Message);
         }
      }

      private void _miTwainAcquire_Click(object sender, System.EventArgs e)
      {
         Acquire(false);
      }

      static public void AddErrorToErrorList(string error)
      {
         _errorList.Add(error);
      }

      private void _miTemplateShowErrors_Click(object sender, System.EventArgs e)
      {
         using(ErrorList errorListDlg = new ErrorList())
         {
            errorListDlg._arrayList = _errorList;
            if(errorListDlg.ShowDialog(this) == DialogResult.OK)
            {
               if(errorListDlg._listCleared)
                  _errorList.Clear();
            }
         }
      }

      private void _miTemplateShowCaps_Click(object sender, System.EventArgs e)
      {
         using(SupportedCaps supportedCapsDls = new SupportedCaps())
         {
            try
            {
               supportedCapsDls._caps = _twainSession.QuerySupportedCapabilities();
               supportedCapsDls.ShowDialog(this);
            }
            catch(Exception ex)
            {
               AddErrorToErrorList(ex.Message);
            }
         }
      }

      private void _miTemplateLEAD_Click(object sender, System.EventArgs e)
      {
         using(Template templateDlg = new Template())
         {
            templateDlg._twainSession = _twainSession;
            templateDlg.ShowDialog(this);

            if(templateDlg.DialogResult == DialogResult.OK)
            {
               _transferMode = templateDlg._transferMode;
               _transferFormat = templateDlg._transferFormat;
               _transferFile = templateDlg._transferFile;
               _transferComp = templateDlg._transferComp;
            }
         }
      }

      private void SetTransferMode( )
      {
         try
         {
            TwainTransferOptions to = _twainSession.TransferOptions;
            to.TransferMode = _transferMode;
            to.FileFormat = (RasterImageFormat)_transferFormat;
            to.FileName = _transferFile;
            to.CompressionMode = (TwainCompressionMode)_transferComp;

            _twainSession.TransferOptions = to;
         }
         catch(Exception ex)
         {
            string errorMsg = string.Format("Error set TwainCapabilityType.ImageTranserMechanism is {0}", ex.Message);
            AddErrorToErrorList(errorMsg);
         }
      }

      private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         if (_twainSession != null && _twainAvailable)
            this._twainSession.Shutdown();
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
      }

      private void Acquire(bool cleanup)
      {
         try
         {
            SetTransferMode();

            if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, _twainSession.SelectedSourceName()))
               return;

            _cleanupAfterAcquire = cleanup;
            if (_cleanupAfterAcquire)
               ShowCleanUpMessage();

            // Acquire one or more images from a TWAIN source.
            _twainSession.Acquire(TwainUserInterfaceFlags.Show | TwainUserInterfaceFlags.Modal);
         }
         catch (Exception ex)
         {
            AddErrorToErrorList(ex.Message);
            MessageBox.Show(this, ex.Message);
         }
      }
   }
}
