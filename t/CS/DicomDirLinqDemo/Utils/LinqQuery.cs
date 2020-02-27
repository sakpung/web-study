// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSDicomDirLinqDemo.Utils
{
    [Serializable]
    public class LinqQuery
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Query { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
