// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Specialized;
using Microsoft.Win32;
using Microsoft.SqlServer.Server;
using Microsoft.SqlServer;
using System.IO;
using System.Data.Sql;
using System.Windows.Forms;

namespace Leadtools.Common.JobProcessor
{
   internal partial class SqlUtilities
   {
      #region Public

      #region Methods

      private SqlUtilities() { }
      ~SqlUtilities() { }

      public static StringCollection GetServerList(out string local)
      {
         StringCollection sqlServers = new StringCollection();
         local = String.Empty;
         try
         {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            System.Data.DataTable servers = instance.GetDataSources();

            foreach (DataRow row in servers.Rows)
            {
               string server = row[0].ToString();
               if (String.IsNullOrEmpty(row[1].ToString()))
               {
                  sqlServers.Add(server);
               }
               else
               {
                  if (string.Compare(server, Environment.MachineName, true) == 0)
                  {
                     local = string.Format(@"{0}\{1}", server, row[1].ToString());
                  }

                  sqlServers.Add(string.Format(@"{0}\{1}", server, row[1].ToString()));
               }
            }
         }
         catch (Exception exception)
         {
            MessageBox.Show(null, exception.Message, "Error", MessageBoxButtons.OK);
         }

         return sqlServers;
      }

      public static StringCollection GetDatabaseList(string connectionString)
      {
         using (SqlConnection connection = new SqlConnection(connectionString))
         {
               connection.Open();

               using (SqlCommand command = new SqlCommand(Constants.SqlScript.SelectDatabasesName, connection))
               {
                  using (SqlDataReader reader = command.ExecuteReader())
                  {
                     StringCollection databaseNames = new StringCollection();
                     while (reader.Read())
                     {
                        databaseNames.Add(reader.GetString(0));
                     }

                     return databaseNames;
                  }
               }
            }
      }

      public static string CreateSqlConnection(string connectionString)
      {
         SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
         sqlConnectionStringBuilder.InitialCatalog = string.Empty;
         sqlConnectionStringBuilder.Pooling = false;

         return sqlConnectionStringBuilder.ConnectionString;
      }

      public static string GetDatabaseName(string connectionString)
      {
         SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

         return sqlConnectionStringBuilder.InitialCatalog;
      }

      public static void CreateDatabase(string connectionString)
      {
         using (SqlConnection connection = new SqlConnection(CreateSqlConnection(connectionString)))
         {
               connection.Open();
               string databaseName = string.Format(Constants.SqlScript.CreateDatabase, GetDatabaseName(connectionString));
               using (SqlCommand command = new SqlCommand(databaseName, connection))
               {
                  command.ExecuteNonQuery();
               }
            }
      }

      public static void DropDatabase(string connectionString)
      {
         using (SqlConnection connection = new SqlConnection(CreateSqlConnection(connectionString)))
         {
               connection.Open();
               string databaseName = string.Format(Constants.SqlScript.DropDatabase, GetDatabaseName(connectionString));
               using (SqlCommand command = new SqlCommand(databaseName, connection))
               {
                  command.ExecuteNonQuery();
               }
            }
      }

      public static bool IsDatabaseExist(string connectionString)
      {
         bool exist = false;

         using (SqlConnection connection = new SqlConnection(CreateSqlConnection(connectionString)))
         {
               connection.Open();
               string databaseName = string.Format(Constants.SqlScript.SelectDatabase, GetDatabaseName(connectionString));
               using (SqlCommand command = new SqlCommand(databaseName, connection))
               {
                  object o = command.ExecuteScalar();
                  exist = o != null;
               }
            }

         return exist;
      }

      public static bool IsDatabaseConnected
      (
         string connectionString,
         string strDatabaseName
      )
      {
         try
         {
            SqlConnection sqlConnection = null;
            int processesCount = -1;
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            using (sqlConnection)
            {
               SqlCommand ProcessCommand = null;

               ProcessCommand = new SqlCommand(String.Format(Constants.ADOCommandText.SELECT_ACTIVE_PROCESSES_EXCEPT_CURRENT_COUNT, strDatabaseName),
                                                 sqlConnection);

               processesCount = (int)ProcessCommand.ExecuteScalar();
            }

            return (processesCount > 0);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      public static bool TestSQLConnectionString
      (
         string connectionString,
         out string connectionErrorMessage,
         out string version
      )
      {
         version = string.Empty;
         try
         {
            System.Data.SqlClient.SqlConnection SQLConnectionTest = null;
            SQLConnectionTest = new System.Data.SqlClient.SqlConnection();
            SQLConnectionTest.ConnectionString = connectionString;
            SetConnectionPoolingState(ref connectionString, false);

            try
            {
               SQLConnectionTest.Open();

               connectionErrorMessage = string.Empty;
               version = SQLConnectionTest.ServerVersion;

               return true;
            }
            catch (Exception exception)
            {
               connectionErrorMessage = exception.Message;

               return false;
            }
            finally
            {
               SQLConnectionTest.Close();
            }
         }
         catch (Exception exp)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exp;
         }
      }

      public static bool IsWindowsAuthentication
      (
         string connectionString
      )
      {
         try
         {
            SqlConnection Connection;
            Connection = new SqlConnection(connectionString);

            if ((-1 == Connection.ConnectionString.ToLower().IndexOf(Constants.ConnectionString.Integrated_Security.ToLower(), 0)) &&
                 (-1 == Connection.ConnectionString.ToLower().IndexOf(Constants.ConnectionString.Trusted_Connection.ToLower(), 0)))
            {
               return false;
            }
            else
            {
               return true;
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      public static bool IsSqlServer2012OrLater(string version)
      {
         return version.StartsWith("11.");
      }

      #endregion

      #endregion

      #region Private

      #region Methods

      private static void SetConnectionPoolingState
      (
         ref string strConnectionString,
         bool bEnabled
      )
      {
         try
         {
            StringBuilder ConnectionStringBuilder;


            RemovePoolingKeyValue(ref strConnectionString);

            ConnectionStringBuilder = new StringBuilder(strConnectionString);

            if (bEnabled)
            {
               ConnectionStringBuilder.Append(Constants.ConnectionString.POOLING_ENABLE);

               strConnectionString = ConnectionStringBuilder.ToString();
            }
            else
            {
               ConnectionStringBuilder.Append(Constants.ConnectionString.POOLING_DISABLE);

               strConnectionString = ConnectionStringBuilder.ToString();
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      private static void RemovePoolingKeyValue
      (
         ref string strConnectionString
      )
      {
         try
         {
            int nStartIndexOfPool = -1;
            int nEndIndexOfPool = -1;


            strConnectionString = strConnectionString.ToLower();
            nStartIndexOfPool = strConnectionString.IndexOf(Constants.ConnectionString.POOLING_KEYWORD);

            if (-1 != nStartIndexOfPool)
            {
               int nPoolingKeyValueLength = -1;


               nEndIndexOfPool = strConnectionString.IndexOf(Constants.SpecialCharacters.SEMICOLON,
                                                               nStartIndexOfPool);

               if (-1 == nEndIndexOfPool)
               {
                  nEndIndexOfPool = strConnectionString.Length - 1;
               }

               nPoolingKeyValueLength = (nEndIndexOfPool - nStartIndexOfPool) + 1;

               strConnectionString = strConnectionString.Remove(nStartIndexOfPool,
                                                                  nPoolingKeyValueLength);
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);

            throw exception;
         }
      }

      #endregion

      #region Data Types Definition

      private class Constants
      {
         public class ConnectionString
         {
            public const string POOLING_KEYWORD = "pooling";
            public const string POOLING_DISABLE = "pooling=false;";
            public const string POOLING_ENABLE = "pooling=true;";
            public const string Integrated_Security = "Integrated Security";
            public const string Trusted_Connection = "Trusted_Connection";
         }

         public class SpecialCharacters
         {
            public const string SEMICOLON = ";";
         }

         public class ADOCommandText
         {
            public const string SELECT_RECORDS_ALL = "SELECT * FROM {0}";
            public const string SELECT_RECORDS_TOP = "SELECT TOP {0} * FROM {1}";
            public const string SELECT_RECORDS_COUNT = "SELECT COUNT ( * ) FROM {0}";
            public const string SELECT_ACTIVE_PROCESSES_EXCEPT_CURRENT_COUNT = "SELECT Count ( Process.spid ) FROM MASTER.dbo.sysdatabases Db, Master.dbo.sysprocesses Process WHERE Db.dbid = Process.dbid AND Db.name = '{0}' AND Process.dbid != @@SPID";
            public const string SELECT_ACTIVE_PROCESSES_EXCEPT_CURRENT = "SELECT Process.spid FROM MASTER.dbo.sysdatabases Db, Master.dbo.sysprocesses Process WHERE Db.dbid = Process.dbid AND Db.name = '{0}' AND Process.dbid != @@SPID";
            public const string KILL_PROCESS = "EXEC KILL {0}";
         }

         public class SqlScript
         {
            public const string SelectTable = "SELECT COUNT ( * ) FROM dbo.sysobjects where id = object_id(N'{0}') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
            public const string CreateDatabase = "CREATE DATABASE [{0}]";
            public const string DropDatabase = "DROP DATABASE [{0}]";
            public const string SelectDatabasesName = "SELECT Name from master.dbo.sysdatabases WHERE NAME NOT IN ('master','msdb','model','tempdb','reportserver','reportservertempdb','datacomsqlaudit','pubs','distribution','northwind')";
            public const string SelectDatabase = "SELECT Name from master.dbo.sysdatabases WHERE NAME NOT IN ('master','msdb','model','tempdb','reportserver','reportservertempdb','datacomsqlaudit','pubs','distribution','northwind') AND Name='{0}'";
         }
      }


      #endregion

      #endregion
   }

}
