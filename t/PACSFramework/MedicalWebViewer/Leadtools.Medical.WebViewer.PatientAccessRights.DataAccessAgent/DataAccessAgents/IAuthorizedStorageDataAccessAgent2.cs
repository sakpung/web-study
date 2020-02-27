// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using System.Data;

namespace Leadtools.Medical.WebViewer.PatientAccessRights
{
   /// <summary>
   /// defines the interface for the agent. Check the "AuthorizedStorageDataAccessAgent" comments
   /// </summary>
   public interface IAuthorizedStorageDataAccessAgent2 : IAuthorizedStorageDataAccessAgent
   {
      DataSet MinimumQueryPatients( MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups ) ;
      DataSet MinimumQueryStudies(MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups);
      DataSet MinimumQuerySeries(MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups);
      DataSet MinimumQueryCompositeInstances(MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups);
      DataSet BasicQueryCompositeInstances(MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups);
   }
}
