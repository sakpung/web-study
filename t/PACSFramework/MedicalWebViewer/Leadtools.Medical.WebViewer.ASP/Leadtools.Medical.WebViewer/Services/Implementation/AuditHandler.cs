// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Xml;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.ServiceContracts;
using System.Web;

namespace Leadtools.Medical.WebViewer.Services.Implementation
{
   public class AuditHandler : IAuditHandler
   {
      IAuditLogAddin _AuditLogAddin = null;

      public AuditHandler(AddinsFactory factory)
      {
         _AuditLogAddin = factory.CreateAuditLogAddin();
      }

      private string GetRemoteIP()
      {
         try
         {
            var ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
               ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
         }
         catch
         {
            return null;
         }
      }

      #region IAuditLogHandler Members

      public void Log(string authenticationCookie, string user, string workstation, DateTime date, string details, string userData)
      {
         string userName = string.Empty;
         XmlDocument extra = null;

         userName = AuthHandler.Authenticate(authenticationCookie, impersonater: true);
         if (user == "?")
            user = userName;

         if (workstation == "?")
            workstation = GetRemoteIP();

         if (!string.IsNullOrEmpty(userData))
         {
            try
            {
               extra = new XmlDocument();
               extra.LoadXml(userData);
            }
            catch
            {
            }
         }

         _AuditLogAddin.Log(userName, workstation, date, details, extra);
      }
      #endregion
   }
}
