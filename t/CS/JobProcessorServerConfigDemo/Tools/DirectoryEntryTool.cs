// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace JobProcessorServerConfigDemo.Tools
{
   // Type of directory entry we are interested in
   public enum DirectoryEntryRootType
   {
      IIS,        // Internet Information System
      AppPool     // The application pool used in IIS
   }

   public static class DirectoryEntryTool
   {
      // Gets the root of a directory entry type
      public static DirectoryEntry GetRoot(DirectoryEntryRootType rootType, string domain, string username, string password)
      {
         string path = GetPath(rootType, domain);

         DirectoryEntry root;

         if (!string.IsNullOrEmpty(username))
            root = new DirectoryEntry(path, username, password);
         else
            root = new DirectoryEntry(path);

         if (root == null)
            throw new Exception("Could not get the directory entry. Please check if you have enough access rights to complete this operation");

         return root;
      }

      // Gets the physical path of a directory entry type
      public static string GetPath(DirectoryEntryRootType rootType, string domain)
      {
         string path;

         switch (rootType)
         {
            case DirectoryEntryRootType.AppPool:
               path = "IIS://" + domain + "/W3SVC/AppPools";
               break;

            case DirectoryEntryRootType.IIS:
               path = "IIS://" + domain + "/W3SVC/1/ROOT";
               break;

            default:
               return null;
         }

         return path;
      }

      // Gets the entry for a virtual directory
      public static DirectoryEntry GetVirtualDirectory(string domain, DirectoryEntry root, string name)
      {
         DirectoryEntry vDir = null;

         try
         {
            vDir = root.Children.Add(name, "IISWebVirtualDir");
         }
         catch
         {
            string iisPath = DirectoryEntryTool.GetPath(DirectoryEntryRootType.IIS, domain);
            vDir = new DirectoryEntry(iisPath + "/" + name);
         }

         if (vDir == null)
            throw new Exception("Could not create the virtual directory. Please check if you have enough access rights to complete this operation");

         return vDir;
      }
   }
}
