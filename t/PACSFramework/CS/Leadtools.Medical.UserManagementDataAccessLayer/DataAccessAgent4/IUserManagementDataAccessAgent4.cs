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
   public interface IUserManagementDataAccessAgent4 : IUserManagementDataAccessAgent3
   {
      bool AddUser(string userName, string friendlyName, SecureString password, DateTime? expireDate, string userType);
      string GetUserType(string userName);

      bool UserExists(string userName);

      User[] GetUsers(Dictionary<string,string> query);
   }
}
