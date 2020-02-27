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
using System.Threading;
using System.Web.Script.Serialization;
using System.ServiceModel.Activation;

namespace Leadtools.Medical.WebViewer.ExternalControl
{
   // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ExternalCommandQueueService" in both code and config file together.
   [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
   [ServiceBehavior(IncludeExceptionDetailInFaults = true, ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single, UseSynchronizationContext = false)]
   internal class ExternalCommandQueueService : IExternalCommandQueueService
   {
      public Queue<Command_Json> _commandQueue;

      public static ExternalCommandQueueService CurrentInstance { get; set; }

      private Guid _currentExternalControlAssociationToken = Guid.Empty;

      private Guid CurrentExternalControlAssociationToken
      {
         get
         {
            return _currentExternalControlAssociationToken;
         }

         set
         {
            _currentExternalControlAssociationToken = value;
         }
      }
      private WebViewerAuthenticationInfo _viewerAuthenticationInfo;

      private AutoResetEvent _currentResetEvent;
      private Dictionary<string, string> _currentResponse;
      private bool _isCurrentResetEventRetrievelOnly;
      private DateTime? _timeLastPositiveHeartBeat = null;
      private DateTime? _timeLastNegativeHeartBeat = null;      
      private Object _timeLock = new Object();

      public ExternalCommandQueueService()
      {
         ExternalCommandQueueService.CurrentInstance = this;
         _commandQueue = new Queue<Command_Json>();
      }

      public bool IsIdle(int milliSeconds)
      {
         lock (_timeLock)
         {
            if(!_timeLastNegativeHeartBeat.HasValue||!_timeLastPositiveHeartBeat.HasValue)
            {
               return false;
            }
            else
            {
               var span = _timeLastNegativeHeartBeat - _timeLastPositiveHeartBeat;
               return span > new TimeSpan(0, 0, 0, 0, milliSeconds);
            }            
         }
      }

      public bool HasCommands(String externalControlAssociationToken)
      {
         HeartBeat();
         if (externalControlAssociationToken != CurrentExternalControlAssociationToken.ToString() ||
             _viewerAuthenticationInfo == null)
         {
            lock (_timeLock)
            {
               _timeLastPositiveHeartBeat = DateTime.Now;
            }
            return true; // if this is request with mismatching association token, we will always send an end association command in GetCommands
         }

         if(_commandQueue.Count > 0)
         {
            lock (_timeLock)
            {
               _timeLastPositiveHeartBeat = DateTime.Now;
            }
            return true;
         }
         else
         {
            lock (_timeLock)
            {
               if (!_timeLastPositiveHeartBeat.HasValue)
               {
                  _timeLastPositiveHeartBeat = DateTime.Now;
               }
               _timeLastNegativeHeartBeat = DateTime.Now;
            }
            return false;
         }
      }

      public List<Command_Json> GetCommands(String externalControlAssociationToken)
      {
         List<Command_Json> commandList = new List<Command_Json>();

         if (externalControlAssociationToken != CurrentExternalControlAssociationToken.ToString() ||
             _viewerAuthenticationInfo == null)
         {
            commandList.Add(new Command_Json(ControllerCommandNames.EndAssociation, null));
            return commandList;
         }


         while (_commandQueue.Count > 0)
         {
            Command_Json command = _commandQueue.Dequeue();
            commandList.Add(command);
         }

         if (_isCurrentResetEventRetrievelOnly)
         {
            _currentResetEvent.Set();
            _isCurrentResetEventRetrievelOnly = false;
         }

         return commandList;
      }

      public ExternalControlAssociationStatus RequestExternalControl()
      {
         ExternalControlAssociationStatus externalControlAssociationStatus = new ExternalControlAssociationStatus();
         CurrentExternalControlAssociationToken = Guid.NewGuid();
         externalControlAssociationStatus.Accepted = true;
         externalControlAssociationStatus.Token = CurrentExternalControlAssociationToken.ToString();
         return externalControlAssociationStatus;
      }


      public event EventHandler<HeartBeatEventArgs> HeartBeatEvent;
      private static int nHeartBeat = 0;
      private void HeartBeat()
      {
         nHeartBeat++;
         if (HeartBeatEvent != null)
         {
            HeartBeatEvent(this, new HeartBeatEventArgs(nHeartBeat));
         }
      }

      public event EventHandler<LogoutEventArgs> LogoutEvent;
      public void LogoutNotify(string reason)
      {
         if (LogoutEvent != null)
         {
            LogoutEvent(this, new LogoutEventArgs(reason));
         }
      }

      public String GetViewerAuthenticationToken(String externalControlAssociationToken)
      {
         if (externalControlAssociationToken != CurrentExternalControlAssociationToken.ToString())
         {
            return null;
         }
         if (_viewerAuthenticationInfo == null)
         {
            return null;
         }
         else
         {
            return _viewerAuthenticationInfo.Token;
         }
      }

      public void EndAssociation()
      {
         CurrentExternalControlAssociationToken = Guid.Empty;
         _commandQueue.Clear();
      }

      internal void EnqueueCommand(string commandName)
      {
         EnqueueCommand(commandName, null, null, false);
      }

      internal void EnqueueCommand(string commandName, string[] commandArgs)
      {
         EnqueueCommand(commandName, commandArgs, null, false);
      }

      internal void EnqueueCommand(string commandName, string[] commandArgs, AutoResetEvent messageRecievedResetEvent)
      {
         EnqueueCommand(commandName, commandArgs, messageRecievedResetEvent, false);
      }

      internal void EnqueueCommand(string commandName, string[] commandArgs, AutoResetEvent messageRecievedResetEvent, bool isCurrentResetEventRetrievelOnly)
      {
         _currentResetEvent = null;

         _currentResponse = new Dictionary<string, string>();
         Command_Json command = new Command_Json(commandName, commandArgs);
         _commandQueue.Enqueue(command);

         if (messageRecievedResetEvent != null)
         {
            _currentResetEvent = messageRecievedResetEvent;
            _isCurrentResetEventRetrievelOnly = isCurrentResetEventRetrievelOnly;
         }
      }

      internal void SetWebtViewerAuthenticationInfo(WebViewerAuthenticationInfo info)
      {
         _viewerAuthenticationInfo = info;
      }


      public void ReceivePatientInfo(string externalControlAssociationToken, PatientInfo patientInfo)
      {
         if (externalControlAssociationToken != CurrentExternalControlAssociationToken.ToString())
            return;

         Utilities.PopulateToDictionary<PatientInfo>(patientInfo, _currentResponse);

         if (_currentResetEvent != null)
            _currentResetEvent.Set();
      }

      public void ReceiveImageInfo(string found, string seriesInstanceUID, string captureDate, string imageType, string comment, string toothGroups, string externalControlAssociationToken)
      {
         if (externalControlAssociationToken != CurrentExternalControlAssociationToken.ToString())
            return;


         _currentResponse.Add("FoundInstance", found);
         if (found != "true")
         {
            if (_currentResetEvent != null)
               _currentResetEvent.Set();
            return;
         }

         string decodedCaptureDate = decodeDate(captureDate);

         _currentResponse.Add("SopInstanceUID", seriesInstanceUID);
         _currentResponse.Add("CaptureDate", decodedCaptureDate);
         _currentResponse.Add("ImageType", imageType);
         _currentResponse.Add("Comment", comment);
         _currentResponse.Add("ToothGroups", toothGroups);
         if (_currentResetEvent != null)
            _currentResetEvent.Set();
      }

      public void ReceiveImageURL(string imageURL, string externalControlAssociationToken)
      {
         if (externalControlAssociationToken != CurrentExternalControlAssociationToken.ToString())
            return;

         string decodedImageURL = System.Web.HttpUtility.UrlDecode(imageURL);
         _currentResponse["ImageURL"]= imageURL;

         if (_currentResetEvent != null)
            _currentResetEvent.Set();
      }

      public void ReceiveGenericActionStatus(string status, string externalControlAssociationToken)
      {
         if (externalControlAssociationToken != CurrentExternalControlAssociationToken.ToString())
            return;

         _currentResponse.Add(ControllerReturnType.GenericActionStatus, status);

         if (_currentResetEvent != null)
            _currentResetEvent.Set();
      }

      public Dictionary<string, string> GetLastResponse()
      {
         return _currentResponse;
      }

      private string decodeDate(string encodedDate)
      {
         string decodedCaptureDate = encodedDate.Replace('_', ' ');
         decodedCaptureDate = decodedCaptureDate.Replace('!', ':');
         return decodedCaptureDate.Replace('.', '/');

      }

   }

   public class HeartBeatEventArgs : EventArgs
   {
      private int _count;

      public int Count
      {
         get { return _count; }
         set { _count = value; }
      }
      public HeartBeatEventArgs(int count)
      {
         _count = count;
      }
   }

   public class LogoutEventArgs : EventArgs
   {
      private string _reason;

      public string Reason
      {
         get { return _reason; }
         set { _reason = value; }
      }

      public LogoutEventArgs(string reason)
      {
         _reason = reason;
      }
   }
}
