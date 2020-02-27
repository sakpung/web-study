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
   public interface IAuthorizedStorageDataAccessAgent
   {
#if (LEADTOOLS_V19_OR_LATER)
      int MaxQueryResults { get; set; }
      bool EnablePatientRestriction { get; set; }
#endif
      DataSet QueryPatients           ( MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups ) ;
      DataSet QueryStudies            ( MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups ) ;
      DataSet QuerySeries             ( MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups ) ;
      DataSet QueryCompositeInstances ( MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups ) ;
      Int32 DeleteInstance ( MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups ) ;
      
      int FindCompositeInstancesCount ( MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups ) ;
   }
}
