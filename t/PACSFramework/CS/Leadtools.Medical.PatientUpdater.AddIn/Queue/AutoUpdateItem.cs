// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom;
using System.Xml.Serialization;

namespace Leadtools.Medical.PatientUpdater.AddIn.Queue
{
   [Serializable]
   public class AutoUpdateItem
   {
      public string SourceAE { get; set; }
      public int Action { get; set; }           
      public string ClientAE { get; set; }      
      [XmlIgnore]
      public DicomDataSet Dicom { get; set; }

      public AutoUpdateItem()
      {         
      }

      public AutoUpdateItem(string source)
      {
         SourceAE = source;
      }
   }
}
