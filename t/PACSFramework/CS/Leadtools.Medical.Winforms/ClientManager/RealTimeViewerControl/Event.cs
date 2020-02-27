// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Common;
using System.IO;

namespace Leadtools.Medical.Winforms.ClientManager
{   
   public class DisconnectClientEventArgs : EventArgs
   {
      private ClientInfo _ClientInfo;

      public ClientInfo ClientInfo
      {
         get
         {
            return _ClientInfo;
         }
      }

      public DisconnectClientEventArgs(ClientInfo clientInfo)
      {
         _ClientInfo = clientInfo;
      }
   }

    public static class Extensions
    {
        public static string ToReadableString(this TimeSpan span)
        {
            return string.Join(", ", span.GetReadableStringElements().Where(str => !string.IsNullOrEmpty(str)).ToArray());
        }        

        private static IEnumerable<string> GetReadableStringElements(this TimeSpan span)
        {
            yield return GetDaysString((int)Math.Floor(span.TotalDays));
            yield return GetHoursString(span.Hours);
            yield return GetMinutesString(span.Minutes);
            yield return GetSecondsString(span.Seconds);
            yield return GetMilliSecondsString(span.Milliseconds);
        }

        private static string GetDaysString(int days)
        {
            if (days == 0)
                return string.Empty;

            if (days == 1)
                return "1 day";

            return string.Format("{0:0} days", days);
        }

        private static string GetHoursString(int hours)
        {
            if (hours == 0)
                return string.Empty;

            if (hours == 1)
                return "1 hour";

            return string.Format("{0:0} hours", hours);
        }

        private static string GetMinutesString(int minutes)
        {
            if (minutes == 0)
                return string.Empty;

            if (minutes == 1)
                return "1 minute";

            return string.Format("{0:0} minutes", minutes);
        }

        private static string GetSecondsString(int seconds)
        {
            if (seconds == 0)
                return string.Empty;

            if (seconds == 1)
                return "1 second";

            return string.Format("{0:0} seconds", seconds);
        }
        private static string GetMilliSecondsString(int ms)
        {
            if (ms == 0)
                return string.Empty;

            if (ms == 1)
                return "1 ms";

            return string.Format("{0:0} ms", ms);
        }

        public static MemoryStream ToStream(this string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }
    }
}
