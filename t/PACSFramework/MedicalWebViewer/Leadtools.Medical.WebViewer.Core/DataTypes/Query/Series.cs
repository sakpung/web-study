// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Leadtools.Medical.WebViewer.Core.DataTypes.Common;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;

namespace Leadtools.Medical.WebViewer.DataContracts
{
   /// <summary>
   /// Contains the series information for a Series level query
   /// </summary>
   [DataContract]
   public class SeriesData
   {
      [DataMember]
      public string Modality { get; set; }
      [DataMember]
      public string Number { get; set; }
      [DataMember]
      public string InstanceUID { get; set; }
      [DataMember]
      public string NumberOfRelatedInstances { get; set; }
      [DataMember]
      public string Description { get; set; }
      [DataMember]
      public string Date { get; set; }
      [DataMember]
      public string StudyInstanceUID { get; set; }
      //Replaced with PatientData class.
      //[DataMember]
      //public string PatientID { get; set; }
      [DataMember]
      public PatientData Patient { get; set; }

#if (LEADTOOLS_V19_OR_LATER)
      [DataMember]
      public bool CompleteMRTI { get; set; }

      [DataMember]
      public List<string> SopInstanceUIDs { get; set; }

      public void AddSopInstanceUID(string instance)
      {
         if (SopInstanceUIDs == null)
         {
            SopInstanceUIDs = new List<string>();
         }
         SopInstanceUIDs.Add(instance);
      }

      public void Print()
      {
         Console.WriteLine("SeriesData.Modality: " + Modality.ToStringNull());
         Console.WriteLine("SeriesData.Number: " + Number.ToStringNull());
         Console.WriteLine("SeriesData.InstanceUID: " + InstanceUID.ToStringNull());
         Console.WriteLine("SeriesData.NumberOfRelatedInstances: " + NumberOfRelatedInstances.ToStringNull());
         Console.WriteLine("SeriesData.Description: " + Description.ToStringNull());
         Console.WriteLine("SeriesData.Date: " + Date.ToStringNull());
         Console.WriteLine("SeriesData.StudyInstanceUID: " + StudyInstanceUID.ToStringNull());

         Console.WriteLine();
         Patient.Print();
      }
#endif

   }
}
