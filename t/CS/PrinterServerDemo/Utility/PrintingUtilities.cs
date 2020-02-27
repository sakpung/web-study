// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
using Leadtools.Printer;

namespace ServerPrinterDemo
{
   class PrintingUtilities
   {
      #region Methods...
      [DllImport("shell32.dll")]
      public static extern bool IsUserAnAdmin();

      internal static string GetPrinterPath(string registryPath)
      {
         try
         {
            string connectionExe = string.Empty;
            string subPathExe = string.Empty;
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(registryPath + "Data");

            if (registryKey != null)
            {
               connectionExe = registryKey.GetValue("ConnectionExe").ToString();
               string[] pathExe = connectionExe.Split('\\');

               for (int iLoop = 0; iLoop < pathExe.Length - 2; iLoop++)
               {
                  subPathExe += pathExe[iLoop] + "\\";
               }
               subPathExe.Remove(subPathExe.Length - 1, 1);
            }
            return subPathExe;
         }
         catch
         {
            return string.Empty;
         }
      }

      internal static string[] GetLeadtoolsPrintersList()
      {
         try
         {
            List<string> printersList = new List<string>();

            foreach(string printerName in PrinterSettings.InstalledPrinters)
            {
               try
               {
                  if (Printer.IsLeadtoolsPrinter(printerName))
                  {
                     printersList.Add(printerName);
                  }
               }
               catch
               {

               }
            }
            return printersList.ToArray();
         }
         catch
         {
            return new List<string>().ToArray();
         }
      }

      internal static string[] GetAllPrintersList()
      {
         try
         {
            List<string> allPrinterList = new List<string>();

            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
               allPrinterList.Add(printerName);
            }
            return allPrinterList.ToArray();
         }
         catch
         {
            return new List<string>().ToArray();
         }
      }

      internal static bool IsPrinterExist(string printerName)
      {
         try
         {
            string[] printers = GetAllPrintersList();
            List<string> printersList = new List<string>();
            printersList.AddRange(printers);

            bool bExist = (printersList.IndexOf(printerName) > 0);
            return bExist;
         }
         catch
         {
            return true;
         }
      }
      #endregion
   }
}
