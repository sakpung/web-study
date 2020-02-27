// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Leadtools.Medical.Winforms.LicenseManager
{
   public class MessageListView : ListView
   {
      private const int WM_ERASEBKGND = 0x14;
      private const long LVM_FIRST = 0x1000;
      private const long LVM_GETHEADER = (LVM_FIRST + 31);

      [DllImport("user32.dll", CallingConvention = CallingConvention.StdCall)]
      private static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

      [DllImport("user32.dll")]
      private static extern bool GetWindowRect(HandleRef hwnd, out RECT lpRect);


      private bool _GridLines;
      private Font _EmptyFont;

      private string _EmptyMessage;

      public string EmptyMessage
      {
         get { return _EmptyMessage; }
         set 
         {
            if (_EmptyMessage != value)
            {
               _EmptyMessage = value;
               Invalidate();
            }
         }
      }

      public MessageListView()
      {
         SetStyle(ControlStyles.ResizeRedraw, true);
         _EmptyFont = new Font(Font, FontStyle.Bold);
      }

      private int GetHeaderHeight()
      {
         RECT rc = new RECT();
         IntPtr hwnd = SendMessage(Handle, (uint)LVM_GETHEADER, 0, 0);
         if (hwnd != null)
         {
            if (GetWindowRect(new HandleRef(null, hwnd), out rc))
            {
               return rc.Bottom - rc.Top;
            }
         }
         return 0;
      }

      protected override void WndProc(ref Message m)
      {
         base.WndProc(ref m);
         if (m.Msg == WM_ERASEBKGND)
         {
            #region Handle drawing of "no items" message
            if (Items.Count == 0 && Columns.Count > 0)
            {
               StringFormat sf = new StringFormat();
               Rectangle rc;

               _GridLines = base.GridLines;
               if (_GridLines)
               {
                  GridLines = false;
               }
                             
               sf.Alignment = StringAlignment.Center;               
               rc = new Rectangle(0, GetHeaderHeight(), ClientRectangle.Width, ClientRectangle.Height - GetHeaderHeight());
               using (Graphics g = this.CreateGraphics())
               {
                  g.FillRectangle(SystemBrushes.Window, 0, 0, Width, Height);
                  g.DrawString(_EmptyMessage,_EmptyFont,Brushes.Red, rc, sf);
               }
            }
            else
            {
               GridLines = _GridLines;
            }
            #endregion
         }
      }
   }

   [Serializable, StructLayout(LayoutKind.Sequential)]
   public struct RECT
   {
      public int Left;
      public int Top;
      public int Right;
      public int Bottom;
   }
}
