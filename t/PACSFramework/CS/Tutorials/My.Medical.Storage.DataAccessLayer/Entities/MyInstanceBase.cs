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
   public class MyInstance : CatalogEntity
   {
      public override string CatalogKey
      {
         get
         {
            return "InstanceTableEntityKey";
         }
      }

      public MyInstance(Dictionary<long, object> values)
      {
         foreach (KeyValuePair<long, object> kvp in values)
         {
            switch (kvp.Key)
            {
               case DicomTag.SOPInstanceUID:
                  SOPInstanceUID = kvp.Value as string;
                  break;

               //case DicomTag.TransferSyntaxUID:
               //   TransferSyntax = kvp.Value as string;
               //   break;

               case DicomTag.SOPClassUID:
                  ImageUniqueSOPClassUID = kvp.Value as string;
                  break;

               //case DicomTag.StationName:
               //   StationName = kvp.Value as string;
               //   break;


               //case DicomTag.RetrieveAETitle:
               //   RetrieveAETitle = kvp.Value as string;
               //   break;

               //case DicomTag.InstanceNumber:
               //   ImageImageNumber.Value = kvp.Value as int;
               //   break;

               //case DicomTag.ReceiveDate:
               //   ReceiveDate = kvp.Value as string;
               //   break;

               //case DicomTag.StoreAETitle:
               //   StoreAETitle = kvp.Value as string;
               //   break;

            }
         }
      }

      #region Constructors
      public MyInstance()
      {

      }

      public MyInstance(string sopInstanceUID)
      {
         SOPInstanceUID = sopInstanceUID;
      }

      #endregion

      #region Public Properties

      [EntityElementAttribute]
      public string SOPInstanceUID
      {
         get;
         set;
      }
      
     [EntityElementAttribute]
      public int? ImageImageNumber
      {
         get;
         set;
      }

      [EntityElementAttribute]
      public DateRange ImageLastStoreDate
      {
         get;
         set;
      }

      [EntityElementAttribute]
      public string ImageFilename
      {
         get;
         set;
      }
      
      [EntityElementAttribute]
      public string ImageUniqueSOPClassUID
      {
         get;
         set;
      }
      
      [EntityElementAttribute]
      public int? ImageRows
      {
         get;
         set;
      }
      
      [EntityElementAttribute]
      public int? ImageColumns
      {
         get;
         set;
      }
      
      [EntityElementAttribute]
      public int? ImageBitsAllocated
      {
         get;
         set;
      }


      #endregion
   }
}
