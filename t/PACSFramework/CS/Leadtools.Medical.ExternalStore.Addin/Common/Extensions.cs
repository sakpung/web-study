// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Dicom;

namespace Leadtools.Medical.ExternalStore.Addin
{
   /// <summary>
   /// 
   /// </summary>
   public static class Extensions
   {

      private const string _addinName = "ExternalStore";
      /// <summary>
      /// Sends a system message.
      /// </summary>
      /// <param name="logger">The logger.</param>
      /// <param name="type">The type.</param>
      /// <param name="description">The description.</param>
      /// <param name="aetitle">The aetitle.</param>
      /// <param name="dataset">The dataset.</param>
      /// <param name="customInformation">The custom information.</param>
      public static void SystemMessage(this Logger logger, LogType type, string description, string aetitle, DicomDataSet dataset, SerializableDictionary<string, object> customInformation)
      {
         try
         {
            string message = string.Format("[{0}] {1}", AddinGlobals.Name, description);
            logger.Log(_addinName, aetitle, string.Empty, -1, string.Empty, string.Empty,
                       -1, DicomCommandType.Undefined, DateTime.Now, type,
                       MessageDirection.None, message, dataset, customInformation);
         }
         catch (Exception exception)
         {
            logger.Exception(_addinName, exception);
         }
      }

      /// <summary>
      /// Sends a system message.
      /// </summary>
      /// <param name="logger">The logger.</param>
      /// <param name="type">The type.</param>
      /// <param name="description">The description.</param>
      /// <param name="aetitle">The aetitle.</param>
      public static void SystemMessage(this Logger logger, LogType type, string description, string aetitle)
      {
         try
         {
            string message = string.Format("[{0}] {1}", AddinGlobals.Name, description);
            logger.Log(_addinName, aetitle, string.Empty, -1, string.Empty, string.Empty,
                       -1, DicomCommandType.Undefined, DateTime.Now, type,
                       MessageDirection.None, message, null, null);
         }
         catch (Exception exception)
         {
            logger.Exception(_addinName, exception);
         }
      } 

      public static void SystemLogException(this Logger logger, Exception e, string serviceName)
      {
         string message = string.Format("{0}", e.Message);
         Logger.Global.SystemMessage(LogType.Error, message, serviceName);
      }
   }   

   internal static class AddinGlobals
   {
      public static readonly string Name = "ExternalStore";
      public static readonly string NameInBrackets = "[ExternalStore]";
   }
}
