// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leadtools.Medical.WebViewerModels
{
   public class PingResponse
   {
      /// <summary>
      /// A simple message, for testing.
      /// </summary>
      public string message { get; set; }

      /// <summary>
      /// The current time, so the user may tell if it was cached.
      /// </summary>
      public DateTime time { get; set; }

      /// <summary>
      /// Whether or not the license was able to be checked.
      /// </summary>
      public bool isLicenseChecked { get; set; }

      /// <summary>
      /// Whether or not the license is expired.
      /// </summary>
      public bool isLicenseExpired { get; set; }

      /// <summary>
      /// The type of kernel - evaluation, for example.
      /// </summary>
      public string kernelType { get; set; }
   }
}
