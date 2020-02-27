// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Leadtools.Medical.WebViewer.Core.DataTypes.Common;

namespace Leadtools.Medical.WebViewer.DataContracts
{
   /// <summary>
   /// contains the DICOM Instance information for an Instance Level query
   /// </summary>
   [DataContract]
   public class InstanceData
   {
      [DataMember]
      public string SOPInstanceUID { get; set; }
      [DataMember]
      public string SeriesInstanceUID { get; set; }
      [DataMember]
      public string StudyInstanceUID { get; set; }
      [DataMember]
      public string InstanceNumber { get; set; }
      [DataMember]
      public string TransferSyntax { get; set; }
      [DataMember]
      public string SOPClassUID { get; set; }
      [DataMember]
      public string StationName { get; set; }
      [DataMember]
      public string PatientID { get; set; }
      [DataMember]
      public int NumberOfFrames { get; set; }

      [DataMember]
      public PageInfo[] Pages { get; set; }

      public void Print()
      {
         Console.WriteLine("InstanceData.SOPInstanceUID: " + SOPInstanceUID.ToStringNull());
         Console.WriteLine("InstanceData.SeriesInstanceUID: " + SeriesInstanceUID.ToStringNull());
         Console.WriteLine("InstanceData.StudyInstanceUID: " + StudyInstanceUID.ToStringNull());
         Console.WriteLine("InstanceData.InstanceNumber: " + InstanceNumber.ToStringNull());
         Console.WriteLine("InstanceData.TransferSyntax: " + TransferSyntax.ToStringNull());
         Console.WriteLine("InstanceData.SOPClassUID: " + SOPClassUID.ToStringNull());
         Console.WriteLine("InstanceData.StationName: " + StationName.ToStringNull());
         Console.WriteLine("InstanceData.PatientID: " + PatientID.ToStringNull());
         Console.WriteLine("InstanceData.NumberOfFrames: " + NumberOfFrames);
      }

   }
}
