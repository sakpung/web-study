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

namespace JPXDemo
{
   public partial class AnimationSettings : Form
   {
      public int AnnimationDelay
      {
         get
         {
            return Convert.ToInt32(_nudDelay.Value);
         }
      }

      public int RenderWidth
      {
         get
         {
            return Convert.ToInt32(_nudRenderWidth.Value);
         }
      }

      public int RenderHeight
      {
         get
         {
            return Convert.ToInt32(_nudRenderHeight.Value);
         }
      }

      public AnimationSettings(int delay, int renderWidth, int renderHeight)
      {
         InitializeComponent();

         _nudDelay.Value = Convert.ToDecimal(delay);
         _nudRenderWidth.Value = Convert.ToDecimal(renderWidth);
         _nudRenderHeight.Value = Convert.ToDecimal(renderHeight);
      }
   }
}
