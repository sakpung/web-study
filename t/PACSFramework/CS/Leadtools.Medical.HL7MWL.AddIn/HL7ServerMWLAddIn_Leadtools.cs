// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.IO;
using System.Reflection;
using System.Drawing;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   public partial class HL7ServerMWL 
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
