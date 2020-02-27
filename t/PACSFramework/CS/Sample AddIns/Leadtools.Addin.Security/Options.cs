// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Design;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom;
using System.ComponentModel;

using System.Windows.Forms;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.IO;


namespace Leadtools.AddIn.Security
{
   [Serializable]
   public class SecurityOptions
   {
      private string _CAFileName;
      private string _CertificateFileName;
      private DicomTlsCertificateType _CertificateType;
      private string _KeyFileName;
      private string _KeyFilePassword;
      private int _MaximumVerificationDepth;
      private DicomSslMethodType _MethodType;
      private DicomOpenSslOptionsFlags _OptionsFlags;
      private DicomOpenSslVerificationFlags _VerificationFlags;

      [Category("Certificates")]
      [DisplayName("Certificate Authority File Name")]
      [Description("File containing CA certificates in PEM format. More than one CA certificate may be present in the file. Can be left empty.")]
      [Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
      public string CAFileName
      {
         get { return _CAFileName; }
         set { _CAFileName = value; }
      }

      [Category("Certificates")]
      [DisplayName("Certificate File Name")]
      [Description("Certificate for the server")]
      [Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
      public string CertificateFileName
      {
         get { return _CertificateFileName; }
         set { _CertificateFileName = value; }
      }

      [Category("Certificates")]
      [DisplayName("Certificate Type")]
      [Description("Identifies the type of the certificate: PEM (text) or  Ans1 (binary)")]
      public DicomTlsCertificateType CertificateType
      {
         get { return _CertificateType; }
         set { _CertificateType = value; }
      }

      [Category("Certificates")]
      [DisplayName("Key File Name")]
      [Description("Contins the private key.  This can be the same as the Certificate File Name")]
      [Editor(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
      public string KeyFileName
      {
         get { return _KeyFileName; }
         set { _KeyFileName = value; }
      }

      [Category("Certificates")]
      [DisplayName("Key File Password")]
      [Description("Password of the private key, if the private key is password protected.")]
      public string KeyFilePassword
      {
         get { return _KeyFilePassword; }
         set { _KeyFilePassword = value; }
      }

      [Category("Verification")]
      [DisplayName("Maximum Verification Depth")]
      [Description("Sets the maximum depth of the certificate chain to be verified.")]
      public int MaximumVerificationDepth
      {
         get { return _MaximumVerificationDepth; }
         set { _MaximumVerificationDepth = value; }
      }

      [Category("Verification")]
      [DisplayName("SSL Method Type")]
      [Description("Identifies which SSL method type is to be used for security verification")]
      public DicomSslMethodType MethodType
      {
         get { return _MethodType; }
         set { _MethodType = value; }
      }

      [Category("Verification")]
      [DisplayName("Verification Options")]
      [Description("Additional options for the verification mode. Values may be combined")]
      [Editor(typeof(FlaggedEnumEditor), typeof(UITypeEditor)), WrappedEnum(typeof(DicomOpenSslVerificationFlags))]
      public DicomOpenSslOptionsFlags OptionsFlags
      {
         get { return _OptionsFlags; }
         set { _OptionsFlags = value; }
      }

      [Category("Verification")]
      [DisplayName("Verification Flags ")]
      [Description("Identifies the verification mode to be used. Values may be combined.")]
      [Editor(typeof(FlaggedEnumEditor), typeof(UITypeEditor)), WrappedEnum(typeof(DicomOpenSslVerificationFlags))]
      public DicomOpenSslVerificationFlags VerificationFlags
      {
         get { return _VerificationFlags; }
         set { _VerificationFlags = value; }
      }

      public SecurityOptions()
      {
         CAFileName = "CA.pem";
         CertificateFileName = "server.pem";
         CertificateType = DicomTlsCertificateType.Pem;
         KeyFileName = "server.pem";
         KeyFilePassword = string.Empty;
         MaximumVerificationDepth = 9;
         MethodType = DicomSslMethodType.SslV23;
         OptionsFlags = DicomOpenSslOptionsFlags.AllBugWorkarounds | DicomOpenSslOptionsFlags.NoSslV2 | DicomOpenSslOptionsFlags.NoSslV3;
         VerificationFlags = DicomOpenSslVerificationFlags.None;
      }

      private string FixFileName(string csDir, string csFullFileName)
      {
         string csInFile;
         string csOutFile = csFullFileName;
         string csInDir;
         if (csFullFileName.Length > 0)
         {
            csInFile = Path.GetFileName(csFullFileName);
            csInDir = Path.GetDirectoryName(csFullFileName);

            if ((csInFile.Length > 0) && (csInDir.Length == 0))
            {
               if (csDir.EndsWith("\\"))
                  csDir = csDir.Substring(0, csDir.Length - 1);

               int nLastSeparator = csDir.LastIndexOf('\\');

               // +1 to include the last separator '\\'
               string csUpDir = csDir.Substring(0, nLastSeparator+1);
               csOutFile = csUpDir + csInFile;
            }
         }
         return csOutFile;
      }


      // returns true if any of the file names are changed
      public bool FixFileNames(string csDir)
      {
         bool bChange = false;
         string csTemp = string.Empty;

         csTemp = FixFileName(csDir,CAFileName);
         if (string.Compare(csTemp, CAFileName, true) != 0)
         {
            bChange = true;
            CAFileName = csTemp;
         }

         csTemp = FixFileName(csDir,CertificateFileName);
         if (string.Compare(csTemp, CertificateFileName, true) != 0)
         {
            bChange = true;
            CertificateFileName = csTemp;
         }

         csTemp = FixFileName(csDir,KeyFileName);
         if (string.Compare(csTemp, KeyFileName, true) != 0)
         {
            bChange = true;
            KeyFileName = csTemp;
         }
         return bChange;
      }
   }
}
