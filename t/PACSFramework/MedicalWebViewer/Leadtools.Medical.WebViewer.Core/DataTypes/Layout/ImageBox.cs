// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Leadtools.DataAccessLayers.Core;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Medical.WebViewer.Core.DataTypes;

namespace Leadtools.Medical.WebViewer.DataContracts
{
    [DataContract]
    public class ImageBox
    {
        [DataMember]
        public List<string> referencedSOPInstanceUID { get; set; }
        [DataMember]
        public FramePosition Position { get; set; }

        [DataMember]
        public int RowPosition { get; set; }
        [DataMember]
        public int ColumnPosition { get; set; }
        [DataMember]
        public int ImageBoxNumber { get; set; }
        [DataMember]
        public int NumberOfRows { get; set; }
        [DataMember]
        public int NumberOfColumns { get; set; }
        [DataMember]
        public ImageBoxLayoutType ImageBoxLayoutType { get; set; }
        [DataMember]
        public FirstFrame FirstFrame { get; set; }
        [DataMember]
        public int WindowWidth { get; set; }
        [DataMember]
        public int WindowCenter { get; set; }

        [DataMember]
        public string ReferencedPresentationStateSOP { get; set; }
        [DataMember]
        public HorizontalJustification HorizontalJustification { get; set; }
        [DataMember]
        public VerticalJustification VerticalJustification { get; set; }

        [DataMember]
        public int? ImageBoxTileHorizontalDimension { get; set; }

        [DataMember]
        public int? ImageBoxTileVerticalDimension { get; set; }

        [DataMember]
        public ScrollDirection? ImageBoxScrollDirection { get; set; }

        [DataMember]
        public ScrollType? ImageBoxSmallScrollType { get; set; }

        [DataMember]
        public int? ImageBoxSmallScrollAmount { get; set; }

        [DataMember]
        public ScrollType? ImageBoxLargeScrollType { get; set; }

        [DataMember]
        public int? ImageBoxLargeScrollAmount { get; set; }

        [DataMember]
        public PlaybackSequencing? PreferredPlaybackSequencing { get; set; }

        [DataMember]
        public int? RecommendedDisplayFrameRate { get; set;}

        public ImageBox()
        {
            referencedSOPInstanceUID = new List<string>();
            Position = new FramePosition();
            RowPosition = -1;
            ColumnPosition = -1;
            ImageBoxNumber = -1;
            ImageBoxLayoutType = ImageBoxLayoutType.Single;
            WindowWidth = -1;
            WindowCenter = -1;
            ReferencedPresentationStateSOP = string.Empty;
            HorizontalJustification = HorizontalJustification.Center;
            VerticalJustification = VerticalJustification.Center;
            ImageBoxSmallScrollType = ScrollType.None;
            ImageBoxLargeScrollType = ScrollType.None;  
        }

        public ImageBox(string sopInstanceUID) : this()
        {
            if (!string.IsNullOrEmpty(sopInstanceUID))
            {
                referencedSOPInstanceUID.Add(sopInstanceUID);
            }
        }

        public ImageBox(double _left, double _top, double _right, double _bottom) : this()
        {
            Position.leftTop = new LeadPointD(_left, _top);
            Position.rightBottom = new LeadPointD(_right, _bottom);
        }

        public ImageBox(string sopInstanceUID, double left, double top, double right, double bottom)            
            :this(left,top,right,bottom)
        {
            if (!string.IsNullOrEmpty(sopInstanceUID))
            {
                referencedSOPInstanceUID.Add(sopInstanceUID);
            }
        }
    }

    [DataContract]
    public class SeriesInfo
    {
        [DataMember]
        public string StudyInstanceUID { get; set; }
        [DataMember]
        public string SeriesInstanceUID { get; set; }
        [DataMember]
        public int ImageBoxNumber { get; set; }            
        [DataMember]                
        public string AnnotationData { get; set; }

        public SeriesInfo()
        {
            StudyInstanceUID = string.Empty;
            SeriesInstanceUID = string.Empty;            
            ImageBoxNumber = -1;
        }
    }

    [DataContract]
    public class OtherStudies
    {
        [DataMember]
        public string StudyInstanceUID { get; set; }
        [DataMember]
        public List<SeriesInfo> Series { get; set; }

        public OtherStudies()
        {
            StudyInstanceUID = string.Empty;
            Series = new List<SeriesInfo>();
        }
    }

    [DataContract]
    public class FirstFrame
    {
        [DataMember]
        public string SOPClassUID { get; set; }
        [DataMember]
        public string SOPInstanceUID { get; set; }
        [DataMember]
        public int FrameNumber { get; set; }
    }
}
