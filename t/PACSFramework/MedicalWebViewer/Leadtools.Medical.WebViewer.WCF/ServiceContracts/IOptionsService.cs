// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.ServiceModel.Web;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOptionsService" in both code and config file together.
    [ServiceContract]
    public interface IOptionsService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetUserOptions?auth={authenticationCookie}",
                BodyStyle = WebMessageBodyStyle.WrappedRequest,
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        Dictionary<string, string> GetUserOptions(string authenticationCookie);

        [OperationContract]
        [WebGet(UriTemplate = "/GetDefaultOptions?auth={authenticationCookie}",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        Dictionary<string, string> GetDefaultOptions(string authenticationCookie);

        [OperationContract]
        [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void SaveUserOption(string authenticationCookie, string optionName, string optionValue);

        [OperationContract]
        [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void SaveDefaultOptions(string authenticationCookie, Dictionary<string, string> options);

        [OperationContract]
        [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetRoleOption(string authenticationCookie, string role, string optionName);

        [OperationContract]
        [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void SaveRoleOptions(string authenticationCookie, string role, Dictionary<string, string> options);
    }
}
