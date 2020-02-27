// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.ComponentModel;
using Leadtools.Medical.Winforms;

namespace Leadtools.Demos.StorageServer.UI.Authentication
{
   public class AuthenticateUserEventArgs : CancelEventArgs
   {
      private LoginType _LoginType;

      public LoginType LoginType
      {
         get
         {
            return _LoginType;
         }
      }

      private bool _CardReaderValidatePinOnly = false;
      public bool CardReaderValidatePinOnly
      {
         get
         {
            return _CardReaderValidatePinOnly;
         }
      }


      private string _Username;

      public string Username 
      { 
         get
         {
            return _Username;
         }
      }

      private string _EdiNumber;
      public string EdiNumber 
      { 
         get
         {
            return _EdiNumber;
         }
         set
         {
            _EdiNumber = value;
         }
      }

      private SecureString _Password;

      public SecureString Password
      {
         get
         {
            return _Password;
         }
      }

      private string _Pin;
      public string Pin
      {
         get
         {
            return _Pin;
         }
      }

      private int _CardReaderIndex;
      public int CardReaderIndex
      {
         get
         {
            return _CardReaderIndex;
         }
      }

      private bool _InvalidCredentials;

      public bool InvalidCredentials
      {
         get { return _InvalidCredentials; }
         set { _InvalidCredentials = value; }
      }

      public AuthenticateUserEventArgs(string username,SecureString password)
      {
         _Username = username;
         _Password = password;
         _LoginType = LoginType.UsernamePassword;
      }

      public AuthenticateUserEventArgs(int cardReaderIndex, string pin, bool cardReaderValidatePinOnly)
      {
         _CardReaderIndex = cardReaderIndex;
         _Pin = pin;
         _LoginType = LoginType.SmartcardPin;
         _CardReaderValidatePinOnly = cardReaderValidatePinOnly;
      }
   }
}
