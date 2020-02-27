// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using CSDicomDirLinqDemo.Properties;

namespace CSDicomDirLinqDemo.Utils
{
    public static class SettingsManager
    {
        [DllImport("shfolder.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);

        private const int CommonDocumentsFolder = 0x2e;

        public enum InstallPlatform
        {
            win32 = 0,
            x64 = 1
        };

        public static T Load<T>(string demoName)
        {
            XmlSerializer SerializerObj = new XmlSerializer(typeof(T));
            string filename = GetSettingsFilename(demoName);
            T settings = default(T);

            if (File.Exists(filename))
            {                
                try
                {
                    // Create a new file stream for reading the XML file
                    using (TextReader ReadFileStream = new StreamReader(filename))
                    {                        
                        settings = (T)SerializerObj.Deserialize(ReadFileStream);                     
                        ReadFileStream.Close();
                    }
                }
                catch (Exception)
                {
                    throw;
                }                            
            }
            else
            {
                try
                {
                    byte[] data = Encoding.ASCII.GetBytes(Resources.DefaultQueries);

                    using (MemoryStream stream = new MemoryStream(data))
                    {
                        settings = (T)SerializerObj.Deserialize(stream);
                    }
                }
                catch(Exception e)
                {
                    throw e;
                }
            }

            if (settings == null)
                settings = default(T);

            return settings;
        }

        public static void Save<T>(string demoName, T settings)
        {
            try
            {
                string filename = GetSettingsFilename(demoName);
                XmlSerializer xs = new XmlSerializer(typeof(T));

                using (TextWriter xmlTextWriter = new StreamWriter(filename))
                {
                    xs.Serialize(xmlTextWriter, settings);
                    xmlTextWriter.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string GetSettingsFilename(string demo)
        {
            string commonFolder = GetFolderPath();
            if (Is64Process())
            {
                return GetSettingsFilename(demo, InstallPlatform.x64);
            }
            else
            {
                return GetSettingsFilename(demo, InstallPlatform.win32);
            }
        }

        private static bool Is64Process()
        {
            return IntPtr.Size == 8;
        }        

        public static string GetFolderPath()
        {
            StringBuilder lpszPath = new StringBuilder(260);
            // CommonDocuments is the folder than any Vista user (including 'guest') has read/write access
            SHGetFolderPath(IntPtr.Zero, (int)CommonDocumentsFolder, IntPtr.Zero, 0, lpszPath);
            string path = lpszPath.ToString();
            new FileIOPermission(FileIOPermissionAccess.PathDiscovery, path).Demand();
            return path;
        }

        public static string GetSettingsFilename(string demo, InstallPlatform platform)
        {
            string commonFolder = GetFolderPath();
            string sPlatform = "32";

            if (platform == InstallPlatform.x64)
            {
                sPlatform = "64";
            }
            else
            {
                sPlatform = "32";
            }

            string ext = Path.GetExtension(demo);
            string name = Path.GetFileNameWithoutExtension(demo);

            string settingsFilename = string.Format("{0}\\{1}{2}{3}_17.xml", commonFolder, name, sPlatform, ext);
            return settingsFilename;
        }
    }
}
