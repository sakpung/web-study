// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Security;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Leadtools.Medical.WebViewer.Jobs.DataAccessLayer
{
   public abstract class DownloadJobsDataAccessAgent : IDownloadJobsDataAccessAgent
   {
      public DownloadJobsDataAccessAgent(string connectionString)
      {
         DBConnectionString = connectionString;
      }

      public string DBConnectionString
      {
         get;
         set;
      }

      protected abstract Database CreateDatabaseProvider();

      protected DbConnection CreateConnection()
      {
         return CreateDatabaseProvider().CreateConnection();
      }

      
      public virtual void AddJob
      (
          string sType,
          string sObject,
          int nStatus,
          int nCompletedStatus,
          string sUserData,
          string sOwner,
          out int nId
      )
      {
         System.Diagnostics.Debug.Assert(sType.Length <= 50);

         using (DbConnection dbConnection = CreateConnection())
         {
            DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = @"INSERT INTO dbo.jobsQueue (type, object, status, completedstatus, timestamp, userdata, owner, retries) VALUES (@type, @object, @status, @completedstatus, @timestamp, @userdata, @owner, @retries) SELECT SCOPE_IDENTITY() AS _id";
            
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@type"; param.DbType = DbType.String; param.Value = sType;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@object"; param.DbType = DbType.String; param.Value = sObject;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@status"; param.DbType = DbType.Int32; param.Value = nStatus;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@completedstatus"; param.DbType = DbType.Int32; param.Value = nStatus;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@timestamp"; param.DbType = DbType.DateTime; param.Value = DateTime.Now;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@userdata"; param.DbType = DbType.String; param.Value = (sUserData==null)?"":sUserData;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@owner"; param.DbType = DbType.String; param.Value = sOwner;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@retries"; param.DbType = DbType.Int32; param.Value = 0;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "_id"; param.DbType = DbType.Int32; param.Direction = ParameterDirection.Output;
               dbCommand.Parameters.Add(param);
            }

            dbCommand.CommandType = CommandType.Text;
            dbCommand.Connection.Open();

            using (var sqlReader = dbCommand.ExecuteReader())
            {
               if (!sqlReader.HasRows)
               {
                  throw new Exception("Error saving a job");
               }

               if (!sqlReader.Read())
               {
                  throw new Exception("Error saving a job");
               }

               nId = int.Parse(sqlReader["_id"].ToString());
            }
            
            return;
         }
      }

      public virtual void SetJobStatus
      (
          int nId,
          int nStatus,
         int nCompletedStatus,
         bool bIncrementRetries,
         string sError         
      )
      {
         using (DbConnection dbConnection = CreateConnection())
         {
            DbCommand dbCommand = dbConnection.CreateCommand();
            
            if (string.IsNullOrEmpty(sError))
            {
               dbCommand.CommandText = @"UPDATE dbo.jobsQueue SET status = @status, completedstatus = @completedstatus, error = NULL";
            }
            else
            {
               dbCommand.CommandText = @"UPDATE dbo.jobsQueue SET status = @status, completedstatus = @completedstatus, error = @error";
            }

            if (bIncrementRetries)
            {
               dbCommand.CommandText += @" ,[retries] = ([retries]+1)";
            }

            dbCommand.CommandText += @" WHERE id = @id";

            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@status"; param.DbType = DbType.Int32; param.Value = nStatus;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@completedstatus"; param.DbType = DbType.Int32; param.Value = nCompletedStatus;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@id"; param.DbType = DbType.Int32; param.Value = nId;
               dbCommand.Parameters.Add(param);
            }
            if (!string.IsNullOrEmpty(sError))
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@error"; param.DbType = DbType.String; param.Value = sError;
               dbCommand.Parameters.Add(param);
            }

            dbCommand.CommandType = CommandType.Text;
            dbCommand.Connection.Open();

            int nRows = dbCommand.ExecuteNonQuery();

            if (nRows <= 0)
            {
               throw new Exception("Error setting job status");
            }
         }
      }

      public virtual void ReadJobStatus
      (
          long nId,
          out int nStatus,
          out int nCompletedStatus,
         out string sError,
         out string sUserData
      )
      {
         nStatus = 0;
         nCompletedStatus = 0;
         sError = string.Empty;
         sUserData = string.Empty;

         using (DbConnection dbConnection = CreateConnection())
         {
            DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = @"SELECT [status], [completedstatus], [error], [userdata] FROM [dbo].[jobsQueue] WHERE id = @id";

            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@id"; param.DbType = DbType.Int32; param.Value = nId;
               dbCommand.Parameters.Add(param);
            }

            dbCommand.CommandType = CommandType.Text;
            dbCommand.Connection.Open();

            using (var sqlReader = dbCommand.ExecuteReader())
            {
               if (!sqlReader.HasRows)
               {
                  throw new Exception("Error retrieving job");
               }

               if (!sqlReader.Read())
               {
                  throw new Exception("Error retrieving job");
               }

               nStatus = int.Parse(sqlReader["status"].ToString());
               nCompletedStatus = int.Parse(sqlReader["completedstatus"].ToString());
               if (null != sqlReader["error"])
               {
                  sError = sqlReader["error"].ToString();
               }
               if (null != sqlReader["userdata"])
               {
                  sUserData = sqlReader["userdata"].ToString();
               }
            }
         }
      }

      public virtual string[] ListJobs
      (
         string sOwner,
          int nStatus,
          int nCompletedStatus,
         int nMaxRetries,
         ListJobsFlags nFlags
      )      
      {
         List<string> JobsIdsList = new List<string>();
         

         bool bOwner = (nFlags & ListJobsFlags.Owner) > 0;
         bool bStatus = (nFlags&ListJobsFlags.Status)>0;
         bool bCompletedStatus = (nFlags & ListJobsFlags.CompletedStatus) > 0;
         bool bNegateCompletedStatus = (nFlags & ListJobsFlags.NegateCompletedStatus) > 0;
         bool bMinRetries = (nFlags & ListJobsFlags.Retries) > 0;

         using (DbConnection dbConnection = CreateConnection())
         {
            DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = @"SELECT [dbo].[jobsQueue].[id] FROM [dbo].[jobsQueue] WHERE 1=1";

            if (bStatus)
            {
               dbCommand.CommandText += @" AND status = @status";
            }
            if (bCompletedStatus)
            {
               if (bNegateCompletedStatus)
               {
                  dbCommand.CommandText += @" AND completedstatus <> @completedstatus";
               }
               else
               {
                  dbCommand.CommandText += @" AND completedstatus = @completedstatus";
               }
            }
            if (bMinRetries)
            {
               dbCommand.CommandText += @" AND retries <= @retries";
            }

            if (bOwner)
            {
               dbCommand.CommandText += @" AND owner = @owner";
            }

            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@status"; param.DbType = DbType.Int32; param.Value = nStatus;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@completedstatus"; param.DbType = DbType.Int32; param.Value = nCompletedStatus;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@retries"; param.DbType = DbType.Int32; param.Value = nMaxRetries;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@owner"; param.DbType = DbType.String; param.Value = sOwner;
               dbCommand.Parameters.Add(param);
            }

            dbCommand.CommandType = CommandType.Text;
            dbCommand.Connection.Open();

            using (var sqlReader = dbCommand.ExecuteReader())
            {
               if (sqlReader.HasRows)
               {
                  while (sqlReader.Read())
                  {
                     JobsIdsList.Add(sqlReader["id"].ToString());
                  }
               }
            }
         }
         return JobsIdsList.ToArray();
      }

      public virtual void DeleteJobs
      (
         string sOwner,
         int nStatus,
         int nCompletedStatus,
         int nMinRetries,
         DateTime MinTimeStamp,
         ListJobsFlags nFlags
      )
      {
         List<string> JobsIdsList = new List<string>();


         bool bOwner = (nFlags & ListJobsFlags.Owner) > 0;
         bool bStatus = (nFlags & ListJobsFlags.Status) > 0;
         bool bCompletedStatus = (nFlags & ListJobsFlags.CompletedStatus) > 0;
         bool bNegateCompletedStatus = (nFlags & ListJobsFlags.NegateCompletedStatus) > 0;
         bool bMinRetries = (nFlags & ListJobsFlags.Retries) > 0;
         bool bTimeStamp = (nFlags & ListJobsFlags.TimeStamp) > 0;

         using (DbConnection dbConnection = CreateConnection())
         {
            DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = @"DELETE FROM [dbo].[jobsQueue] WHERE 1=1";

            if (bStatus)
            {
               dbCommand.CommandText += @" AND status = @status";
            }
            if (bCompletedStatus)
            {
               if (bNegateCompletedStatus)
               {
                  dbCommand.CommandText += @" AND completedstatus <> @completedstatus";
               }
               else
               {
                  dbCommand.CommandText += @" AND completedstatus = @completedstatus";
               }
            }
            if (bMinRetries)
            {
               dbCommand.CommandText += @" AND retries >= @retries";
            }

            if (bOwner)
            {
               dbCommand.CommandText += @" AND owner = @owner";
            }

            if (bTimeStamp)
            {
               dbCommand.CommandText += @" AND timestamp <= @timestamp";
            }

            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@status"; param.DbType = DbType.Int32; param.Value = nStatus;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@completedstatus"; param.DbType = DbType.Int32; param.Value = nCompletedStatus;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@retries"; param.DbType = DbType.Int32; param.Value = nMinRetries;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@owner"; param.DbType = DbType.String; param.Value = sOwner;
               dbCommand.Parameters.Add(param);
            }
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@timestamp"; param.DbType = DbType.DateTime; param.Value = MinTimeStamp;
               dbCommand.Parameters.Add(param);
            }

            dbCommand.CommandType = CommandType.Text;
            dbCommand.Connection.Open();

            dbCommand.ExecuteScalar();
         }
      }

      public virtual void DeleteJobs
      (
         string sOwner,
         int[] jobIds
      )
      {
         using (DbConnection dbConnection = CreateConnection())
         {
            DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = @"DELETE FROM [dbo].[jobsQueue] WHERE 1=1";

            if (!string.IsNullOrEmpty ( sOwner ) )
            {
               dbCommand.CommandText += @" AND owner = @owner";

               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@owner"; 
               param.DbType = DbType.String; 
               param.Value = sOwner;
               dbCommand.Parameters.Add(param);
               
            }
            
            if ( jobIds != null && jobIds.Length > 0 )
            {
               string condition = " AND (" ;
               for ( int jobIndex = 0; jobIndex < jobIds.Length; jobIndex++ )
               {
                  condition += " id=" + jobIds [ jobIndex ] ;

                  if ( jobIndex < jobIds.Length - 1 )
                  {
                     condition += " OR " ;
                  }
               }

               condition += " ) " ;

               dbCommand.CommandText += condition ;
            }

            dbCommand.CommandType = CommandType.Text;
            dbCommand.Connection.Open();

            dbCommand.ExecuteScalar();
         }
      }

      public virtual void ReadJob
      (
          long nId,
          out string sType,
          out string sObject,
          out int nStatus,
          out int nCompletedStatus,
          out DateTime time,
         out string sError,
         out string sUserData,
         out string sOwner
      )
      {
         sType = string.Empty;
         sObject = string.Empty;
         nStatus = 0;
         nCompletedStatus = 0;
         time = DateTime.Now;
         sUserData = string.Empty;
         sError = string.Empty;
         sOwner = string.Empty;

         using (DbConnection dbConnection = CreateConnection())
         {
            DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = @"SELECT * FROM [dbo].[jobsQueue] WHERE [jobsQueue].[id] = @id";
            
            {
               DbParameter param = dbCommand.CreateParameter();
               param.ParameterName = "@id"; param.DbType = DbType.Int32; param.Value = nId;
               dbCommand.Parameters.Add(param);
            }

            dbCommand.CommandType = CommandType.Text;
            dbCommand.Connection.Open();

            using (var sqlReader = dbCommand.ExecuteReader())
            {
               if (sqlReader.HasRows)
               {
                  if (sqlReader.Read())
                  {
                     sType = sqlReader["type"].ToString();
                     sObject = sqlReader["object"].ToString();
                     nStatus = int.Parse(sqlReader["status"].ToString());
                     nCompletedStatus = int.Parse(sqlReader["completedstatus"].ToString());
                     if (null != sqlReader["timestamp"])
                     {
                        time = DateTime.Parse(sqlReader["timestamp"].ToString());
                     }
                     if (null != sqlReader["userdata"])
                     {
                        sUserData = sqlReader["userdata"].ToString();
                     }
                     if (null != sqlReader["error"])
                     {
                        sError = sqlReader["error"].ToString();
                     }
                     if (null != sqlReader["owner"])
                     {
                        sOwner = sqlReader["owner"].ToString();
                     }
                     return;
                  }
               }
            }
         }
         throw new Exception("Error retrieving job");
      }

   }
}
