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
   public partial class XpsOptionsControl : UserControl, IOptionsUserControl
   {
      public XpsOptionsControl()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Called by the owner to initialize
      /// </summary>
      public void SetData(RasterCodecs rasterCodecsInstance)
      {
         // Set the state of the controls

         CodecsXpsLoadOptions xpsLoadOptions = rasterCodecsInstance.Options.Xps.Load;
      }

      /// <summary>
      /// Called by the owner to get the data
      /// </summary>
      public bool GetData(RasterCodecs rasterCodecsInstance)
      {
         CodecsXpsLoadOptions xpsLoadOptions = rasterCodecsInstance.Options.Xps.Load;

         return true;
      }
   }
}
