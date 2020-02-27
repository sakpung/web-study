// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom;

namespace Leadtools.Medical.Rules.AddIn.Scripting
{
   public delegate void SendCFindResponseDelegate(DicomClient Client, byte presentationID, int messageID, string affectedClass, DicomCommandStatusType status, DicomDS dataset);
   public delegate void ReceiveCStoreRequestDelegate(DicomClient Client, byte presentationID, int messageID, string affectedClass, string instance, DicomCommandPriorityType priority, string moveAE, int moveMessageID, DicomDS dataSet);
}
