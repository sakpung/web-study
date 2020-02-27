// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.WebViewer.Addins
{
   public class IBCoordinate
   {
      public double Left { get; set; }
      public double Top { get; set; }
      public double Right { get; set; }
      public double Bottom { get; set; }

      public List<double> ToList()
      {
         List<double> list = new List<double>();

         list.Add(Left);
         list.Add(Top);
         list.Add(Right);
         list.Add(Bottom);
         return list;
      }
   }
}
