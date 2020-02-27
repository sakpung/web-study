// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.DataAccessLayers.Core
{
    public enum Laterality
    {
        Unknown,
        Left,
        Right,
        Both
    }

    [DataContract]
    public class AnatomicDescription
    {
        [DataMember]
        public string Id { get; set; }        

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public CodeSequence AnatomicRegionSequence { get; set; }

        [DataMember]
        public CodeSequence AnatomicRegionModifierSequence { get; set; }

        [DataMember]
        public Laterality Laterality { get; set; }
    }
}
