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
   /// Contains the Study information for a study level query
   /// </summary>
   [DataContract]
   public class StudyData
   {
      [DataMember]
      public string Date { get; set; }
      [DataMember]
      public string InstanceUID { get; set; }
      [DataMember]
      public string Id { get; set; }
      [DataMember]
      public string AccessionNumber { get; set; }
      [DataMember]
      public string ReferringPhysiciansName { get; set; }
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
      [DataMember]
      public string[] ModalitiesInStudy { get; set; }
      [DataMember]
      public int NumberOfRelatedSeries { get; set; }
      [DataMember]
      public int NumberOfRelatedInstances { get; set; }
      [DataMember]
      public string Description { get; set; }
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
      [DataMember]
      public string[] NameOfDoctorsReading { get; set; }
      [DataMember]
      public string AdmittingDiagnosesDescription { get; set; }
      [DataMember]
      public string Age { get; set; }
      [DataMember]
      public string Size { get; set; }
      [DataMember]
      public string Weight { get; set; }

      [DataMember]
      public string AdditionalPatientHistory { get; set; }

      [DataMember]
      public PatientData Patient { get; set; }

#if (LEADTOOLS_V19_OR_LATER)
      public void Print()
      {
         Console.WriteLine("StudyData.Date: " + Date.ToStringNull());
         Console.WriteLine("StudyData.InstanceUID: " + InstanceUID.ToStringNull());
         Console.WriteLine("StudyData.Id: " + Id.ToStringNull());
         Console.WriteLine("StudyData.accessionNumber: " + AccessionNumber.ToStringNull());
         Console.WriteLine("StudyData.referringPhysiciansName: " + ReferringPhysiciansName.ToStringNull());
         Console.WriteLine("StudyData.ModalitiesInStudy: " + ModalitiesInStudy);
         if (ModalitiesInStudy != null)
         {
            foreach (string m in ModalitiesInStudy)
            {
               Console.WriteLine("\t" + m);
            }
         }

         Console.WriteLine("StudyData.NumberOfRelatedSeries: " + NumberOfRelatedSeries);
         Console.WriteLine("StudyData.NumberOfRelatedInstances: " + NumberOfRelatedInstances);
         Console.WriteLine("StudyData.Description: " + Description.ToStringNull());
         Console.WriteLine("StudyData.NameOfDoctorsReading: " + NameOfDoctorsReading);
         Console.WriteLine("StudyData.AdmittingDiagnosesDescription: " + AdmittingDiagnosesDescription.ToStringNull());
         Console.WriteLine("StudyData.Age: " + Age.ToStringNull());
         Console.WriteLine("StudyData.Size: " + Size.ToStringNull());
         Console.WriteLine("StudyData.Weight: " + Weight.ToStringNull());
         Console.WriteLine("StudyData.AdditionalPatientHistory: " + AdditionalPatientHistory.ToStringNull());
         Console.WriteLine();
         Patient.Print();
      }
#endif

   }
}
