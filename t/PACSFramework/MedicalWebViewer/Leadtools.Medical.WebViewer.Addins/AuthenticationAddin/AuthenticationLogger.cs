// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Logging.Medical;
using Leadtools.Logging;
using Leadtools.Medical.Logging.DataAccessLayer;
using Leadtools.Medical.OptionsDataAccessLayer;
using System.ServiceModel.Web;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Net;
using System.Web;

namespace Leadtools.Medical.WebViewer.Addins
{
    public static class AuthenticationLogger
    {
        public static IOptionsDataAccessAgent OptionsAgent { get; set; }

        public static void AddUser(this ILoggingDataAccessAgent loggingAgent, string authUser, string userName)
        {
            if (CanLog("LogSecuritySettingChanges"))
            {
                Log(loggingAgent, authUser, "Add New User: " + userName);
            }
        }

        public static void AddRole(this ILoggingDataAccessAgent loggingAgent, string authUser,string roleName)
        {
            if (CanLog("LogSecuritySettingChanges"))
            {
                Log(loggingAgent, authUser, "Add New Role: " + roleName);
            }
        }

        public static void DeleteUser(this ILoggingDataAccessAgent loggingAgent, string authUser, string userName)
        {
            if (CanLog("LogSecuritySettingChanges"))
            {
                Log(loggingAgent, authUser, "Deleted User: " + userName);
            }
        }

        public static void DeleteRole(this ILoggingDataAccessAgent loggingAgent, string authUser, string roleName)
        {
            if (CanLog("LogSecuritySettingChanges"))
            {
                Log(loggingAgent, authUser, "Deleted Role: " + roleName);
            }
        }

        public static void ChangePermission(this ILoggingDataAccessAgent loggingAgent, string authUser, string userName, string permission, string action)
        {
            if (CanLog("LogSecuritySettingChanges"))
            {
                string details = action + " " + permission + " permission: " + userName;

                Log(loggingAgent, authUser, details);
            }
        }

        public static void Login(this ILoggingDataAccessAgent loggingAgent, string userName, bool successful)
        {
            if (CanLog("LogUserSecurity"))
           {
               if(successful)
                   Log(loggingAgent, userName, "Login successful");
               else
                   Log(loggingAgent, userName, "Login failed");
           }
        }

        public static void LogSettingChanges(this ILoggingDataAccessAgent loggingAgent, string userName, string description)
        {
            if (CanLog("LogSettingChanges"))
            {
                Log(loggingAgent, userName,description);
            }
        }

        public static void Log(ILoggingDataAccessAgent loggingAgent, string authUser, string description)
        {
            DicomLogEntry logEntry = new DicomLogEntry() { LogType = LogType.Audit };

            logEntry.Description = description;
            logEntry.ClientAETitle = authUser;
            logEntry.ClientIPAddress = GetClientIp();
            logEntry.TimeStamp = DateTime.Now;
            logEntry.Source = "AuditLogAddin";

            if (!string.IsNullOrEmpty(logEntry.ClientAETitle) && logEntry.ClientAETitle.Length>16)
               logEntry.ClientAETitle = logEntry.ClientAETitle.Substring(0, 16); 

            loggingAgent.AddDicomEventLog(logEntry);
        }

        public static String GetClientIp()
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
       
        public static bool CanLog(string item)
        {
            bool enable = false;
            bool logSecurity = false;

            enable = OptionsAgent.Get<bool>("EnableAuditLog", false);
            logSecurity = OptionsAgent.Get<bool>(item, false);
            return enable && logSecurity;
        }
    }
}
