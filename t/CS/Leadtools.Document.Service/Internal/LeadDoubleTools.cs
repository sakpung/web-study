// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System;

namespace Leadtools.Document.Service.Internal
{
   internal class LeadDoubleTools
   {
      public static bool IsZero(double value)
      {
         return Math.Abs(value) < 2.2204460492503131E-15;
      }

      public static bool IsNaN(double value)
      {
         return Double.IsNaN(value);
      }

      public static bool IsInfinity(double value)
      {
         return Double.IsInfinity(value);
      }

      public static double NaN = Double.NaN;
   }
}
