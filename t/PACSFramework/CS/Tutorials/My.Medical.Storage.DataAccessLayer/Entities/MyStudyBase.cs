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

namespace My.Medical.Storage.DataAccessLayer.Entities
{
   public class MyStudy : CatalogEntity
   {
      public override string CatalogKey
      {
         get
         {
            return "StudyTableEntityKey";
         }
      }

      public MyStudy()
      { }

      public MyStudy(string studyInstanceUID)
      {
         StudyStudyInstanceUID = studyInstanceUID;
      }

      #region Public Properties

      [EntityElementAttribute]
      public string StudyStudyInstanceUID
      {
         get;
         set;
      }

      [EntityElementAttribute]
      public DateRange StudyStudyDate
      {
         get;
         set;
      }

      [EntityElementAttribute]
      public string StudyAccessionNumber
      {
         get;
         set;
      }

      [EntityElementAttribute]
      public string StudyStudyDescription
      {
         get;
         set;
      }
      
      [EntityElementAttribute]
      public string StudyReferringPhysiciansName
      {
         get;
         set;
      }

      [EntityElementAttribute]
      public string StudyStudyId
      {
         get;
         set;
      }










      #endregion
   }
}
