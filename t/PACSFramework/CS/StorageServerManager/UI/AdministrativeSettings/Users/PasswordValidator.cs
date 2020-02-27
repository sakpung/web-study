// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Demos.StorageServer.DataTypes.Options;
using System.Text.RegularExpressions;

namespace Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
{
   public static class PasswordValidator
   {
      public static bool Validate(string password, string confirmation, PasswordOptions options, out string validationMessage)
      {
         validationMessage = string.Empty;

         if(password.Length==0)
         {
            validationMessage = "Password cannot be empty.";
            return false;
         }

         if (password != confirmation)
         {
            validationMessage = "Password and confirm password do not match.";
            return false;
         }

         if (options.MinimumLength != 0)
         {
            if (password.Length < options.MinimumLength)
            {
               validationMessage = string.Format("Password must be at least {0} long.", options.MinimumLength);
               return false;
            }
         }

         if ((options.Complexity & Complexity.Lowercase) == Complexity.Lowercase)
         {
            if (!Regex.IsMatch(password, "[a-z]"))
            {
               validationMessage = string.Format("Password must must have at least one lower case letter.", options.MinimumLength);
               return false;
            }
         }

         if ((options.Complexity & Complexity.Uppercase) == Complexity.Uppercase)
         {
            if (!Regex.IsMatch(password, "[A-Z]"))
            {
               validationMessage = string.Format("Password must must have at least one upper case letter.", options.MinimumLength);
               return false;
            }
         }

         if ((options.Complexity & Complexity.Numbers) == Complexity.Numbers)
         {
            if (!Regex.IsMatch(password, "[0-9]"))
            {
               validationMessage = string.Format("Password must must have at least one number.", options.MinimumLength);
               return false;
            }
         }

         if ((options.Complexity & Complexity.Symbol) == Complexity.Symbol)
         {
            if (!Regex.IsMatch(password, "[@#$%^&+=]"))
            {
               validationMessage = string.Format("Password must must have at least one symbol.", options.MinimumLength);
               return false;
            }
         }

         return true;
      }
   }
}
