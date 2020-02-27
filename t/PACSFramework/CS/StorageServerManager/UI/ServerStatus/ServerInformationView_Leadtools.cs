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
   partial class ServerInformationView
   {
      public void ShowAbout()
      {
         AboutDialog dialogAbout = new AboutDialog("Storage Server Manager");

         dialogAbout.ShowDialog();
      }
   }
}
