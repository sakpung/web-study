// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using System.Web;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom.Server.Admin;
using Leadtools.Logging;
using Leadtools.Dicom;

namespace Leadtools.Medical.Rules.AddIn.Scripting.Actions
{
   public class ScriptUtils
   {
      private const string GetReferencedFile = "99F19F47-C51B-4961-82EC-FBD7C1091390";
      private static ThreadSafeDictionary<string, Action<DicomDS,string, string, string>> _Callbacks = new ThreadSafeDictionary<string, Action<DicomDS, string, string, string>>();

      static ScriptUtils()
      {
         if (Module.Service != null)
         {
            Module.Service.Message += new EventHandler<MessageEventArgs>(Service_Message);
         }
      }

      public static Cache Cache
      {
         get
         {
            return HttpRuntime.Cache;
         }
      }

      public static void get_dataset(string sopInstanceUID, Action<DicomDS,string, string, string> datasetFile, int numRetries, int retryInterval)
      {
         AsyncHelper.Execute(() =>
         {
            if (Module.Service != null)
            {
               try
               {
                  if (_Callbacks.ContainsKey(sopInstanceUID))
                     _Callbacks[sopInstanceUID] = datasetFile;
                  else
                     _Callbacks.Add(sopInstanceUID, datasetFile);
                  Module.Service.SendMessage(GetReferencedFile, sopInstanceUID, numRetries, retryInterval);
               }
               catch(Exception e)
               {
                  Logger.Global.SystemException(string.Empty, e);
               }
            }
         });         
      }

      static void Service_Message(object sender, MessageEventArgs e)
      {
         if (e.Message.Message == GetReferencedFile)
         {
            try
            {
               string sopInstanceUID = e.Message.Data[0].ToString();

               if (_Callbacks.ContainsKey(sopInstanceUID))
               {
                  DicomServer server = ServiceLocator.Retrieve<DicomServer>();

                  if (e.Message.Data.Count == 2)
                  {
                     try
                     {
                        string referencedFile = e.Message.Data[1].ToString();

                        if (referencedFile != null && referencedFile.Length > 0)
                        {
                           DicomDataSet ds = new DicomDataSet(server.TemporaryDirectory);

                           ds.Load(referencedFile, DicomDataSetLoadFlags.None);
                           _Callbacks[sopInstanceUID](new DicomDS(ds), referencedFile, sopInstanceUID, string.Empty);
                        }
                        else
                        {
                           Logger.Global.SystemMessage(LogType.Information,"Referenced file for (" + sopInstanceUID + ") not found", string.Empty);
                        }
                     }
                     catch (Exception ex)
                     {
                        Logger.Global.SystemException(string.Empty, ex);
                        _Callbacks[sopInstanceUID](null, string.Empty, sopInstanceUID, "Invalid message response for GetReferenceFile");
                     }
                  }
                  else
                  {
                     _Callbacks[sopInstanceUID](null, string.Empty, sopInstanceUID, "Invalid message response for GetReferenceFile");
                  }
                  _Callbacks.Remove(sopInstanceUID);
               }
            }
            catch (Exception exception)
            {
               Logger.Global.SystemException(string.Empty, exception);               
            }
         }         
      }

      public static long MakeTag(int Group, int Element)
      {
         return (((Group) << 16) | Element);
      }
   }
}
