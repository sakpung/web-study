// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Threading;
using Leadtools.Dicom;
using Leadtools;
using System.Globalization;
using Leadtools.Demos;
using DicomDemo.Authentication;
using System.Diagnostics;
using System.IO;
using DicomDemo.Utils;
using Leadtools.DicomDemos;

namespace DicomDemo
{
    partial class Program
    {                
        private static CultureInfo _Culture = System.Globalization.CultureInfo.CurrentCulture;

        public static CultureInfo Culture
        {
           get
           {
              return _Culture;
           }
        }

        public static Dictionary<string, string> OtherPID = new Dictionary<string, string>();

        public const string PatientUpdater = "PatientUpdater";
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
           if (ApplicationUtils.IsOnlyProcess("Patient Updater") || args.Length > 0)
           {
              if (MustRunAsAdmin(args))
              {
                 return;
              }

#if (LEADTOOLS_V20_OR_LATER)
            if (DemosGlobal.IsDotNet45OrLaterInstalled() == false)
            {
               MessageBox.Show("To run this application, you must first install Microsoft .NET Framework 4.5 or later.",
                  "Microsoft .NET Framework 4.5 or later Required",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Exclamation);
               return;
            }
#endif

            string globalPacsConfigPath = DicomDemoSettingsManager.GlobalPacsConfigFullFileName;
              if (File.Exists(globalPacsConfigPath))
              {
                 try
                 {
                    if (false == UpgradeConfigFiles(args))
                       return;
                 }
                 catch (System.UnauthorizedAccessException ex)
                 {
                    string msg = string.Format("Upgrade Failed!\n\n{0}", ex.Message);
                    MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                 }
                 catch (Exception ex)
                 {
                    string msg = string.Format("Upgrade Failed!\n\n{0}", ex.Message);
                    MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                 }
              }

              if (!InitializeLicense())
              {
                 return;
              }

#if LEADTOOLS_V175_OR_LATER
              if (RasterSupport.IsLocked(RasterSupportType.DicomCommunication))
              {
                 MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning");
                 return;
              }
#else
           if (RasterSupport.IsLocked(RasterSupportType.MedicalNet))
           {
              MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.MedicalNet.ToString()), "Warning");
              return;
           }
#endif
              Leadtools.DicomDemos.Utils.EngineStartup();
              Leadtools.DicomDemos.Utils.DicomNetStartup();

              Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
              Application.EnableVisualStyles();
              Application.SetCompatibleTextRenderingDefault(false);

              try
              {
                 if (Login())
                 {
                    Application.Run(CreateMainForm());
                 }
              }
              catch (Exception)
              {
              }
              finally
              {
               DicomShutdown();
              }
           }
        }
        
        private static void DicomShutdown()
        {
           try
           {
              DicomNet.Shutdown();
              DicomEngine.Shutdown();
           }
           catch (Exception)
           {
           }
        }

        private static string _UserName;

        private static void dlgLogin_AuthenticateUser(object sender, AuthenticateUserEventArgs e)
        {
           //
           // Once user is logged in we need to check to see if the user password
           // has expired.
           //
           string errorString = string.Empty;
           _UserName = e.Username;
           UserManager.AuthenticateResult  result = UserManager.Authenticate(e.Username, e.Password, out errorString);
           if (result == UserManager.AuthenticateResult.Success)
           {
              if (UserManager.IsPasswordExpired(e.Username))
              {
                 PasswordDialog dlgPassword = new PasswordDialog();

                 dlgPassword.Text = "Reset Expired Password";
                 dlgPassword.ValidatePassword += new EventHandler<ValidatePasswordEventArgs>(dlgPassword_ValidatePassword);
                 if (dlgPassword.ShowDialog(sender as Form) == DialogResult.OK)
                 {
                    UserManager.ResetPassword(e.Username, dlgPassword.Password);
                 }
                 else
                    e.Cancel = true;
              }
           }
           else if (result == UserManager.AuthenticateResult.InvalidUser)
           {
              Messager.ShowError(sender as Form, "Invalid user name or password.");
              e.InvalidCredentials = true;
           }
           else if (result == UserManager.AuthenticateResult.ErrorInvalidDatabase)
           {
              Messager.ShowError(sender as Form, "Invalid Database.\n\nThe configured database does not contain a 'Users' table.  Please run "+ Program.PacsDatabaseConfigurationDemoNames[0] + " to connect to the correct database.");
              e.InvalidCredentials = false;
              e.Cancel = true;
           }
           else 
           {
              Messager.ShowError(sender as Form, errorString);
              e.InvalidCredentials = false;
              e.Cancel = true;
           }
        }

        static void dlgPassword_ValidatePassword(object sender, ValidatePasswordEventArgs e)
        {
           string message = string.Empty;

           e.Valid = true;
           if (!UserManager.ValidatePassword(e.Password, e.ConfirmPassword, out message))
           {
              e.Valid = false;
              Messager.ShowError(sender as Form, message);
           }
           else if (UserManager.IsPreviousPassword(_UserName, e.Password.ToSecureString()))
           {
              e.Valid = false;
              Messager.ShowError(sender as Form, "The password chosen has already been used.  Please choose a new password.");
           }
        }

        public static string DateString(DateTime? date)
        {
           return date.HasValue ? date.Value.ToString(Culture.DateTimeFormat.ShortDatePattern) : string.Empty;
        }

        public static void RunDatabaseConfigurationDemo()
        {
           string dbManagerFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), PacsDatabaseConfigurationDemoNames[0]);

           if (!File.Exists(dbManagerFileName)&& PacsDatabaseConfigurationDemoNames.Length > 1)
           {
              dbManagerFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), PacsDatabaseConfigurationDemoNames[1]);
           }

           if (File.Exists(dbManagerFileName))
           {
              Process dbConfigProcess = new Process();
              dbConfigProcess.StartInfo.Verb = "runas";
              dbConfigProcess.StartInfo.FileName = dbManagerFileName;

              dbConfigProcess.Start();
              dbConfigProcess.WaitForExit();
           }
           else
           {
              Messager.ShowError(null, "Could not find the " + PacsDatabaseConfigurationDemoNames[0] + " wizard");
           }
           // return 0 ;
        }
    }
}
