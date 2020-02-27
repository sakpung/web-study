// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.Common;

namespace Leadtools.Medical.PermissionsManagement.DataAccessLayer.DataAccessAgent
{
   internal static class Extensions
   {
      public static T GetColumnValue<T>(this IDataReader reader, params string[] columnNames)
      {
         bool foundValue = false;
         T value = default(T);
         IndexOutOfRangeException lastException = null;

         foreach (string columnName in columnNames)
         {
            try
            {
               int ordinal = reader.GetOrdinal(columnName);
               value = (T)reader.GetValue(ordinal);
               foundValue = true;
            }
            catch (IndexOutOfRangeException ex)
            {
               lastException = ex;
            }
         }

         if (!foundValue)
         {
            string message = string.Format("Column(s) {0} could not be not found.",
                    string.Join(", ", columnNames));

            throw new IndexOutOfRangeException(message, lastException);
         }

         return value;
      }

      public static T GetColumnValueOrDefault<T>(this IDataReader reader, params string[] columnNames)
      {
         T value = default(T);
      
         foreach (string columnName in columnNames)
         {
            try
            {
               int ordinal = reader.GetOrdinal(columnName);
               if (!reader.IsDBNull(ordinal))
               {
                  value = (T)reader.GetValue(ordinal);
                  break;
               }
            }
            catch{}
         }
                  
         return value;
      }

      public static void Param(this DbCommand command, string name, object value)
      {
         var p = command.CreateParameter();
         p.ParameterName = name;
         //p.DbType = DbType.String;
         p.Value = value??DBNull.Value;
         command.Parameters.Add(p);
      }

      public static void Param(this DbCommand command, string name, DateTime? date) 
      {
         var p = command.CreateParameter();
         p.ParameterName = name;
         p.DbType = DbType.DateTime;
         if (date.HasValue)
            p.Value = date.Value;
         else
            p.Value = DBNull.Value;
         command.Parameters.Add(p);
      }
   }
   
   internal static class Hashing
   {
      public static byte[] Hash(string inputString, int maxBytes)
      {
         if (maxBytes >= 32)
         {
            using (var algorithm = System.Security.Cryptography.SHA256.Create())//32 bytes
            {
               return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            }
         }
         else
         {
            using (var algorithm = System.Security.Cryptography.SHA1.Create())//20 bytes
            {
               return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            }
         }
      }

      public static string GetHashNString(string inputString, int max)
      {
         var hash = Hash(inputString, max*2);
         var shorts = new ushort[(int)Math.Ceiling((double)hash.Length / 2)];
         Buffer.BlockCopy(hash, 0, shorts, 0, hash.Length);

         var sb = new StringBuilder();

         foreach (var s in shorts)
            sb.Append(Convert.ToChar(s));

         return sb.ToString();
      }      
   }
   internal static class UserType
   {
      public const string Classic = "classic";
      public const string SmartCard = "smartcard";
      public const string ActiveDirectory = "activedirectory";

      public const char Ext = '.';
      public const string Extendedname = "ext";
   }
   internal static class UserNameResolver
   {
      const int UserNameMaxLength = 16;

      public static Tuple<string, string> FromDb(string userNameOrEncodedName, string userExtendedName, string userType)
      {
         if(!string.IsNullOrEmpty(userExtendedName) && !string.IsNullOrEmpty(userType))
         {
            if(IsExtendedName(userType))
            {
               return new Tuple<string,string>(userExtendedName, DecodeType(userType));
            }
         }
         return new Tuple<string,string>(userNameOrEncodedName, userType); 
      }

      public static Tuple<string, string, string> ToDb(string userName, string userType)
      {
         if (NameShouldBeExtended(userName))
         {
            return new Tuple<string, string, string>(EncodeName(userName.ToLower()), userName, EncodeType(userType));
         }
         return new Tuple<string,string, string>(userName, null, userType); 
      }

      public static string EncodeName(string name)
      {
         var encodedName = Hashing.GetHashNString(name, UserNameMaxLength);
         return encodedName;
      }
      private static string EncodeType(string userType)
      {
         if(string.IsNullOrEmpty(userType))
         {
            userType = UserType.Classic;
         }

         userType = DecodeType(userType);
         userType = userType + UserType.Ext + UserType.Extendedname;
         
         return userType;
      }

      private static string DecodeType(string userType)
      {
         if(!string.IsNullOrEmpty(userType))
         {
            userType = userType.Split(UserType.Ext)[0];
         }
         return userType;
      }

      private static bool NameShouldBeExtended(string userName)
      {
         return (!string.IsNullOrEmpty(userName)) &&  (userName.Length > UserNameMaxLength);
      }
      private static bool IsExtendedName(string userType)
      {
         if(!string.IsNullOrEmpty(userType))
         {
            var types = userType.Split(UserType.Ext);
            if (types.Length > 1)
            {
               return types[1] == UserType.Extendedname;
            }
         }
         return false;
      }
   }
}
