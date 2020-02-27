// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom;

namespace Leadtools.AddIn.Store
{
    public static class ExtensionMethods
    {
        public static bool HasTag(DicomDataSet ds,long Tag)
        {
            DicomElement element;

            element = ds.FindFirstElement(null, Tag, false);
            return (element != null);
        }
    }
}
