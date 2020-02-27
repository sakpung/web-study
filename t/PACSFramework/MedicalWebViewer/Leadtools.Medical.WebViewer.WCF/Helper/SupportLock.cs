// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Leadtools.Medical.WebViewer.Wcf.Helper
{
   static class SupportLock
   {
      static SupportLock ( ) 
      {
         license = ServiceUtils.MapConfigPath( ConfigurationManager.AppSettings [ "license" ] );
         key = ConfigurationManager.AppSettings [ "key" ] ;
      }
      
      static string license ;
      static string key ;
      static bool unlocked = false ;
      
      public static void Unlock ( ) 
      {
         if ( !unlocked )
         {
            if (!string.IsNullOrEmpty(key))
            {
               try
               {
                  Leadtools.RasterSupport.SetLicense(license, key);
#if LEADTOOLS_V19_OR_LATER
                  if(RasterSupport.KernelExpired)
                  {
                     System.Diagnostics.Debugger.Log(0, null, "*******************************************************************************" + Environment.NewLine);
                     System.Diagnostics.Debugger.Log(0, null, "*** NOTE: Your license file is missing, invalid or expired. LEADTOOLS will not function. Please contact LEAD Sales for information on obtaining a valid license.***" + Environment.NewLine);
                     System.Diagnostics.Debugger.Log(0, null, "*******************************************************************************" + Environment.NewLine);
                  }
#endif // #if LEADTOOLS_V19_OR_LATER
                  unlocked = !RasterSupport.KernelExpired;
               }
               catch
               {
               }
            }
            else
            {
               Demos.Support.SetLicense(true);
            }
         }
      }
   }
}
