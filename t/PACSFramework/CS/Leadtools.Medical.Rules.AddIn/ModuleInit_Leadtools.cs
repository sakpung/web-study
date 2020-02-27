// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.IO;
using System.Reflection;
using System.Drawing;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Logging;

namespace Leadtools.Medical.Rules.AddIn
{
   public partial class Module
   {
      
      public static void InitializeLicense()
      {         
      }

      public static Icon GetAppIcon()
      {
         Icon icon;

         try
         {
            icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
         }
         catch
         {
            icon = null;
         }
         return icon;
      }

      public static bool IsLicenseValid()
      {         
         return true;
      }      
   }
}
