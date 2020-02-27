// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPatientService" in both code and config file together.
   [ServiceContract]
   public interface IPatientService
   {
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      bool UpdatePatient(string authenticationCookie, PatientInfo_Json info, DataContracts.ExtraOptions extraOptions);

      [OperationContract]
      [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      bool AddPatient(string authenticationCookie, PatientInfo_Json info, string userData);

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      bool DeletePatient(string patientId);

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      bool UpdatePatient2(string patientId, string patientName);
   }
}
