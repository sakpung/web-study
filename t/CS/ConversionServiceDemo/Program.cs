// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;
using Leadtools;
using Leadtools.Demos;

namespace ConversionServiceDemo
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      static void Main()
      {
         if (!Support.SetLicense())
            return;

         ServiceBase[] ServicesToRun;
         ServicesToRun = new ServiceBase[]
         {
            new ConversionService()
         };
         ServiceBase.Run(ServicesToRun);
      }
   }
}
