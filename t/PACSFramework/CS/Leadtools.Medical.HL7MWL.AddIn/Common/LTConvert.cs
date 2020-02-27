// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Dicom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadtools.Medical.HL7MWL.AddIn
{
   internal static class LTConvert
   {
      public static Leadtools.Dicom.Common.DataTypes.DateRange ToDateRange(int? month, int? day, int? year)
      {
         if (!year.HasValue || !month.HasValue || !day.HasValue)
            return null;
         if (year.Value == 0 || month.Value == 0)
            return null;

         var drv = new Leadtools.Dicom.Common.DataTypes.DateRange()
         {
            StartDate = new DateTime(year.Value, month.Value, day.Value),
            EndDate = new DateTime(year.Value, month.Value, day.Value),
         };
         return drv;
      }

      public static DicomDateRangeValue? ToDicomDateRange(int? month, int? day, int? year)
      {
         if (!year.HasValue || !month.HasValue || !day.HasValue)
            return null;
         if(year.Value==0|| month.Value==0)
            return null;
         var dv = new DicomDateValue(year.Value, month.Value, day.Value);
         var drv = new DicomDateRangeValue(DicomRangeType.None, dv, dv);
         return drv;
      }

      public static DicomDateRangeValue? HL7DateToDicomDateRange(string date)
      {
         if (string.IsNullOrEmpty(date))
            return null;

         var date_components = ParseHL7Date(date);
         if (date_components[0] == -1)
            throw new ArgumentException("date parameter is malformed.");

         return ToDicomDateRange(date_components[1], date_components[2], date_components[0]);
      }

      public static Leadtools.Dicom.Common.DataTypes.DateRange HL7DateToDateRange(string date)
      {
         if (string.IsNullOrEmpty(date))
            return null;

         var date_components = ParseHL7Date(date);
         if (date_components[0] == -1)
            throw new ArgumentException("date parameter is malformed.");

         return ToDateRange(date_components[1], date_components[2], date_components[0]);
      }

      private static int[] ParseHL7Date(string dateString)
      {
         /*
          Function will return an array of integer values corresponding to different segments of time.  It is indexed as follows:
            0 - Year
            1 - Month
            2 - Day
            3 - Hour
            4 - Minute
            5 - Second
            6 - Timezone Offset 

            If the date is malformed, a -1 will be in the year index. 
         */
         string[] HL7SplitDate = dateString.Split('-');
         int timezone = 0;
         if (HL7SplitDate.Length > 1)
            timezone = Convert.ToInt32(HL7SplitDate[1]);

         dateString = HL7SplitDate[0];
         int length = dateString.Length;

         //Date is string is malformed
         if (length < 8)
            return new int[] { -1 };
         else
         {
            int year = Convert.ToInt32(dateString.Substring(0, 4));

            int month = Convert.ToInt32(dateString.Substring(4, 2));
            if (month < 1 || month > 12)
               return new int[] { -1 };

            int day = Convert.ToInt32(dateString.Substring(6, 2));
            if (day < 1 || month > 12)
               return new int[] { -1 };

            int hour = 0;
            int minute = 0;
            int second = 0;
            //Hours and Minutes have been specified
            if (length >= 12)
            {
               hour = Convert.ToInt32(dateString.Substring(8, 2));
               if (hour < 0 || hour > 59)
                  return new int[] { -1 };

               minute = Convert.ToInt32(dateString.Substring(10, 2));
               if (minute < 0 || minute > 59)
                  return new int[] { -1 };

               if (length >= 14)
               {
                  second = Convert.ToInt32(dateString.Substring(12, 2));
                  if (second < 0 || second > 59)
                     return new int[] { -1 };
               }

            }
            return new int[] { year, month, day, hour, minute, second, timezone };
         }
      }
   }
}
