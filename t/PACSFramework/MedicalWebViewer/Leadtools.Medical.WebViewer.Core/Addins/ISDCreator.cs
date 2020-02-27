// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;

namespace Leadtools.Medical.WebViewer.Core.Addins
{
   public interface ISDCreator
   {
      string ContentCreator { get; set; }
      string ContentDescription { get; set; }
      string Manufacturer { get; set; }
      string InstitutionName { get; set; }

      DicomDataSet Create(string seriesInstanceUID, List<string> referencedFiles);
   }
}
