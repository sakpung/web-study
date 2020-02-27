// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace Leadtools.Medical.Winforms.Control
{
   public partial class ExtendedListView : ListView
   {
      const int WM_USER = 0x0400;
      const int WM_NOTIFY = 0x4e;
      const int OCM_BASE = WM_USER + 0x1C00;
      const int OCM_NOTIFY = OCM_BASE + WM_NOTIFY;
      const int LVN_FIRST = 0 - 100;
      const int LVN_ITEMCHANGING = LVN_FIRST - 0;
      const int LVIF_STATE = 0x0008;
      const int LVIS_UNSELECTED = 0x0000;
      const int LVIS_FOCUSED = 0x0001;
      const int LVIS_SELECTED = 0x0002;
      const int LVIS_SELECTED_FOCUSED = 0x0003;

      [StructLayout(LayoutKind.Sequential)]
      public struct NMHDR
      {
         public IntPtr hwndFrom;
         public int idFrom;
         public int code;
      }
      [StructLayout(LayoutKind.Sequential)]
      public struct POINT
      {
         public int x;
         public int y;
      }
      [StructLayout(LayoutKind.Sequential)]
      public struct NMLISTVIEW
      {
         public NMHDR hdr;
         public int iItem;
         public int iSubItem;
         public int uNewState;
         public int uOldState;
         public int uChanged;
         public POINT ptAction;
         public int lParam;
      }

      public delegate void ItemDeselectingEventHandler(object sender, ItemChangingEventArgs e);
      public event ItemDeselectingEventHandler ItemDeselecting;
      private bool m_cancel;

      protected virtual void OnItemDeselecting(ItemChangingEventArgs e)
      {
         if (ItemDeselecting != null)
         {
            ItemDeselecting(this, e);
         }
      }

      protected override void WndProc(ref Message m)
      {
         if (m.Msg == OCM_NOTIFY)
         {
            NMHDR nm = (NMHDR)m.GetLParam(typeof(NMHDR));
            if (nm.code == LVN_ITEMCHANGING)
            {
               NMLISTVIEW nmlv = (NMLISTVIEW)m.GetLParam(typeof(NMLISTVIEW));
               
               ItemStateChanging(ref m, ref nmlv);
            }
         }
         base.WndProc(ref m);
      }

      private void ItemStateChanging(ref Message m, ref NMLISTVIEW nmlv)
      {
         if ((nmlv.uChanged & LVIF_STATE) == LVIF_STATE)
         {
            if ((nmlv.uOldState == LVIS_SELECTED) || //FROM ITEM
                (nmlv.uNewState == LVIS_UNSELECTED))
            {
               if (m_cancel)
               {
                  m.Result = new IntPtr(1);
                  m_cancel = false;
               }
               else
               {
                   if ((nmlv.uOldState == LVIS_SELECTED) && //FROM ITEM
                       (nmlv.uNewState == LVIS_UNSELECTED))
                   {
                       ItemChangingEventArgs e = new ItemChangingEventArgs(nmlv.iItem, this.Items[nmlv.iItem]);

                       OnItemDeselecting(e);
                       if (e.Cancel)
                       {
                           m.Result = new IntPtr(1);
                           m_cancel = true;
                       }
                   }
               }
            }
            else if ((nmlv.uOldState == LVIS_UNSELECTED) || //TO ITEM
                     (nmlv.uNewState == LVIS_SELECTED) ||
                     (nmlv.uNewState == LVIS_SELECTED_FOCUSED))
            {
               if (m_cancel)
               {
                  m.Result = new IntPtr(1);
                  m_cancel = false;
               }
            }
         }
      }
   }

   public class ItemChangingEventArgs : CancelEventArgs
   {
      int _Index;

      public int Index
      {
         get
         {
            return _Index;
         }
      }

      ListViewItem _Item;

      public ListViewItem Item
      {
         get
         {
            return _Item;
         }
      }

      public ItemChangingEventArgs(int index, ListViewItem item)
      {
         _Index = index;
         _Item = item;
      }            
   }
}
