// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Text;
using System.Windows.Forms;
using ManagedPrinterClientDemo;
using System.Runtime.InteropServices;
using Leadtools.Printer.Client;

namespace Client_ManagedDemo
{
   // Managed client demo
   public class MyVirtualPrinterClient : IVirtualPrinterClient
   {
      MainForm mainFrm;

      public MyVirtualPrinterClient()
      {
      }

      private bool Is64Bit()
      {
         return IntPtr.Size == 8;
      }

      bool IVirtualPrinterClient.Startup(string virtualPrinterName, byte[] initialData)
      {
         if (initialData == null || initialData.Length == 0)
         {
            string strTittle;
            if(Is64Bit())
               strTittle = "LEADTOOLS C# Printer Client Demo 64-bit";
            else
               strTittle = "LEADTOOLS C# Printer Client Demo 32-bit";

            string strErrorMessage;

            strErrorMessage = "Incorrect IIS Configuration - Couldn't read initialization data from the server.\n\n" +
                              "In order to use the LEADTOOLS Network Virtual Printer:\n" +
                              "  1. IIS should be installed on the server.\n" +
                              "  2. IIS must be configured using the LEADTOOLS Printer Server IIS Configuration Demo on the server.\n\n" +
                              "Print job will be canceled.";
            MessageBox.Show(null, strErrorMessage, strTittle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
         }

         mainFrm = new MainForm(virtualPrinterName, initialData);
         return true;
      }

      void IVirtualPrinterClient.Shutdown(string virtualPrinterName)
      {
      }

      bool IVirtualPrinterClient.PrintJob(PrintJobData printJobData)
      {
         DialogResult dlgRes = mainFrm.ShowDialog();

         if (dlgRes != DialogResult.OK)
            return false;
         Encoding enc = Encoding.Unicode;

         printJobData.UserData = enc.GetBytes(mainFrm.GetData());

         // Or false to abort the printing
         return true;
      }
   }
}
