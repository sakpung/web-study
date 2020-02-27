// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Leadtools.Dicom.Imaging;

namespace Leadtools.Medical.WebViewer.DataContracts
{
   [DataContract]
   public class PageInfo
   {
      [DataMember]
      public LeadSize[] Resolutions { get; set; }

      [DataMember]
      public LeadSize TileSize { get; set; }

      [DataMember]
      public double[] ImageOrientationPatientArray { get; set; }

      [DataMember]
      public double[] PixelSpacingPatientArray { get; set; }

      [DataMember]
      public double[] ImagePositionPatientArray { get; set; }

      [DataMember]
      public string[] PatientOrientation { get; set; }

      [DataMember]
      public bool SupportWindowLevel { get; set; }
      
      [DataMember]
      public int TotalEncapsulatedPages { get; set; }
   }
   
   [DataContract]
   public class StackItem
   {
       [DataMember]
       public string SequenceName { get; set; }
       [DataMember]
       public List<string> SopInstanceUIDs { get; set; }
   }
}
