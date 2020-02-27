// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Leadtools.Demos
{
   public static class DemoUtils
   {
      public static bool IsAlreadyRunning()
      {
         bool alreadyRunning = false;
         Process currentProcess = Process.GetCurrentProcess();
         Process[] processes = Process.GetProcessesByName(currentProcess.ProcessName);
         foreach (Process process in processes)
         {
            if (process.MainModule.ModuleName == currentProcess.MainModule.ModuleName)
            {
               if (alreadyRunning)
                  return true;

               alreadyRunning = true;
            }
         }
         return false;
      }

      public static bool CheckAdminRights()
      {
         bool elevate = false;

         bool needUAC = false;

         // Check if we need UAC to elevate the rights
         OperatingSystem os = Environment.OSVersion;
         if (os.Platform == PlatformID.Win32NT && os.Version.Major >= 6)
            needUAC = true;
         else
            needUAC = false;

         if (needUAC)
         {
            // Check if we are not running in admin mode
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            WindowsPrincipal wp = new WindowsPrincipal(wi);

            if (!wp.IsInRole(WindowsBuiltInRole.Administrator))
               elevate = true;
         }

         return !elevate;
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

      public static bool IsDotNet35Installed()
      {
         bool ret = false;
         RegistryKey rk = OpenSoftwareKey(@"\Microsoft\NET Framework Setup\NDP\v3.5");
         if (rk != null)
         {
            ret = true;
            rk.Close();
         }

         else
            ret = false;
         return ret;
      }

      public static string GetMachineIP()
      {
         string address = "";
         IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());

         IPAddress[] Addresses = hostEntry.AddressList;

         for (int i = 0; i < Addresses.Length; ++i)
         {
            if (Addresses[i].AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
               address = Addresses[i].ToString();
            }
         }

         return address;
      }
   }
}
