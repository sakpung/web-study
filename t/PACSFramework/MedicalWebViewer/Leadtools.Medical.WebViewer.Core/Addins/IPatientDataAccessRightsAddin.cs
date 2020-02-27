// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.DataContracts;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   /// <summary>
   /// The interface for the Add-in that control the user access rights to patient information
   /// </summary>
   public interface IPatientAccessRightsAddin
   {      
#if LEADTOOLS_V19_OR_LATER
       void GrantUserPatients(string user, List<string> patientIds);
#endif
     void GrantUserAccess ( UserPermissions userAccess);
     void DenyUserAccess ( UserPermissions userAccess );

#if LEADTOOLS_V19_OR_LATER
     void GrantRolePatients(string role, List<string> patientIds);
#endif
      void GrantRoleAccess ( RolePermissions roleAccess) ;
      void DenyRoleAccess ( RolePermissions roleAccess) ;

      UserPermissions[]  GetUserAccess ( string user) ;
      RolePermissions[] GetRoleAccess ( string role) ;

#if LEADTOOLS_V19_OR_LATER
      RolePermissions[] GetRolesAccess(List<string> roles);
#endif
   }
}
