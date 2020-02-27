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
using System.IO;
using System.Management;

namespace PrinterDemo
{
   class PrintingUtilities
   {
      #region Methods...
      [DllImport("shell32.dll")]
      public static extern bool IsUserAnAdmin();

      private static bool Is64Bit()
      {
         return IntPtr.Size == 8;
      }

      internal static bool InstallNewPrinter(string printerName, string printerPassword)
      {
         try
         {
            if (IsPrinterExist(printerName))
            {
               string errorMessage = "Duplicated printer name. Please enter another name.";
               MessageBox.Show(errorMessage, "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return false;
            }
            else
            {
#if LTV20_CONFIG
               string documentPrinterRegPath = @"SOFTWARE\LEAD Technologies, Inc.\20\Printer\";
#endif
               PrinterInfo printerInfo = new PrinterInfo();
               printerInfo.PortName = printerName;
               printerInfo.MonitorName = printerName;
               printerInfo.ProductName = printerName;
               printerInfo.PrinterName = printerName;
               printerInfo.Password = printerPassword;
               printerInfo.RegistryKey = documentPrinterRegPath + printerName;
               printerInfo.RootDir = GetPrinterPath(documentPrinterRegPath);
               printerInfo.Url = "https://www.leadtools.com/support/default.htm";
               printerInfo.PrinterExe = Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "CSPrinterServerDemo_Original.exe";
               printerInfo.AboutIcon = @"C:\Users\Public\Documents\LEADTOOLS Images\PrinterDriver.ico";
               if(Is64Bit())
                  printerInfo.AboutString = "LEADTOOLS C# Network Printer 64-Bit";
               else
                  printerInfo.AboutString = "LEADTOOLS C# Network Printer 32-Bit";

               Printer.Install(printerInfo);
               MessageBox.Show("Installing New Printer Completed Successfully", "LEADTOOLS Printer Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

      private static List<string> GetPrinters()
      {
         List<string> printerNames = new List<string>();

         // Use the ObjectQuery to get the list of configured printers
         System.Management.ObjectQuery oquery =
             new System.Management.ObjectQuery("SELECT * FROM Win32_Printer");

         System.Management.ManagementObjectSearcher mosearcher =
             new System.Management.ManagementObjectSearcher(oquery);

         System.Management.ManagementObjectCollection moc = mosearcher.Get();

         foreach (ManagementObject mo in moc)
         {
            System.Management.PropertyDataCollection pdc = mo.Properties;
            foreach (System.Management.PropertyData pd in pdc)
            {
               if (!(bool)mo["Network"])
               {
                  bool bExists = printerNames.Contains(mo["DeviceID"].ToString());
                  if (!bExists)
                     printerNames.Add(mo["DeviceID"].ToString());
               }
            }
         }

         return printerNames;

      }

      internal static string[] GetLeadtoolsPrintersList()
      {
         try
         {
            List<string> printersList = new List<string>();

            foreach (string printerName in GetPrinters().ToArray())
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

            bool bExist = (printersList.IndexOf(printerName) >= 0);
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
