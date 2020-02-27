// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Leadtools.Logging;
using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;
using Leadtools.Demos.StorageServer.UI;
using Leadtools.Demos.StorageServer.UI.Authentication;
using System.Diagnostics;
using Leadtools.Medical.Winforms;
using Leadtools.DicomDemos;
using System.Threading;
using System.IO;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer.Configuration;
using Leadtools.Demos.StorageServer.DataTypes;
using System.Drawing;
using System.Reflection;
#if LEADTOOLS_V19_OR_LATER
using Leadtools.Dicom.Scp;
using System.Security;
using Leadtools.Dicom.AddIn;
using Leadtools.Medical.UserManagementDataAccessLayer.DataAccessAgent.Database;
#endif

namespace Leadtools.Demos.StorageServer
{
   static partial class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         // Still want to let this application run with an expired license (as this is an enterprise level application), but in very a limited mode
         // For example, the user should be able to view the log
         //Support.SetLicense();
         //if (Support.KernelExpired)
         //   return;
         InitializeLicense();

         if ( ProcessChecker.IsOnlyProcess ( Shell.storageServerName) )
         {
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PacsProduct.ProductName = DicomDemoSettingsManager.ProductNameStorageServer;
            
            bool ok ;
            
            string exeName = Path.GetFileNameWithoutExtension ( Application.ExecutablePath ) ;
            
            if ( Demos.DemosGlobal.Is64Process ( ) )
            {
               exeName += "64" ;
            }
            else
            {
               exeName += "32" ;
            }
            
            Mutex m = new Mutex ( true, exeName, out ok ) ;

#if !TUTORIAL_CUSTOM_DATABASE && !LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE
            CheckPacsConfigDemo();
#endif
            
            string globalPacsConfigPath = DicomDemoSettingsManager.GlobalPacsConfigFullFileName;
            if (File.Exists(globalPacsConfigPath))
            {
               try
               {
                  if (false == UpgradeConfigFiles())
                     return;
               }
               catch (Exception ex)
               {
                  string msg = string.Format("Upgrade Failed!\n\n{0}", ex.Message);
                  MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  return;
               }
            }
            
            try
            {
               string message = string.Empty;
               string[] productsToCheck = new string[] { DicomDemoSettingsManager.ProductNameStorageServer };
               bool dbConfigured = GlobalPacsUpdater.IsDbComponentsConfigured(productsToCheck, out message);

#if TUTORIAL_CUSTOM_DATABASE
               // When manually configuring the storage server to use a different database schema, the helper funciton 'IsDbComponentsConfigured'
               // will incorrectly detect that the database has not been configured.  In this case, set 'dbConfigured' to true.
               // For more details, see the "Changing the LEAD Medical Storage Server to use a different database schema" tutorial.
               dbConfigured = true;
#endif

               if (!dbConfigured &&
                    !RequestUserToConfigureDbSucess(message))
               {
                  return;
               }
               

#if !TUTORIAL_CUSTOM_DATABASE
               if ( !GlobalPacsUpdater.IsProductDatabaseUpTodate ( DicomDemoSettingsManager.ProductNameStorageServer ) &&
                    !RequestUserToUpgradeDbSucess ( ) )
               {
                  return ;
               }
#endif 
               
               IOptionsDataAccessAgent optionsAgent;
               System.Configuration.Configuration configuration = DicomDemoSettingsManager.GetGlobalPacsConfiguration();

               if (!ok)
               {
                  return ;
               }

               optionsAgent = DataAccessFactory.GetInstance(new OptionsDataAccessConfigurationView(configuration, DicomDemoSettingsManager.ProductNameStorageServer, null)).CreateDataAccessAgent<IOptionsDataAccessAgent>();
               DataAccessServices.RegisterDataAccessService<IOptionsDataAccessAgent>(optionsAgent);

               if ( Login (string.Empty,false ) )
               {
//#if !DEBUG
                  SplashForm.ShowSplash();
// #endif
                  Shell shell = new Shell ( ) ;

                  shell.Run ( ) ;
               }
            }
            catch ( Exception ex ) 
            {
               MessageBox.Show ( "The program failed to run with the following error:\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
#if LEADTOOLS_V19_OR_LATER
                ProducerConsumerQueue.Instance.Shutdown(true);
#endif
               m.Close ( ) ;
            }
         }
      }

      private static bool RequestUserToConfigureDbSucess(string missingDbComponents)
      {
         string message;
         DialogResult result;
         string Caption = "Warning";

         string pacsDatabaseConfigDemoFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), PacsDatabaseConfigurationDemoNames[0]);

         if (!File.Exists(pacsDatabaseConfigDemoFileName) && PacsDatabaseConfigurationDemoNames.Length > 1)
         {
            pacsDatabaseConfigDemoFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), PacsDatabaseConfigurationDemoNames[1]);
         }

         message = "The following databases are not configured:\n\n{0}\nRun the " +
                   PacsDatabaseConfigurationDemoNames[0] + " to configure the missing databases.\n\n" +
                   "Do you want to run the " + PacsDatabaseConfigurationDemoNames[0] + " wizard now?";

         message = string.Format(message, missingDbComponents);

         result = MessageBox.Show(message,
                                    Caption,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning);

         if (DialogResult.Yes == result)
         {

            if (File.Exists(pacsDatabaseConfigDemoFileName))
            {
               Process dbConfigProcess;


               dbConfigProcess = new Process();
               dbConfigProcess.StartInfo.FileName = pacsDatabaseConfigDemoFileName;

               dbConfigProcess.Start();

               dbConfigProcess.WaitForExit();

               string[] productsToCheck = new string[] { DicomDemoSettingsManager.ProductNameStorageServer };

               bool isDbConfigured = GlobalPacsUpdater.IsDbComponentsConfigured(productsToCheck, out missingDbComponents);

               if (!isDbConfigured)
               {
                  MessageBox.Show("Database is not configured.",
                                    Caption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);


                  return false;

               }
            }
            else
            {
               MessageBox.Show("Could not find the " + PacsDatabaseConfigurationDemoNames[0] + " wizard",
                                 Caption,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);

               return false;
            }
         }
         else
         {
            return false;
         }
         return true;
      }

      private static bool RequestUserToUpgradeDbSucess()
      {
         string message;
         DialogResult result;
         string Caption = "Upgrade Notice";

         message = "The Storage Server database needs to be upgraded.\n\n" + 
                   "Do you want to upgrade the database now?";

         result = MessageBox.Show(message,
                                    Caption,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning);

         if (DialogResult.Yes == result)
         {
            GlobalPacsUpdater.UpgradeProductDatabase ( DicomDemoSettingsManager.ProductNameStorageServer ) ;
            
            if ( GlobalPacsUpdater.IsProductDatabaseUpTodate(DicomDemoSettingsManager.ProductNameStorageServer) )
            {
               MessageBox.Show("Database upgraded successfully",
                                Caption,
                                MessageBoxButtons.OK,
                                 MessageBoxIcon.Information);
                              
               return true ;
            }
         }

         return false;
         
      }

      private static string _UserName;

#if LEADTOOLS_V19_OR_LATER
      private static bool AuthenticateCardUser(object sender, AuthenticateUserEventArgs e)
      {
         if (e.LoginType != LoginType.SmartcardPin)
            return false;

         string error = string.Empty;
         string warning = string.Empty;
         string information = string.Empty;
         int pinCounter;
         string ediNumber;

         AuthenticateCardUserResult isValid = UserManager.AuthenticateCardUser(e.CardReaderIndex, e.Pin, e.CardReaderValidatePinOnly, out ediNumber, out pinCounter);

         switch (isValid)
         {
            case AuthenticateCardUserResult.Success:
               e.InvalidCredentials = false;
               e.EdiNumber = ediNumber;
               break;

            case AuthenticateCardUserResult.UnknownError:
               error = "Card user failed to validate -- Unknown Error";
               e.InvalidCredentials = true;
               break;

            case AuthenticateCardUserResult.InvalidUserName:
               warning = "Card user not recognized";
               e.InvalidCredentials = true;
               break;

            case AuthenticateCardUserResult.InvalidPin:
               {
                  if (pinCounter > 1)
                  {
                     information = string.Format("Invalid PIN number.\n\rThere are {0} remaining tries until the card is locked out.", pinCounter);
                  }
                  else if (pinCounter == 1)
                  {
                     warning = string.Format("Invalid PIN number.\n\rThere is {0} remaining try until the card is locked out.", pinCounter);
                  }
                  else
                  {
                     warning = string.Format("The card is locked out.");
                  }
                  e.InvalidCredentials = true;
               }
               break;
         }

         if (e.InvalidCredentials)
         {
            if (!string.IsNullOrEmpty(error))
            {
               Messager.Caption = "Error";
               Messager.ShowError(sender as Form, error);
            }
            else if (!string.IsNullOrEmpty(warning))
            {
               Messager.Caption = "Warning";
               Messager.ShowWarning(sender as Form, warning);
            }
            else if (!string.IsNullOrEmpty(information))
            {
               Messager.Caption = "Information";
               Messager.ShowInformation(sender as Form, information);
            }
         }
         return true;
      }
#endif // #if LEADTOOLS_V19_OR_LATER

      public static void dlgLogin_AuthenticateUser(object sender, AuthenticateUserEventArgs e)
      {
#if LEADTOOLS_V19_OR_LATER
         if (e.LoginType == LoginType.SmartcardPin)
         {
            AuthenticateCardUser(sender, e);
            return;
         }
#endif
         //
         // Once user is logged in we need to check to see if the user password
         // has expired.
         //
         _UserName = e.Username;
         try
         {
            if (UserManager.Authenticate(e.Username, e.Password))
            {
               if (UserManager.IsPasswordExpired(e.Username))
               {
                  StorageServer.UI.PasswordDialog dlgPassword = new StorageServer.UI.PasswordDialog();

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
            else
            {
               Messager.ShowError(sender as Form, "Invalid user name or password.");
               e.InvalidCredentials = true;
            }
         }
         catch (Exception exception)
         {
            Messager.ShowError(sender as Form, exception);
            e.InvalidCredentials = true;
         }

         if (!e.Cancel && !e.InvalidCredentials)
         {
            IOptionsDataAccessAgent optionsAgent = DataAccessServices.GetDataAccessService<IOptionsDataAccessAgent>();

            optionsAgent.Set<string>("LastUser", e.Username);
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

      public class WindowWrapper : System.Windows.Forms.IWin32Window
      {
         public WindowWrapper(IntPtr handle)
         {
            _hwnd = handle;
         }

         public IntPtr Handle
         {
            get { return _hwnd; }
         }

         private IntPtr _hwnd;
      }
      
      public static Icon GetAppIcon()
      {
         Icon icon;
         try
         {
            icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
         }
         catch
         {
            icon = null;
         }
         return icon;
      }
   }
}
