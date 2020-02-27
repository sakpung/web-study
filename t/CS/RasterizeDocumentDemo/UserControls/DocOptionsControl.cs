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
   public partial class DocOptionsControl : UserControl, IOptionsUserControl
   {
      public DocOptionsControl()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Called by the owner to initialize
      /// </summary>
      public void SetData(RasterCodecs rasterCodecsInstance)
      {
         // First fill the controls with possible values
         _bitDepthComboBox.Items.Add(new Tools.ValueNameItem<int>(1, "1 bits per pixel"));
         _bitDepthComboBox.Items.Add(new Tools.ValueNameItem<int>(4, "4 bits per pixel"));
         _bitDepthComboBox.Items.Add(new Tools.ValueNameItem<int>(8, "8 bits per pixel"));
         _bitDepthComboBox.Items.Add(new Tools.ValueNameItem<int>(24, "24 bits per pixel"));

         // Now set the state of the controls
         CodecsDocLoadOptions docLoadOptions = rasterCodecsInstance.Options.Doc.Load;
         _bitDepthComboBox.SelectedItem = Tools.ValueNameItem<int>.SelectItem(docLoadOptions.BitsPerPixel, _bitDepthComboBox.Items);
      }

      /// <summary>
      /// Called by the owner to get the data
      /// </summary>
      public bool GetData(RasterCodecs rasterCodecsInstance)
      {
         CodecsDocLoadOptions docLoadOptions = rasterCodecsInstance.Options.Doc.Load;

         // Get the Doc load settings
         docLoadOptions.BitsPerPixel = Tools.ValueNameItem<int>.GetSelectedItem(_bitDepthComboBox.SelectedItem);

         return true;
      }

      private void _resetToDefaultsButton_Click(object sender, EventArgs e)
      {
         _bitDepthComboBox.SelectedItem = Tools.ValueNameItem<int>.SelectItem(24, _bitDepthComboBox.Items);
      }
   }
}
