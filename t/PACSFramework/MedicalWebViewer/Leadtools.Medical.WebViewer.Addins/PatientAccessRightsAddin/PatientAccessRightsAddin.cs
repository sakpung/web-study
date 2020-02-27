// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Medical.WebViewer.PatientAccessRights;


namespace Leadtools.Medical.WebViewer.Addins
{
   /// <summary>
   /// The add-in is used to grant/deny users access to patient info
   /// It uses directly the methods of the DataAccessLayer to perform its operations.
   /// </summary>
   public class PatientAccessRightsAddin : IPatientAccessRightsAddin
   {
      IPatientRightsDataAccessAgent _dataAccess ;

      public PatientAccessRightsAddin ( IPatientRightsDataAccessAgent dataAccess ) 
      {
         _dataAccess = dataAccess ;
      }


      public void GrantUserPatients(string user, List<string> patientIds)
      {
          _dataAccess.DeleteAllUserRights(user);       
         if(null!=patientIds)
          foreach (string patientId in patientIds)
          {                           
              _dataAccess.GrantUserAccess(patientId, user);
          }
      }


      public void GrantUserAccess ( UserPermissions userAccess ) 
      {
         _dataAccess.GrantUserAccess ( userAccess.PatientId, userAccess.User ) ;
      }

      public void DenyUserAccess ( UserPermissions userAccess  ) 
      {          
         _dataAccess.DenyUserAccess ( userAccess.PatientId, userAccess.User ) ;
      }


      public void GrantRolePatients(string role, List<string> patientIds)
      {
          _dataAccess.DeleteAllRoleRights(role);
         if (null != patientIds)
         {
          foreach (string patientId in patientIds)
          {
              _dataAccess.GrantRoleAccess(patientId, role);
            }
          }
      }

      public void GrantRoleAccess ( RolePermissions roleAccess ) 
      {
         _dataAccess.GrantRoleAccess ( roleAccess.PatientId, roleAccess.Role ) ;
      }
      
      public void DenyRoleAccess ( RolePermissions roleAccess ) 
      {
         _dataAccess.DenyRoleAccess ( roleAccess.PatientId, roleAccess.Role ) ;
      }

      public UserPermissions[]  GetUserAccess ( string user ) 
      {
         return Array.ConvertAll <PatientAccessKey,UserPermissions> ( _dataAccess.GetUserAccess ( user ), ToUserPermissions ) ;
      }

      public RolePermissions[] GetRoleAccess ( string role ) 
      {
         return Array.ConvertAll <PatientAccessKey,RolePermissions> ( _dataAccess.GetRoleAccess ( role ), ToRolePermissions ) ;
      }

      public RolePermissions[] GetRolesAccess(List<string> roles)
      {
          List<PatientAccessKey> paKeys = new List<PatientAccessKey>();

          foreach (string role in roles)
          {
              paKeys.AddRange(_dataAccess.GetRoleAccess(role));
          }
          return Array.ConvertAll<PatientAccessKey, RolePermissions>(paKeys.ToArray(), ToRolePermissions);
      }


      private static UserPermissions ToUserPermissions ( PatientAccessKey patientAccess )
      {
         UserPermissions permission = new UserPermissions ( ) ;

         permission.PatientId = patientAccess.PatientID ;
         permission.User      = patientAccess.AccessKey ;

         return permission ;
      }

      private static RolePermissions ToRolePermissions ( PatientAccessKey patientAccess )
      {
         RolePermissions permission = new RolePermissions ( ) ;

         permission.PatientId = patientAccess.PatientID ;
         permission.Role      = patientAccess.AccessKey ;

         return permission ;
      }
   }
}
