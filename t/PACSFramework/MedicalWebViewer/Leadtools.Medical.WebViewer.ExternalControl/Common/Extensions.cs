// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;

namespace Leadtools.Medical.WebViewer.ExternalControl
{
   internal static class Extensions
   {
      public static ControllerReturnCode ToControllerReturnCode(this string s)
      {
         ControllerReturnCode ret = ControllerReturnCode.Undefined;
         if (string.Compare(s, GenericActionStatus.Success) == 0)
         {
            ret = ControllerReturnCode.Success;
         }
         else if (string.Compare(s, GenericActionStatus.Ok) == 0)
         {
            ret = ControllerReturnCode.Success;
         }
         else if (string.Compare(s, GenericActionStatus.Failure) == 0)
         {
            ret = ControllerReturnCode.Failure;
         }
         return ret;
      }

      public static string MyTryGetValue(this Dictionary<string, string> d, string fieldName)
      {
         string temp;
         if (d.TryGetValue(fieldName, out temp))
         {
            return temp;
         }
         return string.Empty;
      }

      public static bool IsFlagged(this CreateUserOptions options, CreateUserOptions option)
      {
         // return ((options & option) == (option));
         return ((options & option) != (CreateUserOptions.None));
      }
   }

   internal static class Utilities
   {
      public static void PopulateFromDictionary<T>(T myClass, Dictionary<string, string> myDictionary)
      {
         Type myType = myClass.GetType();

         // Get Properties
         foreach (PropertyInfo pi in typeof(T).GetProperties())
         {
            string value;
            if (myDictionary.TryGetValue(pi.Name, out value))
            {
               pi.SetValue(myClass, value, null);
            }
         }

         // Get Fields
         foreach (FieldInfo pi in myType.GetFields())
         {
            string value;
            if (myDictionary.TryGetValue(pi.Name, out value))
            {
               // pi.SetValue(myClass, value, null);
               pi.SetValue(myClass, value);
            }
         }
      }


      public static void PopulateToDictionary<T>(T myObject, Dictionary<string, string> myDictionary)
      {
         foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(myObject))
         {
            string name = descriptor.Name;
            object value = descriptor.GetValue(myObject);

            if (value != null)
               myDictionary.Add(name, value.ToString());
         }
      }
   }

   internal static class ErrorStrings
   {
      public const string AdminUsernamePasswordInvalid = "adminUsername/adminPassword combination is not valid.";
      public const string UserDoesNotExist = "User '{0}' does not exist.";
      public const string UserAlreadyExists =  "User '{0}' already exists.";
      public const string InvalidParameter = "Invalid Parameter: {0}.";
   }

}
