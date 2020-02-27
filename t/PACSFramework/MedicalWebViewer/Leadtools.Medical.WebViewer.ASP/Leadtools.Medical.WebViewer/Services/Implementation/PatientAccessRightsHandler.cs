// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Collections.Generic;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.ServiceContracts;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   /// <summary>
   /// The Handler is used for granting/denying users access to patients.
   /// All functionality is implemented in the corresponding add-in after authentication and authorization.
   /// </summary>

   public class PatientAccessRightsHandler : IPatientAccessRightsHandler
   {
      IPatientAccessRightsAddin _addin;

      public PatientAccessRightsHandler(AddinsFactory factory)
      {
         _addin = factory.CreatePatientAccessRightsAddin();

      }

      public void GrantUserPatients(string authenticationCookie, string user, List<string> patientIds)
      {
         string userName;


         userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

         _addin.GrantUserPatients(user, patientIds ?? new List<string>());
      }

      public void GrantUserAccess(string authenticationCookie, UserPermissions userAccess)
      {
         string userName;


         userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

         _addin.GrantUserAccess(userAccess);
      }

      public void DenyUserAccess(string authenticationCookie, UserPermissions userAccess)
      {
         string userName;


         userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

         _addin.DenyUserAccess(userAccess);
      }


      public void GrantRolePatients(string authenticationCookie, string role, List<string> patientIds)
      {
         string userName;


         userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

         _addin.GrantRolePatients(role, patientIds);
      }

      public void GrantRoleAccess(string authenticationCookie, RolePermissions roleAccess)
      {
         string userName;


         userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

         _addin.GrantRoleAccess(roleAccess);
      }

      public void DenyRoleAccess(string authenticationCookie, RolePermissions roleAccess)
      {
         string userName;


         userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

         _addin.DenyRoleAccess(roleAccess);
      }

      public UserPermissions[] GetUserAccess(string authenticationCookie, string user)
      {
         string userName;


         userName = AuthHandler.Authenticate(authenticationCookie);

         if (userName != user)
         {
            AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);
         }

         return _addin.GetUserAccess(user);
      }

      public RolePermissions[] GetRoleAccess(string authenticationCookie, string role)
      {
         string userName;


         userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

         return _addin.GetRoleAccess(role);
      }



      public RolePermissions[] GetRolesAccess(string authenticationCookie, List<string> roles)
      {
         string userName;


         userName = AuthHandler.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

         return _addin.GetRolesAccess(roles);
      }

   }
}
