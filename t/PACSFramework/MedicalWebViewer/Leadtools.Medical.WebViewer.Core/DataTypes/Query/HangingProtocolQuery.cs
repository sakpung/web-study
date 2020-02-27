// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;

namespace Leadtools.Medical.WebViewer.DataContracts
{
    [DataContract]
    public class HangingProtocolQuery
    {
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public HangingProtocolLevel? Level { get; set; }

        [DataMember]
        public string Creator { get; set; }

        [DataMember]
        public List<HangingProtocolDefinition> HangingProtocolDefinitionSequence { get; set; }
        
    }

    [DataContract]
    public class HangingProtocolQueryResult
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public HangingProtocolLevel ? Level { get; set;}

        [DataMember]
        public bool BestMatch { get; set; }

        [DataMember]
        public string SOPInstanceUID { get; set; }
    }
}
