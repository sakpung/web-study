// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;

namespace SvgDemo
{
   internal static class SafeNativeMethods
   {
      public const int WS_BORDER = 0x00800000;
      public const int WS_EX_TRANSPARENT = 0x00000020;
      public const int WS_EX_CLIENTEDGE = 0x00000200;
      public const int WS_EX_COMPOSITED = 0x02000000;

      public const int WM_HSCROLL = 0x0114;
      public const int WM_VSCROLL = 0x0115;
      public const int WM_MOUSEWHEEL = 0x020A;

      public const int WM_NCHITTEST = 0x0084;
      public const int HTTRANSPARENT = -1;
      public const int HTCLIENT = 1;
   }
}
