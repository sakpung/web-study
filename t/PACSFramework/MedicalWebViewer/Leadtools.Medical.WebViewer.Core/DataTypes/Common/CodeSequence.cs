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
    public class CodeSequence
    {
         [DataMember]
        public string CodeValue { get; set; }

         [DataMember]
         public string CodingSchemeDesignator { get; set; }

         [DataMember]
         public string CodingSchemeVersion { get; set; }

         [DataMember]
         public string CodeMeaning { get; set; }
    }
}
