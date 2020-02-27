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

using Leadtools.Demos;
using Leadtools;
using Leadtools.ImageProcessing.Effects;
using Leadtools.ImageProcessing.Core;

namespace MainDemo
{
   public partial class SmoothDialog : Form
   {
      private static bool _firstTimer = true;
      private static SmoothCommandFlags _initialFlags;
      private static int _initialLength;

      public SmoothCommandFlags Flags;
      public int Length;

      public SmoothDialog( )
      {
         InitializeComponent();
      }

      private void SmoothDialog_Load(object sender, System.EventArgs e)
      {
         if(_firstTimer)
         {
            _firstTimer = false;
            SmoothCommand command = new SmoothCommand();
            _initialFlags = command.Flags;
            _initialLength = command.Length;
         }

         Flags = _initialFlags;
         Length = _initialLength;

         _cbImageUnchanged.Checked = (Flags & SmoothCommandFlags.ImageUnchanged) == SmoothCommandFlags.ImageUnchanged;
         _cbFavorLong.Checked = (Flags & SmoothCommandFlags.FavorLong) == SmoothCommandFlags.FavorLong;

         _numLength.Value = Length;
      }

      private void _num_Leave(object sender, System.EventArgs e)
      {
         DialogUtilities.NumericOnLeave(sender);
      }

      private void _btnOk_Click(object sender, System.EventArgs e)
      {
         Flags = SmoothCommandFlags.None;

         if(_cbImageUnchanged.Checked)
            Flags |= SmoothCommandFlags.ImageUnchanged;
         if(_cbFavorLong.Checked)
            Flags |= SmoothCommandFlags.FavorLong;

         Length = (int)_numLength.Value;

         _initialFlags = Flags;
         _initialLength = Length;
      }
   }
}
