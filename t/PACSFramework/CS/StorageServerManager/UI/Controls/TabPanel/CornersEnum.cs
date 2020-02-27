// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Demos.StorageServer.UI
{
    [System.Flags]
    public enum Corners
    {
       None = 0,
       TopLeft = 1,
       TopRight = 2,
       BottomLeft = 4,
       BottomRight = 8,
       All = TopLeft | TopRight | BottomLeft | BottomRight
    }
}
