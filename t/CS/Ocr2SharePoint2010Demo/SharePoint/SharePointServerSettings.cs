// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocr2SharePointDemo.SharePoint
{
   public struct SharePointServerSettings
   {
      // The properties for the Share Point server we are connecting to
      // The URL to the server
      public string Uri;
      // Credentials to use, if UserName is null, credentials are not used
      public string UserName;
      public string Password;
      public string Domain;
      // Proxy settings, if Host is null, not used
      public string ProxyUri;
      public int ProxyPort;

      public static SharePointServerSettings Default
      {
         get
         {
            SharePointServerSettings obj = new SharePointServerSettings();
            return obj;
         }
      }
   }
}
