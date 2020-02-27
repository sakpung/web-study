// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Demos.StorageServer.UI
{
   partial class GatewaySettingsPresenter
   {
      protected string[] GetAddIns()
      {
         return new string[] { "Leadtools.Medical.Gateway.AddIn.dll", "Leadtools.Medical.Storage.Addins.dll", "Leadtools.Medical.Security.Addin.dll" };
      }

      protected string[] GetConfigurationAddIns()
      {
         return new string[] { "Leadtools.Medical.Ae.Configuration.dll", "Leadtools.Medical.Logging.AddIn.dll", "Leadtools.Medical.License.Configuration.dll" };
      }
   }
}
