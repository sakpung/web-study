// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.DataContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Leadtools.Medical.WebViewer.Wado
{
   public class WadoQueryAddin : IRemoteQueryAddin
   {
      public async Task<PatientData[]> FindPatients(RemoteQueryServiceConfig serviceConfig, QueryOptions query)
      {
         var config = WadoServiceConfig.From(serviceConfig);
         var qido = new QidoRSClient(config);
         var wquery = WadoDataSetAdapter.ReadQueryOptions(query);

         var results = await qido.PatientLevel(wquery);
         var patientResults = new List<PatientData>();
         foreach (var result in results)
         {
            patientResults.Add(WadoDataSetAdapter.ReadPatientData(result));
         }
         return patientResults.ToArray();
      }

      public async Task<StudyData[]> FindStudies(RemoteQueryServiceConfig serviceConfig, QueryOptions query)
      {
         var config = WadoServiceConfig.From(serviceConfig);
         var qido = new QidoRSClient(config);
         var wquery = WadoDataSetAdapter.ReadQueryOptions(query);

         var results = await qido.StudyLevel(wquery);
         var studyResults = new List<StudyData>();
         foreach (var result in results)
         {
            studyResults.Add(WadoDataSetAdapter.ReadStudyData(result));
         }
         return studyResults.ToArray();
      }

      public async Task<SeriesData[]> FindSeries(RemoteQueryServiceConfig serviceConfig, QueryOptions query)
      {
         var config = WadoServiceConfig.From(serviceConfig);
         var qido = new QidoRSClient(config);
         var wquery = WadoDataSetAdapter.ReadQueryOptions(query);

         var results = await qido.SeriesLevel(wquery);
         var seriesResults = new List<SeriesData>();
         foreach (var result in results)
         {
            seriesResults.Add(WadoDataSetAdapter.ReadSeriesData(result));
         }
         return seriesResults.ToArray();
      }

      public async Task<InstanceData[]> FindInstances(RemoteQueryServiceConfig serviceConfig, QueryOptions query)
      {
         var config = WadoServiceConfig.From(serviceConfig);
         var qido = new QidoRSClient(config);
         var wquery = WadoDataSetAdapter.ReadQueryOptions(query);

         var results = await qido.InstanceLevel(wquery);
         var instanceResults = new List<InstanceData>();
         foreach (var result in results)
         {
            instanceResults.Add(WadoDataSetAdapter.ReadInstanceData(result));
         }
         return instanceResults.ToArray();
      }

      public string Ping(RemoteQueryServiceConfig service)
      {
         throw new NotImplementedException();
      }
   }

}
