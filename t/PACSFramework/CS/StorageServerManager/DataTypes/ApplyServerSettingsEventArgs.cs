// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Demos.StorageServer.DataTypes
{
   class ApplyServerSettingsEventArgs : EventArgs
   {
   }

   class ServerSettingsSecureChangedEventArgs : EventArgs
   {

      public ServerSettingsSecureChangedEventArgs(bool secureServer)
      {
         SecureServer = secureServer;
      }
      public bool SecureServer = false;


   }
}
