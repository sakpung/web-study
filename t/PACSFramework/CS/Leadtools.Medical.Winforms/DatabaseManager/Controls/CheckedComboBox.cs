// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections.Generic ;
using System.ComponentModel ;
using System.Drawing ;
using System.Data ;
using System.Text ;
using System.Windows.Forms ;
using System.Runtime.InteropServices;

namespace Leadtools.Medical.Winforms
{
   partial class CheckedComboBox : UserControl
   {
      #region Public
   
         #region Methods
         
            public CheckedComboBox ( )
            {
               InitializeComponent ( ) ;
               
               _list             = new ListView ( ) ;
               _list.CheckBoxes  = true ;
               _list.View        = View.Details ;
               _list.HeaderStyle = ColumnHeaderStyle.None ;
               _list.Visible     = false ;
               
               btnModalityDropDown.Click += new EventHandler ( btnModalityDropDown_Click ) ;
               _list.ItemChecked         += new ItemCheckedEventHandler ( _list_ItemChecked ) ;
               _list.VisibleChanged      += new EventHandler ( _list_VisibleChanged ) ;
            }
            
            public void CheckAllItems ( ) 
            {
               try
               {
                  _list.ItemChecked -= new ItemCheckedEventHandler ( _list_ItemChecked ) ;
                  
                  UpdateAllItemsCheckState ( true ) ;
                  
                  _list.ItemChecked += new ItemCheckedEventHandler ( _list_ItemChecked ) ;
                  
                  DisplayCheckedItems ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }
            
            public void ClearCheckedItems ( ) 
            {
               try
               {
                  _list.ItemChecked -= new ItemCheckedEventHandler ( _list_ItemChecked ) ;
                  
                  UpdateAllItemsCheckState ( false ) ;
                  
                  _list.ItemChecked += new ItemCheckedEventHandler ( _list_ItemChecked ) ;
                  
                  DisplayCheckedItems ( ) ;
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }

         #endregion
   
         #region Properties
         
            public ListView CheckedList 
            {
               get
               {
                  return _list ;
               }
            }
            
            public string [ ] CheckedItemsText
            {
               get
               {
                  List <string> itemsText ;
                  
                  
                  itemsText = new List <string> ( ) ;
                  
                  foreach ( ListViewItem chcekedItem in _list.CheckedItems )
                  {
                     itemsText.Add ( chcekedItem.Text ) ;
                  }
                  
                  return itemsText.ToArray ( ) ;
               }
            }
   
         #endregion
   
         #region Events
   
         #endregion
   
         #region Data Types Definition
   
         #endregion
   
         #region Callbacks
   
         #endregion
   
      #endregion
   
      #region Protected
   
         #region Methods

            protected override void OnHandleCreated ( EventArgs e )
            {
               base.OnHandleCreated(e);
            }

            protected override void OnVisibleChanged(EventArgs e)
            {
               base.OnVisibleChanged(e);
            }
   
         #endregion
   
         #region Properties
   
         #endregion
   
         #region Events
   
         #endregion
   
         #region Data Members
   
         #endregion
   
         #region Data Types Definition
   
         #endregion
   
      #endregion
   
      #region Private
   
         #region Methods
         
            private int MouseHookProc ( int nCode, IntPtr wParam, IntPtr lParam )
            {
               if ( DesignMode )
               {
                  return CallNextHookEx ( hHook, nCode, wParam, lParam ) ; 
               }
               
               //if ((nCode == HC_ACTION) && (wParam == WM_LBUTTONDON))
               if (wParam.ToInt32 ( ) != WM_LBUTTONDOWN )
               {
                  return CallNextHookEx ( hHook, nCode, wParam, lParam ) ;
               }


               //Marshall the data from the callback.
               MouseHookStruct MyMouseHookStruct = ( MouseHookStruct ) Marshal.PtrToStructure ( lParam, typeof ( MouseHookStruct ) ) ;

               if ( nCode < 0 )
               {
                  return CallNextHookEx ( hHook, nCode, wParam, lParam ) ;
               }
               else
               {
                  //Create a string variable that shows the current mouse coordinates.
                  Point listPoint   = _list.PointToClient ( new Point ( MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y ) ) ;
                  Point controlPoint = btnModalityDropDown.PointToClient ( new Point ( MyMouseHookStruct.pt.x, MyMouseHookStruct.pt.y ) ) ;
                  
                  if ( _list.Parent != null )
                  {
                     if ( !_list.DisplayRectangle.Contains ( listPoint ) && 
                          !btnModalityDropDown.DisplayRectangle.Contains ( controlPoint ) )
                     {
                        System.Windows.Forms.Control parent = GetTopMostControl (  ) ;
                        
                        
                        if ( parent != null ) 
                        {
                           _list.Visible = false ;
                           
                           //parent.Controls.Remove ( _list ) ;
                        }
                     }
                  }
               }
               
               return CallNextHookEx(hHook, nCode, wParam, lParam); 
            }
            
            private System.Windows.Forms.Control GetTopMostControl (  )
            {
               if ( this.Parent == null ) 
               {
                  return null ;
               }
               
               if ( this.TopLevelControl != null ) 
               {
                  return this.TopLevelControl ;
               }
               
               System.Windows.Forms.Control parent ;
               
               
               parent = this.Parent ;
               
               while ( parent.Parent != null ) 
               {
                  parent = parent.Parent ;
               }
               
               return parent ;
            }
            
            private void DisplayCheckedItems ( ) 
            {
               try
               {
                  txtCheckedItems.Text = "" ;
                  
                  foreach ( ListViewItem checkedItem in _list.CheckedItems )
                  {
                     txtCheckedItems.Text += checkedItem.Text + ", " ;
                  }
                  
                  txtCheckedItems.Text = txtCheckedItems.Text.TrimEnd ( ',', ' ') ;
               }
               catch ( Exception )
               {
                  throw ;
               }
            }
            
            private void UpdateAllItemsCheckState ( bool state ) 
            {
               try
               {
                  foreach ( ListViewItem item in _list.Items )
                  {
                     item.Checked = state ;
                  }
               }
               catch ( Exception exception )
               {
                  System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                                 
                  throw ;
               }
            }
   
         #endregion
   
         #region Properties
   
         #endregion
   
         #region Events
            
            void btnModalityDropDown_Click (object sender, EventArgs e)
            {
               System.Windows.Forms.Control parent = GetTopMostControl (  ) ;
               
               
               if ( parent == null ) 
               {
                  return ;
               }
               
               if ( !_list.Visible )
               {
                  Point screenLocation = this.PointToScreen ( this.Location ) ;
                  Point controLocation = parent.PointToClient ( screenLocation ) ;
                  
                  _list.Left = controLocation.X - this.Left ;
                  _list.Top  = controLocation.Y + this.Height  - this.Top ;
                  _list.Width = this.Width - btnModalityDropDown.Width ;
                  
                  _list.Font = this.Font ;
                  
                  _list.Height = Math.Max ( _list.Height, 250 ) ;
                  
                  if ( ( _list.Top + _list.Height ) > parent.Height ) 
                  {
                     _list.Top  = controLocation.Y - this.Top - _list.Height ;
                  }
                  
                  _list.Visible = true ;
                  
                  if ( !parent.Controls.Contains ( _list ) )
                  {
                     parent.Controls.Add ( _list ) ;
                  }
                  
                  _list.BringToFront ( ) ;
               }
               else
               {
                  _list.Visible = false ;
                  
                  //parent.Controls.Remove ( _list ) ;
               }
            }
            
            void _list_ItemChecked ( object sender, ItemCheckedEventArgs e )
            {
               DisplayCheckedItems ( ) ;
            }
            
            void _list_VisibleChanged ( object sender, EventArgs e )
            {
               if ( DesignMode )
               {
                  return ;
               }
               
               if ( _list.Visible && !_windowHooked )
               {
                  // Create an instance of HookProc.
                  MouseHookProcedure = new HookProc ( MouseHookProc ) ;
                  
                  hHook = SetWindowsHookEx ( WH_MOUSE, 
                                             MouseHookProcedure,
                                             (IntPtr)0,
                                             AppDomain.GetCurrentThreadId ( ) ); //System.Threading.Thread.CurrentThread.ManagedThreadId doesn't work!
                                             
                  //If the SetWindowsHookEx function fails.
                  if ( hHook == 0 )
                  {
                     _windowHooked = false ;
                     
                     return ;
                  }
                  else
                  {
                     _windowHooked = true ;
                  }
               }
               else
               {
                  if ( !_windowHooked )
                  {
                     return ;
                  }
                  
                  bool ret = UnhookWindowsHookEx(hHook);
                  //If the UnhookWindowsHookEx function fails.
                  if (ret == false)
                  {
                     return;
                  }
                  else
                  {
                     _windowHooked = false ;
                  }

                  hHook = 0;
               }
            }
            
         #endregion
   
         #region Data Members
         
            ListView _list ;
            bool _windowHooked = false ;
            
         #endregion
   
         #region Data Types Definition
         
            static int hHook = 0;
            public const int WH_MOUSE = 7;
            public const int WM_LBUTTONDOWN = 0x0201 ;
            HookProc MouseHookProcedure ;
            
            public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
            
            [StructLayout(LayoutKind.Sequential)]
            public class POINT 
            {
               public int x;
               public int y;
            }
            
            //Declare the wrapper managed MouseHookStruct class.
            [StructLayout(LayoutKind.Sequential)]
            public class MouseHookStruct 
            {
               public POINT pt;
               public int hwnd;
               public int wHitTestCode;
               public int dwExtraInfo;
            }
            
            //This is the Import for the SetWindowsHookEx function.
            //Use this function to install a thread-specific hook.
            [DllImport("user32.dll",CharSet=CharSet.Auto,
             CallingConvention=CallingConvention.StdCall)]
            public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, 
            IntPtr hInstance, int threadId);

            //This is the Import for the UnhookWindowsHookEx function.
            //Call this function to uninstall the hook.
            [DllImport("user32.dll",CharSet=CharSet.Auto,
             CallingConvention=CallingConvention.StdCall)]
            public static extern bool UnhookWindowsHookEx(int idHook);
            		
            //This is the Import for the CallNextHookEx function.
            //Use this function to pass the hook information to the next hook procedure in chain.
            [DllImport("user32.dll",CharSet=CharSet.Auto,
             CallingConvention=CallingConvention.StdCall)]
            public static extern int CallNextHookEx(int idHook, int nCode, 
            IntPtr wParam, IntPtr lParam);

   
         #endregion
   
      #endregion
   
      #region internal
   
         #region Methods
   
         #endregion
   
         #region Properties
   
         #endregion
   
         #region Events
   
         #endregion
   
         #region Data Types Definition
   
         #endregion
   
         #region Callbacks
   
         #endregion
   
      #endregion
   }
}
