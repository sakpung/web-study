// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Dicom;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadtools.Medical.Security.AddIn
{
   public static class Extensions
   {
      public static void SystemMessage(this Logger logger, LogType type, string description, string aetitle, DicomDataSet dataset, SerializableDictionary<string, object> customInformation)
      {
         try
         {
            logger.Log("[DicomSecurity]", aetitle, string.Empty, -1, string.Empty, string.Empty,
                       -1, DicomCommandType.Undefined, DateTime.Now, type,
                       MessageDirection.None, description, dataset, customInformation);
         }
         catch (Exception exception)
         {
            logger.Exception("[DicomSecurity]", exception);
         }
      }


      public static void SystemMessage(this Logger logger, LogType type, string description, string aetitle)
      {
         try
         {
            logger.Log("[DicomSecurity]", aetitle, string.Empty, -1, string.Empty, string.Empty,
                       -1, DicomCommandType.Undefined, DateTime.Now, type,
                       MessageDirection.None, description, null, null);
         }
         catch (Exception exception)
         {
            logger.Exception("[DicomSecurity]", exception);
         }
      }

   }
}
