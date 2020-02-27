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
   public class MyPatient :CatalogEntity
   {
      public override string CatalogKey
      {
         get
         {
            // return "Patient" ;
            return "PatientTableEntityKey" ;
         }
      }
      
      #region Constructors
         public MyPatient()
         {
         
         }
         
         public MyPatient ( string patientID )
         {
            PatientIdentification = patientID ;
         }
         
      #endregion
      
       #region Public Properties
      
         [EntityElementAttribute]
         public string PatientIdentification
         {
            get;
            set;
         }
         
         [EntityElementAttribute]
         public string PatientName
         {
            get;
            set;
         }
         
         
         [EntityElementAttribute]
         public DateRange PatientBirthday
         {
            get;
            set;
         }
         
         [EntityElementAttribute]
         public string PatientSex
         {
            get;
            set;
         }
         
         [EntityElementAttribute]
         public string PatientComments
         {
            get;
            set;
         }

         #endregion
   }
}
