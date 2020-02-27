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

namespace OcrTwainScanningDemo
{
   public partial class OcrEngineSettingsDialog : Form
   {
      public OcrEngineSettingsDialog(IOcrEngine ocrEngine)
      {
         InitializeComponent();
         _ocrEngineSettings.SetEngine(ocrEngine);
      }
   }
}
