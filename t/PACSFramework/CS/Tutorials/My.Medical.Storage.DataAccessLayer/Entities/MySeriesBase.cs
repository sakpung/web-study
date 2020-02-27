// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer.Catalog;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom;

namespace My.Medical.Storage.DataAccessLayer.Entities
{
   public class MySeries : CatalogEntity
   {
      public override string CatalogKey
      {
         get
         {
            return "SeriesTableEntityKey";
         }
      }

      public MySeries()
      { }

      public MySeries(string seriesInstanceUID)
      {
         SeriesSeriesInstanceUID = seriesInstanceUID;
      }

      public MySeries(Dictionary<long, object> values)
      {
         foreach(KeyValuePair<long, object> kvp in values)
         {
            switch(kvp.Key)
            {
               case DicomTag.SeriesInstanceUID:
                  SeriesSeriesInstanceUID = kvp.Value as string;
                  break;

               case DicomTag.Modality:
                  SeriesModality = kvp.Value as string;
                  break;

               case DicomTag.SeriesDescription:
                  SeriesSeriesDescription = kvp.Value as string;
                  break;

               //case DicomTag.InstitutionName:
               //   InstitutionName = kvp.Value as string;
               //   break;

               //case DicomTag.PerformedProcedureStepID:
               //   PerformedProcedureStepID = kvp.Value as string;
               //   break;

               //case DicomTag.BodyPartExamined:
               //   BodyPartExamined = kvp.Value as string;
               //   break;

               //case DicomTag.Laterality:
               //   Laterality = kvp.Value as string;
               //   break;

               //case DicomTag.ProtocolName:
               //   ProtocolName = kvp.Value as string;
               //   break;

               //case DicomTag.SendingApplicationEntityTitle:
               //   AETitle = kvp.Value as string;
               //   break;

               case DicomTag.SeriesDate:
                  SeriesSeriesDate = kvp.Value as DateRange;
                  break;

               //case DicomTag.PerformedProcedureStepStartDate:
               //   PerformedProcedureStepStartDate = kvp.Value as DateRange;
               //   break;

               case DicomTag.SeriesNumber:
                  SeriesSeriesNumber = kvp.Value as string;
                  break;
            }
         }
      }

      #region Public Properties

      [EntityElementAttribute]
      public string SeriesSeriesInstanceUID
      {
         get;
         set;
      }

      [EntityElementAttribute]
      public string SeriesSeriesNumber
      {
         get;
         set;
      }

      [EntityElementAttribute]
      public string SeriesSeriesDescription
      {
         get;
         set;
      }

      [EntityElementAttribute]
      public DateRange SeriesSeriesDate
      {
         get;
         set;
      }
      
      [EntityElementAttribute]
      public string SeriesModality
      {
         get;
         set;
      }
      #endregion
   }
}
