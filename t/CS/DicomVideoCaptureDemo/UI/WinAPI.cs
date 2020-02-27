// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DicomVideoCaptureDemo.UI
{
   class WinAPI
   {
      [StructLayout(LayoutKind.Sequential)]
      public class SystemTime
      {
         public ushort Year;
         public ushort Month;
         public ushort DayOfWeek;
         public ushort Day;
         public ushort Hour;
         public ushort Minute;
         public ushort Second;
         public ushort Milliseconds;
      }

      [DllImport("kernel32.dll")]
      public static extern void GetSystemTime([In, Out] SystemTime lpSystemTime);

      [DllImport("kernel32.dll", EntryPoint = "SystemTimeToFileTime", SetLastError = true)]
      public static extern bool SystemTimeToFileTime([In] SystemTime lpSystemTime, ref FILETIME lpFileTime);

      [DllImport("kernel32.dll")]
      public static extern uint GetTickCount();

      public static ushort LOWORD(uint l)
      {
         return (ushort)(l & 0xffff);
      }

      public static ushort HIWORD(uint l)
      {
         return (ushort)((l>>16) & 0xffff);
      }

      public static string GenerateDicomUniqueIdentifier()
      {
         SystemTime systemTime = new SystemTime();
         FILETIME fileTime = new FILETIME();
         uint Tick;
         uint HighWord;
         Random rand = new Random();
         GetSystemTime(systemTime);
         SystemTimeToFileTime(systemTime,ref fileTime);
         Tick=GetTickCount();
         HighWord = (uint)fileTime.dwHighDateTime + 0x146BF4;

         return string.Format("1.2.840.114257.1.1{0:D010}{1:D05}{2:D05}{3:D05}{4:D05}{5:D05}{6:D05}",
            fileTime.dwLowDateTime,
            LOWORD(HighWord),
            HIWORD(HighWord |0x10000000),
            LOWORD((uint)rand.Next()),
            HIWORD(Tick),
            LOWORD(Tick),
            LOWORD((uint)rand.Next()));
      }
   }
}
