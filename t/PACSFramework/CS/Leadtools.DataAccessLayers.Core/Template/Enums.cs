// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.DataAccessLayers.Core
{
    public enum FrameRotation
    {
        None,
        Rotate90,
        Rotate180,
        Rotate270
    }

    public enum FrameHorizontalJustication
    {
        Left,
        Center,
        Right
    }

    public enum FrameVerticalJustification
    {
        Top,
        Center,
        Bottom
    }

    public enum PresentationSizeMode
    {
        ScaleToFit,
        TrueSize,       
        Magnify
    }
}
