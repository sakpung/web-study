// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Medical.WebViewer.PatientAccessRights;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leadtools.Medical.PatientRestrict.AddIn.Common
{
   internal static class MyExtensions
      {
         public static bool CaseInsensitiveContains(this string text, string value, StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
         {
            return text.IndexOf(value, stringComparison) >= 0;
         }

      internal static string MyTrim(this string str)
      {
         if (string.IsNullOrEmpty(str))
         {
            return string.Empty;
         }

         return str.Trim();
      }

      internal static bool MyContains(this List<AeAccessKey> aeRoleList, AeAccessKey value)
      {
         return aeRoleList.Any(x => (x.AeTitle == value.AeTitle) && (x.AccessKey == value.AccessKey));
      }

      internal static int MyRemoveAll(this List<AeAccessKey> aeRoleList, AeAccessKey value)
      {
         int countRemoved = aeRoleList.RemoveAll(x => (x.AeTitle == value.AeTitle) && (x.AccessKey == value.AccessKey));
         return countRemoved;
      }

      internal static List<string> MyGetAeList(this List<AeAccessKey> aeRoleList)
      {
         List<string> result = aeRoleList.Select(x => x.AeTitle).Distinct().ToList();
         return result;
      }

      internal static List<string> MyGetRoleList(this List<AeAccessKey> aeRoleList)
      {
         List<string> result = aeRoleList.Select(x => x.AccessKey).Distinct().ToList();
         return result;
      }
   }
}
