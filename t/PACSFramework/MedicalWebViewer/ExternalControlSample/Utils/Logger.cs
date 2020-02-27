// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Medical.WebViewer.ExternalControl;

namespace ExternalControlSample
{
   public static class Logger
   {
      private static ListView _listViewLog = null;
      private static MedicalWebViewerExternalController _controller = null;

      public static MedicalWebViewerExternalController Controller
      {
         get { return _controller; }
         set { _controller = value; }
      }

      public static ListView ListViewLog
      {
         get { return Logger._listViewLog; }
         set { Logger._listViewLog = value; }
      }

      delegate void LogMessageCallback(string command, params string[] list);

      public static void LogMessage(string command, params string[] list)
      {
         if (_listViewLog == null)
            return;

         if (_listViewLog.InvokeRequired)
         {
            LogMessageCallback cb = new LogMessageCallback(LogMessage);
            _listViewLog.Invoke(cb, command, list);
         }
         else
         {
            ListViewItem lvi = _listViewLog.Items.Add(command);
            foreach (string s in list)
            {
               lvi.SubItems.Add(s);
            }
            _listViewLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            _listViewLog.EnsureVisible(_listViewLog.Items.Count - 1);
         }
      }

      public static void LogMessage(string command, PatientInfo info)
      {
         Logger.LogMessage(
               command,
               string.Format("PatientId: {0}", info.PatientId),
               string.Format("Name:  {0}", info.Name),
               string.Format("BirthDate:  {0}", info.BirthDate),
               string.Format("Sex:  {0}", info.Sex),
               string.Format("EthnicGroup:  {0}", info.EthnicGroup),
               string.Format("Comments:  {0}", info.Comments)
               );
      }

      public static void LogMessage(PatientInfo info)
      {
         Logger.LogMessage(
               string.Empty,
               string.Format("PatientId: {0}", info.PatientId),
               string.Format("Name:  {0}", info.Name),
               string.Format("BirthDate:  {0}", info.BirthDate),
               string.Format("Sex:  {0}", info.Sex),
               string.Format("EthnicGroup:  {0}", info.EthnicGroup),
               string.Format("Comments:  {0}", info.Comments)
               );
      }

      public static void LogMessageLine(string command, params string[] list)
      {
         if (_listViewLog == null)
            return;

         string result = string.Empty;
         foreach (string s in list)
         {
            result = result + " " + s;
         }
         
         ListViewItem lvi = _listViewLog.Items.Add(command);
         lvi.SubItems.Add(result.Trim());

         _listViewLog.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
         _listViewLog.EnsureVisible(_listViewLog.Items.Count - 1);
      }

      public static void LogControllerResult(string command, ControllerReturnCode code)
      {
         switch (code)
         {
            case ControllerReturnCode.Success:
               Logger.LogMessageLine(command, "Success");
               break;

            case ControllerReturnCode.AlreadyInitialized:
               Logger.LogMessageLine(command, "Error: AlreadyInitialized");
               break;

            case ControllerReturnCode.AuthenticationFailure:
               Logger.LogMessageLine(command, "Error: AuthenticationFailure");
               Logger.LogMessageLine(string.Empty, _controller.FailureMessage);
               break;

            case ControllerReturnCode.Failure:
               Logger.LogMessageLine(command, "Error: Failure", _controller.FailureMessage);
               break;

            case ControllerReturnCode.NotProperlyInitiated:
               Logger.LogMessageLine(command, "Error: NotProperlyInitiated");
               break;

            case ControllerReturnCode.TimedOut:
               Logger.LogMessageLine(command, "Error: TimedOut");
               break;

            case ControllerReturnCode.UnknownError:
               Logger.LogMessageLine(command, "Error: UnknownError");
               break;

            case ControllerReturnCode.InvalidViewerUrl:
               Logger.LogMessageLine(command, "Error: InvalidViewerUrl ");
               Logger.LogMessageLine(string.Empty, _controller.FailureMessage);
               break;

            case ControllerReturnCode.InvalidServiceUrl:
               Logger.LogMessageLine(command, "Error: InvalidServiceUrl");
               Logger.LogMessageLine(string.Empty, _controller.FailureMessage);
               break;
         }

      }
   }
}
