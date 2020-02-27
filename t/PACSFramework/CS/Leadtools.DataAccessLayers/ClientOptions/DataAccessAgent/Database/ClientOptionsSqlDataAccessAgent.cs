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
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.SqlClient;

namespace Leadtools.DataAccessLayers
{
   public class ClientOptionsSqlDataAccessAgent : ClientOptionsDataAccessAgent
   {
      public ClientOptionsSqlDataAccessAgent(string connectionString) 
      : base ( connectionString ) 
      {
         
      }      

      protected override Database CreateDatabaseProvider()
      {
         return new SqlDatabase(ConnectionString);
      }

      protected override object RunQueryScalar(string query)
      {
         try
         {
            // Create a connection, a command and an adapter then fill a dataset and return it
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
               using (SqlCommand command = new SqlCommand(query, connection))
               {
                  connection.Open();
                  return command.ExecuteScalar();
               }
            }
         }
         catch (Exception exception)
         {
            throw exception;
         }
      }

      protected override void InitializeGetDefaultOptions(DbCommand command)
      {
         command.CommandText = "SELECT * FROM ClientOptions";
      }
      
      protected override void InitializeGetClientOptions(DbCommand command, string userName)
      {
         command.CommandText = string.Format("SELECT * FROM UserClientOptions WHERE UserName='{0}'", userName);
      }
   }
}
