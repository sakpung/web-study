// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Leadtools.Dicom.Scu;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;
using Leadtools.Medical.PatientUpdater.AddIn.Queue;
using Leadtools.Dicom.Common.DataTypes.PatientUpdater;
using System.Diagnostics;
using System.Net;
using Leadtools.Logging;
using Leadtools.Logging.Medical;

namespace Leadtools.Medical.PatientUpdater.AddIn.Retry
{
   public class AutoRetryProcessor
   {
      private DirectoryInfo _RetryDir;
      private string _DicomDir;
      private int _Seconds;
      private int _Days;
      private Timer _RetryTimer;
      public static Dictionary<int, string> Actions = new Dictionary<int, string>();
      private const string _Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
      private static readonly Random _Random = new Random();
      private Type[] _UpdateTypes = { typeof(ChangePatient), typeof(ChangeSeries), typeof(CopyPatient), typeof(CopyStudy),
                                      typeof(DeletePatient), typeof(DeleteSeries), typeof(MergePatient), typeof(MergeStudy),
                                      typeof(MoveToNewPatient)};

      static AutoRetryProcessor()
      {
         Actions.Add(PatientUpdaterConstants.Action.ChangePatient, "ChangePatient");
         Actions.Add(PatientUpdaterConstants.Action.ChangeSeries, "ChangeSeries");
         Actions.Add(PatientUpdaterConstants.Action.CopyPatient, "CopyPatient");
         Actions.Add(PatientUpdaterConstants.Action.CopyStudy, "CopyStudy");
         Actions.Add(PatientUpdaterConstants.Action.DeletePatient, "DeletePatient");
         Actions.Add(PatientUpdaterConstants.Action.DeleteSeries, "DeleteSeries");
         Actions.Add(PatientUpdaterConstants.Action.MergePatient, "MergePatient");
         Actions.Add(PatientUpdaterConstants.Action.MergeStudy, "MergeStudy");
         Actions.Add(PatientUpdaterConstants.Action.MoveStudyToNewPatient, "MoveStudyToNewPatient");
      }

      public AutoRetryProcessor(string retryDir)
      {
         _DicomDir = Path.Combine(retryDir, @"Dicom\");
         try
         {            
            if (!Directory.Exists(retryDir))
            {               
               Directory.CreateDirectory(retryDir);               
            } 
           
            if(!Directory.Exists(_DicomDir))
            {
               Directory.CreateDirectory(_DicomDir);
            }
         }
         catch { }

         _RetryDir = new DirectoryInfo(retryDir);         
      }

      public void Start(int seconds, int days)
      {
         _Seconds = seconds;
         _Days = days;

         _RetryTimer = new Timer(RetryAutoUpdate, null, 1000 * seconds, Timeout.Infinite);
      }

      public void Stop()
      {
         if (_RetryTimer != null)
         {
            _RetryTimer.Change(Timeout.Infinite, Timeout.Infinite);
         }
      }

      private void RetryAutoUpdate(object state)
      {
         _RetryTimer.Change(Timeout.Infinite, Timeout.Infinite);
         try
         {            
            foreach (FileInfo fi in FileSearcher.GetFiles(_RetryDir, "*.xml", SearchOption.AllDirectories))
            {
               string xml = File.ReadAllText(fi.FullName);
               RetryInfo ri = xml.FromXml<RetryInfo>(_UpdateTypes);


               if (ri != null)
               {
                  string dicomPath = Path.Combine(_DicomDir, fi.Name);

                  dicomPath = Path.ChangeExtension(dicomPath, ".ds");
                  if (DateTime.Now > ri.Expires)
                  {
                     //
                     // Retry period has expired.  Delete File
                     //
                     Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined,
                                       DateTime.Now, LogType.Information, MessageDirection.None,
                                       "[Auto Update] NAction retry has passed expiration.  Item removed from update retry queue.", null,
                                        new SerializableDictionary<string, object>() { { "Filename", dicomPath } });
                     DeleteRetry(fi, dicomPath);
                     continue;
                  }

                  if (!File.Exists(dicomPath))
                  {                     
                     Logger.Global.Log(string.Empty,string.Empty,-1,string.Empty, string.Empty, -1,DicomCommandType.Undefined,
                                       DateTime.Now, LogType.Information, MessageDirection.None,
                                       "[Auto Update] File for retry action doesn't exit.  Item removed from update retry queue.", null,
                                        new SerializableDictionary<string, object>() { { "Filename", dicomPath } });
                     DeleteRetry(fi, dicomPath);
                  }

                  using (UpdateProcessor processor = new UpdateProcessor(Module.Options.UseCustomAE ? Module.Options.AutoUpdateAE : ri.Item.ClientAE))
                  {
                     DicomCommandStatusType status = DicomCommandStatusType.Reserved4;
                     bool failed = false;

                     try
                     {
                        string message = string.Empty;

                        using (DicomDataSet ds = new DicomDataSet(PatientUpdaterAddIn.TemporaryDirectory))
                        {
                           ds.Load(dicomPath, DicomDataSetLoadFlags.None);
                           ri.Scp.PeerAddress = IPAddress.Parse(ri.Address);
                           status = processor.SendUpdate(ri.Scp, ds, ri.Item.Action);
                           if (status != DicomCommandStatusType.Success)
                           {
                              if (status == DicomCommandStatusType.MissingAttribute || status == DicomCommandStatusType.AttributeOutOfRange)
                              {
                                 message = string.Format("[Auto Update] {0} failed. Item not found at destination [{1}].  Item will be removed from update retry queue.", AutoRetryProcessor.Actions[ri.Item.Action], ri.Item.SourceAE);
                                 UpdateProcessor.LogEvent(LogType.Warning, MessageDirection.None, message, DicomCommandType.Undefined, null, processor.Scu, null);
                              }
                              else
                              {
                                 failed = true;
                              }
                           }
                        }
                     }
                     catch (DicomException de)
                     {
                        string message = string.Format("[Auto Update] Error: {0}. Leaving {1} action to update retry queue.", de.Message, AutoRetryProcessor.Actions[ri.Item.Action]);

                        UpdateProcessor.LogEvent(LogType.Error, MessageDirection.Input, message, DicomCommandType.Undefined, null, processor.Scu, null);
                        failed = true;
                     }
                     catch (Exception e)
                     {
                        string message = "[Auto Update] " + e.Message;

                        Logger.Global.Log(string.Empty, string.Empty, -1, string.Empty, string.Empty, -1, DicomCommandType.Undefined,
                                       DateTime.Now, LogType.Error, MessageDirection.None,message,null,null);
                        failed = true;
                     }

                     if (!failed)
                     {
                        DeleteRetry(fi, dicomPath);
                     }                     
                  }
               }
            }
         }
         finally
         {
            _RetryTimer.Change(1000 * _Seconds, Timeout.Infinite);
         }
      }

      public void AddRetry(DicomScp scp, AutoUpdateItem item, string address)
      {
         RetryInfo info = new RetryInfo(scp, item, address);
         string fileName = GetActionFileName(item.Action);
         string infoPath = Path.Combine(_RetryDir.FullName, fileName + ".xml");
         string dicomPath = Path.Combine(_DicomDir, fileName + ".ds");

         try
         {                        
            info.Expires = DateTime.Now.AddDays(Module.Options.RetryDays);            
            //
            // Save the dataset
            //
            if (item.Dicom != null)
            {
               item.Dicom.Save(dicomPath, DicomDataSetSaveFlags.None);
            }
            File.WriteAllText(infoPath, info.ToXml(_UpdateTypes));
         }
         catch(Exception e)
         {
            Debug.WriteLine(e.Message);
         }         
      }

      private void DeleteRetry(FileInfo info, string dicomPath)
      {        
         try
         {
            if (File.Exists(dicomPath))
            {
               File.Delete(dicomPath);
            }
            info.Delete();
         }
         catch { }
         {
         }
      }

      private string GetActionFileName(int action)
      {
         while (true)
         {
            string fileName = Actions[action] + "_" + RandomString(5);

            if(!File.Exists(Path.Combine(_RetryDir.FullName, fileName)))
               return fileName;
         }
      }

      private static string RandomString(int size)
      {
         char[] buffer = new char[size];

         for (int i = 0; i < size; i++)
         {
            buffer[i] = _Chars[_Random.Next(_Chars.Length)];
         }
         return new string(buffer);
      }
   }
}
