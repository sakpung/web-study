// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Medical.Workstation.UI;

namespace Leadtools.Demos.Workstation.Customized
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string[] args)
      {
         if (!Support.SetLicense())
            return;

         try
         {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Leadtools.Dicom.DicomEngine.Startup ( ) ;
            Leadtools.Dicom.DicomNet.Startup ( ) ;

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            new WorkstationShellController ( ).Run ( ) ;
         }
         catch ( Exception exception ) 
         {
            ViewErrorDetailsDialog detailedError ;
            
            
            detailedError = new ViewErrorDetailsDialog ( exception ) ;
            
            detailedError.ShowDialog ( ) ;
         }
         finally
         {
            Leadtools.Dicom.DicomEngine.Shutdown ( ) ;
            Leadtools.Dicom.DicomNet.Shutdown ( ) ;
         }
      }

      static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
      {
         ViewErrorDetailsDialog detailedError ;
         
         
         detailedError = new ViewErrorDetailsDialog ( e.Exception ) ;
         
         detailedError.ShowDialog ( ) ;
         
      }
      
   }
}
