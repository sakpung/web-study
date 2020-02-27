// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Logging;
using Leadtools.Dicom;
using Leadtools.Logging.Medical;

namespace Leadtools.Medical.SearchOtherPatientId.Addin.Common
{
   public static class Extensions
   {
      private const string _addinName = "Leadtools.Medical.SearchOtherPatientId.Addin";

      public static void SystemMessage(this Logger logger, LogType type, string description, string aetitle, DicomDataSet dataset, SerializableDictionary<string, object> customInformation)
      {
         try
         {
            string message = string.Format("[{0}] {1}", _addinName, description);
            logger.Log(_addinName, aetitle, string.Empty, -1, string.Empty, string.Empty,
                       -1, DicomCommandType.Undefined, DateTime.Now, type,
                       MessageDirection.None, message, dataset, customInformation);
         }
         catch (Exception exception)
         {
            logger.Exception(_addinName, exception);
         }
      }

       public static void SystemMessage(this Logger logger, LogType type, string description, SerializableDictionary<string, object> customInformation)
       {
          try
          {
             string message = string.Format("[{0}] {1}", _addinName, description);
             logger.Log(_addinName, Module.Server.AETitle, Module.Server.PeerAddress, Module.Server.Port, string.Empty, string.Empty,
                        -1, DicomCommandType.Undefined, DateTime.Now, type,
                        MessageDirection.None, message, null, customInformation);
          }
          catch (Exception exception)
          {
             logger.Exception(_addinName, exception);
          }
       }

       public static void SystemMessage(this Logger logger, LogType type, string description)
       {
          try
          {
             SystemMessage(logger, type, description, null);
          }
          catch (Exception exception)
          {
             logger.Exception(_addinName, exception);
          }
       }
   }
}
