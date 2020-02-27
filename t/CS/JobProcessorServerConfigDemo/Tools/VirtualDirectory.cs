// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System.Collections.Generic;
using System.DirectoryServices;

namespace JobProcessorServerConfigDemo.Tools
{
   // Class for managing an IIS virtual directory
   public static class VirtualDirectory
   {
      // Get the names of all the virtual directories in IIS
      public static string[] GetVirtualDirectories(string domain, string username, string password)
      {
         List<string> vDirs = new List<string>();

         DirectoryEntry root = DirectoryEntryTool.GetRoot(DirectoryEntryRootType.IIS, domain, username, password);
         foreach (DirectoryEntry vDir in root.Children)
            vDirs.Add(vDir.Name);

         return vDirs.ToArray();
      }

      // Create a virtual directory
      public static void CreateVirtualDirectory(string domain, string username, string password, string name, string path, string appPoolName)
      {
         DirectoryEntry root = DirectoryEntryTool.GetRoot(DirectoryEntryRootType.IIS, domain, username, password);
         DirectoryEntry vDir = DirectoryEntryTool.GetVirtualDirectory(domain, root, name);

         root.CommitChanges();
         vDir.CommitChanges();

         SaveProperties(vDir, name, path, appPoolName);
      }

      private static void SaveProperties(DirectoryEntry vDir, string name, string path, string appPoolName)
      {
         if (appPoolName != null)
            vDir.Properties["AppPoolId"].Value = appPoolName;

         vDir.Properties["Path"].Value = path;
         vDir.Invoke("AppCreate", true);
         vDir.Properties["AppFriendlyName"].Value = name;

         vDir.Properties["AuthFlags"].Value = 0x07;   // NTLM | AuthBasic | Anonymous

         vDir.CommitChanges();
      }

      // Delete a virtual directory
      public static void DeleteVirtualDirectory(string domain, string username, string password, string name)
      {
         DirectoryEntry root = DirectoryEntryTool.GetRoot(DirectoryEntryRootType.IIS, domain, username, password);
         DirectoryEntry vDir = DirectoryEntryTool.GetVirtualDirectory(domain, root, name);

         root.Children.Remove(vDir);
         root.CommitChanges();
      }
   }
}
