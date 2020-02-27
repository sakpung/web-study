// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scu.Queries;
using Leadtools.Dicom.Common.Attributes;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.Forwarder.AddIn.Processes
{
   [Instance(DicomClassType.StudyRootQueryImage, DicomUidType.StudyRootQueryFind)]    
   public class ImageQuery : BaseQuery
   {
      [Element(DicomTag.SOPInstanceUID)]
      public string SOPInstanceUID { get; set; }

      public ImageQuery()
      {
         QueryRetrieveLevel = "IMAGE";
      }
   }
}
