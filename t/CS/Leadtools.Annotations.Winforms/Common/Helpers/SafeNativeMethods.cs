// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Leadtools.Annotations.WinForms
{
   public static class SafeNativeMethods
   {
      [DllImport("gdi32")]
      public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

      [DllImport("gdi32")]
      public static extern int DeleteObject(IntPtr hObject);

      [DllImport("gdi32")]
      public static extern IntPtr GetStockObject(int fnObject);

      [DllImport("user32")]
      public static extern IntPtr SendMessage(IntPtr hWnd, Int32 msg, IntPtr wParam, IntPtr lParam);

      [DllImport("gdi32")]
      public static extern int DeleteMetaFile(IntPtr hmf);

      [DllImport("gdi32")]
      public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

      [DllImport("gdi32")]
      public static extern IntPtr CreateEnhMetaFile(IntPtr hdcRef, string lpFilename, [In] ref Win32.RECT lpRect, string lpDescription);

      [DllImport("gdi32")]
      public static extern IntPtr CloseEnhMetaFile(IntPtr hdc);

      [DllImport("gdi32")]
      public static extern int SetMapMode(IntPtr hdc, int mode);

      [DllImport("gdi32")]
      public static extern int SetBkMode(IntPtr hdc, int mode);

      [DllImport("kernel32", EntryPoint = "lstrlenW")]
      public static extern int lstrlen(IntPtr lpString);

      [DllImport("comdlg32")]
      public extern static IntPtr FindText(IntPtr frPtr);

      [DllImport("comdlg32")]
      public extern static IntPtr ReplaceText(IntPtr frPtr);

      [DllImport("user32")]
      [CLSCompliant(false)]
      public extern static uint RegisterWindowMessage(string message);

      [DllImport("user32")]
      public extern static IntPtr SetActiveWindow(IntPtr hWnd);

      [DllImport("user32")]
      public static extern int FillRect(IntPtr hDC, [In] ref Win32.RECT lprc, IntPtr hbr);
   }
}
