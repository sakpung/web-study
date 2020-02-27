// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Demos;
using System.IO;
using Leadtools;
using Leadtools.Twain;
using Leadtools.Codecs;
using Leadtools.Forms.Common;
using Leadtools.Forms.Auto;

namespace CSMasterFormsEditor.UI
{
   public partial class MasterFormsWizard : Form
   {
      public MasterFormsWizard()
      {
         InitializeComponent();
      }
      RasterImage scannedImage = null;
      private TwainSession twainSession = null;
      
      [STAThread]
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         Boolean bLocked = RasterSupport.IsLocked(RasterSupportType.Forms);
         if (bLocked)
            MessageBox.Show("Forms support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

         Boolean bOCRLocked = RasterSupport.IsLocked(RasterSupportType.OcrLEAD) & RasterSupport.IsLocked(RasterSupportType.OcrOmniPage);
         if (bOCRLocked)
             MessageBox.Show("OCR support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

         if (bLocked | bOCRLocked)
            return;

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MasterFormsWizard());
      }

      private void MasterFormsWizard_Load(object sender, EventArgs e)
      {
         _tbMain.Appearance = TabAppearance.FlatButtons;
         _tbMain.ItemSize = new Size(0, 1);
         _tbMain.SizeMode = TabSizeMode.Fixed;

         if (String.IsNullOrEmpty(Properties.Settings.Default.MasterFormsPath))
         {
            _txtMasterFormsPath.Text = DemosGlobal.ImagesFolder + "\\" + @"Forms\MasterForm Sets";
            _txtPagePath.Text = DemosGlobal.ImagesFolder + "\\" + @"Forms\MasterForm Sets";
            _txtMasterFormsDirectory.Text = DemosGlobal.ImagesFolder + "\\" + @"Forms\MasterForm Sets";
         }
         else
         {
            _txtMasterFormsPath.Text = Properties.Settings.Default.MasterFormsPath;
            _txtPagePath.Text = Properties.Settings.Default.MasterFormsPath;
            _txtMasterFormsDirectory.Text = Properties.Settings.Default.MasterFormsPath;
         }

         _txtMasterFormsName.Text = "NewMasterForm";
      }

      private void _lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         System.Diagnostics.Process.Start("https://www.leadtools.com/videos/playvideo.asp?id=30");
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         if (MessageBox.Show("Are you sure you want to exit?", "Cancel", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
         {
            Application.Exit();
         }
      }

      private void _btnNext_Click(object sender, EventArgs e)
      {
         if (_rdLoad.Checked)
         {
            _tbMain.SelectedTab = _tbMain.TabPages["_tbLoad"];
         }
         else
         {
            _tbMain.SelectedTab = _tbMain.TabPages["_tbCreate"];
         }
      }

      private void _btnNextAbout_Click(object sender, EventArgs e)
      {
         _tbMain.SelectedTab = _tbMain.TabPages["_tbOptions"];
      }

      private void _btnFinish_Click(object sender, EventArgs e)
      {
         if (!Directory.Exists(_txtMasterFormsPath.Text))
         {
            MessageBox.Show("Please select valid folder");
            _txtMasterFormsPath.Focus();
            return;
         }

         InformationDlg infoDlg = new InformationDlg();
         if (infoDlg.ShouldShow())
         {
            infoDlg.ShowDialog();
         }
         
         MainForm frm = new MainForm(_txtMasterFormsPath.Text);
         this.Hide();
         frm.Show();
      }

      private void _btnBrowse_Click(object sender, EventArgs e)
      {
         using (FolderBrowserDialogEx browseDlg = new FolderBrowserDialogEx())
         {
            browseDlg.ShowNewFolderButton = false;
            browseDlg.ShowEditBox = true;
            browseDlg.ShowFullPathInEditBox = true;
            browseDlg.ShowNewFolderButton = false;
            browseDlg.Description = "Select Master Forms Path";
            browseDlg.RootFolder = Environment.SpecialFolder.MyComputer;
            browseDlg.SelectedPath = _txtMasterFormsPath.Text;
            if (browseDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               _txtMasterFormsPath.Text = browseDlg.SelectedPath;
            }
         }
      }
      
      private void _btnBrowsePage_Click(object sender, EventArgs e)
      {
         using (OpenFileDialog dlg = new OpenFileDialog())
         {
            dlg.CheckFileExists = true;
            if (String.IsNullOrEmpty(Properties.Settings.Default.MasterFormsPath))
            {
               dlg.InitialDirectory = DemosGlobal.ImagesFolder + "\\" + @"Forms\MasterForm Sets";
            }
            else
            {
               dlg.InitialDirectory = Properties.Settings.Default.MasterFormsPath;
            }

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               _txtPagePath.Text = dlg.FileName;
            }
         }
      }

      private void UpdateControls()
      {
         _txtPagePath.Visible = _rdFromDisk.Checked;
         _btnBrowsePage.Visible = _rdFromDisk.Checked;
         _lblImagePath.Visible = _rdFromDisk.Checked;
         _btnAcquirePage.Visible = _rdFromScanner.Checked;
      }

      private void _rdFromDisk_CheckedChanged(object sender, EventArgs e)
      {
         UpdateControls();
      }

      private void _rdFromScanner_CheckedChanged(object sender, EventArgs e)
      {
         UpdateControls();
      }

      private void _btnNextCreate_Click(object sender, EventArgs e)
      {
         if (String.IsNullOrEmpty(_txtMasterFormsName.Text))
         {
            MessageBox.Show("Master forms name can not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtMasterFormsName.Focus();
            return;
         }

         if (String.IsNullOrEmpty(_txtMasterFormsDirectory.Text))
         {
            MessageBox.Show("Please select a valid master forms directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _txtMasterFormsDirectory.Focus();
            return;
         }

         if (!Directory.Exists(_txtMasterFormsDirectory.Text))
         {
            try
            {
               Directory.CreateDirectory(_txtMasterFormsDirectory.Text);
            }
            catch (Exception exp)
            {
               Messager.ShowError(this, exp);
               _txtMasterFormsDirectory.Focus();
               return;
            }
         }

         if (!IsFormsNameValid())
         {
            _txtMasterFormsName.Focus();
            return;
         }
         
         _tbMain.SelectedTab = _tbMain.TabPages["_tbAddPage"];
      }
      private bool IsFormsNameValid()
      {
         IMasterFormsCategory parentCategory = null;

         DiskMasterFormsRepository workingRepository = new DiskMasterFormsRepository(new RasterCodecs(), _txtMasterFormsDirectory.Text);
         parentCategory = workingRepository.RootCategory;

         //Build array of current form names
         string[] existingForms = new string[parentCategory.MasterForms.Count];
         for (int i = 0; i < parentCategory.MasterForms.Count; i++)
            existingForms[i] = parentCategory.MasterForms[i].Name;

         foreach (string existingForm in existingForms)
         {
            if (existingForm.ToUpper() == _txtMasterFormsName.Text.Trim().ToUpper())
            {
               MessageBox.Show("That Master Forms already exist", "Error");
               return false;
            }
         }
         return true;
      }

      private void _btnAcquirePage_Click(object sender, EventArgs e)
      {
         if (scannedImage != null)
         {
            scannedImage.Dispose();
            scannedImage = null;
         }

         try
         {
            Messager.Show(this, "For best results, scan at 150DPI (or higher) and 1 bits per pixel", MessageBoxIcon.Information, MessageBoxButtons.OK);

            StartupTwain();

            if (!DemosGlobal.CheckKnown3rdPartyTwainIssues(this, twainSession.SelectedSourceName()))
               return;

            if (twainSession.SelectSource(String.Empty) == DialogResult.OK)
            {
               twainSession.Acquire(TwainUserInterfaceFlags.Show);
            }

            if (twainSession != null)
            {
               twainSession.Shutdown();
            }
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void StartupTwain()
      {
         try
         {
            twainSession = new TwainSession();
            if (TwainSession.IsAvailable(this.Handle))
            {
               twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
               twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(twainSession_AcquirePage);
            }
         }
         catch (TwainException ex)
         {
            if (ex.Code == TwainExceptionCode.InvalidDll)
            {
               twainSession = null;
               Messager.ShowError(this, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org");
            }
            else
            {
               twainSession = null;
               Messager.ShowError(this, ex);
            }
         }
         catch (Exception ex)
         {
            Messager.ShowError(this, ex);
            twainSession = null;
         }
      }

      void twainSession_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         if (scannedImage == null)
            scannedImage = e.Image.Clone();
         else
            scannedImage.AddPage(e.Image.Clone());
      }

      private void _btnFinishCreate_Click(object sender, EventArgs e)
      {
         try
         {
            if (_rdFromDisk.Checked)
            {
               using (RasterCodecs codecs = new RasterCodecs())
               {
                  codecs.Options.Load.Resolution = 300;
                  codecs.Options.RasterizeDocument.Load.Resolution = 300;
                  scannedImage = codecs.Load(_txtPagePath.Text);
               }
            }

            if (scannedImage == null)
            {
               MessageBox.Show("Please add a valid image");
               return;
            }

            FormsPageType pageType = FormsPageType.Normal;

            if (_rbNormal.Checked)
                pageType = FormsPageType.Normal;
            else if (_rbIDCard.Checked)
                pageType = FormsPageType.IDCard;
            else if (_rbOmr.Checked)
                pageType = FormsPageType.Omr;

            MainForm frm = new MainForm(scannedImage.CloneAll(), _txtMasterFormsName.Text, _txtMasterFormsDirectory.Text, pageType);
            scannedImage.Dispose();
            scannedImage = null;
            this.Hide();
            frm.Show();
         }
         catch (Exception exp)
         {
            Messager.ShowError(this, exp);
         }
      }

      private void _btnMasterDirectory_Click(object sender, EventArgs e)
      {
         using (FolderBrowserDialogEx browseDlg = new FolderBrowserDialogEx())
         {
            browseDlg.ShowNewFolderButton = true;
            browseDlg.ShowEditBox = true;
            browseDlg.ShowFullPathInEditBox = true;
            browseDlg.Description = "Select Master Forms Directory";
            browseDlg.RootFolder = Environment.SpecialFolder.MyComputer;
            browseDlg.SelectedPath = _txtMasterFormsDirectory.Text;
            if (browseDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
               _txtMasterFormsDirectory.Text = browseDlg.SelectedPath;
            }
         }
      }

      private void _btnPrevOptions_Click(object sender, EventArgs e)
      {
         _tbMain.SelectedTab = _tbMain.TabPages["_tbAboutDemo"];
      }
      
      private void _btnPrevCreate_Click(object sender, EventArgs e)
      {
         _tbMain.SelectedTab = _tbMain.TabPages["_tbOptions"];
      }

      private void _btnPrevAddPage_Click(object sender, EventArgs e)
      {
         if (scannedImage != null)
         {
            scannedImage.Dispose();
            scannedImage = null;
         }
         
         UpdateControls();

         _tbMain.SelectedTab = _tbMain.TabPages["_tbCreate"];
      }

      private void _btnPrevLoad_Click(object sender, EventArgs e)
      {
         _tbMain.SelectedTab = _tbMain.TabPages["_tbOptions"];
      }

      private void MasterFormsWizard_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (scannedImage != null)
         {
            scannedImage.Dispose();
            scannedImage = null;
         }
      }
   }
}
