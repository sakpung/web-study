// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools.Wia;

namespace PrintToPACSDemo
{
   public partial class AcquireOptionsForm : Form
   {
      public AcquireOptionsForm()
      {
         InitializeComponent();
      }

      private void AcquireOptionsForm_Load(object sender, EventArgs e)
      {
         InitializeAcquireOptionsDlg();
      }

      public void InitializeAcquireOptionsDlg()
      {
         // if the WIA 2.0 version is selected and the Show UserInterface option is on
         // then in this case WIA 2.0 will only work as TYMED_FILE, so we need to set the 
         // transfer mode to TYMED_FILE
         if (FrmMain._wiaVersion == WiaVersion.Version2 && FrmMain._showUserInterface)
         {
            FrmMain._wiatransferMode = WiaTransferMode.File;
         }
         else
         {
            // Get the transfer mode selected in the properties dialog and set it as the default mode.
            if (FrmMain._wiaProperties.DataTransfer.TransferMode != WiaTransferMode.None) // GetProperties() method already called.
            {
               FrmMain._wiatransferMode = FrmMain._wiaProperties.DataTransfer.TransferMode;
            }
            else
            {
               FrmMain._wiatransferMode = WiaTransferMode.Memory;
            }
         }

         if (FrmMain._wiatransferMode == WiaTransferMode.Memory)
            _rdMemoryMode.Checked = true;
         else
            _rdFileMode.Checked = true;

         if (FrmMain._wiaVersion == WiaVersion.Version2 && FrmMain._showUserInterface)
         {
            _rdMemoryMode.Enabled = false;
         }
         else
         {
            _rdMemoryMode.Enabled = true;
         }

         // Set the file name (if available).
         if (!String.IsNullOrEmpty(FrmMain._wiaAcquireOptions.FileName))
         {
            _tbFileName.Text = FrmMain._wiaAcquireOptions.FileName;
         }
         else
         {
            _tbFileName.Text = FrmMain._wiaAcquireOptions.FileName;
         }

         _cbSaveToOneFile.Checked = FrmMain._wiaAcquireOptions.SaveToOneFile;
         _cbOverwriteExisting.Checked = FrmMain._wiaAcquireOptions.OverwriteExisting;
         _cbAppendToFile.Checked = FrmMain._wiaAcquireOptions.Append;
         _cbEnableDoubleBuffer.Checked = FrmMain._wiaAcquireOptions.DoubleBuffer;

         _numMemoryBufferSize.Value = FrmMain._wiaAcquireOptions.MemoryBufferSize;
         UpdateDlgControls();
      }

      private void _btnBrowse_Click(object sender, EventArgs e)
      {
         BrowseFile();
      }

      public void BrowseFile()
      {
         string filter = string.Empty;
         string extension = string.Empty;

         SaveFileDialog dlg = new SaveFileDialog();

         HelperFunctions.GetFormatFilterAndExtension();

         dlg.Filter = HelperFunctions.Filter;
         dlg.DefaultExt = HelperFunctions.Extension;
         dlg.Title = "Save File";
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            _tbFileName.Text = dlg.FileName;
         }
      }

      public void UpdateDlgControls()
      {
         bool bMemMode = true;

         // Enable/Disable the File Mode options
         if (_rdMemoryMode.Checked)
         {
            bMemMode = true;
         }
         else
         {
            bMemMode = false;
         }

         // Disable all the controls that are related to file transfer mode
         EnableFileModeOptionsControls(!bMemMode);

         // Enable the memory buffer size and double buffer controls.
         _numMemoryBufferSize.Enabled = bMemMode;
         _cbEnableDoubleBuffer.Enabled = bMemMode;

         // Check if the file name field or buffer size fields are empty then disable the "OK" button.
         if ( (String.IsNullOrEmpty(_tbFileName.Text) && (bMemMode == false) ) ||
            (String.IsNullOrEmpty(_tbFileName.Text)) || (String.IsNullOrEmpty(_numMemoryBufferSize.Text)))
         {
            _btnOk.Enabled = false;
         }
         else
         {
            _btnOk.Enabled = true;
         }
      }

      public void EnableFileModeOptionsControls(bool bEnable)
      {
         _lblFileName.Enabled = bEnable;
         _tbFileName.Enabled = bEnable;
         _btnBrowse.Enabled = bEnable;

         if (FrmMain._wiaVersion == WiaVersion.Version2 && FrmMain._showUserInterface)
         {
            _cbSaveToOneFile.Enabled = false;
            _cbOverwriteExisting.Enabled = false;
            _cbAppendToFile.Enabled = false;
         }
         else
         {
            _cbSaveToOneFile.Enabled = bEnable;
            _cbOverwriteExisting.Enabled = bEnable;
            _cbAppendToFile.Enabled = bEnable;

            // Enable the "Save To One File" and "Append To File" buttons if multi-page format selected.
            if (FrmMain._wiaProperties.DataTransfer.Format == WiaFileFormats.Tiff ||
                FrmMain._wiaProperties.DataTransfer.Format == WiaFileFormats.Gif ||
                FrmMain._wiaProperties.DataTransfer.Format == WiaFileFormats.Ico ||
                FrmMain._wiaProperties.DataTransfer.Format == WiaFileFormats.Pdfa ||
                FrmMain._wiaProperties.DataTransfer.Format == WiaFileFormats.Rtf ||
                FrmMain._wiaProperties.DataTransfer.Format == WiaFileFormats.Txt ||
                FrmMain._wiaProperties.DataTransfer.Format == WiaFileFormats.Html)
            {
               _cbSaveToOneFile.Enabled = true;
               _cbAppendToFile.Enabled = true;
            }
            else
            {
               _cbSaveToOneFile.Checked = false;
               _cbAppendToFile.Checked = false;
               _cbSaveToOneFile.Enabled = false;
               _cbAppendToFile.Enabled = false;
            }
         }
      }

      public void SetWiaAcquireOptions()
      {
         // Check for file mode or memory mode
         if (_rdMemoryMode.Checked)
         {
            FrmMain._wiatransferMode = WiaTransferMode.Memory;
         }
         else
         {
            FrmMain._wiatransferMode = WiaTransferMode.File;
         }

         // Check for the user specified file name
         if(FrmMain._wiatransferMode == WiaTransferMode.File)
         {
            FrmMain._wiaAcquireOptions.FileName = _tbFileName.Text;

            // Check for the "Save To One File" option.
            if ( _cbSaveToOneFile.Checked )
            {
               FrmMain._wiaAcquireOptions.SaveToOneFile = true;
            }
            else
            {
               FrmMain._wiaAcquireOptions.SaveToOneFile = false;
            }

            // Check for the "Overwrite existing" option.
            if ( _cbOverwriteExisting.Checked )
            {
               FrmMain._wiaAcquireOptions.OverwriteExisting = true;
            }
            else
            {
               FrmMain._wiaAcquireOptions.OverwriteExisting = false;
            }

            // Check for the "Append To File" option.
            if ( _cbAppendToFile.Checked )
            {
               FrmMain._wiaAcquireOptions.Append = true;
            }
            else
            {
               FrmMain._wiaAcquireOptions.Append = false;
            }
         }

         // Get the memory buffer size
         FrmMain._wiaAcquireOptions.MemoryBufferSize = (int)_numMemoryBufferSize.Value;

         // Check for the "Enable Double Buffer" option.
         if ( _cbEnableDoubleBuffer.Checked )
         {
            FrmMain._wiaAcquireOptions.DoubleBuffer = true;
         }
         else
         {
            FrmMain._wiaAcquireOptions.DoubleBuffer = false;
         }
      }

      private void _rdMemoryMode_Click(object sender, EventArgs e)
      {
         UpdateDlgControls();
      }

      private void _rdFileMode_Click(object sender, EventArgs e)
      {
         UpdateDlgControls();
      }

      private void _tbFileName_TextChanged(object sender, EventArgs e)
      {
         UpdateDlgControls();
      }

      private void _cbOverwriteExisting_Click(object sender, EventArgs e)
      {
         _cbAppendToFile.Checked = false;
      }

      private void _cbAppendToFile_Click(object sender, EventArgs e)
      {
         _cbOverwriteExisting.Checked = false;
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         SetWiaAcquireOptions();
         DialogResult = DialogResult.OK;
      }

      private void _numMemoryBufferSize_Leave(object sender, EventArgs e)
      {
         UpdateDlgControls();
      }
   }
}
