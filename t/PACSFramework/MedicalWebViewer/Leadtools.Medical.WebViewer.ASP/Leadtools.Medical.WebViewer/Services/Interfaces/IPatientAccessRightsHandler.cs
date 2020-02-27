// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Collections.Generic;
using Leadtools.Medical.WebViewer.DataContracts;

namespace Leadtools.Medical.WebViewer.Services.Interfaces
{
   /// <summary>
   /// The service contract for the patient Access rights service
   /// </summary>

   public interface IPatientAccessRightsHandler
   {
      void GrantUserPatients(string authenticationCookie, string user, List<string> patientIds);
      void GrantUserAccess(string authenticationCookie, UserPermissions userAccess);

      void DenyUserAccess(string authenticationCookie, UserPermissions userAccess);
      void GrantRolePatients(string authenticationCookie, string role, List<string> patientIds);
      void GrantRoleAccess(string authenticationCookie, RolePermissions roleAccess);

      void DenyRoleAccess(string authenticationCookie, RolePermissions roleAccess);
      UserPermissions[] GetUserAccess(string authenticationCookie, string user);
      RolePermissions[] GetRoleAccess(string authenticationCookie, string role);

      RolePermissions[] GetRolesAccess(string authenticationCookie, List<string> roles);
   }
}
