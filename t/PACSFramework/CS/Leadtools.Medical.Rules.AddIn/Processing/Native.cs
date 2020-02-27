// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Leadtools.Medical.Rules.AddIn
{
   [StructLayout(LayoutKind.Sequential)]
   public struct CharacterRange
   {
      public int cpMin;
      public int cpMax;
   }

   [StructLayout(LayoutKind.Sequential)]
   public struct TextRange
   {
      public CharacterRange chrg;
      public IntPtr lpstrText;
   }

   [StructLayout(LayoutKind.Sequential)]
   public struct TextToFind
   {
      public CharacterRange chrg;			// range to search
      public IntPtr lpstrText;			// the search pattern (zero terminated)
      public CharacterRange chrgText;		// returned as position of matching text
   }

   /// <summary>
   /// Struct used for passing parameters to FormatRange()
   /// </summary>
   [StructLayout(LayoutKind.Sequential)]
   public struct RangeToFormat
   {
      /// <summary>
      /// The HDC (device context) we print to
      /// </summary>
      public IntPtr hdc;
      /// <summary>
      /// The HDC we use for measuring (may be same as hdc)
      /// </summary>
      public IntPtr hdcTarget;
      /// <summary>
      /// Rectangle in which to print
      /// </summary>
      public PrintRectangle rc;
      /// <summary>
      /// Physically printable page size
      /// </summary>
      public PrintRectangle rcPage;
      /// <summary>
      /// Range of characters to print
      /// </summary>
      public CharacterRange chrg;
   }

   /// <summary>
   /// Struct used for specifying the printing bounds
   /// </summary>
   [StructLayout(LayoutKind.Sequential)]
   public struct PrintRectangle
   {
      /// <summary>
      /// Left X Bounds Coordinate
      /// </summary>
      public int Left;
      /// <summary>
      /// Top Y Bounds Coordinate
      /// </summary>
      public int Top;
      /// <summary>
      /// Right X Bounds Coordinate
      /// </summary>
      public int Right;
      /// <summary>
      /// Bottom Y Bounds Coordinate
      /// </summary>
      public int Bottom;

      public PrintRectangle(int iLeft, int iTop, int iRight, int iBottom)
      {
         Left = iLeft;
         Top = iTop;
         Right = iRight;
         Bottom = iBottom;
      }
   }


   /// <summary>
   /// This matches the Win32 NMHDR structure
   /// </summary>
   [StructLayout(LayoutKind.Sequential)]
   public struct NotifyHeader
   {
      public IntPtr hwndFrom;	// environment specific window handle/pointer
      public IntPtr idFrom;	// CtrlID of the window issuing the notification      
      public uint code;		// The SCN_* notification code
   }

   [StructLayout(LayoutKind.Sequential)]
   public struct SCNotification
   {
      public NotifyHeader nmhdr;
      public int position;			// SCN_STYLENEEDED, SCN_MODIFIED, SCN_DWELLSTART, SCN_DWELLEND, 
      // SCN_CALLTIPCLICK, SCN_HOTSPOTCLICK, SCN_HOTSPOTDOUBLECLICK
      public char ch;					// SCN_CHARADDED, SCN_KEY
      public int modifiers;			// SCN_KEY
      public int modificationType;	// SCN_MODIFIED
      public IntPtr text;				// SCN_MODIFIED
      public int length;				// SCN_MODIFIED
      public int linesAdded;			// SCN_MODIFIED
      public int message;				// SCN_MACRORECORD
      public IntPtr wParam;			// SCN_MACRORECORD
      public IntPtr lParam;			// SCN_MACRORECORD
      public int line;				// SCN_MODIFIED
      public int foldLevelNow;		// SCN_MODIFIED
      public int foldLevelPrev;		// SCN_MODIFIED
      public int margin;				// SCN_MARGINCLICK
      public int listType;			// SCN_USERLISTSELECTION
      public int x;					// SCN_DWELLSTART, SCN_DWELLEND
      public int y;					// SCN_DWELLSTART, SCN_DWELLEND
   }

   [Serializable, StructLayout(LayoutKind.Sequential)]
   public struct RECT
   {
      public int Left;
      public int Top;
      public int Right;
      public int Bottom;

      public RECT(int left_, int top_, int right_, int bottom_)
      {
         Left = left_;
         Top = top_;
         Right = right_;
         Bottom = bottom_;
      }

      public int Height { get { return Bottom - Top; } }
      public int Width { get { return Right - Left; } }
      public Size Size { get { return new Size(Width, Height); } }

      public Point Location { get { return new Point(Left, Top); } }

      // Handy method for converting to a System.Drawing.Rectangle
      public Rectangle ToRectangle()
      { return Rectangle.FromLTRB(Left, Top, Right, Bottom); }

      public static RECT FromRectangle(Rectangle rectangle)
      {
         return new RECT(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
      }

      public override int GetHashCode()
      {
         return Left ^ ((Top << 13) | (Top >> 0x13))
           ^ ((Width << 0x1a) | (Width >> 6))
           ^ ((Height << 7) | (Height >> 0x19));
      }

      #region Operator overloads

      public static implicit operator Rectangle(RECT rect)
      {
         return rect.ToRectangle();
      }

      public static implicit operator RECT(Rectangle rect)
      {
         return FromRectangle(rect);
      }

      #endregion
   } 

   internal static class NativeMethods
   {
      internal const int WM_DROPFILES = 0x0233;
      internal const int WM_NOTIFY = 0x004e;
      internal const int WM_PAINT = 0x000F;
      internal const int WM_HSCROLL = 0x114;
      internal const int WM_VSCROLL = 0x115;
      internal const int WM_DESTROY = 0x02;
      internal const int WM_GETTEXT = 0x000D;
      internal const int WM_GETTEXTLENGTH = 0x000E;
      internal const int WM_SETCURSOR = 0x0020;
      internal const int WM_USER = 0x0400;
      internal const int WM_REFLECT = WM_USER + 0x1C00;

      internal const int ERROR_MOD_NOT_FOUND = 126;
      internal static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);



      [DllImport("user32.dll")]
      internal static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

      [DllImport("user32.dll")]
      internal static extern bool GetUpdateRect(IntPtr hWnd, out RECT lpRect, bool bErase);

      [DllImport("shell32.dll", CharSet = CharSet.Auto)]
      internal static extern uint DragQueryFile(IntPtr hDrop, uint iFile, [Out] StringBuilder lpszFile, uint cch);

      [DllImport("shell32.dll")]
      internal static extern int DragFinish(IntPtr hDrop);

      [DllImport("shell32.dll")]
      internal static extern void DragAcceptFiles(IntPtr hwnd, bool accept);

      [DllImport("kernel32", SetLastError = true)]
      internal extern static IntPtr LoadLibrary(string lpLibFileName);
   }
}
