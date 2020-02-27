// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Medical.WebViewer.ServiceContracts;
using Leadtools.Dicom.AddIn.Audit;
using Leadtools.Medical.Logging.DataAccessLayer;
using Leadtools.Logging.Medical;
using Leadtools.Logging;
using System.Xml;
using System.Diagnostics;

namespace Leadtools.Medical.WebViewer.Addins
{
   public class AuditLogAddin : IAuditLogAddin
   {
      private ILoggingDataAccessAgent _DataAccessAgent;

      public AuditLogAddin(ILoggingDataAccessAgent dataAccessAgent)
      {
         _DataAccessAgent = dataAccessAgent;
      }

      #region IAuditLogAddin Members

      public void Log(string user, string workstation, DateTime date, string details, XmlDocument extra)
      {
          DicomLogEntry logEntry = new DicomLogEntry() { LogType = LogType.Audit };          

          logEntry.Description = details;
          //logEntry.CustomInformation = additionalInfo;
          logEntry.TimeStamp = date;
          logEntry.Source = "AuditLogAddin";
          logEntry.ClientAETitle = user;
          logEntry.ClientIPAddress = workstation;

          if(extra!=null)
          {
              Dictionary<string, string> extraData = new Dictionary<string, string>();
              XmlNodeList list = extra.GetElementsByTagName("extra");
              string extraInfo = string.Empty;

              if(list.Count > 0)
              {
                  extraData = list[0].ChildNodes.Cast<XmlNode>().ToDictionary(node => node.Name, node => node.InnerText);
              }

              extraInfo = string.Join("\n", extraData.Select(x => x.Key + " = " + x.Value).ToArray());
              logEntry.Description += "\n\n" + extraInfo;
          }
          
          _DataAccessAgent.AddDicomEventLog(logEntry);
      }

      #endregion
   }
}
