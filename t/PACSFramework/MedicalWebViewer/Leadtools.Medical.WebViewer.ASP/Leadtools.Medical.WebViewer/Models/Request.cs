// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Medical.WebViewer.Services.Interfaces;
using Leadtools.Medical.WebViewer.Wado;

namespace Leadtools.Medical.WebViewerModels
{
   [DataContract]
   public class WadoConnection : RemoteConnection
   {
      [DataMember]
      public string title { get; set; }
      [DataMember]
      public string dicomWebRoot { get; set; }
      [DataMember]
      public string wado { get; set; }
      [DataMember]
      public string qido { get; set; }
      [DataMember]
      public string rs { get; set; }
      [DataMember]
      public string stow { get; set; }
      [DataMember]
      public int stowMaxFiles { get; set; }
      [DataMember]
      public int stowMaxFileSize { get; set; }
   }

   internal static class RemoteConnectionFactory
   {
      public static bool IsPACS(RemoteConnection server)
      {
          if (null != server)
         {
            if(!string.IsNullOrEmpty(server.type))
            {
               return server.type.ToLower() == "pacs";
            }
         }
         return false;
      }
      public static bool IsWADO(RemoteConnection server)
      {
          if (null != server)
         {
            if(!string.IsNullOrEmpty(server.type))
            {
               return server.type.ToLower() == "wado";
            }
         }
         return false;
      }
      public static RemoteConnection Server(dynamic model)
      {
         var baseserver = BaseServer(model);
         
         if (IsWADO(baseserver))
         {
            var srv = model.server.ToObject<WadoConnection>();
            return srv;
         }
         else
         {
            var srv = model.server.ToObject<PACSConnection>();
            return srv;
         }
      }

      public static RemoteConnection BaseServer(dynamic model)
      {
         RemoteConnection server = null;
         if (model.server != null)
         {
            server = model.server.ToObject<RemoteConnection>();
         }
         return server;
      }

      public static RemoteQueryServiceConfig Config(WadoConnection wserver)
      {
         var config = new WadoServiceConfig()
         {
            Url = wserver.dicomWebRoot,
            QidoRsService = wserver.qido,
            WadoRsService = wserver.rs
         };
         return new RemoteQueryServiceConfig()
         {
            ServiceClass = "WadoServiceConfig",
            ServerInfo = config 
         };
      }
   }
}