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
   public interface IUserManagementDataAccessAgent3 : IUserManagementDataAccessAgent2
   {
      bool AddUser(string userName, string friendlyName, SecureString password, DateTime? expireDate, bool useCardReader);
      bool AddUserCardReader(string userName, string friendlyName);
      User[] GetUsers(bool useCardReader);
      string[] GetCardReaderNames();

      bool IsUserCardReaderReady(int cardReaderIndex);

      int AuthenticateCardUser(int cardReaderIndex, string pin, bool checkPinOnly, out string ediNumber, out int pinCounter);
   }
}
