using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using System.ServiceProcess;

namespace WebViewerConfiguration
{
   public static class WebServiceInstaller
   {
      public static void AddZip(ZipArchive archive, List<MyFileEntry> fileEntries)
      {
         int totalCount = fileEntries.Count;
         int count = 0;
         foreach (MyFileEntry fileEntry in fileEntries)
         {
            count++;
            string message;
            if (File.Exists(fileEntry.FileName))
            {
               message = string.Format("...Adding {0}/{1}: {2}", count, totalCount, fileEntry.FileName);
               Logger.LogMessage(message);

               string name = Path.GetFileName(fileEntry.ZipFileName);
               string entryName = name;
               
               if (!string.IsNullOrEmpty(fileEntry.LocationInZip))
               {
                  entryName = string.Format(@"{0}\{1}", fileEntry.LocationInZip, name);
               }
               archive.CreateEntryFromFile(fileEntry.FileName, entryName);
            }
            else
            {
               message = string.Format("... File Missing: {0}", fileEntry.FileName);
               Logger.LogError(message);
            }
         }
      }

      private static string _configFileName_ServicesHostManager = "LeadtoolsServicesHostManager.xml";
      public static string ConfigFileName_ServicesHostManager
      {
         get
         {
            return _configFileName_ServicesHostManager;
         }

         private set
         {
            _configFileName_ServicesHostManager = value;
         }
      }

      //private static string _configFileName_WebViewerConfiguration = "WebViewerConfiguration.exe.Config";
      //public static string ConfigFileName_WebViewerConfiguration
      //{
      //   get
      //   {
      //      return _configFileName_WebViewerConfiguration;
      //   }

      //   private set
      //   {
      //      _configFileName_WebViewerConfiguration = value;
      //   }
      //}

      static string _rootPath = string.Empty;
      public static string RootPath
      {
         get
         {
            if (string.IsNullOrEmpty(_rootPath))
            {
               _rootPath = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            }
            return _rootPath;
         }
      }

      public static string GetConfigFilePath_ServicesHostManager()
      {
         // string thisPath = Path.GetFullPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
         return Path.Combine(RootPath, ConfigFileName_ServicesHostManager);
      }

      public static string GetConfigFileName_WebViewerConfiguration()
      {
         string fileName = Path.Combine(RootPath, "WebViewerConfiguration.exe.config" );
         if (File.Exists(fileName))
            return fileName;

         fileName = Path.Combine(RootPath, "WebViewerConfiguration_Original.exe.config");
         return fileName;
      }

      public static string GetConfigFileName_DatabaseConfiguration()
      {
         string fileName = Path.Combine(RootPath, "CSPacsDatabaseConfigurationDemo.exe.config");
         if (File.Exists(fileName))
            return fileName;

         fileName = Path.Combine(RootPath, "CSPacsDatabaseConfigurationDemo_Original.exe.config");
         return fileName;
      }

      public static string GetConfigFileName_GlobalPacsConfiguration()
      {
         string fileName = Path.Combine(RootPath, "GlobalPacs.config");
         return fileName;
      }

      public static List<string> GetXmlFileListWcf()
      {
         XDocument doc = XDocument.Load(GetConfigFilePath_ServicesHostManager());
         var students = doc.Root
                  .Elements("items")
                  .Elements("item")
                  .Where(x => x.Value.Contains("Leadtools.MedicalViewerService.WCF", StringComparison.OrdinalIgnoreCase))
                  .Elements("assemblies")
                  .Elements("assembly")
                  .Select(x => x.Value)
                  .ToList();

         return students;
      }

      public static List<string> GetXmlFileListAsp()
      {
         XDocument doc = XDocument.Load(GetConfigFilePath_ServicesHostManager());
         var students = doc.Root
                  .Elements("items")
                  .Elements("item")
                  .Where(x => x.Value.Contains("Leadtools.MedicalViewerService.ASP", StringComparison.OrdinalIgnoreCase))
                  .Elements("assemblies")
                  .Elements("assembly")
                  .Select(x => x.Value)
                  .ToList();

         return students;
      }

      public static void AddAppSettingsKeyValue(XDocument doc, string key, string value)
      {
         XElement newElement = new XElement("add");
         newElement.Add(new XAttribute("key", key));
         newElement.Add(new XAttribute("value", value));
         doc.Root
            .Element("appSettings")
            .Add(newElement);
      }

      public static void AddServiceTest(XElement serviceItem, string serviceTestName, string serviceTestUrl)
      {
         // Remove existing tests
         XElement tests = serviceItem.Element("tests");
         if (tests != null)
         {
            tests.Remove();
         }

         // Add new test
         XElement elementTests = new XElement("tests");
         serviceItem.Add(elementTests);

         XElement elementTest = new XElement("test");
         elementTests.Add(elementTest);

         XElement elementName = new XElement("name");
         elementName.Value = serviceTestName;
         elementTest.Add(elementName);

         XElement elementUrl = new XElement("url");
         elementUrl.Value = serviceTestUrl;
         elementTest.Add(elementUrl);
      }

      public static void ModifyWebViewerConfigurationConfig(string outputFile)
      {
         XDocument doc = XDocument.Load(GetConfigFileName_WebViewerConfiguration());

         // Remove "LEADTOOLS HTML5 Medical Viewer Demo (Version 20)"
         doc.Root
            .Element("appSettings")
            .Elements("add")
            .Where(x => x.Attribute("key").Value.Contains("UseLeadPath", StringComparison.OrdinalIgnoreCase))
            .Remove();

         AddAppSettingsKeyValue(doc, "UseExternalWebServicePath", "True");
         doc.Save(outputFile);
      }

      public static string GetGlobalStorageServerConnectionString()
      {
         string connectionString = string.Empty;
         XDocument doc = XDocument.Load(GetConfigFileName_GlobalPacsConfiguration());

         connectionString = doc.Root
          .Element("connectionStrings")
          .Elements("add")
          .Where(x => x.Attribute("name").Value.Contains("LeadStorageServer", StringComparison.OrdinalIgnoreCase))
          .First()
          .Attribute("connectionString").Value;


         return connectionString;
      }


      public static void ModifyDatabaseConfigurationConfig(string outputFile)
      {
         XDocument doc = XDocument.Load(GetConfigFileName_DatabaseConfiguration());

         AddAppSettingsKeyValue(doc, "DisableCreate", "True");
         AddAppSettingsKeyValue(doc, "EnabledDatabases", "StorageServer");
         AddAppSettingsKeyValue(doc, "ShowStorageServerDatabaseOptions", "False");
         AddAppSettingsKeyValue(doc, "ShouldEnumerateSqlServers", "False");

         string connectionString = GetGlobalStorageServerConnectionString();
         AddAppSettingsKeyValue(doc, "StorageServerConnectionString", connectionString);

         doc.Save(outputFile);
      }

      public static void ModifyLeadtoolsServicesHostManagerXml(string outputFile)
      {
         XDocument doc = XDocument.Load(GetConfigFilePath_ServicesHostManager());

         // Modify "useLEADInstallation"
         doc.Root
            .Element("settings")
            .Element("useLEADInstallation")
            .Remove();

         doc.Root
            .Element("settings")
            .Add(new XElement("useLEADInstallation", "False"));

         doc.Root
            .Element("settings")
            .Add(new XElement("useExternalServiceInstallation", "True"));

         doc.Root
            .Element("settings")
            .Add(new XElement("isExternalServiceInstallation64BitProcess", Environment.Is64BitProcess.ToString()));

         // Remove "LEADTOOLS HTML5 Medical Viewer Demo (Version 20)"
         doc.Root
            .Element("groups")
            .Element("group")
            .Element("items")
            .Elements("item")
            .Where(x => x.Value.Contains("LEADTOOLS HTML5 Medical Viewer Demo", StringComparison.OrdinalIgnoreCase))
            .Remove();

         // Remove "LEADTOOLS CCOW Web Participation Demo "
         doc.Root
            .Element("groups")
            .Elements("group")
            .Where(x => x.Value.Contains("LEADTOOLS CCOW Web Participation Demo", StringComparison.OrdinalIgnoreCase))
            .Remove();

         // Modify "Leadtools.MedicalViewerService.ASP" project_dir and iis_physical_path
         XElement nameAsp = doc.Root
            .Element("items")
            .Elements("item")
            .Where(x => x.Element("name").Value.Contains("Leadtools.MedicalViewerService.ASP", StringComparison.OrdinalIgnoreCase))
            .Single();

         nameAsp.Element("project_dir").Value = @"Leadtools.Medical.WebViewer.ASP\Leadtools.Medical.WebViewer";
         nameAsp.Element("iis_physical_path").Value = @"Leadtools.Medical.WebViewer.ASP\Leadtools.Medical.WebViewer";

         // Add ASP.Net Service Test
         AddServiceTest(nameAsp, "Leadtools.MedicalViewerService.ASP", string.Empty /*"MedicalViewerServiceAsp20"*/);

         // Modify "Leadtools.MedicalViewerService.WCF" project_dir and iis_physical_path
         XElement nameWcf = doc.Root
            .Element("items")
            .Elements("item")
            .Where(x => x.Element("name").Value.Contains("Leadtools.MedicalViewerService.WCF", StringComparison.OrdinalIgnoreCase))
            .Single();

         nameWcf.Element("project_dir").Value = @"Leadtools.Medical.WebViewer.WCF";
         nameWcf.Element("iis_physical_path").Value = @"Leadtools.Medical.WebViewer.WCF";

         // Add WCF Service Test
         AddServiceTest(nameWcf, "Leadtools.MedicalViewerService.WCF", string.Empty /*"MedicalViewerServiceWcf20"*/);


         // Remove items:
         //    LEADTOOLS HTML5 Medical Viewer Demo
         //    Leadtools.Ccow.WebAgentsServices
         //    LEADTOOLS CCOW Web Participation Demo 
         doc.Root
            .Element("items")
            .Elements("item")
            .Where(x => x.Element("name").Value.Contains("LEADTOOLS HTML5 Medical Viewer Demo", StringComparison.OrdinalIgnoreCase))
            .Remove();

         doc.Root
            .Element("items")
            .Elements("item")
            .Where(x => x.Element("name").Value.Contains("Leadtools.Ccow.WebAgentsServices", StringComparison.OrdinalIgnoreCase))
            .Remove();

         doc.Root
            .Element("items")
            .Elements("item")
            .Where(x => x.Element("name").Value.Contains("LEADTOOLS CCOW Web Participation Demo", StringComparison.OrdinalIgnoreCase))
            .Remove();

         doc.Save(outputFile);
      }

      private static string GetTempFileName(string originalFileName)
      {
         string fileName = Path.GetFileNameWithoutExtension(originalFileName) + "_modified.xml";
         string directoryName = Path.GetDirectoryName(originalFileName);

         string newFileName = Path.Combine(directoryName, fileName);
         if (File.Exists(newFileName))
         {
            File.Delete(newFileName);
         }

         return newFileName;
      }

      public static void AddModifiedConfig(this List<MyFileEntry> files, string fullConfigPath, Action<string> modifyFunction)
      {
         string originalName = Path.GetFileName(fullConfigPath);
         string outputPath = GetTempFileName(fullConfigPath);
         modifyFunction(outputPath);
         files.Add(new MyFileEntry(outputPath, string.Empty, originalName));
      }

      static string GetSvcDirectory()
      {
         string[] possiblePaths = {
             @"..\..\..\..\Examples\DotNet\PACSFramework175\MedicalWebViewer\Leadtools.Medical.WebViewer.WCF\StoreService.svc",
             @"..\..\..\..\Examples\DotNet\PACSFramework\MedicalWebViewer\Leadtools.Medical.WebViewer.WCF\StoreService.svc",
              @"..\..\..\Examples\DotNet\PACSFramework175\MedicalWebViewer\Leadtools.Medical.WebViewer.WCF\StoreService.svc",
             @"..\..\..\Examples\DotNet\PACSFramework\MedicalWebViewer\Leadtools.Medical.WebViewer.WCF\StoreService.svc"
         };

         string retDirectory = string.Empty;

         foreach (string s in possiblePaths)
         {
            string svcPath = Path.Combine(WebServiceInstaller.RootPath, s);
            if (File.Exists(svcPath))
            {
               retDirectory = Path.GetDirectoryName(Path.GetFullPath(svcPath));
               break;
            }
         }

         return retDirectory;
      }

      static string GetAspDirectory()
      {
         string[] possiblePaths = {
             @"..\..\..\..\Examples\DotNet\PACSFramework175\MedicalWebViewer\Leadtools.Medical.WebViewer.ASP\Leadtools.Medical.WebViewer\Index.html",
             @"..\..\..\..\Examples\DotNet\PACSFramework\MedicalWebViewer\Leadtools.Medical.WebViewer.ASP\Leadtools.Medical.WebViewer\Index.html",
              @"..\..\..\Examples\DotNet\PACSFramework175\MedicalWebViewer\Leadtools.Medical.WebViewer.ASP\Leadtools.Medical.WebViewer\Index.html",
             @"..\..\..\Examples\DotNet\PACSFramework\MedicalWebViewer\Leadtools.Medical.WebViewer.ASP\Leadtools.Medical.WebViewer\Index.html"
         };

         string retDirectory = string.Empty;

         foreach (string s in possiblePaths)
         {
            string aspPath = Path.Combine(WebServiceInstaller.RootPath, s);
            if (File.Exists(aspPath))
            {
               retDirectory = Path.GetDirectoryName(Path.GetFullPath(aspPath));
               break;
            }
         }

         return retDirectory;
      }

      static void AddWcfServiceFiles(this List<MyFileEntry> files)
      {
         // System.Diagnostics.Debugger.Launch();
         string svcDirectory = GetSvcDirectory();
         string locationInZip = @"Leadtools.Medical.WebViewer.WCF";

         // .svc files
         try
         {
            var svcFiles = Directory.EnumerateFiles(svcDirectory, "*.svc", SearchOption.TopDirectoryOnly);

            foreach (string svcFile in svcFiles)
            {
               MyFileEntry entry = new MyFileEntry(svcFile, locationInZip);
               files.Add(entry);
            }
         }
         catch (Exception e)
         {
            Console.WriteLine(e.Message);
         }

         // index.html
         // index.js
         files.Add(new MyFileEntry(Path.Combine(svcDirectory, @"index.html"), locationInZip));
         files.Add(new MyFileEntry(Path.Combine(svcDirectory, @"index.js"), locationInZip));
         files.Add(new MyFileEntry(Path.Combine(svcDirectory, @"web.config"), locationInZip));

         // Resources/Images/favicon.ico
         // Resources/Images/LeadtoolsHeader.png
         // Resources/Images/loading.GIF
         string resourceDirectory = Path.Combine(svcDirectory, @"Resources/Images");
         try
         {
            var resourceFiles = Directory.EnumerateFiles(resourceDirectory, "*.*", SearchOption.TopDirectoryOnly);

            foreach (string resourceFile in resourceFiles)
            {
               MyFileEntry entry = new MyFileEntry(resourceFile, Path.Combine(locationInZip, @"Resources/Images"));
               files.Add(entry);
            }
         }
         catch (Exception e)
         {
            Console.WriteLine(e.Message);
         }

         // Resources/Styles/LEADServiceStyles.css
         string fileLEADServiceStyles = Path.Combine(svcDirectory, @"Resources/Styles/LEADServiceStyles.css");
         files.Add(new MyFileEntry(fileLEADServiceStyles, Path.Combine(locationInZip, @"Resources/Styles")));
      }

      static void AddAspServiceFiles(this List<MyFileEntry> files)
      {
         string aspDirectory = GetAspDirectory();
         string locationInZip = @"Leadtools.Medical.WebViewer.ASP/Leadtools.Medical.WebViewer";

         // index.html
         // index.js
         files.Add(new MyFileEntry(Path.Combine(aspDirectory, @"ConfigFirst.html"), locationInZip));
         files.Add(new MyFileEntry(Path.Combine(aspDirectory, @"connectionStrings.config"), locationInZip));
         files.Add(new MyFileEntry(Path.Combine(aspDirectory, @"Global.asax"), locationInZip));
         files.Add(new MyFileEntry(Path.Combine(aspDirectory, @"index.html"), locationInZip));
         files.Add(new MyFileEntry(Path.Combine(aspDirectory, @"index.js"), locationInZip));
         files.Add(new MyFileEntry(Path.Combine(aspDirectory, @"local.config"), locationInZip));
         files.Add(new MyFileEntry(Path.Combine(aspDirectory, @"Web.config"), locationInZip));

         // Resources/Images/favicon.ico
         // Resources/Images/LeadtoolsHeader.png
         // Resources/Images/loading.GIF
         string resourceDirectory = Path.Combine(aspDirectory, @"Resources\Images");
         if (Directory.Exists(resourceDirectory))
         {
            try
            {
               var resourceFiles = Directory.EnumerateFiles(resourceDirectory, "*.*", SearchOption.TopDirectoryOnly);

               foreach (string resourceFile in resourceFiles)
               {
                  MyFileEntry entry = new MyFileEntry(resourceFile, Path.Combine(locationInZip, @"Resources\Images"));
                  files.Add(entry);
               }
            }
            catch (Exception e)
            {
               Console.WriteLine(e.Message);
            }
         }
         else
         {
            string message = string.Format("...Folder not found: {0}", resourceDirectory);
            Logger.LogError(message);
         }


         // Resources/Styles/LEADServiceStyles.css
         string fileLEADServiceStyles = Path.Combine(aspDirectory, @"Resources\Styles\LEADServiceStyles.css");
         files.Add(new MyFileEntry(fileLEADServiceStyles, Path.Combine(locationInZip, @"Resources\Styles")));
      }



      private static bool AddToList(List<string> list1, string root, string s)
      {
         bool ret = false;
         string fileLocation = Path.Combine(root, s);
         if (File.Exists(fileLocation))
         {
            list1.Add(fileLocation);
            ret = true;
         }
         return ret;
      }

      private static void AddToList(List<string> list1, List<string> list2)
      {
         foreach (string s in list2)
         {
            // AddToList(list1, s);
            list1.Add(s);
         }
      }

      static void AddRootLevelFiles(this List<MyFileEntry> files)
      {
         // Assemblies (Leadtools.Xxxxx.dll)
         List<string> binaryFileList = new List<string>();

         List<string> wcfList = WebServiceInstaller.GetXmlFileListWcf();
         AddToList(binaryFileList, wcfList);

         List<string> aspList = WebServiceInstaller.GetXmlFileListAsp();
         AddToList(binaryFileList, aspList);

         // 
         AddToList(binaryFileList, WebServiceInstaller.RootPath, @"Leadtools.Medical.Forward.DataAccessLayer.dll");
         AddToList(binaryFileList, WebServiceInstaller.RootPath, @"Leadtools.Medical.Media.DataAccessLayer.dll");
         AddToList(binaryFileList, WebServiceInstaller.RootPath, @"Leadtools.Dicom.Server.exe");
         AddToList(binaryFileList, WebServiceInstaller.RootPath, @"Leadtools.ProxyServer3D.exe");

         AddToList(binaryFileList, WebServiceInstaller.RootPath, @"Leadtools.Medical3DProxy.exe");
         AddToList(binaryFileList, WebServiceInstaller.RootPath, @"Leadtools.MedicalViewer.dll");

         AddToList(binaryFileList, WebServiceInstaller.RootPath, @"Leadtools.Medical3D.Engine9.dll");
         AddToList(binaryFileList, WebServiceInstaller.RootPath, @"Leadtools.Medical3d.dll");

         // Swift Shader
         AddToList(binaryFileList, WebServiceInstaller.RootPath, @"LT3DRndr9u.dll");
         AddToList(binaryFileList, WebServiceInstaller.RootPath, @"LT3DRndr9x.dll");

         // Exe
         if (AddToList(binaryFileList, WebServiceInstaller.RootPath, @"CSPacsDatabaseConfigurationDemo.exe") == false)
         {
            AddToList(binaryFileList, WebServiceInstaller.RootPath, @"CSPacsDatabaseConfigurationDemo_Original.exe");
         }

         if (AddToList(binaryFileList, WebServiceInstaller.RootPath, @"WebViewerConfiguration.exe") == false)
         {
            AddToList(binaryFileList, WebServiceInstaller.RootPath, @"WebViewerConfiguration_Original.exe");
         }

         if (AddToList(binaryFileList, WebServiceInstaller.RootPath, @"LeadtoolsServicesHostManager.exe") == false)
         {
            AddToList(binaryFileList, WebServiceInstaller.RootPath, @"LeadtoolsServicesHostManager_Original.exe");
         }

         // Add help file for LeadtoolsServicesHostManager.exe
         AddToList(binaryFileList, WebServiceInstaller.RootPath, @"LeadtoolsServicesHostManagerTroubleshooting.html");

         // Remove duplicates
         binaryFileList = binaryFileList.Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();

         // Sort
         binaryFileList = binaryFileList.OrderBy(q => q).ToList();

         foreach (string s in binaryFileList)
         {
            files.Add(new MyFileEntry(Path.Combine(WebServiceInstaller.RootPath, s), string.Empty));
         }
      }

      private static void AddFilesToZip(ZipArchive newZipFile)
      {

         List<MyFileEntry> files = new List<MyFileEntry>();

         files.AddRootLevelFiles();

         // Configuration
         // files.Add(new MyFileEntry(Path.Combine(WebServiceInstaller.RootPath, @"GlobalPacs.config"), @"Configuration"));

         // Modified "LeadtoolsServicesHostManager.xml"
         files.AddModifiedConfig(WebServiceInstaller.GetConfigFilePath_ServicesHostManager(), WebServiceInstaller.ModifyLeadtoolsServicesHostManagerXml);

         // Modified "WebViewerConfiguration.exe.Config"
         files.AddModifiedConfig(WebServiceInstaller.GetConfigFileName_WebViewerConfiguration(), WebServiceInstaller.ModifyWebViewerConfigurationConfig);

         // Modified "CSPacsDatabaseConfigurationDemo.exe.config" or "CSPacsDatabaseConfigurationDemo_Original.exe.config"
         files.AddModifiedConfig(WebServiceInstaller.GetConfigFileName_DatabaseConfiguration(), WebServiceInstaller.ModifyDatabaseConfigurationConfig);

         // WCF Service Files
         files.AddWcfServiceFiles();

         // ASP Service Files
         files.AddAspServiceFiles();

         WebServiceInstaller.AddZip(newZipFile, files);

         string message = "...Total Files Added: " + files.Count.ToString();
         Logger.LogMessage(message);
      }

      static string _defaultZipName = @"WebServiceInstaller.zip";
 

      public static string DefaultZipName
      {
         get
         {
            return _defaultZipName;
         }
      }

      public static string CreateInstaller(string zipPath)
      {
         Logger.Clear();

         // Create an empty zip file
         string message = string.Format("Begin Creating Installer: '{0}'", zipPath);
         Logger.LogMessage(message);

         if (File.Exists(zipPath))
         {
            File.Delete(zipPath);
         }

         using (ZipArchive newZipFile = ZipFile.Open(zipPath, ZipArchiveMode.Create))
         {
            // Add files to zip
            AddFilesToZip(newZipFile);
         }

         message = string.Format("Finished Creating Installer: '{0}'", zipPath);
         Logger.LogMessage(message);
         return zipPath;
      }

      public static string Configure3DServiceToolStripMenuItemText
      {
         get;
         set;
      }

      public static string GetStorageServerPath()
      {
         string storageServerPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"CSStorageServerManagerDemo_Original.exe");
         if (File.Exists(storageServerPath))
         {
            return storageServerPath;
         }

         storageServerPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"CSStorageServerManagerDemo.exe");
         if (File.Exists(storageServerPath))
         {
            return storageServerPath;
         }

         return string.Empty;

      }

      public static string GetInstallerMessage(InstallerMessageType installerMessageType, string installerName)
      {
         string thisExeName = PathHelper.GetThisExeName();
         string message = string.Empty;

         if (string.IsNullOrEmpty(installerName))
         {
            installerName = DefaultZipName;
         }

         string storageServerPath = GetStorageServerPath();
         string storageServerName = Path.GetFileName(storageServerPath);

         switch (installerMessageType)
         {
            case InstallerMessageType.BeforeCreated:
               message = "" +
                         "Click 'Create Installer' to create a zip file that can be used to install the LEAD Medical Web Services on 2nd computer.{0}" +
                         "\r\n" +
                         "Follow these steps to install the LEAD web services on a 2nd computer:{0}" +
                         "1. Run '{3}'{0}" +
                         "2. Set the File settings to a network path, accessible to both computers (this and the 2nd computer).{0}" +
                         "{0}" +
                         "3. Click 'Create Installer' to create the zip file installer: '{1}'.{0}" +
                         "4. 2nd computer: Copy '{1}' to any folder.{0}" +
                         "5. 2nd computer: Unzip '{1}'.{0}" +
                         "6. 2nd computer: Run '{2}' to create the web services.{0}" +
                         "7. From menu in this demo, choose 'Options|{3}' to configure using the web services.{0}" +
                         "";
               
               break;

            case InstallerMessageType.AfterCreated:
               message = "" +
                         "Web Service installer successfully created.{0}" +
                         "{0}" +
                         "Follow these steps to install the LEAD web services on a 2nd computer:{0}" +
                         "1. Click on the link below to open the folder containing the installer.{0}" +
                         "2. 2nd computer: Copy '{1}' to any folder.{0}" +
                         "3. 2nd computer: Unzip '{1}'.{0}" +
                         "4. 2nd computer: Run '{2}' to create the web services.{0}" +
                         "5. From menu in this demo, choose 'Options|{3}' to configure using web services.{0}" +
                         "";
               break;
         }

         return string.Format(message, Environment.NewLine, installerName, thisExeName, Configure3DServiceToolStripMenuItemText, storageServerName);
      }
   }

   public static class MyWindowsServiceController
   {
      public static void Start(string serviceName, out string errorString)
      {
         errorString = string.Empty;
         using (ServiceController serviceController = new ServiceController(serviceName))
         {
            try
            {
               if ((serviceController.Status.Equals(ServiceControllerStatus.Running)) || (serviceController.Status.Equals(ServiceControllerStatus.StartPending)))
               {
                  serviceController.Stop();
               }
               serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
               serviceController.Start();
               serviceController.WaitForStatus(ServiceControllerStatus.Running);
            }
            catch (Exception ex)
            {
               errorString = ex.Message;
            }
         }
      }

      public static void Stop(string serviceName, out string errorString)
      {
         errorString = string.Empty;
         using (ServiceController serviceController = new ServiceController(serviceName))
         {
            try
            {
               if ((serviceController.Status.Equals(ServiceControllerStatus.Running)) || (serviceController.Status.Equals(ServiceControllerStatus.StartPending)))
               {
                  serviceController.Stop();
               }
               serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
            }
            catch (Exception ex)
            {
               errorString = ex.Message;
            }
         }
      }

      public static int Delete(string serviceName, out string errorString)
      {
         errorString = string.Empty;
         string args = string.Format("delete \"{0}\"", serviceName);
         int exitCode = 0;       // 0 -- success
         errorString = string.Empty;
         try
         {
            using (Process process = new Process())
            {
               process.StartInfo.FileName = "sc";
               process.StartInfo.Arguments = args;
               process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
               process.Start();
               process.WaitForExit();// Waits here for the process to exit
               exitCode = process.ExitCode;
            }
         }
         catch (Exception ex)
         {
            errorString = ex.Message;
            exitCode = -1;
         }
         return exitCode;
      }

      public static int Register(string serviceNameFullPath, string args, out string errorString)
      {
         int exitCode = 0;       // 0 -- success
         string exeFolder = PathHelper.GetExePath();
         string comObjectPath = Path.Combine(exeFolder, "Leadtools.Medical3DProxy.exe");
         errorString = string.Empty;
         try
         {
            using (Process process = new Process())
            {
               process.StartInfo.FileName = comObjectPath;
               process.StartInfo.Arguments = args;
               process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
               process.Start();
               process.WaitForExit();// Waits here for the process to exit
               exitCode = process.ExitCode;
            }
         }
         catch (Exception ex)
         {
            errorString = ex.Message;
            exitCode = -1;
         }
         return exitCode;
      }
   }



   public enum InstallerMessageType
   {
      BeforeCreated,
      AfterCreated
   }

   public class MyFileEntry
   {
      private string _fileName;
      private string _locationInZip;
      private string _zipFileName;

      public string FileName
      {
         get { return _fileName;}
         set { _fileName = value;}
      }

      public string ZipFileName
      {
         get { return _zipFileName; }
         set { _zipFileName = value; }
      }

      public string LocationInZip
      {
         get { return _locationInZip; }
         set { _locationInZip = value; }
      }

      public MyFileEntry(string fileName, string locationInZip)
      {
         _fileName = fileName;
         _zipFileName = _fileName;
         _locationInZip = locationInZip;
      }

      public MyFileEntry(string fileName, string locationInZip, string zipFileName)
      {
         _fileName = fileName;
         _zipFileName = zipFileName;
         _locationInZip = locationInZip;
      }
   }
}
