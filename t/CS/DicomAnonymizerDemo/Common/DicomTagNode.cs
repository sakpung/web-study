// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DicomAnonymizer.UI.Controls;
using Leadtools.Dicom;

namespace DicomAnonymizer.Common
{
   public class DicomTagNode : TreeGridNode
   {
      public DicomTag DicomTag { get; set; }
   }
}
