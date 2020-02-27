// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Data.Common;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom;
#if DNXCORE50
using Leadtools.Data;
using Leadtools.Practices.EnterpriseLibrary.Data;
#else
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
#endif


namespace Leadtools.Medical.AeManagement.DataAccessLayer
{
   public abstract class AeManagementDBDataAccessAgent 
#if (LEADTOOLS_V20_OR_LATER)
                                                        : IAeManagementDataAccessAgent2
#endif
   {
      #region Public Methods
      public AeManagementDBDataAccessAgent(string connectionString)
      {
         ConnectionString = connectionString;
      }      

      //public virtual bool IsUserValid(string userName, SecureString password)
      //{
      //   DbCommand command;
      //   object result;


      //   command = DatabaseProvider.DbProviderFactory.CreateCommand();

      //   InitializeIsAeValidCommand(command, userName, GetHashedPassword(password));

      //   result = DatabaseProvider.ExecuteScalar(command);

      //   return ReturnFromScalarResult(result);
      //}

      //public virtual bool AddUser
      //(
      //   string userName,
      //   SecureString password,
      //   bool isAdmin
      //)
      //{
      //   DbCommand insertCommand;


      //   insertCommand = DatabaseProvider.DbProviderFactory.CreateCommand();

      //   InitializeAddAeCommand(insertCommand, userName, GetHashedPassword(password), isAdmin);

      //   return (DatabaseProvider.ExecuteNonQuery(insertCommand) > 0);
      //}

      public virtual bool RemoveUser
      (
         string userName
      )
      {
         DbCommand command;


         command = DatabaseProvider.DbProviderFactory.CreateCommand();

         InitializeRemoveAeCommand(command, userName);

         return (DatabaseProvider.ExecuteNonQuery(command) > 0);
      }

      //public virtual bool SetAdminUser
      //(
      //   string userName,
      //   bool isAdmin
      //)
      //{
      //   DbCommand command;


      //   command = DatabaseProvider.DbProviderFactory.CreateCommand();

      //   InitializeSetAeFlagsCommand(command, userName, isAdmin);

      //   return (DatabaseProvider.ExecuteNonQuery(command) > 0);
      //}

      //public virtual bool SetUserPassword
      //(
      //   string userName,
      //   SecureString newPassword
      //)
      //{
      //   DbCommand command;


      //   command = DatabaseProvider.DbProviderFactory.CreateCommand();

      //   InitializeSetUserPasswordCommand(command, userName, GetHashedPassword(newPassword));

      //   return (DatabaseProvider.ExecuteNonQuery(command) > 0);
      //}

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
      protected abstract void InitializeGetClientInformationCommand(DbCommand command,string aetitle);
      protected abstract void InitializeIsAeValidCommand(DbCommand command, string aetitle);
      protected abstract void InitializeAddAeCommand(DbCommand command, AeInfoExtended AeInfo);
      protected abstract void InitializeAddAeRelationCommand(DbCommand command, string aetitle, string aerelation, int relation);
      protected abstract void InitializeAeHasFlagCommand(DbCommand command, string aetitle, int flag);
      protected abstract void InitializeRemoveAeCommand(DbCommand command, string aetitle);
      protected abstract void InitializeRemoveAeRelationCommand(DbCommand command, string aetitle, string aerelation, int releation);
      protected abstract void InitializeSetAeFlagsCommand(DbCommand command, string aetitle, int flags);
      protected abstract void InitializeGetRelatedClientInformationCommand(DbCommand command, string aetitle);
      protected abstract void InitializeGetRelatedClientInformationCommand(DbCommand command, string aetitle, int relation);
      protected abstract void InitializeRemoveCommand(DbCommand command, string aetitle);
      protected abstract void InitializeUpdateCommand(DbCommand command, AeInfoExtended ae);

#if (LEADTOOLS_V20_OR_LATER)
      protected abstract void InitializeGetClientCountCommand(DbCommand command);
      protected abstract void InitializeGetAeTitlesCommand(DbCommand dbCommand, AeInfoExtended searchParams, QueryPageInfo queryPageInfo);
#endif


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

      private Database _dbProvider;
      private string _connectionString;

      #endregion

      private AeInfoExtended GetClientInformation(IDataReader reader)
      {
         AeInfoExtended ci = new AeInfoExtended();

         int columnCount = reader.FieldCount;

         if (!reader.IsDBNull(0))
            ci.Address = reader.GetString(0);

         ci.AETitle = reader.GetString(1);

         if (!reader.IsDBNull(2))
            ci.Port = reader.GetInt32(2);
         if (!reader.IsDBNull(3))
            ci.SecurePort = reader.GetInt32(3);

         if (!reader.IsDBNull(4))
            ci.VerifyAddress = reader.GetBoolean(4);

         if (!reader.IsDBNull(5))
            ci.Mask = reader.GetString(5);

         if (!reader.IsDBNull(6))
            ci.VerifyMask = reader.GetBoolean(6);

         //if (7 < columnCount)
         //{
         //   if (!reader.IsDBNull(7))
         //      ci.UseSecurePort = reader.GetBoolean(7);
         //}

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
         if (8 < columnCount)
         {
            if (!reader.IsDBNull(8))
               ci.FriendlyName = reader.GetString(8);
         }
#endif

#if (LEADTOOLS_V20_OR_LATER)
         if (9 < columnCount)
         {
            if (!reader.IsDBNull(9))
            {
               int enumValue = reader.GetInt32(9);
               ClientPortUsageType portUsage = (ClientPortUsageType)enumValue;
               ci.ClientPortUsage = portUsage;
            }
         }

         if (10 < columnCount)
         {
            if (!reader.IsDBNull(10))
            {
               DateTime dateTimeValue = reader.GetDateTime(10);
               ci.LastAccessDate = dateTimeValue;
            }
            else
            {
               ci.LastAccessDate = DateTime.MinValue;
            }
         }
#endif

         //if (!reader.IsDBNull(4))
         //   ci.Flags = reader.GetInt64(4);
         return ci;
      }

      #region IAeManagementDataAccessAgent Members

      public AeInfoExtended[] GetAeTitles()
      {
         DbCommand selectCommand;
         IDataReader reader;
         List<AeInfoExtended> aetitles;


         selectCommand = DatabaseProvider.DbProviderFactory.CreateCommand();
         aetitles = new List<AeInfoExtended>();

         InitializeGetClientInformationCommand(selectCommand, string.Empty);

         using (reader = DatabaseProvider.ExecuteReader(selectCommand))
         {            
            while (reader.Read())
            {               
               aetitles.Add(GetClientInformation(reader));
            }
         }

         return aetitles.ToArray();
      }

      public AeInfoExtended[] GetRelatedAeTitles(string aetitle)
      {
         throw new NotImplementedException();
      }

      public AeInfoExtended[] GetRelatedAeTitles(string aetitle, int relation)
      {
         DbCommand selectCommand;
         IDataReader reader;
         List<AeInfoExtended> aes;

         selectCommand = DatabaseProvider.DbProviderFactory.CreateCommand();
         aes = new List<AeInfoExtended>();
         InitializeGetRelatedClientInformationCommand(selectCommand,aetitle, relation);

         using (reader = DatabaseProvider.ExecuteReader(selectCommand))
         {            
            while (reader.Read())
            {
               AeInfoExtended info = GetAeTitle(reader.GetColumnValue<string>("RelatedAETitle"));

               if(info!=null)
                  aes.Add(info);
            }
         }
         return aes.ToArray();
      }

      public AeInfoExtended GetAeTitle(string aetitle)
      {
         DbCommand selectCommand;
         IDataReader reader;         

         selectCommand = DatabaseProvider.DbProviderFactory.CreateCommand();         
         InitializeGetClientInformationCommand(selectCommand, aetitle);
         using (reader = DatabaseProvider.ExecuteReader(selectCommand))
         {
            while (reader.Read())
            {
               return GetClientInformation(reader);
            }
         }
         return null;
      }

      public bool Add(AeInfoExtended ae)
      {
         DbCommand insertCommand;

         insertCommand = DatabaseProvider.DbProviderFactory.CreateCommand();
         InitializeAddAeCommand(insertCommand, ae);
         return (DatabaseProvider.ExecuteNonQuery(insertCommand) > 0);
      }

      public bool AddReleation(string aetitle, string aerelation, int relation)
      {
         DbCommand insertCommand;
         
         insertCommand = DatabaseProvider.DbProviderFactory.CreateCommand();
         InitializeAddAeRelationCommand(insertCommand, aetitle, aerelation, relation);
         return (DatabaseProvider.ExecuteNonQuery(insertCommand) > 0);
      }

      public bool RemoveRelation(string aetitle, string aerelation, int relation)
      {
         DbCommand command;

         command = DatabaseProvider.DbProviderFactory.CreateCommand();
         InitializeRemoveAeRelationCommand(command, aetitle, aerelation, relation);
         return (DatabaseProvider.ExecuteNonQuery(command) > 0);
      }

      public void Remove(string aetitle)
      {
         DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand();
         InitializeRemoveCommand(command, aetitle);
         int ret = DatabaseProvider.ExecuteNonQuery(command);
      }

      public void Update(string aetitle, AeInfoExtended ae)
      {
         DbCommand command;

         command = DatabaseProvider.DbProviderFactory.CreateCommand();
         InitializeUpdateCommand(command, ae);
         DatabaseProvider.ExecuteNonQuery(command);
      }

#if (LEADTOOLS_V20_OR_LATER)
      public int GetAeTitlesCount()
      {
         DbCommand command = DatabaseProvider.DbProviderFactory.CreateCommand();

         InitializeGetClientCountCommand(command);

         object value = DatabaseProvider.ExecuteScalar(command);

         if (value != null && value != DBNull.Value)
         {
            int count = 0;

            if (int.TryParse(value.ToString(), out count))
            {
               return count;
            }
         }

         return 0;
      }

      public AeInfoExtended[] GetAeTitles(AeInfoExtended searchParams, QueryPageInfo queryPageInfo)
      {
         DbCommand dbCommand;
         IDataReader reader;
         List<AeInfoExtended> aetitles;


         dbCommand = DatabaseProvider.DbProviderFactory.CreateCommand();
         aetitles = new List<AeInfoExtended>();

         InitializeGetAeTitlesCommand(dbCommand, searchParams, queryPageInfo);

         using (reader = DatabaseProvider.ExecuteReader(dbCommand))
         {            
            while (reader.Read())
            {               
               aetitles.Add(GetClientInformation(reader));
            }
         }

         return aetitles.ToArray();
      }
#endif // #if (LEADTOOLS_V20_OR_LATER)
      #endregion
   }
}
