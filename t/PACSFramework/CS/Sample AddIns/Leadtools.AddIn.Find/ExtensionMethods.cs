// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom;

namespace Leadtools.AddIn.Store
{
    public static class ExtensionMethods
    {
        public static bool HasTag(DicomDataSet ds,long Tag)
        {
            DicomElement element;

            element = ds.FindFirstElement(null, Tag, false);
            return (element != null);
        }

        public static DicomExceptionCode InsertKeyElement(DicomDataSet response, DicomDataSet request, long Tag)
        {
            DicomExceptionCode ret = DicomExceptionCode.Success;
            DicomElement element;

            try
            {
                element = request.FindFirstElement(null, Tag, true);
                if (element != null)
                {
                    response.InsertElement(null, false, Tag, DicomVRType.UN, false, 0);
                }
            }
            catch (DicomException de)
            {
                ret = de.Code;
            }

            return ret;
        }              

        /// <summary>
        /// Clears the specified dataset.
        /// </summary>
        /// <param name="ds">The ds.</param>
        public static void Clear(DicomDataSet ds)
        {
            DicomElement element = ds.GetFirstElement(null, false, true);

            while (element != null)
            {
                ds.SetConvertValue(element, string.Empty, 1);
                element = ds.GetNextElement(element, false, true);
            }
        }

        /// <summary>
        /// Gets the binary value.
        /// </summary>
        /// <param name="ds">The dataset.</param>
        /// <param name="Tag">The tag to get binary data from.</param>
        /// <returns></returns>
        public static byte[] GetBinaryValue(DicomDataSet ds,long Tag)
        {
            DicomElement element;

            element = ds.FindFirstElement(null, Tag, true);
            if (element != null)
            {
                if (element.Length > 0)
                {
                    return ds.GetBinaryValue(element, (int)element.Length);
                }
            }

            return null;
        }


       public static DicomDateRangeValue[] GetDateRange(DicomDataSet ds, long Tag)
       {
          // Get the date range count
          List<string> dateList = ds.GetValue<List<string>>(Tag, null);

          if (dateList == null)
             return null;

          int count = dateList.Count;

          if (count <= 0)
             return null;

          DicomDateRangeValue[] d = new DicomDateRangeValue[count];

          DicomElement element = ds.FindFirstElement(null, Tag, true);
          if (element != null)
          {
             if (element.Length > 0)
             {
                for (int i = 0; i < count; i++)
                   d[i] = ds.GetDateRangeValue(element, i);
                return d;
             }
          }

          return null;
       }

       public static DicomTimeRangeValue[] GetTimeRange(DicomDataSet ds, long Tag)
       {
          // Get the date range count
          List<string> timeList = ds.GetValue<List<string>>(Tag, null);

          if (timeList == null)
             return null;

          int count = timeList.Count;

          if (count <= 0)
             return null;

          DicomTimeRangeValue[] d = new DicomTimeRangeValue[count];

          DicomElement element = ds.FindFirstElement(null, Tag, true);
          if (element != null)
          {
             if (element.Length > 0)
             {
                for (int i = 0; i < count; i++)
                   d[i] = ds.GetTimeRangeValue(element, i);
                return d;
             }
          }

          return null;
       }

    }
}
