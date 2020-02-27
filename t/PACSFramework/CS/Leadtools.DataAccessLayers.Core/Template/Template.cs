// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Leadtools.DataAccessLayers.Core;

namespace Leadtools.DataAccessLayers.Core
{
   public enum AvailabilityLevel
   {
      None,
      Series,
      Study,
      SeriesAndStudy
   } ;

    [DataContract]
    public class Template
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime? Created { get; set; }

        [DataMember]
        public string Modality { get; set; }

        [DataMember]
        public string Comments { get; set; }

        [DataMember]
        public bool BuiltIn { get; set; }

        [DataMember]
        public bool Hidden { get; set; }

        [DataMember]
        public List<TemplateFrame> Frames { get; set; }

        [DataMember]
        public string OldId { get; set; }

        [DataMember]
        public string AutoMatching { get; set; }

        [DataMember]
        public AvailabilityLevel Availability { get; set; }

        public Template()
        {
           Frames = new List<TemplateFrame>();
           Availability = AvailabilityLevel.Series;
        }
    }      
}
