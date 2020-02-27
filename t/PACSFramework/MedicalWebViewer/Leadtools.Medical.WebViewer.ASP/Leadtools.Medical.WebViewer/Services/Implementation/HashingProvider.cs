// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.IO;
using Leadtools.Medical.WebViewer.DataContracts;
using System.Web.Hosting;
using Leadtools.Medical.WebViewer.Core.DataTypes.Common;
using System.Xml;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.ServiceContracts;
using System.Threading.Tasks;
using System.Text;
using System.Security.Cryptography;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   public class HashingProvider : IHashingProvider
   {
      public HashingProvider ()
      {

      }

      static bool useMD5 = true;
      static object useMD5Lock = new Object();

      public static byte[] GetHash(string inputString)
      {
         if (useMD5)
         {
            try
            {
               using (var algorithm = MD5.Create())
               {
                  return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
               }
            }
            catch //exception might happen if FIPS is enabled
            {
               lock (useMD5Lock)
               {
                  useMD5 = false;
               }
            }            
         }
         if (!useMD5)
         {
            using (var algorithm = SHA1.Create())
            {
               return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            }
         }
         System.Diagnostics.Debug.Assert(false);//should not get here
         return null;
      }

      public string GetHashString(string inputString)
      {
         StringBuilder sb = new StringBuilder();
         foreach (byte b in GetHash(inputString))
            sb.Append(b.ToString("X2"));
         return sb.ToString();
      }
   }
}
