// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;

namespace Leadtools.Medical.WebViewer.Common
{
   public class AutoDeleteFileHttpResponseMessage : HttpResponseMessage
   {
       private string filePath;

       public AutoDeleteFileHttpResponseMessage (string filePath)
       {
           this.filePath = filePath;
       }

       protected override void Dispose(bool disposing)
       {
           base.Dispose(disposing);

           Content.Dispose();

           File.Delete(filePath);
       }
   }

   internal class FileUtility
   {
      public static string GetAbsolutePath(string relativePath)
      {
         if (string.IsNullOrEmpty(relativePath) || relativePath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
         {
            // Not a legal path
            return relativePath;
         }

         relativePath = relativePath.Trim();
         if (!Path.IsPathRooted(relativePath))
            relativePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, relativePath);
         return relativePath;
      }

      public static bool IsAbsolutePath(string relativePath)
      {
         if (string.IsNullOrEmpty(relativePath) || relativePath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
         {
            // Not a legal path
            return false;
         }

         return Path.IsPathRooted(relativePath.Trim());
      }
   }
}
