// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Leadtools.Medical.WebViewer.Common
{
   internal static class TimeStampProvider
   {
      private static DateTime? _timeStamp = null;
      static Object _synch = new Object();

      static TimeStampProvider()
      {
         LoadTimeStamp();
      }

      static string GetLocalConfigPathName()
      {
         var ServiceFolder = Path.GetDirectoryName(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
         return System.IO.Path.Combine(ServiceFolder, "Session.config");
      }
      public static void RefreshTimeStamp()
      {
         lock (_synch)
         {
            try
            {
               _timeStamp = DateTime.Now;

               string localConfigFile = GetLocalConfigPathName();

               File.WriteAllText(localConfigFile, _timeStamp.ToString());
            }
            catch
            {
               _timeStamp = null;
            }
         }
      }

      public static DateTime? GetTimeStamp()
      {
         lock (_synch)
         {
            DateTime? ret = null;

            if (_timeStamp.HasValue)
            {
               ret = _timeStamp.Value;
            }

            return ret;
         }
      }

      static void LoadTimeStamp()
      {
         lock (_synch)
         {
            try
            {
               _timeStamp = null;

               string localConfigFile = GetLocalConfigPathName();

               if (File.Exists(localConfigFile))
               {
                  var timestamp = File.ReadAllText(localConfigFile);
                  if (!string.IsNullOrEmpty(timestamp))
                  {
                     _timeStamp = DateTime.Parse(timestamp);
                  }
               }
            }
            catch
            {
               _timeStamp = null;
            }
         }
      }
   }
}
