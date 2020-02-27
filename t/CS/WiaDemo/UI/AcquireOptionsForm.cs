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
using Leadtools.Demos;

namespace WiaDemo
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
         if (MainForm._wiaVersion == WiaVersion.Version2 && MainForm._showUserInterface)
         {
            MainForm._transferMode = WiaTransferMode.File;
         }
         else
         {
            // Get the transfer mode selected in the properties dialog and set it as the default mode.
            if (MainForm._wiaProperties.DataTransfer.TransferMode != WiaTransferMode.None) // GetProperties() method already called.
            {
               MainForm._transferMode = MainForm._wiaProperties.DataTransfer.TransferMode;
            }
            else
            {
               MainForm._transferMode = WiaTransferMode.Memory;
            }
         }

         if (MainForm._transferMode == WiaTransferMode.Memory)
            _rdMemoryMode.Checked = true;
         else
            _rdFileMode.Checked = true;

         if (MainForm._wiaVersion == WiaVersion.Version2 && MainForm._showUserInterface)
         {
            _rdMemoryMode.Enabled = false;
         }
         else
         {
            _rdMemoryMode.Enabled = true;
         }

         // Set the file name (if available).
         if(!String.IsNullOrEmpty(MainForm._wiaAcquireOptions.FileName))
         {
            _tbFileName.Text = MainForm._wiaAcquireOptions.FileName;
         }
         else
         {
            _tbFileName.Text = MainForm._wiaAcquireOptions.FileName;
         }

         _cbSaveToOneFile.Checked = MainForm._wiaAcquireOptions.SaveToOneFile;
         _cbOverwriteExisting.Checked = MainForm._wiaAcquireOptions.OverwriteExisting;
         _cbAppendToFile.Checked = MainForm._wiaAcquireOptions.Append;
         _cbEnableDoubleBuffer.Checked = MainForm._wiaAcquireOptions.DoubleBuffer;

         _numMemoryBufferSize.Value = MainForm._wiaAcquireOptions.MemoryBufferSize;
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
         dlg.Title = DemosGlobalization.GetResxString(GetType(), "Resx_SaveFile");
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

         if (MainForm._wiaVersion == WiaVersion.Version2 && MainForm._showUserInterface)
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
            if (MainForm._wiaProperties.DataTransfer.Format == WiaFileFormats.Tiff ||
                MainForm._wiaProperties.DataTransfer.Format == WiaFileFormats.Gif ||
                MainForm._wiaProperties.DataTransfer.Format == WiaFileFormats.Ico ||
                MainForm._wiaProperties.DataTransfer.Format == WiaFileFormats.Pdfa ||
                MainForm._wiaProperties.DataTransfer.Format == WiaFileFormats.Rtf ||
                MainForm._wiaProperties.DataTransfer.Format == WiaFileFormats.Txt ||
                MainForm._wiaProperties.DataTransfer.Format == WiaFileFormats.Html)
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
            MainForm._transferMode = WiaTransferMode.Memory;
         }
         else
         {
            MainForm._transferMode = WiaTransferMode.File;
         }

         // Check for the user specified file name
         if(MainForm._transferMode == WiaTransferMode.File)
         {
            MainForm._wiaAcquireOptions.FileName = _tbFileName.Text;

            // Check for the "Save To One File" option.
            if ( _cbSaveToOneFile.Checked )
            {
               MainForm._wiaAcquireOptions.SaveToOneFile = true;
            }
            else
            {
               MainForm._wiaAcquireOptions.SaveToOneFile = false;
            }

            // Check for the "Overwrite existing" option.
            if ( _cbOverwriteExisting.Checked )
            {
               MainForm._wiaAcquireOptions.OverwriteExisting = true;
            }
            else
            {
               MainForm._wiaAcquireOptions.OverwriteExisting = false;
            }

            // Check for the "Append To File" option.
            if ( _cbAppendToFile.Checked )
            {
               MainForm._wiaAcquireOptions.Append = true;
            }
            else
            {
               MainForm._wiaAcquireOptions.Append = false;
            }
         }

         // Get the memory buffer size
         MainForm._wiaAcquireOptions.MemoryBufferSize = (int)_numMemoryBufferSize.Value;

         // Check for the "Enable Double Buffer" option.
         if ( _cbEnableDoubleBuffer.Checked )
         {
            MainForm._wiaAcquireOptions.DoubleBuffer = true;
         }
         else
         {
            MainForm._wiaAcquireOptions.DoubleBuffer = false;
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
