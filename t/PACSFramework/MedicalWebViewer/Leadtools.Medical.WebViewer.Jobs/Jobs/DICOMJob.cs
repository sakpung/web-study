// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;

using System.Text;
using Leadtools;
using Leadtools.Dicom;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom.Scu.Common;
using System.Net;
using System.Runtime.Serialization;

namespace Leadtools.Medical.WebViewer.Jobs
{
   [Serializable]
   public class DICOMJobSettings
   {
      public DICOMJobSettings()
      {
         ServerTimeout = 30;
         UseTls = false;
         ClientCertificate = "";
         ClientPrivateKey = "";
      }

      public string ServerAE { get; set; }
      private string _ServerIP = "";
      public string ServerIP 
      {
         get { return _ServerIP; }
         set 
         {
            _ServerIP = value;
            if (IsLocalHost(_ServerIP))
            {
               _ServerIP = localhost;
            }
         }
      }
      public int ServerPort { get; set; }
      public int ServerTimeout { get; set; }
      public string ClientAE { get; set; }
      public string MoveToClientAE { get; set; }
      private string _ClientIP = "";
      public string ClientIP 
      {
         get { return _ClientIP; }
         set
         {
            _ClientIP = value;
            if (IsLocalHost(_ClientIP))
            {
               _ClientIP = localhost;
            }
         }
      }
      public int ClientPort { get; set; }
      public bool UseTls { get; set; }
      public string ClientCertificate{ get; set; }
      public string ClientPrivateKey { get; set; }

      bool IsLocalHost(string sIP)
      {
         if (sIP == "127.0.0.1" || sIP == "localhost")
         {
            return true;
         }
         return false;
      }
      string localhost
      {
         get
         {
            string sHostName = Dns.GetHostName();            
            IPHostEntry ipE = Dns.GetHostEntry(sHostName);
            IPAddress[] IpA = ipE.AddressList;
            if (IpA.Length > 0)
            {
               return IpA[0].ToString();
            }
            else
            {
               return "127.0.0.1";
            }
         }
      }
   }

   [Serializable]
   public class DICOMJob : Job
   {
      protected DICOMJob()
      {
         Settings = null;
         DicomEngine.Startup();
         DicomNet.Startup();
      }
      public DICOMJob(DICOMJobSettings js)
      {
         Settings = js;
         DicomEngine.Startup();
         DicomNet.Startup();
      }
      
      public DICOMJobSettings Settings
      {
         get;
         set;
      }

      public override void Dispose(bool bUnmanaged) 
      {
         base.Dispose();

         DicomNet.Shutdown();
         DicomEngine.Shutdown();
      }

      public string ServerAE { get{return Settings.ServerAE; } }
      public string ServerIP { get { return Settings.ServerIP; } }
      public int ServerPort { get { return Settings.ServerPort; } }
      public int ServerTimeout { get { return Settings.ServerTimeout; } }
      public string ClientAE { get { return Settings.ClientAE; } }
      public string MoveToClientAE { get { return Settings.MoveToClientAE; } }
      public string ClientIP { get { return Settings.ClientIP; } }
      public int ClientPort { get { return Settings.ClientPort; } }
      public bool UseTls { get { return Settings.UseTls; } }
      public string ClientCertificate { get { return Settings.ClientCertificate; } }
      public string ClientPrivateKey { get { return Settings.ClientPrivateKey; } }

      public const string ConfigurationImplementationClass = "1.2.840.114257.1123456";
      public const string ConfigurationImplementationVersionName = "1";
      public const string ConfigurationProtocolversion = "1";

      public DicomScp CreateServerObject()
      {
         DicomScp _server = new DicomScp();

         _server.AETitle = ServerAE;
         _server.Port = ServerPort;
         _server.PeerAddress = IPAddress.Parse(ServerIP);
         _server.Timeout = ServerTimeout;

         return _server;
      }
   }
}
