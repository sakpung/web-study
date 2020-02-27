// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace JobProcessorServerConfigDemo
{
   static class Globals
   {
      public static readonly string Machine = "localhost";
      public static readonly string UserName = null;
      public static readonly string Password = null;
      public static readonly string Title = "LEADTOOLS Job Processor Server Config Demo";
      public static readonly string AppPoolName = "LEADTOOLSJobProcessorServicesAppPool";
      public static readonly string VirtualDirName = "LEADTOOLSJobProcessorServices";
      public static readonly string OcrJobProcessorClientDemoName = "OcrJobProcessorClientDemo";
      public static readonly string MultimediaJobProcessorClientDemoName = "MultimediaJobProcessorClientDemo";
      public static readonly string JobProcessorFiles = "Media";
      public static string RootDir;
      public static string VirtualDirPath;
      public static string CSOcrClientDemoVirtualDirPath;
      public static string CSMultimediaClientDemoVirtualDirPath;
      public static bool X86Ok;
      public static bool X64Ok;
      public static string AssembliesPathX86;
      public static string AssembliesPathX64;
      public static string SourceCodeDir;
      public static string IISVersion;
      public static int IISMajorVersionNumber;
      public static bool Is64BitOS;
      public static bool IsDotNet35Installed;
      public static bool IsDotNet4Installed;
      public static string WebConfigPath;
      public static string CSExamplesPath;
      public static string VBExamplesPath;
      public static string JobProcessorFilesPath;

#if LTV20_CONFIG
      private const string _toolkitVersion = "20";
#elif LTV19_CONFIG
      private const string _toolkitVersion = "19";
#elif LTV18_CONFIG
      private const string _toolkitVersion = "18";
#elif LTV175_CONFIG
      private const string _toolkitVersion = "17.5";
#endif // LTV19_CONFIG

      public static string[] EnumerateToolkits()
      {
         List<string> toolkits = new List<string>();

         string JobProcessorServer = "LEADTOOLS Job Processor Server";
         RegistryKey key = OpenSoftwareKey(string.Format(@"LEAD Technologies, Inc.\{0}\{1} {0}", _toolkitVersion, JobProcessorServer));
         if (key != null)
         {
            toolkits.Add(string.Format("{0} {1}", JobProcessorServer, _toolkitVersion));
            key.Close();
         }

         key = OpenSoftwareKey(@"Microsoft\Windows\CurrentVersion\Uninstall\");
         if (key != null)
         {
            string displayName = string.Empty;

#if LTV20_CONFIG
            RegistryKey subKey = key.OpenSubKey("{1111511B-A89A-4907-A9D4-BB302F744CDC}");
#elif LTV19_CONFIG
            RegistryKey subKey = key.OpenSubKey("{1111511B-A89A-4907-A9D4-BB302F744CDB}");
#elif LTV18_CONFIG
            RegistryKey subKey = key.OpenSubKey("{1111511B-A89A-4907-A9D4-BB302F744CDA}");
#elif LTV175_CONFIG
            RegistryKey subKey = key.OpenSubKey("{C6E66006-EC72-4D9A-AA1C-149AF73C18FE}");
#endif // #if LTV19_CONFIG
            if (subKey != null)
            {
               displayName = (string)subKey.GetValue("DisplayName");
               subKey.Close();
            }

            key.Close();

            if (!String.IsNullOrEmpty(displayName))
               toolkits.Add(displayName);
         }

         return toolkits.ToArray();
      }

      public static bool Initialize(bool silentMode, string selectedToolkit)
      {
         Is64BitOS = IntPtr.Size == 8;

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
               ShowErrorMessage("Could not find an instance of Microsoft Internet Information Services (IIS) installed on this machine (localhost).\n\nPlease install IIS through the Add Remove Programs control panel applet (Programs and Features on Windows Vista) and try again. This program will now exit.", silentMode);
               return false;
            }
         }
         else
         {
            ShowErrorMessage("Could not find an instance of Microsoft Internet Information Services (IIS) installed on this machine (localhost).\n\nPlease install IIS through the Add Remove Programs control panel applet (Programs and Features on Windows Vista) and try again. This program will now exit.", silentMode);
            return false;
         }

         // Check if .NET 3.5 is installed
         rk = OpenSoftwareKey(@"\Microsoft\NET Framework Setup\NDP\v3.5");
         if (rk != null)
         {
            IsDotNet35Installed = true;
            rk.Close();
         }
         else
            IsDotNet35Installed = false;

         // Check if .NET 4 is installed
         rk = OpenSoftwareKey(@"\Microsoft\NET Framework Setup\NDP\v4.0");
         if (rk != null)
         {
            IsDotNet4Installed = true;
            rk.Close();
         }
         else
            IsDotNet4Installed = false;

         if (!IsDotNet35Installed && !IsDotNet4Installed)
         {
            ShowErrorMessage(".NET Framework 3.5 or 4.0 could not be found on this machine.\n\nPlease install the .NET Framework 3.5 or 4.0 runtime and try again. This program will now exit.", silentMode);
            return false;
         }

         string[] toolkits = EnumerateToolkits();

         if (toolkits.Length > 1 && !silentMode)
         {
            Selection selection = new Selection(toolkits);
            if (selection.ShowDialog() == DialogResult.OK)
            {
               selectedToolkit = selection.SelectedToolkit;
            }
            else
            {
               return false;
            }
         }
         else if (toolkits.Length > 0)
         {
            if (String.IsNullOrEmpty(selectedToolkit))
            {
               selectedToolkit = toolkits[0];
            }
            else
            {
               foreach (string toolkit in toolkits)
               {
                  if (selectedToolkit.Contains(toolkit.ToLower()))
                  {
                     selectedToolkit = toolkit;
                  }
               }
            }
         }

         // Read the paths for the LEADTOOLS installation from the registry
         RegistryKey key = OpenSoftwareKey(string.Format(@"LEAD Technologies, Inc.\{0}\{1}", _toolkitVersion, selectedToolkit));
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
                  return false;
               }

               VirtualDirPath = Path.Combine(RootDir, @"Bin\Common\JobProcessor\Services");
               WebConfigPath = Path.Combine(VirtualDirPath, @"Web.config");
               CSExamplesPath = Path.Combine(RootDir, @"Examples\Dotnet\CS");
               VBExamplesPath = Path.Combine(RootDir, @"Examples\Dotnet\VB");
               
               CSOcrClientDemoVirtualDirPath = Path.Combine(CSExamplesPath, OcrJobProcessorClientDemoName);
               CSMultimediaClientDemoVirtualDirPath = Path.Combine(CSExamplesPath, MultimediaJobProcessorClientDemoName);
               JobProcessorFilesPath = Path.Combine(RootDir, @"Bin\Common\JobProcessor\Media");

               // Check if Win32 or 64-bit version of the toolkit is installed
               X86Ok = CheckComponentInstalled(selectedToolkit, "Win32", "RasterJobProcessor_32Bit");
               X64Ok = CheckComponentInstalled(selectedToolkit, "x64", "RasterJobProcessor_64bit");

               AssembliesPathX86 = Path.Combine(RootDir, @"Bin\DotNet##VER##\Win32");
               AssembliesPathX64 = Path.Combine(RootDir, @"Bin\DotNet##VER##\x64");

               SourceCodeDir = Path.Combine(RootDir, @"Examples\DotNet\CS\JobProcessorServerConfigDemo");

               // Check if the paths exists
               if (!Directory.Exists(VirtualDirPath))
               {
                  ShowErrorMessage(string.Format("The directory '{0}' does not exist or could not be accessed in this machine.", VirtualDirPath), silentMode);
                  return false;
               }

               return true;
            }
            else
               ShowErrorMessage(string.Format("Could not find an instance of {0} {1} installation on this machine.", selectedToolkit, _toolkitVersion), silentMode);
         }
         else
            ShowErrorMessage(string.Format("Could not find an instance of {0} {1} installation on this machine.", selectedToolkit, _toolkitVersion), silentMode);

         return false;
      }

      private static bool CheckComponentInstalled(string toolkit, string feature, string valueName)
      {
         RegistryKey key = OpenSoftwareKey(string.Format(@"LEAD Technologies, Inc.\{0}\{1}\Features\", _toolkitVersion, toolkit) + feature);
         if (key != null)
         {
            object val = key.GetValue(valueName);
            key.Close();

            if (val != null && val is Int32 && (int)val == 1)
               return true;
         }

         return false;
      }

      public static void ShowErrorMessage(string message, bool silentMode)
      {
         if (silentMode)
            return;  // Cannot show any message boxes here

         MessageBox.Show(null, message, Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         ShowTroubleShootingFile();
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

      public static void ShowTroubleShootingFile()
      {
         if (!string.IsNullOrEmpty(RootDir))
         {
            try
            {
               string helpPath = Path.Combine(RootDir, @"Help\HowTo.chm");
               ProcessStartInfo startInfo = new ProcessStartInfo();
               startInfo.FileName = "hh.exe";

               startInfo.Arguments = String.Format("\"mk:@MSITStore:{0}::/WCFIISSetupDemoTroubleshooting.html\"", helpPath);
               using (Process process = new Process())
               {
                  process.StartInfo = startInfo;
                  process.Start();
                  process.Close();
               }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }
   }
}
