// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using Leadtools;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Common;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace Leadtools.AddIn.Security
{
   [Serializable]
   public class DicomSecurity : IDicomSecurity, IModule
   {
      static SecurityOptions _securityOptions = new SecurityOptions();

      #region IDicomSecurity Members
      public string CertificationAuthoritiesFileName
      {
         get
         {
            return _securityOptions.CAFileName;
         }
      }

      public int MaximumVerificationDepth
      {
         get
         {
            return _securityOptions.MaximumVerificationDepth;
         }
      }
      public DicomOpenSslOptionsFlags Options
      {
         get
         {
            return _securityOptions.OptionsFlags;
         }
      }

      public DicomOpenSslVerificationFlags VerificationFlags
      {
         get
         {
            return _securityOptions.VerificationFlags;
         }
      }

      public string CertificateFileName
      {
         get
         {
            return _securityOptions.CertificateFileName;
         }
      }

      public DicomTlsCertificateType CertificateType
      {
         get
         {
            return _securityOptions.CertificateType;
         }
      }

      public string KeyFileName
      {
         get
         {
            return _securityOptions.KeyFileName;
         }
      }

      public string Password
      {
         get
         {
            return _securityOptions.KeyFilePassword;
         }
      }

      public DicomSslMethodType SslMethodType
      {
         get
         {
            return _securityOptions.MethodType;
         }
      }

      #endregion     


      #region IModule Members
      private static string DatasetDir = string.Empty;

      public void AddServices()
      {
      }

      public SecurityOptions SecurityOptions
      {
         get
         {
            return _securityOptions;
         }
      }

      public static string GetOptionsFile(string ServerDirectory)
      {
         string optionsFile = ServerDirectory;
         if (!optionsFile.EndsWith(@"\"))
            optionsFile += @"\";
         optionsFile += "DicomSecurity.xml";

         // Uncomment to show where options file gets loaded
         //string source = "Leadtools.AddIn.Security";
         //EventLog.WriteEntry(source, optionsFile, EventLogEntryType.Error, 7);

         return optionsFile;
      }


      public void Load(string ServerDirectory, string DisplayName)
      {
          InitializeSecurity(ServerDirectory, DisplayName);
      }

       public static void InitializeSecurity(string ServerDirectory, string DisplayName)
      {
          CheckServerDirectory(ServerDirectory, DisplayName);
          string optionsFile = GetOptionsFile(ServerDirectory);

          try
          {
              if (File.Exists(optionsFile))
                _securityOptions = AddInUtils.DeserializeFile<SecurityOptions>(optionsFile);

          }
          catch
          {
              _securityOptions = new SecurityOptions();
          }

          // If any of the options have changed, then rewrite
          // This code gets executed the first time the security addin is loaded
          // This is used to locate the certificate files (CA.pem, server.pem) and prepend the directory
          // If this happens, then we change the password to "test"
          // After the security options have loaded the first time, the code below never executes
          if (_securityOptions.FixFileNames(ServerDirectory))
          {
             try
             {
                _securityOptions.KeyFilePassword = "test";
                AddInUtils.Serialize<SecurityOptions>(_securityOptions, optionsFile);
             }
             catch (Exception)
             {
             }
          }
      }

      /// <summary>
      /// Checks the server directory.  This is the directory where service addins will be added.
      /// </summary>
      /// <param name="ServerDirectory">The server directory.</param>
      /// <param name="DisplayName">The display name.</param>
      private static void CheckServerDirectory(string ServerDirectory, string DisplayName)
      {
         if (!Directory.Exists(ServerDirectory))
         {
            Directory.CreateDirectory(ServerDirectory);
         }

         //
         // Create Server Log directory
         //
         if (!Directory.Exists(ServerDirectory + @"\Log\"))
         {
            Directory.CreateDirectory(ServerDirectory + @"\Log\");
         }

         //
         // Create Server Dataset directory
         //
         DatasetDir = ServerDirectory + @"\Log\Datasets\";
         if (!Directory.Exists(DatasetDir))
         {
            Directory.CreateDirectory(DatasetDir);
         }
      }
      #endregion     
  }
}
