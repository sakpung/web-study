// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.DirectoryServices;

namespace PrinterServiceIISConfigDemo
{
   static class Globals
   {
      public static readonly string Machine = "localhost";
      public static readonly string UserName = null;
      public static readonly string Password = null;
      public static readonly string Title = "LEADTOOLS Printer ISS Config";
      public static string AppPoolName = "VirtualPrinter";
      public static string VirtualDirName = "VirtualPrinterWebService";
      public static string VirtualDirPath;
      public static string IISVersion;
      public static int IISMajorVersionNumber;
      public static bool Is64BitOS;

#if LTV175_CONFIG
      public static string _toolkitVersion = "17.5";
#endif
#if LTV18_CONFIG
      public static string _toolkitVersion = "18";
#endif
#if LTV19_CONFIG
      public static string _toolkitVersion = "19";
#endif
#if LTV20_CONFIG
      public static string _toolkitVersion = "20";
#endif

      public static bool Initialize(bool silentMode, out string strRet)
      {
         Is64BitOS = IntPtr.Size == 8;

         string versionName = _toolkitVersion.Replace(".", "");
         AppPoolName = AppPoolName + versionName;
         VirtualDirName = VirtualDirName + versionName;

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
            }
            else
            {
               strRet = "Could not find an instance of Microsoft Internet Information Services (IIS) installed on this machine (localhost).\n\nPlease install IIS through the Add Remove Programs control panel applet (Programs and Features on Windows Vista) and try again. This program will now exit.";
               ShowErrorMessage(strRet, silentMode);
               return false;
            }
         }
         else
         {
            strRet = "Could not find an instance of Microsoft Internet Information Services (IIS) installed on this machine (localhost).\n\nPlease install IIS through the Add Remove Programs control panel applet (Programs and Features on Windows Vista) and try again. This program will now exit.";
            ShowErrorMessage(strRet, silentMode);
            return false;
         }

         RegistryKey key = OpenSoftwareKey(string.Format(@"LEAD Technologies, Inc.\{0}\LEADTOOLS Virtual Printer {0}", _toolkitVersion));
         string RootDir;
         if (key != null)
         {
            object value = key.GetValue("RootDir");
            key.Close();

            if (value != null)
            {
               RootDir = value.ToString();
               if (!Directory.Exists(RootDir))
               {
                  ShowErrorMessage(string.Format("The directory '{0}' does not exist or could not be accessed in this machine.", RootDir), silentMode);
                  strRet = "";
                  return false;
               }

               VirtualDirPath = Path.Combine(RootDir, @"Bin\Common\PrinterDriver\WebService");
            }
         }

         strRet = "";
         return true;
      }

      public static void ShowErrorMessage(string message, bool silentMode)
      {
         if (silentMode)
            return;  // Cannot show any message boxes here

         MessageBox.Show(null, message, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }

      public static RegistryKey OpenSoftwareKey(string keyName)
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
   }

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
