// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Leadtools.DataAccessLayers.Core
{
    [DataContract]
    public class FramePosition
    {
        [DataMember]
        public LeadPointD leftTop { get; set; }

        [DataMember]
        public LeadPointD rightBottom { get; set; }

        public FramePosition()
        {
        }

        public FramePosition(LeadPointD lt, LeadPointD rb)
        {
            leftTop = lt;
            rightBottom = rb;
        }
    }
}
