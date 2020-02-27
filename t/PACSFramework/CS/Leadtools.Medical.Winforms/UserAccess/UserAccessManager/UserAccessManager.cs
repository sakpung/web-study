// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Data ;
using System.Collections.Generic;
using System.Security ;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.UserManagementDataAccessLayer ;
using Leadtools.Medical.UserManagementDataAccessLayer.Configuration ;
using Leadtools.DicomDemos;

namespace Leadtools.Medical.Winforms
{
   public class UserAccessManager
   {
      #region Public
         
         #region Methods
         
            public static UsersSource GetUsers () 
            {
               IUserManagementDataAccessAgent agent ;
               IEnumerable <User> users ;
               UsersSource usersDataSet ;
               
               System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();
               
               agent        = DataAccessFactory.GetInstance ( new UserManagementDataAccessConfigurationView (configuration, PacsProduct.ProductName, PacsProduct.ServiceName) ).CreateDataAccessAgent <IUserManagementDataAccessAgent> ( ) ;
               users        = agent.GetUsers ( ) ;
               usersDataSet = new UsersSource ( ) ;
               
               
               foreach ( User userData in users ) 
               {
                  UsersSource.UsersRow user ;
                  
                  
                  user = usersDataSet.Users.NewUsersRow ( ) ;
                  
                  user.UserName = userData.UserName ;
                  user.IsAdmin  = userData.IsAdmin ;
                  
                  usersDataSet.Users.AddUsersRow ( user ) ;
               }
               
               usersDataSet.AcceptChanges ( ) ;
               
               return usersDataSet ;
            }
            
            public static void SetAuthenticatedUser ( User authenticatedUser )
            {
               AuthenticatedUser = authenticatedUser ;
            }
            public static bool AuthenticateUser 
            ( 
               string userName, 
               SecureString password 
            )
            {
               IUserManagementDataAccessAgent agent ;
               
               
               agent = GetDataAccessAgent ( ) ;
               
               if ( agent.IsUserValid ( userName, password ) )
               {
                  AuthenticatedUser = new User ( userName, agent.IsAdmin ( userName ) ) ;
                  
                  return true ;
               }
               else
               {
                  AuthenticatedUser = null ;
                  
                  return false ;
               }
            }
            
            public static void UpdateUsers ( UsersSource users ) 
            {
               IUserManagementDataAccessAgent agent ;
               UsersSource usersDataSet ;
               
               
               if ( null == AuthenticatedUser )
               {
                  throw new SecurityException ( "User is not authenticated." ) ;
               }
               
               if ( !AuthenticatedUser.IsAdmin ) 
               {
                  throw new SecurityException ( "Authenticated User doesn't have permissions." ) ;
               }
               
               agent        = GetDataAccessAgent ( ) ;
               usersDataSet = ( UsersSource ) users.GetChanges ( ) ;
               
               if ( null == usersDataSet ) 
               {
                  return ;
               }
               
               foreach ( UsersSource.UsersRow user in usersDataSet.Users )
               {
                  if ( user.RowState == DataRowState.Added )
                  {
                     if ( user.IsNewPasswordNull ( ) )
                     {
                        throw new InvalidOperationException ( "New user has no password." ) ;
                     }
                     
                     agent.AddUser ( user.UserName, user.NewPassword, user.IsAdmin ) ;
                  }
                  else if ( user.RowState == DataRowState.Deleted )
                  {
                     agent.RemoveUser ( user.Field <string> ( usersDataSet.Users.UserNameColumn, DataRowVersion.Original ) ) ;
                  }
                  else if ( user.RowState == DataRowState.Modified )
                  {
                     agent.SetAdminUser ( user.UserName, user.IsAdmin ) ;
                     
                     if ( !user.IsNewPasswordNull ( ) )
                     {
                        agent.SetUserPassword ( user.UserName, user.NewPassword ) ;
                     }
                  }
               }
               
               users.AcceptChanges ( ) ;
            }
            
            public static SecureString GetSecureString ( string password )
            {
               char [ ] passwordChars ;
               SecureString secure ;
               
               
               passwordChars = password.ToCharArray ( ) ;
               secure        = new SecureString ( ) ;
               
               foreach ( char c in passwordChars )
               {
                  secure.AppendChar ( c ) ;
               }
               
               secure.MakeReadOnly ( ) ;
               
               return secure ;
            }
            
         #endregion
         
         #region Properties
         
            public static User AuthenticatedUser
            {
               get
               {
                  return _authenticatedUser ;
               }
               
               private set
               {
                  _authenticatedUser = value ;
               }
            }
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods

            private static IUserManagementDataAccessAgent GetDataAccessAgent ( )
            {
               IUserManagementDataAccessAgent datasetDataAccessAgent;


               if (!DataAccessServices.IsDataAccessServiceRegistered<IUserManagementDataAccessAgent>())
               {
               System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();
                  datasetDataAccessAgent = DataAccessFactory.GetInstance(new UserManagementDataAccessConfigurationView(configuration, PacsProduct.ProductName, PacsProduct.ServiceName) ).CreateDataAccessAgent<IUserManagementDataAccessAgent>();

                  DataAccessServices.RegisterDataAccessService<IUserManagementDataAccessAgent>(datasetDataAccessAgent);
               }
               else
               {
                  datasetDataAccessAgent = DataAccessServices.GetDataAccessService<IUserManagementDataAccessAgent>();
               }

               return datasetDataAccessAgent;
            }            
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
         
            private static User _authenticatedUser = null ;
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}
