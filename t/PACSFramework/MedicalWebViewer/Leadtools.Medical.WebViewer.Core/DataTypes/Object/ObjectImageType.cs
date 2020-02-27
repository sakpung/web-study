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
   [DataContract]
   public enum ObjectImageType
   {
      [DataMember]
      None,
      [DataMember]
      SingleFrameImage,
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Multi")]
      [DataMember]
      MultiFrameImage,
      [DataMember]
      Waveform,
      [DataMember]
      StructuredReport,
      [DataMember]
      RadiationDose,
      [DataMember]
      Overlay,
      [DataMember]
      PresentationState,
      [DataMember]
      EvidenceDocument,
      [DataMember]
      KeyImageNotes,
      [DataMember]
      StandaloneOverlay,
      [DataMember]
      StandaloneLUT
   }
}
