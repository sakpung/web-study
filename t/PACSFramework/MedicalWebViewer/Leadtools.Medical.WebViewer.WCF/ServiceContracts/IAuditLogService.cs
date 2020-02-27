// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Leadtools.Dicom.AddIn.Audit;
using System.ServiceModel.Web;
using Leadtools.Medical.WebViewer.DataContracts;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   [ServiceContract]
   public interface IAuditLogService
   {
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]      
      void Log(string authenticationCookie, string user, string workstation, DateTime date, string details, string userData);
   }
}
