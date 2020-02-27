// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;
using Leadtools.Medical.Storage.DataAccessLayer.Interface;
using System.Data;
using Leadtools.Dicom.Common.Extensions;

namespace My.Medical.Storage.DataAccessLayer
{
   /// <summary>
   /// Implements the ISeriesInfo interface to extract DICOM data from a System.Data.DataRow
   /// </summary>
   public  class MySeriesInfo : ISeriesInfo
   {

      #region ISeriesInfo Members

      public string GetElementValue(DataRow row, long tag)
      {
         string ret = string.Empty;

         switch (tag)
         {
            case DicomTag.SeriesInstanceUID:
               ret = row["SeriesSeriesInstanceUID"] as string;
               break;

            case DicomTag.BodyPartExamined:
               ret = row["SeriesBodyPartExamined"] as string;
               break;

            case DicomTag.SeriesNumber:
               ret = row.GetIntegerString("SeriesSeriesNumber");
               break;

            case DicomTag.SeriesDescription:
               ret = row["SeriesSeriesDescription"] as string;
               break;

            case DicomTag.SeriesDate:
               ret = row.GetDateString("SeriesSeriesDate");
               break;

            case DicomTag.StudyInstanceUID:
               {
                  DataRow studyRow = GetStudyRow(row);
                  if (studyRow != null)
                  {
                     ret = studyRow["StudyStudyInstanceUID"] as string;
                  }
               }
               break;

            case DicomTag.Modality:
               ret = row["SeriesModality"] as string;
               break;

            default:
               Console.WriteLine(string.Format("MySeriesInfo.GetElementValue: Invalid Dicom Tag: {0}", tag.DicomTagToString()));
               ret = string.Empty;
               break;
         }
         return ret;
      }

      public DataRow GetStudyRow(DataRow row)
      {
         return ((row.GetParentRow(row.Table.ParentRelations["FK_Series_Study"])));
      }

      #endregion
   }
}
