// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

#define USE_SMART_CARD

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Security;
// using My.SmartCard;

#if (USE_SMART_CARD)
using System.Linq;
using Leadtools.Medical.DataAccessLayer;
using SmartCard;
#endif

namespace Leadtools.Medical.UserManagementDataAccessLayer.DataAccessAgent.Database
{
   public abstract class UserManagmentDBDataAccessAgent3 : UserManagmentDBDataAccessAgent2, IUserManagementDataAccessAgent3
   {
      #region Protected Abstract Methods

      protected abstract void InitializeAddUserCardReaderCommand(DbCommand command, string userName, string friendlyName, string password, DateTime? expireDate, bool useCardReader);

      #endregion


      public UserManagmentDBDataAccessAgent3(string connectionString) : base(connectionString)
      {
      }


      #region IUserManagementDataAccessAgent3 Members

      public bool AddUser(string userName, string friendlyName, SecureString password, DateTime? expireDate, bool useCardReader)
      {
         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeAddUserCardReaderCommand(command, userName, friendlyName, GetHashedPassword(password), expireDate, useCardReader);
            return (DatabaseProvider.ExecuteNonQuery(command) > 0);
         }
      }

      public bool AddUserCardReader(string userName, string friendlyName)
      {
         using (var command = DatabaseProvider.DbProviderFactory.CreateCommand())
         {
            InitializeAddUserCardReaderCommand(command, userName, friendlyName, string.Empty, null, true);
            return (DatabaseProvider.ExecuteNonQuery(command) > 0);
         }
      }

      public User[] GetUsers(bool useCardReader)
      {
         User[] users = GetUsers();
         List<User> retUsers = new List<User>();

         foreach (User user in users)
         {
            if (user.UseCardReader == useCardReader)
            {
               retUsers.Add(user);
            }
         }

         return retUsers.ToArray();
      }
#if (USE_SMART_CARD)
      private ILTSmartCardHighLevelAPI _smartCardReader;
      private ILTSmartCardHighLevelAPI SmartCardReader
      {
         get
         {
            if (_smartCardReader == null)
            {
               _smartCardReader = DataAccessServices.GetDataAccessService<ILTSmartCardHighLevelAPI>();
            }
            if (_smartCardReader == null)
            {
               _smartCardReader = new LTSmartCardHighLevelAPI();
               // _smartCardReader =  new My.SmartCard.MySmartCard();
               DataAccessServices.RegisterDataAccessService<ILTSmartCardHighLevelAPI>(_smartCardReader);
            }
            return _smartCardReader;
         }
      }
#endif 

      public string[] GetCardReaderNames()
      {
         List<string> cardReaderNames = new List<string>();
#if (USE_SMART_CARD)
         int count = SmartCardReader.GetReadersCount();

         for (int i = 0; i < count; i++)
         {
            string readerAndCardName = SmartCardReader.GetReaderAndCardName(i);

            cardReaderNames.Add(readerAndCardName);
         }
#endif
         return cardReaderNames.ToArray();
      }

#if (USE_SMART_CARD)
      private bool AuthenticateCardUserPin(int cardReaderIndex, string pin, out string ediNumber, out int pinCounter)
      {
         ediNumber = string.Empty;
         pinCounter = -1;
         IDoDPersonInstance result = _smartCardReader.ReadCardInfo(cardReaderIndex, pin);
         if (result == null)
         {
            pinCounter = _smartCardReader.GetCardPinCounter(cardReaderIndex);
         }
         else
         {
            ediNumber = result.GetTag((int)DoDPersonInstance.Tags.DodEdiPersonIdentifier);
         }

         bool isValid = result != null;
         return isValid;
      }
#endif 

      public int AuthenticateCardUser(int cardReaderIndex, string pin, bool checkPinOnly, out string ediNumber, out int pinCounter)
      {
         ediNumber = string.Empty;
         pinCounter = -1;
#if (USE_SMART_CARD)
         bool isPinValid = AuthenticateCardUserPin(cardReaderIndex, pin, out ediNumber, out pinCounter);
         if (!isPinValid)
         {
            return (int)AuthenticateCardUserResult.InvalidPin;
         }

         if (checkPinOnly)
         {
            return (int)AuthenticateCardUserResult.Success;
         }

         string selectedEdiNumber = ediNumber;
         User[] allCardUsers = GetUsers(true);
         bool isUserInDatabase = allCardUsers.Any(user => user.UserName == selectedEdiNumber);
         if (!isUserInDatabase)
         {
            return (int)AuthenticateCardUserResult.InvalidUserName;
         }
#endif
         return (int)AuthenticateCardUserResult.Success;
      }

      public bool IsUserCardReaderReady(int cardReaderIndex)
      {
#if (USE_SMART_CARD)
         return SmartCardReader.IsCardReady(cardReaderIndex);
#else
         return false;
#endif
      }


      #endregion
   }

   public enum AuthenticateCardUserResult
   {
      Success = 0,
      InvalidUserName = 1,
      InvalidPin = 2,
      UnknownError = 3,
   }
}
