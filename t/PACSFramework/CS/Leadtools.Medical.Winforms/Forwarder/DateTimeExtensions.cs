// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms.Forwarder
{
   public static class DateTimeExtensions
   {
      public static DateTime StartOfWeek(this DateTime dt)
      {
         int DaysToSubtract = (int)dt.DayOfWeek;
         DateTime date = DateTime.Now.Subtract(TimeSpan.FromDays(DaysToSubtract));

         return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
      }

      public static DateTime EndOfWeek(this DateTime dt)
      {
         DateTime date = dt.StartOfWeek().AddDays(6);

         return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
      }

      public static DateTime StartOfLastWeek(this DateTime date)
      {
         int DaysToSubtract = (int)date.DayOfWeek + 7;
         DateTime dt = date.Subtract(TimeSpan.FromDays(DaysToSubtract));

         return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
      }

      public static DateTime EndOfLastWeek(this DateTime date)
      {
         DateTime dt = date.StartOfLastWeek().AddDays(6);

         return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
      }

   }
}
