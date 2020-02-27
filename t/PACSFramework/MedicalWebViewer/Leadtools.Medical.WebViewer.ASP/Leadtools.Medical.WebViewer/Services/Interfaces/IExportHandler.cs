// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{
   public interface IExportHandler
   {
      string MapPath(string authenticationCookie, string url);
      Task<string> ExportAllSeries(string authenticationCookie, string patientID, ExportOptions options);
      Task<string> ExportSeries(string authenticationCookie, string[] seriesInstanceUIDs, ExportOptions options);
      Task<string> ExportInstances(string authenticationCookie, string[] instanceUIDs, ExportOptions options);
      Task<string> ExportLayout(string authenticationCookie, string seriesInstanceUID, Layout layout, bool burnAnnotations, CompressionType compression, int width);
      Task<string> PrintAllSeries(string authenticationCookie, string patientID, PrintOptions options);
      Task<string> PrintSeries(string authenticationCookie, string[] seriesInstanceUIDs, PrintOptions options);
      Task<string> PrintInstances(string authenticationCookie, string[] instanceUIDs, PrintOptions options);
      Task<string> PrintLayout(string authenticationCookie, string seriesInstanceUID, Layout layout, PrintOptions options);
      Task<string> GetInstanceLocalPathName(string authenticationCookie, string instanceUID);
   }
}
