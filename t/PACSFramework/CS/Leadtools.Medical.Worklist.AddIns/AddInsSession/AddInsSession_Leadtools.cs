// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Server.Admin;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.DicomDemos;
using Leadtools.Medical.Worklist.DataAccessLayer;
using Leadtools.Medical.Worklist.DataAccessLayer.Configuration;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Logging;
using System.Drawing;
using System.Reflection;
using System.IO;
using Leadtools.Dicom;
using Leadtools.Logging.Medical;

namespace Leadtools.Medical.Worklist.AddIns
{
   public partial class AddInsSession
   {
      public static void InitializeLicense()
      {
#if LEADTOOLS_V19_OR_LATER
         // do nothing
         if (RasterSupport.KernelExpired)
         {
            Leadtools.Demos.Support.SetLicense();
         }
#elif LEADTOOLS_V175_OR_LATER
         Leadtools.Demos.Support.SetLicense();
#else
         Leadtools.Demos.Support.Unlock ( false ) ;
#endif
      }

      public static bool IsLicenseValid()
      {         
         return true;
      }
   }

   public static class LoggerExtensions
   {
      public static void SystemMessage(this Logger logger, LogType type, string description, string aetitle)
      {
         try
         {
            string message = string.Format("[Worklist] {0}", description);

            logger.Log("Worklist", aetitle, string.Empty, -1, string.Empty, string.Empty,
                       -1, DicomCommandType.Undefined, DateTime.Now, type,
                       MessageDirection.None, message, null, null);
         }
         catch (Exception exception)
         {
            logger.Exception("Worklist", exception);
         }
      }
   }
}
