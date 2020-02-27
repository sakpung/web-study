// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Runtime.InteropServices ;


namespace Leadtools.Medical.PatientRestrict.AddIn.Common
{
   /// <summary>
   /// Summary description for Win32APIWrapper.
   /// </summary>
   class Win32APIWrapper
   {
      #region Public
         
      #region Methods
         
         [ DllImport ( Constants.User32Dll ) ]
         public static extern IntPtr SendMessage 
         ( 
            IntPtr hwnd, 
            int wMsg, 
            int wParam, 
            IntPtr lParam 
         ) ;
         
         
         [ DllImport ( Constants.User32Dll ) ]
         public static extern IntPtr SendMessage 
         ( 
            IntPtr hwnd, 
            int wMsg, 
            int wParam, 
            int lParam 
         ) ;
         
         
         [ DllImport ( Constants.User32Dll ) ]
         public static extern IntPtr SendMessage 
         ( 
            IntPtr hwnd, 
            IntPtr wMsg, 
            int wParam, 
            int lParam 
         ) ;
               
               
         [ DllImport ( Constants.User32Dll ) ]
         public static extern IntPtr SendMessage 
         ( 
            IntPtr hwnd, 
            int wMsg, 
            int wParam, 
            ref RECT lParam 
         ) ;
               
               
         [ DllImport ( Constants.User32Dll ) ]
         public static extern IntPtr SendMessage 
         ( 
            IntPtr hwnd, 
            int wMsg, 
            int wParam, 
            ref LVCOLUMNW lParam 
         ) ;
               
               
         [ DllImport ( Constants.User32Dll ) ]
         public static extern bool GetWindowRect 
         ( 
            IntPtr nptrWnd, 
            ref Win32APIWrapper.RECT lpRect 
         ) ;
               
               
         [ DllImport ( Constants.User32Dll ) ]
         public static extern bool GetClientRect
         (
            IntPtr hWnd,
            ref Win32APIWrapper.RECT lpRect
         ) ;

         [ DllImport ( Constants.User32Dll ) ]
         public static extern IntPtr GetWindowLong
         (          
            IntPtr hWnd,
            int nIndex
         ) ;
               
               
         [ DllImport ( Constants.User32Dll ) ]
         public static extern long SetWindowLong
         (          
            IntPtr hWnd,
            int nIndex,
            Win32APIWrapper.WndProcHandler dwNewLong
         ) ;
               
         [ DllImport ( Constants.User32Dll ) ]
         public static extern IntPtr CallWindowProc
         (          
            IntPtr lpPrevWndFunc,
            IntPtr hWnd,
            int Msg,
            IntPtr wParam,
            IntPtr lParam
         );


         [ DllImport ( Constants.User32Dll ) ]
         public static extern IntPtr DefWindowProc
         (          
            IntPtr hWnd,
            int Msg,
            IntPtr wParam,
            IntPtr lParam
         );

         [ DllImport ( Constants.User32Dll ) ]
         public static extern bool GetComboBoxInfo 
         ( 
            IntPtr hwndCombo, 
            ref COMBOBOXINFO pcbi 
         ) ;
               
         [ DllImport ( Constants.User32Dll ) ]
         public static extern bool RedrawWindow
         (
            IntPtr hWnd,       
            ref RECT lprcUpdate,
            IntPtr hrgnUpdate,
            uint flags
         ) ;
         
         [DllImport ( Constants.User32Dll, EntryPoint="SetScrollInfo", SetLastError=true, CharSet=CharSet.Unicode, ExactSpelling=true, CallingConvention=CallingConvention.StdCall)]
         public static extern int SetScrollInfo 
         (
            IntPtr hwnd, 
            int n, 
            SCROLLINFO lpcScrollInfo, 
            bool redraw 
         ) ;         
         
      
         [DllImport ( Constants.User32Dll, EntryPoint="GetScrollInfo", SetLastError=true, CharSet=CharSet.Unicode, ExactSpelling=true, CallingConvention=CallingConvention.StdCall ) ]
         public static extern bool GetScrollInfo
         (
            IntPtr hwnd, 
            int fnBar, 
            SCROLLINFO lpcScrollInfo
         ) ;
         
         [DllImport ( Constants.User32Dll, EntryPoint="ShowScrollBar", SetLastError=true, CharSet=CharSet.Unicode, ExactSpelling=true, CallingConvention=CallingConvention.StdCall ) ]
         public static extern bool ShowScrollBar
         (
            IntPtr hwnd, 
            int nBar, 
            bool bShow
         ) ;
                                                        
         [ DllImport ( Constants.User32Dll ) ] 
         public static extern bool EnableScrollBar
         (          
            IntPtr hWnd,
            int wSBflags,
            int wArrows
         );
               
               
         [ DllImport ( Constants.User32Dll ) ]
         public static extern int GetScrollPos 
         ( 
            IntPtr npWndHandle, 
            int nBar 
         ) ;
               
               
         [ DllImport ( Constants.User32Dll ) ]
         public static extern int SetScrollPos 
         (  
            IntPtr npWndHandle,
            int nBar,
            int nPos,
            bool bRedraw 
         ) ;
                  
               
         [ DllImport ( Constants.User32Dll ) ]
         public static extern bool InvalidateRect
         (
            IntPtr hWnd,           
            ref RECT lpRect,  
            bool bErase          
         ) ;
               
               
         [ DllImport ( Constants.User32Dll, 
         EntryPoint = Constants.EntryPointSendMessage  ) ]
         public static extern int InsertColumn 
         ( 
            IntPtr hWnd, 
            int Msg, 
            int wParam, 
            ref LVCOLUMNW lParam 
         ) ;
               
               
         [ DllImport ( Constants.User32Dll,
         EntryPoint = Constants.EntryPointSendMessage  ) ]
         public static extern int SetSelected 
         ( 
            IntPtr hWnd, 
            int Msg, 
            int wParam, 
            ref LVITEMW lvitem 
         ) ;
               
               
         [ System.Runtime.InteropServices.DllImport ( Constants.User32Dll ) ]
         public static extern bool UpdateWindow ( IntPtr npWndHandle ) ;
               
         public static int HiWord ( int nNumber )
         {
            if ( ( nNumber & 0x80000000 ) == 0x80000000 ) 
            {
               return ( nNumber >> 16 ) ;
            }
            else
            {
               return ( nNumber >> 16 ) & 0xffff ;
            }
         }


         public static int LoWord ( int nNumber )
         {
            try
            {
               return nNumber & 0xffff ; 
            }
            catch ( Exception exception )
            {
               System.Diagnostics.Debug.Assert ( false ) ;
                     
               throw exception ;
            }
         }
               
               
         public int MakeLong ( int nLoWord, int nHiWord )
         { 
            try
            {
               return ( nHiWord << 16 ) | ( nLoWord & 0xffff ) ;
            }
            catch ( Exception exception )
            {
               System.Diagnostics.Debug.Assert ( false ) ;
                     
               throw exception ;
            }
         } 
               
               
         public IntPtr MakeLParam ( int nLoWord, int nHiWord )
         { 
            try
            {
               return ( IntPtr ) ( ( nHiWord << 16 ) | ( nLoWord & 0xffff ) ) ; 
            }
            catch ( Exception exception )
            {
               System.Diagnostics.Debug.Assert ( false ) ;
                     
               throw exception ;
            }
         } 


      #endregion
         
      #region Properties
            
      #endregion
         
      #region Events
            
      #endregion
         
      #region Data Types Definition
         
         public class Win32Constants
         {
            public class WindowsMessage
            {
               public const int WM_PAINT           = 0x000F ;
               public const int WM_NOTIFY          = 0x004E ;
               public const int WM_LBUTTONDOWN     = 0x0201 ;
               public const int WM_LBUTTONDBLCLK   = 0x0203 ;
               public const int WM_LBUTTONUP       = 0x0202 ;
               public const int WM_CTLCOLORLISTBOX = 0x0134 ; 
               public const int WM_SETTEXT         = 0x000C ;
               public const int WM_GETTEXT         = 0x000D ;
               public const int WM_GETTEXTLENGTH   = 0x000E ;
               public const int WM_CHAR            = 0x0102 ;
               public const int WM_DRAWITEM        = 0x002B ;
               public const int WM_MEASUREITEM     = 0x002C ;
               public const int WM_HSCROLL         = 0x0114 ;
               public const int WM_VSCROLL         = 0x0115 ;
               public const int WM_SIZE            = 0x0005 ;
               public const int WM_MOUSEHOVER      = 0x02A1 ;
               public const int WM_MOUSELEAVE      = 0x02A3 ;
               public const int WM_CONTEXTMENU     = 0x007B ;
               public const int WM_KEYDOWN         = 0x0100 ;
               public const int WM_MOUSEWHEEL      = 0x020A;
               public const int WM_SETREDRAW       = 0x000B ;
            }
                  
                  
            public class WindowsStyle
            {
               public const int  WS_OVERLAPPED     = 0x00000000 ;
               public const int  WS_CHILD          = 0x40000000 ;
               public const int  WS_MINIMIZE       = 0x20000000 ;
               public const int  WS_VISIBLE        = 0x10000000 ;
               public const int  WS_DISABLED       = 0x08000000 ;
               public const int  WS_CLIPSIBLINGS   = 0x04000000 ;
               public const int  WS_CLIPCHILDREN   = 0x02000000 ;
               public const int  WS_MAXIMIZE       = 0x01000000 ;
               public const int  WS_CAPTION        = 0x00C00000 ;   /* WS_BORDER | WS_DLGFRAME  */
               public const int  WS_BORDER         = 0x00800000 ;
               public const int  WS_DLGFRAME       = 0x00400000 ;
               public const int  WS_VSCROLL        = 0x00200000 ;
               public const int  WS_HSCROLL        = 0x00100000 ;
               public const int  WS_SYSMENU        = 0x00080000 ;
               public const int  WS_THICKFRAME     = 0x00040000 ;
               public const int  WS_GROUP          = 0x00020000 ;
               public const int  WS_TABSTOP        = 0x00010000 ;
               public const int  WS_MINIMIZEBOX    = 0x00020000 ;
               public const int  WS_MAXIMIZEBOX    = 0x00010000 ;
            }
                  
                  
            public class WindowsExtendedStyle
            {
               public const int  WS_EX_CLIENTEDGE = 0x00000200;
            }
                  
                  
            public class GetWindowLongFieldsOffset
            {
               public const int GWL_WNDPROC = -4 ;
            }
                  
                  
            public class ListboxMessages
            {
               public const int LB_GETCURSEL   = 0x0188 ;
               public const int LB_GETSEL      = 0x0187 ;
               public const int LB_GETITEMRECT = 0x0198 ;
               public const int LB_GETTOPINDEX = 0x018E ;
               public const int LB_SETTOPINDEX = 0x0197 ;
            }
                  
                  
            public class ListboxReturnValues
            {
               public const int LB_ERR = -1 ;
            }
                  
                  
            public class ComboBoxNotification
            {
               public const int CBN_ERRSPACE     = -1 ;
               public const int CBN_SELCHANGE    = 1 ;
               public const int CBN_DBLCLK       = 2 ;
               public const int CBN_SETFOCUS     = 3 ;
               public const int CBN_KILLFOCUS    = 4 ;
               public const int CBN_EDITCHANGE   = 5 ;
               public const int CBN_EDITUPDATE   = 6 ;
               public const int CBN_DROPDOWN     = 7 ;
               public const int CBN_CLOSEUP      = 8 ; 
               public const int CBN_SELENDOK     = 9 ;
               public const int CBN_SELENDCANCEL = 10 ;
            }
                  
                  
            public class ComboBoxMessage
            {
               public const int  CB_GETEDITSEL            = 0x0140 ;
               public const int  CB_LIMITTEXT             = 0x0141 ; 
               public const int  CB_SETEDITSEL            = 0x0142 ;
               public const int  CB_ADDSTRING             = 0x0143 ;
               public const int  CB_DELETESTRING          = 0x0144 ;
               public const int  CB_DIR                   = 0x0145 ;
               public const int  CB_GETCOUNT              = 0x0146 ;
               public const int  CB_GETCURSEL             = 0x0147 ;
               public const int  CB_GETLBTEXT             = 0x0148 ;
               public const int  CB_GETLBTEXTLEN          = 0x0149 ;  
               public const int  CB_INSERTSTRING          = 0x014A ;
               public const int  CB_RESETCONTENT          = 0x014B ;
               public const int  CB_FINDSTRING            = 0x014C ;
               public const int  CB_SELECTSTRING          = 0x014D ;
               public const int  CB_SETCURSEL             = 0x014E ;
               public const int  CB_SHOWDROPDOWN          = 0x014F ;
               public const int  CB_GETITEMDATA           = 0x0150 ;
               public const int  CB_SETITEMDATA           = 0x0151 ;
               public const int  CB_GETDROPPEDCONTROLRECT = 0x0152 ;
               public const int  CB_SETITEMHEIGHT         = 0x0153 ;
               public const int  CB_GETITEMHEIGHT         = 0x0154 ;
               public const int  CB_SETEXTENDEDUI         = 0x0155 ;
               public const int  CB_GETEXTENDEDUI         = 0x0156 ;
               public const int  CB_GETDROPPEDSTATE       = 0x0157 ;
               public const int  CB_FINDSTRINGEXACT       = 0x0158 ;
               public const int  CB_SETLOCALE             = 0x0159 ;
               public const int  CB_GETLOCALE             = 0x015A ;
            }
                  
                  
            public class ComboBoxReturnValues
            {
               public const int CB_OKAY     = 0 ;
               public const int CB_ERR      = -1 ;
               public const int CB_ERRSPACE = -2 ;
            }  
                  
                  
            public class ComboBoxStyles
            {
               public const long CBS_SIMPLE            = 0x0001L ;
               public const long CBS_DROPDOWN          = 0x0002L ;
               public const long CBS_DROPDOWNLIST      = 0x0003L ;
               public const long CBS_OWNERDRAWFIXED    = 0x0010L ;
               public const long CBS_OWNERDRAWVARIABLE = 0x0020L ;
               public const long CBS_AUTOHSCROLL       = 0x0040L ;
               public const long CBS_OEMCONVERT        = 0x0080L ;
               public const long CBS_SORT              = 0x0100L ;
               public const long CBS_HASSTRINGS        = 0x0200L ;
               public const long CBS_NOINTEGRALHEIGHT  = 0x0400L ;
               public const long CBS_DISABLENOSCROLL   = 0x0800L ;
            }
                  
                  
            public class VirtualKeys
            {
               public const int VK_SPACE = 0x20 ;
            }
                  
                  
            public class RedrawWindowFlag
            {
               public const int RDW_INVALIDATE      = 0x0001 ;
               public const int RDW_INTERNALPAINT   = 0x0002 ;
               public const int RDW_ERASE           = 0x0004 ; 
               public const int RDW_VALIDATE        = 0x0008 ;
               public const int RDW_NOINTERNALPAINT = 0x0010 ;
               public const int RDW_NOERASE         = 0x0020 ;
               public const int RDW_NOCHILDREN      = 0x0040 ; 
               public const int RDW_ALLCHILDREN     = 0x0080 ;
               public const int RDW_UPDATENOW       = 0x0100 ;
               public const int RDW_ERASENOW        = 0x0200 ;
               public const int RDW_FRAME           = 0x0400 ;
               public const int RDW_NOFRAME         = 0x0800 ;
            }
                  
                  
            public class ScrollBarMessages
            {
               public const int SB_HORZ = 0 ;
               public const int SB_VERT = 1 ;
               public const int SB_CTL  = 2 ;
               public const int SB_BOTH = 3 ;
            }
            
            
            public class ScrollBarCommands
            {
               public const int SB_LINEUP          = 0;
               public const int SB_LINELEFT        = 0;
               public const int SB_LINEDOWN        = 1;
               public const int SB_LINERIGHT       = 1;
               public const int SB_PAGEUP          = 2;
               public const int SB_PAGELEFT        = 2;
               public const int SB_PAGEDOWN        = 3;
               public const int SB_PAGERIGHT       = 3;
               public const int SB_THUMBPOSITION   = 4;
               public const int SB_THUMBTRACK      = 5;
               public const int SB_TOP             = 6;
               public const int SB_LEFT            = 6;
               public const int SB_BOTTOM          = 7;
               public const int SB_RIGHT           = 7;
               public const int SB_ENDSCROLL       = 8;
            }
                  
                  
            public class ScrollBarInformation
            {
               public const int SIF_RANGE           = 0x0001 ;
               public const int SIF_PAGE            = 0x0002 ;
               public const int SIF_POS             = 0x0004 ;
               public const int SIF_DISABLENOSCROLL = 0x0008 ;
               public const int SIF_TRACKPOS        = 0x0010 ;
               public const int SIF_ALL             = ( SIF_RANGE | SIF_PAGE | SIF_POS | SIF_TRACKPOS) ;
                     
            }
                  
                  
            public class EnableScrollBarFlags
            {
               public const int ESB_ENABLE_BOTH   = 0x0000 ; 
               public const int ESB_DISABLE_BOTH  = 0x0003 ;
               public const int ESB_DISABLE_LEFT  = 0x0001 ;
               public const int ESB_DISABLE_RIGHT = 0x0002 ;
               public const int ESB_DISABLE_UP    = 0x0001 ; 
               public const int ESB_DISABLE_DOWN  = 0x0002 ;
               public const int ESB_DISABLE_LTUP  = ESB_DISABLE_LEFT ;
               public const int ESB_DISABLE_RTDN  = ESB_DISABLE_RIGHT ;
            }
                  
                  
            public class ListViewMessages
            {
               public const int LVM_FIRST                    = 0x1000 ;
               public const int LVM_GETITEMCOUNT             = 0x1000 + 4 ;
               public const int LVM_SETITEMCOUNT             = 0x1000 + 47 ;
               public const int LVM_SETITEMSTATE             = 0x1000 + 43 ;
               public const int LVM_INSERTCOLUMNA            = 0x1000 + 27 ;
               public const int LVM_INSERTCOLUMNW            = 0x1000 + 97 ;
               public const int LVM_REDRAWITEMS              = 0x1000 + 21 ;
               public const int LVM_ENSUREVISIBLE            = 0x1000 + 19 ;
               public const int LVM_SCROLL                   = 0x1000 + 20 ;
               public const int LVM_SETCOLUMN                = 0x1000 + 26 ;
               public const int LVM_SETEXTENDEDLISTVIEWSTYLE = 0x1000 + 54 ;
               public const int LVM_GETSELECTEDCOUNT         = 0x1000 + 50 ;
               public const int LVM_GETITEMSTATE             = 0x1000 + 44 ;
               public const int LVM_GETITEMRECT              = 0x1000 + 14 ;
               public const int LVM_GETHEADER                = 0x1000 + 31 ;
               public const int LVM_SETCOLUMNW               = 0x1000 + 96 ;
            }
                  
                  
            public class ListViewNotification
            {
               public const int LVN_COLUMNCLICK    = -100 - 8 ;
               public const int LVN_ODSTATECHANGED = -100 - 15 ;
               public const int LVN_GETDISPINFOA   = -100 - 50 ;
               public const int LVN_GETDISPINFOW   = -100 - 77 ;
               public const int LVN_ITEMACTIVATE   = -100 - 14 ;
               public const int LVN_ITEMCHANGED    = -100 - 1 ;
            }
                  
            public class ListViewStyles
            {
               public const int LVS_ICON            = 0x0000 ;
               public const int LVS_REPORT          = 0x0001 ;
               public const int LVS_SMALLICON       = 0x0002 ;
               public const int LVS_LIST            = 0x0003 ;
               public const int LVS_TYPEMASK        = 0x0003 ;  
               public const int LVS_SINGLESEL       = 0x0004 ;
               public const int LVS_SHOWSELALWAYS   = 0x0008 ;
               public const int LVS_SORTASCENDING   = 0x0010 ;
               public const int LVS_SORTDESCENDING  = 0x0020 ;
               public const int LVS_SHAREIMAGELISTS = 0x0040 ;
               public const int LVS_NOLABELWRAP     = 0x0080 ;
               public const int LVS_AUTOARRANGE     = 0x0100 ;
               public const int LVS_EDITLABELS      = 0x0200 ;
               public const int LVS_OWNERDATA       = 0x1000 ;
               public const int LVS_NOSCROLL        = 0x2000 ;
               public const int LVS_ALIGNTOP        = 0x0000 ;
               public const int LVS_ALIGNLEFT       = 0x0800 ; 
               public const int LVS_ALIGNMASK       = 0x0c00 ;
               public const int LVS_OWNERDRAWFIXED  = 0x0400 ;
               public const int LVS_NOCOLUMNHEADER  = 0x4000 ;
               public const int LVS_NOSORTHEADER    = 0x8000 ;
            }
                  
                  
            public class ListViewExtendedStyles
            {
               public const int LVS_EX_GRIDLINES        = 0x00000001 ;
               public const int LVS_EX_SUBITEMIMAGES    = 0x00000002 ;
               public const int LVS_EX_CHECKBOXES       = 0x00000004 ;
               public const int LVS_EX_TRACKSELECT      = 0x00000008 ;
               public const int LVS_EX_HEADERDRAGDROP   = 0x00000010 ;
               public const int LVS_EX_FULLROWSELECT    = 0x00000020 ;
               public const int LVS_EX_ONECLICKACTIVATE = 0x00000040 ;
               public const int LVS_EX_TWOCLICKACTIVATE = 0x00000080 ;
               public const int LVS_EX_FLATSB           = 0x00000100 ;
               public const int LVS_EX_REGIONAL         = 0x00000200 ;
               public const int LVS_EX_INFOTIP          = 0x00000400 ;
               public const int LVS_EX_UNDERLINEHOT     = 0x00000800 ;
               public const int LVS_EX_UNDERLINECOLD    = 0x00001000 ;
               public const int LVS_EX_MULTIWORKAREAS   = 0x00002000 ;
               public const int LVS_EX_LABELTIP         = 0x00004000 ;
               public const int LVS_EX_BORDERSELECT     = 0x00008000 ; 
               public const int LVS_EX_DOUBLEBUFFER     = 0x00010000 ;   
               public const int LVS_EX_HIDELABELS       = 0x00020000 ;
               public const int LVS_EX_SINGLEROW        = 0x00040000 ;
               public const int LVS_EX_SNAPTOGRID       = 0x00080000 ;
               public const int LVS_EX_SIMPLESELECT     = 0x00100000 ;

            }
                  
                  
            public class ListViewFormat
            {
               public const int LVCFMT_LEFT        = 0x0000 ;
               public const int LVCFMT_RIGHT       = 0x0001 ;
               public const int LVCFMT_CENTER      = 0x0002 ;
               public const int LVCFMT_JUSTIFYMASK = 0x0003 ;
            }
                  
                  
            public class ListViewColumnFilter
            {
               public const uint LVCF_FMT     = 0x0001;
               public const uint LVCF_WIDTH   = 0x0002;
               public const uint LVCF_TEXT    = 0x0004;
               public const uint LVCF_SUBITEM = 0x0008;
               public const uint LVCF_IMAGE   = 0x0010;
               public const uint LVCF_ORDER   = 0x0020;
            }
                  
                  
            public class ListViewItemStyle
            {
               public const uint LVIS_FOCUSED        = 0x0001;
               public const uint LVIS_SELECTED       = 0x0002;
               public const uint LVIS_CUT            = 0x0004;
               public const uint LVIS_DROPHILITED    = 0x0008;
               public const uint LVIS_GLOW           = 0x0010;
               public const uint LVIS_ACTIVATING     = 0x0020;
               public const uint LVIS_OVERLAYMASK    = 0x0F00;
               public const uint LVIS_STATEIMAGEMASK = 0xF000;
            }
                  
                  
            public class ListViewItemFilter
            {
               public const uint LVIF_TEXT   = 0x0001 ;
               public const uint LVIF_IMAGE  = 0x0002 ;
               public const uint LVIF_PARAM  = 0x0004 ;
               public const uint LVIF_STATE  = 0x0008 ;
               public const uint LVIF_INDENT = 0x0010 ;
            }
                  
            public class ListViewItemRect
            {
                  
               public const int  LVIR_BOUNDS       = 0 ;
               public const int  LVIR_ICON         = 1 ;
               public const int  LVIR_LABEL        = 2 ;
               public const int  LVIR_SELECTBOUNDS = 3 ;
            }
         }
               
               
         [ StructLayout ( LayoutKind.Sequential ) ]
            public struct POINTS 
         { 
            public Int32 x;  
            public Int32 y ;  
         }
               
               
         [ StructLayout ( LayoutKind.Sequential ) ]
            public struct RECT 
         {
            public Int32 left ;
            public Int32 top ;
            public Int32 right ;
            public Int32 bottom ;
         }
               
         [ StructLayout ( LayoutKind.Sequential ) ]
            public struct COMBOBOXINFO
         {
            public Int32 cbSize ;
            public RECT rcItem ;
            public RECT rcButton ;
            public Int32 stateButton ;
            public IntPtr hwndCombo ;
            public IntPtr hwndEdit ;
            public IntPtr hwndList ;
         }
               
               
         [ StructLayout ( LayoutKind.Sequential ) ]
            public struct DRAWITEMSTRUCT 
         {
            public UInt32 CtlType ;
            public UInt32 CtlID ;
            public UInt32 itemID ;
            public UInt32 itemAction ;
            public UInt32 itemState ;
            public IntPtr hwndItem ;
            public IntPtr hDC ;
            public RECT rcItem ;
            public IntPtr itemData ;
         } 
               
               
         [ StructLayout ( LayoutKind.Sequential ) ]
            public  struct MEASUREITEMSTRUCT 
         {
            public UInt32 CtlType ;
            public UInt32 CtlID ;
            public UInt32 itemID ;
            public UInt32 itemWidth ;
            public UInt32 itemHeight ;
            public IntPtr itemData ;
         }
               
               
         [ StructLayout ( LayoutKind.Sequential ) ]
         public class SCROLLINFO 
         {
            public SCROLLINFO ( )
            {
               cbSize = Marshal.SizeOf(typeof(SCROLLINFO));
               fMask  = 0 ;
               nMin = 0 ;
               nMax = 0 ;
               nPage = 0 ;
               nPos = 0 ;
               nTrackPos = 0 ;
            }
            
            public Int32 cbSize ;
            public UInt32 fMask ;
            public int nMin ;
            public int nMax ;
            public UInt32 nPage ;
            public int nPos ;
            public int nTrackPos ;
         }
               
               
         [StructLayout(LayoutKind.Sequential)]
            public struct LVCOLUMNW 
         {
            public UInt32 mask;
            public int fmt;
            public int cx;
            [ MarshalAs ( UnmanagedType.LPWStr ) ] public string pszText;
            public int cchTextMax;
            public int iSubItem;
            public int iImage;
            public int iOrder;
         }
               
               
         [ StructLayout ( LayoutKind.Sequential ) ]
            public struct LVITEMW 
         { 
            public uint mask ;
            public int iItem ;
            public int iSubItem ;
            public uint state ;
            public uint stateMask ;
            public IntPtr pszText ;
            public int cchTextMax ;
            public int iImage ;
            public IntPtr lParam ;
            public int iIndent ;
         }


               
         [ StructLayout ( LayoutKind.Sequential ) ]
         public struct LVDISPINFOW32
         {
            public NMHDR32 hdr ;
            public LVITEMW item ;
         }
         
         [ StructLayout ( LayoutKind.Sequential ) ]
         public struct LVDISPINFOW64
         {
            public NMHDR64 hdr ;
            public LVITEMW item ;
         }
               
               
         [ StructLayout ( LayoutKind.Sequential ) ]
         public struct NMHDR32
         { 
            public IntPtr hwndFrom ;  
            public UInt32 idFrom ; 
            public UInt32 code ; 
         }
         
         [ StructLayout ( LayoutKind.Sequential ) ]
            public struct NMHDR64
         { 
            public IntPtr hwndFrom ;  
            public UInt64 idFrom ; 
            public UInt32 code ; 
         }
               
               
         [ StructLayout ( LayoutKind.Sequential ) ]
            public struct NMLISTVIEW32
         {
            public NMHDR32 hdr ;
            public int iItem ;
            public int iSubItem ;
            public uint uNewState ;
            public uint uOldState ;
            public uint uChanged ;
            public POINTS ptAction ;
            public IntPtr lParam ;
         }
         
         [ StructLayout ( LayoutKind.Sequential ) ]
         public struct NMLISTVIEW64
         {
            public NMHDR64 hdr ;
            public int iItem ;
            public int iSubItem ;
            public uint uNewState ;
            public uint uOldState ;
            public uint uChanged ;
            public POINTS ptAction ;
            public IntPtr lParam ;
         }
               
            
      #endregion
         
      #region Callbacks
         
         public delegate IntPtr WndProcHandler ( IntPtr hWnd, 
                                                 int nMsg, 
                                                 IntPtr wParam, 
                                                 IntPtr lParam ) ;
                                                      
      #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
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
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
         
            private class Constants
            {
               public const string User32Dll             = "USER32.DLL" ;
               public const string EntryPointSendMessage = "SendMessage" ;
            }
            
         #endregion
         
         #region Data Types Definition
            
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
