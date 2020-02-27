// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Dicom;
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom.Common.DataTypes.HangingProtocol;
using Leadtools.Dicom.Common.Editing.Converters;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Medical.WebViewer.DataContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Leadtools.Medical.WebViewer.Core.DataTypes
{
    [DataContract]
    public class WCFHangingProtocol : HangingProtocol
    {
        [DataMember]
        public string WCFHangingProtocolCreationDateTime
        {
            get
            {
                if (HangingProtocolCreationDateTime.HasValue)
                    return HangingProtocolCreationDateTime.Value.ToString();
                return string.Empty;
            }
            set
            {
                DateTime dt;

                if (DateTime.TryParse(value, out dt))
                {
                    HangingProtocolCreationDateTime = dt;
                }
            }
        }

        [DataMember]
        public int Rows { get; set; }

        [DataMember]
        public int Columns { get; set; }        

        [DataMember]        
        public List<WCFDisplaySet> DisplaySets { get; set; }                     
    }

    [DataContract]
    public class WCFDisplaySet : DisplaySet
    {
        [DataMember]
        public List<DataContracts.ImageBox> Boxes { get; set; }
    }

    public class HangingProtocolEx : HangingProtocol
    {
        [Element(DicomTag.ImageDisplayFormat)]
        public string ImageDisplayFormat { get; set; }

        [Element(DicomTag.DisplaySetsSequence)]
        public new List<DisplaySetEx> DisplaySetsSequence { get; set; }


        // If modality contains more than one value, create a hp definition for each modality and add to the list.
       public void NormalizeHangingProtocolDefinitionSequence()
        {
           List<HangingProtocolDefinition> hpDefinitionListNew = new List<HangingProtocolDefinition>();

           foreach (HangingProtocolDefinition hpd in HangingProtocolDefinitionSequence)
           {
              string[] modalities = hpd.Modality.Split("\\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
              int count = modalities.Length;
              if (count <= 1)
              {
                 hpDefinitionListNew.Add(hpd);
              }
              else
              {
                 hpd.Modality = modalities[0];
                 hpDefinitionListNew.Add(hpd);

                 for (int i = 1; i < count; i++)
                 {
                    HangingProtocolDefinition hpDefinitionNew = HangingProtocolDefinition.Copy(hpd);
                    hpDefinitionNew.Modality = modalities[i];
                    hpDefinitionListNew.Add(hpDefinitionNew);
                 }
              }
           }

          HangingProtocolDefinitionSequence = new List<HangingProtocolDefinition>(hpDefinitionListNew);
        }
    }

    public class DisplaySetEx : DisplaySet
    {
        [Element(DicomTag.ImageBoxesSequence)]
        public new List<HPWCFImageBox> ImageBoxesSequence { get; set; }
    }

    public class HPWCFImageBox : Dicom.Common.DataTypes.ImageBox
    {
        [Element(DicomTag.ImageDisplayFormat)]
        public string ImageDisplayFormat { get; set; }

        [Element(DicomTag.Grid)]
       public List<double> Position { get; set; }

        [Element(DicomTag.ImageBoxTileHorizontalDimension)]
        public int? ImageBoxTileHorizontalDimension { get; set; }

        [Element(DicomTag.ImageBoxTileVerticalDimension)]
        public int? ImageBoxTileVerticalDimension { get; set; }

        [Element(DicomTag.ImageBoxScrollDirection)]
        [TypeConverter(typeof(EnumValueConverter<ScrollDirection?>))]
        public ScrollDirection? ImageBoxScrollDirection { get; set; }

        [Element(DicomTag.ImageBoxSmallScrollType)]
        [TypeConverter(typeof(EnumValueConverter<ScrollType?>))]
        public ScrollType? ImageBoxSmallScrollType { get; set; }

        [Element(DicomTag.ImageBoxSmallScrollAmount)]
        public int? ImageBoxSmallScrollAmount { get; set; }

        [Element(DicomTag.ImageBoxLargeScrollType)]
        [TypeConverter(typeof(EnumValueConverter<ScrollType?>))]
        public ScrollType? ImageBoxLargeScrollType { get; set; }

        [Element(DicomTag.ImageBoxLargeScrollAmount)]
        public int? ImageBoxLargeScrollAmount { get; set; }
    }

    public enum ScrollType
    {
        // NONE is not in the DICOM spec, but is needed if there is no scrolling
        [EnumValue("NONE")]
        None,

        [EnumValue("PAGE")]
        Page,

        [EnumValue("ROW_COLUMN")]
        RowColumn,

        [EnumValue("IMAGE")]
        Image
    }

    public enum ScrollDirection
    {
       // NONE is not in the DICOM spec, but is needed if there is no scrolling
        [EnumValue("NONE")]
        None,

        [EnumValue("VERTICAL")]
        Vertical,

        [EnumValue("HORIZONTAL")]
        Horizontal,
    }

    [DataContract]
    public class DisplaySetView
    {
        [DataMember]
        public int DisplaySetNumber { get; set; }

       // If HasValue, then this is part of an MPR Reformatted set
      [DataMember]
      public int? ParentDisplaySetNumber { get; set; }

      [DataMember]
      public InitialViewDirection ? ReformattingOperationView{ get; set; }

        [DataMember]
        public SeriesData Series { get; set; }
    }
}
