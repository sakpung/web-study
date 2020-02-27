// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.DataContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Wado
{
   public class WadoRetrieveAddin : IRemoteRetrieveAddin
   {
      public async Task<Stream> RetrieveDataset(RemoteQueryServiceConfig serviceConfig, QueryOptions query)
      {
         var config = WadoServiceConfig.From(serviceConfig);
         var rs = new WadoRSClient(config);
         var wquery = WadoDataSetAdapter.ReadQueryOptions(query);

         var result = await rs.RetrieveDataset(wquery);
         return result ;
      }

      public async Task<Stream> RetrieveDatasetRendered(RemoteQueryServiceConfig serviceConfig, QueryOptions query, Size? size)
      {
         var config = WadoServiceConfig.From(serviceConfig);
         var rs = new WadoRSClient(config);
         var wquery = WadoDataSetAdapter.ReadQueryOptions(query);

         var result = await rs.RetrieveDatasetRendered(wquery, size);
         return result;
      }

      public string Ping(RemoteQueryServiceConfig service)
      {
         throw new NotImplementedException();
      }
   }
}
