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

namespace OcrDemo
{
   public partial class EngineSettingsDialog : Form
   {
      public EngineSettingsDialog(IOcrEngine ocrEngine)
      {
         InitializeComponent();

         _ocrEngineSettingsControl.SetEngine(ocrEngine);
      }
   }
}
