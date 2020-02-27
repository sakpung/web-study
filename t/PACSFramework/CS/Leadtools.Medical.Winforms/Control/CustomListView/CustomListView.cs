// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Medical.Winforms.Win32;
using System.Drawing;

namespace Leadtools.Medical.Winforms.Control
{
   class CustomListView : ListView
   {

      protected override void WndProc(ref Message WinMsg)
      {
         switch (WinMsg.Msg)
         {
            case Win32APIWrapper.Win32Constants.WindowsMessage.WM_CONTEXTMENU:
            {
               IntPtr nptrHeaderHandle;



               nptrHeaderHandle = Win32APIWrapper.SendMessage(this.Handle,
                                                                Win32APIWrapper.Win32Constants.ListViewMessages.LVM_GETHEADER,
                                                                0,
                                                                IntPtr.Zero);

               if (WinMsg.WParam == nptrHeaderHandle)
               {
                  Point MousePosition;


                  MousePosition = new Point(Win32APIWrapper.LoWord(WinMsg.LParam.ToInt32()),
                                              Win32APIWrapper.HiWord(WinMsg.LParam.ToInt32()));

                  MousePosition = this.PointToClient(MousePosition);

                  OnColumnContextMenu ( MousePosition ) ;
               }
            }
            break ;
                  
            default:
            {
               base.WndProc ( ref WinMsg ) ;

               return ;
            }
         }  
      }
      
      private void OnColumnContextMenu(Point MousePosition)
      {
         try
         {
            if (null != ColumnContextMenu)
            {
               ColumnContextMenu(this,
                                   new VirtualListView.HeaderContextMenuEventArgs(MousePosition));
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }
      
      public event Leadtools.Medical.Winforms.Control.VirtualListView.ColumnContextMenuHandler ColumnContextMenu;
      
      protected override void OnKeyDown(KeyEventArgs e)
      {
         try
         {
            if (e.KeyCode == Keys.A && e.Modifiers == Keys.Control)
            {
               SelectAll();
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
         finally
         {
            base.OnKeyDown(e);
         }
      }
      
      private void SelectAll()
      {
         try
         {
            Win32APIWrapper.LVITEMW LstVwItem;


            LstVwItem = new Win32APIWrapper.LVITEMW();

            LstVwItem.state = Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED;
            LstVwItem.stateMask = Win32APIWrapper.Win32Constants.ListViewItemStyle.LVIS_SELECTED;

            Win32APIWrapper.SetSelected(this.Handle,
                                          Win32APIWrapper.Win32Constants.ListViewMessages.LVM_SETITEMSTATE,
                                          -1,
                                          ref LstVwItem);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }
   }
}
