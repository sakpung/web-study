// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Common;
using System.Data;
using System.Data.SqlServerCe;
using Leadtools.Logging.Medical;

namespace Leadtools.Configuration.Logging
{
   public static class DB
   {
   
      public static void AddDicomEventLog(DicomLogEntry logEntry)
      {
         try
         {
            using (SqlCeConnection DbConnection = new SqlCeConnection(ConfigurationLoggingSession.ConnectionString))
            {
               DbConnection.Open();

               using (SqlCeCommand insertCommand = DbConnection.CreateCommand())
               {
                  insertCommand.CommandText = @"INSERT INTO [DICOMServerEventLog] ([ServerAETitle], [ServerIPAddress], [ServerPort], [ClientAETitle], [ClientHostAddress], [ClientPort], [Command], [EventDateTime], [Type], [MessageDirection], [Description], [CustomInformation], [DatasetPath]) VALUES (@ServerAETitle, @ServerIPAddress, @ServerPort, @ClientAETitle, @ClientHostAddress, @ClientPort, @Command, @EventDateTime, @Type, @MessageDirection, @Description, @CustomInformation, @DatasetPath)";
                  insertCommand.CommandType = CommandType.Text;

                  insertCommand.Parameters.AddWithValue("@ServerAETitle",       /*DbType.String,*/       logEntry.ServerAETitle);
                  insertCommand.Parameters.AddWithValue("@ServerIPAddress",     /*DbType.String,*/       logEntry.ServerIPAddress);
                  insertCommand.Parameters.AddWithValue("@ServerPort",          /*DbType.Int32,*/        logEntry.ServerPort);
                  insertCommand.Parameters.AddWithValue("@ClientAETitle",       /*DbType.String,*/       logEntry.ClientAETitle);
                  insertCommand.Parameters.AddWithValue("@ClientHostAddress",   /*DbType.String,*/       logEntry.ClientIPAddress);
                  insertCommand.Parameters.AddWithValue("@ClientPort",          /*DbType.Int32,*/        logEntry.ClientPort);
                  insertCommand.Parameters.AddWithValue("@Command",             /*DbType.String,*/       logEntry.Command.ToString());
                  insertCommand.Parameters.AddWithValue("@EventDateTime",       /*DbType.DateTime,*/     logEntry.TimeStamp);
                  insertCommand.Parameters.AddWithValue("@Type",                /*DbType.String,*/       logEntry.LogType.ToString());
                  insertCommand.Parameters.AddWithValue("@MessageDirection",    /*DbType.String,*/       logEntry.MessageDirection.ToString());
                  insertCommand.Parameters.AddWithValue("@Description",         /*DbType.String,*/       logEntry.Description);
                  insertCommand.Parameters.AddWithValue("@CustomInformation",   /*DbType.Binary,*/       string.Empty);

                  string fullPath = string.Empty;
                  if (logEntry.DicomDataset != null && !string.IsNullOrEmpty(ConfigurationLoggingSession.LogDatasetDirectory))
                  {
                     string fileName = Path.GetRandomFileName();
                     fullPath = Path.Combine(ConfigurationLoggingSession.LogDatasetDirectory, fileName);
                     logEntry.DicomDataset.Save(fullPath, Leadtools.Dicom.DicomDataSetSaveFlags.None);
                  }
                  
                  insertCommand.Parameters.AddWithValue("@DatasetPath",         /*DbType.String,*/       fullPath);
                  insertCommand.ExecuteNonQuery();
               }
            }
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false);
            throw exception;
         }
      }
   }
}
