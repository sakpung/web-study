// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.IO;
using Leadtools.Dicom;
using Leadtools.Wia;
using Leadtools.Demos;
using Leadtools.DicomDemos;
using PrintToPACSDemo;
using System.Windows.Forms;

namespace PrintToPACS.Utilities
{

   [Serializable()]

   public class MyServer : ICloneable
   {
      public string _sAE;
      public string _sIP;
      public int _port;
      public int _timeout;
      public bool _useTls;

      public MyServer()
      {
         _sAE = string.Empty;
         _sIP = string.Empty;
         _port = 0;
         _timeout = 0;
         _useTls = false;
      }

      public MyServer(DicomAE dicomAE)
      {
         _sAE = dicomAE.AE;
         _sIP = dicomAE.IPAddress;
         _port = dicomAE.Port;
         _timeout = dicomAE.Timeout;
         _useTls = dicomAE.UseTls;
      }

      public MyServer(string sAE, string sIP, int port, int timeout, bool useTls)
      {
         _sAE = sAE;
         _sIP = sIP;
         _port = port;
         _timeout = timeout;
         _useTls = useTls;
      }

      public override string ToString()
      {
         string strText = _sAE;
         return strText;
      }

      #region ICloneable Members

      public object Clone()
      {
         MyServer server = new MyServer();
         server._port = _port;
         server._sAE = _sAE;
         server._sIP = _sIP;
         server._timeout = _timeout;
         server._useTls = _useTls;
         return server;
      }

      #endregion
   }

   public class MyServerList : ICloneable
   {
      public ArrayList serverArrayList;

      public string currentServerAE;

      public string originalServerAE;
      public string originalServerIP;
      public int originalServerPort;
      public bool preConfigured;

      private const string defaultServerAE = "LEAD_SERVER";
      private const string defaultServerIP = "127.0.0.1";
      private const int defaultServerPort = 104;
      private const int defaultServerTimeout = 30;
      private const bool defaultServerUseTls = false;


      [XmlElement("servers")]
      public MyServer[] serverList
      {
         get
         {
            MyServer[] items = new MyServer[serverArrayList.Count];
            serverArrayList.CopyTo(items);
            return items;
         }
         set
         {
            serverArrayList.Clear();
            if (value == null)
               return;
            MyServer[] items = (MyServer[])value;

            foreach (MyServer item in items)
               serverArrayList.Add(item);
         }
      }


      public MyServerList()
      {
         MyServer myServer = new MyServer(defaultServerAE, defaultServerIP, defaultServerPort, defaultServerTimeout, defaultServerUseTls);

         serverArrayList = new ArrayList();

         currentServerAE = myServer._sAE;
         serverArrayList.Add(myServer);

         originalServerAE = myServer._sAE;
         originalServerIP = myServer._sIP;
         originalServerPort = myServer._port;
         preConfigured = false;
      }

      public bool IsQuerySCPPreconfigured()
      {
         bool ret =
            (
               (string.Compare(GetSelectedServerAE().Trim(), originalServerAE.Trim(), true) == 0) &&
               (string.Compare(GetSelectedServerIP().Trim(), originalServerIP.Trim(), true) == 0) &&
               (GetSelectedServerPort() == originalServerPort)
            );
         return ret;
      }

      public string GetSelectedServerAE()
      {
         foreach (MyServer s in serverArrayList)
         {
            if (currentServerAE == s._sAE)
               return s._sAE;
         }
         return defaultServerAE;
      }

      public string GetSelectedServerIP()
      {
         foreach (MyServer s in serverArrayList)
         {
            if (currentServerAE == s._sAE)
               return s._sIP;
         }
         return defaultServerIP;
      }

      public int GetSelectedServerPort()
      {
         foreach (MyServer s in serverArrayList)
         {
            if (currentServerAE == s._sAE)
               return s._port;
         }
         return defaultServerPort;
      }

      public bool GetSelectedQuerySCPServerUseTls()
      {
         foreach (MyServer s in serverArrayList)
         {
            if (currentServerAE == s._sAE)
               return s._useTls;
         }
         return defaultServerUseTls;
      }

      public int GetSelectedQuerySCPServerTimeout()
      {
         foreach (MyServer s in serverArrayList)
         {
            if (currentServerAE == s._sAE)
               return s._timeout;
         }
         return defaultServerTimeout;
      }

      #region ICloneable Members

      public object Clone()
      {
         MyServerList list = new MyServerList();
         list.originalServerAE = originalServerAE;
         list.originalServerIP = originalServerIP;
         list.originalServerPort = originalServerPort;
         list.currentServerAE = currentServerAE;
         list.preConfigured = preConfigured;
         list.serverArrayList = new ArrayList();
         foreach (MyServer server in serverList)
         {
            list.serverArrayList.Add(server.Clone());
         }
         return list;
      }

      #endregion
   }

   public class MyAppSettings
   {
      [XmlIgnore]
      public MyServerList querySCPServers;
      public MyServerList queryMWLServers;
      public MyServerList storeServers;

      public string clientAE;
      public int clientPort;
      public string clientCertificate;
      public string privateKey;
      public string printerName;
      public string secondaryCapturePath;
      public DicomImageCompressionType secondaryCaptureCompression;
      public string secondaryCaptureColorPath;
      public DicomImageCompressionType secondaryCaptureColorCompression;
      public string secondaryCaptureGrayPath;
      public DicomImageCompressionType secondaryCaptureGrayCompression;
      public string PdfPath;
      public string TempDir;
      public string DataPath;
      public bool autodelete;
      public string privateKeyPassword;
      public string wiaSelectedDevice;
      public string TwainSelectedDevice;
      public bool logLowLevel;
      public bool showHelpOnStart;
      public bool UseResample;
      public bool FirstRun;
      public int DefaultSCPServer;
      public int DefaultMWLServer;
      public int wiaVersion;
      public int LastSelectedIndex;
      public int DefaultStoreServer;
      public CaptureType capturetype;
      public DicomClassType selectedtype;
      private const string defaultClientAE = "LEAD_CLIENT";
      private const int defaultClientPort = 1000;

      private static bool Is64Bit()
      {
         return IntPtr.Size == 8;
      }

      public MyAppSettings()
      {
         querySCPServers = new MyServerList();
         queryMWLServers = new MyServerList();
         storeServers = new MyServerList();

         clientAE = defaultClientAE;
         clientCertificate = string.Empty;
         privateKey = string.Empty;
         privateKeyPassword = "test";
         logLowLevel = true;
         showHelpOnStart = true;
#if LTV20_CONFIG
         if(Is64Bit())
            printerName = "LEADTOOLS 20 PrintToPACS 64-bit";
         else
            printerName = "LEADTOOLS 20 PrintToPACS 32-bit";
#endif
         string strCommonLocation = Path.GetDirectoryName(Application.ExecutablePath);
         strCommonLocation = Path.GetDirectoryName(strCommonLocation);
         strCommonLocation = Path.GetDirectoryName(strCommonLocation);
         strCommonLocation = Path.GetDirectoryName(strCommonLocation);
         strCommonLocation += "\\bin\\common\\xml";

         if (File.Exists(strCommonLocation + "\\" + "SC-basic-ds.xml"))
            secondaryCapturePath = strCommonLocation + "\\" + "SC-basic-ds.xml";
         else
            secondaryCapturePath = "";

         secondaryCaptureCompression = DicomImageCompressionType.None;

         if (File.Exists(strCommonLocation + "\\" + "SC-Multi-Frame True Color Image-ds.xml"))
            secondaryCaptureColorPath = strCommonLocation + "\\" + "SC-Multi-Frame True Color Image-ds.xml";
         else
            secondaryCaptureColorPath = "";

         secondaryCaptureColorCompression = DicomImageCompressionType.None;

         if (File.Exists(strCommonLocation + "\\" + "SC-Multi-Frame Grayscale Byte-ds.xml"))
            secondaryCaptureGrayPath = strCommonLocation + "\\" + "SC-Multi-Frame Grayscale Byte-ds.xml";
         else
            secondaryCaptureGrayPath = "";

         secondaryCaptureGrayCompression = DicomImageCompressionType.None;

         if (File.Exists(strCommonLocation + "\\" + "EncapsulatedPDF-Template-ds.xml"))
            PdfPath = strCommonLocation + "\\" + "EncapsulatedPDF-Template-ds.xml";
         else
            PdfPath = "";

         TempDir = "";
         UseResample = false;
         clientPort = 1000;
         selectedtype = DicomClassType.SCImageStorage;
         autodelete = false;
         capturetype = CaptureType.FullScreen;
         DefaultSCPServer = 0;
         DefaultMWLServer = 0;
         DefaultStoreServer = 0;
         wiaVersion = 0;
         if(Is64Bit())
            DataPath = MySettings.GetFolderPath() + "\\SerializedData_64.ser";
         else
            DataPath = MySettings.GetFolderPath() + "\\SerializedData_32.ser";
         FirstRun = true;
         LastSelectedIndex = -1;
      }

      [XmlElement("SCP servers")]
      public MyServerList QuerySCPServers
      {
         get
         {
            return querySCPServers;
         }
         set
         {
            querySCPServers = value;
         }
      }

      [XmlElement("MWL servers")]
      public MyServerList QueryMWLServers
      {
         get
         {
            return queryMWLServers;
         }
         set
         {
            queryMWLServers = value;
         }
      }

      [XmlElement("Store servers")]
      public MyServerList StoreServers
      {
         get
         {
            return storeServers;
         }
         set
         {
            storeServers = value;
         }
      }
   }

   public class MySettings
   {
      public MyAppSettings _settings;
      public MySettings()
      {
         _settings = new MyAppSettings();
      }

      [DllImport("shfolder.dll", CharSet = CharSet.Auto)]
      private static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);

      private const int CommonDocumentsFolder = 0x2e;

      public static string GetFolderPath()
      {
         StringBuilder lpszPath = new StringBuilder(260);
         // CommonDocuments is the folder than any Vista user (including 'guest') has read/write access
         SHGetFolderPath(IntPtr.Zero, (int)CommonDocumentsFolder, IntPtr.Zero, 0, lpszPath);
         string path = lpszPath.ToString();
         new FileIOPermission(FileIOPermissionAccess.PathDiscovery, path).Demand();
         return path;
      }

      public string GetSettingsFilename()
      {
         return DicomDemoSettingsManager.GetSettingsFilename("CSPrintToPacsDemo");
      }

      public void SavePreconfigure()
      {
         _settings.QuerySCPServers.originalServerAE = _settings.QuerySCPServers.serverList[0]._sAE;
         _settings.QuerySCPServers.originalServerIP = _settings.QuerySCPServers.serverList[0]._sIP;
         _settings.QuerySCPServers.originalServerPort = _settings.QuerySCPServers.serverList[0]._port;
         _settings.QuerySCPServers.preConfigured = true;

         _settings.QueryMWLServers.originalServerAE = _settings.QueryMWLServers.serverList[0]._sAE;
         _settings.QueryMWLServers.originalServerIP = _settings.QueryMWLServers.serverList[0]._sIP;
         _settings.QueryMWLServers.originalServerPort = _settings.QueryMWLServers.serverList[0]._port;
         _settings.QueryMWLServers.preConfigured = true;

         _settings.StoreServers.originalServerAE = _settings.StoreServers.serverList[0]._sAE;
         _settings.StoreServers.originalServerIP = _settings.StoreServers.serverList[0]._sIP;
         _settings.StoreServers.originalServerPort = _settings.StoreServers.serverList[0]._port;
         _settings.StoreServers.preConfigured = true;
         Save();
      }

      public void Save()
      {
         try
         {
            string filename = GetSettingsFilename();
            XmlSerializer xs = new XmlSerializer(typeof(MyAppSettings));
            TextWriter xmlTextWriter = new StreamWriter(filename);
            xs.Serialize(xmlTextWriter, this._settings);
            xmlTextWriter.Close();
         }
         catch (Exception)
         {
         }
      }

      public void CopyGlobalSettings()
      {
         // Read the PACSConfigDemo settings
         string demoName = Path.GetFileName(Application.ExecutablePath);
         DicomDemoSettings globalSettings = DicomDemoSettingsManager.LoadSettings(demoName);
         if (globalSettings != null && globalSettings.IsPreconfigured && globalSettings.FirstRun)
         {
            globalSettings.FirstRun = false;

            // Servers
            DicomAE defaultStore = globalSettings.GetServer(globalSettings.DefaultStore);
            if (defaultStore != null)
            {
               MyServer storeServer = new MyServer(defaultStore);
               _settings.StoreServers.serverArrayList.Clear();
               _settings.StoreServers.serverArrayList.Add(storeServer);
            }

            DicomAE defaultImageQuery = globalSettings.GetServer(globalSettings.DefaultImageQuery);
            if (defaultImageQuery != null)
            {
               MyServer imageQueryServer = new MyServer(defaultImageQuery);
               _settings.QuerySCPServers.serverArrayList.Clear();
               _settings.QuerySCPServers.serverArrayList.Add(imageQueryServer);
            }

            DicomAE defaultMwlQuery = globalSettings.GetServer(globalSettings.DefaultMwlQuery);
            if (defaultMwlQuery != null)
            {
               MyServer mwlQueryServer = new MyServer(defaultMwlQuery);
               _settings.QueryMWLServers.serverArrayList.Clear();
               _settings.QueryMWLServers.serverArrayList.Add(mwlQueryServer);
            }

            // Client
            _settings.clientAE = globalSettings.ClientAe.AE;
            _settings.clientPort = globalSettings.ClientAe.Port;

            DicomDemoSettingsManager.SaveSettings(demoName, globalSettings);
            Save();
         }
      }

      public void Load()
      {
         XmlSerializer SerializerObj = new XmlSerializer(typeof(MyAppSettings));
         string filename = GetSettingsFilename();

         if (File.Exists(filename))
         {
            try
            {
               // Create a new file stream for reading the XML file
               FileStream ReadFileStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);

               // Load the object saved above by using the Deserialize function
               _settings = (MyAppSettings)SerializerObj.Deserialize(ReadFileStream);

               // Cleanup
               ReadFileStream.Close();
            }
            catch (Exception)
            {
            }



         }
      }
   }
}
