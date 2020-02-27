// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Leadtools.Medical.WebViewer.DataContracts
{
   /// <summary>
   /// Class that contains the query parameters when performing either Patient, Study, Series or instance query.
   /// </summary>
   [DataContract]
   public class QueryOptions
   {
      // Patients info
      [DataMember]
      public PatientsQueryOptions PatientsOptions { get; set; }

      [DataMember]
      public StudiesQueryOptions StudiesOptions { get; set; }

      [DataMember]
      public SeriesQueryOptions SeriesOptions { get; set; }

      [DataMember]
      public InstancesQueryOptions InstancesOptions { get; set; }
   }
}
