// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom.AddIn;
using System.IO;
using System.Data.SqlServerCe;
using System.Reflection;
using Leadtools.Dicom;

namespace Leadtools.AddIn.Store
{
    public class ServerInfo
    {
        private string _ConnectionString = string.Empty;

        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }
        private string _ImageDirectory = string.Empty;

        public string ImageDirectory
        {
            get { return _ImageDirectory; }
            set { _ImageDirectory = value; }
        }  
    }

    public class Module : ModuleInit
    {
        public static ServerInfo ServerInfo = null;
          
        public override void AddServices()
        {         
        }

        public override void Load(string ServiceDirectory,string DisplayName)
        {
            SetServerInfo(ServiceDirectory);
        }

        public static void SetServerInfo(string ServiceDirectory)
        {
            string temp = string.Empty;
            string ConnectionString = "Data Source='" + Path.Combine(ServiceDirectory,"Dicom.sdf") + "'";
            string ImageDirectory = Path.Combine(ServiceDirectory,@"Images\");

            if (!File.Exists(ServiceDirectory + @"\Dicom.sdf"))
            {
                string fullname = GetResourceFullName("Dicom.sdf");
                Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fullname);

                if (stream != null)
                {
                    FileStream fs = new FileStream(ServiceDirectory + @"\Dicom.sdf", FileMode.CreateNew);
                    byte[] data = new byte[stream.Length];

                    stream.Read(data, 0, (int)stream.Length);
                    fs.Write(data, 0, (int)stream.Length);
                    fs.Close();
                }
            }

            if (!Directory.Exists(ImageDirectory))
            {
                Directory.CreateDirectory(ImageDirectory);
            }

            ServerInfo = new ServerInfo();
            ServerInfo.ConnectionString = ConnectionString;
            ServerInfo.ImageDirectory = ImageDirectory;
        }

        private static string GetResourceFullName(string resName)
        {
            string fullName = null;

            foreach (string str in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (str.EndsWith(resName))
                {
                    fullName = str;
                    break;
                }
            }
            return fullName;
        }

        public static DicomCommandStatusType GetAttributeStatus(string level, string affectedClass, DicomDataSet ds)
        {
            if (level.Length == 0)
            {
                return DicomCommandStatusType.InvalidArgumentValue;
            }

            if (affectedClass == DicomUidType.PatientRootQueryFind && level != "PATIENT")
            {
               if (!ExtensionMethods.HasTag(ds, DicomTag.PatientID))
                {
                    return DicomCommandStatusType.MissingAttribute;
                }

                if (ds.GetValue<string>(DicomTag.PatientID, string.Empty).Length == 0)
                {
                    return DicomCommandStatusType.MissingAttribute;
                }
            }

            if (level == "STUDY" || level == "SERIES" || level == "IMAGE")
            {
               if (!ExtensionMethods.HasTag(ds, DicomTag.StudyInstanceUID))
                {
                    return DicomCommandStatusType.MissingAttribute;
                }

                if (level == "SERIES" || level == "IMAGE")
                {
                    if (ds.GetValue<string>(DicomTag.StudyInstanceUID, string.Empty).Length == 0)
                    {
                        return DicomCommandStatusType.MissingAttribute;
                    }
                }
            }

            if (level == "SERIES" || level == "IMAGE")
            {
               if (!ExtensionMethods.HasTag(ds, DicomTag.SeriesInstanceUID))
                {
                    return DicomCommandStatusType.MissingAttribute;
                }
            }

            if (level == "IMAGE")
            {
               if (!ExtensionMethods.HasTag(ds, DicomTag.SOPInstanceUID))
                {
                    return DicomCommandStatusType.MissingAttribute;
                }
            }

            return DicomCommandStatusType.Success;
        }        
    }
}
