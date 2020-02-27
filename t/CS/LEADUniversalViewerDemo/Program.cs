// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace LEADUniversalViewer
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         //Check if the Multimedia DLL is available in the current directory
         try
         {
            Assembly assembly = Assembly.LoadFrom("Leadtools.Multimedia.dll");
            Application.Run(new MainForm());
         }
         catch (System.IO.FileNotFoundException)
         {
            DialogResult MsgBoxRes = MessageBox.Show("LEADTOOLS Multimedia SDK is not installed. Please download and install it to continue using this demo.\nDo you want to download LEADTOOLS Multimedia SDK?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (MsgBoxRes == System.Windows.Forms.DialogResult.Yes)
               System.Diagnostics.Process.Start("https://www.leadtools.com/downloads?category=mm");
            else
               return;
         }
      }
   }
}
