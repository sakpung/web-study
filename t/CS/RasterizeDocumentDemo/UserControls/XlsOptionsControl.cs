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

using Leadtools;
using Leadtools.Codecs;

namespace RasterizeDocumentDemo.UserControls
{
   public partial class XlsOptionsControl : UserControl, IOptionsUserControl
   {
      public XlsOptionsControl()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Called by the owner to initialize
      /// </summary>
      public void SetData(RasterCodecs rasterCodecsInstance)
      {
         // Set the state of the controls

         CodecsXlsLoadOptions xlsLoadOptions = rasterCodecsInstance.Options.Xls.Load;

         _multiPageSheetCheckBox.Checked = xlsLoadOptions.MultiPageSheet;
      }

      /// <summary>
      /// Called by the owner to get the data
      /// </summary>
      public bool GetData(RasterCodecs rasterCodecsInstance)
      {
         CodecsXlsLoadOptions xlsLoadOptions = rasterCodecsInstance.Options.Xls.Load;

         // Get the XLS load settings
         xlsLoadOptions.MultiPageSheet = _multiPageSheetCheckBox.Checked;

         return true;
      }

      private void _resetToDefaultsButton_Click(object sender, EventArgs e)
      {
         _multiPageSheetCheckBox.Checked = false;
      }
   }
}
