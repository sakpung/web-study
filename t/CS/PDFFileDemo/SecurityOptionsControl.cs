// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Leadtools.Pdf;

namespace PDFFileDemo
{
   public partial class SecurityOptionsControl : UserControl
   {
      private PDFCompatibilityLevel _compatibilityLevel;

      public SecurityOptionsControl()
      {
         InitializeComponent();

         // -1 to leave space for the null terminated character
         _ownerPasswordTextBox.MaxLength = PDFDocument.MaximumPasswordLength - 1;
         _userPasswordTextBox.MaxLength = PDFDocument.MaximumPasswordLength - 1;

         foreach(PDFEncryptionMode mode in Enum.GetValues(typeof(PDFEncryptionMode)))
         {
            _ecnryptionModeComboBox.Items.Add(mode);
         }
      }
      public void SetCompatibilityLevel(PDFCompatibilityLevel CompatibilityLevel)
      {
         _compatibilityLevel = CompatibilityLevel;
         UpdateUIState();
      }
     
      public void SetSecurityOptions(PDFSecurityOptions securityOptions)
      {
         _ownerPasswordTextBox.Text = securityOptions.OwnerPassword;
         _userPasswordTextBox.Text = securityOptions.UserPassword;
         _printEnabledCheckBox.Checked = securityOptions.PrintEnabled;
         _highQualityPrintEnabledCheckBox.Checked = securityOptions.HighQualityPrintEnabled;
         _copyEnabledCheckBox.Checked = securityOptions.CopyEnabled;
         _editEnabledCheckBox.Checked = securityOptions.EditEnabled;
         _annotationsEnabledCheckBox.Checked = securityOptions.AnnotationsEnabled;
         _assemblyEnabledCheckBox.Checked = securityOptions.AssemblyEnabled;
         _ecnryptionModeComboBox.SelectedItem = securityOptions.EncryptionMode;

         UpdateUIState();
      }

      public void UpdateSecurityOptions(PDFSecurityOptions securityOptions)
      {
         securityOptions.OwnerPassword = _ownerPasswordTextBox.Text;
         securityOptions.UserPassword = _userPasswordTextBox.Text;
         securityOptions.PrintEnabled = _printEnabledCheckBox.Checked;
         securityOptions.HighQualityPrintEnabled = _highQualityPrintEnabledCheckBox.Checked;
         securityOptions.CopyEnabled = _copyEnabledCheckBox.Checked;
         securityOptions.EditEnabled = _editEnabledCheckBox.Checked;
         securityOptions.AnnotationsEnabled = _annotationsEnabledCheckBox.Checked;
         securityOptions.AssemblyEnabled = _assemblyEnabledCheckBox.Checked;
         securityOptions.EncryptionMode = (PDFEncryptionMode)_ecnryptionModeComboBox.SelectedItem;
      }

      private void _ecnryptionModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void UpdateUIState()
      {
         bool highQualityPrintEnabled = true;
         if (_compatibilityLevel == PDFCompatibilityLevel.PDF12 || _compatibilityLevel == PDFCompatibilityLevel.PDF13)
         {
            _ecnryptionModeComboBox.Items.Remove(PDFEncryptionMode.RC128Bit);
            _ecnryptionModeComboBox.SelectedIndex = 0;
         }
         else if (!_ecnryptionModeComboBox.Items.Contains(PDFEncryptionMode.RC128Bit))
            _ecnryptionModeComboBox.Items.Add(PDFEncryptionMode.RC128Bit);

         if(_ecnryptionModeComboBox.SelectedItem != null)
         {
            PDFEncryptionMode encryptionMode = (PDFEncryptionMode)_ecnryptionModeComboBox.SelectedItem;
            highQualityPrintEnabled = (encryptionMode == PDFEncryptionMode.RC128Bit);
         }

         if(!_printEnabledCheckBox.Checked)
         {
            highQualityPrintEnabled = false;
         }

         _highQualityPrintEnabledCheckBox.Enabled = highQualityPrintEnabled;

         if(_editEnabledCheckBox.Checked)
         {
            _assemblyEnabledCheckBox.Checked = true;
            _assemblyEnabledCheckBox.Enabled = false;
         }
         else
         {
            _assemblyEnabledCheckBox.Enabled = true;
         }
      }

      private void _printEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }

      private void _editEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         UpdateUIState();
      }
   }
}
