// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Leadtools.Medical.WebViewer.DataContracts;
using System.ServiceModel.Web;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.Addins;
using Leadtools.Medical.WebViewer.Wcf.Helper;
using System.ServiceModel.Activation;
using System.Web.Services;

namespace Leadtools.Medical.WebViewer.Wcf
{
   /// <summary>
   /// The service is used for granting/denying users access to patients.
   /// All functionality is implemented in the corresponding add-in after authentication and authorization.
   /// </summary>
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   public class PatientAccessRightsService : IPatientAccessRightsService
   {
      IPatientAccessRightsAddin _addin ;

      public PatientAccessRightsService ( ) 
      {
         _addin = AddinsFactory.CreatePatientAccessRightsAddin();

      }
#if LEADTOOLS_V19_OR_LATER
      public void GrantUserPatients( string authenticationCookie,  string user, List<string> patientIds, ExtraOptions extraOptions)
      {
          string userName;


          userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

          _addin.GrantUserPatients(user, patientIds);
      }
#endif
      public void GrantUserAccess ( string authenticationCookie,  UserPermissions userAccess, ExtraOptions extraOptions ) 
      {
         string userName ;

         
         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

         _addin.GrantUserAccess ( userAccess ) ;
      }

      public void DenyUserAccess ( string authenticationCookie, UserPermissions userAccess, ExtraOptions extraOptions ) 
      {
         string userName ;

         
         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

         _addin.DenyUserAccess ( userAccess ) ;
      }

#if LEADTOOLS_V19_OR_LATER
      public void GrantRolePatients(string authenticationCookie, string role, List<string> patientIds, ExtraOptions extraOptions)
      {
          string userName;


          userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

          _addin.GrantRolePatients(role, patientIds);
      }
#endif
      public void GrantRoleAccess ( string authenticationCookie, RolePermissions roleAccess, ExtraOptions extraOptions ) 
      {
         string userName ;

         
         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

         _addin.GrantRoleAccess ( roleAccess ) ;
      }

      public void DenyRoleAccess ( string authenticationCookie, RolePermissions roleAccess, ExtraOptions extraOptions ) 
      {
         string userName ;

         
         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

         _addin.DenyRoleAccess ( roleAccess ) ;
      }

      public UserPermissions[]  GetUserAccess ( string authenticationCookie, string user, ExtraOptions extraOptions ) 
      {
         string userName ;


         userName = ServiceUtils.Authenticate(authenticationCookie);

         if ( userName != user )
         {
            ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);
         }

         return _addin.GetUserAccess ( user ) ;
      }
      
      public RolePermissions[] GetRoleAccess ( string authenticationCookie, string role, ExtraOptions extraOptions ) 
      {
         string userName ;

         
         userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

         return _addin.GetRoleAccess ( role ) ;
      }

       
#if LEADTOOLS_V19_OR_LATER
      public RolePermissions[] GetRolesAccess(string authenticationCookie, List<string> roles, ExtraOptions extraOptions)
      {
          string userName;


          userName = ServiceUtils.Authorize(authenticationCookie, PermissionsTable.Instance.CanManageAccessRight);

          return _addin.GetRolesAccess(roles);
      }
#endif
   }
}
