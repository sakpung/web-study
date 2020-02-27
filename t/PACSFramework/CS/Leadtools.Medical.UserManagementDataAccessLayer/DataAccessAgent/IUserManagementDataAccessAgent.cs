// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;

namespace Leadtools.Medical.UserManagementDataAccessLayer
{
   public interface IUserManagementDataAccessAgent
   {
      User[] GetUsers();

      bool IsUserValid ( string userName, SecureString password ) ;
      bool IsAdmin     ( string userName ) ;
      
      bool AddUser         ( string userName, SecureString password, bool isAdmin ) ;
      bool RemoveUser      ( string userName ) ;
      bool SetAdminUser    ( string userName, bool isAdmin ) ;
      bool SetUserPassword ( string userName, SecureString newPassword ) ;
   }
}
