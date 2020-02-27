// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Leadtools.Medical.WebViewer.Core.DataTypes.Common
{
   public class CoreUtils
   {
      private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
      private static readonly Random _Random = new Random();

      public static void CopyStream(Stream input, Stream output)
      {
         byte[] buffer = new byte[8 * 1024];
         int len;
         while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
         {
            output.Write(buffer, 0, len);
         }
      }      

      public static string RandomString(int size)
      {
         char[] buffer = new char[size];

         for (int i = 0; i < size; i++)
         {
            buffer[i] = _chars[_Random.Next(_chars.Length)];
         }
         return new string(buffer);
      }
   }

   public static class Extensions
   {
      public static string ToStringNull(this string s)
      {
         return s ?? (s = "null");
      }
   }
}
