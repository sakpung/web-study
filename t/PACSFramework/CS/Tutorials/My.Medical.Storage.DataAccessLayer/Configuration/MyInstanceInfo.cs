// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;
using System.Data;
using Leadtools.Medical.Storage.DataAccessLayer.Interface;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Medical.Storage.DataAccessLayer;
using System.IO;

namespace My.Medical.Storage.DataAccessLayer
{
   /// <summary>
   /// Implements the IInstanceInfo interface to extract DICOM data from a System.Data.DataRow
   /// </summary>
   public  class  MyInstanceInfo : IInstanceInfo
   {
      public DicomDataSet LoadDicomDataSet(DataRow row)
      {
         return LoadDicomDataSet(row, DicomDataSetLoadFlags.LoadAndClose);
      }

      public DicomDataSet LoadDicomDataSet(DataRow row, DicomDataSetLoadFlags flags)
      {
         DicomDataSet dataSet = new DicomDataSet();

         string referencedFile = ReferencedFile(row);

         dataSet.Load(referencedFile, flags);
         return dataSet;
      }

      #region IInstanceInfo Members
      public  string ReferencedFile(DataRow row)
      {
         return row["ImageFilename"] as string;
      }

      #endregion

      #region IInstanceInfo Members

      public string GetElementValue(DataRow row, long tag)
      {
         string ret = string.Empty;

         switch (tag)
         {
            case DicomTag.SOPInstanceUID:
               ret = row["SOPInstanceUID"] as string;
               break;

            case DicomTag.InstanceNumber:
               ret = row.GetIntegerString("ImageImageNumber");
               break;

            case DicomTag.SOPClassUID:
               ret = row["ImageUniqueSOPClassUID"] as string;
               break;

            case DicomTag.Rows:
               ret = row.GetIntegerString("ImageRows");
               break;

            case DicomTag.Columns:
               ret = row.GetIntegerString("ImageColumns");
               break;

            case DicomTag.BitsAllocated:
               ret = row.GetIntegerString("ImageBitsAllocated");
               break;

            case DicomTag.SeriesInstanceUID:
            DataRow seriesRow = GetSeriesRow(row);
            if (seriesRow != null)
            {
               ret = seriesRow["SeriesSeriesInstanceUID"] as string;
            }
            break;

            case DicomTag.NumberOfFrames:
               using (DicomDataSet ds = LoadDicomDataSet(row, DicomDataSetLoadFlags.None)  )
               {
                  int numberOfFrames = ds.GetValue(DicomTag.NumberOfFrames, 1);
                  ret = numberOfFrames.ToString();
               }
            break;

            case DicomTag.StationName:
            case DicomTag.TransferSyntaxUID:
               ret = string.Empty;
               break;

            default:
               Console.WriteLine(string.Format("MyInstanceInfo.GetElementValue: Invalid Dicom Tag: {0}", tag.DicomTagToString()));
               ret = string.Empty;
               break;

            // ReceiveDate
            // RetrieveAETitle
         }
         return ret;
      }

      public DataRow GetSeriesRow(DataRow row)
      {
         return ((row.GetParentRow(row.Table.ParentRelations["FK_DImage_Series"])));
      }


      public DataRow[] GetReferencedImagesRows(DataRow row)
      {
         return new DataRow[0];
      }

#if (LEADTOOLS_V19_OR_LATER)
      public void DeleteDicomDataSet(DataRow row)
      {
         string referencedFile = ReferencedFile(row); 
         File.Delete(referencedFile);
      }

      public void DeleteDicomDataSetDirectory(DataRow row)
      {
         string referencedFile = ReferencedFile(row);
         if (!string.IsNullOrEmpty(referencedFile))
         {
            string directory = Path.GetDirectoryName(referencedFile);
            Directory.Delete(directory, true);
         }
      }

      public bool ExistsDicomDataSet(DataRow row)
      {
         string referencedFile = ReferencedFile(row);
         return File.Exists(referencedFile);
      }

      public string ExternalStoreGuid(DataRow row)
      {
         return string.Empty;
      }

      public void SaveDicomDataSet(DicomDataSet ds, string path, out string storeToken, out string externalStoreGuid, DicomDataSetSaveFlags flags)
      {
         storeToken = string.Empty;
         externalStoreGuid = string.Empty;
         ds.Save(path, flags);
      }

      public string StoreToken(DataRow row)
      {
         return string.Empty;
      }

      public void UpdateDicomDataSet(DicomDataSet ds, DataRow row, DicomDataSetSaveFlags flags)
      {
         string token = string.Empty;
         string referencedFile = RegisteredDataRows.InstanceInfo.ReferencedFile(row);
         if (File.Exists(referencedFile))
         {
            // Update the file only if it exists -- otherwise do nothing
            ds.Save(referencedFile, flags);
         }
      }
#endif // #if (LEADTOOLS_V19_OR_LATER)


      #endregion
   }
}
