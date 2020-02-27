// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.PermissionsManagement.DataAccessLayer;
using System.Data;

namespace Leadtools.Medical.WebViewer.PatientAccessRights
{
   /// <summary>
   /// a wrapper around the IStorageDataAccessAgent that evaluate user access rights and permissions for the queries
   /// </summary>
   public class AuthorizedStorageDataAccessAgent : IAuthorizedStorageDataAccessAgent2
   {
      public AuthorizedStorageDataAccessAgent ( IStorageDataAccessAgent3 storageDataAccess, IPatientRightsDataAccessAgent patientRightsDataAccess, IPermissionManagementDataAccessAgent permissionManagementDataAccessAgent ) 
      {
         StorageDataAccess = storageDataAccess ;
         PatientRightsDataAccess = patientRightsDataAccess ;
         PermissionManagementDataAccess = permissionManagementDataAccessAgent ;
         PermissionManagementDataAccess2 = permissionManagementDataAccessAgent as IPermissionManagementDataAccessAgent2;
      }

      /// <summary>
      /// Deletes DICOM instances from the storage databases based on what patients the user has access to
      /// </summary>
      /// <param name="matchingEntitiesCollection"></param>
      /// <param name="user"></param>
      /// <param name="groups"></param>
      /// <returns></returns>
      public Int32 DeleteInstance(MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups)
      {
         //check comments for the FiltersAdded method
         if (FiltersAdded(matchingEntitiesCollection, user, groups))
         {
            return StorageDataAccess.DeleteInstance(matchingEntitiesCollection);
         }
         return 0;
      }

#if (LEADTOOLS_V19_OR_LATER)
      public int MaxQueryResults { get; set; }
      public bool EnablePatientRestriction { get; set; }
#endif

      private void SetMaxQueryResults(IStorageDataAccessAgent storageAgent)
      {
#if (LEADTOOLS_V19_OR_LATER)
         StorageDataAccess.MaxQueryResults = MaxQueryResults;
#endif
      }

      private void ResetMaxQueryResults()
      {
#if (LEADTOOLS_V19_OR_LATER)
         StorageDataAccess.MaxQueryResults = 0;
#endif
      }

      /// <summary>
      /// Query patients from storage database based on what patients the user has access to
      /// </summary>
      /// <param name="matchingEntitiesCollection"></param>
      /// <param name="user"></param>
      /// <param name="groups"></param>
      /// <returns></returns>
      public DataSet QueryPatients ( MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups )
      {
         //check comments for the FiltersAdded method
         if ( FiltersAdded ( matchingEntitiesCollection, user, groups ) )
         {
            SetMaxQueryResults(StorageDataAccess);
            DataSet ds = StorageDataAccess.QueryPatients ( matchingEntitiesCollection ) ;
            ResetMaxQueryResults();
            return ds;
         }
         return DataTableHelper.CreateTypedDataSet(); // CompositeInstanceDataSet ( ) ;
      }

      /// <summary>
      /// Query studies from storage database based on what patients the user has access to
      /// </summary>
      /// <param name="matchingEntitiesCollection"></param>
      /// <param name="user"></param>
      /// <param name="groups"></param>
      /// <returns></returns>
      public DataSet QueryStudies ( MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups )
      {
         //check comments for the FiltersAdded method
         if ( FiltersAdded ( matchingEntitiesCollection, user, groups ) )
         {
            SetMaxQueryResults(StorageDataAccess);
            DataSet ds = StorageDataAccess.QueryStudies(matchingEntitiesCollection);
            ResetMaxQueryResults();
            return ds;
         }
         return DataTableHelper.CreateTypedDataSet(); // CompositeInstanceDataSet ( ) ;
      }

      /// <summary>
      /// Query series from storage database based on what patients the user has access to
      /// </summary>
      /// <param name="matchingEntitiesCollection"></param>
      /// <param name="user"></param>
      /// <param name="groups"></param>
      /// <returns></returns>
      public DataSet QuerySeries ( MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups )
      {
         if ( FiltersAdded ( matchingEntitiesCollection, user, groups ) )
         {
            SetMaxQueryResults(StorageDataAccess);
            DataSet ds = StorageDataAccess.QuerySeries(matchingEntitiesCollection);
            ResetMaxQueryResults();
            return ds;
         }
         return DataTableHelper.CreateTypedDataSet(); //CompositeInstanceDataSet ( ) ;
      }

      /// <summary>
      /// Query instances from storage database based on what patients the user has access to
      /// </summary>
      /// <param name="matchingEntitiesCollection"></param>
      /// <param name="user"></param>
      /// <param name="groups"></param>
      /// <returns></returns>
      public DataSet QueryCompositeInstances ( MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups )
      {
         //check comments for the FiltersAdded method
         if ( FiltersAdded ( matchingEntitiesCollection, user, groups ) )
         {
            SetMaxQueryResults(StorageDataAccess);
            DataSet ds = StorageDataAccess.QueryCompositeInstances(matchingEntitiesCollection);
            ResetMaxQueryResults();
            return ds;
         }
         return DataTableHelper.CreateTypedDataSet(); // CompositeInstanceDataSet ( ) ;
      }

      /// <summary>
      /// Query number of instances from storage database based on what patients the user has access to
      /// </summary>
      /// <param name="matchingEntitiesCollection"></param>
      /// <param name="user"></param>
      /// <param name="groups"></param>
      /// <returns></returns>
      public int FindCompositeInstancesCount ( MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups )
      {
         //check comments for the FiltersAdded method
         if ( FiltersAdded ( matchingEntitiesCollection, user, groups ) )
         {
            return StorageDataAccess.FindCompositeInstancesCount ( matchingEntitiesCollection ) ;
         }
         return 0 ;
      }


      public IStorageDataAccessAgent3 StorageDataAccess { get ; private set ; } 
      public IPatientRightsDataAccessAgent PatientRightsDataAccess { get ; private set ; } 
      public IPermissionManagementDataAccessAgent PermissionManagementDataAccess { get; private set ; }
      public IPermissionManagementDataAccessAgent2 PermissionManagementDataAccess2 { get; private set; }

      /// <summary>
      /// This is the main method that evaluates which patient a user/groups have access to then add them into the matching parameters
      /// </summary>
      /// <param name="matchingEntitiesCollection"></param>
      /// <param name="user"></param>
      /// <param name="groups"></param>
      /// <returns></returns>
      private bool FiltersAdded(MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups)
      {
#if LEADTOOLS_V19_OR_LATER
          if (!EnablePatientRestriction)
          {
              return true;
          }
#endif
         //if the user has the built-in Admin permission then it has access to all patients (this is legacy, usually there should be no permission called "Admin")
          if (PermissionManagementDataAccess.UserHasPermission("Admin", user) || InRole(user, "Administrators"))
         {
            return true ;
         }
         
         //query the patient IDS a user have access to
         List<string> patientIds = PatientRightsDataAccess.GetPatientIDs ( user, groups ) ;

         if (patientIds == null)
             return false;

         if ( patientIds.Count == 0 )
         {
            //if user has no patients assigned then no access to anything
            return false ;
         }


         //add the patient IDs into the matching parameters, when the query runs these IDs will be combined with an OR
         foreach ( MatchingParameterList matchingList in matchingEntitiesCollection ) 
         {
            Patient patient = new Patient ( ) ;

            //this join here for patient IDs produce the OR operator
            patient.PatientID = string.Join ( "\\", patientIds.ToArray ( ) ) ;

            matchingList.Add ( patient ) ;
         }

         return true ;
      }

       private bool InRole(string user, string role)
       {
           if (PermissionManagementDataAccess2 == null)
               return false;
          string[] roles = PermissionManagementDataAccess2.GetUserRoles(user);

          return roles.Contains(role, StringComparer.OrdinalIgnoreCase);
       }

       /// <summary>
       /// Query patients from storage database based on what patients the user has access to
       /// </summary>
       /// <param name="matchingEntitiesCollection"></param>
       /// <param name="user"></param>
       /// <param name="groups"></param>
       /// <returns></returns>
       public DataSet MinimumQueryPatients(MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups)
       {
          //check comments for the FiltersAdded method
          if (FiltersAdded(matchingEntitiesCollection, user, groups))
          {
             SetMaxQueryResults(StorageDataAccess);
             DataSet ds = StorageDataAccess.MinimumQueryPatients(matchingEntitiesCollection);
             ResetMaxQueryResults();
             return ds;
          }
          return DataTableHelper.CreateTypedDataSet(); // CompositeInstanceDataSet ( ) ;
       }

       /// <summary>
       /// Query studies from storage database based on what patients the user has access to
       /// </summary>
       /// <param name="matchingEntitiesCollection"></param>
       /// <param name="user"></param>
       /// <param name="groups"></param>
       /// <returns></returns>
       public DataSet MinimumQueryStudies(MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups)
       {
          //check comments for the FiltersAdded method
          if (FiltersAdded(matchingEntitiesCollection, user, groups))
          {
             SetMaxQueryResults(StorageDataAccess);
             DataSet ds = StorageDataAccess.MinimumQueryStudies(matchingEntitiesCollection);
             ResetMaxQueryResults();
             return ds;
          }
          return DataTableHelper.CreateTypedDataSet(); // CompositeInstanceDataSet ( ) ;
       }

       /// <summary>
       /// Query series from storage database based on what patients the user has access to
       /// </summary>
       /// <param name="matchingEntitiesCollection"></param>
       /// <param name="user"></param>
       /// <param name="groups"></param>
       /// <returns></returns>
       public DataSet MinimumQuerySeries(MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups)
       {
          if (FiltersAdded(matchingEntitiesCollection, user, groups))
          {
             SetMaxQueryResults(StorageDataAccess);
             DataSet ds = StorageDataAccess.MinimumQuerySeries(matchingEntitiesCollection);
             ResetMaxQueryResults();
             return ds;
          }
          return DataTableHelper.CreateTypedDataSet(); //CompositeInstanceDataSet ( ) ;
       }

       /// <summary>
       /// Query instances from storage database based on what patients the user has access to
       /// </summary>
       /// <param name="matchingEntitiesCollection"></param>
       /// <param name="user"></param>
       /// <param name="groups"></param>
       /// <returns></returns>
       public DataSet MinimumQueryCompositeInstances(MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups)
       {
          //check comments for the FiltersAdded method
          if (FiltersAdded(matchingEntitiesCollection, user, groups))
          {
             SetMaxQueryResults(StorageDataAccess);
             DataSet ds = StorageDataAccess.MinimumQueryCompositeInstances(matchingEntitiesCollection);
             ResetMaxQueryResults();
             return ds;
          }
          return DataTableHelper.CreateTypedDataSet(); // CompositeInstanceDataSet ( ) ;
       }

       /// <summary>
       /// Query instances from storage database based on what patients the user has access to
       /// </summary>
       /// <param name="matchingEntitiesCollection"></param>
       /// <param name="user"></param>
       /// <param name="groups"></param>
       /// <returns></returns>
       public DataSet BasicQueryCompositeInstances(MatchingParameterCollection matchingEntitiesCollection, string user, string[] groups)
       {
          //check comments for the FiltersAdded method
          if (FiltersAdded(matchingEntitiesCollection, user, groups))
          {
             SetMaxQueryResults(StorageDataAccess);
             DataSet ds = StorageDataAccess.CustomQueryCompositeInstances(matchingEntitiesCollection, ExtraQueryOptions.OptimizedImageInstance);
             ResetMaxQueryResults();
             return ds;
          }
          return DataTableHelper.CreateTypedDataSet(); // CompositeInstanceDataSet ( ) ;
       }

   }
}
