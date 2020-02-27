// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Medical.WebViewer.Core.DataTypes.Common;

namespace Leadtools.Medical.WebViewer.DataContracts
{
   /// <summary>
   /// Contains the patient information for a Patient query
   /// </summary>
   [DataContract]
   public class PatientData
   {
      [DataMember]
      public string ID { get; set; }

      [DataMember]
      public string Name { get; set; }

      [DataMember]
      public string Sex { get; set; }

      [DataMember]
      public string Comments { get; set; }

      [DataMember]
      public string BirthDate { get; set; }

      [DataMember]
      public string NumberOfRelatedStudies { get; set; }

      [DataMember]
      public string NumberOfRelatedSeries { get; set; }

      [DataMember]
      public string NumberOfRelatedInstances { get; set; }

#if (LEADTOOLS_V19_OR_LATER)
      [DataMember]
      public string EthnicGroup { get; set; }

      public void Print()
      {
         Console.WriteLine("PatientData.ID: " + ID.ToStringNull());
         Console.WriteLine("PatientData.Name: " + Name.ToStringNull());
         Console.WriteLine("PatientData.Sex: " + Sex.ToStringNull());
         Console.WriteLine("PatientData.Comments: " + Comments.ToStringNull());
         Console.WriteLine("PatientData.BirthDate: " + BirthDate.ToStringNull());
         Console.WriteLine("PatientData.NumberOfRelatedStudies: " + NumberOfRelatedStudies.ToStringNull());
         Console.WriteLine("PatientData.NumberOfRelatedSeries: " + NumberOfRelatedSeries.ToStringNull());
         Console.WriteLine("PatientData.NumberOfRelatedInstances: " + NumberOfRelatedInstances.ToStringNull());
         Console.WriteLine("PatientData.EthnicGroup: " + EthnicGroup.ToStringNull());
      }
#endif
   }
}
