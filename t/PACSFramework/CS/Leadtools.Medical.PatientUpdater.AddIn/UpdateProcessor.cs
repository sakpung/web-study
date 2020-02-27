// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using Leadtools.Logging;
using Leadtools.Dicom;
using Leadtools.Logging.Medical;
using Leadtools.Dicom.Scu.Common;
using Leadtools.Medical.PatientUpdater.AddIn.Queue;
using Leadtools.Medical.PatientUpdater.AddIn.Retry;

namespace Leadtools.Medical.PatientUpdater.AddIn
{
   public class UpdateProcessor : IDisposable
   {
      private PatientUpdaterScu _Scu = null;

      public PatientUpdaterScu Scu
      {
         get { return _Scu; }         
      }

      public const string NACTION_PROCESSING_SEND = "[Auto Update] Sending NAction request. ^\tMessage ID: {0}.^\tPresentation ID: {1}.^\tAbstract Syntax: {2}.^\tAffected SOP instance UID: {3}.^\tAction: {4}";
      public const string NACTION_RESPONSE_RECEIVED = "[Auto Update] NAction response received.^\tMessage ID: {0}.^\tPresentation ID: {1}.^\tAbstract Syntax: {2}.^\tAffected SOP instance UID: {3}.^\tAction: {4}.^\tStatus: {5}";
      public const string CONNECT_REQUEST_SENT = "[Auto Update] Attempt to connect to server.";
      public const string CONNECT_RESPONSE_RECEIVED = "[Auto Update] Sucessfully connected to server.";
      public const string CONNECT_RESPONSE_RECEIVED_FAILURE = "[Auto Update] Failure to connect to server.^{0}";
      public const string ASSOCIATE_REQUEST_SENT = "[Auto Update] Associate request sent.^{0}";
      public const string ASSOCIATE_REQUEST_REJECTED = "[Auto Update] Association request rejected.^{0}";
      public const string ASSOCIATE_REQUEST_ACCEPTED = "[Auto Update] Association request accepted.";
      public const string RELEASE_REQUEST_SENT = "[Auto Update] Release request sent.";
      public const string RELEASE_RESPONSE_RECEIVED = "[Auto Update] Release response received.";

      public UpdateProcessor(string aetitle)
      {
         _Scu = new PatientUpdaterScu(PatientUpdaterAddIn.TemporaryDirectory);
         _Scu.BeforeNAction += new EventHandler<Leadtools.Dicom.Scu.Common.BeforeNActionEventArgs>(scu_BeforeNAction);
         _Scu.AfterNAction += new EventHandler<AfterNActionEventArgs>(scu_AfterNAction);
         _Scu.BeforeConnect += new BeforeConnectDelegate(scu_BeforeConnect);
         _Scu.AfterConnect += new AfterConnectDelegate(scu_AfterConnect);
         _Scu.BeforeAssociateRequest += new BeforeAssociationRequestDelegate(scu_BeforeAssociateRequest);
         _Scu.AfterAssociateRequest += new AfterAssociateRequestDelegate(scu_AfterAssociateRequest);
         _Scu.BeforeReleaseRequest += new EventHandler(scu_BeforeReleaseRequest);
         _Scu.AfterReleaseRequest += new EventHandler(scu_AfterReleaseRequest);         
         _Scu.AETitle = Module.Options.UseCustomAE ? Module.Options.AutoUpdateAE : aetitle; 
      }

      public DicomCommandStatusType SendUpdate(DicomScp scp,  DicomDataSet ds, int action)
      {
         DicomCommandStatusType status = DicomCommandStatusType.Reserved4;

         status = _Scu.SendUpdate(scp, ds, action, PatientUpdaterConstants.UID.PatientUpdateInstance);         
         return status;
      }

      void scu_AfterReleaseRequest(object sender, EventArgs e)
      {
         PatientUpdaterScu scu = sender as PatientUpdaterScu;

         LogEvent(LogType.Information, MessageDirection.Input, RELEASE_RESPONSE_RECEIVED, DicomCommandType.Undefined, null, scu, null);
      }

      void scu_BeforeReleaseRequest(object sender, EventArgs e)
      {
         PatientUpdaterScu scu = sender as PatientUpdaterScu;

         LogEvent(LogType.Information, MessageDirection.Output, RELEASE_REQUEST_SENT, DicomCommandType.Undefined, null, scu, null);
      }

      void scu_AfterAssociateRequest(object sender, AfterAssociateRequestEventArgs e)
      {
         PatientUpdaterScu scu = sender as PatientUpdaterScu;

         if (!e.Rejected)
         {
            LogEvent(LogType.Information, MessageDirection.Input, ASSOCIATE_REQUEST_ACCEPTED,
                     DicomCommandType.Undefined, null, scu, null);
         }
         else
         {
            LogEvent(LogType.Information, MessageDirection.Input, string.Format(ASSOCIATE_REQUEST_REJECTED, e.Reason),
                     DicomCommandType.Undefined, null, scu, null);
         }
      }

      void scu_BeforeAssociateRequest(object sender, BeforeAssociateRequestEventArgs e)
      {
         PatientUpdaterScu scu = sender as PatientUpdaterScu;

         LogEvent(LogType.Information, MessageDirection.Output, string.Format(ASSOCIATE_REQUEST_SENT, e.Associate.ToString()),
                  DicomCommandType.Undefined, null, scu, null);
      }

      void scu_BeforeConnect(object sender, BeforeConnectEventArgs e)
      {
         PatientUpdaterScu scu = sender as PatientUpdaterScu;

         LogEvent(LogType.Information, MessageDirection.Output, CONNECT_REQUEST_SENT, DicomCommandType.Undefined, null, scu, null);
      }

      void scu_AfterConnect(object sender, AfterConnectEventArgs e)
      {
         PatientUpdaterScu scu = sender as PatientUpdaterScu;
         string message = CONNECT_RESPONSE_RECEIVED;

         if (e.Error != DicomExceptionCode.Success)
         {
            message = string.Format(CONNECT_RESPONSE_RECEIVED_FAILURE, e.Error);
         }

         LogEvent(LogType.Information, MessageDirection.Input, message, DicomCommandType.Undefined, null, scu, null);
      }

      void scu_BeforeNAction(object sender, BeforeNActionEventArgs e)
      {
         PatientUpdaterScu scu = sender as PatientUpdaterScu;
         string message = string.Format(NACTION_PROCESSING_SEND, e.MessageID, e.PresentationID, e.AffectedClass, e.Instance, GetActionInfo(e.ActionType));

         //LogEvent(LogType.Information, MessageDirection.None, string.Format("[Auto Update] Sending Auto Update\n{0}", GetUserInformation(scu.Tag as PatientUpdate)), DicomCommandType.Undefined, null, scu, null);
         LogEvent(LogType.Information, MessageDirection.Output, message, DicomCommandType.NAction, e.DataSet, scu, null);
      }

      void scu_AfterNAction(object sender, AfterNActionEventArgs e)
      {
         PatientUpdaterScu scu = sender as PatientUpdaterScu;
         string message = string.Format(NACTION_RESPONSE_RECEIVED, e.MessageID, e.PresentationID, e.AffectedClass, e.Instance,
                                        GetActionInfo(e.ActionType), e.Status);

         LogEvent(LogType.Information, MessageDirection.Input, message, DicomCommandType.NAction, e.DataSet, scu, null);
         if (e.Status == DicomCommandStatusType.MissingAttribute || e.Status == DicomCommandStatusType.AttributeOutOfRange)
         {
            message = string.Format("{0} failed. Item not found at destination [{1}].  Item will not be added to update retry queue.", AutoRetryProcessor.Actions[e.ActionType], Scu.CurrentScp.AETitle);
            UpdateProcessor.LogEvent(LogType.Warning, MessageDirection.None, message, DicomCommandType.NAction, null, scu, null);
         }
         else
         {
            message = string.Format("Adding {0} action to update retry queue.", AutoRetryProcessor.Actions[e.ActionType]);
            UpdateProcessor.LogEvent(LogType.Debug, MessageDirection.None, message, DicomCommandType.Undefined, null, scu, null);            
         }
      }

      public static void LogEvent(LogType type, MessageDirection messageDirection, string description,
                                    DicomCommandType command, DicomDataSet dataset,
                                    PatientUpdaterScu Client, SerializableDictionary<string, object> customInformation)
      {
         try
         {
            string ae = Client.AETitle;
            DicomNet net = Client as DicomNet;

            SerializableDictionary<string, object> logCustomInformation = DicomLogEntry.CustomInformationDicomMessage;
            if (customInformation != null)
            {
               logCustomInformation = new SerializableDictionary<string, object>();
               foreach (KeyValuePair<string, object> kvp in customInformation)
               {
                  logCustomInformation.Add(kvp.Key, kvp.Value);
               }
               logCustomInformation.Add(DicomLogEntry.DicomMessageKey, DicomLogEntry.DicomMessageValue);
            }

            Logger.Global.Log(Module.Source, Client.CurrentScp.AETitle, Client.CurrentScp.PeerAddress.ToString(),
                              Client.CurrentScp.Port, net.IsAssociated() ? net.Association.Calling : ae,
                              net.HostAddress != null ? net.HostAddress.ToString() : string.Empty,
                              net.IsConnected() ? net.HostPort : -1, command, DateTime.Now, type,
                              messageDirection, description, dataset, logCustomInformation);
         }
         catch (Exception)
         {
         }
      }

      public string GetActionInfo(int action)
      {
         string info = action.ToString() + " (";

         switch (action)
         {
            case PatientUpdaterConstants.Action.ChangePatient:
               info += "Change Patient";
               break;
            case PatientUpdaterConstants.Action.ChangeSeries:
               info += "Change Series";
               break;
            case PatientUpdaterConstants.Action.CopyPatient:
               info += "Copy Patient";
               break;
            case PatientUpdaterConstants.Action.CopyStudy:
               info += "Copy Study";
               break;
            case PatientUpdaterConstants.Action.DeletePatient:
               info += "Delete Patient";
               break;
            case PatientUpdaterConstants.Action.DeleteSeries:
               info += "Delete Series";
               break;
            case PatientUpdaterConstants.Action.MergePatient:
               info += "Merge Patient";
               break;
            case PatientUpdaterConstants.Action.MergeStudy:
               info += "Merge Study";
               break;
            case PatientUpdaterConstants.Action.MoveStudyToNewPatient:
               info += "Move Study To New Patient";
               break;
         }
         info += ")";
         return info;
      }

      protected string GetUserInformation(PatientUpdate data)
      {
         StringBuilder sb = new StringBuilder();

         sb.Append("Transaction Information\n");
         sb.Append(string.Format("   Transaction UID: {0}\n", data.TransactionID));
         sb.Append(string.Format("   Station Name   : {0}\n", data.Station));
         sb.Append(string.Format("   User Name      : {0}\n", data.Operator));
         sb.Append(string.Format("   Description    : {0}\n", data.Description));
         sb.Append(string.Format("   Reason         : {0}\n", data.Reason));
         sb.Append(string.Format("   Date           : {0}\n", data.Date.HasValue ? data.Date.Value.ToShortDateString() : string.Empty));
         sb.Append(string.Format("   Time           : {0}\n", data.Time.HasValue ? data.Time.Value.ToShortDateString() : string.Empty));
         return sb.ToString();
      }

      #region IDisposable Members

      public void Dispose()
      {
         if (_Scu != null)
         {
            _Scu.BeforeNAction -= new EventHandler<Leadtools.Dicom.Scu.Common.BeforeNActionEventArgs>(scu_BeforeNAction);
            _Scu.AfterNAction -= new EventHandler<AfterNActionEventArgs>(scu_AfterNAction);
            _Scu.BeforeConnect -= new BeforeConnectDelegate(scu_BeforeConnect);
            _Scu.AfterConnect -= new AfterConnectDelegate(scu_AfterConnect);
            _Scu.BeforeAssociateRequest -= new BeforeAssociationRequestDelegate(scu_BeforeAssociateRequest);
            _Scu.AfterAssociateRequest -= new AfterAssociateRequestDelegate(scu_AfterAssociateRequest);
            _Scu.BeforeReleaseRequest -= new EventHandler(scu_BeforeReleaseRequest);
            _Scu.AfterReleaseRequest -= new EventHandler(scu_AfterReleaseRequest);
         }
      }

      #endregion
   }
}
