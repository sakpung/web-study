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

namespace DicomDemo.Authentication
{
   public class AuthenticateUserEventArgs : CancelEventArgs
   {
      private string _Username;

      public string Username 
      { 
         get
         {
            return _Username;
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
      }
   }
}
