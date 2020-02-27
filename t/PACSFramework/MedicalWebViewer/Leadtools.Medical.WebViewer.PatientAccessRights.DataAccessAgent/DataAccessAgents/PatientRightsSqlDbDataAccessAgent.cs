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
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using System.Data;

namespace Leadtools.Medical.WebViewer.PatientAccessRights
{
   /// <summary>
   /// implement the database methods that allow granting and denying users access to patient information
   /// </summary>
   public class PatientRightsSqlDbDataAccessAgent : IPatientRightsDataAccessAgent2
   {
      public Database DataProvider { get ; protected set ; }

      public PatientRightsSqlDbDataAccessAgent ( string connectionString ) 
      {
         DataProvider = new SqlDatabase ( connectionString ) ;
      }

      /// <summary>
      /// insert a record in the rolesPatients table to associate a user with a patient ID
      /// </summary>
      /// <param name="patientID"></param>
      /// <param name="user"></param>
      public void GrantUserAccess ( string patientID, string user ) 
      {
         using ( DbConnection connection = DataProvider.CreateConnection ( ) ) 
         {
            using ( DbCommand command = connection.CreateCommand ( ) ) 
            {
               command.CommandText = SqlCommands.GrantUserAccess;
                  
               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@patientid";
                  p.Size = patientID.Length;
                  p.Value = patientID;

                  command.Parameters.Add(p);
               }

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@userid";
                  p.Size = user.Length;
                  p.Value = user;

                  command.Parameters.Add(p);
               }

               connection.Open ( ) ;

               command.ExecuteNonQuery ( ) ;

               connection.Close ( ) ;
            }
         }
      }
      
      /// <summary>
      /// Delete an association (row) from the RolesPatients table between a user and a patient.
      /// </summary>
      /// <param name="patientID"></param>
      /// <param name="user"></param>
      public void DenyUserAccess ( string patientID, string user ) 
      {
         using ( DbConnection connection = DataProvider.CreateConnection ( ) ) 
         {
            using ( DbCommand command = connection.CreateCommand ( ) ) 
            {
               command.CommandText = SqlCommands.DenyUserAccess;

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@patientid";
                  p.Size = patientID.Length;
                  p.Value = patientID;

                  command.Parameters.Add(p);
               }

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@userid";
                  p.Size = user.Length;
                  p.Value = user;

                  command.Parameters.Add(p);
               }

               connection.Open ( ) ;

               command.ExecuteNonQuery ( ) ;

               connection.Close ( ) ;
            }
         }
      }

      /// <summary>
      /// insert a record in the rolesPatients table to associate a role with a patient ID
      /// </summary>
      /// <param name="patientID"></param>
      /// <param name="user"></param>
      public void GrantRoleAccess ( string patientID, string role ) 
      {
         using ( DbConnection connection = DataProvider.CreateConnection ( ) ) 
         {
            using ( DbCommand command = connection.CreateCommand ( ) ) 
            {
               command.CommandText = SqlCommands.GrantRoleAccess;
               
               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@roleid";
                  p.Size = role.Length;
                  p.Value = role;

                  command.Parameters.Add(p);
               }

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@patientid";
                  p.Size = patientID.Length;
                  p.Value = patientID;

                  command.Parameters.Add(p);
               }

               connection.Open ( ) ;

               command.ExecuteNonQuery ( ) ;

               connection.Close ( ) ;
            }
         }
      }

      /// <summary>
      /// Delete an association (row) from the RolesPatients table between a role and a patient.
      /// </summary>
      /// <param name="patientID"></param>
      /// <param name="user"></param>
      public void DenyRoleAccess ( string patientID, string role ) 
      {
         using ( DbConnection connection = DataProvider.CreateConnection ( ) ) 
         {
            using ( DbCommand command = connection.CreateCommand ( ) ) 
            {
               command.CommandText = SqlCommands.DenyRoleAccess;

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@roleid";
                  p.Size = role.Length;
                  p.Value = role;

                  command.Parameters.Add(p);
               }

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@patientid";
                  p.Size = patientID.Length;
                  p.Value = patientID;

                  command.Parameters.Add(p);
               }

               connection.Open ( ) ;

               command.ExecuteNonQuery ( ) ;

               connection.Close ( ) ;
            }
         }
      }

      /// <summary>
      /// Gets all patients accessible to the user
      /// </summary>
      /// <param name="user"></param>
      /// <returns></returns>
      public PatientAccessKey[] GetUserAccess ( string user ) 
      {
         using (DbConnection connection = DataProvider.CreateConnection())
         {
            using (DbCommand command = connection.CreateCommand())
            {
               command.CommandText = SqlCommands.GetUserAccess;

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@userid";
                  p.Size = user.Length;
                  p.Value = user;

                  command.Parameters.Add(p);
               }

               connection.Open ( ) ;
               var access = GetAccess(command);
               connection.Close ( ) ;
               return access;
            }
         }     
      }
      
      /// <summary>
      /// Gets all patients accessible to the role/group
      /// </summary>
      /// <param name="role"></param>
      /// <returns></returns>
      public PatientAccessKey[] GetRoleAccess ( string role ) 
      {
         using (DbConnection connection = DataProvider.CreateConnection())
         {
            using (DbCommand command = connection.CreateCommand())
            {
               command.CommandText = SqlCommands.GetRoleAccess;

                {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@roleid";
                  p.Size = role.Length;
                  p.Value = role;

                  command.Parameters.Add(p);
               }

               connection.Open ( ) ;
               var access = GetAccess(command);
               connection.Close ( ) ;
               return access;
            }
         }
      }

#if LEADTOOLS_V19_OR_LATER
      public void DeleteAllUserRights(string user)
      {
          using (DbConnection connection = DataProvider.CreateConnection())
          {
            using (DbCommand command = connection.CreateCommand())
            {
               command.CommandText = SqlCommands.DeleteAllUserRights;

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@userid";
                  p.Size = user.Length;
                  p.Value = user;

                  command.Parameters.Add(p);
               }

               connection.Open();

               command.ExecuteNonQuery();
            }
          }
      }

      public void DeleteAllRoleRights(string role)
      {
          using (DbConnection connection = DataProvider.CreateConnection())
          {
            using (DbCommand command = connection.CreateCommand())
            {
               command.CommandText = SqlCommands.DeleteAllRoleRights;

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@roleid";
                  p.Size = role.Length;
                  p.Value = role;

                  command.Parameters.Add(p);
               }
               connection.Open();

               command.ExecuteNonQuery();
            }
          }
      }
#endif

      private PatientAccessKey[] GetAccess ( DbCommand command ) 
      {
         List <PatientAccessKey> accessList = new List<PatientAccessKey> ( ) ;

         using ( DbDataReader reader = command.ExecuteReader ( ) )
         {
            while ( reader.Read ( ) )
            {
               PatientAccessKey access = new PatientAccessKey ( ) ;


               access.PatientID = reader.GetString ( 0 ) ;
               access.AccessKey = reader.GetString ( 1 ) ;

               accessList.Add ( access ) ;
            }
         }

         return accessList.ToArray ( ) ;
      }

      /// <summary>
      /// Get all patient IDs that are accessible to the given user and the list of groups (AND operation).
      /// </summary>
      /// <param name="user"></param>
      /// <param name="groups"></param>
      /// <returns></returns>
      public List<string> GetPatientIDs ( string user, string[] groups )
      {
          //
          // Patient access rights are not active so we will always return null
          //          
         using ( DbConnection connection = DataProvider.CreateConnection ( ) )
         {
            using ( DbCommand command = connection.CreateCommand ( ) )
            {
                List<string> patientIds = null;


               command.CommandText = "SELECT DISTINCT [PatientID] FROM [RolesPatients] WHERE 1 = 1 " ;

               if ( !string.IsNullOrEmpty ( user ) )
               {
                  command.CommandText += " AND UserID='" + user + "' " ;
               }

               if ( null != groups && groups.Length > 0 )
               {
                  string groupsString = string.Join ( ",", groups ) ;

                  if (!string.IsNullOrEmpty(user))
                      command.CommandText += " OR ";
                  else
                      command.CommandText += " AND ";

                  command.CommandText += " RoleID in ('" + groupsString + "') " ;
               }

               connection.Open ( ) ;

               using ( DbDataReader reader = command.ExecuteReader ( ) )
               {
                  if(reader.HasRows)
                      patientIds = new List<string>();
                  while ( reader.Read ( ) ) 
                  {                      
                     patientIds.Add ( reader.GetString ( 0 ) ) ;
                  }
               }

               return patientIds ;
            }
         }
      }

      public void AddAeRole(string aeTitle, string role)
      {
         using (DbConnection connection = DataProvider.CreateConnection())
         {
            using (DbCommand command = connection.CreateCommand())
            {
               command.CommandText = SqlCommands.AddAeRoleCommand;

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@aetitle";
                  p.Size = aeTitle.Length;
                  p.Value = aeTitle;

                  command.Parameters.Add(p);
               }

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@rolename";
                  p.Size = role.Length;
                  p.Value = role;

                  command.Parameters.Add(p);
               }

               connection.Open();
               command.ExecuteNonQuery();
               connection.Close();
            }
         }
      }

      public void DeleteAeRole(string aeTitle, string role)
      {
         using (DbConnection connection = DataProvider.CreateConnection())
         {
            using (DbCommand command = connection.CreateCommand())
            {
               command.CommandText = SqlCommands.DeleteAeRoleCommand;

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@aetitle";
                  p.Size = aeTitle.Length;
                  p.Value = aeTitle;

                  command.Parameters.Add(p);
               }

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@rolename";
                  p.Size = role.Length;
                  p.Value = role;

                  command.Parameters.Add(p);
               }

               connection.Open();
               command.ExecuteNonQuery();
               connection.Close();
            }
         }
      }

      private List<string> GetAeRolesList(DbCommand command)
      {
         List<string> rolesList = new List<string>();

         using (DbDataReader reader = command.ExecuteReader())
         {
            while (reader.Read())
            {
               string aeTitle = reader.GetString(0);

               rolesList.Add(aeTitle);
            }
         }

         return rolesList;
      }

      private List<AeAccessKey> GetAllAeRolesRecordsList(DbCommand command)
      {
         List<AeAccessKey> aeRolesRecords = new List<AeAccessKey>();

         using (DbDataReader reader = command.ExecuteReader())
         {
            while (reader.Read())
            {
               string aeTitle = reader.GetString(0);
               string aeRole = reader.GetString(1);
               AeAccessKey aeRoleRecord = new AeAccessKey();
               aeRoleRecord.AeTitle = aeTitle;
               aeRoleRecord.AccessKey = aeRole;

               aeRolesRecords.Add(aeRoleRecord);
            }
         }

         return aeRolesRecords;
      }

      public List<string> GetAeRoles(string aeTitle)
      {
         List<string> aeRoleList = null;

         using (DbConnection connection = DataProvider.CreateConnection())
         {
            using (DbCommand command = connection.CreateCommand())
            {
               command.CommandText = SqlCommands.GetAeRolesCommand;

               {
                  var p = command.CreateParameter();
                  p.DbType = DbType.String;
                  p.Direction = ParameterDirection.Input;
                  p.ParameterName = "@aetitle";
                  p.Size = aeTitle.Length;
                  p.Value = aeTitle;

                  command.Parameters.Add(p);
               }

               connection.Open();
               aeRoleList = GetAeRolesList(command);
               connection.Close();
            }
         }

         if (aeRoleList == null)
         {
            aeRoleList = new List<string>();
         }
         return aeRoleList;
      }

      public List<AeAccessKey> GetAllAeRoleRecords()
      {
         List<AeAccessKey> aeRoleRecords = null;

         using (DbConnection connection = DataProvider.CreateConnection())
         {
            using (DbCommand command = connection.CreateCommand())
            {
               command.CommandText = SqlCommands.GetAllAeRoleRecordsCommand;

               connection.Open();
               aeRoleRecords = GetAllAeRolesRecordsList(command);
               connection.Close();
            }
         }

         if (aeRoleRecords == null)
         {
            aeRoleRecords = new List<AeAccessKey>();
         }
         return aeRoleRecords;
      }

      private static class SqlCommands
      {
         public const string GrantUserAccess = @"INSERT INTO [RolesPatients]([PatientID],[UserID])

SELECT DISTINCT @patientid, @userid WHERE NOT Exists 
( 
   Select * FROM RolesPatients where PatientID= @patientid AND [UserID]=@userid 
)" ;
      
      
         public const string DenyUserAccess = @"DELETE FROM [RolesPatients] WHERE 
PatientID= @patientid AND [UserID]=@userid" ;
      
         public const string GrantRoleAccess = @"
INSERT INTO [RolesPatients]([PatientID],[RoleID])

SELECT DISTINCT @patientid, @roleid WHERE NOT Exists 
( 
	Select * FROM RolesPatients where PatientID= @patientid AND [RoleID]=@roleid 
)" ;
      
         public const string DenyRoleAccess = @"DELETE FROM [RolesPatients] WHERE 
PatientID= @patientid AND [RoleID]=@roleid" ;

         public const string GetUserAccess = "SELECT [PatientID], [UserID] FROM [RolesPatients] WHERE UserID = @userid" ;
         public const string GetRoleAccess = "SELECT [PatientID], [RoleID] FROM [RolesPatients] WHERE RoleID = @roleid" ;

#if LEADTOOLS_V19_OR_LATER
         public const string DeleteAllUserRights = @"DELETE FROM [RolesPatients] WHERE [UserID]= @userid";
         public const string DeleteAllRoleRights = @"DELETE FROM [RolesPatients] WHERE [RoleID]= @roleid";
#endif

         public const string GetAeRolesCommand = @"SELECT [RoleName] FROM [RolesAeMapping] WHERE [AETitle] = @aetitle";

         public const string GetAllAeRoleRecordsCommand = @"SELECT [AETitle], [RoleName] FROM [RolesAeMapping] ORDER BY [AETitle]";

         public const string AddAeRoleCommand = @"
            INSERT INTO [RolesAeMapping]([AETitle],[RoleName])
            SELECT DISTINCT @aetitle, @rolename WHERE NOT Exists 
            ( 
	            Select * FROM [RolesAeMapping] where AETitle= @aetitle AND [RoleName]=@rolename 
            )";

         public const string DeleteAeRoleCommand = @"DELETE FROM [RolesAeMapping] WHERE AETitle= @aetitle AND [RoleName]=@rolename";
      }
   }
}
