// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Leadtools.Dicom;
using System.IO;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Common.Extensions;

namespace Leadtools.Medical.Rules.AddIn.Common
{
    [Serializable]
    public class StoreFailure
    {
        [XmlIgnore]
        public DicomDataSet Dataset { get; set; }        

        public string FileName { get; set; }

        private List<ResendServer> _Scps = new List<ResendServer>();

        public List<ResendServer> Scps
        {
            get
            {
                return _Scps;
            }
            set
            {
                _Scps = value;
            }
        }

        public void Save()
        {
            string timeStamp = "{0:yyyy-MM-dd_hh-mm-ss-tt}".FormatWith(DateTime.Now);
            string sopInstance = Dataset.GetValue<string>(DicomTag.SOPInstanceUID, string.Empty);
            string name = string.Format("Store-{0}-{1}.fail", sopInstance,timeStamp);
            string fileName = Path.Combine(Module.FailureDirectory, name);
            string dsFileName = Path.Combine(Module.FailureDirectory, "{0}-{1}.dcm".FormatWith(sopInstance, timeStamp));

            FileName = dsFileName;
            AddInUtils.Serialize(this, fileName);            
            Dataset.Save(dsFileName, DicomDataSetSaveFlags.None);
        }

        public void Delete()
        {
            if (File.Exists(FileName))
                File.Delete(FileName);
        }
    }
}
