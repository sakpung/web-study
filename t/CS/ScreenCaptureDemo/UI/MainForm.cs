// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using Leadtools;
using Leadtools.ScreenCapture;
using Leadtools.Codecs;
using Leadtools.Demos;
using Leadtools.Controls;

#if LEADTOOLS_V19_OR_LATER
using Leadtools.Demos.Dialogs;
#endif

namespace ScreenCaptureDemo
{
    public partial class MainForm : Form
    {
        // Constructor
        public MainForm()
        {
            InitializeComponent();
        }

        // *****************
        // VARIABLES SECTION
        // *****************

        /// <summary>
        /// What to capture in this app.
        /// </summary>
        private enum CaptureType
        {
            None,
            Window,
            ActiveWindow,
            ActiveClient,
            WallPaper,
            FullScreen,
            MenuUnderCursor,
            WindowUnderCursor,
            SelectedObject,
            Area,
            MouseCursor,
            FromExeTree,
            FromExeTab,
        }

        // current capture type
        private CaptureType _captureType;

        // the raster codecs used in load/save
        private RasterCodecs _codecs;

        // number of opened images
        private int _countOfOpenedImages;

        // boolean variables for menu items (checked or unchecked)
        private bool _isBeepOn;
        private bool _minimizeOnCapture;
        private bool _activateAfterCapture;
        private bool _isImageSaved;
        private bool _cutImage;
        private FormWindowState _previousWindowState;

        // Screen Capture Specific Variables
        private ScreenCaptureEngine _engine = null;
        private ScreenCaptureAreaOptions _areaOptions;
        private ScreenCaptureObjectOptions _objectOptions;
        private ScreenCaptureOptions _options;
        private ScreenCaptureInformation _captureInformation;
        private bool _isHotKeyEnabled;

        private CapturedImageForm ActiveCapturedImageForm
        {
            get
            {
                return ActiveMdiChild as CapturedImageForm;
            }
        }

        public int CountOfOpenedImages
        {
            get
            {
                return _countOfOpenedImages;
            }
            set
            {
                _countOfOpenedImages = value;
            }
        }

        public bool IsCutActive
        {
            get
            {
                return _cutImage;
            }
        }

        public bool EnableSaveAs
        {
            set
            {
                _miFileSaveAs.Enabled = value;
            }
        }

        public bool EnableCut
        {
            set
            {
                _miEditCut.Enabled = value;
            }
        }

        public bool EnableCopy
        {
            set
            {
                _miEditCopy.Enabled = value;
            }
        }

        // **************************
        // PROGRAM SPECIFIC FUNCTIONS
        // **************************

        private void MainForm_Load(object sender, EventArgs e)
        {
            // setup our caption
            Messager.Caption = "LEADTOOLS C# Screen Capture Demo";
            Text = Messager.Caption;

            // what to capture
            _captureType = CaptureType.None;

            // set the current window state
            _previousWindowState = this.WindowState;

            // as a start, do not beep when capturing
            _isBeepOn = false;

            // minimize window on capturing
            _minimizeOnCapture = true;

            // activate window after capturing
            _activateAfterCapture = true;

            // beeping is off
            _isBeepOn = false;

            // no cut is active
            _cutImage = false;

            // initialize the codecs object
            _codecs = new RasterCodecs();

            // no opened images for now
            _countOfOpenedImages = 0;

            // startup the engine
            ScreenCaptureEngine.Startup();

            // initialize Screen Capture Variables
            _engine = new ScreenCaptureEngine();
            _engine.CaptureInformation += new EventHandler<ScreenCaptureInformationEventArgs>(_engine_CaptureInformation);
            _areaOptions = ScreenCaptureEngine.DefaultCaptureAreaOptions;
            _objectOptions = ScreenCaptureEngine.DefaultCaptureObjectOptions;
            _options = _engine.CaptureOptions;
            _captureInformation = null;
            _isHotKeyEnabled = true;

            UpdateMyControls();
            UpdateStatusBarText();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ScreenCaptureEngine.Shutdown();
        }

        void _engine_CaptureInformation(object sender, ScreenCaptureInformationEventArgs e)
        {
            CapturedImageForm child = new CapturedImageForm();

            _countOfOpenedImages++;
            child.MdiParent = this;
            child.Viewer.Image = e.Image;
            child.Text = DemosGlobalization.GetResxString(GetType(), "Resx_CapturedImage") + _countOfOpenedImages;
            child.Show();

            if (_activateAfterCapture)
                this.WindowState = _previousWindowState;

            if (_isBeepOn)
                SystemSounds.Beep.Play();
        }

        private void UpdateMyControls()
        {
            // if we have an image then enable the Save
            CapturedImageForm capturedImageForm = ActiveCapturedImageForm;

            if (capturedImageForm != null)
            {
                _miFileSaveAs.Enabled = true;
                _miEditCopy.Enabled = true;
                _miEditCut.Enabled = true;
            }
            else
            {
                _miFileSaveAs.Enabled = false;
                _miEditCopy.Enabled = false;
                _miEditCut.Enabled = false;
            }

            _miCaptureActiveWindow.Checked = false;
            _miCaptureActiveClient.Checked = false;
            _miCaptureFullScreen.Checked = false;
            _miCaptureSelectedObject.Checked = false;
            _miCaptureMenuUnderCursor.Checked = false;
            _miCaptureSelectedArea.Checked = false;
            _miCaptureWallpaper.Checked = false;
            _miCaptureMouseCursor.Checked = false;
            _miCaptureWindowUnderCursor.Checked = false;

            switch (_captureType)
            {
                case CaptureType.ActiveWindow:
                    _miCaptureActiveWindow.Checked = true;
                    _miCaptureStopCapture.Enabled = true;
                    break;
                case CaptureType.ActiveClient:
                    _miCaptureActiveClient.Checked = true;
                    _miCaptureStopCapture.Enabled = true;
                    break;
                case CaptureType.FullScreen:
                    _miCaptureFullScreen.Checked = true;
                    _miCaptureStopCapture.Enabled = true;
                    break;
                case CaptureType.SelectedObject:
                    _miCaptureSelectedObject.Checked = true;
                    _miCaptureStopCapture.Enabled = true;
                    break;
                case CaptureType.MenuUnderCursor:
                    _miCaptureMenuUnderCursor.Checked = true;
                    _miCaptureStopCapture.Enabled = true;
                    break;
                case CaptureType.Area:
                    _miCaptureSelectedArea.Checked = true;
                    _miCaptureStopCapture.Enabled = true;
                    break;
                case CaptureType.WallPaper:
                    _miCaptureWallpaper.Checked = true;
                    _miCaptureStopCapture.Enabled = true;
                    break;
                case CaptureType.MouseCursor:
                    _miCaptureMouseCursor.Checked = true;
                    _miCaptureStopCapture.Enabled = true;
                    break;
                case CaptureType.WindowUnderCursor:
                    _miCaptureWindowUnderCursor.Checked = true;
                    _miCaptureStopCapture.Enabled = true;
                    break;
                default:
                    _miCaptureStopCapture.Enabled = false;
                    break;
            }
        }

        private void UpdateStatusBarText()
        {
            // update the status bar text
            switch (_captureType)
            {
                case CaptureType.ActiveWindow:
                    _sbiText.Text = DemosGlobalization.GetResxString(GetType(), "Resx_CaptureActiveWindow");
                    break;
                case CaptureType.ActiveClient:
                    _sbiText.Text = DemosGlobalization.GetResxString(GetType(), "Resx_CaptureActiveClient");
                    break;
                case CaptureType.FullScreen:
                    _sbiText.Text = DemosGlobalization.GetResxString(GetType(), "Resx_CaptureFullScreen");
                    break;
                case CaptureType.SelectedObject:
                    _sbiText.Text = DemosGlobalization.GetResxString(GetType(), "Resx_CaptureSelectedObject");
                    break;
                case CaptureType.MenuUnderCursor:
                    _sbiText.Text = DemosGlobalization.GetResxString(GetType(), "Resx_CaptureMenuUnderCursor");
                    break;
                case CaptureType.Area:
                    _sbiText.Text = DemosGlobalization.GetResxString(GetType(), "Resx_CaptureSelectedArea");
                    break;
                case CaptureType.WallPaper:
                    _sbiText.Text = DemosGlobalization.GetResxString(GetType(), "Resx_CaptureWallpaper");
                    break;
                case CaptureType.MouseCursor:
                    _sbiText.Text = DemosGlobalization.GetResxString(GetType(), "Resx_CaptureMouseCursor");
                    break;
                case CaptureType.WindowUnderCursor:
                    _sbiText.Text = DemosGlobalization.GetResxString(GetType(), "Resx_CaptureWindowsUnderCursor");
                    break;
                case CaptureType.FromExeTab:
                    _sbiText.Text = DemosGlobalization.GetResxString(GetType(), "Resx_CaptureEXEFileTabbed");
                    break;
                case CaptureType.FromExeTree:
                    _sbiText.Text = DemosGlobalization.GetResxString(GetType(), "Resx_CaptureEXEFileTree");
                    break;
                default:
                    _sbiText.Text = DemosGlobalization.GetResxString(GetType(), "Resx_NoCapture");
                    break;
            }
        }

        /// <summary>
        /// Saves the image
        /// </summary>
        /// <returns>True if the image is saved successfully, false otherwise.</returns>
        public bool SaveAs()
        {
            _miFileSaveAs_Click(this, null);
            return _isImageSaved;
        }

        // *********
        // FILE MENU
        // *********

        // File Menu - Exit
        private void _miFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // File Menu - SaveAs
        private void _miFileSaveAs_Click(object sender, EventArgs e)
        {
            ImageFileSaver saver = new ImageFileSaver();
            _isImageSaved = false;

            try
            {
                CapturedImageForm activeForm = ActiveCapturedImageForm;
                saver.Save(this, _codecs, activeForm.Viewer.Image);
                _isImageSaved = true;
            }
            catch (Exception ex)
            {
                Messager.ShowFileSaveError(this, saver.FileName, ex);
                _isImageSaved = false;
            }
        }

        // ************
        // OPTIONS MENU
        // ************

        // Options Menu - Minimize Application On Capture
        private void _miOptionsMinimizeApplicationOnCapture_Click(object sender, EventArgs e)
        {
            _minimizeOnCapture = !_minimizeOnCapture;
            _miOptionsMinimizeApplicationOnCapture.Checked = !_miOptionsMinimizeApplicationOnCapture.Checked;
        }

        // Options Menu - Activate Application After Capture
        private void _miOptionsActivateApplicationAfterCapture_Click(object sender, EventArgs e)
        {
            _activateAfterCapture = !_activateAfterCapture;
            _miOptionsActivateApplicationAfterCapture.Checked = !_miOptionsActivateApplicationAfterCapture.Checked;
        }

        // Options Menu - Beep On Capture
        private void _miOptionsBeepOnCapture_Click(object sender, EventArgs e)
        {
            _isBeepOn = !_isBeepOn;
            _miOptionsBeepOnCapture.Checked = !_miOptionsBeepOnCapture.Checked;
        }

        // Options Menu - Capture Options ...
        private void _miOptionsCaptureOptions_Click(object sender, EventArgs e)
        {
            if (_captureType != CaptureType.None)
            {
                _captureType = CaptureType.None;
                _engine.StopCapture();
                UpdateMyControls();
                UpdateStatusBarText();
            }

            try
            {
                _options = _engine.ShowCaptureOptionsDialog(this, ScreenCaptureDialogFlags.None, _options, null);
                _engine.CaptureOptions = _options;
                _isHotKeyEnabled = (_options.Hotkey == Keys.None) ? false : true;
            }
            catch (Exception ex)
            {
                if (ex.Message != "UserAbort" && ex.Message != "User has aborted operation")
                    Messager.ShowError(this, ex);
            }
        }

        // Options - Capture Area Options ...
        private void _miOptionsCaptureAreaOptions_Click(object sender, EventArgs e)
        {
            if (_captureType != CaptureType.None)
            {
                _captureType = CaptureType.None;
                _engine.StopCapture();
                UpdateMyControls();
                UpdateStatusBarText();
            }

            try
            {
                _areaOptions = _engine.ShowCaptureAreaOptionsDialog(this, ScreenCaptureDialogFlags.None, _areaOptions, false, null);
            }
            catch (Exception ex)
            {
                if (ex.Message != "UserAbort" && ex.Message != "User has aborted operation")
                    Messager.ShowError(this, ex);
            }
        }

        // Options - Capture Object Options ...
        private void _miOptionsCaptureObjectOptions_Click(object sender, EventArgs e)
        {
            if (_captureType != CaptureType.None)
            {
                _captureType = CaptureType.None;
                _engine.StopCapture();
                UpdateMyControls();
                UpdateStatusBarText();
            }

            try
            {
                _objectOptions = _engine.ShowCaptureObjectOptionsDialog(this, ScreenCaptureDialogFlags.None, _objectOptions, false, null);
            }
            catch (Exception ex)
            {
                if (ex.Message != "UserAbort" && ex.Message != "User has aborted operation")
                    Messager.ShowError(this, ex);
            }
        }

        // *********
        // VIEW MENU
        // *********
        // View Menu - StatusBar
        private void _miViewStatusBar_Click(object sender, EventArgs e)
        {
            _miViewStatusBar.Checked = !_miViewStatusBar.Checked;
            _sbMain.Visible = !_sbMain.Visible;
            UpdateStatusBarText();
        }

        // *********
        // EDIT MENU
        // *********

        // Edit Menu - Cut
        private void _miEditCut_Click(object sender, EventArgs e)
        {
            _miEditCopy_Click(sender, e);
            CapturedImageForm capturedImageForm = ActiveCapturedImageForm;
            _cutImage = true;
            capturedImageForm.Close();
            _cutImage = false;
        }

        // Edit Menu - Copy
        private void _miEditCopy_Click(object sender, EventArgs e)
        {
            CapturedImageForm capturedImageForm = ActiveCapturedImageForm;

            try
            {
                using (WaitCursor wait = new WaitCursor())
                {
                    RasterClipboard.Copy(
                       this.Handle,
                       capturedImageForm.Viewer.Image,
                       RasterClipboardCopyFlags.Empty |
                       RasterClipboardCopyFlags.Dib |
                       RasterClipboardCopyFlags.Palette |
                       RasterClipboardCopyFlags.Region);
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

        // *********
        // HELP MENU
        // *********

        // Help Menu - About
        private void _miHelpAbout_Click(object sender, EventArgs e)
        {
#if LEADTOOLS_V19_OR_LATER
           using (AboutDialog aboutDialog = new AboutDialog("Screen Capture", ProgrammingInterface.CS))
              aboutDialog.ShowDialog(this);
#else
         using (AboutDialog aboutDialog = new AboutDialog("Screen Capture"))
            aboutDialog.ShowDialog(this);
#endif
        }

        // ************
        // CAPTURE MENU
        // ************

        // Capture Menu - Capture Active Window
        private void _miCaptureActiveWindow_Click(object sender, EventArgs e)
        {
            DoCapture(CaptureType.ActiveWindow);
        }

        // Capture Menu - Capture Active Client
        private void _miCaptureActiveClient_Click(object sender, EventArgs e)
        {
            DoCapture(CaptureType.ActiveClient);
        }

        // Capture Menu - Capture Full Screen
        private void _miCaptureFullScreen_Click(object sender, EventArgs e)
        {
            DoCapture(CaptureType.FullScreen);
        }

        // Capture Menu - Capture Selected Object
        private void _miCaptureSelectedObject_Click(object sender, EventArgs e)
        {
            DoCapture(CaptureType.SelectedObject);
        }

        // Capture Menu - Capture Menu Under Cursor
        private void _miCaptureMenuUnderCursor_Click(object sender, EventArgs e)
        {
            DoCapture(CaptureType.MenuUnderCursor);
        }

        // Capture Menu - Capture Selected Area
        private void _miCaptureSelectedArea_Click(object sender, EventArgs e)
        {
            DoCapture(CaptureType.Area);
        }

        // Capture Menu - Capture Wallpaper
        private void _miCaptureWallpaper_Click(object sender, EventArgs e)
        {
            DoCapture(CaptureType.WallPaper);
        }

        // Capture Menu - Capture Mouse Cursor
        private void _miCaptureMouseCursor_Click(object sender, EventArgs e)
        {
            DoCapture(CaptureType.MouseCursor);
        }

        // Capture Menu - Capture Window Under Cursor
        private void _miCaptureWindowUnderCursor_Click(object sender, EventArgs e)
        {
            DoCapture(CaptureType.WindowUnderCursor);
        }

        private void DoCapture(CaptureType captureType)
        {
            if (_isHotKeyEnabled)
                if (_captureType == captureType)
                    return;

            _captureType = captureType;
            _engine.StopCapture();
            UpdateMyControls();
            UpdateStatusBarText();

            string hotkeyMsg = string.Format(DemosGlobalization.GetResxString(GetType(), "Resx_ActiveCapture"), _options.Hotkey.ToString());
            MessageBox.Show(hotkeyMsg);

            if (_minimizeOnCapture)
            {
                _previousWindowState = this.WindowState;
                this.WindowState = FormWindowState.Minimized;
            }

            try
            {
                switch (captureType)
                {
                    case CaptureType.ActiveWindow:
                        do
                        {
                            RasterImage image = null;
                            try
                            {
                                image = _engine.CaptureActiveWindow(_captureInformation);
                            }
                            catch (RasterException ex)
                            {
                                if (ex.Message == "UserAbort" || ex.Message == "User has aborted operation")
                                {
                                    _captureType = CaptureType.None;
                                }
                            }
                            if (image == null)
                                _captureType = CaptureType.None;
                            else
                                _isHotKeyEnabled = false;
                            UpdateMyControls();
                        } while ((_captureType == CaptureType.ActiveWindow) && (_isHotKeyEnabled));
                        break;

                    case CaptureType.ActiveClient:
                        do
                        {
                            RasterImage image = null;
                            try
                            {
                                image = _engine.CaptureActiveClient(_captureInformation);
                            }
                            catch (RasterException ex)
                            {
                                if (ex.Message == "UserAbort" || ex.Message == "User has aborted operation")
                                {
                                    _captureType = CaptureType.None;
                                }
                            }
                            if (image == null)
                                _captureType = CaptureType.None;
                            UpdateMyControls();
                        } while ((_captureType == CaptureType.ActiveClient) && (_isHotKeyEnabled));
                        break;

                    case CaptureType.FullScreen:
                        do
                        {
                            RasterImage image = null;
                            try
                            {
                                image = _engine.CaptureFullScreen(_captureInformation);
                            }
                            catch (RasterException ex)
                            {
                                if (ex.Message == "UserAbort" || ex.Message == "User has aborted operation")
                                {
                                    _captureType = CaptureType.None;
                                }
                            }
                            if (image == null)
                                _captureType = CaptureType.None;
                            UpdateMyControls();
                        } while ((_captureType == CaptureType.FullScreen) && (_isHotKeyEnabled));
                        break;

                    case CaptureType.SelectedObject:
                        do
                        {
                            RasterImage image = null;
                            try
                            {
                                image = _engine.CaptureSelectedObject(_objectOptions, _captureInformation);
                            }
                            catch (RasterException ex)
                            {
                                if (ex.Message == "UserAbort" || ex.Message == "User has aborted operation")
                                {
                                    _captureType = CaptureType.None;
                                }
                            }
                            if (image == null)
                                _captureType = CaptureType.None;
                            UpdateMyControls();
                        } while ((_captureType == CaptureType.SelectedObject) && (_isHotKeyEnabled));
                        break;

                    case CaptureType.MenuUnderCursor:
                        do
                        {
                            RasterImage image = null;
                            try
                            {
                                image = _engine.CaptureMenuUnderCursor(_captureInformation);
                            }
                            catch (RasterException ex)
                            {
                                if (ex.Message == "UserAbort" || ex.Message == "User has aborted operation")
                                {
                                    _captureType = CaptureType.None;
                                }
                            }
                            if (image == null)
                                _captureType = CaptureType.None;
                            UpdateMyControls();
                        } while ((_captureType == CaptureType.MenuUnderCursor) && (_isHotKeyEnabled));
                        break;

                    case CaptureType.Area:
                        do
                        {
                            RasterImage image = null;
                            try
                            {
                                image = _engine.CaptureArea(_areaOptions, _captureInformation);
                            }
                            catch (RasterException ex)
                            {
                                if (ex.Message == "UserAbort" || ex.Message == "User has aborted operation")
                                {
                                    _captureType = CaptureType.None;
                                }
                            }
                            if (image == null)
                                _captureType = CaptureType.None;
                            UpdateMyControls();
                        } while ((_captureType == CaptureType.Area) && (_isHotKeyEnabled));
                        break;

                    case CaptureType.WallPaper:
                        do
                        {
                            RasterImage image = null;
                            try
                            {
                                image = _engine.CaptureWallpaper(_captureInformation);
                            }
                            catch (RasterException ex)
                            {
                                if (ex.Message == "UserAbort" || ex.Message == "User has aborted operation")
                                {
                                    _captureType = CaptureType.None;
                                }
                            }
                            if (image == null)
                                _captureType = CaptureType.None;
                            UpdateMyControls();
                        } while ((_captureType == CaptureType.WallPaper) && (_isHotKeyEnabled));
                        break;

                    case CaptureType.MouseCursor:
                        do
                        {
                            RasterImage image = null;
                            try
                            {
                                image = _engine.CaptureMouseCursor(Color.Yellow, _captureInformation);
                            }
                            catch (RasterException ex)
                            {
                                if (ex.Message == "UserAbort" || ex.Message == "User has aborted operation")
                                {
                                    _captureType = CaptureType.None;
                                }
                            }
                            if (image == null)
                                _captureType = CaptureType.None;
                            UpdateMyControls();
                        } while ((_captureType == CaptureType.MouseCursor) && (_isHotKeyEnabled));
                        break;

                    case CaptureType.WindowUnderCursor:
                        do
                        {
                            RasterImage image = null;
                            try
                            {
                                image = _engine.CaptureWindowUnderCursor(_captureInformation);
                            }
                            catch (RasterException ex)
                            {
                                if (ex.Message == "UserAbort" || ex.Message == "User has aborted operation")
                                {
                                    _captureType = CaptureType.None;
                                }
                            }
                            if (image == null)
                                _captureType = CaptureType.None;
                            UpdateMyControls();
                        } while ((_captureType == CaptureType.WindowUnderCursor) && (_isHotKeyEnabled));
                        break;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message != "NoImage" && ex.Message != "UserAbort" && ex.Message != "Invalid image" &&
                   ex.Message != "User has aborted operation" && ex.Message != "No menu")
                    Messager.ShowError(this, ex);

                _captureType = CaptureType.None;
                UpdateMyControls();
                UpdateStatusBarText();

                if (_minimizeOnCapture)
                    this.WindowState = _previousWindowState;
            }
        }

        // Capture Menu - Stop Capture
        private void _miCaptureStopCapture_Click(object sender, EventArgs e)
        {
            _captureType = CaptureType.None;
            _engine.StopCapture();
            UpdateMyControls();
            UpdateStatusBarText();
        }

        // Capture Menu - Capture From Exe Dialog - Tree View
        private void _miCaptureFromExeDialogTree_Click(object sender, EventArgs e)
        {
            _captureType = CaptureType.FromExeTree;
            _engine.StopCapture();
            UpdateMyControls();
            UpdateStatusBarText();

            try
            {
                RasterImage image = _engine.ShowCaptureFromExeDialog(String.Empty, Color.Transparent, ScreenCaptureResourceType.Icon | ScreenCaptureResourceType.Cursor | ScreenCaptureResourceType.Bitmap, ScreenCaptureFromExeDialogType.TreeView, ScreenCaptureDialogFlags.None, _captureInformation, null);
                if (image == null)
                    _captureType = CaptureType.None;
                UpdateMyControls();
            }
            catch (Exception ex)
            {
                Messager.ShowError(this, ex);
            }

            _captureType = CaptureType.None;
            UpdateStatusBarText();
        }

        // Capture Menu - Capture From Exe Dialog - Tabbed View
        private void _miCaptureFromExeDialogTabbedView_Click(object sender, EventArgs e)
        {
            _captureType = CaptureType.FromExeTab;
            _engine.StopCapture();
            UpdateMyControls();
            UpdateStatusBarText();

            try
            {
                RasterImage image = _engine.ShowCaptureFromExeDialog(String.Empty, Color.Transparent, ScreenCaptureResourceType.Icon | ScreenCaptureResourceType.Cursor | ScreenCaptureResourceType.Bitmap, ScreenCaptureFromExeDialogType.TabView, ScreenCaptureDialogFlags.None, _captureInformation, null);
                if (image == null)
                    _captureType = CaptureType.None;
                UpdateMyControls();
            }
            catch (Exception ex)
            {
                Messager.ShowError(this, ex);
            }

            _captureType = CaptureType.None;
            UpdateStatusBarText();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (_captureType != CaptureType.None)
            {
                _captureType = CaptureType.None;
                _engine.StopCapture();
                UpdateMyControls();
                UpdateStatusBarText();
            }
        }
    }
}
