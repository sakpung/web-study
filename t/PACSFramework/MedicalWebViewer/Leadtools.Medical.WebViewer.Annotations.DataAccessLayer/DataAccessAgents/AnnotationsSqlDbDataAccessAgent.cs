// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;
using System.Data;

namespace Leadtools.Medical.WebViewer.Annotations
{
   public class AnnotationsSqlDbDataAccessAgent : IAnnotationsDataAccessAgent
   {
      public AnnotationsSqlDbDataAccessAgent(string connectionString)
      {
         DBConnectionString = connectionString ;
         
         _databaseProvider = CreateDatabaseProvider ( ) ;
      }
      
      public string SaveAnnotations ( string seriesInstanceUID, string filePath, string userData ) 
      {
         using (DbConnection dbConnection = _databaseProvider.CreateConnection())
         {
            DbCommand dbCommand = dbConnection.CreateCommand();
            
            dbCommand.CommandText = @"INSERT INTO dbo.Annotations ([SeriesInstanceUID], [FilePath], [UserData]) VALUES (@seriesInstanceUID, @filePath, @userData) SELECT SCOPE_IDENTITY() AS _annId";
            
            DbParameter seriesParam = dbCommand.CreateParameter();
            seriesParam.ParameterName = "@seriesInstanceUID"; 
            seriesParam.DbType = DbType.String; 
            seriesParam.Value = seriesInstanceUID;
            dbCommand.Parameters.Add(seriesParam);
            
            DbParameter filePathParam = dbCommand.CreateParameter();
            filePathParam.ParameterName = "@filePath"; 
            filePathParam.DbType = DbType.String; 
            filePathParam.Value = filePath;
            dbCommand.Parameters.Add(filePathParam);
            
            DbParameter userDataParam = dbCommand.CreateParameter();
            userDataParam.ParameterName = "@userData"; 
            userDataParam.DbType = DbType.String; 
            userDataParam.Value = userData;
            dbCommand.Parameters.Add(userDataParam);
            
            DbParameter annIdParam = dbCommand.CreateParameter();
            annIdParam.ParameterName = "_annId"; 
            annIdParam.SourceColumn= "AnnId" ;
            annIdParam.DbType = DbType.Int32; 
            annIdParam.Direction = ParameterDirection.Output;
            dbCommand.Parameters.Add(annIdParam);
         
            dbCommand.CommandType = CommandType.Text;
            dbCommand.Connection.Open();

            object idValue = null ;
            idValue = dbCommand.ExecuteScalar ( ) ;
            if ( null == idValue || DBNull.Value == idValue )
            {
               throw new Exception ( "Error saving annotations" ) ;
            }
            else
            {
               return System.Convert.ToString ( idValue ) ;
            }
         }
      }
      
      public string GetAnnotationsFile ( string annotationID ) 
      {
         using (DbConnection dbConnection = _databaseProvider.CreateConnection())
         {
            DbCommand dbCommand = dbConnection.CreateCommand();
            
            dbCommand.CommandText = @"SELECT [FilePath] FROM dbo.Annotations WHERE [AnnId] = @annId" ;
            
            DbParameter annIdParam = dbCommand.CreateParameter();
            annIdParam.ParameterName = "@annId"; 
            annIdParam.DbType = DbType.Decimal; 
            annIdParam.Value = int.Parse ( annotationID ) ;
            dbCommand.Parameters.Add(annIdParam);
            
            dbConnection.Open ( ) ;
            
            return dbCommand.ExecuteScalar ( ) as string ;
         }
      }
      
      public AnnotationIdentifier[] FindSeriesAnnotations ( string seriesInstanceUID ) 
      {
         using (DbConnection dbConnection = _databaseProvider.CreateConnection())
         {
            DbCommand dbCommand = dbConnection.CreateCommand();
            
            dbCommand.CommandText = @"SELECT [AnnId], [SeriesInstanceUID], [UserData] FROM dbo.Annotations WHERE [SeriesInstanceUID] = @seriesInstanceUID" ;
            
            DbParameter seriesInstanceUIDParam = dbCommand.CreateParameter();
            seriesInstanceUIDParam.ParameterName = "@seriesInstanceUID"; 
            seriesInstanceUIDParam.DbType = DbType.String; 
            seriesInstanceUIDParam.Value = seriesInstanceUID ;
            dbCommand.Parameters.Add(seriesInstanceUIDParam);
            
            dbConnection.Open ( ) ;
            
            using ( DbDataReader reader = dbCommand.ExecuteReader ( ) )
            {
               List <AnnotationIdentifier> annIds = new List<AnnotationIdentifier> ( ) ;
               
               while ( reader.Read ( ) ) 
               {
                  AnnotationIdentifier annId = new AnnotationIdentifier ( ) ;
                  
                  annId.AnnotationID = reader.GetValue ( 0 ).ToString ( ) ;
                  annId.SeriesInstanceUID = reader.GetString ( 1 ) ;
                  annId.UserData = reader.GetString ( 2 ) ;
                  
                  annIds.Add ( annId ) ;
               }
               
               return annIds.ToArray ( ) ;
            }
         }
      }
      
      public void DeleteAnnotations ( string annotationID ) 
      {
         using (DbConnection dbConnection = _databaseProvider.CreateConnection())
         {
            DbCommand dbCommand = dbConnection.CreateCommand();
            
            dbCommand.CommandText = @"DELETE FROM dbo.Annotations WHERE [AnnId] = @annId" ;
            
            DbParameter annIdParam = dbCommand.CreateParameter();
            annIdParam.ParameterName = "@annId"; 
            annIdParam.DbType = DbType.Decimal; 
            annIdParam.Value = int.Parse ( annotationID ) ;
            dbCommand.Parameters.Add(annIdParam);
            
            dbConnection.Open ( ) ;
            
            dbCommand.ExecuteNonQuery ( ) ;
         }
      }
      
      protected virtual Database CreateDatabaseProvider()
      {
         return new SqlDatabase(DBConnectionString);
      }
      
      private Database _databaseProvider ;
      
      public string DBConnectionString
      {
         get ;
         private set ;
      }
   }
}
