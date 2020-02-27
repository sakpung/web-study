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
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.Forward.DataAccessLayer.DataTypes;
using Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.Medical.Forward.DataAccessLayer
{
   public abstract class ForwardDBDataAccessAgent : IForwardDataAccessAgent
   {
      #region Public Methods
      public ForwardDBDataAccessAgent(string connectionString)
      {
#if TUTORIAL_CUSTOM_DATABASE
      _instanceTableName         = @"MyInstanceTable";
      _columnNameSOPInstanceUID  = @"SOPInstanceUID";
      _columnNameReferencedFile  = @"ImageFilename";
#endif
         ConnectionString = connectionString;
      }                  
      
      #endregion

      #region Public Properties

      public string ConnectionString
      {
         get
         {
            return _connectionString;
         }

         private set
         {
            _connectionString = value;
         }
      }

      #endregion

      #region Protected Abstract Methods

      protected abstract Database CreateDatabaseProvider();
      protected abstract void InitializeGetForwardListCommand(DbCommand command);
      protected abstract void InitializeInsertCommand(DbCommand command, string SOPInstanceUID, DateTime forwardDate, DateTime? expireDate);
      protected abstract void InitializeGetCleanListCommand(DbCommand command);
      protected abstract void InitializeGetForwardCountCommand(DbCommand command);
      protected abstract void InitializeGetCleanCountCommand(DbCommand command);
      protected abstract void InitializeResetCommand(DbCommand command, DateRange range);
      protected abstract void InitializeGetResetCountCommand(DbCommand command, DateRange range);
      protected abstract void InitializeIsForwardedCommand(DbCommand command, string sopInstanceUID) ;
      

      #endregion

      #region Protected Properties

      protected Database DatabaseProvider
      {
         get
         {
            if (null == _dbProvider)
            {
               _dbProvider = CreateDatabaseProvider();
            }

            return _dbProvider;
         }

         private set
         {
            _dbProvider = value;
         }
      }
      
      protected string InstanceTableName
      {
         get { return _instanceTableName; }
      }

      protected string ColumnNameSOPInstanceUID
      {
         get { return _columnNameSOPInstanceUID; }
      }


      protected string ColumnNameReferencedFile
      {
         get { return _columnNameReferencedFile; }
      }

      #endregion

      #region Private Methods

      private bool ReturnFromScalarResult(object result)
      {
         if (result != null && result != DBNull.Value)
         {
            bool boolResult;
            int countValue;


            if (bool.TryParse(result.ToString(), out boolResult))
            {
               return boolResult;
            }
            else if (int.TryParse(result.ToString(), out countValue))
            {
               return countValue > 0;
            }

            return true;
         }
         else
         {
            return false;
         }

      }      

      #endregion

      #region Data Members

      private Database  _dbProvider;
      private string    _connectionString;
      private string    _instanceTableName         = @"Instance";
      private string    _columnNameSOPInstanceUID  = @"SOPInstanceUID";
      private string    _columnNameReferencedFile  = @"ReferencedFile";

      #endregion     
   
      #region IForwardDataAccessAgent Members

      public ForwardInstance[] GetForwardList()
      {
         List<ForwardInstance> list = new List<ForwardInstance>();

         using (DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeGetForwardListCommand(command);
            using (IDataReader reader = DatabaseProvider.ExecuteReader(command))
            {
               while (reader.Read())
               {
                  ForwardInstance instance = new ForwardInstance();

                  instance.SOPInstanceUID = reader.GetColumnValue<string>(ColumnNameSOPInstanceUID);
                  instance.ReferencedFile = reader.GetColumnValue<string>(ColumnNameReferencedFile);
                  list.Add(instance);
               }
            }
         }

         return list.ToArray();
      }

      public void SetInstanceForwarded(string sopInstanceUID, DateTime forwardDate, DateTime? expireDate)
      {
         using (DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeInsertCommand(command, sopInstanceUID, forwardDate, expireDate);
            DatabaseProvider.ExecuteNonQuery(command);
         }
      }

      public ForwardInstance[] GetCleanList()
      {
         List<ForwardInstance> list = new List<ForwardInstance>();

         using (DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeGetCleanListCommand(command);
            using (IDataReader reader = DatabaseProvider.ExecuteReader(command))
            {
               while (reader.Read())
               {
                  ForwardInstance instance = new ForwardInstance();

                  instance.SOPInstanceUID = reader.GetColumnValue<string>(ColumnNameSOPInstanceUID);
                  instance.ReferencedFile = reader.GetColumnValue<string>(ColumnNameReferencedFile);
                  list.Add(instance);
               }
            }
         }

         return list.ToArray();
      }

      public long GetForwardCount()
      {
         using (DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            object value = null;

            InitializeGetForwardCountCommand(command);
            try
            {
               value = DatabaseProvider.ExecuteScalar(command);
            }
            catch { }
            if (value != null)
               return Convert.ToInt64(value);
         }
         return 0;
      }

      public long GetCleanCount()
      {
         using (DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            object value = null;

            InitializeGetCleanCountCommand(command);

            try
            {
               value = DatabaseProvider.ExecuteScalar(command);
            }
            catch { }
            if (value != null)
               return Convert.ToInt64(value);
         }
         return 0;
      }

      public void Reset(DateRange range)
      {
         using (DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeResetCommand(command, range);
            DatabaseProvider.ExecuteNonQuery(command);
         }
      }

      public long GetResetCount(DateRange range)
      {
         using (DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            object value;

            InitializeGetResetCountCommand(command, range);
            value = DatabaseProvider.ExecuteScalar(command);
            if (value != null)
               return Convert.ToInt64(value);
         }
         return 0;
      }

      public bool IsForwarded ( string sopInstanceUID ) 
      {
         using ( DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand ( ) )
         {
            object value ;
            
            InitializeIsForwardedCommand ( command, sopInstanceUID ) ;
            
            value = DatabaseProvider.ExecuteScalar ( command )  ;
            
            if ( value != null && value != DBNull.Value )
            {
               int count ;
               bool exists ;
               
               if ( int.TryParse ( value.ToString ( ), out count ) )
               {
                  return count > 0 ;
               }
               else if ( bool.TryParse ( value.ToString ( ), out exists ) )
               {
                  return exists ;
               }
               else
               {
                  return !string.IsNullOrEmpty ( value.ToString ( ) ) ;
               }
            }
         }
         
         return false ;
      }

      #endregion
   }
}
