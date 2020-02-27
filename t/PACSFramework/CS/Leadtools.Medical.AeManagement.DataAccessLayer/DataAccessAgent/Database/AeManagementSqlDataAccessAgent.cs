// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Data.Common;
using Leadtools.Medical.DataAccessLayer;
using System.Collections.Generic;
#if DNXCORE50
using Leadtools.Practices.EnterpriseLibrary.Data.Sql;
using Leadtools.Practices.EnterpriseLibrary.Data;
#else
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
#endif


namespace Leadtools.Medical.AeManagement.DataAccessLayer
{
   public class AeManagementSqlDataAccessAgent : AeManagementDBDataAccessAgent
   {
      #region Public Methods
      
      public AeManagementSqlDataAccessAgent ( string connectionString ) 
      : base ( connectionString ) 
      {
         
      }

      #endregion
      
      #region Protected Methods
      
      protected override Database CreateDatabaseProvider ( )
      {
         return new SqlDatabase ( ConnectionString ) ;
      }      
      
      //protected override void InitializeIsAeValidCommand 
      //( 
      //   DbCommand command, 
      //   string userName, 
      //   string password 
      //) 
      //{
      //   command.CommandText = string.Format ( "Select UserName FROM Users Where UserName='{0}' AND Password = '{1}'", 
      //                                         userName, 
      //                                         password ) ;
      //}
      
      //protected override void InitializeAddAeCommand
      //( 
      //   DbCommand command,
      //   string userName, 
      //   string password, 
      //   bool isAdmin
      //) 
      //{
      //   command.CommandText = string.Format ( "INSERT INTO Users ( UserName, Password, IsAdmin ) Values ( '{0}', '{1}', {2} )",
      //                                         userName,
      //                                         password,
      //                                         ( isAdmin == true ) ? 1 : 0 ) ;
      //}
      
      //protected override void InitializeAeHasFlagCommand ( DbCommand command, string userName ) 
      //{
      //   command.CommandText = string.Format ( "Select IsAdmin From Users WHERE UserName = '{0}'", userName ) ;
      //}
      
      //protected override void InitializeRemoveAeCommand  
      //( 
      //   DbCommand command,
      //   string userName 
      //) 
      //{
      //   command.CommandText = string.Format ( "DELETE FROM Users WHERE UserName='{0}'",
      //                                         userName ) ;
      //}
      
      //protected override void InitializeSetAeFlagsCommand 
      //( 
      //   DbCommand command,
      //   string userName, 
      //   bool isAdmin
      //) 
      //{
      //   command.CommandText = string.Format ( "UPDATE Users SET IsAdmin={0} WHERE UserName='{1}'",
      //                                         ( isAdmin ) ? 1 : 0,
      //                                         userName ) ;
      //}
      
      //protected override void InitializeSetUserPasswordCommand 
      //( 
      //   DbCommand command,
      //   string userName, 
      //   string newPassword 
      //)
      //{
      //   command.CommandText = string.Format ( "UPDATE Users SET Password='{0}' WHERE UserName='{1}'",
      //                                         newPassword,
      //                                         userName ) ;
      //}
      
      #endregion

      protected override void InitializeGetClientInformationCommand(DbCommand command,string aetitle)
      {
         command.CommandText = "Select * From AeInfo";
         if (!string.IsNullOrEmpty(aetitle))
            command.CommandText += " WHERE AETitle='" + aetitle + "'";
      }

#if (LEADTOOLS_V20_OR_LATER)
      private string AddAnd(string s)
      {
         if (!string.IsNullOrEmpty(s))
         {
            s += " AND ";
         }
         return s;
      }

      private string GenerateWhereStatement(AeInfoExtended searchParams)
      {
         string whereStatement = string.Empty;
         List<string> conditions = new List<string>();

         if (!string.IsNullOrEmpty(searchParams.AETitle))
         {
            conditions.Add( string.Format("AETitle = '{0}'", searchParams.AETitle));
         }

         if (!string.IsNullOrEmpty(searchParams.FriendlyName))
         {
            conditions.Add( string.Format("FriendlyName = '{0}'", searchParams.AETitle));
         }

         if (!string.IsNullOrEmpty(searchParams.Address))
         {
            conditions.Add(string.Format("Address = '{0}'", searchParams.Address));
         }

         if (searchParams.Port > 0)
         {
            conditions.Add(string.Format("Port = '{0}'", searchParams.Port));
         }

         if (searchParams.SecurePort > 0)
         {
            conditions.Add(string.Format("SecurePort = '{0}'", searchParams.SecurePort));
         }

         const string andString = " AND ";

         foreach(string s in conditions)
         {
            whereStatement += s + andString;
         }

         // remove the last AND if necessary
         if (whereStatement.EndsWith(andString))
         {
            whereStatement = whereStatement.Substring(0, whereStatement.Length - andString.Length);
         }

         if (!string.IsNullOrEmpty(whereStatement))
         {
            whereStatement = " WHERE " + whereStatement;
         }

         return whereStatement;
      }

      protected override void InitializeGetAeTitlesCommand(DbCommand command, AeInfoExtended searchParams, QueryPageInfo queryPageInfo)
      {
         command.CommandText =
               @"SELECT * " +
               @"FROM [AeInfo] " +
               GenerateWhereStatement(searchParams);
         if (queryPageInfo.PagingType != QueryPageInfoEnum.None)
         {
            string paging = 
            command.CommandText += 
               @" ORDER BY [AETitle] " + 
               @" OFFSET @PageSize * (@PageNumber - 1) ROWS " + 
               @" FETCH NEXT @PageSize ROWS ONLY"; 


            DbParameter p0 = command.CreateParameter();
            p0.ParameterName = "@PageNumber";
            p0.Value = queryPageInfo.PageNumber;
            command.Parameters.Add(p0);

            DbParameter p1 = command.CreateParameter();
            p1.ParameterName = "@PageSize";
            p1.Value = queryPageInfo.PageSize;
            command.Parameters.Add(p1);
         }
      }

      protected override void InitializeGetClientCountCommand(DbCommand command)
      {
         command.CommandText = "Select COUNT(*) From AeInfo";
      }
#endif // #if (LEADTOOLS_V20_OR_LATER)

      protected override void InitializeIsAeValidCommand(DbCommand command, string aetitle)
      {
         throw new NotImplementedException();
      }

#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
      private const string AddAeFormatString =
         "INSERT INTO AeInfo ( AETitle, Address, VerifyAddress, Mask, VerifyMask, Port, SecurePort, UseSecurePort, FriendlyName, PortUsage, LastAccessDate) Values ( '{0}', '{1}', {2}, '{3}', {4}, {5}, {6}, {7}, '{8}', '{9}', '{10}')";
#else
      private const string AddAeFormatString =
         "INSERT INTO AeInfo ( AETitle, Address, VerifyAddress, Mask, VerifyMask, Port, SecurePort, UseSecurePort) Values ( '{0}', '{1}', {2}, '{3}', {4}, {5}, {6}, {7})";
#endif

      protected override void InitializeAddAeCommand(DbCommand command, AeInfoExtended clientInformation)
      {
         if (clientInformation != null)
         {
            command.CommandText = string.Format(AddAeFormatString,
               clientInformation.AETitle,
               clientInformation.Address,
               clientInformation.VerifyAddress ? 1 : 0,
               clientInformation.Mask,
               clientInformation.VerifyMask ? 1 : 0,
               clientInformation.Port,
               clientInformation.SecurePort,
               0 // clientInformation.UseSecurePort ? 1 : 0
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
               , clientInformation.FriendlyName
#endif   
               , (int)clientInformation.ClientPortUsage
#if LEADTOOLS_V20_OR_LATER
               , DateTime.Now // clientInformation.LastAccessDate
#endif
               );
         }
      }

      protected override void InitializeAddAeRelationCommand(DbCommand command, string aetitle, string aerelation, int relation)
      {
         command.CommandText = string.Format("INSERT INTO AeRelation ( AETitle, RelatedAETitle, Relation ) Values ( '{0}', '{1}', {2} )",
                                             aetitle,aerelation,relation);
      }

      protected override void InitializeAeHasFlagCommand(DbCommand command, string aetitle, int flag)
      {         
      }

      protected override void InitializeRemoveAeCommand(DbCommand command, string aetitle)
      {
         throw new NotImplementedException();
      }

      protected override void InitializeRemoveAeRelationCommand(DbCommand command, string aetitle, string aerelation, int relation)
      {
         command.CommandText = string.Format("DELETE FROM AeRelation WHERE AETitle='{0}' AND RelatedAETitle = '{1}' AND Relation={2}",
                                             aetitle, aerelation, relation);
      }

      protected override void InitializeSetAeFlagsCommand(DbCommand command, string aetitle, int flags)
      {
         throw new NotImplementedException();
      }

      protected override void InitializeGetRelatedClientInformationCommand(DbCommand command, string aetitle)
      {
         command.CommandText = "Select * From AeRelation";
         if (!string.IsNullOrEmpty(aetitle))
            command.CommandText += " WHERE AETitle='" + aetitle + "'";
      }

      protected override void InitializeGetRelatedClientInformationCommand(DbCommand command, string aetitle, int relation)
      {
         command.CommandText = "Select * From AeRelation";
         if (!string.IsNullOrEmpty(aetitle))
            command.CommandText += " WHERE AETitle='" + aetitle + "' AND " ;
         command.CommandText += "Relation=" + relation.ToString();
      }

#if (LEADTOOLS_V20_OR_LATER)
      private const string UpdateAeFormatString =
   "UPDATE AeInfo SET AETitle='{0}', Address='{1}', VerifyAddress='{2}', Mask='{3}', VerifyMask='{4}', Port='{5}', SecurePort='{6}', UseSecurePort='{7}', FriendlyName='{8}', PortUsage='{9}', LastAccessDate='{10}' WHERE AETitle='{11}'";
#elif (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
      private const string UpdateAeFormatString =
         "UPDATE AeInfo SET AETitle='{0}', Address='{1}', VerifyAddress='{2}', Mask='{3}', VerifyMask='{4}', Port='{5}', SecurePort='{6}', UseSecurePort='{7}', FriendlyName='{8}' WHERE AETitle='{9}'";
#else
      private const string UpdateAeFormatString =
         "UPDATE AeInfo SET AETitle='{0}', Address='{1}', VerifyAddress='{2}', Mask='{3}', VerifyMask='{4}', Port='{5}', SecurePort='{6}', UseSecurePort='{7}' WHERE AETitle='{8}'";
#endif
      protected override void InitializeUpdateCommand(DbCommand command, AeInfoExtended ae)
      {
         command.CommandText = string.Format(UpdateAeFormatString,
               ae.AETitle,
               ae.Address,
               ae.VerifyAddress ? 1 : 0,
               ae.Mask,
               ae.VerifyMask ? 1 : 0,
               ae.Port,
               ae.SecurePort,
               0, // ae.UseSecurePort ? 1 : 0,
#if (LEADTOOLS_V19_OR_LATER_MEDICAL_CLIENT_FRIENDLY_NAME) || (LEADTOOLS_V19_OR_LATER)
               ae.FriendlyName,
#endif
#if (LEADTOOLS_V20_OR_LATER)
               (int)ae.ClientPortUsage,
               DateTime.Now, // ae.LastAccessDate,
#endif
               ae.AETitle
               );
      }

      protected override void InitializeRemoveCommand(DbCommand command, string aetitle)
      {
         command.CommandText = "DELETE FROM AeInfo";
         if (!string.IsNullOrEmpty(aetitle))
            command.CommandText += " WHERE AETitle='" + aetitle + "'";
      }
   }
}
