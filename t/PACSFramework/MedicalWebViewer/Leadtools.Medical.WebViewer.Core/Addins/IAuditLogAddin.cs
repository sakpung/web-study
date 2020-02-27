// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Audit;
using System.Xml;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   public interface IAuditLogAddin
   {
       void Log(string user, string workstation, DateTime date, string details, XmlDocument extra);
   }
}
