// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
namespace Leadtools.Medical.WebViewer.Wado
{
   internal static class UrlBuilder
   {
      internal static string Combine(string url1, string url2)
      {
         if (string.IsNullOrEmpty(url2))
            return url1;

         if (string.IsNullOrEmpty(url1))
            return url2;

         char c = url1[url1.Length - 1];
         if (c != '/')
         {
            return url1 + "/" + url2;
         }

         return url1 + url2;
      }
   }
}
