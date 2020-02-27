// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using Microsoft.Win32;

namespace Leadtools.Demos
{
   // IIS Tools
   // Call Initialize first, then use .IsIISAvailable to check if IIS is installed
   // before calling any other methods
   internal static class IISTools
   {
      public static bool IsIISAvailable;
      public static string IISVersion;
      public static int IISMajorVersionNumber;

      // Authentication to use when calling Directory services, set these if you must
      public static string Username;
      public static string Password;

      public static void Initialize()
      {
         // Get the IIS version
         RegistryKey rk = OpenSoftwareKey(@"Microsoft\InetStp");
         if (rk != null)
         {
            object major = rk.GetValue("MajorVersion");
            object minor = rk.GetValue("MinorVersion");

            rk.Close();

            if (major != null && minor != null)
            {
               IISMajorVersionNumber = (int)major;
               IISVersion = major.ToString() + "." + minor.ToString();
               IsIISAvailable = true;
            }
         }
      }

      private static RegistryKey OpenSoftwareKey(string keyName)
      {
         RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\" + keyName);
         if (key == null)
         {
            key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\" + keyName);
            if (key == null)
               key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + keyName);
         }

         return key;
      }

      public static class DirectoryEntryTool
      {
         // Type of directory entry we are interested in
         public enum RootType
         {
            IIS,        // Internet Information System
            AppPool     // The application pool used in IIS
         }

         // Gets the root of a directory entry type
         public static DirectoryEntry GetRoot(RootType rootType, string machine)
         {
            string path = GetPath(rootType, machine);

            DirectoryEntry root;

            if (!string.IsNullOrEmpty(IISTools.Username))
               root = new DirectoryEntry(path, IISTools.Username, IISTools.Password);
            else
               root = new DirectoryEntry(path);

            if (root == null)
               throw new Exception("Could not get the directory entry. Please check if you have enough access rights to complete this operation");

            return root;
         }

         // Gets the physical path of a directory entry type
         public static string GetPath(RootType rootType, string machine)
         {
            string path;

            switch (rootType)
            {
               case RootType.AppPool:
                  path = "IIS://" + machine + "/W3SVC/AppPools";
                  break;

               case RootType.IIS:
                  path = "IIS://" + machine + "/W3SVC/1/ROOT";
                  break;

               default:
                  return null;
            }

            return path;
         }

         // Gets the entry for a virtual directory
         public static DirectoryEntry GetVirtualDirectory(string machine, DirectoryEntry root, string name)
         {
            DirectoryEntry vDir = null;

            try
            {
               vDir = root.Children.Add(name, "IISWebVirtualDir");
            }
            catch
            {
               string iisPath = DirectoryEntryTool.GetPath(RootType.IIS, machine);
               vDir = new DirectoryEntry(iisPath + "/" + name);
            }

            if (vDir == null)
               throw new Exception("Could not create the virtual directory. Please check if you have enough access rights to complete this operation");

            return vDir;
         }
      }

      // Class for managing an IIS virtual directory
      public class VirtualDirectory
      {
         public string Name;
         public string Path;
         public string AppFriendlyName;
         public string AppPoolId;

         public static VirtualDirectory Find(string machine, string name)
         {
            List<VirtualDirectory> items = FindAll(machine);
            foreach (VirtualDirectory item in items)
            {
               if (item.Name == name)
                  return item;
            }

            return null;
         }

         // Get the names of all the virtual directories in IIS
         public static List<VirtualDirectory> FindAll(string machine)
         {
            List<VirtualDirectory> result = new List<VirtualDirectory>();

            using (DirectoryEntry root = DirectoryEntryTool.GetRoot(DirectoryEntryTool.RootType.IIS, machine))
            {
               foreach (DirectoryEntry entry in root.Children)
               {
                  VirtualDirectory item = new VirtualDirectory();
                  item.Name = entry.Name;

                  if (entry.Properties.Contains("Path"))
                     item.Path = (string)entry.Properties["Path"].Value;
                  else
                     item.Path = null;

                  if (entry.Properties.Contains("AppFriendlyName"))
                     item.AppFriendlyName = (string)entry.Properties["AppFriendlyName"].Value;
                  else
                     item.AppFriendlyName = null;

                  if (entry.Properties.Contains("AppPoolId"))
                     item.AppPoolId = (string)entry.Properties["AppPoolId"].Value;
                  else
                     item.AppPoolId = null;

                  result.Add(item);
               }
            }

            return result;
         }

         // Create a virtual directory
         public static void Create(string machine, VirtualDirectory item)
         {
            using (DirectoryEntry root = DirectoryEntryTool.GetRoot(DirectoryEntryTool.RootType.IIS, machine))
            {
               using (DirectoryEntry entry = DirectoryEntryTool.GetVirtualDirectory(machine, root, item.Name))
               {
                  root.CommitChanges();
                  entry.CommitChanges();

                  SetProperties(entry, item);
               }
            }
         }

         public static void SetProperties(DirectoryEntry entry, VirtualDirectory item)
         {
            if (IISTools.IISMajorVersionNumber >= 6 && item.AppPoolId != null)
               entry.Properties["AppPoolId"].Value = item.AppPoolId;

            if (item.Path != null)
               entry.Properties["Path"].Value = item.Path;
            entry.Invoke("AppCreate", true);

            entry.Properties["AppFriendlyName"].Value = item.Name;

            entry.Properties["AuthFlags"].Value = 0x07;   // NTLM | AuthBasic | Anonymous

            entry.CommitChanges();
         }

         // Delete a virtual directory
         public static void Delete(string machine, string name)
         {
            using (DirectoryEntry root = DirectoryEntryTool.GetRoot(DirectoryEntryTool.RootType.IIS, machine))
            {
               using (DirectoryEntry entry = DirectoryEntryTool.GetVirtualDirectory(machine, root, name))
               {

                  root.Children.Remove(entry);
                  root.CommitChanges();
               }
            }
         }
      }

      // Class for managing IIS application pools
      public class ApplicationPool
      {
         public enum PipelineMode
         {
            Intergrated = 0,
            Classic = 1,
            Other = 2
         }

         public enum IdentityType
         {
            LocalSystem = 0,
            LocalService = 1,
            NetworkService = 2,
            Other = 3
         }

         public string Name;

         // Only available on IIS 6 and later
         public bool Enable32BitAppOnWin64;

         // Only available on IIS 7 and later
         public string ManagedRuntimeVersion;
         public PipelineMode ManagedPipelineMode;

         public IdentityType AppPoolIdentityType;

         public static ApplicationPool Find(string machine, string name)
         {
            List<ApplicationPool> items = FindAll(machine);
            foreach (ApplicationPool item in items)
            {
               if (item.Name == name)
                  return item;
            }

            return null;
         }

         // Get the names of all the application pools in IIS
         public static List<ApplicationPool> FindAll(string machine)
         {
            using (DirectoryEntry root = DirectoryEntryTool.GetRoot(DirectoryEntryTool.RootType.AppPool, machine))
            {
               List<ApplicationPool> result = new List<ApplicationPool>();
               foreach (DirectoryEntry entry in root.Children)
               {
                  ApplicationPool item = new ApplicationPool();
                  item.Name = entry.Name;

                  if (IISTools.IISMajorVersionNumber > 6)
                  {
                     if (entry.Properties.Contains("Enable32BitAppOnWin64"))
                        item.Enable32BitAppOnWin64 = (bool)entry.Properties["Enable32BitAppOnWin64"].Value;
                  }

                  if (IISTools.IISMajorVersionNumber >= 7)
                  {
                     if (entry.Properties.Contains("ManagedRuntimeVersion"))
                        item.ManagedRuntimeVersion = (string)entry.Properties["ManagedRuntimeVersion"].Value;

                     if (entry.Properties.Contains("ManagedPipelineMode"))
                     {
                        int value = (int)entry.Properties["ManagedPipelineMode"].Value;
                        if (Enum.IsDefined(typeof(PipelineMode), value))
                           item.ManagedPipelineMode = (PipelineMode)value;
                        else
                           item.ManagedPipelineMode = PipelineMode.Other;
                     }
                  }

                  try
                  {
                     int value = (int)entry.InvokeGet("AppPoolIdentityType");
                     if (Enum.IsDefined(typeof(IdentityType), value))
                        item.AppPoolIdentityType = (IdentityType)value;
                     else
                        item.AppPoolIdentityType = IdentityType.Other;
                  }
                  catch { }

                  result.Add(item);
               }

               return result;
            }
         }

         // Create a new application pool in IIS
         public static void Create(string machine, ApplicationPool item)
         {
            using (DirectoryEntry root = DirectoryEntryTool.GetRoot(DirectoryEntryTool.RootType.AppPool, machine))
            {
               DirectoryEntry entry = root.Invoke("Create", "IIsApplicationPool", item.Name) as DirectoryEntry;
               if (entry != null)
               {
                  if (IISTools.IISMajorVersionNumber > 6)
                     entry.Properties["Enable32BitAppOnWin64"].Value = item.Enable32BitAppOnWin64;

                  if (IISTools.IISMajorVersionNumber >= 7)
                  {
                     entry.Properties["ManagedRuntimeVersion"].Value = item.ManagedRuntimeVersion;
                     entry.Properties["ManagedPipelineMode"].Value = (int)item.ManagedPipelineMode;
                  }

                  entry.InvokeSet("AppPoolIdentityType", new Object[] { (int)item.AppPoolIdentityType });

                  entry.CommitChanges();
                  entry.Dispose();
               }

               root.CommitChanges();
            }
         }

         // Delete an application pool from IIS
         public static void Delete(string machine, string name)
         {
            using (DirectoryEntry root = DirectoryEntryTool.GetRoot(DirectoryEntryTool.RootType.AppPool, machine))
            {
               root.Invoke("Delete", "IIsApplicationPool", name);
               root.CommitChanges();
            }
         }

         public static void UpdateEnable32BitAppOnWin64(string machine, ApplicationPool item, bool value)
         {
            using (DirectoryEntry root = DirectoryEntryTool.GetRoot(DirectoryEntryTool.RootType.AppPool, machine))
            {
               using (DirectoryEntry pool = root.Children.Find(item.Name, "IIsApplicationPool"))
               {
                  pool.Properties["Enable32BitAppOnWin64"].Value = value;

                  pool.CommitChanges();

                  item.Enable32BitAppOnWin64 = value;
               }

            }
         }

      }

   }
}
