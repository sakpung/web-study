// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.DataContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{
   public interface IStreamExportHandler
   {
      Task<Stream> ExportAllSeries(string authenticationCookie, string patientID, ExportOptions options);
      Task<Stream> ExportSeries(string authenticationCookie, string[] seriesInstanceUIDs, ExportOptions options);
      Task<Stream> ExportInstances(string authenticationCookie, string[] instanceUIDs, ExportOptions options);
      Task<Stream> ExportLayout(string authenticationCookie, string seriesInstanceUID, Layout layout, bool burnAnnotations, CompressionType compression, int width);
      Task<Stream> PrintAllSeries(string authenticationCookie, string patientID, PrintOptions options);
      Task<Stream> PrintSeries(string authenticationCookie, string[] seriesInstanceUIDs, PrintOptions options);
      Task<Stream> PrintInstances(string authenticationCookie, string[] instanceUIDs, PrintOptions options);
      Task<Stream> PrintLayout(string authenticationCookie, string seriesInstanceUID, Layout layout, PrintOptions options);
   }
}
