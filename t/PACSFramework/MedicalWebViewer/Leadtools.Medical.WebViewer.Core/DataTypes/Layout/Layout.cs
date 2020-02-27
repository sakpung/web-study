// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Leadtools.Medical.WebViewer.DataContracts
{
    [DataContract]
    public class Layout
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string TemplateId { get; set; }     
        [DataMember]
        public string Icon { get; set; }
        [DataMember]
        public List<ImageBox> Boxes { get; set; }

        public Layout()
        {
            Boxes = new List<ImageBox>();
        }
    }

    [DataContract]
    public class StudyLayout
    {
        [DataMember]
        public int Rows { get; set; }
        [DataMember]
        public int Columns { get; set; }
        [DataMember]
        public List<SeriesInfo> Series { get; set; }
        [DataMember]
        public List<ImageBox> Boxes { get; set; }
        [DataMember]
        public List<OtherStudies> OtherStudies { get; set; }
        [DataMember]
        public string Name { get; set; }

        public StudyLayout()
        {
            Rows = -1;
            Columns = -1;
            Series = new List<SeriesInfo>();
            Boxes = new List<ImageBox>();
            OtherStudies = new List<OtherStudies>();
            Name = "Study Layout";
        }
    }
}
