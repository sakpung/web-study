// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.DataAccessLayers.Core
{
    public static class AnatomicRegionTable
    {    
        private static Dictionary<string, CodeSequence> _Modifers = new Dictionary<string,CodeSequence>();

        public static Dictionary<string, CodeSequence> Modifers 
        {
            get
            {
                return _Modifers;
            }
        }

        static AnatomicRegionTable()
        {
            _Modifers.Add("R-FB322", new CodeSequence() { CodeValue = "R-FB322", CodeMeaning = "Central incisor region", CodeSchemeDesignator = "SRT" });
            _Modifers.Add("R-FB35C", new CodeSequence() { CodeValue = "R-FB35C", CodeMeaning = "Lateral incisor region", CodeSchemeDesignator = "SRT" });
            _Modifers.Add("R-FB35B", new CodeSequence() { CodeValue = "R-FB35B", CodeMeaning = "Canine region", CodeSchemeDesignator = "SRT" }); 
            _Modifers.Add("R-FB35A", new CodeSequence() { CodeValue = "R-FB35A", CodeMeaning = "First premolar region", CodeSchemeDesignator = "SRT" });
            _Modifers.Add("R-FB359", new CodeSequence() { CodeValue = "R-FB359", CodeMeaning = "Second premolar region", CodeSchemeDesignator = "SRT" });
            _Modifers.Add("R-FB358", new CodeSequence() { CodeValue = "R-FB358", CodeMeaning = "First molar region", CodeSchemeDesignator = "SRT" });
            _Modifers.Add("R-FB356", new CodeSequence() { CodeValue = "R-FB356", CodeMeaning = "Second molar region", CodeSchemeDesignator = "SRT" });
            _Modifers.Add("R-FB354", new CodeSequence() { CodeValue = "R-FB354", CodeMeaning = "Third molar region", CodeSchemeDesignator = "SRT" });
        }
    }
}
