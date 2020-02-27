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

using Leadtools.Ocr;

namespace FormsDemo
{
   public partial class AdvancedSettings : Form
   {      
      public AdvancedSettings(bool compareAllPages, bool useBarcodeManager, bool useDefaultManager, bool useOCRManager)
      {
         InitializeComponent();
         _chkCompareAllPages.Checked = _compareAllPages = compareAllPages;
         _chkBarcodeManager.Checked = _useBarcodeManager = useBarcodeManager;
         _chkDefaultObjectManager.Checked = _useDefaultManager = useDefaultManager;
         _chkOCRManager.Checked = _useOCRManager = useOCRManager;
      }

      private void btnCancel_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
         _compareAllPages = _chkCompareAllPages.Checked;
         _useBarcodeManager = _chkBarcodeManager.Checked;
         _useDefaultManager = _chkDefaultObjectManager.Checked;
         _useOCRManager = _chkOCRManager.Checked;
         DialogResult = DialogResult.OK;
      }

      private bool _compareAllPages;
      public bool CompareAllPages
      {
         get { return _compareAllPages; }
         set { _compareAllPages = value; }
      }

      private bool _useBarcodeManager;
      public bool UseBarcodeManager
      {
         get { return _useBarcodeManager; }
         set { _useBarcodeManager = value; }
      }

      private bool _useDefaultManager;
      public bool UseDefaultManager
      {
         get { return _useDefaultManager; }
         set { _useDefaultManager = value; }
      }

      private bool _useOCRManager;
      public bool UseOCRManager
      {
         get { return _useOCRManager; }
         set { _useOCRManager = value; }
      }
   }
}
