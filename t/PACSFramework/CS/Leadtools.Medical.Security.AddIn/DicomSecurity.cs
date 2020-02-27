// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.DicomDemos;
using Leadtools.Medical.Winforms.SecurityOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadtools.Medical.Security.AddIn
{
   public class DicomSecurity : IDicomSecurity, IDicomSecurityCiphers
   {
      public DicomSecurity()
      {
      }

      public string CertificationAuthoritiesFileName
      {
         get
         {
            return ServerConfig._dicomSecurityOptions.CertificationAuthoritiesFileName;
         }
      }

      public int MaximumVerificationDepth
      {
         get
         {
            return ServerConfig._dicomSecurityOptions.MaximumVerificationDepth;
         }
      }

      public DicomOpenSslOptionsFlags Options
      {
         get
         {
            return ServerConfig._dicomSecurityOptions.Options;
         }
      }

      public DicomOpenSslVerificationFlags VerificationFlags
      {
         get
         {
            return ServerConfig._dicomSecurityOptions.VerificationFlags;
         }
      }

      public string CertificateFileName
      {
         get
         {
            return ServerConfig._dicomSecurityOptions.CertificateFileName;
         }
      }

      public DicomTlsCertificateType CertificateType
      {
         get
         {
            return ServerConfig._dicomSecurityOptions.CertificateType;
         }
      }

      public string KeyFileName
      {
         get
         {
            return ServerConfig._dicomSecurityOptions.KeyFileName;
         }
      }

      public string Password
      {
         get
         {
            return ServerConfig._dicomSecurityOptions.Password;
         }
      }

      public DicomSslMethodType SslMethodType
      {
         get
         {
            return ServerConfig._dicomSecurityOptions.SslMethodType;
         }
      }

      public List<DicomTlsCipherSuiteType> CipherSuiteList
      {
         get
         {
            List<DicomTlsCipherSuiteType> cipherSuiteList = new List<DicomTlsCipherSuiteType>();
            foreach(CipherSuiteItem cipherSuiteItem in ServerConfig._dicomSecurityOptions.CipherSuites.ItemList)
            {
               if (cipherSuiteItem.IsChecked)
               {
                  cipherSuiteList.Add(cipherSuiteItem.Cipher);
               }
            }
            return cipherSuiteList;
         }
      }
   }
}
