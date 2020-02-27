// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ModalityWorklistWCFDemo.UI;

namespace ModalityWorklistWCFDemo
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
         _mf = new MainForm();
         Application.Run(_mf);
      }

      private static MainForm _mf = null;

      public static MainForm MyMainForm
      {
         get { return Program._mf; }
      }
   }
}
