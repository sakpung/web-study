// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;
using Leadtools.Dicom;
using Leadtools.Medical.DataAccessLayer.Configuration;
using Leadtools.Medical.Workstation.UI;
using Leadtools.Demos.Workstation.Configuration;
using Leadtools.Medical.Winforms;
using Leadtools.Medical.UserManagementDataAccessLayer;
using System.Reflection;


namespace Leadtools.Demos.Workstation
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main(string[] args)
      {
#pragma warning disable 436

         if (!Support.SetLicense())
            return;

#pragma warning restore 436

         if (DemosGlobal.MustRestartElevated())
         {
            DemosGlobal.TryRestartElevated(args);
            return;
         }
         
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         
         
         try
         {
            string dicomDirFile;

            Leadtools.Dicom.DicomEngine.Startup ( ) ;
            Leadtools.Dicom.DicomNet.Startup ( ) ;

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            dicomDirFile = GetDicomDir ( ) ;
            
            if ( !string.IsNullOrEmpty ( dicomDirFile ) )
            {
               ConfigurationData.CurrentDicomDir           = dicomDirFile ;
               ConfigurationData.SupportDicomCommunication = false ;
               ConfigurationData.SupportLocalQueriesStore  = false ;
               ConfigurationData.SaveSessionBehavior       = SaveOptions.NeverSave ;
               ConfigurationData.ClientBrowsingMode        = DicomClientMode.DicomDir ;
               ConfigurationData.RunPacsConfig             = false ;
               ConfigurationData.CheckDataAccessServices   = false ;
               ConfigurationData.ShowSplashScreen          = false ;
               ConfigurationData.AutoQuery                 = true ;
               
               UserAccessManager.SetAuthenticatedUser ( new User ( "guest", false ) ) ;
               
               if ( ConfigurationData.ApplicationName == "Medical Workstation Viewer Main Demo" )
               {
                  ConfigurationData.ApplicationName = "Medical Workstation Viewer DICOM DIR Demo" ;
               }
               
               WorkstationShellController.Instance.Run ( ) ;
            }
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

      private static string GetDicomDir ( )
      {
         string defaultDicomDir ;


         defaultDicomDir = Path.Combine(Path.GetPathRoot(Assembly.GetExecutingAssembly().Location), "DICOMDIR");
         if (!File.Exists(defaultDicomDir))
         {
            defaultDicomDir = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "DICOMDIR");
         }

         if ( !File.Exists ( defaultDicomDir ) )
         {
            string canBrowseText = ConfigurationManager.AppSettings [ "CanBrowseDicomDir" ] ;
            
            if ( string.IsNullOrEmpty ( canBrowseText ) || bool.Parse ( canBrowseText ) == false )
            {
               return null ;
            }
            else
            {
               string message = string.Format("DICOMDIR file not found:\r\n'{0}'\r\n\r\nDo you want to browse for a DICOMDIR?", defaultDicomDir);
               DialogResult result = MessageBox.Show ( message,
                                                       "Question",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question ) ;
                                                       
               if ( DialogResult.Yes == result )
               {
                  OpenFileDialog openFileDialog = new OpenFileDialog ( ) ;
                  
                  openFileDialog.FileName = "DICOMDIR" ;
                  
                  if ( openFileDialog.ShowDialog ( ) == DialogResult.OK ) 
                  {
                     if ( openFileDialog.SafeFileName != "DICOMDIR" ) 
                     {
                        MessageBox.Show ( "Invalid DICOMDIR file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
                        
                        return null ;
                     }
                     else
                     {
                        return openFileDialog.FileName ;
                     }
                  }
               }
            }
            
            return null ;
         }
         else
         {
            return defaultDicomDir ;
         }
      }

      static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
      {
         ViewErrorDetailsDialog detailedError ;
         
         
         detailedError = new ViewErrorDetailsDialog ( e.Exception ) ;
         
         detailedError.ShowDialog ( ) ;
         
      }

      private static bool NeedUAC()
      {
         OperatingSystem system = Environment.OSVersion;

         if (system.Platform == PlatformID.Win32NT && system.Version.Major >= 6)
            return true;

         return false;
      }

      private static bool IsAdmin()
      {
         WindowsIdentity id = WindowsIdentity.GetCurrent();
         WindowsPrincipal p = new WindowsPrincipal(id);

         return p.IsInRole(WindowsBuiltInRole.Administrator);
      }

      private static void RestartElevated()
      {
         ProcessStartInfo startInfo = new ProcessStartInfo();

         startInfo.UseShellExecute = true;
         startInfo.WorkingDirectory = Environment.CurrentDirectory;
         startInfo.FileName = Application.ExecutablePath;
         startInfo.Verb = "runas";
         try
         {
            Process p = Process.Start(startInfo);
         }
         catch (System.ComponentModel.Win32Exception)
         {
            return;
         }
      }
      
   }
   
      public static class WorkstationUtils
      {
         public static bool IsDataAccessSettingsValid ( string sectionName )
         {
            ConfigurationManager.RefreshSection ( sectionName ) ;
            
            DataAccessSettings section = ConfigurationManager.GetSection ( sectionName ) as DataAccessSettings ;
            
            
            if ( null != section ) 
            {
               ConnectionStringSettings connectionSettings ;
               
               
               ConfigurationManager.RefreshSection ( "connectionStrings" ) ;
               connectionSettings = ConfigurationManager.ConnectionStrings  [ section.ConnectionName ] ;
               
               if ( null != connectionSettings ) 
               {
                  return true ;
               }
            }
            
            return false ;
         }
         
         public static Icon GetApplicationIcon()
         {
            try
            {
               string iconPath ;
               
               
               iconPath = Path.Combine ( Application.StartupPath, "app.ico" ) ;
               
               if ( File.Exists ( iconPath ) )
               {
                  return new Icon ( iconPath ) ;
               }
               else
               {
                  return Leadtools.Demos.Workstation.Properties.Resources.MedAddon ;
               }
            }
            catch ( Exception )
            {
               return Leadtools.Demos.Workstation.Properties.Resources.MedAddon ;
            }
         }
         
         public static string GetAssociationReasonMessage ( DicomAssociateRejectReasonType reason )
         {
            if ( reason == DicomAssociateRejectReasonType.Calling ) 
            {
               return "Calling AE Title Not Recognized" ;
            }
            
            if ( reason == DicomAssociateRejectReasonType.Called ) 
            {
               return "Called AE Title Not Recognized" ;
            }
            
            return string.Empty ;
         }
      }
}
