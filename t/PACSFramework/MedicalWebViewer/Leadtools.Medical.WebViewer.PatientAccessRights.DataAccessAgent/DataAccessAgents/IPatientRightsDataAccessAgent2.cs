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
   public interface IPatientRightsDataAccessAgent2 : IPatientRightsDataAccessAgent
   {
      void AddAeRole(string aeTitle, string role);
      void DeleteAeRole(string aeTitle, string role);

      List<string> GetAeRoles (string aeTitle);

      List<AeAccessKey> GetAllAeRoleRecords();
   }
}
