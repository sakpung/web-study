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
using Leadtools.Wia;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Demos.Dialogs;
using Leadtools.WinForms;

namespace WiaDemo
{
   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public class MainForm : System.Windows.Forms.Form
   {
      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.MenuItem _miFileSave;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miFileClose;
      private System.Windows.Forms.MenuItem _mmFileSep2;
      private MenuItem _miWia;
      private MenuItem _miWiaSelectSource;
      private MenuItem _miWiaAcquire;
      private MenuItem _miProperties;
      private MenuItem _miPropertiesWiaProperties;
      private MenuItem menuItem3;
      private MenuItem _miPropertiesShowErrors;
      private MenuItem _miOptions;
      private MenuItem _miOptionsAcquireOptions;
      private MenuItem _miCapabilities;
      private MenuItem _miCapabilitiesShowCapabilities;
      private MenuItem _miCapabilitiesShowFormats;
      private MenuItem _miWiaAcquireStillImages;
      private IContainer components;

      public static RasterCodecs _codecs;
      public static WiaSession _wiaSession;
      public static WiaAcquireOptions _wiaAcquireOptions = WiaAcquireOptions.Empty;
      public static WiaProperties _wiaProperties = WiaProperties.Empty;
      public static WiaVersion _wiaVersion;
      public static WiaTransferMode _transferMode;
      public static ArrayList _errorList;
      public static Object _selectedWiaItem = null;
      public static ArrayList _capabilitiesList;
      public static ArrayList _formatsList;
      public static ArrayList _flagValuesStrings;
      public static bool _forCapabilities = false;
      public static bool _showUserInterface = true;
      public static bool _acquireFromFeeder = true;
      public ProgressForm _progressDlg;
      private int _scanCount = 0;
      private bool _wiaAvailable = false;
      private bool _wiaSourceSelected = false;
      private bool _wiaVideoStreamSource = false;
      private bool _wiaAcquiring = false;
      private MenuItem menuItem1;
      private MenuItem _miOptionsShowUI;
      private object _sourceItem = null;
      private ArrayList _enumeratedWiaItems = new ArrayList();
      private string _openInitialPath = string.Empty;

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
         this._miWia = new System.Windows.Forms.MenuItem();
         this._miWiaSelectSource = new System.Windows.Forms.MenuItem();
         this._miWiaAcquire = new System.Windows.Forms.MenuItem();
         this._miWiaAcquireStillImages = new System.Windows.Forms.MenuItem();
         this._miOptions = new System.Windows.Forms.MenuItem();
         this._miOptionsAcquireOptions = new System.Windows.Forms.MenuItem();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this._miOptionsShowUI = new System.Windows.Forms.MenuItem();
         this._miCapabilities = new System.Windows.Forms.MenuItem();
         this._miCapabilitiesShowCapabilities = new System.Windows.Forms.MenuItem();
         this._miCapabilitiesShowFormats = new System.Windows.Forms.MenuItem();
         this._miProperties = new System.Windows.Forms.MenuItem();
         this._miPropertiesWiaProperties = new System.Windows.Forms.MenuItem();
         this.menuItem3 = new System.Windows.Forms.MenuItem();
         this._miPropertiesShowErrors = new System.Windows.Forms.MenuItem();
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this._miWia,
            this._miOptions,
            this._miCapabilities,
            this._miProperties,
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
         this._miFile.Popup += new System.EventHandler(this._miFile_Popup);
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
         // _miWia
         // 
         this._miWia.Index = 1;
         this._miWia.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miWiaSelectSource,
            this._miWiaAcquire,
            this._miWiaAcquireStillImages});
         resources.ApplyResources(this._miWia, "_miWia");
         this._miWia.Popup += new System.EventHandler(this._miWia_Popup);
         // 
         // _miWiaSelectSource
         // 
         this._miWiaSelectSource.Index = 0;
         resources.ApplyResources(this._miWiaSelectSource, "_miWiaSelectSource");
         this._miWiaSelectSource.Click += new System.EventHandler(this._miWiaSelectSource_Click);
         // 
         // _miWiaAcquire
         // 
         this._miWiaAcquire.Index = 1;
         resources.ApplyResources(this._miWiaAcquire, "_miWiaAcquire");
         this._miWiaAcquire.Click += new System.EventHandler(this._miWiaAcquire_Click);
         // 
         // _miWiaAcquireStillImages
         // 
         this._miWiaAcquireStillImages.Index = 2;
         resources.ApplyResources(this._miWiaAcquireStillImages, "_miWiaAcquireStillImages");
         this._miWiaAcquireStillImages.Click += new System.EventHandler(this._miWiaAcquireStillImages_Click);
         // 
         // _miOptions
         // 
         this._miOptions.Index = 2;
         this._miOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miOptionsAcquireOptions,
            this.menuItem1,
            this._miOptionsShowUI});
         resources.ApplyResources(this._miOptions, "_miOptions");
         this._miOptions.Popup += new System.EventHandler(this._miOptions_Popup);
         // 
         // _miOptionsAcquireOptions
         // 
         this._miOptionsAcquireOptions.Index = 0;
         resources.ApplyResources(this._miOptionsAcquireOptions, "_miOptionsAcquireOptions");
         this._miOptionsAcquireOptions.Click += new System.EventHandler(this._miOptionsAcquireOptions_Click);
         // 
         // menuItem1
         // 
         this.menuItem1.Index = 1;
         resources.ApplyResources(this.menuItem1, "menuItem1");
         // 
         // _miOptionsShowUI
         // 
         this._miOptionsShowUI.Index = 2;
         resources.ApplyResources(this._miOptionsShowUI, "_miOptionsShowUI");
         this._miOptionsShowUI.Click += new System.EventHandler(this._miOptionsShowUI_Click);
         // 
         // _miCapabilities
         // 
         this._miCapabilities.Index = 3;
         this._miCapabilities.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miCapabilitiesShowCapabilities,
            this._miCapabilitiesShowFormats});
         resources.ApplyResources(this._miCapabilities, "_miCapabilities");
         this._miCapabilities.Popup += new System.EventHandler(this._miCapabilities_Popup);
         // 
         // _miCapabilitiesShowCapabilities
         // 
         this._miCapabilitiesShowCapabilities.Index = 0;
         resources.ApplyResources(this._miCapabilitiesShowCapabilities, "_miCapabilitiesShowCapabilities");
         this._miCapabilitiesShowCapabilities.Click += new System.EventHandler(this._miCapabilitiesShowCapabilities_Click);
         // 
         // _miCapabilitiesShowFormats
         // 
         this._miCapabilitiesShowFormats.Index = 1;
         resources.ApplyResources(this._miCapabilitiesShowFormats, "_miCapabilitiesShowFormats");
         this._miCapabilitiesShowFormats.Click += new System.EventHandler(this._miCapabilitiesShowFormats_Click);
         // 
         // _miProperties
         // 
         this._miProperties.Index = 4;
         this._miProperties.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miPropertiesWiaProperties,
            this.menuItem3,
            this._miPropertiesShowErrors});
         resources.ApplyResources(this._miProperties, "_miProperties");
         this._miProperties.Popup += new System.EventHandler(this._miProperties_Popup);
         // 
         // _miPropertiesWiaProperties
         // 
         this._miPropertiesWiaProperties.Index = 0;
         resources.ApplyResources(this._miPropertiesWiaProperties, "_miPropertiesWiaProperties");
         this._miPropertiesWiaProperties.Click += new System.EventHandler(this._miPropertiesWiaProperties_Click);
         // 
         // menuItem3
         // 
         this.menuItem3.Index = 1;
         resources.ApplyResources(this.menuItem3, "menuItem3");
         // 
         // _miPropertiesShowErrors
         // 
         this._miPropertiesShowErrors.Index = 2;
         resources.ApplyResources(this._miPropertiesShowErrors, "_miPropertiesShowErrors");
         this._miPropertiesShowErrors.Click += new System.EventHandler(this._miPropertiesShowErrors_Click);
         // 
         // _miHelp
         // 
         this._miHelp.Index = 5;
         this._miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miHelpAbout});
         resources.ApplyResources(this._miHelp, "_miHelp");
         this._miHelp.Popup += new System.EventHandler(this._miHelp_Popup);
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Index = 0;
         resources.ApplyResources(this._miHelpAbout, "_miHelpAbout");
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // MainForm
         // 
         resources.ApplyResources(this, "$this");
         this.IsMdiContainer = true;
         this.Menu = this._mmMain;
         this.Name = "MainForm";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
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

         using (WiaVersionForm WiaVersionDlg = new WiaVersionForm())
         {
            if (WiaVersionDlg.ShowDialog() == DialogResult.OK)
            {
               _wiaVersion = WiaVersionDlg._selectedWiaVersion;
            }
            else
            {
               return;
            }
         }

         Application.Run(new MainForm());
      }

      private void MainForm_Load(object sender, System.EventArgs e)
      {
         // initialize the codecs object
         _codecs = new RasterCodecs();

         _wiaAvailable = WiaSession.IsAvailable(_wiaVersion);
         if(_wiaAvailable)
         {
            _wiaSession = new WiaSession();
            _wiaSession.Startup(_wiaVersion);
            _miWiaSelectSource.Enabled = true;

            // Set the default acquire path for file transfer to My Documents folder.
            string myDocumentsPath;
            HelperFunctions.GetFormatFilterAndExtension();

            myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _wiaAcquireOptions.FileName = string.Format("{0}{1}{2}", myDocumentsPath, "\\" + DemosGlobalization.GetResxString(GetType(), "Resx_WiaTest") + ".", HelperFunctions.Extension);

            if(_wiaProperties.DataTransfer.TransferMode == WiaTransferMode.None) // GetProperties() method not called yet.
            {
               _transferMode = WiaTransferMode.Memory;
            }
            else
            {
               _transferMode = _wiaProperties.DataTransfer.TransferMode;
            }

            _wiaSession.AcquireEvent += new EventHandler<WiaAcquireEventArgs>(_wiaSession_AcquireEvent);
         }
         else
         {
            _miWiaSelectSource.Enabled = false;
         }

         EnableMenuItems(false);
         _errorList = new ArrayList();
         _capabilitiesList = new ArrayList();
         _formatsList = new ArrayList();
         _flagValuesStrings = new ArrayList();
      }

      private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
      {
         // prevent the application from closing while acquiring.
         if (_wiaAcquiring)
         {
            e.Cancel = true;
            return;
         }
         _wiaSession.AcquireEvent -= new EventHandler<WiaAcquireEventArgs>(_wiaSession_AcquireEvent);

         if (_wiaAvailable)
            _wiaSession.Shutdown();
      }

      private void _miFile_Popup(object sender, EventArgs e)
      {
         _miFileOpen.Enabled = !_wiaAcquiring;
         _miFileExit.Enabled = !_wiaAcquiring;
      }

      private void _miWia_Popup(object sender, EventArgs e)
      {
         if (_wiaAvailable && _wiaSourceSelected && !_wiaAcquiring)
         {
            _miWiaAcquire.Enabled = true;
            if (_wiaVideoStreamSource)
            {
               _miWiaAcquireStillImages.Enabled = true;
            }
            else
            {
               _miWiaAcquireStillImages.Enabled = false;
            }
         }
         else
         {
            if (_wiaAcquiring)
               _miWiaSelectSource.Enabled = false;
            else
               _miWiaSelectSource.Enabled = true;

            _miWiaAcquire.Enabled = false;
            _miWiaAcquireStillImages.Enabled = false;
         }
      }

      private void _miOptions_Popup(object sender, EventArgs e)
      {
         if (_wiaAvailable && _wiaSourceSelected && !_wiaAcquiring)
         {
            _miOptionsAcquireOptions.Enabled = true;
            _miOptionsShowUI.Enabled = true;
         }
         else
         {
            _miOptionsAcquireOptions.Enabled = false;
            _miOptionsShowUI.Enabled = false;
         }

         _miOptionsShowUI.Checked = _showUserInterface;
      }

      private void _miCapabilities_Popup(object sender, EventArgs e)
      {
         if (_wiaAvailable && _wiaSourceSelected && !_wiaAcquiring)
         {
            _miCapabilitiesShowCapabilities.Enabled = true;
            _miCapabilitiesShowFormats.Enabled = true;
         }
         else
         {
            _miCapabilitiesShowCapabilities.Enabled = false;
            _miCapabilitiesShowFormats.Enabled = false;
         }
      }

      private void _miProperties_Popup(object sender, EventArgs e)
      {
         if (_wiaAvailable && _wiaSourceSelected && !_wiaAcquiring)
         {
            _miPropertiesWiaProperties.Enabled = true;
            if(_errorList.Count > 0)
               _miPropertiesShowErrors.Enabled = true;
            else
               _miPropertiesShowErrors.Enabled = false;
         }
         else
         {
            _miPropertiesWiaProperties.Enabled = false;
            _miPropertiesShowErrors.Enabled = false;
         }
      }

      private void _miHelp_Popup(object sender, EventArgs e)
      {
         _miHelpAbout.Enabled = !_wiaAcquiring;
      }

      public void CreateChildForm(RasterImage img, string caption)
      {
         ChildForm child = new ChildForm();
         child.MdiParent = this;
         child.InsertImage(img, caption);
         child.Show();

         EnableMenuItems(true);
      }

      public void EnableMenuItems(bool enable)
      {
         _miFileSave.Enabled = enable;
         _miFileClose.Enabled = enable;
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

      private void _miFileExit_Click(object sender, System.EventArgs e)
      {
         Close();
      }

      private void _miFileClose_Click(object sender, System.EventArgs e)
      {
         ActiveMdiChild.Close();
      }

      private void _miHelpAbout_Click(object sender, System.EventArgs e)
      {
         using (AboutDialog aboutDialog = new AboutDialog(DemosGlobalization.GetResxString(GetType(), "Resx_WIA"), ProgrammingInterface.CS))
            aboutDialog.ShowDialog(this);
      }

      private void _miWiaSelectSource_Click(object sender, System.EventArgs e)
      {
         try
         {
#if !LEADTOOLS_V19_OR_LATER
            DialogResult res = _wiaSession.SelectDeviceDlg(this, WiaDeviceType.Default, WiaSelectSourceFlags.NoDefault);
#else
            DialogResult res = _wiaSession.SelectDeviceDlg(this.Handle, WiaDeviceType.Default, WiaSelectSourceFlags.NoDefault);
#endif // #if !LEADTOOLS_V19_OR_LATER
            if (res == DialogResult.OK)
            {
               _wiaSourceSelected = true;
               if (_wiaSession.SelectedDeviceType == WiaDeviceType.StreamingVideo)
               {
                  _wiaVideoStreamSource = true;
               }
               else
               {
                  _wiaVideoStreamSource = false;
               }
            }
         }
         catch(Exception ex)
         {
            _wiaSourceSelected = false;
            _wiaVideoStreamSource = false;
            Messager.ShowError(this, ex);
         }
      }

      private void _miWiaAcquire_Click(object sender, System.EventArgs e)
      {
         WiaAcquireFlags flags = WiaAcquireFlags.None;
         bool showProgress = true;

         _progressDlg = new ProgressForm(DemosGlobalization.GetResxString(GetType(), "Resx_Transferring"), "", 100);

         _wiaAcquiring = true;

         if(_showUserInterface)
         {
            flags = WiaAcquireFlags.UseCommonUI | WiaAcquireFlags.ShowUserInterface;
         }
         else
         {
            // Check if the selected device is scanner and that it has multiple sources (Feeder & Flatbed)
            // then show the select source dialog box.
            if( SelectAcquireSource() != DialogResult.OK)
            {
               _wiaAcquiring = false;
               return;
            }
         }

         if (_showUserInterface)
         {
            if (_wiaVersion == WiaVersion.Version2)
               showProgress = false;
         }

         if(showProgress)
         {
            // Show the progress dialog.
            _progressDlg.Show(this);
         }

         try
         {
            _wiaSession.AcquireOptions = _wiaAcquireOptions;

            if (_wiaProperties.DataTransfer.TransferMode == WiaTransferMode.None) // GetProperties() method not called yet.
            {
               _transferMode = WiaTransferMode.Memory;
            }
            else
            {
               _transferMode = _wiaProperties.DataTransfer.TransferMode;
            }

            // Disable the minimize and maximize buttons.
            this.MinimizeBox = false;
            this.MaximizeBox = false;

#if !LEADTOOLS_V19_OR_LATER
            DialogResult dialogResult = _wiaSession.Acquire(this, _sourceItem, flags);
#else
            DialogResult dialogResult = _wiaSession.Acquire(this.Handle, _sourceItem, flags);
#endif // #if !LEADTOOLS_V19_OR_LATER
            if (dialogResult != DialogResult.OK)
               return;

            // Enable back the minimize and maximize buttons.
            this.MinimizeBox = true;
            this.MaximizeBox = true;

            if (_progressDlg.Visible)
            {
               if (!_progressDlg.Abort)
                  _progressDlg.Dispose();
            }

            if(_sourceItem != null)
            {
               _sourceItem = null;
            }

            if (_wiaSession.FilesCount > 0)  // This property indicates how many files where saved when the transfer mode is File mode.
            {
               string strMsg = DemosGlobalization.GetResxString(GetType(), "Resx_PagesSavedTo") + "\n\n";
               if (_wiaSession.FilesPaths.Count > 0)
               {
                  for (int i = 0; i < _wiaSession.FilesPaths.Count; i++)
                  {
                     string strTemp = string.Format("{0}\n", _wiaSession.FilesPaths[i]);
                     strMsg += strTemp;
                  }
                  MessageBox.Show(this, strMsg, DemosGlobalization.GetResxString(GetType(), "Resx_FileTransfer"), MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
            }
            else
            {
               // WIA 2.0 sometimes doesn't return the acquired files count and paths, so this message will show 
               // the directory where the saved files were saved.
               if(_wiaVersion == WiaVersion.Version2)
               {
                  int len = _wiaAcquireOptions.FileName.LastIndexOf('\\');
                  string strFilesDirectory = _wiaAcquireOptions.FileName.Substring(0, len);
                  string strMsg = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_PagesSavedTo") + "\n\n{0}", strFilesDirectory);
                  MessageBox.Show(this, strMsg, DemosGlobalization.GetResxString(GetType(), "Resx_FileTransfer"), MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
            }

            _wiaAcquiring = false;
         }
         catch(Exception ex)
         {
            // Enable back the minimize and maximize buttons.
            this.MinimizeBox = true;
            this.MaximizeBox = true;

            _wiaAcquiring = false;
            if (_progressDlg.Visible)
            {
               if (!_progressDlg.Abort)
                  _progressDlg.Dispose();
            }

            Messager.ShowError(this, ex);
         }
         finally
         {
            // Enable back the minimize and maximize buttons.
            this.MinimizeBox = true;
            this.MaximizeBox = true;

            _wiaAcquiring = false;
         }
      }

      void _wiaSession_AcquireEvent(object sender, WiaAcquireEventArgs e)
      {
         string strInfoMsg;

         // Update the progress bar with the received percent value;
         if (_progressDlg.Visible)
         {
            // Show the user some information about the file we are acquiring 
            // to (if the user chooses file transfer).

            if ((e.Flags & WiaAcquiredPageFlags.StartOfPage) == WiaAcquiredPageFlags.StartOfPage)
            {
               if (_transferMode == WiaTransferMode.File)
               {
                  strInfoMsg = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_TransferringToFile:") + "\n\n{0}", e.FileName);
                  _progressDlg.InformationString = strInfoMsg;
               }
            }

            if (((e.Flags & WiaAcquiredPageFlags.StartOfPage) == WiaAcquiredPageFlags.StartOfPage) && 
                ((e.Flags & WiaAcquiredPageFlags.EndOfPage) != WiaAcquiredPageFlags.EndOfPage) )
            {
               _progressDlg.Percent = 0;
            }
            else
            {
               _progressDlg.Percent = (Int32)e.Percent;
            }

            Application.DoEvents();

            if (_progressDlg.Abort)
               e.Cancel = true;
         }

         if (_transferMode != WiaTransferMode.File)
         {
            if (e.Image != null)
            {
               _scanCount++;
               string childCaption = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_WIAScannedPage") + " {0}", _scanCount.ToString());
               CreateChildForm(e.Image, childCaption);

               Application.DoEvents();
            }
         }
      }

      private DialogResult SelectAcquireSource()
      {
         _forCapabilities = true;
         DialogResult dlgResult = DialogResult.Cancel;

         using (WiaDeviceItemsForm DeviceItemsDlg = new WiaDeviceItemsForm())
         {
            dlgResult = DeviceItemsDlg.ShowDialog(this);
            if (dlgResult == DialogResult.OK)
               _sourceItem = _selectedWiaItem;
         }

         return dlgResult;
      }

      void _wiaSession_EnumItemsEvent(object sender, WiaEnumItemsEventArgs e)
      {
         _enumeratedWiaItems.Add(e.Item);
      }

      private void _miOptionsAcquireOptions_Click(object sender, EventArgs e)
      {
         using (AcquireOptionsForm AcquireOptionsDlg = new AcquireOptionsForm())
         {
            AcquireOptionsDlg.ShowDialog(this);
         }
      }

      private void _miOptionsShowUI_Click(object sender, EventArgs e)
      {
         _showUserInterface = !_showUserInterface;
      }

      private void _miWiaAcquireStillImages_Click(object sender, EventArgs e)
      {
         using (CaptureStillImagesForm CaptureStillImagesDlg = new CaptureStillImagesForm())
         {
            CaptureStillImagesDlg.FormParent = this;
            CaptureStillImagesDlg.ShowDialog(this);
         }
      }

      private void _miCapabilitiesShowCapabilities_Click(object sender, EventArgs e)
      {
         _forCapabilities = true;
         using (WiaDeviceItemsForm DeviceItemsDlg = new WiaDeviceItemsForm())
         {
            if (DeviceItemsDlg.ShowDialog(this) == DialogResult.OK)
            {
               using (SupportedCapabilitiesForm SupportedCapsDlg = new SupportedCapabilitiesForm())
               {
                  SupportedCapsDlg.ShowDialog(this);
               }
            }
         }
      }

      private void _miCapabilitiesShowFormats_Click(object sender, EventArgs e)
      {
         _forCapabilities = true;
         using (WiaDeviceItemsForm DeviceItemsDlg = new WiaDeviceItemsForm())
         {
            if (DeviceItemsDlg.ShowDialog(this) == DialogResult.OK)
            {
               using (SupportedFormatsForm SupportedFormatsDlg = new SupportedFormatsForm())
               {
                  SupportedFormatsDlg.ShowDialog(this);
               }
            }
         }
      }

      private void _miPropertiesWiaProperties_Click(object sender, EventArgs e)
      {
         _forCapabilities = false;
         using (WiaDeviceItemsForm DeviceItemsDlg = new WiaDeviceItemsForm())
         {
            if (DeviceItemsDlg.ShowDialog(this) == DialogResult.OK)
            {
               using (WiaPropertiesForm PropertiesDlg = new WiaPropertiesForm())
               {
                  if (PropertiesDlg.ShowDialog(this) == DialogResult.OK)
                  {
                     if (_errorList.Count > 0)
                     {
                        using (WiaPropertiesErrorsForm ErrorsDlg = new WiaPropertiesErrorsForm())
                        {
                           ErrorsDlg.ShowDialog(this);
                        }
                     }
                  }
               }
            }
         }
      }

      private void _miPropertiesShowErrors_Click(object sender, EventArgs e)
      {
         using (WiaPropertiesErrorsForm ErrorsDlg = new WiaPropertiesErrorsForm())
         {
            ErrorsDlg.ShowDialog(this);
         }
      }
   }

   public class ItemData
   {
      private Object _item;
      private Object _node;

      public ItemData(Object item)
      {
         _item = item;
      }

      public Object Item
      {
         get { return _item; }
         set { _item = value; }
      }

      //Used to save corresponding TreeNode.
      public Object Node
      {
         get { return _node; }
         set { _node = value; }
      }
   }
}
