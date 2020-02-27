// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms
{
   public class PacsProduct
   {
      private static string _productName = "XXX";

      public static string ProductName
      {
         get { return PacsProduct._productName; }
         set { PacsProduct._productName = value; }
      }

      private static string _serviceName = "XXX";

      public static string ServiceName
      {
         get { return PacsProduct._serviceName; }
         set { PacsProduct._serviceName = value; }
      }
   }
}
