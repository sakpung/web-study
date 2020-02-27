// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Wado
{
   internal class QidoRSClient
   {
      internal WadoServiceConfig ServiceConfig { get; set; }
      internal QidoRSClient(WadoServiceConfig config)
      {
         ServiceConfig = config;
      }

      internal async Task<List<WadoDataSetModel>> PatientLevel(WadoDataSetModel query)
      {
         var stm = await RestClient.queryJson(UrlBuilder.Combine(ServiceConfig.QidoRsServiceUrl, WadoDataSetConverter.ToQidoQueryUrl(query, "patient")));

         return WadoDataSetModelFactory.ReadJsonObjects(stm);
      }
      internal async Task<List<WadoDataSetModel>> StudyLevel(WadoDataSetModel query)
      {
         var stm = await RestClient.queryJson(UrlBuilder.Combine(ServiceConfig.QidoRsServiceUrl, WadoDataSetConverter.ToQidoQueryUrl(query, "study")));

         return WadoDataSetModelFactory.ReadJsonObjects(stm);
      }
      internal async Task<List<WadoDataSetModel>> SeriesLevel(WadoDataSetModel query)
      {
         var stm = await RestClient.queryJson(UrlBuilder.Combine(ServiceConfig.QidoRsServiceUrl, WadoDataSetConverter.ToQidoQueryUrl(query, "series")));

         return WadoDataSetModelFactory.ReadJsonObjects(stm);
      }
      internal async Task<List<WadoDataSetModel>> InstanceLevel(WadoDataSetModel query)
      {
         var stm = await RestClient.queryJson(UrlBuilder.Combine(ServiceConfig.QidoRsServiceUrl, WadoDataSetConverter.ToQidoQueryUrl(query, "instance")));

         return WadoDataSetModelFactory.ReadJsonObjects(stm);
      }
   }
}
