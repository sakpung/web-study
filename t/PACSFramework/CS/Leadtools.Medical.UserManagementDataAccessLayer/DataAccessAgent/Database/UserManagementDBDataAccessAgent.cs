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
using Leadtools.Medical.UserManagementDataAccessLayer.DataAccessAgent;
using System.Diagnostics;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.UserManagementDataAccessLayer.Configuration;
using System.DirectoryServices.AccountManagement;

namespace Leadtools.Medical.UserManagementDataAccessLayer
{
   public abstract class UserManagementDBDataAccessAgent : IUserManagementDataAccessAgent
   {
      #region Public Methods
      public UserManagementDBDataAccessAgent(string connectionString) 
      {
         ConnectionString = connectionString ;
      }     
      
      //all interface methods implementations that receive a userName should call this function
      public virtual string FromInputUserName(string userName)
      {
         return UserNameResolver.ToDb(userName, string.Empty).Item1;
      }
               
      public virtual User [ ] GetUsers ( ) 
      {
         List <User>   users ;
         
         using (var selectCommand = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            users = new List<User>();

            InitializeGetUsersCommand(selectCommand);

            using (var reader = DatabaseProvider.ExecuteReader(selectCommand))
            {
               User user;


               while (reader.Read())
               {
                  user = new User(reader.GetColumnValue<string>("UserName"));
                  user.IsAdmin = reader.GetColumnValue<bool>("IsAdmin");
                  var UserType = reader.GetColumnValueOrDefault<string>("UserType");
                  var extendedName = reader.GetColumnValueOrDefault<string>("ExtendedName");
                  var resolvedName = UserNameResolver.FromDb(user.UserName, extendedName, user.UserType);
                  user.UserName = resolvedName.Item1;
                  users.Add(user);
               }
            }

            return users.ToArray();
         }
      }

      public virtual bool IsUserValid ( string userName, SecureString password ) 
      {
         var typ = IntGetuserType(userName);

         if (IsTypeValidateOnDomain(typ))
         {
            return IsDomainUserValid(userName, password);
         }
         else if (IsTypeValidateOnExternalIdP(typ))
         {
            return true;
         }
         else
         {
            userName = FromInputUserName(userName);

            using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
            {
               InitializeIsUserValidCommand(command, userName, GetHashedPassword(password));

               using (var reader = DatabaseProvider.ExecuteReader(command))
               {
                  if(!reader.Read())
                  {
                     return false;
                  }

                  var userType = reader.GetColumnValueOrDefault<string>("UserType");
                  if (userType == UserType.Temp)
                  {
                     var expires = reader.GetColumnValue<DateTime>("Expires");
                     if(expires<DateTime.UtcNow)
                     {
                        return false;
                     }
                  }

                  return true;
               }               
            }
         }
      }
      private static string[] ParseDomainLogin(string identity)
      {
         //Check whether each part of the domain is not longer than 63 characters, and allow internationalized domain names using the punycode notation:
         //\b((?=[a-z0-9-]{1,63}\.)(xn--)?[a-z0-9]+(-[a-z0-9]+)*\.)+[a-z]{2,63}\b

         return identity.Split('\\');
      }

      private static string ConvertToUnsecureString(SecureString securePassword)
      {
          if (securePassword == null)
              throw new ArgumentNullException("securePassword");

          IntPtr unmanagedString = IntPtr.Zero;
          try
          {
              unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
              return Marshal.PtrToStringUni(unmanagedString);
          }
          finally
          {
              Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
          }
      }
      public bool IsDomainUserValid(string userName, SecureString password)
      {
         try
         {
            var result = ParseDomainLogin(userName);

            using (PrincipalContext context = new PrincipalContext(ContextType.Domain, result.First()))
            {
               //beware the 'Guest' account -- if the domain-level Guest account is enabled, ValidateCredentials returns true if you give it a non-existing user. 
               //As a result, you may want to call UserPrinciple.FindByIdentity to see if the passed in user ID exists first
               var user = UserPrincipal.FindByIdentity(context, IdentityType.SamAccountName, result.Last());
               if (user != null)
               {
                  //.NET uses the following technologies by default: LDAP+SSL, Kerberos, then RPC. 
                  //Kerberos doesn't actually get used by .NET unless you explicitly tell it using ContextOptions.Negotiate
                  bool isValid = context.ValidateCredentials(result.Last(), ConvertToUnsecureString(password), ContextOptions.Negotiate);

                  return isValid;
               }
            }
         }
         catch{ }

         return false;
      }
   
      public virtual bool AddUser 
      ( 
         string userName, 
         SecureString password, 
         bool isAdmin 
      ) 
      {
         userName = FromInputUserName(userName);

         using (var insertCommand = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeAddUserCommand(insertCommand, userName, GetHashedPassword(password), isAdmin);

            return (DatabaseProvider.ExecuteNonQuery(insertCommand) > 0);
         }
      }      
      
      public string IntGetuserType( string userName ) 
      {
         userName = FromInputUserName(userName);

         try
         {
            object result;

            using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
            {
               InitializeIsValidateOnDomainCommand(command, userName);

               result = DatabaseProvider.ExecuteScalar(command);

               if(null!=result)
               {
                  var typ = UserNameResolver.DecodeType(result.ToString());
                  return typ;
               }
            }
         }
         catch{
         }

         return null;
      }

      public bool IsTypeValidateOnExternalIdP(string typ)
      {
         if (!string.IsNullOrEmpty(typ))
         {
            return (typ == "federatedIdP");
         }

         return false;
      }

      public bool IsTypeValidateOnDomain(string typ)
      {
         if (!string.IsNullOrEmpty(typ))
         {
            return (typ == "activedirectory");
         }

         return false;
      }

      public bool IsValidateOnDomain(string userName)
      {
         var typ = IntGetuserType(userName);

         if (!string.IsNullOrEmpty(typ))
         {
            return (typ == "activedirectory");
         }

         return false;
      }

      public virtual bool IsAdmin ( string userName ) 
      {
         userName = FromInputUserName(userName);

         object    result ;


         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeIsAdminCommand(command, userName);

            result = DatabaseProvider.ExecuteScalar(command);

            return ReturnFromScalarResult(result);
         }
      }
      
      public virtual bool RemoveUser 
      ( 
         string userName 
      ) 
      {
         userName = FromInputUserName(userName);

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeRemoveUserCommand(command, userName);

            return (DatabaseProvider.ExecuteNonQuery(command) > 0);
         }
      }
      
      public virtual bool SetAdminUser 
      ( 
         string userName, 
         bool isAdmin 
      ) 
      {
         userName = FromInputUserName(userName);

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeSetAdminUserCommand(command, userName, isAdmin);

            return (DatabaseProvider.ExecuteNonQuery(command) > 0);
         }
      }
      
      public virtual bool SetUserPassword 
      ( 
         string userName, 
         SecureString newPassword 
      ) 
      {
         userName = FromInputUserName(userName);

         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeSetUserPasswordCommand(command, userName, GetHashedPassword(newPassword));

            return (DatabaseProvider.ExecuteNonQuery(command) > 0);
         }
      }
      
      #endregion
      
      #region Public Properties
      
      public string ConnectionString 
      {
         get
         {
            return _connectionString ;
         }
         
         private set
         {
            _connectionString = value ;
         }
      }
      
      #endregion
      
      #region Protected Abstract Methods
         
         protected abstract Database CreateDatabaseProvider ( ) ;
         protected abstract void InitializeGetUsersCommand        ( DbCommand command ) ;
         protected abstract void InitializeIsUserValidCommand     ( DbCommand command, string userName, string userPassword ) ;
         protected abstract void InitializeAddUserCommand         ( DbCommand command, string userName, string password, bool isAdmin ) ;
         protected abstract void InitializeIsAdminCommand         ( DbCommand command, string userName ) ;
         protected abstract void InitializeIsValidateOnDomainCommand( DbCommand command, string userName ) ;
         protected abstract void InitializeRemoveUserCommand      ( DbCommand command, string userName ) ;
         protected abstract void InitializeSetAdminUserCommand    ( DbCommand command, string userName, bool isAdmin ) ;
         protected abstract void InitializeSetUserPasswordCommand ( DbCommand command, string userName, string newPassword ) ;
         
      #endregion
      
      #region Protected Properties
      
         protected Database DatabaseProvider
         {
            get
            {
               if ( null == _dbProvider ) 
               {
                  _dbProvider = CreateDatabaseProvider ( ) ;
               }
               
               return _dbProvider ;
            }
            
            private set
            {
               _dbProvider = value ;
            }
         }
         
      #endregion
           
      #region Private Methods
      
         protected bool ReturnFromScalarResult ( object result ) 
         {
            if ( result != null && result != DBNull.Value ) 
            {
               bool boolResult ;
               int countValue ;
               
               
               if ( bool.TryParse ( result.ToString ( ), out boolResult ) )
               {
                  return boolResult ;
               }
               else if ( int.TryParse ( result.ToString ( ), out countValue ) )
               {
                  return countValue > 0 ;
               }
               
               return true ;
            }
            else
            {
               return false ;
            }

         }

         protected bool ReturnFromScalarResult(DateTime? result)
         {
            if (result.HasValue)
            {
               return DateTime.Now > result.Value;  
            }
            else
            {
               return true;
            }
         }         

         protected static string GetHashedPassword(SecureString secure)
         {
            if(null==secure)
            {
               return string.Empty;
            }

            SHA1CryptoServiceProvider sha1 ;
            IntPtr bstrString ;
            byte [ ]  securebytes ;
            byte [ ]  byteArray ;
            string hashedValue = "" ;
            
          
            sha1        = new SHA1CryptoServiceProvider ( );
            securebytes = new byte [ secure.Length ] ;
            bstrString  = Marshal.SecureStringToBSTR ( secure ) ;
            
            for ( int i = 0; i < secure.Length; i++ ) 
            {
               securebytes [ i ] = Marshal.ReadByte ( bstrString, i ) ;
            }
            
            Marshal.FreeBSTR ( bstrString ) ;
            
            byteArray = sha1.ComputeHash ( securebytes ) ;
            
            Array.Clear ( securebytes, 0, securebytes.Length ) ;
            
            securebytes = null ;
            
            foreach (byte b in byteArray)
            {
                hashedValue += b.ToString("x2");
            }
          
            return hashedValue ;
         }      
      
      #endregion
      
      #region Data Members
      
         private Database _dbProvider ;
         private string   _connectionString ;
         
      #endregion
   }
}
