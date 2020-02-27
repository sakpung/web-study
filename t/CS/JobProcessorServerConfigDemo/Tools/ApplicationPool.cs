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
   // Class for managing IIS application pools
   public static class ApplicationPool
   {
      // Get the names of all the application pools in IIS
      public static string[] GetApplicationPools(string domain, string username, string password)
      {
         DirectoryEntry root = DirectoryEntryTool.GetRoot(DirectoryEntryRootType.AppPool, domain, username, password);

         List<string> appPools = new List<string>();
         foreach (DirectoryEntry entry in root.Children)
            appPools.Add(entry.Name);

         return appPools.ToArray();
      }

      // Create a new application pool in IIS
      public static void CreateApplicationPool(string domain, string username, string password, string appPoolName, bool enable32BitAppOnWin64, string dotnetRuntimeVersion)
      {
         DirectoryEntry root = DirectoryEntryTool.GetRoot(DirectoryEntryRootType.AppPool, domain, username, password);
         DirectoryEntry appPool = root.Invoke("Create", "IIsApplicationPool", appPoolName) as DirectoryEntry;
         if (appPool != null)
         {
            if (Globals.IISMajorVersionNumber > 6)
               if (enable32BitAppOnWin64)
                  appPool.Properties["Enable32BitAppOnWin64"].Value = true;
               else
                  appPool.Properties["Enable32BitAppOnWin64"].Value = false;

            if (Globals.IISMajorVersionNumber >= 7)
            {
               appPool.Properties["ManagedRuntimeVersion"].Value = dotnetRuntimeVersion;
               appPool.Properties["ManagedPipelineMode"].Value = 0; // Integrated
            }

            // Change the identity to LocalSystem, possible values:
            // 0  Local System
            // 1  Local Service
            // 2  Network Service
            // 3  Specific user
            appPool.InvokeSet("AppPoolIdentityType", new Object[] { 0 });

            appPool.CommitChanges();
         }
         root.CommitChanges();
      }

      // Delete an application pool from IIS
      public static void DeleteApplicationPool(string domain, string username, string password, string appPoolName)
      {
         DirectoryEntry root = DirectoryEntryTool.GetRoot(DirectoryEntryRootType.AppPool, domain, username, password);
         root.Invoke("Delete", "IIsApplicationPool", appPoolName);
         root.CommitChanges();
      }
   }
}
