// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace SharePointDemo
{
   // The properties for the Share Point server we are connecting to
   public struct SharePointServerProperties
   {
      // The URL to the server
      public string Url;
      // Credentials to use
      public bool UseCredentials;
      public string UserName;
      public string Password;
      public string Domain;
      // Proxy settings
      public bool UseProxy;
      public string Host;
      public int Port;
   }
}
