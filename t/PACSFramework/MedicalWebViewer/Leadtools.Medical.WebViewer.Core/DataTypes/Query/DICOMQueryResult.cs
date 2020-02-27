// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Leadtools.Medical.WebViewer.DataContracts
{
   /// <summary>
   /// not used
   /// </summary>
   [DataContract]
   public class DICOMQueryResult
   {
      // Patients found
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
      [DataMember]
      public PatientData[] Patients { get; set; }

      // Studies found
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
      [DataMember]
      public StudyData[] Studies { get; set; }

      // Series found
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
      [DataMember]
      public SeriesData[] Series { get; set; }

      // Instances found
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
      [DataMember]
      public InstanceData[] Instances { get; set; }
   }
}
