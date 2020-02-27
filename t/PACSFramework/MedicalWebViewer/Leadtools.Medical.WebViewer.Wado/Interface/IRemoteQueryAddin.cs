// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Wado
{
   public interface IRemoteQueryAddin
   {
      Task<InstanceData[]> FindInstances(RemoteQueryServiceConfig serviceConfig, QueryOptions query);
      Task<PatientData[]> FindPatients(RemoteQueryServiceConfig serviceConfig, QueryOptions query);
      Task<SeriesData[]> FindSeries(RemoteQueryServiceConfig serviceConfig, QueryOptions query);
      Task<StudyData[]> FindStudies(RemoteQueryServiceConfig serviceConfig, QueryOptions query);
      string Ping(RemoteQueryServiceConfig service);
   }
}
