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
    public class TemplateFrame
    {
        [DataMember]
        public FramePosition Position { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public int FrameNumber { get; set; }

        [DataMember]
        public int? SequenceNumber { get; set; }

        [DataMember]
        public FrameRotation Rotation { get; set; }

        [DataMember]
        public FrameHorizontalJustication HorizontalJustification { get; set; }

        [DataMember]
        public FrameVerticalJustification VerticalJustification { get; set; }

        [DataMember]
        public PresentationSizeMode PresentationSizeMode { get; set; }

        [DataMember]
        public double Magnification { get; set; }

        [DataMember]
        public string ImageComments { get; set; }

        [DataMember]
        public AnatomicDescription AnatomicDescription { get; set; }

        [DataMember]
        public string Script { get; set; }

        [DataMember]
        public bool Flip { get; set; }

        [DataMember]
        public bool Reverse { get; set; }

        [DataMember]
        public bool Invert { get; set; }

        public TemplateFrame(FramePosition position)
        {
            Position = position;
            Id = string.Empty;
            FrameNumber = -1;
            SequenceNumber = -1;
            Rotation = FrameRotation.None;
            ImageComments = string.Empty;
            AnatomicDescription = new AnatomicDescription();
            Flip = false;
            Reverse = false;
            Invert = false;
        }
    }
}
