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
   public interface IUserManagementDataAccessAgent2 : IUserManagementDataAccessAgent
   {
      bool IsUserPasswordExpired(string username);
      bool AddUser(string userName, SecureString password, DateTime? expireDate);
      bool SetUserPassword(string userName, SecureString newPassword, DateTime? expireDate, int historyCount);
      bool AddToPasswordHistory(string userName, SecureString password, int historyCount);
      bool IsPreviousPassword(string userName, SecureString password);
   }
}
