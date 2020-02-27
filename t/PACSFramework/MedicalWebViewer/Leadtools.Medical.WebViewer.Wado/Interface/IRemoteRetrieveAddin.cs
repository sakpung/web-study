// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;
using System.Drawing;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Wado
{
   public interface IRemoteRetrieveAddin
   {
      Task<Stream> RetrieveDataset(RemoteQueryServiceConfig serviceConfig, QueryOptions query);
      Task<Stream> RetrieveDatasetRendered(RemoteQueryServiceConfig serviceConfig, QueryOptions query, Size? size);
      string Ping(RemoteQueryServiceConfig service);
   }
}
