// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.WebViewer.ImageDownloadAddin
{
   //Add this class to your Jobs project so it would be common for both the Service Add-in sending the request and the DICOM Add-in receiving the request
   public class CustomUID
   {
      //Those are custom class UIDs that identify our custom DICOM Message
      public const string DownloadImagesClass    = "1.2.840.114257.17.2.1";
      public const string DownloadImagesInstance = "1.2.840.114257.17.2.1.100.1";
   }

   public class CustomTags
   {
      public const Int64 JobID = 0x00171201;
   }
}
