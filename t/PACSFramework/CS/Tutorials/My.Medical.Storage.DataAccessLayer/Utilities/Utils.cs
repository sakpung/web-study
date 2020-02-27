// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Leadtools.Dicom;
using System.Globalization;

namespace My.Medical.Storage.DataAccessLayer
{
   public static class MyUtils
   {
      public static string GetDateString(this DataRow row, string dateFieldName)
      {
         DateTime dateTime = new DateTime();
         try
         {
            if (row[dateFieldName] is DateTime)
            {
               dateTime = (DateTime)row[dateFieldName];
            }
         }
         catch (Exception)
         {
         }

         return dateTime.ToShortDateString();
      }

      public static string GetIntegerString(this DataRow row, string dateFieldName)
      {
         int? nValue = null;
         try
         {
            nValue = (int)row[dateFieldName];
         }
         catch (Exception)
         {
         }

         if (nValue != null)
            return nValue.ToString();
         else
            return string.Empty;
      }

      public static int? MyGetIntValue(this DicomDataSet ds, long tag)
      {
         DicomElement element = ds.FindFirstElement(null, tag, true);

         if (null == element || element.Length == 0)
         {
            return null;
         }
         else
         {
            int[] values;


            values = ds.GetIntValue(element, 0, 1);

            if (values != null && values.Length > 0)
            {
               return values[0];
            }
            else
            {
               return null;
            }
         }
      }

      public static string MyGetStringValue(this DicomDataSet ds, long tag, bool autoTruncate, int maxLength)
      {
         DicomElement element = ds.FindFirstElement(null, tag, true);

         if (null == element || element.Length == 0)
         {
            return null;
         }
         else
         {
            if (autoTruncate && element.Length > maxLength)
            {
               return ds.GetConvertValue(element).Substring(0, maxLength);
            }
            else
            {
               return ds.GetConvertValue(element);
            }
         }
      }
      
      // Helper function that gets the corresponding string of a DICOM tag from a DICOM dataset
      public static string MyGetStringValue(this DicomDataSet ds, long tag)
      {
         //DicomElement element = ds.FindFirstElement(null, tag, true);

         //if (null == element || element.Length == 0)
         //{
         //   return null;
         //}
         //else
         //{
         //   return ds.GetConvertValue(element);
         //}
         return MyGetStringValue(ds, tag, false, 0);
      }

      public static DateTime? MyGetDateTime(this DicomDataSet ds, long dicomDate, long dicomTime)
      {
         DateTime? dateValue = null;
         DateTime? timeValue = null;
         DicomElement element = null;
         if (dicomDate != 0)
         {
            element = ds.FindFirstElement(null, dicomDate, true);
         }

         if (null == element || element.Length == 0)
         {
            dateValue = null;
         }
         else
         {
            byte[] dateByte = ds.GetBinaryValue(element, (int)element.Length);

            string dateString = System.Text.ASCIIEncoding.ASCII.GetString(dateByte);

            DateTime date;

            string format = "yyyyMMdd";

            if (dateString.Length > 8)
            {
               dateString.Substring(0, 8);
            }

            if (!string.IsNullOrEmpty(dateString) && DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
               dateValue = date;
            }
         }


         element = null;

         if (dicomTime != 0)
         {
            element = ds.FindFirstElement(null, dicomTime, true);
         }

         if (null == element || element.Length == 0)
         {
            timeValue = null;
         }
         else
         {
            byte[] timeByte = ds.GetBinaryValue(element, (int)element.Length);
            string timeString = System.Text.ASCIIEncoding.ASCII.GetString(timeByte);

            DateTime time;

            if (timeString.Length > 6)
            {
               timeString = timeString.Substring(0, 6);
            }
            else if (timeString.Length < 6)
            {
               timeString = timeString.PadRight(6, '0');
            }

            if (!string.IsNullOrEmpty(timeString) && DateTime.TryParseExact(timeString, "HHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
            {
               timeValue = time;
            }
         }

         if (null != dateValue)
         {
            if (null != timeValue)
            {
               return new DateTime(dateValue.Value.Year,
                                     dateValue.Value.Month,
                                     dateValue.Value.Day,
                                     timeValue.Value.Hour,
                                     timeValue.Value.Minute,
                                     timeValue.Value.Second);


            }
            else
            {
               return new DateTime(dateValue.Value.Year,
                                     dateValue.Value.Month,
                                     dateValue.Value.Day);
            }
         }
         else if (null != timeValue)
         {
            return new DateTime(DateTime.Now.Year,
                                  DateTime.Now.Month,
                                  DateTime.Now.Day,
                                  timeValue.Value.Hour,
                                  timeValue.Value.Minute,
                                  timeValue.Value.Second);
         }
         else
         {
            return null;
         }
      }

      public static TimeSpan? MyGetTime(this DicomDataSet ds, long dicomTime)
      {
         TimeSpan? timeValue = null;
         DicomElement element = null;

         if (dicomTime != 0)
         {
            element = ds.FindFirstElement(null, dicomTime, true);
         }

         if (null == element || element.Length == 0)
         {
            timeValue = null;
         }
         else
         {
            byte[] timeByte = ds.GetBinaryValue(element, (int)element.Length);
            string timeString = System.Text.ASCIIEncoding.ASCII.GetString(timeByte);

            DateTime time;

            if (timeString.Length > 6)
            {
               timeString = timeString.Substring(0, 6);
            }
            else if (timeString.Length < 6)
            {
               timeString = timeString.PadRight(6, '0');
            }

            if (!string.IsNullOrEmpty(timeString) && DateTime.TryParseExact(timeString, "HHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out time))
            {
               timeValue = new TimeSpan(time.Hour, time.Minute, time.Second, time.Millisecond);
            }
         }
         return timeValue;
      }
   }
}
