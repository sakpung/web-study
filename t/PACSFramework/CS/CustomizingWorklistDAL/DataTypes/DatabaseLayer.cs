// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.Worklist.DataAccessLayer.Configuration;
using Leadtools.Medical.Worklist.DataAccessLayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data.SqlCe;
using Leadtools.DicomDemos;
using Leadtools.Demos.StorageServer.DataTypes;

namespace CSCustomizingWorklistDAL.DataTypes
{
   public class DatabaseLayer
   {
      private DatabaseUtility    _database ;
      private WorklistDataSource _source ;
      private IWorklistDataAccessAgent _agent ;
      
      public DatabaseLayer ( WorklistDataSource source ) 
      {
         if ( IsDataAccessSettingsValid ( ) )
         {
            _source = source ;
            
            System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();

            WorklistDataAccessConfigurationView view = new WorklistDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameDemoServer, null);

            ConnectionString = view.GetConnectionStringSettings ( ).ConnectionString ;
            Provider         = view.GetConnectionStringSettings ( ).ProviderName ;
            
            if ( Provider == DataAccessMapping.DefaultSqlProviderName )
            {
               _database = new SqlServerDatabaseUtility ( ConnectionString ) ;
               _agent    = new WorklistSqlDbDataAccessAgent ( ConnectionString ) ;
            }
            else if ( Provider == DataAccessMapping.DefaultSqlCe3_5ProviderName )
            {
               _database = new SqlCeDatabaseUtility ( ConnectionString ) ;
               _agent    = new WorklistSqlCeDataAccessAgent ( ConnectionString ) ;
            }
            else
            {
               throw new NotImplementedException ( ) ;
            }
         }
      }
      
      public void UpdateDatabase ( ) 
      {
         foreach ( DatabaseDicomTags dbColumnTag in _source.DatabaseTags ) 
         {
            if ( !_database.IsColumnExists ( dbColumnTag.TableName, dbColumnTag.ColumnName ) )
            {
               _database.AddStringColumn ( dbColumnTag.TableName, dbColumnTag.ColumnName ) ;
            }
         }
      }
      
      public bool IsDatabaseUpdated ( ) 
      {
         foreach ( DatabaseDicomTags dbColumnTag in _source.DatabaseTags ) 
         {
            if ( !_database.IsColumnExists ( dbColumnTag.TableName, dbColumnTag.ColumnName ) )
            {
               return false ;
            }
         }
         
         return true ;
      }

      public static bool IsDataAccessSettingsValid()
      {
         System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();

         WorklistDataAccessConfigurationView view = new WorklistDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameDemoServer, null);

         ConfigurationManager.RefreshSection(view.DataAccessSettingsSectionName);
         
         return GlobalPacsUpdater.IsDataAccessSettingsValid(configuration, view.DataAccessSettingsSectionName, DicomDemoSettingsManager.ProductNameDemoServer);
      }

      
      public string ConnectionString
      {
         get ;
         private set ;
      }
      
      public string Provider
      {
         get ;
         private set ;
      }

      public IWorklistDataAccessAgent GetWorklistDataAgent ( )
      {
         return _agent ;
      }
   }
   
   class SqlServerDatabaseUtility : DatabaseUtility
   {
      public SqlServerDatabaseUtility ( string connectionString ) 
      : base ( connectionString )
      {
         
      }
      
      public override void AddStringColumn ( string tableName, string columnName )
      {
         using ( DbConnection connection = DataProvider.CreateConnection ( ) )  
         {
             connection.Open ( ) ;
             
             using ( DbCommand command = connection.CreateCommand ( ) ) 
             {
                 command.CommandText = string.Format ( "alter table [{0}] add [{1}] nvarchar(400)" , tableName, columnName ) ;
                 command.ExecuteNonQuery ( ) ;
             }
         }
      }
      
      public override bool IsColumnExists ( string tableName, string columnName ) 
      {
      
         using ( DbConnection connection = DataProvider.CreateConnection ( ) )  
         {
             connection.Open ( ) ;
             
             using ( DbCommand command = connection.CreateCommand ( ) ) 
             {
                 command.CommandText = string.Format ( "select column_name from INFORMATION_SCHEMA.columns where table_name = '{0}' and column_name = '{1}'" , 
                                                       tableName, 
                                                       columnName ) ;
                 
                 object result = command.ExecuteScalar ( ) ;
                 
                 return null != result && result.ToString ( ) == columnName ;
             }
         }
      }
      
      protected Database DataProvider
      {
         get
         {
            if ( null == _dataProvider )
            {
               _dataProvider = CreateDatabaseProvider ( ) ;
            }
            
            return _dataProvider ;
         }
      }
      
      protected virtual Database CreateDatabaseProvider ( ) 
      {
         return new SqlDatabase ( ConnectionString ) ;
      }
      
      private Database _dataProvider ;
   }
   
   class SqlCeDatabaseUtility : SqlServerDatabaseUtility
   {
      public SqlCeDatabaseUtility ( string connectionString )
      : base ( connectionString )
      {
      }
      
      protected override Database CreateDatabaseProvider()
      {
         return new SqlCeDatabase ( ConnectionString ) ;
      }
   }
   
   abstract class DatabaseUtility
   {
      public DatabaseUtility ( string connectionString )
      {
         ConnectionString = connectionString ;
      }
      
      public abstract void AddStringColumn ( string tableName, string columnName ) ;
      
      public abstract bool IsColumnExists ( string tableName, string columnName ) ;
      
      public string ConnectionString
      {
         get ;
         private set ;
      }
   }
}
