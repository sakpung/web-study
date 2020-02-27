// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using System.Collections.Generic;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Dicom;

namespace Leadtools.Medical.SearchOtherPatientId.Addin.Common
{
   public class MyOtherPatientIds
   {
      [Element(DicomTag.OtherPatientIDs)]
      public List<string> OtherPatientIds { get; set; }
   }
}
