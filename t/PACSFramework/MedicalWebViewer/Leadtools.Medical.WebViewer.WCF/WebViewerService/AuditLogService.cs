// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using Leadtools.Medical.WebViewer.ServiceContracts;
using System.Web.Services;
using System.ServiceModel.Activation;
using Leadtools.Medical.WebViewer.Wcf.Helper;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Leadtools.Medical.WebViewer.DataContracts;
using System.Diagnostics;
using System;
using System.Xml;
using System.Net;

namespace Leadtools.Medical.WebViewer.Wcf
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [WebService(Namespace = "http://leadtools.com/")]
    public class AuditLogService : IAuditLogService
    {
        IAuditLogAddin _AuditLogAddin = null;

        public AuditLogService()
        {
           _AuditLogAddin = AddinsFactory.CreateAuditLogAddin();
        }

        private string GetRemoteIP()
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            HttpRequestMessageProperty httpMessage = prop[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            string host = httpMessage.Headers["Host"];

            if (httpMessage == null || string.IsNullOrEmpty(host))
            {
                RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

                host = endpoint.Address;
            }
            else
            {
                IPAddress[] addresses = Dns.GetHostAddresses(host);

                for (int i = 0; i < addresses.Length; i++)
                {
                    if (addresses[i].ToString().IndexOf(".") > -1)
                        host = addresses[i].ToString();
                }
            }

            return host;
        }

        #region IAuditLogService Members

        public void Log(string authenticationCookie, string user, string workstation, DateTime date, string details, string userData)
        {
            string userName = string.Empty;
            XmlDocument extra = null;

            userName = ServiceUtils.Authenticate(authenticationCookie);
            if (user == "?")
                user = userName;

            if (workstation == "?")
                workstation = GetRemoteIP();

            if(!string.IsNullOrEmpty(userData))
            {
                try
                {
                    extra = new XmlDocument();
                    extra.LoadXml(userData);
                }
                catch (Exception)
                {                                        
                }                
            }

            _AuditLogAddin.Log(userName, workstation, date, details, extra);
        }
        #endregion
    }
}
