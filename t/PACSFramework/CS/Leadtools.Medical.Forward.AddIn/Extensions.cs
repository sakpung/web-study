// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Logging;
using Leadtools.Logging.Medical;
using Leadtools.Dicom;

namespace Leadtools.Medical.Forwarder.AddIn
{
   /// <summary>
   /// 
   /// </summary>
   public static class Extensions
   {
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
            logger.Log("Forwarder", aetitle, string.Empty, -1, string.Empty, string.Empty,
                       -1, DicomCommandType.Undefined, DateTime.Now, type,
                       MessageDirection.None, description, dataset, customInformation);
         }
         catch (Exception exception)
         {
            logger.Exception("Forwarder", exception);
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
            logger.Log("Forwarder", aetitle, string.Empty, -1, string.Empty, string.Empty,
                       -1, DicomCommandType.Undefined, DateTime.Now, type,
                       MessageDirection.None, description, null, null);
         }
         catch (Exception exception)
         {
            logger.Exception("Forwarder", exception);
         }
      }

      // Multiplies a timespan by an integer value
      public static TimeSpan Multiply(this TimeSpan multiplicand, int multiplier)
      {
         return TimeSpan.FromTicks(multiplicand.Ticks * multiplier);
      }

      // Multiplies a timespan by a double value
      public static TimeSpan Multiply(this TimeSpan multiplicand, double multiplier)
      {
         return TimeSpan.FromTicks((long)(multiplicand.Ticks * multiplier));
      }
   }   
}
