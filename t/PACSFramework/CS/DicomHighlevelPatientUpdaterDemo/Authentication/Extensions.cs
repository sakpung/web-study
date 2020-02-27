// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;

namespace DicomDemo.Authentication
{
   public static class Extensions
   {
      public static SecureString ToSecureString(this string password)
      {
         char[] passwordChars;
         SecureString secure;


         passwordChars = password.ToCharArray();
         secure = new SecureString();

         foreach (char c in passwordChars)
         {
            secure.AppendChar(c);
         }

         secure.MakeReadOnly();

         return secure;
      }
   }
}
