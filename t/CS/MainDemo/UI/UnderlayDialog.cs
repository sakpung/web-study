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

using Leadtools;

namespace MainDemo
{
   public partial class UnderlayDialog : Form
   {
      private static bool _firstTimer = true;
      private static RasterImageUnderlayFlags _initialFlags;
      public RasterImageUnderlayFlags Flags;

      public UnderlayDialog( )
      {
         InitializeComponent();
      }

      private void UnderlayDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            _initialFlags = RasterImageUnderlayFlags.Stretch;
         }

         Flags = _initialFlags;
         if((Flags & RasterImageUnderlayFlags.Stretch) == RasterImageUnderlayFlags.Stretch)
            _rbStretch.Checked = true;
         else
            _rbTile.Checked = true;
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         if(_rbStretch.Checked)
            Flags = RasterImageUnderlayFlags.Stretch;
         if(_rbTile.Checked)
            Flags = RasterImageUnderlayFlags.None;

         _initialFlags = Flags;
      }
   }
}
