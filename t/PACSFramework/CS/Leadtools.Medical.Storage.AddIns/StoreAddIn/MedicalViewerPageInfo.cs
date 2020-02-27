// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Leadtools.Medical.Storage.AddIns.StoreAddIn
{
   [DataContract]
   public class MedicalViewerPageInfo
   {
      [DataMember]
      public double[] ImageOrientationPatientArray { get; set; }

      [DataMember]
      public double[] PixelSpacingPatientArray { get; set; }

      [DataMember]
      public double[] ImagePositionPatientArray { get; set; }

      [DataMember]
      public string[] PatientOrientation { get; set; }

      [DataMember]
      public string ImageUri { get; set; }

      [DataMember]
      public LeadSize[] Resolutions { get; set; }

      [DataMember]
      public LeadSize TileSize { get; set; }

      [DataMember]
      public bool SupportWindowLevel { get; set; }

      [DataMember]
      public MedicalViewerPageInfo[] Pages{ get; set; }
   }
}
