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

namespace Leadtools.AddIn.Move
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
        private static string _ConnectionString = string.Empty;

        public static string ConnectionString
        {
            get { return _ConnectionString; }           
        }

        private static string _ImageDirectory = string.Empty;

        public static string ImageDirectory
        {
            get { return _ImageDirectory; }
        }  

        public override void AddServices()
        {         
        }

        public override void Load(string ServiceDirectory,string DisplayName)
        {
            _ConnectionString = "Data Source='" + ServiceDirectory + @"\Dicom.sdf'";
            _ImageDirectory = ServiceDirectory + @"\Images\";
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
                if (!ExtensionMethods.HasTag(ds,DicomTag.SOPInstanceUID))
                {
                    return DicomCommandStatusType.MissingAttribute;
                }
            }

            return DicomCommandStatusType.Success;
        }        
    }
}
