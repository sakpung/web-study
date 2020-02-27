// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Leadtools.Annotations.WinForms
{
   public static class Win32
   {
      // Windows Messages defines
      public const Int32 WM_USER = 0x400;
      public const Int32 EM_FORMATRANGE = WM_USER + 57;
      public const Int32 EM_GETCHARFORMAT = WM_USER + 58;
      public const Int32 EM_SETCHARFORMAT = WM_USER + 68;

      public const int HORZSIZE = 4;
      public const int VERTSIZE = 6;
      public const int HORZRES = 8;
      public const int VERTRES = 10;
      public const int LOGPIXELSX = 88;
      public const int LOGPIXELSY = 90;

      public const int PFM_NUMBERING = 0x00000020;
      public const int PFM_NUMBERINGSTART = 0x00008000;// RE 3.0	

      public const int NULL_BRUSH = 5;

      [StructLayout(LayoutKind.Sequential, Pack = 1)]
      public struct ParaFormat2
      {
         public int cbSize;
         public int dwMask;
         public short wNumbering;
         public short wReserved;
         public int dxStartIndent;
         public int dxRightIndent;
         public int dxOffset;
         public short wAlignment;
         public short cTabCount;
         [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
         public int[] rgxTabs;
         public int dySpaceBefore;
         public int dySpaceAfter;
         public int dyLineSpacing;
         public short sStyle;
         public byte bLineSpacingRule;
         public byte bOutlineLevel;
         public short wShadingWeight;
         public short wShadingStyle;
         public short wNumberingStart;
         public short wNumberingStyle;
         public short wNumberingTab;
         public short wBorderSpace;
         public short wBorderWidth;
         public short wBorders;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct CHARRANGE
      {
         public Int32 cpMin;
         public Int32 cpMax;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct FORMATRANGE
      {
         public IntPtr hdc;
         public IntPtr hdcTarget;
         public RECT rc;
         public RECT rcPage;
         public CHARRANGE chrg;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct RECT
      {
         public Int32 left;
         public Int32 top;
         public Int32 right;
         public Int32 bottom;
      }

      [StructLayout(LayoutKind.Sequential)]
      public struct FINDREPLACE
      {
         public Int32 lStructSize;
         public IntPtr hwndOwner;
         public IntPtr hInstance;
         [CLSCompliant(false)]
         public FindReplaceFlags Flags;
         public IntPtr lpstrFindWhat;
         public IntPtr lpstrReplaceWith;
         [CLSCompliant(false)]
         public UInt16 wFindWhatLen;
         [CLSCompliant(false)]
         public UInt16 wReplaceWithLen;
         public IntPtr lCustData;
         public IntPtr lpfnHook;
         public IntPtr lpTemplateName;
      }

      [CLSCompliant(false)]
      [Flags]
      public enum FindReplaceFlags : uint
      {
         FR_DOWN = 0x00000001,
         FR_WHOLEWORD = 0x00000002,
         FR_MATCHCASE = 0x00000004,
         FR_FINDNEXT = 0x00000008,
         FR_REPLACE = 0x00000010,
         FR_REPLACEALL = 0x00000020,
         FR_DIALOGTERM = 0x00000040,
         FR_SHOWHELP = 0x00000080,
         FR_ENABLEHOOK = 0x00000100,
         FR_ENABLETEMPLATE = 0x00000200,
         FR_NOUPDOWN = 0x00000400,
         FR_NOMATCHCASE = 0x00000800,
         FR_NOWHOLEWORD = 0x00001000,
         FR_ENABLETEMPLATEHANDLE = 0x00002000,
         FR_HIDEUPDOWN = 0x00004000,
         FR_HIDEMATCHCASE = 0x00008000,
         FR_HIDEWHOLEWORD = 0x00010000,
         FR_RAW = 0x00020000,
         FR_MATCHDIAC = 0x20000000,
         FR_MATCHKASHIDA = 0x40000000,
         FR_MATCHALEFHAMZA = 0x80000000
      }
   }
}
