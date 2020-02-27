// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DicomAnonymizer.UI.Controls
{
   public class TagListView : ListView
   {
      public TagListView()
      {
         if (!DesignMode)
         {
            //Activate double buffering
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            SetStyle(ControlStyles.EnableNotifyMessage, true);
         }
      }

      protected override void OnNotifyMessage(Message m)
      {
         //Filter out the WM_ERASEBKGND message
         if (m.Msg != 0x14)
         {
            base.OnNotifyMessage(m);
         }
      }
   }
}
