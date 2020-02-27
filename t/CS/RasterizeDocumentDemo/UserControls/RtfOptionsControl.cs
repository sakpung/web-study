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
using Leadtools.Demos;

#if ! LEADTOOLS_V17_OR_LATER
using LeadPoint = System.Drawing.Point;
using LeadSize = System.Drawing.Size;
using LeadRect = System.Drawing.Rectangle;
#endif // #if !LEADTOOLS_V17_OR_LATER

#if LEADTOOLS_V17_OR_LATER
using Leadtools.Drawing;
#endif // #if LEADTOOLS_V17_OR_LATER

namespace RasterizeDocumentDemo.UserControls
{
   public partial class RtfOptionsControl : UserControl, IOptionsUserControl
   {
      public RtfOptionsControl()
      {
         InitializeComponent();
      }

      /// <summary>
      /// Called by the owner to initialize
      /// </summary>
      public void SetData(RasterCodecs rasterCodecsInstance)
      {
         // Set the state of the controls

         CodecsRtfLoadOptions rtfLoadOptions = rasterCodecsInstance.Options.Rtf.Load;

         _backColorPanel.BackColor = Converters.ToGdiPlusColor(rtfLoadOptions.BackColor);
      }

      /// <summary>
      /// Called by the owner to get the data
      /// </summary>
      public bool GetData(RasterCodecs rasterCodecsInstance)
      {
         CodecsRtfLoadOptions rtfLoadOptions = rasterCodecsInstance.Options.Rtf.Load;

         // Get the RTF load settings
         rtfLoadOptions.BackColor = Converters.FromGdiPlusColor(_backColorPanel.BackColor);

         return true;
      }

      private void _backColorButton_Click(object sender, EventArgs e)
      {
         using(ColorDialog dlg = new ColorDialog())
         {
            dlg.Color = _backColorPanel.BackColor;
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _backColorPanel.BackColor = dlg.Color;
            }
         }
      }

      private void _resetToDefaultsButton_Click(object sender, EventArgs e)
      {
         _backColorPanel.BackColor = Color.White;
      }
   }
}
