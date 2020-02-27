// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MPPSWCFDemo.UI;

namespace MPPSWCFDemo
{
   public static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      public static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm());
      }

      public static string GenerateDicomUniqueIdentifier()
      {
         string strGUID = "";

         try
         {
            DateTime SystemTime = DateTime.Now;
            Random rand = new Random((int)SystemTime.Ticks);
            strGUID = String.Format("1.2.840.114257.1.1{0}{1}{2}", SystemTime.Ticks, rand.Next(), rand.Next());
            // max length for this field is 64 so cut it off if too long
            if (strGUID.Length > 64)
               strGUID = strGUID.Substring(0, 64);
         }
         catch (Exception ex)
         {
            throw ex;
         }

         return strGUID;
      }
   }
}
