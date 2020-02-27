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
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.Medical.Forward.DataAccessLayer
{
   public class ForwardSqlDataAccessAgent : ForwardDBDataAccessAgent
   {
      #region Public Methods
      
      public ForwardSqlDataAccessAgent ( string connectionString ) 
      : base ( connectionString ) 
      {
         
      }

      #endregion
      
      #region Protected Methods
      
      protected override Microsoft.Practices.EnterpriseLibrary.Data.Database CreateDatabaseProvider ( )
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
      
      protected override void InitializeGetForwardListCommand(DbCommand command)
      {
         command.CommandText = string.Format(@"SELECT {0}.SOPInstanceUID, {1}
                                 FROM {0} Left Outer Join Forward ON
                                 Forward.SOPInstanceUID = {0}.SOPInstanceUID
                                 WHERE Forward.ForwardDate Is NULL ", InstanceTableName, ColumnNameReferencedFile);
      }

      protected override void InitializeInsertCommand(DbCommand command, string sopInstanceUID, DateTime forwardDate, DateTime? expireDate)
      {
         command.CommandText = "INSERT INTO FORWARD (SOPInstanceUID, ForwardDate";
         if (!expireDate.HasValue)
         {
            DbParameter p = command.CreateParameter();

            p.ParameterName = "@forwardDate";
            p.Value = forwardDate;
            command.CommandText += ") VALUES ('" + sopInstanceUID + "', @forwardDate)";
            command.Parameters.Add(p);
         }
         else
         {
            DbParameter p = command.CreateParameter();

            p.ParameterName = "@forwardDate";
            p.Value = forwardDate;
            command.CommandText += ",ExpireDate) VALUES ('" + sopInstanceUID + "', @forwardDate, @expireDate)";
            command.Parameters.Add(p);

            p = command.CreateParameter();
            p.ParameterName = "@expireDate";
            p.Value = expireDate.Value;
            command.Parameters.Add(p);
         }
      }

      protected override void InitializeGetCleanListCommand(DbCommand command)
      {
         command.CommandText = string.Format(@"SELECT {0}.SOPInstanceUID, {1}
                                 FROM {0}
                                 JOIN Forward ON {0}.SOPInstanceUID = Forward.SOPInstanceUID
                                 WHERE ExpireDate IS NULL OR DATEDIFF(d, GETDATE(), Forward.ExpireDate) <= 0", InstanceTableName, ColumnNameReferencedFile);
      }

      protected override void InitializeGetForwardCountCommand(DbCommand command)
      {
         command.CommandText = string.Format(@"SELECT Count({0}.SOPInstanceUID) AS Count
                                 FROM {0} Left Outer Join Forward ON
                                 Forward.SOPInstanceUID = {0}.SOPInstanceUID
                                 WHERE Forward.ForwardDate Is NULL ", InstanceTableName);
      }

      protected override void InitializeGetCleanCountCommand(DbCommand command)
      {
         command.CommandText = string.Format(@"SELECT Count({0}.SOPInstanceUID) AS Count
                                 FROM {0}
                                 JOIN Forward ON {0}.SOPInstanceUID = Forward.SOPInstanceUID
                                 WHERE ExpireDate IS NULL OR DATEDIFF(d, GETDATE(), Forward.ExpireDate) <= 0", InstanceTableName);
      }

      protected override void InitializeResetCommand(DbCommand command, DateRange range)
      {
         if (!range.EndDate.HasValue)
         {
            DbParameter p = command.CreateParameter();

            p.ParameterName = "@startdate";
            p.Value = range.StartDate;
            command.CommandText = @"DELETE FROM Forward
                                    WHERE (DATEDIFF(d, @startdate, ForwardDate) = 0)";
            command.Parameters.Add(p);
         }
         else
         {
            DbParameter p = command.CreateParameter();

            p.ParameterName = "@startdate";
            p.Value = range.StartDate.Value;
            command.CommandText = @"DELETE FROM Forward
                                    WHERE ForwardDate BETWEEN @startdate AND @enddate";
            command.Parameters.Add(p);

            p = command.CreateParameter();
            p.ParameterName = "@enddate";
            p.Value = range.EndDate.Value;
            command.Parameters.Add(p);
         }
      }

      protected override void InitializeGetResetCountCommand(DbCommand command, DateRange range)
      {
         if (!range.EndDate.HasValue)
         {
            DbParameter p = command.CreateParameter();

            p.ParameterName = "@startdate";
            p.Value = range.StartDate;
            command.CommandText = @"SELECT COUNT(SOPInstanceUID) FROM Forward
                                    WHERE (DATEDIFF(d, @startdate, ForwardDate) = 0)";
            command.Parameters.Add(p);
         }
         else
         {
            DbParameter p = command.CreateParameter();

            p.ParameterName = "@startdate";
            p.Value = range.StartDate.Value;
            command.CommandText = @"SELECT COUNT(SOPInstanceUID) FROM Forward
                                    WHERE ForwardDate BETWEEN @startdate AND @enddate";
            command.Parameters.Add(p);

            p = command.CreateParameter();
            p.ParameterName = "@enddate";
            p.Value = range.EndDate.Value;
            command.Parameters.Add(p);
         }
      }
      
      protected override  void InitializeIsForwardedCommand(DbCommand command, string sopInstanceUID) 
      {
         DbParameter p = command.CreateParameter ( ) ;
         p.ParameterName = "@instance" ;
         p.Value = sopInstanceUID ;
         
         command.CommandText = "SELECT COUNT (SOPInstanceUID) FROM Forward WHERE SOPInstanceUID = " + p.ParameterName ;
         command.Parameters.Add ( p ) ;
      }
   }
}
