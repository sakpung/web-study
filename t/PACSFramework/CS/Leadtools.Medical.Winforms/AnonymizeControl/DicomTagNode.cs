// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Dicom;

namespace Leadtools.Medical.Winforms.Anonymize
{
   public class DicomTagNode : DataGridViewRow
   {
      public DicomTag DicomTag { get; set; }
   }
}
