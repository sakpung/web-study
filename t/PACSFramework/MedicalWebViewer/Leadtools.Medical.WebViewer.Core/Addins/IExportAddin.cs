// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   public interface IExportAddin
   {     
      Stream ExportAllSeries(string userName, string patientID, ExportOptions options);
      Stream ExportSeries(string userName, string[] seriesInstanceUIDa, ExportOptions options);
      Stream ExportInstances(string userName, string[] instanceUIDs, ExportOptions options);
      Stream ExportLayout(string userName, string seriesInstanceUID, Layout layout, bool burnAnnotations, CompressionType compression, int width);
      Stream PrintAllSeries(string userName, string patientID, PrintOptions options, string annotationData);
      Stream PrintInstances(string userName, string[] instanceUIDs, PrintOptions options, string annotationData);
      Stream PrintLayout(string userName, string seriesInstanceUID, Layout layout, PrintOptions options, string annotationData);
      Stream PrintSeries(string userName, string[] seriesInstanceUIDa, PrintOptions options, string annotationData);
      string GetInstanceLocalPathName(string userName, string instanceUID); 
   }
}
