// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.ServiceProcess;
using ConversionServiceHelper;

namespace ConversionServiceDemo
{
   [RunInstaller(true)]
   public partial class ProjectInstaller : System.Configuration.Install.Installer
   {
      public ProjectInstaller()
      {
         InitializeComponent();
      }

      private void serviceProcessInstaller1_BeforeInstall(object sender, InstallEventArgs e)
      {
         serviceInstaller1.Description = Constants.ServiceDescription;
         serviceInstaller1.DisplayName = Constants.ServiceDisplayName;
         serviceInstaller1.ServiceName = Constants.ServiceName;
      }

      private void serviceInstaller1_BeforeUninstall(object sender, InstallEventArgs e)
      {
         serviceInstaller1.Description = Constants.ServiceDescription;
         serviceInstaller1.DisplayName = Constants.ServiceDisplayName;
         serviceInstaller1.ServiceName = Constants.ServiceName;
      }

      private void serviceInstaller1_Committed(object sender, InstallEventArgs e)
      {
         try
         {
            ServiceController sc = new ServiceController(Constants.ServiceName);
            sc.Start();
         }
         catch { }
      }
   }
}
