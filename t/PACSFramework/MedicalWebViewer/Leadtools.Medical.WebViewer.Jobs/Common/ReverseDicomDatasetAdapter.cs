// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;

namespace Leadtools.Medical.WebViewer.Jobs
{
   class ReverseDicomDatasetAdapter
   {
      public Dicom.DicomDataSet query = new Dicom.DicomDataSet();

      public ReverseDicomDatasetAdapter()
      {
      }

      string GetStringValue(long tag, bool tree)
      {
         if (null == query)
         {
            return "";
         }

         DicomElement element;

         element = query.FindFirstElement(null, tag, tree);
         if (element != null)
         {
            if (query.GetElementValueCount(element) > 0)
            {
               return query.GetConvertValue(element);
            }
         }

         return "";
      }

      string GetStringValue(long tag)
      {
         return GetStringValue(tag, true);
      }

      public string PatientID
      {
         get
         {
            return GetStringValue(DicomTag.PatientID);
         }
      }
      public string StudyInstanceUID
      {
         get
         {
            return GetStringValue(DicomTag.StudyInstanceUID);
         }
      }
      public string SeriesInstanceUID
      {
         get
         {
            return GetStringValue(DicomTag.SeriesInstanceUID);
         }
      }
      public string SOPInstanceUID
      {
         get
         {
            return GetStringValue(DicomTag.SOPInstanceUID);
         }
      }
      
   }
}
