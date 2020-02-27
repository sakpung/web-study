// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Security;
using Leadtools.Medical.UserManagementDataAccessLayer;

namespace Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
{
   public class PasswordRequestEventArgs : CancelEventArgs
   {
      public SecureString Password { get; set; }
      public DateTime? Expires { get; set; }

      public PasswordRequestEventArgs()
      {
         Expires = null;
      }
   }

   public class ValidatePasswordEventArgs : EventArgs
   {
      public bool Valid { get; set; }
      public string Password { get; set; }
      public string ConfirmPassword { get; set; }
   }

   public class EditUserPermissionsEventArgs : EventArgs
   {
      private string _Username;

      public string Username 
      {
         get
         {
            return _Username;
         }
      }

      private List<string> _Permissions = new List<string>();

      public List<string> Permissions
      {
         get { return _Permissions; }         
      }


      public EditUserPermissionsEventArgs(string username)
      {
         _Username = username;
      }
   }   
}
