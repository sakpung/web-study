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

namespace Leadtools.Medical.WebViewer.PatientAccessRights
{
   /// <summary>
   /// define the interface for the agent, check the "PatientRightsSqlDbDataAccessAgent" comments
   /// </summary>
   public interface IPatientRightsDataAccessAgent
   {
      void GrantUserAccess ( string patientID, string user ) ;
      void DenyUserAccess ( string patientID, string user ) ;

      void GrantRoleAccess ( string patientID, string role ) ;
      void DenyRoleAccess ( string patientID, string role ) ;

      PatientAccessKey[] GetUserAccess ( string user ) ;
      PatientAccessKey[] GetRoleAccess ( string role ) ;

#if LEADTOOLS_V19_OR_LATER
      void DeleteAllUserRights(string user);
      void DeleteAllRoleRights(string role);
#endif
      
      List<string> GetPatientIDs ( string user, string[] groups ) ;
   }
}
