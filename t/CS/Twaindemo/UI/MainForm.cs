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

namespace TwainDemo
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
      private MenuItem _miDocumentCleanup;
      private MenuItem _miDocCleanDeskew;
      private MenuItem _miDocCleanDespeckle;
      private MenuItem _miDocCleanBorderRemove;
      private MenuItem _miDocCleanHolePunchRemoval;
      private MenuItem _miHelpInfo;
      private MenuItem _miTwainAcquireCleanup;
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
         this._miTwainAcquireCleanup = new System.Windows.Forms.MenuItem();
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
         resources.ApplyResources(this._miFile, "_miFile");
         // 
         // _miFileOpen
         // 
         this._miFileOpen.Index = 0;
         resources.ApplyResources(this._miFileOpen, "_miFileOpen");
         this._miFileOpen.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileSave
         // 
         this._miFileSave.Index = 1;
         resources.ApplyResources(this._miFileSave, "_miFileSave");
         this._miFileSave.Click += new System.EventHandler(this._miFileSave_Click);
         // 
         // _miFileSep1
         // 
         this._miFileSep1.Index = 2;
         resources.ApplyResources(this._miFileSep1, "_miFileSep1");
         // 
         // _miFileClose
         // 
         this._miFileClose.Index = 3;
         resources.ApplyResources(this._miFileClose, "_miFileClose");
         this._miFileClose.Click += new System.EventHandler(this._miFileClose_Click);
         // 
         // _mmFileSep2
         // 
         this._mmFileSep2.Index = 4;
         resources.ApplyResources(this._mmFileSep2, "_mmFileSep2");
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 5;
         resources.ApplyResources(this._miFileExit, "_miFileExit");
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miTwain
         // 
         this._miTwain.Index = 1;
         this._miTwain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miTwainSelectSource,
            this._miTwainAcquire,
            this._miTwainAcquireCleanup});
         resources.ApplyResources(this._miTwain, "_miTwain");
         // 
         // _miTwainSelectSource
         // 
         this._miTwainSelectSource.Index = 0;
         resources.ApplyResources(this._miTwainSelectSource, "_miTwainSelectSource");
         this._miTwainSelectSource.Click += new System.EventHandler(this._miTwainSelectSource_Click);
         // 
         // _miTwainAcquire
         // 
         this._miTwainAcquire.Index = 1;
         resources.ApplyResources(this._miTwainAcquire, "_miTwainAcquire");
         this._miTwainAcquire.Click += new System.EventHandler(this._miTwainAcquire_Click);
         // 
         // _miTwainAcquireCleanup
         // 
         this._miTwainAcquireCleanup.Index = 2;
         resources.ApplyResources(this._miTwainAcquireCleanup, "_miTwainAcquireCleanup");
         this._miTwainAcquireCleanup.Click += new System.EventHandler(this._miTwainAcquireCleanup_Click);
         // 
         // _miDocumentCleanup
         // 
         this._miDocumentCleanup.Index = 2;
         this._miDocumentCleanup.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miDocCleanDeskew,
            this._miDocCleanDespeckle,
            this._miDocCleanBorderRemove,
            this._miDocCleanHolePunchRemoval});
         resources.ApplyResources(this._miDocumentCleanup, "_miDocumentCleanup");
         // 
         // _miDocCleanDeskew
         // 
         this._miDocCleanDeskew.Checked = true;
         this._miDocCleanDeskew.Index = 0;
         resources.ApplyResources(this._miDocCleanDeskew, "_miDocCleanDeskew");
         this._miDocCleanDeskew.Click += new System.EventHandler(this._miDocCleanDeskew_Click);
         // 
         // _miDocCleanDespeckle
         // 
         this._miDocCleanDespeckle.Checked = true;
         this._miDocCleanDespeckle.Index = 1;
         resources.ApplyResources(this._miDocCleanDespeckle, "_miDocCleanDespeckle");
         this._miDocCleanDespeckle.Click += new System.EventHandler(this._miDocCleanDespeckle_Click);
         // 
         // _miDocCleanBorderRemove
         // 
         this._miDocCleanBorderRemove.Checked = true;
         this._miDocCleanBorderRemove.Index = 2;
         resources.ApplyResources(this._miDocCleanBorderRemove, "_miDocCleanBorderRemove");
         this._miDocCleanBorderRemove.Click += new System.EventHandler(this._miDocCleanBorderRemove_Click);
         // 
         // _miDocCleanHolePunchRemoval
         // 
         this._miDocCleanHolePunchRemoval.Checked = true;
         this._miDocCleanHolePunchRemoval.Index = 3;
         resources.ApplyResources(this._miDocCleanHolePunchRemoval, "_miDocCleanHolePunchRemoval");
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
         resources.ApplyResources(this._miTemplate, "_miTemplate");
         // 
         // _miTemplateLEAD
         // 
         this._miTemplateLEAD.Index = 0;
         resources.ApplyResources(this._miTemplateLEAD, "_miTemplateLEAD");
         this._miTemplateLEAD.Click += new System.EventHandler(this._miTemplateLEAD_Click);
         // 
         // _miTemplateShowCaps
         // 
         this._miTemplateShowCaps.Index = 1;
         resources.ApplyResources(this._miTemplateShowCaps, "_miTemplateShowCaps");
         this._miTemplateShowCaps.Click += new System.EventHandler(this._miTemplateShowCaps_Click);
         // 
         // _miTemplateSep1
         // 
         this._miTemplateSep1.Index = 2;
         resources.ApplyResources(this._miTemplateSep1, "_miTemplateSep1");
         // 
         // _miTemplateShowErrors
         // 
         this._miTemplateShowErrors.Index = 3;
         resources.ApplyResources(this._miTemplateShowErrors, "_miTemplateShowErrors");
         this._miTemplateShowErrors.Click += new System.EventHandler(this._miTemplateShowErrors_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 4;
         this._miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miHelpAbout,
            this._miHelpInfo});
         resources.ApplyResources(this._miHelp, "_miHelp");
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Index = 0;
         resources.ApplyResources(this._miHelpAbout, "_miHelpAbout");
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // _miHelpInfo
         // 
         this._miHelpInfo.Index = 1;
         resources.ApplyResources(this._miHelpInfo, "_miHelpInfo");
         this._miHelpInfo.Click += new System.EventHandler(this._miHelpInfo_Click);
         // 
         // MainForm
         // 
         resources.ApplyResources(this, "$this");
         this.IsMdiContainer = true;
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.ResumeLayout(false);

      }
      #endregion
      TwainSession _twainSession;
      RasterCodecs _codecs;
      int _scanCount;
      static ArrayList _errorList;
      public TwainTransferMechanism _transferMode = TwainTransferMechanism.Native;
      bool _twainAvailable = false;
      private string _openInitialPath = string.Empty;
      TwainDocumentCleanupMessage infoDlg = new TwainDocumentCleanupMessage();
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
         Messager.Caption = "Twain C# Demo";
         Text = Messager.Caption;

         // initialize the codecs object
         _codecs = new RasterCodecs();

         try
         {
            // Determine whether a TWAIN source is installed
#if !LEADTOOLS_V19_OR_LATER
            _twainAvailable = TwainSession.IsAvailable(this);
#else
            _twainAvailable = TwainSession.IsAvailable(this.Handle);
#endif // #if !LEADTOOLS_V19_OR_LATER
            if (_twainAvailable)
            {
               // Construct a new TwainSession object with default values
               _twainSession = new TwainSession();
               // Initialize the TWAIN session 
               // This method must be called before calling any other methods that require a TWAIN session
#if !LEADTOOLS_V19_OR_LATER
               _twainSession.Startup(this, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
#else
               //For 32-bit driver support in 64-bit applications, use the following TWAIN initialization method instead:
               //_twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.UseThunkServer);

               _twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
#endif // #if !LEADTOOLS_V19_OR_LATER

               // Set the AcquirePage Event handler
               _twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(_twain_AcquirePage);
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
         catch (TwainException ex)
         {
            _miTwainSelectSource.Enabled = false;
            _miTwainAcquire.Enabled = false;
            _miTwainAcquireCleanup.Enabled = false;
            _miTemplateLEAD.Enabled = false;
            _miTemplateShowCaps.Enabled = false;
            _miTemplateShowErrors.Enabled = false;
            EnableMenuItems(false);
            if (ex.Code == TwainExceptionCode.InvalidDll)
            {
               Messager.ShowError(this, string.Format("{0} TWAINDSM.DLL. {1} www.twain.org", DemosGlobalization.GetResxString(GetType(), "resx_OldVersion1"), DemosGlobalization.GetResxString(GetType(), "resx_OldVersion1"))); 
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
         using (AboutDialog aboutDialog = new AboutDialog("Twain", ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _miTwainSelectSource_Click(object sender, System.EventArgs e)
      {
         // Display the TWAIN dialog box to be used to select a TWAIN source for acquiring images
         _twainSession.SelectSource(String.Empty);
      }

      private void _twain_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         // This event occurs for each page acquired using the Acquire method
         try
         {
            if(_transferMode != TwainTransferMechanism.File)
            {
               if(e.Image != null)
               {
                  _scanCount++;
                  string childCaption;
                  childCaption = string.Format("Twain {0}{1}", DemosGlobalization.GetResxString(GetType(), "resx_ScannedPage"), _scanCount.ToString());

                  if (_cleanupAfterAcquire)
                     ApplyDocumentCleanupCommands(e.Image);
                  CreateChildForm(e.Image, childCaption);
               }
            }
            else
               MessageBox.Show(this, DemosGlobalization.GetResxString(GetType(), "resx_AcquireToFileMsg"), DemosGlobalization.GetResxString(GetType(), "resx_AcquireToFile"));
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
               // Get an array of Twain Capabilities supported in the current session
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
         // Show the Templates dialog which will allow to Save/Load scanning settings
         using(Template templateDlg = new Template())
         {
            templateDlg._twainSession = _twainSession;
            templateDlg.ShowDialog(this);

            if(templateDlg.DialogResult == DialogResult.OK)
               _transferMode = templateDlg._transferMode;
         }
      }

      private void SetTransferMode( )
      {
         using (TwainCapability twnCap = new TwainCapability())
         {
            try
            {
               twnCap.Information.Type = TwainCapabilityType.ImageTransferMechanism;
               twnCap.Information.ContainerType = TwainContainerType.OneValue;

               twnCap.OneValueCapability.ItemType = TwainItemType.Uint16;
               twnCap.OneValueCapability.Value = (UInt16)_transferMode;

               // Set the value of ICAP_XFERMECH (Image Transfer Mechanism) capability
               _twainSession.SetCapability(twnCap, TwainSetCapabilityMode.Set);
            }
            catch (Exception ex)
            {
               string errorMsg = string.Format("{0}{1}",DemosGlobalization.GetResxString(GetType(),"resx_TwainCapabilityTypeError"), ex.Message);
               AddErrorToErrorList(errorMsg);
            }
         }
      }

      private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         if (_twainSession != null && _twainAvailable)
            // End TWAIN session
            // For each call to the Startup method there must be a call to the Shutdown method
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
            if (infoDlg.ShouldShow())
               infoDlg.ShowDialog();
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
         infoDlg.ShowDialog();
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
