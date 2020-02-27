// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Wado
{
   internal class WadoRSClient
   {
      internal WadoServiceConfig ServiceConfig { get; set; }
      internal WadoRSClient(WadoServiceConfig config)
      {
         ServiceConfig = config;
      }

      internal async Task<Stream> RetrieveDataset(WadoDataSetModel query)
      {
         var stm = await RestClient.queryDicomStream(UrlBuilder.Combine(ServiceConfig.WadoRsServiceUrl, WadoDataSetConverter.ToWadoRsQueryUrl(query)));
         return stm;
      }

      internal async Task<Stream> RetrieveDatasetRendered(WadoDataSetModel query, Size? size)
      {
         var stm = await RestClient.queryRenderedDicomFile(UrlBuilder.Combine(ServiceConfig.WadoRsServiceUrl, WadoDataSetConverter.ToWadoRenderedRsQueryUrl(query)), null, size);
         return stm;
      }
   }
}
