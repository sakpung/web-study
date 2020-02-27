// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.DicomDemos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Leadtools.Medical.Winforms.SecurityOptions
{
   [Serializable]
   [XmlRoot(Namespace = "")]
   public class DicomSecurityOptions : IDicomSecurity
   {

      public DicomSecurityOptions()
      {

         CertificationAuthoritiesFileName = DicomDemoSettingsManager.GetCertificateAuthorityFullPath();
         CertificateFileName = DicomDemoSettingsManager.GetClientCertificateFullPath();
         KeyFileName = CertificateFileName;
         Password = DicomDemoSettingsManager.GetClientCertificatePassword();
         CertificateType = DicomTlsCertificateType.Pem;
         MaximumVerificationDepth = 9;
         VerificationFlags = DicomOpenSslVerificationFlags.All;
         Options = DicomOpenSslOptionsFlags.AllBugWorkarounds;
         SslMethodType = DicomSslMethodType.SslV23;

         // IDicomSecurity2
         CipherSuites = new CipherSuiteItems();
         CipherSuites.Default();
      }

      public static bool IsEqual(DicomSecurityOptions options1, DicomSecurityOptions options2)
      {
         if (options1 == null)
         {
            return (options2 == null);
         }

         if (options2 == null)
         {
            // Options1 is not null, so return false
            return false;
         }

         bool isEqual = true;

         // CertificationAuthoritiesFileName
         if (isEqual)
         {
            isEqual = (string.Compare(options1.CertificationAuthoritiesFileName, options2.CertificationAuthoritiesFileName, true) == 0); 
         }

         // CertificateFileName
         if (isEqual)
         {
            isEqual = (string.Compare(options1.CertificateFileName, options2.CertificateFileName, true) == 0);
         }

         // KeyFileName
         if (isEqual)
         {
            isEqual = (string.Compare(options1.KeyFileName, options2.KeyFileName, true) == 0);
         }

         // Password 
         if (isEqual)
         {
            isEqual = (string.Compare(options1.Password, options2.Password, false) == 0);
         }

         // CertificateType 
         if (isEqual)
         {
            isEqual = (options1.CertificateType == options2.CertificateType);
         }

         // MaximumVerificationDepth  
         if (isEqual)
         {
            isEqual = (options1.MaximumVerificationDepth == options2.MaximumVerificationDepth);
         }

         // VerificationFlags   
         if (isEqual)
         {
            isEqual = (options1.VerificationFlags == options2.VerificationFlags);
         }

         // Options    
         if (isEqual)
         {
            isEqual = (options1.Options == options2.Options);
         }

         // SslMethodType     
         if (isEqual)
         {
            isEqual = (options1.SslMethodType == options2.SslMethodType);
         }

         // ShowPassword
         // Skip this one

         //
         if (isEqual)
         {
            isEqual = (options1.CipherSuites.IsEqual(options2.CipherSuites));
         }

         return isEqual;
      }

      //public DicomSecurityOptions Clone()
      //{
      //   DicomSecurityOptions o = new DicomSecurityOptions();
      //   o.CertificationAuthoritiesFileName = CertificationAuthoritiesFileName;
      //   o.CertificateFileName = CertificationAuthoritiesFileName;
      //   o.KeyFileName = KeyFileName;
      //   o.Password = Password;
      //   o.CertificateType = CertificateType;
      //   o.MaximumVerificationDepth = MaximumVerificationDepth;
      //   o.VerificationFlags = VerificationFlags;
      //   o.Options = Options;
      //   o.SslMethodType = SslMethodType;

      //   return o;
      //}

      public string CertificationAuthoritiesFileName
      {
         get;
         set;
      }

      public string CertificateFileName
      {
         get;
         set;
      }

      public string KeyFileName
      {
         get;
         set;
      }

      public string Password
      {
         get;
         set;
      }

      public DicomTlsCertificateType CertificateType
      {
         get;
         set;
      }

      public int MaximumVerificationDepth
      {
         get;
         set;
      }

      public DicomOpenSslOptionsFlags Options
      {
         get;
         set;
      }

      public DicomOpenSslVerificationFlags VerificationFlags
      {
         get;
         set;
      }

      public DicomSslMethodType SslMethodType
      {
         get;
         set;
      }

      // IDicomSecurity2
      public bool ShowPassword
      {
         get;
         set;
      }

      public CipherSuiteItems CipherSuites
      {
         get;
         set;
      }

      public string SerializeToXml()
      {
         try
         {
            var xmlserializer = new XmlSerializer(typeof(DicomSecurityOptions));
            var stringWriter = new StringWriter();
            using (var writer = XmlWriter.Create(stringWriter))
            {
               xmlserializer.Serialize(writer, this);
               return stringWriter.ToString();
            }
         }
         catch (Exception ex)
         {
            throw new Exception("An error occurred", ex);
         }
      }

      private static MemoryStream GenerateStreamFromString(string value)
      {
         return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
      }

      public static DicomSecurityOptions DeserializeFromXml(string xmlString)
      {
         DicomSecurityOptions options = null;

         using (var stream = DicomSecurityOptions.GenerateStreamFromString(xmlString))
         {
            var serializer = new XmlSerializer(typeof(DicomSecurityOptions));
            options = serializer.Deserialize(stream) as DicomSecurityOptions;
         }
         return options;
      }
   }
}
