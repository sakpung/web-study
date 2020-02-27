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

namespace PrinterDemo
{
   class PrintingUtilities
   {
      #region Methods...
      [DllImport("shell32.dll")]
      public static extern bool IsUserAnAdmin();

      internal static bool InstallNewPrinter(string printerName, string printerPassword)
      {
         try
         {
            if (IsPrinterExist(printerName))
            {
               string errorMessage = "Duplicated printer name. Please enter another name.";
               MessageBox.Show(errorMessage, "LEADTOOLS C# Print to PACS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return false;
            }
            else
            {
#if LTV16_CONFIG
               string documentPrinterRegPath = @"SOFTWARE\LEAD Technologies, Inc.\Printer\";
#endif
#if LTV17_CONFIG 
               string documentPrinterRegPath = @"SOFTWARE\LEAD Technologies, Inc.\17\Printer\";
#endif
#if LTV175_CONFIG
               string documentPrinterRegPath = @"SOFTWARE\LEAD Technologies, Inc.\17.5\Printer\";
#endif
#if LTV18_CONFIG
               string documentPrinterRegPath = @"SOFTWARE\LEAD Technologies, Inc.\18\Printer\";
#endif
#if LTV19_CONFIG
               string documentPrinterRegPath = @"SOFTWARE\LEAD Technologies, Inc.\19\Printer\";
#endif
#if LTV20_CONFIG
               string documentPrinterRegPath = @"SOFTWARE\LEAD Technologies, Inc.\20\Printer\";
#endif

               if (Environment.OSVersion.Version.Major >= 6 && !PrintingUtilities.IsUserAnAdmin())
               {
                  //On operating system vista or upper, demo requires to be ran with elevated rights
                  return false;
               }

               PrinterInfo printerInfo = new PrinterInfo();
               printerInfo.PortName = printerName;
               printerInfo.MonitorName = printerName;
               printerInfo.ProductName = printerName;
               printerInfo.PrinterName = printerName;
               printerInfo.Password = printerPassword;
               printerInfo.RegistryKey = documentPrinterRegPath + printerName;
               printerInfo.RootDir = GetPrinterPath(documentPrinterRegPath);
               printerInfo.Url = "https://www.leadtools.com/support/default.htm";
               printerInfo.PrinterExe = Application.ExecutablePath;
               //printerInfo.AboutIcon = System.IO.Path.Combine(Leadtools.Demos.DemosGlobal.ImagesFolder, "PrinterDriver.ico");
               printerInfo.AboutString = "LEADTOOLS C# Print to PACS";

               //Function Requires administrative rights
               Printer.Install(printerInfo);

               return true;
            }
         }
         catch
         {
            return false;
         }
      }

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

            foreach (string printerName in PrinterSettings.InstalledPrinters)
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
            bool bExist = printersList.Contains(printerName.Trim());
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
